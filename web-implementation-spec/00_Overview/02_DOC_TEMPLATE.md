# DOC TEMPLATE — the depth contract

Every **per-form deep-dive** (`03_Modules/<module>/<FORM>.md`) MUST contain the sections below,
in this order. If a section is genuinely N/A for a form, keep the heading and write `N/A — <reason>`.
The goal: an implementer can build the form **without opening the desktop app or the decompiled
source**, yet every claim is traceable back to it.

A module's `README.md` is a lighter document: purpose, form inventory table, the module ER diagram,
shared logic, dependency list, and a build checklist. The heavy per-form depth lives in the form docs.

---

## Per-form deep-dive — required sections

### 0. Header block
```
Form: TR_SALE  ·  Module: Sales  ·  Type: transaction (posting)
Desktop source: unified/src/csharp/DataCareNext/TR_SALE.cs (889 KB)
Web target: apps/api/src/modules/sales/* · apps/web/app/(app)/txn/sales
Requirements: Req 9, 10, 12, 13, 14, 18  ·  Parity: 06_Parity/sales.md
Status: 📋 SPEC · 🟩 BUILT
```

### 1. Purpose & business context
2–5 sentences: what the user does on this screen and why it matters in a jeweler's workflow.
Include the voucher type/book it uses and where it sits in the day-to-day process.

### 2. UI / UX specification
- **Layout**: header panel fields, the line-item grid columns, footer/totals panel, action bar.
- **Field table**: every field — `Label | Source column | Type | Required | Default | Editable when | Lookup/validation`.
- **Grid columns**: each column with the same attributes + how a row is added (tag scan, item pick, manual).
- **Keyboard / F-keys**: desktop F-key behaviors (F2 save, F-key lookups, Enter-to-next-cell) and the web equivalent.
- **Lookups (pickers)**: which master each lookup reads, the columns shown, and the filter scope.
- **Modes**: New / Edit / View / Delete / Print and which controls are enabled in each.
- **Wireframe**: an ASCII or mermaid layout sketch of the screen.

### 3. Data model touched
- **Writes** (INSERT/UPDATE) and **Deletes/Reverses**, grouped: header table, detail table(s),
  sub-detail, ledger (`AC_DATA`), tax (`TAX_DATA`), stock (`MAIN_STOCK`/`TAG_STOCK`), ancillary.
- A **mini-ERD** (mermaid) for just this form's tables.
- Link each table to its `02_Data_Model/tables/<TABLE>.md` reference.

### 4. Business logic & calculations (with code)
- Narrate the computation pipeline (line calc → bill totals → tax split → rounding → ledger amounts).
- Include **desktop evidence** code snippets (decompiled C#, trimmed) AND the **web target** snippet
  (TypeScript from `packages/core` or the module) implementing the same rule.
- State **rounding precision** and money/weight scale explicitly (it must match desktop).
- Cover every branch: labour types, rate types, GST type, discount, round-off, advance/order adjust.

### 5. Save sequence (create / edit)
- A numbered, transactional sequence: number allocation → header → detail → sub-detail → ledger →
  stock → tax → ancillary. Note that desktop "edit" = delete-then-repost, and the web rule is an
  explicit reverse+repost **inside one DB transaction**.
- A **mermaid `sequenceDiagram`** of the save flow (UI → API → core → DB).

### 6. Delete / reverse sequence
- The exact set of tables cleaned up and the stock/tag restoration, plus the `DELETE_DATA` audit row.
- The right required (`USER_DELETE`) and what is blocked.

### 7. API contract
- Endpoints (method + path), request body (TypeScript interface), response, and error codes.
- RBAC right required per endpoint. Validation → HTTP status mapping.

### 8. Validation rules
- A table: `Rule | Condition | Desktop message | HTTP error | req:` covering all guards
  (required account, ≥1 line, tag exists & in stock, cash-limit→PAN, duplicate, referential).

### 9. Parity criteria (Definition of Done)
- The concrete checks that prove this form matches the desktop: identical persisted rows
  (header/detail/ledger/stock/tax), computed values to desktop precision, report dataset equality.
- Point to the parity fixture/script under `06_Parity/`.

### 10. Variants & edge cases
- List sibling forms that reuse this logic (e.g. labour/hallmark/order/return/wholesale sales),
  and what each changes (different book, extra columns, different posting).

### 11. Open questions / risks
- Anything not fully resolved from the decompiled source (flag for a Docker golden-master pass).

---

## Module README — required sections

1. **Purpose** — what the module covers, in business terms.
2. **Form inventory** — table: `Form | Type | Purpose | Tables | Posting? | Web status`.
3. **Module ER diagram** — mermaid, the tables this module owns/touches.
4. **Shared logic** — calculations/posting shared across the module's forms (link to engines).
5. **Dependencies** — which cross-cutting engines + other modules this needs.
6. **API surface** — the endpoints the module exposes (summary; details in form docs).
7. **Build checklist** — ordered steps to implement + the parity gate to pass.

---

## Conventions for diagrams

- **ER diagrams**: mermaid `erDiagram`. Show composite keys; mark the tenant key.
- **Sequence diagrams**: mermaid `sequenceDiagram` with participants `User`, `Web`, `API`, `Core`, `DB`.
- **State/flow**: mermaid `flowchart` or `stateDiagram-v2` for lifecycles (e.g. tag states, order→sale).
- Keep diagrams renderable (valid mermaid); prose explains anything the diagram can't.

## Conventions for code snippets

- Desktop snippets are **evidence** — trim to the relevant lines, keep the `// src: <file>#Lxxxx` tag.
- Web snippets are **the spec** — they should compile conceptually against `packages/core` types.
- Always show the money/weight scale and rounding mode in code, never leave it implicit.
