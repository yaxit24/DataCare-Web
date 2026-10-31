'use client';
import { useState } from 'react';
import { post, put, get, del, ApiError } from '../../../../lib/api';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { VoucherList } from '../../../../components/VoucherList';
import { useVoucherNumberKeys, VoucherNumberNote } from '../../../../components/VoucherNumberKeys';
import { todayLocal } from '../../../../lib/localDate';

/** Desktop "Contra Entry" opens with `CurBookHelp("CONTRA")` (MDI_FORM.cs:8100-8111). */
const CONTRA_MAIN_BOOKS = ['CONTRA'];

type Row = { crdr: 'DR' | 'CR'; acCode: string; acName: string; itDesc: string; amount: string };
const blankRow = (crdr: 'DR' | 'CR'): Row => ({
  crdr,
  acCode: '',
  acName: '',
  itDesc: '',
  amount: '',
});

/**
 * Contra Entry (TR_CONTRA): a grid of accounts, each a debit or a credit. Row 1 is the main account, DR by default,
 * and a new row takes the other side (TR_CONTRA.cs:1530-1545). The totals must agree; the server refuses unequal
 * totals with the desktop message (TR_CONTRA.cs:2694).
 */
export default function ContraPage() {
  const [coBook, setCoBook] = useState('');
  const [rows, setRows] = useState<Row[]>([blankRow('DR'), blankRow('CR')]);
  const [itDesc, setItDesc] = useState('');
  const [vchDate, setVchDate] = useState(todayLocal());
  const [res, setRes] = useState<{ vchNo: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const [loadedVch, setLoadedVch] = useState('');
  const [voucherLookup, setVoucherLookup] = useState('');
  const n = (v: string) => Number(v || 0);
  const total = (side: 'DR' | 'CR') =>
    rows.filter((r) => r.crdr === side).reduce((s, r) => s + n(r.amount), 0);
  const equal = Math.abs(total('DR') - total('CR')) < 0.005 && total('DR') > 0;
  const setRow = (i: number, patch: Partial<Row>) =>
    setRows((rs) => rs.map((r, j) => (j === i ? { ...r, ...patch } : r)));
  const addRow = () => setRows((rs) => [...rs, blankRow(rs[0]?.crdr === 'CR' ? 'DR' : 'CR')]);
  const removeRow = (i: number) =>
    setRows((rs) => (rs.length <= 2 ? rs : rs.filter((_, j) => j !== i)));

  function resetForm() {
    setLoadedVch('');
    setVoucherLookup('');
    setRows([blankRow('DR'), blankRow('CR')]);
    setItDesc('');
    setVchDate(todayLocal());
    setRes(null);
    setErr('');
  }

  async function loadContra(vchNo: string): Promise<boolean> {
    setErr('');
    setRes(null);
    try {
      const d = await get<any>(
        `/contra/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVch(String(d.voucherNo ?? vchNo));
      setVoucherLookup(String(d.voucherNo ?? vchNo));
      setRows(
        (d.lines ?? []).map((l: any) => ({
          crdr: String(l.crdr).toUpperCase() === 'CR' ? 'CR' : 'DR',
          acCode: String(l.acCode ?? ''),
          acName: String(l.acName ?? ''),
          itDesc: String(l.itDesc ?? ''),
          amount: String(l.amount ?? ''),
        })),
      );
      setItDesc(String(d.itDesc ?? ''));
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
    open: (vchNo) => loadContra(vchNo),
    fresh: resetForm,
  });

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
      const payload = {
        coBook,
        vchDate,
        itDesc: itDesc || undefined,
        lines: rows
          .filter((r) => r.acCode.trim() && n(r.amount))
          .map((r) => ({
            crdr: r.crdr,
            acCode: r.acCode.trim(),
            acName: r.acName || undefined,
            itDesc: r.itDesc || undefined,
            amount: n(r.amount),
          })),
      };
      const saved = loadedVch
        ? await put<{ vchNo: number }>(`/contra/${encodeURIComponent(loadedVch)}`, payload)
        : await post<{ vchNo: number }>('/contra', payload);
      setRes(saved);
      if (!loadedVch) {
        setRows([blankRow('DR'), blankRow('CR')]);
        setItDesc('');
      }
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

  async function removeContra() {
    // TR_CONTRA.cs:2959 "Are You Sure To Delete This Voucher now?"
    if (!loadedVch || !window.confirm('Are You Sure To Delete This Voucher now?')) return;
    setBusy(true);
    setErr('');
    try {
      await del(`/contra/${encodeURIComponent(loadedVch)}?coBook=${encodeURIComponent(coBook)}`);
      resetForm();
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
      <h1>Contra Entry</h1>
      <form onSubmit={submit}>
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
                onChange={(e) => setVchDate(e.target.value)}
              />
            </div>
            <div className="field" style={{ flex: 2 }}>
              <label>Narration (ItDesc)</label>
              <input
                value={itDesc}
                onChange={(e) => setItDesc(e.target.value)}
                placeholder="e.g. cash deposited to bank"
              />
            </div>
          </div>
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <table className="grid">
            <thead>
              <tr>
                <th>#</th>
                <th>Cr/Dr</th>
                <th>Account</th>
                <th>Name</th>
                <th>Narration</th>
                <th className="num">Amount</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {rows.map((r, i) => (
                <tr key={i}>
                  <td className="c">{i + 1}</td>
                  <td>
                    <select
                      aria-label={`Dr/Cr row ${i + 1}`}
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
                      onChange={(e) => setRow(i, { acName: e.target.value })}
                    />
                  </td>
                  <td>
                    <input
                      aria-label={`Narration row ${i + 1}`}
                      value={r.itDesc}
                      onChange={(e) => setRow(i, { itDesc: e.target.value })}
                    />
                  </td>
                  <td className="num">
                    <input
                      aria-label={`Amount row ${i + 1}`}
                      value={r.amount}
                      onChange={(e) => setRow(i, { amount: e.target.value })}
                      style={{ width: 120, textAlign: 'right' }}
                    />
                  </td>
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
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td colSpan={5} style={{ textAlign: 'right', fontWeight: 600 }}>
                  Dr {total('DR').toLocaleString('en-IN')} · Cr{' '}
                  {total('CR').toLocaleString('en-IN')}
                </td>
                <td colSpan={2}></td>
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
                <button type="button" onClick={resetForm} disabled={busy}>
                  New
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
      {coBook && (
        <VoucherList
          table="CONTRA_DATA"
          book={coBook}
          deleteBase="/contra"
          onLoad={(vchNo) => void loadContra(vchNo)}
          openKey={numberKeys.listKey}
          printHref={(v) =>
            `/api/contra/${encodeURIComponent(v)}/print?coBook=${encodeURIComponent(coBook)}&format=html`
          }
          reloadKey={res?.vchNo}
        />
      )}
    </div>
  );
}
