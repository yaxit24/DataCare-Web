import { round } from '@datacare/core';
import type { ReceiptPaymentLine } from './finance.js';

/** A refusal the operator sees (HTTP 400). Defined here so the grid rules below need nothing from finance.ts at run time. */
export class FinanceValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'FinanceValidationError';
  }
}

/**
 * The grid lines the desktop saves. TR_CASH.cs:3014 saves a row when its account is not empty and
 * Amount + Kasar is not zero, so a line of Amount 0.00 with Kasar 5.00 (a balance written off with no cash
 * moving) is saved. Cash_Ledr/Bank_Ledr then write each ledger pair only for a non-zero column
 * (Ac_Ledr.cs:567 `A.REC_AMT <> 0`, :571 `A.KASAR_AMT <> 0`), so such a line posts the kasar pair alone.
 *
 * DELIBERATE DIFFERENCE: the desktop's `<> 0` tests would also post a negative Amount or Kasar as a negative
 * ledger figure. The web refuses it with a visible error instead of writing negative legs.
 */
export function gridLinesToSave(
  rawLines: ReceiptPaymentLine[] | undefined,
  emptyMessage: string,
): ReceiptPaymentLine[] {
  const num = (v: unknown): number => round(Number(v) || 0, 2);
  const withAccount = (rawLines ?? []).filter((l) => l && String(l.partyAc ?? '').trim());
  for (const l of withAccount) {
    if (num(l.amount) < 0 || num(l.kasar) < 0)
      throw new FinanceValidationError(
        `amount and kasar cannot be negative (account ${l.partyAc})`,
      );
  }
  const lines = withAccount.filter((l) => round(num(l.amount) + num(l.kasar), 2) !== 0);
  if (!lines.length) throw new FinanceValidationError(emptyMessage);
  return lines;
}
