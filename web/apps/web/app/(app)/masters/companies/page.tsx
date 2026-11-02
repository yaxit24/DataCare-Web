'use client';
import { useEffect, useMemo, useRef, useState, type KeyboardEvent } from 'react';
import { get, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';

/**
 * Company milestone 1 is deliberately read-only. The desktop lists and opens CO_MAST rows
 * (MS_COMPANY.cs:5704-6001), but Save hands a new company to Year Create and its copied master set
 * (:6022-6227; MS_YEAR.cs:1170-1400,1504-1595). Until that identity/provisioning command is atomic,
 * this page uses only the existing tenant-scoped company context read.
 */
interface Company {
  CO_CODE: string;
  CO_NAME: string | null;
}

const errorText = (error: unknown) =>
  error instanceof ApiError
    ? String(error.body?.message || error.body?.error || error.message)
    : String((error as Error)?.message ?? error);

export default function CompanyPage() {
  const { coCode } = useBusinessScope();
  const [companies, setCompanies] = useState<Company[]>([]);
  const [selected, setSelected] = useState('');
  const [search, setSearch] = useState('');
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(true);
  const rowRefs = useRef<Array<HTMLTableRowElement | null>>([]);

  useEffect(() => {
    let active = true;
    get<Company[]>('/context/companies')
      .then((rows) => {
        if (!active) return;
        setCompanies(rows);
        setSelected(rows.some((row) => row.CO_CODE === coCode) ? coCode : (rows[0]?.CO_CODE ?? ''));
      })
      .catch((reason) => active && setError(errorText(reason)))
      .finally(() => active && setLoading(false));
    return () => {
      active = false;
    };
  }, [coCode]);

  const shown = useMemo(() => {
    const wanted = search.trim().toLocaleUpperCase();
    if (!wanted) return companies;
    return companies.filter(
      (company) =>
        company.CO_CODE.toLocaleUpperCase().includes(wanted) ||
        (company.CO_NAME ?? '').toLocaleUpperCase().includes(wanted),
    );
  }, [companies, search]);
  const detail = companies.find((company) => company.CO_CODE === selected) ?? null;

  function rowKey(event: KeyboardEvent<HTMLTableRowElement>, index: number) {
    if (event.key === 'Enter' || event.key === ' ') {
      event.preventDefault();
      setSelected(shown[index]?.CO_CODE ?? '');
      return;
    }
    const next = event.key === 'ArrowDown' ? index + 1 : event.key === 'ArrowUp' ? index - 1 : -1;
    if (next < 0 || next >= shown.length) return;
    event.preventDefault();
    setSelected(shown[next]?.CO_CODE ?? '');
    rowRefs.current[next]?.focus();
  }

  return (
    <main>
      <h1>Company</h1>
      <div className="msg" role="status" data-testid="company-read-only-notice">
        Company create, edit, provisioning, print, and safe deletion are moving to the dedicated
        desktop-parity workflow. This milestone is read-only.
      </div>
      {error && (
        <div className="msg err" role="alert">
          {error}
        </div>
      )}
      <div className="row" style={{ alignItems: 'stretch' }}>
        <section className="panel" style={{ flex: '1 1 420px' }} aria-label="Company list">
          <div className="field">
            <label htmlFor="company-search">Search company</label>
            <input
              id="company-search"
              autoFocus
              value={search}
              onChange={(event) => setSearch(event.target.value)}
              placeholder="Code or name"
            />
          </div>
          <div style={{ maxHeight: 420, overflow: 'auto' }}>
            <table className="grid" data-testid="company-list">
              <thead>
                <tr>
                  <th>Code</th>
                  <th>Name</th>
                </tr>
              </thead>
              <tbody>
                {shown.map((company, index) => {
                  const current = company.CO_CODE === coCode;
                  const chosen = company.CO_CODE === selected;
                  return (
                    <tr
                      key={company.CO_CODE}
                      ref={(node) => {
                        rowRefs.current[index] = node;
                      }}
                      data-code={company.CO_CODE}
                      tabIndex={chosen ? 0 : -1}
                      aria-selected={chosen}
                      onClick={() => setSelected(company.CO_CODE)}
                      onKeyDown={(event) => rowKey(event, index)}
                      style={{
                        cursor: 'pointer',
                        outline: chosen ? '2px solid var(--accent)' : undefined,
                      }}
                    >
                      <td>{company.CO_CODE}</td>
                      <td>
                        {company.CO_NAME || '—'} {current && <strong>(Current)</strong>}
                      </td>
                    </tr>
                  );
                })}
                {!loading && shown.length === 0 && (
                  <tr>
                    <td colSpan={2} className="muted">
                      No companies match the search.
                    </td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
          {loading && <p className="muted">Loading companies…</p>}
        </section>

        <section className="panel" style={{ flex: '1 1 320px' }} aria-label="Selected company">
          <h2>Read-only details</h2>
          <div className="field">
            <label htmlFor="company-code">Code</label>
            <input id="company-code" value={detail?.CO_CODE ?? ''} readOnly />
          </div>
          <div className="field">
            <label htmlFor="company-name">Name</label>
            <input id="company-name" value={detail?.CO_NAME ?? ''} readOnly />
          </div>
          <div className="field">
            <label htmlFor="current-company">Current company identity</label>
            <input
              id="current-company"
              value={
                detail
                  ? detail.CO_CODE === coCode
                    ? 'Current session company'
                    : `Current session: ${coCode}`
                  : coCode
              }
              readOnly
            />
          </div>
          <p className="muted">
            Only Code and Name are available from the safe company-context read API. Rich identity
            fields are not shown as placeholders.
          </p>
        </section>
      </div>
    </main>
  );
}
