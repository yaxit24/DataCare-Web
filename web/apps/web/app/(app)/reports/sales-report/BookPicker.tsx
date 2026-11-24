'use client';
import { useState } from 'react';

export interface BookRow {
  code: string;
  name: string;
}

/**
 * PnlIt: the Select Book grid (RP_ALL.cs:11355-11403, :11405-11458): a check column, CO_BOOK and BOOK_NAME. Ok builds the
 * list (nothing ticked: "Book Selection Not Done..."), Cancel closes the panel and clears the selection.
 */
export function BookPicker({
  rows,
  picked,
  onOk,
  onCancel,
}: {
  rows: BookRow[];
  picked: string[];
  onOk: (codes: string[]) => void;
  onCancel: () => void;
}) {
  const [draft, setDraft] = useState<string[]>(picked);
  const toggle = (code: string) =>
    setDraft((current) =>
      current.includes(code) ? current.filter((entry) => entry !== code) : [...current, code],
    );
  return (
    <div className="panel" role="group" aria-label="Select Book list" style={{ marginTop: 8 }}>
      {rows.map((row) => (
        <label key={row.code} style={{ display: 'block' }}>
          <input
            type="checkbox"
            checked={draft.includes(row.code)}
            onChange={() => toggle(row.code)}
          />{' '}
          {row.code} {row.name}
        </label>
      ))}
      {rows.length === 0 && <div className="muted">No books</div>}
      <div className="row" style={{ marginTop: 6 }}>
        <button type="button" className="ghost" onClick={() => onOk(draft)}>
          Ok
        </button>
        <button type="button" className="ghost" onClick={onCancel}>
          Cancel
        </button>
      </div>
    </div>
  );
}
