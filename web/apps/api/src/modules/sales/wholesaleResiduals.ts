import { round } from '@datacare/core';
import { buildRateCutRojmel, rojmelMetalFor } from '../shared/rojmel.js';
import { buildWholesaleRojmel, type WholesaleRojmelLine } from '../shared/rojmelWholesale.js';
import { versionOf, writeSetStateTx, type VersionedVoucherKey } from '../vouchers/version.js';
import { readStoredDetails } from './wholesaleDetailRows.js';

/**
 * The write-side and read-side pieces of the Wh Sales residuals (WP-30) that `rateCut.ts` calls: which day-book
 * builder a voucher uses, the version token, and the extra figures a reopen returns. Kept here so rateCut.ts, which
 * has a size ceiling that only falls, does not grow.
 */
type Row = Record<string, unknown>;
const n = (v: unknown): number => Number(v ?? 0) || 0;

export interface RojmelRowsArgs {
  scope: { coCode: string; lcCode: string; coYear: string };
  key: Row;
  coBook: string;
  vchNo: string;
  vchDate: Date;
  vchType: string;
  bookName: string;
  dataType?: string;
  customer: string;
  headerName: string;
  masterName: string;
  vchDesc: string;
  itType: 'G' | 'S';
  /** Desktop `Wh_Sales_Rojmel` shape (the Wh Sales book, gold and silver). Rate Cut keeps the measured nine-type shape. */
  desktopShape: boolean;
  accounts: Record<string, string | undefined>;
  /** BOOK_DETL by SR_NO as stored, blank codes included (see `readBookSlots`). */
  slots: Record<number, string | undefined>;
  cardAc: string;
  figures: Row;
  headerTotals: { prBillOs: number; slBillOs: number };
  bankAc: string;
  labourAmount: number;
  ksrFineDr: number;
  ksrFineCr: number;
  issuedRows: Row[];
  receivedRows: Row[];
}

const asLine = (row: Row): WholesaleRojmelLine => ({
  silverFine: n(row.SILVER_FINE),
  srNo: n(row.SR_NO),
  itType: String(row.IT_TYPE ?? 'G'),
  pcs: n(row.ITM_PCS),
  grossWt: n(row.ITM_GWT),
  netWt: n(row.ITM_NWT),
  touch: n(row.ITM_TOUCH),
  westPct: n(row.ITM_WEST_PRC),
  fine: n(row.ITM_FINE),
  itemAmount: n(row.ITM_AMT),
  remark: String(row.ITM_REMARK ?? ''),
  itCode: String(row.IT_CODE ?? ''),
});

/** The ROJ_MEL_DATA rows of one voucher: the desktop's own for a Wh Sales, else the earlier nine-type builder. */
export function rateCutRojmelRows(a: RojmelRowsArgs): any[] {
  const money2 = (v: unknown): number => round(n(v), 2);
  const f = a.figures as any;
  const ctx = {
    scope: a.scope,
    key: a.key,
    coBook: a.coBook,
    vchNo: a.vchNo,
    vchDate: a.vchDate,
    vchType: a.vchType,
    bookName: a.bookName,
    partyName: a.headerName,
    partyCode: a.customer,
  };
  const gold = a.itType === 'G';
  if (a.desktopShape) {
    return buildWholesaleRojmel(ctx, {
      itType: a.itType,
      interestFine: n(f.intFine),
      interestAccount: a.accounts.interestAc,
      silverFineCr: n(f.slvFineCr),
      silverFineDr: n(f.slvFineDr),
      silverAmountCr: n(f.slvAmtCr),
      silverAmountDr: n(f.slvAmtDr),
      silverFineRate: n(f.slvFineRate),
      slots: a.slots,
      cardAc: a.cardAc,
      saleChequeAmount: n(f.slChqAmt),
      saleCardAmount: n(f.slCardAmt),
      saleKasarAmount: n(f.slKasarAmt),
      purchaseCardAmount: n(f.prCardAmt),
      purchaseLabourAmount: money2(n(f.prLbrAmt) + n(f.prOthAmt)),
      headerName: a.headerName,
      masterName: a.masterName,
      vchDesc: a.vchDesc,
      dataType: a.dataType,
      bankAc: a.bankAc,
      fineRate: n(f.fineRate),
      drFine: n(f.drFine),
      crFine: n(f.crFine),
      purchaseBillOs: a.headerTotals.prBillOs,
      saleBillOs: a.headerTotals.slBillOs,
      purchaseAmount: money2(n(f.crAmt) + n(f.prItmAmt)),
      saleAmount: money2(n(f.drAmt) + n(f.slItmAmt)),
      ksrFineDr: a.ksrFineDr,
      ksrFineCr: a.ksrFineCr,
      purchaseChequeAmount: n(f.prChqAmt),
      purchaseKasarAmount: n(f.prKasarAmt),
      labourAmount: a.labourAmount,
      issued: a.issuedRows.map(asLine),
      received: a.receivedRows.map(asLine),
    });
  }
  const sale = gold ? a.accounts.goldAc : a.accounts.silverSaleAc;
  const purchase = gold ? a.accounts.purchaseAc : a.accounts.silverPurcAc;
  return buildRateCutRojmel(ctx, {
    saleAc: String(sale ?? ''),
    purchaseAc: String(purchase ?? ''),
    kasarFineAc: String(a.accounts.fineKasarAc ?? a.accounts.kasarAc ?? ''),
    purchaseKasarAc: String(a.accounts.purchaseKasarAc ?? a.accounts.kasarAc ?? ''),
    bankAc: a.bankAc,
    metal: rojmelMetalFor(a.itType),
    fineRate: n(f.fineRate),
    drFine: n(f.drFine),
    crFine: n(f.crFine),
    purchaseBillOs: a.headerTotals.prBillOs,
    saleBillOs: a.headerTotals.slBillOs,
    purchaseAmount: money2(n(f.crAmt) + n(f.prItmAmt)),
    saleAmount: money2(n(f.drAmt) + n(f.slItmAmt)),
    kasarFineDr: a.ksrFineDr,
    kasarFineCr: a.ksrFineCr,
    purchaseChequeAmount: n(f.prChqAmt),
    purchaseKasarAmount: n(f.prKasarAmt),
  });
}

/** The voucher's version token key. */
export const wholesaleVersionKey = (
  tenantId: string,
  key: { CO_CODE: string; LC_CODE: string; CO_YEAR: string; CO_BOOK: string; VCH_NO: string },
): VersionedVoucherKey => ({
  tenantId,
  coCode: key.CO_CODE,
  lcCode: key.LC_CODE,
  coYear: key.CO_YEAR,
  coBook: key.CO_BOOK,
  voucherNo: key.VCH_NO,
});

/** The extra figures a Wh Sales reopen returns: fine kasar, the stored item-detail rows and the version token. */
export async function readWholesaleExtras(
  tx: any,
  tenantId: string,
  key: { CO_CODE: string; LC_CODE: string; CO_YEAR: string; CO_BOOK: string; VCH_NO: string },
  tables: readonly string[],
): Promise<{
  ksr: { ksrFineDr: number; ksrFineCr: number };
  version: string;
  details: Map<number, Row[]>;
}> {
  const [kasar]: Array<{ dr: number; cr: number }> = await tx.$queryRawUnsafe(
    `SELECT coalesce("KSR_FINE_DR",0)::float8 AS dr, coalesce("KSR_FINE_CR",0)::float8 AS cr FROM "RATE_CUT_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 LIMIT 1`,
    tenantId,
    key.CO_CODE,
    key.LC_CODE,
    key.CO_YEAR,
    key.CO_BOOK,
    key.VCH_NO,
  );
  const version = versionOf(await writeSetStateTx(tx, tables, wholesaleVersionKey(tenantId, key)));
  return {
    ksr: { ksrFineDr: n(kasar?.dr), ksrFineCr: n(kasar?.cr) },
    version,
    details: await readStoredDetails(tx, { tenantId, ...key }),
  };
}
