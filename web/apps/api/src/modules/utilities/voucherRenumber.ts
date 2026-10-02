import { withTxBudget } from '../shared/txBudget.js';

/**
 * Voucher Renumber (Phase 12 / UT) — web port of the desktop UT_VCH_RENO utility.
 *
 * Resequences every voucher in one book+year to a gapless 1..N ordered by (VCH_DATE, VCH_NO), across
 * ALL of the voucher's tables at once (header + detail + tax + stock + ledger), so a book that has
 * developed holes (deleted/voided vouchers) is renumbered contiguously while keeping each voucher's
 * rows joined by the shared VCH_NO.
 *
 * SAFETY (this utility rewrites the voucher key, so it is deliberately conservative):
 *  • DRY-RUN FIRST. previewRenumber is READ-ONLY and returns the exact old→new map + gap count.
 *  • OPT-IN. applyRenumber refuses unless confirm===true (throws RenumberValidationError → HTTP 400).
 *  • ONE TRANSACTION. All writes run inside a single withTenant tx; any failure rolls everything back
 *    and RLS scopes every statement to the tenant.
 *  • COLLISION-SAFE. The new numbers overlap the old numbers (it is a permutation of 1..N), so a
 *    direct "UPDATE VCH_NO=new WHERE VCH_NO=old" would transiently collide with a number that still
 *    exists. We therefore use a two-phase park: first move every CHANGING voucher's rows out of the
 *    live range by +1,000,000, then bring each parked row down to its final number. Because every
 *    changing voucher is parked before any is reassigned, each target slot is guaranteed vacant.
 *  • FORMAT-FAITHFUL. The desktop stores VCH_NO zero-padded (e.g. '00031'); we match the old value
 *    numerically (padding-agnostic) and re-pad the new value to the column's existing width.
 *  • SCOPED. Every statement is filtered by CO_CODE / CO_YEAR / CO_BOOK (+ LC_CODE when present).
 */

/** Quote a SQL identifier, stripping anything but [A-Za-z0-9_] (posting.ts parity). */
const q = (id: string): string => '"' + id.replace(/[^A-Za-z0-9_]/g, '') + '"';

const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};

/** Company / year / location a voucher book lives in. Tenant is bound by RLS via withTenant. */
export interface RenumberScope {
  tenantId: string;
  coCode: string;
  coYear: string;
  lcCode: string;
}

/** One voucher's current number, its proposed gapless number, its date and its AC_DATA leg count. */
export interface RenumberPreviewRow {
  vchNo: number;
  newNo: number;
  vchDate: string;
  legs: number;
}

/** Domain validation error — the name carries 'ValidationError' so the txn route adapter maps it to HTTP 400. */
export class RenumberValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'RenumberValidationError';
  }
}

/**
 * Voucher tables eligible for renumber. Almost every table in the schema happens to carry both a
 * VCH_NO and a CO_BOOK column, so an unbounded "rewrite everything with those columns" would touch
 * ~100 unrelated tables. This allowlist pins the rewrite to the real voucher tables; at runtime it is
 * further intersected with (a) the tables that actually have BOTH columns and (b) the tables that
 * actually hold this book's rows.
 */
export const RENUMBER_TABLE_ALLOWLIST = [
  'AC_DATA',
  'SL_DATA',
  'SL_DETL',
  'SL_IDTL',
  'PR_DATA',
  'PR_DETL',
  'TAX_DATA',
  'BILL_OS_DATA',
  'MAIN_STOCK',
  'CASH_DATA',
] as const;

/** Collision-safe parking offset: changing vouchers are moved to VCH_NO+OFFSET, well above any live
 *  number, before being brought down to their final value. 1,000,000 + a realistic per-book count
 *  stays within VCH_NO's VarChar(8). */
const RENUMBER_OFFSET = 1_000_000;

/** Build the parameterized book-scope predicate (+ its bound params). LC_CODE is included only when
 *  the scope carries one, so single- and multi-location books are both handled correctly. */
function scopeWhere(scope: RenumberScope, book: string): { where: string; params: unknown[] } {
  const params: unknown[] = [scope.coCode, scope.coYear, book];
  let where = `"CO_CODE"=$1 AND "CO_YEAR"=$2 AND "CO_BOOK"=$3`;
  if (scope.lcCode != null && String(scope.lcCode).trim() !== '') {
    params.push(scope.lcCode);
    where += ` AND "LC_CODE"=$4`;
  }
  return { where, params };
}

/** A resolved target table plus the zero-pad width to preserve when writing its new VCH_NO. */
interface RenumberTable {
  table: string;
  width: number;
}

/**
 * Resolve the set of tables to rewrite for this book:
 *   allowlist  (∩ caller-supplied `tables`, if any — never anything outside the allowlist)
 *   ∩ tables that actually have BOTH a VCH_NO and a CO_BOOK column (information_schema, at runtime)
 *   ∩ tables that actually contain at least one numeric-VCH_NO row for this book scope.
 * Also captures each table's existing VCH_NO width so the rewrite stays zero-pad faithful.
 */
async function resolveTables(
  tx: any,
  scope: RenumberScope,
  book: string,
  requested?: string[],
): Promise<RenumberTable[]> {
  const allow = new Set<string>(RENUMBER_TABLE_ALLOWLIST as readonly string[]);
  const candidates =
    requested && requested.length
      ? Array.from(new Set(requested.map((t) => String(t)))).filter((t) => allow.has(t))
      : Array.from(allow);
  if (!candidates.length) return [];

  // (a) keep only candidates that have BOTH columns in the live schema.
  const colRows: any[] = await tx.$queryRawUnsafe(
    `SELECT c1.table_name AS t
       FROM information_schema.columns c1
       JOIN information_schema.columns c2
         ON c1.table_schema = c2.table_schema AND c1.table_name = c2.table_name
      WHERE c1.table_schema = 'public'
        AND c1.column_name = 'VCH_NO'
        AND c2.column_name = 'CO_BOOK'
        AND c1.table_name = ANY (string_to_array($1, ','))`,
    candidates.join(','),
  );
  const haveCols = new Set<string>(colRows.map((r) => String(r.t)));

  // (b) keep only those that actually hold this book's rows; capture the VCH_NO pad width.
  const { where, params } = scopeWhere(scope, book);
  const out: RenumberTable[] = [];
  for (const t of candidates) {
    if (!haveCols.has(t)) continue;
    const r: any[] = await tx.$queryRawUnsafe(
      `SELECT max(length("VCH_NO"))::int AS w, count(*)::int AS n
         FROM ${q(t)} WHERE ${where} AND "VCH_NO" ~ '^[0-9]+$'`,
      ...params,
    );
    const n = num(r[0]?.n);
    const w = num(r[0]?.w);
    if (n > 0) out.push({ table: t, width: Math.max(1, Math.trunc(w)) });
  }
  return out;
}

/** AC_DATA-derived old→new map for the book (date order). `changed` excludes identity mappings. */
async function buildMapTx(
  tx: any,
  scope: RenumberScope,
  book: string,
): Promise<{ rows: RenumberPreviewRow[]; changed: { old: number; new: number }[] }> {
  const { where, params } = scopeWhere(scope, book);
  const rows: any[] = await tx.$queryRawUnsafe(
    `WITH v AS (
       SELECT "VCH_NO" AS vchno, MIN("VCH_DATE") AS vchdate, COUNT(*)::int AS legs
         FROM "AC_DATA"
        WHERE ${where} AND "VCH_NO" ~ '^[0-9]+$'
        GROUP BY "VCH_NO"
     )
     SELECT (vchno)::int AS "vchNo",
            (ROW_NUMBER() OVER (ORDER BY vchdate NULLS LAST, (vchno)::int))::int AS "newNo",
            vchdate::text AS "vchDate",
            legs AS legs
       FROM v
      ORDER BY "newNo"`,
    ...params,
  );
  const out: RenumberPreviewRow[] = rows.map((r) => ({
    vchNo: num(r.vchNo),
    newNo: num(r.newNo),
    vchDate: r.vchDate ? String(r.vchDate).slice(0, 10) : '',
    legs: num(r.legs),
  }));
  const changed = out
    .filter((r) => r.vchNo !== r.newNo)
    .map((r) => ({ old: r.vchNo, new: r.newNo }));
  return { rows: out, changed };
}

/**
 * DRY-RUN. Compute the gapless 1..N resequence for a book WITHOUT writing anything. Vouchers are read
 * from AC_DATA (the ledger every voucher writes), de-duplicated by VCH_NO, ordered by VCH_DATE then
 * VCH_NO, and assigned newNo 1..N. `gaps` is the number of vouchers whose number would change.
 */
export async function previewRenumber(
  prisma: any,
  scope: RenumberScope,
  p: { book: string },
): Promise<{ rows: RenumberPreviewRow[]; gaps: number }> {
  const book = String(p?.book ?? '').trim();
  if (!book) throw new RenumberValidationError('book is required');
  return withTxBudget(prisma, scope.tenantId, 'heavy', async (tx: any) => {
    const { rows } = await buildMapTx(tx, scope, book);
    const gaps = rows.reduce((n, r) => n + (r.vchNo !== r.newNo ? 1 : 0), 0);
    return { rows, gaps };
  });
}

/**
 * APPLY the renumber. Refuses unless confirm===true. Inside ONE tenant transaction it (1) rebuilds
 * the old→new map from AC_DATA, (2) resolves the voucher tables that actually hold this book's rows,
 * and (3) for each table performs the collision-safe two-phase rewrite: park every changing voucher
 * at VCH_NO+OFFSET, then bring each parked row down to its final (re-padded) number. Returns the
 * number of vouchers renumbered and the tables actually modified.
 */
export async function applyRenumber(
  prisma: any,
  scope: RenumberScope,
  p: { book: string; tables?: string[]; confirm: boolean },
): Promise<{ renumbered: number; tablesTouched: string[] }> {
  const book = String(p?.book ?? '').trim();
  if (!book) throw new RenumberValidationError('book is required');
  if (p?.confirm !== true) {
    throw new RenumberValidationError(
      'refusing to renumber without confirm:true — run the preview (dry-run) first',
    );
  }

  return withTxBudget(prisma, scope.tenantId, 'heavy', async (tx: any) => {
    const { where, params } = scopeWhere(scope, book);
    const base = params.length; // next positional placeholder is $base+1

    const { changed } = await buildMapTx(tx, scope, book);
    const tables = await resolveTables(tx, scope, book, p?.tables);

    // Nothing to do — the book is already gapless 1..N. No writes.
    if (changed.length === 0) return { renumbered: 0, tablesTouched: [] };

    const oldsCsv = changed.map((c) => c.old).join(','); // our own integers — bound as one text param
    const touched: string[] = [];

    for (const { table, width } of tables) {
      const tq = q(table);

      // Phase 1 — park: move every changing voucher's rows out of the live range (+OFFSET) in one
      // statement. The CASE guard ensures the ::int cast only runs on numeric VCH_NO rows.
      const parked = await tx.$executeRawUnsafe(
        `UPDATE ${tq}
            SET "VCH_NO" = (("VCH_NO")::int + ${RENUMBER_OFFSET})::text
          WHERE ${where}
            AND CASE WHEN "VCH_NO" ~ '^[0-9]+$'
                     THEN ("VCH_NO")::int = ANY (string_to_array($${base + 1}, ',')::int[])
                     ELSE false END`,
        ...params,
        oldsCsv,
      );

      // Phase 2 — assign: bring each parked voucher down to its final number, re-padded to the
      // column's width. Every changing voucher is already parked, so each target slot is vacant.
      for (const c of changed) {
        await tx.$executeRawUnsafe(
          `UPDATE ${tq}
              SET "VCH_NO" = lpad(($${base + 1})::text, ${width}, '0')
            WHERE ${where} AND "VCH_NO" = ($${base + 2})::text`,
          ...params,
          String(c.new),
          String(c.old + RENUMBER_OFFSET),
        );
      }

      if (num(parked) > 0) touched.push(table);
    }

    return { renumbered: changed.length, tablesTouched: touched };
  });
}
