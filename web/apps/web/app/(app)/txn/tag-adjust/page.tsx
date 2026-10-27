'use client';

import { useState } from 'react';
import { ApiError, del, get, post, put } from '../../../../lib/api';
import { BookSelect } from '../../../../components/BookSelect';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { todayLocal } from '../../../../lib/localDate';

interface Line {
  tagNo: string;
  itCode: string;
  vchSrno: string;
  dataType: string;
  remark: string;
}

interface SaveResult {
  vchNo: number;
  lines: number;
  stones: number;
  barDetlUpdated: number;
  mainStockUpdated: number;
}

interface LoadedVoucher {
  header: Record<string, any> | null;
  lines: Array<Record<string, any>>;
  stones: Array<Record<string, any>>;
}

const blank = (): Line => ({ tagNo: '', itCode: '', vchSrno: '', dataType: '', remark: '' });
const today = () => todayLocal();
const msg = (e: unknown, fallback: string): string =>
  e instanceof ApiError
    ? e.body?.message || e.body?.error || e.body?.detail || e.message
    : fallback;
const dateText = (value: unknown): string => String(value ?? '').slice(0, 10);

export default function TagAdjustPage() {
  const scope = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(today());
  const [vchDesc, setVchDesc] = useState('');
  const [acCode, setAcCode] = useState('');
  const [lookupNo, setLookupNo] = useState('');
  const [loadedNo, setLoadedNo] = useState<string | null>(null);
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [result, setResult] = useState<SaveResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (index: number, key: keyof Line, value: string) =>
    setLines((rows) => rows.map((line, i) => (i === index ? { ...line, [key]: value } : line)));

  const addLine = () => setLines((rows) => [...rows, blank()]);
  const removeLine = (index: number) =>
    setLines((rows) => (rows.length === 1 ? [blank()] : rows.filter((_, i) => i !== index)));

  function payload() {
    return {
      book: coBook,
      coBook,
      coYear: scope.coYear,
      lcCode: scope.lcCode,
      vchDate,
      vchDesc: vchDesc || undefined,
      acCode: acCode || undefined,
      lines: lines
        .filter((line) => line.tagNo.trim() && line.dataType.trim())
        .map((line) => ({
          tagNo: line.tagNo.trim(),
          itCode: line.itCode.trim() || undefined,
          vchSrno: line.vchSrno.trim() ? Number(line.vchSrno) : undefined,
          dataType: line.dataType.trim().toUpperCase(),
          remark: line.remark.trim() || undefined,
        })),
    };
  }

  async function save(e: React.FormEvent) {
    e.preventDefault();
    setBusy(true);
    setError('');
    setResult(null);
    try {
      const body = payload();
      const saved = loadedNo
        ? await put<SaveResult>(`/stock/tag-adjust/${encodeURIComponent(loadedNo)}`, body)
        : await post<SaveResult>('/stock/tag-adjust', body);
      setResult(saved);
      setLoadedNo(String(saved.vchNo).padStart(5, '0'));
      setLookupNo(String(saved.vchNo).padStart(5, '0'));
    } catch (e) {
      setError(msg(e, 'Tag adjust save failed.'));
    } finally {
      setBusy(false);
    }
  }

  async function loadVoucher() {
    if (!lookupNo.trim() || !coBook) return;
    setBusy(true);
    setError('');
    setResult(null);
    try {
      const loaded = await get<LoadedVoucher>(
        `/stock/tag-adjust/${encodeURIComponent(lookupNo.trim())}?book=${encodeURIComponent(coBook)}`,
      );
      if (!loaded?.header) {
        setError('Voucher not found.');
        return;
      }
      setLoadedNo(lookupNo.trim().padStart(5, '0'));
      setVchDate(dateText(loaded.header.VCH_DATE) || today());
      setVchDesc(String(loaded.header.VCH_DESC ?? ''));
      setAcCode(String(loaded.header.AC_CODE ?? ''));
      setLines(
        loaded.lines.length
          ? loaded.lines.map((row) => ({
              tagNo: String(row.TAG_NO ?? ''),
              itCode: String(row.IT_CODE ?? ''),
              vchSrno: row.VCH_SRNO == null ? '' : String(row.VCH_SRNO),
              dataType: String(row.DATA_TYPE ?? ''),
              remark: String(row.ITM_REMARK ?? ''),
            }))
          : [blank()],
      );
      setResult({
        vchNo: Number(lookupNo),
        lines: loaded.lines.length,
        stones: loaded.stones.length,
        barDetlUpdated: 0,
        mainStockUpdated: 0,
      });
    } catch (e) {
      setError(msg(e, 'Tag adjust load failed.'));
    } finally {
      setBusy(false);
    }
  }

  async function deleteVoucher() {
    if (!loadedNo || !coBook) return;
    const ok = window.confirm(
      `Delete Tag Adjust voucher ${loadedNo}? Desktop deletion removes the audit voucher; it does not restore the previous tag DATA_TYPE.`,
    );
    if (!ok) return;
    setBusy(true);
    setError('');
    try {
      await del(`/stock/tag-adjust/${encodeURIComponent(loadedNo)}`, { book: coBook });
      setLoadedNo(null);
      setLookupNo('');
      setLines([blank()]);
      setResult(null);
    } catch (e) {
      setError(msg(e, 'Tag adjust delete failed.'));
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Tag Adjust</h1>
      <p className="muted">
        Desktop TR_TAG_CAN / TAG ADJ mode. It records a tag-adjust voucher and updates DATA_TYPE on
        the matching BAR_DETL and MAIN_STOCK tag rows.
      </p>

      <form onSubmit={save}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect
                value={coBook}
                onChange={setCoBook}
                preferred="TAD"
                mainBooks={['TAG ADJ']}
              />
            </div>
            <div className="field">
              <label>Voucher Date</label>
              <input type="date" value={vchDate} onChange={(e) => setVchDate(e.target.value)} />
            </div>
            <div className="field">
              <label>Party / AC Code</label>
              <input
                value={acCode}
                onChange={(e) => setAcCode(e.target.value)}
                placeholder="optional"
              />
            </div>
          </div>
          <label>
            Description
            <input value={vchDesc} onChange={(e) => setVchDesc(e.target.value)} />
          </label>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Tag Data-Type Adjustments</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Tag No</th>
                <th>Item</th>
                <th className="num">Vch SrNo</th>
                <th>New DATA_TYPE</th>
                <th>Remark</th>
                <th />
              </tr>
            </thead>
            <tbody>
              {lines.map((line, index) => (
                <tr key={index}>
                  <td>
                    <input
                      value={line.tagNo}
                      onChange={(e) => setLine(index, 'tagNo', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      value={line.itCode}
                      onChange={(e) => setLine(index, 'itCode', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      className="num"
                      value={line.vchSrno}
                      onChange={(e) => setLine(index, 'vchSrno', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      value={line.dataType}
                      onChange={(e) => setLine(index, 'dataType', e.target.value)}
                      maxLength={1}
                    />
                  </td>
                  <td>
                    <input
                      value={line.remark}
                      onChange={(e) => setLine(index, 'remark', e.target.value)}
                    />
                  </td>
                  <td>
                    <button type="button" className="ghost" onClick={() => removeLine(index)}>
                      Remove
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <button type="button" className="ghost" onClick={addLine} style={{ marginTop: 12 }}>
            Add Row
          </button>
        </div>

        <div className="toolbar">
          <button className="primary" disabled={busy || !coBook}>
            {busy ? 'Saving…' : loadedNo ? 'Update Tag Adjust' : 'Save Tag Adjust'}
          </button>
          <input
            value={lookupNo}
            onChange={(e) => setLookupNo(e.target.value)}
            placeholder="Voucher no"
          />
          <button
            type="button"
            className="ghost"
            onClick={loadVoucher}
            disabled={busy || !coBook || !lookupNo.trim()}
          >
            Load
          </button>
          <button
            type="button"
            className="danger"
            onClick={deleteVoucher}
            disabled={busy || !loadedNo}
          >
            Delete
          </button>
        </div>
      </form>

      {error && <div className="msg err">{error}</div>}
      {result && (
        <div className="msg ok">
          Voucher {String(result.vchNo).padStart(5, '0')} saved. Lines {result.lines}, copied stone
          rows {result.stones}, BAR_DETL updates {result.barDetlUpdated}, MAIN_STOCK updates{' '}
          {result.mainStockUpdated}.
        </div>
      )}
    </div>
  );
}
