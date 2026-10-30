'use client';
import { useCallback, useRef, useState, type KeyboardEvent } from 'react';
import { ApiError, get } from '../lib/api';
import {
  LAST_RECORD_MESSAGE,
  neighbourPath,
  voucherNumberKey,
  type NeighbourVoucher,
} from '../lib/voucherNumberKeys';

export interface VoucherNumberKeyOptions {
  /** The voucher header table, e.g. SL_DATA (allow-listed by the API). */
  table: string;
  /** The book selected on the screen. */
  book: string;
  /** The number in the voucher number box ('' in the new-entry state). */
  value: string;
  /** Open a saved voucher; resolves true when it loaded. */
  open: (vchNo: string) => Promise<boolean>;
  /** Show a blank new voucher. */
  fresh: () => void;
  /** F1: show the voucher list. */
  list: () => void;
  /** After Enter opens a voucher, the desktop moves to the voucher date (DISPLAY_DATA, TR_SALE.cs:14845). */
  focusDate?: () => void;
}

/**
 * The voucher number box's keys (N172, G179). Returns the box's onKeyDown and the note to show next to it.
 * Up and Down keep the focus in the box, as the desktop does (TR_SALE.cs:17189, :17220), so the operator can keep
 * stepping. A key pressed while a step is still loading is ignored.
 */
export function useVoucherNumberKeys(options: VoucherNumberKeyOptions) {
  const { table, book, value, open, fresh, list, focusDate } = options;
  const [note, setNote] = useState('');
  const pending = useRef(false);
  const onKeyDown = useCallback(
    (event: KeyboardEvent<HTMLInputElement>) => {
      const key = voucherNumberKey(event);
      if (!key) return;
      // F1 would open the browser's help, Enter would move to the next field, and the arrows move the caret.
      event.preventDefault();
      if (pending.current) return;
      setNote('');
      if (key === 'list') {
        list();
        return;
      }
      pending.current = true;
      const step = async () => {
        if (key === 'open') {
          // An empty box is the new-entry state: Enter just moves on to the date, as on the desktop.
          if (!value.trim() || (await open(value.trim()))) focusDate?.();
          return;
        }
        const answer = await get<NeighbourVoucher>(neighbourPath(table, book, value, key));
        if (answer.action === 'open') await open(answer.vchNo);
        else if (answer.action === 'new') fresh();
        else if (answer.action === 'last') setNote(LAST_RECORD_MESSAGE);
        else if (answer.action === 'missing') {
          fresh();
          setNote(`No voucher ${answer.vchNo} in this book`);
        }
      };
      step()
        .catch((error) =>
          setNote(
            error instanceof ApiError
              ? error.body?.message || error.body?.error || error.message
              : 'failed',
          ),
        )
        .finally(() => {
          pending.current = false;
        });
    },
    [table, book, value, open, fresh, list, focusDate],
  );
  return { onKeyDown, note };
}
