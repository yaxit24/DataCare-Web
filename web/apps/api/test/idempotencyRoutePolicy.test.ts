import { readFileSync, readdirSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { routePolicyFor } from '../src/modules/rbac/routePolicy.js';
import {
  canonicalJson,
  IDEMPOTENT_CREATE_ROUTES,
  idempotencyGuardedRoutes,
  parseIdempotencyKey,
  requestSha256,
} from '../src/modules/shared/idempotency.js';

/**
 * N52 (G29, D18; LITE-MASTER-PLAN WP-04): the voucher create routes that must carry the Idempotency-Key guard, and
 * the pages that must send the key. Restated here on purpose, independently of IDEMPOTENT_CREATE_ROUTES: removing a
 * route from that list, renaming its path, or a page dropping the header fails this file.
 *
 * Every other voucher create route (a POST whose policy is a create right on a non-master, non-utility form) is
 * listed in NOT_YET_GUARDED, the WP-04 follow-up queue. A new voucher create route must be added to one of the two,
 * so it cannot appear unguarded without a decision; guarding a queued route means moving it to GUARDED.
 */
const here = dirname(fileURLToPath(import.meta.url));
const web = resolve(here, '../../web');

const GUARDED: Record<string, { page: string; sends: RegExp }> = {
  'POST /stock/stock-adjust': {
    page: 'components/TagCancelForm.tsx',
    sends: /postCommand<[^>]*>\(\s*cfg\.endpoint,\s*body,\s*command\.key\s*\)/,
  },
  'POST /stock/tag-cancel': {
    page: 'components/TagCancelForm.tsx',
    sends: /postCommand<[^>]*>\(\s*cfg\.endpoint,\s*body,\s*command\.key\s*\)/,
  },
  'POST /receipts': {
    page: 'components/PaymentForm.tsx',
    sends: /postCommand<[^>]*>\(\s*ep,\s*singleBody,\s*command\.key\s*\)/,
  },
  'POST /payments': {
    page: 'components/PaymentForm.tsx',
    sends: /postCommand<[^>]*>\(\s*ep,\s*singleBody,\s*command\.key\s*\)/,
  },
  'POST /receipts/multi': {
    page: 'components/PaymentForm.tsx',
    sends: /postCommand<[^>]*>\(\s*`\$\{ep\}\/multi`,[\s\S]*?command\.key,?\s*\)/,
  },
  'POST /payments/multi': {
    page: 'components/PaymentForm.tsx',
    sends: /postCommand<[^>]*>\(\s*`\$\{ep\}\/multi`,[\s\S]*?command\.key,?\s*\)/,
  },
};

/** WP-04 follow-ups, in the plan's order first (Contra, Sales, Sales Order, ... Tag Cancel), then the rest. */
const NOT_YET_GUARDED = [
  'POST /contra',
  'POST /sales',
  'POST /sales-orders',
  'POST /sales-returns',
  'POST /purchases',
  'POST /purchase-returns',
  'POST /wholesale-sales',
  'POST /fine-jv',
  'POST /ac-opbl',
  'POST /bill-to-bill/settle',
  'POST /bullion-sales',
  'POST /bullion/booking',
  'POST /card-receipts',
  'POST /consignment-purchases',
  'POST /daily-rate',
  'POST /dhrn/interest',
  'POST /dhrn/issue',
  'POST /dhrn/receipt',
  'POST /e-credit-notes',
  'POST /e-invoices',
  'POST /employee-jv',
  'POST /estimate',
  'POST /finance/gold-book',
  'POST /finance/location-amount',
  'POST /finance/vp-adjustment',
  'POST /fine-sale',
  'POST /inout/fine',
  'POST /journal',
  'POST /karigar/issue',
  'POST /karigar/receive',
  'POST /labour-invoice',
  'POST /ledger-adjust',
  'POST /loan/issue',
  'POST /loan/received',
  'POST /melting',
  'POST /members',
  'POST /members/points',
  'POST /mfg/issue',
  'POST /mfg/jobwork-issue',
  'POST /mfg/jobwork-receive',
  'POST /mfg/order-issue',
  'POST /mfg/receive',
  'POST /old-item-sales',
  'POST /other-commission',
  'POST /other-income',
  'POST /other-purchase',
  'POST /purchase-quotations',
  'POST /rate-cut',
  'POST /receipts/batch',
  'POST /repair-customer-issues',
  'POST /repair-karigar-issues',
  'POST /repair-karigar-receipts',
  'POST /repair-receipts',
  'POST /sales-orders/:vchNo/cancel-refund',
  'POST /sales-quotations',
  'POST /sales/vp-parcel',
  'POST /sales/wholesale-sale-return',
  'POST /scheme/enroll',
  'POST /scheme/gold-adjust',
  'POST /scheme/installment',
  'POST /scheme/maturity',
  'POST /scheme/opening',
  'POST /stock/counter-transfer',
  'POST /stock/in',
  'POST /stock/item-lot',
  'POST /stock/item-opening',
  'POST /stock/out',
  'POST /stock/physical-stock',
  'POST /stock/stone-dm-cf',
  'POST /stock/tag-adjust',
  'POST /stock/tag-opening',
  'POST /stock/tag-split',
  'POST /stock/tag-transfer',
  'POST /stock/tag-weight-diff',
  'POST /stock/tags',
  'POST /tour-orders',
  'POST /tour-sales',
  'POST /tour/issue',
  'POST /tour/return',
  'POST /wholesale-quotations',
];

const routePattern = /\b(?:app|server)\.(post)\(\s*(['"`])([^'"`]+)\2/g;

/** POST routes whose policy is a create right on a voucher form (not a master, `@master` or a utility). */
function voucherCreateRoutes(): string[] {
  const routeDir = resolve(here, '../src/routes');
  const found = new Set<string>();
  for (const file of [
    resolve(here, '../src/app.ts'),
    ...readdirSync(routeDir)
      .filter((name) => name.endsWith('.ts'))
      .map((name) => resolve(routeDir, name)),
  ]) {
    for (const match of readFileSync(file, 'utf8').matchAll(routePattern)) {
      const policy = routePolicyFor('POST', match[3]!);
      if (
        policy?.kind === 'form' &&
        policy.action === 'create' &&
        !/^(Masters\/|Utilities\/|@master$)/.test(String(policy.form))
      )
        found.add(`POST ${match[3]}`);
    }
  }
  return [...found].sort();
}

describe('N52 Idempotency-Key route policy', () => {
  it('guards exactly the listed voucher creates, and every other voucher create is queued', () => {
    const declared = IDEMPOTENT_CREATE_ROUTES.map((route) => `${route.method} ${route.url}`).sort();
    expect(declared).toEqual(Object.keys(GUARDED).sort());
    const creates = voucherCreateRoutes();
    for (const route of Object.keys(GUARDED)) expect(creates).toContain(route);
    expect(NOT_YET_GUARDED.filter((route) => route in GUARDED)).toEqual([]);
    expect(creates.filter((route) => !(route in GUARDED)).sort()).toEqual(
      [...NOT_YET_GUARDED].sort(),
    );
  });

  it('wraps every guarded route as the app registers it', async () => {
    const app = await buildApp({ prisma: {} as never, secret: 'idempotency-policy-test-secret' });
    try {
      await app.ready();
      expect([...idempotencyGuardedRoutes(app)].sort()).toEqual(Object.keys(GUARDED).sort());
    } finally {
      await app.close();
    }
  });

  it.each(Object.entries(GUARDED))('the page behind %s sends the draft key', (_route, sender) => {
    const source = readFileSync(resolve(web, sender.page), 'utf8');
    expect(source).toMatch(/useIdempotencyKey\(\)/);
    expect(source).toMatch(sender.sends);
    expect(source).toMatch(/command\.renew\(\)/);
  });

  it('accepts only 1-128 visible ASCII characters as a key', () => {
    expect(parseIdempotencyKey('0b8e3b9e-2f5c-4a43-9f43-6d1c2f0a9b11')).toBe(
      '0b8e3b9e-2f5c-4a43-9f43-6d1c2f0a9b11',
    );
    expect(parseIdempotencyKey('k'.repeat(128))).toBe('k'.repeat(128));
    for (const bad of ['', 'k'.repeat(129), 'with space', 'tab\t', 'é', undefined, ['a', 'b']])
      expect(parseIdempotencyKey(bad as never)).toBeNull();
  });

  it('hashes the request independently of key order, and binds user, scope, route and body', () => {
    expect(canonicalJson({ b: 1, a: [{ d: 2, c: null }], z: undefined })).toBe(
      '{"a":[{"c":null,"d":2}],"b":1}',
    );
    const base = {
      method: 'POST',
      route: '/receipts',
      actor: 'clerk',
      coCode: '01',
      lcCode: '01',
      coYear: '2026-2027',
      body: { amount: 10, partyAc: 'C1' },
    };
    const hash = requestSha256(base);
    expect(hash).toMatch(/^[0-9a-f]{64}$/);
    expect(requestSha256({ ...base, body: { partyAc: 'C1', amount: 10 } })).toBe(hash);
    for (const changed of [
      { actor: 'other' },
      { coCode: '02' },
      { lcCode: '02' },
      { coYear: '2025-2026' },
      { route: '/payments' },
      { body: { amount: 11, partyAc: 'C1' } },
    ])
      expect(requestSha256({ ...base, ...changed })).not.toBe(hash);
  });
});
