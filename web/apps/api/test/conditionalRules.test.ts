import { describe, expect, it } from 'vitest';
import {
  assertCounterCodes,
  assertHallmarkWeights,
  assertItemSign,
  assertWestPct,
  resolveCounterStockPolicy,
} from '../src/modules/shared/counterStockPolicy.js';
import { DESKTOP_MESSAGES } from '../src/modules/shared/desktopMessages.js';
import {
  AC_MAST_CONFIG,
  assertColumnRules,
  DeleteSelectionError,
  desktopMessageFor,
  DuplicateKeyError,
  findMissingRequired,
  ITEM_MAST_CONFIG,
  ValidationError,
} from '../src/modules/masters/master.service.js';
import {
  assertMailable,
  assertMessageBody,
  assertYesNo,
} from '../src/modules/integrations/messaging.js';
import {
  AD_MAST_CONFIG,
  MASTERS,
  DESIGN_MAST_CONFIG,
  GROUP_MAST_CONFIG,
  MFG_MAST_CONFIG,
  MODEL_MAST_CONFIG,
  PRODUCT_MAST_CONFIG,
  TABLE_MAST_CONFIG,
} from '../src/modules/masters/configs.js';

/**
 * Conditional desktop rules: each fires only under the condition the desktop states, so the tests pin
 * both the firing case and the allow case. A guard that always fires would be a regression, not parity.
 */
describe('counter-wise stock policy', () => {
  it('is enforced only when the company setting is exactly Y', () => {
    expect(resolveCounterStockPolicy('Y').enforced).toBe(true);
    // MS_OPNCOMP.cs defaults a blank flag to 'N'.
    expect(resolveCounterStockPolicy('').enforced).toBe(false);
    expect(resolveCounterStockPolicy(null).enforced).toBe(false);
    expect(resolveCounterStockPolicy('N').enforced).toBe(false);
    expect(resolveCounterStockPolicy('y').enforced).toBe(true);
  });

  it('demands a counter code for item rows when enforced, in desktop wording', () => {
    expect(() => assertCounterCodes({ enforced: true }, [{ itCode: 'GOLD', tblCode: '' }])).toThrow(
      DESKTOP_MESSAGES.TAG_COUNTER_MANDATORY,
    );
  });

  it('does not fire when the setting is off, even with a blank counter', () => {
    expect(() =>
      assertCounterCodes({ enforced: false }, [{ itCode: 'GOLD', tblCode: '' }]),
    ).not.toThrow();
  });

  it('does not fire for a grid with no items, matching MSG[1,3] being blank', () => {
    expect(() =>
      assertCounterCodes({ enforced: true }, [{ itCode: '', tblCode: '' }]),
    ).not.toThrow();
  });

  it('accepts rows that carry a counter', () => {
    expect(() =>
      assertCounterCodes({ enforced: true }, [{ itCode: 'GOLD', tblCode: 'C1' }]),
    ).not.toThrow();
  });
});

describe('hallmark ID weights', () => {
  it('requires a weight for each filled ID slot, with the slot-specific message', () => {
    expect(() => assertHallmarkWeights({ hallmarkId2: 'HUID2' })).toThrow(
      DESKTOP_MESSAGES.HALLMARK_ID2_WEIGHT,
    );
    expect(() => assertHallmarkWeights({ hallmarkId3: 'HUID3' })).toThrow(
      DESKTOP_MESSAGES.HALLMARK_ID3_WEIGHT,
    );
    expect(() => assertHallmarkWeights({ hallmarkId4: 'HUID4' })).toThrow(
      DESKTOP_MESSAGES.HALLMARK_ID4_WEIGHT,
    );
  });

  it('accepts a filled ID with a weight, and an empty slot with none', () => {
    expect(() => assertHallmarkWeights({ hallmarkId2: 'HUID2', hallmarkId2Wt: 3.5 })).not.toThrow();
    expect(() => assertHallmarkWeights({})).not.toThrow();
    // A weight without an ID is not the desktop's condition and must not fire.
    expect(() => assertHallmarkWeights({ hallmarkId3Wt: 2 })).not.toThrow();
  });
});

describe('master field wording', () => {
  it('reports a blank party name exactly as MS_ACCT does', () => {
    const missing = findMissingRequired(AC_MAST_CONFIG, {
      CO_CODE: '01',
      AC_CODE: 'X',
      AC_NAME: '',
    });
    expect(missing).toContain('AC_NAME');
    expect(desktopMessageFor(AC_MAST_CONFIG, missing)).toBe(DESKTOP_MESSAGES.PARTY_NAME_REQUIRED);
    expect(new ValidationError(missing, desktopMessageFor(AC_MAST_CONFIG, missing)).message).toBe(
      'Please Insert Party Name ...',
    );
  });

  it('reports a blank group name exactly as MS_AC_GROUP does', () => {
    const missing = findMissingRequired(GROUP_MAST_CONFIG, { CO_CODE: '01', GR_CODE: 'G' });
    expect(desktopMessageFor(GROUP_MAST_CONFIG, missing)).toBe(
      DESKTOP_MESSAGES.GROUP_NAME_REQUIRED,
    );
  });

  it('keeps the generic form for columns the desktop has no message for', () => {
    const missing = findMissingRequired(AC_MAST_CONFIG, { AC_CODE: 'X', AC_NAME: 'N' });
    expect(missing).toContain('CO_CODE');
    expect(desktopMessageFor(AC_MAST_CONFIG, missing)).toBeUndefined();
    expect(new ValidationError(missing).message).toBe('missing-required: CO_CODE');
  });
});

describe('master form guards ported from MS_PRODUCT / MS_STYLE / MS_ITEM', () => {
  it('carries per-master wording because one desktop form serves several masters', () => {
    // MS_PRODUCT switches on CurMast; the web has one config per master, each with its own words.
    expect(PRODUCT_MAST_CONFIG.columnMessages?.PR_NAME).toBe('Please Insert Product Name ...');
    expect(TABLE_MAST_CONFIG.columnMessages?.TABLE_NAME).toBe('Please Insert Table Name ...');
    expect(AD_MAST_CONFIG.columnMessages?.SCHM_NAME).toBe('Please Insert Scheme Name ...');
    // MS_STYLE likewise serves Design / Style / Item City.
    expect(MODEL_MAST_CONFIG.columnMessages?.MODEL_NAME).toBe('Please Insert Model Name ...');
    expect(DESIGN_MAST_CONFIG.columnMessages?.DESIGN_NO).toBe('Please Insert Design Name ...');
  });

  it('rejects a one-character product code exactly as MS_PRODUCT does', () => {
    expect(() =>
      assertColumnRules(PRODUCT_MAST_CONFIG, { CO_CODE: '01', PR_CODE: 'R', PR_NAME: 'Ring' }),
    ).toThrow('Please Insert Product Code 2 Digit...');
  });

  it('accepts a two-character code, and leaves a blank code to the presence guard', () => {
    expect(() =>
      assertColumnRules(PRODUCT_MAST_CONFIG, { CO_CODE: '01', PR_CODE: 'RG', PR_NAME: 'Ring' }),
    ).not.toThrow();
    // Blank is NOT length 1, so this rule must stay silent; `Enter Product Code.` reports it instead.
    expect(() => assertColumnRules(PRODUCT_MAST_CONFIG, { PR_CODE: '' })).not.toThrow();
    expect(findMissingRequired(PRODUCT_MAST_CONFIG, { CO_CODE: '01', PR_CODE: '' })).toContain(
      'PR_CODE',
    );
    expect(desktopMessageFor(PRODUCT_MAST_CONFIG, ['PR_CODE'])).toBe('Enter Product Code.');
  });

  it('reports an unselected delete with the desktop message of that master', () => {
    expect(PRODUCT_MAST_CONFIG.deleteSelectionMessage).toBe('Please Select Product For Delete.');
    expect(ITEM_MAST_CONFIG.deleteSelectionMessage).toBe('Please Select Item For Delete.');
    expect(AC_MAST_CONFIG.deleteSelectionMessage).toBe('Please Select AcCode For Delete.');
    expect(GROUP_MAST_CONFIG.deleteSelectionMessage).toBe('Please Select Group For Delete.');
    expect(new DeleteSelectionError(PRODUCT_MAST_CONFIG.deleteSelectionMessage!).name).toBe(
      'ValidationError',
    );
  });

  it('reports a duplicate name with the master-specific wording', () => {
    expect(new DuplicateKeyError(MODEL_MAST_CONFIG.duplicateMessage).message).toBe(
      'This Style Name already Exist Please Change It...',
    );
    expect(new DuplicateKeyError(DESIGN_MAST_CONFIG.duplicateMessage).message).toBe(
      'This Design Name already Exist Please Change It...',
    );
    // Masters without desktop wording keep the generic code.
    expect(new DuplicateKeyError().message).toBe('duplicate-key');
  });
});

describe('mail pre-flight order', () => {
  it('reports the company configuration first, as Module_Save nests the checks', () => {
    // if (company configured) { if (party email) send else "party" } else "company"
    expect(() => assertMailable({ companyEmail: '', companyApiKey: '', partyEmail: '' })).toThrow(
      'Please Update Company Mail Id and Api Then Try...',
    );
    expect(() =>
      assertMailable({ companyEmail: 'shop@example.com', companyApiKey: '', partyEmail: 'a@b.c' }),
    ).toThrow('Please Update Company Mail Id and Api Then Try...');
  });

  it('reports the missing party address only once the company is configured', () => {
    expect(() =>
      assertMailable({ companyEmail: 'shop@example.com', companyApiKey: 'KEY', partyEmail: '  ' }),
    ).toThrow('Please Insert e Mail id in Party Master then Try...');
  });

  it('passes when both sides are configured', () => {
    expect(() =>
      assertMailable({
        companyEmail: 'shop@example.com',
        companyApiKey: 'KEY',
        partyEmail: 'a@b.c',
      }),
    ).not.toThrow();
  });
});

describe('mfg master transaction lock', () => {
  it('freezes the process chain past ten transactions, in desktop wording', () => {
    expect(MFG_MAST_CONFIG.saveGuards?.[0]).toMatchObject({ table: 'MFG_DATA', maxRows: 10 });
    expect(MFG_MAST_CONFIG.saveGuards?.[0]?.message).toBe(
      'You Cant Save Mfg Master Because More Then 10 Transection in MFG_DATA First Delete It and Try...',
    );
  });
});

describe('master message wiring integrity', () => {
  /**
   * A message keyed to a column that is not actually required by the config would never fire, while
   * still appearing in the source and inflating the validation-wording metric. This asserts every
   * `columnMessages` key is a required column of its own config, and every `columnRules` column exists
   * in the config's key or required set — so an unreachable message fails the build instead.
   */
  it('every columnMessages key is a required column of its config', () => {
    const configs = Object.entries(MASTERS);
    const problems: string[] = [];
    for (const [name, config] of configs) {
      for (const column of Object.keys(config.columnMessages ?? {})) {
        if (!config.requiredColumns.includes(column)) {
          problems.push(`${name}.columnMessages.${column} is not in requiredColumns`);
        }
      }
      for (const rule of config.columnRules ?? []) {
        if (![...config.keyColumns, ...config.requiredColumns].includes(rule.column)) {
          problems.push(`${name}.columnRules ${rule.column} is not a key or required column`);
        }
      }
      for (const guard of config.saveGuards ?? []) {
        if (!guard.message.trim()) problems.push(`${name}.saveGuards has an empty message`);
        if (guard.maxRows < 0) problems.push(`${name}.saveGuards has a negative threshold`);
      }
    }
    expect(problems).toEqual([]);
  });

  it('covers a meaningful number of masters, so the check is not vacuous', () => {
    const withMessages = Object.values(MASTERS).filter(
      (c) => c.columnMessages || c.deleteSelectionMessage || c.duplicateMessage || c.saveGuards,
    );
    expect(withMessages.length).toBeGreaterThanOrEqual(12);
  });
});

describe('book-gated and value guards', () => {
  it('demands a + or - sign only for STOCK ADJUST books', () => {
    expect(() => assertItemSign('STOCK ADJUST', '')).toThrow(
      'Please Insert Item Sign + or - then Try',
    );
    expect(() => assertItemSign('STOCK ADJUST', 'X')).toThrow(
      'Please Insert Item Sign + or - then Try',
    );
    expect(() => assertItemSign('STOCK ADJUST', '+')).not.toThrow();
    expect(() => assertItemSign('STOCK ADJUST', '-')).not.toThrow();
    // Every other book derives the sign, so the guard must stay silent there.
    expect(() => assertItemSign('SALE', '')).not.toThrow();
    expect(() => assertItemSign(null, '')).not.toThrow();
  });

  it('rejects a negative wastage percentage, as TR_TOUR_SALE does', () => {
    expect(() => assertWestPct(-0.5)).toThrow(
      'You Cant Adjust Negative West % Please Change West %',
    );
    expect(() => assertWestPct(0)).not.toThrow();
    expect(() => assertWestPct(2)).not.toThrow();
    expect(() => assertWestPct(undefined)).not.toThrow();
  });

  it('refuses an empty message body and a flag that is not Y or N', () => {
    expect(() => assertMessageBody('   ')).toThrow('Please First Type Massage and Try...');
    expect(() => assertMessageBody('Rate today')).not.toThrow();
    expect(() => assertYesNo('X')).toThrow('Please Enter Y or N and Try Again...');
    expect(() => assertYesNo('')).toThrow('Please Enter Y or N and Try Again...');
    // The desktop compares text case-insensitively.
    expect(() => assertYesNo('y')).not.toThrow();
    expect(() => assertYesNo('N')).not.toThrow();
  });

  it('reports a blank customer code or name with one shared message, as MS_ADD_MAST does', () => {
    // MASTERS key 'addresses' is the ADD_MAST config (desktop MS_ADD_MAST).
    const target = MASTERS.addresses;
    expect(target.table).toBe('ADD_MAST');
    expect(target.columnMessages?.AC_NAME).toBe('Please Select Customer name and try....');
    expect(target.columnMessages?.AC_CODE).toBe('Please Select Customer name and try....');
    // The desktop guards code OR name with one message, so both keys must be present and required.
    expect(target.requiredColumns).toContain('AC_NAME');
  });
});
