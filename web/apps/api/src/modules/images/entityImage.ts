import { withTenant } from '@datacare/db';
import {
  lockImageRevisionTx,
  readImageRevisionTx,
  advanceImageRevisionTx,
} from './imageRevision.js';
import {
  compareImageVersion,
  imageStateVersion,
  imagePreview,
  validateImagePixels,
} from './imageState.js';

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
 *   DESIGN + saved DESIGN_IMG_ID + 0                design book image (`MS_DESIGN_BOOK`)
 *
 * STORAGE
 * The desktop keeps local image files and can also store MOB_IMAGE base64 in its separate image database.
 * The web's TAG_IMAGE_DATA model currently imports index fields only. A multi-tenant server cannot depend on a shop's file share, and this codebase already
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
  /** Design Book routes accept only the saved desktop DESIGN_IMG_ID in the active company. */
  requireDesignParent?: boolean;
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

async function designParentExists(tx: any, k: NormalKey, required?: boolean): Promise<boolean> {
  if (!required) return true;
  if (k.entityType !== 'DESIGN' || k.lcCode !== '' || k.instance !== 0 || k.imageType !== 'D') {
    throw new EntityImageError('invalid Design Book image identity');
  }
  // Keep the selected parent alive until this image transaction completes. Images are company-wide,
  // like DESIGN_DETL, and use the saved desktop key, never a caller-supplied bare design number.
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "DESIGN_IMG_ID" FROM "DESIGN_DETL"
     WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "DESIGN_IMG_ID"=$3 FOR KEY SHARE`,
    k.tenantId,
    k.coCode,
    k.entityKey,
  );
  return rows.length > 0;
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
  const instance = Number(key.instance ?? 0);
  if (!Number.isFinite(instance) || instance < 0)
    throw new EntityImageError('image instance must be a finite non-negative number');
  return {
    tenantId: key.tenantId,
    coCode: String(key.coCode),
    lcCode: String(key.lcCode ?? ''),
    entityType: type as EntityType,
    entityKey,
    instance,
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

async function entityImageSnapshotTx(tx: any, k: NormalKey, requireParent?: boolean) {
  let parents: unknown[] = [];
  if (requireParent) {
    if (!(await designParentExists(tx, k, true)))
      throw new EntityImageError('save the design in this company before editing its image');
    parents = await tx.$queryRawUnsafe(
      `SELECT "BOOK_NAME","PR_CODE","SR_NO"::text,"OLD_SRNO"::text,xmin::text AS "generation",ctid::text AS "tuple"
       FROM "DESIGN_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "DESIGN_IMG_ID"=$3
       ORDER BY "BOOK_NAME","PR_CODE","SR_NO"`,
      k.tenantId,
      k.coCode,
      k.entityKey,
    );
  }
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES","MAIN_USER","ENTRY_TIME"::text AS "entryTime"
     FROM "ENTITY_IMAGE" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "ENTITY_TYPE"=$4 AND "ENTITY_KEY"=$5 AND "INSTANCE"=$6`,
    k.tenantId,
    k.coCode,
    k.lcCode,
    k.entityType,
    k.entityKey,
    k.instance,
  );
  const index: any[] =
    k.entityType === 'TAG'
      ? await tx.$queryRawUnsafe(
          `SELECT "IMAGE_TYPE" FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"=$4 AND "VCH_SRNO"=$5`,
          k.tenantId,
          k.coCode,
          k.lcCode,
          k.entityKey,
          k.instance,
        )
      : [];
  const revision = await readImageRevisionTx(tx, k);
  const version = imageStateVersion([
    [k.tenantId, k.coCode, k.lcCode, k.entityType, k.entityKey, k.instance],
    revision,
    parents,
    rows.map(({ IMAGE_BYTES, ...r }) => ({
      ...r,
      data: Buffer.from(IMAGE_BYTES ?? []).toString('base64'),
    })),
    index,
  ]);
  return { version, rows, index };
}

/** A single snapshot includes absent/unavailable bytes and a version suitable for explicit replacement. */
export async function getEntityImageState(prisma: any, key: EntityImageKey) {
  const k = normalise(key);
  return withTenant(
    prisma,
    k.tenantId,
    async (tx: any) => {
      const snapshot = await entityImageSnapshotTx(tx, k, key.requireDesignParent);
      const row = snapshot.rows[0];
      return {
        version: snapshot.version,
        image: await imagePreview(
          row
            ? {
                bytes: Buffer.from(row.IMAGE_BYTES ?? []),
                mimeType: String(row.MIME_TYPE ?? ''),
                size: Number(row.IMAGE_SIZE),
                validType: snapshot.rows.length === 1 && row.IMAGE_TYPE === k.imageType,
              }
            : null,
          snapshot.index.length > 0,
        ),
      };
    },
    { isolationLevel: 'RepeatableRead' },
  );
}

/** Store or replace an entity's image. TAG entities also keep the desktop `TAG_IMAGE_DATA` index in step. */
export async function saveEntityImage(
  prisma: any,
  key: EntityImageKey,
  input: { data?: string; mimeType?: string; user?: string; version?: string },
): Promise<{ saved: true; size: number; mimeType: string }> {
  const k = normalise(key);
  const { bytes, mimeType } = decodeEntityImage(input);
  if (input.version !== undefined) await validateImagePixels(bytes, mimeType);
  await withTenant(prisma, k.tenantId, async (tx: any) => {
    if (!(await designParentExists(tx, k, key.requireDesignParent))) {
      throw new EntityImageError('save the design in this company before uploading its image');
    }
    await lockImageRevisionTx(tx, k);
    if (input.version !== undefined)
      compareImageVersion(
        input.version,
        (await entityImageSnapshotTx(tx, k, key.requireDesignParent)).version,
      );
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
    await advanceImageRevisionTx(tx, k);
  });
  return { saved: true, size: bytes.length, mimeType };
}

export async function getEntityImage(
  prisma: any,
  key: EntityImageKey,
): Promise<EntityImageRecord | null> {
  const k = normalise(key);
  return withTenant(prisma, k.tenantId, async (tx: any) => {
    if (!(await designParentExists(tx, k, key.requireDesignParent))) return null;
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
  version?: string,
): Promise<{ deleted: boolean }> {
  const k = normalise(key);
  return withTenant(prisma, k.tenantId, async (tx: any) => {
    if (!(await designParentExists(tx, k, key.requireDesignParent))) {
      if (version !== undefined)
        throw new EntityImageError('save the design in this company before editing its image');
      return { deleted: false };
    }
    await lockImageRevisionTx(tx, k);
    if (version !== undefined)
      compareImageVersion(
        version,
        (await entityImageSnapshotTx(tx, k, key.requireDesignParent)).version,
      );
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
    await advanceImageRevisionTx(tx, k);
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
