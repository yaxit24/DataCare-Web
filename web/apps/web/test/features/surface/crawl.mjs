import { readFileSync, readdirSync, statSync } from 'node:fs';
import { join, relative, resolve } from 'node:path';
import { webRoot } from '../harness.mjs';

/**
 * UI surface crawler (docs/handbook/web/testing.md §4b).
 *
 * Visits every route an operator can reach — every sidebar menu link (web/apps/web/lib/nav.ts) and every page that
 * exists but is not linked — as a logged-in user against the disposable stack, and records what the page is: its
 * heading, every control inside the content area, the API calls it makes, and what each button does when pressed.
 * It does not decide that a page is equivalent to the desktop; it finds pages that are broken (crash, 5xx, not found),
 * refusals the operator cannot see, buttons that do nothing, and empty forms the server accepts.
 */

const repoRoot = resolve(webRoot, '..');

/** Buttons whose effect would change the data later pages depend on. They run in a final pass of their own. */
export const DESTRUCTIVE =
  /^del\b|delete|remove|^×$|^✕$|year.?end|close year|renumber|repair|provision|restore|reset|truncate|purge|revoke|deactivate|clear all|cancel (tag|voucher|order)|logout/i;

/** Every menu link, in menu order. */
export function menuRoutes() {
  const source = readFileSync(resolve(webRoot, 'apps/web/lib/nav.ts'), 'utf8');
  const groups = [];
  const groupRe = /\{\s*label:\s*'([^']+)',\s*items:\s*\[([\s\S]*?)\]\s*,?\s*\}/g;
  let g;
  while ((g = groupRe.exec(source))) {
    const items = [...g[2].matchAll(/\{\s*label:\s*'([^']+)',\s*href:\s*'([^']+)'/g)].map((m) => ({
      label: m[1],
      route: m[2],
    }));
    groups.push({ group: g[1], items });
  }
  const seen = new Set();
  const out = [];
  for (const { group, items } of groups)
    for (const item of items) {
      const key = item.route;
      if (seen.has(key)) {
        out.find((o) => o.route === key).aliases.push(`${group} / ${item.label}`);
        continue;
      }
      seen.add(key);
      out.push({ route: item.route, label: item.label, group, inMenu: true, aliases: [] });
    }
  return out;
}

/** Static pages under app/ that the menu does not link to. */
export function unlinkedPages(menu) {
  const appDir = resolve(webRoot, 'apps/web/app');
  const pages = [];
  const walk = (dir) => {
    for (const entry of readdirSync(dir)) {
      const full = join(dir, entry);
      if (statSync(full).isDirectory()) walk(full);
      else if (entry === 'page.tsx') pages.push(full);
    }
  };
  walk(appDir);
  const linked = new Set(menu.map((m) => m.route));
  const skip = new Set(['/', '/login', '/select', '/soon', '/dashboard']);
  return pages
    .map((file) => {
      const route =
        '/' +
        relative(appDir, file)
          .replace(/\/?page\.tsx$/, '')
          .split('/')
          .filter((part) => !/^\(.*\)$/.test(part))
          .join('/');
      return {
        route: route === '/' ? '/' : route.replace(/\/$/, ''),
        file: relative(repoRoot, file),
      };
    })
    .filter(({ route }) => !route.includes('[') && !linked.has(route) && !skip.has(route))
    .map(({ route, file }) => ({
      route,
      label: route,
      group: '(not in menu)',
      inMenu: false,
      aliases: [],
      file,
    }));
}

/** Desktop menu catalog rows (docs/handbook/menu-catalog.jsonl), indexed by the web routes they name. */
export function catalogByRoute() {
  const rows = readFileSync(resolve(repoRoot, 'docs/handbook/menu-catalog.jsonl'), 'utf8')
    .split('\n')
    .filter(Boolean)
    .map((line) => JSON.parse(line));
  const byRoute = new Map();
  for (const row of rows)
    for (const ui of row.ui ?? []) {
      const route = String(ui).split('?')[0];
      if (!byRoute.has(route)) byRoute.set(route, []);
      byRoute.get(route).push({ id: row.id, forms: row.forms, status: row.status, gaps: row.gaps });
    }
  return { rows, byRoute };
}

/** Routes the retained browser suites already drive (journeys and feature modules). */
export function deepCoverage() {
  const dir = resolve(webRoot, 'apps/web/test');
  const files = [
    ...readdirSync(dir)
      .filter((f) => /\.(journey|real-stack[^.]*)\.mjs$|^parity\.real-stack\.mjs$/.test(f))
      .map((f) => join(dir, f)),
    ...readdirSync(join(dir, 'features/modules')).map((f) => join(dir, 'features/modules', f)),
  ];
  const byRoute = new Map();
  for (const file of files) {
    const text = readFileSync(file, 'utf8');
    for (const m of text.matchAll(/goto\(['`](\/[a-z0-9/_-]+)/g)) {
      const route = m[1].replace(/\/$/, '');
      if (!byRoute.has(route)) byRoute.set(route, new Set());
      byRoute.get(route).add(relative(repoRoot, file));
    }
  }
  return byRoute;
}

const sleep = (ms) => new Promise((done) => setTimeout(done, ms));

/** Attach recorders to a page once; each phase reads and resets the current bucket. */
export function instrument(page) {
  const state = {
    requests: [],
    pageErrors: [],
    consoleErrors: [],
    dialogs: [],
    popups: [],
    downloads: [],
    fileChoosers: 0,
  };
  let inflight = 0;
  let lastActivity = Date.now();
  const isApi = (url) => new URL(url).pathname.startsWith('/api/');
  page.on('request', (request) => {
    if (!isApi(request.url())) return;
    inflight += 1;
    lastActivity = Date.now();
  });
  const done = (request) => {
    if (!isApi(request.url())) return;
    inflight = Math.max(0, inflight - 1);
    lastActivity = Date.now();
  };
  page.on('requestfinished', done);
  page.on('requestfailed', done);
  page.on('response', (response) => {
    const url = new URL(response.url());
    if (!url.pathname.startsWith('/api/')) return;
    state.requests.push({
      method: response.request().method(),
      path: url.pathname,
      query: url.search,
      status: response.status(),
    });
  });
  page.on('pageerror', (error) =>
    state.pageErrors.push(String(error?.message ?? error).slice(0, 300)),
  );
  page.on('console', (message) => {
    if (message.type() !== 'error') return;
    const text = message.text();
    if (/^Failed to load resource: the server responded with a status of 4\d\d/.test(text)) return;
    state.consoleErrors.push(text.slice(0, 300));
  });
  page.on('dialog', (dialog) => {
    state.dialogs.push({ type: dialog.type(), message: dialog.message().slice(0, 200) });
    void dialog.accept().catch(() => {});
  });
  page.on('popup', (popup) => {
    state.popups.push(popup.url());
    void popup.close().catch(() => {});
  });
  page.on('download', (download) => state.downloads.push(download.suggestedFilename()));
  page.on('filechooser', () => (state.fileChoosers += 1));
  return {
    /** No API request in flight and none started or finished for `quietMs`. */
    quiet: (quietMs) => inflight === 0 && Date.now() - lastActivity >= quietMs,
    take() {
      const snapshot = JSON.parse(JSON.stringify(state));
      state.requests = [];
      state.pageErrors = [];
      state.consoleErrors = [];
      state.dialogs = [];
      state.popups = [];
      state.downloads = [];
      state.fileChoosers = 0;
      return snapshot;
    },
  };
}

const CRASH_TEXT =
  /Application error: a client-side exception|This page could not be found|Unhandled Runtime Error|Internal Server Error/;

/**
 * Wait until the page has finished what the action started: no API request in flight for 600 ms (a click handler
 * gets 300 ms to start its first request), then 200 ms for React to render the result. Gives up after `maxMs`.
 */
async function settle(page, recorder, maxMs = 15_000) {
  const started = Date.now();
  await sleep(300);
  while (Date.now() - started < maxMs) {
    if (recorder.quiet(600)) break;
    await sleep(100);
  }
  await sleep(200);
}

async function mainText(page) {
  return page
    .locator('main.content, form.login-card')
    .first()
    .innerText({ timeout: 2000 })
    .catch(() => '');
}

/** Open a route fresh, expand every disclosure, and mark every content button with a crawl id. */
async function openRoute(page, recorder, route) {
  const started = Date.now();
  await page.goto(route, { waitUntil: 'domcontentloaded', timeout: 30_000 });
  await settle(page, recorder, 20_000);
  const loadMs = Date.now() - started;
  const summaries = page.locator(
    'main.content details:not([open]) > summary, form.login-card details:not([open]) > summary',
  );
  const disclosures = await summaries.count().catch(() => 0);
  for (let i = 0; i < disclosures; i++)
    await summaries
      .first()
      .click({ timeout: 2000 })
      .catch(() => {});
  return { loadMs, disclosures };
}

/** Structure of the content area (the sidebar, header and shortcut bar are the same on every page). */
async function inventory(page) {
  return page.evaluate(() => {
    const main =
      document.querySelector('main.content') ||
      document.querySelector('form.login-card') ||
      document.body;
    if (!main) return { missingMain: true };
    const inBar = (el) => !!el.closest('.form-key-hints');
    const name = (el) =>
      (el.getAttribute('aria-label') || el.innerText || el.textContent || el.value || '')
        .trim()
        .replace(/\s+/g, ' ')
        .slice(0, 80);
    const visible = (el) => !!(el.offsetWidth || el.offsetHeight || el.getClientRects().length);
    const buttons = [...main.querySelectorAll('button')].filter((b) => !inBar(b));
    let id = 0;
    for (const b of buttons) b.setAttribute('data-crawl-id', String(id++));
    const inputs = [...main.querySelectorAll('input')];
    const byType = {};
    for (const i of inputs) byType[i.type || 'text'] = (byType[i.type || 'text'] ?? 0) + 1;
    const labels = [...main.querySelectorAll('label')]
      .map((l) => (l.textContent || '').trim())
      .filter(Boolean);
    return {
      heading: (main.querySelector('h1')?.textContent || '').trim(),
      buttons: buttons.map((b) => ({
        id: b.getAttribute('data-crawl-id'),
        name: name(b) || '(unnamed)',
        disabled: b.disabled,
        visible: visible(b),
        primary: b.classList.contains('primary'),
        type: b.getAttribute('type') || 'submit',
      })),
      inputs: inputs.length,
      inputTypes: byType,
      selects: [...main.querySelectorAll('select')].map((s) => ({
        name: name(s) || s.id || '',
        options: s.options.length,
      })),
      textareas: main.querySelectorAll('textarea').length,
      tables: main.querySelectorAll('table').length,
      links: [...main.querySelectorAll('a[href]')].map((a) => a.getAttribute('href')).slice(0, 40),
      labels: labels.slice(0, 120),
      shortcutBar: !!document.querySelector('.form-key-hints'),
    };
  });
}

function classify(effect) {
  const kinds = [];
  if (effect.navigatedTo) kinds.push('navigate');
  if (effect.popups.length) kinds.push('popup');
  if (effect.downloads.length) kinds.push('download');
  if (effect.dialogs.length) kinds.push('dialog');
  if (effect.fileChoosers) kinds.push('file-chooser');
  for (const r of effect.requests) {
    const band = r.status >= 500 ? '5xx' : r.status >= 400 ? '4xx' : '2xx';
    const kind = `${r.method === 'GET' ? 'read' : 'write'}:${band}`;
    if (!kinds.includes(kind)) kinds.push(kind);
  }
  if (effect.domChanged) kinds.push('dom');
  if (!kinds.length && effect.invalidFields) kinds.push('blocked-by-required-field');
  return kinds.length ? kinds : ['none'];
}

/** Press one button and observe everything it caused. */
async function press(page, recorder, route, button, { prefill } = {}) {
  recorder.take();
  if (prefill) await prefill(page).catch(() => {});
  const before = await mainText(page);
  const urlBefore = page.url();
  const target = page.locator(`[data-crawl-id="${button.id}"]`).first();
  let clickError = null;
  try {
    await target.click({ timeout: 3000 });
  } catch (error) {
    clickError = String(error?.message ?? error)
      .split('\n')[0]
      .slice(0, 200);
  }
  await settle(page, recorder);
  const observed = recorder.take();
  const invalidFields = await page
    .evaluate(
      () =>
        [...document.querySelectorAll('main.content :invalid, form.login-card :invalid')].filter(
          (el) => el.tagName !== 'FORM',
        ).length,
    )
    .catch(() => 0);
  // A refusal is visible when an error message is on screen after the action, even if it is the same text as before.
  const errorShown = await page
    .locator(
      'main.content .msg.err, main.content [role=alert], form.login-card [role=alert], main.content .msg.error',
    )
    .allInnerTexts()
    .then((texts) => texts.some((t) => t.trim()))
    .catch(() => false);
  const urlAfter = page.url();
  const after = await mainText(page);
  const effect = {
    button: button.name,
    clickError,
    navigatedTo: urlAfter !== urlBefore ? new URL(urlAfter).pathname : null,
    domChanged: after !== before,
    crashText: CRASH_TEXT.test(after) ? after.match(CRASH_TEXT)[0] : null,
    feedback: after !== before ? diffText(before, after) : '',
    invalidFields,
    errorShown,
    ...observed,
  };
  effect.kinds = classify(effect);
  return effect;
}

/** The lines that appeared after an action (what the operator was told). */
function diffText(before, after) {
  const old = new Set(before.split('\n').map((l) => l.trim()));
  return after
    .split('\n')
    .map((l) => l.trim())
    .filter((l) => l && !old.has(l))
    .slice(0, 6)
    .join(' | ')
    .slice(0, 300);
}

function findingsFor(route, phase, effect, context = {}) {
  const out = [];
  const add = (severity, kind, detail) =>
    out.push({ route, phase, severity, kind, button: effect.button, detail, ...context });
  for (const r of effect.requests.filter((x) => x.status >= 500))
    add('high', 'server-error', `${r.method} ${r.path} → ${r.status}`);
  for (const e of effect.pageErrors) add('high', 'page-crash', e);
  if (effect.crashText) add('high', 'page-crash', effect.crashText);
  for (const e of effect.consoleErrors.filter((c) => !/status of 5\d\d/.test(c)))
    add('medium', 'console-error', e);
  if (effect.navigatedTo?.startsWith('/login'))
    add('high', 'session-lost', `pressing "${effect.button}" ended the session`);
  const refusals = effect.requests.filter(
    (x) => x.status >= 400 && x.status < 500 && x.status !== 401,
  );
  if (refusals.length && !effect.domChanged && !effect.dialogs.length && !effect.errorShown)
    add(
      'medium',
      'silent-refusal',
      `${refusals.map((r) => `${r.method} ${r.path} → ${r.status}`).join(', ')} with nothing shown to the operator`,
    );
  return out;
}

/**
 * Crawl one route. `phase` is 'safe' (every non-destructive button) or 'destructive' (the remaining ones).
 * Returns the page record and its findings.
 */
export async function crawlRoute(page, recorder, entry, { phase, sweep }) {
  const record = { ...entry, phase, probes: [], buttons: [], findings: [] };
  recorder.take();
  let opened;
  try {
    opened = await openRoute(page, recorder, entry.route);
  } catch (error) {
    record.findings.push({
      route: entry.route,
      phase,
      severity: 'high',
      kind: 'load-failed',
      detail: String(error?.message ?? error).split('\n')[0],
    });
    return record;
  }
  const load = recorder.take();
  record.finalPath = new URL(page.url()).pathname;
  record.loadMs = opened.loadMs;
  record.disclosures = opened.disclosures;
  const structure = await inventory(page);
  const text = await mainText(page);
  record.structure = structure;
  record.loadRequests = load.requests;
  if (phase === 'safe') {
    if (record.finalPath.startsWith('/login'))
      record.findings.push({
        route: entry.route,
        phase,
        severity: 'high',
        kind: 'session-lost',
        detail: 'page load redirected to login',
      });
    if (record.finalPath === '/soon' || /This screen is planned and being ported/.test(text))
      record.findings.push({
        route: entry.route,
        phase,
        severity: 'medium',
        kind: 'placeholder',
        detail: 'page renders the "planned" placeholder',
      });
    if (CRASH_TEXT.test(text))
      record.findings.push({
        route: entry.route,
        phase,
        severity: 'high',
        kind: 'page-crash',
        detail: text.match(CRASH_TEXT)[0],
      });
    if (structure.missingMain)
      record.findings.push({
        route: entry.route,
        phase,
        severity: 'high',
        kind: 'page-crash',
        detail: 'no content area rendered',
      });
    else if (!structure.heading)
      record.findings.push({
        route: entry.route,
        phase,
        severity: 'low',
        kind: 'no-heading',
        detail: 'content has no h1',
      });
    for (const r of load.requests.filter((x) => x.status >= 500))
      record.findings.push({
        route: entry.route,
        phase,
        severity: 'high',
        kind: 'server-error',
        detail: `on load: ${r.method} ${r.path} → ${r.status}`,
      });
    // By design: reports/[report]/page.tsx asks every report for its shared filters and treats 404 as "this
    // report has none" (its own comment says the 404 is not an error).
    const byDesign = (r) => r.status === 404 && /^\/api\/reports\/[^/]+\/filters$/.test(r.path);
    for (const r of load.requests.filter(
      (x) => x.status >= 400 && x.status < 500 && x.status !== 401,
    ))
      record.findings.push({
        route: entry.route,
        phase,
        severity: byDesign(r) ? 'low' : 'medium',
        kind: byDesign(r) ? 'load-refused-by-design' : 'load-refused',
        detail: `on load: ${r.method} ${r.path}${r.query} → ${r.status}`,
      });
    for (const e of load.pageErrors)
      record.findings.push({
        route: entry.route,
        phase,
        severity: 'high',
        kind: 'page-crash',
        detail: e,
      });
    for (const e of load.consoleErrors.filter((c) => !/status of 5\d\d/.test(c)))
      record.findings.push({
        route: entry.route,
        phase,
        severity: 'medium',
        kind: 'console-error',
        detail: `on load: ${e}`,
      });
  }
  if (structure.missingMain) return record;

  const buttons = structure.buttons;
  const distinct = [];
  const seen = new Set();
  for (const b of buttons) {
    if (seen.has(b.name)) continue;
    seen.add(b.name);
    distinct.push(b);
  }
  const wanted = distinct.filter((b) =>
    phase === 'destructive' ? DESTRUCTIVE.test(b.name) : !DESTRUCTIVE.test(b.name),
  );

  // --- probes (safe phase): the cases every voucher, master and report screen must handle -------------------
  if (phase === 'safe') {
    const voucherInput = page.getByLabel(/^Voucher no\.?$/i).first();
    const loadButton = distinct.find((b) => b.name === 'Load' && b.visible && !b.disabled);
    if (loadButton && (await voucherInput.count().catch(() => 0))) {
      record.probed = [...(record.probed ?? []), 'Load'];
      const effect = await press(page, recorder, entry.route, loadButton, {
        prefill: (p) =>
          p
            .getByLabel(/^Voucher no\.?$/i)
            .first()
            .fill('99999'),
      });
      record.probes.push({ probe: 'load-missing-voucher', effect });
      record.findings.push(
        ...findingsFor(entry.route, phase, effect, { probe: 'load-missing-voucher' }),
      );
      if (effect.kinds.includes('none'))
        record.findings.push({
          route: entry.route,
          phase,
          severity: 'medium',
          kind: 'no-feedback',
          probe: 'load-missing-voucher',
          button: 'Load',
          detail: 'loading voucher 99999 showed nothing and made no request',
        });
      await openRoute(page, recorder, entry.route);
      await inventory(page);
    }
    const isReport = entry.route.startsWith('/reports/');
    const primary = distinct.find(
      (b) => b.primary && b.visible && !b.disabled && !DESTRUCTIVE.test(b.name),
    );
    if (primary) {
      record.probed = [...(record.probed ?? []), primary.name];
      const effect = await press(page, recorder, entry.route, primary);
      const probe = isReport ? 'run-report' : 'submit-empty-form';
      record.probes.push({ probe, effect });
      record.findings.push(...findingsFor(entry.route, phase, effect, { probe }));
      // A preview or computation (estimate, balance preview, closing preview, data refresh) runs on its defaults;
      // only a request that CREATES something from an empty form is a finding.
      const writes = effect.requests.filter(
        (r) =>
          r.method !== 'GET' &&
          r.status < 300 &&
          (r.status === 201 || !/\/(preview|estimate|data-refresh)(\/|$)/.test(r.path)),
      );
      if (!isReport && writes.length)
        record.findings.push({
          route: entry.route,
          phase,
          severity: 'medium',
          kind: 'empty-form-accepted',
          probe,
          button: primary.name,
          detail: `an empty form was accepted: ${writes.map((r) => `${r.method} ${r.path} → ${r.status}`).join(', ')}`,
        });
      if (!isReport && effect.kinds.join() === 'none')
        record.findings.push({
          route: entry.route,
          phase,
          severity: 'medium',
          kind: 'no-feedback',
          probe,
          button: primary.name,
          detail: 'pressing the main action on an empty form showed nothing and made no request',
        });
      if (isReport) {
        const rows = await page
          .locator('main.content table tbody tr')
          .count()
          .catch(() => 0);
        record.reportRows = rows;
        const pdf = distinct.find((b) => b.name === 'Download PDF');
        if (pdf) {
          record.probed = [...(record.probed ?? []), pdf.name];
          await inventory(page);
          const pdfEffect = await press(page, recorder, entry.route, pdf);
          record.probes.push({ probe: 'report-pdf', effect: pdfEffect });
          record.findings.push(
            ...findingsFor(entry.route, phase, pdfEffect, { probe: 'report-pdf' }),
          );
        }
      }
      await openRoute(page, recorder, entry.route);
      await inventory(page);
    }
  }

  // --- every button -------------------------------------------------------------------------------------------
  if (sweep) {
    const probed = new Set(record.probed ?? []);
    for (const wantedButton of wanted.filter((b) => !probed.has(b.name)).slice(0, 40)) {
      const current = await inventory(page);
      const button = current.buttons?.find((b) => b.name === wantedButton.name);
      if (!button) {
        record.buttons.push({ button: wantedButton.name, kinds: ['not-present-after-reload'] });
        continue;
      }
      if (button.disabled || !button.visible) {
        record.buttons.push({
          button: button.name,
          kinds: [button.disabled ? 'disabled' : 'hidden'],
        });
        continue;
      }
      const effect = await press(page, recorder, entry.route, button);
      record.buttons.push({
        button: effect.button,
        kinds: effect.kinds,
        requests: effect.requests,
        navigatedTo: effect.navigatedTo,
        feedback: effect.feedback,
        dialogs: effect.dialogs,
        clickError: effect.clickError,
      });
      record.findings.push(...findingsFor(entry.route, phase, effect));
      if (effect.kinds.join() === 'none' && !effect.clickError)
        record.findings.push({
          route: entry.route,
          phase,
          severity: 'low',
          kind: 'no-visible-effect',
          button: effect.button,
          detail: 'no request, navigation, dialog or screen change',
        });
      if (effect.navigatedTo || effect.crashText || page.isClosed()) {
        if (page.isClosed()) break;
        await openRoute(page, recorder, entry.route).catch(() => {});
      }
    }
  }
  return record;
}
