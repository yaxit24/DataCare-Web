import { describe, it, expect } from 'vitest';
import {
  quoteIdent,
  isSafeIdent,
  assertSafeIdent,
  UnsafeIdentifierError,
} from '../src/modules/security/sql.js';

describe('sql identifier safety', () => {
  it('quotes a normal identifier', () => {
    expect(quoteIdent('AC_DATA')).toBe('"AC_DATA"');
  });
  it('strips an injection payload', () => {
    expect(quoteIdent('AC_DATA"; DROP TABLE x;--')).toBe('"AC_DATADROPTABLEx"');
    expect(quoteIdent('a b; delete')).toBe('"abdelete"');
  });
  it('throws when nothing safe remains', () => {
    expect(() => quoteIdent('"; --')).toThrow(UnsafeIdentifierError);
  });
  it('isSafeIdent distinguishes safe vs unsafe', () => {
    expect(isSafeIdent('SL_DATA')).toBe(true);
    expect(isSafeIdent('1bad')).toBe(false);
    expect(isSafeIdent('a;b')).toBe(false);
  });
  it('assertSafeIdent rejects unsafe input-derived names', () => {
    expect(assertSafeIdent('VCH_NO')).toBe('VCH_NO');
    expect(() => assertSafeIdent('x; drop')).toThrow(UnsafeIdentifierError);
  });
});

describe('workspace secret literal policy', () => {
  it('finds plausible assigned credentials and ignores placeholders or environment reads', async () => {
    const { findPlausibleSecretLiterals } = await import('../../../scripts/secret-scanner.mjs');
    const findings = findPlausibleSecretLiterals(
      [
        "const apiKey = 'sk_live_51QwertyLongValue';",
        'const password = process.env.APP_PASSWORD;',
        "const jwtSecret = 'dev-secret-change-me';",
        "const token = '<from-secret-store>';",
      ].join('\n'),
      'probe.ts',
    );
    expect(findings).toHaveLength(1);
    expect(findings[0]).toMatchObject({ line: 1, name: 'apiKey' });
  });

  it('does not mistake a desktop-parity UI message for a credential', async () => {
    const { findPlausibleSecretLiterals } = await import('../../../scripts/secret-scanner.mjs');
    // These live under names containing PASSWORD/SECRET because that is what the desktop guards are
    // about; the values are operator-facing prose, not tokens.
    const findings = findPlausibleSecretLiterals(
      [
        "const OLD_PASSWORD_REQUIRED = 'Please Insert Old Password';",
        "const MAIL_SECRET_MESSAGE = 'Please Update Company Mail Id and Api Then Try...';",
      ].join('\n'),
      'probe.ts',
    );
    expect(findings).toEqual([]);
  });

  it('still reports a real secret even when it contains spaces', async () => {
    const { isPlausibleSecretValue } = await import('../../../scripts/secret-scanner.mjs');
    // Prose is only excused when it has no encoded-looking separators or long alnum runs.
    expect(isPlausibleSecretValue('my super secret token abc123XYZ+/=')).toBe(true);
    expect(isPlausibleSecretValue('postgres://user:pw@host:5432/db')).toBe(true);
    expect(isPlausibleSecretValue('aGVsbG8gd29ybGQgdGhpcyBpcyBiYXNlNjQ=')).toBe(true);
    expect(isPlausibleSecretValue('Parity#Pass1')).toBe(true);
    expect(isPlausibleSecretValue('Please Insert Old Password')).toBe(false);
  });
});
