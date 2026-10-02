import { createHash } from 'node:crypto';
import type { PrismaClient } from '@datacare/db';
import { withTxBudget, SNAPSHOT_READ, type Tx } from '../shared/txBudget.js';
import type {
  SalesOrderDesignList,
  SalesOrderDesignOption,
  SalesOrderDesignSourceRef,
} from '@datacare/core';
import {
  resolveOrderImageTx,
  type OrderImageScope,
  type ResolvedOrderImage,
} from '../images/orderImage.js';
import { resolveBookPolicyTx } from '../shared/bookPolicy.js';

export interface SalesOrderDesignScope {
  tenantId: string;
  coCode: string;
}
export class SalesOrderDesignError extends Error {
  constructor(
    message: string,
    readonly statusCode: 400 | 409 = 400,
  ) {
    super(message);
    this.name = 'SalesOrderDesignError';
  }
}
type SourceRow = {
  PR_CODE: string;
  BOOK_NAME: string;
  SR_NO: number;
  OLD_SRNO: number | null;
  DESIGN_NO: string | null;
  PR_NAME: string | null;
  LABEL_COUNT: number;
  DIE_NO: string | null;
  ITM_SIZE: string | null;
  KR_NAME: string | null;
  ITM_GWT: string | null;
  ITM_TOUCH: string | null;
  ITM_WEST_PRC: string | null;
  LBR_PRC: string | null;
  LBR_RATE: string | null;
  DESIGN_IMG_ID: string | null;
};
const columns = `d."PR_CODE", d."BOOK_NAME", d."SR_NO", d."OLD_SRNO", d."DESIGN_NO",
  p."PR_NAME", p."LABEL_COUNT", d."DIE_NO", d."ITM_SIZE", d."KR_NAME", d."ITM_GWT"::text,
  d."ITM_TOUCH"::text, d."ITM_WEST_PRC"::text, d."LBR_PRC"::text, d."LBR_RATE"::text, d."DESIGN_IMG_ID"`;
const from = `FROM "DESIGN_DETL" d LEFT JOIN LATERAL
  (SELECT min(m."PR_NAME") AS "PR_NAME", count(DISTINCT coalesce(m."PR_NAME",''))::int AS "LABEL_COUNT"
   FROM "PRODUCT_MAST" m WHERE m.tenant_id=d.tenant_id AND m."CO_CODE"=d."CO_CODE" AND m."PR_CODE"=d."PR_CODE") p ON true`;
function scopeValues(scope: SalesOrderDesignScope, itCode: string) {
  if (!scope.tenantId || !scope.coCode?.trim() || !itCode?.trim() || itCode.trim().length > 5)
    throw new SalesOrderDesignError('Select a company and order item before choosing a design.');
  return [scope.tenantId, scope.coCode, itCode.trim()] as const;
}
async function productTx(tx: Tx, scope: SalesOrderDesignScope, itCode: string, lock: boolean) {
  const args = scopeValues(scope, itCode);
  const rows = await tx.$queryRawUnsafe<{ PR_CODE: string | null }[]>(
    `SELECT "PR_CODE" FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3${lock ? ' FOR SHARE' : ''}`,
    ...args,
  );
  const product = rows[0]?.PR_CODE;
  if (rows.length !== 1 || !product?.trim())
    throw new SalesOrderDesignError('The selected order item has no configured product.');
  return product;
}
function option(
  scope: SalesOrderDesignScope,
  itCode: string,
  row: SourceRow,
): SalesOrderDesignOption {
  if (row.LABEL_COUNT > 1)
    throw new SalesOrderDesignError(
      'Conflicting product names require reconciliation before choosing this design.',
    );
  const version = createHash('sha256')
    .update(JSON.stringify([scope.tenantId, scope.coCode, itCode.trim(), row]))
    .digest('hex');
  return {
    source: {
      prCode: row.PR_CODE,
      bookName: row.BOOK_NAME,
      srNo: row.SR_NO,
      oldSrNo: row.OLD_SRNO,
      version,
    },
    designNo: row.DESIGN_NO ?? '',
    bookName: row.BOOK_NAME,
    productName: row.PR_NAME ?? '',
    remark: row.DIE_NO ?? '',
    itmSize: row.ITM_SIZE ?? '',
    karigarName: row.KR_NAME ?? '',
    grossWt: row.ITM_GWT,
    touch: row.ITM_TOUCH,
    westPct: row.ITM_WEST_PRC,
    labourPct: row.LBR_PRC,
    labourRate: row.LBR_RATE,
    designImageId: row.DESIGN_IMG_ID,
  };
}
async function thirdColumnTx(tx: Tx, scope: SalesOrderDesignScope) {
  // TR_SALE_ORD:7309: installation registration changes only the help's third column.
  const refs = await tx.$queryRawUnsafe<{ REF_NO: string }[]>(
    'SELECT "REF_NO" FROM "HDD_MAST" WHERE tenant_id=$1 AND COALESCE("REF_NO",\'\')<>\'\'',
    scope.tenantId,
  );
  const modes = new Set(refs.map((row) => row.REF_NO.trim() === 'DM043NEDM'));
  if (modes.size > 1)
    throw new SalesOrderDesignError(
      'Conflicting installation registrations prevent choosing the Design Book display.',
    );
  return modes.has(true) ? ('Remark' as const) : ('Product' as const);
}
async function salesScopeTx(tx: Tx, scope: OrderImageScope) {
  if (
    ![scope.tenantId, scope.coCode, scope.lcCode, scope.coYear, scope.coBook].every(
      (value) => typeof value === 'string' && value.trim(),
    )
  )
    throw new SalesOrderDesignError(
      'Select the complete company, branch, year and Sales Order book.',
    );
  await resolveBookPolicyTx(tx, scope, 'SALES ORDER', {
    requireExplicitMainBook: true,
    expectedTable: 'SL_ORD_DATA',
  });
}
/** TR_SALE_ORD:7307–7317: item→product, company-wide designs, left-joined product label. */
export async function listSalesOrderDesigns(
  prisma: PrismaClient,
  scope: OrderImageScope,
  input: { itCode: string; search?: string; offset?: number; limit?: number },
): Promise<SalesOrderDesignList> {
  const offset = input.offset ?? 0;
  const limit = input.limit ?? 50;
  if (
    !Number.isSafeInteger(offset) ||
    offset < 0 ||
    !Number.isSafeInteger(limit) ||
    limit < 1 ||
    limit > 100
  )
    throw new SalesOrderDesignError(
      'Design pagination must use a nonnegative offset and a limit from 1 to 100.',
    );
  if (input.search != null && (typeof input.search !== 'string' || input.search.length > 100))
    throw new SalesOrderDesignError('Design search must contain at most 100 characters.');
  scopeValues(scope, input.itCode);
  return withTxBudget(prisma, scope.tenantId, SNAPSHOT_READ, async (tx) => {
    await salesScopeTx(tx, scope);
    const product = await productTx(tx, scope, input.itCode, false);
    const thirdColumnLabel = await thirdColumnTx(tx, scope);
    const rows = await tx.$queryRawUnsafe<SourceRow[]>(
      `SELECT ${columns} ${from} WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."PR_CODE"=$3
       AND ($4='' OR strpos(lower(concat_ws(' ', d."BOOK_NAME",d."DESIGN_NO",${thirdColumnLabel === 'Remark' ? 'd."DIE_NO"' : 'p."PR_NAME"'},d."ITM_SIZE",d."KR_NAME")),lower($4))>0)
       ORDER BY d."BOOK_NAME",d."DESIGN_NO",d."SR_NO" LIMIT $5 OFFSET $6`,
      scope.tenantId,
      scope.coCode,
      product,
      (input.search ?? '').trim(),
      limit + 1,
      offset,
    );
    return {
      rows: rows.slice(0, limit).map((row) => option(scope, input.itCode, row)),
      offset,
      limit,
      hasMore: rows.length > limit,
      thirdColumnLabel,
    };
  });
}
function validateRef(ref: SalesOrderDesignSourceRef) {
  if (
    !ref ||
    typeof ref.prCode !== 'string' ||
    !ref.prCode ||
    ref.prCode.length > 2 ||
    typeof ref.bookName !== 'string' ||
    !ref.bookName.trim() ||
    ref.bookName.length > 20 ||
    !Number.isFinite(ref.srNo) ||
    ref.srNo <= 0 ||
    ref.srNo > Number.MAX_SAFE_INTEGER ||
    (ref.oldSrNo !== null && !Number.isFinite(ref.oldSrNo)) ||
    typeof ref.version !== 'string' ||
    !/^[a-f0-9]{64}$/.test(ref.version)
  )
    throw new SalesOrderDesignError('A complete saved Design Book selection is required.');
}
/** Resolve inside the order writer transaction. SHARE locks block non-key source/item edits
 * until the selected values have been applied and the order transaction commits. */
export async function resolveSalesOrderDesignTx(
  tx: Tx,
  scope: SalesOrderDesignScope,
  input: { itCode: string; source: SalesOrderDesignSourceRef },
): Promise<SalesOrderDesignOption> {
  validateRef(input.source);
  const product = await productTx(tx, scope, input.itCode, true);
  if (product !== input.source.prCode)
    throw new SalesOrderDesignError(
      'The selected design no longer belongs to this order item. Choose it again.',
      409,
    );
  const rows = await tx.$queryRawUnsafe<SourceRow[]>(
    `SELECT ${columns} ${from} WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."PR_CODE"=$3
     AND d."BOOK_NAME"=$4 AND d."SR_NO"=$5 FOR SHARE OF d`,
    scope.tenantId,
    scope.coCode,
    product,
    input.source.bookName,
    input.source.srNo,
  );
  const row = rows[0];
  if (rows.length !== 1 || !row)
    throw new SalesOrderDesignError(
      'The selected design was removed. Choose a saved design again.',
      409,
    );
  const found = option(scope, input.itCode, row);
  if (
    found.source.oldSrNo !== input.source.oldSrNo ||
    found.source.version !== input.source.version
  )
    throw new SalesOrderDesignError(
      'The selected design changed after it was displayed. Choose it again.',
      409,
    );
  return found;
}
/** The route grants Sales Order view and validates the configured Sales book first.
 * The client supplies a validated saved source, never an arbitrary image identity. */
export async function getSalesOrderDesignImage(
  prisma: PrismaClient,
  scope: OrderImageScope,
  input: { itCode: string; source: SalesOrderDesignSourceRef },
): Promise<ResolvedOrderImage> {
  return withTxBudget(prisma, scope.tenantId, SNAPSHOT_READ, async (tx) => {
    await salesScopeTx(tx, scope);
    const selected = await resolveSalesOrderDesignTx(tx, scope, input);
    if (!selected.designImageId?.trim() || selected.designImageId.trim() === 'N')
      return { state: 'absent' };
    return resolveOrderImageTx(
      tx,
      scope,
      'SALES ORDER',
      {},
      { DESIGN_IMG_ID: selected.designImageId },
    );
  });
}
