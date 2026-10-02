import { describe, it, expect } from 'vitest';
import { WhatsAppCloudSender } from '../src/modules/integrations/messaging.js';

function recorder() {
  const calls: any[] = [];
  const fetchImpl = (async (url: string, init: any) => {
    calls.push({
      url,
      method: init?.method,
      body: init?.body,
      isForm: init?.body instanceof FormData,
    });
    if (String(url).endsWith('/media'))
      return { ok: true, json: async () => ({ id: 'MEDIA123' }) } as any;
    return { ok: true, json: async () => ({ messages: [{ id: 'wamid.X' }] }) } as any;
  }) as unknown as typeof fetch;
  return { calls, fetchImpl };
}

describe('WhatsApp Cloud API adapter (Meta Graph v22)', () => {
  it('sends text to /{phoneId}/messages', async () => {
    const r = recorder();
    const res = await new WhatsAppCloudSender({
      phoneNumberId: 'PID',
      token: 'T',
      fetchImpl: r.fetchImpl,
    }).send({ to: '9199', channel: 'whatsapp', body: 'hi' });
    expect(res.status).toBe('accepted');
    expect(r.calls[0].url).toBe('https://graph.facebook.com/v22.0/PID/messages');
    expect(JSON.parse(r.calls[0].body)).toMatchObject({
      messaging_product: 'whatsapp',
      to: '9199',
      type: 'text',
      text: { body: 'hi' },
    });
  });

  it('uploads PDF to /media then sends type=document', async () => {
    const r = recorder();
    const res = await new WhatsAppCloudSender({
      phoneNumberId: 'PID',
      token: 'T',
      fetchImpl: r.fetchImpl,
    }).send({
      to: '9199',
      channel: 'whatsapp',
      body: 'Your invoice',
      document: { pdf: Buffer.from('%PDF-1.4 test'), filename: 'INV-1.pdf' },
    });
    expect(res.status).toBe('accepted');
    expect(r.calls[0].url).toBe('https://graph.facebook.com/v22.0/PID/media');
    expect(r.calls[0].isForm).toBe(true);
    expect(r.calls[1].url).toBe('https://graph.facebook.com/v22.0/PID/messages');
    const b = JSON.parse(r.calls[1].body);
    expect(b.type).toBe('document');
    expect(b.document).toMatchObject({
      id: 'MEDIA123',
      filename: 'INV-1.pdf',
      caption: 'Your invoice',
    });
  });

  it('sends an approved template with ordered params', async () => {
    const r = recorder();
    const res = await new WhatsAppCloudSender({
      phoneNumberId: 'PID',
      token: 'T',
      fetchImpl: r.fetchImpl,
    }).send({
      to: '9199',
      channel: 'whatsapp',
      body: '',
      template: { name: 'invoice_ready', lang: 'en', params: ['INV-1', '51500'] },
    });
    expect(res.status).toBe('accepted');
    const b = JSON.parse(r.calls[0].body);
    expect(b.type).toBe('template');
    expect(b.template.name).toBe('invoice_ready');
    expect(b.template.components[0].parameters.map((p: any) => p.text)).toEqual(['INV-1', '51500']);
  });
});
