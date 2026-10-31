import { describe, expect, it, vi } from 'vitest';
import {
  PHASE_DEVELOPMENT_SERVER,
  PHASE_PRODUCTION_BUILD,
  PHASE_PRODUCTION_SERVER,
} from 'next/constants.js';

vi.mock('../scripts/clearRouteCache.mjs', () => ({ clearRouteCache: vi.fn() }));

describe('next.config route cache (G218)', () => {
  it('clears the route cache when the production server starts, and only then', async () => {
    const { clearRouteCache } = await import('../scripts/clearRouteCache.mjs');
    const { default: config } = await import('../next.config.mjs');
    config(PHASE_PRODUCTION_BUILD);
    config(PHASE_DEVELOPMENT_SERVER);
    expect(clearRouteCache).not.toHaveBeenCalled();
    const resolved = config(PHASE_PRODUCTION_SERVER);
    expect(clearRouteCache).toHaveBeenCalledTimes(1);
    expect(resolved.reactStrictMode).toBe(true);
  });
});
