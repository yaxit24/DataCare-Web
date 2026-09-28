# Exact saved Tour values — bounded independent source review

No confirmed blocker found in the inspected three-file staged correction. Source-only review: no runtime tests, compiler, DB or browser executed here. These source hashes describe the observed revision; the owner may subsequently format/freeze it.

The API removes only the Tour exclusion from the existing exact input-shaped projection. Parent matching remains tied to the same sorted saved row; child matching uses that parent's SR and child's ISR. The helper preserves NULL and emits decimal strings only where Number differs from the stored Decimal. It does not project inferred making as raw storage or change version/calculation/write rules.

The optional saved serializer path keeps the old four-argument create/Sales path. It checks retained document version, restores only serializer-owned primitive fields whose visible string exactly matches the saved value, and matches parents by saved SR and children within that parent by ISR. It does not spread unknown/raw/ledger fields or associate a newly added row by array position. Ambiguous matches refuse. Changed ordinary decimal editor strings remain exact on transport, while existing initial finite-value parsing and backend representability refusal remain in effect. NULL-to-zero/dirty semantics, master events and calculations are unchanged; this is not a general new precision writer.

The page stores a structuredClone(document) at authoritative load beside saved voucher/version/scope and passes it only when selected; the existing reset clears the selected object and its retained baseline. This prevents later alias mutation of the fetched object. Existing scope/document request guards remain in place; the correction does not claim a broader lifecycle redesign.

Current browser coverage is separately staged to challenge API JSON → actual controls → PUT wire → SQL unchanged/advance-only roundtrip with large decimals, NULL/zero and noncontiguous identities. This review alone does not establish that run passed. The fixed fixture avoids essential numeric NULLs whose calculations remain unsupported.

`/tmp/datacare-tour-exact-values/staged/web/apps/api/src/modules/sales/salesOrder.ts` SHA256 `d0c880975689647e30379bf91b2fcd46115719fa216618c5c29c1f248e67c884`

`/tmp/datacare-tour-exact-values/staged/web/apps/web/lib/tourOrderForm.ts` SHA256 `4b67a1f5de37b591eecbe6a90a5371e2d08716e694e64ff556fb8df97d3358e1`

`/tmp/datacare-tour-exact-values/staged/web/apps/web/app/(app)/txn/tour-order/page.tsx` SHA256 `71fe70a4a8580749fc04b1225970d3269b709a76f7d70662cf131724debb7113`

