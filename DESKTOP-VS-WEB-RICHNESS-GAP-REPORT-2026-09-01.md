# Desktop vs web richness gap report

Date: 2026-09-01
Scope: `DataCareNext.exe` (desktop, authoritative) vs the web implementation in `web/`
Question answered: *where exactly is the web thinner than the desktop, and by how much?*

Everything below is measured from source, not estimated. The four extractors and their
outputs are committed so any number here can be recomputed:

| Script | Output |
| --- | --- |
| `project-memory/parity/richness_desktop.py` | `DESKTOP-RICHNESS.json`, `DESKTOP-RICHNESS-NEXTDM.json` |
| `project-memory/parity/richness_web.py` | `WEB-RICHNESS.json` |
| `project-memory/parity/richness_join.py` | `RICHNESS-JOIN.json` |
| `project-memory/parity/settings_parity.py` | `SETTINGS-PARITY.json` |
| `project-memory/parity/settings_effect.py` | `SETTINGS-EFFECT.json` |

---

## 1. The headline

**The web is at roughly one third of the desktop's operator-facing depth, while being at
~99% of its database-write depth.** Those two facts are both true, and the difference
between them is the whole story.

| Dimension | Desktop | Web | Web / desktop |
| --- | ---: | ---: | ---: |
| Forms / pages | 204 | 101 | 49.5% |
| Input controls | 1,599 | 976 | 61.0% |
| **Visible grid columns** | **3,508** | **755** | **21.5%** |
| **Operator field surface** (inputs + grid columns) | **5,107** | **1,731** | **33.9%** |
| Distinct validation messages | 631 | 596 | 94.5% |
| Confirmation prompts | 285 | 216 | 75.8% |
| Event handlers | 5,838 | — (see §6) | — |
| Grid cell events (EnterCell/LeaveCell/RowColChange) | 416 | — (see §6) | — |
| SQL statements | 14,905 | 1,183 | 7.9% |
| UI source lines | 969,133 | 32,852 | 3.4% |

### Why previous audits reported near-parity

`project-memory/parity/DEPTH-SCOREBOARD.md` reports **98.9% column coverage** (3,669
desktop written columns vs 3,627 web). That number is correct *for what it measures*:
whether the web ever writes each database column. It does not measure whether an operator
can reach that column.

The same table already contained the counter-evidence, in a column labelled a "lower
bound" and explicitly de-prioritised: grid coverage of **TR_PURC 14.5%, TR_SALE_RTN 9.1%,
TR_TAG_SPLIT 5.1%, TR_BUL_BOOKING 0.0%**. That was the real signal.

**The gap is not in the database layer, and mostly not in the API layer. It is in the
screens.** The recurring pattern, found independently in every module reviewed: the API
accepts rich desktop-shaped input, and the page collects a fraction of it. Example: the
purchase API declares `stones?: PurchaseStoneInput[]` (`purchase.ts:133`) and persists it
(`:953`); `txn/purchase/page.tsx` contains **zero** occurrences of `stones`. The capability
exists and is unreachable.

---

## 2. Settings

Measured because it was the first thing raised, and it is measurably thin.

| | Count |
| --- | ---: |
| Desktop settings columns (`CO_SET` 58, `CO_SET_NEW` 70, `CO_MAST` 38, `TAG_SET` 8) | 174 |
| Desktop config globals actually read at point of use | 290 |
| Web settings inventory (`settingsInventory.ts`, from `information_schema`) | 130 |
| Web settings read by business logic | 55 |
| **Web settings that are editable, persisted, and read by nothing** | **74** |
| ...of those, settings the **desktop does** branch on | **66** |
| ...dead on both sides (correctly ignored) | 8 |

The web's own behaviour contract, `shared/settingsBehavior.ts`, is honest about its size:
39 typed fields covering 36 real `CO_SET` keys.

A measurement warning worth recording: counting "the key appears in some source file" gives
a false **127 / 130**. Seven files list setting *names as data* — `companyClone.ts`,
`companySettings.ts` (`CO_SET_NEW_COLUMNS`), `generated-formfields.ts`, `configs.ts`,
`desktopColumnDefaults.ts`, `seedCompany.ts`, `bundleDiff.ts`. Five keys (`LBR_TYPE`,
`TAX_CODE`, `FX_RATE`, `LOCK_DATE`, `CO_CODE`) are also transaction column names. After
excluding manifests, the honest figure is 55.

### The 50 business-behaviour settings the web ignores

Format: `SETTING` → number of desktop forms that branch on it.

`BRANCH_ALL_AC_SHOW` 68, `EMP_AS_USER` 57, `VCH_DESC_HELP_LENT` 41, `COUNTRY_ID` 35,
`PURC_WITH_HMTAX` 31, `SALES_WITH_HMTAX` 28, `DUP_PRINT` 23, `ESTMATE_BANK_LOCK` 23,
`LBR_WITH_GHT` 23, `DESIGN_HELP` 13, `SILVER_THREE_DIGIT` 11, `SL_NWT_LOCK` 11,
`ITM_WITH_LOT_STK` 10, `NEGATIVE_STK_SALE` 7, `OS_BILL_SMS` 7, `QR_CODE_GEN` 7,
`PURC_LOT` 6, `OLD_PURC_TOUCH` 5, `STK_LMIT_WITH_DESIGN` 5, `MOBILE_HELP` 4,
`TAG_VCH_AUTO_SAVE` 4, `WH_BILL_IMG` 4, `CUR_DAY_POSTING` 3, `ESTMATE_TAX` 3,
`F_DISC_DATE` 3, `ITM_FINE_LOCK` 3, `KR_DESIGN_IMG_PRINT` 3, `ORD_IMG_PRINT` 3,
`ORD_TAG_STK_LESS` 3, `OTH_ITM_WT_REMOVE` 3, `PR_TDS_TAX` 3, `SL_BILL_IMG` 3,
`TAG_ENTRY_DESIGN_GEN` 3, `T_DISC_DATE` 3, `USER_KR_TOUCH_HIDE` 3, `WAPP_SL_PRINT` 3,
`APR_IMG_PRINT` 2, `DEFAULT_REMINDER` 2, `DHRN_IMG_PRINT` 2, `SL_MRP_TAX_REVERC` 2,
`SL_TAG_WT_DIFF` 2, `TAG_AUTO_PRINT` 2, `TOT_FINE_STK_TYPE` 2, `WAPP_IMG_GWT` 2,
`OLD_GOLD_TYPE` 1, `OS_FINE_INT` 1, `RATE_MAST_OPEN` 1, `REMINDER_OPEN` 1,
`YEAR_GOLD_SL` 1, `YEAR_SILVER_SL` 1.

Plus 15 UI-preference settings, led by `THEME` (152 desktop forms), `MAIN_FONT_CHANGE`
(125), `FONT_CHANGE` (71), `FONT_NAME`/`FONT_SIZE`/`FONT_STYLE_TYPE` (69 each),
`GRID_ROW_HIGHT` (68), `GRID_SCROLL` (60).

These are not cosmetic omissions in aggregate. `NEGATIVE_STK_SALE` decides whether a sale
can go below stock. `SL_NWT_LOCK` decides whether an operator may retype net weight.
`PURC_WITH_HMTAX` / `SALES_WITH_HMTAX` decide whether hallmark tax applies at all — the
web currently computes hallmark GST whenever an amount is supplied
(`purchase.ts:678-683`, `sales.ts:753-758`), with no way to switch the policy off.

Also unsurfaced entirely: **`CO_MAST` (38 columns)** and **`TAG_SET` (8 columns)** are not
part of the web settings surface.

---

## 3. The structural cause

Depth grouped by how each desktop form was mapped to the web:

| Mapping | Forms | Desktop surface | Web surface | Ratio |
| --- | ---: | ---: | ---: | ---: |
| dedicated web screen | 45 | 2,521 | 1,095 | 43.4% |
| folded into a shared variant | 38 | 1,730 | 766 | 44.3% |
| generic report engine | 34 | 267 | 30 | 11.2% |
| generic CRUD scaffold | 15 | 220 | 25 | 11.4% |
| waived / documented | 3 | 190 | 0 | 0% |
| headless engine, no screen | 6 | 95 | 5 | 5.3% |
| generic report scaffold | 11 | 83 | 0 | 0% |

Two findings here.

**Only 48 of 204 desktop forms received a dedicated web screen.** The rest were folded
into shared variants (38) or replaced by generic scaffolds (60+). Genericisation is a
legitimate strategy, but it caps expressible depth: a single-table CRUD page cannot render
`MS_DESIGN_BOOK`, which has three grids and 59 named columns (web surface: 6 fields, 9.4%).

**Even the dedicated screens only reach 43.4%,** and their grid columns reach just
**401 / 1,997 = 20%**. So this is not only a coverage problem to be fixed by adding
pages — the pages that exist are themselves shallow.

---

## 4. Depth by module

| Module | Forms | Desktop surface | Web surface | Ratio |
| --- | ---: | ---: | ---: | ---: |
| statutory | 1 | 9 | 0 | 0% |
| manufacturing | 9 | 598 | 151 | 25.3% |
| tag / stock | 4 | 527 | 101 | 19.2% |
| membership | 2 | 50 | 10 | 20.0% |
| sales | 9 | 1,055 | 283 | 26.8% |
| masters | 31 | 505 | 136 | 26.9% |
| bullion | 3 | 179 | 67 | 37.4% |
| dhiran | 3 | 114 | 52 | 45.6% |
| purchase | 2 | 293 | 137 | 46.8% |
| other | 84 | 1,631 | 864 | 53.0% |
| finance | 5 | 146 | 120 | 82.2% |

Finance is close to parity. Manufacturing, tag/stock, sales and masters are where the
product feels thin, and the measurement agrees with that perception.

### Worst individual forms

| Desktop form | Desktop fields | Web fields | Ratio | Desktop grids |
| --- | ---: | ---: | ---: | --- |
| `TR_TAG_SPLIT` | 211 | 24 | 11.4% | 7 grids, 184 named / 234 declared cols |
| `TR_SALE_ORD` | 112 | 9* | 8.0% | 6 grids, 91 / 136 |
| `MS_DESIGN_BOOK` | 64 | 6 | 9.4% | 3 grids, 59 / 76 |
| `TR_SALE_LBR` | 121 | 22 | 18.2% | 8 grids, 100 / 144 |
| `TR_TAG_OPBL` | 122 | 23 | 18.9% | 3 grids, 104 / 153 |
| `TR_WH_SALE` | 170 | 33 | 19.4% | 6 grids, 129 / 180 |
| `TR_SALE_RTN` | 137 | 27 | 19.7% | 7 grids, 125 / 173 |
| `TR_TAG_WT_DIFF` | 124 | 26 | 21.0% | 6 grids, 103 / 130 |
| `TR_PURC_HM` | 110 | 25 | 22.7% | 4 grids, 89 / 123 |
| `TR_WH_SALE_RTN` | 114 | 31 | 27.2% | 4 grids, 96 / 141 |
| `TR_BUL_SALE` | 120 | 34 | 28.3% | 5 grids, 93 / 137 |
| `TR_SALE_HM` | 120 | 36 | 30.0% | 7 grids, 95 / 150 |
| `TR_TOUR_SALE` | 156 | 68 | 43.6% | 6 grids, 122 / 166 |
| `TR_PURC` | 183 | 82 | 44.8% | 7 grids, 153 / 222 |
| `TR_SALE` | 140 | 68* | 48.6% | 8 grids, 109 / 179 |

\* `TR_SALE_ORD` and `TR_SALE` are understated by the automated count: both pages have
large `<details>`-hidden extended modes. Manual review found sales-order at ~103 operator
fields and sales at ~133 (51 of them extended). The other rows were manually confirmed.

**Desktop forms with no web mapping at all:** `TR_PR_SL_UAE` (95 fields),
`TR_SALE_RTN_UAE` (94), `MS_HELP`, `UT_PWD_UPDATE`.

**A second desktop binary is outside the parity scope entirely:** `NextDm.exe`
(199 decompiled forms, 991,061 LOC, 3,420 named grid columns). No web parity work
addresses it. If it is a shipped product surface, the true denominator is larger than
anything in this report.

---

## 5. Workflows implemented but switched off in production

This is the finding most likely to explain a "feels incomplete" impression that field
counts alone cannot.

`web/packages/core/containment.mjs` defines a fail-closed registry with, in its own words,
"intentionally no environment override":

```
logical-restore, production-cutover-load, tag-opening-update,
tag-transfer, tag-cancel, tag-weight-difference, tag-split
```

Enforced by `containMutation()` at ten live mutation routes in
`apps/api/src/routes/txn.ts` — lines 2914, 3187, 3318, 3326, 3353, 3366, 3386, 3393,
4838, 4851 — each returning **503 PARITY_CONTAINMENT**.

Consequence: **five tag/stock workflows have pages, API modules and tests, and cannot be
used.** Tag split, tag transfer, tag cancel, tag weight-difference, and tag-opening
*update* (create works; editing an existing tag opening does not). The stated reasons are
sound — unproved weight conservation, missing child serial identity, missing `BAR_DETL`
lineage — but from an operator's seat these are simply absent features.

---

## 6. Cross-cutting capability verdicts

| Capability | Verdict | Evidence |
| --- | --- | --- |
| Global function keys | partial | `GlobalFormKeys` **is** mounted app-wide (`app/(app)/layout.tsx:54`) implementing F2,F3,F4,F5,F7,F8,F9,F11,F12. Desktop defines 11 (`MDI_FORM.cs:5571-5601`); **F6 Wholesale Sales and F10 Reminder are missing**. |
| In-grid keyboard navigation | partial | `GridKeyboard` supports arrows / Enter-advance / Ctrl+D, but is mounted on only 14 of 101 pages (15 counting composition). Desktop is keyboard-first across all 204 forms. |
| Per-cell recalculation | partial | Desktop has **416** `EnterCell`/`LeaveCell`/`RowColChange` handlers driving weight→purity→fine→amount→tax→total chains (`TR_SALE.cs:9400-9522`). Web recomputes on selected pages via ad-hoc previews; there is no shared leave-cell contract, and no page recomputes on wastage / ghat / rate-type change. |
| Row-selection side effects | absent | Desktop `RowColChange` syncs row remarks, HUID 2-4, filters component rows and loads images across 7 sales-family forms. `GridKeyboard` has no row-change callback. |
| Master lookup pickers | partial | `LookupPicker` is a faithful F1 picker on 59 pages (65 by composition) vs **944** `MS_HELP.ShowDialog` call sites across 134 desktop files. Field-specific query/filter/autofill variants are per-page work that mostly has not happened. |
| Printing | partial | Web has real PDF rendering and genuine tag/barcode labels. **254 of 255** Crystal layouts are extracted (only `TagStkIdtlRpt.rpt` missing). But `DUP_PRINT` is inert: `VoucherChrome` can render a copy selector, no page supplies `printCopies`, and sales hard-codes `copy=O`. Bill-image invoice layouts are unwired. |
| Messaging / devices | partial | SMS + Meta WhatsApp senders, WebSerial scale capture (a faithful port of the desktop CH340 profile), camera capture and QR/barcode generation all genuinely exist. But scale capture is mounted on **one** page, and there is no transaction-completion messaging hook equivalent to `TR_SALE.cs:16619-16657`. |
| Multi-branch account visibility | absent | Location scoping and switching are solid. `BRANCH_ALL_AC_SHOW` — read by 68 desktop forms to widen account lookups company-wide — has no runtime consumer. |
| Per-form user rights | **present** | Genuine parity. Location- and form-scoped View/Edit/Delete/Print in `rbac/formRights.ts` + `authorization.ts` + the admin matrix page. Not a gap. |
| Voucher lifecycle | partial | Reopen/edit/delete and desktop-shaped delete audit rows exist; `postVoucherTx` is atomically safer than the desktop. Two real differences: `USER_REQUEST` reasons are stored but never consulted by delete routes, and the desktop's separate save-then-effect state is collapsed. (Note: desktop direct delete does **not** require a reason — that is the separate `UT_USER_REQUEST` form. Do not report it as a missing reason prompt.) |
| Reports | partial | 44 desktop report screens (`RP_ALL` is a 72-button launcher, so 45 files → 44 screens) vs 44 web slugs. But only **26** desktop screens have a defensible equivalent; **18** have none. |

---

## 7. Confirmed gap inventory: 138

Every item below was confirmed against desktop `file:line` **and** a check of the web side.
Items where the web genuinely covers the desktop behaviour were discarded rather than
padded.

| Area | Gaps | Dominant theme |
| --- | ---: | --- |
| Manufacturing / karigar / jobwork | 36 | Lot workflow has no route at all; every `*_IDTL` component grid absent; typed labour never derived; tender settlement unreachable |
| Masters & reports | 33 | 18 report workflows missing; generic scaffold cannot express child grids; `DESIGN_IDTL` never saved; report parameters (interest %, detail/summary, stock basis, GST section) absent |
| Sales family | 31 | Component/stone subdetail absent in all 7 forms; UPI identity rows; approval→sale and quotation→sale imports; wholesale bulk wastage; voucher transfer |
| Purchase / bullion / finance / dhiran / membership | 16 | Rate-cut receive side and booking draw-down; hallmark purchase is a façade; dhiran auto-interest bypassed by the form; UPI split rows |
| Tag / stock | 15 | Five workflows contained (§5); both component grids absent; primary HUID, bag weight and karigar ghat missing from split/weight-diff |
| Cross-cutting | 7 | §6 |

### Ten highest-impact individual items

1. **Lot-based manufacturing has no web route.** `TR_MFG_WITH_LOT` (60 fields, 4 grids);
   `mfgLotBalance` exists in `mfg.ts:974-1001` but is registered on no HTTP route.
2. **Stone / diamond subdetail is absent product-wide.** Every transaction family has a
   `*_IDTL` grid on the desktop (purchase 34 + 25 cols, sales 24, returns 24 + 24,
   tag-split 32 + 32, wholesale 31). The web renders none of them, though several APIs
   accept the data.
3. **Five tag workflows return 503.** §5.
4. **74 settings do nothing; 66 of them do something on the desktop.** §2.
5. **Rate-cut has no receive side.** `TR_BUL_SALE`'s 50-column `MSG_PR` has no web
   equivalent, and `rateCut.ts:1078` never writes `RATE_CUT_REC`.
6. **Bullion booking draw-down is not reversed.** Desktop maintains `BUL_DATA.ADJ_WT` on
   save/edit/delete (`TR_BUL_SALE.cs:8816-8818`); the web contains no `UPDATE BUL_DATA`,
   so booking availability can silently drift.
7. **Dhiran auto-interest is implemented and bypassed.** The API computes interest only
   when the field is omitted (`dhrn.ts:564-566`), but both pages always send
   `interest: Number(interest || 0)` — so blank means explicit zero.
8. **Jobwork labour is never derived.** `KarigarForm.tsx:242` always sends a numeric
   `lbrAmt` including zero, which `mfg.ts:448-458` treats as an override, so
   `lbrType`/`lbrRate` never take effect.
9. **Karigar issue loses wastage.** Desktop issue fine is
   `((Net+Ghat)×(Touch+West)/100) − LessWt`; issue-mode payload omits `westPct`.
10. **18 report workflows missing**, including `RP_PHY_STOCK`, `RP_STK_LEVEL`,
    `RP_STOCK_FINE`, `RP_REMINDER`, `RP_MFG`/`RP_MFG_ZOOM`, `RP_DAY_WORK`,
    `RP_BILL_PROFIT`, `RP_ORD_TRACK`.

---

## 8. What closing the gap requires

Ordered by operator impact per unit of work, not by size.

**Tier 1 — makes existing investment usable.** Mostly wiring; the backend already exists.

1. Wire pages to the input the API already accepts: purchase `stones`, tour `stones`,
   wholesale-return settlement, scheme multi-line + UPI rows, dhiran `items`, tag-cancel
   lineage. Recurring shape: add the fields, stop sending zero-defaults that suppress
   server derivation.
2. Fix the three suppression bugs that silently disable working server logic — dhiran
   `interest`, jobwork `lbrAmt`, karigar `westPct`. Small changes, wrong numbers today.
3. Honour or delete the 74 inert settings. Every one is a promise the UI makes and the
   engine ignores. Start with `NEGATIVE_STK_SALE`, `SL_NWT_LOCK`, `PURC_WITH_HMTAX`,
   `SALES_WITH_HMTAX`, `ESTMATE_BANK_LOCK`, `LBR_WITH_GHT`, `DUP_PRINT`.
4. Add F6 and F10; mount `GridKeyboard` on all transaction pages.

**Tier 2 — closes real capability holes.**

5. Discharge the containment exit gates for the five tag workflows (child serial identity,
   `BAR_DETL` lineage, weight conservation proof), or state publicly that they are out of
   scope. Leaving them coded-but-503 is the worst of both.
6. Build a reusable subdetail-grid component and adopt it across the transaction families.
   One component unlocks the single largest gap class in the report.
7. Introduce a shared per-cell recalculation contract so wastage / ghat / rate-type edits
   update totals everywhere, instead of per-page previews with divergent formulas.
8. Lot-based manufacturing: page + route + the existing `mfgLotBalance`.

**Tier 3 — breadth.**

9. The 18 missing report workflows, and report parameter richness on the generic engine.
10. Extend the master scaffold to express child grids and conditional validation, or give
    `MS_DESIGN_BOOK`-class forms dedicated screens.
11. Decide on `TR_PR_SL_UAE` / `TR_SALE_RTN_UAE` and on `NextDm.exe`: in scope or waived.

**Measurement hygiene.** `DEPTH-SCOREBOARD.md` should stop presenting 98.9% column
coverage as the headline parity figure without the 33.9% operator-surface figure beside it.
One number describes the database; the other describes the product. Publishing only the
first is how a 34%-depth application came to be recorded as near-complete.

---

## 9. Honest limits of this measurement

- Grid column counts come from `<grid>.Cols = N` and `<grid>[0, N] = "Header"` in
  decompiled C#. Named headers (3,508) are the operator-visible figure; declared columns
  (5,243) include hidden state columns. Named is the fair comparison and is what §1 uses.
- Web field counts follow relative `.tsx` imports to depth 3, because six txn pages are
  5-line wrappers around shared components and would otherwise score zero. Global totals
  de-duplicate across 128 distinct files so shared components are not counted per page.
- Two web pages hide large extended modes behind `<details>`; the automated count
  understates `TR_SALE` and `TR_SALE_ORD`. Both were corrected by manual review and are
  flagged in §4.
- "Settings honoured" excludes seven manifest files by name. That exclusion list is in
  `settings_parity.py` and is the difference between a false 127/130 and the honest 55/130.
- Event-handler and SQL counts are not directly comparable across a WinForms and a
  React/Fastify codebase; they are reported as evidence of interaction density, not as a
  parity ratio. This is why §1 leaves the web cells blank rather than inventing a number.
- `NextDm.exe` is measured but excluded from every ratio, since no web parity work targets
  it.
