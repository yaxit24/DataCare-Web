'use client';
import { LookupPicker } from './LookupPicker';

/** Shared settlement/tender panel (F2). Cash/Cheque/Card/UPI/Kasar + Bank/Cash a/c pickers + live
 *  Total/Paid/Outstanding. Used by Purchase, Other-Expenses, Purchase-Return (and any voucher that
 *  settles a party balance). `total` is the voucher grand total; the panel computes Outstanding. */
export interface Tender {
  cashAmt?: number | string;
  chequeAmt?: number | string;
  cardAmt?: number | string;
  upiAmt?: number | string;
  kasar?: number | string;
  cashAc?: string;
  bankAc?: string;
  kasarAc?: string;
}

const n = (v: unknown) => Number(v || 0);
const money = (x: number) =>
  x.toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });

export function tenderPaid(t: Tender): number {
  return Math.round((n(t.cashAmt) + n(t.chequeAmt) + n(t.cardAmt) + n(t.upiAmt)) * 100) / 100;
}
export function tenderOutstanding(total: number, t: Tender): number {
  return Math.round((total - tenderPaid(t) - n(t.kasar)) * 100) / 100;
}

export function TenderPanel({
  total,
  value,
  onChange,
  title,
}: {
  total: number;
  value: Tender;
  onChange: (t: Tender) => void;
  title?: string;
}) {
  const set = (k: keyof Tender, v: string) => onChange({ ...value, [k]: v });
  const paid = tenderPaid(value);
  const os = tenderOutstanding(total, value);
  const num = (k: keyof Tender) => (
    <input
      value={(value[k] as string) ?? ''}
      onChange={(e) => set(k, e.target.value)}
      style={{ width: 100, textAlign: 'right' }}
      inputMode="decimal"
    />
  );
  return (
    <div className="panel">
      <h2>
        Settlement <span className="muted">— {title ?? 'pay now (blank = full outstanding)'}</span>
      </h2>
      <div className="row" style={{ flexWrap: 'wrap', gap: 12 }}>
        <div className="field">
          <label>Cash Amt</label>
          {num('cashAmt')}
        </div>
        <div className="field">
          <label>Cheque Amt</label>
          {num('chequeAmt')}
        </div>
        <div className="field">
          <label>Card Amt</label>
          {num('cardAmt')}
        </div>
        <div className="field">
          <label>UPI Amt</label>
          {num('upiAmt')}
        </div>
        <div className="field">
          <label>Kasar (round-off)</label>
          {num('kasar')}
        </div>
      </div>
      <div className="row" style={{ flexWrap: 'wrap', gap: 12, alignItems: 'flex-end' }}>
        <div className="field" style={{ minWidth: 180 }}>
          <label>Bank A/c (cheque/card/upi)</label>
          <LookupPicker
            entity="accounts"
            value={value.bankAc ?? ''}
            onChange={(v) => set('bankAc', v)}
            placeholder="default BANK"
          />
        </div>
        <div className="field" style={{ minWidth: 150 }}>
          <label>Cash A/c</label>
          <LookupPicker
            entity="accounts"
            value={value.cashAc ?? ''}
            onChange={(v) => set('cashAc', v)}
            placeholder="default CASH"
          />
        </div>
        <div className="tiles" style={{ marginLeft: 'auto' }}>
          <div className="tile">
            <div className="muted">Total</div>
            <div className="big kpi">{money(total)}</div>
          </div>
          <div className="tile">
            <div className="muted">Paid + Kasar</div>
            <div className="big kpi">{money(paid + n(value.kasar))}</div>
          </div>
          <div className="tile">
            <div className="muted">Outstanding</div>
            <div
              className="big kpi"
              style={{ color: Math.abs(os) < 0.005 ? 'var(--ok)' : undefined }}
            >
              {money(os)}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
