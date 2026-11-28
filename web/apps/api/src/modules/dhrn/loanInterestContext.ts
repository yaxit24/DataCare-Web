import { round, roundHalfEven, roundHalfEvenDecimal, toIsoDate } from '@datacare/core';
import { resolveSettingsBehaviorTx, interestDayCount } from '../shared/settingsBehavior.js';
import { configuredBookTx, requireBookFamily } from '../finance/lifecycle.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import { DhrnValidationError } from './dhrn.js';
import type { DhrnInterestInput } from './dhrnInterest.js';

/** Loan reference hydration: TR_DHRN_INTREC.cs:5877-6005. Scope all identities, including prior years. */
export async function loanInterestContextTx(tx: any, input: DhrnInterestInput) {
  const s = input.scope;
  requireBookFamily(await configuredBookTx(tx, s), 'LOAN INT ENTRY');
  if (!input.isuBook || !input.isuYear) throw new DhrnValidationError('Select the loan reference book and year');
  const rows = await tx.$queryRawUnsafe(
    `SELECT a.*, a."VCH_DATE"::text issue_date FROM "DHRN_ISU_DATA" a
     JOIN "BOOK_DATA" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."LC_CODE"=a."LC_CODE" AND b."CO_BOOK"=a."CO_BOOK"
     WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5 AND a."VCH_NO"=$6 AND a."AC_CODE"=$7 AND b."MAIN_BOOK"='LOAN REC'`,
    s.tenantId, s.coCode, s.lcCode, input.isuYear, input.isuBook, formatVoucherNo(input.isuNo), input.borrowerAc,
  );
  if (rows.length !== 1) throw new DhrnValidationError('Loan reference not found for this party, book and year');
  const issue = rows[0];
  const lt = String(issue.LOAN_TYPE || 'A') as 'A' | 'G' | 'S';
  if (input.loanType && input.loanType !== lt) throw new DhrnValidationError('Loan type does not match the reference');
  const [prior] = await tx.$queryRawUnsafe(
    `SELECT coalesce(sum("DHRN_REC_AMT"),0)::float8 paid, coalesce(sum("UNCHAK_DHRN_REC"),0)::float8 unchak, max("TO_DATE")::text last_date
       FROM "DHRN_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "ISU_YRCD"=$4 AND "ISU_DBCD"=$5 AND "ISU_NO"=$6 AND "AC_CODE"=$7`,
    s.tenantId, s.coCode, s.lcCode, input.isuYear, input.isuBook, formatVoucherNo(input.isuNo), input.borrowerAc,
  );
  const cfg = await resolveSettingsBehaviorTx(tx, { tenantId: s.tenantId, coCode: s.coCode });
  const fromDate = input.fromDate || toIsoDate(prior.last_date || issue.issue_date);
  const toDate = input.toDate || input.vchDate || new Date();
  const intMonth = input.intMonth ?? 0;
  const intDay = cfg.loanIntType === 'M' ? intMonth * 30 : interestDayCount(fromDate, toDate, cfg.intDay);
  const principal = Number(issue.DHRN_AMT || 0);
  const adjusted = Number(prior.paid || 0);
  // The desktop's pending field subtracts old regular principal; unchak is displayed separately.
  const outstanding = round(roundHalfEvenDecimal(principal, 8).minus(adjusted), lt === 'A' ? 2 : 3);
  const rate = input.intPrc ?? Number(issue.INT_PRC || 0);
  const monthInterest = input.monthInterest ?? Number(issue.MONTH_INT_AMT || 0);
  // Loan mode starts with compound unchecked (TR_DHRN_INTREC.cs:4359-4362).
  const computed = cfg.loanIntType === 'M' && monthInterest
    ? roundHalfEven(roundHalfEvenDecimal(monthInterest, 8).mul(intMonth), lt === 'A' ? 0 : 3)
    : roundHalfEven(roundHalfEvenDecimal(outstanding, 8).mul(rate).div(100).mul(intDay).div(cfg.intYearDays), lt === 'A' ? 0 : 3);
  return { ...input, loanType: lt, interest: input.interest ?? computed, intPrc: rate, fromDate, toDate, intMonth, intDay, monthInterest,
    loanAmount: input.loanAmount ?? principal, oldReceived: input.oldReceived ?? adjusted,
    outstandingAmount: input.outstandingAmount ?? outstanding, dhrnDate: input.dhrnDate || toIsoDate(issue.issue_date),
    dhrnMonths: input.dhrnMonths ?? Number(issue.DHRN_MONTH || 0), billNo: input.billNo ?? String(issue.DHRN_BILL || '') };
}

export async function assertLoanBookTx(tx: any, scope: VoucherScope) {
  const book = await configuredBookTx(tx, scope);
  requireBookFamily(book, 'LOAN INT ENTRY');
  return book;
}

/** TR_DHRN_INTREC.cs:4648-4653: type B may edit existing vouchers, but cannot create. */
export async function assertLoanCreateTx(tx: any, scope: VoucherScope) {
  const rows = await tx.$queryRawUnsafe(`SELECT "CO_TYPE" FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`, scope.tenantId, scope.coCode);
  if (rows.some((r: any) => String(r.CO_TYPE).trim() === 'B')) throw new DhrnValidationError('You Cant Save This Voucher Becouse This Company Type is B......');
}
