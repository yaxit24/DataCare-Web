# DB PARITY — web ⟷ desktop (2026-07-14)

Goal: (a) confirm nothing DB-side remains un-extracted, (b) make the web Postgres a complete replica of the desktop DB.

## A. Extraction completeness — DB objects
Queried the restored real databases in Docker SQL (Next24r = authoritative, 146 tables):

| Object | Count in real DB | Action |
|---|--:|---|
| Tables | 146 | schema extracted |
| Columns | 5,254 | extracted **with full metadata** (type/len/precision/scale/nullable/identity/default) |
| Column defaults | 2,355 | newly extracted |
| Primary keys | 127 tables | newly extracted |
| Indexes (non-PK) | 162 | present (metadata) |
| **Stored procedures** | **0** | none exist |
| **Views** | **0** | none exist |
| **Triggers** | **0** | none exist |
| **Foreign keys** | **0** | none exist |
| **Check constraints** | **0** | none exist |

**Key conclusion:** the desktop DB has **no procedures/views/triggers/FKs** — *all business logic lives in the C# application code + inline SQL*, which is already extracted (204 forms decompiled + 5,128 inline-SQL templates in the behavior catalogs). So there is **nothing logic-side left to extract from the database.** The only enrichment beyond the prior `realdb-schema.json` (col/type/len) was column nullability/identity/**defaults**/PKs → captured in **`catalogs/realdb-schema-full.json`** (146 tables, 5,254 cols, 2,355 defaults).

## B. Web-vs-real schema gap — found + closed
Compared the **live** web Postgres (`information_schema`) to the real 146-table schema.

| | Before | After |
|---|--:|--:|
| Real tables present in web | 142 / 146 | **146 / 146** |
| Missing tables | 4 | **0** |
| Missing columns (shared tables) | 22 | **0** |
| Web tables / columns | 164 / 5,889 | **168 / 6,010** |

**Closed additively** (`migrations/20260714010000_schema_parity/migration.sql`, idempotent, all new columns nullable → demo data untouched):
- **4 tables created:** `COUNTRY_MAST` (country master, 151 seed rows in desktop), `IMAGE_DATA` (tag/design image store, incl. `TAG_IMAGE bytea`), `LBR_ISU_IDTL` (labour-issue item detail, 52 cols), `OP_DETL` (opening detail, 27 cols) — each with the web `tenant_id`/`row_id`-sequence pattern + RLS `tenant_isolation` policy + business-key unique index.
- **22 columns added:** `TAG_DATA` +20 (B2B/B2C labour rates, DESIGN_NO, EMP_CODE, ITM_CITY/LOT/MRP/TOUCH, IT_CODE/TYPE, KR_NAME, MODEL_NAME, PR_CODE…), `DM_DATA` +2 (INOUT_TYPE, MAIN_IT_CODE).

The web schema is now a **complete superset** of the desktop schema (168 ≥ 146 tables; every real table + column present). Note: earlier the web already had many desktop columns the init-migration file didn't show — the true gap was only 4 tables + 22 columns, not the 987 a naive migration-file parse suggested.

## C. Verification
- Re-ran the gap analysis against the live DB post-migration: **0 missing tables, 0 missing columns.**
- Demo data intact (AC_MAST=919, SL_DATA=191 unchanged before/after).
- api build 0 errors · web typecheck 0 · **vitest 180 passed** · masters + login work live.
- Migration saved + recorded in `_prisma_migrations` (tracked as applied; idempotent for fresh deploys).

## D. What remains (not extraction / not schema)
- Real **transaction data** volume — shipped `.BAK`s are fresh-company templates; needs a live-shop backup to ETL.
- Wiring the newly-available tables/columns into web UI (e.g., `COUNTRY_MAST` as a `/masters/countries` lookup for the party Country field; TAG_DATA new columns into the tag master) — this is *replication/build*, not extraction.
