import { withTxBudget } from '../shared/txBudget.js';
import { formatVoucherNo } from '../vouchers/numbering.js';
import { deletePurchaseTx, PurchaseValidationError, type DeletePurchaseInput } from './purchase.js';
import { purchaseSaleLinkStateTx } from './linkedSale.js';

/** TR_PURC.cs:13443-13447, :16024: F1 allows link deletion. Owner adaptation: only an absent sale. */
export function deleteStrayPurchase(prisma: any, input: DeletePurchaseInput) {
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    const s = input.scope;
    // Lock the purchase before checking its link, like the sale's linked-purchase lookup. A concurrent sale
    // cannot adopt this purchase while we check and reverse it. The ordinary delete also checks its version.
    const rows = await tx.$queryRawUnsafe(
      `SELECT "SL_BILL_NO","SL_BILL_LC","SL_BILL_YRCD","SL_BILL_DBCD" FROM "PR_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 FOR UPDATE`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coYear,
      s.coBook,
      formatVoucherNo(input.vchNo),
    );
    if (rows.length !== 1) throw new PurchaseValidationError('Purchase voucher not found');
    const link = await purchaseSaleLinkStateTx(tx, s, rows[0]);
    if (!link) throw new PurchaseValidationError('This purchase has no sale link');
    if (link.exists)
      throw new PurchaseValidationError(
        `Linked with sale ${link.saleBillBook}/${link.saleBillNo}; delete it from the sale`,
      );
    return deletePurchaseTx(tx, input, link);
  });
}
