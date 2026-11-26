import { withTxBudget, type Tx } from '../shared/txBudget.js';
import { dataTypesEnabled } from '../rbac/editionGate.js';
import { validateDataTypeAccess } from './dataTypePolicy.js';
import type { SessionClaims } from './jwt.js';

export async function dataTypeAccessTx(
  tx: Tx,
  tenantId: string,
  coCode: string,
  loginName: string,
) {
  const flags = await tx.$queryRawUnsafe<Array<{ enabled: boolean }>>(
    `SELECT enabled FROM "tenant_feature" WHERE tenant_id=$1 AND feature='dataTypes'`,
    tenantId,
  );
  const enabled = dataTypesEnabled({ features: { dataTypes: flags[0]?.enabled } });
  const users = await tx.$queryRawUnsafe<Array<{ allowed: string; defaultType: string }>>(
    `SELECT "DATA_TYPE_ALLOW" AS allowed,"DATA_TYPE_DEFAULT" AS "defaultType" FROM "LOGIN_MAST"
     WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LOGIN_NAME"=$3 AND "LOGIN_ACTIVE"='Y'`,
    tenantId,
    coCode,
    loginName,
  );
  if (users.length !== 1) throw Object.assign(new Error('session-invalid'), { statusCode: 401 });
  const access = validateDataTypeAccess(users[0]!.allowed, users[0]!.defaultType);
  return { ...access, enabled };
}
export async function sessionDataType(prisma: any, s: SessionClaims) {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx) => {
    const access = await dataTypeAccessTx(tx, s.tenantId, s.loginCoCode, s.sub);
    const rows = await tx.$queryRawUnsafe<Array<{ dataType: string }>>(
      `SELECT data_type AS "dataType" FROM "auth_session" WHERE tenant_id=$1 AND session_id=$2 AND context_epoch=$3::bigint`,
      s.tenantId,
      s.sid,
      s.contextEpoch,
    );
    const stored = rows[0]?.dataType;
    if (!stored || (access.enabled && !access.allowed.includes(stored)))
      throw Object.assign(new Error('session-invalid'), { statusCode: 401 });
    return {
      dataType: access.enabled ? stored : 'C',
      allowedDataTypes: access.allowed.split(''),
      features: { dataTypes: access.enabled },
    };
  });
}
export async function switchDataType(
  prisma: any,
  s: SessionClaims,
  type: string,
  sign: (claims: SessionClaims) => Promise<string>,
) {
  return withTxBudget(prisma, s.tenantId, 'voucher', async (tx) => {
    const access = await dataTypeAccessTx(tx, s.tenantId, s.loginCoCode, s.sub);
    if (!access.enabled) throw Object.assign(new Error('feature-unavailable'), { statusCode: 404 });
    if (!/^[ABC]$/.test(type) || !access.allowed.includes(type))
      throw Object.assign(new Error('data-type-not-allowed'), { statusCode: 403 });
    const rows = await tx.$queryRawUnsafe<Array<{ contextEpoch: string }>>(
      `UPDATE auth_session SET data_type=$1,context_epoch=context_epoch+1,
       last_context_selection_id=NULL,last_context_request_sha256=NULL,last_context_from_epoch=NULL
       WHERE tenant_id=$2 AND session_id=$3 AND context_epoch=$4::bigint
       AND revoked_at IS NULL AND expires_at>clock_timestamp() RETURNING context_epoch::text AS "contextEpoch"`,
      type,
      s.tenantId,
      s.sid,
      s.contextEpoch,
    );
    if (rows.length !== 1) throw Object.assign(new Error('context-stale'), { statusCode: 409 });
    await tx.$executeRawUnsafe(
      `INSERT INTO audit_log(tenant_id,login_name,co_code,action,path,status) VALUES ($1,$2,$3,'DATA_TYPE',$4,200)`,
      s.tenantId,
      s.sub,
      s.coCode,
      `/auth/data-type/${type}`,
    );
    const contextEpoch = rows[0]!.contextEpoch;
    const token = await sign({ ...s, dataType: type, contextEpoch });
    return { token, dataType: type, contextEpoch };
  });
}
