'use client';
import { useState } from 'react';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { BookSelect } from '../../../../components/BookSelect';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { LookupPicker } from '../../../../components/LookupPicker';
import { VoucherList } from '../../../../components/VoucherList';
import { companyFlag, useCompanySettings } from '../../../../lib/companySettings';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import SubDetailGrid, { stoneRowFromApi, useSubDetail } from '../../../../components/SubDetailGrid';
import { fineFor, labourCharge } from '@datacare/core';
import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';
import { openDocument } from '../../../../lib/openDocument';

/** Hallmark Purchase (TR_PURC_HM) — buy items capturing HUID + a hallmarking charge & its input GST.
 *
 *  The desktop opens TR_PURC_HM from "Tag Wise Purc" on a TAG PURCHASE book (MDI_FORM.cs:8540-8541) and
 *  from "Purchase" on a PURCHASE book when the company buys with hallmark tax (MDI_FORM.cs:7865-7866), and
 *  posts both through the purchase routines (TR_PURC_HM.cs:8426-8441). The page therefore selects a
 *  configured PURCHASE or TAG PURCHASE book and uses the purchase lifecycle (/purchases) to save, reopen,
 *  edit, delete and print. It used to send no book, so every save was refused.
 */
interface Row {
  itCode: string;
  tagNo: string;
  huid: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  making: string;
  ghtWt: string;
  westPct: string;
  lesTouch: string;
  kunFine: string;
  fineWt: string;
  metalAmount: string;
  labourPct: string;
  labourFixed: string;
  labourAmount: string;
  otherAmount: string;
  metal: string;
  otherFineWt: string;
  silverFineWt: string;
  itDesc: string;
  tblCode: string;
  designNo: string;
  lotNo: string;
  itmLot: string;
  withStock: string;
  bagWt: string;
  lossWt: string;
  lessWt: string;
  ghtPct: string;
  lessTouch: string;
  convRate: string;
  convPct: string;
  rateType: string;
  urdRateType: string;
  otherRate: string;
  mrp: string;
  commissionPct: string;
  commissionAmount: string;
  fineCutPcs: string;
  fineCutGrossWt: string;
  fineCutNetWt: string;
  fineCutFine: string;
  prCode: string;
}
/**
 * P7 extended grid columns: desktop columns this form has and the web did not.
 *
 * Every entry was verified against the WRITER, not the API interface — a field present on the
 * interface is not necessarily persisted (purchase hard-codes ITM_SIZE to blank, and five
 * SaleLineInput fields have no SL_DETL column at all), and such a cell would silently discard
 * what the operator types.
 */
const extendedLineFields: Array<[keyof Row, string]> = [
  ['ghtWt', 'GhtWt'],
  ['westPct', 'West%'],
  ['lesTouch', 'LesTouch'],
  ['kunFine', 'KunFine'],
  ['fineWt', 'Fine'],
  ['metalAmount', 'ItAmt'],
  ['labourPct', 'Lbr%'],
  ['labourFixed', 'LbrFix'],
  ['labourAmount', 'LbrAmt'],
  ['otherAmount', 'OthAmt'],
  ['metal', 'Metal'],
  ['otherFineWt', 'OFine'],
  ['silverFineWt', 'SlvFine'],
  ['itDesc', 'ItDesc'],
  ['tblCode', 'Counter'],
  ['designNo', 'Design'],
  ['lotNo', 'LotNo'],
  ['itmLot', 'ItmLot'],
  ['withStock', 'WithStk'],
  ['bagWt', 'BagWt'],
  ['lossWt', 'LossWt'],
  ['lessWt', 'LessWt'],
  ['ghtPct', 'Ght%'],
  ['lessTouch', 'LTouch'],
  ['convRate', 'ConRate'],
  ['convPct', 'Con%'],
  ['rateType', 'RateType'],
  ['urdRateType', 'UrdRtType'],
  ['otherRate', 'ORate'],
  ['mrp', 'Mrp'],
  ['commissionPct', 'Com%'],
  ['commissionAmount', 'ComAmt'],
  ['fineCutPcs', 'FcPcs'],
  ['fineCutGrossWt', 'FcGwt'],
  ['fineCutNetWt', 'FcNwt'],
  ['fineCutFine', 'FcFine'],
  ['prCode', 'PrCost'],
];

/** Fields the API takes as numbers; everything else stays a string so codes are not mangled. */
const NUMERIC_EXTENDED = new Set<string>([
  'ghtWt',
  'westPct',
  'lesTouch',
  'kunFine',
  'fineWt',
  'metalAmount',
  'labourPct',
  'labourAmount',
  'otherAmount',
  'otherFineWt',
  'silverFineWt',
  'bagWt',
  'lossWt',
  'lessWt',
  'ghtPct',
  'lessTouch',
  'convRate',
  'convPct',
  'otherRate',
  'commissionPct',
  'commissionAmount',
  'fineCutPcs',
  'fineCutGrossWt',
  'fineCutNetWt',
  'fineCutFine',
]);

const blank = (): Row => ({
  itCode: '',
  tagNo: '',
  huid: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  making: '',
  ghtWt: '',
  westPct: '',
  lesTouch: '',
  kunFine: '',
  fineWt: '',
  metalAmount: '',
  labourPct: '',
  labourFixed: '',
  labourAmount: '',
  otherAmount: '',
  metal: '',
  otherFineWt: '',
  silverFineWt: '',
  itDesc: '',
  tblCode: '',
  designNo: '',
  lotNo: '',
  itmLot: '',
  withStock: '',
  bagWt: '',
  lossWt: '',
  lessWt: '',
  ghtPct: '',
  lessTouch: '',
  convRate: '',
  convPct: '',
  rateType: '',
  urdRateType: '',
  otherRate: '',
  mrp: '',
  commissionPct: '',
  commissionAmount: '',
  fineCutPcs: '',
  fineCutGrossWt: '',
  fineCutNetWt: '',
  fineCutFine: '',
  prCode: '',
});
const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;
/** A saved zero is shown as an empty cell, as the entry grid does. */
const str = (v: unknown) => (v == null || Number(v) === 0 ? '' : String(v));
const HALLMARK_PURCHASE_BOOKS = ['PURCHASE', 'TAG PURCHASE'];

export default function HallmarkPurchasePage() {
  const { lcCode, coYear } = useBusinessScope();
  const companySettings = useCompanySettings();
  // Desktop MsLbrWithGht: per-gram labour is on (net + ghat) unless the company sets LBR_WITH_GHT='N'.
  const labourWithGhat = companyFlag(companySettings, 'LBR_WITH_GHT', 'Y');
  const [coBook, setCoBook] = useState('');
  const [voucherLookup, setVoucherLookup] = useState('');
  const [loadedVchNo, setLoadedVchNo] = useState('');
  const [f, setF] = useState({
    acCode: '',
    acName: '',
    billNo: '',
    taxRatePct: '3',
    interState: false,
    hmCharge: '',
  });
  const [rows, setRows] = useState<Row[]>([blank()]);
  const [fullGrid, setFullGrid] = useState(false);
  // Desktop TR_PURC_HM hangs a 23-column MSG_PR_IDTL row set under each line; the purchase
  // API already persists `stones` and this page sent nothing.
  const sub = useSubDetail(rows.length);
  // Desktop grids are keyboard-driven: arrows move between cells, Enter advances and
  // appends a row at the end, Ctrl/Cmd+D removes one (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: rows.length,
    onAppendRow: () => {
      setRows((rows) => [...rows, blank()]);
      sub.appendLine();
    },
    onRemoveRow: (row) => {
      setRows((rows) => (rows.length === 1 ? [blank()] : rows.filter((_, index) => index !== row)));
      sub.removeLine(row);
      return true;
    },
    onEscape: () => {},
  });
  const [res, setRes] = useState<any>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const set = (k: keyof typeof f, v: string | boolean) => setF((x) => ({ ...x, [k]: v }));
  const setRow = (i: number, k: keyof Row, v: string) =>
    setRows((rs) => rs.map((r, j) => (j === i ? { ...r, [k]: v } : r)));

  const calc = (r: Row) => {
    const fine = fineFor('purchaseItem', { netWt: n(r.netWt), touch: n(r.touch) });
    // Per-gram labour is (net + ghat) x rate unless the company switches ghat off (LBR_WITH_GHT='N').
    const labour = labourCharge('per_gram', {
      netWt: n(r.netWt),
      ghatWt: n(r.ghtWt),
      withGhat: labourWithGhat,
      rate: n(r.making),
    });
    return r2(fine * n(r.rate) + labour);
  };
  const taxable = r2(rows.reduce((s, r) => s + (r.itCode.trim() ? calc(r) : 0), 0));
  const hmAmt = n(f.hmCharge);
  const tax = r2(((taxable + hmAmt) * n(f.taxRatePct)) / 100);
  const grand = Math.round(taxable + hmAmt + tax);

  const scopeQuery = () =>
    `coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}`;
  const failure = (err: unknown) =>
    err instanceof ApiError
      ? err.body?.detail || err.body?.message || err.body?.error || 'failed'
      : 'failed';

  function newVoucher() {
    setLoadedVchNo('');
    setVoucherLookup('');
    setRes(null);
    setMsg(null);
    setF({ acCode: '', acName: '', billNo: '', taxRatePct: '3', interState: false, hmCharge: '' });
    setRows([blank()]);
    sub.reset();
  }

  async function loadVoucher() {
    if (!coBook || !voucherLookup.trim()) return;
    setBusy(true);
    setMsg(null);
    try {
      const view = await get<any>(
        `/purchases/${encodeURIComponent(voucherLookup.trim())}?${scopeQuery()}`,
      );
      setLoadedVchNo(String(view.voucherNo));
      setVoucherLookup(String(view.voucherNo));
      setF({
        acCode: String(view.acCode ?? ''),
        acName: String(view.acName ?? ''),
        billNo: String(view.billNo ?? ''),
        taxRatePct: str(view.taxRatePct) || '0',
        interState: !!view.interState,
        hmCharge: str(view.hmAmount),
      });
      const loaded: Row[] = (view.lines ?? []).map((line: any) => ({
        ...blank(),
        itCode: String(line.itCode ?? ''),
        tagNo: String(line.tagNo ?? ''),
        huid: String(line.huid ?? ''),
        pcs: str(line.pcs),
        grossWt: str(line.grossWt),
        netWt: str(line.netWt),
        touch: str(line.touch),
        rate: str(line.rate),
        making: line.labourType === 'per_gram' ? str(line.labourRate) : '',
        ghtWt: str(line.ghtWt),
        westPct: str(line.westPct),
        labourPct: str(line.labourPct),
        labourAmount: line.labourType === 'per_gram' ? '' : str(line.labourAmount),
        otherAmount: str(line.otherAmount),
        otherFineWt: str(line.otherFineWt),
        silverFineWt: str(line.silverFineWt),
        itDesc: String(line.itDesc ?? ''),
        tblCode: String(line.tblCode ?? ''),
        designNo: String(line.designNo ?? ''),
        bagWt: str(line.bagWt),
        lessWt: str(line.lessWt),
        mrp: str(line.mrp),
        otherRate: str(line.otherRate),
        commissionPct: str(line.commissionPct),
      }));
      setRows(loaded.length ? loaded : [blank()]);
      // Reload the stones too, or an unchanged save would post none and delete them.
      sub.load(
        (view.lines ?? []).map((line: any) =>
          (line.stones ?? []).map((stone: any) => stoneRowFromApi(stone)),
        ),
      );
      setMsg({ kind: 'ok', text: `Loaded voucher #${view.voucherNo}` });
    } catch (err) {
      setMsg({ kind: 'err', text: failure(err) });
    } finally {
      setBusy(false);
    }
  }

  async function deleteVoucher() {
    if (!loadedVchNo || !window.confirm(`Delete voucher ${loadedVchNo}?`)) return;
    setBusy(true);
    setMsg(null);
    try {
      await del(`/purchases/${encodeURIComponent(loadedVchNo)}?${scopeQuery()}`);
      newVoucher();
      setMsg({ kind: 'ok', text: 'Voucher deleted' });
    } catch (err) {
      setMsg({ kind: 'err', text: failure(err) });
    } finally {
      setBusy(false);
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setRes(null);
    if (!coBook) {
      setMsg({ kind: 'err', text: 'select a configured purchase book' });
      return;
    }
    if (!f.acCode.trim()) {
      setMsg({ kind: 'err', text: 'supplier is required' });
      return;
    }
    const lines = rows
      // Original index carried through the filter so stones attach to the right line.
      .map((r, sourceIndex) => ({ r, sourceIndex }))
      .filter(({ r }) => r.itCode.trim())
      .map(({ r, sourceIndex }) => ({
        // P7: writer-verified extended columns. A blank cell is OMITTED, never sent as 0 — an
        // explicit zero is an override at the writer and defeats the server's own derivation.
        ...Object.fromEntries(
          extendedLineFields
            .map(([key]) => [
              key,
              String((r as unknown as Record<string, unknown>)[key] ?? '').trim(),
            ])
            .filter(([, v]) => v !== '')
            .map(([key, v]) => [key, NUMERIC_EXTENDED.has(key as string) ? Number(v) : v]),
        ),
        stones: sub.inputsFor(sourceIndex),
        itCode: r.itCode.trim(),
        tagNo: r.tagNo.trim() || undefined,
        huid: r.huid.trim() || undefined,
        pcs: n(r.pcs),
        grossWt: n(r.grossWt),
        netWt: n(r.netWt),
        touch: n(r.touch),
        rate: n(r.rate),
        ...(r.making ? { labourType: 'per_gram', labourRate: n(r.making) } : {}),
      }));
    if (!lines.length) {
      setMsg({ kind: 'err', text: 'enter at least one item' });
      return;
    }
    setBusy(true);
    try {
      const payload = {
        coBook,
        coYear,
        lcCode,
        acCode: f.acCode.trim(),
        acName: f.acName || undefined,
        billNo: f.billNo || undefined,
        taxRatePct: Number(f.taxRatePct || 0),
        interState: f.interState,
        hmAmount: hmAmt || undefined,
        lines,
      };
      const r = loadedVchNo
        ? await put<any>(`/purchases/${encodeURIComponent(loadedVchNo)}`, payload)
        : await post<any>('/purchases', payload);
      setRes(r);
      const savedNo = String(r.vchNo).padStart(5, '0');
      setLoadedVchNo(savedNo);
      setVoucherLookup(savedNo);
      setMsg({
        kind: 'ok',
        text: `Saved — voucher #${r.vchNo}, total ₹${Number(r.totals?.total ?? grand).toLocaleString('en-IN')}${hmAmt ? ` (+ HM ₹${hmAmt})` : ''}`,
      });
    } catch (err) {
      setMsg({ kind: 'err', text: failure(err) });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Hallmark Purchase <span className="muted">— TR_PURC_HM (HUID + hallmark charge)</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} mainBooks={HALLMARK_PURCHASE_BOOKS} />
            </div>
            <div className="field">
              <label>Voucher No</label>
              <input
                aria-label="Voucher No"
                value={voucherLookup}
                onChange={(e) => setVoucherLookup(e.target.value)}
                placeholder="00001"
              />
            </div>
            <button
              type="button"
              className="ghost"
              disabled={busy || !coBook}
              onClick={loadVoucher}
            >
              Load
            </button>
            {loadedVchNo && (
              <>
                <span className="msg ok" data-testid="purchase-hm-loaded">
                  Loaded #{loadedVchNo}
                </span>
                <button type="button" className="danger" disabled={busy} onClick={deleteVoucher}>
                  Delete
                </button>
                <button
                  type="button"
                  className="ghost"
                  onClick={() =>
                    openDocument(
                      `/api/purchases/invoice?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(loadedVchNo)}&format=html`,
                    )
                  }
                >
                  Print
                </button>
              </>
            )}
            <button type="button" className="ghost" disabled={busy} onClick={newVoucher}>
              New
            </button>
          </div>
          <div className="row">
            <div className="field" style={{ flex: 2 }}>
              <label>Supplier</label>
              <LookupPicker
                entity="accounts"
                value={f.acCode}
                onChange={(v) => set('acCode', v)}
                onPick={(r) => {
                  if (!f.acName) set('acName', String(r.name || ''));
                }}
              />
            </div>
            <div className="field">
              <label>Supplier Name</label>
              <input value={f.acName} onChange={(e) => set('acName', e.target.value)} />
            </div>
            <div className="field">
              <label>Bill No</label>
              <input value={f.billNo} onChange={(e) => set('billNo', e.target.value)} />
            </div>
            <div className="field">
              <label>Tax %</label>
              <input value={f.taxRatePct} onChange={(e) => set('taxRatePct', e.target.value)} />
            </div>
            <div className="field">
              <label>Hallmark chg ₹</label>
              <input value={f.hmCharge} onChange={(e) => set('hmCharge', e.target.value)} />
            </div>
            <div className="field">
              <label>Inter-state</label>
              <select
                value={f.interState ? 'y' : 'n'}
                onChange={(e) => set('interState', e.target.value === 'y')}
              >
                <option value="n">No (CGST+SGST)</option>
                <option value="y">Yes (IGST)</option>
              </select>
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Hallmarked Items</h2>
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedLineFields.length}
            testId="purchase-hm-grid-mode"
          />
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Item</th>
                <th>Tag</th>
                <th>HUID</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net</th>
                <th className="num">Touch</th>
                <th className="num">Rate</th>
                <th className="num">Making/g</th>
                <th className="num">Net Amt</th>
                <ExtendedHeaderCells full={fullGrid} fields={extendedLineFields} />
                <th></th>
              </tr>
            </thead>
            <tbody>
              {rows.map((r, i) => (
                <tr key={i}>
                  <td>
                    <LookupPicker
                      entity="items"
                      value={r.itCode}
                      onChange={(v) => setRow(i, 'itCode', v)}
                      style={{ width: 90 }}
                    />
                  </td>
                  <td>
                    <LookupPicker
                      entity="tags"
                      value={r.tagNo}
                      onChange={(v) => setRow(i, 'tagNo', v)}
                      style={{ width: 100 }}
                    />
                  </td>
                  <td>
                    <input
                      value={r.huid}
                      maxLength={6}
                      onChange={(e) => setRow(i, 'huid', e.target.value)}
                      placeholder="6-char"
                      style={{ width: 80 }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.pcs}
                      onChange={(e) => setRow(i, 'pcs', e.target.value)}
                      style={{ width: 48, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.grossWt}
                      onChange={(e) => setRow(i, 'grossWt', e.target.value)}
                      style={{ width: 70, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.netWt}
                      onChange={(e) => setRow(i, 'netWt', e.target.value)}
                      style={{ width: 70, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.touch}
                      onChange={(e) => setRow(i, 'touch', e.target.value)}
                      style={{ width: 56, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.rate}
                      onChange={(e) => setRow(i, 'rate', e.target.value)}
                      style={{ width: 76, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.making}
                      onChange={(e) => setRow(i, 'making', e.target.value)}
                      style={{ width: 64, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">{r.itCode.trim() ? calc(r).toLocaleString('en-IN') : ''}</td>
                  <ExtendedBodyCells
                    full={fullGrid}
                    fields={extendedLineFields}
                    line={r}
                    row={i}
                    baseColumns={10}
                    setValue={(row, key, value) => setRow(row, key, value)}
                  />
                  <td>
                    <button
                      type="button"
                      className="danger"
                      onClick={() => {
                        setRows((rs) => (rs.length > 1 ? rs.filter((_, j) => j !== i) : [blank()]));
                        sub.removeLine(i);
                      }}
                    >
                      ×
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td colSpan={9} style={{ textAlign: 'right', fontWeight: 600 }}>
                  Taxable {hmAmt ? `+ HM ${hmAmt}` : ''} / +tax / Total
                </td>
                <td className="num">
                  <b>{taxable.toLocaleString('en-IN')}</b> / {tax.toLocaleString('en-IN')} /{' '}
                  <b>{grand.toLocaleString('en-IN')}</b>
                </td>
                <td></td>
              </tr>
            </tfoot>
          </table>
          <div className="row" style={{ marginTop: 8, alignItems: 'flex-end' }}>
            <div className="field">
              <label>Stones for line</label>
              <select
                value={sub.activeLine}
                onChange={(e) => sub.setActiveLine(Number(e.target.value))}
              >
                {rows.map((r, i) => (
                  <option key={i} value={i}>
                    {i + 1}
                    {r.itCode ? ` — ${r.itCode}` : ''}
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
            desktopSource="TR_PURC_HM / MSG_PR_IDTL (23 cols)"
          />
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setRows((rs) => [...rs, blank()])}
            >
              + Add line
            </button>
            <span className="spacer" />
            <button className="primary" disabled={busy}>
              {busy
                ? 'Saving…'
                : loadedVchNo
                  ? 'Update Hallmark Purchase'
                  : 'Save Hallmark Purchase'}
            </button>
          </div>
          {res && (
            <div className="tiles" style={{ marginTop: 10 }}>
              <div className="tile">
                <div className="muted">voucher</div>
                <div className="big kpi">#{res.vchNo}</div>
              </div>
            </div>
          )}
        </div>
      </form>
      <VoucherList
        table="PR_DATA"
        book={coBook}
        deleteBase="/purchases"
        printHref={(v) =>
          `/api/purchases/invoice?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(v)}&format=html`
        }
        reloadKey={res?.vchNo}
      />
    </div>
  );
}
