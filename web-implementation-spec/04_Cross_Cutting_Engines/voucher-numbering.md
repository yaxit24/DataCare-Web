# Voucher Numbering Engine

Allocates the next sequential voucher number for a scope, **unique and gap-free even under
concurrency**. Desktop uses `SRNO_MAST` counters; the web reproduces this with a Postgres
transaction advisory lock so allocation composes safely with posting in one transaction.

Source: `web/apps/api/src/modules/vouchers/numbering.ts`. Requirements: Req 9.1–9.4.

## 1. The counter table — `SRNO_MAST`

The recovered `SRNO_MAST` keys on **`CO_CODE, LC_CODE`** only and holds `VCH_SRNO` (the last used
serial). The advisory-lock key uses the **full** scope (`tenant|CO|LC|YEAR|BOOK`) so the contract is
future-ready, while the persisted counter uses the columns the table actually has.

> **Open item:** per-book / per-year counter columns are not in the recovered schema. If the desktop
> numbered per `CO_BOOK`/`CO_YEAR`, recover the authoritative `SRNO_MAST` columns via the Docker
> SQL-Server pass before finalizing (tracked in `06_Parity/`). Until then, numbering is per `CO_CODE,LC_CODE`.

## 2. Allocation within a transaction

```ts
export async function nextVoucherNoTx(tx, s) {
  await tx.$executeRawUnsafe('SELECT pg_advisory_xact_lock(hashtext($1))', scopeKey(s)); // serialize per scope
  const rows = await tx.$queryRawUnsafe(
    'SELECT "VCH_SRNO" FROM "SRNO_MAST" WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 LIMIT 1', s.coCode, s.lcCode);
  if (rows.length === 0) {                       // first voucher in this scope
    await tx.$executeRawUnsafe('INSERT INTO "SRNO_MAST"(tenant_id,"CO_CODE","LC_CODE","VCH_SRNO") VALUES ($1,$2,$3,$4)', s.tenantId, s.coCode, s.lcCode, 1);
    return 1;
  }
  const next = Number(rows[0].VCH_SRNO ?? 0) + 1;
  await tx.$executeRawUnsafe('UPDATE "SRNO_MAST" SET "VCH_SRNO"=$1 WHERE "CO_CODE"=$2 AND "LC_CODE"=$3', next, s.coCode, s.lcCode);
  return next;
}
```

## 3. Why it's concurrency-safe (Req 9.2/9.3)

- `pg_advisory_xact_lock(hashtext(scopeKey))` is held **until the surrounding transaction commits**.
- Because a transaction module does `nextVoucherNoTx → build rows → postVoucherTx` all in **one**
  `withTenant` tx, the lock spans the whole voucher write. Two users saving in the same scope are
  serialized: each gets a distinct, sequential number; no gaps, no duplicates.
- Proven: "8 concurrent → distinct 1..8" (HANDOFF / numbering live test).

## 4. Desktop nuance: TR_PURC reserves explicitly

`TR_PURC` does an explicit `DELETE`+`INSERT` on `SRNO_MAST` (decompiled L13455/13457) to reserve the
next number. The web's read-increment-under-lock achieves the same guarantee without the
delete/insert dance. Document any per-form numbering quirks in that form's deep-dive.

## 5. Contract

```ts
export interface VoucherScope { tenantId: string; coCode: string; lcCode: string; coYear?: string; coBook?: string; }
export function nextVoucherNo(prisma, s): Promise<number>;     // standalone (own tx)
export function nextVoucherNoTx(tx, s): Promise<number>;       // compose inside an existing tx (preferred)
```

## 6. Parity criteria (DoD)

- Sequential allocation per scope starting at 1; no gaps under normal operation.
- Concurrency test: N parallel allocations in one scope yield the set `{1..N}` with no duplicates.
- The saved `VCH_NO` on the header matches the allocated serial.
