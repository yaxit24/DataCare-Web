import { withTxBudget } from '../shared/txBudget.js';
import { insertRowTx } from '../posting/posting.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { requiredVersion, versionOf } from '../vouchers/version.js';

/**
 * Address master (desktop MS_ADD_MAST, menu Master → Address; MDI_FORM.cs:7610-7619 opens the form directly). One
 * ADD_MAST row per address code of a location: name, group, contact person, three address lines, city, pin, area,
 * country, state, district, phones, mobiles, email and three dates.
 *
 * - The list is the location's addresses ordered by code (MS_ADD_MAST_Load and CLEAR_DATA, MS_ADD_MAST.cs:3119-3396);
 *   a search keeps the names that start with the text (Text1_TextChanged :3641-3665). Typing a name refills the list
 *   with up to 99 of the company's addresses whose name starts with it (tAcName_KeyUp :4171-4294).
 * - CLEAR_DATA (:3454-3547) offers the next code of the location and puts the cursor in the name; the combos list the
 *   company's distinct groups, countries, districts, cities and areas, and the states of ADD_MAST with STATE_MAST's
 *   (AddCboItem :3939-4046). DISPLAY_DATA (:3549-3583) reads a code of the company and keeps its MAIN_USER.
 * - BtnSave_Click (:4411-4515) needs the edit right only for an opened address, refuses a blank code or name ("Please
 *   Select Customer name and try...."), deletes the code's row of the location and inserts every box, a date box that is
 *   not a date as NULL, MAIN_USER and DATA_TRFR 'N'. Leaving the name refuses a name another code has (:4389-4409).
 * - Enter on the mobile of a new entry refuses a mobile another address of the company has ("This Mobile No = <name>
 *   With this Account .....", tmobile_KeyDown :3867-3887).
 * - BtnDelete_Click (:4517-4544) needs the delete right, refuses a blank code ("Please Select AcCode For Delete."),
 *   asks, and deletes the address with its opening rows of the year (OP_DATA and AC_DATA of book 000).
 *
 * Deliberate differences, recorded on the gap:
 * - The next code is the location's prefix and the next four-digit number. The desktop adds 1 to Val of the whole last
 *   code, prefix included, and formats it after the prefix again (:3505-3540), so the second address of location 01 gets
 *   0110002 and every later one the same code, and its save replaces the previous address.
 * - tAcCode_Validating filters CO_CODE by the typed code (:3623) and so never refuses; the web refuses nothing there
 *   either, and Ctrl+E unlocks the code box as the desktop does (:3721-3738).
 * - Save and Delete run in one transaction; an opened address carries the version read with it (N51 tokens); a box
 *   longer than its MaxLength is refused.
 */
export class AddressMasterValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'AddressMasterValidationError';
  }
}

export class AddressVersionConflictError extends Error {
  readonly code = 'address-version-conflict';
  readonly statusCode = 409;
  constructor() {
    super(
      'This address was changed by someone else after you opened it. Open it again before saving or deleting.',
    );
    this.name = 'AddressVersionConflictError';
  }
}

export interface AddressScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear?: string;
}

/** The boxes of the screen, their ADD_MAST columns and the boxes' MaxLength (form spec / resx). */
export const ADDRESS_FIELDS = [
  ['name', 'AC_NAME', 50],
  ['group', 'AC_GR', 15],
  ['mobile', 'AC_MOBILE', 15],
  ['phone', 'AC_PHONE', 15],
  ['person', 'AC_PERSON', 40],
  ['address1', 'AC_ADD1', 50],
  ['address2', 'AC_ADD2', 50],
  ['address3', 'AC_ADD3', 50],
  ['city', 'AC_CITY', 20],
  ['pin', 'AC_PIN', 8],
  ['area', 'AC_AREA', 25],
  ['country', 'AC_COUNTRY', 20],
  ['state', 'AC_STATE', 20],
  ['district', 'AC_DISTRICT', 20],
  ['email', 'AC_EMAIL', 50],
  ['mobile2', 'AC_MOBILE2', 15],
  ['phone2', 'AC_PHONE2', 15],
] as const;
export type AddressFieldKey = (typeof ADDRESS_FIELDS)[number][0];
export type AddressInput = Partial<Record<AddressFieldKey, string>> & {
  birthDate?: string;
  anniversary?: string;
  lBirthDate?: string;
};

export interface AddressSaveInput {
  scope: AddressScope;
  user: string;
  entryMode: 'A' | 'E';
  code: string;
  values: AddressInput;
  expectedVersion?: unknown;
}

const text = (value: unknown): string => String(value ?? '').trim();
/** MS_ADD_MAST_KeyPress upper-cases every key and drops the apostrophe (MS_ADD_MAST.cs:3604-3617). */
const typed = (value: unknown): string => text(value).toUpperCase().replace(/'/g, '');

/** Desktop text of tAcName_Validating (MS_ADD_MAST.cs:4398). */
export const addressNameTakenMessage = (code: string): string =>
  `This Ac Name already Exist in  '${code}'  Ac Code... Please Change Account Name...`;
/** Desktop text of tmobile_KeyDown (MS_ADD_MAST.cs:3882). */
export const addressMobileTakenMessage = (name: string): string =>
  `This Mobile No = ${name}  With this Account .....`;

/**
 * A masked date box (dd/MM/yyyy). Information.IsDate decides whether it is written (:4459-4461); a box that is not a
 * date is NULL. Returns the box text for BR_DATE/AN_DATE (text columns) and the ISO date for L_BR_DATE.
 */
export function maskedDate(value: unknown): { text: string; iso: string } | null {
  const raw = text(value);
  const m = /^(\d{1,2})\/(\d{1,2})\/(\d{4})$/.exec(raw);
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

const lockTx = (tx: any, scope: AddressScope) =>
  tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `address-master:${scope.tenantId}:${scope.coCode}`,
  );

async function addressVersionTx(tx: any, scope: AddressScope, code: string): Promise<string> {
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT row_id::text, to_jsonb(r) - 'row_id' AS r FROM "ADD_MAST" r
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  return versionOf({ ADD_MAST: rows });
}

export async function listAddresses(
  prisma: any,
  scope: AddressScope,
): Promise<{
  rows: Array<{
    code: string;
    name: string;
    group: string;
    address: string;
    phone: string;
    mobile: string;
  }>;
}> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE","AC_NAME","AC_GR","AC_ADD1","AC_PHONE","AC_MOBILE" FROM "ADD_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 ORDER BY "AC_CODE","row_id"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
    );
    // The list shows Code / Name; the F1 help (tAcName_KeyDown :3740-3775) shows name, code, group, address, phone, mobile.
    return {
      rows: rows.map((r) => ({
        code: text(r.AC_CODE),
        name: text(r.AC_NAME),
        group: text(r.AC_GR),
        address: text(r.AC_ADD1),
        phone: text(r.AC_PHONE),
        mobile: text(r.AC_MOBILE),
      })),
    };
  });
}

/** tAcName_KeyUp: up to 99 of the company's addresses whose name starts with the typed text. */
export async function addressNameMatches(
  prisma: any,
  scope: AddressScope,
  term: string,
): Promise<Array<{ code: string; name: string }>> {
  const typedTerm = typed(term);
  const rows: any[] = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT "AC_CODE","AC_NAME" FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_NAME" ILIKE $3
        ORDER BY row_id LIMIT 99`,
      scope.tenantId,
      scope.coCode,
      `${typedTerm.replace(/[\\%_]/g, (c) => `\\${c}`)}%`,
    ),
  );
  return rows.map((r) => ({ code: text(r.AC_CODE), name: text(r.AC_NAME) }));
}

/** The next code of the location: its prefix and the next four-digit number (see the deliberate difference above). */
export async function nextAddressCodeTx(tx: any, scope: AddressScope): Promise<string> {
  const prefix = scope.lcCode;
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE" FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE" LIKE $4`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    `${prefix}%`,
  );
  const numbers = rows
    .map((r) => text(r.AC_CODE).slice(prefix.length))
    .filter((rest) => /^\d{4}$/.test(rest))
    .map(Number);
  const next = (numbers.length ? Math.max(...numbers) : 0) + 1;
  return `${prefix}${String(next).padStart(4, '0')}`;
}

/** AddCboItem: the combos' entries. */
export async function addressCombos(
  prisma: any,
  scope: AddressScope,
): Promise<Record<'groups' | 'countries' | 'states' | 'districts' | 'cities' | 'areas', string[]>> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const distinct = async (column: string) =>
      (
        (await tx.$queryRawUnsafe(
          `SELECT DISTINCT coalesce("${column}",'') v FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1`,
          scope.tenantId,
          scope.coCode,
        )) as Array<{ v: string }>
      ).map((r) => text(r.v));
    const states: Array<{ v: string }> = await tx.$queryRawUnsafe(
      `SELECT v FROM (
         SELECT "AC_STATE" v FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND coalesce("AC_STATE",'')<>'' GROUP BY "AC_STATE"
         UNION ALL SELECT "STATE_NAME" v FROM "STATE_MAST" WHERE tenant_id=$1 GROUP BY "STATE_NAME") s
        ORDER BY v`,
      scope.tenantId,
      scope.coCode,
    );
    return {
      groups: await distinct('AC_GR'),
      countries: await distinct('AC_COUNTRY'),
      states: states.map((r) => text(r.v)),
      districts: await distinct('AC_DISTRICT'),
      cities: await distinct('AC_CITY'),
      areas: await distinct('AC_AREA'),
    };
  });
}

export async function nextAddressCode(prisma: any, scope: AddressScope): Promise<string> {
  return withTxBudget(prisma, scope.tenantId, 'read', (tx: any) => nextAddressCodeTx(tx, scope));
}

export async function getAddress(
  prisma: any,
  scope: AddressScope,
  codeRaw: string,
): Promise<(Record<string, string> & { code: string; version: string }) | null> {
  const code = typed(codeRaw);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    // DISPLAY_DATA reads the code of the company (:3551), whatever its location.
    const [row] = await tx.$queryRawUnsafe(
      `SELECT *, to_char("L_BR_DATE",'DD/MM/YYYY') l_br FROM "ADD_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 ORDER BY row_id LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      code,
    );
    if (!row) return null;
    const view: Record<string, string> = {};
    for (const [key, column] of ADDRESS_FIELDS) view[key] = text(row[column]);
    return {
      ...view,
      code,
      birthDate: text(row.BR_DATE),
      anniversary: text(row.AN_DATE),
      lBirthDate: text(row.l_br),
      version: await addressVersionTx(tx, scope, code),
    };
  });
}

/** tmobile_KeyDown: the name of an address of the company with this mobile, if any. */
export async function addressWithMobile(
  prisma: any,
  scope: AddressScope,
  mobile: string,
): Promise<{ name: string } | null> {
  const wanted = typed(mobile);
  if (!wanted) return null;
  const [row]: Array<{ AC_NAME: string | null }> = await withTxBudget(
    prisma,
    scope.tenantId,
    'read',
    (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "AC_NAME" FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_MOBILE"=$3 ORDER BY row_id LIMIT 1`,
        scope.tenantId,
        scope.coCode,
        wanted,
      ),
  );
  return row ? { name: text(row.AC_NAME) } : null;
}

export async function saveAddress(prisma: any, input: AddressSaveInput): Promise<{ code: string }> {
  const code = typed(input.code);
  const values: Record<string, string> = {};
  for (const [key, column, max] of ADDRESS_FIELDS) {
    const value = typed(input.values[key]);
    if (value.length > max)
      throw new AddressMasterValidationError(`${column} must be at most ${max} characters`);
    values[column] = value;
  }
  if (!code || !values.AC_NAME)
    throw new AddressMasterValidationError(DESKTOP_MESSAGES.CUSTOMER_NAME_REQUIRED);
  if (code.length > 8)
    throw new AddressMasterValidationError('address code must be at most 8 characters');
  const birth = maskedDate(input.values.birthDate);
  const anniversary = maskedDate(input.values.anniversary);
  const lBirth = maskedDate(input.values.lBirthDate);
  const expected = input.entryMode === 'E' ? requiredVersion(input.expectedVersion) : null;
  await withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    const { tenantId, coCode, lcCode } = input.scope;
    await lockTx(tx, input.scope);
    if (expected && (await addressVersionTx(tx, input.scope, code)) !== expected)
      throw new AddressVersionConflictError();
    const rows: Array<{
      AC_CODE: string | null;
      AC_NAME: string | null;
      MAIN_USER: string | null;
    }> = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE","AC_NAME","MAIN_USER" FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 ORDER BY row_id`,
      tenantId,
      coCode,
      lcCode,
    );
    const same = rows.find((r) => text(r.AC_CODE) === code);
    if (input.entryMode === 'E' && !same) {
      const [elsewhere] = await tx.$queryRawUnsafe(
        `SELECT 1 FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 LIMIT 1`,
        tenantId,
        coCode,
        code,
      );
      // An opened address that another operator deleted meanwhile is not brought back.
      if (!elsewhere) throw new AddressVersionConflictError();
    }
    // tAcName_Validating: a name another code of the location has is refused.
    const namesake = rows.find(
      (r) => text(r.AC_NAME).toUpperCase() === values.AC_NAME && text(r.AC_CODE) !== code,
    );
    if (namesake)
      throw new AddressMasterValidationError(addressNameTakenMessage(text(namesake.AC_CODE)));
    // MainUser: the stored user of an opened address (DISPLAY_DATA :3577), the signed-in user for a new entry (:3478).
    let mainUser = input.user;
    if (input.entryMode === 'E') {
      const [stored] = await tx.$queryRawUnsafe(
        `SELECT "MAIN_USER" FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 ORDER BY row_id LIMIT 1`,
        tenantId,
        coCode,
        code,
      );
      mainUser = text(stored?.MAIN_USER);
    }
    await tx.$executeRawUnsafe(
      `DELETE FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4`,
      tenantId,
      coCode,
      lcCode,
      code,
    );
    await insertRowTx(tx, 'ADD_MAST', tenantId, {
      CO_CODE: coCode,
      LC_CODE: lcCode,
      AC_CODE: code,
      ...values,
      BR_DATE: birth?.text ?? null,
      AN_DATE: anniversary?.text ?? null,
      L_BR_DATE: lBirth ? new Date(`${lBirth.iso}T00:00:00Z`) : null,
      MAIN_USER: mainUser,
      DATA_TRFR: 'N',
    });
  });
  return { code };
}

export async function deleteAddress(
  prisma: any,
  scope: AddressScope,
  codeRaw: string,
  expectedVersion?: unknown,
): Promise<{ code: string; deleted: number }> {
  const code = typed(codeRaw);
  if (!code) throw new AddressMasterValidationError(DESKTOP_MESSAGES.ACCOUNT_SELECT_FOR_DELETE);
  const expected =
    expectedVersion == null || expectedVersion === '' ? null : requiredVersion(expectedVersion);
  const deleted = await withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await lockTx(tx, scope);
    if (expected && (await addressVersionTx(tx, scope, code)) !== expected)
      throw new AddressVersionConflictError();
    const n = await tx.$executeRawUnsafe(
      `DELETE FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"=$4`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      code,
    );
    // The address's opening rows of the year go with it (:4533-4535).
    for (const table of ['OP_DATA', 'AC_DATA'])
      await tx.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"='000' AND "AC_CODE"=$5`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear ?? '',
        code,
      );
    return n;
  });
  return { code, deleted: Number(deleted) };
}

/** BtnPrint_Click hands the location's ADD_MAST rows to the PartyMast report (MS_ADD_MAST.cs:3682-3683). */
export async function addressPrintRows(
  prisma: any,
  scope: AddressScope,
): Promise<Array<Record<string, string>>> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "ADD_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 ORDER BY "AC_CODE","row_id"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
    );
    return rows.map((row) => ({
      code: text(row.AC_CODE),
      name: text(row.AC_NAME),
      address: [row.AC_ADD1, row.AC_ADD2, row.AC_ADD3].map(text).filter(Boolean).join(', '),
      city: text(row.AC_CITY),
      pin: text(row.AC_PIN),
      mobile: text(row.AC_MOBILE),
      phone: text(row.AC_PHONE),
    }));
  });
}
