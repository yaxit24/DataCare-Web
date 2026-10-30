import { describe, expect, it } from 'vitest';
import {
  DEFAULT_DEV_SECRET,
  RuntimeConfigError,
  resolveRuntimeConfig,
} from '../src/modules/ops/runtimeConfig.js';

describe('runtime configuration', () => {
  it('keeps explicit development defaults local-only', () => {
    const cfg = resolveRuntimeConfig({ NODE_ENV: 'development' });
    expect(cfg.isProduction).toBe(false);
    expect(cfg.jwtSecret).toBe(DEFAULT_DEV_SECRET);
    expect(cfg.port).toBe(3000);
    expect(cfg.secureCookies).toBe(false);
    expect(cfg.logger).toBe(false);
    expect(cfg.seedDemo).toBe(false);
    expect(cfg.demoPassword).toBeUndefined();
  });

  it('accepts a complete production configuration', () => {
    const cfg = resolveRuntimeConfig({
      NODE_ENV: 'production',
      PORT: '4000',
      DATABASE_URL: 'postgresql://app_user:strong@db:5432/datacare',
      JWT_SECRET: 'a-random-production-key-with-more-than-32-characters',
      APP_TENANT_ID: 'tenant-1',
      DEMO_TENANT: 'demo-tenant',
      SEED_DEMO: '0',
    });
    expect(cfg.isProduction).toBe(true);
    expect(cfg.port).toBe(4000);
    expect(cfg.secureCookies).toBe(true);
    expect(cfg.logger).toBe(true);
    expect(cfg.seedDemo).toBe(false);
    expect(cfg.tenantId).toBe('tenant-1');
    expect(cfg.demoTenant).toBe('demo-tenant');
  });

  it.each([
    [{ NODE_ENV: 'production' }, 'DATABASE_URL is required'],
    [
      {
        NODE_ENV: 'production',
        DATABASE_URL: 'postgresql://db',
        JWT_SECRET: DEFAULT_DEV_SECRET,
      },
      'known weak/default',
    ],
    [
      {
        NODE_ENV: 'production',
        DATABASE_URL: 'postgresql://db',
        JWT_SECRET: 'short',
      },
      'at least 32',
    ],
    [
      {
        NODE_ENV: 'production',
        DATABASE_URL: 'postgresql://db',
        JWT_SECRET: 'a-random-production-key-with-more-than-32-characters',
        SEED_DEMO: '1',
      },
      'SEED_DEMO',
    ],
    [
      {
        NODE_ENV: 'production',
        DATABASE_URL: 'postgresql://db',
        JWT_SECRET: 'a-random-production-key-with-more-than-32-characters',
        MESSAGING_FAKE_MODE: '1',
      },
      'MESSAGING_FAKE_MODE',
    ],
  ])('rejects unsafe production input %#', (env, expected) => {
    expect(() => resolveRuntimeConfig(env)).toThrow(RuntimeConfigError);
    expect(() => resolveRuntimeConfig(env)).toThrow(expected);
  });

  it('rejects an invalid port in every environment', () => {
    expect(() => resolveRuntimeConfig({ NODE_ENV: 'development', PORT: 'not-a-port' })).toThrow(
      'PORT',
    );
  });

  it('rejects a deployment tenant outside the tenant_id database contract', () => {
    expect(() =>
      resolveRuntimeConfig({
        NODE_ENV: 'development',
        APP_TENANT_ID: 'tenant-id-that-is-longer-than-twenty-four-characters',
      }),
    ).toThrow('APP_TENANT_ID');
  });

  it('requires an external password when development demo seeding is enabled', () => {
    expect(() => resolveRuntimeConfig({ NODE_ENV: 'development', SEED_DEMO: '1' })).toThrow(
      'DEMO_PASSWORD',
    );
    expect(
      resolveRuntimeConfig({
        NODE_ENV: 'development',
        SEED_DEMO: '1',
        DEMO_PASSWORD: 'provided-at-runtime',
      }).seedDemo,
    ).toBe(true);
  });
});

describe('desktop edition (N171)', () => {
  it('defaults to Standard with Beta off', () => {
    expect(resolveRuntimeConfig({ NODE_ENV: 'development' }).edition).toEqual({
      code: 'S',
      beta: false,
    });
  });
  it('reads APP_EDITION (any case) and APP_EDITION_BETA', () => {
    expect(
      resolveRuntimeConfig({ NODE_ENV: 'development', APP_EDITION: 'e', APP_EDITION_BETA: '1' })
        .edition,
    ).toEqual({ code: 'E', beta: true });
  });
  it('refuses an unknown edition', () => {
    expect(() => resolveRuntimeConfig({ NODE_ENV: 'development', APP_EDITION: 'X' })).toThrow(
      /APP_EDITION must be one of L, B, S, U, P, A, E/,
    );
  });
});
