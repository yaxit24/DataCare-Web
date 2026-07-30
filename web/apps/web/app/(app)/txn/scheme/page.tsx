'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { LookupPicker } from '../../../../components/LookupPicker';

/**
 * Saving Schemes (Phase 9 — desktop BtmSchm / Module_Schm). Three panels:
 *  • Enroll      → POST /scheme/enroll       (customer joins a monthly gold/amount scheme → AD_MEMB)
 *  • Installment → POST /scheme/installment   (monthly payment → 074 MBENT: AD_DATA + AD_OS + balanced AC_DATA)
 *  • Maturity    → POST /scheme/maturity      (redeem accrued balance → 076 MBADJ: AD_ADJ + AD_OS '-' + balanced AC_DATA)
 * Scope (company/year/branch) is injected server-side from the session, mirroring the membership page.
 */

// SchemeError / invalid-data both surface a human message in the ApiError body (see routes `run`).
const errText = (e: unknown): string =>
  e instanceof ApiError
    ? e.body?.message || e.body?.detail || e.body?.error || e.message || 'failed'
    : e instanceof Error
      ? e.message || 'failed'
      : 'failed';

const PAY_MODES = ['cash', 'cheque', 'card', 'upi', 'bank'] as const;

export default function SchemePage() {
  const { coYear } = useBusinessScope();
  // POST /scheme/enroll → { schmCode, membCode?, membName?, monthlyAmt, months? } → { membNo }
  const [enroll, setEnroll] = useState({
    schmCode: '',
    membCode: '',
    membName: '',
    monthlyAmt: '',
    months: '',
  });
  // POST /scheme/installment (or /scheme/opening when `opening`) → { schmCode, membCode, amount, mode? } → { vchNo }
  const [inst, setInst] = useState({
    schmCode: '',
    membCode: '',
    amount: '',
    mode: 'cash',
    chqNo: '',
    opening: false,
  });
  // POST /scheme/maturity → { schmCode, membCode, amount, bonus?, less?, mode? } → { vchNo, payout }
  const [matur, setMatur] = useState({
    schmCode: '',
    membCode: '',
    amount: '',
    bonus: '',
    less: '',
    mode: 'cash',
  });

  const [enrollRes, setEnrollRes] = useState<{ membNo: string; schmCode: string } | null>(null);
  const [instRes, setInstRes] = useState<{ vchNo: number } | null>(null);
  const [maturRes, setMaturRes] = useState<{ vchNo: number; payout: number } | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busyE, setBusyE] = useState(false);
  const [busyI, setBusyI] = useState(false);
  const [busyM, setBusyM] = useState(false);

  // Active company year (informational context — scope itself is server-injected).

  async function doEnroll(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setEnrollRes(null);
    const body = {
      schmCode: enroll.schmCode.trim(),
      membCode: enroll.membCode.trim() || undefined,
      membName: enroll.membName.trim() || undefined,
      monthlyAmt: Number(enroll.monthlyAmt || 0),
      months: enroll.months.trim() ? Number(enroll.months) : undefined,
    };
    if (!body.schmCode) {
      setMsg({ kind: 'err', text: 'scheme code is required' });
      return;
    }
    if (!(body.monthlyAmt > 0)) {
      setMsg({ kind: 'err', text: 'monthly amount must be positive' });
      return;
    }
    setBusyE(true);
    try {
      const r = await post<{ membNo: string }>('/scheme/enroll', body);
      setEnrollRes({ membNo: r.membNo, schmCode: body.schmCode });
      setMsg({ kind: 'ok', text: `Member ${r.membNo} enrolled in scheme ${body.schmCode}` });
      setEnroll({ schmCode: '', membCode: '', membName: '', monthlyAmt: '', months: '' });
    } catch (err) {
      setMsg({ kind: 'err', text: errText(err) });
    } finally {
      setBusyE(false);
    }
  }

  async function doInstallment(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setInstRes(null);
    const body = {
      schmCode: inst.schmCode.trim(),
      membCode: inst.membCode.trim(),
      amount: Number(inst.amount || 0),
      mode: inst.mode,
      chqNo: inst.chqNo.trim() || undefined,
    };
    if (!body.schmCode) {
      setMsg({ kind: 'err', text: 'scheme code is required' });
      return;
    }
    if (!body.membCode) {
      setMsg({ kind: 'err', text: 'select a member' });
      return;
    }
    if (!(body.amount > 0)) {
      setMsg({ kind: 'err', text: 'amount must be positive' });
      return;
    }
    setBusyI(true);
    try {
      const r = await post<{ vchNo: number }>(
        inst.opening ? '/scheme/opening' : '/scheme/installment',
        body,
      );
      setInstRes(r);
      setMsg({
        kind: 'ok',
        text: `${inst.opening ? 'Opening balance' : 'Installment'} ₹${body.amount.toLocaleString('en-IN')} booked for member ${body.membCode} (voucher #${r.vchNo})`,
      });
      setInst((s) => ({ ...s, amount: '', chqNo: '' }));
    } catch (err) {
      setMsg({ kind: 'err', text: errText(err) });
    } finally {
      setBusyI(false);
    }
  }

  async function doMaturity(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setMaturRes(null);
    const body = {
      schmCode: matur.schmCode.trim(),
      membCode: matur.membCode.trim(),
      amount: Number(matur.amount || 0),
      bonus: matur.bonus.trim() ? Number(matur.bonus) : undefined,
      less: matur.less.trim() ? Number(matur.less) : undefined,
      mode: matur.mode,
    };
    if (!body.schmCode) {
      setMsg({ kind: 'err', text: 'scheme code is required' });
      return;
    }
    if (!body.membCode) {
      setMsg({ kind: 'err', text: 'select a member' });
      return;
    }
    if (!(body.amount > 0)) {
      setMsg({ kind: 'err', text: 'matured amount must be positive' });
      return;
    }
    setBusyM(true);
    try {
      const r = await post<{ vchNo: number; payout: number }>('/scheme/maturity', body);
      setMaturRes(r);
      setMsg({
        kind: 'ok',
        text: `Maturity payout ₹${r.payout.toLocaleString('en-IN')} for member ${body.membCode} (voucher #${r.vchNo})`,
      });
      setMatur((s) => ({ ...s, amount: '', bonus: '', less: '' }));
    } catch (err) {
      setMsg({ kind: 'err', text: errText(err) });
    } finally {
      setBusyM(false);
    }
  }

  return (
    <div>
      <h1>Saving Schemes</h1>
      {coYear && (
        <div className="muted" style={{ marginBottom: 8 }}>
          Company year: {coYear}
        </div>
      )}
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}

      <div className="row">
        {/* ───── Section 1: Enroll (customer joins a monthly saving scheme) ───── */}
        <form className="panel" style={{ flex: 1 }} onSubmit={doEnroll}>
          <h2>Enroll Member</h2>
          <div className="field">
            <label>Scheme Code</label>
            <input
              value={enroll.schmCode}
              onChange={(e) => setEnroll((s) => ({ ...s, schmCode: e.target.value }))}
              required
            />
          </div>
          <div className="field">
            <label>Member (Customer Account)</label>
            <LookupPicker
              entity="accounts"
              value={enroll.membCode}
              onChange={(v) => setEnroll((s) => ({ ...s, membCode: v }))}
              onPick={(r) =>
                setEnroll((s) => ({
                  ...s,
                  membCode: String(r.code),
                  membName: r.name ? String(r.name) : s.membName,
                }))
              }
            />
          </div>
          <div className="field">
            <label>Member Name</label>
            <input
              value={enroll.membName}
              onChange={(e) => setEnroll((s) => ({ ...s, membName: e.target.value }))}
            />
          </div>
          <div className="row">
            <div className="field">
              <label>Monthly Amount ₹</label>
              <input
                value={enroll.monthlyAmt}
                onChange={(e) => setEnroll((s) => ({ ...s, monthlyAmt: e.target.value }))}
                required
              />
            </div>
            <div className="field">
              <label>Months</label>
              <input
                value={enroll.months}
                onChange={(e) => setEnroll((s) => ({ ...s, months: e.target.value }))}
              />
            </div>
          </div>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <span className="muted">POST /scheme/enroll</span>
            <span className="spacer" />
            <button className="primary" disabled={busyE}>
              {busyE ? 'Enrolling…' : 'Enroll'}
            </button>
          </div>
          {enrollRes && (
            <div className="tiles" style={{ marginTop: 10 }}>
              <div className="tile">
                <div className="muted">member no</div>
                <div className="big kpi">{enrollRes.membNo}</div>
              </div>
              <div className="tile">
                <div className="muted">scheme</div>
                <div className="big kpi">{enrollRes.schmCode}</div>
              </div>
            </div>
          )}
        </form>

        {/* ───── Section 2: Installment (monthly payment → balanced receipt) ───── */}
        <form className="panel" style={{ flex: 1 }} onSubmit={doInstallment}>
          <h2>Pay Installment</h2>
          <div className="field">
            <label>Scheme Code</label>
            <input
              value={inst.schmCode}
              onChange={(e) => setInst((s) => ({ ...s, schmCode: e.target.value }))}
              required
            />
          </div>
          <div className="field">
            <label>Member (Customer Account)</label>
            <LookupPicker
              entity="accounts"
              value={inst.membCode}
              onChange={(v) => setInst((s) => ({ ...s, membCode: v }))}
            />
          </div>
          <div className="row">
            <div className="field">
              <label>Amount ₹</label>
              <input
                value={inst.amount}
                onChange={(e) => setInst((s) => ({ ...s, amount: e.target.value }))}
                required
              />
            </div>
            <div className="field">
              <label>Mode</label>
              <select
                value={inst.mode}
                onChange={(e) => setInst((s) => ({ ...s, mode: e.target.value }))}
              >
                {PAY_MODES.map((m) => (
                  <option key={m} value={m}>
                    {m}
                  </option>
                ))}
              </select>
            </div>
            <div className="field">
              <label>Cheque No</label>
              <input
                value={inst.chqNo}
                onChange={(e) => setInst((s) => ({ ...s, chqNo: e.target.value }))}
                disabled={inst.mode === 'cash'}
              />
            </div>
          </div>
          <div className="field" style={{ flexDirection: 'row', alignItems: 'center', gap: 8 }}>
            <input
              id="schm-opening"
              type="checkbox"
              checked={inst.opening}
              onChange={(e) => setInst((s) => ({ ...s, opening: e.target.checked }))}
            />
            <label htmlFor="schm-opening" style={{ margin: 0 }}>
              Opening balance entry (075 MEMB OPENING)
            </label>
          </div>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <span className="muted">POST /scheme/{inst.opening ? 'opening' : 'installment'}</span>
            <span className="spacer" />
            <button className="primary" disabled={busyI}>
              {busyI ? 'Posting…' : inst.opening ? 'Post Opening' : 'Post Installment'}
            </button>
            <button
              type="button"
              className="ghost"
              disabled={!inst.schmCode || !inst.membCode}
              onClick={() =>
                window.open(
                  `/api/scheme/passbook?schmCode=${encodeURIComponent(inst.schmCode.trim())}&membCode=${encodeURIComponent(inst.membCode.trim())}&format=html`,
                  '_blank',
                )
              }
            >
              Print Passbook
            </button>
          </div>
          {instRes && (
            <div className="tiles" style={{ marginTop: 10 }}>
              <div className="tile">
                <div className="muted">voucher</div>
                <div className="big kpi">#{instRes.vchNo}</div>
              </div>
            </div>
          )}
        </form>
      </div>

      <div className="row">
        {/* ───── Section 3: Maturity / Redemption (pay accrued balance back → 076 MBADJ → AD_ADJ) ───── */}
        <form className="panel" style={{ flex: 1 }} onSubmit={doMaturity}>
          <h2>Maturity / Redeem</h2>
          <div className="field">
            <label>Scheme Code</label>
            <input
              value={matur.schmCode}
              onChange={(e) => setMatur((s) => ({ ...s, schmCode: e.target.value }))}
              required
            />
          </div>
          <div className="field">
            <label>Member (Customer Account)</label>
            <LookupPicker
              entity="accounts"
              value={matur.membCode}
              onChange={(v) => setMatur((s) => ({ ...s, membCode: v }))}
            />
          </div>
          <div className="row">
            <div className="field">
              <label>Matured Amount ₹</label>
              <input
                value={matur.amount}
                onChange={(e) => setMatur((s) => ({ ...s, amount: e.target.value }))}
                required
              />
            </div>
            <div className="field">
              <label>Bonus ₹</label>
              <input
                value={matur.bonus}
                onChange={(e) => setMatur((s) => ({ ...s, bonus: e.target.value }))}
              />
            </div>
            <div className="field">
              <label>Less ₹</label>
              <input
                value={matur.less}
                onChange={(e) => setMatur((s) => ({ ...s, less: e.target.value }))}
              />
            </div>
            <div className="field">
              <label>Mode</label>
              <select
                value={matur.mode}
                onChange={(e) => setMatur((s) => ({ ...s, mode: e.target.value }))}
              >
                {PAY_MODES.map((m) => (
                  <option key={m} value={m}>
                    {m}
                  </option>
                ))}
              </select>
            </div>
          </div>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <span className="muted">POST /scheme/maturity · net = amount + bonus − less</span>
            <span className="spacer" />
            <button className="primary" disabled={busyM}>
              {busyM ? 'Posting…' : 'Post Maturity'}
            </button>
          </div>
          {maturRes && (
            <div className="tiles" style={{ marginTop: 10 }}>
              <div className="tile">
                <div className="muted">voucher</div>
                <div className="big kpi">#{maturRes.vchNo}</div>
              </div>
              <div className="tile">
                <div className="muted">payout ₹</div>
                <div className="big kpi">{maturRes.payout.toLocaleString('en-IN')}</div>
              </div>
            </div>
          )}
        </form>
      </div>
    </div>
  );
}
