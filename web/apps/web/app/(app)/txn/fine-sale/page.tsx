'use client';
import { useState } from 'react';
import { post, put, get, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { BookSelect } from '../../../../components/BookSelect';
import { VoucherList } from '../../../../components/VoucherList';
import { useGridKeyboard } from '../../../../components/GridKeyboard';

/** Fine Sale / Fine Purchase (TR_FINE_SL_PR) — pure-metal trade priced on fine weight. SALE sells
 *  fine out, PURC buys fine in; a purchase may "cut" (rate-fix) open fine on existing purchase lines.
 *  POST /fine-sale. */
interface Row {
  itCode: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  fineRate: string;
}
interface Cut {
  coBook: string;
  vchNo: string;
  srNo: string;
  fine: string;
}
const blank = (): Row => ({ itCode: '', pcs: '', grossWt: '', netWt: '', touch: '', fineRate: '' });
const cblank = (): Cut => ({ coBook: '', vchNo: '', srNo: '', fine: '' });
const n = (v: string) => Number(v || 0);
const r3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

export default function FineSalePurchasePage() {
  const [side, setSide] = useState<'SALE' | 'PURC'>('SALE');
  const [f, setF] = useState({
    partyAc: '',
    partyName: '',
    itType: 'G',
    taxPct: '3',
    interState: false,
  });
  const [rows, setRows] = useState<Row[]>([blank()]);
  // P1-5: desktop grids are keyboard-first — arrows move, Enter advances and appends at the end,
  // Ctrl/Cmd+D removes a row (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: rows.length,
    onAppendRow: () => setRows((current) => [...current, blank()]),
    onRemoveRow: (row) => {
      setRows((current) =>
        current.length === 1 ? [blank()] : current.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  const [cuts, setCuts] = useState<Cut[]>([]);
  const [res, setRes] = useState<any>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const [loadedVch, setLoadedVch] = useState('');
  const set = (k: keyof typeof f, v: string | boolean) => setF((x) => ({ ...x, [k]: v }));
  const setRow = (i: number, k: keyof Row, v: string) =>
    setRows((rs) => rs.map((r, j) => (j === i ? { ...r, [k]: v } : r)));
  const setCut = (i: number, k: keyof Cut, v: string) =>
    setCuts((cs) => cs.map((r, j) => (j === i ? { ...r, [k]: v } : r)));
  const fine = (r: Row) => r3((n(r.netWt) * n(r.touch)) / 100);
  const metal = (r: Row) => r2(fine(r) * n(r.fineRate));
  const totMetal = r2(rows.reduce((s, r) => s + (r.itCode.trim() ? metal(r) : 0), 0));
  const totTax = r2((totMetal * n(f.taxPct)) / 100);
  const totNet = r2(totMetal + totTax);

  function resetForm() {
    setLoadedVch('');
    setF({ partyAc: '', partyName: '', itType: 'G', taxPct: '3', interState: false });
    setRows([blank()]);
    setCuts([]);
    setRes(null);
    setMsg(null);
  }

  // Reopen a saved fine sale/purchase (GET /fine-sale/:vchNo?side=) for edit. CUT_DETL stores the
  // fine weight + rate (not the net-weight/touch split), so a reopened line sets netWt = fineWt and
  // touch = 100 — which reproduces the same fine (netWt*touch/100) and the same priced metal.
  async function loadVoucher(vchNo: string) {
    setMsg(null);
    setRes(null);
    setBusy(true);
    try {
      const d = await get<any>(
        `/fine-sale/${encodeURIComponent(vchNo)}?side=${side === 'PURC' ? 'PURC' : 'SALE'}`,
      );
      setLoadedVch(String(d.vchNo ?? vchNo));
      setSide(d.side === 'PURC' ? 'PURC' : 'SALE');
      setF({
        partyAc: String(d.partyAc ?? ''),
        partyName: String(d.partyName ?? ''),
        itType: d.itType === 'S' ? 'S' : 'G',
        taxPct: d.taxPct != null ? String(d.taxPct) : '0',
        interState: !!d.interState,
      });
      const src: any[] = Array.isArray(d.lines) && d.lines.length ? d.lines : [];
      setRows(
        src.length
          ? src.map((l) => ({
              ...blank(),
              netWt: l.fineWt ? String(l.fineWt) : '',
              touch: '100',
              fineRate: l.fineRate ? String(l.fineRate) : '',
            }))
          : [blank()],
      );
      setCuts([]); // rate-cut links are not re-editable on reopen; a fresh cut set may be re-entered
    } catch (e) {
      setMsg({
        kind: 'err',
        text: e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setRes(null);
    if (!f.partyAc.trim()) {
      setMsg({ kind: 'err', text: 'party is required' });
      return;
    }
    const lines = rows
      .filter((r) => r.itCode.trim() && n(r.fineRate) > 0)
      .map((r) => ({
        itCode: r.itCode.trim(),
        pcs: n(r.pcs),
        grossWt: n(r.grossWt),
        netWt: n(r.netWt),
        touch: n(r.touch),
        fineRate: n(r.fineRate),
      }));
    if (!lines.length) {
      setMsg({ kind: 'err', text: 'enter at least one fine line (item + touch + fine rate)' });
      return;
    }
    const cutList =
      side === 'PURC'
        ? cuts
            .filter((cu) => cu.vchNo.trim() && n(cu.fine) > 0)
            .map((cu) => ({
              coBook: cu.coBook.trim(),
              vchNo: cu.vchNo.trim(),
              srNo: n(cu.srNo),
              fine: n(cu.fine),
            }))
        : [];
    setBusy(true);
    try {
      const payload = {
        side,
        partyAc: f.partyAc.trim(),
        partyName: f.partyName || undefined,
        itType: f.itType,
        taxPct: Number(f.taxPct || 0),
        interState: f.interState,
        lines,
        cuts: cutList,
      };
      const r = loadedVch
        ? await put(`/fine-sale/${encodeURIComponent(loadedVch)}`, payload)
        : await post('/fine-sale', payload);
      setRes(r);
      setMsg({
        kind: 'ok',
        text: `${side === 'SALE' ? 'Fine sale' : 'Fine purchase'} #${r.vchNo} — fine ${Number(r.totals?.fine).toLocaleString('en-IN')} g, net ₹${Number(r.totals?.net).toLocaleString('en-IN')}${cutList.length ? `, ${cutList.length} line(s) fixed` : ''}`,
      });
      if (loadedVch) setLoadedVch(String(r.vchNo).padStart(5, '0'));
      else {
        setRows([blank()]);
        setCuts([]);
      }
    } catch (err) {
      setMsg({
        kind: 'err',
        text:
          err instanceof ApiError
            ? err.body?.detail || err.body?.message || err.body?.error || 'failed'
            : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Fine Sale / Purchase{' '}
        <span className="muted">— TR_FINE_SL_PR (pure-metal on fine weight)</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Side</label>
              <select value={side} onChange={(e) => setSide(e.target.value as 'SALE' | 'PURC')}>
                <option value="SALE">FINE SALE (sell out)</option>
                <option value="PURC">FINE PURC (buy in)</option>
              </select>
            </div>
            <div className="field" style={{ flex: 2 }}>
              <label>{side === 'SALE' ? 'Customer' : 'Supplier'}</label>
              <LookupPicker
                entity="accounts"
                value={f.partyAc}
                onChange={(v) => set('partyAc', v)}
                onPick={(r) => {
                  if (!f.partyName) set('partyName', String(r.name || ''));
                }}
              />
            </div>
            <div className="field">
              <label>Metal</label>
              <select value={f.itType} onChange={(e) => set('itType', e.target.value)}>
                <option value="G">Gold</option>
                <option value="S">Silver</option>
              </select>
            </div>
            <div className="field">
              <label>Tax %</label>
              <input value={f.taxPct} onChange={(e) => set('taxPct', e.target.value)} />
            </div>
            <div className="field">
              <label>Inter-state</label>
              <select
                value={f.interState ? 'y' : 'n'}
                onChange={(e) => set('interState', e.target.value === 'y')}
              >
                <option value="n">No</option>
                <option value="y">Yes (IGST)</option>
              </select>
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Fine lines</h2>
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Item</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net</th>
                <th className="num">Touch</th>
                <th className="num">Fine</th>
                <th className="num">Fine Rate</th>
                <th className="num">Metal Amt</th>
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
                  <td className="num">
                    <input
                      value={r.pcs}
                      onChange={(e) => setRow(i, 'pcs', e.target.value)}
                      style={{ width: 50, textAlign: 'right' }}
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
                      style={{ width: 60, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">{fine(r).toLocaleString('en-IN')}</td>
                  <td className="num">
                    <input
                      value={r.fineRate}
                      onChange={(e) => setRow(i, 'fineRate', e.target.value)}
                      style={{ width: 84, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">{r.itCode.trim() ? metal(r).toLocaleString('en-IN') : ''}</td>
                  <td>
                    <button
                      type="button"
                      className="danger"
                      onClick={() =>
                        setRows((rs) => (rs.length > 1 ? rs.filter((_, j) => j !== i) : [blank()]))
                      }
                    >
                      ×
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td colSpan={7} style={{ textAlign: 'right', fontWeight: 600 }}>
                  Metal / +tax / Net
                </td>
                <td className="num">
                  <b>{totMetal.toLocaleString('en-IN')}</b> / {totTax.toLocaleString('en-IN')} /{' '}
                  <b>{totNet.toLocaleString('en-IN')}</b>
                </td>
                <td></td>
              </tr>
            </tfoot>
          </table>
          <div className="toolbar" style={{ marginTop: 8 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setRows((rs) => [...rs, blank()])}
            >
              + Add line
            </button>
          </div>
        </div>

        {side === 'PURC' && (
          <div className="panel" style={{ overflow: 'auto' }}>
            <h2>
              Rate-cut / fixing{' '}
              <span className="muted">(fix open fine on existing purchase lines)</span>
            </h2>
            <table className="grid">
              <thead>
                <tr>
                  <th>Purc Book</th>
                  <th className="num">Purc Vch#</th>
                  <th className="num">Line#</th>
                  <th className="num">Fine to fix</th>
                  <th></th>
                </tr>
              </thead>
              <tbody>
                {cuts.map((cu, i) => (
                  <tr key={i}>
                    <td>
                      <BookSelect
                        value={cu.coBook}
                        onChange={(book) => setCut(i, 'coBook', book)}
                        preferred="PUR"
                      />
                    </td>
                    <td className="num">
                      <input
                        value={cu.vchNo}
                        onChange={(e) => setCut(i, 'vchNo', e.target.value)}
                        style={{ width: 80, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        value={cu.srNo}
                        onChange={(e) => setCut(i, 'srNo', e.target.value)}
                        style={{ width: 56, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        value={cu.fine}
                        onChange={(e) => setCut(i, 'fine', e.target.value)}
                        style={{ width: 84, textAlign: 'right' }}
                      />
                    </td>
                    <td>
                      <button
                        type="button"
                        className="danger"
                        onClick={() => setCuts((cs) => cs.filter((_, j) => j !== i))}
                      >
                        ×
                      </button>
                    </td>
                  </tr>
                ))}
                {cuts.length === 0 && (
                  <tr>
                    <td colSpan={5} className="muted">
                      No fixing rows (optional).
                    </td>
                  </tr>
                )}
              </tbody>
            </table>
            <div className="toolbar" style={{ marginTop: 8 }}>
              <button
                type="button"
                className="ghost"
                onClick={() => setCuts((cs) => [...cs, cblank()])}
              >
                + Fix a line
              </button>
            </div>
          </div>
        )}

        <div className="panel">
          <div className="toolbar">
            <span className="muted">POST /fine-sale ({side})</span>
            <span className="spacer" />
            <button className="primary" data-save-mnemonic disabled={busy}>
              {busy
                ? 'Saving…'
                : loadedVch
                  ? `Update #${loadedVch}`
                  : `Save Fine ${side === 'SALE' ? 'Sale' : 'Purchase'}`}
            </button>
            {loadedVch && (
              <button type="button" className="ghost" onClick={resetForm} disabled={busy}>
                New
              </button>
            )}
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
        table="CUT_DATA"
        book={side === 'PURC' ? 'FPR' : 'FSL'}
        deleteBase="/fine-sale"
        onLoad={(vchNo) => loadVoucher(vchNo)}
      />
    </div>
  );
}
