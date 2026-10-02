import { withTxBudget } from '../shared/txBudget.js';
import { docShell, esc, num, money, type DocMeta } from '../documents/docChrome.js';
import { gstr3b, balanceSheet } from './reports.js';
import { trialBalanceFull } from './reports8.js';
import { gstr2Purchase } from './reports3.js';

/** Formatted accounting / statutory statement documents on the shared A4 chrome:
 *  - Trial Balance (per-account net Debit/Credit two-column, totals, balanced check) — TRialBalHz.rpt
 *  - GSTR-3B summary (3.1 outward supplies + tax, 5.1 net payable) — Gstr_3.rpt
 *  - Balance Sheet summary (Liabilities | Assets two-side) — BalanceHz.rpt (derived summary) */

async function companyOf(prisma: any, tenantId: string, coCode: string): Promise<any> {
  const c: any[] = await withTxBudget(prisma, tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(`SELECT * FROM "CO_MAST" WHERE "CO_CODE"=$1 LIMIT 1`, coCode),
  );
  return c[0] ?? null;
}
const stmtFooter = (company: any, fallbackName: string, note: string): string =>
  `<div class="foot"><div class="bank"></div><div class="sign"><div class="for">For ${esc(company?.CO_NAME ?? fallbackName)}</div><div>Authorised Signatory</div></div></div>` +
  `<div class="decl">${esc(note)}</div>`;

// ---- Trial Balance ----
export function trialBalanceDocHtml(
  data: { rows: any[]; totals: any },
  ctx: { company?: any; period?: string; fallbackName?: string } = {},
): string {
  const rows = [...(data.rows ?? [])].sort((a, b) =>
    String(a.acCode).localeCompare(String(b.acCode)),
  );
  let tDr = 0,
    tCr = 0;
  const body = rows
    .map((r, i) => {
      const bal = num(r.balance);
      const dr = bal > 0 ? bal : 0,
        cr = bal < 0 ? -bal : 0;
      tDr += dr;
      tCr += cr;
      return (
        `<tr><td class="c">${i + 1}</td><td>${esc(r.acCode)}</td><td>${esc(r.name ?? r.acCode)}</td>` +
        `<td class="r">${dr ? money(dr) : ''}</td><td class="r">${cr ? money(cr) : ''}</td></tr>`
      );
    })
    .join('');
  const diff = Math.abs(tDr - tCr);
  const table =
    `<table class="items"><thead><tr><th>#</th><th>Code</th><th style="width:44%">Account</th><th>Debit</th><th>Credit</th></tr></thead>` +
    `<tbody>${body || '<tr><td colspan="5" class="c">No ledger balances</td></tr>'}</tbody>` +
    `<tfoot><tr><td class="c" colspan="3">Total (${rows.length} accounts)</td><td class="r">${money(tDr)}</td><td class="r">${money(tCr)}</td></tr></tfoot></table>` +
    `<div class="words"><b>${diff < 0.05 ? '✓ Trial Balance is balanced' : `⚠ Difference: ${money(diff)}`}</b></div>`;
  const meta: DocMeta[] = [
    { k: 'Statement', v: 'Trial Balance' },
    { k: 'Period', v: ctx.period ?? '' },
    { k: 'Accounts', v: String(rows.length) },
  ];
  return docShell({
    title: 'Trial Balance',
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    meta,
    body: table,
    footer: stmtFooter(
      ctx.company,
      ctx.fallbackName ?? 'Company',
      'Trial balance of ledger balances as per books. E.&O.E.',
    ),
  });
}
export async function renderTrialBalanceDoc(
  prisma: any,
  scope: any,
  opts: { period?: string } = {},
): Promise<string> {
  const data = await trialBalanceFull(prisma, scope);
  return trialBalanceDocHtml(data as any, {
    company: await companyOf(prisma, scope.tenantId, scope.coCode),
    period: opts.period,
  });
}

// ---- GSTR-3B ----
export function gstr3bDocHtml(
  d: Record<string, number>,
  ctx: { company?: any; period?: string; fallbackName?: string } = {},
): string {
  const taxable = num(d.outwardTaxable),
    igst = num(d.outwardIGST),
    cgst = num(d.outwardCGST),
    sgst = num(d.outwardSGST);
  const totalTax = round2(igst + cgst + sgst) || num(d.outwardTax);
  const body =
    `<div class="vinfo" style="margin:8px 0 4px;font-size:12px;font-weight:700">3.1 Details of Outward Supplies</div>` +
    `<table class="items"><thead><tr><th style="width:46%">Nature of Supply</th><th>Taxable Value</th><th>IGST</th><th>CGST</th><th>SGST/UTGST</th></tr></thead>` +
    `<tbody><tr><td>(a) Outward taxable supplies (other than zero-rated, nil, exempt)</td>` +
    `<td class="r">${money(taxable)}</td><td class="r">${money(igst)}</td><td class="r">${money(cgst)}</td><td class="r">${money(sgst)}</td></tr></tbody>` +
    `<tfoot><tr><td class="c">Total</td><td class="r">${money(taxable)}</td><td class="r">${money(igst)}</td><td class="r">${money(cgst)}</td><td class="r">${money(sgst)}</td></tr></tfoot></table>` +
    `<div class="lower"><div class="hsn"></div><div class="tot"><table>` +
    `<tr><td>Total Taxable Value</td><td class="r">${money(taxable)}</td></tr>` +
    `<tr class="grand"><td>5.1 Total Tax Payable</td><td class="r">₹ ${money(totalTax)}</td></tr></table></div></div>`;
  const meta: DocMeta[] = [
    { k: 'GSTIN', v: String(ctx.company?.CO_GST_NO ?? '') },
    { k: 'Return', v: 'GSTR-3B' },
    { k: 'Period', v: ctx.period ?? '' },
  ];
  return docShell({
    title: 'GSTR-3B — Summary Return',
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    meta,
    body,
    footer: stmtFooter(
      ctx.company,
      ctx.fallbackName ?? 'Company',
      'Summary of outward supplies + tax from books. Verify against portal before filing. E.&O.E.',
    ),
  });
}
export async function renderGstr3bDoc(
  prisma: any,
  scope: any,
  opts: { period?: string } = {},
): Promise<string> {
  const d = await gstr3b(prisma, scope);
  return gstr3bDocHtml(d as any, {
    company: await companyOf(prisma, scope.tenantId, scope.coCode),
    period: opts.period,
  });
}

// ---- Balance Sheet (summary) ----
export function balanceSheetDocHtml(
  d: Record<string, number | boolean>,
  ctx: { company?: any; period?: string; fallbackName?: string } = {},
): string {
  const dr = num(d.ledgerDr as number),
    cr = num(d.ledgerCr as number);
  const closing = num(d.closingStock as number);
  const totalAssets = num(d.totalAssets as number),
    totalLiab = num(d.totalLiabilities as number);
  const body =
    `<div class="lower" style="gap:14px">` +
    `<div class="hsn"><table><thead><tr><th style="text-align:left">Liabilities</th><th>Amount</th></tr></thead><tbody>` +
    `<tr><td style="text-align:left">Capital & Liabilities (ledger Cr)</td><td>${money(cr)}</td></tr>` +
    `${closing < 0 ? `<tr><td style="text-align:left">Trading / Stock adjustment</td><td>${money(-closing)}</td></tr>` : ''}` +
    `</tbody><tfoot><tr><td style="text-align:left">Total</td><td>${money(totalLiab)}</td></tr></tfoot></table></div>` +
    `<div class="hsn"><table><thead><tr><th style="text-align:left">Assets</th><th>Amount</th></tr></thead><tbody>` +
    `<tr><td style="text-align:left">Assets (ledger Dr)</td><td>${money(dr)}</td></tr>` +
    `${closing > 0 ? `<tr><td style="text-align:left">Closing Stock (derived)</td><td>${money(closing)}</td></tr>` : ''}` +
    `</tbody><tfoot><tr><td style="text-align:left">Total</td><td>${money(totalAssets)}</td></tr></tfoot></table></div></div>` +
    `<div class="words"><b>${d.balanced ? '✓ Balance Sheet is balanced' : '⚠ Not balanced'}</b> &nbsp;<span class="muted">(summary derived from ledger totals; closing stock is the balancing figure)</span></div>`;
  const meta: DocMeta[] = [
    { k: 'Statement', v: 'Balance Sheet' },
    { k: 'Period', v: ctx.period ?? '' },
  ];
  return docShell({
    title: 'Balance Sheet (Summary)',
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    meta,
    body,
    footer: stmtFooter(
      ctx.company,
      ctx.fallbackName ?? 'Company',
      'Summary balance sheet derived from ledger totals. Subject to audit. E.&O.E.',
    ),
  });
}
export async function renderBalanceSheetDoc(
  prisma: any,
  scope: any,
  opts: { period?: string } = {},
): Promise<string> {
  const d = await balanceSheet(prisma, scope);
  return balanceSheetDocHtml(d as any, {
    company: await companyOf(prisma, scope.tenantId, scope.coCode),
    period: opts.period,
  });
}

const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

// ---- GSTR-2 (inward supplies / ITC summary) ----
export function gstr2DocHtml(
  t: Record<string, number>,
  ctx: { company?: any; period?: string; fallbackName?: string } = {},
): string {
  const taxable = num(t.taxable),
    igst = num(t.igst),
    cgst = num(t.cgst),
    sgst = num(t.sgst);
  const itc = round2(igst + cgst + sgst) || num(t.tax);
  const body =
    `<div class="vinfo" style="margin:8px 0 4px;font-size:12px;font-weight:700">3. Inward Supplies (eligible for Input Tax Credit)</div>` +
    `<table class="items"><thead><tr><th style="width:46%">Nature of Supply</th><th>Taxable Value</th><th>IGST</th><th>CGST</th><th>SGST/UTGST</th></tr></thead>` +
    `<tbody><tr><td>(a) Inward supplies (other than reverse charge)</td>` +
    `<td class="r">${money(taxable)}</td><td class="r">${money(igst)}</td><td class="r">${money(cgst)}</td><td class="r">${money(sgst)}</td></tr></tbody>` +
    `<tfoot><tr><td class="c">Total</td><td class="r">${money(taxable)}</td><td class="r">${money(igst)}</td><td class="r">${money(cgst)}</td><td class="r">${money(sgst)}</td></tr></tfoot></table>` +
    `<div class="lower"><div class="hsn"></div><div class="tot"><table>` +
    `<tr><td>Total Taxable Value</td><td class="r">${money(taxable)}</td></tr>` +
    `<tr class="grand"><td>4. Eligible ITC</td><td class="r">₹ ${money(itc)}</td></tr></table></div></div>`;
  const meta: DocMeta[] = [
    { k: 'GSTIN', v: String(ctx.company?.CO_GST_NO ?? '') },
    { k: 'Return', v: 'GSTR-2' },
    { k: 'Period', v: ctx.period ?? '' },
  ];
  return docShell({
    title: 'GSTR-2 — Inward Supplies (ITC)',
    company: ctx.company,
    fallbackName: ctx.fallbackName,
    meta,
    body,
    footer: stmtFooter(
      ctx.company,
      ctx.fallbackName ?? 'Company',
      'Summary of inward supplies + input tax credit from books. Verify against portal before filing. E.&O.E.',
    ),
  });
}
export async function renderGstr2Doc(
  prisma: any,
  scope: any,
  opts: { period?: string } = {},
): Promise<string> {
  const d = await gstr2Purchase(prisma, scope);
  return gstr2DocHtml((d as any).totals ?? {}, {
    company: await companyOf(prisma, scope.tenantId, scope.coCode),
    period: opts.period,
  });
}
