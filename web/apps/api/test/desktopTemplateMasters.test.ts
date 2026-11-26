import { readFileSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { describe, expect, it } from 'vitest';
import {
  DESKTOP_ACCOUNT_GROUPS,
  DESKTOP_ACCOUNT_ROLES,
  seedDesktopCompanyMasters,
  webAccountFor,
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
  CO_SET: 1568,
  CO_SET_NEW: 1570,
  CONV_MAST: 1574,
  EMP_MAST: 1576,
  GROUP_MAST: 1578,
  ITEM_MAST: 1580,
  PRODUCT_MAST: 1588,
  TABLE_MAST: 1590,
};

// The two documented web adaptations of the copied values (desktopTemplateMasters.ts): installer account codes
// become web role accounts, and the TABLE_MAST counter takes the company's location (default '01', not '00').
const adapted = (table: string, column: string, value: unknown): unknown => {
  if (column === 'CO_CODE') return '73';
  if (table === 'TABLE_MAST' && column === 'LC_CODE') return '01';
  if (
    (table === 'GROUP_MAST' || table === 'BAL_GR') &&
    ['SALE_AC', 'PURC_AC', 'CLOSING_AC', 'OP_AC', 'CLG_AC'].includes(column)
  )
    return webAccountFor(value);
  return value;
};

describe('installer provisioning data against desktop new-company SQL', () => {
  it('binds exactly the copied columns and installer values, rewriting only CO_CODE, the installer account codes and the TABLE_MAST location', async () => {
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
            columns.map((column) => [column, adapted(table, column, row[column])]),
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
    expect(checks).toHaveLength(45);
  });
});

describe('installer account codes map to web role accounts', () => {
  it('names every account the seeded GROUP_MAST and BAL_GR rows use, with the installer AC_MAST name beside it', () => {
    const names = new Map(
      fixture('AC_MAST')
        .filter((r) => r.CO_CODE === '01')
        .map((r) => [String(r.AC_CODE), String(r.AC_NAME)]),
    );
    const used = new Set<string>();
    for (const table of ['GROUP_MAST', 'BAL_GR'])
      for (const row of fixture(table).filter((r) => r.CO_CODE === '01'))
        for (const column of ['SALE_AC', 'PURC_AC', 'CLOSING_AC', 'OP_AC', 'CLG_AC'])
          if (row[column]) used.add(String(row[column]));
    for (const code of used) {
      expect(DESKTOP_ACCOUNT_ROLES[code], `installer account ${code}`).toBeDefined();
      expect(DESKTOP_ACCOUNT_ROLES[code]!.installerName).toBe(names.get(code));
    }
    expect(webAccountFor('00003')).toBe('SALES');
    expect(webAccountFor('00009')).toBe('SLVPURC');
    expect(() => webAccountFor('00099')).toThrow();
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
