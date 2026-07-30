import { describe, it, expect } from 'vitest';
import {
  assertStrongPassword,
  PasswordPolicyError,
  hashPassword,
  verifyPassword,
  isHashed,
  verifyWithMigration,
} from '../src/modules/auth/password.js';

describe('password', () => {
  it('hashes (argon2) and verifies', async () => {
    const h = await hashPassword('s3cret');
    expect(isHashed(h)).toBe(true);
    expect(await verifyPassword(h, 's3cret')).toBe(true);
    expect(await verifyPassword(h, 'wrong')).toBe(false);
  });

  it('migrates plaintext legacy on match (forcedReset=true)', async () => {
    expect(await verifyWithMigration('plain123', 'plain123')).toEqual({
      ok: true,
      forcedReset: true,
    });
    expect(await verifyWithMigration('plain123', 'nope')).toEqual({
      ok: false,
      forcedReset: false,
    });
  });

  it('hashed verify has no forcedReset', async () => {
    const h = await hashPassword('abc');
    expect(await verifyWithMigration(h, 'abc')).toEqual({ ok: true, forcedReset: false });
  });
});

it('requires a long mixed-class password for creation and reset', () => {
  expect(() => assertStrongPassword('Strong-Password-2026')).not.toThrow();
  expect(() => assertStrongPassword('short')).toThrow(PasswordPolicyError);
});
