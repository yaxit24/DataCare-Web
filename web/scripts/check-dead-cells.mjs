#!/usr/bin/env node
/**
 * Dead-cell audit: every extended grid column must be consumed by the writer behind its page.
 *
 * WHY THIS EXISTS
 * The depth metric counts a rendered `<th>`/`<input>` pair as parity. It cannot tell whether the value
 * the operator types is persisted, so a column wired from an API *interface* that the *writer* ignores
 * scores exactly like a real one. That is not hypothetical: 29 of 30 columns wired onto purchase-return
 * were dead — mirrored from purchase's registry and verified against `PurchaseLineInput` instead of
 * `purchaseReturn`'s row builder — and the metric counted all 29 as depth for several rounds.
 *
 * HOW IT DECIDES
 * A field is consumed when the module behind the page reads it in a used runtime expression, which covers both direct
 * column assignment and use as an override in a line calculator (purchase.ts honours `fineWt`,
 * `kunFine` and `metalAmount` that way). It is a deliberately loose test: the goal is to catch columns
 * NOTHING reads, not to police how they are read. AST analysis excludes comments, interfaces,
 * unused local declarations and uncalled local functions. Renamed/nested fields additionally need
 * an actual request mapping, matching literal route/import, forwarded input path and writer read.
 * This remains bounded static consumption evidence, not execution, losslessness or desktop parity.
 *
 * Pages map to modules explicitly below. An unmapped page is REPORTED, not skipped, because silently
 * ignoring a page is how this class of defect survived in the first place.
 */
import { readFileSync, existsSync, readdirSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, join, resolve } from 'node:path';
import {
  writerFieldReads,
  writerImportedCalls,
  traceNestedField,
  formatRequestPath,
} from './lib/request-field-trace.mjs';

const here = dirname(fileURLToPath(import.meta.url));
const root = resolve(here, '..');
const pageOf = (slug) => join(root, 'apps/web/app/(app)/txn', slug, 'page.tsx');
const modOf = (rel) => join(root, 'apps/api/src/modules', rel);

/** page slug -> the API module whose writer must consume its columns. */
const PAGE_WRITER = {
  purchase: 'purchase/purchase.ts',
  'consi-purchase': 'purchase/purchase.ts',
  'purchase-quotation': 'purchase/purchase.ts',
  'purchase-return': 'purchase/purchaseReturn.ts',
  'purchase-hm': 'purchase/purchase.ts',
  sales: 'sales/sales.ts',
  'sales-quotation': 'sales/sales.ts',
  'hallmark-sale': 'sales/sales.ts',
  estimate: 'sales/sales.ts',
  'sale-return': 'sales/salesReturn.ts',
  'sales-order': 'sales/salesOrder.ts',
  'wholesale-sale': 'sales/rateCut.ts',
  'wholesale-sale-return': 'sales/wholesaleSaleReturn.ts',
  'labour-sale': 'sales/labourInvoice.ts',
  'fine-inout': 'inout/fineInout.ts',
  'mfg-issue': 'manufacturing/mfg.ts',
  'mfg-receive': 'manufacturing/mfg.ts',
  'mfg-order-issue': 'manufacturing/mfg.ts',
  tour: 'tour/tour.ts',
  'tour-return': 'tour/tour.ts',
  'item-lot': 'stock/stockVoucherLifecycle.ts',
  // Both mount components/TagCancelForm.tsx (desktop TR_TAG_CAN). Its grid has no `extendedLineFields` registry —
  // every column is first-class — so this audit has nothing to read there; the column-to-writer evidence is
  // apps/web/test/tagCancelVoucher.test.ts (every cell is sent) and apps/api/test/tagCancelRows.test.ts (every
  // sent cell is replayed or refused, never ignored).
  'tag-cancel': 'stock/tagCancel.ts',
  'tag-transfer': 'stock/tagCancel.ts',
  // components/TagSplitForm.tsx (desktop TR_TAG_SPLIT). Its grids have no `extendedLineFields` registry — every
  // column is first-class — so this audit has nothing to read there; the column-to-writer evidence is
  // apps/web/test/tagSplitVoucher.test.ts (every cell is sent) and apps/api/test/tagSplitRows.test.ts.
  'tag-split': 'stock/tagSplit.ts',
  'tag-opening': 'stock/stockVoucherLifecycle.ts',
};

/** A module and its actually called named relative imports, one level deep. Sibling scans start
 * only at the selected exports; a different exported writer cannot lend its field consumption. */
const composedWriter = (modPath) => {
  const seen = new Set();
  const read = (file, depth, entryPoints) => {
    const key = `${file}:${entryPoints?.join(',') ?? '*'}`;
    if (depth < 0 || seen.has(key) || !existsSync(file)) return [];
    seen.add(key);
    const text = readFileSync(file, 'utf8');
    const parts = [{ source: text, file, entryPoints }];
    const dependencies = new Map();
    for (const call of writerImportedCalls(text, file, entryPoints).calls) {
      if (!call.module.endsWith('.js')) continue;
      const target = resolve(dirname(file), call.module.replace(/\.js$/, '.ts'));
      const exports = dependencies.get(target) ?? new Set();
      exports.add(call.imported);
      dependencies.set(target, exports);
    }
    for (const [target, exports] of dependencies)
      parts.push(...read(target, depth - 1, [...exports].sort()));
    return parts;
  };
  return read(modPath, 1);
};

const registryFields = (src) => {
  const m = src.match(/const extendedLineFields[^=]*=\s*\[([\s\S]*?)\n\];/);
  if (!m) return [];
  return [...m[1].matchAll(/\['(\w+)',/g)].map((x) => x[1]);
};

let dead = 0;
let unmapped = 0;
let checked = 0;
let auditedPages = 0;
const report = [];
const nested = [];
const unsupported = [];
const routes = readFileSync(join(root, 'apps/api/src/routes/txn.ts'), 'utf8');

for (const [slug, rel] of Object.entries(PAGE_WRITER)) {
  const page = pageOf(slug);
  if (!existsSync(page)) continue;
  const pageSource = readFileSync(page, 'utf8');
  const fields = registryFields(pageSource);
  if (fields.length === 0) continue;
  auditedPages += 1;
  const modPath = modOf(rel);
  if (!existsSync(modPath)) {
    report.push(`  ! ${slug}: writer module not found (${rel})`);
    unmapped += 1;
    continue;
  }
  // Follow called sibling exports only. Whole imported modules previously lent unrelated Sales
  // Order field reads to the ordinary Sales page merely because an advance helper was imported.
  const writer = composedWriter(modPath);
  const reads = writer.flatMap(
    ({ source, file, entryPoints }) => writerFieldReads(source, file, entryPoints).reads,
  );
  const missing = fields.filter((field) => {
    if (reads.some((read) => read.field === field)) return false;
    const result = traceNestedField({
      pageSource,
      routeSource: routes,
      writerSources: writer,
      writerRelativePath: rel,
      field,
    });
    if (result.traces.length) {
      nested.push({ page: slug, field, traces: result.traces });
      return false;
    }
    if (result.unsupported.length)
      unsupported.push({ page: slug, field, diagnostics: result.unsupported });
    return true;
  });
  checked += fields.length;
  if (missing.length) {
    dead += missing.length;
    report.push(`  x ${slug}: ${missing.length} dead of ${fields.length} -> ${missing.join(', ')}`);
  }
}

// A page with an extended registry that this script does not map is a blind spot, so name it.
const allSlugs = Object.keys(PAGE_WRITER);
for (const entry of readdirSync(join(root, 'apps/web/app/(app)/txn'), { withFileTypes: true })) {
  if (!entry.isDirectory() || entry.name in PAGE_WRITER || !existsSync(pageOf(entry.name)))
    continue;
  if (registryFields(readFileSync(pageOf(entry.name), 'utf8')).length) {
    unmapped += 1;
    report.push(`  ! ${entry.name}: extended registry has no writer mapping`);
  }
}
if (process.argv.includes('--json')) {
  console.log(
    JSON.stringify(
      {
        checked,
        pages: auditedPages,
        mappedPages: allSlugs.length,
        dead,
        unmapped,
        nested,
        unsupported,
        report,
      },
      null,
      2,
    ),
  );
  process.exit(dead || unmapped ? 1 : 0);
}
console.log(
  `dead-cell audit: ${checked} extended columns checked across ${auditedPages} pages (${allSlugs.length} mapped pages)`,
);
for (const line of report) console.log(line);
for (const item of nested) {
  const trace = item.traces[0];
  console.log(
    `  nested ${item.page}.${item.field}: ${trace.method.toUpperCase()} ${trace.endpoint} ${formatRequestPath(trace.path)} -> ${trace.forwarding.writer} -> ${trace.read.column ?? formatRequestPath(trace.read.path)} (${trace.read.file}:${trace.read.line})`,
  );
}
if (unsupported.length)
  console.log(
    `  ${unsupported.length} unresolved fields include unsupported syntax; inspect --json diagnostics. They remain failures, never presumed live.`,
  );
if (dead === 0 && unmapped === 0) {
  console.log(
    '  all checked extended grid columns have static writer-consumption evidence (not runtime parity).',
  );
  process.exit(0);
}
console.log(
  `\nDEAD CELLS: ${dead}. A column the writer never reads silently discards operator input`,
);
console.log(
  'and is counted as parity by the depth metric. Wire it in the writer or remove the column.',
);
process.exit(1);
