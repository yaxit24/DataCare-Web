/** Client types for Report → Purchase Rpt (desktop RP_ALL, "Purchase Rpt" caption). Mirrors the API contract. */
export type PurchaseMode =
  'report' | 'register' | 'item' | 'bill' | 'party' | 'group' | 'party-summary';

/** The seven PanelPurc buttons, with their desktop captions (RP_ALL.cs:6704-6707). */
export const PURCHASE_MODES: ReadonlyArray<{ value: PurchaseMode; label: string }> = [
  { value: 'report', label: 'Purc Report' },
  { value: 'register', label: 'Purc Reg' },
  { value: 'item', label: 'Item Wise' },
  { value: 'bill', label: 'Purchase Bill' },
  { value: 'party', label: 'Party Purc' },
  { value: 'group', label: 'Group Purc' },
  { value: 'party-summary', label: 'Party Summ' },
];

/** cboItemTyp items (RP_ALL.cs:7165-7172); the formula takes the first letter. */
export const ITEM_TYPES: ReadonlyArray<{ value: string; label: string }> = [
  { value: '', label: 'All' },
  { value: 'G', label: 'Gold' },
  { value: 'S', label: 'Silver' },
  { value: 'D', label: 'Diamond' },
  { value: 'R', label: 'Real Stone' },
  { value: 'E', label: 'Emitation' },
  { value: 'O', label: 'Other' },
  { value: 'P', label: 'Platinum' },
];

export interface PurchaseFilters {
  mode: PurchaseMode;
  fromDate: string;
  toDate: string;
  lcCode: string;
  coBook: string;
  prCode: string;
  grCode: string;
  acCode: string;
  city: string;
  area: string;
  itemType: string;
}

export type ColumnKind = 'text' | 'date' | 'money' | 'weight' | 'pcs' | 'rate';
export interface PurchaseColumn {
  key: string;
  caption: string;
  kind: ColumnKind;
  level: 'voucher' | 'line' | 'sub';
  slot?: string;
}
/** One printed line: `_band` is its label, `_kind` its sort (a row level, a group band, a total). */
export type PurchaseLine = Record<string, string> & { _band?: string; _kind?: string };

export interface PurchaseSelection {
  voucherCount: number;
  netAmt: number;
  taxAmt: number;
  totAmt: number;
  fine: number | null;
  nwt: number | null;
}

export interface PurchaseResult {
  mode: PurchaseMode;
  caption: string;
  template: string;
  title: string;
  columns: PurchaseColumn[];
  table: { lines: PurchaseLine[] };
  selection: PurchaseSelection;
  voucherCount: number;
  ignoredFilters: string[];
  cite: string;
}

export interface PurchaseOptions {
  cities: string[];
  areas: string[];
}
