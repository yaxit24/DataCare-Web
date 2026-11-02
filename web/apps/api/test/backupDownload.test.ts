import { describe, expect, it, vi } from 'vitest';
import type { CompanyBackupDocument } from '../src/modules/ops/backupManifest.js';
import { prepareBackupDownload } from '../src/modules/ops/backupDownload.js';

const archive = (generatedAt: string) =>
  ({
    kind: 'datacare.company-backup',
    version: 2,
    generatedAt,
  }) as CompanyBackupDocument;

describe('Data Backup download orchestration', () => {
  it('captures 17:59 before generation completes after 18:00 and keeps filename hour 17', async () => {
    const document = archive('2026-11-02T18:00:00.001Z');
    const events: string[] = [];
    const record = vi.fn(async () => {
      events.push('record');
    });

    const result = await prepareBackupDownload('2024-2025', {
      now: () => {
        events.push('clock');
        return new Date(2026, 10, 2, 17, 59, 59, 999);
      },
      generate: async () => {
        events.push('generate');
        return document;
      },
      loadCompanyType: async () => {
        events.push('company-type');
        return 'R';
      },
      record,
    });

    expect(events).toEqual(['clock', 'generate', 'company-type', 'record']);
    expect(result.filename).toBe('Next24_R_021126_17.json');
    expect(result.data).toBe(document);
    expect(result.data.generatedAt).toBe('2026-11-02T18:00:00.001Z');
    expect(record).toHaveBeenCalledWith(document);
  });
});
