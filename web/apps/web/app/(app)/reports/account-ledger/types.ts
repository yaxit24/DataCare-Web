/** Client types for the Account Ledger report (desktop RP_LEDR). Mirrors the API result contract. */
export type AccountLedgerView = 'summary' | 'detail' | 'voucher-summary' | 'ageing';
export type FineType = 'G' | 'S';

export interface MetalTriple {
  amount: number;
  goldFine: number;
  silverFine: number;
}

export interface SummaryRow {
  srNo: number;
  acCode: string;
  acName: string | null;
  mobile: string | null;
  drAmt: number;
  crAmt: number;
  drGold: number;
  crGold: number;
  drSilver: number;
  crSilver: number;
  refBy: string | null;
  city: string | null;
  khataNo: string | null;
}

export interface DetailRow {
  srNo: number;
  book: string | null;
  bookName: string | null;
  vchNo: string | null;
  vchType: string | null;
  date: string | null;
  billNo: string | null;
  party: string | null;
  crAmt: number;
  drAmt: number;
  balAmt: number;
  amtSide: 'Cr' | 'Dr' | '';
  crGold: number;
  drGold: number;
  balGold: number;
  goldSide: 'Cr' | 'Dr' | '';
  crSilver: number;
  drSilver: number;
  balSilver: number;
  silverSide: 'Cr' | 'Dr' | '';
  remark: string | null;
}

export interface AgeingRow {
  acCode: string;
  acName: string | null;
  amt15: number;
  amt30: number;
  amt45: number;
  amt60: number;
  amt90: number;
  amt120: number;
  amt150: number;
  amt151: number;
  amt: number;
  wt15: number;
  wt30: number;
  wt45: number;
  wt60: number;
  wt90: number;
  wt120: number;
  wt150: number;
  wt151: number;
  wt: number;
}

export interface AccountLedgerResult {
  view: AccountLedgerView;
  period: { fromDate: string | null; toDate: string | null };
  fineType?: FineType;
  halfMonth?: boolean;
  account?: {
    acCode: string;
    acName: string | null;
    group: string | null;
    city: string | null;
    mobile: string | null;
  };
  opening: MetalTriple;
  rows: Array<SummaryRow | DetailRow | AgeingRow>;
  totals: Record<string, number | string>;
  closing: MetalTriple;
}

export interface LedgerFilters {
  view: AccountLedgerView;
  acCode: string;
  fromDate: string;
  toDate: string;
  withZero: boolean;
  fineType: FineType;
}
