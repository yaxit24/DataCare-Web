import { round, PRECISION } from '@datacare/core';

/**
 * Shared types, errors and pure helpers for the Account Ledger report (desktop RP_LEDR). The dataset
 * SQL lives in accountLedgerQueries.ts and the orchestrator and request parser in accountLedgerReport.ts;
 * all three import from here so no file grows past its size budget and the pure arithmetic stays unit
 * testable in one place.
 */

export const AMT = PRECISION.amount; // 2
export const WT = PRECISION.weight; // 3

export type AccountLedgerView = 'summary' | 'detail' | 'voucher-summary' | 'ageing';
export type FineType = 'G' | 'S';

export class AccountLedgerValidationError extends Error {
  readonly statusCode = 400;
  constructor(message: string) {
    super(message);
    this.name = 'AccountLedgerValidationError';
  }
}

export class AccountNotFoundError extends Error {
  readonly statusCode = 404;
  constructor(readonly acCode: string) {
    super(`account not found: ${acCode}`);
    this.name = 'AccountNotFoundError';
  }
}

export interface LedgerScope {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  coYear?: string;
}

export interface AccountLedgerQuery {
  view: AccountLedgerView;
  acCode?: string;
  fromDate?: string;
  toDate?: string;
  dataType?: string;
  withZero?: boolean;
  openingOnly?: boolean;
  accountType?: string;
  accountGroup?: string;
  khataNo?: string;
  refAccount?: string;
  city?: string;
  area?: string;
  state?: string;
  fineType?: FineType;
  halfMonth?: boolean;
}

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

export const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};
export const txt = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s === '' ? null : s;
};
export const r2 = (n: number): number => round(n, AMT);
export const r3 = (n: number): number => round(n, WT);

/** Cr/Dr side from a signed value (Cr when positive, Dr when negative, blank at zero). */
export function sideOf(signed: number): 'Cr' | 'Dr' | '' {
  if (signed > 0) return 'Cr';
  if (signed < 0) return 'Dr';
  return '';
}

/**
 * Split a signed net into a Dr/Cr pair exactly as the desktop account summary does
 * (RP_LEDR.cs:6408/6417/6426): a negative net is shown as an absolute Dr amount, a positive net as an
 * absolute Cr amount.
 */
export function splitSigned(signed: number, dp: number): { dr: number; cr: number } {
  const v = round(signed, dp);
  if (v < 0) return { dr: round(-v, dp), cr: 0 };
  if (v > 0) return { dr: 0, cr: round(v, dp) };
  return { dr: 0, cr: 0 };
}

/** The six display components of a summary row (RP_LEDR nonzero HAVING, :6421). */
export function summaryIsZero(money: number, gold: number, silver: number): boolean {
  return r2(money) === 0 && r3(gold) === 0 && r3(silver) === 0;
}

/**
 * Attach the signed running balances the desktop detail/voucher grids keep: three independent cumulative
 * `Σ(Cr) - Σ(Dr)` totals with their Cr/Dr side (RP_LEDR.cs:6989-7160). Pure, so it is unit tested with
 * desktop-derived vectors.
 */
export function runningBalances<
  T extends {
    crAmt: number;
    drAmt: number;
    crGold: number;
    drGold: number;
    crSilver: number;
    drSilver: number;
  },
>(
  opening: MetalTriple,
  rows: T[],
): Array<
  T & {
    balAmt: number;
    amtSide: 'Cr' | 'Dr' | '';
    balGold: number;
    goldSide: 'Cr' | 'Dr' | '';
    balSilver: number;
    silverSide: 'Cr' | 'Dr' | '';
  }
> {
  let amt = round(opening.amount, AMT);
  let gold = round(opening.goldFine, WT);
  let silver = round(opening.silverFine, WT);
  return rows.map((row) => {
    amt = r2(amt + row.crAmt - row.drAmt);
    gold = r3(gold + row.crGold - row.drGold);
    silver = r3(silver + row.crSilver - row.drSilver);
    return {
      ...row,
      balAmt: amt,
      amtSide: sideOf(amt),
      balGold: gold,
      goldSide: sideOf(gold),
      balSilver: silver,
      silverSide: sideOf(silver),
    };
  });
}

/** The eight debit-ageing buckets, oldest first, matching RP_LEDR TimeLedr_Dr column order. */
export const AGE_BUCKETS = [151, 150, 120, 90, 60, 45, 30, 15] as const;

/**
 * Debit-ageing FIFO allocation (RP_LEDR.cs:9877-10282). Given each bucket's debit total and the account's
 * total credit through the as-of date, consume the oldest debit first. Returns the residual debit left in
 * each bucket, keyed by its upper-bound label (15,30,...,151 where 151 means "151 days or older"). Pure.
 */
export function ageDebitsFifo(
  bucketDebits: Record<number, number>,
  totalCredit: number,
  dp: number,
): Record<number, number> {
  let credit = round(Math.max(totalCredit, 0), dp);
  const out: Record<number, number> = {};
  for (const bucket of AGE_BUCKETS) {
    const debit = round(bucketDebits[bucket] ?? 0, dp);
    const residual = round(Math.max(debit - credit, 0), dp);
    out[bucket] = residual;
    credit = round(Math.max(credit - debit, 0), dp);
  }
  return out;
}

/** Signed money (Cr positive) and signed gold/silver fine over AC_DATA, as the desktop computes them. */
export const SIGNED_MONEY = `coalesce(sum(coalesce(d."CR_AMT",0)-coalesce(d."DR_AMT",0)),0)`;
export const SIGNED_GOLD = `coalesce(sum(CASE WHEN d."IT_TYPE"='G' THEN (CASE WHEN d."SIGN"='+' THEN coalesce(d."FINE_WT",0) ELSE -coalesce(d."FINE_WT",0) END) ELSE 0 END),0)`;
export const SIGNED_SILVER = `coalesce(sum(CASE WHEN d."IT_TYPE"='S' THEN (CASE WHEN d."SIGN"='+' THEN coalesce(d."FINE_WT",0) ELSE -coalesce(d."FINE_WT",0) END) ELSE 0 END),0)`;

/** Common AC_DATA scope predicates, binding company (+ optional location and data-type). */
export function acDataScope(
  s: LedgerScope,
  q: AccountLedgerQuery,
  params: unknown[],
  alias = 'd',
): string {
  const parts: string[] = [];
  params.push(s.coCode);
  parts.push(`${alias}."CO_CODE"=$${params.length}`);
  if (s.lcCode) {
    params.push(s.lcCode);
    parts.push(`${alias}."LC_CODE"=$${params.length}`);
  }
  // DATA_TYPE: the desktop omits the filter only for type 'C' (RP_LEDR.cs:6408). Otherwise filter exactly.
  if (q.dataType && q.dataType !== 'C') {
    params.push(q.dataType);
    parts.push(`${alias}."DATA_TYPE"=$${params.length}`);
  }
  return parts.join(' AND ');
}

/** Aggregated remarks per voucher, newline-joined in SR_NO order (REMARK_DATA is one-to-many). */
export const REMARK_JOIN = `
  LEFT JOIN LATERAL (
    SELECT string_agg(rk."VCH_REMARK", E'\\n' ORDER BY rk."SR_NO") AS remark
      FROM "REMARK_DATA" rk
     WHERE rk."CO_CODE"=d."CO_CODE" AND rk."CO_BOOK"=d."CO_BOOK" AND rk."VCH_NO"=d."VCH_NO"
  ) rem ON true`;
