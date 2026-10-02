import { createHash, randomUUID } from 'node:crypto';
import { PrismaClient } from '@datacare/db';
import type { Tx } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it, vi } from 'vitest';
import {
  withSessionContextCommand,
  type SessionCommandIdentity,
  type SessionCommandPolicy,
} from '../src/modules/auth/sessionContextCommand.js';
import { selectSessionContext } from '../src/modules/auth/sessionContextSelection.js';
import { refreshSessionContext } from '../src/modules/auth/sessionContextRefresh.js';
import { revokeSession } from '../src/modules/auth/session.js';
import { resetUserPassword } from '../src/modules/auth/passwordAccount.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const db = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenantId = 'command-lock-db';
const foreignTenant = 'command-lock-foreign';
const sid = '11111111-1111-4111-8111-111111111111';
const operation = '22222222-2222-4222-8222-222222222222';
const oldJti = 'literal-old-refresh';
const ledger = {
  version: 'server-session-ledger-context-v1',
  status: 'unknown',
  mode: null,
  reason: 'vendor-authority-unresolved',
};
const identity: SessionCommandIdentity = {
  tenantId,
  sessionId: sid,
  loginName: 'operator',
  loginCoCode: '01',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  contextEpoch: '7',
};
const policy: SessionCommandPolicy = {
  form: 'Sales/Sales Order',
  action: 'update',
  scope: { tenantId, coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'C13' },
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

/** Real row locks and rollback on a small master sentinel. Financial/HTTP coverage is in the companion file. */
db('session command lock schedules on isolated PostgreSQL', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let actor: PrismaClient;
  const commandName = `command-${randomUUID()}`;
  const actorName = `command-actor-${randomUUID()}`;
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
  const mark = async (tx: Tx) => {
    expect(
      await tx.$executeRawUnsafe(
        `UPDATE "AC_MAST" SET "AC_NAME"='committed-command' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "AC_CODE"='PARTY'`,
        tenantId,
      ),
    ).toBe(1);
    return 'command-result';
  };
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
        issueTokens: async () => ({ accessToken: 'local-access', refreshToken: 'local-refresh' }),
      },
    );
  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    const commandUrl = new URL(process.env.DATABASE_URL!);
    commandUrl.searchParams.set('application_name', commandName);
    const actorUrl = new URL(process.env.DATABASE_URL!);
    actorUrl.searchParams.set('application_name', actorName);
    runtime = new PrismaClient({ datasources: { db: { url: commandUrl.toString() } } });
    actor = new PrismaClient({ datasources: { db: { url: actorUrl.toString() } } });
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
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","CUR_USE") VALUES($1,'01','01','C13','SALES ORDER','Y')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","PASSWORD_RESET_REQUIRED") VALUES($1,'01','operator','fixture','USER','N'),($1,'02','operator','fixture','USER','N')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT") VALUES($1,'01','01','operator','Sales','Sales Order','Y','Y')`,
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

  it('successful command changes its sentinel only, preserving both sessions/raw revision and foreign tenant', async () => {
    const before = await snapshot();
    expect(await withSessionContextCommand(runtime, identity, policy, mark)).toBe('command-result');
    expect(await marker()).toBe('committed-command');
    const after = await snapshot();
    for (const table of tables.filter((table) => table !== 'AC_MAST'))
      expect(after[table]).toEqual(before[table]);
    const foreign = await owner.$queryRawUnsafe<Array<{ name: string }>>(
      `SELECT "AC_NAME" AS name FROM "AC_MAST" WHERE tenant_id=$1`,
      foreignTenant,
    );
    expect(foreign).toEqual([{ name: 'foreign-sentinel' }]);
  });
  it('injected downstream failure rolls back the real business statement and leaves all raw snapshots unchanged', async () => {
    const before = await snapshot();
    const failure = new Error('injected-after-business-write');
    await expect(
      withSessionContextCommand(runtime, identity, policy, async (tx) => {
        await mark(tx);
        throw failure;
      }),
    ).rejects.toBe(failure);
    expect(await snapshot()).toEqual(before);
  });
  it.each(['epoch', 'ledger', 'expiry'] as const)(
    'final check aborts callback-local %s mutation with its business statement',
    async (kind) => {
      const before = await snapshot();
      await expect(
        withSessionContextCommand(runtime, identity, policy, async (tx) => {
          await mark(tx);
          if (kind === 'epoch')
            await tx.$executeRawUnsafe(
              `UPDATE auth_session SET context_epoch=8 WHERE tenant_id=$1 AND session_id=$2`,
              tenantId,
              sid,
            );
          if (kind === 'ledger')
            await tx.$executeRawUnsafe(
              `UPDATE auth_session SET ledger_context=jsonb_set(ledger_context,'{reason}','"legacy-session-uninitialized"'::jsonb) WHERE tenant_id=$1 AND session_id=$2`,
              tenantId,
              sid,
            );
          if (kind === 'expiry')
            await tx.$executeRawUnsafe(
              `UPDATE auth_session SET expires_at=clock_timestamp()-interval '1 microsecond' WHERE tenant_id=$1 AND session_id=$2`,
              tenantId,
              sid,
            );
        }),
      ).rejects.toMatchObject({ code: kind === 'expiry' ? 'session-expired' : 'context-stale' });
      // Deliberate same-Tx fault injection proves rollback; it is not a natural elapsed-time measurement.
      expect(await snapshot()).toEqual(before);
    },
  );
  it('samples expiry after an actual session-row lock wait, before invoking work', async () => {
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
    let command: ReturnType<typeof settled<string>> | undefined;
    const work = vi.fn(mark);
    try {
      await waitForGate(entered.promise, holder);
      command = settled(withSessionContextCommand(runtime, identity, policy, work));
      await waitForLock(commandName);
      const deadline = Date.now() + 2500;
      let expired = false;
      while (Date.now() < deadline) {
        const row = await owner.$queryRawUnsafe<Array<{ expired: boolean }>>(
          `SELECT expires_at<=clock_timestamp() AS expired FROM auth_session WHERE tenant_id=$1 AND session_id=$2`,
          tenantId,
          sid,
        );
        if (row[0]?.expired) {
          expired = true;
          break;
        }
        await new Promise((resolve) => setTimeout(resolve, 10));
      }
      expect(expired).toBe(true);
      release.release();
      expect((await holder).error).toBeUndefined();
      expect((await command).error).toMatchObject({ code: 'session-expired' });
      expect(work).not.toHaveBeenCalled();
      expect(await snapshot()).toEqual(before);
    } finally {
      release.release();
      await holder;
      if (command) await command;
    }
  });
  it('selection waits for a command SHARE lock then commits its epoch; the committed command is not undone', async () => {
    const entered = barrier(),
      release = barrier();
    const command = settled(
      withSessionContextCommand(runtime, identity, policy, async (tx) => {
        await mark(tx);
        entered.release();
        await release.promise;
        return 'done';
      }),
    );
    let selection: ReturnType<typeof settled<Awaited<ReturnType<typeof select>>>> | undefined;
    try {
      await waitForGate(entered.promise, command);
      selection = settled(select());
      await waitForLock(actorName);
      expect(await marker()).toBe('before-command');
      release.release();
      expect((await command).value).toBe('done');
      expect((await selection).value?.session).toMatchObject({ coCode: '02', contextEpoch: '8' });
      expect(await marker()).toBe('committed-command');
    } finally {
      release.release();
      await command;
      if (selection) await selection;
    }
  });
  it('selection winning its session lock makes an already-started old-context command refuse before work', async () => {
    const signing = barrier(),
      release = barrier();
    const selection = settled(
      select(async () => {
        signing.release();
        await release.promise;
        return 'local-token';
      }),
    );
    let command: ReturnType<typeof settled<string>> | undefined;
    const work = vi.fn(mark);
    try {
      await waitForGate(signing.promise, selection);
      command = settled(withSessionContextCommand(runtime, identity, policy, work));
      await waitForLock(commandName);
      release.release();
      expect((await selection).error).toBeUndefined();
      expect((await command).error).toMatchObject({ code: 'context-stale' });
      expect(work).not.toHaveBeenCalled();
      expect(await marker()).toBe('before-command');
    } finally {
      release.release();
      await selection;
      if (command) await command;
    }
  });
  it.each(['refresh', 'logout', 'password-reset'] as const)(
    '%s waits for command; its own semantics are preserved afterward',
    async (kind) => {
      const entered = barrier(),
        release = barrier();
      const command = settled(
        withSessionContextCommand(runtime, identity, policy, async (tx) => {
          await mark(tx);
          entered.release();
          await release.promise;
          return 'done';
        }),
      );
      let operationPromise: Promise<{ value: unknown; error: unknown }> | undefined;
      try {
        await waitForGate(entered.promise, command);
        const actorOperation: Promise<unknown> =
          kind === 'refresh'
            ? refresh()
            : kind === 'logout'
              ? revokeSession(actor, tenantId, sid, 'logout')
              : resetUserPassword(actor, {
                  tenantId,
                  coCode: '01',
                  loginName: 'operator',
                  newPassword: 'Command-Reset!2026',
                });
        operationPromise = settled(actorOperation);
        await waitForLock(actorName);
        release.release();
        expect((await command).error).toBeUndefined();
        expect((await operationPromise).error).toBeUndefined();
        expect(await marker()).toBe('committed-command');
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
      } finally {
        release.release();
        await command;
        if (operationPromise) await operationPromise;
      }
    },
  );
  it('strict refresh reuse commits revocation before the later command is refused', async () => {
    await refresh();
    await expect(refresh(oldJti)).rejects.toMatchObject({ code: 'refresh-reused' });
    const before = await snapshot();
    const work = vi.fn(mark);
    await expect(withSessionContextCommand(runtime, identity, policy, work)).rejects.toMatchObject({
      code: 'session-revoked',
    });
    expect(work).not.toHaveBeenCalled();
    expect((await session()).reason).toBe('refresh-reuse');
    expect(await snapshot()).toEqual(before);
  });
  it('committed current form removal refuses despite a previously retained request identity', async () => {
    await sql(`UPDATE "USER_SET" SET "FRM_EDIT"='N' WHERE tenant_id=$1`, tenantId);
    const before = await snapshot();
    const work = vi.fn(mark);
    await expect(withSessionContextCommand(runtime, identity, policy, work)).rejects.toMatchObject({
      code: 'forbidden',
      statusCode: 403,
    });
    expect(work).not.toHaveBeenCalled();
    expect(await snapshot()).toEqual(before);
  });
});
