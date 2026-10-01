import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

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
export default nextConfig;
