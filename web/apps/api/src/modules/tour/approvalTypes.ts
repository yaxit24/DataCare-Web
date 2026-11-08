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
  DUPLICATE_TAG: 'Duplicate Tag No',
  LEGACY_RETURN_UNLINKED:
    'Approval Return source or tag link is missing, ambiguous, or inconsistent; repair this legacy voucher before edit or delete.',
  DELETE_RETURNED: 'You Cant Delete this Voucher Because This Voucher Is Approval Returne....',
  DELETE_SALE: 'You Cant Delete this Voucher Because This Voucher Use In Sales....',
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
  discountPct?: number;
  discountAmount?: number;
  netAmount?: number;
  itType?: string;
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
  const weight = num(line.netWt) + num(line.ghtWt);
  const purity = num(line.touch) + num(line.westPct);
  return approvalRound3(purity === 0 ? weight : (weight * purity) / 100);
}

export function tourLineDiscountAmount(line: TourIssueLine): number {
  const pct = num(line.discountPct);
  const labour = num(line.labourAmount);
  return round(pct !== 0 && labour !== 0 ? (labour * pct) / 100 : num(line.discountAmount), 2);
}

export function tourLineNetAmount(line: TourIssueLine): number {
  return round(
    num(line.amount) +
      num(line.labourAmount) +
      num(line.otherAmount) +
      num(line.mrp) -
      tourLineDiscountAmount(line),
    1,
  );
}

function assertDerivedDecimal(
  line: number,
  field: 'fineWt' | 'netAmount',
  value: number,
  exclusiveLimit: number,
  column: string,
): void {
  if (!Number.isFinite(value) || Math.abs(value) >= exclusiveLimit) {
    throw new TourValidationError(
      `approval line ${line} derived ${field} exceeds ${column} precision`,
    );
  }
}

export function completeApprovalScope(scope: VoucherScope): CompleteApprovalScope {
  return completeFinanceScope(scope);
}

export function approvalBusinessDate(value: unknown): { iso: string; date: Date } {
  const iso = toIsoDate(value || new Date());
  if (!iso) throw new TourValidationError('voucher date is missing or invalid');
  return { iso, date: new Date(`${iso}T00:00:00.000Z`) };
}

function explicitStableId(value: unknown, label: string): number | undefined {
  if (value == null) return undefined;
  const id = Number(value);
  if (!Number.isSafeInteger(id) || id <= 0)
    throw new TourValidationError(`${label} must be a positive integer`);
  return id;
}

/** TR_APR_ISU.cs:3414-3421 keeps durable row IDs during edit and appends above the saved maximum. */
export function allocateApprovalStableIds(lines: TourIssueLine[]): TourIssueLine[] {
  const explicitLineIds = lines.map((line, index) =>
    explicitStableId(line.oldSrNo, `approval line ${index + 1} oldSrNo`),
  );
  const seenLines = new Set<number>();
  for (const id of explicitLineIds) {
    if (id === undefined) continue;
    if (seenLines.has(id)) throw new TourValidationError(`approval oldSrNo is duplicated: ${id}`);
    seenLines.add(id);
  }
  let nextLineId = Math.max(0, ...seenLines);
  return lines.map((line, lineIndex) => {
    const oldSrNo = explicitLineIds[lineIndex] ?? ++nextLineId;
    const rawStones = Array.isArray(line.stones) ? line.stones : [];
    const explicitStoneIds = rawStones.map((stone, stoneIndex) => {
      if (!stone || typeof stone !== 'object' || Array.isArray(stone))
        throw new TourValidationError(
          `approval line ${lineIndex + 1} stone ${stoneIndex + 1} is invalid`,
        );
      return explicitStableId(
        stone.isrNo,
        `approval line ${lineIndex + 1} stone ${stoneIndex + 1} isrNo`,
      );
    });
    const seenStones = new Set<number>();
    for (const id of explicitStoneIds) {
      if (id === undefined) continue;
      if (seenStones.has(id))
        throw new TourValidationError(`approval line ${lineIndex + 1} isrNo is duplicated: ${id}`);
      seenStones.add(id);
    }
    let nextStoneId = Math.max(0, ...seenStones);
    return {
      ...line,
      oldSrNo,
      stones: rawStones.map((stone, stoneIndex) => ({
        ...stone,
        isrNo: explicitStoneIds[stoneIndex] ?? ++nextStoneId,
      })),
    };
  });
}

export function normalizeApprovalLines(raw: unknown): TourIssueLine[] {
  if (!Array.isArray(raw)) throw new TourValidationError('approval requires item lines');
  const normalizedRows = raw.map((line: TourIssueLine, index) => {
    if (!line || typeof line !== 'object')
      throw new TourValidationError(`approval line ${index + 1} is invalid`);
    assertWestPct(line.westPct);
    const itCode = text(line.itCode).slice(0, 5);
    if (!itCode) throw new TourValidationError(`approval line ${index + 1} needs an item`);
    const fineWt = tourLineFine(line);
    const discountAmount = tourLineDiscountAmount(line);
    const netAmount = tourLineNetAmount(line);
    // APR_DETL.ITM_FINE is DECIMAL(14,3), NET_AMT is DECIMAL(18,2). Inputs fit their
    // individual columns but their desktop formulas can still overflow the derived target.
    assertDerivedDecimal(index + 1, 'fineWt', fineWt, 10 ** 11, 'APR_DETL.ITM_FINE');
    assertDerivedDecimal(index + 1, 'netAmount', netAmount, 10 ** 16, 'APR_DETL.NET_AMT');
    const normalized = {
      ...line,
      itCode,
      itType: text(line.itType).slice(0, 1),
      tagNo: isApprovalTag(line.tagNo) ? text(line.tagNo).slice(0, 15) : 'N',
      pcs: approvalRound3(line.pcs),
      grossWt: approvalRound3(line.grossWt),
      netWt: approvalRound3(line.netWt),
      touch: approvalRound3(line.touch),
      fineWt,
      discountAmount,
      netAmount,
      stones: Array.isArray(line.stones)
        ? line.stones.map((stone, stoneIndex) => {
            if (!stone || typeof stone !== 'object' || Array.isArray(stone))
              throw new TourValidationError(
                `approval line ${index + 1} stone ${stoneIndex + 1} is invalid`,
              );
            const stoneItCode = text(stone.itCode).slice(0, 5);
            if (!stoneItCode)
              throw new TourValidationError(
                `approval line ${index + 1} stone item ${stoneIndex + 1} is required`,
              );
            return { ...stone, itCode: stoneItCode };
          })
        : [],
    };
    // TR_APR_ISU.cs:6155-6157 inserts only MRP lines or rows with gross/labour/other value.
    if (
      !num(normalized.mrp) &&
      !num(normalized.grossWt) &&
      !num(normalized.labourAmount) &&
      !num(normalized.otherAmount)
    )
      throw new TourValidationError(
        `approval line ${index + 1} needs MRP, gross weight, labour amount, or other amount`,
      );
    return normalized;
  });
  if (!normalizedRows.length) throw new TourValidationError('at least one line item is required');
  const rows = allocateApprovalStableIds(normalizedRows);
  const seen = new Set<string>();
  for (const line of rows) {
    if (!isApprovalTag(line.tagNo)) continue;
    const key = `${text(line.tagNo)}|${num(line.vchSrno)}`;
    if (seen.has(key)) throw new TourValidationError(APPROVAL_MESSAGES.DUPLICATE_TAG);
    seen.add(key);
  }
  return rows;
}
