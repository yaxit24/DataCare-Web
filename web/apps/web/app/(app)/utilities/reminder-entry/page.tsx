'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, post, del, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';

interface Entry {
  vchNo: string;
  entDate: string | null;
  remDate: string | null;
  acCode: string;
  acName: string;
  mobile: string;
  remark: string;
}

export default function ReminderEntryPage() {
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [remark, setRemark] = useState('');
  const [remindDate, setRemindDate] = useState(new Date().toISOString().slice(0, 10));
  const [entries, setEntries] = useState<Entry[]>([]);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);

  const load = useCallback(async () => {
    try {
      setEntries(await get<Entry[]>('/reminder-entries'));
    } catch (e) {
      setMsg({
        kind: 'err',
        text: e instanceof ApiError ? e.body?.error || e.message : 'failed to load',
      });
    }
  }, []);
  useEffect(() => {
    void load();
  }, [load]);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    if (!remark.trim()) {
      setMsg({ kind: 'err', text: 'enter a reminder description' });
      return;
    }
    setBusy(true);
    try {
      await post('/reminder-entries', {
        acCode: acCode.trim() || undefined,
        acName: acName.trim() || undefined,
        remark: remark.trim(),
        remindDate,
      });
      setMsg({ kind: 'ok', text: 'Reminder saved' });
      setRemark('');
      setAcCode('');
      setAcName('');
      await load();
    } catch (err) {
      setMsg({
        kind: 'err',
        text: err instanceof ApiError ? err.body?.detail || err.body?.error || 'failed' : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  async function remove(vchNo: string) {
    if (!window.confirm(`Delete reminder #${vchNo}?`)) return;
    try {
      await del(`/reminder-entries/${encodeURIComponent(vchNo)}`);
      await load();
    } catch (e) {
      setMsg({ kind: 'err', text: e instanceof ApiError ? e.body?.error || e.message : 'failed' });
    }
  }

  return (
    <div>
      <h1>
        Reminder Entry <span className="muted">— ad-hoc reminders (account + note + date)</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form className="panel" onSubmit={submit}>
        <div className="row">
          <div className="field">
            <label>Account (optional)</label>
            <LookupPicker
              entity="accounts"
              value={acCode}
              onChange={setAcCode}
              onPick={(r) => setAcName(String(r.name ?? ''))}
            />
          </div>
          <div className="field">
            <label>Reminder Date</label>
            <input type="date" value={remindDate} onChange={(e) => setRemindDate(e.target.value)} />
          </div>
        </div>
        <div className="field">
          <label>Description</label>
          <input
            value={remark}
            onChange={(e) => setRemark(e.target.value)}
            placeholder="e.g. deposit HDFC cheque"
          />
        </div>
        <button className="primary" disabled={busy}>
          {busy ? 'Saving…' : 'Add Reminder'}
        </button>
      </form>
      <div className="panel" style={{ overflow: 'auto' }}>
        <h2>{entries.length} reminder(s)</h2>
        <table className="grid">
          <thead>
            <tr>
              <th>Vch</th>
              <th>Ent Date</th>
              <th>Rem Date</th>
              <th>Account</th>
              <th>Mobile</th>
              <th>Description</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {entries.map((e) => (
              <tr key={e.vchNo}>
                <td>{e.vchNo}</td>
                <td>{e.entDate ?? ''}</td>
                <td>{e.remDate ?? ''}</td>
                <td>{e.acName || e.acCode || <span className="muted">—</span>}</td>
                <td>{e.mobile || <span className="muted">—</span>}</td>
                <td>{e.remark}</td>
                <td>
                  <button type="button" className="danger" onClick={() => remove(e.vchNo)}>
                    ×
                  </button>
                </td>
              </tr>
            ))}
            {entries.length === 0 && (
              <tr>
                <td colSpan={7} className="muted">
                  No reminders.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}
