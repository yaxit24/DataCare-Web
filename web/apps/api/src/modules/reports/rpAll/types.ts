/**
 * Shared types of the RP_ALL report engine (WP-11).
 *
 * The desktop `RP_ALL` form (unified/src/csharp/DataCareNext/RP_ALL.cs) serves several Report-tab menus
 * with one screen: the menu caption picks a button panel (RP_ALL.cs:6658-6707), each button builds a
 * Crystal record-selection formula from the shared selectors and opens a named `.rpt` template, and the
 * template does the grouping, the column layout and the totals. The web engine splits that into:
 *
 *   selection (branch + mode)  →  adapter: parameterised read-only SQL  →  flat records
 *   records + layout           →  engine (pure): sort, group, rows, count-once totals
 *
 * so every branch (Sales first; Purchase, Approval and Order later) supplies only its layouts and its
 * query, and the grouping, totalling and formatting rules are written and tested once.
 */

/** The menu captions RP_ALL serves (RP_ALL.cs:6676-6770). Only Sales has an adapter so far. */
export type RpAllBranch = 'sales';

/** Kind of a cell: decides precision, alignment and how a total is rounded. */
export type RpAllColumnKind = 'text' | 'date' | 'money' | 'weight' | 'pcs' | 'rate';

/**
 * The record level a value belongs to. A Crystal record set joins header → line → sub-line, so a header
 * value repeats on every line record and a line value on every sub-line record. Each value is counted once
 * per distinct key of its own level (see `RpAllLayout.keys`).
 */
export type RpAllLevel = 'voucher' | 'line' | 'sub';

/** A primitive record value as the adapter returns it (numbers already parsed, dates as ISO yyyy-mm-dd). */
export type RpAllValue = string | number | null;
export type RpAllRecord = Readonly<Record<string, RpAllValue>>;

export interface RpAllColumn {
  /** Key into the record. */
  key: string;
  /** Desktop caption (template text object; `captionSource` says when it is derived instead). */
  caption: string;
  kind: RpAllColumnKind;
  level: RpAllLevel;
  /** True when the template prints a total of this column. */
  total?: boolean;
  /** 'template' = a text object of the .rpt; 'field' = no caption printed, named from the bound field. */
  captionSource?: 'template' | 'field';
}

export interface RpAllGroupLevel {
  /** Record key the template groups on (Crystal `Group ConditionField`). */
  key: string;
  /** Record keys joined with ' ' to label the group header (for example book code + book name). */
  labelKeys: readonly string[];
  /**
   * Whether the template prints sums for this group, and where: 'header' (summary in the group header,
   * as SalesItem does), 'footer' ("DATE TOTAL :"), or 'none' (header only; footer sections suppressed).
   */
  subtotal: 'header' | 'footer' | 'none';
  /** Caption printed beside a footer subtotal, verbatim. */
  subtotalCaption?: string;
  /** Map raw key values to a printed label (Crystal formula such as @ItemType). */
  labelMap?: Readonly<Record<string, string>>;
  labelDefault?: string;
}

/** One record-sort key; groups are always sorted ascending first, in group order (Crystal GroupSortField). */
export interface RpAllSortKey {
  key: string;
}

export interface RpAllLayout {
  /** Crystal template the desktop opens, without extension. */
  template: string;
  /** Title prefix the desktop passes as RptTitel ("Sales Report" → "Sales Report From d To d"). */
  titlePrefix: string;
  columns: readonly RpAllColumn[];
  groups: readonly RpAllGroupLevel[];
  /** Record sort fields applied after the group keys (Crystal RecordSortField). */
  sort: readonly RpAllSortKey[];
  /** Record keys identifying a voucher, a line and a sub-line, for count-once totals and row emission. */
  keys: { voucher: readonly string[]; line?: readonly string[]; sub?: readonly string[] };
  /** Which levels print as rows (a suppressed band is left out). */
  rowLevels: readonly RpAllLevel[];
  /** Whether the template prints a report-footer (grand total) band. */
  grandTotal: boolean;
  /** Caption of the grand-total band, verbatim, when the template prints one. */
  grandTotalCaption?: string;
  /**
   * Conditional band suppression (Crystal `EnableSuppress` condition formula): a row of that level is not
   * printed when the predicate holds. Suppression never changes a total, exactly as in Crystal.
   */
  suppress?: Partial<Record<RpAllLevel, (record: RpAllRecord) => boolean>>;
}

export interface RpAllRow {
  level: RpAllLevel;
  /** Group key values from the outermost group inwards. */
  groupPath: string[];
  /** Voucher key values (joined with '|'), for drill-down to the voucher. */
  voucherKey: string;
  cells: Record<string, RpAllValue>;
}

export interface RpAllGroup {
  depth: number;
  key: string;
  label: string;
  groupPath: string[];
  rowCount: number;
  totals: Record<string, number>;
}

export interface RpAllEngineResult {
  rows: RpAllRow[];
  groups: RpAllGroup[];
  totals: Record<string, number>;
  voucherCount: number;
}
