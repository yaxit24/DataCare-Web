/** Tag Stock (desktop RP_TAG) screen types. The API answers its own column list, so grid, footer and exports agree. */
export type TagStockTab = 'in' | 'out' | 'stock' | 'mrp' | 'apr' | 'all';
export type TagStockView = 'tag' | 'item' | 'product';
export interface TagStockColumn {
  key: string;
  header: string;
  kind: 'text' | 'date' | 'int' | 'wt' | 'amt';
  total?: boolean;
}
export type TagStockRow = Record<string, string | number | null> & { tagNo?: string };
export interface TagStockReport {
  tab: TagStockTab;
  view: TagStockView;
  columns: TagStockColumn[];
  rows: TagStockRow[];
  totals: Record<string, number>;
  hasEmpIssue?: boolean;
}
/** The selectors of the form (RP_TAG.cs:2300-2900). Dates are typed as dd/mm/yyyy like the desktop masks. */
export interface TagStockFilters {
  /** 'tag' = RptType "Tag Wise"; 'summ' = "Tag Summ". */
  rptType: 'tag' | 'summ';
  from: string;
  to: string;
  search: string;
  /** First letter of the It Type list: G, S, D, R, E, O, P or blank. */
  itType: string;
  itCode: string;
  prCode: string;
  grCode: string;
  tagNo: string;
  size: string;
  lcCode: string;
  bookCode: string;
}
export const IT_TYPES: Array<{ value: string; label: string }> = [
  { value: '', label: '' },
  { value: 'G', label: 'Gold' },
  { value: 'S', label: 'Silver' },
  { value: 'D', label: 'Diamond' },
  { value: 'R', label: 'Real Stone' },
  { value: 'E', label: 'Emitation' },
  { value: 'O', label: 'Other' },
  { value: 'P', label: 'Platinum' },
];
