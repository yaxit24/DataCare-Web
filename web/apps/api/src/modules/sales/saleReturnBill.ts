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
 * Sales-return Credit Note document (G127): SL_DATA header + SL_DETL_RTN lines (the return keeps its
 * header in SL_DATA like a sale, but the returned items live in SL_DETL_RTN, not SL_DETL — so this is a
 * dedicated reader, not the plain sales bill). Rendered on the shared A4 GST-bill chrome, mirroring the
 * desktop SaleRtnBillA4Gst.rpt. Credit-note copy marking distinguishes it from a tax invoice.
 */
export type SaleReturnBillScope = VoucherDocumentScope;

export async function saleReturnBillData(
  prisma: any,
  scope: SaleReturnBillScope,
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
         FROM "SL_DETL_RTN" d
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

export interface SaleReturnBillCtx {
  company?: any;
  party?: any;
  copy?: string;
  fallbackName?: string;
}

export function saleReturnBillHtml(header: any, lines: any[], ctx: SaleReturnBillCtx = {}): string {
  const h = header;
  const p = ctx.party ?? {};
  const vchDate = h.VCH_DATE ? String(h.VCH_DATE).slice(0, 10) : '';
  const meta: DocMeta[] = [
    { k: 'Credit Note No', v: String(h.BILL_NO ?? h.VCH_NO ?? '') },
    { k: 'Date', v: vchDate },
    { k: 'Book / Vch', v: `${h.CO_BOOK ?? ''} / ${h.VCH_NO ?? ''}` },
  ];

  const mob = h.MOBILE ?? p.AC_MOBILE;
  return docShell({
    title: 'Credit Note — Sales Return',
    copy: ctx.copy,
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    billTo: {
      cap: 'Customer',
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
      'Credit note — goods returned as per particulars above. Value credited to the customer. E.&O.E.',
    ),
  });
}
