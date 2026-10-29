'use client';
import { useState } from 'react';
import { get, post, put, ApiError } from '../lib/api';
import { LookupPicker } from './LookupPicker';
import { BookSelect } from './BookSelect';
import { VoucherList } from './VoucherList';
import { EntityImagePanel } from './EntityImagePanel';
import { useGridKeyboard } from './GridKeyboard';
import SubDetailGrid, { SUB_DETAIL_COMPONENT, useSubDetail } from './SubDetailGrid';

/** Karigar (goldsmith) issue/receive. Issue = raw fine metal OUT; Receive = finished ornaments IN
 *  (wastage folded into fine), with per-line labour + optional GST + optional barcode tagging (F3). */
interface Line {
  itCode: string;
  designNo: string;
  tblCode: string;
  itmSize: string;
  pcs: string;
  grossWt: string;
  othWt: string;
  netWt: string;
  ghtWt: string;
  touch: string;
  westPct: string;
  lbrType: string;
  lbrRate: string;
  lbrAmt: string;
  othAmt: string;
  tag: boolean;
  // Desktop karigar-grid columns (TR_PURC shared detail block).
  amount: string;
  bagWt: string;
  convPct: string;
  convRate: string;
  itDesc: string;
  lbrPct: string;
  lesWt: string;
  lessTouch: string;
  lossWt: string;
  lotNo: string;
  mrp: string;
  oldSrNo: string;
  otherFine: string;
  otherRate: string;
  kundanWt: string;
  kundanTouch: string;
  kunFine: string;
  silverFine: string;
  ghtPct: string;
  urdRateType: string;
  commissionPct: string;
  commissionAmount: string;
  rate: string;
  rateType: string;
  tagNo: string;
  totalAmount: string;
  withStock: string;
}
const extendedKarigarFields: Array<[keyof Line, string]> = [
  ['amount', 'Amount'],
  ['bagWt', 'Bag Wt'],
  ['convPct', 'Conv Pct'],
  ['convRate', 'Conv Rate'],
  ['itDesc', 'It Desc'],
  ['lbrPct', 'Lbr Pct'],
  ['lesWt', 'Les Wt'],
  ['lessTouch', 'Less Touch'],
  ['lossWt', 'Loss Wt'],
  ['lotNo', 'Lot No'],
  ['mrp', 'Mrp'],
  ['oldSrNo', 'Old Sr No'],
  ['otherFine', 'Other Fine'],
  ['otherRate', 'Other Rate'],
  ['kundanWt', 'Kundan Wt'],
  ['kundanTouch', 'Kundan Touch'],
  ['kunFine', 'Kun Fine'],
  ['silverFine', 'Silver Fine'],
  ['ghtPct', 'Ght %'],
  ['urdRateType', 'URD Rate Type'],
  ['commissionPct', 'Comm %'],
  ['commissionAmount', 'Comm Amt'],
  ['rate', 'Rate'],
  ['rateType', 'Rate Type'],
  ['tagNo', 'Tag No'],
  ['totalAmount', 'Total Amount'],
  ['withStock', 'With Stock'],
];
const blank = (): Line => ({
  itCode: '',
  designNo: '',
  tblCode: '001',
  itmSize: '',
  pcs: '1',
  grossWt: '',
  othWt: '',
  netWt: '',
  ghtWt: '',
  touch: '',
  westPct: '',
  lbrType: 'G',
  lbrRate: '',
  lbrAmt: '',
  othAmt: '',
  tag: false,
  amount: '',
  bagWt: '',
  convPct: '',
  convRate: '',
  itDesc: '',
  lbrPct: '',
  lesWt: '',
  lessTouch: '',
  lossWt: '',
  lotNo: '',
  mrp: '',
  oldSrNo: '',
  otherFine: '',
  otherRate: '',
  kundanWt: '',
  kundanTouch: '',
  kunFine: '',
  silverFine: '',
  ghtPct: '',
  urdRateType: '',
  commissionPct: '',
  commissionAmount: '',
  rate: '',
  rateType: '',
  tagNo: '',
  totalAmount: '',
  withStock: '',
});
const n = (v: string) => Number(v || 0);
const r3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

export default function KarigarForm({
  mode,
  label = 'Karigar',
  family = 'karigar',
}: {
  mode: 'issue' | 'receive';
  label?: string;
  /**
   * WHICH DESKTOP VOUCHER FAMILY THIS INSTANCE POSTS.
   *
   * This used to be absent, and the endpoint was hardcoded to `/karigar/*` while `label` changed only the
   * heading. The job-work pages therefore rendered a form titled "Job-work" that silently wrote KARIGAR
   * vouchers, and the dedicated job-work backend at `/mfg/jobwork-issue|receive` was unreachable from the UI.
   *
   * The correct target is established from the desktop source, not from the label: `TR_JDT_REC.cs` writes
   * MFG_DATA / MFG_DETL / MFG_IDTL (13 MFG_DETL, 9 MFG_DATA, 5 MFG_IDTL references) — the manufacturing
   * family — and `apps/api/src/modules/manufacturing/mfg.ts` cites `TR_JDT_REC.cs:5634/6134-6140/6432`
   * directly. Job-work is an MFG voucher; karigar issue/receive is a KR voucher.
   */
  family?: 'karigar' | 'jobwork' | 'old-item-sales';
}) {
  const oldItemSales = family === 'old-item-sales';
  const ep =
    family === 'jobwork'
      ? mode === 'issue'
        ? '/mfg/jobwork-issue'
        : '/mfg/jobwork-receive'
      : oldItemSales
        ? '/old-item-sales'
        : mode === 'issue'
          ? '/karigar/issue'
          : '/karigar/receive';
  const title = oldItemSales
    ? `${label} — OLD ITEM SALES`
    : mode === 'issue'
      ? `${label} Issue — metal OUT`
      : `${label} Receive — metal IN`;
  const rcv = mode === 'receive';
  // G19: these screens post to a writer that resolves the voucher book from BOOK_DATA and refuses a
  // book-less scope. The form used to send none, so a fresh company could not save a karigar/job-work
  // voucher at all. Choose the configured book of the right MAIN_BOOK family and send it as coBook.
  const bookFamilies =
    family === 'jobwork'
      ? mode === 'issue'
        ? ['JDTR ISU']
        : ['JDTR REC']
      : oldItemSales
        ? ['OLD ITEM SALES']
        : mode === 'issue'
          ? ['KARIGAR ISSUE', 'KARIGAR']
          : ['KARIGAR RECEIPT', 'KARIGAR'];
  const [coBook, setCoBook] = useState('');
  const showLabourTax = rcv && !oldItemSales;
  const [karigarAc, setKarigarAc] = useState('');
  const [karigarName, setKarigarName] = useState('');
  const [labourGstPct, setLabourGstPct] = useState('5');
  const [interState, setInterState] = useState(false);
  const [lines, setLines] = useState<Line[]>([blank()]);
  // One sub-detail grid serves all four pages this component backs. Karigar takes `stones`
  // (`karigar.ts:132`, KR_IDTL); job-work takes `components` (`mfg.ts:287`, MFG_IDTL) whose two
  // amount fields are named differently — `componentsFor` handles the rename.
  const sub = useSubDetail(lines.length);
  // P1-5: the shared form backs karigar issue/receive AND jobwork issue/receive, so mounting the
  // keyboard contract here reaches four transaction pages at once. Desktop grids are keyboard-first
  // (TR_SALE.cs:12250-12320 for the movement rules, TR_KR_ISU.cs for this form's own grid).
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
  // Shared by jobwork issue/receive and karigar issue/receive: the desktop images the tag on the
  // current grid row (TR_JDT_REC / TR_MFG_KR_ISU_REC), so one panel serves all four forms.
  const [imageRow, setImageRow] = useState(0);
  const [res, setRes] = useState<any>(null);
  const [bal, setBal] = useState<number | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const [loadedVch, setLoadedVch] = useState('');
  // Reopen/edit is backed for karigar/issue, karigar/receive and old-item-sales (GET/PUT/DELETE
  // routes exist); jobwork has no lifecycle routes yet, so it stays create-only.
  const lifecycle = family === 'karigar' || oldItemSales;
  // VoucherList lists by the family's header table: KR_DATA for karigar/old-item-sales.
  const lifecycleTable = 'KR_DATA';
  // P3: the karigar's outstanding bill amount carried on the voucher (IssueInput.billOutstanding).
  const [billOutstanding, setBillOutstanding] = useState('');
  const [partyFine, setPartyFine] = useState('');

  const setLine = (i: number, k: keyof Line, v: string | boolean) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));
  /**
   * P1-3 — the line fine preview must mirror the server policy for the ACTIVE mode.
   *
   * The two modes use genuinely different desktop formulas, and `finePolicy.ts` implements both:
   *   karigarIssue    ((net + ghat) x (touch + wastage)) / 100 - lessWeight   TR_KR_ISU.cs:3938-3944
   *   karigarReceipt  (net x (touch + wastage)) / 100                         MS_UPDATE.cs:2691
   *
   * The previous preview was `net x (touch + (receive ? wastage : 0)) / 100`, which was wrong on
   * BOTH sides: it dropped wastage and ghat and less-weight on issue, and dropped nothing but
   * also credited no ghat on receive. Worse, the issue PAYLOAD omitted `westPct` altogether, so
   * the persisted issue fine lost wastage too — the operator could type a wastage percentage and
   * neither the screen nor the saved voucher would reflect it.
   */
  const fine = (l: Line) => {
    const pct = n(l.touch) + n(l.westPct);
    if (oldItemSales) {
      return r3(
        pct !== 0 && n(l.netWt) !== 0
          ? ((n(l.netWt) + n(l.ghtWt)) * (pct - n(l.lessTouch))) / 100 + n(l.kunFine)
          : n(l.netWt) + n(l.kunFine),
      );
    }
    return rcv
      ? r3((n(l.netWt) * pct) / 100)
      : r3(((n(l.netWt) + n(l.ghtWt)) * pct) / 100 - n(l.lesWt));
  };
  const totFine = r3(lines.reduce((s, l) => s + fine(l), 0));
  const totLabour = r2(lines.reduce((s, l) => s + n(l.lbrAmt), 0));
  const totGst = r2((totLabour * n(labourGstPct)) / 100);

  async function checkBalance(ac = karigarAc) {
    if (!ac) return;
    try {
      const r = await get<any>(`/karigar/${encodeURIComponent(ac)}/balance`);
      setBal(r.balance);
    } catch {
      setBal(null);
    }
  }

  function resetForm() {
    setLoadedVch('');
    setKarigarAc('');
    setKarigarName('');
    setLines([blank()]);
    sub.reset();
    setBillOutstanding('');
    setPartyFine('');
    setRes(null);
    setErr('');
  }

  // Reopen a saved karigar / old-item-sales voucher for edit (GET ${ep}/:vchNo). The reader returns
  // numbers; the form holds strings, so every field is stringified. Sub-detail stones are replaced
  // in one shot via sub.load(perLine), the primitive SubDetailGrid exposes for exactly this.
  async function loadVoucher(vchNo: string) {
    if (!lifecycle) return;
    setErr('');
    setRes(null);
    setBusy(true);
    try {
      const d = await get<any>(
        `${ep}/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVch(String(d.voucherNo ?? vchNo));
      setKarigarAc(String(d.karigarAc ?? ''));
      setKarigarName(String(d.karigarName ?? ''));
      if (d.labourGstPct != null) setLabourGstPct(String(d.labourGstPct));
      setBillOutstanding(d.billOutstanding ? String(d.billOutstanding) : '');
      setPartyFine(d.partyFine ? String(d.partyFine) : '');
      const str = (v: unknown) => (v == null || v === 0 ? '' : String(v));
      const srcLines: any[] = Array.isArray(d.lines) && d.lines.length ? d.lines : [];
      setLines(
        srcLines.length
          ? srcLines.map((l) => ({
              ...blank(),
              itCode: String(l.itCode ?? ''),
              designNo: String(l.designNo ?? ''),
              tblCode: String(l.tblCode ?? '001'),
              itmSize: String(l.itmSize ?? ''),
              tagNo: String(l.tagNo ?? ''),
              pcs: str(l.pcs) || '1',
              grossWt: str(l.grossWt),
              othWt: str(l.othWt),
              netWt: str(l.netWt),
              ghtWt: str(l.ghtWt),
              touch: str(l.touch),
              westPct: str(l.westPct),
              lbrType: String(l.lbrType ?? 'G'),
              lbrRate: str(l.lbrRate),
              lbrPct: str(l.lbrPct),
              lbrAmt: str(l.lbrAmt),
              othAmt: str(l.othAmt),
              bagWt: str(l.bagWt),
              convPct: str(l.convPct),
              convRate: str(l.convRate),
              itDesc: String(l.itDesc ?? ''),
              lessTouch: str(l.lessTouch),
              lossWt: str(l.lossWt),
              lotNo: String(l.lotNo ?? ''),
              mrp: str(l.mrp),
              oldSrNo: str(l.oldSrNo),
              otherFine: str(l.otherFine),
              otherRate: str(l.otherRate),
              silverFine: str(l.silverFine),
              ghtPct: str(l.ghtPct),
              urdRateType: String(l.urdRateType ?? ''),
              commissionPct: str(l.commissionPct),
              commissionAmount: str(l.commissionAmount),
              rate: str(l.rate),
              rateType: String(l.rateType ?? ''),
              amount: str(l.amount),
              totalAmount: str(l.totalAmount),
              withStock: String(l.withStock ?? ''),
            }))
          : [blank()],
      );
      // Replace the stone sub-detail, one entry per parent line.
      const stoneStr = (v: unknown) => (v == null || v === 0 ? undefined : String(v));
      sub.load(
        (srcLines.length ? srcLines : [{}]).map((l) =>
          (Array.isArray(l.stones) ? l.stones : []).map((s: any) => {
            const row: Record<string, string> = {};
            for (const [k, v] of Object.entries(s)) {
              if (k === 'isrNo') continue;
              const sv = typeof v === 'number' ? stoneStr(v) : v ? String(v) : undefined;
              if (sv != null) row[k] = sv;
            }
            return row;
          }),
        ),
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
    if (!coBook) {
      setErr('select the configured book first');
      return;
    }
    setBusy(true);
    try {
      const karigarLine = (l: Line, sourceIndex: number) => ({
        stones: sub.inputsFor(sourceIndex),
        itCode: l.itCode || undefined,
        designNo: l.designNo || undefined,
        tblCode: l.tblCode || undefined,
        itmSize: l.itmSize || undefined,
        amount: n(l.amount) || undefined,
        bagWt: n(l.bagWt) || undefined,
        convPct: n(l.convPct) || undefined,
        convRate: n(l.convRate) || undefined,
        itDesc: l.itDesc || undefined,
        lbrPct: n(l.lbrPct) || undefined,
        lesWt: n(l.lesWt) || undefined,
        lessTouch: n(l.lessTouch) || undefined,
        lossWt: n(l.lossWt) || undefined,
        lotNo: l.lotNo || undefined,
        mrp: n(l.mrp) || undefined,
        oldSrNo: n(l.oldSrNo) || undefined,
        otherFine: n(l.otherFine) || undefined,
        otherRate: n(l.otherRate) || undefined,
        kundanWt: n(l.kundanWt) || undefined,
        kundanTouch: n(l.kundanTouch) || undefined,
        kunFine: n(l.kunFine) || undefined,
        silverFine: n(l.silverFine) || undefined,
        ghtPct: n(l.ghtPct) || undefined,
        urdRateType: l.urdRateType || undefined,
        commissionPct: n(l.commissionPct) || undefined,
        commissionAmount: n(l.commissionAmount) || undefined,
        rate: n(l.rate) || undefined,
        rateType: l.rateType || undefined,
        tagNo: l.tagNo || undefined,
        totalAmount: n(l.totalAmount) || undefined,
        withStock: l.withStock || undefined,

        pcs: n(l.pcs),
        grossWt: n(l.grossWt),
        othWt: n(l.othWt),
        netWt: n(l.netWt),
        ghtWt: n(l.ghtWt),
        touch: n(l.touch),
        lbrType: l.lbrType || undefined,
        lbrRate: n(l.lbrRate),
        // P1-3: wastage applies to BOTH modes. `finePolicy.ts` adds westPct to touch for
        // karigarIssue as well as karigarReceipt, so gating it on receive silently discarded the
        // operator's wastage percentage on every issue voucher.
        westPct: n(l.westPct),
        // P1-2: send a labour amount ONLY when the operator typed one.
        //
        // `mfg.ts:448-451` and the karigar writer treat any supplied `lbrAmt` as an OVERRIDE of
        // the derived figure. Sending `n(l.lbrAmt)` — which is 0 for an untouched field — meant
        // `lbrType` and `lbrRate` could never take effect, so the desktop's typed labour
        // derivation (TR_KR_ISU.cs:4025-4129: per piece, per gross, or per net+ghat) was dead
        // code reachable only by API clients.
        ...(l.lbrAmt.trim() === '' ? {} : { lbrAmt: n(l.lbrAmt) }),
        ...(rcv ? { othAmt: n(l.othAmt), tag: l.tag } : {}),
      });

      /**
       * Job-work posts MFG_DATA/MFG_DETL through `issueMfg`/`receiveMfg`, whose `MfgLine` is a different
       * shape from `KarigarLine`. Only the fields MfgLine declares are sent, so nothing is silently dropped
       * by name mismatch: the KR-only grid columns (convRate, convPct, lessTouch, lossWt, withStock, lbrPct,
       * lesWt, mrp, totalAmount, otherRate, otherFine, oldSrNo, bagWt, rate, amount, tblCode, itDesc,
       * itmSize) have no MFG_DETL counterpart and are deliberately omitted rather than ignored server-side.
       */
      const jobworkLine = (l: Line, sourceIndex: number) => ({
        components: sub.componentsFor(sourceIndex),
        itCode: l.itCode || undefined,
        designNo: l.designNo || undefined,
        lotNo: l.lotNo || undefined,
        tagNo: l.tagNo || undefined,
        size: l.itmSize || undefined,
        itemRemark: l.itDesc || undefined,
        rateType: l.rateType || undefined,

        pcs: n(l.pcs),
        grossWt: n(l.grossWt),
        othWt: n(l.othWt),
        netWt: n(l.netWt),
        ghtWt: n(l.ghtWt),
        touch: n(l.touch),
        lbrType: l.lbrType || undefined,
        lbrRate: n(l.lbrRate),
        itRate: n(l.rate) || undefined,
        itAmt: n(l.amount) || undefined,
        krName: karigarName || undefined,
        // P1-3 / P1-2, same two defects on the job-work payload. `mfg.ts:lineFine` adds westPct to
        // touch regardless of direction, and `mfg.ts:448-451` treats a supplied lbrAmt as an
        // override — so gating westPct on receive lost wastage, and always sending lbrAmt made
        // MfgLine.lbrType/lbrRate unreachable.
        westPct: n(l.westPct),
        ...(l.lbrAmt.trim() === '' ? {} : { lbrAmt: n(l.lbrAmt) }),
        ...(rcv ? { othAmt: n(l.othAmt) } : { totalNetWt: n(l.netWt) || undefined }),
      });

      const body: any = {
        coBook,
        billOutstanding: billOutstanding.trim() ? n(billOutstanding) : undefined,
        karigarAc,
        karigarName: karigarName || undefined,
        lines: lines
          // Carry the original index through the filter: empty lines are dropped, so a filtered
          // position would attach a stone block to a different ornament.
          .map((l, sourceIndex) => ({ l, sourceIndex }))
          .filter(({ l }) => l.netWt)
          .map(({ l, sourceIndex }) =>
            family === 'jobwork' ? jobworkLine(l, sourceIndex) : karigarLine(l, sourceIndex),
          ),
      };
      if (rcv) {
        if (showLabourTax) {
          body.labourGstPct = n(labourGstPct);
          body.interState = interState;
        }
        if (oldItemSales && partyFine.trim()) body.partyFine = n(partyFine);
      }
      const r =
        lifecycle && loadedVch
          ? await put(`${ep}/${encodeURIComponent(loadedVch)}`, body)
          : await post(ep, body);
      setRes(r);
      setLines([blank()]);
      checkBalance();
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>{title}</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} mainBooks={bookFamilies} />
            </div>
            <div className="field">
              <label>Bill Outstanding</label>
              <input value={billOutstanding} onChange={(e) => setBillOutstanding(e.target.value)} />
            </div>
            <div className="field">
              <label>Karigar</label>
              <LookupPicker
                entity="accounts"
                value={karigarAc}
                onChange={(v) => {
                  setKarigarAc(v);
                }}
                onPick={(row) => {
                  if (row?.name) setKarigarName(String(row.name));
                  checkBalance(String(row.code));
                }}
              />
            </div>
            <div className="field">
              <label>Name</label>
              <input value={karigarName} onChange={(e) => setKarigarName(e.target.value)} />
            </div>
            {oldItemSales && (
              <div className="field">
                <label>Party Fine</label>
                <input
                  value={partyFine}
                  onChange={(e) => setPartyFine(e.target.value)}
                  style={{ width: 80, textAlign: 'right' }}
                />
              </div>
            )}
            {showLabourTax && (
              <div className="field">
                <label>Labour GST %</label>
                <input
                  value={labourGstPct}
                  onChange={(e) => setLabourGstPct(e.target.value)}
                  style={{ width: 60 }}
                />
              </div>
            )}
            {showLabourTax && (
              <div className="field">
                <label>Inter-state</label>
                <select
                  value={interState ? 'y' : 'n'}
                  onChange={(e) => setInterState(e.target.value === 'y')}
                >
                  <option value="n">No</option>
                  <option value="y">Yes</option>
                </select>
              </div>
            )}
            <div className="field" style={{ justifyContent: 'flex-end' }}>
              <button type="button" className="ghost" onClick={() => checkBalance()}>
                Check balance
              </button>
            </div>
          </div>
          {bal !== null && (
            <div className="msg">
              Metal balance for {karigarAc}: <b>{bal} fine</b>{' '}
              {bal > 0 ? '(karigar owes us)' : bal < 0 ? '(we owe karigar)' : '(settled)'}
            </div>
          )}
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Metal Lines</h2>
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Item</th>
                <th>Design</th>
                <th>Ctr</th>
                <th>Size</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Oth Wt</th>
                <th className="num">Net Wt</th>
                <th className="num">Ght Wt</th>
                <th className="num">Touch%</th>
                {rcv && <th className="num">West%</th>}
                <th className="num">Fine</th>
                {rcv && (
                  <>
                    <th>LType</th>
                    <th className="num">LRate</th>
                    <th className="num">Lbr Amt</th>
                    <th className="num">Oth Amt</th>
                    {!oldItemSales && <th>Tag</th>}
                  </>
                )}
                <th></th>
              </tr>
            </thead>
            <tbody>
              {lines.map((l, i) => (
                <tr key={i}>
                  <td>
                    <LookupPicker
                      entity="items"
                      value={l.itCode}
                      onChange={(v) => setLine(i, 'itCode', v)}
                      style={{ width: 74 }}
                    />
                  </td>
                  <td>
                    <input
                      value={l.designNo}
                      onChange={(e) => setLine(i, 'designNo', e.target.value)}
                      style={{ width: 60 }}
                    />
                  </td>
                  <td>
                    <input
                      value={l.tblCode}
                      onChange={(e) => setLine(i, 'tblCode', e.target.value)}
                      style={{ width: 36 }}
                    />
                  </td>
                  <td>
                    <input
                      value={l.itmSize}
                      onChange={(e) => setLine(i, 'itmSize', e.target.value)}
                      style={{ width: 44 }}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 38, textAlign: 'right' }}
                      value={l.pcs}
                      onChange={(e) => setLine(i, 'pcs', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 56, textAlign: 'right' }}
                      value={l.grossWt}
                      onChange={(e) => setLine(i, 'grossWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 50, textAlign: 'right' }}
                      value={l.othWt}
                      onChange={(e) => setLine(i, 'othWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 56, textAlign: 'right' }}
                      value={l.netWt}
                      onChange={(e) => setLine(i, 'netWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 50, textAlign: 'right' }}
                      value={l.ghtWt}
                      onChange={(e) => setLine(i, 'ghtWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 50, textAlign: 'right' }}
                      value={l.touch}
                      onChange={(e) => setLine(i, 'touch', e.target.value)}
                    />
                  </td>
                  {rcv && (
                    <td className="num">
                      <input
                        style={{ width: 46, textAlign: 'right' }}
                        value={l.westPct}
                        onChange={(e) => setLine(i, 'westPct', e.target.value)}
                      />
                    </td>
                  )}
                  <td className="num">{fine(l).toLocaleString('en-IN')}</td>
                  {rcv && (
                    <>
                      <td>
                        <select
                          value={l.lbrType}
                          onChange={(e) => setLine(i, 'lbrType', e.target.value)}
                          style={{ width: 48 }}
                        >
                          <option value="G">/g</option>
                          <option value="P">/pc</option>
                          <option value="N">Fix</option>
                          <option value="%">%</option>
                        </select>
                      </td>
                      <td className="num">
                        <input
                          style={{ width: 52, textAlign: 'right' }}
                          value={l.lbrRate}
                          onChange={(e) => setLine(i, 'lbrRate', e.target.value)}
                        />
                      </td>
                      <td className="num">
                        <input
                          style={{ width: 60, textAlign: 'right' }}
                          value={l.lbrAmt}
                          onChange={(e) => setLine(i, 'lbrAmt', e.target.value)}
                        />
                      </td>
                      <td className="num">
                        <input
                          style={{ width: 54, textAlign: 'right' }}
                          value={l.othAmt}
                          onChange={(e) => setLine(i, 'othAmt', e.target.value)}
                        />
                      </td>
                      {!oldItemSales && (
                        <td style={{ textAlign: 'center' }}>
                          <input
                            type="checkbox"
                            checked={l.tag}
                            onChange={(e) => setLine(i, 'tag', e.target.checked)}
                            title="tag into barcoded stock"
                          />
                        </td>
                      )}
                    </>
                  )}
                  <td>
                    <button
                      type="button"
                      className="danger"
                      onClick={() =>
                        setLines((ls) => (ls.length > 1 ? ls.filter((_, j) => j !== i) : [blank()]))
                      }
                    >
                      ×
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          {/* Desktop shows the sub-rows of the selected parent only (RowColChange). A selector
              stands in for MSFlexGrid's current-row notion. */}
          <div className="row" style={{ marginTop: 8, alignItems: 'flex-end' }}>
            <div className="field">
              <label>{family === 'jobwork' ? 'Components for line' : 'Stones for line'}</label>
              <select
                value={sub.activeLine}
                onChange={(e) => sub.setActiveLine(Number(e.target.value))}
              >
                {lines.map((l, i) => (
                  <option key={i} value={i}>
                    {i + 1}
                    {l.itCode ? ` — ${l.itCode}` : ''}
                    {l.tagNo ? ` / ${l.tagNo}` : ''}
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
            onRowsChange={(rows) => sub.setRowsFor(sub.activeLine, rows)}
            columns={family === 'jobwork' ? SUB_DETAIL_COMPONENT : undefined}
            parentLabel={`line ${sub.activeLine + 1}`}
            desktopSource={
              family === 'jobwork'
                ? 'TR_JDT_REC / MSG_IDTL (16 cols)'
                : 'TR_KR_ISU + TR_MFG_KR_ISU_REC / MSG_IDTL (24 cols)'
            }
          />
          {lines.map((line, index) => (
            <details key={`kr-line-extra-${index}`} style={{ marginTop: 8 }}>
              <summary>Row {index + 1} desktop fields</summary>
              <div className="row">
                {extendedKarigarFields.map(([key, label]) => (
                  <div className="field" key={String(key)}>
                    <label>{label}</label>
                    <input
                      value={String(line[key] ?? '')}
                      onChange={(e) => setLine(index, key, e.target.value)}
                    />
                  </div>
                ))}
              </div>
            </details>
          ))}
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
              Fine <b>{totFine}</b>
              {showLabourTax
                ? ` · Labour ₹${totLabour.toLocaleString('en-IN')} · GST ₹${totGst.toLocaleString('en-IN')}`
                : oldItemSales
                  ? ` · Party fine ${partyFine || totFine}`
                  : ''}
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Saving…' : lifecycle && loadedVch ? `Update #${loadedVch}` : 'Save'}
            </button>
            {lifecycle && loadedVch && (
              <button type="button" className="ghost" onClick={resetForm} disabled={busy}>
                New
              </button>
            )}
          </div>
        </div>
      </form>
      {lifecycle && (
        <VoucherList
          table={lifecycleTable}
          book={coBook}
          deleteBase={ep}
          onLoad={(vchNo) => loadVoucher(vchNo)}
        />
      )}
      {err && <div className="msg err">{err}</div>}
      {res && (
        <div className="panel">
          <div className="msg ok">
            Saved — Voucher #{res.vchNo} · fine {res.fineIssued ?? res.fineReceived}
            {res.labourAmt
              ? ` · labour ₹${res.labourAmt}` + (res.labourGst ? ` + GST ₹${res.labourGst}` : '')
              : ''}
          </div>
          {!rcv && family === 'karigar' && (
            <div className="toolbar" style={{ marginTop: 6 }}>
              <button
                type="button"
                className="ghost"
                onClick={() =>
                  window.open(
                    `/api/karigar/issue-voucher?coBook=${encodeURIComponent(coBook)}&vchNo=${encodeURIComponent(String(res.vchNo))}&format=html`,
                    '_blank',
                  )
                }
              >
                View Issue Voucher
              </button>
            </div>
          )}
          {res.tagNos?.length ? (
            <div className="muted" style={{ marginTop: 6 }}>
              Generated barcodes: <code>{res.tagNos.join(', ')}</code>
            </div>
          ) : null}
        </div>
      )}
      <EntityImagePanel
        entityType="TAG"
        entityKey={lines[imageRow]?.tagNo ?? ''}
        instance={imageRow + 1}
        label="Tag image"
        testId="karigar-image"
      />
    </div>
  );
}
