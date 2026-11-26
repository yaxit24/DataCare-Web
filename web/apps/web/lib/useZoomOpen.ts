'use client';
import { useEffect, useState } from 'react';

/**
 * Opening a voucher from a report row (RP_TAG.cs:8917 DGV_DoubleClick, RP_HUID.cs): the report opens the voucher's
 * screen with `?vchNo=<number>&coBook=<book>`; the screen selects that book and opens the voucher once its scope
 * (year, location) is known. Used by every voucher screen a report can zoom into.
 *
 * - `coBook` / `setCoBook`: the screen's book state.
 * - `ready`: the screen can read a voucher now (scope loaded).
 * - `open`: opens the voucher by number in the selected book (called once, with the book already selected).
 */
export function useZoomOpen(input: {
  coBook: string;
  setCoBook: (book: string) => void;
  ready: boolean;
  open: (vchNo: string) => unknown;
}): void {
  const { coBook, setCoBook, ready, open } = input;
  const [target, setTarget] = useState<{ vchNo: string; coBook: string } | null>(null);
  useEffect(() => {
    const q = new URLSearchParams(window.location.search);
    const vchNo = q.get('vchNo');
    const book = q.get('coBook');
    if (vchNo && book) setTarget({ vchNo, coBook: book });
  }, []);
  useEffect(() => {
    if (!target) return;
    if (coBook !== target.coBook) {
      setCoBook(target.coBook);
      return;
    }
    if (!ready) return;
    setTarget(null);
    void open(target.vchNo);
    // `open` is the screen's own closure over the state of this render, which holds the selected book.
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [target, coBook, ready]);
}
