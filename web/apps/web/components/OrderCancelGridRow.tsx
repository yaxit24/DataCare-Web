'use client';
import { round } from '@datacare/core';
import { LookupPicker } from './LookupPicker';

/** One row of the Order Cancel grid (MSG, TR_SL_ORD_ADJ.cs:2140-2218). */
export interface Row {
  ordNo: string;
  ordYear: string;
  ordBook: string;
  acCode: string;
  acName: string;
  itDesc: string;
  ordAmt: number;
  adjAmt: string;
  kasarAmt: string;
  paidAc: string;
  paidAcName: string;
}
export const r2 = (value: number) => round(value, 2);
export const f2 = (value: number) => r2(value).toFixed(2);
export const n = (v: string | number) => Number(v || 0) || 0;
export const paidOf = (row: Row) => r2(n(row.adjAmt) - n(row.kasarAmt));

/**
 * Sr, OrdNo, AcCode, Ac Name, It Desc, OrdAmt, AdjAmt, KsarAmt, PaidAmt, PaiidAc, Paid Ac Name. OrdNo opens the
 * pending-order help; AcCode, Ac Name, OrdAmt and PaidAmt follow from the order and the amounts (CommPassTotal :2447).
 */
export function OrderCancelGridRow({
  row: r,
  index: i,
  setRow,
  onCellKey,
}: {
  row: Row;
  index: number;
  setRow: (i: number, patch: Partial<Row>) => void;
  onCellKey: (e: React.KeyboardEvent, i: number, column: string) => void;
}) {
  return (
    <tr key={i}>
      <td className="c">{i + 1}</td>
      <td>
        <input
          aria-label={`OrdNo row ${i + 1}`}
          data-cell={`ord-${i}`}
          value={r.ordNo}
          maxLength={8}
          readOnly={!!r.acCode}
          onChange={(e) => setRow(i, { ordNo: e.target.value })}
          onKeyDown={(e) => onCellKey(e, i, 'ord')}
          placeholder="F1"
          style={{ width: 80 }}
        />
      </td>
      <td aria-label={`AcCode row ${i + 1}`}>{r.acCode}</td>
      <td aria-label={`Ac Name row ${i + 1}`}>{r.acName}</td>
      <td>
        <input
          aria-label={`It Desc row ${i + 1}`}
          data-cell={`desc-${i}`}
          value={r.itDesc}
          maxLength={150}
          onChange={(e) => setRow(i, { itDesc: e.target.value })}
          onKeyDown={(e) => onCellKey(e, i, 'desc')}
        />
      </td>
      <td className="num" aria-label={`OrdAmt row ${i + 1}`}>
        {r.acCode ? f2(r.ordAmt) : ''}
      </td>
      <td className="num">
        <input
          aria-label={`AdjAmt row ${i + 1}`}
          data-cell={`adj-${i}`}
          value={r.adjAmt}
          inputMode="decimal"
          maxLength={10}
          onChange={(e) => setRow(i, { adjAmt: e.target.value })}
          onBlur={() => r.adjAmt && setRow(i, { adjAmt: f2(n(r.adjAmt)) })}
          onKeyDown={(e) => onCellKey(e, i, 'adj')}
          style={{ width: 100, textAlign: 'right' }}
        />
      </td>
      <td className="num">
        <input
          aria-label={`KsarAmt row ${i + 1}`}
          data-cell={`kasar-${i}`}
          value={r.kasarAmt}
          inputMode="decimal"
          maxLength={10}
          onChange={(e) => setRow(i, { kasarAmt: e.target.value })}
          onBlur={() => r.kasarAmt && setRow(i, { kasarAmt: f2(n(r.kasarAmt)) })}
          onKeyDown={(e) => onCellKey(e, i, 'kasar')}
          style={{ width: 100, textAlign: 'right' }}
        />
      </td>
      <td className="num" aria-label={`PaidAmt row ${i + 1}`}>
        {r.acCode ? f2(paidOf(r)) : ''}
      </td>
      <td data-cell={`paidac-${i}`} onKeyDown={(e) => onCellKey(e, i, 'paidac')}>
        <LookupPicker
          entity="accounts"
          value={r.paidAc}
          onChange={(code) => setRow(i, { paidAc: code, paidAcName: '' })}
          onPick={(picked) => setRow(i, { paidAcName: String(picked.name || '') })}
          ariaLabel={`PaiidAc row ${i + 1}`}
          placeholder="account…"
          advanceOnPick={false}
          style={{ width: 130 }}
        />
      </td>
      <td aria-label={`Paid Ac Name row ${i + 1}`}>{r.paidAcName}</td>
    </tr>
  );
}
