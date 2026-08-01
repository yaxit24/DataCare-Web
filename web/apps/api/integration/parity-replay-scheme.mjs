/**
 * Replay a real desktop SCHEME INSTALMENT through the web — family 2.
 *
 * REFERENCE VOUCHER — Live24 book 074 voucher 00001
 *   AC_DATA  2 legs, keyed 33 characters with a LINE NUMBER right-aligned in 10:
 *              [01002024-20250740000101         1]  ac 000858 Cr 2000.00  ld 00001
 *              [01002024-20250740000102         1]  ac 00001  Dr 2000.00  ld 000858
 *            VCH_TYPE 'MBENT', BOOK_NAME 'MEMB ENTRY'
 *   AD_DATA  1 row: SR_NO 1, MEMB_CODE 0029, SCHM_CODE 03, MEMB_AMT 2000.00, TOT_AMT 0.00, ENT_TYPE 'E'
 *   AD_OS    1 row · ROJ_MEL_DATA 1 row · TEMP_BOOK_DATA 1 row
 *
 * WHY THIS FAMILY IS SECOND
 * It is the largest by volume: 1311 vouchers and 2622 AC_DATA legs on book 074, against 556 rows for the
 * whole sale family. Legs come in PAIRS PER MEMBER LINE - 570 vouchers have 2 legs, 172 have 4, and one has
 * 22 - so the line number in the key is the member line, not a detail row.
 *
 * TWO LEG TYPES ONLY, measured across all 2620 legs of length 33:
 *   01  the scheme liability, CREDIT   (1311 rows, ONE account: 000858)
 *   02  the receipt account, DEBIT     (1311 rows, five accounts - cash and banks)
 *
 * Book 075 (MEMB OPENING) has NO AC_DATA rows at all, which the web already reproduces: an opening writes
 * the AD_OS carry-forward and no money ledger.
 */
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { schemeInstallment } from '../dist/modules/membership/scheme.js';

const TENANT = process.env.PARITY_REPLAY_TENANT || 'parity-scheme';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const BOOK = '074';

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
  // Settings read from the real CO_SET / CO_SET_NEW, including ITM_RATE_ROF and TOT_AMT_ROF - PARITY_STRICT=1
  // rejects an absent rounding flag rather than letting it default, because an absent setting is
  // indistinguishable from a product defect in a comparison.
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","SL_AMT_TYPE","TAX_ROF","ALL_ROF_REMOVE","RATE_PAR","ITM_RATE_ROF")
     VALUES ($1,$2,'N',2,'N',2,'N','N',2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","TOT_AMT_ROF","PR_RATE_ROF") VALUES ($1,$2,0,2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,'Parity Scheme Co')`,
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

  // 000858 is the scheme liability the real voucher credits; its name on the live database is the scheme's
  // own period label, which is why the liability account IS the scheme. 00001 is cash.
  for (const [code, name] of [
    ['000858', 'SCHEME LIABILITY'],
    ['00001', 'CASH ON HAND'],
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

  // The scheme and the member. SCHM_CODE '03' and MEMB_CODE '0029' are the real voucher's values.
  await exec(
    `INSERT INTO "AD_MAST"(tenant_id,"CO_CODE","SCHM_CODE","SCHM_NAME","SCHM_AC") VALUES ($1,$2,'03','SCHEME 03','000858')`,
    TENANT,
    CO,
  );
  await exec(
    // AD_MEMB requires LC_CODE (NOT NULL, no default) while AD_MAST does not - the member is per location,
    // the scheme is per company.
    `INSERT INTO "AD_MEMB"(tenant_id,"CO_CODE","LC_CODE","SCHM_CODE","MEMB_CODE","MEMB_NAME")
     VALUES ($1,$2,$3,'03','0029','SCHEME MEMBER')`,
    TENANT,
    CO,
    LC,
  );

  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
        "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,'Member Entry','MBENT','MEMB ENTRY','I','Y','AD_DATA')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
  // Slot 1 is the receipt account: the real leg-02 rows name cash 00001 and four banks.
  await exec(
    `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
     VALUES ($1,$2,$3,$4,1,'00001','Member Entry','MEMB ENTRY','I')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
}

async function main() {
  await wipe();
  await seed();

  const result = await schemeInstallment(runtime, {
    scope: { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK },
    schmCode: '03',
    membCode: '0029',
    amount: 2000,
    vchDate: '2024-04-01',
    mainUser: 'parity-replay',
  });

  console.log(`REPLAY_OK tenant=${TENANT} book=${BOOK} vchNo=${result.vchNo}`);
  console.log('  desktop for comparison: 2 AC_DATA legs, 000858 Cr 2000.00 / 00001 Dr 2000.00');
  await owner.$disconnect();
  await runtime.$disconnect();
}

main().catch(async (e) => {
  console.error('REPLAY_FAIL', e?.message ?? e);
  await owner.$disconnect().catch(() => {});
  await runtime.$disconnect().catch(() => {});
  process.exit(1);
});
