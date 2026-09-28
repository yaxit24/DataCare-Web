# WP-07 tag invariant evidence

**Date:** 2026-08-30
**Plan:** `EXACT-END-TO-END-PARITY-PLAN-2026-08-29.md`
**Work package:** WP-07 — exact tag identity/availability/locking/image kernel and desktop-derived transition model
**Status:** four data invariants implemented and proved; the twelve-invariant coverage map recorded; **WP-07 is NOT closed** — the §7.2 transition model needs desktop evidence and two invariants need owner decisions
**Claim boundary:** this establishes which of the twelve §7.1 invariants are actually held, and by what. It does not build the transition model, and it does not re-enable any contained tag operation.

## 1. What already existed

Applying the WP-06 lesson — measure before building — the tag identity kernel is partly present in `modules/stock/stock.ts`:

- `TagKey` carries `CO_CODE`, `LC_CODE`, `TAG_NO`, `VCH_SRNO`, `IT_CODE`; tenant comes from RLS.
- `issueTagTx` takes `pg_advisory_xact_lock` on `tag-issue|CO|LC|TAG_NO`, selects `FOR UPDATE`, and refuses an ambiguous match with `TagIdentityAmbiguousValidationError`.
- Availability is modelled by row presence in `TAG_STOCK`, with imported tags falling back to `BAR_DETL`.

So the gap is not identity resolution. It is that nothing asked whether the **persisted data** obeys the same rules — the half that code cannot assert about itself.

## 2. The schema answered two invariants before any code was written

| Table | Unique key | Consequence |
| --- | --- | --- |
| `TAG_STOCK` | `(tenant_id, CO_CODE, LC_CODE, TAG_NO)` | Invariant 1 is a **database constraint**. A second live claim on one tag text cannot be inserted. |
| `BAR_DETL` | `row_id` only | Nothing prevents a duplicated identity. |
| `MAIN_STOCK` | `row_id` only | Nothing prevents an impossible on-hand. |

Two things follow, and both changed the design mid-work:

**Invariant 1 is enforced, so scanning for duplicates would be theatre.** The check that can actually fail is whether the constraint still *exists* — dropping or narrowing it would silently turn an enforced invariant into an unenforced one while every row still looked fine. INV-1 is therefore a schema assertion, not a row scan.

**The live key deliberately excludes `VCH_SRNO`.** At most one instance of a tag text is live per company and location; the serial distinguishes instances over **time** in the history tables. My first draft asserted the opposite — that `TAG_STOCK` should hold the same text at two serials — and the database rejected the insert, which is how the mistake surfaced. `issueTagTx` locks on `TAG_NO` without the serial for the same reason, so lock granularity and constraint agree.

**Invariants 2 and 3 are the ones with no constraint behind them**, which is precisely why they need scans.

## 3. What was built

`modules/stock/tagInvariants.ts` — four checks, run inside a tenant-scoped transaction so RLS does the scoping. They take **no tenant argument**: a diagnostic that accepted one could be pointed at another tenant's rows.

| Check | Requirement | Method |
| --- | --- | --- |
| INV-1 | §7.1(1) unambiguous live identity | asserts the `TAG_STOCK` unique key still covers tenant/company/location/tag |
| INV-2 | §7.1(2) a serial is allocated once | duplicate `(CO, LC, TAG_NO, VCH_SRNO)` in `BAR_DETL` |
| INV-3 | §7.1(3) signed on-hand is 0 or 1 | signed `MAIN_STOCK.ITM_SIGN`/`ITM_PCS` net per exact identity |
| INV-9 | §7.1(9) a movement can be traced to its provenance | a tagged movement naming no book or voucher |

Each result carries an `examined` count, so a clean result on an empty table cannot be mistaken for a proof.

INV-9 checks only the unconditional half. The plan says provenance "and, **where required**, `BAR_DETL`/`BAR_IDTL`", and which movements require a `BAR_DETL` row is a desktop question nobody has answered — imported tags legitimately live in `TAG_STOCK` alone — so asserting that join would invent a rule.

## 4. Exit evidence

`test/tagInvariants.db.test.ts` — 12 tests against a real database. Every check is exercised by seeding the exact violation it exists to catch, because a check nobody has seen fail is not a check:

- a coherent tag (admitted, held) and a completed one (admitted then issued, net 0) both pass, with non-zero `examined`;
- INV-1's constraint **rejects** a duplicate live claim at insert time (`P2010`), and the check reports the constraint present;
- the history tables accept a duplicated identity and an impossible on-hand, which INV-2 and INV-3 then catch — pinning why those two are scans and INV-1 is not;
- INV-3 catches both an ornament admitted twice (`signed on-hand is 2`) and one issued having never been admitted (`-1`);
- INV-9 catches a movement naming no voucher;
- a violation seeded in **another tenant** produces zero findings and `examined = 0`, so diagnostics cannot become a cross-tenant read.

Full suite **154 files / 1304 tests passing**; `tsc` clean for api source, api tests and web; `prettier --check` clean.

## 5. The coverage map — the honest half

`TAG_INVARIANT_COVERAGE` records how each of the twelve is held, tested for completeness and for citing evidence:

| Held by | Invariants | Note |
| --- | --- | --- |
| `data-check` | 1, 2, 3, 9 | 1 is a database constraint; the rest are scans over unconstrained tables |
| `code-tested` | 4, 7, 11 | advisory lock plus the atomic `DELETE` affected-row check; reversal inside one transaction |
| `contained` | 6 | WP-01 blocks tag transfer; conservation is unproved |
| `blocked-owner-decision` | 5, 8 | split conservation tolerance (§8.1 item 3); old-versus-new tag identity on return (§8.1 item 2) |
| `blocked-transition-model` | 10, 12 | image lineage across split/weight/cancel; print staging that clears all tenant rows (WP-10) |

Six of the twelve cite WP-01 containment. That matters for how the exit criterion is read: **"no violations observed" on a blocked path is not evidence the path is correct.** Invariants 4 and 7 are genuinely tested for the sale path, and the other four operations they name — split, transfer, weight change, cancel — simply cannot contend today because they return 503.

## 6. What remains for WP-07

- The §7.2 canonical transition model: a versioned state/transition table derived from desktop code, persisted rows and observed workflows. The plan is explicit that state names and terminal semantics must not be invented before that evidence exists, so it was not started.
- Invariants 5 and 8 need the two owner decisions named above before they can even be stated as assertions.
- Invariants 10 and 12 need the image-lineage service and job-scoped print staging, which are WP-09/WP-10.
- The four data checks are ready to run against a **migrated company**, which is where they have data to examine. On the test fixture they examine tens of rows; against a real migration they examine the 1,567-voucher footprint, and that is the run that would mean something. It belongs in WP-14B's reconciliation, and the `examined` counter exists so a thin run cannot be mistaken for a thorough one.

## 7. Files

- `web/apps/api/src/modules/stock/tagInvariants.ts` (new)
- `web/apps/api/test/tagInvariants.db.test.ts` (new)

---

## Correction — 2026-08-30 (found by WP-08d)

INV-2 and INV-3 as shipped here selected tagged rows with `coalesce("TAG_NO"::text,'') <> ''`, in six places.
That predicate does not mean "tagged". The desktop's untagged sentinel is the literal **`'N'`**, not `''`:
`Ac_Stock.cs:54` converts `CASE WHEN A.TAG_NO = '' THEN 'N' ELSE A.TAG_NO END`, every untagged insert hardcodes
`'N'` (`:15, :17, :32, :42, :44, :56`), and loose stock is read back with `TAG_NO = 'N'`
(`TR_KR_ISU.cs:6961`, `TR_MFG_KR_ISU_REC.cs:4694, :8096, :8100`). The web writes the same sentinel
(`stock.ts:780, :934, :1036`).

Consequences on real data, neither of which this document's evidence would have caught:

- **INV-3** swept every loose `MAIN_STOCK` movement in a company into one fabricated identity `('N', 0)`, whose
  signed net is the entire loose balance — a violation reported against stock that was never tagged.
- **INV-2** reported untagged `BAR_DETL` rows legitimately sharing `('N', 0)` as a serial handed out twice.

**Why the evidence here did not catch it:** the fixtures in `test/tagInvariants.db.test.ts` seed tagged rows
exclusively, so neither check had ever been run against a row carrying the sentinel. The passing counts recorded
above were real but unrepresentative.

Fixed in WP-08d by a single shared predicate `IS_TAGGED = coalesce("TAG_NO"::text,'') NOT IN ('', 'N')` used in
all six places, plus two tests that seed loose stock and assert zero violations with `examined` of 0. Both fail
without the fix. See `wp-08/WP-08D-KARIGAR-TAG-STOCK-EVIDENCE-2026-08-30.md`.

The "4 of 12 invariants data-checked" count is unchanged; what changed is that two of those four were checking
the wrong row set.
