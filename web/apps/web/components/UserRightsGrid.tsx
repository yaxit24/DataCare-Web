'use client';
import { useEffect, useState } from 'react';
import { get, post, ApiError } from '../lib/api';
import { USER_TEXT } from '../lib/userCreate';

type Cell = { view: boolean; edit: boolean; del: boolean; print: boolean };
const NONE: Cell = { view: false, edit: false, del: false, print: false };
const keyOf = (main: string, sub: string) => `${main}/${sub}`;

/**
 * The MS_USER rights grid (DGV) and its Update User Right button, for Basic and higher editions only (D36: Lite hides
 * both, MS_USER.cs:1489-1495). Picking a user in the User Name box loads that user's USER_SET rows (DISPLAY_DATA,
 * :1534-1765); the grid's columns are SrNo, Main Menu, Sub Menu, View, Edit, Delete, Print (:1640-1680); the button
 * writes them back and says "Data Are Update." (:2354).
 */
export function UserRightsGrid({
  user,
  onMessage,
}: {
  user: string;
  onMessage: (kind: 'ok' | 'err', text: string) => void;
}) {
  const [catalog, setCatalog] = useState<{ mainMenu: string; subMenu: string }[]>([]);
  const [cells, setCells] = useState<Record<string, Cell>>({});
  const [busy, setBusy] = useState(false);

  useEffect(() => {
    let live = true;
    setCells({});
    if (!user) return;
    (async () => {
      try {
        const cat = await get<{ mainMenu: string; subMenu: string }[]>('/admin/form-catalog');
        const rows = await get<any[]>(`/admin/users/${encodeURIComponent(user)}/form-rights`);
        if (!live) return;
        setCatalog(cat);
        const next: Record<string, Cell> = {};
        for (const r of rows)
          next[keyOf(r.mainMenu, r.subMenu)] = {
            view: !!r.view,
            edit: !!r.edit,
            del: !!r.del,
            print: !!r.print,
          };
        setCells(next);
      } catch (error) {
        if (live)
          onMessage(
            'err',
            error instanceof ApiError && error.status === 403
              ? USER_TEXT.NO_RIGHTS
              : 'Failed to load rights',
          );
      }
    })();
    return () => {
      live = false;
    };
  }, [user, onMessage]);

  async function update() {
    if (!user) {
      onMessage('err', 'User Name Is Not Selected,Please Select User Name First And Try Again..');
      return;
    }
    setBusy(true);
    try {
      const rows = catalog
        .map((c) => ({
          mainMenu: c.mainMenu,
          subMenu: c.subMenu,
          ...(cells[keyOf(c.mainMenu, c.subMenu)] ?? NONE),
        }))
        .filter((r) => r.view || r.edit || r.del || r.print);
      await post(`/admin/users/${encodeURIComponent(user)}/form-rights`, { rows });
      onMessage('ok', 'Data Are Update.');
    } catch (error) {
      onMessage(
        'err',
        error instanceof ApiError && error.status === 403
          ? USER_TEXT.NO_RIGHTS
          : 'Failed to update rights',
      );
    } finally {
      setBusy(false);
    }
  }

  const box = (k: string, f: keyof Cell, label: string) => (
    <input
      type="checkbox"
      aria-label={label}
      checked={(cells[k] ?? NONE)[f]}
      onChange={(event) =>
        setCells((m) => ({ ...m, [k]: { ...(m[k] ?? NONE), [f]: event.target.checked } }))
      }
    />
  );

  return (
    <div className="panel" data-testid="user-rights-grid" style={{ overflow: 'auto' }}>
      <button type="button" className="ghost" disabled={busy} onClick={update}>
        Update User Right
      </button>
      {user && catalog.length > 0 && (
        <table className="grid" style={{ marginTop: 8 }}>
          <thead>
            <tr>
              <th>SrNo</th>
              <th>Main Menu</th>
              <th>Sub Menu</th>
              <th>View</th>
              <th>Edit</th>
              <th>Delete</th>
              <th>Print</th>
            </tr>
          </thead>
          <tbody>
            {catalog.map((c, i) => {
              const k = keyOf(c.mainMenu, c.subMenu);
              return (
                <tr key={k}>
                  <td>{i + 1}</td>
                  <td>{c.mainMenu}</td>
                  <td>{c.subMenu}</td>
                  <td>{box(k, 'view', `View ${c.subMenu}`)}</td>
                  <td>{box(k, 'edit', `Edit ${c.subMenu}`)}</td>
                  <td>{box(k, 'del', `Delete ${c.subMenu}`)}</td>
                  <td>{box(k, 'print', `Print ${c.subMenu}`)}</td>
                </tr>
              );
            })}
          </tbody>
        </table>
      )}
    </div>
  );
}
