'use client';
import { useCallback, useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { PartyBalance } from '../../../../components/PartyBalance';

interface Opening {
  acCode: string;
  amount: number;
  sign: 'D' | 'C';
  gold: number;
  goldSign: '+' | '-';
  silver: number;
  silverSign: '+' | '-';
}

export default function OpeningBalancePage() {
  const [acCode, setAcCode] = useState('');
  const [op, setOp] = useState<Opening | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);

  const load = useCallback(async (ac: string) => {
    if (!ac.trim()) {
      setOp(null);
      return;
    }
    setBusy(true);
    setMsg(null);
    try {
      setOp(await get<Opening>(`/accounts/${encodeURIComponent(ac.trim())}/opening`));
    } catch (e) {
      setMsg({ kind: 'err', text: e instanceof ApiError ? e.body?.error || e.message : 'failed' });
    } finally {
      setBusy(false);
    }
  }, []);

  const upd = (k: keyof Opening, v: string | number) =>
    setOp((o) => (o ? ({ ...o, [k]: v } as Opening) : o));

  async function save(e: React.FormEvent) {
    e.preventDefault();
    if (!op) return;
    setMsg(null);
    setBusy(true);
    try {
      const saved = await post<Opening>(`/accounts/${encodeURIComponent(acCode.trim())}/opening`, {
        amount: Number(op.amount || 0),
        sign: op.sign,
        gold: Number(op.gold || 0),
        goldSign: op.goldSign,
        silver: Number(op.silver || 0),
        silverSign: op.silverSign,
      });
      setOp(saved);
      setMsg({ kind: 'ok', text: 'Opening balance saved' });
    } catch (e) {
      setMsg({
        kind: 'err',
        text:
          e instanceof ApiError
            ? e.body?.detail || e.body?.message || e.body?.error || 'failed'
            : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Opening Balance <span className="muted">— per-account opening money + metal (OP_DATA)</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <div className="panel">
        <div className="row">
          <div className="field" style={{ flex: 2 }}>
            <label>Account</label>
            <LookupPicker
              entity="accounts"
              value={acCode}
              onChange={setAcCode}
              onPick={(r) => load(String(r.code))}
            />
          </div>
          <div className="field" style={{ alignSelf: 'end' }}>
            <button type="button" className="ghost" onClick={() => load(acCode)} disabled={busy}>
              {busy ? 'Loading…' : 'Load'}
            </button>
          </div>
        </div>
        {acCode && <PartyBalance acCode={acCode} />}
      </div>

      {op && (
        <form className="panel" onSubmit={save}>
          <h2>Opening figures</h2>
          <div className="row">
            <div className="field">
              <label>Amount (₹)</label>
              <input
                value={op.amount}
                onChange={(e) => upd('amount', e.target.value)}
                style={{ textAlign: 'right' }}
              />
            </div>
            <div className="field">
              <label>Dr / Cr</label>
              <select value={op.sign} onChange={(e) => upd('sign', e.target.value)}>
                <option value="D">Dr</option>
                <option value="C">Cr</option>
              </select>
            </div>
          </div>
          <div className="row">
            <div className="field">
              <label>Gold fine (g)</label>
              <input
                value={op.gold}
                onChange={(e) => upd('gold', e.target.value)}
                style={{ textAlign: 'right' }}
              />
            </div>
            <div className="field">
              <label>+ / −</label>
              <select value={op.goldSign} onChange={(e) => upd('goldSign', e.target.value)}>
                <option value="+">+ (we hold)</option>
                <option value="-">− (we owe)</option>
              </select>
            </div>
          </div>
          <div className="row">
            <div className="field">
              <label>Silver fine (g)</label>
              <input
                value={op.silver}
                onChange={(e) => upd('silver', e.target.value)}
                style={{ textAlign: 'right' }}
              />
            </div>
            <div className="field">
              <label>+ / −</label>
              <select value={op.silverSign} onChange={(e) => upd('silverSign', e.target.value)}>
                <option value="+">+ (we hold)</option>
                <option value="-">− (we owe)</option>
              </select>
            </div>
          </div>
          <div className="muted" style={{ margin: '6px 0' }}>
            Opening is added to ledger movements when computing the party balance.
          </div>
          <button className="primary" disabled={busy}>
            {busy ? 'Saving…' : 'Save Opening'}
          </button>
        </form>
      )}
    </div>
  );
}
