#!/usr/bin/env node
/**
 * FUNCTIONAL WORKFLOW PARITY MATRIX.
 *
 * WHY THIS EXISTS — WHAT THE EXISTING MEASURES DO NOT TELL YOU
 * ===========================================================
 * The parity work so far has measured three things, all of them useful and none of them functional:
 *
 *   * SCHEMA parity      — 145/145 tables, 5231/5231 columns. Says the shape can hold the data.
 *   * CONTROL coverage   — 73.2% of 4555 desktop UI controls exist (VALIDATION-PLAN.md). Counts widgets.
 *   * FIELD differences  — 4349 across 66 replayed vouchers. Counts cell-level disagreement.
 *
 * None of them answers the question a shop owner actually has: **can I do my job on this?** A form can have
 * every control and every column and still be unusable because you cannot reopen yesterday's invoice to fix a
 * weight, or because deleting it leaves the day book wrong, or because the date lock does not hold.
 *
 * So this tool measures the OPERATOR LIFECYCLE per voucher family instead:
 *
 *   CREATE     can the voucher be posted at all
 *   OPEN       can a saved voucher be retrieved for viewing
 *   EDIT       can a saved voucher be corrected and re-posted
 *   DELETE     can it be reversed, with the desktop's delete audit
 *   NUMBER     does it draw from the desktop's numbering series
 *   LOCK       is it subject to the desktop's date / consumed-tag locks
 *   PRINT      is there a voucher print path
 *   LEDGER     does it write balanced AC_DATA legs
 *   (day book)  NOT measured here — see the note below and use daybook-family-audit.mjs
 *   STOCK      does it move MAIN_STOCK where the desktop does
 *   TAX        does it write TAX_DATA where the desktop does
 *   TESTED     is there a database-backed lifecycle test
 *
 * Each cell is derived from the code, not from a document: registered route verbs, the tables each module
 * writes, the lock helpers it calls, and the test files that exercise it. Absence is reported as absence.
 *
 * USAGE
 *   node apps/api/integration/functional-parity-matrix.mjs
 *   FPM_OUT=/tmp/fpm.json node apps/api/integration/functional-parity-matrix.mjs
 */
import { readFile, readdir, writeFile } from 'node:fs/promises';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const HERE = dirname(fileURLToPath(import.meta.url));
const API = resolve(HERE, '..');
const OUT =
  process.env.FPM_OUT ??
  resolve(HERE, '../../../../project-memory/parity/FUNCTIONAL-PARITY-MATRIX.json');

/**
 * The voucher families a jewellery shop actually operates, each mapped to:
 *   desktopForms  the desktop form(s) it replaces
 *   basePath      the API path family whose verbs express the lifecycle
 *   module        the module file that owns the posting logic
 *   liveVouchers  how many the reference company posted in a year (0 = configured but unused)
 *
 * `liveVouchers` comes from the AC_DATA/BOOK_DATA census: it is what makes this a priority list rather than an
 * inventory. A family with 841 real vouchers and no EDIT is a different problem from one with 0.
 */
const FAMILIES = [
  {
    name: 'Sales invoice',
    desktopForms: ['TR_SALE'],
    basePath: '/sales',
    module: 'sales/sales.ts',
    liveVouchers: 189,
  },
  {
    name: 'Hallmark sale',
    desktopForms: ['TR_SALE_HM'],
    basePath: '/sales',
    module: 'sales/sales.ts',
    liveVouchers: 0,
  },
  {
    name: 'Sales return',
    desktopForms: ['TR_SALE_RTN'],
    basePath: '/sales-returns',
    module: 'sales/salesReturn.ts',
    liveVouchers: 1,
  },
  {
    name: 'Sales order',
    desktopForms: ['TR_SALE_ORD'],
    basePath: '/sales-orders',
    module: 'sales/salesOrder.ts',
    liveVouchers: 39,
  },
  {
    name: 'Order cancel',
    desktopForms: ['TR_SL_ORD_ADJ'],
    basePath: '/sales-orders',
    module: 'sales/salesOrder.ts',
    liveVouchers: 1,
  },
  {
    name: 'Labour invoice',
    desktopForms: ['TR_SALE_LBR'],
    basePath: '/labour-invoice',
    module: 'sales/labourInvoice.ts',
    liveVouchers: 3,
  },
  {
    name: 'Rate cut / wholesale',
    desktopForms: ['TR_PR_SL_HEDG', 'TR_WH_SALE'],
    basePath: '/rate-cut',
    module: 'sales/rateCut.ts',
    liveVouchers: 40,
  },
  {
    name: 'VP parcel',
    desktopForms: ['TR_VP'],
    basePath: '/sales/vp-parcel',
    module: 'sales/vpParcel.ts',
    liveVouchers: 0,
  },
  {
    name: 'Wholesale sale return',
    desktopForms: ['TR_WH_SALE_RTN'],
    basePath: '/sales/wholesale-sale-return',
    module: 'sales/wholesaleSaleReturn.ts',
    liveVouchers: 0,
  },
  {
    name: 'Purchase',
    desktopForms: ['TR_PURC'],
    basePath: '/purchases',
    module: 'purchase/purchase.ts',
    liveVouchers: 51,
  },
  {
    name: 'Purchase HM',
    desktopForms: ['TR_PURC_HM'],
    basePath: '/purchases',
    module: 'purchase/purchase.ts',
    liveVouchers: 0,
  },
  {
    name: 'Purchase return',
    desktopForms: ['TR_PURC'],
    basePath: '/purchase-returns',
    module: 'purchase/purchaseReturn.ts',
    liveVouchers: 0,
  },
  {
    name: 'Other purchase',
    desktopForms: ['TR_OTH_PURC'],
    basePath: '/other-purchase',
    module: 'purchase/purchase.ts',
    liveVouchers: 0,
  },
  {
    name: 'Other commission',
    desktopForms: ['TR_OTH_COMM'],
    basePath: '/other-commission',
    module: 'purchase/otherCommission.ts',
    liveVouchers: 3,
  },
  {
    name: 'Cash receipt',
    desktopForms: ['TR_CASH'],
    basePath: '/receipts',
    module: 'finance/finance.ts',
    liveVouchers: 56,
  },
  {
    name: 'Cash payment',
    desktopForms: ['TR_CASH'],
    basePath: '/payments',
    module: 'finance/finance.ts',
    liveVouchers: 133,
  },
  {
    name: 'Contra / journal',
    desktopForms: ['TR_CONTRA'],
    basePath: '/contra',
    module: 'finance/finance.ts',
    liveVouchers: 37,
  },
  {
    name: 'Fine JV',
    desktopForms: ['TR_FINE_SL_PR'],
    basePath: '/fine-jv',
    module: 'finance/fineJv.ts',
    liveVouchers: 14,
  },
  {
    name: 'Ledger adjust',
    desktopForms: ['TR_LEDR_ADJ'],
    basePath: '/ledger-adjust',
    module: 'finance/ledgerAdjust.ts',
    liveVouchers: 0,
  },
  {
    name: 'Employee JV',
    desktopForms: ['TR_EMP_JV'],
    basePath: '/employee-jv',
    module: 'finance/employeeJv.ts',
    liveVouchers: 0,
  },
  {
    name: 'Account opening',
    desktopForms: ['TR_AC_OPBL'],
    basePath: '/ac-opbl',
    module: 'finance/acOpening.ts',
    liveVouchers: 0,
  },
  {
    name: 'Bill to bill',
    desktopForms: ['TR_BILL_TO'],
    basePath: '/bill-to-bill',
    module: 'finance/billToBill.ts',
    liveVouchers: 1,
  },
  {
    name: 'Gold book',
    desktopForms: ['TR_GOLD_BOOK'],
    basePath: '/finance/gold-book',
    module: 'finance/goldBook.ts',
    liveVouchers: 0,
  },
  {
    name: 'Location amount',
    desktopForms: ['TR_LOCT_AMT'],
    basePath: '/finance/location-amount',
    module: 'finance/locationAmount.ts',
    liveVouchers: 0,
  },
  {
    name: 'VP adjustment',
    desktopForms: ['TR_VP_ADJ'],
    basePath: '/finance/vp-adjustment',
    module: 'finance/vpAdjustment.ts',
    liveVouchers: 0,
  },
  {
    name: 'Karigar issue',
    desktopForms: ['TR_KR_ISU'],
    basePath: '/karigar/issue',
    module: 'manufacturing/karigar.ts',
    liveVouchers: 1,
  },
  {
    name: 'Karigar receipt',
    desktopForms: ['TR_MFG_KR_ISU_REC'],
    basePath: '/karigar/receive',
    module: 'manufacturing/karigar.ts',
    liveVouchers: 16,
  },
  {
    name: 'Job-work issue',
    desktopForms: ['TR_JDT_REC'],
    basePath: '/mfg/jobwork-issue',
    module: 'manufacturing/mfg.ts',
    liveVouchers: 0,
  },
  {
    name: 'Job-work receive',
    desktopForms: ['TR_JDT_REC'],
    basePath: '/mfg/jobwork-receive',
    module: 'manufacturing/mfg.ts',
    liveVouchers: 0,
  },
  {
    name: 'Manufacturing issue',
    desktopForms: ['TR_MFG_ISU_REC'],
    basePath: '/mfg/issue',
    module: 'manufacturing/mfg.ts',
    liveVouchers: 0,
  },
  {
    name: 'Manufacturing receive',
    desktopForms: ['TR_MFG_ISU_REC'],
    basePath: '/mfg/receive',
    module: 'manufacturing/mfg.ts',
    liveVouchers: 0,
  },
  {
    name: 'Melting',
    desktopForms: ['TR_MLT_PRO'],
    basePath: '/melting',
    module: 'manufacturing/meltingPro.ts',
    liveVouchers: 0,
  },
  {
    name: 'Repair receipt',
    desktopForms: ['TR_REP_REC'],
    basePath: '/repair-receipts',
    module: 'repair/repairReceipt.ts',
    liveVouchers: 0,
  },
  {
    name: 'Tag opening',
    desktopForms: ['TR_TAG_OPBL'],
    basePath: '/stock/tag-opening',
    module: 'stock/stock.ts',
    liveVouchers: 1,
  },
  {
    name: 'Item opening',
    desktopForms: ['TR_ITM_OPBL'],
    basePath: '/stock/item-opening',
    module: 'stock/stock.ts',
    liveVouchers: 0,
  },
  {
    name: 'Item lot',
    desktopForms: ['TR_ITM_LOT'],
    basePath: '/stock/item-lot',
    module: 'stock/stock.ts',
    liveVouchers: 0,
  },
  {
    name: 'Tag split',
    desktopForms: ['TR_TAG_SPLIT'],
    basePath: '/stock/tag-split',
    module: 'stock/tagSplit.ts',
    liveVouchers: 0,
  },
  {
    name: 'Tag cancel',
    desktopForms: ['TR_TAG_CAN'],
    basePath: '/stock/tag-cancel',
    module: 'stock/tagOps.ts',
    liveVouchers: 0,
  },
  {
    name: 'Tag weight diff',
    desktopForms: ['TR_TAG_WT_DIFF'],
    basePath: '/stock/tag-weight-diff',
    module: 'stock/tagOps.ts',
    liveVouchers: 0,
  },
  {
    name: 'Physical stock',
    desktopForms: ['TR_PHYSTK'],
    basePath: '/stock/physical-stock',
    module: 'stock/physicalStock.ts',
    liveVouchers: 0,
  },
  {
    name: 'Stock adjust',
    desktopForms: ['TR_INOUT'],
    basePath: '/stock/adjust',
    module: 'stock/stock.ts',
    liveVouchers: 0,
  },
  {
    name: 'Fine in/out',
    desktopForms: ['TR_FN_INOUT'],
    basePath: '/inout/fine',
    module: 'inout/fineInout.ts',
    liveVouchers: 0,
  },
  {
    name: 'Scheme enrol',
    desktopForms: ['TR_MEMB_ENT'],
    basePath: '/scheme/enroll',
    module: 'membership/scheme.ts',
    liveVouchers: 841,
  },
  {
    name: 'Scheme instalment',
    desktopForms: ['TR_MEMB_ENT'],
    basePath: '/scheme/installment',
    module: 'membership/scheme.ts',
    liveVouchers: 841,
  },
  {
    name: 'Scheme maturity',
    desktopForms: ['TR_MEMB_ADJ'],
    basePath: '/scheme/maturity',
    module: 'membership/scheme.ts',
    liveVouchers: 17,
  },
  {
    name: 'Dhrn issue',
    desktopForms: ['TR_DHRN_ISU'],
    basePath: '/dhrn/issue',
    module: 'dhrn/dhrn.ts',
    liveVouchers: 0,
  },
  {
    name: 'Dhrn receipt',
    desktopForms: ['TR_DHRN_REC'],
    basePath: '/dhrn/receipt',
    module: 'dhrn/dhrn.ts',
    liveVouchers: 0,
  },
  {
    name: 'Dhrn interest',
    desktopForms: ['TR_DHRN_INTREC'],
    basePath: '/dhrn/interest',
    module: 'dhrn/dhrn.ts',
    liveVouchers: 0,
  },
  {
    name: 'Bullion booking',
    desktopForms: ['TR_BUL_BOOKING'],
    basePath: '/bullion/booking',
    module: 'bullion/bullion.ts',
    liveVouchers: 0,
  },
  {
    name: 'Fine sale/purchase',
    desktopForms: ['TR_FINE_SL_PR'],
    basePath: '/fine-sale',
    module: 'bullion/fineSalePurchase.ts',
    liveVouchers: 0,
  },
  {
    name: 'Tour issue',
    desktopForms: ['TR_TOUR', 'TR_APR_ISU'],
    basePath: '/tour/issue',
    module: 'tour/tour.ts',
    liveVouchers: 0,
  },
  {
    name: 'Tour return',
    desktopForms: ['TR_TOUR'],
    basePath: '/tour/return',
    module: 'tour/tour.ts',
    liveVouchers: 0,
  },
];

/**
 * THE DAY-BOOK COLUMN WAS REMOVED FROM THIS TOOL. It could not be made reliable and was wrong three ways:
 *   1. matching /ROJ_MEL_DATA|rojmel/i over the MODULE gave a false POSITIVE — `finance.ts` serves several
 *      families and contra was reported as covered while writing none of the desktop's 74 rows;
 *   2. after `deleteBillSettlement` was added, the same match caught a REVERSAL path and flipped
 *      bill-to-bill to a false positive even though `settleBills` projects nothing;
 *   3. tightening it to require a `build*Rojmel(` call then produced false NEGATIVES, because several
 *      modules project through a helper or a different mechanism.
 * The underlying problem is that the unit of analysis has to be the call graph, and
 * `daybook-family-audit.mjs` already does that properly against live desktop row counts — currently
 * 3148 of 3150 rows. A metric that has been wrong in three directions is worse than no metric, so this one
 * is gone rather than iterated on again.
 *
 * Downstream write targets that matter to the business, and the module-source evidence for each.
 *
 * CAVEAT — THESE ARE MODULE-LEVEL SIGNALS AND ONLY WEAK POSITIVES.
 * A module often serves several families: `finance.ts` handles contra, cash receipt, cash payment and more.
 * If ANY of them projects into the day book, the regex matches and every family in that module is reported
 * as covered. That produced a false positive: contra was marked DAYBOOK=Y, and a family-level test
 * (contraDelete.db.test.ts) then proved the web writes NONE of the desktop's 74 contra day-book rows.
 *
 * Treat a Y here as "the module can", not "this family does". Plan item F3.4 replaces this with a
 * family-level check per family. A `.` is still a STRONG negative: the module cannot write it at all.
 */
const DOWNSTREAM = {
  LEDGER: /AC_DATA/,
  STOCK: /MAIN_STOCK/,
  TAX: /TAX_DATA/,
};

/** Lock mechanisms the desktop enforces; any reference counts as "subject to locks". */
const LOCK_SIGNALS = /lastDayLock|assertNotLocked|LOCK_DATE|persistedDate|lockCheck|consumed/i;

async function main() {
  const routeSrc = [
    await readFile(resolve(API, 'src/routes/txn.ts'), 'utf8'),
    await readFile(resolve(API, 'src/app.ts'), 'utf8'),
  ].join('\n');

  // verb -> set of paths
  const routes = [];
  for (const m of routeSrc.matchAll(/app\.(get|post|put|delete|patch)\(\s*'([^']+)'/g)) {
    routes.push({ verb: m[1].toUpperCase(), path: m[2] });
  }

  const testFiles = (await readdir(resolve(API, 'test'))).filter((f) => f.endsWith('.ts'));
  const testSrc = new Map();
  for (const f of testFiles) testSrc.set(f, await readFile(resolve(API, 'test', f), 'utf8'));

  const rows = [];
  for (const fam of FAMILIES) {
    const base = fam.basePath;
    const own = routes.filter((r) => r.path === base || r.path.startsWith(base + '/'));
    const verbs = new Set(own.map((r) => r.verb));
    /**
     * OPEN and EDIT need an instance path — you cannot retrieve or correct "the collection".
     *
     * DELETE does NOT, and assuming it did produced a false negative. Scheme enrolment is keyed by
     * SCHM_CODE + MEMB_CODE, not by a voucher number (AD_MEMB carries neither VCH_NO nor AC_CODE), so its
     * reversal is `DELETE /scheme/enroll` with the member identity in the body. Requiring a `:param` reported
     * the 841-voucher scheme family as having no delete when it has one.
     */
    const instance = own.filter((r) => r.path.includes(':'));
    const iv = new Set(instance.map((r) => r.verb));
    const canDelete = iv.has('DELETE') || own.some((r) => r.path === base && r.verb === 'DELETE');

    let moduleSource = '';
    try {
      moduleSource = await readFile(resolve(API, 'src/modules', fam.module), 'utf8');
    } catch {
      moduleSource = '';
    }

    const downstream = {};
    for (const [k, re] of Object.entries(DOWNSTREAM)) downstream[k] = re.test(moduleSource);

    // A database-backed lifecycle test that names this module or its base path.
    const modLeaf = fam.module.split('/').pop().replace('.ts', '');
    const tested = [...testSrc.entries()].some(
      ([f, s]) => f.includes('.db.test.ts') && (s.includes(base) || s.includes(modLeaf)),
    );

    rows.push({
      family: fam.name,
      desktopForms: fam.desktopForms,
      liveVouchers: fam.liveVouchers,
      basePath: base,
      module: fam.module,
      moduleFound: moduleSource.length > 0,
      CREATE: verbs.has('POST'),
      OPEN: iv.has('GET'),
      EDIT: iv.has('PUT'),
      DELETE: canDelete,
      LOCK: LOCK_SIGNALS.test(moduleSource),
      ...downstream,
      TESTED: tested,
      routeCount: own.length,
    });
  }

  const flag = (b) => (b ? 'Y' : '·');
  console.log('family                       live   C O E D  Lk  Ldg Stk Tax  T   desktop form(s)');
  console.log('---------------------------- -----  - - - -  --  --- --- ---  -   ---------------');
  for (const r of rows) {
    console.log(
      `${r.family.padEnd(28)} ${String(r.liveVouchers).padStart(5)}  ` +
        `${flag(r.CREATE)} ${flag(r.OPEN)} ${flag(r.EDIT)} ${flag(r.DELETE)}  ` +
        `${flag(r.LOCK)}   ${flag(r.LEDGER)}   ${flag(r.STOCK)}   ${flag(r.TAX)}   ` +
        `${flag(r.TESTED)}   ${r.desktopForms.join(', ')}`,
    );
  }

  const n = rows.length;
  const pct = (k) => `${rows.filter((r) => r[k]).length}/${n}`;
  const live = rows.filter((r) => r.liveVouchers > 0);
  const pctLive = (k) => `${live.filter((r) => r[k]).length}/${live.length}`;
  console.log(
    `\nall families      CREATE ${pct('CREATE')}  OPEN ${pct('OPEN')}  EDIT ${pct('EDIT')}  ` +
      `DELETE ${pct('DELETE')}  TESTED ${pct('TESTED')}`,
  );
  console.log(
    `families in live use  CREATE ${pctLive('CREATE')}  OPEN ${pctLive('OPEN')}  EDIT ${pctLive('EDIT')}  ` +
      `DELETE ${pctLive('DELETE')}  TESTED ${pctLive('TESTED')}`,
  );

  await writeFile(
    OUT,
    JSON.stringify(
      {
        kind: 'datacare.functional-parity-matrix/1.0',
        measuredAt: new Date().toISOString(),
        note:
          'Operator-lifecycle capability per voucher family, derived from registered route verbs, module ' +
          'write targets, lock references and database-backed tests. liveVouchers is the reference ' +
          "company's one-year count, so 0 means configured-but-unused rather than unimportant.",
        families: rows,
      },
      null,
      2,
    ) + '\n',
  );
  console.log(`\nFPM_OK ${OUT}`);
}

main().catch((e) => {
  console.error('FPM_FAIL', e?.message ?? e);
  process.exit(1);
});
