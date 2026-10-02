import { withTxBudget } from '../shared/txBudget.js';
import {
  canonicalFormsForRight,
  formKey,
  getFormEntry,
  type FormCatalogEntry,
} from './formCatalog.js';

/** Per-form rights stored in desktop USER_SET. */
export interface FormRight {
  mainMenu: string;
  subMenu: string;
  view: boolean;
  edit: boolean;
  del: boolean;
  print: boolean;
}
const Y = (v: unknown): boolean => String(v ?? '').toUpperCase() === 'Y';
const yn = (b: unknown): string => (b ? 'Y' : 'N');

export async function getUserFormRights(
  prisma: any,
  scope: { tenantId: string; lcCode: string },
  userName: string,
): Promise<FormRight[]> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "MAIN_MENU" mm, "SUB_MENU" sm, "FRM_VIEW" v, "FRM_EDIT" e,
              "FRM_DELETE" d, "FRM_PRINT" p
         FROM "USER_SET"
        WHERE "LC_CODE"=$1 AND "USER_NAME"=$2
        ORDER BY "MAIN_SRNO", "SUB_SRNO", "row_id"`,
      scope.lcCode,
      userName,
    );
    return rows.map((r) => ({
      mainMenu: String(r.mm ?? ''),
      subMenu: String(r.sm ?? ''),
      view: Y(r.v),
      edit: Y(r.e),
      del: Y(r.d),
      print: Y(r.p),
    }));
  });
}

export interface FormRightInput {
  mainMenu: string;
  subMenu?: string;
  view?: boolean;
  edit?: boolean;
  del?: boolean;
  print?: boolean;
}

export class FormRightsValidationError extends Error {
  constructor(public invalidForms: string[]) {
    super(`invalid-form-rights: ${invalidForms.join(',')}`);
    this.name = 'FormRightsValidationError';
  }
}

const resolveCatalogEntry = (row: FormRightInput): FormCatalogEntry | undefined => {
  const mainMenu = String(row.mainMenu ?? '').trim();
  const subMenu = String(row.subMenu ?? '').trim();
  return getFormEntry(formKey(mainMenu, subMenu));
};

/**
 * Replace rights only for the selected location. Empty rows intentionally mean no form access for a
 * non-admin; it no longer doubles as an implicit full-access grant.
 */
export async function setUserFormRights(
  prisma: any,
  scope: { tenantId: string; coCode: string; lcCode: string },
  userName: string,
  rows: FormRightInput[],
): Promise<{ saved: number }> {
  const clean = (rows ?? []).filter((r) => r && String(r.mainMenu ?? '').trim());
  const invalid = clean
    .filter((row) => !resolveCatalogEntry(row))
    .map((row) => formKey(String(row.mainMenu ?? ''), String(row.subMenu ?? '')));
  if (invalid.length) throw new FormRightsValidationError(invalid);

  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const users: unknown[] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "LOGIN_MAST" WHERE "CO_CODE"=$1 AND "LOGIN_NAME"=$2 LIMIT 1`,
      scope.coCode,
      userName,
    );
    if (!users.length) throw new FormRightsValidationError([`unknown-user:${userName}`]);
    await tx.$executeRawUnsafe(
      `DELETE FROM "USER_SET" WHERE "LC_CODE"=$1 AND "USER_NAME"=$2`,
      scope.lcCode,
      userName,
    );
    let i = 0;
    for (const r of clean) {
      const entry = resolveCatalogEntry(r)!;
      i += 1;
      await tx.$executeRawUnsafe(
        `INSERT INTO "USER_SET"(
           tenant_id,"CO_CODE","LC_CODE","MAIN_SRNO","SUB_SRNO","USER_NAME","MAIN_MENU",
           "SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT"
         ) VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12)`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        i,
        String(i),
        userName,
        entry.mainMenu,
        entry.subMenu,
        yn(r.view ?? false),
        yn(r.edit ?? false),
        yn(r.del ?? false),
        yn(r.print ?? false),
      );
    }
    return { saved: i };
  });
}

/**
 * Return canonical navigation keys. Only an explicitly identified admin is unrestricted (`null`).
 * A non-admin with no USER_SET rows receives `[]`, matching the desktop's missing-row denial.
 */
export async function resolveAllowedForms(
  prisma: any,
  scope: { tenantId: string; lcCode: string },
  userName: string,
  isAdmin: boolean,
): Promise<string[] | null> {
  if (isAdmin) return null;
  const rows = await getUserFormRights(prisma, scope, userName);
  const allowed = new Set<string>();
  for (const row of rows) {
    if (!row.view) continue;
    const canonical = canonicalFormsForRight(row.subMenu);
    if (canonical.length) {
      for (const key of canonical) allowed.add(key);
    } else {
      // Preserve a web-created or future form key even if the catalog has not yet learned an alias.
      allowed.add(formKey(row.mainMenu, row.subMenu));
    }
  }
  return [...allowed];
}
