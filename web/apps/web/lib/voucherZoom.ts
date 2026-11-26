'use client';
import { useEffect, useRef } from 'react';

/**
 * The target of a zoom from a report: `?vchNo=&coBook=` on an entry screen opens that voucher (the desktop report
 * sets DC_Main.CurBookVch / CurBook and shows the entry form, RP_STOCK.cs:5240-5600). The screen opens it once its
 * books have loaded: when the voucher is in another book than the screen picked first, the book is switched and the
 * voucher is opened as soon as that book is selected.
 */
export function useVoucherZoom({
  ready,
  book,
  setBook,
  load,
}: {
  /** The screen's books (and any settings the voucher load needs) are loaded. */
  ready: boolean;
  /** The book the screen has selected now. */
  book: string;
  setBook: (book: string) => void;
  load: (vchNo: string, book: string) => unknown;
}): void {
  const target = useRef<{ vchNo: string; book: string } | null | undefined>(undefined);
  useEffect(() => {
    // Read the address after the screen has mounted: a client-side navigation updates it after the first render.
    if (target.current === undefined) {
      const q = new URLSearchParams(window.location.search);
      const vchNo = q.get('vchNo') ?? '';
      target.current = vchNo ? { vchNo, book: q.get('coBook') ?? '' } : null;
    }
    const t = target.current;
    if (!t || !ready) return;
    if (t.book && book !== t.book) {
      setBook(t.book);
      return;
    }
    target.current = null;
    void load(t.vchNo, t.book || book);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [ready, book]);
}
