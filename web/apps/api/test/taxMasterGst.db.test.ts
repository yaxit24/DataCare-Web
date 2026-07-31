/**
 * The tax resolver against a REAL GST tax master.
 *
 * Written after the first attempt to replay a real desktop voucher failed with
 * `tax code has conflicting configuration: 10` — meaning the web could not post a sale against any GST
 * configuration this customer actually has.
 *
 * The cause: selecting by tax code matched every `TAX_MAST` row for the code and then rejected the code
 * because their identities differed. But a GST code's extra rows are not rival configurations, they are its
 * component breakdown — SGST, CGST and IGST. Comparing the parent to a component compares a total to one of
 * its parts.
 *
 * Measured on the real customer database, every GST code collides this way:
 *
 *   code 10 at 3%   parent SR_NO 0 (TAX_AC 00085) vs IGST SR_NO 3 (TAX_AC 00087)
 *   code 11 at 5%,  code 12 at 12%,  code 13 at 18%,  code 14 at 28%   — same shape
 *   and in each, SGST SR_NO 1 vs CGST SR_NO 2 collide at the half rate with different accounts
 *
 * The desktop resolves this by pinning the parent: its tax queries carry `AND D.SR_NO = 0`.
 *
 * The fixtures below reproduce code 10 exactly as `Live24` holds it, so this test fails if the parent-row
 * preference is ever removed.
 */
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import {
  resolveTaxPolicyTx,
  TransactionTaxValidationError,
} from '../src/modules/shared/taxPolicy.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'tax-gst-parent';
const CO = '01';

const prisma = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});

const scope = { tenantId: TENANT, coCode: CO, lcCode: '00', coYear: '2024-2025', coBook: '027' };

async function wipe() {
  for (const t of ['TAX_MAST', 'AC_MAST']) {
    await prisma.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, TENANT);
  }
}

describe.runIf(RUN)('tax resolution against a real GST tax master', () => {
  beforeAll(async () => {
    await wipe();
    await withTenant(prisma, TENANT, async (tx) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
         VALUES ($1,$2,'00','000888','GST PARTY','L')`,
        TENANT,
        CO,
      );
      // Code 10 exactly as the real database holds it: a parent at SR_NO 0 and three components.
      for (const [sr, group, name, prc, ac] of [
        [0, 'N', 'GST 3%', 3.0, '00085'],
        [1, 'SGST', 'SGST 1.5%', 1.5, '00085'],
        [2, 'CGST', 'CGST 1.5%', 1.5, '00086'],
        [3, 'IGST', 'IGST 3%', 3.0, '00087'],
      ] as const) {
        await tx.$executeRawUnsafe(
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
    });
  });

  afterAll(async () => {
    await wipe();
    await prisma.$disconnect();
  });

  it('resolves a GST code whose components share the parent percentage', async () => {
    const policy = await withTenant(prisma, TENANT, (tx) =>
      resolveTaxPolicyTx(tx, scope, { acCode: '000888', taxPct: 3, taxCode: '10' }),
    );
    // The PARENT row, not the IGST row that shares its 3%.
    expect(policy.taxAc).toBe('00085');
    expect(Number(policy.taxPct)).toBe(3);
  });

  it('reads the customer as intra-state, so the halves go to CGST and SGST', async () => {
    const policy = await withTenant(prisma, TENANT, (tx) =>
      resolveTaxPolicyTx(tx, scope, { acCode: '000888', taxPct: 3, taxCode: '10' }),
    );
    // Party 000888 carries AC_GST_TYPE 'L' on the real database, and the real voucher stored
    // CGST 22.725 / SGST 22.725 / IGST 0.
    expect(policy.interState).toBe(false);
  });

  it('still resolves when an explicit SR_NO names a component', async () => {
    const igst = await withTenant(prisma, TENANT, (tx) =>
      resolveTaxPolicyTx(tx, scope, { acCode: '000888', taxPct: 3, taxCode: '10', srNo: 3 }),
    );
    expect(igst.taxAc).toBe('00087');
  });

  it('still refuses a genuinely ambiguous percentage lookup across two codes', async () => {
    // Two different CODES sharing a rate with different accounts is real ambiguity, and the caller has given
    // no code to disambiguate. The parent-row preference must not have silenced this.
    await withTenant(prisma, TENANT, (tx) =>
      tx.$executeRawUnsafe(
        `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC")
         VALUES ($1,$2,'20',0,'N','OTHER 3%',3.0,'00099')`,
        TENANT,
        CO,
      ),
    );
    await expect(
      withTenant(prisma, TENANT, (tx) =>
        resolveTaxPolicyTx(tx, scope, { acCode: '000888', taxPct: 3 }),
      ),
    ).rejects.toThrow(TransactionTaxValidationError);
    await withTenant(prisma, TENANT, (tx) =>
      tx.$executeRawUnsafe(`DELETE FROM "TAX_MAST" WHERE tenant_id=$1 AND "TAX_CODE"='20'`, TENANT),
    );
  });
});
