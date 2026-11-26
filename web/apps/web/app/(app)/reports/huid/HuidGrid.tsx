'use client';
import { forwardRef } from 'react';
import { formatDesktopDate } from '@datacare/core';
import { HUID_TOTAL_KEYS, type HuidResult, type HuidRow } from './types';

/**
 * The HuId Report grid (desktop DGV, RP_HUID.cs:1088 `((Control)DGV).TabIndex = 7;`).
 *
 * The rows, the column order and the footer totals are the server's own result (one resolver feeds the
 * screen and every export, so they can never disagree). Hidden columns — CoCode, Book and BookName
 * (RP_HUID.cs:2038 `Columns["CoCode"].Visible = false;`, :2042, :2046) and the print grouping codes —
 * stay in the result but are not rendered, exactly as the desktop hides them.
 */

/** A cell's display text: dates in the desktop's dd/MM/yyyy, weights at the database's own scale. A date
 *  column the database holds as text (BAR_DETL.STK_DATE is a varchar) shows as stored when it is not ISO. */
export function cellText(row: HuidRow, key: string): string {
  const value = (row as unknown as Record<string, unknown>)[key];
  if (value == null) return '';
  if (key === 'vchDate' || key === 'stkDate') {
    try {
      return formatDesktopDate(value);
    } catch {
      return String(value);
    }
  }
  return String(value);
}

export const HuidGrid = forwardRef<
  HTMLDivElement,
  {
    result: HuidResult | null;
    /** Double click on a row: the desktop opens the row's voucher (RP_HUID.cs:2252 DGV_DoubleClick). */
    onOpen?: (row: HuidRow) => void;
  }
>(function HuidGrid({ result, onOpen }, ref) {
  const visible = (result?.columns ?? []).filter((column) => !column.hidden);
  const rows = result?.rows ?? [];
  return (
    <div
      ref={ref}
      role="grid"
      aria-label="HuId Report"
      aria-rowcount={rows.length + 2}
      tabIndex={0}
      className="grid"
      style={{ overflow: 'auto', maxHeight: '62vh', outline: 'none' }}
    >
      <table style={{ borderCollapse: 'collapse', width: '100%', fontSize: 12 }}>
        <thead>
          <tr role="row">
            {visible.map((column) => (
              <th
                role="columnheader"
                key={column.key}
                style={{
                  textAlign: column.total || column.key === 'qty' ? 'right' : 'left',
                  position: 'sticky',
                  top: 0,
                  background: 'var(--panel,#fff)',
                  borderBottom: '1px solid var(--border,#ccc)',
                  padding: '4px 8px',
                  whiteSpace: 'nowrap',
                }}
              >
                {column.header}
              </th>
            ))}
          </tr>
        </thead>
        <tbody>
          {rows.map((row, index) => (
            <tr
              role="row"
              key={`${row.tagNo}-${row.tagId ?? index}-${index}`}
              onDoubleClick={() => onOpen?.(row)}
            >
              {visible.map((column) => (
                <td
                  data-col={column.key}
                  key={column.key}
                  style={{
                    textAlign: column.total || column.key === 'qty' ? 'right' : 'left',
                    borderBottom: '1px solid var(--border,#eee)',
                    padding: '3px 8px',
                    whiteSpace: 'nowrap',
                  }}
                >
                  {cellText(row, column.key)}
                </td>
              ))}
            </tr>
          ))}
          {result && (
            <tr role="row" data-testid="huid-totals">
              <td
                style={{
                  fontWeight: 600,
                  borderTop: '2px solid var(--border,#ccc)',
                  padding: '4px 8px',
                  whiteSpace: 'nowrap',
                }}
              >
                Total
              </td>
              {visible.slice(1).map((column) => (
                <td
                  data-col={column.key}
                  key={column.key}
                  style={{
                    textAlign: 'right',
                    fontWeight: 600,
                    borderTop: '2px solid var(--border,#ccc)',
                    padding: '4px 8px',
                    whiteSpace: 'nowrap',
                  }}
                >
                  {HUID_TOTAL_KEYS.includes(column.key as (typeof HUID_TOTAL_KEYS)[number])
                    ? String(
                        (result.totals as unknown as Record<string, unknown>)[column.key] ?? '',
                      )
                    : ''}
                </td>
              ))}
            </tr>
          )}
        </tbody>
      </table>
    </div>
  );
});
