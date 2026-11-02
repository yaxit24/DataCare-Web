import { toIsoDate } from '@datacare/core';
import { withTxBudget, SNAPSHOT_READ } from '../shared/txBudget.js';
import { escapeHtml } from './render.js';
import type { XlsxSheet } from './xlsx.js';
import { gstCompanyNameTx, gstGstr3bTx, gstHsnRowsTx, gstTaxRowsTx } from './gstReportQueries.js';
import { presentGstr3b, presentHsn, presentTaxSection } from './gstReportSections.js';
import {
  GstReportRequestError,
  type GstReportInput,
  type GstReportResult,
  type GstReportScope,
  type GstSection,
  type GstView,
} from './gstReportTypes.js';

const VIEWS = new Set<GstView>(['gstr1', 'gstr2', 'gstr3b']);
const SECTIONS = new Set<GstSection>([
  'B2B',
  'B2CL',
  'B2CS',
  'CDNR',
  'CDNUR',
  'AT',
  'ATADJ',
  'HSN',
]);
const BLOCKED = new Set(['EXP', 'EXEMP', 'DOCS', 'TCS']);
const GSTR2_SUPPORTED = new Set<GstSection>(['B2B', 'B2CL', 'B2CS', 'CDNR', 'CDNUR']);

const ALLOWED_QUERY_FIELDS = new Set([
  'view',
  'section',
  'fromDate',
  'toDate',
  'bookCode',
  'partyCode',
  'acCode', // shared report-filter alias for Party
  'lcCode', // validated by the central business-scope guard before this parser
]);

function scalar(query: Record<string, unknown>, field: string, max?: number): string | undefined {
  const raw = query[field];
  if (raw == null || raw === '') return undefined;
  if (typeof raw !== 'string') {
    throw new GstReportRequestError('invalid-query', 400, { field });
  }
  const value = raw.trim();
  if (!value) return undefined;
  if (max != null && value.length > max) {
    throw new GstReportRequestError('invalid-query', 400, { field, maxLength: max });
  }
  return value;
}

function date(value: unknown): string {
  try {
    const parsed = toIsoDate(value);
    if (!parsed) throw new RangeError('date is required');
    return parsed;
  } catch {
    throw new GstReportRequestError('invalid-date', 400);
  }
}

/** Validate the canonical query before any report SQL executes. */
export function parseGstReportQuery(
  scope: GstReportScope,
  query: Record<string, unknown>,
): GstReportInput {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear) {
    throw new GstReportRequestError('scope-incomplete', 400);
  }
  const unknown = Object.keys(query).filter((field) => !ALLOWED_QUERY_FIELDS.has(field));
  if (unknown.length) {
    throw new GstReportRequestError('invalid-query', 400, { fields: unknown.sort() });
  }
  const view = (scalar(query, 'view') ?? '').toLowerCase() as GstView;
  if (!VIEWS.has(view)) throw new GstReportRequestError('invalid-view', 400, { view: query.view });
  const rawSection = (scalar(query, 'section') ?? '').toUpperCase();
  let section: GstSection | undefined;
  if (view !== 'gstr3b') {
    if (!rawSection) throw new GstReportRequestError('missing-section', 400);
    if (BLOCKED.has(rawSection)) {
      throw new GstReportRequestError('section-not-supported', 422, { view, section: rawSection });
    }
    if (!SECTIONS.has(rawSection as GstSection)) {
      throw new GstReportRequestError('invalid-section', 400, { section: rawSection });
    }
    section = rawSection as GstSection;
    if (view === 'gstr2' && !GSTR2_SUPPORTED.has(section)) {
      throw new GstReportRequestError('section-not-supported', 422, { view, section });
    }
  } else if (rawSection) {
    throw new GstReportRequestError('invalid-section', 400, { view, section: rawSection });
  }
  const fromDate = date(query.fromDate);
  const toDate = date(query.toDate);
  if (fromDate > toDate) throw new GstReportRequestError('invalid-date-range', 400);
  // RP_GST sends both dates through DC_Main.SetDate before querying (RP_GST.cs:3033-3063).
  // The exact desktop refusal text is not in this form, but a report must never silently widen into
  // another financial year. Enforce the selected session year's April-March bounds at the API edge.
  const year = /^(\d{4})-(\d{4})$/.exec(scope.coYear);
  if (!year || Number(year[2]) !== Number(year[1]) + 1) {
    throw new GstReportRequestError('scope-incomplete', 400, { field: 'coYear' });
  }
  const fiscalFrom = `${year[1]}-04-01`;
  const fiscalTo = `${year[2]}-03-31`;
  if (fromDate < fiscalFrom || toDate > fiscalTo) {
    throw new GstReportRequestError('date-outside-year', 400, { fiscalFrom, fiscalTo });
  }
  const partyCode = scalar(query, 'partyCode', 8);
  const acCode = scalar(query, 'acCode', 8);
  if (partyCode && acCode && partyCode !== acCode) {
    throw new GstReportRequestError('invalid-query', 400, {
      fields: ['partyCode', 'acCode'],
    });
  }
  return {
    ...scope,
    view,
    section,
    fromDate,
    toDate,
    bookCode: scalar(query, 'bookCode', 3),
    partyCode: partyCode ?? acCode,
  };
}

/** Build one report from one tenant-bound REPEATABLE READ snapshot. */
export async function gstReport(prisma: any, input: GstReportInput): Promise<GstReportResult> {
  return withTxBudget(prisma, input.tenantId, SNAPSHOT_READ, async (tx) => {
    const companyName = await gstCompanyNameTx(tx, input);
    let result: GstReportResult;
    if (input.view === 'gstr3b') {
      result = presentGstr3b(await gstGstr3bTx(tx, input));
    } else if (input.section === 'HSN') {
      result = presentHsn(await gstHsnRowsTx(tx, input));
    } else {
      result = presentTaxSection(input.view, input.section!, await gstTaxRowsTx(tx, input));
    }
    result.metadata = {
      ...result.metadata,
      companyName,
      fromDate: input.fromDate,
      toDate: input.toDate,
      blockedSections:
        input.view === 'gstr1'
          ? ['EXP', 'EXEMP', 'DOCS', 'TCS']
          : input.view === 'gstr2'
            ? ['AT', 'ATADJ', 'HSN', 'EXP', 'EXEMP', 'DOCS', 'TCS']
            : ['unsupported GSTR-3B rows are listed in blockedRows'],
    };
    return result;
  });
}

export function gstReportSheet(report: GstReportResult): XlsxSheet {
  return {
    name: report.section ?? report.view.toUpperCase(),
    columns: report.columns.map((column) => ({
      key: column.key,
      header: column.header,
      type: 'text' as const,
      width: Math.min(Math.max(column.header.length + 2, 10), 30),
    })),
    rows: report.rows,
    totals: report.totals,
  };
}

/** Semantic print layout: source title, exact visible column captions/order, and the same display cells as JSON/CSV. */
export function gstReportHtml(report: GstReportResult): string {
  const e = (value: unknown) => escapeHtml(value);
  const head = report.columns.map((column) => `<th>${e(column.header)}</th>`).join('');
  const body = report.rows
    .map(
      (row) =>
        `<tr>${report.columns.map((column) => `<td>${e(row[column.key] ?? '')}</td>`).join('')}</tr>`,
    )
    .join('');
  const totals = report.columns
    .map(
      (column, index) => `<td>${e(report.totals[column.key] ?? (index === 0 ? 'TOTAL' : ''))}</td>`,
    )
    .join('');
  return `<!doctype html><html><head><meta charset="utf-8"><title>${e(report.title)}</title><style>
body{font:11px Arial,sans-serif;color:#111}h1{font-size:17px;margin:0 0 4px}.meta{margin-bottom:10px}table{border-collapse:collapse;width:100%}th,td{border:1px solid #777;padding:4px;vertical-align:top}th{background:#eee;text-align:left}tfoot{font-weight:bold}</style></head><body>
<h1>${e(report.title)}</h1><div class="meta">${e(report.metadata.companyName)} · ${e(report.metadata.fromDate)} to ${e(report.metadata.toDate)}</div>
<table><thead><tr>${head}</tr></thead><tbody>${body}</tbody><tfoot><tr>${totals}</tr></tfoot></table></body></html>`;
}
