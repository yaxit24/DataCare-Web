You establish exactly what the desktop does for one menu, and what the web does today. You write one document.
You change no code.

**Output:** `orchestration/work/<WP>/study.md` (the packet gives the exact path). At most 450 lines.

**Method**

1. Open the form index (`.orch/index/<FORM>.md`). Read the member list, the message texts, the captions and the
   tables. Decide which line ranges matter for the scope in your packet.
2. Read those ranges in the desktop source. Follow calls into shared code (`DC_Main`, `Ac_Ledr`, `Ac_Rojmel`,
   report classes) only as far as the scope needs; cite what you read there too.
3. Find the web side: the page under `web/apps/web/app/`, the API module under `web/apps/api/src/modules/`, its
   route file, its tests under `web/apps/api/test/`, and its browser module under
   `web/apps/web/test/features/modules/`. Search by menu caption and by desktop table name.
4. Write the document with the sections below. Every statement about the desktop has a quoted citation.

**Sections of the document, in this order**

1. `## Scope`: the menu caption, the desktop form and its line count, how the menu opens it (the dispatch in
   `MDI_FORM.cs`), which modes the Lite edition shows (`MsSoftType` checks), what is out of scope and why.
2. `## Screen`: every control the operator sees: caption, control name, type, tab order, default value, enabled
   and visible rules.
3. `## Keyboard`: every key the form handles (Enter, Esc, F-keys, Ctrl and Alt combinations) and what each does.
4. `## Rules`: every validation with its exact message text (copy the text verbatim, spelling included) and
   where the focus goes after the message.
5. `## Calculations`: every formula in the order the form applies it, with the rounding call used.
6. `## Lifecycle and write set`: for create, reopen, edit, delete and cancel: each table written, the columns
   set, the key used, and the order of statements. For a report: the selection, each filter, the grouping, the
   totals, the drill-down.
7. `## Print`: the Crystal template names, the parameters passed, and the print-rights check.
8. `## Rights`: each `USER_SET` or rights check and its message.
9. `## Desktop weaknesses not to port`: each one with its line.
10. `## Web today`: each web file that belongs to this menu and, in one line, what it does now.
11. `## Gaps`: a numbered list. Each item: what the desktop does (cited), what the web does (file and line), and
    whether it is a missing feature, a wrong result, a wrong text or a missing key.
12. `## Open questions`: only what the source does not answer.

**Quality bar**

- The citation check must pass with every citation quoted. Aim for at least one citation for every rule,
  message, formula and table write.
- Do not summarise from the method names. Open the lines.
- Do not copy more than three source lines in one quote. A quote is proof of location, not a listing.
- On a very long line (a query built by joining strings), quote the part that carries your point, for example
  the column or the condition, not the first characters of the line.
- Before you stop, run the check yourself when the tool is in this worktree:
  `node orchestration/bin/orch.mjs cite <your file> --require-snippets`.
- If the scope is too large for one document, cover the scope's first half completely, list the rest under
  "Open questions" with line ranges, and report `PARTIAL`.
