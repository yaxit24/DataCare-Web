import { formatDesktopDate, toIsoDate } from '@datacare/core';
import { assertPeriodOpen, PeriodLockValidationError } from '../posting/posting.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { assertFiscalDateTx } from '../vouchers/lifecycle.js';
import type { VoucherScope } from '../vouchers/numbering.js';

/**
 * The save refusals of the desktop Wh Sales form (TR_WH_SALE.cs:12779-12896), in the desktop's order and with its
 * own texts. TR_TOUR_SALE carries the same block, so Tour Sales uses it too; Bullion Sale (TR_BUL_SALE) and the
 * quotation do not, and keep their own rules.
 *
 * The desktop checks, before it writes anything:
 *   1. a defaulter party (AC_MAST.DEFAULTER_AC = 'Y') that would be left owing:
 *      `Val(MSG2_TOTAL[7,4]) + Val(nDiffFine) > 0` (the sale-side Os Amt plus the fine still due) — :12784-12789;
 *   2. a missing employee when CO_SET.EMP_CODE_MANDATORY = 'Y' — :12790-12795;
 *   3. a new voucher in a company whose CO_TYPE is 'B' — :12814-12819;
 *   4. a cheque amount (either column) without its bank account — :12820-12825;
 *   5. a card amount (either column) without its card bank account — :12826-12831;
 *   6. a date outside the open year — :12833-12838;
 *   7. a date on or before the lock date — :12839-12844;
 *   8. a grid row with weight, labour, MRP or net amount but no item code, per row — :12886-12896.
 * Licence expiry (:12779) and the two registration-specific checks (HM176NEKU, HM037NEKU) do not apply to the web.
 * The edit right, the party and the voucher number are checked by the route guard and the writer already.
 *
 * Checks 2, 3, 6, 7 and 8 need no figures. `writeRateCut` runs them (`assertWholesaleSaveTx`) after it has taken the
 * voucher number and passed the book-family guard, and before an edit's reversal or any tag reservation. Checks 1, 4
 * and 5 read the band, so `assertWholesaleSettlementTx` runs after the totals are computed and before any row is
 * written. Both run inside the writer's transaction: a refusal rolls it back, so no row and no number persist.
 */
export class WholesaleSaveValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'WholesaleSaveValidationError';
  }
}

export const WHOLESALE_MESSAGES = {
  employee: 'Please Select Employee Code and Try......',
  companyTypeB: 'You Cant Save This Voucher Becouse This Company Type is B......',
  outsideYear:
    'You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...',
  lockDate: (lockDate: string) =>
    `You Cant Save and Delete This Voucher Becouse Lock Date is = ${formatDesktopDate(lockDate)} ....`,
  itemCode: (row: number) => `Please Select Item Code In Row ${row} and Try......`,
} as const;

const text = (value: unknown): string => String(value ?? '').trim();
const num = (value: unknown): number => {
  const n = Number(value ?? 0);
  return Number.isFinite(n) ? n : 0;
};

/** One grid row as the check reads it (the issue and receive grids share the columns the desktop tests). */
export interface WholesaleCheckLine {
  tagNo?: unknown;
  itCode?: unknown;
  grossWt?: unknown;
  lbrAmt?: unknown;
  othAmt?: unknown;
  mrp?: unknown;
}

/**
 * TR_WH_SALE.cs:12886-12896: `MSG[i,3] = ''` (ItCode) and `Val(MSG[i,15]) + Val(MSG[i,36]) + Val(MSG[i,41]) +
 * Val(MSG[i,40]) <> 0` (GrWt, LbrAmt, NetAmt, Mrp). The request carries no NetAmt: the server derives it from the
 * weight, rate, labour, other charges and MRP, so an item-less row has a non-zero NetAmt only when one of those is
 * non-zero, and the row is checked on them. A tagged row takes its item from the tag, so it is not checked here.
 */
export function assertWholesaleItemCodes(lines: readonly WholesaleCheckLine[]): void {
  lines.forEach((line, index) => {
    if (text(line.itCode) || text(line.tagNo)) return;
    if (num(line.grossWt) + num(line.lbrAmt) + num(line.othAmt) + num(line.mrp) !== 0)
      throw new WholesaleSaveValidationError(WHOLESALE_MESSAGES.itemCode(index + 1));
  });
}

/** Checks 2, 3, 6, 7 and 8: after the book-family guard, before an edit's reversal or any write. */
export async function assertWholesaleSaveTx(
  tx: any,
  scope: VoucherScope & { coYear: string },
  input: {
    vchDate: Date;
    empCode?: unknown;
    isNew: boolean;
    issued: readonly WholesaleCheckLine[];
    received: readonly WholesaleCheckLine[];
  },
): Promise<void> {
  const settings: Array<{ EMP_CODE_MANDATORY: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "EMP_CODE_MANDATORY" FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text
      ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
  );
  if (text(settings[0]?.EMP_CODE_MANDATORY).toUpperCase() === 'Y' && !text(input.empCode))
    throw new WholesaleSaveValidationError(WHOLESALE_MESSAGES.employee);

  if (input.isNew) {
    const types: Array<{ type: string }> = await tx.$queryRawUnsafe(
      `SELECT DISTINCT upper(btrim(coalesce("CO_TYPE"::text,''))) AS "type" FROM "CO_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text`,
      scope.tenantId,
      scope.coCode,
    );
    if (types.some((row) => row.type === 'B'))
      throw new WholesaleSaveValidationError(WHOLESALE_MESSAGES.companyTypeB);
  }

  try {
    await assertFiscalDateTx(tx, scope, toIsoDate(input.vchDate));
  } catch (error) {
    // A missing or ambiguous YEAR_MAST row keeps its own fail-closed message.
    if (error instanceof Error && /is outside fiscal year/.test(error.message))
      throw new WholesaleSaveValidationError(WHOLESALE_MESSAGES.outsideYear);
    throw error;
  }

  try {
    await assertPeriodOpen(tx, scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: input.vchDate }] },
    });
  } catch (error) {
    if (error instanceof PeriodLockValidationError)
      throw new WholesaleSaveValidationError(WHOLESALE_MESSAGES.lockDate(error.lockDate));
    throw error;
  }

  assertWholesaleItemCodes(input.issued);
  assertWholesaleItemCodes(input.received);
}

/** Checks 1, 4 and 5, from the band the voucher will post. */
export async function assertWholesaleSettlementTx(
  tx: any,
  scope: VoucherScope,
  input: {
    acCode: string;
    /** The sale-side Os Amt (`MSG2_TOTAL[7,4]`, SL_BILL_OS). */
    saleOutstanding: number;
    /** `nDiffFine` = Tot Fine Dr − Tot Fine Cr. */
    fineDifference: number;
    chequeAmounts: readonly number[];
    cardAmounts: readonly number[];
    bankAc?: unknown;
    cardAc?: unknown;
  },
): Promise<void> {
  const parties: Array<{ DEFAULTER_AC: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "DEFAULTER_AC" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4
      ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    input.acCode,
  );
  const defaulter = text(parties[0]?.DEFAULTER_AC).toUpperCase() === 'Y';
  if (defaulter && num(input.saleOutstanding) + num(input.fineDifference) > 0)
    throw new WholesaleSaveValidationError(DESKTOP_MESSAGES.PARTY_IN_DEFAULTER_LIST);

  if (input.chequeAmounts.reduce((total, x) => total + num(x), 0) !== 0 && !text(input.bankAc))
    throw new WholesaleSaveValidationError(DESKTOP_MESSAGES.CHEQUE_WITHOUT_BANK);
  if (input.cardAmounts.reduce((total, x) => total + num(x), 0) !== 0 && !text(input.cardAc))
    throw new WholesaleSaveValidationError(DESKTOP_MESSAGES.CARD_WITHOUT_BANK);
}

/** The writer's request as the checks read it (a structural subset of `RateCutInput`). */
interface WriterInput {
  scope: VoucherScope;
  acCode: string;
  empCode?: unknown;
  lines?: readonly WholesaleCheckLine[];
  receivedLines?: readonly WholesaleCheckLine[];
  pay?: { bankAc?: unknown; cardAc?: unknown };
  receivedPay?: { bankAc?: unknown; cardAc?: unknown };
}

/** `writeRateCut`'s call for checks 2, 3, 6, 7 and 8: after the book guard, before the edit reversal. */
export function wholesaleChecksBeforeWrite(
  tx: any,
  input: WriterInput,
  vchDate: Date,
  isNew: boolean,
): Promise<void> {
  return assertWholesaleSaveTx(
    tx,
    { ...input.scope, coYear: input.scope.coYear ?? '' },
    {
      vchDate,
      empCode: input.empCode,
      isNew,
      issued: input.lines ?? [],
      received: input.receivedLines ?? [],
    },
  );
}

/** `writeRateCut`'s call for checks 1, 4 and 5: after the header totals, before any row is written. */
export function wholesaleChecksOnBand(
  tx: any,
  input: WriterInput,
  band: { slBillOs: number; totFineDr: number; totFineCr: number },
  tender: { slChqAmt: number; prChqAmt: number; slCardAmt: number; prCardAmt: number },
): Promise<void> {
  return assertWholesaleSettlementTx(tx, input.scope, {
    acCode: String(input.acCode ?? '').trim(),
    saleOutstanding: band.slBillOs,
    fineDifference: band.totFineDr - band.totFineCr,
    chequeAmounts: [tender.slChqAmt, tender.prChqAmt],
    cardAmounts: [tender.slCardAmt, tender.prCardAmt],
    bankAc: input.pay?.bankAc ?? input.receivedPay?.bankAc,
    cardAc: input.pay?.cardAc ?? input.receivedPay?.cardAc,
  });
}
