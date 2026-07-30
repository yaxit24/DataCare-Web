import { describe, it, expect } from 'vitest';
import { buildTagWhere, TagNotAvailableError, TagExistsError } from '../src/modules/stock/stock.js';

describe('tag stock builders', () => {
  it('buildTagWhere orders params CO_CODE, LC_CODE, TAG_NO', () => {
    const w = buildTagWhere({ CO_CODE: '01', LC_CODE: '02', TAG_NO: 'T1' });
    expect(w.params).toEqual(['01', '02', 'T1']);
    expect(w.sql).toContain('"TAG_NO"::text=$3');
  });

  it('adds VCH_SRNO as the fourth ordered tag identity parameter', () => {
    const w = buildTagWhere({ CO_CODE: '01', LC_CODE: '02', TAG_NO: 'T1', VCH_SRNO: 77 });
    expect(w.params).toEqual(['01', '02', 'T1', 77]);
    expect(w.sql).toContain('coalesce("VCH_SRNO",0)::numeric=$4::numeric');
  });

  it('error types carry the tag', () => {
    expect(new TagNotAvailableError('T9').name).toBe('TagNotAvailableError');
    expect(new TagExistsError('T9').tag).toBe('T9');
  });
});
