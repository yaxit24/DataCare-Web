import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { beforeEach, describe, expect, it, vi } from 'vitest';
import type { Principal } from '../src/modules/rbac/authorization.js';

const h = vi.hoisted(() => ({
  row: {} as Record<string, unknown>,
  log: [] as string[],
  live: [] as boolean[],
  revoked: false,
  current: {} as Principal,
  target: {} as Principal,
  principalCalls: 0,
  scopeError: null as unknown,
  storedError: null as unknown,
  principalError: null as unknown,
  lockError: null as unknown,
  transactionError: null as unknown,
  updateCount: 1,
  updateArgs: [] as unknown[],
  signerArgs: [] as unknown[],
  lockResult: { applied: true, lockDate: '2026-09-11' as string | null },
  options: undefined as unknown,
  tenant: '',
  callbackRejected: false,
}));

vi.mock('@datacare/db', () => ({
  withTenant: async (
    _prisma: unknown,
    tenant: string,
    callback: (tx: unknown) => Promise<unknown>,
    options: unknown,
  ) => {
    h.tenant = tenant;
    h.options = options;
    h.log.push('begin');
    if (h.transactionError) throw h.transactionError;
    const tx = {
      $queryRawUnsafe: async (sql: string, ...args: unknown[]) => {
        if (sql.includes('FOR UPDATE')) {
          h.log.push('session-lock');
          return [{ ...h.row }];
        }
        if (sql.includes('AS unexpired')) {
          h.log.push('fresh-clock');
          expect(sql).toContain('clock_timestamp()');
          expect(args).toEqual(['T1', '10000000-0000-4000-8000-000000000001']);
          return [
            {
              revoked: h.revoked,
              unexpired: h.live.length ? h.live.shift() : true,
            },
          ];
        }
        if (sql.includes('UPDATE "auth_session"')) {
          h.log.push('session-update');
          h.updateArgs = args;
          expect(sql).toContain(
            '"tenant_id"=$1 AND "session_id"=$2 AND "context_epoch"=$10::bigint',
          );
          expect(sql).toContain('"revoked_at" IS NULL AND "expires_at" > clock_timestamp()');
          expect(sql).not.toContain('refresh_jti_hash');
          expect(sql).not.toContain('last_used_at');
          return h.updateCount === 1 ? [{ contextEpoch: args[5] }] : [];
        }
        throw new Error('Unexpected coordinator query');
      },
    };
    try {
      const result = await callback(tx);
      h.log.push('callback-resolved');
      return result;
    } catch (error) {
      h.callbackRejected = true;
      h.log.push('callback-rejected');
      throw error;
    }
  },
}));
vi.mock('../src/modules/rbac/authorization.js', () => ({
  loadPrincipalTx: async (_tx: unknown, input: { loginCoCode: string }) => {
    h.log.push('principal');
    expect(input.loginCoCode).toBe('01');
    if (h.principalError) throw h.principalError;
    return h.principalCalls++ === 0 ? h.current : h.target;
  },
}));
vi.mock('../src/modules/auth/businessScope.js', async (original) => ({
  ...(await original<typeof import('../src/modules/auth/businessScope.js')>()),
  resolveSelectedScopeTx: async (
    _tx: unknown,
    input: {
      tenantId: string;
      coCode: string;
      lcCode?: string;
      coYear?: string;
      isAdmin: boolean;
    },
  ) => {
    h.log.push('resolve-scope');
    expect(input.isAdmin).toBe(h.current.isAdmin);
    if (h.scopeError) throw h.scopeError;
    return {
      tenantId: input.tenantId,
      coCode: input.coCode,
      lcCode: input.lcCode ?? '02',
      coYear: input.coYear ?? '2025-2026',
    };
  },
  validateStoredScopeTx: async (
    _tx: unknown,
    input: { coCode: string; lcCode: string; coYear: string },
  ) => {
    h.log.push('validate-stored');
    if (h.storedError) throw h.storedError;
    return input;
  },
}));
vi.mock('../src/modules/shared/lastDayLock.js', () => ({
  applyLastDayLockTx: async () => {
    h.log.push('last-lock');
    if (h.lockError) throw h.lockError;
    return h.lockResult;
  },
}));

import {
  contextSelectionRequestSha256,
  parseContextSelectionRequest,
  selectSessionContext,
  type SelectionAccessDescriptor,
  type SelectionAuthenticatedIdentity,
} from '../src/modules/auth/sessionContextSelection.js';

const bytes = readFileSync(
  new URL('./fixtures/sessionContextSelection.independent.json', import.meta.url),
);
const literal = JSON.parse(bytes.toString('utf8')) as {
  fixtures: {
    requests: Record<string, Record<string, unknown>>;
    fingerprints: Record<string, { utf8: string; sha256: string }>;
  };
  cases: Array<{ id: string }>;
  raceSchedules: Array<{ id: string }>;
};
const body = () => ({ ...literal.fixtures.requests.toB! });
const id = (): SelectionAuthenticatedIdentity => ({
  tenantId: 'T1',
  sessionId: '10000000-0000-4000-8000-000000000001',
  loginName: 'OP01',
  loginCoCode: '01',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  contextEpoch: '9',
});
const ledger = () => ({
  version: 'server-session-ledger-context-v1',
  status: 'unknown',
  mode: null,
  reason: 'vendor-authority-unresolved',
});
const rights = () => ({
  userUpdate: false,
  userDelete: false,
  userPrint: true,
});
const signer = async (input: SelectionAccessDescriptor) => {
  h.log.push('sign');
  h.signerArgs.push(input);
  return 'locally-signed-token';
};
const run = (request: unknown = body(), identity = id(), signAccess = signer) =>
  selectSessionContext(
    {} as Parameters<typeof selectSessionContext>[0],
    { request, identity },
    { signAccess },
  );
function receipt(
  epoch = '10',
  from = '9',
  request: unknown = body(),
): SelectionAuthenticatedIdentity {
  h.row = {
    ...h.row,
    coCode: '02',
    lcCode: '02',
    coYear: '2025-2026',
    contextEpoch: epoch,
    selectionId: '10000000-0000-4000-8000-000000000001',
    fromEpoch: from,
    requestSha256: contextSelectionRequestSha256(parseContextSelectionRequest(request)),
  };
  return {
    ...id(),
    coCode: '02',
    lcCode: '02',
    coYear: '2025-2026',
    contextEpoch: epoch,
  };
}

beforeEach(() => {
  h.row = {
    ...id(),
    ledgerContext: ledger(),
    selectionId: null,
    requestSha256: null,
    fromEpoch: null,
  };
  h.log = [];
  h.live = [];
  h.revoked = false;
  h.principalCalls = 0;
  h.updateCount = 1;
  h.updateArgs = [];
  h.signerArgs = [];
  h.tenant = '';
  h.options = undefined;
  h.callbackRejected = false;
  h.scopeError = h.storedError = h.principalError = h.lockError = h.transactionError = null;
  h.current = {
    loginName: 'OP01',
    loginCoCode: '01',
    role: 'ADMIN',
    isAdmin: true,
    rights: { userUpdate: true, userDelete: true, userPrint: true },
    passwordResetRequired: false,
  };
  h.target = {
    loginName: 'OP01',
    loginCoCode: '02',
    role: 'USER',
    isAdmin: false,
    rights: rights(),
    passwordResetRequired: false,
  };
  h.lockResult = { applied: true, lockDate: '2026-09-11' };
});

describe('independently frozen request literals', () => {
  it('pins the pre-implementation 44 outcomes and12 race schedules without rewriting their qualification', () => {
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      'e46adeb02f8ddbf9fe2fc601f816386e09af5c88dd7ba8a2b6a16dbe5c565299',
    );
    expect(literal.cases).toHaveLength(44);
    expect(literal.raceSchedules).toHaveLength(12);
  });
  for (const [name, expected] of Object.entries(literal.fixtures.fingerprints)) {
    it(`matches independent compact UTF8 tuple/hash ${name}`, () => {
      const request = parseContextSelectionRequest(literal.fixtures.requests[name]);
      expect(contextSelectionRequestSha256(request)).toBe(expected.sha256);
      expect(createHash('sha256').update(expected.utf8).digest('hex')).toBe(expected.sha256);
    });
  }
  it('ignores property order while preserving omitted versus explicit defaults (C06/C41)', () => {
    const forward = body();
    const reverse = Object.fromEntries(Object.entries(forward).reverse());
    expect(contextSelectionRequestSha256(parseContextSelectionRequest(reverse))).toBe(
      literal.fixtures.fingerprints.toB!.sha256,
    );
    expect(literal.fixtures.fingerprints.toB!.sha256).not.toBe(
      literal.fixtures.fingerprints.implicitB!.sha256,
    );
  });
  it('detaches/freeze values and retains optional omissions', () => {
    const value = { ...literal.fixtures.requests.implicitB! };
    const parsed = parseContextSelectionRequest(value);
    value.coCode = '01';
    expect(parsed.coCode).toBe('02');
    expect(Object.isFrozen(parsed)).toBe(true);
    expect(Object.hasOwn(parsed, 'lcCode')).toBe(false);
    expect(Object.hasOwn(parsed, 'coYear')).toBe(false);
  });
  for (const bad of [
    null,
    [],
    {},
    1,
    'text',
    { ...body(), extra: true },
    { ...body(), tenantId: 'T2' },
    { ...body(), rights: {} },
    { ...body(), mode: 'A' },
    { ...body(), lcCode: undefined },
    { ...body(), coYear: null },
    { ...body(), coCode: 2 },
    { ...body(), coCode: ' 2' },
    { ...body(), coYear: '2024-20255' },
    { ...body(), coCode: '02\n' },
    { ...body(), expectedContextEpoch: 9 },
    { ...body(), expectedContextEpoch: '09' },
    { ...body(), expectedContextEpoch: '0' },
    { ...body(), expectedContextEpoch: '9223372036854775808' },
    { ...body(), selectionId: 'A0000000-0000-4000-8000-000000000001' },
  ]) {
    it(`refuses malformed public body before any transaction: ${JSON.stringify(bad)}`, async () => {
      await expect(run(bad)).rejects.toMatchObject({
        code: 'invalid-context-selection-request',
      });
      expect(h.log).toEqual([]);
    });
  }
  it('refuses getter and inherited envelopes without evaluating the getter', () => {
    let calls = 0;
    const getter = { ...body() };
    Object.defineProperty(getter, 'coCode', {
      enumerable: true,
      get() {
        calls++;
        return '02';
      },
    });
    expect(() => parseContextSelectionRequest(getter)).toThrow('invalid-context-selection-request');
    expect(calls).toBe(0);
    expect(() => parseContextSelectionRequest(Object.create(body()))).toThrow(
      'invalid-context-selection-request',
    );
  });
});

describe('coordinator policy and transaction sequencing (mocked, not DB atomicity proof)', () => {
  it('an incomplete login identity with own undefined year can open a complete selected scope', async () => {
    h.row.coYear = null;
    h.row.ledgerContext = { ...ledger(), reason: 'scope-incomplete' };
    const result = await run(body(), { ...id(), coYear: undefined });
    expect(result.session).toMatchObject({
      coYear: '2025-2026',
      contextEpoch: '10',
      ledgerContext: ledger(),
    });
    expect(h.updateArgs[4]).toBe('2025-2026');
  });

  it('C01 uses fresh target rights, immutable login company, one epoch/receipt update and local signing before commit', async () => {
    const result = await run();
    expect(result.session).toMatchObject({
      coCode: '02',
      lcCode: '02',
      coYear: '2025-2026',
      contextEpoch: '10',
      loginCoCode: '01',
      rights: rights(),
    });
    expect(result).toMatchObject({
      replayed: false,
      accessToken: 'locally-signed-token',
      lastDayLock: { applied: true, lockDate: '2026-09-11' },
    });
    expect(h.updateArgs).toEqual([
      'T1',
      id().sessionId,
      '02',
      '02',
      '2025-2026',
      '10',
      JSON.stringify(ledger()),
      body().selectionId,
      literal.fixtures.fingerprints.toB!.sha256,
      '9',
    ]);
    expect(h.signerArgs[0]).toMatchObject({
      loginCoCode: '01',
      coCode: '02',
      contextEpoch: '10',
      rights: rights(),
    });
    expect(h.log).toEqual([
      'begin',
      'session-lock',
      'fresh-clock',
      'principal',
      'resolve-scope',
      'principal',
      'last-lock',
      'sign',
      'session-update',
      'callback-resolved',
    ]);
    expect(h.options).toEqual({ isolationLevel: 'Serializable' });
    expect(h.tenant).toBe('T1');
  });
  it('C02 a fresh same-scope open increments once', async () => {
    const result = await run(literal.fixtures.requests.sameA);
    expect(result.session).toMatchObject({ coCode: '01', contextEpoch: '10' });
    expect(result.replayed).toBe(false);
    expect(h.log.filter((x) => x === 'last-lock')).toHaveLength(1);
  });
  it('C03/C11/C12 exact recovery uses current bearer10 and original body9, fresh rights, no defaults/lock/update', async () => {
    const identity = receipt();
    h.current = { ...h.target };
    const result = await run(body(), identity);
    expect(result).toMatchObject({ replayed: true, lastDayLock: null });
    expect(result.session).toMatchObject({
      coCode: '02',
      contextEpoch: '10',
      ledgerContext: ledger(),
      rights: rights(),
    });
    expect(h.log).toEqual([
      'begin',
      'session-lock',
      'fresh-clock',
      'principal',
      'validate-stored',
      'sign',
      'fresh-clock',
      'callback-resolved',
    ]);
    expect(h.updateArgs).toEqual([]);
  });
  it('C04 and qualifiedR02 reject old bearer authority before receipt matching', async () => {
    receipt();
    await expect(run()).rejects.toMatchObject({ code: 'session-invalid' });
    expect(h.log).toEqual(['begin', 'session-lock', 'callback-rejected']);
  });
  for (const mutation of [{ coCode: '01' }, { expectedContextEpoch: '10' }]) {
    it(`C05/C07 same current ID with changed body refuses ${JSON.stringify(mutation)}`, async () => {
      const identity = receipt();
      await expect(run({ ...body(), ...mutation }, identity)).rejects.toMatchObject({
        code: 'context-operation-conflict',
      });
      expect(h.log).not.toContain('last-lock');
      expect(h.log).not.toContain('sign');
    });
  }
  it('C06 explicit defaults cannot recover an omitted-field receipt', async () => {
    const identity = receipt('10', '9', literal.fixtures.requests.implicitB);
    await expect(run(body(), identity)).rejects.toMatchObject({
      code: 'context-operation-conflict',
    });
  });
  it('C08/C09 stale request with current bearer performs no scope/setting write', async () => {
    const identity = receipt();
    await expect(
      run({ ...body(), selectionId: '30000000-0000-4000-8000-000000000003' }, identity),
    ).rejects.toMatchObject({ code: 'context-stale' });
    expect(h.log).not.toContain('resolve-scope');
    expect(h.log).not.toContain('last-lock');
  });
  for (const [which, code] of [
    ['current', 'password-reset-required'],
    ['target', 'target-password-reset-required'],
  ] as const) {
    it(`C13/C14 refuses ${which} reset before last-lock or signing`, async () => {
      h[which].passwordResetRequired = true;
      await expect(run()).rejects.toMatchObject({ code });
      expect(h.log).not.toContain('last-lock');
      expect(h.log).not.toContain('sign');
    });
  }
  for (const code of ['company-unavailable', 'location-unavailable', 'year-unavailable']) {
    it(`C16-C18 target scope error propagates without writes: ${code}`, async () => {
      h.scopeError = new Error(code);
      await expect(run()).rejects.toThrow(code);
      expect(h.log).not.toContain('last-lock');
    });
    it(`approved qualification: exact receipt refuses deleted ${code} without lock/sign/update`, async () => {
      const identity = receipt();
      h.storedError = new Error(code);
      await expect(run(body(), identity)).rejects.toThrow(code);
      expect(h.log).toContain('validate-stored');
      expect(h.log).not.toContain('last-lock');
      expect(h.log).not.toContain('sign');
    });
  }
  it('C15 missing principal propagates before mutation', async () => {
    h.principalError = new Error('principal-unavailable');
    await expect(run()).rejects.toThrow('principal-unavailable');
    expect(h.log).not.toContain('last-lock');
  });
  it('C20 fresh fallback principal may originate at immutable company01', async () => {
    h.target = { ...h.current };
    const result = await run();
    expect(result.session.rights).toEqual(h.current.rights);
    expect(result.session.loginCoCode).toBe('01');
  });
  for (const lockDate of ['2026-09-11', '2026-09-20', null]) {
    it(`C21-C25 preserves unchanged/no-op lock helper outcome ${lockDate}`, async () => {
      h.lockResult = { applied: false, lockDate };
      expect((await run()).lastDayLock).toEqual({ applied: false, lockDate });
    });
  }
  it('C26 last-lock validation throws out of the transaction', async () => {
    h.lockError = new Error('invalid LAST_DAY_LOCK');
    await expect(run()).rejects.toThrow('invalid LAST_DAY_LOCK');
    expect(h.callbackRejected).toBe(true);
    expect(h.log).not.toContain('sign');
    expect(h.log).not.toContain('session-update');
  });
  it('C27 signer failure remains a rejected transaction callback after tentative last-lock', async () => {
    await expect(
      run(body(), id(), async () => {
        throw new Error('sign failed');
      }),
    ).rejects.toThrow('sign failed');
    expect(h.log).toContain('last-lock');
    expect(h.callbackRejected).toBe(true);
    expect(h.log).not.toContain('session-update');
  });
  it('C28 zero-row CAS throws after writes rather than returning a successful error-shaped callback', async () => {
    h.updateCount = 0;
    await expect(run()).rejects.toMatchObject({
      code: 'context-update-conflict',
    });
    expect(h.callbackRejected).toBe(true);
  });
  for (const error of [
    { code: 'P2034' },
    { code: '40001' },
    { code: '40P01' },
    { code: 'P2010', meta: { code: '40001' } },
  ]) {
    it(`C29/R01 reports a transaction conflict without retry ${JSON.stringify(error)}`, async () => {
      h.transactionError = error;
      await expect(run()).rejects.toMatchObject({
        code: 'context-transaction-conflict',
      });
      expect(h.log).toEqual(['begin']);
    });
  }
  it('C31 revoked receipt cannot recover', async () => {
    const identity = receipt();
    h.revoked = true;
    await expect(run(body(), identity)).rejects.toMatchObject({
      code: 'session-revoked',
    });
    expect(h.log).not.toContain('sign');
  });
  for (const patch of [
    { tenantId: 'T2' },
    { loginName: 'OTHER' },
    { loginCoCode: '02' },
    { sessionId: 'other' },
    { lcCode: '02' },
  ]) {
    it(`C32/C33 locked identity mismatch refuses ${JSON.stringify(patch)}`, async () => {
      h.row = { ...h.row, ...patch };
      await expect(run()).rejects.toMatchObject({ code: 'session-invalid' });
      expect(h.log).not.toContain('principal');
    });
  }
  for (const [epoch, next] of [
    ['9007199254740993', '9007199254740994'],
    ['9223372036854775806', '9223372036854775807'],
  ]) {
    it(`C34/C35 preserves exact BIGINT epoch ${epoch}`, async () => {
      h.row.contextEpoch = epoch;
      const result = await run(
        { ...body(), expectedContextEpoch: epoch },
        { ...id(), contextEpoch: epoch! },
      );
      expect(result.session.contextEpoch).toBe(next);
      expect(h.updateArgs[9]).toBe(epoch);
    });
  }
  it('C36 exhaustion does not run last-lock', async () => {
    const epoch = '9223372036854775807';
    h.row.contextEpoch = epoch;
    await expect(
      run({ ...body(), expectedContextEpoch: epoch }, { ...id(), contextEpoch: epoch }),
    ).rejects.toMatchObject({ code: 'context-epoch-exhausted' });
    expect(h.log).not.toContain('last-lock');
  });
  it('C37 receipt recovery at maximum epoch never computes next', async () => {
    const request = { ...body(), expectedContextEpoch: '9223372036854775806' };
    const identity = receipt('9223372036854775807', '9223372036854775806', request);
    expect((await run(request, identity)).session.contextEpoch).toBe('9223372036854775807');
    expect(h.updateArgs).toEqual([]);
  });
  for (const patch of [
    { contextEpoch: '09' },
    { fromEpoch: '8' },
    { ledgerContext: { ...ledger(), mode: 'A' } },
  ]) {
    it(`C38 malformed persisted context refuses ${JSON.stringify(patch)}`, async () => {
      h.row = { ...h.row, ...patch };
      await expect(run()).rejects.toMatchObject({
        code: 'session-context-invalid',
      });
      expect(h.log).not.toContain('last-lock');
    });
  }
  it('C39 inconsistent receipt origin is not treated as valid recovery', async () => {
    const identity = receipt();
    h.row.fromEpoch = '7';
    await expect(run(body(), identity)).rejects.toMatchObject({
      code: 'session-context-invalid',
    });
  });
  it('C42 expiry is evaluated after row lock, using the separate live query', async () => {
    h.live = [false];
    await expect(run()).rejects.toMatchObject({ code: 'session-expired' });
    expect(h.log).toEqual(['begin', 'session-lock', 'fresh-clock', 'callback-rejected']);
  });
  it('C43 expired final CAS throws after signer and tentative setting mutation', async () => {
    h.live = [true, false];
    h.updateCount = 0;
    await expect(run()).rejects.toMatchObject({ code: 'session-expired' });
    expect(h.log).toContain('last-lock');
    expect(h.log).toContain('sign');
    expect(h.callbackRejected).toBe(true);
  });
  it('C44 recovery also rejects expiry during signer execution', async () => {
    const identity = receipt();
    h.live = [true, false];
    await expect(run(body(), identity)).rejects.toMatchObject({
      code: 'session-expired',
    });
    expect(h.log).toContain('sign');
    expect(h.log).not.toContain('session-update');
  });
});
