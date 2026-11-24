/**
 * WP-28 (D6): lossless reopen on the Purchase screens.
 *
 * `GET /purchases/:vchNo` returns every stored value under the name the edit request takes (purchaseReopen.ts on the
 * API). A screen shows only some of them; the rest must still go back on save, or the edit (which rebuilds the
 * voucher) resets them. These helpers send back every stored value the screen does NOT manage, under the values it
 * does. A field the screen manages is a key of its own body even when its value is `undefined` (cleared): the screen
 * decides it, and the stored value is never resurrected over an operator's change.
 */

/** Header fields of the edit request that a reopened voucher carries back when the screen does not show them. */
export const PURCHASE_HEADER_INPUT_KEYS = [
  'acCode',
  'acName',
  'billNo',
  'vchDate',
  'address1',
  'address2',
  'address3',
  'city',
  'mobile',
  'bankName',
  'chequeNo',
  'cardAc',
  'creditDays',
  'discountPct',
  'discountAmount',
  'tcsCode',
  'tcsPct',
  'tcsAmount',
  'tdsCode',
  'tdsPct',
  'tdsAmount',
  'saleBillNo',
  'saleBillLc',
  'saleBillYear',
  'saleBillBook',
  'consiNo',
  'consiLcCode',
  'consiYrcd',
  'consiDbcd',
  'taxRatePct',
  'taxCode',
  'interState',
  'urd',
  'rateUnfix',
  'hmAmount',
  'hmTaxPct',
  'hmTaxCode',
  'empCode',
  'vchDesc',
  'cashAmt',
  'chequeAmt',
  'cardAmt',
  'kasar',
  'bankAc',
] as const;

type Plain = Record<string, unknown>;

/** The stored values of `source` whose keys the screen's own `body` does not hold, under `body`. */
export function carryUnmanaged<T extends Plain>(
  source: Plain | null | undefined,
  body: T,
  keys?: readonly string[],
): T {
  if (!source) return body;
  const carried: Plain = {};
  for (const key of keys ?? Object.keys(source)) {
    if (key in body || !(key in source) || key === 'stones') continue;
    carried[key] = source[key];
  }
  return { ...carried, ...body } as T;
}

/** The header of a reopened voucher, carried under the screen's header body. */
export function carryPurchaseHeader<T extends Plain>(view: Plain | null | undefined, body: T): T {
  return carryUnmanaged(view, body, PURCHASE_HEADER_INPUT_KEYS);
}
