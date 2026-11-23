'use client';
import { useEffect, useState } from 'react';
import { oldMetalTodayRates } from '@datacare/core';
import { get, post, ApiError } from '../lib/api';
import { openDocument } from '../lib/openDocument';
import {
  duplicateOrderMessage,
  sumRows,
  type CreditNoteRow,
  type OrderRow,
  type SaleResidual,
  type UpiRow,
} from '../lib/saleResidual';

/**
 * WP-26 (N243, G255): the Sales Invoice tender and source grids of TR_SALE (`MSG_UPI`, `MSG_CRNT`, `MSG_ORD`), the
 * member-commission header, and the print-file choice. The grids feed the header totals the page shows: UPI is the
 * sum of rows with an account (TR_SALE.cs:6862-6867), the credit note and the advance the sums of their rows.
 */
const ROW_DELETE = 'This Row Record will Removed permantley ?'; // TR_SALE.cs:7539
const SAVE_TO_EFFECT = 'Please Save This Voucher Then Effect....'; // TR_SALE.cs:6921

export function SaleResidualPanel({
  value,
  onChange,
}: {
  value: SaleResidual;
  onChange: (next: SaleResidual, totals: { upi: number; credit: number; advance: number }) => void;
}) {
  const [upiTypeAdd, setUpiTypeAdd] = useState(false);
  const [message, setMessage] = useState('');
  const emit = (next: SaleResidual) =>
    onChange(next, {
      upi: sumRows(next.upiRows.filter((r) => r.acCode.trim() !== '')),
      credit: sumRows(next.creditNotes),
      advance: sumRows(next.orders),
    });
  const setUpi = (i: number, patch: Partial<UpiRow>) =>
    emit({ ...value, upiRows: value.upiRows.map((r, j) => (j === i ? { ...r, ...patch } : r)) });
  const setCredit = (i: number, patch: Partial<CreditNoteRow>) =>
    emit({
      ...value,
      creditNotes: value.creditNotes.map((r, j) => (j === i ? { ...r, ...patch } : r)),
    });
  const setOrder = (i: number, patch: Partial<OrderRow>) => {
    const orders = value.orders.map((r, j) => (j === i ? { ...r, ...patch } : r));
    const duplicate = duplicateOrderMessage(orders, i);
    if (duplicate) {
      setMessage(duplicate);
      return emit({ ...value, orders: orders.map((r, j) => (j === i ? { ...r, ordNo: '' } : r)) });
    }
    emit({ ...value, orders });
  };
  // Ctrl+D on a UPI row: confirm, clear the row, recompute; the database changes only at Save (TR_SALE.cs:6907-6921).
  const upiKey = (i: number, col: number) => (e: React.KeyboardEvent) => {
    if (e.key === 'F1' && col === 3) {
      e.preventDefault();
      setUpiTypeAdd(true); // TR_SALE.cs:6901-6903
    } else if (e.ctrlKey && (e.key === 'd' || e.key === 'D')) {
      e.preventDefault();
      if (!window.confirm(ROW_DELETE)) return;
      emit({ ...value, upiRows: value.upiRows.filter((_, j) => j !== i) });
      setMessage(SAVE_TO_EFFECT);
    }
  };
  const cell = (
    label: string,
    v: string,
    set: (x: string) => void,
    onKeyDown?: (e: React.KeyboardEvent) => void,
  ) => (
    <td>
      <input
        aria-label={label}
        value={v}
        onChange={(e) => set(e.target.value)}
        onKeyDown={onKeyDown}
      />
    </td>
  );
  return (
    <div className="panel">
      <h2>Tender and source</h2>
      <div className="row">
        <div className="field">
          <label>Memb Ac</label>
          <input
            aria-label="Memb Ac"
            value={value.memberCommissionAc}
            maxLength={10}
            onChange={(e) => emit({ ...value, memberCommissionAc: e.target.value.toUpperCase() })}
          />
        </div>
        <label className="field">
          <input
            type="checkbox"
            aria-label="Without Comm Bill"
            checked={value.withoutCommissionBill}
            onChange={(e) => emit({ ...value, withoutCommissionBill: e.target.checked })}
          />{' '}
          Without Comm Bill
        </label>
      </div>
      {message && (
        <p role="status" className="muted">
          {message}
        </p>
      )}
      <table>
        <caption>UPI {upiTypeAdd ? '(add type)' : ''}</caption>
        <tbody>
          {value.upiRows.map((r, i) => (
            <tr key={`upi-${i}`}>
              {cell(
                `UPI AcCode line ${i + 1}`,
                r.acCode,
                (x) => setUpi(i, { acCode: x.toUpperCase() }),
                upiKey(i, 1),
              )}
              {cell(
                `UPI Name line ${i + 1}`,
                r.acName,
                (x) => setUpi(i, { acName: x }),
                upiKey(i, 2),
              )}
              {cell(`UPI Type line ${i + 1}`, r.type, (x) => setUpi(i, { type: x }), upiKey(i, 3))}
              {cell(`UPI Id line ${i + 1}`, r.upiId, (x) => setUpi(i, { upiId: x }), upiKey(i, 4))}
              {cell(
                `UPI Amt line ${i + 1}`,
                r.amount,
                (x) => setUpi(i, { amount: x }),
                upiKey(i, 5),
              )}
            </tr>
          ))}
        </tbody>
      </table>
      <button
        type="button"
        className="ghost"
        onClick={() =>
          emit({
            ...value,
            upiRows: [
              ...value.upiRows,
              { acCode: '', acName: '', type: '', upiId: '', amount: '' },
            ],
          })
        }
      >
        + UPI row
      </button>
      <table>
        <caption>Credit notes</caption>
        <tbody>
          {value.creditNotes.map((r, i) => (
            <tr key={`crnt-${i}`}>
              {cell(`Credit Note No line ${i + 1}`, r.crntNo, (x) => setCredit(i, { crntNo: x }))}
              {cell(`Credit Note Amt line ${i + 1}`, r.amount, (x) => setCredit(i, { amount: x }))}
              <td>
                <button
                  type="button"
                  className="danger"
                  aria-label={`Remove credit note line ${i + 1}`}
                  onClick={() =>
                    emit({ ...value, creditNotes: value.creditNotes.filter((_, j) => j !== i) })
                  }
                >
                  ×
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <button
        type="button"
        className="ghost"
        onClick={() =>
          emit({
            ...value,
            creditNotes: [...value.creditNotes, { crntNo: '', amount: '', rest: {} }],
          })
        }
      >
        + Credit note
      </button>
      <table>
        <caption>Order advance</caption>
        <tbody>
          {value.orders.map((r, i) => (
            <tr key={`ord-${i}`}>
              {cell(`Order No line ${i + 1}`, r.ordNo, (x) => setOrder(i, { ordNo: x }))}
              {cell(`Order Book line ${i + 1}`, r.ordBook, (x) =>
                setOrder(i, { ordBook: x.toUpperCase() }),
              )}
              {cell(`Order Amt line ${i + 1}`, r.amount, (x) => setOrder(i, { amount: x }))}
              <td>
                <button
                  type="button"
                  className="danger"
                  aria-label={`Remove order line ${i + 1}`}
                  onClick={() => emit({ ...value, orders: value.orders.filter((_, j) => j !== i) })}
                >
                  ×
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <button
        type="button"
        className="ghost"
        onClick={() =>
          emit({
            ...value,
            orders: [...value.orders, { ordNo: '', ordBook: 'SOR', amount: '', rest: {} }],
          })
        }
      >
        + Order
      </button>
    </div>
  );
}

/** Today's per-gram gold and silver rates for the old-metal touch back-calculation (TR_SALE.cs:20833, :20854). */
export function useOldMetalTodayRates(vchDate: string) {
  const [rates, setRates] = useState({ gold: 0, silver: 0 });
  useEffect(() => {
    let live = true;
    get<any>(`/rate?date=${encodeURIComponent(vchDate)}`)
      .then(
        (r) =>
          live &&
          setRates(
            oldMetalTodayRates({ fineGoldRate: r?.fineGold, fineSilverRate: r?.fineSilver }),
          ),
      )
      .catch(() => live && setRates({ gold: 0, silver: 0 }));
    return () => {
      live = false;
    };
  }, [vchDate]);
  return rates;
}

/**
 * The print-file choice (decision D6): the sale book's `PRINT_MAST` list with its default, "Set" to make the chosen
 * file the default, the HUID box, and Print (TR_SALE.cs:13933, :16482-16507, :20618-20625).
 */
export function SalePrintChoice({
  coBook,
  coYear,
  lcCode,
  vchNo,
}: {
  coBook: string;
  coYear: string;
  lcCode: string;
  vchNo: string;
}) {
  const [files, setFiles] = useState<string[]>(['']);
  const [file, setFile] = useState('');
  const [huid, setHuid] = useState(false);
  const [note, setNote] = useState('');
  const scope = `coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}`;
  useEffect(() => {
    if (!coBook) return;
    get<any>(`/sales/print-files?${scope}`)
      .then((r) => {
        setFiles(r.files ?? ['']);
        setFile(r.selected ?? '');
      })
      .catch(() => setFiles(['']));
  }, [scope, coBook]);
  const fail = (e: unknown) =>
    setNote(e instanceof ApiError && e.status === 403 ? 'You Have No Print Rights.....' : 'failed');
  return (
    <div className="row">
      <div className="field">
        <label>Print file</label>
        <select aria-label="Print file" value={file} onChange={(e) => setFile(e.target.value)}>
          {files.map((f) => (
            <option key={f || 'blank'} value={f}>
              {f}
            </option>
          ))}
        </select>
      </div>
      <button
        type="button"
        className="ghost"
        onClick={() =>
          post<any>(`/sales/print-files/default?${scope}`, { file })
            .then((r) => setNote(r.message))
            .catch(fail)
        }
      >
        Set
      </button>
      <label className="field">
        <input
          type="checkbox"
          aria-label="HUID print"
          checked={huid}
          onChange={(e) => setHuid(e.target.checked)}
        />{' '}
        HUID
      </label>
      <button
        type="button"
        disabled={!vchNo}
        onClick={() =>
          openDocument(
            `/api/sales/${encodeURIComponent(vchNo)}/print?${scope}&file=${encodeURIComponent(file)}&huid=${huid ? 1 : 0}&format=html&copy=O`,
          )
        }
      >
        Print file
      </button>
      {note && (
        <span role="status" className="muted">
          {note}
        </span>
      )}
    </div>
  );
}
