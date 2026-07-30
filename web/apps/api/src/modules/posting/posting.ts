import { withTenant } from '@datacare/db';

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

export function insertRowTx(
  tx: any,
  table: string,
  tenantId: string,
  data: Record<string, unknown>,
): Promise<unknown> {
  const cols = Object.keys(data);
  const colSql = ['tenant_id', ...cols.map(q)].join(',');
  const ph = cols.map((_, i) => '$' + (i + 2)).join(',');
  return tx.$executeRawUnsafe(
    `INSERT INTO ${q(table)}(${colSql}) VALUES ($1${ph ? ',' + ph : ''})`,
    tenantId,
    ...cols.map((c) => data[c]),
  );
}

const pad = (v: unknown, n: number): string => String(v ?? '').padStart(n, '0');
/** Stamp desktop ledger-line fields. LD_CODE is never synthesized: desktop uses the workflow's
 * contra-account code, not a line ordinal, so callers must provide it when the source rule is known. */
function enrichLedgerLine(
  line: LedgerLine,
  srno: number,
  bookName?: string,
  voucherDate?: Date | null,
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
      `${line.CO_CODE ?? ''}${line.LC_CODE ?? ''}${line.CO_YEAR ?? ''}${line.CO_BOOK ?? ''}${pad(line.VCH_NO, 6)}${pad(srno, 2)}`,
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
    PARTY_AC_CODE: line.PARTY_AC_CODE ?? line.AC_CODE ?? null,
    ENTRY_TIME: line.ENTRY_TIME ?? rowDate,
    CLR_DATE: line.CLR_DATE ?? rowDate,
    MAIN_USER: line.MAIN_USER ?? null,
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

/** Cache of which tables have a DATA_TYPE column (desktop stamps DATA_TYPE='A' on all data rows). */
const _hasDataType = new Map<string, boolean>();
async function tableHasDataType(tx: any, table: string): Promise<boolean> {
  if (_hasDataType.has(table)) return _hasDataType.get(table)!;
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM information_schema.columns WHERE table_name=$1 AND column_name='DATA_TYPE' LIMIT 1`,
    table,
  );
  const has = (rows as unknown[]).length > 0;
  _hasDataType.set(table, has);
  return has;
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

const _tableColumns = new Map<string, Set<string>>();

async function columnsOf(tx: any, table: string): Promise<Set<string>> {
  const cached = _tableColumns.get(table);
  if (cached) return cached;
  const rows: Array<{ column_name: string }> = await tx.$queryRawUnsafe(
    `SELECT column_name FROM information_schema.columns WHERE table_name=$1`,
    table,
  );
  const set = new Set(rows.map((r) => r.column_name));
  _tableColumns.set(table, set);
  return set;
}

/**
 * Fill the provenance columns a table has and the row has not set.
 *
 * `DATA_TRFR` defaults to `'N'` (not transferred) and the renumbering columns to null, matching a freshly
 * created voucher. `ADD_USER` mirrors `MAIN_USER` only when the row itself supplies one — it is never
 * invented, because a wrong name in an audit column is worse than an empty one.
 */
export function applyProvenance(
  row: Record<string, unknown>,
  tableColumns: Set<string>,
): Record<string, unknown> {
  const out = { ...row };
  const has = (c: string): boolean => tableColumns.has(c);
  if (has('DATA_TRFR') && out.DATA_TRFR == null) out.DATA_TRFR = 'N';
  if (has('OLD_VCH_NO') && !('OLD_VCH_NO' in out)) out.OLD_VCH_NO = null;
  if (has('NEW_VCH_NO') && !('NEW_VCH_NO' in out)) out.NEW_VCH_NO = null;
  if (has('ADD_USER') && out.ADD_USER == null && out.MAIN_USER != null) {
    out.ADD_USER = out.MAIN_USER;
  }
  return out;
}

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
      await insertRowTx(tx, w.table, tenantId, applyProvenance(withDataType, tableColumns));
    }
  }
  // The voucher's date, as written on its own rows: the ledger legs inherit it when they do not
  // carry one of their own.
  const voucherDate =
    (input.writes ?? [])
      .flatMap((w) => w.rows)
      .map((r) => (r as Record<string, unknown>).VCH_DATE)
      .find((d): d is Date => d instanceof Date) ?? null;
  let srno = 0;
  for (const line of input.ledger.lines) {
    srno++;
    const row =
      input.ledger.table === 'AC_DATA'
        ? enrichLedgerLine(line, srno, input.bookName, voucherDate)
        : line;
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
    const columns: Array<{ column_name: string }> = await tx.$queryRawUnsafe(
      `SELECT column_name FROM information_schema.columns
        WHERE table_schema=current_schema() AND table_name=$1
          AND column_name = ANY($2::text[])`,
      table,
      [...keys, 'tenant_id', 'CO_CODE', 'VCH_DATE'],
    );
    const available = new Set(columns.map((c) => c.column_name));
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
