# WP-08d — Karigar tag stock movements

Scope from plan §17.6. Read the desktop write set for karigar receipt, decide from it whether a tagged `+`
movement is written and with which columns, then add it behind the same identity resolver or record a signed
divergence. Exit evidence: INV-3 examining a non-zero row count for a karigar-created tag and reporting a signed
on-hand of exactly 1 while it is held.

Status: **DONE**, and it uncovered a second defect in WP-07 that was more serious than the one in scope.

## 1. Desktop evidence

The MAIN_STOCK write set is not in the form modules. Every posting goes through one shared helper,
`unified/src/csharp_nextdm/DataCareNext/Ac_Stock.cs`, whose inserts all name the same 49 columns:

```
CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SR_NO, ISR_NO, VCH_DATE, STK_DATE, VCH_TYPE, BOOK_NAME,
AC_CODE, IT_CODE, TAG_NO, VCH_SRNO, TBL_CODE, TR_TYPE, ITM_SIGN, ITM_QTY, ITM_PCS, ITM_GWT, ITM_NWT,
ITM_TOUCH, ITM_WEST, ITM_FINE, ITM_RATE, ITM_AMT, LBR_RATE, LBR_AMT, OTH_AMT, ITM_MRP, NET_AMT,
KR_NWT, KR_TOUCH, KR_WEST, KR_FINE, KR_LBR_AMT, KR_OTH_AMT, KR_COST, EMP_CODE, ENTRY_TIME, MAIN_USER,
DATA_TYPE, DESIGN_NO, ITM_SIZE, ITM_DESC, GHT_PRC, ITM_LOT, ITM_DISC
```

**Answer to the scoping question: yes, a tagged `+` movement is written.** `Ac_Stock.cs:28` posts it straight
from the barcode row for the manufacturing tag books:

- source `FROM BAR_DETL AS A`, selecting `A.TAG_NO, A.VCH_SRNO`
- gated on `B.MAIN_BOOK IN ('OPSTK','JDTR TAG','MFG TAG')` — `MFG TAG` is the manufacturing/karigar tag book
- `TR_TYPE 'P'`, `ITM_SIGN '+'`, `ITM_QTY 1`

So the tagged movement is **parity**, not an addition. `Ac_Stock.cs:30` does the same for `TAG GEN`, and
`:66` writes the tagged `-` side for `APR ISU`.

**Second finding, unasked for and more important: the untagged sentinel is `'N'`, never `''`.**

- `Ac_Stock.cs:54` converts explicitly: `CASE WHEN A.TAG_NO = '' THEN 'N' ELSE A.TAG_NO END`
- every untagged insert hardcodes it: `Ac_Stock.cs:15, :17, :32, :42, :44, :56`
- loose stock is read back the same way: `TR_KR_ISU.cs:6961`, `TR_MFG_KR_ISU_REC.cs:4694, :8096, :8100`
  all filter `AND TAG_NO = 'N'`

Tag availability is likewise computed from `MAIN_STOCK`, grouped by `(TAG_NO, VCH_SRNO)`
(`TR_KR_ISU.cs:3318`), which is why a tagged ornament must carry both columns or the desktop cannot find it.

The web already followed the sentinel on write (`stock.ts:780, :934, :1036`) and in the untag repair
(`dataRepairOps.ts:646`). Nothing needed changing there.

## 2. Defect A — WP-07's invariant scans mistook loose stock for a tag

Not in the original scope; found while checking what INV-3 actually selects.

INV-2 and INV-3 selected tagged rows with `coalesce("TAG_NO"::text,'') <> ''`, in six places. `'N'` passes that
predicate. Consequences on any real company holding loose stock:

- every loose `MAIN_STOCK` movement in a company collapsed into one fabricated identity `('N', 0)`, whose signed
  net is the entire loose balance — so INV-3 reported a violation for stock that was never tagged
- untagged `BAR_DETL` rows legitimately sharing `('N', 0)` were reported by INV-2 as a serial handed out twice

This passed WP-07's tests only because those fixtures seed tagged rows exclusively. The checks were never
exercised against realistic data.

Fix: one documented predicate, `IS_TAGGED = coalesce("TAG_NO"::text,'') NOT IN ('', 'N')`, used in all six
places (`tagInvariants.ts`), so the literal cannot drift back in.

Proof it was real — both new tests failed before the fix:

```
× INV-3 does not mistake loose stock for a tag
  → expected [ { …(3) } ] to have a length of +0 but got 1
× INV-2 does not mistake untagged barcode rows for a reused serial
  → expected [ { …(3) } ] to have a length of +0 but got 1
```

## 3. Defect B — karigar stock movements named no tag

`stockRows` (`karigar.ts`, shared by issue, receive and edit) wrote 17 columns and neither `TAG_NO` nor
`VCH_SRNO`.

The plan recorded this as "invisible to tag-level stock views". It is worse than that: a row carrying neither a
tag nor the `'N'` sentinel matches **neither** the tagged views nor the desktop's loose views
(`TAG_NO = 'N'`). A karigar-received ornament was in stock and appeared in no stock view at all, while INV-3
satisfied invariant 9 vacuously by examining nothing.

Fix: `stockRows` takes the `Map<lineIndex, srno>` already produced by `resolveKarigarTagIdentitiesTx` (WP-08c)
and writes `TAG_NO`/`VCH_SRNO` for tagged lines, `'N'`/`0` otherwise, matching `Ac_Stock.cs:54`. A line counts
as tagged only with both a tag number and a positive serial.

In the edit path the resolution moved **above** the write set, because the stock rows now need it and because
`resolveKarigarTagIdentitiesTx` fills in `line.tagNo` for lines tagged without a number. It is now computed
once and consumed by both the barcode rows and the stock rows.

### Corrections to the plan's baseline

- §7's tag matrix claims karigar receipt tagging creates `BAR_DETL` **and** `MAIN_STOCK` tag rows. Only
  `BAR_DETL` existed. Now both do.
- §17.6 described the impact as tag-level invisibility. The true impact was invisibility in every stock view,
  tagged and loose.

## 4. Exit evidence

From `test/mfgLifecycle.db.test.ts`, on the tagged karigar receipt round trip:

- the receipt posts a `MAIN_STOCK` movement, exactly one row names the created tag, its `VCH_SRNO` equals the
  `BAR_DETL` serial, and its `ITM_SIGN` is `'+'`
- `INV-3.examined > 0` — the identity is examined rather than skipped
- `INV-3.violations` is empty: signed on-hand is exactly 1 while the ornament is held

Mutation check, restoring the pre-fix builder:

```
× keeps a tagged karigar receipt intact across reopen and save unchanged
  → the movement must name the tag the receipt created: expected [] to have a length of 1 but got +0
```

## 5. Verification

- `155 test files / 1312 tests` pass (baseline 1310, +2 sentinel tests)
- `tsc -p apps/api/tsconfig.json`, `tsconfig.test.json`, `apps/web/tsconfig.json` all clean
- `prettier --check .` clean

## 6. Deliberately not done

**The tagged `-` side of karigar issue.** `TR_KR_ISU.cs:3318` proves the desktop can issue an existing tagged
ornament to a karigar, and `Ac_Stock.cs:66` shows the tagged `-` shape for `APR ISU`. The web's issue path has
no tag handling at all: `resolveKarigarTagIdentitiesTx` is called only from the receive and edit-receive paths.
Writing a tagged `-` needs the **existing** serial looked up from the live tag record, not allocated, which is a
different resolver and its own evidence. `stockRows` already handles it structurally — pass identities for the
issue call site and the rows become tagged — so the remaining work is the lookup, not the builder.

**The other 32 desktop MAIN_STOCK columns.** `stockRows` writes 19 of 49. The absent ones include `ISR_NO`,
`STK_DATE`, `TBL_CODE`, the seven `KR_*` columns, `DATA_TYPE` and `ITM_LOT`. Untouched here because this
increment was scoped to tag identity; recorded so the gap is not mistaken for closed.
