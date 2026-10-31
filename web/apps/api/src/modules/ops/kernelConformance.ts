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
  /**
   * A line-independent identity for the site, `<concern>:<path>#<fingerprint>`.
   *
   * For a rounding helper the fingerprint is the binding name (`round2`, `r3`, `money`, `f0`), so moving the
   * declaration up or down a file does not change the identity. For an inline `BOOK_DETL` read, which has no
   * name, the fingerprint is a short hash of the normalised matched line. Either kind gets a `~<ordinal>`
   * suffix when the same fingerprint occurs more than once in one file, so two `r2` helpers in the same module
   * stay distinct and stable in declaration order.
   */
  siteId: string;
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
  Object.freeze({
    id: 'date-normalization',
    title: 'Date sliced from its string form',
    kernel: '@datacare/core toIsoDate (transport) or formatDesktopDate (display, dd/MM/yyyy)',
    why:
      'String() of a JavaScript Date is "Thu Oct 01 2026 …", so slicing ten characters drops the year ' +
      '(G36: the printed tax invoice showed no year); D19 transports YYYY-MM-DD and displays dd/MM/yyyy',
    exempt: Object.freeze(['packages/core/dates.ts']),
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
/** `String(x.VCH_DATE).slice(0, 10)`, `text(h.vd ?? '').slice(0, 10)` and the like: a date read by slicing its text. */
const DATE_SLICE =
  /\b(?:String|text|t|str)\([^()]*(?:[A-Z_]*DATE[A-Z_]*|\b[vtf]d\b|[Dd]ate)[^()]*\)\.slice\(0, ?10\)/;

const isExempt = (concern: KernelConcern, path: string): boolean =>
  concern.exempt.some((e) => path === e || path.endsWith(`/${e}`));
/** The binding name of a helper declaration, so its identity survives moving within a file. */
const BINDING_NAME =
  /^\s*(?:export\s+)?(?:const|let|var)\s+(\w+)\s*(?::|=)|^\s*(?:export\s+)?function\s+(\w+)\s*\(/;

/** A short, stable hash of a string. Used to fingerprint an unnamed `BOOK_DETL` read line. */
function fingerprintOf(text: string): string {
  // Normalise whitespace so reformatting (Prettier line wraps) does not change the identity.
  const normalised = text.replace(/\s+/g, ' ').trim();
  let hash = 2166136261 >>> 0; // FNV-1a 32-bit
  for (let i = 0; i < normalised.length; i += 1) {
    hash ^= normalised.charCodeAt(i);
    hash = Math.imul(hash, 16777619) >>> 0;
  }
  return hash.toString(16).padStart(8, '0');
}

/** The name a rounding helper is bound to, or `anon` for an arrow with no binding on its own line. */
function helperName(declarationLine: string): string {
  const m = BINDING_NAME.exec(declarationLine);
  return m ? (m[1] ?? m[2] ?? 'anon') : 'anon';
}

/**
 * Assign a `<concern>:<path>#<fingerprint>` identity to each bypass, with a `~<ordinal>` suffix when the same
 * fingerprint repeats in one file. Ordinals follow declaration order (the scan order), so two `r2` helpers in
 * one module keep a fixed, line-independent identity.
 */
function assignSiteIds(
  bypasses: Array<KernelBypass & { fingerprint: string }>,
): Array<KernelBypass & { fingerprint: string }> {
  const seen = new Map<string, number>();
  return bypasses.map((b) => {
    const base = `${b.concern}:${b.path}#${b.fingerprint}`;
    const n = (seen.get(base) ?? 0) + 1;
    seen.set(base, n);
    return { ...b, siteId: n > 1 ? `${base}~${n}` : base };
  });
}

/** Find every bypass of a kernel primitive, each carrying a stable, line-independent site identity. */
export function findBypasses(files: readonly KernelSourceFile[]): KernelBypass[] {
  const raw: Array<KernelBypass & { fingerprint: string }> = [];
  const rounding = KERNEL_CONCERNS.find((c) => c.id === 'rounding')!;
  const bookAccount = KERNEL_CONCERNS.find((c) => c.id === 'book-account')!;
  const dateNormalization = KERNEL_CONCERNS.find((c) => c.id === 'date-normalization')!;

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
          const declarationLine = declaresHere ? line : previous;
          raw.push({
            concern: rounding.id,
            path: file.path,
            line: i + 1,
            snippet: (declaresHere ? line : `${previous.trim()} … ${line.trim()}`)
              .trim()
              .slice(0, 110),
            fingerprint: helperName(declarationLine),
            siteId: '',
          });
        }
      }
    }

    if (!isExempt(bookAccount, file.path)) {
      for (let i = 0; i < lines.length; i += 1) {
        const line = lines[i] ?? '';
        if (BOOK_DETL.test(line)) {
          raw.push({
            concern: bookAccount.id,
            path: file.path,
            line: i + 1,
            snippet: line.trim().slice(0, 110),
            fingerprint: fingerprintOf(line),
            siteId: '',
          });
        }
      }
    }
    if (!isExempt(dateNormalization, file.path)) {
      for (let i = 0; i < lines.length; i += 1) {
        const line = lines[i] ?? '';
        if (DATE_SLICE.test(line)) {
          raw.push({
            concern: dateNormalization.id,
            path: file.path,
            line: i + 1,
            snippet: line.trim().slice(0, 110),
            fingerprint: fingerprintOf(line),
            siteId: '',
          });
        }
      }
    }
  }
  // Strip the transient `fingerprint` field after it has done its job in the identity.
  return assignSiteIds(raw).map(({ fingerprint: _f, ...rest }) => rest as KernelBypass);
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

  // Retained for the characterisation unit tests only. The CI gate no longer uses a count ceiling: it
  // compares site identities against the checked-in baseline through `compareToBaseline`, which is what
  // `scripts/check-kernel-conformance.mjs` and `kernelConformance.test.ts` both run (N48, G22).
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

/**
 * The checked-in baseline, `parity/kernel-conformance-baseline.json`. It records the scanned roots, the
 * exemptions, the concern rule set and — the point of N48 — the exact grandfathered site IDs. A site not in
 * the baseline fails (an addition can no longer hide behind an unrelated removal); a baseline site that no
 * longer exists also fails, with an instruction to delete its ID in the same change.
 */
export interface KernelBaseline {
  /** How the baseline was built; prose, not machine-read. */
  description: string;
  /** `apps/api/src` and `packages/core/src`, so moving a file between them does not change the answer. */
  scannedRoots: readonly string[];
  /** The kernel files that legitimately contain the pattern, by concern. */
  exemptions: Record<string, readonly string[]>;
  /** The grandfathered site IDs that are allowed to remain until burned down. */
  sites: readonly string[];
}

export interface KernelBaselineComparison {
  verdict: 'ok' | 'red';
  /** Live site IDs that are not in the baseline — a new bypass. */
  added: string[];
  /** Baseline site IDs that no longer exist — must be deleted from the baseline. */
  removed: string[];
  /** Human-readable failure lines, ready to print. */
  problems: string[];
  /** Every live site ID, sorted, so a reviewer can diff. */
  liveSites: string[];
}

/**
 * Compare the live bypass set against the checked-in baseline by site identity.
 *
 * This replaces the total-count ratchet. A count-based gate let an addition hide behind an unrelated removal:
 * delete one `round2`, add one `r3` elsewhere, and the total was unchanged. Identity makes both moves visible.
 */
export function compareToBaseline(
  files: readonly KernelSourceFile[],
  baseline: KernelBaseline,
): KernelBaselineComparison {
  const liveSet = new Set(findBypasses(files).map((b) => b.siteId));
  const baselineSet = new Set(baseline.sites);

  const added = [...liveSet].filter((id) => !baselineSet.has(id)).sort();
  const removed = [...baselineSet].filter((id) => !liveSet.has(id)).sort();

  const problems: string[] = [];
  for (const id of added) {
    const kernel =
      KERNEL_CONCERNS.find((c) => id.startsWith(`${c.id}:`))?.kernel ?? 'the kernel primitive';
    problems.push(
      `NEW bypass not in the baseline: ${id} — use ${kernel}, or, if a reviewed grandfathered exception, ` +
        `add the exact site ID to parity/kernel-conformance-baseline.json with a note`,
    );
  }
  for (const id of removed) {
    problems.push(
      `baseline site no longer exists: ${id} — delete this ID from ` +
        `parity/kernel-conformance-baseline.json in the same change (the burn-down is working)`,
    );
  }

  return {
    verdict: problems.length ? 'red' : 'ok',
    added,
    removed,
    problems,
    liveSites: [...liveSet].sort(),
  };
}
