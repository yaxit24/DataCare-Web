import { describe, it, expect } from 'vitest';
import {
  findMissingRequired,
  buildInsert,
  buildDuplicateCheck,
  buildDeleteGuards,
  bindMasterScope,
  AC_MAST_CONFIG,
  ITEM_MAST_CONFIG,
} from '../src/modules/masters/master.service.js';

describe('master builders', () => {
  it('findMissingRequired flags empty/missing fields', () => {
    expect(
      findMissingRequired(AC_MAST_CONFIG, { CO_CODE: '01', AC_CODE: 'A1', AC_NAME: 'Cash' }),
    ).toEqual([]);
    expect(
      findMissingRequired(AC_MAST_CONFIG, { CO_CODE: '01', AC_CODE: '', AC_NAME: 'Cash' }),
    ).toEqual(['AC_CODE']);
    expect(findMissingRequired(AC_MAST_CONFIG, { CO_CODE: '01' })).toEqual(['AC_CODE', 'AC_NAME']);
  });

  it('buildInsert emits tenant_id + quoted columns + ordered params', () => {
    const { sql, params } = buildInsert(AC_MAST_CONFIG, 't1', {
      CO_CODE: '01',
      AC_CODE: 'A1',
      AC_NAME: 'Cash',
    });
    expect(sql).toBe(
      'INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","AC_CODE","AC_NAME") VALUES ($1,$2,$3,$4)',
    );
    expect(params).toEqual(['t1', '01', 'A1', 'Cash']);
  });

  it('buildDuplicateCheck matches the business key', () => {
    const { sql, params } = buildDuplicateCheck(AC_MAST_CONFIG, { CO_CODE: '01', AC_CODE: 'A1' });
    expect(sql).toBe(
      'SELECT 1 FROM "AC_MAST" WHERE "CO_CODE"::text=$1::text AND "AC_CODE"::text=$2::text LIMIT 1',
    );
    expect(params).toEqual(['01', 'A1']);
  });

  it('buildDeleteGuards builds a referential check per reference table', () => {
    const guards = buildDeleteGuards(AC_MAST_CONFIG, { CO_CODE: '01', AC_CODE: 'A1' });
    expect(guards).toHaveLength(1);
    expect(guards[0].ref).toBe('AC_DATA');
    expect(guards[0].sql).toBe(
      'SELECT 1 FROM "AC_DATA" WHERE "CO_CODE"::text=$1::text AND "AC_CODE"::text=$2::text LIMIT 1',
    );
    expect(guards[0].params).toEqual(['01', 'A1']);
  });

  it('binds denormalized company/location keys to server scope', () => {
    const config = {
      table: 'BOOK_DATA',
      keyColumns: ['CO_CODE', 'LC_CODE', 'CO_BOOK'],
      requiredColumns: ['CO_CODE', 'LC_CODE', 'CO_BOOK'],
    };
    expect(
      bindMasterScope(
        config,
        { tenantId: 'tenant-a', coCode: '01', lcCode: '02' },
        { tenant_id: 'tenant-b', CO_CODE: '99', LC_CODE: '88', CO_BOOK: 'SAL' },
      ),
    ).toEqual({ CO_CODE: '01', LC_CODE: '02', CO_BOOK: 'SAL' });
  });

  it('configs expose expected keys', () => {
    expect(ITEM_MAST_CONFIG.keyColumns).toEqual(['CO_CODE', 'IT_CODE']);
    expect(AC_MAST_CONFIG.references).toEqual(['AC_DATA']);
  });
});
