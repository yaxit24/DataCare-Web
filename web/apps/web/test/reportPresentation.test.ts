import { describe, expect, it } from 'vitest';
import { formatReportCell } from '../lib/reportPresentation';

const date = { type: 'date' } as const;

describe('report cell presentation', () => {
  it('formats explicitly typed ISO timestamps as desktop dates', () => {
    expect(formatReportCell('2026-11-01T00:00:00.000Z', date)).toBe('01/11/2026');
  });

  it('formats explicitly typed ISO dates as desktop dates', () => {
    expect(formatReportCell('2026-11-01', date)).toBe('01/11/2026');
  });

  it('renders nullish values as empty strings', () => {
    expect(formatReportCell(null, date)).toBe('');
    expect(formatReportCell(undefined)).toBe('');
  });

  it('keeps untyped text and numbers unchanged', () => {
    expect(formatReportCell('Contra')).toBe('Contra');
    expect(formatReportCell(12345.67)).toBe('12345.67');
  });

  it('does not infer dates from untyped ISO-looking text', () => {
    expect(formatReportCell('2026-11-01T00:00:00.000Z')).toBe('2026-11-01T00:00:00.000Z');
  });
});
