import { describe, it, expect } from 'vitest';
import { can, assertRight, ForbiddenError, filterNav } from '../src/modules/rbac/policy.js';

const full = { userUpdate: true, userDelete: true, userPrint: true };
const readonly = { userUpdate: false, userDelete: false, userPrint: false };

describe('rbac can()', () => {
  it('maps rights to actions', () => {
    expect(can(full, 'create')).toBe(true);
    expect(can(readonly, 'create')).toBe(false);
    expect(can(readonly, 'update')).toBe(false);
    expect(can({ ...readonly, userDelete: true }, 'delete')).toBe(true);
    expect(can(readonly, 'delete')).toBe(false);
    expect(can({ ...readonly, userPrint: true }, 'print')).toBe(true);
    expect(can(readonly, 'read')).toBe(true); // read always allowed
  });
});

describe('assertRight()', () => {
  it('throws ForbiddenError when denied', () => {
    expect(() => assertRight(readonly, 'delete')).toThrow(ForbiddenError);
  });
  it('passes when allowed', () => {
    expect(() => assertRight(full, 'delete')).not.toThrow();
  });
});

describe('filterNav()', () => {
  const menu = [
    { form: 'TR_SALE', label: 'Sales' },
    { form: 'MASTERS', label: 'Masters', children: [{ form: 'AC_MAST' }, { form: 'ITEM_MAST' }] },
    { form: 'ADMIN', label: 'Admin', children: [{ form: 'MS_USER' }] },
  ];

  it('hides forms the user cannot access', () => {
    const allowed = new Set(['TR_SALE', 'AC_MAST']);
    const nav = filterNav(menu, allowed);
    const forms = nav.map((n) => n.form);
    expect(forms).toContain('TR_SALE');
    expect(forms).toContain('MASTERS'); // kept because AC_MAST child survives
    expect(forms).not.toContain('ADMIN'); // MS_USER not allowed -> parent dropped
    const masters = nav.find((n) => n.form === 'MASTERS')!;
    expect(masters.children!.map((c) => c.form)).toEqual(['AC_MAST']);
  });

  it('returns empty when nothing allowed', () => {
    expect(filterNav(menu, new Set())).toEqual([]);
  });
});
