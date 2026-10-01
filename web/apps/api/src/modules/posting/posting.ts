import { withTenant } from '@datacare/db';
import { DESKTOP_COLUMN_DEFAULTS } from './desktopColumnDefaults.js';
import { tableColumnsTx, warmSchemaCatalog } from '../shared/schemaCatalog.js';

/** A double-entry ledger row (AC_DATA): one of CR_AMT/DR_AMT set per line. */
export interface LedgerLine {
  CR_AMT?: number;
  DR_AMT?: number;
  [col: string]: unknown;
}

/** A set of rows to write into one table within the voucher transaction. */
export interface VoucherWrite {
  table: string;
  rows: Record<string, unknown>[];
}

export interface PostInput {
  ledger: { table: string; lines: LedgerLine[] }; // AC_DATA
  writes?: VoucherWrite[]; // header, detail, tax, stock, ...
  bookName?: string; // BOOK_NAME stamped on each AC_DATA line (e.g. 'SALES','PURC') — desktop parity
  /**
   * The voucher's party account, used to decide which ledger leg carries `PARTY_AC_CODE`.
   *
   * Optional: without it the legacy behaviour (echo the row's own AC_CODE) is kept, so an un-audited caller does
   * not silently lose the value on its party leg.
   */
  partyAc?: string;
}

export class UnbalancedError extends Error {
  constructor(
    public cr: number,
    public dr: number,
  ) {
    super(`unbalanced ledger: CR=${cr} DR=${dr}`);
    this.name = 'UnbalancedError';
  }
}

const q = (id: string): string => '"' + id.replace(/[^A-Za-z0-9_]/g, '') + '"';
const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

/** Σ CR vs Σ DR across ledger lines (Req 13.1). */
export function ledgerBalance(lines: LedgerLine[]): { cr: number; dr: number; balanced: boolean } {
  const cr = round2(lines.reduce((s, l) => s + Number(l.CR_AMT ?? 0), 0));
  const dr = round2(lines.reduce((s, l) => s + Number(l.DR_AMT ?? 0), 0));
  return { cr, dr, balanced: cr === dr };
}

export function assertBalanced(lines: LedgerLine[]): void {
  const b = ledgerBalance(lines);
  if (!b.balanced) throw new UnbalancedError(b.cr, b.dr);
}

/**
 * Columns the desktop never leaves NULL, with the default it writes — derived from the real database by
 * `apps/api/integration/derive-column-defaults.mjs` and consumed here.
 *
 * WHY THE WEB MUST WRITE THESE RATHER THAN LEAVING THEM NULL
 * =========================================================
 * The desktop's data layer writes a COMPLETE row: every numeric column it does not use gets 0 and every
 * character column gets ''. The web built its INSERT from only the columns a caller supplied, so everything
 * else defaulted to NULL. Measured in the 66-voucher comparison, that one difference in convention accounted
 * for **5239 of 8080 field differences — 65% of everything** across 135 columns of 8 tables.
 *
 * It is not cosmetic: `SUM` ignores NULL but `COUNT(col)` and `AVG(col)` do not, so a report that averages a
 * weight or counts populated lines answers differently against NULL than against 0.
 *
 * WHY A MEASURED SPEC AND NOT A TYPE RULE
 * ======================================
 * Defaulting by type alone was tried and the comparison rejected it: filling every numeric with 0 and every
 * character with '' removed 3057 differences but INTRODUCED 828 new ones across 17 columns the desktop
 * genuinely leaves NULL (PR_DETL.CONSI_NO/CONSI_YRCD/CONSI_DBCD, PR_DETL.HM_ID2/3/4, ITM_COLOR,
 * PR_DATA.HM_TAX_CODE, RATE_CUT_DATA.VP_AMT_TYPE/AC_ANGDIYA/TDS_CODE, …). NULL is meaningful in those.
 *
 * A hand-maintained exclusion list would be incomplete by construction — it could only hold the columns some
 * comparison happened to surface — so the specification is measured per (table, column) instead:
 *
 *     never NULL in the real data, numeric or character  ->  default it (0 or '')
 *     ever NULL                                          ->  absent here, so left NULL
 *     no rows to judge from                              ->  absent here, so left NULL
 *
 * Current spec: 49 tables, 2231 columns defaulted, 256 left NULL, 1719 with no evidence. Dates are never
 * defaulted — the desktop leaves an unset date NULL, as documented for AC_DATA.BILL_DATE.
 *
 * The distinction is per TABLE, not per column name: PR_DETL.ITM_LOT is never NULL and is defaulted, while
 * MAIN_STOCK.ITM_LOT is sometimes NULL and is not.
 */
const desktopColumnDefaults = DESKTOP_COLUMN_DEFAULTS;

export function insertRowTx(
  tx: any,
  table: string,
  tenantId: string,
  data: Record<string, unknown>,
): Promise<unknown> {
  const defaults = desktopColumnDefaults[table];
  /**
   * A supplied value wins — EXCEPT an explicit `null` on a column the desktop never leaves NULL.
   *
   * `desktopColumnDefaults` is not a convenience table. It was derived by counting NULLs per column over every
   * row of the real database, and a column only appears in it when the desktop NEVER stores NULL there. So a
   * caller passing `null` for such a column is passing a value the desktop never writes, and letting that win
   * silently defeated the whole mechanism.
   *
   * Measured, not argued: the purchase builders use the idiom `text(x).slice(0, n) || null`, which yields `null`
   * for an absent field. Across the 70-case comparison that overrode the measured `''` on twenty columns —
   * `PR_DETL.IT_DESC`, `LOT_NO`, `DESIGN_NO`, `TBL_CODE`, `WITH_STOCK`, `PR_CODE`, `PR_DATA.ADD1..3`, `CITY`,
   * `MOBILE`, `BANK_NAME`, `CHQ_NO`, `CARD_AC`, `TCS_CODE`, `TDS_CODE` and more — for around 1,290 of its 3,199
   * field differences.
   *
   * A caller that genuinely means NULL on such a column is asking for something the desktop does not do; if that
   * is ever legitimately needed, the right fix is to correct the derived spec from data, not to slip a null past
   * it here.
   *
   * Columns ABSENT from the spec are untouched: the desktop does leave those NULL, and `null` remains meaningful.
   */
  const row: Record<string, unknown> = defaults ? { ...defaults, ...data } : data;
  if (defaults) {
    for (const [col, fallback] of Object.entries(defaults)) {
      if (row[col] === null) row[col] = fallback;
    }
  }
  const cols = Object.keys(row);
  const colSql = ['tenant_id', ...cols.map(q)].join(',');
  const ph = cols.map((_, i) => '$' + (i + 2)).join(',');
  return tx.$executeRawUnsafe(
    `INSERT INTO ${q(table)}(${colSql}) VALUES ($1${ph ? ',' + ph : ''})`,
    tenantId,
    ...cols.map((c) => row[c]),
  );
}

const pad = (v: unknown, n: number): string => String(v ?? '').padStart(n, '0');

/**
 * Books whose AC_DATA rows carry CLR_DATE, taken from the real data rather than from the column's name.
 *
 * `bookName` here is the desktop MAIN_BOOK (see the `bookName` field comment on LedgerLine). Bank receipts
 * and payments clear through an instrument, and the opening-stock voucher is dated into the year it opens;
 * nothing else sets a clearance date. Evidence and counts are recorded at the CLR_DATE assignment below.
 */
const CLEARANCE_DATE_BOOKS = new Set(['BANK PAY', 'BANK REC', 'OPSTK']);
const bookSetsClearanceDate = (bookName?: string): boolean =>
  CLEARANCE_DATE_BOOKS.has(
    String(bookName ?? '')
      .trim()
      .toUpperCase(),
  );

/** Stamp desktop ledger-line fields. LD_CODE is never synthesized: desktop uses the workflow's
 * contra-account code, not a line ordinal, so callers must provide it when the source rule is known. */
export function enrichLedgerLine(
  line: LedgerLine,
  srno: number,
  /** Right-aligned line number, or '' for the 23-character form. */
  lineSuffix: string,
  /**
   * When true, `lineSuffix` REPLACES the two-character leg type rather than following it.
   *
   * The cash books need this: their tail is `<line><leg>` as one field right-aligned in 12, so nothing sits at
   * positions 22-23 and appending a leg type there would produce a 35-character key.
   */
  suffixReplacesLegType: boolean,
  bookName?: string,
  voucherDate?: Date | null,
  /** The voucher's party account; see PARTY_AC_CODE below. */
  partyAc?: string,
  /** Desktop ENTRY_TIME copies the document's VCH_TIME, including its wall clock. */
  voucherTime?: Date | string | null,
): LedgerLine {
  // Desktop ledger rows carry the voucher's own date. Callers that build ledger legs from the
  // voucher key alone (purchase, karigar, …) omit VCH_DATE, so it is taken from the voucher's write
  // set rather than left NULL — which also gives ENTRY_TIME and CLR_DATE their value.
  const rowDate = (line.VCH_DATE as Date | undefined) ?? voucherDate ?? null;
  // Built as one literal (rather than by property assignment) so the desktop's full 29-column
  // AC_DATA ledger shape is visible to the write-set audit as well as to readers.
  // Defaults are the literals the desktop statement writes (Ac_Ledr.cs:13) and never override a
  // value the caller supplied:
  //   BILL_NO '' | BILL_DATE Null | CHQ_NO '' | LDR_NAME '' | DATA_TRFR 'N' | FINE_RATE 0
  //   HD_VCH_NO '00000' | PARTY_AC_CODE = the row's AC_CODE | ENTRY_TIME / CLR_DATE = the row date
  const e: LedgerLine = {
    ...line,
    LEDR_KEY:
      line.LEDR_KEY ??
      // VCH_NO is FIVE characters, not six. Measured on the real customer database: AC_DATA keys for a sale
      // are 23 characters and decompose as CO_CODE(2) LC_CODE(2) CO_YEAR(9) CO_BOOK(3) VCH_NO(5) TYPE(2) -
      // `01002024-20250270000101` - which is the same layout already verified byte-for-byte for
      // ROJ_MEL_DATA. Padding to six produced a 24-character key with an extra zero, so every web ledger
      // key differed from the desktop's in a column that is part of the primary key.
      `${line.CO_CODE ?? ''}${line.LC_CODE ?? ''}${line.CO_YEAR ?? ''}${line.CO_BOOK ?? ''}${pad(line.VCH_NO, 5)}${
        suffixReplacesLegType ? lineSuffix : `${pad(srno, 2)}${lineSuffix}`
      }`,
    VCH_DATE: line.VCH_DATE ?? rowDate,
    IT_TYPE: line.IT_TYPE ?? 'A',
    DATA_TYPE: line.DATA_TYPE ?? 'A',
    BILL_NO: line.BILL_NO ?? '',
    BILL_DATE: line.BILL_DATE ?? null,
    CHQ_NO: line.CHQ_NO ?? '',
    LDR_NAME: line.LDR_NAME ?? '',
    DATA_TRFR: line.DATA_TRFR ?? 'N',
    FINE_RATE: line.FINE_RATE ?? 0,
    HD_VCH_NO: line.HD_VCH_NO ?? '00000',
    /**
     * The VOUCHER'S party, and only on the party's own leg.
     *
     * This echoed the row's own `AC_CODE`, which is right on the party leg — the two coincide there — and wrong on
     * every contra leg, where it stamped the settlement or expense account as though it were a party. Measured
     * across the captured ledgers: the party leg carries the party on 120/120 rows, and a contra leg is blank on
     * 79 of 88.
     *
     * `partyAc` is optional so callers that have not been audited keep today's behaviour rather than silently
     * losing the value on their party legs; a caller that supplies it gets the desktop's rule.
     */
    PARTY_AC_CODE:
      line.PARTY_AC_CODE ??
      (partyAc == null
        ? (line.AC_CODE ?? null)
        : String(line.AC_CODE ?? '') === String(partyAc)
          ? line.AC_CODE
          : ''),
    ENTRY_TIME: line.ENTRY_TIME ?? voucherTime ?? rowDate,
    /**
     * CLR_DATE is a CLEARANCE date and belongs only to bank instruments and the opening-stock voucher.
     *
     * This used to be `line.CLR_DATE ?? rowDate` — stamped on every ledger leg of every family. Measured
     * over all 5150 real AC_DATA rows in Live24, the desktop populates it on exactly 345, and the partition
     * is perfectly clean:
     *
     *     BANK PAY   130 of 130   (100%)
     *     BANK REC    98 of  98   (100%)
     *     OPSTK      117 of 117   (100%)
     *     all 20 other families            0        (PURCHASE 0/143, SALES 0/1020, CASH PAY 0/360, …)
     *
     * 130 + 98 + 117 = 345, so no other family contributes a single row. Stamping it everywhere made the web
     * disagree with the desktop on 4805 of 5150 ledger rows — 93% — and it was the single largest source of
     * real value mismatches in the 66-voucher comparison (119 occurrences of AC_DATA.CLR_DATE).
     *
     * A caller that legitimately has a clearance date still wins, because the supplied value is preferred.
     */
    CLR_DATE: line.CLR_DATE ?? (bookSetsClearanceDate(bookName) ? rowDate : null),
    MAIN_USER: line.MAIN_USER ?? null,
    // SIGN IS A MOVEMENT DIRECTION, NOT A DEBIT/CREDIT MARKER.
    //
    // Measured across every table in the real customer database that has a `SIGN` column - 11,548 rows:
    //
    //     AC_DATA        blank 4975   + 105    - 70
    //     ROJ_MEL_DATA   blank 2711   + 160    - 308
    //     AD_OS                       + 8160   - 34
    //     AD_ADJ                               - 26
    //
    // 'C' and 'D' appear NOWHERE. The desktop leaves SIGN blank on a money leg and sets +/- only where metal
    // moves: 174 of the 175 signed AC_DATA rows carry a non-zero FINE_WT, the single exception being in book
    // 034 (wholesale sale, which is not built). '+' is metal in - purchase 035, karigar receipt 052 - and '-'
    // is metal out - karigar issue 050, labour work 088.
    //
    // The C/D alphabet IS correct for the differently-named columns OP_DATA.OP_SIGN (D 73 / C 35) and
    // OP_DATA.FINE_SIGN (D 97 / C 11), which are opening-balance debit/credit markers. Those are untouched;
    // conflating the two is exactly the mistake this normalisation exists to undo, so it matches only `SIGN`.
    SIGN: line.SIGN === 'C' || line.SIGN === 'D' ? '' : (line.SIGN ?? ''),
  };
  if (e.BOOK_NAME == null && bookName) e.BOOK_NAME = bookName;
  return e;
}

/** Raised when a voucher is dated on/before the company period-lock date (CO_SET.LOCK_DATE). */
export class PeriodLockValidationError extends Error {
  constructor(
    public vchDate: string,
    public lockDate: string,
  ) {
    super(`period is locked: voucher date ${vchDate} is on or before the lock date ${lockDate}`);
    this.name = 'PeriodLockValidationError';
  }
}

export class PeriodLockConfigurationValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'PeriodLockConfigurationValidationError';
  }
}

function businessDay(value: unknown, label: string): { day: number; iso: string } {
  if (value instanceof Date && !Number.isNaN(value.getTime())) {
    const iso = value.toISOString().slice(0, 10);
    const [year, month, day] = iso.split('-').map(Number);
    return { day: Date.UTC(year as number, (month as number) - 1, day), iso };
  }
  const raw = String(value ?? '').trim();
  let year: number;
  let month: number;
  let day: number;
  let match = /^(\d{4})-(\d{2})-(\d{2})(?:T.*)?$/.exec(raw);
  if (match) {
    year = Number(match[1]);
    month = Number(match[2]);
    day = Number(match[3]);
  } else {
    match = /^(\d{1,2})\/(\d{1,2})\/(\d{4})$/.exec(raw);
    if (!match) throw new PeriodLockConfigurationValidationError(`${label} is missing or invalid`);
    month = Number(match[1]);
    day = Number(match[2]);
    year = Number(match[3]);
  }
  const utc = Date.UTC(year, month - 1, day);
  const parsed = new Date(utc);
  if (
    parsed.getUTCFullYear() !== year ||
    parsed.getUTCMonth() !== month - 1 ||
    parsed.getUTCDate() !== day
  ) {
    throw new PeriodLockConfigurationValidationError(`${label} is invalid: ${raw}`);
  }
  return { day: utc, iso: parsed.toISOString().slice(0, 10) };
}

/**
 * Desktop applies LAST_DAY_LOCK by WRITING CO_SET.LOCK_DATE = system date - 1 when the company is
 * opened (MS_OPNCOMP.cs:1503-1507) or when the setting is saved (UT_SETTING_MAIN.cs:9159-9165).
 * It is never re-evaluated per voucher, so this gate reads the persisted LOCK_DATE only; the
 * last-day rule is applied at company-open time in modules/shared/lastDayLock.ts.
 */
async function lockDateFor(
  tx: any,
  tenantId: string,
  coCode: unknown,
): Promise<{ day: number; iso: string } | null> {
  let rows: Array<{ d: unknown }>;
  try {
    rows = await tx.$queryRawUnsafe(
      `SELECT btrim(coalesce("LOCK_DATE"::text,'')) AS d
         FROM "CO_SET"
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text
        ORDER BY row_id`,
      tenantId,
      String(coCode ?? ''),
    );
  } catch {
    throw new PeriodLockConfigurationValidationError(
      `unable to read period lock configuration for company ${String(coCode ?? '')}`,
    );
  }
  if (!rows.length) {
    throw new PeriodLockConfigurationValidationError(
      `period lock configuration is missing for company ${String(coCode ?? '')}`,
    );
  }
  if (rows.length > 1) {
    throw new PeriodLockConfigurationValidationError(
      `multiple lock dates are configured for company ${String(coCode ?? '')}`,
    );
  }
  const configuredDate = String(rows[0]!.d ?? '').trim();
  return configuredDate ? businessDay(configuredDate, 'CO_SET.LOCK_DATE') : null;
}

/** Find the voucher's CO_CODE + VCH_DATE from its ledger lines or any write row. */
function voucherCoAndDate(input: PostInput): { coCode: unknown; vchDate: unknown } {
  const rows: Record<string, unknown>[] = [
    ...input.ledger.lines,
    ...(input.writes ?? []).flatMap((w) => w.rows),
  ];
  let coCode: unknown = null;
  let vchDate: unknown = null;
  for (const r of rows) {
    if (coCode == null && r.CO_CODE != null) coCode = r.CO_CODE;
    if (vchDate == null && r.VCH_DATE != null && String(r.VCH_DATE).trim() !== '')
      vchDate = r.VCH_DATE;
    if (coCode != null && vchDate != null) break;
  }
  return { coCode, vchDate };
}

export async function assertPeriodOpen(tx: any, tenantId: string, input: PostInput): Promise<void> {
  const { coCode, vchDate } = voucherCoAndDate(input);
  if (coCode == null || String(coCode).trim() === '') {
    throw new PeriodLockConfigurationValidationError('voucher company is required for period lock');
  }
  if (vchDate == null || String(vchDate).trim() === '') {
    throw new PeriodLockConfigurationValidationError('voucher date is required for period lock');
  }
  const lock = await lockDateFor(tx, tenantId, coCode);
  if (!lock) return;
  const voucher = businessDay(vchDate, 'voucher date');
  if (voucher.day <= lock.day) {
    throw new PeriodLockValidationError(voucher.iso, lock.iso);
  }
}

/** Whether a table has a DATA_TYPE column (desktop stamps DATA_TYPE='A' on all data rows). */
async function tableHasDataType(tx: any, table: string): Promise<boolean> {
  return (await tableColumnsTx(tx, table)).has('DATA_TYPE');
}

/**
 * Provenance columns the desktop stamps uniformly across voucher tables.
 *
 * These five account for 59 of the previously-missing column instances, spread thinly over dozens of
 * tables — which is the signature of a cross-cutting concern rather than per-table work:
 *
 *   `MAIN_USER`  the acting user
 *   `ADD_USER`   the row's creator (equal to MAIN_USER on a fresh write; an edit preserves the original)
 *   `DATA_TRFR`  data-transfer flag, `'N'` until a transfer utility moves the row
 *   `OLD_VCH_NO` / `NEW_VCH_NO`  the renumbering trail, null until `voucherRenumber` rewrites a number
 *
 * Stamped here rather than in every module so a new write set cannot forget them, and only when the
 * target table actually HAS the column and the caller has not already supplied a value — an explicit
 * value from a module always wins.
 */
const PROVENANCE_COLUMNS = [
  'MAIN_USER',
  'ADD_USER',
  'DATA_TRFR',
  'OLD_VCH_NO',
  'NEW_VCH_NO',
] as const;

/**
 * Load the column metadata posting and numbering need, in one query, before any request is served (N53).
 * After this no posting or numbering transaction queries `information_schema`.
 */
export async function warmPostingMetadata(prisma: any): Promise<number> {
  return warmSchemaCatalog(prisma);
}

async function columnsOf(tx: any, table: string): Promise<ReadonlySet<string>> {
  return tableColumnsTx(tx, table);
}

/**
 * Tables where the desktop leaves `DATA_TRFR` EMPTY. Measured over all 37 tables carrying the column
 * (27214 rows): it is populated on 18691, and these five never populate it at all —
 * `AD_OS` 0/8194, `SL_DETL` 0/245, `SL_PR_DETL` 0/25, `RATE_CUT_ISU` 0/20, `SL_DETL_RTN` 0/1.
 * Defaulting them to `'N'` wrote a transfer flag onto rows the desktop leaves blank.
 */
const DATA_TRFR_NEVER_SET = new Set([
  'AD_OS',
  'SL_DETL',
  'SL_PR_DETL',
  'RATE_CUT_ISU',
  'SL_DETL_RTN',
]);

/** Tables where the desktop stores `'Y'`: `OP_DATA` 108/108 and `ITM_OPBL` 72/72, both opening-balance. */
const DATA_TRFR_YES = new Set(['OP_DATA', 'ITM_OPBL']);

/**
 * Tables where the desktop populates `ADD_USER`. Measured over all 19 tables that carry BOTH `ADD_USER` and
 * `MAIN_USER`: `MAIN_USER` is filled almost everywhere, but `ADD_USER` is populated on **only two** —
 * `BAR_DETL` 1169/1329 and `SL_ORD_DETL` 25/63 — and is EMPTY on the other seventeen, including
 * `PR_DETL` 0/103, `CASH_DATA` 0/335, `SL_DETL` 0/245, `CONTRA_DATA` 0/102 and `RATE_CUT_ISU` 0/20.
 *
 * So `ADD_USER` does not mirror `MAIN_USER` in general; the previous blanket rule stamped an audit value onto
 * seventeen tables that leave it blank. Where it IS populated it always equals `MAIN_USER` (1169/1169 and
 * 25/25), so mirroring is the right FORM — it just has to be restricted to these two tables. The partial
 * counts suggest it marks rows appended to an existing voucher, which this dataset cannot confirm, so the
 * within-table condition stays unmodelled.
 */
const ADD_USER_TABLES = new Set(['BAR_DETL', 'SL_ORD_DETL']);

/**
 * Fill the provenance columns a table has and the row has not set.
 *
 * `DATA_TRFR` and `ADD_USER` are decided PER TABLE from the measured sets above, not by a blanket rule: both
 * were previously applied to every table and both were wrong on a large minority of them. The renumbering
 * columns default to null, matching a freshly created voucher. Nothing is ever invented, because a wrong
 * value in an audit column is worse than an empty one.
 */
export function applyProvenance(
  row: Record<string, unknown>,
  tableColumns: ReadonlySet<string>,
  table?: string,
): Record<string, unknown> {
  const out = { ...row };
  const has = (c: string): boolean => tableColumns.has(c);
  const t = (table ?? '').trim();
  if (has('DATA_TRFR') && out.DATA_TRFR == null && !DATA_TRFR_NEVER_SET.has(t)) {
    out.DATA_TRFR = DATA_TRFR_YES.has(t) ? 'Y' : 'N';
  }
  if (has('OLD_VCH_NO') && !('OLD_VCH_NO' in out)) out.OLD_VCH_NO = null;
  if (has('NEW_VCH_NO') && !('NEW_VCH_NO' in out)) out.NEW_VCH_NO = null;
  if (has('ADD_USER') && out.ADD_USER == null && out.MAIN_USER != null && ADD_USER_TABLES.has(t)) {
    out.ADD_USER = out.MAIN_USER;
  }
  return out;
}

/** Exported for the acceptance tests that pin the measured per-table rules. */
export const PROVENANCE_TABLE_RULES = {
  DATA_TRFR_NEVER_SET,
  DATA_TRFR_YES,
  ADD_USER_TABLES,
};

/** The provenance column names, exported for tests and the depth audit. */
export const PROVENANCE_COLUMN_NAMES = PROVENANCE_COLUMNS;

/** Post a voucher's writes within an EXISTING transaction (used by sales/purchase composition). */
export async function postVoucherTx(tx: any, tenantId: string, input: PostInput): Promise<void> {
  assertBalanced(input.ledger.lines);
  await assertPeriodOpen(tx, tenantId, input);
  for (const w of input.writes ?? []) {
    const stampDt = await tableHasDataType(tx, w.table); // desktop parity: DATA_TYPE='A' on all data rows
    const tableColumns = await columnsOf(tx, w.table);
    for (const r of w.rows) {
      const withDataType = stampDt && r.DATA_TYPE == null ? { ...r, DATA_TYPE: 'A' } : r;
      await insertRowTx(
        tx,
        w.table,
        tenantId,
        applyProvenance(withDataType, tableColumns, w.table),
      );
    }
  }
  // The voucher's date, as written on its own rows: the ledger legs inherit it when they do not
  // carry one of their own.
  const voucherDate =
    (input.writes ?? [])
      .flatMap((w) => w.rows)
      .map((r) => (r as Record<string, unknown>).VCH_DATE)
      .find((d): d is Date => d instanceof Date) ?? null;
  const voucherTime =
    (input.writes ?? [])
      .flatMap((w) => w.rows)
      .map((r) => (r as Record<string, unknown>).VCH_TIME)
      .find((value): value is Date | string =>
        value instanceof Date
          ? !Number.isNaN(value.getTime())
          : typeof value === 'string' && value.trim().length > 10,
      ) ?? null;
  // The last two characters of LEDR_KEY are a SEMANTIC leg type, not a sequence.
  //
  // Measured across the sale books (026/027/029/032) they are consistent by ROLE, and settlement legs come in
  // pairs of party-credit plus receiving-account-debit:
  //
  //     01 party (the bill)      Dr     03 revenue account   Cr     04 tax             Cr
  //     09 party, bank settle    Cr     10 bank              Dr
  //     19 party, cash settle    Cr     20 cash              Dr
  //     25 party, kasar          Cr     26 kasar             Dr
  //
  // A bare 1..n sequence therefore gets the FIRST leg right by coincidence and every later one wrong - the web
  // wrote 01/02/03 where the desktop writes 01/03/04, and `02` does not appear on any sale book at all.
  //
  // `legType` lets a caller state the role. Where it is absent the sequence is kept, so families whose codes
  // have not been measured yet are unchanged rather than being given a guessed mapping.
  let srno = 0;
  for (const line of input.ledger.lines) {
    srno++;
    // An UNMAPPED leg goes into a reserved band (50+) rather than taking its positional index.
    //
    // Two reasons, both learned by breaking it. First, collision: once the measured codes are in use a
    // positionally-numbered fourth leg takes 04 and duplicates the tax leg, which the desktop's PK_AC_DATA
    // would reject and the web silently accepted until LEDR_KEY uniqueness was added. Second, disguise: a low
    // number is indistinguishable from a measured desktop code, so an unmapped leg numbered 05 would look like
    // evidence about the desktop that nobody had gathered.
    //
    // Measured sale codes occupy 01-26 (party 01, revenue 03, tax 04, and the settlement pairs 09/10, 19/20,
    // 21/22, 23/24, 25/26). The band 50-98 is unused by any of them, and 99 is the web-only round-off leg.
    const declared = (line as Record<string, unknown>).legType;
    const legNo = typeof declared === 'number' ? declared : 50 + srno;
    // `legLine` appends a LINE NUMBER, right-aligned in 10, giving a 33-character key.
    //
    // Measured on book 074 (member entry): all 2620 real AC_DATA legs are 33 characters and carry the MEMBER
    // LINE, because a scheme instalment posts a Dr/Cr pair per member - 570 vouchers have 2 legs, 172 have 4
    // and one has 22. The sale family's keys are 23 characters with no line, so this is per-family and cannot
    // be applied globally.
    //
    // Same layout ROJ_MEL_DATA already uses, verified byte-exact there against a real 33-character key.
    const declaredLine = (line as Record<string, unknown>).legLine;
    // `legKeySuffix` supplies the WHOLE tail after VCH_NO, for families whose layout neither `legType` nor
    // `legLine` can express.
    //
    // Three layouts are now confirmed and no two agree:
    //   sale   (026/027/...)  23 chars - leg type in the 2 characters at 22-23, no line
    //   scheme (074)          33 chars - leg type at 22-23, then a bare line right-aligned in 10
    //   cash   (001/002)      33 chars - <line><leg> as ONE field right-aligned in 12, so nothing sits at 22-23
    //
    // The cash form is why this exists: reading `SUBSTRING(LEDR_KEY,22,2)` there returns SPACES, which is how
    // the difference was noticed at all. A per-family suffix is honest about that; a fourth optional field
    // trying to cover it would not be.
    const declaredSuffix = (line as Record<string, unknown>).legKeySuffix;
    // legType is a directive to this function, not a column, so it never reaches the INSERT.
    const {
      legType: _legType,
      legLine: _legLine,
      legKeySuffix: _legKeySuffix,
      ...columns
    } = line as Record<string, unknown>;
    const row =
      input.ledger.table === 'AC_DATA'
        ? enrichLedgerLine(
            columns as typeof line,
            legNo,
            typeof declaredSuffix === 'string'
              ? declaredSuffix
              : typeof declaredLine === 'number'
                ? String(declaredLine).padStart(10, ' ')
                : '',
            typeof declaredSuffix === 'string',
            input.bookName,
            voucherDate,
            input.partyAc,
            voucherTime,
          )
        : (columns as typeof line);
    await insertRowTx(tx, input.ledger.table, tenantId, row);
  }
}

/**
 * Post a voucher: validate the double-entry balance, then write all detail/tax/stock rows and the
 * balanced AC_DATA ledger lines inside ONE tenant transaction (Req 5.4, 10.8, 11.2, 13.1). Any
 * failure rolls back the whole voucher.
 */
export async function postVoucher(
  prisma: any,
  tenantId: string,
  input: PostInput,
): Promise<{ posted: true }> {
  return withTenant(prisma, tenantId, async (tx: any) => {
    await postVoucherTx(tx, tenantId, input);
    return { posted: true };
  });
}

export interface ReverseInput {
  tables: string[];
  key: Record<string, unknown>;
  deleteLog?: { table: string; row: Record<string, unknown> };
}

export class VoucherNotFoundValidationError extends Error {
  constructor() {
    super('voucher not found for reversal');
    this.name = 'VoucherNotFoundValidationError';
  }
}

function canonicalReverseKey(key: Record<string, unknown>): Record<string, unknown> {
  const normalized = { ...key };
  const raw = String(normalized.VCH_NO ?? '').trim();
  if (/^\d+$/.test(raw) && Number(raw) > 0) normalized.VCH_NO = raw.padStart(5, '0');
  return normalized;
}

async function persistedVoucherForReversal(
  tx: any,
  tenantId: string,
  tables: string[],
  key: Record<string, unknown>,
): Promise<{ coCode: unknown; vchDate: unknown }> {
  const keys = Object.keys(key);
  const where = keys.map((k, i) => `${q(k)}::text=$${i + 2}::text`).join(' AND ');
  const params = keys.map((k) => key[k]);
  for (const table of tables) {
    const available = await tableColumnsTx(tx, table);
    if (
      !available.has('tenant_id') ||
      !available.has('CO_CODE') ||
      !available.has('VCH_DATE') ||
      keys.some((keyColumn) => !available.has(keyColumn))
    ) {
      continue;
    }
    const rows: Array<{ CO_CODE: unknown; VCH_DATE: unknown }> = await tx.$queryRawUnsafe(
      `SELECT "CO_CODE", "VCH_DATE" FROM ${q(table)}
        WHERE tenant_id=$1 AND ${where} LIMIT 1`,
      tenantId,
      ...params,
    );
    if (rows.length && rows[0]?.VCH_DATE != null) {
      return { coCode: rows[0].CO_CODE, vchDate: rows[0].VCH_DATE };
    }
  }
  throw new VoucherNotFoundValidationError();
}

/** Reverse within the caller's transaction. Lock validation is derived from persisted state before
 * any delete, so callers cannot omit or forge VCH_DATE to bypass a closed period. */
export async function reverseVoucherTx(
  tx: any,
  tenantId: string,
  input: ReverseInput,
): Promise<void> {
  const key = canonicalReverseKey(input.key);
  const persisted = await persistedVoucherForReversal(tx, tenantId, input.tables, key);
  await assertPeriodOpen(tx, tenantId, {
    ledger: {
      table: 'AC_DATA',
      lines: [{ CO_CODE: persisted.coCode, VCH_DATE: persisted.vchDate }],
    },
  });

  const keys = Object.keys(key);
  const where = keys.map((k, i) => `${q(k)}::text=$${i + 2}::text`).join(' AND ');
  const params = keys.map((k) => key[k]);
  for (const table of input.tables) {
    await tx.$executeRawUnsafe(
      `DELETE FROM ${q(table)} WHERE tenant_id=$1 AND ${where}`,
      tenantId,
      ...params,
    );
  }
  if (input.deleteLog) await insertRowTx(tx, input.deleteLog.table, tenantId, input.deleteLog.row);
}

/**
 * Reverse (delete) a voucher: delete its rows from every table by voucher key and write a
 * DELETE_DATA log row — all in one transaction (Req 10.10, 11.5, 13.4).
 */
export async function reverseVoucher(
  prisma: any,
  tenantId: string,
  input: ReverseInput,
): Promise<{ reversed: true }> {
  return withTenant(prisma, tenantId, async (tx: any) => {
    await reverseVoucherTx(tx, tenantId, input);
    return { reversed: true };
  });
}
