import { withTxBudget, SNAPSHOT_READ } from '../shared/txBudget.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';

export class CreditNoteValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'CreditNoteValidationError';
  }
}

type Row = Record<string, unknown>;
type CompleteScope = VoucherScope & { coBook: string; coYear: string };
/** TR_SL_EBILL saved-document families: credit notes (inward) and e-invoices (outward). */
export type EBillDocumentFamily = 'E CRNT' | 'E INVOICE';
const DIRECTION: Record<EBillDocumentFamily, 'I' | 'O'> = { 'E CRNT': 'I', 'E INVOICE': 'O' };

function completeScope(scope: VoucherScope): CompleteScope {
  if (!scope.coBook?.trim() || !scope.coYear?.trim()) {
    throw new CreditNoteValidationError('Select a credit-note book and financial year.');
  }
  return { ...scope, coBook: scope.coBook.trim(), coYear: scope.coYear.trim() };
}

/** TR_SL_EBILL opens the chosen E CRNT / E INVOICE book, never a voucher number across SL_DATA. */
async function creditBook(
  tx: any,
  scope: CompleteScope,
  family: EBillDocumentFamily = 'E CRNT',
): Promise<Row> {
  const rows: Row[] = await tx.$queryRawUnsafe(
    `SELECT "CO_BOOK","BOOK_NAME","BOOK_SNAME","BOOK_SR_NAME","MAIN_BOOK","BOOK_INOUT",
            "BOOK_TBL_NAME","CUR_USE" FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  if (rows.length !== 1)
    throw new CreditNoteValidationError('Credit-note book is missing or ambiguous.');
  const row = rows[0]!;
  if (
    String(row.MAIN_BOOK ?? '')
      .trim()
      .toUpperCase() !== family ||
    String(row.BOOK_INOUT ?? '')
      .trim()
      .toUpperCase() !== DIRECTION[family] ||
    String(row.CUR_USE ?? '')
      .trim()
      .toUpperCase() === 'N' ||
    (String(row.BOOK_TBL_NAME ?? '').trim() && String(row.BOOK_TBL_NAME).trim() !== 'SL_DATA')
  ) {
    throw new CreditNoteValidationError(
      family === 'E CRNT'
        ? 'Selected book is not an active E Credit Note book.'
        : 'Selected book is not an active E Invoice book.',
    );
  }
  return row;
}

const scopeArgs = (s: CompleteScope) => [s.tenantId, s.coCode, s.lcCode, s.coYear, s.coBook];
const WHERE = `tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5`;

export async function listCreditNotes(
  prisma: any,
  rawScope: VoucherScope,
  query: { search?: string; offset?: number; limit?: number } = {},
  family: EBillDocumentFamily = 'E CRNT',
) {
  const scope = completeScope(rawScope);
  const limit = query.limit ?? 50;
  const offset = query.offset ?? 0;
  if (
    !Number.isSafeInteger(limit) ||
    limit < 1 ||
    limit > 100 ||
    !Number.isSafeInteger(offset) ||
    offset < 0 ||
    offset > 100000
  ) {
    throw new CreditNoteValidationError('Invalid credit-note page.');
  }
  const search = String(query.search ?? '').trim();
  if (search.length > 100)
    throw new CreditNoteValidationError('Search must be at most 100 characters.');
  // Literal substring search: wildcard characters typed by an operator stay literal.
  const pattern = `%${search.replace(/[\\%_]/g, '\\$&')}%`;
  return withTxBudget(prisma, scope.tenantId, SNAPSHOT_READ, async (tx: any) => {
    const book = await creditBook(tx, scope, family);
    const rows: Row[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO", "VCH_DATE"::text AS "VCH_DATE", "BILL_NO", "AC_CODE", "AC_NAME",
              "NET_AMT", "TAX_AMT", "TOT_AMT", "BILL_OS", "IRN_NO", "ACK_NO"
         FROM "SL_DATA" WHERE ${WHERE}
          AND ($6='%%' OR "VCH_NO" ILIKE $6 OR "BILL_NO" ILIKE $6 OR "AC_CODE" ILIKE $6 OR "AC_NAME" ILIKE $6)
        ORDER BY "VCH_DATE" DESC NULLS LAST, "VCH_NO" DESC, row_id DESC LIMIT $7 OFFSET $8`,
      ...scopeArgs(scope),
      pattern,
      limit + 1,
      offset,
    );
    return { book, rows: rows.slice(0, limit), hasMore: rows.length > limit, offset, limit };
  });
}

/** Complete persisted header, real parent/child rows, and registration state in one read snapshot.
 * Date/time values are serialized by PostgreSQL, so a browser's timezone cannot shift the business date.
 */
export async function getCreditNote(
  prisma: any,
  rawScope: VoucherScope,
  voucherNo: unknown,
  family: EBillDocumentFamily = 'E CRNT',
) {
  const scope = completeScope(rawScope);
  const vchNo = formatVoucherNo(String(voucherNo ?? ''));
  return withTxBudget(prisma, scope.tenantId, SNAPSHOT_READ, async (tx: any) => {
    const book = await creditBook(tx, scope, family);
    const args = [...scopeArgs(scope), vchNo];
    const headers: { data: Row }[] = await tx.$queryRawUnsafe(
      `SELECT to_jsonb(a)-'tenant_id'-'row_id' AS data FROM "SL_DATA" a WHERE ${WHERE} AND "VCH_NO"=$6 LIMIT 2`,
      ...args,
    );
    if (!headers.length) return null;
    if (headers.length !== 1)
      throw new CreditNoteValidationError('Credit-note identity is ambiguous.');
    const read = async (table: 'SL_DETL' | 'SL_IDTL', order: string): Promise<Row[]> => {
      const rows: { data: Row }[] = await tx.$queryRawUnsafe(
        `SELECT to_jsonb(a)-'tenant_id'-'row_id' AS data FROM "${table}" a WHERE ${WHERE} AND "VCH_NO"=$6 ORDER BY ${order}, row_id`,
        ...args,
      );
      return rows.map((row) => row.data);
    };
    const lines = await read('SL_DETL', '"SR_NO"');
    const components = await read('SL_IDTL', '"SR_NO","ISR_NO"');
    const parentIds = new Set<string>();
    const childIds = new Set<string>();
    for (const line of lines) {
      const id = String(line.SR_NO ?? '');
      if (!id || parentIds.has(id))
        throw new CreditNoteValidationError('Credit-note item identity is missing or duplicated.');
      parentIds.add(id);
    }
    // EInvoice's child join uses OLD_SRNO, which can differ from the visible row number.
    for (const child of components) {
      const id = `${child.SR_NO}|${child.ISR_NO}`;
      const sourceParents = lines.filter(
        (line) => line.OLD_SRNO != null && String(line.OLD_SRNO) === String(child.SR_NO),
      );
      const parents = sourceParents.length
        ? sourceParents
        : lines.filter((line) => String(line.SR_NO) === String(child.SR_NO));
      if (child.SR_NO == null || child.ISR_NO == null || childIds.has(id) || parents.length !== 1) {
        throw new CreditNoteValidationError(
          'Credit-note component identity is duplicated or has no parent.',
        );
      }
      childIds.add(id);
      child.parentSrNo = parents[0]!.SR_NO;
    }
    const registrations: Row[] = await tx.$queryRawUnsafe(
      `SELECT "IRN_NO","ACK_NO","ACK_DATE"::text AS "ACK_DATE", "QR_DATA" IS NOT NULL AS "HAS_QR"
         FROM "E_DATA" WHERE ${WHERE} AND "VCH_NO"=$6`,
      ...args,
    );
    return {
      book,
      header: headers[0]!.data,
      lines,
      components,
      registration: registrations[0] ?? null,
    };
  });
}

export const listEInvoices = (
  prisma: any,
  scope: VoucherScope,
  query: { search?: string; offset?: number; limit?: number } = {},
) => listCreditNotes(prisma, scope, query, 'E INVOICE');
export const getEInvoice = (prisma: any, scope: VoucherScope, voucherNo: unknown) =>
  getCreditNote(prisma, scope, voucherNo, 'E INVOICE');
