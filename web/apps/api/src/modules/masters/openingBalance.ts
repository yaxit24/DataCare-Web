import { withTenant } from '@datacare/db';

/**
 * Account opening balance (desktop "Opening Balance"): stored per account in OP_DATA — money
 * (OP_AMT + OP_SIGN D/C), opening gold fine (FINE_BAL + FINE_SIGN +/−) and opening silver fine
 * (SL_FINE_BAL + SL_FINE_SIGN +/−). These are added to the running AC_DATA movements when computing
 * a party's balance. One opening row per account (book 'OPN'); writing replaces the existing row.
 */
const r2 = (n: number): number => Math.round((n + 1e-9) * 100) / 100;
const r3 = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;

export type DrCr = 'D' | 'C';
export type PlusMinus = '+' | '-';
export interface OpeningBalance {
  acCode: string;
  amount: number;
  sign: DrCr;
  gold: number;
  goldSign: PlusMinus;
  silver: number;
  silverSign: PlusMinus;
}
export interface OpeningInput {
  /** Entering user: desktop stamps it on both MAIN_USER and ADD_USER (TR_AC_OPBL.cs:2719). */
  mainUser?: string;
  scope: { tenantId: string; coCode: string; coYear?: string; lcCode?: string };
  acCode: string;
  amount?: number;
  sign?: DrCr;
  gold?: number;
  goldSign?: PlusMinus;
  silver?: number;
  silverSign?: PlusMinus;
}

/** Signed opening for an account (money: Cr negative; gold/silver: '-' negative). Reused by partyBalance/reports. */
export async function openingFor(
  tx: any,
  coCode: string,
  acCode: string,
): Promise<{ money: number; gold: number; silver: number }> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT coalesce(NULLIF("OP_AMT"::text,'')::numeric,0)::float amt, upper(coalesce("OP_SIGN",'D')) osg,
            coalesce(NULLIF("FINE_BAL"::text,'')::numeric,0)::float g, coalesce("FINE_SIGN",'+') gsg,
            coalesce(NULLIF("SL_FINE_BAL"::text,'')::numeric,0)::float s, coalesce("SL_FINE_SIGN",'+') ssg
     FROM "OP_DATA" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2`,
    coCode,
    acCode,
  );
  let money = 0,
    gold = 0,
    silver = 0;
  for (const r of rows) {
    money += (String(r.osg) === 'C' ? -1 : 1) * Number(r.amt || 0);
    gold += (String(r.gsg) === '-' ? -1 : 1) * Number(r.g || 0);
    silver += (String(r.ssg) === '-' ? -1 : 1) * Number(r.s || 0);
  }
  return { money: r2(money), gold: r3(gold), silver: r3(silver) };
}

export async function getOpeningBalance(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  acCode: string,
): Promise<OpeningBalance> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce(NULLIF("OP_AMT"::text,'')::numeric,0)::float amt, upper(coalesce("OP_SIGN",'D')) osg,
              coalesce(NULLIF("FINE_BAL"::text,'')::numeric,0)::float g, coalesce("FINE_SIGN",'+') gsg,
              coalesce(NULLIF("SL_FINE_BAL"::text,'')::numeric,0)::float s, coalesce("SL_FINE_SIGN",'+') ssg
       FROM "OP_DATA" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2 LIMIT 1`,
      scope.coCode,
      acCode,
    );
    const r = rows[0];
    if (!r)
      return { acCode, amount: 0, sign: 'D', gold: 0, goldSign: '+', silver: 0, silverSign: '+' };
    return {
      acCode,
      amount: r2(Number(r.amt || 0)),
      sign: String(r.osg) === 'C' ? 'C' : 'D',
      gold: r3(Number(r.g || 0)),
      goldSign: String(r.gsg) === '-' ? '-' : '+',
      silver: r3(Number(r.s || 0)),
      silverSign: String(r.ssg) === '-' ? '-' : '+',
    };
  });
}

export async function setOpeningBalance(prisma: any, input: OpeningInput): Promise<OpeningBalance> {
  if (!input.acCode) throw new Error('acCode is required');
  const { tenantId, coCode, coYear, lcCode } = input.scope;
  const amount = Math.abs(Number(input.amount || 0));
  const sign: DrCr = input.sign === 'C' ? 'C' : 'D';
  const gold = Math.abs(Number(input.gold || 0));
  const goldSign: PlusMinus = input.goldSign === '-' ? '-' : '+';
  const silver = Math.abs(Number(input.silver || 0));
  const silverSign: PlusMinus = input.silverSign === '-' ? '-' : '+';
  return withTenant(prisma, tenantId, async (tx: any) => {
    await tx.$executeRawUnsafe(
      `DELETE FROM "OP_DATA" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2`,
      coCode,
      input.acCode,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "OP_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","OP_AMT","OP_SIGN","FINE_BAL","FINE_SIGN","SL_FINE_BAL","SL_FINE_SIGN","DATA_TYPE","MAIN_USER","ADD_USER","ADD_DATE","DATA_TRFR")
       VALUES ($1,$2,$3,$4,'OPN',$5,$5,$6,$7,$8,$9,$10,$11,'O',$12,$12,$13,'N')`,
      tenantId,
      coCode,
      lcCode ?? '01',
      coYear ?? '',
      input.acCode,
      String(amount),
      sign,
      String(gold),
      goldSign,
      String(silver),
      silverSign,
      // Desktop OP_DATA carries the entering user twice (MAIN_USER + ADD_USER), the entry date and
      // the DATA_TRFR literal (TR_AC_OPBL.cs:2719-2720, 3403).
      input.mainUser ?? 'system',
      new Date(),
    );
    return {
      acCode: input.acCode,
      amount: r2(amount),
      sign,
      gold: r3(gold),
      goldSign,
      silver: r3(silver),
      silverSign,
    };
  });
}
