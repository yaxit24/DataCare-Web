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
  CR_FINE: number;
  DR_FINE: number;
  KSR_FINE_CR: number;
  KSR_FINE_DR: number;
  TOT_FINE_CR: number;
  TOT_FINE_DR: number;
  CR_AMT: number;
  DR_AMT: number;
  PR_LBR_AMT: number;
  SL_LBR_AMT: number;
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

/**
 * The report's own Cr/Dr formulas read the balance as credit minus debit: `@OpAmtCrDr` is `Cr` when the amount is
 * above zero, else `Dr` (WhSalesBill.spec.json; the balance comes from `DC_Main.MsAcBal`, `SUM(CR_AMT-DR_AMT)`,
 * DC_Main.cs:1471). `amount` here is the ledger's debit minus credit, so a positive amount is a debit. Gold and silver
 * are the signed fine (`+` is positive): above zero is `Cr`, else `Dr` (`@OpGodCrDr`, `@OpSilverCrd`).
 */
const amountSide = (amount: number): string => (amount > 0 ? 'Dr' : amount < 0 ? 'Cr' : 'Dr');
const fineSide = (fine: number): string => (fine > 0 ? 'Cr' : 'Dr');
const balanceRow = (
  label: string,
  value: number,
  format: (x: unknown) => string,
  side: (x: number) => string,
): string =>
  `<tr><td>${esc(label)}</td><td class="r">${format(Math.abs(value))}</td><td>${side(value)}</td></tr>`;

/**
 * Issue rows then receive rows. RATE_CUT_ISU_REC is grouped by ENTRY_TYPE: a group header (`@Issue_Rec_Type`, "Issue
 * Item" or "Received Item"), one row per line with the running `@SrNo`, and the group's gross weight
 * (`Sum(ITM_GWT, ENTRY_TYPE)`) under the Gr Wt column.
 */
const grid = (lines: any[], receivedLines: any[]): string => {
  const row = (line: any, serial: number) => `<tr>
      <td>${serial}</td>
      <td>${esc(line.itemName || line.itCode)}${line.tagNo ? ` <small>(${esc(line.tagNo)})</small>` : ''}</td>
      <td class="r">${n(line.pcs) || ''}</td><td class="r">${wt(line.grossWt)}</td><td class="r">${wt(line.netWt)}</td>
      <td class="r">${blankZero(line.touch, (x) => n(x).toFixed(2))}</td>
      <td class="r">${blankZero(line.westPct, (x) => n(x).toFixed(2))}</td>
      <td class="r">${wt(line.fine)}</td><td class="r">${blankZero(line.lbrAmt, money)}</td>
      <td class="r">${blankZero(line.netAmount ?? line.totalAmount, money)}</td>
    </tr>`;
  let serial = 0;
  const group = (title: string, group: any[]): string =>
    group.length === 0
      ? ''
      : `<tr class="grp"><td colspan="10"><b>${esc(title)}</b></td></tr>` +
        group.map((line) => row(line, ++serial)).join('') +
        `<tr class="sub"><td colspan="3"></td><td class="r"><b>${wt(
          group.reduce((sum, line) => sum + n(line.grossWt), 0),
        )}</b></td><td colspan="6"></td></tr>`;
  const rows = group('Issue Item', lines) + group('Received Item', receivedLines);
  return `<table class="items"><thead><tr>
      <th>SNO</th><th>Item Name</th><th>Pcs.</th><th>Gr Wt.</th><th>Net Wt</th><th>Touch</th><th>West</th>
      <th>FineWt.</th><th>Labour</th><th>Net Amount</th>
    </tr></thead><tbody>${rows || '<tr><td colspan="10" style="text-align:center">No lines</td></tr>'}</tbody></table>`;
};

/**
 * Printable projection of desktop WhSalesBill.RPT (report-specs/WhSalesBill.spec.json), which TR_WH_SALE prints for a
 * WH SALES book (BtnPrint_Click, TR_WH_SALE.cs:13654-13800): the report title (`@RptTitle`, the book's name), the party
 * block, Vch Date / Vch No / Ref No, the issue and receive groups, the four-column band (Purchase Fine, Sales Fine,
 * Purchase Amt, Sales Amt), Vch Desc, and the party's opening and closing money, gold and silver.
 *
 * The band's cells are the report's own formulas: `@RecFine` is TOT_FINE_CR - (KSR_FINE_CR + CR_FINE), `@IsuFine` is
 * TOT_FINE_DR - (KSR_FINE_DR + DR_FINE), `@PurcAmt` is PR_NET_AMT - CR_AMT, `@SlAmt` is SL_NET_AMT - DR_AMT, `@CrTot`
 * is CR_AMT + PR_LBR_AMT, `@DrTot` is DR_AMT + SL_LBR_AMT and `@TotIsuFine` is TOT_FINE_DR - TOT_FINE_CR.
 *
 * Deliberate differences: `@InVoiceType` is the constant 'ESTIMATE' in this report and is printed as it is; the web
 * does not store the fine kasar (KSR_FINE_CR and KSR_FINE_DR are 0), so that row prints zeros; the report's `@AcMobile`
 * prints the empty mobile in its phone branch (a formula slip), the web prints the phone there; the item-detail rows
 * (SL_IDTL under each line) wait for the web to write them.
 */
export function wholesaleSaleBillHtml(
  voucher: any,
  band: WholesaleBillBand,
  context: {
    company?: any;
    party?: any;
    copy?: string;
    balances?: WholesaleBalances;
    bookName?: string;
  } = {},
): string {
  const party = context.party ?? {};
  const cells = (
    label: string,
    [purchaseFine, salesFine, purchaseAmt, salesAmt]: [
      number | null,
      number | null,
      number | null,
      number | null,
    ],
    extra = '',
  ) => {
    const cell = (value: number | null, format: (x: unknown) => string) =>
      `<td class="r">${value === null ? '' : format(value)}</td>`;
    return `<tr><td>${esc(label)}${extra}</td>${cell(purchaseFine, wt)}${cell(salesFine, wt)}${cell(
      purchaseAmt,
      money,
    )}${cell(salesAmt, money)}</tr>`;
  };
  const bandTable = `<table class="tot" style="width:100%"><thead><tr><th></th><th class="r">Purchase Fine</th>
      <th class="r">Sales Fine</th><th class="r">Purchase Amt</th><th class="r">Sales Amt</th></tr></thead><tbody>
      ${cells('Isu / Rec Fine :', [
        n(band.TOT_FINE_CR) - (n(band.KSR_FINE_CR) + n(band.CR_FINE)),
        n(band.TOT_FINE_DR) - (n(band.KSR_FINE_DR) + n(band.DR_FINE)),
        n(band.PR_NET_AMT) - n(band.CR_AMT),
        n(band.SL_NET_AMT) - n(band.DR_AMT),
      ])}
      ${cells(
        'Rate Cut Rate :',
        [n(band.CR_FINE), n(band.DR_FINE), n(band.CR_AMT), n(band.DR_AMT)],
        ` ${money(band.FINE_RATE)}`,
      )}
      ${cells('Kasar Fine', [n(band.KSR_FINE_CR), n(band.KSR_FINE_DR), null, null])}
      ${cells('Bill Total :', [
        n(band.TOT_FINE_CR),
        n(band.TOT_FINE_DR),
        n(band.CR_AMT) + n(band.PR_LBR_AMT),
        n(band.DR_AMT) + n(band.SL_LBR_AMT),
      ])}
      ${cells('Cash Amount :', [null, null, n(band.PR_CASH_AMT), n(band.SL_CASH_AMT)])}
      ${cells('Card Amount :', [null, null, n(band.PR_CARD_AMT), n(band.SL_CARD_AMT)])}
      ${cells('Chq Amount :', [null, null, n(band.PR_CHQ_AMT), n(band.SL_CHQ_AMT)])}
      ${cells('Kasar Amount :', [null, null, n(band.PR_KASAR_AMT), n(band.SL_KASAR_AMT)])}
      ${cells('Bill Oustanding :', [
        n(band.TOT_FINE_CR),
        n(band.TOT_FINE_DR) - n(band.TOT_FINE_CR),
        n(band.PR_BILL_OS),
        n(band.SL_BILL_OS),
      ]).replace('<tr>', '<tr class="grand">')}
    </tbody></table>`;
  const balances = context.balances
    ? `<table class="tot"><tbody>
        ${balanceRow('Oppning Bal :', context.balances.opening.amount, money, amountSide)}
        ${balanceRow('Closing Bal :', context.balances.closing.amount, money, amountSide)}
        ${balanceRow('OppningGold :', context.balances.opening.gold, wt, fineSide)}
        ${balanceRow('Closing Gold :', context.balances.closing.gold, wt, fineSide)}
        ${balanceRow('Oppning Silver :', context.balances.opening.silver, wt, fineSide)}
        ${balanceRow('Closing Silver :', context.balances.closing.silver, wt, fineSide)}
      </tbody></table>`
    : '';
  const body =
    grid(voucher.lines ?? [], voucher.receivedLines ?? []) +
    `<div class="lower"><div>${balances}${
      voucher.vchDesc ? `<p>Vch Desc : ${esc(voucher.vchDesc)}</p>` : ''
    }</div><div>${bandTable}</div></div>`;
  // @AcMobile: the mobile, else the phone, else the second mobile.
  const mobile = String(party.AC_MOBILE ?? voucher.mobile ?? '').trim();
  const phone = String(party.AC_PHONE ?? '').trim();
  const mobile2 = String(party.AC_MOBILE2 ?? '').trim();
  const contact = mobile
    ? `Mo : ${mobile}`
    : phone
      ? `Ph : ${phone}`
      : mobile2
        ? `Mo : ${mobile2}`
        : '';
  const gstNo = String(party.AC_GSTNO ?? '').trim();
  return docShell({
    title: context.bookName || 'Wholesale Sale',
    copy: context.copy,
    company: context.company,
    fallbackName: 'Company',
    billTo: {
      cap: 'Party',
      name: String(party.AC_NAME ?? voucher.acName ?? voucher.acCode ?? ''),
      addr: [voucher.add1, voucher.add2, voucher.add3, voucher.city].filter(Boolean),
      extra: [contact, gstNo ? `Gst No : ${gstNo}` : ''].filter(Boolean),
    },
    meta: [
      { k: 'Vch Date', v: formatDesktopDate(voucher.vchDate) },
      { k: 'Vch No', v: String(voucher.voucherNo ?? '') },
      { k: 'Ref No', v: String(voucher.billNo ?? '') },
      { k: 'Bill Type', v: 'ESTIMATE' },
    ],
    body,
    footer: billFooter(context.company, 'Company'),
  });
}
