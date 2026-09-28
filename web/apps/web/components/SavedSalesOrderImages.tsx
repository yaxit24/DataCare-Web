'use client';

import { useEffect, useRef, useState } from 'react';
import { ApiError, get } from '../lib/api';
import { BookSelect } from './BookSelect';
import { useBusinessScope } from './BusinessScope';
import { OrderImagePanel } from './OrderImagePanel';

interface SavedOrder {
  voucherNo: string;
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
  lines: Array<{ srNo: number; itCode: string; designNo: string }>;
}
/** Sales creation does not hydrate existing orders; explicitly choose an actual saved parent for images. */
export function SavedSalesOrderImages() {
  const scope = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [lookup, setLookup] = useState('');
  const [saved, setSaved] = useState<{ scope: string; order: SavedOrder } | null>(null);
  const [srNo, setSrNo] = useState('');
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);
  const query = new URLSearchParams({ ...scope, coBook }).toString();
  const current = useRef(query);
  current.current = query;
  const generation = useRef(0);
  useEffect(() => {
    generation.current += 1;
    setSaved(null);
    setSrNo('');
    setError('');
    setBusy(false);
    return () => {
      generation.current += 1;
    };
  }, [query]);
  async function open() {
    if (!coBook || !lookup.trim()) return;
    const request = ++generation.current;
    setSaved(null);
    setSrNo('');
    setError('');
    setBusy(true);
    try {
      const order = await get<SavedOrder>(
        `/sales-orders/${encodeURIComponent(lookup.trim())}?${query}`,
      );
      if (current.current !== query || request !== generation.current) return;
      if (
        order.coCode !== scope.coCode ||
        order.lcCode !== scope.lcCode ||
        order.coYear !== scope.coYear ||
        order.coBook !== coBook
      )
        throw new Error(
          'The saved order does not belong to the selected company, branch, year and book.',
        );
      setSaved({ scope: query, order });
      setSrNo(String(order.lines[0]?.srNo ?? ''));
    } catch (caught) {
      if (current.current === query && request === generation.current)
        setError(
          caught instanceof ApiError
            ? caught.body?.message || caught.message
            : caught instanceof Error
              ? caught.message
              : 'Order could not be loaded.',
        );
    } finally {
      if (current.current === query && request === generation.current) setBusy(false);
    }
  }
  const order = saved?.scope === query ? saved.order : null;
  return (
    <section data-testid="sales-order-saved-images">
      <div className="panel">
        <h2>Saved order images</h2>
        <div className="toolbar">
          <label>
            Sales Order book{' '}
            <BookSelect
              key={`${scope.coCode}/${scope.lcCode}/${scope.coYear}`}
              value={coBook}
              onChange={setCoBook}
              preferred="SOR"
              mainBooks={['SALES ORDER']}
            />
          </label>
          <label>
            Saved order number{' '}
            <input
              data-testid="sales-order-image-lookup"
              value={lookup}
              onChange={(event) => setLookup(event.target.value)}
            />
          </label>
          <button
            type="button"
            disabled={!coBook || !lookup.trim() || busy}
            onClick={() => void open()}
          >
            Load order images
          </button>
          {order && (
            <label>
              Saved item{' '}
              <select
                data-testid="sales-order-image-parent"
                value={srNo}
                onChange={(event) => setSrNo(event.target.value)}
              >
                {order.lines.map((line) => (
                  <option key={line.srNo} value={line.srNo}>
                    {line.srNo} — {line.itCode} · {line.designNo || 'No design number'}
                  </option>
                ))}
              </select>
            </label>
          )}
        </div>
        {error && (
          <p className="msg err" role="alert">
            {error}
          </p>
        )}
        {order && !order.lines.length && (
          <p className="muted">This saved order has no item rows.</p>
        )}
      </div>
      <OrderImagePanel
        family="sales-orders"
        scope={scope}
        coBook={coBook}
        voucherNo={order?.voucherNo ?? ''}
        srNo={srNo}
        disabled={busy}
        testId="sales-order-image"
      />
    </section>
  );
}
