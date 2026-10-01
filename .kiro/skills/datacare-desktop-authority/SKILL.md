---
name: datacare-desktop-authority
description: Establish exactly what the DataCareNext desktop does for a menu, form, calculation, posting or print, from the decompiled source, catalogs, tutorial keyframes and aggregate database facts, and write a cited authority note. Use before implementing or reviewing any behaviour change, or when asked how the desktop does something.
---

# Desktop authority

Subject: `$ARGUMENTS` (a menu caption, a form such as `TR_SALE`, or a behaviour such as "kasar on cash receipt").

The desktop is the authority for business behaviour. Cite every finding as `path:line`. Mark anything you reasoned
but did not see confirmed by a desktop row or video as *inferred*.

## 1. From the menu to the form

1. Look the menu up in `docs/handbook/menu-catalog.jsonl` (forms, mode, dispatch range, tables, web surfaces).
2. Open the dispatch range in `unified/src/csharp/DataCareNext/MDI_FORM.cs`. Note the form class, the constructor
   argument or caption that selects its mode, and the `MAIN_BOOK` passed to `CurBookHelp`
   (`unified/src/csharp/DataCareNext/DC_Main.cs:1489-1521`). Some captions choose between forms by setting or edition
   (for example `MsSalesWithHmTax`, `MsMfgWithLedger`, UAE): record every branch.
3. Captions without a menu row exist (about 60): see `docs/handbook/desktop/README.md` §4 and decision D21.

## 2. What the form does

1. `docs/master-parity-plan-2026-09-29/desktop-form-reference.json` → `sourceUnits[]` entry for the form:
   `methodAnchors` (line numbers of load, save, delete, print and event handlers), `tablesWrittenCatalog`
   (inserted, updated, deleted), `referencedReports`, `postingHelperCalls`, `gridColumnNamesCatalog`.
2. Read the form source at those anchors in `unified/src/csharp/DataCareNext/<FORM>.cs`: field validations and their
   messages, the save order, which helpers write ledger, stock, day book and tax, delete and reversal, print selection.
3. Shared engines: `Ac_Ledr.cs`, `Ac_Stock.cs`, `Ac_Rojmel.cs`, `Ac_Tax.cs`, `MS_PRINT.cs` in the same folder.
4. Catalog summaries: `project-memory/catalogs/forms/<FORM>.md` (tables and save sequence) and
   `project-memory/catalogs/form-behavior/<FORM>.behavior.json` (grid columns, inline SQL, keyboard, calculations,
   validations).
5. Settings that change the behaviour: search the form for `DC_Main.Ms` variables and map them to `CO_SET` or
   `CO_SET_NEW` columns (`project-memory/catalogs/settings-catalog.json`).
6. The NextDm variant (`unified/src/csharp_nextdm/`, if present) may differ: compare when the behaviour is
   edition-sensitive.

## 3. How the screen looks

1. The knowledge base `project-memory/video-research/_kb/KB_*.md` lists screens with fields, grids and workflow, and
   points to keyframes `project-memory/video-research/<playlist>/<video>/keyframes/kf_NNN.jpg`. Open the keyframes
   with an image reader.
2. Extracted layouts: `web/apps/api/form-specs/<FORM>.initcomp.json` and `DataCareNext.<FORM>.layout.json`
   (controls, positions, tab order).
3. Grid captions and visibility come from `COL_MAST` at run time.

## 4. Conventions in the data (aggregate queries only)

Rules already measured are in `docs/handbook/desktop/business-rules.md` and
`docs/master-parity-plan-2026-09-29/evidence/audit-2026-10-01/desktop-conventions.json`; use them first.

If a new fact is needed from the desktop SQL Server (Docker container `dc-mssql`; connection details in
`web/docs/HANDOFF.md` — never print or copy them):

- Query **aggregates only**: counts, distinct codes, lengths, column shapes, `MIN`/`MAX` of non-personal fields.
- Never select names, addresses, phone numbers, PAN, GSTIN, remarks or row dumps. One database (`Live24`) holds real
  customer data; prefer `Next24` (the seed company) for shapes.
- Never write to the desktop databases; never copy query output with personal data into the repository.
- Stop the container when finished if you started it.

## 5. Output: the authority note

```markdown
### Desktop authority — <subject>
- Dispatch: MDI_FORM.cs:<lines> → <FORM> (<mode>, MAIN_BOOK <family>); branches: …
- Load / save / delete / print: <FORM>.cs:<lines> each
- Writes: <TABLE> (insert/update/delete) … ; helpers: Ac_Ledr.<method> (<file>:<line>) …
- Calculations: <formula> with rounding <rule> at <stage> (<file>:<line>)
- Validations: "<message>" when <condition> (<file>:<line>)
- Settings: <CO_SET column> → <effect> (<file>:<line>)
- Print: PRINT_MAST lookup <file>:<line>; template <name>.rpt; copies …
- Screen: KB_<file>.md §<section>, keyframe <path>; layout <form-spec>
- Data facts: <aggregate result> (query described, no personal data)
- Inferred / unconfirmed: …
```

Put the note in the pull request description or the slice's evidence, not in a new top-level document.
