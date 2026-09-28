import { describe, it, expect } from 'vitest';
import {
  CharteredInfoIrnTransport,
  buildIrnPayload,
  gspStatus,
  testGspAuth,
} from '../src/modules/einvoice/einvoice.js';

const payload = buildIrnPayload({
  seller: { gstin: '24AAAAA0000A1Z5', lglNm: 'DHAKAN', stcd: '24' },
  buyer: { gstin: '24BBBBB0000B1Z5', lglNm: 'CUST', stcd: '24' },
  sale: { billNo: '1', vchDate: '2024-04-01', interState: false },
  items: [
    {
      desc: 'GOLD',
      hsn: '7113',
      qty: 1,
      unitPrice: 50000,
      assAmt: 50000,
      gstRt: 3,
      cgst: 750,
      sgst: 750,
    },
  ],
});

describe('Chartered Info GSP IRN transport', () => {
  it('auths then POSTs the invoice (sandbox host, token threaded)', async () => {
    const calls: string[] = [];
    const fetchImpl = (async (url: string) => {
      calls.push(url);
      if (url.includes('/auth'))
        return { ok: true, json: async () => ({ AuthToken: 'TOK123' }) } as any;
      return {
        ok: true,
        json: async () => ({
          Data: {
            Irn: 'IRN'.padEnd(64, 'X'),
            AckNo: '112233',
            AckDt: '01/04/2024',
            SignedQRCode: 'QRDATA',
          },
        }),
      } as any;
    }) as unknown as typeof fetch;
    const t = new CharteredInfoIrnTransport({
      aspId: 'A',
      aspPassword: 'P',
      gstin: '24AAAAA0000A1Z5',
      userId: 'U',
      eInvPwd: 'E',
      sandbox: true,
      fetchImpl,
    });
    const res = await t.generateIRN(payload);
    expect(calls[0]).toContain('https://gstsandbox.charteredinfo.com/eivital/dec/v1.04/auth');
    expect(calls[0]).toContain('User_name=U');
    expect(calls[1]).toContain('https://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice');
    expect(calls[1]).toContain('AuthToken=TOK123');
    expect(res.Irn.length).toBe(64);
    expect(res.AckNo).toBe('112233');
  });

  it('throws on auth failure (no AuthToken)', async () => {
    const fetchImpl = (async () => ({
      ok: true,
      json: async () => ({ error: 'bad creds' }),
    })) as unknown as typeof fetch;
    const t = new CharteredInfoIrnTransport({
      aspId: 'A',
      aspPassword: 'P',
      gstin: 'G',
      userId: 'U',
      eInvPwd: 'E',
      fetchImpl,
    });
    await expect(t.generateIRN(payload)).rejects.toThrow();
  });

  it('cancelIRN auths then POSTs the Cancel endpoint with reason/remark', async () => {
    const calls: string[] = [];
    const bodies: string[] = [];
    const fetchImpl = (async (url: string, init?: any) => {
      calls.push(url);
      if (init?.body) bodies.push(init.body);
      if (url.includes('/auth'))
        return { ok: true, json: async () => ({ AuthToken: 'TOK9' }) } as any;
      return {
        ok: true,
        json: async () => ({ Data: { Irn: 'IRN'.padEnd(64, 'X'), CancelDate: '02/04/2024' } }),
      } as any;
    }) as unknown as typeof fetch;
    const t = new CharteredInfoIrnTransport({
      aspId: 'A',
      aspPassword: 'P',
      gstin: '24AAAAA0000A1Z5',
      userId: 'U',
      eInvPwd: 'E',
      sandbox: true,
      fetchImpl,
    });
    const res = await t.cancelIRN('IRN'.padEnd(64, 'X'), '3', 'Order cancelled');
    expect(calls[1]).toContain('/eicore/dec/v1.03/Cancel');
    expect(calls[1]).toContain('AuthToken=TOK9');
    expect(JSON.parse(bodies[0]!).CnlRsn).toBe('3');
    expect(res.Status).toBe('CNL');
  });
});

describe('GSP status + connection test (no secrets leaked)', () => {
  it('gspStatus reports the blocked/fake state when unconfigured, live+masked when configured', () => {
    const off = gspStatus({});
    // Renamed from 'fake': the mode string now says where a fake is legitimate. With NODE_ENV=production it
    // reports 'blocked-production-no-credentials' instead — see einvoiceProductionGuard.test.ts.
    expect(off.mode).toBe('fake-development');
    expect(off.configured).toBe(false);
    const on = gspStatus({
      GSP_ASPID: 'A',
      GSP_PASSWORD: 'secretpw',
      GSP_GSTIN: '24AAAAA0000A1Z5',
      GSP_USER: 'U',
      GSP_EINV_PWD: 'E',
      // Must now be declared explicitly. Omitting it reports 'blocked-sandbox-undeclared', because
      // defaulting to sandbox silently produced IRNs that are not legally valid.
      GSP_SANDBOX: '1',
    });
    expect(on.configured).toBe(true);
    expect(on.mode).toBe('chartered-info-sandbox');
    expect(on.gstin).toBe('24••••Z5'); // masked
    expect(JSON.stringify(on)).not.toContain('secretpw'); // never leak the password
  });
  it('testGspAuth returns not-configured without creds, ok on auth success', async () => {
    const none = await testGspAuth({});
    expect(none.ok).toBe(false);
    expect(none.mode).toBe('fake');
    const okFetch = (async (u: string) => ({
      ok: true,
      json: async () => ({ AuthToken: 'T' }),
    })) as unknown as typeof fetch;
    const ok = await testGspAuth(
      {
        GSP_ASPID: 'A',
        GSP_PASSWORD: 'P',
        GSP_GSTIN: 'G',
        GSP_USER: 'U',
        GSP_EINV_PWD: 'E',
        GSP_SANDBOX: '0',
      },
      okFetch,
    );
    expect(ok.ok).toBe(true);
    expect(ok.mode).toBe('chartered-info-prod');
  });
});
