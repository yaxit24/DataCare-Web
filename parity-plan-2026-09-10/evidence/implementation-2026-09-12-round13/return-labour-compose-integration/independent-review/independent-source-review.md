# Atomic Return labour composition — independent source review

Disposition: no confirmed blocker against the frozen23-case contract in source62405dc4662d23978581f8a8b91708f659af681c014f75848d539c0386fd9865. This reviewer authored the literal expectations before the composer existed, then read the complete implementation, its test adapter and the unchanged copy/row/aggregate dependencies. No product, fixture or test was edited. No calculator, unit test, compiler, database or browser was executed in this review.

Primary TR_SALE_RTN4248–4319 and4322–4380 distinguishes changed-code clearing from unconditional resolved-code calculation; tag categories04/05 have no copy destination but still calculate. The composer calls the unchanged copy helper, then sends its calculateAfterCopy event exactly once into the unchanged aggregate reducer (compose445–475). There is no same-code/empty-patch shortcut or cache reseeding. This retains source row→MSG_PR_TOT_FILL→BILL_TOTAL ordering at5157–5158, including UpDown skipping only the fold. The prefix case that returns labour to its original value still retains the recalculated bill-tax history.

Whole-state rollback is explicit. recoverState343–354 safely detaches a separately valid own data state; the sole refusal constructor385–404 always returns that pre-copy aggregate. The candidate462–469 changes only the selected opaque-identity row, retaining row ordinal, all other rows, raw/caches, totals/counters, bill state, outgoing total and both original journals. The aggregate constructor335–341 validates structure only; its reset journal is discarded. Row/fold/bill rejection or unexpected callback skip never publishes the candidate. Catch handling also returns the original on representation/resource failure. Returned refusal patch/event/observation are null, so a partial master copy cannot be mistaken for success.

The boundary detaches descriptor values rather than evaluating getters, rejects custom prototypes, sparse arrays, symbols/nonenumerable fields, cycles, undefined/nonfinite values and unknown command/policy/phase shapes. It freezes detached outputs only. Structural history checks preserve prior data without authenticating a historical replay. Current copy/configuration/context semantics remain the responsibility of the unchanged pure dependencies and any future trusted server adapter; matching supplied hashes are coherence checks, not fresh database authority. Missing lookup is distinct from an applied operation. No route, permission, numeric writer, help selection, session mode or closing authority is added.

Output closure is checked twice before success: the calculated state is substituted into the full next command and rechecked against the same bounded-detach/state rules, then the complete response is detached/frozen. Growing journals or duplicate response material that exceeds the profile causes an atomic refusal instead of exposing an unusable successful next state. The limit is an internal transport profile, not a desktop row limit. Reflection exceptions are contained, but JavaScript Proxy traps are not claimed side-effect-free.

The unchanged portable fixture hash fd55edb9173dbc40475d7dd04a63877226600d36c983f20b1421ab013ee73dd6 equals the pre-implementation23-case artifact byte-for-byte. The adapter compares complete expected states, both journal prefixes, raw values and untouched input, and requires detached frozen results. It calls the L01→L11 sequence and compares both independent full-state prefixes, so it does not manufacture expectations from the composer. Added cases exercise malformed command versus malformed state recovery, getters, immutability and a next-state text-budget refusal. There are53 declared cases (23 literal plus30 additional); this note supplies no executed-pass credit. Root owns the actual focused/strict/global checks and any later source correction.

The exact-decimal mathematical profile and existing unsupported branches remain qualified; this is not measured Windows Double/Format/collation equivalence or full Return acceptance. Initial runtime closing and financial writes remain outside this pure stage.

## Observed input hashes

- `/tmp/datacare-return-labour-compose-staged/required-core-export.txt` — `e723b09b8cc34a20fa9a2ef90bcfff51db130c0c3a3dc5a2d8ff0ba2b6a2643c`
- `/tmp/datacare-return-labour-compose-staged/README.md` — `8a3ef55e69e559d8c35215de8ed5bcb097ca58189b6fd044cfb4dcca9a6503ec`
- `/tmp/datacare-return-labour-compose-staged/web/packages/core/test/saleReturnIncomingLabourCompose.test.ts` — `9334a5b3f770a503c85a638949f71fb66f3493fae6d5a1a66fe6d7960f30c8fe`
- `/tmp/datacare-return-labour-compose-staged/web/packages/core/src/saleReturnIncomingLabourCompose.ts` — `62405dc4662d23978581f8a8b91708f659af681c014f75848d539c0386fd9865`
- `/tmp/datacare-return-labour-compose-staged/web/packages/core/test/fixtures/saleReturnIncomingLabourCompose.independent.json` — `fd55edb9173dbc40475d7dd04a63877226600d36c983f20b1421ab013ee73dd6`
- `/tmp/datacare-return-labour-compose-staged/dependency-verification.json` — `09fdffe0f6154e16770ade5c607952442f0a792cb9053afb016709e7cd5bca94`
- `/tmp/datacare-return-labour-compose-contract/inputs.json` — `20a8ffcfba0bad984377a15f66ac87c5728e2379da8d0cdf34bb42b4e8f66dbb`
- `/tmp/datacare-return-labour-compose-contract/implementation-contract.md` — `5f47c2adcb05b54b923274c7566e1dd23c5f4d4e933cdd03d0d12c313ff165fd`
- `/tmp/datacare-return-labour-compose-contract/literal-case-index.md` — `740a17ad85d0a578eeff84009d388630e401e23d10d25c9158a192c91b60f3d2`
- `/tmp/datacare-return-labour-compose-contract/labour-compose-independent.v1.json` — `fd55edb9173dbc40475d7dd04a63877226600d36c983f20b1421ab013ee73dd6`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/packages/core/src/saleReturnIncomingLabour.ts` — `d5e3260358a9596d6f735978f7be46379c5cb19bd7304f2e7db6763b44181b81`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/packages/core/src/saleReturnIncomingAggregate.ts` — `c356eacb0a8f3a509997eb10a56a8bb269edf3791af3909fde1326c222f8d3ed`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/packages/core/src/saleReturnIncoming.ts` — `bbc5df6568da23a75804866ab31c789b9be9850e79681d8193a82e1e3430c805`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/web/packages/core/src/money.ts` — `d6fbf799c56f4ed70e7b83006e22adeef4a23ac12f36d91abbf4b8deb0f19131`
- `/Users/yakshitsavaliya/Desktop/imodule-extracted/unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` — `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1`
- `/tmp/datacare-return-labour-compose-staged/inputs.json` — `ffce266143cb53f8bcba4cad3ade6fee7f51283f552340170fe991ea01fa6aca`
