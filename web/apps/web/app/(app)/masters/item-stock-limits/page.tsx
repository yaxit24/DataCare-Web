'use client';

import { useCallback, useEffect, useState } from 'react';
import { ApiError, del, get, post } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';

interface LimitLine {
  fromWt: string;
  toWt: string;
  minPcs: string;
  lbrCode: string;
  ghtPct: string;
  lbrPct: string;
  minLbrPct: string;
  lbrType: string;
  lbrRate: string;
  lbrAmt: string;
}
interface SummaryRow {
  itCode: string;
  itName: string;
  itDesign: string;
  rowCount: number;
}

const blankLine = (): LimitLine => ({
  fromWt: '',
  toWt: '',
  minPcs: '',
  lbrCode: '',
  ghtPct: '',
  lbrPct: '',
  minLbrPct: '',
  lbrType: '',
  lbrRate: '',
  lbrAmt: '',
});
const num = (value: string): number => Number(value || 0);
const text = (value: unknown): string => String(value ?? '').trim();
const design = (value: string): string => text(value).toUpperCase() || 'N';

export default function ItemStockLimitsPage() {
  const [itCode, setItCode] = useState('');
  const [itName, setItName] = useState('');
  const [itDesign, setItDesign] = useState('N');
  const [rows, setRows] = useState<LimitLine[]>([blankLine()]);
  const [summary, setSummary] = useState<SummaryRow[]>([]);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);

  const setRow = (index: number, key: keyof LimitLine, value: string) =>
    setRows((current) => current.map((row, i) => (i === index ? { ...row, [key]: value } : row)));

  const loadSummary = useCallback(async () => {
    try {
      setSummary(await get<SummaryRow[]>('/masters/item-stock-limits'));
    } catch {
      setSummary([]);
    }
  }, []);

  useEffect(() => {
    void loadSummary();
  }, [loadSummary]);

  const load = useCallback(
    async (item = itCode, itemDesign = itDesign) => {
      const code = text(item).toUpperCase();
      if (!code) {
        setMsg({ kind: 'err', text: 'Error Found : Please Enter Item code First...' });
        return;
      }
      const dsgn = design(itemDesign);
      setBusy(true);
      setMsg(null);
      try {
        const data = await get<any[]>(
          `/masters/item-stock-limits?itCode=${encodeURIComponent(code)}&itDesign=${encodeURIComponent(dsgn)}`,
        );
        setItCode(code);
        setItDesign(dsgn);
        setItName(text(data[0]?.itName));
        setRows(
          data.length
            ? data.map((row) => ({
                fromWt: String(row.fromWt ?? ''),
                toWt: String(row.toWt ?? ''),
                minPcs: String(row.minPcs ?? ''),
                lbrCode: text(row.lbrCode),
                ghtPct: String(row.ghtPct ?? ''),
                lbrPct: String(row.lbrPct ?? ''),
                minLbrPct: String(row.minLbrPct ?? ''),
                lbrType: text(row.lbrType),
                lbrRate: String(row.lbrRate ?? ''),
                lbrAmt: String(row.lbrAmt ?? ''),
              }))
            : [blankLine()],
        );
      } catch (error) {
        setMsg({
          kind: 'err',
          text: error instanceof ApiError ? error.body?.message || error.body?.error || error.message : 'failed',
        });
      } finally {
        setBusy(false);
      }
    },
    [itCode, itDesign],
  );

  async function save() {
    const code = text(itCode).toUpperCase();
    if (!code) {
      setMsg({ kind: 'err', text: 'Error Found : Please Enter Item code First...' });
      return;
    }
    const dsgn = design(itDesign);
    setBusy(true);
    setMsg(null);
    try {
      const payload = rows.map((row) => ({
        fromWt: num(row.fromWt),
        toWt: num(row.toWt),
        minPcs: num(row.minPcs),
        lbrCode: text(row.lbrCode).toUpperCase(),
        ghtPct: num(row.ghtPct),
        lbrPct: num(row.lbrPct),
        minLbrPct: num(row.minLbrPct),
        lbrType: text(row.lbrType).toUpperCase().slice(0, 1),
        lbrRate: num(row.lbrRate),
        lbrAmt: num(row.lbrAmt),
      }));
      const result = await post<{ saved: number }>('/masters/item-stock-limits', {
        itCode: code,
        itDesign: dsgn,
        rows: payload,
      });
      setMsg({ kind: 'ok', text: `Data Are Saved. ${result.saved} row(s).` });
      await load(code, dsgn);
      await loadSummary();
    } catch (error) {
      setMsg({
        kind: 'err',
        text: error instanceof ApiError ? error.body?.message || error.body?.detail || error.body?.error || error.message : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  async function removeAll() {
    const code = text(itCode).toUpperCase();
    if (!code) {
      setMsg({ kind: 'err', text: 'Please Select Product For Delete.' });
      return;
    }
    const dsgn = design(itDesign);
    setBusy(true);
    setMsg(null);
    try {
      const result = await del<{ deleted: number }>(
        `/masters/item-stock-limits?itCode=${encodeURIComponent(code)}&itDesign=${encodeURIComponent(dsgn)}`,
      );
      setMsg({ kind: 'ok', text: `Delete Success. ${result.deleted} row(s).` });
      setRows([blankLine()]);
      await loadSummary();
    } catch (error) {
      setMsg({
        kind: 'err',
        text: error instanceof ApiError ? error.body?.message || error.body?.error || error.message : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        ItStk Limit <span className="muted">— MS_STK_LIMIT item/design weight grid</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <div className="panel">
        <div className="row">
          <div className="field" style={{ flex: 1 }}>
            <label>Item</label>
            <LookupPicker
              entity="items"
              value={itCode}
              onChange={setItCode}
              onPick={(row) => {
                setItName(text(row.name));
                void load(String(row.code), itDesign);
              }}
            />
          </div>
          <div className="field" style={{ flex: 1 }}>
            <label>Item Name</label>
            <input value={itName} onChange={(event) => setItName(event.target.value)} readOnly />
          </div>
          <div className="field" style={{ width: 150 }}>
            <label>Design</label>
            <input value={itDesign} onChange={(event) => setItDesign(event.target.value)} maxLength={20} />
          </div>
          <div className="field" style={{ alignSelf: 'end' }}>
            <button type="button" className="ghost" onClick={() => load()} disabled={busy}>
              Load
            </button>
          </div>
        </div>
      </div>

      <div className="panel" style={{ overflow: 'auto' }}>
        <table className="grid">
          <thead>
            <tr>
              <th className="num">Sr</th>
              <th className="num">From Wt</th>
              <th className="num">To Wt</th>
              <th className="num">Min Pcs</th>
              <th>Lbr Code</th>
              <th className="num">Ght %</th>
              <th className="num">Lbr %</th>
              <th className="num">MinLbr %</th>
              <th>Lbr Type</th>
              <th className="num">Lbr Rate</th>
              <th className="num">Lbr Amt</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {rows.map((row, index) => (
              <tr key={index}>
                <td className="num muted">{index + 1}</td>
                {(['fromWt', 'toWt', 'minPcs'] as const).map((key) => (
                  <td className="num" key={key}>
                    <input value={row[key]} onChange={(event) => setRow(index, key, event.target.value)} style={{ width: 72, textAlign: 'right' }} />
                  </td>
                ))}
                <td style={{ minWidth: 105 }}>
                  <LookupPicker
                    entity="labour"
                    value={row.lbrCode}
                    onChange={(value) => setRow(index, 'lbrCode', value)}
                    style={{ minWidth: 95 }}
                  />
                </td>
                {(['ghtPct', 'lbrPct', 'minLbrPct'] as const).map((key) => (
                  <td className="num" key={key}>
                    <input value={row[key]} onChange={(event) => setRow(index, key, event.target.value)} style={{ width: 72, textAlign: 'right' }} />
                  </td>
                ))}
                <td>
                  <select value={row.lbrType} onChange={(event) => setRow(index, 'lbrType', event.target.value)} style={{ width: 72 }}>
                    <option value=""></option>
                    <option value="G">G</option>
                    <option value="N">N</option>
                    <option value="P">P</option>
                    <option value="F">F</option>
                    <option value="K">K</option>
                  </select>
                </td>
                {(['lbrRate', 'lbrAmt'] as const).map((key) => (
                  <td className="num" key={key}>
                    <input value={row[key]} onChange={(event) => setRow(index, key, event.target.value)} style={{ width: 82, textAlign: 'right' }} />
                  </td>
                ))}
                <td>
                  <button
                    type="button"
                    className="danger"
                    onClick={() => setRows((current) => (current.length > 1 ? current.filter((_, i) => i !== index) : [blankLine()]))}
                  >
                    ×
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        <div className="toolbar" style={{ marginTop: 10 }}>
          <button type="button" className="ghost" onClick={() => setRows((current) => [...current, blankLine()])}>
            + Add Row
          </button>
          <span className="spacer" />
          <button type="button" className="danger" onClick={removeAll} disabled={busy}>
            Delete
          </button>
          <button type="button" className="primary" onClick={save} disabled={busy}>
            {busy ? 'Saving…' : 'Save'}
          </button>
        </div>
      </div>

      <div className="panel" style={{ overflow: 'auto' }}>
        <h2>Saved item stock limits</h2>
        <table className="grid">
          <thead>
            <tr>
              <th>Item</th>
              <th>Name</th>
              <th>Design</th>
              <th className="num">Rows</th>
            </tr>
          </thead>
          <tbody>
            {summary.map((row) => (
              <tr
                key={`${row.itCode}-${row.itDesign}`}
                onClick={() => load(row.itCode, row.itDesign)}
                style={{ cursor: 'pointer' }}
              >
                <td>{row.itCode}</td>
                <td>{row.itName}</td>
                <td>{row.itDesign}</td>
                <td className="num">{row.rowCount}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
