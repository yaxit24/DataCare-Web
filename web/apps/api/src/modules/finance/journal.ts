import { withTxBudget } from '../shared/txBudget.js';
import { buildJournalRojmel } from '../shared/rojmel.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import {
  assertBalanced,
  postVoucherTx,
  reverseVoucherTx,
  type LedgerLine,
} from '../posting/posting.js';
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

export class JournalValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'JournalValidationError';
  }
}
export interface JournalLineInput {
  acCode: string;
  drAmt?: number;
  crAmt?: number;
  desc?: string;
}
export interface JournalInput {
  scope: VoucherScope;
  vchDate?: Date | string;
  narration?: string;
  lines: JournalLineInput[];
  mainUser?: string;
}
export interface JournalResult {
  vchNo: number;
}
type Context = { tx: any; identity: VoucherIdentity };
// ROJ_MEL_DATA belongs here, not just in the write set: its primary key is LEDR_KEY alone, so an edit
// that rewrites the voucher without first deleting the old day-book rows fails on unique constraint
// 23505 rather than replacing them.
const WRITE_TABLES = ['CONTRA_DATA', 'AC_DATA', 'ROJ_MEL_DATA'] as const;
const finite = (v: unknown) => (Number.isFinite(Number(v ?? 0)) ? Number(v ?? 0) : 0);

async function writeJournalTx(
  tx: any,
  input: JournalInput,
  identity: VoucherIdentity,
): Promise<JournalResult> {
  const raw = input.lines ?? [];
  if (raw.length < 2) throw new JournalValidationError('journal voucher requires at least 2 lines');
  for (const line of raw) {
    const dr = finite(line.drAmt),
      cr = finite(line.crAmt);
    if (!text(line.acCode))
      throw new JournalValidationError('every journal line needs an account code');
    if (dr < 0 || cr < 0 || dr > 0 === cr > 0)
      throw new JournalValidationError(
        `line "${line.acCode}" must have exactly one of debit or credit`,
      );
  }
  completeFinanceScope(input.scope);
  const book = await configuredBookTx(tx, input.scope);
  const key = voucherKey(input.scope, identity.voucherNo);
  const narration = text(input.narration);
  const ledger: LedgerLine[] = raw.map((line) => {
    const dr = finite(line.drAmt),
      cr = finite(line.crAmt);
    return {
      ...key,
      VCH_TYPE: book.shortName,
      VCH_DATE: identity.voucherDate,
      AC_CODE: line.acCode,
      DR_AMT: dr,
      CR_AMT: cr,
      SIGN: dr > 0 ? 'D' : 'C',
      IT_DESC: text(line.desc) || narration,
    };
  });
  assertBalanced(ledger);
  const rows = raw.map((line, index) => {
    const dr = finite(line.drAmt),
      cr = finite(line.crAmt);
    return {
      ...key,
      SR_NO: index + 1,
      VCH_DATE: identity.voucherDate,
      VCH_TIME: identity.voucherTime,
      VCH_TYPE: book.shortName,
      BOOK_NAME: book.name,
      AC_CODE: line.acCode,
      DR_AMT: dr,
      CR_AMT: cr,
      CRDR_TYPE: dr > 0 ? 'D' : 'C',
      IT_DESC: text(line.desc) || narration,
      LDR_TYPE: '1',
      HD_VCH_NO: identity.hiddenVoucherNo,
      MAIN_USER: identity.mainUser || null,
      DATA_TRFR: 'N',
    };
  });
  // The Rojmel. Every one of the 74 real Rojmel rows on contra book 017 carries the same DR/CR as its
  // own AC_CODE's ledger leg (100%), and the same test gives 100% on the scheme's 1635 rows — so a
  // journal projects one day-book row per line. The cash books are excluded deliberately: the same
  // test matches only 47.2% of book 001 and 5.4% of book 002, so they use a convention not yet derived.
  const rojmelRows = buildJournalRojmel(
    {
      scope: {
        coCode: input.scope.coCode,
        lcCode: input.scope.lcCode,
        coYear: input.scope.coYear!,
      },
      key,
      coBook: key.CO_BOOK,
      vchNo: key.VCH_NO,
      vchDate: identity.voucherDate,
      vchType: book.shortName,
      bookName: book.name,
      partyName: '',
      partyCode: '',
    },
    raw.map((line, index) => ({
      lineNo: index + 1,
      acCode: line.acCode,
      drAmt: finite(line.drAmt),
      crAmt: finite(line.crAmt),
    })),
  );
  await insertHiddenIdentityTx(tx, input.scope, identity, book.name);
  await postVoucherTx(tx, input.scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: ledger },
    bookName: book.name,
    writes: [
      { table: 'CONTRA_DATA', rows },
      ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
    ],
  });
  return { vchNo: identity.vchNo };
}

export async function postJournal(
  prisma: any,
  input: JournalInput,
  ctx?: Context,
): Promise<JournalResult> {
  completeFinanceScope(input.scope);
  const date = input.vchDate ? new Date(input.vchDate) : new Date();
  input = { ...input, vchDate: date };
  if (ctx) return writeJournalTx(ctx.tx, input, ctx.identity);
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx) =>
    writeJournalTx(tx, input, await createIdentityTx(tx, input.scope, date, input.mainUser)),
  );
}
export async function getJournal(prisma: any, scope: VoucherScope, requested: number | string) {
  completeFinanceScope(scope);
  const voucherNo = formatVoucherNo(requested);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx) => {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"HD_VCH_NO","MAIN_USER","AC_CODE","DR_AMT","CR_AMT","IT_DESC" FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (!rows.length) throw new JournalValidationError(`journal voucher not found: ${voucherNo}`);
    return {
      voucherNo,
      hiddenVoucherNo: text(rows[0]!.HD_VCH_NO),
      mainUser: text(rows[0]!.MAIN_USER),
      vchDate: text(rows[0]!.VCH_DATE).slice(0, 10),
      narration: text(rows[0]!.IT_DESC),
      lines: rows.map((r) => ({
        acCode: text(r.AC_CODE),
        drAmt: num(r.DR_AMT),
        crAmt: num(r.CR_AMT),
        desc: text(r.IT_DESC),
      })),
    };
  });
}
export async function editJournal(prisma: any, input: JournalInput, requested: number | string) {
  completeFinanceScope(input.scope);
  const date = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx) => {
    const { identity } = await editIdentityTx(tx, {
      table: 'CONTRA_DATA',
      scope: input.scope,
      requestedVoucherNo: requested,
      requestedDate: date,
    });
    await replaceWriteSetTx(
      tx,
      input.scope,
      identity.voucherNo,
      identity.hiddenVoucherNo,
      WRITE_TABLES,
    );
    return writeJournalTx(tx, input, identity);
  });
}
export async function deleteJournal(
  prisma: any,
  input: {
    scope: VoucherScope;
    vchNo: number | string;
    deleteUser?: string;
    book?: unknown;
  },
) {
  completeFinanceScope(input.scope);
  const scope = input.scope,
    voucherNo = formatVoucherNo(input.vchNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx) => {
    const { persisted: header, identity } = await editIdentityTx(tx, {
      table: 'CONTRA_DATA',
      scope,
      requestedVoucherNo: voucherNo,
      requestedDate: new Date(),
    });
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","AC_CODE","AC_NAME","DR_AMT","CR_AMT","DR_FINE","CR_FINE","IT_TYPE","IT_DESC" FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    const book = await configuredBookTx(tx, scope);
    await reverseVoucherTx(tx, scope.tenantId, {
      tables: [...WRITE_TABLES],
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
      rows: rows.map((r) => ({
        srNo: num(r.SR_NO),
        valueDr: num(r.DR_AMT),
        valueCr: num(r.CR_AMT),
        fineType: text(r.IT_TYPE) || 'A',
        fineDr: num(r.DR_FINE),
        fineCr: num(r.CR_FINE),
        description: text(r.IT_DESC),
        acCode: r.AC_CODE,
        acName: r.AC_NAME,
      })),
      deleteUser: input.deleteUser,
    });
    return { reversed: true as const };
  });
}
