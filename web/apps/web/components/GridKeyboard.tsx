'use client';

import { type KeyboardEvent as ReactKeyboardEvent } from 'react';
import { focusableElements } from './focus';

export type GridKeyAction =
  | { type: 'move'; row: number; column: number }
  | { type: 'append'; row: number; column: 0 }
  | { type: 'remove'; row: number }
  | { type: 'escape' }
  | { type: 'none' };

export interface GridKeyContext {
  key: string;
  row: number;
  column: number;
  rowCount: number;
  columnCount: number;
  ctrlKey?: boolean;
  metaKey?: boolean;
  altKey?: boolean;
  shiftKey?: boolean;
  defaultPrevented?: boolean;
  atHorizontalStart?: boolean;
  atHorizontalEnd?: boolean;
}

/** Pure decision table retained as executable evidence for the shared grid key contract. */
export function resolveGridKey(context: GridKeyContext): GridKeyAction {
  if (
    context.defaultPrevented ||
    context.altKey ||
    context.shiftKey ||
    context.rowCount < 1 ||
    context.columnCount < 1
  ) {
    return { type: 'none' };
  }

  const command = context.ctrlKey || context.metaKey;
  if (command) {
    if (context.key.toLowerCase() === 'd') return { type: 'remove', row: context.row };
    // Ctrl/Cmd+Enter belongs to the enclosing form; Ctrl/Cmd+V remains native paste.
    return { type: 'none' };
  }

  if (context.key === 'Escape') return { type: 'escape' };
  if (context.key === 'ArrowUp' && context.row > 0) {
    return { type: 'move', row: context.row - 1, column: context.column };
  }
  if (context.key === 'ArrowDown' && context.row < context.rowCount - 1) {
    return { type: 'move', row: context.row + 1, column: context.column };
  }
  if (context.key === 'ArrowLeft' && context.atHorizontalStart && context.column > 0) {
    return { type: 'move', row: context.row, column: context.column - 1 };
  }
  if (
    context.key === 'ArrowRight' &&
    context.atHorizontalEnd &&
    context.column < context.columnCount - 1
  ) {
    return { type: 'move', row: context.row, column: context.column + 1 };
  }
  if (context.key !== 'Enter') return { type: 'none' };
  if (context.column < context.columnCount - 1) {
    return { type: 'move', row: context.row, column: context.column + 1 };
  }
  if (context.row < context.rowCount - 1) {
    return { type: 'move', row: context.row + 1, column: 0 };
  }
  return { type: 'append', row: context.row + 1, column: 0 };
}

function horizontalBoundaries(target: HTMLElement): { start: boolean; end: boolean } {
  if (!(target instanceof HTMLInputElement) && !(target instanceof HTMLTextAreaElement)) {
    return { start: true, end: true };
  }
  const start = target.selectionStart;
  const end = target.selectionEnd;
  if (start == null || end == null) return { start: true, end: true };
  return { start: start === 0 && end === 0, end: start === target.value.length && end === start };
}

/**
 * Locate the row/column of the cell containing `target`.
 *
 * Explicit `data-grid-row` / `data-grid-column` attributes win when present, because a page may
 * deliberately number its grid differently from the DOM (hidden columns, extended-mode toggles).
 *
 * When they are absent we DERIVE the position from the table geometry. That fallback is why the
 * shared keyboard contract can reach every voucher screen: it was mounted on only 15 of 66
 * transaction pages, and the barrier was never the hook — it was that adopting it meant hand-adding
 * two attributes to every cell of every grid. Deriving position makes adoption a five-line change
 * per page, which is the difference between a contract that spreads and one that does not.
 */
function locateCell(
  container: HTMLElement,
  target: HTMLElement,
): { row: number; column: number; explicit: boolean } | null {
  const tagged = target.closest<HTMLElement>('[data-grid-row][data-grid-column]');
  if (tagged && container.contains(tagged)) {
    const row = Number(tagged.dataset.gridRow);
    const column = Number(tagged.dataset.gridColumn);
    if (Number.isInteger(row) && Number.isInteger(column)) return { row, column, explicit: true };
  }
  const td = target.closest<HTMLTableCellElement>('td');
  const tr = td?.closest<HTMLTableRowElement>('tr');
  if (!td || !tr || !container.contains(tr)) return null;
  // Row index within the body only: a header row must not shift every data row by one.
  const body = tr.closest<HTMLElement>('tbody') ?? container;
  const rows = Array.from(body.querySelectorAll<HTMLTableRowElement>(':scope > tr'));
  const row = rows.indexOf(tr);
  const column = Array.from(tr.children).indexOf(td);
  if (row < 0 || column < 0) return null;
  return { row, column, explicit: false };
}

/** Focus a cell addressed by derived DOM position rather than explicit attributes. */
function focusPositionalCell(container: HTMLElement, row: number, column: number): boolean {
  const body = container.querySelector<HTMLElement>('tbody') ?? container;
  const tr = Array.from(body.querySelectorAll<HTMLTableRowElement>(':scope > tr'))[row];
  const td = tr ? (tr.children[column] as HTMLElement | undefined) : undefined;
  const focusTarget = td ? focusableElements(td)[0] : undefined;
  if (!focusTarget) return false;
  focusTarget.focus();
  if (focusTarget instanceof HTMLInputElement || focusTarget instanceof HTMLTextAreaElement)
    focusTarget.select();
  return true;
}

function focusGridCell(container: HTMLElement, row: number, column: number): boolean {
  const cell = container.querySelector<HTMLElement>(
    `[data-grid-row="${row}"][data-grid-column="${column}"]`,
  );
  const target = cell ? focusableElements(cell)[0] : undefined;
  if (target) {
    target.focus();
    if (target instanceof HTMLInputElement || target instanceof HTMLTextAreaElement)
      target.select();
    return true;
  }
  return focusPositionalCell(container, row, column);
}

function focusAfterRender(container: HTMLElement, row: number, column: number): void {
  // Row removal shrinks an existing grid, so the target cell is usually already mounted: focus it
  // synchronously and leave no pending retry that could later fight a deliberate focus move.
  if (focusGridCell(container, row, column)) return;
  // Row append only mounts after React commits, and one frame is not always enough once a page
  // carries extra state (e.g. a loaded voucher). Retry across a few frames, but only while focus
  // remains on the element that requested the append. A deliberate move within or outside the grid
  // must cancel the retry so it cannot steal focus back.
  const origin = document.activeElement;
  let attempts = 0;
  const attempt = (): void => {
    const active = document.activeElement;
    if (active != null && active !== document.body && active !== origin) return;
    if (focusGridCell(container, row, column)) return;
    if (attempts++ >= 10) return;
    window.requestAnimationFrame(attempt);
  };
  window.requestAnimationFrame(attempt);
}

export interface GridKeyboardOptions {
  rowCount: number;
  /** Optional: when 0 or omitted, the row's own cell count is used (positional grids). */
  columnCount?: number;
  onAppendRow: () => void;
  onRemoveRow: (row: number) => boolean | void;
  onEscape: () => void;
}

export function useGridKeyboard(options: GridKeyboardOptions) {
  return (event: ReactKeyboardEvent<HTMLElement>): void => {
    const target = event.target as HTMLElement | null;
    if (!target || event.defaultPrevented) return;
    const located = locateCell(event.currentTarget, target);
    if (!located) return;

    const { row, column } = located;
    const boundary = horizontalBoundaries(target);
    const action = resolveGridKey({
      key: event.key,
      row,
      column,
      rowCount: options.rowCount,
      // A page that does not declare a column count can still navigate: the row's own cell count
      // is the truth for a positionally-addressed grid.
      columnCount:
        (options.columnCount ?? 0) > 0
          ? (options.columnCount as number)
          : (target.closest('tr')?.children.length ?? 0),
      ctrlKey: event.ctrlKey,
      metaKey: event.metaKey,
      altKey: event.altKey,
      shiftKey: event.shiftKey,
      defaultPrevented: event.defaultPrevented,
      atHorizontalStart: boundary.start,
      atHorizontalEnd: boundary.end,
    });

    if (action.type === 'none') return;
    event.preventDefault();
    const container = event.currentTarget;
    if (action.type === 'move') {
      focusGridCell(container, action.row, action.column);
    } else if (action.type === 'append') {
      options.onAppendRow();
      focusAfterRender(container, action.row, action.column);
    } else if (action.type === 'remove') {
      if (options.onRemoveRow(action.row) !== false) {
        focusAfterRender(
          container,
          Math.min(action.row, Math.max(0, options.rowCount - 2)),
          column,
        );
      }
    } else {
      options.onEscape();
    }
  };
}
