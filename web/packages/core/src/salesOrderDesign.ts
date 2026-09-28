import { Decimal } from 'decimal.js';

/** Saved Design identity, independent of its non-unique display number. */
export interface SalesOrderDesignSourceRef {
  prCode: string;
  bookName: string;
  srNo: number;
  oldSrNo: number | null;
  version: string;
}
export interface SalesOrderDesignOption {
  source: SalesOrderDesignSourceRef;
  designNo: string;
  bookName: string;
  productName: string;
  remark: string;
  itmSize: string;
  karigarName: string;
  grossWt: string | null;
  touch: string | null;
  westPct: string | null;
  labourPct: string | null;
  labourRate: string | null;
  designImageId: string | null;
}
export interface SalesOrderDesignList {
  rows: SalesOrderDesignOption[];
  offset: number;
  limit: number;
  hasMore: boolean;
  thirdColumnLabel: 'Product' | 'Remark';
}
export type SalesOrderDesignEvent =
  { kind: 'design'; source: SalesOrderDesignSourceRef } | { kind: 'clearDesign' };

/** TR_SALE_ORD:7366–7370. Clearing differs from cancelling the help dialog. */
export function clearSalesOrderDesignSelection<T extends object>(current: T): T {
  return { ...current, designNo: '', designImageId: 'N' };
}

/** TR_SALE_ORD:7341–7364. This is a copy event, not a calculation trigger.
 * `existing` must be derived from the saved parent, including for appended rows.
 * Frontend decimal strings stay strings; server numeric inputs stay numbers.
 * The source's nonzero predicate occurs BEFORE Strings.Format(..., "0.00"). */
export function applySalesOrderDesignSelection<T extends object>(
  current: T,
  option: SalesOrderDesignOption,
  { existing }: { existing: boolean },
): T {
  if (!option.designNo) return clearSalesOrderDesignSelection(current);
  const next: Record<string, unknown> = {
    ...current,
    designNo: option.designNo,
    itmSize: option.itmSize,
    karigarName: option.karigarName,
    designImageId: option.designImageId ?? '',
  };
  if (!existing) {
    const source = (value: string | null) => {
      const decimal = new Decimal(value ?? 0);
      if (!decimal.isFinite()) throw new Error('The selected design contains an invalid number.');
      return decimal;
    };
    const copyNonzero = (field: string, value: string | null) => {
      const decimal = source(value);
      if (!decimal.isZero()) {
        const formatted = decimal.toDecimalPlaces(2, Decimal.ROUND_HALF_UP).toFixed(2);
        const numeric = Number(formatted);
        if (typeof next[field] !== 'string' && !new Decimal(formatted).equals(numeric))
          throw new Error(
            'The selected design value requires exact decimal storage; this numeric order field cannot represent it.',
          );
        next[field] = typeof next[field] === 'string' ? formatted : numeric;
      }
    };
    copyNonzero('touch', option.touch);
    copyNonzero('westPct', option.westPct);
    copyNonzero('labourPct', option.labourPct);
    if (source(option.labourPct).isZero()) copyNonzero('labourRate', option.labourRate);
  }
  return next as T;
}
