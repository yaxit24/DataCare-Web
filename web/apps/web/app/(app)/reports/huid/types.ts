/** Shared types for the HuId Report screen (desktop RP_HUID, /reports/huid). */

export type HuidView = 'in' | 'out' | 'stock';

/** The desktop's three view buttons (RP_HUID.cs:1121 `BtnStock.Text = "&Stock Tag";`, :1177, :1149). */
export const HUID_VIEWS: ReadonlyArray<{ view: HuidView; caption: string; key: string }> = [
  { view: 'stock', caption: 'Stock Tag', key: 'KeyS' },
  { view: 'in', caption: 'In Tag', key: 'KeyI' },
  { view: 'out', caption: 'Out Tag', key: 'KeyO' },
];

export interface HuidColumn {
  key: string;
  header: string;
  hidden: boolean;
  total: boolean;
}

export interface HuidRow {
  coCode: string | null;
  vchTyp: string | null;
  vchNo: string | null;
  vchDate: string | null;
  stkDate: string | null;
  tagNo: string;
  itCode: string | null;
  counter: string | null;
  qty: number;
  pcs: string;
  grwt: string;
  netWt: string;
  huId: string | null;
  huWt: string;
  huId2: string | null;
  huWt2: string;
  huId3: string | null;
  huWt3: string;
  huId4: string | null;
  huWt4: string;
  krName: string;
  book: string | null;
  bookName: string | null;
  itRemark: string | null;
  tagId: string | null;
  prCode: string | null;
  grCode: string | null;
}

export interface HuidTotals {
  qty: number;
  pcs: string;
  grwt: string;
  netWt: string;
  huWt: string;
  huWt2: string;
  huWt3: string;
  huWt4: string;
}

export interface HuidResult {
  view: HuidView;
  from: string;
  to: string;
  columns: HuidColumn[];
  rows: HuidRow[];
  totals: HuidTotals;
}

/** The totals row keys in desktop column order (RP_HUID.cs:2068-2096). */
export const HUID_TOTAL_KEYS = [
  'qty',
  'pcs',
  'grwt',
  'netWt',
  'huWt',
  'huWt2',
  'huWt3',
  'huWt4',
] as const;

export type HuidHallmark = 'all' | 'with' | 'without';

export interface HuidFilters {
  fromDate: string;
  toDate: string;
  itemType: string;
  product: string;
  group: string;
  tagNo: string;
  acCode: string;
  hallmark: HuidHallmark;
  search: string;
}

export interface HelpRow {
  code: string;
  name: string;
}
