/**
 * Types for `secret-scanner.mjs`, which the security tests import directly. See `load-profile.d.mts` for why a
 * sibling declaration rather than an ambient module block.
 */
export function findPlausibleSecretLiterals(text: string, path?: string): unknown[];
export function isPlausibleSecretValue(value: string): boolean;
