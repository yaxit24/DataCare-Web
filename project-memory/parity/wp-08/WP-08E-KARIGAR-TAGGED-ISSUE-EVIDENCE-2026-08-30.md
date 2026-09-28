# WP-08e — Karigar issue of an existing tagged ornament

Scope from plan §17.7. Add the existing-tag lookup for karigar issue, refuse unavailable tags, and pass the
identities into `stockRows`. Exit evidence: issuing a tagged ornament leaves INV-3 reporting signed on-hand 0 for
that identity while it is out, and the round trip issue → receive returns it to exactly 1.

Status: **DONE**, with two defects fixed beyond the stated scope and one residue recorded.

## 1. Desktop evidence

**The path is real.** `TR_KR_ISU.cs:3318` resolves the issue screen's tag availability from `MAIN_STOCK`:

```sql
SELECT A.TAG_NO, A.VCH_SRNO, B.VCH_TIME
  FROM MAIN_STOCK A LEFT JOIN BAR_DETL B ON co/lc/tag/srno
 WHERE A.TAG_NO = '<typed>'  [AND A.VCH_SRNO = <grid col 40>]
   AND B.EMP_ISU <> 'Y'
 GROUP BY A.TAG_NO, A.VCH_SRNO, B.VCH_TIME
HAVING SUM(CASE WHEN A.ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0
```

Note it sums `VCH_SRNO`, not pieces. Within a group the serial is constant, so this is
`VCH_SRNO × (count(+) − count(−))` — a presence test that works only because `VCH_SRNO > 0`, which is also why
an untagged row (`VCH_SRNO = 0`) can never be tag-issued.

**The identity is persisted on the detail row.** The karigar form has its own save routine, and it differs from
TR_PURC's shared block on exactly the two columns at issue:

- `TR_KR_ISU.cs:5109`/`:5113` — `if (grid[i,1] == "") TAG_NO = "N"; else TAG_NO = grid[i,1]`
- `TR_KR_ISU.cs:5150` — `VCH_SRNO = Val(grid[i,40])`

Grid column 40 is the serial: filled from the lookup at `:3368`, `:3464`, `:6899`, restored on reopen at
`:4766`.

**Unavailable tags never reach the detail row.** When the typed tag resolves to zero rows the desktop does not
save it — `:3320` opens the availability lookup grid (`:3322`) so the user must pick an available tag, and a
cancelled pick returns focus to the entry box. A server API has no lookup dialog, so refusing is the equivalent
enforcement of the same invariant.

**Duplicates are refused explicitly.** `TR_KR_ISU.cs:3352` shows `MsgBox "Duplicate Tag No"` when the typed tag
matches another row's column 1.

**No live-tag table is involved.** `TR_KR_ISU.cs` references `TAG_STOCK` zero times. An issued tag is recorded
solely as the signed `-` movement, which is what makes it unavailable afterwards.

## 2. What was wrong

`issueKarigar` had no tag handling at all — `resolveKarigarTagIdentitiesTx` was reachable only from the receive
and edit-receive paths. Consequences:

1. The `-` movement was untagged, so an issued ornament's signed on-hand never fell. It looked permanently held
   while physically sitting with the karigar, and `availableBarTags` would still offer it for sale.
2. `KR_DETL.TAG_NO` was `l.tagNo ?? null` — a null where the desktop writes the `'N'` sentinel.
3. `KR_DETL.VCH_SRNO` was hardcoded `0` with the comment `// literal :13188`. That citation is to **TR_PURC's**
   shared detail block; the karigar form overrides it at `:5150`. Citing the wrong form is how the divergence
   survived review.

## 3. What changed

- **`resolveLiveTagIdentityTx`** (new, `stock.ts`): `issueTagTx`'s first half, extracted. Same resolution, same
  refusals (`TagNotAvailableError`, `TagIdentityAmbiguousValidationError`), same advisory lock, but it does not
  consume the `TAG_STOCK` row. `issueTagTx` now calls it and deletes only when the source is `TAG_STOCK`, so
  sales and purchase-return behaviour is unchanged.
- **`resolveIssuedKarigarTagIdentitiesTx`** (new, `karigar.ts`): resolves each tagged issue line, refuses
  duplicates within the voucher, and returns `Map<lineIndex, serial>`.
- **`issueKarigar`** resolves identities before posting, so an unavailable tag throws before any movement is
  written.
- **`editKarigar`** resolves issue-side identities too. Without this, create would refuse an unavailable tag and
  record the identity while an edit quietly rewrote the same line as untagged.
- **`detlRows`** writes `TAG_NO` `'N'` and the real `VCH_SRNO`, with the citations corrected to `TR_KR_ISU`.

Why the read-only resolver rather than `issueTagTx`: consuming `TAG_STOCK` creates a reversal obligation —
`sales.ts:885` pairs `issueTagTx` with `restoreTagTx` at `:2318`/`:2428`, and `deleteKarigar` has no such
restore. Adding consumption without the counterpart would lose the tag row on delete. The desktop has no
`TAG_STOCK` at all here, so resolving without consuming is both the faithful and the safe choice.

## 4. Baseline corrections

- §7's tag matrix treats karigar tagging as receipt-side only. Issue-side tag handling is also desktop
  behaviour, evidenced at `TR_KR_ISU.cs:3318` and `:5150`.
- The `VCH_SRNO: 0 // literal :13188` annotation in `detlRows` was a citation to the wrong form.
- Two `DELETE_DATA` descriptions in `mfgLifecycle.db.test.ts` expected `TagNo / K-TAG-2` and `TagNo / K-TAG-3`
  for lines whose tags never existed in stock. The desktop builds that string from the stored column
  (`TR_KR_ISU.cs:5315`), so for untagged lines it reads `TagNo / N`. Corrected, and the phantom tags removed —
  they had been asserting the shape of invalid data.

## 5. Exit evidence

`test/mfgLifecycle.db.test.ts`, entirely through real module calls with nothing hand-seeded:

- karigar receipt creates the tag → signed on-hand **1**
- karigar issue of that tag → signed on-hand **0**, exactly one tagged `-` movement, `VCH_SRNO > 0`
- the `KR_DETL` row names the tag and carries the same serial
- re-issuing while it is out is refused (`not available`)
- `checkTagInvariants` reports **0** violations while it is out — out is not a violation
- receiving it back → signed on-hand **1**, still 0 violations

Second test: the same tag twice on one voucher is refused (`Duplicate tag`), and the refusal leaves the ornament
held exactly once.

Mutation checks — each fails the intended assertion:

```
issue path untagged again  → issuing it out takes signed on-hand to 0: expected 1 to be +0
duplicate check removed    → promise resolved "{ vchNo: 2, fineIssued: 9 }" instead of rejecting
```

The second mutation's `fineIssued: 9` is twice the single-line fine, confirming both duplicate lines would
really have posted.

## 6. Verification

- `155 test files / 1314 tests` pass (was 1312; +2 new)
- all three typechecks clean; `prettier --check .` clean
- release certifier unchanged at `passed=10 failed=3 skipped=1 missing=1`, with the `test` gate PASS

## 7. Residue, recorded so it is not mistaken for done

**`TAG_STOCK` is not updated when a tag is issued to a karigar.** For karigar-*created* tags this is harmless:
receive writes no `TAG_STOCK` row, so resolution goes through `BAR_DETL` and the signed sum, which the `-`
movement correctly drives to 0. But a tag created by tag-opening or purchase *does* have a `TAG_STOCK` row, and
`resolveLiveTagIdentityTx` checks that table first and returns without consuming — so after issuing such a tag
to a karigar, `issueTagTx` would still find the row and a sale could still sell it, even though the signed sum
says it is out.

Closing it properly requires deciding whether the web's `TAG_STOCK` is authoritative over the signed sum, then
either consuming on issue with a matching `restoreTagTx` in `deleteKarigar` and `editKarigar`, or making
`resolveLiveTagIdentityTx` verify the signed sum even when a `TAG_STOCK` row exists. That is a change to the
meaning of the live-tag table across every module that uses it, so it needs its own increment.
