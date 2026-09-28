# Phase A evidence — depth measurement gated (2026-07-28)

Retained because the headline parity number changed six times during this phase; anyone reading a
figure from an earlier document needs to be able to reproduce why.

## Commands

```bash
python3 project-memory/parity/test_depth_metrics.py     # parser fixtures  -> DEPTH_PARSER_OK
python3 project-memory/parity/deep_column_audit.py      # write-set audit
python3 project-memory/parity/build_parity_matrix.py    # gates + scoreboard + ratchet
```

## Measured result

| Metric | Value |
| --- | --- |
| Desktop written columns | 3,669 |
| Web written columns | 1,933 |
| Column coverage | **52.7%** |
| Desktop tables written by web | 89 of 122 |
| Tables never written | 33 (two independent methods agree) |
| Remaining column gap | 1,736 |

Gate distribution (`depth`): forms 1 passed / 83 in_progress / 22 not_started / 25 evidence_gap /
73 waived; tables 13 passed / 70 in_progress / 63 not_started.

## Parser fixes, in order, with the effect each had

| # | Idiom that was invisible | Example | Coverage after |
| --- | --- | --- | ---: |
| 0 | baseline | — | 32.7% |
| 1 | `Object.assign(header, {…})`; dynamic master/settings writers | sale settlement, `CO_SET` | 42.4% |
| 2 | factory row builders | `const header = (…) => ({…})` | 49.1% |
| 3 | paren-aware factory bodies; `return lines.map(() => ({…}))` | `KR_DETL`, `MFG_DETL` | 52.2% |
| 4 | inline object keys; `::text` cast guard | `{ CO_CODE: c, LC_CODE: l }` | 52.1% |
| 5 | dynamic `INSERT INTO "T"(${cols})`; `configs.ts` master configs | `POINT_DATA`, `TAG_STOCK`, `BAL_GR` | **52.7%** |

Fix 4 slightly *reduced* the number: the `(?!:)` guard removed false positives from `"COL"::text`
casts. Accuracy, not optimism, is the objective.

## Negative controls executed

Both mechanisms were proven to fail when they should, not assumed to work:

1. **Ratchet.** Injected a fake prior coverage of 99.9% for `TR_SALE` into `depth-baseline.json`;
   generation aborted with
   `AssertionError: depth ratchet: column coverage may never decrease -> TR_SALE: 99.9% -> 63.5%`.
   Baseline restored afterwards and generation re-run clean.
2. **Parser self-test.** Replaced `deep_column_audit.KEY` in-process with an impossible pattern;
   `run_cases()` went from 0 failures to 7, starting with
   `inline object literal: missing ['CO_CODE', 'VCH_NO']`. The generator asserts on this, so depth
   can never be computed by a silently broken parser.
3. **Phantom check.** Every column credited to the web was confirmed to exist by name in
   `web/apps/api/src`: 0 claimed-but-absent names.
4. **Determinism.** Two consecutive generator runs produced byte-identical CSV output.

## Residual measurement limits (both directions)

- Tables written through a runtime column list (`Object.keys(data)`) are flagged
  `columnListDynamic`: the write is real, the column set is not statically knowable. `TAG_STOCK` is
  the current example.
- Grid coverage (17.2%) is a **lower bound**: desktop `gridColumns` inventories include hidden state
  columns. Column coverage has no such distortion and is the gating metric.
- 25 forms have no desktop logic catalog (`evidence_gap`), so their depth is unmeasured rather than
  zero. `TR_ITM_LOT` is the known case of a catalog that looks incomplete on the desktop side.
- Column attribution is per table, not per write site; a column credited to a table is not proven to
  be written by the specific form that owns it. Per-form figures are therefore indicative, per-table
  figures are robust.
