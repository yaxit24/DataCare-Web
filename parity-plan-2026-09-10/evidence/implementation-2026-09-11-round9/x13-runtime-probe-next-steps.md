# X13 primary Incoming Return runtime probes — prospective next steps

This is a read-only prerequisite assessment. No .NET executable, compiler, ILSpy command, test, database or desktop application was run for this note. No installation or product change was made. Shell path/file inventory, source/evidence reading and file hashing were the only operations. Proposed results below are distinctions to measure, not executed acceptance.

The next useful work is a small, typed scalar probe harness that preserves the original VB call overloads and expression order. It can resolve several currently contained saved-projection cases without loading the jewellery form or touching business data. The original-runtime result still needs the matching Windows .NET Framework deployment; the installed macOS .NET8/10 runtimes can supply comparison results, not substitute for it. TextBox/ActiveX event behavior is a separate Windows-control stage.

## 1. Local inventory actually observed

| Item | Read-only observation | Usable boundary |
| --- | --- | --- |
| PATH `dotnet` | `/opt/homebrew/bin/dotnet` links to Homebrew10.0.300. SDK directory10.0.300 and `Microsoft.NETCore.App/10.0.8` exist under `/opt/homebrew/opt/dotnet/libexec`. | A modern managed comparison harness could be built later without installing an SDK. No executable/version command was run here. |
| User-local .NET | `~/.dotnet/dotnet`, SDK8.0.422, `shared/Microsoft.NETCore.App/8.0.28` exist. | Independent modern-runtime comparison target, not the original Framework implementation. |
| Managed compilers | Roslyn `csc.dll` and `vbc.dll` exist in both SDKs' `Roslyn/bincore` directories. | File presence only; no compile was attempted. |
| VB/Data assemblies | Both runtime trees contain Microsoft.VisualBasic.dll, Microsoft.VisualBasic.Core.dll, System.Data.dll and System.Data.Common.dll. | Preserve which implementation actually loads. A modern facade/implementation is not the historical Framework DLL. |
| ILSpy | `~/.dotnet/tools/ilspycmd` exists. Round7 records successful ILSpy10.1.0.8386 under runtime10.0.8 with an explicit DOTNET_ROOT. | Prior static extraction is reusable; it did not run the desktop. No new IL extraction occurred here. |
| Framework references | NuGet cache contains `microsoft.netframework.referenceassemblies.net472/1.0.3`, including reference mscorlib, Microsoft.VisualBasic and System.Data assemblies. | Useful compile-time metadata/reference assets. Their presence does not supply an original executable .NET Framework runtime on this Mac. |
| Windows interop assets | `unified/libs/interop/AxInterop.MSFlexGridLib.dll`, `Interop.MSFlexGridLib.dll`, and `unified/setup_installer/Support/MSFLXGRD.OCX` exist. | These are actual local assets to pin for a later Windows-control probe; presence is not registration, licensing or successful control activation. The nearby msvbvm60.dll is not evidence of a .NET Framework VB implementation. |
| Other runtimes/tools | No mono, mcs, csc, vbc, vbnc, msbuild, xbuild, ilasm, ildasm, monodis, wine/wine64 or PowerShell command was found on PATH. Known `/Library/Frameworks/Mono.framework`, Homebrew mono, `/usr/local/bin/mono`, Wine Stable.app and CrossOver.app locations were absent. | This is a bounded inventory, not proof no alternate installation exists anywhere. No install or emulation was attempted. |

`DataCareNext.exe` is present and its pinned hash matches the original Round7 input. Static byte inspection found the CLR metadata version text `v4.0.30319`, `.NETFramework,Version=v4.7.2`, `TargetFrameworkAttribute` and the associated Framework display-name text. Reconstructed source projects specify net472, x86 and Prefer32Bit. These corroborate a Framework/x86 target, but do not identify the installed Windows patch level, actual loaded assembly files, binding redirects or JIT behavior of the business deployment. `DataCareNext.exe.config` was not present beside the root executable. The old `extraction_output/DataCareNext_dotnet_metadata.json` contains assembly-reference parser errors and an N/A assembly name; do not use it as successful binding evidence.

The primary C# tree search found no explicit CurrentCulture/CurrentUICulture/DefaultThreadCurrentCulture/CreateSpecificCulture/NumberDecimalSeparator/SetThreadLocale assignment. That negative search does not establish the actual desktop culture: startup configuration, runtime/control behavior and deployment settings must still be captured.

## 2. What is already resolved, and what is still a runtime question

Round7 original-assembly IL conclusively identifies the decompiler's single-index members as `AxMSFlexGrid.get_ColWidth`: LeaveCell IL_0038 and Fine-basis IL_0661. The apparently competing default-width assignment is `set_ColAlignment`, not another width write. Effective source column configuration is now resolved/versioned by the API. Do not spend a new numerical probe proving those member names again or infer Fine visibility from its value.

The still-qualified boundary is the conversion/format implementation surrounding the exact source expressions:

- Saved load10353–10438 calls `Conversion.Val` on boxed DataTable values before `Strings.Format`; PCS10376 uses `Conversions.ToString` directly. SQL NULL, boxed Decimal scale, Float rendering and text concatenation are distinct inputs.
- EnterCell4538–4541/4561–4575 presents two-decimal editor text; LeaveCell4607–4660 formats again and invokes calculation. A three-decimal calculated visible percentage is not the same object as its next editor text.
- Calculation4866–5156 mixes binary Double operations, explicit `Math.Round`, `Strings.Format`, subsequent `Val` comparisons and occasional `Conversions.ToString(Val(...))` cache writes. Reordering the arithmetic or collapsing rounding stages can change a result.
- `DC_Main.OpenRecordSetDc`:1232–1239 uses a fresh DataTable and SqlDataAdapter.Fill. The saved query10353 selects A.* plus B.RATE_TYPE/B.IT_TYPE even though A already declares those columns. The name-binding result remains unmeasured.
- The source calls aggregate callbacks5157–5158 after row calculation. A scalar probe must stop before those effects and must never be presented as testing bill/refund/stock/ledger behavior.

The current web implementation deliberately uses exact Decimal cell text with half-up formatting, explicit half-even source Math.Round sites, strict plain-decimal editor parsing and recoverable refusal. It preserves raw values independently and contains unproved numeric NULL/type binding. None of the proposed probes authorizes changing those policies automatically.

## 3. Smallest harness that can answer useful questions

Keep one small console program with a fixed input JSON file and a JSONL result writer. It should reference only the required VB runtime, core CLR and Data assemblies. Do not load/instantiate the original executable, use an uninitialized TR_SALE_RTN object, provide fake ActiveX classes, or suppress original callbacks and label that desktop execution.

Define inputs by both **value and CLR type**: String, Decimal, Double, Int32, DBNull.Value and null. Construct Decimal values from invariant text without an intervening Double, then call exactly the source-selected overload. Capture both the direct source expression and, where useful, explicitly labeled intermediate diagnostics. Instrumenting an inline Double expression with extra stores can itself affect legacy precision; the uninstrumented final expression remains the comparison result.

Record for every run: target framework; runtime/process bitness; OS/architecture; actual loaded mscorlib/System.Private.CoreLib, Microsoft.VisualBasic implementation and System.Data assembly names, versions, file paths and hashes; compilation/debug/optimization settings; culture and UI culture names, decimal/group separators; exact escaped input text/type; exact output text/type; binary Double bit pattern where applicable; exception type/HResult/message and the precise failed stage. JSON numbers must not carry the financial observation; emit strings and explicit type tags.

Use the same checked-in input and harness source hashes across these distinct stages:

1. **Portable comparison, no original-runtime credit:** installed .NET8 and10 console runs, when separately authorized. This catches harness/output defects and identifies modern-runtime differences. It does not establish Framework4.7.2 behavior.
2. **Original-family scalar run, no form required:** Windows x86 console targeting the recorded Framework deployment, with actual runtime implementation/patch files captured. It can establish VB scalar conversion, formatting, rounding and exceptional arithmetic independently of ActiveX. A net472 target can run on a later installed in-place Framework update; record the actual implementation rather than treating the target label as sufficient.
3. **Provider-specific read probe:** the same original-family runtime with System.Data.SqlClient and an isolated SQL Server fixture, to resolve DataAdapter duplicate names and database-derived CLR types. A generic in-memory DbDataAdapter/IDataReader test is useful first, but is not the concrete SqlDataAdapter/SQL Server result.
4. **Windows control probe:** actual Windows Forms TextBox and the pinned registered MSFlexGrid ActiveX control for event order, MaxLength, focus/visibility and grid text behavior. This stage does not need financial writes. The real application/form workflow, reports, source admission and business acceptance remain later, separate exercises.

## 4. Exact proposed scalar/provider probe inputs

`F2/F3` below mean the literal source `Strings.Format((object)Conversion.Val(value), "0.00"/"0.000")` with the correct overload; they are not aliases for a newly invented formatter. The web-side distinctions are current mathematical-policy expectations, not observed desktop values.

| ID / source | Proposed exact inputs and operation | Distinction to record; allowed conclusion |
| --- | --- | --- |
| RT01 — saved numeric10377–10417 | For each of `DBNull.Value`, null, String empty, String spaces, Decimal0, Double0 and String"0", run the boxed-object Val→F2/F3 path separately. Also run text concatenation with an empty string and direct Conversions.ToString. | Record return value versus exception and the first failed call. Establish only the measured typed cases. Raw SQL NULL must not be inferred equivalent to a deliberately empty editor merely because a different input yields0. |
| RT02 — saved/LeaveCell formatting | String and boxed Decimal/Double inputs `1.005`, `-1.005`, `2.675`, `-2.675`, `1.225`, `1.2345`, `-1.2345`; apply F2/F3. Controls: explicit Math.Round on12.5,13.5,-12.5,-13.5 at precision0, then F2. | Web F2 half-up examples are1.01,-1.01,2.68,-2.68; F3 of±1.2345 is±1.235. Measure whether source boxing/binary/mode/culture differs. Exact binary half-even controls distinguish12 versus13 and14 versus13; passing controls does not settle nonbinary decimal ties. |
| RT03 — configured rounding4963/5024/5044 | Literal `Strings.Format((object)Math.Round(value,3),"0.00")` with String→Val value1.2449, plus configured0/1/2 controls and positive/negative partners. Compare the uncollapsed source sequence with single F2 only. | Mathematical two-stage1.2449→1.245→1.25 differs from one-stage1.24. Record actual Framework intermediate/final text; retain a demonstrated two-stage rule even if some binary input falls on another side. |
| RT04 — K metal4949/4952, tag5044 | Preserve exact inline order `1500 * (1001 / 1000.0)` before Math.Round0/F2; compare separately labeled regrouping `(1500*1001)/1000.0`. Also run exactly representable12.5*(1000/1000.0). | Exact Decimal first case is1501.5 and half-even whole result1502. Prior static/binary discussion identified a possible1501.4999999999998 path; do not pin that as a Windows result. Capture architecture/JIT and inline output; diagnostic temporary stores are not assumed neutral. |
| RT05 — direct PCS10376 and precision | Box Decimal with scale `1.250`, `0.000`, `999999999.999`; compare direct Conversions.ToString with the numeric F0/F3 paths. For rate use Decimal and String `9999999999999999.99`, and representable large/scientific Doubles for hidden instance text. | Distinguish retained Decimal scale from integer rounding and binary conversion loss. Current web raw strings remain exact even if original display loses precision. A display observation never authorizes rewriting preserved raw amounts or identity. |
| RT06 — residual5080, cache5108 | Evaluate source residual `99.999 - 100.00`, F2, then Val(formatted)<0 and Val(formatted)!=0. Also run exact String"-0.00", Double negative zero and `Conversions.ToString(Val("2.00"))`. | Measure negative-zero spelling independently from its zero comparison; the source numeric less-than-zero must not be replaced by a sign-bit predicate. Distinguish cache"2" from"2.00" without assuming culture-independent ToString. |
| RT07 — source parsing versus strict web | Val on exact strings `""`, `" "`, `"12tail"`, `"1,25"`, `"1.25"`, `"&H10"`, `"&O10"`, `"0x10"`, `"1e2"`, `"NaN"`, `"Infinity"`, and a string containing a tab. Repeat Val→F2→Val. | Record prefixes/bases/exceptions and roundtrip changes. Do not silently broaden web input acceptance when legacy Val accepts a prefix; strict rejection is a separate deliberate policy. |
| RT08 — exceptional division4996–5017/5051–5063/5120–5150 | Typed Double1/0,0/0 and source-formatted Math.Round/Format/Val chains; row-shaped scalar expressions for nonzero manual labour with zero P/N/G basis, N net1+ghat-1, and tax-100. Execute each stage independently after a captured failure. | Establish whether/where Infinity, NaN, special text or exceptions arise. Do not invent a final grid value or assume primitive Double behavior equals the complete format/reparse path. Web recoverable422 remains until explicitly reviewed. |
| RT09 — culture-sensitive roundtrip | Run RT01–08 under invariant, en-US, en-IN and one decimal-comma culture such as de-DE, with explicit culture capture. Include source manual-total original text130.004 versus computed130.00 and editor re-entry from visible20.000. | Separate arithmetic from formatted separator/text reparsing and original editor comparisons. A different culture result does not establish which culture the deployed desktop used; no explicit assignment was found in the inspected source tree. |
| RT10 — setting conversion, source MS_OPNCOMP691/817–819/1297–1303 | Box Double values2,2.5,-1,2147483647,2147483648, DBNull and empty text through the actual Int32 conversion before the >3 and final Y overrides. Capture conversion failure before attempting a later branch. | Resolve conversion/overflow ordering, not a guessed clamp. A final rounding override cannot retrospectively erase an earlier conversion exception. The existing resolver's strict representability profile stays explicit. |
| RT11 — duplicate source columns10353/10421–10424 | Reader schema in exact query order: A.RATE_TYPE="N", A.IT_TYPE="G", B.IT_NAME="Master", B.RATE_TYPE="P", B.IT_TYPE="D"; then A.NULL/B.nonNULL, missing B, and two matching B rows. Record every resulting DataColumn ordinal/name/type, every value, unsuffixed name lookup and row count. | This directly distinguishes A ownership, B overwrite or renamed duplicate columns without guessing suffix rules. An in-memory DbDataAdapter test proves only its path. Repeat the actual `SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE` through original System.Data.SqlClient against an isolated SQL Server fixture before removing the API agreement/ambiguity restriction. No ActiveX is needed. |

For RT11, use explicit aliases only in the **diagnostic comparison query**. The primary probe must retain the original duplicate names and column order. Do not substitute PostgreSQL/Prisma object construction, `DataTable.Load`, a dictionary with duplicate-key overwrite or a modern Microsoft.Data.SqlClient package and describe the result as the original SqlDataAdapter.Fill behavior. Include SQL field types/scale and reader GetFieldType/GetName/GetOrdinal observations; source `ITM_PCS` arrives as a typed database value, not the SQL-text DTO used by the web.

## 5. Probes that need Windows controls or the actual desktop workflow

| ID / dependency | Bounded proposed observation | What a console scalar harness cannot establish |
| --- | --- | --- |
| WC01 — TextBox MaxLength | In a real Windows TextBox set MaxLength10, programmatically assign exact"9999999999999999.99", then separately type, paste, replace-all with"100", press Tab/Enter and reopen. Capture Text, SelectionStart/Length and events. Source4538–4541/4561–4575 sets MaxLength then assigns formatted text. | Whether programmatic assignment, user typing and pasted replacement have the same limit. Current web preserves full loaded text, rejects overlong submitted journal text and permits short correction; this remains a stated difference pending control observation. |
| WC02 — grid/edit event chronology | Use the actual pinned AxMSFlexGrid/TextBox pair with visible and configured-zero-width columns. Capture EnterCell/LeaveCell, focus, editor Visible/ReadOnly, active row/col and unchanged same-value commits. Include a second row, hidden destination and rapid focus transitions. | Whether the actual form emits the same ordered commits as a completed-LeaveCell web profile. Replacing the grid with a string array tests a clone, not ActiveX event behavior. The ColWidth member identity itself is already established by IL. |
| WC03 — exceptional handler continuation | After scalar probes identify a failing format/reparse input, use an isolated form state to observe whether the real handler aborts, displays an error, changes cells already written, or continues to aggregate callbacks. | The source's surrounding exception/UI behavior and partial control updates cannot be inferred from a scalar exception alone. Do not apply this to customer records or execute an unbounded save workflow. |
| WC04 — complete application acceptance | Later use the supported Windows deployment and disposable source fixtures for load, calculation, F1/whole-import, tags/children, save, reports, undo/delete and financial/stock reconciliation. | Dependencies, registration/licensing, application globals, DataAdapter source admission, callback totals and real workflow correctness. Passing the smaller probes supplies evidence for specific conversions only. |

Local OCX/interop files do not make these controls executable on macOS. No Wine/Mono installation or placeholder control is proposed as an original-desktop acceptance shortcut. A minimal Windows console is sufficient for scalar/ADO behavior; full Windows desktop/ActiveX is necessary only for the control/form questions above.

## 6. Next implementation order and release rule

First produce the typed input/result schema and the small console source as a separate evidence tool, with no reference to the web reducer as an expected-value generator. Review literal expressions and overload selection against source and existing IL. Begin with RT01/RT02/RT05/RT11 because they directly govern currently contained saved rows; RT03/RT04/RT06/RT08 then calibrate arithmetic boundaries. Modern local comparison can validate the harness protocol, while original Windows execution remains a separately labeled artifact.

For any measured difference, add an independent immutable vector with source line, input CLR type, runtime/assembly hashes, exact text/exception and its scope of validity. Decide whether to reproduce the source display, retain a documented web difference, or continue containment. Preserve raw snapshots and existing mathematical fixtures; do not rewrite historical expectations or automatically remove all numeric-NULL/master/precision gates after one successful example. Any later adapter change needs focused projection/replay/HTTP tests and zero-write regression, followed by the usual root checkpoint.

No runtime, original-desktop, business or complete-parity acceptance is claimed by this document. The scalar/provider/control stages are intentionally distinct so the next implementation can close a measured prerequisite without overstating the result.

## 7. Read-input hashes

The following table is appended by read-only hashing of the inspected local artifacts. Runtime filenames/directories were inventoried without executing them; a later harness must record the assemblies actually loaded by its own process.

Captured UTC: 2026-09-11T12:44:46.333677+00:00

Paths are relative to the web workspace unless absolute.

| Artifact | SHA256 |
| --- | --- |
| `../DataCareNext.exe` | `c85f93fd336853a2a639c6452b47748290a1dddb214e2fdf3fc78f47bc0ca6c8` |
| `../unified/src/csharp/DataCareNext/TR_SALE_RTN.cs` | `cdee9c37772522727d08c86baee71a46daa7b11cdfdf2eeb1ef656d80dfbb7a1` |
| `../unified/src/csharp/DataCareNext/DC_Main.cs` | `7ff3543a78440db0f6f18eaf442aade59a105fcb398c0ba7fd9f9c53c195a688` |
| `../unified/src/csharp/DataCareNext/MS_OPNCOMP.cs` | `180f295f9595dfc7c28ee34629563889c943eea0a0afc7c7a9baa519a11c4561` |
| `../unified/src/csharp/DataCareNext.csproj` | `6167930b9421e460f57ca4c19cbeddd7d11169384e4d2bd20d7db7eb1ddc1f27` |
| `../unified/database/schema/01_Schema.sql` | `1eb684c7e2bec72a330a9038a2da72ffea669b3ae7ef50b85b34e0e3126efa0d` |
| `../unified/libs/interop/AxInterop.MSFlexGridLib.dll` | `9b5908f8db5ce06ef395bdb4495e05f0effae78e0fc135c3224ab4feaa09ed4e` |
| `../unified/libs/interop/Interop.MSFlexGridLib.dll` | `b328195f8285b2dde61a3fc3ca49061784b3e7216ea0489fc2ed3f201209ab68` |
| `../unified/setup_installer/Support/MSFLXGRD.OCX` | `4e592240b745546c15e95e26b2547cec86352a49ee1ef79b3e3d28df8b5a0e70` |
| `../extraction_output/DataCareNext_dotnet_metadata.json` | `9acd94884f4f48b70e7c75ca38003c0ebc2ab40a2de6b79418af1364138d30de` |
| `packages/core/src/saleReturnIncoming.ts` | `bbc5df6568da23a75804866ab31c789b9be9850e79681d8193a82e1e3430c805` |
| `packages/core/src/saleReturnIncomingProjection.ts` | `3f3b9ac1e937f1adfbf535283cd66701438b791a24ed691d641c573f63e9d96e` |
| `packages/core/src/money.ts` | `d6fbf799c56f4ed70e7b83006e22adeef4a23ac12f36d91abbf4b8deb0f19131` |
| `../parity-plan-2026-09-10/evidence/implementation-2026-09-11-round7/x13-incoming-calculation-contract.md` | `3a60edd05ab8837cfffe24283c45e2a91a1421d1ba9cc771b22d9aba756fb5c0` |
| `../parity-plan-2026-09-10/evidence/implementation-2026-09-11-round7/x13-calculation-contract-independent-review.md` | `e2a7c2704d0c7290d7007f1a6be2e33a99a7dbebabfcd3cff90d0f8323699835` |
| `../parity-plan-2026-09-10/evidence/implementation-2026-09-11-round7/x13-calculation-il-review-excerpts.txt` | `8c60e56122820e7fc18cb35aed07188f5016f185ed1d219f7661566facf09144` |
| `../parity-plan-2026-09-10/evidence/implementation-2026-09-11-round9/x13-next-server-replay-contract.md` | `c01e0a6d59dfaa6bd634a945148d3cb97e8e97486668bfafc503e1fbe9c17dcd` |
| `../parity-plan-2026-09-10/evidence/implementation-2026-09-11-round9/x13-projection-core-implementation.md` | `d6bd519f022b4f46ee6e653bd5ccff81b886ba5ad1210713ed03aa5b9097fcb0` |
| `/opt/homebrew/opt/dotnet/libexec/shared/Microsoft.NETCore.App/10.0.8/Microsoft.VisualBasic.Core.dll` | `4bee02836dc62d02ced58a01446cab7bbd42c2037a9bbad2acd74b7f0188a1a9` |
| `/Users/yakshitsavaliya/.dotnet/shared/Microsoft.NETCore.App/8.0.28/Microsoft.VisualBasic.Core.dll` | `b5070e998ad7f16d216ddf391f6df64877a66b34cfe4c0f156cdbf22cce27e6a` |
| `/Users/yakshitsavaliya/.nuget/packages/microsoft.netframework.referenceassemblies.net472/1.0.3/build/.NETFramework/v4.7.2/Microsoft.VisualBasic.dll` | `3c081b0f0d48526d63994e15b9152ca8ce255168387e37f113d9b3644b4bfe58` |
| `/Users/yakshitsavaliya/.nuget/packages/microsoft.netframework.referenceassemblies.net472/1.0.3/build/.NETFramework/v4.7.2/System.Data.dll` | `05e52f1129985102e1ec22cb8664246af2d9c1737b0d8ef556278503a23aa430` |
