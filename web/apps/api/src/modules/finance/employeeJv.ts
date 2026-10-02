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
export class EmployeeJvValidationError extends Error {
  constructor(m: string) {
    super(m);
    this.name = 'EmployeeJvValidationError';
  }
}
export interface EmployeeJvInput {
  scope: VoucherScope;
  empAc: string;
  empName?: string;
  empCode?: string;
  paidAc?: string;
  salaryAmt: number;
  tdsAmt?: number;
  pfAmt?: number;
  tdsAc?: string;
  pfAc?: string;
  chqNo?: string;
  desc?: string;
  vchDate?: Date | string;
  mainUser?: string;
}
export interface EmployeeJvResult {
  vchNo: number;
  netPaid: number;
}
const T = ['EMP_DATA', 'AC_DATA'] as const;
const r2 = (n: number) => Math.round((n + Number.EPSILON) * 100) / 100;
/** Pure input guards. Desktop rejects these before touching the database, and the unit contract in
 * apps/api/test/financeWriters.test.ts depends on that ordering, so callers validate first. */
export function assertEmployeeJvInput(i: EmployeeJvInput): void {
  const salary = r2(num(i.salaryAmt)),
    tds = r2(num(i.tdsAmt)),
    pf = r2(num(i.pfAmt)),
    net = r2(salary - tds - pf);
  if (!text(i.empAc)) throw new EmployeeJvValidationError('employee account is required');
  if (!(salary > 0)) throw new EmployeeJvValidationError('salary amount must be positive');
  if (tds < 0 || pf < 0 || net < 0)
    throw new EmployeeJvValidationError('TDS + PF cannot exceed salary');
}
async function write(tx: any, i: EmployeeJvInput, id: VoucherIdentity): Promise<EmployeeJvResult> {
  completeFinanceScope(i.scope);
  const salary = r2(num(i.salaryAmt)),
    tds = r2(num(i.tdsAmt)),
    pf = r2(num(i.pfAmt)),
    net = r2(salary - tds - pf),
    emp = text(i.empAc),
    paid = text(i.paidAc) || 'CASH';
  const b = await configuredBookTx(tx, i.scope),
    k = voucherKey(i.scope, id.voucherNo),
    d = text(i.desc) || 'Salary',
    base = { ...k, VCH_TYPE: b.shortName, VCH_DATE: id.voucherDate };
  const ledger: LedgerLine[] = [
    { ...base, AC_CODE: emp, DR_AMT: salary, CR_AMT: 0, SIGN: 'D', IT_DESC: d },
  ];
  if (net > 0)
    ledger.push({
      ...base,
      AC_CODE: paid,
      DR_AMT: 0,
      CR_AMT: net,
      SIGN: 'C',
      IT_DESC: 'Salary paid',
    });
  if (tds > 0)
    ledger.push({
      ...base,
      AC_CODE: text(i.tdsAc) || 'TDS',
      DR_AMT: 0,
      CR_AMT: tds,
      SIGN: 'C',
      IT_DESC: 'TDS',
    });
  if (pf > 0)
    ledger.push({
      ...base,
      AC_CODE: text(i.pfAc) || 'PF',
      DR_AMT: 0,
      CR_AMT: pf,
      SIGN: 'C',
      IT_DESC: 'PF',
    });
  assertBalanced(ledger);
  await insertHiddenIdentityTx(tx, i.scope, id, b.name);
  await postVoucherTx(tx, i.scope.tenantId, {
    bookName: b.name,
    ledger: { table: 'AC_DATA', lines: ledger },
    writes: [
      {
        table: 'EMP_DATA',
        rows: [
          {
            ...k,
            SR_NO: 1,
            VCH_DATE: id.voucherDate,
            VCH_TIME: id.voucherTime,
            VCH_TYPE: b.shortName,
            INOUT_TYPE: 'O',
            ENTRY_TYPE: 'S',
            BOOK_NAME: b.name,
            AC_CODE: emp,
            AC_NAME: i.empName ?? null,
            PAID_AC_CODE: paid,
            MONTHLY_SALARY: salary,
            SALARY_AMT: salary,
            PAID_AMT: net,
            TDS_AMT: tds,
            PF_AMT: pf,
            CHQ_NO: i.chqNo ?? null,
            IT_DESC: d,
            EMP_CODE: i.empCode ?? null,
            HD_VCH_NO: id.hiddenVoucherNo,
            DATA_TRFR: 'N',
            MAIN_USER: id.mainUser || null,
          },
        ],
      },
    ],
  });
  return { vchNo: id.vchNo, netPaid: net };
}
export async function postEmployeeJv(p: any, i: EmployeeJvInput) {
  assertEmployeeJvInput(i);
  completeFinanceScope(i.scope);
  const d = i.vchDate ? new Date(i.vchDate) : new Date();
  return withTxBudget(p, i.scope.tenantId, 'voucher', async (tx) =>
    write(tx, i, await createIdentityTx(tx, i.scope, d, i.mainUser)),
  );
}
export async function getEmployeeJv(p: any, s: VoucherScope, x: number | string) {
  completeFinanceScope(s);
  const no = formatVoucherNo(x);
  return withTxBudget(p, s.tenantId, 'read', async (tx) => {
    const a: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"HD_VCH_NO","MAIN_USER","AC_CODE","AC_NAME","PAID_AC_CODE","SALARY_AMT","TDS_AMT","PF_AMT","CHQ_NO","IT_DESC","EMP_CODE" FROM "EMP_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coYear,
      s.coBook,
      no,
    );
    if (a.length !== 1) throw new EmployeeJvValidationError(`employee-jv voucher not found: ${no}`);
    const h = a[0]!;
    return {
      voucherNo: no,
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      vchDate: text(h.VCH_DATE).slice(0, 10),
      empAc: text(h.AC_CODE),
      empName: text(h.AC_NAME),
      paidAc: text(h.PAID_AC_CODE),
      salaryAmt: num(h.SALARY_AMT),
      tdsAmt: num(h.TDS_AMT),
      pfAmt: num(h.PF_AMT),
      chqNo: text(h.CHQ_NO),
      desc: text(h.IT_DESC),
      empCode: text(h.EMP_CODE),
    };
  });
}
export async function editEmployeeJv(p: any, i: EmployeeJvInput, x: number | string) {
  assertEmployeeJvInput(i);
  completeFinanceScope(i.scope);
  const d = i.vchDate ? new Date(i.vchDate) : new Date();
  return withTxBudget(p, i.scope.tenantId, 'voucher', async (tx) => {
    const { identity } = await editIdentityTx(tx, {
      table: 'EMP_DATA',
      scope: i.scope,
      requestedVoucherNo: x,
      requestedDate: d,
    });
    await replaceWriteSetTx(tx, i.scope, identity.voucherNo, identity.hiddenVoucherNo, T);
    return write(tx, i, identity);
  });
}
/** TR_EMP_JV.cs:3032-3036 has no DELETE_DATA insert. */ export async function deleteEmployeeJv(
  p: any,
  i: { scope: VoucherScope; vchNo: number | string; book?: unknown },
) {
  completeFinanceScope(i.scope);
  const s = i.scope,
    no = formatVoucherNo(i.vchNo);
  return withTxBudget(p, s.tenantId, 'voucher', async (tx) => {
    const { identity } = await editIdentityTx(tx, {
      table: 'EMP_DATA',
      scope: s,
      requestedVoucherNo: no,
      requestedDate: new Date(),
    });
    await reverseVoucherTx(tx, s.tenantId, { tables: [...T], key: voucherKey(s, no) });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coBook,
      identity.hiddenVoucherNo,
    );
    return { reversed: true as const };
  });
}
