import { describe, expect, it } from 'vitest';
import { MASTERS } from '../src/modules/masters/configs.js';
import { GENERATED_FORM_FIELDS } from '../src/modules/masters/generated-formfields.js';
import { resolveFormFields } from '../src/modules/masters/master.service.js';

const SCOPE_COLUMNS = new Set(['CO_CODE', 'LC_CODE', 'CO_YEAR']);

/**
 * Guard against the `formFields` shadowing defect.
 *
 * `app.ts` resolved form fields as `cfg.formFields ?? GENERATED_FORM_FIELDS[cfg.table]`, so any explicit
 * list REPLACED the generated column set. Measured impact before the fix: **127 columns hidden across 9
 * masters**, including `DG_GOLD_MAST.GOLD_CONV`, `AD_MAST.SCHM_AMT`, `ITEM_MAST.IT_GHT_PRC` and
 * `ITEM_MAST.UNICODE_NAME` — all of which the desktop does expose. That single expression accounted for a
 * large share of the "missing entry controls" finding.
 *
 * The rule enforced here is that hiding must be DELIBERATE. Every generated column must be one of:
 *   1. rendered on the form,
 *   2. a scope column the server injects from the session, or
 *   3. listed in `nonFormColumns` with a non-empty reason.
 *
 * Reasons are evidence-backed: `project-memory/parity/desktop_editable_columns.py` reads which columns the
 * desktop binds to a control, so an excluded column is one the desktop itself never lets an operator type.
 */
describe('master form fields', () => {
  it('never hides a generated column without a documented reason', () => {
    const offenders: string[] = [];
    for (const [name, cfg] of Object.entries(MASTERS)) {
      const gen = GENERATED_FORM_FIELDS[cfg.table];
      if (!gen) continue;
      const resolved = resolveFormFields(cfg, gen) ?? [];
      const rendered = new Set(resolved.map((f) => f.col));
      const excluded = cfg.nonFormColumns ?? {};
      for (const f of gen) {
        if (rendered.has(f.col) || SCOPE_COLUMNS.has(f.col)) continue;
        const reason = excluded[f.col];
        if (!reason || !reason.trim()) {
          offenders.push(`${name} (${cfg.table}).${f.col}`);
        }
      }
    }
    expect(offenders).toEqual([]);
  });

  it('restores the specific columns the shadowing defect hid', () => {
    // Each of these was measured as hidden before the fix and is desktop-editable, so each must now render.
    const mustRender: Record<string, string[]> = {
      items: [
        'IT_GHT_PRC',
        'UNICODE_NAME',
        'OTH_RATE',
        'TAG_TYPE',
        'TRAD_TYPE',
        'AC_ITEM',
        'TAG_IDTL_COL',
        'OTH_RATE_TYPE',
        'OTH_DETL_POSTING',
        'OTH_ITM_WT_REMOVE',
        'ITM_WITH_LOT_STK',
      ],
      'gold-rate': [
        'OUNCES_CONV',
        'GOLD_CONV',
        'SILVER_CONV',
        'CUST_BUY_RATE_ADD',
        'CUST_SALE_RATE_LESS',
        'BOOK_WITH_LIVE_RATE',
        'GOLD_FIX_RATE',
        'SILVER_FIX_RATE',
        'SHOW_DG_GOLD',
        'API_KEY',
        'CURRENCY_RATE',
        'COUNTRY_CODE',
      ],
      schemes: [
        'SCHM_CODE',
        'SCHM_NAME',
        'SCHM_AMT',
        'SCHM_AC',
        'SCHM_TYPE',
        'SCHM_MONTH',
        'BONUS_PRC',
        'BONUS_MONTH',
        'GOLD_RATE',
        'SCHM_WITH_APP',
        'SCHM_HADING',
        'SCHM_REMARK',
      ],
      addresses: [
        'AC_CODE',
        'AC_NAME',
        'AC_ADD1',
        'AC_CITY',
        'AC_STATE',
        'AC_PIN',
        'AC_MOBILE',
        'AC_EMAIL',
        'AC_PERSON',
      ],
      companies: ['CO_PHONE2', 'CO_MOBILE2', 'DHIRAN_NO', 'CO_TYPE', 'MAIL_API', 'CO_MSG'],
      counters: ['TABLE_CODE', 'TABLE_NAME'],
      accounts: ['PASSPORT_NO', 'WITH_TDS_TAX', 'MAIN_AC_CODE', 'BANK_DETL', 'DEFAULTER_AC'],
      groups: ['TRAD_TYPE'],
    };
    for (const [master, cols] of Object.entries(mustRender)) {
      const cfg = MASTERS[master];
      expect(cfg, `master ${master} must exist`).toBeTruthy();
      const rendered = new Set(
        (resolveFormFields(cfg, GENERATED_FORM_FIELDS[cfg.table]) ?? []).map((f) => f.col),
      );
      for (const col of cols) {
        expect(rendered.has(col), `${master}.${col} must render`).toBe(true);
      }
    }
  });

  it('keeps explicit metadata and explicit ordering', () => {
    const cfg = MASTERS.items;
    const resolved = resolveFormFields(cfg, GENERATED_FORM_FIELDS[cfg.table]) ?? [];
    const explicit = cfg.formFields ?? [];
    // Explicit fields lead, in their authored order, because that order mirrors the desktop tab layout.
    expect(resolved.slice(0, explicit.length).map((f) => f.col)).toEqual(
      explicit.map((f) => f.col),
    );
    // Explicit metadata wins over the generated default for the same column.
    for (const f of explicit) {
      const got = resolved.find((r) => r.col === f.col);
      expect(got?.label).toBe(f.label);
      if (f.type) expect(got?.type).toBe(f.type);
    }
  });

  it('renders no scope column and no duplicate column', () => {
    for (const [name, cfg] of Object.entries(MASTERS)) {
      const resolved = resolveFormFields(cfg, GENERATED_FORM_FIELDS[cfg.table]);
      if (!resolved) continue;
      const cols = resolved.map((f) => f.col);
      expect(new Set(cols).size, `${name} must not repeat a column`).toBe(cols.length);
      // A scope column is injected by the server unless the config asked for it by name.
      const authored = new Set((cfg.formFields ?? []).map((f) => f.col));
      for (const c of cols) {
        if (SCOPE_COLUMNS.has(c)) {
          expect(authored.has(c), `${name}.${c} is scope-injected and must not be rendered`).toBe(
            true,
          );
        }
      }
    }
  });

  it('returns null only when there is nothing to render', () => {
    expect(resolveFormFields({ table: 'X', keyColumns: [], requiredColumns: [] })).toBeNull();
    const only = resolveFormFields({
      table: 'X',
      keyColumns: [],
      requiredColumns: [],
      formFields: [{ col: 'A', label: 'A' }],
    });
    expect(only?.map((f) => f.col)).toEqual(['A']);
  });
});
