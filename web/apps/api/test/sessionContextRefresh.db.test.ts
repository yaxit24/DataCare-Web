import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { PrismaClient } from '@prisma/client';
import { withTenant, type Tx } from '@datacare/db';
import { afterAll, afterEach, beforeAll, beforeEach, describe, expect, it, vi } from 'vitest';
import {
  refreshSessionContext,
  type RefreshContextDependencies,
} from '../src/modules/auth/sessionContextRefresh.js';
import type { RefreshClaims } from '../src/modules/auth/jwt.js';
import { revokeSession } from '../src/modules/auth/session.js';
import type { Principal } from '../src/modules/rbac/authorization.js';
import independent from './fixtures/sessionContextRefresh.independent.json';
import qualifications from './fixtures/sessionContextRefresh.qualifications.json';

// These are real PostgreSQL tests. Only local signer/clock dependencies and statement scheduling
// are controlled. Every authority SELECT and mutation executes against the installed schema/RLS.
const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenantId = 'context-refresh-db';
const foreignTenant = 'context-refresh-other';
const tenants = [tenantId, foreignTenant];
const sid = '11111111-1111-4111-8111-111111111111';
const currentJti = independent.trustedFixtureJtis.current;
const nextJti = independent.trustedFixtureJtis.next;
const time = '2026-09-03T12:00:00.000Z';
type Row = Record<string, unknown>;
type Raw = Record<string, string | null>;
type Snapshot = { raw: Raw; revision: string; locator: string };
type Case = {
  id: string;
  reason: string;
  before: Row[];
  events: Array<{
    presentedJti: string;
    clockAfterLock: string;
    principal: Principal | null;
    fault: string | null;
    clockBeforeFinalUpdate?: string;
  }>;
  conditions?: {
    claimSubject?: string;
    claimTenant?: string;
    configuredYears?: string[];
    configuredLocations?: string[];
  };
  expected: {
    outcome: string;
    sessionRows: Row[];
    commitRejection?: boolean;
    principalMustNotBeRead?: boolean;
    yearDefaultMustNotBeRead?: boolean;
  };
};
const original = independent.cases as unknown as Case[];
const additive = qualifications.cases as unknown as Case[];
const fixture = (id: string): Case => {
  const found = [...original, ...additive].find((entry) => entry.id === id);
  if (!found) throw new Error(`Missing independent case ${id}`);
  return found;
};
// R05 is qualified by Q01/Q02. R16/R21/R22 are impossible constrained database rows.
// R20 is covered only by a named confirmed SQL-abort scenario below, not lost COMMIT acknowledgment.
// R23 is an impossible row-count fault, not represented as a genuine PostgreSQL race.
const databaseCases = [
  'R01',
  'R02',
  'R03',
  'R04',
  'R06',
  'R07',
  'R08',
  'R09',
  'R10',
  'R11',
  'R12',
  'R13',
  'R14',
  'R15',
  'R17',
  'R18',
  'R19',
  'R24',
  'R25',
  'Q01',
  'Q02',
].map(fixture);
const businessTables = [
  'CO_MAST',
  'LOCT_MAST',
  'YEAR_MAST',
  'LOGIN_MAST',
  'CO_SET',
  'AC_DATA',
  'SL_DATA',
  'SL_DETL_RTN',
  'audit_log',
] as const;
const rawSql = `(SELECT jsonb_object_agg(j.key,j.value) FROM jsonb_each_text(to_jsonb(t)) j)
  || jsonb_build_object('created_at',t.created_at::text,'last_used_at',t.last_used_at::text,
    'expires_at',t.expires_at::text,'revoked_at',t.revoked_at::text)`;
const mapped = (row: Row): Row => ({
  ...row,
  tenant_id: row.tenant_id === 'refresh-matrix' ? tenantId : foreignTenant,
});
const claims = (jti = currentJti): RefreshClaims => ({
  typ: 'refresh',
  tenantId,
  sid,
  sub: 'operator',
  jti,
});
const tokens = {
  accessToken: 'local-unpublished-access',
  refreshToken: 'local-unpublished-refresh',
};
const deferred = <T>() => {
  let resolve!: (value: T) => void;
  const promise = new Promise<T>((done) => {
    resolve = done;
  });
  return { promise, resolve };
};
const settle = <T>(promise: Promise<T>) =>
  promise.then(
    (value) => ({ status: 'fulfilled' as const, value }),
    (reason: unknown) => ({ status: 'rejected' as const, reason }),
  );

run('internal atomic refresh: qualified independent literals and real PostgreSQL schedules', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let protectedBusiness: Record<string, unknown> | undefined;
  const sql = (query: string, ...values: unknown[]) => owner.$executeRawUnsafe(query, ...values);
  const insert = async (table: string, row: Row) => {
    const columns = Object.keys(row)
      .map((key) => `"${key}"`)
      .join(',');
    await sql(
      `INSERT INTO "${table}"(${columns}) SELECT ${columns} FROM jsonb_populate_record(NULL::"${table}",$1::jsonb)`,
      JSON.stringify(row),
    );
  };
  const cleanup = async () => {
    for (const table of ['auth_session', ...businessTables])
      await sql(`DELETE FROM "${table}" WHERE tenant_id=ANY($1::text[])`, tenants);
  };
  const snapshot = () =>
    owner.$queryRawUnsafe<Snapshot[]>(
      `SELECT ${rawSql} raw,t.xmin::text revision,t.ctid::text locator FROM "auth_session" t
     WHERE tenant_id=ANY($1::text[]) ORDER BY tenant_id,session_id`,
      tenants,
    );
  const business = async () => {
    const result: Record<string, unknown> = {};
    for (const table of businessTables)
      result[table] = await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t)::text raw,t.xmin::text revision,t.ctid::text locator FROM "${table}" t
         WHERE tenant_id=ANY($1::text[]) ORDER BY to_jsonb(t)::text`,
        tenants,
      );
    return result;
  };
  const expectRaw = async (expected: Row[]) => {
    const normalized: Raw[] = [];
    for (const row of expected) {
      const rows = await owner.$queryRawUnsafe<Array<{ raw: Raw }>>(
        `SELECT ${rawSql} raw FROM jsonb_populate_record(NULL::"auth_session",$1::jsonb) t`,
        JSON.stringify(mapped(row)),
      );
      normalized.push(rows[0]!.raw);
    }
    normalized.sort((a, b) =>
      `${a.tenant_id}/${a.session_id}`.localeCompare(`${b.tenant_id}/${b.session_id}`),
    );
    expect((await snapshot()).map((row) => row.raw)).toEqual(normalized);
  };
  const seed = async (entry = fixture('R01')) => {
    for (const company of ['01', '02', '03']) {
      await insert('CO_MAST', {
        tenant_id: tenantId,
        CO_CODE: company,
        CO_NAME: `Refresh ${company}`,
        LC_CODE: '04',
      });
      for (const location of entry.conditions?.configuredLocations ?? ['03', '04'])
        await insert('LOCT_MAST', {
          tenant_id: tenantId,
          CO_CODE: company,
          LC_CODE: location,
        });
      for (const year of entry.conditions?.configuredYears ?? ['2024-2025', '2025-2026'])
        await insert('YEAR_MAST', {
          tenant_id: tenantId,
          CO_CODE: company,
          CO_YEAR: year,
          OP_DATE: `${year.slice(0, 4)}-04-01`,
        });
    }
    const principal = entry.events[0]!.principal;
    if (principal) {
      await insert('LOGIN_MAST', {
        tenant_id: tenantId,
        CO_CODE: principal.loginCoCode,
        LOGIN_NAME: principal.loginName,
        LOGIN_PWD: 'not-used-by-internal-refresh',
        LOGIN_CATG: principal.role,
        USER_UPDATE: principal.rights.userUpdate ? 'Y' : 'N',
        USER_DELETE: principal.rights.userDelete ? 'Y' : 'N',
        USER_PRINT: principal.rights.userPrint ? 'Y' : 'N',
        PASSWORD_RESET_REQUIRED: principal.passwordResetRequired ? 'Y' : 'N',
      });
      // Discriminating fallback: selected row must win over the opposite rights in login company01.
      if (principal.loginCoCode !== '01')
        await insert('LOGIN_MAST', {
          tenant_id: tenantId,
          CO_CODE: '01',
          LOGIN_NAME: 'operator',
          LOGIN_PWD: 'unused',
          LOGIN_CATG: 'ADMIN',
          USER_UPDATE: 'Y',
          USER_DELETE: 'Y',
          USER_PRINT: 'N',
          PASSWORD_RESET_REQUIRED: 'N',
        });
    }
    await insert('CO_SET', {
      tenant_id: tenantId,
      CO_CODE: '02',
      LAST_DAY_LOCK: 'Y',
      LOCK_DATE: '2020-01-02',
    });
    await insert('AC_DATA', {
      tenant_id: tenantId,
      CO_CODE: '02',
      LC_CODE: '03',
      CO_YEAR: '2024-2025',
      CO_BOOK: 'R01',
      LEDR_KEY: 'refresh-no-ledger-write',
      CR_AMT: '90071992547409.91',
      DR_AMT: null,
      ENTRY_TIME: '2024-05-06T12:34:56.123456',
      IT_DESC: 'unchanged',
    });
    for (const row of entry.before) await insert('auth_session', mapped(row));
    protectedBusiness = await business();
  };
  type Observe = {
    statements?: string[];
    pid?: ReturnType<typeof deferred<number>>;
    before?: (tx: Tx, statement: string, values: readonly unknown[]) => Promise<void>;
    rewriteValues?: (statement: string, values: readonly unknown[]) => readonly unknown[];
    afterCallback?: (tx: Tx) => Promise<void>;
  };
  // Instrumentation forwards ALL statements to PostgreSQL and never substitutes query results.
  const observed = (hooks: Observe): PrismaClient =>
    ({
      $transaction: <T>(
        callback: (tx: Tx) => Promise<T>,
        options?: Parameters<PrismaClient['$transaction']>[1],
      ) =>
        runtime.$transaction(async (tx) => {
          if (hooks.pid) {
            const rows = await tx.$queryRawUnsafe<Array<{ pid: number }>>(
              'SELECT pg_backend_pid()::int pid',
            );
            hooks.pid.resolve(rows[0]!.pid);
          }
          const proxy = new Proxy(tx, {
            get(target, key, receiver) {
              const value: unknown = Reflect.get(target, key, receiver);
              if (key !== '$queryRawUnsafe' && key !== '$executeRawUnsafe')
                return typeof value === 'function' ? value.bind(target) : value;
              return async (statement: string, ...values: unknown[]) => {
                hooks.statements?.push(statement);
                await hooks.before?.(tx, statement, values);
                const bindings = hooks.rewriteValues?.(statement, values) ?? values;
                return Reflect.apply(value as (...args: unknown[]) => unknown, target, [
                  statement,
                  ...bindings,
                ]);
              };
            },
          });
          const result = await callback(proxy);
          await hooks.afterCallback?.(tx);
          return result;
        }, options),
    }) as unknown as PrismaClient;
  const deps = (
    overrides: Partial<RefreshContextDependencies> = {},
  ): RefreshContextDependencies => ({
    issueTokens: async () => ({ ...tokens }),
    clock: () => new Date(time),
    newRefreshJti: () => nextJti,
    ...overrides,
  });
  const untilBlocked = async (pid: number) => {
    for (let attempt = 0; attempt < 200; attempt++) {
      const rows = await owner.$queryRawUnsafe<Array<{ blocked: boolean }>>(
        `SELECT EXISTS(SELECT 1 FROM pg_stat_activity WHERE pid=$1 AND wait_event_type='Lock'
          AND cardinality(pg_blocking_pids(pid))>0) AS blocked`,
        pid,
      );
      if (rows[0]?.blocked) return;
      await new Promise((resolve) => setTimeout(resolve, 10));
    }
    throw new Error('The second real PostgreSQL transaction never entered a row-lock wait.');
  };
  const protect = async () => {
    protectedBusiness = await business();
  };
  beforeAll(async () => {
    for (const value of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL]) {
      if (
        !value ||
        new URL(value).port !== '55433' ||
        !['localhost', '127.0.0.1'].includes(new URL(value).hostname)
      )
        throw new Error('Only local disposable parity database55433 is allowed.');
    }
    if (new URL(process.env.DATABASE_URL!).username !== 'app_user')
      throw new Error('Runtime must use app_user.');
    owner = new PrismaClient({
      datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
    });
    runtime = new PrismaClient();
    const rows = await runtime.$queryRawUnsafe<Array<{ role: string; bypass: boolean }>>(
      'SELECT current_user::text role,(rolsuper OR rolbypassrls) AS bypass FROM pg_roles WHERE rolname=current_user',
    );
    expect(rows).toEqual([{ role: 'app_user', bypass: false }]);
  });
  beforeEach(async () => {
    protectedBusiness = undefined;
    await cleanup();
  });
  afterEach(async () => {
    if (protectedBusiness) expect(await business()).toEqual(protectedBusiness);
  });
  afterAll(async () => {
    if (owner) {
      await cleanup();
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });

  it('pins all44 original literals and the three additive qualifications without rewriting expected outcomes', () => {
    for (const [file, hash] of [
      [
        'sessionContextRefresh.independent.json',
        'c7a7d68f63ef0bca93024dab1030b7c918a6c0bf22928c0de42499f02aa4bc61',
      ],
      [
        'sessionContextRefresh.qualifications.json',
        'dbe3861a31b738739719878e8d1dd68f0fa3fb66ff3ea0826ae0d6b463083fef',
      ],
    ] as const)
      expect(
        createHash('sha256')
          .update(readFileSync(new URL(`./fixtures/${file}`, import.meta.url)))
          .digest('hex'),
      ).toBe(hash);
    expect(independent.cases).toHaveLength(44);
    expect(qualifications.cases).toHaveLength(3);
    expect(databaseCases).toHaveLength(21);
  });

  it.each(databaseCases)('$id $reason', async (entry) => {
    await seed(entry);
    const before = await snapshot();
    const event = entry.events[0]!;
    const statements: string[] = [];
    const signing = vi.fn(
      async (input: Parameters<RefreshContextDependencies['issueTokens']>[0]) => {
        expect(input.principal).toEqual(event.principal);
        expect(input.session.loginCoCode).toBe('01');
        expect(input.refreshJti).toBe(nextJti);
        if (event.fault) throw new Error(event.fault);
        return { ...tokens };
      },
    );
    const submitted = {
      ...claims(event.presentedJti),
      sub: entry.conditions?.claimSubject ?? 'operator',
      tenantId: entry.conditions?.claimTenant ? foreignTenant : tenantId,
    };
    const result = await settle(
      refreshSessionContext(
        observed({ statements }),
        submitted,
        deps({
          issueTokens: signing,
          clock: () => new Date(event.clockAfterLock),
        }),
      ),
    );
    if (entry.expected.outcome === 'success') {
      expect(result.status).toBe('fulfilled');
      if (result.status !== 'fulfilled') throw result.reason;
      expect(result.value).toMatchObject(tokens);
      expect(result.value.principal).toEqual(event.principal);
      expect(result.value.session).toMatchObject({
        tenantId,
        sessionId: sid,
        loginName: 'operator',
        loginCoCode: '01',
        coCode: '02',
        lcCode: '03',
        contextEpoch: String(entry.before[0]!.context_epoch),
        ledgerContext: entry.before[0]!.ledger_context,
      });
      expect(Object.hasOwn(result.value.session, 'coYear')).toBe(true);
      expect(result.value.session.coYear).toBe(entry.before[0]!.co_year ?? undefined);
      expect(signing).toHaveBeenCalledTimes(1);
    } else {
      expect(result.status).toBe('rejected');
      if (result.status !== 'rejected') throw new Error('Expected refusal');
      expect(result.reason).toBeInstanceOf(Error);
      expect((result.reason as Error).message).toBe(entry.expected.outcome);
      expect(signing).toHaveBeenCalledTimes(event.fault ? 1 : 0);
    }
    await expectRaw(entry.expected.sessionRows);
    const after = await snapshot();
    if (JSON.stringify(entry.before) === JSON.stringify(entry.expected.sessionRows))
      expect(after).toEqual(before);
    if (entry.expected.principalMustNotBeRead)
      expect(statements.some((query) => query.includes('FROM "LOGIN_MAST"'))).toBe(false);
    if (entry.expected.yearDefaultMustNotBeRead)
      expect(statements.some((query) => query.includes('FROM "YEAR_MAST"'))).toBe(false);
  });

  it('Q03 uses literal microsecond SQL clocks: live1µs then exact expiry rolls back, preserving original row physically', async () => {
    const entry = fixture('Q03');
    await seed(entry);
    const before = await snapshot();
    const event = entry.events[0]!;
    const clockValues = [event.clockAfterLock, event.clockBeforeFinalUpdate!];
    let samples = 0;
    const signing = vi.fn(async () => ({ ...tokens }));
    const client = observed({
      rewriteValues(statement, values) {
        if (!statement.includes('WITH instant AS MATERIALIZED')) return values;
        const next = clockValues[samples++];
        if (!next) throw new Error('Unexpected extra sample in Q03');
        // Change ONLY the trusted clock parameter; real SQL parses and compares timestamp(6).
        return [next, ...values.slice(1)];
      },
    });
    await expect(
      refreshSessionContext(client, claims(), deps({ issueTokens: signing })),
    ).rejects.toMatchObject({ code: 'session-expired' });
    expect(samples).toBe(2);
    expect(signing).toHaveBeenCalledTimes(1);
    expect(await snapshot()).toEqual(before);
    await expectRaw(entry.expected.sessionRows);
  });

  it('keeps raw microseconds and maximum BIGINT text exact in the successful descriptor and stored observation', async () => {
    const base = fixture('R04');
    await seed({
      ...base,
      before: [
        {
          ...base.before[0]!,
          created_at: '2026-09-01T12:00:00.123456Z',
          last_used_at: '2026-09-02T12:00:00.234567Z',
          expires_at: '2026-09-08T12:00:00.345678Z',
        },
      ],
    });
    const before = (await snapshot())[0]!;
    const result = await refreshSessionContext(runtime, claims(), deps());
    expect(result.session.contextEpoch).toBe('9223372036854775807');
    expect(result.session.lastContextFromEpoch).toBe('9223372036854775806');
    expect(result.session.expiresAt).toBe(before.raw.expires_at);
    const after = (await snapshot())[0]!;
    const at = await owner.$queryRawUnsafe<Array<{ value: string }>>(
      'SELECT $1::timestamptz::text value',
      time,
    );
    expect(after.raw).toEqual({
      ...before.raw,
      refresh_jti_hash: independent.trustedFixtureJtis.nextSha256,
      last_used_at: at[0]!.value,
    });
  });

  it('R20 qualified: a real confirmed PostgreSQL statement abort after rotation rolls back; no lost-commit claim', async () => {
    await seed();
    const before = await snapshot();
    let rotatedInside = false;
    const client = observed({
      afterCallback: async (tx) => {
        const rows = await tx.$queryRawUnsafe<Array<{ hash: string }>>(
          'SELECT refresh_jti_hash::text hash FROM auth_session WHERE tenant_id=$1 AND session_id=$2',
          tenantId,
          sid,
        );
        rotatedInside = rows[0]?.hash === independent.trustedFixtureJtis.nextSha256;
        // A real SQL error aborts the transaction. This is NOT a simulated lost COMMIT acknowledgment.
        await tx.$queryRawUnsafe('SELECT 1 / 0');
      },
    });
    await expect(refreshSessionContext(client, claims(), deps())).rejects.toMatchObject({
      code: 'P2010',
    });
    expect(rotatedInside).toBe(true);
    expect(await snapshot()).toEqual(before);
  });

  it('C01/C06 actual duplicate current-JTI transactions serialize, then commit strict reuse revocation', async () => {
    await seed();
    const entered = deferred<void>();
    const release = deferred<void>();
    const secondPid = deferred<number>();
    const first = settle(
      refreshSessionContext(
        runtime,
        claims(),
        deps({
          issueTokens: async () => {
            entered.resolve();
            await release.promise;
            return { ...tokens };
          },
        }),
      ),
    );
    await Promise.race([
      entered.promise,
      first.then(() => {
        throw new Error('First refresh ended before reaching signer barrier');
      }),
    ]);
    const secondSigner = vi.fn(async () => ({ ...tokens }));
    const second = settle(
      refreshSessionContext(
        observed({ pid: secondPid }),
        claims(),
        deps({ issueTokens: secondSigner }),
      ),
    );
    const blocked = await settle(untilBlocked(await secondPid.promise));
    release.resolve();
    const [a, b] = await Promise.all([first, second]);
    if (blocked.status === 'rejected') throw blocked.reason;
    expect(a.status).toBe('fulfilled');
    expect(b).toMatchObject({
      status: 'rejected',
      reason: { code: 'refresh-reused' },
    });
    expect(secondSigner).not.toHaveBeenCalled();
    await expectRaw(fixture('C01').expected.sessionRows);
    const beforeRetry = await snapshot();
    await expect(refreshSessionContext(runtime, claims(nextJti), deps())).rejects.toMatchObject({
      code: 'session-revoked',
    });
    expect(await snapshot()).toEqual(beforeRetry);
  });

  it('C07 signer failure rolls back before a waiting independent request retries the same JTI successfully', async () => {
    await seed();
    const entered = deferred<void>();
    const release = deferred<void>();
    const secondPid = deferred<number>();
    const first = settle(
      refreshSessionContext(
        runtime,
        claims(),
        deps({
          issueTokens: async () => {
            entered.resolve();
            await release.promise;
            throw new Error('sign-refresh-failure');
          },
        }),
      ),
    );
    await Promise.race([
      entered.promise,
      first.then(() => {
        throw new Error('First refresh ended before reaching signer barrier');
      }),
    ]);
    const second = settle(refreshSessionContext(observed({ pid: secondPid }), claims(), deps()));
    const blocked = await settle(untilBlocked(await secondPid.promise));
    release.resolve();
    const [a, b] = await Promise.all([first, second]);
    if (blocked.status === 'rejected') throw blocked.reason;
    expect(a).toMatchObject({
      status: 'rejected',
      reason: { message: 'sign-refresh-failure' },
    });
    expect(b.status).toBe('fulfilled');
    await expectRaw(fixture('C07').expected.sessionRows);
  });

  it('C10 samples the trusted server clock after a real row-lock wait, committing expiry instead of signing', async () => {
    const base = fixture('R01');
    await seed({
      ...base,
      before: [{ ...base.before[0]!, expires_at: time }],
    });
    let now = '2026-09-03T11:59:59.999Z';
    const locked = deferred<void>();
    const release = deferred<void>();
    const pid = deferred<number>();
    const holder = settle(
      withTenant(runtime, tenantId, async (tx) => {
        await tx.$queryRawUnsafe(
          'SELECT session_id FROM auth_session WHERE tenant_id=$1 AND session_id=$2 FOR UPDATE',
          tenantId,
          sid,
        );
        locked.resolve();
        await release.promise;
      }),
    );
    await Promise.race([
      locked.promise,
      holder.then(() => {
        throw new Error('Holder ended before acquiring row lock');
      }),
    ]);
    const signing = vi.fn(async () => ({ ...tokens }));
    const refreshing = settle(
      refreshSessionContext(
        observed({ pid }),
        claims(),
        deps({ clock: () => new Date(now), issueTokens: signing }),
      ),
    );
    const blocked = await settle(untilBlocked(await pid.promise));
    now = time;
    release.resolve();
    const held = await holder;
    const refreshed = await refreshing;
    if (blocked.status === 'rejected') throw blocked.reason;
    if (held.status === 'rejected') throw held.reason;
    expect(refreshed).toMatchObject({
      status: 'rejected',
      reason: { code: 'session-expired' },
    });
    expect(signing).not.toHaveBeenCalled();
    await expectRaw(fixture('C10').expected.sessionRows);
  });

  for (const phase of ['signer', 'after-final-sample'] as const) {
    it(`default PostgreSQL clock expires during ${phase}; no rotation or revocation survives`, async () => {
      await seed();
      // Relative database time avoids dependence on the host timezone, date or JavaScript precision.
      await sql(
        "UPDATE auth_session SET expires_at=clock_timestamp()+interval '2 seconds' WHERE tenant_id=$1 AND session_id=$2",
        tenantId,
        sid,
      );
      const before = await snapshot();
      let delayed = false;
      const waitPastExpiry = async (tx: Tx | PrismaClient) => {
        await tx.$queryRawUnsafe(
          `SELECT pg_sleep(GREATEST(0,EXTRACT(EPOCH FROM (expires_at-clock_timestamp())))::double precision+0.02)::text AS waited
          FROM auth_session WHERE tenant_id=$1 AND session_id=$2`,
          tenantId,
          sid,
        );
        delayed = true;
      };
      const signing = vi.fn(async () => {
        if (phase === 'signer') await waitPastExpiry(owner);
        return { ...tokens };
      });
      const client = observed({
        before: async (tx, statement) => {
          if (phase === 'after-final-sample' && statement.includes('SET "refresh_jti_hash"'))
            await waitPastExpiry(tx);
        },
      });
      await expect(
        refreshSessionContext(client, claims(), deps({ clock: undefined, issueTokens: signing })),
      ).rejects.toMatchObject({ code: 'session-expired' });
      expect(signing).toHaveBeenCalledTimes(1);
      expect(delayed).toBe(true);
      expect(await snapshot()).toEqual(before);
    });
  }

  it('C02 qualified synthetic committed context is refreshed from the locked current row, preserving the receipt exactly', async () => {
    const entry = fixture('C02');
    await seed();
    await insert('LOGIN_MAST', {
      tenant_id: tenantId,
      CO_CODE: '03',
      LOGIN_NAME: 'operator',
      LOGIN_PWD: 'unused',
      LOGIN_CATG: 'USER',
      USER_UPDATE: 'N',
      USER_DELETE: 'N',
      USER_PRINT: 'Y',
      PASSWORD_RESET_REQUIRED: 'N',
    });
    await protect();
    const selected = entry.expected.sessionRows[0]!;
    // A modelled already-committed row transition, explicitly NOT selectSessionContext acceptance.
    await sql(
      `UPDATE auth_session SET co_code=$3,lc_code=$4,co_year=$5,context_epoch=$6::bigint,
      ledger_context=$7::jsonb,last_context_selection_id=$8,last_context_request_sha256=$9,last_context_from_epoch=$10::bigint
      WHERE tenant_id=$1 AND session_id=$2`,
      tenantId,
      sid,
      selected.co_code,
      selected.lc_code,
      selected.co_year,
      selected.context_epoch,
      JSON.stringify(selected.ledger_context),
      selected.last_context_selection_id,
      selected.last_context_request_sha256,
      selected.last_context_from_epoch,
    );
    const result = await refreshSessionContext(runtime, claims(), deps());
    expect(result.session).toMatchObject({
      loginCoCode: '01',
      coCode: '03',
      lcCode: '04',
      coYear: '2025-2026',
      contextEpoch: '8',
    });
    await expectRaw(entry.expected.sessionRows);
  });

  it('C04 actual logout commits before refresh and retains the established revoked row', async () => {
    await seed();
    await revokeSession(runtime, tenantId, sid, 'logout', new Date(time));
    const before = await snapshot();
    const signing = vi.fn(async () => ({ ...tokens }));
    await expect(
      refreshSessionContext(runtime, claims(), deps({ issueTokens: signing })),
    ).rejects.toMatchObject({ code: 'session-revoked' });
    expect(signing).not.toHaveBeenCalled();
    expect(await snapshot()).toEqual(before);
    await expectRaw(fixture('C04').expected.sessionRows);
  });

  it('C05 a real logout waits for the refresh row lock, then revokes the rotated session', async () => {
    await seed();
    const entered = deferred<void>();
    const release = deferred<void>();
    const logoutPid = deferred<number>();
    const refreshing = settle(
      refreshSessionContext(
        runtime,
        claims(),
        deps({
          issueTokens: async () => {
            entered.resolve();
            await release.promise;
            return { ...tokens };
          },
        }),
      ),
    );
    await Promise.race([
      entered.promise,
      refreshing.then(() => {
        throw new Error('Refresh ended before signer barrier');
      }),
    ]);
    const logout = settle(
      revokeSession(observed({ pid: logoutPid }), tenantId, sid, 'logout', new Date(time)),
    );
    const blocked = await settle(untilBlocked(await logoutPid.promise));
    release.resolve();
    const [a, b] = await Promise.all([refreshing, logout]);
    if (blocked.status === 'rejected') throw blocked.reason;
    expect(a.status).toBe('fulfilled');
    expect(b.status).toBe('fulfilled');
    await expectRaw(fixture('C05').expected.sessionRows);
    const before = await snapshot();
    await expect(refreshSessionContext(runtime, claims(nextJti), deps())).rejects.toMatchObject({
      code: 'session-revoked',
    });
    expect(await snapshot()).toEqual(before);
  });

  it('same sessionId in another tenant cannot be observed, rotated or revoked by the runtime tenant', async () => {
    await seed();
    const sentinel = {
      ...fixture('R01').before[0]!,
      tenant_id: foreignTenant,
      login_name: 'foreign-operator',
    };
    await insert('auth_session', sentinel);
    const before = await snapshot();
    await refreshSessionContext(runtime, claims(), deps());
    expect((await snapshot()).find((row) => row.raw.tenant_id === foreignTenant)).toEqual(
      before.find((row) => row.raw.tenant_id === foreignTenant),
    );
    await expect(
      refreshSessionContext(runtime, { ...claims(), tenantId: foreignTenant }, deps()),
    ).rejects.toMatchObject({ code: 'session-invalid' });
    expect((await snapshot()).find((row) => row.raw.tenant_id === foreignTenant)).toEqual(
      before.find((row) => row.raw.tenant_id === foreignTenant),
    );
  });
});
