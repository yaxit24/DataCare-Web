'use client';

import { useEffect, useRef, useState } from 'react';
import { createPortal } from 'react-dom';
import { ApiError, postCommand, put } from '../lib/api';
import { useIdempotencyKey } from '../lib/idempotencyKey';

/**
 * Owner decision 3B (2026-11-27): the Sales Invoice may adjust another customer's order advance, or more than the
 * order's open advance, only after the operator answers Yes to the facts. The API refuses such a save with 409
 * `order-advance-confirm` and the facts in `details` (apps/api/src/modules/sales/orderAdvanceConfirm.ts); Yes sends
 * the same save again with `orderAdvanceAck` naming exactly those facts, No returns to the order amount.
 *
 * The retail sale create sends the draft's Idempotency-Key (N52; owner decision 2B writes the linked URD purchase in
 * the same transaction, so a replay must post neither twice). A refused save keeps no receipt, so the resend with
 * the acknowledgement under the same key is a new save; the key is renewed only after a successful save.
 */
export interface OrderAdvanceFacts {
  orderKey: string;
  ordNo: string;
  ordBook: string;
  orderParty: string;
  orderPartyName: string;
  saleParty: string;
  salePartyName: string;
  openAmount: number;
  adjustAmount: number;
  overBy: number;
  otherCustomer: boolean;
}
interface Refusal {
  reason: 'confirm' | 'stale';
  rows: OrderAdvanceFacts[];
}

const money = (v: number) => Number(v || 0).toFixed(2);
const party = (name: string, code: string) => (name ? `${name} (${code})` : code);

/** The facts in plain words (the same sentence the API's message carries). */
export function orderAdvanceQuestion(f: OrderAdvanceFacts): string {
  const owner = `Order ${f.ordNo} (${f.ordBook}) belongs to ${party(f.orderPartyName, f.orderParty)}${
    f.otherCustomer ? ", not to this bill's customer" : ''
  }.`;
  const over = f.overBy > 0 ? `, ${money(f.overBy)} more than is open` : '';
  return `${owner} It has ${money(f.openAmount)} advance open. You are adjusting ${money(f.adjustAmount)} on ${party(f.salePartyName, f.saleParty)}'s bill${over}.`;
}

function refusalOf(e: unknown): Refusal | null {
  if (!(e instanceof ApiError) || e.status !== 409 || e.body?.error !== 'order-advance-confirm')
    return null;
  const rows = e.body?.details?.rows;
  return Array.isArray(rows) && rows.length ? (e.body.details as Refusal) : null;
}

/** No: back to the order amount of the first refused order (grid row, else the header box). */
function focusOrderAmount(ordNo: string) {
  const want = Number(ordNo);
  const cells = Array.from(
    document.querySelectorAll<HTMLInputElement>('input[aria-label^="Order No line "]'),
  );
  const hit = cells.find((c) => c.value.trim() !== '' && Number(c.value) === want);
  const line = hit?.getAttribute('aria-label')?.replace('Order No line ', '');
  const target =
    (line &&
      document.querySelector<HTMLInputElement>(`input[aria-label="Order Amt line ${line}"]`)) ||
    document.querySelector<HTMLInputElement>('input[placeholder="advance to apply"]');
  setTimeout(() => {
    target?.focus();
    target?.select();
  }, 0);
}

/** The retail sale save: PUT over a loaded voucher (with its version), else POST; `extra` adds the acknowledgement. */
export const saleSaveRequest =
  <T,>(vchNo: string, version: string, body: Record<string, unknown>) =>
  (extra: Record<string, unknown>, key: string) =>
    vchNo
      ? put<T>(`/sales/${encodeURIComponent(vchNo)}`, {
          ...body,
          ...extra,
          expectedVersion: version,
        })
      : postCommand<T>('/sales', { ...body, ...extra }, key);

export function useOrderAdvanceConfirm() {
  const command = useIdempotencyKey();
  const [asking, setAsking] = useState<(Refusal & { answer: (yes: boolean) => void }) | null>(null);
  const [notes, setNotes] = useState<string[]>([]);
  const marker = useRef<HTMLSpanElement>(null);
  // While the question is open the sale form is inert, so what Yes saves is exactly what is on screen.
  useEffect(() => {
    const form = marker.current?.closest('form');
    if (!form || !asking) return;
    form.setAttribute('inert', '');
    return () => form.removeAttribute('inert');
  }, [asking]);

  /** Run the save; on the 3B refusal ask, and on Yes resend with the acknowledgement. Null when the operator says No. */
  async function save<T>(
    send: (extra: Record<string, unknown>, key: string) => Promise<T>,
  ): Promise<T | null> {
    let extra: Record<string, unknown> = {};
    for (;;) {
      try {
        const saved = await send(extra, command.key);
        command.renew();
        return saved;
      } catch (e) {
        const refusal = refusalOf(e);
        if (!refusal) throw e;
        const yes = await new Promise<boolean>((answer) => setAsking({ ...refusal, answer }));
        setAsking(null);
        if (!yes) {
          focusOrderAmount(refusal.rows[0]!.ordNo);
          return null;
        }
        extra = {
          orderAdvanceAck: refusal.rows.map((r) => ({
            orderKey: r.orderKey,
            orderParty: r.orderParty,
            openAmount: r.openAmount,
            adjustAmount: r.adjustAmount,
          })),
        };
      }
    }
  }

  const node = (
    <>
      <span ref={marker} hidden />
      {notes.map((note) => (
        <div key={note} className="msg" role="note" data-order-advance-note>
          {note}
        </div>
      ))}
      {asking &&
        createPortal(
          <div
            className="panel"
            role="alertdialog"
            aria-modal="true"
            aria-label="Confirm order advance"
            style={{
              position: 'fixed',
              top: '30%',
              left: '50%',
              transform: 'translateX(-50%)',
              zIndex: 1000,
              maxWidth: 560,
              boxShadow: '0 4px 24px rgba(0,0,0,.35)',
            }}
            onKeyDown={(event) => {
              if (event.key === 'Escape') {
                event.preventDefault();
                asking.answer(false);
              }
            }}
          >
            {asking.reason === 'stale' && (
              <p style={{ margin: '0 0 8px' }}>
                The order&apos;s figures changed since you confirmed. Please check them again.
              </p>
            )}
            {asking.rows.map((row) => (
              <p key={row.orderKey} style={{ margin: '0 0 8px' }}>
                {orderAdvanceQuestion(row)}
              </p>
            ))}
            <p style={{ margin: '0 0 8px' }}>
              <b>Continue?</b> Yes saves the bill and records that you confirmed it.
            </p>
            <button type="button" className="danger" onClick={() => asking.answer(true)}>
              Yes
            </button>{' '}
            <button type="button" autoFocus onClick={() => asking.answer(false)}>
              No
            </button>
          </div>,
          document.body,
        )}
    </>
  );

  return {
    save,
    /** The Sales Invoice save (saleSaveRequest) through `save`. */
    saveSale: <T,>(vchNo: string, version: string, body: Record<string, unknown>) =>
      save(saleSaveRequest<T>(vchNo, version, body)),
    node,
    /** The reopened sale's confirmation notes (GET /sales/:vchNo `orderAdvanceNotes`); null clears them. */
    load: (view: { orderAdvanceNotes?: unknown } | null) =>
      setNotes(Array.isArray(view?.orderAdvanceNotes) ? view.orderAdvanceNotes.map(String) : []),
  };
}
