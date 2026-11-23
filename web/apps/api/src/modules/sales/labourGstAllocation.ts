import { roundHalfEven } from '@datacare/core';

/**
 * The per-line GST share the desktop labour invoice stores on LBR_ISU_DETL after save (TR_SALE_LBR.cs:9748-9830),
 * which the Gst Report's HSN section sums (RP_GST.cs:2719: IT_NET_AMT/IT_TAX_AMT/IT_DISC_AMT for the item arm,
 * IT_LBR_AMT/IT_LBR_TAX/IT_LBR_DISC for the labour arm under HSN 998892).
 *
 * Item arm (:9748-9787), run only when the voucher's metal tax and metal net are both non-zero, for each line whose
 * NET_AMT is non-zero:
 *   IT_NET_AMT  = NET_AMT + NET_AMT / SUM(NET_AMT) * (SL_NET_AMT - SUM(NET_AMT))
 *   IT_TAX_AMT  = Math.Round(IT_NET_AMT * TAX_AMT / SL_NET_AMT, 2)
 *   IT_DISC_AMT = Math.Round(IT_NET_AMT * 0 / SL_NET_AMT, 2)        (the query selects `0 As VCH_DISC_AMT`)
 * Labour arm (:9789-9830), run only when the labour tax and DR_LBR are both non-zero, for each line whose LBR_AMT is
 * non-zero:
 *   IT_LBR_AMT  = LBR_AMT + LBR_AMT / SUM(LBR_AMT) * (DR_LBR - SUM(LBR_AMT))
 *   IT_LBR_TAX  = Math.Round(IT_LBR_AMT * LBR_TAX_AMT / DR_LBR, 2)
 *   IT_LBR_DISC = Math.Round(IT_LBR_AMT * LBR_DISC_AMT / DR_LBR, 2)
 * Lines the desktop does not update keep the column default 0 (MS_UPDATE.cs:6378, 6435, 6706).
 * `Math.Round(x, 2)` is the .NET default midpoint-to-even (`roundHalfEven`); the shares are doubles, as the desktop
 * FLOAT columns are.
 */
export interface LabourGstLine {
  netAmount: number;
  labourAmount: number;
}

export interface LabourGstVoucher {
  /** LBR_DATA.SL_NET_AMT: the metal taxable value. */
  metalNet: number;
  /** LBR_DATA.TAX_AMT: the metal GST. */
  metalTax: number;
  /** LBR_DATA.DR_LBR: the labour value the labour tax is charged on. */
  labourNet: number;
  /** LBR_DATA.LBR_TAX_AMT. */
  labourTax: number;
  /** LBR_DATA.LBR_DISC_AMT. */
  labourDiscount: number;
}

export interface LabourGstShare {
  IT_NET_AMT: number;
  IT_TAX_AMT: number;
  IT_DISC_AMT: number;
  IT_LBR_AMT: number;
  IT_LBR_TAX: number;
  IT_LBR_DISC: number;
}

const ZERO: LabourGstShare = {
  IT_NET_AMT: 0,
  IT_TAX_AMT: 0,
  IT_DISC_AMT: 0,
  IT_LBR_AMT: 0,
  IT_LBR_TAX: 0,
  IT_LBR_DISC: 0,
};

export function labourGstAllocation(
  lines: readonly LabourGstLine[],
  voucher: LabourGstVoucher,
): LabourGstShare[] {
  const shares = lines.map(() => ({ ...ZERO }));
  const itemTotal = lines.reduce((sum, line) => sum + line.netAmount, 0);
  if (voucher.metalTax !== 0 && voucher.metalNet !== 0) {
    lines.forEach((line, index) => {
      if (line.netAmount === 0) return;
      const net = line.netAmount + (line.netAmount / itemTotal) * (voucher.metalNet - itemTotal);
      shares[index]!.IT_NET_AMT = net;
      shares[index]!.IT_TAX_AMT = roundHalfEven((net * voucher.metalTax) / voucher.metalNet, 2);
      shares[index]!.IT_DISC_AMT = roundHalfEven((net * 0) / voucher.metalNet, 2);
    });
  }
  const labourTotal = lines.reduce((sum, line) => sum + line.labourAmount, 0);
  if (voucher.labourTax !== 0 && voucher.labourNet !== 0) {
    lines.forEach((line, index) => {
      if (line.labourAmount === 0) return;
      const net =
        line.labourAmount + (line.labourAmount / labourTotal) * (voucher.labourNet - labourTotal);
      shares[index]!.IT_LBR_AMT = net;
      shares[index]!.IT_LBR_TAX = roundHalfEven((net * voucher.labourTax) / voucher.labourNet, 2);
      shares[index]!.IT_LBR_DISC = roundHalfEven(
        (net * voucher.labourDiscount) / voucher.labourNet,
        2,
      );
    });
  }
  return shares;
}
