import { describe, expect, it } from 'vitest';
import { buildBackupFilename } from '../src/modules/ops/backupFilename.js';

describe('Data Backup source-backed filename', () => {
  const hour = new Date(2026, 10, 2, 17, 42, 59, 999);

  it('uses the authenticated fiscal-year prefix, persisted type, and local hour', () => {
    expect(buildBackupFilename({ fiscalYear: '2024-2025', companyType: 'R', now: hour })).toBe(
      'Next24_R_021126_17.json',
    );
  });

  it('omits a blank type and gives every call in one hour the same suggestion', () => {
    const first = buildBackupFilename({
      fiscalYear: '2025-2026',
      companyType: '   ',
      now: new Date(2026, 10, 2, 17, 0, 0, 0),
    });
    const second = buildBackupFilename({
      fiscalYear: '2025-2026',
      companyType: '',
      now: new Date(2026, 10, 2, 17, 59, 59, 999),
    });
    expect(first).toBe('Next25_021126_17.json');
    expect(second).toBe(first);
  });

  it('sanitizes persisted type text and rejects an unusable fiscal year', () => {
    expect(
      buildBackupFilename({ fiscalYear: '2027', companyType: ' retail / gold ', now: hour }),
    ).toBe('Next27_RETAIL-GOLD_021126_17.json');
    expect(() => buildBackupFilename({ fiscalYear: 'year', companyType: 'R', now: hour })).toThrow(
      /fiscal year/i,
    );
  });
});
