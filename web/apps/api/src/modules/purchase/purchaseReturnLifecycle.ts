/**
 * Purchase Return lifecycle after the first save: reopen, edit and delete (desktop TR_KR_ISU in `PURC RETURN`
 * mode, dispatched from MDI_FORM.cs:7893-7917). The writer itself lives in `purchaseReturn.ts` and is shared with
 * create, because the desktop saves a new and a reopened voucher through the same handler.
 */
import { withTxBudget } from '../shared/txBudget.js';
import { resolveBookPolicyTx } from '../shared/bookPolicy.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import {
  assertFiscalDateTx,
  deleteVoucherWriteSetTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
} from '../vouchers/lifecycle.js';
import { restoreTagTx } from '../stock/stock.js';
import { assertPeriodOpen, reverseVoucherTx } from '../posting/posting.js';
import { getPurchase, type PurchaseLineInput, PurchaseValidationError } from './purchase.js';
import {
  PURCHASE_RETURN_WRITE_TABLES,
  purchaseReturnKey,
  writePurchaseReturnTx,
  type PurchaseReturnInput,
  type PurchaseReturnResult,
} from './purchaseReturn.js';

type CompleteScope = VoucherScope & { coYear: string; coBook: string };
type TagRestore = Record<string, unknown> & { CO_CODE: string; LC_CODE: string; TAG_NO: string };

const num = (value: unknown): number => (value == null ? 0 : Number(value));
const text = (value: unknown): string => String(value ?? '').trim();

function completeScope(scope: VoucherScope): CompleteScope {
  if (!scope.coYear || !scope.coBook)
    throw new PurchaseValidationError('company year and book are required');
  return scope as CompleteScope;
}

function voucherParams(scope: CompleteScope, voucherNo: string): unknown[] {
  return [scope.tenantId, scope.coCode, scope.lcCode, scope.coYear, scope.coBook, voucherNo];
}

/**
 * Reopen a Purchase Return (TR_KR_ISU DISPLAY_DATA, :4612-4898) after checking that the selected book is a
 * PURC RETURN book.
 *
 * The header and the purchase-shaped line fields come from the shared PR_DATA/PR_DETL projection. The return
 * writer also stores columns that projection does not read: lot, stock flag, loss, ghat %, less touch,
 * conversion, commission amount, fine cut, rate types, product code, and the raw metal code (the projection
 * reads a blank IT_TYPE as gold). An edit rebuilds PR_DETL from its input, so a field the screen cannot see is
 * lost on an unchanged save; they are read here.
 */
export async function getPurchaseReturn(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  const complete = completeScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  const extras: Array<Record<string, unknown>> = await withTxBudget(
    prisma,
    scope.tenantId,
    'read',
    async (tx: any) => {
      await resolveBookPolicyTx(tx, scope, 'PURCHASE RETURN');
      return tx.$queryRawUnsafe(
        `SELECT "SR_NO","IT_TYPE","LOT_NO","ITM_LOT","WITH_STOCK","ITM_LOSS_WT","ITM_GHT_PRC",
                "ITM_LESS_TCH","CONV_RATE","CONV_PRC","COMM_AMT","FINE_CUT_PCS","FINE_CUT_GWT",
                "FINE_CUT_NWT","FINE_CUT_FINE","RATE_TYPE","URD_RATE_TYPE","PR_CODE"
           FROM "PR_DETL"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
            AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
        ...voucherParams(complete, voucherNo),
      );
    },
  );
  const view = await getPurchase(prisma, scope, voucherNo);
  const extraBySrNo = new Map(extras.map((row) => [num(row.SR_NO), row]));
  const lines = (view.lines as Array<Record<string, unknown>>).map((line) => {
    const row = extraBySrNo.get(num(line.srNo));
    if (!row) return line;
    return {
      ...line,
      metal: text(row.IT_TYPE),
      lotNo: text(row.LOT_NO),
      itmLot: text(row.ITM_LOT),
      withStock: text(row.WITH_STOCK),
      lossWt: num(row.ITM_LOSS_WT),
      ghtPct: num(row.ITM_GHT_PRC),
      lessTouch: num(row.ITM_LESS_TCH),
      convRate: num(row.CONV_RATE),
      convPct: num(row.CONV_PRC),
      commissionAmount: num(row.COMM_AMT),
      fineCutPcs: num(row.FINE_CUT_PCS),
      fineCutGrossWt: num(row.FINE_CUT_GWT),
      fineCutNetWt: num(row.FINE_CUT_NWT),
      fineCutFine: num(row.FINE_CUT_FINE),
      rateType: text(row.RATE_TYPE),
      urdRateType: text(row.URD_RATE_TYPE),
      prCode: text(row.PR_CODE),
    };
  });
  return {
    ...view,
    lines,
    origVchNo: view.saleBillNo,
    origBook: view.saleBillBook,
    origYear: view.saleBillYear,
  };
}

/** Lock and read the persisted header, mapping "missing" and "ambiguous" to the return's own messages. */
async function persistedReturnHeaderTx(
  tx: any,
  scope: CompleteScope,
  voucherNo: string,
): Promise<Record<string, unknown>> {
  try {
    return await persistedVoucherHeaderTx(tx, {
      table: 'PR_DATA',
      scope,
      voucherNo,
      extraColumns: [],
    });
  } catch (error) {
    if (error instanceof Error && error.name === 'PersistedVoucherNotFoundError')
      throw new PurchaseValidationError(`purchase return not found: ${voucherNo}`);
    if (error instanceof Error && error.name === 'PersistedVoucherAmbiguousError')
      throw new PurchaseValidationError(`purchase return is ambiguous: ${voucherNo}`);
    throw error;
  }
}

/**
 * Returned tags that exist only in TAG_STOCK (imported or legacy stock with no BAR_DETL row). Saving the return
 * removed their TAG_STOCK row, so a reversal must put it back; tags with BAR_DETL provenance come back on their
 * own once this voucher's MAIN_STOCK issue rows are gone.
 */
async function tagStockOnlyReturnTagsTx(
  tx: any,
  scope: CompleteScope,
  voucherNo: string,
): Promise<TagRestore[]> {
  const tags: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT"
       FROM "PR_DETL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND "TAG_NO"::text<>'N'
        AND nullif(btrim(coalesce("TAG_NO"::text,'')),'') IS NOT NULL`,
    ...voucherParams(scope, voucherNo),
  );
  const restores: TagRestore[] = [];
  for (const tag of tags) {
    const provenance: Array<{ n: unknown }> = await tx.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "BAR_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"::text=$4
          AND coalesce("VCH_SRNO",0)=coalesce($5::numeric,0)
          AND coalesce("IT_CODE"::text,'')=coalesce($6::text,'')`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      String(tag.TAG_NO),
      tag.VCH_SRNO ?? 0,
      tag.IT_CODE ?? '',
    );
    if (Number(provenance[0]?.n ?? 0) === 0)
      restores.push({
        CO_CODE: scope.coCode,
        LC_CODE: scope.lcCode,
        TAG_NO: String(tag.TAG_NO),
        VCH_SRNO: Number(tag.VCH_SRNO ?? 0),
        // NO IT_CODE: TAG_STOCK has IT_TYPE instead, and insertTagTx THROWS on an undeclared column
        // rather than ignoring it — so this aborted the whole reversal for any tag that lived only in
        // TAG_STOCK, which is exactly the imported/legacy stock this restore path exists for.
        ITM_PCS: tag.ITM_PCS,
        ITM_GWT: tag.ITM_GWT,
        ITM_NWT: tag.ITM_NWT,
        STK_TYPE: 'R',
      });
  }
  return restores;
}

function isoDay(value: Date | string): string {
  const date = new Date(value);
  if (Number.isNaN(date.getTime()))
    throw new PurchaseValidationError(`invalid voucher date: ${String(value)}`);
  return date.toISOString().slice(0, 10);
}

/**
 * Edit a saved Purchase Return.
 *
 * TR_KR_ISU saves a reopened voucher through the same handler as a new one (BtnSave_Click, :4928-5355): it
 * refuses a date outside the open year (:4964-4969) or on or before the lock date (:4970-4975), deletes the
 * voucher's PR_DATA, PR_DETL and PR_IDTL rows (:5033-5035) and re-inserts them under the same voucher and hidden
 * numbers, then deletes and re-posts the ledger (:5240-5249), day book (:5252-5263), tax (:5266-5270), stock and
 * diamond rows (:5272-5285). It keeps the creator (`MainUser`, :4689) and the time of day (:4622), and writes no
 * DELETE_DATA row. The web does all of it in one transaction and also refuses an edit of a voucher whose persisted
 * date is locked, as `editPurchase` does, so a locked voucher cannot be moved out of its period.
 */
export async function editPurchaseReturn(
  prisma: any,
  input: PurchaseReturnInput,
  lines: PurchaseLineInput[],
  requestedVoucherNo: number | string,
): Promise<PurchaseReturnResult> {
  const scope = completeScope(input.scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const bookPolicy = await resolveBookPolicyTx(tx, scope, 'PURCHASE RETURN');
    const persisted = await persistedReturnHeaderTx(tx, scope, voucherNo);
    // A client that omits the date keeps the voucher's date; it is never silently moved to today.
    const vchDate = input.vchDate ?? (persisted.VCH_DATE as Date);
    await assertFiscalDateTx(tx, scope, isoDay(vchDate));
    for (const date of [persisted.VCH_DATE, vchDate])
      await assertPeriodOpen(tx, scope.tenantId, {
        ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: date }] },
      });

    const tagStockOnly = await tagStockOnlyReturnTagsTx(tx, scope, voucherNo);
    const persistedHidden = text(persisted.HD_VCH_NO);
    await deleteVoucherWriteSetTx(tx, {
      tables: PURCHASE_RETURN_WRITE_TABLES,
      key: { scope, voucherNo },
      ...(persistedHidden ? { tempBook: { voucherNo: persistedHidden } } : {}),
    });
    // Put the voucher's own tags back so the writer can issue them again; a tag the edit no longer returns
    // stays in stock, as it would after a delete.
    for (const tag of tagStockOnly) await restoreTagTx(tx, scope.tenantId, tag);
    return writePurchaseReturnTx(tx, { ...input, vchDate }, lines, {
      vchNo: Number(voucherNo),
      // A voucher saved before hidden numbers existed gets one now, as a new voucher would.
      hdVchNo: persistedHidden || (await nextHiddenVoucherNoTx(tx, scope)),
      bookPolicy,
      mainUser: persisted.MAIN_USER == null ? null : String(persisted.MAIN_USER),
      persistedClock: persisted.VCH_CLOCK,
    });
  });
}

export interface DeletePurchaseReturnInput {
  scope: VoucherScope;
  vchNo: number | string;
  deleteUser?: string;
}

export async function deletePurchaseReturn(
  prisma: any,
  input: DeletePurchaseReturnInput,
): Promise<{ reversed: true }> {
  const scope = completeScope(input.scope);
  const tenantId = scope.tenantId;
  const key = purchaseReturnKey(scope, Number(input.vchNo));
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const bookPolicy = await resolveBookPolicyTx(tx, scope, 'PURCHASE RETURN');
    const headers: Array<{ HD_VCH_NO: unknown }> = await tx.$queryRawUnsafe(
      `SELECT "HD_VCH_NO" FROM "PR_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 FOR UPDATE`,
      ...voucherParams(scope, key.VCH_NO),
    );
    if (headers.length !== 1)
      throw new PurchaseValidationError(
        headers.length
          ? `purchase return is ambiguous: ${key.VCH_NO}`
          : `purchase return not found: ${key.VCH_NO}`,
      );
    const tagStockOnly = await tagStockOnlyReturnTagsTx(tx, scope, key.VCH_NO);
    await reverseVoucherTx(tx, tenantId, {
      // Every table uses the complete voucher key. PR_IDTL is included although the return writer never
      // fills it, because the desktop delete removes it too (TR_KR_ISU.cs:5385).
      tables: [...PURCHASE_RETURN_WRITE_TABLES],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: {
          ...key,
          VCH_TYPE: bookPolicy.vchType,
          BOOK_NAME: bookPolicy.bookName,
          DELETE_USER: input.deleteUser ?? 'system',
        },
      },
    });
    const hiddenVoucherNo = text(headers[0]?.HD_VCH_NO);
    if (hiddenVoucherNo) {
      await tx.$executeRawUnsafe(
        `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
        tenantId,
        key.CO_CODE,
        key.LC_CODE,
        key.CO_BOOK,
        hiddenVoucherNo,
      );
    }
    for (const tag of tagStockOnly) await restoreTagTx(tx, tenantId, tag);
    return { reversed: true };
  });
}
