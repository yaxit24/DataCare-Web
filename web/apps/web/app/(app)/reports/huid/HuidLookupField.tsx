'use client';
import { useRef, useState } from 'react';
import { isCurrentAnswer, lookupEnterAction } from '../../../../lib/lookupEnter';
import type { HelpRow } from './types';

/** Focus a named control by its accessible label; disabled controls are skipped by the browser. */
export function focusControl(label: string): void {
  const control = document.querySelector<HTMLElement>(`[aria-label="${label}"]`);
  control?.focus();
}

/**
 * The RP_HUID TagNo and AcCode boxes with the desktop's Enter lookup.
 *
 * Enter looks the typed code up exactly, and only a code that matches nothing opens the help list
 * (RP_HUID.cs:2229-2247 for the tag: `Select A.TAG_NO FROM BAR_DETL AS A WHERE A.CO_CODE` then the help
 * dialog; :2689-2729 for the account, with `((TextBoxBase)tAcCode).SelectAll();` on a match). The list is
 * the same /lookup/:entity source the other screens use, so the codes the report filters by are the codes
 * the help offers.
 *
 * Every typed character is upper-cased, as the desktop form does (RP_HUID.cs:1715
 * `num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));`). The desktop also drops
 * the apostrophe and NUL there (:1718) — a partial guard for its string-built SQL; the web binds
 * parameters instead, so a valid tag's characters are never dropped.
 */
export function HuidLookupField({
  label,
  value,
  onChange,
  load,
  maxLength,
  /** The desktop selects the AcCode text when the account is found (RP_HUID.cs:2729). */
  selectAllOnResolve = false,
  focusAfter,
}: {
  label: string;
  value: string;
  onChange: (value: string) => void;
  load: (term: string) => Promise<HelpRow[]>;
  maxLength?: number;
  selectAllOnResolve?: boolean;
  /** Where Enter moves when the box is empty (the desktop's Tab, :2660). */
  focusAfter?: string;
}) {
  const [rows, setRows] = useState<HelpRow[]>([]);
  const [open, setOpen] = useState(false);
  const [rowsFor, setRowsFor] = useState<string | null>(null);
  const input = useRef<HTMLInputElement>(null);
  const lookup = useRef({ ticket: 0, pending: false });
  const latest = useRef(value);
  latest.current = value;

  const accept = (row: HelpRow, advance: boolean) => {
    onChange(row.code);
    setOpen(false);
    // An answer that arrives after the operator moved on must not pull the focus back.
    const stillHere =
      document.activeElement === input.current || document.activeElement === document.body;
    if (advance && focusAfter && stillHere) focusControl(focusAfter);
    else focusControl(label);
    if (selectAllOnResolve) input.current?.select();
  };

  const resolveEnter = async (typed: string) => {
    const requested = typed.trim();
    const mine = ++lookup.current.ticket;
    lookup.current.pending = true;
    let found: HelpRow[];
    try {
      found = await load(requested);
    } catch {
      if (mine === lookup.current.ticket) lookup.current.pending = false;
      return;
    }
    // A late answer must never overwrite a newer selection.
    if (mine !== lookup.current.ticket || !isCurrentAnswer(requested, latest.current)) return;
    const exact =
      found.find((row) => row.code.trim().toUpperCase() === requested.toUpperCase()) ??
      found.find((row) => row.name.trim().toUpperCase() === requested.toUpperCase());
    if (exact) {
      lookup.current.pending = false;
      accept(exact, true);
      return;
    }
    try {
      const choices = await load('');
      if (mine !== lookup.current.ticket || !isCurrentAnswer(requested, latest.current)) return;
      setRows(choices);
    } catch {
      if (mine === lookup.current.ticket) lookup.current.pending = false;
      return;
    }
    lookup.current.pending = false;
    setRowsFor(typed);
    setOpen(true);
  };

  return (
    <div className="field" style={{ minWidth: 130, position: 'relative' }}>
      <label htmlFor={`huid-${label.replaceAll(' ', '-')}`}>{label}</label>
      <input
        ref={input}
        id={`huid-${label.replaceAll(' ', '-')}`}
        aria-label={label}
        value={value}
        maxLength={maxLength}
        autoComplete="off"
        onChange={(event) => {
          lookup.current.ticket += 1;
          lookup.current.pending = false;
          setOpen(false);
          // Upper-case only (RP_HUID.cs:1715); no character is dropped.
          onChange(event.target.value.toUpperCase());
        }}
        onKeyDown={(event) => {
          if (event.key === 'Escape' && (open || lookup.current.pending)) {
            event.preventDefault();
            event.stopPropagation();
            lookup.current.ticket += 1;
            lookup.current.pending = false;
            setOpen(false);
            return;
          }
          if (event.key !== 'Enter') return;
          event.preventDefault();
          const action = lookupEnterAction({ open, rowCount: rows.length, rowsFor, value });
          if (action === 'pick-highlighted' && rows[0]) {
            accept(rows[0], false);
            return;
          }
          if (action === 'none') {
            if (focusAfter) focusControl(focusAfter);
            return;
          }
          void resolveEnter(value);
        }}
      />
      {open && (
        <div
          role="dialog"
          aria-label={`${label} help`}
          data-lookup-open="true"
          onKeyDown={(event) => {
            if (event.key === 'Escape') {
              event.preventDefault();
              event.stopPropagation();
              setOpen(false);
              focusControl(label);
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
              onClick={() => accept(row, false)}
              style={{ display: 'block', width: '100%', textAlign: 'left' }}
            >
              <span>{row.code}</span> · {row.name}
            </button>
          ))}
          {rows.length === 0 && <div style={{ padding: 8 }}>No matching record</div>}
        </div>
      )}
    </div>
  );
}
