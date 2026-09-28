# X13 trusted observation: narrow source qualification

This new static addendum preserves the frozen `x13-aggregate-trusted-observation-contract.md` unchanged. It records two independent review qualifications, not additional implementation or execution.

- The exact saved `MsAcBal` call in `TR_SALE_RTN.cs` is line10197; line10198 begins the positive-opening branch. The helper body is `DC_Main.cs:1463–1487`; line1489 starts `CurBookHelp`.
- The helper formats/converts **GoldWt and SilverWt**, as well as Amount, at1475–1477 and1483–1485. Finite monetary sum alone cannot prove the whole helper completes: a group whose relevant fine operands all yield SQL NULL can leave a metal sum NULL and an unresolved original Format/Conversions path. An amount-only mathematical opening/closing preview must be labeled partial; it cannot claim successful complete original helper or saved-open execution while those other conversions are unproved. Future source-helper acceptance needs independent eligible-group/NULL vectors for all three sums. This does not change the pure amount arithmetic or authorize metal/ledger writes.

The tax resolver implemented in this round does not execute this helper, query any ledger or resolve its DATA_TYPE mode. The prior contract's distinction between book ItmDataType and session MsDataType remains unchanged.

| Inspected source | SHA256 |
| --- | --- |
| `unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `unified/src/csharp/DataCareNext/DC_Main.cs` | `7ff3543a78440db0f6f18eaf442aade59a105fcb398c0ba7fd9f9c53c195a688` |
| `parity-plan-2026-09-10/evidence/implementation-2026-09-11-round10/x13-aggregate-trusted-observation-contract.md` | `7240e8f6b3e0ea5b25ddd98535862d6e7a8cbf50cd981caccf049ef35b707b6b` |
