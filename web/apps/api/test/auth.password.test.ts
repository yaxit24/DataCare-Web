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

/** The reasons a password is refused for, or [] when D34 accepts it. */
const reasons = (plain: string, context = {}) => {
  try {
    assertStrongPassword(plain, context);
    return [];
  } catch (error) {
    expect(error).toBeInstanceOf(PasswordPolicyError);
    return (error as PasswordPolicyError).reasons;
  }
};

/**
 * D34 (document 12 §4): the desktop accepts any password (MS_USER.cs:1981). The web keeps the desktop flow and adds only
 * what an internet login needs (NIST SP 800-63B): at least 8 characters, no composition rules, at most 128, and a
 * deny-list of common passwords and of the account's own login name and company code.
 */
describe('D34 password rule', () => {
  const account = { loginName: 'RAMESH', coCode: '01' };

  it('accepts 8 characters of one class: no composition rules', () => {
    expect(reasons('tulsibag', account)).toEqual([]);
    expect(reasons('48291736', account)).toEqual([]);
    expect(reasons('correct horse battery staple', account)).toEqual([]);
  });

  it('refuses fewer than 8 characters', () => {
    expect(reasons('tulsiba', account)).toEqual(['min-8']);
    expect(reasons('', account)).toEqual(['min-8']);
  });

  it('refuses more than 128 characters', () => {
    expect(reasons('k'.repeat(129), account)).toEqual(['max-128']);
    expect(reasons('k'.repeat(128), account)).toEqual([]);
  });

  it('refuses a common password whatever its case', () => {
    expect(reasons('password', account)).toEqual(['common-password']);
    expect(reasons('PassWord123', account)).toEqual(['common-password']);
    expect(reasons('12345678', account)).toEqual(['common-password']);
  });

  it("refuses the account's own login name, alone or with digits and symbols, and a 4+ letter name anywhere", () => {
    expect(reasons('ramesh12', account)).toEqual(['login-name']);
    expect(reasons('Ramesh@2026', account)).toEqual(['login-name']);
    expect(reasons('myrameshkey', account)).toEqual(['login-name']);
    // A short name is refused only as the whole word plus digits/symbols, not inside an unrelated word.
    expect(reasons('abc-2026-xyz', { loginName: 'ABC' })).toEqual([]);
    expect(reasons('abc20262026', { loginName: 'ABC' })).toEqual(['login-name']);
  });

  it('refuses a password built from the company code and digits or symbols only', () => {
    expect(reasons('01010101', account)).toEqual(['company-code']);
    expect(reasons('2026-01-01', account)).toEqual(['company-code']);
    expect(reasons('kesar-01-shop', account)).toEqual([]);
  });

  it('without an account context only the length and common-password rules apply', () => {
    expect(reasons('ramesh12')).toEqual([]);
    expect(reasons('short')).toEqual(['min-8']);
  });
});
