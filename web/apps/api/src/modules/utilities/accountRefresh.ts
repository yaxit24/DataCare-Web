import { createHash } from 'node:crypto';
import {
  assertPeriodOpen,
  insertMaterializedRowTx,
  materializeVoucherRowsTx,
  PeriodLockValidationError,
  type PostInput,
} from '../posting/posting.js';
import { voucherVersionTx, versionKeyOf } from '../vouchers/version.js';
import {
  AccountRefreshDeriveError,
  type RefreshCandidate,
  deriveContraPostingsTx,
  deriveFineJvPostingsTx,
  type RefreshVoucherScope,
} from '../finance/contraRefresh.js';
import { CONTRA_WRITE_TABLES, lockContraVoucherTx } from '../finance/contra.js';
import {
  CASH_BANK_MAIN_BOOKS,
  CASH_WRITE_TABLES,
  LEGACY_PAYMENT_TABLES,
} from '../finance/cashBank.js';
import { deriveCashBankPostingsTx } from '../finance/cashBankRefresh.js';
import { withTxBudget } from '../shared/txBudget.js';
import {
  diff,
  registerRepair,
  RepairError,
  type RepairScope,
  type RepairTableDiff,
} from './dataRepair.js';

/**
 * Data Refresh > Account as CHECK AND REPAIR (owner decision 2026-11-27, docs/handbook/web/data-refresh.md).
 *
 * The desktop's btnAc_Click (MS_UPDATE.cs:2334-2398) deletes the year's AC_DATA, ROJ_MEL_DATA and derived tables and
 * AcRefresh (:2401-2669) rebuilds them from every voucher. The web does not copy the wipe. Per voucher family it
 * re-derives what each voucher's AC_DATA, ROJ_MEL_DATA and TAX_DATA rows SHOULD be from the voucher's own stored rows
 * with the writer's own builders (writing nothing), compares them with what is stored, and repairs only the vouchers
 * that differ, in the framework's one audited transaction. The replaced rows are kept on the run record.
 *
 * Defaults (owner-approved, recorded in data-refresh.md): the session's company, location and year only; a voucher in
 * a locked period is listed as `locked` and never changed; postings without a voucher are listed as `orphan` and
 * never deleted; books 888 and 000 are never touched; AC_DATA.CLR_DATE is carried over by LEDR_KEY on replace, as the
 * desktop's refresh does (MS_UPDATE.cs:2379-2396).
 */

/** The posting tables Account check-and-repair compares and replaces, each with its row key. */
export const ACCOUNT_REFRESH_TABLES = [
  { table: 'AC_DATA', key: 'LEDR_KEY' },
  { table: 'ROJ_MEL_DATA', key: 'LEDR_KEY' },
  { table: 'TAX_DATA', key: 'SR_NO' },
] as const;

/**
 * Columns never compared. Row identity and timestamps cannot agree by construction; CLR_DATE is the bank clearing
 * mark the refresh carries over (MS_UPDATE.cs:2379-2396); the rest are audit columns a later utility owns. On replace
 * every one of them that a replaced row carried is copied onto the new row with the same key.
 */
const IGNORED = new Set([
  'row_id',
  'tenant_id',
  'created_at',
  'updated_at',
  'CLR_DATE',
  'ADD_USER',
  'USER_UPDATE',
  'USER_DELETE',
  'OLD_VCH_NO',
  'NEW_VCH_NO',
]);

/** Books the refresh never touches (opening and system books). */
const UNTOUCHED_BOOKS = ['888', '000'];

export interface AccountRefreshFamily {
  /** Short id, e.g. `contra`; the operation is `data-refresh-account-<id>`. */
  id: string;
  title: string;
  /** BOOK_DATA.MAIN_BOOK of the family's books (one value or several). */
  mainBook: string | readonly string[];
  /** Extra BOOK_DATA condition on alias `b`, e.g. the inward FINE JV book (Ac_Ledr.cs:846). */
  bookFilter?: string;
  /** The family's voucher (header) table. */
  headerTable: string;
  /**
   * Other tables that hold vouchers of the family's books which the family does not re-derive (e.g. payments saved in
   * PAY_DATA before they moved to CASH_DATA): their postings are listed as `unverified`, not as orphans.
   */
  legacyHeaderTables?: readonly string[];
  /** The tables the voucher's version token covers. */
  versionTables: readonly string[];
  /** The desktop builders of the family, shown in the operation's description. */
  desktopSource: string;
  /**
   * The voucher's expected posting. Several candidates, in preference order, when the voucher's own rows leave a
   * choice open: the check then accepts the voucher only if its postings equal one of them, and never repairs it.
   */
  derive: (
    tx: any,
    scope: RefreshVoucherScope,
    voucherNo: string,
  ) => Promise<RefreshCandidate | RefreshCandidate[]>;
  /** Serialise with the family's writer before the voucher is replaced. */
  lock: (tx: any, scope: RefreshVoucherScope, voucherNo: string) => Promise<void>;
}

/**
 * Families whose apply is enabled. A family is listed only after every write-set fixture of it, saved through the
 * normal writer, previews clean (accountRefresh.db.test.ts) and a replay of real desktop vouchers checks with no
 * `differs`; every other family is preview-only. Cash/Bank passed both on 28 Nov 2026 (289 real desktop vouchers,
 * loaded as stored, all match; docs/handbook/web/data-refresh.md). The set is read on every preview and apply.
 */
export const ACCOUNT_REFRESH_VERIFIED: ReadonlySet<string> = new Set([
  'contra',
  'fine-jv',
  'cash-bank',
]);

export type VoucherStatus = 'match' | 'differs' | 'missing' | 'orphan' | 'locked' | 'unverified';

export interface TableCheck {
  table: string;
  onlyStored: string[];
  onlyExpected: string[];
  changed: Array<{ key: string; col: string; stored: unknown; expected: unknown }>;
}

export interface VoucherCheck {
  coBook: string;
  vchNo: string;
  vchDate: string | null;
  status: VoucherStatus;
  reason?: string;
  tables: TableCheck[];
  /** Orphan postings: rows per table. */
  orphanRows?: Record<string, number>;
  /** What a repair would lose, e.g. a bank clearing mark on a leg the voucher no longer posts. */
  warnings?: string[];
  storedHash: string;
  expectedHash: string;
  version: string;
}

export interface AccountCheck {
  family: string;
  summary: Record<VoucherStatus, number> & { total: number };
  vouchers: VoucherCheck[];
  diffs: RepairTableDiff[];
  fingerprint: string;
}

const sha = (value: unknown): string =>
  createHash('sha256').update(JSON.stringify(value)).digest('hex');
const q = (id: string): string => '"' + id.replace(/[^A-Za-z0-9_]/g, '') + '"';

function completeScope(scope: RepairScope): Omit<RefreshVoucherScope, 'coBook'> {
  if (!scope.coCode || !scope.lcCode || !scope.coYear)
    throw new RepairError(
      'scope-incomplete',
      'Account check needs the session company, location and year',
    );
  return {
    tenantId: scope.tenantId,
    coCode: scope.coCode,
    lcCode: scope.lcCode,
    coYear: scope.coYear,
  };
}

/** `format_type` per column, so expected values are cast exactly as an INSERT would store them. */
const columnTypes = new Map<string, Map<string, string>>();
async function columnTypesTx(tx: any, table: string): Promise<Map<string, string>> {
  const cached = columnTypes.get(table);
  if (cached) return cached;
  const rows: Array<{ name: string; type: string }> = await tx.$queryRawUnsafe(
    `SELECT a.attname AS name, format_type(a.atttypid, a.atttypmod) AS type
       FROM pg_attribute a WHERE a.attrelid=$1::regclass AND a.attnum>0 AND NOT a.attisdropped`,
    q(table),
  );
  const types = new Map(rows.map((row) => [row.name, row.type]));
  columnTypes.set(table, types);
  return types;
}

/**
 * Expected rows in the form the database would store them: every value goes through the same parameter path as the
 * writer's INSERT and is cast to its column type, then read back as jsonb. Writes nothing.
 */
async function normalisedTx(
  tx: any,
  table: string,
  rows: Record<string, unknown>[],
): Promise<Record<string, unknown>[]> {
  if (!rows.length) return [];
  const types = await columnTypesTx(tx, table);
  const params: unknown[] = [];
  const selects = rows.map((row) => {
    const cols = Object.keys(row).filter((col) => types.has(col));
    // jsonb_build_object takes at most 100 arguments, so a wide row is built in chunks.
    const chunks: string[] = [];
    for (let i = 0; i < cols.length; i += 40) {
      const parts = cols.slice(i, i + 40).map((col) => {
        params.push(row[col] ?? null);
        return `'${col}', $${params.length}::${types.get(col)}`;
      });
      chunks.push(`jsonb_build_object(${parts.join(',')})`);
    }
    return `SELECT ${chunks.length ? chunks.join(' || ') : `'{}'::jsonb`} AS r`;
  });
  const out: Array<{ r: Record<string, unknown> }> = await tx.$queryRawUnsafe(
    selects.join(' UNION ALL '),
    ...params,
  );
  return out.map((row) => row.r);
}

const where = `tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`;
const keyParams = (scope: RefreshVoucherScope, vchNo: string) => [
  scope.tenantId,
  scope.coCode,
  scope.lcCode,
  scope.coYear,
  scope.coBook,
  vchNo,
];

async function storedRowsTx(
  tx: any,
  table: string,
  scope: RefreshVoucherScope,
  vchNo: string,
): Promise<Record<string, unknown>[]> {
  const rows: Array<{ r: Record<string, unknown> }> = await tx.$queryRawUnsafe(
    `SELECT to_jsonb(t) AS r FROM ${q(table)} t WHERE ${where} ORDER BY to_jsonb(t)::text`,
    ...keyParams(scope, vchNo),
  );
  return rows.map((row) => row.r);
}

/** Rows keyed by their table key; a repeated key gets `#2`, `#3`, ... so no row hides behind another. */
function keyed(
  rows: Record<string, unknown>[],
  keyCol: string,
): Map<string, Record<string, unknown>> {
  const out = new Map<string, Record<string, unknown>>();
  for (const row of rows) {
    const base = String(row[keyCol] ?? '');
    let key = base;
    for (let n = 2; out.has(key); n++) key = `${base}#${n}`;
    out.set(key, row);
  }
  return out;
}

/**
 * Desktop text keeps the spaces typed around it (a narration or party name padded by the old CHAR columns) while the
 * web trims what it writes; a value that differs only in leading or trailing spaces is not a posting fault, so it is
 * no reason to rewrite the voucher (real desktop Cash/Bank replay, 28 Nov 2026).
 */
function sameValue(have: unknown, want: unknown): boolean {
  if (typeof have === 'string' && typeof want === 'string') return have.trim() === want.trim();
  return JSON.stringify(have) === JSON.stringify(want);
}

function compareTable(
  table: string,
  keyCol: string,
  stored: Record<string, unknown>[],
  expected: Record<string, unknown>[],
): TableCheck {
  const s = keyed(stored, keyCol);
  const e = keyed(expected, keyCol);
  const check: TableCheck = { table, onlyStored: [], onlyExpected: [], changed: [] };
  for (const key of s.keys()) if (!e.has(key)) check.onlyStored.push(key);
  for (const [key, want] of e) {
    const have = s.get(key);
    if (!have) {
      check.onlyExpected.push(key);
      continue;
    }
    // Only the columns the writer sets are compared; the rest are the database's own defaults.
    for (const col of Object.keys(want)) {
      if (IGNORED.has(col)) continue;
      if (!sameValue(have[col] ?? null, want[col] ?? null))
        check.changed.push({ key, col, stored: have[col] ?? null, expected: want[col] ?? null });
    }
  }
  return check;
}

const differs = (t: TableCheck) =>
  t.onlyStored.length + t.onlyExpected.length + t.changed.length > 0;

async function lockedTx(tx: any, scope: RefreshVoucherScope, vchDate: string): Promise<boolean> {
  try {
    await assertPeriodOpen(tx, scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: vchDate }] },
    });
    return false;
  } catch (error) {
    if (error instanceof PeriodLockValidationError) return true;
    throw error;
  }
}

/** Check one voucher: derive, materialize, normalise and compare. */
async function checkVoucherTx(
  tx: any,
  family: AccountRefreshFamily,
  scope: RefreshVoucherScope,
  vchNo: string,
  vchDate: string | null,
): Promise<{ check: VoucherCheck; expected: Map<string, Record<string, unknown>[]> | null }> {
  const version = await voucherVersionTx(tx, family.versionTables, versionKeyOf(scope, vchNo));
  const stored = new Map<string, Record<string, unknown>[]>();
  for (const { table } of ACCOUNT_REFRESH_TABLES)
    stored.set(table, await storedRowsTx(tx, table, scope, vchNo));
  const storedHash = sha([...stored.entries()]);
  const base = { coBook: scope.coBook, vchNo, vchDate, storedHash, version };
  const unverified = (reason: string) => ({
    check: {
      ...base,
      status: 'unverified' as const,
      reason,
      tables: [],
      expectedHash: sha(reason),
    },
    expected: null,
  });
  let candidates: RefreshCandidate[];
  try {
    const derived = await family.derive(tx, scope, vchNo);
    candidates = Array.isArray(derived) ? derived : [derived];
  } catch (error) {
    // A voucher the builders cannot re-derive is reported, never repaired.
    return unverified(error instanceof Error ? error.message : String(error));
  }
  // Candidates the voucher may be repaired to come first; `unverifiedReason` candidates only explain the stored
  // postings (e.g. the book's settings at save time) and are never written.
  const drift = candidates.filter((c) => c.unverifiedReason);
  candidates = candidates.filter((c) => !c.unverifiedReason);
  let expected = new Map<string, Record<string, unknown>[]>();
  let tables: TableCheck[] = [];
  const compareTx = async (candidate: PostInput) => {
    const materialized = await materializeVoucherRowsTx(tx, scope.tenantId, candidate);
    const tried = new Map<string, Record<string, unknown>[]>();
    const found: TableCheck[] = [];
    for (const { table, key } of ACCOUNT_REFRESH_TABLES) {
      const rows = materialized.get(table) ?? [];
      tried.set(table, rows);
      const check = compareTable(
        table,
        key,
        stored.get(table)!,
        await normalisedTx(tx, table, rows),
      );
      if (differs(check)) found.push(check);
    }
    return { tried, found };
  };
  for (const [index, candidate] of candidates.entries()) {
    const { tried, found } = await compareTx(candidate);
    if (index === 0 || !found.length) [expected, tables] = [tried, found];
    if (!found.length) break;
  }
  // The stored postings follow settings the voucher no longer has: reported, never re-posted into today's settings.
  if (tables.length && drift.length) {
    const explained = !(await compareTx(drift[0]!)).found.length;
    return unverified(
      `voucher ${vchNo}: ${drift[0]!.unverifiedReason}${explained ? '' : '; its postings also differ from what they were then'}`,
    );
  }
  // Rows that allow more than one posting, none of which is stored, cannot say which one to restore.
  if (tables.length && candidates.length > 1)
    return unverified(
      `voucher ${vchNo}: its rows allow ${candidates.length} postings (what it does not record: layout or account) and the stored postings match none of them`,
    );
  const expectedHash = sha([...expected.entries()].map(([t, rows]) => [t, rows]));
  // CLR_DATE is carried over by LEDR_KEY only (MS_UPDATE.cs:2379-2396); a cleared leg with no same-key successor
  // loses its mark, so the preview and the run record say so.
  const expectedKeys = new Set(
    (expected.get('AC_DATA') ?? []).map((row) => String(row.LEDR_KEY ?? '')),
  );
  const warnings = stored
    .get('AC_DATA')!
    .filter((row) => row.CLR_DATE != null && !expectedKeys.has(String(row.LEDR_KEY ?? '')))
    .map(
      (row) =>
        `bank clearing mark ${String(row.CLR_DATE)} on ${String(row.LEDR_KEY)} will be dropped`,
    );
  let status: VoucherStatus = 'match';
  if (tables.length) {
    const storedCount = [...stored.values()].reduce((n, rows) => n + rows.length, 0);
    if (vchDate && (await lockedTx(tx, scope, vchDate))) status = 'locked';
    else status = storedCount === 0 ? 'missing' : 'differs';
  }
  return {
    check: { ...base, status, tables, expectedHash, ...(warnings.length ? { warnings } : {}) },
    expected,
  };
}

const mainBooks = (family: AccountRefreshFamily): string[] => [family.mainBook].flat();

/** The family's books ($1 tenant, $2 company, $3 location, $4 untouched books, $6 MAIN_BOOK values). */
const familyBooks = (family: AccountRefreshFamily) =>
  `SELECT b."CO_BOOK" FROM "BOOK_DATA" b
    WHERE b.tenant_id=$1 AND b."CO_CODE"=$2 AND b."LC_CODE"=$3
      AND upper(btrim(coalesce(b."MAIN_BOOK",''))) = ANY($6::text[])
      ${family.bookFilter ? `AND ${family.bookFilter}` : ''}
      AND btrim(coalesce(b."CO_BOOK",'')) <> ALL($4::text[])`;

/** Every voucher of the family in scope and the posting rows that have no voucher. */
async function checkFamilyTx(
  tx: any,
  family: AccountRefreshFamily,
  repairScope: RepairScope,
): Promise<{ check: AccountCheck; expected: Map<string, Map<string, Record<string, unknown>[]>> }> {
  const scope = completeScope(repairScope);
  const books = familyBooks(family);
  const vouchers: Array<{ coBook: string; vchNo: string; vchDate: string | null }> =
    await tx.$queryRawUnsafe(
      `SELECT h."CO_BOOK" AS "coBook", h."VCH_NO" AS "vchNo", min(h."VCH_DATE")::text AS "vchDate"
         FROM ${q(family.headerTable)} h
        WHERE h.tenant_id=$1 AND h."CO_CODE"=$2 AND h."LC_CODE"=$3 AND h."CO_YEAR"=$5
          AND h."CO_BOOK" IN (${books})
        GROUP BY h."CO_BOOK", h."VCH_NO" ORDER BY h."CO_BOOK", h."VCH_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      UNTOUCHED_BOOKS,
      scope.coYear,
      mainBooks(family),
    );
  const checks: VoucherCheck[] = [];
  const expected = new Map<string, Map<string, Record<string, unknown>[]>>();
  for (const v of vouchers) {
    const result = await checkVoucherTx(
      tx,
      family,
      { ...scope, coBook: v.coBook },
      v.vchNo,
      v.vchDate,
    );
    checks.push(result.check);
    if (result.expected) expected.set(`${v.coBook}/${v.vchNo}`, result.expected);
  }
  // Postings of a family book with no voucher: reported, never deleted.
  const legacyExists = (family.legacyHeaderTables ?? []).length
    ? `bool_or(${(family.legacyHeaderTables ?? [])
        .map(
          (t) => `EXISTS (SELECT 1 FROM ${q(t)} l
                  WHERE l.tenant_id=p.tenant_id AND l."CO_CODE"=p."CO_CODE" AND l."LC_CODE"=p."LC_CODE"
                    AND l."CO_YEAR"=p."CO_YEAR" AND l."CO_BOOK"=p."CO_BOOK" AND l."VCH_NO"=p."VCH_NO")`,
        )
        .join(' OR ')})`
    : 'false';
  const orphans = new Map<string, VoucherCheck>();
  for (const { table } of ACCOUNT_REFRESH_TABLES) {
    const rows: Array<{ coBook: string; vchNo: string; n: number; h: string; legacy: boolean }> =
      await tx.$queryRawUnsafe(
        `SELECT p."CO_BOOK" AS "coBook", p."VCH_NO" AS "vchNo", count(*)::int AS n,
                md5(string_agg(to_jsonb(p)::text, '|' ORDER BY to_jsonb(p)::text)) AS h,
                ${legacyExists} AS legacy
           FROM ${q(table)} p
          WHERE p.tenant_id=$1 AND p."CO_CODE"=$2 AND p."LC_CODE"=$3 AND p."CO_YEAR"=$5
            AND p."CO_BOOK" IN (${books})
            AND NOT EXISTS (SELECT 1 FROM ${q(family.headerTable)} h
                             WHERE h.tenant_id=p.tenant_id AND h."CO_CODE"=p."CO_CODE"
                               AND h."LC_CODE"=p."LC_CODE" AND h."CO_YEAR"=p."CO_YEAR"
                               AND h."CO_BOOK"=p."CO_BOOK" AND h."VCH_NO"=p."VCH_NO")
          GROUP BY p."CO_BOOK", p."VCH_NO"`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        UNTOUCHED_BOOKS,
        scope.coYear,
        mainBooks(family),
      );
    for (const row of rows) {
      const id = `${row.coBook}/${row.vchNo}`;
      const entry = orphans.get(id) ?? {
        coBook: row.coBook,
        vchNo: row.vchNo,
        vchDate: null,
        status: row.legacy ? ('unverified' as const) : ('orphan' as const),
        reason: row.legacy
          ? `voucher kept in ${(family.legacyHeaderTables ?? []).join('/')}, which this check does not re-derive; never changed`
          : 'posting rows without a voucher; reported, never deleted',
        tables: [],
        orphanRows: {},
        storedHash: '',
        expectedHash: '',
        version: '',
      };
      entry.orphanRows![table] = row.n;
      entry.storedHash = sha([entry.storedHash, table, row.h]);
      orphans.set(id, entry);
    }
  }
  checks.push(
    ...[...orphans.values()].sort(
      (a, b) => a.coBook.localeCompare(b.coBook) || a.vchNo.localeCompare(b.vchNo),
    ),
  );
  const summary = {
    match: 0,
    differs: 0,
    missing: 0,
    orphan: 0,
    locked: 0,
    unverified: 0,
    total: checks.length,
  };
  for (const c of checks) summary[c.status]++;
  // Counts promise only what apply will do: the differing and missing vouchers' rows.
  const counts = new Map<string, RepairTableDiff>();
  for (const c of checks.filter((x) => x.status === 'differs' || x.status === 'missing'))
    for (const t of c.tables) {
      const d = counts.get(t.table) ?? diff(t.table, {});
      d.insert += t.onlyExpected.length;
      d.delete += t.onlyStored.length;
      d.update += new Set(t.changed.map((x) => x.key)).size;
      counts.set(t.table, d);
    }
  const fingerprint = sha(
    checks.map((c) => [c.coBook, c.vchNo, c.status, c.storedHash, c.expectedHash, c.version]),
  );
  return {
    check: {
      family: family.id,
      summary,
      vouchers: checks,
      diffs: [...counts.values()],
      fingerprint,
    },
    expected,
  };
}

/** The last check made in a transaction, so an apply right after its framework preview does not derive twice. */
const lastCheck = new WeakMap<
  object,
  {
    family: string;
    check: AccountCheck;
    expected: Map<string, Map<string, Record<string, unknown>[]>>;
  }
>();

const sampleOf = (c: VoucherCheck): string => {
  const parts = c.tables.map(
    (t) =>
      `${t.table} -${t.onlyStored.length} +${t.onlyExpected.length} ~${new Set(t.changed.map((x) => x.key)).size}`,
  );
  const notes = [c.reason, ...(c.warnings ?? [])].filter(Boolean);
  return `${c.coBook}/${c.vchNo}: ${c.status}${parts.length ? ` (${parts.join(', ')})` : ''}${notes.length ? ` - ${notes.join('; ')}` : ''}`;
};

/** A page of the check for the screen. */
export function pageOf(
  check: AccountCheck,
  options: { offset?: number; limit?: number; status?: string } = {},
) {
  const listed = check.vouchers.filter((c) =>
    options.status ? c.status === options.status : c.status !== 'match',
  );
  const offset = Math.max(0, options.offset ?? 0);
  const limit = Math.min(Math.max(1, options.limit ?? 50), 100);
  return {
    family: check.family,
    summary: check.summary,
    total: listed.length,
    offset,
    vouchers: listed.slice(offset, offset + limit),
  };
}

/**
 * Read-only check for the screen's paged list (not audited: it is the same data the audited preview showed). Each
 * page re-runs the family check, which is linear in the family's vouchers; pages hold at most 100 vouchers.
 */
export async function accountCheck(
  prisma: any,
  familyId: string,
  scope: RepairScope,
  options: { offset?: number; limit?: number; status?: string } = {},
) {
  const family = FAMILIES.get(familyId);
  if (!family) throw new RepairError('unknown-operation', `unknown account family: ${familyId}`);
  return withTxBudget(prisma, scope.tenantId, 'heavy', async (tx: any) =>
    pageOf((await checkFamilyTx(tx, family, scope)).check, options),
  );
}

/** Carry the ignored columns a replaced row had onto the new row with the same key. */
async function carriedTx(
  tx: any,
  table: string,
  keyCol: string,
  scope: RefreshVoucherScope,
  vchNo: string,
): Promise<Map<string, Record<string, unknown>>> {
  const types = await columnTypesTx(tx, table);
  const cols = [...IGNORED].filter(
    (c) => types.has(c) && !['row_id', 'tenant_id', 'created_at', 'updated_at'].includes(c),
  );
  if (!cols.length) return new Map();
  const rows: Record<string, unknown>[] = await tx.$queryRawUnsafe(
    `SELECT ${[keyCol, ...cols].map(q).join(',')} FROM ${q(table)} WHERE ${where}`,
    ...keyParams(scope, vchNo),
  );
  return new Map(rows.map((row) => [String(row[keyCol] ?? ''), row]));
}

async function applyFamilyTx(tx: any, family: AccountRefreshFamily, repairScope: RepairScope) {
  const scope = completeScope(repairScope);
  // One Account repair per company at a time, whichever family (the framework lock is per operation).
  await tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `account-refresh:${scope.tenantId}:${scope.coCode}`,
  );
  const reviewed = lastCheck.get(tx);
  const { check, expected } =
    reviewed && reviewed.family === family.id
      ? reviewed
      : await checkFamilyTx(tx, family, repairScope);
  const applied = new Map<string, RepairTableDiff>();
  const beforeRows: Array<{
    coBook: string;
    vchNo: string;
    rows: Record<string, unknown[]>;
    warnings?: string[];
  }> = [];
  for (const c of check.vouchers.filter((x) => x.status === 'differs' || x.status === 'missing')) {
    const vScope = { ...scope, coBook: c.coBook };
    await family.lock(tx, vScope, c.vchNo);
    // The header and every posting row of the voucher: nothing it carries over can change under the apply.
    for (const table of [family.headerTable, ...ACCOUNT_REFRESH_TABLES.map((t) => t.table)])
      await tx.$queryRawUnsafe(
        `SELECT 1 FROM ${q(table)} WHERE ${where} FOR UPDATE`,
        ...keyParams(vScope, c.vchNo),
      );
    // Re-derive under the lock: a voucher saved after the review is refused, not overwritten.
    const again = await checkVoucherTx(tx, family, vScope, c.vchNo, c.vchDate);
    if (
      again.check.version !== c.version ||
      again.check.storedHash !== c.storedHash ||
      again.check.expectedHash !== c.expectedHash
    )
      throw new RepairError(
        'stale-preview',
        'the data changed since the preview; review the operation again',
      );
    const rows = expected.get(`${c.coBook}/${c.vchNo}`) ?? again.expected!;
    await assertPeriodOpen(tx, scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: c.vchDate }] },
    });
    const before: Record<string, unknown[]> = {};
    for (const { table, key } of ACCOUNT_REFRESH_TABLES) {
      before[table] = await storedRowsTx(tx, table, vScope, c.vchNo);
      const carried = await carriedTx(tx, table, key, vScope, c.vchNo);
      await tx.$executeRawUnsafe(
        `DELETE FROM ${q(table)} WHERE ${where}`,
        ...keyParams(vScope, c.vchNo),
      );
      for (const row of rows.get(table) ?? []) {
        const prior = carried.get(String(row[key] ?? ''));
        const { [key]: _key, ...carry } = prior ?? {};
        await insertMaterializedRowTx(tx, table, scope.tenantId, { ...row, ...carry });
      }
    }
    beforeRows.push({
      coBook: c.coBook,
      vchNo: c.vchNo,
      rows: before,
      ...(again.check.warnings ? { warnings: again.check.warnings } : {}),
    });
    for (const t of c.tables) {
      const d = applied.get(t.table) ?? diff(t.table, {});
      d.insert += t.onlyExpected.length;
      d.delete += t.onlyStored.length;
      d.update += new Set(t.changed.map((x) => x.key)).size;
      applied.set(t.table, d);
    }
  }
  return { applied: [...applied.values()], beforeRows };
}

const FAMILIES = new Map<string, AccountRefreshFamily>();

/** Register one family as the operation `data-refresh-account-<id>`. Apply only if it is verified. */
export function registerAccountRefreshFamily(family: AccountRefreshFamily): void {
  FAMILIES.set(family.id, family);
  const verified = () => ACCOUNT_REFRESH_VERIFIED.has(family.id);
  const blockedReason = `${family.title} apply is not available until the family is verified; preview only.`;
  registerRepair({
    id: `data-refresh-account-${family.id}`,
    title: `Account: ${family.title}`,
    description: `Checks every ${family.title} voucher's AC_DATA, ROJ_MEL_DATA and TAX_DATA against what the voucher's own rows post (${family.desktopSource}), and repairs only the vouchers that differ.`,
    // The registry's evidence format is one MS_UPDATE range; the family's builders are named in the description.
    desktopSource: 'MS_UPDATE.cs:2334-2669',
    risk: 'danger',
    get applyAvailable() {
      return verified();
    },
    get blockedReason() {
      return verified() ? undefined : blockedReason;
    },
    completionText: 'Account Refersh Process Complete.',
    tables: ACCOUNT_REFRESH_TABLES.map((t) => t.table),
    async preview(tx, scope) {
      const result = await checkFamilyTx(tx, family, scope);
      lastCheck.set(tx, { family: family.id, ...result });
      const { check } = result;
      return {
        diffs: check.diffs,
        samples: check.vouchers
          .filter((c) => c.status !== 'match')
          .slice(0, 50)
          .map(sampleOf),
        candidateFingerprint: check.fingerprint,
        detail: pageOf(check, { limit: 100 }),
      };
    },
    async apply(tx, scope) {
      if (!verified()) throw new RepairError('preview-only', blockedReason);
      return applyFamilyTx(tx, family, scope);
    },
  });
}

/** Account families registered as operations, in screen order. */
export function accountRefreshFamilies(): Array<{
  id: string;
  title: string;
  operationId: string;
  verified: boolean;
}> {
  return [...FAMILIES.values()].map((f) => ({
    id: f.id,
    title: f.title,
    operationId: `data-refresh-account-${f.id}`,
    verified: ACCOUNT_REFRESH_VERIFIED.has(f.id),
  }));
}

registerAccountRefreshFamily({
  id: 'contra',
  title: 'Contra',
  mainBook: 'CONTRA',
  headerTable: 'CONTRA_DATA',
  versionTables: CONTRA_WRITE_TABLES,
  desktopSource: 'Ac_Ledr.cs:840-848 Contra_Ledr; Ac_Rojmel.cs:336-340 Contra_Rojmel',
  derive: deriveContraPostingsTx,
  lock: (tx, scope, vchNo) => lockContraVoucherTx(tx, scope, vchNo),
});

registerAccountRefreshFamily({
  id: 'fine-jv',
  title: 'Fine Jv',
  mainBook: 'FINE JV',
  bookFilter: `upper(btrim(coalesce(b."BOOK_INOUT",'')))='I'`,
  headerTable: 'CONTRA_DATA',
  versionTables: ['CONTRA_DATA', 'AC_DATA', 'ROJ_MEL_DATA', 'REMARK_DATA', 'APR_IDTL'],
  desktopSource: 'Ac_Ledr.cs:846-848 Contra_Ledr; Ac_Rojmel.cs:342-344 Contra_Rojmel',
  derive: deriveFineJvPostingsTx,
  // editFineJv serialises on the CONTRA_DATA rows alone (FOR UPDATE), which the apply also takes.
  lock: async () => {},
});

registerAccountRefreshFamily({
  id: 'cash-bank',
  title: 'Cash/Bank',
  // TR_CASH's four desktop books and the web's generic RECEIPT / PAYMENT books (cashBank.ts FINANCE_BOOK_FAMILIES).
  mainBook: CASH_BANK_MAIN_BOOKS,
  headerTable: 'CASH_DATA',
  legacyHeaderTables: LEGACY_PAYMENT_TABLES.slice(0, 1),
  versionTables: CASH_WRITE_TABLES,
  desktopSource:
    'Ac_Ledr.cs:565-610 Cash_Ledr/Bank_Ledr; Ac_Rojmel.cs:179-219 Cash_Rojmel/Bank_Rojmel',
  derive: deriveCashBankPostingsTx,
  // editCash and deleteCash serialise on the CASH_DATA rows (FOR UPDATE), which the apply also takes.
  lock: async () => {},
});

export { AccountRefreshDeriveError };
