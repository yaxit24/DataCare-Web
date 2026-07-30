# Prompt for the Windows machine

Paste everything below the line into the agent running on the Windows box that has DataCareNext installed.

It is written to be self-contained: it states the goal, the constraints, what to do, and — importantly — what
**not** to conclude. Read the "Rules" section before starting; several of them exist because the harness this
replaces produced confident results that were wrong.

---

## Your task

You are on a Windows machine where the **DataCareNext desktop application** (Windows Forms + Crystal Reports +
SQL Server) is installed and working. A web replacement for it has been built. Nobody has ever compared the
two applications' output — every correctness claim so far rests on reading the decompiled desktop source, which
is not the same as checking against the running program.

Your job is to produce that comparison for the first time.

You will **not** modify the desktop application or its database. Every step you take against SQL Server is a
read.

## Get the code

```bat
git clone https://github.com/yaxit24/datacarenext-web.git
cd datacarenext-web
```

Read `web/docs/PARITY-WINDOWS-PROCEDURE.md` in full before doing anything else. It is the authoritative
procedure; this prompt is the framing around it.

## What you need

- **Node.js 20 or newer** — `node --version`
- **The SQL Server instance and database name the desktop uses.** Find it in the application's configuration
  or in SQL Server Management Studio. Read access is sufficient.
- **The mssql driver.** The extractor imports only Node builtins plus `mssql`, so it runs standalone:

  ```bat
  npm i mssql
  ```

  You do **not** need to build the web workspace to run the extraction.

## Step 1 — Confirm you can read the database

Before entering anything, prove the connection and find the company code:

```bat
set PARITY_MSSQL_HOST=localhost
set PARITY_MSSQL_DATABASE=<the desktop's database name>
set PARITY_MSSQL_USER=sa
set PARITY_MSSQL_PASSWORD=<password>
set PARITY_COMPANY=01
set PARITY_CASES=[{"caseId":"probe","book":"SL","vchNo":"00001"}]
node web\apps\api\integration\parity-extract-mssql.mjs
```

For Windows authentication instead of a SQL login, set `PARITY_MSSQL_TRUSTED=1` and omit user and password.

Any voucher that already exists is fine for this probe — you are checking connectivity, not comparing yet. If
it reports **no rows in any table**, the book or voucher number does not exist; look at `SL_DATA` in SSMS to
find a real one.

## Step 2 — Enter the cases in the desktop application

Enter these five vouchers **by hand, in the desktop UI**, exactly as a shop would. Record the book and voucher
number the desktop allocates for each.

| caseId | What to enter |
|---|---|
| `sale-cash-single-line` | Cash sale, one gold line: net weight, touch, a rate, a making charge, GST applied |
| `sale-credit-old-gold` | Credit sale to a party, with an old-gold exchange line |
| `purchase-basic` | Purchase from a party, one line, GST applied |
| `sale-return` | Return against the sale above |
| `rate-cut` | A rate-cut voucher settling metal against money |

Write down, for every case: **the exact values you typed**, including the date. You will need to type the same
values into the web application, and the date is compared — do not let one side default to today while the
other uses a chosen date.

## Step 3 — Extract from the desktop

```bat
set PARITY_CASES=[{"caseId":"sale-cash-single-line","description":"cash sale, 1 gold line","book":"SL","vchNo":"00042"},{"caseId":"purchase-basic","description":"purchase, 1 line","book":"PR","vchNo":"00013"}]
node web\apps\api\integration\parity-extract-mssql.mjs
```

Include every case you entered. The bundle lands in `project-memory\parity\bundles\`.

## Step 4 — Report back

You almost certainly **cannot** finish the comparison on this machine, because the web application and its
PostgreSQL database run elsewhere. That is expected and fine — the design deliberately splits extraction from
comparison.

So: commit the bundle on a branch and push it.

```bat
git checkout -b parity/desktop-capture-<yyyy-mm-dd>
git add -f project-memory/parity/bundles/desktop-*.json
git commit -m "Desktop parity capture: <n> cases from <database>"
git push -u origin parity/desktop-capture-<yyyy-mm-dd>
```

`-f` is required because bundles are normally git-ignored — they contain real voucher rows.

Then write, in the pull request or a note beside it:

1. The SQL Server version the extractor printed.
2. For each case: the caseId, the book and voucher number, and **the exact input values you typed**.
3. The desktop's configuration for that company — specifically the rounding, labour-type and rate-basis
   settings on the settings screens. A configuration difference makes the two applications legitimately
   disagree, and without this the comparison cannot be interpreted.
4. Anything that behaved unexpectedly in the desktop app while you worked.

## If you also have the web app running here

Then finish it yourself:

```bat
set DATABASE_URL=postgresql://...
set PARITY_TENANT=default
set PARITY_CASES=[{"caseId":"sale-cash-single-line","book":"SL","vchNo":"00001"}]
node web\apps\api\integration\parity-extract-pg.mjs

cd web && pnpm install && pnpm build && cd ..
node web\apps\api\integration\parity-compare.mjs ^
  project-memory\parity\bundles\desktop-latest.json ^
  project-memory\parity\bundles\web-latest.json
```

`caseId` must match between the two bundles. The voucher numbers will differ; that is expected and handled.

## Rules

**Do not modify the desktop database.** No `UPDATE`, no `DELETE`, no `INSERT` outside the application's own UI.
If a step seems to require a write, stop and say so.

**Do not edit the harness to make a comparison pass.** If the differ reports something you believe is wrong,
say what and why, and leave the code alone. The harness this replaces was never tested and had six defects that
each made the comparison unable to fail — a green result from a weakened instrument is worse than a red one.

**Do not report success you have not verified.** `PARITY_EXTRACT_OK` means rows were captured. It does not mean
the applications agree. Only `parity-compare.mjs` can say that, and only for the cases actually entered on both
sides.

**A difference is not automatically a defect in the web application.** Check in this order:

1. Did both sides receive identical input? Re-read your notes, especially the date and the rate.
2. Is the configuration the same? Rounding, labour type and rate basis come from `CO_SET` and `CO_SET_NEW`. If
   the desktop company is configured differently, the two *should* disagree.
3. Only then is it a real divergence — and the artifact names the field and both values, which is enough to
   locate the responsible line.

**Report what you could not do.** If you cannot find the database, cannot get read access, or cannot enter a
case because the desktop rejects it, say that plainly. An honest blocker is more useful than a partial result
presented as complete.

## What good output looks like

A pushed branch containing one or more desktop bundles, and a note that lets someone else reproduce exactly
what you did: server version, per-case inputs, the company's configuration, and any anomalies.

If you got as far as running the comparison, include the `parity-diff-*.json` artifact and say plainly whether
it matched — and if it did not, which fields differed.
