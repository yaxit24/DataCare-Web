/**
 * Company → Company (desktop MS_COMPANY) keyboard map. Citations are to
 * `unified/src/csharp/DataCareNext/MS_COMPANY.cs`.
 *
 * The desktop form has three TabMenu pages, added in this order (`:4151-4156`): Tab1 "Company Detail" (`:4589`),
 * Tab2 "Tax Detail" (`:4805`), Tab3 "Bank Detail" (`:5022`). The web draws them as three sections of one panel, so
 * the desktop's `TabMenu.SelectNextTab()` becomes focus moving into the next section.
 *
 * Most boxes answer Enter with `SendKeys.Send("{tab}")`, so their next field is the next TabIndex on the same page
 * (Pnl1 0-16, Pnl2 17-21, Pnl3 22-25). The explicit jumps are:
 *   tCoCode   → cboWithOldCoMast, or stays with "Please Insert Co Code ..." when blank (`:6483-6500`)
 *   tCoName   → cboWithOldCoMast, or stays with "Please Insert Co Name ..." when blank (`:6502-6534`)
 *   cboWithOldCoMast → tCoName when the name is blank, else tAddress1 (`:7303-7320`)
 *   tStateCode → TState when the code is a known state, else the state help (`:7209-7251`)
 *   cboRptHader → SelectNextTab, tGstNo (`:6748-6752`)
 *   tJudrection → SelectNextTab, tBankName (`:6656-6665`)
 *   tRtgsNo   → Save enabled and focused (`:6737-6746`)
 *   tCoType   → Save enabled and focused (`:7279-7290`)
 */

export type CompanyMode = 'view' | 'new' | 'edit';

/** The three TabMenu pages, each field in its desktop TabIndex order. */
export const COMPANY_SECTIONS: { legend: string; keys: string[] }[] = [
  {
    // Pnl1 TabIndex 0-16; tCoType (144) is disabled until Ctrl+O (:4253).
    legend: 'Company Detail',
    keys: [
      'CO_NAME',
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
      'CO_TYPE',
    ],
  },
  { legend: 'Tax Detail', keys: ['CO_GST_NO', 'CO_CSTNO', 'CO_PAN_NO', 'DHIRAN_NO', 'CO_JUD'] },
  { legend: 'Bank Detail', keys: ['BANK_NAME', 'BANK_AREA', 'BANK_AC_NO', 'BANK_RTGS_NO'] },
];

/** Pseudo keys for the boxes outside the CO_MAST field list. */
export const OLD = 'OLD';
const YEAR_CHAIN = ['YEAR', 'OPENING', 'CLOSING'];

const ids: Record<string, string> = {
  CO_CODE: 'company-code',
  OLD: 'company-old',
  YEAR: 'company-year',
  OPENING: 'company-opening',
  CLOSING: 'company-closing',
};
export const companyFieldId = (key: string) => ids[key] ?? `company-${key}`;
export const companyFieldKey = (id: string): string | undefined => {
  const named = Object.entries(ids).find(([, value]) => value === id);
  if (named) return named[0];
  return id.startsWith('company-') ? id.slice('company-'.length) : undefined;
};

/** Plain `{tab}` successors inside one page. */
const TAB_NEXT: Record<string, string> = {
  CO_ADD1: 'CO_ADD2',
  CO_ADD2: 'CO_ADD3',
  CO_ADD3: 'CO_COUNTRY',
  CO_COUNTRY: 'CO_STATE_CODE',
  CO_STATE: 'CO_CITY',
  CO_CITY: 'CO_PIN',
  CO_PIN: 'CO_PHONE',
  CO_PHONE: 'CO_PHONE2',
  CO_PHONE2: 'CO_MOBILE',
  CO_MOBILE: 'CO_MOBILE2',
  CO_MOBILE2: 'CO_MAIL',
  CO_MAIL: 'WORK_TYPE',
  WORK_TYPE: 'METAL_TYPE',
  METAL_TYPE: 'REP_ADD_TYPE',
  REP_ADD_TYPE: 'CO_GST_NO', // SelectNextTab → Tax Detail
  CO_GST_NO: 'CO_CSTNO',
  CO_CSTNO: 'CO_PAN_NO',
  CO_PAN_NO: 'DHIRAN_NO',
  DHIRAN_NO: 'CO_JUD',
  CO_JUD: 'BANK_NAME', // SelectNextTab → Bank Detail
  BANK_NAME: 'BANK_AREA',
  BANK_AREA: 'BANK_AC_NO',
  BANK_AC_NO: 'BANK_RTGS_NO',
  YEAR: 'OPENING',
  OPENING: 'CLOSING',
};

export type CompanyEnterAction =
  | { kind: 'focus'; key: string; state?: string }
  | { kind: 'stay'; message?: string }
  | { kind: 'save' }
  | { kind: 'none' };

export function companyEnterAction(input: {
  key: string;
  mode: CompanyMode;
  values: Record<string, string | undefined>;
  /** The "With Old Company Master" box exists only for a new company; DISPLAY_DATA hides it (:5964-5965). */
  hasOld: boolean;
  stateName: (code: string) => string | undefined;
}): CompanyEnterAction {
  const { key, mode, values, hasOld } = input;
  const nameBlank = !(values.CO_NAME ?? '').trim();
  // A hidden cboWithOldCoMast cannot take focus on the desktop; the web skips it as Tab would.
  switch (key) {
    case 'CO_CODE':
      if (!(values.CO_CODE ?? '').trim())
        return { kind: 'stay', message: 'Please Insert Co Code ...' };
      return { kind: 'focus', key: hasOld ? OLD : 'CO_NAME' };
    case 'CO_NAME':
      if (nameBlank) return { kind: 'stay', message: 'Please Insert Co Name ...' };
      return { kind: 'focus', key: hasOld ? OLD : 'CO_ADD1' };
    case OLD:
      return { kind: 'focus', key: nameBlank ? 'CO_NAME' : 'CO_ADD1' };
    case 'CO_STATE_CODE': {
      const state = input.stateName((values.CO_STATE_CODE ?? '').trim());
      // Unknown code: the desktop opens the state help and keeps focus here; the web's list is the box's datalist.
      return state === undefined ? { kind: 'stay' } : { kind: 'focus', key: 'CO_STATE', state };
    }
    case 'BANK_RTGS_NO':
      // A new company's first year is asked on the screen (the desktop opens MS_YEAR after Save), so the
      // Year Create boxes come before Save.
      return mode === 'new' ? { kind: 'focus', key: YEAR_CHAIN[0]! } : { kind: 'save' };
    case 'CLOSING':
    case 'CO_TYPE':
      return { kind: 'save' };
  }
  const next = TAB_NEXT[key];
  return next ? { kind: 'focus', key: next } : { kind: 'none' };
}
