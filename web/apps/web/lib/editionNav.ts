import { routeAvailability, type EditionPolicy } from '@datacare/core';
import type { NavGroup, NavItem } from './nav';

/**
 * Navigation for the running desktop edition (N171, D31).
 *
 * The desktop builds its menus from the `MENU_DATA` rows of its edition (`MDI_FORM.cs:11249-11322`), so a Standard
 * shop never sees a Pro, Advance or Enterprise menu. Items of a higher edition are dropped; when Beta is on they are
 * collected into a separate Beta list instead, so internal users can still reach them without mixing them into the
 * Standard menus. Without an edition (no gate configured) the navigation is unchanged.
 */
export interface BetaNavItem extends NavItem {
  /** The navigation group the item belongs to, kept so the rights form resolves as before. */
  group: string;
}

export interface EditionNav {
  groups: NavGroup[];
  beta: BetaNavItem[];
}

export function editionNav(nav: NavGroup[], edition: EditionPolicy | null | undefined): EditionNav {
  if (!edition) return { groups: nav, beta: [] };
  const groups: NavGroup[] = [];
  const beta: BetaNavItem[] = [];
  for (const group of nav) {
    const items: NavItem[] = [];
    for (const item of group.items) {
      const availability = routeAvailability(item.href, edition);
      if (availability === 'available') items.push(item);
      else if (availability === 'beta') beta.push({ ...item, group: group.label });
    }
    if (items.length) groups.push({ label: group.label, items });
  }
  return { groups, beta };
}

/** The rights form of a navigation item, as the Shell and the API name it. */
export const navItemForm = (group: string, item: NavItem): string =>
  item.form ?? `${group}/${item.label}`;
