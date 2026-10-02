import { withTxBudget } from '../shared/txBudget.js';
import {
  docShell,
  esc,
  num,
  money,
  wt,
  rupeesInWords,
  billFooter,
  type DocMeta,
} from '../documents/docChrome.js';
import {
  documentCompanyTx,
  documentPartyTx,
  requireVoucherDocumentScope,
  voucherKeyParams,
  voucherKeyWhere,
  type VoucherDocumentScope,
} from '../documents/voucherDocument.js';

/** Dhrn (pledge/gold-loan) ISSUE RECEIPT: DHRN_ISU_DATA header + DHRN_ISU_DETL pledged items.
 *  Mirrors desktop DhrnIssue.rpt — borrower, pledged collateral (pcs/gross/net wt + valuation),
 *  loan principal, interest rate + monthly interest, from/due date, packet no, amount in words. */
export type DhrnScope = VoucherDocumentScope;

export async function dhrnIssueData(
  prisma: any,
  scope: DhrnScope,
): Promise<{ header: any; lines: any[]; company: any; party: any } | null> {
  const s = requireVoucherDocumentScope(scope);
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const params = voucherKeyParams(s);
    const h: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "DHRN_ISU_DATA" WHERE ${voucherKeyWhere()} LIMIT 1`,
      ...params,
    );
    if (!h.length) return null;
    const header = h[0];
    const lines: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "DHRN_ISU_DETL" WHERE ${voucherKeyWhere()} ORDER BY "SR_NO"`,
      ...params,
    );
    const company = await documentCompanyTx(tx, s);
    const party = await documentPartyTx(tx, s, header.AC_CODE);
    return { header, lines, company, party };
  });
}

export interface DhrnCtx {
  company?: any;
  party?: any;
  copy?: string;
  fallbackName?: string;
}
const dt = (v: any): string => (v ? String(v).slice(0, 10) : '');

export function dhrnIssueHtml(header: any, lines: any[], ctx: DhrnCtx = {}): string {
  const h = header;
  const p = ctx.party ?? {};
  const principal = num(h.DHRN_AMT);
  const monthInt = num(h.MONTH_INT_AMT);

  let sPcs = 0,
    sGwt = 0,
    sNwt = 0,
    sVal = 0;
  const rows = (
    lines.length
      ? lines
      : [{ IT_NAME: h.GOLD_DESC, ITM_GWT: h.GOLD_WT, ITM_NWT: h.GOLD_NWT, ITM_AMT: h.GOLD_AMT }]
  )
    .map((l, i) => {
      sPcs += num(l.ITM_PCS);
      sGwt += num(l.ITM_GWT);
      sNwt += num(l.ITM_NWT);
      sVal += num(l.ITM_AMT);
      const desc =
        esc(l.IT_NAME ?? l.IT_CODE ?? l.IT_DESC ?? 'Pledged Item') +
        (l.IT_DESC && l.IT_NAME ? `<span class="hu">${esc(l.IT_DESC)}</span>` : '') +
        (l.HM_ID ? `<span class="hu">HUID: ${esc(l.HM_ID)}</span>` : '');
      return (
        `<tr><td class="c">${i + 1}</td><td>${desc}</td><td class="r">${num(l.ITM_PCS) || ''}</td>` +
        `<td class="r">${wt(l.ITM_GWT)}</td><td class="r">${wt(l.ITM_NWT)}</td><td class="r">${num(l.ITM_TOUCH) || ''}</td>` +
        `<td class="r">${wt(l.ITM_FINE)}</td><td class="r">${money(l.ITM_AMT)}</td></tr>`
      );
    })
    .join('');
  const itemsTable =
    `<div class="vinfo" style="margin:6px 0;font-size:12px"><b>Pledged Collateral</b></div>` +
    `<table class="items"><thead><tr><th>#</th><th style="width:30%">Item / Description</th><th>Pcs</th><th>Gross Wt</th><th>Net Wt</th><th>Touch%</th><th>Fine</th><th>Valuation</th></tr></thead>` +
    `<tbody>${rows}</tbody>` +
    `<tfoot><tr><td class="c" colspan="2">Total</td><td class="r">${sPcs || ''}</td><td class="r">${wt(sGwt)}</td><td class="r">${wt(sNwt)}</td><td></td><td></td><td class="r">${money(sVal || h.GOLD_AMT)}</td></tr></tfoot></table>`;

  const terms: string[] = [
    `<tr><td>Loan Principal</td><td class="r">₹ ${money(principal)}</td></tr>`,
    `<tr><td>Interest Rate</td><td class="r">${num(h.INT_PRC)}%${num(h.INT_MONTH) ? ` · ${num(h.INT_MONTH)} month(s)` : ''}</td></tr>`,
  ];
  if (monthInt > 0)
    terms.push(`<tr><td>Interest / month</td><td class="r">${money(monthInt)}</td></tr>`);
  if (num(h.GOLD_AMT) > 0)
    terms.push(`<tr><td>Collateral Valuation</td><td class="r">${money(h.GOLD_AMT)}</td></tr>`);
  terms.push(
    `<tr class="grand"><td>Amount Advanced</td><td class="r">₹ ${money(principal)}</td></tr>`,
  );
  const termsBox =
    `<div class="hsn"><div style="border:1px solid #94a3b8;border-radius:4px;padding:6px 8px;font-size:11px">` +
    `<b>From:</b> ${esc(dt(h.VCH_DATE))} &nbsp; <b>Due:</b> ${esc(dt(h.DHRN_DUE_DATE ?? h.TO_DATE))}` +
    `${h.PACKET_NO ? `<br/><b>Packet No:</b> ${esc(h.PACKET_NO)}` : ''}${h.LOAN_TYPE ? ` &nbsp; <b>Loan Type:</b> ${esc(h.LOAN_TYPE)}` : ''}` +
    `${h.VCH_DESC ? `<br/><b>Remarks:</b> ${esc(h.VCH_DESC)}` : ''}</div></div>`;
  const lower =
    `<div class="lower">${termsBox}<div class="tot"><table>${terms.join('')}</table></div></div>` +
    `<div class="words"><b>Amount in words:</b> ${esc(rupeesInWords(principal))} only.</div>`;

  const meta: DocMeta[] = [
    { k: 'Loan / Bill No', v: String(h.DHRN_BILL ?? h.VCH_NO ?? '') },
    { k: 'Date', v: dt(h.VCH_DATE) },
    { k: 'Due Date', v: dt(h.DHRN_DUE_DATE ?? h.TO_DATE) },
    { k: 'Book / Vch', v: `${h.CO_BOOK ?? ''} / ${h.VCH_NO ?? ''}` },
  ];
  return docShell({
    title: 'Dhrn Loan — Pledge Receipt',
    copy: ctx.copy,
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    billTo: {
      cap: 'Borrower',
      name: p.AC_NAME ?? h.AC_NAME ?? h.AC_CODE,
      addr: [p.AC_ADD1, p.AC_CITY, p.AC_MOBILE && `Mob: ${p.AC_MOBILE}`].filter(Boolean),
    },
    meta,
    body: itemsTable + lower,
    footer: billFooter(
      ctx.company,
      ctx.fallbackName,
      'The above ornaments are pledged as security for the loan. Interest payable monthly. Goods redeemable on full repayment of principal + interest. Subject to jurisdiction. E.&O.E.',
    ),
  });
}
