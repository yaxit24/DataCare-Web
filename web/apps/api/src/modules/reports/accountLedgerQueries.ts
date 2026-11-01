import { round, toIsoDate } from '@datacare/core';
import {
  AMT,
  WT,
  AccountNotFoundError,
  AccountLedgerValidationError,
  REMARK_JOIN,
  SIGNED_GOLD,
  SIGNED_MONEY,
  SIGNED_SILVER,
  acDataScope,
  ageDebitsFifo,
  num,
  r2,
  r3,
  runningBalances,
  sideOf,
  splitSigned,
  summaryIsZero,
  txt,
  type AccountLedgerQuery,
  type AccountLedgerResult,
  type AgeingRow,
  type DetailRow,
  type LedgerScope,
  type MetalTriple,
  type SummaryRow,
} from './accountLedgerShared.js';

/**
 * The four Account Ledger datasets (desktop RP_LEDR). Each opens no transaction of its own — the
 * orchestrator in accountLedgerReport.ts runs them inside one tenant-scoped snapshot read. Every value
 * is a positional bind; a query never narrows tenant/company/location/year (business scope is the
 * session's). See accountLedgerShared.ts for the sign conventions and the desktop citations.
 */

export async function summaryDataset(
  tx: any,
  s: LedgerScope,
  q: AccountLedgerQuery,
): Promise<AccountLedgerResult> {
  const params: unknown[] = [];
  const scope = acDataScope(s, q, params);
  // openingOnly: balances strictly before the fromDate (the desktop uses the company opening date; we use
  // the operator's fromDate when given, else no lower bound). Otherwise: through toDate inclusive.
  const dateParts: string[] = [];
  if (q.openingOnly) {
    if (q.fromDate) {
      params.push(q.fromDate);
      dateParts.push(`d."VCH_DATE" < $${params.length}::date`);
    }
  } else if (q.toDate) {
    params.push(q.toDate);
    dateParts.push(`d."VCH_DATE" <= $${params.length}::date`);
  }
  // Optional master-driven filters (AC_MAST join).
  const mastParts: string[] = [];
  const addMast = (col: string, val: string | undefined) => {
    if (!val) return;
    params.push(val);
    mastParts.push(`m."${col}"=$${params.length}`);
  };
  addMast('AC_TYPE', q.accountType);
  addMast('AC_GR', q.accountGroup);
  addMast('AC_KHATA_NO', q.khataNo);
  addMast('AC_REF_CODE', q.refAccount);
  addMast('AC_CITY', q.city);
  addMast('AC_AREA', q.area);
  addMast('AC_STATE', q.state);

  const where = [scope, ...dateParts, ...mastParts].filter(Boolean).join(' AND ');
  const sql = `
    SELECT d."AC_CODE" AS "AC_CODE",
           max(m."AC_NAME") AS "AC_NAME",
           max(m."AC_MOBILE") AS "AC_MOBILE",
           max(m."AC_REF_NAME") AS "AC_REF_NAME",
           max(m."AC_CITY") AS "AC_CITY",
           max(m."AC_KHATA_NO") AS "AC_KHATA_NO",
           ${SIGNED_MONEY} AS money,
           ${SIGNED_GOLD} AS gold,
           ${SIGNED_SILVER} AS silver
      FROM "AC_DATA" d
      LEFT JOIN "AC_MAST" m
        ON m."CO_CODE"=d."CO_CODE" AND m."AC_CODE"=d."AC_CODE"
     WHERE ${where}
     GROUP BY d."AC_CODE"`;
  const raw: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(sql, ...params);

  const mapped = raw
    .map((r) => ({
      acCode: String(r.AC_CODE ?? ''),
      acName: txt(r.AC_NAME),
      mobile: txt(r.AC_MOBILE),
      refBy: txt(r.AC_REF_NAME),
      city: txt(r.AC_CITY),
      khataNo: txt(r.AC_KHATA_NO),
      money: r2(num(r.money)),
      gold: r3(num(r.gold)),
      silver: r3(num(r.silver)),
    }))
    .filter((r) => q.withZero || !summaryIsZero(r.money, r.gold, r.silver))
    .sort(
      (a, b) => (a.acName ?? '').localeCompare(b.acName ?? '') || a.acCode.localeCompare(b.acCode),
    );

  const rows: SummaryRow[] = mapped.map((r, i) => {
    const a = splitSigned(r.money, AMT);
    const g = splitSigned(r.gold, WT);
    const sv = splitSigned(r.silver, WT);
    return {
      srNo: i + 1,
      acCode: r.acCode,
      acName: r.acName,
      mobile: r.mobile,
      drAmt: a.dr,
      crAmt: a.cr,
      drGold: g.dr,
      crGold: g.cr,
      drSilver: sv.dr,
      crSilver: sv.cr,
      refBy: r.refBy,
      city: r.city,
      khataNo: r.khataNo,
    };
  });

  const totals = {
    drAmt: r2(rows.reduce((t, r) => t + r.drAmt, 0)),
    crAmt: r2(rows.reduce((t, r) => t + r.crAmt, 0)),
    drGold: r3(rows.reduce((t, r) => t + r.drGold, 0)),
    crGold: r3(rows.reduce((t, r) => t + r.crGold, 0)),
    drSilver: r3(rows.reduce((t, r) => t + r.drSilver, 0)),
    crSilver: r3(rows.reduce((t, r) => t + r.crSilver, 0)),
    count: rows.length,
  };
  return {
    view: 'summary',
    period: { fromDate: q.fromDate ?? null, toDate: q.toDate ?? null },
    opening: { amount: 0, goldFine: 0, silverFine: 0 },
    rows,
    totals,
    closing: { amount: 0, goldFine: 0, silverFine: 0 },
  };
}

/** Resolve and verify a selected account's master header; 404 when it does not exist in scope. */
async function loadAccount(
  tx: any,
  s: LedgerScope,
  acCode: string,
): Promise<NonNullable<AccountLedgerResult['account']>> {
  const params: unknown[] = [s.coCode, acCode];
  let where = `m."CO_CODE"=$1 AND m."AC_CODE"=$2`;
  if (s.lcCode) {
    params.push(s.lcCode);
    where += ` AND (m."LC_CODE"=$${params.length} OR m."LC_CODE" IS NULL)`;
  }
  const raw: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT m."AC_CODE","AC_NAME","AC_GR","AC_CITY","AC_MOBILE"
       FROM "AC_MAST" m WHERE ${where} ORDER BY m."LC_CODE" NULLS LAST LIMIT 1`,
    ...params,
  );
  const row = raw[0];
  if (!row) throw new AccountNotFoundError(acCode);
  return {
    acCode: String(row.AC_CODE ?? acCode),
    acName: txt(row.AC_NAME),
    group: txt(row.AC_GR),
    city: txt(row.AC_CITY),
    mobile: txt(row.AC_MOBILE),
  };
}

/** Opening money/gold/silver for a selected account strictly before fromDate (signed, Cr positive). */
async function accountOpening(
  tx: any,
  s: LedgerScope,
  q: AccountLedgerQuery,
  acCode: string,
): Promise<MetalTriple> {
  if (!q.fromDate) return { amount: 0, goldFine: 0, silverFine: 0 };
  const params: unknown[] = [];
  const scope = acDataScope(s, q, params);
  params.push(acCode);
  const acIdx = params.length;
  params.push(q.fromDate);
  const dtIdx = params.length;
  const raw: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT ${SIGNED_MONEY} AS money, ${SIGNED_GOLD} AS gold, ${SIGNED_SILVER} AS silver
       FROM "AC_DATA" d
      WHERE ${scope} AND d."AC_CODE"=$${acIdx} AND d."VCH_DATE" < $${dtIdx}::date`,
    ...params,
  );
  const r = raw[0] ?? {};
  return { amount: r2(num(r.money)), goldFine: r3(num(r.gold)), silverFine: r3(num(r.silver)) };
}

/** Build the inclusive period predicate SQL for a selected-account drill-down. */
function periodPredicate(q: AccountLedgerQuery, params: unknown[]): string {
  const parts: string[] = [];
  if (q.fromDate) {
    params.push(q.fromDate);
    parts.push(`d."VCH_DATE" >= $${params.length}::date`);
  }
  if (q.toDate) {
    params.push(q.toDate);
    parts.push(`d."VCH_DATE" <= $${params.length}::date`);
  }
  return parts.length ? ' AND ' + parts.join(' AND ') : '';
}

interface DetailBase {
  book: string | null;
  bookName: string | null;
  vchNo: string | null;
  vchType: string | null;
  date: string | null;
  billNo: string | null;
  party: string | null;
  crAmt: number;
  drAmt: number;
  crGold: number;
  drGold: number;
  crSilver: number;
  drSilver: number;
  remark: string | null;
}

type DetailBaseWithBalance = DetailBase & {
  balAmt: number;
  amtSide: 'Cr' | 'Dr' | '';
  balGold: number;
  goldSide: 'Cr' | 'Dr' | '';
  balSilver: number;
  silverSide: 'Cr' | 'Dr' | '';
};

/** Map a running-balance row to the DetailRow shape (shared by detail and voucher-summary). */
function toDetailRow(r: DetailBaseWithBalance, i: number): DetailRow {
  return {
    srNo: i + 1,
    book: r.book,
    bookName: r.bookName,
    vchNo: r.vchNo,
    vchType: r.vchType,
    date: r.date,
    billNo: r.billNo,
    party: r.party,
    crAmt: r.crAmt,
    drAmt: r.drAmt,
    balAmt: r.balAmt,
    amtSide: r.amtSide,
    crGold: r.crGold,
    drGold: r.drGold,
    balGold: r.balGold,
    goldSide: r.goldSide,
    crSilver: r.crSilver,
    drSilver: r.drSilver,
    balSilver: r.balSilver,
    silverSide: r.silverSide,
    remark: r.remark,
  };
}

export async function detailDataset(
  tx: any,
  s: LedgerScope,
  q: AccountLedgerQuery,
  acCode: string,
): Promise<AccountLedgerResult> {
  const account = await loadAccount(tx, s, acCode);
  const opening = await accountOpening(tx, s, q, acCode);

  const params: unknown[] = [];
  const scope = acDataScope(s, q, params);
  params.push(acCode);
  const acIdx = params.length;
  const period = periodPredicate(q, params);
  // Net each desktop detail key, then split (RP_LEDR.cs:6888). The key is book/voucher/ledger-key; a web
  // LEDR_KEY is unique so each row is its own key. Stable order: entry time, book name, voucher, book, key.
  const sql = `
    SELECT d."CO_BOOK" AS book, max(d."BOOK_NAME") AS book_name, d."VCH_NO" AS vch_no,
           max(d."VCH_TYPE") AS vch_type, min(d."VCH_DATE")::text AS vch_date,
           max(d."ENTRY_TIME") AS entry_time, d."LEDR_KEY" AS ledr_key,
           max(coalesce(NULLIF(d."LDR_NAME",''), lm."AC_NAME")) AS party,
           ${SIGNED_MONEY} AS money, ${SIGNED_GOLD} AS gold, ${SIGNED_SILVER} AS silver,
           max(rem.remark) AS remark
      FROM "AC_DATA" d
      LEFT JOIN "AC_MAST" lm ON lm."CO_CODE"=d."CO_CODE" AND lm."AC_CODE"=d."LD_CODE"
      ${REMARK_JOIN}
     WHERE ${scope} AND d."AC_CODE"=$${acIdx}${period}
     GROUP BY d."CO_BOOK", d."VCH_NO", d."LEDR_KEY"
     ORDER BY max(d."ENTRY_TIME") NULLS FIRST, max(d."BOOK_NAME"), d."VCH_NO", d."CO_BOOK", d."LEDR_KEY"`;
  const raw: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(sql, ...params);

  const base: DetailBase[] = raw.map((r) => {
    const a = splitSigned(num(r.money), AMT);
    const g = splitSigned(num(r.gold), WT);
    const sv = splitSigned(num(r.silver), WT);
    return {
      book: txt(r.book),
      bookName: txt(r.book_name),
      vchNo: txt(r.vch_no),
      vchType: txt(r.vch_type),
      date: toIsoDate(r.vch_date) || null,
      billNo: null,
      party: txt(r.party),
      crAmt: a.cr,
      drAmt: a.dr,
      crGold: g.cr,
      drGold: g.dr,
      crSilver: sv.cr,
      drSilver: sv.dr,
      remark: txt(r.remark),
    };
  });
  const rows = runningBalances(opening, base).map(toDetailRow);
  return finishDrill('detail', q, account, opening, base, rows);
}

export async function voucherSummaryDataset(
  tx: any,
  s: LedgerScope,
  q: AccountLedgerQuery,
  acCode: string,
): Promise<AccountLedgerResult> {
  const account = await loadAccount(tx, s, acCode);
  const opening = await accountOpening(tx, s, q, acCode);

  const params: unknown[] = [];
  const scope = acDataScope(s, q, params);
  params.push(acCode);
  const acIdx = params.length;
  const period = periodPredicate(q, params);
  // Voucher summary keeps GROSS Dr/Cr and gross +/- fine per complete voucher (RP_LEDR.cs:7716).
  const sql = `
    SELECT d."CO_BOOK" AS book, max(d."BOOK_NAME") AS book_name, d."VCH_NO" AS vch_no,
           max(d."VCH_TYPE") AS vch_type, min(d."VCH_DATE")::text AS vch_date,
           max(d."ENTRY_TIME") AS entry_time,
           coalesce(sum(coalesce(d."DR_AMT",0)),0) AS dr,
           coalesce(sum(coalesce(d."CR_AMT",0)),0) AS cr,
           coalesce(sum(CASE WHEN d."IT_TYPE"='G' AND d."SIGN"='-' THEN coalesce(d."FINE_WT",0) ELSE 0 END),0) AS dr_gold,
           coalesce(sum(CASE WHEN d."IT_TYPE"='G' AND d."SIGN"='+' THEN coalesce(d."FINE_WT",0) ELSE 0 END),0) AS cr_gold,
           coalesce(sum(CASE WHEN d."IT_TYPE"='S' AND d."SIGN"='-' THEN coalesce(d."FINE_WT",0) ELSE 0 END),0) AS dr_silver,
           coalesce(sum(CASE WHEN d."IT_TYPE"='S' AND d."SIGN"='+' THEN coalesce(d."FINE_WT",0) ELSE 0 END),0) AS cr_silver,
           max(rem.remark) AS remark
      FROM "AC_DATA" d
      ${REMARK_JOIN}
     WHERE ${scope} AND d."AC_CODE"=$${acIdx}${period}
     GROUP BY d."CO_BOOK", d."VCH_NO"
     ORDER BY max(d."ENTRY_TIME") NULLS FIRST, max(d."BOOK_NAME"), d."VCH_NO", d."CO_BOOK"`;
  const raw: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(sql, ...params);

  const base: DetailBase[] = raw.map((r) => ({
    book: txt(r.book),
    bookName: txt(r.book_name),
    vchNo: txt(r.vch_no),
    vchType: txt(r.vch_type),
    date: toIsoDate(r.vch_date) || null,
    billNo: null,
    party: account.acName,
    crAmt: r2(num(r.cr)),
    drAmt: r2(num(r.dr)),
    crGold: r3(num(r.cr_gold)),
    drGold: r3(num(r.dr_gold)),
    crSilver: r3(num(r.cr_silver)),
    drSilver: r3(num(r.dr_silver)),
    remark: txt(r.remark),
  }));
  const rows = runningBalances(opening, base).map(toDetailRow);
  return finishDrill('voucher-summary', q, account, opening, base, rows);
}

/** Shared totals/closing for the two drill-down views. */
function finishDrill(
  view: 'detail' | 'voucher-summary',
  q: AccountLedgerQuery,
  account: NonNullable<AccountLedgerResult['account']>,
  opening: MetalTriple,
  base: DetailBase[],
  rows: DetailRow[],
): AccountLedgerResult {
  const sum = (sel: (r: DetailBase) => number, dp: number) =>
    round(
      base.reduce((t, r) => t + sel(r), 0),
      dp,
    );
  const drAmt = sum((r) => r.drAmt, AMT);
  const crAmt = sum((r) => r.crAmt, AMT);
  const drGold = sum((r) => r.drGold, WT);
  const crGold = sum((r) => r.crGold, WT);
  const drSilver = sum((r) => r.drSilver, WT);
  const crSilver = sum((r) => r.crSilver, WT);
  const closeAmt = r2(opening.amount + crAmt - drAmt);
  const closeGold = r3(opening.goldFine + crGold - drGold);
  const closeSilver = r3(opening.silverFine + crSilver - drSilver);
  const totals = {
    drAmt,
    crAmt,
    balAmt: r2(Math.abs(closeAmt)),
    amtSide: sideOf(closeAmt),
    drGold,
    crGold,
    balGold: r3(Math.abs(closeGold)),
    goldSide: sideOf(closeGold),
    drSilver,
    crSilver,
    balSilver: r3(Math.abs(closeSilver)),
    silverSide: sideOf(closeSilver),
    count: rows.length,
  };
  return {
    view,
    period: { fromDate: q.fromDate ?? null, toDate: q.toDate ?? null },
    account,
    opening,
    rows,
    totals,
    closing: { amount: closeAmt, goldFine: closeGold, silverFine: closeSilver },
  };
}

export async function ageingDataset(
  tx: any,
  s: LedgerScope,
  q: AccountLedgerQuery,
): Promise<AccountLedgerResult> {
  const fine = q.fineType ?? 'G';
  const asOf = q.toDate; // operator-entered as-of date; required for ageing.
  if (!asOf) throw new AccountLedgerValidationError('ageing requires toDate (as-of date)');

  const params: unknown[] = [];
  const scope = acDataScope(s, q, params);
  params.push(asOf);
  const asOfIdx = params.length;
  // The selected fine is chosen by a constant letter ('G' or 'S'), never request text.
  const fineLetter = fine === 'S' ? 'S' : 'G';
  // Per-account, per-day-bucket debit totals and the total credit through the as-of date. The youngest
  // bucket is bounded above by the as-of date (a deliberate fix of the desktop 0-15 leak). Bucket
  // boundaries are ages (asOf - VCH_DATE) in days.
  const sql = `
    WITH base AS (
      SELECT d."AC_CODE" AS ac,
             (($${asOfIdx}::date) - d."VCH_DATE") AS age,
             coalesce(d."CR_AMT",0)-coalesce(d."DR_AMT",0) AS money_net,
             CASE WHEN d."IT_TYPE"='${fineLetter}' THEN (CASE WHEN d."SIGN"='+' THEN coalesce(d."FINE_WT",0) ELSE -coalesce(d."FINE_WT",0) END) ELSE 0 END AS fine_net
        FROM "AC_DATA" d
       WHERE ${scope} AND d."VCH_DATE" <= $${asOfIdx}::date
    )
    SELECT ac,
      sum(CASE WHEN money_net<0 THEN -money_net ELSE 0 END) FILTER (WHERE age>=0 AND age<=15) AS d15,
      sum(CASE WHEN money_net<0 THEN -money_net ELSE 0 END) FILTER (WHERE age>=16 AND age<=30) AS d30,
      sum(CASE WHEN money_net<0 THEN -money_net ELSE 0 END) FILTER (WHERE age>=31 AND age<=45) AS d45,
      sum(CASE WHEN money_net<0 THEN -money_net ELSE 0 END) FILTER (WHERE age>=46 AND age<=60) AS d60,
      sum(CASE WHEN money_net<0 THEN -money_net ELSE 0 END) FILTER (WHERE age>=61 AND age<=90) AS d90,
      sum(CASE WHEN money_net<0 THEN -money_net ELSE 0 END) FILTER (WHERE age>=91 AND age<=120) AS d120,
      sum(CASE WHEN money_net<0 THEN -money_net ELSE 0 END) FILTER (WHERE age>=121 AND age<=150) AS d150,
      sum(CASE WHEN money_net<0 THEN -money_net ELSE 0 END) FILTER (WHERE age>=151) AS d151,
      sum(CASE WHEN money_net>0 THEN money_net ELSE 0 END) AS money_credit,
      sum(money_net) AS money_total,
      sum(CASE WHEN fine_net<0 THEN -fine_net ELSE 0 END) FILTER (WHERE age>=0 AND age<=15) AS f15,
      sum(CASE WHEN fine_net<0 THEN -fine_net ELSE 0 END) FILTER (WHERE age>=16 AND age<=30) AS f30,
      sum(CASE WHEN fine_net<0 THEN -fine_net ELSE 0 END) FILTER (WHERE age>=31 AND age<=45) AS f45,
      sum(CASE WHEN fine_net<0 THEN -fine_net ELSE 0 END) FILTER (WHERE age>=46 AND age<=60) AS f60,
      sum(CASE WHEN fine_net<0 THEN -fine_net ELSE 0 END) FILTER (WHERE age>=61 AND age<=90) AS f90,
      sum(CASE WHEN fine_net<0 THEN -fine_net ELSE 0 END) FILTER (WHERE age>=91 AND age<=120) AS f120,
      sum(CASE WHEN fine_net<0 THEN -fine_net ELSE 0 END) FILTER (WHERE age>=121 AND age<=150) AS f150,
      sum(CASE WHEN fine_net<0 THEN -fine_net ELSE 0 END) FILTER (WHERE age>=151) AS f151,
      sum(CASE WHEN fine_net>0 THEN fine_net ELSE 0 END) AS fine_credit,
      sum(fine_net) AS fine_total
     FROM base GROUP BY ac`;
  const raw: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(sql, ...params);

  // Surviving accounts are those debit-outstanding on money or the selected fine.
  const survivors = raw.filter((r) => num(r.money_total) < 0 || num(r.fine_total) < 0);
  const nameByCode = await accountNames(
    tx,
    s,
    survivors.map((r) => String(r.ac ?? '')),
  );

  const rows: AgeingRow[] = survivors
    .map((r) => {
      const moneyBuckets: Record<number, number> = {
        15: num(r.d15),
        30: num(r.d30),
        45: num(r.d45),
        60: num(r.d60),
        90: num(r.d90),
        120: num(r.d120),
        150: num(r.d150),
        151: num(r.d151),
      };
      const fineBuckets: Record<number, number> = {
        15: num(r.f15),
        30: num(r.f30),
        45: num(r.f45),
        60: num(r.f60),
        90: num(r.f90),
        120: num(r.f120),
        150: num(r.f150),
        151: num(r.f151),
      };
      const m = ageDebitsFifo(moneyBuckets, num(r.money_credit), AMT);
      const f = ageDebitsFifo(fineBuckets, num(r.fine_credit), WT);
      const acCode = String(r.ac ?? '');
      return {
        acCode,
        acName: nameByCode.get(acCode) ?? null,
        amt15: m[15]!,
        amt30: m[30]!,
        amt45: m[45]!,
        amt60: m[60]!,
        amt90: m[90]!,
        amt120: m[120]!,
        amt150: m[150]!,
        amt151: m[151]!,
        amt: r2(Math.abs(Math.min(num(r.money_total), 0))),
        wt15: f[15]!,
        wt30: f[30]!,
        wt45: f[45]!,
        wt60: f[60]!,
        wt90: f[90]!,
        wt120: f[120]!,
        wt150: f[150]!,
        wt151: f[151]!,
        wt: r3(Math.abs(Math.min(num(r.fine_total), 0))),
      };
    })
    .sort(
      (a, b) => (a.acName ?? '').localeCompare(b.acName ?? '') || a.acCode.localeCompare(b.acCode),
    );

  const tot = (sel: (r: AgeingRow) => number, dp: number) =>
    round(
      rows.reduce((t, r) => t + sel(r), 0),
      dp,
    );
  const totals = {
    amt15: tot((r) => r.amt15, AMT),
    amt30: tot((r) => r.amt30, AMT),
    amt45: tot((r) => r.amt45, AMT),
    amt60: tot((r) => r.amt60, AMT),
    amt90: tot((r) => r.amt90, AMT),
    amt120: tot((r) => r.amt120, AMT),
    amt150: tot((r) => r.amt150, AMT),
    amt151: tot((r) => r.amt151, AMT),
    amt: tot((r) => r.amt, AMT),
    wt15: tot((r) => r.wt15, WT),
    wt30: tot((r) => r.wt30, WT),
    wt45: tot((r) => r.wt45, WT),
    wt60: tot((r) => r.wt60, WT),
    wt90: tot((r) => r.wt90, WT),
    wt120: tot((r) => r.wt120, WT),
    wt150: tot((r) => r.wt150, WT),
    wt151: tot((r) => r.wt151, WT),
    wt: tot((r) => r.wt, WT),
    count: rows.length,
  };
  return {
    view: 'ageing',
    period: { fromDate: q.fromDate ?? null, toDate: asOf },
    fineType: fine,
    halfMonth: q.halfMonth ?? false,
    opening: { amount: 0, goldFine: 0, silverFine: 0 },
    rows,
    totals,
    closing: { amount: 0, goldFine: 0, silverFine: 0 },
  };
}

async function accountNames(
  tx: any,
  s: LedgerScope,
  codes: string[],
): Promise<Map<string, string>> {
  const out = new Map<string, string>();
  const unique = Array.from(new Set(codes.filter(Boolean)));
  if (unique.length === 0) return out;
  const raw: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE", max("AC_NAME") AS "AC_NAME" FROM "AC_MAST"
      WHERE "CO_CODE"=$1 AND "AC_CODE"=ANY($2) GROUP BY "AC_CODE"`,
    s.coCode,
    unique,
  );
  for (const r of raw) {
    const name = txt(r.AC_NAME);
    if (name) out.set(String(r.AC_CODE ?? ''), name);
  }
  return out;
}
