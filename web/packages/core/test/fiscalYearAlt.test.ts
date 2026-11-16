import { describe, expect, it } from 'vitest';
import * as core from '@datacare/core';

// Pure rules of the alternate-year company (CO_MAST.ALTER_YEAR = 'Y'). No database is needed.
// The functions do not exist yet: `impl-alt` adds them to @datacare/core and removes this cast.
const coreAny = core as any;
const alternateYearDefaults = (today: { year: number; month: number }) =>
  coreAny.alternateYearDefaults(today) as {
    coYear: string;
    yearMonth: string;
    opDate: string;
    clDate: string;
  };
const alternateYearKey = (coYear: string, yearMonth: string) =>
  coreAny.alternateYearKey(coYear, yearMonth) as string;

// Desktop rule for the alternate-year company (MS_YEAR.cs:1010-1023):
// MS_YEAR.cs:1010 {{if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)}}
// MS_YEAR.cs:1012 {{tMonth.Text = Strings.Mid(Conversions.ToString(DateAndTime.Today), 4, 2);}}
// MS_YEAR.cs:1015 {{tYearCode.Text = Strings.Mid(Conversions.ToString(DateAndTime.Today), 7, 4) + "-" +}}
// MS_YEAR.cs:1016 {{mOpDate.Text = "01/" + tMonth.Text + "/" + Strings.Mid(tYearCode.Text, 1, 4);}}
// MS_YEAR.cs:1017 {{mClDate.Text = "01/" + tMonth.Text + "/" + Strings.Mid(tYearCode.Text, 6, 4);}}
// MS_YEAR.cs:1022 {{mOpDate.Text = "01/" + tMonth.Text + "/" + Strings.Mid(tYearCode.Text, 6, 4);}}
// MS_YEAR.cs:1023 {{Strings.Format((object)(Conversions.ToDouble(Strings.Mid(tYearCode.Text, 6, 4)) + 1.0), "00")}}
describe('alternateYearDefaults (desktop MS_YEAR alternate-year fill)', () => {
  it('16 Nov 2026: code 2026-2027, month 11, opening 2026-11-01, closing 2027-11-01', () => {
    expect(alternateYearDefaults({ year: 2026, month: 11 })).toEqual({
      coYear: '2026-2027',
      yearMonth: '11',
      opDate: '2026-11-01',
      clDate: '2027-11-01',
    });
  });

  it('15 Feb 2027 (January to March): code 2026-2027, month 02, opening 2027-02-01, closing 2028-02-01', () => {
    expect(alternateYearDefaults({ year: 2027, month: 2 })).toEqual({
      coYear: '2026-2027',
      yearMonth: '02',
      opDate: '2027-02-01',
      clDate: '2028-02-01',
    });
  });

  it('1 Apr 2026 (April boundary): code 2026-2027, month 04, opening 2026-04-01, closing 2027-04-01', () => {
    expect(alternateYearDefaults({ year: 2026, month: 4 })).toEqual({
      coYear: '2026-2027',
      yearMonth: '04',
      opDate: '2026-04-01',
      clDate: '2027-04-01',
    });
  });

  it('31 Mar 2027 (March boundary): code 2026-2027, month 03, opening 2027-03-01, closing 2028-03-01', () => {
    expect(alternateYearDefaults({ year: 2027, month: 3 })).toEqual({
      coYear: '2026-2027',
      yearMonth: '03',
      opDate: '2027-03-01',
      clDate: '2028-03-01',
    });
  });
});

// MS_YEAR.cs:1189 {{dataRow["CO_YEAR"] = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;}}
describe('alternateYearKey (desktop CO_YEAR of the alternate-year company)', () => {
  it('joins the first four characters of the code and the two-digit month', () => {
    expect(alternateYearKey('2026-2027', '11')).toBe('202611');
    expect(alternateYearKey('2026-2027', '02')).toBe('202602');
  });

  it('pads a one-digit month to two digits', () => {
    expect(alternateYearKey('2026-2027', '7')).toBe('202607');
  });
});
