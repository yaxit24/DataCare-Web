---
name: datacare-code-review
description: Review a DataCare change (a branch, pull request or working-tree diff) against the engineering standards — desktop authority, scope, posting, calculations, SQL, schemas, versions, idempotency, size limits, tests and records — and report findings by severity. Use before opening or approving a pull request.
---

# Code review against the DataCare standards

Change to review: `$ARGUMENTS` (a branch, a pull request number, or empty for the working tree).

Standards: `docs/handbook/web/engineering-standards.md`. Report each finding as
`severity | file:line | rule | why it matters | fix`, with severity S1 (wrong business result, data loss, security),
S2 (incomplete or fragile), S3 (style or ergonomics).

## 1. Get the diff

```bash
git fetch origin
git diff --stat origin/main...HEAD        # or: gh pr diff <number>
git diff origin/main...HEAD -- web/
```

## 2. Mechanical searches on the changed lines

| Search (on added lines) | Rule |
|---|---|
| `Math.round(`, `.toFixed(`, `parseFloat(` on money or weight | Calculations through `@datacare/core` with desktop rounding stages |
| `req.body as`, `request.body as` | Every route has a JSON Schema; no raw-body casts |
| `$queryRawUnsafe`, `$executeRawUnsafe`, template-string SQL | Bind every value; identifiers only through `web/apps/api/src/modules/security/sql.ts` |
| Quoted 5-digit account codes such as `'00001'`, `'CASH'`, `'KASAR'`, book codes | No literal accounts or books; resolve from `BOOK_DETL` and the session |
| `coCode`, `lcCode`, `coYear` read from body or query | The session owns business scope |
| New `app.get/post/put/delete` in `web/apps/api/src/routes/txn.ts` | Once N88 plugins exist, new routes go into their module plugin; before that, next to their family with a schema |
| `as any`, `@ts-ignore`, `eslint-disable` | Typed boundaries instead |
| `fetch(` in pages | Pages call the API through `web/apps/web/lib/api.ts` |
| Hard-coded dates, `new Date()` in calculations | Dates travel as `YYYY-MM-DD`; clocks are injected in tests |
| Secrets, connection strings, tracked `.env` values | Never in code, tests, fixtures or docs |

## 3. Judgement checks

1. **Desktop authority.** Does the description cite the desktop dispatch, form and posting lines for every behaviour
   change? Does the code match them (field order, write order, rounding stage, validation message)?
2. **Write set.** Is the whole write set written or reversed in one transaction? Are `AC_DATA` legs balanced and leg
   codes from the family? Is the party day-book row only written when the bill is outstanding?
3. **Lifecycle.** Edit and delete require the version token; financial creates require an idempotency key; reopen
   returns every field; an unchanged save changes nothing.
4. **Scope and rights.** Route policy entry, form right and business scope for every new route; lists carry the full
   voucher identity.
5. **Tests.** The tests in standards §7 exist, use independently derived expectations, and include a broken variant.
6. **Size and boundaries.** New or moved API files ≤ 800 lines, pages ≤ 600; no existing large file grows; kernel
   stays pure.
7. **Records.** Backlog status, `statusAsOf` and existing evidence paths; document 11 §2; menu-catalog rows;
   generated views regenerated.

## 4. Run the gates

```bash
cd web && pnpm lint && pnpm typecheck && pnpm typecheck:tests && pnpm test && pnpm format:check
cd .. && python3 docs/master-parity-plan-2026-09-29/validate_plan.py && python3 docs/tools/docs_check.py
```

## 5. Report

Start with a one-line verdict (approve, approve with follow-ups, or changes required), then the findings table
ordered by severity, then what you could not verify (for example no desktop capture, no browser run).
