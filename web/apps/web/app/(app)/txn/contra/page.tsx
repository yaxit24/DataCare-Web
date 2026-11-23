'use client';
import { round, toIsoDate } from '@datacare/core';
import { useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { post, put, get, del, getDownload, ApiError } from '../../../../lib/api';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { VoucherList } from '../../../../components/VoucherList';
import { useVoucherNumberKeys, VoucherNumberNote } from '../../../../components/VoucherNumberKeys';
import { todayLocal } from '../../../../lib/localDate';

/** Desktop "Contra Entry" opens with `CurBookHelp("CONTRA")` (MDI_FORM.cs:8100-8111). */
const CONTRA_MAIN_BOOKS = ['CONTRA'];

type Side = 'DR' | 'CR';
type Row = { acCode: string; acName: string; itDesc: string; amount: string };
type F1Row = {
  vchNo: string;
  vchDate: string;
  partyName: string;
  vchDesc: string;
  user: string;
  crAmt: number;
  drAmt: number;
};
const blankRow = (): Row => ({ acCode: '', acName: '', itDesc: '', amount: '' });
const opposite = (side: Side): Side => (side === 'DR' ? 'CR' : 'DR');
/** Row 1 holds its own side (DR by default); every later row takes the other one (TR_CONTRA.cs:1538, :1630). */
const sideOf = (first: Side, index: number): Side => (index === 0 ? first : opposite(first));
const clock = () => new Date().toTimeString().slice(0, 8);
const weekday = (iso: string) =>
  new Date(`${iso}T00:00:00`).toLocaleDateString('en-US', { weekday: 'long' });
const PRINT_DENIED = 'You Have No Print Rights.....';
const focusLabel = (label: string) =>
  document.querySelector<HTMLInputElement>(`[aria-label="${label}"]`)?.focus();

/**
 * Contra Entry (TR_CONTRA): a grid of accounts. Row 1 is the main account, DR by default; every later row takes the
 * other side and its side cell is read-only (TR_CONTRA.cs:1530-1545, :1630). The CrAmt cell of a DR row and the DrAmt
 * cell of a CR row are read-only (:1643-1661). The totals row sums both columns as "0.00" (:1516); the server refuses
 * unequal totals with the desktop message (:2694). Keys: Enter in the amount of the last row adds a row (:2055), Ctrl+D
 * blanks a row after asking (:1814), Esc closes an untouched screen or goes to the employee box (:2978), F1 in the
 * voucher number box lists the book (:3135). A saved voucher is printed at once (:2902).
 */
export default function ContraPage() {
  const router = useRouter();
  const [coBook, setCoBook] = useState('');
  const [firstSide, setFirstSide] = useState<Side>('DR');
  const [rows, setRows] = useState<Row[]>([blankRow(), blankRow()]);
  const [vchDate, setVchDate] = useState(todayLocal());
  // The clock is set after mount so the server-rendered page and the first client render agree.
  const [time, setTime] = useState('');
  useEffect(() => setTime(clock()), []);
  const [empCode, setEmpCode] = useState('');
  const [empName, setEmpName] = useState('');
  const [res, setRes] = useState<{ vchNo: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const [touched, setTouched] = useState(false);
  const [loadedVch, setLoadedVch] = useState('');
  const [version, setVersion] = useState('');
  const [voucherLookup, setVoucherLookup] = useState('');
  const [f1, setF1] = useState<F1Row[] | null>(null);
  const [printDoc, setPrintDoc] = useState('');
  const [printNote, setPrintNote] = useState('');
  const n = (v: string) => Number(v || 0);
  const cell = (v: string) => round(n(v), 2);
  const total = (side: Side) =>
    round(
      rows.reduce((sum, r, i) => (sideOf(firstSide, i) === side ? sum + cell(r.amount) : sum), 0),
      2,
    );
  const equal = total('DR') === total('CR') && total('DR') > 0;
  const setRow = (i: number, patch: Partial<Row>) => {
    setTouched(true);
    setRows((rs) => rs.map((r, j) => (j === i ? { ...r, ...patch } : r)));
  };
  const addRow = () => setRows((rs) => [...rs, blankRow()]);

  /** Ctrl+D (TR_CONTRA.cs:1814-1828): ask, blank the row's cells, then say it takes effect on save. */
  function blankRowAt(i: number) {
    if (!window.confirm('This Row Record will Removed permantley ?')) return;
    setRow(i, blankRow());
    window.alert('Please Save This Voucher Then Effect....');
  }

  function resetForm() {
    setLoadedVch('');
    setVersion('');
    setVoucherLookup('');
    setFirstSide('DR');
    setRows([blankRow(), blankRow()]);
    setEmpCode('');
    setEmpName('');
    setVchDate(todayLocal());
    setTime(clock());
    setTouched(false);
    setRes(null);
    setErr('');
    setPrintDoc('');
    setPrintNote('');
  }

  async function loadContra(vchNo: string): Promise<boolean> {
    setErr('');
    setRes(null);
    setPrintDoc('');
    setPrintNote('');
    try {
      const d = await get<any>(
        `/contra/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVch(String(d.voucherNo ?? vchNo));
      setVoucherLookup(String(d.voucherNo ?? vchNo));
      setVersion(String(d.version ?? ''));
      const lines: any[] = d.lines ?? [];
      setFirstSide(String(lines[0]?.crdr).toUpperCase() === 'CR' ? 'CR' : 'DR');
      setRows(
        lines.map((l: any) => ({
          acCode: String(l.acCode ?? ''),
          acName: String(l.acName ?? ''),
          itDesc: String(l.itDesc ?? ''),
          amount: String(l.amount ?? ''),
        })),
      );
      setEmpCode(String(d.empCode ?? ''));
      setEmpName('');
      setVchDate(toIsoDate(d.vchDate ?? todayLocal()));
      setTouched(false);
      setF1(null);
      return true;
    } catch (e) {
      setErr(
        e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed to load',
      );
      return false;
    }
  }

  // N172 (G179): the voucher number box's F1, Up, Down and Enter (TR_CONTRA tVchNo_KeyDown).
  const numberKeys = useVoucherNumberKeys({
    table: 'CONTRA_DATA',
    book: coBook,
    value: voucherLookup,
    open: (vchNo) => loadContra(vchNo),
    fresh: resetForm,
  });

  // F1 (TR_CONTRA.BtnF1_Click, TR_CONTRA.cs:3135): the book's vouchers, one line per voucher, account and description.
  useEffect(() => {
    if (!numberKeys.listKey || !coBook) return;
    void get<F1Row[]>(`/contra/list?coBook=${encodeURIComponent(coBook)}`)
      .then(setF1)
      .catch((e) =>
        setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed'),
      );
  }, [numberKeys.listKey, coBook]);

  /** TR_CONTRA.BtnPrint_Click (:2995-3004): the print needs the print right; the preview is shown in the page. */
  async function printVoucher(vchNo: string) {
    setPrintDoc('');
    setPrintNote('');
    try {
      const { blob } = await getDownload(
        `/contra/${encodeURIComponent(vchNo)}/print?coBook=${encodeURIComponent(coBook)}&format=html`,
      );
      setPrintDoc(await blob.text());
    } catch (e) {
      setPrintNote(e instanceof ApiError && e.status === 403 ? PRINT_DENIED : 'print failed');
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setRes(null);
    if (!coBook) {
      setErr('select the configured contra book first');
      return;
    }
    setBusy(true);
    try {
      // The whole grid goes up in screen order: row 1 is positional and blank later rows are skipped by the server.
      const payload = {
        coBook,
        vchDate,
        empCode: empCode.trim() || undefined,
        ...(loadedVch ? { expectedVersion: version } : {}),
        lines: rows.map((r, i) => ({
          crdr: sideOf(firstSide, i),
          acCode: r.acCode.trim(),
          acName: r.acName.slice(0, 50) || undefined,
          itDesc: r.itDesc || undefined,
          amount: n(r.amount),
        })),
      };
      const saved = loadedVch
        ? await put<{ vchNo: number; version?: string }>(
            `/contra/${encodeURIComponent(loadedVch)}`,
            payload,
          )
        : await post<{ vchNo: number }>('/contra', payload);
      setRes(saved);
      const savedNo = String(saved.vchNo).padStart(5, '0');
      if (loadedVch) setVersion(String((saved as any).version ?? version));
      else resetFormKeepResult();
      await printVoucher(savedNo); // TR_CONTRA.cs:2902
    } catch (e) {
      setErr(
        e instanceof ApiError
          ? e.body?.message || e.body?.detail || e.body?.error || e.message
          : 'failed',
      );
    } finally {
      setBusy(false);
    }
  }

  function resetFormKeepResult() {
    setFirstSide('DR');
    setRows([blankRow(), blankRow()]);
    setEmpCode('');
    setEmpName('');
    setTime(clock());
    setTouched(false);
  }

  async function removeContra() {
    // TR_CONTRA.cs:2959 "Are You Sure To Delete This Voucher now?"
    if (!loadedVch || !window.confirm('Are You Sure To Delete This Voucher now?')) return;
    setBusy(true);
    setErr('');
    try {
      await del(
        `/contra/${encodeURIComponent(loadedVch)}?coBook=${encodeURIComponent(coBook)}&expectedVersion=${encodeURIComponent(version)}`,
      );
      resetForm();
      window.alert('Delete Success.'); // TR_CONTRA.cs:2969
    } catch (e) {
      setErr(
        e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'delete failed',
      );
    } finally {
      setBusy(false);
    }
  }

  /** Enter in an amount cell (TR_CONTRA.cs:2032-2059): a zero amount keeps the focus; otherwise go on to the next row. */
  function amountKey(e: React.KeyboardEvent<HTMLInputElement>, i: number) {
    if (e.ctrlKey && e.key.toLowerCase() === 'd') {
      e.preventDefault();
      blankRowAt(i);
      return;
    }
    if (e.key !== 'Enter') return;
    e.preventDefault();
    if (n(rows[i]!.amount) === 0) return;
    if (i === rows.length - 1) addRow();
    window.setTimeout(() => focusLabel(`Account row ${i + 2}`), 0);
  }

  /** Esc (TR_CONTRA.cs:2978-2991): an untouched screen closes; otherwise commit the cell and go to the employee box. */
  function formKey(e: React.KeyboardEvent<HTMLFormElement>) {
    if (e.key !== 'Escape') return;
    e.preventDefault();
    if (!touched) router.push('/');
    else focusLabel('Employee');
  }

  return (
    <div>
      <h1>Contra Entry</h1>
      <form onSubmit={submit} onKeyDown={formKey}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Voucher No</label>
              <input
                aria-label="Voucher No"
                value={voucherLookup}
                onChange={(e) => setVoucherLookup(e.target.value)}
                onKeyDown={numberKeys.onKeyDown}
                placeholder="00001"
                style={{ width: 90 }}
              />
              <VoucherNumberNote note={numberKeys.note} />
            </div>
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} mainBooks={CONTRA_MAIN_BOOKS} />
            </div>
            <div className="field">
              <label>Date</label>
              <input
                type="date"
                aria-label="Voucher date"
                ref={numberKeys.dateRef}
                value={vchDate}
                onChange={(e) => {
                  setTouched(true);
                  setVchDate(e.target.value);
                }}
              />
            </div>
            <div className="field">
              <label>Day</label>
              <input aria-label="Day" value={weekday(vchDate)} readOnly style={{ width: 110 }} />
            </div>
            <div className="field">
              <label>Time</label>
              <input aria-label="Time" value={time} readOnly style={{ width: 90 }} />
            </div>
            <div className="field" style={{ flex: 2 }}>
              <label>Employee</label>
              <LookupPicker
                entity="employees"
                value={empCode}
                onChange={(code) => {
                  setTouched(true);
                  setEmpCode(code);
                  setEmpName('');
                }}
                onPick={(picked) => setEmpName(String(picked.name || ''))}
                ariaLabel="Employee"
                placeholder="search employees…"
                resolveTypedCode
              />
              {empName && (
                <span className="muted" style={{ fontSize: 12 }}>
                  {empName}
                </span>
              )}
            </div>
          </div>
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <table className="grid">
            <thead>
              <tr>
                <th>Sr</th>
                <th>Cr/Dr</th>
                <th>AcCode</th>
                <th>Ac Name</th>
                <th>It Desc</th>
                <th className="num">CrAmt</th>
                <th className="num">DrAmt</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {rows.map((r, i) => {
                const side = sideOf(firstSide, i);
                const amountInput = (
                  <input
                    aria-label={`Amount row ${i + 1}`}
                    value={r.amount}
                    inputMode="decimal"
                    maxLength={10}
                    onChange={(e) => setRow(i, { amount: e.target.value })}
                    onBlur={() =>
                      r.amount !== '' && Number.isFinite(n(r.amount))
                        ? setRow(i, { amount: String(cell(r.amount)) })
                        : undefined
                    }
                    onKeyDown={(e) => amountKey(e, i)}
                    style={{ width: 120, textAlign: 'right' }}
                  />
                );
                return (
                  <tr key={i}>
                    <td className="c">{i + 1}</td>
                    <td>
                      {i === 0 ? (
                        <select
                          aria-label="Dr/Cr row 1"
                          value={firstSide}
                          onChange={(e) => {
                            setTouched(true);
                            setFirstSide(e.target.value === 'CR' ? 'CR' : 'DR');
                          }}
                        >
                          <option value="DR">DR</option>
                          <option value="CR">CR</option>
                        </select>
                      ) : (
                        <input
                          aria-label={`Dr/Cr row ${i + 1}`}
                          value={side}
                          readOnly
                          style={{ width: 48 }}
                        />
                      )}
                    </td>
                    <td>
                      <LookupPicker
                        entity="accounts"
                        value={r.acCode}
                        onChange={(v) => setRow(i, { acCode: v })}
                        onPick={(picked) => setRow(i, { acName: String(picked.name || '') })}
                        ariaLabel={`Account row ${i + 1}`}
                        style={{ width: 180 }}
                      />
                    </td>
                    <td>
                      <input
                        aria-label={`Name row ${i + 1}`}
                        value={r.acName}
                        maxLength={50}
                        onChange={(e) => setRow(i, { acName: e.target.value })}
                      />
                    </td>
                    <td>
                      <input
                        aria-label={`Narration row ${i + 1}`}
                        value={r.itDesc}
                        maxLength={150}
                        onChange={(e) => setRow(i, { itDesc: e.target.value })}
                        onKeyDown={(e) => {
                          if (e.ctrlKey && e.key.toLowerCase() === 'd') {
                            e.preventDefault();
                            blankRowAt(i);
                          }
                        }}
                      />
                    </td>
                    <td className="num" data-cell={`cr-${i + 1}`}>
                      {side === 'CR' ? amountInput : <span className="muted">0.00</span>}
                    </td>
                    <td className="num" data-cell={`dr-${i + 1}`}>
                      {side === 'DR' ? amountInput : <span className="muted">0.00</span>}
                    </td>
                    <td>
                      {rows.length > 2 && (
                        <button
                          type="button"
                          className="ghost"
                          aria-label={`Remove row ${i + 1}`}
                          onClick={() => blankRowAt(i)}
                        >
                          ×
                        </button>
                      )}
                    </td>
                  </tr>
                );
              })}
            </tbody>
            <tfoot>
              <tr>
                <td colSpan={5} style={{ textAlign: 'right', fontWeight: 600 }}>
                  Total :
                </td>
                <td className="num" style={{ fontWeight: 600 }}>
                  <span aria-label="Total CrAmt">{total('CR').toFixed(2)}</span>
                </td>
                <td className="num" style={{ fontWeight: 600 }}>
                  <span aria-label="Total DrAmt">{total('DR').toFixed(2)}</span>
                </td>
                <td></td>
              </tr>
              <tr>
                <td colSpan={5} style={{ textAlign: 'right' }}>
                  Dr {total('DR').toLocaleString('en-IN')} · Cr{' '}
                  {total('CR').toLocaleString('en-IN')}
                </td>
                <td colSpan={3}></td>
              </tr>
            </tfoot>
          </table>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button type="button" className="ghost" onClick={addRow}>
              + Add line
            </button>
            <span className={equal ? 'muted' : 'msg err'} style={{ margin: 0 }}>
              {equal ? 'Balanced ✓' : 'Dr must equal Cr'}
            </span>
            <span className="spacer" />
            {loadedVch && (
              <>
                <button type="button" onClick={() => void printVoucher(loadedVch)} disabled={busy}>
                  Print
                </button>
                <button
                  type="button"
                  className="danger"
                  onClick={() => void removeContra()}
                  disabled={busy}
                >
                  Delete
                </button>
              </>
            )}
            <button type="button" onClick={resetForm} disabled={busy}>
              Cancel
            </button>
            <button className="primary" data-save-mnemonic disabled={busy || !coBook}>
              {busy ? 'Saving…' : loadedVch ? `Update #${loadedVch}` : 'Save Contra'}
            </button>
          </div>
        </div>
      </form>
      {err && <div className="msg err">{err}</div>}
      {res && (
        <div className="panel">
          <div className="msg ok">
            Contra {loadedVch ? 'updated' : 'posted'} — Voucher #{res.vchNo}
          </div>
        </div>
      )}
      {printNote && <div className="msg err">{printNote}</div>}
      {printDoc && (
        <div className="panel">
          <iframe
            title="Contra voucher print"
            srcDoc={printDoc}
            style={{ width: '100%', height: 420, border: '1px solid #ccc' }}
          />
        </div>
      )}
      {f1 && (
        <div className="panel" data-f1-list style={{ overflow: 'auto' }}>
          <table className="grid">
            <thead>
              <tr>
                <th>Vch No</th>
                <th>Vch Date</th>
                <th>Party Name</th>
                <th>Vch Desc</th>
                <th>User</th>
                <th className="num">CrAmt</th>
                <th className="num">DrAmt</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {f1.map((r, i) => (
                <tr key={`${r.vchNo}-${i}`}>
                  <td>{r.vchNo}</td>
                  <td>{r.vchDate}</td>
                  <td>{r.partyName}</td>
                  <td>{r.vchDesc}</td>
                  <td>{r.user}</td>
                  <td className="num">{r.crAmt.toFixed(2)}</td>
                  <td className="num">{r.drAmt.toFixed(2)}</td>
                  <td>
                    <button type="button" onClick={() => void loadContra(r.vchNo)}>
                      Load
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
      {coBook && (
        <VoucherList
          table="CONTRA_DATA"
          book={coBook}
          onLoad={(vchNo) => void loadContra(vchNo)}
          printHref={(v) =>
            `/api/contra/${encodeURIComponent(v)}/print?coBook=${encodeURIComponent(coBook)}&format=html`
          }
          reloadKey={res?.vchNo}
        />
      )}
    </div>
  );
}
