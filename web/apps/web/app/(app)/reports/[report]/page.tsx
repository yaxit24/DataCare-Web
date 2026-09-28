'use client';
import { useCallback, useEffect, useRef, useState } from 'react';
import { useParams } from 'next/navigation';
import { get, post, downloadPdf, downloadCsv, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';

const TITLES: Record<string, string> = {
  'last-visit': 'Last Visit',
  'address-print': 'Address Print',
  'entry-check': 'Entry Check',
  'user-report': 'User Report',
  'dhiran-report': 'Dhiran Report',
  'loan-report': 'Loan Report',
  'gst-report': 'GST Report',
  'delete-data': 'Delete Data',
  'point-report': 'Point Report',
  'approval-report': 'Approval Report',
  'vp-report': 'VP Report',
  'bullion-report': 'Bullion Report',
  'karigar-report': 'Karigar Report',
  'repair-report': 'Repair Report',
  // Desktop menu names: 'Tag Estmate' (its own misspelling) and 'Order Zoom'.
  'tag-estimate': 'Tag Estimate',
  'order-lot-zoom': 'Order Zoom (Lot Movement)',
  'sales-register': 'Sales Register',
  'purchase-register': 'Purchase Register',
  'day-book': 'Day Book',
  rojmel: 'Rojmel (Day Book)',
  // RP_CASH_BANK, reached by Ctrl+F11 on the desktop (MDI_FORM.cs handler F11CtrlCashBank).
  'cash-book': 'Cash / Bank Book',
  'cash-day-summary': 'Cash Day Summary',
  'final-reports': 'Final Reports',
  'profit-loss': 'Profit and Loss',
  'trial-balance': 'Trial Balance',
  'balance-sheet': 'Balance Sheet',
  outstanding: 'Outstanding (Debtors / Creditors)',
  'account-ledger': 'Account Ledger',
  'account-balances': 'Account Balances',
  'dhrn-outstanding': 'Pledge Loans Outstanding',
  'karigar-balances': 'Karigar Metal Balances',
  'stock-valuation': 'Stock Valuation',
  'sales-by-party': 'Sales by Party',
  'sales-by-item': 'Sales by Item',
  'monthly-sales': 'Monthly Sales',
  huid: 'HUID Report',
  'item-weight-levels': 'Item Stock Level',
  'bill-profit': 'Bill Wise Profit',
  'physical-stock-verify': 'Physical Stock Verify',
  'size-movement': 'Stock Movement',
  'branch-inout': 'Branch InOut',
  'other-item-report': 'Other Item Report',
  'design-move': 'Design Move',
  'consi-report': 'Consi Report',
  'old-stock': 'Old Stock',
  'trading-report': 'Trading Report',
  'tour-report': 'Tour Report',
  'tour-tag': 'Tour Tag',
  'order-track': 'Order Track',
  'graph-report': 'Graph Report',
  'mfg-inout': 'Mfg InOut',
  'mfg-lot-isurec': 'Mfg Lot IsuRec',
  'mfg-ledger': 'Mfg Ledger',
  'scheme-monthly': 'Scheme Monthly Report',
  gstr1: 'GSTR-1',
  gstr3b: 'GSTR-3B Summary',
};

function endpointFor(
  slug: string,
  coYear: string,
  acCode: string,
  fromDate = '',
  toDate = '',
  /** Report-specific filters (lot number, tag, direction). Empty values are omitted. */
  extra: Record<string, string> = {},
): string | null {
  // The API accepts a voucher-date window on every report via readScope; the UI simply never sent one, so
  // a report could only ever be viewed a whole financial year at a time.
  const dates =
    (fromDate ? `&fromDate=${encodeURIComponent(fromDate)}` : '') +
    (toDate ? `&toDate=${encodeURIComponent(toDate)}` : '');
  const more = Object.entries(extra)
    .filter(([, v]) => v)
    .map(([k, v]) => `&${k}=${encodeURIComponent(v)}`)
    .join('');
  const qy = `?coYear=${encodeURIComponent(coYear)}${dates}${more}`;
  switch (slug) {
    // RP_ORDER is a drill-down: without a lot number the desktop shows nothing, so the request is not made
    // at all rather than fetching an empty grid.
    case 'order-lot-zoom':
      return extra.lotNo ? `/reports/order-lot-zoom${qy}` : null;
    case 'gstr1':
      return `/gst/gstr1${qy}`;
    case 'account-ledger':
      return acCode ? `/reports/account-ledger/${encodeURIComponent(acCode)}${qy}` : null;
    default:
      return `/reports/${slug.replace(/[^a-z-]/g, '')}${qy}`;
  }
}

const esc = (s: any): string =>
  String(s ?? '').replace(
    /[&<>]/g,
    (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;' })[c] as string,
  );
/** Prettify a route slug (e.g. "sales-by-party" -> "Sales By Party") for the report title. */
function prettify(slug: string): string {
  return slug.replace(/[-_]/g, ' ').replace(/\b\w/g, (c) => c.toUpperCase());
}
/** Indian financial-year label from a starting year code (e.g. "2024" -> "2024-2025"). */
function fyLabel(coYear: string): string {
  const n = Number(coYear);
  return Number.isFinite(n) && n > 1900 ? `${n}-${n + 1}` : coYear || '\u2014';
}

// Columns whose name reads like an identifier/label should be right-aligned-if-numeric but never summed.
const ID_COL =
  /(^|[^a-z])(code|no|number|num|id|year|yr|date|rate|hsn|sac|pan|gstin|pin|phone|mobile|sr|srno|slno|vch|inv|ref|barcode|tag)([^a-z]|$)/i;
const NUM_RE = /^-?[\d,]*\.?\d+$/;
const REPORT_MODE_DEFAULTS: Record<string, string> = {
  'approval-report': 'issue',
  'vp-report': 'vp-issue',
  'bullion-report': 'sales-booking',
  'karigar-report': 'issue',
  'repair-report': 'customer-receipt',
  'branch-inout': 'out',
  'other-item-report': 'stud-inout',
  'design-move': 'design',
  'trading-report': 'all',
  'tour-report': 'voucher',
  'graph-report': 'last-30-day-sales',
};
const fmtNum = (n: number): string => n.toLocaleString('en-IN', { maximumFractionDigits: 3 });

/** Inspect rows to decide which columns are numeric (right-aligned) and which should be totalled. */
function analyzeCols(rows: Record<string, any>[]): {
  cols: string[];
  numeric: Record<string, boolean>;
  sums: Record<string, number>;
  summable: Record<string, boolean>;
} {
  const cols = Object.keys(rows[0]);
  const numeric: Record<string, boolean> = {};
  const sums: Record<string, number> = {};
  const summable: Record<string, boolean> = {};
  for (const c of cols) {
    let allNum = true,
      anyVal = false,
      sum = 0;
    for (const r of rows) {
      const v = r[c];
      if (v === null || v === undefined || v === '') continue;
      anyVal = true;
      const txt = String(v).trim();
      const ok = typeof v === 'number' ? Number.isFinite(v) : NUM_RE.test(txt);
      if (!ok) {
        allNum = false;
        break;
      }
      sum += typeof v === 'number' ? v : Number(txt.replace(/,/g, ''));
    }
    numeric[c] = anyVal && allNum;
    sums[c] = sum;
    summable[c] = numeric[c] && !ID_COL.test(c);
  }
  return { cols, numeric, sums, summable };
}

/** A bordered report table: right-aligned numeric columns + a bold TOTALS row for amount-like columns. */
function tableHtml(rows: Record<string, any>[]): string {
  if (!rows.length) return '<div class="empty">No records for the selected period.</div>';
  const { cols, numeric, sums, summable } = analyzeCols(rows);
  const head = `<thead><tr>${cols.map((c) => `<th class="${numeric[c] ? 'num' : ''}">${esc(c)}</th>`).join('')}</tr></thead>`;
  const body = `<tbody>${rows
    .map(
      (r) =>
        `<tr>${cols.map((c) => `<td class="${numeric[c] ? 'num' : ''}">${esc(r[c])}</td>`).join('')}</tr>`,
    )
    .join('')}`;
  let totals = '';
  if (cols.some((c) => summable[c])) {
    let labelIdx = cols.findIndex((c) => !summable[c]);
    if (labelIdx === -1) labelIdx = 0;
    const cells = cols.map((c, i) => {
      if (i === labelIdx)
        return `<td class="${numeric[c] ? 'num' : ''}">Total (${rows.length} rows)</td>`;
      if (summable[c]) return `<td class="num">${esc(fmtNum(sums[c]))}</td>`;
      return `<td class="${numeric[c] ? 'num' : ''}"></td>`;
    });
    totals = `<tr class="totals">${cells.join('')}</tr>`;
  }
  return `<table class="rpt">${head}${body}${totals}</tbody></table>`;
}

/** Branded, Crystal-style printable report HTML (company header band, FY, totals, footer note). */
function buildReportHtml(opts: {
  company: string;
  title: string;
  fy: string;
  scalars: [string, any][];
  arrays: [string, any[]][];
}): string {
  const { company, title, fy, scalars, arrays } = opts;
  const printedOn = new Date().toLocaleString('en-IN', {
    day: '2-digit',
    month: 'short',
    year: 'numeric',
    hour: '2-digit',
    minute: '2-digit',
  });
  const summary = scalars.length
    ? `<div class="summary">${scalars.map(([k, v]) => `<div class="card"><div class="k">${esc(k)}</div><div class="v">${esc(v)}</div></div>`).join('')}</div>`
    : '';
  const secs = arrays.map(([k, v]) => `<h2 class="section">${esc(k)}</h2>${tableHtml(v)}`).join('');
  const bodyInner =
    summary || secs
      ? `${summary}${secs}`
      : '<div class="empty">No data available for this report.</div>';
  return `<!doctype html><html><head><meta charset="utf-8"><title>${esc(title)}</title><style>
  *{box-sizing:border-box}html,body{margin:0;padding:0}
  body{font:12px 'Segoe UI',Roboto,Arial,sans-serif;color:#22272e;-webkit-print-color-adjust:exact;print-color-adjust:exact}
  .page{padding:24px 28px 62px}
  .band{display:flex;align-items:center;justify-content:space-between;background:linear-gradient(135deg,#5b1220,#7d1f33 55%,#9c2a44);color:#fff;padding:15px 20px;border-radius:6px;box-shadow:inset 0 -3px 0 #c9a227}
  .band .brand{display:flex;align-items:center;gap:13px}
  .band .mark{width:38px;height:38px;border:2px solid #e8c976;border-radius:50%;display:flex;align-items:center;justify-content:center;font-size:18px;color:#f2d98a;background:rgba(255,255,255,.07)}
  .band .co{font-family:Georgia,'Times New Roman',serif;font-size:23px;font-weight:700;letter-spacing:.6px;text-transform:uppercase;color:#fdf6e3;line-height:1.05}
  .band .co small{display:block;font-family:'Segoe UI',Arial,sans-serif;font-weight:400;font-size:8.5px;letter-spacing:3px;color:#e8c976;margin-top:3px}
  .band .stamp{text-align:right;line-height:1.25}
  .band .stamp span{display:block;font-size:8.5px;letter-spacing:1.5px;text-transform:uppercase;color:#e8c976}
  .band .stamp b{font-size:15px;color:#fdf6e3}
  .titlebar{display:flex;align-items:flex-end;justify-content:space-between;margin:16px 2px 4px;padding-bottom:7px;border-bottom:2px solid #c9a227}
  .titlebar h1{margin:0;font-size:18px;color:#5b1220;font-weight:700;letter-spacing:.3px}
  .titlebar .meta{text-align:right;font-size:10px;color:#555;line-height:1.6}
  .titlebar .meta b{color:#22272e}
  .summary{display:flex;flex-wrap:wrap;gap:9px;margin:12px 0 4px}
  .summary .card{min-width:128px;border:1px solid #e6dcbf;border-left:3px solid #c9a227;background:#fbf8ef;border-radius:4px;padding:6px 11px}
  .summary .card .k{font-size:8.5px;letter-spacing:.6px;text-transform:uppercase;color:#9a7d2e}
  .summary .card .v{font-size:14px;font-weight:700;color:#22272e;margin-top:2px}
  h2.section{font-size:12px;margin:16px 0 5px;color:#5b1220;text-transform:capitalize;border-left:4px solid #c9a227;padding-left:8px;font-weight:700}
  table.rpt{border-collapse:collapse;width:100%;margin:4px 0 10px;font-size:10.5px}
  table.rpt th,table.rpt td{border:1px solid #d7d2c4;padding:5px 8px;vertical-align:top}
  table.rpt thead th{background:#3a2230;color:#fff;text-align:left;font-weight:600;text-transform:uppercase;font-size:9px;letter-spacing:.4px;white-space:nowrap}
  table.rpt th.num,table.rpt td.num{text-align:right;font-variant-numeric:tabular-nums;white-space:nowrap}
  table.rpt tbody tr:nth-child(even){background:#f6f4ee}
  table.rpt tbody tr.totals td{border-top:2px solid #5b1220;background:#f3e7c6;font-weight:700;color:#22272e}
  table.rpt thead{display:table-header-group}
  table.rpt tr{page-break-inside:avoid}
  h2.section{page-break-after:avoid}
  .empty{color:#777;font-style:italic;padding:8px 2px}
  .foot{position:fixed;left:0;right:0;bottom:0;padding:6px 28px;border-top:1px solid #d9d3c4;background:#fff;display:flex;justify-content:space-between;font-size:8.5px;color:#7a7a7a;letter-spacing:.3px}
  .foot .l{color:#9a7d2e;font-weight:600}
  </style></head><body><div class="page">
  <div class="band"><div class="brand"><div class="mark">&#9670;</div><div class="co">${esc(company)}<small>Gold &middot; Silver &middot; Diamond</small></div></div><div class="stamp"><span>Financial Year</span><b>${esc(fy)}</b></div></div>
  <div class="titlebar"><h1>${esc(title)}</h1><div class="meta"><div><b>Printed on:</b> ${esc(printedOn)}</div><div><b>Financial Year:</b> ${esc(fy)}</div></div></div>
  ${bodyInner}
  </div>
  <div class="foot"><span class="l">${esc(company)}</span><span>Computer-generated report &middot; ${esc(title)} &middot; valid without signature</span><span>Printed ${esc(printedOn)}</span></div>
  </body></html>`;
}

function Table({
  rows,
  onRowClick,
}: {
  rows: Record<string, any>[];
  onRowClick?: (row: Record<string, any>) => void;
}) {
  if (!rows.length) return <p className="muted">No rows.</p>;
  const cols = Object.keys(rows[0]);
  const isNum = (v: any) => typeof v === 'number' || (!isNaN(Number(v)) && v !== '' && v !== null);
  return (
    <table className="grid">
      <thead>
        <tr>
          {cols.map((c) => (
            <th key={c} className={isNum(rows[0][c]) ? 'num' : ''}>
              {c}
            </th>
          ))}
        </tr>
      </thead>
      <tbody>
        {rows.map((r, i) => (
          <tr
            key={i}
            onClick={onRowClick ? () => onRowClick(r) : undefined}
            style={onRowClick ? { cursor: 'pointer' } : undefined}
          >
            {cols.map((c) => (
              <td key={c} className={isNum(r[c]) ? 'num' : ''}>
                {String(r[c] ?? '')}
              </td>
            ))}
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default function ReportPage() {
  const { coCode, coYear } = useBusinessScope();
  const slug = String(useParams().report);
  const [acCode, setAcCode] = useState('');
  const [fromDate, setFromDate] = useState('');
  const [toDate, setToDate] = useState('');
  // Report-specific filters. Only rendered for the reports that use them, mirroring the desktop's per-form
  // filter panel rather than showing every control on every report.
  const [lotNo, setLotNo] = useState('');
  const [tagNo, setTagNo] = useState('');
  const [direction, setDirection] = useState('In');
  const [userName, setUserName] = useState('');
  const [itemCodes, setItemCodes] = useState('');
  const [pendingOnly, setPendingOnly] = useState(true);
  const [dhrnMode, setDhrnMode] = useState('register');
  const [loanType, setLoanType] = useState('A');
  const [packetNo, setPacketNo] = useState('');
  const [refNo, setRefNo] = useState('');
  const [refAc, setRefAc] = useState('');
  const [reportMode, setReportMode] = useState('');
  const [itemCode, setItemCode] = useState('');
  const [designNo, setDesignNo] = useState('');
  const [karigarCode, setKarigarCode] = useState('');
  const [salesAc, setSalesAc] = useState('00003');
  const [purchaseAc, setPurchaseAc] = useState('00008');
  const [bookCodes, setBookCodes] = useState('');
  const [tourStatus, setTourStatus] = useState('pending');
  const [employeeCode, setEmployeeCode] = useState('');
  const [onlyTagged, setOnlyTagged] = useState(true);
  const [issueYear, setIssueYear] = useState('');
  const [issueBook, setIssueBook] = useState('');
  const [issueNo, setIssueNo] = useState('');
  const [partyCode, setPartyCode] = useState('');
  const [useItemLot, setUseItemLot] = useState(false);
  const [ledgerLcCode, setLedgerLcCode] = useState('');
  const [acGroup, setAcGroup] = useState('');
  const [khataNo, setKhataNo] = useState('');
  const [includeZero, setIncludeZero] = useState(false);
  const [mfgLedgerBook, setMfgLedgerBook] = useState('');
  const [orderNo, setOrderNo] = useState('');
  const [orderTrackLcCode, setOrderTrackLcCode] = useState('');
  const [orderTrackStatus, setOrderTrackStatus] = useState('sales-pending');
  const [onlyOrderTagStock, setOnlyOrderTagStock] = useState(false);
  const [schemeCode, setSchemeCode] = useState('');
  const [schemeLcCode, setSchemeLcCode] = useState('');
  const [withAdjScheme, setWithAdjScheme] = useState(false);
  const [graphMetric, setGraphMetric] = useState('');
  const [graphBookType, setGraphBookType] = useState('');
  const [graphTransactionType, setGraphTransactionType] = useState('all');
  const [graphItemType, setGraphItemType] = useState('');
  const [graphGroupCode, setGraphGroupCode] = useState('');
  const [graphLcCode, setGraphLcCode] = useState('');
  const [graphDataType, setGraphDataType] = useState('');
  const [detailRows, setDetailRows] = useState<Record<string, any>[]>([]);
  const [detailErr, setDetailErr] = useState('');
  /**
   * P3: balance-sheet valuation inputs.
   *
   * `GET /reports/balance-sheet` has always accepted closingDate, goldRate, silverRate,
   * ledgerFineGold and ledgerFineSilver (routes/txn.ts:4296-4308) because the desktop's RP_BALANCE
   * passes an operator-entered closing date and metal rates into Ac_Final.Trading_Stock — without a
   * rate the metal pass cannot value stock at all. This page never rendered them, so the report ran
   * with no valuation and silently reported unvalued metal.
   */
  const [closingDate, setClosingDate] = useState('');
  const [goldRate, setGoldRate] = useState('');
  const [silverRate, setSilverRate] = useState('');
  const [ledgerFineGold, setLedgerFineGold] = useState('');
  const [ledgerFineSilver, setLedgerFineSilver] = useState('');
  // The eleven shared RP_ALL panel dimensions. Only those the report can honour are rendered: the API
  // REFUSES an unsupported filter rather than dropping it, so offering one would just produce an error.
  const [filters, setFilters] = useState<Record<string, string>>({});
  const [supported, setSupported] = useState<string[] | null>(null);

  useEffect(() => {
    let live = true;
    setSupported(null);
    setFilters({});
    setReportMode(REPORT_MODE_DEFAULTS[slug] ?? '');
    // A report with no registered binding simply has no shared filters; a 404 here is not an error.
    get<{ supported: string[] }>(`/reports/${encodeURIComponent(slug)}/filters`)
      .then((r) => {
        if (live) setSupported(r.supported ?? []);
      })
      .catch(() => {
        if (live) setSupported([]);
      });
    return () => {
      live = false;
    };
  }, [slug]);
  const [data, setData] = useState<any>(null);
  const [err, setErr] = useState('');
  const [coName, setCoName] = useState('DataCareNext');

  // Company name for the PDF header band; authenticated company code is the fallback.
  useEffect(() => {
    const fromScope = () => setCoName(coCode || 'DataCareNext');
    get<{ CO_CODE: string; CO_NAME: string }[]>('/context/companies')
      .then((rows) => {
        const companyName = Array.isArray(rows) && rows.length ? rows[0]?.CO_NAME : '';
        if (companyName) setCoName(String(companyName).trim());
        else fromScope();
      })
      .catch(fromScope);
  }, [coCode]);

  /**
   * Build and fetch the report for the CURRENT filter values.
   *
   * The dependency array used to be `[slug, coYear, acCode]` while the body also reads `fromDate`, `toDate`,
   * `filters`, `lotNo`, `tagNo` and `direction`. Because the Run button binds this memoised callback
   * directly, changing a date or a filter did not recreate it and Run submitted STALE values — the request
   * succeeded, so nothing surfaced the mistake. On a statutory report that means the operator picks one GST
   * period and silently gets another. `react-hooks/exhaustive-deps` now guards this.
   */
  const run = useCallback(async () => {
    setErr('');
    setData(null);
    setDetailRows([]);
    setDetailErr('');
    const ep = endpointFor(slug, coYear, acCode, fromDate, toDate, {
      ...filters,
      lotNo,
      tagNo,
      ...(slug === 'tag-estimate' ? { direction } : {}),
      ...(slug === 'entry-check' ? { userName, pendingOnly: pendingOnly ? 'true' : 'false' } : {}),
      ...(slug === 'user-report' ? { userName, itemCodes } : {}),
      ...(slug === 'dhiran-report' || slug === 'loan-report'
        ? { mode: dhrnMode, loanType, packetNo, refNo, refAc }
        : {}),
      ...([
        'approval-report',
        'vp-report',
        'bullion-report',
        'karigar-report',
        'repair-report',
        'branch-inout',
        'other-item-report',
        'design-move',
        'trading-report',
        'tour-report',
      ].includes(slug) && reportMode
        ? { mode: reportMode }
        : {}),
      ...(slug === 'other-item-report' ? { itemCode } : {}),
      ...(slug === 'design-move' ? { tagNo, designNo } : {}),
      ...(slug === 'old-stock' ? { karigarCode } : {}),
      ...(slug === 'trading-report' ? { salesAc, purchaseAc, bookCodes } : {}),
      ...(slug === 'tour-report' || slug === 'tour-tag'
        ? { status: tourStatus, employeeCode, onlyTagged: onlyTagged ? 'true' : 'false' }
        : {}),
      ...(slug === 'tour-tag' ? { tagNo, issueYear, issueBook, issueNo } : {}),
      ...(slug === 'graph-report'
        ? {
            mode: reportMode,
            metric: graphMetric,
            transactionType: graphTransactionType,
            bookType: graphBookType,
            itemType: graphItemType,
            grCode: graphGroupCode,
            lcCode: graphLcCode,
            dataType: graphDataType,
          }
        : {}),
      ...(slug === 'order-track'
        ? {
            orderNo,
            employeeCode,
            lcCode: orderTrackLcCode,
            onlyOrderTagStock: onlyOrderTagStock ? 'true' : 'false',
            designNo,
            karigarCode,
            status: orderTrackStatus,
          }
        : {}),
      ...(slug === 'mfg-inout' ? { karigarCode } : {}),
      ...(slug === 'mfg-lot-isurec'
        ? { partyCode, karigarCode, lotNo, useItemLot: useItemLot ? 'true' : 'false' }
        : {}),
      ...(slug === 'mfg-ledger'
        ? {
            lcCode: ledgerLcCode,
            acGroup,
            khataNo,
            includeZero: includeZero ? 'true' : 'false',
          }
        : {}),
      ...(slug === 'scheme-monthly'
        ? {
            schemeCode,
            lcCode: schemeLcCode,
            withAdjScheme: withAdjScheme ? 'true' : 'false',
          }
        : {}),
      ...(slug === 'balance-sheet'
        ? { closingDate, goldRate, silverRate, ledgerFineGold, ledgerFineSilver }
        : {}),
    });
    if (!ep) {
      setErr('Enter an account code');
      return;
    }
    try {
      setData(await get(ep));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.error || e.message : 'failed');
    }
  }, [
    slug,
    coYear,
    acCode,
    fromDate,
    toDate,
    filters,
    lotNo,
    tagNo,
    direction,
    userName,
    itemCodes,
    pendingOnly,
    dhrnMode,
    loanType,
    packetNo,
    refNo,
    refAc,
    reportMode,
    itemCode,
    designNo,
    karigarCode,
    salesAc,
    purchaseAc,
    bookCodes,
    tourStatus,
    employeeCode,
    onlyTagged,
    issueYear,
    issueBook,
    issueNo,
    partyCode,
    useItemLot,
    ledgerLcCode,
    acGroup,
    khataNo,
    includeZero,
    orderNo,
    orderTrackLcCode,
    orderTrackStatus,
    onlyOrderTagStock,
    schemeCode,
    schemeLcCode,
    withAdjScheme,
    graphMetric,
    graphBookType,
    graphTransactionType,
    graphItemType,
    graphGroupCode,
    graphLcCode,
    graphDataType,
    closingDate,
    goldRate,
    silverRate,
    ledgerFineGold,
    ledgerFineSilver,
  ]);

  /**
   * Auto-run only when the REPORT or the YEAR changes.
   *
   * `run` is now correctly invalidated by every filter it reads, so depending on it here would re-fetch on
   * each keystroke in a date or filter box. The ref keeps the effect's trigger set narrow (report + year)
   * while still invoking the latest, non-stale callback.
   */
  const runRef = useRef(run);
  runRef.current = run;
  useEffect(() => {
    if (coYear && slug !== 'account-ledger') void runRef.current();
  }, [coYear, slug]);

  const loadEntryCheckDetail = useCallback(
    async (row: Record<string, any>) => {
      if (slug !== 'entry-check') return;
      const coBook = String(row.coBook ?? '').trim();
      const vchNo = String(row.vchNo ?? '').trim();
      if (!coBook || !vchNo) return;
      setDetailErr('');
      try {
        const q = new URLSearchParams();
        if (coYear) q.set('coYear', coYear);
        q.set('coBook', coBook);
        q.set('vchNo', vchNo);
        if (fromDate) q.set('fromDate', fromDate);
        if (toDate) q.set('toDate', toDate);
        const result = await get<{ rows: Record<string, any>[] }>(
          `/reports/entry-check/detail?${q.toString()}`,
        );
        setDetailRows(result.rows ?? []);
      } catch (e) {
        setDetailErr(e instanceof ApiError ? e.body?.error || e.message : 'failed');
      }
    },
    [slug, coYear, fromDate, toDate],
  );

  const loadPointReportDetail = useCallback(
    async (row: Record<string, any>) => {
      if (slug !== 'point-report') return;
      const memberCode = String(row.memberCode ?? '').trim();
      if (!memberCode) return;
      setDetailErr('');
      try {
        const q = new URLSearchParams();
        if (coYear) q.set('coYear', coYear);
        q.set('memberCode', memberCode);
        if (toDate) q.set('toDate', toDate);
        const result = await get<{ rows: Record<string, any>[] }>(
          `/reports/point-report/detail?${q.toString()}`,
        );
        setDetailRows(result.rows ?? []);
      } catch (e) {
        setDetailErr(e instanceof ApiError ? e.body?.error || e.message : 'failed');
      }
    },
    [slug, coYear, toDate],
  );

  const loadDesignMoveDetail = useCallback(
    async (row: Record<string, any>) => {
      if (slug !== 'design-move') return;
      const key = String(row.key ?? '').trim();
      const size = String(row.size ?? '').trim();
      if (!key || !size) return;
      setDetailErr('');
      try {
        const q = new URLSearchParams();
        if (coYear) q.set('coYear', coYear);
        if (toDate) q.set('toDate', toDate);
        if (reportMode) q.set('mode', reportMode);
        if (designNo) q.set('designNo', designNo);
        Object.entries(filters).forEach(([filterKey, value]) => {
          if (value) q.set(filterKey, value);
        });
        q.set('key', key);
        q.set('size', size);
        const result = await get<{ rows: Record<string, any>[] }>(
          `/reports/design-move/detail?${q.toString()}`,
        );
        setDetailRows(result.rows ?? []);
      } catch (e) {
        setDetailErr(e instanceof ApiError ? e.body?.error || e.message : 'failed');
      }
    },
    [slug, coYear, toDate, reportMode, designNo, filters],
  );

  const loadConsiDetail = useCallback(
    async (row: Record<string, any>) => {
      if (slug !== 'consi-report') return;
      const rowAcCode = String(row.acCode ?? '').trim();
      if (!rowAcCode) return;
      setDetailErr('');
      try {
        const q = new URLSearchParams();
        if (coYear) q.set('coYear', coYear);
        if (fromDate) q.set('fromDate', fromDate);
        if (toDate) q.set('toDate', toDate);
        q.set('acCode', rowAcCode);
        const result = await get<{ rows: Record<string, any>[] }>(
          `/reports/consi-report/detail?${q.toString()}`,
        );
        setDetailRows(result.rows ?? []);
      } catch (e) {
        setDetailErr(e instanceof ApiError ? e.body?.error || e.message : 'failed');
      }
    },
    [slug, coYear, fromDate, toDate],
  );

  const loadMfgLedgerDetail = useCallback(
    async (row: Record<string, any>) => {
      if (slug !== 'mfg-ledger') return;
      const rowAcCode = String(row.acCode ?? '').trim();
      if (!rowAcCode) return;
      setDetailErr('');
      try {
        const q = new URLSearchParams();
        if (coYear) q.set('coYear', coYear);
        if (fromDate) q.set('fromDate', fromDate);
        if (toDate) q.set('toDate', toDate);
        if (ledgerLcCode) q.set('lcCode', ledgerLcCode);
        if (mfgLedgerBook) q.set('coBook', mfgLedgerBook);
        q.set('acCode', rowAcCode);
        const result = await get<{ rows: Record<string, any>[] }>(
          `/reports/mfg-ledger/detail?${q.toString()}`,
        );
        setDetailRows(result.rows ?? []);
      } catch (e) {
        setDetailErr(e instanceof ApiError ? e.body?.error || e.message : 'failed');
      }
    },
    [slug, coYear, fromDate, toDate, ledgerLcCode, mfgLedgerBook],
  );

  const markVisibleEntryRows = useCallback(async () => {
    const rows = Array.isArray(data?.rows) ? data.rows : [];
    const targets = rows
      .filter((row: Record<string, any>) => String(row.entryCheck ?? '') !== 'Y')
      .map((row: Record<string, any>) => ({
        coBook: row.coBook,
        vchNo: row.vchNo,
        editDate: row.editDate,
      }));
    if (!targets.length) return;
    setErr('');
    try {
      const q = new URLSearchParams();
      if (coYear) q.set('coYear', coYear);
      await post(`/reports/entry-check/mark-checked?${q.toString()}`, { rows: targets });
      await run();
      setDetailRows([]);
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.error || e.message : 'failed');
    }
  }, [data, coYear, run]);

  const arrays = data
    ? (Object.entries(data).filter(([, v]) => Array.isArray(v)) as [string, any[]][])
    : [];
  const scalars = data
    ? Object.entries(data).filter(([, v]) => !Array.isArray(v) && typeof v !== 'object')
    : [];

  return (
    <div>
      <h1>{TITLES[slug] ?? prettify(slug)}</h1>
      <div className="toolbar">
        <div className="field" style={{ marginBottom: 0 }}>
          <label>Year</label>
          <input value={coYear} readOnly style={{ width: 90 }} />
        </div>
        {slug === 'account-ledger' && (
          <div className="field" style={{ marginBottom: 0 }}>
            <label>Account Code</label>
            <input
              value={acCode}
              onChange={(e) => setAcCode(e.target.value)}
              style={{ width: 120 }}
            />
          </div>
        )}
        {/* The shared RP_ALL filter panel. Labels use the business meaning rather than the desktop's
            misleading control names: `tItCode` drives the PRODUCT code and `tGrCode` the item group. */}
        {(supported ?? []).map((key) => {
          const LABELS: Record<string, string> = {
            acCode: 'Party',
            lcCode: 'Location',
            bookCode: 'Book',
            area: 'Area',
            city: 'City',
            state: 'State',
            grCode: 'Group',
            prCode: 'Product',
            itType: 'Item Type',
            empCode: 'Employee',
            custName: 'Customer Name',
          };
          return (
            <div className="field" style={{ marginBottom: 0 }} key={key}>
              <label htmlFor={`filter-${key}`}>{LABELS[key] ?? key}</label>
              <input
                id={`filter-${key}`}
                value={filters[key] ?? ''}
                onChange={(e) => setFilters((f) => ({ ...f, [key]: e.target.value }))}
                style={{ width: 120 }}
              />
            </div>
          );
        })}
        {/* RP_ORDER drills into ONE lot, so the lot number is required rather than optional. */}
        {slug === 'order-lot-zoom' && (
          <div className="field" style={{ marginBottom: 0 }}>
            <label htmlFor="lotNo">Lot No (required)</label>
            <input
              id="lotNo"
              value={lotNo}
              onChange={(e) => setLotNo(e.target.value)}
              style={{ width: 140 }}
            />
          </div>
        )}
        {/* RP_BALANCE values closing stock from an operator-entered date and metal rates; without
            a rate the metal pass cannot value stock at all. The API always accepted these. */}
        {(slug === 'balance-sheet' || slug === 'final-reports') && (
          <>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="closingDate">Closing Date</label>
              <input
                id="closingDate"
                type="date"
                value={closingDate}
                onChange={(e) => setClosingDate(e.target.value)}
                style={{ width: 130 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="goldRate">Gold Rate /10g</label>
              <input
                id="goldRate"
                value={goldRate}
                onChange={(e) => setGoldRate(e.target.value)}
                style={{ width: 110 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="silverRate">Silver Rate /10g</label>
              <input
                id="silverRate"
                value={silverRate}
                onChange={(e) => setSilverRate(e.target.value)}
                style={{ width: 110 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="ledgerFineGold">Ledger Fine Gold</label>
              <input
                id="ledgerFineGold"
                value={ledgerFineGold}
                onChange={(e) => setLedgerFineGold(e.target.value)}
                style={{ width: 110 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="ledgerFineSilver">Ledger Fine Silver</label>
              <input
                id="ledgerFineSilver"
                value={ledgerFineSilver}
                onChange={(e) => setLedgerFineSilver(e.target.value)}
                style={{ width: 110 }}
              />
            </div>
          </>
        )}
        {/* RP_USER Entry Check: desktop has user filter and an Only Panding Chk checkbox. */}
        {slug === 'entry-check' && (
          <>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="userName">User</label>
              <input
                id="userName"
                value={userName}
                onChange={(e) => setUserName(e.target.value)}
                style={{ width: 130 }}
              />
            </div>
            <label className="field" style={{ marginBottom: 0, width: 150 }}>
              <span>Only Pending</span>
              <input
                type="checkbox"
                checked={pendingOnly}
                onChange={(e) => setPendingOnly(e.target.checked)}
              />
            </label>
          </>
        )}
        {/* RP_USER User Report: desktop has the same user combo plus a Select Item checklist. */}
        {slug === 'user-report' && (
          <>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="userName">User</label>
              <input
                id="userName"
                value={userName}
                onChange={(e) => setUserName(e.target.value)}
                style={{ width: 130 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="itemCodes">Item Codes</label>
              <input
                id="itemCodes"
                placeholder="comma separated"
                value={itemCodes}
                onChange={(e) => setItemCodes(e.target.value)}
                style={{ width: 180 }}
              />
            </div>
          </>
        )}
        {/* RP_DHRN_LOAN: same form serves Dhiran Report (D) and Loan Report (L). */}
        {(slug === 'dhiran-report' || slug === 'loan-report') && (
          <>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="dhrnMode">View</label>
              <select
                id="dhrnMode"
                value={dhrnMode}
                onChange={(e) => setDhrnMode(e.target.value)}
                style={{ width: 110 }}
              >
                <option value="register">Register</option>
                <option value="pending">Pending</option>
              </select>
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="loanType">Loan Type</label>
              <select
                id="loanType"
                value={loanType}
                onChange={(e) => setLoanType(e.target.value)}
                style={{ width: 105 }}
              >
                <option value="A">Amount</option>
                <option value="G">Gold</option>
                <option value="S">Silver</option>
              </select>
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="packetNo">Packet No</label>
              <input
                id="packetNo"
                value={packetNo}
                onChange={(e) => setPacketNo(e.target.value)}
                style={{ width: 120 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="refNo">Ref No</label>
              <input
                id="refNo"
                value={refNo}
                onChange={(e) => setRefNo(e.target.value)}
                style={{ width: 110 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="refAc">Ref Account</label>
              <input
                id="refAc"
                value={refAc}
                onChange={(e) => setRefAc(e.target.value)}
                style={{ width: 120 }}
              />
            </div>
          </>
        )}
        {[
          'approval-report',
          'vp-report',
          'bullion-report',
          'karigar-report',
          'repair-report',
          'branch-inout',
          'other-item-report',
          'design-move',
          'trading-report',
          'tour-report',
        ].includes(slug) && (
          <div className="field" style={{ marginBottom: 0 }}>
            <label htmlFor="reportMode">Report Type</label>
            <select
              id="reportMode"
              value={reportMode}
              onChange={(e) => setReportMode(e.target.value)}
              style={{ width: 190 }}
            >
              {slug === 'approval-report' && (
                <>
                  <option value="issue">Party Wise Issue</option>
                  <option value="inout">In Out</option>
                  <option value="pending">Pending</option>
                </>
              )}
              {slug === 'vp-report' && (
                <>
                  <option value="vp-issue">VP Issue</option>
                  <option value="vp-pending">VP Pending</option>
                  <option value="vp-adjusted">VP Adjusted</option>
                  <option value="angdiya-issue">Angdiya Issue</option>
                  <option value="angdiya-pending">Angdiya Pending</option>
                  <option value="angdiya-adjusted">Angdiya Adjusted</option>
                </>
              )}
              {slug === 'bullion-report' && (
                <>
                  <option value="sales-booking">Sales Booking</option>
                  <option value="purchase-booking">Purchase Booking</option>
                  <option value="sales-adjusted">Sales Adjust</option>
                  <option value="purchase-adjusted">Purchase Adjust</option>
                  <option value="sales-pending">Sales Pending</option>
                  <option value="purchase-pending">Purchase Pending</option>
                </>
              )}
              {slug === 'karigar-report' && (
                <>
                  <option value="issue">Issue</option>
                  <option value="receive">Receive</option>
                </>
              )}
              {slug === 'repair-report' && (
                <>
                  <option value="customer-receipt">Customer Receipt</option>
                  <option value="karigar-issue-pending">Karigar Issue Pending</option>
                  <option value="karigar-issue">Karigar Issue</option>
                  <option value="karigar-receipt-pending">Karigar Receipt Pending</option>
                  <option value="karigar-receipt">Karigar Receipt</option>
                  <option value="customer-issue">Customer Issue</option>
                  <option value="customer-issue-pending">Customer Issue Pending</option>
                </>
              )}
              {slug === 'branch-inout' && (
                <>
                  <option value="out">Stock Outword</option>
                  <option value="in">Stock Inword</option>
                </>
              )}
              {slug === 'other-item-report' && (
                <>
                  <option value="stud-in">Stud Itm In</option>
                  <option value="stud-inout">Stud In Out</option>
                  <option value="stud-out">Stud Itm Out</option>
                  <option value="loose-in">Loose Itm In</option>
                  <option value="loose-inout">Loose In Out</option>
                  <option value="loose-out">Loose Itm Out</option>
                </>
              )}
              {slug === 'design-move' && (
                <>
                  <option value="design">Design / Size</option>
                  <option value="item">Item / Size</option>
                </>
              )}
              {slug === 'trading-report' && (
                <>
                  <option value="all">All</option>
                  <option value="only-ratecut">Only RateCut</option>
                  <option value="without-ratecut">Whout RateCut</option>
                </>
              )}
              {slug === 'tour-report' && (
                <>
                  <option value="voucher">Voucher Wise</option>
                  <option value="item-wise">Item Wise Stock</option>
                </>
              )}
            </select>
          </div>
        )}
        {slug === 'other-item-report' && (
          <div className="field" style={{ marginBottom: 0 }}>
            <label htmlFor="itemCode">Item Code</label>
            <input
              id="itemCode"
              value={itemCode}
              onChange={(e) => setItemCode(e.target.value)}
              style={{ width: 120 }}
            />
          </div>
        )}
        {slug === 'design-move' && (
          <>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="designTagNo">Tag No</label>
              <input
                id="designTagNo"
                value={tagNo}
                onChange={(e) => setTagNo(e.target.value)}
                style={{ width: 120 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="designNo">Design</label>
              <input
                id="designNo"
                value={designNo}
                onChange={(e) => setDesignNo(e.target.value)}
                style={{ width: 140 }}
              />
            </div>
          </>
        )}
        {slug === 'old-stock' && (
          <div className="field" style={{ marginBottom: 0 }}>
            <label htmlFor="karigarCode">Karigar</label>
            <input
              id="karigarCode"
              value={karigarCode}
              onChange={(e) => setKarigarCode(e.target.value)}
              style={{ width: 120 }}
            />
          </div>
        )}
        {slug === 'mfg-inout' && (
          <div className="field" style={{ marginBottom: 0 }}>
            <label htmlFor="mfgKarigarCode">Karigar</label>
            <input
              id="mfgKarigarCode"
              value={karigarCode}
              onChange={(e) => setKarigarCode(e.target.value)}
              style={{ width: 120 }}
            />
          </div>
        )}
        {slug === 'mfg-lot-isurec' && (
          <>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="mfgPartyCode">Party</label>
              <input
                id="mfgPartyCode"
                value={partyCode}
                onChange={(e) => setPartyCode(e.target.value)}
                style={{ width: 120 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="mfgLotKarigarCode">Karigar</label>
              <input
                id="mfgLotKarigarCode"
                value={karigarCode}
                onChange={(e) => setKarigarCode(e.target.value)}
                style={{ width: 120 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="mfgLotNo">Lot No</label>
              <input
                id="mfgLotNo"
                value={lotNo}
                onChange={(e) => setLotNo(e.target.value)}
                style={{ width: 130 }}
              />
            </div>
            <label className="field" style={{ marginBottom: 0, width: 140 }}>
              <span>Use Item Lot</span>
              <input
                type="checkbox"
                checked={useItemLot}
                onChange={(e) => setUseItemLot(e.target.checked)}
              />
            </label>
          </>
        )}
        {slug === 'mfg-ledger' && (
          <>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="mfgLedgerLcCode">Location</label>
              <input
                id="mfgLedgerLcCode"
                value={ledgerLcCode}
                onChange={(e) => setLedgerLcCode(e.target.value)}
                placeholder="blank = all"
                style={{ width: 115 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="mfgLedgerAcGroup">Ac Group</label>
              <input
                id="mfgLedgerAcGroup"
                value={acGroup}
                onChange={(e) => setAcGroup(e.target.value)}
                style={{ width: 120 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="mfgLedgerKhataNo">Khata No</label>
              <input
                id="mfgLedgerKhataNo"
                value={khataNo}
                onChange={(e) => setKhataNo(e.target.value)}
                style={{ width: 120 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="mfgLedgerBook">Book</label>
              <input
                id="mfgLedgerBook"
                value={mfgLedgerBook}
                onChange={(e) => setMfgLedgerBook(e.target.value)}
                title="Applied when opening account detail."
                style={{ width: 90 }}
              />
            </div>
            <label className="field" style={{ marginBottom: 0, width: 145 }}>
              <span>Show Zero</span>
              <input
                type="checkbox"
                checked={includeZero}
                onChange={(e) => setIncludeZero(e.target.checked)}
              />
            </label>
          </>
        )}
        {slug === 'trading-report' && (
          <>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="salesAc">Sales Ac</label>
              <input
                id="salesAc"
                value={salesAc}
                onChange={(e) => setSalesAc(e.target.value)}
                style={{ width: 120 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="purchaseAc">Purchase Ac</label>
              <input
                id="purchaseAc"
                value={purchaseAc}
                onChange={(e) => setPurchaseAc(e.target.value)}
                style={{ width: 120 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="bookCodes">Books</label>
              <input
                id="bookCodes"
                placeholder="comma separated"
                value={bookCodes}
                onChange={(e) => setBookCodes(e.target.value)}
                style={{ width: 150 }}
              />
            </div>
          </>
        )}
        {(slug === 'tour-report' || slug === 'tour-tag') && (
          <>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="tourStatus">Status</label>
              <select
                id="tourStatus"
                value={tourStatus}
                onChange={(e) => setTourStatus(e.target.value)}
                style={{ width: 110 }}
              >
                <option value="pending">Panding</option>
                <option value="sales">Sales</option>
                <option value="return">Return</option>
                <option value="all">All</option>
              </select>
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="employeeCode">Employee</label>
              <input
                id="employeeCode"
                value={employeeCode}
                onChange={(e) => setEmployeeCode(e.target.value)}
                style={{ width: 120 }}
              />
            </div>
            <label className="field" style={{ marginBottom: 0, width: 145 }}>
              <span>Only Tag Stock</span>
              <input
                type="checkbox"
                checked={onlyTagged}
                onChange={(e) => setOnlyTagged(e.target.checked)}
              />
            </label>
          </>
        )}
        {slug === 'tour-tag' && (
          <>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="tourTagNo">Tag No</label>
              <input
                id="tourTagNo"
                value={tagNo}
                onChange={(e) => setTagNo(e.target.value)}
                style={{ width: 120 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="issueYear">Issue Year</label>
              <input
                id="issueYear"
                value={issueYear}
                onChange={(e) => setIssueYear(e.target.value)}
                style={{ width: 100 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="issueBook">Issue Book</label>
              <input
                id="issueBook"
                value={issueBook}
                onChange={(e) => setIssueBook(e.target.value)}
                style={{ width: 90 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="issueNo">Issue No</label>
              <input
                id="issueNo"
                value={issueNo}
                onChange={(e) => setIssueNo(e.target.value)}
                style={{ width: 110 }}
              />
            </div>
          </>
        )}
        {slug === 'graph-report' && (
          <>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="graphMode">Mode</label>
              <select
                id="graphMode"
                value={reportMode || 'last-30-day-sales'}
                onChange={(e) => setReportMode(e.target.value)}
                style={{ width: 165 }}
              >
                <option value="last-30-day-sales">Last 30 Day SL</option>
                <option value="month-sales">Month SL</option>
                <option value="product-sales">Product SL</option>
                <option value="employee-sales">Employee SL</option>
                <option value="expense-by-day">Expense Day</option>
                <option value="expense-by-type">Expense Type</option>
                <option value="karigar-sales">Karigar SL</option>
              </select>
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="graphMetric">Amount / Weight</label>
              <select
                id="graphMetric"
                value={graphMetric}
                onChange={(e) => setGraphMetric(e.target.value)}
                style={{ width: 130 }}
              >
                <option value="">Desktop default</option>
                <option value="amount">Amount</option>
                <option value="weight">Weight</option>
              </select>
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="graphTxn">Sales / Return</label>
              <select
                id="graphTxn"
                value={graphTransactionType}
                onChange={(e) => setGraphTransactionType(e.target.value)}
                style={{ width: 105 }}
              >
                <option value="all">Both</option>
                <option value="sales">Sales</option>
                <option value="return">Return</option>
              </select>
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="graphBook">Book Type</label>
              <select
                id="graphBook"
                value={graphBookType}
                onChange={(e) => setGraphBookType(e.target.value)}
                style={{ width: 120 }}
              >
                <option value="">Desktop default</option>
                <option value="retail">Retail</option>
                <option value="whsale">WhSale</option>
                <option value="all">All</option>
              </select>
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="graphItemType">Item Type</label>
              <select
                id="graphItemType"
                value={graphItemType}
                onChange={(e) => setGraphItemType(e.target.value)}
                style={{ width: 120 }}
              >
                <option value="">Desktop default</option>
                <option value="all">All</option>
                <option value="G">Gold</option>
                <option value="S">Silver</option>
                <option value="D">Diamond</option>
                <option value="R">Real Stone</option>
                <option value="E">Emitation</option>
                <option value="O">Other</option>
                <option value="P">Platinum</option>
              </select>
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="graphGroupCode">Group</label>
              <input
                id="graphGroupCode"
                value={graphGroupCode}
                onChange={(e) => setGraphGroupCode(e.target.value)}
                style={{ width: 90 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="graphLcCode">Location</label>
              <input
                id="graphLcCode"
                value={graphLcCode}
                onChange={(e) => setGraphLcCode(e.target.value)}
                placeholder="current"
                style={{ width: 95 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="graphDataType">Data Type</label>
              <input
                id="graphDataType"
                value={graphDataType}
                onChange={(e) => setGraphDataType(e.target.value)}
                placeholder="C/R/etc"
                style={{ width: 90 }}
              />
            </div>
          </>
        )}
        {slug === 'order-track' && (
          <>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="orderTrackStatus">Status</label>
              <select
                id="orderTrackStatus"
                value={orderTrackStatus}
                onChange={(e) => setOrderTrackStatus(e.target.value)}
                style={{ width: 130 }}
              >
                <option value="sales-pending">Sal Panding</option>
                <option value="issue-pending">Isu Panding</option>
                <option value="receive-pending">Rec Panding</option>
                <option value="all">All</option>
              </select>
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="orderTrackNo">Order No</label>
              <input
                id="orderTrackNo"
                value={orderNo}
                onChange={(e) => setOrderNo(e.target.value)}
                style={{ width: 110 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="orderTrackEmployee">Employee</label>
              <input
                id="orderTrackEmployee"
                value={employeeCode}
                onChange={(e) => setEmployeeCode(e.target.value)}
                style={{ width: 110 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="orderTrackLcCode">Location</label>
              <input
                id="orderTrackLcCode"
                value={orderTrackLcCode}
                onChange={(e) => setOrderTrackLcCode(e.target.value)}
                placeholder="current"
                style={{ width: 95 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="orderTrackDesignNo">Design</label>
              <input
                id="orderTrackDesignNo"
                value={designNo}
                onChange={(e) => setDesignNo(e.target.value)}
                style={{ width: 120 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="orderTrackKarigar">Karigar</label>
              <input
                id="orderTrackKarigar"
                value={karigarCode}
                onChange={(e) => setKarigarCode(e.target.value)}
                style={{ width: 110 }}
              />
            </div>
            <label className="field" style={{ marginBottom: 0, width: 170 }}>
              <span>Only Order Tag Stock</span>
              <input
                type="checkbox"
                checked={onlyOrderTagStock}
                onChange={(e) => setOnlyOrderTagStock(e.target.checked)}
              />
            </label>
          </>
        )}
        {slug === 'scheme-monthly' && (
          <>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="schemeCode">Schm Code</label>
              <input
                id="schemeCode"
                value={schemeCode}
                onChange={(e) => setSchemeCode(e.target.value)}
                style={{ width: 105 }}
              />
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="schemeLcCode">Location</label>
              <input
                id="schemeLcCode"
                value={schemeLcCode}
                onChange={(e) => setSchemeLcCode(e.target.value)}
                placeholder="current"
                style={{ width: 95 }}
              />
            </div>
            <label className="field" style={{ marginBottom: 0, width: 150 }}>
              <span>With Adj Scheme</span>
              <input
                type="checkbox"
                checked={withAdjScheme}
                onChange={(e) => setWithAdjScheme(e.target.checked)}
              />
            </label>
          </>
        )}
        {/* RP_TAG_ESTMATE switches source between the tag ledger (In) and issued stock (Out). */}
        {slug === 'tag-estimate' && (
          <>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="direction">Direction</label>
              <select
                id="direction"
                value={direction}
                onChange={(e) => setDirection(e.target.value)}
                style={{ width: 100 }}
              >
                <option value="In">In</option>
                <option value="Out">Out</option>
              </select>
            </div>
            <div className="field" style={{ marginBottom: 0 }}>
              <label htmlFor="tagNo">Tag No</label>
              <input
                id="tagNo"
                value={tagNo}
                onChange={(e) => setTagNo(e.target.value)}
                style={{ width: 140 }}
              />
            </div>
          </>
        )}
        {/* Voucher-date window. The desktop filters nearly every report family by from/to date; the web
            API already accepted it and only the UI was missing. Blank means the whole financial year. */}
        <div className="field" style={{ marginBottom: 0 }}>
          <label htmlFor="fromDate">From</label>
          <input
            id="fromDate"
            type="date"
            value={fromDate}
            onChange={(e) => setFromDate(e.target.value)}
            style={{ width: 150 }}
          />
        </div>
        <div className="field" style={{ marginBottom: 0 }}>
          <label htmlFor="toDate">To</label>
          <input
            id="toDate"
            type="date"
            value={toDate}
            onChange={(e) => setToDate(e.target.value)}
            style={{ width: 150 }}
          />
        </div>
        <button className="primary" onClick={run}>
          Run
        </button>
        <button
          className="ghost"
          disabled={!data}
          onClick={() =>
            downloadPdf(
              buildReportHtml({
                company: coName,
                title: TITLES[slug] ?? prettify(slug),
                fy: fyLabel(coYear),
                scalars: scalars as [string, any][],
                arrays,
              }),
              slug,
            )
          }
        >
          Download PDF
        </button>
        {(
          {
            gstr1: 'gstr1-doc',
            gstr2: 'gstr2-doc',
            gstr3b: 'gstr3b-doc',
            'trial-balance': 'trial-balance-doc',
            'trial-balance-full': 'trial-balance-doc',
            'balance-sheet': 'balance-sheet-doc',
          } as Record<string, string>
        )[slug] && (
          <button
            className="ghost"
            onClick={() =>
              window.open(
                `/api/reports/${({ gstr1: 'gstr1-doc', gstr2: 'gstr2-doc', gstr3b: 'gstr3b-doc', 'trial-balance': 'trial-balance-doc', 'trial-balance-full': 'trial-balance-doc', 'balance-sheet': 'balance-sheet-doc' } as Record<string, string>)[slug]}?coYear=${encodeURIComponent(coYear)}&format=html`,
                '_blank',
              )
            }
          >
            {slug.startsWith('gstr') ? 'Statutory Document' : 'Statement Document'}
          </button>
        )}
      </div>
      {slug === 'entry-check' && Array.isArray(data?.rows) && data.rows.length > 0 && (
        <div className="toolbar" style={{ marginTop: 8 }}>
          <button className="ghost" onClick={markVisibleEntryRows}>
            Mark visible pending rows checked
          </button>
          <span className="muted">Click a row to load its desktop-style field-change detail.</span>
        </div>
      )}
      {err && <div className="msg err">{err}</div>}
      {scalars.length > 0 && (
        <div className="panel">
          <div className="tiles">
            {scalars.map(([k, v]) => (
              <div className="tile" key={k}>
                <div className="muted">{k}</div>
                <div className="big kpi">{String(v)}</div>
              </div>
            ))}
          </div>
        </div>
      )}
      {arrays.map(([k, v]) => (
        <div className="panel" key={k} style={{ overflow: 'auto' }}>
          <div className="toolbar">
            <h2 style={{ textTransform: 'capitalize', margin: 0 }}>{k}</h2>
            <button className="ghost" onClick={() => downloadCsv(v, `${slug}-${k}`)}>
              CSV
            </button>
            {/* Excel export (desktop BtnExel). The server re-derives the rows from the same builder the
                report uses, so the workbook can never disagree with what is on screen. */}
            <button
              className="ghost"
              onClick={() => {
                const q = new URLSearchParams();
                if (coYear) q.set('coYear', coYear);
                if (acCode) q.set('acCode', acCode);
                if (fromDate) q.set('fromDate', fromDate);
                if (toDate) q.set('toDate', toDate);
                Object.entries(filters).forEach(([key, value]) => {
                  if (value) q.set(key, value);
                });
                if (slug === 'tag-estimate') {
                  if (direction) q.set('direction', direction);
                  if (tagNo) q.set('tagNo', tagNo);
                }
                if (slug === 'entry-check') {
                  if (userName) q.set('userName', userName);
                  q.set('pendingOnly', pendingOnly ? 'true' : 'false');
                }
                if (slug === 'user-report') {
                  if (userName) q.set('userName', userName);
                  if (itemCodes) q.set('itemCodes', itemCodes);
                }
                if (
                  [
                    'approval-report',
                    'vp-report',
                    'bullion-report',
                    'karigar-report',
                    'repair-report',
                    'branch-inout',
                    'other-item-report',
                    'design-move',
                    'trading-report',
                    'tour-report',
                  ].includes(slug) &&
                  reportMode
                ) {
                  q.set('mode', reportMode);
                }
                if (slug === 'other-item-report' && itemCode) q.set('itemCode', itemCode);
                if (slug === 'design-move') {
                  if (tagNo) q.set('tagNo', tagNo);
                  if (designNo) q.set('designNo', designNo);
                }
                if (slug === 'old-stock' && karigarCode) q.set('karigarCode', karigarCode);
                if (slug === 'trading-report') {
                  if (salesAc) q.set('salesAc', salesAc);
                  if (purchaseAc) q.set('purchaseAc', purchaseAc);
                  if (bookCodes) q.set('bookCodes', bookCodes);
                }
                if (slug === 'tour-report' || slug === 'tour-tag') {
                  if (tourStatus) q.set('status', tourStatus);
                  if (employeeCode) q.set('employeeCode', employeeCode);
                  q.set('onlyTagged', onlyTagged ? 'true' : 'false');
                }
                if (slug === 'tour-tag') {
                  if (tagNo) q.set('tagNo', tagNo);
                  if (issueYear) q.set('issueYear', issueYear);
                  if (issueBook) q.set('issueBook', issueBook);
                  if (issueNo) q.set('issueNo', issueNo);
                }
                if (slug === 'graph-report') {
                  if (reportMode) q.set('mode', reportMode);
                  if (graphMetric) q.set('metric', graphMetric);
                  if (graphTransactionType) q.set('transactionType', graphTransactionType);
                  if (graphBookType) q.set('bookType', graphBookType);
                  if (graphItemType) q.set('itemType', graphItemType);
                  if (graphGroupCode) q.set('grCode', graphGroupCode);
                  if (graphLcCode) q.set('lcCode', graphLcCode);
                  if (graphDataType) q.set('dataType', graphDataType);
                }
                if (slug === 'order-track') {
                  if (orderNo) q.set('orderNo', orderNo);
                  if (employeeCode) q.set('employeeCode', employeeCode);
                  if (orderTrackLcCode) q.set('lcCode', orderTrackLcCode);
                  if (designNo) q.set('designNo', designNo);
                  if (karigarCode) q.set('karigarCode', karigarCode);
                  q.set('onlyOrderTagStock', onlyOrderTagStock ? 'true' : 'false');
                  q.set('status', orderTrackStatus);
                }
                if (slug === 'mfg-inout' && karigarCode) q.set('karigarCode', karigarCode);
                if (slug === 'mfg-lot-isurec') {
                  if (partyCode) q.set('partyCode', partyCode);
                  if (karigarCode) q.set('karigarCode', karigarCode);
                  if (lotNo) q.set('lotNo', lotNo);
                  q.set('useItemLot', useItemLot ? 'true' : 'false');
                }
                if (slug === 'mfg-ledger') {
                  if (ledgerLcCode) q.set('lcCode', ledgerLcCode);
                  if (acGroup) q.set('acGroup', acGroup);
                  if (khataNo) q.set('khataNo', khataNo);
                  q.set('includeZero', includeZero ? 'true' : 'false');
                }
                if (slug === 'scheme-monthly') {
                  if (schemeCode) q.set('schemeCode', schemeCode);
                  if (schemeLcCode) q.set('lcCode', schemeLcCode);
                  q.set('withAdjScheme', withAdjScheme ? 'true' : 'false');
                }
                if (slug === 'dhiran-report' || slug === 'loan-report') {
                  if (dhrnMode) q.set('mode', dhrnMode);
                  if (loanType) q.set('loanType', loanType);
                  if (packetNo) q.set('packetNo', packetNo);
                  if (refNo) q.set('refNo', refNo);
                  if (refAc) q.set('refAc', refAc);
                }
                if (slug === 'order-lot-zoom' && lotNo) q.set('lotNo', lotNo);
                window.open(`/api/reports/${slug}/export.xlsx?${q.toString()}`, '_blank');
              }}
            >
              Excel
            </button>
          </div>
          <Table
            rows={v}
            onRowClick={
              slug === 'entry-check'
                ? loadEntryCheckDetail
                : slug === 'point-report'
                  ? loadPointReportDetail
                  : slug === 'design-move'
                    ? loadDesignMoveDetail
                    : slug === 'consi-report'
                      ? loadConsiDetail
                      : slug === 'mfg-ledger'
                        ? loadMfgLedgerDetail
                        : undefined
            }
          />
        </div>
      ))}
      {(slug === 'entry-check' ||
        slug === 'point-report' ||
        slug === 'design-move' ||
        slug === 'consi-report' ||
        slug === 'mfg-ledger') &&
        (detailRows.length > 0 || detailErr) && (
          <div className="panel" style={{ overflow: 'auto' }}>
            <div className="toolbar">
              <h2 style={{ margin: 0 }}>
                {slug === 'point-report'
                  ? 'Point Detail'
                  : slug === 'design-move'
                    ? 'Design Move Detail'
                    : slug === 'consi-report'
                      ? 'Consi Detail'
                      : slug === 'mfg-ledger'
                        ? 'Mfg Ledger Detail'
                        : 'Entry Check Detail'}
              </h2>
              <button className="ghost" onClick={() => setDetailRows([])}>
                Clear detail
              </button>
            </div>
            {detailErr && <div className="msg err">{detailErr}</div>}
            {detailRows.length > 0 && <Table rows={detailRows} />}
          </div>
        )}
      {data && arrays.length === 0 && scalars.length === 0 && (
        <pre>{JSON.stringify(data, null, 2)}</pre>
      )}
    </div>
  );
}
