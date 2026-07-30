import { withTenant } from '@datacare/db';
import { insertRowTx } from '../posting/posting.js';
import { barTagAvailableSql } from '../shared/stockSql.js';
import type { VoucherScope } from '../vouchers/numbering.js';

/**
 * Year-End Close (Phase 12 / UT) — web port of the desktop Ac_Final.cs final-accounts close
 * (Trading_Stock@18 = closing-stock valuation; AcBalInsert@139 = write opening/closing account
 * balances).
 *
 * The desktop computes per-account balances as ROUND(SUM(CR_AMT-DR_AMT),2) over AC_DATA for the
 * working year (AcBalInsert) and stamps the closing-stock value into CO_BOOK '999' (Trading_Stock).
 * Here we follow the web read-model convention used everywhere else (reports.accountBalances):
 * balance = ΣDR − ΣCR per AC_CODE (debit-positive). We then carry each non-zero account forward as
 * the *opening* of the next year: one AC_DATA leg per account, VCH_TYPE 'ACOP' (same opening voucher
 * type as finance/acOpening.postAcOpening), CO_YEAR = toYear, CO_BOOK '000'. The leg lands on the
 * Dr or Cr side per the account's own balance sign (so it is "balanced by account sign"), carrying
 * the account's net metal FINE_WT + IT_TYPE for metal accounts.
 *
 * Closing-stock fine is reported (and shown in the preview) as the net MAIN_STOCK fine for the year
 * — Σ ITM_FINE with in '+' minus out '-' (desktop Trading_Stock parity) — falling back to the
 * on-hand tag inventory (BAR_DETL minus sold) when the company has no MAIN_STOCK movements.
 *
 * The carry-forward is idempotent: a re-run first DELETEs any existing toYear ACOP '000' rows, then
 * re-writes them, so closing a year twice yields the same opening (no doubling). All writes happen
 * inside ONE withTenant transaction.
 */

/** Desktop opening voucher type — every carried AC_DATA leg is VCH_TYPE 'ACOP' (acOpening parity). */
const ACOP_TYPE = 'ACOP';
/** Carry-forward opening book. Desktop closing valuation lives in CO_BOOK '999'; the next-year
 *  opening batch we write is isolated under CO_BOOK '000' so it is idempotently replaceable. */
const YE_BOOK = '000';
/** BOOK_NAME stamped on each opening leg (matches acOpening's 'OPENING'). */
const YE_BOOK_NAME = 'OPENING';
/** All carried opening legs share one voucher number; individual legs are keyed by LD_CODE/LEDR_KEY. */
const YE_VCH_NO = '1';
/** Desktop closing-stock valuation book — excluded from the carry so injected closing stock (the
 *  balancing figure, held OUTSIDE the real ledger) is not double-counted into next year's opening.
 *  Mirrors AcBalInsert's opening query guard `AND A.CO_BOOK <> '999'`. */
const CLOSING_BOOK = '999';

const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};
const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;
const round3 = (n: number): number => Math.round((n + Number.EPSILON) * 1000) / 1000;
const pad = (v: unknown, n: number): string => String(v ?? '').padStart(n, '0');
/** SQL: numeric value of a loosely-typed (text) column — '' / null → 0. */
const NN = (c: string): string => `coalesce(NULLIF(${c}::text,'')::numeric,0)`;

/** One account's closing position for the From Year (the would-be next-year opening leg). */
export interface AccountClosing {
  acCode: string;
  dr: number;
  cr: number;
  /** ΣDR − ΣCR (debit-positive), web accountBalances / desktop AcBalInsert parity. */
  balance: number;
  /** Net metal fine carried for metal accounts (Σ FINE_WT, debit-positive: −FINE_WT on Cr legs). */
  fineWt: number;
  /** Metal type 'G' gold / 'S' silver, or 'A' for money accounts. */
  itType: string;
  /** Side the opening leg lands on: 'D' debit balance / 'C' credit balance. */
  sign: 'D' | 'C';
}

export interface YearEndPreviewInput {
  scope: VoucherScope;
  fromYear: string;
}

export interface YearEndPreviewResult {
  fromYear: string;
  accounts: number;
  closings: AccountClosing[];
  totals: { dr: number; cr: number; balance: number };
  closingStockFine: number;
}

export interface YearEndInput {
  scope: VoucherScope;
  fromYear: string;
  toYear: string;
}

export interface YearEndResult {
  fromYear: string;
  toYear: string;
  /** Accounts evaluated with a non-zero closing position (= rows written). */
  accounts: number;
  /** AC_DATA opening legs written into toYear. */
  carried: number;
  /** Prior toYear ACOP '000' legs removed before the re-write (idempotent re-run). */
  deleted: number;
  /** Net closing-stock fine (Σ MAIN_STOCK +/−, or BAR_DETL on-hand). */
  closingStockFine: number;
}

/** Domain validation error — name carries 'ValidationError' so the route adapter maps it to HTTP 400. */
export class YearEndValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'YearEndValidationError';
  }
}

/**
 * Per-account closing balances for fromYear (ΣDR − ΣCR per AC_CODE, debit-positive), with the net
 * metal fine (Σ FINE_WT, −FINE_WT on credit legs) and the metal type per account. Excludes the
 * desktop closing-valuation book '999'. Zero-balance + zero-fine accounts are dropped.
 */
async function computeClosingsTx(
  tx: any,
  scope: VoucherScope,
  fromYear: string,
): Promise<AccountClosing[]> {
  const fineSigned = `CASE WHEN "SIGN"::text='C' THEN -${NN('"FINE_WT"')} ELSE ${NN('"FINE_WT"')} END`;
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE" AS "acCode",
            coalesce(sum(${NN('"DR_AMT"')}),0) AS dr,
            coalesce(sum(${NN('"CR_AMT"')}),0) AS cr,
            coalesce(sum(${fineSigned}),0) AS fine,
            max(NULLIF("IT_TYPE"::text,'')) FILTER (WHERE "IT_TYPE"::text IN ('G','S')) AS "itType"
       FROM "AC_DATA"
      WHERE "CO_CODE"=$1 AND "CO_YEAR"=$2 AND coalesce("CO_BOOK"::text,'') <> $3
      GROUP BY "AC_CODE"
      ORDER BY "AC_CODE"`,
    scope.coCode,
    fromYear,
    CLOSING_BOOK,
  );
  const closings: AccountClosing[] = [];
  for (const r of rows) {
    if (r.acCode == null || String(r.acCode).trim() === '') continue;
    const dr = round2(num(r.dr));
    const cr = round2(num(r.cr));
    const balance = round2(dr - cr);
    const fineWt = round3(num(r.fine));
    // Carry an account only if it has a money balance or a metal position.
    if (Math.abs(balance) <= 0.005 && Math.abs(fineWt) <= 0.0005) continue;
    const sign: 'D' | 'C' = balance > 0 ? 'D' : balance < 0 ? 'C' : fineWt >= 0 ? 'D' : 'C';
    closings.push({
      acCode: String(r.acCode),
      dr,
      cr,
      balance,
      fineWt,
      itType: (r.itType as string) || 'A',
      sign,
    });
  }
  return closings;
}

/**
 * Net closing-stock fine for fromYear: Σ MAIN_STOCK ITM_FINE with in '+' minus out '-' (desktop
 * Trading_Stock parity). Falls back to the on-hand tag inventory (BAR_DETL minus sold tags) when the
 * company has no MAIN_STOCK movements for the year.
 */
async function closingStockFineTx(tx: any, scope: VoucherScope, fromYear: string): Promise<number> {
  const ms: any[] = await tx.$queryRawUnsafe(
    `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"::text='-' THEN -${NN('"ITM_FINE"')} ELSE ${NN('"ITM_FINE"')} END),0) AS fine,
            count(*)::int AS n
       FROM "MAIN_STOCK" WHERE "CO_CODE"=$1 AND "CO_YEAR"=$2`,
    scope.coCode,
    fromYear,
  );
  if (ms.length && num(ms[0]!.n) > 0) return round3(num(ms[0]!.fine));
  // Fallback: on-hand BAR_DETL fine (tags not yet sold) — mirrors reports.stockValuation / stock.onHand.
  const bd: any[] = await tx.$queryRawUnsafe(
    `SELECT coalesce(sum(${NN('b."ITM_FINE"')}),0) AS fine
       FROM "BAR_DETL" b WHERE b."CO_CODE"=$1
         AND ${barTagAvailableSql('b')}`,
    scope.coCode,
  );
  return bd.length ? round3(num(bd[0]!.fine)) : 0;
}

/** Build ONE next-year opening AC_DATA leg from an account's closing position (acOpening-shaped). */
function buildOpeningRow(
  scope: VoucherScope,
  toYear: string,
  c: AccountClosing,
  srno: number,
): Record<string, unknown> {
  const co = scope.coCode ?? '';
  const lc = scope.lcCode ?? '';
  return {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: toYear,
    CO_BOOK: YE_BOOK,
    VCH_TYPE: ACOP_TYPE,
    VCH_NO: YE_VCH_NO,
    BOOK_NAME: YE_BOOK_NAME,
    LEDR_KEY: `${co}${lc}${toYear}${YE_BOOK}${pad(YE_VCH_NO, 6)}${pad(srno, 2)}`,
    LD_CODE: String(srno),
    AC_CODE: c.acCode,
    // Balanced by account sign: a debit balance opens on Dr, a credit balance on Cr.
    DR_AMT: c.balance > 0 ? c.balance : 0,
    CR_AMT: c.balance < 0 ? round2(-c.balance) : 0,
    SIGN: c.sign,
    // Metal accounts carry the opening fine magnitude + metal type (money accounts: 0 / 'A').
    FINE_WT: round3(Math.abs(c.fineWt)),
    IT_TYPE: c.itType || 'A',
  };
}

/**
 * Preview the year-end close WITHOUT writing: returns the would-be closing balances for fromYear
 * (per account + Dr/Cr/balance totals) plus the net closing-stock fine. Read-only.
 */
export async function yearEndPreview(
  prisma: any,
  input: YearEndPreviewInput,
): Promise<YearEndPreviewResult> {
  const fromYear = String(input.fromYear ?? '').trim();
  if (!fromYear) throw new YearEndValidationError('fromYear is required');
  return withTenant(prisma, input.scope.tenantId, async (tx: any) => {
    const closings = await computeClosingsTx(tx, input.scope, fromYear);
    const closingStockFine = await closingStockFineTx(tx, input.scope, fromYear);
    const totals = closings.reduce(
      (t, c) => ({
        dr: round2(t.dr + c.dr),
        cr: round2(t.cr + c.cr),
        balance: round2(t.balance + c.balance),
      }),
      { dr: 0, cr: 0, balance: 0 },
    );
    return { fromYear, accounts: closings.length, closings, totals, closingStockFine };
  });
}

/**
 * Close the From Year and carry its account balances forward as the To Year opening. Computes the
 * per-account closings (ΣDR − ΣCR), DELETEs any existing toYear ACOP '000' legs (idempotent re-run),
 * then writes one balanced-by-sign opening leg per account inside one tenant transaction. Returns
 * counts + the net closing-stock fine.
 */
export async function yearEndClose(prisma: any, input: YearEndInput): Promise<YearEndResult> {
  const fromYear = String(input.fromYear ?? '').trim();
  const toYear = String(input.toYear ?? '').trim();
  if (!fromYear) throw new YearEndValidationError('fromYear is required');
  if (!toYear) throw new YearEndValidationError('toYear is required');
  if (fromYear === toYear) throw new YearEndValidationError('toYear must differ from fromYear');

  const { scope } = input;
  const tenantId = scope.tenantId;
  return withTenant(prisma, tenantId, async (tx: any) => {
    const closings = await computeClosingsTx(tx, scope, fromYear);
    const closingStockFine = await closingStockFineTx(tx, scope, fromYear);

    // Idempotent re-run: clear any prior carry-forward opening for toYear (CO_BOOK '000' / VCH_TYPE 'ACOP').
    const deletedRaw = await tx.$executeRawUnsafe(
      `DELETE FROM "AC_DATA"
        WHERE "CO_CODE"=$1 AND "CO_YEAR"=$2 AND coalesce("CO_BOOK"::text,'')=$3 AND "VCH_TYPE"::text=$4`,
      scope.coCode,
      toYear,
      YE_BOOK,
      ACOP_TYPE,
    );
    const deleted = num(deletedRaw);

    let srno = 0;
    for (const c of closings) {
      srno++;
      await insertRowTx(tx, 'AC_DATA', tenantId, buildOpeningRow(scope, toYear, c, srno));
    }

    return {
      fromYear,
      toYear,
      accounts: closings.length,
      carried: srno,
      deleted,
      closingStockFine,
    };
  });
}
