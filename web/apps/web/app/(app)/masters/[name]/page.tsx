'use client';
import { useCallback, useEffect, useState } from 'react';
import { useParams } from 'next/navigation';
import { get, post, put, del, downloadCsv, ApiError } from '../../../../lib/api';
import { LookupPicker, type LookupRow } from '../../../../components/LookupPicker';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { filterMasterRows } from '../../../../lib/masterSearch';
import { EntityImagePanel, type ImageEntityType } from '../../../../components/EntityImagePanel';

/**
 * Masters whose desktop form carries image buttons, and the entity each photograph belongs to.
 *
 *   MS_ACCT        party photo      -> AC     (accounts, customers)
 *   MS_PRODUCT     scheme artwork   -> SCHM   (schemes, products)
 *   MS_DESIGN_BOOK design image     -> DESIGN (designs, styles)
 *
 * A master not listed here has no image surface on the desktop either, so no panel is shown rather than
 * offering an attachment the desktop never had.
 */
const MASTER_IMAGE_ENTITY: Record<
  string,
  { entity: ImageEntityType; label: string; keyCol: string }
> = {
  accounts: { entity: 'AC', label: 'Party photo', keyCol: 'AC_CODE' },
  customers: { entity: 'AC', label: 'Party photo', keyCol: 'AC_CODE' },
  schemes: { entity: 'SCHM', label: 'Scheme image', keyCol: 'SCHM_CODE' },
  products: { entity: 'SCHM', label: 'Product image', keyCol: 'PR_CODE' },
  designs: { entity: 'DESIGN', label: 'Design image', keyCol: 'DESIGN_NO' },
  styles: { entity: 'DESIGN', label: 'Style image', keyCol: 'STYLE_CODE' },
};

interface FormFieldOption {
  value: string;
  label: string;
}
interface FormField {
  col: string;
  label: string;
  type?: string;
  options?: FormFieldOption[];
  entity?: string;
  fill?: { col: string; from: string }[];
  group?: string;
}
interface Meta {
  table: string;
  keyColumns: string[];
  requiredColumns: string[];
  formFields?: FormField[] | null;
}

/** Render a master field by type: select (enum) / lookup (LookupPicker + fill side-effects) / text|number. */
function FieldInput({
  f,
  value,
  disabled,
  setValues,
}: {
  f: FormField;
  value: string;
  disabled?: boolean;
  setValues: (patch: Record<string, string>) => void;
}) {
  if (f.type === 'select') {
    return (
      <select
        value={value}
        disabled={disabled}
        onChange={(e) => setValues({ [f.col]: e.target.value })}
      >
        <option value="">—</option>
        {(f.options ?? []).map((o) => (
          <option key={o.value} value={o.value}>
            {o.label}
          </option>
        ))}
      </select>
    );
  }
  if (f.type === 'lookup' && f.entity) {
    return (
      <LookupPicker
        entity={f.entity}
        value={value}
        onChange={(v) => setValues({ [f.col]: v })}
        onPick={(row: LookupRow) => {
          const patch: Record<string, string> = { [f.col]: String(row.code) };
          (f.fill ?? []).forEach((fl) => {
            const rv = (row as Record<string, unknown>)[fl.from];
            if (rv != null && rv !== '') patch[fl.col] = String(rv);
          });
          setValues(patch);
        }}
      />
    );
  }
  return (
    <input
      type={f.type === 'number' ? 'number' : f.type === 'date' ? 'date' : 'text'}
      value={value}
      disabled={disabled}
      onChange={(e) => setValues({ [f.col]: e.target.value })}
    />
  );
}

const GROUP_ORDER = [
  'General',
  'Address',
  'Contact',
  'Tax & GST',
  'Bank',
  'Balances & Terms',
  'Dates',
  'Other',
];

/** Render fields as tabbed sections grouped by field.group (desktop tabbed dialog). Flat when ≤1 group. */
function FieldGroups({
  fields,
  active,
  setActive,
  renderOne,
}: {
  fields: FormField[];
  active: string;
  setActive: (g: string) => void;
  renderOne: (f: FormField) => React.ReactNode;
}) {
  const present = [...new Set(fields.map((f) => f.group || 'Other'))];
  const groups = [
    ...GROUP_ORDER.filter((g) => present.includes(g)),
    ...present.filter((g) => !GROUP_ORDER.includes(g)),
  ];
  if (groups.length <= 1) return <div className="row">{fields.map(renderOne)}</div>;
  const cur = active && groups.includes(active) ? active : groups[0];
  return (
    <>
      <div
        style={{
          display: 'flex',
          gap: 4,
          flexWrap: 'wrap',
          marginBottom: 10,
          borderBottom: '1px solid var(--border,#ddd)',
        }}
      >
        {groups.map((g) => (
          <button
            key={g}
            type="button"
            onClick={() => setActive(g)}
            style={{
              padding: '5px 12px',
              border: 'none',
              borderBottom: g === cur ? '2px solid var(--accent,#0b5cab)' : '2px solid transparent',
              background: 'transparent',
              cursor: 'pointer',
              fontWeight: g === cur ? 700 : 400,
              color: g === cur ? 'var(--accent,#0b5cab)' : 'inherit',
            }}
          >
            {g}{' '}
            <span className="muted" style={{ fontSize: 10 }}>
              ({fields.filter((f) => (f.group || 'Other') === g).length})
            </span>
          </button>
        ))}
      </div>
      <div className="row">{fields.filter((f) => (f.group || 'Other') === cur).map(renderOne)}</div>
    </>
  );
}

function parseCsv(text: string): Record<string, string>[] {
  const lines = text.split(/\r?\n/).filter((l) => l.trim());
  if (lines.length < 2) return [];
  const parseLine = (line: string): string[] => {
    const out: string[] = [];
    let cur = '',
      q = false;
    for (let i = 0; i < line.length; i++) {
      const c = line[i];
      if (q) {
        if (c === '"') {
          if (line[i + 1] === '"') {
            cur += '"';
            i++;
          } else q = false;
        } else cur += c;
      } else if (c === ',') {
        out.push(cur);
        cur = '';
      } else if (c === '"') q = true;
      else cur += c;
    }
    out.push(cur);
    return out;
  };
  const cols = parseLine(lines[0]).map((c) => c.trim());
  return lines.slice(1).map((l) => {
    const vals = parseLine(l);
    return Object.fromEntries(cols.map((c, i) => [c, (vals[i] ?? '').trim()]));
  });
}

export default function MasterPage() {
  const { coCode, lcCode } = useBusinessScope();
  const params = useParams();
  const name = String(params.name);
  const [meta, setMeta] = useState<Meta | null>(null);
  const [rows, setRows] = useState<Record<string, any>[]>([]);
  // Desktop grid type-ahead: case-insensitive PREFIX over any visible column
  // (MS_BOOKLIST.cs tSearchText_TextChanged uses .ToLower().StartsWith(...)).
  const [search, setSearch] = useState('');
  const [form, setForm] = useState<Record<string, string>>({});
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [showNew, setShowNew] = useState(false);
  const [editing, setEditing] = useState<Record<string, any> | null>(null);
  const [newTab, setNewTab] = useState('');
  const [editTab, setEditTab] = useState('');

  const load = useCallback(async () => {
    setMsg(null);
    const [m, list] = await Promise.all([
      get<Meta>(`/masters/${name}/meta`),
      get<Record<string, any>[]>(`/masters/${name}`),
    ]);
    setMeta(m);
    setRows(list);
    const fcols =
      m.formFields && m.formFields.length ? m.formFields.map((f) => f.col) : m.requiredColumns;
    setForm(
      Object.fromEntries(
        fcols.map((column) => [
          column,
          column === 'CO_CODE' ? coCode : column === 'LC_CODE' ? lcCode : '',
        ]),
      ),
    );
  }, [coCode, lcCode, name]);

  useEffect(() => {
    load().catch(() => setMsg({ kind: 'err', text: 'Failed to load' }));
  }, [load]);

  async function create(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    try {
      await post(`/masters/${name}`, form);
      setMsg({ kind: 'ok', text: 'Record created' });
      setShowNew(false);
      await load();
    } catch (e) {
      const b = e instanceof ApiError ? e.body : null;
      setMsg({
        kind: 'err',
        text:
          b?.error === 'duplicate-key'
            ? 'Duplicate key'
            : b?.missing
              ? 'Missing: ' + b.missing.join(', ')
              : b?.error === 'invalid-data'
                ? b.detail || 'Invalid data'
                : 'Create failed',
      });
    }
  }

  async function remove(row: Record<string, any>) {
    if (!meta) return;
    if (!confirm('Delete this record?')) return;
    const key = Object.fromEntries(meta.keyColumns.map((k) => [k, row[k]]));
    try {
      await del(`/masters/${name}`, key);
      setMsg({ kind: 'ok', text: 'Deleted' });
      await load();
    } catch (e) {
      const b = e instanceof ApiError ? e.body : null;
      setMsg({
        kind: 'err',
        text: b?.error === 'referenced' ? `In use by ${b.ref}` : 'Delete failed',
      });
    }
  }

  function startEdit(row: Record<string, any>) {
    setShowNew(false);
    setMsg(null);
    setEditing({ ...row });
  }

  async function saveEdit(e: React.FormEvent) {
    e.preventDefault();
    if (!editing || !meta) return;
    setMsg(null);
    const { tenant_id, row_id, ...payload } = editing; // never PUT the surrogate/tenant columns
    try {
      await put(`/masters/${name}`, payload);
      setMsg({ kind: 'ok', text: 'Record updated' });
      setEditing(null);
      await load();
    } catch (e) {
      const b = e instanceof ApiError ? e.body : null;
      setMsg({
        kind: 'err',
        text:
          b?.error === 'not-found'
            ? 'Record not found'
            : b?.missing
              ? 'Missing: ' + b.missing.join(', ')
              : b?.error === 'invalid-data'
                ? b.detail || 'Invalid data'
                : 'Update failed',
      });
    }
  }

  async function handleImport(e: React.ChangeEvent<HTMLInputElement>) {
    const file = e.target.files?.[0];
    if (!file) return;
    setMsg(null);
    try {
      const rowsIn = parseCsv(await file.text());
      if (!rowsIn.length) {
        setMsg({ kind: 'err', text: 'No data rows in CSV' });
        return;
      }
      const r = await post<{
        created: number;
        failed: number;
        errors: { row: number; error: string }[];
      }>(`/masters/${name}/import`, { rows: rowsIn });
      setMsg({
        kind: r.failed ? 'err' : 'ok',
        text: `Imported ${r.created}, failed ${r.failed}${r.errors?.length ? ` — e.g. row ${r.errors[0].row}: ${r.errors[0].error}` : ''}`,
      });
      await load();
    } catch {
      setMsg({ kind: 'err', text: 'Import failed' });
    } finally {
      e.target.value = '';
    }
  }

  const shownRows = filterMasterRows(rows, search);
  const cols = rows[0]
    ? Object.keys(rows[0])
        .filter((c) => c !== 'tenant_id')
        .slice(0, 9)
    : (meta?.keyColumns ?? []);

  return (
    <div>
      <h1 style={{ textTransform: 'capitalize' }}>
        {name} <span className="muted">— {meta?.table}</span>
      </h1>
      <div className="toolbar">
        <button className="primary" onClick={() => setShowNew((s) => !s)}>
          {showNew ? 'Cancel' : '+ New'}
        </button>
        <button className="ghost" onClick={() => load()}>
          Refresh
        </button>
        <button className="ghost" disabled={!rows.length} onClick={() => downloadCsv(rows, name)}>
          Export CSV
        </button>
        <label className="ghost" style={{ cursor: 'pointer' }}>
          Import CSV
          <input
            type="file"
            accept=".csv,text/csv"
            style={{ display: 'none' }}
            onChange={handleImport}
          />
        </label>
        <span className="muted">
          {search ? `${shownRows.length} of ${rows.length}` : `${rows.length} record(s)`}
        </span>
        <input
          type="search"
          aria-label="Search records"
          placeholder="Search…"
          value={search}
          onChange={(e) => setSearch(e.target.value)}
          style={{ width: 180 }}
        />
      </div>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}

      {showNew && meta && (
        <form className="panel" onSubmit={create}>
          <h2>New {name}</h2>
          <FieldGroups
            fields={
              meta.formFields && meta.formFields.length
                ? meta.formFields
                : meta.requiredColumns.map((c) => ({ col: c, label: c, type: 'text' }))
            }
            active={newTab}
            setActive={setNewTab}
            renderOne={(f) => (
              <div className="field" key={f.col}>
                <label>
                  {f.label}
                  {meta.keyColumns.includes(f.col) ? ' *' : ''}
                </label>
                <FieldInput
                  f={f}
                  value={form[f.col] ?? ''}
                  disabled={f.col === 'CO_CODE' || f.col === 'LC_CODE'}
                  setValues={(patch) => setForm((x) => ({ ...x, ...patch }))}
                />
              </div>
            )}
          />
          <button className="primary">Save</button>
        </form>
      )}

      {/* Desktop image buttons exist on MS_ACCT, MS_PRODUCT and MS_DESIGN_BOOK; the photograph belongs to
          the record being edited, not to a tag. */}
      {editing && MASTER_IMAGE_ENTITY[name] && (
        <EntityImagePanel
          entityType={MASTER_IMAGE_ENTITY[name]!.entity}
          entityKey={String(editing[MASTER_IMAGE_ENTITY[name]!.keyCol] ?? '')}
          instance={0}
          label={MASTER_IMAGE_ENTITY[name]!.label}
          testId="master-image"
        />
      )}

      {editing && meta && (
        <form className="panel" onSubmit={saveEdit}>
          <h2>
            Edit {name}{' '}
            <span className="muted">
              — {meta.keyColumns.map((k) => `${k}=${editing[k]}`).join(', ')}
            </span>
          </h2>
          <FieldGroups
            fields={
              meta.formFields && meta.formFields.length
                ? meta.formFields
                : cols
                    .filter((c) => c !== 'row_id')
                    .map((c) => ({ col: c, label: c, type: 'text' }))
            }
            active={editTab}
            setActive={setEditTab}
            renderOne={(f) => (
              <div className="field" key={f.col}>
                <label>
                  {f.label}
                  {meta.keyColumns.includes(f.col) ? ' (key)' : ''}
                </label>
                <FieldInput
                  f={f}
                  value={String(editing[f.col] ?? '')}
                  disabled={
                    meta.keyColumns.includes(f.col) || f.col === 'CO_CODE' || f.col === 'LC_CODE'
                  }
                  setValues={(patch) => setEditing((x) => (x ? { ...x, ...patch } : x))}
                />
              </div>
            )}
          />
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button className="primary">Update</button>
            <button type="button" className="ghost" onClick={() => setEditing(null)}>
              Cancel
            </button>
          </div>
        </form>
      )}

      <div className="panel" style={{ overflow: 'auto' }}>
        <table className="grid">
          <thead>
            <tr>
              {cols.map((c) => (
                <th key={c}>{c}</th>
              ))}
              <th></th>
            </tr>
          </thead>
          <tbody>
            {shownRows.map((r, i) => (
              <tr key={i}>
                {cols.map((c) => (
                  <td key={c}>{String(r[c] ?? '')}</td>
                ))}
                <td style={{ whiteSpace: 'nowrap' }}>
                  <button className="ghost" onClick={() => startEdit(r)}>
                    Edit
                  </button>{' '}
                  <button className="danger" onClick={() => remove(r)}>
                    Del
                  </button>
                </td>
              </tr>
            ))}
            {shownRows.length === 0 && (
              <tr>
                <td colSpan={cols.length + 1} className="muted">
                  No records.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}
