import type { CashBankResult } from './cashBankReport.js';

/**
 * Cash Bank report print (desktop RP_CASH_BANK, Crystal layout AcLedger) as one html document, built from the same
 * resolver result as the screen so print and screen cannot disagree. Pure function: every inserted string is escaped,
 * no script, no external resource.
 *
 * RP_CASH_BANK.cs:3570 {{DC_Main.RptName = "AcLedger";}}
 *
 * Headings and captions used, each from extraction_output/rpt_xml/AcLedger.xml:
 *   :452 Debit Rs · :465 Credit Rs · :478 Ac Name · :511 Balance (page header)
 *   :581 Opening Balance : (group header) · :836 Transaction Total : · :917 Closing Balance : (group footer)
 * MISSING: the template's book, voucher and date column headings were not in the read range (lines 440-520 hold only
 * the four above), so the detail rows are printed without extra column headings of my own.
 * Decided questions still open (cases.md print.balance-zero-side, print.balance-column-format): a zero balance has a
 * blank side (as the grid), and the balance is printed as an absolute value with two decimals and the side label.
 */
const esc = (v: unknown): string =>
  String(v ?? '')
    .replace(/&/g, '&amp;')
    .replace(/</g, '&lt;')
    .replace(/>/g, '&gt;')
    .replace(/"/g, '&quot;')
    .replace(/'/g, '&#39;');

const money = (n: number): string => (Number.isFinite(n) ? n : 0).toFixed(2);

/** dd/MM/yyyy from an ISO date (RP_CASH_BANK.cs:3563 {{"dd/MM/yyyy"}}). */
const ddmmyyyy = (iso: string): string =>
  iso ? `${iso.slice(8, 10)}/${iso.slice(5, 7)}/${iso.slice(0, 4)}` : '';

export function cashBankPrintHtml(
  result: CashBankResult,
  opts: { company: string; coYear: string },
): string {
  // RP_CASH_BANK.cs:3563 {{DC_Main.MsRptTitelStr = "'Cash and Bank Report From "}}
  const title = `Cash and Bank Report From ${ddmmyyyy(result.from)} To ${ddmmyyyy(result.to)}`;
  const opening = result.rows.find((r) => r.kind === 'opening');
  // AcLedger.xml:285 {{NumberVar AcBal := {@AcOpAmt} ;}}: the opening is signed, Cr positive.
  const openingSigned = opening ? opening.crAmt - opening.drAmt : 0;
  const details = result.rows.filter((r) => r.kind === 'detail');
  const account = result.account ? `${result.account.acCode} ${result.account.acName}` : '';
  const t = result.totals;

  const body = details
    .map(
      (r) =>
        `<tr><td>${esc(ddmmyyyy(r.vchDate))}</td><td>${esc(r.book)}</td><td>${esc(r.vchNo)}</td>` +
        `<td>${esc(r.party)}</td><td class="n">${money(r.drAmt)}</td><td class="n">${money(r.crAmt)}</td>` +
        `<td class="n">${money(r.balAmt)} ${esc(r.side)}</td></tr>`,
    )
    .join('');

  return (
    `<!doctype html><html><head><meta charset="utf-8"><title>${esc(title)}</title>` +
    `<style>@page{size:A4 landscape;margin:12mm}body{font:11px Arial,sans-serif;color:#000}` +
    `h1{font-size:15px;margin:0}h2{font-size:12px;margin:2px 0 8px}table{border-collapse:collapse;width:100%}` +
    `th{color:#000080;text-align:left;border-top:1px solid #000;border-bottom:1px solid #000;padding:3px 4px}` +
    `td{padding:2px 4px}.n{text-align:right}th.n{text-align:right}tfoot td{border-top:1px solid #000;font-weight:bold}` +
    `</style></head><body>` +
    `<h1>${esc(opts.company)}</h1><h2>${esc(title)}${opts.coYear ? ` &middot; ${esc(opts.coYear)}` : ''}</h2>` +
    `<div>${esc(account)}</div>` +
    `<table><thead><tr><th>Date</th><th>Book</th><th>Vch No</th>` +
    // AcLedger.xml:478 {{<Text>Ac Name</Text>}}, :452 {{<Text>Debit Rs</Text>}}, :465 {{<Text>Credit Rs</Text>}}, :511 {{<Text>Balance</Text>}}
    `<th>Ac Name</th><th class="n">Debit Rs</th><th class="n">Credit Rs</th><th class="n">Balance</th></tr></thead>` +
    `<tbody><tr><td colspan="3"><b>Opening Balance :</b></td><td class="n" colspan="4">${money(openingSigned)}</td></tr>` + // AcLedger.xml:581
    body +
    `</tbody>` +
    (t
      ? `<tfoot>` +
        // AcLedger.xml:836 {{<Text>Transaction Total :</Text>}}; the kernel totals already include the opening.
        `<tr><td colspan="4">Transaction Total :</td><td class="n">${money(t.drAmt)}</td><td class="n">${money(t.crAmt)}</td><td></td></tr>` +
        // AcLedger.xml:917 {{<Text>Closing Balance :</Text>}}; AcLedger.xml:350 gives the side.
        `<tr><td colspan="6">Closing Balance :</td><td class="n">${money(t.balAmt)} ${esc(t.side)}</td></tr>` +
        `</tfoot>`
      : '') +
    `</table></body></html>`
  );
}
