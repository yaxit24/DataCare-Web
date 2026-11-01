import { describe, expect, it } from 'vitest';
import { approvalLineFromApi } from '../components/ApprovalGrid';

describe('approval grid round trip', () => {
  it('reopens a stored zero-piece line as zero rather than the new-row default of one', () => {
    // TR_APR_ISU.cs:3414-3426 defaults only a newly added row; DISPLAY_DATA :5841-5913 restores ITM_PCS.
    expect(approvalLineFromApi({ itCode: 'GOLD', pcs: 0 }).pcs).toBe('0');
  });
});
