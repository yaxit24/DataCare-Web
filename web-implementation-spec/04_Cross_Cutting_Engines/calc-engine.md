# Calc Engine — weight, fine, labour, GST, bill totals

The pure (no-I/O) calculation core. **This is the single most parity-sensitive code in the system** —
if a rupee or milligram differs from the desktop, parity fails. It lives in `packages/core` and is
covered by golden-vector unit tests.

Source: `web/packages/core/src/money.ts`, `web/packages/core/src/calc.ts`.
Requirements: Req 12 (weight/fine/labour), Req 10.3/10.4/10.5 + 18 (GST), Req 13 (amounts).

## 1. Precision policy (do not deviate without an ADR)

```ts
// money.ts
export const PRECISION = { amount: 2, weight: 3, fine: 3 } as const;
export function round(value, dp) {
  return new Decimal(value).toDecimalPlaces(dp, Decimal.ROUND_HALF_UP).toNumber();
}
```
- **All math uses `decimal.js`** (never JS float). DB columns are `NUMERIC`.
- **HALF-UP** rounding: amounts → 2 dp, weights/fine → 3 dp.
- The desktop stored these as `FLOAT`; the web pins exact decimals and rounds at the same points the
  desktop did, so outputs match.

## 2. Fine (pure-metal) weight — Req 12.1

```ts
// fineWeight = netWt × touch / 100
export function fineWeight(netWt, touch, dp = PRECISION.fine) {
  return round(new Decimal(netWt).times(touch).div(100), dp);
}
```
**Example:** NWT 10.250 g, Touch 91.60 → fine = 10.250 × 91.60 / 100 = **9.389 g**.
Wastage variants add to touch before dividing: `fine = NWT × (TOUCH + WEST) / 100` (used in manufacturing/karigar).

## 3. Labour / making charge — Req 12.2–12.5

Four labour types; the desktop picks one per line via `LBR_TYPE`:

```ts
export function labourCharge(type, i) {
  switch (type) {
    case 'per_gram':   return round(D(i.netWt).times(i.rate), 2);           // NWT × rate
    case 'per_piece':  return round(D(i.pcs).times(i.rate), 2);            // pcs × rate
    case 'percentage': return round(D(i.metalAmount).times(i.pct).div(100), 2); // metal × pct%
    case 'fixed':      return round(D(i.fixed), 2);                        // flat amount
  }
}
```

| `LBR_TYPE` | Formula | Inputs |
|---|---|---|
| per_gram | `netWt × rate` | `LBR_RATE` per gram |
| per_piece | `pcs × rate` | `LBR_RATE` per piece |
| percentage | `metalAmount × pct / 100` | `LBR_PRC` |
| fixed | `fixedAmount` | `LBR_AMT` |

## 4. Metal amount & line net — Req 12.6

```ts
export function metalAmount(fineWt, rate) { return round(D(fineWt).times(rate), 2); } // fine × rate
export function lineNet(p) { return round(D(p.metal).plus(p.labour).plus(p.other ?? 0), 2); }
```
**Line net = metal amount + labour + other charges.** (Stones/other from sub-detail add into `other`.)

## 5. GST split — Req 10.4/10.5, 18.2/18.3

```ts
export function gstSplit(taxAmount, interState) {
  const t = D(taxAmount);
  if (interState) return { cgst: 0, sgst: 0, igst: round(t, 2) };   // inter-state ⇒ all IGST
  const cgst = round(t.div(2), 2);
  const sgst = round(t.minus(cgst), 2);   // SGST = tax − CGST  ⇒ CGST+SGST == tax EXACTLY
  return { cgst, sgst, igst: 0 };
}
```
- **Intra-state** (customer state == company state): CGST = SGST = tax/2, IGST = 0.
- **Inter-state**: IGST = tax, CGST = SGST = 0.
- The `SGST = tax − CGST` trick guarantees the two halves re-sum to the exact tax even on odd paise
  (e.g. tax 22.51 → CGST 11.26, SGST 11.25). **This is desktop parity — keep it.**

## 6. Bill totals pipeline — Req 10.3, 12

```ts
export function billTotals(i) {
  const net = D(i.lineNetTotal);
  const discount = D(i.discountAmount);
  const taxable = net.minus(discount);
  const tax = taxable.times(i.taxRatePct).div(100);
  const split = gstSplit(tax, i.interState);
  const preRound = taxable.plus(tax);
  const total = preRound.toDecimalPlaces(0, Decimal.ROUND_HALF_UP); // nearest rupee
  const roundOff = total.minus(preRound);
  return { net, discount, taxable, tax, ...split, roundOff, total }; // each round(...,2)
}
```

Pipeline order (**must** match): `Σ line nets → minus discount → taxable → × rate% = tax →
split CGST/SGST/IGST → taxable+tax → round to nearest rupee = total → roundOff = total − preRound`.

**Worked example.** Lines net ₹75,000; discount 0; GST 3% intra-state:
- taxable = 75000 · tax = 2250.00 · CGST = 1125.00, SGST = 1125.00, IGST = 0
- preRound = 77250.00 → total = **₹77,250** · roundOff = 0.00
- (This is the exact certified case in `HANDOFF.md`: "₹77,250 = 75000 + 3% GST 2250; cgst/sgst 1125".)

## 7. Mapping to desktop columns

| Calc output | Header column (`SL_DATA`/`PR_DATA`) | Line column (`SL_DETL`/`PR_DETL`) |
|---|---|---|
| line metal | — | `ITM_AMT` (metal part) |
| labour | `*_LBR_AMT` | `LBR_AMT` (+ `LBR_TYPE`,`LBR_RATE`,`LBR_PRC`) |
| line net | — | `ITM_AMT` (net) |
| net total | `NET_AMT` | — |
| discount | `DISC_AMT` / `DISC_PRC` | — |
| tax | `TAX_AMT` (+ `TAX_CODE`,`TAX_PRC`) | `ITM_CGST_AMT`,`ITM_SGST_AMT`,`ITM_IGST_AMT` |
| round-off | `ROF_AMT` | — |
| total | `TOT_AMT` | — |
| fine | — | `ITM_FINE` |

## 8. Parity criteria (DoD)

- Golden-vector unit tests for every labour type, GST type, and the bill pipeline (see `packages/core/test/calc.test.ts`).
- Recompute parity: for a sample of real invoices, `billTotals` reproduces the desktop `SL_DATA` totals
  field-for-field (HANDOFF cites 190/190 invoices matching). Tracked in `06_Parity/`.
- Any mismatch records the inputs + differing field (never silently rounds differently).
