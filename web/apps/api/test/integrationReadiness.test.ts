import { describe, expect, it } from 'vitest';
import {
  integrationReadiness,
  readinessSummary,
  REQUIRED_ENV,
  verifyIntegrationCredentials,
} from '../src/modules/integrations/readiness.js';

/**
 * Readiness must be honest in both directions: it may not claim an integration works without its
 * credentials, and it may not hide that the code is finished when only a credential is missing.
 */
describe('integration readiness', () => {
  const bare: NodeJS.ProcessEnv = {};

  it('reports credential-gated integrations as awaiting-credentials, never ready', () => {
    const report = integrationReadiness({ env: bare, weightPort: 'COM3' });
    for (const id of ['einvoice-irn', 'whatsapp', 'sms']) {
      const entry = report.find((r) => r.id === id);
      expect(entry?.state).toBe('awaiting-credentials');
      expect(entry?.missingEnv?.length).toBeGreaterThan(0);
    }
  });

  it('names the exact variables that are missing', () => {
    const report = integrationReadiness({ env: bare });
    const einvoice = report.find((r) => r.id === 'einvoice-irn');
    expect(einvoice?.missingEnv).toEqual([...REQUIRED_ENV.einvoice]);
  });

  it('flips to ready once every variable is supplied', () => {
    const env: NodeJS.ProcessEnv = {};
    for (const name of REQUIRED_ENV.whatsapp) env[name] = 'supplied';
    const entry = integrationReadiness({ env }).find((r) => r.id === 'whatsapp');
    expect(entry?.state).toBe('ready');
    expect(entry?.missingEnv).toEqual([]);
  });

  it('never returns a secret value, only presence, and masks the GSTIN', () => {
    const env: NodeJS.ProcessEnv = {};
    for (const name of REQUIRED_ENV.einvoice) env[name] = 'SUPER-SECRET-VALUE';
    env.GSP_GSTIN = '24ABCDE1234F1Z5';
    const report = integrationReadiness({ env });
    const serialized = JSON.stringify(report);
    expect(serialized).not.toContain('SUPER-SECRET-VALUE');
    expect(serialized).not.toContain('24ABCDE1234F1Z5');
    const einvoice = report.find((r) => r.id === 'einvoice-irn');
    expect(einvoice?.detail?.gstin).toBe('24••••Z5');
    // Presence is expressed as booleans only.
    expect(Object.values(einvoice?.requiredEnv ?? {}).every((v) => typeof v === 'boolean')).toBe(
      true,
    );
  });

  it('treats WEIGHT_PORT = 0 as disabled-by-setting, matching the desktop', () => {
    const off = integrationReadiness({ env: bare, weightPort: '0' }).find(
      (r) => r.id === 'weighing-scale',
    );
    expect(off?.state).toBe('disabled-by-setting');
    const on = integrationReadiness({ env: bare, weightPort: 'COM3' }).find(
      (r) => r.id === 'weighing-scale',
    );
    expect(on?.state).toBe('awaiting-hardware');
    // A blank setting is also off — the desktop's check is against '0' after defaulting.
    expect(
      integrationReadiness({ env: bare, weightPort: null }).find((r) => r.id === 'weighing-scale')
        ?.state,
    ).toBe('disabled-by-setting');
  });

  it('reports the scanner and printing as ready because they need no driver', () => {
    const report = integrationReadiness({ env: bare });
    expect(report.find((r) => r.id === 'barcode-scanner')?.state).toBe('ready');
    expect(report.find((r) => r.id === 'printing')?.state).toBe('ready');
  });

  it('summarises without losing any integration', () => {
    const report = integrationReadiness({ env: bare, weightPort: '0' });
    const summary = readinessSummary(report);
    const counted = Object.values(summary).reduce((a, b) => a + b, 0);
    expect(counted).toBe(report.length);
    expect(report.length).toBeGreaterThanOrEqual(8);
  });

  it('cites a desktop source for every integration, so each claim is traceable', () => {
    for (const entry of integrationReadiness({ env: bare })) {
      expect(entry.desktopSource.length).toBeGreaterThan(3);
      expect(entry.implemented.length).toBeGreaterThan(20);
    }
  });
});

describe('credential verification', () => {
  const ok = (body: unknown) =>
    (async () => ({ ok: true, status: 200, json: async () => body })) as unknown as typeof fetch;

  it('reports not-configured for every provider when nothing is set', async () => {
    const checks = await verifyIntegrationCredentials({ env: {}, fetchImpl: ok({}) });
    expect(checks.map((c) => c.result)).toEqual([
      'not-configured',
      'not-configured',
      'not-configured',
    ]);
    // The detail must name the variables to set, so an operator knows what to do.
    expect(checks[1]!.detail).toContain('WA_PHONE_ID');
    expect(checks[2]!.detail).toContain('SMS_URL_TEMPLATE');
  });

  it('proves WhatsApp credentials with a live node read', async () => {
    const env: NodeJS.ProcessEnv = { WA_PHONE_ID: '1234', WA_TOKEN: 'TKN' };
    const checks = await verifyIntegrationCredentials({
      env,
      fetchImpl: ok({ id: '1234', display_phone_number: '+91 98123 45670' }),
    });
    const whatsapp = checks.find((c) => c.id === 'whatsapp');
    expect(whatsapp?.result).toBe('ok');
    expect(whatsapp?.detail).toContain('1234');
  });

  it('reports a rejected WhatsApp token as failed, with the provider message', async () => {
    const env: NodeJS.ProcessEnv = { WA_PHONE_ID: '1234', WA_TOKEN: 'bad' };
    const fetchImpl = (async () => ({
      ok: false,
      status: 401,
      json: async () => ({ error: { message: 'Invalid OAuth access token' } }),
    })) as unknown as typeof fetch;
    const checks = await verifyIntegrationCredentials({ env, fetchImpl });
    const whatsapp = checks.find((c) => c.id === 'whatsapp');
    expect(whatsapp?.result).toBe('failed');
    expect(whatsapp?.detail).toContain('Invalid OAuth access token');
  });

  it('calls SMS unverifiable rather than guessing, because sending costs money', async () => {
    const env: NodeJS.ProcessEnv = { SMS_URL_TEMPLATE: 'https://x/{text}', SMS_KEY: 'k' };
    const checks = await verifyIntegrationCredentials({ env, fetchImpl: ok({}) });
    const sms = checks.find((c) => c.id === 'sms');
    expect(sms?.result).toBe('unverifiable');
    expect(sms?.detail).toMatch(/no authentication endpoint/i);
  });

  it('never returns a credential value in a verdict', async () => {
    const env: NodeJS.ProcessEnv = {
      WA_PHONE_ID: '1234',
      WA_TOKEN: 'SECRET-TOKEN-VALUE',
      SMS_URL_TEMPLATE: 'https://x/{text}',
      SMS_KEY: 'SECRET-SMS-KEY',
    };
    const checks = await verifyIntegrationCredentials({ env, fetchImpl: ok({ id: '1234' }) });
    const serialized = JSON.stringify(checks);
    expect(serialized).not.toContain('SECRET-TOKEN-VALUE');
    expect(serialized).not.toContain('SECRET-SMS-KEY');
  });
});
