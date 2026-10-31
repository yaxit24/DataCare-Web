import { round, toIsoDate } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { insertRowTx } from '../posting/posting.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';

/**
 * Party Opening (desktop TR_AC_OPBL, menu Master → Party Opening). The Party master's inline opening (MS_ACCT.cs:7856-7905)
 * and Balance TrFr (BtmSchm.cs:2801) write the same rows, so every opening goes through this module.
 *
 * One OP_DATA row per party and data type, in book '000' with voucher '00000' (TR_AC_OPBL.cs:2694-2722): the opening
 * amount, gold fine and silver fine, each with a Cr/Dr sign stored as 'C'/'D' (the combos at :2232-2239, defaulting to
 * "Cr" at CLEAR_DATA). A save deletes the party's row and writes it again.
 *
 * The opening reaches the ledger through AcOp_Ledr (Ac_Ledr.cs:9-28): the party's '000' AC_DATA rows are deleted and
 * up to six legs written, one per non-zero head, with the leg type as the last two characters of LEDR_KEY:
 *   01 amount Cr (CR_AMT)   02 amount Dr (DR_AMT)
 *   03 gold Cr   (G, '+')   04 gold Dr   (G, '-')
 *   05 silver Cr (S, '+')   06 silver Dr (S, '-')
 * Each leg is dated the day before the year opens and is the opening's only ledger effect: the desktop balance
 * (DC_Main.MsAcBal, DC_Main.cs:1463) reads AC_DATA alone, never OP_DATA.
 *
 * The bill-wise grid (OP_DETL) is not edited here; a save keeps the party's OP_DETL rows and a delete removes them, as
 * the desktop delete does (:2877).
 */
export const OPENING_BOOK = '000';
export const OPENING_VCH_NO = '00000';
const OPENING_BOOK_NAME = 'TR_AC_OPBL';
const OPENING_VCH_TYPE = 'ACOP';
/** The desktop data type for a single-book company (MsDataType 'A'); the A/B split is an Advance-edition feature. */
const DATA_TYPE = 'A';

export type CrDr = 'C' | 'D';
export type OpeningBalanceType = 'amount' | 'gold' | 'silver';

export class PartyOpeningValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'PartyOpeningValidationError';
  }
}

export interface PartyOpeningScope {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  coYear?: string;
}

export interface PartyOpeningHeads {
  amount: number;
  sign: CrDr;
  gold: number;
  goldSign: CrDr;
  silver: number;
  silverSign: CrDr;
}

export interface PartyOpening extends PartyOpeningHeads {
  acCode: string;
  acName: string | null;
  /** False when the party has no OP_DATA row; the heads are then the screen's empty defaults. */
  exists: boolean;
}

export interface SavePartyOpeningInput extends Partial<PartyOpeningHeads> {
  scope: PartyOpeningScope;
  acCode: string;
  mainUser?: string;
}

/** A Cr/Dr sign as the desktop stores it. '+' and '-' are the older web spelling of Cr and Dr for metal. */
export function crDr(value: unknown): CrDr {
  const v = String(value ?? '')
    .trim()
    .toUpperCase();
  if (v === 'D' || v === 'DR' || v === '-') return 'D';
  if (v === '' || v === 'C' || v === 'CR' || v === '+') return 'C';
  throw new PartyOpeningValidationError(`sign must be Cr or Dr, got ${String(value)}`);
}

function head(value: unknown, places: number, label: string): number {
  const n = value === undefined || value === null || value === '' ? 0 : Number(value);
  if (!Number.isFinite(n)) throw new PartyOpeningValidationError(`${label} must be a number`);
  if (n < 0)
    throw new PartyOpeningValidationError(`${label} cannot be negative; choose Cr or Dr instead`);
  return round(n, places);
}

const scopeOf = (s: PartyOpeningScope) => ({
  coCode: s.coCode,
  lcCode: s.lcCode ?? '01',
  coYear: s.coYear ?? '',
});

/**
 * AcOp_Ledr's legs for one party (Ac_Ledr.cs:9-28). Pure, so the leg layout is unit-tested on its own. `legDate` is
 * the day before the year's opening date (MOp_dt.AddDays(-1)).
 */
export function openingLegs(
  scope: PartyOpeningScope,
  acCode: string,
  heads: PartyOpeningHeads,
  legDate: Date,
  mainUser: string,
  dataType: string = DATA_TYPE,
): Record<string, unknown>[] {
  const { coCode, lcCode, coYear } = scopeOf(scope);
  const leg = (
    type: string,
    money: { cr: number; dr: number },
    metal: { itType: string; sign: string; fine: number },
    desc: string,
  ) => ({
    CO_CODE: coCode,
    LC_CODE: lcCode,
    CO_YEAR: coYear,
    CO_BOOK: OPENING_BOOK,
    VCH_TYPE: OPENING_VCH_TYPE,
    VCH_NO: OPENING_VCH_NO,
    VCH_DATE: legDate,
    LEDR_KEY: `${coCode}${lcCode}${coYear}${OPENING_BOOK}${OPENING_VCH_NO}${acCode}${dataType}${type}`,
    BOOK_NAME: OPENING_BOOK_NAME,
    BILL_NO: '',
    BILL_DATE: null,
    CHQ_NO: '',
    AC_CODE: acCode,
    LD_CODE: '00000',
    CR_AMT: money.cr,
    DR_AMT: money.dr,
    IT_TYPE: metal.itType,
    SIGN: metal.sign,
    FINE_WT: metal.fine,
    IT_DESC: desc,
    ENTRY_TIME: legDate,
    HD_VCH_NO: OPENING_VCH_NO,
    CLR_DATE: legDate,
    DATA_TYPE: dataType,
    DATA_TRFR: 'N',
    MAIN_USER: mainUser,
    FINE_RATE: 0,
    PARTY_AC_CODE: acCode,
    LDR_NAME: '',
  });
  const legs: Record<string, unknown>[] = [];
  const noMetal = { itType: 'A', sign: '', fine: 0 };
  if (heads.amount !== 0)
    legs.push(
      heads.sign === 'C'
        ? leg('01', { cr: heads.amount, dr: 0 }, noMetal, 'OPENING AMOUNT')
        : leg('02', { cr: 0, dr: heads.amount }, noMetal, 'OPENING AMOUNT'),
    );
  if (heads.gold !== 0)
    legs.push(
      heads.goldSign === 'C'
        ? leg('03', { cr: 0, dr: 0 }, { itType: 'G', sign: '+', fine: heads.gold }, 'OPENING GOLD')
        : leg('04', { cr: 0, dr: 0 }, { itType: 'G', sign: '-', fine: heads.gold }, 'OPENING GOLD'),
    );
  if (heads.silver !== 0)
    legs.push(
      heads.silverSign === 'C'
        ? leg(
            '05',
            { cr: 0, dr: 0 },
            { itType: 'S', sign: '+', fine: heads.silver },
            'OPENING SILVER',
          )
        : leg(
            '06',
            { cr: 0, dr: 0 },
            { itType: 'S', sign: '-', fine: heads.silver },
            'OPENING SILVER',
          ),
    );
  return legs;
}

/** The day before the scope year's opening date: the date AcOp_Ledr gives every opening leg. Fails closed. */
export async function openingLegDateTx(tx: any, scope: PartyOpeningScope): Promise<Date> {
  const { coCode, coYear } = scopeOf(scope);
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "OP_DATE"::text AS op FROM "YEAR_MAST" WHERE "CO_CODE"=$1 AND "CO_YEAR"=$2 LIMIT 1`,
    coCode,
    coYear,
  );
  const iso = toIsoDate(rows[0]?.op);
  if (!iso)
    throw new PartyOpeningValidationError(
      `year ${coYear || '(none)'} has no opening date; open the company year first`,
    );
  const d = new Date(`${iso}T00:00:00.000Z`);
  d.setUTCDate(d.getUTCDate() - 1);
  return d;
}

const opDataWhere = `"CO_CODE"=$1 AND "LC_CODE"=$2 AND "CO_YEAR"=$3 AND "CO_BOOK"='${OPENING_BOOK}' AND "AC_CODE"=$4`;

/**
 * Write one party's opening and its ledger legs inside the caller's transaction (TR_AC_OPBL.cs:2694-2775). The previous
 * row's MAIN_USER and DATA_TRFR are kept on an edit, as the desktop reload does (:2545-2546).
 */
export async function writePartyOpeningTx(
  tx: any,
  scope: PartyOpeningScope,
  acCode: string,
  heads: PartyOpeningHeads,
  mainUser: string,
): Promise<void> {
  const { coCode, lcCode, coYear } = scopeOf(scope);
  const previous: any[] = await tx.$queryRawUnsafe(
    `SELECT "MAIN_USER" mu, "DATA_TRFR" tr FROM "OP_DATA" WHERE ${opDataWhere} AND "DATA_TYPE"=$5 LIMIT 1`,
    coCode,
    lcCode,
    coYear,
    acCode,
    DATA_TYPE,
  );
  const owner = String(previous[0]?.mu ?? '') || mainUser;
  const transfer = String(previous[0]?.tr ?? '') || 'N';
  await tx.$executeRawUnsafe(
    `DELETE FROM "OP_DATA" WHERE ${opDataWhere} AND "DATA_TYPE"=$5`,
    coCode,
    lcCode,
    coYear,
    acCode,
    DATA_TYPE,
  );
  await insertRowTx(tx, 'OP_DATA', scope.tenantId, {
    CO_CODE: coCode,
    LC_CODE: lcCode,
    CO_YEAR: coYear,
    CO_BOOK: OPENING_BOOK,
    VCH_NO: OPENING_VCH_NO,
    AC_CODE: acCode,
    OP_AMT: heads.amount,
    OP_SIGN: heads.sign,
    FINE_BAL: heads.gold,
    FINE_SIGN: heads.goldSign,
    SL_FINE_BAL: heads.silver,
    SL_FINE_SIGN: heads.silverSign,
    DATA_TYPE,
    DATA_TRFR: transfer,
    MAIN_USER: owner,
  });
  await tx.$executeRawUnsafe(
    `DELETE FROM "AC_DATA" WHERE ${opDataWhere} AND "DATA_TYPE"=$5`,
    coCode,
    lcCode,
    coYear,
    acCode,
    DATA_TYPE,
  );
  const legDate = await openingLegDateTx(tx, scope);
  for (const leg of openingLegs(scope, acCode, heads, legDate, owner))
    await insertRowTx(tx, 'AC_DATA', scope.tenantId, leg);
}

/** Validate a save body into the six heads. Missing signs default to Cr, the desktop combos' first item. */
export function openingHeads(input: Partial<PartyOpeningHeads>): PartyOpeningHeads {
  return {
    amount: head(input.amount, 2, 'opening amount'),
    sign: crDr(input.sign),
    gold: head(input.gold, 3, 'opening gold fine'),
    goldSign: crDr(input.goldSign),
    silver: head(input.silver, 3, 'opening silver fine'),
    silverSign: crDr(input.silverSign),
  };
}

async function partyNameTx(
  tx: any,
  coCode: string,
  acCode: string,
  lock: boolean,
): Promise<string | null> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "AC_NAME" nm FROM "AC_MAST" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2 LIMIT 1${lock ? ' FOR UPDATE' : ''}`,
    coCode,
    acCode,
  );
  return rows.length ? String(rows[0].nm ?? '') : null;
}

/** Save (TR_AC_OPBL BtnSave). The party row is locked so two saves of the same party cannot both insert. */
export async function savePartyOpening(
  prisma: any,
  input: SavePartyOpeningInput,
): Promise<PartyOpening> {
  const acCode = String(input.acCode ?? '').trim();
  if (!acCode) throw new PartyOpeningValidationError(DESKTOP_MESSAGES.OPENING_PARTY_REQUIRED);
  const heads = openingHeads(input);
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    const acName = await partyNameTx(tx, input.scope.coCode, acCode, true);
    if (acName === null) throw new PartyOpeningValidationError(`party ${acCode} does not exist`);
    await writePartyOpeningTx(tx, input.scope, acCode, heads, input.mainUser ?? 'system');
    return { acCode, acName, exists: true, ...heads };
  });
}

/** Read one party's opening (the reload at TR_AC_OPBL.cs:2534-2546). */
export async function getPartyOpening(
  prisma: any,
  scope: PartyOpeningScope,
  acCodeRaw: string,
): Promise<PartyOpening> {
  const acCode = String(acCodeRaw ?? '').trim();
  const { coCode, lcCode, coYear } = scopeOf(scope);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const acName = await partyNameTx(tx, coCode, acCode, false);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT coalesce("OP_AMT",0)::float amt, "OP_SIGN" osg, coalesce("FINE_BAL",0)::float g, "FINE_SIGN" gsg,
              coalesce("SL_FINE_BAL",0)::float s, "SL_FINE_SIGN" ssg
         FROM "OP_DATA" WHERE ${opDataWhere} AND "DATA_TYPE"=$5 LIMIT 1`,
      coCode,
      lcCode,
      coYear,
      acCode,
      DATA_TYPE,
    );
    const r = rows[0];
    if (!r)
      return {
        acCode,
        acName,
        exists: false,
        amount: 0,
        sign: 'C',
        gold: 0,
        goldSign: 'C',
        silver: 0,
        silverSign: 'C',
      };
    const stored = (v: unknown): CrDr => (String(v ?? '').toUpperCase() === 'D' ? 'D' : 'C');
    return {
      acCode,
      acName,
      exists: true,
      amount: round(Number(r.amt), 2),
      sign: stored(r.osg),
      gold: round(Number(r.g), 3),
      goldSign: stored(r.gsg),
      silver: round(Number(r.s), 3),
      silverSign: stored(r.ssg),
    };
  });
}

export interface PartyOpeningListRow {
  acCode: string;
  acName: string | null;
  group: string | null;
  cr: number;
  dr: number;
}

/**
 * The screen's opening list (MSG_AC, TR_AC_OPBL.cs:2299-2311): one row per party with a non-zero head of the chosen
 * balance type, Cr and Dr in their own columns, ordered by account group and name.
 */
export async function listPartyOpenings(
  prisma: any,
  scope: PartyOpeningScope,
  balanceType: OpeningBalanceType = 'amount',
): Promise<{
  balanceType: OpeningBalanceType;
  rows: PartyOpeningListRow[];
  totalCr: number;
  totalDr: number;
}> {
  const column = {
    amount: ['OP_AMT', 'OP_SIGN', 2],
    gold: ['FINE_BAL', 'FINE_SIGN', 3],
    silver: ['SL_FINE_BAL', 'SL_FINE_SIGN', 3],
  }[balanceType] as [string, string, number] | undefined;
  if (!column) throw new PartyOpeningValidationError('balance type must be amount, gold or silver');
  const [value, sign, places] = column;
  const { coCode, lcCode, coYear } = scopeOf(scope);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT a."AC_CODE" ac, m."AC_NAME" nm, m."AC_GR" gr,
              CASE WHEN a."${sign}"='C' THEN coalesce(a."${value}",0) ELSE 0 END::float cr,
              CASE WHEN a."${sign}"='D' THEN coalesce(a."${value}",0) ELSE 0 END::float dr
         FROM "OP_DATA" a LEFT JOIN "AC_MAST" m ON m."CO_CODE"=a."CO_CODE" AND m."AC_CODE"=a."AC_CODE"
        WHERE a."CO_CODE"=$1 AND a."LC_CODE"=$2 AND a."CO_YEAR"=$3 AND a."CO_BOOK"='${OPENING_BOOK}'
          AND a."DATA_TYPE"=$4 AND coalesce(a."${value}",0)<>0
        ORDER BY m."AC_GR", m."AC_NAME", a."AC_CODE"`,
      coCode,
      lcCode,
      coYear,
      DATA_TYPE,
    );
    const out = rows.map((r) => ({
      acCode: String(r.ac),
      acName: r.nm ?? null,
      group: r.gr ?? null,
      cr: round(Number(r.cr), places),
      dr: round(Number(r.dr), places),
    }));
    return {
      balanceType,
      rows: out,
      totalCr: round(
        out.reduce((t, r) => t + r.cr, 0),
        places,
      ),
      totalDr: round(
        out.reduce((t, r) => t + r.dr, 0),
        places,
      ),
    };
  });
}

/**
 * Delete (TR_AC_OPBL BtnDelete, :2856-2885): two DELETE_DATA rows (amount and gold as SR_NO 0, silver as SR_NO 1 when the
 * party has silver), then the party's OP_DATA, OP_DETL and '000' AC_DATA rows. Answers `deleted: false` when the party
 * has no opening.
 */
export async function deletePartyOpening(
  prisma: any,
  scope: PartyOpeningScope,
  acCodeRaw: string,
  deleteUser: string,
): Promise<{ deleted: boolean }> {
  const acCode = String(acCodeRaw ?? '').trim();
  if (!acCode) throw new PartyOpeningValidationError(DESKTOP_MESSAGES.OPENING_ACCOUNT_REQUIRED);
  const { coCode, lcCode, coYear } = scopeOf(scope);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await partyNameTx(tx, coCode, acCode, true);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT a."VCH_NO" vch, a."MAIN_USER" mu, m."AC_NAME" nm,
              a."OP_SIGN" osg, coalesce(a."OP_AMT",0)::float amt, a."FINE_SIGN" gsg, coalesce(a."FINE_BAL",0)::float g,
              a."SL_FINE_SIGN" ssg, coalesce(a."SL_FINE_BAL",0)::float s
         FROM "OP_DATA" a LEFT JOIN "AC_MAST" m ON m."CO_CODE"=a."CO_CODE" AND m."AC_CODE"=a."AC_CODE"
        WHERE a."CO_CODE"=$1 AND a."LC_CODE"=$2 AND a."CO_YEAR"=$3 AND a."CO_BOOK"='${OPENING_BOOK}'
          AND a."AC_CODE"=$4 AND a."DATA_TYPE"=$5`,
      coCode,
      lcCode,
      coYear,
      acCode,
      DATA_TYPE,
    );
    if (!rows.length) return { deleted: false };
    const legDate = await openingLegDateTx(tx, scope);
    const opDate = new Date(legDate);
    opDate.setUTCDate(opDate.getUTCDate() + 1);
    const now = new Date();
    for (const r of rows) {
      const audit = (
        srNo: number,
        fineType: string,
        money: { dr: number; cr: number },
        fine: { dr: number; cr: number },
      ) =>
        insertRowTx(tx, 'DELETE_DATA', scope.tenantId, {
          CO_CODE: coCode,
          LC_CODE: lcCode,
          CO_YEAR: coYear,
          CO_BOOK: OPENING_BOOK,
          VCH_NO: r.vch,
          SR_NO: srNo,
          VCH_DATE: opDate,
          DELETE_DATE: now,
          VCH_TYPE: 'OPBAL',
          VCH_TIME: opDate,
          DELETE_TIME: now,
          BOOK_NAME: 'Ac OpBal',
          AC_CODE: acCode,
          AC_NAME: r.nm ?? '',
          VCH_VAL_DR: money.dr,
          VCH_VAL_CR: money.cr,
          FINE_TYPE: fineType,
          VCH_FINE_DR: fine.dr,
          VCH_FINE_CR: fine.cr,
          HD_VCH_NO: r.vch,
          MAIN_USER: r.mu ?? '',
          DELETE_USER: deleteUser,
          VCH_DESC: '',
        });
      const side = (sign: unknown, v: number) =>
        String(sign ?? '').toUpperCase() === 'D'
          ? { dr: v, cr: 0 }
          : String(sign ?? '').toUpperCase() === 'C'
            ? { dr: 0, cr: v }
            : { dr: 0, cr: 0 };
      await audit(
        0,
        Number(r.g) !== 0 ? 'G' : 'A',
        side(r.osg, Number(r.amt)),
        side(r.gsg, Number(r.g)),
      );
      if (Number(r.s) !== 0) await audit(1, 'S', { dr: 0, cr: 0 }, side(r.ssg, Number(r.s)));
    }
    await tx.$executeRawUnsafe(
      `DELETE FROM "OP_DATA" WHERE ${opDataWhere} AND "DATA_TYPE"=$5`,
      coCode,
      lcCode,
      coYear,
      acCode,
      DATA_TYPE,
    );
    await tx.$executeRawUnsafe(
      `DELETE FROM "OP_DETL" WHERE ${opDataWhere}`,
      coCode,
      lcCode,
      coYear,
      acCode,
    );
    await tx.$executeRawUnsafe(
      `DELETE FROM "AC_DATA" WHERE ${opDataWhere} AND "DATA_TYPE"=$5`,
      coCode,
      lcCode,
      coYear,
      acCode,
      DATA_TYPE,
    );
    return { deleted: true };
  });
}
