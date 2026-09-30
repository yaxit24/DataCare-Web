import type { VoucherScope } from '../vouchers/numbering.js';
export class BookPolicyValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'BookPolicyValidationError';
  }
}

export type BookWorkflow =
  | 'SALES'
  | 'SALES QUOTATION'
  | 'SALES ORDER'
  | 'TOUR ORDER'
  | 'PURCHASE'
  | 'PURCHASE QUOTATION'
  | 'CONSIGNMENT PURCHASE'
  | 'SALES RETURN'
  | 'WHOLESALE SALE RETURN'
  | 'PURCHASE RETURN'
  | 'VP REC'
  | 'VP PARCEL';

export interface BookPolicy {
  coBook: string;
  vchType: string;
  bookName: string;
  mainBook: string;
  inout: string;
}

/**
 * The MAIN_BOOK / direction each workflow demands. Exported so company provisioning derives the values it
 * seeds from THIS table instead of restating them: the desktop's own strings include `SALES RETURNE` and
 * the abbreviated `PURC RETURN`, and a provisioning copy that spelled them the obvious way created books
 * that could never post.
 */
export const workflowPolicy: Record<BookWorkflow, { mainBook: string; inout: 'I' | 'O' }> = {
  SALES: { mainBook: 'SALES', inout: 'O' },
  'SALES QUOTATION': { mainBook: 'SL QUOT', inout: 'O' },
  'SALES ORDER': { mainBook: 'SALES ORDER', inout: 'O' },
  'TOUR ORDER': { mainBook: 'TOUR ORDER', inout: 'I' },
  PURCHASE: { mainBook: 'PURCHASE', inout: 'I' },
  'PURCHASE QUOTATION': { mainBook: 'PR QUOT', inout: 'O' },
  'CONSIGNMENT PURCHASE': { mainBook: 'CON PUR', inout: 'I' },
  'SALES RETURN': { mainBook: 'SALES RETURNE', inout: 'I' },
  'WHOLESALE SALE RETURN': { mainBook: 'WH RTN', inout: 'I' },
  'PURCHASE RETURN': { mainBook: 'PURC RETURN', inout: 'O' },
  'VP REC': { mainBook: 'VP REC', inout: 'I' },
  'VP PARCEL': { mainBook: 'VP PARCEL', inout: 'O' },
};

export async function resolveBookPolicyTx(
  tx: any,
  scope: VoucherScope,
  workflow: BookWorkflow,
  options: { requireExplicitMainBook?: boolean; expectedTable?: string } = {},
): Promise<BookPolicy> {
  const expected = workflowPolicy[workflow];
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "CO_BOOK","BOOK_SNAME","BOOK_NAME","MAIN_BOOK","BOOK_INOUT","BOOK_TBL_NAME"
       FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        AND coalesce(nullif(btrim("CUR_USE"::text),''),'Y') <> 'N'
      ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  if (rows.length !== 1) {
    throw new BookPolicyValidationError(
      rows.length
        ? `book configuration is ambiguous: ${scope.coBook}`
        : `book not found: ${scope.coBook}`,
    );
  }
  const row = rows[0] as Record<string, unknown>;
  const configuredMain = String(row.MAIN_BOOK ?? '')
    .trim()
    .toUpperCase();
  if (options.requireExplicitMainBook && !configuredMain) {
    throw new BookPolicyValidationError(`book ${scope.coBook} has no configured workflow family`);
  }
  const configuredTable = String(row.BOOK_TBL_NAME ?? '')
    .trim()
    .toUpperCase();
  if (options.expectedTable && configuredTable && configuredTable !== options.expectedTable) {
    throw new BookPolicyValidationError(
      `book ${scope.coBook} uses ${configuredTable}, expected ${options.expectedTable}`,
    );
  }
  if (configuredMain && configuredMain !== expected.mainBook) {
    throw new BookPolicyValidationError(
      `book ${scope.coBook} is ${configuredMain}, expected ${expected.mainBook}`,
    );
  }
  const configuredInout = String(row.BOOK_INOUT ?? '')
    .trim()
    .toUpperCase();
  if (configuredInout && configuredInout !== expected.inout) {
    throw new BookPolicyValidationError(
      `book ${scope.coBook} direction is ${configuredInout}, expected ${expected.inout}`,
    );
  }
  const coBook = String(row.CO_BOOK ?? scope.coBook ?? '').trim();
  const vchType = String(row.BOOK_SNAME ?? '').trim() || coBook;
  const mainBook = configuredMain || expected.mainBook;
  return {
    coBook,
    vchType,
    bookName: mainBook,
    mainBook,
    inout: configuredInout || expected.inout,
  };
}

/** Desktop AC_DATA uses BOOK_DETL.AC_CODE as the configured contra/control account.
 * Missing or duplicate rows must fail closed rather than inventing a request/default account. */
export async function resolveBookAccountTx(
  tx: any,
  scope: VoucherScope,
  policy: BookPolicy,
  srNo: number,
): Promise<string> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE"
       FROM "BOOK_DETL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        AND coalesce("SR_NO",0)::numeric=$5::numeric
        AND upper(btrim(coalesce("MAIN_BOOK"::text,'')))=$6
        AND upper(btrim(coalesce("BOOK_INOUT"::text,'')))=$7
      ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
    srNo,
    policy.mainBook,
    policy.inout,
  );
  const accounts = rows.map((row) => String(row.AC_CODE ?? '').trim()).filter(Boolean);
  if (rows.length !== 1 || accounts.length !== 1) {
    throw new BookPolicyValidationError(
      `book ${scope.coBook} account row ${srNo} is ${rows.length ? 'ambiguous or blank' : 'missing'}`,
    );
  }
  return accounts[0] as string;
}

/** The complete configured BOOK_DETL slot row, fail-closed exactly like resolveBookAccountTx.
 * The Sale Return numeric write path needs the whole slot (BOOK_SNAME/DATA_TYPE as well as
 * AC_CODE) to compose the Rojmel effect projection, so it reads it through THIS kernel module
 * rather than duplicating an inline BOOK_DETL LIMIT 1 read that could silently take the first
 * row. Missing, blank-account or duplicated slots refuse. */
export async function resolveBookSlotRowTx(
  tx: any,
  scope: VoucherScope,
  srNo: number,
): Promise<Record<string, string | null>> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "CO_CODE"::text AS "CO_CODE","LC_CODE"::text AS "LC_CODE","CO_BOOK"::text AS "CO_BOOK",
        "MAIN_BOOK"::text AS "MAIN_BOOK","BOOK_INOUT"::text AS "BOOK_INOUT","BOOK_TYPE"::text AS "BOOK_TYPE",
        "BOOK_SNAME"::text AS "BOOK_SNAME","DATA_TYPE"::text AS "DATA_TYPE","SR_NO"::text AS "SR_NO",
        "AC_CODE"::text AS "AC_CODE"
       FROM "BOOK_DETL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        AND coalesce("SR_NO",0)::numeric=$5::numeric
      ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
    srNo,
  );
  if (rows.length !== 1 || !String(rows[0]!.AC_CODE ?? '').trim()) {
    throw new BookPolicyValidationError(
      `book ${scope.coBook} account row ${srNo} is ${rows.length ? 'ambiguous or blank' : 'missing'}`,
    );
  }
  return rows[0] as Record<string, string | null>;
}
