import { createRequire } from 'node:module';
import { pathToFileURL } from 'node:url';
import { Worker } from 'node:worker_threads';

/**
 * The source side of Other → Data Import (desktop UT_IMPORT "Old Softwar Import", Lite Soft only, D-IMP-1).
 *
 * The desktop opens the chosen file with `Provider=Microsoft.Jet.OLEDB.4.0` (UT_IMPORT.cs:3193-3202, TrfrConn) and runs
 * Access SQL on it. The web never runs a shell or a driver on an uploaded file (D-IMP-3): the bytes are parsed by the
 * pure-JavaScript `mdb-reader` inside a worker thread of this process, with a size cap, a row cap, a memory limit and
 * a timeout, and only the tables and columns of SOURCE_ALLOW_LIST leave the worker. Everything after that works on
 * plain rows through `SourceReader`, so the mapping is tested with table fixtures (no sample .mdb exists).
 */

/** One source row: upper-case column name to value (string, number, boolean, ISO date string or null). */
export type SourceRow = Record<string, unknown>;

export interface SourceReader {
  /** Upper-case names of every table in the file (allow-listed or not). */
  tableNames(): string[];
  /** The allow-listed columns of a table, or null when the file has no such table. */
  rows(table: SourceTable): SourceRow[] | null;
  /** Allow-listed columns the file's table lacks. */
  missingColumns(table: SourceTable): string[];
  /** 'mdb' for an Access file; 'fixture' for the test-only JSON tables. */
  readonly format: 'mdb' | 'fixture';
}

/**
 * Every source table and column the five Lite steps read, with the desktop line that reads it. Nothing else is read.
 *   Lite_AcMast   UT_IMPORT.cs:8694-8780   AC_MAST LEFT JOIN AREA_MAST
 *   Wh_Item       UT_IMPORT.cs:4241-4328   PRODUCT_MAST, GROUP_MAST, TABLE_MAST, ITEM_MAST (Lite branches)
 *   WH_AcOpbl     UT_IMPORT.cs:4330-4363   AC_DATA LEFT JOIN AC_MAST
 *   Lite_BarData  UT_IMPORT.cs:8447-8692   MAIN_TAG_DATA, BAR_DETL, BAR_IDTL, BOOK_DATA, ITEM_MAST
 *   WH_ItOpbl     UT_IMPORT.cs:3887-3965   MAIN_STOCK LEFT JOIN ITEM_MAST
 */
export const SOURCE_ALLOW_LIST = {
  AC_MAST: [
    'CO_CODE',
    'AC_CODE',
    'AC_NAME',
    'AC_MAIN_GR',
    'AC_GR',
    'AC_ADD1',
    'AC_ADD2',
    'AC_ADD3',
    'AC_STATE',
    'AC_CITY',
    'AC_AREA',
    'AC_PIN',
    'AC_PHONE',
    'AC_MOBILE',
    'AC_MOBILE2',
    'AC_EMAIL',
    'GST_NO',
    'TAX_TYPE',
    'AC_PANNO',
    'BR_DATE',
    'AN_DATE',
  ],
  AREA_MAST: ['CO_CODE', 'AREA_CODE', 'AREA_NAME'],
  PRODUCT_MAST: ['CO_CODE', 'PR_CODE', 'PR_NAME'],
  GROUP_MAST: [
    'CO_CODE',
    'GR_CODE',
    'GR_NAME',
    'GR_TYPE',
    'GR_TOUCH',
    'MELTING_PRC',
    'GR_RATE',
    'SALE_AC',
    'PURC_AC',
    'HSN_CODE',
  ],
  TABLE_MAST: ['CO_CODE', 'TABLE_CODE', 'TABLE_NAME'],
  ITEM_MAST: [
    'CO_CODE',
    'IT_CODE',
    'IT_NAME',
    'IT_TYPE',
    'TAG_TYPE',
    'PR_CODE',
    'GR_CODE',
    'UNIT_NAME',
    'RATE_TYPE',
    'HSN_CODE',
    'ITEM_RATE',
    'AVG_TOUCH',
  ],
  AC_DATA: ['CO_CODE', 'AC_CODE', 'VCH_DATE', 'CR_AMT', 'DR_AMT', 'IT_TYPE', 'SIGN', 'FINE_WT'],
  MAIN_STOCK: [
    'CO_CODE',
    'CO_YEAR',
    'IT_CODE',
    'TAG_NO',
    'VCH_DATE',
    'SIGN',
    'ITM_PCS',
    'ITM_NWT',
    'ITM_GWT',
  ],
  MAIN_TAG_DATA: ['CO_CODE', 'CO_YEAR', 'TAG_NO', 'IT_CODE'],
  BAR_DETL: [
    'CO_CODE',
    'CO_YEAR',
    'CO_BOOK',
    'VCH_NO',
    'VCH_DATE',
    'VCH_TYPE',
    'BOOK_NAME',
    'CUST_AC',
    'AC_CODE',
    'IT_CODE',
    'TAG_NO',
    'DESIGN',
    'ITM_SIZE',
    'ITM_PCS',
    'ITM_GWT',
    'ITM_NWT',
    'ITM_GHAT',
    'ITM_TOUCH',
    'ITM_WEST',
    'ITM_FINE',
    'LBR_PRC',
    'LBR_RATE',
    'LBR_AMT',
    'OTH_AMT',
    'ITM_RAT',
    'ITM_AMT',
    'NET_COST',
    'MRP',
    'KR_NAME',
    'KR_ITM_NWT',
    'KR_ITM_GHAT',
    'KR_ITM_TOUCH',
    'KR_ITM_WEST',
    'KR_LBR_RATE',
    'KR_LBR_AMT',
    'RATE_TYPE',
    'IT_TYPE',
    'PR_CODE',
  ],
  BAR_IDTL: [
    'CO_CODE',
    'TAG_NO',
    'TAG_NWT',
    'ISR_NO',
    'IT_CODE',
    'ITM_PCS',
    'PR_WT',
    'ITM_GWT',
    'CON_PRC',
    'CON_WT',
    'RATE_TYPE',
    'ITM_RATE',
    'IT_AMT',
    'LBR_RATE',
    'LBR_AMT',
    'ITM_AMT',
    'PR_CON_WT',
    'PR_RATE',
    'PR_AMT',
    'PR_LBR_RATE',
    'PR_LBR_AMT',
    'PR_NET_AMT',
  ],
  BOOK_DATA: ['CO_CODE', 'CO_BOOK', 'BOOK_SNAME', 'MAIN_BOOK'],
} as const;

export type SourceTable = keyof typeof SOURCE_ALLOW_LIST;
export const SOURCE_TABLES = Object.keys(SOURCE_ALLOW_LIST) as SourceTable[];
const columnsOf = (table: SourceTable): string[] => [...new Set(SOURCE_ALLOW_LIST[table])];

/** The largest file accepted (an uploaded .mdb is read whole into memory). */
export const MAX_SOURCE_BYTES = 32 * 1024 * 1024;
/** The most rows read from one table. */
export const MAX_SOURCE_ROWS = 500_000;
/** How long the worker may parse before it is stopped. */
export const SOURCE_TIMEOUT_MS = 60_000;
/** Heap limit of the parsing worker. */
const WORKER_HEAP_MB = 768;

export class SourceFileError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'SourceFileError';
  }
}

export const SOURCE_MESSAGES = {
  EMPTY: 'The chosen file is empty. Choose the old Lite software .mdb file.',
  TOO_LARGE: `The chosen file is larger than ${MAX_SOURCE_BYTES / 1024 / 1024} MB and was not read; nothing was imported.`,
  NOT_MDB:
    'The chosen file is not a Microsoft Access (.mdb) database and was not read; nothing was imported.',
  UNREADABLE: 'The chosen .mdb file could not be read; nothing was imported.',
  TIMEOUT: 'Reading the chosen .mdb file took too long and was stopped; nothing was imported.',
} as const;

/** Jet 3/4 and ACE files carry "Standard Jet DB" / "Standard ACE DB" at byte 4 of their first page. */
export function isAccessFile(bytes: Uint8Array): boolean {
  if (bytes.length < 20) return false;
  const tag = Buffer.from(bytes.subarray(4, 19)).toString('latin1');
  return tag === 'Standard Jet DB' || tag === 'Standard ACE DB';
}

class TableReader implements SourceReader {
  constructor(
    readonly format: 'mdb' | 'fixture',
    private readonly names: string[],
    private readonly tables: Partial<Record<SourceTable, SourceRow[]>>,
    private readonly missing: Partial<Record<SourceTable, string[]>>,
  ) {}
  tableNames(): string[] {
    return [...this.names];
  }
  rows(table: SourceTable): SourceRow[] | null {
    return this.tables[table] ?? null;
  }
  missingColumns(table: SourceTable): string[] {
    return this.missing[table] ?? [];
  }
}

const scalar = (value: unknown): unknown => {
  if (value === undefined || value === null) return null;
  if (value instanceof Date)
    return Number.isNaN(value.getTime()) ? null : value.toISOString().slice(0, 10);
  if (typeof value === 'bigint') return Number(value);
  if (typeof value === 'string' || typeof value === 'number' || typeof value === 'boolean')
    return value;
  return null; // binary / OLE fields are never read
};

/**
 * Keep the allow-listed tables and columns of a set of named tables (any case), upper-casing names, and record
 * which allow-listed columns are absent. Unknown tables and columns are ignored.
 */
export function pickAllowed(source: Record<string, Array<Record<string, unknown>>>): {
  names: string[];
  tables: Partial<Record<SourceTable, SourceRow[]>>;
  missing: Partial<Record<SourceTable, string[]>>;
} {
  const byUpper = new Map(Object.keys(source).map((name) => [name.toUpperCase(), name]));
  const tables: Partial<Record<SourceTable, SourceRow[]>> = {};
  const missing: Partial<Record<SourceTable, string[]>> = {};
  for (const table of SOURCE_TABLES) {
    const actual = byUpper.get(table);
    if (actual === undefined) continue;
    const rows = source[actual] ?? [];
    if (!Array.isArray(rows)) throw new SourceFileError(SOURCE_MESSAGES.UNREADABLE);
    if (rows.length > MAX_SOURCE_ROWS)
      throw new SourceFileError(
        `Table ${table} of the chosen file has more than ${MAX_SOURCE_ROWS} rows; nothing was imported.`,
      );
    const present = new Set<string>();
    for (const row of rows)
      for (const key of Object.keys(row ?? {})) present.add(key.toUpperCase());
    missing[table] = rows.length ? columnsOf(table).filter((c) => !present.has(c)) : [];
    tables[table] = rows.map((row) => {
      const upper = new Map(Object.entries(row ?? {}).map(([k, v]) => [k.toUpperCase(), v]));
      return Object.fromEntries(columnsOf(table).map((c) => [c, scalar(upper.get(c))]));
    });
  }
  return { names: [...byUpper.keys()], tables, missing };
}

/**
 * The test-only fixture reader: `{"format":"datacare-lite-fixture","tables":{"AC_MAST":[{...}],...}}`. It exists so the
 * mapping and the transaction can be exercised through the real screen without a real .mdb (none is in the repository
 * and none may be fabricated). It is accepted only while DATACARE_IMPORT_FIXTURE_READER=1, which the feature and
 * database test harnesses set and a deployment never does.
 */
export function fixtureReaderEnabled(): boolean {
  return process.env.DATACARE_IMPORT_FIXTURE_READER === '1';
}

export function fixtureReader(bytes: Uint8Array): SourceReader {
  let parsed: any;
  try {
    parsed = JSON.parse(Buffer.from(bytes).toString('utf8'));
  } catch {
    throw new SourceFileError(SOURCE_MESSAGES.NOT_MDB);
  }
  if (parsed?.format !== 'datacare-lite-fixture' || typeof parsed.tables !== 'object')
    throw new SourceFileError(SOURCE_MESSAGES.NOT_MDB);
  const { names, tables, missing } = pickAllowed(parsed.tables);
  return new TableReader('fixture', names, tables, missing);
}

/** The worker body: open the bytes with mdb-reader and post back only the allow-listed columns. */
const WORKER_SOURCE = `
const { parentPort, workerData } = require('node:worker_threads');
(async () => {
  const { default: MDBReader } = await import(workerData.readerUrl);
  const reader = new MDBReader(Buffer.from(workerData.bytes));
  const names = reader.getTableNames();
  const tables = {};
  for (const [table, columns] of Object.entries(workerData.allow)) {
    const actual = names.find((name) => name.toUpperCase() === table);
    if (actual === undefined) continue;
    const t = reader.getTable(actual);
    if (t.rowCount > workerData.maxRows) throw new Error('too-many-rows:' + table);
    const byUpper = new Map(t.getColumnNames().map((c) => [c.toUpperCase(), c]));
    const present = columns.filter((c) => byUpper.has(c)).map((c) => byUpper.get(c));
    tables[actual] = present.length ? t.getData({ columns: present }) : Array.from({ length: t.rowCount }, () => ({}));
  }
  parentPort.postMessage({ ok: true, names, tables });
})().catch((error) => parentPort.postMessage({ ok: false, error: String((error && error.message) || error) }));
`;

let readerUrl: string | undefined;
function mdbReaderUrl(): string {
  readerUrl ??= pathToFileURL(createRequire(import.meta.url).resolve('mdb-reader')).href;
  return readerUrl;
}

/** Parse an Access file in a worker thread: capped, time-limited and memory-limited. */
export async function mdbReader(
  bytes: Uint8Array,
  opts: { timeoutMs?: number } = {},
): Promise<SourceReader> {
  const allow = Object.fromEntries(SOURCE_TABLES.map((t) => [t, columnsOf(t)]));
  const result = await new Promise<{ ok: boolean; error?: string; names?: string[]; tables?: any }>(
    (resolve) => {
      const worker = new Worker(WORKER_SOURCE, {
        eval: true,
        workerData: {
          bytes: Buffer.from(bytes),
          allow,
          maxRows: MAX_SOURCE_ROWS,
          readerUrl: mdbReaderUrl(),
        },
        resourceLimits: { maxOldGenerationSizeMb: WORKER_HEAP_MB },
      });
      let settled = false;
      const finish = (value: { ok: boolean; error?: string; names?: string[]; tables?: any }) => {
        if (settled) return;
        settled = true;
        clearTimeout(timer);
        void worker.terminate();
        resolve(value);
      };
      const timer = setTimeout(
        () => finish({ ok: false, error: 'timeout' }),
        opts.timeoutMs ?? SOURCE_TIMEOUT_MS,
      );
      worker.on('message', finish);
      worker.on('error', (error) => finish({ ok: false, error: String(error?.message ?? error) }));
      worker.on('exit', () => finish({ ok: false, error: 'worker exited' }));
    },
  );
  if (!result.ok) {
    if (result.error === 'timeout') throw new SourceFileError(SOURCE_MESSAGES.TIMEOUT);
    const tooMany = /^too-many-rows:(\w+)/.exec(result.error ?? '');
    if (tooMany)
      throw new SourceFileError(
        `Table ${tooMany[1]} of the chosen file has more than ${MAX_SOURCE_ROWS} rows; nothing was imported.`,
      );
    throw new SourceFileError(SOURCE_MESSAGES.UNREADABLE);
  }
  const { names, tables, missing } = pickAllowed(result.tables ?? {});
  // Tables the worker saw but held no allow-listed table: keep every name so the preview can list what was ignored.
  const allNames = [...new Set([...(result.names ?? []).map((n) => n.toUpperCase()), ...names])];
  return new TableReader('mdb', allNames, tables, missing);
}

/** Open an uploaded file: size cap first, then an Access file through the worker, or (tests only) a fixture. */
export async function openImportSource(
  bytes: Uint8Array,
  opts: { timeoutMs?: number } = {},
): Promise<SourceReader> {
  if (!bytes.length) throw new SourceFileError(SOURCE_MESSAGES.EMPTY);
  if (bytes.length > MAX_SOURCE_BYTES) throw new SourceFileError(SOURCE_MESSAGES.TOO_LARGE);
  if (isAccessFile(bytes)) return mdbReader(bytes, opts);
  if (fixtureReaderEnabled() && bytes[0] === 0x7b /* { */) return fixtureReader(bytes);
  throw new SourceFileError(SOURCE_MESSAGES.NOT_MDB);
}
