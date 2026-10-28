import { withTxBudget } from '../shared/txBudget.js';
import {
  docShell,
  esc,
  num,
  money,
  rupeesInWords,
  billFooter,
  type DocMeta,
} from '../documents/docChrome.js';
import {
  documentCompanyTx,
  requireVoucherDocumentScope,
  voucherKeyParams,
  voucherKeyWhere,
  type VoucherDocumentScope,
} from '../documents/voucherDocument.js';

/**
 * Contra voucher document (G128): a bank↔cash (or inter-account) transfer. The desktop writes two
 * CONTRA_DATA rows — Cr the from-account (SR_NO 1) and Dr the to-account (SR_NO 2) — of equal value.
 * Rendered on the shared docShell chrome as a From → To transfer voucher, mirroring ContraVch.rpt.
 */
export type ContraVoucherScope = VoucherDocumentScope;

export async function contraVoucherData(
  prisma: any,
  scope: ContraVoucherScope,
): Promise<{ rows: any[]; company: any } | null> {
  const s = requireVoucherDocumentScope(scope);
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const params = voucherKeyParams(s);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT c.*, a."AC_NAME" AS "RESOLVED_NAME"
         FROM "CONTRA_DATA" c
         LEFT JOIN "AC_MAST" a ON a.tenant_id=c.tenant_id AND a."CO_CODE"=c."CO_CODE" AND a."AC_CODE"=c."AC_CODE"
        WHERE ${voucherKeyWhere('c')} ORDER BY c."SR_NO"`,
      ...params,
    );
    if (!rows.length) return null;
    const company = await documentCompanyTx(tx, s);
    return { rows, company };
  });
}

export interface ContraVoucherCtx {
  company?: any;
  copy?: string;
  fallbackName?: string;
}

export function contraVoucherHtml(rows: any[], ctx: ContraVoucherCtx = {}): string {
  // Cr row = money leaves the "from" account; Dr row = money enters the "to" account.
  const crRow = rows.find((r) => num(r.CR_AMT) > 0) ?? rows[0];
  const drRow = rows.find((r) => num(r.DR_AMT) > 0) ?? rows[rows.length - 1];
  const amount = num(crRow?.CR_AMT) || num(drRow?.DR_AMT);
  const h = rows[0] ?? {};
  const acName = (r: any) => esc(r?.RESOLVED_NAME ?? r?.AC_NAME ?? r?.AC_CODE ?? '');
  const narration = h.IT_DESC ?? '';
  const vchDate = h.VCH_DATE ? String(h.VCH_DATE).slice(0, 10) : '';

  const body =
    `<table class="items"><thead><tr><th style="width:50%">From (credited)</th><th style="width:50%">To (debited)</th></tr></thead>` +
    `<tbody><tr><td>${acName(crRow)}</td><td>${acName(drRow)}</td></tr></tbody></table>` +
    `<div class="lower"><div class="hsn"><div style="border:1px solid #94a3b8;border-radius:4px;padding:6px 8px;font-size:11px">` +
    `<b>Transfer:</b> ${acName(crRow)} &rarr; ${acName(drRow)}` +
    `${narration ? `<br/><b>Narration:</b> ${esc(narration)}` : ''}</div></div>` +
    `<div class="tot"><table><tr class="grand"><td>Amount</td><td class="r">&#8377; ${money(amount)}</td></tr></table></div></div>` +
    `<div class="words"><b>Amount in words:</b> ${esc(rupeesInWords(amount))} only.</div>`;

  const meta: DocMeta[] = [
    { k: 'Voucher No', v: String(h.BILL_NO ?? h.VCH_NO ?? '') },
    { k: 'Date', v: vchDate },
    { k: 'Book / Vch', v: `${h.CO_BOOK ?? ''} / ${h.VCH_NO ?? ''}` },
  ];
  return docShell({
    title: 'Contra Voucher',
    copy: ctx.copy,
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    meta,
    body,
    footer: billFooter(
      ctx.company,
      ctx.fallbackName,
      'Contra entry — funds transferred between the accounts above. E.&O.E.',
    ),
  });
}

/**
 * Journal voucher document (G129): a multi-line Dr/Cr entry. The journal writer stores its lines in
 * CONTRA_DATA (shared with contra) + AC_DATA, so this reuses `contraVoucherData`. Rendered as the
 * classic accounting journal table (Particulars | Debit | Credit) with narration, per JournalVch.rpt.
 */
export function journalVoucherHtml(rows: any[], ctx: ContraVoucherCtx = {}): string {
  const h = rows[0] ?? {};
  const acName = (r: any) => esc(r?.RESOLVED_NAME ?? r?.AC_NAME ?? r?.AC_CODE ?? '');
  let totDr = 0;
  let totCr = 0;
  const lineRows = rows
    .map((r, i) => {
      const dr = num(r.DR_AMT);
      const cr = num(r.CR_AMT);
      totDr += dr;
      totCr += cr;
      // Classic journal indents the credited account under "To".
      const particulars = cr > 0 ? `&nbsp;&nbsp;&nbsp;&nbsp;To ${acName(r)}` : acName(r);
      return (
        `<tr><td class="c">${i + 1}</td><td>${particulars}</td>` +
        `<td class="r">${dr > 0 ? money(dr) : ''}</td><td class="r">${cr > 0 ? money(cr) : ''}</td></tr>`
      );
    })
    .join('');
  const narration = rows.map((r) => r.IT_DESC).find((d) => d && String(d).trim()) ?? '';
  const vchDate = h.VCH_DATE ? String(h.VCH_DATE).slice(0, 10) : '';

  const body =
    `<table class="items"><thead><tr><th>#</th><th style="width:56%">Particulars</th><th class="r">Debit</th><th class="r">Credit</th></tr></thead>` +
    `<tbody>${lineRows}</tbody>` +
    `<tfoot><tr><td class="c" colspan="2">Total</td><td class="r">${money(totDr)}</td><td class="r">${money(totCr)}</td></tr></tfoot></table>` +
    (narration ? `<div class="words"><b>Narration:</b> ${esc(narration)}</div>` : '') +
    `<div class="words"><b>Amount in words:</b> ${esc(rupeesInWords(totDr))} only.</div>`;

  const meta: DocMeta[] = [
    { k: 'Voucher No', v: String(h.BILL_NO ?? h.VCH_NO ?? '') },
    { k: 'Date', v: vchDate },
    { k: 'Book / Vch', v: `${h.CO_BOOK ?? ''} / ${h.VCH_NO ?? ''}` },
  ];
  return docShell({
    title: 'Journal Voucher',
    copy: ctx.copy,
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    meta,
    body,
    footer: billFooter(
      ctx.company,
      ctx.fallbackName,
      'Journal entry — as per particulars above. E.&O.E.',
    ),
  });
}
