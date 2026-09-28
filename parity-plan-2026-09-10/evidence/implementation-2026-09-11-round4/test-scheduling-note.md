# Test scheduling correction

The first strict API test type check (`test-types.txt`) passed before the final source-blank fix. The post-fix concurrent attempt (`test-types-complete.txt`) was terminated with SIGTERM after sustained memory pressure while the production build and full API regression were also running. It is not credited as a final pass. macOS reported only 3,636 free 16KiB pages and heavy compressed memory/swap use at the diagnostic observation. Only the identified Codex-started `tsc -p tsconfig.test.json` process was stopped; user VMs/apps were not changed.

The final strict check must run separately after the full API/build complete, with its own `test-types-serial.txt` evidence. No timeout, compiler error or terminated check is converted into a pass.
