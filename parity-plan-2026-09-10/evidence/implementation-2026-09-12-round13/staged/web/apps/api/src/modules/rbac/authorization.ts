import { withTenant, type Tx } from '@datacare/db';
import type { UserRights } from '@datacare/types';
import { rightsOf, type LoginMastRow } from '../auth/auth.service.js';
import { rightNamesForForm, canonicalFormsForRight } from './formCatalog.js';
import type { RouteAction } from './routePolicy.js';
import { isAdminRole } from './users.js';

export interface Principal {
  loginName: string;
  loginCoCode: string;
  role: string;
  isAdmin: boolean;
  rights: UserRights;
  passwordResetRequired: boolean;
}

export interface FormAuthorization {
  form: string;
  action: RouteAction;
  principal: Principal;
}

export class PrincipalUnavailableError extends Error {
  constructor() {
    super('principal-unavailable');
    this.name = 'PrincipalUnavailableError';
  }
}

export class FormForbiddenError extends Error {
  constructor(
    public form: string,
    public action: RouteAction,
  ) {
    super(`forbidden: ${form} ${action}`);
    this.name = 'FormForbiddenError';
  }
}

const Y = (value: unknown): boolean =>
  ['Y', '1', 'TRUE'].includes(String(value ?? '').toUpperCase());

interface PrincipalRow extends LoginMastRow {
  PASSWORD_RESET_REQUIRED?: string | null;
}

interface PrincipalInput {
  tenantId: string;
  loginName: string;
  coCode: string;
  loginCoCode: string;
}

/**
 * Resolve the user on every authenticated request so role changes, password resets, and deletion
 * take effect immediately rather than waiting for a JWT to expire. The selected company is tried
 * first; `loginCoCode` is the immutable authentication company used when an admin selected another
 * company context.
 */
export async function loadPrincipal(prisma: any, input: PrincipalInput): Promise<Principal> {
  return withTenant(prisma, input.tenantId, (tx) => loadPrincipalTx(tx, input));
}

/** The caller owns the transaction and must already bind input.tenantId through withTenant. */
export async function loadPrincipalTx(tx: Tx, input: PrincipalInput): Promise<Principal> {
  const rows = await tx.$queryRawUnsafe<PrincipalRow[]>(
    `SELECT "CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG",
              "USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED"
         FROM "LOGIN_MAST"
        WHERE "LOGIN_NAME"=$1 AND "CO_CODE" IN ($2,$3)
        ORDER BY CASE WHEN "CO_CODE"=$2 THEN 0 ELSE 1 END
        LIMIT 1`,
    input.loginName,
    input.coCode,
    input.loginCoCode,
  );
  const row = rows[0];
  if (!row?.LOGIN_NAME || !row.CO_CODE) throw new PrincipalUnavailableError();
  const role = String(row.LOGIN_CATG ?? '');
  return {
    loginName: String(row.LOGIN_NAME),
    loginCoCode: String(row.CO_CODE),
    role,
    isAdmin: isAdminRole(role),
    rights: rightsOf(row),
    passwordResetRequired: Y(row.PASSWORD_RESET_REQUIRED),
  };
}

/**
 * Desktop parity: USER_SET is resolved by current LC_CODE + USER_NAME + SUB_MENU. Missing rows do
 * not grant access. Admins are the sole explicit bootstrap bypass (LOGIN_CATG starts with `A`).
 * Creating a new record requires View, while modifying an existing record requires Edit; this
 * preserves the desktop behavior demonstrated by a user who can create a sale but cannot edit it.
 */
export async function authorizeForm(
  prisma: any,
  input: {
    tenantId: string;
    lcCode: string;
    principal: Principal;
    form: string;
    action: RouteAction;
    adminOnly?: boolean;
  },
): Promise<FormAuthorization> {
  if (input.adminOnly && !input.principal.isAdmin) {
    throw new FormForbiddenError(input.form, input.action);
  }
  if (input.principal.isAdmin) {
    return { form: input.form, action: input.action, principal: input.principal };
  }

  const names = rightNamesForForm(input.form);
  const params = [
    input.lcCode,
    input.principal.loginName,
    ...names.map((name) => name.toUpperCase()),
  ];
  const placeholders = names.map((_, index) => `$${index + 3}`).join(',');
  const rows: Array<{
    FRM_VIEW?: string | null;
    FRM_EDIT?: string | null;
    FRM_DELETE?: string | null;
    FRM_PRINT?: string | null;
  }> = await withTenant(prisma, input.tenantId, (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT "FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT"
         FROM "USER_SET"
        WHERE "LC_CODE"=$1 AND "USER_NAME"=$2
          AND UPPER(TRIM(COALESCE("SUB_MENU",''))) IN (${placeholders})
        ORDER BY "row_id"
        LIMIT 1`,
      ...params,
    ),
  );
  const row = rows[0];
  const view = Y(row?.FRM_VIEW);
  const granted =
    view &&
    (input.action === 'read' ||
      input.action === 'create' ||
      (input.action === 'update' && Y(row?.FRM_EDIT)) ||
      (input.action === 'delete' && Y(row?.FRM_DELETE)) ||
      (input.action === 'print' && Y(row?.FRM_PRINT)));
  if (!granted) throw new FormForbiddenError(input.form, input.action);
  return { form: input.form, action: input.action, principal: input.principal };
}

/** Convert raw desktop USER_SET rows to canonical web form keys, including desktop aliases. */
export function canonicalAllowedForms(rows: Array<{ subMenu: string; view: boolean }>): string[] {
  const out = new Set<string>();
  for (const row of rows) {
    if (!row.view) continue;
    for (const key of canonicalFormsForRight(row.subMenu)) out.add(key);
  }
  return [...out];
}
