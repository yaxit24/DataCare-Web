import type { PrismaClient } from '@datacare/db';

/** Seed A and variants (desktop RP_CASH_BANK.cs). Data only; tests derive every figure from it. MISSING: the desktop AC_GR
 * codes of cash and bank accounts (cases.md gives names only), so AC_GR is null. */
export type Db = Pick<PrismaClient, '$executeRawUnsafe' | '$queryRawUnsafe'>;
export interface Leg {
  key: string; account: string; book: string; vch: string; date: string; counterParty: string;
  cr?: number; dr?: number; company?: string; location?: string; year?: string;
}
export type VariantName = 'date-boundary' | 'cr-side' | 'paise';
export type SentinelKind = 'company' | 'location' | 'year';
export const COMPANY = '01', LOCATION = '01', CO_YEAR = '2026-27';
const BOOKS: Array<[string, string, string]> = [['001', 'CASH REC', 'CREC'], ['002', 'CASH PAY', 'CPAY'], ['CON', 'CONTRA', 'CON'], ['SL', 'SALES', 'SL']];
const ACCOUNTS: Array<[string, string]> = [['00001', 'CASH ON HAND'], ['00010', 'TEST BANK'], ['00101', 'PARTY ALPHA'], ['00102', 'PARTY BETA']];

/** Seed A. Account 00001 unless stated. Period 01/11/2026 to 30/11/2026. Voucher 7 is ONE line carrying both amounts:
 * the packet asks for two lines sharing one LEDR_KEY, but the unique index AC_DATA_tenant_ledr_key_key (migration
 * 20260801160000_ledger_key_uniqueness) refuses a shared key. Net 500 - 500 = 0, the same grid result. */
export const SEED_A_LINES: Leg[] = [
  { key: 'L1', account: '00001', book: '001', vch: '1', date: '2026-10-10', dr: 10000, counterParty: '00101' },
  { key: 'L2', account: '00001', book: '002', vch: '2', date: '2026-10-20', cr: 2500, counterParty: '00102' },
  { key: 'R1', account: '00001', book: '001', vch: '3', date: '2026-11-05', dr: 4000, counterParty: '00101' },
  { key: 'R2', account: '00001', book: '002', vch: '4', date: '2026-11-12', cr: 1500, counterParty: '00102' },
  { key: 'R3', account: '00001', book: 'CON', vch: '5', date: '2026-11-20', cr: 1000, counterParty: '00010' },
  { key: 'R4', account: '00001', book: '001', vch: '7', date: '2026-11-22', cr: 500, dr: 500, counterParty: '00101' },
  { key: 'R5', account: '00001', book: 'SL', vch: '6', date: '2026-11-25', dr: 2000, counterParty: '00102' },
  { key: 'L8', account: '00001', book: '001', vch: '8', date: '2026-12-02', dr: 999, counterParty: '00101' },
  { key: 'L5b', account: '00010', book: 'CON', vch: '5', date: '2026-11-20', dr: 1000, counterParty: '00001' },
];

const VARIANTS: Record<VariantName, { accounts: Array<[string, string]>; legs: Leg[] }> = {
  'date-boundary': { accounts: [], legs: [{ key: 'L9', account: '00001', book: '001', vch: '9', date: '2026-11-01', dr: 100, counterParty: '00101' }] },
  'cr-side': { accounts: [], legs: [{ key: 'L10', account: '00001', book: '002', vch: '10', date: '2026-10-01', cr: 20000, counterParty: '00102' }] },
  paise: {
    accounts: [['00030', 'PAISE TEST']],
    legs: [{ key: 'P1', account: '00030', book: '001', vch: '31', date: '2026-11-03', dr: 0.1, counterParty: '00101' }, { key: 'P2', account: '00030', book: '001', vch: '32', date: '2026-11-03', dr: 0.2, counterParty: '00101' }],
  },
};

/** Sentinels reuse the visible voucher 3, so a leak shows as a second row. */
const SENTINELS: Record<SentinelKind, Leg> = {
  company: { key: 'S-CO', account: '00001', book: '001', vch: '3', date: '2026-11-05', dr: 888, counterParty: '00101', company: '02' },
  location: { key: 'S-LC', account: '00001', book: '001', vch: '3', date: '2026-11-05', dr: 777, counterParty: '00101', location: '02' },
  year: { key: 'S-YR', account: '00001', book: '001', vch: '3', date: '2026-11-06', dr: 333, counterParty: '00101', year: '2025-26' },
};

async function seedAccounts(db: Db, tid: string, list: Array<[string, string]>) {
  for (const [code, name] of list) await db.$executeRawUnsafe(`INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES($1,'01','01',$2,$3)`, tid, code, name);
}

async function seedBooks(db: Db, tid: string, company = COMPANY, location = LOCATION) {
  for (const [code, name, short] of BOOKS) await db.$executeRawUnsafe(`INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","CUR_USE") VALUES($1,$2,$3,$4,$5,$6,$5,'Y')`, tid, company, location, code, name, short);
}

export async function seedLegs(db: Db, tid: string, legs: Leg[]): Promise<void> {
  for (const l of legs) await db.$executeRawUnsafe(
    `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","LEDR_KEY","AC_CODE","LD_CODE","CR_AMT","DR_AMT","DATA_TYPE") VALUES($1,$2,$3,$4,$5,$6,$7::date,$8,$9,$10,$11,$12,'A')`,
    tid, l.company ?? COMPANY, l.location ?? LOCATION, l.year ?? CO_YEAR, l.book, l.vch, l.date, `CB-${l.key}`, l.account, l.counterParty, l.cr ?? 0, l.dr ?? 0,
  );
}

async function removeLegs(db: Db, tid: string, legs: Leg[]) {
  for (const l of legs) await db.$executeRawUnsafe(`DELETE FROM "AC_DATA" WHERE tenant_id=$1 AND "LEDR_KEY"=$2`, tid, `CB-${l.key}`);
}

/** Seed A for one empty tenant. Voucher 6 is a sales voucher: its party name comes from this SL_DATA row. */
export async function seedA(db: Db, tid: string): Promise<void> {
  await seedAccounts(db, tid, ACCOUNTS);
  await seedBooks(db, tid);
  await seedLegs(db, tid, SEED_A_LINES);
  await db.$executeRawUnsafe(`INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_NAME") VALUES($1,'01','01',$2,'SL','6','PARTY ALPHA')`, tid, CO_YEAR);
}

export async function seedVariant(db: Db, tid: string, name: VariantName): Promise<void> {
  await seedAccounts(db, tid, VARIANTS[name].accounts);
  await seedLegs(db, tid, VARIANTS[name].legs);
}

export async function unseedVariant(db: Db, tid: string, name: VariantName): Promise<void> {
  await removeLegs(db, tid, VARIANTS[name].legs);
  for (const [code] of VARIANTS[name].accounts) await db.$executeRawUnsafe(`DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE"=$2`, tid, code);
}

/** One line of another company, location or year. A company or location sentinel gets its own BOOK_DATA. */
export async function seedSentinels(db: Db, tid: string, kind: SentinelKind): Promise<void> {
  const s = SENTINELS[kind];
  if (s.company || s.location) await seedBooks(db, tid, s.company ?? COMPANY, s.location ?? LOCATION);
  await seedLegs(db, tid, [s]);
}

export async function unseedSentinels(db: Db, tid: string, kind: SentinelKind): Promise<void> {
  const s = SENTINELS[kind];
  await removeLegs(db, tid, [s]);
  if (s.company || s.location) await db.$executeRawUnsafe(`DELETE FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3`, tid, s.company ?? COMPANY, s.location ?? LOCATION);
}

/** The other tenant: one line on account 00001 (DR 4444, voucher 3) that must never reach tenant one. */
export async function seedSecondTenant(db: Db, tid: string): Promise<void> {
  await seedAccounts(db, tid, [['00001', 'OTHER CASH']]);
  await seedBooks(db, tid);
  await seedLegs(db, tid, [{ key: 'X1', account: '00001', book: '001', vch: '3', date: '2026-11-05', dr: 4444, counterParty: '00101' }]);
}

/** Removes every row of one tenant from every table that has a tenant_id. */
export async function wipe(db: Db, tid: string): Promise<void> {
  const rows: Array<{ table_name: string }> = await db.$queryRawUnsafe(`SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`);
  for (const row of rows) await db.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tid);
}
