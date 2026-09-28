/**
 * Static analysis: every transaction page must post to the endpoint for the desktop voucher family it claims.
 *
 * WHY THIS FILE EXISTS
 * ====================
 * Three pages were found rendering a correctly-labelled form that posted to a DIFFERENT family's endpoint.
 * The request succeeded, so nothing surfaced an error — the voucher was simply written into the wrong family:
 *
 *   1. txn/wholesale-sale        posted '/sales'          (retail) instead of a wholesale endpoint
 *   2. txn/jobwork-issue         posted '/karigar/issue'  instead of '/mfg/jobwork-issue'
 *   3. txn/jobwork-receive       posted '/karigar/receive' instead of '/mfg/jobwork-receive'
 *
 * (2) and (3) happened because the shared component hardcoded the karigar endpoint while the `label` prop
 * changed only the heading. Desktop TR_JDT_REC writes MFG_DATA/MFG_DETL/MFG_IDTL, so the manufacturing
 * endpoints are the correct target; mfg.ts cites TR_JDT_REC.cs directly.
 *
 * A page that writes a valid voucher into the wrong family is worse than a missing feature: it is invisible.
 * These assertions are deliberately literal string checks over the page/component sources so that renaming a
 * label can never again change what gets written.
 */
import { readFile } from 'node:fs/promises';
import { describe, expect, it } from 'vitest';

const WEB = new URL('../../web/', import.meta.url);
const page = (p: string) => readFile(new URL(`app/(app)/txn/${p}/page.tsx`, WEB), 'utf8');
const component = (c: string) => readFile(new URL(`components/${c}`, WEB), 'utf8');

describe('job-work pages post to the manufacturing family, not karigar', () => {
  it('the shared form derives its endpoint from the family, not from a hardcoded constant', async () => {
    const src = await component('KarigarForm.tsx');
    expect(src).toContain("'/mfg/jobwork-issue'");
    expect(src).toContain("'/mfg/jobwork-receive'");
    expect(src).toContain("family === 'jobwork'");
    // The regression was a single unconditional assignment. If the endpoint is ever computed only from
    // `mode` again, the jobwork branch disappears and the assertions above fail.
    expect(src).not.toMatch(/const ep =\s*mode === 'issue' \? '\/karigar\/issue'/);
  });

  it.each([
    ['jobwork-issue', 'issue'],
    ['jobwork-receive', 'receive'],
  ])('%s declares family="jobwork"', async (dir, mode) => {
    const src = await page(dir);
    expect(src).toContain('family="jobwork"');
    expect(src).toContain(`mode="${mode}"`);
  });

  it.each([
    ['karigar-issue', 'issue'],
    ['karigar-receive', 'receive'],
  ])('%s stays on the karigar family (no regression)', async (dir, mode) => {
    const src = await page(dir);
    expect(src).toContain(`mode="${mode}"`);
    expect(src).not.toContain('family="jobwork"');
  });
});

describe('the wholesale-sale page does not post to the retail sales endpoint', () => {
  it('does not post to /sales', async () => {
    const src = await page('wholesale-sale');
    // Desktop TR_WH_SALE has a write set retail sale cannot produce (a purchase grid writing PR_FINE,
    // PR_NET_AMT, PR_TOT_AMT, SILVER_FINE, BAG_WT). Posting it to /sales stores a retail voucher.
    expect(src).not.toMatch(/post\(\s*'\/sales'/);
  });
});

describe('no transaction page posts to another family by accident', () => {
  /** page directory -> the path fragment its POST must contain. */
  const EXPECTED: Record<string, string> = {
    'jobwork-issue': '/mfg/jobwork-issue',
    'jobwork-receive': '/mfg/jobwork-receive',
    'karigar-issue': '/karigar/issue',
    'karigar-receive': '/karigar/receive',
  };

  it('each shared-component page resolves to its own endpoint', async () => {
    const form = await component('KarigarForm.tsx');
    for (const [dir, expected] of Object.entries(EXPECTED)) {
      const src = await page(dir);
      const isJobwork = src.includes('family="jobwork"');
      const resolved = expected.startsWith('/mfg/');
      expect(isJobwork, `${dir} must ${resolved ? '' : 'not '}declare the jobwork family`).toBe(
        resolved,
      );
      expect(form, `${expected} must be reachable from the shared form`).toContain(`'${expected}'`);
    }
  });
});
