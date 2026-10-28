import { withTxBudget } from '../shared/txBudget.js';
import { docShell, gstBillBody, billFooter, type DocMeta } from '../documents/docChrome.js';
import {
  documentCompanyTx,
  documentPartyTx,
  requireVoucherDocumentScope,
  voucherKeyParams,
  voucherKeyWhere,
  type VoucherDocumentScope,
} from '../documents/voucherDocument.js';

/**
 * Sales-bill document (G125): SL_DATA header + SL_DETL lines (joined CO_MAST seller + AC_MAST customer
 * + ITEM/GROUP HSN), rendered on the shared A4 GST-bill body — the retail sales counterpart of
 * `purchaseBill.ts`, mirroring the desktop SaleBillA4Gst.rpt. The HTML chrome (docShell + gstBillBody
 * + billFooter) is shared with the purchase bill so both prints stay visually consistent.
 */
export type SalesBillScope = VoucherDocumentScope;

export async function salesBillData(
  prisma: any,
  scope: SalesBillScope,
): Promise<{ header: any; lines: any[]; company: any; party: any } | null> {
  const s = requireVoucherDocumentScope(scope);
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const params = voucherKeyParams(s);
    const h: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "SL_DATA" WHERE ${voucherKeyWhere()} LIMIT 1`,
      ...params,
    );
    if (!h.length) return null;
    const header = h[0];
    const lines: any[] = await tx.$queryRawUnsafe(
      `SELECT d.*, COALESCE(NULLIF(i."HSN_CODE",''), g."HSN_CODE") AS "HSN_CODE"
         FROM "SL_DETL" d
         LEFT JOIN "ITEM_MAST" i ON i.tenant_id=d.tenant_id AND i."CO_CODE"=d."CO_CODE" AND i."IT_CODE"=d."IT_CODE"
         LEFT JOIN "GROUP_MAST" g ON g.tenant_id=i.tenant_id AND g."CO_CODE"=i."CO_CODE" AND g."GR_CODE"=i."GR_CODE"
        WHERE ${voucherKeyWhere('d')} ORDER BY d."SR_NO"`,
      ...params,
    );
    const company = await documentCompanyTx(tx, s);
    const party = await documentPartyTx(tx, s, header.AC_CODE);
    return { header, lines, company, party };
  });
}

export interface SalesBillCtx {
  company?: any;
  party?: any;
  copy?: string;
  fallbackName?: string;
  title?: string;
  partyCaption?: string;
  footerText?: string;
}

export function salesBillHtml(header: any, lines: any[], ctx: SalesBillCtx = {}): string {
  const h = header;
  const p = ctx.party ?? {};
  const vchDate = h.VCH_DATE ? String(h.VCH_DATE).slice(0, 10) : '';
  const meta: DocMeta[] = [
    { k: 'Bill No', v: String(h.BILL_NO ?? h.VCH_NO ?? '') },
    { k: 'Date', v: vchDate },
    { k: 'Book / Vch', v: `${h.CO_BOOK ?? ''} / ${h.VCH_NO ?? ''}` },
  ];

  const mob = h.MOBILE ?? p.AC_MOBILE;
  return docShell({
    title: ctx.title ?? 'Tax Invoice',
    copy: ctx.copy,
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    billTo: {
      cap: ctx.partyCaption ?? 'Customer',
      name: p.AC_NAME ?? h.AC_NAME ?? h.AC_CODE,
      addr: [
        h.ADD1 ?? p.AC_ADD1,
        h.ADD2 ?? p.AC_ADD2,
        h.ADD3 ?? p.AC_ADD3,
        h.CITY ?? p.AC_CITY,
        mob && `Mob: ${mob}`,
      ].filter(Boolean),
      gstin: p.AC_GSTNO,
      state: p.AC_STATE,
    },
    meta,
    body: gstBillBody(h, lines),
    footer: billFooter(
      ctx.company,
      ctx.fallbackName,
      ctx.footerText ??
        'Tax invoice — goods sold as per particulars above. Goods once sold will not be taken back. E.&O.E.',
    ),
  });
}
