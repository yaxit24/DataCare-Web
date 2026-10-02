import { describe, expect, it } from 'vitest';
import { messagingFailure, messagingOutcome } from '../lib/messagingOutcome';

/**
 * N54 step 4 / G33: the integrations and reminders screens must never show a simulated or refused send as a
 * success. Only a provider acceptance is success-styled, and even that says delivery is unconfirmed.
 */
describe('messaging outcome shown to the operator', () => {
  it('shows a provider acceptance as accepted, not delivered', () => {
    const outcome = messagingOutcome({
      ok: true,
      status: 'accepted',
      mode: 'whatsapp-cloud',
      channel: 'whatsapp',
      id: 'wa-1',
    });
    expect(outcome.tone).toBe('ok');
    expect(outcome.text).toBe(
      'Accepted via whatsapp (WhatsApp Cloud API), ref wa-1 — delivery not yet confirmed',
    );
  });

  it('shows a test-mode send as simulated, in the not-delivered style', () => {
    expect(messagingOutcome({ ok: false, status: 'simulated', mode: 'simulated' })).toEqual({
      tone: 'err',
      text: 'Simulated — nothing was delivered (test mode)',
    });
  });

  it('explains a refused send on an unconfigured server', () => {
    const refused = messagingFailure({
      status: 503,
      body: { error: 'messaging-unconfigured' },
      message: 'messaging-unconfigured',
    });
    expect(messagingOutcome(refused)).toEqual({
      tone: 'err',
      text: 'Not sent — messaging is not configured on this server',
    });
  });

  it('reports a provider failure as not delivered', () => {
    expect(messagingOutcome({ ok: false, status: 'failed', error: 'send failed' })).toEqual({
      tone: 'err',
      text: 'Not delivered — send failed',
    });
    expect(messagingOutcome(null).tone).toBe('err');
  });

  it('never uses the word "Sent" for anything', () => {
    for (const status of ['accepted', 'simulated', 'failed', 'pending']) {
      expect(messagingOutcome({ status }).text).not.toMatch(/\bsent\b/i);
    }
  });
});
