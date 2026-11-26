import { AsyncLocalStorage } from 'node:async_hooks';
import { withTxBudget } from '../shared/txBudget.js';

/**
 * Owner decision 2026-11-25: an A or B session works only with books of its own data type. The desktop enforces this
 * only through the book picker (DC_Main.cs:1491-1502); the web refuses a request whose client names a book of the
 * other type, so a typed or replayed book cannot reach the other type's vouchers. A book the server chooses itself is
 * not refused (the desktop's fixed-book forms never read MsDataType, TR_SALE.cs, TR_SL_ORD_ADJ.cs). All (C) allows
 * every book. Book-like fields only: ordDbcd/isuDbcd on sale lines are deliberately unchecked.
 *
 * Three layers, so no single path is relied on:
 * 1. The route hook (app.ts) checks every book-like field a request names, anywhere in its parameters, query or body
 *    (the voucher's own book and every second book: the original sale of a return, an import's source, an issue book,
 *    an image's book, a transfer's from/to book). A book the server chooses itself is not refused (see booksOfRequest).
 * 2. Every route handler runs inside the session's data-type context (runWithSessionDataType, wrapped in app.ts) that
 *    records the books the request named, and the shared book resolvers that every voucher load, post and delete goes
 *    through (shared/bookPolicy.ts) refuse a NAMED book of the other type (assertBookTypeInContextTx).
 * 3. Posting stamps each ledger/stock row with its book's own type (posting/dataType.ts); a named book of the other
 *    type is refused there too, whichever route posted it. Server-chosen books are stamped with their own type.
 */

/** A route parameter, query or body key that names a book (CO_BOOK) — the voucher's own or a second one. */
const BOOK_KEY =
  /^(?:co_?book|book|bookcode|book_code|orig_?(?:co_?)?book|source_?(?:co_?)?book|issue_?book|isu_?book|sale_?bill_?book|from_?book|to_?book|image_?book|[a-z]+(?:co)?book)$/i;
/** Keys that end in "book" but hold a name or a family, never a book code. */
const NOT_A_BOOK = /^(?:main_?book|mainbook|family_?book)$/i;
const MAX_DEPTH = 4;
const MAX_BOOKS = 64;

function text(value: unknown): string | undefined {
  return typeof value === 'string' && value.trim() ? value.trim() : undefined;
}

function collect(value: unknown, depth: number, out: Set<string>): void {
  if (depth > MAX_DEPTH || out.size >= MAX_BOOKS || !value || typeof value !== 'object') return;
  if (Array.isArray(value)) {
    for (const item of value) collect(item, depth + 1, out);
    return;
  }
  for (const [key, child] of Object.entries(value as Record<string, unknown>)) {
    const code = text(child);
    // A book code is at most a few characters (CO_BOOK is varchar(3) on the voucher tables).
    if (code && code.length <= 8 && BOOK_KEY.test(key) && !NOT_A_BOOK.test(key)) out.add(code);
    else if (child && typeof child === 'object') collect(child, depth + 1, out);
  }
}

/** Every book code a request names: route parameters, query and body (nested objects and lines included). */
export function requestedBooks(req: {
  params?: unknown;
  query?: unknown;
  body?: unknown;
}): string[] {
  const out = new Set<string>();
  for (const source of [req.params, req.query, req.body]) collect(source, 0, out);
  return [...out];
}

/** The first book a request names (kept for callers that need one). */
export function requestedBook(req: {
  params?: unknown;
  query?: unknown;
  body?: unknown;
}): string | undefined {
  return requestedBooks(req)[0];
}

/**
 * The books a request reaches: every book the CLIENT names. A book the server chooses itself (fine sale FSL/FPR, DIS,
 * PRT, SRT, LBR, MLT, SAL/146, ORC) is deliberately NOT checked: the desktop forms that hard-code their book never
 * read MsDataType (TR_SALE.cs, TR_SL_ORD_ADJ.cs); they post with the book's own type (BOOK_DETL/BOOK_DATA), so a B
 * session can use them although the book is seeded as type A. Likewise ordDbcd/isuDbcd on sale lines are not book
 * fields here: TR_SALE never reads MsDataType for them.
 */
export function booksOfRequest(req: {
  params?: unknown;
  query?: unknown;
  body?: unknown;
}): string[] {
  return requestedBooks(req);
}

export class BookDataTypeMismatchError extends Error {
  readonly statusCode = 403;
  readonly code = 'book-data-type-mismatch';
  constructor() {
    super('book-data-type-mismatch');
    this.name = 'BookDataTypeMismatchError';
  }
}

export const BOOK_DATA_TYPE_MISMATCH_BODY = {
  error: 'book-data-type-mismatch',
  message: 'This book belongs to another data type. Switch the data type to use it.',
} as const;

/** The SQL that reads a book's data type (blank or NULL as 'A'), the row's location first, then '00' / NULL. */
const BOOK_TYPE_SQL = `SELECT "CO_BOOK" AS book, COALESCE(NULLIF(btrim("DATA_TYPE"),''),'A') AS "dataType"
    FROM (SELECT DISTINCT ON ("CO_BOOK") "CO_BOOK","DATA_TYPE" FROM "BOOK_DATA"
           WHERE "CO_CODE"=$1 AND "CO_BOOK" = ANY($2::text[])
             AND ("LC_CODE"=$3 OR "LC_CODE"='00' OR "LC_CODE" IS NULL OR btrim("LC_CODE")='')
           ORDER BY "CO_BOOK", CASE WHEN "LC_CODE"=$3 THEN 0 ELSE 1 END, row_id) b`;

async function bookTypesTx(
  tx: any,
  coCode: string,
  lcCode: string,
  books: string[],
): Promise<Map<string, string>> {
  const rows = (await tx.$queryRawUnsafe(BOOK_TYPE_SQL, coCode, books, lcCode)) as Array<{
    book: string;
    dataType: string;
  }>;
  return new Map(rows.map((r) => [String(r.book), String(r.dataType)]));
}

/** The hook's check: refuse when any book the request reaches is of the other type. Unknown books pass here. */
export async function assertBooksMatchSessionType(
  prisma: any,
  scope: { tenantId: string; coCode: string; lcCode: string; dataType?: string },
  books: string[],
): Promise<void> {
  const type = scope.dataType ?? 'C';
  if (!books.length || type === 'C') return;
  const types = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    bookTypesTx(tx, scope.coCode, scope.lcCode, books),
  );
  for (const t of types.values()) if (t !== type) throw new BookDataTypeMismatchError();
}

/** Kept for one-book callers. */
export async function assertBookMatchesSessionType(
  prisma: any,
  scope: { tenantId: string; coCode: string; lcCode: string; dataType?: string },
  book: string | undefined,
): Promise<void> {
  await assertBooksMatchSessionType(prisma, scope, book ? [book] : []);
}

/** The session's data type while a route handler runs (only for A and B sessions; All has no context). */
export interface SessionDataTypeContext {
  tenantId: string;
  coCode: string;
  lcCode: string;
  dataType: 'A' | 'B';
  /** Book types already read in this request. */
  books: Map<string, string>;
  /** The books the client named in this request; only these are refused (server-chosen books are not). */
  requested: Set<string>;
}

const context = new AsyncLocalStorage<SessionDataTypeContext | undefined>();

export function runWithSessionDataType<T>(
  session: { tenantId?: string; coCode?: string; lcCode?: string; dataType?: string } | undefined,
  fn: () => T,
  requested: Iterable<string> = [],
): T {
  const type = session?.dataType;
  if (!session?.tenantId || !session.coCode || (type !== 'A' && type !== 'B'))
    return context.run(undefined, fn);
  return context.run(
    {
      tenantId: session.tenantId,
      coCode: session.coCode,
      lcCode: session.lcCode ?? '',
      dataType: type,
      books: new Map(),
      requested: new Set(requested),
    },
    fn,
  );
}

export function sessionDataTypeContext(): SessionDataTypeContext | undefined {
  return context.getStore();
}

/**
 * Refuse a book of the other data type inside an A or B request. Called by the shared book resolvers, so a voucher's
 * load, post or delete is refused whichever route chose the book. Outside a request (jobs, tests calling modules
 * directly) and in an All session it does nothing. `knownType` skips the lookup when the caller already read it.
 */
export async function assertBookTypeInContextTx(
  tx: any,
  scope: { tenantId?: string; coCode?: string; lcCode?: string; coBook?: string },
  knownType?: string,
): Promise<void> {
  const ctx = context.getStore();
  const book = text(scope.coBook);
  if (!ctx || !book) return;
  // A book the server chose itself is stamped with its own type, not refused (TR_SALE.cs never reads MsDataType).
  if (!ctx.requested.has(book)) return;
  if (scope.tenantId && scope.tenantId !== ctx.tenantId) return;
  if (scope.coCode && scope.coCode !== ctx.coCode) return;
  let type = knownType ?? ctx.books.get(book);
  if (!type) {
    type = (
      await bookTypesTx(tx, scope.coCode ?? ctx.coCode, scope.lcCode ?? ctx.lcCode, [book])
    ).get(book);
    if (!type) return; // an unknown book is the resolver's own refusal
    ctx.books.set(book, type);
  }
  if (type !== ctx.dataType) throw new BookDataTypeMismatchError();
}
