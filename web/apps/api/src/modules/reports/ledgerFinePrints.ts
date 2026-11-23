import { round, toIsoDate } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import {
  AccountLedgerValidationError,
  AccountNotFoundError,
  SIGNED_GOLD,
  SIGNED_MONEY,
  SIGNED_SILVER,
  acDataScope,
  num,
  txt,
  type LedgerScope,
} from './accountLedgerShared.js';
import { GOLD_SOURCES, JAMA_UDHAR_SOURCES, SILVER_SOURCES } from './ledgerFineSources.js';

/**
 * Ledger Report fine prints (desktop RP_LEDR JmaUdr, Gold and Silver buttons), read-only (WP-20, D-20-2).
 * The desktop clears and refills the shared FINE_DATA table before it opens Crystal; the web builds the same
 * rows and the same report parameters in memory and writes nothing, so two operators can never overwrite each
 * other (the unscoped `DELETE FROM FINE_DATA` at RP_LEDR.cs:8255 is not ported).
 *
 * Opening-ledger (OP_LDR) rows never enter these figures: both balance queries read AC_DATA only.
 */

export type FinePrintKind = 'jama-udhar' | 'gold-fine' | 'silver-fine';

/** The message the desktop shows when a print button is pressed without the print right. */
// RP_LEDR.cs:8236 {{Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);}}
export const NO_PRINT_RIGHTS_TEXT = 'You Have No Print Rights.....';
// RP_LEDR.cs:8667 {{Please Select Lc Code and Try...}}
export const NO_LC_CODE_TEXT = 'Please Select Lc Code and Try...';

export const FINE_PRINT_PATHS: readonly string[] = [
  '/reports/account-ledger/jama-udhar',
  '/reports/account-ledger/gold-fine',
  '/reports/account-ledger/silver-fine',
];

/** The refusal text for a print-right failure on one of these routes, else undefined. */
export function finePrintRefusalText(url: string, action: string): string | undefined {
  if (action !== 'print') return undefined;
  const base = url.replace(/\/export\.(pdf|xlsx)$/, '');
  return FINE_PRINT_PATHS.includes(base) ? NO_PRINT_RIGHTS_TEXT : undefined;
}

export interface FinePrintQuery {
  acCode: string;
  fromDate: string;
  toDate: string;
  dataType?: string;
  /** The Hz layout answer (the Yes/No question box). */
  hz: boolean;
  /** `location` was sent on the request: undefined when absent, '' when sent empty. */
  location?: string;
}

export interface FinePrintRow {
  section: number;
  coBook: string | null;
  vchNo: string | null;
  bookName: string | null;
  date: string | null;
  /** The desktop AC_NAME literal of the source ('RATE CUT', 'INT FINE'), else ''. */
  label: string | null;
  ldCode: string | null;
  itCode: string | null;
  itDesc: string | null;
  tagNo: string | null;
  pcs: number;
  grossWt: number;
  netWt: number;
  touch: number;
  west: number;
  fine: number;
  rate: number;
  amount: number;
  crAmt: number;
  drAmt: number;
  sign: string | null;
}

export interface FinePrintResult {
  report: string;
  question: string | null;
  title: string;
  parameters: string[];
  period: { fromDate: string; toDate: string };
  account: { acCode: string; acName: string | null };
  opening: { amount: number; fine: number };
  closing: { amount: number; fine: number };
  rows: FinePrintRow[];
  /** Fine received (sign '+', Jama) and issued (sign '-', Udhar) are totalled apart, as the layouts print them. */
  totals: { rows: number; fineIn: number; fineOut: number; crAmt: number; drAmt: number };
}

const ISO = /^\d{4}-\d{2}-\d{2}$/;

/** Parse a fine-print request into a typed query, failing closed. Business scope is never read here. */
export function parseFinePrintQuery(
  kind: FinePrintKind,
  q: Record<string, unknown>,
): FinePrintQuery {
  const str = (v: unknown): string | undefined => {
    if (v == null) return undefined;
    const s = String(v).trim();
    return s === '' ? undefined : s;
  };
  const acCode = str(q.acCode);
  if (!acCode) throw new AccountLedgerValidationError('acCode is required');
  if (acCode.length > 8)
    throw new AccountLedgerValidationError('acCode must be at most 8 characters');
  const date = (label: string, v: unknown): string => {
    const s = str(v);
    if (!s) throw new AccountLedgerValidationError(`${label} is required`);
    if (!ISO.test(s)) throw new AccountLedgerValidationError(`${label} must be YYYY-MM-DD`);
    try {
      return toIsoDate(s);
    } catch {
      throw new AccountLedgerValidationError(`${label} is not a calendar date`);
    }
  };
  const fromDate = date('fromDate', q.fromDate);
  const toDate = date('toDate', q.toDate);
  if (fromDate > toDate)
    throw new AccountLedgerValidationError('fromDate must not be after toDate');
  const dataType = str(q.dataType)?.toUpperCase();
  if (dataType && !['A', 'B', 'C'].includes(dataType))
    throw new AccountLedgerValidationError('dataType must be A, B or C');
  const location = q.location == null ? undefined : String(q.location).trim();
  // The Silver print stops on an empty location box. RP_LEDR.cs:8667 {{Please Select Lc Code and Try...}}
  if (kind === 'silver-fine' && location === '')
    throw new AccountLedgerValidationError(NO_LC_CODE_TEXT);
  const hz = ['Y', 'y', '1', 'true'].includes(String(q.hz ?? ''));
  return { acCode, fromDate, toDate, dataType, hz, location };
}

const sumOf = (rows: FinePrintRow[], f: (r: FinePrintRow) => number): number =>
  rows.reduce((sum, r) => sum + f(r), 0);
const fmt = (value: number, dp: number): string => round(value, dp).toFixed(dp);
// The Crystal date arguments are built as Date(year,month,dd). RP_LEDR.cs:8409 {{Cr[(short)1] = "FromDate = Date("}}
const dmy = (iso: string): string => `${iso.slice(8, 10)}/${iso.slice(5, 7)}/${iso.slice(0, 4)}`;
const crystalDate = (iso: string): string =>
  `Date(${Number(iso.slice(0, 4))},${Number(iso.slice(5, 7))},${iso.slice(8, 10)})`;

interface Balance {
  amount: number;
  gold: number;
  silver: number;
}

/**
 * Opening is before the from date, closing is up to the to date. RP_LEDR.cs:8327 {{SELECT Sum(CR_AMT - DR_AMT) as BalAmt}}
 * The Gold balance has no data-type condition; the Silver and Jama/Udhar balances drop it only for type C
 * (RP_LEDR.cs:8942 {{Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '"}}).
 */
async function balanceAt(
  tx: any,
  s: LedgerScope,
  q: FinePrintQuery,
  op: '<' | '<=',
  date: string,
  byDataType: boolean,
): Promise<Balance> {
  const params: unknown[] = [];
  const scope = acDataScope(
    s,
    { view: 'detail', dataType: byDataType ? q.dataType : undefined },
    params,
  );
  params.push(q.acCode, date);
  const raw: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT ${SIGNED_MONEY}::float8 AS amt, ${SIGNED_GOLD}::float8 AS gold, ${SIGNED_SILVER}::float8 AS silver
       FROM "AC_DATA" d
      WHERE ${scope} AND d."AC_CODE"=$${params.length - 1} AND d."VCH_DATE" ${op} $${params.length}::date`,
    ...params,
  );
  const r = raw[0] ?? {};
  return { amount: num(r.amt), gold: num(r.gold), silver: num(r.silver) };
}

const SOURCES: Record<FinePrintKind, readonly string[]> = {
  'jama-udhar': JAMA_UDHAR_SOURCES,
  'gold-fine': GOLD_SOURCES,
  'silver-fine': SILVER_SOURCES,
};

/**
 * The print rows: every desktop source, then the Crystal selection: account, dates, location, and the data type
 * only when it is A or B (RP_LEDR.cs:8348 {{if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)}}).
 */
async function printRows(
  tx: any,
  s: LedgerScope,
  q: FinePrintQuery,
  kind: FinePrintKind,
): Promise<FinePrintRow[]> {
  const params: unknown[] = [s.coCode, q.acCode, q.fromDate, q.toDate];
  let where = `f.vch_date >= $3::date AND f.vch_date <= $4::date`;
  if (s.lcCode) {
    params.push(s.lcCode);
    where += ` AND f.lc_code=$${params.length}`;
  }
  if (q.dataType === 'A' || q.dataType === 'B') {
    params.push(q.dataType);
    where += ` AND f.data_type=$${params.length}`;
  }
  const raw: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT f.* FROM (${SOURCES[kind].join('\n UNION ALL \n')}) f
      WHERE ${where}
      ORDER BY f.vch_date, f.sec, f.co_book, f.vch_no, f.isr`,
    ...params,
  );
  return raw.map((r) => ({
    section: num(r.sec),
    coBook: txt(r.co_book),
    vchNo: txt(r.vch_no),
    bookName: txt(r.book_name),
    date: toIsoDate(r.vch_date) || null,
    label: txt(r.ac_label),
    ldCode: txt(r.ld_code),
    itCode: txt(r.it_code),
    itDesc: txt(r.it_desc),
    tagNo: txt(r.tag_no),
    pcs: num(r.pcs),
    grossWt: round(num(r.gwt), 3),
    netWt: round(num(r.nwt), 3),
    touch: round(num(r.touch), 2),
    west: round(num(r.west), 3),
    fine: round(num(r.fine), 3),
    rate: round(num(r.rate), 2),
    amount: round(num(r.amt), 2),
    crAmt: round(num(r.cr), 2),
    drAmt: round(num(r.dr), 2),
    sign: txt(r.sign),
  }));
}

/** SILVER_THREE_DIGIT: the Silver print reads the balances at three decimals when 'Y', else two (RP_LEDR.cs:8947 {{if (Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0)}}). */
async function silverThreeDigit(tx: any, s: LedgerScope): Promise<boolean> {
  const raw: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "SILVER_THREE_DIGIT" AS v FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text LIMIT 1`,
    s.tenantId,
    String(s.coCode),
  );
  return (
    String(raw[0]?.v ?? '')
      .trim()
      .toUpperCase() === 'Y'
  );
}

async function loadAccountName(tx: any, s: LedgerScope, acCode: string): Promise<string | null> {
  const params: unknown[] = [s.coCode, acCode];
  let where = `m."CO_CODE"=$1 AND m."AC_CODE"=$2`;
  if (s.lcCode) {
    params.push(s.lcCode);
    where += ` AND (m."LC_CODE"=$${params.length} OR m."LC_CODE" IS NULL)`;
  }
  const raw: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT m."AC_NAME" FROM "AC_MAST" m WHERE ${where} ORDER BY m."LC_CODE" NULLS LAST LIMIT 1`,
    ...params,
  );
  if (!raw[0]) throw new AccountNotFoundError(acCode);
  return txt(raw[0].AC_NAME);
}

const TITLES: Record<FinePrintKind, string> = {
  // RP_LEDR.cs:4061 {{Cr[(short)0] = "RptTitel = 'Jama Udhar Report As On " + Strings.Format}}
  'jama-udhar': 'Jama Udhar Report As On ',
  // RP_LEDR.cs:8407 {{Cr[(short)0] = "RptTitel = 'Ledr With Gold Fine Report As On " + Strings.Format}}
  'gold-fine': 'Ledr With Gold Fine Report As On ',
  // RP_LEDR.cs:9038 {{Cr[(short)0] = "RptTitel = 'Ledr With Silver Fine Report As On " + Strings.Format}}
  'silver-fine': 'Ledr With Silver Fine Report As On ',
};

function templateFor(kind: FinePrintKind, hz: boolean): string {
  // RP_LEDR.cs:4050 {{DC_Main.RptName = "JmUdAmt";}}
  if (kind === 'jama-udhar') return 'JmUdAmt';
  // RP_LEDR.cs:8384 {{DC_Main.RptName = "JmUdFineHz";}}, RP_LEDR.cs:8388 {{DC_Main.RptName = "JmUdFine";}}
  if (kind === 'gold-fine') return hz ? 'JmUdFineHz' : 'JmUdFine';
  // RP_LEDR.cs:9015 {{DC_Main.RptName = "JmUdFineSlHz";}}, RP_LEDR.cs:9019 {{DC_Main.RptName = "JmUdFineSl";}}
  return hz ? 'JmUdFineSlHz' : 'JmUdFineSl';
}

/** The Yes/No layout question the desktop asks before the Gold and Silver prints. */
const QUESTIONS: Partial<Record<FinePrintKind, string>> = {
  // RP_LEDR.cs:8382 {{Hz Jama Udhar Gold Report}}
  'gold-fine': 'Hz Jama Udhar Gold Report',
  // RP_LEDR.cs:9013 {{Hz Jama Udhar Silver Report}}
  'silver-fine': 'Hz Jama Udhar Silver Report',
};

/**
 * Resolve one fine print into its rows and report parameters. The session owns company and location; a
 * location sent on the request only fills a session that has none.
 */
export async function ledgerFinePrint(
  prisma: any,
  s: LedgerScope,
  kind: FinePrintKind,
  q: FinePrintQuery,
): Promise<FinePrintResult> {
  const scope: LedgerScope = { ...s, lcCode: s.lcCode || q.location || undefined };
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const acName = await loadAccountName(tx, scope, q.acCode);
    // RP_LEDR.cs:8327 (Gold, no data type) against RP_LEDR.cs:4005 and :8942 (Jama/Udhar and Silver, by data type).
    const byDataType = kind !== 'gold-fine';
    const opening = await balanceAt(tx, scope, q, '<', q.fromDate, byDataType);
    const closing = await balanceAt(tx, scope, q, '<=', q.toDate, byDataType);
    const rows = await printRows(tx, scope, q, kind);

    // Gold balances round to three decimals; silver to two unless SILVER_THREE_DIGIT (D14).
    // RP_LEDR.cs:8333 {{num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));}}
    const fineDp = kind === 'silver-fine' && !(await silverThreeDigit(tx, scope)) ? 2 : 3;
    const pick = (b: Balance): number => round(kind === 'silver-fine' ? b.silver : b.gold, fineDp);
    const opAmt = round(opening.amount, 2);
    const clAmt = round(closing.amount, 2);
    const title = `${TITLES[kind]}${dmy(q.toDate)}`;
    const parameters = [
      `RptTitel = '${title}'`,
      `FromDate = ${crystalDate(q.fromDate)} `,
      `ToDate = ${crystalDate(q.toDate)} `,
    ];
    if (kind === 'jama-udhar') {
      // RP_LEDR.cs:4065 {{Cr[(short)3] = ("OpBal = " + Strings.Format((object)num, "0.00")) ?? "";}}
      parameters.push(`OpBal = ${fmt(opAmt, 2)}`, `ClBal = ${fmt(clAmt, 2)}`);
    } else {
      // RP_LEDR.cs:8411 {{Cr[(short)3] = ("OpBal = " + Strings.Format((object)num2, "0.000")) ?? "";}}
      parameters.push(
        `OpBal = ${fmt(pick(opening), 3)}`,
        `ClBal = ${fmt(pick(closing), 3)}`,
        `OpAmtBal = ${fmt(opAmt, 2)}`,
        `ClAmtBal = ${fmt(clAmt, 2)}`,
        `DataType = '${q.dataType ?? ''}'`,
      );
    }
    return {
      report: templateFor(kind, q.hz),
      question: QUESTIONS[kind] ?? null,
      title,
      parameters,
      period: { fromDate: q.fromDate, toDate: q.toDate },
      account: { acCode: q.acCode, acName },
      opening: { amount: opAmt, fine: pick(opening) },
      closing: { amount: clAmt, fine: pick(closing) },
      rows,
      totals: {
        rows: rows.length,
        fineIn: round(
          sumOf(rows, (r) => (r.sign === '+' ? r.fine : 0)),
          3,
        ),
        fineOut: round(
          sumOf(rows, (r) => (r.sign === '-' ? r.fine : 0)),
          3,
        ),
        crAmt: round(
          sumOf(rows, (r) => r.crAmt),
          2,
        ),
        drAmt: round(
          sumOf(rows, (r) => r.drAmt),
          2,
        ),
      },
    };
  });
}
