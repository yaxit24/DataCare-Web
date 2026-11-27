/**
 * The purchase day book (ROJ_MEL_DATA), ported from `Ac_Rojmel.Purc_Rojmel`
 * (unified/src/csharp_nextdm/DataCareNext/Ac_Rojmel.cs:115-177).
 *
 * ## Row-type codes: the data's numbering, not the source's
 * The source numbers its inserts 01-21; the build that wrote the real 2024-25 data numbered them more
 * tightly. Measured on the 51 replayed purchases (oracle sp5 replay of the owner's desktop data):
 *
 *   01 item (:119)       43 rows  AC_NAME = party, DR ITM_AMT+LBR_AMT+OTH_AMT
 *   03 tax (:136)         5 rows  DR TAX_AMT, AC_NAME ''            (source '06')
 *   04 TCS (:138)         2 rows  CR TCS_AMT, AC_NAME ''            (source '07')
 *   08 party (:156)      19 rows  CR BILL_OS, AC_NAME = party       (source '13')
 *   09 cheque (:158)      2 rows  CR CHQ_AMT, AC_NAME ''            (source '14')
 *   11 kasar (:162)       2 rows  CR KASAR_AMT, 'KSR - ' + party    (source '16')
 *   14 metal (:173)      42 rows  no money, ITM_FINE, AC_NAME = party (source '20')
 *
 * The offset is constant inside each run (source - 3 for 06..08, - 5 for 13..18, - 6 for 20..21), so the rows
 * without a real example take the same offset: labour 02 (:126 '03'), TDS 05 (:140 '08'), hallmark 06 and its
 * tax 07 (:151/:153 '11'/'12'), card 10 (:160 '15'), discount 12 (:164 '17'), round-off 13 (:166 '18'),
 * silver 15 (:175 '21'). The UAE-only rows (:130, :132, :144, :170) are the ones the offsets show the data build
 * did not have; they take unused codes 16-19. All inferred codes are UNVERIFIED against data.
 */
import type { VoucherScope } from '../vouchers/numbering.js';
import { resolveBookAccountTx, type BookPolicy } from './bookPolicy.js';
import {
  blank,
  rojmelLedrKey,
  type RojmelContext,
  type RojmelLine,
  type RojmelRow,
} from './rojmel.js';

export const PURCHASE_ROJMEL_TYPE = {
  item: '01',
  labour: '02',
  tax: '03',
  tcs: '04',
  tds: '05',
  hallmark: '06',
  hallmarkTax: '07',
  party: '08',
  cheque: '09',
  card: '10',
  kasar: '11',
  discount: '12',
  roundOff: '13',
  metal: '14',
  silver: '15',
  uaeOther: '16',
  uaeLabour: '17',
  otherTax: '18',
  unfixedMetal: '19',
} as const;
export type PurchaseRojmelRowType =
  (typeof PURCHASE_ROJMEL_TYPE)[keyof typeof PURCHASE_ROJMEL_TYPE];

export type PurchaseRojmelLine = RojmelLine & { otherFine?: number; silverFine?: number };

export interface PurchaseRojmelOptions {
  /** CO_SET.PURC_WITH_LBR = 'Y' (DC_Main.MsPurcWithLbr). */
  withLabour: boolean;
  /** CO_MAST.CO_SNAME = 'UAE' (DC_Main.MCo_SName). */
  uae?: boolean;
  /** BOOK_DATA.MAIN_BOOK = 'B2B PURC': :126 excludes it, :130/:132 are limited to it. */
  b2b?: boolean;
  /** BOOK_DETL slot 1: the party row's contra (:156 B.AC_CODE). */
  partyAccount: string;
  labourAccount?: string;
  kasarAccount?: string;
  discountAccount?: string;
  taxAccount?: string;
  tcsAccount?: string;
  tdsAccount?: string;
  otherTaxAccount?: string;
  otherTaxName?: string;
  hallmarkTaxAccount?: string;
  hallmarkTaxName?: string;
}

const num = (value: unknown): number => Number(value ?? 0);
const text = (value: unknown): string => String(value ?? '').trim();

/**
 * Project a saved purchase into its day-book rows. `header` is the PR_DATA row as written, because every money
 * row reads its amount from PR_DATA exactly as the desktop's INSERT ... SELECT does.
 */
export function buildPurchaseRojmel(
  ctx: RojmelContext,
  lines: PurchaseRojmelLine[],
  header: Record<string, unknown>,
  options: PurchaseRojmelOptions,
): RojmelRow[] {
  const rows: RojmelRow[] = [];
  const types = PURCHASE_ROJMEL_TYPE;
  const make = (type: PurchaseRojmelRowType, lineNo?: number): RojmelRow =>
    blank(ctx, rojmelLedrKey(ctx.scope, ctx.coBook, ctx.vchNo, type, lineNo));
  // Every money row: IT_TYPE 'A', IT_DESC = PR_DATA.VCH_DESC, guarded by `<amount> <> 0`. A row whose account
  // comes from a BOOK_DETL slot or TAX_MAST join is not written when that slot/tax is missing, as the desktop's
  // `B.SR_NO = n` / `D.SR_NO = 0` WHERE filters drop it.
  const money = (
    type: PurchaseRojmelRowType,
    account: string | undefined,
    amount: number,
    credit = false,
    name = '',
    contra = ctx.partyCode,
  ): void => {
    if (!amount || !account) return;
    rows.push({
      ...make(type),
      AC_CODE: account,
      LD_CODE: contra,
      AC_NAME: name,
      DR_AMT: credit ? 0 : amount,
      CR_AMT: credit ? amount : 0,
      IT_DESC: ctx.voucherDescription ?? '',
    });
  };
  // :117 - the item row carries labour and other charges, and the party's name, only with PURC_WITH_LBR = 'Y'
  // outside the UAE; otherwise (:124) it is ITM_AMT alone with a blank name and labour gets its own rows.
  const combined = options.withLabour && !options.uae;
  for (const line of lines) {
    const itemAmount = line.itemAmount ?? line.amount;
    const amount = itemAmount + (combined ? (line.labourAmount ?? 0) + (line.otherAmount ?? 0) : 0);
    if (!amount) continue;
    rows.push({
      ...make(types.item, line.lineNo),
      AC_CODE: line.revenueAc,
      LD_CODE: ctx.partyCode,
      AC_NAME: combined ? ctx.partyName : '',
      DR_AMT: amount,
      IT_TYPE: line.metal,
      SIGN: '+',
      ITM_PCS: line.pcs ?? 0,
      ITM_GWT: line.grossWt ?? 0,
      ITM_NWT: line.netWt ?? 0,
      ITM_RATE: line.rate ?? 0,
      ITM_AMT: itemAmount,
      LBR_RATE: line.labourRate ?? 0,
      LBR_AMT: line.labourAmount ?? 0,
      OTH_AMT: line.otherAmount ?? 0,
      NET_AMT: line.netAmount ?? line.amount,
      IT_CODE: line.itemCode ?? '',
      IT_DESC: line.itemName ?? '',
    });
  }
  if (!combined) {
    // :126 slot 4, LBR_AMT+OTH_AMT, every purchase book but B2B PURC; :130/:132 split them on B2B PURC (UAE).
    if (!options.b2b)
      money(types.labour, options.labourAccount, num(header.LBR_AMT) + num(header.OTH_AMT));
    if (options.uae && options.b2b) {
      money(types.uaeOther, '00007', num(header.OTH_AMT));
      money(types.uaeLabour, options.labourAccount, num(header.LBR_AMT));
    }
  }
  money(types.tax, options.taxAccount, num(header.TAX_AMT)); // :136
  money(types.tcs, options.tcsAccount, num(header.TCS_AMT), true); // :138, the one CREDITED tax
  money(types.tds, options.tdsAccount, num(header.TDS_AMT)); // :140
  if (options.uae) {
    money(
      types.otherTax,
      options.otherTaxAccount,
      num(header.OTH_TAX_AMT),
      false,
      options.otherTaxName,
    ); // :144
  } else {
    money(types.hallmark, '00097', num(header.HM_AMT)); // :151
  }
  // :146 (UAE) and :153: the hallmark tax names the tax account (E.AC_NAME).
  money(
    types.hallmarkTax,
    options.hallmarkTaxAccount,
    num(header.HM_TAX_AMT),
    false,
    options.hallmarkTaxName,
  );
  // :156 - CREDIT BILL_OS as signed (no split on the sign, unlike the sale), and none for a purchase linked to a
  // sale bill (SL_BILL_NO set).
  if (!text(header.SL_BILL_NO)) {
    money(
      types.party,
      ctx.partyCode,
      num(header.BILL_OS),
      true,
      ctx.partyName,
      options.partyAccount,
    );
  }
  money(types.cheque, text(header.BANK_AC), num(header.CHQ_AMT), true); // :158
  money(types.card, text(header.CARD_AC), num(header.CARD_AMT), true); // :160
  money(types.kasar, options.kasarAccount, num(header.KASAR_AMT), true, `KSR - ${ctx.partyName}`); // :162 slot 3
  money(
    types.discount,
    options.discountAccount,
    num(header.DISC_AMT),
    true,
    `DISC - ${ctx.partyName}`,
  ); // :164
  // :166 - the PARTY in AC_CODE, slot 5 as contra: a positive round-off is a debit, a negative one a credit of its
  // absolute value (CR_AMT = ABS(ROF_AMT) when < 0, DR_AMT = ROF_AMT when > 0), the mirror of the sale's :102.
  const roundOff = num(header.ROF_AMT);
  if (options.discountAccount) {
    money(
      types.roundOff,
      ctx.partyCode,
      Math.abs(roundOff),
      roundOff < 0,
      `ROF - ${ctx.partyName}`,
      options.discountAccount,
    );
  }
  // :170/:173/:175 - metal rows on the party (PR_DETL.AC_CODE), the group's PURC_AC as contra, no money, named
  // from AC_MAST. Selected on ITM_FINE and ITM_AMT, not on the rate.
  const unfixed = text(header.RATE_UNFIX) === 'Y';
  const masterName = ctx.partyMasterName || ctx.partyName;
  for (const line of lines) {
    const itemAmount = line.itemAmount ?? line.amount;
    for (const type of [
      ...(options.uae && unfixed ? [types.unfixedMetal] : []),
      ...(!unfixed && !itemAmount ? [types.metal] : []),
    ]) {
      if (!line.fine) continue;
      rows.push({
        ...make(type, line.lineNo),
        AC_CODE: ctx.partyCode,
        LD_CODE: line.revenueAc,
        AC_NAME: masterName,
        IT_TYPE: line.metal,
        SIGN: '+',
        ITM_PCS: line.pcs ?? 0,
        ITM_GWT: line.grossWt ?? 0,
        ITM_NWT: line.netWt ?? 0,
        ITM_TOUCH: line.touch ?? 0,
        ITM_WEST: line.wastage ?? 0,
        ITM_FINE: (line.fine ?? 0) + (line.otherFine ?? 0),
        IT_CODE: line.itemCode ?? '',
        IT_DESC: line.itemName ?? '',
      });
    }
    if (line.silverFine && !itemAmount) {
      rows.push({
        ...make(types.silver, line.lineNo),
        AC_CODE: ctx.partyCode,
        LD_CODE: '00009',
        AC_NAME: masterName,
        IT_TYPE: 'S',
        SIGN: '+',
        ITM_GWT: line.silverFine,
        ITM_NWT: line.silverFine,
        ITM_TOUCH: 100,
        ITM_FINE: line.silverFine,
        IT_CODE: line.itemCode ?? '',
        IT_DESC: line.itemName ?? '',
      });
    }
  }
  return rows;
}

/**
 * The accounts `buildPurchaseRojmel` needs beyond those the purchase ledger already resolved: the labour (slot 4)
 * and discount/round-off (slot 5) slots, which a book may not configure, and the TAX_MAST accounts of the TDS,
 * hallmark-tax and other-tax codes with their AC_MAST names.
 */
export async function purchaseRojmelOptionsTx(
  tx: { $queryRawUnsafe: (...args: any[]) => Promise<any> },
  scope: VoucherScope,
  bookPolicy: BookPolicy,
  header: Record<string, unknown>,
  base: Omit<PurchaseRojmelOptions, 'uae' | 'b2b'>,
): Promise<PurchaseRojmelOptions> {
  const company: Array<{ sname: string }> = await tx.$queryRawUnsafe(
    `SELECT upper(btrim(coalesce("CO_SNAME",''))) sname FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
    scope.tenantId,
    scope.coCode,
  );
  const uae = company[0]?.sname === 'UAE';
  const b2b = text(bookPolicy.mainBook).toUpperCase() === 'B2B PURC';
  const slot = (srNo: number, needed: boolean): Promise<string> =>
    needed
      ? resolveBookAccountTx(tx, scope, bookPolicy, srNo).catch(() => '')
      : Promise.resolve('');
  const labourAccount = await slot(
    4,
    (!base.withLabour || uae) && num(header.LBR_AMT) + num(header.OTH_AMT) !== 0,
  );
  const discountAccount = await slot(5, num(header.DISC_AMT) !== 0 || num(header.ROF_AMT) !== 0);
  const codes = [header.TDS_CODE, header.HM_TAX_CODE, header.OTH_TAX_CODE]
    .map(text)
    .filter(Boolean);
  const taxes: Array<{ code: unknown; ac: unknown; name: unknown }> = codes.length
    ? await tx.$queryRawUnsafe(
        `SELECT t."TAX_CODE" code, t."TAX_AC" ac,
                (SELECT a."AC_NAME" FROM "AC_MAST" a
                  WHERE a.tenant_id=t.tenant_id AND a."CO_CODE"=t."CO_CODE" AND a."AC_CODE"=t."TAX_AC"
                  ORDER BY (a."LC_CODE"::text=$3) DESC, a.row_id LIMIT 1) name
           FROM "TAX_MAST" t
          WHERE t.tenant_id=$1 AND t."CO_CODE"=$2 AND coalesce(t."SR_NO",0)=0
            AND t."TAX_CODE"::text = ANY($4::text[])
          ORDER BY t.row_id`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        codes,
      )
    : [];
  const tax = (code: unknown) => taxes.find((row) => text(row.code) === text(code));
  const hmTax = tax(header.HM_TAX_CODE);
  const otherTax = tax(header.OTH_TAX_CODE);
  return {
    ...base,
    uae,
    b2b,
    labourAccount,
    discountAccount,
    tdsAccount: text(tax(header.TDS_CODE)?.ac),
    hallmarkTaxAccount: text(hmTax?.ac),
    hallmarkTaxName: text(hmTax?.name),
    otherTaxAccount: text(otherTax?.ac),
    otherTaxName: text(otherTax?.name),
  };
}
