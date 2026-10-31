import { isEditionCode, type EditionPolicy } from '@datacare/core';

export interface RuntimeConfig {
  isProduction: boolean;
  port: number;
  jwtSecret: string;
  databaseUrl?: string;
  tenantId: string;
  demoTenant: string;
  demoPassword?: string;
  seedDemo: boolean;
  secureCookies: boolean;
  logger: boolean;
  /**
   * The desktop edition this deployment runs (APP_EDITION) and whether Beta is on (N171). The default is Lite (D33):
   * Lite is the edition being completed, so the menus of Basic and above stay behind Beta until their turn.
   */
  edition: EditionPolicy;
}

const DEFAULT_DEV_SECRET = 'dev-secret-change-me';
const WEAK_SECRET_PATTERNS = [DEFAULT_DEV_SECRET, 'change-me', 'changeme', 'secret', 'password'];

const isEnabled = (value: string | undefined): boolean =>
  ['1', 'true', 'yes', 'on'].includes(
    String(value ?? '')
      .trim()
      .toLowerCase(),
  );

export class RuntimeConfigError extends Error {
  constructor(public readonly problems: string[]) {
    super(`unsafe runtime configuration: ${problems.join('; ')}`);
    this.name = 'RuntimeConfigError';
  }
}

/**
 * Resolve process configuration before creating clients or opening a port.
 * Production deliberately fails closed; development retains the historical local defaults.
 */
export function resolveRuntimeConfig(env: NodeJS.ProcessEnv = process.env): RuntimeConfig {
  const isProduction = env.NODE_ENV === 'production';
  const port = Number(env.PORT ?? (isProduction ? '4000' : '3000'));
  const suppliedSecret = env.JWT_SECRET?.trim();
  const jwtSecret = suppliedSecret || DEFAULT_DEV_SECRET;
  const seedDemo = isEnabled(env.SEED_DEMO);
  const demoPassword = env.DEMO_PASSWORD?.trim();
  const tenantId = env.APP_TENANT_ID?.trim() || env.DEMO_TENANT?.trim() || 'default';
  const problems: string[] = [];

  if (!/^[A-Za-z0-9][A-Za-z0-9_-]{0,23}$/.test(tenantId)) {
    problems.push('APP_TENANT_ID must be 1-24 letters, numbers, underscores or hyphens');
  }

  if (!Number.isInteger(port) || port < 1 || port > 65_535) {
    problems.push('PORT must be an integer between 1 and 65535');
  }

  if (seedDemo && !demoPassword)
    problems.push('DEMO_PASSWORD is required when SEED_DEMO is enabled');

  const editionCode = env.APP_EDITION?.trim().toUpperCase() || 'L';
  if (!isEditionCode(editionCode)) problems.push('APP_EDITION must be one of L, B, S, U, P, A, E');

  if (isProduction) {
    if (!env.DATABASE_URL?.trim()) problems.push('DATABASE_URL is required');
    if (!suppliedSecret) problems.push('JWT_SECRET is required');
    if (jwtSecret.length < 32) problems.push('JWT_SECRET must contain at least 32 characters');
    const normalized = jwtSecret.toLowerCase();
    if (WEAK_SECRET_PATTERNS.some((value) => normalized === value || normalized.includes(value))) {
      problems.push('JWT_SECRET uses a known weak/default value');
    }
    if (seedDemo) problems.push('SEED_DEMO cannot be enabled in production');
    // N54 step 4 / G33: the simulating message sender is test-only. senderFromEnv already ignores the flag in
    // production; refusing to start makes the misconfiguration visible instead of silently refusing sends.
    if (env.MESSAGING_FAKE_MODE === '1')
      problems.push('MESSAGING_FAKE_MODE cannot be enabled in production');
  }

  if (problems.length) throw new RuntimeConfigError(problems);

  return {
    isProduction,
    port,
    jwtSecret,
    databaseUrl: env.DATABASE_URL?.trim() || undefined,
    tenantId,
    demoTenant: env.DEMO_TENANT?.trim() || tenantId,
    demoPassword,
    seedDemo,
    secureCookies: isProduction,
    logger: isProduction,
    edition: {
      code: isEditionCode(editionCode) ? editionCode : 'L',
      beta: isEnabled(env.APP_EDITION_BETA),
    },
  };
}

export { DEFAULT_DEV_SECRET };
