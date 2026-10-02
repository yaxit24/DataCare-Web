import { createHash, randomUUID } from 'node:crypto';
import { PrismaClient } from '@datacare/db';
import type { Tx } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it, vi } from 'vitest';
import {
  withSessionContextSerializableCommand,
  type SessionSerializableCommandIdentity,
  type SessionSerializableCommandPolicy,
} from '../src/modules/auth/sessionContextSerializableCommand.js';
import { selectSessionContext } from '../src/modules/auth/sessionContextSelection.js';
import { refreshSessionContext } from '../src/modules/auth/sessionContextRefresh.js';
import { revokeSession } from '../src/modules/auth/session.js';
import { resetUserPassword } from '../src/modules/auth/passwordAccount.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const db = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenantId = 'serial-command-db';
const foreignTenant = 'serial-command-foreign';
const sid = '11111111-1111-4111-8111-111111111111';
const operation = '22222222-2222-4222-8222-222222222222';
const oldJti = 'literal-old-refresh';
const ledger = {
  version: 'server-session-ledger-context-v1',
  status: 'unknown',
  mode: null,
  reason: 'vendor-authority-unresolved',
};
const identity: SessionSerializableCommandIdentity = {
  tenantId,
  sessionId: sid,
  loginName: 'operator',
  loginCoCode: '01',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  contextEpoch: '7',
};
const policy: SessionSerializableCommandPolicy = {
  scope: {
    tenantId,
    coCode: '01',
    lcCode: '01',
    coYear: '2024-2025',
    coBook: 'R13',
  },
};
function barrier() {
  let release!: () => void;
  const promise = new Promise<void>((resolve) => {
    release = resolve;
  });
  return { promise, release };
}
const settled = <T>(promise: Promise<T>) =>
  promise.then(
    (value) => ({ value, error: undefined }),
    (error: unknown) => ({ value: undefined, error }),
  );

/** Do not wait forever if the operation fails before reaching its test barrier. */
const waitForGate = <T>(
  gate: Promise<void>,
  operation: Promise<{ value: T | undefined; error: unknown }>,
): Promise<void> =>
  Promise.race([
    gate,
    operation.then((outcome) => {
      throw outcome.error ?? new Error('Operation completed before the expected test barrier');
    }),
  ]);

/** Real Serializable snapshots, callback DML rollback and SSI schedules. Marker writes are synthetic transaction proof, not Return financial acceptance; no route is added. */
db('Serializable Return command schedules on isolated PostgreSQL', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let actor: PrismaClient;
  const readName = `read-${randomUUID()}`;
  const actorName = `read-actor-${randomUUID()}`;
  const tables = [
    'auth_session',
    'AC_MAST',
    'USER_SET',
    'LOGIN_MAST',
    'BOOK_DATA',
    'CO_SET',
    'YEAR_MAST',
    'LOCT_MAST',
    'CO_MAST',
  ];
  const sql = (statement: string, ...values: unknown[]) =>
    owner.$executeRawUnsafe(statement, ...values);
  const clean = async () => {
    for (const table of tables)
      await sql(`DELETE FROM "${table}" WHERE tenant_id IN ($1,$2)`, tenantId, foreignTenant);
  };
  const snapshot = async (only = tables) => {
    const out: Record<string, unknown> = {};
    for (const table of only)
      out[table] = await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t)::text AS raw,t.xmin::text AS revision,t.ctid::text AS locator
       FROM "${table}" t WHERE tenant_id IN ($1,$2) ORDER BY to_jsonb(t)::text`,
        tenantId,
        foreignTenant,
      );
    return out;
  };
  const session = async () =>
    (
      await owner.$queryRawUnsafe<
        Array<{
          epoch: string;
          company: string;
          revoked: string | null;
          reason: string | null;
          refresh: string;
          ledger: unknown;
        }>
      >(
        `SELECT context_epoch::text AS epoch,co_code AS company,revoked_at::text AS revoked,revoke_reason AS reason,refresh_jti_hash AS refresh,ledger_context AS ledger
      FROM auth_session WHERE tenant_id=$1 AND session_id=$2`,
        tenantId,
        sid,
      )
    )[0]!;
  const readMarker = async (tx: Tx) =>
    (
      await tx.$queryRawUnsafe<Array<{ name: string }>>(
        `SELECT "AC_NAME" AS name FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"='PARTY'`,
        tenantId,
      )
    )[0]!.name;
  const writeMarker = (tx: Tx, name: string, code = 'PARTY') =>
    tx.$executeRawUnsafe(
      `UPDATE "AC_MAST" SET "AC_NAME"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"=$3`,
      tenantId,
      name,
      code,
    );
  const marker = async () =>
    (
      await owner.$queryRawUnsafe<Array<{ name: string }>>(
        `SELECT "AC_NAME" AS name FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"='PARTY'`,
        tenantId,
      )
    )[0]!.name;
  const waitForLock = async (applicationName: string) => {
    const deadline = Date.now() + 3000;
    while (Date.now() < deadline) {
      const rows = await owner.$queryRawUnsafe<Array<{ waiting: boolean }>>(
        `SELECT EXISTS(SELECT 1 FROM pg_stat_activity WHERE application_name=$1 AND wait_event_type='Lock') AS waiting`,
        applicationName,
      );
      if (rows[0]?.waiting) return;
      await new Promise((resolve) => setTimeout(resolve, 10));
    }
    throw new Error(`Expected real database lock wait: ${applicationName}`);
  };
  const select = (signAccess = async () => 'local-selection-token') =>
    selectSessionContext(
      actor,
      {
        identity,
        request: {
          coCode: '02',
          lcCode: '01',
          coYear: '2024-2025',
          expectedContextEpoch: '7',
          selectionId: operation,
        },
      },
      { signAccess },
    );
  const refresh = (jti = oldJti) =>
    refreshSessionContext(
      actor,
      { tenantId, sid, sub: 'operator', jti, typ: 'refresh' },
      {
        newRefreshJti: () => 'literal-next-refresh',
        issueTokens: async () => ({
          accessToken: 'local-access',
          refreshToken: 'local-refresh',
        }),
      },
    );
  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({
      datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
    });
    const readUrl = new URL(process.env.DATABASE_URL!);
    readUrl.searchParams.set('application_name', readName);
    const actorUrl = new URL(process.env.DATABASE_URL!);
    actorUrl.searchParams.set('application_name', actorName);
    runtime = new PrismaClient({
      datasources: { db: { url: readUrl.toString() } },
    });
    actor = new PrismaClient({
      datasources: { db: { url: actorUrl.toString() } },
    });
  });
  beforeEach(async () => {
    await clean();
    await sql(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","LC_CODE") VALUES($1,'01','01'),($1,'02','01')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE") VALUES($1,'01','01'),($1,'02','01')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR") VALUES($1,'01','2024-2025'),($1,'02','2024-2025')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LAST_DAY_LOCK","LOCK_DATE") VALUES($1,'01','N',''),($1,'02','N','')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","CUR_USE") VALUES($1,'01','01','R13','SALES RETURNE','Y')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","PASSWORD_RESET_REQUIRED") VALUES($1,'01','operator','fixture','USER','N'),($1,'02','operator','fixture','USER','N')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT") VALUES($1,'01','01','operator','Sales','Sales Return','Y','Y')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES($1,'01','01','PARTY','before-command'),($2,'01','01','PARTY','foreign-sentinel')`,
      tenantId,
      foreignTenant,
    );
    for (const tenant of [tenantId, foreignTenant])
      await sql(
        `INSERT INTO auth_session(tenant_id,session_id,login_name,login_co_code,co_code,lc_code,co_year,refresh_jti_hash,created_at,last_used_at,expires_at,context_epoch,ledger_context)
      VALUES($1,$2,'operator','01','01','01','2024-2025',$3,'2020-01-01 00:00:00.123456+00','2020-01-01 00:00:00.123456+00',clock_timestamp()+interval '1 hour',7,$4::jsonb)`,
        tenant,
        sid,
        createHash('sha256').update(oldJti).digest('hex'),
        JSON.stringify(ledger),
      );
  });
  afterAll(async () => {
    if (owner) await clean();
    if (runtime) await runtime.$disconnect();
    if (actor) await actor.$disconnect();
    if (owner) await owner.$disconnect();
  });

  const waitForExpiry = async () => {
    const deadline = Date.now() + 2500;
    while (Date.now() < deadline) {
      const rows = await owner.$queryRawUnsafe<Array<{ expired: boolean }>>(
        `SELECT expires_at<=clock_timestamp() AS expired FROM auth_session WHERE tenant_id=$1 AND session_id=$2`,
        tenantId,
        sid,
      );
      if (rows[0]?.expired) return;
      await new Promise((resolve) => setTimeout(resolve, 10));
    }
    throw new Error('Expected natural session expiry');
  };
  it('D01 admits fixed Return update authority and preserves all scoped raw rows/xmin/ctid', async () => {
    const before = await snapshot();
    expect(
      await withSessionContextSerializableCommand(
        runtime,
        identity,
        policy,
        async (tx, admitted) => {
          expect(admitted.authorization.action).toBe('update');
          expect(admitted.context.contextEpoch).toBe('7');
          expect(admitted.context.ledgerContext).toEqual(ledger);
          const settings = await tx.$queryRawUnsafe<Array<{ isolation: string; readonly: string }>>(
            `SELECT current_setting('transaction_isolation') AS isolation,current_setting('transaction_read_only') AS readonly`,
          );
          expect(settings).toEqual([{ isolation: 'serializable', readonly: 'off' }]);
          return readMarker(tx);
        },
      ),
    ).toBe('before-command');
    expect(await snapshot()).toEqual(before);
  });
  it('D02 SHARE winner holds selection until read commit without undoing either outcome', async () => {
    const beforeBusiness = await snapshot(
      tables.filter((name) => !['auth_session', 'AC_MAST'].includes(name)),
    );
    const entered = barrier(),
      release = barrier();
    const read = settled(
      withSessionContextSerializableCommand(runtime, identity, policy, async (tx, admitted) => {
        expect(admitted.context.contextEpoch).toBe('7');
        await writeMarker(tx, 'command-committed');
        entered.release();
        await release.promise;
        return readMarker(tx);
      }),
    );
    let selection: ReturnType<typeof settled<Awaited<ReturnType<typeof select>>>> | undefined;
    try {
      await waitForGate(entered.promise, read);
      selection = settled(select());
      await waitForGate(waitForLock(actorName), selection);
      expect((await session()).epoch).toBe('7');
      release.release();
      expect((await read).value).toBe('command-committed');
      expect(await marker()).toBe('command-committed');
      expect((await selection).value?.session).toMatchObject({
        coCode: '02',
        contextEpoch: '8',
      });
      expect(
        await snapshot(tables.filter((name) => !['auth_session', 'AC_MAST'].includes(name))),
      ).toEqual(beforeBusiness);
    } finally {
      release.release();
      await read;
      if (selection) await selection;
    }
  });
  it('D03 selection UPDATE winner causes Serializable serialization refusal before callback, without replay', async () => {
    const signing = barrier(),
      release = barrier();
    const selection = settled(
      select(async () => {
        signing.release();
        await release.promise;
        return 'local-token';
      }),
    );
    let read: ReturnType<typeof settled<string>> | undefined;
    const work = vi.fn(readMarker);
    try {
      await waitForGate(signing.promise, selection);
      read = settled(withSessionContextSerializableCommand(runtime, identity, policy, work));
      await waitForGate(waitForLock(readName), read);
      release.release();
      expect((await selection).error).toBeUndefined();
      expect((await read).error).toMatchObject({
        code: 'session-command-conflict',
        statusCode: 409,
      });
      expect(work).not.toHaveBeenCalled();
      expect(await marker()).toBe('before-command');
      expect((await session()).epoch).toBe('8');
    } finally {
      release.release();
      await selection;
      if (read) await read;
    }
  });
  it('D04 clock is sampled after a real lock wait even when the MVCC row itself never changed', async () => {
    await sql(
      `UPDATE auth_session SET expires_at=clock_timestamp()+interval '500 milliseconds' WHERE tenant_id=$1 AND session_id=$2`,
      tenantId,
      sid,
    );
    const before = await snapshot();
    const entered = barrier(),
      release = barrier();
    const holder = settled(
      owner.$transaction(async (tx) => {
        await tx.$queryRawUnsafe(
          `SELECT session_id FROM auth_session WHERE tenant_id=$1 AND session_id=$2 FOR UPDATE`,
          tenantId,
          sid,
        );
        entered.release();
        await release.promise;
      }),
    );
    let read: ReturnType<typeof settled<string>> | undefined;
    const work = vi.fn(readMarker);
    try {
      await waitForGate(entered.promise, holder);
      read = settled(withSessionContextSerializableCommand(runtime, identity, policy, work));
      await waitForGate(waitForLock(readName), read);
      await waitForExpiry();
      release.release();
      expect((await holder).error).toBeUndefined();
      expect((await read).error).toMatchObject({ code: 'session-expired' });
      expect(work).not.toHaveBeenCalled();
      expect(await snapshot()).toEqual(before);
    } finally {
      release.release();
      await holder;
      if (read) await read;
    }
  });
  it('D05 all callback reads share the snapshot while an unrelated business actor commits', async () => {
    const before = await snapshot(tables.filter((name) => name !== 'AC_MAST'));
    expect(
      await withSessionContextSerializableCommand(runtime, identity, policy, async (tx) => {
        const first = await readMarker(tx);
        await sql(
          `UPDATE "AC_MAST" SET "AC_NAME"='actor-change' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"='PARTY'`,
          tenantId,
        );
        return [first, await readMarker(tx)];
      }),
    ).toEqual(['before-command', 'before-command']);
    expect(await marker()).toBe('actor-change');
    expect(await snapshot(tables.filter((name) => name !== 'AC_MAST'))).toEqual(before);
    expect(
      await owner.$queryRawUnsafe(
        `SELECT "AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1`,
        foreignTenant,
      ),
    ).toEqual([{ AC_NAME: 'foreign-sentinel' }]);
  });
  it.each([
    { id: 'D06', kind: 'refresh' },
    { id: 'D07', kind: 'logout' },
    { id: 'D08', kind: 'password-reset' },
  ] as const)(
    '$id $kind waits for SHARE; no LOGIN lock cycle is introduced by the read',
    async ({ kind }) => {
      const beforeBusiness = await snapshot(
        tables.filter((name) => !['auth_session', 'LOGIN_MAST'].includes(name)),
      );
      const entered = barrier(),
        release = barrier();
      const read = settled(
        withSessionContextSerializableCommand(runtime, identity, policy, async (tx, admitted) => {
          expect(admitted.context.contextEpoch).toBe('7');
          entered.release();
          await release.promise;
          return readMarker(tx);
        }),
      );
      let operationPromise: Promise<{ value: unknown; error: unknown }> | undefined;
      try {
        await waitForGate(entered.promise, read);
        const operation: Promise<unknown> =
          kind === 'refresh'
            ? refresh()
            : kind === 'logout'
              ? revokeSession(actor, tenantId, sid, 'logout')
              : resetUserPassword(actor, {
                  tenantId,
                  coCode: '01',
                  loginName: 'operator',
                  newPassword: 'Read-Reset!2026',
                });
        operationPromise = settled(operation);
        await waitForGate(waitForLock(actorName), operationPromise);
        release.release();
        expect((await read).value).toBe('before-command');
        expect((await operationPromise).error).toBeUndefined();
        const final = await session();
        expect(final.epoch).toBe('7');
        expect(final.ledger).toEqual(ledger);
        if (kind === 'refresh') {
          expect(final.revoked).toBeNull();
          expect(final.refresh).toBe(
            createHash('sha256').update('literal-next-refresh').digest('hex'),
          );
        } else {
          expect(final.revoked).not.toBeNull();
          expect(final.reason).toBe(kind === 'logout' ? 'logout' : 'password-reset');
        }
        expect(
          await snapshot(tables.filter((name) => !['auth_session', 'LOGIN_MAST'].includes(name))),
        ).toEqual(beforeBusiness);
      } finally {
        release.release();
        await read;
        if (operationPromise) await operationPromise;
      }
    },
  );
  it('D09 final SQL clock refuses a naturally expired session after callback reads', async () => {
    await sql(
      `UPDATE auth_session SET expires_at=clock_timestamp()+interval '500 milliseconds' WHERE tenant_id=$1 AND session_id=$2`,
      tenantId,
      sid,
    );
    const before = await snapshot();
    const work = vi.fn(async (tx: Tx) => {
      await writeMarker(tx, 'must-rollback-on-expiry');
      const value = await readMarker(tx);
      await waitForExpiry();
      return value;
    });
    await expect(
      withSessionContextSerializableCommand(runtime, identity, policy, work),
    ).rejects.toMatchObject({ code: 'session-expired' });
    expect(work).toHaveBeenCalledTimes(1);
    expect(await snapshot()).toEqual(before);
  });
  it('D10 selected credential company differs from immutable login company without session mutation', async () => {
    await sql(
      `UPDATE auth_session SET co_code='02' WHERE tenant_id=$1 AND session_id=$2`,
      tenantId,
      sid,
    );
    const before = await snapshot();
    await withSessionContextSerializableCommand(
      runtime,
      { ...identity, coCode: '02' },
      { ...policy, scope: { ...policy.scope, coCode: '02' } },
      async (_tx, admitted) => {
        expect(admitted.context.loginCoCode).toBe('01');
        expect(admitted.principal.loginCoCode).toBe('02');
        expect(admitted.context.contextEpoch).toBe('7');
      },
    );
    expect(await snapshot()).toEqual(before);
  });
  it('D11 committed Edit revocation refuses before callback despite retained identity', async () => {
    await sql(`UPDATE "USER_SET" SET "FRM_VIEW"='Y',"FRM_EDIT"='N' WHERE tenant_id=$1`, tenantId);
    const before = await snapshot();
    const work = vi.fn(readMarker);
    await expect(
      withSessionContextSerializableCommand(runtime, identity, policy, work),
    ).rejects.toMatchObject({
      code: 'forbidden',
      statusCode: 403,
      action: 'update',
    });
    expect(work).not.toHaveBeenCalled();
    expect(await snapshot()).toEqual(before);
  });
  it('D12 rights are as of the snapshot; a later Edit change affects the next command', async () => {
    const before = await snapshot(tables.filter((name) => name !== 'USER_SET'));
    expect(
      await withSessionContextSerializableCommand(runtime, identity, policy, async (tx) => {
        await sql(`UPDATE "USER_SET" SET "FRM_EDIT"='N' WHERE tenant_id=$1`, tenantId);
        expect(
          await tx.$queryRawUnsafe(
            `SELECT "FRM_EDIT" FROM "USER_SET" WHERE tenant_id=$1`,
            tenantId,
          ),
        ).toEqual([{ FRM_EDIT: 'Y' }]);
        return readMarker(tx);
      }),
    ).toBe('before-command');
    await expect(
      withSessionContextSerializableCommand(runtime, identity, policy, readMarker),
    ).rejects.toMatchObject({ code: 'forbidden' });
    expect(await snapshot(tables.filter((name) => name !== 'USER_SET'))).toEqual(before);
  });
  it('D13 callback marker DML is rolled back with its injected failure', async () => {
    const before = await snapshot();
    const failure = new Error('injected-callback-failure');
    await expect(
      withSessionContextSerializableCommand(runtime, identity, policy, async (tx) => {
        await tx.$executeRawUnsafe(
          `UPDATE "AC_MAST" SET "AC_NAME"='must-rollback' WHERE tenant_id=$1`,
          tenantId,
        );
        throw failure;
      }),
    ).rejects.toBe(failure);
    expect(await snapshot()).toEqual(before);
  });
  it('D14 final full-context check contains a controlled same-Tx epoch mutation', async () => {
    const before = await snapshot();
    await expect(
      withSessionContextSerializableCommand(runtime, identity, policy, async (tx) => {
        await writeMarker(tx, 'must-rollback-with-epoch');
        await tx.$executeRawUnsafe(
          `UPDATE auth_session SET context_epoch=8 WHERE tenant_id=$1 AND session_id=$2`,
          tenantId,
          sid,
        );
        return readMarker(tx);
      }),
    ).rejects.toMatchObject({ code: 'context-stale' });
    expect(await snapshot()).toEqual(before);
  });
  it('D15 real SSI write-skew cycle commits exactly one command and never retries either callback', async () => {
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES($1,'01','01','PEER','before-peer')`,
      tenantId,
    );
    const beforeStable = await snapshot(tables.filter((name) => name !== 'AC_MAST'));
    const enteredA = barrier(),
      enteredB = barrier(),
      release = barrier();
    const makeWork = (code: string, entered: ReturnType<typeof barrier>) =>
      vi.fn(async (tx: Tx) => {
        const rows = await tx.$queryRawUnsafe<Array<{ code: string; name: string }>>(
          `SELECT "AC_CODE" AS code,"AC_NAME" AS name FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE" IN ('PARTY','PEER') ORDER BY "AC_CODE"`,
          tenantId,
        );
        expect(rows).toEqual([
          { code: 'PARTY', name: 'before-command' },
          { code: 'PEER', name: 'before-peer' },
        ]);
        entered.release();
        await release.promise;
        expect(await writeMarker(tx, `winner-${code}`, code)).toBe(1);
        return code;
      });
    const workA = makeWork('PARTY', enteredA),
      workB = makeWork('PEER', enteredB);
    const a = settled(withSessionContextSerializableCommand(runtime, identity, policy, workA));
    const b = settled(withSessionContextSerializableCommand(runtime, identity, policy, workB));
    try {
      await Promise.all([waitForGate(enteredA.promise, a), waitForGate(enteredB.promise, b)]);
      release.release();
      const outcomes = await Promise.all([a, b]);
      expect(outcomes.filter((entry) => entry.error === undefined)).toHaveLength(1);
      expect(outcomes.find((entry) => entry.error !== undefined)?.error).toMatchObject({
        code: 'session-command-conflict',
        statusCode: 409,
      });
      expect(workA).toHaveBeenCalledTimes(1);
      expect(workB).toHaveBeenCalledTimes(1);
      const winner = outcomes.find((entry) => entry.error === undefined)!.value;
      expect(
        await owner.$queryRawUnsafe(
          `SELECT "AC_CODE" AS code,"AC_NAME" AS name FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' ORDER BY "AC_CODE"`,
          tenantId,
        ),
      ).toEqual([
        {
          code: 'PARTY',
          name: winner === 'PARTY' ? 'winner-PARTY' : 'before-command',
        },
        {
          code: 'PEER',
          name: winner === 'PEER' ? 'winner-PEER' : 'before-peer',
        },
      ]);
      expect(await snapshot(tables.filter((name) => name !== 'AC_MAST'))).toEqual(beforeStable);
      expect(
        await owner.$queryRawUnsafe(
          `SELECT "AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1`,
          foreignTenant,
        ),
      ).toEqual([{ AC_NAME: 'foreign-sentinel' }]);
    } finally {
      release.release();
      await Promise.all([a, b]);
    }
  });
  it('D16 real concurrent same-row change is preserved while the stale snapshot update refuses409', async () => {
    const beforeStable = await snapshot(tables.filter((name) => name !== 'AC_MAST'));
    const work = vi.fn(async (tx: Tx) => {
      expect(await readMarker(tx)).toBe('before-command');
      await sql(
        `UPDATE "AC_MAST" SET "AC_NAME"='external-winner' WHERE tenant_id=$1 AND "AC_CODE"='PARTY'`,
        tenantId,
      );
      await writeMarker(tx, 'stale-must-not-commit');
      return 'unexpected';
    });
    await expect(
      withSessionContextSerializableCommand(runtime, identity, policy, work),
    ).rejects.toMatchObject({
      code: 'session-command-conflict',
      statusCode: 409,
    });
    expect(work).toHaveBeenCalledTimes(1);
    expect(await marker()).toBe('external-winner');
    expect(await snapshot(tables.filter((name) => name !== 'AC_MAST'))).toEqual(beforeStable);
    expect(
      await owner.$queryRawUnsafe(
        `SELECT "AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1`,
        foreignTenant,
      ),
    ).toEqual([{ AC_NAME: 'foreign-sentinel' }]);
  });
  it('D17 final ledger check rolls back prohibited same-Tx authority mutation and marker DML', async () => {
    const before = await snapshot();
    await expect(
      withSessionContextSerializableCommand(runtime, identity, policy, async (tx) => {
        await writeMarker(tx, 'must-rollback');
        await tx.$executeRawUnsafe(
          `UPDATE auth_session SET ledger_context=$3::jsonb WHERE tenant_id=$1 AND session_id=$2`,
          tenantId,
          sid,
          JSON.stringify({
            ...ledger,
            reason: 'legacy-session-uninitialized',
          }),
        );
        return 'discarded';
      }),
    ).rejects.toMatchObject({ code: 'context-stale', statusCode: 409 });
    expect(await snapshot()).toEqual(before);
  });
});
