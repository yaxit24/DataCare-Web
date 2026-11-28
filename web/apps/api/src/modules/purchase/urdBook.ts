import { PurchaseValidationError } from './purchase.js';

/**
 * The Gold / Silver URD purchase book a tax-invoice sale's Old Gold / Old Silver row opens (owner decision 2B).
 *
 * The desktop hardcodes it: TR_SALE.cs:18756-18842 opens TR_PURC on CurBook "043" (gold) or "044" (silver),
 * MAIN_BOOK PURCHASE, short name GLURD / SLURD, and MS_UPDATE.cs:23955/:23963 names those books "Gold URD Purchase" and
 * "Silver URD Purchase" in BOOK_DATA. A web-provisioned company numbers its books differently (PR, TPR), so the web
 * resolves the book per metal:
 *   1. the company setting (`company_urd_book.gold_book` / `silver_book`, Settings screen) when set and an active
 *      PURCHASE book at this location; a book that is not (the setting is per company, books are per location) falls
 *      through to the next steps, and the Settings screen says so;
 *   2. else 043 / 044 when BOOK_DATA has it as an active PURCHASE book;
 *   3. else the single active PURCHASE book whose BOOK_DATA.BOOK_SNAME is GLURD / SLURD or whose BOOK_NAME starts with
 *      "Gold URD" / "Silver URD". BOOK_DATA, never BOOK_DETL: MS_UPDATE.cs:23959 writes BOOK_SNAME 'SLURD' on 043's
 *      BOOK_DETL rows, so BOOK_DETL would call the gold book silver;
 *   4. none, or several → UrdBookValidationError, worded for a Lite user too (Books / Series is Lite; Settings is not).
 *
 * "Active" is the web's book rule (purchaseMainBookTx): CUR_USE not 'N', a blank CUR_USE counting as in use.
 */
export type UrdMetal = 'G' | 'S';

export interface UrdBookScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
}

export interface UrdPurchaseBook {
  metal: UrdMetal;
  coBook: string;
  bookName: string;
  source: 'setting' | 'desktop-code' | 'name';
  /** Set when the company setting names a book that is not an active PURCHASE book at this location. */
  settingIgnored?: string;
}

export class UrdBookValidationError extends PurchaseValidationError {
  readonly metal: UrdMetal;
  constructor(metal: UrdMetal, message = urdBookMissingMessage(metal)) {
    super(message);
    this.name = 'UrdBookValidationError';
    this.metal = metal;
  }
}

const METAL_WORD: Record<UrdMetal, string> = { G: 'Gold', S: 'Silver' };
const DESKTOP_CODE: Record<UrdMetal, string> = { G: '043', S: '044' };
const SHORT_NAME: Record<UrdMetal, string> = { G: 'GLURD', S: 'SLURD' };

export const urdBookMissingMessage = (metal: UrdMetal): string =>
  `Create a ${METAL_WORD[metal]} URD Purchase book in Books / Series (code ${DESKTOP_CODE[metal]} or a name starting '${METAL_WORD[metal]} URD'), or choose one in Settings`;

const severalBooksMessage = (metal: UrdMetal, codes: string[]): string =>
  `Several Purchase books qualify as the ${METAL_WORD[metal]} URD Purchase book (${codes.join(', ')}): keep only one in use, or choose one in Settings`;

const text = (value: unknown): string => String(value ?? '').trim();

type BookRow = { CO_BOOK: unknown; BOOK_NAME: unknown };

/**
 * Active PURCHASE books of the location (or of any location of the company when `lcCode` is null), one row per book
 * code, optionally narrowed by an extra predicate.
 */
async function activePurchaseBooksTx(
  tx: any,
  scope: Omit<UrdBookScope, 'lcCode'> & { lcCode: string | null },
  predicate: string,
  params: unknown[],
): Promise<Array<{ coBook: string; bookName: string }>> {
  const rows: BookRow[] = await tx.$queryRawUnsafe(
    `SELECT DISTINCT ON (btrim("CO_BOOK")) btrim("CO_BOOK") AS "CO_BOOK","BOOK_NAME"
       FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND ($3::text IS NULL OR "LC_CODE"=$3)
        AND upper(btrim(coalesce("MAIN_BOOK",'')))='PURCHASE'
        AND coalesce(nullif(btrim("CUR_USE"::text),''),'Y') <> 'N'
        AND (${predicate})
      ORDER BY btrim("CO_BOOK"), row_id`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    ...params,
  );
  return rows.map((r) => ({ coBook: text(r.CO_BOOK), bookName: text(r.BOOK_NAME) }));
}

/** The company setting for one metal, or '' when unset. */
export async function urdBookSettingTx(
  tx: any,
  scope: Pick<UrdBookScope, 'tenantId' | 'coCode'>,
  metal: UrdMetal,
): Promise<string> {
  const rows: Array<{ book: unknown }> = await tx.$queryRawUnsafe(
    `SELECT ${metal === 'G' ? 'gold_book' : 'silver_book'} AS book FROM "company_urd_book"
      WHERE tenant_id=$1 AND "CO_CODE"=$2`,
    scope.tenantId,
    scope.coCode,
  );
  return text(rows[0]?.book);
}

/** Resolve the URD purchase book for a metal by the rule above; throws UrdBookValidationError when there is none. */
export async function resolveUrdPurchaseBookTx(
  tx: any,
  scope: UrdBookScope,
  metal: UrdMetal,
): Promise<UrdPurchaseBook> {
  const configured = await urdBookSettingTx(tx, scope, metal);
  let settingIgnored: string | undefined;
  if (configured) {
    const [book] = await activePurchaseBooksTx(tx, scope, `btrim("CO_BOOK")=$4`, [configured]);
    if (book) return { metal, ...book, source: 'setting' };
    settingIgnored = `book ${configured} chosen in Settings is not an active Purchase book at location ${scope.lcCode}`;
  }
  const [desktop] = await activePurchaseBooksTx(tx, scope, `btrim("CO_BOOK")=$4`, [
    DESKTOP_CODE[metal],
  ]);
  if (desktop) return { metal, ...desktop, source: 'desktop-code', settingIgnored };
  const named = await activePurchaseBooksTx(
    tx,
    scope,
    `upper(btrim(coalesce("BOOK_SNAME",'')))=$4 OR btrim(coalesce("BOOK_NAME",'')) ILIKE $5`,
    [SHORT_NAME[metal], `${METAL_WORD[metal]} URD%`],
  );
  if (named.length === 1) return { metal, ...named[0]!, source: 'name', settingIgnored };
  const message =
    named.length > 1
      ? severalBooksMessage(
          metal,
          named.map((b) => b.coBook),
        )
      : urdBookMissingMessage(metal);
  throw new UrdBookValidationError(
    metal,
    settingIgnored ? `${METAL_WORD[metal]} URD Purchase ${settingIgnored}. ${message}` : message,
  );
}

/**
 * Whether `coBook` is the company's URD purchase book for either metal, by the same rule. A metal whose rule resolves
 * no single book (none or several) contributes nothing. Returns the metal, or null for an ordinary purchase book.
 */
export async function isUrdPurchaseBookTx(
  tx: any,
  scope: UrdBookScope,
  coBook: string,
): Promise<UrdMetal | null> {
  const wanted = text(coBook);
  for (const metal of ['G', 'S'] as const) {
    try {
      if ((await resolveUrdPurchaseBookTx(tx, scope, metal)).coBook === wanted) return metal;
    } catch (error) {
      if (!(error instanceof UrdBookValidationError)) throw error;
    }
  }
  return null;
}

export interface UrdBookSettings {
  goldBook: string | null;
  silverBook: string | null;
}

/**
 * Settings screen: the stored choice, the selectable PURCHASE books (any location of the company, since the setting is
 * per company), and what each metal resolves to at the session's location.
 */
export async function getUrdBookSettingsTx(
  tx: any,
  scope: UrdBookScope,
): Promise<{
  values: UrdBookSettings;
  books: Array<{ coBook: string; bookName: string }>;
  lcCode: string;
  resolved: Record<
    'gold' | 'silver',
    | { coBook: string; bookName: string; source: string; settingIgnored?: string }
    | { error: string }
  >;
}> {
  const gold = await urdBookSettingTx(tx, scope, 'G');
  const silver = await urdBookSettingTx(tx, scope, 'S');
  const books = await activePurchaseBooksTx(tx, { ...scope, lcCode: null }, 'true', []);
  const resolve = async (metal: UrdMetal) => {
    try {
      const { coBook, bookName, source, settingIgnored } = await resolveUrdPurchaseBookTx(
        tx,
        scope,
        metal,
      );
      return { coBook, bookName, source, ...(settingIgnored ? { settingIgnored } : {}) };
    } catch (error) {
      if (error instanceof UrdBookValidationError) return { error: error.message };
      throw error;
    }
  };
  return {
    values: { goldBook: gold || null, silverBook: silver || null },
    books,
    lcCode: scope.lcCode,
    resolved: { gold: await resolve('G'), silver: await resolve('S') },
  };
}

/**
 * Save the per-company choice. A blank value clears it (the fallback rule applies again). A value must name an active
 * PURCHASE book of some location of the company, and the same book cannot serve both metals.
 */
export async function saveUrdBookSettingsTx(
  tx: any,
  scope: UrdBookScope,
  input: { goldBook?: unknown; silverBook?: unknown },
  updatedBy: string,
): Promise<UrdBookSettings> {
  const next: UrdBookSettings = {
    goldBook: text(input.goldBook) || null,
    silverBook: text(input.silverBook) || null,
  };
  for (const [metal, book] of [
    ['G', next.goldBook],
    ['S', next.silverBook],
  ] as const) {
    if (!book) continue;
    const [found] = await activePurchaseBooksTx(
      tx,
      { ...scope, lcCode: null },
      `btrim("CO_BOOK")=$4`,
      [book],
    );
    if (!found) {
      throw new UrdBookValidationError(
        metal,
        `${METAL_WORD[metal]} URD Purchase book ${book} is not an active Purchase book`,
      );
    }
  }
  if (next.goldBook && next.goldBook === next.silverBook) {
    throw new UrdBookValidationError('S', 'Gold and Silver URD Purchase books must differ');
  }
  await tx.$executeRawUnsafe(
    `INSERT INTO "company_urd_book"(tenant_id,"CO_CODE",gold_book,silver_book,updated_by,updated_at)
     VALUES ($1,$2,$3,$4,$5,now())
     ON CONFLICT (tenant_id,"CO_CODE") DO UPDATE
       SET gold_book=EXCLUDED.gold_book, silver_book=EXCLUDED.silver_book,
           updated_by=EXCLUDED.updated_by, updated_at=now()`,
    scope.tenantId,
    scope.coCode,
    next.goldBook,
    next.silverBook,
    updatedBy.slice(0, 64) || null,
  );
  return next;
}
