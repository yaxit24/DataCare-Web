/**
 * Write-set footprint probe, shared by the voucher lifecycle suites.
 *
 * WHY IT EXISTS
 * -------------
 * The lifecycle tests assert the CONTENT of rows they look at. Nothing asserted the SET of tables that received
 * rows, and that gap was proven rather than assumed: emitting `{ table: 'TAX_DATA', rows: [] }` from the sale —
 * dropping every tax row — passed 26 tests across three files, including the GST suite. A voucher with no tax
 * rows at all was indistinguishable from a correct one.
 *
 * That is the same failure the desktop comparison reports as `WEB NEVER WROTE THIS TABLE`, and it is the most
 * consequential kind of parity defect: the voucher looks right on screen and in its own detail rows while an
 * entire ledger or tax table is absent.
 *
 * WHY IT IS SCHEMA-DRIVEN
 * -----------------------
 * The probe enumerates every table carrying a `VCH_NO` column rather than consulting a list. A hand-written list
 * can only restate what its author already believed, so it cannot reveal a table nobody thought of — which is
 * exactly the case that matters.
 */

/** Minimal Prisma-ish surface, so the helper does not depend on the generated client's types. */
interface RawClient {
  $queryRawUnsafe: (sql: string, ...params: unknown[]) => Promise<unknown>;
}

/**
 * Every table in the schema that carries a `VCH_NO` column.
 *
 * Read once per suite. The count is asserted by callers: a schema that suddenly exposes very few voucher tables
 * means the probe is looking at the wrong database, and a footprint assertion against that would pass vacuously.
 */
export async function voucherTables(owner: RawClient): Promise<string[]> {
  const rows = (await owner.$queryRawUnsafe(
    `SELECT table_name AS name FROM information_schema.columns
      WHERE table_schema='public' AND upper(column_name)='VCH_NO'
      GROUP BY table_name ORDER BY table_name`,
  )) as { name: string }[];
  return rows.map((r) => String(r.name));
}

/**
 * Which of those tables actually received rows for one voucher.
 *
 * A table that cannot be queried (a permission or shape problem) is treated as untouched rather than throwing,
 * because the alternative is one awkward table aborting the whole probe and hiding every other finding. The
 * count assertion in `voucherTables` is what protects against a wholesale failure going unnoticed.
 */
export async function footprintOf(
  owner: RawClient,
  tables: readonly string[],
  tenantId: string,
  vchNo: string,
): Promise<string[]> {
  const touched: string[] = [];
  for (const table of tables) {
    const rows = (await owner
      .$queryRawUnsafe(
        `SELECT count(*)::int AS n FROM "${table}" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
        tenantId,
        vchNo,
      )
      .catch(() => [{ n: 0 }])) as { n: number }[];
    if ((rows[0]?.n ?? 0) > 0) touched.push(table);
  }
  return touched.sort();
}

/**
 * Debit and credit totals for one voucher's ledger rows.
 *
 * Asserted alongside the footprint because a footprint check alone would pass if `AC_DATA` received rows that
 * did not balance — the table would be present and the postings still wrong.
 */
export async function ledgerLegs(
  owner: RawClient,
  tenantId: string,
  vchNo: string,
): Promise<{ dr: number; cr: number }> {
  const rows = (await owner.$queryRawUnsafe(
    `SELECT coalesce(sum("DR_AMT"),0)::float dr, coalesce(sum("CR_AMT"),0)::float cr
       FROM "AC_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
    tenantId,
    vchNo,
  )) as { dr: number; cr: number }[];
  return { dr: Number(rows[0]?.dr ?? 0), cr: Number(rows[0]?.cr ?? 0) };
}
