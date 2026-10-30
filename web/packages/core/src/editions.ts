/**
 * Desktop editions and what each one shows (slice N171, decision D31).
 *
 * The desktop keeps its edition in `DC_Main.MsSoftType`: L Lite, B Basic, S Standard, U Ultra, P Pro, A Advance,
 * E Enterprise. Editions are cumulative: the MDI loads only the `MENU_DATA` rows whose `SM_TYPE` is the running
 * edition or a lower one (`MDI_FORM.cs:11249-11322`). The web reproduces that with one generated table
 * (`editionTable.ts`) giving every web route and every rights form the lowest edition that shows it.
 *
 * `platform` marks web pages that belong to no desktop menu but every edition needs (the shell, audit log,
 * registration): they are always available.
 */
import { FORM_EDITION, ROUTE_EDITION } from './editionTable.js';

export type EditionCode = 'L' | 'B' | 'S' | 'U' | 'P' | 'A' | 'E';
export type EditionTier = EditionCode | 'platform';

/** Lowest to highest; an edition includes every edition to its left. */
export const EDITION_ORDER: readonly EditionCode[] = Object.freeze([
  'L',
  'B',
  'S',
  'U',
  'P',
  'A',
  'E',
]);

export const EDITION_NAMES: Readonly<Record<EditionCode, string>> = Object.freeze({
  L: 'Lite',
  B: 'Basic',
  S: 'Standard',
  U: 'Ultra',
  P: 'Pro',
  A: 'Advance',
  E: 'Enterprise',
});

/** The running edition, and whether the editions above it are opened for internal use as Beta. */
export interface EditionPolicy {
  code: EditionCode;
  beta: boolean;
}

/** `available` in the running edition; `beta` only because Beta is on; `unavailable` otherwise. */
export type EditionAvailability = 'available' | 'beta' | 'unavailable';

export function isEditionCode(value: unknown): value is EditionCode {
  return typeof value === 'string' && (EDITION_ORDER as readonly string[]).includes(value);
}

/** Whether something of `tier` is shown in the `running` edition. */
export function tierIncluded(tier: EditionTier, running: EditionCode): boolean {
  if (tier === 'platform') return true;
  return EDITION_ORDER.indexOf(tier) <= EDITION_ORDER.indexOf(running);
}

function availability(tier: EditionTier | undefined, policy: EditionPolicy): EditionAvailability {
  // Fail closed: something the table does not know is not shown. The generator and its tests make the table
  // cover every navigation route, page and rights form, so this only refuses what nobody classified.
  if (tier === undefined) return 'unavailable';
  if (tierIncluded(tier, policy.code)) return 'available';
  return policy.beta ? 'beta' : 'unavailable';
}

/** The tier of a rights form (`Main/Sub`, as in the route policy and the form catalog). */
export function formTier(form: string): EditionTier | undefined {
  return FORM_EDITION[form];
}

export function formAvailability(form: string, policy: EditionPolicy): EditionAvailability {
  return availability(formTier(form), policy);
}

/** The tier of a web page, by its path (query string ignored). */
export function routeTier(path: string): EditionTier | undefined {
  const pathname = (path.split('?')[0] ?? '').replace(/\/+$/, '') || '/';
  return ROUTE_EDITION[pathname];
}

export function routeAvailability(path: string, policy: EditionPolicy): EditionAvailability {
  return availability(routeTier(path), policy);
}
