# Desktop-vs-web parity: the Windows procedure

This is the procedure that produces the only objective evidence that the web application agrees with
DataCareNext. Until it has been run, every arithmetic claim in this codebase rests on the **decompiled source**
— a strong form of evidence, but not the same thing as comparing output with the running application.

The `g5:parity` gate stays **red** until a real comparison artifact exists, and it refuses anything that did
not come from a live SQL Server.

## Why the Windows step is only an extraction

The earlier harness connected to SQL Server and PostgreSQL at the same time and compared in flight. Every
defect in the comparison logic therefore had to be discovered _on that machine_, during a session that is
expensive to arrange — and nothing was retained, so a disputed result could not be re-examined.

Extraction and comparison are now separate:

```
Windows box                    anywhere
-----------                    --------
enter voucher by hand
        |
parity-extract-mssql.mjs  -->  desktop-<timestamp>.json  \
                                                          >--  parity-compare.mjs  -->  parity-diff-*.json
post the same voucher                                    /
        |
parity-extract-pg.mjs     -->  web-<timestamp>.json
```

The Windows step is **read-only** and cannot modify the desktop database. The bundles are retained, so a fix
can be re-compared against exactly the same data.

## Before you start

On the Windows box:

```bat
node --version                        :: 20 or newer
pnpm add -w -D mssql                  :: dev-only driver, not needed to run the app
```

Find the SQL Server instance and database name the desktop uses. It is normally in the application's
configuration or visible in SQL Server Management Studio. You need read access only.

## Step 1 — Choose the cases

A case is one voucher, entered the same way on both sides. Start with these five, which between them exercise
the arithmetic that matters most. Add more once the pipeline is proven.

| caseId                  | What to enter                                                                    |
| ----------------------- | -------------------------------------------------------------------------------- |
| `sale-cash-single-line` | Cash sale, one gold line, net weight and touch set, a making charge, GST applied |
| `sale-credit-old-gold`  | Credit sale to a party with an old-gold exchange line                            |
| `purchase-basic`        | Purchase from a party, one line, GST applied                                     |
| `sale-return`           | Return against the sale above                                                    |
| `rate-cut`              | A rate-cut voucher settling metal against money                                  |

Write down, for each: the **book** and the **voucher number** the desktop allocated, and the same for the web.
They will differ — that is expected, and the comparison links the two by `caseId`, not by number.

**Enter the same values on both sides.** The date must be the same; it is compared. Do not let one side default
to today and the other to a chosen date.

## Step 2 — Extract from the desktop

```bat
set PARITY_MSSQL_HOST=localhost
set PARITY_MSSQL_DATABASE=DataCare
set PARITY_MSSQL_USER=sa
set PARITY_MSSQL_PASSWORD=********
set PARITY_COMPANY=01
set PARITY_LOCATION=01
set PARITY_CASES=[{"caseId":"sale-cash-single-line","description":"cash sale 1 gold line","book":"SL","vchNo":"00042"}]
node apps\api\integration\parity-extract-mssql.mjs
```

For Windows authentication instead of a SQL login, set `PARITY_MSSQL_TRUSTED=1` and omit user and password.

Expected output:

```
  sale-cash-single-line: SL/00042 -> 7 tables
PARITY_EXTRACT_OK 1 case(s) -> ...\bundles\desktop-2026-...json
```

If it reports **no rows in any table**, the book or voucher number is wrong, or the voucher was not saved.

The table set is discovered from the desktop's own schema — every table carrying `CO_BOOK` and `VCH_NO` is
probed. It is _not_ filtered by what the web has, which is what lets the comparison detect a write the web
never performed.

## Step 3 — Enter the same cases in the web app and extract

```bash
DATABASE_URL='postgresql://...' \
PARITY_TENANT=default PARITY_COMPANY=01 PARITY_LOCATION=01 \
PARITY_CASES='[{"caseId":"sale-cash-single-line","book":"SL","vchNo":"00001"}]' \
node apps/api/integration/parity-extract-pg.mjs
```

`caseId` **must match** the desktop's. `vchNo` is the web's own number.

## Step 4 — Compare

```bash
pnpm build      # the differ is compiled TypeScript
node apps/api/integration/parity-compare.mjs \
  ../project-memory/parity/bundles/desktop-latest.json \
  ../project-memory/parity/bundles/web-latest.json
```

A pass looks like:

```
cases 1/1 matched   fields compared 454 (excluded 43)   differences 0
PARITY_COMPARE_OK 1/1 cases, 454 fields compared -> ...parity-diff-...json
```

Note that the report always states **how many fields it looked at and how many it excluded**. A verdict of
"matched" is meaningless without that denominator, and the predecessor did not publish one.

A difference names the field and both values:

```
  DIFF sale-cash-single-line  desktop SL/00042 vs web SL/00001
         SL_DATA.TOT_AMT [single unmatched row]  desktop=67271.12  web=67270.12
         TAX_DATA: WEB NEVER WROTE THIS TABLE (2 desktop rows)
```

Then:

```bash
pnpm g5:parity        # green only when a real, matching artifact exists
```

## What is excluded from the comparison, and why

Only fields that **cannot** agree by construction. Each carries a reason in
`apps/api/src/modules/parity/bundle.ts`, and the count is published with every result.

| Field                                             | Reason                                                           |
| ------------------------------------------------- | ---------------------------------------------------------------- |
| `TENANT_ID`, `ROW_ID`                             | web-only storage identity                                        |
| `VCH_NO`, `HD_VCH_NO`, `OLD_VCH_NO`, `NEW_VCH_NO` | allocated independently on each side                             |
| `VCH_TIME`, `ENTRY_TIME`                          | wall clock; the two entries happen at different moments          |
| `MAIN_USER`, `USER_UPDATE`                        | operator differs between the desktop session and the API session |

**`VCH_DATE` is compared.** The predecessor skipped it, which meant a voucher posted to the wrong day could
not be detected. `BILL_NO`, `STK_DATE`, `DATA_TRFR`, `CO_BOOK` and the scope columns are also compared now.

## Interpreting a difference

Work in this order — the first two are usually operator error, not a defect:

1. **Different input.** Confirm both sides received identical values, especially the date and the rate.
2. **Different configuration.** Rounding, labour type and rate basis all come from `CO_SET`/`CO_SET_NEW`. If
   the desktop company is configured differently from the web company, the two will legitimately disagree.
   Compare `pnpm settings:parity` output against the desktop's settings screens.
3. **A real divergence.** Then the field and both values are in the artifact, which is enough to locate the
   desktop source line responsible.

A `WEB NEVER WROTE THIS TABLE` finding is always significant: it means a whole table in the desktop write set
is absent from the web's.

## Reports: comparing the data

Built and tested. Compare the **rows and control totals**, never the layout — Crystal pixel parity is not
claimed anywhere in this project and must not be inferred from the 254 layout baselines, which only detect
regressions in the web's own renderer.

While you are on the Windows box, export each report you care about to CSV:

    DataCareNext -> open the report -> Export -> CSV

Then on the web side, with the **same date range and filters**:

```bash
curl -b cookies.txt "http://<host>/reports/day-book/export.csv" -o web-day-book.csv
```

Every report has a CSV export. Write a column map, because Crystal names its fields after the report designer's
choices and the web names them after its own row keys — there is no reliable way to infer the correspondence,
and a column the map does not name is reported as unmapped rather than silently dropped:

```json
{
  "report":  "day-book",
  "columns": { "VchNo": "vchNo", "AcName": "acCode", "Dr Amount": "dr", "Cr Amount": "cr" },
  "numeric": ["dr", "cr"],
  "key":     ["vchNo", "acCode"],
  "scale":   { "dr": 2, "cr": 2 },
  "crystalHeaderHint": "VchNo"
}
```

```bash
node apps/api/integration/report-compare.mjs crystal-day-book.csv web-day-book.csv day-book-map.json
```

The reader handles what a real Crystal export carries: a UTF-8 BOM, a title block, page headers repeated on
every page, group captions, blank separators, a grand total, thousands separators and parenthesised negatives.
None of those are counted as data rows — miscounting them would make the row totals disagree for reasons that
have nothing to do with the business logic.

Output leads with the denominator, and states plainly when it did **not** run a row-level comparison:

```
  rows      crystal 50  web 50
  total dr: crystal 663942.82  web 663942.82
  row level: 200 fields compared, 0 differing
  skipped   crystal {"blank":1,"repeatedHeader":24,"groupOrSubtotal":0,"total":1}
  VERDICT: matched
```

## What this procedure does not cover

- **Hardware** — scale, scanner, webcam, printer. Implemented to their interfaces, never exercised against a
  device.
- **WhatsApp / SMS / GSP** — no credentials, so no live send has ever succeeded.
- **Legacy data migration** — needs a real, sanitised customer database to rehearse against.

These remain honestly open. None of them is unblocked by this procedure.
