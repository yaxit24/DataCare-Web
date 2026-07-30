# TR_CARD_REC — Card Receipt (variant stub)

```
Form: TR_CARD_REC  ·  Module: 7_Finance_CashBank  ·  Type: transaction (posting)
Desktop source: unified/src/csharp/DataCareNext/TR_CARD_REC.cs (4,063 lines)
Web target: apps/api/src/modules/finance/finance.ts (postReceipt mode='card') · apps/web/app/(app)/txn/receipts
Requirements: Req 17.1 (balanced), 17.4 (card → bank/clearing), 13.4 (reverse)
Parity: 06_Parity/finance.md  ·  Status: 📋 SPEC · 🟩 PARTIAL
Evidence: form catalog project-memory/catalogs/forms/TR_CARD_REC.md ; table CARD_DATA.md (39 cols)
```

> **Reuses the receipt engine of [`TR_CASH`](TR_CASH.md).** Documents only the card-specific deltas:
> the acquirer **commission split** and the routing of the net proceeds to the **bank/clearing**
> account (Req 17.4). A card receipt may also **settle a gold-loan (dhrn)**.

## 1. Purpose & business context
Accept a customer payment by **card**. Unlike a plain bank receipt, the bank/acquirer keeps a
**commission** (`CARD_COM_PRC` → `CARD_COM_AMT`), so the customer is credited the **gross**
(`CARD_AMT`) while only the **net** (`BANK_NET_AMT` / `CARD_REC_AMT = CARD_AMT − CARD_COM_AMT`)
reaches the bank, and the commission is booked to an expense. The card receipt can be applied to a
specific bill (`BILL_NO`/`BILL_OS_AMT`) and can release a pledged dhrn (hence `DHRN_*`, `MAIN_STOCK`).

## 2. UI / UX specification
Header like TR_CASH (party, date, book) + card panel: `CARD_AMT`, `CARD_COM_PRC`/`CARD_COM_AMT`,
`CARD_REC_AMT`, `BANK_ACCD`/`BANK_NAME`, `BANK_COM_PRC`/`BANK_COM_AMT`/`BANK_NET_AMT`, `CASH_PAID`,
`BILL_NO`/`BILL_AMT`/`BILL_ADJ_AMT`/`BILL_OS_AMT`. Book `MAIN_BOOK='BANK REC'`, `INOUT_TYPE='I'`,
`ENTRY_TYPE='C'`. Modes: New/Edit/View/Delete(`USER_DELETE`)/Print. _(Confirm field labels/F-keys
from `TR_CARD_REC.cs`.)_

## 3. Data model touched
- **Writes:** `CARD_DATA` (header, 39 cols — see [CARD_DATA.md](../../02_Data_Model/tables/CARD_DATA.md)),
  derived `AC_DATA` + `ROJ_MEL_DATA`, `REMARK_DATA`; when settling a loan: `DHRN_DATA`,
  `DHRN_REC_DETL`, `MAIN_STOCK` (pledged-item movement).
- **Deletes/reverses:** `AC_DATA, CARD_DATA, DHRN_DATA, DHRN_REC_DETL, MAIN_STOCK, REMARK_DATA,
  ROJ_MEL_DATA, TEMP_BOOK_DATA` + `DELETE_DATA`. `src:` catalog `forms/TR_CARD_REC.md`.

## 4. Business logic & calculations (with code)
```ts
// src: web/apps/api/src/modules/finance/finance.ts  postReceipt(mode='card')
const comPct = round2(input.cardCommissionPct ?? 0);
const comAmt = round2(input.amount * comPct / 100);     // CARD_COM_AMT  (2 dp HALF-UP)
const net    = round2(input.amount - comAmt);           // CARD_REC_AMT = BANK_NET_AMT
// CARD_DATA row: CARD_AMT=amount, CARD_COM_PRC=comPct, CARD_COM_AMT=comAmt, CARD_REC_AMT=net,
//                BANK_ACCD=recAc, BANK_NET_AMT=net, INOUT_TYPE='I', ENTRY_TYPE='C', BOOK_NAME='BANK REC'
const recAc = settlementAc('card', input.bankAc);       // → bank/clearing a/c (Req 17.4)
const ledger = buildTransferLedger(key, 'BREC', recAc, input.partyAc, input.amount); // Dr bank · Cr party (GROSS)
```
> **Ledger commission split not yet modelled.** The web posts the **gross** `Dr bank / Cr party`; the
> desktop additionally books the commission (`Dr card-commission-expense / Cr party-or-bank` for
> `CARD_COM_AMT`, leaving `BANK_NET_AMT` to the bank). The dedicated desktop routine was **not**
> among the named `Ac_Ledr` methods (`Cash_Ledr/Bank_Ledr/Contra_Ledr/Loct_Amt_Ledr`) — confirm
> whether card posts via `Bank_Ledr` or an inline routine, and add the commission leg. (Req 17.4 / §6.)

## 5. Save sequence — as TR_CASH §5, with `CARD_DATA` as header and the commission split before posting.
## 6. Delete / reverse — as TR_CASH §6, plus dhrn/stock restoration when a loan was settled. `USER_DELETE`.

## 7. API contract
`POST /txn/receipts` with `mode:'card'`, `cardCommissionPct?`, `bankName?`, `bankAc?` (see
[`TR_CASH.md §7`](TR_CASH.md)). → `201 { vchNo }`. Errors as TR_CASH.

## 8. Validation rules
As TR_CASH (party required, amount > 0, period lock, rights) **plus**: `CARD_COM_AMT ≤ CARD_AMT`;
`BANK_NET_AMT = CARD_AMT − CARD_COM_AMT`; if settling a dhrn, the loan must be open. `req: 17.4`.

## 9. Parity criteria
`CARD_DATA` row (amount/commission/net/bank) + `AC_DATA` legs (gross to party, net to bank,
commission to expense) match desktop; ΣCr=ΣDr; dhrn/stock side-effects match on loan settlement;
day-book written; delete reverses all + `DELETE_DATA`.

## 10. Variants & edge cases
Bank-side commission (`BANK_COM_PRC`/`BANK_COMM_1`/`BANK_COMM_2`/`BANK_COM_AMT`) for MDR tiers;
`CASH_PAID` (part cash + part card); bill-wise application (`BILL_OS_AMT`); dhrn settlement.

## 11. Open questions / risks
- Locate/confirm the **card ledger routine** and the exact commission posting legs (gross vs net,
  which expense account) — current web posts gross only.
- Confirm the **dhrn-settlement** path (when a card receipt closes a pledge): `DHRN_DATA`/
  `DHRN_REC_DETL`/`MAIN_STOCK` writes (cross-ref Module 6).
- `CARD_DATA` has no `SR_NO` in PK (PK = …,`VCH_NO`) — one card row per voucher; confirm multi-card.
