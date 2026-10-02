import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { withTxBudget } from '../shared/txBudget.js';

/**
 * Messaging integrations — web replacement for the desktop UT_WHATSAPP / UT_WAPP_WITH_API / UT_SMS.
 * The desktop built a message from a template (CO_SET.CUST_SMS/ADMIN_SMS) + sale data and sent it
 * over WhatsApp/SMS. Here, message bodies are rendered from templates (pure) and sent through an
 * injected MessageSender: the WhatsApp Cloud API or an HTTP SMS gateway, configured by environment.
 *
 * TRUTHFULNESS (N54 step 4, gap G33). A send result says exactly what happened and nothing more:
 *   • `accepted`  — a real provider accepted the message. That is not delivery; only a provider callback
 *                   could say "delivered", and none is wired yet, so nothing is ever reported delivered.
 *   • `simulated` — the in-memory fake took it. Nothing left the server. The fake exists only when
 *                   `MESSAGING_FAKE_MODE=1` is set outside production.
 *   • `failed`    — the provider refused it, or the call failed.
 * With no provider configured there is NO sender: send routes answer 503 `messaging-unconfigured` before an
 * attempt is recorded. Previously an unconfigured server fell back to the fake in every environment and
 * answered `{ok:true}`, logging the attempt as `sent`.
 *
 * notify() is BEST-EFFORT and NEVER throws — a delivery failure must not roll back the business
 * transaction that triggered it (matches the desktop, where a failed send didn't void the sale).
 */

export type Channel = 'whatsapp' | 'sms';

export interface OutboundMessage {
  to: string; // phone (E.164 ideally)
  channel: Channel;
  body: string;
  /** WhatsApp document (e.g. the invoice PDF): uploaded to /media then sent as type=document. */
  document?: { pdf: Buffer; filename: string; caption?: string };
  /** WhatsApp approved template (name + ordered body params), for out-of-session sends. */
  template?: { name: string; lang?: string; params?: string[] };
}

/** What a sender can truthfully report; see the module comment. */
export type SendStatus = 'accepted' | 'simulated' | 'failed';

export interface SendResult {
  id: string;
  status: SendStatus;
}

export interface MessageSender {
  send(msg: OutboundMessage): Promise<SendResult>;
}

/** Render a template, substituting {placeholder} tokens from vars (pure, desktop CUST_SMS parity). */
export function renderTemplate(template: string, vars: Record<string, string | number>): string {
  return template.replace(/\{(\w+)\}/g, (_m, key) => {
    const v = vars[key];
    return v === undefined || v === null ? '' : String(v);
  });
}

/**
 * Records every message in-memory and reports it as SIMULATED; used for tests and explicit test mode. It never
 * reports a success, because nothing was delivered.
 */
export class FakeMessageSender implements MessageSender {
  public outbox: OutboundMessage[] = [];
  private n = 0;
  async send(msg: OutboundMessage): Promise<SendResult> {
    this.outbox.push(msg);
    return { id: `fake-${++this.n}`, status: 'simulated' };
  }
}

export interface NotifyResult {
  /** True only when a real provider ACCEPTED the message; never for a simulation, and never proof of delivery. */
  ok: boolean;
  /** `pending` only when replaying an attempt that another request is still sending. */
  status: SendStatus | 'pending';
  id?: string;
  error?: string;
}

/** No provider is configured, so the message cannot be sent; the route answers 503 and records nothing. */
export class MessagingUnconfiguredError extends Error {
  readonly statusCode = 503;
  readonly code = 'messaging-unconfigured';
  constructor() {
    super(
      'Messaging is not configured on this server: set WA_PHONE_ID/WA_TOKEN or SMS_URL_TEMPLATE/SMS_KEY',
    );
    this.name = 'MessagingUnconfiguredError';
  }
}

/**
 * Real HTTP SMS gateway — the desktop used simple GET APIs (tripadasmsbox / ping4sms / mobileadz),
 * all of the shape `<url>?key=..&sender=..&mobile=..&text=..`. Configure `urlTemplate` with
 * {key}{sender}{mobile}{text} placeholders so any of those providers (or a new one) works by config.
 */
export class HttpSmsSender implements MessageSender {
  constructor(
    private cfg: { urlTemplate: string; key: string; sender: string; fetchImpl?: typeof fetch },
  ) {}
  async send(msg: OutboundMessage): Promise<SendResult> {
    const url = this.cfg.urlTemplate
      .replace('{key}', encodeURIComponent(this.cfg.key))
      .replace('{sender}', encodeURIComponent(this.cfg.sender))
      .replace('{mobile}', encodeURIComponent(msg.to))
      .replace('{text}', encodeURIComponent(msg.body));
    const f = this.cfg.fetchImpl ?? fetch;
    const res = await f(url, { signal: AbortSignal.timeout(12000) } as any);
    return { id: `sms-${Date.now()}`, status: res.ok ? 'accepted' : 'failed' };
  }
}

/** Real WhatsApp Cloud API (Meta Graph) — desktop UT_WAPP_WITH_API used graph.facebook.com/v22.0:
 *  text, approved templates, and document (invoice PDF) via /media upload → send. */
export class WhatsAppCloudSender implements MessageSender {
  private base: string;
  constructor(
    private cfg: {
      phoneNumberId: string;
      token: string;
      apiVersion?: string;
      fetchImpl?: typeof fetch;
    },
  ) {
    this.base = `https://graph.facebook.com/${cfg.apiVersion ?? 'v22.0'}`;
  }
  private get f(): typeof fetch {
    return this.cfg.fetchImpl ?? fetch;
  }
  private post(json: any): Promise<any> {
    return this.f(`${this.base}/${this.cfg.phoneNumberId}/messages`, {
      method: 'POST',
      headers: { authorization: `Bearer ${this.cfg.token}`, 'content-type': 'application/json' },
      body: JSON.stringify(json),
      signal: AbortSignal.timeout(15000),
    } as any);
  }
  /** Upload a PDF to /media and return the media id (Meta requires upload before sending a document). */
  private async uploadPdf(pdf: Buffer, filename: string): Promise<string | null> {
    const fd = new FormData();
    fd.append('messaging_product', 'whatsapp');
    fd.append('type', 'application/pdf');
    fd.append('file', new Blob([new Uint8Array(pdf)], { type: 'application/pdf' }), filename);
    const res = await this.f(`${this.base}/${this.cfg.phoneNumberId}/media`, {
      method: 'POST',
      headers: { authorization: `Bearer ${this.cfg.token}` },
      body: fd as any,
      signal: AbortSignal.timeout(20000),
    } as any);
    const j: any = await res.json().catch(() => ({}));
    return j?.id ?? null;
  }
  async send(msg: OutboundMessage): Promise<SendResult> {
    try {
      if (msg.template) {
        const t = msg.template;
        const res = await this.post({
          messaging_product: 'whatsapp',
          to: msg.to,
          type: 'template',
          template: {
            name: t.name,
            language: { code: t.lang ?? 'en' },
            ...(t.params?.length
              ? {
                  components: [
                    { type: 'body', parameters: t.params.map((p) => ({ type: 'text', text: p })) },
                  ],
                }
              : {}),
          },
        });
        return { id: `wa-tpl-${Date.now()}`, status: res.ok ? 'accepted' : 'failed' };
      }
      if (msg.document) {
        const id = await this.uploadPdf(msg.document.pdf, msg.document.filename);
        if (!id) return { id: 'wa-upload-failed', status: 'failed' };
        const res = await this.post({
          messaging_product: 'whatsapp',
          to: msg.to,
          type: 'document',
          document: {
            id,
            filename: msg.document.filename,
            caption: msg.document.caption ?? msg.body,
          },
        });
        return { id: `wa-doc-${Date.now()}`, status: res.ok ? 'accepted' : 'failed' };
      }
      const res = await this.post({
        messaging_product: 'whatsapp',
        to: msg.to,
        type: 'text',
        text: { body: msg.body },
      });
      return { id: `wa-${Date.now()}`, status: res.ok ? 'accepted' : 'failed' };
    } catch {
      return { id: 'wa-error', status: 'failed' };
    }
  }
}

/**
 * Pick a sender from environment config: the WhatsApp Cloud API (WA_PHONE_ID+WA_TOKEN) or an HTTP SMS gateway
 * (SMS_URL_TEMPLATE+SMS_KEY) when configured, so the feature goes live the moment the shop supplies credentials.
 *
 * Without credentials there is NO sender (`unconfigured`): the send routes answer 503 and record nothing. The
 * in-memory fake is used only when `MESSAGING_FAKE_MODE=1` is set and the process is not in production
 * (`NODE_ENV=production`), and it reports every send as `simulated` (N54 step 4, G33).
 */
/**
 * The environment variables `senderFromEnv` actually reads, declared HERE so the readiness report cannot
 * advertise names the code ignores. An earlier version of the readiness module named `SMS_BASE_URL` and
 * `SMS_TOKEN`, neither of which is read — an operator following that report would have set variables that
 * did nothing and concluded the integration was broken.
 */
export const WHATSAPP_ENV = ['WA_PHONE_ID', 'WA_TOKEN'] as const;
export const SMS_ENV = ['SMS_URL_TEMPLATE', 'SMS_KEY'] as const;
/** Optional, with a documented default rather than a hard requirement. */
export const MESSAGING_OPTIONAL_ENV = ['WA_API_VERSION', 'SMS_SENDER'] as const;
/** Test-only switch for the simulating fake sender; ignored (and refused at start-up) in production. */
export const MESSAGING_FAKE_MODE_ENV = 'MESSAGING_FAKE_MODE';

export type MessagingMode = 'whatsapp-cloud' | 'http-sms' | 'simulated' | 'unconfigured';

/** True when the explicit fake mode is on and allowed (never in production). */
export function messagingFakeModeAllowed(env: NodeJS.ProcessEnv = process.env): boolean {
  return env[MESSAGING_FAKE_MODE_ENV] === '1' && env.NODE_ENV !== 'production';
}

export function senderFromEnv(env: NodeJS.ProcessEnv = process.env): {
  sender: MessageSender | null;
  mode: MessagingMode;
} {
  if (env.WA_PHONE_ID && env.WA_TOKEN)
    return {
      sender: new WhatsAppCloudSender({
        phoneNumberId: env.WA_PHONE_ID,
        token: env.WA_TOKEN,
        apiVersion: env.WA_API_VERSION,
      }),
      mode: 'whatsapp-cloud',
    };
  if (env.SMS_URL_TEMPLATE && env.SMS_KEY)
    return {
      sender: new HttpSmsSender({
        urlTemplate: env.SMS_URL_TEMPLATE,
        key: env.SMS_KEY,
        sender: env.SMS_SENDER ?? 'JEWELL',
      }),
      mode: 'http-sms',
    };
  if (messagingFakeModeAllowed(env)) return { sender: new FakeMessageSender(), mode: 'simulated' };
  return { sender: null, mode: 'unconfigured' };
}

/** The `/integrations/status` messaging entry, in words an operator can act on (never "wired" for a fake). */
export function messagingStatus(env: NodeJS.ProcessEnv = process.env): {
  provider: MessagingMode;
  status: string;
} {
  const { mode } = senderFromEnv(env);
  return {
    provider: mode,
    status:
      mode === 'unconfigured'
        ? 'sends are refused — set WA_PHONE_ID/WA_TOKEN or SMS_URL_TEMPLATE/SMS_KEY to enable'
        : mode === 'simulated'
          ? 'test mode (MESSAGING_FAKE_MODE=1, not production) — nothing is delivered'
          : 'provider acceptance is reported; delivery is not confirmed',
  };
}

/**
 * Best-effort send: never throws. `ok` is true only when a real provider accepted the message; a simulation is
 * `{ok:false, status:'simulated'}` and a failure `{ok:false, status:'failed', error}`.
 */
export async function notify(sender: MessageSender, msg: OutboundMessage): Promise<NotifyResult> {
  try {
    if (!msg.to) return { ok: false, status: 'failed', error: 'no recipient' };
    const r = await sender.send(msg);
    if (r.status === 'accepted') return { ok: true, status: 'accepted', id: r.id };
    if (r.status === 'simulated') return { ok: false, status: 'simulated', id: r.id };
    return { ok: false, status: 'failed', error: 'send failed', id: r.id };
  } catch (e: any) {
    return { ok: false, status: 'failed', error: e?.message ?? 'send error' };
  }
}

export interface MessageAttemptScope {
  tenantId: string;
  coCode: string;
  lcCode?: string | null;
}

export interface MessageAttemptOptions {
  idempotencyKey: string;
  templateKind: string;
}

export interface MessageAttemptResult extends NotifyResult {
  deduplicated: boolean;
}

interface ExistingAttempt {
  status: string;
  provider_reference: string | null;
  failure_reason: string | null;
}

/**
 * Claim the tenant/idempotency key before contacting the provider. The unique constraint makes the
 * operation at-most-once across concurrent requests: a duplicate returns the first attempt's stored
 * result and never calls the provider again. The initial pending row also records crash/interruption
 * attempts rather than silently losing them.
 */
export async function notifyWithAttemptLog(
  prisma: any,
  sender: MessageSender,
  scope: MessageAttemptScope,
  msg: OutboundMessage,
  options: MessageAttemptOptions,
): Promise<MessageAttemptResult> {
  const idempotencyKey = String(options.idempotencyKey ?? '').trim();
  const templateKind = String(options.templateKind ?? '').trim();
  if (!idempotencyKey)
    return {
      ok: false,
      status: 'failed',
      error: 'idempotency key is required',
      deduplicated: false,
    };
  if (!templateKind)
    return { ok: false, status: 'failed', error: 'template kind is required', deduplicated: false };

  const claimed = await withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const inserted = (await tx.$queryRawUnsafe(
      `INSERT INTO "message_attempt_log"
         ("tenant_id","co_code","lc_code","channel","recipient","template_kind",
          "idempotency_key","status")
       VALUES ($1,$2,$3,$4,$5,$6,$7,'pending')
       ON CONFLICT ("tenant_id","idempotency_key") DO NOTHING
       RETURNING "id"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode ?? null,
      msg.channel,
      msg.to,
      templateKind,
      idempotencyKey,
    )) as Array<{ id: bigint }>;
    if (inserted.length) return null;
    const existing = (await tx.$queryRawUnsafe(
      // The tenant predicate is EXPLICIT and not left to row level security alone. The unique constraint is
      // on (tenant_id, idempotency_key), so a key can legitimately exist for several tenants; filtering on the
      // key alone would return whichever row RLS happened to expose. Isolation must not rest on one mechanism.
      `SELECT "status","provider_reference","failure_reason"
         FROM "message_attempt_log"
        WHERE "tenant_id"=$1 AND "idempotency_key"=$2
        LIMIT 1`,
      scope.tenantId,
      idempotencyKey,
    )) as ExistingAttempt[];
    return existing[0] ?? { status: 'pending', provider_reference: null, failure_reason: null };
  });

  if (claimed) {
    // Replay the stored outcome. `sent` is how attempts were recorded before N54 step 4, when it meant "the
    // provider accepted it"; `delivered` is reserved for a future provider callback. Both read as accepted.
    const stored = String(claimed.status ?? '');
    const status: NotifyResult['status'] =
      stored === 'accepted' || stored === 'sent' || stored === 'delivered'
        ? 'accepted'
        : stored === 'simulated'
          ? 'simulated'
          : stored === 'pending'
            ? 'pending'
            : 'failed';
    return {
      ok: status === 'accepted',
      status,
      id: claimed.provider_reference ?? undefined,
      error:
        status === 'accepted' || status === 'simulated'
          ? undefined
          : (claimed.failure_reason ?? 'attempt already in progress'),
      deduplicated: true,
    };
  }

  const result = await notify(sender, msg);
  await withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await tx.$executeRawUnsafe(
      // Explicit tenant predicate: without it this UPDATE could overwrite another tenant's delivery record
      // when idempotency keys collide, which keys derived from voucher identifiers do routinely.
      `UPDATE "message_attempt_log"
          SET "status"=$1,"provider_reference"=$2,"failure_reason"=$3
        WHERE "tenant_id"=$4 AND "idempotency_key"=$5`,
      result.status,
      result.id ?? null,
      result.status === 'failed' ? (result.error ?? 'send failed') : null,
      scope.tenantId,
      idempotencyKey,
    );
  });
  return { ...result, deduplicated: false };
}

export interface UpiParams {
  pa: string; // payee VPA
  pn: string; // payee name
  am?: number; // amount
  tn?: string; // transaction note
  cu?: string; // currency (default INR)
  tr?: string; // transaction ref
}

/** Build an NPCI UPI deep-link / QR payload (pure). Image rendering is done by a QR encoder. */
export function buildUpiUri(p: UpiParams): string {
  if (!p.pa) throw new Error('UPI payee address (pa) is required');
  const q: string[] = [
    `pa=${encodeURIComponent(p.pa)}`,
    `pn=${encodeURIComponent(p.pn)}`,
    `cu=${encodeURIComponent(p.cu ?? 'INR')}`,
  ];
  if (p.am != null) q.push(`am=${encodeURIComponent(p.am.toFixed(2))}`);
  if (p.tr) q.push(`tr=${encodeURIComponent(p.tr)}`);
  if (p.tn) q.push(`tn=${encodeURIComponent(p.tn)}`);
  return `upi://pay?${q.join('&')}`;
}

export class MailRecipientError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'MailValidationError';
  }
}

/**
 * Pre-flight for sending a document by e-mail, in the desktop's own order.
 *
 * `Module_Save.cs` checks the COMPANY's mail id / API credentials first and reports
 * `Please Update Company Mail Id and Api Then Try...`; only when the company is configured does it
 * complain about a missing party address with `Please Insert e Mail id in Party Master then Try...`.
 * Keeping that order matters: with neither configured the desktop shows the company message.
 */
export function assertMailable(input: {
  companyEmail?: string | null;
  companyApiKey?: string | null;
  partyEmail?: string | null;
}): void {
  const company = String(input.companyEmail ?? '').trim();
  const api = String(input.companyApiKey ?? '').trim();
  if (!company || !api) {
    throw new MailRecipientError(DESKTOP_MESSAGES.COMPANY_MAIL_NOT_CONFIGURED);
  }
  if (!String(input.partyEmail ?? '').trim()) {
    throw new MailRecipientError(DESKTOP_MESSAGES.PARTY_EMAIL_MISSING);
  }
}

/**
 * Shared field guards for the desktop's messaging screens.
 *
 * `UT_SMS.cs` refuses to send with an empty body (`tMsg.Text = ''`); `MS_AUTO_ITEM.cs` refuses a flag
 * that is neither `Y` nor `N`. Both are pure value checks, so they live here as reusable assertions
 * rather than duplicated per caller.
 */
export function assertMessageBody(body: unknown): void {
  if (!String(body ?? '').trim())
    throw new MailRecipientError(DESKTOP_MESSAGES.MESSAGE_BODY_REQUIRED);
}

/** Desktop `Y`/`N` flag validation. Case-insensitive, because the desktop compares with `false` (text). */
export function assertYesNo(value: unknown): void {
  const flag = String(value ?? '')
    .trim()
    .toUpperCase();
  if (flag !== 'Y' && flag !== 'N') {
    throw new MailRecipientError(DESKTOP_MESSAGES.YES_OR_NO_REQUIRED);
  }
}
