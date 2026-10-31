'use client';
import { useState } from 'react';
import { post, put, get, del, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { todayLocal } from '../../../../lib/localDate';

/**
 * Customer Entry (desktop UT_CUST_ENTRY) — an employee-scoped, NON-FINANCIAL customer enquiry /
 * item-interest / follow-up-reminder log. Each entry has an employee + several customer/interest rows;
 * a row persists only when it carries a name+remark, a tag, or an item+reminder date. Keyed by
 * employeeCode + vchNo (no accounting book). Posts to /crm/customer-entries.
 */
interface Row {
  acCode: string;
  acName: string;
  mobileNo: string;
  itemRemark: string;
  remDate: string;
  itemCode: string;
  itemName: string;
  itemLike: string;
  pieces: string;
  grossWeight: string;
  netWeight: string;
}
const blank = (): Row => ({
  acCode: '',
  acName: '',
  mobileNo: '',
  itemRemark: '',
  remDate: todayLocal(),
  itemCode: '',
  itemName: '',
  itemLike: '',
  pieces: '',
  grossWeight: '',
  netWeight: '',
});
const num = (v: string) => (v.trim() === '' ? undefined : Number(v));

export default function CustomerEntryPage() {
  const [employeeCode, setEmployeeCode] = useState('001');
  const [employeeName, setEmployeeName] = useState('');
  const [vchDate, setVchDate] = useState(todayLocal());
  const [rows, setRows] = useState<Row[]>([blank()]);
  const [loadVchNo, setLoadVchNo] = useState('');
  const [loadedVch, setLoadedVch] = useState('');
  const [res, setRes] = useState<{ vchNo: number; rowCount?: number } | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);

  const setRow = (i: number, k: keyof Row, v: string) =>
    setRows((rs) => rs.map((r, j) => (j === i ? { ...r, [k]: v } : r)));
  const addRow = () => setRows((rs) => [...rs, blank()]);
  const removeRow = (i: number) =>
    setRows((rs) => (rs.length === 1 ? [blank()] : rs.filter((_, j) => j !== i)));

  // Mirror the desktop write predicate so the operator sees which rows will persist.
  const qualifies = (r: Row) =>
    (!!r.acName.trim() && !!r.itemRemark.trim()) || (!!r.itemCode.trim() && !!r.remDate.trim());

  function resetForm() {
    setLoadedVch('');
    setLoadVchNo('');
    setRows([blank()]);
    setEmployeeName('');
    setVchDate(todayLocal());
    setRes(null);
    setMsg(null);
  }

  async function load() {
    if (!employeeCode.trim() || !loadVchNo.trim()) return;
    setMsg(null);
    setRes(null);
    try {
      const d = await get<any>(
        `/crm/customer-entries/${encodeURIComponent(employeeCode.trim())}/${encodeURIComponent(loadVchNo.trim())}`,
      );
      setLoadedVch(String(d.voucherNo ?? loadVchNo.trim()));
      setEmployeeName(String(d.employeeName ?? ''));
      setVchDate(String(d.vchDate ?? todayLocal()).slice(0, 10));
      const loaded: Row[] = (d.rows ?? []).map((r: any) => ({
        acCode: String(r.acCode ?? ''),
        acName: String(r.acName ?? ''),
        mobileNo: String(r.mobileNo ?? ''),
        itemRemark: String(r.itemRemark ?? ''),
        remDate: String(r.remDate ?? '').slice(0, 10) || todayLocal(),
        itemCode: String(r.itemCode ?? ''),
        itemName: String(r.itemName ?? ''),
        itemLike: String(r.itemLike ?? ''),
        pieces: Number(r.pieces ?? 0) ? String(r.pieces) : '',
        grossWeight: Number(r.grossWeight ?? 0) ? String(r.grossWeight) : '',
        netWeight: Number(r.netWeight ?? 0) ? String(r.netWeight) : '',
      }));
      setRows(loaded.length ? loaded : [blank()]);
      setMsg({ kind: 'ok', text: `Loaded entry ${d.voucherNo}` });
    } catch (e) {
      setMsg({
        kind: 'err',
        text: e instanceof ApiError ? e.body?.error || e.message : 'load failed',
      });
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setRes(null);
    if (!employeeCode.trim()) return setMsg({ kind: 'err', text: 'employee code is required' });
    setBusy(true);
    try {
      const body = {
        employeeCode: employeeCode.trim(),
        employeeName: employeeName || undefined,
        vchDate,
        rows: rows.map((r) => ({
          acCode: r.acCode || undefined,
          acName: r.acName || undefined,
          mobileNo: r.mobileNo || undefined,
          itemRemark: r.itemRemark || undefined,
          remDate: r.remDate || undefined,
          itemCode: r.itemCode || undefined,
          itemName: r.itemName || undefined,
          itemLike: r.itemLike || undefined,
          pieces: num(r.pieces),
          grossWeight: num(r.grossWeight),
          netWeight: num(r.netWeight),
        })),
      };
      const saved = loadedVch
        ? await put<{ vchNo: number; rowCount?: number }>(
            `/crm/customer-entries/${encodeURIComponent(employeeCode.trim())}/${encodeURIComponent(loadedVch)}`,
            body,
          )
        : await post<{ vchNo: number; rowCount?: number }>('/crm/customer-entries', body);
      setRes(saved);
      setMsg({
        kind: 'ok',
        text: `Entry ${loadedVch ? 'updated' : 'saved'} — #${saved.vchNo} (${saved.rowCount ?? ''} rows)`,
      });
      if (!loadedVch) {
        setLoadedVch(String(saved.vchNo).padStart(5, '0'));
      }
    } catch (err) {
      setMsg({
        kind: 'err',
        text: err instanceof ApiError ? err.body?.message || err.body?.error || 'failed' : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    if (!loadedVch || !window.confirm(`Delete customer entry #${loadedVch}?`)) return;
    setBusy(true);
    setMsg(null);
    try {
      await del(
        `/crm/customer-entries/${encodeURIComponent(employeeCode.trim())}/${encodeURIComponent(loadedVch)}`,
      );
      setMsg({ kind: 'ok', text: `Deleted entry #${loadedVch}` });
      resetForm();
    } catch (err) {
      setMsg({
        kind: 'err',
        text: err instanceof ApiError ? err.body?.error || 'failed' : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Customer Entry{' '}
        <span className="muted">— CRM enquiry / interest / reminder (UT_CUST_ENTRY)</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Employee Code</label>
              <input
                value={employeeCode}
                onChange={(e) => setEmployeeCode(e.target.value)}
                required
              />
            </div>
            <div className="field">
              <label>Employee Name</label>
              <input value={employeeName} onChange={(e) => setEmployeeName(e.target.value)} />
            </div>
            <div className="field">
              <label>Date</label>
              <input type="date" value={vchDate} onChange={(e) => setVchDate(e.target.value)} />
            </div>
            <div className="field">
              <label>Load Entry No</label>
              <div style={{ display: 'flex', gap: 6 }}>
                <input
                  value={loadVchNo}
                  onChange={(e) => setLoadVchNo(e.target.value)}
                  style={{ width: 90 }}
                />
                <button type="button" className="ghost" onClick={() => void load()} disabled={busy}>
                  Load
                </button>
              </div>
            </div>
          </div>
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <table className="grid">
            <thead>
              <tr>
                <th>#</th>
                <th>Customer / Party</th>
                <th>Name</th>
                <th>Mobile</th>
                <th>Remark</th>
                <th>Rem Date</th>
                <th>Item</th>
                <th>Like</th>
                <th className="num">Pcs</th>
                <th className="num">GrWt</th>
                <th className="num">NetWt</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {rows.map((r, i) => (
                <tr key={i} style={qualifies(r) ? undefined : { opacity: 0.6 }}>
                  <td className="c">{i + 1}</td>
                  <td>
                    <LookupPicker
                      entity="accounts"
                      value={r.acCode}
                      onChange={(v) => setRow(i, 'acCode', v)}
                      onPick={(p) => {
                        setRow(i, 'acName', String(p.name || ''));
                      }}
                      ariaLabel={`row ${i + 1} party`}
                      style={{ width: 130 }}
                    />
                  </td>
                  <td>
                    <input
                      aria-label={`row ${i + 1} name`}
                      value={r.acName}
                      onChange={(e) => setRow(i, 'acName', e.target.value)}
                      style={{ width: 130 }}
                    />
                  </td>
                  <td>
                    <input
                      aria-label={`row ${i + 1} mobile`}
                      value={r.mobileNo}
                      onChange={(e) => setRow(i, 'mobileNo', e.target.value)}
                      style={{ width: 110 }}
                    />
                  </td>
                  <td>
                    <input
                      aria-label={`row ${i + 1} remark`}
                      value={r.itemRemark}
                      onChange={(e) => setRow(i, 'itemRemark', e.target.value)}
                      style={{ width: 160 }}
                    />
                  </td>
                  <td>
                    <input
                      aria-label={`row ${i + 1} remDate`}
                      type="date"
                      value={r.remDate}
                      onChange={(e) => setRow(i, 'remDate', e.target.value)}
                    />
                  </td>
                  <td>
                    <LookupPicker
                      entity="items"
                      value={r.itemCode}
                      onChange={(v) => setRow(i, 'itemCode', v)}
                      onPick={(p) => setRow(i, 'itemName', String(p.name || ''))}
                      ariaLabel={`row ${i + 1} item`}
                      style={{ width: 110 }}
                    />
                  </td>
                  <td>
                    <input
                      aria-label={`row ${i + 1} like`}
                      value={r.itemLike}
                      onChange={(e) => setRow(i, 'itemLike', e.target.value)}
                      maxLength={1}
                      style={{ width: 40 }}
                    />
                  </td>
                  <td className="num">
                    <input
                      aria-label={`row ${i + 1} pcs`}
                      value={r.pieces}
                      onChange={(e) => setRow(i, 'pieces', e.target.value)}
                      style={{ width: 60, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      aria-label={`row ${i + 1} grwt`}
                      value={r.grossWeight}
                      onChange={(e) => setRow(i, 'grossWeight', e.target.value)}
                      style={{ width: 70, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      aria-label={`row ${i + 1} netwt`}
                      value={r.netWeight}
                      onChange={(e) => setRow(i, 'netWeight', e.target.value)}
                      style={{ width: 70, textAlign: 'right' }}
                    />
                  </td>
                  <td>
                    <button
                      type="button"
                      className="ghost"
                      onClick={() => removeRow(i)}
                      aria-label={`remove row ${i + 1}`}
                    >
                      ✕
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button type="button" className="ghost" onClick={addRow}>
              + Add row
            </button>
            <span className="muted" style={{ marginLeft: 8 }}>
              A row saves only with a name+remark, a tag, or an item+reminder date.
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
                  onClick={() => void remove()}
                  disabled={busy}
                >
                  Delete
                </button>
              </>
            )}
            <button className="primary" data-save-mnemonic disabled={busy || !employeeCode.trim()}>
              {busy ? 'Saving…' : loadedVch ? `Update #${loadedVch}` : 'Save Entry'}
            </button>
          </div>
        </div>
      </form>
    </div>
  );
}
