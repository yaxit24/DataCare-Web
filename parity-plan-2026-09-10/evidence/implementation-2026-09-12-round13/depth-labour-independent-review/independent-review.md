# Recorded labour depth field-set comparison

The current recorded API-only set is exactly the earlier Round13 set: **106 identical `(file, interface, field)` triples**, with no additions or removals. All 168 earlier interface records are unchanged. The only new record is `SaleReturnLabourPrefixInput`, containing four fields, all counted as frontend-mentioned. Independent row sums and field-count balances agree with both JSON totals.

| Recorded observation | Interfaces | Fields | Frontend-mentioned | API-only |
| --- | ---: | ---: | ---: | ---: |
| Earlier Round13 `gap-manifest-current.json` |168|2390|2284|106|
| Labour `depth-input-labour-current.json` |169|2394|2288|106|

Thus the four additional mentioned fields are new counted contract properties; they are not four closed API-only findings. The gate remains failed at 106 against its unchanged 96 ceiling. `comparison.json` retains the complete 106-entry set, exact empty differences and the one added record. No hidden API-only replacement is concealed by equal aggregate counts.

The new properties are `baseVersion`, `rowIdentity`, `prefixVersion` and `events`, declared in `web/apps/api/src/modules/sales/saleReturnLabourReplay.ts:71–76`. The frontend names them in `web/apps/web/lib/salesReturnLabourReplay.ts:48–53` and builds them in `requestBase` at398–421. They carry the observed baseline, exact selected row, accepted prefix and ordered journal. The added module totals are sales 25→26 interfaces,576→580 fields and556→560 mentioned fields, with its 20 API-only entries unchanged. The same property spellings can count in many interfaces; this is not four new physical screen controls.

The earlier frozen-Round12 qualification records 166/2382/2278/104 and attributes the increase to 106 to `FormAuthorizationInput.adminOnly` and `SaleReturnIncomingLabourReadInput.enteredCode`. Both exact entries remain in the current 106 set. Current source corroborates their internal use: authorization policy input at `authorization.ts:96–102`; scoped master-reader input at `saleReturnIncomingLabour.ts:10–13`; the replay service derives `enteredCode` from event text/candidate and passes it internally at `saleReturnLabourReplay.ts:570–581`. This review pins that earlier qualification; it does **not** independently compare the unavailable full frozen 104-set JSON or claim a historical scanner rerun.

The scanner is `project-memory/parity/gap_manifest.py`, SHA256 `0404f2b930215b1c90dbdce0e3f4ab1fc0b0328dd28554aeeb8dbcb5150c5a35`, matching the earlier qualification and measurement-script manifest. Its actual boundaries matter:

- Lines 32–39 and 56–88 regex-match exported interfaces whose names end in `Input` or `Line`; aliases, inheritance forms and other shapes are not a complete TypeScript contract inventory. Records are keyed by interface name.
- Lines 42–53 concatenate `.ts`/`.tsx` files under frontend app/components/lib; lines 98–110 count any whole-identifier mention anywhere in that corpus. Types, comments or unrelated screens can satisfy a mention. It does not trace a request, a control or a write.
- The JSON enumerates API-only property names and all interface counts, but does not enumerate each interface's mentioned property names. Exact equality here proves the recorded 106 set and 168 common records; it is not a separate complete property-inventory proof.

Both recorded depth runs exited 1 with the same 106/96 failure. The earlier run finished 2026-09-11T22:09:01.748102Z; the labour run finished23:36:51.958741Z. Their 1802/1829 input manifests, run metadata and logs are pinned in `inputs.json`. The gate wrapper and baseline have matching hashes across both manifests and this read.

There is a real provenance limit: `gap_manifest.py` is absent from both run input manifests. This read pins its current bytes and the older independent measurement-script pin, but does not manufacture before/after run coverage for that omitted dependency. The labour run also predates the later frontend helper correction: recorded helper SHA `a5c5b4c21bf630d9fc99c86294660a2465c0d1392ee45f09f9b65cbd57139ae8`, read-time SHA `c9775c999e07f5827a9196f975aea7315da0ae275ab492f64c411f1c510a4905`. Current helper references above are source corroboration, not a remeasurement. Root plans a separately captured final scan with measurement scripts included; old evidence remains qualified and unchanged.

Only JSON comparisons, hashes and source reads were performed here. No scanner, compiler, browser, DB or application test was run, and no active workspace file was edited. Static mentions establish neither operator reachability nor functional parity, saved-value correctness or acceptance closure.

Machine-readable comparison SHA256: `b6bcb45477c1af7cea6f250c8e92370c4d1a914e9940ec2ef0ca611d85c5a7f1`.
Seventeen pinned inputs SHA256: `850b74134e54aa19b331f54b2451663fb6671411526ef5627fc3cefdf2da7b0a`.
