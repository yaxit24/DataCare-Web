import { rojmelLedrKey, type RojmelContext, type RojmelRow } from './rojmel.js';

/**
 * The day book of a Wh Sales voucher, row for row from `Ac_Rojmel.Wh_Sales_Rojmel` (Ac_Rojmel.cs:221-310), gold
 * vouchers. WP-30 decision 1: the desktop source wins over the 66 rows the earlier slice measured, so keys, names and
 * directions below are the source's. The insert is `INSERT INTO ROJ_MEL_DATA(... CR_AMT,DR_AMT ...)` and the select
 * lists the credit first: reading it the other way round is what made five directions look opposite.
 *
 *   key    source row                                   AC_CODE / LD_CODE      name (AC_NAME)            money
 *   01     party fine, purchase side                    party / slot 2         BOOK_SNAME - AC_NAME      Cr PR_BILL_OS > 0
 *   02     purchase amount                              slot 2 / party         BOOK_SNAME - AC_NAME      Dr CR_AMT + PR_ITM_AMT
 *   03     party fine, sale side                        party / slot 1         BOOK_SNAME - AC_NAME      Dr SL_BILL_OS > 0
 *   04     sale amount                                  slot 1 / party         BOOK_SNAME - AC_NAME      Cr DR_AMT + SL_ITM_AMT
 *   05+Sr  an issued line with fine and no ItAmt        party / slot 1         E.AC_NAME (the master)    none, '-', pcs, weights
 *   06+Sr  a received line, the same                    party / slot 2         E.AC_NAME                 none, '+'
 *   07/08  fine kasar Dr / Cr                           party / slot 12        'KSR - ' E.AC_NAME        none, '-' / '+', ITM_FINE
 *   13     overpaid purchase                            party / slot 2         BOOK_SNAME - AC_NAME      Dr ABS(PR_BILL_OS) < 0
 *   14     overpaid sale (slot 8, as the source joins)  party / slot 8         BOOK_SNAME - AC_NAME      Cr ABS(SL_BILL_OS) < 0
 *   22     purchase cheque                              BANK_AC / party        ''                        Cr PR_CHQ_AMT
 *   26     purchase kasar                               slot 5 / party         'KSR - ' AC_NAME          Cr PR_KASAR_AMT
 *   27     labour                                       slot 6 / party         'LBR - ' AC_NAME          Cr SL_LBR_AMT + SL_OTH_AMT
 *
 * 21/23/24/25/28 follow the same source (cheque, card and kasar on the sale side, purchase card, purchase labour). Types 31/32
 * (tax) are written for a BUL WH SALE book only (`B.MAIN_BOOK = 'BUL WH SALE'`), which Wh Sales is not.
 * Every row also carries the voucher's description in IT_DESC (`A.VCH_DESC`; a line row carries its remark). Types
 * 21, 23, 24, 25, 28, 29-40 and the silver families are not built (case rojmel.missing-types-and-silver, blocked).
 * The line key is `voucher + type + Str(SR_NO)`, which `rojmelLedrKey` writes as the ten-wide right-aligned number.
 */
export interface WholesaleRojmelLine {
  srNo: number;
  itType: string;
  pcs: number;
  grossWt: number;
  netWt: number;
  touch: number;
  westPct: number;
  fine: number;
  itemAmount: number;
  remark: string;
  itCode: string;
}

/** The stored voucher's figures the day book is built from: derived on the server at save, never an API input. */
export interface WholesaleRojmelFigures {
  /**
   * The book's BOOK_DETL by SR_NO. A row joins `B.SR_NO = n`, so it is written whenever the slot row EXISTS, even
   * with a blank AC_CODE (the value is then ''); a slot with no row writes nothing.
   */
  slots: Record<number, string | undefined>;
  cardAc: string;
  /** SL_CHQ_AMT, SL_CARD_AMT, SL_KASAR_AMT, PR_CARD_AMT and PR_LBR_AMT + PR_OTH_AMT (types 21, 23, 25, 24, 28). */
  saleChequeAmount: number;
  saleCardAmount: number;
  saleKasarAmount: number;
  purchaseCardAmount: number;
  purchaseLabourAmount: number;
  /** `RATE_CUT_DATA.AC_NAME` as stored, and the account master's name (`E.AC_NAME`). */
  headerName: string;
  masterName: string;
  vchDesc: string;
  dataType?: string;
  bankAc: string;
  fineRate: number;
  drFine: number;
  crFine: number;
  purchaseBillOs: number;
  saleBillOs: number;
  /** `CR_AMT + PR_ITM_AMT` and `DR_AMT + SL_ITM_AMT`. */
  purchaseAmount: number;
  saleAmount: number;
  ksrFineDr: number;
  ksrFineCr: number;
  purchaseChequeAmount: number;
  purchaseKasarAmount: number;
  /** `SL_LBR_AMT + SL_OTH_AMT`. */
  labourAmount: number;
  issued: WholesaleRojmelLine[];
  received: WholesaleRojmelLine[];
}

export function buildWholesaleRojmel(
  ctx: RojmelContext,
  input: WholesaleRojmelFigures,
): RojmelRow[] {
  const rows: RojmelRow[] = [];
  const bookPrefixed = `${ctx.vchType} - ${input.headerName}`;
  const base = (type: string, srNo?: number): RojmelRow => ({
    ...ctx.key,
    LEDR_KEY: rojmelLedrKey(ctx.scope, ctx.coBook, ctx.vchNo, type as never, srNo),
    VCH_DATE: ctx.vchDate,
    VCH_TYPE: ctx.vchType,
    BOOK_NAME: ctx.bookName,
    AC_CODE: '',
    AC_NAME: bookPrefixed,
    LD_CODE: '',
    DR_AMT: 0,
    CR_AMT: 0,
    IT_TYPE: 'A',
    SIGN: '',
    ITM_PCS: 0,
    ITM_GWT: 0,
    ITM_NWT: 0,
    ITM_TOUCH: 0,
    ITM_WEST: 0,
    ITM_FINE: 0,
    ITM_RATE: 0,
    ITM_AMT: 0,
    LBR_RATE: 0,
    LBR_AMT: 0,
    OTH_AMT: 0,
    NET_AMT: 0,
    IT_DESC: input.vchDesc,
    IT_CODE: '',
    ...(input.dataType ? { DATA_TYPE: input.dataType } : {}),
  });
  const party = ctx.partyCode;
  const has = (n: number): boolean => input.slots[n] !== undefined;
  const at = (n: number): string => input.slots[n] ?? '';
  const sale = has(1) ? at(1) : undefined;
  const purchase = has(2) ? at(2) : undefined;

  if (purchase !== undefined && (input.drFine !== 0 || input.purchaseBillOs > 0))
    rows.push({
      ...base('01'),
      AC_CODE: party,
      LD_CODE: purchase,
      CR_AMT: input.purchaseBillOs > 0 ? input.purchaseBillOs : 0,
      IT_TYPE: 'G',
      SIGN: '-',
      ITM_FINE: input.drFine,
      ITM_RATE: input.fineRate,
    });
  if (purchase !== undefined && input.purchaseAmount !== 0)
    rows.push({ ...base('02'), AC_CODE: purchase, LD_CODE: party, DR_AMT: input.purchaseAmount });
  if (sale !== undefined && (input.crFine !== 0 || input.saleBillOs > 0))
    rows.push({
      ...base('03'),
      AC_CODE: party,
      LD_CODE: sale,
      DR_AMT: input.saleBillOs > 0 ? input.saleBillOs : 0,
      IT_TYPE: 'G',
      SIGN: '+',
      ITM_FINE: input.crFine,
      ITM_RATE: input.fineRate,
    });
  if (sale !== undefined && input.saleAmount !== 0)
    rows.push({ ...base('04'), AC_CODE: sale, LD_CODE: party, CR_AMT: input.saleAmount });

  const lineRow = (
    type: string,
    line: WholesaleRojmelLine,
    ld: string,
    sign: '-' | '+',
  ): RojmelRow => ({
    ...base(type, line.srNo),
    AC_CODE: party,
    LD_CODE: ld,
    AC_NAME: input.masterName,
    IT_TYPE: line.itType as RojmelRow['IT_TYPE'],
    SIGN: sign,
    ITM_PCS: line.pcs,
    ITM_GWT: line.grossWt,
    ITM_NWT: line.netWt,
    ITM_TOUCH: line.touch,
    ITM_WEST: line.westPct,
    ITM_FINE: line.fine,
    IT_DESC: line.remark,
    IT_CODE: line.itCode,
  });
  const qualifies = (line: WholesaleRojmelLine): boolean =>
    line.fine !== 0 && line.itemAmount === 0 && line.itType === 'G';
  if (sale !== undefined)
    for (const line of input.issued) if (qualifies(line)) rows.push(lineRow('05', line, sale, '-'));
  if (purchase !== undefined)
    for (const line of input.received)
      if (qualifies(line)) rows.push(lineRow('06', line, purchase, '+'));

  if (has(12) && input.ksrFineDr !== 0)
    rows.push({
      ...base('07'),
      AC_CODE: party,
      LD_CODE: at(12),
      AC_NAME: `KSR - ${input.masterName}`,
      IT_TYPE: 'G',
      SIGN: '-',
      ITM_FINE: input.ksrFineDr,
    });
  if (has(12) && input.ksrFineCr !== 0)
    rows.push({
      ...base('08'),
      AC_CODE: party,
      LD_CODE: at(12),
      AC_NAME: `KSR - ${input.masterName}`,
      IT_TYPE: 'G',
      SIGN: '+',
      ITM_FINE: input.ksrFineCr,
    });

  if (purchase !== undefined && input.purchaseBillOs < 0)
    rows.push({
      ...base('13'),
      AC_CODE: party,
      LD_CODE: purchase,
      DR_AMT: Math.abs(input.purchaseBillOs),
    });
  // The source joins slot 8 (the silver sale account) for type 14 and filters no metal; kept as written.
  if (has(8) && input.saleBillOs < 0)
    rows.push({
      ...base('14'),
      AC_CODE: party,
      LD_CODE: at(8),
      CR_AMT: Math.abs(input.saleBillOs),
    });

  // Sale-side tender and purchase labour (Ac_Rojmel.cs:263-277); the cheque and card rows join slot 1, kasar 4, labour 7.
  if (has(1) && input.saleChequeAmount !== 0)
    rows.push({
      ...base('21'),
      AC_CODE: input.bankAc,
      LD_CODE: party,
      AC_NAME: '',
      DR_AMT: input.saleChequeAmount,
    });
  if (has(1) && input.saleCardAmount !== 0)
    rows.push({
      ...base('23'),
      AC_CODE: input.cardAc,
      LD_CODE: party,
      AC_NAME: '',
      DR_AMT: input.saleCardAmount,
    });
  if (has(1) && input.purchaseCardAmount !== 0)
    rows.push({
      ...base('24'),
      AC_CODE: input.cardAc,
      LD_CODE: party,
      AC_NAME: '',
      CR_AMT: input.purchaseCardAmount,
    });
  if (has(4) && input.saleKasarAmount !== 0)
    rows.push({
      ...base('25'),
      AC_CODE: at(4),
      LD_CODE: party,
      AC_NAME: `KSR - ${input.headerName}`,
      DR_AMT: input.saleKasarAmount,
    });
  if (has(7) && input.purchaseLabourAmount !== 0)
    rows.push({
      ...base('28'),
      AC_CODE: at(7),
      LD_CODE: party,
      AC_NAME: `LBR - ${input.headerName}`,
      DR_AMT: input.purchaseLabourAmount,
    });
  if (input.purchaseChequeAmount !== 0)
    rows.push({
      ...base('22'),
      AC_CODE: input.bankAc,
      LD_CODE: party,
      AC_NAME: '',
      CR_AMT: input.purchaseChequeAmount,
    });
  if (has(5) && input.purchaseKasarAmount !== 0)
    rows.push({
      ...base('26'),
      AC_CODE: at(5),
      LD_CODE: party,
      AC_NAME: `KSR - ${input.headerName}`,
      CR_AMT: input.purchaseKasarAmount,
    });
  if (has(6) && input.labourAmount !== 0)
    rows.push({
      ...base('27'),
      AC_CODE: at(6),
      LD_CODE: party,
      AC_NAME: `LBR - ${input.headerName}`,
      CR_AMT: input.labourAmount,
    });
  return rows;
}
