export type Dimension =
  'item' | 'product' | 'group' | 'design' | 'safe' | 'counter' | 'trading' | 'size';

/** Desktop button order (RP_STOCK tab order): Item, Product, Group, Design, Safe, Counter, Trading, Size. */
export const DIMENSIONS: Array<{ value: Dimension; label: string }> = [
  { value: 'item', label: 'Item' },
  { value: 'product', label: 'Product' },
  { value: 'group', label: 'Group' },
  { value: 'design', label: 'Design' },
  { value: 'safe', label: 'Safe' },
  { value: 'counter', label: 'Counter' },
  { value: 'trading', label: 'Trading' },
  { value: 'size', label: 'Size' },
];

/** cboItemTyp items in desktop order (RP_STOCK.cs:3620-3627); the value is the filter letter. */
export const ITEM_TYPES: Array<{ value: string; label: string }> = [
  { value: '', label: '' },
  { value: 'G', label: 'Gold' },
  { value: 'S', label: 'Silver' },
  { value: 'D', label: 'Diamond' },
  { value: 'R', label: 'Real Stone' },
  { value: 'E', label: 'Emitation' },
  { value: 'O', label: 'Other' },
  { value: 'P', label: 'Platinum' },
];

export type Column = 'opening' | 'purchase' | 'inward' | 'outward' | 'sale' | 'closing';

export interface Figures {
  opPcs: number;
  opWt: number;
  prPcs: number;
  prWt: number;
  inPcs: number;
  inWt: number;
  outPcs: number;
  outWt: number;
  slPcs: number;
  slWt: number;
  clPcs: number;
  clWt: number;
  tInPcs: number;
  tInWt: number;
  tOutPcs: number;
  tOutWt: number;
}
export interface StockRow extends Figures {
  code: string;
  name: string;
  itType: string;
}
export interface StockResult {
  dimension: Dimension;
  title: string;
  weight: 'net' | 'gross';
  fromDate: string;
  toDate: string;
  rows: StockRow[];
  totals: Figures;
}
export interface MovementRow {
  vchType: string | null;
  /** The book of the voucher (CO_BOOK), which decides the entry screen a double click opens. */
  coBook?: string | null;
  partyName: string;
  vchNo: string | null;
  vchDate: string | null;
  tagNo: string | null;
  itLot: string | null;
  itName: string;
  pcs: number;
  gwt: number;
  nwt: number;
  fine: number;
  sign: '+' | '-';
}
export interface MovementResult {
  column: Column;
  rows: MovementRow[];
  totals: { pcs: number; gwt: number; nwt: number; fine: number };
}
export interface Defaults {
  /** CO_STK_MERGE: nothing opens from a movement row while merged (RP_STOCK.cs:5225). */
  companyMerge?: boolean;
  fromDate: string;
  toDate: string;
  /** What Cancel resets To to; To itself is a future voucher's date when one exists. */
  systemDate: string;
  itemType: string;
  grossWeight: boolean;
  /** ITM_WITH_LOT_STK = Y: the Safe button reads Item Lot and its drill-down shows the lot (RP_STOCK.cs:3701, :3102). */
  itemLot?: boolean;
  /** RP_STOCK.cs:3713: a movement dated after today; the screen shows `message` once on open. */
  futureVoucher: { bookName: string; vchNo: string; vchDate: string; message: string } | null;
}

export interface Filters {
  fromDate: string;
  toDate: string;
  itemType: string;
  stockType: 'all' | 'tag' | 'item';
  gross: boolean;
  grCode: string;
  prCode: string;
  itCode: string;
  designNo: string;
  safe: string;
  tblCode: string;
  tagNo: string;
  acCode: string;
}

export const EMPTY_FILTERS: Filters = {
  fromDate: '',
  toDate: '',
  itemType: 'G',
  stockType: 'all',
  gross: false,
  grCode: '',
  prCode: '',
  itCode: '',
  designNo: '',
  safe: '',
  tblCode: '',
  tagNo: '',
  acCode: '',
};

/** Summary column pairs a double click can drill into (RP_STOCK.cs:2892: any other column returns). */
export const DRILL_COLUMNS: Array<{
  column: Column;
  pcs: keyof Figures;
  wt: keyof Figures;
  caption: [string, string];
}> = [
  { column: 'opening', pcs: 'opPcs', wt: 'opWt', caption: ['OpPcs', 'OpWt'] },
  { column: 'purchase', pcs: 'prPcs', wt: 'prWt', caption: ['PrPcs', 'PrWt'] },
  { column: 'inward', pcs: 'inPcs', wt: 'inWt', caption: ['InPcs', 'InWt'] },
  { column: 'outward', pcs: 'outPcs', wt: 'outWt', caption: ['OuPcs', 'OuWt'] },
  { column: 'sale', pcs: 'slPcs', wt: 'slWt', caption: ['SlPcs', 'SlWt'] },
  { column: 'closing', pcs: 'clPcs', wt: 'clWt', caption: ['ClPcs', 'ClWt'] },
];

/** What a double click on a movement row does (GET /reports/stock-report/zoom). */
export type ZoomAnswer =
  | { action: 'none' }
  | { action: 'refuse'; message: string }
  | { action: 'open'; path: string; vchNo: string; coBook: string; coYear: string; lcCode: string };
