import { readStoneSubDetail, type StoneSubDetailInput } from '../shared/stoneSubDetail.js';
import {
  buildKarigarRojmel,
  rojmelMetalFor,
  type KarigarRojmelLine,
  type RojmelRow,
} from '../shared/rojmel.js';
import { withTxBudget } from '../shared/txBudget.js';
import { resolveLiveTagIdentityTx } from '../stock/stock.js';
import {
  formatVoucherNo,
  nextVoucherNoTx,
  nextTagNoTx,
  type VoucherScope,
} from '../vouchers/numbering.js';
import {
  assertPeriodOpen,
  insertRowTx,
  postVoucherTx,
  reverseVoucherTx,
  type LedgerLine,
} from '../posting/posting.js';
import {
  assertFiscalDateTx,
  deleteVoucherWriteSetTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';
import { fineFor } from '../shared/finePolicy.js';
// Shared with the job-work path so the labour bases have exactly one definition. There is no
// import cycle: mfg.ts does not import karigar.ts.
import { labourAmount } from './mfg.js';

/**
 * Karigar (goldsmith) metal flow. The shop issues raw fine metal OUT to the karigar, who returns
 * finished ornaments IN. Wastage is folded into the accountable fine on receipt — the desktop
 * formula (MS_UPDATE.cs): fine = ITM_NWT × (ITM_TOUCH + ITM_WEST_PRC) / 100.
 * Karigar metal balance = Σ fine issued − Σ fine received (zero ⇒ fully accounted incl. wastage).
 * Labour paid to the karigar is the only amount movement (Dr LABOUR / Cr karigar) posted to AC_DATA.
 *
 * NOTE: INOUT_TYPE is varchar(1); we use 'I' (issue→metal out) / 'R' (receipt→metal in). The exact
 * desktop character convention is a parity item to confirm at Task 30 (golden-master restore).
 */

export class KarigarValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'KarigarValidationError';
  }
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};
const round3 = (n: number): number => Math.round((n + Number.EPSILON) * 1000) / 1000;
const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

export const INOUT_ISSUE = 'O';
export const INOUT_RECEIPT = 'I'; // desktop KR_DETL real data: issue='O' (book 050), receipt='I' (book 052) — verified vs imported Next24 data

/** Backward-compatible net-only fine helper. */
export function fineWeight(nwt: number, touch: number): number {
  return fineFor('karigarReceipt', { netWt: nwt, touch });
}

/** Accountable receipt fine (desktop MS_UPDATE.cs:2691). */
export function fineWithWastage(nwt: number, touch: number, westPct: number): number {
  return fineFor('karigarReceipt', { netWt: nwt, touch, westPct });
}

/** Karigar metal balance = issued − received (positive ⇒ karigar still owes fine). */
export function karigarBalance(issuedFine: number, receivedFine: number): number {
  return round3(issuedFine - receivedFine);
}

export interface KarigarLine {
  itCode?: string;
  itDesc?: string;
  designNo?: string;
  tblCode?: string; // counter
  itmSize?: string;
  tagNo?: string; // supplied tag; or auto-generated when `tag` is set (receive-side tagging, F3)
  /**
   * Pins an exact tag instance when the tag text alone is ambiguous.
   *
   * Desktop grid column 40 (`TR_KR_ISU.cs:3368, :3464, :6899` fill it from the tag lookup, `:4766` restores it
   * on reopen, `:5150` persists it to the detail row). Its availability query adds `AND A.VCH_SRNO = <col 40>`
   * only when that cell is non-zero (`:3318`), so an absent value means "whichever instance is available".
   */
  vchSrno?: number;
  tag?: boolean; // receive: put this finished ornament into barcoded stock (BAR_DETL)
  pcs?: number;
  grossWt?: number;
  othWt?: number; // ITM_OTH_WT (loss/other weight)
  netWt: number;
  ghtWt?: number; // ITM_GHT_WT (ghat/melting weight)
  touch: number;
  westPct?: number; // wastage %
  lesWt?: number; // issue-side less weight; defaults to 0
  lbrType?: string; // LBR_TYPE
  lbrRate?: number; // LBR_RATE
  lbrPct?: number; // LBR_PRC
  lbrAmt?: number; // LBR_AMT (per-line labour charged by the karigar)
  othAmt?: number; // OTH_AMT (stone / other charges)
  // Desktop KR_DETL grid columns (TR_PURC.cs shared detail block, `mSG_PR[i, c]`).
  oldSrNo?: number; // mSG_PR[i,57] :13098
  lotNo?: string; // mSG_PR[i,5]  :13104
  withStock?: string; // mSG_PR[i,7]  :13151
  bagWt?: number; // mSG_PR[i,8]  :13107
  lossWt?: number; // mSG_PR[i,14] :13112
  lessTouch?: number; // mSG_PR[i,23] :13121
  convRate?: number; // mSG_PR[i,27] :13131
  convPct?: number; // mSG_PR[i,28] :13132
  rate?: number; // mSG_PR[i,29] :13136
  amount?: number; // mSG_PR[i,31] :13138
  otherRate?: number; // mSG_PR[i,37] :13129
  otherFine?: number; // mSG_PR[i,38] :13130
  /** Old-item/old-gold Kun fields (TR_PURC.cs:7310-7317, :13114-13116). */
  kundanWt?: number; // KUNDAN_WT
  kundanTouch?: number; // KUNDAN_TOUCH
  kunFine?: number; // KUNDAN_FINE
  silverFine?: number; // SILVER_FINE
  ghtPct?: number; // ITM_GHT_PRC
  urdRateType?: string; // URD_RATE_TYPE
  commissionPct?: number; // COMM_PRC
  commissionAmount?: number; // COMM_AMT
  mrp?: number; // mSG_PR[i,39] :13139
  totalAmount?: number; // mSG_PR[i,40] :13142
  taxRatePct?: number; // mSG_PR[i,43] :13143
  rateType?: string; // mSG_PR[i,46] :13145
  /**
   * Stone/diamond sub-detail rows for this line → KR_IDTL.
   *
   * Desktop writes this through TR_PURC's shared sub-detail block: the form selects the KR_* family
   * when the book's MAIN_BOOK is 'KARIGAR RECEIPT' or 'OLD ITEM SALES' (TR_PURC.cs:11830-11845),
   * and the row builder at TR_PURC.cs:13211-13243 then writes TblIdtl = KR_IDTL with these columns.
   * An empty sub-grid writes no rows, so omitting this writes none.
   */
  stones?: KarigarStoneInput[];
}

/** One KR_IDTL sub-detail row (TR_PURC.cs:13223-13242, `DtIdtlPr.Rows[i][n]` column ordinals). */
export interface KarigarStoneInput extends StoneSubDetailInput {
  /** Extends the shared TblIdtl shape (stone identity + karigar valuation). */
  tagNo?: string;
  vchSrno?: number;
  isrNo?: number; // [0]  ISR_NO
  itCode?: string; // [1]  IT_CODE
  dmCode?: string; // [3]  DM_CODE
  dmName?: string; // [4]  DM_NAME
  dmColor?: string; // [5]  DM_COLOR
  dmSize?: string; // [6]  DM_SIZE
  dmOrigin?: string; // [7]  DM_ORIGIN
  dmRemark?: string; // [8]  DM_REMARK
  dmSfNo?: string; // [9]  DM_SFNO
  pcs?: number; // [12] IT_PCS
  grossWt?: number; // [14] IT_GWT
  conPct?: number; // [15] IT_CON_PRC
  rateType?: string; // [16] IT_RATE_TYPE
  rate?: number; // [17] IT_RATE
  amount?: number; // [18] IT_AMT
  lbrRate?: number; // [19] IT_LBR_RATE
  lbrAmount?: number; // [20] IT_LBR_AMT
  netAmount?: number; // [21] IT_NET_AMT
  conWt?: number; // [22] IT_CON_WT
  itType?: string; // [23] IT_TYPE
}

export interface IssueInput {
  scope: VoucherScope;
  karigarAc: string;
  karigarName?: string;
  vchDate?: Date | string;
  mainUser?: string;
  lines: KarigarLine[];
  /**
   * Desktop KR_DATA header fields. The karigar-receipt book is served by TR_PURC's shared header
   * block (TR_PURC.cs:11830-11845 selects the KR_* family; row builder 12960-13069), so these are
   * the same bill, party, tender, tax and sale-bill-linkage columns a purchase header carries.
   */
  billNo?: string; // tBillNo.Text        :12968
  itemType?: string; // cboItemTyp first char :12972
  vchDesc?: string; // tVchDesc.Text       :13045
  empCode?: string; // tEmpCode.Text       :13044
  address1?: string; // tAdd1.Text          :13017
  address2?: string; // tAdd2.Text          :13018
  address3?: string; // tAdd3.Text          :13019
  city?: string; // tCity.Text          :13020
  mobile?: string; // tMobile.Text        :13021
  bankName?: string; // tBankName.Text      :13016
  bankAc?: string; // MSG2_TOTAL[6,4]     :13014
  chequeNo?: string; // MSG2_TOTAL[6,2]     :13015
  chequeAmount?: number; // MSG2_TOTAL[6,3]     :13008
  cardAc?: string; // MSG2_TOTAL[7,4]     :13013
  cardAmount?: number; // MSG2_TOTAL[7,3]     :13009
  cashAmount?: number; // MSG2_TOTAL[8,3]     :13010
  kasarAmount?: number; // MSG2_TOTAL[9,3]     :13011
  billOutstanding?: number; // MSG2_TOTAL[10,3]    :13012
  creditDays?: number; // nCrDays.Text        :13046
  discountPct?: number; // MSG2_TOTAL[1,2]     :12982
  discountAmount?: number; // MSG2_TOTAL[1,3]     :12983
  otherAmount?: number; // MSG_PR_TOT[0,36]    :13007
  taxCode?: string; // MSG2_TOTAL[2,4]     :12984
  taxRatePct?: number; // MSG2_TOTAL[2,2]     :12985
  taxAmount?: number; // MSG2_TOTAL[2,3]     :12986
  tcsCode?: string; // MSG2_TOTAL[3,4]     :12987
  tcsPct?: number; // MSG2_TOTAL[3,2]     :12988
  tcsAmount?: number; // MSG2_TOTAL[3,3]     :12989
  accountGstType?: string; // AcGstType           :13022
  saleBillNo?: string; // tSlBill.Text        :13047
  saleBillBook?: string; // tSlBill_DbCd.Text   :13050
  /** OLD ITEM SALES only: desktop writes operator-visible `nPartyFine` to KR_DATA.PARTY_FINE. */
  partyFine?: number;
}

export interface ReceiveInput extends IssueInput {
  labourAmt?: number; // paid to karigar (Dr LABOUR / Cr karigar); defaults to Σ per-line lbrAmt
  labourAc?: string; // default 'LABOUR'
  labourGstPct?: number; // GST on karigar labour (e.g. 5) — Dr GST / Cr karigar
  gstAc?: string; // default 'GST'
  interState?: boolean; // IGST vs CGST+SGST split (KR_DATA register)
  tagPrefix?: string; // barcode prefix for auto-tagged finished ornaments (F3)
}

type CompleteKarigarScope = VoucherScope & { coYear: string; coBook: string };

type KarigarBookPolicy = { bookName: string; vchType: string; mainBook: string; inout: string };

const normalizeMainBook = (value: unknown): string =>
  String(value ?? '')
    .trim()
    .toUpperCase();

const OLD_ITEM_SALES_MAIN_BOOK = 'OLD ITEM SALES';
const KARIGAR_MAIN_BOOKS = new Set([
  'KARIGAR',
  'KARIGAR ISSUE',
  'KARIGAR RECEIPT',
  'JOBWORK ISSUE',
  'JOBWORK RECEIPT',
]);

type KarigarBookGuard = 'karigar' | 'old-item-sale';

function completeScope(scope: VoucherScope): CompleteKarigarScope {
  if (!scope.coYear || !scope.coBook)
    throw new KarigarValidationError('company year and book are required');
  return scope as CompleteKarigarScope;
}

async function karigarBookPolicyTx(
  tx: any,
  scope: CompleteKarigarScope,
): Promise<KarigarBookPolicy> {
  const rows: Array<{
    BOOK_NAME: unknown;
    BOOK_SNAME: unknown;
    MAIN_BOOK: unknown;
    BOOK_INOUT: unknown;
  }> = await tx.$queryRawUnsafe(
    `SELECT "BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT" FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2
      AND "LC_CODE"=$3 AND "CO_BOOK"=$4 ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  if (rows.length !== 1)
    throw new KarigarValidationError(`book ${scope.coBook} is not configured unambiguously`);
  const bookName = String(rows[0]?.BOOK_NAME ?? '').trim();
  const vchType = String(rows[0]?.BOOK_SNAME ?? '').trim();
  const mainBook = normalizeMainBook(rows[0]?.MAIN_BOOK);
  const inout = String(rows[0]?.BOOK_INOUT ?? '').trim() || INOUT_RECEIPT;
  if (!bookName || !vchType || !mainBook)
    throw new KarigarValidationError(`book ${scope.coBook} has incomplete desktop identity`);
  return { bookName, vchType, mainBook, inout };
}

function assertKarigarBookGuard(
  scope: CompleteKarigarScope,
  policy: KarigarBookPolicy,
  guard: KarigarBookGuard,
) {
  if (guard === 'old-item-sale') {
    if (policy.mainBook !== OLD_ITEM_SALES_MAIN_BOOK) {
      throw new KarigarValidationError(
        `book ${scope.coBook} is ${policy.mainBook || 'not configured'}; expected OLD ITEM SALES`,
      );
    }
    return;
  }
  if (policy.mainBook === OLD_ITEM_SALES_MAIN_BOOK) {
    throw new KarigarValidationError('use the old item sales workflow for OLD ITEM SALES books');
  }
  if (!KARIGAR_MAIN_BOOKS.has(policy.mainBook)) {
    throw new KarigarValidationError(
      `book ${scope.coBook} is ${policy.mainBook}; expected a karigar book`,
    );
  }
}

async function tempBookRowTx(
  tx: any,
  scope: CompleteKarigarScope,
  hiddenVoucherNo: string,
  bookName: string,
) {
  // TR_KR_ISU.cs:4597 increments TEMP_BOOK_DATA independently by company/location/book (no year).
  await insertRowTx(tx, 'TEMP_BOOK_DATA', scope.tenantId, {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_BOOK: scope.coBook,
    VCH_NO: hiddenVoucherNo,
    BOOK_NAME: bookName,
  });
}

const num = (v: unknown): number => (v == null ? 0 : Number(v));

const issueFine = (line: KarigarLine): number => fineFor('karigarIssue', line);
const receiptFine = (line: KarigarLine): number => fineFor('karigarReceipt', line);
const oldItemSaleFine = (line: KarigarLine): number =>
  fineFor('purchaseOldGold', {
    netWt: line.netWt,
    ghtWt: line.ghtWt,
    touch: line.touch,
    westPct: line.westPct,
    lesTouch: line.lessTouch,
    kunFine: line.kunFine,
  });

/**
 * Per-line karigar labour: the operator's amount when given, otherwise DERIVED from the line's
 * labour type and rate.
 *
 * The desktop derives it (TR_KR_ISU.cs:4025-4129) across the same bases `labourAmount` implements:
 * 'P' per piece, 'N' per (net + ghat), 'K' per kilo of (net + ghat), default per gross. This module
 * previously wrote `num(l.lbrAmt)` straight through, so `LBR_TYPE` and `LBR_RATE` were persisted
 * but never used — a karigar line could carry "per gram at 50" and still be charged nothing.
 *
 * `mfg.ts` already had this derivation for the job-work path (`lineLbrAmt`), which is why job-work
 * and karigar disagreed on identical input. Reusing that helper keeps one definition of the bases
 * rather than a second copy that can drift.
 */
const lineLabour = (line: KarigarLine): number =>
  line.lbrAmt != null
    ? round2(num(line.lbrAmt))
    : labourAmount(line.lbrType, {
        pcs: line.pcs,
        net: line.netWt,
        ghtWt: line.ghtWt,
        gross: line.grossWt,
        lbrRate: line.lbrRate,
      });

type KarigarReceiveWorkflow = {
  guard: KarigarBookGuard;
  fineOf: (line: KarigarLine) => number;
  includeLabourSettlement: boolean;
  includeBarcodes: boolean;
  inoutType: (policy: KarigarBookPolicy) => string;
  partyFineOf?: (input: ReceiveInput, lineFineTotal: number) => number;
};

const KARIGAR_RECEIVE_WORKFLOW: KarigarReceiveWorkflow = {
  guard: 'karigar',
  fineOf: receiptFine,
  includeLabourSettlement: true,
  includeBarcodes: true,
  inoutType: () => INOUT_RECEIPT,
};

const OLD_ITEM_SALE_WORKFLOW: KarigarReceiveWorkflow = {
  guard: 'old-item-sale',
  fineOf: oldItemSaleFine,
  includeLabourSettlement: false,
  includeBarcodes: false,
  // TR_PURC OLD ITEM SALES writes FormBookInOut into KR_DETL; the book controls whether stock is in or out.
  inoutType: (policy) => policy.inout || INOUT_RECEIPT,
  partyFineOf: (input, lineFineTotal) =>
    input.partyFine != null ? round3(num(input.partyFine)) : lineFineTotal,
};

function oldItemSaleValue(input: ReceiveInput, fineTotal: number): number {
  return (
    round2(
      (input.lines ?? []).reduce(
        (sum, line) =>
          sum +
          (line.totalAmount != null
            ? num(line.totalAmount)
            : num(line.amount) + lineLabour(line) + num(line.othAmt)),
        0,
      ),
    ) + Math.abs(fineTotal)
  );
}

function keyOf(s: VoucherScope, vchNo: number, book: string): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? book,
    VCH_NO: formatVoucherNo(vchNo),
  };
}

function detlRows(
  key: VoucherKey,
  vchType: string,
  inout: string,
  karigarAc: string,
  fineOf: (l: KarigarLine) => number,
  lines: KarigarLine[],
  identity: { vchDate: Date; hiddenVoucherNo: string; mainUser?: string; vchClock?: unknown },
  bookName?: string,
  saleBill?: { no?: string; book?: string },
  /**
   * Serial per tagged line index (WP-08e).
   *
   * `TAG_NO` and `VCH_SRNO` here were modelled on TR_PURC's shared detail block, but the karigar form has its
   * OWN save routine and it differs on exactly these two columns: `TR_KR_ISU.cs:5109`/`:5113` writes the `'N'`
   * sentinel when the grid's tag cell is blank rather than a null, and `:5150` persists the tag's serial from
   * grid column 40 rather than a literal 0.
   */
  tagIdentities?: Map<number, number>,
) {
  const txtD = (v: unknown, len: number): string | null =>
    String(v ?? '')
      .trim()
      .slice(0, len) || null;
  return lines.map((l, idx) => {
    const srno = tagIdentities?.get(idx);
    const tagNo = String(l.tagNo ?? '').trim();
    const tagged = Boolean(tagNo) && srno != null && srno > 0;
    return {
      ...key,
      VCH_DATE: identity.vchDate,
      VCH_TIME: voucherTimestamp(identity.vchDate, identity.vchClock),
      HD_VCH_NO: identity.hiddenVoucherNo,
      MAIN_USER: identity.mainUser ?? null,
      VCH_TYPE: vchType,
      INOUT_TYPE: inout,
      ENTRY_TYPE: 'P',
      SR_NO: idx + 1,
      AC_CODE: karigarAc,
      IT_CODE: l.itCode ?? null,
      IT_DESC: l.itDesc ?? null,
      DESIGN_NO: l.designNo ?? null,
      TBL_CODE: l.tblCode ?? null,
      ITM_SIZE: l.itmSize ?? null,
      TAG_NO: tagged ? tagNo : 'N', // mSG[i,1] via :5109/:5113
      ITM_PCS: num(l.pcs),
      ITM_GWT: num(l.grossWt),
      ITM_OTH_WT: num(l.othWt),
      ITM_NWT: num(l.netWt),
      ITM_GHT_WT: num(l.ghtWt),
      ITM_GHT_PRC: num(l.ghtPct),
      ITM_TOUCH: num(l.touch),
      ITM_WEST_PRC: num(l.westPct),
      SILVER_FINE: num(l.silverFine),
      ITM_FINE: fineOf(l),
      LBR_TYPE: l.lbrType ?? null,
      LBR_RATE: num(l.lbrRate),
      LBR_PRC: num(l.lbrPct),
      LBR_AMT: lineLabour(l),
      OTH_AMT: num(l.othAmt),
      NET_AMT: round2(lineLabour(l) + num(l.othAmt)),
      // Desktop KR_DETL columns via TR_PURC's shared detail block (TR_PURC.cs:13096-13188), which
      // targets KR_DETL for karigar-receipt books. Blank desktop grid cells persist as ''/0.
      BOOK_NAME: bookName ?? null, // FormMainBook          :13096
      OLD_SRNO: l.oldSrNo ?? idx + 1, // mSG_PR[i,57]          :13098
      LOT_NO: txtD(l.lotNo, 10), // mSG_PR[i,5]           :13104
      WITH_STOCK: txtD(l.withStock, 1), // mSG_PR[i,7]           :13151
      BAG_WT: num(l.bagWt), // mSG_PR[i,8]           :13107
      ITM_LOSS_WT: num(l.lossWt), // mSG_PR[i,14]          :13112
      ITM_LESS_TCH: num(l.lessTouch), // mSG_PR[i,23]          :13121
      CONV_RATE: num(l.convRate), // mSG_PR[i,27]          :13131
      CONV_PRC: num(l.convPct), // mSG_PR[i,28]          :13132
      ITM_RATE: num(l.rate), // mSG_PR[i,29]          :13136
      URD_RATE_TYPE: txtD(l.urdRateType, 1),
      ITM_AMT: round2(num(l.amount)), // mSG_PR[i,31]          :13138
      COMM_PRC: num(l.commissionPct),
      COMM_AMT: round2(num(l.commissionAmount)),
      ITM_OTH_RATE: num(l.otherRate), // mSG_PR[i,37]          :13129
      ITM_OTH_FINE: num(l.otherFine), // mSG_PR[i,38]          :13130
      ITM_MRP: num(l.mrp), // mSG_PR[i,39]          :13139
      TOT_AMT: round2(num(l.totalAmount)), // mSG_PR[i,40]          :13142
      TAX_PRC: num(l.taxRatePct), // mSG_PR[i,43]          :13143
      RATE_TYPE: txtD(l.rateType, 1), // mSG_PR[i,46]          :13145
      SL_BILL_NO: txtD(saleBill?.no, 10), // tSlBill.Text          :13169
      SL_BILL_LC: key.LC_CODE, // MLc_code              :13170
      SL_BILL_YRCD: key.CO_YEAR, // MCo_year              :13171
      SL_BILL_DBCD: txtD(saleBill?.book, 3), // tSlBill_DbCd.Text     :13172
      TAG_COST: 0, // literal               :13184
      VCH_SRNO: tagged ? srno : 0, // mSG[i,40]             :5150
    };
  });
}

/** MAIN_STOCK metal movement for a karigar voucher (issue ⇒ TR_TYPE 'O'/sign '-', receipt ⇒ 'I'/'+'). */
function stockRows(
  key: VoucherKey,
  vchType: string,
  trType: 'I' | 'O',
  sign: '+' | '-',
  karigarAc: string,
  vchDate: Date,
  fineOf: (line: KarigarLine) => number,
  lines: KarigarLine[],
  bookName = 'KARIGAR',
  /**
   * Serial per tagged line index, from `resolveKarigarTagIdentitiesTx`.
   *
   * WP-08d. This builder wrote neither `TAG_NO` nor `VCH_SRNO`, so a karigar-received ornament got a barcode
   * record with an **untagged** stock movement. That made it invisible twice over: tag-level views select tagged
   * rows, and the desktop's loose-stock views select `TAG_NO = 'N'` (TR_KR_ISU.cs:6961), and a row carrying
   * neither matches neither. The ornament was in stock and appeared in no stock view.
   *
   * The desktop writes the tagged `+` movement from the barcode row for manufacturing tag books —
   * `Ac_Stock.cs:28` selects `A.TAG_NO, A.VCH_SRNO` from `BAR_DETL` where `B.MAIN_BOOK IN ('OPSTK','JDTR TAG',
   * 'MFG TAG')` with `ITM_SIGN '+'` and `ITM_QTY 1` — which is exactly the karigar receipt case, so the tagged
   * movement is parity, not an addition.
   *
   * Untagged lines take the desktop's `'N'`/0 sentinel (Ac_Stock.cs:54), not '' or NULL.
   */
  tagIdentities?: Map<number, number>,
) {
  return lines.map((l, idx) => {
    const srno = tagIdentities?.get(idx);
    const tagNo = String(l.tagNo ?? '').trim();
    // A line is tagged only when it has both a tag number and an allocated serial.
    const tagged = Boolean(tagNo) && srno != null && srno > 0;
    return {
      ...key,
      SR_NO: idx + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: vchType,
      BOOK_NAME: bookName,
      AC_CODE: karigarAc,
      IT_CODE: l.itCode ?? null,
      TAG_NO: tagged ? tagNo : 'N',
      VCH_SRNO: tagged ? srno : 0,
      TR_TYPE: trType,
      ITM_SIGN: sign,
      ITM_QTY: 1,
      ITM_PCS: num(l.pcs),
      ITM_GWT: num(l.grossWt),
      ITM_NWT: num(l.netWt),
      ITM_TOUCH: num(l.touch),
      ITM_WEST: num(l.westPct),
      ITM_FINE: fineOf(l),
    };
  });
}

function header(
  key: VoucherKey,
  karigarAc: string,
  karigarName: string | undefined,
  vchDate: Date,
  fineTotal: number,
  labourAmt = 0,
  extra: Record<string, unknown> = {},
  input?: IssueInput,
) {
  const txtH = (v: unknown, len: number): string | null =>
    String(v ?? '')
      .trim()
      .slice(0, len) || null;
  // Desktop KR_DATA header columns via TR_PURC's shared block (TR_PURC.cs:12960-13069). A blank
  // desktop field/grid cell persists as ''/0, which an absent input reproduces.
  const desktopHeader: Record<string, unknown> = input
    ? {
        BILL_NO: txtH(input.billNo, 10) ?? formatVoucherNo(Number(key.VCH_NO)), // :12968
        IT_TYPE: txtH(input.itemType, 1) ?? 'G', // :12972
        VCH_DESC: txtH(input.vchDesc, 150), // :13045
        EMP_CODE: txtH(input.empCode, 3), // :13044
        ADD1: txtH(input.address1, 50), // :13017
        ADD2: txtH(input.address2, 50), // :13018
        ADD3: txtH(input.address3, 50), // :13019
        CITY: txtH(input.city, 20), // :13020
        MOBILE: txtH(input.mobile, 15), // :13021
        BANK_NAME: txtH(input.bankName, 50), // :13016
        BANK_AC: txtH(input.bankAc, 9), // :13014
        CHQ_NO: txtH(input.chequeNo, 10), // :13015
        CHQ_AMT: num(input.chequeAmount), // :13008
        CARD_AC: txtH(input.cardAc, 9), // :13013
        CARD_AMT: num(input.cardAmount), // :13009
        CASH_AMT: num(input.cashAmount), // :13010
        KASAR_AMT: num(input.kasarAmount), // :13011
        BILL_OS: num(input.billOutstanding), // :13012
        CR_DAYS: num(input.creditDays), // :13046
        DISC_PRC: num(input.discountPct), // :12982
        DISC_AMT: num(input.discountAmount), // :12983
        OTH_AMT: num(input.otherAmount), // :13007
        TAX_CODE: txtH(input.taxCode, 2), // :12984
        TAX_PRC: num(input.taxRatePct), // :12985
        TAX_AMT: num(input.taxAmount), // :12986
        TCS_CODE: txtH(input.tcsCode, 2), // :12987
        TCS_PRC: num(input.tcsPct), // :12988
        TCS_AMT: num(input.tcsAmount), // :12989
        AC_GST_TYPE: txtH(input.accountGstType, 1), // :13022
        SL_BILL_NO: txtH(input.saleBillNo, 10), // :13047
        SL_BILL_LC: key.LC_CODE, // :13048
        SL_BILL_YRCD: key.CO_YEAR, // :13049
        SL_BILL_DBCD: txtH(input.saleBillBook, 3), // :13050
        ROF_AMT: 0, // literal :12992
        DATA_TRFR: 'N', // literal :13057
      }
    : {};
  return {
    ...key,
    VCH_DATE: vchDate,
    AC_CODE: karigarAc,
    AC_NAME: karigarName ?? null,
    PARTY_FINE: fineTotal,
    LBR_AMT: labourAmt,
    NET_AMT: labourAmt,
    TOT_AMT: labourAmt,
    ...desktopHeader,
    ...extra,
  };
}

/** Issue raw fine metal to a karigar (metal OUT). */
export async function issueKarigar(
  prisma: any,
  input: IssueInput,
): Promise<{ vchNo: number; fineIssued: number }> {
  if (!input.karigarAc) throw new KarigarValidationError('karigar account is required');
  if (!input.lines?.length) throw new KarigarValidationError('at least one line is required');

  const scope = completeScope(input.scope);
  const tenantId = scope.tenantId;
  const fineIssued = round3(input.lines.reduce((sum, line) => sum + issueFine(line), 0));
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();

  const vchNo = await withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const policy = await karigarBookPolicyTx(tx, scope);
    assertKarigarBookGuard(scope, policy, 'karigar');
    const hiddenVoucherNo = await nextHiddenVoucherNoTx(tx, scope);
    const no = await nextVoucherNoTx(tx, scope);
    const key = keyOf(scope, no, 'KIS');
    const identity = { vchDate, hiddenVoucherNo, mainUser: input.mainUser };
    await tempBookRowTx(tx, scope, hiddenVoucherNo, policy.bookName);
    // The day book — plan item F3.1. Metal OUT to the karigar: book 050 type `05`, SIGN '-'.
    const rojmelRows = await karigarRojmelRowsTx(tx, scope, {
      key,
      coBook: String(key.CO_BOOK),
      vchNo: String(key.VCH_NO),
      vchDate,
      vchType: policy.vchType,
      bookName: policy.bookName,
      karigarAc: input.karigarAc,
      karigarName: input.karigarName,
      direction: 'issue',
      lines: input.lines,
      fineOf: issueFine,
    });
    // WP-08e. Resolved before the write set because both the detail rows and the stock movements name the tag.
    // An unavailable or ambiguous tag throws here, so the voucher never posts a `-` movement for stock that is
    // not there to send.
    const tagIdentities = await resolveIssuedKarigarTagIdentitiesTx(tx, scope, input.lines);
    await postVoucherTx(tx, tenantId, {
      // metal sub-ledger: karigar fine OUT — desktop AC_DATA leg IT_TYPE 'G'/SIGN '-' (book 050, FINE_WT=fine issued)
      ledger: {
        table: 'AC_DATA',
        lines: [
          {
            ...key,
            VCH_TYPE: policy.vchType,
            AC_CODE: input.karigarAc,
            IT_TYPE: 'G',
            SIGN: '-',
            FINE_WT: fineIssued,
            FINE_RATE: 0,
            DR_AMT: 0,
            CR_AMT: 0,
          },
        ],
      },
      bookName: policy.bookName,
      writes: [
        {
          table: 'KR_DATA',
          rows: [
            header(
              key,
              input.karigarAc,
              input.karigarName,
              vchDate,
              fineIssued,
              0,
              {
                VCH_TIME: voucherTimestamp(vchDate),
                HD_VCH_NO: hiddenVoucherNo,
                MAIN_USER: input.mainUser ?? null,
              },
              input,
            ),
          ],
        },
        {
          table: 'KR_DETL',
          rows: detlRows(
            key,
            policy.vchType,
            INOUT_ISSUE,
            input.karigarAc,
            issueFine,
            input.lines,
            identity,
            policy.bookName,
            { no: input.saleBillNo, book: input.saleBillBook },
            tagIdentities,
          ),
        },
        ...(idtlRows(
          key,
          policy.vchType,
          INOUT_ISSUE,
          input.karigarAc,
          vchDate,
          input.lines,
          input.mainUser,
        ).length
          ? [
              {
                table: 'KR_IDTL',
                rows: idtlRows(
                  key,
                  policy.vchType,
                  INOUT_ISSUE,
                  input.karigarAc,
                  vchDate,
                  input.lines,
                  input.mainUser,
                ),
              },
            ]
          : []),
        {
          table: 'MAIN_STOCK',
          rows: stockRows(
            key,
            policy.vchType,
            'O',
            '-',
            input.karigarAc,
            vchDate,
            issueFine,
            input.lines,
            policy.bookName,
            tagIdentities,
          ),
        },
        ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
      ],
    });
    return no;
  });
  return { vchNo, fineIssued };
}

/** Receive finished ornaments from a karigar (metal IN; wastage folded into fine; labour + GST paid). */
export async function receiveKarigar(
  prisma: any,
  input: ReceiveInput,
  workflow: KarigarReceiveWorkflow = KARIGAR_RECEIVE_WORKFLOW,
): Promise<{
  vchNo: number;
  fineReceived: number;
  labourAmt: number;
  labourGst: number;
  tagNos: string[];
}> {
  if (!input.karigarAc) throw new KarigarValidationError('karigar account is required');
  if (!input.lines?.length) throw new KarigarValidationError('at least one line is required');

  const scope = completeScope(input.scope);
  const tenantId = scope.tenantId;
  const perLineLabour = round2(input.lines.reduce((s, l) => s + lineLabour(l), 0));
  const labourAmt = workflow.includeLabourSettlement
    ? round2(input.labourAmt != null ? num(input.labourAmt) : perLineLabour)
    : 0;
  const labourAc = input.labourAc ?? 'LABOUR';
  const gstAc = input.gstAc ?? 'GST';
  const labourGstPct = workflow.includeLabourSettlement ? num(input.labourGstPct) : 0;
  const labourGst = round2((labourAmt * labourGstPct) / 100);
  const othAmt = round2(input.lines.reduce((s, l) => s + num(l.othAmt), 0));
  const creditToKarigar = round2(labourAmt + labourGst);
  const lineFineTotal = round3(input.lines.reduce((sum, line) => sum + workflow.fineOf(line), 0));
  const fineReceived = workflow.partyFineOf?.(input, lineFineTotal) ?? lineFineTotal;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const inter = !!input.interState;

  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const policy = await karigarBookPolicyTx(tx, scope);
    assertKarigarBookGuard(scope, policy, workflow.guard);
    const inoutType = workflow.inoutType(policy) || INOUT_RECEIPT;
    const stockOut = inoutType === INOUT_ISSUE;
    const stockSign = stockOut ? '-' : '+';
    const hiddenVoucherNo = await nextHiddenVoucherNoTx(tx, scope);
    const no = await nextVoucherNoTx(tx, scope);
    const key = keyOf(scope, no, stockOut ? 'KIS' : 'KRC');
    const identity = { vchDate, hiddenVoucherNo, mainUser: input.mainUser };
    await tempBookRowTx(tx, scope, hiddenVoucherNo, policy.bookName);

    // Resolve barcodes for finished ornaments flagged for tagging (auto via SRNO_MAST.TAG_SRNO, F3).
    //
    // WP-08c: the serial is now kept. This loop used to call the allocator only for an untyped tag and take
    // just the tag number, so no karigar tag carried a `VCH_SRNO` identity.
    const tagIdentities = workflow.includeBarcodes
      ? await resolveKarigarTagIdentitiesTx(tx, scope, input.lines, {
          tagPrefix: input.tagPrefix,
        })
      : new Map<number, number>();
    const tagNos: string[] = workflow.includeBarcodes
      ? input.lines.filter((l) => l.tagNo).map((l) => String(l.tagNo))
      : [];

    const ledger: LedgerLine[] = [];
    if (workflow.includeLabourSettlement && labourAmt > 0) {
      ledger.push({
        ...key,
        VCH_TYPE: policy.vchType,
        AC_CODE: labourAc,
        DR_AMT: labourAmt,
        CR_AMT: 0,
        SIGN: 'D',
      } as LedgerLine);
      if (labourGst > 0)
        ledger.push({
          ...key,
          VCH_TYPE: policy.vchType,
          AC_CODE: gstAc,
          DR_AMT: labourGst,
          CR_AMT: 0,
          SIGN: 'D',
        } as LedgerLine);
      ledger.push({
        ...key,
        VCH_TYPE: policy.vchType,
        AC_CODE: input.karigarAc,
        DR_AMT: 0,
        CR_AMT: creditToKarigar,
        SIGN: 'C',
      } as LedgerLine);
    }
    // metal sub-ledger: karigar fine IN — IT_TYPE 'G'/SIGN '+' (FINE_WT=PARTY_FINE).
    ledger.push({
      ...key,
      VCH_TYPE: policy.vchType,
      AC_CODE: input.karigarAc,
      IT_TYPE: 'G',
      SIGN: stockSign,
      FINE_WT: fineReceived,
      FINE_RATE: 0,
      DR_AMT: 0,
      CR_AMT: 0,
    });

    // Barcode records for tagged finished ornaments (BAR_DETL).
    const barDetl = workflow.includeBarcodes
      ? karigarBarcodeRows(key, policy.vchType, vchDate, input.lines, tagIdentities)
      : [];

    const gstExtra =
      labourGst > 0
        ? inter
          ? { TAX_AMT: labourGst, TAX_PRC: labourGstPct, IGST_TAX: labourGst }
          : {
              TAX_AMT: labourGst,
              TAX_PRC: labourGstPct,
              CGST_TAX: round2(labourGst / 2),
              SGST_TAX: round2(labourGst / 2),
            }
        : {};
    const hdr = header(
      key,
      input.karigarAc,
      input.karigarName,
      vchDate,
      fineReceived,
      labourAmt,
      {
        VCH_TIME: voucherTimestamp(vchDate),
        HD_VCH_NO: hiddenVoucherNo,
        MAIN_USER: input.mainUser ?? null,
        OTH_AMT: othAmt,
        NET_AMT: creditToKarigar,
        TOT_AMT: creditToKarigar,
        ...gstExtra,
      },
      input,
    );

    // The day book — plan item F3.1. Metal IN from the karigar: book 052 type `11`, SIGN '+'.
    const rojmelRows = await karigarRojmelRowsTx(tx, scope, {
      key,
      coBook: String(key.CO_BOOK),
      vchNo: String(key.VCH_NO),
      vchDate,
      vchType: policy.vchType,
      bookName: policy.bookName,
      karigarAc: input.karigarAc,
      karigarName: input.karigarName,
      direction: stockOut ? 'issue' : 'receive',
      lines: input.lines,
      fineOf: workflow.fineOf,
    });
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: policy.bookName,
      writes: [
        { table: 'KR_DATA', rows: [hdr] },
        {
          table: 'KR_DETL',
          rows: detlRows(
            key,
            policy.vchType,
            inoutType,
            input.karigarAc,
            workflow.fineOf,
            input.lines,
            identity,
            policy.bookName,
            { no: input.saleBillNo, book: input.saleBillBook },
            tagIdentities,
          ),
        },
        ...(idtlRows(
          key,
          policy.vchType,
          inoutType,
          input.karigarAc,
          vchDate,
          input.lines,
          input.mainUser,
        ).length
          ? [
              {
                table: 'KR_IDTL',
                rows: idtlRows(
                  key,
                  policy.vchType,
                  inoutType,
                  input.karigarAc,
                  vchDate,
                  input.lines,
                  input.mainUser,
                ),
              },
            ]
          : []),
        {
          table: 'MAIN_STOCK',
          rows: stockRows(
            key,
            policy.vchType,
            stockOut ? 'O' : 'I',
            stockSign,
            input.karigarAc,
            vchDate,
            workflow.fineOf,
            input.lines,
            policy.bookName,
            tagIdentities,
          ),
        },
        ...(barDetl.length ? [{ table: 'BAR_DETL', rows: barDetl }] : []),
        ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
      ],
    });
    return { vchNo: no, fineReceived, labourAmt, labourGst, tagNos };
  });
}

export async function createOldItemSale(
  prisma: any,
  input: ReceiveInput,
): Promise<{
  vchNo: number;
  fineReceived: number;
  labourAmt: number;
  labourGst: number;
  tagNos: string[];
}> {
  const lineFineTotal = round3(
    input.lines?.reduce((sum, line) => sum + oldItemSaleFine(line), 0) ?? 0,
  );
  if (
    oldItemSaleValue(input, input.partyFine != null ? num(input.partyFine) : lineFineTotal) <= 0
  ) {
    throw new KarigarValidationError('old item sales requires party fine or item amount');
  }
  return receiveKarigar(prisma, input, OLD_ITEM_SALE_WORKFLOW);
}

async function balanceTx(tx: any, s: VoucherScope, karigarAc: string): Promise<number> {
  const rows: { inout: string; f: unknown }[] = await tx.$queryRawUnsafe(
    `SELECT "INOUT_TYPE" AS inout, coalesce(sum("ITM_FINE"),0) AS f FROM "KR_DETL"
     WHERE "AC_CODE"=$1 AND "CO_CODE"=$2 GROUP BY "INOUT_TYPE"`,
    karigarAc,
    s.coCode,
  );
  let issued = 0;
  let received = 0;
  for (const r of rows) {
    if (r.inout === INOUT_ISSUE) issued += Number(r.f ?? 0);
    else if (r.inout === INOUT_RECEIPT) received += Number(r.f ?? 0);
  }
  return karigarBalance(issued, received);
}

/** Live karigar metal balance = Σ issued fine − Σ received fine for a karigar. */
export async function karigarMetalBalance(
  prisma: any,
  scope: VoucherScope,
  karigarAc: string,
): Promise<number> {
  return withTxBudget(prisma, scope.tenantId, 'read', (tx: any) => balanceTx(tx, scope, karigarAc));
}

export interface KarigarLifecycleInput extends ReceiveInput {
  vchNo: number | string;
  mode: 'issue' | 'receive';
}

export interface DeleteKarigarInput {
  scope: VoucherScope;
  vchNo: number | string;
  book?: string;
  vchType?: string;
  deleteUser?: string;
}

/**
 * KR_IDTL sub-detail rows (stones/diamonds) for a karigar voucher.
 *
 * Desktop citation: TR_PURC.cs:13211-13243 writes `TblIdtl`, which is KR_IDTL for
 * MAIN_BOOK 'KARIGAR RECEIPT' / 'OLD ITEM SALES' (TR_PURC.cs:11830-11845). Header-derived columns
 * come from the book and scope, never from the request body.
 */
function idtlRows(
  key: Record<string, unknown>,
  vchType: string,
  inout: string,
  karigarAc: string,
  vchDate: Date,
  lines: KarigarLine[],
  mainUser?: string,
): Record<string, unknown>[] {
  const txt = (v: unknown, len: number): string | null =>
    String(v ?? '')
      .trim()
      .slice(0, len) || null;
  return lines.flatMap((line, idx) =>
    (line.stones ?? []).map((stone, sIdx) => ({
      ...key,
      VCH_DATE: vchDate,
      VCH_TYPE: vchType, // FormBookSname :13217
      INOUT_TYPE: inout, // FormBookInOut :13218
      ENTRY_TYPE: 'P', // literal       :13219
      AC_CODE: karigarAc, // tAcCode.Text  :13221
      SR_NO: idx + 1, // parent line   :13222
      ISR_NO: stone.isrNo ?? sIdx + 1, // [0]  :13223
      IT_CODE: txt(stone.itCode, 10), // [1]  :13224
      DM_CODE: txt(stone.dmCode, 10), // [3]  :13225
      DM_NAME: txt(stone.dmName, 50), // [4]  :13226
      DM_COLOR: txt(stone.dmColor, 15), // [5]  :13227
      DM_SIZE: txt(stone.dmSize, 15), // [6]  :13228
      DM_ORIGIN: txt(stone.dmOrigin, 15), // [7]  :13229
      DM_REMARK: txt(stone.dmRemark, 50), // [8]  :13230
      DM_SFNO: txt(stone.dmSfNo, 15), // [9]  :13231
      IT_PCS: num(stone.pcs), // [12] :13232
      IT_GWT: num(stone.grossWt), // [14] :13233
      IT_CON_PRC: num(stone.conPct), // [15] :13234
      IT_RATE_TYPE: txt(stone.rateType, 1), // [16] :13235
      IT_RATE: num(stone.rate), // [17] :13236
      IT_AMT: num(stone.amount), // [18] :13237
      IT_LBR_RATE: num(stone.lbrRate), // [19] :13238
      IT_LBR_AMT: num(stone.lbrAmount), // [20] :13239
      IT_NET_AMT: num(stone.netAmount), // [21] :13240
      IT_CON_WT: num(stone.conWt), // [22] :13241
      IT_TYPE: txt(stone.itType, 1), // [23] :13242
      // The KARIGAR side of the same stone plus its tag/lab identity. This is the whole point of KR_IDTL:
      // a karigar job settles the stone portion on these columns, so leaving them unwritten left the
      // settlement with no basis for stones.
      TAG_NO: txt(stone.tagNo, 15),
      DM_LEB: txt(stone.dmLeb, 15),
      IT_PCS_WT: num(stone.pcsWt),
      KR_WT: num(stone.karigarWt),
      KR_LESS_PRC: num(stone.karigarLessPct),
      KR_CON_PRC: num(stone.karigarConPct),
      KR_CON_WT: num(stone.karigarConWt),
      KR_RATE: num(stone.karigarRate),
      KR_AMT: num(stone.karigarAmount),
      KR_LBR_RATE: num(stone.karigarLabourRate),
      KR_LBR_AMT: num(stone.karigarLabourAmount),
      KR_NET_AMT: num(stone.karigarNetAmount),
      VCH_SRNO: stone.vchSrno ?? idx + 1,
      // The desktop stamps the voucher's own number here; `key` already carries it.
      HD_VCH_NO: (key as Record<string, unknown>).VCH_NO ?? null,
      MAIN_USER: mainUser ?? null, // MainUser :13243
    })),
  );
}

/**
 * Resolve the tag identity for every tagged line of a karigar receipt.
 *
 * WP-08c. Two things were wrong before this existed.
 *
 * The serial was thrown away: the tag loop called `nextTagNoTx` purely to obtain a tag NUMBER and discarded
 * `srno`, and it did not allocate at all when the operator typed the number. The `BAR_DETL` builder then never
 * named `VCH_SRNO`, so every karigar-created tag carried the column default. Plan §7 requires the identity to
 * preserve the serial, and `issueTagTx` resolves an exact instance on `(CO, LC, TAG_NO, VCH_SRNO)` — without it
 * two instances of the same tag text are indistinguishable.
 *
 * Purchase allocates a serial even for a manually typed tag, deliberately ("each purchased tag receives the
 * desktop VCH_SRNO identity even when TAG_NO is manual"). This follows that rule.
 *
 * `persisted` carries the serials this voucher already holds, so an EDIT keeps each tag's identity instead of
 * minting a new one. It is CONSUMED as it is read: two lines naming one tag must not share a serial, which
 * would create a duplicate identity that `BAR_DETL` has no constraint to catch.
 */
/**
 * Resolve the identities of EXISTING tags being ISSUED OUT to a karigar (WP-08e).
 *
 * The mirror of the receive-side resolver above, and deliberately not the same operation. Receive *allocates* a
 * serial for a newly tagged ornament; issue must *look up* the serial of an ornament that already exists, and
 * refuse when it is not available — otherwise a voucher could send out a tag that was already sold.
 *
 * Desktop evidence that this path is real: `TR_KR_ISU.cs:3318` resolves availability for the issue screen from
 * `MAIN_STOCK` grouped by `(TAG_NO, VCH_SRNO)` with `HAVING SUM(CASE WHEN ITM_SIGN='+' THEN VCH_SRNO ELSE
 * -VCH_SRNO END) > 0` and `B.EMP_ISU <> 'Y'`, and the save routine persists both columns on the detail row
 * (`:5109`/`:5113` for `TAG_NO` with the `'N'` sentinel, `:5150` for `VCH_SRNO`).
 *
 * `resolveLiveTagIdentityTx` already implements that exact rule — including the signed `VCH_SRNO` sum rather
 * than a piece count, and the employee-issue exclusion — so this reuses it rather than restating it. It
 * resolves WITHOUT consuming, because the desktop has no live-tag table here (`TR_KR_ISU.cs` names `TAG_STOCK`
 * zero times): an issued tag is recorded solely as the signed `-` movement this voucher posts, which is what
 * makes it unavailable afterwards.
 */
async function resolveIssuedKarigarTagIdentitiesTx(
  tx: any,
  scope: CompleteKarigarScope,
  lines: KarigarLine[],
): Promise<Map<number, number>> {
  const identities = new Map<number, number>();
  const seen = new Map<string, number>();
  for (const [index, line] of lines.entries()) {
    const tagNo = String(line.tagNo ?? '').trim();
    if (!tagNo) continue;
    /**
     * One tag cannot be issued twice on one voucher.
     *
     * The desktop refuses this outright with "Duplicate Tag No" (`TR_KR_ISU.cs:3352`, comparing the typed value
     * against every other row's column 1). Without the check both lines resolve the same identity and the
     * voucher posts two `-` movements for one ornament, taking its signed on-hand to -1 — a §7.1 invariant 3
     * violation manufactured by the voucher itself.
     */
    const duplicateOf = seen.get(`${tagNo.toLowerCase()}|${line.vchSrno ?? ''}`);
    if (duplicateOf != null) {
      throw new KarigarValidationError(
        `Duplicate tag ${tagNo} on lines ${duplicateOf + 1} and ${index + 1}: a tag can only be issued once.`,
      );
    }
    seen.set(`${tagNo.toLowerCase()}|${line.vchSrno ?? ''}`, index);
    const resolved = await resolveLiveTagIdentityTx(tx, {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      TAG_NO: tagNo,
      // Absent means "whichever instance is available", matching the desktop's conditional serial filter.
      ...(line.vchSrno != null ? { VCH_SRNO: line.vchSrno } : {}),
      ...(line.itCode ? { IT_CODE: String(line.itCode) } : {}),
    });
    identities.set(index, resolved.VCH_SRNO);
  }
  return identities;
}

async function resolveKarigarTagIdentitiesTx(
  tx: any,
  scope: CompleteKarigarScope,
  lines: KarigarLine[],
  options: { tagPrefix?: string; persisted?: Map<string, number> } = {},
): Promise<Map<number, number>> {
  const persisted = new Map(options.persisted ?? []);
  const identities = new Map<number, number>();
  for (const [index, line] of lines.entries()) {
    if (!line.tag && !line.tagNo) continue;
    const typed = String(line.tagNo ?? '').trim();
    if (typed) {
      const reused = persisted.get(typed);
      if (reused != null && reused > 0) {
        persisted.delete(typed);
        identities.set(index, reused);
        continue;
      }
    }
    const allocated = await nextTagNoTx(tx, scope, {
      prefix:
        options.tagPrefix ?? (line.itCode ? String(line.itCode).slice(0, 3).toUpperCase() : 'KRG'),
    });
    // A typed tag number is kept; only the serial comes from the allocator.
    if (!typed) line.tagNo = allocated.tagNo;
    identities.set(index, allocated.srno);
  }
  return identities;
}

/**
 * Barcode rows for the tagged finished ornaments of a karigar receipt.
 *
 * Extracted so the EDIT path can rebuild them. `karigarWriteSet` includes `BAR_DETL` and the edit deletes the
 * whole write set, but only the create path had a builder — so an edit destroyed the tag's barcode record and
 * left the physical ornament unsellable, since `issueTagTx` resolves availability from `TAG_STOCK` or
 * `BAR_DETL`. Plan §7.1 invariant 11 requires an edit to restore the complete prior state.
 */
function karigarBarcodeRows(
  key: VoucherKey,
  vchType: string,
  vchDate: Date,
  lines: KarigarLine[],
  identities: Map<number, number>,
): Array<Record<string, unknown>> {
  const rows: Array<Record<string, unknown>> = [];
  lines.forEach((l, index) => {
    if (!l.tagNo) return;
    rows.push({
      ...key,
      SR_NO: rows.length + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: vchType,
      BOOK_NAME: 'KARIGAR',
      INOUT_TYPE: 'I',
      ENTRY_TYPE: 'O',
      TBL_CODE: l.tblCode ?? '001',
      TAG_NO: l.tagNo,
      VCH_SRNO: identities.get(index) ?? 0,
      IT_CODE: l.itCode ?? null,
      DESIGN_NO: l.designNo ?? null,
      ITM_SIZE: l.itmSize ?? null,
      ITM_PCS: num(l.pcs),
      ITM_GWT: num(l.grossWt),
      ITM_OTH_WT: num(l.othWt),
      ITM_NWT: num(l.netWt),
      ITM_TOUCH: num(l.touch),
      ITM_FINE: receiptFine(l),
      LBR_TYPE: l.lbrType ?? null,
      LBR_RATE: num(l.lbrRate),
      LBR_PRC: num(l.lbrPct),
      LBR_AMT: lineLabour(l),
      OTH_AMT: num(l.othAmt),
      /**
       * P8: the KARIGAR COST BASIS, without which every sale of a karigar-made tag posts zeros.
       *
       * `stock.ts:88-93` records the measurement: a SALE LINE COPIES KR_NET_WT / KR_TOUCH / KR_FINE
       * FROM THE TAG — `SL_DETL.KR_TOUCH` equals `BAR_DETL.KR_TOUCH` and `SL_DETL.KR_FINE` equals
       * `BAR_DETL.KR_FINE` on 102 of 102 tagged sale lines in the real customer database, and they are
       * NOT derivable (`KR_NET_WT x KR_TOUCH/100` fits only 7 of 92 rows). The tag is the only source.
       *
       * The sale path was already asking for these columns; this writer — the one that CREATES tags from
       * a karigar receipt — never populated them, so the cost basis behind profit reporting was zero for
       * every such tag.
       *
       * The values are the karigar's own side of the receipt, which is exactly what this voucher settles.
       */
      KR_NET_WT: num(l.netWt),
      KR_TOUCH: num(l.touch),
      KR_WEST_PRC: num(l.westPct),
      KR_FINE: receiptFine(l),
      // Wastage and ghat belong on the tag too: they are part of the fine base everywhere else, and a
      // tag that omits them cannot reproduce its own fine.
      ITM_WEST_PRC: num(l.westPct),
      ITM_GHT_WT: num(l.ghtWt),
      ITM_MRP: num(l.mrp),
      // MAIN_USER / ADD_USER / HD_VCH_NO are DELIBERATELY NOT SET HERE. Adding them broke
      // mfgLifecycle's "keeps a tagged karigar receipt intact across reopen and save unchanged":
      // on an EDIT the original creator must be preserved, and writing input.mainUser overwrote
      // `mfg-user` with the editor's value (or blank). The write path already stamps attribution
      // correctly, so an explicit column here is not an improvement — it is a regression that a
      // passing invariant caught.
    });
  });
  return rows;
}

/**
 * The tag serials this karigar voucher already persisted, keyed by tag number.
 *
 * Read before the write set is deleted so an edit can keep each tag's identity. A tag number appearing twice
 * would make the identity ambiguous, so the first is kept and the resolver allocates a fresh serial for any
 * further line — never two lines sharing one.
 */
async function persistedKarigarTagSrnosTx(
  tx: any,
  scope: CompleteKarigarScope,
  voucherNo: string,
): Promise<Map<string, number>> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "TAG_NO","VCH_SRNO" FROM "BAR_DETL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6
        AND NULLIF(btrim(coalesce("TAG_NO"::text,'')),'') IS NOT NULL
      ORDER BY "TAG_NO",row_id FOR UPDATE`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  const persisted = new Map<string, number>();
  for (const row of rows) {
    const tagNo = String(row.TAG_NO ?? '').trim();
    if (!tagNo || persisted.has(tagNo)) continue;
    persisted.set(tagNo, Number(row.VCH_SRNO ?? 0));
  }
  return persisted;
}

const karigarWriteSet = [
  'BAR_DETL',
  'MAIN_STOCK',
  'AC_DATA',
  'KR_IDTL',
  'KR_DETL',
  'KR_DATA',
  /**
   * The day book — plan item F3.1.
   *
   * Added with the Rojmel projection below. It belongs in the WRITE SET and not only in the writer, because
   * this list is what `deleteVoucherWriteSetTx` reverses: a projection without a matching reversal leaves
   * orphan day-book rows that no delete can reach, and since `LEDR_KEY` is unique the next voucher reusing
   * that number then fails to post. The same coupling was caught on contra.
   */
  'ROJ_MEL_DATA',
] as const;

/**
 * Resolve each detail line's day-book contra account, and build the karigar Rojmel rows.
 *
 * `LD_CODE` is the ITEM GROUP's `PURC_AC` — verified on **25 of 25** real metal rows across both karigar
 * books. Metal moving to or from a karigar is booked against purchase gold, reached through
 * `GROUP_MAST.PURC_AC`, which is the route `purchase.ts` already uses. Deriving it rather than hardcoding
 * 00008 means a shop whose item groups point at a different account still gets its own.
 *
 * A line whose item has no resolvable group account contributes NO day-book row rather than a row naming a
 * blank account: a Rojmel row that names nothing cannot be reconciled, and silently writing one would be
 * worse than the gap this closes.
 */
async function karigarRojmelRowsTx(
  tx: any,
  scope: { tenantId: string; coCode: string; lcCode: string; coYear?: string },
  args: {
    key: Record<string, unknown>;
    coBook: string;
    vchNo: string;
    vchDate: unknown;
    vchType: string;
    bookName: string;
    karigarAc: string;
    karigarName?: string;
    direction: 'issue' | 'receive';
    lines: KarigarLine[];
    fineOf: (line: KarigarLine) => number;
  },
): Promise<RojmelRow[]> {
  const itCodes = [
    ...new Set(args.lines.map((l) => String(l.itCode ?? '').trim()).filter(Boolean)),
  ];
  if (!itCodes.length) return [];
  const rows: Array<{ ic: string; typ: string | null; pac: string | null }> =
    await tx.$queryRawUnsafe(
      `SELECT i."IT_CODE" ic, i."IT_TYPE" typ, g."PURC_AC" pac FROM "ITEM_MAST" i
         LEFT JOIN "GROUP_MAST" g ON g.tenant_id=i.tenant_id
          AND g."CO_CODE"=i."CO_CODE" AND g."GR_CODE"=i."GR_CODE"
        WHERE i.tenant_id=$1 AND i."CO_CODE"=$2 AND i."IT_CODE"::text = ANY($3::text[])`,
      scope.tenantId,
      scope.coCode,
      itCodes,
    );
  const byItem = new Map(rows.map((r) => [String(r.ic).trim(), r]));

  const built: KarigarRojmelLine[] = [];
  args.lines.forEach((l, index) => {
    const item = String(l.itCode ?? '').trim();
    const meta = byItem.get(item);
    const contraAc = String(meta?.pac ?? '').trim();
    if (!item || !contraAc) return;
    built.push({
      lineNo: index + 1,
      itCode: item,
      metal: rojmelMetalFor(meta?.typ),
      contraAc,
      pcs: Number(l.pcs ?? 0),
      grossWt: Number(l.grossWt ?? 0),
      netWt: Number(l.netWt ?? 0),
      touch: Number(l.touch ?? 0),
      fine: args.fineOf(l),
    });
  });
  if (!built.length) return [];

  return buildKarigarRojmel(
    {
      scope: { coCode: scope.coCode, lcCode: scope.lcCode, coYear: scope.coYear! },
      key: args.key,
      coBook: args.coBook,
      vchNo: args.vchNo,
      vchDate: args.vchDate,
      vchType: args.vchType,
      bookName: args.bookName,
      // AC_CODE on every karigar day-book row is the karigar itself — 21 of 21 real rows match KR_DATA.AC_CODE.
      partyName: args.karigarName ?? '',
      partyCode: args.karigarAc,
    },
    args.direction,
    built,
  );
}
const isoDate = (value: unknown): string => new Date(value as any).toISOString().slice(0, 10);

async function assertKarigarReplacementSafeTx(
  tx: any,
  scope: CompleteKarigarScope,
  voucherNo: string,
  karigarAc: string,
  mode: 'issue' | 'receive',
  lines: KarigarLine[],
) {
  if (mode !== 'issue') return;
  const rows: Array<{ balance: unknown }> = await tx.$queryRawUnsafe(
    `SELECT coalesce(sum(CASE WHEN "INOUT_TYPE"=$1 THEN "ITM_FINE" ELSE -"ITM_FINE" END),0) AS balance
       FROM "KR_DETL" WHERE tenant_id=$2 AND "CO_CODE"=$3 AND "LC_CODE"=$4 AND "AC_CODE"=$5
        AND NOT ("CO_YEAR"=$6 AND "CO_BOOK"=$7 AND "VCH_NO"=$8)`,
    INOUT_ISSUE,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    karigarAc,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  const replacement = round3(lines.reduce((sum, line) => sum + issueFine(line), 0));
  if (Number(rows[0]?.balance ?? 0) + replacement < -0.0005)
    throw new KarigarValidationError('voucher metal/stock was consumed by a later voucher');
}

export async function getKarigar(
  prisma: any,
  scopeInput: VoucherScope,
  vchNoInput: number | string,
  guard: KarigarBookGuard = 'karigar',
) {
  const scope = completeScope(scopeInput);
  const vchNo = formatVoucherNo(vchNoInput);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const headers: Record<string, unknown>[] = await tx.$queryRawUnsafe(
      `SELECT *,to_char("VCH_TIME",'HH24:MI:SS.MS') AS "VCH_CLOCK" FROM "KR_DATA"
       WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      vchNo,
    );
    if (headers.length !== 1) throw new KarigarValidationError(`voucher not found: ${vchNo}`);
    const policy = await karigarBookPolicyTx(tx, scope);
    assertKarigarBookGuard(scope, policy, guard);
    const details: Record<string, unknown>[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "KR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
       AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      vchNo,
    );
    /**
     * Stone sub-detail (`KR_IDTL`). Read because `karigarWriteSet` contains it, so an edit deletes
     * and rebuilds these rows from its input: a reader that omitted them meant an unchanged save
     * destroyed every stone on the voucher. Reached by four screens — karigar issue/receive and
     * job-work issue/receive all share `KarigarForm`. Same defect class as `PR_IDTL` on purchase,
     * found by the sub-detail case in `test/operatorDepth.roundtrip.db.test.ts`.
     */
    const stoneRows: Record<string, unknown>[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "KR_IDTL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
       AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO","ISR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      vchNo,
    );
    const stonesBySrNo = new Map<number, Record<string, unknown>[]>();
    for (const row of stoneRows) {
      const srNo = Number(row.SR_NO ?? 0);
      const list = stonesBySrNo.get(srNo) ?? [];
      list.push(readStoneSubDetail(row));
      stonesBySrNo.set(srNo, list);
    }
    const h = headers[0]!;
    // TR_KR_ISU.cs:4624-4625,4689 DISPLAY_DATA preserves VCH_TIME, HD_VCH_NO and MAIN_USER.
    return {
      voucherNo: vchNo,
      hiddenVoucherNo: String(h.HD_VCH_NO ?? ''),
      mainUser: h.MAIN_USER,
      vchClock: h.VCH_CLOCK,
      vchDate: isoDate(h.VCH_DATE),
      karigarAc: h.AC_CODE,
      karigarName: h.AC_NAME,
      labourAmt: Number(h.LBR_AMT ?? 0),
      labourGstPct: Number(h.TAX_PRC ?? 0),
      partyFine: Number(h.PARTY_FINE ?? 0),
      billOutstanding: Number(h.BILL_OS ?? 0),
      mode: String(details[0]?.INOUT_TYPE ?? '') === INOUT_RECEIPT ? 'receive' : 'issue',
      lines: details.map((d) => ({
        itCode: d.IT_CODE,
        itDesc: d.IT_DESC,
        designNo: d.DESIGN_NO,
        tblCode: d.TBL_CODE,
        itmSize: d.ITM_SIZE,
        tagNo: d.TAG_NO,
        pcs: Number(d.ITM_PCS ?? 0),
        grossWt: Number(d.ITM_GWT ?? 0),
        othWt: Number(d.ITM_OTH_WT ?? 0),
        netWt: Number(d.ITM_NWT ?? 0),
        ghtWt: Number(d.ITM_GHT_WT ?? 0),
        touch: Number(d.ITM_TOUCH ?? 0),
        westPct: Number(d.ITM_WEST_PRC ?? 0),
        lbrType: d.LBR_TYPE,
        lbrRate: Number(d.LBR_RATE ?? 0),
        lbrPct: Number(d.LBR_PRC ?? 0),
        lbrAmt: Number(d.LBR_AMT ?? 0),
        othAmt: Number(d.OTH_AMT ?? 0),
        oldSrNo: Number(d.OLD_SRNO ?? 0),
        lotNo: d.LOT_NO,
        withStock: d.WITH_STOCK,
        bagWt: Number(d.BAG_WT ?? 0),
        lossWt: Number(d.ITM_LOSS_WT ?? 0),
        lessTouch: Number(d.ITM_LESS_TCH ?? 0),
        convRate: Number(d.CONV_RATE ?? 0),
        convPct: Number(d.CONV_PRC ?? 0),
        rate: Number(d.ITM_RATE ?? 0),
        amount: Number(d.ITM_AMT ?? 0),
        otherRate: Number(d.ITM_OTH_RATE ?? 0),
        otherFine: Number(d.ITM_OTH_FINE ?? 0),
        silverFine: Number(d.SILVER_FINE ?? 0),
        ghtPct: Number(d.ITM_GHT_PRC ?? 0),
        urdRateType: d.URD_RATE_TYPE,
        commissionPct: Number(d.COMM_PRC ?? 0),
        commissionAmount: Number(d.COMM_AMT ?? 0),
        mrp: Number(d.ITM_MRP ?? 0),
        totalAmount: Number(d.TOT_AMT ?? 0),
        taxRatePct: Number(d.TAX_PRC ?? 0),
        rateType: d.RATE_TYPE,
        stones: stonesBySrNo.get(Number(d.SR_NO ?? 0)) ?? [],
      })),
    };
  });
}

export async function getOldItemSale(
  prisma: any,
  scopeInput: VoucherScope,
  vchNoInput: number | string,
) {
  return getKarigar(prisma, scopeInput, vchNoInput, 'old-item-sale');
}

export async function editKarigar(
  prisma: any,
  input: KarigarLifecycleInput,
  workflow?: KarigarReceiveWorkflow,
) {
  if (!input.karigarAc) throw new KarigarValidationError('karigar account is required');
  if (!input.lines?.length) throw new KarigarValidationError('at least one line is required');
  const scope = completeScope(input.scope);
  const vchNo = formatVoucherNo(input.vchNo);
  const requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const prior = await persistedVoucherHeaderTx(tx, {
      table: 'KR_DATA',
      scope,
      voucherNo: vchNo,
      extraColumns: [],
    });
    const check = async (date: unknown) =>
      assertPeriodOpen(tx, scope.tenantId, {
        ledger: { table: 'AC_DATA', lines: [] },
        writes: [{ table: 'KR_DATA', rows: [{ CO_CODE: scope.coCode, VCH_DATE: date }] }],
      });
    await check(prior.VCH_DATE);
    await check(requestedDate);
    await assertFiscalDateTx(tx, scope, isoDate(requestedDate));
    const policy = await karigarBookPolicyTx(tx, scope);
    const receive = input.mode === 'receive';
    const activeWorkflow =
      workflow ??
      (receive
        ? KARIGAR_RECEIVE_WORKFLOW
        : {
            ...KARIGAR_RECEIVE_WORKFLOW,
            fineOf: issueFine,
            includeLabourSettlement: false,
            includeBarcodes: false,
            inoutType: () => INOUT_ISSUE,
          });
    assertKarigarBookGuard(scope, policy, activeWorkflow.guard);
    const inoutType = activeWorkflow.inoutType(policy) || (receive ? INOUT_RECEIPT : INOUT_ISSUE);
    const stockOut = inoutType === INOUT_ISSUE;
    const stockSign = stockOut ? '-' : '+';
    if (activeWorkflow.guard === 'karigar') {
      await assertKarigarReplacementSafeTx(
        tx,
        scope,
        vchNo,
        input.karigarAc,
        input.mode,
        input.lines,
      );
    }
    const hiddenVoucherNo = String(prior.HD_VCH_NO ?? '').trim();
    if (!hiddenVoucherNo)
      throw new KarigarValidationError('persisted voucher has no hidden identity');
    const mainUser = String(prior.MAIN_USER ?? '').trim() || input.mainUser;
    const key = keyOf(scope, Number(vchNo), stockOut ? 'KIS' : 'KRC');
    const identity = {
      vchDate: requestedDate,
      hiddenVoucherNo,
      mainUser,
      vchClock: prior.VCH_CLOCK,
    };
    const fineOf = activeWorkflow.fineOf;
    const lineFineTotal = round3(input.lines.reduce((sum, line) => sum + fineOf(line), 0));
    const fineTotal = activeWorkflow.partyFineOf?.(input, lineFineTotal) ?? lineFineTotal;
    const labourAmt =
      receive && activeWorkflow.includeLabourSettlement
        ? round2(input.labourAmt ?? input.lines.reduce((s, line) => s + lineLabour(line), 0))
        : 0;
    const gstPct = receive && activeWorkflow.includeLabourSettlement ? num(input.labourGstPct) : 0;
    const gst = round2((labourAmt * gstPct) / 100);
    const ledger: LedgerLine[] = [];
    if (receive && activeWorkflow.includeLabourSettlement && labourAmt > 0) {
      ledger.push(
        {
          ...key,
          VCH_TYPE: policy.vchType,
          AC_CODE: input.labourAc ?? 'LABOUR',
          DR_AMT: labourAmt,
          CR_AMT: 0,
          SIGN: 'D',
        },
        {
          ...key,
          VCH_TYPE: policy.vchType,
          AC_CODE: input.karigarAc,
          DR_AMT: 0,
          CR_AMT: labourAmt + gst,
          SIGN: 'C',
        },
      );
      if (gst > 0)
        ledger.splice(1, 0, {
          ...key,
          VCH_TYPE: policy.vchType,
          AC_CODE: input.gstAc ?? 'GST',
          DR_AMT: gst,
          CR_AMT: 0,
          SIGN: 'D',
        });
    }
    ledger.push({
      ...key,
      VCH_TYPE: policy.vchType,
      AC_CODE: input.karigarAc,
      IT_TYPE: 'G',
      SIGN: stockSign,
      FINE_WT: fineTotal,
      FINE_RATE: 0,
      DR_AMT: 0,
      CR_AMT: 0,
    });
    const hdr = header(
      key,
      input.karigarAc,
      input.karigarName,
      requestedDate,
      fineTotal,
      labourAmt,
      {
        VCH_TIME: voucherTimestamp(requestedDate, prior.VCH_CLOCK),
        HD_VCH_NO: hiddenVoucherNo,
        MAIN_USER: mainUser ?? null,
        TAX_PRC: gstPct,
        TAX_AMT: gst,
        NET_AMT: labourAmt + gst,
        TOT_AMT: labourAmt + gst,
      },
      input,
    );
    /**
     * Tag identities are resolved BEFORE the write set is built, because the stock movements now carry them too.
     *
     * The persisted serials are read before the delete so each tag keeps its identity across the rewrite
     * (WP-08c). Ordering matters: `resolveKarigarTagIdentitiesTx` also fills in `line.tagNo` for lines that were
     * tagged without a number, and `stockRows` reads that.
     */
    const persistedTagSrnos =
      !stockOut && activeWorkflow.includeBarcodes
        ? await persistedKarigarTagSrnosTx(tx, scope, vchNo)
        : new Map<string, number>();
    const tagIdentities =
      !stockOut && activeWorkflow.includeBarcodes
        ? await resolveKarigarTagIdentitiesTx(tx, scope, input.lines, {
            persisted: persistedTagSrnos,
          })
        : stockOut && activeWorkflow.guard === 'karigar'
          ? // An EDIT of a karigar issue resolves the same way a create does. Otherwise the two paths would disagree
            // about what a tagged issue line means: create refuses an unavailable tag and records its identity.
            await resolveIssuedKarigarTagIdentitiesTx(tx, scope, input.lines)
          : new Map<number, number>();
    const writes = [
      { table: 'KR_DATA', rows: [hdr] },
      {
        table: 'KR_DETL',
        rows: detlRows(
          key,
          policy.vchType,
          inoutType,
          input.karigarAc,
          fineOf,
          input.lines,
          identity,
          policy.bookName,
          { no: input.saleBillNo, book: input.saleBillBook },
          tagIdentities,
        ),
      },
      ...(idtlRows(
        key,
        policy.vchType,
        inoutType,
        input.karigarAc,
        identity.vchDate,
        input.lines,
        input.mainUser,
      ).length
        ? [
            {
              table: 'KR_IDTL',
              rows: idtlRows(
                key,
                policy.vchType,
                inoutType,
                input.karigarAc,
                identity.vchDate,
                input.lines,
                input.mainUser,
              ),
            },
          ]
        : []),
      {
        table: 'MAIN_STOCK',
        rows: stockRows(
          key,
          policy.vchType,
          stockOut ? 'O' : 'I',
          stockSign,
          input.karigarAc,
          requestedDate,
          fineOf,
          input.lines,
          policy.bookName,
          tagIdentities,
        ),
      },
    ];
    /**
     * Rebuild the barcode records the delete below removes.
     *
     * WP-08c: `karigarWriteSet` includes `BAR_DETL`, so the delete took the tag's barcode row with it, and only
     * the CREATE path had a builder — the row was never written back. The physical ornament then existed with
     * no tag record at all, and `issueTagTx` (which resolves availability from `TAG_STOCK` or `BAR_DETL`) could
     * no longer sell it. Plan §7.1 invariant 11 requires an edit to restore the complete prior state.
     *
     * The identities were resolved above, before the write set, because the stock movements carry them too.
     */
    if (!stockOut && activeWorkflow.includeBarcodes) {
      const barcodeRows = karigarBarcodeRows(
        key,
        policy.vchType,
        requestedDate,
        input.lines,
        tagIdentities,
      );
      if (barcodeRows.length) writes.push({ table: 'BAR_DETL', rows: barcodeRows });
    }
    // TR_KR_ISU.cs:5033-5039 deletes the complete derived write set before reposting. Its sole
    // INSERT INTO DELETE_DATA is in delete at TR_KR_ISU.cs:5373, so edit intentionally writes none.
    await deleteVoucherWriteSetTx(tx, {
      tables: karigarWriteSet,
      key: { scope, voucherNo: vchNo },
      tempBook: { voucherNo: hiddenVoucherNo },
    });
    await tempBookRowTx(tx, scope, hiddenVoucherNo, policy.bookName);
    await postVoucherTx(tx, scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: policy.bookName,
      writes,
    });
    return { vchNo: Number(vchNo), updated: true as const };
  });
}

export async function editOldItemSale(
  prisma: any,
  input: Omit<KarigarLifecycleInput, 'mode'> & { mode?: 'receive' },
) {
  const lineFineTotal = round3(
    input.lines?.reduce((sum, line) => sum + oldItemSaleFine(line), 0) ?? 0,
  );
  if (
    oldItemSaleValue(input, input.partyFine != null ? num(input.partyFine) : lineFineTotal) <= 0
  ) {
    throw new KarigarValidationError('old item sales requires party fine or item amount');
  }
  return editKarigar(
    prisma,
    { ...input, mode: 'receive' } as KarigarLifecycleInput,
    OLD_ITEM_SALE_WORKFLOW,
  );
}

export async function deleteKarigar(
  prisma: any,
  input: DeleteKarigarInput,
  guard: KarigarBookGuard = 'karigar',
): Promise<{ reversed: true }> {
  const scope = completeScope({ ...input.scope, coBook: input.scope.coBook ?? input.book });
  const vchNo = formatVoucherNo(input.vchNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const h = await persistedVoucherHeaderTx(tx, {
      table: 'KR_DATA',
      scope,
      voucherNo: vchNo,
      extraColumns: ['AC_CODE', 'AC_NAME'],
    });
    await assertPeriodOpen(tx, scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: [] },
      writes: [{ table: 'KR_DATA', rows: [{ CO_CODE: scope.coCode, VCH_DATE: h.VCH_DATE }] }],
    });
    const policy = await karigarBookPolicyTx(tx, scope);
    assertKarigarBookGuard(scope, policy, guard);
    const details: Record<string, unknown>[] = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","AC_CODE","IT_CODE","TAG_NO","NET_AMT","IT_TYPE","ITM_NWT","ITM_FINE","INOUT_TYPE"
       FROM "KR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      vchNo,
    );
    const mode = String(details[0]?.INOUT_TYPE ?? '') === INOUT_RECEIPT ? 'receive' : 'issue';
    if (guard === 'karigar') {
      await assertKarigarReplacementSafeTx(tx, scope, vchNo, String(h.AC_CODE ?? ''), mode, []);
    }
    const now = new Date();
    const base = {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      CO_YEAR: scope.coYear,
      CO_BOOK: scope.coBook,
      VCH_NO: vchNo,
      VCH_DATE: h.VCH_DATE,
      DELETE_DATE: now,
      VCH_TIME: voucherTimestamp(new Date(h.VCH_DATE as any), h.VCH_CLOCK),
      DELETE_TIME: now,
      VCH_TYPE: policy.vchType,
      BOOK_NAME: policy.bookName,
      AC_CODE: h.AC_CODE,
      AC_NAME: h.AC_NAME,
      HD_VCH_NO: h.HD_VCH_NO,
      MAIN_USER: h.MAIN_USER,
      DELETE_USER: input.deleteUser ?? 'system',
    };
    if (mode === 'issue') {
      // Exact TR_KR_ISU.cs:5373 mapping: one row per detail, amount DR=NET_AMT, fine CR=ITM_NWT.
      for (const d of details)
        await insertRowTx(tx, 'DELETE_DATA', scope.tenantId, {
          ...base,
          SR_NO: d.SR_NO,
          AC_CODE: d.AC_CODE,
          VCH_VAL_DR: d.NET_AMT,
          VCH_VAL_CR: 0,
          FINE_TYPE: d.IT_TYPE,
          VCH_FINE_DR: 0,
          VCH_FINE_CR: d.ITM_NWT,
          VCH_DESC: `ItCode / ${String(d.IT_CODE ?? '')}   TagNo / ${String(d.TAG_NO ?? '')}`,
        });
    } else {
      // TR_MFG_KR_ISU_REC.cs:9935 maps receipt deletion to one zero-valued header row.
      await insertRowTx(tx, 'DELETE_DATA', scope.tenantId, {
        ...base,
        SR_NO: 0,
        VCH_VAL_DR: 0,
        VCH_VAL_CR: 0,
        FINE_TYPE: 'A',
        VCH_FINE_DR: 0,
        VCH_FINE_CR: 0,
        VCH_DESC: '0',
      });
    }
    await deleteVoucherWriteSetTx(tx, {
      tables: karigarWriteSet,
      key: { scope, voucherNo: vchNo },
      tempBook: { voucherNo: String(h.HD_VCH_NO ?? '') },
    });
    return { reversed: true };
  });
}

export async function deleteOldItemSale(
  prisma: any,
  input: DeleteKarigarInput,
): Promise<{ reversed: true }> {
  return deleteKarigar(prisma, input, 'old-item-sale');
}
