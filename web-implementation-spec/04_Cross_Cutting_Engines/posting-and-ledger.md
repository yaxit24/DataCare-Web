# Posting & Ledger Engine — double-entry into AC_DATA

Every posting voucher (sale, purchase, receipt, payment, contra, dhrn, manufacturing, journal)
writes a **balanced** set of debit/credit rows into `AC_DATA`. In the desktop this is centralized in
`Ac_Ledr.cs`; in the web it is `modules/posting/posting.ts`. This engine is the heart of accounting
parity — trial balance only ties if every voucher posts ΣCR = ΣDR.

Source: `web/apps/api/src/modules/posting/posting.ts`. Desktop: `unified/src/csharp/DataCareNext/Ac_Ledr.cs` → `INSERT INTO AC_DATA(...CR_AMT,DR_AMT,FINE_WT,FINE_RATE,LEDR_KEY...)`.
Requirements: Req 5.4/5.5 (atomic), 13.1 (balanced), 13.4 (reverse on delete).

## 1. The ledger row (`AC_DATA`, 29 columns)

Each `AC_DATA` row is one ledger leg. Money **and** metal live on the same row:

| Group | Columns |
|---|---|
| Scope key | `CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, VCH_TYPE, VCH_DATE` |
| Account | `AC_CODE` (the account this leg hits), `LD_CODE` (line ordinal), `LDR_NAME`, `PARTY_AC_CODE` |
| Money | `CR_AMT`, `DR_AMT` (exactly one set per leg) |
| Metal | `FINE_WT`, `FINE_RATE` (parallel metal ledger), `IT_TYPE` (`A`=amount, `G`/`S`=gold/silver) |
| Identity / parity | `LEDR_KEY` (unique line key), `BOOK_NAME`, `DATA_TYPE`='A', `SIGN`, `HD_VCH_NO` |
| Misc | `BILL_NO, BILL_DATE, CHQ_NO, CLR_DATE, ENTRY_TIME, MAIN_USER, IT_DESC` |

See [`../02_Data_Model/tables/AC_DATA.md`](../02_Data_Model/tables/AC_DATA.md) for the full column list.

## 2. Balance invariant — Req 13.1

```ts
export function ledgerBalance(lines) {
  const cr = round2(lines.reduce((s,l)=>s+Number(l.CR_AMT??0),0));
  const dr = round2(lines.reduce((s,l)=>s+Number(l.DR_AMT??0),0));
  return { cr, dr, balanced: cr === dr };
}
export function assertBalanced(lines) { const b = ledgerBalance(lines); if (!b.balanced) throw new UnbalancedError(b.cr,b.dr); }
```
`postVoucherTx` calls `assertBalanced` **before** writing anything — an unbalanced voucher can never
be persisted. (Metal legs balance independently of money legs — Req 13.5.)

## 3. Ledger-line enrichment (desktop parity fields)

The desktop stamps several fields on every `AC_DATA` row. `enrichLedgerLine` reproduces them so the
parity diff matches:

```ts
function enrichLedgerLine(line, srno, bookName) {
  e.LEDR_KEY  ??= `${CO_CODE}${LC_CODE}${CO_YEAR}${CO_BOOK}${pad(VCH_NO,6)}${pad(srno,2)}`; // unique line key
  e.IT_TYPE   ??= 'A';     // money leg ('G'/'S' for metal legs, set by the caller)
  e.DATA_TYPE ??= 'A';     // desktop sets DATA_TYPE='A' on 100% of data rows
  e.LD_CODE   ??= srno;    // line ordinal
  e.BOOK_NAME ??= bookName;// 'SALES' / 'PURC' / ...
  return e;
}
```
`postVoucherTx` also auto-stamps `DATA_TYPE='A'` on any *written* table that has that column (it
checks `information_schema` once per table and caches it).

## 4. Posting within a transaction

```ts
export async function postVoucherTx(tx, tenantId, input) {
  assertBalanced(input.ledger.lines);            // ΣCR == ΣDR
  await assertPeriodOpen(tx, tenantId, input);    // period-lock guard (CO_SET.LOCK_DATE)
  for (const w of input.writes ?? [])             // header, detail, tax, stock, ancillary
    for (const r of w.rows) await insertRowTx(tx, w.table, tenantId, { ...r, DATA_TYPE? });
  let srno = 0;
  for (const line of input.ledger.lines) {        // AC_DATA legs, enriched
    srno++;
    await insertRowTx(tx, input.ledger.table, tenantId, enrichLedgerLine(line, srno, input.bookName));
  }
}
```
- `insertRowTx` builds a parameterized `INSERT` (`tenant_id` + the row's columns) — identifiers are
  sanitized (`[^A-Za-z0-9_]` stripped) to prevent injection.
- `postVoucher` wraps `postVoucherTx` in its own `withTenant` tx for standalone use; transaction
  modules call `postVoucherTx` inside their **own** tx so numbering + stock + posting are one unit.

## 5. Period lock — `CO_SET.LOCK_DATE`

```ts
// throws PeriodLockValidationError (→ HTTP 400) if VCH_DATE <= CO_SET.LOCK_DATE
await assertPeriodOpen(tx, tenantId, input);
```
Opt-in: if no lock date is configured, the period is open and posting proceeds. Desktop parity: `MsLockDt`.

## 6. Reverse / delete — Req 10.10, 11.5, 13.4

```ts
export async function reverseVoucherTx(tx, tenantId, { tables, key, deleteLog }) {
  const where = Object.keys(key).map((k,i)=>`"${k}"::text=$${i+1}::text`).join(' AND ');
  for (const t of tables) await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE ${where}`, ...vals);
  if (deleteLog) await insertRowTx(tx, deleteLog.table, tenantId, deleteLog.row); // DELETE_DATA audit
}
```
- Deletes the voucher's rows from **every** table it wrote (header, detail, `AC_DATA`, `TAX_DATA`,
  stock, ancillary) by the voucher key, then writes a `DELETE_DATA` audit row.
- Stock/tag **restoration** is done by the module (it re-marks issued tags available) inside the same tx.
- Requires `USER_DELETE`.

## 7. Edit = reverse + repost (atomic)

The desktop edits by delete-then-insert. The web rule: in one `withTenant` tx, call
`reverseVoucherTx` for the old voucher, then `postVoucherTx` for the new state. Net persisted rows
are identical to a desktop edit, but atomic and auditable.

## 8. Standard posting shapes

| Voucher | Debit | Credit | Metal legs |
|---|---|---|---|
| Sale (intra) | Customer (`AC_CODE`) | Sales + CGST + SGST | metal out on item legs |
| Sale (inter) | Customer | Sales + IGST | — |
| Purchase | Purchase + input-tax | Supplier | metal in |
| Receipt | Cash/Bank | Customer | — |
| Payment | Supplier | Cash/Bank | — |
| Contra | Account A | Account B | — |
| Dhrn issue | Loan-to-party | Cash | pledged metal tracked separately |

## 9. Parity criteria (DoD)

- For any saved voucher, ΣCR = ΣDR (and Σ metal in = Σ metal out where applicable).
- The exact `AC_DATA` row-set (accounts, amounts, `LEDR_KEY`, `BOOK_NAME`, `IT_TYPE`) matches the
  desktop for the same input.
- After delete, no `AC_DATA`/detail rows remain for the key and a `DELETE_DATA` row exists.
- Trial balance over all `AC_DATA` nets to zero (HANDOFF cites Dr=Cr verified). Tracked in `06_Parity/`.
