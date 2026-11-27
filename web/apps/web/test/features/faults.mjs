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
export async function nextVoucherNo(ctx, headerTable, book, scope) {
  // The web numbers per company, location, year and book (numbering.ts currentMaxVoucherNo). Without a scope the
  // prediction spans every year, which is wrong once another module has written the same book in another year.
  const where = scope ? ` AND "CO_CODE"=$3 AND "LC_CODE"=$4 AND "CO_YEAR"=$5` : '';
  const args = scope ? [book, scope.coCode, scope.lcCode, scope.coYear] : [book];
  const [{ n }] = await ctx.rows(
    `SELECT (coalesce(max("VCH_NO"::int),0)+1)::int n FROM "${headerTable}" WHERE tenant_id=$1 AND "CO_BOOK"=$2${where}`,
    ...args,
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
 * @param {string[]} [o.updatedTables] tables a real save changes by UPDATE (a counter row such as SRNO_MAST); a fault on
 *   an UPDATE of each is injected as well, and they count as written in the final comparison
 * @param {{coCode: string, lcCode: string, coYear: string}} [o.scope] the session's company, location and year, to
 *   predict the number in the same scope the web numbers in
 * @param {number} [o.expectedNo] the number the web itself just gave this scope (a probe saved and deleted again: MAX+1
 *   reuses it), when the prediction cannot see every table the book is numbered from
 * @param {boolean} [o.fixedVoucherNo=false] Skip numbering for replacements and fixed opening keys.
 * @param {(response: any) => Promise<string>} [o.voucherNoOf]
 */
export async function rollbackMatrix(ctx, o) {
  const { tables, book, headerTable, submit } = o;
  const voucherNoOf = o.voucherNoOf ?? (async (response) => String((await response.json()).vchNo));
  const expectedNo = o.fixedVoucherNo
    ? null
    : (o.expectedNo ?? (await nextVoucherNo(ctx, headerTable, book, o.scope)));
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

  // Counter rows are updated in place: an INSERT trigger cannot reach them, so fault their UPDATE.
  for (const table of o.updatedTables ?? []) {
    const response = await withWriteFault(ctx, table, 'UPDATE', submit);
    assert.ok(
      response.status() >= 400,
      `fault on the update of ${table}: the save answered ${response.status()}`,
    );
    assert.deepEqual(
      changedTables(before, await tenantFingerprint(ctx)),
      [],
      `fault on the update of ${table}: every table of the tenant is unchanged`,
    );
    attempts.push({
      table: `${table} (update)`,
      status: response.status(),
      pendingElsewhere: null,
    });
  }

  const pending = attempts
    .filter((a) => a.pendingElsewhere !== null)
    .map((a) => a.pendingElsewhere);
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
  if (o.fixedVoucherNo) assert.ok([200, 201].includes(response.status()), await response.text());
  else assert.equal(response.status(), 201, await response.text());
  const rawNo = await voucherNoOf(response);
  const vchNo = o.fixedVoucherNo ? rawNo : rawNo.padStart(5, '0');
  if (!o.fixedVoucherNo)
    assert.equal(
      vchNo,
      String(expectedNo).padStart(5, '0'),
      `no voucher number was consumed: saved ${vchNo}, expected ${expectedNo}`,
    );

  // The Idempotency-Key guard (N52) records its receipt beside the voucher in the same transaction. It is not part of
  // the voucher's write set, so it is left out here; a faulted save still had to leave it unchanged (checked above).
  const written = changedTables(before, await tenantFingerprint(ctx)).filter(
    (table) => table !== 'api_command_receipt',
  );
  assert.deepEqual(
    [...written].sort(),
    [...tables, ...(o.updatedTables ?? [])].sort(),
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

/** Scoped, real database fault; always remove the trigger even when a browser assertion fails. */
export async function withWriteFault(ctx, table, operation, work) {
  assert.match(table, /^[A-Za-z_]+$/);
  assert.ok(['INSERT', 'UPDATE', 'DELETE'].includes(operation));
  assert.match(ctx.tenantId, /^[A-Za-z0-9_-]+$/);
  const row = operation === 'DELETE' ? 'OLD' : 'NEW';
  await ctx.owner.$executeRawUnsafe(
    `CREATE OR REPLACE FUNCTION wp35_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
     BEGIN
       IF ${row}.tenant_id = '${ctx.tenantId}' THEN RAISE EXCEPTION 'WP35 injected fault'; END IF;
       RETURN ${row};
     END $f$`,
  );
  try {
    await ctx.owner.$executeRawUnsafe(
      `CREATE TRIGGER wp35_fault BEFORE ${operation} ON "${table}" FOR EACH ROW EXECUTE FUNCTION wp35_fault()`,
    );
    return await work();
  } finally {
    await ctx.owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS wp35_fault ON "${table}"`);
    await ctx.owner.$executeRawUnsafe('DROP FUNCTION IF EXISTS wp35_fault()');
  }
}

/**
 * Scoped, real database READ fault for read-only screens (reports), the read-side partner of withWriteFault.
 *
 * PostgreSQL has no SELECT trigger, so the fault is a RESTRICTIVE row-level-security policy for the runtime role
 * `app_user` (every tenant table already has forced RLS): its predicate raises for this tenant's rows only, so the
 * first statement that reads `table` for the tenant fails inside the server's own transaction, exactly as a real
 * read error would. Other tenants, the owner connection the case reads with, and every other table are untouched.
 *
 * The fault is not allowed to pass vacuously: a non-transactional sequence written from inside the failing statement
 * records that it fired, and, for each table in `scansOf`, how many scans of it the same transaction had already
 * made (pg_stat_get_xact_numscans of the table, i.e. sequential scans, plus of each of its indexes) — which is how a case proves a fault landed mid-way through a multi-query export.
 *
 * @param {object} ctx  the case context
 * @param {string} table  the table whose read fails
 * @param {() => Promise<any>} work  drive the screen while the fault is armed
 * @param {{scansOf?: string[]}} [o]
 * @returns {Promise<{result: any, fired: boolean, scans: Record<string, number>}>}
 */
export async function withReadFault(ctx, table, work, o = {}) {
  const scansOf = o.scansOf ?? [];
  for (const name of [table, ...scansOf]) assert.match(name, /^[A-Za-z_]+$/);
  assert.match(ctx.tenantId, /^[A-Za-z0-9_-]+$/);
  const sql = (text) => ctx.owner.$executeRawUnsafe(text);
  const probes = scansOf.map((name, i) => ({ name, seq: `e2e_read_fault_scans_${i}` }));
  try {
    for (const seq of ['e2e_read_fault_fired', ...probes.map((p) => p.seq)]) {
      await sql(`CREATE SEQUENCE IF NOT EXISTS ${seq}`);
      await sql(`SELECT setval('${seq}', 1, false)`);
    }
    const record = probes
      .map(
        (p) =>
          `PERFORM setval('${p.seq}', 1 + pg_stat_get_xact_numscans('public."${p.name}"'::regclass)
             + COALESCE((SELECT sum(pg_stat_get_xact_numscans(i.indexrelid))::bigint FROM pg_index i
                          WHERE i.indrelid = 'public."${p.name}"'::regclass), 0));`,
      )
      .join('\n');
    await sql(
      `CREATE OR REPLACE FUNCTION e2e_read_fault(t text) RETURNS boolean
         LANGUAGE plpgsql SECURITY DEFINER SET search_path = public AS $f$
       BEGIN
         IF t = '${ctx.tenantId}' THEN
           PERFORM setval('e2e_read_fault_fired', 1, true);
           ${record}
           RAISE EXCEPTION 'e2e read fault on ${table}';
         END IF;
         RETURN true;
       END $f$`,
    );
    await sql('GRANT EXECUTE ON FUNCTION e2e_read_fault(text) TO app_user');
    await sql(
      `CREATE POLICY e2e_read_fault ON "${table}" AS RESTRICTIVE FOR SELECT TO app_user
         USING (e2e_read_fault(tenant_id))`,
    );
    const result = await work();
    const [{ fired }] = await ctx.owner.$queryRawUnsafe(
      `SELECT is_called fired FROM e2e_read_fault_fired`,
    );
    const scans = {};
    for (const p of probes) {
      const [{ v }] = await ctx.owner.$queryRawUnsafe(`SELECT last_value::int v FROM ${p.seq}`);
      scans[p.name] = v - 1;
    }
    return { result, fired, scans };
  } finally {
    await sql(`DROP POLICY IF EXISTS e2e_read_fault ON "${table}"`);
    await sql('DROP FUNCTION IF EXISTS e2e_read_fault(text)');
    for (const seq of ['e2e_read_fault_fired', ...probes.map((p) => p.seq)])
      await sql(`DROP SEQUENCE IF EXISTS ${seq}`);
  }
}
