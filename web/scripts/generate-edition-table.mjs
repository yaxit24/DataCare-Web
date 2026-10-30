#!/usr/bin/env node
/**
 * Generate `packages/core/src/editionTable.ts`: the edition of every web route and every rights form (N171, D31).
 *
 * Sources, in order of authority:
 *   1. `docs/handbook/menu-editions.json` — each desktop menu's edition, read from the desktop's MENU_DATA, and
 *      `docs/handbook/menu-catalog.jsonl` — the web routes (`ui`) that serve each menu. A route takes the LOWEST
 *      edition of the visible menus it serves (editions are cumulative, MDI_FORM.cs:11249-11322).
 *   2. `docs/handbook/web-route-editions.json` — the reviewed edition, with a reason, of each web route and API rights
 *      form that serves no desktop menu row. An entry there for a route the catalog already maps is refused, so the
 *      desktop data always wins.
 *   3. `apps/web/lib/nav.ts` — every navigation item must resolve, and its rights form takes its route's edition;
 *      every static page under `apps/web/app/(app)` must resolve too.
 *
 *   node scripts/generate-edition-table.mjs          # write the table
 *   node scripts/generate-edition-table.mjs --check  # exit 1 when the committed table is stale or a route is unclassified
 */
import { readFileSync, readdirSync, statSync, writeFileSync } from 'node:fs';
import { dirname, join, relative, resolve, sep } from 'node:path';
import { fileURLToPath, pathToFileURL } from 'node:url';

const here = dirname(fileURLToPath(import.meta.url));
const webRoot = resolve(here, '..');
const repoRoot = resolve(webRoot, '..');
const OUTPUT = resolve(webRoot, 'packages/core/src/editionTable.ts');
const ORDER = ['L', 'B', 'S', 'U', 'P', 'A', 'E'];
const TIERS = new Set([...ORDER, 'platform']);

const basePath = (href) => (href.split('?')[0] ?? '').replace(/\/+$/, '') || '/';
/** The lower of two tiers; `platform` is lowest (always shown). */
export function lowerTier(a, b) {
  if (a === undefined) return b;
  if (b === undefined) return a;
  if (a === 'platform' || b === 'platform') return 'platform';
  return ORDER.indexOf(a) <= ORDER.indexOf(b) ? a : b;
}

/**
 * Build the table from already-loaded inputs. Pure, so the tests can feed it variations.
 * Returns `{ routes, forms, problems }`; `problems` lists every reason the table cannot be trusted.
 */
export function buildEditionTable({ menuEditions, catalog, overrides, nav, pages }) {
  const problems = [];
  const byId = new Map(catalog.map((row) => [row.id, row]));
  const routes = {};
  for (const menu of menuEditions.menus) {
    if (!menu.visible || menu.separator || !menu.catalogId) continue;
    const row = byId.get(menu.catalogId);
    if (!row) {
      problems.push(`menu-editions names unknown catalog row ${menu.catalogId}`);
      continue;
    }
    for (const href of row.ui ?? [])
      routes[basePath(href)] = lowerTier(routes[basePath(href)], menu.edition);
  }
  for (const [route, entry] of Object.entries(overrides.routes ?? {})) {
    if (!TIERS.has(entry.edition))
      problems.push(`override ${route}: unknown edition ${entry.edition}`);
    else if (!entry.reason) problems.push(`override ${route}: a reason is required`);
    else if (routes[route] !== undefined)
      problems.push(`override ${route} is redundant: the menu catalog maps it to ${routes[route]}`);
    else routes[route] = entry.edition;
  }
  const forms = {};
  for (const item of nav) {
    const tier = routes[basePath(item.href)];
    if (tier === undefined) {
      problems.push(`navigation item ${item.group}/${item.label} (${item.href}) has no edition`);
      continue;
    }
    forms[item.form] = lowerTier(forms[item.form], tier);
  }
  for (const [form, entry] of Object.entries(overrides.forms ?? {})) {
    if (!TIERS.has(entry.edition))
      problems.push(`override form ${form}: unknown edition ${entry.edition}`);
    else if (!entry.reason) problems.push(`override form ${form}: a reason is required`);
    else if (forms[form] !== undefined)
      problems.push(`override form ${form} is redundant: navigation maps it to ${forms[form]}`);
    else forms[form] = entry.edition;
  }
  for (const page of pages)
    if (routes[page] === undefined) problems.push(`page ${page} has no edition`);
  const sorted = (object) =>
    Object.fromEntries(Object.entries(object).sort(([a], [b]) => (a < b ? -1 : a > b ? 1 : 0)));
  return { routes: sorted(routes), forms: sorted(forms), problems };
}

/** Static pages under app/(app): their route paths, skipping dynamic segments such as [name]. */
export function staticPages(appDirectory) {
  const out = [];
  const walk = (directory) => {
    for (const entry of readdirSync(directory)) {
      const full = join(directory, entry);
      if (statSync(full).isDirectory()) walk(full);
      else if (entry === 'page.tsx') {
        const rel = relative(appDirectory, directory).split(sep).filter(Boolean);
        if (rel.some((segment) => segment.startsWith('['))) continue;
        out.push('/' + rel.join('/'));
      }
    }
  };
  walk(appDirectory);
  return out.sort();
}

async function loadNav() {
  const ts = (await import('typescript')).default;
  const source = readFileSync(resolve(webRoot, 'apps/web/lib/nav.ts'), 'utf8');
  const js = ts.transpileModule(source, {
    compilerOptions: { module: ts.ModuleKind.ESNext, target: ts.ScriptTarget.ES2022 },
  }).outputText;
  const mod = await import('data:text/javascript;base64,' + Buffer.from(js).toString('base64'));
  return mod.NAV.flatMap((group) =>
    group.items.map((item) => ({
      group: group.label,
      label: item.label,
      href: item.href,
      form: item.form ?? `${group.label}/${item.label}`,
    })),
  );
}

export async function loadInputs() {
  const read = (path) => readFileSync(resolve(repoRoot, path), 'utf8');
  return {
    menuEditions: JSON.parse(read('docs/handbook/menu-editions.json')),
    catalog: read('docs/handbook/menu-catalog.jsonl')
      .split('\n')
      .filter((line) => line.trim())
      .map((line) => JSON.parse(line)),
    overrides: JSON.parse(read('docs/handbook/web-route-editions.json')),
    nav: await loadNav(),
    pages: staticPages(resolve(webRoot, 'apps/web/app/(app)')),
  };
}

export async function renderTable({ routes, forms }) {
  const prettier = await import('prettier');
  const entries = (object) =>
    Object.entries(object)
      .map(([key, tier]) => `  ${JSON.stringify(key).replace(/^"|"$/g, "'")}: '${tier}',`)
      .join('\n');
  const source = `/**
 * GENERATED by web/scripts/generate-edition-table.mjs — do not edit.
 *
 * The lowest edition that shows each web route and each rights form (N171, D31), from
 * docs/handbook/menu-editions.json (desktop MENU_DATA), docs/handbook/menu-catalog.jsonl and
 * docs/handbook/web-route-editions.json. Regenerate after changing any of them or the navigation.
 */
import type { EditionTier } from './editions.js';

export const ROUTE_EDITION: Readonly<Record<string, EditionTier>> = Object.freeze({
${entries(routes)}
});

export const FORM_EDITION: Readonly<Record<string, EditionTier>> = Object.freeze({
${entries(forms)}
});
`;
  const options = (await prettier.resolveConfig(OUTPUT)) ?? {};
  return prettier.format(source, { ...options, filepath: OUTPUT });
}

async function main() {
  const check = process.argv.includes('--check');
  const table = buildEditionTable(await loadInputs());
  if (table.problems.length) {
    console.error(`EDITION_TABLE_INVALID:\n- ${table.problems.join('\n- ')}`);
    process.exit(1);
  }
  const rendered = await renderTable(table);
  const counts = (object) =>
    ORDER.concat('platform')
      .map((tier) => `${tier} ${Object.values(object).filter((value) => value === tier).length}`)
      .join(', ');
  if (check) {
    let committed = '';
    try {
      committed = readFileSync(OUTPUT, 'utf8');
    } catch {
      /* missing counts as stale */
    }
    if (committed !== rendered) {
      console.error(
        'EDITION_TABLE_STALE: run `node scripts/generate-edition-table.mjs` and commit the result',
      );
      process.exit(1);
    }
    console.log(
      `EDITION_TABLE_OK: ${Object.keys(table.routes).length} routes (${counts(table.routes)}); ` +
        `${Object.keys(table.forms).length} forms`,
    );
    return;
  }
  writeFileSync(OUTPUT, rendered);
  console.log(
    `wrote ${relative(webRoot, OUTPUT)}: ${Object.keys(table.routes).length} routes (${counts(table.routes)}); ` +
      `${Object.keys(table.forms).length} forms (${counts(table.forms)})`,
  );
}

if (import.meta.url === pathToFileURL(process.argv[1] ?? '').href) await main();
