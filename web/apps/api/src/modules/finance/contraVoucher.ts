import { formatDesktopDate } from '@datacare/core';
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
import { gridOfRows } from './contra.js';
import {
  documentCompanyTx,
  requireVoucherDocumentScope,
  voucherKeyParams,
  voucherKeyWhere,
  type VoucherDocumentScope,
} from '../documents/voucherDocument.js';

/**
 * Contra voucher document (G128): a bank↔cash (or inter-account) transfer. The desktop writes a pair of CONTRA_DATA
 * rows per grid row after row 1 (TR_CONTRA.cs:2760-2866) and prints the whole voucher with `ContraBill.rpt`
 * (TR_CONTRA.cs:3021; there is no ContraVch.rpt). Rendered on the shared docShell chrome as the voucher's legs with
 * Dr and Cr columns and totals; the Crystal layout itself is blocked on a text export of the template.
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
      `SELECT c.*, a."RESOLVED_NAME"
         FROM "CONTRA_DATA" c
         LEFT JOIN LATERAL (
           SELECT m."AC_NAME" AS "RESOLVED_NAME"
             FROM "AC_MAST" m
            WHERE m.tenant_id=c.tenant_id AND m."CO_CODE"=c."CO_CODE" AND m."AC_CODE"=c."AC_CODE"
            ORDER BY CASE WHEN m."LC_CODE"::text=c."LC_CODE"::text THEN 0
                          WHEN m."LC_CODE" IS NULL OR btrim(m."LC_CODE"::text)='' THEN 1 ELSE 2 END,
                     m.row_id
            LIMIT 1
         ) a ON true
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
  const h = rows[0] ?? {};
  const names = new Map<string, string>();
  for (const r of rows) {
    const code = String(r.AC_CODE ?? '').trim();
    if (code && !names.has(code)) names.set(code, String(r.RESOLVED_NAME ?? r.AC_NAME ?? code));
  }
  const acName = (code: string) => esc(names.get(code) ?? code);
  // The desktop prints the whole voucher (TR_CONTRA.cs:3026): the main account (row 1) and every grid row with its own
  // Dr or Cr, then the totals. A voucher saved before the grid existed is a single two-account row (gridOfRows).
  const legs = gridOfRows(rows);
  const total = (side: 'DR' | 'CR') =>
    legs.filter((l) => l.crdr === side).reduce((sum, l) => sum + l.amount, 0);
  const amount = total('DR');
  const vchDate = formatDesktopDate(h.VCH_DATE); // N56 (D19): dd/MM/yyyy, always with the year
  const lineRows = legs
    .map(
      (l, i) =>
        `<tr><td class="c">${i + 1}</td><td>${acName(l.acCode)}</td><td>${esc(l.itDesc ?? '')}</td>` +
        `<td class="r">${l.crdr === 'DR' ? money(l.amount) : ''}</td><td class="r">${l.crdr === 'CR' ? money(l.amount) : ''}</td></tr>`,
    )
    .join('');
  const body =
    `<table class="items"><thead><tr><th>Sr</th><th style="width:36%">Account</th><th>Description</th><th class="r">Dr</th><th class="r">Cr</th></tr></thead>` +
    `<tbody>${lineRows}</tbody>` +
    `<tfoot><tr><td class="c" colspan="3">Total</td><td class="r">${money(total('DR'))}</td><td class="r">${money(total('CR'))}</td></tr></tfoot></table>` +
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
 * FineJvBill's page footer (report-specs/FineJvBill.spec.json, PageFooter Section2): `{@for}` =
 * 'For : ' + CO_NAME at the right, the stamp box, then 'Party signature.' at the left and 'signature.' at the
 * right. The report binds no bank field and prints no declaration.
 */
function fineJvFooter(company: any, fallbackName = 'Company'): string {
  const c = company ?? {};
  return (
    `<div class="foot"><div class="bank" style="align-self:flex-end">Party signature.</div>` +
    `<div class="sign"><div class="for">For : ${esc(c.CO_NAME ?? fallbackName)}</div>` +
    `<div>signature.</div></div></div>`
  );
}

export interface FineJvVoucherCtx extends ContraVoucherCtx {
  /** BOOK_DATA.BOOK_NAME of the configured book; `{@RptTitle}` appends it to the metal. */
  bookName?: string;
}

/**
 * Fine JV document (desktop `FineJvBill.RPT`, selected by `TR_CONTRA.BtnPrint_Click` when
 * `FormMainBook = 'FINE JV'`, TR_CONTRA.cs:3021, :3061-3069, for every CONTRA_DATA row of the voucher,
 * :3026/:3069). From the extracted report: the title `{@RptTitle}` is 'Gold ' or 'Silver ' (IT_TYPE 'G' or
 * not) followed by BOOK_DATA.BOOK_NAME; the header carries Vch Date and Vch No; each detail record prints
 * AC_MAST.AC_NAME with CR_FINE and DR_FINE, then its IT_DESC on a second line that is suppressed when blank;
 * there is no total section. `{@InVoiceTipe}` defaults to 'ORIGINAL' (TR_CONTRA sets the copy label only when it
 * prints, :3070-3089) and `{@CurPag}` prints the page number at the top right. The CrFine and DrFine fields are not
 * suppressed, so a zero side prints its value; the extracted spec carries no numeric format, so fines print as 0.000.
 */
export function fineJvVoucherHtml(rows: any[], ctx: FineJvVoucherCtx = {}): string {
  const h = rows[0] ?? {};
  const acName = (row: any) => esc(row?.RESOLVED_NAME ?? row?.AC_NAME ?? row?.AC_CODE ?? '');
  const metal =
    String(h.IT_TYPE ?? '')
      .trim()
      .toUpperCase() === 'G'
      ? 'Gold'
      : 'Silver';
  const lineRows = rows
    .map((row) => {
      const cr = num(row.CR_FINE);
      const dr = num(row.DR_FINE);
      const desc = String(row.IT_DESC ?? '').trim();
      return (
        `<tr><td>${acName(row)}</td><td class="r">${wt(cr)}</td>` +
        `<td class="r">${wt(dr)}</td></tr>` +
        (desc
          ? `<tr><td colspan="3" style="padding-left:28px;color:#595959;font-size:9.5px">${esc(desc)}</td></tr>`
          : '')
      );
    })
    .join('');
  const meta: DocMeta[] = [
    { k: 'Vch Date', v: formatDesktopDate(h.VCH_DATE) },
    { k: 'Vch No', v: String(h.VCH_NO ?? '') },
  ];
  // `{@CurPag}`: the page number in the top-right page margin of every printed page.
  const pageNumber = `<style>@page{@top-right{content:counter(page);font-size:9px}}</style>`;
  const body =
    pageNumber +
    `<table class="items"><thead><tr><th style="width:56%">Party Name</th>` +
    `<th class="r">Cr Fine</th><th class="r">Dr Fine</th></tr></thead>` +
    `<tbody>${lineRows}</tbody></table>`;
  return docShell({
    title: `${metal} ${ctx.bookName ?? 'Fine JV'}`,
    copy: ctx.copy ?? 'ORIGINAL',
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    meta,
    body,
    footer: fineJvFooter(ctx.company, ctx.fallbackName),
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
  const vchDate = formatDesktopDate(h.VCH_DATE); // N56 (D19): dd/MM/yyyy, always with the year

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
