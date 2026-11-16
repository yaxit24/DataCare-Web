import assert from 'node:assert/strict';

/**
 * T14 rollback: a fault on any one write of a voucher save must leave the whole tenant exactly as it was.
 *
 * The desktop writes table by table with no transaction around the voucher, so a fault there leaves the earlier
 * tables behind. The web writes a voucher in one transaction, and this proves it through the real screen: a trigger
 * makes one table's insert fail, the screen's save is refused, and every row of every tenant table is compared with a
 * fingerprint taken before. Then the fault is removed and the same screen saves, taking the voucher number the failed
 * attempts did not use.
 *
 * It is not allowed to pass vacuously:
 *  - the faulted tables must be exactly the tables a real save writes (so a fault on a table the save never touches,
 *    or a write the matrix forgot, fails the case);
 *  - a non-transactional sequence written by the trigger records, from inside the failing transaction, how many of the
 *    other write-set tables already held uncommitted rows. The one that is written last must have found all of them.
 */

/** One fingerprint per tenant table: row count and an MD5 of every row's full text. audit_log is compared apart. */
export async function tenantFingerprint(ctx) {
  const tables = await ctx.owner.$queryRawUnsafe(
    `SELECT table_name name FROM information_schema.columns
      WHERE table_schema='public' AND column_name='tenant_id' AND table_name<>'audit_log'
      GROUP BY table_name ORDER BY table_name`,
  );
  const out = {};
  for (const { name } of tables) {
    const [r] = await ctx.rows(
      `SELECT count(*)::int n, coalesce(md5(string_agg(t::text, E'\\n' ORDER BY t::text)), '') h
         FROM "${name}" t WHERE t.tenant_id=$1`,
    );
    out[name] = `${r.n}:${r.h}`;
  }
  return out;
}

export const changedTables = (before, after) =>
  Object.keys(after).filter((table) => before[table] !== after[table]);

const auditRows = (ctx) =>
  ctx.rows(
    `SELECT id::text id,login_name login,co_code company,action,path,status
       FROM audit_log WHERE tenant_id=$1 ORDER BY id`,
  );

/** The next voucher number of a book: what the failed attempts must not have taken. */
export async function nextVoucherNo(ctx, headerTable, book) {
  const [{ n }] = await ctx.rows(
    `SELECT (coalesce(max("VCH_NO"::int),0)+1)::int n FROM "${headerTable}" WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
    book,
  );
  return n;
}

/**
 * @param {object} ctx  the case context
 * @param {object} o
 * @param {string[]} o.tables    the write set to fault, one table per attempt (must equal what a real save writes)
 * @param {string}   o.book      CO_BOOK of the voucher; the trigger fires only for this tenant and book
 * @param {string}   o.headerTable  the voucher header table, to predict the next number
 * @param {() => Promise<any>} o.submit  click Save on the filled screen and return the response
 * @param {(response: any) => Promise<string>} [o.voucherNoOf]
 */
export async function rollbackMatrix(ctx, o) {
  const { tables, book, headerTable, submit } = o;
  const voucherNoOf = o.voucherNoOf ?? (async (response) => String((await response.json()).vchNo));
  const expectedNo = await nextVoucherNo(ctx, headerTable, book);
  const before = await tenantFingerprint(ctx);
  const auditBefore = await auditRows(ctx);

  const attempts = [];
  for (const table of tables) {
    // The probe sequence is not transactional, so what the trigger writes to it survives the rollback.
    await ctx.owner.$executeRawUnsafe(`CREATE SEQUENCE IF NOT EXISTS e2e_fault_pending`);
    await ctx.owner.$executeRawUnsafe(`SELECT setval('e2e_fault_pending', 1, false)`);
    const pendingExpr = tables
      .filter((other) => other !== table)
      .map(
        (other) =>
          `(CASE WHEN pg_stat_get_xact_tuples_inserted('public."${other}"'::regclass) > 0 THEN 1 ELSE 0 END)`,
      )
      .join(' + ');
    await ctx.owner.$executeRawUnsafe(
      `CREATE OR REPLACE FUNCTION e2e_fault() RETURNS trigger LANGUAGE plpgsql SECURITY DEFINER AS $f$
       BEGIN
         IF NEW.tenant_id = '${ctx.tenantId}' AND NEW."CO_BOOK" = '${book}' THEN
           PERFORM setval('e2e_fault_pending', 1 + ${pendingExpr || '0'});
           RAISE EXCEPTION 'e2e fault on ${table}';
         END IF;
         RETURN NEW;
       END $f$`,
    );
    await ctx.owner.$executeRawUnsafe(
      `CREATE TRIGGER e2e_fault BEFORE INSERT ON "${table}" FOR EACH ROW EXECUTE FUNCTION e2e_fault()`,
    );
    try {
      const response = await submit();
      assert.ok(
        response.status() >= 400,
        `fault on ${table}: the save answered ${response.status()}`,
      );
      const after = await tenantFingerprint(ctx);
      assert.deepEqual(
        changedTables(before, after),
        [],
        `fault on ${table}: every table of the tenant is unchanged`,
      );
      const [{ v }] = await ctx.owner.$queryRawUnsafe(
        `SELECT last_value::int v FROM e2e_fault_pending`,
      );
      // v = 1 + the number of other write-set tables that held uncommitted rows when the fault fired
      attempts.push({ table, status: response.status(), pendingElsewhere: v - 1 });
    } finally {
      await ctx.owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS e2e_fault ON "${table}"`);
      await ctx.owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS e2e_fault()`);
      await ctx.owner.$executeRawUnsafe(`DROP SEQUENCE IF EXISTS e2e_fault_pending`);
    }
  }

  const pending = attempts.map((a) => a.pendingElsewhere);
  assert.equal(
    Math.max(...pending),
    tables.length - 1,
    `the last write found every other table pending: ${JSON.stringify(attempts)}`,
  );
  assert.ok(
    pending.filter((n) => n === 0).length <= 1,
    `at most the first write has nothing pending: ${JSON.stringify(attempts)}`,
  );

  // The fault is gone: the same screen saves, and it takes the number the failed attempts did not use.
  const response = await submit();
  assert.equal(response.status(), 201, await response.text());
  const vchNo = (await voucherNoOf(response)).padStart(5, '0');
  assert.equal(vchNo, String(expectedNo).padStart(5, '0'), 'no voucher number was consumed');

  // The Idempotency-Key guard (N52) records its receipt beside the voucher in the same transaction. It is not part of
  // the voucher's write set, so it is left out here; a faulted save still had to leave it unchanged (checked above).
  const written = changedTables(before, await tenantFingerprint(ctx)).filter(
    (table) => table !== 'api_command_receipt',
  );
  assert.deepEqual(
    [...written].sort(),
    [...tables].sort(),
    'the faulted tables are exactly the tables a real save writes',
  );

  const auditAfter = new Map((await auditRows(ctx)).map((row) => [row.id, JSON.stringify(row)]));
  for (const row of auditBefore)
    assert.equal(
      auditAfter.get(row.id),
      JSON.stringify(row),
      `existing audit row ${row.id} stays unchanged`,
    );
  return { attempts, written, vchNo, expectedNo };
}
