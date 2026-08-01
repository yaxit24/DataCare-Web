/**
 * Replay a real desktop CASH RECEIPT through the web — family 3.
 *
 * REFERENCE VOUCHER — Live24 book 001 voucher 00001
 *   CASH_DATA  1 line: AC_CODE 000926, REC_AMT 60000.00, KASAR_AMT 771.00, INOUT_TYPE 'I', ENTRY_TYPE 'C'
 *   AC_DATA    4 legs, keyed 33 characters with a 12-wide `<line><leg>` tail:
 *                [01002024-202500100001         101]  ac 000926  Cr 60000.00  ld 00001
 *                [01002024-202500100001         102]  ac 00001   Dr 60000.00  ld 000926
 *                [01002024-202500100001         103]  ac 000926  Cr   771.00  ld 00057
 *                [01002024-202500100001         104]  ac 00057   Dr   771.00  ld 000926
 *   ROJ_MEL_DATA 3 rows · TEMP_BOOK_DATA 1 row
 *
 * ONE CASH_DATA LINE, FOUR LEGS. The party is credited twice — once against cash, once against kasar — because
 * the desktop pairs each MOVEMENT rather than netting the party's balance. The web wrote three.
 *
 * Note the kasar account: `00057 KASAR JAVK A/C` on a receipt. A payment uses `00042 KASAR AVAK A/C.` instead,
 * so the account mirrors the money's direction and not the voucher's.
 */
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { postReceipt } from '../dist/modules/finance/finance.js';

const TENANT = process.env.PARITY_REPLAY_TENANT || 'parity-cash';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const BOOK = '001';
const PARTY = '000926';
const CASH = '00001';
const KASAR = '00057';

const url = process.env.MIGRATE_DATABASE_URL;
const runtimeUrl = process.env.DATABASE_URL;
if (!url || !runtimeUrl) {
  console.error('REPLAY_SKIP need MIGRATE_DATABASE_URL and DATABASE_URL');
  process.exit(1);
}
const owner = new PrismaClient({ datasources: { db: { url } } });
const runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
const exec = (sql, ...p) => withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

async function wipe() {
  const tables = await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  );
  for (const t of tables) {
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

async function seed() {
  // Rounding flags from the real CO_SET / CO_SET_NEW. PARITY_STRICT=1 rejects an absent one rather than letting
  // it default, because an absent setting is indistinguishable from a product defect in a comparison.
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","SL_AMT_TYPE","TAX_ROF","ALL_ROF_REMOVE","RATE_PAR","ITM_RATE_ROF","CASH_LIMIT")
     VALUES ($1,$2,'N',2,'N',2,'N','N',2,200000)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","TOT_AMT_ROF","PR_RATE_ROF") VALUES ($1,$2,0,2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,'Parity Cash Co')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,$2,$3,'Main')`,
    TENANT,
    CO,
    LC,
  );
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
     VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
    TENANT,
    CO,
    YEAR,
  );
  for (const [code, name] of [
    [PARTY, 'CASH PARTY'], // real name withheld: live customer data
    [CASH, 'CASH ON HAND'],
    [KASAR, 'KASAR JAVK A/C'],
  ]) {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,$4,$5,'L')`,
      TENANT,
      CO,
      LC,
      code,
      name,
    );
  }
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
        "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,'Cash Received','CREC','CASH REC','I','Y','CASH_DATA')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
  // Slot 1 is the cash account: every leg-02 row on book 001 names 00001.
  await exec(
    `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
     VALUES ($1,$2,$3,$4,1,$5,'Cash Received','CASH REC','I')`,
    TENANT,
    CO,
    LC,
    BOOK,
    CASH,
  );
}

async function main() {
  await wipe();
  await seed();

  const result = await postReceipt(runtime, {
    scope: { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK },
    partyAc: PARTY,
    partyName: 'CASH PARTY',
    amount: 60000,
    kasar: 771,
    kasarAc: KASAR,
    mode: 'cash',
    vchDate: '2024-04-03',
    mainUser: 'parity-replay',
  });

  console.log(`REPLAY_OK tenant=${TENANT} book=${BOOK} vchNo=${result.vchNo ?? '?'}`);
  console.log(
    '  desktop for comparison: 4 legs — 000926 Cr 60000 / 00001 Dr 60000 / 000926 Cr 771 / 00057 Dr 771',
  );
  await owner.$disconnect();
  await runtime.$disconnect();
}

main().catch(async (e) => {
  console.error('REPLAY_FAIL', e?.message ?? e);
  await owner.$disconnect().catch(() => {});
  await runtime.$disconnect().catch(() => {});
  process.exit(1);
});
