import { withTxBudget } from '../shared/txBudget.js';
import { billFooter, docShell, esc, money, num, wt, type DocMeta } from '../documents/docChrome.js';
import { getKarigarRepairReceipt, type KarigarRepairReceiptView } from './repairKarigarReceipt.js';
import type { VoucherScope } from '../vouchers/numbering.js';

export async function karigarRepairReceiptDocumentData(
  prisma: any,
  scope: VoucherScope,
  vchNo: string | number,
): Promise<{ receipt: KarigarRepairReceiptView; company: any; party: any } | null> {
  const receipt = await getKarigarRepairReceipt(prisma, scope, vchNo);
  if (!receipt) return null;
  const context = await withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const companies: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
    );
    const parties: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      receipt.acCode,
    );
    return { company: companies[0] ?? null, party: parties[0] ?? null };
  });
  return { receipt, ...context };
}

/** Engineering print binding for desktop ReparingKrRec data; Crystal pixel comparison remains open. */
export function karigarRepairReceiptHtml(
  receipt: KarigarRepairReceiptView,
  context: { company?: any; party?: any; copy?: string } = {},
): string {
  let pieces = 0;
  let gross = 0;
  let net = 0;
  let fine = 0;
  let labour = 0;
  const rows = receipt.lines
    .map((line) => {
      pieces += num(line.pieces);
      gross += num(line.grossWt);
      net += num(line.netWt);
      fine += num(line.fineWt);
      labour += num(line.labourAmount);
      const item = `${esc(line.itemName || line.itCode)}${line.itmSize ? `<span class="hu">Size: ${esc(line.itmSize)}</span>` : ''}${line.description ? `<span class="hu">${esc(line.description)}</span>` : ''}`;
      const source = `${esc(line.voucherNo)}/${line.srNo}<span class="hu">${esc(line.vchDate)}</span>`;
      const customer = `${esc(line.customerName || line.customerCode)}${line.customerRepairNo ? `<span class="hu">Cust. repair ${esc(line.customerRepairNo)}</span>` : ''}`;
      return `<tr><td class="c">${line.receiptSrNo}</td><td>${source}</td><td>${customer}</td><td>${item}</td><td class="r">${num(line.pieces) || ''}</td><td class="r">${wt(line.grossWt)}</td><td class="r">${wt(line.netWt)}</td><td class="r">${wt(line.fineWt)}</td><td class="r">${money(line.itemAmount)}</td><td class="r">${money(line.labourAmount)}</td><td class="r">${money(line.netAmount)}</td></tr>`;
    })
    .join('');
  const table = `<table class="items"><thead><tr><th>#</th><th>Karigar issue</th><th>Customer</th><th style="width:22%">Repair item / description</th><th>Pcs</th><th>Gross</th><th>Net</th><th>Fine</th><th>Item Amt</th><th>Labour</th><th>Net Amt</th></tr></thead><tbody>${rows || '<tr><td colspan="11" class="c">No repair items</td></tr>'}</tbody><tfoot><tr><td colspan="4" class="c">Total received</td><td class="r">${pieces || ''}</td><td class="r">${wt(gross)}</td><td class="r">${wt(net)}</td><td class="r">${wt(fine)}</td><td></td><td class="r">${money(labour)}</td><td class="r">${money(receipt.totals.netAmount)}</td></tr></tfoot></table>`;

  const settlement = `<div class="lower"><div class="hsn"><b>Narration</b><div>${esc(receipt.description || '—')}</div></div><div class="tot"><table><tr><td>Net Amount</td><td class="r">${money(receipt.totals.netAmount)}</td></tr><tr><td>Discount${receipt.discountPct ? ` (${num(receipt.discountPct)}% on labour)` : ''}</td><td class="r">${money(receipt.totals.discountAmount)}</td></tr><tr><td>Tax${receipt.taxPct ? ` (${num(receipt.taxPct)}%)` : ''}</td><td class="r">${money(receipt.totals.taxAmount)}</td></tr><tr class="sub"><td>Total</td><td class="r">${money(receipt.totals.totalAmount)}</td></tr><tr><td>Cheque Paid</td><td class="r">${money(receipt.chequeAmount)}</td></tr><tr><td>Card Paid</td><td class="r">${money(receipt.cardAmount)}</td></tr><tr><td>Cash Paid</td><td class="r">${money(receipt.cashAmount)}</td></tr><tr><td>Kasar</td><td class="r">${money(receipt.kasarAmount)}</td></tr><tr class="grand"><td>Outstanding</td><td class="r">${money(receipt.totals.outstandingAmount)}</td></tr></table></div></div>`;

  const party = context.party ?? {};
  const meta: DocMeta[] = [
    { k: 'Voucher No', v: receipt.voucherNo },
    { k: 'Date', v: receipt.vchDate },
    { k: 'Reference', v: receipt.billNo || '—' },
    { k: 'Employee', v: receipt.employeeCode || '—' },
  ];
  return docShell({
    title: 'Repairing Received — Karigar',
    copy: context.copy,
    company: context.company,
    billTo: {
      cap: 'Received From Karigar',
      name: receipt.acName || receipt.acCode,
      addr: [
        party.AC_ADD1,
        party.AC_ADD2,
        party.AC_CITY,
        party.AC_MOBILE && `Mob: ${party.AC_MOBILE}`,
      ].filter(Boolean),
    },
    meta,
    body: table + settlement,
    footer: billFooter(
      context.company,
      undefined,
      'Repaired items received back from the karigar against the karigar issue rows listed above.',
    ),
  });
}
