import { formatVoucherNo } from '../vouchers/numbering.js';
import { withTenant } from '@datacare/db';
import { docShell, num, gstBillBody, billFooter, type DocMeta } from '../documents/docChrome.js';

export { rupeesInWords } from '../documents/docChrome.js';

/** GST Tax-Invoice builder: reads a sale (SL_DATA header + SL_DETL lines, joined to CO_MAST for the
 *  seller GSTIN and AC_MAST for the buyer GSTIN, and ITEM/GROUP for HSN) and renders a faithful A4
 *  GST tax invoice — mirroring the desktop SalesBillA4Gst.rpt: company+party GSTIN/state, per-line
 *  HSN/weights/rate/making/taxable, intra (CGST+SGST) vs inter-state (IGST) split, HSN-wise summary,
 *  hallmark tax, round-off, grand total, amount in words, bank + signatory. */
export interface InvoiceScope {
  tenantId: string;
  coCode: string;
  coYear?: string;
  coBook: string;
  vchNo: string | number;
}

export async function invoiceData(
  prisma: any,
  s: InvoiceScope,
): Promise<{ header: any; lines: any[]; company: any; party: any } | null> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const params = s.coYear
      ? [s.coCode, s.coBook, formatVoucherNo(s.vchNo), s.coYear]
      : [s.coCode, s.coBook, formatVoucherNo(s.vchNo)];
    const h: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "SL_DATA" WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3${s.coYear ? ' AND "CO_YEAR"=$4' : ''} LIMIT 1`,
      ...params,
    );
    if (!h.length) return null;
    const header = h[0];
    // lines enriched with HSN (ITEM_MAST → GROUP_MAST fallback)
    const lines: any[] = await tx.$queryRawUnsafe(
      `SELECT d.*, COALESCE(NULLIF(i."HSN_CODE",''), g."HSN_CODE") AS "HSN_CODE"
         FROM "SL_DETL" d
         LEFT JOIN "ITEM_MAST" i ON i."CO_CODE"=d."CO_CODE" AND i."IT_CODE"=d."IT_CODE"
         LEFT JOIN "GROUP_MAST" g ON g."CO_CODE"=i."CO_CODE" AND g."GR_CODE"=i."GR_CODE"
        WHERE d."CO_CODE"=$1 AND d."CO_BOOK"=$2 AND d."VCH_NO"=$3 ORDER BY d."SR_NO"`,
      s.coCode,
      s.coBook,
      formatVoucherNo(s.vchNo),
    );
    const co: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "CO_MAST" WHERE "CO_CODE"=$1 LIMIT 1`,
      s.coCode,
    );
    const party: any[] = header.AC_CODE
      ? await tx.$queryRawUnsafe(
          `SELECT * FROM "AC_MAST" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2 LIMIT 1`,
          s.coCode,
          header.AC_CODE,
        )
      : [];
    return { header, lines, company: co[0] ?? null, party: party[0] ?? null };
  });
}

export interface InvoiceCtx {
  company?: any;
  party?: any;
  copy?: string;
  fallbackName?: string;
  title?: string;
}

export function invoiceHtml(header: any, lines: any[], ctx: InvoiceCtx = {}): string {
  const h = header;
  const p = ctx.party ?? {};
  const vchDate = h.VCH_DATE ? String(h.VCH_DATE).slice(0, 10) : '';
  const meta: DocMeta[] = [
    { k: 'Invoice No', v: String(h.BILL_NO ?? h.VCH_NO ?? '') },
    { k: 'Date', v: vchDate },
    { k: 'Book / Vch', v: `${h.CO_BOOK ?? ''} / ${h.VCH_NO ?? ''}` },
  ];
  if (num(h.CR_DAYS) > 0) meta.push({ k: 'Credit Days', v: String(num(h.CR_DAYS)) });
  if (h.EMP_CODE) meta.push({ k: 'Salesman', v: String(h.EMP_CODE) });

  return docShell({
    title: ctx.title ?? 'Tax Invoice',
    copy: ctx.copy,
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    billTo: {
      cap: 'Bill To',
      name: p.AC_NAME ?? h.AC_NAME ?? h.AC_CODE,
      addr: [
        p.AC_ADD1,
        p.AC_ADD2,
        p.AC_ADD3,
        [p.AC_CITY, p.AC_PIN].filter(Boolean).join(' '),
        p.AC_MOBILE && `Mob: ${p.AC_MOBILE}`,
      ].filter(Boolean),
      gstin: p.AC_GSTNO,
      state: p.AC_STATE,
    },
    meta,
    body: gstBillBody(h, lines),
    footer: billFooter(
      ctx.company,
      ctx.fallbackName,
      'Certified that the particulars given above are true and correct. Goods once sold will not be taken back or exchanged. Subject to local jurisdiction. E.&O.E.',
    ),
  });
}
