import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import {
  PARTY_DATES,
  PARTY_FIELDS,
  PARTY_FLAGS,
  PARTY_NUMBERS,
  PartyVersionConflictError,
  deleteParty,
  deletePartyPhoto,
  getParty,
  getPartyPhoto,
  listParties,
  partyAccount,
  partyCombos,
  partyCopySource,
  partyGstState,
  partyHelp,
  partyPrintRows,
  partyTaken,
  saveParty,
  setPartyPhoto,
  type PartyHelp,
  type PartyValues,
} from '../modules/masters/partyMaster.js';

/** The rights row of the screen and its routes (routePolicy 'Masters/Party (rich)', desktop SUB_MENU 'Party'). */
const FORM = 'Masters/Party (rich)';
const HELPS: readonly PartyHelp[] = [
  'names',
  'f1',
  'groups',
  'short',
  'main',
  'address',
  'member',
  'account',
];

/**
 * Party master (MS_ACCT). A new party needs only the view right and an opened one the edit right, as BtnSave_Click
 * checks UserEdit only in edit mode (MS_ACCT.cs:7652-7656), so the screen posts a new party and puts an opened one. The
 * list returns the user's rights (MS_ACCT_Load reads USER_SET SUB_MENU 'Party'), the combos and the next code.
 */
export function registerPartyMasterRoutes(
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
  const query = (req: FastifyRequest, key: string) => String((req.query as any)?.[key] ?? '');
  /** MCo_UserType 'A': the administrator sees the short names in the F1 help and may open the short-name help. */
  const admin = (req: FastifyRequest) => Boolean((req as any).principal?.isAdmin);
  const write = async (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => {
    try {
      return await run(reply, okCode, fn);
    } catch (e) {
      if (e instanceof PartyVersionConflictError)
        return reply.code(409).send({ error: e.code, message: e.message });
      throw e;
    }
  };

  app.get('/masters/party-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({
      ...(await listParties(prisma, scope(req))),
      combos: await partyCombos(prisma, scope(req)),
      rights: await capabilities(req, FORM),
      admin: admin(req),
    }));
  });
  app.get('/masters/party-master/print', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    return run(reply, 200, async () => ({ rows: await partyPrintRows(prisma, scope(req)) }));
  });
  app.get('/masters/party-master/help/:kind', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const kind = String((req.params as any).kind ?? '') as PartyHelp;
    if (!HELPS.includes(kind))
      return reply.code(400).send({ error: 'invalid-data', message: `unknown help ${kind}` });
    if (kind === 'short' && !admin(req))
      return reply.code(403).send({ error: 'forbidden', action: 'view' });
    return run(reply, 200, async () => ({
      rows: await partyHelp(prisma, scope(req), kind, admin(req)),
    }));
  });
  app.get('/masters/party-master/copy/:kind', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const kind = String((req.params as any).kind ?? '');
    if (kind !== 'address' && kind !== 'member' && kind !== 'account')
      return reply.code(400).send({ error: 'invalid-data', message: `unknown source ${kind}` });
    return run(reply, 200, async () => ({
      values: await partyCopySource(
        prisma,
        scope(req),
        kind,
        query(req, 'code'),
        query(req, 'scheme'),
      ),
    }));
  });
  app.get('/masters/party-master/taken/:kind', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const kind = String((req.params as any).kind ?? '');
    if (kind !== 'mobile' && kind !== 'mobile2' && kind !== 'short')
      return reply.code(400).send({ error: 'invalid-data', message: `unknown check ${kind}` });
    return run(reply, 200, async () => ({
      taken: await partyTaken(prisma, scope(req), kind, query(req, 'value'), query(req, 'code')),
    }));
  });
  app.get('/masters/party-master/gst-state', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => partyGstState(prisma, scope(req), query(req, 'gst')));
  });
  app.get('/masters/party-master/account', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({
      account: await partyAccount(prisma, scope(req), query(req, 'code')),
    }));
  });
  app.get('/masters/party-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const party = await getParty(prisma, scope(req), codeOf(req));
    if (!party)
      return reply.code(404).send({ error: 'party-not-found', message: 'account code not found' });
    return reply.code(200).send(party);
  });
  app.get('/masters/party-master/:code/photo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getPartyPhoto(prisma, scope(req), codeOf(req)));
  });
  app.post('/masters/party-master/:code/photo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 200, () =>
      setPartyPhoto(prisma, scope(req), codeOf(req), String(body(req).dataUrl ?? '')),
    );
  });
  app.post('/masters/party-master/:code/photo/delete', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 200, () => deletePartyPhoto(prisma, scope(req), codeOf(req)));
  });
  const save = (req: FastifyRequest, entryMode: 'A' | 'E', code: string) => {
    const b = body(req);
    const values: Record<string, unknown> = {};
    for (const [key] of PARTY_FIELDS) values[key] = b[key];
    for (const [key] of PARTY_NUMBERS) values[key] = b[key];
    for (const [key] of PARTY_FLAGS) values[key] = b[key] === true || b[key] === 'Y';
    for (const [key] of PARTY_DATES) values[key] = b[key];
    values.acType = b.acType;
    values.gstType = b.gstType;
    return saveParty(prisma, {
      scope: scope(req),
      user: mainUserOf(req),
      entryMode,
      code,
      unlocked: b.unlocked === true,
      values: values as PartyValues,
      opening: b.opening,
      expectedVersion: b.expectedVersion,
    });
  };
  app.post('/masters/party-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return write(reply, 201, () => save(req, 'A', String(body(req).code ?? '')));
  });
  app.put('/masters/party-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return write(reply, 200, () => save(req, 'E', codeOf(req)));
  });
  app.delete('/masters/party-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const q = req.query as any;
    return write(reply, 200, () =>
      deleteParty(prisma, scope(req), codeOf(req), {
        expectedVersion: q?.expectedVersion,
        unlocked: q?.unlocked === 'Y',
        dryRun: q?.dryRun === 'Y',
      }),
    );
  });
}
