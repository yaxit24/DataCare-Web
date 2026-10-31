# Developer setup

How to get the DataCare-Web project running on your laptop, run its tests, and use the desktop reference code while
you build. For what to build and in what order, read [`AGENTS.md`](../../../AGENTS.md) and the
[Phase 1 plan](../../master-parity-plan-2026-09-29/13-phase1-delivery-plan.md). Supported devices and how to connect
them: [devices.md](devices.md).

## 1. Prerequisites

| Tool | Version | Note |
|---|---|---|
| Node.js | 24 LTS (CI and images use it; `engines` is `>=20`) | `node -v` |
| pnpm | 9.15.4 | `corepack enable && corepack prepare pnpm@9.15.4 --activate` |
| Docker | Engine + Compose v2 | `docker compose version`; used for the local and test databases |
| Python | 3 | runs the plan and documentation checks |
| git, GitHub CLI (`gh`) | current | `gh auth status` to confirm you can open pull requests |
| A Chromium for the visual tests | installed by Playwright | `pnpm --filter @datacare/web exec playwright install chromium` |

Browsers for the device and visual flows need a Chromium-based browser (Chrome or Edge): WebSerial (scale) and the
camera APIs are Chromium-only.

## 2. Get the code

```bash
git clone https://github.com/yaxit24/DataCare-Web.git     # the private repo (ask the owner for access)
cd DataCare-Web
git lfs pull                                               # binaries, reports and images are in Git LFS
```

This repository is private and intentionally holds legacy credentials and sample data; read
[`SECURITY-NOTICE.md`](../../../SECURITY-NOTICE.md) before sharing it.

## 3. Install

```bash
cd web
pnpm install --frozen-lockfile
pnpm --filter @datacare/db db:generate      # generate the Prisma client
```

## 4. Run the stack locally

The quickest path uses Docker Compose (`web/docker-compose.yml`): PostgreSQL 16 on host port 5433, the Fastify API on
4000, the Next.js app on 4001.

```bash
cd web
cp .env.example .env        # then set the values the file marks as required (see below)
docker compose up -d postgres
docker compose ps           # wait until postgres is "healthy"
# apply migrations, RLS and the runtime role once — full commands in web/DEPLOY.md §4
docker compose build
docker compose up -d
```

- **Environment values you set in `.env`** (names only; never commit real values):
  `POSTGRES_PASSWORD`, `APP_DB_PASSWORD`, `JWT_SECRET` (`openssl rand -hex 48`), `APP_TENANT_ID`. The API runs the Lite edition by default (`APP_EDITION`, slices N171 and N202, decision D33): set `APP_EDITION_BETA=1` to
  see the higher editions' screens as Beta. For demo data add
  `SEED_DEMO=1` and `DEMO_PASSWORD`. Provider and device variables are in [devices.md](devices.md).
- **`API_ORIGIN` is baked into the web build.** The browser calls the API through a same-origin `/api` rewrite; if
  you change the API port, rebuild the web image with `--build-arg API_ORIGIN=<url>`.
- Full, exact bootstrap (migrations as the owner, `rls.sql`, `setup_roles.sql`, `verify_runtime.sql`) is in
  [`web/DEPLOY.md`](../../../web/DEPLOY.md).

For a dev loop without Docker for the apps: start Postgres as above, then
`PORT=4000 pnpm --filter @datacare/api dev` and `API_ORIGIN=http://127.0.0.1:4000 pnpm --filter @datacare/web dev`.

## 5. Run the tests

From `web/`:

```bash
pnpm lint && pnpm typecheck && pnpm typecheck:tests && pnpm format:check && pnpm build
node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test     # API + write-set DB tests (fresh isolated DB)
API_ORIGIN=http://127.0.0.1:4410 pnpm build && node scripts/parity-test-env.mjs -- node apps/web/test/parity.real-stack.mjs
pnpm docs:refs
```

From the repository root:

```bash
python3 docs/master-parity-plan-2026-09-29/validate_plan.py
python3 docs/tools/docs_check.py
python3 docs/tools/session_status.py       # what other sessions, worktrees and PRs are in flight
```

The isolated test wrapper gives each checkout its own database project and credentials outside the repository. A
second checkout runs at the same time on other ports: `PARITY_TEST_PORT=55533` for the database and, for the browser
suites, `PARITY_API_PORT=4510 PARITY_WEB_PORT=4511` with the web app built using `API_ORIGIN=http://127.0.0.1:4510`.
The status check reports when port 55433 is busy. Full test guide, including the Chrome DevTools visual protocol:
[testing](../web/testing.md).

## 6. Keep the desktop reference code open while you build

During development, keep the decompiled desktop source beside you — it is the authority for business behaviour, and
every change cites it. The reference material is already in the repository:

| What | Where |
|---|---|
| Decompiled desktop C# (the oracle) | `unified/src/csharp/DataCareNext/` — `MDI_FORM.cs` (menu → form), `<FORM>.cs` (each screen), `Ac_Ledr.cs`/`Ac_Stock.cs`/`Ac_Rojmel.cs`/`Ac_Tax.cs` (posting), `DC_Main.cs` (shared helpers) |
| Alternate variant | `unified/src/csharp_nextdm/DataCareNext/` — compare when a behaviour is edition-sensitive |
| Per-form summaries | `project-memory/catalogs/forms/<FORM>.md`, `project-memory/catalogs/form-behavior/<FORM>.behavior.json` |
| Extracted screen layouts | `web/apps/api/form-specs/<FORM>.initcomp.json` |
| Tables and columns | `project-memory/catalogs/realdb-schema-full.json`, `web-implementation-spec/02_Data_Model/tables/` |
| How the desktop looks and is operated | the tutorial knowledge base `project-memory/video-research/_kb/KB_*.md`, with Hindi transcripts and keyframes under `project-memory/video-research/<playlist>/<video>/` (`transcript.txt`, `transcript.sarvam.txt`, `keyframes/kf_NNN.jpg`) |
| Line-level index of every source unit | [`desktop-form-reference.json`](../../master-parity-plan-2026-09-29/desktop-form-reference.json) |

Use the `datacare-desktop-authority` skill to turn a menu into a cited note (dispatch line, save routine, posting
helpers, tables written, the keyframe that shows the screen) before you write code. Because the desktop runs only on
Windows, these screenshots and transcripts are the operating oracle for layout and workflow; stored values come from
the decompiled source and, when available, real desktop database rows (decision D13). Never run write queries against
the desktop databases, and query them only in aggregate — one holds real customer data.

## 7. Day-to-day

- Start a session with `kiro-cli chat --agent datacare` from the repository root (loads the plan, runs the status
  check, blocks pushing to `main`).
- Pick the next slice from [Phase 1 plan §3](../../master-parity-plan-2026-09-29/13-phase1-delivery-plan.md), build it
  with the `datacare-implement-slice` skill, open a pull request, and let the owner merge.
