'use client';
import { formatDesktopDate } from '@datacare/core';
import { useEffect, useMemo, useRef, useState } from 'react';
import { ApiError, get } from '../lib/api';
import { saleLineFromView } from '../lib/saleResidual';

/**
 * Sales Invoice "Apr No" (TR_SALE.cs). The box is read-only (tIsuNo, :5465) and is filled from the "A" button
 * (btnIsuNo, ToolTip "Approval Help", :5449-5450), whose help lists the open Approval Isu vouchers (:20562-20590).
 * Enter in the box (tIsuNo_KeyDown, :19669) loads that voucher's open lines: none reopens the help (:20020-20023);
 * otherwise the party is taken from the approval (:20042-20048) and "All Approval Tag In This Voucher Import?"
 * (:20050) replaces the item grid with the approval's lines (:20060-20520). The sale save closes them (:16112).
 */

interface HelpRow {
  vchNo: string;
  vchDate: string;
  partyName: string;
  tagQty: number;
  year: string;
  book: string;
}
interface Imported {
  found: boolean;
  acCode: string;
  acName: string;
  acGstType: string;
  lines: Array<Record<string, unknown>>;
}
export interface SaleApprovalNo {
  issueNo: string;
  issueYear: string;
  issueBook: string;
}

const EMPTY: SaleApprovalNo = { issueNo: '', issueYear: '', issueBook: '' };

/** The header's Apr No, year and book (SL_DATA.ISU_NO, ISU_YRCD, ISU_DBCD; TR_SALE.cs:14377-14379, :15310-15313). */
export function useSaleApprovalNo() {
  const [value, setValue] = useState<SaleApprovalNo>(EMPTY);
  return {
    value,
    set: setValue,
    reset: () => setValue(EMPTY),
    load: (view: any) =>
      setValue({
        issueNo: String(view.issueNo ?? ''),
        issueYear: String(view.issueYear ?? ''),
        issueBook: String(view.issueBook ?? ''),
      }),
    body: () => ({
      issueNo: value.issueNo || undefined,
      issueYear: value.issueYear || undefined,
      issueBook: value.issueBook || undefined,
    }),
  };
}

/** The imported columns the shared reopen mapping (saleLineFromView) leaves out: counter, HUID, MRP, wastage, ghat. */
function approvalLineExtras(line: Record<string, unknown>): Record<string, string> {
  const s = (v: unknown) => (v == null || Number(v) === 0 ? '' : String(v));
  return {
    tblCode: String(line.tblCode ?? ''),
    huid: String(line.huid ?? ''),
    mrp: s(line.mrp),
    westPct: s(line.westPct),
    ghtWt: s(line.ghtWt),
    metal: String(line.metal ?? ''),
  };
}

export function SaleApprovalImport<T>({
  apr,
  blank,
  party,
  onLines,
}: {
  apr: ReturnType<typeof useSaleApprovalNo>;
  blank: () => T;
  /** The bill takes the approval's party (TR_SALE.cs:20042-20048) and, from it, the GST split. */
  party: {
    setAcCode: (code: string) => void;
    setAcName: (name: string) => void;
    setInterState: (interState: boolean) => void;
  };
  onLines: (lines: T[]) => void;
}) {
  const [help, setHelp] = useState<HelpRow[] | null>(null);
  const [err, setErr] = useState('');
  const box = useRef<HTMLInputElement>(null);
  const fail = (e: unknown) =>
    setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');

  async function openHelp() {
    setErr('');
    try {
      setHelp(await get<HelpRow[]>('/sales/approval-help'));
    } catch (e) {
      fail(e);
    }
  }

  async function importLines() {
    const { issueNo, issueYear, issueBook } = apr.value;
    if (!issueNo) return openHelp();
    setErr('');
    try {
      const q = new URLSearchParams({
        aprYear: issueYear,
        aprBook: issueBook,
        aprNo: issueNo,
      });
      const got = await get<Imported>(`/sales/approval-import?${q}`);
      if (!got.found) return openHelp();
      party.setAcCode(got.acCode);
      party.setAcName(got.acName);
      if (got.acGstType) party.setInterState(got.acGstType !== 'L');
      if (!window.confirm('All Approval Tag In This Voucher Import?')) return;
      onLines(
        got.lines.map(
          (l) => ({ ...blank(), ...saleLineFromView(l), ...approvalLineExtras(l) }) as T,
        ),
      );
    } catch (e) {
      fail(e);
    }
  }

  return (
    <>
      <div className="field">
        <label>Apr No</label>
        <input
          ref={box}
          aria-label="Apr No"
          value={apr.value.issueNo}
          readOnly
          style={{ width: 80 }}
          onKeyDown={(e) => {
            if (e.key !== 'Enter') return;
            e.preventDefault();
            void importLines();
          }}
        />
      </div>
      <button type="button" className="ghost" title="Approval Help" onClick={() => void openHelp()}>
        A
      </button>
      {err && (
        <span className="msg err" role="alert">
          {err}
        </span>
      )}
      {help && (
        <ApprovalHelp
          rows={help}
          onClose={() => {
            setHelp(null);
            box.current?.focus();
          }}
          onPick={(row) => {
            apr.set({ issueNo: row.vchNo, issueYear: row.year, issueBook: row.book });
            setHelp(null);
            box.current?.focus();
          }}
        />
      )}
    </>
  );
}

/** MS_HELP over VchNoL, VchDateL, PartyNameL, TagQtyM, YearL, BookL. Typing filters, Up/Down move, Enter picks. */
function ApprovalHelp({
  rows,
  onPick,
  onClose,
}: {
  rows: HelpRow[];
  onPick: (row: HelpRow) => void;
  onClose: () => void;
}) {
  const [filter, setFilter] = useState('');
  const [hi, setHi] = useState(0);
  const input = useRef<HTMLInputElement>(null);
  const shown = useMemo(() => {
    const f = filter.trim().toUpperCase();
    return f
      ? rows.filter((r) => [r.vchNo, r.partyName].some((v) => v.toUpperCase().includes(f)))
      : rows;
  }, [rows, filter]);
  useEffect(() => input.current?.focus(), []);
  useEffect(() => setHi(0), [filter]);

  function onKeyDown(e: React.KeyboardEvent) {
    if (e.key === 'ArrowDown') {
      e.preventDefault();
      setHi((h) => Math.min(h + 1, shown.length - 1));
    } else if (e.key === 'ArrowUp') {
      e.preventDefault();
      setHi((h) => Math.max(h - 1, 0));
    } else if (e.key === 'Enter') {
      e.preventDefault();
      const row = shown[hi];
      if (row) onPick(row);
    } else if (e.key === 'Escape') {
      e.preventDefault();
      e.stopPropagation();
      onClose();
    }
  }

  return (
    <div
      className="panel"
      role="dialog"
      aria-label="Approval Help"
      data-lookup-open="true"
      onKeyDown={onKeyDown}
      style={{ position: 'relative', zIndex: 5, width: '100%' }}
    >
      <div className="row" style={{ alignItems: 'center' }}>
        <strong>Approval Help</strong>
        <input
          ref={input}
          aria-label="Search approvals"
          value={filter}
          onChange={(e) => setFilter(e.target.value)}
          placeholder="vch no or party…"
          style={{ marginLeft: 12, width: 220 }}
        />
        <span className="spacer" />
        <button type="button" className="ghost" onClick={onClose}>
          Close
        </button>
      </div>
      {shown.length === 0 ? (
        <p className="muted">No open approval.</p>
      ) : (
        <table className="grid" style={{ marginTop: 8 }}>
          <thead>
            <tr>
              <th>VchNo</th>
              <th>VchDate</th>
              <th>PartyName</th>
              <th className="num">TagQty</th>
              <th>Year</th>
              <th>Book</th>
            </tr>
          </thead>
          <tbody>
            {shown.map((r, i) => (
              <tr
                key={`${r.year}|${r.book}|${r.vchNo}`}
                aria-selected={i === hi}
                data-approval={r.vchNo}
                style={i === hi ? { background: 'var(--sel, #dbeafe)' } : undefined}
                onMouseEnter={() => setHi(i)}
                onClick={() => onPick(r)}
              >
                <td>{r.vchNo}</td>
                <td>{formatDesktopDate(r.vchDate)}</td>
                <td>{r.partyName}</td>
                <td className="num">{r.tagQty}</td>
                <td>{r.year}</td>
                <td>{r.book}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
