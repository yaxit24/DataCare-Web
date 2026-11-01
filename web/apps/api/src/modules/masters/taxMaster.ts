import { vbVal } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { insertRowTx } from '../posting/posting.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { requiredVersion, versionOf } from '../vouchers/version.js';

/**
 * Tax master (desktop MS_TAX, menu Master → Tax; MDI_FORM.cs:7670-7679 opens the form directly). A tax code is a header
 * row, SR_NO 0 with TAX_GROUP 'N', and its component rows, SR_NO 1, 2, … (SGST, CGST and IGST for a GST code), which the
 * sale and purchase tax postings read by SR_NO (`shared/taxPolicy.ts`, the desktop's Ac_Tax).
 *
 * - The list is the header rows ordered by code (CLEAR_DATA, MS_TAX.cs:1608), shown as Code / Name (DGV_FILL
 *   :1543-1588); a search keeps the names that start with the typed text (Text1_TextChanged :1783-1804, :1793).
 * - DISPLAY_DATA (:1616-1668) shows the header's Tax % and Add Tax % as 0.00, its account with the account name, and the
 *   component rows ordered by SR_NO with Tax % as 0.000; the code box is read-only for an opened code.
 * - BtnSave_Click (:1824-1933) needs the edit right only for an opened code, refuses a blank code ("Enter Tax Code.")
 *   and name ("Enter Tax Name."), deletes every row of the code and writes the header (TAX_GROUP 'N', Val of Tax % and
 *   Add Tax %, the account) and one row per grid row whose Tax % is not zero (:1886), with SR_NO = the grid row (:1889), the row's type,
 *   name, account and Val(Tax %), and the header's Add Tax %. MAIN_USER is not written.
 * - Leaving the code refuses a code another tax has, and leaving the name a name another code has (tTaxCode_Validating
 *   :1720-1740, tTaxName_Validating :1761-1781).
 * - BtnDelete_Click (:1935-1956) needs the delete right, refuses a blank code with "Please Select Tax Code For Delete."
 *   and deletes every row of the code.
 *
 * Deliberate differences from the desktop, recorded on the gap:
 * - Save runs in one transaction. The desktop deletes the code's rows before it inserts, so an insert that fails (a
 *   blank Tax % the DataRow cannot convert) leaves the code deleted; the web reads Val of a blank or text box as 0.
 * - Save refuses an account code that is not in AC_MAST, in the header or a component; the desktop looks a code up only
 *   on Enter. It refuses a name over the box's 40 characters and a component type over its 5.
 * - An opened code carries the version read with it (N51 tokens): a save or delete after another operator's change is
 *   refused with 409 where the desktop's later save wins.
 * - The Input Tax account (INPUT_TAX_AC) is shown and written only for one registration (SSRegSrNo VK195NEPH,
 *   MS_TAX.cs:1518-1527); the web has no such column and leaves it out.
 */
export class TaxMasterValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'TaxMasterValidationError';
  }
}

export class TaxVersionConflictError extends Error {
  readonly code = 'tax-version-conflict';
  readonly statusCode = 409;
  constructor() {
    super(
      'This tax code was changed by someone else after you opened it. Open it again before saving or deleting.',
    );
    this.name = 'TaxVersionConflictError';
  }
}

export interface TaxScope {
  tenantId: string;
  coCode: string;
}

/** One component row of the grid as the screen sends it; its position in the list is its grid row. */
export interface TaxComponentInput {
  taxType?: string;
  name?: string;
  account?: string;
  pct?: number | string;
}

export interface TaxSaveInput {
  scope: TaxScope;
  /** 'A' for a new code, 'E' for one opened from the list (the desktop's EntryMode). */
  entryMode: 'A' | 'E';
  code: string;
  name: string;
  pct?: number | string;
  addPct?: number | string;
  account?: string;
  components?: TaxComponentInput[];
  canUpdate: boolean;
  /** The version read when the code was opened; required for an opened one ('E'). */
  expectedVersion?: unknown;
}

export interface TaxComponent {
  srNo: number;
  taxType: string;
  name: string;
  account: string;
  pct: number;
}

const text = (value: unknown): string => String(value ?? '').trim();
/** MS_TAX_KeyPress upper-cases every key and drops the apostrophe (MS_TAX.cs:1689-1702). */
const typed = (value: unknown): string => text(value).toUpperCase().replace(/'/g, '');

/** Desktop text of tTaxCode_Validating (MS_TAX.cs:1730). */
export const taxCodeTakenMessage = (name: string): string =>
  `This Tax Code already Exist in  '${name}'  Tax Name...Please Change Tax Code...`;
/** Desktop text of tTaxName_Validating (MS_TAX.cs:1771). */
export const taxNameTakenMessage = (code: string): string =>
  `This Tax Name already Exist in  '${code}'  Tax Code...Please Change Tax Name...`;

const lockTx = (tx: any, scope: TaxScope) =>
  tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `tax-master:${scope.tenantId}:${scope.coCode}`,
  );

/** SHA-256 of the code's TAX_MAST rows (row ids included, so every save issues a new version). */
async function taxVersionTx(tx: any, scope: TaxScope, code: string): Promise<string> {
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT r.* FROM "TAX_MAST" r WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAX_CODE"=$3
      ORDER BY to_jsonb(r)::text`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  return versionOf({ TAX_MAST: rows });
}

export async function listTaxes(
  prisma: any,
  scope: TaxScope,
): Promise<{ rows: Array<{ code: string; name: string }> }> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: Array<{ TAX_CODE: string | null; TAX_NAME: string | null }> =
      await tx.$queryRawUnsafe(
        `SELECT "TAX_CODE","TAX_NAME" FROM "TAX_MAST"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND coalesce("SR_NO",0)=0
          ORDER BY "TAX_CODE","row_id"`,
        scope.tenantId,
        scope.coCode,
      );
    return { rows: rows.map((row) => ({ code: text(row.TAX_CODE), name: text(row.TAX_NAME) })) };
  });
}

const accountNameTx = async (tx: any, scope: TaxScope, code: string): Promise<string> => {
  if (!code) return '';
  const [row] = await tx.$queryRawUnsafe(
    `SELECT "AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  return text(row?.AC_NAME);
};

export async function getTax(
  prisma: any,
  scope: TaxScope,
  codeRaw: string,
): Promise<{
  code: string;
  name: string;
  pct: number;
  addPct: number;
  account: string;
  accountName: string;
  components: TaxComponent[];
  version: string;
} | null> {
  const code = typed(codeRaw);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce("SR_NO",0)::float8 sr,"TAX_GROUP","TAX_NAME",coalesce("TAX_PRC",0)::float8 pct,
              coalesce("ADD_TAX_PRC",0)::float8 add_pct,"TAX_AC"
         FROM "TAX_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAX_CODE"=$3
        ORDER BY coalesce("SR_NO",0),"row_id"`,
      scope.tenantId,
      scope.coCode,
      code,
    );
    const header = rows.find((row) => Number(row.sr) === 0);
    if (!header) return null;
    const account = text(header.TAX_AC);
    return {
      code,
      name: text(header.TAX_NAME),
      pct: Number(header.pct),
      addPct: Number(header.add_pct),
      account,
      accountName: await accountNameTx(tx, scope, account),
      components: rows
        .filter((row) => Number(row.sr) > 0)
        .map((row) => ({
          srNo: Number(row.sr),
          taxType: text(row.TAX_GROUP),
          name: text(row.TAX_NAME),
          account: text(row.TAX_AC),
          pct: Number(row.pct),
        })),
      version: await taxVersionTx(tx, scope, code),
    };
  });
}

export async function saveTax(
  prisma: any,
  input: TaxSaveInput,
): Promise<{ code: string; components: number }> {
  const code = typed(input.code);
  const name = typed(input.name);
  if (input.entryMode === 'E' && !input.canUpdate)
    throw new TaxMasterValidationError(DESKTOP_MESSAGES.TAX_NO_RIGHTS);
  if (!code) throw new TaxMasterValidationError(DESKTOP_MESSAGES.TAX_CODE_REQUIRED);
  if (!name) throw new TaxMasterValidationError(DESKTOP_MESSAGES.TAX_DESC_REQUIRED);
  if (code.length > 2) throw new TaxMasterValidationError('tax code must be 1 or 2 characters');
  if (name.length > 40)
    throw new TaxMasterValidationError('tax name must be at most 40 characters');
  const account = typed(input.account);
  const addPct = vbVal(input.addPct);
  // A grid row is written when its Tax % is not zero, under SR_NO = its grid row (:1886-1906).
  const components = (input.components ?? [])
    .map((row, index) => ({
      srNo: index + 1,
      taxType: typed(row.taxType),
      name: typed(row.name),
      account: typed(row.account),
      pct: vbVal(row.pct),
    }))
    .filter((row) => row.pct !== 0);
  for (const row of components) {
    if (row.taxType.length > 5)
      throw new TaxMasterValidationError(
        `tax type of row ${row.srNo} must be at most 5 characters`,
      );
    if (row.name.length > 50)
      throw new TaxMasterValidationError(
        `tax name of row ${row.srNo} must be at most 50 characters`,
      );
    if (row.account.length > 8)
      throw new TaxMasterValidationError(`account of row ${row.srNo} must be at most 8 characters`);
  }
  const expected = input.entryMode === 'E' ? requiredVersion(input.expectedVersion) : null;
  await withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    await lockTx(tx, input.scope);
    if (expected && (await taxVersionTx(tx, input.scope, code)) !== expected)
      throw new TaxVersionConflictError();
    const headers: Array<{ TAX_CODE: string | null; TAX_NAME: string | null }> =
      await tx.$queryRawUnsafe(
        `SELECT "TAX_CODE","TAX_NAME" FROM "TAX_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND coalesce("SR_NO",0)=0 ORDER BY "row_id"`,
        input.scope.tenantId,
        input.scope.coCode,
      );
    const same = headers.find((row) => text(row.TAX_CODE) === code);
    // tTaxCode_Validating: a code already used by another name is refused on a new entry.
    if (same && input.entryMode === 'A' && text(same.TAX_NAME).toUpperCase() !== name)
      throw new TaxMasterValidationError(taxCodeTakenMessage(text(same.TAX_NAME)));
    // An opened code that another operator deleted meanwhile is not brought back.
    if (!same && input.entryMode === 'E') throw new TaxVersionConflictError();
    // tTaxName_Validating: a name already used by another code is refused.
    const namesake = headers.find(
      (row) => text(row.TAX_NAME).toUpperCase() === name && text(row.TAX_CODE) !== code,
    );
    if (namesake) throw new TaxMasterValidationError(taxNameTakenMessage(text(namesake.TAX_CODE)));
    for (const [where, value] of [
      ['the tax', account],
      ...components.map((row) => [`row ${row.srNo}`, row.account] as const),
    ] as const) {
      if (!value) continue;
      const [found] = await tx.$queryRawUnsafe(
        `SELECT 1 FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 LIMIT 1`,
        input.scope.tenantId,
        input.scope.coCode,
        value,
      );
      if (!found)
        throw new TaxMasterValidationError(
          `account ${value} of ${where} is not in the account master`,
        );
    }
    await tx.$executeRawUnsafe(
      `DELETE FROM "TAX_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAX_CODE"=$3`,
      input.scope.tenantId,
      input.scope.coCode,
      code,
    );
    await insertRowTx(tx, 'TAX_MAST', input.scope.tenantId, {
      CO_CODE: input.scope.coCode,
      SR_NO: 0,
      TAX_CODE: code,
      TAX_NAME: name,
      TAX_GROUP: 'N',
      TAX_PRC: vbVal(input.pct),
      ADD_TAX_PRC: addPct,
      TAX_AC: account,
    });
    for (const row of components)
      await insertRowTx(tx, 'TAX_MAST', input.scope.tenantId, {
        CO_CODE: input.scope.coCode,
        SR_NO: row.srNo,
        TAX_CODE: code,
        TAX_GROUP: row.taxType,
        TAX_NAME: row.name,
        TAX_AC: row.account,
        TAX_PRC: row.pct,
        ADD_TAX_PRC: addPct,
      });
  });
  return { code, components: components.length };
}

/**
 * BtnDelete_Click deletes every row of the code in the box. An opened code sends the version read with it, which must
 * still be current; a code that was not opened is deleted as the desktop does, by code.
 */
export async function deleteTax(
  prisma: any,
  scope: TaxScope,
  codeRaw: string,
  expectedVersion?: unknown,
): Promise<{ code: string; deleted: number }> {
  const code = typed(codeRaw);
  if (!code) throw new TaxMasterValidationError(DESKTOP_MESSAGES.TAX_SELECT_FOR_DELETE);
  const expected =
    expectedVersion == null || expectedVersion === '' ? null : requiredVersion(expectedVersion);
  const deleted = await withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await lockTx(tx, scope);
    if (expected && (await taxVersionTx(tx, scope, code)) !== expected)
      throw new TaxVersionConflictError();
    return tx.$executeRawUnsafe(
      `DELETE FROM "TAX_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAX_CODE"=$3`,
      scope.tenantId,
      scope.coCode,
      code,
    );
  });
  return { code, deleted: Number(deleted) };
}

/**
 * The account helps. The header's Ac Code (tTaxAcCode_KeyDown, MS_TAX.cs:2026-2063) takes a code found in AC_MAST
 * whatever its group, else lists group 12 and account 00013 by name (:2039). A component's Ac Code (TEXT_ENTRY_KeyDown
 * :1248-1268, the list at :1252) takes a code found in AC_MAST, else lists every account by name with its group.
 */
export async function taxAccounts(
  prisma: any,
  scope: TaxScope,
  kind: 'header' | 'component',
  term: string,
  limit = 20,
): Promise<Array<{ code: string; name: string; group: string }>> {
  const typedTerm = text(term);
  const filter = kind === 'header' ? `AND ("AC_GR"='12' OR "AC_CODE"='00013')` : '';
  const rows: any[] = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT "AC_CODE","AC_NAME","AC_GR" FROM "AC_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2
          AND ("AC_CODE"=$3 OR (("AC_CODE" ILIKE $4 OR "AC_NAME" ILIKE $5) ${filter}))
        ORDER BY ("AC_CODE"=$3) DESC, "AC_NAME", "AC_CODE"
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

/** The rows BtnPrint_Click hands to the TaxMast report for the company (MS_TAX.cs:1966-1967): every row by code. */
export async function taxPrintRows(
  prisma: any,
  scope: TaxScope,
): Promise<
  Array<{
    code: string;
    srNo: number;
    taxType: string;
    name: string;
    pct: number;
    addPct: number;
    account: string;
  }>
> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "TAX_CODE",coalesce("SR_NO",0)::float8 sr,"TAX_GROUP","TAX_NAME",coalesce("TAX_PRC",0)::float8 pct,
              coalesce("ADD_TAX_PRC",0)::float8 add_pct,"TAX_AC"
         FROM "TAX_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
        ORDER BY "TAX_CODE",coalesce("SR_NO",0),"row_id"`,
      scope.tenantId,
      scope.coCode,
    );
    return rows.map((row) => ({
      code: text(row.TAX_CODE),
      srNo: Number(row.sr),
      taxType: text(row.TAX_GROUP),
      name: text(row.TAX_NAME),
      pct: Number(row.pct),
      addPct: Number(row.add_pct),
      account: text(row.TAX_AC),
    }));
  });
}
