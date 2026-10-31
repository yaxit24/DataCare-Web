import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { withTenant } from '@datacare/db';
import { createPurchase, editPurchase, getPurchase } from '../src/modules/purchase/purchase.js';
import { editKarigar, getKarigar, receiveKarigar } from '../src/modules/manufacturing/karigar.js';
import { editMfg, getMfg, issueMfg } from '../src/modules/manufacturing/mfg.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

/** N51: the purchase's current version, as the screen would have read it before saving or deleting. */
const versionOfPurchase = async (prisma: any, scope: any, vchNo: number | string) =>
  String((await getPurchase(prisma, scope, vchNo)).version);

/**
 * Operator-depth round-trip harness (parity plan P0-2).
 *
 * WHY A SEPARATE HARNESS
 * Counting the fields a screen renders proves the markup exists. It does not prove the value
 * survives a save, and that is where depth is actually lost. WP-08 found an unchanged reopen
 * and save wiping 43 of 109 `BAR_DETL` columns while every field was on screen and every
 * lifecycle test passed, because the reader selected fewer columns than the writer accepted.
 *
 * THE CONTRACT, applied per workflow:
 *   1. create with every field the screen can supply, each a DISTINCT non-default value
 *   2. read it back
 *   3. assert every supplied value returned equal          -> catches writer/reader asymmetry
 *   4. edit with the unmodified read-back payload
 *   5. re-read and assert byte-equality with step 2        -> catches delete-and-rebuild loss
 *   6. assert no identity (serial) changed                 -> catches re-allocation on edit
 *
 * Step 5 is the one that matters most and the one ordinary lifecycle tests skip: they assert a
 * changed save changes what was changed, never that an UNCHANGED save changes nothing.
 *
 * Distinct values are not a stylistic preference. If two fields share a value, a mapping that
 * crosses them round-trips cleanly and the bug survives.
 */

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'operator-depth-roundtrip';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-04-10';

// ---------------------------------------------------------------------------
// generic comparison utilities
// ---------------------------------------------------------------------------

/** Normalise the shapes Postgres and Prisma hand back so equal values compare equal. */
const canonical = (value: unknown): unknown => {
  if (value === null || value === undefined) return null;
  if (typeof value === 'bigint') return Number(value);
  if (typeof value === 'object' && value !== null && 'toNumber' in (value as any)) {
    // Prisma Decimal
    return Number((value as any).toNumber());
  }
  if (value instanceof Date) return value.toISOString();
  if (typeof value === 'number') {
    // Money and weight columns are numeric(n,3); compare at that scale rather than in binary
    // floating point, which would make 2372.2199999 differ from 2372.22.
    return Math.round(value * 1e6) / 1e6;
  }
  if (typeof value === 'string') return value.trim();
  if (Array.isArray(value)) return value.map(canonical);
  if (typeof value === 'object') {
    const out: Record<string, unknown> = {};
    for (const key of Object.keys(value as Record<string, unknown>).sort()) {
      out[key] = canonical((value as Record<string, unknown>)[key]);
    }
    return out;
  }
  return value;
};

interface Difference {
  path: string;
  before: unknown;
  after: unknown;
}

/** Every leaf path where two structures differ, so a failure names the columns it lost. */
const differences = (before: unknown, after: unknown, path = ''): Difference[] => {
  const a = canonical(before);
  const b = canonical(after);
  if (Array.isArray(a) || Array.isArray(b)) {
    const aa = Array.isArray(a) ? a : [];
    const bb = Array.isArray(b) ? b : [];
    if (aa.length !== bb.length) {
      return [{ path: `${path}.length`, before: aa.length, after: bb.length }];
    }
    return aa.flatMap((item, index) => differences(item, bb[index], `${path}[${index}]`));
  }
  const aObj = a && typeof a === 'object';
  const bObj = b && typeof b === 'object';
  if (aObj || bObj) {
    const keys = new Set([
      ...Object.keys((a as Record<string, unknown>) ?? {}),
      ...Object.keys((b as Record<string, unknown>) ?? {}),
    ]);
    return [...keys].flatMap((key) =>
      differences(
        (a as Record<string, unknown>)?.[key],
        (b as Record<string, unknown>)?.[key],
        path ? `${path}.${key}` : key,
      ),
    );
  }
  return a === b ? [] : [{ path: path || '(root)', before: a, after: b }];
};

const describeDifferences = (label: string, diffs: Difference[]): string =>
  `${label}: ${diffs.length} field(s) changed\n` +
  diffs
    .map((d) => `  ${d.path}: ${JSON.stringify(d.before)} -> ${JSON.stringify(d.after)}`)
    .join('\n');

/** Read a dotted path out of a read-back document. Supports `lines[0].field`. */
const at = (doc: unknown, path: string): unknown =>
  path.split('.').reduce<any>((node, key) => {
    if (node == null) return undefined;
    const index = key.match(/^(\w+)\[(\d+)\]$/);
    if (index?.[1] != null) return node[index[1]]?.[Number(index[2])];
    return node[key];
  }, doc);

interface RoundTripCase<TRead> {
  label: string;
  /** Create the voucher and return its number. */
  create: () => Promise<string>;
  /** Read the voucher back into the shape the screen would repopulate from. */
  read: (voucherNo: string) => Promise<TRead>;
  /** Save the read-back document unchanged. */
  editUnchanged: (voucherNo: string, document: TRead) => Promise<void>;
  /**
   * Values the creating screen supplied, keyed by their dotted path in the read-back.
   * Asserting these separately from the byte-equality check distinguishes "the writer dropped
   * it" from "the editor dropped it" — different bugs with different fixes.
   */
  supplied: Record<string, unknown>;
  /** Paths that must be identical before and after the unchanged save (serials, identities). */
  identity: string[];
}

/** The six-step contract. Returns the two read-backs so a caller can assert further. */
const assertLosslessRoundTrip = async <TRead>(
  testCase: RoundTripCase<TRead>,
): Promise<{ first: TRead; second: TRead }> => {
  const voucherNo = await testCase.create();

  const first = await testCase.read(voucherNo);

  // step 3 — did the WRITER keep what the screen sent?
  const dropped: Difference[] = [];
  for (const [path, expected] of Object.entries(testCase.supplied)) {
    const actual = at(first, path);
    if (canonical(actual) !== canonical(expected)) {
      dropped.push({ path, before: expected, after: actual });
    }
  }
  expect(
    dropped,
    describeDifferences(
      `${testCase.label}: values supplied on create did not survive the write`,
      dropped,
    ),
  ).toEqual([]);

  // steps 4-5 — does an UNCHANGED save preserve everything?
  await testCase.editUnchanged(voucherNo, first);
  const second = await testCase.read(voucherNo);

  // The version token changes on every save by design (N51, D17); it is not voucher data.
  const withoutVersion = (view: any) => {
    const { version: _version, ...rest } = view ?? {};
    return rest;
  };
  const lost = differences(withoutVersion(first), withoutVersion(second));
  expect(
    lost,
    describeDifferences(`${testCase.label}: an unchanged save altered the voucher`, lost),
  ).toEqual([]);

  // step 6 — identity stability
  for (const path of testCase.identity) {
    expect(
      canonical(at(second, path)),
      `${testCase.label}: identity ${path} changed across an unchanged save`,
    ).toEqual(canonical(at(first, path)));
  }

  return { first, second };
};

// ---------------------------------------------------------------------------

databaseDescribe('operator depth — lossless round trips', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const scope = (book: string): VoucherScope => ({
    tenantId: TENANT,
    coCode: CO,
    lcCode: LC,
    coYear: YEAR,
    coBook: book,
  });

  const clean = async () => {
    const tables: string[] = await owner
      .$queryRawUnsafe<Array<{ table_name: string }>>(
        `SELECT table_name FROM information_schema.columns
          WHERE table_schema='public' AND column_name='tenant_id'`,
      )
      .then((rows) => rows.map((r) => r.table_name));
    for (const table of tables) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seed = async () => {
    // The settings behaviour resolver requires exactly one CO_SET row per company, so this is
    // structural rather than optional (settingsBehavior.ts:315).
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`,
      TENANT,
      CO,
    );
    // The edit path asserts the voucher date falls inside an unambiguous fiscal year
    // (lifecycle.ts:95), so a round-trip cannot reach step 4 without this row.
    await owner.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
       VALUES ($1,$2,$3,'2024-04-01','2025-03-31'::timestamp)`,
      TENANT,
      CO,
      YEAR,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_TYPE")
       VALUES ($1,$2,$3,'SUPP','Depth Supplier','L'),
              ($1,$2,$3,'KARI','Depth Karigar','L'),
              ($1,$2,$3,'CUST','Depth Customer','L')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC")
       VALUES ($1,$2,'10',1,'GST','GST 3%',3,'GSTLED')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
       VALUES ($1,$2,'G01','Gold','SALEAC','PURCAC')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,'GOLD','Gold Ornament','G','G01'),
              ($1,$2,'LOOSE','Loose Gold','G','G01')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,'PUR','Depth Purchase','DPB','PURCHASE','I','Y','PR_DATA'),
              ($1,$2,$3,'KRC','Depth Karigar Rec','DKR','KARIGAR','I','Y','KR_DATA'),
              ($1,$2,$3,'MFG','Depth Mfg','DMF','MANUFACTURING','O','Y','MFG_DATA')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,'PUR',1,'CTRL','PURCHASE','I'),
              ($1,$2,$3,'PUR',2,'CASH','PURCHASE','I'),
              ($1,$2,$3,'PUR',3,'ROUND','PURCHASE','I'),
              ($1,$2,$3,'KRC',1,'CTRL','KARIGAR','I'),
              ($1,$2,$3,'KRC',2,'CASH','KARIGAR','I'),
              ($1,$2,$3,'KRC',3,'ROUND','KARIGAR','I'),
              ($1,$2,$3,'MFG',1,'CTRL','MANUFACTURING','O'),
              ($1,$2,$3,'MFG',2,'CASH','MANUFACTURING','O'),
              ($1,$2,$3,'MFG',3,'ROUND','MANUFACTURING','O')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SRNO_MAST"(tenant_id,"CO_CODE","LC_CODE","VCH_SRNO","TAG_SRNO")
       VALUES ($1,$2,$3,0,0)`,
      TENANT,
      CO,
      LC,
    );
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) {
      throw new Error('RUN_DB_INTEGRITY_TESTS requires MIGRATE_DATABASE_URL and DATABASE_URL');
    }
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  beforeEach(async () => {
    await clean();
    await seed();
  });

  afterAll(async () => {
    await clean();
    await owner?.$disconnect();
    await runtime?.$disconnect();
  });

  /**
   * PURCHASE — the control case.
   *
   * `purchase.ts` is 98.2% reachable from its screen and has already had two round-trip defects
   * fixed (WP-08: `LBR_AMT` 2372.22 -> 0 with `TOT_AMT`/`NET_AMT` following it down, and
   * `VCH_SRNO` 1 -> 2 on edit). It should therefore PASS, which is what makes it a control: a
   * failure here means the harness itself is wrong, not the product.
   *
   * Every value below is distinct so a crossed mapping cannot round-trip cleanly.
   */
  it('purchase preserves every supplied field across an unchanged save', async () => {
    const header = {
      scope: scope('PUR'),
      mainUser: 'depth-user',
      acCode: 'SUPP',
      acName: 'Depth Supplier',
      vchDate: DAY,
      billNo: 'BILL-4471',
      taxRatePct: 3,
      interState: false,
      cashAmt: 11,
      cardAmt: 22,
      chequeAmt: 33,
      bankAc: 'BANKAC',
    };
    const lines = [
      {
        itCode: 'GOLD',
        tagNo: 'DEPTH-TAG-1',
        pcs: 3,
        grossWt: 12.345,
        netWt: 11.234,
        touch: 91.6,
        ghtWt: 0.567,
        westPct: 1.25,
        rate: 6543.21,
        labourType: 'perGram' as const,
        labourRate: 55.5,
        // WP-08: LBR_TYPE cannot represent the web's percentage/fixed modes, so an explicit
        // labourAmount is what makes a reopen lossless. Without it this collapsed to 0 and took
        // TOT_AMT/NET_AMT down with it.
        labourAmount: 623.49,
        otherAmount: 77.77,
        // The eight columns WP-08 proved were selected-but-unmapped, or absent from the SELECT.
        designNo: 'DSN-9',
        tblCode: 'T37', // TBL_CODE is varchar(3); a longer value is silently truncated
        itDesc: 'distinct item description',
        bagWt: 0.089,
        mrp: 98765.43,
        otherRate: 4321.09,
        commissionPct: 2.5,
        huid: 'HUID12345A',
        // P2: stone sub-detail. The writer persisted these from the start (purchase.ts:953) but the
        // reader never selected PR_IDTL, so a reopen returned no stones and the edit — which
        // rebuilds the write set from its input — destroyed them. Two rows under one line, with
        // distinct values in both the customer (IT_*) and karigar (KR_*) blocks, because dropping
        // the karigar half leaves job-work settlement with no basis for the stone portion.
        stones: [
          {
            isrNo: 1,
            dmCode: 'DM01',
            dmName: 'Round Brilliant',
            dmColor: 'EF',
            dmSize: '1.5mm',
            dmOrigin: 'Natural',
            dmSfNo: 'SF-77',
            pcs: 4,
            grossWt: 0.412,
            pcsWt: 0.103,
            conPct: 96.5,
            conWt: 0.397,
            rateType: 'W',
            rate: 1234.5,
            lbrRate: 12.25,
            lbrAmount: 49,
            karigarWt: 0.401,
            karigarLessPct: 1.5,
            karigarConPct: 95.5,
            karigarConWt: 0.383,
            karigarRate: 1100.25,
            karigarLabourRate: 10.5,
            karigarLabourAmount: 42,
          },
          {
            isrNo: 2,
            dmCode: 'DM02',
            dmName: 'Baguette',
            pcs: 2,
            grossWt: 0.208,
            conPct: 92,
            rate: 987.65,
            karigarWt: 0.2,
          },
        ],
      },
    ];

    await assertLosslessRoundTrip({
      label: 'purchase',
      create: async () => {
        const created = await createPurchase(runtime, header as any, lines as any);
        return String(created.vchNo);
      },
      read: (voucherNo) => getPurchase(runtime, scope('PUR'), voucherNo),
      editUnchanged: async (voucherNo, document) => {
        // Replay exactly what a screen repopulated from the reader would send back. Anything the
        // reader omits is therefore absent here too, which is precisely the defect being hunted.
        const read = document as Record<string, any>;
        const detail = (read.lines ?? read.details ?? []) as Array<Record<string, any>>;
        await editPurchase(
          runtime,
          header as any,
          detail.map((line) => ({
            itCode: line.itCode,
            tagNo: line.tagNo,
            vchSrno: line.vchSrno,
            pcs: line.pcs,
            grossWt: line.grossWt,
            netWt: line.netWt,
            touch: line.touch,
            ghtWt: line.ghtWt,
            westPct: line.westPct,
            rate: line.rate,
            labourType: line.labourType,
            labourRate: line.labourRate,
            labourAmount: line.labourAmount,
            otherAmount: line.otherAmount,
            designNo: line.designNo,
            tblCode: line.tblCode,
            itDesc: line.itDesc,
            bagWt: line.bagWt,
            mrp: line.mrp,
            otherRate: line.otherRate,
            commissionPct: line.commissionPct,
            huid: line.huid,
            // Replay the stones the reader handed back. If the reader dropped them, this sends none
            // and the assertions below fail with the exact lost paths named.
            stones: line.stones,
          })) as any,
          voucherNo,
          await versionOfPurchase(runtime, (header as any).scope, voucherNo),
        );
      },
      supplied: {
        // Header identity and the tender the screen sent.
        billNo: 'BILL-4471',
        // Every line field the screen supplied, at its read-back path. Asserting these
        // separately from byte-equality distinguishes a writer/reader asymmetry from an
        // editor that rebuilds and loses — different defects with different fixes.
        'lines[0].itCode': 'GOLD',
        'lines[0].tagNo': 'DEPTH-TAG-1',
        'lines[0].pcs': 3,
        'lines[0].grossWt': 12.345,
        'lines[0].netWt': 11.234,
        'lines[0].touch': 91.6,
        'lines[0].ghtWt': 0.567,
        'lines[0].westPct': 1.25,
        'lines[0].rate': 6543.21,
        'lines[0].labourRate': 55.5,
        'lines[0].labourAmount': 623.49,
        'lines[0].otherAmount': 77.77,
        'lines[0].designNo': 'DSN-9',
        'lines[0].tblCode': 'T37',
        'lines[0].itDesc': 'distinct item description',
        'lines[0].bagWt': 0.089,
        'lines[0].mrp': 98765.43,
        'lines[0].otherRate': 4321.09,
        'lines[0].commissionPct': 2.5,
        'lines[0].huid': 'HUID12345A',
        // Stone sub-detail must survive both the write and the unchanged re-save.
        'lines[0].stones[0].dmCode': 'DM01',
        'lines[0].stones[0].dmName': 'Round Brilliant',
        'lines[0].stones[0].dmColor': 'EF',
        'lines[0].stones[0].dmSize': '1.5mm',
        'lines[0].stones[0].dmSfNo': 'SF-77',
        'lines[0].stones[0].pcs': 4,
        'lines[0].stones[0].grossWt': 0.412,
        'lines[0].stones[0].pcsWt': 0.103,
        'lines[0].stones[0].conPct': 96.5,
        'lines[0].stones[0].rate': 1234.5,
        'lines[0].stones[0].lbrRate': 12.25,
        // The karigar half is the part a shortcut implementation drops.
        'lines[0].stones[0].karigarWt': 0.401,
        'lines[0].stones[0].karigarLessPct': 1.5,
        'lines[0].stones[0].karigarConPct': 95.5,
        'lines[0].stones[0].karigarRate': 1100.25,
        'lines[0].stones[0].karigarLabourRate': 10.5,
        'lines[0].stones[1].dmCode': 'DM02',
        'lines[0].stones[1].pcs': 2,
        'lines[0].stones[1].karigarWt': 0.2,
      },
      // WP-08 measured VCH_SRNO moving 1 -> 2 on an unchanged purchase edit, which silently
      // re-pointed the line at a different physical tag.
      identity: ['lines[0].vchSrno', 'lines[0].srNo'],
    });
  });

  /**
   * KARIGAR RECEIVE — the shared-component path.
   *
   * `KarigarForm.tsx` serves karigar issue/receive AND jobwork issue/receive through mode and
   * family props, so one screen backs four desktop forms. WP-08 found two defects behind zero
   * coverage here because no test used `mode:'receive'`: the karigar write set includes
   * `BAR_DETL` and edit deletes the write set, but only create had a builder — so an EDIT
   * destroyed the tag record and left the ornament unsellable (tag invariant 11). The builder
   * also never named `VCH_SRNO`, so the tag had no serial identity.
   *
   * This case exists to keep both fixed, and to hold the line for P1-2/P1-3 which change what
   * the form sends.
   */
  it('karigar receive preserves every supplied field across an unchanged save', async () => {
    const base = {
      scope: scope('KRC'),
      karigarAc: 'KARI',
      vchDate: DAY,
      labourAc: 'LABOUR',
      gstAc: 'GST',
    };
    const lines = [
      {
        itCode: 'GOLD',
        itDesc: 'karigar depth description',
        designNo: 'KDSN-4',
        pcs: 2,
        grossWt: 9.876,
        othWt: 0.234,
        netWt: 9.111,
        ghtWt: 0.345,
        touch: 92.5,
        // P1-3: the desktop issue formula subtracts less-weight and adds wastage. Supplying both
        // here means a regression that drops either is visible as a fine-weight difference.
        westPct: 1.75,
        lbrType: 'G',
        lbrRate: 42.5,
        lbrAmt: 387.22,
        othAmt: 55.55,
        // P2 follow-up: KR_IDTL is in `karigarWriteSet`, so an edit deletes and rebuilds it. If the
        // reader does not return these, an unchanged save destroys every stone — the same defect
        // found on PR_IDTL, reached by four pages here (karigar issue/receive, jobwork issue/receive).
        stones: [
          {
            isrNo: 1,
            dmCode: 'KDM01',
            dmName: 'Karigar Round',
            dmColor: 'GH',
            dmSize: '2.0mm',
            dmSfNo: 'KSF-11',
            pcs: 3,
            grossWt: 0.333,
            pcsWt: 0.111,
            conPct: 94.5,
            rateType: 'W',
            rate: 2222.25,
            lbrRate: 15.5,
            lbrAmount: 46.5,
            karigarWt: 0.321,
            karigarLessPct: 2.5,
            karigarRate: 2000.75,
            karigarLabourRate: 13.25,
          },
        ],
      },
    ];

    await assertLosslessRoundTrip({
      label: 'karigar receive',
      create: async () => {
        const created = await receiveKarigar(runtime, { ...base, lines } as any);
        return String(created.vchNo);
      },
      read: (voucherNo) => getKarigar(runtime, scope('KRC'), voucherNo),
      editUnchanged: async (voucherNo, document) => {
        const read = document as Record<string, any>;
        const detail = (read.lines ?? read.details ?? []) as Array<Record<string, any>>;
        await editKarigar(runtime, {
          ...base,
          vchNo: voucherNo,
          mode: 'receive',
          lines: detail.map((line) => ({
            itCode: line.itCode ?? line.IT_CODE,
            itDesc: line.itDesc ?? line.IT_DESC,
            designNo: line.designNo ?? line.DESIGN_NO,
            tagNo: line.tagNo ?? line.TAG_NO,
            vchSrno: line.vchSrno ?? line.VCH_SRNO,
            pcs: line.pcs ?? line.ITM_PCS,
            grossWt: line.grossWt ?? line.ITM_GWT,
            othWt: line.othWt ?? line.ITM_OTH_WT,
            netWt: line.netWt ?? line.ITM_NWT,
            ghtWt: line.ghtWt ?? line.ITM_GHT_WT,
            touch: line.touch ?? line.ITM_TOUCH,
            westPct: line.westPct ?? line.ITM_WEST_PRC,
            lbrType: line.lbrType ?? line.LBR_TYPE,
            lbrRate: line.lbrRate ?? line.LBR_RATE,
            lbrAmt: line.lbrAmt ?? line.LBR_AMT,
            othAmt: line.othAmt ?? line.OTH_AMT,
            stones: line.stones,
          })),
        } as any);
      },
      supplied: {
        karigarAc: 'KARI',
        'lines[0].itCode': 'GOLD',
        'lines[0].itDesc': 'karigar depth description',
        'lines[0].designNo': 'KDSN-4',
        'lines[0].pcs': 2,
        'lines[0].grossWt': 9.876,
        'lines[0].othWt': 0.234,
        'lines[0].netWt': 9.111,
        'lines[0].ghtWt': 0.345,
        'lines[0].touch': 92.5,
        // P1-3 guards this specifically: the shared form currently omits westPct on the ISSUE
        // payload. Receive keeps it, so this assertion pins the receive side while P1-3 fixes
        // issue, and makes a later regression on either side visible.
        'lines[0].westPct': 1.75,
        'lines[0].lbrType': 'G',
        'lines[0].lbrRate': 42.5,
        'lines[0].lbrAmt': 387.22,
        'lines[0].othAmt': 55.55,
        'lines[0].stones[0].dmCode': 'KDM01',
        'lines[0].stones[0].dmName': 'Karigar Round',
        'lines[0].stones[0].pcs': 3,
        'lines[0].stones[0].grossWt': 0.333,
        'lines[0].stones[0].conPct': 94.5,
        'lines[0].stones[0].rate': 2222.25,
        'lines[0].stones[0].karigarWt': 0.321,
        'lines[0].stones[0].karigarRate': 2000.75,
      },
      // WP-08: the karigar barcode builder never named VCH_SRNO, leaving the tag with no serial
      // identity, and an edit destroyed the BAR_DETL row outright.
      identity: ['lines[0].tagNo'],
    });
  });

  /**
   * MANUFACTURING — the last edit-capable module whose sub-detail had no round-trip proof.
   *
   * `mfg.ts` is the module that looked SAFE in the reader audit: it selects `MFG_IDTL`
   * (`mfg.ts:1109`) and maps `components` onto its lines (`:1152`), unlike purchase and karigar
   * which selected nothing. But selecting a table is only half the job — the mapping returned 7 of
   * the 22 fields `MfgComponent` accepts, so an unchanged save still dropped the labour columns and
   * the whole return/breakage block that `SUB_DETAIL_COMPONENT` now puts on screen.
   *
   * That is the WP-08 lesson in its subtler form, and it is why "the module reads its IDTL table"
   * is not a sufficient audit answer.
   */
  it('manufacturing preserves every supplied component field across an unchanged save', async () => {
    const base = {
      scope: scope('MFG'),
      partyAc: 'KARI',
      karigarAc: 'KARI',
      vchDate: DAY,
      mainUser: 'depth-user',
    };
    const lines = [
      {
        itCode: 'GOLD',
        pcs: 1,
        grossWt: 15.5,
        netWt: 14.25,
        touch: 91.6,
        // P3-1: MfgLine fields the server accepted that no screen could send. The process-loss trio
        // matters most: TR_MFG_ORD_REC.cs:4726 computes the karigar's accountable difference as
        // `IsNwt - (NetWt + GhtWt + Chole + Ghis + MtrlWt)`, so a screen without them cannot state it.
        totalGrossWt: 16.75,
        totalLessWt: 1.25,
        karigarJobworkWt: 2.5,
        karigarMinorityWt: 0.75,
        karigarMinorityAmount: 480.25,
        oldGrossWt: 3.125,
        oldFine: 2.86,
        oldLabourAmount: 145.5,
        oldOther: 22.75,
        addOtherWt: 0.44,
        lessOtherWt: 0.33,
        // P3-2: the nine line columns exposed by the Order Issue reopen audit (G161). Eight are
        // issue-valid and asserted here; `itmLoss` is receive-only at the writer (mfg.ts:771 gates it
        // on ctx.isReceipt) so, like itmGhat, it is covered by the receive path, not this issue voucher.
        totalNetWt: 13.75,
        oldNetWt: 2.9,
        netAmt: 81234.5,
        rateType: 'W',
        prCode: 'PR',
        krName: 'KARI',
        ordAcCode: 'ORDCUST',
        ordDesign: 'DSN-ORD-1',
        // rtnChol / rtnGhis / mtrlWt / mtrlItCode are receive-only at the writer
        // (mfg.ts:589,592 gate them on ctx.isReceipt), matching the desktop: filings and polishing
        // dust come back on RECEIPT, not when metal is issued. Supplying them on an issue voucher
        // would assert the wrong contract, so they are covered by the receive path instead.
        itmGhat: 0.35,
        dmPcs: 7,
        dmWt: 0.91,
        components: [
          {
            itCode: 'LOOSE',
            itType: 'G',
            pcs: 5,
            pcsWt: 0.22,
            grossWt: 1.1,
            conPct: 93.5,
            conWt: 1.028,
            rateType: 'W',
            rate: 5432.1,
            amount: 5583.2,
            // The block the 7-field mapping dropped.
            lbrRate: 18.75,
            lbrAmt: 20.63,
            netAmt: 5603.83,
            rtnPcs: 1,
            rtnWt: 0.2,
            brokPcs: 1,
            brokWt: 0.05,
            oldItmIsu: 'Y',
          },
        ],
      },
    ];

    await assertLosslessRoundTrip({
      label: 'manufacturing issue',
      create: async () => {
        const created = await issueMfg(runtime, { ...base, lines } as any);
        return String(created.vchNo);
      },
      read: (voucherNo) => getMfg(runtime, scope('MFG'), voucherNo),
      editUnchanged: async (voucherNo, document) => {
        const read = document as Record<string, any>;
        await editMfg(runtime, {
          ...base,
          vchNo: voucherNo,
          mode: 'issue',
          lines: (read.lines ?? []).map((line: any) => ({
            itCode: line.itCode,
            pcs: line.pcs,
            grossWt: line.grossWt,
            netWt: line.netWt,
            touch: line.touch,
            totalGrossWt: line.totalGrossWt,
            totalLessWt: line.totalLessWt,
            karigarJobworkWt: line.karigarJobworkWt,
            karigarMinorityWt: line.karigarMinorityWt,
            karigarMinorityAmount: line.karigarMinorityAmount,
            oldGrossWt: line.oldGrossWt,
            oldFine: line.oldFine,
            oldLabourAmount: line.oldLabourAmount,
            oldOther: line.oldOther,
            addOtherWt: line.addOtherWt,
            lessOtherWt: line.lessOtherWt,
            totalNetWt: line.totalNetWt,
            oldNetWt: line.oldNetWt,
            netAmt: line.netAmt,
            rateType: line.rateType,
            prCode: line.prCode,
            krName: line.krName,
            ordAcCode: line.ordAcCode,
            ordDesign: line.ordDesign,
            rtnChol: line.rtnChol,
            rtnGhis: line.rtnGhis,
            itmGhat: line.itmGhat,
            mtrlWt: line.mtrlWt,
            mtrlItCode: line.mtrlItCode,
            dmPcs: line.dmPcs,
            dmWt: line.dmWt,
            components: line.components,
          })),
        } as any);
      },
      supplied: {
        'lines[0].components[0].itCode': 'LOOSE',
        'lines[0].components[0].pcs': 5,
        'lines[0].components[0].grossWt': 1.1,
        'lines[0].components[0].conPct': 93.5,
        'lines[0].components[0].rate': 5432.1,
        'lines[0].components[0].pcsWt': 0.22,
        'lines[0].components[0].rateType': 'W',
        'lines[0].components[0].lbrRate': 18.75,
        'lines[0].components[0].lbrAmt': 20.63,
        'lines[0].components[0].rtnPcs': 1,
        'lines[0].components[0].rtnWt': 0.2,
        'lines[0].components[0].brokPcs': 1,
        'lines[0].components[0].brokWt': 0.05,
        'lines[0].components[0].oldItmIsu': 'Y',
        // P3-1 assertions.
        'lines[0].totalGrossWt': 16.75,
        'lines[0].totalLessWt': 1.25,
        'lines[0].karigarJobworkWt': 2.5,
        'lines[0].karigarMinorityWt': 0.75,
        'lines[0].karigarMinorityAmount': 480.25,
        'lines[0].oldGrossWt': 3.125,
        'lines[0].oldFine': 2.86,
        'lines[0].oldLabourAmount': 145.5,
        'lines[0].oldOther': 22.75,
        'lines[0].addOtherWt': 0.44,
        'lines[0].lessOtherWt': 0.33,
        'lines[0].dmPcs': 7,
        'lines[0].dmWt': 0.91,
        // P3-2 assertions (G161): the eight issue-valid line columns the reader now maps.
        'lines[0].totalNetWt': 13.75,
        'lines[0].oldNetWt': 2.9,
        'lines[0].netAmt': 81234.5,
        'lines[0].rateType': 'W',
        'lines[0].prCode': 'PR',
        'lines[0].krName': 'KARI',
        'lines[0].ordAcCode': 'ORDCUST',
        'lines[0].ordDesign': 'DSN-ORD-1',
      },
      identity: [],
    });
  }, 30_000);

  /**
   * TAG OPENING — round-tripped, and the containment rule it was waiting on is DISCHARGED.
   *
   * This case was skipped while `tag-opening-update` was blocked in the fail-closed registry, because an
   * `editUnchanged` step would have asserted against a path that returned 503 by design. That rule is
   * now retired: the P0-06/WP-08 exit gate is satisfied.
   *
   * The proof lives in its own file, `tagOpeningRoundTrip.db.test.ts`, and is stronger than what this
   * harness would do here — it reads the FULL persisted BAR_DETL row before and after an unchanged save
   * and demands equality on every column, rather than naming a field list that could silently drift. It
   * also asserts the BAR_IDTL sub-detail, tag identity, the MAIN_STOCK movement, and that hallmark ids
   * stay text so an alphanumeric HUID survives.
   *
   * Duplicating it here would add a second place to keep in sync without adding coverage, so this notes
   * where the obligation was discharged instead.
   */
});
