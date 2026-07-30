'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, post } from '../../../lib/api';
import DeviceCapabilityProbe from '../../../components/DeviceCapabilityProbe';

export default function IntegrationsPage() {
  const [rates, setRates] = useState<any>(null);
  const [status, setStatus] = useState<any>(null);
  const [n, setN] = useState({
    to: '',
    channel: 'whatsapp',
    body: 'Thank you for shopping with DHAKAN JEWELLERS.',
    templateKind: 'manual-test',
    idempotencyKey: '',
  });
  const [sent, setSent] = useState<any>(null);

  const loadRates = useCallback(async () => {
    setRates(await get('/integrations/live-rates').catch(() => ({ ok: false })));
  }, []);
  useEffect(() => {
    loadRates();
    get('/integrations/status')
      .then(setStatus)
      .catch(() => {});
  }, [loadRates]);

  async function sendTest(e: React.FormEvent) {
    e.preventDefault();
    const idempotencyKey = n.idempotencyKey || crypto.randomUUID();
    const payload = { ...n, idempotencyKey };
    setN(payload);
    setSent(
      await post('/integrations/notify', payload).catch((x) => ({ ok: false, error: String(x) })),
    );
  }

  return (
    <div>
      <h1>Integrations</h1>

      <div className="panel">
        <div className="toolbar">
          <h2 style={{ margin: 0 }}>Live Rates</h2>
          <button className="ghost" onClick={loadRates}>
            Refresh
          </button>
          {rates?.updatedAt && (
            <span className="muted">
              as of {String(rates.updatedAt).slice(11, 19)} UTC · {rates.source}
            </span>
          )}
        </div>
        {rates?.ok ? (
          <div className="tiles">
            <div className="tile">
              <div className="muted">Gold 24K ₹/g</div>
              <div className="big kpi">{rates.gold24kInrGram?.toLocaleString('en-IN')}</div>
            </div>
            <div className="tile">
              <div className="muted">Gold 22K ₹/g</div>
              <div className="big kpi">{rates.gold22kInrGram?.toLocaleString('en-IN')}</div>
            </div>
            <div className="tile">
              <div className="muted">Silver ₹/g</div>
              <div className="big kpi">{rates.silverInrGram?.toLocaleString('en-IN') ?? '—'}</div>
            </div>
            <div className="tile">
              <div className="muted">USD → INR</div>
              <div className="big kpi">{rates.usdInr}</div>
            </div>
            <div className="tile">
              <div className="muted">Gold $/oz</div>
              <div className="big kpi">{rates.goldUsdOz?.toLocaleString('en-US')}</div>
            </div>
          </div>
        ) : (
          <div className="msg err">
            Live rates unavailable {rates?.error ? `(${rates.error})` : ''}
          </div>
        )}
      </div>

      <div className="panel">
        <h2>Provider Status</h2>
        {status ? (
          <table className="grid">
            <thead>
              <tr>
                <th>Feature</th>
                <th>Provider</th>
                <th>Status</th>
              </tr>
            </thead>
            <tbody>
              {Object.entries(status).map(([k, v]: any) => (
                <tr key={k}>
                  <td>{k}</td>
                  <td>{v.provider}</td>
                  <td>{v.status}</td>
                </tr>
              ))}
            </tbody>
          </table>
        ) : (
          <span className="muted">loading…</span>
        )}
      </div>

      <DeviceCapabilityProbe />

      <form className="panel" onSubmit={sendTest}>
        <h2>Send WhatsApp / SMS (test)</h2>
        <div className="row">
          <div className="field">
            <label>To (mobile)</label>
            <input value={n.to} onChange={(e) => setN({ ...n, to: e.target.value })} required />
          </div>
          <div className="field">
            <label>Channel</label>
            <select value={n.channel} onChange={(e) => setN({ ...n, channel: e.target.value })}>
              <option value="whatsapp">WhatsApp</option>
              <option value="sms">SMS</option>
            </select>
          </div>
        </div>
        <div className="field">
          <label>Message</label>
          <input
            value={n.body}
            onChange={(e) => setN({ ...n, body: e.target.value, idempotencyKey: '' })}
          />
        </div>
        <div className="row">
          <div className="field">
            <label htmlFor="message-template-kind">Template kind</label>
            <input
              id="message-template-kind"
              value={n.templateKind}
              onChange={(e) => setN({ ...n, templateKind: e.target.value, idempotencyKey: '' })}
              required
            />
          </div>
          <div className="field">
            <label htmlFor="message-idempotency-key">Idempotency key</label>
            <input
              id="message-idempotency-key"
              value={n.idempotencyKey}
              onChange={(e) => setN({ ...n, idempotencyKey: e.target.value })}
              placeholder="Generated when sent"
            />
          </div>
        </div>
        <button className="primary">Send / retry</button>
        {sent && (
          <div className={`msg ${sent.ok ? 'ok' : 'err'}`}>
            {sent.ok
              ? `Sent via ${sent.mode} (id ${sent.id})`
              : `mode ${sent.mode ?? '?'} — ${sent.error}`}
          </div>
        )}
      </form>
    </div>
  );
}
