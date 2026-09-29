/**
 * The report slug as it may appear in an API path.
 *
 * The slug comes from the URL, so it is reduced to kebab-case characters before it is placed in an API
 * path. That keeps `/`, `?` and `..` out of the request.
 *
 * Digits are part of real slugs. The former `/[^a-z-]/g` turned `gstr2` into `gstr` and `gstr3b` into
 * `gstrb`, so the GSTR-2 and GSTR-3B screens requested routes that do not exist and showed nothing
 * (PARITY-EVALUATION-2026-09-28 D2).
 */
export function reportApiSlug(slug: string): string {
  return String(slug ?? '').replace(/[^a-z0-9-]/g, '');
}
