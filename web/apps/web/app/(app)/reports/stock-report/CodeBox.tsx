'use client';
import { useRef, useState } from 'react';
import { get } from '../../../../lib/api';

interface HelpRow {
  code: string;
  name: string;
  [k: string]: unknown;
}

/**
 * A code box of the Stock Report with the desktop's Enter-opens-help behaviour (RP_STOCK.cs:5721 tPrCode_KeyDown,
 * :5753 tGrCode, :6145 tItCode, :6179 tDesignNo, :6092 tAcCode).
 *
 * Enter looks the typed code up exactly. A known code stays as it is (Ac Code then runs the Item summary, :6130). An
 * unknown or blank code opens the help list of the whole master; picking a row writes its code back, Esc closes the
 * list and leaves the box as it was (MS_HELP HelpClose). Only the answer of the latest Enter is shown, so a slow first
 * answer can never replace a later one.
 */
export function CodeBox({
  id,
  entity,
  value,
  onChange,
  onKnown,
  blankIsKnown = false,
}: {
  id: string;
  entity: string;
  value: string;
  onChange: (code: string) => void;
  /** Runs after Enter on a known code (and on a blank one when `blankIsKnown`). */
  onKnown?: () => void;
  /** tAcCode_KeyDown treats a blank box like a known code (it runs the Item summary). */
  blankIsKnown?: boolean;
}) {
  const [rows, setRows] = useState<HelpRow[] | null>(null);
  const [hi, setHi] = useState(0);
  const latest = useRef(0);
  const input = useRef<HTMLInputElement>(null);

  const close = () => {
    latest.current += 1;
    setRows(null);
  };
  const pick = (row: HelpRow) => {
    onChange(String(row.code));
    close();
    input.current?.focus();
    input.current?.select();
  };
  const enter = async () => {
    const mine = (latest.current += 1);
    const typed = value.trim();
    if (!typed && blankIsKnown) {
      onKnown?.();
      return;
    }
    try {
      let shown: HelpRow[] = [];
      if (typed) {
        const found =
          (await get<HelpRow[]>(`/lookup/${entity}?q=${encodeURIComponent(typed)}&limit=50`)) ?? [];
        if (mine !== latest.current) return;
        if (found.some((r) => String(r.code).trim().toUpperCase() === typed.toUpperCase())) {
          onKnown?.();
          return;
        }
        // The lookup answers at most 50 rows: the rows that contain the typed text come first, so a long master still
        // shows the codes the operator is after; the desktop shows the whole master (MS_HELP).
        shown = found;
      }
      if (shown.length === 0) {
        shown = (await get<HelpRow[]>(`/lookup/${entity}?q=&limit=50`)) ?? [];
        if (mine !== latest.current) return;
      }
      setHi(0);
      setRows(shown);
    } catch {
      // An unreachable lookup leaves the typed code as it is.
    }
  };

  return (
    <div
      style={{ position: 'relative' }}
      data-lookup-open={rows && rows.length > 0 ? 'true' : undefined}
    >
      <input
        ref={input}
        id={id}
        data-sr-field
        value={value}
        style={{ width: 110 }}
        onChange={(e) => {
          close();
          onChange(e.target.value.toUpperCase());
        }}
        onKeyDown={(e) => {
          if (rows) {
            if (e.key === 'ArrowDown') {
              e.preventDefault();
              setHi((h) => Math.min(h + 1, rows.length - 1));
            } else if (e.key === 'ArrowUp') {
              e.preventDefault();
              setHi((h) => Math.max(h - 1, 0));
            } else if (e.key === 'Enter') {
              e.preventDefault();
              const row = rows[hi];
              if (row) pick(row);
              else close();
            } else if (e.key === 'Escape') {
              e.preventDefault();
              e.stopPropagation();
              close();
            }
            return;
          }
          if (e.key === 'Enter') {
            e.preventDefault();
            void enter();
          }
        }}
      />
      {rows && (
        <div
          role="listbox"
          aria-label={`${id} help`}
          data-testid="stock-help"
          style={{
            position: 'absolute',
            zIndex: 50,
            left: 0,
            top: '100%',
            minWidth: 260,
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
              key={`${r.code}|${i}`}
              role="option"
              aria-selected={i === hi}
              onMouseDown={(e) => {
                e.preventDefault();
                pick(r);
              }}
              onMouseEnter={() => setHi(i)}
              style={{
                padding: '4px 10px',
                cursor: 'pointer',
                background: i === hi ? 'var(--accent-bg,#eef)' : 'transparent',
              }}
            >
              <b>{String(r.code)}</b> {r.name && r.name !== r.code ? `· ${String(r.name)}` : ''}
            </div>
          ))}
          {rows.length === 0 && (
            <div className="muted" style={{ padding: '4px 10px' }}>
              No records
            </div>
          )}
        </div>
      )}
    </div>
  );
}
