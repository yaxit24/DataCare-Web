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
 * FAILURES ARE COLLECTED AND THEN THROWN, never swallowed.
 *
 * This previously carried `.catch(() => [{ n: 0 }])`, which turned any unreadable table into a count of zero.
 * The stated reason was sound - one awkward table should not abort the whole probe and hide every other
 * finding - but treating an error as "untouched" is the wrong mechanism for it, because the realistic failure
 * here is not an odd table shape. The table list comes from `information_schema`, so every table in it has the
 * column being queried. The realistic failure is ROW-LEVEL SECURITY: handed an RLS-bound client, every query
 * returns nothing and the footprint comes back EMPTY rather than failing. An empty footprint reads as "the
 * module wrote nothing", which is a defect report, not a harness error - so the swallow could turn a
 * misconfigured probe into a false accusation against working code.
 *
 * The original intent is kept by continuing past a failure and reporting them all together at the end, so one
 * awkward table still does not hide the others - it just cannot hide itself either.
 *
 * Pass a TENANT-SCOPED transaction, not a bare RLS-bound client:
 *
 *     await withTenant(prisma, tenantId, (tx) => footprintOf(tx, tables, tenantId, vchNo))
 */
export async function footprintOf(
  owner: RawClient,
  tables: readonly string[],
  tenantId: string,
  vchNo: string,
): Promise<string[]> {
  const touched: string[] = [];
  const failures: string[] = [];
  for (const table of tables) {
    try {
      const rows = (await owner.$queryRawUnsafe(
        `SELECT count(*)::int AS n FROM "${table}" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
        tenantId,
        vchNo,
      )) as { n: number }[];
      if ((rows[0]?.n ?? 0) > 0) touched.push(table);
    } catch (e) {
      failures.push(`${table}: ${e instanceof Error ? e.message : String(e)}`);
    }
  }
  if (failures.length) {
    throw new Error(
      `footprintOf could not read ${failures.length} of ${tables.length} table(s); ` +
        `a footprint built from a partial read would understate the write set.\n  ` +
        failures.join('\n  '),
    );
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
