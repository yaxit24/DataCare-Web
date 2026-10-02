import { round } from '@datacare/core';
import type { ResolvedTaxPolicy } from './taxPolicy.js';

/** The voucher's main GST, as its writer computed it. */
export interface VoucherGst {
  interState: boolean;
  /** The voucher's total rate (header TAX_PRC). */
  ratePct: number;
  igst: number;
  sgst: number;
  cgst: number;
}

/**
 * The TAX_DATA rows for a voucher's main GST, taken from the tax code's COMPONENT rows (G90).
 *
 * Every non-UAE family in `unified/src/csharp/DataCareNext/Ac_Tax.cs` writes them the same way: sales
 * `Sales_GST` :92-96, purchase `Purc_GST` :122-126, sales return `Sales_Rtn_GST` :191-195 and purchase return
 * `Purc_Rtn_GST` :242-246 join `TAX_MAST AS C` on the voucher's TAX_CODE and insert
 *
 *     AC_GST_TYPE <> 'I':  SR_NO 1 from C.SR_NO = 1 and SR_NO 2 from C.SR_NO = 2, each TAX_AMT/2
 *     AC_GST_TYPE  = 'I':  SR_NO 3 from C.SR_NO = 3, the full TAX_AMT
 *
 * with TAX_TYPE = C.TAX_GROUP and TAX_PRC = C.TAX_PRC. On a provisioned master those are SGST, CGST and IGST
 * (seedCompany, G82). The SR_NO 1 row carries the SGST amount and SR_NO 2 the CGST amount, so each row's
 * amount matches its type and the header's SGST_TAX / CGST_TAX.
 *
 * A code without component rows (a legacy single-row master) has nothing for the join to find, so the desktop
 * writes fewer rows. The web keeps writing them with the master's own group and the rate split in two, so the
 * tax is not lost from the registers - the behaviour before G90.
 *
 * `base` carries the columns the family sets itself (key, TRAN_TYPE, TAX_SIGN, NET_AMT, DISC_AMT, TOT_AMT…).
 * Hallmark-charge rows (SR_NO 10/20/30, from HM_TAX_CODE) are not built here (G91).
 */
export function gstTaxRows<T extends Record<string, unknown>>(
  base: T,
  policy: Pick<ResolvedTaxPolicy, 'components' | 'taxGroup'>,
  gst: VoucherGst,
): Array<T & { SR_NO: number; TAX_TYPE: string; TAX_PRC: number; TAX_AMT: number }> {
  const type = (srNo: number): string => policy.components.get(srNo)?.group || policy.taxGroup;
  const pct = (srNo: number, fallback: number): number =>
    policy.components.get(srNo)?.pct ?? fallback;
  if (gst.interState)
    return [
      { ...base, SR_NO: 3, TAX_TYPE: type(3), TAX_PRC: pct(3, gst.ratePct), TAX_AMT: gst.igst },
    ];
  const half = round(gst.ratePct / 2, 2);
  return [
    { ...base, SR_NO: 1, TAX_TYPE: type(1), TAX_PRC: pct(1, half), TAX_AMT: gst.sgst },
    { ...base, SR_NO: 2, TAX_TYPE: type(2), TAX_PRC: pct(2, half), TAX_AMT: gst.cgst },
  ];
}
