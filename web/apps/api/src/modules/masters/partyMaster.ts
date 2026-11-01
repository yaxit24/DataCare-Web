import { round, vbVal } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { insertRowTx } from '../posting/posting.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import { openingHeads, writePartyOpeningTx } from '../finance/partyOpening.js';
import { requiredVersion, versionOf } from '../vouchers/version.js';

/**
 * Party master (desktop MS_ACCT, menu Master → Party; MDI_FORM.cs:7600-7609 opens the form directly). One AC_MAST row
 * per account code of a location, with its opening (OP_DATA and the AC_DATA legs of book 000) on a new entry, its
 * AC_MAST_SRNO serial row and its photo.
 *
 * - The list (MS_ACCT_Load :5944-5958, refilled after Save and Delete): with BRANCH_ALL_AC_SHOW every account of the
 *   company ordered by location and code; at a location other than 00 the company's codes below 100 and the location's
 *   codes from 200, ordered by code; at location 00 the location's accounts ordered by their first two characters,
 *   length and code. The search box keeps the names that contain the text or the mobiles that start with it
 *   (Text1_TextChanged :6647-6690); typing the name of a new entry keeps the names that start with it (:7280-7470).
 * - CLEAR_DATA (:6134-6355) offers the next code (nextPartyCodeTx) with the cursor in the name; Ctrl+E unlocks the code.
 * - DISPLAY_DATA (:6356-6587) reads the code of the location (of the company with BRANCH_ALL_AC_SHOW; a row of another
 *   location says "This Ac Code Is Branch With : <lc> You Cant Change..."), the group's name, the reference's name and
 *   the opening, whose boxes become read-only.
 * - BtnSave_Click (:7650-7962): the edit right for an opened party; with BRANCH_ALL_AC_SHOW the mobile is required; a
 *   five-character code is a software default account and saves only after Ctrl+E (at location 00); a blank code, name or
 *   group says "Enter Party Name and Account group Detail"; a new entry whose code exists takes the next code; the
 *   location's row of the code is deleted and every box inserted with MAIN_USER, DATA_TRFR 'N', VISIT_TRAN 'AC', AC_TYPE
 *   as the type's first letter and a date box that is not a date as NULL; a new entry with an opening writes OP_DATA
 *   (book 000, voucher 00000, DATA_TRFR 'Y') and its ledger legs (Ac_Ledr.AcOp_Ledr); the AC_MAST_SRNO row is replaced.
 *   Leaving the name refuses a name another listed code has (tAcName_Validating :7624-7648).
 * - BtnDelete_Click (:7963-8025): the delete right; a blank code; a code with AC_DATA rows outside the opening voucher is
 *   in use; a software default account is refused; the AC_MAST_SRNO, AC_MAST, OP_DATA and AC_DATA (book 000 of the year)
 *   rows go.
 *
 * Deliberate differences, recorded on the gap:
 * - Save writes AC_MAST, the opening and AC_MAST_SRNO in one transaction (the desktop commits AC_MAST first and writes the
 *   rest after it, the serial row in its master database); an opened party carries the version read with it.
 * - A new entry never replaces an account: when the next code is taken too the save is refused (the desktop would delete
 *   and rewrite that account).
 * - The next code also counts AC_MAST's codes, as migrated companies have no AC_MAST_SRNO rows; and the two-character
 *   location prefix and the 80000 series add 1 to the last five digits (the desktop adds 1 to the whole code, prefix
 *   included, so location 01's second party would get 01100202 and the third the same code again).
 * - A code that is not a number (the web's seeded accounts) belongs to its location's list; the desktop's CAST fails on it.
 * - The opening boxes are read-only for every opened party (the desktop leaves them editable when the party has no
 *   opening and then ignores them); the opening of an opened party is edited in Party Opening.
 * - The opening shown is the year's (book 000); the desktop reads the first OP_DATA row of the code in any year.
 * - Delete refuses a software default account; the desktop shows " You Can't Delete Software Default Account...." and
 *   then still asks and deletes.
 */
export class PartyMasterValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'PartyMasterValidationError';
  }
}

export class PartyVersionConflictError extends Error {
  readonly code = 'party-version-conflict';
  readonly statusCode = 409;
  constructor() {
    super(
      'This party was changed by someone else after you opened it. Open it again before saving or deleting.',
    );
    this.name = 'PartyVersionConflictError';
  }
}

export interface PartyScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear?: string;
}

/** The text boxes of the screen, their AC_MAST columns and MaxLength (DataCareNext.MS_ACCT.resx). */
export const PARTY_FIELDS = [
  ['name', 'AC_NAME', 50],
  ['group', 'AC_GR', 2],
  ['mainGroup', 'AC_MAIN_GR', 1],
  ['mobile', 'AC_MOBILE', 15],
  ['phone', 'AC_PHONE', 15],
  ['person', 'AC_PERSON', 40],
  ['short', 'AC_SHORT', 5],
  ['address1', 'AC_ADD1', 50],
  ['address2', 'AC_ADD2', 50],
  ['address3', 'AC_ADD3', 50],
  ['city', 'AC_CITY', 20],
  ['pin', 'AC_PIN', 8],
  ['area', 'AC_AREA', 25],
  ['gstNo', 'AC_GSTNO', 15],
  ['panNo', 'AC_PANNO', 20],
  ['lcsNo', 'LCS_NO', 15],
  ['state', 'AC_STATE', 20],
  ['district', 'AC_DISTRICT', 21],
  ['mainAcCode', 'MAIN_AC_CODE', 8],
  // tRefAc's MaxLength is 10; AC_REF_CODE holds an account code (8).
  ['refCode', 'AC_REF_CODE', 8],
  ['refName', 'AC_REF_NAME', 50],
  ['mobile2', 'AC_MOBILE2', 15],
  ['phone2', 'AC_PHONE2', 15],
  ['aadhaar', 'AC_ADHAR_NO', 12],
  ['passport', 'PASSPORT_NO', 15],
  ['country', 'AC_COUNTRY', 20],
  ['bankName', 'BANK_NAME', 50],
  ['bankArea', 'BANK_AREA', 40],
  ['bankAcNo', 'BANK_AC_NO', 30],
  ['rtgs', 'BANK_RTGS_NO', 30],
  ['email', 'AC_EMAIL', 50],
  ['khata', 'AC_KHATA_NO', 10],
] as const;
export type PartyFieldKey = (typeof PARTY_FIELDS)[number][0];

/** The number boxes: Val() of the text (BtnSave_Click :7806-7838) and the places DISPLAY_DATA shows. */
export const PARTY_NUMBERS = [
  ['crDays', 'AC_CR_DAYS', 0],
  ['dpcPrc', 'DPC_PRC', 2],
  ['intPrc', 'AC_INT_PRC', 2],
  ['amtLimit', 'AMT_LIMIT', 2],
  ['goldLimit', 'GOLD_LIMIT', 3],
  ['silverLimit', 'SILVER_LIMIT', 3],
] as const;
export type PartyNumberKey = (typeof PARTY_NUMBERS)[number][0];

/** The check boxes, stored Y/N. */
export const PARTY_FLAGS = [
  ['defaulter', 'DEFAULTER_AC'],
  ['withTds', 'WITH_TDS_TAX'],
  ['member', 'AC_WITH_MEMB_COM'],
  ['shareHolder', 'AC_SHARE_HOLDER_COM'],
] as const;
export type PartyFlagKey = (typeof PARTY_FLAGS)[number][0];

/** The masked date boxes: the text columns keep dd/MM/yyyy, the date columns a date. */
export const PARTY_DATES = [
  ['birthDate', 'BR_DATE', 'text'],
  ['anniversary', 'AN_DATE', 'text'],
  ['lBirthDate', 'L_BR_DATE', 'date'],
  ['lastVisit', 'LAST_VISIT', 'text'],
  ['ledgerDate', 'LAST_DATE', 'text'],
  ['trnDate', 'TRN_DATE', 'date'],
  ['custIdDate', 'CUST_ID_DATE', 'date'],
] as const;
export type PartyDateKey = (typeof PARTY_DATES)[number][0];

/** cboAcType's items (MS_ACCT_Load); the save keeps the first letter. */
export const PARTY_AC_TYPES = ['A', 'B', 'C', 'D', 'E'] as const;

export type PartyValues = Partial<Record<PartyFieldKey | PartyDateKey, string>> &
  Partial<Record<PartyNumberKey, string | number>> &
  Partial<Record<PartyFlagKey, boolean>> & {
    acType?: string;
    /** cboGstType: 'L' Local (index 0) or 'I' Inter state (index 1). */
    gstType?: string;
  };

export interface PartyOpeningInput {
  amount?: string | number;
  sign?: string;
  gold?: string | number;
  goldSign?: string;
  silver?: string | number;
  silverSign?: string;
}

export interface PartySaveInput {
  scope: PartyScope;
  user: string;
  entryMode: 'A' | 'E';
  code: string;
  /** The code box was unlocked with Ctrl+E (its MistyRose colour, MS_ACCT_KeyDown :6735-6745). */
  unlocked?: boolean;
  values: PartyValues;
  opening?: PartyOpeningInput;
  expectedVersion?: unknown;
}

const text = (value: unknown): string => String(value ?? '').trim();
/** MS_ACCT_KeyPress upper-cases every key and drops the apostrophe (MS_ACCT.cs:6606-6619). */
const typed = (value: unknown): string => text(value).toUpperCase().replace(/'/g, '');
/** tEmail lower-cases what the form upper-cased (CharacterCasing Lower, :5050). */
const typedEmail = (value: unknown): string => text(value).toLowerCase().replace(/'/g, '');
const numeric = (code: string): boolean => /^\d+$/.test(code);

/** Desktop texts of MS_ACCT. */
export const PARTY_MESSAGES = {
  NO_RIGHTS: 'You Have No Rights.....',
  NO_PRINT_RIGHTS: 'You Have No Print Rights.....',
  DETAIL_REQUIRED: 'Enter Party Name and Account group Detail',
  MULTI_BRANCH_MOBILE:
    'Please Insert Mobile No Because This Ac With Multi Branch Acconut so Mobile No Is Mandatory....',
  DEFAULT_MAIN_LOCATION: ' You Change Software Default Account With Main Location....',
  DEFAULT_LOCKED: " You Can't Change Software Default Account....",
  IN_USE: "You Can't Delete Record This Party Code Use in Transection....",
  DEFAULT_DELETE_VB: ' You Cant Delete Default Account ....',
  DEFAULT_DELETE: " You Can't Delete Software Default Account....",
  DELETE_CONFIRM: 'Are You Sure To Delete This Account now?',
  DELETED: 'Delete Success.',
  SAVED: 'Data Are Saved.',
  SELECT_FOR_DELETE: DESKTOP_MESSAGES.ACCOUNT_SELECT_FOR_DELETE,
  NAME_REQUIRED: DESKTOP_MESSAGES.PARTY_NAME_REQUIRED,
  PHOTO_DELETE_CONFIRM: 'Are You Sure To Delete This Image now?',
} as const;
/** tAcName_Validating (:7638). */
export const partyNameTakenMessage = (code: string): string =>
  `This Ac Name already Exist in  '${code}'  Ac Code... Please Change Account Name...`;
/** tAcCode_Validating (:6633). */
export const partyCodeTakenMessage = (name: string): string =>
  `This Ac Code already Exist in  '${name}'  Party Name...Please Change Party Name...`;
/** DISPLAY_DATA (:6371). */
export const partyBranchMessage = (lc: string): string =>
  `This Ac Code Is Branch With : ${lc} You Cant Change...`;
/** tmobile_KeyDown (:6922). */
export const partyMobileTakenMessage = (name: string): string =>
  `This Mobile No = ${name}  With this Account .....`;
/** tmobile_KeyDown with BRANCH_ALL_AC_SHOW (:6911). */
export const partyMobileBranchMessage = (name: string, code: string, lc: string): string =>
  `This Mobile No With = ${name} Party Name  And AcCode = ${code}  Branch With  ${lc}  Branch ...`;
/** tAcShort_KeyDown and tMobile2_KeyDown (:6945, :7262) say the same words. */
export const partyShortTakenMessage = (name: string): string =>
  `This Short Name = ${name}  With this Account .....`;

/**
 * A masked date box (dd/MM/yyyy). Information.IsDate decides whether it is written (:7801-7805); a box that is not a date
 * is NULL. Returns the box text (text columns) and the ISO date (date columns).
 */
export function partyDate(value: unknown): { text: string; iso: string } | null {
  const m = /^(\d{1,2})\/(\d{1,2})\/(\d{4})$/.exec(text(value));
  if (!m) return null;
  const [day, month, year] = [Number(m[1]), Number(m[2]), Number(m[3])];
  const date = new Date(Date.UTC(year, month - 1, day));
  if (
    date.getUTCFullYear() !== year ||
    date.getUTCMonth() !== month - 1 ||
    date.getUTCDate() !== day
  )
    return null;
  const pad = (n: number) => String(n).padStart(2, '0');
  return { text: `${pad(day)}/${pad(month)}/${year}`, iso: `${year}-${pad(month)}-${pad(day)}` };
}

const pad = (n: number, width: number) => String(Math.trunc(n)).padStart(width, '0');

export interface NextCodeRules {
  lcCode: string;
  /** CO_SET.AC_LC_CODE_LEN, 1 when blank (MS_OPNCOMP.cs:737-740). */
  lcCodeLength: number;
  /** CO_SET.VB_IMPORT = 'Y'. */
  vbImport: boolean;
  /** CO_MAST.CO_TYPE. */
  coType: string;
}

/**
 * CLEAR_DATA's next code (MS_ACCT.cs:6230-6340) from the location's codes. Pure, so every branch is unit-tested.
 * - VB_IMPORT: company type P or B takes the 80000 series of five digits (80001 first); another location takes its
 *   digit and the next of its six-character codes' last five (x00201 first); location 00 the next five-digit code
 *   below 80000 (00101 first).
 * - AC_LC_CODE_LEN 1 (the default): the location's second character and five digits, 80001 first for company type P or
 *   B and 00201 first otherwise.
 * - AC_LC_CODE_LEN 2: the location code and five digits, the same way.
 */
export function nextPartyCode(codes: readonly string[], rules: NextCodeRules): string {
  const lc = rules.lcCode;
  const digit = lc.slice(1, 2);
  const series = rules.coType === 'P' || rules.coType === 'B';
  const five = (s: string) => /^\d{5}$/.test(s);
  const ofLength = (length: number) => codes.filter((c) => c.length === length);
  /** The first row of `ORDER BY <key> DESC`. */
  const top = (rows: string[], key: (c: string) => string = (c) => c): string | null =>
    rows.reduce<string | null>((m, c) => (m === null || key(c) > key(m) ? c : m), null);
  const right5 = (c: string) => c.slice(-5);
  const mid5 = (c: string) => c.slice(1, 6);
  if (rules.vbImport) {
    if (series) {
      // LEN(AC_CODE) = 5 AND RIGHT(AC_CODE,5) > 80000; Format(Val(CoCode) + 1, "00000").
      const t = top(ofLength(5).filter((c) => five(c) && Number(c) > 80000));
      return t ? pad(vbVal(t) + 1, 5) : '80001';
    }
    if (lc !== '00') {
      // LEN(AC_CODE) = 6; Mid(LC,2,1) + Format(Val(Mid(CoCode,2,5)) + 1, "00000").
      const t = top(ofLength(6));
      return t ? digit + pad(vbVal(mid5(t)) + 1, 5) : `${digit}00201`;
    }
    // LEN(AC_CODE) = 5 AND RIGHT(AC_CODE,5) < 80000; Format(Val(CoCode) + 1, "00000").
    const t = top(ofLength(5).filter((c) => five(c) && Number(c) < 80000));
    return t ? pad(vbVal(t) + 1, 5) : '00101';
  }
  if (rules.lcCodeLength === 1) {
    if (series) {
      // LEN(AC_CODE) = 6 AND RIGHT(AC_CODE,5) > 80000 (the next is the last five digits + 1, see above).
      const t = top(ofLength(6).filter((c) => five(right5(c)) && Number(right5(c)) > 80000));
      return t ? digit + pad(Number(right5(t)) + 1, 5) : `${digit}80001`;
    }
    // LEN(AC_CODE) = 6 AND SUBSTRING(AC_CODE,2,5) < 80000 ORDER BY SUBSTRING(AC_CODE,2,5) DESC.
    const t = top(
      ofLength(6).filter((c) => five(mid5(c)) && Number(mid5(c)) < 80000),
      mid5,
    );
    return t ? digit + pad(vbVal(mid5(t)) + 1, 5) : `${digit}00201`;
  }
  // LEN(AC_CODE) = 7 AND RIGHT(AC_CODE,5) > or < 80000 (the next is the last five digits + 1, see above).
  const t = top(
    ofLength(7).filter(
      (c) => five(right5(c)) && (series ? Number(right5(c)) > 80000 : Number(right5(c)) < 80000),
    ),
  );
  return t ? lc + pad(Number(right5(t)) + 1, 5) : `${lc}${series ? '80001' : '00201'}`;
}

const lockTx = (tx: any, scope: PartyScope) =>
  tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `party-master:${scope.tenantId}:${scope.coCode}`,
  );

async function partyVersionTx(tx: any, scope: PartyScope, code: string): Promise<string> {
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT row_id::text, to_jsonb(r) - 'row_id' AS r FROM "AC_MAST" r
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4 ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    code,
  );
  return versionOf({ AC_MAST: rows });
}

interface PartyRules extends NextCodeRules {
  allBranch: boolean;
  coState: string;
  coStateCode: string;
}

async function partyRulesTx(tx: any, scope: PartyScope): Promise<PartyRules> {
  const behavior = await resolveSettingsBehaviorTx(tx, scope);
  const [co]: any[] = await tx.$queryRawUnsafe(
    `SELECT "CO_TYPE","CO_STATE","CO_STATE_CODE" FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
  );
  return {
    lcCode: scope.lcCode,
    lcCodeLength: behavior.accountCodeLength ?? 1,
    vbImport: behavior.vbImport,
    allBranch: behavior.branchAllAccountShow,
    coType: text(co?.CO_TYPE).toUpperCase(),
    coState: text(co?.CO_STATE),
    coStateCode: text(co?.CO_STATE_CODE),
  };
}

export interface PartyListRow {
  code: string;
  name: string;
  mobile: string;
  lc: string;
}

/** MS_ACCT_Load's list (RsMast) for the location and settings. */
async function partyListTx(tx: any, scope: PartyScope, allBranch: boolean): Promise<PartyListRow[]> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE","AC_NAME","AC_MOBILE","LC_CODE" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
  );
  const all = rows.map((r) => ({
    code: text(r.AC_CODE),
    name: text(r.AC_NAME),
    mobile: text(r.AC_MOBILE),
    lc: text(r.LC_CODE),
  }));
  const byCode = (a: PartyListRow, b: PartyListRow) =>
    a.code < b.code ? -1 : a.code > b.code ? 1 : 0;
  if (allBranch)
    return all.sort((a, b) => (a.lc < b.lc ? -1 : a.lc > b.lc ? 1 : byCode(a, b)));
  if (scope.lcCode !== '00')
    return all
      .filter((r) =>
        numeric(r.code)
          ? Number(r.code) < 100 || (r.lc === scope.lcCode && Number(r.code) >= 200)
          : r.lc === scope.lcCode,
      )
      .sort(byCode);
  return all
    .filter((r) => r.lc === scope.lcCode)
    .sort((a, b) => {
      const head = a.code.slice(0, 2).localeCompare(b.code.slice(0, 2));
      if (head) return head;
      if (a.code.length !== b.code.length) return a.code.length - b.code.length;
      return byCode(a, b);
    });
}

/** The location's codes in AC_MAST and AC_MAST_SRNO, for the next code. */
async function locationCodesTx(tx: any, scope: PartyScope): Promise<string[]> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE" c FROM "AC_MAST_SRNO" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
      UNION SELECT "AC_CODE" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
  );
  return rows.map((r) => text(r.c)).filter(Boolean);
}

export interface PartyListing {
  rows: PartyListRow[];
  nextCode: string;
  allBranch: boolean;
  coState: string;
}

export async function listParties(prisma: any, scope: PartyScope): Promise<PartyListing> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rules = await partyRulesTx(tx, scope);
    return {
      rows: await partyListTx(tx, scope, rules.allBranch),
      nextCode: nextPartyCode(await locationCodesTx(tx, scope), rules),
      allBranch: rules.allBranch,
      coState: rules.coState,
    };
  });
}

export interface PartyView {
  code: string;
  values: Record<string, string | boolean>;
  groupName: string;
  opening: {
    amount: string;
    sign: 'C' | 'D';
    gold: string;
    goldSign: 'C' | 'D';
    silver: string;
    silverSign: 'C' | 'D';
    exists: boolean;
  };
  version: string;
}

/** Strings.Format(Fnv(x), "0.00") / "0.000" of DISPLAY_DATA (half-up, as Strings.Format). */
const fixed = (value: unknown, places: number) => round(vbVal(value), places).toFixed(places);
const sign = (value: unknown): 'C' | 'D' => (text(value).toUpperCase() === 'D' ? 'D' : 'C');

/** DISPLAY_DATA. Returns { branch } for a code of another location and null for an unknown code. */
export async function getParty(
  prisma: any,
  scope: PartyScope,
  codeRaw: string,
): Promise<PartyView | { branch: string } | null> {
  const code = typed(codeRaw);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT *, to_char("L_BR_DATE",'DD/MM/YYYY') l_br, to_char("TRN_DATE",'DD/MM/YYYY') trn,
              to_char("CUST_ID_DATE",'DD/MM/YYYY') cust_id
         FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 ORDER BY ("LC_CODE"=$4) DESC, row_id`,
      scope.tenantId,
      scope.coCode,
      code,
      scope.lcCode,
    );
    const row = rows[0];
    if (!row) return null;
    if (text(row.LC_CODE) !== scope.lcCode) return { branch: text(row.LC_CODE) };
    const values: Record<string, string | boolean> = {};
    for (const [key, column] of PARTY_FIELDS) values[key] = text(row[column]);
    for (const [key, column, places] of PARTY_NUMBERS)
      values[key] = key === 'crDays' ? text(row[column] ?? '') : fixed(row[column], places);
    for (const [key, column] of PARTY_FLAGS) values[key] = text(row[column]) === 'Y';
    values.birthDate = text(row.BR_DATE);
    values.anniversary = text(row.AN_DATE);
    values.lBirthDate = text(row.l_br);
    values.lastVisit = text(row.LAST_VISIT);
    values.ledgerDate = text(row.LAST_DATE);
    values.trnDate = text(row.trn);
    values.custIdDate = text(row.cust_id);
    values.acType = text(row.AC_TYPE);
    values.gstType = text(row.AC_GST_TYPE) === 'I' ? 'I' : 'L';
    values.mainUser = text(row.MAIN_USER);
    const [group]: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_GR_NAME" FROM "AC_GROUP" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_GR"=$3 ORDER BY row_id LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      text(row.AC_GR),
    );
    // DISPLAY_DATA takes the reference's name from the location's AC_MAST when the code is there (:6477-6481).
    if (values.refCode) {
      const [ref]: any[] = await tx.$queryRawUnsafe(
        `SELECT "AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4 ORDER BY row_id LIMIT 1`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        values.refCode,
      );
      if (ref) values.refName = text(ref.AC_NAME);
    }
    const [op]: any[] = await tx.$queryRawUnsafe(
      `SELECT "OP_AMT","OP_SIGN","FINE_BAL","FINE_SIGN","SL_FINE_BAL","SL_FINE_SIGN" FROM "OP_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"='000' AND "AC_CODE"=$5
        ORDER BY row_id LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear ?? '',
      code,
    );
    return {
      code,
      values,
      groupName: text(group?.AC_GR_NAME),
      opening: {
        amount: op ? fixed(op.OP_AMT, 2) : '',
        sign: sign(op?.OP_SIGN),
        gold: op ? fixed(op.FINE_BAL, 3) : '',
        goldSign: sign(op?.FINE_SIGN),
        silver: op ? fixed(op.SL_FINE_BAL, 3) : '',
        silverSign: sign(op?.SL_FINE_SIGN),
        exists: Boolean(op),
      },
      version: await partyVersionTx(tx, scope, code),
    };
  });
}

/** The software default account checks shared by Save (:7700-7735) and Delete (:7986-7997). */
function defaultAccountProblem(
  code: string,
  rules: PartyRules,
  unlocked: boolean,
  action: 'save' | 'delete',
): string | null {
  if (rules.vbImport)
    return vbVal(code) < 100
      ? action === 'save'
        ? PARTY_MESSAGES.DEFAULT_MAIN_LOCATION
        : PARTY_MESSAGES.DEFAULT_DELETE_VB
      : null;
  if (code.length !== 5) return null;
  if (!unlocked)
    return action === 'save' ? PARTY_MESSAGES.DEFAULT_LOCKED : PARTY_MESSAGES.DEFAULT_DELETE;
  if (action === 'save' && rules.lcCode !== '00') return PARTY_MESSAGES.DEFAULT_MAIN_LOCATION;
  return null;
}

function cleanValues(values: PartyValues): Record<string, unknown> {
  const row: Record<string, unknown> = {};
  for (const [key, column, max] of PARTY_FIELDS) {
    const value = key === 'email' ? typedEmail(values[key]) : typed(values[key]);
    if (value.length > max)
      throw new PartyMasterValidationError(`${column} must be at most ${max} characters`);
    row[column] = value;
  }
  for (const [key, column] of PARTY_NUMBERS) {
    const n = vbVal(values[key]);
    if (n > 9_999_999_999)
      throw new PartyMasterValidationError(`${column} is larger than its box allows`);
    row[column] = n;
  }
  for (const [key, column] of PARTY_FLAGS) row[column] = values[key] ? 'Y' : 'N';
  for (const [key, column, kind] of PARTY_DATES) {
    const date = partyDate(values[key]);
    row[column] = !date ? null : kind === 'text' ? date.text : new Date(`${date.iso}T00:00:00Z`);
  }
  const acType = typed(values.acType).slice(0, 1);
  row.AC_TYPE = (PARTY_AC_TYPES as readonly string[]).includes(acType) ? acType : 'A';
  row.AC_GST_TYPE = typed(values.gstType) === 'I' ? 'I' : 'L';
  return row;
}

export async function saveParty(
  prisma: any,
  input: PartySaveInput,
): Promise<{ code: string; name: string; opening: boolean }> {
  const row = cleanValues(input.values);
  let code = typed(input.code);
  if (code.length > 8)
    throw new PartyMasterValidationError('account code must be at most 8 characters');
  const expected = input.entryMode === 'E' ? requiredVersion(input.expectedVersion) : null;
  const heads = input.entryMode === 'A' ? openingHeads(input.opening ?? {}) : null;
  if (heads && String(input.opening?.amount ?? '').trim().length > 8)
    throw new PartyMasterValidationError('opening amount must be at most 8 characters');
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    const scope = input.scope;
    const { tenantId, coCode, lcCode } = scope;
    await lockTx(tx, scope);
    const rules = await partyRulesTx(tx, scope);
    if (rules.allBranch && !row.AC_MOBILE)
      throw new PartyMasterValidationError(PARTY_MESSAGES.MULTI_BRANCH_MOBILE);
    const problem = defaultAccountProblem(code, rules, Boolean(input.unlocked), 'save');
    if (problem) throw new PartyMasterValidationError(problem);
    if (!code || !row.AC_NAME || !row.AC_GR)
      throw new PartyMasterValidationError(PARTY_MESSAGES.DETAIL_REQUIRED);
    if (expected && (await partyVersionTx(tx, scope, code)) !== expected)
      throw new PartyVersionConflictError();
    const existing: any[] = await tx.$queryRawUnsafe(
      `SELECT "MAIN_USER" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4 ORDER BY row_id`,
      tenantId,
      coCode,
      lcCode,
      code,
    );
    // An opened party that another operator deleted meanwhile is not brought back.
    if (input.entryMode === 'E' && !existing.length) throw new PartyVersionConflictError();
    // BtnSave_Click :7740-7760: a new entry whose code exists takes the next code.
    if (input.entryMode === 'A' && existing.length) {
      code = nextPartyCode(await locationCodesTx(tx, scope), rules);
      const [taken] = await tx.$queryRawUnsafe(
        `SELECT 1 FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4 LIMIT 1`,
        tenantId,
        coCode,
        lcCode,
        code,
      );
      // The desktop would replace that account; the web refuses instead.
      if (taken)
        throw new PartyMasterValidationError(
          `Account code ${code} already exists and no free next code was found; type a free code after Ctrl+E.`,
        );
    }
    // tAcName_Validating: a name another listed code has is refused.
    const namesake = (await partyListTx(tx, scope, rules.allBranch)).find(
      (r) => r.name.toUpperCase() === row.AC_NAME && r.code !== code,
    );
    if (namesake) throw new PartyMasterValidationError(partyNameTakenMessage(namesake.code));
    // The group's main group (tAcGrCode_KeyDown :7064 fills tAcMainGr from AC_GROUP).
    const [group]: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_MAIN_GR" FROM "AC_GROUP" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_GR"=$3 ORDER BY row_id LIMIT 1`,
      tenantId,
      coCode,
      row.AC_GR,
    );
    if (group) row.AC_MAIN_GR = text(group.AC_MAIN_GR).slice(0, 1);
    // MainUser: the stored user of an opened party (DISPLAY_DATA :6496), the signed-in user for a new entry.
    const mainUser =
      input.entryMode === 'E' ? text(existing[0]?.MAIN_USER) || input.user : input.user;
    await tx.$executeRawUnsafe(
      `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4`,
      tenantId,
      coCode,
      lcCode,
      code,
    );
    await insertRowTx(tx, 'AC_MAST', tenantId, {
      CO_CODE: coCode,
      LC_CODE: lcCode,
      AC_CODE: code,
      ...row,
      MAIN_USER: mainUser,
      DATA_TRFR: 'N',
      VISIT_TRAN: 'AC',
    });
    let opening = false;
    if (heads && heads.amount + heads.gold + heads.silver !== 0) {
      await writePartyOpeningTx(tx, scope, code, heads, mainUser);
      // MS_ACCT writes its opening row with DATA_TRFR 'Y' (:7884).
      await tx.$executeRawUnsafe(
        `UPDATE "OP_DATA" SET "DATA_TRFR"='Y' WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
            AND "CO_BOOK"='000' AND "AC_CODE"=$5`,
        tenantId,
        coCode,
        lcCode,
        scope.coYear ?? '',
        code,
      );
      opening = true;
    }
    await tx.$executeRawUnsafe(
      `DELETE FROM "AC_MAST_SRNO" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4`,
      tenantId,
      coCode,
      lcCode,
      code,
    );
    await insertRowTx(tx, 'AC_MAST_SRNO', tenantId, {
      CO_CODE: coCode,
      LC_CODE: lcCode,
      AC_CODE: code,
      AC_NAME: row.AC_NAME,
      AC_GR: row.AC_GR,
      MAIN_USER: mainUser,
    });
    return { code, name: String(row.AC_NAME), opening };
  });
}

export async function deleteParty(
  prisma: any,
  scope: PartyScope,
  codeRaw: string,
  options: { expectedVersion?: unknown; unlocked?: boolean } = {},
): Promise<{ code: string; deleted: number }> {
  const code = typed(codeRaw);
  if (!code) throw new PartyMasterValidationError(PARTY_MESSAGES.SELECT_FOR_DELETE);
  const expected =
    options.expectedVersion == null || options.expectedVersion === ''
      ? null
      : requiredVersion(options.expectedVersion);
  const deleted = await withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const { tenantId, coCode, lcCode } = scope;
    await lockTx(tx, scope);
    if (expected && (await partyVersionTx(tx, scope, code)) !== expected)
      throw new PartyVersionConflictError();
    const [used] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "VCH_NO"<>'00000' AND "AC_CODE"=$4 LIMIT 1`,
      tenantId,
      coCode,
      lcCode,
      code,
    );
    if (used) throw new PartyMasterValidationError(PARTY_MESSAGES.IN_USE);
    const rules = await partyRulesTx(tx, scope);
    const problem = defaultAccountProblem(code, rules, Boolean(options.unlocked), 'delete');
    if (problem) throw new PartyMasterValidationError(problem);
    await tx.$executeRawUnsafe(
      `DELETE FROM "AC_MAST_SRNO" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4`,
      tenantId,
      coCode,
      lcCode,
      code,
    );
    const n = await tx.$executeRawUnsafe(
      `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4`,
      tenantId,
      coCode,
      lcCode,
      code,
    );
    for (const table of ['OP_DATA', 'AC_DATA'])
      await tx.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"='000' AND "AC_CODE"=$5`,
        tenantId,
        coCode,
        lcCode,
        scope.coYear ?? '',
        code,
      );
    return n;
  });
  return { code, deleted: Number(deleted) };
}

/** AddCboItem (:7081-7172): the combos' entries. */
export async function partyCombos(
  prisma: any,
  scope: PartyScope,
): Promise<Record<'countries' | 'states' | 'districts' | 'cities' | 'areas', string[]>> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const distinct = async (column: string, nonBlank: boolean) =>
      (
        (await tx.$queryRawUnsafe(
          `SELECT DISTINCT coalesce("${column}",'') v FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
            ${nonBlank ? `AND coalesce("${column}",'')<>''` : ''} ORDER BY 1`,
          scope.tenantId,
          scope.coCode,
        )) as Array<{ v: string }>
      ).map((r) => text(r.v));
    const states: Array<{ v: string }> = await tx.$queryRawUnsafe(
      `SELECT v FROM (
         SELECT "AC_STATE" v FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND coalesce("AC_STATE",'')<>'' GROUP BY "AC_STATE"
         UNION ALL SELECT "STATE_NAME" v FROM "STATE_MAST" WHERE tenant_id=$1 GROUP BY "STATE_NAME") s
        ORDER BY v`,
      scope.tenantId,
      scope.coCode,
    );
    return {
      countries: await distinct('AC_COUNTRY', false),
      states: states.map((r) => text(r.v)),
      districts: await distinct('AC_DISTRICT', true),
      cities: await distinct('AC_CITY', false),
      areas: await distinct('AC_AREA', false),
    };
  });
}

/** The help lists of the screen. */
export type PartyHelp = 'names' | 'f1' | 'groups' | 'short' | 'main' | 'address' | 'member' | 'account';

/**
 * - names: tAcName F1 and tRefAc's help, the location's accounts by name (:6776, :7493);
 * - f1: the F1 button, the same with the short name for an administrator and the user (BtnF1_Click :8041);
 * - groups: tAcGrCode's help, AC_GROUP by code (:7041);
 * - short: tAcShort F1 for an administrator, the location's short names (:7240);
 * - main: tMainAcCode's help in the list's scope (:9559-9567);
 * - address / member / account: the D, S and A buttons' helps (BtnAdd :8504, BtnMemb :8541, BtnAcimp :9027).
 */
export async function partyHelp(
  prisma: any,
  scope: PartyScope,
  kind: PartyHelp,
  admin: boolean,
): Promise<Array<Record<string, string>>> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const { tenantId, coCode, lcCode } = scope;
    const q = (sql: string, ...params: unknown[]): Promise<any[]> =>
      tx.$queryRawUnsafe(sql, tenantId, coCode, ...params);
    const map = (rows: any[], cols: Record<string, string>) =>
      rows.map((r) => Object.fromEntries(Object.entries(cols).map(([k, c]) => [k, text(r[c])])));
    switch (kind) {
      case 'names':
      case 'f1':
        return map(
          await q(
            `SELECT "AC_NAME","AC_CODE","AC_SHORT","AC_GR","AC_ADD1","AC_PHONE","AC_MOBILE","MAIN_USER" FROM "AC_MAST"
              WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 ORDER BY "AC_NAME", row_id`,
            lcCode,
          ),
          kind === 'names'
            ? {
                name: 'AC_NAME',
                code: 'AC_CODE',
                group: 'AC_GR',
                address: 'AC_ADD1',
                phone: 'AC_PHONE',
                mobile: 'AC_MOBILE',
              }
            : {
                name: 'AC_NAME',
                code: 'AC_CODE',
                ...(admin ? { short: 'AC_SHORT' } : {}),
                group: 'AC_GR',
                address: 'AC_ADD1',
                phone: 'AC_PHONE',
                mobile: 'AC_MOBILE',
                user: 'MAIN_USER',
              },
        );
      case 'groups':
        return map(
          await q(
            `SELECT "AC_GR","AC_GR_NAME","AC_SUB_GR","AC_MAIN_GR" FROM "AC_GROUP" WHERE tenant_id=$1 AND "CO_CODE"=$2
              ORDER BY "AC_GR", row_id`,
          ),
          { code: 'AC_GR', name: 'AC_GR_NAME', subGroup: 'AC_SUB_GR', mainGroup: 'AC_MAIN_GR' },
        );
      case 'short':
        return map(
          await q(
            `SELECT "AC_SHORT","AC_NAME","AC_ADD1","AC_MOBILE" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
              AND "LC_CODE"=$3 AND coalesce("AC_SHORT",'')<>'' ORDER BY "AC_SHORT", row_id`,
            lcCode,
          ),
          { short: 'AC_SHORT', name: 'AC_NAME', address: 'AC_ADD1', mobile: 'AC_MOBILE' },
        );
      case 'main': {
        const rules = await partyRulesTx(tx, scope);
        const listed = new Set(
          (await partyListTx(tx, scope, rules.allBranch)).map((r) => `${r.lc}|${r.code}`),
        );
        const rows = await q(
          `SELECT a."AC_NAME",a."AC_CODE",a."LC_CODE",b."AC_GR_NAME",a."AC_AREA",a."AC_ADD1",a."AC_CITY",a."AC_MOBILE"
             FROM "AC_MAST" a LEFT JOIN "AC_GROUP" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."AC_GR"=a."AC_GR"
            WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 ORDER BY ${rules.allBranch ? 'a."LC_CODE",' : ''}a."AC_NAME", a.row_id`,
        );
        return map(
          rows.filter((r) => listed.has(`${text(r.LC_CODE)}|${text(r.AC_CODE)}`)),
          {
            name: 'AC_NAME',
            code: 'AC_CODE',
            group: 'AC_GR_NAME',
            area: 'AC_AREA',
            address: 'AC_ADD1',
            city: 'AC_CITY',
            mobile: 'AC_MOBILE',
          },
        );
      }
      case 'address':
        return map(
          await q(
            `SELECT "AC_NAME","AC_CODE","AC_AREA","AC_ADD1","AC_CITY" FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
              ORDER BY "AC_NAME", row_id`,
          ),
          { name: 'AC_NAME', code: 'AC_CODE', area: 'AC_AREA', address: 'AC_ADD1', city: 'AC_CITY' },
        );
      case 'member':
        return map(
          await q(
            `SELECT "MEMB_NAME","MEMB_CODE","SCHM_CODE","AC_ADD1","AC_CITY" FROM "AD_MEMB" WHERE tenant_id=$1
              AND "CO_CODE"=$2 AND "LC_CODE"=$3 ORDER BY "MEMB_NAME", row_id`,
            lcCode,
          ),
          {
            name: 'MEMB_NAME',
            code: 'MEMB_CODE',
            scheme: 'SCHM_CODE',
            address: 'AC_ADD1',
            city: 'AC_CITY',
          },
        );
      case 'account': {
        const rows = await q(
          `SELECT "AC_NAME","AC_CODE","AC_AREA","AC_ADD1","AC_CITY" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
            ORDER BY "AC_NAME", row_id`,
        );
        // BtnAcimp lists the codes above 99 (CAST(AC_CODE AS INT) > 99).
        return map(
          rows.filter((r) => numeric(text(r.AC_CODE)) && Number(text(r.AC_CODE)) > 99),
          { name: 'AC_NAME', code: 'AC_CODE', area: 'AC_AREA', address: 'AC_ADD1', city: 'AC_CITY' },
        );
      }
    }
  });
}

/** The boxes the D, S and A buttons copy from the picked row (BtnAdd :8512-8530, BtnMemb, BtnAcimp :9033-9050). */
export async function partyCopySource(
  prisma: any,
  scope: PartyScope,
  kind: 'address' | 'member' | 'account',
  code: string,
  scheme = '',
): Promise<Record<string, string> | null> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const { tenantId, coCode, lcCode } = scope;
    const [row]: any[] =
      kind === 'address'
        ? await tx.$queryRawUnsafe(
            `SELECT * FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 ORDER BY row_id LIMIT 1`,
            tenantId,
            coCode,
            text(code),
          )
        : kind === 'member'
          ? await tx.$queryRawUnsafe(
              `SELECT *, "MEMB_NAME" "AC_NAME", "BIRTH_DATE" "BR_DATE", "ANV_DATE" "AN_DATE" FROM "AD_MEMB"
                WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "MEMB_CODE"=$4 AND "SCHM_CODE"=$5 ORDER BY row_id LIMIT 1`,
              tenantId,
              coCode,
              lcCode,
              text(code),
              text(scheme),
            )
          : await tx.$queryRawUnsafe(
              `SELECT * FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 ORDER BY row_id LIMIT 1`,
              tenantId,
              coCode,
              text(code),
            );
    if (!row) return null;
    const copied: Record<string, string> = {
      name: text(row.AC_NAME),
      area: text(row.AC_AREA),
      address1: text(row.AC_ADD1),
      address2: text(row.AC_ADD2),
      address3: text(row.AC_ADD3),
      city: text(row.AC_CITY),
      phone: text(row.AC_PHONE),
      mobile: text(row.AC_MOBILE),
      mobile2: text(row.AC_MOBILE2),
      email: text(row.AC_EMAIL),
    };
    if (kind !== 'account') {
      const dateText = (v: unknown) =>
        v instanceof Date
          ? `${String(v.getUTCDate()).padStart(2, '0')}/${String(v.getUTCMonth() + 1).padStart(2, '0')}/${v.getUTCFullYear()}`
          : text(v);
      copied.birthDate = dateText(row.BR_DATE);
      copied.anniversary = dateText(row.AN_DATE);
    }
    return copied;
  });
}

/**
 * The Enter checks of the screen:
 * - mobile (tmobile_KeyDown :6893-6928): another account of the location (of the company with BRANCH_ALL_AC_SHOW) with
 *   this mobile;
 * - mobile2 (tMobile2_KeyDown :6930-6956): another account of the company with this mobile in either mobile box;
 * - short (tAcShort_KeyDown :7262): another account of the company with this short name.
 * Returns the desktop's message, or null when the value is free.
 */
export async function partyTaken(
  prisma: any,
  scope: PartyScope,
  kind: 'mobile' | 'mobile2' | 'short',
  valueRaw: string,
  ownCode: string,
): Promise<{ message: string; clear: boolean } | null> {
  const value = typed(valueRaw);
  if (!value) return null;
  const own = typed(ownCode);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const { tenantId, coCode, lcCode } = scope;
    if (kind === 'mobile') {
      const rules = await partyRulesTx(tx, scope);
      const [row]: any[] = await tx.$queryRawUnsafe(
        `SELECT "AC_NAME","LC_CODE","AC_CODE" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_MOBILE"=$3
          AND coalesce("AC_CODE",'')<>$4 ${rules.allBranch ? '' : 'AND "LC_CODE"=$5'} ORDER BY row_id LIMIT 1`,
        tenantId,
        coCode,
        value,
        own,
        ...(rules.allBranch ? [] : [lcCode]),
      );
      if (!row) return null;
      // With BRANCH_ALL_AC_SHOW the desktop also clears the box (:6912).
      return rules.allBranch
        ? {
            message: partyMobileBranchMessage(
              text(row.AC_NAME),
              text(row.AC_CODE),
              text(row.LC_CODE),
            ),
            clear: true,
          }
        : { message: partyMobileTakenMessage(text(row.AC_NAME)), clear: false };
    }
    const [row]: any[] = await tx.$queryRawUnsafe(
      kind === 'mobile2'
        ? `SELECT "AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND coalesce("AC_CODE",'')<>$4
            AND ("AC_MOBILE2"=$3 OR "AC_MOBILE"=$3) ORDER BY row_id LIMIT 1`
        : `SELECT "AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND coalesce("AC_CODE",'')<>$4
            AND "AC_SHORT"=$3 AND "AC_SHORT"<>'' ORDER BY row_id LIMIT 1`,
      tenantId,
      coCode,
      value,
      own,
    );
    return row ? { message: partyShortTakenMessage(text(row.AC_NAME)), clear: false } : null;
  });
}

/**
 * tGstNo_KeyDown (:6978-7018): the state of the GST number's first two digits (STATE_MAST) and the GST type, Local when
 * they are the company's state code; a blank number gives the company's state.
 */
export async function partyGstState(
  prisma: any,
  scope: PartyScope,
  gstRaw: string,
): Promise<{ state: string; gstType: 'L' | 'I' | null }> {
  const gst = typed(gstRaw);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rules = await partyRulesTx(tx, scope);
    if (!gst) return { state: rules.coState, gstType: null };
    const [state]: any[] = await tx.$queryRawUnsafe(
      `SELECT "STATE_NAME" FROM "STATE_MAST" WHERE tenant_id=$1 AND "STATE_CODE"=$2 ORDER BY row_id LIMIT 1`,
      scope.tenantId,
      gst.slice(0, 2),
    );
    if (!state) return { state: '', gstType: null };
    return {
      state: text(state.STATE_NAME),
      gstType: gst.slice(0, 2) === rules.coStateCode ? 'L' : 'I',
    };
  });
}

/** An account of the company by exact code (tRefAc :7492, tMainAcCode :9553). */
export async function partyAccount(
  prisma: any,
  scope: PartyScope,
  codeRaw: string,
): Promise<{ code: string; name: string } | null> {
  const code = typed(codeRaw);
  if (!code) return null;
  const [row]: any[] = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT "AC_CODE","AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 ORDER BY row_id LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      code,
    ),
  );
  return row ? { code: text(row.AC_CODE), name: text(row.AC_NAME) } : null;
}

/** BtnPrint_Click hands the AcMast report to UT_REPORT (:8657-8668); the web prints the listed accounts. */
export async function partyPrintRows(
  prisma: any,
  scope: PartyScope,
): Promise<Array<Record<string, string>>> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rules = await partyRulesTx(tx, scope);
    const listed = await partyListTx(tx, scope, rules.allBranch);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE","LC_CODE","AC_NAME","AC_GR","AC_ADD1","AC_CITY","AC_MOBILE","AC_GSTNO" FROM "AC_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY row_id`,
      scope.tenantId,
      scope.coCode,
    );
    const byKey = new Map(rows.map((r) => [`${text(r.LC_CODE)}|${text(r.AC_CODE)}`, r]));
    return listed.map((l) => {
      const r = byKey.get(`${l.lc}|${l.code}`) ?? {};
      return {
        code: l.code,
        name: l.name,
        group: text(r.AC_GR),
        address: text(r.AC_ADD1),
        city: text(r.AC_CITY),
        mobile: l.mobile,
        gstNo: text(r.AC_GSTNO),
      };
    });
  });
}

/** The photo (AC_IMAGE), keyed as the desktop's image file name (company, location, code; :6560-6575). */
export async function getPartyPhoto(
  prisma: any,
  scope: PartyScope,
  codeRaw: string,
): Promise<{ dataUrl: string | null }> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const [row]: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_IMAGE" img FROM "AC_IMAGE" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
        ORDER BY ("LC_CODE"=$4) DESC, row_id LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      typed(codeRaw),
      scope.lcCode,
    );
    const img = row?.img;
    if (!img) return { dataUrl: null };
    const buf = Buffer.isBuffer(img) ? img : Buffer.from(img as any);
    return { dataUrl: buf.length ? `data:image/jpeg;base64,${buf.toString('base64')}` : null };
  });
}

/** The largest photo the screen takes (a 178×146 picture box; JPEG files of a few hundred KB). */
export const PARTY_PHOTO_MAX_BYTES = 2_000_000;

/** BtnImgS_Click / BtnImgC_Click (:8181-8392): the picked JPEG replaces the code's photo at once. */
export async function setPartyPhoto(
  prisma: any,
  scope: PartyScope,
  codeRaw: string,
  dataUrl: string,
): Promise<{ saved: true }> {
  const code = typed(codeRaw);
  if (!code) throw new PartyMasterValidationError('account code is required for a photo');
  const m = /^data:image\/(jpeg|jpg|png);base64,([A-Za-z0-9+/=]+)$/.exec(String(dataUrl ?? ''));
  if (!m) throw new PartyMasterValidationError('the photo must be a JPEG or PNG image');
  const buf = Buffer.from(m[2], 'base64');
  if (!buf.length || buf.length > PARTY_PHOTO_MAX_BYTES)
    throw new PartyMasterValidationError('the photo must be at most 2 MB');
  await withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await tx.$executeRawUnsafe(
      `DELETE FROM "AC_IMAGE" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      code,
    );
    await insertRowTx(tx, 'AC_IMAGE', scope.tenantId, {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      AC_CODE: code,
      AC_IMAGE: buf,
    });
  });
  return { saved: true };
}

/** BtnImgD_Click (:8394-8466): after "Are You Sure To Delete This Image now?" the code's photo goes. */
export async function deletePartyPhoto(
  prisma: any,
  scope: PartyScope,
  codeRaw: string,
): Promise<{ deleted: number }> {
  const n = await withTxBudget(prisma, scope.tenantId, 'voucher', (tx: any) =>
    tx.$executeRawUnsafe(
      `DELETE FROM "AC_IMAGE" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      typed(codeRaw),
    ),
  );
  return { deleted: Number(n) };
}

/** The search box and the name type-ahead filter the list on the screen; exported for the unit tests. */
export function filterPartyList(
  rows: readonly PartyListRow[],
  term: string,
  mode: 'search' | 'name',
): PartyListRow[] {
  const t = typed(term);
  if (!t) return [...rows];
  return mode === 'search'
    ? rows.filter((r) => r.name.toUpperCase().includes(t) || r.mobile.startsWith(t))
    : rows.filter((r) => r.name.toUpperCase().startsWith(t));
}

