/**
 * Replay a real desktop voucher through the web, so the two can be diffed field by field.
 *
 * This is the missing half of `g5:parity`. The harness has existed for weeks — extractor, bundle format,
 * differ, 24 unit tests — but no real voucher had ever been replayed, so every parity claim rested on
 * derivation rather than comparison.
 *
 * WHAT IT DOES
 *   1. Seeds a dedicated tenant with the masters and settings the real voucher depended on, read from
 *      Live24 rather than invented: CO_SET flags, the tax code and its component rows, the party, the
 *      items and their group, and the book with its BOOK_DETL account slots.
 *   2. Posts the sale through `createSale` — the same code path the API uses.
 *   3. Leaves the rows in place for `parity-extract-pg.mjs` to bundle under a matching caseId.
 *
 * WHY THE INPUTS ARE DERIVED, AND THE LIMIT THAT PUTS ON THE RESULT
 * Operator inputs are reconstructed from the persisted `SL_DETL`/`SL_DATA`, because the keystrokes are gone.
 * So a field the desktop COMPUTED and stored, which this script feeds back as an input, will match by
 * construction and proves nothing. The fields that carry real information are the ones neither side was
 * told: the ledger legs, the tax split, the Rojmel projection, stock movement and the bill outstanding.
 * The comparison report should be read with that distinction in mind.
 *
 * REFERENCE VOUCHER — Live24 book 027 voucher 00001, 2024-04-06
 *   header  party 000888, tax code 10 (3%), NET_AMT 1515.00, TAX_AMT 45.45, TOT_AMT 1560.00, BILL_OS 1560.00
 *   line 1  MA925 silver, 1 pc, 10.360 g, touch 0, rate 0, LBR_TYPE N, LBR_AMT 1087.00, NET_AMT 1087.00
 *   line 2  ORS   silver, 1 pc,  4.600 g, touch 0, rate 77, LBR_RATE 16.09, LBR_AMT 74.00, NET_AMT 428.00
 *
 * Line 1 is labour-only: no metal value at all, the whole line being making charges entered directly.
 * Note also that 1515.00 + 45.45 = 1560.45 while the desktop stored TOT_AMT 1560.00 with ROF_AMT 0.00 — it
 * rounded the total without recording the round-off. That is a real behaviour and a likely source of the
 * first genuine difference.
 */
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
// The BUILT output, not src: this is a plain .mjs script with no TypeScript transform, so it needs
// `pnpm --filter @datacare/api build` to have run. Same reason the other integration scripts use dist.
import { createSale } from '../dist/modules/sales/sales.js';

const TENANT = process.env.PARITY_REPLAY_TENANT || 'parity-replay';
const CO = '01';
const LC = '00'; // the real database uses '00', not '01' - see the note in seed()
const YEAR = '2024-2025';
const BOOK = '027';

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
  // Settings read from the real CO_SET, not chosen: LBR_TYPE 'N' is what makes a directly-entered labour
  // amount persist as LBR_TYPE 'N' the way the desktop stored it.
  await exec(
    // ITM_RATE_ROF is 2 on the real database and was missing here. PARITY_STRICT=1 found it on its first run -
    // the harness had been quietly taking a default for the item-rate precision all along, which is the same
    // class of omission that made TOT_AMT_ROF look like a product defect for two commits.
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","SL_AMT_TYPE","TAX_ROF","ALL_ROF_REMOVE","RATE_PAR","ITM_RATE_ROF")
     VALUES ($1,$2,'N','2','N','2','N','N','2')`,
    TENANT,
    CO,
  );
  // CO_SET_NEW carries the rounding precisions, and TOT_AMT_ROF lives HERE rather than in CO_SET. The real
  // database holds 0 for all four companies - zero decimals, i.e. whole rupees - which is precisely why every
  // money column in 245 SL_DETL rows and 190 SL_DATA headers is an integer.
  //
  // Omitting this row was a harness defect that looked exactly like a web rounding defect: with TOT_AMT_ROF
  // absent the loader keeps its documented 2dp default, so the replay produced 1515.21 against the desktop's
  // 1515.00 and I began writing it up as a missing whole-rupee mode. The mode is implemented.
  await exec(
    `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","TOT_AMT_ROF","PR_RATE_ROF") VALUES ($1,$2,0,2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,'Parity Replay Co')`,
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

  // LC_CODE is '00' on the real database, on BOOK_DATA, BOOK_DETL and the voucher alike. Worth stating
  // because querying BOOK_DETL with LC_CODE '01' returns nothing, which reads exactly like "this book has no
  // account slots configured" - it briefly did read that way here.
  //
  // Accounts. AC_CODE is varchar(8), so the real codes fit as-is.
  for (const [code, name] of [
    ['000888', 'REPLAY PARTY'], // real name withheld: this is live customer data
    ['00004', 'SALES SILVER A/C'],
    ['00085', 'GST TAX'],
    ['00086', 'CGST A/C'],
    ['00087', 'IGST A/C'],
    ['00001', 'CASH ON HAND'],
    ['00057', 'KASAR A/C'],
    ['00020', 'SLOT 4 A/C'],
    ['00076', 'DISCOUNT A/C'],
    ['00041', 'SLOT 6 A/C'],
    ['00050', 'SLOT 7 A/C'],
    ['00079', 'SLOT 8 A/C'],
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

  // Tax code 10 exactly as Live24 holds it: a parent row plus SGST/CGST/IGST components.
  for (const [sr, group, name, prc, ac] of [
    [0, 'N', 'GST 3%', 3.0, '00085'],
    [1, 'SGST', 'SGST 1.5%', 1.5, '00085'],
    [2, 'CGST', 'CGST 1.5%', 1.5, '00086'],
    [3, 'IGST', 'IGST 3%', 3.0, '00087'],
  ]) {
    await exec(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC")
       VALUES ($1,$2,'10',$3,$4,$5,$6,$7)`,
      TENANT,
      CO,
      sr,
      group,
      name,
      prc,
      ac,
    );
  }

  // Group carries the income account; items are silver, matching IT_TYPE 'S' on both real lines.
  await exec(
    `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC")
     VALUES ($1,$2,'01','SILVER','00004')`,
    TENANT,
    CO,
  );
  for (const [code, name] of [
    ['MA925', 'SILVER PAYAL'],
    ['ORS', 'SILVER ORNAMENT'],
  ]) {
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,$3,$4,'S','01')`,
      TENANT,
      CO,
      code,
      name,
    );
  }

  // The TAG INSTANCE that line 1 sells, seeded with the real tag's own figures.
  //
  // Line 1 of the reference voucher is a TAGGED sale: TAG_NO 'MAS00013', VCH_SRNO 100211101051. Its karigar
  // figures are not derived from the line - they are copied from the tag. Measured across all 102 tagged sale
  // lines, SL_DETL.KR_TOUCH equals BAR_DETL.KR_TOUCH and SL_DETL.KR_FINE equals BAR_DETL.KR_FINE, 102 of 102
  // for both. So the tag has to carry them or the comparison is testing the fixture rather than the code.
  await exec(
    `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","IT_CODE",
        "ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_PCS","KR_NAME","KR_NET_WT","KR_TOUCH","KR_FINE","APR_ISU","APP_TRFR")
     VALUES ($1,$2,$3,'MAS00013',100211101051,'MA925',10.360,10.360,92.500,1,'VIKAS',10.360,92.500,9.583,'N','N')`,
    TENANT,
    CO,
    LC,
  );

  // The tag's INWARD stock movement. A tag is only issuable when MAIN_STOCK shows a net positive balance for
  // it (stock.ts availableBarTags), which is the web modelling "this tag was received before it was sold" - so
  // without this row the replay fails with `tag not available for issue`, correctly.
  await exec(
    `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
        "TAG_NO","VCH_SRNO","IT_CODE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT","TR_TYPE")
     VALUES ($1,$2,$3,$4,'900','00001',1,'MAS00013',100211101051,'MA925','+',1,1,10.360,10.360,'P')`,
    TENANT,
    CO,
    LC,
    YEAR,
  );

  // The book, and all eight BOOK_DETL slots exactly as book 027 holds them. Slot 1 is 00004 SALES SILVER
  // A/C, which is the account the real voucher's ledger names as the party leg's contra - so slot 1 is the
  // right resolution and this replay can confirm it rather than assume it.
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
        "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,'Silver Tax Invoice Old','TSSL','SALES','O','Y','SL_DATA')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
  for (const [sr, ac] of [
    [1, '00004'],
    [2, '00001'],
    [3, '00057'],
    [4, '00020'],
    [5, '00076'],
    [6, '00041'],
    [7, '00050'],
    [8, '00079'],
  ]) {
    await exec(
      // BOOK_INOUT is on the DETL row as well as the DATA row, and resolveBookAccountTx filters on it.
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,$4,$5,$6,'Silver Tax Invoice Old','SALES','O')`,
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

  const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK };
  const result = await createSale(
    runtime,
    {
      scope,
      acCode: '000888',
      acName: 'REPLAY PARTY',
      vchDate: '2024-04-06',
      taxCode: '10',
      taxRatePct: 3,
      // Party 000888 carries AC_GST_TYPE 'L' on the real database, and the voucher stored CGST 22.725 /
      // SGST 22.725 / IGST 0 - an intra-state sale. The server cross-checks this against the persisted
      // customer type rather than trusting it, so it has to be stated.
      interState: false,
      mainUser: 'parity-replay',
    },
    [
      // Line 1 is labour-only: the desktop stored rate 0 and ITM_AMT 0 with the whole 1087.00 as labour.
      {
        itCode: 'MA925',
        metal: 'S',
        // The tag this line sells. Supplying it is what makes the comparison test the WRITE path for the tag
        // and karigar columns rather than an absent input.
        tagNo: 'MAS00013',
        pcs: 1,
        grossWt: 10.36,
        netWt: 10.36,
        touch: 0,
        rate: 0,
        // labourType is REQUIRED alongside labourFixed. `const labour = line.labourType ? ... : 0` in
        // sales.ts means a line carrying only labourFixed contributes ZERO labour and says nothing about it -
        // this replay lost the whole 1087.00 that way on its first successful post, and the only reason it was
        // noticed is that a real total was sitting next to it to disagree with.
        labourType: 'fixed',
        labourFixed: 1087,
      },
      // Line 2 carries both: 4.600 x 77 = 354.20 metal, plus 4.600 x 16.09 = 74.01 labour.
      {
        itCode: 'ORS',
        metal: 'S',
        pcs: 1,
        grossWt: 4.6,
        netWt: 4.6,
        touch: 0,
        rate: 77,
        labourRate: 16.09,
        labourType: 'per_gram',
      },
    ],
  );

  console.log(`REPLAY_OK tenant=${TENANT} book=${BOOK} vchNo=${result.vchNo}`);
  console.log(`  totals: ${JSON.stringify(result.totals)}`);
  console.log('  desktop for comparison: NET_AMT 1515.00 TAX_AMT 45.45 TOT_AMT 1560.00');
  await owner.$disconnect();
  await runtime.$disconnect();
}

main().catch(async (e) => {
  console.error('REPLAY_FAIL', e?.message ?? e);
  await owner.$disconnect().catch(() => {});
  await runtime.$disconnect().catch(() => {});
  process.exit(1);
});
