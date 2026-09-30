import { withTenant } from '@datacare/db';
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

/** Karigar (goldsmith/job-work) ISSUE voucher: KR_DATA header + KR_DETL lines — metal issued to a
 *  karigar for making. Fine-weight focused (gross/net/touch/fine + making), mirroring KrIsuBill.
 *  Not a customer GST bill, so it has its own metal body (labour GST shown only if present). */
export type KarigarVoucherScope = VoucherDocumentScope;

export async function karigarIssueData(
  prisma: any,
  scope: KarigarVoucherScope,
): Promise<{ header: any; lines: any[]; company: any; party: any } | null> {
  const s = requireVoucherDocumentScope(scope);
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const params = voucherKeyParams(s);
    const h: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "KR_DATA" WHERE ${voucherKeyWhere()} LIMIT 1`,
      ...params,
    );
    if (!h.length) return null;
    const header = h[0];
    const lines: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "KR_DETL" WHERE ${voucherKeyWhere()} ORDER BY "SR_NO"`,
      ...params,
    );
    const company = await documentCompanyTx(tx, s);
    const party = await documentPartyTx(tx, s, header.AC_CODE);
    return { header, lines, company, party };
  });
}

export interface KarigarVoucherCtx {
  company?: any;
  party?: any;
  copy?: string;
  fallbackName?: string;
  title?: string;
}

export function karigarIssueHtml(header: any, lines: any[], ctx: KarigarVoucherCtx = {}): string {
  const h = header;
  const p = ctx.party ?? {};
  const inter = num(h.IGST_TAX) > 0;
  let sPcs = 0,
    sGwt = 0,
    sNwt = 0,
    sFine = 0,
    sMaking = 0;
  const rows = lines
    .map((l, i) => {
      const fine = num(l.ITM_FINE) || (num(l.ITM_NWT) * num(l.ITM_TOUCH)) / 100;
      sPcs += num(l.ITM_PCS);
      sGwt += num(l.ITM_GWT);
      sNwt += num(l.ITM_NWT);
      sFine += fine;
      sMaking += num(l.LBR_AMT);
      const desc =
        esc(l.IT_CODE) +
        (l.DESIGN_NO
          ? `<span class="hu">Design: ${esc(l.DESIGN_NO)}${l.ITM_SIZE ? ' · Size ' + esc(l.ITM_SIZE) : ''}</span>`
          : '') +
        (l.IT_DESC ? `<span class="hu">${esc(l.IT_DESC)}</span>` : '');
      return (
        `<tr><td class="c">${i + 1}</td><td>${desc}</td>` +
        `<td class="r">${num(l.ITM_PCS) || ''}</td><td class="r">${wt(l.ITM_GWT)}</td><td class="r">${wt(l.ITM_NWT)}</td>` +
        `<td class="r">${num(l.ITM_TOUCH) || ''}</td><td class="r">${num(l.ITM_WEST_PRC) || ''}</td><td class="r">${wt(fine)}</td><td class="r">${money(l.LBR_AMT)}</td></tr>`
      );
    })
    .join('');
  const itemsTable = `<table class="items"><thead><tr>
      <th>#</th><th style="width:32%">Item / Design</th><th>Pcs</th><th>Gross Wt</th><th>Net Wt</th><th>Touch%</th><th>Wst%</th><th>Fine Wt</th><th>Making</th>
    </tr></thead><tbody>${rows || '<tr><td colspan="9" class="c">No items issued</td></tr>'}</tbody>
    <tfoot><tr><td class="c" colspan="2">Total</td><td class="r">${sPcs || ''}</td><td class="r">${wt(sGwt)}</td><td class="r">${wt(sNwt)}</td><td></td><td></td><td class="r">${wt(sFine)}</td><td class="r">${money(sMaking)}</td></tr></tfoot></table>`;

  const t: string[] = [`<tr><td>Total Fine Weight</td><td class="r">${wt(sFine)} g</td></tr>`];
  if (sMaking > 0) t.push(`<tr><td>Labour / Making</td><td class="r">${money(sMaking)}</td></tr>`);
  if (num(h.LBR_AMT) > 0)
    t.push(`<tr><td>Labour (Header)</td><td class="r">${money(h.LBR_AMT)}</td></tr>`);
  if (inter && num(h.IGST_TAX) > 0)
    t.push(`<tr class="sub"><td>IGST</td><td class="r">${money(h.IGST_TAX)}</td></tr>`);
  else if (num(h.CGST_TAX) > 0 || num(h.SGST_TAX) > 0) {
    t.push(`<tr class="sub"><td>CGST</td><td class="r">${money(h.CGST_TAX)}</td></tr>`);
    t.push(`<tr><td>SGST</td><td class="r">${money(h.SGST_TAX)}</td></tr>`);
  }
  if (num(h.TOT_AMT) > 0)
    t.push(`<tr class="grand"><td>Total Amount</td><td class="r">₹ ${money(h.TOT_AMT)}</td></tr>`);
  const totals =
    `<div class="lower"><div class="hsn"></div><div class="tot"><table>${t.join('')}</table></div></div>` +
    (num(h.TOT_AMT) > 0
      ? `<div class="words"><b>Amount in words:</b> ${esc(rupeesInWords(num(h.TOT_AMT)))} only.</div>`
      : '');

  const vchDate = h.VCH_DATE ? String(h.VCH_DATE).slice(0, 10) : '';
  const meta: DocMeta[] = [
    { k: 'Voucher No', v: String(h.BILL_NO ?? h.VCH_NO ?? '') },
    { k: 'Date', v: vchDate },
    { k: 'Book / Vch', v: `${h.CO_BOOK ?? ''} / ${h.VCH_NO ?? ''}` },
  ];
  return docShell({
    title: ctx.title ?? 'Karigar Issue Voucher',
    copy: ctx.copy,
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    billTo: {
      cap: 'Karigar / Goldsmith',
      name: p.AC_NAME ?? h.AC_NAME ?? h.AC_CODE,
      addr: [
        h.ADD1 ?? p.AC_ADD1,
        h.CITY ?? p.AC_CITY,
        (h.MOBILE ?? p.AC_MOBILE) && `Mob: ${h.MOBILE ?? p.AC_MOBILE}`,
      ].filter(Boolean),
    },
    meta,
    body: itemsTable + totals,
    footer: billFooter(
      ctx.company,
      ctx.fallbackName,
      'Metal issued for job-work as per particulars above. Receiver acknowledges the fine weight. E.&O.E.',
    ),
  });
}
