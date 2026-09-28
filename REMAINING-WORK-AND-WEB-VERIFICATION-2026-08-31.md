# Remaining work to parity, and how the web gets verified — 2026-08-31

Companion to `DESKTOP-PARITY-EXECUTION-PLAN-2026-08-30.md`. Everything here is measured today.

## 1. Where parity stands

```
                     2026-08-30 baseline    now
cases                      66                70   (6 families)
cases matched               0                 0
fieldDifferences        3,787               898
agreement              83.94%            96.56%
rowsMissing               210               198
rowsExtra                 210               174
tablesDesktopOnly          53                59
```

Reproduce with `pnpm parity:measure`. **3,813 → 898 on the identical case set, a 76% reduction**, achieved in six
measured increments, each recorded in `project-memory/parity/wp-09/`.

Zero of 70 cases match. That is the honest headline: 898 field differences spread across 70 vouchers means almost
every voucher still differs somewhere.

## 2. What remains on the database dimension

### 2.1 Columns — 898 differences

| Count | Column                                       | Nature                                           |
| ----- | -------------------------------------------- | ------------------------------------------------ |
| 54    | `ROJ_MEL_DATA.IT_DESC`                       | web writes the item name, desktop the group name |
| 44    | `AC_DATA.LDR_NAME`                           | **no derivable rule** — see below                |
| 52    | `LEDR_KEY` (`ROJ_MEL_DATA` 30, `AC_DATA` 22) | constructed key; join-breaking                   |
| 26    | `PR_DATA.PARTY_FINE`                         | metal position on the header                     |
| 21    | `ROJ_MEL_DATA.LD_CODE`                       | contra account on the daybook row                |
| 20    | `ROJ_MEL_DATA.AC_NAME`                       | denormalised party name                          |
| 20    | `ROJ_MEL_DATA.ITM_AMT`                       | money on the daybook row                         |

`ROJ_MEL_DATA` and `RATE_CUT_*` now dominate. The daybook is the largest single block and the least explored.

**`AC_DATA.LDR_NAME` is deliberately unfixed.** Within purchases the desktop leaves it blank on 57 party legs and
names it on 32; contra legs blank on 43 and named on 11. No rule is derivable from the captured data. The web
writes blank, which matches 162 of 208 rows; any rule I could justify today would match fewer. It needs either a
wider capture or the desktop form's own source.

### 2.2 Rows — 198 missing, 174 extra

| Missing | Table          |     | Extra | Table          |
| ------- | -------------- | --- | ----- | -------------- |
| 79      | `ROJ_MEL_DATA` |     | 78    | `LOT_DETL`     |
| 28      | `AC_DATA`      |     | 53    | `ROJ_MEL_DATA` |
| 22      | `MAIN_STOCK`   |     | 11    | `AC_DATA`      |
| 20      | `PR_IDTL`      |     | 9     | `PAY_DETL`     |

No column fix touches these. `ROJ_MEL_DATA` appears on both sides — the web writes daybook rows the desktop does
not and omits others it does, which means the projection rule differs, not just its values.

`LOT_DETL`'s 78 extra rows are **unresolved on purpose**: `Ac_Stock.cs` filters its `LOT_DETL` insert only on
`MAIN_BOOK IN ('PURCHASE','B2B PURC')` with no lot-number condition, so the source says every purchase line; the
captured data has none. The likely reconciliation is that `PrKr_Lot` is a separate posting pass, but there is no
evidence here to settle it, and guessing would either invent lot rows or suppress real ones.

### 2.3 Coverage of the oracle itself

70 cases across **6 of 61** transaction families. `TR_SALE` has one case; `TR_PURC` has 51. Fifty-five families
have none. Everything beyond the six needs a desktop capture, which is not reachable from this environment.

## 3. What remains on the web dimension — and what verification exists

This is the part with the least coverage, measured today.

### 3.1 The surface

|                       | Count                                                      |
| --------------------- | ---------------------------------------------------------- |
| Pages                 | 101 (99 distinct routes after sampling 2 dynamic segments) |
| Components            | 22                                                         |
| Web unit tests        | **23** across 4 files                                      |
| Browser scenario test | 1 (`browser.smoke.mjs`), 39 routes, 92 assertions          |
| Route reachability    | **new today**: 99/99 routes server-render                  |

The 23 unit tests cover keyboard mapping (6), grid keyboard navigation (5), master search filtering (7) and parity
containment UI (5). They are good tests. They are also the entire component-level suite for a 101-page application.

### 3.2 What the desktop expects of these screens

Across the 61 transaction forms: **5,108 grid columns, 3,612 controls, 2,933 calculation expressions, 1,091
validations, 418 keyboard handlers**. Current coverage — grid **4.5%**, controls **25.3%**, validations **61.7%** —
is from `DEEP-DEPTH-AUDIT.json`, static analysis, so it counts presence rather than correctness.

### 3.3 The honest limit of what was added today

`apps/web/test/route-coverage.mjs` (`pnpm test:routes`) enumerates routes from the filesystem — so a new page is
covered the moment it is added — and asserts each server-renders without erroring. 99/99 pass.

**It cannot detect a client-side render failure, and this was measured rather than assumed.** Injecting
`throw new Error(...)` into a client page component produced HTTP 200, no `pageerror`, and the application's own
fallback text "Cannot reach server." — which is exactly what a healthy page shows when the API is absent, because
the harness runs with `API_ORIGIN` pointed at a dead port. The two states are indistinguishable, so no assertion
in that harness can separate them.

That limitation is written into the script and printed on every run. Closing it is the first item below.

## 4. Plan for verifying the web implementation

### W1 · An API-backed browser harness — DONE, by stubbing rather than a live API

**Result: 99 of 99 routes verified to render, client-side included. Enforced in CI.**
Run with `pnpm test:routes`.

The first version could not fail, and that was established by experiment rather than assumed: injecting
`throw new Error(...)` into a client page component passed. Three separate causes, each found by probing:

1. **No session.** With no API every page showed "Cannot reach server." — identical to a page that threw. Fixed by
   stubbing `**/api/**` in the browser, the pattern `browser.smoke.mjs` already uses, which gives each page a
   session and a chosen company without needing a database.
2. **The wrong failure marker.** This app's boundary text is "Something went wrong" (`app/error.tsx`,
   `app/global-error.tsx`); the check looked only for generic Next.js strings.
3. **Reading the body too early.** `domcontentloaded` fires on the server-rendered HTML, which is healthy even when
   the client throws — the boundary replaces it only at hydration. The check was looking before the failure existed.

With all three fixed the mutation is caught, and the harness immediately flagged five more routes. Those turned out
to be **the stub's fault, not the pages'**: each fetches an endpoint that really returns an object and reads a field
of it (`.some`, `.count`, `.overdueParties`, `.map`, `Object.keys`) while the blanket fallback answered `[]`.
Blaming the pages would have been wrong, so they are listed as `NEEDS SHAPED STUB` on every run with the exact
field named. Deleting an entry after writing its stub is a real coverage gain.

_Remaining for W1:_ a live-API variant for W2's persistence assertions.

The five deferred routes were closed by shaping their stubs from the types the pages themselves declare —
`/settings` `{fields, values}`, `/reports/tag-stock` `{totals:{count,…}}`, `/reminders`
`{receivables, ordersDue, summary:{overdueParties,…}}`, the two data-repair payloads, and `/einvoice/gsp-config`
`{vars:{}}`. Coverage went 94 → 99 with no change to any page, which is the point: the pages were never at fault.

Re-verified afterwards by injecting a throw into a different page (`/txn/reminders`) — the run still fails, so full
green is not a green that cannot fail. Enforced in CI as "Route reachability (all pages render)".

### W1b · Live API, for the workflow tests

Stand up the API and a seeded database alongside the web server, so "Cannot reach server." stops being the normal
state. Then a page rendering its error fallback is a genuine failure, and route coverage becomes a real gate rather
than a server-render check.

_Exit:_ `pnpm test:routes` runs against a live API, and the client-throw mutation above fails it.

### W2 · One end-to-end workflow per family, through the UI

Not the module — the screen. Log in, choose company and book, enter a voucher in the grid, save, then assert the
**database rows** match what the parity oracle expects for that family. This is the only test that exercises the
form, the API and the posting layer together, and it is the shape of the defect the oracle keeps finding: a value
the form never sends.

Start with purchase, since its oracle result is now the strongest, then sale.

_Exit:_ per family, a UI-driven save whose rows match the module-driven replay's rows.

### W3 · Field and grid parity per form

`UI-FIELD-AUDIT.json` already captures 496 fields across 10 forms at 100% capturability, so the method works and
needs applying to the other 51 transaction forms. For each: enumerate the desktop form's controls and grid columns
from source, and assert the web form presents the same set, in the same order, with the same editability.
~4,878 grid columns are unaccounted for.

_Exit:_ a per-form report with a ratchet, so a removed field fails CI.

### W4 · Calculations in the browser

2,933 desktop calc expressions. `CALC-AUDIT.json` inventories them and 184 golden-vector cells are blank. A vector
proves the API computes correctly; it does not prove the **screen** shows the same number before saving, which is
what an operator acts on. Drive the grid, assert the displayed totals.

_Exit:_ every calc with a vector also has a UI assertion, or a recorded reason it cannot have one.

### W5 · Validations and refusals in the UI

1,091 desktop validations, 61.7% present, 28 recorded `NOT ENFORCED`. Each needs a UI test that the same bad input
is refused with a comparable message — a validation that only exists server-side still lets an operator lose work.

### W6 · Keyboard and entry flow

418 desktop key handlers; 11 web tests cover the mapping and grid navigation. At counter speed an operator enters
fifty lines a minute by keyboard; a form that is correct but mouse-only is unusable. Extend the existing
`formKeys` / `gridKeyboard` approach form by form.

### W7 · Reports

45 desktop report forms, comparison artefact currently MISSING. Same parameters, same data, identical rows, totals
and grouping — then the statutory ones signed off against real filed returns.

## 5. Sequencing, and what I would not promise

**Order:** W1 first and alone — it is small and it makes W2–W6 meaningful. Then W2 (one family end to end), which
will find the next class of defect. W3–W6 are per-form and can run in parallel across forms once W1 and W2 exist.
W7 is independent and can start any time.

**On the database side**, continue the measured increments: `ROJ_MEL_DATA` next, since it is the largest remaining
block on both columns and rows.

**What I would not promise.** The measured scope is 61 transaction forms averaging ~12,000 lines of desktop logic,
5,108 grid columns, 2,933 calculations, 1,091 validations, 45 reports, and 55 families with no test case at all.
The last increments moved field differences 76% in a session because they were systematic — one convention, one
poster, one builder. The remainder is not like that: it is per-form work, and the parts that need a desktop capture
cannot be done from here at all. Any schedule that treats the next 900 differences as another day's work is not
describing this codebase.
