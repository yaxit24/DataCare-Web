# ADR-0001 — Stack, scope, and parity strategy

- **Status:** Accepted
- **Date:** 2026-06-28
- **Deciders:** Product owner + planning agent

## Context
DataCareNext is a Windows jewelry/gold ERP (VB.NET → .NET 4.7.2 WinForms, SQL Server,
255 Crystal Reports, ~161 forms, ~14k SQL queries, ~190 tables). Goal: reproduce it as a
feature-exact, multi-tenant cloud web SaaS with no Windows/hardware/offline dependency.

## Decisions
1. **Database = PostgreSQL.** Money & fine-weight columns map to `NUMERIC` (not `FLOAT`).
   Documented precision: amounts 2dp, weights 3dp, fine 3–4dp. SQL Server `FLOAT` parity
   risk is mitigated by decimal arithmetic + the Tier-4 parity harness.
2. **Reports = data-parity, HTML→PDF.** Reproduce each `.rpt` dataset (same fields/rows) and
   render via Playwright headless-Chromium. No Crystal/.NET/Windows runtime. Layout is
   faithful-approximate, not pixel-identical.
3. **Sequencing = audit-first.** Phase 0 (Tasks 1–5) is a HARD GATE: prove `unified/` is
   complete and catalog the data model + per-form logic before any web code.
4. **Target = multi-tenant cloud SaaS replacing the desktop.** Next.js (frontend) +
   Node/NestJS (backend) + PostgreSQL. Shared DB + shared schema + Row-Level Security;
   `tenant_id` outermost; original composite keys (CO_CODE, LC_CODE, CO_YEAR, CO_BOOK,
   VCH_NO, SR_NO) preserved. Yearly SQL Server DBs consolidated into one schema with
   `CO_YEAR` as a column.
5. **Golden master = `DataCareNext.exe` (Jun 2026)** (superset); `NextDm` is secondary.
6. **Security upgrades:** Argon2 password hashing (desktop likely plaintext) with forced
   reset on migration; JWT httpOnly + refresh; RBAC from USER rights; audit log.

## Consequences
- Strong parity guarantee via golden-master diffing; some report layouts approximated.
- Proprietary DevExpress/Crystal DLLs are NOT used in the web app (kept in `unified/` only
   for desktop reference and audit).
- WhatsApp moves from Selenium automation to the official WhatsApp Business/Cloud API.
