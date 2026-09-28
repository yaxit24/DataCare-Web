#!/usr/bin/env node
/**
 * Combine the retained desktop captures into one bundle, so the comparison can cover more than one family.
 *
 * WHY THIS IS NEEDED
 * ==================
 * `desktop-latest.json` holds 66 cases, all of them purchases (51) or wholesale rate-cuts (15) — two of the
 * desktop's 61 transaction families. Extending coverage normally means a new capture from the real SQL Server,
 * which is not reachable here.
 *
 * But earlier captures were retained, and between them they hold four families the 66-case bundle does not:
 *
 *     sale-027-00001     retail sale        SL_DATA / SL_DETL / BILL_OS_DATA / TAX_DATA
 *     scheme-074-00001   savings scheme     AD_DATA / AD_OS
 *     cashrec-001-00001  cash receipt       CASH_DATA
 *     cashpay-002-00029  cash payment       CASH_DATA
 *
 * Merging them raises family coverage from 2 to 6 using only evidence already on disk.
 *
 * RULES
 * =====
 *   * a case is identified by `caseId`; the NEWEST capture containing it wins, so a re-capture supersedes
 *   * duplicate vouchers under different case ids are dropped, keeping the one whose id names its family —
 *     `real-sale-027-00001` and `sale-027-00001` are the same voucher, and comparing it twice would double-count
 *     every difference it carries
 *   * provenance is preserved per case, because the gate requires a Microsoft SQL Server banner and a merged
 *     bundle must not launder a synthetic capture into a real one
 *   * a capture whose desktop side is not sqlserver is refused outright
 *
 * USAGE
 *   node apps/api/integration/parity-bundle-merge.mjs [--out name.json]
 */

import { readFileSync, readdirSync, writeFileSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve, relative } from 'node:path';

const HERE = dirname(fileURLToPath(import.meta.url));
const WEB = resolve(HERE, '../../..');
const REPO = resolve(WEB, '..');
const BUNDLES = resolve(REPO, 'project-memory', 'parity', 'bundles');

const argv = process.argv.slice(2);
const outIdx = argv.indexOf('--out');
const outName = outIdx >= 0 ? argv[outIdx + 1] : 'desktop-combined.json';

const files = readdirSync(BUNDLES)
  .filter(
    (f) =>
      f.startsWith('desktop-') &&
      f.endsWith('.json') &&
      !f.includes('latest') &&
      !f.includes('combined'),
  )
  .sort(); // ascending, so later captures overwrite earlier ones

const byCase = new Map();
const byVoucher = new Map();
const refused = [];
let template = null;

for (const f of files) {
  let b;
  try {
    b = JSON.parse(readFileSync(resolve(BUNDLES, f), 'utf8'));
  } catch {
    refused.push(`${f}: unreadable`);
    continue;
  }
  if (b?.kind !== 'datacare.parity-bundle/1.0' || b.side !== 'desktop') {
    refused.push(`${f}: not a desktop parity bundle`);
    continue;
  }
  const engine = String(b.source?.engine ?? '').toLowerCase();
  if (engine && engine !== 'sqlserver') {
    refused.push(`${f}: desktop side is "${engine}", not sqlserver`);
    continue;
  }
  template = template ?? b;
  for (const c of b.cases ?? []) {
    const id = String(c.caseId ?? '').trim();
    if (!id) continue;
    byCase.set(id, {
      ...c,
      capturedIn: f,
      capturedAt: b.capturedAt ?? null,
      source: b.source ?? null,
    });
  }
}

/**
 * Drop duplicate vouchers.
 *
 * The same voucher appears under different case ids across captures: the 08-02T08-19 capture named cases by BOOK
 * (`035-00001`) and the 08-02T17-09 one by FAMILY (`purc-035-00001`). Keeping both would compare the same voucher
 * twice and double-count every difference it carries.
 *
 * The newest capture's naming wins, because that is the scheme the current bundle uses; `real-` prefixed ids lose
 * a tie, since they name no family.
 */
const rank = (c) => files.indexOf(c.capturedIn);
const prefixPenalty = (id) => (/^real[-_]/.test(id) ? 1 : 0);
for (const [id, c] of [...byCase].sort((a, b) => {
  const byRecency = rank(b[1]) - rank(a[1]);
  return byRecency !== 0 ? byRecency : prefixPenalty(a[0]) - prefixPenalty(b[0]);
})) {
  const key = `${c.voucher?.book}/${c.voucher?.vchNo}`;
  if (byVoucher.has(key)) {
    byCase.delete(id);
    continue;
  }
  byVoucher.set(key, id);
}

if (!template) {
  console.error('BUNDLE_MERGE_FAILED no usable desktop capture found');
  process.exit(1);
}

const cases = [...byCase.values()].sort((a, b) => String(a.caseId).localeCompare(String(b.caseId)));
const merged = {
  kind: 'datacare.parity-bundle/1.0',
  side: 'desktop',
  capturedAt: new Date().toISOString(),
  mergedFrom: files,
  source: template.source ?? null,
  scope: template.scope ?? null,
  cases,
};

const target = resolve(BUNDLES, outName);
writeFileSync(target, `${JSON.stringify(merged, null, 2)}\n`);

const fam = new Map();
for (const c of cases) {
  const f = String(c.caseId).split('-')[0];
  fam.set(f, (fam.get(f) ?? 0) + 1);
}
console.log(`merged ${files.length} capture(s) -> ${relative(REPO, target)}`);
console.log(`cases ${cases.length} across ${fam.size} family(ies)`);
for (const [f, n] of [...fam].sort()) console.log(`  ${f.padEnd(10)} ${n}`);
if (refused.length) {
  console.log('refused:');
  for (const r of refused) console.log(`  ${r}`);
}
