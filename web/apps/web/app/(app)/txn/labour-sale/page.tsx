'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { LookupPicker } from '../../../../components/LookupPicker';
import { BookSelect } from '../../../../components/BookSelect';
import { VoucherList } from '../../../../components/VoucherList';

/** Labour Invoice (TR_MFG_LBR): bill the MAKING when the customer supplied the gold (order-gold).
 *  DUAL GST — metal value @ metalTaxPct (3%) + labour @ labourTaxPct (5%). Posts to /labour-invoice. */
type LType = 'per_gram' | 'per_piece' | 'percentage' | 'fixed';
interface Line {
  itCode: string;
  desc: string;
  labourType: LType;
  netWt: string;
  pcs: string;
  value: string;
  metalAmount: string;
}
const blank = (): Line => ({
  itCode: '',
  desc: '',
  labourType: 'fixed',
  netWt: '',
  pcs: '1',
  value: '',
  metalAmount: '',
});
const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

function making(l: Line): number {
  if (l.labourType === 'per_gram') return r2(n(l.value) * n(l.netWt));
  if (l.labourType === 'per_piece') return r2(n(l.value) * n(l.pcs));
  if (l.labourType === 'percentage') return r2((n(l.value) * n(l.metalAmount)) / 100);
  return n(l.value);
}

export default function LabourInvoicePage() {
  const { coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [metalTaxPct, setMetalTaxPct] = useState('3');
  const [labourTaxPct, setLabourTaxPct] = useState('5');
  const [orderGoldFine, setOrderGoldFine] = useState('');
  const [interState, setInterState] = useState(false);
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [result, setResult] = useState<{
    vchNo: number;
    metalTaxable: number;
    labourTaxable: number;
    metalTax: number;
    labourTax: number;
    total: number;
  } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  const metalBase = r2(lines.reduce((s, l) => s + n(l.metalAmount), 0));
  const labourBase = r2(lines.reduce((s, l) => s + making(l), 0));
  const metalTax = r2((metalBase * n(metalTaxPct)) / 100);
  const labourTax = r2((labourBase * n(labourTaxPct)) / 100);
  const grand = r2(metalBase + metalTax + labourBase + labourTax);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      setResult(
        await post('/labour-invoice', {
          coBook,
          coYear,
          acCode,
          acName: acName || undefined,
          interState,
          metalTaxPct: n(metalTaxPct),
          labourTaxPct: n(labourTaxPct),
          orderGoldFine: n(orderGoldFine) > 0 ? n(orderGoldFine) : undefined,
          lines: lines
            .filter((l) => l.itCode)
            .map((l) => ({
              itCode: l.itCode,
              desc: l.desc || undefined,
              netWt: n(l.netWt),
              pcs: n(l.pcs),
              metalAmount: n(l.metalAmount),
              labourAmount: making(l),
            })),
        }),
      );
      setLines([blank()]);
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Labour Invoice{' '}
        <span className="muted">— making bill on customer's own gold (dual GST 3% + 5%)</span>
      </h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="LBR" />
            </div>
            <div className="field">
              <label>Customer</label>
              <LookupPicker
                entity="customers"
                value={acCode}
                onChange={setAcCode}
                onPick={(row) => {
                  if (row?.name) setAcName(String(row.name));
                }}
              />
            </div>
            <div className="field">
              <label>Name</label>
              <input value={acName} onChange={(e) => setAcName(e.target.value)} />
            </div>
            <div className="field">
              <label>Metal GST %</label>
              <input value={metalTaxPct} onChange={(e) => setMetalTaxPct(e.target.value)} />
            </div>
            <div className="field">
              <label>Labour GST %</label>
              <input value={labourTaxPct} onChange={(e) => setLabourTaxPct(e.target.value)} />
            </div>
            <div className="field">
              <label>Order-gold fine (g)</label>
              <input
                value={orderGoldFine}
                onChange={(e) => setOrderGoldFine(e.target.value)}
                placeholder="customer gold"
              />
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
        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Labour Lines</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Item</th>
                <th>Desc</th>
                <th>Labour Type</th>
                <th className="num">Net Wt</th>
                <th className="num">Pcs</th>
                <th className="num">Rate/%/Fixed</th>
                <th className="num">Metal Amt</th>
                <th className="num">Making</th>
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
                      style={{ width: 90 }}
                    />
                  </td>
                  <td>
                    <input
                      value={l.desc}
                      onChange={(e) => setLine(i, 'desc', e.target.value)}
                      style={{ width: 100 }}
                    />
                  </td>
                  <td>
                    <select
                      value={l.labourType}
                      onChange={(e) => setLine(i, 'labourType', e.target.value)}
                    >
                      <option value="fixed">Fixed</option>
                      <option value="per_gram">Per gram</option>
                      <option value="per_piece">Per piece</option>
                      <option value="percentage">% of metal</option>
                    </select>
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 60, textAlign: 'right' }}
                      value={l.netWt}
                      onChange={(e) => setLine(i, 'netWt', e.target.value)}
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
                      style={{ width: 70, textAlign: 'right' }}
                      value={l.value}
                      onChange={(e) => setLine(i, 'value', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 80, textAlign: 'right' }}
                      value={l.metalAmount}
                      onChange={(e) => setLine(i, 'metalAmount', e.target.value)}
                    />
                  </td>
                  <td className="num">{making(l).toLocaleString('en-IN')}</td>
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
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setLines((ls) => [...ls, blank()])}
            >
              + Add line
            </button>
            <span className="spacer" />
            <button className="primary" disabled={busy}>
              {busy ? 'Saving…' : 'Save Labour Bill'}
            </button>
          </div>
          <div className="tiles" style={{ marginTop: 10 }}>
            {[
              ['Metal', metalBase],
              [`Metal GST ${metalTaxPct}%`, metalTax],
              ['Labour', labourBase],
              [`Labour GST ${labourTaxPct}%`, labourTax],
              ['Total', grand],
            ].map(([k, v]) => (
              <div className="tile" key={String(k)}>
                <div className="muted">{k}</div>
                <div className="big kpi">{Number(v).toLocaleString('en-IN')}</div>
              </div>
            ))}
          </div>
        </div>
      </form>
      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">Saved — Labour Invoice #{result.vchNo}</div>
          <div className="tiles">
            {(
              [
                ['Metal', result.metalTaxable],
                ['Metal GST', result.metalTax],
                ['Labour', result.labourTaxable],
                ['Labour GST', result.labourTax],
                ['Total', result.total],
              ] as [string, number][]
            ).map(([k, v]) => (
              <div className="tile" key={k}>
                <div className="muted">{k}</div>
                <div className="big kpi">{Number(v).toLocaleString('en-IN')}</div>
              </div>
            ))}
          </div>
        </div>
      )}
      <VoucherList
        table="LBR_DATA"
        book="LBR"
        deleteBase="/labour-invoice"
        reloadKey={result?.vchNo}
      />
    </div>
  );
}
