# ADR-0003 — HTTP framework: Fastify-first (revises NestJS choice for the HTTP layer)

- **Status:** Accepted
- **Date:** 2026-06-28

## Context
ADR-0001 named NestJS (Fastify adapter) for the API. In practice, NestJS dependency-injection
relies on `emitDecoratorMetadata`, which Vitest (esbuild) does not emit without extra SWC/unplugin
wiring — creating friction and boilerplate that slows the multi-tier test loop.

## Decision
Build the HTTP layer directly on **Fastify** (the same engine Nest would use under the hood),
reusing the already-unit-tested cores (`auth/*`, `rbac/policy`, `@datacare/db withTenant`). Use
`@fastify/cookie` (httpOnly sessions), `@fastify/rate-limit`, and Fastify's built-in `.inject()` for
Tier-2 HTTP tests (no real port, no supertest).

## Consequences
- Faster, friction-free testing; less boilerplate; same performance profile.
- Routes are thin handlers over tested services → behavior parity unaffected.
- If full Nest is later desired (modules/guards/DI ergonomics), the handlers wrap cleanly since
  Fastify is Nest's adapter. No data/contract changes.
