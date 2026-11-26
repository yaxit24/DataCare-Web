import { readFileSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { describe, expect, it } from 'vitest';
import {
  DESKTOP_ACCOUNT_GROUPS,
  seedDesktopCompanyMasters,
} from '../src/modules/ops/desktopTemplateMasters.js';

const fixture = (table: string): Record<string, unknown>[] =>
  JSON.parse(
    readFileSync(new URL(`./fixtures/desktop-template/${table}.json`, import.meta.url), 'utf8'),
  );
const desktop = readFileSync(
  new URL('../../../../unified/src/csharp/DataCareNext/MS_YEAR.cs', import.meta.url),
  'utf8',
).split('\n');
const authority: Record<string, number> = {
  BAL_GR: 1562,
  CO_SET_NEW: 1570,
  EMP_MAST: 1576,
  GROUP_MAST: 1578,
  ITEM_MAST: 1580,
  PRODUCT_MAST: 1588,
  TABLE_MAST: 1590,
};

describe('installer provisioning data against desktop new-company SQL', () => {
  it('binds exactly the copied columns and installer values, rewriting only CO_CODE', async () => {
    const inserted: Record<string, Record<string, unknown>[]> = {};
    const tx = {
      async $executeRawUnsafe(sql: string, tenant: string, ...values: unknown[]) {
        expect(tenant).toBe('isolated-unit-tenant');
        const [, table, columns] = /INSERT INTO "(\w+)"\(tenant_id,([^)]*)\)/.exec(sql)!;
        const names = columns!.split(',').map((column) => column.replaceAll('"', ''));
        (inserted[table!] ??= []).push(
          Object.fromEntries(names.map((name, i) => [name, values[i]])),
        );
      },
    };
    await seedDesktopCompanyMasters(tx, async () => true, 'isolated-unit-tenant', '73');
    expect(Object.keys(inserted).sort()).toEqual(Object.keys(authority).sort());
    for (const [table, line] of Object.entries(authority)) {
      const source = desktop[line - 1]!;
      const columns = /INSERT INTO \w+ \(([^)]*)\)/
        .exec(source)![1]!
        .replaceAll(' ', '')
        .split(',');
      const filter = /AND (\w+)\s+IN \(([^)]*)\)/.exec(source);
      const single = /AND (\w+) = '(\w+)'/.exec(source);
      const expected = fixture(table)
        .filter((row) => row.CO_CODE === '01')
        .filter(
          (row) =>
            !filter ||
            filter[2]!
              .split(',')
              .map((v) => v.replaceAll("'", ''))
              .includes(String(row[filter[1]!])),
        )
        .filter((row) => !single || row[single[1]!] === single[2])
        .map((row) =>
          Object.fromEntries(
            columns.map((column) => [column, column === 'CO_CODE' ? '73' : row[column]]),
          ),
        );
      expect(inserted[table], `${table}: MS_YEAR.cs:${line}`).toEqual(expected);
    }
  });

  it('does not overwrite any existing business key', async () => {
    const checks: string[] = [];
    await seedDesktopCompanyMasters(
      {
        $executeRawUnsafe: () => {
          throw new Error('existing row overwritten');
        },
      },
      async (table, where, ...keys) => {
        expect(where).toContain('"CO_CODE"=$2');
        expect(keys[0]).toBe('73');
        checks.push(table);
        return false;
      },
      'isolated-unit-tenant',
      '73',
    );
    expect(checks).toHaveLength(43);
  });
});

describe('desktop provisioning masters', () => {
  it('keeps all 35 account groups byte-for-byte aligned with the independent installer fixture', () => {
    const path = resolve(
      dirname(fileURLToPath(import.meta.url)),
      'fixtures/desktop-template/AC_GROUP.json',
    );
    const fixture = JSON.parse(readFileSync(path, 'utf8')) as Array<Record<string, unknown>>;
    const provisionedShape = DESKTOP_ACCOUNT_GROUPS.map(([code, name, mainGroup, subGroup]) => ({
      CO_CODE: '01',
      AC_GR: code,
      AC_GR_NAME: name,
      AC_MAIN_GR: mainGroup,
      AC_SUB_GR: subGroup,
      MAIN_USER: null,
      USER_SHOW_GROUP: 'Y',
    }));

    expect(provisionedShape).toEqual(fixture);
  });
});
