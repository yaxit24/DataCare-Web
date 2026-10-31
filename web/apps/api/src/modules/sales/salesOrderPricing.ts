import {
  billTotals,
  salesOrderBill,
  salesOrderItemAmount,
  type OrderLabourPolicy,
} from '@datacare/core';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import type { VoucherScope } from '../vouchers/numbering.js';

/**
 * N196 (G205): a Sales Order prices its metal on the company's SL_AMT_TYPE in whole rupees and rounds its tax and
 * total to rupees (`@datacare/core` salesOrderAmount.ts, TR_SALE_ORD.cs:6571-6672 and :11340-11342). The Tour Order
 * is a separate desktop form (TR_TOUR_ORD) and keeps its own pricing, so its policy has no `itemAmountType`.
 */
export type OrderPricingPolicy = OrderLabourPolicy & { itemAmountType?: string };

const num = (v: unknown): number => (v == null || v === '' ? 0 : Number(v));
const code = (v: unknown): string =>
  String(v ?? '')
    .trim()
    .toUpperCase();

interface PricedLine {
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  ghtWt?: number;
  touch?: number;
  westPct?: number;
  rate?: number;
  rateType?: string;
}

/** CO_SET.SL_AMT_TYPE as the desktop reads it (blank is N): the basis a Sales Order's metal is priced on. */
export async function salesOrderAmountTypeTx(tx: any, scope: VoucherScope): Promise<string> {
  return (await resolveSettingsBehaviorTx(tx, scope)).saleAmountType;
}

/** The line's labour policy, plus the company amount basis when the order is a Sales Order. */
export async function orderPricingPolicyTx(
  tx: any,
  scope: VoucherScope,
  mainBook: string,
  labour: OrderLabourPolicy,
): Promise<OrderPricingPolicy> {
  if (mainBook !== 'SALES ORDER') return labour;
  return { ...labour, itemAmountType: await salesOrderAmountTypeTx(tx, scope) };
}

/** True when none of the inputs the metal depends on differs from the saved row. */
export function orderMetalUnchanged(
  policy: OrderPricingPolicy,
  line: PricedLine,
  prior: Record<string, any>,
): boolean {
  const inputs: Array<[keyof PricedLine, string]> = [
    ['netWt', 'ITM_NWT'],
    ['ghtWt', 'ITM_GHT_WT'],
    ['touch', 'ITM_TOUCH'],
    ['westPct', 'ITM_WEST_PRC'],
    ['rate', 'ITM_RATE'],
  ];
  if (policy.itemAmountType) {
    if (code(line.rateType) !== code(prior.RATE_TYPE)) return false;
    if (code(policy.itemAmountType) === 'G') inputs.push(['grossWt', 'ITM_GWT']);
    if (code(line.rateType) === 'P') inputs.push(['pcs', 'ITM_PCS']);
  }
  return inputs.every(([field, column]) => num(line[field]) === num(prior[column]));
}

/** The Sales Order metal amount by the desktop rule, or null when the order (the Tour Order) prices otherwise. */
export function orderMetalAmount(policy: OrderPricingPolicy, line: PricedLine): number | null {
  if (!policy.itemAmountType) return null;
  return salesOrderItemAmount(
    {
      pcs: num(line.pcs),
      grossWt: num(line.grossWt),
      netWt: num(line.netWt),
      ghtWt: num(line.ghtWt),
      touch: num(line.touch),
      westPct: num(line.westPct),
    },
    policy.itemAmountType,
    num(line.rate),
    line.rateType,
  );
}

/** Bill totals: whole-rupee tax and total on a Sales Order, the previous core totals otherwise. */
export function orderTotals(
  policy: OrderPricingPolicy,
  input: { lineNetTotal: number; taxRatePct: number; interState: boolean },
) {
  const totals = billTotals(input);
  if (!policy.itemAmountType) return totals;
  const bill = salesOrderBill(input.lineNetTotal, input.taxRatePct);
  return { ...totals, taxable: bill.net, tax: bill.tax, total: bill.total };
}
