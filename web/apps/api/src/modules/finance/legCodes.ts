import type { PayMode } from './finance.js';

/**
 * Desktop cash-book leg codes (direction-specific; receipt/payment share none), Cash_Ledr, Ac_Ledr.cs:565-583:
 *   CASH REC 01 party Cr / 02 cash Dr · 03 party Cr / 04 kasar Dr (kasar 00057 JAVK)
 *   CASH PAY 05 party Dr / 06 cash Cr · 07 party Dr / 08 kasar Cr (kasar 00042 AVAK)
 * The kasar account mirrors the money (JAVK out / AVAK in).
 */
export const CASH_LEG = {
  recParty: 1,
  recCash: 2,
  recKasarParty: 3,
  recKasar: 4,
  payParty: 5,
  payCash: 6,
  payKasarParty: 7,
  payKasar: 8,
} as const;

/**
 * BANK leg codes, Bank_Ledr, Ac_Ledr.cs:585-610 (measured across all 228 legs of the 11 active bank books for
 * 01/02 and 07/08). NOT a mirror of cash:
 *   BANK REC 01 party Cr / 02 bank Dr · 03 party Cr / 04 kasar Dr · 05 bank Cr / 06 charges Dr (BANK_CHARGES)
 *   BANK PAY 07 party Dr / 08 bank Cr · 09 party Dr / 10 kasar Cr · 11 bank Cr / 12 charges Dr (BANK_CHARGES)
 */
export const BANK_LEG = {
  recParty: 1,
  recBank: 2,
  recKasarParty: 3,
  recKasar: 4,
  recChargesBank: 5,
  recCharges: 6,
  payParty: 7,
  payBank: 8,
  payKasarParty: 9,
  payKasar: 10,
  payChargesBank: 11,
  payCharges: 12,
} as const;

/**
 * The payment leg map for a mode: bank payments use 07/08 (amount) and 09/10 (kasar) where cash payments use
 * 05/06 and 07/08 (Ac_Ledr.cs:577-583 against :600-605). A bank payment's kasar on 07/08 collided with its own
 * amount legs, so one voucher carried two legs under each of the keys `107` and `108`.
 */
export const legsFor = (mode: PayMode) =>
  mode === 'cash'
    ? {
        party: CASH_LEG.payParty,
        account: CASH_LEG.payCash,
        kasarParty: CASH_LEG.payKasarParty,
        kasar: CASH_LEG.payKasar,
      }
    : {
        party: BANK_LEG.payParty,
        account: BANK_LEG.payBank,
        kasarParty: BANK_LEG.payKasarParty,
        kasar: BANK_LEG.payKasar,
      };
