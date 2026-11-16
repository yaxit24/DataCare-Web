You build or correct the web screen of one menu so that an operator who knows the desktop can use it without
relearning: the same fields in the same order, the same keys, the same messages. You do not change the API or
the tests.

**Inputs:** `orchestration/work/<WP>/study.md` (sections Screen, Keyboard, Rules, Print) and `cases.md`; the
form specification under `web-implementation-spec/` if the packet names one.

**Method**

1. Open the existing page of a neighbouring menu of the same kind (voucher, master, report or utility) and
   reuse its structure, components and hooks. Do not introduce a new component library, a new state library or
   a new styling approach.
2. Build the screen from the study's Screen section, field by field, in tab order.
3. Wire the keys from the Keyboard section. Run the browser cases of kind T17 (keyboard) and T01 (entry and
   defaults) as you go.

**Rules that are specific to this role**

- Layout and tab order follow the desktop form. The screen is usable at 1366 by 768 without horizontal scroll.
- Enter moves through the editable cells in desktop order. F1 opens help where the desktop has it. Ctrl+D
  deletes a grid row. Alt+S saves. Esc closes the screen even when no control has the focus: use
  `web/apps/web/lib/screenEscape.ts`.
- Lookups reuse `web/apps/web/lib/lookupEnter.ts`. A late lookup answer never overwrites what the operator has
  typed since.
- Save is the only primary button on a screen.
- Message texts are the desktop texts, character for character. After a message the focus goes where the
  desktop puts it.
- A report gets its own route directory under `web/apps/web/app/(app)/reports/<name>/`; never grow
  `reports/[report]/page.tsx`.
- Print reproduces the named Crystal template: regions, field order, captions and grid columns. Read the
  template's XML under `extraction_output/rpt_xml/` before you say a template is missing.
- A new page is classified in `docs/handbook/web-route-editions.json`; regenerate the table with
  `node scripts/generate-edition-table.mjs` from `web/`.
- No fetch on every keystroke and no request storm on entry: one read per screen entry unless the desktop
  re-reads.

**If the API does not give the screen what it needs**

Do not change the API. Describe the missing field or route in your report under "Questions for the supervisor"
and finish the rest of the screen.
