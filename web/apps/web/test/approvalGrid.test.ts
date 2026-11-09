import { describe, expect, it } from 'vitest';
import {
  approvalLineFromApi,
  approvalLineInput,
  approvalLinesWithStableIds,
  approvalDiscountAmount,
  approvalNetAmount,
  blankApprovalLine,
} from '../components/ApprovalGrid';

describe('approval grid round trip', () => {
  it('reopens a stored zero-piece line as zero rather than the new-row default of one', () => {
    // TR_APR_ISU.cs:3414-3426 defaults only a newly added row; DISPLAY_DATA :5841-5913 restores ITM_PCS.
    expect(approvalLineFromApi({ itCode: 'GOLD', pcs: 0 }).pcs).toBe('0');
  });

  it('allocates new line and stone IDs above retained maxima', () => {
    // TR_APR_ISU.cs:3414-3421 appends after the stable grid serial instead of reusing a gap.
    const retained = { ...blankApprovalLine(), oldSrNo: '2' };
    expect(
      approvalLinesWithStableIds([retained, blankApprovalLine()]).map((line) => line.oldSrNo),
    ).toEqual(['2', '3']);
    expect(
      approvalLineInput(retained, [
        { isrNo: 2, itCode: 'DIA01', netAmount: 2 },
        { itCode: 'DIA01', netAmount: 3 },
      ]).stones,
    ).toEqual([
      { isrNo: 2, itCode: 'DIA01', netAmount: 2 },
      { isrNo: 3, itCode: 'DIA01', netAmount: 3 },
    ]);
  });

  it('derives LDisc amount and displays NET_AMT at one decimal', () => {
    // TR_APR_ISU.cs:3936-3942: 20.05 × 10% = 2.01; 100.04 + 20.05 + .02 - 2.01
    // is formatted as 118.1 before save.
    const line = approvalLineFromApi({
      amount: 100.04,
      labourAmount: 20.05,
      otherAmount: 0.02,
      discountPct: 10,
    });
    expect(approvalDiscountAmount(line)).toBe(2.01);
    expect(approvalNetAmount(line)).toBe(118.1);
  });
});
