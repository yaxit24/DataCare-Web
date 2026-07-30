/**
 * The shared report filter matrix — `RP_ALL.cs`.
 *
 * `RP_ALL` is not one report: it is a launcher with 72 buttons, each setting a Crystal record-selection
 * formula over a different base table while reusing ONE filter panel. Extracting every formula gives the
 * complete dimension list with the exact column each control drives, and how often it appears:
 *
 *   tBookCode   -> <data>.CO_BOOK                              59 reports
 *   tAcCode     -> <data>.AC_CODE  (AD_OS/AD_DATA: MEMB_CODE)  58
 *   tLcCode     -> <data>.LC_CODE                              58
 *   cboCity     -> AC_MAST.AC_CITY   (schemes: AD_MEMB.AC_CITY) 57
 *   cboArea     -> AC_MAST.AC_AREA   (schemes: AD_MEMB.AC_AREA) 57
 *   tItCode     -> ITEM_MAST.PR_CODE (schemes: AD_OS.SCHM_CODE) 55
 *   cboItemTyp  -> ITEM_MAST.IT_TYPE                           33
 *   tGrCode     -> ITEM_MAST.GR_CODE (rate cut: AC_ANGDIYA)     30
 *   cboState    -> AC_MAST.AC_STATE                            15
 *   cboEmploy   -> <data>.EMP_CODE                             11
 *   tCustName   -> SL_ORD_DATA.AC_NAME                          8
 *
 * Two control names are misleading and are NOT what they suggest:
 *
 *  * `tItCode` drives `ITEM_MAST.PR_CODE` — the PRODUCT code, not the item code.
 *  * `tGrCode` drives `ITEM_MAST.GR_CODE` on most reports but `RATE_CUT_DATA.AC_ANGDIYA` on the rate-cut
 *    family — one control reused for a different dimension. Renaming either to match the other would filter
 *    the wrong column on seven reports.
 *
 * Every predicate is guarded: the desktop appends it only when the control is non-blank, so a blank filter
 * means "all" rather than "match empty".
 */

/** Operator-supplied filter values. Blank or absent means the dimension is not applied. */
export interface ReportFilters {
  /** Party / member code — `<data>.AC_CODE`, or `MEMB_CODE` on the scheme tables. */
  acCode?: string;
  /** Location — `<data>.LC_CODE`. Narrows within the session's company. */
  lcCode?: string;
  /**
   * Book — `<data>.CO_BOOK`, the desktop's `tBookCode`.
   *
   * Deliberately NOT named after the session scope parameter of the same meaning: reusing that name made the
   * filter collide with book-access validation, which rejected the request with `book-unavailable` before the
   * report ever ran.
   */
  bookCode?: string;
  /** `AC_MAST.AC_AREA` (or `AD_MEMB.AC_AREA`). */
  area?: string;
  /** `AC_MAST.AC_CITY` (or `AD_MEMB.AC_CITY`). */
  city?: string;
  /** `AC_MAST.AC_STATE`. */
  state?: string;
  /** `ITEM_MAST.GR_CODE`, or `AC_ANGDIYA` where the report binds it there. */
  grCode?: string;
  /** `ITEM_MAST.PR_CODE` — the desktop's `tItCode`, which is a PRODUCT code. */
  prCode?: string;
  /** `ITEM_MAST.IT_TYPE`. Stored as a single character. */
  itType?: string;
  /** `<data>.EMP_CODE`. */
  empCode?: string;
  /** `SL_ORD_DATA.AC_NAME`. */
  custName?: string;
}

export const REPORT_FILTER_KEYS = [
  'acCode',
  'lcCode',
  'bookCode',
  'area',
  'city',
  'state',
  'grCode',
  'prCode',
  'itType',
  'empCode',
  'custName',
] as const satisfies readonly (keyof ReportFilters)[];

export type ReportFilterKey = (typeof REPORT_FILTER_KEYS)[number];

/**
 * Which table alias each dimension group resolves against for one report.
 *
 * A report can only offer a dimension it actually joins: a stock listing with no `ITEM_MAST` join cannot
 * filter by group. Absent aliases therefore make the dimension UNSUPPORTED rather than silently ignored —
 * see `unsupportedFilters`.
 */
/** The four dimensions that live on a report's own voucher table rather than on a joined master. */
export type DataFilterColumn = 'AC_CODE' | 'LC_CODE' | 'CO_BOOK' | 'EMP_CODE';

const ALL_DATA_COLUMNS: readonly DataFilterColumn[] = ['AC_CODE', 'LC_CODE', 'CO_BOOK', 'EMP_CODE'];

export interface FilterBinding {
  /**
   * Alias (or quoted table name, for an unaliased `FROM`) of the voucher/data table.
   *
   * Which of the four data dimensions it actually carries is declared by `dataColumns`, because they are NOT
   * universal: `AC_DATA` and `BAR_DETL` have no `EMP_CODE`, and `RATE_MAST` has no `AC_CODE`. Emitting a
   * predicate on a column the table lacks would throw at runtime — strictly worse than not filtering.
   */
  data?: string;
  /**
   * Data-table columns present, verified against `information_schema`. Defaults to all four when omitted,
   * which is correct only for tables that really have all four.
   */
  dataColumns?: readonly DataFilterColumn[];
  /** Alias of `AC_MAST` (area, city, state). */
  party?: string;
  /** Alias of `ITEM_MAST` (group, product, item type). */
  item?: string;
  /** Alias of `AD_MEMB` where the report filters scheme members instead of accounts. */
  member?: string;
  /**
   * Column the party dimension uses on the data table instead of `AC_CODE`. `AD_OS` and `AD_DATA` use
   * `MEMB_CODE` for the same filter control.
   */
  partyCodeColumn?: string;
  /**
   * Column `grCode` binds to on the data table instead of `ITEM_MAST.GR_CODE`. The rate-cut family binds
   * `AC_ANGDIYA` here — the same control, a different dimension.
   */
  grCodeDataColumn?: string;
  /** Alias of `SL_ORD_DATA` (or any table carrying `AC_NAME`) for the customer-name filter. */
  custNameAlias?: string;
}

/** Normalise a filter value: trim, and treat blank as absent exactly as the desktop's guard does. */
const val = (v: unknown): string => String(v ?? '').trim();

/**
 * Which of the supplied filters this report cannot honour.
 *
 * Returned so the caller can REFUSE the request rather than run it. Silently dropping a filter is the worst
 * option: the operator would read a wider result set as if it were filtered. The desktop avoids the problem
 * by not offering the control on that button; the web serves many reports from one screen, so it has to say
 * so explicitly.
 */
export function unsupportedFilters(f: ReportFilters, b: FilterBinding): ReportFilterKey[] {
  const out: ReportFilterKey[] = [];
  const need = (key: ReportFilterKey, ok: boolean) => {
    if (val(f[key]) && !ok) out.push(key);
  };
  const dataCols = new Set(b.dataColumns ?? ALL_DATA_COLUMNS);
  const hasData = (c: DataFilterColumn) => Boolean(b.data) && dataCols.has(c);
  // The party filter may target a different column (schemes use MEMB_CODE), which is always considered
  // present when the binding names it explicitly.
  need('acCode', Boolean(b.data) && (Boolean(b.partyCodeColumn) || dataCols.has('AC_CODE')));
  need('lcCode', hasData('LC_CODE'));
  need('bookCode', hasData('CO_BOOK'));
  need('empCode', hasData('EMP_CODE'));
  need('area', Boolean(b.party || b.member));
  need('city', Boolean(b.party || b.member));
  need('state', Boolean(b.party));
  need('grCode', Boolean(b.item || b.grCodeDataColumn));
  need('prCode', Boolean(b.item));
  need('itType', Boolean(b.item));
  need('custName', Boolean(b.custNameAlias));
  return out;
}

/**
 * Build the filter predicate, pushing values onto the caller's parameter array.
 *
 * Mirrors `dateWhere`: the caller owns the array (report builders assemble their own positional parameters),
 * and the returned SQL references the indices actually used. Unsupported dimensions are ignored HERE by
 * construction, so callers must check `unsupportedFilters` first.
 */
export function filterWhere(f: ReportFilters, b: FilterBinding, params: unknown[]): string {
  let sql = '';
  const push = (expr: string, value: string) => {
    params.push(value);
    sql += ` AND ${expr}=$${params.length}`;
  };

  if (b.data) {
    const cols = new Set(b.dataColumns ?? ALL_DATA_COLUMNS);
    const partyCol = b.partyCodeColumn ?? 'AC_CODE';
    if (val(f.acCode) && (b.partyCodeColumn || cols.has('AC_CODE'))) {
      push(`${b.data}."${partyCol}"`, val(f.acCode));
    }
    if (val(f.lcCode) && cols.has('LC_CODE')) push(`${b.data}."LC_CODE"`, val(f.lcCode));
    if (val(f.bookCode) && cols.has('CO_BOOK')) push(`${b.data}."CO_BOOK"`, val(f.bookCode));
    if (val(f.empCode) && cols.has('EMP_CODE')) push(`${b.data}."EMP_CODE"`, val(f.empCode));
  }
  // Schemes filter area/city on AD_MEMB; everything else on AC_MAST. Only one is ever bound.
  const geo = b.party ?? b.member;
  if (geo) {
    if (val(f.area)) push(`${geo}."AC_AREA"`, val(f.area));
    if (val(f.city)) push(`${geo}."AC_CITY"`, val(f.city));
  }
  if (b.party && val(f.state)) push(`${b.party}."AC_STATE"`, val(f.state));
  if (val(f.grCode)) {
    // The rate-cut family binds this control to AC_ANGDIYA on the data table instead of the item group.
    if (b.grCodeDataColumn && b.data) {
      push(`${b.data}."${b.grCodeDataColumn}"`, val(f.grCode));
    } else if (b.item) {
      push(`${b.item}."GR_CODE"`, val(f.grCode));
    }
  }
  if (b.item) {
    // `tItCode` drives PR_CODE — the product code, despite the control's name.
    if (val(f.prCode)) push(`${b.item}."PR_CODE"`, val(f.prCode));
    // IT_TYPE holds a single character; the desktop stores Strings.Mid(cboItemTyp.Text, 1, 1).
    if (val(f.itType)) push(`${b.item}."IT_TYPE"`, val(f.itType).slice(0, 1));
  }
  if (b.custNameAlias && val(f.custName)) {
    push(`${b.custNameAlias}."AC_NAME"`, val(f.custName));
  }
  return sql;
}

/** Dimensions this report can honour — used to render only the filters that apply. */
export function supportedFilters(b: FilterBinding): ReportFilterKey[] {
  const all: ReportFilters = Object.fromEntries(
    REPORT_FILTER_KEYS.map((k) => [k, 'x']),
  ) as ReportFilters;
  const bad = new Set(unsupportedFilters(all, b));
  return REPORT_FILTER_KEYS.filter((k) => !bad.has(k));
}

/** Read filters from a request query, keeping only well-formed short codes. */
export function readFilters(q: Record<string, string | undefined>): ReportFilters {
  const take = (v: string | undefined, max: number): string | undefined => {
    const s = val(v);
    return s ? s.slice(0, max) : undefined;
  };
  return {
    acCode: take(q.acCode, 24),
    lcCode: take(q.lcCode, 8),
    bookCode: take(q.bookCode, 8),
    area: take(q.area, 40),
    city: take(q.city, 40),
    state: take(q.state, 40),
    grCode: take(q.grCode, 12),
    prCode: take(q.prCode, 12),
    itType: take(q.itType, 1),
    empCode: take(q.empCode, 12),
    custName: take(q.custName, 60),
  };
}

/** A filter the report cannot honour. A client mistake, so it must surface as 400 rather than 500. */
export class ReportFilterError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'ReportFilterError';
  }
}

/**
 * The single source of truth for which report honours which dimension.
 *
 * Both the builders and `GET /reports/:report/filters` read THIS map, so the capability the API advertises
 * and the predicate the query actually applies cannot drift apart. That drift is the failure mode worth
 * designing out: advertising a dimension the builder ignores would show the operator an unfiltered result
 * set as though it were filtered.
 *
 * Every entry was verified by READING the builder's SQL, not by scanning for `FROM "T" alias`. Three things a
 * scan got wrong:
 *
 *  * `billOutstanding` and `cashBook` reference `AC_MAST m` inside a CORRELATED SUBQUERY, so `m` is not in the
 *    outer WHERE scope and a party predicate on it would not compile. They are therefore NOT bound.
 *  * `purchaseByParty` resolves to `reports3.ts`, whose `FROM "PR_DATA"` is UNALIASED — a second function of
 *    the same name in `reports10.ts` is aliased `pd` and is not the one registered.
 *  * `dataColumns` differs per table, verified against `information_schema`: `AC_DATA` and `BAR_DETL` have no
 *    `EMP_CODE`, `RATE_MAST` has no `AC_CODE`.
 */
export const REPORT_FILTER_BINDINGS: Record<string, FilterBinding> = {
  // FROM "BAR_DETL" a … LEFT JOIN "ITEM_MAST" b — the tag estimate's own aliases.
  'tag-estimate': { data: 'a', item: 'b' },
  // FROM "SL_DETL_RTN" r LEFT JOIN "AC_MAST" m — both real outer joins.
  'sales-return-register': { data: 'r', party: 'm' },
  // FROM "BAR_DETL" b LEFT JOIN "ITEM_MAST" i.
  'stock-valuation': { data: 'b', dataColumns: ['AC_CODE', 'LC_CODE', 'CO_BOOK'], item: 'i' },
  // FROM "BAR_DETL" d LEFT JOIN "ITEM_MAST" i.
  'item-group-stock': { data: 'd', dataColumns: ['AC_CODE', 'LC_CODE', 'CO_BOOK'], item: 'i' },
  // FROM "PR_DATA" with NO alias, so the table name qualifies the columns.
  'purchase-by-party': { data: '"PR_DATA"' },
};

/**
 * Refuse anything this report cannot honour, then build the predicate — one call so the two can never be
 * done separately.
 */
export function applyFilters(
  slug: string,
  filters: ReportFilters | undefined,
  params: unknown[],
): string {
  const binding = REPORT_FILTER_BINDINGS[slug];
  // An unbound report offers no shared dimensions; a filter sent to it is refused, not ignored.
  const b = binding ?? {};
  const f = filters ?? {};
  const bad = unsupportedFilters(f, b);
  if (bad.length) {
    throw new ReportFilterError(`this report cannot filter by: ${bad.join(', ')}`);
  }
  return filterWhere(f, b, params);
}
