/** @type {import('next').NextConfig} */
const API = process.env.API_ORIGIN || 'http://localhost:4000';
const nextConfig = {
  reactStrictMode: true,
  async rewrites() {
    // Proxy API calls through the Next origin so httpOnly auth cookies stay same-origin.
    return [{ source: '/api/:path*', destination: `${API}/:path*` }];
  },
};
export default nextConfig;
