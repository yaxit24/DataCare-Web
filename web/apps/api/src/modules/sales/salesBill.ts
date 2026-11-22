import { salePartyBalancesTx } from './salePrintChoice.js';
import { formatDesktopDate } from '@datacare/core';
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
  opts: { balances?: boolean } = {},
): Promise<{ header: any; lines: any[]; company: any; party: any; balances?: { opAmt: number; clAmt: number } } | null> {
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
    // WP-26: OpAmt/ClAmt of the party at the voucher time (TR_SALE.cs:16259-16261, :16505-16506).
    const at = header.VCH_TIME instanceof Date ? header.VCH_TIME : new Date(header.VCH_DATE);
    const balances = opts.balances ? await salePartyBalancesTx(tx, s as any, String(header.AC_CODE), at) : undefined;
    return { header, lines, company, party, balances };
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
  /** WP-26: the party's opening/closing balance the desktop passes as OpAmt/ClAmt. */
  balances?: { opAmt: number; clAmt: number };
}

export function salesBillHtml(header: any, lines: any[], ctx: SalesBillCtx = {}): string {
  const h = header;
  const p = ctx.party ?? {};
  const vchDate = formatDesktopDate(h.VCH_DATE); // N56 (D19): dd/MM/yyyy, always with the year
  const meta: DocMeta[] = [
    { k: 'Bill No', v: String(h.BILL_NO ?? h.VCH_NO ?? '') },
    { k: 'Date', v: vchDate },
    { k: 'Book / Vch', v: `${h.CO_BOOK ?? ''} / ${h.VCH_NO ?? ''}` },
    ...(ctx.balances
      ? [
          { k: 'Opening Bal', v: ctx.balances.opAmt.toFixed(2) },
          { k: 'Closing Bal', v: ctx.balances.clAmt.toFixed(2) },
        ]
      : []),
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
