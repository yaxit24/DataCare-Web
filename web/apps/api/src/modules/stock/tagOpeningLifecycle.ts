import { round, tagKarigarBlock } from '@datacare/core';
import { assertCounterCodes, resolveCounterStockPolicyTx } from '../shared/counterStockPolicy.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { assertVoucherVersionTx, versionKeyOf, voucherVersionTx } from '../vouchers/version.js';
import type { VoucherScope } from '../vouchers/numbering.js';

export interface TagOpeningLine {
  tagNo?: string;
  vchSrno?: number;
  itCode: string;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  ghtWt?: number;
  westPct?: number;
  fineWt?: number;
  rate?: number;
  mrp?: number;
  tblCode?: string;
  designNo?: string;
  itmSize?: string;
  lessWt?: number;
  lbrPct?: number;
  lbrType?: string;
  lbrRate?: number;
  lbrAmt?: number;
  othAmt?: number;
  tagCost?: number;
  // Desktop tag-grid columns (TR_TAG_OPBL.cs `mSG[i, c]`); each maps to one BAR_DETL column.
  // Item attributes — mSG 8/9/49/24/38/100/101.
  itmStyle?: string;
  itmColor?: string;
  itmMargin?: number;
  lbrCode?: string;
  slType?: string;
  empIsu?: string;
  designImageId?: string;
  // Retail pricing — mSG 47/48.
  mainMarginPct?: number;
  mainMrp?: number;
  // Hallmark identifiers and weights — mSG 82-88.
  hallmarkId2?: string;
  hallmarkId3?: string;
  hallmarkId4?: string;
  hallmarkIdWt?: number;
  hallmarkId2Wt?: number;
  hallmarkId3Wt?: number;
  hallmarkId4Wt?: number;
  // Karigar weight block — mSG 17-23 (KrOthWt, KrNwt, KrGht%, KrGht, KrTouch, KrWst%, KrFine; N204).
  karigarOthWt?: number;
  karigarNetWt?: number;
  karigarGhtPct?: number;
  karigarGhtWt?: number;
  karigarTouch?: number;
  karigarWestPct?: number;
  karigarFine?: number;
  // Karigar costing — mSG 35/36/37/39/40/41/42/45/53/60.
  karigarLbrRate?: number;
  karigarLbrAmt?: number;
  karigarOthAmt?: number;
  karigarOthRate?: number;
  karigarOthFine?: number;
  karigarTotFine?: number;
  karigarGwtTouch?: number;
  karigarCost?: number;
  karigarName?: string;
  karigarWaxWt?: number;
  // Jadtar (stone-set) weights — mSG 54-59.
  jdtJdtWt?: number;
  jdtGhtWt?: number;
  jdtKunWt?: number;
  jdtKunTouch?: number;
  jdtKunNet?: number;
  jdtWaxWt?: number;
  // Sales-order linkage — mSG 4/90/91/92/94/95/97.
  ordNo?: string;
  ordSrno?: number;
  ordYrcd?: string;
  ordDbcd?: string;
  ordAc?: string;
  ordLcCode?: string;
  sfNo?: string;
  // Manufacturing linkage — mSG 2/103/104/106.
  mfgNo?: string;
  mfgYrcd?: string;
  mfgDbcd?: string;
  mfgSrno?: number;
  sourceType?: string;
  /** Set by the lot-header fill only: the "0.00" KrFine of TR_TAG_OPBL.cs:10996 (0 = left unwritten). */
  lotFine?: number;
}

export interface TagOpeningInput {
  scope: VoucherScope;
  mainUser?: string;
  vchDate?: Date | string;
  stockItCode?: string;
  /**
   * The lot header (desktop `tLotNo` / `nLotTouch` / `nLotWestPrc`, TR_TAG_OPBL.cs:3056-3712 area). A
   * tag row left without its own KrTouch takes the lot's touch and wastage at save
   * (TR_TAG_OPBL.cs:10990-10996), so these feed money columns (KR_TOUCH, KR_WEST_PRC, KR_FINE).
   */
  lotNo?: string;
  lotTouch?: number | string;
  lotWestPrc?: number | string;
  lines: TagOpeningLine[];
}

/**
 * The tables an edit or delete replaces, and therefore the write set the GET's `version` token covers
 * (N51, D17). The hidden numbering row (TEMP_BOOK_DATA) is keyed by the hidden voucher number, not the
 * business one, so it is counted by the voucher tables only.
 */
export const TAG_OPENING_VERSION_TABLES = [
  'BAR_DATA',
  'BAR_DETL',
  'BAR_IDTL',
  'MAIN_STOCK',
] as const;

export function tagOpeningVersionTx(tx: any, scope: VoucherScope, voucherNo: string) {
  return voucherVersionTx(tx, TAG_OPENING_VERSION_TABLES, versionKeyOf(scope, voucherNo));
}

export function assertTagOpeningVersionTx(
  tx: any,
  scope: VoucherScope,
  voucherNo: string,
  expectedVersion: string,
) {
  return assertVoucherVersionTx(
    tx,
    TAG_OPENING_VERSION_TABLES,
    versionKeyOf(scope, voucherNo),
    expectedVersion,
  );
}

/** TR_TAG_OPBL.cs:10793-10806: with counter-wise stock on, every tag row needs its counter code. */
export async function assertTagOpeningCounterCodes(
  tx: any,
  scope: VoucherScope,
  lines: TagOpeningLine[],
) {
  assertCounterCodes(
    await resolveCounterStockPolicyTx(tx, scope),
    lines,
    DESKTOP_MESSAGES.TAG_OPENING_COUNTER_MANDATORY,
  );
}

/**
 * The lot header's karigar fill (TR_TAG_OPBL.cs:10990-10996). With a lot number and a non-zero lot
 * touch, a row whose KrTouch cell is blank takes the lot touch and wastage ("0.00"), and its KrFine
 * is (KrNwt + KrGht) × (lot touch + lot wastage) / 100 — which is the block's own formula once the
 * touch and wastage are filled, so the fill happens before `tagKarigarLineColumns` runs it.
 */
export function withLotKarigarFill(input: TagOpeningInput): TagOpeningLine[] {
  const lotTouch = n(input.lotTouch);
  const lotNo = text(input.lotNo);
  if (lotTouch === 0 || !lotNo) return input.lines;
  const lotWest = n(input.lotWestPrc);
  return input.lines.map((line) => {
    if (n(line.karigarTouch) !== 0 || (text(line.sourceType) || 'A') !== 'A') return line;
    // :10994-10995 format the raw lot values "0.00" (half away from zero); the columns writer rounds them.
    // :10996 writes KrFine only for a non-zero KrNwt cell, from the raw values, formatted "0.00".
    const { karigarNetWt } = tagKarigarBlock({ ...line, karigarTouch: 0, karigarWestPct: 0 });
    return {
      ...line,
      karigarTouch: lotTouch,
      karigarWestPct: lotWest,
      lotFine:
        karigarNetWt !== 0
          ? round(((karigarNetWt + n(line.karigarGhtWt)) * (lotTouch + lotWest)) / 100, 2)
          : 0,
    };
  });
}

/**
 * TR_TAG_OPBL.cs:11421-11422: per tag, the identity and photograph rows go first. The web keeps
 * ONE SRNO_MAST counter row per company/location (schema uq_srno_mast_tenant_company_location;
 * numbering.ts:177-213), never the desktop's per-tag rows, so the desktop's per-tag SRNO_MAST
 * delete has no row to act on here and is deliberately not a blanket counter delete.
 */
export async function deleteTagOpeningOwnedRows(
  tx: any,
  scope: VoucherScope,
  voucherNo: string,
  rows: Array<Record<string, unknown>>,
) {
  for (const row of rows) {
    await tx.$executeRawUnsafe(
      `DELETE FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
         AND "TAG_NO"=$4 AND "VCH_SRNO"=$5`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      text(row.TAG_NO),
      n(row.VCH_SRNO),
    );
  }
  // TR_TAG_OPBL.cs:11427: the voucher's lot links go with the rest of the set.
  await tx.$executeRawUnsafe(
    `DELETE FROM "LOT_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
       AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
}

const n = (value: unknown): number => (value == null || value === '' ? 0 : Number(value));
const text = (value: unknown): string => String(value ?? '').trim();
