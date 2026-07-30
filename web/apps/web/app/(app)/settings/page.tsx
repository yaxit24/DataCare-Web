'use client';
import { useEffect, useMemo, useState } from 'react';
import { get, post, ApiError } from '../../../lib/api';

interface SettingOption {
  label: string;
  value: string;
}
interface Field {
  id: string;
  key: string;
  table: 'CO_SET' | 'CO_SET_NEW';
  type: 'boolean' | 'enum' | 'number' | 'date' | 'text';
  label: string;
  hint?: string;
  options?: SettingOption[];
  maxLength?: number;
  unknownOptions?: true;
  surface: 'UT_SETTING' | 'UT_SETTING_MAIN' | 'UT_SET_ADMIN' | 'SCHEMA_ONLY';
}

/** Desktop surface names, in the order the desktop presents them. */
const SURFACES: { id: Field['surface']; label: string }[] = [
  { id: 'UT_SETTING', label: 'Setting' },
  { id: 'UT_SETTING_MAIN', label: 'Main Setting' },
  { id: 'UT_SET_ADMIN', label: 'Admin Setting' },
  // Settings with no desktop control are shown honestly rather than hidden.
  { id: 'SCHEMA_ONLY', label: 'Unmapped' },
];

export default function SettingsPage() {
  const [fields, setFields] = useState<Field[]>([]);
  const [vals, setVals] = useState<Record<string, string>>({});
  // Only changed ids are submitted: sending the whole value map would rewrite every setting, turning
  // "never configured" (null) into a blank string across the board.
  const [dirty, setDirty] = useState<Record<string, true>>({});
  const [errors, setErrors] = useState<Record<string, string>>({});
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [surface, setSurface] = useState<Field['surface']>('UT_SETTING');

  useEffect(() => {
    get<{ fields: Field[]; values: Record<string, unknown> }>('/settings')
      .then((d) => {
        setFields(d.fields);
        setVals(
          Object.fromEntries(
            Object.entries(d.values).map(([k, v]) => [k, v == null ? '' : String(v)]),
          ),
        );
      })
      .catch(() => setMsg({ kind: 'err', text: 'Failed to load settings' }))
      .finally(() => setLoading(false));
  }, []);

  const present = useMemo(
    () => SURFACES.filter((s) => fields.some((f) => f.surface === s.id)),
    [fields],
  );
  const shown = useMemo(() => fields.filter((f) => f.surface === surface), [fields, surface]);
  const dirtyCount = Object.keys(dirty).length;

  const set = (id: string, value: string) => {
    setVals((v) => ({ ...v, [id]: value }));
    setDirty((d) => ({ ...d, [id]: true }));
    setErrors((e) => {
      if (!e[id]) return e;
      const { [id]: _drop, ...rest } = e;
      return rest;
    });
  };

  async function save(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setErrors({});
    setSaving(true);
    try {
      const patch = Object.fromEntries(Object.keys(dirty).map((id) => [id, vals[id] ?? '']));
      const r = await post<{ changed: number }>('/settings', patch);
      setDirty({});
      setMsg({ kind: 'ok', text: `Saved ${r.changed} setting${r.changed === 1 ? '' : 's'}` });
    } catch (err) {
      if (err instanceof ApiError && err.body?.details) {
        setErrors(err.body.details as Record<string, string>);
        setMsg({ kind: 'err', text: 'Some settings were rejected; nothing was saved' });
      } else {
        setMsg({
          kind: 'err',
          text:
            err instanceof ApiError
              ? err.body?.message || err.body?.error || 'Save failed'
              : 'Save failed',
        });
      }
    } finally {
      setSaving(false);
    }
  }

  const renderControl = (f: Field) => {
    const v = vals[f.id] ?? '';
    const invalid = Boolean(errors[f.id]);
    const common = {
      id: f.id,
      'aria-invalid': invalid || undefined,
      'aria-describedby': f.hint || invalid ? `${f.id}-desc` : undefined,
    };
    if (f.type === 'boolean' || f.type === 'enum') {
      return (
        <select {...common} value={v} onChange={(e) => set(f.id, e.target.value)}>
          <option value="">(not set)</option>
          {(f.options ?? []).map((o) => (
            <option key={o.value} value={o.value}>
              {o.label}
            </option>
          ))}
          {/* A stored value outside the desktop's option set is shown rather than silently replaced. */}
          {v && !(f.options ?? []).some((o) => o.value === v) && (
            <option value={v}>{`Legacy value: ${v}`}</option>
          )}
        </select>
      );
    }
    if (f.type === 'number' && f.options?.length) {
      return (
        <select {...common} value={v} onChange={(e) => set(f.id, e.target.value)}>
          <option value="">(not set)</option>
          {f.options.map((o) => (
            <option key={o.value} value={o.value}>
              {o.label}
            </option>
          ))}
        </select>
      );
    }
    return (
      <input
        {...common}
        type={f.type === 'number' ? 'number' : f.type === 'date' ? 'date' : 'text'}
        maxLength={f.maxLength}
        value={v}
        onChange={(e) => set(f.id, e.target.value)}
      />
    );
  };

  if (loading) return <div>Loading…</div>;

  return (
    <div>
      <h1>Company Settings</h1>
      <p className="muted">
        All {fields.length} settings across CO_SET and CO_SET_NEW — the desktop UT_SETTING,
        UT_SETTING_MAIN and UT_SET_ADMIN forms.
      </p>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}

      <div className="tabs" role="tablist" aria-label="Setting groups">
        {present.map((s) => (
          <button
            key={s.id}
            type="button"
            role="tab"
            aria-selected={surface === s.id}
            className={surface === s.id ? 'active' : ''}
            onClick={() => setSurface(s.id)}
          >
            {s.label} ({fields.filter((f) => f.surface === s.id).length})
          </button>
        ))}
      </div>

      <form className="panel" onSubmit={save}>
        <div className="row">
          {shown.map((f) => (
            <div className="field" key={f.id} style={{ minWidth: 220 }}>
              <label htmlFor={f.id}>{f.label}</label>
              {renderControl(f)}
              {(f.hint || errors[f.id]) && (
                <small id={`${f.id}-desc`} className={errors[f.id] ? 'err' : 'muted'}>
                  {errors[f.id] ? `${f.key} ${errors[f.id]}` : f.hint}
                </small>
              )}
            </div>
          ))}
        </div>
        <button className="primary" disabled={saving || dirtyCount === 0}>
          {saving ? 'Saving…' : dirtyCount ? `Save ${dirtyCount} change(s)` : 'Save Settings'}
        </button>
      </form>
    </div>
  );
}
