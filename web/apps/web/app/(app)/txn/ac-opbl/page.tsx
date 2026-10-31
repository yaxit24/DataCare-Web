'use client';
import { useCallback, useEffect, useState } from 'react';
import { del, get, post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { PartyBalance } from '../../../../components/PartyBalance';
import { useGridKeyboard } from '../../../../components/GridKeyboard';

/**
 * Party Opening (desktop TR_AC_OPBL). One opening per party: the amount, gold fine and silver fine, each Cr or Dr
 * (the combos default to Cr, TR_AC_OPBL.cs:2232-2239). Save rewrites the party's opening and its ledger legs; the list
 * on the right is the desktop's opening list by balance type (:2299-2311). Picking a party or a list row reloads it.
 */
type CrDr = 'C' | 'D';
/** One bill-wise row (TR_AC_OPBL MSG columns 1-18). Numbers are kept as typed text until save. */
interface Bill {
  key: number;
  vchNo: string;
  vchDate: string;
  billNo: string;
  crDays: string;
  itemDesc: string;
  itType: string;
  grossWt: string;
  netWt: string;
  ghatWt: string;
  touch: string;
  wastage: string;
  goldFine: string;
  silverFine: string;
  dmPcs: string;
  dmWt: string;
  dmAmt: string;
  amount: string;
  sign: string;
}
type BillField = Exclude<keyof Bill, 'key'>;
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
  bills: Record<BillField, string | number | null>[];
  billDate: string | null;
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

/** The grid's columns in desktop order (MSG_CLEAR, TR_AC_OPBL.cs:1562-1675). */
const BILL_COLUMNS: { field: BillField; label: string; width: number; num?: number }[] = [
  { field: 'vchNo', label: 'VchNo', width: 70 },
  { field: 'vchDate', label: 'VchDate', width: 130 },
  { field: 'billNo', label: 'BillNo', width: 70 },
  { field: 'crDays', label: 'Days', width: 50, num: 0 },
  { field: 'itemDesc', label: 'Item Name', width: 140 },
  { field: 'itType', label: 'ItType', width: 50 },
  { field: 'grossWt', label: 'GrWt', width: 80, num: 3 },
  { field: 'netWt', label: 'NetWt', width: 80, num: 3 },
  { field: 'ghatWt', label: 'GhtWt', width: 70, num: 2 },
  { field: 'touch', label: 'Touch', width: 60, num: 2 },
  { field: 'wastage', label: 'West%', width: 60, num: 2 },
  { field: 'goldFine', label: 'Gold Fine', width: 80, num: 3 },
  { field: 'silverFine', label: 'Silver Fine', width: 80, num: 3 },
  { field: 'dmPcs', label: 'DmPcs', width: 55, num: 0 },
  { field: 'dmWt', label: 'DmWt', width: 65, num: 2 },
  { field: 'dmAmt', label: 'DmAmt', width: 80, num: 2 },
  { field: 'amount', label: 'Amount', width: 100, num: 2 },
  { field: 'sign', label: 'Cr/Dr', width: 50 },
];
let billKey = 0;
const blankBill = (vchDate = '', itType = 'A'): Bill => ({
  key: (billKey += 1),
  vchNo: '',
  vchDate,
  billNo: '',
  crDays: '',
  itemDesc: '',
  itType,
  grossWt: '',
  netWt: '',
  ghatWt: '',
  touch: '',
  wastage: '',
  goldFine: '',
  silverFine: '',
  dmPcs: '',
  dmWt: '',
  dmAmt: '',
  amount: '',
  sign: 'C',
});
const n = (v: string) => Number(v || 0) || 0;
const fixed = (v: number, places: number) => (v ? v.toFixed(places) : '');
/**
 * CommPassTotal (TR_AC_OPBL.cs:1855-1883): a G row's gold fine and an S row's silver fine are the net weight times
 * (touch + wastage) / 100, or the net weight when touch is blank. A gross weight fills a blank net weight (case 7).
 */
function recalc(b: Bill, changed: BillField): Bill {
  const next = { ...b };
  if (changed === 'grossWt' && !n(next.netWt)) next.netWt = next.grossWt;
  if (['grossWt', 'netWt', 'touch', 'wastage', 'itType'].includes(changed)) {
    const fine = n(next.touch)
      ? (n(next.netWt) * (n(next.touch) + n(next.wastage))) / 100
      : n(next.netWt);
    if (next.itType === 'G') next.goldFine = fixed(fine, 3);
    if (next.itType === 'S') next.silverFine = fixed(fine, 3);
  }
  return next;
}
const isBlank = (b: Bill) =>
  ![b.vchNo, b.billNo, b.itemDesc].some((v) => v.trim()) &&
  ![b.grossWt, b.netWt, b.goldFine, b.silverFine, b.amount, b.dmWt].some((v) => n(v));
/** MSG_TOT_FILL: Cr rows add and Dr rows subtract; gold only from G rows, silver only from S rows. */
function billTotals(bills: Bill[]) {
  const t = { grossWt: 0, netWt: 0, goldFine: 0, silverFine: 0, dmWt: 0, dmAmt: 0, amount: 0 };
  for (const b of bills) {
    const k = b.sign === 'D' ? -1 : 1;
    t.grossWt += k * n(b.grossWt);
    t.netWt += k * n(b.netWt);
    if (b.itType === 'G') t.goldFine += k * n(b.goldFine);
    if (b.itType === 'S') t.silverFine += k * n(b.silverFine);
    t.dmWt += k * n(b.dmWt);
    t.dmAmt += k * n(b.dmAmt);
    t.amount += k * n(b.amount);
  }
  return t;
}
const asBill = (r: Record<BillField, string | number | null>): Bill => {
  const b = blankBill();
  for (const c of BILL_COLUMNS) {
    const v = r[c.field];
    b[c.field] =
      v === null || v === undefined
        ? ''
        : c.num !== undefined
          ? fixed(Number(v), c.num)
          : String(v);
  }
  return b;
};

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
  disabled,
}: {
  label: string;
  value: CrDr;
  onChange: (v: CrDr) => void;
  disabled?: boolean;
}) {
  return (
    <select
      aria-label={label}
      value={value}
      disabled={disabled}
      onChange={(e) => onChange(e.target.value as CrDr)}
    >
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
  const [bills, setBills] = useState<Bill[]>([blankBill()]);
  const [billDate, setBillDate] = useState('');
  // Desktop grids are keyboard-driven (TEXT_ENTRY_KeyDown, TR_AC_OPBL.cs:3034-3142): arrows move between cells,
  // Enter advances and adds a row after the last cell of the last row, Ctrl/Cmd+D removes a row.
  const handleGridKey = useGridKeyboard({
    rowCount: bills.length,
    columnCount: BILL_COLUMNS.length,
    onAppendRow: () =>
      setBills((rows) => [...rows, blankBill(billDate, rows[rows.length - 1]?.itType || 'A')]),
    onRemoveRow: (row) => {
      setBills((rows) =>
        rows.length === 1 ? [blankBill(billDate)] : rows.filter((_, i) => i !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  const setBill = (i: number, field: BillField, value: string) =>
    setBills((rows) => rows.map((b, j) => (j === i ? recalc({ ...b, [field]: value }, field) : b)));
  const filledBills = bills.filter((b) => !isBlank(b));
  const totals = billTotals(filledBills);
  const fromBills = filledBills.length > 0;
  const signOf = (v: number, typed: CrDr): CrDr => (fromBills ? (v < 0 ? 'D' : 'C') : typed);

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
      const date = o.billDate ?? '';
      setBillDate(date);
      setBills([...(o.bills ?? []).map(asBill), blankBill(date)]);
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
    setBills([blankBill(billDate)]);
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
        bills: filledBills.map((b) => {
          const row: Record<string, string | number | null> = {};
          for (const c of BILL_COLUMNS)
            row[c.field] =
              c.num !== undefined
                ? n(b[c.field])
                : c.field === 'vchDate'
                  ? b.vchDate || null
                  : b[c.field];
          return row;
        }),
      });
      setLoaded(saved);
      setForm(asForm(saved));
      setBills([...(saved.bills ?? []).map(asBill), blankBill(saved.billDate ?? billDate)]);
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
          {filledBills.length > 0 && (
            <div className="muted" style={{ marginBottom: 6 }}>
              The opening is the total of the bill rows below.
            </div>
          )}
          <div className="row">
            <div className="field">
              <label htmlFor="opening-amount">Opening Amount</label>
              <input
                id="opening-amount"
                inputMode="decimal"
                value={filledBills.length ? fixed(Math.abs(totals.amount), 2) : form.amount}
                readOnly={filledBills.length > 0}
                onChange={(e) => set('amount', e.target.value)}
                style={{ textAlign: 'right' }}
              />
            </div>
            <div className="field">
              <label>&nbsp;</label>
              <SignSelect
                label="Opening Amount Cr or Dr"
                value={signOf(totals.amount, form.sign)}
                disabled={fromBills}
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
                value={filledBills.length ? fixed(Math.abs(totals.goldFine), 3) : form.gold}
                readOnly={filledBills.length > 0}
                onChange={(e) => set('gold', e.target.value)}
                style={{ textAlign: 'right' }}
              />
            </div>
            <div className="field">
              <label>&nbsp;</label>
              <SignSelect
                label="Opening Gold Fine Cr or Dr"
                value={signOf(totals.goldFine, form.goldSign)}
                disabled={fromBills}
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
                value={filledBills.length ? fixed(Math.abs(totals.silverFine), 3) : form.silver}
                readOnly={filledBills.length > 0}
                onChange={(e) => set('silver', e.target.value)}
                style={{ textAlign: 'right' }}
              />
            </div>
            <div className="field">
              <label>&nbsp;</label>
              <SignSelect
                label="Opening Silver Fine Cr or Dr"
                value={signOf(totals.silverFine, form.silverSign)}
                disabled={fromBills}
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

      <section className="panel" style={{ overflowX: 'auto' }} aria-label="Bill-wise opening">
        <h2>Bills</h2>
        <table className="grid" onKeyDown={handleGridKey}>
          <thead>
            <tr>
              <th>Sr.</th>
              {BILL_COLUMNS.map((c) => (
                <th key={c.field} className={c.num !== undefined ? 'num' : undefined}>
                  {c.label}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {bills.map((b, i) => (
              <tr key={b.key}>
                <td>{i + 1}</td>
                {BILL_COLUMNS.map((c) => (
                  <td key={c.field} className={c.num !== undefined ? 'num' : undefined}>
                    {c.field === 'itType' || c.field === 'sign' ? (
                      <select
                        aria-label={`${c.label} row ${i + 1}`}
                        value={b[c.field]}
                        onChange={(e) => setBill(i, c.field, e.target.value)}
                      >
                        {(c.field === 'itType' ? ['G', 'S', 'A'] : ['C', 'D']).map((v) => (
                          <option key={v} value={v}>
                            {v}
                          </option>
                        ))}
                      </select>
                    ) : (
                      <input
                        aria-label={`${c.label} row ${i + 1}`}
                        type={c.field === 'vchDate' ? 'date' : 'text'}
                        inputMode={c.num !== undefined ? 'decimal' : undefined}
                        value={b[c.field]}
                        onChange={(e) => setBill(i, c.field, e.target.value)}
                        style={{
                          width: c.width,
                          textAlign: c.num !== undefined ? 'right' : undefined,
                        }}
                      />
                    )}
                  </td>
                ))}
              </tr>
            ))}
          </tbody>
          <tfoot>
            <tr>
              <td colSpan={7} style={{ textAlign: 'right', fontWeight: 600 }}>
                Total :
              </td>
              <td className="num">{fixed(totals.grossWt, 3)}</td>
              <td className="num">{fixed(totals.netWt, 3)}</td>
              <td colSpan={3}></td>
              <td className="num">{fixed(totals.goldFine, 3)}</td>
              <td className="num">{fixed(totals.silverFine, 3)}</td>
              <td></td>
              <td className="num">{fixed(totals.dmWt, 2)}</td>
              <td className="num">{fixed(totals.dmAmt, 2)}</td>
              <td className="num">{fixed(totals.amount, 2)}</td>
              <td>{totals.amount < 0 ? 'D' : totals.amount > 0 ? 'C' : ''}</td>
            </tr>
          </tfoot>
        </table>
      </section>
    </div>
  );
}
