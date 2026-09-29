'use client';

import { useEffect, useRef, useState } from 'react';
import { ApiError, get } from '../../../../lib/api';
import { BookSelect } from '../../../../components/BookSelect';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { EBillEntry } from '../../../../components/EBillEntry';

type BrowseRow = {
  VCH_NO: string;
  VCH_DATE: string;
  BILL_NO: string;
  AC_CODE: string;
  AC_NAME: string;
  TOT_AMT: number | string;
  BILL_OS: number | string;
  IRN_NO: string | null;
};
type Browse = { rows: BrowseRow[]; hasMore: boolean; offset: number; limit: number };
type GspStatus = { mode: string; provider: string; configured: boolean };
const errorMessage = (error: unknown) =>
  error instanceof ApiError
    ? error.body?.message || error.body?.detail || error.message
    : error instanceof Error
      ? error.message
      : 'Request failed';
const money = (value: unknown) =>
  Number(value || 0).toLocaleString('en-IN', {
    minimumFractionDigits: 2,
    maximumFractionDigits: 2,
  });

/**
 * Desktop Transaction → E Invoice: TR_SL_EBILL in E INVOICE mode (card X15). Outward e-invoices are
 * entered, browsed, reopened, edited, deleted, printed and registered for an IRN here; the separate
 * Utilities → e-Invoice (IRN) screen keeps the export and GSP configuration tools.
 */
export default function EInvoicePage() {
  const { coCode, lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [search, setSearch] = useState('');
  const [browse, setBrowse] = useState<{ key: string; value: Browse } | null>(null);
  const [editVoucher, setEditVoucher] = useState<{ no: string; seq: number } | null>(null);
  const [busy, setBusy] = useState(false);
  const [message, setMessage] = useState('');
  const [gsp, setGsp] = useState<GspStatus | null>(null);
  const generation = useRef(0);
  const scopeKey = JSON.stringify([coCode, lcCode, coYear, coBook]);
  const query = new URLSearchParams({ coBook, coYear });
  const rows = browse?.key === scopeKey ? browse.value : null;

  useEffect(() => {
    generation.current += 1;
    setBrowse(null);
    setEditVoucher(null);
    setMessage('');
  }, [coCode, lcCode, coYear, coBook]);

  useEffect(() => {
    let active = true;
    get<GspStatus>('/e-credit-notes/provider')
      .then((value) => active && setGsp(value))
      .catch(() => active && setGsp(null));
    return () => {
      active = false;
    };
  }, [coCode, lcCode]);

  async function find(offset = 0) {
    const current = ++generation.current;
    setBusy(true);
    setMessage('');
    try {
      const params = new URLSearchParams(query);
      params.set('search', search);
      params.set('offset', String(offset));
      const value = await get<Browse>(`/e-invoices?${params}`);
      if (current === generation.current) setBrowse({ key: scopeKey, value });
    } catch (error) {
      if (current === generation.current) setMessage(errorMessage(error));
    } finally {
      if (current === generation.current) setBusy(false);
    }
  }
  const openVoucher = (voucherNo: string) =>
    setEditVoucher((current) => ({ no: voucherNo, seq: (current?.seq ?? 0) + 1 }));

  return (
    <div>
      <h1>E Invoice</h1>
      <p className="muted">
        Enter, edit, delete and print outward e-invoices (TR_SL_EBILL, E INVOICE books) with TCS and
        TDS, then generate or cancel the IRN.
      </p>
      <div className="panel">
        <div className="row">
          <div className="field">
            <label>Book</label>
            <BookSelect
              key={`${coCode}/${lcCode}`}
              value={coBook}
              onChange={setCoBook}
              mainBooks={['E INVOICE']}
              disabled={busy}
            />
          </div>
          <div className="field">
            <label htmlFor="einv-year">Year</label>
            <input id="einv-year" value={coYear} readOnly />
          </div>
        </div>
        <form
          onSubmit={(event) => {
            event.preventDefault();
            void find();
          }}
          className="row"
          style={{ marginTop: 12 }}
        >
          <div className="field">
            <label htmlFor="einv-search">Find customer, bill or voucher</label>
            <input
              id="einv-search"
              maxLength={100}
              value={search}
              onChange={(event) => setSearch(event.target.value)}
            />
          </div>
          <button disabled={busy || !coBook}>Browse e-invoices</button>
        </form>
        {gsp && (
          <p className="muted">
            IRN provider: {gsp.provider} · {gsp.mode}
          </p>
        )}
      </div>
      {message && (
        <p role="status" className="msg">
          {message}
        </p>
      )}
      {rows && (
        <div className="panel" style={{ overflowX: 'auto' }}>
          <table>
            <caption>E-invoices in the selected book and year</caption>
            <thead>
              <tr>
                {['Voucher', 'Date', 'Customer', 'Ref No', 'Total', 'Bill OS', 'IRN', 'Action'].map(
                  (label) => (
                    <th key={label}>{label}</th>
                  ),
                )}
              </tr>
            </thead>
            <tbody>
              {rows.rows.map((row, index) => (
                <tr key={`${row.VCH_NO}/${index}`}>
                  <td>{row.VCH_NO}</td>
                  <td>{row.VCH_DATE}</td>
                  <td>{row.AC_NAME}</td>
                  <td>{row.BILL_NO}</td>
                  <td>{money(row.TOT_AMT)}</td>
                  <td>{money(row.BILL_OS)}</td>
                  <td>
                    {String(row.IRN_NO ?? '').trim().length > 10 ? 'Generated' : 'Not generated'}
                  </td>
                  <td>
                    <button disabled={busy} onClick={() => openVoucher(String(row.VCH_NO))}>
                      Open {row.VCH_NO}
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          {!rows.rows.length && <p>No e-invoices match this search.</p>}
          <button
            disabled={busy || rows.offset === 0}
            onClick={() => void find(Math.max(0, rows.offset - rows.limit))}
          >
            Previous
          </button>{' '}
          <button
            disabled={busy || !rows.hasMore}
            onClick={() => void find(rows.offset + rows.limit)}
          >
            Next
          </button>
        </div>
      )}
      <EBillEntry
        key={scopeKey}
        family="E INVOICE"
        coBook={coBook}
        coYear={coYear}
        scopeKey={scopeKey}
        editVoucherNo={editVoucher ? `${editVoucher.no}#${editVoucher.seq}` : null}
        onSaved={() => void (rows ? find(rows.offset) : undefined)}
        onDeleted={() => void (rows ? find(rows.offset) : undefined)}
      />
    </div>
  );
}
