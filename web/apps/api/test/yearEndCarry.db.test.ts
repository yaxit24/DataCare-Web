import { describe, it, expect, beforeAll, afterAll, beforeEach } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  yearEndPreview,
  yearEndClose,
  YearEndValidationError,
} from '../src/modules/ops/yearEnd.js';

/**
 * Year-end carry-forward.
 *
 * WHY THIS FILE EXISTS
 * --------------------
 * `ops/yearEnd.ts` is 280 lines, reachable through `POST /year-end/preview` and `POST /year-end/close`,
 * policed in `routePolicy.ts` as `Utilities/Year-End Close` — and it had **no test of any kind**. It
 * determines every account's opening balance for a new fiscal year. If it is wrong, every account opens
 * wrong, and it is the sort of defect nobody notices until the annual close, by which time the prior year
 * is shut.
 *
 * WHAT THE DESKTOP DOES, AND HOW THE TWO MODELS DIFFER
 * ---------------------------------------------------
 * The desktop keeps `OP_LDR`: on this customer's database that is **7011 rows across 117 accounts**,
 * carrying the prior year's transaction DETAIL — `VCH_TYPE MBENT/TGSL/CREC/TSSL/CPAY`, real books, and
 * 2566 rows for a single account. `RP_LEDR.cs` reads it ten times, summing `DR_AMT`/`CR_AMT` and the
 * gold/silver fine per account to produce a ledger's opening figure.
 *
 * The web keeps only the **net**: one `AC_DATA` leg per account, `CO_BOOK '000'`, `VCH_TYPE 'ACOP'`.
 *
 * For the opening FIGURE the two must agree, because summing the detail gives the net — and that is what
 * these tests pin. What the web does **not** retain is the prior-year detail itself, so it cannot drill
 * from an opening balance into last year's transactions the way the desktop can. That is recorded as a
 * deliberate model difference in `MODULE-VERIFICATION-CATALOGUE.md` §2.9, not as a defect.
 *
 * `OP_LDR` is also NOT balanced on its own — 86,510,920.77 debit against 87,615,844.46 credit on the real
 * data, and only 117 of 918 accounts appear. So it is a partial prior-year copy, which is a further reason
 * the web's net-per-account model is not simply a lossy version of it.
 */

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'year-end-carry';
const CO = '01';
const LC = '01';
const FROM = '2024-2025';
const TO = '2025-2026';

databaseDescribe('year-end carry-forward', () => {
  let owner: PrismaClient; // postgres — setup and inspection only; BYPASSES RLS
  let runtime: PrismaClient; // app_user — what the module must be given
  const scope = { tenantId: TENANT, coCode: CO, lcCode: LC } as any;

  // The module MUST be called with the runtime client. Handed the owner it bypasses row-level security, so
  // `withTenant` sets a context the owner ignores and `computeClosingsTx` sums EVERY tenant's AC_DATA for
  // the company and year. The first run of this file did exactly that and reported a 637,842.82 opening
  // for an account seeded with 1,000 - the RLS trap in its less familiar direction: not zero rows, but all
  // of them.

  const wipe = async (): Promise<void> => {
    for (const t of ['AC_DATA', 'CO_SET', 'AC_MAST']) {
      await owner.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, TENANT);
    }
  };

  /** One AC_DATA leg. Books other than '000' are ordinary trading; '000' is the opening book itself. */
  const leg = async (
    acCode: string,
    dr: number,
    cr: number,
    opts: { book?: string; year?: string; itType?: string; fine?: number; vchNo?: string } = {},
  ): Promise<void> => {
    await withTenant(owner, TENANT, (tx: any) =>
      tx.$executeRawUnsafe(
        `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
            "AC_CODE","DR_AMT","CR_AMT","IT_TYPE","FINE_WT","VCH_TYPE","LEDR_KEY")
         VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,'JV',$12)`,
        TENANT,
        CO,
        LC,
        opts.year ?? FROM,
        opts.book ?? 'SAL',
        opts.vchNo ?? '00001',
        acCode,
        dr,
        cr,
        opts.itType ?? 'A',
        opts.fine ?? 0,
        `${acCode}-${opts.book ?? 'SAL'}-${opts.vchNo ?? '00001'}-${dr}-${cr}-${Math.random()}`,
      ),
    );
  };

  const openingLegs = async (): Promise<Array<Record<string, unknown>>> =>
    withTenant(owner, TENANT, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "AC_CODE","DR_AMT"::float dr,"CR_AMT"::float cr,"SIGN","IT_TYPE",
                "FINE_WT"::float fine,"CO_BOOK","VCH_TYPE","LD_CODE"
           FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_YEAR"=$2 AND "VCH_TYPE"='ACOP'
          ORDER BY "AC_CODE"`,
        TENANT,
        TO,
      ),
    ) as Promise<Array<Record<string, unknown>>>;

  beforeAll(async () => {
    const url = process.env.MIGRATE_DATABASE_URL;
    if (!url) throw new Error('RUN_DB_INTEGRITY_TESTS requires MIGRATE_DATABASE_URL');
    const runtimeUrl = process.env.DATABASE_URL;
    if (!runtimeUrl) throw new Error('RUN_DB_INTEGRITY_TESTS requires DATABASE_URL');
    owner = new PrismaClient({ datasources: { db: { url } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  beforeEach(async () => {
    await wipe();
  });

  it('carries each account forward as ΣDR − ΣCR, one leg per account', async () => {
    // Two accounts, several legs each, so the sum is doing real work rather than copying one row.
    await leg('CUST', 5000, 0);
    await leg('CUST', 3000, 0, { vchNo: '00002' });
    await leg('CUST', 0, 1200, { vchNo: '00003' });
    await leg('SALES', 0, 6800);

    const result = await yearEndClose(runtime, { scope, fromYear: FROM, toYear: TO } as any);
    expect(result.carried).toBe(2);

    const rows = await openingLegs();
    expect(rows).toHaveLength(2);
    const cust = rows.find((r) => r.AC_CODE === 'CUST')!;
    const sales = rows.find((r) => r.AC_CODE === 'SALES')!;
    // 5000 + 3000 − 1200 = 6800 debit.
    expect(Number(cust.dr)).toBeCloseTo(6800, 2);
    expect(Number(cust.cr)).toBe(0);
    expect(cust.SIGN).toBe('D');
    // A credit balance opens on the credit side, stated positively.
    expect(Number(sales.cr)).toBeCloseTo(6800, 2);
    expect(Number(sales.dr)).toBe(0);
    expect(sales.SIGN).toBe('C');
  });

  it('writes into the opening book 000 as VCH_TYPE ACOP, which is what makes it findable', async () => {
    await leg('CUST', 1000, 0);
    await yearEndClose(runtime, { scope, fromYear: FROM, toYear: TO } as any);
    const [row] = await openingLegs();
    expect(row!.CO_BOOK).toBe('000');
    expect(row!.VCH_TYPE).toBe('ACOP');
    // LD_CODE carries the sequence, which is how the desktop distinguishes opening legs within one voucher.
    expect(String(row!.LD_CODE)).not.toBe('');
  });

  it('excludes an account whose balance nets to zero', async () => {
    // A fully settled account has nothing to open with. Carrying a zero leg would clutter every new year's
    // ledger with accounts that have no position.
    await leg('SETTLED', 2500, 0);
    await leg('SETTLED', 0, 2500, { vchNo: '00002' });
    await leg('CUST', 100, 0);

    const result = await yearEndClose(runtime, { scope, fromYear: FROM, toYear: TO } as any);
    const rows = await openingLegs();
    expect(rows.map((r) => r.AC_CODE)).toEqual(['CUST']);
    expect(result.carried).toBe(1);
  });

  it('is idempotent — running twice leaves one opening per account, not two', async () => {
    // The close is the kind of operation an operator re-runs after fixing a stray voucher. Without the
    // delete-first step the second run would double every opening balance in the new year.
    await leg('CUST', 4000, 0);
    await yearEndClose(runtime, { scope, fromYear: FROM, toYear: TO } as any);
    const first = await openingLegs();

    const second = await yearEndClose(runtime, { scope, fromYear: FROM, toYear: TO } as any);
    const after = await openingLegs();
    expect(after).toHaveLength(first.length);
    expect(Number(after[0]!.dr)).toBeCloseTo(Number(first[0]!.dr), 2);
    expect(second.deleted).toBeGreaterThan(0); // it really did clear the prior run
  });

  it('re-running after a correction produces the corrected figure, not the stale one', async () => {
    // The stronger form of idempotency: not just "same count" but "reflects the current data".
    await leg('CUST', 4000, 0);
    await yearEndClose(runtime, { scope, fromYear: FROM, toYear: TO } as any);
    await leg('CUST', 0, 1500, { vchNo: '00009' }); // a correction posted afterwards
    await yearEndClose(runtime, { scope, fromYear: FROM, toYear: TO } as any);
    const rows = await openingLegs();
    expect(rows).toHaveLength(1);
    expect(Number(rows[0]!.dr)).toBeCloseTo(2500, 2);
  });

  it('excludes the closing-stock valuation book 999 from the carry', async () => {
    // The excluded book is '999', not the opening book '000'. yearEnd.ts cites the desktop guard it mirrors:
    // AcBalInsert's opening query carries `AND A.CO_BOOK <> '999'`. Book 999 holds the injected closing-stock
    // balancing figure, which lives OUTSIDE the real ledger, so folding it into next year's opening would
    // double-count it. My first draft of this test guessed '000' and the module was right.
    await leg('CUST', 1000, 0);
    await leg('STOCKVAL', 900000, 0, { book: '999' });
    await yearEndClose(runtime, { scope, fromYear: FROM, toYear: TO } as any);
    const rows = await openingLegs();
    expect(rows.map((r) => r.AC_CODE)).toEqual(['CUST']);
  });

  it('carries metal fine and its metal letter; money accounts stay 0 / A', async () => {
    // AC_CODE is varchar(8) - 'GOLDPARTY' would be nine characters and fail 22001.
    await leg('GOLDAC', 0, 0, { itType: 'G', fine: 12.345 });
    await leg('CUST', 500, 0);
    await yearEndClose(runtime, { scope, fromYear: FROM, toYear: TO } as any);
    const rows = await openingLegs();
    const gold = rows.find((r) => r.AC_CODE === 'GOLDAC')!;
    const money = rows.find((r) => r.AC_CODE === 'CUST')!;
    expect(gold.IT_TYPE).toBe('G');
    expect(Number(gold.fine)).toBeCloseTo(12.345, 3);
    expect(money.IT_TYPE).toBe('A');
    expect(Number(money.fine)).toBe(0);
  });

  it('only reads the year being closed', async () => {
    await leg('CUST', 1000, 0, { year: FROM });
    await leg('CUST', 7777, 0, { year: '2023-2024' }); // an older year must not leak in
    await yearEndClose(runtime, { scope, fromYear: FROM, toYear: TO } as any);
    const rows = await openingLegs();
    expect(Number(rows[0]!.dr)).toBeCloseTo(1000, 2);
  });

  it('preview reports the same figures and writes nothing', async () => {
    await leg('CUST', 2000, 0);
    await leg('SALES', 0, 2000);
    const preview = await yearEndPreview(runtime, { scope, fromYear: FROM } as any);
    expect(preview.accounts).toBe(2);
    expect(preview.totals.dr).toBeCloseTo(2000, 2);
    expect(preview.totals.cr).toBeCloseTo(2000, 2);
    // Read-only: no opening legs should exist for any year.
    const [openingCount] = (await withTenant(owner, TENANT, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1 AND "VCH_TYPE"='ACOP'`,
        TENANT,
      ),
    )) as Array<{ n: number }>;
    expect(openingCount!.n).toBe(0);
  });

  it('refuses a close that would carry a year onto itself', async () => {
    await expect(
      yearEndClose(runtime, { scope, fromYear: FROM, toYear: FROM } as any),
    ).rejects.toBeInstanceOf(YearEndValidationError);
    await expect(
      yearEndClose(runtime, { scope, fromYear: '', toYear: TO } as any),
    ).rejects.toBeInstanceOf(YearEndValidationError);
  });

  it('the carry is self-balancing in aggregate', async () => {
    // Whatever the individual signs, the opening must not create or destroy value: Σ opening debits must
    // equal Σ opening credits whenever the closed year balanced.
    await leg('CUST', 9000, 0);
    await leg('SALES', 0, 6000);
    await leg('TAX', 0, 3000);
    await yearEndClose(runtime, { scope, fromYear: FROM, toYear: TO } as any);
    const rows = await openingLegs();
    const dr = rows.reduce((t, r) => t + Number(r.dr), 0);
    const cr = rows.reduce((t, r) => t + Number(r.cr), 0);
    expect(dr).toBeCloseTo(cr, 2);
    expect(dr).toBeCloseTo(9000, 2);
  });
});
