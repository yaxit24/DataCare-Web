import { describe, expect, it } from 'vitest';
import {
  OLD,
  companyEnterAction,
  companyFieldId,
  companyFieldKey,
  type CompanyMode,
} from '../lib/companyMasterKeys';

const act = (
  key: string,
  {
    mode = 'edit' as CompanyMode,
    values = { CO_CODE: '01', CO_NAME: 'X' } as Record<string, string>,
    hasOld = false,
  } = {},
) =>
  companyEnterAction({
    key,
    mode,
    values,
    hasOld,
    stateName: (code) => (code === '24' ? 'GUJARAT' : undefined),
  });

// MS_COMPANY.cs Enter chain: TabIndex order per TabMenu page, with the explicit jumps.
describe('Company Master Enter chain', () => {
  it('walks the edit chain from Name to Save across the three sections', () => {
    const seen: string[] = [];
    let action = act('CO_NAME', { values: { CO_CODE: '01', CO_NAME: 'X', CO_STATE_CODE: '24' } });
    while (action.kind === 'focus') {
      seen.push(action.key);
      action = act(action.key, { values: { CO_CODE: '01', CO_NAME: 'X', CO_STATE_CODE: '24' } });
    }
    expect(action.kind).toBe('save');
    expect(seen).toEqual([
      'CO_ADD1',
      'CO_ADD2',
      'CO_ADD3',
      'CO_COUNTRY',
      'CO_STATE_CODE',
      'CO_STATE',
      'CO_CITY',
      'CO_PIN',
      'CO_PHONE',
      'CO_PHONE2',
      'CO_MOBILE',
      'CO_MOBILE2',
      'CO_MAIL',
      'WORK_TYPE',
      'METAL_TYPE',
      'REP_ADD_TYPE',
      'CO_GST_NO',
      'CO_CSTNO',
      'CO_PAN_NO',
      'DHIRAN_NO',
      'CO_JUD',
      'BANK_NAME',
      'BANK_AREA',
      'BANK_AC_NO',
      'BANK_RTGS_NO',
    ]);
  });

  it('routes Code and Name through With Old Company Master for a new company', () => {
    const blank = { CO_CODE: '03', CO_NAME: '' };
    expect(act('CO_CODE', { mode: 'new', values: blank, hasOld: true })).toEqual({
      kind: 'focus',
      key: OLD,
    });
    expect(act(OLD, { mode: 'new', values: blank, hasOld: true })).toEqual({
      kind: 'focus',
      key: 'CO_NAME',
    });
    expect(act('CO_NAME', { mode: 'new', values: blank, hasOld: true })).toEqual({
      kind: 'stay',
      message: 'Please Insert Co Name ...',
    });
    expect(act(OLD, { mode: 'new', hasOld: true })).toEqual({ kind: 'focus', key: 'CO_ADD1' });
    expect(act('CO_CODE', { values: { CO_CODE: '' } })).toEqual({
      kind: 'stay',
      message: 'Please Insert Co Code ...',
    });
  });

  it('fills a known state and stays on an unknown one', () => {
    expect(act('CO_STATE_CODE', { values: { CO_STATE_CODE: '24' } })).toEqual({
      kind: 'focus',
      key: 'CO_STATE',
      state: 'GUJARAT',
    });
    expect(act('CO_STATE_CODE', { values: { CO_STATE_CODE: '99' } })).toEqual({ kind: 'stay' });
  });

  it('asks the first year before Save for a new company; Company Type goes to Save', () => {
    expect(act('BANK_RTGS_NO', { mode: 'new' })).toEqual({ kind: 'focus', key: 'YEAR' });
    expect(act('OPENING', { mode: 'new' })).toEqual({ kind: 'focus', key: 'CLOSING' });
    expect(act('CLOSING', { mode: 'new' })).toEqual({ kind: 'save' });
    expect(act('CO_TYPE')).toEqual({ kind: 'save' });
  });

  it('maps keys and element ids both ways', () => {
    for (const key of ['CO_CODE', OLD, 'YEAR', 'CO_GST_NO'])
      expect(companyFieldKey(companyFieldId(key))).toBe(key);
    expect(companyFieldKey('search')).toBeUndefined();
  });
});
