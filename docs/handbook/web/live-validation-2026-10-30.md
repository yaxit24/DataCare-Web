# Hand-run live validation, 30 October 2026

**Status: historical record, superseded.** This was a one-off check by hand, done before the automated feature
suites existed. The retained, repeatable checks are the feature suites and the UI surface crawl
(`docs/handbook/web/testing.md` §4a and §4b, results in `docs/handbook/web/ui-surface-map.md`). This record is kept
because it is the first time the running app was checked end to end in a browser, and because it is honest about
what that check did and did not prove.

## Environment

The developer's running demo stack, not an isolated one: web `localhost:4411`, API `:4410`, PostgreSQL `:55800`,
tenant `dc-shop`, company 01 (Demo Jeweller), financial year 2026-2027, logged in as `admin` through the real login
page in Chrome (chrome-devtools MCP). Demo masters present: system accounts (WALKIN, CASH, BANK, SALES, PURCHASE, GST,
GSTINPUT, ROUNDOFF, KASAR, TCS, HMCHRG, OLDGOLD, OG, OS, INTINC), items GOLD and SILVR, and 41 books (SL, SRT, SOR,
ORC, PR, PRT, RCT, PAY, CON, JV, KRI, KRR, LBR, DHI, DHR, BUL, TUR, TRR, WHS, WHQ, TOP, TGC, TSP, TTR, FIO, FJV, FPR,
FSL, RTC and others). Not provisioned in that demo: manufacturing, setting, jobwork, scheme/membership and bullion
booking books, so those screens could not be exercised there.

## How each step was driven

The evidence contract (`.kiro/skills/datacare-feature-browser-validation/references/evidence-contract.md`) counts a
step as a browser pass only when the real screen controls were operated. Steps marked **API from the page** called
the same endpoints the screen's buttons call, through `fetch` inside the logged-in page. They prove the backend
lifecycle, not the screen.

| Screen                                   | Step                   | Driver                                                                   | Result                                                                                                                                                                                                                                                                            |
| ---------------------------------------- | ---------------------- | ------------------------------------------------------------------------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Sales Invoice                            | Create                 | **Screen**: item line filled in the grid, Save Invoice pressed           | Saved as voucher 2. On-screen totals matched the hand calculation: fine 9.16 (10 g × 91.6%), net 65,000 (10 × 6,000 + 10 × 500 making), CGST 975 + SGST 975, total 66,950. Console clean. After saving, the screen offered Update Invoice, Delete, New, Load and View Invoice PDF |
| Sales Invoice                            | Reopen                 | API from the page (`GET /api/sales/00002`)                               | All fields returned: party WALKIN, tax 3%, one GOLD line, net 10, rate 6,000, total 66,950                                                                                                                                                                                        |
| Sales Invoice                            | Edit                   | API from the page (`PUT /api/sales/00002`, discount 1,000)               | 200; recalculated to net 60,000, tax 1,770 (885 + 885), total 60,770. The net fell to 60,000 because the hand-written request did not resend the making charge, not because of the app                                                                                            |
| Sales Invoice                            | Delete                 | API from the page (`DELETE`)                                             | 200 `{"reversed":true}`; a read afterwards answered 400 (voucher not found)                                                                                                                                                                                                       |
| Sales Invoice                            | Print                  | API from the page (`/api/sales/00002/print?format=pdf&copy=O&coBook=SL`) | 200, a real 182,694-byte `application/pdf`. Without `coBook` and a valid `copy` the endpoint answers a clear 400, which is how the screen's own button calls it                                                                                                                   |
| Purchase Invoice                         | Render                 | Screen                                                                   | Heading "Purchase Invoice", 108 inputs, book PR offered, no script error                                                                                                                                                                                                          |
| Purchase Invoice                         | Create, reopen, delete | API from the page                                                        | Create 201 (voucher 1, total 28,304.40 = 5 g × 91.6% × 6,000 + 3% GST, the fine-weight rule), reopen 200, delete 200 `{"reversed":true}`                                                                                                                                          |
| Contra                                   | Create, delete         | API from the page                                                        | Create 201 (voucher 1, CASH → BANK 1,000), delete 200                                                                                                                                                                                                                             |
| Journal, Receipt, Payment, Karigar issue | Create                 | API from the page                                                        | 400 with a clear validation message each time. These were mistakes in the hand-written requests (wrong line shape, missing book scope), not app defects; they show the server refuses bad input cleanly                                                                           |

An attempt to check every transaction page by fetching its HTML gave false results: the pages render in the browser
after loading, so their raw HTML is the application shell. That approach was abandoned; the surface crawl (§4b)
renders every page in a real browser instead.

## What it showed and what it did not

- Shown: login, the dashboard (one sale, trial balance balanced), a faithful Sales Invoice screen whose on-screen
  calculation matched the desktop net-weight rule, and a backend that creates, reopens, edits, deletes and prints
  vouchers and refuses malformed requests with clear messages.
- Not shown: edit, delete and print through the screen; any edge case; any report total; any screen beyond the four
  above. The feature suites added since then cover these for Sales Invoice, Purchase Invoice and Company Settings.
- Later on the same demo database, the `admin` user was found demoted to an ordinary user with every right `N`
  (`POST /admin/users/:loginName/rights` answered 200 at 15:50 IST), after which admin requests answered 403. Recorded
  as G178, planned as N169.
