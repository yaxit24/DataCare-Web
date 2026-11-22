import { toIsoDate } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { insertRowTx } from '../posting/posting.js';
import { openingLegs } from '../finance/partyOpening.js';
import {
  acOpeningHeads,
  dayBefore,
  itemOpeningFigures,
  nextYearOf,
  type YearRow,
} from './balanceTransferRules.js';

/**
 * Company → Balance TrFr (desktop BtmSchm, MDI_FORM.cs:7431-7433): carries the closing balances of the current year
 * into the next year, one button per dataset. Lite has five datasets (orchestration/work/WP-23/study.md, button table):
 * Ac Balance and Item Stock are carried here; Tag Stock, Sales Order and Approval wait on owner decisions (cases.md Q1
 * and Q8) because the web keeps every year in one database, and are refused with a reason (balanceTransferBlocked).
 *
 * Desktop rules kept: the source rows, grouping, metal, skip and rounding rules of each dataset; a run deletes and
 * rewrites its dataset, so a second run replaces and never doubles (BtmSchm.cs:2764, :2932).
 * Desktop weaknesses not ported (study §Desktop weaknesses): the deletes are scoped to the target year (the desktop
 * deletes every year of the company and location); a run is one transaction under an advisory lock (the desktop
 * auto-commits each statement and can leave half a carry); the closing year is never written (the desktop updates
 * AC_MAST.AC_MAIN_GR, AC_DATA.DATA_TYPE and ITEM_MAST.AVG_* first; the web reads the same values without writing);
 * the target year is the first later YEAR_MAST year computed by the server, never free text.
 */

export const BT_MESSAGES = {
  CONFIRM: 'Are You Sure To Data Transfer to Next Year ?',
  COMPLETE: 'Process Are Complete....',
  NO_YEAR: 'There Are Not Found New Year Please Creat New Year And Try....',
} as const;

export type BalanceTransferDataset =
  'ac-balance' | 'item-stock' | 'tag-stock' | 'sales-order' | 'approval';

export interface BalanceTransferScope {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  /** The session year: the year being closed. */
  coYear?: string;
}

export class BalanceTransferValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'BalanceTransferValidationError';
  }
}

export interface BalanceTransferContext {
  fromYear: string;
  /** The Transfer Year, or null when YEAR_MAST has no later year. */
  toYear: string | null;
  /** The Transfer Year's opening date. */
  opDate: string | null;
  /** The closing date of the year being closed. */
  clDate: string | null;
  /** The desktop's no-year message when there is no Transfer Year. */
  message: string | null;
}

export interface BalanceTransferResult {
  dataset: BalanceTransferDataset;
  fromYear: string;
  toYear: string;
  /** Rows written into the Transfer Year. */
  rows: number;
  message: string;
}

const lcOf = (s: BalanceTransferScope) => s.lcCode ?? '01';

async function yearsTx(tx: any, coCode: string): Promise<YearRow[]> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "CO_YEAR" y, "OP_DATE"::text op, "CL_DATE"::text cl FROM "YEAR_MAST" WHERE "CO_CODE"=$1`,
    coCode,
  );
  return rows
    .filter((r) => String(r.y ?? '').trim() !== '')
    .map((r) => ({
      coYear: String(r.y).trim(),
      opDate: toIsoDate(r.op) || null,
      clDate: toIsoDate(r.cl) || null,
    }));
}

async function contextTx(tx: any, scope: BalanceTransferScope): Promise<BalanceTransferContext> {
  const fromYear = String(scope.coYear ?? '').trim();
  const years = await yearsTx(tx, scope.coCode);
  const current = years.find((y) => y.coYear === fromYear) ?? null;
  const next = fromYear ? nextYearOf(years, fromYear) : null;
  return {
    fromYear,
    toYear: next?.coYear ?? null,
    opDate: next?.opDate ?? null,
    clDate: current?.clDate ?? null,
    message: next ? null : BT_MESSAGES.NO_YEAR,
  };
}

/** What the screen shows on load (BtmSchm_Load / Activated, BtmSchm.cs:2085-2145). Read-only. */
export function balanceTransferContext(
  prisma: any,
  scope: BalanceTransferScope,
): Promise<BalanceTransferContext> {
  return withTxBudget(prisma, scope.tenantId, 'read', (tx: any) => contextTx(tx, scope));
}

interface CheckedTarget {
  fromYear: string;
  toYear: string;
  opDate: string;
  clDate: string;
}

/**
 * The server decides the Transfer Year; the request must name that same year. An empty, current, earlier, unknown or
 * later-than-next year is refused (cases.md invalid.server-refuses-no-year); with no later year the refusal is the
 * desktop text.
 */
async function checkTargetTx(
  tx: any,
  scope: BalanceTransferScope,
  requested: unknown,
): Promise<CheckedTarget> {
  const ctx = await contextTx(tx, scope);
  if (!ctx.fromYear) throw new BalanceTransferValidationError('Select the company year first.');
  if (!ctx.toYear) throw new BalanceTransferValidationError(BT_MESSAGES.NO_YEAR);
  const toYear = String(requested ?? '').trim();
  if (toYear !== ctx.toYear)
    throw new BalanceTransferValidationError(
      `Transfer Year must be ${ctx.toYear}, the year after ${ctx.fromYear}.`,
    );
  if (!ctx.clDate)
    throw new BalanceTransferValidationError(`Year ${ctx.fromYear} has no closing date.`);
  if (!ctx.opDate)
    throw new BalanceTransferValidationError(`Year ${ctx.toYear} has no opening date.`);
  return { fromYear: ctx.fromYear, toYear, opDate: ctx.opDate, clDate: ctx.clDate };
}

/** One run of one dataset at a time per company, location and Transfer Year (cases.md concurrency.same-button-twice). */
async function lockTx(
  tx: any,
  scope: BalanceTransferScope,
  toYear: string,
  dataset: BalanceTransferDataset,
) {
  await tx.$executeRawUnsafe(
    `SELECT pg_advisory_xact_lock(hashtextextended($1, 0))`,
    `BALANCE_TRFR:${scope.tenantId}:${scope.coCode}:${lcOf(scope)}:${toYear}:${dataset}`,
  );
}

export interface BalanceTransferInput {
  toYear: unknown;
  mainUser: string;
}

/** The Party Opening writer's ledger legs (TR_AC_OPBL via AcOp_Ledr), which a carried OP_DATA row owns. */
const PARTY_OPENING_LEG_BOOK_NAME = 'TR_AC_OPBL';

/**
 * Ac Balance (BtnAcBalence → Rtl_AcOpbl, BtmSchm.cs:2724-2812). Closing per AC_CODE and DATA_TYPE of the parties
 * (`B.AC_MAIN_GR < '3'`, the main group taken from AC_GROUP as BtmSchm.cs:2733 copies it), company and location, the
 * year being closed, VCH_DATE up to its closing date; money Σ(CR − DR), gold and silver Σ ±FINE_WT by IT_TYPE; a blank
 * DATA_TYPE is 'A' (:2765). The Transfer Year's OP_DATA is replaced by one row per group (:2764, :2801), each with the
 * Party Opening ledger legs (Ac_Ledr.cs:9-28) so the ledger of the new year opens at the same figure: the web's Party
 * Opening screen and its ledger read exactly these rows (finance/partyOpening.ts).
 */
export async function carryAcBalance(
  prisma: any,
  scope: BalanceTransferScope,
  input: BalanceTransferInput,
): Promise<BalanceTransferResult> {
  return withTxBudget(prisma, scope.tenantId, 'heavy', async (tx: any) => {
    const target = await checkTargetTx(tx, scope, input.toYear);
    await lockTx(tx, scope, target.toYear, 'ac-balance');
    const lc = lcOf(scope);
    const groups: any[] = await tx.$queryRawUnsafe(
      `SELECT a."AC_CODE" ac,
              coalesce(NULLIF(a."DATA_TYPE",''),'A') dt,
              coalesce(sum(coalesce(a."CR_AMT",0) - coalesce(a."DR_AMT",0)),0)::text money,
              coalesce(sum(CASE WHEN a."IT_TYPE"='G' THEN CASE WHEN a."SIGN"='+' THEN coalesce(a."FINE_WT",0) ELSE -coalesce(a."FINE_WT",0) END ELSE 0 END),0)::text gold,
              coalesce(sum(CASE WHEN a."IT_TYPE"='S' THEN CASE WHEN a."SIGN"='+' THEN coalesce(a."FINE_WT",0) ELSE -coalesce(a."FINE_WT",0) END ELSE 0 END),0)::text silver
         FROM "AC_DATA" a
        WHERE a."CO_CODE"=$1 AND a."LC_CODE"=$2 AND a."CO_YEAR"=$3 AND a."VCH_DATE" <= $4::date
          AND coalesce(a."AC_CODE",'') <> ''
          AND (SELECT CASE WHEN g."AC_GR" IS NOT NULL THEN g."AC_MAIN_GR" ELSE m."AC_MAIN_GR" END
                 FROM "AC_MAST" m
                 LEFT JOIN LATERAL (SELECT x."AC_GR", x."AC_MAIN_GR" FROM "AC_GROUP" x
                                     WHERE x."CO_CODE"=m."CO_CODE" AND x."AC_GR"=m."AC_GR" LIMIT 1) g ON true
                WHERE m."CO_CODE"=a."CO_CODE" AND m."AC_CODE"=a."AC_CODE" LIMIT 1) < '3'
        GROUP BY a."AC_CODE", coalesce(NULLIF(a."DATA_TYPE",''),'A')
        ORDER BY a."AC_CODE", 2`,
      scope.coCode,
      lc,
      target.fromYear,
      target.clDate,
    );
    const where = `"CO_CODE"=$1 AND "LC_CODE"=$2 AND "CO_YEAR"=$3`;
    await tx.$executeRawUnsafe(
      `DELETE FROM "OP_DATA" WHERE ${where}`,
      scope.coCode,
      lc,
      target.toYear,
    );
    await tx.$executeRawUnsafe(
      `DELETE FROM "AC_DATA" WHERE ${where} AND "CO_BOOK"='000' AND "BOOK_NAME"=$4`,
      scope.coCode,
      lc,
      target.toYear,
      PARTY_OPENING_LEG_BOOK_NAME,
    );
    const legDate = new Date(`${dayBefore(target.opDate)}T00:00:00.000Z`);
    const toScope = {
      tenantId: scope.tenantId,
      coCode: scope.coCode,
      lcCode: lc,
      coYear: target.toYear,
    };
    let rows = 0;
    for (const g of groups) {
      const heads = acOpeningHeads({ money: g.money, gold: g.gold, silver: g.silver });
      if (!heads) continue;
      const acCode = String(g.ac);
      const dataType = String(g.dt);
      await insertRowTx(tx, 'OP_DATA', scope.tenantId, {
        CO_CODE: scope.coCode,
        LC_CODE: lc,
        CO_YEAR: target.toYear,
        CO_BOOK: '000',
        VCH_NO: '00000',
        AC_CODE: acCode,
        OP_AMT: heads.amount,
        OP_SIGN: heads.sign,
        FINE_BAL: heads.gold,
        FINE_SIGN: heads.goldSign,
        SL_FINE_BAL: heads.silver,
        SL_FINE_SIGN: heads.silverSign,
        DATA_TYPE: dataType,
        MAIN_USER: input.mainUser.slice(0, 15),
        ADD_USER: '',
        ADD_DATE: null,
        DATA_TRFR: 'Y',
      });
      for (const leg of openingLegs(
        toScope,
        acCode,
        heads,
        legDate,
        input.mainUser.slice(0, 15),
        dataType,
      ))
        await insertRowTx(tx, 'AC_DATA', scope.tenantId, leg);
      rows += 1;
    }
    return {
      dataset: 'ac-balance' as const,
      fromYear: target.fromYear,
      toYear: target.toYear,
      rows,
      message: BT_MESSAGES.COMPLETE,
    };
  });
}

/**
 * Item Stock (BtnItmStk, BtmSchm.cs:2921-3002). Untagged MAIN_STOCK (TAG_NO 'N', blank or NULL) of the company,
 * location and year being closed, up to its closing date, per item, ordered GR_CODE then IT_CODE; touch is the item's
 * AVG_TOUCH as stored (the desktop first recomputes it with DC_Main.AvgTouch, a write to the closing year that is not
 * ported: cases.md item.rule.touch-is-recomputed-average is blocked on it). The Transfer Year's ITM_OPBL is replaced:
 * book '000', VCH_NO = the item type, SR_NO = the query row + 1 (skipped rows keep their number), rate, labour, other
 * and diamond 0, DATA_TRFR 'Y', DATA_TYPE 'A'. The web's Item Opening screen reads these rows.
 */
export async function carryItemStock(
  prisma: any,
  scope: BalanceTransferScope,
  input: BalanceTransferInput,
): Promise<BalanceTransferResult> {
  return withTxBudget(prisma, scope.tenantId, 'heavy', async (tx: any) => {
    const target = await checkTargetTx(tx, scope, input.toYear);
    await lockTx(tx, scope, target.toYear, 'item-stock');
    const lc = lcOf(scope);
    const signed = (c: string) => `CASE WHEN a."ITM_SIGN"='+' THEN ${c} ELSE -(${c}) END`;
    const groups: any[] = await tx.$queryRawUnsafe(
      `SELECT a."IT_CODE" it, max(b."IT_TYPE") ty, max(b."AVG_TOUCH")::text touch,
              coalesce(sum(${signed('coalesce(a."ITM_PCS",0)')}),0)::text pcs,
              coalesce(sum(${signed('coalesce(a."ITM_GWT",0)')}),0)::text gross,
              coalesce(sum(${signed('coalesce(a."ITM_NWT",0)')}),0)::text net,
              coalesce(sum(${signed('coalesce(a."ITM_PCS",0) * coalesce(b."ITEM_RATE",0)')}),0)::text amt
         FROM "MAIN_STOCK" a
         LEFT JOIN "ITEM_MAST" b ON b."CO_CODE"=a."CO_CODE" AND b."IT_CODE"=a."IT_CODE"
        WHERE a."CO_CODE"=$1 AND a."LC_CODE"=$2 AND a."CO_YEAR"=$3 AND a."VCH_DATE" <= $4::date
          AND coalesce(a."IT_CODE",'') <> '' AND (a."TAG_NO"='N' OR a."TAG_NO"='' OR a."TAG_NO" IS NULL)
        GROUP BY a."IT_CODE", b."GR_CODE"
        ORDER BY b."GR_CODE", a."IT_CODE"`,
      scope.coCode,
      lc,
      target.fromYear,
      target.clDate,
    );
    await tx.$executeRawUnsafe(
      `DELETE FROM "ITM_OPBL" WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 AND "CO_YEAR"=$3`,
      scope.coCode,
      lc,
      target.toYear,
    );
    let rows = 0;
    for (const [index, g] of groups.entries()) {
      const f = itemOpeningFigures({
        itCode: String(g.it),
        itType: g.ty ?? null,
        pcs: g.pcs,
        gross: g.gross,
        net: g.net,
        amount: g.amt,
        touch: g.touch,
      });
      if (!f) continue;
      await insertRowTx(tx, 'ITM_OPBL', scope.tenantId, {
        CO_CODE: scope.coCode,
        LC_CODE: lc,
        CO_YEAR: target.toYear,
        CO_BOOK: '000',
        IT_CODE: String(g.it),
        VCH_NO: String(g.ty ?? ''),
        SR_NO: index + 1,
        ITM_PCS: f.pcs,
        ITM_GWT: f.gross,
        ITM_NWT: f.net,
        ITM_TOUCH: f.touch,
        ITM_FINE: f.fine,
        ITM_RATE: 0,
        ITM_AMT: f.amount,
        LBR_AMT: 0,
        OTH_AMT: 0,
        NET_AMT: f.amount,
        DM_WT: 0,
        DM_RATE: 0,
        DM_AMT: 0,
        MAIN_USER: input.mainUser.slice(0, 15),
        LBR_RATE: 0,
        DATA_TRFR: 'Y',
        DATA_TYPE: 'A',
      });
      rows += 1;
    }
    return {
      dataset: 'item-stock' as const,
      fromYear: target.fromYear,
      toYear: target.toYear,
      rows,
      message: BT_MESSAGES.COMPLETE,
    };
  });
}

/** Why a Lite dataset is not carried yet (each waits on an owner decision recorded in cases.md). */
export const BLOCKED_DATASETS: Readonly<Record<'tag-stock' | 'sales-order' | 'approval', string>> =
  {
    'tag-stock':
      'Tag Stock is not carried yet: the web keeps every year in one database and counts a tag in stock in any year, so a copy of the tag in the next year would count it twice (owner decision Q8).',
    'sales-order':
      'Sales Order is not carried yet: the desktop keeps the order under its old year, which in one database is the order itself (owner decision Q1).',
    approval:
      'Approval is not carried yet: the desktop keeps the approval under its old year, which in one database is the approval itself (owner decisions Q1 and Q5).',
  };

/** A blocked dataset: the target year is still checked, then the run is refused and nothing is written. */
export async function balanceTransferBlocked(
  prisma: any,
  scope: BalanceTransferScope,
  dataset: keyof typeof BLOCKED_DATASETS,
  input: BalanceTransferInput,
): Promise<never> {
  await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    checkTargetTx(tx, scope, input.toYear),
  );
  throw new BalanceTransferBlockedError(BLOCKED_DATASETS[dataset]);
}

export class BalanceTransferBlockedError extends Error {
  readonly statusCode = 409;
  constructor(message: string) {
    super(message);
    this.name = 'BalanceTransferBlockedError';
  }
}
