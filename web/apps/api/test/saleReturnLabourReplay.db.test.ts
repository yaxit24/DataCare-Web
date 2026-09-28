import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, it, expect } from 'vitest';
import {
  getSaleReturnLabourReplayState,
  observeSaleReturnLabourReplayCode,
  previewSaleReturnLabourReplay,
  type SaleReturnLabourPrefixInput,
  type SaleReturnLabourReplayEvent,
} from '../src/modules/sales/saleReturnLabourReplay.js';
import { getSaleReturnBillReplayState } from '../src/modules/sales/saleReturnBillReplay.js';
import {
  golden,
  billInsert,
  billSelected,
  billVoucher,
  scopeFor,
  assertBillTestDatabase,
  seedLabourFixture,
  cleanLabourFixture,
  insertLabourSession,
  snapshotLabourFixture,
  firstPrefix,
  withPrefix,
  moneyEvent,
  assertGolden,
} from './fixtures/saleReturnLabourReplay.fixture.js';
const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('session-bound saved labour preview in PostgreSQL', () => {
  const tenant = 'r13-labour-api',
    foreign = 'r13-labour-foreign',
    tenants = [tenant, foreign],
    scope = scopeFor(tenant);
  let owner: PrismaClient,
    runtime: PrismaClient,
    identity: Awaited<ReturnType<typeof insertLabourSession>>;
  const sql = (q: string, ...args: unknown[]) => owner.$executeRawUnsafe(q, ...args);
  const snapshot = () => snapshotLabourFixture(owner, tenants);
  const get = () => getSaleReturnLabourReplayState(runtime, identity, scope, billVoucher);
  const lookup = (p: SaleReturnLabourPrefixInput, code: string, field = 13) =>
    observeSaleReturnLabourReplayCode(runtime, identity, scope, billVoucher, {
      ...p,
      fieldId: `x13.primary-incoming.c${field}`,
      editorText: code,
    });
  const append = (p: SaleReturnLabourPrefixInput, event: SaleReturnLabourReplayEvent) =>
    previewSaleReturnLabourReplay(runtime, identity, scope, billVoucher, {
      ...p,
      event,
    });
  const select = async (p: SaleReturnLabourPrefixInput, code: string, field = 13) => {
    const seen = await lookup(p, code, field);
    return append(p, {
      kind: 'labourEnter',
      fieldId: seen.fieldId,
      editorText: seen.editorText,
      observationVersion: seen.observationVersion,
    });
  };
  beforeAll(() => {
    assertBillTestDatabase();
    owner = new PrismaClient({
      datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
    });
    runtime = new PrismaClient();
  });
  beforeEach(async () => {
    await cleanLabourFixture(owner, tenants);
    await seedLabourFixture(owner, tenants);
    identity = await insertLabourSession(owner, tenant);
  });
  afterAll(async () => {
    if (owner) {
      await cleanLabourFixture(owner, tenants);
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });
  it('preserves old DTO/hash and complete literal loaded/opened states with no writes', async () => {
    const before = await snapshot(),
      old = await getSaleReturnBillReplayState(runtime, scope, billVoucher),
      dto = await get();
    expect(dto.billReplay).toEqual(old);
    expect(dto.billReplay.rowReplay.rows[0]).toMatchObject(golden.expected.initial);
    expect(dto.billReplay.phases.loaded).toEqual(golden.expected.loaded);
    expect(dto.billReplay.phases.opened).toEqual(golden.expected.opened);
    expect(dto.capabilities).toEqual({
      canPreview: true,
      canPreviewClosing: false,
      canSaveNumeric: false,
      canApplySource: false,
    });
    expect(dto.context).toEqual({
      sessionId: identity.sessionId,
      contextEpoch: '1',
      coCode: '01',
      lcCode: '01',
      coYear: billSelected.coYear,
    });
    expect(Object.isFrozen(dto.billReplay.savedHeader)).toBe(true);
    expect(await snapshot()).toEqual(before);
  });
  it('lookup neither copies nor appends; BB then AA preserves exact bill tax history', async () => {
    const dto = await get(),
      p = firstPrefix(dto),
      before = await snapshot();
    const observed = await lookup(p, 'BB');
    expect(observed.selection).toEqual({
      CO_CODE: '01',
      LBR_CODE: 'BB',
      LBR_CATG: '01',
      LBR_VAL: '2',
    });
    expect(observed.prefixVersion).toBe(p.prefixVersion);
    expect(observed).not.toHaveProperty('prefix');
    const bb = await select(p, 'BB');
    assertGolden(bb.prefix, 'bb');
    expect(bb.effects).toEqual({
      aggregateApplied: true,
      billApplied: true,
      taxRecalculated: true,
    });
    const aa = await select(withPrefix(p, bb.prefix), 'AA');
    assertGolden(aa.prefix, 'bb-aa');
    expect(aa.prefix.events).toHaveLength(2);
    expect(await snapshot()).toEqual(before);
  });
  it('interleaves money and labour at every bill prefix', async () => {
    const p = firstPrefix(await get()),
      bb = await select(p, 'BB');
    const other = await append(withPrefix(p, bb.prefix), moneyEvent(27, '1'));
    assertGolden(other.prefix, 'bb-other');
    const aa = await select(withPrefix(p, other.prefix), 'AA');
    assertGolden(aa.prefix, 'bb-other-aa');
    expect(aa.prefix.events.map((e) => e.kind)).toEqual([
      'labourEnter',
      'moneyLeave',
      'labourEnter',
    ]);
  });
  for (const [code, field, expected] of [
    ['AA', 13, 'same-aa'],
    ['TA', 29, 'same-ta'],
    ['C3', 13, 'fixed'],
    ['ZZ', 13, 'zero'],
  ] as const)
    it(`qualifies ${code} c${field} and matches every independently expected cell`, async () => {
      const p = firstPrefix(await get()),
        before = await snapshot(),
        result = await select(p, code, field);
      assertGolden(result.prefix, expected);
      expect(result.acceptedEvent.status).toBe('applied');
      expect(result.effects.billApplied).toBe(true);
      expect(result.prefix.events).toHaveLength(1);
      expect(await snapshot()).toEqual(before);
    });
  it('retains repeated same-code events and deterministic retry without persistence', async () => {
    const p = firstPrefix(await get()),
      seen = await lookup(p, 'AA'),
      event = {
        kind: 'labourEnter' as const,
        fieldId: seen.fieldId,
        editorText: 'AA',
        observationVersion: seen.observationVersion,
      };
    const first = await append(p, event),
      retry = await append(p, event);
    expect(retry).toEqual(first);
    const second = await append(withPrefix(p, first.prefix), event);
    assertGolden(second.prefix, 'same-aa');
    expect(second.prefix.events).toHaveLength(2);
  });
  it('refuses missing, case alias, unsupported category and NULL value without falling back', async () => {
    const p = firstPrefix(await get());
    await expect(lookup(p, 'NO')).rejects.toMatchObject({
      statusCode: 422,
      code: 'lookup-required',
    });
    await billInsert(owner, 'LBR_MAST', {
      tenant_id: tenant,
      CO_CODE: '01',
      LBR_CODE: 'bb',
      LBR_CATG: '01',
      LBR_VAL: '2',
    });
    await expect(lookup(p, 'BB')).rejects.toMatchObject({
      statusCode: 422,
      code: 'unsupported-master',
    });
    await sql('DELETE FROM "LBR_MAST" WHERE tenant_id=$1 AND "LBR_CODE"=\'bb\'', tenant);
    await sql(
      'UPDATE "LBR_MAST" SET "LBR_CATG"=\'99\' WHERE tenant_id=$1 AND "LBR_CODE"=\'BB\'',
      tenant,
    );
    await expect(lookup(p, 'BB')).rejects.toMatchObject({
      statusCode: 422,
      code: 'unsupported-master',
    });
    await sql(
      'UPDATE "LBR_MAST" SET "LBR_CATG"=\'01\',"LBR_VAL"=NULL WHERE tenant_id=$1 AND "LBR_CODE"=\'BB\'',
      tenant,
    );
    await expect(lookup(p, 'BB')).rejects.toMatchObject({
      statusCode: 422,
      code: 'unsupported-master',
    });
  });
  it('refuses checked candidate change and historical master change before new lookup', async () => {
    const p = firstPrefix(await get()),
      seen = await lookup(p, 'BB');
    await sql('UPDATE "LBR_MAST" SET "LBR_VAL"=3 WHERE tenant_id=$1 AND "LBR_CODE"=\'BB\'', tenant);
    await expect(
      append(p, {
        kind: 'labourEnter',
        fieldId: seen.fieldId,
        editorText: 'BB',
        observationVersion: seen.observationVersion,
      }),
    ).rejects.toMatchObject({
      statusCode: 409,
      code: 'master-version-conflict',
    });
    const accepted = await select(p, 'BB'),
      prior = withPrefix(p, accepted.prefix);
    await sql('UPDATE "LBR_MAST" SET "LBR_VAL"=2 WHERE tenant_id=$1 AND "LBR_CODE"=\'BB\'', tenant);
    await expect(lookup(prior, 'AA')).rejects.toMatchObject({
      statusCode: 409,
      code: 'master-version-conflict',
    });
  });
  it('detects present-row ABA and delete/recreate while ignoring unrelated master changes', async () => {
    const p = firstPrefix(await get()),
      result = await select(p, 'BB'),
      prior = withPrefix(p, result.prefix);
    await sql('UPDATE "LBR_MAST" SET "LBR_VAL"=99 WHERE tenant_id=$1', foreign);
    expect((await lookup(prior, 'AA')).selection.LBR_CODE).toBe('AA');
    await sql('UPDATE "LBR_MAST" SET "LBR_VAL"=3 WHERE tenant_id=$1 AND "LBR_CODE"=\'BB\'', tenant);
    await sql('UPDATE "LBR_MAST" SET "LBR_VAL"=2 WHERE tenant_id=$1 AND "LBR_CODE"=\'BB\'', tenant);
    await expect(lookup(prior, 'AA')).rejects.toMatchObject({
      code: 'master-version-conflict',
    });
    const fresh = await select(p, 'BB');
    await sql('DELETE FROM "LBR_MAST" WHERE tenant_id=$1 AND "LBR_CODE"=\'BB\'', tenant);
    await billInsert(owner, 'LBR_MAST', {
      tenant_id: tenant,
      CO_CODE: '01',
      LBR_CODE: 'BB',
      LBR_CATG: '01',
      LBR_VAL: '2',
    });
    await expect(lookup(withPrefix(p, fresh.prefix), 'AA')).rejects.toMatchObject({
      code: 'master-version-conflict',
    });
  });
  it('checks the base token before now-malformed saved numeric projection', async () => {
    const p = firstPrefix(await get());
    await sql(
      'UPDATE "SL_DETL_RTN" SET "ITM_RATE"=NULL WHERE tenant_id=$1 AND "CO_BOOK"=\'R11\'',
      tenant,
    );
    await expect(lookup(p, 'BB')).rejects.toMatchObject({
      statusCode: 409,
      code: 'version-conflict',
    });
  });
  it('refuses forged prefix, unknown identity and hidden configured labour field', async () => {
    const dto = await get(),
      p = firstPrefix(dto);
    await expect(lookup({ ...p, prefixVersion: 'f'.repeat(64) }, 'BB')).rejects.toMatchObject({
      code: 'prefix-conflict',
    });
    await expect(lookup({ ...p, rowIdentity: 'e'.repeat(64) }, 'BB')).rejects.toMatchObject({
      statusCode: 409,
    });
    await billInsert(owner, 'COL_MAST', {
      tenant_id: tenant,
      CO_CODE: '01',
      BOOK_NAME: 'SALES RETURNE',
      COL_NAME: 'LCode',
      COL_NEW_NAME: 'Labour code',
      YES_NO: 'N',
    });
    const hidden = await get();
    expect(hidden.rows[0]!.labourFields[0]!.allowed).toBe(false);
    await expect(lookup(firstPrefix(hidden), 'BB')).rejects.toMatchObject({
      statusCode: 422,
      code: 'unsupported-field',
    });
  });
  it('reads an empty saved header but offers no candidate capability', async () => {
    await sql('DELETE FROM "SL_DETL_RTN" WHERE tenant_id=$1 AND "CO_BOOK"=\'R11\'', tenant);
    const dto = await get();
    expect(dto.rows).toEqual([]);
    expect(dto.capabilities.canPreview).toBe(false);
  });
  it('checks fresh read rights and context rather than reusing old request permission', async () => {
    await sql(
      'UPDATE "USER_SET" SET "FRM_VIEW"=\'N\' WHERE tenant_id=$1 AND "USER_NAME"=\'view\'',
      tenant,
    );
    await expect(get()).rejects.toMatchObject({ statusCode: 403 });
    await sql(
      'UPDATE "USER_SET" SET "FRM_VIEW"=\'Y\' WHERE tenant_id=$1 AND "USER_NAME"=\'view\'',
      tenant,
    );
    await sql('UPDATE "auth_session" SET context_epoch=2 WHERE tenant_id=$1', tenant);
    await expect(get()).rejects.toMatchObject({
      statusCode: 409,
      code: 'context-stale',
    });
  });
  it('preserves the exact accepted prefix after copy succeeds but the bill rejects', async () => {
    // Prior independent bill boundary, adapted to a resolved category02 copy. No expected total is generated from the new service.
    await sql('UPDATE "CO_SET" SET "SL_AMT_TYPE"=\'F\' WHERE tenant_id=$1', tenant);
    await sql(
      'UPDATE "SL_DATA" SET "TAX_PRC"=99999 WHERE tenant_id=$1 AND "CO_BOOK"=\'R11\'',
      tenant,
    );
    await sql(
      `UPDATE "SL_DETL_RTN" SET "ITM_GWT"=10000000000,"ITM_NWT"=10000000000,"ITM_TOUCH"=1000000000,"ITM_RATE"=1000000000000000,"LBR_PRC"=0,"LBR_RATE"=0,"LBR_AMT"=0,"LBR_TYPE"='N' WHERE tenant_id=$1 AND "CO_BOOK"='R11'`,
      tenant,
    );
    await billInsert(owner, 'LBR_MAST', {
      tenant_id: tenant,
      CO_CODE: '01',
      LBR_CODE: 'P2',
      LBR_CATG: '02',
      LBR_VAL: '9999999999',
    });
    const p = firstPrefix(await get()),
      first = await append(p, moneyEvent(21, '0')),
      prior = withPrefix(p, first.prefix),
      seen = await lookup(prior, 'P2'),
      before = await snapshot();
    await expect(
      append(prior, {
        kind: 'labourEnter',
        fieldId: seen.fieldId,
        editorText: 'P2',
        observationVersion: seen.observationVersion,
      }),
    ).rejects.toMatchObject({
      statusCode: 422,
      code: 'calculation-rejected',
      details: {
        eventIndex: 1,
        recovery: first.prefix,
        diagnostics: [
          expect.objectContaining({
            code: 'unsupported-precision',
            stage: 'bill matrix r2',
          }),
        ],
      },
    });
    expect(await snapshot()).toEqual(before);
  });
  it('keeps scope detached and all reads in one RR snapshot during a concurrent master change', async () => {
    const p = firstPrefix(await get()),
      before = await lookup(p, 'BB');
    let changed = false,
      transactions = 0;
    const mutableScope = { ...scope };
    const wrapped = {
      $transaction: (fn: (tx: any) => Promise<unknown>, opts: any) => {
        transactions++;
        expect(opts.isolationLevel).toBe('RepeatableRead');
        return runtime.$transaction(
          async (tx) =>
            fn(
              new Proxy(tx, {
                get(target, key) {
                  if (key === '$queryRawUnsafe')
                    return async (q: string, ...args: unknown[]) => {
                      const result = await target.$queryRawUnsafe(q, ...args);
                      if (!changed && q.includes('FROM "SL_DETL_RTN"')) {
                        changed = true;
                        mutableScope.coBook = 'R12';
                        await sql(
                          'UPDATE "LBR_MAST" SET "LBR_VAL"=3 WHERE tenant_id=$1 AND "LBR_CODE"=\'BB\'',
                          tenant,
                        );
                      }
                      return result;
                    };
                  const value = Reflect.get(target, key);
                  return typeof value === 'function' ? value.bind(target) : value;
                },
              }),
            ),
          opts,
        );
      },
    };
    const observed = await observeSaleReturnLabourReplayCode(
      wrapped,
      identity,
      mutableScope,
      billVoucher,
      { ...p, fieldId: 'x13.primary-incoming.c13', editorText: 'BB' },
    );
    expect(changed).toBe(true);
    expect(transactions).toBe(1);
    expect(observed.observationVersion).toBe(before.observationVersion);
    expect(observed.scope.coBook).toBe('R11');
    expect((await lookup(p, 'BB')).observationVersion).not.toBe(before.observationVersion);
  });
});
