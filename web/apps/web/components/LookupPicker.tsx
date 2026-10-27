'use client';
import { useEffect, useRef, useState } from 'react';
import { get } from '../lib/api';
import { focusNext } from './focus';

export interface LookupRow {
  code: string;
  name: string;
  [k: string]: unknown;
}

/**
 * Type-ahead picker over a master (accounts/items/tags/...). Searches /api/lookup/:entity,
 * shows a dropdown, and on select fills the code + calls onPick(row) so the form can autofill
 * related fields (party name/GST-type, tag weight/rate, etc.) — mirrors the desktop F-key lookups.
 */
export function LookupPicker({
  entity,
  value,
  onChange,
  onPick,
  searchPath,
  placeholder,
  ariaLabel,
  style,
  advanceOnPick = true,
}: {
  entity: string;
  value: string;
  onChange: (code: string) => void;
  onPick?: (row: LookupRow) => void;
  /** Optional workflow lookup endpoint; defaults to /lookup/:entity. */
  searchPath?: string;
  placeholder?: string;
  ariaLabel?: string;
  style?: React.CSSProperties;
  /** Workflows with asynchronous validation move focus after their own successful commit. */
  advanceOnPick?: boolean;
}) {
  const [open, setOpen] = useState(false);
  const [rows, setRows] = useState<LookupRow[]>([]);
  const [hi, setHi] = useState(0);
  const boxRef = useRef<HTMLDivElement>(null);
  const inputRef = useRef<HTMLInputElement>(null);
  const tmr = useRef<any>(null);
  /** The code last chosen from the list or resolved from typing, so a resolve never fires twice for it. */
  const picked = useRef<string | null>(null);

  useEffect(() => {
    const onDoc = (e: MouseEvent) => {
      if (boxRef.current && !boxRef.current.contains(e.target as Node)) setOpen(false);
    };
    document.addEventListener('mousedown', onDoc);
    return () => document.removeEventListener('mousedown', onDoc);
  }, []);

  function search(q: string) {
    clearTimeout(tmr.current);
    tmr.current = setTimeout(async () => {
      try {
        const base = searchPath || `/lookup/${entity}`;
        const separator = base.includes('?') ? '&' : '?';
        const r = (await get(
          `${base}${separator}q=${encodeURIComponent(q)}&limit=20`,
        )) as LookupRow[];
        // G94: the search still runs, but a reply that arrives after the operator has left the field opens
        // nothing — otherwise its list floats under another field, covering the controls below it.
        if (document.activeElement !== inputRef.current) return;
        setRows(r || []);
        setHi(0);
        setOpen(true);
      } catch {
        setRows([]);
      }
    }, 180);
  }
  const pick = (r: LookupRow) => {
    picked.current = String(r.code);
    onChange(String(r.code));
    onPick?.(r);
    setOpen(false);
    if (advanceOnPick && inputRef.current) focusNext(inputRef.current);
  };
  /**
   * The desktop resolves a typed code on Enter: `tAcCode_KeyDown` looks the exact code up in AC_MAST and fills
   * the party's details, opening F1 help only when nothing matches (`TR_PURC.cs:14619-14628`; `TR_SALE.cs:17340`
   * is the same). Here a typed value that matches one lookup code exactly is picked on Enter before the list has
   * opened, and also when the field is left (Tab or a click elsewhere), so the screen's `onPick` effects (name,
   * inter-state, rates) always run. Found in the 2026-10-26 browser run: a supplier typed and tabbed past left the
   * name blank and inter-state "No", and the purchase was refused.
   */
  async function resolveTyped(): Promise<void> {
    const typed = String(value ?? '').trim();
    if (!typed || !onPick || picked.current === typed) return;
    try {
      const base = searchPath || `/lookup/${entity}`;
      const separator = base.includes('?') ? '&' : '?';
      const r = (await get(
        `${base}${separator}q=${encodeURIComponent(typed)}&limit=20`,
      )) as LookupRow[];
      const exact = (r || []).find(
        (row) => String(row.code).trim().toUpperCase() === typed.toUpperCase(),
      );
      if (!exact) return;
      picked.current = String(exact.code);
      if (String(exact.code) !== value) onChange(String(exact.code));
      onPick(exact);
    } catch {
      // An unreachable lookup leaves the typed value as it is; the save validates it.
    }
  }

  return (
    <div
      ref={boxRef}
      data-lookup-open={open && rows.length > 0 ? 'true' : undefined}
      style={{ position: 'relative', ...style }}
    >
      <input
        ref={inputRef}
        value={value}
        aria-label={ariaLabel}
        placeholder={placeholder || `search ${entity}… (F1)`}
        onChange={(e) => {
          picked.current = null;
          onChange(e.target.value);
          search(e.target.value);
        }}
        onFocus={() => {
          if (value !== undefined) search(value);
        }}
        onBlur={(e) => {
          // G94: the list closes when focus moves to another control (Tab, Enter-advance, a programmatic
          // focus); a click on a non-focusable area is handled by the document listener above. An open list
          // is an overlay to FormKeys, so a list left behind kept every F-key inert. A null relatedTarget
          // (the list's own scrollbar, another window) leaves it open.
          const next = e.relatedTarget;
          if (next instanceof Node && !boxRef.current?.contains(next)) {
            setOpen(false);
            void resolveTyped();
          } else if (next == null) void resolveTyped();
        }}
        onKeyDown={(e) => {
          if (e.key === 'F1') {
            e.preventDefault();
            search(value ?? '');
            return;
          } // desktop F1-LOV: open lookup
          if (!open) {
            if (e.key === 'Enter') void resolveTyped();
            return;
          }
          if (e.key === 'ArrowDown') {
            e.preventDefault();
            setHi((h) => Math.min(h + 1, rows.length - 1));
          } else if (e.key === 'ArrowUp') {
            e.preventDefault();
            setHi((h) => Math.max(h - 1, 0));
          } else if (e.key === 'Enter' && rows[hi]) {
            e.preventDefault();
            pick(rows[hi]);
          } else if (e.key === 'Escape') {
            e.preventDefault();
            setOpen(false);
          }
        }}
        style={{ width: '100%' }}
      />
      {open && rows.length > 0 && (
        <div
          style={{
            position: 'absolute',
            zIndex: 50,
            left: 0,
            right: 0,
            top: '100%',
            maxHeight: 240,
            overflow: 'auto',
            background: 'var(--panel,#fff)',
            border: '1px solid var(--border,#ccc)',
            borderRadius: 6,
            boxShadow: '0 6px 20px rgba(0,0,0,.15)',
          }}
        >
          {rows.map((r, i) => (
            <div
              key={String(r.code) + i}
              onMouseDown={() => pick(r)}
              onMouseEnter={() => setHi(i)}
              style={{
                padding: '6px 10px',
                cursor: 'pointer',
                background: i === hi ? 'var(--accent-bg,#eef)' : 'transparent',
                display: 'flex',
                justifyContent: 'space-between',
                gap: 12,
              }}
            >
              <span>
                <b>{String(r.code)}</b> {r.name ? `· ${r.name}` : ''}
              </span>
              <span className="muted" style={{ fontSize: 11 }}>
                {[r.AC_CITY, r.ITM_NWT && `${r.ITM_NWT}g`, r.ITM_RATE && `₹${r.ITM_RATE}`]
                  .filter(Boolean)
                  .join(' · ')}
              </span>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}
