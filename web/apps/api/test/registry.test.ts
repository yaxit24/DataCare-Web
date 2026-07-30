import { describe, it, expect } from 'vitest';
import { MASTERS } from '../src/modules/masters/configs.js';

describe('master registry', () => {
  it('exposes expected master routes', () => {
    expect(Object.keys(MASTERS).sort()).toEqual([
      'ac-groups',
      'accounts',
      'addresses',
      'books',
      'companies',
      'conversions',
      'counters',
      'customers',
      'designs',
      'diamonds',
      'einvoice-gsp',
      'employees',
      'franchise-accounts',
      'gold-rate',
      'groups',
      'item-cities',
      'item-weights',
      'items',
      'labour',
      'locations',
      'messages',
      'mfg',
      'models',
      'points',
      'print-formats',
      'products',
      'rates',
      'schemes',
      'states',
      'styles',
      'taxes',
      'touch',
      'trade',
      'years',
    ]);
  });
  it('configs carry correct key columns + guards', () => {
    expect(MASTERS.rates.keyColumns).toEqual(['CO_CODE', 'LC_CODE', 'VCH_DATE', 'SR_NO']);
    expect(MASTERS.taxes.keyColumns).toEqual(['CO_CODE', 'TAX_CODE']);
    expect(MASTERS.groups.references).toEqual(['ITEM_MAST']);
    expect(MASTERS.customers.table).toBe('AC_MAST');
    expect(MASTERS.products.table).toBe('PRODUCT_MAST');
    expect(MASTERS.locations.keyColumns).toEqual(['CO_CODE', 'LC_CODE']);
    expect(MASTERS.states.keyColumns).toEqual(['STATE_CODE']);
    expect(MASTERS.touch.keyColumns).toEqual(['CO_CODE', 'LC_CODE', 'AC_CODE', 'AC_IT_CODE']);
  });
  it('every config requiredColumns include all keyColumns', () => {
    for (const [route, cfg] of Object.entries(MASTERS)) {
      for (const k of cfg.keyColumns) {
        expect(cfg.requiredColumns, `${route}.${k}`).toContain(k);
      }
    }
  });
});
