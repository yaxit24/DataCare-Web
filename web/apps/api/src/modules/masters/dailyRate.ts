import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { withTxBudget } from '../shared/txBudget.js';

/**
 * Daily Rate entry (desktop "Daily Rate Master"): the operator enters today's Gold fine rate (per 10g)
 * + Silver fine rate (per kg); the system derives EACH item group's selling rate and writes a RATE_MAST
 * row per group for the date. Derivation (verified vs demo: GR_RATE 60886 = FINE_GL_RATE 72055 × GR_TOUCH
 * 84.5/100): groupRate = (group is silver ? silverRate : goldRate) × GR_TOUCH / 100. These rows feed the
 * live rate ticker (FINE_GL_RATE/FINE_SL_RATE) + the per-group sale/purchase rate. Idempotent per date.
 */
const r0 = (n: number): number => Math.round(n + 1e-9);

export interface DailyRateInput {
  scope: { tenantId: string; coCode: string; coYear?: string; lcCode?: string };
  date: string;
  goldRate: number;
  silverRate: number;
  taxPct?: number;
  empCode?: string;
  overrides?: { grCode: string; rate: number }[];
}
export interface DerivedRate {
  grCode: string;
  grType: string;
  touch: number;
  rate: number;
  prTouch: number;
  prRate: number;
}

/** Pure: derive each group's sale rate (GR_TOUCH) + purchase rate (GR_PR_TOUCH, falling back to GR_TOUCH). */
export function deriveGroupRates(
  groups: { grCode: string; grType: string; touch: number; prTouch?: number }[],
  goldRate: number,
  silverRate: number,
): DerivedRate[] {
  return groups.map((g) => {
    const fine = String(g.grType).toUpperCase() === 'S' ? silverRate : goldRate;
    const prTouch = g.prTouch && g.prTouch > 0 ? g.prTouch : g.touch;
    return {
      grCode: g.grCode,
      grType: g.grType,
      touch: g.touch,
      rate: r0((fine * g.touch) / 100),
      prTouch,
      prRate: r0((fine * prTouch) / 100),
    };
  });
}

export async function postDailyRate(
  prisma: any,
  input: DailyRateInput,
): Promise<{ date: string; groups: number; goldRate: number; silverRate: number }> {
  const date = String(input.date || '').slice(0, 10);
  if (!/^\d{4}-\d{2}-\d{2}$/.test(date)) throw new Error('a valid date (YYYY-MM-DD) is required');
  const gold = Number(input.goldRate || 0);
  const silver = Number(input.silverRate || 0);
  if (!(gold > 0) && !(silver > 0)) throw new Error('enter a gold and/or silver rate');
  const { tenantId, coCode, coYear, lcCode } = input.scope;
  const taxPct = Number(input.taxPct || 0);
  const ovr = new Map((input.overrides ?? []).map((o) => [String(o.grCode), Number(o.rate)]));
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const grs: any[] = await tx.$queryRawUnsafe(
      `SELECT "GR_CODE" gr, coalesce("GR_NAME",'') nm, coalesce("GR_TYPE",'G') t, coalesce(NULLIF("GR_TOUCH"::text,'')::numeric,0)::float touch, coalesce(NULLIF("GR_PURC_TOUCH"::text,'')::numeric,0)::float prtouch FROM "GROUP_MAST" WHERE "CO_CODE"=$1 AND coalesce("GR_CODE",'')<>'' ORDER BY "GR_CODE"`,
      coCode,
    );
    const nmeBy = new Map(grs.map((g) => [String(g.gr), String(g.nm)]));
    const derived = deriveGroupRates(
      grs.map((g) => ({
        grCode: String(g.gr),
        grType: String(g.t),
        touch: Number(g.touch),
        prTouch: Number(g.prtouch),
      })),
      gold,
      silver,
    );
    // idempotent: clear this date's rows first
    await tx.$executeRawUnsafe(
      `DELETE FROM "RATE_MAST" WHERE "CO_CODE"=$1 AND "VCH_DATE"::date = $2::date`,
      coCode,
      date,
    );
    let i = 0;
    for (const d of derived) {
      i += 1;
      const rate = ovr.has(d.grCode) ? Number(ovr.get(d.grCode)) : d.rate; // per-group manual override
      const taxRate = Math.round(rate * (1 + taxPct / 100) * 100) / 100;
      await tx.$executeRawUnsafe(
        `INSERT INTO "RATE_MAST"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","GR_CODE","GR_NAME","VCH_DATE","SR_NO","GR_TOUCH","GR_RATE","GR_TAX_PRC","GR_TAX_RATE","EMP_CODE","FINE_GL_RATE","FINE_SL_RATE","GR_PR_TOUCH","GR_PR_RATE","FINE_GL_PR_RATE","FINE_SL_PR_RATE")
         VALUES ($1,$2,$3,$4,$5,$6,$7::date,$8,$9,$10,$11,$12,$13,$14,$15,$16,$17,$18,$19)`,
        tenantId,
        coCode,
        lcCode ?? '01',
        coYear ?? '',
        d.grCode,
        nmeBy.get(d.grCode) ?? '',
        date,
        i,
        d.touch,
        rate,
        taxPct,
        taxRate,
        input.empCode ?? null,
        gold,
        silver,
        d.prTouch,
        d.prRate,
        gold,
        silver,
      );
    }
    return { date, groups: i, goldRate: gold, silverRate: silver };
  });
}

/** Read back the saved daily rates for a company + date (for the editable grid). */
export async function getDailyRate(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  date: string,
): Promise<{
  date: string;
  goldRate: number;
  silverRate: number;
  taxPct: number;
  empCode: string | null;
  groups: {
    grCode: string;
    grName: string;
    touch: number;
    rate: number;
    prTouch: number;
    prRate: number;
    taxPct: number;
  }[];
}> {
  const d = String(date || '').slice(0, 10);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "GR_CODE" gr, coalesce("GR_NAME",'') nm, coalesce(NULLIF("GR_TOUCH"::text,'')::numeric,0)::float touch, coalesce(NULLIF("GR_RATE"::text,'')::numeric,0)::float rate, coalesce(NULLIF("GR_PR_TOUCH"::text,'')::numeric,0)::float prt, coalesce(NULLIF("GR_PR_RATE"::text,'')::numeric,0)::float prr, coalesce(NULLIF("GR_TAX_PRC"::text,'')::numeric,0)::float tax, coalesce(NULLIF("FINE_GL_RATE"::text,'')::numeric,0)::float gl, coalesce(NULLIF("FINE_SL_RATE"::text,'')::numeric,0)::float sl, "EMP_CODE" emp FROM "RATE_MAST" WHERE "CO_CODE"=$1 AND "VCH_DATE"::date=$2::date ORDER BY "SR_NO"`,
      scope.coCode,
      d,
    );
    return {
      date: d,
      goldRate: rows.length ? Number(rows[0].gl) : 0,
      silverRate: rows.length ? Number(rows[0].sl) : 0,
      taxPct: rows.length ? Number(rows[0].tax) : 0,
      empCode: rows.length ? (rows[0].emp ?? null) : null,
      groups: rows.map((r) => ({
        grCode: String(r.gr),
        grName: String(r.nm),
        touch: Number(r.touch),
        rate: Number(r.rate),
        prTouch: Number(r.prt),
        prRate: Number(r.prr),
        taxPct: Number(r.tax),
      })),
    };
  });
}

/** Distinct recent rate dates (F1 history). */
export async function dailyRateDates(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  limit = 30,
): Promise<string[]> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT DISTINCT to_char("VCH_DATE"::date,'YYYY-MM-DD') d FROM "RATE_MAST" WHERE "CO_CODE"=$1 ORDER BY d DESC LIMIT ${Math.min(Number(limit) || 30, 100)}`,
      scope.coCode,
    );
    return rows.map((r) => String(r.d));
  });
}

export class DailyRateMissingError extends Error {
  constructor() {
    super(DESKTOP_MESSAGES.DAILY_RATE_MISSING);
    this.name = 'DailyRateValidationError';
  }
}

/**
 * Daily rate for a date, refusing when the rate master has nothing for that day.
 *
 * `UT_WAPP_WITH_API.cs` takes an else branch with this exact wording when its `RATE_MAST` query returns
 * no row — nothing can be quoted or messaged without a rate. `getDailyRate` stays lenient (it returns
 * empty groups) because read screens legitimately show "no rate yet"; callers that must not proceed
 * use this accessor instead.
 */
export async function requireDailyRate(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  date: string,
): Promise<Awaited<ReturnType<typeof getDailyRate>>> {
  const rate = await getDailyRate(prisma, scope, date);
  if (!rate.groups.length && !rate.goldRate && !rate.silverRate) throw new DailyRateMissingError();
  return rate;
}
