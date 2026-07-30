'use client';
import { useRef, useState } from 'react';
import { useRouter } from 'next/navigation';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { BookSelect } from '../../../../components/BookSelect';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';

/** Item Lot Intake (TR_ITM_LOT) — load loose/lot stock as identifiable lots → ITM_LOT_DETL +
 *  MAIN_STOCK (VCH_TYPE 'ITLOT' / TR_TYPE 'I' / '+'). No money ledger. */
interface Row {
  itCode: string;
  lotNo: string;
  designNo: string;
  itmSize: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  westPct: string;
  rate: string;
  making: string;
}
const blank = (): Row => ({
  itCode: '',
  lotNo: '',
  designNo: '',
  itmSize: '',
  pcs: '',
  grossWt: '',
  netWt: '',
  touch: '',
  westPct: '',
  rate: '',
  making: '',
});
const n = (v: string) => Number(v || 0);
const str = (v: unknown) => (v == null || Number(v) === 0 ? '' : String(v));
const r3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;
const currentDate = () => new Date().toISOString().slice(0, 10);
const gridCell = (row: number, column: number) => ({
  'data-grid-row': row,
  'data-grid-column': column,
});

export default function ItemLotPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const { coYear, lcCode } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [rows, setRows] = useState<Row[]>([blank()]);
  // The desktop's image buttons act on the current grid row.
  const [imageRow, setImageRow] = useState(0);
  const [vchDate, setVchDate] = useState(currentDate);
  const [acCode, setAcCode] = useState('');
  const [voucherLookup, setVoucherLookup] = useState('');
  const [loadedVchNo, setLoadedVchNo] = useState('');
  const [res, setRes] = useState<{ vchNo: number; lots: number } | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const submitRef = useRef<HTMLButtonElement>(null);
  const handleGridKey = useGridKeyboard({
    rowCount: rows.length,
    columnCount: 11,
    onAppendRow: () => setRows((current) => [...current, blank()]),
    onRemoveRow: (row) => {
      if (!window.confirm('Remove this lot row?')) return false;
      setRows((current) =>
        current.length > 1 ? current.filter((_, index) => index !== row) : [blank()],
      );
      return true;
    },
    onEscape: () => submitRef.current?.focus(),
  });
  const set = (i: number, k: keyof Row, v: string) =>
    setRows((current) => current.map((row, index) => (index === i ? { ...row, [k]: v } : row)));
  const fine = (row: Row) => r3((n(row.netWt) * n(row.touch)) / 100);
  const scopeQuery = `coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}`;
  const errorText = (error: unknown) =>
    error instanceof ApiError
      ? error.body?.detail || error.body?.message || error.body?.error || error.message
      : 'failed';

  function newVoucher() {
    setLoadedVchNo('');
    setVoucherLookup('');
    setVchDate(currentDate());
    setAcCode('');
    setRows([blank()]);
    setRes(null);
    setMsg(null);
  }

  async function loadVoucher() {
    if (!voucherLookup.trim()) return;
    setBusy(true);
    setMsg(null);
    try {
      const view = await get<any>(
        `/stock/item-lot/${encodeURIComponent(voucherLookup.trim())}?${scopeQuery}`,
      );
      setLoadedVchNo(String(view.voucherNo));
      setVoucherLookup(String(view.voucherNo));
      setVchDate(String(view.vchDate));
      setAcCode(String(view.acCode ?? ''));
      const loaded = (view.lines ?? []).map((line: any): Row => ({
        itCode: String(line.itCode ?? ''),
        lotNo: String(line.lotNo ?? ''),
        designNo: String(line.designNo ?? ''),
        itmSize: String(line.itmSize ?? ''),
        pcs: str(line.pcs),
        grossWt: str(line.grossWt),
        netWt: str(line.netWt),
        touch: str(line.touch),
        westPct: str(line.westPct),
        rate: str(line.rate),
        making: str(line.making),
      }));
      setRows(loaded.length ? loaded : [blank()]);
      setRes(null);
    } catch (error) {
      setMsg({ kind: 'err', text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }

  async function removeVoucher() {
    if (!loadedVchNo || !window.confirm(`Delete voucher ${loadedVchNo}?`)) return;
    setBusy(true);
    setMsg(null);
    try {
      await del(`/stock/item-lot/${encodeURIComponent(loadedVchNo)}?${scopeQuery}`);
      newVoucher();
    } catch (error) {
      setMsg({ kind: 'err', text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setRes(null);
    const lines = rows
      .filter((row) => row.itCode.trim())
      .map((row) => ({
        itCode: row.itCode.trim(),
        lotNo: row.lotNo.trim() || undefined,
        designNo: row.designNo.trim() || undefined,
        itmSize: row.itmSize.trim() || undefined,
        pcs: n(row.pcs),
        grossWt: n(row.grossWt),
        netWt: n(row.netWt),
        touch: n(row.touch),
        westPct: n(row.westPct),
        rate: n(row.rate),
        making: n(row.making),
      }));
    if (!lines.length) {
      setMsg({ kind: 'err', text: 'enter at least one lot line' });
      return;
    }
    setBusy(true);
    try {
      const body = {
        coBook: coBook || undefined,
        coYear,
        lcCode,
        vchDate,
        acCode: acCode || undefined,
        lines,
      };
      const saved = loadedVchNo
        ? await put<{ vchNo: number; lots: number }>(
            `/stock/item-lot/${encodeURIComponent(loadedVchNo)}`,
            body,
          )
        : await post<{ vchNo: number; lots: number }>('/stock/item-lot', body);
      const savedNo = String(saved.vchNo).padStart(5, '0');
      setLoadedVchNo(savedNo);
      setVoucherLookup(savedNo);
      setRes(saved);
      setMsg({
        kind: 'ok',
        text: `${loadedVchNo ? 'Lot intake updated' : 'Lot intake posted'} — ${saved.lots} lot(s) (voucher #${saved.vchNo})`,
      });
    } catch (error) {
      setMsg({ kind: 'err', text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <FormKeyHints actions={formKeys} />
      <h1>
        Item Lot Intake <span className="muted">— TR_ITM_LOT (loose/lot stock)</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Voucher No</label>
              <input
                aria-label="Voucher No"
                value={voucherLookup}
                onChange={(e) => setVoucherLookup(e.target.value)}
                placeholder="00001"
              />
            </div>
            <button type="button" className="ghost" disabled={busy} onClick={loadVoucher}>
              Load
            </button>
            {loadedVchNo && (
              <span className="msg ok" data-testid="item-lot-loaded">
                Loaded #{loadedVchNo}
              </span>
            )}
            {loadedVchNo && (
              <button type="button" className="danger" disabled={busy} onClick={removeVoucher}>
                Delete
              </button>
            )}
            <button type="button" className="ghost" disabled={busy} onClick={newVoucher}>
              New
            </button>
            <div className="field">
              <label>Date</label>
              <input
                aria-label="Date"
                type="date"
                value={vchDate}
                onChange={(e) => setVchDate(e.target.value)}
              />
            </div>
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="ILT" />
            </div>
            <div className="field">
              <label>Account (optional)</label>
              <LookupPicker
                entity="accounts"
                ariaLabel="Account"
                value={acCode}
                onChange={setAcCode}
              />
            </div>
            <div className="field muted" style={{ alignSelf: 'end' }}>
              blank lot no ⇒ auto · fine = net × touch / 100
            </div>
          </div>
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <table className="grid">
            <thead>
              <tr>
                <th>Item</th>
                <th>Lot No</th>
                <th>Design</th>
                <th>Size</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net</th>
                <th className="num">Touch</th>
                <th className="num">West%</th>
                <th className="num">Fine</th>
                <th className="num">Rate</th>
                <th className="num">Making/g</th>
                <th></th>
              </tr>
            </thead>
            <tbody data-testid="item-lot-grid" onKeyDown={handleGridKey}>
              {rows.map((row, i) => (
                <tr key={i}>
                  <td {...gridCell(i, 0)}>
                    <LookupPicker
                      entity="items"
                      ariaLabel={`Item code row ${i + 1}`}
                      value={row.itCode}
                      onChange={(value) => set(i, 'itCode', value)}
                      style={{ width: 90 }}
                    />
                  </td>
                  {(['lotNo', 'designNo', 'itmSize'] as const).map((field, columnIndex) => (
                    <td {...gridCell(i, columnIndex + 1)} key={field}>
                      <input
                        aria-label={`Item lot ${field} row ${i + 1}`}
                        value={row[field]}
                        maxLength={field === 'lotNo' ? 10 : undefined}
                        onChange={(e) => set(i, field, e.target.value)}
                        style={{ width: field === 'lotNo' ? 80 : field === 'designNo' ? 70 : 60 }}
                      />
                    </td>
                  ))}
                  {(['pcs', 'grossWt', 'netWt', 'touch', 'westPct'] as const).map(
                    (field, columnIndex) => (
                      <td {...gridCell(i, columnIndex + 4)} className="num" key={field}>
                        <input
                          aria-label={`Item lot ${field} row ${i + 1}`}
                          value={row[field]}
                          onChange={(e) => set(i, field, e.target.value)}
                          style={{
                            width:
                              field === 'pcs'
                                ? 50
                                : field === 'grossWt' || field === 'netWt'
                                  ? 70
                                  : 56,
                            textAlign: 'right',
                          }}
                        />
                      </td>
                    ),
                  )}
                  <td className="num">{fine(row).toLocaleString('en-IN')}</td>
                  {(['rate', 'making'] as const).map((field, columnIndex) => (
                    <td {...gridCell(i, columnIndex + 9)} className="num" key={field}>
                      <input
                        aria-label={`Item lot ${field} row ${i + 1}`}
                        value={row[field]}
                        onChange={(e) => set(i, field, e.target.value)}
                        style={{ width: field === 'rate' ? 76 : 64, textAlign: 'right' }}
                      />
                    </td>
                  ))}
                  <td>
                    <button
                      type="button"
                      className="danger"
                      aria-label={`Remove lot row ${i + 1}`}
                      onClick={() =>
                        setRows((current) =>
                          current.length > 1
                            ? current.filter((_, index) => index !== i)
                            : [blank()],
                        )
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
              onClick={() => setRows((current) => [...current, blank()])}
            >
              + Add lot
            </button>
            <span className="spacer" />
            <button ref={submitRef} className="primary" disabled={busy}>
              {busy ? 'Posting…' : loadedVchNo ? 'Update Lot Intake' : 'Post Lot Intake'}
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
      <EntityImagePanel
        entityType="DESIGN"
        entityKey={rows[imageRow]?.designNo ?? ''}
        instance={0}
        label="Design image"
        testId="item-lot-image"
      />
    </div>
  );
}
