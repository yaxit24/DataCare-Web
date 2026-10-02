import { withTxBudget } from '../shared/txBudget.js';
import { buildFineJvRojmel, rojmelMetalFor } from '../shared/rojmel.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import { postVoucherTx, reverseVoucherTx, type LedgerLine } from '../posting/posting.js';
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
export class FineJvValidationError extends Error {
  constructor(m: string) {
    super(m);
    this.name = 'FineJvValidationError';
  }
}
export interface FineJvInput {
  /** Desktop CONTRA_DATA columns (TR_CONTRA.cs:2783,2803): counter-account name, employee. */
  toAcName?: string;
  empCode?: string;
  scope: VoucherScope;
  fromAc: string;
  toAc: string;
  fineWt: number;
  metal?: 'G' | 'S';
  vchDate?: Date | string;
  mainUser?: string;
}
export interface FineJvResult {
  vchNo: number;
}
// ROJ_MEL_DATA belongs in the reversal set, not only the write set: its primary key is LEDR_KEY alone,
// so an edit that rewrites without deleting first fails on unique constraint 23505.
const T = ['CONTRA_DATA', 'AC_DATA', 'ROJ_MEL_DATA'] as const,
  r3 = (n: number) => Math.round((n + Number.EPSILON) * 1000) / 1000;
async function write(tx: any, i: FineJvInput, id: VoucherIdentity) {
  completeFinanceScope(i.scope);
  const from = text(i.fromAc),
    to = text(i.toAc),
    fine = r3(num(i.fineWt)),
    metal = i.metal ?? 'G';
  if (!from || !to || from === to || !(fine > 0))
    throw new FineJvValidationError(
      'fine-jv requires different from/to accounts and positive fine',
    );
  const b = await configuredBookTx(tx, i.scope),
    k = voucherKey(i.scope, id.voucherNo),
    base = {
      ...k,
      VCH_TYPE: b.shortName,
      VCH_DATE: id.voucherDate,
      IT_TYPE: metal,
      FINE_WT: fine,
      FINE_RATE: 0,
      DR_AMT: 0,
      CR_AMT: 0,
    };
  const ledger: LedgerLine[] = [
    { ...base, AC_CODE: to, LD_CODE: from, SIGN: '+' },
    { ...base, AC_CODE: from, LD_CODE: to, SIGN: '-' },
  ];
  const rows = [
    {
      ...k,
      SR_NO: 1,
      VCH_DATE: id.voucherDate,
      VCH_TIME: id.voucherTime,
      VCH_TYPE: b.shortName,
      BOOK_NAME: b.name,
      AC_CODE: to,
      LD_CODE: from,
      DR_AMT: 0,
      CR_AMT: 0,
      DR_FINE: fine,
      CR_FINE: 0,
      IT_TYPE: metal,
      CRDR_TYPE: 'D',
      LDR_TYPE: '1',
      HD_VCH_NO: id.hiddenVoucherNo,
      MAIN_USER: id.mainUser || null,
      // TR_CONTRA.cs:2783,2803,2805 — counter-account name, employee, DATA_TRFR literal.
      AC_NAME: i.toAcName ?? null,
      EMP_CODE: i.empCode ?? null,
      DATA_TRFR: 'N',
    },
    {
      ...k,
      SR_NO: 2,
      VCH_DATE: id.voucherDate,
      VCH_TIME: id.voucherTime,
      VCH_TYPE: b.shortName,
      BOOK_NAME: b.name,
      AC_CODE: from,
      LD_CODE: to,
      DR_AMT: 0,
      CR_AMT: 0,
      DR_FINE: 0,
      CR_FINE: fine,
      IT_TYPE: metal,
      CRDR_TYPE: 'C',
      LDR_TYPE: '0',
      HD_VCH_NO: id.hiddenVoucherNo,
      MAIN_USER: id.mainUser || null,
      // TR_CONTRA.cs:2783,2803,2805 — counter-account name, employee, DATA_TRFR literal.
      AC_NAME: i.toAcName ?? null,
      EMP_CODE: i.empCode ?? null,
      DATA_TRFR: 'N',
    },
  ];
  await insertHiddenIdentityTx(tx, i.scope, id, b.name);
  // The Rojmel. Book 078 carries 28 real rows in two types, both money-free and both carrying ITM_FINE with
  // NO gross weight - a fine JV moves pure fine between accounts, so there is nothing to weigh and no cash
  // involved. Derived from Ac_Rojmel.Contra_Rojmel lines 342/344, where one routine serves both
  // MAIN_BOOK 'CONTRA' (book 017) and 'FINE JV' (book 078). Source and data agree exactly.
  //
  // Built from `rows` - the same CONTRA_DATA rows the write set uses - so the two projections of this
  // voucher cannot drift apart.
  const rojmelRows = buildFineJvRojmel(
    {
      scope: { coCode: i.scope.coCode, lcCode: i.scope.lcCode, coYear: i.scope.coYear! },
      key: k,
      coBook: String(k.CO_BOOK),
      vchNo: String(k.VCH_NO),
      vchDate: id.voucherDate,
      vchType: b.shortName,
      bookName: b.name,
      partyName: '',
      partyCode: '',
    },
    rows.map((r: Record<string, unknown>, idx: number) => ({
      lineNo: Number(r.SR_NO ?? idx + 1),
      acCode: String(r.AC_CODE ?? ''),
      ldCode: String(r.LD_CODE ?? ''),
      metal: rojmelMetalFor(r.IT_TYPE as string),
      creditFine: Number(r.CR_FINE ?? 0),
      debitFine: Number(r.DR_FINE ?? 0),
      description: String(r.IT_DESC ?? '') || undefined,
    })),
  );
  await postVoucherTx(tx, i.scope.tenantId, {
    bookName: b.name,
    ledger: { table: 'AC_DATA', lines: ledger },
    writes: [
      { table: 'CONTRA_DATA', rows },
      ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
    ],
  });
  return { vchNo: id.vchNo };
}
export async function postFineJv(p: any, i: FineJvInput) {
  completeFinanceScope(i.scope);
  const d = i.vchDate ? new Date(i.vchDate) : new Date();
  return withTxBudget(p, i.scope.tenantId, 'voucher', async (tx) =>
    write(tx, i, await createIdentityTx(tx, i.scope, d, i.mainUser)),
  );
}
export async function getFineJv(p: any, s: VoucherScope, x: number | string) {
  completeFinanceScope(s);
  const no = formatVoucherNo(x);
  return withTxBudget(p, s.tenantId, 'read', async (tx) => {
    const a: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"HD_VCH_NO","MAIN_USER","AC_CODE","LD_CODE","DR_FINE","CR_FINE","IT_TYPE" FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coYear,
      s.coBook,
      no,
    );
    if (a.length !== 2) throw new FineJvValidationError(`fine-jv voucher not found: ${no}`);
    const h = a[0]!,
      plus = a.find((r) => num(r.DR_FINE) > 0) ?? h;
    return {
      voucherNo: no,
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      vchDate: text(h.VCH_DATE).slice(0, 10),
      toAc: text(plus.AC_CODE),
      fromAc: text(plus.LD_CODE),
      fineWt: num(plus.DR_FINE) || num(plus.CR_FINE),
      metal: text(plus.IT_TYPE) === 'S' ? 'S' : 'G',
    };
  });
}
export async function editFineJv(p: any, i: FineJvInput, x: number | string) {
  completeFinanceScope(i.scope);
  const d = i.vchDate ? new Date(i.vchDate) : new Date();
  return withTxBudget(p, i.scope.tenantId, 'voucher', async (tx) => {
    const { identity } = await editIdentityTx(tx, {
      table: 'CONTRA_DATA',
      scope: i.scope,
      requestedVoucherNo: x,
      requestedDate: d,
    });
    await replaceWriteSetTx(tx, i.scope, identity.voucherNo, identity.hiddenVoucherNo, T);
    return write(tx, i, identity);
  });
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
  return withTxBudget(p, s.tenantId, 'voucher', async (tx) => {
    const { persisted: header, identity } = await editIdentityTx(tx, {
      table: 'CONTRA_DATA',
      scope: s,
      requestedVoucherNo: no,
      requestedDate: new Date(),
    });
    const a: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
        `SELECT "SR_NO","AC_CODE","AC_NAME","DR_AMT","CR_AMT","DR_FINE","CR_FINE","IT_TYPE","IT_DESC" FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        s.coYear,
        s.coBook,
        no,
      ),
      b = await configuredBookTx(tx, s);
    await reverseVoucherTx(tx, s.tenantId, { tables: [...T], key: voucherKey(s, no) });
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
      configuredBook: b,
      header,
      rows: a.map((r) => ({
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
      deleteUser: i.deleteUser,
    });
    return { reversed: true as const };
  });
}
