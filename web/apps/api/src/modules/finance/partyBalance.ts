import { withTxBudget } from '../shared/txBudget.js';

/**
 * Party balance for the on-select balance bar (desktop shows Dr/Cr amount + Gold + Silver the moment a
 * party is picked). Money balance = Σ(DR_AMT − CR_AMT) over AC_DATA; metal = Σ signed FINE_WT by
 * IT_TYPE ('G'/'S', SIGN '+'/'-'). Read-only.
 *
 * Openings are already in AC_DATA: a party opening writes its AcOp_Ledr legs in book '000' (modules/finance/partyOpening.ts),
 * and the desktop balance (DC_Main.MsAcBal, DC_Main.cs:1463) reads AC_DATA alone. Adding OP_DATA as well counted every
 * opening twice.
 */
const r2 = (n: number): number => Math.round((n + 1e-9) * 100) / 100;
const r3 = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;

export interface PartyBalance {
  acCode: string;
  name: string | null;
  amount: number;
  sign: 'Dr' | 'Cr';
  gold: number;
  silver: number;
}

export async function partyBalance(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  acCode: string,
): Promise<PartyBalance> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce(sum(coalesce(NULLIF("DR_AMT"::text,'')::numeric,0)),0)::float dr,
              coalesce(sum(coalesce(NULLIF("CR_AMT"::text,'')::numeric,0)),0)::float cr,
              coalesce(sum(CASE WHEN "IT_TYPE"='G' THEN (CASE WHEN "SIGN"='-' THEN -1 ELSE 1 END)*coalesce(NULLIF("FINE_WT"::text,'')::numeric,0) ELSE 0 END),0)::float gold,
              coalesce(sum(CASE WHEN "IT_TYPE"='S' THEN (CASE WHEN "SIGN"='-' THEN -1 ELSE 1 END)*coalesce(NULLIF("FINE_WT"::text,'')::numeric,0) ELSE 0 END),0)::float silver
       FROM "AC_DATA" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2`,
      scope.coCode,
      acCode,
    );
    const r = rows[0] ?? {};
    const bal = r2(Number(r.dr ?? 0) - Number(r.cr ?? 0));
    let name: string | null = null;
    try {
      const nm: any[] = await tx.$queryRawUnsafe(
        `SELECT "AC_NAME" n FROM "AC_MAST" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2 LIMIT 1`,
        scope.coCode,
        acCode,
      );
      name = nm[0]?.n ?? null;
    } catch {
      name = null;
    }
    return {
      acCode,
      name,
      amount: Math.abs(bal),
      sign: bal >= 0 ? 'Dr' : 'Cr',
      gold: r3(Number(r.gold ?? 0)),
      silver: r3(Number(r.silver ?? 0)),
    };
  });
}
