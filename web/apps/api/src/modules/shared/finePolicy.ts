export type FineWorkflow =
  | 'sale'
  | 'salesOrder'
  | 'purchaseItem'
  | 'purchaseOldGold'
  | 'karigarIssue'
  | 'karigarReceipt'
  | 'itemOpening'
  | 'itemLot'
  | 'tagOpening'
  | 'melting'
  | 'mfg'
  | 'wholesaleSaleReturn';

export interface FineLine {
  netWt?: number;
  ghtWt?: number;
  touch?: number;
  westPct?: number;
  lesWt?: number;
  lesTouch?: number;
  kunFine?: number;
}

export const DEFAULT_FINE_WORKFLOW: FineWorkflow = 'sale';

const num = (value: unknown): number => Number(value ?? 0) || 0;
export const round3 = (value: number): number => Math.round((value + Number.EPSILON) * 1000) / 1000;

/** Resolve line fine using the desktop policy for the named workflow. */
export function fineFor(workflow: FineWorkflow, line: FineLine): number {
  const net = num(line.netWt);
  const ght = num(line.ghtWt);
  const touch = num(line.touch);
  const west = num(line.westPct);
  const pct = touch + west;
  let fine: number;

  switch (workflow) {
    // unified/src/csharp/DataCareNext/TR_ITM_OPBL.cs:949-955: touch/net gate; ghat ignored.
    case 'itemOpening':
      fine = touch !== 0 && net !== 0 ? (net * pct) / 100 : net;
      break;

    // unified/src/csharp/DataCareNext/TR_ITM_LOT.cs:2722-2732: touch/net gate; ghat ignored.
    case 'itemLot':
      fine = touch !== 0 && net !== 0 ? (net * pct) / 100 : net;
      break;

    // unified/src/csharp/DataCareNext/TR_KR_ISU.cs:3938-3944: subtract less weight in both branches.
    case 'karigarIssue':
      fine =
        pct !== 0 && net !== 0
          ? ((net + ght) * pct) / 100 - num(line.lesWt)
          : net - num(line.lesWt);
      break;

    // unified/src/csharp/DataCareNext/TR_PURC.cs:7310-7317: Kun fine and less-touch old-gold policy.
    case 'purchaseOldGold':
      fine =
        pct !== 0 && net !== 0
          ? ((net + ght) * (pct - num(line.lesTouch))) / 100 + num(line.kunFine)
          : net + num(line.kunFine);
      break;

    // unified/src/csharp/DataCareNext/MS_UPDATE.cs:2691: receipt fine is net-only with touch + west.
    case 'karigarReceipt':
      fine = (net * pct) / 100;
      break;

    // TR_WH_SALE_RTN.cs:5729-5771 subtracts less touch from touch + wastage and falls back
    // to net + ghat when both touch and wastage are zero.
    case 'wholesaleSaleReturn':
      fine =
        touch + west !== 0 && net !== 0
          ? ((net + ght) * (touch + west - num(line.lesTouch))) / 100
          : net + ght;
      break;

    // TR_TAG_OPBL.cs:6590 and the existing sale/purchase-item/order/melting/mfg policy.
    case 'sale':
    case 'salesOrder':
    case 'purchaseItem':
    case 'tagOpening':
    case 'melting':
    case 'mfg':
      fine = pct === 0 ? net + ght : ((net + ght) * pct) / 100;
      break;

    default: {
      const exhaustive: never = workflow;
      return exhaustive;
    }
  }

  return round3(fine);
}
