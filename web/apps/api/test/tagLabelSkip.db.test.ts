import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { renderTagLabels, stageTagPrintRowsTx } from '../src/modules/stock/tagPrint.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * Blank-label skip parity — `nLableSkip`.
 *
 * Eleven `TR_*` forms plus `UT_TAG_PRINT` expose this on the desktop and the web had none of it, so an
 * operator could not reuse a part-used sticker sheet. The desktop prepends N placeholder rows with
 * `IT_CODE='00'` and `VCH_SRNO=0` BEFORE copying the real labels (`TR_TAG_OPBL.cs:11485-11492`).
 *
 * The count is `(int)Math.Round(Conversion.Val(nLableSkip.Text))`. .NET `Math.Round` is banker's rounding,
 * so 2.5 skips 2 and 3.5 skips 4 — pinned below, because using JavaScript's half-up `Math.round` would
 * silently waste a sticker.
 */
describe('tag label skip rendering', () => {
  it('prepends exactly the requested number of blank labels', () => {
    const html = renderTagLabels([], 3);
    expect((html.match(/class="lbl blank"/g) ?? []).length).toBe(3);
  });

  it('renders nothing extra when skip is zero', () => {
    const html = renderTagLabels([], 0);
    expect(html).not.toContain('lbl blank');
    expect(html).toContain('no tags');
  });

  it('uses .NET banker rounding, not JavaScript half-up', () => {
    // Math.round(2.5) === 3 in JavaScript but Math.Round(2.5) === 2 in .NET.
    expect((renderTagLabels([], 2.5).match(/class="lbl blank"/g) ?? []).length).toBe(2);
    expect((renderTagLabels([], 3.5).match(/class="lbl blank"/g) ?? []).length).toBe(4);
  });

  it('treats a negative or junk value as no skip', () => {
    expect(renderTagLabels([], -5)).not.toContain('lbl blank');
    expect(renderTagLabels([], Number.NaN)).not.toContain('lbl blank');
  });
});

d('tag print staging with label skip', () => {
  const prisma = new PrismaClient();
  // tenant_id is varchar(24), so DB tests use short kebab tenants.
  const tenantId = 'tagskip-db';
  const scope = { coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'SL' };
  const VCH = '00001';

  const clean = () =>
    withTenant(prisma, tenantId, async (tx: any) => {
      for (const t of ['TAG_PRINT_DATA', 'BAR_DETL']) {
        await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, tenantId);
      }
    });

  beforeAll(async () => {
    await clean();
    await withTenant(prisma, tenantId, async (tx: any) => {
      for (const sr of [1, 2]) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
             "IT_CODE","TAG_NO","VCH_SRNO") VALUES ($1,$2,$3,$4,$5,$6,$7,'GOLD',$8,$7)`,
          tenantId,
          scope.coCode,
          scope.lcCode,
          scope.coYear,
          scope.coBook,
          VCH,
          sr,
          `TAG00${sr}`,
        );
      }
    });
  });
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
  });

  const staged = () =>
    withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "SR_NO","IT_CODE","VCH_SRNO" FROM "TAG_PRINT_DATA" WHERE tenant_id=$1
          ORDER BY "IT_CODE"='00' DESC, "SR_NO"`,
        tenantId,
      ),
    );

  it('stages placeholder rows before the real labels', async () => {
    const n = await withTenant(prisma, tenantId, (tx: any) =>
      stageTagPrintRowsTx(tx, tenantId, scope, VCH, undefined, 2),
    );
    expect(n).toBe(2); // the copy returns the number of REAL label rows
    const rows: any[] = await staged();
    const blanks = rows.filter((r) => String(r.IT_CODE) === '00');
    const real = rows.filter((r) => String(r.IT_CODE) !== '00');
    expect(blanks.length).toBe(2);
    expect(real.length).toBe(2);
    // Desktop writes SR_NO 1..n and VCH_SRNO 0 on placeholders (TR_TAG_OPBL.cs:11489).
    expect(blanks.map((r) => Number(r.SR_NO)).sort()).toEqual([1, 2]);
    for (const b of blanks) expect(Number(b.VCH_SRNO)).toBe(0);
  });

  it('stages no placeholder when skip is omitted', async () => {
    await withTenant(prisma, tenantId, (tx: any) => stageTagPrintRowsTx(tx, tenantId, scope, VCH));
    const rows: any[] = await staged();
    expect(rows.filter((r) => String(r.IT_CODE) === '00').length).toBe(0);
    expect(rows.length).toBe(2);
  });
});
