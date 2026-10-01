import { LastDayLockConfigurationError } from './modules/shared/lastDayLock.js';
import { loginSessionContext } from './modules/auth/sessionContextLogin.js';
import {
  refreshSessionContext,
  type RefreshContextDependencies,
} from './modules/auth/sessionContextRefresh.js';
import {
  selectSessionContext,
  ContextSelectionError,
} from './modules/auth/sessionContextSelection.js';
import { validateAccessSessionContext } from './modules/auth/sessionContextAccess.js';
import type { UnknownSessionLedgerContext } from './modules/auth/sessionContextValue.js';
import Fastify, { type FastifyInstance, type FastifyReply, type FastifyRequest } from 'fastify';
import cookie from '@fastify/cookie';
import rateLimit from '@fastify/rate-limit';
import { withTenant } from '@datacare/db';
import type { UserRights } from '@datacare/types';
import { AuthError } from './modules/auth/auth.service.js';
import {
  issueAccess,
  issueRefresh,
  verifyAccessToken,
  verifyRefreshToken,
  type SessionClaims,
} from './modules/auth/jwt.js';
import { revokeSession, SessionRejectedError } from './modules/auth/session.js';
import { changeOwnPassword, PasswordChangeError } from './modules/auth/passwordAccount.js';
import { PasswordPolicyError } from './modules/auth/password.js';
import {
  enforceRequestScope,
  listScopeBooks,
  listScopeCompanies,
  listScopeLocations,
  listScopeYears,
  ScopeError,
  type BusinessScope,
} from './modules/auth/businessScope.js';
import { resolveAllowedForms } from './modules/rbac/formRights.js';
import {
  authorizeForm,
  FormForbiddenError,
  loadPrincipal,
  PrincipalUnavailableError,
  type Principal,
} from './modules/rbac/authorization.js';
import {
  isRouteAuthorizedMarker,
  MASTER_FORM_BY_NAME,
  resolvePolicyForm,
  routePolicyFor,
  type RoutePolicy,
} from './modules/rbac/routePolicy.js';
import { MASTERS } from './modules/masters/configs.js';
import { GENERATED_FORM_FIELDS } from './modules/masters/generated-formfields.js';
import { ColumnSettingsError, listColumnSettings } from './modules/masters/columnSettings.js';
import { resolveFormFields, withGroups } from './modules/masters/master.service.js';
import {
  createMaster,
  updateMaster,
  deleteMaster,
  listMaster,
  importMaster,
  ValidationError,
  DuplicateKeyError,
  ReferencedError,
  DataError,
  NotFoundError,
  type MasterScope,
} from './modules/masters/master.service.js';
import { registerTxnRoutes } from './routes/txn.js';
import { logAudit, listAudit } from './modules/ops/audit.js';
import { backupCompany, recordCompanyBackup } from './modules/ops/backup.js';
import { healthPayload, readiness, type PdfRendererProbe } from './modules/ops/health.js';
import { correlationId, requestCompletedFields } from './modules/ops/requestContext.js';
import { collectDatabaseMetrics, MetricsRegistry, type RouteClass } from './modules/ops/metrics.js';
import { isTransactionTimeout } from './modules/shared/txBudget.js';
import { operationalInvariants } from './modules/ops/invariants.js';
import {
  REPORT_FILTER_BINDINGS,
  REPORT_FILTER_KEYS,
  supportedFilters,
} from './modules/reports/reportFilters.js';
import { reportFormForSlug } from './modules/reports/reportAuthorization.js';

export interface BuildOpts {
  prisma: any;
  secret: string;
  logger?: boolean;
  secureCookies?: boolean;
  rendererProbe?: PdfRendererProbe;
  /** Tenant bound to this deployment when no trusted gateway selects one. */
  defaultTenantId?: string;
  /** Enable only when x-tenant-id is supplied by a trusted gateway (enabled by default in tests). */
  allowTenantHeader?: boolean;
}

interface Session extends SessionClaims {
  rights: UserRights;
  principal: Principal;
  ledgerContext: UnknownSessionLedgerContext;
}

interface RequestState extends FastifyRequest {
  session?: Session;
  principal?: Principal;
  businessScope?: BusinessScope;
  routeAuthorized?: boolean;
  requestStartedAt?: bigint;
}

const ACCESS_COOKIE_SECONDS = 15 * 60;
const REFRESH_COOKIE_SECONDS = 7 * 24 * 60 * 60;

export async function buildApp(opts: BuildOpts): Promise<FastifyInstance> {
  const { prisma, secret } = opts;
  const startedAt = Date.now();
  const metrics = new MetricsRegistry();
  const app = Fastify({
    logger: opts.logger ?? false,
    disableRequestLogging: true,
    genReqId: (rawRequest) => correlationId(rawRequest.headers['x-request-id']),
  });
  const unmappedMasters = Object.keys(MASTERS).filter((name) => !MASTER_FORM_BY_NAME[name]);
  const orphanedMasterPolicies = Object.keys(MASTER_FORM_BY_NAME).filter((name) => !MASTERS[name]);
  if (unmappedMasters.length || orphanedMasterPolicies.length) {
    throw new Error(
      `master-route-policy-mismatch: unmapped=${unmappedMasters.join(',') || 'none'}; ` +
        `orphaned=${orphanedMasterPolicies.join(',') || 'none'}`,
    );
  }
  const cookieBase = {
    httpOnly: true as const,
    sameSite: 'strict' as const,
    path: '/',
    secure: opts.secureCookies ?? false,
  };
  const accessCookie = { ...cookieBase, maxAge: ACCESS_COOKIE_SECONDS };
  const refreshCookie = { ...cookieBase, maxAge: REFRESH_COOKIE_SECONDS };
  await app.register(cookie);
  await app.register(rateLimit, { global: false });

  app.addHook('onRequest', async (req: FastifyRequest, reply: FastifyReply) => {
    (req as RequestState).requestStartedAt = process.hrtime.bigint();
    reply.header('X-Request-Id', req.id);
  });

  // Every declared route must have a registry policy. A newly added route cannot start unless it is
  // deliberately classified public/system/form with an action.
  app.addHook('onRoute', (routeOptions) => {
    const methods = Array.isArray(routeOptions.method)
      ? routeOptions.method
      : [routeOptions.method];
    const policies = methods.map((method) => routePolicyFor(String(method), routeOptions.url));
    const policy = policies[0];
    if (
      !policy ||
      policies.some((candidate) => JSON.stringify(candidate) !== JSON.stringify(policy))
    ) {
      throw new Error(
        `unmapped-or-ambiguous-route-policy: ${methods.join(',')} ${routeOptions.url}`,
      );
    }
    routeOptions.config = {
      ...(routeOptions.config ?? {}),
      authorizationPolicy: policy,
    } as any;
  });

  app.addHook('onSend', async (_req: FastifyRequest, reply: FastifyReply, payload: unknown) => {
    reply.header('X-Content-Type-Options', 'nosniff');
    reply.header('X-Frame-Options', 'DENY');
    reply.header('Referrer-Policy', 'no-referrer');
    reply.header('X-XSS-Protection', '0');
    return payload;
  });

  // A transaction that ran past its budget, or could not start in time, has already rolled back completely.
  // Say so with a retryable 503 instead of an opaque 500 (N53). Nothing retries automatically: a manual retry
  // becomes safe once N52 adds idempotency keys. Every other error goes on to Fastify's default handler.
  app.setErrorHandler((error, req, reply) => {
    if (isTransactionTimeout(error)) {
      req.log.warn({ err: error }, 'transaction budget exceeded; rolled back');
      return reply
        .code(503)
        .header('Retry-After', '1')
        .send({ error: 'transaction-timeout', retryable: true });
    }
    return reply.send(error);
  });

  app.addHook('onResponse', async (req: FastifyRequest, reply: FastifyReply) => {
    const state = req as RequestState;
    const method = req.method;
    const route = req.routeOptions.url || (req.url || '').split('?')[0] || 'unknown';
    const policy = (req.routeOptions.config as any)?.authorizationPolicy as RoutePolicy | undefined;
    const routeClass = (policy?.kind ?? 'unknown') as RouteClass;
    const mutation = ['POST', 'DELETE', 'PUT', 'PATCH'].includes(method);

    metrics.recordRequest(routeClass, reply.statusCode);
    const voucherWrite =
      mutation &&
      policy?.kind === 'form' &&
      policy.form !== '@master' &&
      !String(policy.form ?? '').startsWith('Utilities/') &&
      !String(policy.form ?? '').startsWith('Masters/') &&
      !String(policy.form ?? '').startsWith('Reports/');
    if (voucherWrite) {
      metrics.recordVoucherWrite(
        reply.statusCode < 400 ? 'success' : reply.statusCode < 500 ? 'rejected' : 'server_error',
      );
    }

    const s = state.session;
    if (mutation && s && !route.startsWith('/audit')) {
      const result = await logAudit(prisma, s.tenantId, {
        loginName: s.sub,
        coCode: s.coCode,
        action: method,
        path: route,
        status: reply.statusCode,
      });
      if (!result.logged) {
        metrics.recordAuditWriteFailure();
        req.log.error(
          {
            event: result.error,
            correlationId: req.id,
            tenantId: s.tenantId,
            action: method,
            path: route,
          },
          'audit persistence failed',
        );
      }
    }

    const elapsed = state.requestStartedAt
      ? Number(process.hrtime.bigint() - state.requestStartedAt) / 1_000_000
      : 0;
    req.log.info(
      requestCompletedFields({
        correlationId: req.id,
        method,
        route,
        status: reply.statusCode,
        durationMs: elapsed,
        tenantId: s?.tenantId,
        companyCode: s?.coCode,
        locationCode: s?.lcCode,
        user: s?.sub,
      }),
      'request completed',
    );
  });

  const tenantOf = (req: FastifyRequest): string => {
    const rawHeader = req.headers['x-tenant-id'];
    const headerTenant = Array.isArray(rawHeader) ? rawHeader[0] : rawHeader;
    if (opts.allowTenantHeader !== false && headerTenant?.trim()) return headerTenant.trim();
    return opts.defaultTenantId?.trim() || 'default';
  };

  const contextDescriptor = (session: {
    sessionId: string;
    contextEpoch: string;
    coCode: string;
    lcCode: string;
    coYear?: string;
  }) => ({
    sessionId: session.sessionId,
    contextEpoch: session.contextEpoch,
    coCode: session.coCode,
    lcCode: session.lcCode,
    coYear: session.coYear ?? null,
  });
  const issueContextTokens: RefreshContextDependencies['issueTokens'] = async ({
    session,
    principal,
    refreshJti,
  }) => {
    const accessToken = await issueAccess(
      {
        sub: session.loginName,
        tenantId: session.tenantId,
        sid: session.sessionId,
        loginCoCode: session.loginCoCode,
        coCode: session.coCode,
        lcCode: session.lcCode,
        coYear: session.coYear,
        contextEpoch: session.contextEpoch,
        rights: principal.rights,
        passwordResetRequired: principal.passwordResetRequired,
      },
      secret,
    );
    const refreshToken = await issueRefresh(
      {
        sub: session.loginName,
        tenantId: session.tenantId,
        sid: session.sessionId,
        jti: refreshJti,
      },
      secret,
    );
    return { accessToken, refreshToken };
  };

  const sess = (req: FastifyRequest): Session => (req as RequestState).session as Session;
  const principalOf = (req: FastifyRequest): Principal =>
    (req as RequestState).principal as Principal;
  const scopeOfRequest = (req: FastifyRequest): BusinessScope =>
    (req as RequestState).businessScope ?? {
      tenantId: sess(req).tenantId,
      coCode: sess(req).coCode,
      lcCode: sess(req).lcCode,
      coYear: sess(req).coYear,
    };

  async function requireAuth(req: FastifyRequest, reply: FastifyReply): Promise<void> {
    const route = req.routeOptions.url ?? '';
    if (route === '/me' || route.startsWith('/auth/') || route.startsWith('/context/')) {
      reply.header('Cache-Control', 'no-store');
    }
    const state = req as RequestState;
    if (state.session) return;
    const token = (req as any).cookies?.access as string | undefined;
    if (!token) {
      await reply.code(401).send({ error: 'unauthenticated' });
      return;
    }
    try {
      const claims = await verifyAccessToken(token, secret);
      const stored = await validateAccessSessionContext(prisma, claims);
      const pageSession = req.headers['x-session-context-id'];
      const pageEpoch = req.headers['x-session-context-epoch'];
      if (
        (pageSession !== undefined || pageEpoch !== undefined) &&
        (pageSession !== stored.sessionId || pageEpoch !== stored.contextEpoch)
      ) {
        await reply.code(409).send({ error: 'context-stale' });
        return;
      }
      const principal = await loadPrincipal(prisma, {
        tenantId: claims.tenantId,
        loginName: claims.sub,
        coCode: stored.coCode,
        loginCoCode: stored.loginCoCode,
      });
      state.principal = principal;
      state.session = {
        ...claims,
        contextEpoch: stored.contextEpoch,
        ledgerContext: stored.ledgerContext,
        coCode: stored.coCode,
        lcCode: stored.lcCode,
        coYear: stored.coYear,
        loginCoCode: stored.loginCoCode,
        rights: principal.rights,
        passwordResetRequired: principal.passwordResetRequired,
        principal,
      };
    } catch (error) {
      const code =
        error instanceof SessionRejectedError || error instanceof PrincipalUnavailableError
          ? 'session-invalid'
          : 'invalid-token';
      await reply.code(401).send({ error: code });
    }
  }

  // Central authorization executes before report-filter validation and every route-local preHandler. Existing
  // `requireAuth` declarations remain as defense in depth and become no-ops once this hook loaded the session.
  /**
   * Refuse a shared report filter unless the authorized report actually applies it.
   *
   * Only bound reports call `applyFilters`. Live verification showed `GET /reports/day-book?city=Surat`
   * returning 200 with an UNFILTERED result set — the exact failure this refusal prevents. This function is
   * called only after authentication and per-form authorization, so an invalid filter cannot reveal report
   * capabilities or replace the required 401/403 response for an unauthenticated or unauthorized caller.
   */
  const enforceReportFilters = async (req: FastifyRequest, reply: FastifyReply): Promise<void> => {
    const url = req.routeOptions.url ?? '';
    if (!url.startsWith('/reports/')) return;
    const q = (req.query ?? {}) as Record<string, string | undefined>;
    const asked = REPORT_FILTER_KEYS.filter((k) => String(q[k] ?? '').trim());
    if (!asked.length) return;
    // The slug is the first path segment after /reports/, which is how every report route is shaped.
    const dynamicReport = (req.params as any)?.report;
    const slug = String(dynamicReport ?? url.split('/')[2] ?? '').replace(
      /\.(csv|xlsx|pdf|print)$/,
      '',
    );
    // Unknown dynamic slugs have already failed central @report resolution. Keep this defensive return so
    // this validation helper can never classify an unresolved slug as a filter-capability error.
    if (dynamicReport != null && !reportFormForSlug(slug)) return;
    const binding = REPORT_FILTER_BINDINGS[slug];
    const allowed = new Set(binding ? supportedFilters(binding) : []);
    const bad = asked.filter((k) => !allowed.has(k));
    if (bad.length) {
      await reply.code(400).send({
        error: 'ReportFilterError',
        message: `this report cannot filter by: ${bad.join(', ')}`,
      });
    }
  };

  app.addHook('preHandler', async (req: FastifyRequest, reply: FastifyReply) => {
    const policy = (req.routeOptions.config as any)?.authorizationPolicy as RoutePolicy | undefined;
    if (!policy) {
      // An UNMATCHED path has no route options at all, and that is a client error, not a server fault.
      // Previously every unknown URL returned 500 `route-policy-missing`, which would make ordinary 404 noise
      // indistinguishable from real server faults in production alerting.
      if (!req.routeOptions.url) {
        return reply.code(404).send({ error: 'not-found' });
      }
      // A route that IS registered but carries no policy remains a hard 500. That fail-closed behaviour is
      // what forces every new route into routePolicy.ts, so it must not be softened.
      return reply.code(500).send({ error: 'route-policy-missing' });
    }
    if (policy.kind === 'public') return;
    await requireAuth(req, reply);
    if (reply.sent) return;

    const state = req as RequestState;
    const s = state.session!;
    const principal = state.principal!;
    const routeUrl = req.routeOptions.url;
    if (
      principal.passwordResetRequired &&
      routeUrl !== '/auth/password/change' &&
      routeUrl !== '/me'
    ) {
      return reply.code(403).send({ error: 'password-reset-required' });
    }

    try {
      if (policy.businessScope) {
        state.businessScope = await enforceRequestScope(prisma, req, {
          tenantId: s.tenantId,
          coCode: s.coCode,
          lcCode: s.lcCode,
          coYear: s.coYear,
        });
      }
      if (policy.kind === 'form') {
        const form = resolvePolicyForm(policy, req.params as Record<string, unknown>);
        if (!form) {
          return reply
            .code(403)
            .send({ error: 'forbidden', form: 'unresolved', action: policy.action });
        }
        await authorizeForm(prisma, {
          tenantId: s.tenantId,
          lcCode: s.lcCode,
          principal,
          form,
          action: policy.action!,
          adminOnly: policy.adminOnly,
        });
      }
      state.routeAuthorized = true;
      await enforceReportFilters(req, reply);
    } catch (error) {
      if (error instanceof ScopeError) {
        return reply.code(error.statusCode).send({ error: error.code });
      }
      if (error instanceof FormForbiddenError) {
        return reply.code(403).send({ error: 'forbidden', form: error.form, action: error.action });
      }
      throw error;
    }
  });

  app.get('/health', async () => healthPayload(Date.now(), startedAt));
  app.get('/ready', async (_req: FastifyRequest, reply: FastifyReply) => {
    const result = await readiness(prisma, 'readiness', opts.rendererProbe);
    return reply.code(result.ready ? 200 : 503).send(result);
  });
  app.get('/ops/metrics', { preHandler: requireAuth }, async (_req, reply) => {
    await collectDatabaseMetrics(prisma, metrics);
    return reply
      .header('content-type', 'text/plain; version=0.0.4; charset=utf-8')
      .send(metrics.prometheus());
  });
  app.get('/ops/invariants', { preHandler: requireAuth }, async (_req, reply) => {
    try {
      const result = await operationalInvariants(prisma);
      return reply.code(result.healthy ? 200 : 503).send(result);
    } catch {
      return reply.code(503).send({ healthy: false, error: 'invariant-check-failed' });
    }
  });

  app.post(
    '/auth/login',
    { config: { rateLimit: { max: 10, timeWindow: '1 minute' } } },
    async (req: FastifyRequest, reply: FastifyReply) => {
      const b = (req.body ?? {}) as Record<string, string | undefined>;
      const tenantId = tenantOf(req);
      reply.header('Cache-Control', 'no-store');
      if (!b.coCode || !b.loginName || !b.password) {
        return reply.code(400).send({ error: 'missing-fields' });
      }
      try {
        const created = await loginSessionContext(
          prisma,
          {
            tenantId,
            coCode: b.coCode,
            loginName: b.loginName,
            password: b.password,
            lcCode: b.lcCode,
            coYear: b.coYear,
          },
          { issueTokens: issueContextTokens },
        );
        reply
          .setCookie('access', created.accessToken, accessCookie)
          .setCookie('refresh', created.refreshToken, refreshCookie);
        return {
          user: created.session.loginName,
          rights: created.principal.rights,
          forcedReset: created.principal.passwordResetRequired,
          scope: {
            coCode: created.session.coCode,
            lcCode: created.session.lcCode,
            coYear: created.session.coYear ?? null,
          },
          context: contextDescriptor(created.session),
          ledgerContext: created.session.ledgerContext,
        };
      } catch (error) {
        // The client response stays deliberately generic so it cannot be used to enumerate users or
        // probe configuration. The server log DOES distinguish the two causes, because a missing
        // company/location/year configuration is an operator problem, not a wrong password, and
        // reporting both identically sends operators hunting credentials for hours.
        if (error instanceof ScopeError) {
          req.log?.warn(
            { reason: 'scope-unresolved' },
            'login rejected: company/location/year configuration could not be resolved',
          );
          return reply.code(401).send({ error: 'invalid-credentials' });
        }
        if (error instanceof AuthError) {
          return reply.code(401).send({ error: 'invalid-credentials' });
        }
        throw error;
      }
    },
  );

  app.post('/auth/refresh', async (req: FastifyRequest, reply: FastifyReply) => {
    reply.header('Cache-Control', 'no-store');
    const token = (req as any).cookies?.refresh as string | undefined;
    if (!token) return reply.code(401).send({ error: 'invalid-refresh' });
    try {
      const claims = await verifyRefreshToken(token, secret);
      const refreshed = await refreshSessionContext(prisma, claims, {
        issueTokens: issueContextTokens,
      });
      reply
        .setCookie('access', refreshed.accessToken, accessCookie)
        .setCookie('refresh', refreshed.refreshToken, refreshCookie);
      return {
        refreshed: true,
        context: contextDescriptor(refreshed.session),
        ledgerContext: refreshed.session.ledgerContext,
      };
    } catch {
      reply.clearCookie('access', cookieBase).clearCookie('refresh', cookieBase);
      return reply.code(401).send({ error: 'invalid-refresh' });
    }
  });

  app.post('/auth/logout', async (req: FastifyRequest, reply: FastifyReply) => {
    const token = (req as any).cookies?.refresh as string | undefined;
    if (token) {
      try {
        const claims = await verifyRefreshToken(token, secret);
        await revokeSession(prisma, claims.tenantId, claims.sid, 'logout');
      } catch {
        // Always clear cookies; an invalid/expired refresh token is already unusable.
      }
    }
    reply.clearCookie('access', cookieBase).clearCookie('refresh', cookieBase);
    return { ok: true };
  });

  app.post(
    '/auth/password/change',
    { preHandler: requireAuth },
    async (req: FastifyRequest, reply: FastifyReply) => {
      const s = sess(req);
      const b = (req.body ?? {}) as Record<string, string | undefined>;
      try {
        await changeOwnPassword(prisma, {
          tenantId: s.tenantId,
          loginCoCode: s.loginCoCode,
          loginName: s.sub,
          currentPassword: b.currentPassword ?? '',
          newPassword: b.newPassword ?? '',
          confirmPassword: b.confirmPassword ?? '',
          currentSessionId: s.sid,
        });
        return { changed: true };
      } catch (error) {
        if (error instanceof PasswordPolicyError) {
          return reply.code(400).send({ error: 'weak-password', reasons: error.reasons });
        }
        if (error instanceof PasswordChangeError) {
          return reply.code(400).send({ error: error.code });
        }
        throw error;
      }
    },
  );

  app.get('/me', { preHandler: requireAuth }, async (req: FastifyRequest, reply: FastifyReply) => {
    reply.header('Cache-Control', 'no-store');
    const s = sess(req);
    const principal = principalOf(req);
    const allowedForms = await resolveAllowedForms(
      prisma,
      { tenantId: s.tenantId, lcCode: s.lcCode },
      s.sub,
      principal.isAdmin,
    );
    return {
      user: s.sub,
      context: contextDescriptor({
        sessionId: s.sid,
        contextEpoch: s.contextEpoch,
        coCode: s.coCode,
        lcCode: s.lcCode,
        coYear: s.coYear,
      }),
      ledgerContext: s.ledgerContext,
      coCode: s.coCode,
      lcCode: s.lcCode,
      coYear: s.coYear ?? null,
      rights: principal.rights,
      role: principal.role,
      isAdmin: principal.isAdmin,
      passwordResetRequired: principal.passwordResetRequired,
      allowedForms,
    };
  });

  app.get('/audit', { preHandler: requireAuth }, async (req: FastifyRequest) =>
    listAudit(prisma, sess(req).tenantId),
  );

  app.get(
    '/backup',
    { preHandler: requireAuth },
    async (req: FastifyRequest, reply: FastifyReply) => {
      const data = await backupCompany(prisma, sess(req).tenantId, sess(req).coCode);
      // The artefact is now in the operator's hands, so record its identity append-only. This is what a
      // destructive data repair must later name as its recovery cover.
      await recordCompanyBackup(prisma, data, sess(req).sub);
      return reply
        .header('content-type', 'application/json')
        .header(
          'content-disposition',
          `attachment; filename="backup-${sess(req).coCode}-${new Date().toISOString().slice(0, 10)}.json"`,
        )
        .send(data);
    },
  );

  app.get('/context/companies', { preHandler: requireAuth }, async (req: FastifyRequest) => {
    const s = sess(req);
    const principal = principalOf(req);
    return listScopeCompanies(prisma, {
      tenantId: s.tenantId,
      loginName: s.sub,
      isAdmin: principal.isAdmin,
    });
  });

  app.get('/context/locations', { preHandler: requireAuth }, async (req: FastifyRequest) => {
    const s = sess(req);
    return listScopeLocations(prisma, { tenantId: s.tenantId, coCode: s.coCode });
  });

  app.get('/context/years', { preHandler: requireAuth }, async (req: FastifyRequest) => {
    const s = sess(req);
    return listScopeYears(prisma, { tenantId: s.tenantId, coCode: s.coCode });
  });

  app.get('/context/books', { preHandler: requireAuth }, async (req: FastifyRequest) => {
    const s = sess(req);
    return listScopeBooks(prisma, {
      tenantId: s.tenantId,
      coCode: s.coCode,
      lcCode: s.lcCode,
    });
  });

  app.post(
    '/context/select',
    { preHandler: requireAuth },
    async (req: FastifyRequest, reply: FastifyReply) => {
      reply.header('Cache-Control', 'no-store');
      const s = sess(req);
      try {
        const selected = await selectSessionContext(
          prisma,
          {
            identity: {
              tenantId: s.tenantId,
              sessionId: s.sid,
              loginName: s.sub,
              loginCoCode: s.loginCoCode,
              coCode: s.coCode,
              lcCode: s.lcCode,
              coYear: s.coYear,
              contextEpoch: s.contextEpoch,
            },
            request: req.body,
          },
          { signAccess: (descriptor) => issueAccess({ ...descriptor }, secret) },
        );
        reply.setCookie('access', selected.accessToken, accessCookie);
        return {
          coCode: selected.session.coCode,
          lcCode: selected.session.lcCode,
          coYear: selected.session.coYear,
          scoped: true,
          replayed: selected.replayed,
          ledgerContext: selected.session.ledgerContext,
          context: contextDescriptor(selected.session),
        };
      } catch (error) {
        if (error instanceof ScopeError)
          return reply.code(error.statusCode).send({ error: error.code });
        if (error instanceof ContextSelectionError) {
          const status =
            error.code === 'invalid-context-selection-request'
              ? 400
              : ['password-reset-required', 'target-password-reset-required'].includes(error.code)
                ? 403
                : ['session-invalid', 'session-revoked', 'session-expired'].includes(error.code)
                  ? 401
                  : error.code === 'context-signing-failed'
                    ? 500
                    : 409;
          return reply.code(status).send({ error: error.code });
        }
        if (error instanceof PrincipalUnavailableError)
          return reply.code(401).send({ error: 'session-invalid' });
        if (error instanceof LastDayLockConfigurationError)
          return reply.code(409).send({ error: 'last-day-lock-invalid' });
        throw error;
      }
    },
  );

  const masterOf = (req: FastifyRequest, reply: FastifyReply) => {
    const name = (req.params as Record<string, string | undefined>).name ?? '';
    const cfg = MASTERS[name];
    if (!cfg) {
      reply.code(404).send({ error: 'unknown-master' });
      return null;
    }
    return cfg;
  };
  const masterScope = (req: FastifyRequest): MasterScope => {
    const scope = scopeOfRequest(req);
    return { tenantId: scope.tenantId, coCode: scope.coCode, lcCode: scope.lcCode };
  };

  app.get(
    '/masters/:name',
    { preHandler: requireAuth },
    async (req: FastifyRequest, reply: FastifyReply) => {
      const cfg = masterOf(req, reply);
      if (!cfg) return;
      if (cfg.table === 'COL_MAST') {
        const query = req.query as Record<string, unknown>;
        reply.header('Cache-Control', 'no-store');
        try {
          return await listColumnSettings(prisma, masterScope(req), {
            offset: query.offset,
            limit: query.limit,
            family: query.family,
            search: query.search,
          });
        } catch (error) {
          if (error instanceof ColumnSettingsError)
            return reply.code(error.statusCode).send({ error: error.code, message: error.message });
          throw error;
        }
      }
      return listMaster(prisma, masterScope(req), cfg);
    },
  );

  app.get(
    '/masters/:name/meta',
    { preHandler: requireAuth },
    async (req: FastifyRequest, reply: FastifyReply) => {
      const cfg = masterOf(req, reply);
      if (!cfg) return;
      const ff = resolveFormFields(cfg, GENERATED_FORM_FIELDS[cfg.table]);
      let columnCapabilities:
        { canCreate: boolean; canUpdate: boolean; canDelete: boolean } | undefined;
      if (cfg.table === 'COL_MAST') {
        const scope = masterScope(req);
        reply.header('Cache-Control', 'no-store');
        const allowed = await Promise.all(
          (['create', 'update', 'delete'] as const).map(async (action) => {
            try {
              await authorizeForm(prisma, {
                tenantId: scope.tenantId,
                lcCode: scope.lcCode!,
                principal: principalOf(req),
                form: 'Masters/Styles / Columns',
                action,
              });
              return true;
            } catch (error) {
              if (error instanceof FormForbiddenError) return false;
              throw error;
            }
          }),
        );
        columnCapabilities = {
          canCreate: allowed[0]!,
          canUpdate: allowed[1]!,
          canDelete: allowed[2]!,
        };
      }
      return {
        table: cfg.table,
        keyColumns: cfg.keyColumns,
        requiredColumns: cfg.requiredColumns,
        formFields: ff ? withGroups(ff) : null,
        ...(columnCapabilities ? { capabilities: columnCapabilities } : {}),
      };
    },
  );

  app.post(
    '/masters/:name',
    { preHandler: requireAuth },
    async (req: FastifyRequest, reply: FastifyReply) => {
      const cfg = masterOf(req, reply);
      if (!cfg) return;
      try {
        await createMaster(
          prisma,
          masterScope(req),
          cfg,
          (req.body ?? {}) as Record<string, unknown>,
        );
        return reply.code(201).send({ created: true });
      } catch (e) {
        if (e instanceof ColumnSettingsError)
          return reply.code(e.statusCode).send({ error: e.code, message: e.message });
        if (e instanceof ValidationError)
          return reply.code(400).send({ error: 'missing-required', missing: e.missing });
        if (e instanceof DuplicateKeyError) return reply.code(409).send({ error: 'duplicate-key' });
        if (e instanceof ReferencedError)
          return reply.code(409).send({ error: 'referenced', ref: e.ref });
        if (e instanceof DataError)
          return reply.code(400).send({ error: 'invalid-data', detail: e.detail });
        throw e;
      }
    },
  );

  app.put(
    '/masters/:name',
    { preHandler: requireAuth },
    async (req: FastifyRequest, reply: FastifyReply) => {
      const cfg = masterOf(req, reply);
      if (!cfg) return;
      try {
        await updateMaster(
          prisma,
          masterScope(req),
          cfg,
          (req.body ?? {}) as Record<string, unknown>,
        );
        return { updated: true };
      } catch (e) {
        if (e instanceof ColumnSettingsError)
          return reply.code(e.statusCode).send({ error: e.code, message: e.message });
        if (e instanceof ValidationError)
          return reply.code(400).send({ error: 'missing-required', missing: e.missing });
        if (e instanceof NotFoundError) return reply.code(404).send({ error: 'not-found' });
        if (e instanceof DataError)
          return reply.code(400).send({ error: 'invalid-data', detail: e.detail });
        throw e;
      }
    },
  );

  app.delete(
    '/masters/:name',
    { preHandler: requireAuth },
    async (req: FastifyRequest, reply: FastifyReply) => {
      const cfg = masterOf(req, reply);
      if (!cfg) return;
      try {
        await deleteMaster(
          prisma,
          masterScope(req),
          cfg,
          (req.body ?? {}) as Record<string, unknown>,
        );
        return { deleted: true };
      } catch (e) {
        if (e instanceof ColumnSettingsError)
          return reply.code(e.statusCode).send({ error: e.code, message: e.message });
        if (e instanceof ReferencedError)
          return reply.code(409).send({ error: 'referenced', ref: e.ref });
        throw e;
      }
    },
  );

  app.post(
    '/masters/:name/import',
    { preHandler: requireAuth },
    async (req: FastifyRequest, reply: FastifyReply) => {
      const cfg = masterOf(req, reply);
      if (!cfg) return;
      const rows = ((req.body as Record<string, unknown> | undefined)?.rows ?? []) as Record<
        string,
        unknown
      >[];
      if (!Array.isArray(rows)) return reply.code(400).send({ error: 'rows-array-required' });
      return importMaster(prisma, masterScope(req), cfg, rows);
    },
  );

  registerTxnRoutes(app, {
    prisma,
    requireAuth,
    sess,
    scopeOfRequest,
    metrics,
    routeAuthorized: (req) => isRouteAuthorizedMarker((req as RequestState).routeAuthorized),
  });

  return app;
}
