# Staged Round14 browser retention

No verifier run or artifact copy has occurred. Python syntax was parsed only. Root must first confirm that all three qualified browser processes have finished.

Then run `python3 verify_retain_browsers.py` from this directory for read-only verification. Add `--retain` to copy only `result.json`, PNG screenshots and `next-server.log` into Round14 `verified-browser-artifacts` and create `retained-browser-artifacts-qualification.json`. The destination must not already exist; history is never overwritten. Other files are listed by identity as excluded, not copied.

Default run labels are `browser-qualified`, `browser-context-qualified`, and `browser-labour-qualified`; explicit label options support different recorded labels. Folder names and exact environment/runner commands are fixed to the three requested qualified folders. The script requires final exit-zero records, unchanged public/private/runtime inputs, exact source/run/log/result identities and bounded result timestamps.

`contract.json` pins the active release list and runner mapping (17), the unchanged baseline labour 12 checks, context 12+2 checks, labour lifecycle 5 checks and the corrected storage fixture. Source constants were read, not executed. Transport faults are checked by exact name/kind/resolution, actual successful upstream hash, count and zero synthetic responses. Baseline recursively requires zero mock/interception indicators. Recorded journey cleanup lists must be empty; labour also reports completed outer cleanup. Baseline/context write their result before outer cleanup, so their completed exit-zero run record is required separately. No general proof that all OS processes ceased is inferred.

The retained Round13 qualification is a format/provenance precedent; its passes are not credited to upcoming Round14 runs. This helper verifies retained evidence and never runs a browser, database, product module or subprocess. It does not replace checkpoint-wide final source equality or establish desktop/production acceptance.
