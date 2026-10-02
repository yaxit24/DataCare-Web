import { randomUUID } from 'node:crypto';
import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  selectSessionContext,
  type SelectionAuthenticatedIdentity,
  type SelectedSessionContext,
} from '../src/modules/auth/sessionContextSelection.js';

const databaseDescribe = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenant = 'context-select-db';
const sid = '11111111-1111-4111-8111-111111111111';
const operation = '22222222-2222-4222-8222-222222222222';
const ledger = {
  version: 'server-session-ledger-context-v1',
  status: 'unknown',
  mode: null,
  reason: 'legacy-session-uninitialized',
};
const identity = (context?: Partial<SelectedSessionContext>): SelectionAuthenticatedIdentity => ({
  tenantId: tenant,
  sessionId: sid,
  loginName: 'operator',
  loginCoCode: '01',
  coCode: context?.coCode ?? '01',
  lcCode: context?.lcCode ?? '01',
  coYear: context?.coYear ?? '2024-2025',
  contextEpoch: context?.contextEpoch ?? '9',
});
const request = (extra: Record<string, unknown> = {}) => ({
  coCode: '02',
  expectedContextEpoch: '9',
  selectionId: operation,
  ...extra,
});
function barrier() {
  let release!: () => void;
  const promise = new Promise<void>((resolve) => {
    release = resolve;
  });
  return { promise, release };
}

databaseDescribe('atomic session company selection on real PostgreSQL', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const appName = `selection-${randomUUID()}`;
  const tables = ['auth_session', 'CO_SET', 'LOGIN_MAST', 'YEAR_MAST', 'LOCT_MAST', 'CO_MAST'];
  const cleanup = async () => {
    for (const table of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE "tenant_id"=$1`, tenant);
  };
  const snapshot = async () => {
    const out: Record<string, unknown> = {};
    for (const table of tables) {
      // PostgreSQL renders the full row; neither BIGINT nor timestamp fractions pass through JS Number/Date.
      out[table] = await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t)::text AS value FROM "${table}" t WHERE "tenant_id"=$1 ORDER BY to_jsonb(t)::text`,
        tenant,
      );
    }
    return out;
  };
  const sessionRow = async () => {
    const rows = await owner.$queryRawUnsafe<Array<Record<string, unknown>>>(
      `SELECT "co_code","lc_code","co_year","login_co_code","context_epoch"::text AS epoch,
       "ledger_context","last_context_from_epoch"::text AS from_epoch,"last_context_selection_id" AS selection_id,
       "refresh_jti_hash","revoked_at"::text AS revoked_at FROM "auth_session" WHERE "tenant_id"=$1`,
      tenant,
    );
    return rows[0]!;
  };
  const waitForRuntimeLock = async () => {
    const deadline = Date.now() + 4000;
    while (Date.now() < deadline) {
      const rows = await owner.$queryRawUnsafe<Array<{ waiting: boolean }>>(
        `SELECT EXISTS(SELECT 1 FROM pg_stat_activity WHERE application_name=$1 AND wait_event_type='Lock') AS waiting`,
        appName,
      );
      if (rows[0]?.waiting) return;
      await new Promise((resolve) => setTimeout(resolve, 10));
    }
    throw new Error('second session transaction did not reach the expected database lock');
  };
  beforeAll(async () => {
    if (!process.env.MIGRATE_DATABASE_URL || !process.env.DATABASE_URL)
      throw new Error('isolated database wrapper required');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    const runtimeUrl = new URL(process.env.DATABASE_URL);
    runtimeUrl.searchParams.set('application_name', appName);
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl.toString() } } });
  });
  beforeEach(async () => {
    await cleanup();
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_MAST"("tenant_id","CO_CODE","LC_CODE") VALUES ($1,'01','01'),($1,'02','02')`,
      tenant,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOCT_MAST"("tenant_id","CO_CODE","LC_CODE") VALUES ($1,'01','01'),($1,'02','02')`,
      tenant,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"("tenant_id","CO_CODE","CO_YEAR") VALUES ($1,'01','2024-2025'),($1,'02','2025-2026')`,
      tenant,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "LOGIN_MAST"("tenant_id","CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_PRINT")
      VALUES ($1,'01','operator','fixture','ADMIN','Y'),($1,'02','operator','fixture','USER','N')`,
      tenant,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"("tenant_id","CO_CODE","LAST_DAY_LOCK","LOCK_DATE") VALUES ($1,'01','N',''),($1,'02','Y','2000-01-01')`,
      tenant,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "auth_session"("tenant_id","session_id","login_name","login_co_code","co_code","lc_code","co_year",
      "refresh_jti_hash","created_at","last_used_at","expires_at","context_epoch","ledger_context")
      VALUES ($1,$2,'operator','01','01','01','2024-2025',repeat('a',64),clock_timestamp(),clock_timestamp(),clock_timestamp()+interval '1 hour',9,$3::jsonb)`,
      tenant,
      sid,
      JSON.stringify(ledger),
    );
  });
  afterAll(async () => {
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('commits scope, exact epoch, receipt and last-day lock together with fresh target rights', async () => {
    const before = await snapshot();
    const signed: unknown[] = [];
    const result = await selectSessionContext(
      runtime,
      { identity: identity(), request: request() },
      {
        signAccess: async (value) => {
          signed.push(value);
          return 'signed-target-access';
        },
      },
    );
    expect(result).toMatchObject({
      accessToken: 'signed-target-access',
      replayed: false,
      lastDayLock: { applied: true },
    });
    expect(signed).toEqual([
      expect.objectContaining({
        loginCoCode: '01',
        coCode: '02',
        lcCode: '02',
        coYear: '2025-2026',
        contextEpoch: '10',
        rights: { userUpdate: false, userDelete: false, userPrint: false },
      }),
    ]);
    expect(await sessionRow()).toMatchObject({
      login_co_code: '01',
      co_code: '02',
      lc_code: '02',
      co_year: '2025-2026',
      epoch: '10',
      from_epoch: '9',
      selection_id: operation,
      refresh_jti_hash: 'a'.repeat(64),
      revoked_at: null,
    });
    const after = await snapshot();
    for (const table of ['LOGIN_MAST', 'YEAR_MAST', 'LOCT_MAST', 'CO_MAST'])
      expect(after[table]).toEqual(before[table]);
    const dates = await owner.$queryRawUnsafe<Array<{ correct: boolean }>>(
      `SELECT "LOCK_DATE"=(current_date-1)::text AS correct FROM "CO_SET" WHERE "tenant_id"=$1 AND "CO_CODE"='02'`,
      tenant,
    );
    expect(dates).toEqual([{ correct: true }]);
  });

  it('rolls back both settings and the complete session when local signing fails after the lock update', async () => {
    const before = await snapshot();
    await expect(
      selectSessionContext(
        runtime,
        { identity: identity(), request: request() },
        {
          signAccess: async () => {
            throw new Error('signer-failed');
          },
        },
      ),
    ).rejects.toThrow('signer-failed');
    expect(await snapshot()).toEqual(before);
  });

  it('rejects stale bearer recovery; exact current-authority retry makes no writes and does not rerun last lock', async () => {
    const first = await selectSessionContext(
      runtime,
      { identity: identity(), request: request() },
      { signAccess: async () => 'first' },
    );
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LAST_DAY_LOCK"='INVALID' WHERE "tenant_id"=$1 AND "CO_CODE"='02'`,
      tenant,
    );
    const before = await snapshot();
    await expect(
      selectSessionContext(
        runtime,
        { identity: identity(), request: request() },
        { signAccess: async () => 'forbidden' },
      ),
    ).rejects.toMatchObject({ code: 'session-invalid' });
    const retry = await selectSessionContext(
      runtime,
      { identity: identity(first.session), request: request() },
      { signAccess: async () => 'recovered' },
    );
    expect(retry).toMatchObject({ accessToken: 'recovered', replayed: true, lastDayLock: null });
    expect(await snapshot()).toEqual(before);
  });

  it('rejects changed-body reuse of the current operation ID without writes', async () => {
    const first = await selectSessionContext(
      runtime,
      { identity: identity(), request: request() },
      { signAccess: async () => 'first' },
    );
    const before = await snapshot();
    await expect(
      selectSessionContext(
        runtime,
        { identity: identity(first.session), request: request({ lcCode: '02' }) },
        { signAccess: async () => 'forbidden' },
      ),
    ).rejects.toMatchObject({ code: 'context-operation-conflict' });
    expect(await snapshot()).toEqual(before);
  });

  it('a fresh same-scope open advances exactly once and retains the immutable login identity', async () => {
    const result = await selectSessionContext(
      runtime,
      {
        identity: identity(),
        request: request({ coCode: '01', lcCode: '01', coYear: '2024-2025' }),
      },
      { signAccess: async () => 'same-scope' },
    );
    expect(result.session).toMatchObject({ coCode: '01', contextEpoch: '10', loginCoCode: '01' });
    expect(await sessionRow()).toMatchObject({
      epoch: '10',
      from_epoch: '9',
      selection_id: operation,
    });
  });

  it('opens a complete scope from a legitimate no-year session with own undefined identity year', async () => {
    await owner.$executeRawUnsafe(
      `UPDATE "auth_session" SET "co_year"=NULL,"ledger_context"=jsonb_set("ledger_context",'{reason}','"scope-incomplete"') WHERE "tenant_id"=$1`,
      tenant,
    );
    const result = await selectSessionContext(
      runtime,
      { identity: { ...identity(), coYear: undefined }, request: request() },
      { signAccess: async () => 'completed-scope' },
    );
    expect(result.session).toMatchObject({
      coCode: '02',
      coYear: '2025-2026',
      contextEpoch: '10',
      loginCoCode: '01',
    });
    expect(await sessionRow()).toMatchObject({ epoch: '10', refresh_jti_hash: 'a'.repeat(64) });
  });

  it.each(['target-reset', 'invalid-setting', 'missing-year'] as const)(
    'refuses %s without changing any captured row',
    async (fault) => {
      if (fault === 'target-reset')
        await owner.$executeRawUnsafe(
          `UPDATE "LOGIN_MAST" SET "PASSWORD_RESET_REQUIRED"='Y' WHERE "tenant_id"=$1 AND "CO_CODE"='02'`,
          tenant,
        );
      if (fault === 'invalid-setting')
        await owner.$executeRawUnsafe(
          `UPDATE "CO_SET" SET "LAST_DAY_LOCK"='INVALID' WHERE "tenant_id"=$1 AND "CO_CODE"='02'`,
          tenant,
        );
      if (fault === 'missing-year')
        await owner.$executeRawUnsafe(
          `DELETE FROM "YEAR_MAST" WHERE "tenant_id"=$1 AND "CO_CODE"='02'`,
          tenant,
        );
      const before = await snapshot();
      let signed = false;
      await expect(
        selectSessionContext(
          runtime,
          { identity: identity(), request: request() },
          {
            signAccess: async () => {
              signed = true;
              return 'forbidden';
            },
          },
        ),
      ).rejects.toThrow();
      expect(signed).toBe(false);
      expect(await snapshot()).toEqual(before);
    },
  );

  it('preserves BIGINT generations beyond Number precision', async () => {
    await owner.$executeRawUnsafe(
      `UPDATE "auth_session" SET "context_epoch"=9007199254740993 WHERE "tenant_id"=$1`,
      tenant,
    );
    const result = await selectSessionContext(
      runtime,
      {
        identity: { ...identity(), contextEpoch: '9007199254740993' },
        request: request({ expectedContextEpoch: '9007199254740993' }),
      },
      { signAccess: async () => 'exact' },
    );
    expect(result.session.contextEpoch).toBe('9007199254740994');
    expect(await sessionRow()).toMatchObject({
      epoch: '9007199254740994',
      from_epoch: '9007199254740993',
    });
  });

  it('A to B to A does not revive an old bearer or an older receipt', async () => {
    const first = await selectSessionContext(
      runtime,
      { identity: identity(), request: request() },
      { signAccess: async () => 'B' },
    );
    const second = await selectSessionContext(
      runtime,
      {
        identity: identity(first.session),
        request: request({
          coCode: '01',
          expectedContextEpoch: '10',
          selectionId: '33333333-3333-4333-8333-333333333333',
        }),
      },
      { signAccess: async () => 'A-again' },
    );
    expect(second.session).toMatchObject({
      coCode: '01',
      lcCode: '01',
      coYear: '2024-2025',
      contextEpoch: '11',
    });
    const before = await snapshot();
    await expect(
      selectSessionContext(
        runtime,
        { identity: identity(), request: request() },
        { signAccess: async () => 'forbidden' },
      ),
    ).rejects.toMatchObject({ code: 'session-invalid' });
    await expect(
      selectSessionContext(
        runtime,
        { identity: identity(second.session), request: request() },
        { signAccess: async () => 'forbidden' },
      ),
    ).rejects.toMatchObject({ code: 'context-stale' });
    expect(await snapshot()).toEqual(before);
  });

  it('exact receipt recovery refuses a deleted stored year without choosing a replacement', async () => {
    const first = await selectSessionContext(
      runtime,
      { identity: identity(), request: request() },
      { signAccess: async () => 'B' },
    );
    await owner.$executeRawUnsafe(
      `UPDATE "YEAR_MAST" SET "CO_YEAR"='2026-2027' WHERE "tenant_id"=$1 AND "CO_CODE"='02'`,
      tenant,
    );
    const before = await snapshot();
    await expect(
      selectSessionContext(
        runtime,
        { identity: identity(first.session), request: request() },
        { signAccess: async () => 'forbidden' },
      ),
    ).rejects.toMatchObject({ code: 'year-unavailable' });
    expect(await snapshot()).toEqual(before);
  });

  it('serializes two same-ID selections: stale waiting authority cannot recover the winner', async () => {
    const entered = barrier();
    const finish = barrier();
    const first = selectSessionContext(
      runtime,
      { identity: identity(), request: request() },
      {
        signAccess: async () => {
          entered.release();
          await finish.promise;
          return 'winner';
        },
      },
    );
    await entered.promise;
    const second = selectSessionContext(
      runtime,
      { identity: identity(), request: request() },
      { signAccess: async () => 'not-authorized' },
    ).then(
      (value) => ({ value, error: undefined }),
      (error: unknown) => ({ value: undefined, error }),
    );
    try {
      await waitForRuntimeLock();
    } finally {
      finish.release();
    }
    const winner = await first;
    const loser = await second;
    expect(loser.value).toBeUndefined();
    expect(loser.error).toMatchObject({ code: 'context-transaction-conflict' });
    expect(await sessionRow()).toMatchObject({ epoch: '10', from_epoch: '9' });
    const retry = await selectSessionContext(
      runtime,
      { identity: identity(winner.session), request: request() },
      { signAccess: async () => 'recovered' },
    );
    expect(retry.replayed).toBe(true);
    expect(await sessionRow()).toMatchObject({ epoch: '10' });
  });

  it('rolls back tentative last-lock changes when signing crosses absolute expiry', async () => {
    await owner.$executeRawUnsafe(
      `UPDATE "auth_session" SET "expires_at"=clock_timestamp()+interval '2 seconds' WHERE "tenant_id"=$1`,
      tenant,
    );
    const before = await snapshot();
    let signed = false;
    await expect(
      selectSessionContext(
        runtime,
        { identity: identity(), request: request() },
        {
          signAccess: async () => {
            signed = true;
            await new Promise((resolve) => setTimeout(resolve, 2150));
            return 'expired-before-commit';
          },
        },
      ),
    ).rejects.toMatchObject({ code: 'session-expired' });
    expect(signed).toBe(true);
    expect(await snapshot()).toEqual(before);
  });

  it('checks fresh expiry after a real session-row lock wait', async () => {
    await owner.$executeRawUnsafe(
      `UPDATE "auth_session" SET "expires_at"=clock_timestamp()+interval '2 seconds' WHERE "tenant_id"=$1`,
      tenant,
    );
    const before = await snapshot();
    const held = barrier();
    const finish = barrier();
    const blocker = owner.$transaction(async (tx) => {
      await tx.$queryRawUnsafe(
        `SELECT "session_id" FROM "auth_session" WHERE "tenant_id"=$1 FOR UPDATE`,
        tenant,
      );
      held.release();
      await finish.promise;
    });
    await held.promise;
    let signed = false;
    const pending = selectSessionContext(
      runtime,
      { identity: identity(), request: request() },
      {
        signAccess: async () => {
          signed = true;
          return 'forbidden';
        },
      },
    ).catch((error: unknown) => error);
    try {
      await waitForRuntimeLock();
      await new Promise((resolve) => setTimeout(resolve, 2150));
    } finally {
      finish.release();
    }
    await blocker;
    expect(await pending).toMatchObject({ code: 'session-expired' });
    expect(signed).toBe(false);
    expect(await snapshot()).toEqual(before);
  });
});
