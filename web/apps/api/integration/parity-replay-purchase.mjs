#!/usr/bin/env node
/**
 * Replay retained desktop PURCHASE vouchers through the web, so the two can be compared field by field.
 *
 * This is the missing half of the parity loop. The extractor reads rows that already exist, so without a replay
 * the web-side bundle is whatever happened to be in the database — which is how the 2026-08-30 measurement came
 * to be a month stale, with 1,354 of its 3,787 differences already fixed and nobody aware.
 *
 * WHAT IS EVIDENCE HERE AND WHAT IS NOT
 * ====================================
 * Operator keystrokes are gone, so inputs are reconstructed from the persisted rows. A column the desktop
 * COMPUTED and stored, fed back in as an input, matches by construction and proves nothing. The columns that
 * carry information are the ones neither side was told:
 *
 *     AC_DATA        the ledger legs and which accounts they name
 *     MAIN_STOCK     the stock movement and its column set
 *     ROJ_MEL_DATA   the daybook projection, including LEDR_KEY construction
 *     TAX_DATA       the tax split
 *     TEMP_BOOK_DATA the hidden-voucher bookkeeping
 *
 * Read any report from this replay with that split in mind.
 *
 * MASTERS COME FROM THE DERIVED SPEC, NOT FROM IMAGINATION
 * =======================================================
 * `parity-seed-derive.mjs` reads the retained bundle and writes PARITY-REPLAY-SEED.json: the company scope, the
 * books, the parties, the items, and — the part that makes this possible offline — the account codes each book's
 * slots must point at, taken from the ledger legs the desktop actually posted.
 *
 * Two things it cannot derive, handled explicitly rather than silently:
 *
 *   CO_SET / CO_SET_NEW  company settings, absent from any voucher bundle. The values below were read from the
 *                        real database for this same company by the sale replay and are reused, not invented.
 *   SLOT ORDERING        AC_DATA names WHICH accounts a book uses but not which BOOK_DETL.SR_NO each occupies.
 *                        Assigned here by role and REPORTED, so a wrong assignment shows up as a ledger
 *                        difference rather than hiding.
 *
 * USAGE
 *   MIGRATE_DATABASE_URL=... DATABASE_URL=... node apps/api/integration/parity-replay-purchase.mjs
 *   ... --case purc-035-00001      replay one case
 *   ... --limit 5                  replay the first five
 */

import { readFileSync, writeFileSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
// The BUILT output: this is a plain .mjs with no TypeScript transform, so `pnpm --filter @datacare/api build`
// must have run. Same reason the sibling integration scripts import from dist.
import { createPurchase } from '../dist/modules/purchase/purchase.js';

const HERE = dirname(fileURLToPath(import.meta.url));
const WEB = resolve(HERE, '../../..');
const REPO = resolve(WEB, '..');

const TENANT = process.env.PARITY_REPLAY_TENANT || 'parity-purchase';
const argv = process.argv.slice(2);
const only = argv.includes('--case') ? argv[argv.indexOf('--case') + 1] : '';
const limit = argv.includes('--limit') ? Number(argv[argv.indexOf('--limit') + 1]) : Infinity;

const url = process.env.MIGRATE_DATABASE_URL;
const runtimeUrl = process.env.DATABASE_URL;
if (!url || !runtimeUrl) {
  console.error('REPLAY_SKIP need MIGRATE_DATABASE_URL and DATABASE_URL');
  process.exit(1);
}
const owner = new PrismaClient({ datasources: { db: { url } } });
const runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
const exec = (sql, ...p) => withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

const spec = JSON.parse(
  readFileSync(resolve(REPO, 'project-memory/parity/PARITY-REPLAY-SEED.json'), 'utf8'),
);
const bundle = JSON.parse(
  readFileSync(resolve(REPO, 'project-memory/parity/bundles/desktop-latest.json'), 'utf8'),
);

const CO = spec.scope.companies[0];
const LC = spec.scope.locations[0];
const YEAR = spec.scope.years[0];

const asDicts = (t) => {
  if (!t?.columns || !t?.rows) return [];
  const names = t.columns.map((c) => c.name);
  return t.rows.map((r) => Object.fromEntries(names.map((n, i) => [n, r[i]])));
};
const txt = (v) => (v == null ? '' : String(v).trim());
const num = (v) => (v == null || v === '' ? 0 : Number(v));

async function wipe() {
  const tables = await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  );
  for (const t of tables) {
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

/**
 * Assign BOOK_DETL slot numbers to the accounts a book used.
 *
 * The purchase module resolves slot 1 for the purchase ledger, slot 2 for settlement, and slots 3-4 for the
 * kasar/round-off paths. AC_DATA proves WHICH accounts the desktop posted to but not their slot numbers, so the
 * assignment goes by role: the account most often DEBITED is the purchase ledger, the one most often CREDITED
 * (excluding the party) is settlement, and the rest follow. Returned with the reasoning so a wrong guess is
 * visible in the log rather than only as a ledger difference.
 */
function assignSlots(book) {
  const byDr = [...book.slots].sort((a, b) => b.drLegs - a.drLegs || a.code.localeCompare(b.code));
  const byCr = [...book.slots].sort((a, b) => b.crLegs - a.crLegs || a.code.localeCompare(b.code));
  const purchaseAc = byDr.find((s) => s.drLegs > 0)?.code ?? byDr[0]?.code ?? '';
  const settleAc = byCr.find((s) => s.crLegs > 0 && s.code !== purchaseAc)?.code ?? '';
  const rest = book.slots.map((s) => s.code).filter((c) => c !== purchaseAc && c !== settleAc);
  const ordered = [purchaseAc, settleAc, ...rest].filter(Boolean);
  return {
    ordered,
    why: `slot1=${purchaseAc} (most DR legs) slot2=${settleAc || '-'} (most CR legs) rest=${rest.join(',') || '-'}`,
  };
}

async function seed() {
  // Company settings. NOT derivable from a voucher bundle; these were read from the real database for this
  // company by parity-replay-sale.mjs. TOT_AMT_ROF 0 is why every money column in the real data is a whole
  // rupee, and omitting it once made the web look like it had a rounding defect.
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","SL_AMT_TYPE","TAX_ROF","ALL_ROF_REMOVE","RATE_PAR","ITM_RATE_ROF")
     VALUES ($1,$2,'N','2','N','2','N','N','2')`,
    TENANT,
    CO,
  );
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

  for (const a of spec.accounts) {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,$4,$5,$6)`,
      TENANT,
      CO,
      LC,
      a.code,
      a.name || `ACCOUNT ${a.code}`,
      a.gstType || 'L',
    );
  }

  /**
   * Tax codes the cases actually use, measured from the bundle rather than assumed.
   *
   * Across the 51 purchase cases: 39 carry no tax code at all, 7 carry '00' at 0%, and 5 carry '10' at 3%.
   * The desktop's own TAX_DATA rows for code 10 are 1.5% each, so 10 is SGST 1.5 + CGST 1.5 — the same
   * structure the sale replay read from Live24, reused here rather than re-derived.
   *
   * Code '00' needs a real 0% row: the module refuses an unconfigured code, and it is right to. Treating a
   * missing tax master as "no tax" would let a genuine configuration error post silently.
   */
  const TAX_STRUCTURE = {
    '00': [[0, 'N', 'NO TAX', 0, '00085']],
    10: [
      [0, 'N', 'GST 3%', 3.0, '00085'],
      [1, 'SGST', 'SGST 1.5%', 1.5, '00085'],
      [2, 'CGST', 'CGST 1.5%', 1.5, '00086'],
      [3, 'IGST', 'IGST 3%', 3.0, '00087'],
    ],
  };
  for (const code of spec.taxCodes) {
    const rows = TAX_STRUCTURE[code];
    if (!rows) {
      console.log(
        `  WARNING tax code ${code} is used by the cases but has no known structure; not seeded`,
      );
      continue;
    }
    for (const [sr, group, name, prc, ac] of rows) {
      await exec(
        `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC")
         VALUES ($1,$2,$3,$4,$5,$6,$7,$8)`,
        TENANT,
        CO,
        code,
        sr,
        group,
        name,
        prc,
        ac,
      );
    }
  }
  // The tax component accounts are referenced by TAX_MAST but are not party or slot accounts, so they are not
  // in the derived spec.
  for (const ac of ['00085', '00086', '00087']) {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       SELECT $1,$2,$3,$4,$5,'L'
        WHERE NOT EXISTS (SELECT 1 FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$4)`,
      TENANT,
      CO,
      LC,
      ac,
      `GST ${ac}`,
    );
  }

  /**
   * One GROUP_MAST per item, so each can carry its own `PURC_AC`.
   *
   * `PURC_AC` is the Rojmel contra account — `rojmel.ts` verified it as the item group's `PURC_AC` on 25 of 25
   * real METAL rows — and it is master data, so it is absent from the bundle. It is derived where the desktop's
   * own Rojmel rows reveal it: on a metal row `LD_CODE` holds that account, and a slot-like code is how such a
   * row is recognised, because on non-metal rows `LD_CODE` is the party instead.
   *
   * In this dataset only `999` and `ORG` expose it that way. For the rest the slot-1 account of the book the
   * item appears in is used, and the choice is LOGGED — so a Rojmel difference on those items is attributable
   * to this fallback rather than mistaken for an application defect.
   */
  const slotCodes = new Set(spec.books.flatMap((b) => b.slots.map((s) => s.code)));
  const ldByItem = new Map();
  const bookByItem = new Map();
  for (const c of bundle.cases ?? []) {
    if (!txt(c.caseId).startsWith('purc')) continue;
    const book = txt(c.voucher?.book);
    for (const l of asDicts(c.tables.PR_DETL)) {
      const it = txt(l.IT_CODE);
      if (!it) continue;
      const seen = bookByItem.get(it) ?? new Map();
      seen.set(book, (seen.get(book) ?? 0) + 1);
      bookByItem.set(it, seen);
    }
    for (const r of asDicts(c.tables.ROJ_MEL_DATA)) {
      const it = txt(r.IT_CODE);
      const ld = txt(r.LD_CODE);
      if (!it || !ld || !slotCodes.has(ld)) continue;
      const seen = ldByItem.get(it) ?? new Map();
      seen.set(ld, (seen.get(ld) ?? 0) + 1);
      ldByItem.set(it, seen);
    }
  }
  const commonest = (m) => [...(m ?? new Map())].sort((a, b) => b[1] - a[1])[0]?.[0] ?? '';
  const plans = new Map(
    spec.books.filter((b) => b.vchType !== 'WSALE').map((b) => [b.code, assignSlots(b)]),
  );

  // GROUP_MAST.GR_CODE is varchar(3), so the group code is a sequence rather than a slice of the item code —
  // a slice is not guaranteed to fit or to stay unique.
  let grSeq = 0;
  for (const it of spec.items) {
    grSeq += 1;
    const derived = commonest(ldByItem.get(it.code));
    const itsBook = commonest(bookByItem.get(it.code));
    const purcAc = derived || plans.get(itsBook)?.ordered?.[0] || '';
    console.log(
      `  item ${it.code.padEnd(6)} PURC_AC=${purcAc || '(none)'} ` +
        `${derived ? 'derived from metal Rojmel rows' : `FALLBACK slot1 of book ${itsBook}`}`,
    );
    const gr = String(grSeq).padStart(2, '0');
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
       VALUES ($1,$2,$3,$4,'00004',$5)`,
      TENANT,
      CO,
      gr,
      `GROUP ${it.code}`,
      purcAc,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,$3,$4,$5,$6)`,
      TENANT,
      CO,
      it.code,
      it.name || it.desc || it.code,
      it.itType || 'G',
      gr,
    );
  }

  /**
   * The book's DISPLAY name, taken verbatim from the desktop's own hidden-book rows.
   *
   * `PR_DETL.BOOK_NAME` and `AC_DATA.BOOK_NAME` both hold the MAIN_BOOK ('PURCHASE'), not the book's name —
   * seeding the display name from them made every case differ on `TEMP_BOOK_DATA.BOOK_NAME` (51 differences,
   * exactly one per case) for a reason that had nothing to do with the application.
   *
   * NOT trimmed: book 038 is 'Old Silver Purchase ' with a trailing space in the real data, and trimming it
   * would trade one artefact for another.
   */
  const displayName = new Map();
  for (const c of bundle.cases ?? []) {
    const b = txt(c.voucher?.book);
    for (const r of asDicts(c.tables.TEMP_BOOK_DATA)) {
      if (r.BOOK_NAME != null && String(r.BOOK_NAME) !== '' && !displayName.has(b)) {
        displayName.set(b, String(r.BOOK_NAME));
      }
    }
  }

  const slotPlan = new Map();
  /**
   * Only the books this replay actually posts to.
   *
   * The derived spec now covers all six families, so iterating every book made this seeder create book 027 — a
   * SALE book — as a purchase book with `BOOK_TBL_NAME 'PR_DATA'`. The sale replay then added `SL_DATA` for the
   * same book and the run failed with "book 027 has conflicting BOOK_TBL_NAME values". Each replay seeds its own
   * books; sharing a tenant does not mean sharing a book definition.
   */
  const purchaseBooks = new Set(
    (bundle.cases ?? [])
      .filter((c) => txt(c.caseId).startsWith('purc'))
      .map((c) => txt(c.voucher?.book)),
  );
  for (const b of spec.books) {
    if (!purchaseBooks.has(b.code)) continue;
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
          "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,$4,$5,$6,'PURCHASE','I','Y','PR_DATA')`,
      TENANT,
      CO,
      LC,
      b.code,
      displayName.get(b.code) ?? b.name ?? 'PURCHASE',
      b.vchType || 'FGPR',
    );
    const plan = plans.get(b.code) ?? assignSlots(b);
    slotPlan.set(b.code, plan);
    let sr = 0;
    for (const ac of plan.ordered) {
      sr += 1;
      await exec(
        `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
         VALUES ($1,$2,$3,$4,$5,$6,$7,'PURCHASE','I')`,
        TENANT,
        CO,
        LC,
        b.code,
        sr,
        ac,
        displayName.get(b.code) ?? b.name ?? 'PURCHASE',
      );
    }
  }
  return slotPlan;
}

/** PR_DATA + PR_DETL -> createPurchase(input, lines). `plan` supplies the book's derived slot accounts. */
function mapCase(c, plan) {
  const header = asDicts(c.tables.PR_DATA)[0];
  const lines = asDicts(c.tables.PR_DETL);
  if (!header) return { skip: 'no PR_DATA header' };
  if (!lines.length) return { skip: 'no PR_DETL lines' };

  const taxPct = num(header.TAX_PRC);
  const input = {
    scope: { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: txt(header.CO_BOOK) },
    mainUser: txt(header.MAIN_USER) || undefined,
    acCode: txt(header.AC_CODE),
    acName: txt(header.AC_NAME) || undefined,
    billNo: txt(header.BILL_NO) || undefined,
    vchDate: header.VCH_DATE ? new Date(header.VCH_DATE) : undefined,
    taxCode: txt(header.TAX_CODE) || undefined,
    taxRatePct: taxPct,
    // AC_GST_TYPE 'L' is local; anything else is treated as inter-state. The module re-checks this against
    // the persisted AC_MAST value and never trusts the input, so a wrong guess here cannot force a wrong split.
    interState: txt(header.AC_GST_TYPE) !== 'L' && txt(header.AC_GST_TYPE) !== '',
    rateUnfix: txt(header.RATE_UNFIX) === 'Y',
    cashAmt: num(header.CASH_AMT) || undefined,
    chequeAmt: num(header.CHQ_AMT) || undefined,
    cardAmt: num(header.CARD_AMT) || undefined,
    kasar: num(header.KASAR_AMT) || undefined,
    discountAmount: num(header.DISC_AMT) || undefined,
    /**
     * Settlement accounts come from the book's derived slots rather than the module's 'CASH'/'BANK' defaults,
     * which do not exist in this seeded world. Slot 2 is the settlement account by the same role-based
     * derivation used for the slot ordering, and the desktop confirms it: on the two cheque-settled book-041
     * cases the credit leg is 001008, which is exactly what slot 2 resolved to.
     */
    cashAc: plan?.ordered?.[1] || undefined,
    /**
     * Only for a non-cash tender. Passing it unconditionally wrote `BANK_AC` on 49 cash purchases where the
     * desktop leaves it blank — the replay's artefact, not the application's.
     */
    bankAc:
      num(header.CHQ_AMT) || num(header.CARD_AMT) ? plan?.ordered?.[1] || undefined : undefined,
  };

  const mapped = lines.map((l) => {
    const tag = txt(l.TAG_NO);
    return {
      itCode: txt(l.IT_CODE),
      ...(tag && tag !== 'N' ? { tagNo: tag } : {}),
      pcs: num(l.ITM_PCS),
      grossWt: num(l.ITM_GWT),
      netWt: num(l.ITM_NWT),
      touch: num(l.ITM_TOUCH),
      ghtWt: num(l.ITM_GHT_WT),
      westPct: num(l.ITM_WEST_PRC),
      // The desktop's stored fine weight is fed back rather than recomputed: it is an input to the money
      // columns, and recomputing it here would test this script's arithmetic instead of the application's.
      fineWt: num(l.ITM_FINE),
      rate: num(l.ITM_RATE),
      metalAmount: num(l.ITM_AMT) || undefined,
      labourAmount: num(l.LBR_AMT) || undefined,
      otherAmount: num(l.OTH_AMT) || undefined,
      metal: txt(l.IT_TYPE) === 'S' ? 'S' : 'G',
      /**
       * Four fields the mapper was omitting, which made the web look worse than it is.
       *
       * `rateType`, `withStock`, `prCode` and `itDesc` all exist as `PurchaseLineInput` fields, so their absence
       * from the comparison was this script's gap, not the application's — 312 differences that would have been
       * "fixed" by changing the web to invent values it was never given. Checked before changing anything.
       */
      rateType: txt(l.RATE_TYPE) || undefined,
      withStock: txt(l.WITH_STOCK) || undefined,
      prCode: txt(l.PR_CODE) || undefined,
      itDesc: txt(l.IT_DESC) || undefined,
    };
  });
  return { input, lines: mapped };
}

async function main() {
  await wipe();
  const slotPlan = await seed();
  console.log(`tenant ${TENANT}  company ${CO}/${LC}/${YEAR}`);
  for (const [book, plan] of slotPlan) console.log(`  book ${book} slots: ${plan.why}`);

  const cases = (bundle.cases ?? [])
    .filter((c) => txt(c.caseId).startsWith('purc'))
    .filter((c) => !only || c.caseId === only)
    .slice(0, limit);

  let ok = 0;
  const failures = [];
  /**
   * The case list the extractor must use.
   *
   * The web allocates its own voucher numbers, so a replayed case is not guaranteed to land on the desktop's
   * VCH_NO. Emitting the ACTUAL mapping means the comparison pairs the right two vouchers; assuming they align
   * would silently compare unrelated ones and report differences that are an artefact of the assumption.
   */
  const replayed = [];
  for (const c of cases) {
    const m = mapCase(c, slotPlan.get(txt(c.voucher?.book)));
    if (m.skip) {
      failures.push(`${c.caseId}: ${m.skip}`);
      continue;
    }
    try {
      const r = await createPurchase(runtime, m.input, m.lines);
      const desktop = asDicts(c.tables.PR_DATA)[0];
      const gotNet = Number(r?.totals?.net ?? 0);
      const wantNet = num(desktop.NET_AMT);
      const flag = Math.abs(gotNet - wantNet) < 0.005 ? 'net=match' : `net=${gotNet} vs ${wantNet}`;
      console.log(`  REPLAYED ${c.caseId} -> vchNo=${r.vchNo} ${flag}`);
      replayed.push({
        caseId: c.caseId,
        book: txt(c.voucher?.book),
        vchNo: String(r.vchNo).padStart(5, '0'),
        desktopVchNo: txt(c.voucher?.vchNo),
      });
      ok += 1;
    } catch (e) {
      failures.push(`${c.caseId}: ${e?.message ?? e}`);
    }
  }

  console.log(`\nreplayed ${ok} of ${cases.length} purchase case(s)`);
  if (failures.length) {
    console.log('not replayed:');
    for (const f of failures.slice(0, 20)) console.log(`  ${f}`);
    if (failures.length > 20) console.log(`  … ${failures.length - 20} more`);
  }
  const drift = replayed.filter((r) => r.vchNo !== r.desktopVchNo);
  if (drift.length) {
    console.log(
      `\n${drift.length} case(s) landed on a different voucher number than the desktop; the emitted case list ` +
        'carries the web number so the comparison still pairs correctly',
    );
    for (const r of drift.slice(0, 5))
      console.log(`  ${r.caseId}: desktop ${r.desktopVchNo} -> web ${r.vchNo}`);
  }
  const listPath = resolve(REPO, 'project-memory/parity/PARITY-REPLAY-CASES.json');
  writeFileSync(listPath, `${JSON.stringify(replayed, null, 2)}\n`);
  console.log(`\ncase list -> ${listPath.replace(`${REPO}/`, '')}`);
  console.log(
    `next: PARITY_TENANT=${TENANT} PARITY_COMPANY=${CO} ` +
      `PARITY_CASES="$(cat ../project-memory/parity/PARITY-REPLAY-CASES.json)" ` +
      'node apps/api/integration/parity-extract-pg.mjs   then   pnpm parity:measure',
  );
  await owner.$disconnect();
  await runtime.$disconnect();
  if (!ok) process.exit(1);
}

main().catch(async (e) => {
  console.error('REPLAY_FAIL', e?.message ?? e);
  await owner.$disconnect().catch(() => {});
  await runtime.$disconnect().catch(() => {});
  process.exit(1);
});
