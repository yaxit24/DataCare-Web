import { existsSync, readFileSync, readdirSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { describe, expect, it } from 'vitest';
import { formTier, ROUTE_EDITION } from '@datacare/core';
import { EDITION_EXEMPT_ROUTES } from '../src/modules/rbac/editionGate.js';
import { resolvePolicyForm, routePolicyFor } from '../src/modules/rbac/routePolicy.js';

/**
 * D33: deployments run the Lite edition by default, so a Lite screen must not depend on an API of a higher edition,
 * or it breaks in Lite (403 edition-unavailable). This scans every Lite page and every shared component or library
 * module for the API calls it makes (`get('/…')`, `post(…)`, `put(…)`, `del(…)`) and checks each call resolves to a
 * route the Lite edition allows: a system route, a Lite or platform rights form, or one of the exempt configuration
 * reads (`EDITION_EXEMPT_ROUTES`). Components used only by higher-edition screens are listed in HIGHER_ONLY.
 */
const here = dirname(fileURLToPath(import.meta.url));
const web = resolve(here, '../../web');
const routePattern = /\b(?:app|server)\.(get|post|put|patch|delete)\(\s*(['"`])([^'"`]+)\2/g;
const callPattern = /\b(get|post|put|del)(?:<[^>(]*>)?\(\s*[`'"](\/[^`'"?]*)/g;
const VERB: Record<string, string> = { get: 'GET', post: 'POST', put: 'PUT', del: 'DELETE' };

/** Shared files whose higher-edition calls are only reached from higher-edition screens. */
const HIGHER_ONLY = new Set([
  'components/EBillEntry.tsx', // E Invoice and E Credit Note (Basic)
  'components/KarigarForm.tsx', // karigar and job-work screens (Basic)
  'components/RepairImagePanel.tsx', // repair screens (Standard)
  'components/TagSplitForm.tsx', // Tag Split (Advance)
]);

function declaredRoutes(): Array<{ method: string; path: string; pattern: RegExp }> {
  const files = [
    resolve(here, '../src/app.ts'),
    ...readdirSync(resolve(here, '../src/routes'))
      .filter((name) => name.endsWith('.ts'))
      .map((name) => resolve(here, '../src/routes', name)),
  ];
  const routes: Array<{ method: string; path: string; pattern: RegExp }> = [];
  for (const file of files)
    for (const m of readFileSync(file, 'utf8').matchAll(routePattern)) {
      const path = m[3]!;
      const escaped = path.replace(/[.*+?^${}()|[\]\\]/g, '\\$&').replace(/:[A-Za-z_]+/g, '[^/]+');
      routes.push({ method: m[1]!.toUpperCase(), path, pattern: new RegExp(`^${escaped}$`) });
    }
  // Literal paths first, so `/ac-opbl` wins over a parameterised sibling.
  return routes.sort((a, b) => a.path.split(':').length - b.path.split(':').length);
}

function callsIn(source: string): Array<{ method: string; url: string }> {
  const out: Array<{ method: string; url: string }> = [];
  for (const m of source.matchAll(callPattern)) {
    const url = m[2]!.replace(/\$\{[^}]*\}/g, 'x1').replace(/\/+$/, '');
    if (url) out.push({ method: VERB[m[1]!]!, url });
  }
  return out;
}

function liteSources(): Array<{ file: string; source: string }> {
  const out: Array<{ file: string; source: string }> = [];
  for (const [route, tier] of Object.entries(ROUTE_EDITION)) {
    if (tier !== 'L') continue;
    const file = resolve(web, 'app/(app)' + route, 'page.tsx');
    if (existsSync(file))
      out.push({ file: `app/(app)${route}/page.tsx`, source: readFileSync(file, 'utf8') });
  }
  for (const dir of ['components', 'lib'])
    for (const name of readdirSync(resolve(web, dir))) {
      const rel = `${dir}/${name}`;
      if (!/\.(ts|tsx)$/.test(name) || HIGHER_ONLY.has(rel)) continue;
      out.push({ file: rel, source: readFileSync(resolve(web, rel), 'utf8') });
    }
  return out;
}

describe('Lite screens use only Lite APIs (D33)', () => {
  it('every API call of a Lite page or shared module is allowed in the Lite edition', () => {
    const routes = declaredRoutes();
    const problems: string[] = [];
    let checked = 0;
    for (const { file, source } of liteSources())
      for (const call of callsIn(source)) {
        const route = routes.find((r) => r.method === call.method && r.pattern.test(call.url));
        if (!route) continue; // a document link or a non-API path
        checked += 1;
        const key = `${route.method} ${route.path}`;
        if (EDITION_EXEMPT_ROUTES.has(key)) continue;
        const policy = routePolicyFor(route.method, route.path);
        if (!policy || policy.kind !== 'form') continue;
        const params: Record<string, string> = {};
        route.path.split('/').forEach((part, i) => {
          if (part.startsWith(':')) params[part.slice(1)] = call.url.split('/')[i] ?? '';
        });
        const form = resolvePolicyForm(policy, params);
        if (!form) continue; // a dynamic master or report named by a variable; checked at request time
        const tier = formTier(form);
        if (tier !== 'L' && tier !== 'platform')
          problems.push(`${file}: ${key} -> ${form} [${tier}]`);
      }
    expect(checked).toBeGreaterThan(100);
    expect(problems).toEqual([]);
  });

  it('the exempt reads are the configuration every edition loads, and nothing else', () => {
    expect([...EDITION_EXEMPT_ROUTES].sort()).toEqual([
      'GET /integrations/device-settings',
      'GET /settings',
    ]);
  });
});
