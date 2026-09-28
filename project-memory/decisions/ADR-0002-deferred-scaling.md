# ADR-0002 — Right-sized infrastructure ("scale-ready, not scaled")

- **Status:** Accepted
- **Date:** 2026-06-28

## Context
The product will not see thousands of concurrent requests soon. We want a solid, correct
base without premature operational complexity, while never blocking future scale.

## Decision
**Build now (low complexity, high value):**
- Stateless API; queue-based workers (Redis + BullMQ) for reports / e-invoice / messaging.
- Multi-tenant isolation via PostgreSQL Row-Level Security + `tenant_id`.
- Clean module boundaries (NestJS) and a `packages/core` pure-logic layer.
- One managed PostgreSQL + one Redis + S3-compatible object storage.
- Env-based config, health checks, structured logging, Sentry error tracking.
- Daily automated backups; Docker deploy on a simple managed host (or single Compose VM).

**Defer (documented levers — zero work now, architecture must not block them):**
- Horizontal autoscaling of app/workers.
- Postgres read replicas.
- Dedicated connection-pooler tier (PgBouncer) for high concurrency.
- Table partitioning / sharding (e.g., by tenant or year).
- Multi-region / CDN tuning.

## Consequences
- Lower ops burden and faster delivery now.
- Each deferred lever is additive later (no rewrite): statelessness + RLS + queues + clean
  boundaries are the enabling foundations and are in place from day one.
