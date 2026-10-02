import { describe, expect, it } from 'vitest';
import {
  parityTestIdentityChanges,
  parityTestPort,
  parityTestProject,
} from '../../../scripts/lib/parity-test-env-lib.mjs';

/** N49 step 3: per-worktree Compose projects, a configurable port and the identity re-check. */
describe('parity test environment helpers', () => {
  it('derives a stable, distinct project per checkout path, and honours a valid override', () => {
    const a = parityTestProject('/work/dc-wt/a/web');
    expect(a).toMatch(/^datacare-parity-[0-9a-f]{12}$/);
    expect(parityTestProject('/work/dc-wt/a/web')).toBe(a);
    expect(parityTestProject('/work/dc-wt/b/web')).not.toBe(a);
    expect(parityTestProject('/work/dc-wt/a/web', ' ci-run_7 ')).toBe('ci-run_7');
    for (const bad of ['CI', '-x', 'a b', 'a/b', 'x'.repeat(64)])
      expect(() => parityTestProject('/w', bad), bad).toThrow(/PARITY_TEST_PROJECT/);
  });

  it('defaults to 55433, accepts another port, and refuses the application port or junk', () => {
    expect(parityTestPort(undefined)).toBe('55433');
    expect(parityTestPort(' 55533 ')).toBe('55533');
    expect(() => parityTestPort('5433')).toThrow('application database port');
    for (const bad of ['80', '70000', 'abc', '5543.3', '-1'])
      expect(() => parityTestPort(bad), bad).toThrow(/1024 to 65535/);
  });

  it('reports a replaced or removed container and a different cluster', () => {
    const before = { containerId: 'c1', systemIdentifier: '7691' };
    expect(parityTestIdentityChanges(before, { ...before })).toEqual([]);
    expect(
      parityTestIdentityChanges(before, { containerId: 'c2', systemIdentifier: '7691' }),
    ).toEqual(['container c1 was replaced by c2']);
    expect(parityTestIdentityChanges(before, { containerId: '', systemIdentifier: '' })).toEqual([
      'container c1 is gone',
      'system identifier 7691 became (unreadable)',
    ]);
    expect(
      parityTestIdentityChanges(before, { containerId: 'c1', systemIdentifier: '8000' }),
    ).toEqual(['system identifier 7691 became 8000']);
  });
});
