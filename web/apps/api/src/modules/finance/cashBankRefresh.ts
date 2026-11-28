import { round, toIsoDate } from '@datacare/core';
import { resolveBookSlotAccountTx } from '../shared/postingAccounts.js';
import { configuredBookTx, num, text } from './lifecycle.js';
import { cashBookFamily } from './cashBank.js';
import {
  cashBankPostInput,
  cashLegRoles,
  type CashGridRow,
  type CashLayout,
  type CashVoucherFacts,
  type Who,
} from './cashBankLegs.js';
import {
  AccountRefreshDeriveError,
  type RefreshCandidate,
  type RefreshVoucherScope,
} from './contraRefresh.js';

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

/** The voucher's stored AC_DATA legs: what it actually posted, to tell the book's settings at save time. */
async function storedLegsTx(
  tx: any,
  scope: RefreshVoucherScope,
  voucherNo: string,
): Promise<Array<{ key: string; ac: string; ld: string; vchType: string; bookName: string }>> {
  return tx.$queryRawUnsafe(
    `SELECT "LEDR_KEY"::text "key", btrim(coalesce("AC_CODE"::text,'')) ac, btrim(coalesce("LD_CODE"::text,'')) ld,
            btrim(coalesce("VCH_TYPE"::text,'')) "vchType", btrim(coalesce("BOOK_NAME"::text,'')) "bookName"
       FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5
        AND "VCH_NO"=$6 ORDER BY "LEDR_KEY"`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
}

type Role = Exclude<Who, 'party'>;

/**
 * The account each role (settlement, kasar, charges) posted to, read from the stored legs by their LEDR_KEY tails,
 * for the first layout whose legs are exactly the ones stored. A role whose legs disagree is left out (damaged).
 */
function postedAccounts(
  legs: Array<{ key: string; ac: string; ld: string }>,
  layouts: CashLayout[],
  direction: 'receipt' | 'payment',
  rows: CashGridRow[],
): { layout: CashLayout; accounts: Partial<Record<Role, string>> } | null {
  for (const layout of layouts) {
    const roles = cashLegRoles(layout, direction, rows);
    const matched = roles.map((role) => legs.find((leg) => leg.key.endsWith(role.suffix)));
    if (roles.length !== legs.length || matched.some((leg) => !leg)) continue;
    const seen: Record<Role, Set<string>> = {
      settle: new Set(),
      kasar: new Set(),
      charges: new Set(),
    };
    roles.forEach((role, i) => {
      if (role.ac !== 'party') seen[role.ac].add(matched[i]!.ac);
      if (role.ld !== 'party') seen[role.ld].add(matched[i]!.ld);
    });
    const accounts: Partial<Record<Role, string>> = {};
    for (const r of ['settle', 'kasar', 'charges'] as const)
      if (seen[r].size === 1) accounts[r] = [...seen[r]][0]!;
    return { layout, accounts };
  }
  return null;
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
): Promise<RefreshCandidate | RefreshCandidate[]> {
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
  // The writer keeps REC_AC_CODE only when it is NOT slot 1, so a kept account that is slot 1 now proves the book's
  // slot 1 was changed after the save; which layout the voucher had can no longer be told.
  if (named && named === slotOne)
    fail(
      'book configuration changed since save (the settlement account it kept is now slot 1 of the book)',
    );
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
  // What the voucher actually posted, from its own legs (see postedAccounts).
  const legs = await storedLegsTx(tx, scope, voucherNo);
  const posted = postedAccounts(legs, layouts, direction, rows);
  const parties = new Set(rows.map((r) => r.partyAc));
  let kasarAccounts = [''];
  if (totalKasar > 0) {
    const slotTwo = await slotTx(tx, scope, 2);
    const usable = slotTwo && slotTwo !== settle ? [slotTwo] : [];
    // A kasar account the API named instead of slot 2 is offered too, unless it is the party, settlement or charges
    // account: then the kasar legs cannot be told apart from the others and the voucher is not re-derived.
    const named2 = posted?.accounts.kasar;
    if (named2 && named2 !== slotTwo) {
      if (named2 === settle || named2 === chargesAc || parties.has(named2))
        fail(
          `kasar account cannot be told apart (${named2} is also the voucher's party, settlement or charges account)`,
        );
      usable.push(named2);
    }
    kasarAccounts = usable;
    if (!kasarAccounts.length) fail(`book ${scope.coBook} slot 2 names no usable kasar account`);
  }

  const key = {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear,
    CO_BOOK: scope.coBook,
    VCH_NO: voucherNo,
  };
  const facts = (
    layout: CashLayout,
    kasar: string,
    over: Partial<CashVoucherFacts> = {},
  ): CashVoucherFacts => ({
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
    ...over,
  });
  const candidates: RefreshCandidate[] = [];
  for (const layout of layouts)
    for (const kasar of kasarAccounts)
      candidates.push(cashBankPostInput(facts(layout, kasar), rows));

  // The book's settings at save time, read from the voucher's own legs: settlement and charges accounts, short name
  // and MAIN_BOOK. When they are not today's, the voucher is explained by them and reported, never re-posted into
  // today's settings (a changed slot would otherwise move every old voucher's legs).
  if (posted && legs.length) {
    const was = {
      settle: posted.accounts.settle ?? settle,
      charges: posted.accounts.charges ?? chargesAc,
      shortName: legs[0]!.vchType,
      mainBook: legs[0]!.bookName,
    };
    const changed = [
      was.settle !== settle && `settlement ${was.settle} -> ${settle}`,
      was.charges !== chargesAc && `charges ${was.charges} -> ${chargesAc}`,
      was.shortName !== book.shortName && `short name ${was.shortName} -> ${book.shortName}`,
      was.mainBook.toUpperCase() !== book.mainBook.toUpperCase() &&
        `main book ${was.mainBook} -> ${book.mainBook}`,
    ].filter(Boolean);
    if (changed.length) {
      const wasLayout = cashBookFamily(was.mainBook)?.layout;
      candidates.push({
        ...cashBankPostInput(
          facts(
            wasLayout === 'cash' || wasLayout === 'bank' ? wasLayout : posted.layout,
            posted.accounts.kasar ?? kasarAccounts[0]!,
            {
              shortName: was.shortName,
              mainBook: was.mainBook,
              accounts: {
                settle: was.settle,
                kasar: posted.accounts.kasar ?? kasarAccounts[0]!,
                charges: was.charges,
              },
            },
          ),
          rows,
        ),
        unverifiedReason: `book configuration changed since save (${changed.join(', ')})`,
      });
    }
  }
  return candidates.length === 1 ? candidates[0]! : candidates;
}
