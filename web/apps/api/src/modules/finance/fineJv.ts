import { formatDesktopDate, round, toIsoDate } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { buildFineJvRojmel, rojmelMetalFor } from '../shared/rojmel.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import { assertFiscalDateTx } from '../vouchers/lifecycle.js';
import {
  assertPeriodOpen,
  insertRowTx,
  PeriodLockValidationError,
  postVoucherTx,
  reverseVoucherTx,
  type LedgerLine,
} from '../posting/posting.js';
import { sqlStr } from '../posting/lineLegs.js';
import {
  completeFinanceScope,
  configuredBookTx,
  createIdentityTx,
  editIdentityTx,
  insertDesktopDeleteAuditTx,
  insertHiddenIdentityTx,
  replaceWriteSetTx,
  text,
  num,
  voucherKey,
  type VoucherIdentity,
} from './lifecycle.js';

/**
 * Fine Jv Entry (desktop TR_CONTRA with FormMainBook = 'FINE JV', opened by MDI_FORM.cs:8360-8365).
 *
 * The screen is the same grid as Contra Entry with fine weights instead of money: row 1 is the main
 * account and every later row i is paired with it (TR_CONTRA.cs:2760-2847). Row i is written first
 * (LDR_TYPE '0', its own Cr/Dr side, CR_FINE from the Cr column and DR_FINE from the Dr column, LD_CODE =
 * row 1, row i's description) and row 1 is then mirrored against it (LDR_TYPE '1', row 1's side, the
 * opposite fine, LD_CODE = row i, row 1's description). Contra_Ledr posts one AC_DATA leg per CR_FINE row
 * (`STR(SR_NO)+'03'`, `+`) and per DR_FINE row (`STR(SR_NO)+'04'`, `-`) (Ac_Ledr.cs:846-848),
 * Contra_Rojmel projects the same rows into the day book (Ac_Rojmel.cs:342-344), and Vch_Remark mode 3
 * rebuilds REMARK_DATA from the rows that carry a description (TR_CONTRA.cs:2890; Ac_Tax.cs:686-694).
 */
export class FineJvValidationError extends Error {
  constructor(m: string) {
    super(m);
    this.name = 'FineJvValidationError';
  }
}

/** A missing saved Fine JV is a stale document (N183), not a server error. */
export class FineJvNotFoundError extends Error {
  readonly statusCode = 404;
  readonly code = 'fine-jv-not-found';
  constructor(voucherNo: string) {
    super(`fine-jv voucher not found: ${voucherNo}`);
    this.name = 'FineJvNotFoundError';
  }
}

/** TR_CONTRA's save refusals, word for word. */
export const FINE_JV_MESSAGES = {
  /** TR_CONTRA.cs:2666-2672, when CO_SET.EMP_CODE_MANDATORY = 'Y' (MS_OPNCOMP.cs:710). */
  EMPLOYEE_REQUIRED: 'Please Select Employee Code and Try......',
  /** TR_CONTRA.cs:2673-2678, a new voucher in a company whose CO_TYPE is 'B'. */
  COMPANY_TYPE_B: 'You Cant Save This Voucher Becouse This Company Type is B......',
  /** TR_CONTRA.cs:2680-2685, a date outside the company's open and close dates. */
  NOT_IN_CURRENT_YEAR:
    'You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...',
  /** TR_CONTRA.cs:2686-2691 (save) and :2951-2954 (delete), a voucher dated on or before the lock date. */
  lockDate: (lockIso: string) =>
    `You Cant Save and Delete This Voucher Becouse Lock Date is = ${formatDesktopDate(lockIso)} ....`,
} as const;

/** Any period-lock refusal inside a Fine JV save or delete answers with the desktop text. */
async function withDesktopLockText<T>(work: () => Promise<T>): Promise<T> {
  try {
    return await work();
  } catch (error) {
    if (error instanceof PeriodLockValidationError)
      error.message = FINE_JV_MESSAGES.lockDate(error.lockDate);
    throw error;
  }
}

export interface FineJvLine {
  crdr: 'DR' | 'CR' | string;
  acCode: string;
  /** Omitted on an edit: keep the description the matching saved row carries. */
  itDesc?: string;
  fine: number;
}
export interface FineJvInput {
  scope: VoucherScope;
  /** The grid, row 1 first. */
  lines: FineJvLine[];
  /** cboItemTyp's first letter; omitted on an edit keeps the saved metal. */
  metal?: 'G' | 'S' | string;
  /** Omitted on an edit keeps the saved date. */
  vchDate?: Date | string;
  /** tEmpCode; omitted on an edit keeps the saved employee. */
  empCode?: string;
  mainUser?: string;
}
export interface FineJvResult {
  vchNo: number;
}
export interface FineJvGridLine {
  crdr: 'DR' | 'CR';
  acCode: string;
  acName: string;
  itDesc: string;
  fine: number;
}

type SourceRow = Record<string, unknown>;
type Book = Awaited<ReturnType<typeof configuredBookTx>>;
type Line = { crdr: 'DR' | 'CR'; acCode: string; itDesc?: string; fine: number };

/** Fine weights are 0.000 on the desktop grid (TR_CONTRA.cs:1509-1512, :1689-1692). */
const r3 = (n: number) => round(n, 3);
const FINE_JV_MAIN_BOOK = 'FINE JV';
// ROJ_MEL_DATA is in the edit set because its primary key is LEDR_KEY alone. REMARK_DATA is rebuilt by
// every save (Vch_Remark), and delete also clears it and APR_IDTL (TR_CONTRA.cs:2963-2968).
const WRITE_TABLES = ['CONTRA_DATA', 'AC_DATA', 'ROJ_MEL_DATA'] as const;
const DELETE_TABLES = [...WRITE_TABLES, 'REMARK_DATA', 'APR_IDTL'] as const;

/** Ac_Ledr.cs:846 joins `B.MAIN_BOOK = 'FINE JV' AND B.BOOK_INOUT = 'I'`; no other book posts fine legs. */
function requireFineJvBook(book: { mainBook: string; inout: string }): void {
  if (book.mainBook.trim().toUpperCase() !== FINE_JV_MAIN_BOOK)
    throw new FineJvValidationError(
      `fine-jv requires BOOK_DATA.MAIN_BOOK='${FINE_JV_MAIN_BOOK}' for the configured book`,
    );
  if (book.inout.trim().toUpperCase() !== 'I')
    throw new FineJvValidationError('fine-jv requires an inward FINE JV book');
}

/** The configured book, after the FINE JV family check; shared by the document route. */
export async function fineJvBookTx(tx: any, scope: VoucherScope): Promise<Book> {
  const book = await configuredBookTx(tx, scope);
  requireFineJvBook(book);
  return book;
}

export async function fineJvPrintBook(prisma: any, scope: VoucherScope): Promise<Book> {
  completeFinanceScope(scope);
  return withTxBudget(prisma, scope.tenantId, 'read', (tx: any) => fineJvBookTx(tx, scope));
}

function metalOf(value: unknown): 'G' | 'S' {
  const metal = text(value).toUpperCase();
  if (metal !== 'G' && metal !== 'S')
    throw new FineJvValidationError('fine-jv metal must be G (gold) or S (silver)');
  return metal;
}

/** The grid a request saves: TR_CONTRA.cs:2765 skips rows with no account or no value. */
export function fineJvLines(raw: unknown): Line[] {
  if (!Array.isArray(raw)) throw new FineJvValidationError('fine-jv requires grid lines');
  const lines = raw
    .map((line: any, index: number): Line => {
      const crdr = text(line?.crdr).toUpperCase();
      if (crdr !== 'DR' && crdr !== 'CR')
        throw new FineJvValidationError(`fine-jv line ${index + 1} must be DR or CR`);
      const fine = Number(line?.fine ?? 0);
      if (!Number.isFinite(fine) || fine < 0)
        throw new FineJvValidationError(`fine-jv line ${index + 1} needs a positive fine`);
      return {
        crdr,
        acCode: text(line?.acCode),
        itDesc:
          line?.itDesc === undefined || line?.itDesc === null ? undefined : String(line.itDesc),
        fine: r3(fine),
      };
    })
    .filter((line) => line.acCode && line.fine !== 0);
  if (lines.length < 2)
    throw new FineJvValidationError('a fine JV needs at least two accounts with a positive fine');
  return lines;
}

/** TR_CONTRA.cs:2692-2697: the CrFine and DrFine totals must agree (checked after the lock, as the desktop does). */
function assertBalancedFine(lines: Line[]): void {
  const total = (side: 'DR' | 'CR') =>
    r3(lines.filter((line) => line.crdr === side).reduce((sum, line) => sum + line.fine, 0));
  if (total('DR') !== total('CR'))
    throw new FineJvValidationError(DESKTOP_MESSAGES.CONTRA_DR_CR_NOT_SAME);
}

/** The scoped account master name (null when the code has no AC_MAST row), preferring the voucher's location. */
async function accountNameTx(tx: any, scope: VoucherScope, code: string): Promise<string | null> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "AC_NAME" FROM "AC_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
      ORDER BY CASE WHEN "LC_CODE"::text=$4 THEN 0
                    WHEN "LC_CODE" IS NULL OR btrim("LC_CODE"::text)='' THEN 1 ELSE 2 END,
               row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    code,
    scope.lcCode,
  );
  return rows.length ? text(rows[0]!.AC_NAME) : null;
}

/**
 * TR_CONTRA.cs:2666-2697 in desktop order: employee when mandatory, company type B on a new voucher, the current
 * year, the lock date, then equal totals. The employee must then name an EMP_MAST row (the desktop picks it from help).
 */
async function assertSaveAllowedTx(
  tx: any,
  scope: VoucherScope,
  options: { creating: boolean; empCode: string; date: Date; lines: Line[] },
): Promise<void> {
  const settings: Array<{ mandatory: string }> = await tx.$queryRawUnsafe(
    `SELECT upper(btrim(coalesce("EMP_CODE_MANDATORY"::text,''))) mandatory
       FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text`,
    scope.tenantId,
    scope.coCode,
  );
  if (settings.some((row) => row.mandatory === 'Y') && !options.empCode)
    throw new FineJvValidationError(FINE_JV_MESSAGES.EMPLOYEE_REQUIRED);
  if (options.creating) {
    const types: Array<{ type: string }> = await tx.$queryRawUnsafe(
      `SELECT DISTINCT upper(btrim(coalesce("CO_TYPE"::text,''))) "type"
         FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text`,
      scope.tenantId,
      scope.coCode,
    );
    if (types.some((row) => row.type === 'B'))
      throw new FineJvValidationError(FINE_JV_MESSAGES.COMPANY_TYPE_B);
  }
  try {
    await assertFiscalDateTx(tx, completeFinanceScope(scope), toIsoDate(options.date));
  } catch (error) {
    // Only the out-of-year date is the desktop refusal; an unusable YEAR_MAST keeps its own message.
    if (error instanceof Error && /is outside fiscal year/.test(error.message))
      throw new FineJvValidationError(FINE_JV_MESSAGES.NOT_IN_CURRENT_YEAR);
    throw error;
  }
  await assertPeriodOpen(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: options.date }] },
  });
  assertBalancedFine(options.lines);
  if (options.empCode) {
    const employees: unknown[] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text AND "EMP_CODE"=$3 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      options.empCode,
    );
    if (!employees.length)
      throw new FineJvValidationError(`fine-jv employee not found: ${options.empCode}`);
  }
}

/**
 * Names and descriptions for the grid. The desktop reloads the saved AC_NAME into the grid
 * (TR_CONTRA.cs:2502, :2550) and replaces it from AC_MAST only when another account is picked, so an
 * unchanged account keeps the saved name of the row it came from, even if its master row is gone; a new or
 * changed account must exist in AC_MAST. A description the request omits keeps that row's saved description.
 * `masterNames` holds the AC_MAST names Vch_Remark joins (null when there is no master row).
 */
async function resolveGridTx(
  tx: any,
  scope: VoucherScope,
  lines: Line[],
  saved?: FineJvGridLine[],
): Promise<{ grid: FineJvGridLine[]; masterNames: Map<string, string | null> }> {
  const masterNames = new Map<string, string | null>();
  for (const code of new Set(lines.map((line) => line.acCode)))
    masterNames.set(code, await accountNameTx(tx, scope, code));
  const used = new Set<number>();
  const grid = lines.map((line, index): FineJvGridLine => {
    let prior: FineJvGridLine | undefined;
    if (saved && index === 0 && saved[0]?.acCode === line.acCode) prior = saved[0];
    if (saved && index > 0) {
      const at = saved.findIndex((row, j) => j > 0 && !used.has(j) && row.acCode === line.acCode);
      if (at > 0) {
        used.add(at);
        prior = saved[at];
      }
    }
    const master = masterNames.get(line.acCode);
    if (!prior && master == null)
      throw new FineJvValidationError(`fine-jv account not found: ${line.acCode}`);
    return {
      crdr: line.crdr,
      acCode: line.acCode,
      acName: prior ? prior.acName : (master ?? ''),
      itDesc: line.itDesc ?? prior?.itDesc ?? '',
      fine: line.fine,
    };
  });
  return { grid, masterNames };
}

/** Vch_Remark mode 3 (Ac_Tax.cs:694 deletes, :686 inserts the rows whose IT_DESC is not blank). */
async function rebuildRemarksTx(
  tx: any,
  scope: VoucherScope,
  voucherNo: string,
  book: Book,
  rows: SourceRow[],
  masterNames: Map<string, string | null>,
): Promise<void> {
  const s = completeFinanceScope(scope);
  await tx.$executeRawUnsafe(
    `DELETE FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
    s.tenantId,
    s.coCode,
    s.lcCode,
    s.coYear,
    s.coBook,
    voucherNo,
  );
  for (const row of rows) {
    if (!text(row.IT_DESC)) continue;
    await insertRowTx(tx, 'REMARK_DATA', s.tenantId, {
      CO_CODE: s.coCode,
      LC_CODE: s.lcCode,
      CO_YEAR: s.coYear,
      CO_BOOK: s.coBook,
      VCH_NO: voucherNo,
      SR_NO: row.SR_NO,
      VCH_DATE: row.VCH_DATE,
      AC_CODE: row.AC_CODE,
      // Vch_Remark LEFT JOINs AC_MAST, so a code without a master row gets no name.
      AC_NAME: masterNames.get(text(row.AC_CODE)) ?? null,
      MAIN_BOOK: book.mainBook,
      VCH_REMARK: row.IT_DESC,
    });
  }
}

async function writeTx(
  tx: any,
  ctx: {
    scope: VoucherScope;
    book: Book;
    identity: VoucherIdentity;
    grid: FineJvGridLine[];
    masterNames: Map<string, string | null>;
    metal: 'G' | 'S';
    empCode: string;
  },
): Promise<FineJvResult> {
  const { scope, book, identity, grid, metal, empCode } = ctx;
  const first = grid[0]!;
  const key = voucherKey(scope, identity.voucherNo);
  const base = {
    ...key,
    VCH_DATE: identity.voucherDate,
    VCH_TIME: identity.voucherTime,
    VCH_TYPE: book.shortName,
    INOUT_TYPE: book.inout,
    ENTRY_TYPE: 'J',
    BOOK_NAME: book.mainBook,
    IT_TYPE: metal,
    DR_AMT: 0,
    CR_AMT: 0,
    HD_VCH_NO: identity.hiddenVoucherNo,
    EMP_CODE: empCode,
    MAIN_USER: identity.mainUser || null,
    // TR_CONTRA.cs:2805, :2814-2815, :2872-2875: every save clears the transfer and per-voucher rights flags.
    DATA_TRFR: 'N',
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
  };
  const rows = grid.slice(1).flatMap((row, index) => {
    const mirror = row.crdr === 'DR' ? 'CR' : 'DR';
    return [
      {
        ...base,
        SR_NO: index * 2 + 1,
        CRDR_TYPE: row.crdr,
        AC_CODE: row.acCode,
        LD_CODE: first.acCode,
        LDR_TYPE: '0',
        AC_NAME: row.acName,
        CR_FINE: row.crdr === 'CR' ? row.fine : 0,
        DR_FINE: row.crdr === 'DR' ? row.fine : 0,
        IT_DESC: row.itDesc,
      },
      {
        ...base,
        SR_NO: index * 2 + 2,
        CRDR_TYPE: first.crdr,
        AC_CODE: first.acCode,
        LD_CODE: row.acCode,
        LDR_TYPE: '1',
        AC_NAME: first.acName,
        CR_FINE: mirror === 'CR' ? row.fine : 0,
        DR_FINE: mirror === 'DR' ? row.fine : 0,
        IT_DESC: first.itDesc,
      },
    ];
  });
  const ledgerBase = {
    ...key,
    VCH_TYPE: book.shortName,
    VCH_DATE: identity.voucherDate,
    BOOK_NAME: book.mainBook,
    IT_TYPE: metal,
    FINE_RATE: 0,
    DR_AMT: 0,
    CR_AMT: 0,
    HD_VCH_NO: identity.hiddenVoucherNo,
    MAIN_USER: identity.mainUser || null,
    DATA_TYPE: book.dataType,
    DATA_TRFR: 'N',
    ENTRY_TIME: identity.voucherTime,
  };
  const ledger: LedgerLine[] = rows.flatMap((row) => [
    ...(row.CR_FINE
      ? [
          {
            ...ledgerBase,
            legKeySuffix: `${sqlStr(row.SR_NO)}03`,
            AC_CODE: row.AC_CODE,
            LD_CODE: row.LD_CODE,
            SIGN: '+',
            FINE_WT: row.CR_FINE,
            IT_DESC: row.IT_DESC,
          },
        ]
      : []),
    ...(row.DR_FINE
      ? [
          {
            ...ledgerBase,
            legKeySuffix: `${sqlStr(row.SR_NO)}04`,
            AC_CODE: row.AC_CODE,
            LD_CODE: row.LD_CODE,
            SIGN: '-',
            FINE_WT: row.DR_FINE,
            IT_DESC: row.IT_DESC,
          },
        ]
      : []),
  ]);
  const complete = completeFinanceScope(scope);
  const rojmelRows = rows.flatMap((row) =>
    buildFineJvRojmel(
      {
        scope: { coCode: complete.coCode, lcCode: complete.lcCode, coYear: complete.coYear },
        key,
        coBook: String(key.CO_BOOK),
        vchNo: String(key.VCH_NO),
        vchDate: identity.voucherDate,
        vchType: book.shortName,
        bookName: book.mainBook,
        // Ac_Rojmel.cs:342-344 copies each CONTRA_DATA row's AC_NAME and BOOK_DATA.DATA_TYPE.
        partyName: row.AC_NAME,
        partyCode: '',
      },
      [
        {
          lineNo: row.SR_NO,
          acCode: row.AC_CODE,
          ldCode: row.LD_CODE,
          metal: rojmelMetalFor(metal),
          creditFine: row.CR_FINE,
          debitFine: row.DR_FINE,
          description: row.IT_DESC || undefined,
        },
      ],
    ).map((dayBookRow) => ({ ...dayBookRow, DATA_TYPE: book.dataType })),
  );
  // TR_CONTRA.cs:2742-2753: TEMP_BOOK_DATA.BOOK_NAME is FormName, the BOOK_DATA.BOOK_NAME picked by
  // CurBookHelp (DC_Main.cs:1495-1531, TR_CONTRA.cs:2307).
  await insertHiddenIdentityTx(tx, scope, identity, book.name);
  await postVoucherTx(tx, scope.tenantId, {
    bookName: book.mainBook,
    ledger: { table: 'AC_DATA', lines: ledger },
    writes: [
      { table: 'CONTRA_DATA', rows },
      ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
    ],
  });
  await rebuildRemarksTx(tx, scope, identity.voucherNo, book, rows, ctx.masterNames);
  return { vchNo: identity.vchNo };
}

export async function postFineJv(p: any, i: FineJvInput): Promise<FineJvResult> {
  completeFinanceScope(i.scope);
  const lines = fineJvLines(i.lines);
  const metal = metalOf(i.metal ?? 'G');
  const date = i.vchDate ? new Date(i.vchDate) : new Date();
  const empCode = text(i.empCode);
  return withTxBudget(p, i.scope.tenantId, 'voucher', (tx) =>
    withDesktopLockText(async () => {
      const book = await fineJvBookTx(tx, i.scope);
      await assertSaveAllowedTx(tx, i.scope, { creating: true, empCode, date, lines });
      const resolved = await resolveGridTx(tx, i.scope, lines);
      const identity = await createIdentityTx(tx, i.scope, date, i.mainUser);
      return writeTx(tx, { scope: i.scope, book, identity, metal, empCode, ...resolved });
    }),
  );
}

async function sourceRowsTx(
  tx: any,
  scope: VoucherScope,
  voucherNo: string,
  lock = false,
): Promise<SourceRow[]> {
  return tx.$queryRawUnsafe(
    `SELECT "SR_NO","VCH_NO","VCH_DATE"::text,"VCH_TIME","HD_VCH_NO","MAIN_USER","CRDR_TYPE","LDR_TYPE",
            "AC_CODE","AC_NAME","LD_CODE","DR_AMT","CR_AMT","DR_FINE","CR_FINE","IT_TYPE","IT_DESC","EMP_CODE"
       FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
         AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"${lock ? ' FOR UPDATE' : ''}`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
}

/**
 * Reopen (TR_CONTRA.cs:2467-2565). Both queries group CONTRA_DATA by AC_CODE, AC_NAME, CRDR_TYPE and IT_DESC: the
 * LDR_TYPE '1' mirrors give row 1 and the LDR_TYPE '0' counter rows give the other rows, so two counter rows with
 * the same account, name, side and description reopen as one grid row with their fines summed. Groups keep the
 * order of their first SR_NO (the desktop's GROUP BY has no ORDER BY). Row 1's fine is the mirrors' net on its own
 * side; a row-1 group that carries both Cr and Dr fine (row 1 paired with rows on both sides) shows the net only.
 */
export function fineJvGridOfRows(rows: SourceRow[], voucherNo: string): FineJvGridLine[] {
  const side = (row: SourceRow): 'DR' | 'CR' =>
    text(row.CRDR_TYPE).toUpperCase() === 'CR' ? 'CR' : 'DR';
  const groups = (ldrType: string) => {
    const byKey = new Map<string, { head: SourceRow; cr: number; dr: number }>();
    for (const row of rows.filter((r) => text(r.LDR_TYPE) === ldrType)) {
      const key = JSON.stringify([
        text(row.AC_CODE),
        text(row.AC_NAME),
        side(row),
        text(row.IT_DESC),
      ]);
      const group = byKey.get(key) ?? { head: row, cr: 0, dr: 0 };
      group.cr += num(row.CR_FINE);
      group.dr += num(row.DR_FINE);
      byKey.set(key, group);
    }
    return [...byKey.values()];
  };
  const mirrors = groups('1');
  const counters = groups('0');
  if (
    mirrors.length !== 1 ||
    !counters.length ||
    rows.some((r) => !['0', '1'].includes(text(r.LDR_TYPE)))
  )
    throw new FineJvValidationError(
      `fine-jv voucher ${voucherNo} cannot be opened as a TR_CONTRA grid: its rows are not one row-1 account (LDR_TYPE 1) paired with counter rows (LDR_TYPE 0)`,
    );
  const head = mirrors[0]!;
  const crdr = side(head.head);
  const line = (group: { head: SourceRow; cr: number; dr: number }, fine: number) => ({
    crdr: side(group.head),
    acCode: text(group.head.AC_CODE),
    acName: text(group.head.AC_NAME),
    itDesc: text(group.head.IT_DESC),
    fine: r3(fine),
  });
  return [
    line(head, crdr === 'DR' ? head.dr - head.cr : head.cr - head.dr),
    ...counters.map((group) => line(group, group.cr || group.dr)),
  ];
}

export async function getFineJv(p: any, s: VoucherScope, x: number | string) {
  completeFinanceScope(s);
  const no = formatVoucherNo(x);
  return withTxBudget(p, s.tenantId, 'read', async (tx) => {
    const book = await fineJvBookTx(tx, s);
    const rows = await sourceRowsTx(tx, s, no);
    if (!rows.length) throw new FineJvNotFoundError(no);
    const header = rows[0]!;
    return {
      voucherNo: no,
      hiddenVoucherNo: text(header.HD_VCH_NO),
      mainUser: text(header.MAIN_USER),
      vchDate: toIsoDate(header.VCH_DATE),
      // TR_CONTRA.cs:2430-2437 selects Silver for IT_TYPE 'S', otherwise Gold.
      metal: text(header.IT_TYPE).toUpperCase() === 'S' ? 'S' : 'G',
      empCode: text(header.EMP_CODE),
      bookName: book.name,
      lines: fineJvGridOfRows(rows, no),
    };
  });
}

export async function editFineJv(p: any, i: FineJvInput, x: number | string) {
  completeFinanceScope(i.scope);
  const lines = fineJvLines(i.lines);
  const voucherNo = formatVoucherNo(x);
  return withTxBudget(p, i.scope.tenantId, 'voucher', (tx) =>
    withDesktopLockText(async () => {
      const book = await fineJvBookTx(tx, i.scope);
      const saved = await sourceRowsTx(tx, i.scope, voucherNo, true);
      if (!saved.length) throw new FineJvNotFoundError(voucherNo);
      const savedGrid = fineJvGridOfRows(saved, voucherNo);
      const header = saved[0]!;
      const date = i.vchDate ? new Date(i.vchDate) : new Date(toIsoDate(header.VCH_DATE));
      const metal = metalOf(i.metal ?? header.IT_TYPE);
      const empCode = i.empCode === undefined ? text(header.EMP_CODE) : text(i.empCode);
      await assertSaveAllowedTx(tx, i.scope, { creating: false, empCode, date, lines });
      // Web hardening: editIdentityTx also refuses a voucher whose SAVED date is locked.
      const { identity } = await editIdentityTx(tx, {
        table: 'CONTRA_DATA',
        scope: i.scope,
        requestedVoucherNo: voucherNo,
        requestedDate: date,
      });
      const resolved = await resolveGridTx(tx, i.scope, lines, savedGrid);
      await replaceWriteSetTx(
        tx,
        i.scope,
        identity.voucherNo,
        identity.hiddenVoucherNo,
        WRITE_TABLES,
      );
      return writeTx(tx, { scope: i.scope, book, identity, metal, empCode, ...resolved });
    }),
  );
}

export async function deleteFineJv(
  p: any,
  i: {
    scope: VoucherScope;
    vchNo: number | string;
    deleteUser?: string;
    book?: unknown;
  },
) {
  completeFinanceScope(i.scope);
  const s = i.scope,
    no = formatVoucherNo(i.vchNo);
  return withTxBudget(p, s.tenantId, 'voucher', (tx) =>
    withDesktopLockText(async () => {
      const book = await fineJvBookTx(tx, s);
      const rows: SourceRow[] = await tx.$queryRawUnsafe(
        `SELECT "SR_NO","AC_CODE","AC_NAME","DR_AMT","CR_AMT","DR_FINE","CR_FINE","IT_TYPE","IT_DESC" FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        s.coYear,
        s.coBook,
        no,
      );
      if (!rows.length) throw new FineJvNotFoundError(no);
      // TR_CONTRA.cs:2951 checks the lock against the voucher's own date only.
      const { persisted: header, identity } = await editIdentityTx(tx, {
        table: 'CONTRA_DATA',
        scope: s,
        requestedVoucherNo: no,
        requestedDate: new Date(),
        checkRequestedDate: false,
      });
      await reverseVoucherTx(tx, s.tenantId, {
        tables: [...DELETE_TABLES],
        key: voucherKey(s, no),
      });
      await tx.$executeRawUnsafe(
        `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        s.coBook,
        identity.hiddenVoucherNo,
      );
      await insertDesktopDeleteAuditTx(tx, {
        scope: s,
        configuredBook: book,
        header,
        rows: rows.map((r) => ({
          srNo: num(r.SR_NO),
          valueDr: num(r.DR_AMT),
          valueCr: num(r.CR_AMT),
          fineType: text(r.IT_TYPE) || 'A',
          fineDr: num(r.DR_FINE),
          fineCr: num(r.CR_FINE),
          // TR_CONTRA.cs:2961 audits SUBSTRING(IT_DESC,1,149).
          description: String(r.IT_DESC ?? '').slice(0, 149),
          acCode: r.AC_CODE,
          acName: r.AC_NAME,
        })),
        deleteUser: i.deleteUser,
      });
      return { reversed: true as const };
    }),
  );
}
