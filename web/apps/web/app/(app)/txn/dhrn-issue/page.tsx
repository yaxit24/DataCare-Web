'use client';
import { useState } from 'react';
import { post, put, get, del, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { VoucherList } from '../../../../components/VoucherList';
import { LookupPicker } from '../../../../components/LookupPicker';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { fineFor } from '@datacare/core';
import { openDocument } from '../../../../lib/openDocument';

// One pledged-ornament collateral line. Fine + Amount are computed previews (see calc()).
interface Coll {
  itCode: string;
  itDesc: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
}
const blank = (): Coll => ({
  itCode: '',
  itDesc: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
});
const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;
const inr = (x: number) => x.toLocaleString('en-IN');

const extendedIssueFields: Array<[string, string]> = [
  ['licenceNo', 'Pawn Licence No'],
  ['remarks', 'Remarks'],
  ['adjustedDhrn', 'Adjusted Dhiran'],
  ['uncheckedReceipts', 'Unchecked Receipts'],
  ['cashAc', 'Cash Ac'],
  ['fromDate', 'From Date'],
  ['goldAmt', 'Gold Amt'],
  ['goldWt', 'Gold Wt'],
  ['loanAc', 'Loan Ac'],
];
export default function DhrnIssuePage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [borrowerAc, setBorrowerAc] = useState('');
  // Desktop DHRN_ISU_DATA fields the API accepts.
  const [extra, setExtra] = useState<Record<string, string>>({});
  const [borrowerName, setBorrowerName] = useState('');
  const [loanType, setLoanType] = useState<'A' | 'G' | 'S'>('A');
  const [principal, setPrincipal] = useState('');
  const [intPrc, setIntPrc] = useState('');
  const [intMonths, setIntMonths] = useState('');
  const [packetNo, setPacketNo] = useState('');
  const [otherCharges, setOtherCharges] = useState('');
  const [toDate, setToDate] = useState('');
  const [lines, setLines] = useState<Coll[]>([blank()]);
  // Desktop grids are keyboard-driven: arrows move between cells, Enter advances and
  // appends a row at the end, Ctrl/Cmd+D removes one (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    onAppendRow: () => setLines((rows) => [...rows, blank()]),
    onRemoveRow: (row) => {
      setLines((rows) =>
        rows.length === 1 ? [blank()] : rows.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  const [res, setRes] = useState<{ vchNo: number; intAmt: number; monthInt: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const [loadedVch, setLoadedVch] = useState('');

  const setLine = (i: number, k: keyof Coll, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // per-line preview: fine = net×touch/100, amount = fine×rate (valuation of the pledged metal)
  const calc = (l: Coll) => {
    const fine = fineFor('sale', { netWt: n(l.netWt), touch: n(l.touch) });
    const amount = r2(fine * n(l.rate));
    return { fine, amount };
  };
  const totalFine = r2(lines.reduce((s, l) => s + calc(l).fine, 0));
  const totalAmount = r2(lines.reduce((s, l) => s + calc(l).amount, 0));
  // Issue-time interest preview.
  //
  // This mirrors `desktopDhrnInterest` for the SIMPLE case only: monthly mode, no compounding,
  // a 360-day year. That function (settingsBehavior.ts) actually derives days from the book's
  // interest type ('M' -> months x 30, else a day count honouring CO_SET.INT_DAY), divides by
  // CO_SET.INT_YEAR_DAYS rather than a literal 360, and compounds in annual blocks when
  // CO_SET.DHIRN_COMPOUND is set and days/365 exceeds 1 (TR_DHRN_REC.cs:6897-6927).
  //
  // The server recomputes on save and is authoritative, so this is a guide, not the charge. It
  // is labelled as such below rather than presented as the figure, because a preview that
  // silently disagrees with the posted interest is worse than no preview at all.
  const intPreviewApproximate = r2(
    ((n(principal) * n(intPrc)) / 100) * ((n(intMonths) * 30) / 360),
  );

  function resetForm() {
    setLoadedVch('');
    setBorrowerAc('');
    setBorrowerName('');
    setLoanType('A');
    setPrincipal('');
    setIntPrc('');
    setIntMonths('');
    setPacketNo('');
    setOtherCharges('');
    setToDate('');
    setExtra({});
    setLines([blank()]);
    setRes(null);
    setErr('');
  }

  // Reopen a saved pledge (GET /dhrn/issue/:isuNo) into the form so it can be edited and re-saved.
  async function loadIssue(isuNo: string) {
    setErr('');
    setRes(null);
    setBusy(true);
    try {
      const d = await get<any>(`/dhrn/issue/${encodeURIComponent(isuNo)}`);
      setLoadedVch(String(d.voucherNo ?? isuNo));
      setBorrowerAc(String(d.borrowerAc ?? ''));
      setBorrowerName(String(d.borrowerName ?? ''));
      setLoanType((d.loanType as 'A' | 'G' | 'S') || 'A');
      setPrincipal(String(d.principal ?? ''));
      setIntPrc(d.intPrc ? String(d.intPrc) : '');
      setIntMonths(d.intMonths ? String(d.intMonths) : '');
      setPacketNo(String(d.packetNo ?? ''));
      setOtherCharges(d.otherCharges ? String(d.otherCharges) : '');
      setToDate(String(d.toDate ?? ''));
      setExtra({
        fromDate: String(d.fromDate ?? ''),
        goldWt: d.goldWt ? String(d.goldWt) : '',
        goldAmt: d.goldAmt ? String(d.goldAmt) : '',
        licenceNo: String(d.licenceNo ?? ''),
        remarks: String(d.remarks ?? ''),
        adjustedDhrn: d.adjustedDhrn ? String(d.adjustedDhrn) : '',
        uncheckedReceipts: d.uncheckedReceipts ? String(d.uncheckedReceipts) : '',
      });
      const coll = Array.isArray(d.collateral) ? d.collateral : [];
      setLines(
        coll.length
          ? coll.map((c: any) => ({
              ...blank(),
              itCode: String(c.itCode ?? ''),
              itDesc: String(c.itName ?? c.itDesc ?? ''),
              pcs: c.pcs ? String(c.pcs) : '',
              grossWt: c.grossWt ? String(c.grossWt) : '',
              netWt: c.netWt ? String(c.netWt) : '',
              touch: c.touch ? String(c.touch) : '',
              rate: c.rate ? String(c.rate) : '',
            }))
          : [blank()],
      );
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setRes(null);
    setBusy(true);
    try {
      const body = {
        coBook,
        coYear,
        lcCode,
        borrowerAc,
        borrowerName: borrowerName || undefined,
        principal: Number(principal),
        cashAc: extra.cashAc || undefined,
        fromDate: extra.fromDate || undefined,
        goldAmt: extra.goldAmt ? Number(extra.goldAmt) : undefined,
        goldWt: extra.goldWt ? Number(extra.goldWt) : undefined,
        // Pledge metadata written to DHRN_DATA (TR_DHRN_ISU/REC).
        licenceNo: extra.licenceNo || undefined,
        remarks: extra.remarks || undefined,
        adjustedDhrn: extra.adjustedDhrn ? Number(extra.adjustedDhrn) : undefined,
        uncheckedReceipts: extra.uncheckedReceipts ? Number(extra.uncheckedReceipts) : undefined,
        loanAc: extra.loanAc || undefined,
        // P1-1: omit `intPrc` when blank so the company default can supply it.
        //
        // `dhrn.ts:306` resolves `input.intPrc ?? cfg.dhrnDefaultRate` (desktop
        // TR_DHRN_ISU.cs:4787 reads CO_SET.DHRN_PRC), and `:307-308` refuses only when BOTH are
        // absent. Sending 0 satisfied the `annualRatePct >= 0` guard, so a blank field silently
        // issued a zero-interest loan instead of using the configured rate — the company default
        // could never take effect through this screen.
        intPrc: intPrc.trim() === '' ? undefined : Number(intPrc),
        intMonths: Number(intMonths || 0),
        loanType,
        packetNo: packetNo || undefined,
        otherCharges: Number(otherCharges || 0),
        toDate: toDate || undefined,
        collateral: lines
          .filter((l) => l.itCode && (l.netWt || l.rate || l.grossWt))
          .map((l) => {
            const c = calc(l);
            return {
              itCode: l.itCode,
              itDesc: l.itDesc || undefined,
              pcs: n(l.pcs),
              grossWt: n(l.grossWt),
              netWt: n(l.netWt),
              touch: n(l.touch),
              westPct: 0,
              fineWt: c.fine,
              rate: n(l.rate),
              amount: c.amount,
              packet: packetNo || undefined,
            };
          }),
      };
      setRes(
        loadedVch
          ? await put(`/dhrn/issue/${encodeURIComponent(loadedVch)}`, body)
          : await post('/dhrn/issue', body),
      );
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Pledge Loan — Issue</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect
                value={coBook}
                onChange={setCoBook}
                preferred="DIS"
                mainBooks={['DHIRAN ISSUE']}
              />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly />
            </div>
            <div className="field">
              <label>Location</label>
              <input value={lcCode} readOnly />
            </div>
            <div className="field">
              <label>Borrower (AC_CODE)</label>
              <LookupPicker
                entity="accounts"
                value={borrowerAc}
                onChange={setBorrowerAc}
                onPick={(r) => setBorrowerName(String(r.name || ''))}
              />
            </div>
            <div className="field">
              <label>Borrower Name</label>
              <input value={borrowerName} onChange={(e) => setBorrowerName(e.target.value)} />
            </div>
            <div className="field">
              <label>Loan Type</label>
              <select
                value={loanType}
                onChange={(e) => setLoanType(e.target.value as 'A' | 'G' | 'S')}
              >
                <option value="A">A · Amount</option>
                <option value="G">G · Gold</option>
                <option value="S">S · Silver</option>
              </select>
            </div>
          </div>
          <div className="row">
            <div className="field">
              <label>Principal</label>
              <input value={principal} onChange={(e) => setPrincipal(e.target.value)} required />
            </div>
            <div className="field">
              <label>Annual Int %</label>
              <input value={intPrc} onChange={(e) => setIntPrc(e.target.value)} />
            </div>
            <div className="field">
              <label>Int Months</label>
              <input value={intMonths} onChange={(e) => setIntMonths(e.target.value)} />
            </div>
            <div className="field">
              <label>Packet No</label>
              <input value={packetNo} onChange={(e) => setPacketNo(e.target.value)} />
            </div>
            <div className="field">
              <label>Other Charges</label>
              <input value={otherCharges} onChange={(e) => setOtherCharges(e.target.value)} />
            </div>
            <div className="field">
              <label>To / Maturity Date</label>
              <input type="date" value={toDate} onChange={(e) => setToDate(e.target.value)} />
            </div>
          </div>
          <div className="muted" style={{ marginTop: 6 }}>
            Approximate interest <b>₹{inr(intPreviewApproximate)}</b> = principal ×{' '}
            {intPrc.trim() === '' ? 'company default' : `${n(intPrc)}%`}/yr × ({n(intMonths)}
            ×30)/360. The posted amount is recomputed on save from this loan&rsquo;s configured
            interest type, day basis, year length and compounding, so it may differ.
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Collateral — Pledged Ornaments</h2>
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Item</th>
                <th>Desc</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch%</th>
                <th className="num">Fine</th>
                <th className="num">Rate</th>
                <th className="num">Amount</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {lines.map((l, i) => {
                const c = calc(l);
                return (
                  <tr key={i}>
                    <td>
                      <LookupPicker
                        entity="items"
                        value={l.itCode}
                        onChange={(v) => setLine(i, 'itCode', v)}
                        style={{ width: 90 }}
                        onPick={(r) =>
                          setLines((ls) =>
                            ls.map((x, j) =>
                              j === i
                                ? {
                                    ...x,
                                    itCode: String(r.code),
                                    itDesc: x.itDesc || String(r.name || ''),
                                  }
                                : x,
                            ),
                          )
                        }
                      />
                    </td>
                    <td>
                      <input
                        style={{ width: 150 }}
                        value={l.itDesc}
                        onChange={(e) => setLine(i, 'itDesc', e.target.value)}
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
                    <td className="num">{inr(c.fine)}</td>
                    <td className="num">
                      <input
                        style={{ width: 72, textAlign: 'right' }}
                        value={l.rate}
                        onChange={(e) => setLine(i, 'rate', e.target.value)}
                      />
                    </td>
                    <td className="num">{inr(c.amount)}</td>
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
                );
              })}
            </tbody>
          </table>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setLines((ls) => [...ls, blank()])}
            >
              + Add line
            </button>
            <span className="spacer" />
            <span className="muted" style={{ marginRight: 16 }}>
              Fine {inr(totalFine)} g · <b>Total ₹{inr(totalAmount)}</b>
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Saving…' : loadedVch ? `Update #${loadedVch}` : 'Issue Loan'}
            </button>
            {loadedVch && (
              <button type="button" className="ghost" onClick={resetForm} disabled={busy}>
                New
              </button>
            )}
          </div>
        </div>
        <details style={{ marginTop: 8 }}>
          <summary>Desktop pledge fields</summary>
          <div className="row">
            {extendedIssueFields.map(([key, label]) => (
              <div className="field" key={key}>
                <label>{label}</label>
                <input
                  value={extra[key] ?? ''}
                  onChange={(e) => setExtra((x) => ({ ...x, [key]: e.target.value }))}
                />
              </div>
            ))}
          </div>
        </details>
      </form>

      <VoucherList
        table="DHRN_ISU_DATA"
        book={coBook}
        deleteBase="/dhrn/issue"
        onLoad={(vchNo) => loadIssue(vchNo)}
        printHref={(vchNo) =>
          `/api/dhrn/issue-receipt?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(vchNo)}&format=html`
        }
      />

      {err && <div className="msg err">{err}</div>}
      {res && (
        <div className="panel">
          <div className="msg ok">
            {loadedVch ? 'Updated' : 'Issued'} — Voucher #{res.vchNo}
          </div>
          <div className="toolbar" style={{ marginTop: 6 }}>
            <button
              type="button"
              className="ghost"
              onClick={() =>
                openDocument(
                  `/api/dhrn/issue-receipt?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(String(res.vchNo))}&format=html`,
                )
              }
            >
              View Pledge Receipt
            </button>
          </div>
          <div className="tiles">
            <div className="tile">
              <div className="muted">vchNo</div>
              <div className="big kpi">{res.vchNo}</div>
            </div>
            <div className="tile">
              <div className="muted">intAmt</div>
              <div className="big kpi">{Number(res.intAmt).toLocaleString('en-IN')}</div>
            </div>
            <div className="tile">
              <div className="muted">monthInt</div>
              <div className="big kpi">{Number(res.monthInt).toLocaleString('en-IN')}</div>
            </div>
          </div>
        </div>
      )}
      {/* Desktop BtnImgS / BtnImgC / BtnImgD on this form photograph the record itself. */}
      <EntityImagePanel
        entityType="AC"
        entityKey={borrowerAc}
        instance={0}
        label="Borrower photo"
        testId="dhrn-issue-image"
      />
    </div>
  );
}
