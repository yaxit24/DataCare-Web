/**
 * Types for `load-profile.mjs`, which tests import directly.
 *
 * The gate scripts are plain ESM JavaScript with no build step, so a typechecked test importing one is an
 * implicit `any` (TS7016). A sibling declaration is the resolution TypeScript actually uses for a RELATIVE
 * import - an ambient `declare module` with a relative specifier does not apply, which is worth stating because
 * that was tried first and silently changed nothing.
 *
 * Loose on purpose: this exists so the checker can run over the tests. The tests assert on real return values.
 */
export function percentile(values: number[], p: number): number;
export function summarizeResults(results: unknown[]): Record<string, unknown>;
