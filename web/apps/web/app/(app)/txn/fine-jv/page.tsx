'use client';
import { useState } from 'react';
import { post, put, get, del, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { VoucherList } from '../../../../components/VoucherList';
import { LookupPicker } from '../../../../components/LookupPicker';
import { useVoucherNumberKeys, VoucherNumberNote } from '../../../../components/VoucherNumberKeys';
import { todayLocal } from '../../../../lib/localDate';

/** Desktop "Fine Jv Entry" opens TR_CONTRA with `CurBookHelp('FINE JV')` (MDI_FORM.cs:8360-8365). */
const FINE_JV_MAIN_BOOKS = ['FINE JV'];

type Side = 'DR' | 'CR';
type Row = { crdr: Side; acCode: string; acName: string; itDesc: string; fine: string };
const blankRow = (crdr: Side): Row => ({ crdr, acCode: '', acName: '', itDesc: '', fine: '' });
const other = (side: Side): Side => (side === 'DR' ? 'CR' : 'DR');
const r3 = (n: number) => Math.round((n + Number.EPSILON) * 1000) / 1000;
const f3 = (n: number) => r3(n).toFixed(3);
const VISUALLY_HIDDEN: React.CSSProperties = {
  position: 'absolute',
  width: 1,
  height: 1,
  overflow: 'hidden',
  clip: 'rect(0 0 0 0)',
  whiteSpace: 'nowrap',
};

/**
 * Fine Jv Entry (TR_CONTRA in FINE JV mode). The grid is the Contra grid with fine weights: row 1 is the main
 * account, DR by default, and a new row takes the other side (TR_CONTRA.cs:1530-1545). The CrFine and DrFine
 * columns show 0.000 (:1439-1446, :1509-1512) and their totals must agree before the server saves
 * (:2692-2697). Item Type (Gold/Silver) and Employee are the FINE JV header fields (:2329-2343, :1345).
 */
export default function FineJvPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(todayLocal());
  const [metal, setMetal] = useState<'G' | 'S'>('G');
  const [empCode, setEmpCode] = useState('');
  const [empName, setEmpName] = useState('');
  const [rows, setRows] = useState<Row[]>([blankRow('DR'), blankRow('CR')]);
  const [result, setResult] = useState<{ vchNo: number } | null>(null);
  const [notice, setNotice] = useState('');
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const [loadedVch, setLoadedVch] = useState('');
  const [voucherLookup, setVoucherLookup] = useState('');

  const n = (v: string) => Number(v || 0);
  const filled = rows.filter((r) => r.acCode.trim() && n(r.fine) > 0);
  const total = (side: Side) =>
    r3(rows.filter((r) => r.crdr === side).reduce((sum, r) => sum + n(r.fine), 0));
  const balanced = total('DR') > 0 && total('DR') === total('CR');
  const canSave = !!coBook && filled.length >= 2;
  const setRow = (i: number, patch: Partial<Row>) =>
    setRows((rs) => rs.map((r, j) => (j === i ? { ...r, ...patch } : r)));
  const addRow = () => setRows((rs) => [...rs, blankRow(other(rs[0]?.crdr ?? 'DR'))]);
  function removeRow(i: number) {
    // TR_CONTRA.cs:1816
    if (rows.length <= 2 || !window.confirm('This Row Record will Removed permantley ?')) return;
    setRows((rs) => rs.filter((_, j) => j !== i));
  }

  function resetForm() {
    setLoadedVch('');
    setVoucherLookup('');
    setRows([blankRow('DR'), blankRow('CR')]);
    setVchDate(todayLocal());
    setMetal('G');
    setEmpCode('');
    setEmpName('');
    setResult(null);
    setErr('');
  }

  async function loadFineJv(vchNo: string): Promise<boolean> {
    setErr('');
    setResult(null);
    setNotice('');
    try {
      const d = await get<any>(
        `/fine-jv/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      const no = String(d.voucherNo ?? vchNo);
      setLoadedVch(no);
      setVoucherLookup(no);
      setRows(
        (d.lines ?? []).map((l: any) => ({
          crdr: String(l.crdr).toUpperCase() === 'CR' ? 'CR' : 'DR',
          acCode: String(l.acCode ?? ''),
          acName: String(l.acName ?? ''),
          itDesc: String(l.itDesc ?? ''),
          fine: f3(Number(l.fine ?? 0)),
        })),
      );
      setMetal(String(d.metal ?? 'G') === 'S' ? 'S' : 'G');
      setEmpCode(String(d.empCode ?? ''));
      setEmpName('');
      setVchDate(String(d.vchDate ?? todayLocal()).slice(0, 10));
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
    open: (vchNo) => loadFineJv(vchNo),
    fresh: resetForm,
  });

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setNotice('');
    setBusy(true);
    try {
      const body = {
        coBook,
        coYear,
        lcCode,
        vchDate,
        metal,
        empCode: empCode.trim(),
        lines: filled.map((r) => ({
          crdr: r.crdr,
          acCode: r.acCode.trim(),
          itDesc: r.itDesc,
          fine: r3(n(r.fine)),
        })),
      };
      const saved = loadedVch
        ? await put<{ vchNo: number }>(`/fine-jv/${encodeURIComponent(loadedVch)}`, body)
        : await post<{ vchNo: number }>('/fine-jv', body);
      setResult(saved);
      if (!loadedVch) setRows([blankRow('DR'), blankRow('CR')]);
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

  async function removeVoucher() {
    // TR_CONTRA.cs:2959 and :2969
    if (!loadedVch || !window.confirm('Are You Sure To Delete This Voucher now?')) return;
    setBusy(true);
    setErr('');
    try {
      await del(`/fine-jv/${encodeURIComponent(loadedVch)}?coBook=${encodeURIComponent(coBook)}`);
      resetForm();
      setNotice('Delete Success.');
    } catch (e) {
      setErr(
        e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'delete failed',
      );
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Fine Jv Entry</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label htmlFor="fine-jv-vch-no">Vch No</label>
              <input
                id="fine-jv-vch-no"
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
              <BookSelect
                value={coBook}
                onChange={setCoBook}
                preferred="FJV"
                mainBooks={FINE_JV_MAIN_BOOKS}
              />
            </div>
            <div className="field">
              <label htmlFor="fine-jv-year">Year</label>
              <input id="fine-jv-year" value={coYear} readOnly />
            </div>
            <div className="field">
              <label htmlFor="fine-jv-location">Location</label>
              <input id="fine-jv-location" value={lcCode} readOnly />
            </div>
            <div className="field">
              <label htmlFor="fine-jv-date">Vch Date</label>
              <input
                id="fine-jv-date"
                type="date"
                ref={numberKeys.dateRef}
                value={vchDate}
                onChange={(e) => setVchDate(e.target.value)}
              />
            </div>
            <div className="field">
              <label htmlFor="fine-jv-metal">Item Type</label>
              <select
                id="fine-jv-metal"
                value={metal}
                onChange={(e) => setMetal(e.target.value === 'S' ? 'S' : 'G')}
              >
                <option value="G">Gold</option>
                <option value="S">Silver</option>
              </select>
            </div>
            <div className="field" style={{ flex: 2 }}>
              <label>Employee</label>
              <LookupPicker
                entity="employees"
                value={empCode}
                onChange={(code) => {
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
                <th className="num">CrFine</th>
                <th className="num">DrFine</th>
                <th>
                  <span style={VISUALLY_HIDDEN}>Remove</span>
                </th>
              </tr>
            </thead>
            <tbody>
              {rows.map((r, i) => {
                const fineInput = (
                  <input
                    aria-label={`Fine row ${i + 1}`}
                    value={r.fine}
                    inputMode="decimal"
                    placeholder="0.000"
                    onChange={(e) => setRow(i, { fine: e.target.value })}
                    onBlur={() => r.fine && setRow(i, { fine: f3(n(r.fine)) })}
                    style={{ width: 110, textAlign: 'right' }}
                  />
                );
                return (
                  <tr key={i}>
                    <td className="c">{i + 1}</td>
                    <td>
                      <select
                        aria-label={`Cr/Dr row ${i + 1}`}
                        value={r.crdr}
                        onChange={(e) => setRow(i, { crdr: e.target.value === 'CR' ? 'CR' : 'DR' })}
                      >
                        <option value="DR">DR</option>
                        <option value="CR">CR</option>
                      </select>
                    </td>
                    <td>
                      <LookupPicker
                        entity="accounts"
                        value={r.acCode}
                        onChange={(code) => setRow(i, { acCode: code, acName: '' })}
                        onPick={(picked) => setRow(i, { acName: String(picked.name || '') })}
                        ariaLabel={`AcCode row ${i + 1}`}
                        placeholder="search accounts…"
                        resolveTypedCode
                        style={{ width: 170 }}
                      />
                    </td>
                    <td>{r.acName}</td>
                    <td>
                      <input
                        aria-label={`It Desc row ${i + 1}`}
                        value={r.itDesc}
                        maxLength={150}
                        onChange={(e) => setRow(i, { itDesc: e.target.value })}
                      />
                    </td>
                    <td className="num">{r.crdr === 'CR' ? fineInput : ''}</td>
                    <td className="num">{r.crdr === 'DR' ? fineInput : ''}</td>
                    <td>
                      {rows.length > 2 && (
                        <button
                          type="button"
                          className="ghost"
                          aria-label={`Remove row ${i + 1}`}
                          onClick={() => removeRow(i)}
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
                  Total
                </td>
                <td className="num" aria-label="CrFine total">
                  {f3(total('CR'))}
                </td>
                <td className="num" aria-label="DrFine total">
                  {f3(total('DR'))}
                </td>
                <td></td>
              </tr>
            </tfoot>
          </table>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button type="button" className="ghost" onClick={addRow}>
              + Add line
            </button>
            {total('DR') + total('CR') > 0 && (
              <span className={balanced ? 'muted' : 'msg err'} style={{ margin: 0 }}>
                {balanced ? 'Balanced ✓' : 'CrFine must equal DrFine'}
              </span>
            )}
            <span className="spacer" />
            {loadedVch && (
              <>
                <button type="button" onClick={resetForm} disabled={busy}>
                  New
                </button>
                <button
                  type="button"
                  className="danger"
                  onClick={() => void removeVoucher()}
                  disabled={busy}
                >
                  Delete
                </button>
              </>
            )}
            <button className="primary" data-save-mnemonic disabled={busy || !canSave}>
              {busy ? 'Saving…' : loadedVch ? `Update #${loadedVch}` : 'Save Fine JV'}
            </button>
          </div>
        </div>
      </form>

      {err && (
        <div className="msg err" role="alert">
          {err}
        </div>
      )}
      {notice && <div className="msg ok">{notice}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">
            {loadedVch ? 'Updated' : 'Posted'} — Fine JV #{result.vchNo}
          </div>
        </div>
      )}
      {coBook && (
        <VoucherList
          table="CONTRA_DATA"
          book={coBook}
          deleteBase="/fine-jv"
          onLoad={(vchNo) => void loadFineJv(vchNo)}
          openKey={numberKeys.listKey}
          printHref={(v) =>
            `/api/fine-jv/${encodeURIComponent(v)}/print?coBook=${encodeURIComponent(coBook)}&format=html`
          }
          reloadKey={result?.vchNo}
        />
      )}
    </div>
  );
}
