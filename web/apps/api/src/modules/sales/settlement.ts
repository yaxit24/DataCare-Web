/**
 * The money/metal settlement engine (`BILL_TOTAL`) lives in `@datacare/core` (packages/core/src/settlement.ts),
 * so the wholesale / rate-cut screen previews with the same arithmetic the writer posts. This module keeps the
 * server's import path stable.
 */
export { rateFactor, settleMoneyMetal, settlementBalance } from '@datacare/core';
export type { RateBasis, SettlementInput, SettlementResult } from '@datacare/core';
