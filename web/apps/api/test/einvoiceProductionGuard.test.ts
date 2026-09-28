/**
 * Guard tests for the e-invoice transport selection.
 *
 * WHY THIS FILE EXISTS
 * ====================
 * `irnTransportFromEnv` used to fall back to `FakeIrnTransport` whenever any of the five GSP credentials was
 * absent, with no environment guard. `FakeIrnTransport` returns a 64-character IRN, a 12-digit AckNo, a QR
 * string and Status 'ACT' — indistinguishable from a government-issued IRN — and `submitIrn` persists it into
 * SL_DATA.IRN_NO / ACK_NO / ACK_DATE and E_DATA.
 *
 * Three deployment defects made that reachable in production rather than only in tests:
 *   1. docker-compose.yml defaulted all five credentials to empty.
 *   2. deploy/.env.example documented GSP_BASE_URL / GSP_CLIENT_ID / GSP_CLIENT_SECRET, which the code never
 *      reads, so an operator following the deploy guide set variables with no effect.
 *   3. deploy/docker-compose.prod.yml never forwarded the GSP variables to the container at all.
 *
 * An invoice carrying an invalid IRN is not valid tax documentation, so the failure mode was: the shop
 * believes it is e-invoicing compliant while issuing legally invalid invoices.
 *
 * Each test below asserts a property that, if the guard were reverted, would fail.
 */
import { describe, expect, it } from 'vitest';
import {
  EInvoiceConfigError,
  FakeIrnTransport,
  gspStatus,
  irnTransportFromEnv,
} from '../src/modules/einvoice/einvoice.js';

/** A complete, syntactically valid credential set. Values are placeholders, not real credentials. */
const CREDS = {
  GSP_ASPID: 'asp-test',
  GSP_PASSWORD: 'pw-test',
  GSP_GSTIN: '24AAAAA0000A1Z5',
  GSP_USER: 'user-test',
  GSP_EINV_PWD: 'einv-test',
};

describe('e-invoice transport selection refuses to fabricate IRNs', () => {
  it('THROWS in production when credentials are absent, instead of returning a fake transport', () => {
    expect(() => irnTransportFromEnv({ NODE_ENV: 'production' })).toThrow(EInvoiceConfigError);
    expect(() => irnTransportFromEnv({ NODE_ENV: 'production' })).toThrow(
      /refusing to issue a fake IRN/i,
    );
  });

  it('THROWS in production when credentials are only partially supplied', () => {
    for (const omit of Object.keys(CREDS)) {
      const env: NodeJS.ProcessEnv = { NODE_ENV: 'production', GSP_SANDBOX: '0', ...CREDS };
      delete env[omit as keyof typeof CREDS];
      expect(
        () => irnTransportFromEnv(env),
        `omitting ${omit} must not yield a usable transport in production`,
      ).toThrow(EInvoiceConfigError);
    }
  });

  it('THROWS when credentials are complete but sandbox-vs-production is not declared', () => {
    // The old code defaulted to sandbox. Sandbox IRNs are not legally valid, so a complete production
    // credential set silently produced invalid IRNs when GSP_SANDBOX was forgotten.
    expect(() => irnTransportFromEnv({ NODE_ENV: 'production', ...CREDS })).toThrow(
      /GSP_SANDBOX must be set explicitly/i,
    );
    expect(() =>
      irnTransportFromEnv({ NODE_ENV: 'production', GSP_SANDBOX: '  ', ...CREDS }),
    ).toThrow(/GSP_SANDBOX must be set explicitly/i);
  });

  it('selects the real GSP transport, honouring the declared sandbox flag', () => {
    expect(irnTransportFromEnv({ NODE_ENV: 'production', GSP_SANDBOX: '0', ...CREDS }).mode).toBe(
      'chartered-info-prod',
    );
    expect(irnTransportFromEnv({ NODE_ENV: 'production', GSP_SANDBOX: '1', ...CREDS }).mode).toBe(
      'chartered-info-sandbox',
    );
  });

  it('still allows a fake transport OUTSIDE production so local work and tests are unaffected', () => {
    const { transport, mode } = irnTransportFromEnv({ NODE_ENV: 'development' });
    expect(transport).toBeInstanceOf(FakeIrnTransport);
    // Renamed from 'fake' so the mode string itself says where it is legitimate.
    expect(mode).toBe('fake-development');
  });

  it('reports the blocked state honestly rather than advertising a working fake mode', () => {
    expect(gspStatus({ NODE_ENV: 'production' }).mode).toBe('blocked-production-no-credentials');
    expect(gspStatus({ NODE_ENV: 'production', ...CREDS }).mode).toBe('blocked-sandbox-undeclared');
    expect(gspStatus({ NODE_ENV: 'development' }).mode).toBe('fake-development');
    expect(gspStatus({ NODE_ENV: 'production', GSP_SANDBOX: '0', ...CREDS }).mode).toBe(
      'chartered-info-prod',
    );
  });

  it('never reports configured=true without all five credentials', () => {
    expect(gspStatus({ NODE_ENV: 'production' }).configured).toBe(false);
    expect(gspStatus({ NODE_ENV: 'production', GSP_SANDBOX: '0', ...CREDS }).configured).toBe(true);
  });
});

describe('deployment configuration cannot silently land in fake mode', () => {
  it('documents the variable names the code actually reads', async () => {
    const { readFile } = await import('node:fs/promises');
    const example = await readFile(
      new URL('../../../deploy/.env.example', import.meta.url),
      'utf8',
    );
    for (const name of Object.keys(CREDS)) expect(example).toContain(name);
    expect(example).toContain('GSP_SANDBOX');
    // These were documented but read by nothing; an operator setting them got no error and fake IRNs.
    for (const dead of ['GSP_BASE_URL=', 'GSP_CLIENT_ID=', 'GSP_CLIENT_SECRET=']) {
      expect(example).not.toContain(dead);
    }
  });

  it('forwards every GSP variable to the production API container', async () => {
    const { readFile } = await import('node:fs/promises');
    const compose = await readFile(
      new URL('../../../deploy/docker-compose.prod.yml', import.meta.url),
      'utf8',
    );
    for (const name of [...Object.keys(CREDS), 'GSP_SANDBOX']) {
      expect(compose, `${name} must reach the container or setting it has no effect`).toContain(
        `${name}:`,
      );
    }
  });

  it('does not default GSP_SANDBOX in any compose file', async () => {
    const { readFile } = await import('node:fs/promises');
    for (const rel of ['../../../docker-compose.yml', '../../../deploy/docker-compose.prod.yml']) {
      const text = await readFile(new URL(rel, import.meta.url), 'utf8');
      // `${GSP_SANDBOX:-1}` would reintroduce the silent-sandbox failure.
      expect(text, `${rel} must not default GSP_SANDBOX`).not.toMatch(
        /GSP_SANDBOX:\s*\$\{GSP_SANDBOX:-[^}]+\}/,
      );
    }
  });
});
