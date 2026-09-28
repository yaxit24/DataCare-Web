#!/usr/bin/env node
/**
 * Replay the retained desktop WHOLESALE-SALE / rate-cut vouchers (book 034) through the web.
 *
 * The 15 cases the bundle labels `wsale` are book 034 `WH SALES`, `VCH_TYPE` `WSALE`, and their write set is the
 * rate-cut tables: `RATE_CUT_DATA` header, `RATE_CUT_ISU` lines, plus `AC_DATA`, `MAIN_STOCK`, `ROJ_MEL_DATA`
 * and `TEMP_BOOK_DATA`. `RATE_CUT_REC` / `RATE_CUT_ISU_REC` appear on only a few.
 *
 * They matter out of proportion to their number. The gap analysis measured rate cutting as the least correct
 * family in the web — `RATE_CUT_DATA` 32 divergent columns, `RATE_CUT_ISU` 26 — and fixing a metal rate against
 * an outstanding balance is core jewellery trade, not an edge case.
 *
 * They are also why the parity ceiling cannot yet be re-recorded: a purchase-only run covers 51 of the 66 cases,
 * and the ratchet correctly refuses a reduced case set, because a smaller difference count obtained by comparing
 * fewer cases is not progress.
 *
 * SHARES THE PURCHASE REPLAY'S DERIVATION, AND ITS LIMITS
 * =====================================================
 * Masters come from `PARITY-REPLAY-SEED.json`; the book's account slots are derived from the ledger legs the
 * desktop actually posted; `CO_SET` / `CO_SET_NEW` are the values read from the real database. Inputs are
 * reconstructed from persisted rows, so a column the desktop COMPUTED and stored, fed back as an input, matches
 * by construction. The informative columns are the derived ones: the ledger legs, the stock movement, the Rojmel
 * projection and its `LEDR_KEY`.
 *
 * USAGE
 *   MIGRATE_DATABASE_URL=... DATABASE_URL=... node apps/api/integration/parity-replay-wsale.mjs
 *   ... --case wsale-034-00001
 */

import { readFileSync, writeFileSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { postRateCut } from '../dist/modules/sales/rateCut.js';

const HERE = dirname(fileURLToPath(import.meta.url));
const WEB = resolve(HERE, '../../..');
const REPO = resolve(WEB, '..');

const TENANT = process.env.PARITY_REPLAY_TENANT || 'parity-wsale';
const argv = process.argv.slice(2);
const only = argv.includes('--case') ? argv[argv.indexOf('--case') + 1] : '';
/**
 * `--no-wipe` lets this run into a tenant the purchase replay already seeded, so ONE extract covers all 66
 * cases. Without it the two families land in separate tenants and the comparison can only ever see a reduced
 * case set — which the ratchet rightly refuses. The master inserts below are guarded accordingly, because the
 * two books share accounts (00001, 00008, 00057).
 */
const keepExisting = argv.includes('--no-wipe');

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
const BOOK = '034';

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

const wsaleCases = (bundle.cases ?? []).filter((c) => txt(c.caseId).startsWith('wsale'));

/** The book's display name, verbatim from the desktop's own hidden-book rows (never trimmed). */
function displayName() {
  for (const c of wsaleCases) {
    for (const r of asDicts(c.tables.TEMP_BOOK_DATA)) {
      if (r.BOOK_NAME != null && String(r.BOOK_NAME) !== '') return String(r.BOOK_NAME);
    }
  }
  return 'WH SALES';
}

/**
 * Assign the BOOK_DETL slot numbers `rateCut.ts` resolves: `goldAc:1, cashAc:3, kasarAc:4, lbrAc:6, othAc:11`.
 *
 * Two are assigned from evidence in the desktop's own legs:
 *
 *   goldAc  the account carrying the METAL leg — `IT_TYPE 'G'` with DR=CR=0 and a non-zero `FINE_WT`, which is
 *           the split-leg structure this module documents. Only `00098` matches, on every case.
 *   cashAc  the only account posted in BOTH directions across the set (`00001`), which is what a cash account
 *           does.
 *
 * The remaining three have no role evidence in the bundle: `kasar`, `labour` and `other` never carry a
 * distinguishing signature on these 15 vouchers. They are filled from the leftover accounts in a fixed order
 * and LOGGED as unverified, so a resulting ledger difference is attributable to this assignment rather than
 * mistaken for an application defect. The purchase replay's slot derivation was validated exactly this way.
 */
function assignSlots(book) {
  const codes = book.slots.map((s) => s.code);
  const gold = '00098';
  const cash = '00001';
  const rest = codes.filter((c) => c !== gold && c !== cash);
  const bySr = new Map([
    [1, codes.includes(gold) ? gold : codes[0]],
    [3, codes.includes(cash) ? cash : codes[1]],
    [4, rest[0]],
    [6, rest[1]],
    [11, rest[2]],
  ]);
  return {
    bySr: new Map([...bySr].filter(([, v]) => Boolean(v))),
    evidenced: [1, 3],
    unverified: [4, 6, 11],
  };
}

async function seed() {
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","SL_AMT_TYPE","TAX_ROF","ALL_ROF_REMOVE","RATE_PAR","ITM_RATE_ROF")
     SELECT $1,$2,'N','2','N','2','N','N','2'
      WHERE NOT EXISTS (SELECT 1 FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"=$2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","TOT_AMT_ROF","PR_RATE_ROF")
     SELECT $1,$2,0,2
      WHERE NOT EXISTS (SELECT 1 FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"=$2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME")
     SELECT $1,$2,'Parity Replay Co'
      WHERE NOT EXISTS (SELECT 1 FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME")
     SELECT $1,$2,$3,'Main'
      WHERE NOT EXISTS (SELECT 1 FROM "LOCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3)`,
    TENANT,
    CO,
    LC,
  );
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
     SELECT $1,$2,$3,'2024-04-01','2025-03-31'
      WHERE NOT EXISTS (SELECT 1 FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_YEAR"=$3)`,
    TENANT,
    CO,
    YEAR,
  );

  for (const a of spec.accounts) {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       SELECT $1,$2,$3,$4,$5,$6
        WHERE NOT EXISTS (SELECT 1 FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$4)`,
      TENANT,
      CO,
      LC,
      a.code,
      a.name || `ACCOUNT ${a.code}`,
      a.gstType || 'L',
    );
  }

  // Items on these vouchers are not in the purchase spec (DHOG and friends), so they are collected from the
  // rate-cut lines themselves.
  const items = new Map();
  for (const c of wsaleCases) {
    for (const l of asDicts(c.tables.RATE_CUT_ISU)) {
      const it = txt(l.IT_CODE);
      if (it && !items.has(it)) {
        items.set(it, { code: it, desc: txt(l.IT_DESC) || it, itType: txt(l.IT_TYPE) || 'G' });
      }
    }
  }
  let gr = 0;
  for (const it of items.values()) {
    gr += 1;
    const code = String(gr).padStart(2, '0');
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
       SELECT $1,$2,$3,$4,$5,$5
        WHERE NOT EXISTS (SELECT 1 FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "GR_CODE"=$3)`,
      TENANT,
      CO,
      code,
      `GROUP ${it.code}`,
      '00098',
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       SELECT $1,$2,$3,$4,$5,$6
        WHERE NOT EXISTS (SELECT 1 FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3)`,
      TENANT,
      CO,
      it.code,
      it.desc,
      it.itType,
      code,
    );
  }
  console.log(`  items ${[...items.keys()].join(', ')}`);

  const book = spec.books.find((b) => b.code === BOOK);
  const plan = assignSlots(book);
  const name = displayName();
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
        "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,$5,'WSALE','WH SALES','O','Y','RATE_CUT_DATA')`,
    TENANT,
    CO,
    LC,
    BOOK,
    name,
  );
  for (const [sr, ac] of plan.bySr) {
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,$4,$5,$6,$7,'WH SALES','O')`,
      TENANT,
      CO,
      LC,
      BOOK,
      sr,
      ac,
      name,
    );
  }
  const shown = [...plan.bySr].map(
    ([sr, ac]) => `${sr}=${ac}${plan.unverified.includes(sr) ? '?' : ''}`,
  );
  console.log(
    `  book ${BOOK} "${name}" slots: ${shown.join(' ')}   (? = role not evidenced in the bundle)`,
  );
  return plan;
}

/** RATE_CUT_DATA + RATE_CUT_ISU -> postRateCut input. */
function mapCase(c, plan) {
  const header = asDicts(c.tables.RATE_CUT_DATA)[0];
  const lines = asDicts(c.tables.RATE_CUT_ISU);
  if (!header) return { skip: 'no RATE_CUT_DATA header' };
  if (!lines.length) return { skip: 'no RATE_CUT_ISU lines' };
  return {
    input: {
      scope: { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK },
      vchDate: header.VCH_DATE ? new Date(header.VCH_DATE) : undefined,
      acCode: txt(header.AC_CODE),
      acName: txt(header.AC_NAME) || undefined,
      itType: txt(header.IT_TYPE) === 'S' ? 'S' : 'G',
      /**
       * Conversion and settlement as the desktop recorded them, not left to the engine.
       *
       * `RateCutInput` documents that "the engine derives whatever is left at zero", so omitting these made the web
       * compute a metal settlement of its own — `CR_FINE` 54.483 where the desktop holds 0 on 14 of 15 headers.
       * `CONV_PRC` is 99.5 on all 15, a company conversion purity the operator does not retype per voucher.
       *
       * Passing the persisted values is the same discipline as everywhere else in this replay: a column the
       * desktop COMPUTED and stored is fed back as an input, and it proves nothing by matching. What it does is
       * stop the engine inventing a different answer and masking the columns that are genuinely derived.
       */
      // The voucher-level fine rate, which this family fixes at the header.
      fineRate: num(header.FINE_RATE) || undefined,
      convPct: num(header.CONV_PRC) || undefined,
      convRate: num(header.CONV_RATE) || undefined,
      settleDrFine: num(header.DR_FINE),
      settleCrFine: num(header.CR_FINE),
      settleDrAmt: num(header.DR_AMT),
      settleCrAmt: num(header.CR_AMT),
      hdVchNo: txt(header.HD_VCH_NO) || undefined,
      empCode: txt(header.EMP_CODE) || undefined,
      mobile: txt(header.MOBILE) || undefined,
      lines: lines.map((l) => ({
        itCode: txt(l.IT_CODE),
        itemName: txt(l.ITM_REMARK) || undefined,
        prCode: txt(l.PR_CODE) || undefined,
        ...(txt(l.TAG_NO) && txt(l.TAG_NO) !== 'N' ? { tagNo: txt(l.TAG_NO) } : {}),
        designNo: txt(l.DESIGN_NO) || undefined,
        pcs: num(l.ITM_PCS),
        grossWt: num(l.ITM_GWT),
        othWt: num(l.ITM_OTH_WT),
        netWt: num(l.ITM_NWT),
        touch: num(l.ITM_TOUCH),
        westPct: num(l.ITM_WEST_PRC),
        rate: num(l.ITM_RATE),
        lbrAmt: num(l.LBR_AMT) || undefined,
        othAmt: num(l.OTH_AMT) || undefined,
        itType: txt(l.IT_TYPE) === 'S' ? 'S' : 'G',
      })),
      pay: {
        cashAmt: num(header.SL_CASH_AMT) || undefined,
        chequeAmt: num(header.SL_CHQ_AMT) || undefined,
        cardAmt: num(header.SL_CARD_AMT) || undefined,
      },
      // Accounts are left to BOOK_DETL resolution rather than overridden, so the seeded slots are what is
      // actually being tested. An override would hide a wrong slot assignment.
      accounts: undefined,
    },
  };
}

async function main() {
  if (!keepExisting) await wipe();
  else {
    /**
     * Clear only THIS replay's book when sharing a tenant, so a re-run replaces its vouchers instead of appending.
     * Without it a second pass posted book 034 again at voucher 16..30, and the extract then compared whichever
     * numbers the case list happened to name.
     */
    const voucherTables = await owner.$queryRawUnsafe(
      `SELECT table_name FROM information_schema.columns
        WHERE column_name='CO_BOOK' AND table_schema='public'`,
    );
    for (const t of voucherTables) {
      await owner.$executeRawUnsafe(
        `DELETE FROM "${t.table_name}" WHERE tenant_id=$1 AND "CO_BOOK"::text=$2`,
        TENANT,
        BOOK,
      );
    }
  }
  const plan = await seed();
  const cases = wsaleCases.filter((c) => !only || c.caseId === only);
  const replayed = [];
  const failures = [];
  for (const c of cases) {
    const m = mapCase(c, plan);
    if (m.skip) {
      failures.push(`${c.caseId}: ${m.skip}`);
      continue;
    }
    try {
      const r = await postRateCut(runtime, m.input);
      const desktop = asDicts(c.tables.RATE_CUT_DATA)[0];
      const want = num(desktop.SL_NET_AMT);
      const got = Number(r?.totals?.net ?? r?.netAmt ?? 0);
      const flag = Math.abs(got - want) < 0.005 ? 'net=match' : `net=${got} vs ${want}`;
      console.log(`  REPLAYED ${c.caseId} -> vchNo=${r.vchNo} ${flag}`);
      replayed.push({
        caseId: c.caseId,
        book: BOOK,
        vchNo: String(r.vchNo).padStart(5, '0'),
        desktopVchNo: txt(c.voucher?.vchNo),
      });
    } catch (e) {
      failures.push(`${c.caseId}: ${e?.message ?? e}`);
    }
  }
  console.log(`\nreplayed ${replayed.length} of ${cases.length} wholesale case(s)`);
  if (failures.length) {
    console.log('not replayed:');
    for (const f of failures.slice(0, 15)) console.log(`  ${f}`);
  }
  if (replayed.length) {
    const p = resolve(REPO, 'project-memory/parity/PARITY-REPLAY-CASES-WSALE.json');
    writeFileSync(p, `${JSON.stringify(replayed, null, 2)}\n`);
    console.log(`\ncase list -> ${p.replace(`${REPO}/`, '')}`);
  }
  await owner.$disconnect();
  await runtime.$disconnect();
  if (!replayed.length) process.exit(1);
}

main().catch(async (e) => {
  console.error('REPLAY_FAIL', e?.message ?? e);
  await owner.$disconnect().catch(() => {});
  await runtime.$disconnect().catch(() => {});
  process.exit(1);
});
