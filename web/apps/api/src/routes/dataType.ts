import type { FastifyInstance, FastifyRequest, FastifyReply } from 'fastify';
import type { SessionClaims } from '../modules/auth/jwt.js';
import { switchDataType } from '../modules/auth/dataTypeAccess.js';
export function registerDataTypeRoute(
  app: FastifyInstance,
  deps: {
    prisma: any;
    requireAuth: (req: FastifyRequest, reply: FastifyReply) => Promise<void>;
    session: (req: FastifyRequest) => SessionClaims;
    sign: (s: SessionClaims) => Promise<string>;
    cookie: any;
  },
) {
  app.post(
    '/auth/data-type',
    {
      preHandler: deps.requireAuth,
      schema: {
        body: {
          type: 'object',
          required: ['type'],
          additionalProperties: false,
          properties: { type: { type: 'string', enum: ['A', 'B', 'C'] } },
        },
      },
    },
    async (req, reply) => {
      try {
        const result = await switchDataType(
          deps.prisma,
          deps.session(req),
          (req.body as { type: string }).type,
          deps.sign,
        );
        reply.header('Cache-Control', 'no-store').setCookie('access', result.token, deps.cookie);
        return { dataType: result.dataType, contextEpoch: result.contextEpoch };
      } catch (error) {
        const e = error as Error & { statusCode?: number };
        if (e.statusCode) return reply.code(e.statusCode).send({ error: e.message });
        throw error;
      }
    },
  );
}
