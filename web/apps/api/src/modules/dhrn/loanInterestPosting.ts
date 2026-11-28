import { roundHalfEvenDecimal, round, roundHalfEven } from '@datacare/core';
import type { LedgerLine } from '../posting/posting.js';

const decimal = (value: number) => roundHalfEvenDecimal(value, 8);

export interface LoanInterestAmounts {
  loanType: string;
  principal: number;
  unchak: number;
  assessed: number;
  received: number;
  kasar: number;
  monthInterest: number;
  rateCutRate: number;
  rateCutPay: number;
}

/** TR_DHRN_INTREC.cs:5569-5573: rate cut is assessed interest × rate, whole rupees. */
export function loanRateCut(a: LoanInterestAmounts) {
  const amount = a.loanType === 'A' ? 0 : roundHalfEven(decimal(a.assessed).mul(a.rateCutRate), 0);
  return { amount, outstanding: round(decimal(amount).minus(a.rateCutPay), 2) };
}

/** Ac_Ledr.cs:1436-1468, Ac_Rojmel.cs:627-640, Ac_Stock.cs:305-312.
 * Keep the desktop's strict >25 / <25 predicates (25 deliberately satisfies neither).
 * Account codes are resolved by the caller; there are no seeded-code fallbacks here.
 */
export function loanInterestPosting(
  a: LoanInterestAmounts,
  base: Record<string, any>,
  rojBase: Record<string, any>,
  accounts: { party: string; settlement: string; cash: string; interest: string; kasar: string; metal: string },
  name: string,
  key: (n: number) => string,
) {
  const { party, settlement, cash, interest, kasar, metal } = accounts;
  const ptot = round(decimal(a.principal).plus(a.unchak), a.loanType === 'A' ? 2 : 3);
  const isAmount = a.loanType === 'A';
  const moneyInterest = isAmount || a.monthInterest > 25;
  const fineInterest = !isAmount && a.monthInterest < 25;
  const cut = loanRateCut(a);
  const ledger: LedgerLine[] = [];
  const money = (legType: number, ac: string, ld: string, dr: number, cr: number, partyCode = ac === party ? party : '') => {
    ledger.push({ ...base, legType, AC_CODE: ac, LD_CODE: ld, DR_AMT: dr, CR_AMT: cr, IT_TYPE: 'A', SIGN: '', PARTY_AC_CODE: partyCode } as LedgerLine);
  };
  const fine = (legType: number, ld: string, sign: string, value: number) => {
    if (value) ledger.push({ ...base, legType, AC_CODE: party, LD_CODE: ld, DR_AMT: 0, CR_AMT: 0, IT_TYPE: a.loanType, SIGN: sign, FINE_WT: value, PARTY_AC_CODE: party } as LedgerLine);
  };
  if (isAmount && ptot) { money(1, party, settlement, ptot, 0); money(2, settlement, party, 0, ptot); }
  if (moneyInterest && a.assessed) { money(3, party, interest, 0, a.assessed); money(4, interest, party, a.assessed, 0); }
  if (moneyInterest && a.received) { money(5, party, settlement, a.received, 0); money(6, settlement, party, 0, a.received); }
  if (isAmount && a.kasar) { money(7, party, kasar, a.kasar, 0); money(8, kasar, party, 0, a.kasar); }
  if (!isAmount) fine(9, settlement, '-', ptot);
  if (fineInterest) { fine(10, interest, '+', a.assessed); fine(11, settlement, '-', a.received); }
  if (!isAmount && cut.amount && a.rateCutRate) { money(13, party, metal, 0, cut.amount); money(14, metal, party, cut.amount, 0, party); }
  if (!isAmount && a.rateCutPay) { money(15, party, settlement, a.rateCutPay, 0); money(16, settlement, party, 0, a.rateCutPay); }
  const roj: Record<string, unknown>[] = [];
  const row = (n: number, ac: string, ld: string, dr: number, cr: number, caption: string, type = 'A', sign = '') => roj.push({ ...rojBase, LEDR_KEY: key(n), AC_CODE: ac, LD_CODE: ld, DR_AMT: dr, CR_AMT: cr, AC_NAME: caption, IT_TYPE: type, SIGN: sign });
  if (ptot) row(1, party, settlement, ptot, 0, `Lon - ${name}`);
  if (moneyInterest && a.received) row(2, party, interest, round(decimal(a.received).plus(a.kasar), 2), 0, `Lon Int - ${name}`);
  if (moneyInterest && a.kasar) row(3, interest, party, 0, a.kasar, `Lon ksar - ${name}`);
  const cashAmount = round(decimal(ptot).plus(a.received), 2);
  if (moneyInterest && cashAmount && settlement !== cash) row(4, settlement, party, 0, cashAmount, '');
  if (cut.amount) row(6, party, settlement, cut.amount, 0, `Lon Rcut - ${name}`, a.loanType, '-');
  if (a.rateCutPay && settlement !== cash) row(8, settlement, party, 0, a.rateCutPay, '');
  const stock: Record<string, unknown>[] = [];
  if (fineInterest && cut.amount === 0) {
    // UNCHAK is intentionally absent from the stock quantity in Ac_Stock.cs:311.
    const wt = round(decimal(a.principal).plus(a.received), 3);
    const { IT_TYPE: _type, SIGN: _sign, IT_DESC: _desc, ...stockBase } = base;
    stock.push({ ...stockBase, SR_NO: 1, ISR_NO: 1, STK_DATE: base.VCH_DATE, AC_CODE: party,
      IT_CODE: a.loanType === 'G' ? '999' : 'FSL', TAG_NO: 'N', VCH_SRNO: 0, TBL_CODE: '',
      TR_TYPE: 'O', ITM_SIGN: '-', ITM_QTY: 1, ITM_PCS: 0, ITM_GWT: wt, ITM_NWT: wt,
      ITM_TOUCH: 100, ITM_WEST: 0, ITM_FINE: wt, ITM_RATE: 0, ITM_AMT: 0,
      LBR_RATE: 0, LBR_AMT: 0, OTH_AMT: 0, ITM_MRP: 0, NET_AMT: 0,
      KR_NWT: wt, KR_TOUCH: 100, KR_WEST: 0, KR_FINE: wt, KR_LBR_AMT: 0,
      KR_OTH_AMT: 0, KR_COST: 0, EMP_CODE: '', DESIGN_NO: '', ITM_SIZE: '', ITM_DESC: '', GHT_PRC: 0, ITM_LOT: '', ITM_DISC: 0 });
  }
  return { ledger, roj, stock, cut };
}
