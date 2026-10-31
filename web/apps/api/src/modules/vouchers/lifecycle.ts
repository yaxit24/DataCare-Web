import { formatVoucherNo, type VoucherScope } from './numbering.js';

type CompleteVoucherScope = VoucherScope & { coYear: string; coBook: string };

type PersistedVoucherHeader = {
  VCH_NO: unknown;
  VCH_DATE: unknown;
  VCH_TIME: unknown;
  VCH_CLOCK: unknown;
  HD_VCH_NO: unknown;
  MAIN_USER: unknown;
} & Record<string, unknown>;

class FiscalDateValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'FiscalDateValidationError';
  }
}

/**
 * N183 (G193): a voucher another operator has already deleted is a stale document, not a server fault. The stable
 * reason `voucher-not-found` (404) lets the screen say so and offer a reload (03-shared-contracts.md, conflict rule 9).
 * `statusCode` also gives routes outside `run()` the same answer through Fastify's default error handler.
 */
class PersistedVoucherNotFoundError extends Error {
  readonly statusCode = 404;
  readonly code = 'voucher-not-found';
  constructor(voucherNo: string) {
    super(`voucher not found: ${voucherNo}`);
    this.name = 'PersistedVoucherNotFoundError';
  }
}

class PersistedVoucherAmbiguousError extends Error {
  readonly statusCode = 409;
  readonly code = 'voucher-ambiguous';
  constructor(voucherNo: string) {
    super(`voucher is ambiguous: ${voucherNo}`);
    this.name = 'PersistedVoucherAmbiguousError';
  }
}

const q = (identifier: string): string => `"${identifier.replace(/"/g, '""')}"`;
const text = (value: unknown): string => String(value ?? '').trim();

export async function nextHiddenVoucherNoTx(
  tx: any,
  scope: VoucherScope & { coBook: string },
): Promise<string> {
  await tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    ['melting-temp', scope.tenantId, scope.coCode, scope.lcCode, scope.coBook].join('|'),
  );
  const rows: Array<{ max_no: unknown }> = await tx.$queryRawUnsafe(
    `SELECT coalesce(max(CASE WHEN "VCH_NO"::text ~ '^[0-9]+$'
                             THEN "VCH_NO"::text::int END),0)::int AS max_no
       FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_BOOK"=$4`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  return formatVoucherNo(Number(rows[0]?.max_no ?? 0) + 1);
}

export function voucherTimestamp(date: Date, prior?: unknown): Date {
  const day = date.toISOString().slice(0, 10);
  if (typeof prior === 'string' && /^\d{2}:\d{2}:\d{2}(?:\.\d+)?$/.test(prior)) {
    // VCH_TIME is a timestamp without time zone. Recreate the persisted wall-clock value in the
    // process timezone so Prisma does not shift it when replacing a voucher.
    return new Date(`${day}T${prior.padEnd(12, '0').slice(0, 12)}`);
  }
  // Desktop stamps VCH_TIME as "<voucher date> <wall clock>" (e.g. TR_SALE.cs:15331), so the
  // persisted date part must always equal the voucher date. Prisma serialises a JS Date into a
  // `timestamp without time zone` using its LOCAL components, so the time-of-day has to be taken
  // from the local clock too. Using the UTC time-of-day rolled the stored date forward by a day
  // whenever the process was east of UTC and the UTC clock had passed midnight-minus-offset
  // (e.g. after 00:00 IST), which silently mis-dated every voucher saved late at night.
  const source = prior instanceof Date && !Number.isNaN(prior.getTime()) ? prior : new Date();
  const pad = (value: number, width = 2): string => String(value).padStart(width, '0');
  const clock =
    `${pad(source.getHours())}:${pad(source.getMinutes())}:${pad(source.getSeconds())}` +
    `.${pad(source.getMilliseconds(), 3)}`;
  return new Date(`${day}T${clock}`);
}

export async function assertFiscalDateTx(
  tx: any,
  scope: VoucherScope & { coYear: string },
  isoDate: string,
): Promise<void> {
  const rows: Array<{ OP_DATE: unknown; CL_DATE: unknown }> = await tx.$queryRawUnsafe(
    `SELECT left("OP_DATE"::text,10) AS "OP_DATE","CL_DATE"::date::text AS "CL_DATE"
       FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
        AND coalesce(nullif(btrim("CO_YEAR"::text),''),left("OP_DATE"::text,4))=$3
       ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    scope.coYear,
  );
  if (rows.length !== 1 || !rows[0]?.OP_DATE || !rows[0]?.CL_DATE) {
    throw new FiscalDateValidationError(
      `fiscal year ${scope.coYear} has no unambiguous opening and closing dates`,
    );
  }
  const opening = text(rows[0].OP_DATE).slice(0, 10);
  const closing = text(rows[0].CL_DATE).slice(0, 10);
  if (isoDate < opening || isoDate > closing) {
    throw new FiscalDateValidationError(
      `voucher date ${isoDate} is outside fiscal year ${opening} to ${closing}`,
    );
  }
}

export async function persistedVoucherHeaderTx(
  tx: any,
  options: {
    table: string;
    scope: CompleteVoucherScope;
    voucherNo: string;
    extraColumns: readonly string[];
  },
): Promise<PersistedVoucherHeader> {
  const { table, scope, voucherNo, extraColumns } = options;
  const extras = extraColumns.length ? `,${extraColumns.map(q).join(',')}` : '';
  const rows: PersistedVoucherHeader[] = await tx.$queryRawUnsafe(
    `SELECT "VCH_NO","VCH_DATE","VCH_TIME",to_char("VCH_TIME",'HH24:MI:SS.MS') AS "VCH_CLOCK",
            "HD_VCH_NO","MAIN_USER"${extras} FROM ${q(table)}
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6 FOR UPDATE`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  if (rows.length === 0) throw new PersistedVoucherNotFoundError(voucherNo);
  const first = rows[0]!;
  const columns = Object.keys(first);
  if (rows.some((row) => columns.some((column) => text(row[column]) !== text(first[column])))) {
    throw new PersistedVoucherAmbiguousError(voucherNo);
  }
  return first;
}

export async function deleteVoucherWriteSetTx(
  tx: any,
  options: {
    tables: readonly string[];
    key: { scope: CompleteVoucherScope; voucherNo: string };
    tempBook?: { voucherNo: string };
  },
): Promise<void> {
  const { scope, voucherNo } = options.key;
  const params = [
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  ];
  for (const table of options.tables) {
    await tx.$executeRawUnsafe(
      `DELETE FROM ${q(table)} WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      ...params,
    );
  }
  if (options.tempBook) {
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coBook,
      options.tempBook.voucherNo,
    );
  }
}
