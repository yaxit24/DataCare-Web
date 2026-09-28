# Deploy — DataCareNext Web (Docker Compose)

Right-sized single-host deployment (ADR-0002): **PostgreSQL + API + Web** on one Docker
network, built from the pnpm + turbo monorepo.

| Service    | Image source         | Port (host:container) | Notes                                                     |
| ---------- | -------------------- | --------------------- | --------------------------------------------------------- |
| `postgres` | `postgres:16-alpine` | `5433:5432`           | healthcheck + `pgdata` volume                             |
| `api`      | `Dockerfile.api`     | `4000:4000`           | Fastify, `/health` liveness + `/ready` security readiness |
| `web`      | `Dockerfile.web`     | `4001:4001`           | `@datacare/web` (Next.js 15)                              |

The web app proxies `/api/:path*` → `http://api:4000` (same-origin, so the httpOnly auth
cookies work). That origin is **baked into the web image at build time** (see _Web ↔ API_ below).

---

## 1. Prerequisites

- Docker Engine + Docker Compose v2 (`docker compose version`).
- This repo checked out; run all commands from `web/` (the directory holding `docker-compose.yml`).

## 2. Configure environment

```bash
cp .env.example .env
# edit .env and set, at minimum:
#   POSTGRES_PASSWORD   – Postgres superuser password
#   APP_DB_PASSWORD     – app_user (runtime) password
#   JWT_SECRET          – long random string:  openssl rand -hex 48
#   APP_TENANT_ID       – the migrated customer's tenant_id (1–24 safe characters)
```

`docker-compose.yml` reads `.env` automatically. The DB/JWT vars are marked required and
compose will refuse to start until they are set. Integration creds (GSP / WhatsApp / SMS)
can stay blank — the API falls back to built-in Fake/no-op senders until they are filled.

## 3. Build the images

```bash
docker compose build
```

## 4. First-run database bootstrap

The runtime API connects as the non-superuser **`app_user`** so Postgres Row-Level Security
is enforced. Schema DDL, RLS policies and the `app_user` role must be created first, using the
**superuser** role. Do this once on a fresh volume (and after any new Prisma migration).

```bash
# 4a. Start only the database and wait for it to become healthy.
docker compose up -d postgres
docker compose ps                       # wait until postgres is "healthy"

# 4b. Apply Prisma migrations as the OWNER/superuser (override DATABASE_URL for this one-off).
#     Uses the prisma CLI already present in the api image; no pnpm needed.
docker compose run --rm --workdir /repo/packages/db \
  -e DATABASE_URL="postgresql://datacare:<POSTGRES_PASSWORD>@postgres:5432/datacare?schema=public" \
  api ./node_modules/.bin/prisma migrate deploy --schema prisma/schema.prisma

# 4c. Reapply the repeatable RLS safety script, then create/configure app_user with the
#     exact runtime password. setup_roles.sql rejects missing or short values.
docker compose exec -T postgres \
  psql -U datacare -d datacare -v ON_ERROR_STOP=1 -f - \
  < packages/db/prisma/rls.sql

export APP_DB_PASSWORD='<same value configured in .env>'
docker compose exec -T postgres \
  psql -U datacare -d datacare -v ON_ERROR_STOP=1 \
  -v app_password="$APP_DB_PASSWORD" -f - \
  < packages/db/setup_roles.sql

# 4d. Prove the actual app_user is non-bypass, every tenant table has ENABLE+FORCE RLS,
#     and tenant A/B reads and writes are isolated. All probe rows are rolled back.
docker compose exec -T postgres env PGPASSWORD="$APP_DB_PASSWORD" \
  psql -U app_user -d datacare -v ON_ERROR_STOP=1 -f - \
  < packages/db/test/verify_runtime.sql
```

> **`prisma migrate deploy` is mandatory, including for throwaway environments.** Do not replace step 4b
> with `prisma db push`: `db push` creates Prisma tables but does not execute committed raw-SQL migration
> assets such as `datacare_advance_owned_sequence`, so step 4c would fail closed and logical-restore
> sequence safety would be absent. Use a disposable database with the normal migration chain instead.

> If you ran `docker compose up -d` (all services) before bootstrapping, the `api` container
> will crash-loop until `app_user` exists — that is expected; it recovers automatically once
> step 4 completes (`restart: unless-stopped`).

## 5. Start the stack

```bash
docker compose up -d
docker compose ps          # api + web should report "healthy"
```

- Web UI: http://localhost:4001
- API liveness: http://localhost:4000/health — process-only status, suitable for diagnostics.
- API readiness: http://localhost:4000/ready — HTTP 200 only when the database is reachable,
  the current role is neither superuser nor `BYPASSRLS`, and every tenant table has
  ENABLE+FORCE RLS. Compose uses this probe before starting the web tier.

## 6. Seeding & data import

- **Demo seed** (a demo company + `admin` login) runs automatically **only when
  `NODE_ENV != production`** — so it is off in this stack by design. To create a demo
  environment, run the API with `NODE_ENV=development` (and `SEED_DEMO=1`).
- **Real customer data** is loaded per tenant via the migration/ETL flow (SQL Server →
  Postgres) described in `docs/runbooks/migration.md`. Each customer is one `tenant_id`;
  every row carries it and RLS isolates it. Run the ETL against the same Postgres instance
  (host port `5433`) using the **superuser** connection, then re-run the parity sign-off
  before go-live.
- Optional performance indexes: `docker compose exec -T postgres psql -U datacare -d datacare < deploy/sql/perf-indexes.sql`.

## 7. Web ↔ API origin (build-time!)

`apps/web/next.config.mjs` serializes the `/api` rewrite destination into
`.next/routes-manifest.json` **at build time**. `docker-compose.yml` therefore passes
`API_ORIGIN=http://api:4000` as a **build arg** to `Dockerfile.web` (and again as a runtime
env as a safety net). If you deploy the web image somewhere the API is not reachable at
`http://api:4000`, **rebuild** the web image with the correct `API_ORIGIN`:

```bash
docker compose build --build-arg API_ORIGIN=https://api.example.com web
```

## 8. HTTPS / reverse proxy

Terminate TLS at a reverse proxy (nginx or Caddy) in front of the `web` service; proxy
public 443 → `web:4001`. The API stays private on the compose network (do not expose 4000
publicly in production; drop its host port mapping if the proxy only needs the web app).

**Secure cookies.** With `NODE_ENV=production`, the API itself sets authentication cookies
`HttpOnly`, `SameSite=Strict`, and `Secure`; startup also rejects missing/default JWT secrets.
The reverse proxy must terminate TLS and preserve `X-Forwarded-Proto`, but it does not need to
rewrite cookie attributes. Development keeps `Secure` off so the local HTTP harness remains usable.

nginx:

```nginx
server {
  listen 443 ssl;
  server_name app.example.com;
  # ssl_certificate / ssl_certificate_key ...

  location / {
    proxy_pass         http://127.0.0.1:4001;
    proxy_set_header   Host $host;
    proxy_set_header   X-Forwarded-Proto $scheme;   # tells upstreams the edge is HTTPS
    proxy_set_header   X-Forwarded-For $proxy_add_x_forwarded_for;
  }
}
```

Caddy (auto-HTTPS):

```caddy
app.example.com {
    reverse_proxy 127.0.0.1:4001 {
        header_up X-Forwarded-Proto {scheme}
    }
}
```

## 9. Backups

Logical backups use `deploy/backup.sh` (`pg_dump -Fc` + retention pruning). Schedule it via
cron on the host (or a sidecar) with the DB env pointed at the compose Postgres:

```bash
# nightly at 01:00 — runs pg_dump inside the postgres container
0 1 * * *  cd /path/to/web && PGUSER=datacare PGDATABASE=datacare \
  docker compose exec -T postgres pg_dump -U datacare -d datacare -Fc \
  > /var/backups/datacare/datacare-$(date +\%Y\%m\%d-\%H\%M\%S).dump
```

Restore:

```bash
docker compose exec -T postgres pg_restore -U datacare -d datacare --clean --if-exists < <dump-file>
```

- Keep the `pgdata` named volume on durable storage; snapshot it as a second line of defence.
- Copy dumps **off-host** (object storage such as S3/B2) — deferred lever per ADR-0002.
- Test a restore into a scratch database periodically; an untested backup is not a backup.

## 10. Operations

```bash
docker compose logs -f api          # tail API logs
docker compose logs -f web          # tail web logs
docker compose restart api          # restart a service
docker compose pull && docker compose up -d   # if using a registry

# upgrade after code changes:
docker compose build && docker compose up -d
# after a NEW prisma migration is added, re-run step 4b (migrate deploy).
```

## 11. Assumptions & notes

- **This `docker-compose.yml` replaces the previous dev-only compose** (which ran Postgres +
  Redis). **Redis is omitted** because the API reads no `REDIS_URL` today; re-add it when a
  queue/cache is actually wired.
- Postgres keeps the established **host port `5433`** (prior dev convention; container was
  `web-postgres-1`). Internal service-to-service traffic uses container port `5432`.
- The API listens on **4000** and the web on **4001**, matching `next.config.mjs`'s default
  API origin and the `@datacare/web` `start` script (`next start -p 4001`).
- **`/health` is liveness-only.** The Compose healthcheck and deployment readiness gate use
  **`/ready`**, which is wired by the API and must return HTTP 200 before the web tier starts. It verifies
  database connectivity, a non-superuser/non-`BYPASSRLS` runtime role, complete ENABLE+FORCE RLS coverage,
  and renderer availability; do not replace it with the weaker `/health` probe.
- Images are built from the full workspace and **do not prune dev dependencies**, which keeps
  pnpm's symlinked `node_modules` (and the generated Prisma client) intact — a deliberate
  simplicity/correctness trade-off for a right-sized deploy.
- No app source was modified to produce these files.
