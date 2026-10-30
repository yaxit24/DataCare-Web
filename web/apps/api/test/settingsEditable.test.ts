import { describe, expect, it } from 'vitest';
import { coerceSettingValue } from '../src/modules/settings/settings.js';
import { SETTING_CATALOG_BY_ID } from '../src/modules/settings/settingsCatalog.js';

/**
 * G177: the desktop setting combos are editable (no DropDownStyle in UT_SETTING, UT_SETTING_MAIN or UT_SET_ADMIN) and
 * the numeric ones save `Val(Text)` (UT_SETTING.cs:5059; UT_SETTING_MAIN.cs:9120, :9148, :9300). Their options are presets.
 */
const setting = (id: string) => {
  const d = SETTING_CATALOG_BY_ID[id];
  if (!d) throw new Error(`no setting ${id}`);
  return d;
};

describe('editable preset settings (G177)', () => {
  it('accepts an amount that is not a preset, as the desktop combo does', () => {
    expect(coerceSettingValue(setting('CO_SET.PAN_CARD_VAL'), '50000')).toEqual({
      ok: true,
      value: 50000,
    });
    expect(coerceSettingValue(setting('CO_SET.PAN_CARD_VAL'), '200000')).toEqual({
      ok: true,
      value: 200000,
    });
    expect(coerceSettingValue(setting('CO_SET_NEW.FONT_SIZE'), '10.5')).toEqual({
      ok: true,
      value: 10.5,
    });
    expect(coerceSettingValue(setting('CO_SET_NEW.GRID_ROW_HIGHT'), '31')).toEqual({
      ok: true,
      value: 31,
    });
    expect(coerceSettingValue(setting('CO_SET_NEW.VCH_DESC_HELP_LENT'), '40')).toEqual({
      ok: true,
      value: 40,
    });
  });

  it('refuses text, and a fraction for a whole-number column', () => {
    expect(coerceSettingValue(setting('CO_SET.PAN_CARD_VAL'), 'fifty')).toEqual({
      ok: false,
      reason: 'must be a number',
    });
    expect(coerceSettingValue(setting('CO_SET_NEW.GRID_ROW_HIGHT'), '22.5')).toEqual({
      ok: false,
      reason: 'must be a whole number',
    });
    expect(coerceSettingValue(setting('CO_SET_NEW.VCH_DESC_HELP_LENT'), '12.25')).toMatchObject({
      ok: false,
    });
  });

  it('clearing stays allowed, and a closed numeric list is still closed', () => {
    expect(coerceSettingValue(setting('CO_SET.PAN_CARD_VAL'), '')).toEqual({
      ok: true,
      value: null,
    });
    const closed = setting('CO_SET_NEW.TOT_AMT_ROF');
    expect(closed.editable).toBeUndefined();
    const outside = String(Math.max(...(closed.options ?? []).map((o) => Number(o.value))) + 7);
    expect(coerceSettingValue(closed, outside)).toMatchObject({ ok: false });
  });
});
