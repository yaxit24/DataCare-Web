import { withTxBudget } from '../shared/txBudget.js';
import { insertRowTx } from '../posting/posting.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { requiredVersion, versionOf } from '../vouchers/version.js';

/**
 * Product master (desktop MS_PRODUCT with CurMast = 'Product', menu Master → Product; MDI_FORM.cs:7620-7628 opens the
 * form after setting MsUserRightForm to the menu caption, :7111, which MS_PRODUCT_Load keeps as CurMast and shows as
 * the title). One PRODUCT_MAST row per two-character product code; an item names its product in ITEM_MAST.PR_CODE.
 *
 * - The list is every product of the company ordered by code (MS_PRODUCT_Load, MS_PRODUCT.cs:2142), shown as
 *   Code / Name (DGV_FILL :2170-2215); a search keeps the names that start with the typed text (:2506-2527).
 * - BtnSave_Click (:2570-2665) needs the edit right only for an opened product (:2583-2587), refuses a blank code
 *   ("Enter Product Code.", :2600) and name ("Enter Product Name.", :2617) and a one-character code ("Please Insert
 *   Product Code 2 Digit...", :2650-2653), then deletes the code's row and inserts CO_CODE, PR_CODE, PR_NAME, MAIN_USER
 *   and DATA_TRFR 'N' (:2655-2657). MAIN_USER is the signed-in user on every save: CLEAR_DATA sets MainUser (:2230) and
 *   DISPLAY_DATA never reads it back for a product.
 * - Leaving the code refuses a code another product has, and leaving the name a name another code has
 *   (tPrCode_Validating :2395-2432, tPrName_Validating :2467-2504).
 * - BtnDelete_Click (:2706-2804) needs the delete right, refuses a blank code ("Please Select Product For Delete."),
 *   asks "Are You Sure To Delete This Record now?", and then refuses a product an item uses ("You Cant Delete Record
 *   This Product Use in Itme Master....", :2775-2781) and the default products DM, EM, FN, HM, OG, OR, OS, OT, RD and SN
 *   ("You Cant Delete Record, This Product Is Default Product....", :2782-2795).
 * - BtnPrint_Click (:1914-1917) does nothing.
 *
 * Deliberate differences, recorded on the gap: the delete and insert of a save run in one transaction; a name over the
 * box's 40 characters is refused; an opened product carries the version read with it (N51 tokens), so a save or
 * delete after another operator's change is refused with 409.
 */
export class ProductMasterValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'ProductMasterValidationError';
  }
}

export class ProductVersionConflictError extends Error {
  readonly code = 'product-version-conflict';
  readonly statusCode = 409;
  constructor() {
    super(
      'This product was changed by someone else after you opened it. Open it again before saving or deleting.',
    );
    this.name = 'ProductVersionConflictError';
  }
}

export interface ProductScope {
  tenantId: string;
  coCode: string;
}

/** The products BtnDelete_Click never deletes (MS_PRODUCT.cs:2782-2795). */
export const DEFAULT_PRODUCTS = [
  'DM',
  'EM',
  'FN',
  'HM',
  'OG',
  'OR',
  'OS',
  'OT',
  'RD',
  'SN',
] as const;

export interface ProductSaveInput {
  scope: ProductScope;
  /** The signed-in user, written as MAIN_USER on every save (CLEAR_DATA, MS_PRODUCT.cs:2230). */
  user: string;
  /** 'A' for a new product, 'E' for one opened from the list (the desktop's EntryMode). */
  entryMode: 'A' | 'E';
  code: string;
  name: string;
  /** The version read when the product was opened; required for an opened one ('E'). */
  expectedVersion?: unknown;
}

const text = (value: unknown): string => String(value ?? '').trim();
/** UT_TASTING_KeyPress upper-cases every key and drops the apostrophe (MS_PRODUCT.cs:2361-2377). */
const typed = (value: unknown): string => text(value).toUpperCase().replace(/'/g, '');

/** Desktop text of tPrCode_Validating for a product (MS_PRODUCT.cs:2421). */
export const productCodeTakenMessage = (name: string): string =>
  `This Product Code already Exist in  '${name}'  Product Name...Please Change Pr Code...`;
/** Desktop text of tPrName_Validating for a product (MS_PRODUCT.cs:2493). */
export const productNameTakenMessage = (code: string): string =>
  `This Product Name already Exist in  '${code}'  Product Code...Please Change Pr Name...`;

const lockTx = (tx: any, scope: ProductScope) =>
  tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `product-master:${scope.tenantId}:${scope.coCode}`,
  );

/** SHA-256 of the code's PRODUCT_MAST rows (row ids included, so every save issues a new version). */
async function productVersionTx(tx: any, scope: ProductScope, code: string): Promise<string> {
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT row_id::text,"PR_CODE","PR_NAME","MAIN_USER","DATA_TRFR" FROM "PRODUCT_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "PR_CODE"=$3 ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  return versionOf({ PRODUCT_MAST: rows });
}

export async function listProducts(
  prisma: any,
  scope: ProductScope,
): Promise<{ rows: Array<{ code: string; name: string }> }> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: Array<{ PR_CODE: string | null; PR_NAME: string | null }> =
      await tx.$queryRawUnsafe(
        `SELECT "PR_CODE","PR_NAME" FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
          ORDER BY "PR_CODE","row_id"`,
        scope.tenantId,
        scope.coCode,
      );
    return { rows: rows.map((row) => ({ code: text(row.PR_CODE), name: text(row.PR_NAME) })) };
  });
}

export async function getProduct(
  prisma: any,
  scope: ProductScope,
  codeRaw: string,
): Promise<{ code: string; name: string; items: number; version: string } | null> {
  const code = typed(codeRaw);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const [row] = await tx.$queryRawUnsafe(
      `SELECT "PR_NAME" FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "PR_CODE"=$3
        ORDER BY row_id LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      code,
    );
    if (!row) return null;
    const [{ n }] = await tx.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "PR_CODE"=$3`,
      scope.tenantId,
      scope.coCode,
      code,
    );
    return {
      code,
      name: text(row.PR_NAME),
      items: Number(n),
      version: await productVersionTx(tx, scope, code),
    };
  });
}

export async function saveProduct(prisma: any, input: ProductSaveInput): Promise<{ code: string }> {
  const code = typed(input.code);
  const name = typed(input.name);
  if (!code) throw new ProductMasterValidationError(DESKTOP_MESSAGES.PRODUCT_CODE_REQUIRED);
  if (!name) throw new ProductMasterValidationError(DESKTOP_MESSAGES.PRODUCT_DESC_REQUIRED);
  if (code.length === 1)
    throw new ProductMasterValidationError(DESKTOP_MESSAGES.PRODUCT_CODE_TWO_DIGITS);
  if (code.length > 2) throw new ProductMasterValidationError('product code must be 2 characters');
  if (name.length > 40)
    throw new ProductMasterValidationError('product name must be at most 40 characters');
  const expected = input.entryMode === 'E' ? requiredVersion(input.expectedVersion) : null;
  await withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    const { tenantId, coCode } = input.scope;
    await lockTx(tx, input.scope);
    if (expected && (await productVersionTx(tx, input.scope, code)) !== expected)
      throw new ProductVersionConflictError();
    const products: Array<{ PR_CODE: string | null; PR_NAME: string | null }> =
      await tx.$queryRawUnsafe(
        `SELECT "PR_CODE","PR_NAME" FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY row_id`,
        tenantId,
        coCode,
      );
    const same = products.find((row) => text(row.PR_CODE) === code);
    // tPrCode_Validating: a code already used by another name is refused on a new entry.
    if (same && input.entryMode === 'A' && text(same.PR_NAME).toUpperCase() !== name)
      throw new ProductMasterValidationError(productCodeTakenMessage(text(same.PR_NAME)));
    // An opened product that another operator deleted meanwhile is not brought back.
    if (!same && input.entryMode === 'E') throw new ProductVersionConflictError();
    // tPrName_Validating: a name already used by another code is refused.
    const namesake = products.find(
      (row) => text(row.PR_NAME).toUpperCase() === name && text(row.PR_CODE) !== code,
    );
    if (namesake)
      throw new ProductMasterValidationError(productNameTakenMessage(text(namesake.PR_CODE)));
    await tx.$executeRawUnsafe(
      `DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "PR_CODE"=$3`,
      tenantId,
      coCode,
      code,
    );
    await insertRowTx(tx, 'PRODUCT_MAST', tenantId, {
      CO_CODE: coCode,
      PR_CODE: code,
      PR_NAME: name,
      MAIN_USER: input.user,
      DATA_TRFR: 'N',
    });
  });
  return { code };
}

/**
 * BtnDelete_Click deletes the product in the box after the question, unless an item uses it or it is a default product.
 * An opened product sends the version read with it, which must still be current.
 */
export async function deleteProduct(
  prisma: any,
  scope: ProductScope,
  codeRaw: string,
  expectedVersion?: unknown,
): Promise<{ code: string; deleted: number }> {
  const code = typed(codeRaw);
  if (!code) throw new ProductMasterValidationError(DESKTOP_MESSAGES.PRODUCT_SELECT_FOR_DELETE);
  const expected =
    expectedVersion == null || expectedVersion === '' ? null : requiredVersion(expectedVersion);
  const deleted = await withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await lockTx(tx, scope);
    if (expected && (await productVersionTx(tx, scope, code)) !== expected)
      throw new ProductVersionConflictError();
    const [used] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "PR_CODE"=$3 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      code,
    );
    if (used) throw new ProductMasterValidationError(DESKTOP_MESSAGES.PRODUCT_IN_ITEM_MASTER);
    if ((DEFAULT_PRODUCTS as readonly string[]).includes(code))
      throw new ProductMasterValidationError(DESKTOP_MESSAGES.PRODUCT_DEFAULT);
    return tx.$executeRawUnsafe(
      `DELETE FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "PR_CODE"=$3`,
      scope.tenantId,
      scope.coCode,
      code,
    );
  });
  return { code, deleted: Number(deleted) };
}
