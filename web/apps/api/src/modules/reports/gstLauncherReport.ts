import type { ReportScope } from './reports.js';

export interface GstLauncherRow {
  srNo: number;
  desktopButton: string;
  webReport: string;
  route: string;
  basis: string;
}

/** Desktop `RP_TAX` launcher: maps its GST buttons to the implemented web statutory/tax reports. */
export async function gstLauncherReport(
  _prisma: any,
  _s: ReportScope,
): Promise<{ rows: GstLauncherRow[] }> {
  return {
    rows: [
      {
        srNo: 1,
        desktopButton: 'OutPut Tax (Sale)',
        webReport: 'Sales GST (Monthly)',
        route: '/reports/sales-gst-monthly',
        basis: 'sales tax output by period',
      },
      {
        srNo: 2,
        desktopButton: 'InPut Tax (Purc)',
        webReport: 'GST Input Register / GSTR-2',
        route: '/reports/gst-input-register and /reports/gstr2',
        basis: 'purchase input tax by period',
      },
      {
        srNo: 3,
        desktopButton: 'Sales Tax',
        webReport: 'GSTR-1',
        route: '/reports/gstr1',
        basis: 'sales tax return output',
      },
      {
        srNo: 4,
        desktopButton: 'Purchase Tax',
        webReport: 'GSTR-2 (Purchase)',
        route: '/reports/gstr2',
        basis: 'purchase tax return input',
      },
      {
        srNo: 5,
        desktopButton: 'Tax (Summ)',
        webReport: 'HSN Tax Summary',
        route: '/reports/hsn-summary',
        basis: 'tax summary grouped by HSN/tax',
      },
      {
        srNo: 6,
        desktopButton: 'In Out Tax',
        webReport: 'GSTR-3B',
        route: '/reports/gstr3b',
        basis: 'input/output tax summary',
      },
    ],
  };
}
