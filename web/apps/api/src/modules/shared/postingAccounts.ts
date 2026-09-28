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
