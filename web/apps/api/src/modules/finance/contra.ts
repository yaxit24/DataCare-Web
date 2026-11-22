import { round, toIsoDate } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { buildJournalRojmel } from '../shared/rojmel.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import {
  postVoucherTx,
  reverseVoucherTx,
  assertBalanced,
  assertPeriodOpen,
  type LedgerLine,
} from '../posting/posting.js';
import {
  assertVoucherVersionTx,
  requiredVersion,
  versionKeyOf,
  voucherVersionTx,
} from '../vouchers/version.js';
import {
  completeFinanceScope,
  configuredBookTx,
  createIdentityTx,
  editIdentityTx,
  financeEmployeeTx,
  insertDesktopDeleteAuditTx,
  insertHiddenIdentityTx,
  replaceWriteSetTx,
  requireBookFamily,
  text,
  voucherKey,
  type VoucherIdentity,
  assertFinanceVoucherDateTx,
  FinanceLifecycleValidationError,
} from './lifecycle.js';
import { FinanceValidationError, type FinanceResult } from './finance.js';
import { captureClearingTx, dropClearingTx, restoreClearingTx } from './contraClearing.js';

/**
 * Contra Entry (desktop TR_CONTRA).
 *
 * The desktop grid holds any number of rows. Row 1 is the main account (DR by default, TR_CONTRA.cs:1530-1545) and
 * every later row takes the opposite side (TR_CONTRA.cs:1538, :1630); each further row i writes a PAIR of CONTRA_DATA
 * rows (TR_CONTRA.cs:2760-2866): LDR_TYPE '0' with row i's account and amount against row 1 (LD_CODE = row 1's
 * account), and LDR_TYPE '1' with row 1's account, row 1's description (TR_CONTRA.cs:2868) and the amount on the other
 * side against row i. Contra_Ledr (Ac_Ledr.cs:840-) posts each row as one leg keyed STR(SR_NO)+'01' (credit) or
 * +'02' (debit), Contra_Rojmel (Ac_Rojmel.cs:336-) one day-book row per CONTRA_DATA row, and Vch_Remark (Ac_Tax.cs:686)
 * one REMARK_DATA row per described row. Unequal totals are refused with the desktop message (TR_CONTRA.cs:2694).
 * Reopen rebuilds the grid from the LDR_TYPE '1' rows (row 1) and the LDR_TYPE '0' rows (the others), as
 * TR_CONTRA.cs:2467 and :2541 do.
 *
 * The hosted service adds (decisions D1-D16 in orchestration/work/WP-31/cases.md): all legs or none in one
 * transaction; the voucher version token on edit and delete; the clearing marks of a bank leg follow the leg; an
 * account that is not in the company, an amount without an account and a negative amount are refused.
 */
export interface ContraLine {
  crdr: 'DR' | 'CR';
  acCode: string;
  acName?: string;
  itDesc?: string;
  amount: number;
}

export interface ContraInput {
  scope: VoucherScope;
  /** The TR_CONTRA grid, row 1 first (TR_CONTRA.cs:1530-1545, :2760-2866). */
  lines: ContraLine[];
  empCode?: string;
  vchDate?: Date | string;
  mainUser?: string;
  /** The version the operator's copy was read with (edit only). */
  expectedVersion?: string;
}

/** The voucher write set = the version set = the reversal set; the day book is reversed with the rest (F3.3). */
export const CONTRA_WRITE_TABLES = [
  'CONTRA_DATA',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'REMARK_DATA',
] as const;
/** TR_CONTRA.cs:2963-2968 also removes the approval detail rows on delete. */
const CONTRA_DELETE_TABLES = [...CONTRA_WRITE_TABLES, 'APR_IDTL'] as const;

export const CONTRA_MESSAGES = {
  SAME_SIDE: 'A contra row after the first must take the opposite side of row 1',
  COMPANY_TYPE_B: 'You Cant Save This Voucher Becouse This Company Type is B......',
  accountRequired: (row: number) => `Account code is required on row ${row}`,
  negative: (row: number) => `Amount cannot be negative on row ${row}`,
  noAccount: (code: string) => `Account code ${code} is not in this company`,
} as const;

const numv = (v: unknown): number => Number(v ?? 0);

/**
 * The grid of a request (the desktop screen has no other form of entry).
 *
 * Row 1 is positional and is never dropped. A later row with no account and no amount is skipped
 * (TR_CONTRA.cs:2765). Every cell holds `Format(Val(text), "0.00")` (TR_CONTRA.cs:1695), so amounts are rounded to two
 * decimals first. Checks, in this order: totals (TR_CONTRA.cs:2692, with an empty grid counted as unequal: D1), sides,
 * negative amounts, accounts.
 */
export function contraLines(input: Pick<ContraInput, 'lines'>): ContraLine[] {
  const raw: any[] = Array.isArray(input.lines) ? input.lines : [];
  const grid = raw.map((line, index) => ({
    row: index + 1,
    crdr: String(line?.crdr ?? '').toUpperCase() === 'CR' ? ('CR' as const) : ('DR' as const),
    acCode: String(line?.acCode ?? '').trim(),
    acName: line?.acName ? String(line.acName) : undefined,
    itDesc: line?.itDesc ? String(line.itDesc) : undefined,
    amount: round(Number(line?.amount ?? 0) || 0, 2),
  }));
  const filled = grid.filter((line, index) => index === 0 || line.acCode || line.amount !== 0);
  const total = (side: 'DR' | 'CR') =>
    round(
      filled.filter((l) => l.crdr === side).reduce((sum, l) => sum + l.amount, 0),
      2,
    );
  if (filled.every((l) => l.amount === 0) || total('DR') !== total('CR'))
    throw new FinanceValidationError(DESKTOP_MESSAGES.CONTRA_DR_CR_NOT_SAME);
  if (filled.slice(1).some((l) => l.crdr === filled[0]!.crdr))
    throw new FinanceValidationError(CONTRA_MESSAGES.SAME_SIDE);
  for (const l of filled)
    if (l.amount < 0) throw new FinanceValidationError(CONTRA_MESSAGES.negative(l.row));
  for (const l of filled)
    if (!l.acCode) throw new FinanceValidationError(CONTRA_MESSAGES.accountRequired(l.row));
  return filled
    .filter((l, index) => index === 0 || l.amount !== 0)
    .map(({ row: _row, ...line }) => line);
}

/** The desktop CONTRA_DATA rows of a grid (TR_CONTRA.cs:2760-2866), SR_NO from 1. */
export function contraRows(lines: ContraLine[]) {
  const first = lines[0]!;
  return lines.slice(1).flatMap((row, index) => {
    const amountOn = (side: 'DR' | 'CR', crdr: 'DR' | 'CR') => (crdr === side ? row.amount : 0);
    const other = row.crdr === 'DR' ? 'CR' : 'DR';
    return [
      {
        SR_NO: index * 2 + 1,
        LDR_TYPE: '0',
        CRDR_TYPE: row.crdr,
        AC_CODE: row.acCode,
        LD_CODE: first.acCode,
        AC_NAME: row.acName ?? null,
        DR_AMT: amountOn('DR', row.crdr),
        CR_AMT: amountOn('CR', row.crdr),
        IT_DESC: row.itDesc ?? null,
      },
      {
        SR_NO: index * 2 + 2,
        LDR_TYPE: '1',
        CRDR_TYPE: first.crdr,
        AC_CODE: first.acCode,
        LD_CODE: row.acCode,
        AC_NAME: first.acName ?? null,
        DR_AMT: amountOn('DR', other),
        CR_AMT: amountOn('CR', other),
        // TR_CONTRA.cs:2868: the mirror record carries ROW 1's description, not row i's.
        IT_DESC: first.itDesc ?? null,
      },
    ];
  });
}

/** Contra_Ledr (Ac_Ledr.cs:840-): one leg per row, STR(SR_NO)+'01' for a credit, +'02' for a debit. */
export function contraLedger(
  key: Record<string, unknown>,
  vchType: string,
  rows: ReturnType<typeof contraRows>,
  vchDate: Date,
): LedgerLine[] {
  return rows.map((row) => ({
    ...key,
    VCH_TYPE: vchType,
    VCH_DATE: vchDate,
    legKeySuffix: `${row.SR_NO}${row.CR_AMT !== 0 ? '01' : '02'}`.padStart(12, ' '),
    AC_CODE: row.AC_CODE,
    LD_CODE: row.LD_CODE,
    DR_AMT: row.DR_AMT,
    CR_AMT: row.CR_AMT,
    IT_TYPE: 'A',
    IT_DESC: row.IT_DESC ?? '',
  }));
}

/**
 * Serialise writers of one voucher. The header rows are deleted and rewritten by every edit, so a row lock taken by a
 * waiting writer would find nothing once the first one commits and report "not found" instead of the version conflict.
 */
async function lockVoucherTx(tx: any, scope: VoucherScope, voucherNo: string): Promise<void> {
  const key = [scope.tenantId, scope.coCode, scope.lcCode, scope.coYear, scope.coBook, voucherNo];
  await tx.$executeRawUnsafe(
    `SELECT pg_advisory_xact_lock(hashtextextended($1::text, 0))`,
    `contra:${key.join('|')}`,
  );
}

/** TR_CONTRA.cs:2675: a new voucher is refused when the company type is B. */
async function assertCompanyNotTypeBTx(tx: any, scope: VoucherScope): Promise<void> {
  const types: Array<{ type: string }> = await tx.$queryRawUnsafe(
    `SELECT DISTINCT upper(btrim(coalesce("CO_TYPE"::text,''))) "type"
       FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text`,
    scope.tenantId,
    scope.coCode,
  );
  if (types.some((row) => row.type === 'B'))
    throw new FinanceLifecycleValidationError(CONTRA_MESSAGES.COMPANY_TYPE_B);
}

/** Every grid account must be an AC_MAST account of the company; returns code → master name. */
async function accountNamesTx(
  tx: any,
  scope: VoucherScope,
  lines: ContraLine[],
): Promise<Map<string, string>> {
  const codes = [...new Set(lines.map((l) => l.acCode))];
  const found: Array<{ code: string; name: string | null }> = await tx.$queryRawUnsafe(
    `SELECT DISTINCT ON (btrim("AC_CODE")) btrim("AC_CODE") code, "AC_NAME" name FROM "AC_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND btrim("AC_CODE")=ANY($3::text[])
      ORDER BY btrim("AC_CODE"), CASE WHEN "LC_CODE"=$4 THEN 0 ELSE 1 END, row_id`,
    scope.tenantId,
    scope.coCode,
    codes,
    scope.lcCode,
  );
  const names = new Map(found.map((r) => [r.code, text(r.name)]));
  const missing = codes.find((code) => !names.has(code));
  if (missing) throw new FinanceValidationError(CONTRA_MESSAGES.noAccount(missing));
  return names;
}

/**
 * The save checks in the desktop's order (TR_CONTRA.cs:2666-2697) that precede the writes: employee, company type B
 * (new voucher), the open year, the lock date, then the grid. Returns the grid and the employee code to store.
 */
async function checkedGridTx(
  tx: any,
  input: ContraInput,
  options: { creating: boolean; vchDate: Date },
): Promise<{ lines: ContraLine[]; empCode: string }> {
  const scope = completeFinanceScope(input.scope);
  const empCode = await financeEmployeeTx(tx, scope, input.empCode);
  if (options.creating) await assertCompanyNotTypeBTx(tx, scope);
  await assertFinanceVoucherDateTx(tx, scope, options.vchDate);
  await assertPeriodOpen(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: options.vchDate }] },
  });
  const checked = contraLines(input);
  const names = await accountNamesTx(tx, scope, checked);
  return {
    empCode,
    lines: checked.map((l) => ({ ...l, acName: l.acName || names.get(l.acCode) || undefined })),
  };
}

/** Every table of one voucher: CONTRA_DATA pairs, the AC_DATA legs, the day book and REMARK_DATA. */
async function writeContraTx(
  tx: any,
  input: ContraInput,
  ctx: {
    lines: ContraLine[];
    empCode: string;
    identity: VoucherIdentity;
    book: Awaited<ReturnType<typeof configuredBookTx>>;
    vchDate: Date;
  },
): Promise<number> {
  const { identity, book, vchDate, lines } = ctx;
  const scope = completeFinanceScope(input.scope);
  const key = {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear,
    CO_BOOK: scope.coBook,
    VCH_NO: formatVoucherNo(identity.vchNo),
  };
  const rows = contraRows(lines);
  const ledger = contraLedger(key, book.shortName, rows, vchDate);
  assertBalanced(ledger);
  const rojmelRows = buildJournalRojmel(
    {
      scope: { coCode: scope.coCode, lcCode: scope.lcCode, coYear: scope.coYear },
      key,
      coBook: key.CO_BOOK,
      vchNo: key.VCH_NO,
      vchDate,
      vchType: book.shortName,
      bookName: book.name,
      // A contra moves money between the shop's own accounts, so there is no party to denormalise.
      partyName: '',
      partyCode: '',
    },
    rows.map((row) => ({
      lineNo: row.SR_NO,
      acCode: row.AC_CODE,
      drAmt: row.DR_AMT,
      crAmt: row.CR_AMT,
    })),
  ).map((roj, index) => ({
    ...roj,
    // Ac_Rojmel.Contra_Rojmel copies each CONTRA_DATA row's own LD_CODE, AC_NAME and IT_DESC (Ac_Rojmel.cs:338-340).
    LD_CODE: rows[index]!.LD_CODE,
    AC_NAME: rows[index]!.AC_NAME,
    IT_DESC: rows[index]!.IT_DESC ?? '',
  }));
  await insertHiddenIdentityTx(tx, scope, identity, book.name);
  await postVoucherTx(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: ledger },
    bookName: book.name,
    writes: [
      {
        table: 'CONTRA_DATA',
        rows: rows.map((row) => ({
          ...key,
          ...row,
          VCH_TYPE: book.shortName,
          EMP_CODE: ctx.empCode || null,
          DATA_TRFR: 'N',
          USER_UPDATE: 'N',
          USER_DELETE: 'N',
          // TR_CONTRA.cs:2786-2794 — a money transfer carries no metal: zero fine, item type 'A'.
          DR_FINE: 0,
          CR_FINE: 0,
          IT_TYPE: 'A',
          VCH_DATE: vchDate,
          VCH_TIME: identity.voucherTime,
          HD_VCH_NO: identity.hiddenVoucherNo,
          MAIN_USER: identity.mainUser || null,
          BOOK_NAME: book.name,
          // TR_CONTRA.cs:2774: the book's own in/out flag.
          INOUT_TYPE: book.inout || null,
          ENTRY_TYPE: 'J',
        })),
      },
      ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
      // Ac_Tax.Vch_Remark mode 3 (Ac_Tax.cs:686): one row per CONTRA_DATA row whose description is not empty.
      ...(rows.some((row) => text(row.IT_DESC))
        ? [
            {
              table: 'REMARK_DATA',
              rows: rows
                .filter((row) => text(row.IT_DESC))
                .map((row) => ({
                  ...key,
                  SR_NO: row.SR_NO,
                  VCH_DATE: vchDate,
                  AC_CODE: row.AC_CODE,
                  AC_NAME: row.AC_NAME,
                  MAIN_BOOK: book.mainBook,
                  VCH_REMARK: row.IT_DESC,
                })),
            },
          ]
        : []),
    ],
  });
  return identity.vchNo;
}

export async function postContra(prisma: any, input: ContraInput): Promise<FinanceResult> {
  completeFinanceScope(input.scope);
  const scope = completeFinanceScope(input.scope);
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const book = await configuredBookTx(tx, scope);
    requireBookFamily(book, 'CONTRA', 'contra');
    const checked = await checkedGridTx(tx, input, { creating: true, vchDate });
    const identity = await createIdentityTx(tx, scope, vchDate, input.mainUser);
    const vchNo = await writeContraTx(tx, input, { ...checked, identity, book, vchDate });
    return {
      vchNo,
      version: await voucherVersionTx(
        tx,
        CONTRA_WRITE_TABLES,
        versionKeyOf(scope, formatVoucherNo(vchNo)),
      ),
    } as FinanceResult;
  });
}

/** Rebuild the grid from the saved rows (TR_CONTRA.cs:2467 row 1 from LDR_TYPE '1', :2541 the others). */
export function gridOfRows(rows: Array<Record<string, unknown>>): ContraLine[] {
  const mirrors = rows.filter((r) => text(r.LDR_TYPE) === '1');
  const counters = rows.filter((r) => text(r.LDR_TYPE) === '0');
  if (!counters.length && rows.length === 1) {
    // A contra saved by the earlier web writer: one row, Dr AC_CODE and Cr LD_CODE of the same amount.
    const r = rows[0]!;
    const amount = numv(r.DR_AMT) || numv(r.CR_AMT);
    return [
      { crdr: 'DR', acCode: text(r.AC_CODE), acName: text(r.AC_NAME) || undefined, amount },
      { crdr: 'CR', acCode: text(r.LD_CODE), amount },
    ];
  }
  const head = mirrors[0];
  const crdr = text(head?.CRDR_TYPE).toUpperCase() === 'CR' ? 'CR' : 'DR';
  const dr = mirrors.reduce((sum, r) => sum + numv(r.DR_AMT), 0);
  const cr = mirrors.reduce((sum, r) => sum + numv(r.CR_AMT), 0);
  return [
    {
      crdr,
      acCode: text(head?.AC_CODE),
      acName: text(head?.AC_NAME) || undefined,
      // TR_CONTRA.cs:2868 stores row 1's description on every mirror record.
      itDesc: text(head?.IT_DESC) || undefined,
      amount: round(crdr === 'DR' ? dr - cr : cr - dr, 2),
    },
    ...counters.map((r) => ({
      crdr: (text(r.CRDR_TYPE).toUpperCase() === 'CR' ? 'CR' : 'DR') as 'DR' | 'CR',
      acCode: text(r.AC_CODE),
      acName: text(r.AC_NAME) || undefined,
      itDesc: text(r.IT_DESC) || undefined,
      amount: numv(r.DR_AMT) || numv(r.CR_AMT),
    })),
  ];
}

export async function getContra(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
) {
  completeFinanceScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    requireBookFamily(await configuredBookTx(tx, scope), 'CONTRA', 'contra');
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"HD_VCH_NO","MAIN_USER","EMP_CODE","SR_NO","LDR_TYPE","CRDR_TYPE","AC_CODE","AC_NAME",
              "LD_CODE","DR_AMT","CR_AMT","IT_DESC"
         FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (!rows.length) throw new FinanceValidationError(`contra voucher not found: ${voucherNo}`);
    const h = rows[0]!;
    const lines = gridOfRows(rows);
    const two = lines.length === 2;
    return {
      voucherNo,
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      empCode: text(h.EMP_CODE),
      vchDate: toIsoDate(h.VCH_DATE), // N56 (D19)
      lines,
      // The two-account form, for a two-row contra.
      toAc: two ? (lines.find((l) => l.crdr === 'DR')?.acCode ?? '') : '',
      fromAc: two ? (lines.find((l) => l.crdr === 'CR')?.acCode ?? '') : '',
      amount: two ? lines[0]!.amount : 0,
      // D7: sent back as expectedVersion by the edit and the delete.
      version: await voucherVersionTx(tx, CONTRA_WRITE_TABLES, versionKeyOf(scope, voucherNo)),
    };
  });
}

export async function editContra(
  prisma: any,
  input: ContraInput,
  requestedVoucherNo: number | string,
) {
  const scope = completeFinanceScope(input.scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const book = await configuredBookTx(tx, scope);
    requireBookFamily(book, 'CONTRA', 'contra');
    const expected = requiredVersion(input.expectedVersion);
    await lockVoucherTx(tx, scope, voucherNo);
    // The date of an edit is the one on the form; a client that sends none keeps the saved date (D9).
    let vchDate: Date;
    if (input.vchDate) vchDate = new Date(input.vchDate);
    else {
      const saved: Array<{ d: string }> = await tx.$queryRawUnsafe(
        `SELECT "VCH_DATE"::text d FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 LIMIT 1`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        scope.coBook,
        voucherNo,
      );
      if (!saved.length)
        throw new FinanceLifecycleValidationError(`voucher not found: ${voucherNo}`);
      vchDate = new Date(toIsoDate(saved[0]!.d));
    }
    // TR_CONTRA.cs:2680-2691 checks the year before the lock date that editIdentityTx enforces.
    await assertFinanceVoucherDateTx(tx, scope, vchDate);
    const { identity } = await editIdentityTx(tx, {
      table: 'CONTRA_DATA',
      scope,
      requestedVoucherNo: voucherNo,
      requestedDate: vchDate,
    });
    // The header rows are locked: the version is read and compared inside the same transaction.
    await assertVoucherVersionTx(tx, CONTRA_WRITE_TABLES, versionKeyOf(scope, voucherNo), expected);
    // A client that omits the employee keeps the saved one (lossless reopen); '' clears it.
    let withEmp = input;
    if (input.empCode === undefined) {
      const saved: Array<{ e: string | null }> = await tx.$queryRawUnsafe(
        `SELECT "EMP_CODE" e FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" LIMIT 1`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        scope.coBook,
        voucherNo,
      );
      withEmp = { ...input, empCode: text(saved[0]?.e) };
    }
    const checked = await checkedGridTx(tx, withEmp, { creating: false, vchDate });
    const marks = await captureClearingTx(tx, scope, voucherNo);
    await dropClearingTx(tx, scope, voucherNo);
    await replaceWriteSetTx(
      tx,
      scope,
      identity.voucherNo,
      identity.hiddenVoucherNo,
      CONTRA_WRITE_TABLES,
    );
    const vchNo = await writeContraTx(tx, input, { ...checked, identity, book, vchDate });
    await restoreClearingTx(tx, scope, voucherNo, marks);
    return {
      vchNo,
      version: await voucherVersionTx(tx, CONTRA_WRITE_TABLES, versionKeyOf(scope, voucherNo)),
    };
  });
}

export async function deleteContra(
  prisma: any,
  input: {
    scope: VoucherScope;
    vchNo: number | string;
    deleteUser?: string;
    expectedVersion?: unknown;
    book?: unknown;
  },
) {
  completeFinanceScope(input.scope);
  const scope = input.scope;
  const voucherNo = formatVoucherNo(input.vchNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const book = await configuredBookTx(tx, scope);
    requireBookFamily(book, 'CONTRA', 'contra');
    const expected = requiredVersion(input.expectedVersion);
    await lockVoucherTx(tx, scope, voucherNo);
    // A contra has a row per grid row (TR_CONTRA.cs:2760-2866), so only the shared identity columns are locked as
    // the header; the audit takes the row columns from SR_NO 1. The desktop checks the lock date of the SAVED
    // voucher on delete (TR_CONTRA.cs:2951) and has no year check there.
    const { persisted, identity } = await editIdentityTx(tx, {
      table: 'CONTRA_DATA',
      scope,
      requestedVoucherNo: voucherNo,
      requestedDate: new Date(),
      checkRequestedDate: false,
    });
    await assertVoucherVersionTx(tx, CONTRA_WRITE_TABLES, versionKeyOf(scope, voucherNo), expected);
    const details: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","AC_CODE","AC_NAME","DR_AMT","CR_AMT","DR_FINE","CR_FINE","IT_TYPE","IT_DESC" FROM "CONTRA_DATA"
       WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    const header = { ...persisted, ...details[0] };
    await dropClearingTx(tx, scope, voucherNo);
    await reverseVoucherTx(tx, scope.tenantId, {
      tables: [...CONTRA_DELETE_TABLES],
      key: voucherKey(scope, voucherNo),
    });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coBook,
      identity.hiddenVoucherNo,
    );
    await insertDesktopDeleteAuditTx(tx, {
      scope,
      configuredBook: book,
      header,
      rows: details.map((r) => ({
        srNo: numv(r.SR_NO),
        valueDr: numv(r.DR_AMT),
        valueCr: numv(r.CR_AMT),
        fineType: text(r.IT_TYPE) || 'A',
        fineDr: numv(r.DR_FINE),
        fineCr: numv(r.CR_FINE),
        description: text(r.IT_DESC),
        acCode: r.AC_CODE,
        acName: r.AC_NAME,
      })),
      deleteUser: input.deleteUser,
    });
    return { reversed: true as const };
  });
}
