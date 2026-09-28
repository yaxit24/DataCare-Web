# WP-06 compatibility kernel conformance evidence

**Date:** 2026-08-30
**Plan:** `EXACT-END-TO-END-PARITY-PLAN-2026-08-29.md`
**Work package:** WP-06 — compatibility kernel: scope, rights, book/account resolution, serials, dates/locks, decimal/rounding, defaults, posting/reversal plans
**Status:** adoption measured, ratcheted and gated; **WP-06 is NOT closed** — 108 rounding bypasses and 5 book-account bypasses remain, and each needs desktop evidence before it can be migrated
**Claim boundary:** this makes kernel adoption measurable and non-regressible, and proves why bulk migration would change posted money. It migrates nothing.

## 1. The finding that reframed the work package

WP-06 reads as "build the kernel". Measuring first showed the kernel largely **already exists**:

| Concern | Kernel primitive that exists | Modules bypassing it |
| --- | --- | ---: |
| Decimal/rounding | `packages/core/src/money.ts` — exact-decimal `round` (half-up, away from zero) and `roundHalfEven` (.NET `Math.Round` default); `modules/shared/roundingPolicy.ts` — the per-company `TAX_ROF`/`LBR_ROF`/`TOT_AMT_ROF` flag policy | **108 local helpers in 69 files** |
| Book/account resolution | `bookPolicy.resolveBookAccountTx`, `postingAccounts.resolveBookSlotAccountTx` (both fail closed) | **5 inline `BOOK_DETL` reads** |
| Posting accounts | `postingAccounts.requirePostingAccount` (WP-02D) | 68 literals, already ratcheted |

Adoption of the money kernel is 6 imports (`round` ×2, `roundHalfEven` ×4) against 108 private reimplementations. So the gap is not construction, it is **adoption**, and nothing measured it.

## 2. Why 108 local `round2` helpers are a correctness problem

Every one takes the shape `Math.round((n + eps) * 100) / 100`, with **two different epsilons** in circulation — `Number.EPSILON` (57 sites) and `1e-9` (33 sites) — which is itself the fingerprint of someone hitting a case and enlarging the fudge.

Measured against the kernel, there are two distinct defect classes:

**Class A — negative midpoints, all 108 helpers.** JavaScript's `Math.round` breaks a negative tie toward `+∞`; .NET half-up breaks it away from zero.

| Value | local helper | kernel `round` (desktop `Strings.Format`) |
| --- | ---: | ---: |
| `-1.005` | `-1` | **`-1.01`** |
| `-0.125` | `-0.12` | **`-0.13`** |
| `-0.5` at 0dp | `-0` | **`-1`** |

Negative midpoints are reachable: kasar, round-off, credit notes, signed metal legs, and any `CR − DR` difference.

**Class B — wrong mechanism.** The local helpers implement half-up. The desktop uses half-up at its 20,575 `Strings.Format` sites but **half-to-even at its 10,306 `Math.Round` sites**, and the two disagree on every positive midpoint: `1.005` → `1.01` half-up versus `1` half-to-even; `0.125` → `0.13` versus `0.12`.

A third measurement corrected my own assumption mid-work: `roundingPolicy.roundNearest` implements **both** desktop mechanisms and selects between them by whether the company **configured** the flag — ties-to-even when configured, half-up when defaulted — and it rounds away from zero on both branches, because it applies `Math.sign` outside the rounding. So the kernel is right and the 108 local helpers are the sole outlier. My first draft asserted the opposite and the test caught it.

Away from a midpoint all three agree, which is exactly why the divergence has stayed invisible.

## 3. The book-account bypasses are not lazy duplication

Two of the five are byte-identical private copies of `resolveBookDetlAccountTx` in `repairKarigarReceipt.ts` and `repairCustomerIssue.ts`. The obvious WP-06 move is to delete them and call the shared resolver. **That would be a regression.**

The private copy accepts a `BOOK_DETL` row whose `LC_CODE` is the current location **OR `'00'` OR NULL**, preferring the current location by priority. `resolveBookSlotAccountTx` requires an exact `LC_CODE` match. Consolidating would make every book configured with a `'00'` row start failing closed.

The fix therefore runs the other way — the kernel must absorb the location fallback — and that first needs a desktop-evidenced decision that `'00'` rows are valid. Turning a fail-closed resolver into a more permissive one on the strength of one module's comment is precisely the guess WP-02D removed from the posting paths. Pinned as a test so the "cleanup" cannot happen by eye.

## 4. What was built

- `apps/api/src/modules/ops/kernelConformance.ts` — concern-based bypass detection with a ratchet. A concern names the kernel primitive **and the correctness reason**, so a report is actionable rather than a scold.
- `scripts/check-kernel-conformance.mjs` — gate; `--list` prints every bypass with `file:line`.
- `apps/api/test/kernelConformance.test.ts` — 12 tests.

Detection distinguishes a **reimplementation** from a **use**: `const round2 = (n) => Math.round(...)` is a private kernel copy, `const total = Math.round(x)` is arithmetic. Counting both gave 139 and would have made the number meaningless; counting only function-valued bindings gives 108. Broadening from arrow-only to block-bodied functions moved the count from 105 to 108, so the ceiling is the measured value, not the first guess.

## 5. Exit evidence

```
kernel conformance across 191 source files
  rounding       108 bypass(es) in 69 file(s), ceiling 108
  book-account     5 bypass(es) in  5 file(s), ceiling 5
KERNEL_CONFORMANCE_OK adoption has not regressed
```

The 12 tests cover: the negative-midpoint divergence (Class A), the half-up versus half-to-even divergence (Class B), both branches of the flag-driven policy, agreement away from midpoints, helper-versus-use detection, kernel-file exemption, the repair resolver's richer semantics, the pinned counts, and a regression case proving the ratchet fails when adoption slips.

Commands: full suite **153 files / 1292 tests passing**; `tsc` clean for api source, api tests and web; `prettier --check` clean. `kernel-conformance` added to `RELEASE_GATES` and reads **PASS** (`passed=10`).

## 6. Why nothing was migrated

Swapping a local helper for the kernel changes posted values at midpoints, and **which** kernel function is correct depends on whether the desktop produced that particular figure with `Strings.Format` (half-up) or `Math.Round` (half-to-even). That is a per-formula question, answered by a contract and pinned by a golden vector — WP-05 work. There are 108 sites and 27 golden vectors; the mapping does not exist yet.

Migrating on a guess would change money on 69 files' worth of arithmetic with no desktop evidence per site, which is the exact failure mode this plan exists to prevent. The ratchet means no new bypass can appear while that evidence is gathered.

## 7. What remains for WP-06

- 108 rounding sites: each needs its desktop mechanism identified, then migration to `round` or `roundHalfEven` (or the flag policy where a company setting governs the precision), with a golden vector per formula.
- 5 book-account sites: needs a decision on whether `BOOK_DETL` rows with `LC_CODE='00'`/NULL are valid, then the kernel absorbs the fallback and the repair modules adopt it.
- The kernel's other named concerns — scope, rights, serials, dates/locks, posting/reversal plans — have primitives (`enforceRequestScope`, `authorizeForm`, `nextVoucherNoTx`, `postVoucherTx`, `reverseVoucherTx`) whose adoption is not yet measured. The same concern-based audit extends to them; each addition needs its own bypass pattern and a correctness reason, which is why they were not added speculatively.

## 8. Files

- `web/apps/api/src/modules/ops/kernelConformance.ts` (new)
- `web/scripts/check-kernel-conformance.mjs` (new)
- `web/apps/api/test/kernelConformance.test.ts` (new)
- `web/apps/api/src/modules/ops/releaseCertification.ts` — `kernel-conformance` gate added
