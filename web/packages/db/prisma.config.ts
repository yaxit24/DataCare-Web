import { existsSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { defineConfig } from 'prisma/config';

// Prisma 7 no longer loads .env automatically. Keep the package-local developer file compatible while
// allowing CI/deployment environment variables to win; never require a URL for validate/generate.
const envFile = fileURLToPath(new URL('.env', import.meta.url));
if (existsSync(envFile)) process.loadEnvFile(envFile);

const databaseUrl = process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL;

export default defineConfig({
  schema: 'prisma/schema.prisma',
  migrations: { path: 'prisma/migrations' },
  datasource: databaseUrl ? { url: databaseUrl } : undefined,
});
