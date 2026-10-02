'use client';
import { useState } from 'react';
import { get, post, put, del, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { companyFlag, useCompanySettings } from '../../../../lib/companySettings';
import { BookSelect } from '../../../../components/BookSelect';
import { VoucherList } from '../../../../components/VoucherList';
import {
  blankHallmarkLine as blank,
  fineFor,
  labourCharge,
  extendedLineFields,
  hallmarkHeaderFromView,
  hallmarkLineFromView,
  hallmarkOldGold,
  hallmarkSaleCommand,
  type HallmarkLine as Line,
  type LoadedHallmarkSale,
} from '@datacare/core';
import { LookupPicker } from '../../../../components/LookupPicker';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';

interface Totals {
  net: number;
  discount: number;
  taxable: number;
  tax: number;
  cgst: number;
  sgst: number;
  igst: number;
  roundOff: number;
  total: number;
}

const str = (v: unknown) => (v == null || Number(v) === 0 ? '' : String(v));
const n = (v: string) => Number(v || 0);
/** Editing one of these on a loaded line invalidates its loaded fine and metal amount. */
const DERIVATION_INPUT_KEYS = new Set<keyof Line>([
  'itCode',
  'pcs',
  'grossWt',
  'netWt',
  'lessWt',
  'touch',
  'ghtWt',
  'ghtPct',
  'westPct',
  'rate',
  'rateWith',
  'rateType',
]);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

export default function HallmarkSalePage() {
  // G11: per-gram labour is on (net + ghat) unless the company sets LBR_WITH_GHT='N' (blank default Y).
  const companySettings = useCompanySettings();
  const labourWithGhat = companyFlag(companySettings, 'LBR_WITH_GHT', 'Y');
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [acCode, setAcCode] = useState('WALKIN');
  const [acName, setAcName] = useState('');
  const [taxRatePct, setTaxRatePct] = useState('3');
  const [discountAmount, setDiscountAmount] = useState('');
  const [interState, setInterState] = useState(false);
  const [hmCharge, setHmCharge] = useState('');
  const [cashAmt, setCashAmt] = useState('');
  const [cardAmt, setCardAmt] = useState('');
  const [upiAmt, setUpiAmt] = useState('');
  const [chequeAmt, setChequeAmt] = useState('');
  const [oldGoldNet, setOldGoldNet] = useState('');
  const [oldGoldTouch, setOldGoldTouch] = useState('');
  const [oldGoldRate, setOldGoldRate] = useState('');
  // Reopen/edit/delete lifecycle (G10): a hallmark sale is a SL_DATA sale, so it uses the shared
  // /sales/:vchNo read, update and delete routes just like the ordinary sales screen.
  const [voucherLookup, setVoucherLookup] = useState('');
  const [loadedVchNo, setLoadedVchNo] = useState('');
  // Everything GET /sales/:vchNo returned, so an edit sends back what it does not display (G45).
  const [loaded, setLoaded] = useState<LoadedHallmarkSale | undefined>(undefined);
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [fullGrid, setFullGrid] = useState(false);
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
  const [result, setResult] = useState<{ vchNo: number; totals: Totals } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) =>
      ls.map((l, j) => {
        if (j !== i) return l;
        const next = { ...l, [k]: v };
        // A loaded fine or metal amount is the server's derivation from the loaded inputs. Once an input
        // changes, show it blank (the server derives it again) unless the operator overrides it.
        if (l.loaded && DERIVATION_INPUT_KEYS.has(k)) {
          for (const derived of ['fineWt', 'metalAmount'] as const)
            if (next[derived] === l.loaded.editor[derived]) next[derived] = '';
        }
        return next;
      }),
    );

  // live line preview: fine = net×touch/100, metal = fine×rate, making = net×making/g, net = metal+making
  const calc = (l: Line) => {
    const fine = fineFor('sale', {
      netWt: n(l.netWt),
      touch: n(l.touch),
      ghtWt: n(l.ghtWt),
      westPct: n(l.westPct),
    });
    const metal = r2(fine * n(l.rate));
    // P5/P7: this page now carries ghat, and per-gram labour is (net + ghat) x rate unless the
    // company switches ghat off (LBR_WITH_GHT, blank default 'Y'). The structural guard in
    // derivedValueSources.test.ts caught this the moment ghtWt was added to the grid.
    const mk = labourCharge('per_gram', {
      netWt: n(l.netWt),
      ghatWt: n(l.ghtWt),
      withGhat: labourWithGhat,
      rate: n(l.making),
    });
    return { fine, metal, mk, net: r2(metal + mk) };
  };
  const lineNet = lines.reduce((s, l) => s + calc(l).net, 0);
  const taxable = r2(lineNet - n(discountAmount));
  const taxPrev = r2((taxable * n(taxRatePct)) / 100);
  const totalPrev = Math.round(taxable + taxPrev);
  const hmAmt = n(hmCharge);
  const hmTax = r2((hmAmt * n(taxRatePct)) / 100);
  const grandTotalPrev = r2(totalPrev + hmAmt + hmTax);
  const oldGoldVal = hallmarkOldGold.value(oldGoldNet, oldGoldTouch, oldGoldRate); // G83
  const paid = r2(n(cashAmt) + n(cardAmt) + n(upiAmt) + n(chequeAmt) + oldGoldVal);
  const balanceDue = r2(grandTotalPrev - paid);

  function resetForm() {
    setLoadedVchNo('');
    setLoaded(undefined);
    setVoucherLookup('');
    setResult(null);
    setErr('');
    setAcCode('WALKIN');
    setAcName('');
    setDiscountAmount('');
    setHmCharge('');
    setCashAmt('');
    setCardAmt('');
    setUpiAmt('');
    setChequeAmt('');
    setOldGoldNet('');
    setOldGoldTouch('');
    setOldGoldRate('');
    setLines([blank()]);
  }

  async function loadSale(vchOverride?: string) {
    if (!coBook) {
      setErr('select the hallmark sale book first');
      return;
    }
    const lookup = (vchOverride ?? voucherLookup).trim();
    if (!lookup) return;
    setBusy(true);
    setErr('');
    try {
      const view = await get<any>(
        `/sales/${encodeURIComponent(lookup)}?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}`,
      );
      setLoadedVchNo(String(view.voucherNo));
      setVoucherLookup(String(view.voucherNo));
      setResult(null);
      const header = hallmarkHeaderFromView(view);
      const oldGold = hallmarkOldGold.fromView(view);
      setAcCode(header.acCode);
      setAcName(header.acName);
      setTaxRatePct(header.taxRatePct);
      setDiscountAmount(header.discountAmount);
      setInterState(header.interState);
      setHmCharge(header.hallmarkAmount);
      setCashAmt(header.cashAmt);
      setCardAmt(header.cardAmt);
      setUpiAmt(header.upiAmt);
      setChequeAmt(header.chequeAmt);
      setOldGoldNet(oldGold.netWt);
      setOldGoldTouch(oldGold.touch);
      setOldGoldRate(oldGold.rate);
      setLoaded({ view, header, oldGold });
      const loadedLines: Line[] = (view.lines ?? []).map(hallmarkLineFromView);
      setLines(loadedLines.length ? loadedLines : [blank()]);
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'load failed');
    } finally {
      setBusy(false);
    }
  }

  async function removeLoadedSale() {
    if (!loadedVchNo || !window.confirm(`Delete hallmark sale ${loadedVchNo}?`)) return;
    setBusy(true);
    setErr('');
    try {
      await del(
        `/sales/${encodeURIComponent(loadedVchNo)}?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}`,
      );
      resetForm();
    } catch (e) {
      setErr(
        e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'delete failed',
      );
    } finally {
      setBusy(false);
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const body = hallmarkSaleCommand({
        scope: { coBook, coYear, lcCode },
        header: {
          acCode,
          acName,
          taxRatePct,
          discountAmount,
          interState,
          hallmarkAmount: hmCharge,
          cashAmt,
          cardAmt,
          upiAmt,
          chequeAmt,
        },
        oldGold: { netWt: oldGoldNet, touch: oldGoldTouch, rate: oldGoldRate },
        lines,
        loaded: loadedVchNo ? loaded : undefined,
      });
      if (loadedVchNo) {
        const updated = await put<any>(`/sales/${encodeURIComponent(loadedVchNo)}`, body);
        setLoadedVchNo(String(updated.vchNo));
        setResult(updated);
      } else {
        const created = await post<any>('/sales', body);
        setLoadedVchNo(String(created.vchNo));
        setResult(created);
      }
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Hallmark Sale <span className="muted">(HUID)</span>
      </h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="HM" />
            </div>
            <div className="field">
              <label>Voucher</label>
              <div style={{ display: 'flex', gap: 4 }}>
                <input
                  aria-label="Hallmark sale voucher"
                  value={voucherLookup}
                  onChange={(e) => setVoucherLookup(e.target.value)}
                  placeholder="00001"
                  style={{ width: 90 }}
                />
                <button type="button" className="ghost" disabled={busy} onClick={() => loadSale()}>
                  Load
                </button>
                <button type="button" className="ghost" disabled={busy} onClick={resetForm}>
                  New
                </button>
                {loadedVchNo && (
                  <button
                    type="button"
                    className="danger"
                    disabled={busy}
                    onClick={removeLoadedSale}
                  >
                    Delete
                  </button>
                )}
              </div>
              {loadedVchNo && <span className="muted">Editing #{loadedVchNo}</span>}
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
              <label>Party (AC_CODE)</label>
              <LookupPicker
                entity="accounts"
                value={acCode}
                onChange={setAcCode}
                onPick={(r) => {
                  setAcName(String(r.name || ''));
                  if (r.AC_GST_TYPE) setInterState(String(r.AC_GST_TYPE) !== 'L');
                }}
              />
            </div>
            <div className="field">
              <label>Customer Name</label>
              <input value={acName} onChange={(e) => setAcName(e.target.value)} />
            </div>
            <div className="field">
              <label>Tax %</label>
              <input value={taxRatePct} onChange={(e) => setTaxRatePct(e.target.value)} />
            </div>
            <div className="field">
              <label>Discount ₹</label>
              <input value={discountAmount} onChange={(e) => setDiscountAmount(e.target.value)} />
            </div>
            <div className="field">
              <label>Hallmark chg ₹</label>
              <input value={hmCharge} onChange={(e) => setHmCharge(e.target.value)} />
            </div>
            <div className="field">
              <label>Inter-state</label>
              <select
                value={interState ? 'y' : 'n'}
                onChange={(e) => setInterState(e.target.value === 'y')}
              >
                <option value="n">No (CGST+SGST)</option>
                <option value="y">Yes (IGST)</option>
              </select>
            </div>
          </div>
        </div>

        <div className="panel">
          <h2>Settlement</h2>
          <div className="row">
            <div className="field">
              <label>Cash ₹</label>
              <input value={cashAmt} onChange={(e) => setCashAmt(e.target.value)} />
            </div>
            <div className="field">
              <label>Card ₹</label>
              <input value={cardAmt} onChange={(e) => setCardAmt(e.target.value)} />
            </div>
            <div className="field">
              <label>UPI ₹</label>
              <input value={upiAmt} onChange={(e) => setUpiAmt(e.target.value)} />
            </div>
            <div className="field">
              <label>Cheque ₹</label>
              <input value={chequeAmt} onChange={(e) => setChequeAmt(e.target.value)} />
            </div>
            <div className="field">
              <label>Old Gold Net</label>
              <input value={oldGoldNet} onChange={(e) => setOldGoldNet(e.target.value)} />
            </div>
            <div className="field">
              <label>Old Gold Touch%</label>
              <input value={oldGoldTouch} onChange={(e) => setOldGoldTouch(e.target.value)} />
            </div>
            <div className="field">
              <label>Old Gold Rate</label>
              <input value={oldGoldRate} onChange={(e) => setOldGoldRate(e.target.value)} />
            </div>
          </div>
          <div className="muted" style={{ marginTop: 6 }}>
            Old gold ₹{oldGoldVal.toLocaleString('en-IN')} · Paid ₹{paid.toLocaleString('en-IN')} ·{' '}
            <b style={{ color: balanceDue > 0 ? 'var(--err)' : 'var(--ok)' }}>
              Balance due ₹{balanceDue.toLocaleString('en-IN')}
            </b>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Hallmarked Items</h2>
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedLineFields.length}
            testId="hallmark-sale-grid-mode"
          />
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Item</th>
                <th>Tag</th>
                <th>HUID</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch%</th>
                <th className="num">Rate</th>
                <th className="num">Making/g</th>
                <th className="num">Fine</th>
                <th className="num">Amount</th>
                <ExtendedHeaderCells full={fullGrid} fields={extendedLineFields} />
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
                        style={{ width: 80 }}
                      />
                    </td>
                    <td>
                      <LookupPicker
                        entity="tags"
                        value={l.tagNo}
                        onChange={(v) => setLine(i, 'tagNo', v)}
                        style={{ width: 110 }}
                        onPick={(r) =>
                          setLines((ls) =>
                            ls.map((x, j) =>
                              j === i
                                ? {
                                    ...x,
                                    tagNo: String(r.code),
                                    itCode: String(r.name || x.itCode),
                                    netWt: String(r.ITM_NWT ?? x.netWt),
                                    grossWt: String(r.ITM_GWT ?? x.grossWt),
                                    touch: String(r.ITM_TOUCH ?? x.touch),
                                    rate: String(r.ITM_RATE ?? x.rate),
                                  }
                                : x,
                            ),
                          )
                        }
                      />
                    </td>
                    <td>
                      <input
                        style={{ width: 110 }}
                        value={l.huid}
                        onChange={(e) => setLine(i, 'huid', e.target.value)}
                        placeholder="6-char HUID"
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
                    <td className="num">
                      <input
                        style={{ width: 72, textAlign: 'right' }}
                        value={l.rate}
                        onChange={(e) => setLine(i, 'rate', e.target.value)}
                      />
                    </td>
                    <td className="num">
                      <input
                        style={{ width: 64, textAlign: 'right' }}
                        value={l.making}
                        onChange={(e) => setLine(i, 'making', e.target.value)}
                      />
                    </td>
                    <td className="num">{c.fine.toLocaleString('en-IN')}</td>
                    <td className="num">{c.net.toLocaleString('en-IN')}</td>
                    <ExtendedBodyCells
                      full={fullGrid}
                      fields={extendedLineFields}
                      line={l}
                      row={i}
                      baseColumns={11}
                      setValue={(row, key, value) => setLine(row, key, value)}
                    />
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
              Taxable ₹{taxable.toLocaleString('en-IN')} · Tax ₹{taxPrev.toLocaleString('en-IN')}
              {hmAmt > 0
                ? ` · HM ₹${hmAmt.toLocaleString('en-IN')}+tax ₹${hmTax.toLocaleString('en-IN')}`
                : ''}{' '}
              · <b>Total ₹{grandTotalPrev.toLocaleString('en-IN')}</b>
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Saving…' : loadedVchNo ? 'Update Hallmark Sale' : 'Save Hallmark Sale'}
            </button>
          </div>
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">Saved — Voucher #{result.vchNo}</div>
          <div className="toolbar">
            <button
              type="button"
              className="ghost"
              onClick={() =>
                window.open(
                  `/api/sales/invoice?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(String(result.vchNo))}`,
                  '_blank',
                )
              }
            >
              View Invoice PDF
            </button>
          </div>
          <div className="tiles">
            {Object.entries(result.totals).map(([k, v]) => (
              <div className="tile" key={k}>
                <div className="muted">{k}</div>
                <div className="big kpi">{Number(v).toLocaleString('en-IN')}</div>
              </div>
            ))}
          </div>
        </div>
      )}
      {coBook && (
        <VoucherList
          table="SL_DATA"
          book={coBook}
          deleteBase="/sales"
          printHref={(v) =>
            `/api/sales/invoice?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(v)}&format=html&copy=O`
          }
          onLoad={(v) => {
            setVoucherLookup(v);
            void loadSale(v);
          }}
          reloadKey={result?.vchNo}
        />
      )}
    </div>
  );
}
