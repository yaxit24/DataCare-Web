import { describe, it, expect } from 'vitest';
import { code39Svg, code39CheckChar, BarcodeError } from '../src/modules/integrations/barcode.js';
import {
  renderTemplate,
  notify,
  buildUpiUri,
  FakeMessageSender,
  type MessageSender,
} from '../src/modules/integrations/messaging.js';

describe('code39 barcode', () => {
  it('produces an SVG with bars', () => {
    const svg = code39Svg('TAG001');
    expect(svg.startsWith('<svg')).toBe(true);
    expect(svg).toContain('<rect');
    expect(svg).toContain('aria-label="TAG001"');
  });
  it('mod-43 check char is correct', () => {
    expect(code39CheckChar('AB')).toBe('L'); // 10+11=21 -> 'L'
    expect(code39CheckChar('A')).toBe('A'); // 10 -> 'A'
  });
  it('rejects non-encodable characters', () => {
    expect(() => code39Svg('abc')).not.toThrow(); // lowercased to ABC (valid)
    expect(() => code39Svg('A!')).toThrow(BarcodeError); // '!' not encodable
  });
});

describe('messaging', () => {
  it('renderTemplate substitutes placeholders', () => {
    expect(
      renderTemplate('Dear {name}, bill {bill} total Rs.{amt}', {
        name: 'Asha',
        bill: 'INV/1',
        amt: 1030,
      }),
    ).toBe('Dear Asha, bill INV/1 total Rs.1030');
  });
  it('notify records via fake sender (ok)', async () => {
    const s = new FakeMessageSender();
    const r = await notify(s, { to: '+919999999999', channel: 'whatsapp', body: 'hi' });
    expect(r.ok).toBe(true);
    expect(s.outbox.length).toBe(1);
  });
  it('notify NEVER throws on sender failure', async () => {
    const throwing: MessageSender = {
      async send() {
        throw new Error('gateway down');
      },
    };
    const r = await notify(throwing, { to: '+91', channel: 'sms', body: 'x' });
    expect(r.ok).toBe(false);
    expect(r.error).toContain('gateway down');
  });
  it('notify rejects empty recipient without throwing', async () => {
    const r = await notify(new FakeMessageSender(), { to: '', channel: 'sms', body: 'x' });
    expect(r.ok).toBe(false);
  });
  it('buildUpiUri formats an NPCI link', () => {
    const uri = buildUpiUri({ pa: 'shop@upi', pn: 'Jewel Co', am: 1030, tn: 'INV/1' });
    expect(uri).toContain('upi://pay?');
    expect(uri).toContain('pa=shop%40upi');
    expect(uri).toContain('am=1030.00');
  });
});
