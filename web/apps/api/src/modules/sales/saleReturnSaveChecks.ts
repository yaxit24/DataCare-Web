import { roundHalfEven, toIsoDate } from '@datacare/core';
import { assertPeriodOpen } from '../posting/posting.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { assertFiscalDateTx } from '../vouchers/lifecycle.js';
import type { VoucherScope } from '../vouchers/numbering.js';
import { SaleValidationError } from './sales.js';
import { WHOLESALE_MESSAGES } from './wholesaleSaveChecks.js';

/**
 * The save refusals of the desktop Sales Return form (TR_SALE_RTN `BtnSave_Click`), in the desktop's order and with
 * its texts (WP-27, N242, G254; decisions D9-D11 and D14 in orchestration/work/WP-27/cases.md):
 *
 *   1. employee mandatory                 TR_SALE_RTN.cs:12124  (CO_SET.EMP_CODE_MANDATORY = 'Y', blank tEmpCode)
 *   2. cheque amount without its account  TR_SALE_RTN.cs:12195-12202
 *   3. card amount without its account    TR_SALE_RTN.cs:12210-12217 (the web tender has one bank account)
 *   4. company type B, new voucher only   TR_SALE_RTN.cs:12225-12232
 *   5. date outside the open year         TR_SALE_RTN.cs:12255-12262
 *   6. date on or before the lock date    TR_SALE_RTN.cs:12270-12277 (PeriodLockValidationError carries the text)
 *   7. zero voucher value                 TR_SALE_RTN.cs:12398-12405, checked by the writer once the lines are priced
 *
 * The defaulter test (:12136) and the cash limit (:12169) read the SALE-side column of the bill-total grid, which a
 * return-only voucher leaves at 0, so neither can refuse a return (D10). Licence expiry (:12113) is not a web concept.
 * Every check runs inside the writer's transaction before any row is written: a refusal rolls the voucher number back.
 */
export const SALE_RETURN_MESSAGES = {
  itemValue: 'Please Insert Item Value and try',
  duplicateTag: 'Duplicate Tag No',
  alreadyImported: (voucherNo: string) =>
    `This Sales Bill Is All ready Import...In...${voucherNo} You Cant Re Ipmport...Please Select Single Item In Receive Item...`,
} as const;

const text = (value: unknown): string => String(value ?? '').trim();
const amount = (value: unknown): number => {
  const n = Number(value ?? 0);
  return Number.isFinite(n) ? n : 0;
};

/** Checks 1-6, before the lines are priced. */
export async function assertSaleReturnSaveTx(
  tx: any,
  scope: VoucherScope,
  input: {
    vchDate: Date;
    empCode?: unknown;
    chequeAmt?: unknown;
    cardAmt?: unknown;
    bankAc?: unknown;
    isNew: boolean;
  },
): Promise<void> {
  const settings: Array<{ EMP_CODE_MANDATORY: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "EMP_CODE_MANDATORY" FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text
      ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
  );
  if (text(settings[0]?.EMP_CODE_MANDATORY).toUpperCase() === 'Y' && !text(input.empCode))
    throw new SaleValidationError(WHOLESALE_MESSAGES.employee);
  if (amount(input.chequeAmt) !== 0 && !text(input.bankAc))
    throw new SaleValidationError(DESKTOP_MESSAGES.CHEQUE_WITHOUT_BANK);
  if (amount(input.cardAmt) !== 0 && !text(input.bankAc))
    throw new SaleValidationError(DESKTOP_MESSAGES.CARD_WITHOUT_BANK);
  if (input.isNew) {
    const types: Array<{ type: string }> = await tx.$queryRawUnsafe(
      `SELECT DISTINCT upper(btrim(coalesce("CO_TYPE"::text,''))) AS "type" FROM "CO_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text`,
      scope.tenantId,
      scope.coCode,
    );
    if (types.some((row) => row.type === 'B'))
      throw new SaleValidationError(WHOLESALE_MESSAGES.companyTypeB);
  }
  try {
    await assertFiscalDateTx(tx, { ...scope, coYear: scope.coYear ?? '' }, toIsoDate(input.vchDate));
  } catch (error) {
    // A missing or ambiguous YEAR_MAST row keeps its own fail-closed message.
    if (error instanceof Error && /is outside fiscal year/.test(error.message))
      throw new SaleValidationError(WHOLESALE_MESSAGES.outsideYear);
    throw error;
  }
  await assertPeriodOpen(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: input.vchDate }] },
  });
}

/**
 * Check 7. `nAcCrAmt` is the return grid's net rounded to whole rupees (TR_SALE_RTN.cs:16386); the web form has no
 * sale side (`nAcDrAmt` = 0) and `num6` is one registration's hallmark term (0). An empty grid totals 0 too.
 */
export function assertSaleReturnValue(lineNetTotal: number): void {
  if (roundHalfEven(lineNetTotal, 0) === 0) throw new SaleValidationError(SALE_RETURN_MESSAGES.itemValue);
}
