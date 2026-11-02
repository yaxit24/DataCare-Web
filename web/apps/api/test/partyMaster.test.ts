import { describe, expect, it } from 'vitest';
import {
  filterPartyList,
  nextPartyCode,
  partyBranchMessage,
  partyDate,
  partyMobileBranchMessage,
  partyMobileTakenMessage,
  partyNameTakenMessage,
  partyShortTakenMessage,
} from '../src/modules/masters/partyMaster.js';

/**
 * N223 / G235: the pure rules of the Party master (desktop MS_ACCT). Expected values come from CLEAR_DATA's next-code
 * queries (MS_ACCT.cs:6230-6340), the masked date boxes' IsDate (:7801-7805), the list filters (Text1_TextChanged
 * :6647-6690, tAcName_TextChanged :7280-7470) and the message texts.
 */
const rules = (over: Partial<Parameters<typeof nextPartyCode>[1]> = {}) => ({
  lcCode: '01',
  lcCodeLength: 1,
  vbImport: false,
  coType: '',
  ...over,
});

describe('N223 Party master next code (CLEAR_DATA)', () => {
  it("AC_LC_CODE_LEN 1: the location's second character and five digits, 00201 first", () => {
    expect(nextPartyCode([], rules())).toBe('100201');
    expect(nextPartyCode([], rules({ lcCode: '00' }))).toBe('000201');
    // LEN(AC_CODE) = 6 AND SUBSTRING(AC_CODE,2,5) < 80000 ORDER BY SUBSTRING(AC_CODE,2,5) DESC.
    expect(nextPartyCode(['100201', '100215', '100209', 'CASH', '05', '1002150'], rules())).toBe(
      '100216',
    );
    expect(nextPartyCode(['180001', '100300'], rules())).toBe('100301');
    expect(nextPartyCode(['A00400', '100300'], rules())).toBe('100401');
  });

  it('AC_LC_CODE_LEN 1 with company type P or B: the 80000 series', () => {
    expect(nextPartyCode([], rules({ coType: 'P' }))).toBe('180001');
    expect(nextPartyCode(['180001', '180007', '100300'], rules({ coType: 'B' }))).toBe('180008');
  });

  it('AC_LC_CODE_LEN 2: the location code and five digits, adding 1 to the last five', () => {
    expect(nextPartyCode([], rules({ lcCodeLength: 2 }))).toBe('0100201');
    expect(nextPartyCode(['0100201', '0100202'], rules({ lcCodeLength: 2 }))).toBe('0100203');
    expect(nextPartyCode(['0180001'], rules({ lcCodeLength: 2, coType: 'P' }))).toBe('0180002');
    expect(nextPartyCode([], rules({ lcCodeLength: 2, coType: 'P' }))).toBe('0180001');
  });

  it('VB_IMPORT: five digits at location 00, the location digit elsewhere, 80000 for P and B', () => {
    expect(nextPartyCode([], rules({ vbImport: true, lcCode: '00' }))).toBe('00101');
    expect(
      nextPartyCode(['00101', '00150', '80005'], rules({ vbImport: true, lcCode: '00' })),
    ).toBe('00151');
    expect(nextPartyCode([], rules({ vbImport: true }))).toBe('100201');
    expect(nextPartyCode(['100201', '100230'], rules({ vbImport: true }))).toBe('100231');
    expect(nextPartyCode([], rules({ vbImport: true, coType: 'P' }))).toBe('80001');
    expect(nextPartyCode(['80001', '80010'], rules({ vbImport: true, coType: 'B' }))).toBe('80011');
  });
});

describe('N223 Party master boxes and texts', () => {
  it('reads a masked date box as IsDate does', () => {
    expect(partyDate('15/08/1990')).toEqual({ text: '15/08/1990', iso: '1990-08-15' });
    expect(partyDate('1/2/2020')).toEqual({ text: '01/02/2020', iso: '2020-02-01' });
    expect(partyDate('31/02/2020')).toBeNull();
    expect(partyDate('  /  /    ')).toBeNull();
    expect(partyDate('')).toBeNull();
  });

  it('filters the list as the search box and the name type-ahead do', () => {
    const rows = [
      { code: '100201', name: 'RAMESH SHAH', mobile: '9876543210', lc: '01' },
      { code: '100202', name: 'SURESH RAMANI', mobile: '9123456780', lc: '01' },
    ];
    expect(filterPartyList(rows, 'ram', 'search').map((r) => r.code)).toEqual(['100201', '100202']);
    expect(filterPartyList(rows, '9123', 'search').map((r) => r.code)).toEqual(['100202']);
    expect(filterPartyList(rows, '3210', 'search')).toEqual([]);
    expect(filterPartyList(rows, 'ram', 'name').map((r) => r.code)).toEqual(['100201']);
    expect(filterPartyList(rows, '', 'name')).toHaveLength(2);
  });

  it('builds the desktop messages with their spacing', () => {
    expect(partyNameTakenMessage('100201')).toBe(
      "This Ac Name already Exist in  '100201'  Ac Code... Please Change Account Name...",
    );
    expect(partyBranchMessage('02')).toBe('This Ac Code Is Branch With : 02 You Cant Change...');
    expect(partyMobileTakenMessage('RAMESH')).toBe(
      'This Mobile No = RAMESH  With this Account .....',
    );
    expect(partyMobileBranchMessage('RAMESH', '200201', '02')).toBe(
      'This Mobile No With = RAMESH Party Name  And AcCode = 200201  Branch With  02  Branch ...',
    );
    expect(partyShortTakenMessage('RAMESH')).toBe(
      'This Short Name = RAMESH  With this Account .....',
    );
  });
});
