import { hash, verify } from '@node-rs/argon2';

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

/** Security upgrade over the plaintext desktop password: long, mixed-class, and bounded. */
export function assertStrongPassword(plain: string): void {
  const reasons: string[] = [];
  if (plain.length < 12) reasons.push('min-12');
  if (plain.length > 128) reasons.push('max-128');
  if (!/[a-z]/.test(plain)) reasons.push('lowercase');
  if (!/[A-Z]/.test(plain)) reasons.push('uppercase');
  if (!/[0-9]/.test(plain)) reasons.push('number');
  if (!/[^A-Za-z0-9]/.test(plain)) reasons.push('symbol');
  if (reasons.length) throw new PasswordPolicyError(reasons);
}
