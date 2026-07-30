import { withTenant } from '@datacare/db';

/**
 * Entity images — the shared media surface behind the desktop's `BtnImgS` (select), `BtnImgC` (capture)
 * and `BtnImgD` (delete) controls.
 *
 * 24 desktop forms carry those buttons, and they do NOT all photograph a tag: `MS_ACCT` stores a party
 * photo, `MS_MEMB` a member photo, `MS_PRODUCT` scheme artwork, `MS_DESIGN_BOOK` a design. Identity is
 * therefore `(ENTITY_TYPE, ENTITY_KEY, INSTANCE)` rather than a tag number — keying everything on `TAG_NO`
 * would have been wrong for a third of the forms.
 *
 *   TAG    + tag number    + voucher serial   12 tag-image forms; also indexed in `TAG_IMAGE_DATA`
 *   AC     + account code  + 0                party / karigar photo (`MS_ACCT`, `TR_DHRN_ISU`)
 *   MEMB   + member code   + 0                membership photo (`MS_MEMB`)
 *   SCHM   + scheme code   + 0                scheme artwork (`MS_PRODUCT`)
 *   DESIGN + design number + 0                design book image (`MS_DESIGN_BOOK`)
 *
 * STORAGE
 * The desktop keeps bytes on a Windows file share and treats `TAG_IMAGE_DATA` as an index — that table has
 * no byte column. A multi-tenant server cannot depend on a shop's file share, and this codebase already
 * proves the alternative: the repair workflow stores bytes in a tenant-scoped `bytea` (`REP_IMAGE`). Only the
 * TAG entity is mirrored into `TAG_IMAGE_DATA`, whose primary key has no room for another entity kind.
 *
 * VALIDATION
 * The MIME type a client claims is never trusted: magic bytes decide, and a declaration that disagrees with
 * the content is refused, because the stored type is served back to browsers later.
 */

export class EntityImageError extends Error {
  constructor(m: string) {
    super(m);
    this.name = 'EntityImageError';
  }
}

/** Entity kinds, matching the desktop forms that own each image. */
export const ENTITY_TYPES = ['TAG', 'AC', 'MEMB', 'SCHM', 'DESIGN', 'ITEM'] as const;
export type EntityType = (typeof ENTITY_TYPES)[number];

/**
 * Image type codes are SINGLE CHARACTERS.
 *
 * `TAG_IMAGE_DATA.IMAGE_TYPE` is `varchar(1)` and the desktop's own DDL declares
 * `IMAGE_TYPE VARCHAR(1) DEFAULT 'T'` (`MS_UPDATE.cs:8995`); `'D'` is the design image
 * (`TR_APR_ISU.cs:7050` filters `IMAGE_TYPE = 'D'`). A descriptive name does not truncate — it fails the
 * insert.
 */
export const DEFAULT_IMAGE_TYPE = 'T';
export const DESIGN_IMAGE_TYPE = 'D';

/** 4 MB, matching the repair-image ceiling so both surfaces behave alike. */
export const ENTITY_IMAGE_MAX_BYTES = 4 * 1024 * 1024;

const ALLOWED: Array<{ mime: string; magic: number[] }> = [
  { mime: 'image/jpeg', magic: [0xff, 0xd8, 0xff] },
  { mime: 'image/png', magic: [0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a] },
];

export interface EntityImageKey {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  entityType: EntityType | string;
  /** Tag number, account code, member code, scheme code or design number. */
  entityKey: string;
  /** Voucher instance for a tag; 0 for master records. */
  instance?: number;
  imageType?: string;
}

export interface EntityImageRecord {
  entityType: string;
  entityKey: string;
  instance: number;
  imageType: string;
  mimeType: string;
  size: number;
  bytes: Buffer;
  entryTime: Date | null;
}

interface NormalKey {
  tenantId: string;
  coCode: string;
  lcCode: string;
  entityType: EntityType;
  entityKey: string;
  instance: number;
  imageType: string;
}

function normalise(key: EntityImageKey): NormalKey {
  const entityKey = String(key.entityKey ?? '').trim();
  if (!entityKey) throw new EntityImageError('image requires an entity key');
  if (!key.coCode) throw new EntityImageError('image requires a company');
  const type = String(key.entityType ?? 'TAG')
    .trim()
    .toUpperCase();
  if (!(ENTITY_TYPES as readonly string[]).includes(type)) {
    throw new EntityImageError(`unknown image entity type: ${type}`);
  }
  return {
    tenantId: key.tenantId,
    coCode: String(key.coCode),
    lcCode: String(key.lcCode ?? ''),
    entityType: type as EntityType,
    entityKey,
    instance: Number(key.instance ?? 0) || 0,
    // One character only: the desktop column is varchar(1).
    imageType: (
      String(key.imageType ?? DEFAULT_IMAGE_TYPE)
        .trim()
        .slice(0, 1) || DEFAULT_IMAGE_TYPE
    ).toUpperCase(),
  };
}

/** Decode a base64 upload and verify it is the image type it claims. Returns the DETECTED mime. */
export function decodeEntityImage(input: { data?: string; mimeType?: string }): {
  bytes: Buffer;
  mimeType: string;
} {
  const raw = String(input.data ?? '').trim();
  if (!raw) throw new EntityImageError('image requires data');
  const base64 = raw.startsWith('data:') ? (raw.split(',')[1] ?? '') : raw;
  if (!base64) throw new EntityImageError('image data is not valid base64');
  let bytes: Buffer;
  try {
    bytes = Buffer.from(base64, 'base64');
  } catch {
    throw new EntityImageError('image data is not valid base64');
  }
  if (!bytes.length) throw new EntityImageError('image is empty');
  if (bytes.length > ENTITY_IMAGE_MAX_BYTES) {
    throw new EntityImageError(`image exceeds ${ENTITY_IMAGE_MAX_BYTES} bytes`);
  }
  const detected = ALLOWED.find((c) => c.magic.every((byte, i) => bytes[i] === byte));
  if (!detected) throw new EntityImageError('image must be a JPEG or PNG');
  const claimed = String(input.mimeType ?? '')
    .trim()
    .toLowerCase();
  if (claimed && claimed !== detected.mime) {
    throw new EntityImageError(`image content is ${detected.mime} but was declared ${claimed}`);
  }
  return { bytes, mimeType: detected.mime };
}

/** Store or replace an entity's image. TAG entities also keep the desktop `TAG_IMAGE_DATA` index in step. */
export async function saveEntityImage(
  prisma: any,
  key: EntityImageKey,
  input: { data?: string; mimeType?: string; user?: string },
): Promise<{ saved: true; size: number; mimeType: string }> {
  const k = normalise(key);
  const { bytes, mimeType } = decodeEntityImage(input);
  await withTenant(prisma, k.tenantId, async (tx: any) => {
    await tx.$executeRawUnsafe(
      `INSERT INTO "ENTITY_IMAGE"(tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE",
         "IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES","MAIN_USER")
       VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11)
       ON CONFLICT (tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE")
       DO UPDATE SET "IMAGE_TYPE"=EXCLUDED."IMAGE_TYPE","MIME_TYPE"=EXCLUDED."MIME_TYPE",
                     "IMAGE_SIZE"=EXCLUDED."IMAGE_SIZE","IMAGE_BYTES"=EXCLUDED."IMAGE_BYTES",
                     "MAIN_USER"=EXCLUDED."MAIN_USER","ENTRY_TIME"=now()`,
      k.tenantId,
      k.coCode,
      k.lcCode,
      k.entityType,
      k.entityKey,
      k.instance,
      k.imageType,
      mimeType,
      bytes.length,
      bytes,
      (input.user ?? '').slice(0, 64) || null,
    );
    if (k.entityType === 'TAG') {
      // The desktop's tag index, so a desktop-shaped read still finds the image.
      await tx.$executeRawUnsafe(
        `INSERT INTO "TAG_IMAGE_DATA"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","IMAGE_TYPE")
         VALUES ($1,$2,$3,$4,$5,$6)
         ON CONFLICT (tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO")
         DO UPDATE SET "IMAGE_TYPE"=EXCLUDED."IMAGE_TYPE"`,
        k.tenantId,
        k.coCode,
        k.lcCode,
        k.entityKey,
        k.instance,
        k.imageType,
      );
    }
  });
  return { saved: true, size: bytes.length, mimeType };
}

export async function getEntityImage(
  prisma: any,
  key: EntityImageKey,
): Promise<EntityImageRecord | null> {
  const k = normalise(key);
  return withTenant(prisma, k.tenantId, async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "ENTITY_TYPE","ENTITY_KEY","INSTANCE","IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES",
              "ENTRY_TIME"
         FROM "ENTITY_IMAGE"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "ENTITY_TYPE"=$4
          AND "ENTITY_KEY"=$5 AND "INSTANCE"=$6 LIMIT 1`,
      k.tenantId,
      k.coCode,
      k.lcCode,
      k.entityType,
      k.entityKey,
      k.instance,
    );
    const r = rows[0];
    if (!r) return null;
    return {
      entityType: String(r.ENTITY_TYPE),
      entityKey: String(r.ENTITY_KEY),
      instance: Number(r.INSTANCE ?? 0),
      imageType: String(r.IMAGE_TYPE ?? DEFAULT_IMAGE_TYPE),
      mimeType: String(r.MIME_TYPE ?? 'image/jpeg'),
      size: Number(r.IMAGE_SIZE ?? 0),
      bytes: Buffer.isBuffer(r.IMAGE_BYTES) ? r.IMAGE_BYTES : Buffer.from(r.IMAGE_BYTES ?? []),
      entryTime: r.ENTRY_TIME ? new Date(r.ENTRY_TIME) : null,
    };
  });
}

export async function deleteEntityImage(
  prisma: any,
  key: EntityImageKey,
): Promise<{ deleted: boolean }> {
  const k = normalise(key);
  return withTenant(prisma, k.tenantId, async (tx: any) => {
    const n: number = await tx.$executeRawUnsafe(
      `DELETE FROM "ENTITY_IMAGE"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "ENTITY_TYPE"=$4
          AND "ENTITY_KEY"=$5 AND "INSTANCE"=$6`,
      k.tenantId,
      k.coCode,
      k.lcCode,
      k.entityType,
      k.entityKey,
      k.instance,
    );
    if (k.entityType === 'TAG') {
      await tx.$executeRawUnsafe(
        `DELETE FROM "TAG_IMAGE_DATA"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"=$4 AND "VCH_SRNO"=$5`,
        k.tenantId,
        k.coCode,
        k.lcCode,
        k.entityKey,
        k.instance,
      );
    }
    return { deleted: n > 0 };
  });
}

/** Which entities have an image — used to show a thumbnail indicator in a grid or list. */
export async function listEntityImageKeys(
  prisma: any,
  scope: { tenantId: string; coCode: string; lcCode?: string; entityType?: string },
  entityKeys?: readonly string[],
): Promise<{ entityType: string; entityKey: string; instance: number; size: number }[]> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const params: unknown[] = [scope.tenantId, scope.coCode];
    let filter = '';
    if (scope.lcCode != null) {
      params.push(String(scope.lcCode));
      filter += ` AND "LC_CODE"=$${params.length}`;
    }
    if (scope.entityType) {
      params.push(String(scope.entityType).toUpperCase());
      filter += ` AND "ENTITY_TYPE"=$${params.length}`;
    }
    if (entityKeys && entityKeys.length) {
      params.push(entityKeys.map(String));
      filter += ` AND "ENTITY_KEY" = ANY($${params.length}::text[])`;
    }
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "ENTITY_TYPE","ENTITY_KEY","INSTANCE","IMAGE_SIZE" FROM "ENTITY_IMAGE"
        WHERE tenant_id=$1 AND "CO_CODE"=$2${filter} ORDER BY "ENTITY_TYPE","ENTITY_KEY","INSTANCE"`,
      ...params,
    );
    return rows.map((r) => ({
      entityType: String(r.ENTITY_TYPE),
      entityKey: String(r.ENTITY_KEY),
      instance: Number(r.INSTANCE ?? 0),
      size: Number(r.IMAGE_SIZE ?? 0),
    }));
  });
}
