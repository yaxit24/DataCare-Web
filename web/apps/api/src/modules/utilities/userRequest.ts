import { withTxBudget } from '../shared/txBudget.js';
import type { UtilityScope } from './hddRegistry.js';

export interface UserRequestInput {
  scope: UtilityScope;
  coBook: string;
  vchNo: string;
  acCode?: string;
  editUser: string;
  remark: string;
  requestType: 'E' | 'D';
}

export interface UserRequestRow {
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
  vchNo: string;
  vchDate: string | null;
  acCode: string;
  acName: string;
  totalAmount: number;
  totalFine: number;
  itemType: string;
  employeeCode: string;
  userName: string;
  editUser: string;
  remark: string;
  requestTime: string | null;
  requestType: string;
  permissionType: string;
}

export class UserRequestValidationError extends Error {
  override name = 'UserRequestValidationError';
}

const text = (value: unknown): string => String(value ?? '').trim();

function validate(input: UserRequestInput): void {
  // Exact desktop validation/message (UT_USER_REQUEST.cs:386-390).
  if (!text(input.remark)) {
    throw new UserRequestValidationError('Please Insert Reseon For Edit Or Delete in Remarks...');
  }
  if (!text(input.coBook) || !text(input.vchNo)) {
    throw new UserRequestValidationError('CO_BOOK and VCH_NO are required');
  }
  // RadioEdit maps to E, otherwise D (UT_USER_REQUEST.cs:397); no other values can be produced.
  if (input.requestType !== 'E' && input.requestType !== 'D') {
    throw new UserRequestValidationError('REQ_TYPE must be E or D');
  }
}

function rowOf(row: any): UserRequestRow {
  return {
    coCode: String(row.coCode),
    lcCode: String(row.lcCode),
    coYear: String(row.coYear),
    coBook: String(row.coBook),
    vchNo: String(row.vchNo),
    vchDate: row.vchDate ? String(row.vchDate).slice(0, 10) : null,
    acCode: String(row.acCode ?? ''),
    acName: String(row.acName ?? ''),
    totalAmount: Number(row.totalAmount ?? 0),
    totalFine: Number(row.totalFine ?? 0),
    itemType: String(row.itemType ?? ''),
    employeeCode: String(row.employeeCode ?? ''),
    userName: String(row.userName ?? ''),
    editUser: String(row.editUser ?? ''),
    remark: String(row.remark ?? ''),
    requestTime: row.requestTime ? new Date(row.requestTime).toISOString() : null,
    requestType: String(row.requestType ?? ''),
    permissionType: String(row.permissionType ?? ''),
  };
}

const SELECT_COLUMNS = `
  r."CO_CODE" AS "coCode", r."LC_CODE" AS "lcCode", r."CO_YEAR" AS "coYear",
  r."CO_BOOK" AS "coBook", r."VCH_NO" AS "vchNo", r."VCH_DATE"::text AS "vchDate",
  r."AC_CODE" AS "acCode", r."AC_NAME" AS "acName", r."TOT_AMT" AS "totalAmount",
  r."TOT_FINE" AS "totalFine", r."ITM_TYPE" AS "itemType", r."EMP_CODE" AS "employeeCode",
  r."USER_NAME" AS "userName", r."EDIT_USER" AS "editUser", r."EDIT_RMARK" AS "remark",
  r."REQ_TIME" AS "requestTime", r."REQ_TYPE" AS "requestType",
  r."PARMATION_TYPE" AS "permissionType"`;

export async function listUserRequests(
  prisma: any,
  scope: UtilityScope,
): Promise<UserRequestRow[]> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows = await tx.$queryRawUnsafe(
      `SELECT ${SELECT_COLUMNS} FROM "USER_REQUEST" r
        WHERE r.tenant_id=$1 AND r."CO_CODE"=$2 AND r."LC_CODE"=$3 AND r."CO_YEAR"=$4
        ORDER BY r."REQ_TIME" DESC NULLS LAST, r."CO_BOOK", r."VCH_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear ?? '',
    );
    return rows.map(rowOf);
  });
}

export async function getUserRequest(
  prisma: any,
  scope: UtilityScope,
  coBook: string,
  vchNo: string,
): Promise<UserRequestRow | null> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows = await tx.$queryRawUnsafe(
      `SELECT ${SELECT_COLUMNS} FROM "USER_REQUEST" r
        WHERE r.tenant_id=$1 AND r."CO_CODE"=$2 AND r."LC_CODE"=$3 AND r."CO_YEAR"=$4
          AND r."CO_BOOK"=$5 AND r."VCH_NO"=$6 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear ?? '',
      coBook,
      vchNo,
    );
    return rows[0] ? rowOf(rows[0]) : null;
  });
}

export async function saveUserRequest(
  prisma: any,
  input: UserRequestInput,
): Promise<{ saved: boolean; message: string }> {
  validate(input);
  const scope = input.scope;
  const coBook = text(input.coBook);
  const vchNo = text(input.vchNo);
  const acCode = text(input.acCode);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    // Desktop first removes the same company/year/location/book/voucher request
    // (UT_USER_REQUEST.cs:392). Explicit tenant scope is added and the replacement is atomic.
    await tx.$executeRawUnsafe(
      `DELETE FROM "USER_REQUEST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
         AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear ?? '',
      coBook,
      vchNo,
    );

    // Desktop source lookup reads CO_BOOK,VCH_NO,VCH_DATE,AC_CODE,AC_NAME,MAIN_USER from AC_DATA
    // UNION ALL MAIN_STOCK, filtered by company/location/year/book/voucher/account
    // (UT_USER_REQUEST.cs:393). AC_NAME comes from AC_MAST; all reads are additionally tenant- and
    // active-location-scoped here. AC_DATA remains first, matching UNION ALL row 0 behavior.
    const sourceRows = await tx.$queryRawUnsafe(
      `SELECT s."CO_BOOK" AS "coBook",s."VCH_NO" AS "vchNo",s."VCH_DATE" AS "vchDate",
              $6::text AS "acCode",m."AC_NAME" AS "acName",s."MAIN_USER" AS "mainUser",s.origin
         FROM (
           SELECT "CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","MAIN_USER",0 AS origin
             FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
              AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$7 AND COALESCE("AC_CODE",'')=$6
           UNION ALL
           SELECT "CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","MAIN_USER",1 AS origin
             FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
              AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$7 AND COALESCE("AC_CODE",'')=$6
         ) s
         LEFT JOIN "AC_MAST" m ON m.tenant_id=$1 AND m."CO_CODE"=$2 AND m."LC_CODE"=$3
                               AND m."AC_CODE"=$6
        ORDER BY s.origin LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear ?? '',
      coBook,
      acCode,
      vchNo,
    );
    const source = sourceRows[0];
    if (source) {
      // Exact desktop 18-column write/value sources (UT_USER_REQUEST.cs:397): scoped globals;
      // source voucher/date/name/original MAIN_USER; 0 totals; blank item/employee; current caller
      // as EDIT_USER (call sites set MsReqUser=MCo_User, e.g. TR_SALE.cs:17145-17148); reason;
      // current time; E/D radio; constant permission type P.
      await tx.$executeRawUnsafe(
        `INSERT INTO "USER_REQUEST"(
           tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE",
           "AC_NAME","TOT_AMT","TOT_FINE","ITM_TYPE","EMP_CODE","USER_NAME","EDIT_USER",
           "EDIT_RMARK","REQ_TIME","REQ_TYPE","PARMATION_TYPE")
         VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,0,0,'','',$10,$11,$12,CURRENT_TIMESTAMP,$13,'P')`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear ?? '',
        String(source.coBook),
        String(source.vchNo),
        source.vchDate,
        acCode,
        source.acName ?? '',
        source.mainUser ?? '',
        input.editUser,
        text(input.remark),
        input.requestType,
      );
    }
    // Desktop shows this even when the source SELECT returns no rows (UT_USER_REQUEST.cs:395-405).
    return { saved: Boolean(source), message: 'Request Sent Successfully...' };
  });
}

export async function deleteUserRequest(
  prisma: any,
  scope: UtilityScope,
  coBook: string,
  vchNo: string,
): Promise<{ deleted: number }> {
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const deleted = await tx.$executeRawUnsafe(
      `DELETE FROM "USER_REQUEST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
         AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear ?? '',
      coBook,
      vchNo,
    );
    return { deleted };
  });
}
