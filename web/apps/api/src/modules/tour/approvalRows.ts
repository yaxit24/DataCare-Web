import { toIsoDate } from '@datacare/core';
import {
  configuredBookTx,
  num,
  text,
  voucherKey,
  type VoucherIdentity,
} from '../finance/lifecycle.js';
import { readStoneSubDetail } from '../shared/stoneSubDetail.js';
import { resolveLiveTagIdentityTx } from '../stock/stock.js';
import { formatVoucherNo } from '../vouchers/numbering.js';
import {
  APPROVAL_MESSAGES,
  approvalRound3,
  approvalText as t,
  isApprovalTag,
  tourLineFine,
  tourLineNetAmount,
  TourValidationError,
  type ApprovalKind,
  type ApprovalRow as Row,
  type CompleteApprovalScope,
  type TourIssueLine,
  type TourReturnInput,
  type TourStoneInput,
} from './approvalTypes.js';

export type ApprovalBook = Awaited<ReturnType<typeof configuredBookTx>>;

export async function resolveIssueTagsTx(
  tx: any,
  scope: CompleteApprovalScope,
  lines: TourIssueLine[],
): Promise<TourIssueLine[]> {
  const codes = [...new Set(lines.map((line) => text(line.itCode)).filter(Boolean))];
  const itemRows: Array<{ IT_CODE: unknown; IT_TYPE: unknown }> = codes.length
    ? await tx.$queryRawUnsafe(
        `SELECT "IT_CODE","IT_TYPE" FROM "ITEM_MAST"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=ANY($3::text[])`,
        scope.tenantId,
        scope.coCode,
        codes,
      )
    : [];
  const items = new Map(itemRows.map((row) => [text(row.IT_CODE), text(row.IT_TYPE)] as const));
  const out: TourIssueLine[] = [];
  for (const line of lines) {
    const itemType = items.get(text(line.itCode));
    if (itemType === undefined)
      throw new TourValidationError(`approval item not found: ${text(line.itCode)}`);
    // DISPLAY_DATA/Save carries consumed rows forward. They no longer have to be live stock and must
    // retain the original tag identity rather than being resolved as a new issue selection.
    const received = text(line.isuRec).toUpperCase();
    if (received && received !== 'N') {
      out.push({ ...line, itType: itemType });
      continue;
    }
    if (!isApprovalTag(line.tagNo)) {
      out.push({ ...line, tagNo: 'N', vchSrno: 0, itType: itemType });
      continue;
    }
    const identity = await resolveLiveTagIdentityTx(tx, {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      TAG_NO: text(line.tagNo),
      ...(line.vchSrno == null ? {} : { VCH_SRNO: num(line.vchSrno) }),
      IT_CODE: line.itCode,
    });
    if (identity.source !== 'BAR_DETL')
      throw new TourValidationError(`approval tag has no BAR_DETL source: ${line.tagNo}`);
    out.push({
      ...line,
      vchSrno: identity.VCH_SRNO,
      itCode: text(identity.IT_CODE) || line.itCode,
      itType: itemType,
    });
  }
  return out;
}

export async function sourceLinesTx(
  tx: any,
  scope: CompleteApprovalScope,
  input: TourReturnInput,
  lock = false,
): Promise<TourIssueLine[]> {
  const origBook = text(input.origBook);
  const origYear = text(input.origYear) || scope.coYear;
  if (!origBook) throw new TourValidationError('the original approval issue book is required');
  if (!input.origVchNo)
    throw new TourValidationError('the original approval issue voucher is required');
  const books: Array<{ MAIN_BOOK: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "MAIN_BOOK" FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
      AND "CO_BOOK"=$4 AND coalesce(nullif(btrim("CUR_USE"::text),''),'Y')<>'N'`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    origBook,
  );
  if (books.length !== 1 || text(books[0]!.MAIN_BOOK).toUpperCase() !== 'APR ISU')
    throw new TourValidationError("approval return requires an original MAIN_BOOK='APR ISU'");
  if (!Array.isArray(input.lines) || input.lines.length === 0)
    throw new TourValidationError('at least one return line is required');
  const wanted = input.lines.map((line, index) => {
    if (!line || typeof line !== 'object')
      throw new TourValidationError(`approval return line ${index + 1} is invalid`);
    const origSrNo = num(line.origSrNo ?? line.oldSrNo);
    if (!origSrNo)
      throw new TourValidationError(`approval return line ${index + 1} needs the original Sr No`);
    return { ...line, origSrNo };
  });
  const requestedSources = new Set<number>();
  for (const line of wanted) {
    if (requestedSources.has(line.origSrNo))
      throw new TourValidationError(APPROVAL_MESSAGES.DUPLICATE_TAG);
    requestedSources.add(line.origSrNo);
  }
  const rows: Row[] = [];
  for (const line of wanted) {
    const source: Row[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
        AND "OLD_SRNO"::numeric=$7::numeric AND coalesce("ISU_REC",'N')='N'
        ORDER BY row_id${lock ? ' FOR UPDATE' : ''}`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      origYear,
      origBook,
      formatVoucherNo(input.origVchNo),
      num(line.origSrNo),
    );
    if (source.length !== 1)
      throw new TourValidationError(
        `approval issue line is unavailable: ${formatVoucherNo(input.origVchNo)}/${num(line.origSrNo)}`,
      );
    const row = source[0]!;
    if (text(row.AC_CODE) !== text(input.partyAc ?? input.salesmanAc))
      throw new TourValidationError('approval return party must match the original issue');
    const stones: Row[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "APR_IDTL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND "SR_NO"::numeric=$7::numeric
        ORDER BY "ISR_NO",row_id`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      origYear,
      origBook,
      formatVoucherNo(input.origVchNo),
      num(row.OLD_SRNO),
    );
    rows.push({ ...row, stones });
  }
  return rows.map(lineFromRow);
}

export function stoneFromRow(row: Row): TourStoneInput {
  return readStoneSubDetail(row) as TourStoneInput;
}

export function lineFromRow(row: Row): TourIssueLine {
  return {
    oldSrNo: num(row.OLD_SRNO),
    vchSrno: num(row.VCH_SRNO),
    itCode: text(row.IT_CODE),
    tagNo: text(row.TAG_NO) || 'N',
    pcs: num(row.ITM_PCS),
    grossWt: num(row.ITM_GWT),
    netWt: num(row.ITM_NWT),
    touch: num(row.ITM_TOUCH),
    fineWt: num(row.ITM_FINE),
    lotNo: text(row.LOT_NO),
    itmColor: text(row.ITM_COLOR),
    tagCost: num(row.TAG_COST),
    hallmarkId2: text(row.HM_ID2),
    hallmarkId3: text(row.HM_ID3),
    hallmarkId4: text(row.HM_ID4),
    hallmarkIdWt: num(row.HM_ID_WT),
    hallmarkId2Wt: num(row.HM_ID2_WT),
    hallmarkId3Wt: num(row.HM_ID3_WT),
    hallmarkId4Wt: num(row.HM_ID4_WT),
    adjustGrossWt: row.ADJ_GWT == null ? undefined : num(row.ADJ_GWT),
    adjustNetWt: row.ADJ_NWT == null ? undefined : num(row.ADJ_NWT),
    lessTouch: row.ITM_LESS_TCH == null ? undefined : num(row.ITM_LESS_TCH),
    lossWt: row.ITM_LOSS_WT == null ? undefined : num(row.ITM_LOSS_WT),
    remark: text(row.ITM_REMARK),
    isuAcName: text(row.ISU_AC_NAME),
    metalColor: text(row.MTL_COLOR),
    isuAcCode: text(row.ISU_AC_CODE),
    tblCode: text(row.TBL_CODE),
    designNo: text(row.DESIGN_NO),
    itmSize: text(row.ITM_SIZE),
    huid: text(row.HM_ID),
    bagWt: num(row.BAG_WT),
    lessWt: num(row.ITM_OTH_WT),
    ghtWt: num(row.ITM_GHT_WT),
    westPct: num(row.ITM_WEST_PRC),
    labourPct: num(row.LBR_PRC),
    labourType: text(row.LBR_TYPE),
    labourRate: num(row.LBR_RATE),
    labourAmount: num(row.LBR_AMT),
    otherAmount: num(row.OTH_AMT),
    rate: num(row.ITM_RATE),
    amount: num(row.ITM_AMT),
    mrp: num(row.ITM_MRP),
    discountPct: num(row.DISC_PRC),
    discountAmount: num(row.DISC_AMT),
    netAmount: num(row.NET_AMT),
    itType: text(row.IT_TYPE),
    karigarNetWt: num(row.KR_NET_WT),
    karigarTouch: num(row.KR_TOUCH),
    karigarWestPct: num(row.KR_WEST_PRC),
    karigarFine: num(row.KR_FINE),
    karigarName: text(row.KR_NAME),
    rateType: text(row.RATE_TYPE),
    prCode: text(row.PR_CODE),
    isuYrcd: text(row.ISU_YRCD),
    isuDbcd: text(row.ISU_DBCD),
    isuLcCode: text(row.ISU_LC_CODE),
    isuSrNo: num(row.ISU_SRNO),
    designImageId: text(row.DESIGN_IMG_ID),
    stones: (row.stones ?? []).map(stoneFromRow),
  };
}

export function detailRow(
  key: Row,
  identity: VoucherIdentity,
  book: ApprovalBook,
  partyAc: string,
  empCode: string,
  line: TourIssueLine,
  index: number,
  source?: { year: string; book: string; no: string },
): Row {
  return {
    ...key,
    VCH_DATE: identity.voucherDate,
    VCH_TIME: identity.voucherTime,
    HD_VCH_NO: identity.hiddenVoucherNo,
    AC_CODE: partyAc,
    EMP_CODE: empCode || null,
    VCH_TYPE: book.shortName,
    INOUT_TYPE: book.inout,
    ENTRY_TYPE: 'A',
    BOOK_NAME: book.mainBook,
    SR_NO: index + 1,
    OLD_SRNO: num(line.oldSrNo) || index + 1,
    VCH_SRNO: num(line.vchSrno),
    IT_CODE: line.itCode,
    TAG_NO: isApprovalTag(line.tagNo) ? text(line.tagNo) : 'N',
    ISU_REC: t(line.isuRec, 1) || 'N',
    EMP_SALE: t(line.empSale, 1) || 'N',
    CON_ISU_REC: t(line.conIsuRec),
    ITM_PCS: approvalRound3(line.pcs),
    ITM_GWT: approvalRound3(line.grossWt),
    ITM_NWT: approvalRound3(line.netWt),
    ITM_TOUCH: approvalRound3(line.touch),
    ITM_FINE: tourLineFine(line),
    ITM_REMARK: t(line.remark),
    ORNA_REC_DATE: toIsoDate(identity.voucherDate),
    LOT_NO: t(line.lotNo, 15),
    ITM_COLOR: t(line.itmColor, 15),
    TAG_COST: num(line.tagCost),
    HM_ID: t(line.huid, 10),
    HM_ID2: t(line.hallmarkId2, 10),
    HM_ID3: t(line.hallmarkId3, 10),
    HM_ID4: t(line.hallmarkId4, 10),
    HM_ID_WT: approvalRound3(line.hallmarkIdWt),
    HM_ID2_WT: approvalRound3(line.hallmarkId2Wt),
    HM_ID3_WT: approvalRound3(line.hallmarkId3Wt),
    HM_ID4_WT: approvalRound3(line.hallmarkId4Wt),
    ADJ_GWT: line.adjustGrossWt == null ? null : num(line.adjustGrossWt),
    ADJ_NWT: line.adjustNetWt == null ? null : num(line.adjustNetWt),
    ITM_LESS_TCH: line.lessTouch == null ? null : num(line.lessTouch),
    ITM_LOSS_WT: line.lossWt == null ? null : num(line.lossWt),
    ISU_AC_NAME: t(line.isuAcName, 50),
    MTL_COLOR: t(line.metalColor, 15),
    ISU_AC_CODE: t(line.isuAcCode, 8),
    TBL_CODE: t(line.tblCode, 3),
    DESIGN_NO: t(line.designNo, 20),
    ITM_SIZE: t(line.itmSize, 20),
    BAG_WT: approvalRound3(line.bagWt),
    ITM_OTH_WT: approvalRound3(line.lessWt),
    ITM_GHT_WT: approvalRound3(line.ghtWt),
    ITM_WEST_PRC: num(line.westPct),
    LBR_PRC: num(line.labourPct),
    LBR_TYPE: t(line.labourType, 1),
    LBR_RATE: num(line.labourRate),
    LBR_AMT: num(line.labourAmount),
    OTH_AMT: num(line.otherAmount),
    ITM_RATE: num(line.rate),
    ITM_AMT: num(line.amount),
    ITM_MRP: num(line.mrp),
    DISC_PRC: num(line.discountPct),
    DISC_AMT: num(line.discountAmount),
    NET_AMT: tourLineNetAmount(line),
    IT_TYPE: t(line.itType, 1),
    KR_NET_WT: approvalRound3(line.karigarNetWt),
    KR_TOUCH: num(line.karigarTouch),
    KR_WEST_PRC: num(line.karigarWestPct),
    KR_FINE: approvalRound3(line.karigarFine),
    KR_NAME: t(line.karigarName, 5),
    RATE_TYPE: t(line.rateType, 1),
    PR_CODE: t(line.prCode, 2),
    ISU_YRCD: source?.year ?? t(line.isuYrcd, 10),
    ISU_DBCD: source?.book ?? t(line.isuDbcd, 3),
    ISU_NO: source?.no ?? t(line.isuNo, 10),
    ISU_SRNO: source ? num(line.oldSrNo) : num(line.isuSrNo) || null,
    ISU_LC_CODE: key.LC_CODE,
    DESIGN_IMG_ID: t(line.designImageId, 50),
    MAIN_USER: identity.mainUser || null,
  };
}

export function stoneRows(
  key: Row,
  identity: VoucherIdentity,
  book: ApprovalBook,
  partyAc: string,
  lines: TourIssueLine[],
): Row[] {
  return lines.flatMap((line, index) =>
    (line.stones ?? []).map((stone, stoneIndex) => ({
      ...key,
      VCH_DATE: identity.voucherDate,
      HD_VCH_NO: identity.hiddenVoucherNo,
      VCH_TYPE: book.shortName,
      INOUT_TYPE: book.inout,
      ENTRY_TYPE: 'A',
      BOOK_NAME: book.mainBook,
      AC_CODE: partyAc,
      SR_NO: index + 1,
      TAG_NO: isApprovalTag(line.tagNo) ? text(line.tagNo) : 'N',
      VCH_SRNO: num(line.vchSrno),
      ISR_NO: stone.isrNo ?? stoneIndex + 1,
      IT_CODE: t(stone.itCode, 5),
      DM_CODE: t(stone.dmCode, 8),
      DM_NAME: t(stone.dmName, 50),
      DM_SIZE: t(stone.dmSize, 20),
      DM_SFNO: t(stone.dmSfNo, 20),
      IT_PCS: approvalRound3(stone.pcs),
      IT_GWT: approvalRound3(stone.grossWt),
      KR_WT: approvalRound3(stone.karigarWt),
      IT_CON_PRC: num(stone.conPct),
      IT_RATE_TYPE: t(stone.rateType, 1),
      IT_RATE: num(stone.rate),
      IT_AMT: num(stone.amount),
      IT_LBR_RATE: num(stone.lbrRate),
      IT_LBR_AMT: num(stone.lbrAmount),
      IT_NET_AMT: num(stone.netAmount),
      IT_CON_WT: approvalRound3(stone.conWt),
      DM_LEB: t(stone.dmLeb, 15),
      DM_COLOR: t(stone.dmColor, 15),
      DM_ORIGIN: t(stone.dmOrigin, 20),
      DM_REMARK: t(stone.dmRemark, 20),
      IT_PCS_WT: approvalRound3(stone.pcsWt),
      KR_LESS_PRC: num(stone.karigarLessPct),
      KR_CON_PRC: num(stone.karigarConPct),
      KR_CON_WT: approvalRound3(stone.karigarConWt),
      KR_RATE: num(stone.karigarRate),
      KR_AMT: num(stone.karigarAmount),
      KR_LBR_RATE: num(stone.karigarLabourRate),
      KR_LBR_AMT: num(stone.karigarLabourAmount),
      KR_NET_AMT: num(stone.karigarNetAmount),
      IT_TYPE: t(stone.itType, 1),
      MAIN_USER: identity.mainUser || null,
    })),
  );
}

export function stockRows(details: Row[], book: ApprovalBook, kind: ApprovalKind): Row[] {
  return details.map((row) => ({
    CO_CODE: row.CO_CODE,
    LC_CODE: row.LC_CODE,
    CO_YEAR: row.CO_YEAR,
    CO_BOOK: row.CO_BOOK,
    VCH_NO: row.VCH_NO,
    SR_NO: row.SR_NO,
    ISR_NO: 1,
    VCH_DATE: row.VCH_DATE,
    STK_DATE: toIsoDate(row.VCH_DATE),
    VCH_TYPE: book.shortName,
    BOOK_NAME: book.mainBook,
    AC_CODE: row.AC_CODE,
    IT_CODE: row.IT_CODE,
    TAG_NO: row.TAG_NO,
    VCH_SRNO: row.VCH_SRNO,
    TBL_CODE: row.TBL_CODE,
    TR_TYPE: kind === 'issue' ? 'O' : 'I',
    ITM_SIGN: kind === 'issue' ? '-' : '+',
    ITM_QTY: 1,
    ITM_PCS: row.ITM_PCS,
    ITM_GWT: row.ITM_GWT,
    ITM_NWT: row.ITM_NWT,
    ITM_TOUCH: row.ITM_TOUCH,
    ITM_WEST: row.ITM_WEST_PRC,
    ITM_FINE: row.ITM_FINE,
    ITM_RATE: row.ITM_RATE,
    ITM_AMT: row.ITM_AMT,
    LBR_RATE: row.LBR_RATE,
    LBR_AMT: row.LBR_AMT,
    OTH_AMT: row.OTH_AMT,
    ITM_MRP: row.ITM_MRP,
    NET_AMT: 0,
    KR_NWT: row.KR_NET_WT,
    KR_TOUCH: row.KR_TOUCH,
    KR_WEST: row.KR_WEST_PRC,
    KR_FINE: row.KR_FINE,
    EMP_CODE: '',
    ITM_LOT: '',
    ITM_DISC: 0,
    ENTRY_TIME: row.VCH_TIME,
    MAIN_USER: row.MAIN_USER,
    DATA_TYPE: 'A',
    DESIGN_NO: row.DESIGN_NO,
    ITM_SIZE: row.ITM_SIZE,
  }));
}

export async function dmRowsTx(
  tx: any,
  tenantId: string,
  stones: Row[],
  details: Row[],
  book: ApprovalBook,
  kind: ApprovalKind,
): Promise<Row[]> {
  const codes = [...new Set(stones.map((row) => text(row.IT_CODE)).filter(Boolean))];
  if (!codes.length) return [];
  const allowed: Array<{ IT_CODE: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "IT_CODE" FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
      AND "IT_CODE"=ANY($3::text[]) AND upper(btrim(coalesce("OTH_DETL_POSTING"::text,'')))='Y'`,
    tenantId,
    details[0]!.CO_CODE,
    codes,
  );
  const posts = new Set(allowed.map((row) => text(row.IT_CODE)));
  return stones
    .filter((row) => posts.has(text(row.IT_CODE)))
    .map((row) => {
      const parent = details[num(row.SR_NO) - 1]!;
      return {
        CO_CODE: row.CO_CODE,
        LC_CODE: row.LC_CODE,
        CO_YEAR: row.CO_YEAR,
        CO_BOOK: row.CO_BOOK,
        VCH_NO: row.VCH_NO,
        MAIN_SRNO: kind === 'issue' ? 1 : 2,
        SR_NO: row.SR_NO,
        ISR_NO: row.ISR_NO,
        VCH_DATE: row.VCH_DATE,
        ENTRY_TYPE: 'S',
        BOOK_NAME: book.shortName,
        AC_CODE: row.AC_CODE,
        IT_CODE: row.IT_CODE,
        DM_CODE: row.DM_CODE,
        DM_ORIGIN: row.DM_ORIGIN,
        DM_REMARK: row.DM_REMARK,
        DM_SIZE: row.DM_SIZE,
        DM_COLOR: row.DM_COLOR,
        DM_LOT_NO: '',
        DM_PCS: row.IT_PCS,
        DM_WT: row.IT_GWT,
        DM_SIGN: kind === 'issue' ? '-' : '+',
        DM_RATE: row.IT_RATE,
        DM_AMT: row.IT_AMT,
        EMP_CODE: '',
        TAG_NO: row.TAG_NO,
        VCH_SRNO: row.VCH_SRNO,
        MAIN_IT_CODE: parent.IT_CODE,
        INOUT_TYPE: book.inout,
        TBL_CODE: parent.TBL_CODE,
      };
    });
}

export async function setBarFlagsTx(
  tx: any,
  tenantId: string,
  details: Row[],
  kind: ApprovalKind,
): Promise<void> {
  const tagged = details.filter((line) => isApprovalTag(line.TAG_NO));
  for (const row of tagged) {
    // TR_APR_ISU.cs:6412-6431 marks every return unavailable, but re-marks an issue tag only while
    // that source row remains open (ISU_REC='N'). A description edit must not reopen a returned tag.
    if (kind === 'issue' && text(row.ISU_REC).toUpperCase() !== 'N') continue;
    await tx.$executeRawUnsafe(
      `UPDATE "BAR_DETL" SET "APR_ISU"=$6${kind === 'return' ? ',"APP_TRFR"=\'N\'' : ''}
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"=$4
          AND coalesce("VCH_SRNO",0)::numeric=$5::numeric`,
      tenantId,
      row.CO_CODE,
      row.LC_CODE,
      row.TAG_NO,
      num(row.VCH_SRNO),
      kind === 'issue' ? 'Y' : 'N',
    );
  }
}

export async function setSourceReceivedTx(
  tx: any,
  tenantId: string,
  details: Row[],
  received: 'Y' | 'N',
): Promise<void> {
  for (const row of details) {
    if (!text(row.ISU_DBCD) || !text(row.ISU_NO)) continue;
    await tx.$executeRawUnsafe(
      `UPDATE "APR_DETL" SET "ISU_REC"=$8 WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND "OLD_SRNO"::numeric=$7::numeric`,
      tenantId,
      row.CO_CODE,
      row.LC_CODE,
      row.ISU_YRCD,
      row.ISU_DBCD,
      row.ISU_NO,
      num(row.ISU_SRNO),
      received,
    );
  }
}
