import { vbVal } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { insertRowTx } from '../posting/posting.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { requiredVersion, versionOf } from '../vouchers/version.js';

/**
 * Employee master (desktop MS_EMP, menu Master → Employee; MDI_FORM.cs:7660-7669 opens the form directly). One
 * EMP_MAST row per company and employee code:
 *
 * - The list shows Code and Name ordered by name (MS_EMP_Load, MS_EMP.cs:1144; DGV_FILL :1197-1240), and by code right
 *   after a delete, because BtnDelete_Click re-reads the rows ORDER BY EMP_CODE (:1579).
 * - A new entry takes the next code: '001' when the company has none, else the highest code + 1 as three digits
 *   (CLEAR_DATA :1260-1268). The code box is read-only once an employee is opened (DISPLAY_DATA :1296).
 * - The user list is LOGIN_MAST's login names of company '01' after a blank entry (AddCboItem :1152-1177).
 * - Save needs the edit right only for an opened employee (BtnSave_Click :1478-1484), refuses a blank code and name
 *   with "Enter Employee Detail" (:1487-1491), and replaces the row with the code, name, account, amount, day hours,
 *   user ('ABC' when blank) and the creator (:1493-1516). Leaving the code box refuses a code another employee uses
 *   (tEmpCode_Validating :1350-1370, text at :1360), and leaving the name box a name another code uses
 *   (tEmpName_Validating :1391-1411, text at :1401).
 * - Delete needs the delete right, refuses a blank code with "Please Select Employee For Delete." and the default
 *   employee '001' with "You Cant Delete Record, This Empoyee Is Default Empoyee...." (:1552-1584; texts at :1562,
 *   :1566, :1573).
 * - Print needs the print right and prints the EmpMast report for the company (:1585-1599).
 *
 * Deliberate differences from the desktop, recorded on the gap:
 * - Save refuses a blank name ("Please Insert Employee Name ...", the desktop's Enter text on the name box :1381);
 *   the desktop checks it only when Enter is pressed there, so a click on Save could store a nameless employee.
 * - Save refuses an account code that is not in AC_MAST; the desktop looks the code up only on Enter (:1631-1680) and
 *   stores whatever the box holds.
 * - Save keeps EMP_TYPE, TDS_PRC, TDS_AMT, PF_PRC and PF_AMT. The desktop's DELETE + INSERT resets them to their
 *   defaults; only an import sets them (UT_IMPORT.cs:9984), and TR_EMP_JV shows its TDS and PF columns from them
 *   (TR_EMP_JV.cs:1567).
 * - Save refuses a user that is not a company-01 login and a name longer than the 40-character column; the desktop
 *   offers only the login names and SQL Server refuses a longer name.
 * - An opened employee carries the version read with it (N51 tokens): its save and delete are refused with 409 when
 *   another operator changed or deleted it meanwhile, and a new entry whose code another operator took meanwhile is
 *   refused with the code text under the company lock. The desktop's later save wins, replacing the other operator's
 *   employee.
 */
export const EMPLOYEE_DEFAULT_CODE = '001';
const BLANK_USER = 'ABC';

export class EmployeeMasterValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'EmployeeMasterValidationError';
  }
}

export class EmployeeVersionConflictError extends Error {
  readonly code = 'employee-version-conflict';
  readonly statusCode = 409;
  constructor() {
    super(
      'This employee was changed by someone else after you opened it. Open it again before saving or deleting.',
    );
    this.name = 'EmployeeVersionConflictError';
  }
}

export interface EmployeeScope {
  tenantId: string;
  coCode: string;
}

/** One employee as the screen sends it. */
export interface EmployeeSaveInput {
  scope: EmployeeScope;
  /** 'A' for a new employee, 'E' for one opened from the list (the desktop's EntryMode). */
  entryMode: 'A' | 'E';
  code: string;
  name: string;
  account?: string;
  amount?: number | string;
  dayHours?: number | string;
  user?: string;
  mainUser: string;
  canUpdate: boolean;
  /** The version read when the employee was opened; required for an opened one ('E'). */
  expectedVersion?: unknown;
}

const text = (value: unknown): string => String(value ?? '').trim();
/** MS_EMP_KeyPress upper-cases every key and drops the apostrophe (MS_EMP.cs:1319-1332). */
const typed = (value: unknown): string => text(value).toUpperCase().replace(/'/g, '');

/** Desktop text of tEmpCode_Validating (MS_EMP.cs:1360). */
export const codeTakenMessage = (name: string): string =>
  `This Employee Code already Exist in  '${name}'  Employee Name...Please Change Employee Code...`;
/** Desktop text of tEmpName_Validating (MS_EMP.cs:1401). */
export const nameTakenMessage = (code: string): string =>
  `This Employee Name already Exist in  '${code}'  Employee Code...Please Change Employee Name...`;

/**
 * CLEAR_DATA's next code (MS_EMP.cs:1260-1268): '001', or the highest code + 1 as three digits. The desktop takes the
 * first code of `ORDER BY EMP_CODE DESC`, which is the highest number while every code has three digits, as the form
 * writes them; the web takes the highest number, so an odd two-digit code cannot produce a code that is already used.
 */
export function nextEmployeeCode(codes: readonly string[]): string {
  const numbers = codes.map((code) => Number(code)).filter((value) => Number.isInteger(value));
  if (!numbers.length) return EMPLOYEE_DEFAULT_CODE;
  return String(Math.max(...numbers) + 1).padStart(3, '0');
}

const lockTx = (tx: any, scope: EmployeeScope) =>
  tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `employee-master:${scope.tenantId}:${scope.coCode}`,
  );

/** SHA-256 of the employee's EMP_MAST rows (row ids included, so every save issues a new version). */
async function employeeVersionTx(tx: any, scope: EmployeeScope, code: string): Promise<string> {
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT r.* FROM "EMP_MAST" r WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3
      ORDER BY to_jsonb(r)::text`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  return versionOf({ EMP_MAST: rows });
}

export async function listEmployees(
  prisma: any,
  scope: EmployeeScope,
  order: 'name' | 'code' = 'name',
): Promise<{
  rows: Array<{ code: string; name: string }>;
  nextCode: string;
  users: string[];
}> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: Array<{ EMP_CODE: string | null; EMP_NAME: string | null }> =
      await tx.$queryRawUnsafe(
        `SELECT "EMP_CODE","EMP_NAME" FROM "EMP_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2
        ORDER BY ${order === 'code' ? '"EMP_CODE"' : '"EMP_NAME"'}, "row_id"`,
        scope.tenantId,
        scope.coCode,
      );
    const users: Array<{ LOGIN_NAME: string | null }> = await tx.$queryRawUnsafe(
      `SELECT "LOGIN_NAME" FROM "LOGIN_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"='01' AND coalesce("LOGIN_NAME",'')<>''
        GROUP BY "LOGIN_NAME" ORDER BY "LOGIN_NAME"`,
      scope.tenantId,
    );
    return {
      rows: rows.map((row) => ({ code: text(row.EMP_CODE), name: text(row.EMP_NAME) })),
      nextCode: nextEmployeeCode(rows.map((row) => text(row.EMP_CODE))),
      users: ['', ...users.map((row) => text(row.LOGIN_NAME))],
    };
  });
}

export async function getEmployee(
  prisma: any,
  scope: EmployeeScope,
  code: string,
): Promise<{
  code: string;
  name: string;
  user: string;
  account: string;
  accountName: string;
  amount: number;
  dayHours: number;
  mainUser: string;
  version: string;
} | null> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const [row] = await tx.$queryRawUnsafe(
      `SELECT e."EMP_CODE", e."EMP_NAME", e."USER_NAME", e."EMP_AC", coalesce(e."EMP_AMT",0)::float8 AS amt,
              coalesce(e."DAY_HOURS",0)::float8 AS hours, e."MAIN_USER", a."AC_NAME"
         FROM "EMP_MAST" e
         LEFT JOIN "AC_MAST" a ON a.tenant_id=e.tenant_id AND a."CO_CODE"=e."CO_CODE" AND a."AC_CODE"=e."EMP_AC"
        WHERE e.tenant_id=$1 AND e."CO_CODE"=$2 AND e."EMP_CODE"=$3
        ORDER BY e."row_id" LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      text(code),
    );
    if (!row) return null;
    return {
      code: text(row.EMP_CODE),
      name: text(row.EMP_NAME),
      user: text(row.USER_NAME),
      account: text(row.EMP_AC),
      accountName: text(row.AC_NAME),
      amount: Number(row.amt),
      dayHours: Number(row.hours),
      mainUser: text(row.MAIN_USER),
      version: await employeeVersionTx(tx, scope, text(code)),
    };
  });
}

export async function saveEmployee(
  prisma: any,
  input: EmployeeSaveInput,
): Promise<{ code: string }> {
  const code = typed(input.code);
  const name = typed(input.name);
  if (input.entryMode === 'E' && !input.canUpdate)
    throw new EmployeeMasterValidationError(DESKTOP_MESSAGES.EMPLOYEE_NO_RIGHTS);
  if (!code && !name)
    throw new EmployeeMasterValidationError(DESKTOP_MESSAGES.EMPLOYEE_DETAIL_REQUIRED);
  if (!name) throw new EmployeeMasterValidationError(DESKTOP_MESSAGES.EMPLOYEE_NAME_REQUIRED);
  if (!/^.{1,3}$/.test(code))
    throw new EmployeeMasterValidationError(`employee code must be 1 to 3 characters`);
  if (name.length > 40)
    throw new EmployeeMasterValidationError(`employee name must be at most 40 characters`);
  const account = typed(input.account);
  // cboUser is a drop-down list of login names (DropDownStyle 2), so the stored name is the listed one as it is.
  const listedUser = text(input.user);
  const expected = input.entryMode === 'E' ? requiredVersion(input.expectedVersion) : null;
  await withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    await lockTx(tx, input.scope);
    if (expected && (await employeeVersionTx(tx, input.scope, code)) !== expected)
      throw new EmployeeVersionConflictError();
    const rows: Array<{
      EMP_CODE: string | null;
      EMP_NAME: string | null;
      MAIN_USER: string | null;
      EMP_TYPE: string | null;
      TDS_PRC: unknown;
      TDS_AMT: unknown;
      PF_PRC: unknown;
      PF_AMT: unknown;
    }> = await tx.$queryRawUnsafe(
      `SELECT "EMP_CODE","EMP_NAME","MAIN_USER","EMP_TYPE","TDS_PRC","TDS_AMT","PF_PRC","PF_AMT"
         FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "row_id"`,
      input.scope.tenantId,
      input.scope.coCode,
    );
    const same = rows.find((row) => text(row.EMP_CODE) === code);
    // tEmpCode_Validating: a code already used by another name is refused on a new entry.
    if (same && input.entryMode === 'A' && text(same.EMP_NAME).toUpperCase() !== name)
      throw new EmployeeMasterValidationError(codeTakenMessage(text(same.EMP_NAME)));
    // tEmpName_Validating: a name already used by another code is refused.
    const namesake = rows.find(
      (row) => text(row.EMP_NAME).toUpperCase() === name && text(row.EMP_CODE) !== code,
    );
    if (namesake)
      throw new EmployeeMasterValidationError(nameTakenMessage(text(namesake.EMP_CODE)));
    if (listedUser) {
      const [login] = await tx.$queryRawUnsafe(
        `SELECT 1 FROM "LOGIN_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LOGIN_NAME"=$2 LIMIT 1`,
        input.scope.tenantId,
        listedUser,
      );
      if (!login || listedUser.length > 15)
        throw new EmployeeMasterValidationError(`user ${listedUser} is not in the user list`);
    }
    if (account) {
      const [found] = await tx.$queryRawUnsafe(
        `SELECT 1 FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 LIMIT 1`,
        input.scope.tenantId,
        input.scope.coCode,
        account,
      );
      if (!found)
        throw new EmployeeMasterValidationError(`account ${account} is not in the account master`);
    }
    await tx.$executeRawUnsafe(
      `DELETE FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3`,
      input.scope.tenantId,
      input.scope.coCode,
      code,
    );
    await insertRowTx(tx, 'EMP_MAST', input.scope.tenantId, {
      CO_CODE: input.scope.coCode,
      EMP_CODE: code,
      EMP_NAME: name.slice(0, 40),
      EMP_AC: account,
      // Conversion.Val of the boxes, stored as typed (:1503-1504); the screen shows them as 0.00.
      EMP_AMT: vbVal(input.amount),
      DAY_HOURS: vbVal(input.dayHours),
      USER_NAME: listedUser || BLANK_USER,
      // CLEAR_DATA makes a new entry the operator's (:1253); DISPLAY_DATA keeps an opened one's creator (:1293).
      MAIN_USER:
        input.entryMode === 'E' && same ? text(same.MAIN_USER) : text(input.mainUser).slice(0, 15),
      EMP_TYPE: same?.EMP_TYPE ?? null,
      TDS_PRC: same?.TDS_PRC ?? 0,
      TDS_AMT: same?.TDS_AMT ?? 0,
      PF_PRC: same?.PF_PRC ?? 0,
      PF_AMT: same?.PF_AMT ?? 0,
    });
  });
  return { code };
}

/**
 * BtnDelete_Click deletes the code in the box. An opened employee sends the version read with it, which must still be
 * current; a code that was not opened (the next code of a new entry) is deleted as the desktop does, by code.
 */
export async function deleteEmployee(
  prisma: any,
  scope: EmployeeScope,
  code: string,
  expectedVersion?: unknown,
): Promise<{ code: string; deleted: number }> {
  const key = typed(code);
  if (!key) throw new EmployeeMasterValidationError(DESKTOP_MESSAGES.EMPLOYEE_SELECT_FOR_DELETE);
  if (key === EMPLOYEE_DEFAULT_CODE)
    throw new EmployeeMasterValidationError(DESKTOP_MESSAGES.EMPLOYEE_DEFAULT_UNDELETABLE);
  const expected =
    expectedVersion == null || expectedVersion === '' ? null : requiredVersion(expectedVersion);
  const deleted = await withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await lockTx(tx, scope);
    if (expected && (await employeeVersionTx(tx, scope, key)) !== expected)
      throw new EmployeeVersionConflictError();
    return tx.$executeRawUnsafe(
      `DELETE FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3`,
      scope.tenantId,
      scope.coCode,
      key,
    );
  });
  return { code: key, deleted: Number(deleted) };
}

/**
 * The account box's lookup (tEmpAc_KeyDown, MS_EMP.cs:1631-1680): a code typed exactly is taken from AC_MAST whatever
 * its group (:1640), and the help lists the accounts of groups 09, 10 and 45 except 00020, ordered by group and
 * name (:1644).
 */
export async function employeeAccounts(
  prisma: any,
  scope: EmployeeScope,
  term: string,
  limit = 20,
): Promise<Array<{ code: string; name: string; group: string }>> {
  const typedTerm = text(term);
  const rows: any[] = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT "AC_CODE","AC_NAME","AC_GR" FROM "AC_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2
          AND ("AC_CODE"=$3
               OR ("AC_GR" IN ('09','10','45') AND "AC_CODE"<>'00020'
                   AND ("AC_CODE" ILIKE $4 OR "AC_NAME" ILIKE $5)))
        ORDER BY ("AC_CODE"=$3) DESC, "AC_GR", "AC_NAME"
        LIMIT $6`,
      scope.tenantId,
      scope.coCode,
      typedTerm.toUpperCase(),
      `${typedTerm}%`,
      `%${typedTerm}%`,
      Math.min(Math.max(Number(limit) || 20, 1), 50),
    ),
  );
  return rows.map((row) => ({
    code: text(row.AC_CODE),
    name: text(row.AC_NAME),
    group: text(row.AC_GR),
  }));
}

/** The rows BtnPrint_Click hands to the EmpMast report for the company (MS_EMP.cs:1593-1594). */
export async function employeePrintRows(
  prisma: any,
  scope: EmployeeScope,
): Promise<
  Array<{
    code: string;
    name: string;
    user: string;
    account: string;
    amount: number;
    dayHours: number;
  }>
> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "EMP_CODE","EMP_NAME","USER_NAME","EMP_AC",coalesce("EMP_AMT",0)::float8 amt,
              coalesce("DAY_HOURS",0)::float8 hours
         FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "EMP_CODE","row_id"`,
      scope.tenantId,
      scope.coCode,
    );
    return rows.map((row) => ({
      code: text(row.EMP_CODE),
      name: text(row.EMP_NAME),
      user: text(row.USER_NAME),
      account: text(row.EMP_AC),
      amount: Number(row.amt),
      dayHours: Number(row.hours),
    }));
  });
}
