import { withTxBudget } from '../shared/txBudget.js';
import type { VoucherScope } from '../vouchers/numbering.js';

/**
 * Customer Entry (desktop UT_CUST_ENTRY) — an employee-scoped customer CRM enquiry / item-interest /
 * follow-up-reminder log. NON-FINANCIAL: it writes only CUST_DATA (one row per customer/item-interest
 * line, keyed by SR_NO) and a seed CUST_DETL follow-up row (ISR_NO=1) per line. It posts NO ledger
 * (AC_DATA), no ROJ_MEL_DATA, no TEMP_BOOK_DATA and no DELETE_DATA, and uses no configured accounting
 * book — the aggregate is keyed by CO_BOOK = employeeCode with an employee-scoped VCH_NO.
 *
 * Desktop authority: UT_CUST_ENTRY.cs:2496-2569 (write-set), :2353-2366 (employee-scoped numbering),
 * :2503-2509 (the per-row write predicate), :2605-2606 (delete removes both tables, no audit).
 */
export class CustomerEntryValidationError extends Error {
  constructor(m: string) {
    super(m);
    this.name = 'CustomerEntryValidationError';
  }
}

export interface CustomerEntryRow {
  srNo?: number;
  acCode?: string;
  custCode?: string;
  acName?: string;
  mobileNo?: string;
  remDate?: Date | string;
  itemRemark?: string;
  tagNo?: string;
  tagVoucherSerial?: number;
  itemCode?: string;
  itemName?: string;
  itemLike?: string;
  pieces?: number;
  grossWeight?: number;
  netWeight?: number;
  fineWeight?: number;
}

export interface CustomerEntryInput {
  scope: VoucherScope; // tenantId, coCode, lcCode, coYear
  employeeCode: string;
  employeeName?: string;
  vchDate?: Date | string;
  rows: CustomerEntryRow[];
  mainUser?: string;
}

const txt = (v: unknown): string => (v == null ? '' : String(v).trim());
const nnum = (v: unknown): number => {
  const n = Number(v);
  return Number.isFinite(n) ? n : 0;
};
const fmt5 = (n: number): string => String(n).padStart(5, '0');

/** Desktop predicate (UT_CUST_ENTRY.cs:2503-2509): a row is persisted only when it carries meaning. */
function rowQualifies(r: CustomerEntryRow): boolean {
  const name = txt(r.acName);
  const remark = txt(r.itemRemark);
  const tag = txt(r.tagNo);
  const itCode = txt(r.itemCode);
  const remDate = txt(r.remDate);
  return (!!name && !!remark) || !!tag || (!!itCode && !!remDate);
}

export function assertCustomerEntryInput(i: CustomerEntryInput): void {
  if (!txt(i.employeeCode)) throw new CustomerEntryValidationError('employee code is required');
  const rows = (i.rows ?? []).filter(rowQualifies);
  if (!rows.length)
    throw new CustomerEntryValidationError(
      'at least one row with a name+remark, a tag, or an item+reminder date is required',
    );
}

function requireScope(scope: VoucherScope): {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
} {
  if (!scope?.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear)
    throw new CustomerEntryValidationError(
      'scope requires tenantId, company, location and fiscal year',
    );
  return {
    tenantId: scope.tenantId,
    coCode: scope.coCode,
    lcCode: scope.lcCode,
    coYear: scope.coYear,
  };
}

/** Next employee-scoped CUST_DATA voucher number (MAX+1 within company/location/year/employee). */
async function nextCustVchNoTx(
  tx: any,
  s: { tenantId: string; coCode: string; lcCode: string; coYear: string },
  emp: string,
): Promise<number> {
  const rows: Array<{ mx: number }> = await tx.$queryRawUnsafe(
    `SELECT coalesce(MAX(("VCH_NO")::int),0) mx FROM "CUST_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5`,
    s.tenantId,
    s.coCode,
    s.lcCode,
    s.coYear,
    emp,
  );
  return Number(rows[0]?.mx ?? 0) + 1;
}

async function writeRows(
  tx: any,
  i: CustomerEntryInput,
  s: { tenantId: string; coCode: string; lcCode: string; coYear: string },
  emp: string,
  vchNoStr: string,
  mainUser: string,
): Promise<number> {
  const vchDate = i.vchDate ? new Date(i.vchDate) : new Date();
  const now = new Date();
  const rows = (i.rows ?? []).filter(rowQualifies);
  let sr = 0;
  for (const r of rows) {
    sr++;
    const srNo = r.srNo != null ? nnum(r.srNo) : sr;
    const remDate = r.remDate ? new Date(r.remDate) : vchDate;
    await tx.$executeRawUnsafe(
      `INSERT INTO "CUST_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
         "VCH_DATE","VCH_TIME","REM_DATE","REM_TIME","AC_CODE","CUST_CODE","AC_NAME","MOBILE_NO",
         "TAG_NO","VCH_SRNO","IT_CODE","IT_NAME","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","ITM_BUY",
         "ITM_REMARK","MAIN_USER","EMP_CODE","EMP_NAME")
       VALUES($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12,$13,$14,$15,$16,$17,$18,$19,$20,$21,$22,$23,$24,$25,$26,$27,$28)`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coYear,
      emp,
      vchNoStr,
      srNo,
      vchDate,
      now,
      remDate,
      now,
      txt(r.acCode) || null,
      txt(r.custCode) || null,
      txt(r.acName).slice(0, 50) || null,
      txt(r.mobileNo).slice(0, 13) || null,
      txt(r.tagNo).slice(0, 15) || null,
      r.tagVoucherSerial != null ? nnum(r.tagVoucherSerial) : null,
      txt(r.itemCode).slice(0, 6) || null,
      txt(r.itemName).slice(0, 50) || null,
      nnum(r.pieces),
      nnum(r.grossWeight),
      nnum(r.netWeight),
      nnum(r.fineWeight),
      txt(r.itemLike).slice(0, 1) || null,
      txt(r.itemRemark).slice(0, 150) || null,
      mainUser || null,
      emp.slice(0, 5),
      txt(i.employeeName).slice(0, 40) || null,
    );
    // seed follow-up row (ISR_NO=1) using THIS row's reminder date and remark (hardening over the
    // desktop control-state bug that copied the active control's remark to every seed row).
    await tx.$executeRawUnsafe(
      `INSERT INTO "CUST_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "REM_DATE","REM_TIME","ITM_REMARK","MAIN_USER","EMP_CODE")
       VALUES($1,$2,$3,$4,$5,$6,$7,1,$8,$9,$10,$11,$12)`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coYear,
      emp,
      vchNoStr,
      srNo,
      remDate,
      now,
      txt(r.itemRemark).slice(0, 150) || null,
      mainUser || null,
      emp.slice(0, 5),
    );
  }
  return sr;
}

/** Map a raw request body + scope into a CustomerEntryInput (keeps the route file thin). */
export function customerEntryInputFromBody(
  scope: VoucherScope,
  b: Record<string, any>,
): CustomerEntryInput {
  return {
    scope,
    employeeCode: b.employeeCode,
    employeeName: b.employeeName,
    vchDate: b.vchDate,
    rows: Array.isArray(b.rows) ? b.rows : [],
    mainUser: b.mainUser,
  };
}

export async function postCustomerEntry(p: any, i: CustomerEntryInput) {
  assertCustomerEntryInput(i);
  const s = requireScope(i.scope);
  const emp = txt(i.employeeCode).slice(0, 5);
  return withTxBudget(p, s.tenantId, 'voucher', async (tx: any) => {
    const no = await nextCustVchNoTx(tx, s, emp);
    const vchNoStr = fmt5(no);
    const rowCount = await writeRows(tx, i, s, emp, vchNoStr, txt(i.mainUser));
    return { vchNo: no, voucherNo: vchNoStr, rowCount };
  });
}

export async function getCustomerEntry(
  p: any,
  scope: VoucherScope,
  employeeCode: string,
  vchNo: number | string,
) {
  const s = requireScope(scope);
  const emp = txt(employeeCode).slice(0, 5);
  const no = fmt5(Number(vchNo));
  return withTxBudget(p, s.tenantId, 'read', async (tx: any) => {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","SR_NO"::int sr,"VCH_DATE"::text vd,"EMP_CODE","EMP_NAME","MAIN_USER",
              "AC_CODE","CUST_CODE","AC_NAME","MOBILE_NO","REM_DATE"::text rd,"ITM_REMARK","TAG_NO",
              "VCH_SRNO"::int vsr,"IT_CODE","IT_NAME","ITM_BUY","ITM_PCS"::float8 pcs,"ITM_GWT"::float8 gwt,
              "ITM_NWT"::float8 nwt,"ITM_FINE"::float8 fine
         FROM "CUST_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
         ORDER BY "SR_NO"`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coYear,
      emp,
      no,
    );
    if (!rows.length)
      throw new CustomerEntryValidationError(`customer-entry not found: ${emp}/${no}`);
    const h = rows[0]!;
    return {
      voucherNo: no,
      employeeCode: txt(h.EMP_CODE),
      employeeName: txt(h.EMP_NAME),
      mainUser: txt(h.MAIN_USER),
      vchDate: txt(h.vd).slice(0, 10),
      rows: rows.map((r) => ({
        srNo: Number(r.sr),
        acCode: txt(r.AC_CODE),
        custCode: txt(r.CUST_CODE),
        acName: txt(r.AC_NAME),
        mobileNo: txt(r.MOBILE_NO),
        remDate: txt(r.rd).slice(0, 10),
        itemRemark: txt(r.ITM_REMARK),
        tagNo: txt(r.TAG_NO),
        tagVoucherSerial: r.vsr == null ? null : Number(r.vsr),
        itemCode: txt(r.IT_CODE),
        itemName: txt(r.IT_NAME),
        itemLike: txt(r.ITM_BUY),
        pieces: nnum(r.pcs),
        grossWeight: nnum(r.gwt),
        netWeight: nnum(r.nwt),
        fineWeight: nnum(r.fine),
      })),
    };
  });
}

/** Edit = replace the whole CUST_DATA aggregate + reseed CUST_DETL ISR_NO=1. Retains ISR_NO>1 history
 *  for rows that still exist; removed rows have their follow-up history deleted (deliberate hardening). */
export async function editCustomerEntry(p: any, i: CustomerEntryInput, vchNo: number | string) {
  assertCustomerEntryInput(i);
  const s = requireScope(i.scope);
  const emp = txt(i.employeeCode).slice(0, 5);
  const no = fmt5(Number(vchNo));
  return withTxBudget(p, s.tenantId, 'voucher', async (tx: any) => {
    // preserve the original creator
    const prev: Array<{ MAIN_USER: string | null }> = await tx.$queryRawUnsafe(
      `SELECT "MAIN_USER" FROM "CUST_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" LIMIT 1`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coYear,
      emp,
      no,
    );
    const mainUser = txt(prev[0]?.MAIN_USER) || txt(i.mainUser);
    const wipe = (table: string) =>
      tx.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        s.coYear,
        emp,
        no,
      );
    await wipe('CUST_DATA');
    await wipe('CUST_DETL');
    const rowCount = await writeRows(tx, i, s, emp, no, mainUser);
    return { voucherNo: no, rowCount };
  });
}

export async function deleteCustomerEntry(
  p: any,
  i: { scope: VoucherScope; employeeCode: string; vchNo: number | string },
) {
  const s = requireScope(i.scope);
  const emp = txt(i.employeeCode).slice(0, 5);
  const no = fmt5(Number(i.vchNo));
  return withTxBudget(p, s.tenantId, 'voucher', async (tx: any) => {
    for (const table of ['CUST_DATA', 'CUST_DETL'])
      await tx.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        s.coYear,
        emp,
        no,
      );
    return { deleted: true as const };
  });
}
