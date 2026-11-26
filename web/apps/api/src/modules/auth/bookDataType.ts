import { withTxBudget } from '../shared/txBudget.js';

/**
 * Owner decision 2026-11-25: an A or B session works only with books of its own data type. The desktop enforces this
 * only through the book picker (DC_Main.cs:1491-1502); the web also refuses the request, so a typed or replayed book
 * code cannot reach the other type's vouchers. All (C) allows every book.
 */
const BOOK_KEYS = ['coBook', 'CO_BOOK', 'book', 'bookCode'] as const;

function text(value: unknown): string | undefined {
  return typeof value === 'string' && value.trim() ? value.trim() : undefined;
}

/** The book code a request names: a route parameter, a query field or a body (or body header) field. */
export function requestedBook(req: {
  params?: unknown;
  query?: unknown;
  body?: unknown;
}): string | undefined {
  const sources: unknown[] = [req.params, req.query, req.body];
  const body = req.body as Record<string, unknown> | undefined;
  if (body && typeof body === 'object') sources.push(body.header, body.voucher);
  for (const source of sources) {
    if (!source || typeof source !== 'object') continue;
    for (const key of BOOK_KEYS) {
      const found = text((source as Record<string, unknown>)[key]);
      if (found) return found;
    }
  }
  return undefined;
}

export class BookDataTypeMismatchError extends Error {
  readonly statusCode = 403;
  constructor() {
    super('book-data-type-mismatch');
  }
}

export async function assertBookMatchesSessionType(
  prisma: any,
  scope: { tenantId: string; coCode: string; lcCode: string; dataType?: string },
  book: string | undefined,
): Promise<void> {
  const type = scope.dataType ?? 'C';
  if (!book || type === 'C') return;
  const rows = (await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT COALESCE(NULLIF(btrim("DATA_TYPE"),''),'A') AS "dataType" FROM "BOOK_DATA"
        WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND ("LC_CODE"=$3 OR "LC_CODE"='00' OR "LC_CODE" IS NULL)
        ORDER BY CASE WHEN "LC_CODE"=$3 THEN 0 ELSE 1 END LIMIT 1`,
      scope.coCode,
      book,
      scope.lcCode,
    ),
  )) as Array<{ dataType: string }>;
  if (rows[0] && rows[0].dataType !== type) throw new BookDataTypeMismatchError();
}
