> **Superseded (1 October 2026).** This June scaffold description names NestJS, Redis and Kysely. The API is built
> directly on Fastify ([ADR-0003](../project-memory/decisions/ADR-0003-http-fastify.md)) and nothing uses a queue yet.
> The current description is the [Web handbook](../docs/handbook/web/README.md).

# DataCareNext — Web SaaS (monorepo)

Multi-tenant cloud rebuild of the DataCareNext jewelry/gold ERP. See `../project-memory/` for the
task graph, decisions (ADRs), and the Phase-0 catalogs that drive this build
(`../project-memory/catalogs/data-model.json`, `forms/`, `module-map.json`).

## Layout

```
web/
├── apps/
│   ├── web/    # Next.js frontend (App Router) — scaffolded in Task 12
│   └── api/    # NestJS backend — scaffolded in Task 10 (health module + tests now)
├── packages/
│   ├── core/     # pure calc engine (decimal.js): fine-weight, labour, rounding — Task 15
│   ├── types/    # shared zod DTOs (TenantScope, UserRights)
│   ├── db/       # Prisma + Kysely data layer — Task 7/9
│   └── reports/  # report dataset builders + HTML→PDF — Task 27/28
├── docker-compose.yml   # local Postgres + Redis (right-sized, ADR-0002)
└── .github/workflows/ci.yml
```

## Quality gates (Definition of Done)

- `pnpm typecheck` · `pnpm test` (Vitest unit + integration) · `pnpm build` · `pnpm format:check`
- Tier-3 e2e (Playwright) and Tier-2 integration (Testcontainers) are added as their phases begin.

## Develop

```
cd web
pnpm install
docker compose up -d        # Postgres + Redis
pnpm test                   # run all workspace tests
pnpm --filter @datacare/api dev   # boot api health server on :3001
```

Stack: Next.js · NestJS (Fastify) · PostgreSQL (Prisma + Kysely) · Redis/BullMQ · decimal.js ·
Playwright (PDF/e2e). Tenancy: shared DB + RLS + `tenant_id`, original composite keys preserved.
