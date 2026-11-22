import { withTxBudget, type Tx } from '../shared/txBudget.js';
import { assertStrongPassword, hashPassword, verifyWithMigration } from '../auth/password.js';
import { FORM_CATALOG } from './formCatalog.js';
import { isAdminRole, LastAdministratorValidationError } from './users.js';

/**
 * User Create (desktop MS_USER), the writer behind the screen's Save and Delete.
 *
 * Desktop (MS_USER.cs):
 *  - Save (:1820-2065): a blank Create New User box says "Please Enter User Name."; the LOGIN_MAST row is written with
 *    the company, the name, the password, the first letter of the user type ('U' or 'A') and MAIN_USER, the operator
 *    (:1981-1997); a new user (EntryMode 'A') also gets USER_SET rows for every menu with View, Edit, Delete and Print
 *    all 'Y', for location '00' and the operator's location (:2012-2040); both modes answer "User Are Created." (:1942).
 *  - Leaving the name box refuses a name that exists, in add mode (:2131-2150); leaving Confirm Password refuses a
 *    different password (:2205-2220); leaving Old Password of an existing user refuses a blank or different old password
 *    (:2222-2253). The server repeats each check, so a request that skips the screen gets the same refusal.
 *  - Delete (:2067-2093) removes the LOGIN_MAST and USER_SET rows and says "Delete Success.".
 *
 * Web (decisions D34, D35, D36 in document 12 §4): the password is stored as an Argon2id hash and must pass the D34 rule;
 * Delete deactivates the login (LOGIN_ACTIVE 'N') and revokes every session and refresh token of the user in the same
 * transaction; rows stay, so vouchers and the audit keep the user code; the last administrator cannot be deleted
 * (N169/G178); saving a new user under a deleted user's name reactivates that login with the new password and type and
 * the rights seeded afresh, which is the desktop's result of creating a user whose rows were deleted.
 * Not ported: the plaintext LOGIN_PWD, F1 in Old Password showing the stored password (:2153-2167), the ABC reset tool
 * (:5269-5307).
 */

export const USER_TEXT = Object.freeze({
  CREATED: 'User Are Created.',
  NAME_REQUIRED: 'Please Enter User Name.',
  NAME_EXISTS: 'This User Name already Exist.Please Change User Name...',
  PASSWORD_MISMATCH: 'Password Not Match',
  OLD_PASSWORD_REQUIRED: 'Please Insert Old Password',
  OLD_PASSWORD_WRONG: "Old Password Doesn't Match",
  SELECT_FOR_DELETE: 'Please Select User For Delete.',
  DELETE_CONFIRM: 'Are You Sure To Delete This User now?',
  DELETED: 'Delete Success.',
  NO_RIGHTS: 'You Have No Rights.....',
  NO_PRINT_RIGHTS: 'You Have No Print Rights.....',
});

/** tUserName.MaxLength (MS_USER.cs:1087); MAIN_USER and DEACTIVATED_BY are varchar(15) too. */
export const USER_NAME_MAX = 15;

export interface UserMasterScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
}

/** A refusal with the desktop's text. `field` names the box the cursor returns to. */
export class UserMasterValidationError extends Error {
  constructor(
    message: string,
    public field: 'loginName' | 'oldPassword' | 'newPassword' | 'confirmPassword' | 'userType',
    public statusCode = 400,
  ) {
    super(message);
    this.name = 'UserMasterValidationError';
  }
}

export class UserMasterNotFoundError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'UserMasterNotFoundError';
  }
}

/** cboUserTyp holds "User" and "Admin"; LOGIN_CATG takes the first letter (Strings.Mid(cboUserTyp.Text, 1, 1)). */
export function desktopUserType(value: unknown): 'U' | 'A' | '' {
  const text = String(value ?? '')
    .trim()
    .toUpperCase();
  if (text === 'U' || text === 'USER') return 'U';
  if (text === 'A' || text === 'ADMIN') return 'A';
  return '';
}

const nameOf = (value: unknown) => String(value ?? '').trim();

function assertName(loginName: string): void {
  if (!loginName) throw new UserMasterValidationError(USER_TEXT.NAME_REQUIRED, 'loginName');
  if (loginName.length > USER_NAME_MAX || loginName.includes("'"))
    throw new UserMasterValidationError(USER_TEXT.NAME_REQUIRED, 'loginName');
}

/** Serialise every writer of one company's logins, so a duplicate check and its insert cannot interleave (T12). */
async function lockCompanyLogins(tx: Tx, scope: UserMasterScope): Promise<void> {
  await tx.$executeRawUnsafe(
    `SELECT pg_advisory_xact_lock(hashtextextended('LOGIN_MAST:' || $1 || ':' || $2, 0))`,
    scope.tenantId,
    scope.coCode,
  );
}

interface LoginRow {
  rowId: string;
  LOGIN_NAME: string;
  LOGIN_PWD: string | null;
  LOGIN_CATG: string | null;
  LOGIN_ACTIVE: string;
}

/** The company's row for a name, matched without regard to case as the desktop's DataView filter does. */
async function findLogin(tx: Tx, scope: UserMasterScope, loginName: string): Promise<LoginRow[]> {
  return tx.$queryRawUnsafe<LoginRow[]>(
    `SELECT "row_id"::text AS "rowId","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","LOGIN_ACTIVE"
       FROM "LOGIN_MAST" WHERE "CO_CODE"=$1 AND upper("LOGIN_NAME")=upper($2)
      ORDER BY "row_id" FOR UPDATE`,
    scope.coCode,
    loginName,
  );
}

/** USER_SET for one location: every menu of the catalogue, all four rights 'Y' (:2012-2040, D36). */
async function seedRights(
  tx: Tx,
  scope: UserMasterScope,
  lcCode: string,
  loginName: string,
): Promise<void> {
  await tx.$executeRawUnsafe(
    `DELETE FROM "USER_SET" WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 AND "USER_NAME"=$3`,
    scope.coCode,
    lcCode,
    loginName,
  );
  let index = 0;
  for (const form of FORM_CATALOG) {
    index += 1;
    await tx.$executeRawUnsafe(
      `INSERT INTO "USER_SET"(
         tenant_id,"CO_CODE","LC_CODE","MAIN_SRNO","SUB_SRNO","USER_NAME","MAIN_MENU",
         "SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT"
       ) VALUES ($1,$2,$3,$4,$5,$6,$7,$8,'Y','Y','Y','Y')`,
      scope.tenantId,
      scope.coCode,
      lcCode,
      index,
      String(index),
      loginName,
      form.mainMenu,
      form.subMenu,
    );
  }
}

/** The locations the desktop seeds: the template location '00' and the operator's own (:2012-2040). */
const seededLocations = (scope: UserMasterScope) => [...new Set(['00', scope.lcCode])];

export interface CreateDesktopUserInput {
  loginName: string;
  password: string;
  /** Omitted only by callers that confirm elsewhere; the screen always sends it. */
  confirmPassword?: string;
  userType: string;
  /** MAIN_USER: the operator saving the user (MainUser = MCo_User, :1569). */
  mainUser: string;
}

/** Save in add mode. A deleted login of the same name is reactivated (D35). */
export async function createDesktopUser(
  prisma: any,
  scope: UserMasterScope,
  input: CreateDesktopUserInput,
): Promise<{ created: true; loginName: string; userType: 'U' | 'A'; message: string }> {
  const loginName = nameOf(input.loginName);
  assertName(loginName);
  const password = typeof input.password === 'string' ? input.password : '';
  if (input.confirmPassword !== undefined && input.confirmPassword !== password)
    throw new UserMasterValidationError(USER_TEXT.PASSWORD_MISMATCH, 'confirmPassword');
  const userType = desktopUserType(input.userType);
  if (!userType) throw new UserMasterValidationError(USER_TEXT.NAME_REQUIRED, 'userType');
  assertStrongPassword(password, { loginName, coCode: scope.coCode });
  const passwordHash = await hashPassword(password);
  const mainUser = nameOf(input.mainUser).slice(0, USER_NAME_MAX) || null;

  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx) => {
    await lockCompanyLogins(tx, scope);
    const existing = await findLogin(tx, scope, loginName);
    if (existing.some((row) => row.LOGIN_ACTIVE === 'Y'))
      throw new UserMasterValidationError(USER_TEXT.NAME_EXISTS, 'loginName', 409);
    const deleted = existing[0];
    // A reactivated login keeps its original spelling, so its vouchers and audit rows still name it.
    const storedName = deleted?.LOGIN_NAME ?? loginName;
    if (deleted) {
      await tx.$executeRawUnsafe(
        `UPDATE "LOGIN_MAST"
            SET "LOGIN_PWD"=$1,"LOGIN_CATG"=$2,"MAIN_USER"=$3,"USER_UPDATE"='Y',"USER_DELETE"='Y',
                "USER_PRINT"='Y',"PASSWORD_RESET_REQUIRED"='N',"PASSWORD_CHANGED_AT"=clock_timestamp(),
                "LOGIN_ACTIVE"='Y',"DEACTIVATED_AT"=NULL,"DEACTIVATED_BY"=NULL,
                "FAILED_LOGIN_COUNT"=0,"LOGIN_BLOCKED_UNTIL"=NULL
          WHERE "row_id"=$4::bigint`,
        passwordHash,
        userType,
        mainUser,
        deleted.rowId,
      );
    } else {
      await tx.$executeRawUnsafe(
        `INSERT INTO "LOGIN_MAST"(
           tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","MAIN_USER",
           "USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED","PASSWORD_CHANGED_AT"
         ) VALUES ($1,$2,$3,$4,$5,$6,'Y','Y','Y','N',clock_timestamp())`,
        scope.tenantId,
        scope.coCode,
        storedName,
        passwordHash,
        userType,
        mainUser,
      );
    }
    for (const lcCode of seededLocations(scope)) await seedRights(tx, scope, lcCode, storedName);
    return { created: true as const, loginName: storedName, userType, message: USER_TEXT.CREATED };
  });
}

export interface UpdateDesktopUserInput {
  oldPassword: string;
  /** Blank keeps the current password (the desktop would store a blank one; not ported). */
  newPassword?: string;
  confirmPassword?: string;
  userType: string;
}

/**
 * Save in edit mode: the old password must be given and match (tOldPasword_Validating, :2222-2253); a new password must
 * match Confirm and pass D34; the user type may change unless that would leave the company without an administrator.
 * A changed password revokes every other session of the user, as the web's own password change does.
 */
export async function updateDesktopUser(
  prisma: any,
  scope: UserMasterScope,
  loginName: string,
  input: UpdateDesktopUserInput,
  actor: { sessionId: string },
): Promise<{ updated: true; loginName: string; userType: 'U' | 'A'; message: string }> {
  const name = nameOf(loginName);
  assertName(name);
  const oldPassword = typeof input.oldPassword === 'string' ? input.oldPassword : '';
  if (!oldPassword)
    throw new UserMasterValidationError(USER_TEXT.OLD_PASSWORD_REQUIRED, 'oldPassword');
  const newPassword = typeof input.newPassword === 'string' ? input.newPassword : '';
  const confirm = typeof input.confirmPassword === 'string' ? input.confirmPassword : '';
  if (newPassword !== confirm)
    throw new UserMasterValidationError(USER_TEXT.PASSWORD_MISMATCH, 'confirmPassword');
  const userType = desktopUserType(input.userType);
  if (!userType) throw new UserMasterValidationError(USER_TEXT.NAME_REQUIRED, 'userType');
  if (newPassword) assertStrongPassword(newPassword, { loginName: name, coCode: scope.coCode });
  const nextHash = newPassword ? await hashPassword(newPassword) : null;

  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx) => {
    await lockCompanyLogins(tx, scope);
    const row = (await findLogin(tx, scope, name)).find((r) => r.LOGIN_ACTIVE === 'Y');
    if (!row) throw new UserMasterNotFoundError(USER_TEXT.SELECT_FOR_DELETE);
    // A desktop-era plaintext password still compares (verifyWithMigration); it is replaced only by a new password.
    if (!row.LOGIN_PWD || !(await verifyWithMigration(row.LOGIN_PWD, oldPassword)).ok)
      throw new UserMasterValidationError(USER_TEXT.OLD_PASSWORD_WRONG, 'oldPassword');
    if (isAdminRole(row.LOGIN_CATG) && userType !== 'A')
      await assertAnotherAdministrator(tx, scope, row.LOGIN_NAME);
    const sameType = desktopUserType(row.LOGIN_CATG) === userType;
    // An unchanged save writes nothing: the footprint stays as it was (T08).
    if (!nextHash && sameType)
      return {
        updated: true as const,
        loginName: row.LOGIN_NAME,
        userType,
        message: USER_TEXT.CREATED,
      };
    await tx.$executeRawUnsafe(
      `UPDATE "LOGIN_MAST"
          SET "LOGIN_CATG"=$1,
              "LOGIN_PWD"=COALESCE($2,"LOGIN_PWD"),
              "PASSWORD_CHANGED_AT"=CASE WHEN $2::text IS NULL THEN "PASSWORD_CHANGED_AT" ELSE clock_timestamp() END,
              "PASSWORD_RESET_REQUIRED"=CASE WHEN $2::text IS NULL THEN "PASSWORD_RESET_REQUIRED" ELSE 'N' END
        WHERE "row_id"=$3::bigint`,
      sameType ? row.LOGIN_CATG : userType,
      nextHash,
      row.rowId,
    );
    if (nextHash)
      await tx.$executeRawUnsafe(
        `UPDATE "auth_session" SET "revoked_at"=clock_timestamp(),"revoke_reason"='password-changed'
          WHERE "login_name"=$1 AND "login_co_code"=$2 AND "revoked_at" IS NULL AND "session_id"<>$3`,
        row.LOGIN_NAME,
        scope.coCode,
        actor.sessionId,
      );
    return {
      updated: true as const,
      loginName: row.LOGIN_NAME,
      userType,
      message: USER_TEXT.CREATED,
    };
  });
}

/** N169/G178: the company keeps at least one active administrator. Locks the admins' rows. */
async function assertAnotherAdministrator(
  tx: Tx,
  scope: UserMasterScope,
  loginName: string,
): Promise<void> {
  const admins = await tx.$queryRawUnsafe<Array<{ LOGIN_NAME: string }>>(
    `SELECT "LOGIN_NAME" FROM "LOGIN_MAST"
      WHERE "CO_CODE"=$1 AND "LOGIN_ACTIVE"='Y' AND upper(coalesce("LOGIN_CATG",'')) LIKE 'A%'
      ORDER BY "row_id" FOR UPDATE`,
    scope.coCode,
  );
  if (!admins.some((row) => row.LOGIN_NAME.toUpperCase() !== loginName.toUpperCase()))
    throw new LastAdministratorValidationError(loginName);
}

/**
 * Delete (D35): the login becomes inactive and every session of it (and so its refresh token, which lives on the
 * session row) is revoked in the same transaction. LOGIN_MAST and USER_SET rows stay.
 */
export async function deactivateDesktopUser(
  prisma: any,
  scope: UserMasterScope,
  loginName: string,
  actor: { loginName: string },
): Promise<{ deleted: true; loginName: string; revokedSessions: number; message: string }> {
  const name = nameOf(loginName);
  if (!name) throw new UserMasterValidationError(USER_TEXT.SELECT_FOR_DELETE, 'loginName');
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx) => {
    await lockCompanyLogins(tx, scope);
    const row = (await findLogin(tx, scope, name)).find((r) => r.LOGIN_ACTIVE === 'Y');
    if (!row) throw new UserMasterNotFoundError(USER_TEXT.SELECT_FOR_DELETE);
    if (isAdminRole(row.LOGIN_CATG)) await assertAnotherAdministrator(tx, scope, row.LOGIN_NAME);
    await tx.$executeRawUnsafe(
      `UPDATE "LOGIN_MAST"
          SET "LOGIN_ACTIVE"='N',"DEACTIVATED_AT"=clock_timestamp(),"DEACTIVATED_BY"=$1
        WHERE "row_id"=$2::bigint`,
      nameOf(actor.loginName).slice(0, USER_NAME_MAX) || null,
      row.rowId,
    );
    const revoked = Number(
      await tx.$executeRawUnsafe(
        `UPDATE "auth_session" SET "revoked_at"=clock_timestamp(),"revoke_reason"='user-deleted'
          WHERE "login_name"=$1 AND "login_co_code"=$2 AND "revoked_at" IS NULL`,
        row.LOGIN_NAME,
        scope.coCode,
      ),
    );
    return {
      deleted: true as const,
      loginName: row.LOGIN_NAME,
      revokedSessions: revoked,
      message: USER_TEXT.DELETED,
    };
  });
}
