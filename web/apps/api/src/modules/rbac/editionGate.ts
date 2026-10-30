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
