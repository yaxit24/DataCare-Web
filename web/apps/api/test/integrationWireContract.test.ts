import { describe, expect, it } from 'vitest';
import {
  CharteredInfoIrnTransport,
  duplicateIrnFrom,
  NIC_DUPLICATE_IRN_CODE,
  parseNicErrors,
} from '../src/modules/einvoice/einvoice.js';
import {
  HttpSmsSender,
  senderFromEnv,
  SMS_ENV,
  WHATSAPP_ENV,
  WhatsAppCloudSender,
} from '../src/modules/integrations/messaging.js';
import { REQUIRED_ENV } from '../src/modules/integrations/readiness.js';

/**
 * WIRE CONTRACT TESTS for the credential-gated integrations.
 *
 * These exist to answer one question honestly: *will it work when the credentials arrive?*
 *
 * Live credentials cannot be used here, but the request is fully determined by the code — so every
 * transport takes an injectable `fetch`, and these tests assert the exact URL, method, headers and body
 * the provider will receive, plus how each documented response and error shape is interpreted. What they
 * prove is that the integration speaks the right protocol. What they cannot prove is that a particular
 * shop's credentials are valid; that is what `POST /einvoice/test-auth` is for once a key exists.
 *
 * Endpoint and parameter names come from the providers' published contracts, matching the desktop's own
 * GSP (Chartered Info) and the Meta Graph API the desktop's WhatsApp utility moved to.
 */

/** Capture calls without any network access. */
function recorder(responses: unknown[]) {
  const calls: Array<{ url: string; init: any }> = [];
  let index = 0;
  const fetchImpl = (async (url: any, init: any) => {
    calls.push({ url: String(url), init: init ?? {} });
    const body = responses[Math.min(index, responses.length - 1)];
    index += 1;
    return {
      ok: true,
      status: 200,
      json: async () => body,
      text: async () => JSON.stringify(body),
    } as any;
  }) as unknown as typeof fetch;
  return { calls, fetchImpl };
}

const gspConfig = {
  aspId: 'ASP1',
  aspPassword: 'p@ss word',
  gstin: '24ABCDE1234F1Z5',
  userId: 'USER1',
  eInvPwd: 'einv/pwd',
};

const payload = { Version: '1.1' } as never;

describe('GSP e-invoice wire contract', () => {
  it('authenticates against the sandbox host with every required parameter, url-encoded', async () => {
    const { calls, fetchImpl } = recorder([
      { AuthToken: 'TOKEN-1', TokenExpiry: '2099-01-01 00:00:00' },
    ]);
    const transport = new CharteredInfoIrnTransport({ ...gspConfig, sandbox: true, fetchImpl });
    expect(await transport.authToken()).toBe('TOKEN-1');

    const url = new URL(calls[0]!.url);
    expect(url.origin).toBe('https://gstsandbox.charteredinfo.com');
    expect(url.pathname).toBe('/eivital/dec/v1.04/auth');
    expect(url.searchParams.get('aspid')).toBe('ASP1');
    // Values with spaces and slashes must survive encoding intact.
    expect(url.searchParams.get('password')).toBe('p@ss word');
    expect(url.searchParams.get('eInvPwd')).toBe('einv/pwd');
    expect(url.searchParams.get('Gstin')).toBe('24ABCDE1234F1Z5');
    expect(url.searchParams.get('User_name')).toBe('USER1');
  });

  it('uses the production host only when sandbox is explicitly false', async () => {
    const { calls, fetchImpl } = recorder([{ AuthToken: 'T' }]);
    await new CharteredInfoIrnTransport({ ...gspConfig, sandbox: false, fetchImpl }).authToken();
    expect(new URL(calls[0]!.url).origin).toBe('https://einvapi.charteredinfo.com');
  });

  it('posts the IRN payload as JSON to the eicore endpoint with the auth token', async () => {
    const { calls, fetchImpl } = recorder([
      { AuthToken: 'TOKEN-1', TokenExpiry: '2099-01-01 00:00:00' },
      { Data: { Irn: 'a'.repeat(64), AckNo: '112', AckDt: '2026-04-05', SignedQRCode: 'QR' } },
    ]);
    const transport = new CharteredInfoIrnTransport({ ...gspConfig, sandbox: true, fetchImpl });
    const result = await transport.generateIRN(payload);

    expect(result.Irn).toBe('a'.repeat(64));
    expect(result.SignedQRCode).toBe('QR');
    const invoice = calls[1]!;
    const url = new URL(invoice.url);
    expect(url.pathname).toBe('/eicore/dec/v1.03/Invoice');
    expect(url.searchParams.get('AuthToken')).toBe('TOKEN-1');
    expect(url.searchParams.get('QrCodeSize')).toBe('250');
    expect(invoice.init.method).toBe('POST');
    expect(invoice.init.headers['content-type']).toBe('application/json');
    expect(JSON.parse(invoice.init.body)).toEqual({ Version: '1.1' });
  });

  it('reuses the cached token instead of re-authenticating per call', async () => {
    const { calls, fetchImpl } = recorder([
      { AuthToken: 'TOKEN-1', TokenExpiry: '2099-01-01 00:00:00' },
      { Data: { Irn: 'b'.repeat(64) } },
      { Data: { Irn: 'c'.repeat(64) } },
    ]);
    const transport = new CharteredInfoIrnTransport({ ...gspConfig, sandbox: true, fetchImpl });
    await transport.generateIRN(payload);
    await transport.generateIRN(payload);
    // 1 auth + 2 invoices, not 2 auths: the portal rate-limits authentication.
    const auths = calls.filter((c) => c.url.includes('/auth')).length;
    expect(auths).toBe(1);
    expect(calls.length).toBe(3);
  });

  it('treats a duplicate-IRN error as success and returns the portal IRN', async () => {
    const existing = 'd'.repeat(64);
    const { fetchImpl } = recorder([
      { AuthToken: 'T', TokenExpiry: '2099-01-01 00:00:00' },
      {
        Status: '0',
        ErrorDetails: [
          { ErrorCode: NIC_DUPLICATE_IRN_CODE, ErrorMessage: `Duplicate IRN ${existing}` },
        ],
      },
    ]);
    const transport = new CharteredInfoIrnTransport({ ...gspConfig, sandbox: true, fetchImpl });
    const result = await transport.generateIRN(payload);
    // A timeout followed by a retry produces exactly this; failing here would strand a registered bill.
    expect(result.Irn).toBe(existing);
    expect(result.duplicate).toBe(true);
    expect(result.Status).toBe('ACT');
  });

  it('re-authenticates once on an expired token, then gives up rather than resubmitting forever', async () => {
    const calls: string[] = [];
    let step = 0;
    const fetchImpl = (async (url: any) => {
      calls.push(String(url));
      step += 1;
      // auth, invoice(expired), auth, invoice(expired again)
      const body =
        step === 1 || step === 3
          ? { AuthToken: `T${step}`, TokenExpiry: '2099-01-01 00:00:00' }
          : { ErrorDetails: [{ ErrorCode: '1005', ErrorMessage: 'Invalid token' }] };
      return { ok: true, status: 200, json: async () => body } as any;
    }) as unknown as typeof fetch;

    const transport = new CharteredInfoIrnTransport({ ...gspConfig, sandbox: true, fetchImpl });
    await expect(transport.generateIRN(payload)).rejects.toThrow(/1005/);
    // Exactly two submissions, never an unbounded loop against the tax portal.
    expect(calls.filter((u) => u.includes('/Invoice')).length).toBe(2);
  });

  it('surfaces the NIC error code and message rather than a raw JSON blob', async () => {
    const { fetchImpl } = recorder([
      { AuthToken: 'T', TokenExpiry: '2099-01-01 00:00:00' },
      {
        ErrorDetails: [
          { ErrorCode: '2172', ErrorMessage: 'For intra state transaction IGST is invalid' },
        ],
      },
    ]);
    const transport = new CharteredInfoIrnTransport({ ...gspConfig, sandbox: true, fetchImpl });
    await expect(transport.generateIRN(payload)).rejects.toThrow(
      /2172: For intra state transaction IGST is invalid/,
    );
  });

  it('posts a cancellation with the NIC reason and remark fields', async () => {
    const { calls, fetchImpl } = recorder([
      { AuthToken: 'T', TokenExpiry: '2099-01-01 00:00:00' },
      { Data: { Irn: 'e'.repeat(64), CancelDate: '2026-04-06' } },
    ]);
    const transport = new CharteredInfoIrnTransport({ ...gspConfig, sandbox: true, fetchImpl });
    const result = await transport.cancelIRN('e'.repeat(64), '3', 'Order cancelled');
    expect(result.Status).toBe('CNL');
    const cancel = calls[1]!;
    expect(new URL(cancel.url).pathname).toBe('/eicore/dec/v1.03/Cancel');
    expect(JSON.parse(cancel.init.body)).toEqual({
      Irn: 'e'.repeat(64),
      CnlRsn: '3',
      CnlRem: 'Order cancelled',
    });
  });
});

describe('NIC error parsing', () => {
  it('reads errors from an array, from a JSON string, and from a nested Data field', () => {
    expect(parseNicErrors({ ErrorDetails: [{ ErrorCode: '1', ErrorMessage: 'a' }] })).toEqual([
      { code: '1', message: 'a' },
    ]);
    // NIC sometimes returns the same structure as a string inside Data.
    expect(parseNicErrors({ Data: '[{"ErrorCode":"2","ErrorMessage":"b"}]' })).toEqual([
      { code: '2', message: 'b' },
    ]);
    expect(parseNicErrors('not json at all')).toEqual([]);
    expect(parseNicErrors(null)).toEqual([]);
  });

  it('extracts the existing IRN only when the duplicate code is present', () => {
    const irn = 'f'.repeat(64);
    expect(duplicateIrnFrom({ ErrorDetails: [{ ErrorCode: '2150', ErrorMessage: irn }] })).toEqual({
      irn,
    });
    // A different error that happens to contain a hex string must not be read as a duplicate.
    expect(
      duplicateIrnFrom({ ErrorDetails: [{ ErrorCode: '2172', ErrorMessage: irn }] }),
    ).toBeNull();
  });
});

describe('WhatsApp Cloud API wire contract', () => {
  it('posts a template message to the phone-number id with a bearer token', async () => {
    const { calls, fetchImpl } = recorder([{ messages: [{ id: 'wamid.1' }] }]);
    const sender = new WhatsAppCloudSender({ phoneNumberId: '1234', token: 'TKN', fetchImpl });
    const result = await sender.send({
      to: '919812345670',
      body: 'ignored for templates',
      template: { name: 'bill_ready', lang: 'en', params: ['INV-1', '76,225'] },
    } as never);

    expect(result.status).toBe('sent');
    const call = calls[0]!;
    expect(call.url).toBe('https://graph.facebook.com/v22.0/1234/messages');
    expect(call.init.headers.authorization).toBe('Bearer TKN');
    const body = JSON.parse(call.init.body);
    expect(body.messaging_product).toBe('whatsapp');
    expect(body.to).toBe('919812345670');
    expect(body.type).toBe('template');
    expect(body.template.name).toBe('bill_ready');
    expect(body.template.language).toEqual({ code: 'en' });
    // Parameters must be positional text components, in order.
    expect(body.template.components[0].parameters).toEqual([
      { type: 'text', text: 'INV-1' },
      { type: 'text', text: '76,225' },
    ]);
  });
});

describe('SMS gateway wire contract', () => {
  it('builds the gateway URL from the configured base, sender and message', async () => {
    const { calls, fetchImpl } = recorder([{ ok: true }]);
    // The desktop's gateways were all `<url>?key=..&sender=..&mobile=..&text=..`, so the template keeps
    // any of them (or a new provider) working by configuration alone.
    const sender = new HttpSmsSender({
      urlTemplate:
        'https://sms.example.com/send?key={key}&sender={sender}&mobile={mobile}&text={text}',
      key: 'KEY-1',
      sender: 'JEWEL',
      fetchImpl,
    });
    const result = await sender.send({ to: '919812345670', body: 'Rate today 6200' } as never);
    expect(result.status).toBe('sent');
    const url = new URL(calls[0]!.url);
    expect(url.origin + url.pathname).toBe('https://sms.example.com/send');
    expect(url.searchParams.get('key')).toBe('KEY-1');
    expect(url.searchParams.get('sender')).toBe('JEWEL');
    expect(url.searchParams.get('mobile')).toBe('919812345670');
    // The message must survive encoding with its spaces intact.
    expect(url.searchParams.get('text')).toBe('Rate today 6200');
  });
});

describe('credential name drift', () => {
  /**
   * The readiness report tells an operator which variables to set. If those names differ from the ones
   * the factories read, the operator sets variables that do nothing and concludes the integration is
   * broken. This test is the guard: the lists must be the SAME objects, not merely similar.
   */
  it('advertises exactly the variables the factories read', () => {
    expect(REQUIRED_ENV.whatsapp).toBe(WHATSAPP_ENV);
    expect(REQUIRED_ENV.sms).toBe(SMS_ENV);
    expect([...WHATSAPP_ENV]).toEqual(['WA_PHONE_ID', 'WA_TOKEN']);
    expect([...SMS_ENV]).toEqual(['SMS_URL_TEMPLATE', 'SMS_KEY']);
  });

  it('selects the real sender the moment the advertised variables are present', () => {
    expect(senderFromEnv({}).mode).toBe('fake');
    const whatsappEnv: NodeJS.ProcessEnv = {};
    for (const name of WHATSAPP_ENV) whatsappEnv[name] = 'x';
    expect(senderFromEnv(whatsappEnv).mode).toBe('whatsapp-cloud');
    const smsEnv: NodeJS.ProcessEnv = {};
    for (const name of SMS_ENV) smsEnv[name] = 'x';
    expect(senderFromEnv(smsEnv).mode).toBe('http-sms');
  });
});
