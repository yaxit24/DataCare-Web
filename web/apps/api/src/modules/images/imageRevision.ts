/** Web concurrency metadata; a revision survives removal of the image bytes. */
export interface ImageRevisionKey {
  tenantId: string;
  coCode: string;
  lcCode: string;
  entityType: string;
  entityKey: string;
  instance: number;
}
const args = (key: ImageRevisionKey) => [
  key.tenantId,
  key.coCode,
  key.lcCode,
  key.entityType,
  key.entityKey,
  key.instance,
];
const where =
  'tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "ENTITY_TYPE"=$4 AND "ENTITY_KEY"=$5 AND "INSTANCE"=$6';

/** All application image writers lock this identity before changing bytes or the tag index. */
export async function lockImageRevisionTx(tx: any, key: ImageRevisionKey): Promise<void> {
  await tx.$executeRawUnsafe(
    `INSERT INTO "ENTITY_IMAGE_REVISION" (tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE")
     VALUES ($1,$2,$3,$4,$5,$6) ON CONFLICT DO NOTHING`,
    ...args(key),
  );
  await tx.$queryRawUnsafe(
    `SELECT "REVISION" FROM "ENTITY_IMAGE_REVISION" WHERE ${where} FOR UPDATE`,
    ...args(key),
  );
}

export async function readImageRevisionTx(tx: any, key: ImageRevisionKey): Promise<string> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "REVISION"::text AS "revision" FROM "ENTITY_IMAGE_REVISION" WHERE ${where}`,
    ...args(key),
  );
  return rows[0]?.revision ?? '0';
}

/** Requires lockImageRevisionTx earlier in this transaction. Rollback also rolls this back. */
export async function advanceImageRevisionTx(tx: any, key: ImageRevisionKey): Promise<void> {
  const changed = await tx.$executeRawUnsafe(
    `UPDATE "ENTITY_IMAGE_REVISION" SET "REVISION"="REVISION"+1 WHERE ${where}`,
    ...args(key),
  );
  if (changed !== 1) throw new Error('Image revision identity was not locked.');
}
