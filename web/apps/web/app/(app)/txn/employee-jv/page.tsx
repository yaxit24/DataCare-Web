'use client';
import { useState } from 'react';
import { post, put, get, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { BookSelect } from '../../../../components/BookSelect';
import { VoucherList } from '../../../../components/VoucherList';

/** Employee Salary JV (desktop TR_EMP_JV → EMP_DATA + balanced AC_DATA).
 *  Dr employee salary; Cr cash/bank net; Cr TDS; Cr PF — net = salary − tds − pf. */
export default function EmployeeJvPage() {
  const [f, setF] = useState({
    empAc: '',
    empName: '',
    paidAc: 'CASH',
    salaryAmt: '',
    tdsAmt: '',
    pfAmt: '',
    chqNo: '',
    desc: '',
  });
  const [coBook, setCoBook] = useState('');
  const [loadedVch, setLoadedVch] = useState('');
  const [res, setRes] = useState<{ vchNo: number; netPaid: number } | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const set = (k: string, v: string) => setF((s) => ({ ...s, [k]: v }));
  const n = (v: string) => Number(v || 0);
  const net = Math.round((n(f.salaryAmt) - n(f.tdsAmt) - n(f.pfAmt) + 1e-9) * 100) / 100;

  function resetForm() {
    setLoadedVch('');
    setF({
      empAc: '',
      empName: '',
      paidAc: 'CASH',
      salaryAmt: '',
      tdsAmt: '',
      pfAmt: '',
      chqNo: '',
      desc: '',
    });
    setRes(null);
    setMsg(null);
  }

  async function loadEmpJv(vchNo: string) {
    setMsg(null);
    setRes(null);
    try {
      const d = await get<any>(
        `/employee-jv/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVch(vchNo);
      setF({
        empAc: String(d.empAc ?? ''),
        empName: String(d.empName ?? ''),
        paidAc: String(d.paidAc ?? 'CASH'),
        salaryAmt: String(d.salaryAmt ?? ''),
        tdsAmt: Number(d.tdsAmt ?? 0) ? String(d.tdsAmt) : '',
        pfAmt: Number(d.pfAmt ?? 0) ? String(d.pfAmt) : '',
        chqNo: String(d.chqNo ?? ''),
        desc: String(d.desc ?? ''),
      });
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
    if (!coBook) {
      setMsg({ kind: 'err', text: 'select the configured book first' });
      return;
    }
    if (!f.empAc.trim()) {
      setMsg({ kind: 'err', text: 'employee account is required' });
      return;
    }
    if (!(n(f.salaryAmt) > 0)) {
      setMsg({ kind: 'err', text: 'salary must be positive' });
      return;
    }
    if (net < 0) {
      setMsg({ kind: 'err', text: 'TDS + PF cannot exceed salary' });
      return;
    }
    setBusy(true);
    try {
      const body = {
        coBook,
        empAc: f.empAc.trim(),
        empName: f.empName.trim() || undefined,
        paidAc: f.paidAc.trim() || undefined,
        salaryAmt: n(f.salaryAmt),
        tdsAmt: f.tdsAmt.trim() ? n(f.tdsAmt) : undefined,
        pfAmt: f.pfAmt.trim() ? n(f.pfAmt) : undefined,
        chqNo: f.chqNo.trim() || undefined,
        desc: f.desc.trim() || undefined,
      };
      const r = loadedVch
        ? await put<{ vchNo: number; netPaid: number }>(
            `/employee-jv/${encodeURIComponent(loadedVch)}`,
            body,
          )
        : await post<{ vchNo: number; netPaid: number }>('/employee-jv', body);
      setRes(r);
      setMsg({
        kind: 'ok',
        text: `Salary JV ${loadedVch ? 'updated' : 'posted'} — net ₹${r.netPaid.toLocaleString('en-IN')} (voucher #${r.vchNo})`,
      });
      if (!loadedVch)
        setF((s) => ({ ...s, salaryAmt: '', tdsAmt: '', pfAmt: '', chqNo: '', desc: '' }));
    } catch (err) {
      setMsg({
        kind: 'err',
        text: err instanceof ApiError ? err.body?.message || err.body?.error || 'failed' : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Employee Salary JV <span className="muted">— TR_EMP_JV</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form className="panel" onSubmit={submit} style={{ maxWidth: 720 }}>
        <div className="field">
          <label>Book</label>
          <BookSelect value={coBook} onChange={setCoBook} preferred="JV" mainBooks={['JOURNAL']} />
        </div>
        <div className="row">
          <div className="field" style={{ flex: 2 }}>
            <label>Employee account</label>
            <LookupPicker
              entity="accounts"
              value={f.empAc}
              onChange={(v) => set('empAc', v)}
              onPick={(r) => {
                if (!f.empName) set('empName', String(r.name || ''));
              }}
            />
          </div>
          <div className="field">
            <label>Employee name</label>
            <input value={f.empName} onChange={(e) => set('empName', e.target.value)} />
          </div>
          <div className="field">
            <label>Paid from (cash/bank)</label>
            <input value={f.paidAc} onChange={(e) => set('paidAc', e.target.value)} />
          </div>
        </div>
        <div className="row">
          <div className="field">
            <label>Salary ₹</label>
            <input
              value={f.salaryAmt}
              onChange={(e) => set('salaryAmt', e.target.value)}
              required
            />
          </div>
          <div className="field">
            <label>TDS ₹</label>
            <input value={f.tdsAmt} onChange={(e) => set('tdsAmt', e.target.value)} />
          </div>
          <div className="field">
            <label>PF ₹</label>
            <input value={f.pfAmt} onChange={(e) => set('pfAmt', e.target.value)} />
          </div>
          <div className="field">
            <label>Net pay ₹</label>
            <input value={net.toLocaleString('en-IN')} disabled />
          </div>
        </div>
        <div className="row">
          <div className="field">
            <label>Cheque No</label>
            <input value={f.chqNo} onChange={(e) => set('chqNo', e.target.value)} />
          </div>
          <div className="field" style={{ flex: 2 }}>
            <label>Description</label>
            <input
              value={f.desc}
              onChange={(e) => set('desc', e.target.value)}
              placeholder="e.g. Salary May-2026"
            />
          </div>
        </div>
        <div className="toolbar" style={{ marginTop: 10 }}>
          <span className="muted">
            POST /employee-jv · Dr employee / Cr cash {net.toLocaleString('en-IN')} + TDS + PF
          </span>
          <span className="spacer" />
          {loadedVch && (
            <button type="button" onClick={resetForm} disabled={busy}>
              New
            </button>
          )}
          <button className="primary" disabled={busy || !coBook}>
            {busy ? 'Saving…' : loadedVch ? `Update #${loadedVch}` : 'Post Salary JV'}
          </button>
        </div>
        {res && (
          <div className="tiles" style={{ marginTop: 10 }}>
            <div className="tile">
              <div className="muted">voucher</div>
              <div className="big kpi">#{res.vchNo}</div>
            </div>
            <div className="tile">
              <div className="muted">net paid ₹</div>
              <div className="big kpi">{res.netPaid.toLocaleString('en-IN')}</div>
            </div>
          </div>
        )}
      </form>
      {coBook && (
        <VoucherList
          table="EMP_DATA"
          book={coBook}
          deleteBase="/employee-jv"
          onLoad={(vchNo) => void loadEmpJv(vchNo)}
          reloadKey={res?.vchNo}
        />
      )}
    </div>
  );
}
