/**
 * The stones of an issued tag on a TR_WH_SALE voucher.
 *
 * Picking a tag on the Wh Sales grid reads the tag's BAR_IDTL rows into the item-detail grid (TR_WH_SALE.cs:10113-10148:
 * `WHERE TAG_NO = tag AND VCH_SRNO = the tag instance`). Save writes that grid to SL_IDTL (:13162-13250): ENTRY_TYPE
 * 'W', SR_NO the line's serial, ISR_NO 1.. restarting for each line, only a row whose pieces, gross weight, less weight
 * or net amount is not zero (:13190-13194). Dm_Wh_Tour_Sale_Detl (Ac_Stock.cs:857-861, called at :13358) then projects
 * those rows into DM_DATA for a line whose item has OTH_DETL_POSTING = 'Y', on a WH SALES or TOUR SALES book only:
 * MAIN_SRNO 1, ENTRY_TYPE 'S', DM_SIGN '-', INOUT_TYPE 'S', MAIN_IT_CODE and TBL_CODE from the issued line.
 *
 * Deliberately not ported: the desktop's hand-typed rows for a loose item (the item-detail dialog). A loose line has no
 * tag instance and so no stones here.
 */
type Row = Record<string, unknown>;

/** The main books whose vouchers Dm_Wh_Tour_Sale_Detl projects (`B.MAIN_BOOK IN ('WH SALES','TOUR SALES')`). */
const DM_DATA_BOOKS = new Set(['WH SALES', 'TOUR SALES']);

const n = (value: unknown): number => Number(value ?? 0) || 0;

export interface WholesaleStoneRows {
  idtl: Row[];
  dmData: Row[];
}

/**
 * SL_IDTL and DM_DATA rows for the issued lines. `issued` are the RATE_CUT_ISU rows already built for the voucher; the
 * stones are read from the tags' BAR_IDTL. Pure reads: the caller writes the rows with the voucher.
 */
export async function buildWholesaleStoneRows(
  tx: any,
  tenantId: string,
  voucher: { mainBook: string; mainUser: string | null; hiddenVoucherNo: string },
  issued: Row[],
): Promise<WholesaleStoneRows> {
  const idtl: Row[] = [];
  const dmData: Row[] = [];
  const posting = new Map<string, boolean>();
  const postsDetail = async (coCode: string, itCode: string): Promise<boolean> => {
    if (!posting.has(itCode)) {
      const found: Array<{ flag: string | null }> = await tx.$queryRawUnsafe(
        `SELECT "OTH_DETL_POSTING" AS flag FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3 LIMIT 1`,
        tenantId,
        coCode,
        itCode,
      );
      posting.set(itCode, String(found[0]?.flag ?? '').toUpperCase() === 'Y');
    }
    return posting.get(itCode)!;
  };
  for (const line of issued) {
    const tag = String(line.TAG_NO ?? '').trim();
    const instance = n(line.VCH_SRNO);
    if (!tag || tag.toUpperCase() === 'N' || instance === 0) continue;
    const stones: Row[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "BAR_IDTL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"=$4 AND "VCH_SRNO"=$5
        ORDER BY "ISR_NO","row_id"`,
      tenantId,
      line.CO_CODE,
      line.LC_CODE,
      tag,
      instance,
    );
    let isrNo = 0;
    for (const stone of stones) {
      if (n(stone.IT_PCS) + n(stone.IT_GWT) + n(stone.KR_WT) + n(stone.IT_NET_AMT) === 0) continue;
      isrNo += 1;
      idtl.push({
        CO_CODE: line.CO_CODE,
        LC_CODE: line.LC_CODE,
        CO_YEAR: line.CO_YEAR,
        CO_BOOK: line.CO_BOOK,
        VCH_NO: line.VCH_NO,
        HD_VCH_NO: voucher.hiddenVoucherNo,
        VCH_DATE: line.VCH_DATE,
        AC_CODE: line.AC_CODE,
        VCH_TYPE: line.VCH_TYPE,
        INOUT_TYPE: line.INOUT_TYPE,
        ENTRY_TYPE: 'W',
        BOOK_NAME: line.BOOK_NAME,
        SR_NO: line.SR_NO,
        TAG_NO: tag,
        VCH_SRNO: instance,
        ISR_NO: isrNo,
        IT_CODE: stone.IT_CODE ?? line.IT_CODE,
        DM_CODE: stone.DM_CODE,
        DM_NAME: stone.DM_NAME,
        DM_COLOR: stone.DM_COLOR,
        DM_SIZE: stone.DM_SIZE,
        DM_ORIGIN: stone.DM_ORIGIN,
        DM_REMARK: stone.DM_REMARK,
        DM_SFNO: stone.DM_SFNO,
        IT_PCS: stone.IT_PCS,
        IT_PCS_WT: 0,
        KR_LESS_PRC: 0,
        IT_GWT: stone.IT_GWT,
        KR_WT: stone.KR_WT,
        IT_CON_PRC: stone.IT_CON_PRC,
        IT_RATE_TYPE: stone.IT_RATE_TYPE,
        IT_RATE: stone.IT_RATE,
        IT_AMT: stone.IT_AMT,
        IT_DISC_PRC: stone.IT_DISC_PRC,
        IT_DISC_AMT: stone.IT_DISC_AMT,
        IT_LBR_RATE: stone.IT_LBR_RATE,
        IT_LBR_AMT: stone.IT_LBR_AMT,
        IT_NET_AMT: stone.IT_NET_AMT,
        KR_CON_PRC: stone.KR_CON_PRC,
        IT_CON_WT: stone.IT_CON_WT,
        IT_TYPE: stone.IT_TYPE,
        MAIN_USER: voucher.mainUser,
      });
      const itCode = String(stone.IT_CODE ?? line.IT_CODE ?? '');
      if (
        DM_DATA_BOOKS.has(voucher.mainBook) &&
        (await postsDetail(String(line.CO_CODE), itCode))
      ) {
        dmData.push({
          CO_CODE: line.CO_CODE,
          LC_CODE: line.LC_CODE,
          CO_YEAR: line.CO_YEAR,
          CO_BOOK: line.CO_BOOK,
          VCH_NO: line.VCH_NO,
          MAIN_SRNO: 1,
          SR_NO: line.SR_NO,
          ISR_NO: isrNo,
          VCH_DATE: line.VCH_DATE,
          ENTRY_TYPE: 'S',
          BOOK_NAME: line.VCH_TYPE,
          AC_CODE: line.AC_CODE,
          IT_CODE: itCode,
          DM_CODE: stone.DM_CODE,
          DM_ORIGIN: stone.DM_ORIGIN,
          DM_REMARK: stone.DM_REMARK,
          DM_SIZE: stone.DM_SIZE,
          DM_COLOR: stone.DM_COLOR,
          DM_LOT_NO: '',
          DM_PCS: stone.IT_PCS,
          DM_WT: stone.IT_GWT,
          DM_SIGN: '-',
          DM_RATE: stone.IT_RATE,
          DM_AMT: stone.IT_AMT,
          EMP_CODE: '',
          TAG_NO: tag,
          VCH_SRNO: instance,
          MAIN_IT_CODE: line.IT_CODE,
          INOUT_TYPE: 'S',
          TBL_CODE: line.TBL_CODE ?? null,
        });
      }
    }
  }
  return { idtl, dmData };
}
