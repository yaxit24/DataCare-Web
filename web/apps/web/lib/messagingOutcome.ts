/**
 * What the operator is told after a WhatsApp/SMS send (N54 step 4, gap G33).
 *
 * The server reports exactly what happened: `accepted` by a real provider (which is not delivery — only a
 * provider callback could confirm that, and none is wired), `simulated` in explicit test mode (nothing left the
 * server), or a failure, including 503 `messaging-unconfigured` when no provider is set up. Only an acceptance is
 * shown in the success style, and even then it says delivery is unconfirmed; the screens used to print "Sent" for
 * a fake that delivered nothing.
 */
export interface MessagingResult {
  ok?: boolean;
  status?: string;
  mode?: string;
  channel?: string;
  id?: string;
  error?: string;
}

export interface MessagingOutcome {
  /** `ok` only for a provider acceptance; everything else is shown as not delivered. */
  tone: 'ok' | 'err';
  text: string;
}

const PROVIDER: Record<string, string> = {
  'whatsapp-cloud': 'WhatsApp Cloud API',
  'http-sms': 'SMS gateway',
};

export function messagingOutcome(result: MessagingResult | null | undefined): MessagingOutcome {
  const r = result ?? {};
  if (r.status === 'accepted') {
    const via = r.channel ? ` via ${r.channel}` : '';
    const provider = r.mode && PROVIDER[r.mode] ? ` (${PROVIDER[r.mode]})` : '';
    const id = r.id ? `, ref ${r.id}` : '';
    return { tone: 'ok', text: `Accepted${via}${provider}${id} — delivery not yet confirmed` };
  }
  if (r.status === 'simulated')
    return { tone: 'err', text: 'Simulated — nothing was delivered (test mode)' };
  if (r.status === 'pending')
    return { tone: 'err', text: 'Already in progress for this message — check again shortly' };
  if (r.error === 'messaging-unconfigured' || r.mode === 'unconfigured')
    return { tone: 'err', text: 'Not sent — messaging is not configured on this server' };
  return { tone: 'err', text: `Not delivered — ${r.error || 'send failed'}` };
}

/** The result shape for a request that failed before the server answered with a send result. */
export function messagingFailure(error: unknown): MessagingResult {
  const e = error as { body?: { error?: string }; message?: string } | null;
  return { ok: false, status: 'failed', error: e?.body?.error || e?.message || 'request failed' };
}
