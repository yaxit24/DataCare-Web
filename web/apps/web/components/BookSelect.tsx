'use client';

import { useEffect, useRef, useState } from 'react';
import { get } from '../lib/api';

export interface ScopeBook {
  CO_BOOK: string;
  BOOK_NAME: string | null;
  BOOK_SNAME: string | null;
  MAIN_BOOK?: string | null;
}

export function BookSelect({
  value,
  onChange,
  preferred,
  mainBooks,
  disabled = false,
}: {
  value: string;
  onChange: (book: string) => void;
  /** Historical desktop/web default; used only if that code is active in BOOK_DATA. */
  preferred?: string;
  /** Optional authoritative BOOK_DATA.MAIN_BOOK values accepted by this workflow. */
  mainBooks?: string[];
  disabled?: boolean;
}) {
  const [books, setBooks] = useState<ScopeBook[]>([]);
  const [loaded, setLoaded] = useState(false);
  const valueRef = useRef(value);
  const onChangeRef = useRef(onChange);
  const mainBookFilter = (mainBooks ?? []).map((name) => name.trim().toUpperCase()).filter(Boolean);
  const mainBookKey = mainBookFilter.join('|');
  useEffect(() => {
    valueRef.current = value;
    onChangeRef.current = onChange;
  }, [onChange, value]);

  useEffect(() => {
    let cancelled = false;
    get<ScopeBook[]>('/context/books')
      .then((rows) => {
        if (cancelled) return;
        const active = rows.filter(
          (row) =>
            String(row.CO_BOOK ?? '').trim() &&
            (!mainBookFilter.length ||
              mainBookFilter.includes(
                String(row.MAIN_BOOK ?? '')
                  .trim()
                  .toUpperCase(),
              )),
        );
        setBooks(active);
        setLoaded(true);
        if (active.some((row) => row.CO_BOOK === valueRef.current)) return;
        const configuredPreferred = active.find((row) => row.CO_BOOK === preferred)?.CO_BOOK;
        onChangeRef.current(configuredPreferred ?? (active.length === 1 ? active[0]!.CO_BOOK : ''));
      })
      .catch(() => {
        if (cancelled) return;
        setBooks([]);
        setLoaded(true);
        onChangeRef.current('');
      });
    return () => {
      cancelled = true;
    };
  }, [preferred, mainBookKey]);

  return (
    <select
      value={value}
      onChange={(event) => onChange(event.target.value)}
      disabled={disabled || !loaded || books.length === 0}
      required
      aria-label="Configured book"
    >
      <option value="">
        {!loaded ? 'Loading books…' : books.length ? 'Select configured book…' : 'No active books'}
      </option>
      {books.map((book) => (
        <option key={book.CO_BOOK} value={book.CO_BOOK}>
          {book.CO_BOOK} — {book.BOOK_NAME || book.BOOK_SNAME || 'Unnamed book'}
        </option>
      ))}
    </select>
  );
}
