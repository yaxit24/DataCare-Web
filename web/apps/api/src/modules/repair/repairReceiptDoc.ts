import { withTenant } from '@datacare/db';
import { billFooter, docShell, esc, money, num, wt, type DocMeta } from '../documents/docChrome.js';
import { getCustomerRepairReceipt, type CustomerRepairReceiptView } from './repairReceipt.js';
import type { VoucherScope } from '../vouchers/numbering.js';

export async function customerRepairReceiptDocumentData(
  prisma: any,
  scope: VoucherScope,
  vchNo: string | number,
): Promise<{ receipt: CustomerRepairReceiptView; company: any; party: any } | null> {
  const receipt = await getCustomerRepairReceipt(prisma, scope, vchNo);
  if (!receipt) return null;
  const context = await withTenant(prisma, scope.tenantId, async (tx: any) => {
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

/** Engineering print binding for ReparingRec data; objective Crystal pixel comparison remains open. */
export function customerRepairReceiptHtml(
  receipt: CustomerRepairReceiptView,
  context: { company?: any; party?: any; copy?: string } = {},
): string {
  let pieces = 0;
  let gross = 0;
  let net = 0;
  let labour = 0;
  let other = 0;
  const rows = receipt.lines
    .map((line) => {
      pieces += num(line.pcs);
      gross += num(line.grossWt);
      net += num(line.netWt);
      labour += num(line.labourAmount);
      other += num(line.otherAmount);
      const item = `${esc(line.itemName || line.itCode)}${line.itmSize ? `<span class="hu">Size: ${esc(line.itmSize)}</span>` : ''}${line.description ? `<span class="hu">${esc(line.description)}</span>` : ''}`;
      return `<tr><td class="c">${line.srNo}</td><td>${item}</td><td class="r">${num(line.pcs) || ''}</td><td class="r">${wt(line.grossWt)}</td><td class="r">${wt(line.otherWt)}</td><td class="r">${wt(line.netWt)}</td><td class="r">${num(line.touch) || ''}</td><td class="r">${money(line.labourAmount)}</td><td class="r">${money(line.otherAmount)}</td><td class="r">${money(line.netAmount)}</td></tr>`;
    })
    .join('');
  const table = `<table class="items"><thead><tr><th>#</th><th style="width:30%">Repair item / description</th><th>Pcs</th><th>Gross</th><th>Other Wt</th><th>Net</th><th>Touch%</th><th>Labour</th><th>Other</th><th>Net Amt</th></tr></thead><tbody>${rows || '<tr><td colspan="10" class="c">No repair items</td></tr>'}</tbody><tfoot><tr><td colspan="2" class="c">Total</td><td class="r">${pieces || ''}</td><td class="r">${wt(gross)}</td><td></td><td class="r">${wt(net)}</td><td></td><td class="r">${money(labour)}</td><td class="r">${money(other)}</td><td class="r">${money(receipt.totals.netAmount)}</td></tr></tfoot></table>`;

  const settlement = `<div class="lower"><div class="hsn"><b>Repair receipt / narration</b><div>${esc(receipt.description || '—')}</div></div><div class="tot"><table><tr><td>Estimate / Net Amount</td><td class="r">${money(receipt.totals.netAmount)}</td></tr><tr><td>Cheque Received</td><td class="r">${money(receipt.chequeAmount)}</td></tr><tr><td>Card Received</td><td class="r">${money(receipt.cardAmount)}</td></tr><tr><td>Cash Received</td><td class="r">${money(receipt.cashAmount)}</td></tr><tr class="grand"><td>Outstanding</td><td class="r">${money(receipt.totals.outstandingAmount)}</td></tr></table></div></div>`;

  const party = context.party ?? {};
  const meta: DocMeta[] = [
    { k: 'Voucher No', v: receipt.voucherNo },
    { k: 'Date', v: receipt.vchDate },
    { k: 'Customer Ref', v: receipt.billNo || '—' },
    { k: 'Employee', v: receipt.employeeCode || '—' },
  ];
  return docShell({
    title: 'Repairing Received',
    copy: context.copy,
    company: context.company,
    billTo: {
      cap: 'Received From',
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
      'Item received for repair as described above. Please retain this receipt for delivery.',
    ),
  });
}
