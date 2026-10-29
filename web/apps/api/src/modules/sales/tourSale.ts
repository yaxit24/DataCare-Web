import type { VoucherScope } from '../vouchers/numbering.js';
import {
  writeRateCut,
  readRateCut,
  reverseRateCut,
  type RateCutInput,
  type RateCutResult,
  type DeleteRateCutInput,
} from './rateCut.js';

/**
 * Tour Sales (desktop TR_TOUR_SALE). The desktop form posts the SAME TR_WH_SALE engine
 * (Ac_Ledr.Wh_Sales_Ledr / Wh_Sales_Rojmel / Wh_Sale_Stk, TR_TOUR_SALE.cs:11252) over RATE_CUT_DATA,
 * the only difference being the book: the "Tour Sales" menu opens it on a TOUR SALES book
 * (MDI_FORM.cs:9321 CurBookHelp('TOUR SALES')). These wrappers therefore reuse the wholesale-sale
 * writers with the `tour-sale` book guard, which accepts only a TOUR SALES book.
 */
export async function postTourSale(prisma: any, input: RateCutInput): Promise<RateCutResult> {
  return writeRateCut(prisma, input, { bookGuard: 'tour-sale' });
}

export async function editTourSale(
  prisma: any,
  input: RateCutInput,
  vchNo: number | string,
): Promise<RateCutResult> {
  return writeRateCut(prisma, input, { vchNo, bookGuard: 'tour-sale' });
}

export async function getTourSale(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  return readRateCut(prisma, scope, requestedVoucherNo, { bookGuard: 'tour-sale' });
}

export async function deleteTourSale(
  prisma: any,
  input: DeleteRateCutInput,
): Promise<{ reversed: true }> {
  return reverseRateCut(prisma, input, { bookGuard: 'tour-sale' });
}
