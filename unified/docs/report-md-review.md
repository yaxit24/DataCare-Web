# Verification Correction

This report is useful but not sufficient as proof of exact rebuild parity.

Corrections verified on 2026-06-13:

- `DataCareNext.exe` has 166 manifest resources including `DataCareNext.exe.licenses`, not 165.
- The workspace/package has 36 `.rpt` files, not 37.
- `Next_1106.zip` includes both `DataCareNext.exe` and `NextDm.exe`; a full package rebuild must account for both.
- Source scanning method counts are not metadata method counts. Direct metadata shows 24,923 MethodDef names in `DataCareNext.exe` and 24,367 in `NextDm.exe`.
- The current `DataCareNext` project is not build-ready: existing logs show thousands of unresolved third-party type errors.
- The `.NET 8` project is not an exact-fidelity target for the original `.NET Framework 4.7.2` x86 WinForms application.
- Stubs are acceptable only for limited compile smoke tests. Exact UI/UX/report behavior requires the real vendor DLLs and COM runtimes.
- The source references more than 200 `.RPT` templates missing from the supplied package/root. Report workflow parity is blocked until the full original `Report` folder is recovered or missing templates are proven unreachable.

Detailed remediation plan: `docs/superpowers/plans/2026-06-13-next1106-fidelity.md`
