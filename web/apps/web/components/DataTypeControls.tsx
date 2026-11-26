'use client';
import { createContext, useContext, useEffect, useState } from 'react';
import { post } from '../lib/api';
export const DataTypesFeature = createContext(true);
export const useDataTypes = () => useContext(DataTypesFeature);
export function DataTypeBadge({ type, allowed = [] }: { type?: string; allowed?: string[] }) {
  // Disabled until /me has told us the session's type and permission: no guessed defaults.
  const enabled = useDataTypes() && type !== undefined && allowed.length > 0;
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);
  async function change(next: string) {
    if (busy || !enabled || !allowed.includes(next) || next === type) return;
    // Same guard as the company switch: the page reloads, so unsaved work must be copied first.
    if (
      !window.confirm(
        'Changing the data type closes this page. Save or copy any unsaved work first. Continue?',
      )
    )
      return;
    setBusy(true);
    try {
      await post('/auth/data-type', { type: next });
      window.location.reload();
    } catch (e) {
      setError(e instanceof Error ? e.message : 'Unable to switch data type');
      setBusy(false);
    }
  }
  useEffect(() => {
    const key = (event: KeyboardEvent) => {
      const target = event.target;
      if (
        !enabled ||
        !event.ctrlKey ||
        event.altKey ||
        event.metaKey ||
        event.shiftKey ||
        event.repeat ||
        // Ctrl+C with selected text is a copy, not a switch.
        (event.key.toUpperCase() === 'C' && (window.getSelection()?.toString() ?? '') !== '') ||
        (target instanceof HTMLElement &&
          (target.isContentEditable || target.closest('input,textarea,select,[role="textbox"]')))
      )
        return;
      const next = event.key.toUpperCase();
      if (!['B', 'C'].includes(next) || !allowed.includes(next)) return;
      event.preventDefault();
      void change(next);
    };
    window.addEventListener('keydown', key);
    return () => window.removeEventListener('keydown', key);
  });
  if (!enabled) return null;
  return (
    <>
      {type !== 'A' && (
        <button
          type="button"
          data-testid="data-type-badge"
          disabled={busy || !allowed.includes('A')}
          title={`Current data type: ${type === 'C' ? 'All' : 'B'}. Ctrl+B selects B; Ctrl+C selects All. Click to return to A when permitted.`}
          style={{ color: type === 'B' ? '#b91c1c' : '#15803d' }}
          onClick={() => void change('A')}
        >
          {type === 'C' ? 'All' : 'B'}
        </button>
      )}
      {error && <span role="alert">{error}</span>}
    </>
  );
}
export function UserDataTypeControls({
  allowed,
  defaultType,
  onChange,
}: {
  allowed: string;
  defaultType: string;
  onChange: (allowed: string, defaultType: string) => void;
}) {
  const enabled = useDataTypes();
  if (!enabled) return null;
  return (
    <fieldset>
      <legend>Data types</legend>
      {['A', 'B', 'C'].map((type) => (
        <label key={type}>
          <input
            type="checkbox"
            checked={allowed.includes(type)}
            aria-label={`Allow ${type === 'C' ? 'All' : type}`}
            onChange={(e) => {
              const next = ['A', 'B', 'C']
                .filter((t) => (t === type ? e.target.checked : allowed.includes(t)))
                .join('');
              if (next) onChange(next, next.includes(defaultType) ? defaultType : next[0]!);
            }}
          />
          {type === 'C' ? 'All' : type}
        </label>
      ))}
      <label>
        Default data type
        <select
          aria-label="Default data type"
          value={defaultType}
          onChange={(e) => onChange(allowed, e.target.value)}
        >
          {allowed.split('').map((t) => (
            <option key={t} value={t}>
              {t === 'C' ? 'All' : t}
            </option>
          ))}
        </select>
      </label>
    </fieldset>
  );
}
export function BookDataTypeControl({
  value,
  onChange,
}: {
  value: string;
  onChange: (value: string) => void;
}) {
  const enabled = useDataTypes();
  if (!enabled) return null;
  return (
    <label>
      Data type
      <select aria-label="Data type" value={value} onChange={(e) => onChange(e.target.value)}>
        <option>A</option>
        <option>B</option>
      </select>
    </label>
  );
}
