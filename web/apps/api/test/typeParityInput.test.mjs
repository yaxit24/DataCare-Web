import { createHash } from 'node:crypto';
import { describe, expect, it } from 'vitest';
import {
  FROZEN_DESKTOP_SCHEMA_IDENTITY,
  desktopSchemaColumns,
  frozenDesktopSchemaColumns,
  parseTypeDump,
  typeDumpCoverageProblems,
} from '../../../scripts/check-type-parity.mjs';

const contract = {
  tableCount: 2,
  columnCount: 3,
  tables: {
    AC_DATA: ['AC_CODE', 'DR_AMT'],
    SL_DATA: ['VCH_NO'],
  },
};

describe('SQL Server type-dump coverage', () => {
  it('normalizes a complete headerless dump against the independent schema denominator', () => {
    const parsed = parseTypeDump(
      'ac_data|ac_code|varchar\r\nAC_DATA|DR_AMT|FLOAT\nSL_DATA|VCH_NO|int\n',
    );
    const expected = desktopSchemaColumns(contract);

    expect([...parsed.columns]).toEqual([
      ['AC_DATA.AC_CODE', 'varchar'],
      ['AC_DATA.DR_AMT', 'float'],
      ['SL_DATA.VCH_NO', 'int'],
    ]);
    expect(typeDumpCoverageProblems(parsed, expected)).toEqual([]);
  });

  it.each([
    ['', /missing 3 desktop-schema column/],
    ['AC_DATA|AC_CODE|varchar\n', /missing 2 desktop-schema column/],
    [
      'AC_DATA|AC_CODE|varchar\nAC_DATA|DR_AMT|float\nSL_DATA|VCH_NO|int\nEXTRA|VALUE|int\n',
      /unexpected 1 dump column/,
    ],
    [
      'AC_DATA|AC_CODE|varchar\nAC_DATA|AC_CODE|varchar\nAC_DATA|DR_AMT|float\nSL_DATA|VCH_NO|int\n',
      /duplicate dump column/,
    ],
    [
      'header from sqlcmd\nAC_DATA|AC_CODE|varchar\nAC_DATA|DR_AMT|float\nSL_DATA|VCH_NO|int\n',
      /malformed nonblank dump line/,
    ],
  ])('refuses an incomplete or malformed readable dump %#', (dump, expectedProblem) => {
    const problems = typeDumpCoverageProblems(parseTypeDump(dump), desktopSchemaColumns(contract));
    expect(problems.join('\n')).toMatch(expectedProblem);
  });

  it('binds the separately supplied desktop schema to an immutable source identity', () => {
    const source = `${JSON.stringify(contract)}\n`;
    const identity = {
      tableCount: 2,
      columnCount: 3,
      sha256: createHash('sha256').update(source).digest('hex'),
    };
    expect(frozenDesktopSchemaColumns(source, identity).size).toBe(3);
    expect(() =>
      frozenDesktopSchemaColumns(source.replace('VCH_NO', 'OTHER_NO'), identity),
    ).toThrow(/does not match frozen identity/);
    expect(() => frozenDesktopSchemaColumns(source, { ...identity, columnCount: 2 })).toThrow(
      /denominator 2\/3 does not match frozen identity 2\/2/,
    );
    expect(FROZEN_DESKTOP_SCHEMA_IDENTITY).toEqual({
      tableCount: 145,
      columnCount: 5231,
      sha256: '547a424c5a8703c0904fafd87d6fd2125b8ee5c08c1189d1a12d73cf48cd3dac',
    });
  });

  it('validates schema structure as a nonempty exact denominator', () => {
    expect(desktopSchemaColumns(contract).size).toBe(3);
    expect(() => desktopSchemaColumns({ ...contract, columnCount: 2 })).toThrow(/columnCount/);
    expect(() =>
      desktopSchemaColumns({
        tableCount: 1,
        columnCount: 2,
        tables: { AC_DATA: ['AC_CODE', 'ac_code'] },
      }),
    ).toThrow(/duplicates AC_DATA\.AC_CODE/);
  });
});
