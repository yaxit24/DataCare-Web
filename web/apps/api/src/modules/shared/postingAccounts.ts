import type { VoucherScope } from '../vouchers/numbering.js';

/**
 * Posting accounts, resolved from configuration or refused (P0-04).
 *
 * THE DEFECT THIS EXISTS TO REMOVE
 * ================================
 * Posting paths across finance, sales, purchase, manufacturing and tag modules ended their account
 * resolution with a literal: `input.kasarAc ?? 'KASAR'`, `settlementAc()` returning `'CASH'`,
 * `DEFAULT_STOCK_ADJ_AC = 'STKADJ'`. Those strings are not accounts. They are placeholders that happen to
 * exist in the provisioning seed, so on a seeded demo company a voucher looks correct, while on a real
 * migrated company the same voucher posts to an account code that either belongs to something else or does
 * not exist at all — and it posts SILENTLY, after consuming a voucher serial.
 *
 * Measured evidence that the placeholders are wrong rather than merely ugly: the real leg-02 rows on book
 * 001 all name `00001`, that book's `BOOK_DETL` slot 1; rate-cut books 034/064 name `00003`/`00042`/`00098`
 * for cash/kasar/fine. No real dataset contains an account called `CASH` or `KASAR`.
 *
 * THE RULE
 * ========
 * An account reaches a ledger column only if it came from one of:
 *
 *   1. an explicit caller value (the operator chose it, or the family measured it),
 *   2. `BOOK_DETL`, the desktop's per-book account SLOT table,
 *   3. company/item/group configuration,
 *
 * and otherwise the voucher is REFUSED before numbering and before any write. There is no fourth option and
 * deliberately no default: a wrong account is worse than a refused voucher, because a refusal is visible in
 * the same second while a misposting is discovered at year end.
 *
 * `PostingAccountValidationError` carries `ValidationError` in its name so the route error mapper answers
 * 400 rather than 500 — the caller supplied an unpostable request, the server did not fail.
 */
export class PostingAccountValidationError extends Error {
  readonly role: PostingAccountRole;
  readonly detail: string;
  constructor(role: PostingAccountRole, detail: string) {
    super(`${role} account is not configured: ${detail}`);
    this.name = 'PostingAccountValidationError';
    this.role = role;
    this.detail = detail;
  }
}

/**
 * The posting roles that were previously satisfied by a literal.
 *
 * A role is a BUSINESS position in a voucher, not an account name. Two families can hold the same role in
 * different `BOOK_DETL` slots — cash settlement is slot 1 on a cash book and slot 2 on a sale book — so the
 * slot stays with the caller that measured it and the role only names what is being resolved, which is what
 * the error message needs in order to be actionable.
 */
export type PostingAccountRole =
  | 'party-control'
  | 'cash-settlement'
  | 'bank-settlement'
  | 'kasar'
  | 'round-off'
  | 'labour-expense'
  | 'stock-adjustment'
  | 'weight-difference'
  | 'advance-settlement'
  | 'refund-settlement'
  | 'write-off';

const clean = (value: unknown): string => String(value ?? '').trim();

/**
 * Accept an account only if it is actually present.
 *
 * For a role whose account cannot be derived from configuration — an operator-chosen refund account, a
 * labour expense head that no measured `BOOK_DETL` slot covers — this is the whole enforcement: the caller
 * supplies it or the voucher does not post. `context` names the voucher family and the amount that made the
 * account necessary, so the operator is told what to configure rather than that something was null.
 */
export function requirePostingAccount(
  role: PostingAccountRole,
  value: unknown,
  context: string,
): string {
  const account = clean(value);
  if (!account) {
    throw new PostingAccountValidationError(
      role,
      `${context} — supply the account explicitly or configure it on the book`,
    );
  }
  return account;
}

/**
 * Resolve one `BOOK_DETL` slot for the current book, honouring an explicit caller value first.
 *
 * Deliberately separate from `bookPolicy.resolveBookAccountTx`: that one additionally matches `MAIN_BOOK`
 * and `BOOK_INOUT` because a sale book must not answer with a purchase row, and it requires a `BookPolicy`
 * that only the sale/purchase/return workflows construct. Cash, payment, scheme and order books have no
 * `workflowPolicy` entry, so they need slot resolution without that pairing — but they still must fail
 * closed on a missing, blank or duplicated slot, which is the part that was missing.
 */
export async function resolveBookSlotAccountTx(
  tx: any,
  scope: VoucherScope,
  role: PostingAccountRole,
  srNo: number,
  explicit?: unknown,
): Promise<string> {
  const chosen = clean(explicit);
  if (chosen) return chosen;
  const rows: Array<{ AC_CODE?: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE" FROM "BOOK_DETL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        AND coalesce("SR_NO",0)::numeric=$5::numeric
      ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
    srNo,
  );
  const accounts = rows.map((row) => clean(row.AC_CODE)).filter(Boolean);
  if (rows.length > 1) {
    throw new PostingAccountValidationError(
      role,
      `book ${scope.coBook} has more than one account in slot ${srNo}`,
    );
  }
  if (accounts.length !== 1) {
    throw new PostingAccountValidationError(
      role,
      `book ${scope.coBook} slot ${srNo} is ${rows.length ? 'blank' : 'missing'}`,
    );
  }
  return accounts[0] as string;
}

export interface BookSlotRow {
  srNo: number;
  accountCode: string;
  shortName: string;
  mainBook: string;
  dataType: string;
  bookType: string;
}

/**
 * Every BOOK_DETL slot of a book with the per-slot metadata some desktop posting helpers read from
 * BOOK_DETL rather than BOOK_DATA (e.g. Ac_Ledr.EInvoice_Ledr takes VCH_TYPE, BOOK_NAME and DATA_TYPE
 * from the slot row). A duplicated slot fails closed; a missing or blank slot is the caller's decision,
 * made through `requireBookSlot` only for the slots a voucher actually posts to.
 */
export async function resolveBookSlotRowsTx(
  tx: any,
  scope: VoucherScope,
  role: PostingAccountRole,
): Promise<Map<number, BookSlotRow>> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "SR_NO","AC_CODE","BOOK_SNAME","MAIN_BOOK","DATA_TYPE","BOOK_TYPE" FROM "BOOK_DETL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 ORDER BY "SR_NO",row_id`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  const slots = new Map<number, BookSlotRow>();
  for (const row of rows) {
    const srNo = Number(row.SR_NO);
    if (slots.has(srNo)) {
      throw new PostingAccountValidationError(
        role,
        `book ${scope.coBook} has more than one account in slot ${srNo}`,
      );
    }
    slots.set(srNo, {
      srNo,
      accountCode: clean(row.AC_CODE),
      shortName: clean(row.BOOK_SNAME),
      mainBook: clean(row.MAIN_BOOK),
      dataType: clean(row.DATA_TYPE),
      bookType: clean(row.BOOK_TYPE),
    });
  }
  return slots;
}

export type DataRefreshAccountCandidatePart =
  'BANK_RECONCILE_CURRENT' | 'BANK_RECONCILE_EXPECTED' | 'BOOK_DATA' | 'BOOK_DETL' | 'CASH_DATA';

/** Complete, ordered identity and value record used to bind a Data Refresh Account preview. */
export interface DataRefreshAccountCandidate {
  part: DataRefreshAccountCandidatePart;
  rowId: string;
  businessKey: string;
  sourceKey: string | null;
  stored: string | null;
  expected: string | null;
}

export interface DataRefreshAccountCandidateScope {
  coCode: string;
  lcCode?: string;
  coYear?: string;
}

/**
 * Read every Account-classification candidate in one statement. This belongs at the shared BOOK_DETL boundary:
 * it inventories incomplete slot metadata but does not resolve a posting account or collapse duplicate slots.
 */
export async function selectDataRefreshAccountCandidatesTx(
  tx: any,
  scope: DataRefreshAccountCandidateScope,
  reconcileAccountGroups: readonly string[],
): Promise<DataRefreshAccountCandidate[]> {
  return tx.$queryRawUnsafe(
    `SELECT * FROM (
       SELECT 'BOOK_DATA'::text AS part,t.row_id::text AS "rowId",
              jsonb_build_array(t."CO_CODE",t."LC_CODE",t."CO_BOOK")::text AS "businessKey",
              NULL::text AS "sourceKey",t."DATA_TYPE" AS stored,'A'::text AS expected
         FROM "BOOK_DATA" t
        WHERE t.tenant_id=current_setting('app.tenant_id', true)
          AND t."CO_CODE"=$1 AND ($2::text='' OR t."LC_CODE"=$2)
          AND coalesce(t."DATA_TYPE",'')=''
       UNION ALL
       SELECT 'BOOK_DETL',t.row_id::text,
              jsonb_build_array(t."CO_CODE",t."LC_CODE",t."CO_BOOK",t."SR_NO",t."AC_CODE")::text,
              NULL::text,t."DATA_TYPE",'A'::text
         FROM "BOOK_DETL" t
        WHERE t.tenant_id=current_setting('app.tenant_id', true)
          AND t."CO_CODE"=$1 AND ($2::text='' OR t."LC_CODE"=$2)
          AND coalesce(t."DATA_TYPE",'')=''
       UNION ALL
       SELECT 'CASH_DATA',c.row_id::text,
              jsonb_build_array(c."CO_CODE",c."LC_CODE",c."CO_YEAR",c."CO_BOOK",c."VCH_NO",c."SR_NO")::text,
              NULL::text,to_char(c."CLR_DATE",'YYYY-MM-DD'),to_char(c."VCH_DATE",'YYYY-MM-DD')
         FROM "CASH_DATA" c
        WHERE c.tenant_id=current_setting('app.tenant_id', true)
          AND c."CO_CODE"=$1 AND ($2::text='' OR c."LC_CODE"=$2)
          AND ($3::text='' OR c."CO_YEAR"=$3)
          AND c."CLR_DATE" IS NULL AND c."VCH_DATE" IS NOT NULL
       UNION ALL
       SELECT 'BANK_RECONCILE_CURRENT',r.row_id::text,
              jsonb_build_array(r."CO_CODE",r."LC_CODE",r."LEDR_KEY")::text,
              NULL::text,to_char(r."CLR_DATE",'YYYY-MM-DD'),NULL::text
         FROM "BANK_RECONCILE" r
        WHERE r.tenant_id=current_setting('app.tenant_id', true)
          AND r."CO_CODE"=$1 AND ($2::text='' OR r."LC_CODE"=$2)
       UNION ALL
       SELECT 'BANK_RECONCILE_EXPECTED',a.row_id::text,
              jsonb_build_array(a."CO_CODE",a."LC_CODE",a."LEDR_KEY")::text,
              jsonb_build_array(a."CO_YEAR",a."CO_BOOK",a."VCH_NO",a."AC_CODE")::text,
              NULL::text,to_char(a."CLR_DATE",'YYYY-MM-DD')
         FROM "AC_DATA" a
         JOIN "AC_MAST" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE"
              AND b."AC_CODE"::text=a."AC_CODE"::text
        WHERE a.tenant_id=current_setting('app.tenant_id', true)
          AND a."CO_CODE"=$1 AND ($2::text='' OR a."LC_CODE"=$2)
          AND b."AC_GR" = ANY($4::text[])
     ) candidate
     ORDER BY part,"businessKey","sourceKey","rowId"`,
    scope.coCode,
    scope.lcCode ?? '',
    scope.coYear ?? '',
    [...reconcileAccountGroups],
  );
}
