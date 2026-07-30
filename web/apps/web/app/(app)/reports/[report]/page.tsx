'use client';
import { useCallback, useEffect, useState } from 'react';
import { useParams } from 'next/navigation';
import { get, downloadPdf, downloadCsv, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';

const TITLES: Record<string, string> = {
  // Desktop menu names: 'Tag Estmate' (its own misspelling) and 'Order Zoom'.
  'tag-estimate': 'Tag Estimate',
  'order-lot-zoom': 'Order Zoom (Lot Movement)',
  'sales-register': 'Sales Register',
  'purchase-register': 'Purchase Register',
  'day-book': 'Day Book',
  // RP_CASH_BANK, reached by Ctrl+F11 on the desktop (MDI_FORM.cs handler F11CtrlCashBank).
  'cash-book': 'Cash / Bank Book',
  'cash-day-summary': 'Cash Day Summary',
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

function Table({ rows }: { rows: Record<string, any>[] }) {
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
          <tr key={i}>
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
  // The eleven shared RP_ALL panel dimensions. Only those the report can honour are rendered: the API
  // REFUSES an unsupported filter rather than dropping it, so offering one would just produce an error.
  const [filters, setFilters] = useState<Record<string, string>>({});
  const [supported, setSupported] = useState<string[] | null>(null);

  useEffect(() => {
    let live = true;
    setSupported(null);
    setFilters({});
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

  const run = useCallback(async () => {
    setErr('');
    setData(null);
    const ep = endpointFor(slug, coYear, acCode, fromDate, toDate, {
      ...filters,
      lotNo,
      tagNo,
      ...(slug === 'tag-estimate' ? { direction } : {}),
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
  }, [slug, coYear, acCode]);

  useEffect(() => {
    if (coYear && slug !== 'account-ledger') run();
  }, [coYear, slug, run]);

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
                window.open(`/api/reports/${slug}/export.xlsx?${q.toString()}`, '_blank');
              }}
            >
              Excel
            </button>
          </div>
          <Table rows={v} />
        </div>
      ))}
      {data && arrays.length === 0 && scalars.length === 0 && (
        <pre>{JSON.stringify(data, null, 2)}</pre>
      )}
    </div>
  );
}
