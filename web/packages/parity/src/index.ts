/**
 * @datacare/parity — golden-master diff engine (Req 21).
 * Compares two row sets (desktop SQL Server "expected" vs web Postgres "actual") by primary key,
 * normalizing numeric fields to a precision so FLOAT(desktop) vs NUMERIC(web) match within tolerance.
 * Used by Task 8 (ETL round-trip) and Task 30 (full parity suite).
 */
export type Row = Record<string, unknown>;

export interface ValueMismatch {
  key: string;
  field: string;
  expected: unknown;
  actual: unknown;
}

export interface DiffResult {
  expectedCount: number;
  actualCount: number;
  countMatch: boolean;
  missing: string[];
  extra: string[];
  valueMismatches: ValueMismatch[];
  ok: boolean;
}

export interface DiffOptions {
  numericFields?: Record<string, number>;
  ignore?: string[];
}

export function pkKey(row: Row, pk: string[]): string {
  return pk.map((f) => String(row[f] ?? '')).join('|');
}

function roundTo(n: number, dp: number): number {
  const f = 10 ** dp;
  return Math.round((n + Number.EPSILON) * f) / f;
}

export function normalize(value: unknown, dp?: number): unknown {
  if (value === null || value === undefined) return null;
  if (typeof dp === 'number') {
    const num = typeof value === 'string' ? Number(value) : (value as number);
    if (!Number.isNaN(num)) return roundTo(num, dp);
  }
  if (value instanceof Date) return value.toISOString().slice(0, 10);
  return value;
}

export function diffRows(
  expected: Row[],
  actual: Row[],
  pk: string[],
  opts: DiffOptions = {},
): DiffResult {
  const ignore = new Set(opts.ignore ?? []);
  const numeric = opts.numericFields ?? {};
  const expMap = new Map(expected.map((r) => [pkKey(r, pk), r]));
  const actMap = new Map(actual.map((r) => [pkKey(r, pk), r]));

  const missing: string[] = [];
  const extra: string[] = [];
  const valueMismatches: ValueMismatch[] = [];

  for (const [key, er] of expMap) {
    const ar = actMap.get(key);
    if (!ar) {
      missing.push(key);
      continue;
    }
    const fields = new Set([...Object.keys(er), ...Object.keys(ar)]);
    for (const f of fields) {
      if (ignore.has(f) || pk.includes(f)) continue;
      const dp = numeric[f];
      const ev = normalize(er[f], dp);
      const av = normalize(ar[f], dp);
      if (JSON.stringify(ev) !== JSON.stringify(av)) {
        valueMismatches.push({ key, field: f, expected: ev, actual: av });
      }
    }
  }
  for (const key of actMap.keys()) if (!expMap.has(key)) extra.push(key);

  const countMatch = expected.length === actual.length;
  return {
    expectedCount: expected.length,
    actualCount: actual.length,
    countMatch,
    missing,
    extra,
    valueMismatches,
    ok: countMatch && missing.length === 0 && extra.length === 0 && valueMismatches.length === 0,
  };
}
