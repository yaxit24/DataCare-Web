import type { UserRights } from '@datacare/types';

/** Actions gated by the desktop user-right flags (Req 6.4–6.6). */
export type Action = 'create' | 'update' | 'delete' | 'print' | 'read';

export class ForbiddenError extends Error {
  constructor(public action: Action) {
    super(`forbidden: ${action}`);
    this.name = 'ForbiddenError';
  }
}

/** USER_UPDATE → create/update; USER_DELETE → delete; USER_PRINT → print; read is always allowed. */
export function can(rights: UserRights, action: Action): boolean {
  switch (action) {
    case 'create':
    case 'update':
      return rights.userUpdate;
    case 'delete':
      return rights.userDelete;
    case 'print':
      return rights.userPrint;
    case 'read':
      return true;
  }
}

export function assertRight(rights: UserRights, action: Action): void {
  if (!can(rights, action)) throw new ForbiddenError(action);
}

/** A navigation entry (menu/form tree). */
export interface NavItem {
  form: string;
  label?: string;
  children?: NavItem[];
}

/**
 * Dynamic navigation (Req 6.7): keep an item only if the user may access that form, or if any
 * descendant survives the filter. `allowed` is the per-user accessible-form set (from USER_SET/
 * USER_DATA, resolved into the session).
 */
export function filterNav(items: NavItem[], allowed: ReadonlySet<string>): NavItem[] {
  const out: NavItem[] = [];
  for (const it of items) {
    const children = it.children ? filterNav(it.children, allowed) : undefined;
    const keep = allowed.has(it.form) || (children !== undefined && children.length > 0);
    if (keep) out.push(children ? { ...it, children } : { ...it });
  }
  return out;
}
