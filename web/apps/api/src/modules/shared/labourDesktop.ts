import { roundHalfEven } from '@datacare/core';

/**
 * The desktop's labour model.
 *
 * WHAT THE DESKTOP ACTUALLY DOES
 * ------------------------------
 * `LBR_TYPE` is not a pricing mode. It selects the **basis** that `LBR_RATE` is multiplied by. Its four values
 * come from `CO_SET.LBR_TYPE`'s own option list, and the arithmetic from the write-set bindings of the sale
 * grid:
 *
 *   G  "Gorss Wise"  ITM_GWT x LBR_RATE                          TR_SALE.cs:11104
 *   N  "Net Wise"    ITM_NWT x LBR_RATE                          TR_SALE.cs:11119
 *   K  "Kg Wise"     (ITM_NWT + ITM_GHT_WT) x LBR_RATE / 1000    TR_SALE.cs:11108
 *   P  "Pcs Wise"    ITM_PCS x LBR_RATE                          TR_SALE.cs:11127
 *
 * When `MsLbrWithGht <> 'N'` the weight bases include `ITM_GHT_WT` (TR_SALE.cs:11112, :11100, :11123).
 *
 * A percentage is a SEPARATE input that derives the rate rather than a type of its own:
 *
 *   LBR_RATE = Math.Round(ITM_RATE x LBR_PRC / 100, MsLbrRof)     TR_SALE.cs:11021
 *
 * and the amount is then computed from that derived rate through the same basis rule. Every one of the six
 * amount branches multiplies by column 26, which the write set binds to `LBR_RATE` — the desktop never applies
 * a percentage directly to a line total.
 *
 * WHY THIS MODULE EXISTS
 * ----------------------
 * The web modelled labour as `per_gram | per_piece | percentage | fixed` and mapped those onto the desktop
 * codes as `per_gram -> G`, `per_piece -> P`, `percentage -> '%'`, `fixed -> N`. Three of those four are wrong:
 *
 *  * `G` is GROSS weight, so per-gram on net weight is `N`, not `G`;
 *  * `N` is NET weight times rate, so labelling a flat amount `N` makes the desktop recompute it as a rate;
 *  * `'%'` is not a value `LBR_TYPE` ever holds — the column is `varchar(1)` and the option list is G/N/K/P;
 *  * `K` had no representation at all, so a shop quoting labour per kilogram could not be modelled.
 *
 * `LBR_TYPE` and `LBR_RATE` are persisted and read back when a voucher is reopened, so these are not labelling
 * problems. A percentage line was storing `LBR_RATE = 0`, and the amount was computed as
 * `metalAmount x pct / 100` — 6815.04 where the desktop produces 7440 on a 91.6-touch line.
 *
 * Grid columns were resolved from the write set rather than assumed:
 *   11=ITM_PCS  12=ITM_GWT  13=ITM_OTH_WT  14=ITM_NWT  17=ITM_GHT_WT
 *   22=ITM_RATE 24=LBR_PRC  25=LBR_TYPE    26=LBR_RATE 27=LBR_AMT
 */

/** The only values `LBR_TYPE` holds, in the order `CO_SET.LBR_TYPE` offers them. */
export const DESKTOP_LABOUR_TYPES = ['G', 'N', 'K', 'P'] as const;

export type DesktopLabourType = (typeof DESKTOP_LABOUR_TYPES)[number];

/** Human labels, preserving the desktop's own misspelling of "Gross". */
export const DESKTOP_LABOUR_LABELS: Record<DesktopLabourType, string> = {
  G: 'Gorss Wise',
  N: 'Net Wise',
  K: 'Kg Wise',
  P: 'Pcs Wise',
};

export function isDesktopLabourType(value: unknown): value is DesktopLabourType {
  return (DESKTOP_LABOUR_TYPES as readonly string[]).includes(String(value ?? ''));
}

export interface LabourBasis {
  /** `ITM_GWT` — gross weight. */
  grossWt: number;
  /** `ITM_NWT` — net weight. */
  netWt: number;
  /** `ITM_PCS` — pieces. */
  pcs: number;
  /** `ITM_GHT_WT` — ghat (wastage-carrier) weight. */
  ghatWt: number;
  /** `LBR_RATE` — the rate per basis unit. */
  rate: number;
}

export interface LabourOptions {
  /**
   * `MsLbrWithGht <> 'N'`. When set, the weight bases add `ITM_GHT_WT` (TR_SALE.cs:11112).
   * `K` includes ghat weight unconditionally, which is why it is not governed by this flag.
   */
  withGhat?: boolean;
  /** Decimal places for the amount. `Math.Round(x, digits2)`; the sale grid uses 2. */
  decimals?: number;
}

const n = (v: unknown): number => {
  const x = typeof v === 'number' ? v : Number(v);
  return Number.isFinite(x) ? x : 0;
};

/**
 * `LBR_AMT` for one line.
 *
 * Rounding is `Math.Round(value, digits)` with no `MidpointRounding` argument, which in .NET is banker's
 * rounding — so 12.5 becomes 12, not 13. Using half-up here would disagree with the desktop on every exact
 * midpoint.
 */
export function desktopLabourAmount(
  type: DesktopLabourType,
  basis: LabourBasis,
  options: LabourOptions = {},
): number {
  const decimals = options.decimals ?? 2;
  const rate = n(basis.rate);
  const ghat = n(basis.ghatWt);
  const netBasis = n(basis.netWt) + (options.withGhat ? ghat : 0);

  let raw: number;
  switch (type) {
    case 'G':
      // TR_SALE.cs:11104 — gross weight. Note it is NOT net, which is the confusion this module exists to fix.
      raw = (n(basis.grossWt) + (options.withGhat ? ghat : 0)) * rate;
      break;
    case 'N':
      // TR_SALE.cs:11119, and :11100/:11123 for the with-ghat variant.
      raw = netBasis * rate;
      break;
    case 'K':
      // TR_SALE.cs:11108 — the rate is quoted per KILOGRAM, and ghat weight is always part of the basis.
      // Omitting the /1000 inflates the charge a thousandfold.
      raw = (n(basis.netWt) + ghat) * (rate / 1000);
      break;
    case 'P':
      // TR_SALE.cs:11127 — pieces.
      raw = n(basis.pcs) * rate;
      break;
    default:
      // A code outside G/N/K/P cannot be interpreted. Throwing is deliberate: silently treating an unknown
      // code as net weight is how `'%'` produced plausible-looking but wrong amounts.
      throw new Error(`unknown labour type: ${String(type)}`);
  }
  return roundHalfEven(raw, decimals);
}

/**
 * `LBR_RATE` derived from a percentage of the item rate — TR_SALE.cs:11021.
 *
 *   LBR_RATE = Math.Round(ITM_RATE x LBR_PRC / 100, MsLbrRof)
 *
 * `MsLbrRof` comes from `CO_SET.LBR_ROF`, so the decimal count is a company setting and not a constant. A zero
 * percentage returns zero: TR_SALE.cs:11032 returns early in that case, leaving whatever rate the operator
 * typed untouched, so the caller must not overwrite an explicit rate with this result when the percentage is 0.
 */
export function desktopLabourRateFromPercent(
  itemRate: number,
  labourPct: number,
  lbrRof: number,
): number {
  const pct = n(labourPct);
  if (pct === 0) return 0;
  return roundHalfEven((n(itemRate) * pct) / 100, Math.max(0, Math.trunc(n(lbrRof))));
}

/**
 * Resolve the effective rate for a line: an explicit rate wins, otherwise derive it from the percentage.
 *
 * The desktop only computes col 26 from the percentage when the percentage is non-zero (TR_SALE.cs:11032),
 * so an operator-entered rate is never silently replaced.
 */
export function effectiveLabourRate(
  explicitRate: number | undefined,
  itemRate: number,
  labourPct: number | undefined,
  lbrRof: number,
): number {
  const explicit = n(explicitRate);
  if (explicit !== 0) return explicit;
  return desktopLabourRateFromPercent(itemRate, n(labourPct), lbrRof);
}

/**
 * Map the API's labour mode onto the desktop's basis code.
 *
 * The two vocabularies do not correspond one to one, and pretending they do is what produced the original
 * defect. What each API value means in desktop terms:
 *
 *   per_gram    a rate per gram of NET weight  ->  'N'   (NOT 'G', which is gross weight)
 *   per_piece   a rate per piece               ->  'P'
 *   percentage  not a basis at all             ->  the company default, with LBR_RATE derived from LBR_PRC
 *   fixed       no desktop equivalent          ->  the company default
 *
 * `fixed` is an invention of the web model: `LBR_TYPE` has no flat-amount code, so a fixed charge cannot be
 * expressed in a way the desktop would reproduce on reopen. It falls back to the company default rather than
 * to 'N', because sending 'N' would make the desktop recompute the flat amount as net weight times rate. That
 * limitation is recorded rather than papered over — see FEATURE-GAP-REGISTER.
 */
export function desktopLabourTypeFor(
  mode: string | undefined,
  companyDefault: string | undefined,
): string {
  const fallback = isDesktopLabourType(companyDefault) ? companyDefault : '';
  if (!mode) return fallback;
  // A caller may already speak the desktop's language.
  if (isDesktopLabourType(mode)) return mode;
  switch (mode) {
    case 'per_gram':
      return 'N';
    case 'per_piece':
      return 'P';
    case 'percentage':
    case 'fixed':
      return fallback;
    default:
      return fallback;
  }
}

/**
 * Read a persisted `LBR_TYPE` back into the API's legacy mode vocabulary.
 *
 * The mapping is LOSSY in one direction and that is stated rather than hidden: the desktop has four bases but
 * the legacy API vocabulary only expresses two of them.
 *
 *   'N' -> 'per_gram'    net weight x rate
 *   'P' -> 'per_piece'   pieces x rate
 *   'G' -> undefined     gross weight x rate has no legacy mode
 *   'K' -> undefined     per-kilogram has no legacy mode
 *
 * Callers that need fidelity must read the raw code. Returning `undefined` for G and K is deliberate: the
 * alternative is to claim a line is per-gram when it is priced on gross weight or per kilogram, which would
 * silently change the amount on the next save.
 *
 * The inverse of `desktopLabourTypeFor` must agree with it. It previously read 'N' as 'fixed', so once the
 * forward map was corrected to send per-gram to 'N', a saved line would have read back as a flat charge - a
 * round-trip corruption introduced by fixing only one direction.
 */
export function legacyLabourModeFor(code: unknown): 'per_gram' | 'per_piece' | undefined {
  switch (
    String(code ?? '')
      .trim()
      .toUpperCase()
      .slice(0, 1)
  ) {
    case 'N':
      return 'per_gram';
    case 'P':
      return 'per_piece';
    default:
      // 'G' and 'K' have no legacy equivalent, and neither does a blank or unknown code.
      return undefined;
  }
}
