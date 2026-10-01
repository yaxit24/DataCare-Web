import { existsSync, readFileSync, statSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';
import { describe, expect, it } from 'vitest';
import { MASTER_FORM_BY_NAME, routePolicyFor } from '../src/modules/rbac/routePolicy.js';
import { getFormEntry } from '../src/modules/rbac/formCatalog.js';
import { REPORT_FORM_BY_SLUG } from '../src/modules/reports/reportAuthorization.js';

/**
 * WP-04 — the completion register's classification must be falsifiable.
 *
 * The register now claims a web surface for 145 of the 198 desktop menu entries. A claim like
 * `GET /reports/day-book` is worth exactly as much as the check that it resolves: without one, the register is
 * prose, and prose is what the two earlier classification attempts produced before they were thrown away
 * (label matching reported Sales and Purchase as missing; table grepping reported almost everything as
 * present).
 *
 * So every surface is resolved here against the SAME registry the server authorises with — `routePolicyFor`,
 * `MASTER_FORM_BY_NAME`, the form catalog, the report slug map — or the filesystem for a page. That is why this
 * lives in the test suite rather than in `check-completion-register.mjs`: a text search in the script would
 * report a false negative on dynamic families such as `POST /masters/:name/import`, which the resolver handles
 * correctly.
 *
 * These tests also hold the register to the honesty rules WP-04 committed to, because the useful part of a
 * classification is the part that admits what is not known.
 */

const here = dirname(fileURLToPath(import.meta.url));
const repoRoot = resolve(here, '../../../..');
const register = JSON.parse(
  readFileSync(resolve(repoRoot, 'web/docs/COMPLETION-REGISTER.json'), 'utf8'),
) as {
  counts: Record<string, unknown>;
  states: Record<string, string>;
  caveat: string;
  method?: Record<string, unknown>;
  items: Array<{
    tab: string;
    menu: string;
    state: string;
    note: string | null;
    evidence: string | null;
    visibleOnDesktop?: boolean;
    desktopForms?: string[];
    webSurface: { kind: string; surface: string } | null;
    sharedSurfaceWith?: string[];
  }>;
};

const items = register.items;
const label = (it: { tab: string; menu: string }): string => `${it.tab}/${it.menu}`;

/** Resolve one claimed surface the way the server would, returning why it failed if it did. */
function resolveSurface(kind: string, surface: string): { ok: boolean; why?: string } {
  switch (kind) {
    case 'route': {
      const match = /^([A-Z]+)\s+(\/.*)$/.exec(surface);
      if (!match) return { ok: false, why: 'not a "METHOD /path" key' };
      const policy = routePolicyFor(match[1]!, match[2]!);
      return policy ? { ok: true } : { ok: false, why: 'no route policy resolves this key' };
    }
    case 'master':
      return MASTER_FORM_BY_NAME[surface]
        ? { ok: true }
        : { ok: false, why: 'not a dynamic master name' };
    case 'report':
      return surface in REPORT_FORM_BY_SLUG
        ? { ok: true }
        : { ok: false, why: 'not a generic report slug' };
    case 'form':
      return getFormEntry(surface) ? { ok: true } : { ok: false, why: 'not a canonical form key' };
    case 'page': {
      const full = resolve(repoRoot, surface);
      if (!existsSync(full)) return { ok: false, why: 'file does not exist' };
      return statSync(full).isFile() ? { ok: true } : { ok: false, why: 'not a file' };
    }
    default:
      return { ok: false, why: `unknown surface kind '${kind}'` };
  }
}

describe('completion register: coverage of the authoritative menu', () => {
  it('carries all 198 MENU_DATA entries exactly once', () => {
    expect(items).toHaveLength(198);
    expect(register.counts.items).toBe(198);
    const labels = items.map(label);
    expect(new Set(labels).size).toBe(198);
  });

  it('has classified every entry, so nothing is left unassessed', () => {
    const unclassified = items.filter((it) => it.state === 'unclassified').map(label);
    expect(unclassified).toEqual([]);
  });

  it('uses only states the register itself defines', () => {
    for (const it of items) {
      expect(register.states[it.state], `${label(it)} state '${it.state}'`).toBeDefined();
    }
  });
});

describe('completion register: every surface claim resolves', () => {
  it('resolves each claimed web surface through the real route/master/form registry', () => {
    const failures: string[] = [];
    for (const it of items) {
      if (!it.webSurface) continue;
      const { ok, why } = resolveSurface(it.webSurface.kind, it.webSurface.surface);
      if (!ok)
        failures.push(`${label(it)} -> ${it.webSurface.kind} '${it.webSurface.surface}': ${why}`);
    }
    expect(
      failures,
      'a register that names a surface which does not exist is worse than one that admits it does not know',
    ).toEqual([]);
  });

  it('claims a surface for every state that asserts a web equivalent, and none where it asserts absence', () => {
    const asserts = new Set(['verified', 'implemented-unverified', 'implemented-elsewhere']);
    for (const it of items) {
      if (asserts.has(it.state)) {
        expect(
          it.webSurface,
          `${label(it)} claims '${it.state}' but names no surface`,
        ).toBeTruthy();
      }
      if (it.state === 'absent') {
        expect(it.webSurface, `${label(it)} is absent but carries a surface`).toBeNull();
      }
    }
  });

  it('records the sibling entries wherever several menu actions collapse onto one surface', () => {
    // 52 entries share 21 surfaces. That is the register's most useful warning: a shared surface is where a
    // desktop MODE can silently be missing, and one such pair is already known half-implemented
    // (ExtraTran/Other Expenses is mapped; ExtraTran/Other Income is absent).
    const users = new Map<string, string[]>();
    for (const it of items) {
      if (!it.webSurface) continue;
      const key = `${it.webSurface.kind}:${it.webSurface.surface}`;
      users.set(key, [...(users.get(key) ?? []), label(it)]);
    }
    const shared = [...users.values()].filter((v) => v.length > 1);
    expect(shared.length).toBeGreaterThan(0);
    for (const it of items) {
      if (!it.webSurface) continue;
      const key = `${it.webSurface.kind}:${it.webSurface.surface}`;
      const expected = (users.get(key) ?? []).filter((l) => l !== label(it)).sort();
      expect([...(it.sharedSurfaceWith ?? [])].sort(), `${label(it)} siblings`).toEqual(expected);
    }
  });
});

describe('completion register: the honesty rules WP-04 committed to', () => {
  it('claims nothing as desktop-verified while the desktop comparison is red', () => {
    // The register defines `verified` as "compared or tested". Using it on the strength of web-only tests
    // would be the self-approval this project keeps finding, so WP-04 used it zero times and said so.
    expect(items.filter((it) => it.state === 'verified')).toEqual([]);
    expect(String(register.method?.howEachStateWasAssigned ?? '')).toBeDefined();
  });

  it('excludes nothing from scope on the owner’s behalf', () => {
    // scope-excluded and dead-in-dataset both require evidence a classifier does not have: an owner decision
    // and Live24 row counts respectively.
    expect(items.filter((it) => it.state === 'scope-excluded')).toEqual([]);
    expect(items.filter((it) => it.state === 'dead-in-dataset')).toEqual([]);
  });

  it('marks absent exactly the menus with no web workflow, each with its reason and desktop forms', () => {
    // N85 (G71): these five were mapped to a different workflow (the generic receipt, the approval bill bridge,
    // pledge interest, the pledge khata, the CRM report). Saying so is more useful than a surface that does something else.
    const absent = items.filter((it) => it.state === 'absent');
    expect(absent.map(label).sort()).toEqual([
      'Crm/Cust Entry',
      'Dhiran/Dhrn Os Letter',
      'Dhiran/Loan Intrest',
      'ExtraTran/Card Rec',
      'Karigar/Tour Sales',
    ]);
    for (const it of absent) {
      expect(String(it.note ?? ''), `${label(it)}`).toMatch(
        /^No web surface: .+Desktop form\(s\):/s,
      );
    }
  });

  it('records the method, including what the classification does NOT establish', () => {
    const method = register.method as Record<string, unknown> | undefined;
    expect(method, 'a classification without a recorded method cannot be audited').toBeDefined();
    expect(String(method!.rejectedMethods)).toMatch(/165 of 198/);
    expect(String(method!.whatThisDoesNotEstablish)).toMatch(/behaves like the desktop/);
  });

  it('warns that formReferencedInWeb is wrong in both directions rather than leaving it to be trusted', () => {
    expect(String(register.caveat)).toMatch(/wrong in both directions/);
  });
});
