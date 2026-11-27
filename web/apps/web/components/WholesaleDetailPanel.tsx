'use client';

import { useRef, type KeyboardEvent } from 'react';
import { detailWeightFromKr, detailWeightFromPieces } from '@datacare/core';
import {
  blankDetail,
  computeDetail,
  money,
  weight,
  type DetailField,
  type DetailRow,
} from '../lib/wholesaleVoucher';
import { focusNext } from './focus';
import { LookupPicker, type LookupRow } from './LookupPicker';

/**
 * The item-detail grid of an issue line (`MSG_IDTL` / `TEXT_IDTL`, TR_WH_SALE.cs:4900, :7389-7530): the stones and
 * loose items typed under a line. Enter walks the cells; Enter in PcsWt sets Weight = Pcs x PcsWt (:7503) and in
 * KrLs% Weight = KrWt x KrLs% / 100 (:7511); Enter in NetAmt of the last row adds a row (:7522); a blank ItCode
 * returns to the issue row (:7408); Esc closes the panel back to the issue grid (:13625); Ctrl+D asks
 * "This Row Record will Removed permantley ?" before removing the row (:7331); the arrow keys select the cell's text
 * (:17251). Every figure after the typed cells is `commPassTotalIdtl`, the function the server stores with.
 */
const COLUMNS: Array<{ field: DetailField; label: string; width: number; text?: boolean }> = [
  { field: 'itCode', label: 'ItCode', width: 80, text: true },
  { field: 'dmCode', label: 'DmCode', width: 80, text: true },
  { field: 'dmColor', label: 'DmColor', width: 72, text: true },
  { field: 'dmSize', label: 'DmSize', width: 64, text: true },
  { field: 'pcs', label: 'Pcs', width: 56 },
  { field: 'pcsWt', label: 'PcsWt', width: 70 },
  { field: 'krWt', label: 'KrWt', width: 70 },
  { field: 'krLessPrc', label: 'KrLs%', width: 60 },
  { field: 'grossWt', label: 'Weight', width: 76 },
  { field: 'conPct', label: 'Con%', width: 60 },
  { field: 'rateType', label: 'P/W', width: 44, text: true },
  { field: 'rate', label: 'Rate', width: 76 },
  { field: 'discPct', label: 'Disc%', width: 56 },
  { field: 'lbrRate', label: 'LbrRate', width: 70 },
  { field: 'krConPct', label: 'KrCon%', width: 64 },
  { field: 'netAmt', label: 'NetAmt', width: 84 },
];

export function WholesaleDetailPanel({
  mayDelete,
  lineNo,
  rows,
  onChange,
  onClose,
}: {
  mayDelete?: () => boolean;
  lineNo: number;
  rows: DetailRow[];
  onChange: (rows: DetailRow[]) => void;
  onClose: () => void;
}) {
  const table = useRef<HTMLTableElement>(null);
  const visible = rows.length ? rows : [blankDetail()];

  const set = (index: number, change: Partial<DetailRow>) =>
    onChange(visible.map((row, i) => (i === index ? { ...row, ...change } : row)));
  const edit = (index: number, field: DetailField, value: string) => set(index, { [field]: value });

  /** The Enter-time weight rules of columns 11 and 13, then `CommPassTotal_Idtl` into the row's own cells. */
  const afterEnter = (index: number, field: DetailField, value: string) => {
    let row: DetailRow = { ...visible[index]!, [field]: value };
    if (field === 'pcsWt') {
      const w = detailWeightFromPieces(Number(row.pcs || 0), Number(value || 0));
      if (w != null) row = { ...row, grossWt: w.toFixed(3) };
    } else if (field === 'krLessPrc') {
      const w = detailWeightFromKr(Number(row.krWt || 0), Number(value || 0));
      if (w != null) row = { ...row, grossWt: w.toFixed(3) };
    }
    const r = computeDetail(row);
    const cellOf = (x: number, dp: number) => (x === 0 ? '' : x.toFixed(dp));
    set(index, {
      ...row,
      grossWt: cellOf(r.weight, 3),
      tagWt: cellOf(r.tagWt, 3),
      itAmt: cellOf(r.itAmt, 2),
      discAmt: cellOf(r.discAmt, 2),
      lbrAmt: cellOf(r.lbrAmt, 2),
      netAmt: cellOf(r.netAmt, 2),
    });
  };

  const key = (event: KeyboardEvent<HTMLInputElement>, index: number, field: DetailField) => {
    if (event.key === 'Escape') {
      event.preventDefault();
      event.stopPropagation();
      onClose();
      return;
    }
    if (event.key !== 'Enter') return;
    event.preventDefault();
    const value = event.currentTarget.value;
    if (field === 'itCode' && value.trim() === '') {
      onClose(); // a blank code returns to the issue row (:7408)
      return;
    }
    afterEnter(index, field, value);
    if (field === 'netAmt') {
      if (index === visible.length - 1) {
        onChange([...visible, blankDetail()]);
        // The caret moves to the new row's first cell (:7522), which only exists after React commits, so the
        // move happens on the next frame. Guard it as useGridKeyboard's focusAfterRender does: when focus has
        // moved on by the time the frame fires, the move must not steal it back underneath a keystroke that
        // was already aimed at another control — on the desktop the move is synchronous inside the keydown
        // (:7518-7531) and cannot land under a later keystroke.
        const origin = event.currentTarget;
        requestAnimationFrame(() => {
          const active = document.activeElement;
          if (active != null && active !== document.body && active !== origin) return;
          const first = table.current?.querySelectorAll<HTMLInputElement>(
            `tr[data-detail-row="${index + 1}"] input`,
          )[0];
          first?.focus();
        });
      } else {
        table.current
          ?.querySelectorAll<HTMLInputElement>(`tr[data-detail-row="${index + 1}"] input`)[0]
          ?.focus();
      }
      return;
    }
    if (!focusNext(event.currentTarget, table.current ?? undefined)) event.currentTarget.blur();
  };

  const pickItem = (index: number, row: LookupRow) =>
    set(index, {
      itCode: String(row.code ?? ''),
      itemName: String(row.name ?? ''),
      itType: String(row.IT_TYPE ?? '')
        .trim()
        .toUpperCase(),
    });
  const pickDiamond = (index: number, row: LookupRow) => {
    const current = visible[index]!;
    set(index, {
      dmCode: String(row.code ?? ''),
      dmName: String(row.name ?? ''),
      dmColor: current.dmColor || String(row.DM_COLOR ?? ''),
      rate: current.rate || (Number(row.SL_RATE ?? 0) ? String(Number(row.SL_RATE)) : ''),
    });
  };

  return (
    <div
      className="panel"
      role="region"
      aria-label={`Item detail Issue line ${lineNo}`}
      data-testid="wholesale-detail-panel"
      onKeyDownCapture={(event) => {
        if (!(event.ctrlKey || event.metaKey) || event.key.toLowerCase() !== 'd') return;
        const row = (event.target as HTMLElement).closest<HTMLElement>('[data-detail-row]');
        if (!row) return;
        event.preventDefault();
        event.stopPropagation();
        // TR_WH_SALE.cs:7326-7331: the refusal precedes confirmation, including lookup cells.
        if (mayDelete && !mayDelete()) return;
        if (!window.confirm('This Row Record will Removed permantley ?')) return;
        onChange(visible.filter((_, i) => i !== Number(row.dataset.detailRow)));
      }}
    >
      <div className="toolbar" style={{ justifyContent: 'space-between' }}>
        <h3 style={{ margin: 0 }}>Item detail — issue line {lineNo}</h3>
        <button type="button" className="ghost" onClick={onClose} aria-label="Close item detail">
          Close (Esc)
        </button>
      </div>
      <div style={{ overflowX: 'auto' }}>
        <table className="grid" aria-label={`Item detail rows of issue line ${lineNo}`} ref={table}>
          <thead>
            <tr>
              <th scope="col">Sr</th>
              {COLUMNS.map((c) => (
                <th key={c.field} scope="col" className={c.text ? undefined : 'num'}>
                  {c.label}
                </th>
              ))}
              <th scope="col" className="num">
                ConWt
              </th>
              <th scope="col" className="num">
                ItAmt
              </th>
              <th scope="col" className="num">
                DiscAmt
              </th>
              <th scope="col" className="num">
                LbrAmt
              </th>
            </tr>
          </thead>
          <tbody>
            {visible.map((row, index) => {
              const result = computeDetail(row);
              return (
                <tr key={index} data-detail-row={index}>
                  <td>{index + 1}</td>
                  {COLUMNS.map((c) => (
                    <td key={c.field} className={c.text ? undefined : 'num'}>
                      {c.field === 'itCode' ? (
                        <LookupPicker
                          entity="items"
                          value={row.itCode}
                          onChange={(value) => edit(index, 'itCode', value)}
                          onPick={(picked) => pickItem(index, picked)}
                          placeholder="item… (F1)"
                          ariaLabel={`ItCode detail ${index + 1}`}
                          style={{ minWidth: 90 }}
                        />
                      ) : c.field === 'dmCode' ? (
                        <LookupPicker
                          entity="diamonds"
                          value={row.dmCode}
                          onChange={(value) => edit(index, 'dmCode', value)}
                          onPick={(picked) => pickDiamond(index, picked)}
                          placeholder="dm… (F1)"
                          ariaLabel={`DmCode detail ${index + 1}`}
                          style={{ minWidth: 90 }}
                        />
                      ) : (
                        <input
                          aria-label={`${c.label} detail ${index + 1}`}
                          value={row[c.field]}
                          inputMode={c.text ? undefined : 'decimal'}
                          onChange={(event) => edit(index, c.field, event.target.value)}
                          onKeyDown={(event) => key(event, index, c.field)}
                          onKeyUp={(event) => {
                            if (event.key.startsWith('Arrow')) event.currentTarget.select();
                          }}
                          style={{ width: c.width, textAlign: c.text ? 'left' : 'right' }}
                        />
                      )}
                    </td>
                  ))}
                  <td className="num" data-testid={`detail-con-wt-${index}`}>
                    {weight(result.conWt)}
                  </td>
                  <td className="num" data-testid={`detail-it-amt-${index}`}>
                    {money(result.itAmt)}
                  </td>
                  <td className="num" data-testid={`detail-disc-amt-${index}`}>
                    {money(result.discAmt)}
                  </td>
                  <td className="num" data-testid={`detail-lbr-amt-${index}`}>
                    {money(result.lbrAmt)}
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>
      <p className="muted" style={{ marginTop: 6 }}>
        Enter next cell · Ctrl+D delete row · Esc back to the issue line. Net amount shown in each
        row is stored as computed:{' '}
        <b data-testid="detail-net-total">
          {money(visible.reduce((t, r) => t + computeDetail(r).netAmt, 0))}
        </b>
      </p>
    </div>
  );
}
