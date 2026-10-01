import { billFooter, docShell } from '../documents/docChrome.js';

const esc = (value: unknown): string =>
  String(value ?? '').replace(
    /[&<>\"]/g,
    (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;' })[c]!,
  );
const n = (value: unknown): number => Number(value ?? 0) || 0;
const wt = (value: unknown): string => n(value).toFixed(3);
const money = (value: unknown): string =>
  n(value).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });

const grid = (caption: string, lines: any[]): string => {
  const rows = lines
    .map(
      (line, index) => `<tr>
        <td>${index + 1}</td><td>${esc(line.itCode)}</td><td>${esc(line.itemName)}</td><td>${esc(line.tagNo)}</td>
        <td class="r">${n(line.pcs) || ''}</td><td class="r">${wt(line.grossWt)}</td><td class="r">${wt(line.netWt)}</td>
        <td class="r">${wt(line.touch)}</td><td class="r">${wt(line.fine)}</td><td class="r">${money(line.rate)}</td>
        <td class="r">${money(line.lbrAmt)}</td><td class="r">${money(line.totalAmount ?? line.netAmt)}</td>
      </tr>`,
    )
    .join('');
  return `<h3 style="margin:12px 0 4px">${esc(caption)}</h3><table class="items"><thead><tr>
    <th>#</th><th>Item</th><th>Description</th><th>Tag</th><th>Pcs</th><th>Gross</th><th>Net</th>
    <th>Touch</th><th>Fine</th><th>Rate</th><th>Labour</th><th>Amount</th>
  </tr></thead><tbody>${rows || '<tr><td colspan="12" style="text-align:center">No lines</td></tr>'}</tbody></table>`;
};

/** Printable in-memory projection for desktop WhQuotation.RPT (artifact absent from the supplied reports). */
export function wholesaleQuotationHtml(
  voucher: any,
  context: { company?: any; party?: any; copy?: string } = {},
): string {
  const party = context.party ?? {};
  const body =
    grid('Items Offered', voucher.lines ?? []) +
    grid('Items / Metal Received', voucher.receivedLines ?? []) +
    `<div class="lower"><div></div><div class="tot"><table>
      <tr><td>Quoted Net</td><td class="r">${money(voucher.netAmt)}</td></tr>
      <tr><td>Fine Rate</td><td class="r">${money(voucher.fineRate)}</td></tr>
      <tr class="grand"><td>Quotation Value</td><td class="r">₹ ${money(voucher.netAmt)}</td></tr>
    </table></div></div>`;
  return docShell({
    title: 'Wholesale Quotation',
    copy: context.copy,
    company: context.company,
    fallbackName: 'Company',
    billTo: {
      cap: 'Party',
      name: String(party.AC_NAME ?? voucher.acName ?? voucher.acCode ?? ''),
      addr: [voucher.add1, voucher.add2, voucher.add3, voucher.city].filter(Boolean),
      extra: voucher.mobile ? [`Mobile: ${voucher.mobile}`] : [],
    },
    meta: [
      { k: 'Quotation No', v: String(voucher.voucherNo ?? '') },
      { k: 'Date', v: String(voucher.vchDate ?? '') },
      { k: 'Reference', v: String(voucher.billNo ?? '') },
      { k: 'Metal', v: voucher.itType === 'S' ? 'Silver' : 'Gold' },
    ],
    body,
    footer: billFooter(
      context.company,
      'Company',
      'Quotation only — subject to confirmation and rate finalisation. No stock or ledger movement.',
    ),
  });
}
