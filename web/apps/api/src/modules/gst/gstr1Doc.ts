import { docShell, esc, num, money, type DocMeta } from '../documents/docChrome.js';
import { withTenant } from '@datacare/db';
import { gstr1, type Gstr1, type GstScope } from './gst.js';

/** GSTR-1 statutory return document — renders the outward-supply sections from the existing gstr1()
 *  dataset in the filing layout: 4A/4B B2B (registered), 5 B2CL (large inter-state), 7 B2CS (small,
 *  state+rate), 12 HSN-wise summary, and a consolidated tax liability total. Mirrors desktop Gstr_1.rpt. */
export interface Gstr1DocCtx {
  company?: any;
  period?: string;
  fallbackName?: string;
}

function tbl(title: string, headers: string[], rows: string[], note?: string): string {
  return (
    `<div class="vinfo" style="margin:10px 0 4px;font-size:12px;font-weight:700">${esc(title)}${note ? ` <span class="muted" style="font-weight:400">${esc(note)}</span>` : ''}</div>` +
    `<table class="items"><thead><tr>${headers.map((h, i) => `<th${i === 0 ? '' : ' class="r"'}>${esc(h)}</th>`).join('')}</tr></thead>` +
    `<tbody>${rows.join('') || `<tr><td colspan="${headers.length}" class="c">— none —</td></tr>`}</tbody></table>`
  );
}

export function gstr1DocHtml(data: Gstr1, ctx: Gstr1DocCtx = {}): string {
  const b2b = data.b2b ?? [],
    b2cl = data.b2cl ?? [],
    b2cs = data.b2cs ?? [],
    hsn = data.hsn ?? [];
  const tax = (r: any) => num(r.igst) + num(r.cgst) + num(r.sgst);

  const b2bRows = b2b.map(
    (r: any) =>
      `<tr><td>${esc(r.gstin ?? '')}</td><td class="r">${esc(r.vchNo)}</td>` +
      `<td class="r">${num(r.ratePct)}%</td><td class="r">${money(r.taxable)}</td><td class="r">${money(r.igst)}</td>` +
      `<td class="r">${money(r.cgst)}</td><td class="r">${money(r.sgst)}</td><td class="r">${money(r.invoiceValue)}</td></tr>`,
  );
  const b2clRows = b2cl.map(
    (r: any) =>
      `<tr><td>${esc(r.stateCode ?? '')}</td><td class="r">${esc(r.vchNo)}</td>` +
      `<td class="r">${num(r.ratePct)}%</td><td class="r">${money(r.taxable)}</td><td class="r">${money(r.igst)}</td><td class="r">${money(r.invoiceValue)}</td></tr>`,
  );
  const b2csRows = b2cs.map(
    (r: any) =>
      `<tr><td>${esc(r.stateCode || '—')}</td><td class="r">${num(r.ratePct)}%</td>` +
      `<td class="r">${money(r.taxable)}</td><td class="r">${money(r.igst)}</td><td class="r">${money(r.cgst)}</td><td class="r">${money(r.sgst)}</td></tr>`,
  );
  const hsnRows = hsn.map(
    (r: any) =>
      `<tr><td>${esc(r.hsn)}</td><td class="r">${num(r.qty)}</td>` +
      `<td class="r">${money(r.taxable)}</td><td class="r">${money(r.igst)}</td><td class="r">${money(r.cgst)}</td><td class="r">${money(r.sgst)}</td></tr>`,
  );

  // consolidated liability (B2B + B2CL + B2CS)
  const all = [...b2b, ...b2cl, ...b2cs];
  const tot = all.reduce(
    (a: any, r: any) => ({
      taxable: a.taxable + num(r.taxable),
      igst: a.igst + num(r.igst),
      cgst: a.cgst + num(r.cgst),
      sgst: a.sgst + num(r.sgst),
    }),
    { taxable: 0, igst: 0, cgst: 0, sgst: 0 },
  );
  const totBox =
    `<div class="lower"><div class="hsn"></div><div class="tot"><table>` +
    `<tr><td>Total Taxable</td><td class="r">${money(tot.taxable)}</td></tr>` +
    `<tr class="sub"><td>IGST</td><td class="r">${money(tot.igst)}</td></tr>` +
    `<tr><td>CGST</td><td class="r">${money(tot.cgst)}</td></tr>` +
    `<tr><td>SGST</td><td class="r">${money(tot.sgst)}</td></tr>` +
    `<tr class="grand"><td>Total Tax Liability</td><td class="r">₹ ${money(tot.igst + tot.cgst + tot.sgst)}</td></tr>` +
    `</table></div></div>`;

  const body =
    tbl(
      '4. B2B — Supplies to Registered Persons',
      ['Recipient GSTIN', 'Invoice', 'Rate', 'Taxable', 'IGST', 'CGST', 'SGST', 'Value'],
      b2bRows,
      `${b2b.length} invoice(s)`,
    ) +
    tbl(
      '5. B2CL — Large Inter-State (Unregistered)',
      ['State', 'Invoice', 'Rate', 'Taxable', 'IGST', 'Value'],
      b2clRows,
      `${b2cl.length} invoice(s)`,
    ) +
    tbl(
      '7. B2CS — Others (state + rate)',
      ['State', 'Rate', 'Taxable', 'IGST', 'CGST', 'SGST'],
      b2csRows,
    ) +
    tbl(
      '12. HSN-wise Summary of Outward Supplies',
      ['HSN', 'Qty', 'Taxable', 'IGST', 'CGST', 'SGST'],
      hsnRows,
      `${hsn.length} HSN`,
    ) +
    totBox;

  const meta: DocMeta[] = [
    { k: 'GSTIN', v: String(ctx.company?.CO_GST_NO ?? '') },
    { k: 'Return', v: 'GSTR-1' },
    { k: 'Period', v: ctx.period ?? '' },
  ];
  return docShell({
    title: 'GSTR-1 — Outward Supplies',
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    meta,
    body,
    footer:
      `<div class="foot"><div class="bank"></div><div class="sign"><div class="for">For ${esc(ctx.company?.CO_NAME ?? ctx.fallbackName ?? 'Company')}</div><div>Authorised Signatory</div></div></div>` +
      `<div class="decl">Summary statement of outward supplies generated from books. Verify against GST portal before filing. E.&O.E.</div>`,
  });
}

/** Fetch the gstr1 dataset + company and render the statutory document (route convenience). */
export async function renderGstr1Doc(
  prisma: any,
  scope: GstScope,
  opts: { threshold?: number; period?: string } = {},
): Promise<string> {
  const data = await gstr1(prisma, scope, { threshold: opts.threshold });
  const co: any[] = await withTenant(prisma, scope.tenantId, (tx: any) =>
    tx.$queryRawUnsafe(`SELECT * FROM "CO_MAST" WHERE "CO_CODE"=$1 LIMIT 1`, scope.coCode),
  );
  return gstr1DocHtml(data, { company: co[0] ?? null, period: opts.period });
}
