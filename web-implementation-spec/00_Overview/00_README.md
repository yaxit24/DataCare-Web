# DataCareNext → Web : Implementation Specification ("the Bible")

> **Purpose.** This documentation tree is the single, authoritative, build-ready specification
> for rebuilding the **DataCareNext** Windows desktop ERP as a **web application at exact
> functional parity**. It is written so that an AI agent (or a human team) can implement the
> web app **module by module** without ever needing to open the desktop binary — every screen,
> field, calculation, database write, validation, posting rule, report, and integration is
> documented here, traced back to the decompiled source as evidence.

---

## 1. What is being rebuilt

**DataCareNext** is a jewelry & gold-trade ERP + accounting system for the Indian market
(with a UAE variant). It runs on the Windows desktop and has these characteristics:

| Aspect | Detail |
|---|---|
| Original language | VB.NET (compiled), decompiled to C# for analysis |
| Runtime | .NET Framework 4.7.2 WinForms |
| UI toolkits | DevExpress v19.1, DevComponents DotNetBar2, MSFlexGrid (COM) |
| Reporting | SAP Crystal Reports (255 `.rpt` templates) |
| Database | Microsoft SQL Server — **per-year databases** (Next23 / Next24 / Next25 …) + a `NextImage` DB |
| Size | **204 forms**, **162 tables / 4,666 columns**, **255 reports**, ~14,000 SQL queries, ~8,300 methods |
| Domain | Sales, purchase, tagged-inventory, manufacturing/karigar job-work, gold loans (dhrn), cash/bank, double-entry accounting, GST + e-invoice, loyalty, bullion/tour, reports |

The desktop app is the **golden master**: when this spec and the desktop disagree, the desktop
behavior wins, and the discrepancy must be recorded (see `06_Parity/`).

## 2. Target web stack (locked)

| Layer | Technology | Notes |
|---|---|---|
| Frontend | **Next.js 15 / React 19** (App Router, TypeScript) | Replaces WinForms MDI shell |
| API | **Fastify** (TypeScript, Node) | RBAC-guarded JSON endpoints |
| ORM / DB | **Prisma → PostgreSQL** | Single multi-tenant DB; per-year SQL Server DBs collapse to `CO_YEAR` column scoping |
| Reports | **HTML templates → PDF (Playwright/Chromium)** | Replaces Crystal Reports |
| Auth | httpOnly cookie + JWT (jose), Argon2 password hashing | Replaces `LOGIN_MAST` plaintext |
| Monorepo | pnpm + Turborepo | `apps/{web,api}` + `packages/{core,types,db,reports}` |

Full component-by-component mapping is in **`01_Architecture/tech-stack-mapping.md`**.

## 3. How this documentation is organized

```
web-implementation-spec/
├── 00_Overview/
│   ├── 00_README.md            ← you are here
│   ├── 01_MASTER_INDEX.md      ← index of every doc + module build status
│   ├── 02_DOC_TEMPLATE.md      ← the depth contract every module doc must satisfy
│   └── 03_GLOSSARY.md          ← domain terms (fine, touch, dhrn, rojmel, karigar, …)
├── 01_Architecture/
│   ├── tech-stack-mapping.md   ← desktop component → web component
│   ├── system-architecture.md  ← request lifecycle, layering, diagrams
│   ├── multitenancy-scoping.md ← CO/LC/YEAR/BOOK scoping & RLS model
│   └── conventions.md          ← naming, money/weight types, error model
├── 02_Data_Model/
│   ├── overview.md             ← full ERD + table clusters
│   ├── erd-<cluster>.md        ← per-cluster ER diagrams (sales, purchase, …)
│   └── tables/<TABLE>.md       ← generated per-table column reference (162 tables)
├── 03_Modules/
│   └── <module>/
│       ├── README.md           ← module overview + form inventory + diagrams
│       └── <FORM>.md           ← per-form deep dive (see DOC_TEMPLATE)
├── 04_Cross_Cutting_Engines/   ← posting, calc, numbering, GST, RBAC, reporting, integrations
├── 05_Reports/                 ← report catalog + per-report field specs
├── 06_Parity/                  ← parity method + per-module acceptance criteria
└── 07_Build_Plan/              ← phased build order an AI agent executes end-to-end
```

## 4. How an AI agent should consume this

1. **Read `00_Overview/` fully** (this file + index + template + glossary).
2. **Read `01_Architecture/`** to internalize the stack mapping, scoping, and conventions.
3. **Read `02_Data_Model/overview.md`** + the table refs for the tables your module touches.
4. **Read `04_Cross_Cutting_Engines/`** — every transaction module depends on the posting,
   calc, numbering, and GST engines. Build these first.
5. **Pick a module from `07_Build_Plan/`** (it gives the dependency-ordered sequence).
6. For that module, read `03_Modules/<module>/` — implement each form per its deep-dive doc.
7. **Certify parity** using `06_Parity/` before marking the module done.

## 5. Source-evidence policy (non-negotiable)

Every behavioral claim in a module doc must cite its evidence so it can be re-verified:

- **`src:`** decompiled C# path + line range, e.g. `src/csharp/DataCareNext/TR_SALE.cs#L16332-L16386`
- **`data:`** the `data-model.json` table/column the claim relies on
- **`req:`** the matching acceptance criterion in `.kiro/specs/datacare-web-rebuild/requirements.md`
- **`web:`** the reference implementation already in `web/` (if one exists)

Decompiled source root: `../unified/src/csharp/DataCareNext/` (and `…/NextDm/` for the variant).
Reports root: `../unified/reports/*.rpt`. Data model: `../project-memory/catalogs/data-model.json`.

## 6. Status legend (used in the master index)

| Symbol | Meaning |
|---|---|
| `📋 SPEC` | Documentation status: spec written to template depth |
| `✏️ DRAFT` | Partial spec (stub / auto-extracted only) |
| `⬜ TODO` | Not yet documented |
| `🟩 BUILT` | A reference implementation exists in `web/` |
| `🟦 PARTIAL` | Reference implementation exists but incomplete vs desktop |
| `⬛ UNBUILT` | No web implementation yet |

See `00_Overview/01_MASTER_INDEX.md` for the live status of all 14 functional modules.
