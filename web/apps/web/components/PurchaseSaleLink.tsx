'use client';

import { useRef, useState, type ReactNode } from 'react';
import { useRouter } from 'next/navigation';
import { ApiError, post } from '../lib/api';
import { useBusinessScope } from './BusinessScope';

interface Link {
  saleBillBook: string;
  saleBillNo: string;
  saleBillYear: string;
  saleBillLc: string;
  exists: boolean;
}

/** TR_PURC.cs:13724-13740, :13443-13447, :16024; owner decision 2B keeps standalone linked purchases read-only. */
export function PurchaseSaleLink({
  view,
  book,
  voucher,
  version,
  onClear,
  children,
}: {
  view: Record<string, unknown> | null;
  book: string;
  voucher: string;
  version: string;
  onClear: () => void;
  children: ReactNode;
}) {
  const link = view?.linkedSale as Link | null | undefined;
  const router = useRouter();
  const scope = useBusinessScope();
  const dialog = useRef<HTMLDialogElement>(null);
  const [busy, setBusy] = useState(false);
  const [error, setError] = useState('');
  const sameScope = link?.saleBillYear === scope.coYear && link?.saleBillLc === scope.lcCode;
  const amount = Number(
    (view?.totals as { total?: number } | undefined)?.total ?? 0,
  ).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
  async function remove() {
    setBusy(true);
    setError('');
    try {
      await post(
        `/purchases/${encodeURIComponent(voucher)}/delete-stray-link?${new URLSearchParams({ coBook: book, expectedVersion: version })}`,
        {},
      );
      dialog.current?.close();
      onClear();
    } catch (e) {
      setError(e instanceof ApiError ? e.body?.message || e.message : 'Could not delete purchase');
    } finally {
      setBusy(false);
    }
  }
  return (
    <>
      {link && (
        <div className="panel" data-testid="purchase-sale-link">
          <p>
            {link.exists
              ? `Old gold taken on sale ${link.saleBillBook}/${link.saleBillNo} — edit it from that sale`
              : `Linked to sale ${link.saleBillBook}/${link.saleBillNo}, which does not exist`}
          </p>
          {link.exists ? (
            <>
              <button
                type="button"
                disabled={!sameScope}
                onClick={() =>
                  router.push(
                    `/txn/sales?${new URLSearchParams({ coBook: link.saleBillBook, vchNo: link.saleBillNo })}`,
                  )
                }
              >
                Open sale
              </button>
              {!sameScope && (
                <p>
                  Select location {link.saleBillLc}, year {link.saleBillYear} to open this sale.
                </p>
              )}
            </>
          ) : (
            <button
              type="button"
              className="danger"
              onClick={() => {
                setError('');
                dialog.current?.showModal();
              }}
            >
              Delete this stray purchase…
            </button>
          )}{' '}
          <button type="button" onClick={onClear}>
            New purchase
          </button>
          <dialog
            className="panel"
            style={{ maxWidth: 560 }}
            ref={dialog}
            aria-label="Delete stray purchase"
            onCancel={(e) => {
              if (busy) e.preventDefault();
            }}
          >
            <p>
              Delete purchase {book}/{voucher} for ₹{amount}? This reverses its ledger and stock.
            </p>
            {error && (
              <p className="msg err" role="alert">
                {error}
              </p>
            )}
            <button type="button" className="danger" disabled={busy} onClick={() => void remove()}>
              Confirm delete
            </button>{' '}
            <button type="button" autoFocus disabled={busy} onClick={() => dialog.current?.close()}>
              Cancel
            </button>
          </dialog>
        </div>
      )}
      {children}
    </>
  );
}

/** Disable entry controls while keeping voucher navigation outside this boundary. */
export function PurchaseEntryFields({
  view,
  children,
}: {
  view: Record<string, unknown> | null;
  children: ReactNode;
}) {
  return (
    <fieldset
      disabled={!!view?.linkedSale}
      style={{ border: 0, padding: 0, margin: 0, minWidth: 0 }}
    >
      {children}
    </fieldset>
  );
}
