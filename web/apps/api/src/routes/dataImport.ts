import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import {
  DataImportError,
  applyLiteImport,
  previewLiteImport,
  type DataImportScope,
} from '../modules/utilities/dataImport.js';
import { MAX_SOURCE_BYTES } from '../modules/utilities/dataImportSource.js';

interface DataImportRouteDeps {
  prisma: any;
  auth: { preHandler: unknown };
  guard: (req: FastifyRequest, reply: FastifyReply, action: 'view' | 'create') => boolean;
  sess: (req: FastifyRequest) => any;
}

/** The base64 of the largest accepted file, plus room for the JSON around it. */
const BODY_LIMIT = Math.ceil((MAX_SOURCE_BYTES * 4) / 3) + 64 * 1024;

/**
 * Other → Data Import (desktop UT_IMPORT, Lite Soft). The menu caption "Data Import" (MDI_FORM.cs:8606-8615) is the
 * only right the desktop checks: AllBtn opens the form on FRM_VIEW (MDI_FORM.cs:7034-7046, "You Have No Rights.....")
 * and BtnLite_Click checks nothing more (UT_IMPORT.cs:8413-8445). Preview is a read; Import is a create (G225).
 *
 *   POST /utilities/data-import/lite/preview  {fileName, data: base64}               rows per step, errors, refusal
 *   POST /utilities/data-import/lite/apply    {fileName, data: base64, previewHash}  the five steps in one transaction
 */
export function registerDataImportRoutes(app: FastifyInstance, deps: DataImportRouteDeps): void {
  const { prisma, auth, guard, sess } = deps;
  const scopeOf = (req: FastifyRequest): DataImportScope => {
    const s = sess(req);
    return {
      tenantId: s.tenantId,
      coCode: s.coCode,
      lcCode: s.lcCode,
      coYear: s.coYear,
      user: String(s.sub ?? ''),
    };
  };
  const fileOf = (req: FastifyRequest): { name: string; bytes: Uint8Array } | null => {
    const b = (req.body ?? {}) as Record<string, unknown>;
    if (typeof b.data !== 'string' || !/^[A-Za-z0-9+/=\s]*$/.test(b.data)) return null;
    return { name: String(b.fileName ?? '').slice(0, 255), bytes: Buffer.from(b.data, 'base64') };
  };
  const answer = async (reply: FastifyReply, fn: () => Promise<unknown>) => {
    try {
      return reply.code(200).send(await fn());
    } catch (error) {
      if (error instanceof DataImportError) {
        const status = error.code === 'has-data' || error.code === 'stale-preview' ? 409 : 400;
        return reply.code(status).send({
          error: `data-import-${error.code}`,
          message: error.message,
          ...(error.detail && typeof error.detail === 'object' ? error.detail : {}),
        });
      }
      // A failed write rolled the whole import back; answer it as the other writers do (dataRepair.ts apply).
      const text = String((error as any)?.message ?? '');
      if (
        (error as any)?.code === 'P2010' ||
        /Raw query failed|violates|not-null|duplicate key/i.test(text)
      ) {
        const detail = text.match(/Message: `([^`]+)`/)?.[1] ?? text;
        return reply.code(400).send({
          error: 'data-import-failed',
          message: `The import failed and nothing was imported: ${detail.replace(/^ERROR:\s*/, '').slice(0, 200)}`,
        });
      }
      throw error;
    }
  };
  const badFile = (reply: FastifyReply) =>
    reply
      .code(400)
      .send({ error: 'data-import-file', message: 'Choose the old software .mdb file.' });

  app.post(
    '/utilities/data-import/lite/preview',
    { ...(auth as any), bodyLimit: BODY_LIMIT },
    async (req, reply) => {
      if (!guard(req, reply, 'view')) return;
      const file = fileOf(req);
      if (!file) return badFile(reply);
      return answer(reply, () => previewLiteImport(prisma, scopeOf(req), file));
    },
  );

  app.post(
    '/utilities/data-import/lite/apply',
    { ...(auth as any), bodyLimit: BODY_LIMIT },
    async (req, reply) => {
      if (!guard(req, reply, 'create')) return;
      const file = fileOf(req);
      if (!file) return badFile(reply);
      const previewHash = String(((req.body ?? {}) as Record<string, unknown>).previewHash ?? '');
      return answer(reply, () => applyLiteImport(prisma, scopeOf(req), file, previewHash));
    },
  );
}
