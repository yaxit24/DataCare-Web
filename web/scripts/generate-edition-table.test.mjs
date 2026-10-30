import assert from 'node:assert/strict';
import { test } from 'node:test';
import { buildEditionTable, loadInputs, lowerTier } from './generate-edition-table.mjs';

const menuEditions = {
  menus: [
    { visible: true, separator: false, catalogId: 'T/Sales', edition: 'L' },
    { visible: true, separator: false, catalogId: 'T/Sl Quotation', edition: 'B' },
    { visible: true, separator: false, catalogId: 'D/Dhrn Issue', edition: 'P' },
    { visible: false, separator: false, catalogId: 'M/Hidden', edition: 'L' },
  ],
};
const catalog = [
  { id: 'T/Sales', ui: ['/txn/sales', '/txn/hallmark-sale'] },
  { id: 'T/Sl Quotation', ui: ['/txn/sales'] },
  { id: 'D/Dhrn Issue', ui: ['/txn/dhrn-issue'] },
  { id: 'M/Hidden', ui: ['/masters/hidden'] },
];
const nav = [
  { group: 'Sales', label: 'Sales Invoice', href: '/txn/sales', form: 'Sales/Sales Invoice' },
  { group: 'Loans', label: 'Pledge Issue', href: '/txn/dhrn-issue', form: 'Loans/Pledge Issue' },
];

test('a route takes the lowest edition of the visible menus it serves; hidden menus are ignored', () => {
  const t = buildEditionTable({ menuEditions, catalog, overrides: {}, nav, pages: [] });
  assert.deepEqual(t.problems, []);
  assert.equal(t.routes['/txn/sales'], 'L');
  assert.equal(t.routes['/txn/dhrn-issue'], 'P');
  assert.equal(t.routes['/masters/hidden'], undefined);
  assert.equal(t.forms['Sales/Sales Invoice'], 'L');
  assert.equal(t.forms['Loans/Pledge Issue'], 'P');
});

test('an unclassified navigation item or page is a problem, never a silent default', () => {
  const t = buildEditionTable({
    menuEditions,
    catalog,
    overrides: {},
    nav: [...nav, { group: 'X', label: 'New', href: '/txn/new', form: 'X/New' }],
    pages: ['/txn/orphan'],
  });
  assert.ok(t.problems.some((p) => p.includes('/txn/new')));
  assert.ok(t.problems.some((p) => p.includes('page /txn/orphan')));
});

test('an override needs a known edition and a reason, and may not shadow a catalog-mapped route', () => {
  const t = buildEditionTable({
    menuEditions,
    catalog,
    overrides: {
      routes: {
        '/txn/sales': { edition: 'E', reason: 'stale' },
        '/txn/new': { edition: 'Z', reason: 'x' },
        '/txn/other': { edition: 'S' },
      },
    },
    nav,
    pages: [],
  });
  assert.ok(t.problems.some((p) => p.includes('/txn/sales is redundant')));
  assert.ok(t.problems.some((p) => p.includes('/txn/new: unknown edition')));
  assert.ok(t.problems.some((p) => p.includes('/txn/other: a reason is required')));
});

test('lowerTier orders editions and treats platform as always shown', () => {
  assert.equal(lowerTier('S', 'B'), 'B');
  assert.equal(lowerTier('E', undefined), 'E');
  assert.equal(lowerTier('P', 'platform'), 'platform');
});

test('the committed inputs build without problems (every route, page and form classified)', async () => {
  const t = buildEditionTable(await loadInputs());
  assert.deepEqual(t.problems, []);
});
