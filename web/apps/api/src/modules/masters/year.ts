import { withTenant } from '@datacare/db';
import { cloneCompanyTx } from './companyClone.js';

/**
 * Financial-year lifecycle (desktop "Year Create"): create a company year (YEAR_MAST: OP_DATE opening,
 * CL_DATE closing, YEAR_MONTH start-month), close/reopen it, and carry the prior year's CLOSING party
 * balances forward as the new year's OPENING balances (OP_DATA). Additive; RLS-scoped.
 */
export interface YearRow {
  coYear: string;
  opDate: string | null;
  clDate: string | null;
  yearMonth: string;
  closed: boolean;
}
const num = (v: unknown): number => Number(v ?? 0);
const r2 = (n: number): number => Math.round((n + 1e-9) * 100) / 100;
const r3 = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;

export async function listYears(
  prisma: any,
  scope: { tenantId: string; coCode: string },
): Promise<YearRow[]> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "CO_YEAR" y, "OP_DATE"::text od, "CL_DATE"::text cd, coalesce("YEAR_MONTH",'') ym FROM "YEAR_MAST" WHERE "CO_CODE"=$1 ORDER BY "CO_YEAR"`,
      scope.coCode,
    );
    return rows.map((r) => ({
      coYear: String(r.y ?? ''),
      opDate: r.od ? String(r.od).slice(0, 10) : null,
      clDate: r.cd ? String(r.cd).slice(0, 10) : null,
      yearMonth: String(r.ym ?? ''),
      closed: !!r.cd,
    }));
  });
}

export async function createYear(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  input: {
    coYear: string;
    opDate?: string;
    clDate?: string;
    yearMonth?: string;
    oldMethod?: string;
  },
): Promise<{ coYear: string }> {
  const coYear = String(input.coYear ?? '').trim();
  if (!coYear) throw new Error('coYear is required');
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const ex: any[] = await tx.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "YEAR_MAST" WHERE "CO_CODE"=$1 AND "CO_YEAR"=$2`,
      scope.coCode,
      coYear,
    );
    if (ex[0]?.n > 0) throw new Error(`year ${coYear} already exists`);
    await tx.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE","YEAR_MONTH","OLD_METHOD") VALUES ($1,$2,$3,$4,$5,$6,$7)`,
      scope.tenantId,
      scope.coCode,
      coYear,
      input.opDate ? new Date(input.opDate) : null,
      input.clDate ? new Date(input.clDate) : null,
      input.yearMonth ?? '4',
      input.oldMethod ?? 'N',
    );
    // Desktop provisions the company's masters and configuration in one block when a company/year is
    // created (MS_YEAR.cs:1511-1553). Non-destructive here: each table is skipped when the company
    // already has rows, so opening a new year can never wipe live masters.
    await cloneCompanyTx(tx, scope.tenantId, scope.coCode);
    return { coYear };
  });
}

export async function closeYear(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  coYear: string,
  clDate?: string,
): Promise<{ closed: true }> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await tx.$executeRawUnsafe(
      `UPDATE "YEAR_MAST" SET "CL_DATE"=$3 WHERE "CO_CODE"=$1 AND "CO_YEAR"=$2`,
      scope.coCode,
      coYear,
      clDate ? new Date(clDate) : new Date(),
    );
    return { closed: true };
  });
}

export async function reopenYear(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  coYear: string,
): Promise<{ reopened: true }> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await tx.$executeRawUnsafe(
      `UPDATE "YEAR_MAST" SET "CL_DATE"=NULL WHERE "CO_CODE"=$1 AND "CO_YEAR"=$2`,
      scope.coCode,
      coYear,
    );
    return { reopened: true };
  });
}

/**
 * Carry-forward: compute each party's CLOSING balance in `fromYear` (its fromYear opening + the net of
 * its AC_DATA there — money net = Σ(DR−CR) on non-gold legs, gold net = Σ signed FINE_WT on IT_TYPE 'G')
 * and write it as the `toYear` OPENING (OP_DATA). Idempotent: clears toYear openings first.
 */
export async function carryForwardOpenings(
  prisma: any,
  scope: { tenantId: string; coCode: string; lcCode?: string },
  fromYear: string,
  toYear: string,
): Promise<{ parties: number }> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await tx.$executeRawUnsafe(
      `DELETE FROM "OP_DATA" WHERE "CO_CODE"=$1 AND "CO_YEAR"=$2`,
      scope.coCode,
      toYear,
    );
    // fromYear ledger net per party
    const acRows: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE" ac,
              coalesce(sum(CASE WHEN coalesce("IT_TYPE",'')<>'G' THEN coalesce(NULLIF("DR_AMT"::text,'')::numeric,0)-coalesce(NULLIF("CR_AMT"::text,'')::numeric,0) ELSE 0 END),0)::float money,
              coalesce(sum(CASE WHEN coalesce("IT_TYPE",'')='G' THEN (CASE WHEN coalesce("SIGN",'')='+' THEN 1 ELSE -1 END)*coalesce(NULLIF("FINE_WT"::text,'')::numeric,0) ELSE 0 END),0)::float gold
         FROM "AC_DATA" WHERE "CO_CODE"=$1 AND "CO_YEAR"=$2 AND coalesce("AC_CODE",'')<>'' GROUP BY "AC_CODE"`,
      scope.coCode,
      fromYear,
    );
    // fromYear opening per party
    const opRows: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE" ac, coalesce(NULLIF("OP_AMT"::text,'')::numeric,0)::float amt, upper(coalesce("OP_SIGN",'D')) osg, coalesce(NULLIF("FINE_BAL"::text,'')::numeric,0)::float fb, coalesce("FINE_SIGN",'+') fsg
         FROM "OP_DATA" WHERE "CO_CODE"=$1 AND "CO_YEAR"=$2`,
      scope.coCode,
      fromYear,
    );
    const closing = new Map<string, { money: number; gold: number }>();
    for (const r of opRows) {
      const m = num(r.amt) * (String(r.osg) === 'C' ? -1 : 1);
      const g = num(r.fb) * (String(r.fsg) === '-' ? -1 : 1);
      const c = closing.get(String(r.ac)) ?? { money: 0, gold: 0 };
      c.money += m;
      c.gold += g;
      closing.set(String(r.ac), c);
    }
    for (const r of acRows) {
      const c = closing.get(String(r.ac)) ?? { money: 0, gold: 0 };
      c.money += num(r.money);
      c.gold += num(r.gold);
      closing.set(String(r.ac), c);
    }
    let parties = 0;
    for (const [ac, c] of closing) {
      const money = r2(c.money);
      const gold = r3(c.gold);
      if (Math.abs(money) < 0.005 && Math.abs(gold) < 0.0005) continue; // skip fully-settled parties
      parties += 1;
      await tx.$executeRawUnsafe(
        `INSERT INTO "OP_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","OP_AMT","OP_SIGN","FINE_BAL","FINE_SIGN","DATA_TYPE") VALUES ($1,$2,$3,$4,'OPB',$5,$6,$7,$8,$9,$10,'O')`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode ?? '01',
        toYear,
        ac,
        ac,
        Math.abs(money),
        money >= 0 ? 'D' : 'C',
        Math.abs(gold),
        gold >= 0 ? '+' : '-',
      );
    }
    return { parties };
  });
}
