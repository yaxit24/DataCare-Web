# WP-04 completion register classification evidence

**Date:** 2026-08-30
**Plan:** `EXACT-END-TO-END-PARITY-PLAN-2026-08-29.md`
**Work package:** WP-04 — classify all 198 desktop menu entries
**Status:** implemented and validated in the current working tree; no commit created
**Claim boundary:** every entry is now classified with a machine-verified web surface or an explicit record of absence. This proves **what exists**, not that anything **matches the desktop**. The plan's no-go condition "198/198 menu entries are unclassified" is cleared; nothing else is.

## 1. Exit criterion

WP-04's criterion is `pnpm register:check --strict` passing with zero unclassified.

```
completion register: 198 desktop menu item(s)
   145  implemented-unverified
    53  absent
REGISTER_OK every entry is well-formed and honestly evidenced      (--strict, exit 0)
```

Before: 198 `unclassified`. After: 0.

## 2. The vocabulary had a hole that would have forced a lie

The register defined six states: `unclassified`, `verified`, `implemented-unverified`, `implemented-elsewhere`, `dead-in-dataset`, `scope-excluded`. **None of them can say "visible on the desktop, absent from the web."**

53 entries are exactly that. With the original vocabulary each would have had to be called implemented, implemented-elsewhere, dead in the dataset, or deliberately excluded — and three of those require evidence a classifier does not have (an owner decision; Live24 row counts). Forcing that choice is how a register starts lying, and the register is the definition of done.

So WP-04 adds `absent`, requiring a note that names the missing capability and the desktop form behind it. Per plan §11.2 an absent visible entry is a release blocker, not a softer classification.

## 3. Method

Two methods had already failed and are recorded in the gate's own source: label matching reported **165 of 198 missing**, including Sales, Purchase, Rojmel and Rate Cut, which the web demonstrably has; table-name grepping reported a hit for almost everything.

Each of the 198 entries was instead traced **desktop form → web implementation → the exact registration site**, using the route registry (`routePolicy.ts`), the dynamic master map, the canonical form catalog, the report slug map, the web navigation, and the page files. Result:

| Surface kind                                  | Entries |
| --------------------------------------------- | ------: |
| Registered API route                          |     121 |
| Dynamic master name                           |      19 |
| Next.js page                                  |       5 |
| **Total with a surface**                      | **145** |
| No defensible surface (`absent`)              |      53 |

145 entries resolve to **114 distinct surfaces**, so **52 entries share 21 surfaces**.

### States deliberately left unused, and why

- **`verified`** — zero uses. The register defines it as "compared or tested", but the plan means desktop-verified and the controlling comparison is **0 of 66 matched**. Marking entries verified from web-only tests would be precisely the self-approval this project keeps finding in its own gates.
- **`implemented-elsewhere`** — zero uses. Every mapped entry is reached through a web feature with a different name, so the label would apply to all 145 and distinguish nothing. The real signal is recorded per item as `sharedSurfaceWith` instead.
- **`scope-excluded`, `dead-in-dataset`** — zero uses. Both need evidence outside a classifier's reach: an owner decision (§8.1) and Live24 row counts.

## 4. Exit evidence

**A classification claim is now falsifiable.** `apps/api/test/completionRegister.test.ts` (11 tests) resolves every claimed surface through the *same* registry the server authorises with — `routePolicyFor`, `MASTER_FORM_BY_NAME`, `getFormEntry`, `REPORT_FORM_BY_SLUG` — or the filesystem for a page. All 145 resolve.

That check deliberately lives in the test rather than in the `.mjs` gate: a text search would report a false negative on dynamic families such as `POST /masters/:name/import`, which the resolver handles correctly, and a gate that cries wolf gets bypassed.

The tests also hold the register to the honesty rules above: zero `verified` while G5 is red, zero owner-behalf exclusions, every `absent` note naming its missing capability and desktop form, a recorded method including *what the classification does not establish*, and the `formReferencedInWeb` caveat.

**The gate itself was strengthened** with the checks an earlier audit found missing: `verified` evidence must be a real non-empty **file** (a directory or empty file previously passed), no duplicate tab/menu pair, the item list must match its own declared count, a state asserting a web equivalent must name one, and a state asserting absence must not carry one.

Commands: `--strict` exit 0; full suite **151 files / 1263 tests passing**; `tsc` clean for api source, api tests and web; `prettier --check` clean.

## 5. The finding that mattered most

Completing the classification made `register:check --strict` pass — which would have flipped WP-03's release gate to **PASS on a register that documents 53 missing features**. That is the "green means nothing objected" failure WP-03 exists to eliminate, and I had just built the gate that would have reported it.

Plan §14 is explicit: _"'Implemented-unverified' is not done."_ §11.2 requires every visible entry to be verified or mapped, with excluded and dead entries carrying an owner-signed consequence. So classification and releasability are two different bars, and the script now implements both:

| Bar                  | Asks                                  | Result today                                    |
| -------------------- | ------------------------------------- | ----------------------------------------------- |
| `--strict`           | is every entry classified?            | **PASS** — 0 unclassified                       |
| `--strict --release` | is every entry proven or decided?     | **RED** — 198 of 198 blocked: 145 unverified, 53 absent |

`RELEASE_GATES` now invokes `--strict --release`. The release certifier consequently still reports `completion-register FAILED`, but for a precise and useful reason. The no-go condition has moved from *"we do not know what is missing"* to *"we know exactly which 53 are missing and which 145 are unproven"*, and the release gate refuses on the correct one.

Release certification after this work package, for commit `41a7ba4e`:

```
passed=8 failed=3 skipped=1 missing=1     RELEASE_NOT_CERTIFIED
  completion-register    FAILED    198 of 198 cannot be released
  type-parity            SKIPPED   TYPE_PARITY_SKIP
  g5-desktop-comparison  FAILED    retained comparison reports matched:false
  report-comparison      MISSING   no artefact exists
  restore-drill          FAILED    blocked by WP-01 containment
```

## 6. What the register now tells the next work package

- **The mode risk is located.** 52 entries collapse onto 21 shared surfaces, and at least one such pair is half implemented: `ExtraTran/Other Expenses` is mapped to `POST /other-purchase` while `ExtraTran/Other Income` is `absent`. Shared surfaces are exactly where a desktop mode can go missing silently, so WP-05's contracts must resolve each shared surface mode by mode. `sharedSurfaceWith` names the siblings for every one.
- **`formReferencedInWeb` is wrong in both directions** and must not be read as state: 10 entries flagged `false` are implemented (`Master/Labour Type`, `Master/Point Mast`, `Other/Bank Reconcile`, `Other/Daily Rate`, `Other/Vch ReNumber`, `Report/Party Os`, `Report/Purc Zoom`, `Report/Sale Zoom`, `Scheme/Day Sales`, `Scheme/Memb Adjust`), and 26 flagged `true` have no implementation. The caveat now says so.
- **The 53 absences cluster**, which is how they should be scheduled rather than one at a time: 9 report-tab families (`Approval Rpt`, `Bul Report`, `Vp Report`, `Trading Report`, `Consi Report`, `Address Print`, `Old Stock`, `Final Reports`, `Gst Report`), 9 in `More` (analysis/graph/tracking reports), 5 in `Other` (export, estimate reset, tag adjust, stone carry-forward, e-Excel), 4 loan/dhiran, 3 manufacturing reports, 3 tour, 3 scheme, plus generic `Stock In`/`Stock Out` and two quotation persistence gaps.
- **Two absent entries are hidden on the desktop** (`Master/Dm Size`, `Other/E-Excel`) and therefore need an owner-signed exclusion rather than an implementation. `--release` reports them separately for exactly that reason.

## 7. What this does not establish

No mapped surface is claimed to behave like its desktop original. `implemented-unverified` means what it says. The register is now an accurate map of the territory and an accurate list of what is missing from it; the plan's §11.2 acceptance still requires contracts (WP-05), the compatibility kernel (WP-06), the voucher replay (WP-11A/B) and report comparison (WP-13) before any of these 145 can become `verified`.

## 8. Files

- `web/docs/COMPLETION-REGISTER.json` — 198 items classified; `absent` state added; `webSurface` and `sharedSurfaceWith` per item; `method` and `caveat` recorded
- `web/scripts/check-completion-register.mjs` — `absent` state, `--release` bar, plus the count/duplicate/surface/non-empty-evidence checks
- `web/apps/api/test/completionRegister.test.ts` (new) — resolves all 145 surface claims; enforces the honesty rules
- `web/apps/api/src/modules/ops/releaseCertification.ts` — register gate now `--strict --release`
