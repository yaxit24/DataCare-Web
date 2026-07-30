'use client';
import { useEffect, useState } from 'react';
import { get } from '../lib/api';

// Live gold/silver rate ticker — mirrors the desktop footer (Fine Gold / Fine Silver / Rate Date)
// present on every transaction screen. Reads GET /rate (returns fineGold/fineSilver/date) + refreshes.
export function RateTicker() {
  const [r, setR] = useState<{
    fineGold?: number;
    fineSilver?: number;
    date?: string;
    rate?: number;
  } | null>(null);
  useEffect(() => {
    let on = true;
    const load = () =>
      get('/rate')
        .then((d: any) => {
          if (on) setR(d || null);
        })
        .catch(() => {});
    load();
    const t = setInterval(load, 60000);
    return () => {
      on = false;
      clearInterval(t);
    };
  }, []);
  const f = (n?: number) => (n ? Number(n).toLocaleString('en-IN') : '—');
  return (
    <div
      style={{
        display: 'flex',
        gap: 16,
        alignItems: 'center',
        padding: '6px 12px',
        margin: '0 0 10px',
        background: 'var(--panel, #161a22)',
        border: '1px solid var(--border,#2a2f3a)',
        borderRadius: 6,
        fontSize: 12,
      }}
    >
      <span style={{ display: 'inline-flex', alignItems: 'center', gap: 6, fontWeight: 600 }}>
        <span
          style={{
            width: 8,
            height: 8,
            borderRadius: 8,
            background: '#22c55e',
            display: 'inline-block',
          }}
        />{' '}
        Live Rate
      </span>
      <span>
        Fine Gold <b>₹{f(r?.fineGold)}</b>
      </span>
      <span>
        Fine Silver <b>₹{f(r?.fineSilver)}</b>
      </span>
      {r?.date && <span className="muted">Rate {String(r.date).slice(0, 10)}</span>}
    </div>
  );
}
