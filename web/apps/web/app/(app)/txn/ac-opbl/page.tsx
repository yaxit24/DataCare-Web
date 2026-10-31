'use client';
import { useCallback, useEffect, useState } from 'react';
import { del, get, post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { PartyBalance } from '../../../../components/PartyBalance';

/**
 * Party Opening (desktop TR_AC_OPBL). One opening per party: the amount, gold fine and silver fine, each Cr or Dr
 * (the combos default to Cr, TR_AC_OPBL.cs:2232-2239). Save rewrites the party's opening and its ledger legs; the list
 * on the right is the desktop's opening list by balance type (:2299-2311). Picking a party or a list row reloads it.
 */
type CrDr = 'C' | 'D';
interface Opening {
  acCode: string;
  acName: string | null;
  exists: boolean;
  amount: number;
  sign: CrDr;
  gold: number;
  goldSign: CrDr;
  silver: number;
  silverSign: CrDr;
}
interface Form {
  amount: string;
  sign: CrDr;
  gold: string;
  goldSign: CrDr;
  silver: string;
  silverSign: CrDr;
}
type BalanceType = 'amount' | 'gold' | 'silver';
interface ListRow {
  acCode: string;
  acName: string | null;
  cr: number;
  dr: number;
}
interface OpeningList {
  rows: ListRow[];
  totalCr: number;
  totalDr: number;
}

const EMPTY: Form = { amount: '', sign: 'C', gold: '', goldSign: 'C', silver: '', silverSign: 'C' };
const DELETE_CONFIRM = 'Are You Sure To Delete This Record now?'; // TR_AC_OPBL.cs:2870
const SAVED = 'Data Are Saved.'; // :2830
const DELETED = 'Delete Success.'; // :2879

const asForm = (o: Opening): Form =>
  o.exists
    ? {
        amount: o.amount ? o.amount.toFixed(2) : '',
        sign: o.sign,
        gold: o.gold ? o.gold.toFixed(3) : '',
        goldSign: o.goldSign,
        silver: o.silver ? o.silver.toFixed(3) : '',
        silverSign: o.silverSign,
      }
    : EMPTY;
const messageOf = (e: unknown) =>
  e instanceof ApiError
    ? e.body?.message || e.body?.detail || e.body?.error || e.message
    : 'failed';
const places = (t: BalanceType) => (t === 'amount' ? 2 : 3);

function SignSelect({
  label,
  value,
  onChange,
}: {
  label: string;
  value: CrDr;
  onChange: (v: CrDr) => void;
}) {
  return (
    <select aria-label={label} value={value} onChange={(e) => onChange(e.target.value as CrDr)}>
      <option value="C">Cr</option>
      <option value="D">Dr</option>
    </select>
  );
}

export default function PartyOpeningPage() {
  const [acCode, setAcCode] = useState('');
  const [loaded, setLoaded] = useState<Opening | null>(null);
  const [form, setForm] = useState<Form>(EMPTY);
  const [balanceType, setBalanceType] = useState<BalanceType>('amount');
  const [list, setList] = useState<OpeningList | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  // Bumped after a save or delete so the balance bar reads the party's new ledger balance.
  const [balanceKey, setBalanceKey] = useState(0);

  const loadList = useCallback(async (type: BalanceType) => {
    try {
      setList(await get<OpeningList>(`/ac-opbl?balanceType=${type}`));
    } catch (e) {
      setMsg({ kind: 'err', text: messageOf(e) });
    }
  }, []);
  useEffect(() => {
    void loadList(balanceType);
  }, [balanceType, loadList]);

  const open = useCallback(async (code: string) => {
    const ac = code.trim();
    setAcCode(ac);
    if (!ac) return;
    setBusy(true);
    try {
      const o = await get<Opening>(`/ac-opbl/${encodeURIComponent(ac)}`);
      setLoaded(o);
      setForm(asForm(o));
    } catch (e) {
      setMsg({ kind: 'err', text: messageOf(e) });
    } finally {
      setBusy(false);
    }
  }, []);

  const clear = () => {
    setAcCode('');
    setLoaded(null);
    setForm(EMPTY);
  };
  const set = <K extends keyof Form>(k: K, v: Form[K]) => setForm((f) => ({ ...f, [k]: v }));

  async function save(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setBusy(true);
    try {
      const saved = await post<Opening>('/ac-opbl', {
        acCode: acCode.trim(),
        amount: form.amount,
        sign: form.sign,
        gold: form.gold,
        goldSign: form.goldSign,
        silver: form.silver,
        silverSign: form.silverSign,
      });
      setLoaded(saved);
      setForm(asForm(saved));
      setMsg({ kind: 'ok', text: SAVED });
      setBalanceKey((k) => k + 1);
      await loadList(balanceType);
    } catch (e) {
      setMsg({ kind: 'err', text: messageOf(e) });
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    if (!window.confirm(DELETE_CONFIRM)) return;
    setMsg(null);
    setBusy(true);
    try {
      await del(`/ac-opbl/${encodeURIComponent(acCode.trim())}`);
      clear();
      setMsg({ kind: 'ok', text: DELETED });
      await loadList(balanceType);
    } catch (e) {
      setMsg({ kind: 'err', text: messageOf(e) });
    } finally {
      setBusy(false);
    }
  }

  const fmt = (v: number) =>
    v.toLocaleString('en-IN', { minimumFractionDigits: places(balanceType) });

  return (
    <div>
      <h1>Party Opening</h1>
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : 'status'}>
          {msg.text}
        </div>
      )}
      <div className="row" style={{ alignItems: 'flex-start', gap: 16 }}>
        <form
          className="panel"
          style={{ flex: 1 }}
          onSubmit={save}
          aria-label="Party Opening editor"
        >
          <div className="row">
            <div className="field" style={{ flex: 2 }}>
              <label>Party Code</label>
              <LookupPicker
                entity="accounts"
                ariaLabel="Party Code"
                resolveTypedCode
                value={acCode}
                onChange={setAcCode}
                onPick={(r) => void open(String(r.code))}
              />
            </div>
          </div>
          {acCode && <PartyBalance key={`${acCode}:${balanceKey}`} acCode={acCode} />}
          <div className="row">
            <div className="field">
              <label htmlFor="opening-amount">Opening Amount</label>
              <input
                id="opening-amount"
                inputMode="decimal"
                value={form.amount}
                onChange={(e) => set('amount', e.target.value)}
                style={{ textAlign: 'right' }}
              />
            </div>
            <div className="field">
              <label>&nbsp;</label>
              <SignSelect
                label="Opening Amount Cr or Dr"
                value={form.sign}
                onChange={(v) => set('sign', v)}
              />
            </div>
          </div>
          <div className="row">
            <div className="field">
              <label htmlFor="opening-gold">Opening Gold Fine</label>
              <input
                id="opening-gold"
                inputMode="decimal"
                value={form.gold}
                onChange={(e) => set('gold', e.target.value)}
                style={{ textAlign: 'right' }}
              />
            </div>
            <div className="field">
              <label>&nbsp;</label>
              <SignSelect
                label="Opening Gold Fine Cr or Dr"
                value={form.goldSign}
                onChange={(v) => set('goldSign', v)}
              />
            </div>
          </div>
          <div className="row">
            <div className="field">
              <label htmlFor="opening-silver">Opening Silver Fine</label>
              <input
                id="opening-silver"
                inputMode="decimal"
                value={form.silver}
                onChange={(e) => set('silver', e.target.value)}
                style={{ textAlign: 'right' }}
              />
            </div>
            <div className="field">
              <label>&nbsp;</label>
              <SignSelect
                label="Opening Silver Fine Cr or Dr"
                value={form.silverSign}
                onChange={(v) => set('silverSign', v)}
              />
            </div>
          </div>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button className="primary" data-save-mnemonic disabled={busy}>
              {busy ? 'Saving…' : 'Save'}
            </button>
            <button
              type="button"
              className="danger"
              onClick={() => void remove()}
              disabled={busy || !loaded?.exists}
            >
              Delete
            </button>
            <button type="button" className="ghost" onClick={clear} disabled={busy}>
              Cancel
            </button>
          </div>
        </form>

        <section className="panel" style={{ flex: 1 }} aria-label="Opening list">
          <div className="row">
            <div className="field">
              <label htmlFor="opening-balance-type">Balance Type</label>
              <select
                id="opening-balance-type"
                value={balanceType}
                onChange={(e) => setBalanceType(e.target.value as BalanceType)}
              >
                <option value="amount">Amount</option>
                <option value="gold">Gold</option>
                <option value="silver">Silver</option>
              </select>
            </div>
          </div>
          <table className="grid">
            <thead>
              <tr>
                <th>Sr.</th>
                <th>Code</th>
                <th>Name</th>
                <th className="num">Cr</th>
                <th className="num">Dr</th>
              </tr>
            </thead>
            <tbody>
              {(list?.rows ?? []).map((r, i) => (
                <tr
                  key={r.acCode}
                  onClick={() => void open(r.acCode)}
                  style={{ cursor: 'pointer' }}
                  aria-selected={r.acCode === acCode}
                >
                  <td>{i + 1}</td>
                  <td>{r.acCode}</td>
                  <td>{r.acName}</td>
                  <td className="num">{r.cr ? fmt(r.cr) : ''}</td>
                  <td className="num">{r.dr ? fmt(r.dr) : ''}</td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td colSpan={3} style={{ textAlign: 'right', fontWeight: 600 }}>
                  Total
                </td>
                <td className="num">
                  <b>{fmt(list?.totalCr ?? 0)}</b>
                </td>
                <td className="num">
                  <b>{fmt(list?.totalDr ?? 0)}</b>
                </td>
              </tr>
            </tfoot>
          </table>
        </section>
      </div>
    </div>
  );
}
