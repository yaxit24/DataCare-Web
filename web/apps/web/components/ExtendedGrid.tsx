'use client';

import { type Dispatch, type SetStateAction } from 'react';

/**
 * Desktop parity for transaction grids.
 *
 * The desktop's main item grid exposes every operator-typed field as a grid COLUMN — `TR_SALE`'s `MSG`
 * grid alone defines 107 columns, of which roughly thirty are typed by the operator, who tabs across
 * them without leaving the row. Presenting the same fields in a per-row disclosure panel makes them
 * reachable but changes the data-entry motion, which is the difference an operator actually feels.
 *
 * These helpers promote a page's extended line fields into real grid cells, keeping the compact layout
 * as the default. Only one control per field is ever rendered: when full mode is on the panel must be
 * hidden, otherwise a field would have two inputs, which breaks both accessibility and the field
 * audit's transmission check.
 */
export interface ExtendedGridMode {
  full: boolean;
  setFull: Dispatch<SetStateAction<boolean>>;
  /** Editable columns rendered before the extended block; extended cells are indexed after these. */
  baseColumns: number;
  /** Keyboard column count to hand to `useGridKeyboard`. */
  columnCount: number;
}

export function extendedGridColumnCount(
  full: boolean,
  baseColumns: number,
  extendedCount: number,
): number {
  return full ? baseColumns + extendedCount : baseColumns;
}

/** Toggle button; label states the number of columns gained so the operator knows the cost. */
export function GridModeToggle({
  full,
  setFull,
  extendedCount,
  testId,
}: {
  full: boolean;
  setFull: Dispatch<SetStateAction<boolean>>;
  extendedCount: number;
  testId: string;
}) {
  return (
    <button
      type="button"
      className="ghost"
      aria-pressed={full}
      data-testid={testId}
      onClick={() => setFull((value) => !value)}
    >
      {full ? 'Compact grid' : `Full grid (${extendedCount} more columns)`}
    </button>
  );
}

export function ExtendedHeaderCells<K extends string>({
  full,
  fields,
}: {
  full: boolean;
  fields: ReadonlyArray<readonly [K, string]>;
}) {
  if (!full) return null;
  return (
    <>
      {fields.map(([key, label]) => (
        <th key={`xh-${String(key)}`} className="num">
          {label}
        </th>
      ))}
    </>
  );
}

export function ExtendedBodyCells<K extends string, L extends object>({
  full,
  fields,
  line,
  row,
  baseColumns,
  setValue,
  cellProps,
  readOnlyFields,
}: {
  full: boolean;
  fields: ReadonlyArray<readonly [K, string]>;
  line: L;
  row: number;
  baseColumns: number;
  setValue: (row: number, key: K, value: string) => void;
  /** Supplies the page's own grid-cell attributes so keyboard navigation keeps working. */
  cellProps?: (row: number, column: number) => Record<string, unknown>;
  /**
   * Columns the company has locked against retyping.
   *
   * The desktop expresses these settings as `ReadOnly = true` on the grid's entry box — e.g.
   * `ITM_FINE_LOCK` at `TR_PURC.cs:7145-7148`. The cell still shows and still posts its value; the
   * operator simply may not overtype it, which is why this belongs on the input and not in the API.
   */
  readOnlyFields?: readonly K[];
}) {
  if (!full) return null;
  const locked = new Set(readOnlyFields ?? []);
  return (
    <>
      {fields.map(([key, label], offset) => (
        <td
          key={`xc-${String(key)}`}
          className="num"
          {...(cellProps ? cellProps(row, baseColumns + offset) : {})}
        >
          <input
            aria-label={`${label} row ${row + 1}`}
            style={{ width: 72, textAlign: 'right' }}
            value={String((line as Record<string, unknown>)[key] ?? '')}
            onChange={(event) => setValue(row, key, event.target.value)}
            readOnly={locked.has(key)}
            aria-readonly={locked.has(key)}
            title={locked.has(key) ? `${label} is locked by a company setting` : undefined}
          />
        </td>
      ))}
    </>
  );
}
