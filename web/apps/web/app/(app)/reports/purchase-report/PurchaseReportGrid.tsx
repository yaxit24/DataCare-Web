'use client';
import type { ColumnKind, PurchaseColumn, PurchaseLine, PurchaseResult } from './types';

const DIGITS: Partial<Record<ColumnKind, number>> = { money: 2, rate: 2, weight: 3, pcs: 0 };
const NUMERIC = new Set<ColumnKind>(['money', 'rate', 'weight', 'pcs']);

/** en-IN grouping of a value the server already rounded to the column's precision. */
export function formatValue(kind: ColumnKind, text: string | undefined): string {
  if (text === undefined || text === '') return '';
  const digits = DIGITS[kind];
  if (digits === undefined) return text;
  const n = Number(text);
  if (!Number.isFinite(n)) return text;
  return n.toLocaleString('en-IN', {
    minimumFractionDigits: digits,
    maximumFractionDigits: digits,
  });
}
const money = (n: number) => formatValue('money', String(n));
const weight = (n: number) => formatValue('weight', String(n));

interface Slot {
  header: string;
  columns: PurchaseColumn[];
  numeric: boolean;
}

/**
 * Columns of different levels that share a slot header print under one table column, as the template's bands
 * share x-positions (a voucher's Net Amt and a line's Net Amt, or a voucher's Pcs total and a line's Pcs).
 */
export function slotsOf(columns: readonly PurchaseColumn[]): Slot[] {
  const slots: Slot[] = [];
  for (const column of columns) {
    const header = column.slot ?? column.caption;
    let slot = slots.find((s) => s.header === header);
    if (!slot) {
      slot = { header, columns: [], numeric: NUMERIC.has(column.kind) };
      slots.push(slot);
    }
    slot.columns.push(column);
  }
  return slots;
}

const ROW_KINDS = new Set(['voucher', 'line', 'sub']);

function cellText(slot: Slot, line: PurchaseLine): string {
  const column = slot.columns.find((c) => line[c.key] !== undefined);
  return column ? formatValue(column.kind, line[column.key]) : '';
}

/**
 * The Purchase Rpt grid: the server's printed lines, band by band, with the voucher totals of the selection under
 * them. Group and total lines carry their label in the first column.
 */
export function PurchaseReportGrid({ result }: { result: PurchaseResult }) {
  const slots = slotsOf(result.columns);
  const s = result.selection;
  return (
    <table className="grid" data-testid="purchase-report-grid">
      <thead>
        <tr>
          <th aria-label="Band" />
          {slots.map((slot) => (
            <th key={slot.header} className={slot.numeric ? 'num' : undefined}>
              {slot.header}
            </th>
          ))}
        </tr>
      </thead>
      <tbody>
        {result.table.lines.map((line, index) => {
          const kind = line._kind ?? '';
          const isRow = ROW_KINDS.has(kind);
          return (
            <tr
              key={index}
              className={isRow ? `lvl-${kind}` : `band-${kind}`}
              style={!isRow || kind === 'voucher' ? { fontWeight: 600 } : undefined}
            >
              <td>{isRow ? '' : (line._band ?? '')}</td>
              {slots.map((slot) => (
                <td key={slot.header} className={slot.numeric ? 'num' : undefined}>
                  {cellText(slot, line)}
                </td>
              ))}
            </tr>
          );
        })}
        {result.table.lines.length === 0 && (
          <tr>
            <td colSpan={slots.length + 1} className="muted">
              No purchases for the selected filters.
            </td>
          </tr>
        )}
      </tbody>
      <tfoot>
        <tr data-testid="purchase-report-selection">
          <td colSpan={slots.length + 1}>
            <strong>Voucher totals</strong> Vouchers {s.voucherCount} · Net Amt {money(s.netAmt)} ·
            Tax {money(s.taxAmt)} · Bill Total {money(s.totAmt)}
            {s.fine !== null && <> · Fine {weight(s.fine)}</>}
            {s.nwt !== null && <> · Net Wt {weight(s.nwt)}</>}
          </td>
        </tr>
      </tfoot>
    </table>
  );
}
