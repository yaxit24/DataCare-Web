'use client';

import { useRouter } from 'next/navigation';
import { useState } from 'react';
import { BookSelect } from '../../../../components/BookSelect';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import { LookupPicker } from '../../../../components/LookupPicker';
import { VoucherChrome } from '../../../../components/VoucherChrome';
import { ApiError, del, get, post, put } from '../../../../lib/api';

interface StoneDmCfLine {
  srNo?: number;
  oldSrNo?: number;
  tagNo: string;
  vchSrno: number;
  itCode: string;
  itemName?: string;
  designNo: string;
  color: string;
  purity: string;
  size: string;
  certificateNo: string;
  tblCode: string;
  pieces: number;
  grossWt: number;
  otherWt: number;
  netWt: number;
  fineWt: number;
  labourAmount: number;
  otherAmount: number;
  tagCost: number;
  mrp: number;
  remark: string;
  karigarName: string;
  designImageId: string;
}

interface StoneDmCfView {
  voucherNo: string;
  vchDate: string;
  employeeCode: string;
  description: string;
  hiddenVoucherNo: string;
  mainUser: string;
  lines: StoneDmCfLine[];
}

interface SaveResult {
  voucherNo: string;
  hiddenVoucherNo: string;
  created: boolean;
  lines: number;
}

const blankLine = (): StoneDmCfLine => ({
  tagNo: '',
  vchSrno: 0,
  itCode: '',
  itemName: '',
  designNo: '',
  color: '',
  purity: '',
  size: '',
  certificateNo: '',
  tblCode: '',
  pieces: 1,
  grossWt: 0,
  otherWt: 0,
  netWt: 0,
  fineWt: 0,
  labourAmount: 0,
  otherAmount: 0,
  tagCost: 0,
  mrp: 0,
  remark: '',
  karigarName: '',
  designImageId: '',
});

const num = (value: string): number => Number(value || 0) || 0;
const identity = (row: Pick<StoneDmCfLine, 'tagNo' | 'vchSrno'>, index: number): string =>
  row.tagNo ? `${row.tagNo}|${row.vchSrno}` : `manual|${index}`;

export default function StoneDmCfPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const { coYear, lcCode } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [employeeCode, setEmployeeCode] = useState('');
  const [description, setDescription] = useState('');
  const [loadVoucherNo, setLoadVoucherNo] = useState('');
  const [loadedVoucherNo, setLoadedVoucherNo] = useState('');
  const [tagFilter, setTagFilter] = useState('');
  const [itCodeFilter, setItCodeFilter] = useState('');
  const [tblCodeFilter, setTblCodeFilter] = useState('');
  const [sources, setSources] = useState<StoneDmCfLine[]>([]);
  const [lines, setLines] = useState<StoneDmCfLine[]>([]);
  const [imageRow, setImageRow] = useState(0);
  const [result, setResult] = useState<SaveResult | null>(null);
  const [busy, setBusy] = useState(false);
  const [error, setError] = useState('');

  const totals = lines.reduce(
    (sum, row) => ({
      pieces: sum.pieces + (Number(row.pieces) || 0),
      grossWt: sum.grossWt + (Number(row.grossWt) || 0),
      otherWt: sum.otherWt + (Number(row.otherWt) || 0),
      netWt: sum.netWt + (Number(row.netWt) || 0),
      fineWt: sum.fineWt + (Number(row.fineWt) || 0),
      labourAmount: sum.labourAmount + (Number(row.labourAmount) || 0),
      otherAmount: sum.otherAmount + (Number(row.otherAmount) || 0),
      mrp: sum.mrp + (Number(row.mrp) || 0),
    }),
    { pieces: 0, grossWt: 0, otherWt: 0, netWt: 0, fineWt: 0, labourAmount: 0, otherAmount: 0, mrp: 0 },
  );

  const message = (caught: unknown, fallback: string): string =>
    caught instanceof ApiError
      ? caught.body?.message || caught.body?.error || caught.message
      : fallback;

  function reset() {
    setVchDate(new Date().toISOString().slice(0, 10));
    setEmployeeCode('');
    setDescription('');
    setLoadVoucherNo('');
    setLoadedVoucherNo('');
    setSources([]);
    setLines([]);
    setImageRow(0);
    setResult(null);
    setError('');
  }

  function updateLine(index: number, patch: Partial<StoneDmCfLine>) {
    setLines((current) => current.map((line, i) => (i === index ? { ...line, ...patch } : line)));
  }

  async function loadSources() {
    setError('');
    try {
      const query = new URLSearchParams();
      if (tagFilter.trim()) query.set('tagNo', tagFilter.trim());
      if (itCodeFilter.trim()) query.set('itCode', itCodeFilter.trim());
      if (tblCodeFilter.trim()) query.set('tblCode', tblCodeFilter.trim());
      query.set('limit', '500');
      const rows = await get<StoneDmCfLine[]>(`/stock/stone-dm-cf/source-list?${query.toString()}`);
      setSources(rows);
    } catch (caught) {
      setError(message(caught, 'stone/dm-cf source list failed'));
    }
  }

  function addSource(row: StoneDmCfLine) {
    setLines((current) => {
      const key = `${row.tagNo}|${row.vchSrno}`;
      if (current.some((line) => line.tagNo && `${line.tagNo}|${line.vchSrno}` === key)) return current;
      return [...current, { ...row, color: '', purity: '', certificateNo: '', remark: row.remark || '' }];
    });
  }

  async function save() {
    if (!coBook || !lines.length) {
      setError('Select an SF PRINT book and add at least one tag or manual certificate row.');
      return;
    }
    setBusy(true);
    setError('');
    try {
      const body = {
        coBook,
        coYear,
        lcCode,
        vchDate,
        employeeCode: employeeCode || undefined,
        description: description || undefined,
        lines,
      };
      const saved = loadedVoucherNo
        ? await put<SaveResult>(`/stock/stone-dm-cf/${encodeURIComponent(loadedVoucherNo)}`, body)
        : await post<SaveResult>('/stock/stone-dm-cf', body);
      setResult(saved);
      setLoadedVoucherNo(saved.voucherNo);
      setLoadVoucherNo(saved.voucherNo);
    } catch (caught) {
      setError(message(caught, 'stone/dm-cf save failed'));
    } finally {
      setBusy(false);
    }
  }

  async function loadVoucher() {
    if (!coBook || !loadVoucherNo.trim()) return;
    setBusy(true);
    setError('');
    try {
      const view = await get<StoneDmCfView>(
        `/stock/stone-dm-cf/${encodeURIComponent(loadVoucherNo.trim())}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVoucherNo(view.voucherNo);
      setLoadVoucherNo(view.voucherNo);
      setVchDate(view.vchDate);
      setEmployeeCode(view.employeeCode);
      setDescription(view.description);
      setLines(view.lines);
      setImageRow(0);
      setResult({
        voucherNo: view.voucherNo,
        hiddenVoucherNo: view.hiddenVoucherNo,
        created: false,
        lines: view.lines.length,
      });
    } catch (caught) {
      setError(message(caught, 'stone/dm-cf voucher load failed'));
    } finally {
      setBusy(false);
    }
  }

  async function removeVoucher() {
    if (!loadedVoucherNo || !window.confirm(`Delete Stone/Dm-Cf ${loadedVoucherNo}?`)) return;
    setBusy(true);
    setError('');
    try {
      await del(`/stock/stone-dm-cf/${encodeURIComponent(loadedVoucherNo)}`, { coBook });
      reset();
    } catch (caught) {
      setError(message(caught, 'stone/dm-cf delete failed'));
    } finally {
      setBusy(false);
    }
  }

  const currentImageLine = lines[imageRow];

  return (
    <div>
      <FormKeyHints actions={formKeys} />
      <VoucherChrome
        title="Stone/Dm-Cf"
        vchNo={loadedVoucherNo || result?.voucherNo}
        date={vchDate}
        onDateChange={setVchDate}
        showTime
        employee={employeeCode}
        onEmployeeChange={setEmployeeCode}
        vchDesc={description}
        onVchDescChange={setDescription}
        onSave={save}
        saveLabel={loadedVoucherNo ? 'Update' : 'Save'}
        saving={busy}
        onCancel={reset}
        onDelete={loadedVoucherNo ? removeVoucher : undefined}
        onExit={() => router.back()}
      />

      <div className="panel">
        <div className="row" style={{ alignItems: 'flex-end' }}>
          <div className="field">
            <label>Book</label>
            <BookSelect
              value={coBook}
              onChange={setCoBook}
              mainBooks={['SF PRINT']}
              disabled={Boolean(loadedVoucherNo)}
            />
          </div>
          <div className="field">
            <label>Year</label>
            <input value={coYear} readOnly />
          </div>
          <div className="field">
            <label>Location</label>
            <input value={lcCode} readOnly style={{ width: 70 }} />
          </div>
          <div className="field">
            <label>Load voucher</label>
            <input
              value={loadVoucherNo}
              onChange={(event) => setLoadVoucherNo(event.target.value)}
              onKeyDown={(event) => {
                if (event.key === 'Enter') {
                  event.preventDefault();
                  void loadVoucher();
                }
              }}
              style={{ width: 90 }}
            />
          </div>
          <button type="button" className="ghost" disabled={busy} onClick={loadVoucher}>
            Load
          </button>
          <span className="spacer" />
          <button type="button" className="ghost" disabled={!result} onClick={() => window.print()}>
            Print view
          </button>
        </div>
      </div>

      <div className="panel">
        <div className="row" style={{ alignItems: 'flex-end' }}>
          <div className="field">
            <label>Tag filter</label>
            <input value={tagFilter} onChange={(event) => setTagFilter(event.target.value)} />
          </div>
          <div className="field">
            <label>Item filter</label>
            <LookupPicker entity="items" value={itCodeFilter} onChange={setItCodeFilter} />
          </div>
          <div className="field">
            <label>Counter filter</label>
            <input value={tblCodeFilter} onChange={(event) => setTblCodeFilter(event.target.value)} />
          </div>
          <button type="button" className="primary" disabled={busy} onClick={() => void loadSources()}>
            Load in-stock tags
          </button>
          <button type="button" className="ghost" onClick={() => setLines((current) => [...current, blankLine()])}>
            Add manual row
          </button>
        </div>

        {sources.length > 0 && (
          <div style={{ overflow: 'auto', marginTop: 12 }}>
            <table className="grid" data-testid="stone-dm-cf-source-grid">
              <thead>
                <tr>
                  <th>Tag No</th>
                  <th>Item</th>
                  <th>Design</th>
                  <th>Size</th>
                  <th>Counter</th>
                  <th className="num">Pcs</th>
                  <th className="num">Gross</th>
                  <th className="num">MRP</th>
                  <th></th>
                </tr>
              </thead>
              <tbody>
                {sources.map((row, index) => (
                  <tr key={identity(row, index)}>
                    <td>{row.tagNo}</td>
                    <td>{row.itemName || row.itCode}</td>
                    <td>{row.designNo}</td>
                    <td>{row.size}</td>
                    <td>{row.tblCode}</td>
                    <td className="num">{row.pieces || ''}</td>
                    <td className="num">{row.grossWt.toFixed(3)}</td>
                    <td className="num">{row.mrp.toFixed(2)}</td>
                    <td>
                      <button type="button" className="ghost" onClick={() => addSource(row)}>
                        Add
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
      </div>

      {lines.length > 0 && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <div className="toolbar" style={{ marginBottom: 8 }}>
            <h2 style={{ margin: 0 }}>Certificate / stone rows</h2>
            <span className="muted">{lines.length} row(s)</span>
          </div>
          <table className="grid" data-testid="stone-dm-cf-grid">
            <thead>
              <tr>
                <th>Sr</th>
                <th>Tag No</th>
                <th>VchSrno</th>
                <th>ItCode</th>
                <th>Design</th>
                <th>Color</th>
                <th>Purity</th>
                <th>Size</th>
                <th>Cf.No</th>
                <th className="num">Pcs</th>
                <th className="num">GrWt</th>
                <th className="num">OthWt</th>
                <th className="num">NetWt</th>
                <th className="num">Fine</th>
                <th className="num">LbrAmt</th>
                <th className="num">OthAmt</th>
                <th className="num">TagCost</th>
                <th className="num">Mrp</th>
                <th>Remark</th>
                <th>KrName</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {lines.map((row, index) => (
                <tr key={identity(row, index)} onClick={() => setImageRow(index)}>
                  <td>{index + 1}</td>
                  <td><input value={row.tagNo} onChange={(e) => updateLine(index, { tagNo: e.target.value })} /></td>
                  <td><input type="number" value={row.vchSrno || ''} onChange={(e) => updateLine(index, { vchSrno: num(e.target.value) })} style={{ width: 70 }} /></td>
                  <td><input value={row.itCode} onChange={(e) => updateLine(index, { itCode: e.target.value })} style={{ width: 70 }} /></td>
                  <td><input value={row.designNo} onChange={(e) => updateLine(index, { designNo: e.target.value })} /></td>
                  <td><input value={row.color} onChange={(e) => updateLine(index, { color: e.target.value })} /></td>
                  <td><input value={row.purity} onChange={(e) => updateLine(index, { purity: e.target.value })} /></td>
                  <td><input value={row.size} onChange={(e) => updateLine(index, { size: e.target.value })} /></td>
                  <td><input value={row.certificateNo} onChange={(e) => updateLine(index, { certificateNo: e.target.value })} /></td>
                  <td><input className="num" type="number" value={row.pieces || ''} onChange={(e) => updateLine(index, { pieces: num(e.target.value) })} style={{ width: 70 }} /></td>
                  <td><input className="num" type="number" value={row.grossWt || ''} onChange={(e) => updateLine(index, { grossWt: num(e.target.value) })} style={{ width: 90 }} /></td>
                  <td><input className="num" type="number" value={row.otherWt || ''} onChange={(e) => updateLine(index, { otherWt: num(e.target.value) })} style={{ width: 90 }} /></td>
                  <td><input className="num" type="number" value={row.netWt || ''} onChange={(e) => updateLine(index, { netWt: num(e.target.value) })} style={{ width: 90 }} /></td>
                  <td><input className="num" type="number" value={row.fineWt || ''} onChange={(e) => updateLine(index, { fineWt: num(e.target.value) })} style={{ width: 90 }} /></td>
                  <td><input className="num" type="number" value={row.labourAmount || ''} onChange={(e) => updateLine(index, { labourAmount: num(e.target.value) })} style={{ width: 90 }} /></td>
                  <td><input className="num" type="number" value={row.otherAmount || ''} onChange={(e) => updateLine(index, { otherAmount: num(e.target.value) })} style={{ width: 90 }} /></td>
                  <td><input className="num" type="number" value={row.tagCost || ''} onChange={(e) => updateLine(index, { tagCost: num(e.target.value) })} style={{ width: 90 }} /></td>
                  <td><input className="num" type="number" value={row.mrp || ''} onChange={(e) => updateLine(index, { mrp: num(e.target.value) })} style={{ width: 90 }} /></td>
                  <td><input value={row.remark} onChange={(e) => updateLine(index, { remark: e.target.value })} /></td>
                  <td><input value={row.karigarName} onChange={(e) => updateLine(index, { karigarName: e.target.value })} style={{ width: 70 }} /></td>
                  <td>
                    <button
                      type="button"
                      className="ghost"
                      onClick={(event) => {
                        event.stopPropagation();
                        setLines((current) => current.filter((_, i) => i !== index));
                      }}
                    >
                      Remove
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td colSpan={9}>Total</td>
                <td className="num">{totals.pieces || ''}</td>
                <td className="num">{totals.grossWt.toFixed(3)}</td>
                <td className="num">{totals.otherWt.toFixed(3)}</td>
                <td className="num">{totals.netWt.toFixed(3)}</td>
                <td className="num">{totals.fineWt.toFixed(3)}</td>
                <td className="num">{totals.labourAmount.toFixed(2)}</td>
                <td className="num">{totals.otherAmount.toFixed(2)}</td>
                <td></td>
                <td className="num">{totals.mrp.toFixed(2)}</td>
                <td colSpan={3}></td>
              </tr>
            </tfoot>
          </table>
        </div>
      )}

      {error && <div className="msg err">{error}</div>}
      {result && (
        <div className="msg ok" data-testid="stone-dm-cf-saved">
          Saved Stone/Dm-Cf {result.voucherNo} · header {result.hiddenVoucherNo} · {result.lines} row(s). This records the SF PRINT data used by the desktop print flow.
        </div>
      )}

      <EntityImagePanel
        entityType="TAG"
        entityKey={currentImageLine?.tagNo ?? ''}
        instance={currentImageLine?.vchSrno ?? 0}
        label="Tag image"
        testId="stone-dm-cf-image"
        disabled={!currentImageLine?.tagNo}
      />
    </div>
  );
}
