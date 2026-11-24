'use client';
import { focusNext } from '../../../../components/focus';
import { desktopText } from './LookupField';

/** Editable combo (cboCity, cboArea and cboEmploy are DropDown combos): typed text is kept, the list only suggests. */
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
  const id = `sr-${label.replaceAll(' ', '-')}`;
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
