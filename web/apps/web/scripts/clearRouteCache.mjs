// N186 (G197): Next.js 15.5 keeps the pages a running server has served in .next/server/route-cache, and `next build`
// leaves that directory in place. The next `next start` then served the previous build's pages (seen as
// `x-nextjs-cache: HIT` with the old page chunk), so a local browser run after a rebuild tested old code.
// The build clears it, so every server started after a build serves that build.
import { rmSync } from 'node:fs';
import { fileURLToPath } from 'node:url';

export function clearRouteCache(appDir = fileURLToPath(new URL('..', import.meta.url))) {
  rmSync(`${appDir}/.next/server/route-cache`, { recursive: true, force: true });
}

if (process.argv[1] && fileURLToPath(import.meta.url) === process.argv[1]) clearRouteCache();
