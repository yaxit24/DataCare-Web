import { formatDesktopDate, round, toIsoDate } from '@datacare/core';
import { assertWestPct } from '../shared/counterStockPolicy.js';
import type { StoneSubDetailInput } from '../shared/stoneSubDetail.js';
import { completeFinanceScope, num, text } from '../finance/lifecycle.js';
import type { VoucherScope } from '../vouchers/numbering.js';

export type ApprovalKind = 'issue' | 'return';
export type CompleteApprovalScope = VoucherScope & { coYear: string; coBook: string };

export class TourValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'TourValidationError';
  }
}

export class ApprovalNotFoundError extends Error {
  readonly statusCode = 404;
  readonly code = 'approval-not-found';
  constructor(kind: ApprovalKind, voucherNo: string) {
    super(`approval ${kind} voucher not found: ${voucherNo}`);
    this.name = 'ApprovalNotFoundError';
  }
}

export const APPROVAL_MESSAGES = {
  COMPANY_TYPE_B: 'You Cant Save This Voucher Becouse This Company Type is B......',
  NOT_IN_CURRENT_YEAR:
    'You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...',
  EMPLOYEE_REQUIRED: 'Please Select Employee Code and Try......',
  PARTY_REQUIRED: 'Please Insert Party and try',
  DELETE_RETURNED: 'You Cant Delete this Voucher Because This Voucher Is Approval Returne....',
  DELETE_WHOLESALE: 'You Cant Delete this Voucher Because This Voucher Use In Wh Sales....',
  lockDate: (date: string) =>
    `You Cant Save and Delete This Voucher Becouse Lock Date is = ${formatDesktopDate(date)} ....`,
} as const;

export interface TourStoneInput extends StoneSubDetailInput {
  isrNo?: number;
  itCode?: string;
  dmCode?: string;
  dmName?: string;
  dmSize?: string;
  dmSfNo?: string;
  pcs?: number;
  grossWt?: number;
  karigarWt?: number;
  conPct?: number;
  rateType?: string;
  rate?: number;
  amount?: number;
  lbrRate?: number;
  lbrAmount?: number;
  netAmount?: number;
  conWt?: number;
  itType?: string;
}

export interface TourIssueLine {
  oldSrNo?: number;
  origSrNo?: number;
  vchSrno?: number;
  lotNo?: string;
  itmColor?: string;
  tagCost?: number;
  hallmarkId2?: string;
  hallmarkId3?: string;
  hallmarkId4?: string;
  hallmarkIdWt?: number;
  hallmarkId2Wt?: number;
  hallmarkId3Wt?: number;
  hallmarkId4Wt?: number;
  adjustGrossWt?: number | string;
  adjustNetWt?: number | string;
  lessTouch?: number | string;
  lossWt?: number | string;
  itCode: string;
  tagNo?: string;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  fineWt?: number;
  remark?: string;
  isuAcName?: string;
  metalColor?: string;
  isuAcCode?: string;
  tblCode?: string;
  designNo?: string;
  itmSize?: string;
  huid?: string;
  bagWt?: number;
  lessWt?: number;
  ghtWt?: number;
  westPct?: number;
  labourPct?: number;
  labourType?: string;
  labourRate?: number;
  labourAmount?: number;
  otherAmount?: number;
  rate?: number;
  amount?: number;
  mrp?: number;
  karigarNetWt?: number;
  karigarTouch?: number;
  karigarWestPct?: number;
  karigarFine?: number;
  karigarName?: string;
  rateType?: string;
  prCode?: string;
  isuYrcd?: string;
  isuDbcd?: string;
  isuLcCode?: string;
  isuSrNo?: number;
  designImageId?: string;
  stones?: TourStoneInput[];
}

export interface TourIssueInput {
  scope: VoucherScope;
  vchDate?: Date | string;
  partyAc?: string;
  /** Kept for direct legacy callers; HTTP accepts only partyAc. */
  salesmanAc?: string;
  empCode?: string;
  vchDesc?: string;
  mainUser?: string;
  expectedVersion?: string;
  lines: TourIssueLine[];
}

export interface TourReturnInput extends TourIssueInput {
  origVchNo: number | string;
  origBook?: string;
  origYear?: string;
}

export type TourReturnLine = TourIssueLine & { origSrNo?: number };
export interface TourIssueResult {
  vchNo: number;
  voucherNo: string;
  fine: number;
  version: string;
}
export interface TourReturnResult extends TourIssueResult {
  closedLines: number;
}
export interface DeleteTourInput {
  scope: VoucherScope;
  vchNo: number | string;
  expectedVersion?: string;
  deleteUser?: string;
}

export type ApprovalRow = Record<string, any>;
export const approvalText = (value: unknown, max = 255): string | null =>
  text(value).slice(0, max) || null;
export const approvalRound3 = (value: unknown): number => round(num(value), 3);
export const isApprovalTag = (value: unknown): boolean =>
  !!text(value) && text(value).toUpperCase() !== 'N';

export function tourLineFine(line: TourIssueLine): number {
  if (line.fineWt != null) return approvalRound3(line.fineWt);
  return approvalRound3((num(line.netWt) * num(line.touch)) / 100);
}

export function completeApprovalScope(scope: VoucherScope): CompleteApprovalScope {
  return completeFinanceScope(scope);
}

export function approvalBusinessDate(value: unknown): { iso: string; date: Date } {
  const iso = toIsoDate(value || new Date());
  if (!iso) throw new TourValidationError('voucher date is missing or invalid');
  return { iso, date: new Date(`${iso}T00:00:00.000Z`) };
}

export function normalizeApprovalLines(raw: unknown): TourIssueLine[] {
  if (!Array.isArray(raw)) throw new TourValidationError('approval requires item lines');
  const rows = raw
    .map((line: TourIssueLine, index) => {
      if (!line || typeof line !== 'object')
        throw new TourValidationError(`approval line ${index + 1} is invalid`);
      assertWestPct(line.westPct);
      const itCode = text(line.itCode).slice(0, 5);
      if (!itCode) throw new TourValidationError(`approval line ${index + 1} needs an item`);
      return {
        ...line,
        oldSrNo: line.oldSrNo == null ? index + 1 : num(line.oldSrNo),
        itCode,
        tagNo: isApprovalTag(line.tagNo) ? text(line.tagNo).slice(0, 15) : 'N',
        pcs: approvalRound3(line.pcs),
        grossWt: approvalRound3(line.grossWt),
        netWt: approvalRound3(line.netWt),
        touch: approvalRound3(line.touch),
        fineWt: tourLineFine(line),
        stones: Array.isArray(line.stones) ? line.stones : [],
      };
    })
    .filter((line) => num(line.pcs) || num(line.grossWt) || num(line.netWt) || num(line.mrp));
  if (!rows.length) throw new TourValidationError('at least one line item is required');
  const seen = new Set<string>();
  for (const line of rows) {
    if (!isApprovalTag(line.tagNo)) continue;
    const key = `${text(line.tagNo)}|${num(line.vchSrno)}`;
    if (seen.has(key)) throw new TourValidationError(`Duplicate Tag No: ${text(line.tagNo)}`);
    seen.add(key);
  }
  return rows;
}
