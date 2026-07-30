import { insertRowTx } from '../posting/posting.js';

/**
 * Typed report staging tables — `FINE_DATA` and `LEDR_AC_DATA`.
 *
 * These are distinct from `REPORT_DATA` (the 33-slot grid snapshot in `reportGridStaging.ts`). The
 * desktop materialises these two with real, typed columns before running a metal-ledger or balance
 * report: `RP_LEDR.cs` clears them and repopulates with `INSERT INTO … SELECT` over the transaction
 * detail, then Crystal binds the staged rows rather than the live tables.
 *
 * They are not optional plumbing. **`FINE_DATA` is bound by nine Crystal layouts** (`JmUdFine`,
 * `JmUdFineSl`, `JmUdFineHzSumm`, `JmUdFineHzSummVch`, `LedrInOut`, `LedrInOutWh`, …) and
 * **`LEDR_AC_DATA` by eight** (`AcLedgerSelected`, `BalanceHz`, `TRialBalHz`, `AcSummLdr`,
 * `ProfitLossHz`, `RojMelCrDr`, …). Until they are written those seventeen layouts render blank, which
 * is exactly the "report binding exists but the source column was never written" case Phase G predicted.
 *
 * Both follow the desktop's clear-then-fill contract, scoped to the company, so a re-run replaces the
 * previous materialisation instead of accumulating duplicates.
 */

/** `FINE_DATA` — the 34 columns `RP_LEDR.cs` inserts, in its own order. */
export const FINE_DATA_COLUMNS = [
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'SR_NO',
  'ISR_NO',
  'VCH_DATE',
  'VCH_TYPE',
  'BOOK_NAME',
  'AC_CODE',
  'AC_NAME',
  'LD_CODE',
  'IT_CODE',
  'IT_DESC',
  'TAG_NO',
  'ITM_PCS',
  'ITM_GWT',
  'ITM_NWT',
  'ITM_TOUCH',
  'ITM_WEST',
  'ITM_FINE',
  'ITM_RATE',
  'ITM_AMT',
  'LBR_RATE',
  'LBR_AMT',
  'OTH_AMT',
  'NET_AMT',
  'CR_AMT',
  'DR_AMT',
  'TR_TYPE',
  'ITM_SIGN',
  'ENTRY_TYPE',
  'DATA_TYPE',
] as const;

/** `LEDR_AC_DATA` — the 14 columns `RP_LEDR.cs` inserts. */
export const LEDR_AC_DATA_COLUMNS = [
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'AC_CODE',
  'VCH_DT',
  'DR_AMT',
  'CR_AMT',
  'DR_FINE_WT',
  'CR_FINE_WT',
  'DR_SL_FINE',
  'CR_SL_FINE',
  'DATA_TYPE',
  'MAIN_USER',
] as const;

export interface StagingScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear?: string;
  coBook?: string;
}

export interface FineDataRow {
  vchNo?: string;
  srNo?: number;
  iSrNo?: number;
  vchDate?: Date | string | null;
  vchType?: string;
  bookName?: string;
  acCode?: string;
  acName?: string;
  ldCode?: string;
  itCode?: string;
  itDesc?: string;
  tagNo?: string;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  westPct?: number;
  fineWt?: number;
  rate?: number;
  amount?: number;
  labourRate?: number;
  labourAmount?: number;
  otherAmount?: number;
  netAmount?: number;
  crAmt?: number;
  drAmt?: number;
  trType?: string;
  itmSign?: string;
  entryType?: string;
  dataType?: string;
  coBook?: string;
}

export interface LedgerAcDataRow {
  acCode?: string;
  vchDate?: Date | string | null;
  drAmt?: number;
  crAmt?: number;
  drFineWt?: number;
  crFineWt?: number;
  drSilverFine?: number;
  crSilverFine?: number;
  dataType?: string;
  mainUser?: string;
  /** `AC_GR` — the account group the balance and trial-balance layouts group by. */
  acGroup?: string;
  coBook?: string;
}

const n = (v: unknown): number => (v == null ? 0 : Number(v) || 0);
const t = (v: unknown, len: number): string | null =>
  String(v ?? '')
    .trim()
    .slice(0, len) || null;
/** ISO date text for the varchar date columns in these staging tables. */
const isoDate = (v: unknown): string | null => {
  const d = date(v);
  return d ? d.toISOString().slice(0, 10) : null;
};

/** Three-decimal weight text, matching the desktop's `"0.000"` formatting for weight display columns. */
const weightText = (v: unknown): string => n(v).toFixed(3);

const date = (v: unknown): Date | null => {
  if (v == null || v === '') return null;
  const d = new Date(v as string);
  return Number.isNaN(d.getTime()) ? null : d;
};

/**
 * Clear a company's staged rows. The desktop deletes by company before every materialisation, so a
 * report run never mixes two periods.
 */
async function clearTx(tx: any, table: string, scope: StagingScope): Promise<void> {
  await tx.$executeRawUnsafe(
    `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
    scope.tenantId,
    scope.coCode,
  );
}

/** Materialise `FINE_DATA` for the metal-ledger reports. Returns the row count written. */
export async function stageFineDataTx(
  tx: any,
  scope: StagingScope,
  rows: FineDataRow[],
): Promise<number> {
  await clearTx(tx, 'FINE_DATA', scope);
  let written = 0;
  for (const [index, row] of rows.entries()) {
    await insertRowTx(tx, 'FINE_DATA', scope.tenantId, {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      CO_YEAR: t(scope.coYear, 10),
      CO_BOOK: t(row.coBook ?? scope.coBook, 3),
      VCH_NO: t(row.vchNo, 8),
      SR_NO: row.srNo ?? index + 1,
      ISR_NO: row.iSrNo ?? 0,
      VCH_DATE: date(row.vchDate),
      VCH_TYPE: t(row.vchType, 6),
      BOOK_NAME: t(row.bookName, 20),
      AC_CODE: t(row.acCode, 8),
      AC_NAME: t(row.acName, 50),
      LD_CODE: t(row.ldCode, 8),
      IT_CODE: t(row.itCode, 5),
      IT_DESC: t(row.itDesc, 50),
      TAG_NO: t(row.tagNo, 15),
      ITM_PCS: n(row.pcs),
      ITM_GWT: n(row.grossWt),
      ITM_NWT: n(row.netWt),
      ITM_TOUCH: n(row.touch),
      ITM_WEST: n(row.westPct),
      ITM_FINE: n(row.fineWt),
      ITM_RATE: n(row.rate),
      ITM_AMT: n(row.amount),
      LBR_RATE: n(row.labourRate),
      LBR_AMT: n(row.labourAmount),
      OTH_AMT: n(row.otherAmount),
      NET_AMT: n(row.netAmount),
      CR_AMT: n(row.crAmt),
      DR_AMT: n(row.drAmt),
      TR_TYPE: t(row.trType, 1),
      ITM_SIGN: t(row.itmSign, 1),
      ENTRY_TYPE: t(row.entryType, 1),
      DATA_TYPE: t(row.dataType, 1),
    });
    written += 1;
  }
  return written;
}

/** Materialise `LEDR_AC_DATA` for the balance, trial-balance and profit-and-loss layouts. */
export async function stageLedgerAcDataTx(
  tx: any,
  scope: StagingScope,
  rows: LedgerAcDataRow[],
): Promise<number> {
  await clearTx(tx, 'LEDR_AC_DATA', scope);
  let written = 0;
  for (const row of rows) {
    await insertRowTx(tx, 'LEDR_AC_DATA', scope.tenantId, {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      CO_YEAR: t(scope.coYear, 9),
      CO_BOOK: t(row.coBook ?? scope.coBook, 3),
      AC_CODE: t(row.acCode, 8),
      // VCH_DT is varchar(255) in the restored schema, not a date. The desktop's INSERT…SELECT relied on
      // SQL Server's implicit date-to-string conversion, whose format is locale-dependent and therefore
      // ambiguous; ISO `yyyy-MM-dd` is written instead because it is unambiguous and sorts correctly as
      // text, which is how Crystal binds this column.
      VCH_DT: isoDate(row.vchDate),
      DR_AMT: n(row.drAmt),
      CR_AMT: n(row.crAmt),
      // DR_FINE_WT / CR_FINE_WT are varchar(255) too, so the weight is written with its three decimals
      // rather than coerced to a number.
      DR_FINE_WT: weightText(row.drFineWt),
      CR_FINE_WT: weightText(row.crFineWt),
      // Only the GOLD fine-weight pair is varchar in the restored schema; the SILVER pair is numeric.
      // Mixing them up produced `42804 column is of type numeric but expression is of type text`.
      DR_SL_FINE: n(row.drSilverFine),
      CR_SL_FINE: n(row.crSilverFine),
      DATA_TYPE: t(row.dataType, 1),
      AC_GR: t(row.acGroup, 20),
      MAIN_USER: t(row.mainUser, 15),
    });
    written += 1;
  }
  return written;
}

/** `DM_KR_DATA` — diamond movement per karigar, bound by `KrDmWtInOut` and `KrDmIsuRec`. */
export const DM_KR_DATA_COLUMNS = [
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
  'CO_BOOK',
  'VCH_NO',
  'MAIN_SRNO',
  'SR_NO',
  'ISR_NO',
  'VCH_DATE',
  'ENTRY_TYPE',
  'BOOK_NAME',
  'AC_CODE',
  'DM_LOT',
  'IT_CODE',
  'DM_CODE',
  'DM_SIZE',
  'DM_PCS',
  'DM_WT',
  'DM_SIGN',
  'DM_RATE',
  'DM_AMT',
  'EMP_CODE',
  'MAIN_USER',
] as const;

export interface DiamondKarigarRow {
  vchNo?: string;
  mainSrNo?: number;
  srNo?: number;
  iSrNo?: number;
  vchDate?: Date | string | null;
  entryType?: string;
  bookName?: string;
  acCode?: string;
  dmLot?: string;
  itCode?: string;
  dmCode?: string;
  dmSize?: string;
  pcs?: number;
  weight?: number;
  sign?: string;
  rate?: number;
  amount?: number;
  empCode?: string;
  mainUser?: string;
  coBook?: string;
}

export async function stageDiamondKarigarTx(
  tx: any,
  scope: StagingScope,
  rows: DiamondKarigarRow[],
): Promise<number> {
  await clearTx(tx, 'DM_KR_DATA', scope);
  let written = 0;
  for (const [index, row] of rows.entries()) {
    await insertRowTx(tx, 'DM_KR_DATA', scope.tenantId, {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      CO_YEAR: t(scope.coYear, 10),
      CO_BOOK: t(row.coBook ?? scope.coBook, 3),
      VCH_NO: t(row.vchNo, 8),
      MAIN_SRNO: n(row.mainSrNo),
      SR_NO: row.srNo ?? index + 1,
      ISR_NO: n(row.iSrNo),
      VCH_DATE: date(row.vchDate),
      ENTRY_TYPE: t(row.entryType, 1),
      BOOK_NAME: t(row.bookName, 20),
      AC_CODE: t(row.acCode, 8),
      DM_LOT: t(row.dmLot, 10),
      IT_CODE: t(row.itCode, 6),
      DM_CODE: t(row.dmCode, 8),
      DM_SIZE: t(row.dmSize, 20),
      DM_PCS: n(row.pcs),
      DM_WT: n(row.weight),
      DM_SIGN: t(row.sign, 1),
      DM_RATE: n(row.rate),
      DM_AMT: n(row.amount),
      EMP_CODE: t(row.empCode, 3),
      MAIN_USER: t(row.mainUser, 15),
    });
    written += 1;
  }
  return written;
}

/** `TEMP_ADD` — the address/label staging behind `TempAdd2`, `TempAdd3` and `TempPhone`. */
export const TEMP_ADD_COLUMNS = [
  'CO_CODE',
  'LC_CODE',
  'AC_CODE',
  'AC_NAME',
  'AC_ADD1',
  'AC_ADD2',
  'AC_ADD3',
  'AC_CITY',
  'AC_PIN',
  'AC_PHONE',
  'AC_MOBILE',
  'AC_MOBILE2',
  'AC_EMAIL',
  'AC_PARSON',
  'AC_AREA',
] as const;

export interface AddressRow {
  acCode?: string;
  acName?: string;
  add1?: string;
  add2?: string;
  add3?: string;
  city?: string;
  pin?: string;
  phone?: string;
  mobile?: string;
  mobile2?: string;
  email?: string;
  /** Desktop spelling: `AC_PARSON`, not `AC_PERSON`. Preserved so the Crystal binding resolves. */
  person?: string;
  area?: string;
}

export async function stageAddressLabelsTx(
  tx: any,
  scope: StagingScope,
  rows: AddressRow[],
): Promise<number> {
  await clearTx(tx, 'TEMP_ADD', scope);
  let written = 0;
  for (const row of rows) {
    await insertRowTx(tx, 'TEMP_ADD', scope.tenantId, {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      AC_CODE: t(row.acCode, 10),
      AC_NAME: t(row.acName, 50),
      AC_ADD1: t(row.add1, 50),
      AC_ADD2: t(row.add2, 50),
      AC_ADD3: t(row.add3, 50),
      AC_CITY: t(row.city, 30),
      AC_PIN: t(row.pin, 10),
      AC_PHONE: t(row.phone, 20),
      AC_MOBILE: t(row.mobile, 21),
      AC_MOBILE2: t(row.mobile2, 21),
      AC_EMAIL: t(row.email, 50),
      AC_PARSON: t(row.person, 50),
      AC_AREA: t(row.area, 50),
    });
    written += 1;
  }
  return written;
}
