'use client';
import { formatDesktopDate } from '@datacare/core';
import {
  DRILL_COLUMNS,
  type Column,
  type MovementResult,
  type MovementRow,
  type StockResult,
  type StockRow,
} from './types';

const wt = (n: number): string =>
  Number(n || 0).toLocaleString('en-IN', { minimumFractionDigits: 3, maximumFractionDigits: 3 });
const pcs = (n: number): string =>
  Number(n || 0).toLocaleString('en-IN', { maximumFractionDigits: 3 });
/** Zero shows blank in every figure column (RP_STOCK.cs:3790). */
const blankZero = (n: number, f: (v: number) => string): string => (Number(n) === 0 ? '' : f(n));

export function SummaryGrid({
  result,
  rows,
  onDrill,
  gridRef,
  showTotal = true,
}: {
  result: StockResult;
  rows: StockRow[];
  onDrill: (row: StockRow, column: Column) => void;
  gridRef: React.RefObject<HTMLTableElement | null>;
  /** The "Total :" row exists only on the full grid: a name search binds the filtered rows as they are (RP_STOCK.cs:3837-3905). */
  showTotal?: boolean;
}) {
  const t = result.totals;
  return (
    <div className="panel" style={{ overflow: 'auto', maxHeight: '60vh' }}>
      <table className="grid dense" ref={gridRef} data-testid="stock-grid">
        <thead>
          <tr style={{ position: 'sticky', top: 0 }}>
            <th>SrNo</th>
            <th>Item Name</th>
            {DRILL_COLUMNS.flatMap((c) => [
              <th key={`${c.column}p`} className="num">
                {c.caption[0]}
              </th>,
              <th key={`${c.column}w`} className="num">
                {c.caption[1]}
              </th>,
            ])}
          </tr>
        </thead>
        <tbody>
          {rows.map((r, i) => (
            <tr key={`${r.code}|${r.itType}`} data-row={r.code}>
              <td>{i + 1}</td>
              <td>{r.name}</td>
              {DRILL_COLUMNS.flatMap((c) => [
                <td
                  key={`${c.column}p`}
                  className="num"
                  tabIndex={0}
                  data-col={`${c.column}-pcs`}
                  onDoubleClick={() => onDrill(r, c.column)}
                  onKeyDown={(e) => {
                    if (e.key === 'Enter') onDrill(r, c.column);
                  }}
                >
                  {blankZero(r[c.pcs], pcs)}
                </td>,
                <td
                  key={`${c.column}w`}
                  className="num"
                  tabIndex={0}
                  data-col={`${c.column}-wt`}
                  onDoubleClick={() => onDrill(r, c.column)}
                  onKeyDown={(e) => {
                    if (e.key === 'Enter') onDrill(r, c.column);
                  }}
                >
                  {blankZero(r[c.wt], wt)}
                </td>,
              ])}
            </tr>
          ))}
          {showTotal && result.rows.length > 0 && (
            <tr data-total="1" style={{ fontWeight: 600 }}>
              <td />
              <td>Total :</td>
              {DRILL_COLUMNS.flatMap((c) => [
                <td key={`${c.column}p`} className="num" data-col={`${c.column}-pcs`}>
                  {blankZero(t[c.pcs], pcs)}
                </td>,
                <td key={`${c.column}w`} className="num" data-col={`${c.column}-wt`}>
                  {blankZero(t[c.wt], wt)}
                </td>,
              ])}
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
}

export function MovementGrid({
  data,
  lotCaption,
  onZoom,
}: {
  data: MovementResult;
  lotCaption: boolean;
  /** Double click on a row opens its voucher (RP_STOCK.cs:5218). */
  onZoom?: (row: MovementRow) => void;
}) {
  const t = data.totals;
  return (
    <div className="panel" style={{ overflow: 'auto', maxHeight: '60vh' }}>
      <table className="grid dense" data-testid="stock-movements">
        <thead>
          <tr>
            <th>SrNo</th>
            <th>Vchtype</th>
            <th>Party Name</th>
            <th>VchNo</th>
            <th>VchDate</th>
            <th>{lotCaption ? 'Itm Lot' : 'TagNo'}</th>
            <th>ItName</th>
            <th className="num">Pcs</th>
            <th className="num">GrWt</th>
            <th className="num">NetWt</th>
            <th className="num">Fine</th>
            <th>Sign</th>
          </tr>
        </thead>
        <tbody>
          {data.rows.map((r, i) => (
            <tr key={i} data-vch={r.vchNo ?? ''} onDoubleClick={() => onZoom?.(r)}>
              <td>{i + 1}</td>
              <td>{r.vchType ?? ''}</td>
              <td>{r.partyName}</td>
              <td>{r.vchNo ?? ''}</td>
              <td>{formatDesktopDate(r.vchDate)}</td>
              <td>{lotCaption ? (r.itLot ?? '') : (r.tagNo ?? '')}</td>
              <td>{r.itName}</td>
              <td className="num">{pcs(r.pcs)}</td>
              <td className="num">{wt(r.gwt)}</td>
              <td className="num">{wt(r.nwt)}</td>
              <td className="num">{wt(r.fine)}</td>
              <td>{r.sign}</td>
            </tr>
          ))}
          {data.rows.length > 0 && (
            <tr data-total="1" style={{ fontWeight: 600 }}>
              <td />
              <td colSpan={6}>Total :</td>
              <td className="num">{pcs(t.pcs)}</td>
              <td className="num">{wt(t.gwt)}</td>
              <td className="num">{wt(t.nwt)}</td>
              <td className="num">{wt(t.fine)}</td>
              <td />
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
}
