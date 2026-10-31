import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { PHASE_PRODUCTION_SERVER } from 'next/constants.js';
import { clearRouteCache } from './scripts/clearRouteCache.mjs';

/** @type {import('next').NextConfig} */
const API = process.env.API_ORIGIN || 'http://localhost:4000';
const nextConfig = {
  reactStrictMode: true,
  // The pnpm workspace (web/) is the root for build file tracing. Without this, Next.js infers the root from
  // whichever lockfile it finds first above the app, which on a developer machine can be an unrelated one.
  outputFileTracingRoot: resolve(dirname(fileURLToPath(import.meta.url)), '..', '..'),
  async rewrites() {
    // Proxy API calls through the Next origin so httpOnly auth cookies stay same-origin.
    return [{ source: '/api/:path*', destination: `${API}/:path*` }];
  },
};

/**
 * N205 (G218): the production server starts from an empty route cache. The build clears it (N186), but a build that
 * turbo restores from its cache replays the build's log without running that step, so the pages a previous server
 * cached survived and a fresh `next start` served them (`x-nextjs-cache: HIT` with a chunk from an older build).
 */
export default function config(phase) {
  if (phase === PHASE_PRODUCTION_SERVER) clearRouteCache();
  return nextConfig;
}
