'use client';
import { formatDesktopDate } from '@datacare/core';
import type { RefObject } from 'react';
import type { TagStockColumn, TagStockRow } from './types';

const fmt = (kind: TagStockColumn['kind'], v: unknown): string => {
  if (v === null || v === undefined || v === '') return '';
  if (kind === 'wt')
    return Number(v).toLocaleString('en-IN', {
      minimumFractionDigits: 3,
      maximumFractionDigits: 3,
    });
  if (kind === 'amt')
    return Number(v).toLocaleString('en-IN', {
      minimumFractionDigits: 0,
      maximumFractionDigits: 0,
    });
  if (kind === 'date') return formatDesktopDate(v);
  return String(v);
};

/** Footer sums over the rows the grid shows (RP_TAG.cs:4916-4976 Summary.Add), computed here so a search narrows them. */
export function footerTotals(
  columns: TagStockColumn[],
  rows: TagStockRow[],
): Record<string, number> {
  const out: Record<string, number> = {};
  for (const c of columns)
    if (c.total) out[c.key] = rows.reduce((a, r) => a + Number(r[c.key] ?? 0), 0);
  return out;
}

export function TagStockGrid({
  columns,
  rows,
  selected,
  onSelect,
  gridRef,
}: {
  columns: TagStockColumn[];
  rows: TagStockRow[];
  selected: number;
  onSelect: (i: number) => void;
  gridRef: RefObject<HTMLDivElement | null>;
}) {
  const totals = footerTotals(columns, rows);
  const num = (c: TagStockColumn) => c.kind === 'int' || c.kind === 'wt' || c.kind === 'amt';
  return (
    <div
      className="panel"
      style={{ overflow: 'auto', maxHeight: '60vh' }}
      ref={gridRef}
      tabIndex={0}
      data-testid="tag-stock-grid"
    >
      <table className="grid">
        <thead>
          <tr>
            {columns.map((c) => (
              <th key={c.key} className={num(c) ? 'num' : undefined}>
                {c.header}
              </th>
            ))}
          </tr>
        </thead>
        <tbody>
          {rows.map((r, i) => (
            <tr
              key={`${r.tagNo ?? ''}-${r.tagId ?? ''}-${r.vchNo ?? ''}-${r.vchDate ?? ''}-${r.sign ?? ''}-${i}`}
              className={i === selected ? 'active' : undefined}
              onClick={() => onSelect(i)}
              style={{ cursor: 'pointer' }}
            >
              {columns.map((c) => (
                <td key={c.key} className={num(c) ? 'num' : undefined}>
                  {fmt(c.kind, r[c.key])}
                </td>
              ))}
            </tr>
          ))}
          {rows.length === 0 && (
            <tr>
              <td colSpan={columns.length} className="muted" />
            </tr>
          )}
        </tbody>
        <tfoot>
          <tr data-testid="tag-stock-footer">
            {columns.map((c) => (
              <td key={c.key} className={num(c) ? 'num' : undefined} data-col={c.key}>
                {c.total ? fmt(c.kind, totals[c.key] ?? 0) : ''}
              </td>
            ))}
          </tr>
        </tfoot>
      </table>
    </div>
  );
}
