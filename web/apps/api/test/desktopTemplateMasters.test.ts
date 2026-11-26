import { readFileSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { describe, expect, it } from 'vitest';
import { DESKTOP_ACCOUNT_GROUPS } from '../src/modules/ops/desktopTemplateMasters.js';

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
