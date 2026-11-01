import { describe, expect, it } from 'vitest';
import {
  approvalLineFromApi,
  approvalLineInput,
  approvalLinesWithStableIds,
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

  it('derives NET_AMT from every desktop amount component', () => {
    // TR_APR_ISU.cs:3936-3942: ITM_AMT + LBR_AMT + OTH_AMT + ITM_MRP - DISC_AMT.
    const line = approvalLineFromApi({
      amount: 100,
      labourAmount: 20,
      otherAmount: 5,
      mrp: 300,
      discountAmount: 10,
    });
    expect(approvalNetAmount(line)).toBe(415);
  });
});
