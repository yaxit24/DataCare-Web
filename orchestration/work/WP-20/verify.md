# WP-20 verify — Ledger Report fine prints and Lite ageing

Lead session, 2026-11-23. Branch `agent/wp20-ledger-residuals`. Scope of this pull request: the JmaUdr, Gold and Silver
prints of the detail drill-down (Gaps 5, 6, 8 for those three buttons, Gap 9) and the Lite/Basic ageing gate (Gap 10).
The OP_LDR ageing union (Gaps 1-4), In Out / Ac Sale, the summary Hz choice, the voucher-wise summaries (Gap 7),
the opening zoom (Gap 12) and the half-month toggle (Gap 11) are **not** in this pull request.

Build: `pnpm --filter @datacare/db db:generate && pnpm --filter "@datacare/api..." run build && API_ORIGIN=http://127.0.0.1:4710 pnpm --filter "@datacare/web..." run build`.
Run: `PARITY_TEST_PORT=55710 PARITY_API_PORT=4710 PARITY_WEB_PORT=4711 FEATURE_E2E_MODULES=account-ledger node scripts/parity-test-env.mjs -- node apps/web/test/features/run-features.mjs`
→ `FEATURE_E2E_PASSED`, `test-results/feature-e2e/account-ledger/run.json`: 25 cases, 17 applicable, 17 passed, 8 not applicable.
DB and unit tests (slot 55712): `ledgerFinePrints.db.test.ts`, `ledgerFinePrints.test.ts`, `accountLedgerReport*.test.ts`,
`editionGate.test.ts`, `liteEditionCalls.test.ts`: 6 files, 55 tests, all pass.

## Coverage

- Cases executed of applicable (cases.md, 58 cases, 2 blocked): 26 of 56 covered by an executed test (19 executable
  cases plus the 7 reused not-applicable groups); 30 executable cases remain open (listed under Verdict).
- Cases passed of executed: 26 of 26 (browser module 17 of 17 applicable; API 20 of 20 in the fine-print DB file).
- Desktop-match coverage: 0 (no desktop oracle run; D16 blocked).

## Case table

| id | kind | result | note |
|---|---|---|---|
| account-ledger.entry.defaults | browser | pass | reused |
| account-ledger.entry.print-buttons-drill-only | browser | pass | Gold, Silver, JmaUdr; In Out is not built (no route), so its part is open |
| account-ledger.filter.account-lookup | browser | pass | reused |
| account-ledger.drill.detail-children | browser | pass | reused |
| account-ledger.refuse.print-rights-gold | browser | pass | also Silver and JmaUdr; exact text "You Have No Print Rights....." |
| account-ledger.refuse.print-rights-others | browser + API | partial | Silver and JmaUdr pass; In Out and the summary Print right are not covered |
| account-ledger.refuse.no-user-set-row | API | pass | |
| account-ledger.refuse.lc-code-empty | API | pass | see deviation 3 |
| account-ledger.scope.rights | browser | pass | reused |
| account-ledger.scope.print-route-rights | API | pass | every export, other tenant never printed |
| account-ledger.config.lite-ageing-hidden | browser + API | pass | page drops Debit Ageing for L, B and the ungated Lite default; API 403 for L and B |
| account-ledger.output.exports | browser | pass | reused |
| account-ledger.output.gold-figures | browser + API | pass | both layouts carry OpBal 1.500, ClBal 3.000, OpAmtBal 100.00, ClAmtBal 120.00 |
| account-ledger.output.gold-rows | API | pass | MAIN_STOCK, PR_DETL purchase, RATE_CUT_ISU and FINE JV rows asserted; MFG and registration-gated sources excluded (deviation 1) |
| account-ledger.output.silver-print | browser + API | pass | OpBal 2.260 / ClBal 1.260; priced silver sale excluded |
| account-ledger.output.jmaudr-print | browser + API | pass | JmUdAmt, OpBal 100.00, ClBal 120.00, AC_DATA legs as rows |
| account-ledger.keyboard.enter-esc | browser | pass | reused |
| account-ledger.keyboard.print-hotkeys | browser | partial | Alt+J, Alt+G, Alt+S pass; Alt+I (In Out) not built |
| account-ledger.journey.summary-to-detail | browser | pass | reused |
| T07-T10, T12-T14 not-applicable groups | n/a | n/a | unchanged; nothing is written (D5) |
| account-ledger.journey.desktop-comparison | — | blocked | D16 |
| account-ledger.output.voucher-wise-row-shapes | — | blocked | D6 |
| every other case of cases.md | — | not run | not built in this pull request (Verdict) |

## The two locked tests the implement worker disputed

1. `ledgerFinePrints.db.test.ts` "silver-print" expected the priced silver sale (ITM_AMT 250, fine 3.5) to print. The
   desktop selects silver stock only with a zero amount: `RP_LEDR.cs:8900 {{AND ITM_AMT = 0 AND ITM_FINE <> 0 AND B.IT_TYPE = 'S' AND A.SR_NO <> 7 AND BOOK_NAME IN ('SALES ORDER','SALES','WH SALES','RATE CUT','KARIGAR ISSUE')}}`,
   inside `RP_LEDR.cs:8871 {{private void BtnSilver_Click(object sender, EventArgs e)}}`. The test was wrong. Fixed
   without weakening it: the priced row now has fine 4.75 and must **not** print, and a zero-amount silver sale of 3.5
   must print.
2. "registers the three fine-print data routes" searched `app.printRoutes()` text, which Fastify prints as a
   compressed radix tree that splits paths. The test was wrong about the tool, not the desktop; it now asks the router
   (`app.hasRoute`) for each of the nine paths. No assertion was dropped.

## Review of the implementation (money and weight)

Findings fixed in this pull request:

- The Gold and Silver prints read only MAIN_STOCK plus money legs; the desktop fills FINE_DATA from 26 (Gold) and 17
  (Silver) sources (`RP_LEDR.cs:8256-8319`, `:8900-8934`). `ledgerFineSources.ts` now runs each source as one arm of a
  read-only UNION ALL, then applies the Crystal selection (`RP_LEDR.cs:8343`): account, dates, location, data type
  only for A or B (`RP_LEDR.cs:8348`).
- The metal-leg money arm credits only issues and debits only receipts (`RP_LEDR.cs:8268 {{CASE WHEN SIGN = '-' THEN CR_AMT ELSE 0 END,CASE WHEN SIGN = '+' THEN DR_AMT ELSE 0 END}}`); ported as written.
- JmaUdr printed no rows; it now prints the account's AC_DATA legs in the dates (`RP_LEDR.cs:4017`).
- The Gold balance applied the data type; the desktop Gold balance has none (`RP_LEDR.cs:8327`) while Silver and
  JmaUdr drop it only for C (`RP_LEDR.cs:8942`, `:4005`).
- The Silver balance used two decimals always; it reads three when `SILVER_THREE_DIGIT` is Y (`RP_LEDR.cs:8947`).
- The fine total summed issues and receipts together; it is now split into fine in (+) and fine out (-).
- Lite only refused ageing; Basic hides it too (`RP_LEDR.cs:4587`).
- Money is rounded with `round` to 2 places, weights to 3, touch to 2, through `@datacare/core` only.

Deviations kept and recorded (owner may override):

1. The manufacturing sources (GHAT REC, JDTR, FTNG/CHEDIYA/PARA) run only when `MsMfgType` is J (`RP_LEDR.cs:8290`),
   and `MsMfgType` is set only for named registration serials (`MS_OPNCOMP.cs:4911`); the SALES RETURNE detail and
   OUTWORD/INWORD arms are gated on single serials (`RP_LEDR.cs:8305`, `:8310`). The web has no registration serial,
   so these arms are not ported; case config.mfg-type-j stays open on that question.
2. The branch title prefix "Branch - <lc> " (`RP_LEDR.cs:8361`, shown when `MsLcBoxShow`) is not produced.
3. The locked test refuses the Silver print with an empty location sent; the desktop refuses only in `Silver_Summ`
   (the voucher-wise summary, `RP_LEDR.cs:8665-8668`), not on the plain Silver print. Left as the case list states;
   the page never sends an empty location. Proposed for the next case-list correction.
4. The desktop reads `CO_YEAR = MCo_year`; the web reads every year without the carried year-end opening, as the
   existing ledger does.

## Screen against the desktop

- Captions "Gold", "Silver", "JmaUdr" (desktop `&Gold`, `&Silver`, `&JmaUdr`, `RP_LEDR.cs:2439`, `:2453`, `:2425`);
  ghost buttons, shown only in the detail drill-down, hidden after Esc (`RP_LEDR.cs:6024`).
- The Hz layout question is a browser confirm (OK = Yes) with the exact desktop text.
- "In Out" / "Ac Sale" is not on the page (no route yet).
- Hot keys Alt+G, Alt+S, Alt+J work in the drill-down; Alt+I does not exist yet.

## Console and network

No failed request in the module run other than the asserted 403 refusals of the print-right case. Each print issues
one PDF request; the browser cases fetch the matching JSON data route once to check the figures.

## Print

The PDFs come from the shared server report document (summary cards, the parameter list and the row table), not the
Crystal regions of `JmUdAmt`, `JmUdFine` and `JmUdFineSl`; the region and column comparison with
`extraction_output/rpt_xml/JmUdFine.xml` was **not** done. Figures and titles match the desktop parameters.

## Verdict

**Ready for review** for the scope above. Not done here (the menu stays PARTIAL): the OP_LDR ageing union and its
cases (filter.*-op-ldr, ageing.*, drill.op-ldr-row-ownership, scope.op-ldr-company, scope.presence-location,
keyboard.ageing-rerun, journey.op-ldr-to-print), In Out / Ac Sale (output.in-out-print, config.work-type-ac-sale),
output.summary-hz-choice, output.voucher-wise-summ, refuse.zoom-opening, refuse.zoom-rights, refuse.empty-ageing-silent,
config.half-month-toggle, config.mfg-type-j, entry.fine-type-default, entry.date-defaults,
keyboard.uppercase-apostrophe; the Crystal region comparison; D16.
