/**
 * Compatibility kernel conformance (WP-06).
 *
 * WP-06's exit criterion is "shared conformance suite is used by every in-scope posting family; no
 * module-local posting fallback". The surprise on measuring it is that the kernel largely EXISTS — the gap is
 * adoption, and nothing measured adoption:
 *
 *   * Rounding. `packages/core/src/money.ts` provides exact-decimal `round` (half-up, away from zero) and
 *     `roundHalfEven` (the .NET `Math.Round` default), and `modules/shared/roundingPolicy.ts` resolves the
 *     per-company `TAX_ROF`/`LBR_ROF`/`TOT_AMT_ROF` flags. Yet **105 module-local rounding helpers** across 67
 *     files reimplement it as `Math.round((n + eps) * 100) / 100`, with two different epsilons.
 *   * Book account resolution. `bookPolicy.resolveBookAccountTx` and `postingAccounts.resolveBookSlotAccountTx`
 *     read `BOOK_DETL` and fail closed. Yet **5 modules** still read `BOOK_DETL` inline, two of them via
 *     byte-identical private copies of the same resolver.
 *
 * WHY A LOCAL COPY IS NOT A STYLE QUESTION HERE
 * =============================================
 * `Math.round((n + eps) * 100) / 100` is not either of the desktop's two measured rounding mechanisms. It is
 * float-based, so it inherits binary representation error that the epsilon is there to paper over — which is
 * why two different epsilons exist, someone hit a case and enlarged the fudge. More seriously, JavaScript's
 * `Math.round` breaks negative ties toward **+∞** (`Math.round(-0.5) === -0`), while .NET half-up breaks them
 * **away from zero** (`-1`). Every one of the 105 helpers therefore rounds negative midpoints the wrong way,
 * and negative midpoints are reachable: kasar, round-off, credit notes, signed metal legs and any `CR − DR`
 * difference. `contractIntegrity`'s golden vectors already pin the two correct behaviours; these helpers
 * implement a third.
 *
 * WHAT THIS DOES AND DOES NOT DO
 * ==============================
 * It measures, reports and ratchets. It does NOT migrate: swapping a local helper for the kernel changes
 * posted values at midpoints, and which kernel function is correct depends on whether the desktop computed
 * that particular figure with `Strings.Format` (half-up, 20,575 sites) or `Math.Round` (half-to-even, 10,306
 * sites). That is a per-formula question answered by a contract and pinned by a golden vector — WP-05 work,
 * not a bulk find-and-replace. Doing it blindly would change money on a guess, which is the failure mode this
 * whole plan exists to prevent.
 */

export interface KernelSourceFile {
  /** Path relative to `apps/api/src`, e.g. `modules/sales/sales.ts`. */
  path: string;
  text: string;
}

export interface KernelConcern {
  id: string;
  title: string;
  /** The primitive that should have been used. */
  kernel: string;
  /** Why a local copy is a correctness problem rather than a duplication problem. */
  why: string;
  /** Files that ARE the kernel, and so may legitimately contain the pattern. */
  exempt: readonly string[];
}

export interface KernelBypass {
  concern: string;
  path: string;
  line: number;
  snippet: string;
}

export interface KernelConformanceReport {
  verdict: 'ok' | 'red';
  concerns: Array<{ concern: KernelConcern; bypasses: number; files: number }>;
  bypasses: KernelBypass[];
  totals: Record<string, number>;
  /** Ceiling breaches, i.e. adoption going backwards. */
  regressions: string[];
}

export const KERNEL_CONCERNS: readonly KernelConcern[] = Object.freeze([
  Object.freeze({
    id: 'rounding',
    title: 'Module-local rounding helper',
    kernel: '@datacare/core round / roundHalfEven, or shared/roundingPolicy.resolveRoundingPolicy',
    why:
      'a float helper with an epsilon fudge is neither of the desktop mechanisms and rounds negative ' +
      'midpoints toward +Infinity instead of away from zero',
    exempt: Object.freeze([
      'modules/shared/roundingPolicy.ts',
      // Parity harnesses deliberately reimplement desktop arithmetic to compare against it.
      'modules/parity/golden.ts',
    ]),
  }),
  Object.freeze({
    id: 'book-account',
    title: 'Inline BOOK_DETL read',
    kernel: 'bookPolicy.resolveBookAccountTx or postingAccounts.resolveBookSlotAccountTx',
    why:
      'the shared resolvers fail closed on a missing, blank or duplicated slot; an inline LIMIT 1 read ' +
      'silently takes the first row and often falls back to a literal',
    exempt: Object.freeze(['modules/shared/bookPolicy.ts', 'modules/shared/postingAccounts.ts']),
  }),
]);

/**
 * A local rounding helper is a FUNCTION-VALUED binding whose body rounds.
 *
 * The distinction matters: `const total = Math.round(x)` is an incidental use inside a calculation, while
 * `const round2 = (n) => Math.round(...)` is a private reimplementation of a kernel primitive. Counting both
 * gave 139 and would have made the number meaningless; counting only helpers gives 105 across 67 files.
 */
const HELPER_DECLARATION =
  /^\s*(?:export\s+)?(?:const\s+\w+\s*(?::[^=\n]*)?=\s*(?:\([^)]*\)|\w+)\s*(?::[^=>\n]*)?=>|function\s+\w+\s*\()/;
const ROUNDS = /Math\.round\(/;
const BOOK_DETL = /FROM\s+"BOOK_DETL"/;

const isExempt = (concern: KernelConcern, path: string): boolean =>
  concern.exempt.some((e) => path === e || path.endsWith(`/${e}`));

/** Find every bypass of a kernel primitive. */
export function findBypasses(files: readonly KernelSourceFile[]): KernelBypass[] {
  const out: KernelBypass[] = [];
  const rounding = KERNEL_CONCERNS.find((c) => c.id === 'rounding')!;
  const bookAccount = KERNEL_CONCERNS.find((c) => c.id === 'book-account')!;

  for (const file of files) {
    const lines = file.text.split('\n');

    if (!isExempt(rounding, file.path)) {
      for (let i = 0; i < lines.length; i += 1) {
        const line = lines[i] ?? '';
        if (!ROUNDS.test(line)) continue;
        const previous = lines[i - 1] ?? '';
        const declaresHere = HELPER_DECLARATION.test(line);
        // A helper whose body sits on the next line, either an arrow continuation
        // (`const money = (v): number =>`) or a block body (`function fine(n) {`).
        const declaresAbove =
          HELPER_DECLARATION.test(previous) && /(?:=>|\(|\{)\s*$/.test(previous.trimEnd());
        if (declaresHere || declaresAbove) {
          out.push({
            concern: rounding.id,
            path: file.path,
            line: i + 1,
            snippet: (declaresHere ? line : `${previous.trim()} … ${line.trim()}`)
              .trim()
              .slice(0, 110),
          });
        }
      }
    }

    if (!isExempt(bookAccount, file.path)) {
      for (let i = 0; i < lines.length; i += 1) {
        if (BOOK_DETL.test(lines[i] ?? '')) {
          out.push({
            concern: bookAccount.id,
            path: file.path,
            line: i + 1,
            snippet: (lines[i] ?? '').trim().slice(0, 110),
          });
        }
      }
    }
  }
  return out;
}

export function auditKernelConformance(
  files: readonly KernelSourceFile[],
  ceilings: Readonly<Record<string, number>>,
): KernelConformanceReport {
  const bypasses = findBypasses(files);
  const totals: Record<string, number> = {};
  const concerns = KERNEL_CONCERNS.map((concern) => {
    const mine = bypasses.filter((b) => b.concern === concern.id);
    totals[concern.id] = mine.length;
    return { concern, bypasses: mine.length, files: new Set(mine.map((b) => b.path)).size };
  });

  // Adoption may improve and may not regress. A new local helper in a voucher module is how the kernel
  // quietly stopped being the kernel the first time.
  const regressions: string[] = [];
  for (const [id, ceiling] of Object.entries(ceilings)) {
    const actual = totals[id] ?? 0;
    if (actual > ceiling) {
      regressions.push(
        `${id}: ${actual} bypasses, above the recorded ceiling of ${ceiling}; use the kernel primitive instead`,
      );
    }
  }

  return {
    verdict: regressions.length ? 'red' : 'ok',
    concerns,
    bypasses,
    totals,
    regressions,
  };
}
