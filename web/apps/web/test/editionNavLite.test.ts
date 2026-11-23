import { readFileSync } from 'node:fs';
import { resolve } from 'node:path';
import { describe, expect, it } from 'vitest';
import { editionNav, navItemForm } from '../lib/editionNav';
import { NAV } from '../lib/nav';

/**
 * WP-55 (D33): a Lite tenant sees exactly the 49 desktop Lite menus (`MENU_DATA` rows with `SM_TYPE` `L`,
 * `MDI_FORM.cs:11249-11322`), under the desktop tabs and with the desktop captions.
 */
const handbook = resolve(__dirname, '../../../../docs/handbook');
const read = (name: string) => readFileSync(resolve(handbook, name), 'utf8');

interface DesktopMenu {
  tab: string;
  menu: string;
  edition: string;
  catalogId: string;
  visible: boolean;
  separator: boolean;
}
const desktop = (JSON.parse(read('menu-editions.json')) as { menus: DesktopMenu[] }).menus.filter(
  (menu) => menu.edition === 'L' && menu.visible && !menu.separator,
);
const catalog = new Map(
  read('menu-catalog.jsonl')
    .split('\n')
    .filter((line) => line.trim())
    .map((line) => JSON.parse(line) as { id: string; ui?: string[] })
    .map((row) => [row.id, row.ui ?? []] as const),
);
const routeEditions = (
  JSON.parse(read('web-route-editions.json')) as { routes: Record<string, { edition: string }> }
).routes;

/** Desktop menus whose web screen does not exist yet: `catalogId` -> reason. Empty: all 49 have a screen. */
const KNOWN_GAPS: Record<string, string> = {};

const lite = editionNav(NAV, { code: 'L', beta: false }).groups;
const shown = lite.flatMap((group) => group.items.map((item) => ({ group: group.label, item })));
const shownId = ({ group, item }: (typeof shown)[number]) => `${group}/${item.label}`;
const expected = desktop.map((menu) => menu.catalogId);

describe('Lite edition navigation', () => {
  it('the desktop has 49 visible Lite menus', () => {
    expect(desktop).toHaveLength(49);
  });

  it('shows exactly the desktop Lite menus, none missing, none extra', () => {
    const got = new Set(shown.map(shownId));
    const want = new Set(expected.filter((id) => !(id in KNOWN_GAPS)));
    const missing = [...want].filter((id) => !got.has(id));
    const extra = [...got].filter((id) => !want.has(id));
    expect({ missing, extra }).toEqual({ missing: [], extra: [] });
    expect(shown).toHaveLength(want.size);
  });

  it('groups the menus by the desktop tabs and keeps the desktop order', () => {
    const order = (ids: string[]) => ids.filter((id) => !(id in KNOWN_GAPS));
    expect(shown.map(shownId)).toEqual(order(expected));
    expect(lite.map((group) => group.label)).toEqual([...new Set(desktop.map((menu) => menu.tab))]);
  });

  it('captions equal the desktop captions character for character', () => {
    const differences = desktop
      .filter((menu) => !(menu.catalogId in KNOWN_GAPS))
      .flatMap((menu) => {
        const found = shown.find(
          (entry) => entry.group === menu.tab && entry.item.label === menu.menu,
        );
        return found ? [] : [`${menu.tab}: desktop caption "${menu.menu}" not on the navigation`];
      });
    expect(differences).toEqual([]);
  });

  it('every item opens the web screen the menu catalog names, and every route is classified Lite', () => {
    const problems: string[] = [];
    for (const entry of shown) {
      const routes = catalog.get(shownId(entry)) ?? [];
      if (!routes.some((route) => route.split('?')[0] === entry.item.href.split('?')[0])) {
        problems.push(
          `${shownId(entry)}: ${entry.item.href} is not in the catalog routes ${routes.join(', ')}`,
        );
      }
      const path = entry.item.href.split('?')[0]!;
      const table = routeEditions[path]?.edition;
      const editionOfRoute = table ?? routeEditionFromMenus(path);
      if (editionOfRoute !== 'L')
        problems.push(`${shownId(entry)}: ${path} is edition ${editionOfRoute}`);
    }
    expect(problems).toEqual([]);
  });

  it('keeps the rights form of an existing navigation item, so USER_SET rows still apply', () => {
    const forms = new Set(
      NAV.flatMap((group) => group.items.map((item) => navItemForm(group.label, item))),
    );
    const unknown = shown
      .map((entry) => `${shownId(entry)} -> ${navItemForm(entry.group, entry.item)}`)
      .filter((line) => !forms.has(line.split(' -> ')[1]!));
    expect(unknown).toEqual([]);
  });

  it('Standard is unaffected: it keeps the web groups', () => {
    const groups = editionNav(NAV, { code: 'S', beta: false }).groups.map((group) => group.label);
    expect(groups).toContain('Sales');
    expect(groups).not.toContain('Master');
  });
});

/** A route a Lite menu serves is Lite; the overrides file classifies only routes that serve no desktop menu. */
function routeEditionFromMenus(path: string): string | undefined {
  for (const menu of desktop) {
    if ((catalog.get(menu.catalogId) ?? []).some((href) => href.split('?')[0] === path)) return 'L';
  }
  return undefined;
}
