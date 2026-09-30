#!/usr/bin/env node
/**
 * GENERIC PARITY REPLAY DRIVER.
 *
 * Replays a REAL desktop voucher through the web posting engine, reconstructing the API input from the
 * desktop's own rows instead of a hand-written fixture.
 *
 * HOW THIS DIFFERS FROM parity-replay-{sale,purchase,cash,scheme}.mjs
 * ==================================================================
 * Those four scripts each hard-code one voucher: a `seed()` that types out the masters by hand and a payload
 * with literal amounts copied from that voucher. Cost is O(bespoke fixture) per case, which is why 1 of 1567
 * vouchers had ever been compared, and a mistyped fixture value shows up as a fake "web defect" (the purchase
 * replay documents exactly that happening with BOOK_SNAME).
 *
 * This driver removes both problems:
 *   * masters come from `parity-import-masters.mjs`, copied out of the real database — nothing typed;
 *   * the payload is DERIVED from the desktop header and detail rows of the voucher under test.
 *
 * WHAT IS AND IS NOT PROVED
 * -------------------------
 * Deriving the input from the desktop's OUTPUT is legitimate only for fields that are operator INPUT on the
 * desktop form. It would be circular for fields the desktop DERIVES: if the web copied a desktop-computed
 * total, the comparison of that total would be vacuous. So each family builder below takes only input-side
 * columns (party, date, item, weights, touch, rate, tender) and lets the web compute every derived figure —
 * fine, amounts, tax, rounding, ledger legs, Rojmel, stock. Those derived values are what the diff then tests.
 *
 * Each builder documents which columns it treats as input and why.
 *
 * USAGE
 *   PARITY_PG_URL=... PARITY_TENANT=parity-generic \
 *   PARITY_MSSQL_DATABASE=Live24 \
 *   PARITY_CASES='[{"caseId":"purc-035-00001","book":"035","vchNo":"00001"}]' \
 *   node apps/api/integration/parity-replay-generic.mjs
 *
 * Run parity-import-masters.mjs FIRST; this driver asserts the masters are present and refuses otherwise,
 * because an empty master set produces "web wrote nothing", which reads as a catastrophic defect.
 */
import { writeFile } from 'node:fs/promises';
import { PrismaClient } from '@prisma/client';

/** Optional: where to write the desktop/web extractor case lists produced by this run. */
const MAP_OUT = String(process.env.PARITY_CASE_MAP_OUT ?? '').trim() || null;

const IDENT = /^[A-Za-z_][A-Za-z0-9_]*$/;
const q = (v) => {
  if (!IDENT.test(v)) throw new Error(`unsafe identifier: ${v}`);
  return `"${v}"`;
};
const env = (n, d) => {
  const v = String(process.env[n] ?? '').trim();
  if (v) return v;
  if (d !== undefined) return d;
  throw new Error(`${n} is required`);
};
const num = (v) => (v == null || v === '' ? 0 : Number(v));
const str = (v) => (v == null ? '' : String(v).trim());

/* ------------------------------------------------------------------------------------------------------ *
 * Family registry.
 *
 * `detect` maps a desktop book to a family using BOOK_DATA, exactly as the desktop does — MAIN_BOOK plus
 * BOOK_TBL_NAME. Note WH SALES resolves to the rate-cut family because its BOOK_TBL_NAME is RATE_CUT_DATA;
 * that is measured configuration, not an assumption.
 * ------------------------------------------------------------------------------------------------------ */

const FAMILIES = {
  PURCHASE: {
    headerTable: 'PR_DATA',
    detailTable: 'PR_DETL',
    module: '/projects/sandbox/DataCare-Web/web/apps/api/dist/modules/purchase/purchase.js',
    entry: 'createPurchase',
    /**
     * Input-side columns only.
     *   header: AC_CODE (party chosen by the operator), VCH_DATE, TAX_CODE/TAX_PRC (tax selected),
     *           CASH_AMT/CHQ_AMT/CARD_AMT (tender typed).
     *   line:   IT_CODE, ITM_PCS, ITM_GWT, ITM_OTH_WT, ITM_NWT, ITM_TOUCH, ITM_WEST_PRC, ITM_GHT_WT,
     *           ITM_RATE, ITM_AMT, TAG_NO, LOT_NO, DESIGN_NO, ITM_SIZE.
     * Deliberately NOT taken: NET_AMT, TOT_AMT, ITM_FINE, BILL_OS, KASAR — all desktop-derived, and the
     * whole point of the comparison is whether the web derives them identically.
     *
     * WHY THE WASTAGE AND GHAT COLUMNS MATTER — a harness bug this file previously had.
     * An earlier version passed only pcs/gross/net/touch/rate/amount. `ITM_WEST_PRC` is non-zero on **43 of
     * 103** real purchase lines, and the fine formula is `(net + ght) × (touch + west) / 100`
     * (`shared/finePolicy.ts`), so omitting wastage made the web compute a LOWER fine than the desktop on
     * every one of those lines. That produced ~138 field differences across `PR_DETL.ITM_FINE`,
     * `MAIN_STOCK.ITM_FINE` and `AC_DATA.FINE_WT` that looked like a systematic web defect and were entirely
     * an artifact of the replay input. The ratios gave it away: web/desktop sat at 0.9293 on line after line,
     * which is exactly 92/99 — a touch of 92 with 7% wastage dropped.
     *
     * The lesson generalises: an input-side column omitted here shows up as a derived-value defect there.
     */
    build(header, lines, scope) {
      return [
        {
          scope,
          acCode: str(header.AC_CODE),
          acName: str(header.AC_NAME) || undefined,
          vchDate: header.VCH_DATE,
          interState: false,
          taxCode: str(header.TAX_CODE) || undefined,
          taxRatePct: num(header.TAX_PRC),
          cashAmt: num(header.CASH_AMT) || undefined,
          chequeAmt: num(header.CHQ_AMT) || undefined,
          cardAmt: num(header.CARD_AMT) || undefined,
          discountAmount: num(header.DISC_AMT) || undefined,
          mainUser: 'parity-generic',
        },
        lines.map((l) => ({
          itCode: str(l.IT_CODE),
          metal: str(l.IT_TYPE) || 'G',
          tagNo: str(l.TAG_NO) && str(l.TAG_NO) !== 'N' ? str(l.TAG_NO) : undefined,
          otherAmount: num(l.OTH_AMT) || undefined,
          labourType: num(l.LBR_RATE) ? 'per_gram' : num(l.LBR_AMT) ? 'fixed' : undefined,
          labourRate: num(l.LBR_RATE) || undefined,
          labourFixed: num(l.LBR_RATE) ? undefined : num(l.LBR_AMT) || undefined,
          lotNo: str(l.LOT_NO) || undefined,
          designNo: str(l.DESIGN_NO) || undefined,
          itmSize: str(l.ITM_SIZE) || undefined,
          pcs: num(l.ITM_PCS),
          grossWt: num(l.ITM_GWT),
          // ITM_OTH_WT is the stone / other weight deducted to reach the net.
          lessWt: num(l.ITM_OTH_WT) || undefined,
          netWt: num(l.ITM_NWT),
          touch: num(l.ITM_TOUCH),
          // The two omissions that produced ~138 false differences. Both are operator input.
          westPct: num(l.ITM_WEST_PRC) || undefined,
          ghtWt: num(l.ITM_GHT_WT) || undefined,
          rate: num(l.ITM_RATE),
          metalAmount: num(l.ITM_AMT),
        })),
      ];
    },
  },

  SALES: {
    headerTable: 'SL_DATA',
    detailTable: 'SL_DETL',
    module: '/projects/sandbox/DataCare-Web/web/apps/api/dist/modules/sales/sales.js',
    entry: 'createSale',
    build(header, lines, scope) {
      return [
        {
          scope,
          acCode: str(header.AC_CODE),
          acName: str(header.AC_NAME) || undefined,
          vchDate: header.VCH_DATE,
          interState: false,
          taxCode: str(header.TAX_CODE) || undefined,
          taxRatePct: num(header.TAX_PRC),
          cashAmt: num(header.CASH_AMT) || undefined,
          chequeAmt: num(header.CHQ_AMT) || undefined,
          cardAmt: num(header.CARD_AMT) || undefined,
          discountAmount: num(header.DISC_AMT) || undefined,
          mainUser: 'parity-generic',
        },
        lines.map((l) => ({
          itCode: str(l.IT_CODE),
          metal: str(l.IT_TYPE) || 'G',
          tagNo: str(l.TAG_NO) && str(l.TAG_NO) !== 'N' ? str(l.TAG_NO) : undefined,
          pcs: num(l.ITM_PCS),
          grossWt: num(l.ITM_GWT),
          netWt: num(l.ITM_NWT),
          touch: num(l.ITM_TOUCH),
          rate: num(l.ITM_RATE),
          metalAmount: num(l.ITM_AMT),
          labourType: num(l.LBR_RATE) ? 'per_gram' : num(l.LBR_AMT) ? 'fixed' : undefined,
          labourRate: num(l.LBR_RATE) || undefined,
          labourFixed: num(l.LBR_RATE) ? undefined : num(l.LBR_AMT) || undefined,
          otherAmount: num(l.OTH_AMT) || undefined,
        })),
      ];
    },
  },

  'RATE CUT': {
    headerTable: 'RATE_CUT_DATA',
    detailTable: 'RATE_CUT_ISU',
    module: '/projects/sandbox/DataCare-Web/web/apps/api/dist/modules/sales/rateCut.js',
    entry: 'postRateCut',
    /** Single-object entry point, so `build` returns a one-element argument list. */
    single: true,
    build(header, lines, scope) {
      return [
        {
          scope,
          acCode: str(header.AC_CODE),
          acName: str(header.AC_NAME) || undefined,
          vchDate: header.VCH_DATE,
          itType: str(header.IT_TYPE) === 'S' ? 'S' : 'G',
          convPct: num(header.CONV_PRC) || undefined,
          empCode: str(header.EMP_CODE) || undefined,
          hdVchNo: str(header.HD_VCH_NO) || undefined,
          lines: lines.map((l) => ({
            itCode: str(l.IT_CODE) || undefined,
            tagNo: str(l.TAG_NO) && str(l.TAG_NO) !== 'N' ? str(l.TAG_NO) : undefined,
            othAmt: num(l.OTH_AMT) || undefined,
            lbrAmt: num(l.LBR_AMT) || undefined,
            pcs: num(l.ITM_PCS) || undefined,
            grossWt: num(l.ITM_GWT) || undefined,
            othWt: num(l.ITM_OTH_WT) || undefined,
            netWt: num(l.ITM_NWT) || undefined,
            touch: num(l.ITM_TOUCH),
            // The column is ITM_WEST_PRC. This read `l.ITM_WEST`, which does not exist on RATE_CUT_ISU, so
            // `num(undefined)` made the wastage silently 0 on every line — the same class of harness bug as
            // the purchase builder's omission, and just as invisible: a wrong column name reads as a zero.
            westPct: num(l.ITM_WEST_PRC),
            rate: num(l.ITM_RATE),
            rateType: str(l.RATE_TYPE) || undefined,
            itType: str(header.IT_TYPE) === 'S' ? 'S' : 'G',
          })),
          fineRate: num(header.FINE_RATE) || undefined,
          settleCrFine: num(header.CR_FINE) || undefined,
          receivedLines: (header.__rec || []).map((l) => ({
            itCode: str(l.IT_CODE) || undefined,
            tagNo: str(l.TAG_NO) && str(l.TAG_NO) !== 'N' ? str(l.TAG_NO) : undefined,
            pcs: num(l.ITM_PCS) || undefined,
            grossWt: num(l.ITM_GWT) || undefined,
            othWt: num(l.ITM_OTH_WT) || undefined,
            netWt: num(l.ITM_NWT) || undefined,
            touch: num(l.ITM_TOUCH),
            westPct: num(l.ITM_WEST_PRC),
            rate: num(l.ITM_RATE),
            itType: str(header.IT_TYPE) === 'S' ? 'S' : 'G',
          })),
          pay: {
            cash: num(header.SL_CASH_AMT) || undefined,
            kasar: num(header.SL_KASAR_AMT) || undefined,
            billOs: num(header.SL_BILL_OS) || undefined,
          },
        },
      ];
    },
  },
};

/** WH SALES is configured onto RATE_CUT_DATA, so it replays through the rate-cut family. */
const FAMILY_ALIAS = { 'WH SALES': 'RATE CUT' };

async function main() {
  let mssql;
  try {
    mssql = (await import('mssql')).default;
  } catch {
    console.error('REPLAY_FAIL the "mssql" package is not installed.');
    process.exit(2);
  }

  const tenant = env('PARITY_TENANT', 'parity-generic');
  const pgUrl = env('PARITY_PG_URL');
  const runtimeUrl = String(process.env.PARITY_PG_RUNTIME_URL ?? '').trim() || pgUrl;
  const company = env('PARITY_COMPANY', '01');
  const cases = JSON.parse(env('PARITY_CASES'));

  const pool = await mssql.connect({
    server: env('PARITY_MSSQL_SERVER', '127.0.0.1'),
    port: Number(env('PARITY_MSSQL_PORT', '11433')),
    database: env('PARITY_MSSQL_DATABASE', 'Live24'),
    user: env('PARITY_MSSQL_USER', 'sa'),
    password: env('PARITY_MSSQL_PASSWORD', 'ParityProbe#2026x'),
    options: { encrypt: true, trustServerCertificate: true, enableArithAbort: true },
    requestTimeout: 120000,
  });
  const owner = new PrismaClient({ datasources: { db: { url: pgUrl } } });
  const runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });

  // Refuse to run against an unseeded tenant: "the web wrote nothing" would otherwise look like a defect.
  const [{ n: acCount }] = await owner.$queryRawUnsafe(
    `SELECT count(*)::int AS n FROM "AC_MAST" WHERE tenant_id=$1`,
    tenant,
  );
  if (!acCount) {
    console.error(
      `REPLAY_FAIL tenant ${tenant} has no AC_MAST rows.\n` +
        '  Run parity-import-masters.mjs first — replaying without masters produces an empty write set,\n' +
        '  which reads as a catastrophic web defect rather than a missing fixture.',
    );
    process.exit(1);
  }
  console.log(`tenant ${tenant}: ${acCount} account(s) present`);

  const results = [];
  for (const c of cases) {
    const book = String(c.book);
    const vchNo = String(c.vchNo);

    const cfgRows = (
      await pool
        .request()
        .input('b', mssql.NVarChar(20), book)
        .input('co', mssql.NVarChar(10), company)
        .query(
          `SELECT MAIN_BOOK, BOOK_TBL_NAME, BOOK_SNAME FROM BOOK_DATA WHERE CO_BOOK=@b AND CO_CODE=@co`,
        )
    ).recordset;
    const mainBook = str(cfgRows[0]?.MAIN_BOOK);
    const famKey = FAMILY_ALIAS[mainBook] ?? mainBook;
    const fam = FAMILIES[famKey];

    if (!fam) {
      results.push({ caseId: c.caseId, status: 'NO_BUILDER', family: mainBook || '(blank)' });
      console.log(`  ${c.caseId}: family "${mainBook}" has no builder yet — skipped`);
      continue;
    }

    const hdr = (
      await pool
        .request()
        .input('b', mssql.NVarChar(20), book)
        .input('v', mssql.NVarChar(40), vchNo)
        .query(`SELECT * FROM [${fam.headerTable}] WHERE CO_BOOK=@b AND VCH_NO=@v`)
    ).recordset;
    if (!hdr.length) {
      results.push({ caseId: c.caseId, status: 'NO_DESKTOP_HEADER', family: famKey });
      console.log(`  ${c.caseId}: no ${fam.headerTable} row for ${book}/${vchNo}`);
      continue;
    }
    const lines = (
      await pool
        .request()
        .input('b', mssql.NVarChar(20), book)
        .input('v', mssql.NVarChar(40), vchNo)
        .query(`SELECT * FROM [${fam.detailTable}] WHERE CO_BOOK=@b AND VCH_NO=@v ORDER BY SR_NO`)
    ).recordset;

    const header = hdr[0];
    if (famKey === 'RATE CUT') {
      header.__rec = (
        await pool.request().input('b', mssql.NVarChar(20), book).input('v', mssql.NVarChar(40), vchNo)
          .query(`SELECT * FROM [RATE_CUT_REC] WHERE CO_BOOK=@b AND VCH_NO=@v ORDER BY SR_NO`)
      ).recordset;
    }
    const scope = {
      tenantId: tenant,
      coCode: company,
      lcCode: str(header.LC_CODE) || '00',
      coYear: str(header.CO_YEAR) || undefined,
      coBook: book,
    };

    let mod;
    try {
      mod = await import(fam.module);
    } catch (e) {
      results.push({ caseId: c.caseId, status: 'MODULE_LOAD_FAILED', detail: e?.message });
      continue;
    }
    const fn = mod[fam.entry];
    if (typeof fn !== 'function') {
      results.push({ caseId: c.caseId, status: 'ENTRY_NOT_FOUND', detail: fam.entry });
      continue;
    }

    const args = fam.build(header, lines, scope);
    try {
      const out = fam.single ? await fn(runtime, args[0]) : await fn(runtime, args[0], args[1]);
      results.push({
        caseId: c.caseId,
        status: 'REPLAYED',
        family: famKey,
        desktopVoucher: `${book}/${vchNo}`,
        webVchNo: out?.vchNo ?? null,
        desktopLines: lines.length,
      });
      console.log(
        `  ${c.caseId}: ${famKey} ${book}/${vchNo} (${lines.length} line(s)) -> web voucher ${out?.vchNo}`,
      );
    } catch (e) {
      results.push({
        caseId: c.caseId,
        status: 'REPLAY_ERROR',
        family: famKey,
        detail: String(e?.message ?? e).slice(0, 300),
      });
      console.log(`  ${c.caseId}: ${famKey} REPLAY_ERROR ${String(e?.message ?? e).slice(0, 160)}`);
    }
  }

  const ok = results.filter((r) => r.status === 'REPLAYED').length;
  console.log(`\nreplayed ${ok}/${results.length} case(s)`);
  for (const r of results.filter((x) => x.status !== 'REPLAYED')) {
    console.log(`  ${r.status.padEnd(18)} ${r.caseId} ${r.family ?? ''} ${r.detail ?? ''}`);
  }

  /**
   * Emit the two extractor case lists.
   *
   * The web assigns its OWN voucher number from its own sequence, so a desktop voucher 035/00017 can land on
   * a different web number. `bundleDiff` pairs the two sides on `caseId`, not on the voucher number — the
   * diff artifact carries `desktopVoucher` and `webVoucher` as separate fields for exactly this reason — so
   * the same caseId must be captured with each side's own number.
   *
   * Writing both lists here removes the step where those numbers are transcribed by hand, which is where a
   * mismatched pair would silently compare two unrelated vouchers and report a wall of false differences.
   */
  if (MAP_OUT) {
    const replayed = results.filter((r) => r.status === 'REPLAYED');
    const desktopCases = replayed.map((r) => ({
      caseId: r.caseId,
      book: r.desktopVoucher.split('/')[0],
      vchNo: r.desktopVoucher.split('/')[1],
    }));
    const webCases = replayed.map((r) => ({
      caseId: r.caseId,
      book: r.desktopVoucher.split('/')[0],
      vchNo: String(r.webVchNo).padStart(5, '0'),
    }));
    await writeFile(
      MAP_OUT,
      JSON.stringify({ desktopCases, webCases, results }, null, 2) + '\n',
      'utf8',
    );
    console.log(`case map -> ${MAP_OUT} (${replayed.length} replayed case(s))`);
  }

  await pool.close();
  await owner.$disconnect();
  await runtime.$disconnect();
  console.log(ok === results.length ? 'REPLAY_OK' : 'REPLAY_PARTIAL');
  process.exit(ok === results.length ? 0 : 1);
}

main().catch(async (e) => {
  console.error('REPLAY_FAIL', e?.message ?? e);
  console.error(
    String(e?.stack ?? '')
      .split('\n')
      .slice(1, 6)
      .join('\n'),
  );
  process.exit(1);
});
