import { formatVoucherNo } from '../vouchers/numbering.js';
import { withTenant } from '@datacare/db';
import { docShell, num, gstBillBody, billFooter, type DocMeta } from '../documents/docChrome.js';

/** Purchase-bill document: PR_DATA header + PR_DETL lines (joined CO_MAST seller + AC_MAST supplier +
 *  ITEM/GROUP HSN), rendered on the shared A4 GST-bill body — mirroring desktop PurcBillA4Gst.rpt. */
export interface PurchaseBillScope {
  tenantId: string;
  coCode: string;
  coYear?: string;
  coBook: string;
  vchNo: string | number;
}

export async function purchaseBillData(
  prisma: any,
  s: PurchaseBillScope,
): Promise<{ header: any; lines: any[]; company: any; party: any } | null> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const params = s.coYear
      ? [s.coCode, s.coBook, formatVoucherNo(s.vchNo), s.coYear]
      : [s.coCode, s.coBook, formatVoucherNo(s.vchNo)];
    const h: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "PR_DATA" WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3${s.coYear ? ' AND "CO_YEAR"=$4' : ''} LIMIT 1`,
      ...params,
    );
    if (!h.length) return null;
    const header = h[0];
    const lines: any[] = await tx.$queryRawUnsafe(
      `SELECT d.*, COALESCE(NULLIF(i."HSN_CODE",''), g."HSN_CODE") AS "HSN_CODE"
         FROM "PR_DETL" d
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

export interface PurchaseBillCtx {
  company?: any;
  party?: any;
  copy?: string;
  fallbackName?: string;
}

export function purchaseBillHtml(header: any, lines: any[], ctx: PurchaseBillCtx = {}): string {
  const h = header;
  const p = ctx.party ?? {};
  const vchDate = h.VCH_DATE ? String(h.VCH_DATE).slice(0, 10) : '';
  const meta: DocMeta[] = [
    { k: 'Bill No', v: String(h.BILL_NO ?? h.VCH_NO ?? '') },
    { k: 'Date', v: vchDate },
    { k: 'Book / Vch', v: `${h.CO_BOOK ?? ''} / ${h.VCH_NO ?? ''}` },
  ];
  if (h.SL_BILL_NO) meta.push({ k: 'Supplier Bill', v: String(h.SL_BILL_NO) });

  const mob = h.MOBILE ?? p.AC_MOBILE;
  return docShell({
    title: 'Purchase Bill',
    copy: ctx.copy,
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    billTo: {
      cap: 'Supplier',
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
      'Purchase bill — goods received as per particulars above. Subject to verification. E.&O.E.',
    ),
  });
}
