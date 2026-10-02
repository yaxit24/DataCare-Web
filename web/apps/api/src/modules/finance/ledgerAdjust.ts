import { withTxBudget } from '../shared/txBudget.js';
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
  insertHiddenIdentityTx,
  replaceWriteSetTx,
  text,
  num,
  voucherKey,
  type VoucherIdentity,
} from './lifecycle.js';
export class LedgerAdjustValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'LedgerAdjustValidationError';
  }
}
export interface LedgerAdjustInput {
  scope: VoucherScope;
  acCode: string;
  adjAc?: string;
  amount: number;
  direction: 'debit' | 'credit';
  remark?: string;
  vchDate?: Date | string;
  mainUser?: string;
}
export interface LedgerAdjustResult {
  vchNo: number;
}
const TABLES = ['LDR_ADJ_DATA', 'AC_DATA'] as const;
const r2 = (n: number) => Math.round((n + Number.EPSILON) * 100) / 100;
/** Pure input guards, run before any DB access (desktop rejects these first and
 * apps/api/test/financeWriters.test.ts pins that ordering). */
export function assertLedgerAdjustInput(input: LedgerAdjustInput): void {
  const ac = text(input.acCode),
    adj = text(input.adjAc) || 'KASAR',
    amount = r2(num(input.amount));
  if (!ac) throw new LedgerAdjustValidationError('account code is required');
  if (ac === adj)
    throw new LedgerAdjustValidationError('adjustment account must differ from the account');
  if (!(amount > 0)) throw new LedgerAdjustValidationError('amount must be positive');
}
async function write(
  tx: any,
  input: LedgerAdjustInput,
  id: VoucherIdentity,
): Promise<LedgerAdjustResult> {
  completeFinanceScope(input.scope);
  const ac = text(input.acCode),
    adj = text(input.adjAc) || 'KASAR',
    amount = r2(num(input.amount)),
    dir = input.direction === 'credit' ? 'credit' : 'debit';
  const book = await configuredBookTx(tx, input.scope),
    key = voucherKey(input.scope, id.voucherNo),
    remark = text(input.remark) || 'Ledger adjustment',
    dr = dir === 'debit' ? ac : adj,
    cr = dir === 'debit' ? adj : ac;
  const ledger: LedgerLine[] = [
    {
      ...key,
      VCH_TYPE: book.shortName,
      VCH_DATE: id.voucherDate,
      AC_CODE: dr,
      DR_AMT: amount,
      CR_AMT: 0,
      SIGN: 'D',
      IT_DESC: remark,
    },
    {
      ...key,
      VCH_TYPE: book.shortName,
      VCH_DATE: id.voucherDate,
      AC_CODE: cr,
      DR_AMT: 0,
      CR_AMT: amount,
      SIGN: 'C',
      IT_DESC: remark,
    },
  ];
  assertBalanced(ledger);
  await insertHiddenIdentityTx(tx, input.scope, id, book.name);
  await postVoucherTx(tx, input.scope.tenantId, {
    bookName: book.name,
    ledger: { table: 'AC_DATA', lines: ledger },
    writes: [
      {
        table: 'LDR_ADJ_DATA',
        rows: [
          {
            ...key,
            SR_NO: 1,
            VCH_DATE: id.voucherDate,
            VCH_TIME: id.voucherTime,
            VCH_TYPE: book.shortName,
            INOUT_TYPE: dir === 'debit' ? 'I' : 'O',
            ENTRY_TYPE: 'A',
            BOOK_NAME: book.name,
            AC_CODE: ac,
            IT_TYPE: 'A',
            DR_AMT: dir === 'debit' ? amount : 0,
            CR_AMT: dir === 'credit' ? amount : 0,
            DIFF_AMT: amount,
            CR_FINE: 0,
            DR_FINE: 0,
            DIFF_FINE: 0,
            IT_REMARK: input.remark ?? null,
            ADJ_DATE: id.voucherDate,
            LEDR_OK: 'Y',
            HD_VCH_NO: id.hiddenVoucherNo,
            DATA_TRFR: 'N',
            MAIN_USER: id.mainUser || null,
          },
        ],
      },
    ],
  });
  return { vchNo: id.vchNo };
}
export async function postLedgerAdjust(prisma: any, input: LedgerAdjustInput) {
  assertLedgerAdjustInput(input);
  completeFinanceScope(input.scope);
  const date = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx) =>
    write(tx, input, await createIdentityTx(tx, input.scope, date, input.mainUser)),
  );
}
export async function getLedgerAdjust(
  prisma: any,
  scope: VoucherScope,
  requested: number | string,
) {
  completeFinanceScope(scope);
  const no = formatVoucherNo(requested);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx) => {
    const r: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"HD_VCH_NO","MAIN_USER","AC_CODE","DR_AMT","CR_AMT","DIFF_AMT","IT_REMARK" FROM "LDR_ADJ_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      no,
    );
    if (r.length !== 1)
      throw new LedgerAdjustValidationError(`ledger-adjust voucher not found: ${no}`);
    const h = r[0]!;
    return {
      voucherNo: no,
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      vchDate: text(h.VCH_DATE).slice(0, 10),
      acCode: text(h.AC_CODE),
      amount: num(h.DIFF_AMT),
      direction: num(h.DR_AMT) > 0 ? 'debit' : 'credit',
      remark: text(h.IT_REMARK),
    };
  });
}
export async function editLedgerAdjust(
  prisma: any,
  input: LedgerAdjustInput,
  requested: number | string,
) {
  assertLedgerAdjustInput(input);
  completeFinanceScope(input.scope);
  const date = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx) => {
    const { identity } = await editIdentityTx(tx, {
      table: 'LDR_ADJ_DATA',
      scope: input.scope,
      requestedVoucherNo: requested,
      requestedDate: date,
    });
    await replaceWriteSetTx(tx, input.scope, identity.voucherNo, identity.hiddenVoucherNo, TABLES);
    return write(tx, input, identity);
  });
}
/** TR_LEDR_ADJ.cs:3153-3157 deletes rows but contains no INSERT INTO DELETE_DATA. */
export async function deleteLedgerAdjust(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; book?: unknown },
) {
  completeFinanceScope(input.scope);
  const scope = input.scope,
    no = formatVoucherNo(input.vchNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx) => {
    const { identity } = await editIdentityTx(tx, {
      table: 'LDR_ADJ_DATA',
      scope,
      requestedVoucherNo: no,
      requestedDate: new Date(),
    });
    await reverseVoucherTx(tx, scope.tenantId, { tables: [...TABLES], key: voucherKey(scope, no) });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coBook,
      identity.hiddenVoucherNo,
    );
    return { reversed: true as const };
  });
}
