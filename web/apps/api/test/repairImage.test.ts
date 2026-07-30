import { describe, expect, it } from 'vitest';
import { RepairWorkflowValidationError } from '../src/modules/repair/repairWorkflowCommon.js';
import {
  REPAIR_IMAGE_MAX_BYTES,
  REPAIR_IMAGE_TYPE,
  decodeRepairImage,
  repairImageNo,
  resolveRepairImageKey,
} from '../src/modules/repair/repairImage.js';

const scope = {
  tenantId: 't1',
  coCode: '01',
  lcCode: '02',
  coYear: '2024-2025',
  coBook: 'RCR',
};

const jpeg = (extra = 8): Buffer =>
  Buffer.concat([Buffer.from([0xff, 0xd8, 0xff]), Buffer.alloc(extra, 7)]);
const png = (): Buffer =>
  Buffer.concat([
    Buffer.from([0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a]),
    Buffer.alloc(4, 3),
  ]);

describe('repair image keys', () => {
  it('builds the exact desktop image number from company, location, year prefix, book, voucher and serial', () => {
    expect(
      repairImageNo({
        coCode: '01',
        lcCode: '02',
        coYear: '2024-2025',
        coBook: 'RCR',
        voucherNo: '00007',
        srNo: 3,
      }),
    ).toBe('01022024RCR000073');
    expect(REPAIR_IMAGE_TYPE).toBe('ReparingImage');
  });

  it('resolves a source-row key using the supplied year and book, defaulting to the current year', () => {
    expect(resolveRepairImageKey(scope, { coBook: 'RCR', vchNo: 7, srNo: 1 })).toEqual({
      coYear: '2024-2025',
      coBook: 'RCR',
      voucherNo: '00007',
      srNo: 1,
      imageNo: '01022024RCR000071',
    });
    expect(
      resolveRepairImageKey(scope, {
        coBook: 'RKI',
        coYear: '2023-2024',
        vchNo: '00012',
        srNo: 2,
      }).imageNo,
    ).toBe('01022023RKI000122');
  });

  it('rejects incomplete or invalid keys', () => {
    expect(() => resolveRepairImageKey(scope, { coBook: '', vchNo: 1, srNo: 1 })).toThrow(
      RepairWorkflowValidationError,
    );
    expect(() => resolveRepairImageKey(scope, { coBook: 'RCR', vchNo: 1, srNo: 0 })).toThrow(
      RepairWorkflowValidationError,
    );
    expect(() => resolveRepairImageKey(scope, { coBook: 'RCR', vchNo: 'abc', srNo: 1 })).toThrow(
      RepairWorkflowValidationError,
    );
  });
});

describe('repair image payload validation', () => {
  it('accepts JPEG and PNG payloads, including data URLs', () => {
    expect(decodeRepairImage({ data: jpeg().toString('base64') }).mimeType).toBe('image/jpeg');
    expect(
      decodeRepairImage({
        data: `data:image/png;base64,${png().toString('base64')}`,
        mimeType: 'image/png',
      }).mimeType,
    ).toBe('image/png');
  });

  it('rejects empty, oversized, non-image and mislabelled payloads', () => {
    expect(() => decodeRepairImage({ data: '' })).toThrow(RepairWorkflowValidationError);
    expect(() =>
      decodeRepairImage({ data: Buffer.from('not-an-image').toString('base64') }),
    ).toThrow(/JPEG or PNG/);
    expect(() =>
      decodeRepairImage({ data: jpeg().toString('base64'), mimeType: 'image/png' }),
    ).toThrow(/content is image\/jpeg/);
    expect(() =>
      decodeRepairImage({
        data: Buffer.concat([
          Buffer.from([0xff, 0xd8, 0xff]),
          Buffer.alloc(REPAIR_IMAGE_MAX_BYTES, 1),
        ]).toString('base64'),
      }),
    ).toThrow(/exceeds/);
    expect(() => decodeRepairImage({ data: '***not base64***' })).toThrow(/base64/);
  });
});
