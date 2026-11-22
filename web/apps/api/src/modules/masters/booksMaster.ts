import { withTxBudget } from '../shared/txBudget.js';
import { requiredVersion, versionOf } from '../vouchers/version.js';
import { DESKTOP_BOOK_TABLES } from '../ops/seedCompany.js';
import { BOOK_TEMPLATES, DESKTOP_DEFAULT_ACCOUNT_ROLES } from './bookTemplates.js';

/**
 * Company → Books (desktop MS_BOOK; MDI_FORM.cs:7443-7448 opens it directly). One BOOK_DATA header per company,
 * location and book code, and one BOOK_DETL row per posting-account slot, the rows every voucher of the book posts
 * through (`shared/bookPolicy.ts`, `shared/postingAccounts.ts`).
 *
 * - The list is the location's books ordered by code, shown as Code / Name / Trfr (MS_BOOK.cs:2461, :2418-2424). The
 *   Transaction Name combo offers the families the location's books already have, alphabetically (:2119).
 * - The family's grid is its BOOK_IDTL template without SR_NO 0, and the first row's direction sets Inword/Outword in
 *   add mode (:2936-2948). A reopen lays the template, SR_NO 0 included, under the book's saved slots (:2541-2556).
 * - BtnSave_Click (:2579-2685) refuses the reserved codes 218/888/999, a blank short name and a blank code or name, in
 *   that order; it writes the header from the boxes, each combo as its first letter (:2621-2625), a blank Data Type as
 *   'A' (:2630), and one detail row per grid row repeating the header columns (:2653-2673). MAIN_USER is the user for a
 *   new book and the stored one for an opened book (:2446, :2527).
 * - Leaving the code refuses a code another book has; leaving the name, a name another code has (:2778, :2800).
 * - BtnDelete_Click (:2687-2726) refuses a blank code, a book AC_DATA uses (company and book, every location) and a
 *   book MAIN_STOCK uses at the location, then deletes the header and the slots.
 *
 * Deliberate differences, recorded on G252:
 * - Header and slots are written and deleted in one transaction under a per-location lock. The desktop deletes the
 *   header and the details and inserts them again with separate statements (:2608-2675), and inserts the header from a
 *   blank row, which empties BOOK_TBL_NAME and the other columns the form does not show; the header is updated in place.
 * - Slots are matched by SR_NO, not by row position (the desktop's reopen and family Enter overlay saved rows by
 *   position, and the family Enter drops the last saved account, :2554 and :2958).
 * - A slot account must be in the company's account master (blank stays allowed, decision D5); two rows with one
 *   slot number are refused (the posting readers refuse such a book).
 * - An opened book's direction and invoice type cannot be changed (the Ctrl+O override, :2853-2857, is not ported,
 *   decision D6), nor its mobile-entry flag (read-only on reopen, :2526).
 * - A book that has vouchers keeps its Transaction Name (decision D4): the desktop has no such guard, and a changed
 *   family re-routes the book's postings.
 * - An opened book carries a version token (N51); a save or delete after another operator's change is refused (409).
 * - The baseline BOOK_IDTL rows of the older families are not in the source (MISSING in the study), so a family
 *   without template rows takes the slots of the location's first book of that family, and a template default the
 *   company's chart lacks takes the provisioned account of the same role (`bookTemplates.ts`).
 */
export class BooksMasterValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'BooksMasterValidationError';
  }
}

export class BookNotFoundError extends Error {
  readonly code = 'book-not-found';
  constructor() {
    super('book code not found');
    this.name = 'BookNotFoundError';
  }
}

export class BookVersionConflictError extends Error {
  readonly code = 'book-version-conflict';
  constructor() {
    super(
      'This book was changed by someone else after you opened it. Open it again before saving or deleting.',
    );
    this.name = 'BookVersionConflictError';
  }
}

export const BOOK_MESSAGES = {
  reserved: 'This Is a Reserve Code You Cant Use It...',
  shortRequired: 'Please Insert Book Short Name',
  detailRequired: 'Error Found : Please Enter Book Detail First...',
  selectForDelete: 'Please Select Product For Delete.',
  usedInAccounts: 'You Cant Delete Record This Book Code Use in Account Transection....',
  usedInStock: 'You Cant Delete Record This Book Code Use in Stock Transection....',
  familyLocked: 'This book already has vouchers, so its Transaction Name cannot be changed.',
} as const;
/** tBkCode_Validating (MS_BOOK.cs:2778) and tBkName_Validating (:2800). */
export const bookCodeTakenMessage = (name: string): string =>
  `This Book Code already Exist in  '${name}'  Book Name... Please Change Book Code...`;
export const bookNameTakenMessage = (code: string): string =>
  `This Book Name already Exist in  '${code}'  Book Code... Please Change Book Name...`;

/** MS_BOOK.cs:2591. */
const RESERVED_CODES = new Set(['218', '888', '999']);
/** The boxes' MaxLength (MS_BOOK.cs:1428, :1435, :1526, :1511, :1745, :1770, :1845, :1582) and the grid editor's. */
const LIMITS = {
  code: ['Book Code', 3],
  name: ['Book Name', 50],
  short: ['Book Short', 5],
  vchSeries: ['Vch Serice', 15],
  resetBook: ['ReSet Book', 5],
  trfrBook: ['Trfr Book', 5],
  mobileEntry: ['With Mobile Entry', 1],
  family: ['Transaction Name', 30],
} as const;
/** The combos' entries (MS_BOOK.cs:2099-2112); the stored value is the first letter (:2621-2625). */
const COMBOS = {
  curUse: ['Cur In Use', ['Yes', 'No']],
  itemType: ['Item Type', ['All', 'Gold', 'Silver']],
  inout: ['Tran In / Out', ['Inword', 'Outword']],
  bookType: ['Invoice Type', ['Free', 'Tax Invoice', 'Mix']],
} as const;

export interface BooksScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
}

export interface BookSlotView {
  srNo: number;
  /** Account Desc: the template's description. */
  desc: string;
  acCode: string;
  acName: string;
}

export interface BookView {
  code: string;
  name: string;
  short: string;
  curUse: string;
  family: string;
  itemType: string;
  inout: string;
  bookType: string;
  vchSeries: string;
  resetBook: string;
  trfrBook: string;
  mobileEntry: string;
  mainUser: string;
  slots: BookSlotView[];
  /** AC_DATA or MAIN_STOCK rows name the book: Delete refuses it and its family is locked (D4). */
  hasVouchers: boolean;
  version: string;
}

export interface BookSaveInput {
  scope: BooksScope;
  user: string;
  entryMode: 'A' | 'E';
  code: unknown;
  values: Record<string, unknown>;
  slots: unknown;
  expectedVersion?: unknown;
}

const text = (value: unknown): string => String(value ?? '').trim();
/** MS_BOOK_KeyPress upper-cases every key but Book Name's and drops the apostrophe (MS_BOOK.cs:2752-2763). */
const typed = (value: unknown): string => text(value).toUpperCase().replace(/'/g, '');
const fail = (message: string): never => {
  throw new BooksMasterValidationError(message);
};

const lockTx = (tx: any, scope: BooksScope) =>
  tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `books-master:${scope.tenantId}:${scope.coCode}:${scope.lcCode}`,
  );

const headerRowsTx = (tx: any, scope: BooksScope, code: string): Promise<any[]> =>
  tx.$queryRawUnsafe(
    `SELECT * FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
      ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    code,
  );
const detailRowsTx = (tx: any, scope: BooksScope, code: string): Promise<any[]> =>
  tx.$queryRawUnsafe(
    `SELECT * FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
      ORDER BY "SR_NO",row_id`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    code,
  );

/** SHA-256 of the book's header and slot rows, row ids included (N51). */
async function bookVersionTx(tx: any, scope: BooksScope, code: string): Promise<string> {
  return versionOf({
    BOOK_DATA: await headerRowsTx(tx, scope, code),
    BOOK_DETL: await detailRowsTx(tx, scope, code),
  });
}

/** The two reference checks of BtnDelete_Click (MS_BOOK.cs:2706, :2713), also the family lock of decision D4. */
async function voucherUseTx(
  tx: any,
  scope: BooksScope,
  code: string,
): Promise<{ accounts: boolean; stock: boolean }> {
  const [row] = await tx.$queryRawUnsafe(
    `SELECT EXISTS(SELECT 1 FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$4) accounts,
            EXISTS(SELECT 1 FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
                     AND "CO_BOOK"=$4) stock`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    code,
  );
  return { accounts: Boolean(row?.accounts), stock: Boolean(row?.stock) };
}

async function accountNamesTx(
  tx: any,
  scope: BooksScope,
  codes: string[],
): Promise<Map<string, string>> {
  const wanted = [...new Set(codes.filter(Boolean))];
  if (!wanted.length) return new Map();
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT DISTINCT ON ("AC_CODE") "AC_CODE","AC_NAME" FROM "AC_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE" = ANY($3::text[]) ORDER BY "AC_CODE",row_id`,
    scope.tenantId,
    scope.coCode,
    wanted,
  );
  return new Map(rows.map((row) => [text(row.AC_CODE), text(row.AC_NAME)]));
}

interface TemplateRow {
  srNo: number;
  inout: string;
  desc: string;
  acCode: string;
}

/**
 * The family's template rows with their default accounts resolved against the company's chart. BOOK_IDTL of the
 * tenant wins when it has the family (the desktop reads only it); else the MS_UPDATE.cs template, with the slots the
 * source lacks taken from the location's first book of the family.
 */
async function familyTemplateTx(
  tx: any,
  scope: BooksScope,
  family: string,
  withSrZero: boolean,
): Promise<{ rows: TemplateRow[]; inout: string }> {
  if (!family) return { rows: [], inout: '' };
  const idtl: any[] = await tx.$queryRawUnsafe(
    `SELECT "SR_NO","INOUT_TYPE","AC_CODE","AC_NAME" FROM "BOOK_IDTL"
      WHERE tenant_id=$1 AND upper(btrim("MAIN_BOOK"))=$2 ORDER BY "SR_NO",row_id`,
    scope.tenantId,
    family,
  );
  let rows: TemplateRow[];
  // The first template row's INOUT_TYPE sets the direction (MS_BOOK.cs:2942-2948).
  let first = '';
  if (idtl.length) {
    rows = idtl.map((row) => ({
      srNo: Number(row.SR_NO ?? 0),
      inout: typed(row.INOUT_TYPE),
      desc: text(row.AC_NAME),
      acCode: text(row.AC_CODE),
    }));
  } else {
    const template = BOOK_TEMPLATES[family] ?? [];
    first = template[0]?.inout ?? '';
    const taken = new Set(template.map((slot) => slot.srNo));
    const base: any[] = await tx.$queryRawUnsafe(
      `SELECT d."SR_NO",d."AC_CODE",d."BOOK_INOUT",a."AC_NAME" FROM "BOOK_DETL" d
         LEFT JOIN LATERAL (SELECT "AC_NAME" FROM "AC_MAST" m WHERE m.tenant_id=d.tenant_id
                              AND m."CO_CODE"=d."CO_CODE" AND m."AC_CODE"=d."AC_CODE" ORDER BY row_id LIMIT 1) a ON true
        WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3
          AND d."CO_BOOK"=(SELECT min(b."CO_BOOK") FROM "BOOK_DATA" b WHERE b.tenant_id=$1 AND b."CO_CODE"=$2
                             AND b."LC_CODE"=$3 AND upper(btrim(b."MAIN_BOOK"))=$4)
        ORDER BY d."SR_NO",d.row_id`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      family,
    );
    rows = [
      ...template.map((slot) => ({ ...slot })),
      ...base
        .filter((row) => !taken.has(Number(row.SR_NO ?? 0)))
        .map((row) => ({
          srNo: Number(row.SR_NO ?? 0),
          inout: typed(row.BOOK_INOUT),
          desc: text(row.AC_NAME),
          acCode: text(row.AC_CODE),
        })),
    ];
    rows.sort((a, b) => a.srNo - b.srNo);
  }
  rows = rows.filter((row, i) => rows.findIndex((other) => other.srNo === row.srNo) === i);
  if (!withSrZero) rows = rows.filter((row) => row.srNo !== 0);
  first ||= rows[0]?.inout ?? '';
  const desktopCodes = rows.map((row) => row.acCode);
  const known = await accountNamesTx(tx, scope, [
    ...desktopCodes,
    ...desktopCodes.map((code) => DESKTOP_DEFAULT_ACCOUNT_ROLES[code] ?? ''),
  ]);
  return {
    inout: first ? (first === 'I' ? 'I' : 'O') : '',
    rows: rows.map((row) => {
      const role = DESKTOP_DEFAULT_ACCOUNT_ROLES[row.acCode] ?? '';
      const acCode = known.has(row.acCode) ? row.acCode : known.has(role) ? role : '';
      return { ...row, acCode };
    }),
  };
}

/** Template rows with the saved slots over them, by slot number. */
async function slotViewsTx(
  tx: any,
  scope: BooksScope,
  template: TemplateRow[],
  saved: Array<{ srNo: number; acCode: string }>,
): Promise<BookSlotView[]> {
  const bySr = new Map<number, { desc: string; acCode: string }>();
  for (const row of template) bySr.set(row.srNo, { desc: row.desc, acCode: row.acCode });
  for (const row of saved)
    bySr.set(row.srNo, { desc: bySr.get(row.srNo)?.desc ?? '', acCode: row.acCode });
  const names = await accountNamesTx(
    tx,
    scope,
    [...bySr.values()].map((row) => row.acCode),
  );
  return [...bySr.entries()]
    .sort(([a], [b]) => a - b)
    .map(([srNo, row]) => ({
      srNo,
      desc: row.desc,
      acCode: row.acCode,
      acName: names.get(row.acCode) ?? '',
    }));
}

const savedSlots = (rows: any[]) =>
  rows.map((row) => ({ srNo: Number(row.SR_NO ?? 0), acCode: text(row.AC_CODE) }));

export async function listBooks(
  prisma: any,
  scope: BooksScope,
): Promise<{ rows: Array<{ code: string; name: string; trfr: string }>; families: string[] }> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "CO_BOOK","BOOK_NAME","TRFR_BOOK" FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 ORDER BY "CO_BOOK",row_id`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
    );
    const families: any[] = await tx.$queryRawUnsafe(
      `SELECT DISTINCT "MAIN_BOOK" FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND coalesce(btrim("MAIN_BOOK"),'')<>''
        ORDER BY 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
    );
    return {
      rows: rows.map((row) => ({
        code: text(row.CO_BOOK),
        name: text(row.BOOK_NAME),
        trfr: text(row.TRFR_BOOK),
      })),
      families: families.map((row) => text(row.MAIN_BOOK)),
    };
  });
}

/** The family Enter (MS_BOOK.cs:2922-2971): the template, under the opened book's saved slots when it is its family. */
export async function bookTemplate(
  prisma: any,
  scope: BooksScope,
  familyRaw: unknown,
  codeRaw?: unknown,
): Promise<{ family: string; inout: string; slots: BookSlotView[] }> {
  const family = text(familyRaw).toUpperCase();
  const code = typed(codeRaw);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const { rows: template, inout } = await familyTemplateTx(tx, scope, family, false);
    let saved: Array<{ srNo: number; acCode: string }> = [];
    if (code) {
      const [head] = await headerRowsTx(tx, scope, code);
      if (head && text(head.MAIN_BOOK).toUpperCase() === family)
        saved = savedSlots(await detailRowsTx(tx, scope, code));
    }
    return {
      family,
      inout,
      slots: await slotViewsTx(tx, scope, template, saved),
    };
  });
}

const comboLetter = (stored: unknown, letters: string, fallback: string) => {
  const letter = typed(stored).slice(0, 1);
  return letters.includes(letter) && letter ? letter : fallback;
};

export async function getBook(
  prisma: any,
  scope: BooksScope,
  codeRaw: unknown,
): Promise<BookView | null> {
  const code = typed(codeRaw);
  if (!code) return null;
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const [head] = await headerRowsTx(tx, scope, code);
    if (!head) return null;
    const family = text(head.MAIN_BOOK).toUpperCase();
    const { rows: template } = await familyTemplateTx(tx, scope, family, true);
    const detail = await detailRowsTx(tx, scope, code);
    const use = await voucherUseTx(tx, scope, code);
    return {
      code: text(head.CO_BOOK),
      name: text(head.BOOK_NAME),
      short: text(head.BOOK_SNAME),
      // DISPLAY_DATA leaves a combo at its cleared first entry when the stored letter matches none (:2481-2520).
      curUse: comboLetter(head.CUR_USE, 'YN', 'Y'),
      family: text(head.MAIN_BOOK),
      itemType: comboLetter(head.ITM_TYPE, 'AGS', 'A'),
      inout: comboLetter(head.BOOK_INOUT, 'IO', 'I'),
      bookType: comboLetter(head.BOOK_TYPE, 'FTM', 'F'),
      vchSeries: text(head.BOOK_SR_NAME),
      resetBook: text(head.RESET_BOOK),
      trfrBook: text(head.TRFR_BOOK),
      mobileEntry: text(head.WITH_MOBILE_ENTRY),
      mainUser: text(head.MAIN_USER),
      slots: await slotViewsTx(tx, scope, template, savedSlots(detail)),
      hasVouchers: use.accounts || use.stock,
      version: await bookVersionTx(tx, scope, code),
    };
  });
}

interface CleanHeader {
  code: string;
  name: string;
  short: string;
  curUse: string;
  family: string;
  itemType: string;
  inout: string;
  bookType: string;
  vchSeries: string;
  resetBook: string;
  trfrBook: string;
  mobileEntry: string;
}

function combo(key: keyof typeof COMBOS, value: unknown): string {
  const [label, entries] = COMBOS[key];
  const raw = text(value).toUpperCase();
  const hit = entries.find((entry) => entry.toUpperCase() === raw || entry[0] === raw);
  if (!hit) fail(`${label} must be one of ${entries.join(', ')}.`);
  return hit![0]!;
}

/** BtnSave_Click's checks in its order (MS_BOOK.cs:2591-2606), then the boxes' limits and the combos' entries. */
function cleanHeader(codeRaw: unknown, v: Record<string, unknown>): CleanHeader {
  const code = typed(codeRaw);
  const name = text(v.name);
  const short = typed(v.short);
  if (RESERVED_CODES.has(code)) fail(BOOK_MESSAGES.reserved);
  if (!short) fail(BOOK_MESSAGES.shortRequired);
  if (!code || !name) fail(BOOK_MESSAGES.detailRequired);
  const header: CleanHeader = {
    code,
    name,
    short,
    curUse: combo('curUse', v.curUse ?? 'Y'),
    family: text(v.family).toUpperCase(),
    itemType: combo('itemType', v.itemType ?? 'A'),
    inout: combo('inout', v.inout ?? 'I'),
    bookType: combo('bookType', v.bookType ?? 'F'),
    vchSeries: typed(v.vchSeries),
    resetBook: typed(v.resetBook),
    trfrBook: typed(v.trfrBook),
    mobileEntry: typed(v.mobileEntry),
  };
  for (const [key, [label, max]] of Object.entries(LIMITS))
    if (header[key as keyof CleanHeader].length > max)
      fail(`${label} holds at most ${max} characters.`);
  return header;
}

/** The grid rows: Val of the Sr cell (:2661), an account of at most 8 characters, one row per slot number. */
function cleanSlots(raw: unknown): Array<{ srNo: number; acCode: string }> {
  if (!Array.isArray(raw)) fail('The slot grid is missing.');
  const seen = new Set<number>();
  return (raw as unknown[]).map((entry: any) => {
    const sr = text(entry?.srNo);
    const srNo = Number(sr);
    if (!/^\d{1,2}$/.test(sr) || !Number.isInteger(srNo))
      fail(`Sr ${sr || '(blank)'} is not a slot number.`);
    if (seen.has(srNo)) fail(`Slot ${srNo} is entered twice.`);
    seen.add(srNo);
    const acCode = typed(entry?.acCode);
    if (acCode.length > 8) fail(`AcCode ${acCode} holds at most 8 characters.`);
    return { srNo, acCode };
  });
}

/**
 * BtnSave_Click: the header and its slots in one transaction. A new book needs a code no book of the location has (a
 * repeated identical create answers as the first did); an opened book needs its current version.
 */
export async function saveBook(
  prisma: any,
  input: BookSaveInput,
): Promise<{ code: string; slots: number }> {
  const h = cleanHeader(input.code, input.values);
  const slots = cleanSlots(input.slots);
  const expected = input.entryMode === 'E' ? requiredVersion(input.expectedVersion) : null;
  const { scope } = input;
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await lockTx(tx, scope);
    const heads = await headerRowsTx(tx, scope, h.code);
    const stored = heads[0];
    if (input.entryMode === 'E') {
      if (!stored) throw new BookNotFoundError();
      if ((await bookVersionTx(tx, scope, h.code)) !== expected)
        throw new BookVersionConflictError();
    }
    const [sameName] = await tx.$queryRawUnsafe(
      `SELECT "CO_BOOK" FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND upper(btrim("BOOK_NAME"))=upper($4) AND "CO_BOOK"<>$5 ORDER BY "CO_BOOK" LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      h.name,
      h.code,
    );
    if (input.entryMode === 'A' && stored) {
      if (text(stored.BOOK_NAME).toUpperCase() !== h.name.toUpperCase())
        fail(bookCodeTakenMessage(text(stored.BOOK_NAME)));
      // The same create again (a double click, a lost answer): one book, answered as the first time.
      const same = savedSlots(await detailRowsTx(tx, scope, h.code));
      if (
        JSON.stringify(same) === JSON.stringify([...slots].sort((a, b) => a.srNo - b.srNo)) &&
        text(stored.MAIN_BOOK).toUpperCase() === h.family
      )
        return { code: h.code, slots: same.length };
      fail(bookCodeTakenMessage(text(stored.BOOK_NAME)));
    }
    if (sameName) fail(bookNameTakenMessage(text(sameName.CO_BOOK)));

    const names = await accountNamesTx(
      tx,
      scope,
      slots.map((slot) => slot.acCode),
    );
    for (const slot of slots)
      if (slot.acCode && !names.has(slot.acCode))
        fail(`Account ${slot.acCode} of slot ${slot.srNo} is not in the account master.`);

    let inout = h.inout;
    let bookType = h.bookType;
    let mobileEntry = h.mobileEntry;
    if (stored) {
      if (comboLetter(stored.BOOK_INOUT, 'IO', 'I') !== h.inout)
        fail('Tran In / Out of a saved book cannot be changed.');
      if (comboLetter(stored.BOOK_TYPE, 'FTM', 'F') !== h.bookType)
        fail('Invoice Type of a saved book cannot be changed.');
      if (text(stored.MAIN_BOOK).toUpperCase() !== h.family) {
        const use = await voucherUseTx(tx, scope, h.code);
        if (use.accounts || use.stock) fail(BOOK_MESSAGES.familyLocked);
      }
      inout = text(stored.BOOK_INOUT) || h.inout;
      bookType = text(stored.BOOK_TYPE) || h.bookType;
      mobileEntry = text(stored.WITH_MOBILE_ENTRY);
    }
    const dataType = text(stored?.DATA_TYPE) || 'A';
    const tables = DESKTOP_BOOK_TABLES[h.family];
    const header: Record<string, unknown> = {
      BOOK_NAME: h.name,
      BOOK_SNAME: h.short,
      CUR_USE: h.curUse,
      MAIN_BOOK: h.family,
      ITM_TYPE: h.itemType,
      BOOK_INOUT: inout,
      BOOK_TYPE: bookType,
      BOOK_SR_NAME: h.vchSeries,
      USER_EMP_CODE: text(stored?.USER_EMP_CODE),
      DATA_TYPE: dataType,
      RESET_BOOK: h.resetBook,
      TRFR_BOOK: h.trfrBook,
      WITH_MOBILE_ENTRY: mobileEntry,
      MAIN_USER: stored ? text(stored.MAIN_USER) : input.user,
      // The families that route by their table (`seedCompany.ts`); a value already set is kept.
      BOOK_TBL_NAME: text(stored?.BOOK_TBL_NAME) || tables?.table || null,
      BOOK_TBL_DETL: text(stored?.BOOK_TBL_DETL) || tables?.detail || null,
    };
    const columns = Object.keys(header);
    if (stored) {
      await tx.$executeRawUnsafe(
        `UPDATE "BOOK_DATA" SET ${columns.map((c, i) => `"${c}"=$${i + 3}`).join(',')}
          WHERE tenant_id=$1 AND row_id=$2`,
        scope.tenantId,
        stored.row_id,
        ...Object.values(header),
      );
      if (heads.length > 1)
        await tx.$executeRawUnsafe(
          `DELETE FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
              AND row_id<>$5`,
          scope.tenantId,
          scope.coCode,
          scope.lcCode,
          h.code,
          stored.row_id,
        );
    } else {
      const all = { CO_CODE: scope.coCode, LC_CODE: scope.lcCode, CO_BOOK: h.code, ...header };
      await tx.$executeRawUnsafe(
        `INSERT INTO "BOOK_DATA"(tenant_id,${Object.keys(all)
          .map((c) => `"${c}"`)
          .join(',')}) VALUES ($1,${Object.keys(all)
          .map((_, i) => `$${i + 2}`)
          .join(',')})`,
        scope.tenantId,
        ...Object.values(all),
      );
    }
    await tx.$executeRawUnsafe(
      `DELETE FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      h.code,
    );
    for (const slot of slots)
      await tx.$executeRawUnsafe(
        `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","BOOK_NAME","BOOK_SNAME",
           "BOOK_TYPE","ITM_TYPE","BOOK_INOUT","AC_CODE","AC_NAME","MAIN_BOOK","RESET_BOOK","DATA_TYPE")
         VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12,$13,$14,$15)`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        h.code,
        slot.srNo,
        h.name,
        h.short,
        bookType,
        h.itemType,
        inout,
        slot.acCode,
        names.get(slot.acCode) ?? '',
        h.family,
        h.resetBook,
        dataType,
      );
    return { code: h.code, slots: slots.length };
  });
}

/** BtnDelete_Click (MS_BOOK.cs:2687-2726), the guards checked inside the deleting transaction. */
export async function deleteBook(
  prisma: any,
  scope: BooksScope,
  codeRaw: unknown,
  expectedVersion?: unknown,
): Promise<{ code: string; deleted: number; slots: number }> {
  const code = typed(codeRaw);
  if (!code) fail(BOOK_MESSAGES.selectForDelete);
  const expected =
    expectedVersion == null || expectedVersion === '' ? null : requiredVersion(expectedVersion);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await lockTx(tx, scope);
    const heads = await headerRowsTx(tx, scope, code);
    if (!heads.length) throw new BookNotFoundError();
    if (expected && (await bookVersionTx(tx, scope, code)) !== expected)
      throw new BookVersionConflictError();
    const use = await voucherUseTx(tx, scope, code);
    if (use.accounts) fail(BOOK_MESSAGES.usedInAccounts);
    if (use.stock) fail(BOOK_MESSAGES.usedInStock);
    const key = [scope.tenantId, scope.coCode, scope.lcCode, code];
    const where = `tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4`;
    const deleted = await tx.$executeRawUnsafe(`DELETE FROM "BOOK_DATA" WHERE ${where}`, ...key);
    const slots = await tx.$executeRawUnsafe(`DELETE FROM "BOOK_DETL" WHERE ${where}`, ...key);
    return { code, deleted: Number(deleted), slots: Number(slots) };
  });
}

/**
 * The slot account lookup (MSG_KeyDown, MS_BOOK.cs:2310-2337): a code found in the company's accounts is taken (it is
 * listed first); else the help lists the company's accounts by name, with no class or location filter (:2318).
 */
export async function bookAccounts(
  prisma: any,
  scope: BooksScope,
  term: unknown,
  limit = 200,
): Promise<Array<{ code: string; name: string; group: string }>> {
  const q = text(term);
  const search = (wanted: string): Promise<any[]> => {
    const like = wanted.replace(/[\\%_]/g, (c) => `\\${c}`);
    return withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "AC_CODE","AC_NAME","AC_GR" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
            AND ($3='' OR "AC_CODE"=$3 OR "AC_CODE" ILIKE $4 OR "AC_NAME" ILIKE $5)
          ORDER BY ("AC_CODE"=$3) DESC,"AC_NAME","AC_CODE" LIMIT $6`,
        scope.tenantId,
        scope.coCode,
        wanted.toUpperCase(),
        `${like}%`,
        `%${like}%`,
        Math.min(Math.max(Number(limit) || 200, 1), 500),
      ),
    );
  };
  // An unknown code opens the help of every company account by name (MS_BOOK.cs:2318), not an empty list.
  let rows = await search(q);
  if (!rows.length && q) rows = await search('');
  return rows.map((row) => ({
    code: text(row.AC_CODE),
    name: text(row.AC_NAME),
    group: text(row.AC_GR),
  }));
}

/** The book list behind the Print right (web addition, decision D7): Code, Name, Trfr. */
export async function bookPrintRows(
  prisma: any,
  scope: BooksScope,
): Promise<Array<{ code: string; name: string; trfr: string }>> {
  return (await listBooks(prisma, scope)).rows;
}
