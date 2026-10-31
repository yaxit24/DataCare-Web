import { formatDesktopDate } from '@datacare/core';
import { formatVoucherNo } from '../vouchers/numbering.js';
import { withTxBudget, SNAPSHOT_READ } from '../shared/txBudget.js';
import { resolveBookPolicyTx } from '../shared/bookPolicy.js';
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

/** Sales Order Confirmation / Estimate — SL_ORD_DATA header + SL_ORD_DETL lines. Mirrors desktop
 *  OrderVch.rpt: customer, ordered items (est. weights/rate/making/amount), delivery date, order
 *  value, advance received, old-gold/scheme adjustment, balance due, amount in words. Not a tax bill. */
export interface OrderScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
  vchNo: string | number;
  /** Required by the form-specific print routes; prevents one order form reading another family. */
  family?: 'SALES ORDER' | 'TOUR ORDER';
}

export async function orderData(
  prisma: any,
  s: OrderScope,
): Promise<{ header: any; lines: any[]; company: any; party: any; imagePrint: boolean } | null> {
  // TR_SALE_ORD.cs:9918 selects all five desktop voucher identity fields for printing.
  // A missing year/location must not broaden a document query to another order.
  for (const field of ['tenantId', 'coCode', 'lcCode', 'coYear', 'coBook', 'vchNo'] as const) {
    if (!String(s[field] ?? '').trim()) {
      const error = new Error(`Order confirmation requires ${field}`);
      error.name = 'OrderDocumentValidationError';
      throw error;
    }
  }
  return withTxBudget(prisma, s.tenantId, SNAPSHOT_READ, async (tx: any) => {
    if (s.family) {
      await resolveBookPolicyTx(tx, s, s.family, {
        requireExplicitMainBook: true,
        expectedTable: 'SL_ORD_DATA',
      });
    }
    const params = [s.tenantId, s.coCode, s.lcCode, s.coYear, s.coBook, formatVoucherNo(s.vchNo)];
    const where =
      'tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6';
    const h: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "SL_ORD_DATA" WHERE ${where} LIMIT 1`,
      ...params,
    );
    if (!h.length) return null;
    const header = h[0];
    const lines: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "SL_ORD_DETL" WHERE ${where} ORDER BY "SR_NO"`,
      ...params,
    );
    const co: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
      s.tenantId,
      s.coCode,
    );
    const party: any[] = header.AC_CODE
      ? await tx.$queryRawUnsafe(
          `SELECT * FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4 LIMIT 1`,
          s.tenantId,
          s.coCode,
          s.lcCode,
          header.AC_CODE,
        )
      : [];
    const settings: any[] = lines.length
      ? await tx.$queryRawUnsafe(
          'SELECT "ORD_IMG_PRINT" FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"=$2',
          s.tenantId,
          s.coCode,
        )
      : [];
    const imageFlags = new Set(
      settings.map(
        (row) =>
          String(row.ORD_IMG_PRINT ?? '')
            .trim()
            .toUpperCase() || 'N',
      ),
    );
    if (imageFlags.size > 1) {
      const error = new Error('The company has conflicting order image print settings.');
      error.name = 'OrderDocumentValidationError';
      throw error;
    }
    return {
      header,
      lines,
      company: co[0] ?? null,
      party: party[0] ?? null,
      imagePrint: imageFlags.has('Y'),
    };
  });
}

export interface OrderCtx {
  company?: any;
  party?: any;
  copy?: string;
  fallbackName?: string;
  title?: string;
}
const dt = (v: any): string => formatDesktopDate(v); // N56 (D19): dd/MM/yyyy

export function orderHtml(header: any, lines: any[], ctx: OrderCtx = {}): string {
  const h = header;
  const p = ctx.party ?? {};
  let sPcs = 0,
    sGwt = 0,
    sNwt = 0,
    sMaking = 0,
    sAmt = 0;
  const rows = lines
    .map((l, i) => {
      sPcs += num(l.ITM_PCS) || num(l.ITM_QTY);
      sGwt += num(l.ITM_GWT);
      sNwt += num(l.ITM_NWT);
      sMaking += num(l.LBR_AMT);
      sAmt += num(l.NET_AMT) || num(l.ITM_AMT);
      const desc =
        esc(l.IT_CODE ?? '') +
        (l.DESIGN_NO
          ? `<span class="hu">Design: ${esc(l.DESIGN_NO)}${l.ITM_SIZE ? ' · Size ' + esc(l.ITM_SIZE) : ''}</span>`
          : '') +
        (l.ITM_REMARK ? `<span class="hu">${esc(l.ITM_REMARK)}</span>` : '') +
        (l.ORD_DEL_DATE ? `<span class="hu">Delivery: ${esc(dt(l.ORD_DEL_DATE))}</span>` : '');
      return (
        `<tr><td class="c">${i + 1}</td><td>${desc}</td><td class="r">${num(l.ITM_PCS) || num(l.ITM_QTY) || ''}</td>` +
        `<td class="r">${wt(l.ITM_GWT)}</td><td class="r">${wt(l.ITM_NWT)}</td><td class="r">${num(l.ITM_TOUCH) || ''}</td>` +
        `<td class="r">${money(l.ITM_RATE)}</td><td class="r">${money(l.LBR_AMT)}</td><td class="r">${money(num(l.NET_AMT) || num(l.ITM_AMT))}</td></tr>`
      );
    })
    .join('');
  const itemsTable =
    `<table class="items"><thead><tr><th>#</th><th style="width:30%">Item / Design</th><th>Pcs</th><th>Est. Gross</th><th>Est. Net</th><th>Touch%</th><th>Rate</th><th>Making</th><th>Amount</th></tr></thead>` +
    `<tbody>${rows || '<tr><td colspan="9" class="c">No ordered items</td></tr>'}</tbody>` +
    `<tfoot><tr><td class="c" colspan="2">Total</td><td class="r">${sPcs || ''}</td><td class="r">${wt(sGwt)}</td><td class="r">${wt(sNwt)}</td><td></td><td></td><td class="r">${money(sMaking)}</td><td class="r">${money(sAmt)}</td></tr></tfoot></table>`;

  const total = num(h.TOT_AMT) || num(h.NET_AMT) + num(h.TAX_AMT);
  const adv = num(h.ADV_AMT);
  const oldGold = num(h.OLD_GL_AMT) + num(h.OLD_SL_AMT);
  const balance = total - adv - oldGold - num(h.SCHM_AMT);
  const t: string[] = [`<tr><td>Order Value</td><td class="r">${money(total)}</td></tr>`];
  if (adv > 0) t.push(`<tr><td>Advance Received</td><td class="r">-${money(adv)}</td></tr>`);
  if (oldGold > 0)
    t.push(`<tr><td>Old Gold / Metal Adj</td><td class="r">-${money(oldGold)}</td></tr>`);
  if (num(h.SCHM_AMT) > 0)
    t.push(`<tr><td>Scheme Adjustment</td><td class="r">-${money(h.SCHM_AMT)}</td></tr>`);
  t.push(
    `<tr class="grand"><td>Balance Due on Delivery</td><td class="r">₹ ${money(balance)}</td></tr>`,
  );
  const delBox =
    `<div class="hsn"><div style="border:1px solid #94a3b8;border-radius:4px;padding:6px 8px;font-size:11px">` +
    `<b>Expected Delivery:</b> ${esc(dt(h.DEL_DATE)) || '—'}${h.VCH_DESC ? `<br/><b>Note:</b> ${esc(h.VCH_DESC)}` : ''}</div></div>`;
  const lower =
    `<div class="lower">${delBox}<div class="tot"><table>${t.join('')}</table></div></div>` +
    `<div class="words"><b>Amount in words:</b> ${esc(rupeesInWords(total))} only.</div>`;

  const mob = h.MOBILE ?? p.AC_MOBILE;
  const meta: DocMeta[] = [
    { k: 'Order No', v: String(h.BILL_NO ?? h.VCH_NO ?? '') },
    { k: 'Order Date', v: dt(h.VCH_DATE) },
    { k: 'Delivery Date', v: dt(h.DEL_DATE) },
    { k: 'Book / Vch', v: `${h.CO_BOOK ?? ''} / ${h.VCH_NO ?? ''}` },
  ];
  return docShell({
    title: ctx.title ?? 'Sales Order Confirmation',
    copy: ctx.copy,
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    billTo: {
      cap: 'Customer',
      name: p.AC_NAME ?? h.AC_NAME ?? h.AC_CODE,
      addr: [h.ADD1 ?? p.AC_ADD1, h.CITY ?? p.AC_CITY, mob && `Mob: ${mob}`].filter(Boolean),
    },
    meta,
    body: itemsTable + lower,
    footer: billFooter(
      ctx.company,
      ctx.fallbackName,
      'Order confirmed as per particulars above. Weights/amounts are estimates; final on delivery. Advance non-refundable on custom orders. E.&O.E.',
    ),
  });
}
