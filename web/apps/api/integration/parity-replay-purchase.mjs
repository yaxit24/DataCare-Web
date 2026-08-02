/**
 * Replay a real desktop PURCHASE through the web — family 4.
 *
 * REFERENCE VOUCHER — Live24 book 035 voucher 00001, 2024-04-01
 *   PR_DATA  party 000903, NET_AMT 6780.00, TOT_AMT 6780.00, CASH_AMT 6780.00, TAX_CODE '00'
 *   PR_DETL  1 line: item 999, ITM_NWT 1.000, ITM_TOUCH 0, ITM_FINE 1.000, ITM_RATE 6780.00, ITM_AMT 6780.00
 *   AC_DATA  4 legs, all 23-character keys:
 *              [01002024-20250350000101]  ac 000903  ld 00008   Cr 6780.00   party
 *              [01002024-20250350000103]  ac 00008   ld 000903  Dr 6780.00   purchase
 *              [01002024-20250350000116]  ac 000903  ld 00001   Dr 6780.00   settlement, party
 *              [01002024-20250350000117]  ac 00001   ld 000903  Cr 6780.00   settlement, cash
 *   MAIN_STOCK 1 · PR_DETL 1 · ROJ_MEL_DATA 1 · TEMP_BOOK_DATA 1
 *
 * A CASH PURCHASE IS TWO SELF-BALANCED PAIRS — the bill (01/03) and the payment (16/17) — the same shape the
 * cash books use, and the same shape the sale family needed. The settlement codes differ from every other
 * family's, which is why `payoutLegs` takes them from the caller rather than defaulting.
 *
 * WHAT THIS VOUCHER DOES NOT COVER, deliberately recorded: voucher 035/00004 is UNFIXED - three lines with
 * rate 0 and amount 0, producing three type-21 fine legs and NO money legs at all. Its fine legs are covered by
 * a unit test; a second replay case would need the unfixed path wired here.
 */
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { createPurchase } from '../dist/modules/purchase/purchase.js';

const TENANT = process.env.PARITY_REPLAY_TENANT || 'parity-purchase';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const BOOK = '035';
const PARTY = '000903';
const PURC = '00008';
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
  // Rounding flags from the real CO_SET / CO_SET_NEW. PARITY_STRICT=1 refuses an absent one.
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","SL_AMT_TYPE","PR_AMT_TYPE","TAX_ROF","ALL_ROF_REMOVE","RATE_PAR","ITM_RATE_ROF")
     VALUES ($1,$2,'N',2,'N','F',2,'N','N',2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","TOT_AMT_ROF","PR_RATE_ROF") VALUES ($1,$2,0,2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,'Parity Purchase Co')`,
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
    [PARTY, 'GOLD SUPPLIER'], // real name withheld: live customer data
    [PURC, 'PURCHASE GOLD A/C'],
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
    `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","PURC_AC") VALUES ($1,$2,'01','GOLD',$3)`,
    TENANT,
    CO,
    PURC,
  );
  // Item 999 is pure gold: ITM_TOUCH 0 on the real line, with the fine equal to the net weight.
  await exec(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
     VALUES ($1,$2,'999','FINE GOLD 999','G','01')`,
    TENANT,
    CO,
  );
  // TAX_MAST code '00' "TAX FREE", TAX_PRC 0.00, TAX_AC 00014 - copied from the real Live24 master, where it
  // is a legitimately CONFIGURED zero rate rather than an absent one. 57 of 190 real sales and 7 of 74 real
  // purchases use it, so tax-free is a mainstream case and not an edge.
  await exec(
    `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","ADD_TAX_PRC","TAX_AC")
     VALUES ($1,$2,'00',0,'N','TAX FREE',0,0,'00014')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
     VALUES ($1,$2,$3,'00014','VAT TAX','L')`,
    TENANT,
    CO,
    LC,
  );
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
        "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,'Gold Purchase','PURC','PURCHASE','I','Y','PR_DATA')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
  // Slot 1 purchase, slot 2 cash, slot 3 kasar/round — the numbering resolveBookAccountTx reads.
  for (const [sr, ac] of [
    [1, PURC],
    [2, CASH],
    [3, KASAR],
  ]) {
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,$4,$5,$6,'Gold Purchase','PURCHASE','I')`,
      TENANT,
      CO,
      LC,
      BOOK,
      sr,
      ac,
    );
  }
}

async function main() {
  await wipe();
  await seed();

  const result = await createPurchase(
    runtime,
    {
      scope: { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK },
      acCode: PARTY,
      acName: 'GOLD SUPPLIER',
      vchDate: '2024-04-01',
      // All 918 real Live24 accounts are AC_GST_TYPE 'L' (local); none is inter-state.
      interState: false,
      // PR_DATA.TAX_CODE is '00' on the real voucher - TAX_MAST 'TAX FREE', TAX_PRC 0.00.
      taxCode: '00',
      taxRatePct: 0,
      // Paid in full, in cash — CASH_AMT equals TOT_AMT on the real voucher.
      cashAmt: 6780,
      cashAc: CASH,
      mainUser: 'parity-replay',
    },
    [
      {
        itCode: '999',
        metal: 'G',
        pcs: 1,
        grossWt: 1,
        netWt: 1,
        touch: 0,
        rate: 6780,
        metalAmount: 6780,
      },
    ],
  );

  console.log(`REPLAY_OK tenant=${TENANT} book=${BOOK} vchNo=${result.vchNo ?? '?'}`);
  console.log(
    '  desktop for comparison: 4 legs — 01 party Cr / 03 purchase Dr / 16 party Dr / 17 cash Cr, all 6780.00',
  );
  await owner.$disconnect();
  await runtime.$disconnect();
}

main().catch(async (e) => {
  console.error('REPLAY_FAIL', e?.message ?? e);
  console.error(
    String(e?.stack).split(String.fromCharCode(10)).slice(0, 6).join(String.fromCharCode(10)),
  );
  await owner.$disconnect().catch(() => {});
  await runtime.$disconnect().catch(() => {});
  process.exit(1);
});
