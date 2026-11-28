'use client';

import type { Dispatch, SetStateAction } from 'react';
import { oldGoldRowAmount } from '../lib/lineRecalc';
import { r2 } from '../lib/saleBillTotal';
import * as wp26 from '../lib/saleResidual';
import type { useOldMetalTodayRates } from './SaleResidualPanel';

/**
 * The Sales Invoice's in-bill Old Gold / Silver exchange grid (desktop MSG_OLD → SL_PR_DETL, TR_SALE.cs:18843-18847),
 * used on every sale book except a tax-invoice (T) book, whose Old Gold / Silver rows open the linked URD purchase.
 */
export interface OgRow {
  metal: 'G' | 'S';
  itCode: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  description: string;
  otherWt: string;
  conversionPct: string;
  conversionWt: string;
  rateType: string;
  amount?: string;
  itType?: string;
  prCost?: number; // WP-26: typed amount, stored type and PR_COST
}
const ogBlank = (): OgRow => ({
  metal: 'G',
  itCode: 'OG',
  pcs: '',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  description: '',
  otherWt: '',
  conversionPct: '',
  conversionWt: '',
  rateType: '',
});
const n = (v: string) => Number(v || 0);
const str = (v: unknown) => (v == null || Number(v) === 0 ? '' : String(v));
const ogAmt = (o: OgRow) => oldGoldRowAmount(o); // the writer's own valuation (G83)

/** The exchange rows' total, as the writer values them. */
export const oldGoldValue = (rows: OgRow[]) => r2(rows.reduce((s, o) => s + ogAmt(o), 0));

/** GET /sales/:vchNo `oldGold[]` as grid rows. */
export const ogRowsFromView = (view: { oldGold?: any[] }): OgRow[] =>
  (view.oldGold ?? []).map((row: any) => ({
    metal: row.metal === 'S' ? 'S' : 'G',
    itCode: String(row.itCode ?? ''),
    pcs: str(row.pcs),
    grossWt: str(row.grossWt),
    netWt: str(row.netWt),
    touch: str(row.touch),
    rate: str(row.rate),
    description: String(row.description ?? ''),
    otherWt: str(row.otherWt),
    conversionPct: str(row.conversionPct),
    conversionWt: str(row.conversionWt),
    rateType: String(row.rateType ?? ''),
    itType: String(row.itType ?? ''),
    prCost: Number(row.prCost ?? 0),
  }));

/** The request's `oldGold[]`: rows with an amount. */
export const oldGoldBody = (rows: OgRow[]) =>
  rows
    .filter((o) => ogAmt(o) > 0)
    .map((o) => ({
      itCode: o.itCode || (o.metal === 'S' ? 'OS' : 'OG'),
      pcs: n(o.pcs),
      grossWt: n(o.grossWt),
      netWt: n(o.netWt),
      touch: n(o.touch),
      metal: o.metal,
      description: o.description || undefined,
      rate: n(o.rate),
      otherWt: n(o.otherWt),
      conversionPct: n(o.conversionPct),
      conversionWt: n(o.conversionWt),
      rateType: o.rateType || undefined,
      amount: ogAmt(o),
      itType: o.itType || undefined,
      prCost: o.prCost || undefined,
    }));

export function SaleOldGoldGrid({
  rows: ogRows,
  setRows: setOgRows,
  todayRates,
}: {
  rows: OgRow[];
  setRows: Dispatch<SetStateAction<OgRow[]>>;
  todayRates: ReturnType<typeof useOldMetalTodayRates>;
}) {
  const setOg = (i: number, k: keyof OgRow, v: string) =>
    setOgRows((rs) => rs.map((r, j) => (j === i ? { ...r, [k]: v } : r)));
  const numInput = (o: OgRow, i: number, k: keyof OgRow, width: number) => (
    <td className="num">
      <input
        value={String(o[k] ?? '')}
        onChange={(e) => setOg(i, k, e.target.value)}
        style={{ width, textAlign: 'right' }}
      />
    </td>
  );
  return (
    <div className="panel" style={{ overflow: 'auto' }}>
      <h2>
        Old Gold / Silver Exchange <span className="muted">— metal taken in against the bill</span>
      </h2>
      <table className="grid">
        <thead>
          <tr>
            <th>Metal</th>
            <th>Item</th>
            <th className="num">Pcs</th>
            <th className="num">Gross</th>
            <th className="num">Net</th>
            <th className="num">Touch%</th>
            <th className="num">Rate</th>
            <th className="num">Amount</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {ogRows.map((o, i) => (
            <tr key={i}>
              <td>
                <select value={o.metal} onChange={(e) => setOg(i, 'metal', e.target.value)}>
                  <option value="G">Gold</option>
                  <option value="S">Silver</option>
                </select>
              </td>
              <td>
                <input
                  value={o.itCode}
                  maxLength={5}
                  onChange={(e) => setOg(i, 'itCode', e.target.value)}
                  style={{ width: 70 }}
                />
              </td>
              {numInput(o, i, 'pcs', 48)}
              {numInput(o, i, 'grossWt', 70)}
              {numInput(o, i, 'netWt', 70)}
              {numInput(o, i, 'touch', 56)}
              {numInput(o, i, 'rate', 76)}
              <td className="num">{ogAmt(o).toLocaleString('en-IN')}</td>
              <td>
                <button
                  type="button"
                  className="danger"
                  onClick={() => setOgRows((rs) => rs.filter((_, j) => j !== i))}
                >
                  ×
                </button>
              </td>
            </tr>
          ))}
          {ogRows.length === 0 && (
            <tr>
              <td colSpan={9} className="muted">
                No exchange (optional).
              </td>
            </tr>
          )}
        </tbody>
      </table>
      <div className="toolbar" style={{ marginTop: 8 }}>
        <button
          type="button"
          className="ghost"
          onClick={() => setOgRows((rs) => [...rs, ogBlank()])}
        >
          + Add exchange
        </button>
      </div>
      {ogRows.map((row, index) => (
        <details key={`old-metal-${index}`} style={{ marginTop: 8 }}>
          <summary>Exchange row {index + 1} desktop fields</summary>
          <div className="row">
            {[
              ['Description', 'description'],
              ['Other Wt', 'otherWt'],
              ['Conversion %', 'conversionPct'],
              ['Conversion Wt', 'conversionWt'],
              ['Rate Type', 'rateType'],
              ['Amount', 'amount'],
            ].map(([label, key]) => (
              <div className="field" key={key}>
                <label>{label}</label>
                <input
                  aria-label={`Exchange ${index + 1} ${label}`}
                  value={String(row[key as keyof OgRow] ?? '')}
                  onChange={(e) => setOg(index, key as keyof OgRow, e.target.value)}
                  onBlur={(e) => {
                    const refusal =
                      key === 'rateType' && wp26.oldMetalRateTypeMessage(e.target.value);
                    if (refusal) return void (window.alert(refusal), e.target.focus()); // TR_SALE.cs:7669
                    if (key === 'amount')
                      setOgRows((rs) =>
                        rs.map((r, j) =>
                          j === index ? wp26.applyOldMetalAmount(r, todayRates) : r,
                        ),
                      );
                  }}
                />
              </div>
            ))}
          </div>
        </details>
      ))}
    </div>
  );
}
