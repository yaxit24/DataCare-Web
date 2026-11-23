'use client';
import { focusNext } from '../../../../components/focus';
import { desktopText } from './LookupField';

/** Editable combo fallback until the report API supplies AC_MAST city/area choices. */
export function ListField({
  label,
  value,
  options,
  onChange,
}: {
  label: string;
  value: string;
  options: readonly string[];
  onChange: (value: string) => void;
}) {
  const id = `or-${label.replaceAll(' ', '-')}`;
  return (
    <div className="field" style={{ minWidth: 130 }}>
      <label htmlFor={id}>{label}</label>
      <input
        id={id}
        aria-label={label}
        list={`${id}-options`}
        value={value}
        onChange={(event) => onChange(desktopText(event.target.value))}
        onKeyDown={(event) => {
          if (event.key === 'Enter') {
            event.preventDefault();
            focusNext(event.currentTarget);
          }
        }}
      />
      <datalist id={`${id}-options`}>
        {options.map((option) => (
          <option key={option} value={option} />
        ))}
      </datalist>
    </div>
  );
}
