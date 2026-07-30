# Cross-Cutting Engines

These engines are the shared machinery **every transaction module depends on**. Build and
parity-certify them **first** — a bug here corrupts every voucher. All code shown is from the
existing `web/` implementation (cited path), so it is the authoritative spec.

## The engines

| Engine | Doc | Web source | What it guarantees |
|---|---|---|---|
| Weight / fine / labour calc | [`calc-engine.md`](calc-engine.md) | `packages/core/src/{calc,money}.ts` | Amounts match desktop to fixed precision |
| Double-entry posting / ledger | [`posting-and-ledger.md`](posting-and-ledger.md) | `apps/api/src/modules/posting/posting.ts` | Every voucher posts a **balanced** `AC_DATA` set, atomically |
| Voucher numbering | [`voucher-numbering.md`](voucher-numbering.md) | `apps/api/src/modules/vouchers/numbering.ts` | Sequential, unique-per-scope, gap-free under concurrency |
| GST engine | [`gst-engine.md`](gst-engine.md) | `packages/core` `gstSplit` + `modules/gst` | Correct CGST/SGST vs IGST split; penny-exact |
| Auth & RBAC | [`auth-and-rbac.md`](auth-and-rbac.md) | `modules/auth`, `modules/rbac` | Login parity; per-right + per-menu enforcement |
| Reporting & Integrations | [`reporting-and-integrations.md`](reporting-and-integrations.md) | `packages/reports`, `modules/integrations` | HTML/PDF reports; non-blocking WhatsApp/SMS/IRN/rates |

## How they compose (the transaction recipe)

Every posting transaction (sale, purchase, dhrn, finance, mfg) follows the same shape:

```ts
async function createXxx(prisma, tenantId, scope, dto) {
  // 1. PURE CALC (no I/O) — packages/core
  const totals = billTotals({ lineNetTotal, discountAmount, taxRatePct, interState });

  // 2. ONE TENANT TRANSACTION — everything below is atomic (rolls back together)
  return withTenant(prisma, tenantId, async (tx) => {
    // 2a. number from the per-scope sequence (advisory-locked)
    const vchNo = await nextVoucherNoTx(tx, scope);

    // 2b. build header/detail/tax/stock rows + the balanced AC_DATA ledger legs
    const writes = [{ table: 'SL_DATA', rows: [header] }, { table: 'SL_DETL', rows: lines }, ...];
    const ledger = { table: 'AC_DATA', lines: [drCustomer, crSales, crTax] };

    // 2c. post — asserts ΣCR=ΣDR + period-lock, then inserts everything
    await postVoucherTx(tx, tenantId, { ledger, writes, bookName: 'SALES' });
    return { vchNo, totals };
  });
}
```

Delete/edit reuse the same primitives: `reverseVoucherTx` (delete all the voucher's rows by key +
write `DELETE_DATA`), and **edit = reverse then post in the same tx**.

## Dependency order (build first → last)

```
money/round  →  calc  →  gstSplit/billTotals
withTenant/atomic (db)  →  numbering  →  posting  →  (every txn module)
auth  →  rbac  →  (every route)
reports renderer, integrations adapters  →  (reports + notify endpoints)
```
