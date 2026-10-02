import { withTxBudget } from '../shared/txBudget.js';
import { tableColumnsTx, tablesWithColumnsTx } from '../shared/schemaCatalog.js';

/** Desktop voucher identity: tenant + company + location + fiscal year + book. */
export interface VoucherScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear?: string;
  coBook?: string;
}

export class NumberingConfigurationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'NumberingConfigurationError';
  }
}

const q = (id: string): string => `"${id.replace(/"/g, '""')}"`;
const IDENTIFIER = /^[A-Za-z_][A-Za-z0-9_]*$/;
/** The six columns that make a row a voucher row: the complete voucher identity. */
const VOUCHER_IDENTITY_COLUMNS = [
  'tenant_id',
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
];
const VOUCHER_WIDTH = 5;
const MAX_VOUCHER_NO = 10 ** VOUCHER_WIDTH - 1;

export function scopeKey(s: VoucherScope): string {
  return [s.tenantId, s.coCode, s.lcCode, s.coYear ?? '', s.coBook ?? ''].join('|');
}

export function formatVoucherNo(value: number | string): string {
  const raw = String(value).trim();
  if (!/^\d+$/.test(raw)) throw new NumberingConfigurationError(`invalid voucher number: ${raw}`);
  const n = Number(raw);
  if (!Number.isSafeInteger(n) || n < 1 || n > MAX_VOUCHER_NO) {
    throw new NumberingConfigurationError(`voucher number is outside 00001-${MAX_VOUCHER_NO}`);
  }
  return String(n).padStart(VOUCHER_WIDTH, '0');
}

function completeScope(
  s: VoucherScope,
): asserts s is VoucherScope & { coYear: string; coBook: string } {
  if (!s.tenantId || !s.coCode || !s.lcCode || !s.coYear || !s.coBook) {
    throw new NumberingConfigurationError(
      'voucher numbering requires tenant, company, location, fiscal year, and book',
    );
  }
}

/**
 * Resolve the desktop header table from BOOK_DATA. Legacy/web-seeded books that predate
 * BOOK_TBL_NAME fall back to all live voucher tables carrying the complete identity. The fallback
 * intentionally excludes deletion/temporary evidence so deleting the highest voucher permits the
 * desktop MAX(VCH_NO)+1 reuse rule.
 */
async function numberingTables(tx: any, s: VoucherScope): Promise<string[]> {
  const books: Array<{ table_name: unknown }> = await tx.$queryRawUnsafe(
    `SELECT DISTINCT NULLIF(btrim(coalesce("BOOK_TBL_NAME"::text,'')),'') AS table_name
       FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"::text=$2 AND "LC_CODE"::text=$3 AND "CO_BOOK"::text=$4`,
    s.tenantId,
    s.coCode,
    s.lcCode,
    s.coBook,
  );
  const configured = Array.from(
    new Set(books.map((r) => String(r.table_name ?? '').trim()).filter(Boolean)),
  );
  if (configured.length > 1) {
    throw new NumberingConfigurationError(
      `book ${s.coBook} has conflicting BOOK_TBL_NAME values: ${configured.join(', ')}`,
    );
  }
  if (configured.length === 1) {
    const table = configured[0] as string;
    if (!IDENTIFIER.test(table)) {
      throw new NumberingConfigurationError(`unsafe BOOK_TBL_NAME for book ${s.coBook}: ${table}`);
    }
    const identity = await tableColumnsTx(tx, table);
    if (!VOUCHER_IDENTITY_COLUMNS.every((column) => identity.has(column))) {
      throw new NumberingConfigurationError(
        `BOOK_TBL_NAME ${table} does not carry the complete voucher identity`,
      );
    }
    return [table];
  }

  const tables = (
    await tablesWithColumnsTx(tx, VOUCHER_IDENTITY_COLUMNS, [
      'DELETE_DATA',
      'TEMP_BOOK_DATA',
      'TAG_STOCK_PRINT',
    ])
  ).filter((t) => IDENTIFIER.test(t));
  if (!tables.length) {
    throw new NumberingConfigurationError(
      'no migrated voucher table carries the complete identity',
    );
  }
  return tables;
}

async function currentMaxVoucherNo(tx: any, s: VoucherScope): Promise<number> {
  const tables = await numberingTables(tx, s);
  const union = tables
    .map(
      (table) =>
        `SELECT CASE WHEN "VCH_NO"::text ~ '^[0-9]+$' THEN "VCH_NO"::text::bigint END AS n
           FROM ${q(table)}
          WHERE tenant_id=$1 AND "CO_CODE"::text=$2 AND "LC_CODE"::text=$3
            AND "CO_YEAR"::text=$4 AND "CO_BOOK"::text=$5`,
    )
    .join('\nUNION ALL\n');
  const rows: Array<{ max_no: unknown }> = await tx.$queryRawUnsafe(
    `SELECT coalesce(max(n),0)::bigint AS max_no FROM (${union}) scoped_vouchers`,
    s.tenantId,
    s.coCode,
    s.lcCode,
    s.coYear,
    s.coBook,
  );
  const max = Number(rows[0]?.max_no ?? 0);
  if (!Number.isSafeInteger(max) || max < 0 || max >= MAX_VOUCHER_NO) {
    throw new NumberingConfigurationError(
      `voucher sequence exhausted or invalid for ${scopeKey(s)}`,
    );
  }
  return max;
}

/**
 * Allocate MAX(VCH_NO)+1 inside the caller's transaction. The full-scope advisory lock is held to
 * commit, so concurrent web writers for the same company/location/year/book cannot collide. The
 * number is re-derived from persisted rows on every call, matching desktop import and top-delete
 * reuse semantics rather than trusting SRNO_MAST's global tag counter row.
 */
export async function nextVoucherNoTx(tx: any, s: VoucherScope): Promise<number> {
  completeScope(s);
  await tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `voucher|${scopeKey(s)}`,
  );
  return (await currentMaxVoucherNo(tx, s)) + 1;
}

export async function nextVoucherNo(prisma: any, s: VoucherScope): Promise<number> {
  return withTxBudget(prisma, s.tenantId, 'voucher', (tx: any) => nextVoucherNoTx(tx, s));
}

/**
 * Allocate the legacy global tag serial. Unlike voucher numbers, SRNO_MAST.TAG_SRNO is scoped only
 * by tenant/company/location, so its lock deliberately excludes fiscal year and book. The unique
 * migration index and FOR UPDATE make the persisted row unambiguous.
 */
export async function nextTagNoTx(
  tx: any,
  s: VoucherScope,
  opts?: { prefix?: string; pad?: number },
): Promise<{ srno: number; tagNo: string }> {
  const tagKey = ['tag', s.tenantId, s.coCode, s.lcCode].join('|');
  await tx.$executeRawUnsafe('SELECT pg_advisory_xact_lock(hashtext($1))', tagKey);
  const rows: Array<{ TAG_SRNO: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "TAG_SRNO" FROM "SRNO_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 FOR UPDATE`,
    s.tenantId,
    s.coCode,
    s.lcCode,
  );
  if (rows.length > 1) {
    throw new NumberingConfigurationError(`duplicate SRNO_MAST rows for ${tagKey}`);
  }
  let next: number;
  if (rows.length === 0) {
    next = 1;
    await tx.$executeRawUnsafe(
      // TR_TAG_OPBL/TR_PURC insert TAG_NO and IT_CODE with the counters, and MS_UPDATE later
      // back-fills IT_CODE from BAR_DETL — so the row identifies WHICH tag the serial belongs to, not
      // just the next number. A counter row seeded before any tag exists carries them empty.
      `INSERT INTO "SRNO_MAST"(tenant_id,"CO_CODE","LC_CODE","TAG_SRNO","VCH_SRNO","TAG_NO","IT_CODE")
         VALUES ($1,$2,$3,$4,0,'','')`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      next,
    );
  } else {
    next = Number(rows[0]?.TAG_SRNO ?? 0) + 1;
    await tx.$executeRawUnsafe(
      `UPDATE "SRNO_MAST" SET "TAG_SRNO"=$1
        WHERE tenant_id=$2 AND "CO_CODE"=$3 AND "LC_CODE"=$4`,
      next,
      s.tenantId,
      s.coCode,
      s.lcCode,
    );
  }
  if (!Number.isSafeInteger(next) || next < 1) {
    throw new NumberingConfigurationError(`invalid tag serial for ${tagKey}`);
  }
  const pad = opts?.pad ?? 6;
  const prefix = (opts?.prefix ?? '')
    .toUpperCase()
    .replace(/[^A-Z0-9]/g, '')
    .slice(0, 4);
  return { srno: next, tagNo: `${prefix}${String(next).padStart(pad, '0')}` };
}
