/**
 * SQL identity safety. The codebase always passes VALUES as parameterized `$n` placeholders; only
 * identifiers (table/column names — internal constants) are interpolated. This is the canonical
 * sanitizer used to quote those identifiers, defending against injection even if an identifier ever
 * derived from input (e.g. /masters/:name). Strips everything except [A-Za-z0-9_] then double-quotes.
 */

export class UnsafeIdentifierError extends Error {
  constructor(public ident: string) {
    super(`unsafe SQL identifier: ${ident}`);
    this.name = 'UnsafeIdentifierError';
  }
}

/** True if the identifier contains only safe characters (no quoting needed to be safe). */
export function isSafeIdent(name: string): boolean {
  return /^[A-Za-z_][A-Za-z0-9_]*$/.test(name);
}

/** Sanitize + double-quote an identifier (strips any injection payload). */
export function quoteIdent(name: string): string {
  const clean = String(name).replace(/[^A-Za-z0-9_]/g, '');
  if (!clean) throw new UnsafeIdentifierError(name);
  return `"${clean}"`;
}

/** Strict variant: reject (don't silently strip) an unsafe identifier — for input-derived names. */
export function assertSafeIdent(name: string): string {
  if (!isSafeIdent(name)) throw new UnsafeIdentifierError(name);
  return name;
}
