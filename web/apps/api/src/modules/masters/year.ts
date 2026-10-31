import { fiscalYearDates } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { CLONE_TEMPLATE_CO_CODE, cloneCompanyTx } from './companyClone.js';
import { OPENING_BOOK, writePartyOpeningTx } from '../finance/partyOpening.js';

/**
 * Financial-year master (desktop "Year Create", `MS_YEAR`): create a company year (YEAR_MAST: OP_DATE opening,
 * CL_DATE closing, YEAR_MONTH start month) and carry the prior year's CLOSING party balances forward as the new
 * year's OPENING balances (OP_DATA). Additive; RLS-scoped.
 *
 * CL_DATE is the year's last day, not a "closed" flag: `MS_YEAR.cs:1035-1040` fills 01/04/yyyy and 31/03/yyyy+1
 * from the year code and `:1196`/`:1224` save it as entered. Every voucher writer bounds its date by OP_DATE and
 * CL_DATE (`vouchers/lifecycle.ts` `assertFiscalDateTx`), so a year without a closing date cannot post at all.
 * The desktop has no year close/reopen on this form; period locking is `CO_SET.LOCK_DATE` / `LAST_DAY_LOCK`.
 */
export interface YearRow {
  coYear: string;
  opDate: string | null;
  clDate: string | null;
  yearMonth: string;
}
const num = (v: unknown): number => Number(v ?? 0);
const r2 = (n: number): number => Math.round((n + 1e-9) * 100) / 100;
const r3 = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;

export class YearValidationError extends Error {
  override name = 'YearValidationError';
}

export async function listYears(
  prisma: any,
  scope: { tenantId: string; coCode: string },
): Promise<YearRow[]> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "CO_YEAR" y, "OP_DATE"::text od, "CL_DATE"::text cd, coalesce("YEAR_MONTH",'') ym FROM "YEAR_MAST" WHERE "CO_CODE"=$1 ORDER BY "CO_YEAR"`,
      scope.coCode,
    );
    return rows.map((r) => ({
      coYear: String(r.y ?? ''),
      opDate: r.od ? String(r.od).slice(0, 10) : null,
      clDate: r.cd ? String(r.cd).slice(0, 10) : null,
      yearMonth: String(r.ym ?? ''),
    }));
  });
}

/**
 * Resolve the year's opening and closing dates with the shared desktop rule (`@datacare/core`
 * `fiscalYearDates`, MS_YEAR.cs:1035-1043), throwing the operator-facing reason when it cannot.
 */
export function resolveYearDates(input: {
  coYear: string;
  opDate?: string;
  clDate?: string;
  yearMonth?: string;
}): { opDate: string; clDate: string; yearMonth: string } {
  const dates = fiscalYearDates(input);
  if (dates.error !== undefined) throw new YearValidationError(dates.error);
  return dates;
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
    mainUser?: string;
  },
): Promise<{ coYear: string; opDate: string; clDate: string }> {
  const coYear = String(input.coYear ?? '').trim();
  if (!coYear) throw new YearValidationError('coYear is required');
  if (coYear.length > 9) throw new YearValidationError('year code is at most 9 characters');
  const dates = resolveYearDates({ ...input, coYear });
  return withTxBudget(prisma, scope.tenantId, 'heavy', async (tx: any) => {
    const ex: any[] = await tx.$queryRawUnsafe(
      `SELECT count(*) FILTER (WHERE "CO_YEAR"=$2)::int n, count(*)::int years
         FROM "YEAR_MAST" WHERE "CO_CODE"=$1`,
      scope.coCode,
      coYear,
    );
    if (ex[0]?.n > 0) throw new YearValidationError(`year ${coYear} already exists`);
    const firstYear = Number(ex[0]?.years ?? 0) === 0;
    // OP_DATE is varchar in the migrated schema and CL_DATE a timestamp; both carry the ISO day.
    // OLD_METHOD 'Y' is what the standard (non alter-year) desktop save writes (MS_YEAR.cs:1197).
    await tx.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE","YEAR_MONTH","OLD_METHOD","MAIN_USER")
       VALUES ($1,$2,$3,$4,$5::date,$6,$7,$8)`,
      scope.tenantId,
      scope.coCode,
      coYear,
      dates.opDate,
      dates.clDate,
      dates.yearMonth,
      input.oldMethod ?? 'Y',
      input.mainUser ? String(input.mainUser).slice(0, 15) : null,
    );
    // The desktop copies the company's masters and configuration only when a NEW company gets its first year
    // (`MS_YEAR.cs:1357-1363` runs `NewCompParmCreat` when `NewCompCode` is set by `MS_COMPANY.cs:6196`).
    // Opening the next year of an existing company copies nothing, and the template company (01) is the copy
    // source, so it is never cloned into itself. Non-destructive: each table is skipped when it already has rows.
    if (firstYear && scope.coCode !== CLONE_TEMPLATE_CO_CODE)
      await cloneCompanyTx(tx, scope.tenantId, scope.coCode);
    return { coYear, opDate: dates.opDate, clDate: dates.clDate };
  });
}

/**
 * Carry-forward (Balance TrFr, BtmSchm.cs:2764-2801): each party's CLOSING balance in `fromYear` becomes its `toYear`
 * opening. The closing is read from AC_DATA alone, which already holds the fromYear opening as its AcOp_Ledr legs:
 * money = Σ(DR−CR), gold and silver = Σ signed FINE_WT on IT_TYPE 'G' and 'S' ('+' is Cr). Each opening is written
 * through the Party Opening writer, so it lands in OP_DATA book '000' with its ledger legs, as the desktop's openings do.
 * Idempotent: the toYear openings and their legs are cleared first, as BtmSchm clears OP_DATA.
 */
export async function carryForwardOpenings(
  prisma: any,
  scope: { tenantId: string; coCode: string; lcCode?: string },
  fromYear: string,
  toYear: string,
  mainUser = 'system',
): Promise<{ parties: number }> {
  return withTxBudget(prisma, scope.tenantId, 'heavy', async (tx: any) => {
    await tx.$executeRawUnsafe(
      `DELETE FROM "OP_DATA" WHERE "CO_CODE"=$1 AND "CO_YEAR"=$2`,
      scope.coCode,
      toYear,
    );
    await tx.$executeRawUnsafe(
      `DELETE FROM "AC_DATA" WHERE "CO_CODE"=$1 AND "CO_YEAR"=$2 AND "CO_BOOK"=$3 AND "BOOK_NAME"='TR_AC_OPBL'`,
      scope.coCode,
      toYear,
      OPENING_BOOK,
    );
    const closings: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE" ac,
              coalesce(sum(coalesce("DR_AMT",0)-coalesce("CR_AMT",0)),0)::float money,
              coalesce(sum(CASE WHEN "IT_TYPE"='G' THEN (CASE WHEN "SIGN"='+' THEN 1 ELSE -1 END)*coalesce("FINE_WT",0) ELSE 0 END),0)::float gold,
              coalesce(sum(CASE WHEN "IT_TYPE"='S' THEN (CASE WHEN "SIGN"='+' THEN 1 ELSE -1 END)*coalesce("FINE_WT",0) ELSE 0 END),0)::float silver
         FROM "AC_DATA" WHERE "CO_CODE"=$1 AND "CO_YEAR"=$2 AND coalesce("AC_CODE",'')<>''
        GROUP BY "AC_CODE" ORDER BY "AC_CODE"`,
      scope.coCode,
      fromYear,
    );
    let parties = 0;
    for (const c of closings) {
      const money = r2(num(c.money));
      const gold = r3(num(c.gold));
      const silver = r3(num(c.silver));
      if (money === 0 && gold === 0 && silver === 0) continue; // a settled party carries nothing
      parties += 1;
      await writePartyOpeningTx(
        tx,
        { tenantId: scope.tenantId, coCode: scope.coCode, lcCode: scope.lcCode, coYear: toYear },
        String(c.ac),
        {
          amount: Math.abs(money),
          sign: money >= 0 ? 'D' : 'C',
          gold: Math.abs(gold),
          goldSign: gold >= 0 ? 'C' : 'D',
          silver: Math.abs(silver),
          silverSign: silver >= 0 ? 'C' : 'D',
        },
        mainUser,
      );
    }
    return { parties };
  });
}
