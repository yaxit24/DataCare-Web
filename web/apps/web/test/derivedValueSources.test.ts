import { describe, expect, it } from 'vitest';
import { readdirSync, readFileSync, statSync } from 'node:fs';
import { join } from 'node:path';

/**
 * Structural guard: no page may compute a weight or money figure with its own arithmetic.
 *
 * WHY THIS IS A TEST AND NOT A CODE REVIEW NOTE
 * The sales page shipped a local `calc` that disagreed with the server four ways at once — fine
 * rounded to 2dp where `PRECISION.fine` is 3, wastage dropped from the fine base, per-gram labour
 * missing its ghat term, and local rounding instead of the money kernel. The operator was shown a
 * total that was not the total that posted. Six further pages rounded fine to 2dp the same way.
 *
 * Every one of those was individually plausible and individually invisible. A one-time fix does not
 * stop the next page from doing it again, so the rule is enforced here: fine weight comes from
 * `fineWeight` (or the `recalcLine` kernel that wraps it), never from an inline `/ 100`.
 */
const TXN = join(__dirname, '..', 'app', '(app)', 'txn');

const pages = (): Array<{ slug: string; src: string }> =>
  readdirSync(TXN)
    .filter((d) => statSync(join(TXN, d)).isDirectory())
    .map((slug) => {
      const file = join(TXN, slug, 'page.tsx');
      try {
        return { slug, src: readFileSync(file, 'utf8') };
      } catch {
        return { slug, src: '' };
      }
    })
    .filter((p) => p.src !== '');

describe('no page computes fine weight with its own arithmetic', () => {
  it('finds transaction pages to check', () => {
    expect(pages().length).toBeGreaterThan(40);
  });

  it('never rounds fine weight to 2dp, which would disagree with PRECISION.fine = 3', () => {
    // `r2(... touch ... / 100)` is the exact shape that shipped on seven pages.
    const offenders = pages()
      .filter(({ src }) =>
        /r2\(\s*\(?n\([^)]*\)\s*\*\s*n\([^)]*touch[^)]*\)\)?\s*\/\s*100/i.test(src),
      )
      .map((p) => p.slug);
    expect(offenders).toEqual([]);
  });

  it('derives fine weight through the shared WORKFLOW POLICY, not the generic helper', () => {
    // Routing to core's generic fineWeight(net, touch) was NOT enough: it fixed precision but still
    // omitted ghat, while every sale/purchase policy in finePolicy.ts uses (net + ghat) x pct. A live
    // sale return posted ITM_FINE 5.065 where such a preview showed 4.605. The rule is therefore
    // fineFor(workflow, ...) — the server's own policy table — or the recalcLine kernel that wraps it.
    const offenders = pages()
      .filter(({ src }) => /\bn\(l\.touch\)\s*\)?\s*\/\s*100/.test(src))
      .filter(({ src }) => !src.includes('fineFor') && !src.includes('recalcLine'))
      .map((p) => p.slug);
    expect(offenders).toEqual([]);
  });

  it('never computes per-gram labour from net weight alone on a page that carries ghat', () => {
    // The money defect this guards: per-gram labour is (net + ghat) x rate, because LBR_WITH_GHT's
    // desktop blank default is 'Y'. The server was fixed first, which left previews on pages that DO
    // send ghtWt understating labour by ghat x rate against the figure that actually posts.
    //
    // Scoped to pages carrying ghat on purpose. A page with no ghat field multiplying netWt by a rate
    // is correct — ghat is structurally zero there — and flagging it would be a false positive that
    // pushes pointless churn.
    const offenders = pages()
      .filter(({ src }) => /\bghtWt\b/.test(src))
      .filter(({ src }) => /n\([lr]\.netWt\)\s*\*\s*n\([lr]\.making\)/.test(src))
      .map((p) => p.slug);
    expect(offenders).toEqual([]);
  });
});
