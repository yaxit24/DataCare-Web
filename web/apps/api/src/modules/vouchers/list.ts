import { withTxBudget } from '../shared/txBudget.js';

/**
 * Generic "recent vouchers" list for a header table + book — powers the reusable <VoucherList> that
 * gives every transaction screen navigate / load-to-edit / delete (desktop ◀▶/Delete). Read-only;
 * RLS-scoped; table is allow-listed. Amount/name columns are detected (tables differ). Delete is done
 * by each module's own reversible DELETE endpoint (createSale→/sales/:vchNo etc.).
 *
 * N51 milestone 1 (G28): the list is scoped to the session's COMPLETE voucher identity: company, location,
 * year and book. It used to filter on company and book only. It then showed vouchers from other locations
 * and years, while Load and Delete act on the session's location and year by number. Clicking such a row could
 * therefore load or delete a DIFFERENT voucher that happened to share its number. Each row now also
 * returns its full identity, so callers act on exactly the row shown.
 */
const ALLOWED = new Set([
  'SL_DATA',
  'PR_DATA',
  'PAY_DATA',
  'CASH_DATA',
  'CONTRA_DATA',
  'KR_DATA',
  'LBR_DATA',
  'APR_DATA',
  'SL_ORD_DATA',
  'LDR_ADJ_DATA',
  'EMP_DATA',
  'DHRN_REC_DATA',
  'DHRN_ISU_DATA',
  'CARD_DATA',
  'CUT_DATA',
  'MFG_DATA',
  // Tag Opening and Only Tag Entry (TR_TAG_OPBL): the voucher number box and the F1 list (N172).
  'BAR_DATA',
]);
const IDENTITY_COLUMNS = ['CO_CODE', 'LC_CODE', 'CO_YEAR', 'CO_BOOK', 'VCH_NO'];
const qid = (c: string): string => '"' + c.replace(/[^A-Za-z0-9_]/g, '') + '"';

export interface VoucherListScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
}

export interface VoucherRow {
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
  vchNo: string;
  vchDate: string | null;
  vchType: string | null;
  acCode: string;
  acName: string;
  total: number;
}

export async function recentVouchers(
  prisma: any,
  scope: VoucherListScope,
  table: string,
  book: string,
  limit = 50,
): Promise<VoucherRow[]> {
  if (!ALLOWED.has(table)) return [];
  // Fail closed: without a complete scope the list cannot tell this session's vouchers from another's.
  if (!scope.coCode || !scope.lcCode || !scope.coYear || !book) return [];
  const n = Math.min(Number(limit) || 50, 200);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const colRows: { column_name: string }[] = await tx.$queryRawUnsafe(
      `SELECT column_name FROM information_schema.columns
        WHERE table_schema=current_schema() AND table_name=$1`,
      table,
    );
    const cols = new Set(colRows.map((c) => c.column_name));
    if (!IDENTITY_COLUMNS.every((c) => cols.has(c))) return [];
    const amtCol = [
      'TOT_AMT',
      'NET_AMT',
      'TOT_DR_AMT',
      'SL_NET_AMT',
      'REC_AMT',
      'DIFF_AMT',
      'SALARY_AMT',
      'CARD_AMT',
      'DHRN_AMT',
    ].find((c) => cols.has(c));
    const nameSel = cols.has('AC_NAME') ? '"AC_NAME"' : `''`;
    const typeSel = cols.has('VCH_TYPE') ? `coalesce("VCH_TYPE",'')` : `''`;
    const acSel = cols.has('AC_CODE') ? `coalesce("AC_CODE",'')` : `''`;
    const amtSel = amtCol
      ? `coalesce(NULLIF(${qid(amtCol)}::text,'')::numeric,0)::float`
      : '0::float';
    const dateSel = cols.has('VCH_DATE') ? `"VCH_DATE"::text` : 'NULL';
    // The header table can hold several rows per voucher (party leg + tax + old-gold components share one
    // VCH_NO). The desktop voucher navigator lists ONE row per voucher, so collapse with DISTINCT ON and
    // pick the representative row: prefer a row that carries the party code, then the largest amount.
    const pickOrder = [
      '"VCH_NO"',
      cols.has('AC_CODE') ? `(CASE WHEN coalesce("AC_CODE",'')<>'' THEN 0 ELSE 1 END)` : '',
      amtCol ? `${amtSel} DESC` : '',
      cols.has('VCH_DATE') ? `"VCH_DATE" DESC NULLS LAST` : '',
    ]
      .filter(Boolean)
      .join(', ');
    const outerOrder = `${cols.has('VCH_DATE') ? 'vd DESC NULLS LAST,' : ''} length(vch) DESC, vch DESC`;
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM (
         SELECT DISTINCT ON ("VCH_NO") "VCH_NO" vch, ${dateSel} vd, ${typeSel} vt, ${acSel} ac, ${nameSel} acn, ${amtSel} tot
           FROM ${qid(table)}
          WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 AND "CO_YEAR"=$3 AND "CO_BOOK"=$4
           ORDER BY ${pickOrder}
       ) x ORDER BY ${outerOrder} LIMIT ${n}`,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      book,
    );
    return rows.map((r) => ({
      coCode: scope.coCode,
      lcCode: scope.lcCode,
      coYear: scope.coYear,
      coBook: book,
      vchNo: String(r.vch ?? ''),
      vchDate: r.vd ? String(r.vd).slice(0, 10) : null,
      vchType: r.vt ?? null,
      acCode: String(r.ac ?? ''),
      acName: String(r.acn ?? ''),
      total: Number(r.tot),
    }));
  });
}

/** What the voucher number box does after Up or Down (N172, G179). */
export type NeighbourVoucher =
  /** A saved voucher was found: open it. */
  | { action: 'open'; vchNo: string }
  /** The walk reached the next new number (the desktop's LastVchNo): show a blank new voucher. */
  | { action: 'new' }
  /** Up at or past the next new number: the desktop says "Last Record...". */
  | { action: 'last' }
  /** Down below voucher 2: the desktop does nothing. */
  | { action: 'none' }
  /** The walk ended on a number with no voucher: the desktop shows an empty form with that number. */
  | { action: 'missing'; vchNo: string };

export class VoucherNeighbourValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'VoucherNeighbourValidationError';
  }
}

/** VB `Conversion.Val` for a voucher number: the leading digits, or 0. */
const val = (value: string): number => Number(/^\s*(\d+)/.exec(value)?.[1] ?? 0);
const voucherText = (n: number): string => String(n).padStart(5, '0');

/**
 * The desktop voucher number box (`tVchNo_KeyDown`, TR_SALE.cs:17068-17096, TR_PURC.cs:14407-14432) maps Up to
 * BtnLast_Click and Down to BtnFirst_Click. Despite their names they step to the NEXT and PREVIOUS saved voucher:
 *
 * - Up (TR_SALE.cs:17193-17222): at or past LastVchNo (the next new number, MAX(VCH_NO)+1 from CLEAR_DATA :14197-14208)
 *   it says "Last Record...". Otherwise it tries number+1, +2, ... and stops at the first saved voucher or at LastVchNo,
 *   for at most 10 tries, then displays the number it stopped on (an 11th number after 10 misses).
 * - Down (TR_SALE.cs:17164-17191): below 2 it does nothing. Otherwise it tries number-1, -2, ... and stops at the first
 *   saved voucher or at 1, for at most 10 tries, then displays that number.
 *
 * DISPLAY_DATA (:14226) opens a saved voucher, or leaves an empty form in add mode when the number has none.
 * `from` is the number in the box; an empty box is the new-entry state, whose box shows LastVchNo on the desktop.
 */
export async function neighbourVoucher(
  prisma: any,
  scope: VoucherListScope,
  table: string,
  book: string,
  from: string,
  direction: string,
): Promise<NeighbourVoucher> {
  if (!ALLOWED.has(table))
    throw new VoucherNeighbourValidationError(`unknown voucher table ${table}`);
  if (direction !== 'next' && direction !== 'previous')
    throw new VoucherNeighbourValidationError('direction must be next or previous');
  if (!scope.coCode || !scope.lcCode || !scope.coYear || !book)
    throw new VoucherNeighbourValidationError('the session has no company, location, year or book');
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const identity = `"CO_CODE"=$1 AND "LC_CODE"=$2 AND "CO_YEAR"=$3 AND "CO_BOOK"=$4`;
    const params = [scope.coCode, scope.lcCode, scope.coYear, book];
    const maxRows: Array<{ max: string | null }> = await tx.$queryRawUnsafe(
      `SELECT MAX("VCH_NO") AS max FROM ${qid(table)} WHERE ${identity}`,
      ...params,
    );
    const max = maxRows[0]?.max ?? null;
    const lastNo = max ? val(max) + 1 : 1; // CLEAR_DATA: "00001" when the book is empty
    const fromNo = from.trim() === '' ? lastNo : val(from);
    const step = direction === 'next' ? 1 : -1;
    if (direction === 'next' && fromNo >= lastNo) return { action: 'last' };
    if (direction === 'previous' && fromNo < 2) return { action: 'none' };
    const candidates = Array.from({ length: 11 }, (_, i) => fromNo + step * (i + 1)).filter(
      (n) => n >= 1,
    );
    const found: Array<{ vch: string }> = await tx.$queryRawUnsafe(
      `SELECT DISTINCT "VCH_NO" AS vch FROM ${qid(table)} WHERE ${identity} AND "VCH_NO" = ANY($5::text[])`,
      ...params,
      candidates.map(voucherText),
    );
    const saved = new Set(found.map((row) => val(row.vch)));
    const stop = direction === 'next' ? lastNo : 1;
    let number = fromNo + step;
    for (let tries = 1; tries <= 10; tries++) {
      if (saved.has(number) || number === stop) break;
      number += step;
    }
    if (saved.has(number)) return { action: 'open', vchNo: voucherText(number) };
    if (number === lastNo) return { action: 'new' };
    return { action: 'missing', vchNo: voucherText(number) };
  });
}
