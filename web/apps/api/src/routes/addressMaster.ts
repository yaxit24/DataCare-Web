import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import {
  AddressVersionConflictError,
  ADDRESS_FIELDS,
  addressCombos,
  addressNameMatches,
  addressPrintRows,
  addressWithMobile,
  deleteAddress,
  getAddress,
  listAddresses,
  nextAddressCode,
  saveAddress,
} from '../modules/masters/addressMaster.js';

/** The rights row of the screen and its routes (routePolicy 'Masters/Addresses', desktop SUB_MENU 'Address'). */
const FORM = 'Masters/Addresses';

/**
 * Address master (MS_ADD_MAST). A new address needs only the view right and an opened one the edit right, as
 * BtnSave_Click checks FRM_EDIT only in edit mode (MS_ADD_MAST.cs:4431-4435), so the screen posts a new address and puts
 * an opened one. The list returns the user's rights (MS_ADD_MAST_Load :3119-3135), the combos and the next code.
 */
export function registerAddressMasterRoutes(
  app: FastifyInstance,
  h: Pick<CrmRouteHelpers, 'prisma' | 'auth' | 'scopeOf' | 'run' | 'body' | 'mainUserOf'> & {
    guard: (
      req: FastifyRequest,
      reply: FastifyReply,
      action: 'view' | 'create' | 'update' | 'delete' | 'print',
    ) => boolean;
  },
  capabilities: (
    req: FastifyRequest,
    form: string,
  ) => Promise<{ canUpdate: boolean; canDelete: boolean; canPrint: boolean }>,
): void {
  const { prisma, auth, guard, scopeOf, run, body, mainUserOf } = h;
  const scope = (req: FastifyRequest) => {
    const s = scopeOf(req) as any;
    return { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode, coYear: s.coYear };
  };
  const codeOf = (req: FastifyRequest) => String((req.params as any).code ?? '');
  const write = async (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => {
    try {
      return await run(reply, okCode, fn);
    } catch (e) {
      if (e instanceof AddressVersionConflictError)
        return reply.code(409).send({ error: e.code, message: e.message });
      throw e;
    }
  };

  app.get('/masters/address-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({
      ...(await listAddresses(prisma, scope(req))),
      combos: await addressCombos(prisma, scope(req)),
      nextCode: await nextAddressCode(prisma, scope(req)),
      rights: await capabilities(req, FORM),
    }));
  });
  app.get('/masters/address-master/print', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    return run(reply, 200, async () => ({ rows: await addressPrintRows(prisma, scope(req)) }));
  });
  app.get('/masters/address-master/names', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = String((req.query as any)?.q ?? '');
    return run(reply, 200, () => addressNameMatches(prisma, scope(req), q));
  });
  app.get('/masters/address-master/mobile', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const no = String((req.query as any)?.no ?? '');
    return run(reply, 200, async () => ({
      taken: await addressWithMobile(prisma, scope(req), no),
    }));
  });
  app.get('/masters/address-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const address = await getAddress(prisma, scope(req), codeOf(req));
    if (!address)
      return reply
        .code(404)
        .send({ error: 'address-not-found', message: 'address code not found' });
    return reply.code(200).send(address);
  });
  const save = (req: FastifyRequest, entryMode: 'A' | 'E', code: string) => {
    const b = body(req);
    const values: Record<string, string> = {};
    for (const [key] of ADDRESS_FIELDS) values[key] = b[key];
    return saveAddress(prisma, {
      scope: scope(req),
      user: mainUserOf(req),
      entryMode,
      code,
      values: {
        ...values,
        birthDate: b.birthDate,
        anniversary: b.anniversary,
        lBirthDate: b.lBirthDate,
      },
      expectedVersion: b.expectedVersion,
    });
  };
  app.post('/masters/address-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return write(reply, 201, () => save(req, 'A', String(body(req).code ?? '')));
  });
  app.put('/masters/address-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return write(reply, 200, () => save(req, 'E', codeOf(req)));
  });
  app.delete('/masters/address-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return write(reply, 200, () =>
      deleteAddress(prisma, scope(req), codeOf(req), (req.query as any)?.expectedVersion),
    );
  });
}
