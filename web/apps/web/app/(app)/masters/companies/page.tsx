'use client';
import { useEffect, useRef, useState, type KeyboardEvent } from 'react';
import { flushSync } from 'react-dom';
import { get, post, put, del, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import {
  COMPANY_SECTIONS,
  companyEnterAction,
  companyFieldId,
  companyFieldKey,
} from '../../../../lib/companyMasterKeys';

// MS_COMPANY.cs:5882-5980,6074-6189. Integration credentials hidden by the desktop are not identity inputs: F1 or a
// double-click on the name opens them there (GroupBox1 e-invoice portal and ASP logins, pnlUae client secret,
// :6502-6521,7411-7421); the web keeps them off this screen, so F1 on the name does nothing here.
// Keyboard (lib/companyMasterKeys.ts): Enter walks the desktop order across the Company/Tax/Bank Detail sections
// to Save; Ctrl+O unlocks Company Type and disables Save until Enter there or on RTGS No (:6471-6476,6737-6746,
// 7279-7290); Ctrl+R shows the desktop's "Reset Compnay" box only as an explanation (:6477-6480).
const fields: [string, string, number][] = [
  ['CO_NAME', 'Name', 50],
  ['CO_ADD1', 'Address 1', 50],
  ['CO_ADD2', 'Address 2', 50],
  ['CO_ADD3', 'Address 3', 50],
  ['CO_COUNTRY', 'Country', 25],
  ['CO_STATE_CODE', 'State Code', 2],
  ['CO_STATE', 'State', 25],
  ['CO_CITY', 'City', 25],
  ['CO_PIN', 'Pin Code', 10],
  ['CO_PHONE', 'Phone', 15],
  ['CO_PHONE2', 'Phone 2', 15],
  ['CO_MOBILE', 'Mobile', 15],
  ['CO_MOBILE2', 'Mobile 2', 15],
  ['CO_MAIL', 'Email', 50],
  ['CO_JUD', 'Jurisdiction', 30],
  ['CO_GST_NO', 'GST No', 15],
  ['CO_CSTNO', 'CST No', 30],
  ['CO_PAN_NO', 'PAN No', 30],
  ['DHIRAN_NO', 'Dhiran No', 30],
  ['BANK_NAME', 'Bank Name', 50],
  ['BANK_AREA', 'Bank Area', 40],
  ['BANK_AC_NO', 'Bank Account No', 30],
  ['BANK_RTGS_NO', 'RTGS No', 30],
  ['CO_TYPE', 'Company Type', 1],
];
const selects: [string, string, string[]][] = [
  ['REP_ADD_TYPE', 'Report Header', ['Company', 'Location', 'Both']],
  ['WORK_TYPE', 'Work Type', ['Retail', 'WhSales']],
  ['METAL_TYPE', 'Metal Type', ['Gold', 'Silver', 'Other']],
];
// rpt_xml/Company.xml:88-153 page-header texts, in their left-to-right order, over the :190-250 detail fields.
const printColumns = ['CO_CODE', 'CO_NAME', 'CO_ADD1', 'CO_ADD2', 'CO_STATE', 'CO_CITY'];
const blank = (): Record<string, string> => ({
  CO_CODE: '',
  ...Object.fromEntries(fields.map(([key]) => [key, ''])),
  REP_ADD_TYPE: 'C',
  WORK_TYPE: 'R',
  METAL_TYPE: 'G',
});
const hydrate = (row: Record<string, string>) => ({
  ...blank(),
  ...Object.fromEntries(Object.entries(row).map(([key, value]) => [key, value ?? ''])),
  REP_ADD_TYPE: row.REP_ADD_TYPE || 'C',
  WORK_TYPE: row.WORK_TYPE || 'R',
  METAL_TYPE: row.METAL_TYPE || 'G',
});
const errorText = (e: unknown) =>
  e instanceof ApiError
    ? String(e.body?.message || e.body?.error || e.message)
    : String((e as Error).message);
export default function CompanyPage() {
  const { coCode } = useBusinessScope();
  const [companies, setCompanies] = useState<{ CO_CODE: string; CO_NAME: string }[]>([]);
  const [form, setForm] = useState(blank);
  const [search, setSearch] = useState('');
  const [mode, setMode] = useState<'view' | 'new' | 'edit'>('view');
  const [busy, setBusy] = useState(false);
  const [message, setMessage] = useState('');
  const [states, setStates] = useState<{ STATE_CODE: string; STATE_NAME: string }[]>([]);
  const [source, setSource] = useState('');
  const [importAllParties, setImportAllParties] = useState(true);
  const [year, setYear] = useState('');
  const [opDate, setOpDate] = useState('');
  const [clDate, setClDate] = useState('');
  const [printRows, setPrintRows] = useState<Record<string, string>[] | null>(null);
  // tCoType starts disabled (:4253) and nothing disables it again; Ctrl+O also disables Save (:6471-6476).
  const [coTypeOpen, setCoTypeOpen] = useState(false);
  const [saveLocked, setSaveLocked] = useState(false);
  const [resetOpen, setResetOpen] = useState(false);
  const saveRef = useRef<HTMLButtonElement>(null);
  const focusField = (key: string) => document.getElementById(companyFieldId(key))?.focus();
  const load = async () => setCompanies(await get('/context/companies'));
  const open = async (code: string) => {
    setForm(hydrate(await get(`/company-identity/${encodeURIComponent(code)}`)));
    setMode('view');
  };
  useEffect(() => {
    void get<{ STATE_CODE: string; STATE_NAME: string }[]>('/company-identity/states')
      .then(setStates)
      .catch((e) => setMessage(errorText(e)));
    void load()
      .then(() => open(coCode))
      .catch((e) => setMessage(errorText(e)));
  }, [coCode]);
  const act = async (fn: () => Promise<void>) => {
    setBusy(true);
    setMessage('');
    try {
      await fn();
    } catch (e) {
      setMessage(errorText(e));
    } finally {
      setBusy(false);
    }
  };
  const change = (key: string, value: string) =>
    setForm((f) => ({ ...f, [key]: value.toUpperCase() }));
  const editable = mode !== 'view' && !busy;
  useEffect(() => {
    // MS_COMPANY_KeyDown (:6451-6481), the form-level Ctrl chords.
    const onKeyDown = (event: globalThis.KeyboardEvent) => {
      if (!event.ctrlKey || event.altKey || event.shiftKey || event.metaKey || event.repeat) return;
      const key = event.key.toLowerCase();
      if (key === 'o') {
        event.preventDefault();
        flushSync(() => {
          setSaveLocked(true);
          setCoTypeOpen(true);
        });
        focusField('CO_TYPE');
      } else if (key === 'r') {
        event.preventDefault();
        setResetOpen(true);
      }
    };
    document.addEventListener('keydown', onKeyDown);
    return () => document.removeEventListener('keydown', onKeyDown);
  }, []);
  const onIdentityKeyDown = (event: KeyboardEvent<HTMLElement>) => {
    const key = companyFieldKey((event.target as HTMLElement).id);
    if (!key) return;
    if (event.key === 'F1' && key === 'CO_NAME') {
      event.preventDefault(); // the credential panels stay hidden (header note)
      return;
    }
    if (event.key !== 'Enter' || event.ctrlKey || event.altKey || event.shiftKey || event.metaKey)
      return;
    const action = companyEnterAction({
      key,
      mode,
      values: form,
      hasOld: mode === 'new',
      stateName: (code) => states.find((s) => s.STATE_CODE === code)?.STATE_NAME,
    });
    if (action.kind === 'none') return;
    event.preventDefault();
    if (action.kind === 'stay') {
      if (action.message) setMessage(action.message);
    } else if (action.kind === 'focus') {
      if (action.state !== undefined) change('CO_STATE', action.state);
      focusField(action.key);
    } else {
      flushSync(() => setSaveLocked(false));
      saveRef.current?.focus();
    }
  };
  const textField = (key: string) => {
    const [, label, max] = fields.find(([name]) => name === key)!;
    return (
      <div className="field" key={key}>
        <label htmlFor={`company-${key}`}>{label}</label>
        <input
          id={`company-${key}`}
          maxLength={max}
          value={form[key] ?? ''}
          readOnly={!editable}
          disabled={key === 'CO_TYPE' && !coTypeOpen}
          list={key === 'CO_STATE_CODE' ? 'company-states' : undefined}
          onChange={(e) => {
            change(key, e.target.value);
            if (key === 'CO_STATE_CODE') {
              const state = states.find((s) => s.STATE_CODE === e.target.value);
              if (state) change('CO_STATE', state.STATE_NAME);
            }
          }}
        />
      </div>
    );
  };
  const selectField = (key: string) => {
    const [, label, options] = selects.find(([name]) => name === key)!;
    return (
      <div className="field" key={key}>
        <label htmlFor={`company-${key}`}>{label}</label>
        <select
          id={`company-${key}`}
          disabled={!editable}
          value={form[key] || options[0]![0]}
          onChange={(e) => change(key, e.target.value)}
        >
          {options.map((option) => (
            <option key={option} value={option[0]}>
              {option}
            </option>
          ))}
        </select>
      </div>
    );
  };
  return (
    <main>
      <h1>Company</h1>
      {message && (
        <div role="status" className="msg">
          {message}
        </div>
      )}
      {resetOpen && (
        // Ctrl+R (:6477-6480) shows chkResetData "Reset Compnay" (:5318) only where MsMasterResetAllData='Y', a flag
        // six registration serials set (MS_OPNCOMP.cs:5077-5262). Saved ticked it stores CO_MAST.RTGS_TYPE='Y'
        // (:6116,6162) and the next login deletes that company's vouchers and masters (Module_Schm.cs:62-110,
        // MS_LOGIN.cs:575-600). The web has no registration identity and no such wipe, so the box only explains.
        <section
          className="panel"
          role="dialog"
          aria-modal="true"
          aria-label="Reset Compnay"
          onKeyDown={(e) => {
            if (e.key === 'Escape') setResetOpen(false);
          }}
        >
          <strong>Reset Compnay</strong>
          <p>
            Not available on the web. On the desktop this box appears only for a few licences;
            ticked and saved, it deletes this company&apos;s vouchers and masters at the next login.
            Nothing has been changed.
          </p>
          <button type="button" autoFocus onClick={() => setResetOpen(false)}>
            Close
          </button>
        </section>
      )}
      <div className="row">
        <button
          disabled={busy}
          onClick={() => {
            setForm({
              ...blank(),
              CO_CODE: String(
                Math.max(0, ...companies.map((c) => Number(c.CO_CODE) || 0)) + 1,
              ).padStart(2, '0'),
            });
            setSource('');
            setImportAllParties(true);
            setYear('');
            setOpDate('');
            setClDate('');
            setMode('new');
            setMessage('');
          }}
        >
          New
        </button>
        <button disabled={busy || !form.version} onClick={() => setMode('edit')}>
          Edit
        </button>
        <button
          ref={saveRef}
          disabled={!editable || saveLocked}
          onClick={() =>
            act(async () => {
              const { version, ...identity } = form;
              const payload = {
                ...identity,
                ...(mode === 'edit'
                  ? { expectedVersion: version }
                  : {
                      sourceCoCode: source,
                      importAllParties,
                      firstYear: {
                        coYear: year,
                        opDate: opDate || undefined,
                        clDate: clDate || undefined,
                      },
                    }),
              };
              const saved =
                mode === 'new'
                  ? await post<Record<string, string>>('/company-identity', payload)
                  : await put<Record<string, string>>('/company-identity', payload);
              setForm(hydrate(saved));
              setMode('view');
              await load();
              setMessage('Data Are Saved.');
            })
          }
        >
          Save
        </button>
        <button
          disabled={busy}
          onClick={() =>
            act(async () => {
              await open(coCode);
              setMessage('');
            })
          }
        >
          Cancel
        </button>
        <button
          disabled={busy || !form.version}
          onClick={() =>
            act(async () => {
              if (form.CO_CODE === '01') {
                setMessage('You cant Delete Defoult company...');
                return;
              }
              if (!window.confirm('All Record From This Company Will Delete Permanently ?')) return;
              await del(
                `/company-identity/${encodeURIComponent(form.CO_CODE!)}?expectedVersion=${form.version}`,
              );
              await load();
              setForm(blank());
              setMode('view');
              setMessage('Delete Success.');
            })
          }
        >
          Delete
        </button>
        <button
          disabled={busy}
          onClick={() =>
            act(async () => {
              // MS_COMPANY.cs:6776-6790: Company.RPT for the logged-in company; the API answers the Print right.
              const out = await get<{ rows: Record<string, string>[] }>('/company-identity/print');
              setPrintRows(out.rows);
            })
          }
        >
          Print
        </button>
      </div>
      {printRows && (
        <section className="panel" data-testid="company-print" aria-label="Company print">
          <div className="row" style={{ justifyContent: 'space-between' }}>
            {/* rpt_xml/Company.xml:165 PrintDate in the page header, :287 PageNumber in the page footer. */}
            <span data-testid="company-print-date">
              {new Date().toLocaleDateString('en-GB').replace(/-/g, '/')}
            </span>
            <div className="row" style={{ gap: 8 }}>
              <button type="button" className="ghost" onClick={() => window.print()}>
                Print now
              </button>
              <button type="button" className="ghost" onClick={() => setPrintRows(null)}>
                Close
              </button>
            </div>
          </div>
          <table className="grid">
            <thead>
              <tr>
                {printColumns.map((key) => (
                  <th key={key}>{key}</th>
                ))}
              </tr>
            </thead>
            <tbody>
              {printRows.map((row) => (
                <tr key={row.CO_CODE}>
                  {printColumns.map((key) => (
                    <td key={key}>{row[key] ?? ''}</td>
                  ))}
                </tr>
              ))}
            </tbody>
          </table>
          <div data-testid="company-print-page">1</div>
        </section>
      )}
      <div className="row" style={{ alignItems: 'start' }}>
        <section className="panel">
          <label htmlFor="company-search">Search company</label>
          <input id="company-search" value={search} onChange={(e) => setSearch(e.target.value)} />
          <table className="grid" data-testid="company-list">
            <thead>
              <tr>
                <th>Code</th>
                <th>Name</th>
              </tr>
            </thead>
            <tbody>
              {companies
                .filter((c) =>
                  `${c.CO_CODE} ${c.CO_NAME}`.toUpperCase().includes(search.toUpperCase()),
                )
                .map((c) => (
                  <tr
                    key={c.CO_CODE}
                    data-code={c.CO_CODE}
                    tabIndex={0}
                    onClick={() => act(() => open(c.CO_CODE))}
                    onKeyDown={(e) => {
                      if (e.key === 'Enter') void act(() => open(c.CO_CODE));
                    }}
                  >
                    <td>{c.CO_CODE}</td>
                    <td>
                      {c.CO_NAME}
                      {c.CO_CODE === coCode ? ' (Current)' : ''}
                    </td>
                  </tr>
                ))}
            </tbody>
          </table>
        </section>
        <section
          className="panel"
          style={{ flex: 1 }}
          aria-label="Company identity"
          onKeyDown={onIdentityKeyDown}
        >
          <datalist id="company-states">
            {states.map((s) => (
              <option key={s.STATE_CODE} value={s.STATE_CODE}>
                {s.STATE_NAME}
              </option>
            ))}
          </datalist>
          {COMPANY_SECTIONS.map((section, index) => (
            <fieldset key={section.legend} aria-label={section.legend}>
              <legend>{section.legend}</legend>
              {index === 0 && (
                <>
                  <label htmlFor="company-code">Code</label>
                  <input
                    id="company-code"
                    value={form.CO_CODE ?? ''}
                    maxLength={2}
                    readOnly={mode !== 'new' || busy}
                    onChange={(e) => change('CO_CODE', e.target.value)}
                  />
                </>
              )}
              <div className="row" style={{ flexWrap: 'wrap' }}>
                {section.keys.map((key) =>
                  selects.some(([name]) => name === key) ? selectField(key) : textField(key),
                )}
              </div>
            </fieldset>
          ))}
          {mode === 'new' && (
            <fieldset>
              <legend>Year Create</legend>
              {source && (
                <label>
                  <input
                    type="checkbox"
                    checked={importAllParties}
                    onChange={(e) => setImportAllParties(e.target.checked)}
                  />
                  Import All Party from Ac Master Of {source} Compnay...?
                </label>
              )}
              <label htmlFor="company-old">With Old Company Master</label>
              <select id="company-old" value={source} onChange={(e) => setSource(e.target.value)}>
                <option value="">Default masters</option>
                {companies.map((c) => (
                  <option key={c.CO_CODE} value={c.CO_CODE}>
                    {c.CO_CODE} — {c.CO_NAME}
                  </option>
                ))}
              </select>
              <label htmlFor="company-year">Year</label>
              <input
                id="company-year"
                value={year}
                placeholder="2026-2027"
                onChange={(e) => setYear(e.target.value)}
              />
              <label htmlFor="company-opening">Opening Date</label>
              <input
                type="date"
                id="company-opening"
                value={opDate}
                onChange={(e) => setOpDate(e.target.value)}
              />
              <label htmlFor="company-closing">Closing Date</label>
              <input
                type="date"
                id="company-closing"
                value={clDate}
                onChange={(e) => setClDate(e.target.value)}
              />
            </fieldset>
          )}
        </section>
      </div>
    </main>
  );
}
