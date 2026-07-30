'use client';

import { useRouter } from 'next/navigation';
import { useState } from 'react';
import { BookSelect } from '../../../../components/BookSelect';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { LookupPicker } from '../../../../components/LookupPicker';
import { VoucherChrome } from '../../../../components/VoucherChrome';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import { ApiError, del, get, post, put } from '../../../../lib/api';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';

interface StockRow {
  tagNo: string;
  vchSrno: number;
  itCode: string;
  itemName: string;
  designNo: string | null;
  itmSize: string | null;
  tblCode: string | null;
  pieces: number;
  grossWt: number;
  otherWt: number;
  netWt: number;
  touch: number;
  labourAmount: number;
  otherAmount: number;
  mrp: number;
  karigarName: string | null;
}

interface PersistedLine extends StockRow {
  srNo: number;
  oldSrNo: number;
  fineWt: number;
}

interface PhysicalStockView {
  voucherNo: string;
  vchDate: string;
  employeeCode: string;
  description: string;
  hiddenVoucherNo: string;
  mainUser: string;
  lines: PersistedLine[];
}

interface SaveResult {
  voucherNo: string;
  hiddenVoucherNo: string;
  created: boolean;
  lines: number;
}

interface VarianceDetail {
  tagNo: string;
  vchSrno: number;
  status: 'matched' | 'missing' | 'extra';
  bookWt: number;
  countedWt: number | null;
  diffWt: number;
}

const identity = (row: Pick<StockRow, 'tagNo' | 'vchSrno'>): string =>
  `${row.tagNo}|${row.vchSrno}`;

export default function PhysicalStockPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const { coYear, lcCode } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [employeeCode, setEmployeeCode] = useState('');
  const [description, setDescription] = useState('');
  const [loadVoucherNo, setLoadVoucherNo] = useState('');
  const [loadedVoucherNo, setLoadedVoucherNo] = useState('');
  const [tblCode, setTblCode] = useState('');
  const [itCode, setItCode] = useState('');
  const [rows, setRows] = useState<StockRow[]>([]);
  // The desktop's image buttons act on the current grid row.
  const [imageRow, setImageRow] = useState(0);
  const [listOffset, setListOffset] = useState(0);
  const [hasMore, setHasMore] = useState(false);
  const [selected, setSelected] = useState<Set<string>>(new Set());
  const [scan, setScan] = useState('');
  const [result, setResult] = useState<SaveResult | null>(null);
  const [variance, setVariance] = useState<any>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);

  const selectedRows = rows.filter((row) => selected.has(identity(row)));
  const totals = selectedRows.reduce(
    (sum, row) => ({
      pieces: sum.pieces + row.pieces,
      grossWt: sum.grossWt + row.grossWt,
      otherWt: sum.otherWt + row.otherWt,
      netWt: sum.netWt + row.netWt,
      labourAmount: sum.labourAmount + row.labourAmount,
      otherAmount: sum.otherAmount + row.otherAmount,
      mrp: sum.mrp + row.mrp,
    }),
    { pieces: 0, grossWt: 0, otherWt: 0, netWt: 0, labourAmount: 0, otherAmount: 0, mrp: 0 },
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
    setRows([]);
    setListOffset(0);
    setHasMore(false);
    setSelected(new Set());
    setScan('');
    setResult(null);
    setVariance(null);
    setError('');
  }

  async function loadAvailable(append = false) {
    setError('');
    setVariance(null);
    try {
      const query = new URLSearchParams();
      if (tblCode) query.set('tblCode', tblCode);
      if (itCode) query.set('itCode', itCode);
      query.set('limit', '500');
      query.set('offset', String(append ? listOffset : 0));
      const available = await get<StockRow[]>(`/stock/physical-list?${query.toString()}`);
      setRows((current) => {
        const base = append || loadedVoucherNo ? current : [];
        return Array.from(
          new Map([...base, ...available].map((row) => [identity(row), row])).values(),
        );
      });
      if (!append && !loadedVoucherNo) {
        setSelected(new Set());
        setResult(null);
      }
      setListOffset((append ? listOffset : 0) + available.length);
      setHasMore(available.length === 500);
    } catch (caught) {
      setError(message(caught, 'physical stock list failed'));
    }
  }

  function selectRow(row: StockRow, checked: boolean) {
    setSelected((current) => {
      const next = new Set(current);
      if (checked) next.add(identity(row));
      else next.delete(identity(row));
      return next;
    });
    setVariance(null);
  }

  async function markScan(value: string) {
    const tagNo = value.trim();
    if (!tagNo) return;
    try {
      let matches = rows.filter((row) => row.tagNo === tagNo);
      if (!matches.length) {
        matches = await get<StockRow[]>(
          `/stock/physical-list?tagNo=${encodeURIComponent(tagNo)}&limit=500`,
        );
        if (matches.length === 1) {
          setRows((current) =>
            current.some((row) => identity(row) === identity(matches[0]!))
              ? current
              : [...current, matches[0]!],
          );
        }
      }
      if (matches.length !== 1) {
        setError(
          matches.length
            ? `Tag ${tagNo} has multiple live identities; select the exact row.`
            : `Tag ${tagNo} is not available in book stock.`,
        );
        return;
      }
      setError('');
      selectRow(matches[0]!, true);
    } catch (caught) {
      setError(message(caught, 'tag lookup failed'));
    } finally {
      setScan('');
    }
  }

  async function save() {
    if (!coBook || !selectedRows.length) {
      setError('Select a configured Physical Stock book and at least one available tag.');
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
        lines: selectedRows.map((row) => ({ tagNo: row.tagNo, vchSrno: row.vchSrno })),
      };
      const saved = loadedVoucherNo
        ? await put<SaveResult>(
            `/stock/physical-stock/${encodeURIComponent(loadedVoucherNo)}`,
            body,
          )
        : await post<SaveResult>('/stock/physical-stock', body);
      setResult(saved);
      setLoadedVoucherNo(saved.voucherNo);
      setLoadVoucherNo(saved.voucherNo);
    } catch (caught) {
      setError(message(caught, 'physical stock save failed'));
    } finally {
      setBusy(false);
    }
  }

  async function loadVoucher() {
    if (!coBook || !loadVoucherNo.trim()) return;
    setBusy(true);
    setError('');
    setVariance(null);
    try {
      const view = await get<PhysicalStockView>(
        `/stock/physical-stock/${encodeURIComponent(loadVoucherNo.trim())}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVoucherNo(view.voucherNo);
      setLoadVoucherNo(view.voucherNo);
      setVchDate(view.vchDate);
      setEmployeeCode(view.employeeCode);
      setDescription(view.description);
      setRows(view.lines);
      setListOffset(0);
      setHasMore(false);
      setSelected(new Set(view.lines.map(identity)));
      setResult({
        voucherNo: view.voucherNo,
        hiddenVoucherNo: view.hiddenVoucherNo,
        created: false,
        lines: view.lines.length,
      });
    } catch (caught) {
      setError(message(caught, 'physical stock voucher load failed'));
    } finally {
      setBusy(false);
    }
  }

  async function removeVoucher() {
    if (!loadedVoucherNo || !window.confirm(`Delete physical stock ${loadedVoucherNo}?`)) return;
    setBusy(true);
    setError('');
    try {
      await del(`/stock/physical-stock/${encodeURIComponent(loadedVoucherNo)}`, { coBook });
      reset();
    } catch (caught) {
      setError(message(caught, 'physical stock delete failed'));
    } finally {
      setBusy(false);
    }
  }

  async function reconcile() {
    setBusy(true);
    setError('');
    try {
      setVariance(
        await post('/stock/physical-reconcile', {
          coBook,
          counts: selectedRows.map((row) => ({
            tagNo: row.tagNo,
            vchSrno: row.vchSrno,
          })),
        }),
      );
    } catch (caught) {
      setError(message(caught, 'physical stock reconciliation failed'));
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <FormKeyHints actions={formKeys} />
      <VoucherChrome
        title="Physical Stock"
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
              mainBooks={['PHY STOCK']}
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
          <div className="field">
            <label>Counter filter</label>
            <input value={tblCode} onChange={(event) => setTblCode(event.target.value)} />
          </div>
          <div className="field">
            <label>Item filter</label>
            <LookupPicker entity="items" value={itCode} onChange={setItCode} />
          </div>
          <button
            type="button"
            className="primary"
            disabled={busy}
            onClick={() => void loadAvailable(false)}
          >
            Load in-stock
          </button>
        </div>
        <div className="row" style={{ marginTop: 10 }}>
          <div className="field" style={{ flex: 1 }}>
            <label>Scan tag</label>
            <input
              value={scan}
              onChange={(event) => setScan(event.target.value)}
              onKeyDown={(event) => {
                if (event.key === 'Enter') {
                  event.preventDefault();
                  void markScan(scan);
                }
              }}
              placeholder="scan / type an available tag + Enter"
              data-testid="physical-stock-scan"
            />
          </div>
          <span className="muted" style={{ alignSelf: 'end' }}>
            {rows.length} available · {selectedRows.length} physically counted
          </span>
        </div>
      </div>

      {rows.length > 0 && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <div className="toolbar" style={{ marginBottom: 8 }}>
            <h2 style={{ margin: 0 }}>Counted Tags</h2>
            {hasMore && (
              <button type="button" className="ghost" onClick={() => void loadAvailable(true)}>
                Load next 500
              </button>
            )}
            <span className="spacer" />
            <button
              type="button"
              className="ghost"
              onClick={() => {
                setSelected(new Set());
                setVariance(null);
              }}
            >
              Clear count
            </button>
            <button
              type="button"
              className="ghost"
              disabled={busy || !selectedRows.length}
              onClick={reconcile}
            >
              Variance report
            </button>
          </div>
          <table className="grid" data-testid="physical-stock-grid">
            <thead>
              <tr>
                <th>✓</th>
                <th>Tag No</th>
                <th>Item</th>
                <th>Design</th>
                <th>Size</th>
                <th>Counter</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Other Wt</th>
                <th className="num">Net</th>
                <th className="num">Labour</th>
                <th className="num">Other Amt</th>
                <th className="num">MRP</th>
                <th>Karigar</th>
              </tr>
            </thead>
            <tbody>
              {rows.map((row) => {
                const checked = selected.has(identity(row));
                return (
                  <tr key={identity(row)} style={{ opacity: checked ? 1 : 0.6 }}>
                    <td>
                      <input
                        type="checkbox"
                        checked={checked}
                        onChange={(event) => selectRow(row, event.target.checked)}
                        aria-label={`Count tag ${row.tagNo}`}
                      />
                    </td>
                    <td>{row.tagNo}</td>
                    <td>{row.itemName || row.itCode}</td>
                    <td>{row.designNo || ''}</td>
                    <td>{row.itmSize || ''}</td>
                    <td>{row.tblCode || ''}</td>
                    <td className="num">{row.pieces || ''}</td>
                    <td className="num">{row.grossWt.toFixed(3)}</td>
                    <td className="num">{row.otherWt.toFixed(3)}</td>
                    <td className="num">{row.netWt.toFixed(3)}</td>
                    <td className="num">{row.labourAmount.toFixed(2)}</td>
                    <td className="num">{row.otherAmount.toFixed(2)}</td>
                    <td className="num">{row.mrp.toFixed(2)}</td>
                    <td>{row.karigarName || ''}</td>
                  </tr>
                );
              })}
            </tbody>
            <tfoot>
              <tr>
                <td colSpan={6}>Total physically counted</td>
                <td className="num">{totals.pieces || ''}</td>
                <td className="num">{totals.grossWt.toFixed(3)}</td>
                <td className="num">{totals.otherWt.toFixed(3)}</td>
                <td className="num">{totals.netWt.toFixed(3)}</td>
                <td className="num">{totals.labourAmount.toFixed(2)}</td>
                <td className="num">{totals.otherAmount.toFixed(2)}</td>
                <td className="num">{totals.mrp.toFixed(2)}</td>
                <td></td>
              </tr>
            </tfoot>
          </table>
        </div>
      )}

      {error && <div className="msg err">{error}</div>}
      {result && (
        <div className="msg ok" data-testid="physical-stock-saved">
          Saved physical count {result.voucherNo} · header {result.hiddenVoucherNo} · {result.lines}{' '}
          tag(s). This records count evidence only; it does not move stock.
        </div>
      )}

      {variance && (
        <>
          <div className="tiles">
            <div className="tile">
              <div className="muted">Book tags</div>
              <div className="big kpi">{variance.bookCount}</div>
            </div>
            <div className="tile">
              <div className="muted">Physically counted</div>
              <div className="big kpi">{variance.countedCount}</div>
            </div>
            <div className="tile">
              <div className="muted">Shortage</div>
              <div className="big kpi" style={{ color: 'var(--err)' }}>
                {variance.missingCount}
              </div>
            </div>
          </div>
          <div className="panel" style={{ overflow: 'auto' }}>
            <h2>Variance</h2>
            <table className="grid">
              <thead>
                <tr>
                  <th>Tag</th>
                  <th>Status</th>
                  <th className="num">Book Net</th>
                  <th className="num">Diff Wt</th>
                </tr>
              </thead>
              <tbody>
                {(variance.detail as VarianceDetail[])
                  .filter((row) => row.status !== 'matched')
                  .map((row) => (
                    <tr key={`${row.tagNo}|${row.vchSrno}`}>
                      <td>
                        {row.tagNo} <span className="muted">#{row.vchSrno}</span>
                      </td>
                      <td style={{ color: 'var(--err)' }}>{row.status}</td>
                      <td className="num">{row.bookWt}</td>
                      <td className="num">{row.diffWt}</td>
                    </tr>
                  ))}
              </tbody>
            </table>
          </div>
        </>
      )}
      <EntityImagePanel
        entityType="TAG"
        entityKey={rows[imageRow]?.tagNo ?? ''}
        instance={imageRow + 1}
        label="Tag image"
        testId="physical-stock-image"
      />
    </div>
  );
}
