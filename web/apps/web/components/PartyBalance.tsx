'use client';
import { useEffect, useState } from 'react';
import { get } from '../lib/api';

// Party balance bar — desktop shows the selected party's Dr/Cr amount + Gold + Silver the moment a
// party is picked. Reads GET /party/:acCode/balance. Renders nothing until an account is selected.
interface Bal {
  acCode: string;
  name: string | null;
  amount: number;
  sign: 'Dr' | 'Cr';
  gold: number;
  silver: number;
}
/** How long the party code must stay unchanged before its balance is fetched. */
export const BALANCE_DELAY_MS = 300;

export function PartyBalance({ acCode }: { acCode: string }) {
  const [b, setB] = useState<Bal | null>(null);
  useEffect(() => {
    const ac = (acCode ?? '').trim();
    if (!ac) {
      setB(null);
      return;
    }
    let on = true;
    // G182: the party box changes on every keystroke; ask once the operator has stopped typing.
    const timer = setTimeout(() => {
      get<Bal>(`/party/${encodeURIComponent(ac)}/balance`)
        .then((d) => {
          if (on) setB(d);
        })
        .catch(() => {
          if (on) setB(null);
        });
    }, BALANCE_DELAY_MS);
    return () => {
      on = false;
      clearTimeout(timer);
    };
  }, [acCode]);
  if (!b) return null;
  const n = (x: number) => Number(x || 0).toLocaleString('en-IN');
  return (
    <div
      style={{
        display: 'flex',
        gap: 14,
        alignItems: 'center',
        padding: '5px 12px',
        margin: '0 0 10px',
        background: 'var(--panel,#161a22)',
        border: '1px solid var(--border,#2a2f3a)',
        borderRadius: 6,
        fontSize: 12,
      }}
    >
      {b.name && <b>{b.name}</b>}
      <span style={{ color: b.sign === 'Dr' ? '#f87171' : '#34d399' }}>
        ₹{n(b.amount)} {b.sign}
      </span>
      {b.gold ? <span>Gold {n(b.gold)} g</span> : null}
      {b.silver ? <span>Silver {n(b.silver)} g</span> : null}
      {!b.gold && !b.silver && <span className="muted">no metal balance</span>}
    </div>
  );
}
