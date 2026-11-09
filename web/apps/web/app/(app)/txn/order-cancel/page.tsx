'use client';
import { toIsoDate } from '@datacare/core';
import { useRouter } from 'next/navigation';
import { useCallback, useEffect, useRef, useState } from 'react';
import { get, postCommand, put, del, ApiError } from '../../../../lib/api';
import { useIdempotencyKey } from '../../../../lib/idempotencyKey';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { VoucherList } from '../../../../components/VoucherList';
import { useVoucherNumberKeys, VoucherNumberNote } from '../../../../components/VoucherNumberKeys';
import {
  OrderCancelGridRow,
  f2,
  n,
  paidOf,
  r2,
  type Row,
} from '../../../../components/OrderCancelGridRow';
import {
  OrderCancelOrderHelp,
  OrderCancelTagGrid,
  type OrderTag,
  type PendingOrder,
} from '../../../../components/OrderCancelOrderHelp';
import { useScreenEscape, type ScreenKeyEvent } from '../../../../lib/screenEscape';
import { todayLocal } from '../../../../lib/localDate';

/** Desktop "Order Cancel" opens TR_SL_ORD_ADJ with `CurBookHelp('ORDER CANCEL')` (MDI_FORM.cs:8628-8639). */
const ORDER_CANCEL_MAIN_BOOKS = ['ORDER CANCEL'];

const weekday = (iso: string) =>
  iso ? new Date(`${iso}T00:00:00`).toLocaleDateString('en-GB', { weekday: 'long' }) : '';
const clock = () => new Date().toTimeString().slice(0, 8);
const errorText = (e: unknown, fallback: string) =>
  e instanceof ApiError
    ? e.body?.message || e.body?.detail || e.body?.error || e.message
    : fallback;

/**
 * Order Cancel (TR_SL_ORD_ADJ). One voucher cancels the open advance of any number of orders. The grid is the
 * desktop's MSG: Sr, OrdNo, AcCode, Ac Name, It Desc, OrdAmt, AdjAmt, KsarAmt, PaidAmt, PaiidAc, Paid Ac Name
 * (MSG_CLEAR, TR_SL_ORD_ADJ.cs:2140-2218). Enter on a blank OrdNo opens the pending-order help (:2499-2526); picking one
 * fills the party and puts the open advance in OrdAmt, AdjAmt and PaidAmt (:2542-2560). PaidAmt is AdjAmt - KsarAmt
 * (:2447); a new row's PaiidAc is the book's cash account (:2255-2263). The tag grid below lists the tags the picked
 * orders hold; Save puts them back in stock.
 */
export default function OrderCancelPage() {
  const router = useRouter();
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(todayLocal());
  const [vchTime, setVchTime] = useState(clock());
  const [empCode, setEmpCode] = useState('');
  const [empName, setEmpName] = useState('');
  const [defaults, setDefaults] = useState({ paidAc: '', paidAcName: '' });
  const blankRow = useCallback(
    (): Row => ({
      ordNo: '',
      ordYear: '',
      ordBook: '',
      acCode: '',
      acName: '',
      itDesc: '',
      ordAmt: 0,
      adjAmt: '',
      kasarAmt: '',
      paidAc: defaults.paidAc,
      paidAcName: defaults.paidAcName,
    }),
    [defaults],
  );
  const [rows, setRows] = useState<Row[]>([]);
  const [tags, setTags] = useState<OrderTag[]>([]);
  const [pending, setPending] = useState<PendingOrder[]>([]);
  const [helpRow, setHelpRow] = useState<number | null>(null);
  const [loadedVch, setLoadedVch] = useState('');
  const [version, setVersion] = useState('');
  const [voucherLookup, setVoucherLookup] = useState('');
  const [savedVch, setSavedVch] = useState('');
  const [notice, setNotice] = useState('');
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const [openedTotal, setOpenedTotal] = useState(0);
  const grid = useRef<HTMLTableSectionElement | null>(null);
  // N52: one Idempotency-Key per draft, so a replayed save answers the first one instead of refunding twice.
  const command = useIdempotencyKey();

  const bookQuery = `coBook=${encodeURIComponent(coBook)}`;
  const totals = {
    ord: r2(rows.reduce((s, r) => s + n(r.ordAmt), 0)),
    adj: r2(rows.reduce((s, r) => s + n(r.adjAmt), 0)),
    kasar: r2(rows.reduce((s, r) => s + n(r.kasarAmt), 0)),
    paid: r2(rows.reduce((s, r) => s + paidOf(r), 0)),
  };
  const filled = rows.filter((r) => r.ordNo.trim());
  const canSave = !!coBook && filled.length > 0;

  useEffect(() => {
    if (!coBook) return;
    get<{ paidAc: string; paidAcName: string }>(`/order-cancel/defaults?${bookQuery}`)
      .then(setDefaults)
      .catch(() => setDefaults({ paidAc: '', paidAcName: '' }));
  }, [coBook, bookQuery]);
  useEffect(() => {
    // A row the operator has not touched takes the book's refund account once it is known.
    setRows((rs) =>
      rs.length
        ? rs.map((r) =>
            !r.ordNo && !r.paidAc
              ? { ...r, paidAc: defaults.paidAc, paidAcName: defaults.paidAcName }
              : r,
          )
        : [blankRow()],
    );
  }, [blankRow, defaults]);

  const cell = (row: number, column: string) =>
    grid.current?.querySelector<HTMLInputElement>(`[data-cell="${column}-${row}"]`) ?? null;
  const focusCell = (row: number, column: string) =>
    // The row may only appear in the next render (a new last row), so look again for a short while.
    (function attempt(left: number) {
      const found = cell(row, column);
      const el = found?.matches('input') ? found : found?.querySelector('input');
      if (!el && left > 0) return void setTimeout(() => attempt(left - 1), 20);
      el?.focus();
      el?.select?.();
    })(10);
  const setRow = (i: number, patch: Partial<Row>) =>
    setRows((rs) => rs.map((r, j) => (j === i ? { ...r, ...patch } : r)));

  function resetForm() {
    setLoadedVch('');
    setVersion('');
    setVoucherLookup('');
    setRows([blankRow()]);
    setTags([]);
    setVchDate(todayLocal());
    setVchTime(clock());
    setEmpCode('');
    setEmpName('');
    setHelpRow(null);
    setErr('');
    setOpenedTotal(0);
  }

  async function openHelp(i: number) {
    setErr('');
    try {
      setPending(await get<PendingOrder[]>(`/order-cancel/pending-orders?${bookQuery}`));
      setHelpRow(i);
    } catch (e) {
      setErr(errorText(e, 'failed to load the pending orders'));
    }
  }

  function pickOrder(order: PendingOrder) {
    const i = helpRow ?? 0;
    // :2542-2560: OrdAmt, AdjAmt and (when blank) PaidAmt take the advance still open.
    setRows((rs) =>
      rs.map((r, j) =>
        j === i
          ? {
              ...r,
              ordNo: order.ordNo,
              ordYear: order.ordYear,
              ordBook: order.ordBook,
              acCode: order.acCode,
              acName: order.acName,
              ordAmt: order.openAmt,
              adjAmt: f2(order.openAmt),
              kasarAmt: r.kasarAmt || '0.00',
            }
          : r,
      ),
    );
    setTags((ts) => {
      const others = ts.filter((t) => t.ordNo !== order.ordNo);
      return [...others, ...order.tags].map((t, k) => ({ ...t, srNo: k + 1 }));
    });
    setHelpRow(null);
    focusCell(i, 'desc');
  }

  function nextRow(i: number) {
    if (i === rows.length - 1) setRows((rs) => [...rs, blankRow()]);
    focusCell(i + 1, 'ord');
  }

  function removeRow(i: number) {
    // The desktop's grid row prompt (TR_SL_ORD_ADJ.cs:1841).
    if (!window.confirm('This Row Record will Removed permantley ?')) return;
    const gone = rows[i]?.ordNo;
    setRows((rs) => (rs.length > 1 ? rs.filter((_, j) => j !== i) : [blankRow()]));
    if (gone && !rows.some((r, j) => j !== i && r.ordNo === gone))
      setTags((ts) => ts.filter((t) => t.ordNo !== gone).map((t, k) => ({ ...t, srNo: k + 1 })));
  }

  /** TEXT_ENTRY_KeyDown (:2481-2850): Enter walks OrdNo, It Desc, AdjAmt, KsarAmt, PaiidAc, then the next row. */
  function onCellKey(e: React.KeyboardEvent, i: number, column: string) {
    // The account picker took the key itself (it picked from its open list).
    if (e.defaultPrevented) return;
    if (e.ctrlKey && (e.key === 'd' || e.key === 'D')) {
      e.preventDefault();
      removeRow(i);
      return;
    }
    if (e.key === 'F1' && column === 'ord') {
      e.preventDefault();
      void openHelp(i);
      return;
    }
    if (e.key !== 'Enter') return;
    e.preventDefault();
    const row = rows[i]!;
    if (column === 'ord') {
      if (!row.acCode) void openHelp(i);
      else focusCell(i, 'desc');
    } else if (column === 'desc') focusCell(i, 'adj');
    // :2733 — Enter on a zero AdjAmt stays in the cell.
    else if (column === 'adj') {
      if (n(row.adjAmt) !== 0) focusCell(i, 'kasar');
    } else if (column === 'kasar') focusCell(i, 'paidac');
    else if (column === 'paidac') nextRow(i);
  }

  async function loadVoucher(vchNo: string): Promise<boolean> {
    setErr('');
    setNotice('');
    setSavedVch('');
    try {
      const d = await get<any>(`/order-cancel/${encodeURIComponent(vchNo)}?${bookQuery}`);
      const no = String(d.voucherNo ?? vchNo);
      setLoadedVch(no);
      setVoucherLookup(no);
      setVersion(String(d.version ?? ''));
      const loaded: Row[] = (d.rows ?? []).map((r: any) => ({
        ordNo: String(r.ordNo ?? ''),
        ordYear: String(r.ordYear ?? ''),
        ordBook: String(r.ordBook ?? ''),
        acCode: String(r.acCode ?? ''),
        acName: String(r.acName ?? ''),
        itDesc: String(r.itDesc ?? ''),
        ordAmt: n(r.ordAmt),
        adjAmt: f2(n(r.adjAmt)),
        kasarAmt: f2(n(r.kasarAmt)),
        paidAc: String(r.paidAc ?? ''),
        paidAcName: String(r.paidAcName ?? ''),
      }));
      setRows(loaded.length ? loaded : [blankRow()]);
      setTags(d.tags ?? []);
      setEmpCode(String(d.empCode ?? ''));
      setEmpName(String(d.empName ?? ''));
      setVchDate(toIsoDate(d.vchDate ?? todayLocal()));
      setOpenedTotal(r2(loaded.reduce((s, r) => s + r.ordAmt + n(r.adjAmt), 0)));
      return true;
    } catch (e) {
      setErr(errorText(e, 'failed to load'));
      return false;
    }
  }

  // tVchNo_KeyDown (:3951-3977): F1 lists the vouchers, Up/Down step through them, Enter opens one.
  const numberKeys = useVoucherNumberKeys({
    table: 'SL_ORD_ADJ',
    book: coBook,
    value: voucherLookup,
    open: (vchNo) => loadVoucher(vchNo),
    fresh: resetForm,
  });

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setNotice('');
    setSavedVch('');
    setBusy(true);
    try {
      const body = {
        coBook,
        coYear,
        lcCode,
        vchDate,
        empCode: empCode.trim(),
        ...(loadedVch ? { expectedVersion: version } : {}),
        rows: filled.map((r) => ({
          ordNo: r.ordNo.trim(),
          ...(r.ordYear ? { ordYear: r.ordYear } : {}),
          ...(r.ordBook ? { ordBook: r.ordBook } : {}),
          adjAmt: r2(n(r.adjAmt)),
          kasarAmt: r2(n(r.kasarAmt)),
          paidAmt: paidOf(r),
          paidAc: r.paidAc.trim(),
          itDesc: r.itDesc,
        })),
      };
      const saved = loadedVch
        ? await put<{ vchNo: number }>(`/order-cancel/${encodeURIComponent(loadedVch)}`, body)
        : await postCommand<{ vchNo: number }>('/order-cancel', body, command.key);
      if (!loadedVch) command.renew();
      const no = String(saved.vchNo).padStart(5, '0');
      resetForm();
      setSavedVch(no);
      setNotice(`${loadedVch ? 'Updated' : 'Posted'} — Order Cancel #${saved.vchNo}`);
    } catch (e) {
      setErr(errorText(e, 'failed'));
    } finally {
      setBusy(false);
    }
  }

  async function removeVoucher() {
    // BtnDelete_Click (:3741, :3753).
    if (!loadedVch || !window.confirm('Are You Sure To Delete This Voucher now?')) return;
    setBusy(true);
    setErr('');
    try {
      await del(`/order-cancel/${encodeURIComponent(loadedVch)}?${bookQuery}`, {
        expectedVersion: version,
      });
      resetForm();
      setNotice('Delete Success.');
    } catch (e) {
      setErr(errorText(e, 'delete failed'));
    } finally {
      setBusy(false);
    }
  }

  /** TR_SL_ORD_ADJ_KeyDown (:3758-3790): Esc closes the form when the totals are what it opened with. */
  function onScreenKeyDown(event: ScreenKeyEvent) {
    if (event.defaultPrevented || event.key !== 'Escape') return;
    const target = event.target as HTMLElement;
    if (target.closest?.('[data-lookup-open="true"]')) return;
    if (target.closest?.('[data-cell]')) {
      event.preventDefault();
      document.getElementById('order-cancel-emp')?.querySelector('input')?.focus();
      return;
    }
    if (r2(totals.ord + totals.adj) === openedTotal) {
      event.preventDefault();
      router.back();
    }
  }
  const screenRef = useScreenEscape<HTMLDivElement>(onScreenKeyDown);
  const printHref = (v: string) =>
    `/api/order-cancel/${encodeURIComponent(v)}/print?${bookQuery}&format=html`;

  return (
    <div ref={screenRef} onKeyDown={onScreenKeyDown}>
      <h1>Order Cancel</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label htmlFor="order-cancel-vch-no">Vch No</label>
              <input
                id="order-cancel-vch-no"
                value={voucherLookup}
                onChange={(e) => setVoucherLookup(e.target.value)}
                onKeyDown={numberKeys.onKeyDown}
                placeholder="new"
                style={{ width: 90 }}
              />
              <VoucherNumberNote note={numberKeys.note} />
            </div>
            <div className="field">
              <label>Book</label>
              <BookSelect
                value={coBook}
                onChange={setCoBook}
                preferred="ORC"
                mainBooks={ORDER_CANCEL_MAIN_BOOKS}
              />
            </div>
            <div className="field">
              <label htmlFor="order-cancel-date">Vch Date</label>
              <input
                id="order-cancel-date"
                type="date"
                ref={numberKeys.dateRef}
                value={vchDate}
                onChange={(e) => setVchDate(e.target.value)}
                onKeyDown={(e) => {
                  if (e.key === 'Enter') {
                    e.preventDefault();
                    focusCell(0, 'ord');
                  }
                }}
              />
            </div>
            <div className="field">
              <label htmlFor="order-cancel-time">Time</label>
              <input id="order-cancel-time" value={vchTime} readOnly style={{ width: 90 }} />
            </div>
            <div className="field">
              <label htmlFor="order-cancel-day">Day</label>
              <input
                id="order-cancel-day"
                value={weekday(vchDate)}
                readOnly
                style={{ width: 110 }}
              />
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <table className="grid" aria-label="Orders to cancel">
            <thead>
              <tr>
                <th>Sr</th>
                <th>OrdNo</th>
                <th>AcCode</th>
                <th>Ac Name</th>
                <th>It Desc</th>
                <th className="num">OrdAmt</th>
                <th className="num">AdjAmt</th>
                <th className="num">KsarAmt</th>
                <th className="num">PaidAmt</th>
                <th>PaiidAc</th>
                <th>Paid Ac Name</th>
              </tr>
            </thead>
            <tbody ref={grid}>
              {rows.map((r, i) => (
                <OrderCancelGridRow
                  key={i}
                  row={r}
                  index={i}
                  setRow={setRow}
                  onCellKey={onCellKey}
                />
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td colSpan={3}></td>
                <td style={{ fontWeight: 600 }}>Total :</td>
                <td></td>
                <td className="num" aria-label="OrdAmt total">
                  {f2(totals.ord)}
                </td>
                <td className="num" aria-label="AdjAmt total">
                  {f2(totals.adj)}
                </td>
                <td className="num" aria-label="KsarAmt total">
                  {f2(totals.kasar)}
                </td>
                <td className="num" aria-label="PaidAmt total">
                  {f2(totals.paid)}
                </td>
                <td colSpan={2}></td>
              </tr>
            </tfoot>
          </table>
          <div className="toolbar" style={{ marginTop: 8 }}>
            <button type="button" className="ghost" onClick={() => void openHelp(rows.length - 1)}>
              Pending orders (F1)
            </button>
            <button type="button" className="ghost" onClick={() => nextRow(rows.length - 1)}>
              + Add line
            </button>
          </div>
        </div>

        {helpRow !== null && (
          <OrderCancelOrderHelp
            orders={pending.filter(
              (o) =>
                !rows.some(
                  (r, j) => j !== helpRow && r.ordNo === o.ordNo && r.ordBook === o.ordBook,
                ),
            )}
            onPick={pickOrder}
            onClose={() => {
              setHelpRow(null);
              focusCell(helpRow, 'ord');
            }}
          />
        )}

        <OrderCancelTagGrid tags={tags} />

        <div className="panel">
          <div className="row">
            <div className="field" style={{ flex: 2 }} id="order-cancel-emp">
              <label>Employee</label>
              <LookupPicker
                entity="employees"
                value={empCode}
                onChange={(code) => {
                  setEmpCode(code);
                  setEmpName('');
                }}
                onPick={(picked) => setEmpName(String(picked.name || ''))}
                ariaLabel="Employee"
                placeholder="search employees…"
                resolveTypedCode
              />
              {empName && (
                <span className="muted" style={{ fontSize: 12 }}>
                  {empName}
                </span>
              )}
            </div>
            <span className="spacer" />
            {loadedVch && (
              <a className="button" href={printHref(loadedVch)} target="_blank" rel="noreferrer">
                Print
              </a>
            )}
            <button type="button" onClick={resetForm} disabled={busy}>
              Cancel
            </button>
            {loadedVch && (
              <button
                type="button"
                className="danger"
                onClick={() => void removeVoucher()}
                disabled={busy}
              >
                Delete
              </button>
            )}
            <button className="primary" data-save-mnemonic disabled={busy || !canSave}>
              {busy ? 'Saving…' : loadedVch ? `Update #${loadedVch}` : 'Save Order Cancel'}
            </button>
          </div>
        </div>
      </form>

      {err && (
        <div className="msg err" role="alert">
          {err}
        </div>
      )}
      {notice && (
        <div className="msg ok" role="status">
          {notice}
          {savedVch && (
            <>
              {' '}
              <a href={printHref(savedVch)} target="_blank" rel="noreferrer">
                Print
              </a>
            </>
          )}
        </div>
      )}
      {coBook && (
        <VoucherList
          table="SL_ORD_ADJ"
          book={coBook}
          onLoad={(vchNo) => void loadVoucher(vchNo)}
          openKey={numberKeys.listKey}
          printHref={printHref}
          reloadKey={notice}
        />
      )}
    </div>
  );
}
