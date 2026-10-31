import { formatDesktopDate, toIsoDate } from '@datacare/core';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { withTxBudget } from '../shared/txBudget.js';
import { esc, money } from '../documents/docChrome.js';

/**
 * Daily Rate (desktop MS_RATE, "Rate Master", opened by MDI_FORM.cs:8564-8573).
 *
 * The screen shows the GROUP_MAST groups that have a touch (GR_TOUCH <> 0, ORDER BY GR_TYPE, GR_NAME) with their
 * touch, TAX_PRC and GR_PURC_TOUCH, and the day's saved Rate10gm / TaxRate / PrRate from RATE_MAST for the company,
 * location, year and date (DISPLAY_DATA, MS_RATE.cs:1752-1832). The operator types the gold and silver rates and the
 * grid is recomputed on the screen (`recalcDailyRateGrid` in @datacare/core); Save stores the grid as shown
 * (BtnSave_Click, :1867-1947): the day's rows are deleted and one row is written per group whose touch and Rate10gm
 * are non-zero, SR_NO = the group's grid row. Location '00' also stores the rate on GROUP_MAST.GR_RATE.
 */
export class DailyRateValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'DailyRateValidationError';
  }
}

export class DailyRateNotFoundError extends Error {
  readonly statusCode = 404;
  readonly code = 'daily-rate-not-found';
  constructor(date: string) {
    super(`no daily rate saved for ${date}`);
    this.name = 'DailyRateNotFoundError';
  }
}

export interface DailyRateScope {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  coYear?: string;
}
export interface DailyRateRowInput {
  grCode: string;
  touch?: number;
  taxPct?: number;
  rate: number;
  taxRate?: number;
  prRate?: number;
}
export interface DailyRateInput {
  scope: DailyRateScope;
  date: string;
  goldRate?: number;
  silverRate?: number;
  /** UAE companies only (MS_RATE.cs:1705-1715). */
  prGoldRate?: number;
  prSilverRate?: number;
  goldOzRate?: number;
  silverOzRate?: number;
  empCode?: string;
  /** The signed-in user; kept only for a new day (CLEAR_DATA sets MainUser, DISPLAY_DATA reloads it). */
  mainUser?: string;
  rows: DailyRateRowInput[];
}

type Group = {
  code: string;
  name: string;
  type: string;
  touch: number;
  taxPct: number;
  prTouch: number;
};
type Complete = Required<Pick<DailyRateScope, 'tenantId' | 'coCode' | 'lcCode' | 'coYear'>>;

const text = (value: unknown): string => String(value ?? '').trim();
const amount = (value: unknown, label: string): number => {
  const n = Number(value ?? 0);
  if (!Number.isFinite(n) || n < 0)
    throw new DailyRateValidationError(`${label} must be zero or more`);
  return n;
};

function complete(scope: DailyRateScope): Complete {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear)
    throw new DailyRateValidationError('daily rate needs a company, location and year');
  return scope as Complete;
}

function isoDay(raw: unknown): string {
  const value = text(raw);
  if (!/^\d{4}-\d{2}-\d{2}$/.test(value))
    throw new DailyRateValidationError('a valid date (YYYY-MM-DD) is required');
  try {
    return toIsoDate(value);
  } catch {
    throw new DailyRateValidationError(`not a calendar date: ${value}`);
  }
}

/** The grid's groups, in MS_RATE's order (MS_RATE.cs:1781). */
async function gridGroupsTx(tx: any, s: Complete): Promise<Group[]> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "GR_CODE" code,coalesce("GR_NAME",'') name,coalesce("GR_TYPE",'') type,
            coalesce("GR_TOUCH",0)::float touch,coalesce("TAX_PRC",0)::float tax,
            coalesce("GR_PURC_TOUCH",0)::float prtouch
       FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND coalesce("GR_TOUCH",0) <> 0
      ORDER BY "GR_TYPE","GR_NAME",row_id`,
    s.tenantId,
    s.coCode,
  );
  return rows.map((r) => ({
    code: text(r.code),
    name: text(r.name),
    type: text(r.type).toUpperCase(),
    touch: Number(r.touch),
    taxPct: Number(r.tax),
    prTouch: Number(r.prtouch),
  }));
}

/** The saved day for this company, location and year (MS_RATE.cs:1756). */
async function savedDayTx(tx: any, s: Complete, date: string): Promise<Array<Record<string, any>>> {
  return tx.$queryRawUnsafe(
    `SELECT "SR_NO","GR_CODE",coalesce("GR_RATE",0)::float rate,coalesce("GR_TAX_RATE",0)::float taxrate,
            coalesce("GR_PR_RATE",0)::float prrate,coalesce("FINE_GL_RATE",0)::float gold,
            coalesce("FINE_SL_RATE",0)::float silver,coalesce("FINE_GL_PR_RATE",0)::float prgold,
            coalesce("FINE_SL_PR_RATE",0)::float prsilver,coalesce("DOLLAR_GL_RATE",0)::float usdgold,
            coalesce("DOLLAR_SL_RATE",0)::float usdsilver,coalesce("EMP_CODE",'') emp,
            coalesce("MAIN_USER",'') mainuser
       FROM "RATE_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "VCH_DATE"=$5::date ORDER BY "SR_NO"`,
    s.tenantId,
    s.coCode,
    s.lcCode,
    s.coYear,
    date,
  );
}

export async function getDailyRate(prisma: any, scope: DailyRateScope, rawDate: string) {
  const s = complete(scope);
  const date = isoDay(rawDate);
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const [groups, saved] = await Promise.all([gridGroupsTx(tx, s), savedDayTx(tx, s, date)]);
    const head = saved[0];
    const byCode = new Map<string, Record<string, any>>();
    for (const row of saved) if (!byCode.has(text(row.GR_CODE))) byCode.set(text(row.GR_CODE), row);
    const emp = head?.emp
      ? ((await tx.$queryRawUnsafe(
          `SELECT coalesce("EMP_NAME",'') name FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3 LIMIT 1`,
          s.tenantId,
          s.coCode,
          head.emp,
        )) as Array<{ name: string }>)
      : [];
    const company: Array<{ sname: string }> = await tx.$queryRawUnsafe(
      `SELECT upper(btrim(coalesce("CO_SNAME",''))) sname FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
      s.tenantId,
      s.coCode,
    );
    return {
      date,
      exists: saved.length > 0,
      goldRate: Number(head?.gold ?? 0),
      silverRate: Number(head?.silver ?? 0),
      prGoldRate: Number(head?.prgold ?? 0),
      prSilverRate: Number(head?.prsilver ?? 0),
      goldOzRate: Number(head?.usdgold ?? 0),
      silverOzRate: Number(head?.usdsilver ?? 0),
      empCode: text(head?.emp),
      empName: text(emp[0]?.name),
      mainUser: text(head?.mainuser),
      // MS_RATE.cs:1705-1715 shows the purchase and USD rates only when CO_SNAME is 'UAE'.
      foreignRates: company[0]?.sname === 'UAE',
      groups: groups.map((g) => {
        const savedRow = byCode.get(g.code);
        return {
          grCode: g.code,
          grName: g.name,
          grType: g.type,
          touch: g.touch,
          taxPct: g.taxPct,
          prTouch: g.prTouch,
          rate: Number(savedRow?.rate ?? 0),
          taxRate: Number(savedRow?.taxrate ?? 0),
          prRate: Number(savedRow?.prrate ?? 0),
        };
      }),
    };
  });
}

export async function dailyRateExists(prisma: any, scope: DailyRateScope, rawDate: string) {
  const s = complete(scope);
  const date = isoDay(rawDate);
  return withTxBudget(
    prisma,
    s.tenantId,
    'read',
    async (tx: any) => (await savedDayTx(tx, s, date)).length > 0,
  );
}

export async function saveDailyRate(prisma: any, input: DailyRateInput) {
  const s = complete(input.scope);
  const date = isoDay(input.date);
  const header = {
    gold: amount(input.goldRate, 'gold rate'),
    silver: amount(input.silverRate, 'silver rate'),
    prGold: amount(input.prGoldRate, 'gold purchase rate'),
    prSilver: amount(input.prSilverRate, 'silver purchase rate'),
    usdGold: amount(input.goldOzRate, 'gold USD rate'),
    usdSilver: amount(input.silverOzRate, 'silver USD rate'),
  };
  if (!Array.isArray(input.rows))
    throw new DailyRateValidationError('daily rate needs the group grid');
  const requested = new Map<string, Required<DailyRateRowInput>>();
  for (const row of input.rows) {
    const code = text(row?.grCode);
    if (requested.has(code)) throw new DailyRateValidationError(`group ${code} appears twice`);
    requested.set(code, {
      grCode: code,
      touch: amount(row.touch, `touch of ${code}`),
      taxPct: amount(row.taxPct, `tax % of ${code}`),
      rate: amount(row.rate, `rate of ${code}`),
      taxRate: amount(row.taxRate, `tax rate of ${code}`),
      prRate: amount(row.prRate, `purchase rate of ${code}`),
    });
  }
  const empCode = text(input.empCode);
  return withTxBudget(prisma, s.tenantId, 'voucher', async (tx: any) => {
    const groups = await gridGroupsTx(tx, s);
    const known = new Set(groups.map((g) => g.code));
    for (const code of requested.keys())
      if (!known.has(code))
        throw new DailyRateValidationError(`daily rate group not found or without touch: ${code}`);
    if (empCode) {
      const found: unknown[] = await tx.$queryRawUnsafe(
        `SELECT 1 FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3 LIMIT 1`,
        s.tenantId,
        s.coCode,
        empCode,
      );
      if (!found.length) throw new DailyRateValidationError(`employee not found: ${empCode}`);
    }
    const saved = await savedDayTx(tx, s, date);
    const mainUser = text(saved[0]?.mainuser) || text(input.mainUser) || null;
    await tx.$executeRawUnsafe(
      `DELETE FROM "RATE_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "VCH_DATE"=$5::date`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coYear,
      date,
    );
    let count = 0;
    for (const [index, group] of groups.entries()) {
      const row = requested.get(group.code);
      if (!row || row.touch === 0 || row.rate === 0) continue;
      await tx.$executeRawUnsafe(
        `INSERT INTO "RATE_MAST"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","VCH_DATE","SR_NO","GR_CODE",
           "FINE_GL_RATE","FINE_SL_RATE","FINE_GL_PR_RATE","FINE_SL_PR_RATE","DOLLAR_GL_RATE","DOLLAR_SL_RATE",
           "GR_TOUCH","GR_TAX_PRC","GR_RATE","GR_TAX_RATE","GR_PR_TOUCH","GR_PR_RATE","GR_TYPE","EMP_CODE","MAIN_USER")
         VALUES ($1,$2,$3,$4,$5::date,$6,$7,$8,$9,$10,$11,$12,$13,$14,$15,$16,$17,$18,$19,$20,$21,$22)`,
        s.tenantId,
        s.coCode,
        s.lcCode,
        s.coYear,
        date,
        index + 1,
        group.code,
        header.gold,
        header.silver,
        header.prGold,
        header.prSilver,
        header.usdGold,
        header.usdSilver,
        row.touch,
        row.taxPct,
        row.rate,
        row.taxRate,
        group.prTouch,
        row.prRate,
        group.type,
        empCode,
        mainUser,
      );
      // MS_RATE.cs:1930-1933: the head-office location also keeps the group's current rate.
      if (s.lcCode === '00')
        await tx.$executeRawUnsafe(
          `UPDATE "GROUP_MAST" SET "GR_RATE"=$3 WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "GR_CODE"=$4`,
          s.tenantId,
          s.coCode,
          row.rate,
          group.code,
        );
      count += 1;
    }
    return { date, saved: count };
  });
}

/** BtnDelete_Click (MS_RATE.cs:2095-2109): CO_CODE, LC_CODE and VCH_DATE. */
export async function deleteDailyRate(prisma: any, scope: DailyRateScope, rawDate: string) {
  const s = complete(scope);
  const date = isoDay(rawDate);
  return withTxBudget(prisma, s.tenantId, 'voucher', async (tx: any) => {
    const deleted: number = await tx.$executeRawUnsafe(
      `DELETE FROM "RATE_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "VCH_DATE"=$4::date`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      date,
    );
    if (!deleted) throw new DailyRateNotFoundError(date);
    return { deleted };
  });
}

/** BtnF1_Click (MS_RATE.cs:2370-2396): date, user, gold and silver for this company and location, newest first. */
export async function dailyRateDates(prisma: any, scope: DailyRateScope) {
  const s = complete(scope);
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT to_char("VCH_DATE",'YYYY-MM-DD') d,coalesce("MAIN_USER",'') u,
              coalesce("FINE_GL_RATE",0)::float g,coalesce("FINE_SL_RATE",0)::float sl
         FROM "RATE_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        GROUP BY "VCH_DATE","MAIN_USER","FINE_GL_RATE","FINE_SL_RATE"
        ORDER BY "VCH_DATE" DESC LIMIT 500`,
      s.tenantId,
      s.coCode,
      s.lcCode,
    );
    return rows.map((r) => ({
      date: text(r.d),
      mainUser: text(r.u),
      goldRate: Number(r.g),
      silverRate: Number(r.sl),
    }));
  });
}

/**
 * RateRpt (MS_RATE.cs:1834-1866; report-specs/RateRpt.spec.json): the company name, 'Daily Rate Report dd/MM/yyyy',
 * the page number, then Date / Group Name / Rate 10gm with the day as a group row and GROUP_MAST.GR_NAME with
 * RATE_MAST.GR_RATE per saved row, for this company, location and date.
 */
export async function dailyRateReportHtml(prisma: any, scope: DailyRateScope, rawDate: string) {
  const s = complete(scope);
  const date = isoDay(rawDate);
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT coalesce(g."GR_NAME",'') name,coalesce(r."GR_RATE",0)::float rate
         FROM "RATE_MAST" r LEFT JOIN LATERAL (
           SELECT m."GR_NAME" FROM "GROUP_MAST" m
            WHERE m.tenant_id=r.tenant_id AND m."CO_CODE"=r."CO_CODE" AND m."GR_CODE"=r."GR_CODE"
            ORDER BY m.row_id LIMIT 1) g ON true
        WHERE r.tenant_id=$1 AND r."CO_CODE"=$2 AND r."LC_CODE"=$3 AND r."VCH_DATE"=$4::date
        ORDER BY r."SR_NO"`,
      s.tenantId,
      s.coCode,
      s.lcCode,
      date,
    );
    if (!rows.length) throw new DailyRateNotFoundError(date);
    const company: Array<{ name: string }> = await tx.$queryRawUnsafe(
      `SELECT coalesce("CO_NAME",'') name FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
      s.tenantId,
      s.coCode,
    );
    const day = formatDesktopDate(date);
    const title = `Daily Rate Report ${day}`;
    const detail = rows
      .map(
        (r) => `<tr><td></td><td>${esc(text(r.name))}</td><td class="r">${money(r.rate)}</td></tr>`,
      )
      .join('');
    return (
      `<!doctype html><html><head><meta charset="utf-8"><title>${esc(title)}</title><style>` +
      `body{font-family:Arial,sans-serif;font-size:11px;color:#111;margin:24px}h1{font-size:16px;margin:0}` +
      `h2{font-size:13px;margin:6px 0 12px}table{border-collapse:collapse;width:100%}` +
      `th,td{padding:3px 6px;text-align:left}th{border-bottom:1px solid #333}td.r,th.r{text-align:right}` +
      `@page{@top-right{content:counter(page)}}</style></head><body>` +
      `<h1>${esc(text(company[0]?.name))}</h1><h2>${esc(title)}</h2>` +
      `<table><thead><tr><th>Date</th><th>Group Name</th><th class="r">Rate 10gm</th></tr></thead>` +
      `<tbody><tr><td colspan="3"><b>${esc(day)}</b></td></tr>${detail}</tbody></table></body></html>`
    );
  });
}

export class DailyRateMissingError extends Error {
  constructor() {
    super(DESKTOP_MESSAGES.DAILY_RATE_MISSING);
    this.name = 'DailyRateValidationError';
  }
}

/**
 * Daily rate for a date, refusing when the rate master has nothing for that day (`UT_WAPP_WITH_API.cs` refuses with
 * this wording when its RATE_MAST query returns no row).
 */
export async function requireDailyRate(prisma: any, scope: DailyRateScope, date: string) {
  const rate = await getDailyRate(prisma, scope, date);
  if (!rate.exists) throw new DailyRateMissingError();
  return rate;
}
