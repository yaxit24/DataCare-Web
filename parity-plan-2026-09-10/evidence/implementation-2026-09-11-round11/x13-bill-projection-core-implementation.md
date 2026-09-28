# X13 saved bill header projection: Round11 scoped proof

This slice adds the pure `projectSavedSaleReturnBill` prerequisite, version `sale-return-bill-projection-v1`. It projects a saved raw header into the source's loaded bill controls, matrix and two comparison caches. It performs no row, incoming-aggregate or bill calculation and grants no numeric write capability. It does not query masters, settings or a ledger. The API must independently resolve display-label provenance and all later calculation/observation authority.

## Source contract

The inspected primary `TR_SALE_RTN.cs:10112–10169` loads the saved header; `MSG2_CLEAR` labels at15917–15929 define the cleared nine-row, six-column matrix. The extracted and unified primary copies were checked against the pinned source hash. `DC_Main.cs:2088–2104` establishes the explicit Fnv path. This is decompiled source evidence, not original Windows/VB/ActiveX runtime execution or locale acceptance.

| Saved raw input | Loaded destination | Rule |
| --- | --- | --- |
| `NET_AMT` | `outgoingRounded` | F2 only at10112; the target property's name does not authorize whole-unit rounding during load. |
| `RTN_NET_AMT` | `incomingRounded`, `oldNetAmt` | F2 at10128–10129; the cache is canonical numeric text from the formatted **full incoming amount**, not a payment difference. |
| `TAX_PRC` | matrix[2][2], `oldTaxPrc` | F2 at10131–10132; seed canonical numeric cache from that formatted value. |
| `TAX_AMT` | matrix[2][3] | Preserve formatted manual saved tax at10133. No master-rate replacement or recalculation. |
| `TOT_AMT`, `CHQ_AMT`, `CARD_AMT`, `CASH_AMT` | Received column4, rows3–6 | F2 at10113–10116. |
| `KASAR_AMT`, `BILL_OS` | Received column4, rows7–8 | Explicit Fnv then F2 at10117–10127. |
| `RTN_TOT_AMT`, `RTN_CHQ_AMT`, `RTN_CARD_AMT`, `RTN_CASH_AMT` | Payment column3, rows3–6 | F2 at10134–10138. These are settlement fields, not an additional incoming row sum. |
| `RTN_KASAR_AMT`, `RTN_BILL_OS` | Payment column3, rows7–8 | Explicit Fnv then F2 at10139–10148. |
| `TAX_CODE`, `BANK_AC`, `CHQ_NO`, `CARD_AC` | [2][5], [4][5], [4][2], [5][5] | Saved text concatenation at10130/10155–10156/10163. Leading zeros and spaces retained. NULL displays blank while raw remains NULL. |
| Resolved tax/bank/card labels | [2][1], [4][1], [5][1] | Supplied trusted labels correspond to master name lookups10149–10169. NULL label displays blank; this pure function does not resolve missing/ambiguous identity. |

All other matrix cells remain blank, including both row1 net amount cells and row5 column2. `Payment    ` and `Received    ` each retain four trailing spaces. The eight source row captions each retain their trailing space. Unreconciled saved tax/tender/total values and both active/inactive sides remain loaded; no callback, consistency repair or phase clearing runs here.

The closing result is always `{status:'unavailable',amount:null,label:null,color:'unknown',reason:'Customer balance requires a resolved ledger mode.'}`. Unrelated saved raw opening, closing or color fields cannot provide a ledger observation or prior label history. The Round10 source addendum's complete-helper NULL/metal conversion limits remain open.

## Deliberately bounded numeric and observation profile

Every required source key must be an own observation. Missing is distinct from SQL NULL, including the four Fnv fields and four text fields. Raw and labels must contain the declared string/NULL observations. Unknown raw business fields, hidden NULL/blank values, exact Float text and microsecond timestamps are copied without interpretation.

Only `KASAR_AMT`, `BILL_OS`, `RTN_KASAR_AMT`, `RTN_BILL_OS` admit NULL/empty/ASCII-blank to zero through the explicit Fnv profile. Direct boxed-Val NULL is unsupported; direct blank text is also outside this initial plain-decimal profile. These are rollout containment decisions, not a claim that the desktop refuses every such value. No blanket DBNull-to-zero rule is introduced.

Supported numeric strings have at most128 characters, ASCII spaces only around a signed plain decimal, at most36 significant digits and18 decimal places, and absolute value strictly below1e36. Numeric controls, terminal newline/carriage return, Unicode whitespace/digits, exponent notation, separators, radix/prefix text and nonfinite values are refused before trimming or conversion. Every independent field diagnostic identifies its `sourceField`; no partial state is returned.

A private Decimal clone with precision100 handles parsing, F2 and canonical caches without JavaScript Number conversion or global Decimal configuration mutation. F2 uses the established mathematical half-up Format-intent profile; this does not prove original binary Double midpoint/locale behavior. Formatted values remain in the declared significant-digit/range domain. Signed formatted zero may remain `-0.00` while its numeric cache is canonical `0`. Raw text remains unchanged.

Ready results detach and freeze raw, state, matrix, every matrix row and closing. Unsupported results freeze the diagnostic array and each diagnostic. Caller inputs are neither changed nor frozen by the function.

## Independent literal expectations and verification

The complete literal54-cell expected matrix, all saved raw inputs, labels, cache/control expectations and source identities were authored before the implementation file existed. `x13-bill-projection-vectors-authorship.json` records that sequence. No application reducer or bill calculator computed the expected values. The portable fixture and evidence copy are byte-identical, SHA256 `3a13171acfc68e79a8b2f12e1b3169d97c85c23851bda7fed81bce49707eea8c`.

Final focused execution passed **1 file /84 tests /0 skips**,350ms overall,12ms test body. Strict NodeNext test TypeScript with `--strict --noUncheckedIndexedAccess` passed exit0. Ten direct source/test/type-dependency inputs were captured before these final checks and matched afterward. Root-owned package index exports are deliberately excluded because this focused test imports the new module directly; this is not a full workspace/build snapshot.

Meaningful vectors cover the full source matrix, retained inconsistent manual amounts, full incoming cache rather than difference, exact labels/identifiers, raw Float and microsecond preservation, all required missing-own-key cases, all twelve direct numeric NULL fields, four Fnv cases, malformed profile text, range/precision boundaries, multiple diagnostics without partial state, input/return immutability, and exact large cents under ambient Decimal precision7 with safe restoration. The large value remains `99999999999999999999999999.02`; no Number/default-precision loss is permitted.

Historical first execution is retained:84 runtime tests passed, but strict compilation found the new module/test used Decimal's default import rather than the repository's named import, and the label validation keys lacked a const tuple. Those typing corrections were applied without changing the literal fixture or projection semantics. `core-bill-projection-first-stage-inputs.json` is explicitly an after-run capture before correction, not a retroactively claimed before-run snapshot. Final execution was rerun against corrected inputs.

No DB, HTTP, browser, global build, lint coverage, original runtime or business acceptance is claimed by this scoped proof. Root integration verification is separate. Prior core modules, fixtures and frozen Round10 evidence remain unchanged.

## Source identities

| Read source | SHA256 |
| --- | --- |
| `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `unified/src/csharp/DataCareNext/DC_Main.cs` | `7ff3543a78440db0f6f18eaf442aade59a105fcb398c0ba7fd9f9c53c195a688` |
| `web/packages/core/src/saleReturnBillProjection.ts` | `881c903a3321923014eb776a2ddf583c3b2ea6232d6773f94a8d56ca7a4978b9` |
| `web/packages/core/test/saleReturnBillProjection.test.ts` | `fd2f21128607f588fe4bc4b9698345facac60196d43b6458bf0135c87832fe87` |

The companion `x13-bill-projection-core-run.json` pins the portable fixture, source/contract inputs, first and final logs, both stage records and final ten-input verification. It makes no claim about independently changing root integration inputs.
