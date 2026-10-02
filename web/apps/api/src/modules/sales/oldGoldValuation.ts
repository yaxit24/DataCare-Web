/**
 * Old-gold (exchange) line valuation now lives in `@datacare/core` (`packages/core/src/oldGold.ts`), so the
 * writer and every screen that previews an exchange line compute the same figure (G83). This module re-exports
 * it for existing API importers.
 */
export {
  oldGoldAmountFromRate,
  oldGoldBasisWeight,
  oldGoldFine,
  oldGoldRateFromAmount,
  resolveOldGoldValuation,
  valueOldGoldLine,
} from '@datacare/core';
export type { OldGoldRateType, OldGoldValuationInput } from '@datacare/core';
