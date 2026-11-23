'use client';
import { useCallback, useEffect, useRef, type KeyboardEvent, type RefObject } from 'react';
import { LookupPicker } from './LookupPicker';

/** One row of the Books slot grid MSG: Sr, Account Desc, AcCode, AcName (MS_BOOK.cs:2154-2163). */
export interface BookSlotRow {
  srNo: string;
  desc: string;
  acCode: string;
  acName: string;
}

/** The cell editor's MaxLength per column (MSG_EnterCell, MS_BOOK.cs:2221-2233) and the grid's widths. */
const COLUMNS = [
  { key: 'srNo', header: 'Sr', maxLength: 2, width: 40 },
  { key: 'desc', header: 'Account Desc', maxLength: 50, width: 220 },
  { key: 'acCode', header: 'AcCode', maxLength: 8, width: 100 },
  { key: 'acName', header: 'AcName', maxLength: 50, width: 220 },
] as const;
const SR = 0;
const DESC = 1;
const AC_CODE = 2;
const AC_NAME = 3;

/** Every typed key upper-cased, the apostrophe refused (MS_BOOK_KeyPress, :2752-2763); the Sr cell keeps digits. */
const typed = (value: string) => value.toUpperCase().replace(/'/g, '');

export interface BookSlotGridHandle {
  /** Vch Serice Enter: row 1, column 1 when the grid has rows (MS_BOOK.cs:2978-2982). */
  start: () => boolean;
}

/**
 * The slot grid of Company → Books. TEXT_ENTRY_KeyDown/MSG_KeyDown (MS_BOOK.cs:2280-2366): the arrows move one cell and
 * stop at column 1, the last column, row 1 and the last row; Enter moves right, and on AcCode or AcName it goes to the
 * next row's AcCode, or to Save on the last row. AcCode looks the typed code up in the company's accounts and opens the
 * help of every account by name when it is not found (:2310-2337); a blank AcCode is allowed (decision D5).
 * AcName shows the chosen account's name; the server stores the account master's name for the code.
 */
export function BookSlotGrid({
  rows,
  onChange,
  saveRef,
  handleRef,
  disabled,
}: {
  rows: BookSlotRow[];
  onChange: (index: number, patch: Partial<BookSlotRow>) => void;
  saveRef: RefObject<HTMLButtonElement | null>;
  handleRef: RefObject<BookSlotGridHandle | null>;
  disabled?: boolean;
}) {
  const bodyRef = useRef<HTMLTableSectionElement>(null);
  const focusCell = useCallback((row: number, column: number) => {
    const input = bodyRef.current?.querySelector<HTMLInputElement>(
      `[data-grid-row="${row}"][data-grid-column="${column}"] input`,
    );
    if (!input) return false;
    input.focus();
    input.select();
    return true;
  }, []);
  const cellHasFocus = (row: number, column: number) =>
    !!bodyRef.current
      ?.querySelector(`[data-grid-row="${row}"][data-grid-column="${column}"]`)
      ?.contains(document.activeElement);
  useEffect(() => {
    handleRef.current = { start: () => rows.length > 0 && focusCell(0, DESC) };
  }, [handleRef, rows.length, focusCell]);

  /** Enter on AcCode or AcName: the next row's AcCode, or Save on the last row (:2348-2358). */
  const nextRow = (row: number) => {
    if (row >= rows.length - 1) {
      saveRef.current?.focus();
      return;
    }
    focusCell(row + 1, AC_CODE);
  };

  function onKeyDown(event: KeyboardEvent<HTMLTableSectionElement>) {
    const target = event.target as HTMLInputElement;
    const cell = target.closest<HTMLElement>('[data-grid-row][data-grid-column]');
    if (!cell || event.defaultPrevented) return;
    if (event.altKey || event.ctrlKey || event.metaKey || event.shiftKey) return;
    const row = Number(cell.dataset.gridRow);
    const column = Number(cell.dataset.gridColumn);
    // An open account help keeps Enter, Up and Down for its list.
    if (
      target.closest('[data-lookup-open="true"]') &&
      !['ArrowLeft', 'ArrowRight'].includes(event.key)
    )
      return;
    if (event.key === 'Enter') {
      if (column === AC_CODE && rows[row]?.acCode.trim()) return; // the lookup resolves it; onPick moves on
      event.preventDefault();
      if (column === AC_CODE || column === AC_NAME) return nextRow(row);
      return void focusCell(row, column + 1);
    }
    const moves: Record<string, [number, number]> = {
      ArrowLeft: [0, -1],
      ArrowRight: [0, 1],
      ArrowUp: [-1, 0],
      ArrowDown: [1, 0],
    };
    const move = moves[event.key];
    if (!move) return;
    event.preventDefault();
    const toRow = row + move[0];
    const toColumn = column + move[1];
    if (toRow >= 0 && toRow < rows.length && toColumn >= DESC && toColumn <= AC_NAME)
      focusCell(toRow, toColumn);
  }

  return (
    <table className="grid" style={{ marginTop: 10 }} aria-label="Book slots">
      <thead>
        <tr>
          {COLUMNS.map((column) => (
            <th key={column.key} style={{ width: column.width }}>
              {column.header}
            </th>
          ))}
        </tr>
      </thead>
      <tbody ref={bodyRef} data-testid="book-slots" onKeyDown={onKeyDown}>
        {rows.map((row, i) => (
          <tr key={i} data-slot={row.srNo}>
            {COLUMNS.map((column, c) => (
              <td key={column.key} data-grid-row={i} data-grid-column={c}>
                {c === AC_CODE ? (
                  <LookupPicker
                    entity="accounts"
                    searchPath="/masters/books-master/accounts"
                    ariaLabel={`AcCode row ${i + 1}`}
                    value={row.acCode}
                    placeholder=""
                    resolveTypedCode
                    advanceOnPick={false}
                    onChange={(code) => onChange(i, { acCode: typed(code), acName: '' })}
                    onPick={(picked) => {
                      onChange(i, {
                        acCode: String(picked.code),
                        acName: String(picked.name ?? ''),
                      });
                      // Only Enter in the cell moves on (MS_BOOK.cs:2348-2358). The lookup also resolves the code
                      // when the cell is left (an arrow, a click); that late answer must not pull the focus back
                      // from where the operator went, since the desktop arrows only move the cell (:2283-2301).
                      if (cellHasFocus(i, AC_CODE)) nextRow(i);
                    }}
                    style={{ width: column.width }}
                  />
                ) : (
                  <input
                    aria-label={`${column.header} row ${i + 1}`}
                    value={row[column.key]}
                    maxLength={column.maxLength}
                    readOnly={c === AC_NAME || disabled}
                    inputMode={c === SR ? 'numeric' : undefined}
                    onChange={(e) =>
                      onChange(i, {
                        [column.key]:
                          c === SR ? e.target.value.replace(/\D/g, '') : typed(e.target.value),
                      })
                    }
                    onBlur={() => {
                      // Strings.Format(TEXT_ENTRY.Text, "0") on the Sr cell (:2256).
                      if (c === SR && row.srNo.trim())
                        onChange(i, { srNo: String(Number(row.srNo)) });
                    }}
                    style={{ width: column.width }}
                  />
                )}
              </td>
            ))}
          </tr>
        ))}
      </tbody>
    </table>
  );
}
