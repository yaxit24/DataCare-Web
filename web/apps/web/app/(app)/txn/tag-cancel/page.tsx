'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { ParityContainmentNotice } from '../../../../components/ParityContainmentNotice';
import { parityContainmentMessage, parityContainmentRule } from '@datacare/core/containment';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import SubDetailGrid, { useSubDetail } from '../../../../components/SubDetailGrid';
import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';

// TAG CANCEL (TR_TAG_CAN) — remove one or more tags from stock. Posts to /stock/tag-cancel
// (tagCancel), which writes a MAIN_STOCK out-movement per tag (VCH_TYPE 'TGCAN', ITM_SIGN '-').
// Pure inventory removal — no money ledger. Mirrors the desktop Tag Cancellation screen.
interface Line {
  transferItCode: string;
  tagNo: string;
  itCode: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  fineWt: string;
  bagWt: string;
  lotNo: string;
}
/**
 * P7 extended grid columns: desktop columns this form has and the web did not.
 *
 * Every entry was verified against the WRITER, not the API interface — a field present on the
 * interface is not necessarily persisted (purchase hard-codes ITM_SIZE to blank, and five
 * SaleLineInput fields have no SL_DETL column at all), and such a cell would silently discard
 * what the operator types.
 */
const extendedLineFields: Array<[keyof Line, string]> = [
  ['bagWt', 'BagWt'],
  ['lotNo', 'LotNo'],
];

/** Fields the API takes as numbers; everything else stays a string so codes are not mangled. */
const NUMERIC_EXTENDED = new Set<string>(['bagWt']);

const blank = (): Line => ({
  transferItCode: '',
  tagNo: '',
  itCode: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  fineWt: '',
  bagWt: '',
  lotNo: '',
});
const n = (v: string) => Number(v || 0);
const containment = parityContainmentRule('tag-cancel');

/**
 * P3: Line fields the server accepted that no screen could send.
 *
 * Cancelling a tag can transfer its metal to a different item code (the loose-stock item it returns to).
 */
const extendedP3Fields: Array<[keyof Line, string]> = [['transferItCode', 'TrfItCode']];

export default function TagCancelPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [fullGrid, setFullGrid] = useState(false);
  // Desktop TR_TAG_CAN sub-detail (17 cols) hangs a sub-detail row set under each item line; the server
  // already persists it and this page sent nothing.
  const sub = useSubDetail(lines.length);
  // Desktop grids are keyboard-driven: arrows move between cells, Enter advances and
  // appends a row at the end, Ctrl/Cmd+D removes one (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    onAppendRow: () => {
      setLines((rows) => [...rows, blank()]);
      sub.appendLine();
    },
    onRemoveRow: (row) => {
      setLines((rows) =>
        rows.length === 1 ? [blank()] : rows.filter((_, index) => index !== row),
      );
      sub.removeLine(row);
      return true;
    },
    onEscape: () => {},
  });
  const [res, setRes] = useState<{ vchNo: number; tags: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setRes(null);
    if (containment.blocked) {
      setErr(parityContainmentMessage('tag-cancel'));
      return;
    }
    setBusy(true);
    try {
      const body = {
        coBook,
        coYear,
        lcCode,
        lines: lines

          // Original index carried through the filter: empty lines are dropped, so a

          // filtered position would attach a sub-detail block to a different item.

          .map((l, sourceIndex) => ({ l, sourceIndex }))

          .filter(({ l }) => l.tagNo && l.itCode)

          .map(({ l, sourceIndex }) => ({
            // P7: writer-verified extended columns. A blank cell is OMITTED, never sent as 0 — an
            // explicit zero is an override at the writer and defeats the server's derivation.
            ...Object.fromEntries(
              extendedLineFields
                .map(([key]) => [
                  key,
                  String((l as unknown as Record<string, unknown>)[key] ?? '').trim(),
                ])
                .filter(([, v]) => v !== '')
                .map(([key, v]) => [key, NUMERIC_EXTENDED.has(key as string) ? Number(v) : v]),
            ),
            transferItCode: l.transferItCode || undefined,
            stones: sub.inputsFor(sourceIndex),
            tagNo: l.tagNo,
            itCode: l.itCode,
            pcs: n(l.pcs),
            netWt: n(l.netWt),
            grossWt: n(l.grossWt),
            touch: n(l.touch),
            fineWt: n(l.fineWt),
          })),
      };
      setRes(await post('/stock/tag-cancel', body));
    } catch (e) {
      setErr(
        e instanceof ApiError
          ? e.body?.message || e.body?.error || e.body?.detail || e.message
          : 'failed',
      );
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Tag Cancellation</h1>
      <ParityContainmentNotice operation="tag-cancel" />
      <p className="muted">
        Cancel tags and remove them from stock. Each tag posts a stock-out movement (MAIN_STOCK,
        VCH_TYPE &lsquo;TGCAN&rsquo;) — no money ledger.
      </p>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="TGC" />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly />
            </div>
            <div className="field">
              <label>Location</label>
              <input value={lcCode} readOnly />
            </div>
          </div>
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Tags to Cancel</h2>
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedP3Fields.length}
            testId="tag-cancel-p3-mode"
          />
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedLineFields.length}
            testId="tag-cancel-grid-mode"
          />
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Tag</th>
                <th>Item</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch %</th>
                <th className="num">Fine</th>
                <ExtendedHeaderCells full={fullGrid} fields={extendedP3Fields} />
                <ExtendedHeaderCells full={fullGrid} fields={extendedLineFields} />
                <th></th>
              </tr>
            </thead>
            <tbody>
              {lines.map((l, i) => (
                <tr key={i}>
                  <td>
                    <LookupPicker
                      entity="tags"
                      value={l.tagNo}
                      onChange={(v) => setLine(i, 'tagNo', v)}
                      style={{ width: 120 }}
                      onPick={(r) =>
                        setLines((ls) =>
                          ls.map((x, j) =>
                            j === i
                              ? {
                                  ...x,
                                  tagNo: String(r.code),
                                  itCode: String(r.name ?? x.itCode),
                                  netWt: String(r.ITM_NWT ?? x.netWt),
                                  grossWt: String(r.ITM_GWT ?? x.grossWt),
                                  touch: String(r.ITM_TOUCH ?? x.touch),
                                  fineWt: String(r.ITM_FINE ?? x.fineWt),
                                }
                              : x,
                          ),
                        )
                      }
                    />
                  </td>
                  <td>
                    <input
                      value={l.itCode}
                      onChange={(e) => setLine(i, 'itCode', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 44, textAlign: 'right' }}
                      value={l.pcs}
                      onChange={(e) => setLine(i, 'pcs', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 64, textAlign: 'right' }}
                      value={l.grossWt}
                      onChange={(e) => setLine(i, 'grossWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 64, textAlign: 'right' }}
                      value={l.netWt}
                      onChange={(e) => setLine(i, 'netWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 56, textAlign: 'right' }}
                      value={l.touch}
                      onChange={(e) => setLine(i, 'touch', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 64, textAlign: 'right' }}
                      value={l.fineWt}
                      onChange={(e) => setLine(i, 'fineWt', e.target.value)}
                    />
                  </td>
                  <ExtendedBodyCells
                    full={fullGrid}
                    fields={extendedLineFields}
                    line={l}
                    row={i}
                    baseColumns={9}
                    setValue={(row, key, value) => setLine(row, key, value)}
                  />
                  <td>
                    <button
                      type="button"
                      className="danger"
                      onClick={() => setLines((ls) => ls.filter((_, j) => j !== i))}
                    >
                      ×
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <div className="row" style={{ marginTop: 8, alignItems: 'flex-end' }}>
            <div className="field">
              <label>Stones for line</label>
              <select
                value={sub.activeLine}
                onChange={(e) => sub.setActiveLine(Number(e.target.value))}
              >
                {lines.map((l, i) => (
                  <option key={i} value={i}>
                    {i + 1}
                    {l.itCode ? ` — ${l.itCode}` : ''}
                  </option>
                ))}
              </select>
            </div>
            <div className="field">
              <span className="muted">{sub.totalRows} row(s) on this voucher</span>
            </div>
          </div>
          <SubDetailGrid
            rows={sub.rowsFor(sub.activeLine)}
            onRowsChange={(r) => sub.setRowsFor(sub.activeLine, r)}
            parentLabel={`line ${sub.activeLine + 1}`}
            desktopSource="TR_TAG_CAN sub-detail (17 cols)"
          />
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setLines((ls) => [...ls, blank()])}
            >
              + Add tag
            </button>
            <span className="spacer" />
            <button className="primary" disabled={busy || containment.blocked}>
              {busy ? 'Cancelling…' : 'Cancel Tags'}
            </button>
          </div>
        </div>
      </form>
      {err && <div className="msg err">{err}</div>}
      {res && (
        <div className="panel">
          <div className="msg ok">
            Cancel voucher #{res.vchNo} created — {res.tags} tag(s) cancelled
          </div>
        </div>
      )}
    </div>
  );
}
