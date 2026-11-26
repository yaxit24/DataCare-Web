'use client';
import { useCallback, useEffect, useRef, useState } from 'react';
import { ApiError, get, getDownload } from '../../../../lib/api';
import {
  EMPTY_FILTERS,
  type Column,
  type Defaults,
  type Dimension,
  type Filters,
  type MovementResult,
  type MovementRow,
  type StockResult,
  type StockRow,
  type ZoomAnswer,
} from './types';

/** The desktop's exact refusal texts (RP_STOCK.cs:4024 / :3237). */
export const NO_PRINT_RIGHTS = 'You Have No Print Rights.....';

/** MDI_FORM.cs:7047: the menu refuses a user without the View right with this text and the screen stays closed. */
export const NO_RIGHTS = 'You Have No Rights.....';
const ITEM_OPENING_REFUSAL = 'This Is a Item Wise Opening Stock Voucher You Cant Zoom ....';

const BASE = '/reports/stock-report';

/** The query one run was made with; the drill-down and the exports repeat it so every view agrees. */
function queryOf(f: Filters, dimension: Dimension): URLSearchParams {
  const q = new URLSearchParams({ dimension, fromDate: f.fromDate, toDate: f.toDate });
  q.set('weight', f.gross ? 'gross' : 'net');
  if (f.itemType) q.set('itemType', f.itemType);
  if (f.stockType !== 'all') q.set('stockType', f.stockType);
  const text: Array<[keyof Filters, string]> = [
    ['grCode', 'grCode'],
    ['prCode', 'prCode'],
    ['itCode', 'itCode'],
    ['designNo', 'designNo'],
    ['safe', 'safe'],
    ['tblCode', 'tblCode'],
    ['tagNo', 'tagNo'],
    ['acCode', 'acCode'],
  ];
  for (const [key, name] of text) {
    const v = String(f[key] ?? '').trim();
    if (v) q.set(name, v);
  }
  return q;
}

const messageOf = (e: unknown): string =>
  e instanceof ApiError ? String(e.body?.message || e.body?.error || e.message) : 'failed';

export function useStockReport() {
  const [filters, setFiltersState] = useState<Filters>(EMPTY_FILTERS);
  const [ready, setReady] = useState(false);
  const [result, setResult] = useState<StockResult | null>(null);
  const [movements, setMovements] = useState<{
    title: string;
    data: MovementResult;
    row: StockRow;
  } | null>(null);
  const [error, setError] = useState('');
  const [message, setMessage] = useState('');
  const [busy, setBusy] = useState(false);
  const [noRights, setNoRights] = useState(false);
  const [itemLot, setItemLot] = useState(false);
  const merged = useRef(false);
  const [futureWarning, setFutureWarning] = useState('');
  /** The filters of the run on screen. */
  const ran = useRef<{ filters: Filters; dimension: Dimension } | null>(null);

  const setFilters = useCallback((patch: Partial<Filters>) => {
    setFiltersState((prev) => ({ ...prev, ...patch }));
  }, []);

  useEffect(() => {
    let live = true;
    void get<Defaults>(`${BASE}/defaults`)
      .then((d) => {
        if (!live) return;
        setFiltersState((prev) => ({
          ...prev,
          fromDate: d.fromDate,
          toDate: d.toDate,
          itemType: d.itemType,
          gross: d.grossWeight,
        }));
        setFutureWarning(d.futureVoucher?.message ?? '');
        setItemLot(Boolean(d.itemLot));
        merged.current = Boolean(d.companyMerge);
        setReady(true);
      })
      .catch((e) => {
        if (!live) return;
        if (e instanceof ApiError && e.status === 403) setNoRights(true);
        else setError(messageOf(e));
      });
    return () => {
      live = false;
    };
  }, []);

  const run = useCallback(
    async (dimension: Dimension) => {
      setBusy(true);
      setError('');
      setMessage('');
      setMovements(null);
      try {
        const snapshot = { ...filters };
        const res = await get<StockResult>(`${BASE}?${queryOf(snapshot, dimension).toString()}`);
        ran.current = { filters: snapshot, dimension };
        setResult(res);
      } catch (e) {
        setError(messageOf(e));
      } finally {
        setBusy(false);
      }
    },
    [filters],
  );

  const drill = useCallback(async (row: StockRow, column: Column) => {
    const r = ran.current;
    if (!r) return;
    setBusy(true);
    setError('');
    try {
      const q = queryOf(r.filters, r.dimension);
      q.set('key', row.code);
      q.set('rowType', row.itType);
      q.set('column', column);
      const data = await get<MovementResult>(`${BASE}/movements?${q.toString()}`);
      setMovements({ title: `${row.name} ${column}`, data, row });
    } catch (e) {
      setError(messageOf(e));
    } finally {
      setBusy(false);
    }
  }, []);

  const back = useCallback(() => setMovements(null), []);

  /** Double click on a movement row: the screen to open, or the desktop's refusal (RP_STOCK.cs:5218-5263). */
  const zoom = useCallback(async (row: MovementRow): Promise<ZoomAnswer | null> => {
    // Nothing opens while the companies' stock is merged (RP_STOCK.cs:5225).
    if (merged.current) return { action: 'none' };
    setMessage('');
    // A voucher number shorter than three characters is an Item Opening row (RP_STOCK.cs:5263): its book is not one an
    // entry screen opens, so the refusal does not need the server.
    if ((row.vchNo ?? '').trim().length < 3) {
      setMessage(ITEM_OPENING_REFUSAL);
      return { action: 'refuse', message: ITEM_OPENING_REFUSAL };
    }
    if (!row.coBook) return null;
    try {
      const answer = await get<ZoomAnswer>(
        `${BASE}/zoom?coBook=${encodeURIComponent(row.coBook)}&vchNo=${encodeURIComponent(row.vchNo ?? '')}`,
      );
      if (answer.action === 'refuse') setMessage(answer.message);
      return answer;
    } catch (e) {
      setError(messageOf(e));
      return null;
    }
  }, []);

  /** Ticking Gross Wise Weight clears an open drill-down but does NOT refresh the summary (RP_STOCK.cs:5710). */
  const setGross = useCallback(
    (gross: boolean) => {
      setFilters({ gross });
      setMovements(null);
    },
    [setFilters],
  );

  /** Cancel clears the form (CLEAR_DATA): the grid and the typed filters, back to the form defaults. */
  const clear = useCallback(async () => {
    setResult(null);
    setMovements(null);
    setError('');
    setMessage('');
    ran.current = null;
    try {
      const d = await get<Defaults>(`${BASE}/defaults`);
      setFiltersState({
        ...EMPTY_FILTERS,
        fromDate: d.fromDate,
        toDate: d.systemDate,
        itemType: d.itemType,
        gross: d.grossWeight,
      });
    } catch (e) {
      setError(messageOf(e));
    }
  }, []);

  /** The query of the run on screen, for the documents that repeat it (the InOut ledger uses its dates). */
  const ranFilters = useCallback(() => ran.current?.filters ?? null, []);

  /** The printed document of the run on screen: the same query, as a PDF (RP_STOCK.cs:4020). */
  const printUrl = useCallback((): string | null => {
    const r = ran.current;
    return r ? `/api${BASE}/export.pdf?${queryOf(r.filters, r.dimension).toString()}` : null;
  }, []);

  /** Print and Excel need the Print right: the API answers 403 and the screen shows the desktop text. */
  const exportFile = useCallback(async (kind: 'csv' | 'xlsx'): Promise<Blob | null> => {
    const r = ran.current;
    if (!r) return null;
    setMessage('');
    try {
      const file = await getDownload(
        `${BASE}/export.${kind}?${queryOf(r.filters, r.dimension).toString()}`,
      );
      return file.blob;
    } catch (e) {
      if (e instanceof ApiError && e.status === 403) setMessage(NO_PRINT_RIGHTS);
      else setError(messageOf(e));
      return null;
    }
  }, []);

  return {
    filters,
    setFilters,
    setGross,
    ready,
    result,
    movements,
    error,
    message,
    busy,
    noRights,
    itemLot,
    futureWarning,
    run,
    drill,
    zoom,
    notify: setMessage,
    back,
    clear,
    exportFile,
    printUrl,
    ranFilters,
    dimension: ran.current?.dimension ?? null,
  };
}
