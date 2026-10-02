import { createHash } from 'node:crypto';
import sharp from 'sharp';
import {
  lockImageRevisionTx,
  readImageRevisionTx,
  advanceImageRevisionTx,
} from './imageRevision.js';
import { withTxBudget, SNAPSHOT_READ } from '../shared/txBudget.js';
import { resolveBookPolicyTx } from '../shared/bookPolicy.js';
import { formatVoucherNo } from '../vouchers/numbering.js';
import { decodeEntityImage, ENTITY_IMAGE_MAX_BYTES } from './entityImage.js';

export type OrderImageFamily = 'SALES ORDER' | 'TOUR ORDER';
export interface OrderImageScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
}
export type ResolvedOrderImage =
  | { state: 'absent' }
  | {
      state: 'present';
      bytes: Buffer;
      mimeType: 'image/jpeg' | 'image/png';
      source: string;
    };
export class OrderImageError extends Error {
  constructor(
    public code: 'unavailable-image' | 'ambiguous-image' | 'invalid-image' | 'invalid-order-image',
    message: string,
  ) {
    super(message);
    this.name = 'OrderImageError';
  }
}
type SavedRow = Record<string, unknown>;
type ImageKey = {
  entityType: 'TAG' | 'DESIGN' | 'ORDER';
  entityKey: string;
  instance: number;
  lcCode: string;
  imageType: string;
};
const str = (value: unknown) => String(value ?? '').trim();
function badIdentity(message: string): never {
  throw new OrderImageError('invalid-order-image', message);
}

/** The filename used HD_VCH_NO, not the visible voucher number or parent serial. */
export function customOrderImageKey(
  scope: OrderImageScope,
  header: SavedRow,
  parent: SavedRow,
): string | null {
  const design = str(parent.DESIGN_NO);
  if (!design) return null;
  const hidden = str(parent.HD_VCH_NO);
  if (!hidden || hidden !== str(header.HD_VCH_NO))
    badIdentity('The saved order has an inconsistent hidden image identity.');
  const key = JSON.stringify([scope.coYear, scope.coBook, hidden, design]);
  if (key.length > 255) badIdentity('The saved order image identity exceeds storage capacity.');
  return key;
}

function candidates(
  scope: OrderImageScope,
  family: OrderImageFamily,
  header: SavedRow,
  parent: SavedRow,
): ImageKey[] {
  for (const field of ['tenantId', 'coCode', 'lcCode', 'coYear', 'coBook'] as const)
    if (!str(scope[field])) badIdentity(`Order image requires ${field}.`);
  const designId = str(parent.DESIGN_IMG_ID);
  const design: ImageKey | null =
    designId && designId !== 'N'
      ? { entityType: 'DESIGN', entityKey: designId, instance: 0, lcCode: '', imageType: 'D' }
      : null;
  // TR_SALE_ORD:9316,11527 selects a linked design before the tag/custom filename.
  // Blank imported IDs do not mean the explicit desktop sentinel N.
  if (family === 'SALES ORDER' && designId !== 'N') return design ? [design] : [];
  // DISPLAY_DATA restores the persisted N sentinel to an empty grid tag (TR_SALE_ORD:8678).
  // It must never resolve a shared photograph named N for every untagged order.
  const tag = str(parent.TAG_NO) === 'N' ? '' : str(parent.TAG_NO);
  let local: ImageKey | null = null;
  if (tag) {
    const instance = Number(parent.VCH_SRNO);
    if (parent.VCH_SRNO == null || !Number.isSafeInteger(instance) || instance < 0)
      badIdentity('The saved tag image requires its exact voucher instance.');
    local = { entityType: 'TAG', entityKey: tag, instance, lcCode: scope.lcCode, imageType: 'T' };
  } else {
    const key = customOrderImageKey(scope, header, parent);
    if (key)
      local = {
        entityType: 'ORDER',
        entityKey: key,
        instance: 0,
        lcCode: scope.lcCode,
        imageType: 'T',
      };
  }
  // TR_TOUR_ORD:7798–7950 uses the local tag/custom image before the linked design fallback.
  return [...(local ? [local] : []), ...(family === 'TOUR ORDER' && design ? [design] : [])];
}

/** Metadata alone does not decode the payload. Force a complete, bounded pixel read. */
export async function validateOrderImageBytes(
  bytes: Buffer,
  declaredMime: string,
): Promise<'image/jpeg' | 'image/png'> {
  if (!bytes.length || bytes.length > ENTITY_IMAGE_MAX_BYTES)
    throw new OrderImageError('invalid-image', 'Image is empty or exceeds the 4 MB limit.');
  let detected: ReturnType<typeof decodeEntityImage>;
  try {
    detected = decodeEntityImage({ data: bytes.toString('base64'), mimeType: declaredMime });
    await sharp(bytes, { failOn: 'warning', limitInputPixels: 25_000_000 }).raw().toBuffer();
  } catch {
    throw new OrderImageError(
      'invalid-image',
      'The saved image cannot be decoded as a complete JPEG or PNG.',
    );
  }
  return detected.mimeType as 'image/jpeg' | 'image/png';
}

async function readImageTx(
  tx: any,
  scope: OrderImageScope,
  key: ImageKey,
): Promise<ResolvedOrderImage> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES" FROM "ENTITY_IMAGE"
     WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "ENTITY_TYPE"=$4 AND "ENTITY_KEY"=$5 AND "INSTANCE"=$6`,
    scope.tenantId,
    scope.coCode,
    key.lcCode,
    key.entityType,
    key.entityKey,
    key.instance,
  );
  if (rows.length > 1)
    throw new OrderImageError('ambiguous-image', 'More than one image owns this saved identity.');
  if (rows.length) {
    const row = rows[0];
    if (
      !(row.IMAGE_BYTES instanceof Uint8Array) ||
      Number(row.IMAGE_SIZE) !== row.IMAGE_BYTES.length ||
      row.IMAGE_TYPE !== key.imageType
    )
      throw new OrderImageError('invalid-image', 'The saved image metadata and bytes disagree.');
    const bytes = Buffer.from(row.IMAGE_BYTES);
    const mimeType = await validateOrderImageBytes(bytes, str(row.MIME_TYPE));
    return { state: 'present', bytes, mimeType, source: key.entityType };
  }
  if (key.entityType === 'TAG') {
    const index: any[] = await tx.$queryRawUnsafe(
      `SELECT "IMAGE_TYPE" FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"=$4 AND "VCH_SRNO"=$5`,
      scope.tenantId,
      scope.coCode,
      key.lcCode,
      key.entityKey,
      key.instance,
    );
    if (index.length)
      throw new OrderImageError(
        'unavailable-image',
        'The saved tag image index exists, but its image bytes have not been transferred.',
      );
  }
  return { state: 'absent' };
}

/** Called inside the report's repeatable-read snapshot. Never reads branch-wide staging or remote URLs. */
export async function resolveOrderImageTx(
  tx: any,
  scope: OrderImageScope,
  family: OrderImageFamily,
  header: SavedRow,
  parent: SavedRow,
): Promise<ResolvedOrderImage> {
  for (const key of candidates(scope, family, header, parent)) {
    const image = await readImageTx(tx, scope, key);
    if (image.state === 'present') return image;
  }
  return { state: 'absent' };
}

async function tokenTx(
  tx: any,
  scope: OrderImageScope,
  family: OrderImageFamily,
  header: SavedRow,
  parent: SavedRow,
): Promise<string> {
  const parts: unknown[] = [
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    header.VCH_NO,
    parent.SR_NO,
    header.HD_VCH_NO,
    parent.HD_VCH_NO,
    parent.TAG_NO,
    parent.VCH_SRNO,
    parent.DESIGN_NO,
    parent.DESIGN_IMG_ID,
  ];
  for (const key of candidates(scope, family, header, parent)) {
    // Revision includes ordinary image editors and survives deletion. The raw fingerprint
    // additionally detects imported/corrupt bytes changed outside an application writer.
    const revisionKey = { ...scope, ...key };
    const stored: any[] = await tx.$queryRawUnsafe(
      `SELECT "IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES","ENTRY_TIME"::text FROM "ENTITY_IMAGE"
       WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "ENTITY_TYPE"=$4 AND "ENTITY_KEY"=$5 AND "INSTANCE"=$6`,
      scope.tenantId,
      scope.coCode,
      key.lcCode,
      key.entityType,
      key.entityKey,
      key.instance,
    );
    const fingerprint = stored.map((row) => ({
      ...row,
      IMAGE_BYTES:
        row.IMAGE_BYTES == null
          ? null
          : createHash('sha256').update(Buffer.from(row.IMAGE_BYTES)).digest('hex'),
    }));
    const tagIndex =
      key.entityType === 'TAG'
        ? await tx.$queryRawUnsafe(
            `SELECT "IMAGE_TYPE" FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"=$4 AND "VCH_SRNO"=$5 ORDER BY "IMAGE_TYPE"`,
            scope.tenantId,
            scope.coCode,
            key.lcCode,
            key.entityKey,
            key.instance,
          )
        : [];
    parts.push([key, await readImageRevisionTx(tx, revisionKey), fingerprint, tagIndex]);
  }
  return createHash('sha256').update(JSON.stringify(parts)).digest('hex');
}

async function savedParentTx(
  tx: any,
  scope: OrderImageScope,
  family: OrderImageFamily,
  vchNo: string,
  srNo: number,
  lock: boolean,
) {
  if (!vchNo.trim() || !Number.isSafeInteger(srNo) || srNo <= 0)
    badIdentity('Select a saved order and parent row.');
  await resolveBookPolicyTx(tx, scope, family, {
    requireExplicitMainBook: true,
    expectedTable: 'SL_ORD_DATA',
  });
  const where =
    'tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6';
  const args = [
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    formatVoucherNo(vchNo),
  ];
  const headers: any[] = await tx.$queryRawUnsafe(
    `SELECT * FROM "SL_ORD_DATA" WHERE ${where}${lock ? ' FOR UPDATE' : ''}`,
    ...args,
  );
  if (headers.length !== 1) badIdentity('The saved order was not found in the selected book.');
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT * FROM "SL_ORD_DETL" WHERE ${where} AND "SR_NO"=$7${lock ? ' FOR UPDATE' : ''}`,
    ...args,
    srNo,
  );
  if (rows.length !== 1) badIdentity('The saved order parent row was not found.');
  return { header: headers[0], parent: rows[0] };
}

export async function getOrderImage(
  prisma: any,
  scope: OrderImageScope,
  family: OrderImageFamily,
  vchNo: string,
  srNo: number,
) {
  return withTxBudget(prisma, scope.tenantId, SNAPSHOT_READ, async (tx: any) => {
    const { header, parent } = await savedParentTx(tx, scope, family, vchNo, srNo, false);
    const keys = candidates(scope, family, header, parent);
    const target = keys[0];
    let image: ResolvedOrderImage | { state: 'unavailable'; code: string; message: string } = {
      state: 'absent',
    };
    let targetHasImage = false;
    for (const [index, key] of keys.entries()) {
      try {
        image = await readImageTx(tx, scope, key);
        if (index === 0) targetHasImage = image.state === 'present';
      } catch (error) {
        // Repair is permitted under a valid saved identity. Reports still refuse these bytes.
        if (
          !(error instanceof OrderImageError) ||
          !['unavailable-image', 'invalid-image'].includes(error.code)
        )
          throw error;
        image = { state: 'unavailable', code: error.code, message: error.message };
        if (index === 0) targetHasImage = true;
      }
      if (image.state !== 'absent') break;
    }
    const editable = Boolean(target && target.entityType !== 'DESIGN');
    return {
      image,
      version: await tokenTx(tx, scope, family, header, parent),
      editable,
      targetHasImage,
      source: image.state === 'present' ? image.source : (target?.entityType ?? null),
      reason: editable
        ? null
        : target?.entityType === 'DESIGN'
          ? 'This order uses a shared Design Book image. Change that image in Design Book.'
          : 'Save a design number and a complete image identity before adding an image.',
    };
  });
}

/** Identity comes only from the locked, saved parent. Client keys and filenames are never accepted. */
export async function changeOrderImage(
  prisma: any,
  scope: OrderImageScope,
  family: OrderImageFamily,
  vchNo: string,
  srNo: number,
  input: { version: string; data?: string; mimeType?: string; user?: string; remove?: boolean },
) {
  let decoded: ReturnType<typeof decodeEntityImage> | null = null;
  if (!input.remove) {
    try {
      decoded = decodeEntityImage(input);
    } catch {
      throw new OrderImageError('invalid-image', 'Select a JPEG or PNG image up to 4 MB.');
    }
    await validateOrderImageBytes(decoded.bytes, decoded.mimeType);
  }
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const { header, parent } = await savedParentTx(tx, scope, family, vchNo, srNo, true);
    const keys = candidates(scope, family, header, parent);
    const key = keys[0];
    if (!key || key.entityType === 'DESIGN')
      badIdentity('Shared design images must be changed in Design Book.');
    // A photo can be shared by different saved parents or orders. Lock its actual key,
    // including an absent key, rather than relying on the selected parent row lock.
    for (const candidate of [...keys].sort((a, b) =>
      JSON.stringify(a).localeCompare(JSON.stringify(b)),
    ))
      await lockImageRevisionTx(tx, { ...scope, ...candidate });
    if (!input.version || input.version !== (await tokenTx(tx, scope, family, header, parent)))
      badIdentity(
        'The saved order image or its identity changed. Reload this row before changing its image.',
      );
    const args = [
      scope.tenantId,
      scope.coCode,
      key.lcCode,
      key.entityType,
      key.entityKey,
      key.instance,
    ];
    if (input.remove) {
      await tx.$executeRawUnsafe(
        `DELETE FROM "ENTITY_IMAGE" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "ENTITY_TYPE"=$4 AND "ENTITY_KEY"=$5 AND "INSTANCE"=$6`,
        ...args,
      );
    } else {
      await tx.$executeRawUnsafe(
        `INSERT INTO "ENTITY_IMAGE" (tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE","IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES","MAIN_USER")
        VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11)
        ON CONFLICT (tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE") DO UPDATE SET
        "IMAGE_TYPE"=EXCLUDED."IMAGE_TYPE","MIME_TYPE"=EXCLUDED."MIME_TYPE","IMAGE_SIZE"=EXCLUDED."IMAGE_SIZE","IMAGE_BYTES"=EXCLUDED."IMAGE_BYTES","MAIN_USER"=EXCLUDED."MAIN_USER","ENTRY_TIME"=now()`,
        ...args,
        key.imageType,
        decoded!.mimeType,
        decoded!.bytes.length,
        decoded!.bytes,
        str(input.user).slice(0, 64) || null,
      );
    }
    if (key.entityType === 'TAG') {
      const tagArgs = [scope.tenantId, scope.coCode, key.lcCode, key.entityKey, key.instance];
      if (input.remove)
        await tx.$executeRawUnsafe(
          `DELETE FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"=$4 AND "VCH_SRNO"=$5`,
          ...tagArgs,
        );
      else
        await tx.$executeRawUnsafe(
          `INSERT INTO "TAG_IMAGE_DATA" (tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","IMAGE_TYPE") VALUES ($1,$2,$3,$4,$5,'T')
        ON CONFLICT (tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO") DO UPDATE SET "IMAGE_TYPE"='T'`,
          ...tagArgs,
        );
    }
    await advanceImageRevisionTx(tx, { ...scope, ...key });
    return { saved: true };
  });
}
