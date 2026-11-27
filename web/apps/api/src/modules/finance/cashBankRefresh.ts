import { round, toIsoDate } from '@datacare/core';
import type { PostInput } from '../posting/posting.js';
import { resolveBookSlotAccountTx } from '../shared/postingAccounts.js';
import { configuredBookTx, num, text } from './lifecycle.js';
import { cashBookFamily } from './cashBank.js';
import { cashBankPostInput, type CashGridRow, type CashLayout } from './cashBankLegs.js';
import { AccountRefreshDeriveError, type RefreshVoucherScope } from './contraRefresh.js';

/**
 * Re-derivation of the postings of one saved Cash/Bank receipt or payment (TR_CASH), for Data Refresh > Account
 * (check-and-repair, docs/handbook/web/data-refresh.md).
 *
 * The desktop's AcRefresh rebuilds the cash and bank books from CASH_DATA alone (MS_UPDATE.cs:2470-2476):
 * Cash_Ledr / Cash_Rojmel (Ac_Ledr.cs:565-583, Ac_Rojmel.cs:179-193) for CASH REC / CASH PAY, Bank_Ledr /
 * Bank_Rojmel (Ac_Ledr.cs:585-610, Ac_Rojmel.cs:195-219) for BANK REC / BANK PAY, each joining BOOK_DETL slots 1-3
 * for the cash/bank, kasar and charges accounts. The web keeps that source: the stored CASH_DATA rows go unchanged
 * through cashBankPostInput, the builder writeCashVoucherTx posts with. Nothing here writes or allocates.
 *
 * What CASH_DATA does not record, the derive refuses to guess:
 *   - a generic web RECEIPT / PAYMENT book takes every mode, and a row naming a settlement account other than slot 1
 *     may be a bank movement or a cash one settled to a chosen account. The reader (cashBank.ts readCash) opens it as
 *     bank; the derive offers bank then cash, and the check accepts the voucher only if its postings equal one of them;
 *   - the API may name a kasar account other than slot 2. When the stored legs name such an account it is offered as a
 *     second candidate the same way.
 * A voucher whose postings match no candidate of an ambiguous voucher is `unverified`, never repaired.
 */

type StoredRow = Record<string, unknown>;

/** The stored CASH_DATA rows of one voucher, dates and time as text so the wall clock survives the round trip. */
async function storedCashRowsTx(
  tx: any,
  scope: RefreshVoucherScope,
  voucherNo: string,
): Promise<StoredRow[]> {
  const rows: StoredRow[] = await tx.$queryRawUnsafe(
    `SELECT "SR_NO","AC_CODE","AC_NAME","REC_AMT","KASAR_AMT","BANK_CHARGES","IT_DESC","CHQ_NO","REC_AC_CODE",
            "ENTRY_TYPE","HD_VCH_NO","MAIN_USER","VCH_DATE"::text AS "VCH_DATE","CLR_DATE"::text AS "CLR_DATE",
            "VCH_TIME"::text AS "VCH_TIME"
       FROM "CASH_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" NULLS FIRST, row_id`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  if (!rows.length)
    throw new AccountRefreshDeriveError(`voucher ${voucherNo} has no CASH_DATA rows`);
  return rows;
}

/** Detail rows the card / UPI receipt writes beside CASH_DATA: their presence proves a bank movement. */
async function hasCardOrUpiTx(
  tx: any,
  scope: RefreshVoucherScope,
  voucherNo: string,
): Promise<boolean> {
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "CARD_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6
     UNION ALL
     SELECT 1 FROM "UPI_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6 LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  return rows.length > 0;
}

/** Accounts on the voucher's stored AC_DATA legs, to offer a kasar account the API named instead of slot 2. */
async function storedLegAccountsTx(
  tx: any,
  scope: RefreshVoucherScope,
  voucherNo: string,
): Promise<string[]> {
  const rows: Array<{ ac: string }> = await tx.$queryRawUnsafe(
    `SELECT DISTINCT btrim("AC_CODE"::text) ac FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  return rows.map((row) => row.ac).filter(Boolean);
}

const slotTx = (tx: any, scope: RefreshVoucherScope, srNo: number): Promise<string> =>
  resolveBookSlotAccountTx(tx, scope, srNo === 1 ? 'cash-settlement' : 'kasar', srNo).catch(
    () => '',
  );

/**
 * The postings a TR_CASH save writes for the voucher's stored CASH_DATA rows (cashBankLegs.ts cashBankPostInput).
 * One PostInput when the rows decide everything; more than one, in preference order, when CASH_DATA leaves the
 * layout or the kasar account open (see the module comment).
 */
export async function deriveCashBankPostingsTx(
  tx: any,
  scope: RefreshVoucherScope,
  voucherNo: string,
): Promise<PostInput | PostInput[]> {
  const fail = (why: string): never => {
    throw new AccountRefreshDeriveError(`voucher ${voucherNo}: ${why}`);
  };
  const book = await configuredBookTx(tx, scope);
  const family = cashBookFamily(book.mainBook);
  if (!family) fail(`book ${scope.coBook} is not a receipt or payment book`);
  const { direction, layout: bookLayout } = family!;
  const stored = await storedCashRowsTx(tx, scope, voucherNo);
  const head = stored[0]!;
  // writeCashVoucherTx stamps every row with the voucher's identity, ENTRY_TYPE 'C' (TR_CASH.cs:3032) and a hidden
  // number (:2995-3004). Rows without them were written by another screen (Bill to Bill, Batch Receipt) whose
  // postings follow other rules, so they are not re-derived here.
  if (stored.some((row) => text(row.ENTRY_TYPE).toUpperCase() !== 'C' || !text(row.HD_VCH_NO)))
    fail(
      'its CASH_DATA rows were not written by the receipt/payment form (no ENTRY_TYPE C or hidden number)',
    );
  const identity = (row: StoredRow) =>
    ['VCH_DATE', 'VCH_TIME', 'HD_VCH_NO', 'MAIN_USER', 'REC_AC_CODE']
      .map((c) => text(row[c]))
      .join('|');
  if (stored.some((row) => identity(row) !== identity(head)))
    fail(
      'its CASH_DATA rows disagree on the voucher identity (date, time, hidden number, user or account)',
    );
  if (!text(head.VCH_DATE)) fail('it has no VCH_DATE');
  const srNos = stored.map((row) => num(row.SR_NO));
  if (srNos.some((sr) => !Number.isInteger(sr) || sr < 1) || new Set(srNos).size !== srNos.length)
    fail('its CASH_DATA rows do not carry distinct grid serials');

  const vchDate = new Date(toIsoDate(head.VCH_DATE));
  const rows: CashGridRow[] = stored.map((row) => ({
    srNo: num(row.SR_NO),
    partyAc: text(row.AC_CODE),
    partyName: text(row.AC_NAME),
    recAmt: round(num(row.REC_AMT), 2),
    kasar: round(num(row.KASAR_AMT), 2),
    charges: round(num(row.BANK_CHARGES), 2),
    itDesc: text(row.IT_DESC),
    chqNo: text(row.CHQ_NO),
    vchDate,
    clrDate: text(row.CLR_DATE) ? new Date(toIsoDate(row.CLR_DATE)) : vchDate,
  }));
  const totalKasar = round(
    rows.reduce((s, r) => s + r.kasar, 0),
    2,
  );
  const totalCharges = round(
    rows.reduce((s, r) => s + r.charges, 0),
    2,
  );
  if (rows.some((r) => r.charges < 0)) fail('a row carries negative bank charges');

  // The settlement account: REC_AC_CODE when the writer kept it (not slot 1), else the book's slot 1.
  const slotOne = await slotTx(tx, scope, 1);
  const named = text(head.REC_AC_CODE);
  const settle = named || slotOne;
  if (!settle) fail(`book ${scope.coBook} slot 1 names no settlement account`);

  // The layout: the book's own, else (a generic book) cash when the voucher settles to slot 1, bank when card / UPI
  // rows or charges prove it, otherwise bank first (as readCash opens it) and cash second.
  const certainBank =
    totalCharges !== 0 || (await hasCardOrUpiTx(tx, scope, voucherNo)) ? true : false;
  const layouts: CashLayout[] =
    bookLayout !== 'any'
      ? [bookLayout]
      : !named || named === slotOne
        ? ['cash']
        : certainBank
          ? ['bank']
          : ['bank', 'cash'];
  if (layouts.length === 1 && layouts[0] === 'cash' && totalCharges !== 0)
    fail('a cash book row carries bank charges, which the form refuses');
  if (layouts[0] === 'bank' && layouts.length === 1 && stored.some((row) => !text(row.CLR_DATE)))
    fail('a bank row has no clearing date');

  // The kasar account: slot 2 (Ac_Ledr.cs:571-581 joins B.SR_NO = 2), refused when it is the settlement account as
  // the writer refuses it; then any other account the stored legs name that is not the party, settlement or charges.
  const chargesAc = totalCharges !== 0 ? await slotTx(tx, scope, 3) : '';
  if (totalCharges !== 0 && !chargesAc)
    fail(`book ${scope.coBook} slot 3 names no charges account`);
  let kasarAccounts = [''];
  if (totalKasar > 0) {
    const slotTwo = await slotTx(tx, scope, 2);
    const known = new Set([settle, chargesAc, slotTwo, ...rows.map((r) => r.partyAc)]);
    kasarAccounts = [
      ...(slotTwo && slotTwo !== settle ? [slotTwo] : []),
      ...(await storedLegAccountsTx(tx, scope, voucherNo)).filter((ac) => !known.has(ac)),
    ];
    if (!kasarAccounts.length) fail(`book ${scope.coBook} slot 2 names no usable kasar account`);
  }

  const key = {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear,
    CO_BOOK: scope.coBook,
    VCH_NO: voucherNo,
  };
  const candidates: PostInput[] = [];
  for (const layout of layouts)
    for (const kasar of kasarAccounts)
      candidates.push(
        cashBankPostInput(
          {
            key,
            coBook: scope.coBook,
            vchNo: voucherNo,
            layout,
            direction,
            shortName: book.shortName,
            mainBook: book.mainBook,
            dataType: book.dataType,
            hiddenVoucherNo: text(head.HD_VCH_NO),
            mainUser: text(head.MAIN_USER),
            // The stored text: the database casts it back to the same wall clock in any server time zone.
            voucherTime: text(head.VCH_TIME) || vchDate,
            scope: { coCode: scope.coCode, lcCode: scope.lcCode, coYear: scope.coYear },
            accounts: { settle, kasar, charges: chargesAc },
          },
          rows,
        ),
      );
  return candidates.length === 1 ? candidates[0]! : candidates;
}
