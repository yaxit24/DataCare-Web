import { describe, it, expect } from 'vitest';
import { TenantScope, UserRights } from '../src/index.js';

describe('TenantScope', () => {
  it('accepts a valid scope', () => {
    const r = TenantScope.safeParse({ tenantId: 't1', coCode: '01', lcCode: '01', coYear: '2024' });
    expect(r.success).toBe(true);
  });
  it('rejects bad CO_CODE length', () => {
    const r = TenantScope.safeParse({
      tenantId: 't1',
      coCode: '001',
      lcCode: '01',
      coYear: '2024',
    });
    expect(r.success).toBe(false);
  });
});

describe('UserRights', () => {
  it('parses right flags', () => {
    const r = UserRights.parse({ userUpdate: true, userDelete: false, userPrint: true });
    expect(r.userDelete).toBe(false);
  });
});
