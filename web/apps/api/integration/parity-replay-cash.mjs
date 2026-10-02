#!/usr/bin/env node
/**
 * Replay the retained CASH RECEIPT, CASH PAYMENT and SCHEME vouchers, raising measured family coverage from 3 to 6.
 *
 * These three cases are the last families available without a new desktop capture:
 *
 *     cashrec-001-00001   book 001 `CREC`  CASH REC     -> postReceipt        CASH_DATA + AC_DATA + ROJ_MEL_DATA
 *     cashpay-002-00029   book 002 `CPAY`  CASH PAY     -> postPaymentLines   nine CASH_DATA lines, eighteen legs
 *     scheme-074-00001    book 074 `MBENT` MEMB ENTRY   -> schemeInstallment  AD_DATA + AD_OS
 *
 * Worth noting for anyone reading the result: `finance.ts` was WRITTEN against these two cash vouchers. Its
 * `ReceiptInput` documents "Real voucher 002/00029 has nine CASH_DATA lines and eighteen legs keyed 105/106
 * through 905/906", and the receipt path documents the 60,000 + 771 kasar shape of `cashrec-001-00001`. So these
 * two are the friendliest possible cases, and a difference here is more significant than a difference elsewhere,
 * not less.
 *
 * Runs into the tenant the other replays seeded (`--no-wipe` semantics are implicit: this script never wipes),
 * so one extract covers every family and the ratchet sees an expanded rather than a swapped case set.
 *
 * USAGE
 *   MIGRATE_DATABASE_URL=... DATABASE_URL=... PARITY_REPLAY_TENANT=parity-purchase \
 *   node apps/api/integration/parity-replay-cash.mjs
 */

import { readFileSync, writeFileSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { postReceipt, postPaymentLines } from '../dist/modules/finance/finance.js';
import { schemeInstallment } from '../dist/modules/membership/scheme.js';

const HERE = dirname(fileURLToPath(import.meta.url));
const WEB = resolve(HERE, '../../..');
const REPO = resolve(WEB, '..');

const TENANT = process.env.PARITY_REPLAY_TENANT || 'parity-purchase';
const url = process.env.MIGRATE_DATABASE_URL;
const runtimeUrl = process.env.DATABASE_URL;
if (!url || !runtimeUrl) {
  console.error('REPLAY_SKIP need MIGRATE_DATABASE_URL and DATABASE_URL');
  process.exit(1);
}
const owner = new PrismaClient({ datasources: { db: { url } } });
const runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
const exec = (sql, ...p) => withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

const bundle = JSON.parse(
  readFileSync(resolve(REPO, 'project-memory/parity/bundles/desktop-combined.json'), 'utf8'),
);
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';

const asDicts = (t) => {
  if (!t?.columns || !t?.rows) return [];
  const names = t.columns.map((c) => c.name);
  return t.rows.map((r) => Object.fromEntries(names.map((n, i) => [n, r[i]])));
};
const txt = (v) => (v == null ? '' : String(v).trim());
const num = (v) => (v == null || v === '' ? 0 : Number(v));
const caseOf = (id) => (bundle.cases ?? []).find((c) => c.caseId === id);

/** Seed only what these three books need, guarded so it composes with the other replays' masters. */
async function seed(cases) {
  const accounts = new Map();
  const books = new Map();
  for (const c of cases) {
    if (!c) continue;
    const book = txt(c.voucher?.book);
    for (const r of asDicts(c.tables.AC_DATA)) {
      const code = txt(r.AC_CODE);
      if (code) accounts.set(code, txt(r.LDR_NAME));
      if (book && !books.has(book)) {
        books.set(book, { name: txt(r.BOOK_NAME), vchType: txt(r.VCH_TYPE), inout: '' });
      }
    }
    for (const t of ['CASH_DATA', 'AD_OS']) {
      for (const r of asDicts(c.tables[t])) {
        const b = books.get(book);
        if (b) {
          b.name = b.name || txt(r.BOOK_NAME);
          b.vchType = b.vchType || txt(r.VCH_TYPE);
          b.inout = b.inout || txt(r.INOUT_TYPE);
        }
        for (const k of ['AC_CODE', 'REC_AC', 'PAY_AC']) {
          const code = txt(r[k]);
          if (code) accounts.set(code, accounts.get(code) ?? '');
        }
      }
    }
  }

  for (const [code, name] of accounts) {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       SELECT $1,$2,$3,$4,$5,'L'
        WHERE NOT EXISTS (SELECT 1 FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$4)`,
      TENANT,
      CO,
      LC,
      code,
      name || `ACCOUNT ${code}`,
    );
  }

  for (const [code, b] of books) {
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
          "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       SELECT $1,$2,$3,$4,$5,$6,$5,$7,'Y','CASH_DATA'
        WHERE NOT EXISTS (SELECT 1 FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$4)`,
      TENANT,
      CO,
      LC,
      code,
      b.name || 'CASH',
      b.vchType || 'CREC',
      b.inout || 'I',
    );
    // Slot 1 and 3 are the cash/settlement accounts these books post against; 00001 is the cash ledger on every
    // one of the three vouchers' legs.
    for (const [sr, ac] of [
      [1, '00001'],
      [3, '00001'],
    ]) {
      await exec(
        `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
         SELECT $1,$2,$3,$4,$5,$6,$7,$7,$8
          WHERE NOT EXISTS (SELECT 1 FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$4 AND "SR_NO"=$5)`,
        TENANT,
        CO,
        LC,
        code,
        sr,
        ac,
        b.name || 'CASH',
        b.inout || 'I',
      );
    }
  }
  /**
   * Scheme masters for `scheme-074-00001`.
   *
   * `AD_MAST.SCHM_AC` is the scheme-liability account the installment credits. The desktop credits `000858`,
   * whose name is "03 - ALAUDIN MAKASUDBHAI KADARI" — a PER-MEMBER account, while the web's `AD_MAST.SCHM_AC` is
   * per-SCHEME. Seeding 000858 makes this one case comparable, but it does not generalise, and the divergence is
   * recorded rather than papered over: with two members on scheme 03 the web would credit both to one account.
   */
  const sch = asDicts((caseOf('scheme-074-00001') ?? { tables: {} }).tables.AD_DATA)[0];
  if (sch) {
    const liab = (
      asDicts(caseOf('scheme-074-00001').tables.AC_DATA).find(
        (l) => num(l.CR_AMT) > 0 && txt(l.AC_CODE) !== '00001',
      ) ?? {}
    ).AC_CODE;
    await exec(
      `INSERT INTO "AD_MAST"(tenant_id,"CO_CODE","SCHM_CODE","SCHM_NAME","SCHM_AC")
       SELECT $1,$2,$3,$4,$5
        WHERE NOT EXISTS (SELECT 1 FROM "AD_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "SCHM_CODE"=$3)`,
      TENANT,
      CO,
      txt(sch.SCHM_CODE),
      `SCHEME ${txt(sch.SCHM_CODE)}`,
      txt(liab) || '00001',
    );
    /**
     * `AD_MEMB` has NO account column — verified against the live schema. The member is identified by
     * `MEMB_CODE` alone and the liability account comes only from `AD_MAST.SCHM_AC`, which is per-scheme.
     *
     * That is the structural divergence: the desktop's leg credits `000858`, an account whose name is
     * "03 - ALAUDIN MAKASUDBHAI KADARI", i.e. one account per MEMBER. The web cannot express that, so with two
     * members on one scheme it would credit both to the same ledger. Recorded here, not worked around.
     */
    await exec(
      `INSERT INTO "AD_MEMB"(tenant_id,"CO_CODE","LC_CODE","SCHM_CODE","MEMB_CODE","MEMB_NAME","MEMB_AMT")
       SELECT $1,$2,$3,$4,$5,$6,$7
        WHERE NOT EXISTS (SELECT 1 FROM "AD_MEMB" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
                            AND "SCHM_CODE"=$4 AND "MEMB_CODE"=$5)`,
      TENANT,
      CO,
      LC,
      txt(sch.SCHM_CODE),
      txt(sch.MEMB_CODE),
      accounts.get(txt(liab)) || `MEMBER ${txt(sch.MEMB_CODE)}`,
      num(sch.MEMB_AMT),
    );
    console.log(
      `  scheme ${txt(sch.SCHM_CODE)} member ${txt(sch.MEMB_CODE)} liability ${txt(liab)}`,
    );
  }
  console.log(`  seeded ${accounts.size} account(s), books ${[...books.keys()].join(', ')}`);
}

/**
 * The kasar/write-off account, taken from the desktop's own ledger.
 *
 * On a receipt the party is credited the write-off and some expense account is debited it; that debit names the
 * kasar account. On `cashrec-001-00001` it is `00057`. Derived rather than assumed, because a wrong account here
 * would post a real amount to the wrong ledger.
 */
function kasarAcFor(c) {
  const rows = asDicts(c.tables.CASH_DATA);
  const kasar = num(rows[0]?.KASAR_AMT);
  if (!kasar) return '';
  const party = txt(rows[0]?.AC_CODE);
  for (const leg of asDicts(c.tables.AC_DATA)) {
    if (txt(leg.AC_CODE) === party) continue;
    if (Math.abs(num(leg.DR_AMT) - kasar) < 0.005) return txt(leg.AC_CODE);
  }
  return '';
}

const scope = (book) => ({ tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: book });

async function replayCashReceipt(c) {
  const rows = asDicts(c.tables.CASH_DATA);
  const h = rows[0];
  return postReceipt(runtime, {
    scope: scope(txt(c.voucher.book)),
    partyAc: txt(h.AC_CODE),
    partyName: txt(h.AC_NAME) || undefined,
    amount: num(h.REC_AMT),
    mode: 'cash',
    bankAc: txt(h.REC_AC) || '00001',
    kasar: num(h.KASAR_AMT) || undefined,
    // The write-off account is read from the desktop's own legs: the 771 kasar is DEBITED to 00057 on this
    // voucher. The module refuses to guess it, which is why it has to be supplied.
    kasarAc: kasarAcFor(c) || undefined,
    vchDate: h.VCH_DATE ? new Date(h.VCH_DATE) : undefined,
    lineNo: num(h.SR_NO) || 1,
  });
}

async function replayCashPayment(c) {
  const rows = asDicts(c.tables.CASH_DATA);
  // Nine CASH_DATA lines on this voucher, which is why the LINES form is used rather than postPayment.
  return postPaymentLines(runtime, {
    scope: scope(txt(c.voucher.book)),
    vchDate: rows[0]?.VCH_DATE ? new Date(rows[0].VCH_DATE) : undefined,
    lines: rows.map((r) => ({
      partyAc: txt(r.AC_CODE),
      partyName: txt(r.AC_NAME) || undefined,
      amount: num(r.REC_AMT),
      mode: 'cash',
      bankAc: txt(r.PAY_AC) || txt(r.REC_AC) || '00001',
      kasar: num(r.KASAR_AMT) || undefined,
      /**
       * The operator's per-line narration, which the desktop carries onto `CASH_DATA`, `AC_DATA` and the day
       * book — "AMDAVAD" on one line of this voucher, "DIESEL ERTIGA" on another. `ReceiptPaymentLine.itDesc`
       * accepts it and the mapper was not passing it, so every one of those columns compared blank.
       */
      itDesc: txt(r.IT_DESC) || undefined,
      empCode: txt(r.EMP_CODE) || undefined,
    })),
  });
}

async function replayScheme(c) {
  const ad = asDicts(c.tables.AD_DATA)[0];
  return schemeInstallment(runtime, {
    scope: scope(txt(c.voucher.book)),
    schmCode: txt(ad.SCHM_CODE),
    membCode: txt(ad.MEMB_CODE),
    amount: num(ad.MEMB_AMT),
    mode: 'cash',
    bankAc: txt(ad.REC_AC) || '00001',
    empCode: txt(ad.EMP_CODE) || undefined,
    monthCode: txt(ad.IT_DESC) || undefined,
    vchDate: ad.VCH_DATE ? new Date(ad.VCH_DATE) : undefined,
  });
}

const PLAN = [
  ['cashrec-001-00001', replayCashReceipt],
  ['cashpay-002-00029', replayCashPayment],
  ['scheme-074-00001', replayScheme],
];

async function main() {
  const cases = PLAN.map(([id]) => caseOf(id));
  const missing = PLAN.filter(([id]) => !caseOf(id)).map(([id]) => id);
  if (missing.length) console.log(`  not in the bundle: ${missing.join(', ')}`);
  /**
   * Clear only THIS script's books before replaying, so it is re-runnable without wiping the tenant the other
   * replays seeded. Re-running without this hit a unique-constraint failure on the second pass, because the
   * voucher from the first was still there.
   */
  const ownBooks = [...new Set(cases.filter(Boolean).map((c) => txt(c.voucher.book)))];
  const voucherTables = await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='CO_BOOK' AND table_schema='public'`,
  );
  for (const t of voucherTables) {
    await owner.$executeRawUnsafe(
      `DELETE FROM "${t.table_name}" WHERE tenant_id=$1 AND "CO_BOOK"::text = ANY($2::text[])`,
      TENANT,
      ownBooks,
    );
  }
  console.log(`  cleared books ${ownBooks.join(', ')} for a repeatable run`);
  await seed(cases);

  const replayed = [];
  const failures = [];
  for (const [id, fn] of PLAN) {
    const c = caseOf(id);
    if (!c) continue;
    try {
      /**
       * Post on the DESKTOP's voucher number, not the next free one.
       *
       * `LEDR_KEY` embeds `VCH_NO`, so a replay that lands on 00001 where the desktop used 00029 differs on every
       * ledger key in the voucher — 40 differences on `cashpay-002-00029` alone that say nothing about the
       * application. Voucher numbers come from `max(VCH_NO) + 1` across the book's tables, so a throwaway row one
       * below the target moves the sequence; it is removed immediately after, and being at a different VCH_NO it
       * is never part of the comparison.
       */
      const want = Number(txt(c.voucher.vchNo));
      const placeholder = want > 1;
      if (placeholder) {
        await exec(
          `INSERT INTO "CASH_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO")
           VALUES ($1,$2,$3,$4,$5,$6,1)`,
          TENANT,
          CO,
          LC,
          YEAR,
          txt(c.voucher.book),
          String(want - 1).padStart(5, '0'),
        );
      }
      const r = await fn(c);
      if (placeholder) {
        await exec(
          `DELETE FROM "CASH_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          TENANT,
          txt(c.voucher.book),
          String(want - 1).padStart(5, '0'),
        );
      }
      const vch = String(r?.vchNo ?? r?.voucherNo ?? '').padStart(5, '0');
      console.log(`  REPLAYED ${id} -> vchNo=${vch}`);
      replayed.push({
        caseId: id,
        book: txt(c.voucher.book),
        vchNo: vch,
        desktopVchNo: txt(c.voucher.vchNo),
      });
    } catch (e) {
      failures.push(`${id}: ${e?.message ?? e}`);
    }
  }
  console.log(`\nreplayed ${replayed.length} of ${PLAN.length} case(s)`);
  for (const f of failures) console.log(`  not replayed: ${f}`);
  if (replayed.length) {
    const p = resolve(REPO, 'project-memory/parity/PARITY-REPLAY-CASES-CASH.json');
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
