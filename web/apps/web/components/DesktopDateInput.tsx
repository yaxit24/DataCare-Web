'use client';
import { forwardRef, useEffect, useImperativeHandle, useRef, useState } from 'react';
import {
  DESKTOP_DATE_MASK,
  desktopDateMaskText,
  desktopSetDate,
  formatDesktopDate,
  type SetDateMessage,
} from '@datacare/core';

/**
 * A desktop masked date box (`MaskedTextBox` "dd/MM/yyyy") with `DC_Main.SetDate` on Enter (DC_Main.cs:1561-1683):
 * the text is completed from today and the session year, impossible days/months get the desktop's OK-only message
 * ("Date Not Valid..." / "Month Not Valid...") and the box is cleared to the empty mask with the focus kept in it,
 * a one-digit entry is refused silently, and a valid entry moves on (`SendKeys.Send("{tab}")`). The text is selected
 * on focus (RP_GST.cs:3065-3076). `onChange` receives the ISO date once the text is a real calendar date, else ''.
 */
export interface DesktopDateInputHandle {
  /** Run SetDate on the current text: the ISO date, or null when it was refused (a message is then shown). */
  commit(): string | null;
  focus(): void;
}

const isoOf = (text: string): string => {
  const match = /^(\d{2})\/(\d{2})\/(\d{4})$/.exec(text);
  if (!match) return '';
  const [day, month, year] = [Number(match[1]), Number(match[2]), Number(match[3])];
  const date = new Date(Date.UTC(year, month - 1, day));
  return date.getUTCFullYear() === year &&
    date.getUTCMonth() === month - 1 &&
    date.getUTCDate() === day
    ? `${match[3]}-${match[2]}-${match[1]}`
    : '';
};

const digitsOf = (text: string): string => text.replace(/\D/g, '');

export const DesktopDateInput = forwardRef<
  DesktopDateInputHandle,
  {
    id: string;
    label: string;
    value: string;
    coYear: string;
    autoFocus?: boolean;
    onChange: (iso: string) => void;
    onAdvance?: () => void;
  }
>(function DesktopDateInput({ id, label, value, coYear, autoFocus, onChange, onAdvance }, ref) {
  const input = useRef<HTMLInputElement>(null);
  const [text, setText] = useState(() => (value ? formatDesktopDate(value) : DESKTOP_DATE_MASK));
  const [message, setMessage] = useState<SetDateMessage | null>(null);
  const okButton = useRef<HTMLButtonElement>(null);

  useEffect(() => {
    // An outside change (defaults, a reset) replaces the text; the box's own edits arrive here as the same ISO.
    if (value && isoOf(text) !== value) setText(formatDesktopDate(value));
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [value]);
  useEffect(() => {
    if (message) okButton.current?.focus();
  }, [message]);

  const update = (next: string) => {
    setText(next);
    onChange(isoOf(next));
  };
  const commit = (): string | null => {
    const now = new Date();
    const result = desktopSetDate(text, {
      coYear,
      today: { day: now.getDate(), month: now.getMonth() + 1 },
    });
    if (result.ok) {
      // SetDate accepts 31/04 and 29/02 of any year; the desktop then fails converting the date when it runs.
      const iso = isoOf(result.text);
      if (!iso) {
        update(DESKTOP_DATE_MASK);
        setMessage('Date Not Valid...');
        return null;
      }
      update(result.text);
      return iso;
    }
    if (!result.silent) {
      update(result.text);
      setMessage(result.message);
    }
    return null;
  };
  useImperativeHandle(ref, () => ({ commit, focus: () => input.current?.focus() }));

  const closeMessage = () => {
    setMessage(null);
    input.current?.focus();
    input.current?.select();
  };

  return (
    <>
      <label htmlFor={id}>{label}</label>
      <input
        id={id}
        ref={input}
        inputMode="numeric"
        autoComplete="off"
        value={text}
        autoFocus={autoFocus}
        placeholder={DESKTOP_DATE_MASK}
        style={{ width: '10ch', fontFamily: 'monospace' }}
        onFocus={(event) => event.currentTarget.select()}
        onChange={(event) => update(desktopDateMaskText(digitsOf(event.target.value)))}
        onKeyDown={(event) => {
          if (event.key === 'Backspace' || event.key === 'Delete') {
            event.preventDefault();
            const target = event.currentTarget;
            const all = target.selectionStart === 0 && target.selectionEnd === target.value.length;
            update(desktopDateMaskText(all ? '' : digitsOf(text).slice(0, -1)));
            return;
          }
          if (event.key !== 'Enter') return;
          event.preventDefault();
          if (commit() != null) onAdvance?.();
        }}
      />
      {message && (
        <div className="panel" role="alertdialog" aria-label={message} aria-modal="true">
          <p style={{ margin: '0 0 8px' }}>{message}</p>
          <button type="button" ref={okButton} onClick={closeMessage}>
            OK
          </button>
        </div>
      )}
    </>
  );
});
