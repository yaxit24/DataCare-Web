'use client';

import { useCallback, useEffect, useState } from 'react';
import { ApiError, del, get, post } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';

interface DiamondLine {
  dmSize: string;
  dmWt: string;
  pcsGht: string;
  pcsLbr: string;
  rateType: string;
  dmRate: string;
}
interface SummaryRow {
  itCode: string;
  itName: string;
  dmSize: string;
  rowCount: number;
}

const blankLine = (): DiamondLine => ({
  dmSize: '',
  dmWt: '',
  pcsGht: '',
  pcsLbr: '',
  rateType: '',
  dmRate: '',
});
const num = (value: string): number => Number(value || 0);
const text = (value: unknown): string => String(value ?? '').trim();

export default function DiamondSizesPage() {
  const [itCode, setItCode] = useState('');
  const [itName, setItName] = useState('');
  const [rows, setRows] = useState<DiamondLine[]>([blankLine()]);
  const [summary, setSummary] = useState<SummaryRow[]>([]);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);

  const setRow = (index: number, key: keyof DiamondLine, value: string) =>
    setRows((current) => current.map((row, i) => (i === index ? { ...row, [key]: value } : row)));

  const loadSummary = useCallback(async () => {
    try {
      setSummary(await get<SummaryRow[]>('/masters/diamond-sizes'));
    } catch {
      setSummary([]);
    }
  }, []);

  useEffect(() => {
    void loadSummary();
  }, [loadSummary]);

  const load = useCallback(
    async (item = itCode) => {
      const code = text(item).toUpperCase();
      if (!code) {
        setMsg({ kind: 'err', text: 'Error Found : Please Enter Item code First...' });
        return;
      }
      setBusy(true);
      setMsg(null);
      try {
        const data = await get<any[]>(`/masters/diamond-sizes?itCode=${encodeURIComponent(code)}`);
        setItCode(code);
        setItName(text(data[0]?.itName));
        setRows(
          data.length
            ? data.map((row) => ({
                dmSize: text(row.dmSize),
                dmWt: String(row.dmWt ?? ''),
                pcsGht: String(row.pcsGht ?? ''),
                pcsLbr: String(row.pcsLbr ?? ''),
                rateType: text(row.rateType),
                dmRate: String(row.dmRate ?? ''),
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
    [itCode],
  );

  async function save() {
    const code = text(itCode).toUpperCase();
    if (!code) {
      setMsg({ kind: 'err', text: 'Error Found : Please Enter Item code First...' });
      return;
    }
    setBusy(true);
    setMsg(null);
    try {
      const payload = rows.map((row) => ({
        dmSize: text(row.dmSize).toUpperCase(),
        dmWt: num(row.dmWt),
        pcsGht: num(row.pcsGht),
        pcsLbr: num(row.pcsLbr),
        rateType: text(row.rateType).toUpperCase().slice(0, 1),
        dmRate: num(row.dmRate),
      }));
      const result = await post<{ saved: number }>('/masters/diamond-sizes', {
        itCode: code,
        rows: payload,
      });
      setMsg({ kind: 'ok', text: `Data Are Saved. ${result.saved} row(s).` });
      await load(code);
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
    setBusy(true);
    setMsg(null);
    try {
      const result = await del<{ deleted: number }>(
        `/masters/diamond-sizes?itCode=${encodeURIComponent(code)}`,
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
        Dm Size <span className="muted">— MS_STK_LIMIT diamond-size grid</span>
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
                void load(String(row.code));
              }}
            />
          </div>
          <div className="field" style={{ flex: 1 }}>
            <label>Item Name</label>
            <input value={itName} onChange={(event) => setItName(event.target.value)} readOnly />
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
              <th>Dm Size</th>
              <th className="num">Dm Wt</th>
              <th className="num">PcsGht</th>
              <th className="num">PcsLbr</th>
              <th>Rate Type</th>
              <th className="num">Dm Rate</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {rows.map((row, index) => (
              <tr key={index}>
                <td className="num muted">{index + 1}</td>
                <td>
                  <input value={row.dmSize} onChange={(event) => setRow(index, 'dmSize', event.target.value)} style={{ width: 120 }} />
                </td>
                <td className="num">
                  <input value={row.dmWt} onChange={(event) => setRow(index, 'dmWt', event.target.value)} style={{ width: 80, textAlign: 'right' }} />
                </td>
                <td className="num">
                  <input value={row.pcsGht} onChange={(event) => setRow(index, 'pcsGht', event.target.value)} style={{ width: 80, textAlign: 'right' }} />
                </td>
                <td className="num">
                  <input value={row.pcsLbr} onChange={(event) => setRow(index, 'pcsLbr', event.target.value)} style={{ width: 80, textAlign: 'right' }} />
                </td>
                <td>
                  <input value={row.rateType} maxLength={1} onChange={(event) => setRow(index, 'rateType', event.target.value)} style={{ width: 70 }} />
                </td>
                <td className="num">
                  <input value={row.dmRate} onChange={(event) => setRow(index, 'dmRate', event.target.value)} style={{ width: 90, textAlign: 'right' }} />
                </td>
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
        <h2>Saved diamond-size rows</h2>
        <table className="grid">
          <thead>
            <tr>
              <th>Item</th>
              <th>Name</th>
              <th>Size</th>
              <th className="num">Rows</th>
            </tr>
          </thead>
          <tbody>
            {summary.map((row, index) => (
              <tr
                key={`${row.itCode}-${row.dmSize}-${index}`}
                onClick={() => load(row.itCode)}
                style={{ cursor: 'pointer' }}
              >
                <td>{row.itCode}</td>
                <td>{row.itName}</td>
                <td>{row.dmSize}</td>
                <td className="num">{row.rowCount}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
