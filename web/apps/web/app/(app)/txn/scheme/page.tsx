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
    itemGrossWt: '',
    membBonus: '',
    schemeShort: '',
    refCode: '',
    nomineeName: '',
    idProof: '',
    phone2: '',
    mobile2: '',
    email: '',
    district: '',
    birthDate: '',
    anniversaryDate: '',
    joinDate: '',
    expiryDate: '',
    lastBrokenDate: '',
    bankAcNo: '',
    bankRtgsNo: '',
    bankArea: '',
  });
  // POST /scheme/installment (or /scheme/opening when `opening`) → { schmCode, membCode, amount, mode? } → { vchNo }
  const [inst, setInst] = useState({
    // P3: the desktop numbers each installment by scheme month (AD_DATA month code), which is how a
    // member's paid/unpaid months are tracked.
    monthCode: '',
    schmCode: '',
    membCode: '',
    amount: '',
    mode: 'cash',
    bankAc: '',
    bankName: '',
    empCode: '',
    chqNo: '',
    withUpi: false,
    upiAcCode: '',
    upiAcName: '',
    upiType: 'UPI',
    upiId: '',
    upiAmount: '',
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
      // P3: the desktop enrollment carries the member's demographics, KYC, nominee, bank details
      // and scheme dates (TR_MEMB_ENT / AD_MEMB). `scheme.ts:89-116` accepts every one of these and
      // `:197-221` persists them; the screen sent none, so they could not be captured at all.
      // Reminder reports read birthDate/anniversaryDate (RP_REMINDER.cs:1303-1598), so an empty
      // enrollment silently disables those reminders for that member.
      itemGrossWt: enroll.itemGrossWt.trim() ? Number(enroll.itemGrossWt) : undefined,
      membBonus: enroll.membBonus.trim() ? Number(enroll.membBonus) : undefined,
      schemeShort: enroll.schemeShort.trim() || undefined,
      refCode: enroll.refCode.trim() || undefined,
      nomineeName: enroll.nomineeName.trim() || undefined,
      idProof: enroll.idProof.trim() || undefined,
      phone2: enroll.phone2.trim() || undefined,
      mobile2: enroll.mobile2.trim() || undefined,
      email: enroll.email.trim() || undefined,
      district: enroll.district.trim() || undefined,
      birthDate: enroll.birthDate.trim() || undefined,
      anniversaryDate: enroll.anniversaryDate.trim() || undefined,
      joinDate: enroll.joinDate.trim() || undefined,
      expiryDate: enroll.expiryDate.trim() || undefined,
      lastBrokenDate: enroll.lastBrokenDate.trim() || undefined,
      bankAcNo: enroll.bankAcNo.trim() || undefined,
      bankRtgsNo: enroll.bankRtgsNo.trim() || undefined,
      bankArea: enroll.bankArea.trim() || undefined,
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
      setEnroll({
        schmCode: '',
        membCode: '',
        membName: '',
        monthlyAmt: '',
        months: '',
        itemGrossWt: '',
        membBonus: '',
        schemeShort: '',
        refCode: '',
        nomineeName: '',
        idProof: '',
        phone2: '',
        mobile2: '',
        email: '',
        district: '',
        birthDate: '',
        anniversaryDate: '',
        joinDate: '',
        expiryDate: '',
        lastBrokenDate: '',
        bankAcNo: '',
        bankRtgsNo: '',
        bankArea: '',
      });
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
    const wantsUpi = inst.withUpi || inst.mode === 'upi';
    const body = {
      schmCode: inst.schmCode.trim(),
      membCode: inst.membCode.trim(),
      amount: Number(inst.amount || 0),
      monthCode: inst.monthCode.trim() || undefined,
      mode: inst.mode,
      bankAc: inst.bankAc.trim() || undefined,
      bankName: inst.bankName.trim() || undefined,
      empCode: inst.empCode.trim() || undefined,
      chqNo: inst.chqNo.trim() || undefined,
      withUpi: wantsUpi,
      upiAcCode: wantsUpi ? inst.upiAcCode.trim() || inst.bankAc.trim() || undefined : undefined,
      upiAcName: wantsUpi ? inst.upiAcName.trim() || inst.bankName.trim() || undefined : undefined,
      upiType: wantsUpi ? inst.upiType.trim() || 'UPI' : undefined,
      upiId: wantsUpi ? inst.upiId.trim() || inst.chqNo.trim() || undefined : undefined,
      upiAmount: wantsUpi ? Number(inst.upiAmount || inst.amount || 0) : undefined,
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
      setInst((s) => ({ ...s, amount: '', chqNo: '', upiId: '', upiAmount: '' }));
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

  const showInstallmentUpi = inst.withUpi || inst.mode === 'upi';

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
          <details style={{ marginTop: 8 }}>
            <summary>Member details, KYC, nominee and bank (desktop AD_MEMB)</summary>
            {/* The desktop enrollment form captures these on the member record. Birth and
                anniversary dates in particular drive the consolidated reminder report
                (RP_REMINDER.cs:1303-1598), so leaving them unreachable disabled those reminders. */}
            <div className="row">
              <div className="field">
                <label>Gold Wt (ITM_GWT)</label>
                <input
                  value={enroll.itemGrossWt}
                  onChange={(e) => setEnroll((s) => ({ ...s, itemGrossWt: e.target.value }))}
                />
              </div>
              <div className="field">
                <label>Bonus</label>
                <input
                  value={enroll.membBonus}
                  onChange={(e) => setEnroll((s) => ({ ...s, membBonus: e.target.value }))}
                />
              </div>
              <div className="field">
                <label>Scheme Short</label>
                <input
                  value={enroll.schemeShort}
                  onChange={(e) => setEnroll((s) => ({ ...s, schemeShort: e.target.value }))}
                />
              </div>
            </div>
            <div className="row">
              <div className="field">
                <label>Ref Code</label>
                <input
                  value={enroll.refCode}
                  onChange={(e) => setEnroll((s) => ({ ...s, refCode: e.target.value }))}
                />
              </div>
              <div className="field">
                <label>Nominee</label>
                <input
                  value={enroll.nomineeName}
                  onChange={(e) => setEnroll((s) => ({ ...s, nomineeName: e.target.value }))}
                />
              </div>
              <div className="field">
                <label>ID Proof (KYC)</label>
                <input
                  value={enroll.idProof}
                  onChange={(e) => setEnroll((s) => ({ ...s, idProof: e.target.value }))}
                />
              </div>
            </div>
            <div className="row">
              <div className="field">
                <label>Phone 2</label>
                <input
                  value={enroll.phone2}
                  onChange={(e) => setEnroll((s) => ({ ...s, phone2: e.target.value }))}
                />
              </div>
              <div className="field">
                <label>Mobile 2</label>
                <input
                  value={enroll.mobile2}
                  onChange={(e) => setEnroll((s) => ({ ...s, mobile2: e.target.value }))}
                />
              </div>
              <div className="field">
                <label>Email</label>
                <input
                  value={enroll.email}
                  onChange={(e) => setEnroll((s) => ({ ...s, email: e.target.value }))}
                />
              </div>
            </div>
            <div className="row">
              <div className="field">
                <label>District</label>
                <input
                  value={enroll.district}
                  onChange={(e) => setEnroll((s) => ({ ...s, district: e.target.value }))}
                />
              </div>
              <div className="field">
                <label>Birth Date</label>
                <input
                  type="date"
                  value={enroll.birthDate}
                  onChange={(e) => setEnroll((s) => ({ ...s, birthDate: e.target.value }))}
                />
              </div>
              <div className="field">
                <label>Anniversary</label>
                <input
                  type="date"
                  value={enroll.anniversaryDate}
                  onChange={(e) => setEnroll((s) => ({ ...s, anniversaryDate: e.target.value }))}
                />
              </div>
            </div>
            <div className="row">
              <div className="field">
                <label>Join Date</label>
                <input
                  type="date"
                  value={enroll.joinDate}
                  onChange={(e) => setEnroll((s) => ({ ...s, joinDate: e.target.value }))}
                />
              </div>
              <div className="field">
                <label>Expiry Date</label>
                <input
                  type="date"
                  value={enroll.expiryDate}
                  onChange={(e) => setEnroll((s) => ({ ...s, expiryDate: e.target.value }))}
                />
              </div>
              <div className="field">
                <label>Last Broken</label>
                <input
                  type="date"
                  value={enroll.lastBrokenDate}
                  onChange={(e) => setEnroll((s) => ({ ...s, lastBrokenDate: e.target.value }))}
                />
              </div>
            </div>
            <div className="row">
              <div className="field">
                <label>Bank A/c No</label>
                <input
                  value={enroll.bankAcNo}
                  onChange={(e) => setEnroll((s) => ({ ...s, bankAcNo: e.target.value }))}
                />
              </div>
              <div className="field">
                <label>Bank RTGS/IFSC</label>
                <input
                  value={enroll.bankRtgsNo}
                  onChange={(e) => setEnroll((s) => ({ ...s, bankRtgsNo: e.target.value }))}
                />
              </div>
              <div className="field">
                <label>Bank Area</label>
                <input
                  value={enroll.bankArea}
                  onChange={(e) => setEnroll((s) => ({ ...s, bankArea: e.target.value }))}
                />
              </div>
            </div>
          </details>
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
              <label>Month Code</label>
              <input
                value={inst.monthCode}
                onChange={(e) => setInst((s) => ({ ...s, monthCode: e.target.value }))}
                maxLength={2}
              />
            </div>
            <div className="field">
              <label>Employee</label>
              <input
                value={inst.empCode}
                onChange={(e) => setInst((s) => ({ ...s, empCode: e.target.value }))}
                maxLength={3}
              />
            </div>
            <div className="field">
              <label>Settlement A/c</label>
              <LookupPicker
                entity="accounts"
                value={inst.bankAc}
                onChange={(v) => setInst((s) => ({ ...s, bankAc: v }))}
                onPick={(r) =>
                  setInst((s) => ({
                    ...s,
                    bankAc: String(r.code),
                    bankName: r.name ? String(r.name) : s.bankName,
                    upiAcCode: s.upiAcCode || String(r.code),
                    upiAcName: s.upiAcName || (r.name ? String(r.name) : ''),
                  }))
                }
              />
            </div>
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
                onChange={(e) => {
                  const mode = e.target.value;
                  setInst((s) => ({ ...s, mode, withUpi: mode === 'upi' ? true : s.withUpi }));
                }}
              >
                {PAY_MODES.map((m) => (
                  <option key={m} value={m}>
                    {m}
                  </option>
                ))}
              </select>
            </div>
            <div className="field">
              <label>Bank Name</label>
              <input
                value={inst.bankName}
                onChange={(e) => setInst((s) => ({ ...s, bankName: e.target.value }))}
              />
            </div>
            <div className="field">
              <label>Cheque / Ref No</label>
              <input
                value={inst.chqNo}
                onChange={(e) => setInst((s) => ({ ...s, chqNo: e.target.value }))}
                disabled={inst.mode === 'cash' && !inst.withUpi}
              />
            </div>
          </div>
          <div className="field" style={{ flexDirection: 'row', alignItems: 'center', gap: 8 }}>
            <input
              id="schm-with-upi"
              type="checkbox"
              checked={showInstallmentUpi}
              disabled={inst.mode === 'upi'}
              onChange={(e) => setInst((s) => ({ ...s, withUpi: e.target.checked }))}
            />
            <label htmlFor="schm-with-upi" style={{ margin: 0 }}>
              With UPI split/payment (writes UPI_DATA)
            </label>
          </div>
          {showInstallmentUpi && (
            <details open style={{ marginTop: 8 }}>
              <summary>UPI settlement detail</summary>
              <div className="row">
                <div className="field">
                  <label>UPI A/c</label>
                  <LookupPicker
                    entity="accounts"
                    value={inst.upiAcCode}
                    onChange={(v) => setInst((s) => ({ ...s, upiAcCode: v }))}
                    onPick={(r) =>
                      setInst((s) => ({
                        ...s,
                        upiAcCode: String(r.code),
                        upiAcName: r.name ? String(r.name) : s.upiAcName,
                      }))
                    }
                  />
                </div>
                <div className="field">
                  <label>UPI A/c Name</label>
                  <input
                    value={inst.upiAcName}
                    onChange={(e) => setInst((s) => ({ ...s, upiAcName: e.target.value }))}
                  />
                </div>
                <div className="field">
                  <label>UPI Type</label>
                  <input
                    value={inst.upiType}
                    onChange={(e) => setInst((s) => ({ ...s, upiType: e.target.value }))}
                  />
                </div>
                <div className="field">
                  <label>UPI ID</label>
                  <input
                    value={inst.upiId}
                    onChange={(e) => setInst((s) => ({ ...s, upiId: e.target.value }))}
                  />
                </div>
                <div className="field">
                  <label>UPI Amount ₹</label>
                  <input
                    value={inst.upiAmount}
                    onChange={(e) => setInst((s) => ({ ...s, upiAmount: e.target.value }))}
                    placeholder={inst.amount || 'amount'}
                  />
                </div>
              </div>
            </details>
          )}
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
