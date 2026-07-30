import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  coerceSettingValue,
  getSettings,
  saveSettings,
  SettingsError,
  settingsExposure,
} from '../src/modules/settings/settings.js';
import {
  SETTING_CATALOG,
  SETTING_CATALOG_BY_ID,
  SETTING_CATALOG_BY_KEY,
} from '../src/modules/settings/settingsCatalog.js';
import {
  CONFIGURABLE_SETTINGS,
  SETTING_COLUMN_COUNTS,
  SETTING_COLUMNS,
} from '../src/modules/settings/settingsInventory.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * Settings surface parity.
 *
 * The defect this pins: the settings module read and wrote `CO_SET` only, so all 70 `CO_SET_NEW` settings
 * were unreachable — including `PROFIT_RPT_TYPE`, which decides whether the balance sheet values metal at
 * all. The exposure assertion divides by a denominator derived from `information_schema`, never from the
 * catalog, so the catalog cannot certify itself as complete.
 */
describe('settings catalog and inventory', () => {
  it('keeps the schema-derived denominator fixed at 130', () => {
    expect(SETTING_COLUMN_COUNTS.CO_SET).toBe(60);
    expect(SETTING_COLUMN_COUNTS.CO_SET_NEW).toBe(70);
    expect(SETTING_COLUMN_COUNTS.total).toBe(130);
    expect(SETTING_COLUMNS.length).toBe(130);
  });

  it('exposes every configurable setting exactly once', () => {
    // Identity is table+column: COUNTRY_ID exists in BOTH tables and the desktop writes both with
    // different defaults, so keying by column name alone would silently drop one.
    const configurable = new Set(CONFIGURABLE_SETTINGS.map((c) => `${c.table}.${c.key}`));
    const exposed = SETTING_CATALOG.map((d) => d.id);
    expect(new Set(exposed).size, 'no duplicate descriptors').toBe(exposed.length);
    expect(exposed.length).toBe(128); // 130 columns less the two CO_CODE identity columns
    const missing = [...configurable].filter((k) => !exposed.includes(k));
    expect(missing).toEqual([]);
    const e = settingsExposure();
    expect(e.exposed).toBe(e.total);
    expect(e.pct).toBe(100);
  });

  it('reaches both tables, not just CO_SET', () => {
    const byTable = SETTING_CATALOG.reduce<Record<string, number>>((a, d) => {
      a[d.table] = (a[d.table] ?? 0) + 1;
      return a;
    }, {});
    // The original surface had zero CO_SET_NEW coverage; a regression shows up here immediately.
    expect(byTable.CO_SET_NEW).toBe(69); // 70 columns less CO_CODE
    expect(byTable.CO_SET).toBe(59); // 60 columns less CO_CODE
  });

  it('separates the display label from the persisted code', () => {
    // The desktop stores Strings.Mid(cboLbrType.Text,1,1): "Net Wise" -> "N" (UT_SETTING.cs:4252-4255).
    const lbr = SETTING_CATALOG_BY_KEY.LBR_TYPE;
    expect(lbr.type).toBe('enum');
    expect(lbr.options?.map((o) => o.label)).toEqual([
      'Gorss Wise', // the desktop's own misspelling is the contract
      'Net Wise',
      'Kg Wise',
      'Pcs Wise',
    ]);
    expect(lbr.options?.map((o) => o.value)).toEqual(['G', 'N', 'K', 'P']);
    // 'Fine Wise' -> 'F' is exactly what closingStock.ts checks for the metal valuation pass.
    const bs = SETTING_CATALOG_BY_KEY.PROFIT_RPT_TYPE;
    expect(bs.options?.find((o) => o.label === 'Fine Wise')?.value).toBe('F');
    expect(bs.options?.find((o) => o.label === 'Amount Wise')?.value).toBe('A');
  });

  it('types the numeric and date columns from the real schema', () => {
    // Storage shape wins over option shape: TOT_AMT_ROF offers 0/1/2 but is an INTEGER column, so it is
    // typed number with an allowed-value list, never a string enum.
    for (const key of ['GRID_ROW_HIGHT', 'TOT_AMT_ROF', 'FONT_SIZE', 'PR_RATE_ROF']) {
      expect(SETTING_CATALOG_BY_KEY[key]?.type, key).toBe('number');
    }
    expect(SETTING_CATALOG_BY_KEY.TOT_AMT_ROF?.options?.map((o) => o.value)).toEqual([
      '0',
      '1',
      '2',
    ]);
    for (const key of ['F_DISC_DATE', 'T_DISC_DATE']) {
      expect(SETTING_CATALOG_BY_KEY[key]?.type, key).toBe('date');
    }
  });

  it('marks unproven option domains instead of inventing dropdowns', () => {
    const unknown = SETTING_CATALOG.filter((d) => d.unknownOptions);
    // Every unknown-options descriptor must be free text with no fabricated option list.
    for (const d of unknown) {
      expect(d.type, d.key).toBe('text');
      expect(d.options, d.key).toBeUndefined();
    }
    // Recorded so the gate can require this to fall and never rise.
    expect(unknown.length).toBeLessThanOrEqual(35);
  });

  it('rejects a label submitted where a code is stored', () => {
    const lbr = SETTING_CATALOG_BY_KEY.LBR_TYPE;
    expect(coerceSettingValue(lbr, 'N').ok).toBe(true);
    const bad = coerceSettingValue(lbr, 'Net Wise');
    expect(bad.ok).toBe(false);
    // A blank clears the setting rather than failing.
    expect(coerceSettingValue(lbr, '')).toEqual({ ok: true, value: null });
  });

  it('validates numbers, dates and text width', () => {
    expect(coerceSettingValue(SETTING_CATALOG_BY_KEY.GRID_ROW_HIGHT, '25').ok).toBe(true);
    expect(coerceSettingValue(SETTING_CATALOG_BY_KEY.GRID_ROW_HIGHT, '26').ok).toBe(true);
    expect(coerceSettingValue(SETTING_CATALOG_BY_KEY.GRID_ROW_HIGHT, 'abc').ok).toBe(false);
    expect(coerceSettingValue(SETTING_CATALOG_BY_KEY.F_DISC_DATE, '2026-03-31').ok).toBe(true);
    expect(coerceSettingValue(SETTING_CATALOG_BY_KEY.F_DISC_DATE, '31/03/2026').ok).toBe(false);
    const text = SETTING_CATALOG.find((x) => x.type === 'text' && x.maxLength);
    if (text?.maxLength) {
      expect(coerceSettingValue(text, 'x'.repeat(text.maxLength)).ok).toBe(true);
      expect(coerceSettingValue(text, 'x'.repeat(text.maxLength + 1)).ok).toBe(false);
    }
  });
});

d('settings dual-table persistence', () => {
  const prisma = new PrismaClient();
  // tenant_id is varchar(24), so DB tests use short kebab tenants.
  const tenantId = 'settings-dual-db';
  const CO = '01';
  const scope = { tenantId, coCode: CO };

  const clean = () =>
    withTenant(prisma, tenantId, async (tx: any) => {
      for (const t of ['CO_SET', 'CO_SET_NEW']) {
        await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, tenantId);
      }
    });

  beforeAll(clean);
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
  });

  it('creates the missing row in each table and round-trips both sides', async () => {
    const r = await saveSettings(prisma, scope, {
      'CO_SET.LBR_TYPE': 'N', // enum stored as first char
      'CO_SET_NEW.NEGATIVE_STK_SALE': 'Y', // previously unreachable entirely
      'CO_SET_NEW.PROFIT_RPT_TYPE': 'F', // drives closing-stock metal valuation
      'CO_SET_NEW.GRID_ROW_HIGHT': '25', // integer column
    });
    expect(r.saved).toBe(true);
    expect(r.changed).toBe(4);
    const v = await getSettings(prisma, scope);
    expect(v['CO_SET.LBR_TYPE']).toBe('N');
    expect(v['CO_SET_NEW.NEGATIVE_STK_SALE']).toBe('Y');
    expect(v['CO_SET_NEW.PROFIT_RPT_TYPE']).toBe('F');
    expect(Number(v['CO_SET_NEW.GRID_ROW_HIGHT'])).toBe(25);
  });

  it('returns null for never-configured settings rather than empty string', async () => {
    const v = await getSettings(prisma, scope);
    // CASH_LIMIT was never written by the previous test.
    expect(v['CO_SET.CASH_LIMIT']).toBeNull();
  });

  it('leaves unrelated settings untouched on a partial save', async () => {
    await saveSettings(prisma, scope, { 'CO_SET.CASH_LIMIT': '200000' });
    const v = await getSettings(prisma, scope);
    expect(String(v['CO_SET.CASH_LIMIT'])).toContain('200000');
    // The earlier CO_SET_NEW values must survive a CO_SET-only edit.
    expect(v['CO_SET_NEW.NEGATIVE_STK_SALE']).toBe('Y');
    expect(v['CO_SET_NEW.PROFIT_RPT_TYPE']).toBe('F');
  });

  it('persists a real date into the date columns', async () => {
    await saveSettings(prisma, scope, { 'CO_SET_NEW.F_DISC_DATE': '2026-03-31' });
    const v = await getSettings(prisma, scope);
    expect(v['CO_SET_NEW.F_DISC_DATE']).toBe('2026-03-31');
  });

  it('rejects the whole request when any key is unknown or invalid', async () => {
    const before = await getSettings(prisma, scope);
    await expect(
      saveSettings(prisma, scope, { 'CO_SET.LBR_TYPE': 'N', NOT_A_SETTING: 'x' }),
    ).rejects.toBeInstanceOf(SettingsError);
    await expect(
      saveSettings(prisma, scope, { 'CO_SET.LBR_TYPE': 'Net Wise' }),
    ).rejects.toBeInstanceOf(SettingsError);
    const after = await getSettings(prisma, scope);
    expect(after).toEqual(before); // nothing partially applied
  });

  it('isolates tenants', async () => {
    const other = { tenantId: 'settings-other-db', coCode: CO };
    await saveSettings(prisma, other, { 'CO_SET_NEW.NEGATIVE_STK_SALE': 'N' });
    const mine = await getSettings(prisma, scope);
    expect(mine['CO_SET_NEW.NEGATIVE_STK_SALE']).toBe('Y'); // unchanged by the other tenant
    await withTenant(prisma, other.tenantId, async (tx: any) => {
      for (const t of ['CO_SET', 'CO_SET_NEW']) {
        await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, other.tenantId);
      }
    });
  });
});
