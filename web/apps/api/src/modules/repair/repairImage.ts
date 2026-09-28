import { withTenant } from '@datacare/db';
import {
  lockImageRevisionTx,
  readImageRevisionTx,
  advanceImageRevisionTx,
} from '../images/imageRevision.js';
import {
  compareImageVersion,
  imageStateVersion,
  imagePreview,
  validateImagePixels,
} from '../images/imageState.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import {
  RepairWorkflowValidationError,
  assertCompleteRepairScope,
  repairNumber,
} from './repairWorkflowCommon.js';

/**
 * Repair-line image persistence for desktop TR_REP_REC.
 *
 * Desktop writes one JPEG per repair line to a shared folder using the image number
 *   CO_CODE + LC_CODE + left(CO_YEAR,4) + CO_BOOK + VCH_NO + SR_NO
 * inside <MSImageSavePath>\ReparingImage\, and keys the image to the *source customer repair row*
 * when the current row was imported from one (KRREP ISSUE / KRREP RECEIPT / CUSTREP ISSUE), so the
 * same photo follows a repair through every stage. The web keeps that exact logical key but stores
 * the bytes in REP_IMAGE so the attachment is transactional, tenant-isolated and included in
 * database backups instead of living on an unmanaged file share.
 *
 * Desktop shows the image control only on CUSTREP RECEIPT and KRREP ISSUE; later stages hide it.
 */
export const REPAIR_IMAGE_TYPE = 'ReparingImage';

/** Desktop accepts JPEG through its file dialog; PNG is additionally allowed by the web upload. */
const ALLOWED: Array<{ mime: string; magic: number[] }> = [
  { mime: 'image/jpeg', magic: [0xff, 0xd8, 0xff] },
  { mime: 'image/png', magic: [0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a] },
];
export const REPAIR_IMAGE_MAX_BYTES = 4 * 1024 * 1024;

export interface RepairImageKeyInput {
  coYear?: string;
  coBook: string;
  vchNo: string | number;
  srNo: number | string;
}

export interface RepairImageKey {
  coYear: string;
  coBook: string;
  voucherNo: string;
  srNo: number;
  imageNo: string;
}

export interface RepairImageRecord extends RepairImageKey {
  imageType: string;
  mimeType: string;
  size: number;
  data: Buffer;
  mainUser: string;
  entryTime: string;
}

/** Exact desktop image number: company + location + fiscal-year prefix + book + voucher + serial. */
export function repairImageNo(input: {
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
  voucherNo: string;
  srNo: number;
}): string {
  return `${input.coCode}${input.lcCode}${input.coYear.slice(0, 4)}${input.coBook}${
    input.voucherNo
  }${input.srNo}`;
}

export function resolveRepairImageKey(
  scope: VoucherScope,
  input: RepairImageKeyInput,
): RepairImageKey {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode) {
    throw new RepairWorkflowValidationError('repair image requires tenant, company and location');
  }
  const coBook = String(input.coBook ?? '').trim();
  if (!coBook) throw new RepairWorkflowValidationError('repair image requires a book');
  const coYear = String(input.coYear ?? scope.coYear ?? '').trim();
  if (!coYear) throw new RepairWorkflowValidationError('repair image requires a fiscal year');
  const srNo = Number(input.srNo);
  if (!Number.isSafeInteger(srNo) || srNo < 1) {
    throw new RepairWorkflowValidationError(
      'repair image serial number must be a positive integer',
    );
  }
  let voucherNo: string;
  try {
    voucherNo = formatVoucherNo(input.vchNo);
  } catch {
    throw new RepairWorkflowValidationError(`invalid repair image voucher: ${input.vchNo}`);
  }
  return {
    coYear,
    coBook,
    voucherNo,
    srNo,
    imageNo: repairImageNo({
      coCode: scope.coCode,
      lcCode: scope.lcCode,
      coYear,
      coBook,
      voucherNo,
      srNo,
    }),
  };
}

/** Accept only real JPEG/PNG payloads so the store cannot be used to smuggle other content. */
export function decodeRepairImage(input: { data?: string; mimeType?: string }): {
  data: Buffer;
  mimeType: string;
} {
  const raw = String(input.data ?? '').trim();
  if (!raw) throw new RepairWorkflowValidationError('repair image data is required');
  const base64 = raw.startsWith('data:') ? raw.slice(raw.indexOf(',') + 1) : raw;
  if (!/^[A-Za-z0-9+/=\s]+$/.test(base64)) {
    throw new RepairWorkflowValidationError('repair image data must be base64');
  }
  const data = Buffer.from(base64, 'base64');
  if (!data.length) throw new RepairWorkflowValidationError('repair image data is empty');
  if (data.length > REPAIR_IMAGE_MAX_BYTES) {
    throw new RepairWorkflowValidationError(`repair image exceeds ${REPAIR_IMAGE_MAX_BYTES} bytes`);
  }
  const detected = ALLOWED.find((candidate) =>
    candidate.magic.every((byte, index) => data[index] === byte),
  );
  if (!detected) {
    throw new RepairWorkflowValidationError('repair image must be a JPEG or PNG file');
  }
  const declared = String(input.mimeType ?? '')
    .trim()
    .toLowerCase();
  if (declared && declared !== detected.mime) {
    throw new RepairWorkflowValidationError(
      `repair image content is ${detected.mime}, not ${declared}`,
    );
  }
  return { data, mimeType: detected.mime };
}

async function assertRepairLineExistsTx(
  tx: any,
  scope: VoucherScope,
  key: RepairImageKey,
): Promise<void> {
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "REP_DETL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND "SR_NO"::numeric=$7::numeric
      LIMIT 1 FOR SHARE`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    key.coYear,
    key.coBook,
    key.voucherNo,
    key.srNo,
  );
  if (!rows.length) {
    throw new RepairWorkflowValidationError(
      `repair line not found: ${key.coYear}/${key.coBook}/${key.voucherNo}/${key.srNo}`,
    );
  }
}

function repairRevisionKey(scope: VoucherScope, key: RepairImageKey) {
  return {
    tenantId: scope.tenantId,
    coCode: scope.coCode,
    lcCode: scope.lcCode,
    entityType: 'REPAIR',
    entityKey: JSON.stringify([key.coYear, key.coBook, key.voucherNo, key.srNo]),
    instance: 0,
  };
}

async function repairImageSnapshotTx(tx: any, scope: VoucherScope, key: RepairImageKey) {
  await assertRepairLineExistsTx(tx, scope, key);
  const values = [
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    key.coYear,
    key.coBook,
    key.voucherNo,
    key.srNo,
  ];
  const where =
    'tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND "SR_NO"::numeric=$7::numeric';
  const parents = await tx.$queryRawUnsafe(
    `SELECT xmin::text AS "generation",ctid::text AS "tuple" FROM "REP_DETL" WHERE ${where}`,
    ...values,
  );
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "IMAGE_NO","IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","REP_IMAGE","MAIN_USER","ENTRY_TIME"::text AS "entryTime" FROM "REP_IMAGE" WHERE ${where}`,
    ...values,
  );
  const revision = await readImageRevisionTx(tx, repairRevisionKey(scope, key));
  return {
    rows,
    version: imageStateVersion([
      values,
      revision,
      parents,
      rows.map(({ REP_IMAGE, ...row }) => ({
        ...row,
        data: Buffer.from(REP_IMAGE ?? []).toString('base64'),
      })),
    ]),
  };
}

export async function getRepairImageState(
  prisma: any,
  scope: VoucherScope,
  input: RepairImageKeyInput,
) {
  assertCompleteRepairScope(scope);
  const key = resolveRepairImageKey(scope, input);
  return withTenant(
    prisma,
    scope.tenantId,
    async (tx: any) => {
      const snapshot = await repairImageSnapshotTx(tx, scope, key);
      const row = snapshot.rows[0];
      return {
        version: snapshot.version,
        image: await imagePreview(
          row
            ? {
                bytes: Buffer.from(row.REP_IMAGE ?? []),
                mimeType: String(row.MIME_TYPE ?? ''),
                size: Number(row.IMAGE_SIZE),
                validType:
                  snapshot.rows.length === 1 &&
                  row.IMAGE_TYPE === REPAIR_IMAGE_TYPE &&
                  row.IMAGE_NO === key.imageNo,
              }
            : null,
        ),
      };
    },
    { isolationLevel: 'RepeatableRead' },
  );
}

/** Replace-on-save, exactly like the desktop button which deletes the old JPEG first. */
export async function saveRepairImage(
  prisma: any,
  input: {
    scope: VoucherScope;
    key: RepairImageKeyInput;
    data?: string;
    mimeType?: string;
    mainUser?: string;
    version?: string;
  },
): Promise<RepairImageKey & { size: number; mimeType: string; replaced: boolean }> {
  assertCompleteRepairScope(input.scope);
  const scope = input.scope;
  const key = resolveRepairImageKey(scope, input.key);
  const image = decodeRepairImage(input);
  if (input.version !== undefined) await validateImagePixels(image.data, image.mimeType);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await assertRepairLineExistsTx(tx, scope, key);
    const revisionKey = repairRevisionKey(scope, key);
    await lockImageRevisionTx(tx, revisionKey);
    if (input.version !== undefined)
      compareImageVersion(input.version, (await repairImageSnapshotTx(tx, scope, key)).version);
    const removed = await tx.$executeRawUnsafe(
      `DELETE FROM "REP_IMAGE"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND "SR_NO"::numeric=$7::numeric`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      key.coYear,
      key.coBook,
      key.voucherNo,
      key.srNo,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "REP_IMAGE"
         (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IMAGE_NO",
          "IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","REP_IMAGE","MAIN_USER","ENTRY_TIME")
       VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12,$13,now())`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      key.coYear,
      key.coBook,
      key.voucherNo,
      key.srNo,
      key.imageNo,
      REPAIR_IMAGE_TYPE,
      image.mimeType,
      image.data.length,
      image.data,
      String(input.mainUser ?? '').trim() || null,
    );
    await advanceImageRevisionTx(tx, revisionKey);
    return {
      ...key,
      size: image.data.length,
      mimeType: image.mimeType,
      replaced: Number(removed) > 0,
    };
  });
}

export async function getRepairImage(
  prisma: any,
  scopeInput: VoucherScope,
  keyInput: RepairImageKeyInput,
): Promise<RepairImageRecord | null> {
  assertCompleteRepairScope(scopeInput);
  const scope = scopeInput;
  const key = resolveRepairImageKey(scope, keyInput);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT * FROM "REP_IMAGE"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND "SR_NO"::numeric=$7::numeric
        LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      key.coYear,
      key.coBook,
      key.voucherNo,
      key.srNo,
    );
    const row = rows[0];
    if (!row) return null;
    const data = row.REP_IMAGE as Buffer;
    return {
      ...key,
      imageType: String(row.IMAGE_TYPE ?? REPAIR_IMAGE_TYPE),
      mimeType: String(row.MIME_TYPE ?? 'image/jpeg'),
      size: repairNumber(row.IMAGE_SIZE),
      data: Buffer.isBuffer(data) ? data : Buffer.from(data ?? []),
      mainUser: String(row.MAIN_USER ?? ''),
      entryTime: row.ENTRY_TIME ? new Date(row.ENTRY_TIME as string).toISOString() : '',
    };
  });
}

export async function deleteRepairImage(
  prisma: any,
  input: { scope: VoucherScope; key: RepairImageKeyInput; version?: string },
): Promise<{ deleted: boolean }> {
  assertCompleteRepairScope(input.scope);
  const scope = input.scope;
  const key = resolveRepairImageKey(scope, input.key);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    if (input.version !== undefined) await assertRepairLineExistsTx(tx, scope, key);
    const revisionKey = repairRevisionKey(scope, key);
    await lockImageRevisionTx(tx, revisionKey);
    if (input.version !== undefined)
      compareImageVersion(input.version, (await repairImageSnapshotTx(tx, scope, key)).version);
    const removed = await tx.$executeRawUnsafe(
      `DELETE FROM "REP_IMAGE"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND "SR_NO"::numeric=$7::numeric`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      key.coYear,
      key.coBook,
      key.voucherNo,
      key.srNo,
    );
    await advanceImageRevisionTx(tx, revisionKey);
    return { deleted: Number(removed) > 0 };
  });
}

/** Which lines of one repair voucher currently carry an image, for grid indicators. */
export async function listRepairImageKeys(
  prisma: any,
  scopeInput: VoucherScope,
  input: { coBook: string; vchNo: string | number; coYear?: string },
): Promise<Array<{ srNo: number; imageNo: string; mimeType: string; size: number }>> {
  assertCompleteRepairScope(scopeInput);
  const scope = scopeInput;
  const coBook = String(input.coBook ?? '').trim();
  if (!coBook) throw new RepairWorkflowValidationError('repair image list requires a book');
  const coYear = String(input.coYear ?? scope.coYear ?? '').trim();
  let voucherNo: string;
  try {
    voucherNo = formatVoucherNo(input.vchNo);
  } catch {
    throw new RepairWorkflowValidationError(`invalid repair image voucher: ${input.vchNo}`);
  }
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","IMAGE_NO","MIME_TYPE","IMAGE_SIZE" FROM "REP_IMAGE"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
        ORDER BY "SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      coYear,
      coBook,
      voucherNo,
    );
    return rows.map((row) => ({
      srNo: repairNumber(row.SR_NO),
      imageNo: String(row.IMAGE_NO ?? ''),
      mimeType: String(row.MIME_TYPE ?? 'image/jpeg'),
      size: repairNumber(row.IMAGE_SIZE),
    }));
  });
}
