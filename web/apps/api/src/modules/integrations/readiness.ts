import { GSP_ENV, GSP_OPTIONAL_ENV, testGspAuth } from '../einvoice/einvoice.js';
import { MESSAGING_OPTIONAL_ENV, SMS_ENV, WHATSAPP_ENV } from './messaging.js';
/**
 * Integration readiness — one place that answers "what will work the moment the shop supplies X?".
 *
 * Every desktop hardware and third-party integration is implemented behind an interface with an
 * environment-driven transport, so nothing needs a code change when credentials or devices arrive. What
 * was missing was a way to *check* that claim. This module reports, per integration:
 *
 *   • `ready`                — implemented and configured; it will operate now
 *   • `awaiting-credentials` — implemented, but named variables are unset (the names are returned)
 *   • `awaiting-hardware`    — implemented, but the device is not attached or the browser lacks the API
 *   • `disabled-by-setting`  — the company's own configuration switches it off, matching the desktop
 *
 * Two rules this module keeps:
 *  1. **No secret values are ever returned**, only whether a variable is present. A GSTIN is masked.
 *  2. **Nothing is reported ready on the strength of code alone.** A missing credential is
 *     `awaiting-credentials`, never `ready`, because a fake transport succeeding proves nothing about a
 *     real one.
 */

export type ReadinessState =
  'ready' | 'awaiting-credentials' | 'awaiting-hardware' | 'disabled-by-setting';

export interface IntegrationReadiness {
  id: string;
  /** Desktop origin, so an operator can match this against the behaviour they know. */
  desktopSource: string;
  state: ReadinessState;
  /** What is implemented and will run unchanged once the blocker clears. */
  implemented: string;
  /** Environment variables required, with presence only — never values. */
  requiredEnv?: Record<string, boolean>;
  /** Which required variables are still unset. */
  missingEnv?: string[];
  /** For device integrations: what the operator or installer must do. */
  blockedBy?: string;
  /** Free-form detail: mode, host, masked identifiers. */
  detail?: Record<string, unknown>;
}

const presence = (
  env: NodeJS.ProcessEnv,
  names: readonly string[],
): { vars: Record<string, boolean>; missing: string[] } => {
  const vars: Record<string, boolean> = {};
  const missing: string[] = [];
  for (const name of names) {
    const present = !!env[name];
    vars[name] = present;
    if (!present) missing.push(name);
  }
  return { vars, missing };
};

export interface ReadinessContext {
  env?: NodeJS.ProcessEnv;
  /** `CO_SET.WEIGHT_PORT` — `'0'` disables scale capture, as the desktop does. */
  weightPort?: string | null;
  /** Company e-mail/API configuration, from the company master rather than the request. */
  companyMailConfigured?: boolean;
}

/**
 * Credential sets, IMPORTED from the modules that read them rather than restated here.
 *
 * This indirection is the fix for a real defect: this module previously named `WHATSAPP_PHONE_ID`,
 * `WHATSAPP_TOKEN`, `SMS_BASE_URL` and `SMS_TOKEN`, while the factories read `WA_PHONE_ID`, `WA_TOKEN`,
 * `SMS_URL_TEMPLATE` and `SMS_KEY`. An operator following the readiness report would have set variables
 * that were never read. Importing the lists makes drift impossible.
 */
export const REQUIRED_ENV = {
  einvoice: GSP_ENV,
  whatsapp: WHATSAPP_ENV,
  sms: SMS_ENV,
} as const;

/** Optional variables, reported for completeness but never blocking readiness. */
export const OPTIONAL_ENV = {
  einvoice: GSP_OPTIONAL_ENV,
  messaging: MESSAGING_OPTIONAL_ENV,
} as const;

export function integrationReadiness(context: ReadinessContext = {}): IntegrationReadiness[] {
  const env = context.env ?? process.env;
  const report: IntegrationReadiness[] = [];

  // ---- Weighing scale ------------------------------------------------------------------------
  const weightPort = String(context.weightPort ?? '').trim();
  const scaleDisabled = weightPort === '' || weightPort === '0';
  report.push({
    id: 'weighing-scale',
    desktopSource: 'TR_TAG_OPBL.cs WeightScal()/Timer1_Tick',
    state: scaleDisabled ? 'disabled-by-setting' : 'awaiting-hardware',
    implemented:
      'Serial framing (CH340 9600/8-N-1, fallback 2400/7-N-1), the desktop character filter with its ' +
      '20-character window, three-decimal formatting, and the net-weight-cell focus condition.',
    blockedBy: scaleDisabled
      ? 'CO_SET.WEIGHT_PORT is 0 or unset for this company, which switches capture off exactly as the desktop does.'
      : 'A CH340 scale must be attached and the operator must grant the port via WebSerial, or the loopback agent must be running.',
    detail: { weightPort: weightPort || null, signIsDropped: true },
  });

  // ---- Barcode / tag scanner ----------------------------------------------------------------
  report.push({
    id: 'barcode-scanner',
    desktopSource: 'tag cells across TR_SALE / TR_TAG_OPBL (no dedicated driver in the desktop)',
    state: 'ready',
    implemented:
      'Nothing device-specific is required: the desktop treats a scanner as a keyboard that types the ' +
      'tag then presses Enter, and the web grids already accept exactly that into the tag cell with ' +
      'the same Enter-advances-cell behaviour.',
  });

  // ---- Webcam / image capture ---------------------------------------------------------------
  report.push({
    id: 'image-capture',
    desktopSource: 'UT_WEB_CAM.cs, MS_ACCT.cs PicImage',
    state: 'awaiting-hardware',
    implemented:
      'Capture through getUserMedia and upload into the database (AC_IMAGE / repair images). The web ' +
      'stores images in the database rather than the LAN share the desktop writes to, which is why the ' +
      "desktop's share-unreachable error has no web equivalent.",
    blockedBy: 'A camera must be present and the operator must grant permission.',
  });

  // ---- e-Invoice (IRN) ----------------------------------------------------------------------
  const einvoice = presence(env, REQUIRED_ENV.einvoice);
  const sandbox = env.GSP_SANDBOX !== '0';
  report.push({
    id: 'einvoice-irn',
    desktopSource: 'TR_SL_EBILL.cs',
    state: einvoice.missing.length ? 'awaiting-credentials' : 'ready',
    implemented:
      'IRN generation, signed QR persistence into E_DATA.QR_DATA, and cancellation, against the ' +
      'Chartered Info GSP. Without credentials a clearly-labelled fake transport is used so the flow is ' +
      'exercisable, and it is never reported ready.',
    requiredEnv: einvoice.vars,
    missingEnv: einvoice.missing,
    detail: {
      mode: einvoice.missing.length ? 'fake' : sandbox ? 'sandbox' : 'production',
      host: sandbox ? 'gstsandbox.charteredinfo.com' : 'einvapi.charteredinfo.com',
      gstin: env.GSP_GSTIN ? `${env.GSP_GSTIN.slice(0, 2)}••••${env.GSP_GSTIN.slice(-2)}` : null,
    },
  });

  // ---- WhatsApp -----------------------------------------------------------------------------
  const whatsapp = presence(env, REQUIRED_ENV.whatsapp);
  report.push({
    id: 'whatsapp',
    desktopSource: 'UT_WHATSAPP.cs (Selenium browser automation, replaced by the Graph API)',
    state: whatsapp.missing.length ? 'awaiting-credentials' : 'ready',
    implemented:
      'Template send through the Meta Graph Cloud API with a per-attempt log keyed by an idempotency ' +
      'key, so a retry neither re-sends nor duplicates. Templates come from MSG_MAST exactly as the ' +
      'desktop stores them.',
    requiredEnv: whatsapp.vars,
    missingEnv: whatsapp.missing,
  });

  // ---- SMS ----------------------------------------------------------------------------------
  const sms = presence(env, REQUIRED_ENV.sms);
  report.push({
    id: 'sms',
    desktopSource: 'UT_SMS.cs',
    state: sms.missing.length ? 'awaiting-credentials' : 'ready',
    implemented:
      'Gateway send behind the same interface and attempt log as WhatsApp, with the desktop template ' +
      'substitution and its empty-body guard.',
    requiredEnv: sms.vars,
    missingEnv: sms.missing,
  });

  // ---- Company e-mail ------------------------------------------------------------------------
  report.push({
    id: 'company-email',
    desktopSource: 'Module_Save.cs mail path',
    state: context.companyMailConfigured ? 'ready' : 'awaiting-credentials',
    implemented:
      "Document mail-out with the desktop's own pre-flight order — the company's mail id and API are " +
      'checked before the party address, so an unconfigured company reports the company message first.',
    blockedBy: context.companyMailConfigured
      ? undefined
      : "The company master's mail id and API key must be set.",
  });

  // ---- Printing ------------------------------------------------------------------------------
  report.push({
    id: 'printing',
    desktopSource: 'Crystal Reports print paths',
    state: 'ready',
    implemented:
      'All 254 extracted Crystal layouts render server-side to positioned HTML and PDF, with retained ' +
      'checksum baselines so a layout change is detected. Any OS-level printer works through the ' +
      'browser print path; no driver integration is required.',
  });

  return report;
}

/** Convenience roll-up for dashboards and the ops endpoint. */
export function readinessSummary(report: IntegrationReadiness[]): Record<ReadinessState, number> {
  const summary: Record<ReadinessState, number> = {
    ready: 0,
    'awaiting-credentials': 0,
    'awaiting-hardware': 0,
    'disabled-by-setting': 0,
  };
  for (const entry of report) summary[entry.state] += 1;
  return summary;
}

export interface CredentialCheck {
  id: string;
  /** `ok` proven by a live round-trip, `not-configured`, `failed`, or `unverifiable` with a reason. */
  result: 'ok' | 'not-configured' | 'failed' | 'unverifiable';
  detail: string;
}

/**
 * Verify supplied credentials with a real round-trip, so "the credentials work" is proven rather than
 * assumed the moment a shop provides them.
 *
 * Each provider is checked with the cheapest call that authenticates and changes nothing:
 *  • GSP  — the auth endpoint, which returns a token and no side effect.
 *  • WhatsApp — a GET on the phone-number node, which 200s only with a valid token.
 *  • SMS  — reported `unverifiable`. The desktop's gateways are plain URL calls with no auth-check
 *    endpoint, so the only way to test one is to send a real chargeable message. Claiming `ok` without
 *    that would be a guess, and sending silently would cost the shop money and reach a real handset.
 */
export async function verifyIntegrationCredentials(
  context: { env?: NodeJS.ProcessEnv; fetchImpl?: typeof fetch } = {},
): Promise<CredentialCheck[]> {
  const env = context.env ?? process.env;
  const fetchImpl = context.fetchImpl ?? fetch;
  const checks: CredentialCheck[] = [];

  // ---- e-Invoice / GSP -----------------------------------------------------------------------
  const gsp = await testGspAuth(env, context.fetchImpl);
  checks.push({
    id: 'einvoice-irn',
    result: gsp.ok ? 'ok' : GSP_ENV.every((n) => env[n]) ? 'failed' : 'not-configured',
    detail: gsp.detail,
  });

  // ---- WhatsApp ------------------------------------------------------------------------------
  if (!WHATSAPP_ENV.every((name) => env[name])) {
    checks.push({
      id: 'whatsapp',
      result: 'not-configured',
      detail: `Set ${WHATSAPP_ENV.join(' and ')} to enable WhatsApp.`,
    });
  } else {
    const version = env.WA_API_VERSION ?? 'v22.0';
    try {
      const response = await fetchImpl(
        `https://graph.facebook.com/${version}/${env.WA_PHONE_ID}?fields=display_phone_number`,
        {
          headers: { authorization: `Bearer ${env.WA_TOKEN}` },
          signal: AbortSignal.timeout(12_000),
        } as never,
      );
      const body: any = await response.json().catch(() => ({}));
      if (response.ok && body?.id) {
        checks.push({
          id: 'whatsapp',
          result: 'ok',
          detail: `Authenticated phone-number id ${String(body.id)}.`,
        });
      } else {
        checks.push({
          id: 'whatsapp',
          result: 'failed',
          detail: String(body?.error?.message ?? `Graph API returned ${response.status}.`),
        });
      }
    } catch (error) {
      checks.push({
        id: 'whatsapp',
        result: 'failed',
        detail: `Could not reach the Graph API: ${(error as Error).message}`,
      });
    }
  }

  // ---- SMS -----------------------------------------------------------------------------------
  checks.push({
    id: 'sms',
    result: SMS_ENV.every((name) => env[name]) ? 'unverifiable' : 'not-configured',
    detail: SMS_ENV.every((name) => env[name])
      ? 'Configured. These gateways expose no authentication endpoint, so the only real test is sending a chargeable message to a live handset — done deliberately from the messaging screen, not by a health check.'
      : `Set ${SMS_ENV.join(' and ')} to enable SMS.`,
  });

  return checks;
}
