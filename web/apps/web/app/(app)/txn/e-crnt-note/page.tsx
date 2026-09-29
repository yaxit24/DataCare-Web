'use client';

import { useEffect, useRef, useState } from 'react';
import { ApiError, get, post } from '../../../../lib/api';
import { BookSelect } from '../../../../components/BookSelect';
import { useBusinessScope } from '../../../../components/BusinessScope';
import {
  creditNoteComponents,
  creditNoteLabels,
  creditNoteValue,
  type CreditNoteDocument,
  type CreditNoteRow,
} from '../../../../lib/creditNoteView';
import { EBillEntry } from '../../../../components/EBillEntry';

type Browse = { rows: CreditNoteRow[]; hasMore: boolean; offset: number; limit: number };
type GspStatus = { mode: string; provider: string; configured: boolean };
type ScopedResult<T> = { scopeKey: string; value: T };
const errorMessage = (error: unknown) =>
  error instanceof ApiError
    ? error.body?.message || error.body?.detail || error.message
    : error instanceof Error
      ? error.message
      : 'Request failed';

function Fields({ row }: { row: CreditNoteRow }) {
  return (
    <dl className="row" style={{ gap: 16, flexWrap: 'wrap' }}>
      {Object.entries(creditNoteLabels)
        .filter(([key]) => Object.hasOwn(row, key))
        .map(([key, label]) => (
          <div key={key} style={{ minWidth: 150, maxWidth: 350 }}>
            <dt className="muted">{label}</dt>
            <dd style={{ margin: 0, overflowWrap: 'anywhere' }}>{creditNoteValue(row[key])}</dd>
          </div>
        ))}
    </dl>
  );
}

export default function ECrntNotePage() {
  const { coCode, lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchNo, setVchNo] = useState('');
  const [search, setSearch] = useState('');
  const [savedBrowse, setBrowse] = useState<ScopedResult<Browse> | null>(null);
  const [savedDocument, setDocument] = useState<ScopedResult<CreditNoteDocument> | null>(null);
  const [busy, setBusy] = useState(false);
  const [message, setMessage] = useState('');
  const [gsp, setGsp] = useState<GspStatus | null>(null);
  const [editVoucher, setEditVoucher] = useState<{ no: string; seq: number } | null>(null);
  const generation = useRef(0);
  const query = new URLSearchParams({ coBook, coYear });
  const scopeKey = JSON.stringify([coCode, lcCode, coYear, coBook]);
  // Hide an old scope in the same render as a scope change. The effect below also
  // clears state and invalidates in-flight requests, but must not be the action barrier.
  const browse = savedBrowse?.scopeKey === scopeKey ? savedBrowse.value : null;
  const document = savedDocument?.scopeKey === scopeKey ? savedDocument.value : null;

  useEffect(() => {
    generation.current += 1;
    setDocument(null);
    setBrowse(null);
    setMessage('');
    setBusy(false);
    setEditVoucher(null);
  }, [coCode, lcCode, coYear, coBook]);

  useEffect(() => {
    let active = true;
    get<GspStatus>('/e-credit-notes/provider')
      .then((value) => {
        if (active) setGsp(value);
      })
      .catch(() => {
        if (active) setGsp(null);
      });
    return () => {
      active = false;
    };
  }, [coCode, lcCode]);

  async function execute(task: (current: number) => Promise<void>) {
    const current = ++generation.current;
    setBusy(true);
    setMessage('');
    try {
      await task(current);
    } catch (error) {
      if (current === generation.current) setMessage(errorMessage(error));
    } finally {
      if (current === generation.current) setBusy(false);
    }
  }
  async function load(number: string) {
    await execute(async (current) => {
      setDocument(null);
      const result = await get<CreditNoteDocument>(
        `/e-credit-notes/${encodeURIComponent(number)}?${query}`,
      );
      if (current !== generation.current) return;
      setDocument({ scopeKey, value: result });
      setVchNo(String(result.header.VCH_NO));
    });
  }
  async function find(offset = 0) {
    await execute(async (current) => {
      const params = new URLSearchParams(query);
      params.set('search', search);
      params.set('offset', String(offset));
      const result = await get<Browse>(`/e-credit-notes?${params}`);
      if (current === generation.current) setBrowse({ scopeKey, value: result });
    });
  }
  async function register() {
    if (!document) return;
    const savedNumber = String(document.header.VCH_NO);
    await execute(async (current) => {
      const result = await post<{ mode: string }>('/einvoice/credit-note/irn', {
        coBook,
        coYear,
        vchNo: savedNumber,
      });
      const refreshed = await get<CreditNoteDocument>(
        `/e-credit-notes/${encodeURIComponent(savedNumber)}?${query}`,
      );
      if (current !== generation.current) return;
      setDocument({ scopeKey, value: refreshed });
      setMessage(`Credit-note IRN generated (${result.mode}).`);
    });
  }
  const registered = String(document?.header.IRN_NO ?? '').trim().length > 10;

  return (
    <div>
      <h1>E CrntNote</h1>
      <p className="muted">
        Enter, edit, delete and print E CRNT credit notes; browse and review saved credit notes,
        then generate an IRN for the selected voucher.
      </p>
      <div className="panel">
        <div className="row">
          <div className="field">
            <label>Book</label>
            <BookSelect
              key={`${coCode}/${lcCode}`}
              value={coBook}
              onChange={setCoBook}
              mainBooks={['E CRNT']}
              preferred="146"
              disabled={busy}
            />
          </div>
          <div className="field">
            <label htmlFor="credit-year">Year</label>
            <input id="credit-year" value={coYear} readOnly />
          </div>
          <div className="field">
            <label htmlFor="credit-number">Voucher number</label>
            <input
              id="credit-number"
              value={vchNo}
              onChange={(event) => setVchNo(event.target.value)}
            />
          </div>
          <button
            type="button"
            disabled={busy || !coBook || !vchNo.trim()}
            onClick={() => void load(vchNo.trim())}
          >
            Open credit note
          </button>
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
            <label htmlFor="credit-search">Find customer, bill or voucher</label>
            <input
              id="credit-search"
              maxLength={100}
              value={search}
              onChange={(event) => setSearch(event.target.value)}
            />
          </div>
          <button disabled={busy || !coBook}>Browse credit notes</button>
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
      {browse && (
        <div className="panel" style={{ overflowX: 'auto' }}>
          <table>
            <caption>Credit notes in the selected book and year</caption>
            <thead>
              <tr>
                {['Voucher', 'Date', 'Customer', 'Bill reference', 'Total', 'IRN', 'Action'].map(
                  (label) => (
                    <th key={label}>{label}</th>
                  ),
                )}
              </tr>
            </thead>
            <tbody>
              {browse.rows.map((row, index) => (
                <tr key={`${row.VCH_NO}/${index}`}>
                  <td>{String(row.VCH_NO ?? '')}</td>
                  <td>{String(row.VCH_DATE ?? '')}</td>
                  <td>{String(row.AC_NAME ?? '')}</td>
                  <td>{String(row.BILL_NO ?? '')}</td>
                  <td>{creditNoteValue(row.TOT_AMT)}</td>
                  <td>
                    {String(row.IRN_NO ?? '').trim().length > 10 ? 'Generated' : 'Not generated'}
                  </td>
                  <td>
                    <button disabled={busy} onClick={() => void load(String(row.VCH_NO))}>
                      Open {String(row.VCH_NO)}
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          {!browse.rows.length && <p>No credit notes match this search.</p>}
          <button
            disabled={busy || browse.offset === 0}
            onClick={() => void find(Math.max(0, browse.offset - browse.limit))}
          >
            Previous
          </button>{' '}
          <button
            disabled={busy || !browse.hasMore}
            onClick={() => void find(browse.offset + browse.limit)}
          >
            Next
          </button>
        </div>
      )}
      {document && (
        <section aria-label="Saved credit note">
          <div className="panel">
            <h2>Credit note {String(document.header.VCH_NO)}</h2>
            <Fields row={document.header} />
            <button
              className="primary"
              disabled={busy || registered}
              onClick={() => void register()}
            >
              {registered ? 'IRN already generated' : 'Generate CRN IRN'}
            </button>{' '}
            <button
              disabled={busy}
              onClick={() =>
                setEditVoucher((current) => ({
                  no: String(document.header.VCH_NO),
                  seq: (current?.seq ?? 0) + 1,
                }))
              }
            >
              Edit in entry form
            </button>
            {document.registration && <Fields row={document.registration} />}
          </div>
          <h2>Items and components</h2>
          {!document.lines.length && <p>No item lines are recorded.</p>}
          {document.lines.map((line) => (
            <details className="panel" key={String(line.SR_NO)} open>
              <summary>
                Item {String(line.SR_NO)} · {String(line.IT_CODE ?? '')} ·{' '}
                {String(line.DESIGN_NO ?? '')}
              </summary>
              <Fields row={line} />
              {creditNoteComponents(document, line).map((component) => (
                <details key={String(component.ISR_NO)}>
                  <summary>
                    Component {String(component.ISR_NO)} ·{' '}
                    {String(component.DM_NAME ?? component.IT_CODE ?? '')}
                  </summary>
                  <Fields row={component} />
                </details>
              ))}
            </details>
          ))}
        </section>
      )}
      <EBillEntry
        family="E CRNT"
        key={scopeKey}
        coBook={coBook}
        coYear={coYear}
        scopeKey={scopeKey}
        editVoucherNo={editVoucher ? `${editVoucher.no}#${editVoucher.seq}` : null}
        onSaved={(number) => void load(number)}
        onDeleted={() => {
          setDocument(null);
          setBrowse(null);
        }}
      />
    </div>
  );
}
