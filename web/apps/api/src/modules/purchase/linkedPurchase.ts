import type { VoucherScope } from '../vouchers/numbering.js';
import { formatVoucherNo } from '../vouchers/numbering.js';
import {
  createPurchaseTx,
  deletePurchaseTx,
  editPurchaseTx,
  purchaseVersionTx,
  PurchaseValidationError,
  type PurchaseInput,
  type PurchaseLineInput,
  type PurchaseResult,
} from './purchase.js';
import { normalizeSaleLink, type SaleLink } from './linkedSale.js';
import { isUrdPurchaseBookTx, type UrdMetal } from './urdBook.js';

/**
 * The linked old-gold (URD) purchase of a tax-invoice sale (owner decision 2B).
 *
 * Desktop: the sale's Old Gold / Old Silver totals row opens TR_PURC on the URD book with tSlBill / tSlBill_DbCd
 * prefilled (TR_SALE.cs:18756-18842; TR_PURC.cs:13724-13740), and the purchase saves SL_BILL_NO / SL_BILL_LC /
 * SL_BILL_YRCD / SL_BILL_DBCD on PR_DATA and PR_DETL (TR_PURC.cs:12647-12650, :12766-12769). If a purchase in that book
 * already carries the sale's DBCD + NO, the desktop opens it in edit.
 *
 * The web writes it inside the sale's own transaction (a later PR), so these functions take the caller's `tx` and run
 * the ordinary purchase create / edit / delete paths (same rows, numbering, ledger, rojmel — Purc_Rojmel's party row
 * is suppressed by SL_BILL_NO, shared/purchaseRojmel.ts). The only difference from a standalone save is the link
 * gate: a purchase linked to a sale is edited or deleted only when the caller names that exact sale key.
 */
export interface SaleKey extends SaleLink {
  tenantId: string;
  coCode: string;
}

export interface LinkedPurchaseRef {
  lcCode: string;
  coYear: string;
  coBook: string;
  vchNo: string;
}

export type LinkedPurchaseInput = Omit<
  PurchaseInput,
  | 'scope'
  | 'saleBillNo'
  | 'saleBillLc'
  | 'saleBillYear'
  | 'saleBillBook'
  | 'consiNo'
  | 'consiLcCode'
  | 'consiYrcd'
  | 'consiDbcd'
> & { lines: PurchaseLineInput[] };

export type LinkedPurchaseResult = PurchaseResult & {
  version: string;
  created: boolean;
  metal: UrdMetal;
};

const text = (value: unknown): string => String(value ?? '').trim();

function requireLink(link: SaleLink): SaleLink {
  const normalized = normalizeSaleLink(link);
  if (!normalized.saleBillNo || !normalized.saleBillBook || !normalized.saleBillYear) {
    throw new PurchaseValidationError('linked purchase requires the sale book, number and year');
  }
  return normalized;
}

/**
 * Every purchase linked to a sale, by an exact match on all four SL_BILL_* columns (never the desktop's
 * date/amount/party heuristic, TR_SALE.cs:15840-15852). Only MAIN_BOOK PURCHASE books: a CON PUR purchase reuses the
 * same columns for its consignment receipt (TR_PR_SL_UAE) and is never a sale link. Rows are locked unless a reader
 * passes `lock: false`.
 */
export async function findLinkedPurchasesTx(
  tx: any,
  saleKey: SaleKey,
  opts: { lock?: boolean } = {},
): Promise<LinkedPurchaseRef[]> {
  const link = requireLink(saleKey);
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT p."LC_CODE",p."CO_YEAR",p."CO_BOOK",p."VCH_NO" FROM "PR_DATA" p
      WHERE p.tenant_id=$1 AND p."CO_CODE"=$2
        AND btrim(coalesce(p."SL_BILL_NO"::text,''))=$3
        AND btrim(coalesce(p."SL_BILL_LC"::text,''))=$4
        AND btrim(coalesce(p."SL_BILL_YRCD"::text,''))=$5
        AND btrim(coalesce(p."SL_BILL_DBCD"::text,''))=$6
        AND EXISTS (SELECT 1 FROM "BOOK_DATA" b
                     WHERE b.tenant_id=p.tenant_id AND b."CO_CODE"=p."CO_CODE" AND b."LC_CODE"=p."LC_CODE"
                       AND btrim(b."CO_BOOK")=btrim(p."CO_BOOK")
                       AND upper(btrim(coalesce(b."MAIN_BOOK",'')))='PURCHASE')
      ORDER BY p."LC_CODE",p."CO_YEAR",p."CO_BOOK",p."VCH_NO"${opts.lock === false ? '' : ' FOR UPDATE'}`,
    saleKey.tenantId,
    saleKey.coCode,
    link.saleBillNo,
    link.saleBillLc,
    link.saleBillYear,
    link.saleBillBook,
  );
  return rows.map((r) => ({
    lcCode: text(r.LC_CODE),
    coYear: text(r.CO_YEAR),
    coBook: text(r.CO_BOOK),
    vchNo: text(r.VCH_NO),
  }));
}

/**
 * Create or edit the sale's linked purchase on a URD book (`scope.coBook`, from resolveUrdPurchaseBookTx).
 *
 * With no purchase in that book for this sale key it creates one through the normal create path. With one, it edits
 * it through the normal edit path — only when `allowLinkedEdit` is true; otherwise the standalone refusal stands.
 * At most one linked purchase per sale key and book: a second one is refused.
 */
export async function writeLinkedPurchaseTx(
  tx: any,
  scope: VoucherScope,
  input: LinkedPurchaseInput,
  link: SaleLink,
  opts: { allowLinkedEdit: boolean },
): Promise<LinkedPurchaseResult> {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear || !scope.coBook) {
    throw new PurchaseValidationError(
      'linked purchase requires tenant, company, location, fiscal year, and book',
    );
  }
  const saleLink = requireLink(link);
  const metal = await isUrdPurchaseBookTx(tx, scope, scope.coBook);
  if (!metal) {
    throw new PurchaseValidationError(
      `book ${scope.coBook} is not the Gold or Silver URD Purchase book`,
    );
  }
  // One writer per sale key: a concurrent save of the same sale cannot create a second linked purchase.
  await tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `linked-purchase|${scope.tenantId}|${scope.coCode}|${saleLink.saleBillLc}|${saleLink.saleBillYear}|${saleLink.saleBillBook}|${saleLink.saleBillNo}`,
  );
  const existing = (
    await findLinkedPurchasesTx(tx, {
      tenantId: scope.tenantId,
      coCode: scope.coCode,
      ...saleLink,
    })
  ).filter(
    (row) =>
      row.lcCode === scope.lcCode && row.coYear === scope.coYear && row.coBook === scope.coBook,
  );
  if (existing.length > 1) {
    throw new PurchaseValidationError(
      `sale ${saleLink.saleBillBook}/${saleLink.saleBillNo} has ${existing.length} linked purchases in book ${scope.coBook}`,
    );
  }
  const { lines, ...header } = input;
  const purchaseInput: PurchaseInput = { ...header, scope, ...saleLink };
  if (!existing.length) {
    const result = await createPurchaseTx(tx, purchaseInput, lines, saleLink);
    return { ...result, created: true, metal };
  }
  const voucherNo = existing[0]!.vchNo;
  // The caller's sale transaction is the concurrency boundary; the purchase's own version is read here, after the
  // row lock taken by findLinkedPurchasesTx.
  const version = await purchaseVersionTx(tx, scope, formatVoucherNo(voucherNo));
  const result = await editPurchaseTx(
    tx,
    purchaseInput,
    lines,
    voucherNo,
    version,
    opts.allowLinkedEdit ? saleLink : undefined,
  );
  return { ...result, created: false, metal };
}

/** Delete one linked purchase through the full purchase delete path, gated on the exact sale key. */
export async function deleteLinkedPurchaseTx(
  tx: any,
  ref: LinkedPurchaseRef & { tenantId: string; coCode: string },
  link: SaleLink,
  deleteUser?: string,
): Promise<{ reversed: true }> {
  const scope: VoucherScope = {
    tenantId: ref.tenantId,
    coCode: ref.coCode,
    lcCode: ref.lcCode,
    coYear: ref.coYear,
    coBook: ref.coBook,
  };
  const voucherNo = formatVoucherNo(ref.vchNo);
  const expectedVersion = await purchaseVersionTx(tx, scope, voucherNo);
  return deletePurchaseTx(
    tx,
    { scope, vchNo: voucherNo, deleteUser, expectedVersion },
    requireLink(link),
  );
}

/** Delete every purchase linked to a sale (the desktop's sale-delete cascade, TR_SALE.cs:16159-16175, by exact key). */
export async function deleteLinkedPurchasesForSaleTx(
  tx: any,
  saleKey: SaleKey,
  deleteUser?: string,
): Promise<LinkedPurchaseRef[]> {
  const linked = await findLinkedPurchasesTx(tx, saleKey);
  for (const ref of linked) {
    await deleteLinkedPurchaseTx(
      tx,
      { ...ref, tenantId: saleKey.tenantId, coCode: saleKey.coCode },
      saleKey,
      deleteUser,
    );
  }
  return linked;
}
