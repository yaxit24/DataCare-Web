import tseslint from 'typescript-eslint';
import reactHooks from 'eslint-plugin-react-hooks';

/**
 * ESLint configuration.
 *
 * WHY THIS EXISTS
 * ===============
 * The repository had NO ESLint at all. `pnpm lint` ran `scripts/lint-workspace.mjs` — a custom secret
 * scanner plus a set of project-specific AST assertions — and then `tsc`. Both are useful and both stay,
 * but neither can see a React hook dependency mistake, so an entire class of bug was undetected.
 *
 * It let this ship in the primary reporting surface
 * (`apps/web/app/(app)/reports/[report]/page.tsx`):
 *
 *     const run = useCallback(async () => {
 *       const ep = endpointFor(slug, coYear, acCode, fromDate, toDate, { ...filters, lotNo, tagNo, ... });
 *       ...
 *     }, [slug, coYear, acCode]);        //  fromDate/toDate/filters/lotNo/tagNo NOT listed
 *
 * with the Run button bound straight to that memoised callback. Changing a date or a filter did not
 * recreate the callback, so Run submitted STALE filter values. On a GST return that means the operator
 * selects one period and silently receives another — the failure is invisible because the request succeeds.
 *
 * SCOPE IS DELIBERATELY NARROW
 * ============================
 * Only the `react-hooks` rules are enabled, as errors. This is not a style pass: introducing hundreds of
 * cosmetic findings across 422 files would bury the correctness signal and stall the gate. Formatting is
 * already owned by Prettier and project invariants by lint-workspace.mjs. More rules can be added later,
 * one at a time, each with its own justification.
 */
export default tseslint.config(
  {
    ignores: [
      '**/node_modules/**',
      '**/dist/**',
      '**/.next/**',
      '**/.turbo/**',
      '**/coverage/**',
      '**/*.d.ts',
      '**/*.d.mts',
    ],
  },
  {
    files: ['apps/web/**/*.{ts,tsx}'],
    plugins: { 'react-hooks': reactHooks },
    languageOptions: {
      parser: tseslint.parser,
      parserOptions: { ecmaFeatures: { jsx: true } },
    },
    rules: {
      // The rule that catches the stale-closure defect above.
      'react-hooks/exhaustive-deps': 'error',
      'react-hooks/rules-of-hooks': 'error',
    },
  },
);
