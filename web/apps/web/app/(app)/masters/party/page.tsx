'use client';
import { useCallback, useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { LookupPicker } from '../../../../components/LookupPicker';

/** Rich Party form (desktop MS_ACCT tabs): Details / Photo (AC_IMAGE) / Family (shared AC_KHATA_NO) /
 *  Opening (OP_DATA). Save creates/updates the account, then sets its opening balance + photo inline. */
type Tab = 'details' | 'photo' | 'family' | 'opening';

export default function PartyFormPage() {
  const { coCode } = useBusinessScope();
  const [tab, setTab] = useState<Tab>('details');
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [khata, setKhata] = useState('');
  const [mobile, setMobile] = useState('');
  const [gr, setGr] = useState('');
  const [photo, setPhoto] = useState<string>('');
  const [op, setOp] = useState({
    amount: '',
    sign: 'D',
    gold: '',
    goldSign: '+',
    silver: '',
    silverSign: '+',
  });
  const [family, setFamily] = useState<{
    khataNo: string;
    members: { acCode: string; acName: string; mobile: string }[];
  } | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);

  const loadExisting = useCallback(async (code: string) => {
    setAcCode(code);
    if (!code.trim()) return;
    try {
      const [p, f, o] = await Promise.all([
        get<{ dataUrl: string | null }>(`/party/${encodeURIComponent(code)}/photo`).catch(() => ({
          dataUrl: null,
        })),
        get<any>(`/party/${encodeURIComponent(code)}/family`).catch(() => null),
        get<any>(`/accounts/${encodeURIComponent(code)}/opening`).catch(() => null),
      ]);
      setPhoto(p?.dataUrl || '');
      setFamily(f);
      if (o)
        setOp({
          amount: String(o.amount || ''),
          sign: o.sign || 'D',
          gold: String(o.gold || ''),
          goldSign: o.goldSign || '+',
          silver: String(o.silver || ''),
          silverSign: o.silverSign || '+',
        });
    } catch {
      /* new party */
    }
  }, []);

  function onFile(e: React.ChangeEvent<HTMLInputElement>) {
    const f = e.target.files?.[0];
    if (!f) return;
    const r = new FileReader();
    r.onload = () => setPhoto(String(r.result || ''));
    r.readAsDataURL(f);
  }

  async function save() {
    if (!acCode.trim() || !acName.trim()) {
      setMsg({ kind: 'err', text: 'Account code + name are required' });
      return;
    }
    setBusy(true);
    setMsg(null);
    try {
      await post('/masters/customers', {
        CO_CODE: coCode,
        AC_CODE: acCode.trim(),
        AC_NAME: acName.trim(),
        AC_KHATA_NO: khata || undefined,
        AC_MOBILE: mobile || undefined,
        AC_GR: gr || undefined,
      }).catch(async (e) => {
        if (e instanceof ApiError && e.status === 409) return;
        throw e;
      });
      if (Number(op.amount) || Number(op.gold) || Number(op.silver))
        await post(`/accounts/${encodeURIComponent(acCode.trim())}/opening`, {
          amount: Number(op.amount || 0),
          sign: op.sign,
          gold: Number(op.gold || 0),
          goldSign: op.goldSign,
          silver: Number(op.silver || 0),
          silverSign: op.silverSign,
        });
      if (photo)
        await post(`/party/${encodeURIComponent(acCode.trim())}/photo`, { dataUrl: photo });
      setMsg({ kind: 'ok', text: `Party "${acCode}" saved (details + opening + photo)` });
      await loadExisting(acCode.trim());
    } catch (e) {
      setMsg({
        kind: 'err',
        text: e instanceof ApiError ? e.body?.detail || e.body?.error || 'failed' : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  const TabBtn = ({ id, label }: { id: Tab; label: string }) => (
    <button type="button" className={tab === id ? 'primary' : 'ghost'} onClick={() => setTab(id)}>
      {label}
    </button>
  );

  return (
    <div>
      <h1>
        Party <span className="muted">— details · photo · family · opening</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <div className="panel">
        <div className="row">
          <div className="field">
            <label>Existing party</label>
            <LookupPicker
              entity="accounts"
              value={acCode}
              onChange={setAcCode}
              onPick={(r) => {
                setAcCode(String(r.code));
                setAcName(String(r.name || ''));
                loadExisting(String(r.code));
              }}
            />
          </div>
          <div className="field muted" style={{ flex: 1, alignSelf: 'center' }}>
            Pick to edit, or type a new code in Details.
          </div>
          <div className="field" style={{ alignSelf: 'end' }}>
            <button type="button" className="primary" disabled={busy} onClick={save}>
              {busy ? 'Saving…' : 'Save Party'}
            </button>
          </div>
        </div>
      </div>

      <div className="toolbar">
        <TabBtn id="details" label="Details" />
        <TabBtn id="photo" label="Photo" />
        <TabBtn id="family" label="Family" />
        <TabBtn id="opening" label="Opening" />
      </div>

      {tab === 'details' && (
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Account Code</label>
              <input value={acCode} onChange={(e) => setAcCode(e.target.value)} />
            </div>
            <div className="field">
              <label>Name</label>
              <input value={acName} onChange={(e) => setAcName(e.target.value)} />
            </div>
            <div className="field">
              <label>Khata No (family)</label>
              <input
                value={khata}
                onChange={(e) => setKhata(e.target.value)}
                placeholder="shared family ledger"
              />
            </div>
            <div className="field">
              <label>Mobile</label>
              <input value={mobile} onChange={(e) => setMobile(e.target.value)} />
            </div>
            <div className="field">
              <label>Group</label>
              <LookupPicker entity="ac-groups" value={gr} onChange={setGr} />
            </div>
          </div>
        </div>
      )}

      {tab === 'photo' && (
        <div className="panel">
          <div className="row" style={{ alignItems: 'flex-start' }}>
            <div className="field">
              <label>Party Photo</label>
              <input type="file" accept="image/*" onChange={onFile} />
            </div>
            {photo ? (
              <img
                src={photo}
                alt="party"
                style={{
                  maxWidth: 160,
                  maxHeight: 160,
                  border: '1px solid var(--border,#ccc)',
                  borderRadius: 4,
                }}
              />
            ) : (
              <span className="muted">no photo</span>
            )}
          </div>
        </div>
      )}

      {tab === 'family' && (
        <div className="panel">
          <h2>
            Family / Khata{' '}
            {family?.khataNo ? <span className="muted">— {family.khataNo}</span> : ''}
          </h2>
          {!family?.members?.length ? (
            <div className="muted">
              No family members (set a shared Khata No on Details + save, then the members sharing
              it appear here).
            </div>
          ) : (
            <table className="grid">
              <thead>
                <tr>
                  <th>Account</th>
                  <th>Name</th>
                  <th>Mobile</th>
                </tr>
              </thead>
              <tbody>
                {family.members.map((m) => (
                  <tr key={m.acCode}>
                    <td>{m.acCode}</td>
                    <td>{m.acName}</td>
                    <td>{m.mobile}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
        </div>
      )}

      {tab === 'opening' && (
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Amount</label>
              <input
                value={op.amount}
                onChange={(e) => setOp((o) => ({ ...o, amount: e.target.value }))}
              />
            </div>
            <div className="field">
              <label>Dr/Cr</label>
              <select
                value={op.sign}
                onChange={(e) => setOp((o) => ({ ...o, sign: e.target.value }))}
              >
                <option value="D">Dr</option>
                <option value="C">Cr</option>
              </select>
            </div>
            <div className="field">
              <label>Gold (g)</label>
              <input
                value={op.gold}
                onChange={(e) => setOp((o) => ({ ...o, gold: e.target.value }))}
              />
            </div>
            <div className="field">
              <label>+/−</label>
              <select
                value={op.goldSign}
                onChange={(e) => setOp((o) => ({ ...o, goldSign: e.target.value }))}
              >
                <option value="+">+</option>
                <option value="-">−</option>
              </select>
            </div>
            <div className="field">
              <label>Silver (g)</label>
              <input
                value={op.silver}
                onChange={(e) => setOp((o) => ({ ...o, silver: e.target.value }))}
              />
            </div>
            <div className="field">
              <label>+/−</label>
              <select
                value={op.silverSign}
                onChange={(e) => setOp((o) => ({ ...o, silverSign: e.target.value }))}
              >
                <option value="+">+</option>
                <option value="-">−</option>
              </select>
            </div>
          </div>
          <div className="muted" style={{ marginTop: 6 }}>
            Saved with the party (OP_DATA) — inline opening-at-create.
          </div>
        </div>
      )}
    </div>
  );
}
