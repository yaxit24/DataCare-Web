#!/usr/bin/env node
/**
 * Derive the master data a parity replay needs, from the retained desktop bundle.
 *
 * WHY THIS IS DERIVED RATHER THAN WRITTEN
 * ======================================
 * To replay a real voucher through the web you first need the world it was entered into: the party, the items,
 * the book and the accounts its slots point at. That world lives in master tables which are NOT voucher-scoped
 * and are therefore NOT in the bundle — the extractors only capture tables carrying `CO_BOOK` and `VCH_NO`.
 *
 * Inventing it defeats the exercise. A book whose slots point at accounts the desktop did not use produces
 * ledger legs that differ for a reason that has nothing to do with the application.
 *
 * But most of it does not need inventing, because the desktop's own rows name it:
 *
 *   party            PR_DATA.AC_CODE + AC_NAME
 *   items            PR_DETL.IT_CODE + IT_DESC + IT_TYPE
 *   book identity    CO_BOOK + BOOK_NAME + VCH_TYPE from the detail rows
 *   ACCOUNT SLOTS    the AC_CODEs in AC_DATA that are not the party — the legs the desktop actually posted
 *   tax code         PR_DATA.TAX_CODE
 *   company scope    CO_CODE / LC_CODE / CO_YEAR
 *
 * The account-slot derivation is the important one: it is what makes an offline replay possible at all, and it
 * is evidence rather than assumption, because it is read from what the desktop did.
 *
 * WHAT CANNOT BE DERIVED
 * =====================
 * `CO_SET` / `CO_SET_NEW` are company settings, not voucher data, and nothing in the bundle implies them. They
 * decide rounding precision and labour representation, so guessing them would silently move money. This tool
 * REPORTS them as required-but-absent rather than filling them; the values already retained in
 * `parity-replay-sale.mjs` were read from the real database for the same company and are the right source.
 *
 * USAGE
 *   node apps/api/integration/parity-seed-derive.mjs [bundle.json] [--json out.json]
 */

import { readFileSync, writeFileSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve, relative } from 'node:path';

const HERE = dirname(fileURLToPath(import.meta.url));
// `../../..` is the web workspace root; project-memory is its SIBLING. Same convention as
// parity-extract-pg.mjs, which resolves `resolve(WEB, '..', 'project-memory', ...)`.
const WEB = resolve(HERE, '../../..');
const REPO = resolve(WEB, '..');
const DEFAULT_BUNDLE = resolve(REPO, 'project-memory', 'parity', 'bundles', 'desktop-latest.json');

const argv = process.argv.slice(2);
const jsonIndex = argv.indexOf('--json');
const jsonOut = jsonIndex >= 0 ? (argv[jsonIndex + 1] ?? '') : '';
// A flag's VALUE does not start with '--', so it has to be excluded explicitly or it is taken as the bundle
// path. The first version of this did exactly that and tried to read the output file as input.
const positional = argv.filter(
  (a, i) => !a.startsWith('--') && !(jsonIndex >= 0 && i === jsonIndex + 1),
);
const bundlePath = resolve(process.cwd(), positional[0] ?? DEFAULT_BUNDLE);

const bundle = JSON.parse(readFileSync(bundlePath, 'utf8'));
if (bundle?.kind !== 'datacare.parity-bundle/1.0' || bundle.side !== 'desktop') {
  console.error(`SEED_DERIVE_FAILED not a desktop parity bundle: ${relative(REPO, bundlePath)}`);
  process.exit(1);
}

/** Bundle tables are columnar: {columns:[{name}], rows:[[...]]}. */
const asDicts = (table) => {
  if (!table?.columns || !table?.rows) return [];
  const names = table.columns.map((c) => c.name);
  return table.rows.map((r) => Object.fromEntries(names.map((n, i) => [n, r[i]])));
};

const txt = (v) => (v == null ? '' : String(v).trim());

const seed = {
  derivedFrom: relative(REPO, bundlePath),
  derivedAt: new Date().toISOString(),
  capturedAt: bundle.capturedAt ?? null,
  companies: new Map(),
  locations: new Set(),
  years: new Set(),
  books: new Map(),
  accounts: new Map(),
  items: new Map(),
  taxCodes: new Set(),
  families: new Map(),
};

const undeliverable = [];
/** item code -> (name -> occurrences), resolved to the most frequent after all cases are read. */
const itemNameVotes = new Map();

for (const c of bundle.cases ?? []) {
  const family = txt(c.caseId).split('-')[0] || 'unknown';
  const fam = seed.families.get(family) ?? { cases: 0, books: new Set(), tables: new Set() };
  fam.cases += 1;
  seed.families.set(family, fam);

  const tables = c.tables ?? {};
  for (const name of Object.keys(tables)) fam.tables.add(name);

  /**
   * Find the voucher's HEADER table.
   *
   * `endsWith('_DATA')` is not enough: `AC_DATA`, `DELETE_DATA`, `ROJ_MEL_DATA`, `TAX_DATA` and
   * `TEMP_BOOK_DATA` all match it, and `AC_DATA` even carries an `AC_CODE`, so a loose match silently
   * succeeded and produced nameless parties and unnamed books. The header is the `*_DATA` whose prefix pairs
   * with the `*_DETL` table (`PR_DATA` ↔ `PR_DETL`); families with no detail table fall back to the first
   * candidate that is not a known sub-ledger.
   */
  const NOT_A_HEADER = new Set([
    'AC_DATA',
    'DELETE_DATA',
    'ROJ_MEL_DATA',
    'TAX_DATA',
    'TEMP_BOOK_DATA',
    'BILL_OS_DATA',
  ]);
  const names = Object.keys(tables);
  const detailName = names.find((t) => t.endsWith('_DETL') && !NOT_A_HEADER.has(t));
  const paired = detailName ? `${detailName.slice(0, -'_DETL'.length)}_DATA` : '';
  const headerName =
    (paired && names.includes(paired) && paired) ||
    names.find((t) => t.endsWith('_DATA') && !NOT_A_HEADER.has(t)) ||
    '';
  const header = headerName ? asDicts(tables[headerName])[0] : null;
  const details = detailName ? asDicts(tables[detailName]) : [];
  const ledger = asDicts(tables.AC_DATA ?? null);
  if (headerName) fam.headerTable = headerName;
  if (detailName) fam.detailTable = detailName;

  if (!header) {
    undeliverable.push(`${c.caseId}: no header table among ${Object.keys(tables).join(', ')}`);
    continue;
  }

  const co = txt(header.CO_CODE);
  const lc = txt(header.LC_CODE);
  const year = txt(header.CO_YEAR);
  const book = txt(header.CO_BOOK);
  if (co) seed.companies.set(co, txt(header.CO_NAME) || seed.companies.get(co) || '');
  if (lc) seed.locations.add(lc);
  if (year) seed.years.add(year);
  fam.books.add(book);

  const party = txt(header.AC_CODE);
  const partyName = txt(header.AC_NAME) || txt(header.LDR_NAME);
  if (party) {
    const prev = seed.accounts.get(party);
    seed.accounts.set(party, {
      code: party,
      name: partyName || prev?.name || '',
      role: 'party',
      gstType: txt(header.AC_GST_TYPE) || prev?.gstType || '',
    });
  }

  const tax = txt(header.TAX_CODE);
  if (tax) seed.taxCodes.add(tax);

  // Book identity comes from the detail rows, which carry the desktop's own VCH_TYPE and BOOK_NAME.
  // Families with no detail table at all — the rate-cut vouchers in book 034 — still have both on their
  // ledger legs, so AC_DATA is the fallback rather than leaving the book unidentified.
  const first = details[0] ?? ledger[0] ?? {};
  if (book) {
    const prev = seed.books.get(book) ?? { code: book, slots: new Map(), cases: 0 };
    prev.cases += 1;
    prev.name = prev.name || txt(first.BOOK_NAME);
    prev.vchType = prev.vchType || txt(first.VCH_TYPE);
    prev.inout = prev.inout || txt(first.INOUT_TYPE);
    prev.entryType = prev.entryType || txt(first.ENTRY_TYPE);
    seed.books.set(book, prev);
  }

  // THE ACCOUNT SLOTS. Every AC_DATA leg that is not the party names an account the book's slots point at.
  for (const leg of ledger) {
    const code = txt(leg.AC_CODE);
    if (!code || code === party) continue;
    const rec = seed.accounts.get(code) ?? { code, name: '', role: 'slot', gstType: '' };
    rec.role = rec.role === 'party' ? 'party' : 'slot';
    rec.name = rec.name || txt(leg.LDR_NAME);
    seed.accounts.set(code, rec);
    const bk = seed.books.get(book);
    if (bk) {
      const seen = bk.slots.get(code) ?? { code, dr: 0, cr: 0, itTypes: new Set() };
      seen.dr += Number(leg.DR_AMT ?? 0) > 0 ? 1 : 0;
      seen.cr += Number(leg.CR_AMT ?? 0) > 0 ? 1 : 0;
      if (txt(leg.IT_TYPE)) seen.itTypes.add(txt(leg.IT_TYPE));
      bk.slots.set(code, seen);
    }
  }

  for (const line of details) {
    const it = txt(line.IT_CODE);
    if (!it) continue;
    const prev = seed.items.get(it);
    seed.items.set(it, {
      code: it,
      desc: txt(line.IT_DESC) || prev?.desc || '',
      itType: txt(line.IT_TYPE) || prev?.itType || '',
      rateType: txt(line.RATE_TYPE) || prev?.rateType || '',
      prCode: txt(line.PR_CODE) || prev?.prCode || '',
      withStock: txt(line.WITH_STOCK) || prev?.withStock || '',
      tagged: prev?.tagged || Boolean(txt(line.TAG_NO) && txt(line.TAG_NO) !== 'N'),
    });
  }

  /**
   * The item's REAL name, taken from the daybook rather than the voucher line.
   *
   * `PR_DETL.IT_DESC` is the description the operator typed on that line — for item `ORG` the captured lines say
   * "NANO CHAIN". `ROJ_MEL_DATA.IT_DESC` carries the item master's own name for the same code: "GOLD ORNAMENTS".
   * Seeding `ITEM_MAST.IT_NAME` from the line description made every replayed daybook row disagree with the
   * desktop on `IT_DESC` — 54 differences that belonged to this seed, not to the application.
   *
   * Measured: `ORG` → GOLD ORNAMENTS (40 rows), `OR925` → 925 SILVER ORNAMENTS (13), `OG` → OLD GOLD (7),
   * `OS` → OLD SILVER (6), `999` → FINE GOLD (5).
   */
  for (const r of asDicts(tables.ROJ_MEL_DATA ?? null)) {
    const it = txt(r.IT_CODE);
    const name = txt(r.IT_DESC);
    if (!it || !name) continue;
    // Count them: one item can appear under more than one description across vouchers, and taking the last one
    // seen picked 'COPPER KADALI' for OG over its 7 rows of 'OLD GOLD'.
    const counts = itemNameVotes.get(it) ?? new Map();
    counts.set(name, (counts.get(name) ?? 0) + 1);
    itemNameVotes.set(it, counts);
  }
}

for (const [code, votes] of itemNameVotes) {
  const name = [...votes].sort((a, b) => b[1] - a[1])[0]?.[0] ?? '';
  const prev = seed.items.get(code);
  seed.items.set(code, {
    code,
    desc: prev?.desc ?? '',
    itType: prev?.itType ?? '',
    rateType: prev?.rateType ?? '',
    prCode: prev?.prCode ?? '',
    withStock: prev?.withStock ?? '',
    tagged: prev?.tagged ?? false,
    name,
  });
}

// ---------------------------------------------------------------------------------------------------
// Report
// ---------------------------------------------------------------------------------------------------
const out = (s = '') => console.log(s);
out(`bundle    ${relative(REPO, bundlePath)}`);
out(`captured  ${seed.capturedAt}`);
out(`cases     ${(bundle.cases ?? []).length}`);
out('');
out('families');
for (const [name, f] of [...seed.families].sort()) {
  out(
    `  ${name.padEnd(8)} ${String(f.cases).padStart(3)} case(s)  books ${[...f.books].sort().join(',')}`,
  );
  out(`           header=${f.headerTable ?? '(none)'} detail=${f.detailTable ?? '(none)'}`);
  out(`           tables ${[...f.tables].sort().join(', ')}`);
}

out('');
out(
  `company scope   CO ${[...seed.companies.keys()].join(',')}  LC ${[...seed.locations].join(',')}  YEAR ${[...seed.years].join(',')}`,
);
out(`tax codes       ${[...seed.taxCodes].sort().join(', ') || '(none)'}`);

out('');
out(`books (${seed.books.size}) — slots derived from the ledger legs the desktop actually posted`);
for (const [code, b] of [...seed.books].sort()) {
  out(
    `  ${code}  ${(b.name || '?').padEnd(14)} vchType=${(b.vchType || '?').padEnd(6)} inout=${b.inout || '?'}  cases=${b.cases}`,
  );
  for (const [ac, s] of [...b.slots].sort()) {
    out(`        slot ${ac}  dr=${s.dr} cr=${s.cr}  itTypes=${[...s.itTypes].join('/') || '-'}`);
  }
}

out('');
out(`accounts (${seed.accounts.size})`);
const parties = [...seed.accounts.values()].filter((a) => a.role === 'party');
const slots = [...seed.accounts.values()].filter((a) => a.role !== 'party');
out(
  `  parties ${parties.length}: ${parties
    .slice(0, 6)
    .map((a) => `${a.code} ${a.name}`)
    .join(' | ')}${parties.length > 6 ? ' | …' : ''}`,
);
out(
  `  slots   ${slots.length}: ${slots
    .map((a) => a.code)
    .sort()
    .join(', ')}`,
);

out('');
out(`items (${seed.items.size})`);
for (const it of [...seed.items.values()]
  .sort((a, b) => a.code.localeCompare(b.code))
  .slice(0, 12)) {
  out(
    `  ${it.code.padEnd(8)} ${(it.desc || '?').padEnd(18)} itType=${it.itType || '-'} rateType=${it.rateType || '-'} withStock=${it.withStock || '-'}${it.tagged ? ' TAGGED' : ''}`,
  );
}
if (seed.items.size > 12) out(`  … ${seed.items.size - 12} more`);

out('');
out('NOT DERIVABLE from a voucher bundle — must come from the real company settings');
out(
  '  CO_SET      labour representation and rounding flags (LBR_TYPE, LBR_ROF, TAX_ROF, RATE_PAR, ITM_RATE_ROF)',
);
out('  CO_SET_NEW  rounding precisions including TOT_AMT_ROF');
out(
  '  These decide how money is rounded and how a labour amount is stored, so a guess moves money silently.',
);
out(
  '  The values retained in parity-replay-sale.mjs were read from the real database for this same company.',
);
if (undeliverable.length) {
  out('');
  out('cases whose shape was not understood');
  for (const u of undeliverable.slice(0, 10)) out(`  ${u}`);
}

if (jsonOut) {
  const plain = {
    derivedFrom: seed.derivedFrom,
    derivedAt: seed.derivedAt,
    capturedAt: seed.capturedAt,
    scope: {
      companies: [...seed.companies.keys()],
      locations: [...seed.locations],
      years: [...seed.years],
    },
    taxCodes: [...seed.taxCodes].sort(),
    books: [...seed.books.values()].map((b) => ({
      code: b.code,
      name: b.name ?? '',
      vchType: b.vchType ?? '',
      inout: b.inout ?? '',
      entryType: b.entryType ?? '',
      cases: b.cases,
      slots: [...b.slots.values()].map((s) => ({
        code: s.code,
        drLegs: s.dr,
        crLegs: s.cr,
        itTypes: [...s.itTypes],
      })),
    })),
    accounts: [...seed.accounts.values()],
    items: [...seed.items.values()].map((i) => ({ ...i })),
    families: [...seed.families].map(([name, f]) => ({
      name,
      cases: f.cases,
      books: [...f.books],
      tables: [...f.tables],
    })),
    notDerivable: ['CO_SET', 'CO_SET_NEW'],
  };
  const target = resolve(process.cwd(), jsonOut);
  writeFileSync(target, `${JSON.stringify(plain, null, 2)}\n`);
  out('');
  out(`seed spec -> ${relative(REPO, target)}`);
}
