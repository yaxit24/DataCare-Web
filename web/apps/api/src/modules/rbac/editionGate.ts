import {
  EDITION_NAMES,
  formAvailability,
  formTier,
  type EditionCode,
  type EditionPolicy,
} from '@datacare/core';

/**
 * The edition gate of the API (N171, D31).
 *
 * The desktop shows a menu only in its edition and above (`MDI_FORM.cs:11249-11322` filters `MENU_DATA` by
 * `SM_TYPE`). The web hides those menus in its navigation, and the API refuses their routes, so a screen of a higher
 * edition cannot be used by calling its API either. The gate is off unless the deployment configures an edition
 * (`APP_EDITION`), which keeps the test harnesses running every edition's suites.
 */
export interface EditionRefusal {
  error: 'edition-unavailable';
  form: string;
  edition: EditionCode;
}

/**
 * Configuration reads every edition's screens need, so the gate never refuses them (D33). The desktop loads CO_SET into
 * its globals when a company opens, in every edition (`MS_OPNCOMP.cs:657-684`), and each voucher screen reads those
 * globals; the Settings menu that edits them (UT_SETTING) is a Basic menu. Their rights check still applies.
 */
export const EDITION_EXEMPT_ROUTES: ReadonlySet<string> = new Set([
  'GET /settings',
  'GET /integrations/device-settings',
]);

/** The refusal for `form` under `policy`, or null when the form may be used (or no gate is configured). */
export function editionRefusal(
  form: string,
  policy: EditionPolicy | null | undefined,
): EditionRefusal | null {
  if (!policy) return null;
  return formAvailability(form, policy) === 'unavailable'
    ? { error: 'edition-unavailable', form, edition: policy.code }
    : null;
}

/**
 * The refusal for a feature that exists in every edition except Lite (D36: the Lite rights grid is hidden and every right is
 * seeded Y, `MS_USER.cs:1489-1495`), or null outside Lite / without a configured edition.
 */
export function aboveLiteRefusal(
  form: string,
  policy: EditionPolicy | null | undefined,
): EditionRefusal | null {
  return policy && policy.code === 'L'
    ? { error: 'edition-unavailable', form, edition: policy.code }
    : null;
}

/**
 * The Ledger Report's Debit Ageing is a view of `GET /reports/account-ledger` (and its exports), not a path of its own, so
 * the route table cannot classify it. Lite refuses it: the desktop hides the Time Wise button there
 * (`RP_LEDR.cs:4589 {{((Control)BtnTimeWise).Visible = false;}}`, WP-20 D-20-1). The two account-in-path aliases force the
 * detail view and are never ageing.
 */
const LEDGER_AGEING_URLS: ReadonlySet<string> = new Set([
  '/reports/account-ledger',
  '/reports/account-ledger/export.pdf',
  '/reports/account-ledger/export.xlsx',
  '/reports/account-ledger/export.csv',
]);

/** The refusal for an ageing-view request of the Ledger Report in Lite, or null. */
export function ledgerAgeingRefusal(
  url: string | undefined,
  query: unknown,
  policy: EditionPolicy | null | undefined,
): EditionRefusal | null {
  if (!url || !LEDGER_AGEING_URLS.has(url)) return null;
  const view = String((query as Record<string, unknown> | null | undefined)?.view ?? '')
    .trim()
    .toLowerCase();
  return view === 'ageing' ? aboveLiteRefusal('Reports/Account Ledger', policy) : null;
}

/** A route's static rights form must be classified, or a gated deployment refuses to start. */
export function assertFormClassified(form: string): void {
  if (form.startsWith('@')) return; // dynamic (@master, @report): checked per request after resolution
  if (formTier(form) === undefined)
    throw new Error(
      `edition-table-missing-form: ${form} (classify it in docs/handbook/web-route-editions.json)`,
    );
}

/** What `/me` reports, so the screens can hide and guard the same menus. */
export function editionDescriptor(
  policy: EditionPolicy | null | undefined,
): { code: EditionCode; name: string; beta: boolean } | null {
  return policy ? { code: policy.code, name: EDITION_NAMES[policy.code], beta: policy.beta } : null;
}
