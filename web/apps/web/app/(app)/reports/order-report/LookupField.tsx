'use client';
import { useEffect, useRef, useState } from 'react';
import { isCurrentAnswer, lookupEnterAction } from '../../../../lib/lookupEnter';

export interface HelpRow {
  code: string;
  name: string;
}

/** Uppercase and drop the apostrophe exactly as the desktop's form-wide KeyPress (RP_ALL.cs:7251). */
export const desktopText = (value: string): string => value.replaceAll("'", '').toUpperCase();

/** Focus a named control by its accessible label; disabled controls are skipped by the browser. */
export function focusControl(label: string): void {
  const control = document.querySelector<HTMLElement>(`[aria-label="${label}"]`);
  control?.focus();
}

/**
 * The RP_ALL lookups: Enter resolves an exact typed code/name from the same source the desktop reads, and only
 * opens the help dialog when nothing matches. An answer for older text is never applied (lib/lookupEnter.ts).
 */
export function LookupField({
  label,
  value,
  onChange,
  load,
  maxLength,
  disabled = false,
  focusAfter,
  onName,
}: {
  label: string;
  value: string;
  onChange: (value: string) => void;
  load: (term: string) => Promise<HelpRow[]>;
  maxLength?: number;
  disabled?: boolean;
  focusAfter?: string;
  onName?: (name: string) => void;
}) {
  const [rows, setRows] = useState<HelpRow[]>([]);
  const [open, setOpen] = useState(false);
  const [rowsFor, setRowsFor] = useState<string | null>(null);
  const latest = useRef(value);
  const [name, setName] = useState('');
  latest.current = value;

  useEffect(() => {
    if (!value) setName('');
  }, [value]);

  const accept = (row: HelpRow, advance: boolean) => {
    onChange(row.code);
    setName(row.name);
    onName?.(row.name);
    setOpen(false);
    if (advance && focusAfter) focusControl(focusAfter);
  };

  const resolveEnter = async (typed: string) => {
    const requested = typed.trim();
    const found = await load(requested);
    // A late answer must never overwrite a newer selection.
    if (!isCurrentAnswer(requested, latest.current)) return;
    const exact =
      found.find((row) => row.code.trim().toUpperCase() === requested.toUpperCase()) ??
      found.find((row) => row.name.trim().toUpperCase() === requested.toUpperCase());
    if (exact) {
      accept(exact, true);
      return;
    }
    setRowsFor(typed);
    setRows(found);
    setOpen(true);
  };

  return (
    <div className="field" style={{ minWidth: 140, position: 'relative' }}>
      <label htmlFor={`or-${label.replaceAll(' ', '-')}`}>{label}</label>
      <input
        id={`or-${label.replaceAll(' ', '-')}`}
        aria-label={label}
        value={value}
        maxLength={maxLength}
        disabled={disabled}
        onChange={(event) => onChange(desktopText(event.target.value))}
        onKeyDown={(event) => {
          if (event.key === 'Escape' && open) {
            event.preventDefault();
            event.stopPropagation();
            setOpen(false);
            return;
          }
          if (event.key !== 'Enter') return;
          const action = lookupEnterAction({
            open,
            rowCount: rows.length,
            rowsFor,
            value,
          });
          if (action === 'none') {
            if (focusAfter) focusControl(focusAfter);
            return;
          }
          event.preventDefault();
          void resolveEnter(value);
        }}
      />
      {name && !open && (
        <span className="muted" data-lookup-name={label} style={{ fontSize: 11 }}>
          {name}
        </span>
      )}
      {open && (
        <div
          role="dialog"
          aria-label={`${label} help`}
          onKeyDown={(event) => {
            if (event.key === 'Escape') {
              event.preventDefault();
              event.stopPropagation();
              setOpen(false);
            }
          }}
          style={{
            position: 'absolute',
            zIndex: 60,
            top: '100%',
            left: 0,
            minWidth: 240,
            maxHeight: 220,
            overflow: 'auto',
            background: 'var(--panel,#fff)',
            border: '1px solid var(--border,#ccc)',
            borderRadius: 6,
          }}
        >
          {rows.map((row, index) => (
            <button
              type="button"
              key={`${row.code}-${index}`}
              onClick={() => accept(row, true)}
              style={{ display: 'block', width: '100%', textAlign: 'left' }}
            >
              {row.code} · {row.name}
            </button>
          ))}
          {rows.length === 0 && <div style={{ padding: 8 }}>No matching record</div>}
        </div>
      )}
    </div>
  );
}
