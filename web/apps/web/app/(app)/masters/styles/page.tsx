'use client';

import { useEffect, useRef, useState } from 'react';
import { useBusinessScope, type BusinessScope } from '../../../../components/BusinessScope';
import { ApiError, del, downloadCsv, get, post, put } from '../../../../lib/api';
import {
  COLUMN_VALUES,
  appendColumnSettingsPage,
  columnSettingKey,
  columnSettingPatch,
  columnSettingProblem,
  columnSettingsExport,
  columnSettingsQuery,
  parseColumnSettingsCsv,
  readColumnSettings,
  type ColumnSetting,
  type ColumnValue,
} from '../../../../lib/columnSettings';

const labels: Record<ColumnValue, string> = {
  COL_NEW_NAME: 'Caption',
  YES_NO: 'Visible',
  COL_RPT: 'Repeat',
};
const blank = (): Record<ColumnValue, string> => ({ COL_NEW_NAME: '', YES_NO: '', COL_RPT: '' });
type Observation = ReturnType<typeof readColumnSettings>;
export default function ColumnSettingsPage() {
  const scope = useBusinessScope();
  return <ColumnSettingsEditor key={JSON.stringify(scope)} scope={scope} />;
}

function ColumnSettingsEditor({ scope }: { scope: BusinessScope }) {
  const [observation, setObservation] = useState<Observation | null>(null);
  const [observationQuery, setObservationQuery] = useState('');
  const [busy, setBusy] = useState(true);
  const [needsReload, setNeedsReload] = useState(false);
  const [message, setMessage] = useState('');
  const [search, setSearch] = useState('');
  const [family, setFamily] = useState('');
  const [selected, setSelected] = useState<ColumnSetting | null>(null);
  const [creating, setCreating] = useState(false);
  const [newFamily, setNewFamily] = useState('');
  const [newColumn, setNewColumn] = useState('');
  const [values, setValues] = useState(blank);
  const [touched, setTouched] = useState<ColumnValue[]>([]);
  const epoch = useRef(0);
  const alive = useRef(false);
  const query = columnSettingsQuery(scope);
  const endpoint = `/masters/styles?${query}`;
  const filterKey = JSON.stringify([family, search]);
  const renderedFilter = useRef(filterKey);
  renderedFilter.current = filterKey;
  const current = (id: number) => alive.current && epoch.current === id;

  async function observe(id: number, previous?: Observation) {
    const observedFilter = filterKey;
    const listQuery = new URLSearchParams(query);
    listQuery.set('family', family);
    listQuery.set('search', search);
    listQuery.set('limit', '50');
    listQuery.set('offset', String(previous?.rows.length ?? 0));
    const [meta, rows] = await Promise.all([
      get<unknown>(`/masters/styles/meta?${query}`),
      get<unknown>(`/masters/styles?${listQuery}`),
    ]);
    if (!current(id) || renderedFilter.current !== observedFilter) return false;
    const next = readColumnSettings(meta, rows, scope.coCode);
    setObservation(previous ? appendColumnSettingsPage(previous, next) : next);
    setObservationQuery(observedFilter);
    setNeedsReload(false);
    return true;
  }
  async function reload() {
    const id = ++epoch.current;
    setBusy(true);
    setObservation(null);
    setSelected(null);
    setCreating(false);
    setTouched([]);
    setMessage('');
    setNeedsReload(true);
    try {
      await observe(id);
    } catch (error) {
      if (current(id))
        setMessage(error instanceof Error ? error.message : 'Column settings could not be loaded.');
    } finally {
      if (current(id)) setBusy(false);
    }
  }
  useEffect(() => {
    alive.current = true;
    void reload();
    return () => {
      alive.current = false;
      // This numeric request counter must invalidate the latest generation;
      // it is not a DOM ref to the value that existed when the effect began.
      // eslint-disable-next-line react-hooks/exhaustive-deps
      epoch.current++;
    };
    // The enclosing component remounts for every complete scope transition.
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [family, search]);

  function select(row: ColumnSetting) {
    if (!ready || columnSettingProblem(row)) return;
    setSelected(row);
    setCreating(false);
    setTouched([]);
    setMessage('');
    setValues(
      Object.fromEntries(COLUMN_VALUES.map((key) => [key, row[key] ?? ''])) as Record<
        ColumnValue,
        string
      >,
    );
  }
  function beginCreate() {
    setSelected(null);
    setCreating(true);
    setValues(blank());
    setTouched([]);
    setNewFamily(family);
    setNewColumn('');
    setMessage('');
  }
  function failure(error: unknown, committed: boolean) {
    const uncertain = committed || !(error instanceof ApiError) || error.status >= 500;
    const conflict = error instanceof ApiError && [403, 404, 409].includes(error.status);
    if (uncertain || conflict) setNeedsReload(true);
    setMessage(
      committed
        ? 'The change was saved, but the list could not be refreshed. Reload before changing another setting.'
        : error instanceof ApiError
          ? error.body?.message || error.body?.detail || 'The change could not be saved.'
          : uncertain
            ? 'The save outcome could not be confirmed. Your draft is retained; reload before retrying.'
            : 'The change could not be saved.',
    );
  }
  async function save(event: React.FormEvent) {
    event.preventDefault();
    if (!ready || !observation) return;
    let payload: Record<string, unknown>;
    try {
      if (creating) {
        if (!observation.capabilities.canCreate || !newFamily.trim() || !newColumn.trim())
          throw new Error('Choose a form family and original column name.');
        payload = { CO_CODE: scope.coCode, BOOK_NAME: newFamily, COL_NAME: newColumn, ...values };
      } else {
        if (!selected || !observation.capabilities.canUpdate) return;
        payload = columnSettingPatch(selected, values, touched);
      }
    } catch (error) {
      setMessage(error instanceof Error ? error.message : 'The draft is invalid.');
      return;
    }
    const wasCreating = creating;
    const id = ++epoch.current;
    setBusy(true);
    setMessage('');
    let committed = false;
    try {
      if (wasCreating) await post(endpoint, payload);
      else await put(endpoint, payload);
      committed = true;
      if (!current(id)) return;
      setSelected(null);
      setCreating(false);
      setTouched([]);
      setNeedsReload(true);
      if (await observe(id))
        setMessage(wasCreating ? 'Column setting created.' : 'Column setting updated.');
    } catch (error) {
      if (current(id)) failure(error, committed);
    } finally {
      if (current(id)) setBusy(false);
    }
  }
  async function remove(row: ColumnSetting) {
    if (!ready || !observation?.capabilities.canDelete || columnSettingProblem(row)) return;
    if (!confirm(`Delete the ${row.COL_NAME} setting for ${row.BOOK_NAME}?`)) return;
    const id = ++epoch.current;
    setBusy(true);
    setMessage('');
    let committed = false;
    try {
      await del(endpoint, { ...columnSettingKey(row), version: row._columnVersion });
      committed = true;
      if (!current(id)) return;
      setSelected(null);
      setCreating(false);
      setNeedsReload(true);
      if (await observe(id)) setMessage('Column setting deleted.');
    } catch (error) {
      if (current(id)) failure(error, committed);
    } finally {
      if (current(id)) setBusy(false);
    }
  }
  async function importFile(event: React.ChangeEvent<HTMLInputElement>) {
    const input = event.currentTarget,
      file = input.files?.[0];
    input.value = '';
    if (!file || !ready || !observation?.capabilities.canCreate) return;
    const id = ++epoch.current;
    setBusy(true);
    setMessage('');
    let sent = false,
      committed = false;
    try {
      const rows = parseColumnSettingsCsv(await file.text());
      if (!current(id)) return;
      sent = true;
      const result = await post<{
        created: number;
        failed: number;
        errors: { row: number; error: string }[];
      }>(`/masters/styles/import?${query}`, { rows });
      committed = true;
      if (!current(id)) return;
      setSelected(null);
      setCreating(false);
      setNeedsReload(true);
      if (await observe(id))
        setMessage(
          `Imported ${result.created}; failed ${result.failed}.${result.errors[0] ? ` Row ${result.errors[0].row}: ${result.errors[0].error}` : ''}`,
        );
    } catch (error) {
      if (current(id)) {
        if (!sent)
          setMessage(error instanceof Error ? error.message : 'The CSV could not be read.');
        else failure(error, committed);
      }
    } finally {
      if (current(id)) setBusy(false);
    }
  }

  async function loadMore() {
    if (!ready || !observation || observation.rows.length >= observation.total) return;
    const id = ++epoch.current;
    setBusy(true);
    setMessage('');
    try {
      await observe(id, observation);
    } catch (error) {
      if (current(id)) {
        setNeedsReload(true);
        setMessage(
          error instanceof Error
            ? error.message
            : 'The next page could not be verified. Reload the list.',
        );
      }
    } finally {
      if (current(id)) setBusy(false);
    }
  }
  const ready = !!observation && observationQuery === filterKey && !busy && !needsReload;
  const rows = observationQuery === filterKey ? (observation?.rows ?? []) : [];
  const families = [
    ...new Set(rows.flatMap((row) => (row.BOOK_NAME ? [row.BOOK_NAME] : []))),
  ].sort();
  const editable =
    ready && (creating ? observation?.capabilities.canCreate : observation?.capabilities.canUpdate);
  return (
    <div data-testid="column-settings">
      <h1>Column settings</h1>
      <p className="muted">
        Choose the form and its original column to change the caption, visibility or repeat option.
      </p>
      <div className="toolbar">
        <button
          type="button"
          disabled={!ready || !observation?.capabilities.canCreate}
          onClick={beginCreate}
        >
          New column setting
        </button>
        <button
          type="button"
          data-testid="column-settings-reload"
          disabled={busy}
          onClick={() => void reload()}
        >
          {selected || creating || needsReload
            ? 'Discard draft and reload'
            : 'Reload column settings'}
        </button>
        <button
          type="button"
          disabled={!rows.length || busy}
          onClick={() => downloadCsv(columnSettingsExport(rows), 'column-settings')}
        >
          Export loaded settings CSV
        </button>
        <label>
          Import CSV{' '}
          <input
            type="file"
            data-testid="column-settings-import"
            accept=".csv,text/csv"
            disabled={!ready || !observation?.capabilities.canCreate}
            onChange={(event) => void importFile(event)}
          />
        </label>
      </div>
      {message && (
        <p role="status" data-testid="column-settings-message">
          {message}
        </p>
      )}
      {needsReload && !busy && (
        <p role="alert" data-testid="column-settings-conflict">
          Reload the saved settings before making another change.
        </p>
      )}
      {(selected || creating) && (
        <form
          className="panel"
          data-testid="column-settings-editor"
          onSubmit={(event) => void save(event)}
        >
          <h2>{creating ? 'New column setting' : 'Edit column setting'}</h2>
          <fieldset disabled={!editable} style={{ border: 0, padding: 0, minWidth: 0 }}>
            <div className="row">
              <label>
                Form family
                <input
                  aria-label="Form family"
                  value={creating ? newFamily : (selected?.BOOK_NAME ?? '')}
                  readOnly={!creating}
                  onChange={(event) => setNewFamily(event.target.value)}
                />
              </label>
              <label>
                Original column
                <input
                  aria-label="Original column"
                  value={creating ? newColumn : (selected?.COL_NAME ?? '')}
                  readOnly={!creating}
                  onChange={(event) => setNewColumn(event.target.value)}
                />
              </label>
              {COLUMN_VALUES.map((key) => (
                <label key={key}>
                  {labels[key]}
                  {key === 'COL_NEW_NAME' ? (
                    <input
                      aria-label={labels[key]}
                      value={values[key]}
                      maxLength={255}
                      onChange={(event) => {
                        setValues((old) => ({ ...old, [key]: event.target.value }));
                        setTouched((old) => [...new Set([...old, key])]);
                      }}
                    />
                  ) : (
                    <select
                      aria-label={labels[key]}
                      value={values[key]}
                      onChange={(event) => {
                        setValues((old) => ({ ...old, [key]: event.target.value }));
                        setTouched((old) => [...new Set([...old, key])]);
                      }}
                    >
                      <option value="">Blank</option>
                      <option value="Y">Yes</option>
                      <option value="N">No</option>
                      {!['', 'Y', 'N'].includes(values[key]) && (
                        <option value={values[key]}>Saved: {values[key]}</option>
                      )}
                    </select>
                  )}
                </label>
              ))}
            </div>
            <button className="primary" disabled={!creating && !touched.length}>
              Save column setting
            </button>
          </fieldset>
          <button
            type="button"
            disabled={busy}
            onClick={() => {
              setSelected(null);
              setCreating(false);
              setTouched([]);
            }}
          >
            Cancel edit
          </button>
        </form>
      )}
      <div className="toolbar">
        <label>
          Filter form
          <input
            aria-label="Filter form"
            list="column-settings-families"
            placeholder="All forms (enter exact family to filter)"
            value={family}
            onChange={(event) => setFamily(event.target.value)}
          />
          <datalist id="column-settings-families">
            {families.map((name) => (
              <option key={name} value={name} />
            ))}
          </datalist>
        </label>
        <label>
          Search columns
          <input
            type="search"
            aria-label="Search columns"
            value={search}
            onChange={(event) => setSearch(event.target.value)}
          />
        </label>
        <span>
          {rows.length} of {observationQuery === filterKey ? (observation?.total ?? 0) : 0} matching
          settings loaded
        </span>
      </div>
      <p className="muted">
        CSV exports contain the loaded settings. CSV represents saved NULL values as blank text.
      </p>
      <div className="panel" style={{ overflowX: 'auto', minWidth: 0 }}>
        <table className="grid">
          <thead>
            <tr>
              <th>Form family</th>
              <th>Original column</th>
              <th>Caption</th>
              <th>Visible</th>
              <th>Repeat</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {rows.map((row) => {
              const problem = columnSettingProblem(row);
              return (
                <tr key={row.row_id} data-testid={`column-setting-${row.row_id}`}>
                  <td>{row.BOOK_NAME}</td>
                  <td>{row.COL_NAME}</td>
                  <td>{row.COL_NEW_NAME}</td>
                  <td>{row.YES_NO ?? '—'}</td>
                  <td>{row.COL_RPT ?? '—'}</td>
                  <td>
                    <button
                      type="button"
                      disabled={!ready || !!problem || !observation?.capabilities.canUpdate}
                      onClick={() => select(row)}
                    >
                      Edit
                    </button>{' '}
                    <button
                      type="button"
                      disabled={!ready || !!problem || !observation?.capabilities.canDelete}
                      onClick={() => void remove(row)}
                    >
                      Delete
                    </button>
                    {problem && <p>{problem}</p>}
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
        {!rows.length && <p>{busy ? 'Loading column settings…' : 'No column settings loaded.'}</p>}
      </div>
      {observation && rows.length < observation.total && (
        <button
          type="button"
          data-testid="column-settings-load-more"
          disabled={!ready}
          onClick={() => void loadMore()}
        >
          Load more settings
        </button>
      )}
    </div>
  );
}
