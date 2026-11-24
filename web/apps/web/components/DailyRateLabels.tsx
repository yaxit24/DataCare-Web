'use client';
import { useCallback, useEffect, useState } from 'react';
import { get } from '../lib/api';
import { todayLocal } from '../lib/localDate';

/** Fired after Daily Rate commits a save or a delete, so mounted labels read the stored rates again. */
export const DAILY_RATE_CHANGED = 'datacare:daily-rate-changed';

interface Labels {
  empty: string;
  labels: Array<{ grCode: string; text: string }>;
}

/**
 * The main window's rate labels (desktop MDI_FORM Rate_1 to Rate_7, MDI_FORM.cs:11421-11500): today's saved rates of
 * this company and location for the groups that show a rate, 'GR_NAME  -  0.00', at most seven. With no rate for today
 * the first label reads 'ToDays Rate :'; there is no fallback to another day or location. The set is replaced as a
 * whole on every read, so a shorter list leaves no stale label behind.
 */
export function DailyRateLabels() {
  const [data, setData] = useState<Labels | null>(null);
  const load = useCallback(() => {
    get<Labels>(`/daily-rate/labels?date=${todayLocal()}`)
      .then((d) => setData(d))
      .catch(() => {});
  }, []);
  useEffect(() => {
    load();
    window.addEventListener(DAILY_RATE_CHANGED, load);
    return () => window.removeEventListener(DAILY_RATE_CHANGED, load);
  }, [load]);
  if (!data) return null;
  const items = data.labels.length
    ? data.labels.map((l) => ({ key: l.grCode, text: l.text }))
    : [{ key: 'empty', text: data.empty }];
  return (
    <div
      data-testid="daily-rate-labels"
      aria-label="Today's rates"
      style={{ display: 'flex', flexWrap: 'wrap', gap: 16, fontSize: 13, margin: '0 0 10px' }}
    >
      {items.map((item, i) => (
        <span key={item.key} data-rate-label={i + 1} style={{ whiteSpace: 'pre' }}>
          {item.text}
        </span>
      ))}
    </div>
  );
}
