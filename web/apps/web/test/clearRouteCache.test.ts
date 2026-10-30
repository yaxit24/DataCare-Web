import { existsSync, mkdirSync, mkdtempSync, writeFileSync } from 'node:fs';
import { tmpdir } from 'node:os';
import { join } from 'node:path';
import { describe, expect, it } from 'vitest';
import { clearRouteCache } from '../scripts/clearRouteCache.mjs';

describe('clearRouteCache (G197)', () => {
  it('removes the route cache a previous server wrote and leaves the build output', () => {
    const app = mkdtempSync(join(tmpdir(), 'route-cache-'));
    mkdirSync(join(app, '.next/server/route-cache/APP_PAGE/x/$/txn'), { recursive: true });
    writeFileSync(join(app, '.next/server/route-cache/APP_PAGE/x/$/txn/sales.html'), 'old build');
    mkdirSync(join(app, '.next/server/app/txn'), { recursive: true });
    writeFileSync(join(app, '.next/server/app/txn/sales.html'), 'new build');
    clearRouteCache(app);
    expect(existsSync(join(app, '.next/server/route-cache'))).toBe(false);
    expect(existsSync(join(app, '.next/server/app/txn/sales.html'))).toBe(true);
  });

  it('does nothing when there is no route cache', () => {
    const app = mkdtempSync(join(tmpdir(), 'route-cache-'));
    clearRouteCache(app);
    expect(existsSync(join(app, '.next'))).toBe(false);
  });
});
