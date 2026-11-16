import { hash, verify } from '@node-rs/argon2';
import { COMMON_PASSWORDS } from './commonPasswords.js';

/** Argon2id hash for new/reset passwords. */
export async function hashPassword(plain: string): Promise<string> {
  return hash(plain);
}

export async function verifyPassword(stored: string, candidate: string): Promise<boolean> {
  try {
    return await verify(stored, candidate);
  } catch {
    return false;
  }
}

export function isHashed(stored: string): boolean {
  return typeof stored === 'string' && stored.startsWith('$argon2');
}

/**
 * Desktop `LOGIN_MAST.LOGIN_PWD` is stored as PLAINTEXT. On login:
 *  - if already hashed → verify with Argon2.
 *  - if plaintext and it matches → authenticate but flag `forcedReset` so the app rehashes
 *    and forces a password change (ADR-0001 security upgrade).
 */
export async function verifyWithMigration(
  stored: string,
  candidate: string,
): Promise<{ ok: boolean; forcedReset: boolean }> {
  if (isHashed(stored)) {
    return { ok: await verifyPassword(stored, candidate), forcedReset: false };
  }
  const ok = stored === candidate;
  return { ok, forcedReset: ok };
}

export class PasswordPolicyError extends Error {
  constructor(public reasons: string[]) {
    super(`weak-password: ${reasons.join(',')}`);
    this.name = 'PasswordPolicyError';
  }
}

/** The account a password is set for: its own login name and company code are denied (D34). */
export interface PasswordContext {
  loginName?: string | null;
  coCode?: string | null;
}

export const PASSWORD_MIN_LENGTH = 8;
export const PASSWORD_MAX_LENGTH = 128;

/**
 * True when the password is built from `word` plus digits and symbols only ("01010101", "Ramesh@2026" for RAMESH).
 * A login name of four or more letters is refused anywhere in the password.
 */
function builtFrom(lowered: string, word: string, anywhere: boolean): boolean {
  if (!word || !lowered.includes(word)) return false;
  if (anywhere) return true;
  return !/\p{L}/u.test(lowered.split(word).join(''));
}

/**
 * D34 (document 12 §4): the desktop accepts any password (MS_USER.cs:1981); the web asks only what an internet login
 * needs, following NIST SP 800-63B: at least 8 characters with no composition rules, at most 128, not a common
 * password, not built from the account's own login name or company code. Returns the refusal reasons, in order.
 */
export function passwordProblems(plain: string, context: PasswordContext = {}): string[] {
  const value = typeof plain === 'string' ? plain : '';
  const reasons: string[] = [];
  if (value.length < PASSWORD_MIN_LENGTH) reasons.push('min-8');
  if (value.length > PASSWORD_MAX_LENGTH) reasons.push('max-128');
  const lowered = value.trim().toLowerCase();
  if (COMMON_PASSWORDS.has(lowered)) reasons.push('common-password');
  const login = String(context.loginName ?? '')
    .trim()
    .toLowerCase();
  if (login && builtFrom(lowered, login, login.length >= 4)) reasons.push('login-name');
  const company = String(context.coCode ?? '')
    .trim()
    .toLowerCase();
  if (company && builtFrom(lowered, company, company.length >= 4)) reasons.push('company-code');
  return reasons;
}

/** Throws PasswordPolicyError with every D34 reason the password breaks. */
export function assertStrongPassword(plain: string, context: PasswordContext = {}): void {
  const reasons = passwordProblems(plain, context);
  if (reasons.length) throw new PasswordPolicyError(reasons);
}
