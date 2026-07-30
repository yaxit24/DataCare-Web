'use client';
import { useEffect, useState, useCallback } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { RateTicker } from '../../../../components/RateTicker';
import { LookupPicker } from '../../../../components/LookupPicker';

/** Daily Rate (TR_DAILY_RATE): enter Gold (/10g) + Silver (/kg) fine rate; server derives each group's
 *  rate (fine × touch / 100) → RATE_MAST. Editable per-group grid (manual override) + Tax% + Employee
 *  + history (past dates). Save sends the grid rows as overrides so manual edits stick. */
interface Grp {
  grCode: string;
  grName: string;
  touch: number;
  rate: string;
  taxPct: number;
}

export default function DailyRatePage() {
  const [date, setDate] = useState(new Date().toISOString().slice(0, 10));
  const [goldRate, setGoldRate] = useState('');
  const [silverRate, setSilverRate] = useState('');
  const [taxPct, setTaxPct] = useState('3');
  const [empCode, setEmpCode] = useState('');
  const [groups, setGroups] = useState<Grp[]>([]);
  const [dates, setDates] = useState<string[]>([]);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);

  const load = useCallback(async (d: string) => {
    try {
      const r = await get<any>(`/daily-rate?date=${encodeURIComponent(d)}`);
      if (r.groups?.length) {
        setGoldRate(String(r.goldRate || ''));
        setSilverRate(String(r.silverRate || ''));
        setTaxPct(String(r.taxPct ?? 3));
        setEmpCode(r.empCode || '');
      }
      setGroups(
        (r.groups || []).map((g: any) => ({
          grCode: g.grCode,
          grName: g.grName,
          touch: g.touch,
          rate: String(g.rate),
          taxPct: g.taxPct,
        })),
      );
    } catch {
      setGroups([]);
    }
  }, []);

  useEffect(() => {
    get<string[]>('/daily-rate/dates')
      .then(setDates)
      .catch(() => {});
  }, []);
  useEffect(() => {
    load(date);
  }, [date, load]);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    if (!Number(goldRate) && !Number(silverRate)) {
      setMsg({ kind: 'err', text: 'enter a gold and/or silver rate' });
      return;
    }
    setBusy(true);
    try {
      const overrides = groups
        .filter((g) => Number(g.rate) > 0)
        .map((g) => ({ grCode: g.grCode, rate: Number(g.rate) }));
      const r = await post<{ date: string; groups: number }>('/daily-rate', {
        date,
        goldRate: Number(goldRate || 0),
        silverRate: Number(silverRate || 0),
        taxPct: Number(taxPct || 0),
        empCode: empCode || undefined,
        overrides: overrides.length ? overrides : undefined,
      });
      setMsg({ kind: 'ok', text: `Rates set for ${r.date} — ${r.groups} group(s)` });
      await load(date);
      get<string[]>('/daily-rate/dates')
        .then(setDates)
        .catch(() => {});
    } catch (err) {
      setMsg({
        kind: 'err',
        text:
          err instanceof ApiError
            ? err.body?.detail || err.body?.message || err.body?.error || 'failed'
            : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Daily Rate <span className="muted">— sets the day's metal rate for every item group</span>
      </h1>
      <RateTicker />
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form className="panel" onSubmit={submit}>
        <div className="row">
          <div className="field">
            <label>Date</label>
            <input type="date" value={date} onChange={(e) => setDate(e.target.value)} required />
          </div>
          <div className="field">
            <label>History</label>
            <select value="" onChange={(e) => e.target.value && setDate(e.target.value)}>
              <option value="">— past dates —</option>
              {dates.map((d) => (
                <option key={d} value={d}>
                  {d}
                </option>
              ))}
            </select>
          </div>
          <div className="field">
            <label>Gold /10g (fine)</label>
            <input
              value={goldRate}
              onChange={(e) => setGoldRate(e.target.value)}
              placeholder="72055"
            />
          </div>
          <div className="field">
            <label>Silver /kg (fine)</label>
            <input
              value={silverRate}
              onChange={(e) => setSilverRate(e.target.value)}
              placeholder="86000"
            />
          </div>
          <div className="field">
            <label>Tax %</label>
            <input
              value={taxPct}
              onChange={(e) => setTaxPct(e.target.value)}
              style={{ width: 60 }}
            />
          </div>
          <div className="field">
            <label>Employee</label>
            <LookupPicker entity="employees" value={empCode} onChange={setEmpCode} />
          </div>
        </div>
        <div className="muted" style={{ margin: '6px 0' }}>
          Save derives each group's rate = fine × touch ÷ 100; edit any group rate below to
          override. Re-saving keeps your edits.
        </div>
        {groups.length > 0 && (
          <div style={{ overflow: 'auto' }}>
            <table className="grid" style={{ maxWidth: 640 }}>
              <thead>
                <tr>
                  <th>Group</th>
                  <th>Name</th>
                  <th className="num">Touch%</th>
                  <th className="num">Rate (override)</th>
                  <th className="num">+Tax {taxPct}%</th>
                </tr>
              </thead>
              <tbody>
                {groups.map((g, i) => (
                  <tr key={g.grCode}>
                    <td>{g.grCode}</td>
                    <td>{g.grName}</td>
                    <td className="num">{g.touch}</td>
                    <td className="num">
                      <input
                        value={g.rate}
                        onChange={(e) =>
                          setGroups((gs) =>
                            gs.map((x, j) => (j === i ? { ...x, rate: e.target.value } : x)),
                          )
                        }
                        style={{ width: 90, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      {(
                        Math.round(Number(g.rate) * (1 + Number(taxPct) / 100) * 100) / 100
                      ).toLocaleString('en-IN')}
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
        <button className="primary" disabled={busy} style={{ marginTop: 10 }}>
          {busy ? 'Saving…' : 'Set Daily Rate'}
        </button>
      </form>
    </div>
  );
}
