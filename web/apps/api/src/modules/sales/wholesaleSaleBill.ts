import { formatDesktopDate } from '@datacare/core';
import { billFooter, docShell } from '../documents/docChrome.js';

const esc = (value: unknown): string =>
  String(value ?? '').replace(
    /[&<>"]/g,
    (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;' })[c]!,
  );
const n = (value: unknown): number => Number(value ?? 0) || 0;
const wt = (value: unknown): string => n(value).toFixed(3);
const money = (value: unknown): string =>
  n(value).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
const blankZero = (value: unknown, format: (x: unknown) => string): string =>
  n(value) === 0 ? '' : format(value);

export interface WholesaleBalances {
  opening: { amount: number; gold: number; silver: number };
  closing: { amount: number; gold: number; silver: number };
}

/** The stored RATE_CUT_DATA band the bill prints (column names as the report reads them). */
export interface WholesaleBillBand {
  FINE_RATE: number;
  PR_FINE: number;
  SL_FINE: number;
  DR_FINE: number;
  CR_FINE: number;
  PR_NET_AMT: number;
  SL_NET_AMT: number;
  PR_CASH_AMT: number;
  SL_CASH_AMT: number;
  PR_CARD_AMT: number;
  SL_CARD_AMT: number;
  PR_CHQ_AMT: number;
  SL_CHQ_AMT: number;
  PR_KASAR_AMT: number;
  SL_KASAR_AMT: number;
  PR_BILL_OS: number;
  SL_BILL_OS: number;
}

const drCr = (amount: number): string => (amount >= 0 ? 'Dr' : 'Cr');
const balanceRow = (label: string, value: number, format: (x: unknown) => string): string =>
  `<tr><td>${esc(label)}</td><td class="r">${format(Math.abs(value))}</td><td>${drCr(value)}</td></tr>`;

/** Issue rows then receive rows, as RATE_CUT_ISU_REC lists them (`@Issue_Rec_Type`, SNO, Item Name, …). */
const grid = (lines: any[], receivedLines: any[]): string => {
  const row = (line: any, index: number, kind: string) => `<tr>
      <td>${index + 1}</td><td>${esc(kind)}</td>
      <td>${esc(line.itemName || line.itCode)}${line.tagNo ? ` <small>(${esc(line.tagNo)})</small>` : ''}</td>
      <td class="r">${n(line.pcs) || ''}</td><td class="r">${wt(line.grossWt)}</td><td class="r">${wt(line.netWt)}</td>
      <td class="r">${blankZero(line.touch, (x) => n(x).toFixed(2))}</td>
      <td class="r">${blankZero(line.westPct, (x) => n(x).toFixed(2))}</td>
      <td class="r">${wt(line.fine)}</td><td class="r">${blankZero(line.lbrAmt, money)}</td>
      <td class="r">${blankZero(line.netAmount ?? line.totalAmount, money)}</td>
    </tr>`;
  const rows = [
    ...lines.map((line, i) => row(line, i, 'Issue')),
    ...receivedLines.map((line, i) => row(line, lines.length + i, 'Receive')),
  ].join('');
  return `<table class="items"><thead><tr>
      <th>SNO</th><th></th><th>Item Name</th><th>Pcs.</th><th>Gr Wt.</th><th>Net Wt</th><th>Touch</th><th>West</th>
      <th>FineWt.</th><th>Labour</th><th>Net Amount</th>
    </tr></thead><tbody>${rows || '<tr><td colspan="11" style="text-align:center">No lines</td></tr>'}</tbody></table>`;
};

/**
 * Printable projection of desktop WhSalesBill.RPT (report-specs/WhSalesBill.spec.json), which TR_WH_SALE prints for a
 * WH SALES book (BtnPrint_Click, TR_WH_SALE.cs:13654-13800): the party block, Vch Date / Vch No, the issue and receive
 * rows, the two-column band (Purchase / Sales: fine, amount, rate cut, bill total, cash, card, cheque, kasar, bill
 * outstanding), Vch Desc, and the party's opening and closing money, gold and silver balances.
 */
export function wholesaleSaleBillHtml(
  voucher: any,
  band: WholesaleBillBand,
  context: { company?: any; party?: any; copy?: string; balances?: WholesaleBalances } = {},
): string {
  const party = context.party ?? {};
  const pair = (label: string, purchase: number, sale: number, format: (x: unknown) => string) =>
    `<tr><td>${esc(label)}</td><td class="r">${format(purchase)}</td><td class="r">${format(sale)}</td></tr>`;
  const bandTable = `<table class="tot" style="width:100%"><thead><tr><th></th><th class="r">Purchase</th>
      <th class="r">Sales</th></tr></thead><tbody>
      ${pair('Isu / Rec Fine :', band.PR_FINE, band.SL_FINE, wt)}
      ${pair(`Rate Cut Rate : ${money(band.FINE_RATE)}`, band.DR_FINE, band.CR_FINE, wt)}
      ${pair('Bill Total :', band.PR_NET_AMT, band.SL_NET_AMT, money)}
      ${pair('Cash Amount :', band.PR_CASH_AMT, band.SL_CASH_AMT, money)}
      ${pair('Card Amount :', band.PR_CARD_AMT, band.SL_CARD_AMT, money)}
      ${pair('Chq Amount :', band.PR_CHQ_AMT, band.SL_CHQ_AMT, money)}
      ${pair('Kasar Amount :', band.PR_KASAR_AMT, band.SL_KASAR_AMT, money)}
      <tr class="grand"><td>Bill Oustanding :</td><td class="r">${money(band.PR_BILL_OS)}</td>
        <td class="r">${money(band.SL_BILL_OS)}</td></tr>
    </tbody></table>`;
  const balances = context.balances
    ? `<table class="tot"><tbody>
        ${balanceRow('Oppning Bal :', context.balances.opening.amount, money)}
        ${balanceRow('Closing Bal :', context.balances.closing.amount, money)}
        ${balanceRow('OppningGold :', context.balances.opening.gold, wt)}
        ${balanceRow('Closing Gold :', context.balances.closing.gold, wt)}
        ${balanceRow('Oppning Silver :', context.balances.opening.silver, wt)}
        ${balanceRow('Closing Silver :', context.balances.closing.silver, wt)}
      </tbody></table>`
    : '';
  const body =
    grid(voucher.lines ?? [], voucher.receivedLines ?? []) +
    `<div class="lower"><div>${balances}${
      voucher.vchDesc ? `<p>Vch Desc : ${esc(voucher.vchDesc)}</p>` : ''
    }</div><div>${bandTable}</div></div>`;
  return docShell({
    title: 'Wholesale Sale',
    copy: context.copy,
    company: context.company,
    fallbackName: 'Company',
    billTo: {
      cap: 'Party',
      name: String(party.AC_NAME ?? voucher.acName ?? voucher.acCode ?? ''),
      addr: [voucher.add1, voucher.add2, voucher.add3, voucher.city].filter(Boolean),
      extra: voucher.mobile ? [`Mobile: ${voucher.mobile}`] : [],
    },
    meta: [
      { k: 'Vch No', v: String(voucher.voucherNo ?? '') },
      { k: 'Vch Date', v: formatDesktopDate(voucher.vchDate) },
      { k: 'Ref No', v: String(voucher.billNo ?? '') },
      { k: 'Metal', v: voucher.itType === 'S' ? 'Silver' : 'Gold' },
    ],
    body,
    footer: billFooter(context.company, 'Company'),
  });
}
