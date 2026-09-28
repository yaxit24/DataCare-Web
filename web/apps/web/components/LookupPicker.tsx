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
        setRows(r || []);
        setHi(0);
        setOpen(true);
      } catch {
        setRows([]);
      }
    }, 180);
  }
  const pick = (r: LookupRow) => {
    onChange(String(r.code));
    onPick?.(r);
    setOpen(false);
    if (advanceOnPick && inputRef.current) focusNext(inputRef.current);
  };

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
          onChange(e.target.value);
          search(e.target.value);
        }}
        onFocus={() => {
          if (value !== undefined) search(value);
        }}
        onKeyDown={(e) => {
          if (e.key === 'F1') {
            e.preventDefault();
            search(value ?? '');
            return;
          } // desktop F1-LOV: open lookup
          if (!open) return;
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
