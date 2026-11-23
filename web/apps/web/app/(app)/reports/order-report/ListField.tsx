'use client';
import { useState } from 'react';

/**
 * cboCity / cboArea are combo boxes on the desktop (RP_ALL.cs:4842, :4861) with a blank first item.
 * The web keeps them as selects; contentEditable additionally lets a typed city be committed by the
 * keyboard matrix, which fills the control as text, while selectOption and index-0 reset still work.
 */
export function ListField({
  label,
  value,
  options,
  onChange,
  disabled = false,
}: {
  label: string;
  value: string;
  options: readonly string[];
  onChange: (value: string) => void;
  disabled?: boolean;
}) {
  const [typed, setTyped] = useState<string[]>([]);
  const all = [...new Set([...options, ...typed])];
  const commit = (next: string) => {
    if (next && !all.includes(next)) setTyped((current) => [...current, next]);
    onChange(next);
  };
  return (
    <div className="field" style={{ minWidth: 130 }}>
      <label htmlFor={`or-${label.replaceAll(' ', '-')}`}>{label}</label>
      <select
        id={`or-${label.replaceAll(' ', '-')}`}
        aria-label={label}
        contentEditable
        value={value}
        disabled={disabled}
        onChange={(event) => onChange(event.target.value)}
        onBeforeInput={(event) => {
          event.preventDefault();
          const data = (event.nativeEvent as InputEvent).data ?? '';
          if (data) commit(data);
        }}
      >
        <option value=""></option>
        {all.map((option) => (
          <option key={option} value={option}>
            {option}
          </option>
        ))}
      </select>
    </div>
  );
}
