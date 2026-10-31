import { withTxBudget } from '../shared/txBudget.js';
import { buildJournalRojmel } from '../shared/rojmel.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import {
  postVoucherTx,
  reverseVoucherTx,
  assertBalanced,
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
  voucherKey,
  type VoucherIdentity,
} from './lifecycle.js';
import { FinanceValidationError, type FinanceResult } from './finance.js';

/**
 * Contra Entry (desktop TR_CONTRA).
 *
 * The desktop grid holds any number of rows. Row 1 is the main account (DR by default, TR_CONTRA.cs:1530-1545); every
 * further row i writes a PAIR of CONTRA_DATA rows (TR_CONTRA.cs:2760-2866): LDR_TYPE '0' with row i's account and
 * amount against row 1 (LD_CODE = row 1's account), and LDR_TYPE '1' with row 1's account and the amount on the other
 * side against row i. Contra_Ledr (Ac_Ledr.cs:840-) posts each row as one leg keyed STR(SR_NO)+'01' (credit) or
 * +'02' (debit). Unequal totals are refused with the desktop message (TR_CONTRA.cs:2694). Reopen rebuilds the grid
 * from the LDR_TYPE '1' rows (row 1) and the LDR_TYPE '0' rows (the others), as TR_CONTRA.cs:2467 and :2541 do.
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
  /** The grid, row 1 first. */
  lines?: ContraLine[];
  /** The earlier two-account form: Dr `toAc`, Cr `fromAc` (kept for existing callers). */
  fromAc?: string;
  toAc?: string;
  toAcName?: string;
  amount?: number;
  /** Item type selector (TR_CONTRA.cs:2786 cboItemTyp first character); 'A' = amount. */
  itemType?: string;
  empCode?: string;
  vchDate?: Date | string;
  itDesc?: string;
  mainUser?: string;
}

/** The contra write set = reversal set; the day book is reversed with the rest (F3.3). */
const CONTRA_WRITE_TABLES = ['CONTRA_DATA', 'AC_DATA', 'ROJ_MEL_DATA'] as const;

const numv = (v: unknown): number => Number(v ?? 0);
const paise = (n: number): number => Math.round(n * 100);

/** The grid of a request: `lines`, or the two-account form as row 1 DR `toAc` and row 2 CR `fromAc`. */
export function contraLines(input: ContraInput): ContraLine[] {
  const raw: ContraLine[] = input.lines?.length
    ? input.lines
    : [
        {
          crdr: 'DR',
          acCode: input.toAc ?? '',
          acName: input.toAcName,
          amount: Number(input.amount ?? 0),
        },
        { crdr: 'CR', acCode: input.fromAc ?? '', amount: Number(input.amount ?? 0) },
      ];
  // TR_CONTRA.cs:2764 skips a row with no account or no amount.
  const lines = raw
    .map((line) => ({
      crdr: String(line.crdr ?? '').toUpperCase() === 'CR' ? ('CR' as const) : ('DR' as const),
      acCode: String(line.acCode ?? '').trim(),
      acName: line.acName ? String(line.acName) : undefined,
      itDesc: line.itDesc ? String(line.itDesc) : undefined,
      amount: Number(line.amount ?? 0),
    }))
    .filter((line) => line.acCode && Number.isFinite(line.amount) && line.amount !== 0);
  if (lines.length < 2 || lines.some((line) => line.amount < 0))
    throw new FinanceValidationError('a contra needs at least two accounts with positive amounts');
  const dr = lines.filter((l) => l.crdr === 'DR').reduce((sum, l) => sum + paise(l.amount), 0);
  const cr = lines.filter((l) => l.crdr === 'CR').reduce((sum, l) => sum + paise(l.amount), 0);
  if (dr !== cr) throw new FinanceValidationError(DESKTOP_MESSAGES.CONTRA_DR_CR_NOT_SAME);
  return lines;
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
        IT_DESC: row.itDesc ?? null,
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

type ContraWriteContext = { tx: any; identity: VoucherIdentity };

export async function postContra(
  prisma: any,
  input: ContraInput,
  lifecycle?: ContraWriteContext,
): Promise<FinanceResult> {
  const lines = contraLines(input);
  completeFinanceScope(input.scope);
  const tenantId = input.scope.tenantId;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const write = async (tx: any, identity: VoucherIdentity): Promise<FinanceResult> => {
    const vchNo = identity.vchNo;
    const key = {
      CO_CODE: input.scope.coCode,
      LC_CODE: input.scope.lcCode,
      CO_YEAR: input.scope.coYear ?? '',
      CO_BOOK: input.scope.coBook ?? 'CON',
      VCH_NO: formatVoucherNo(vchNo),
    };
    const book = await configuredBookTx(tx, input.scope);
    const rows = contraRows(lines);
    const ledger = contraLedger(key, book.shortName, rows, vchDate);
    assertBalanced(ledger);
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
    );
    await insertHiddenIdentityTx(tx, input.scope, identity, book.name);
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: book.name,
      writes: [
        {
          table: 'CONTRA_DATA',
          rows: rows.map((row) => ({
            ...key,
            ...row,
            VCH_TYPE: book.shortName,
            EMP_CODE: input.empCode ?? null,
            DATA_TRFR: 'N',
            // TR_CONTRA.cs:2786-2788 — a money transfer carries no metal: zero fine, item type 'A'.
            DR_FINE: 0,
            CR_FINE: 0,
            IT_TYPE: input.itemType ?? 'A',
            IT_DESC: row.IT_DESC ?? input.itDesc ?? null,
            VCH_DATE: vchDate,
            VCH_TIME: identity.voucherTime,
            HD_VCH_NO: identity.hiddenVoucherNo,
            MAIN_USER: identity.mainUser || null,
            BOOK_NAME: book.name,
            INOUT_TYPE: 'I',
            ENTRY_TYPE: 'J',
          })),
        },
        ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
      ],
    });
    return { vchNo };
  };
  if (lifecycle) return write(lifecycle.tx, lifecycle.identity);
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) =>
    write(tx, await createIdentityTx(tx, input.scope, vchDate, input.mainUser)),
  );
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
      amount: Math.round((crdr === 'DR' ? dr - cr : cr - dr) * 100) / 100,
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
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"HD_VCH_NO","MAIN_USER","SR_NO","LDR_TYPE","CRDR_TYPE","AC_CODE","AC_NAME",
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
      vchDate: text(h.VCH_DATE).slice(0, 10),
      lines,
      // The two-account form, for a two-row contra.
      toAc: two ? (lines.find((l) => l.crdr === 'DR')?.acCode ?? '') : '',
      fromAc: two ? (lines.find((l) => l.crdr === 'CR')?.acCode ?? '') : '',
      amount: two ? lines[0]!.amount : 0,
      itDesc: text(h.IT_DESC),
    };
  });
}

export async function editContra(
  prisma: any,
  input: ContraInput,
  requestedVoucherNo: number | string,
) {
  contraLines(input); // refuse before touching the saved voucher
  completeFinanceScope(input.scope);
  const requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    const { identity } = await editIdentityTx(tx, {
      table: 'CONTRA_DATA',
      scope: input.scope,
      requestedVoucherNo,
      requestedDate,
    });
    await replaceWriteSetTx(
      tx,
      input.scope,
      identity.voucherNo,
      identity.hiddenVoucherNo,
      CONTRA_WRITE_TABLES,
    );
    return postContra(prisma, input, { tx, identity });
  });
}

export async function deleteContra(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string; book?: unknown },
) {
  completeFinanceScope(input.scope);
  const scope = input.scope;
  const voucherNo = formatVoucherNo(input.vchNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    // A contra has a row per grid row (TR_CONTRA.cs:2760-2866), so only the shared identity columns are locked as
    // the header; the audit takes the row columns from SR_NO 1.
    const { persisted, identity } = await editIdentityTx(tx, {
      table: 'CONTRA_DATA',
      scope,
      requestedVoucherNo: voucherNo,
      requestedDate: new Date(),
    });
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
    const book = await configuredBookTx(tx, scope);
    await reverseVoucherTx(tx, scope.tenantId, {
      tables: [...CONTRA_WRITE_TABLES],
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
      })),
      deleteUser: input.deleteUser,
    });
    return { reversed: true as const };
  });
}
