import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  FakeMessageSender,
  notifyWithAttemptLog,
  type MessageSender,
} from '../src/modules/integrations/messaging.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT_A = 'messaging-attempt-a';
const TENANT_B = 'messaging-attempt-b';

const scope = (tenantId = TENANT_A) => ({ tenantId, coCode: '01', lcCode: '01' });
const message = { to: '+919999999999', channel: 'whatsapp' as const, body: 'invoice ready' };

databaseDescribe('restricted-role message attempt log', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async () => {
    await owner.$executeRawUnsafe(
      `DELETE FROM "message_attempt_log" WHERE "tenant_id" IN ($1,$2)`,
      TENANT_A,
      TENANT_B,
    );
  };

  const rows = async (tenantId = TENANT_A) =>
    (await owner.$queryRawUnsafe(
      `SELECT "tenant_id","status","provider_reference","failure_reason","idempotency_key"
         FROM "message_attempt_log" WHERE "tenant_id"=$1 ORDER BY "id"`,
      tenantId,
    )) as Array<Record<string, string | null>>;

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl)
      throw new Error('messaging DB tests require MIGRATE_DATABASE_URL and DATABASE_URL');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  beforeEach(cleanup);

  afterAll(async () => {
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  /** A sender that a real gateway would be: it ACCEPTS the message; delivery is never claimed. */
  const accepting = (): MessageSender & { calls: number } => {
    const sender = {
      calls: 0,
      async send() {
        sender.calls += 1;
        return { id: `gw-${sender.calls}`, status: 'accepted' as const };
      },
    };
    return sender;
  };

  it('logs a provider acceptance as accepted, never as delivered (G33)', async () => {
    const sender = accepting();
    const result = await notifyWithAttemptLog(runtime, sender, scope(), message, {
      idempotencyKey: 'accepted-1',
      templateKind: 'invoice',
    });

    expect(result).toMatchObject({ ok: true, status: 'accepted', deduplicated: false, id: 'gw-1' });
    expect(sender.calls).toBe(1);
    expect(await rows()).toEqual([
      expect.objectContaining({
        tenant_id: TENANT_A,
        status: 'accepted',
        provider_reference: 'gw-1',
        failure_reason: null,
        idempotency_key: 'accepted-1',
      }),
    ]);
  });

  it('logs a simulated send as simulated and reports it as not delivered (G33)', async () => {
    const sender = new FakeMessageSender();
    const result = await notifyWithAttemptLog(runtime, sender, scope(), message, {
      idempotencyKey: 'simulated-1',
      templateKind: 'invoice',
    });

    expect(result).toMatchObject({
      ok: false,
      status: 'simulated',
      deduplicated: false,
      id: 'fake-1',
    });
    expect(sender.outbox).toHaveLength(1);
    expect(await rows()).toEqual([
      expect.objectContaining({
        status: 'simulated',
        provider_reference: 'fake-1',
        failure_reason: null,
      }),
    ]);
    // A retry with the same key replays the stored simulation; it never turns into a success.
    const retry = await notifyWithAttemptLog(runtime, sender, scope(), message, {
      idempotencyKey: 'simulated-1',
      templateKind: 'invoice',
    });
    expect(retry).toMatchObject({ ok: false, status: 'simulated', deduplicated: true });
    expect(sender.outbox).toHaveLength(1);
  });

  it('does not insert or call the provider twice for the same tenant key', async () => {
    const sender = accepting();
    const options = { idempotencyKey: 'retry-1', templateKind: 'invoice' };
    await notifyWithAttemptLog(runtime, sender, scope(), message, options);
    const retry = await notifyWithAttemptLog(runtime, sender, scope(), message, options);

    expect(retry).toMatchObject({ ok: true, status: 'accepted', deduplicated: true, id: 'gw-1' });
    expect(sender.calls).toBe(1);
    expect(await rows()).toHaveLength(1);
  });

  it('still reads a pre-N54 attempt stored as sent as a provider acceptance', async () => {
    await withTenant(runtime, TENANT_A, (tx: any) =>
      tx.$executeRawUnsafe(
        `INSERT INTO "message_attempt_log"("tenant_id","co_code","channel","recipient","template_kind","idempotency_key","status","provider_reference")
         VALUES ($1,'01','whatsapp','919812345670','invoice','legacy-1','sent','OLD-REF')`,
        TENANT_A,
      ),
    );
    const sender = accepting();
    const replay = await notifyWithAttemptLog(runtime, sender, scope(), message, {
      idempotencyKey: 'legacy-1',
      templateKind: 'invoice',
    });
    expect(replay).toMatchObject({
      ok: true,
      status: 'accepted',
      deduplicated: true,
      id: 'OLD-REF',
    });
    expect(sender.calls).toBe(0);
  });

  it('logs a provider failure and its reason', async () => {
    let calls = 0;
    const sender: MessageSender = {
      async send() {
        calls += 1;
        throw new Error('gateway unavailable');
      },
    };
    const result = await notifyWithAttemptLog(runtime, sender, scope(), message, {
      idempotencyKey: 'failure-1',
      templateKind: 'invoice',
    });

    expect(result).toMatchObject({ ok: false, status: 'failed', error: 'gateway unavailable' });
    expect(calls).toBe(1);
    expect(await rows()).toEqual([
      expect.objectContaining({ status: 'failed', failure_reason: 'gateway unavailable' }),
    ]);
  });

  it('keeps attempts tenant-isolated while allowing the same key in another tenant', async () => {
    const sender = new FakeMessageSender();
    const options = { idempotencyKey: 'shared-key', templateKind: 'invoice' };
    await notifyWithAttemptLog(runtime, sender, scope(TENANT_A), message, options);

    const hidden = await withTenant(runtime, TENANT_B, (tx: any) =>
      tx.$queryRawUnsafe(`SELECT "id" FROM "message_attempt_log"`),
    );
    expect(hidden).toEqual([]);

    await notifyWithAttemptLog(runtime, sender, scope(TENANT_B), message, options);
    expect(sender.outbox).toHaveLength(2);
    expect(await rows(TENANT_A)).toHaveLength(1);
    expect(await rows(TENANT_B)).toHaveLength(1);
  });
});
