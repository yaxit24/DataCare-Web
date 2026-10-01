import { spawnSync } from 'node:child_process';
import { mkdtempSync, readFileSync, rmSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join, resolve } from 'node:path';
import { afterAll, describe, expect, it } from 'vitest';

/**
 * N85 / G71: `scripts/check-completion-register.mjs` requires every register row to agree with the menu catalog,
 * whose forms `docs/tools/docs_check.py` verifies against the `MDI_FORM.cs` dispatch and whose surfaces it
 * verifies against the code. The real register passes; a planted wrong form or wrong surface fails.
 */
const web = resolve(__dirname, '..', '..', '..');
const script = resolve(web, 'scripts', 'check-completion-register.mjs');
const register = JSON.parse(readFileSync(resolve(web, 'docs', 'COMPLETION-REGISTER.json'), 'utf8'));
const dir = mkdtempSync(join(tmpdir(), 'register-check-'));
afterAll(() => rmSync(dir, { recursive: true, force: true }));

const run = (registerPath?: string) =>
  spawnSync(process.execPath, [script, ...(registerPath ? ['--register', registerPath] : [])], {
    cwd: web,
    encoding: 'utf8',
  });

const planted = (name: string, change: (item: any) => void, menu: string) => {
  const copy = structuredClone(register);
  const item = copy.items.find((it: any) => `${it.tab}/${it.menu}` === menu);
  change(item);
  const path = join(dir, `${name}.json`);
  writeFileSync(path, JSON.stringify(copy));
  return path;
};

describe('completion register agrees with the dispatch-verified menu catalog', () => {
  it('passes on the corrected register', () => {
    const result = run();
    expect(result.status, result.stdout + result.stderr).toBe(0);
    expect(result.stdout).toContain('REGISTER_OK');
  });

  it('fails on a desktop form the dispatch does not open', () => {
    const result = run(
      planted('form', (it) => (it.desktopForms = ['MS_PRODUCT']), 'Master/Design Book'),
    );
    expect(result.status).toBe(1);
    expect(result.stdout).toContain(
      'Master/Design Book: desktop forms [MS_PRODUCT] differ from the dispatch [MS_DESIGN_BOOK]',
    );
  });

  it('fails on a web surface the menu does not use', () => {
    const result = run(
      planted(
        'surface',
        (it) => (it.webSurface = { kind: 'master', surface: 'styles' }),
        'Master/Style',
      ),
    );
    expect(result.status).toBe(1);
    expect(result.stdout).toContain(
      "Master/Style: web surface master 'styles' is not one the menu uses",
    );
  });
});
