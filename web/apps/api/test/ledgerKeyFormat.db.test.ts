/**
 * The `AC_DATA.LEDR_KEY` layout.
 *
 * `LEDR_KEY` is part of the primary key, and the web was building it one character too long: `VCH_NO` was
 * padded to six where the desktop uses five, so every web ledger row carried a key the desktop would never
 * produce.
 *
 * Measured on the real customer database, a sale's ledger keys are 23 characters:
 *
 *     01002024-20250270000101
 *     ^^^^                      CO_CODE(2) + LC_CODE(2)
 *         ^^^^^^^^^             CO_YEAR(9)
 *                  ^^^          CO_BOOK(3)
 *                     ^^^^^     VCH_NO(5)
 *                          ^^   leg type(2)
 *
 * which is the same layout already verified byte-for-byte for `ROJ_MEL_DATA`. Padding to six produced
 * `01002024-202502700000101` at 24 characters, with an extra zero inside the voucher number.
 *
 * Found by replaying a real voucher; the difference was invisible until the differ's row-pairing defect was
 * fixed, because until then `AC_DATA` rows never paired and so were never compared.
 *
 * NOT asserted here: the leg TYPE codes. The desktop writes 01/03/04 for a plain credit sale - party, sales
 * account, tax - where the web writes a bare 01/02/03 sequence. That is a real difference and is recorded in
 * docs/FIRST-REAL-COMPARISON.md, but the desktop's codes are semantic per leg role and vary by voucher family
 * (book 027 alone uses 01/03/04, 09/10, 19/20 and 25/26), so they need measuring per family before any
 * mapping is written. Guessing one here would pin a wrong answer.
 */
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { postVoucherTx } from '../src/modules/posting/posting.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'ledger-key-fmt';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const BOOK = '027';

const prisma = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});

async function wipe() {
  for (const t of ['AC_DATA', 'YEAR_MAST', 'CO_SET']) {
    await prisma.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, TENANT);
  }
}

/** The period lock reads CO_SET.LOCK_DATE and refuses to post without a row; a precondition, not the subject. */
async function seedYear() {
  await withTenant(prisma, TENANT, async (tx) => {
    await tx.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,'')`,
      TENANT,
      CO,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
       VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
      TENANT,
      CO,
      YEAR,
    );
  });
}

describe.runIf(RUN)('AC_DATA ledger key layout', () => {
  beforeAll(async () => {
    await wipe();
    await seedYear();
  });
  afterAll(async () => {
    await wipe();
    await prisma.$disconnect();
  });

  it('builds a 23-character key with VCH_NO padded to five', async () => {
    const key = { CO_CODE: CO, LC_CODE: LC, CO_YEAR: YEAR, CO_BOOK: BOOK, VCH_NO: '00001' };
    await withTenant(prisma, TENANT, (tx) =>
      postVoucherTx(tx, TENANT, {
        ledger: {
          table: 'AC_DATA',
          lines: [
            // legType states the leg's ROLE. The desktop's codes for a sale are 01 party and 03 revenue; an
            // untyped leg lands in the reserved 50+ band instead, which is correct behaviour but not what this
            // test is about.
            {
              ...key,
              legType: 1,
              AC_CODE: '000888',
              LD_CODE: '00004',
              DR_AMT: 1560,
              CR_AMT: 0,
              VCH_DATE: new Date('2024-04-06T00:00:00Z'),
            },
            {
              ...key,
              legType: 3,
              AC_CODE: '00004',
              LD_CODE: '000888',
              DR_AMT: 0,
              CR_AMT: 1560,
              VCH_DATE: new Date('2024-04-06T00:00:00Z'),
            },
          ],
        },
        bookName: 'SALES',
        // No vchDate here: PostInput has no such property, so an earlier version of this test passed one that
        // was silently ignored. The period lock is satisfied by VCH_DATE on the ledger lines themselves, which
        // is where the desktop carries it too. Surfaced by typechecking the test project.
        writes: [],
      }),
    );

    const rows = (await prisma.$queryRawUnsafe(
      `SELECT "LEDR_KEY" k FROM "AC_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
      TENANT,
    )) as Array<{ k: string }>;

    expect(rows).toHaveLength(2);
    for (const r of rows) {
      // 23, not 24. This is the assertion the six-pad broke.
      expect(r.k).toHaveLength(23);
      expect(r.k.slice(0, 4)).toBe('0100'); // CO_CODE + LC_CODE
      expect(r.k.slice(4, 13)).toBe(YEAR); // CO_YEAR
      expect(r.k.slice(13, 16)).toBe(BOOK); // CO_BOOK
      expect(r.k.slice(16, 21)).toBe('00001'); // VCH_NO, five characters
    }
    // Byte-for-byte against the real desktop row for book 027 voucher 00001.
    expect(rows[0]!.k).toBe('01002024-20250270000101');
    // And the second leg carries the desktop's revenue code 03, not a positional 02.
    expect(rows[1]!.k).toBe('01002024-20250270000103');
  });
});
