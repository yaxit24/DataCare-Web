# Feature evidence contract

Use this when freezing a feature's required cases and recording its browser validation run. Required cases come
from the desktop branches, feature contract, known regressions, T01–T18 and relevant J journeys. Neither this
schema nor the validator discovers the complete business scope: review that scope before executing it.

## Matrix and run identities

Create a matrix JSON with `feature`, `candidate` (full lowercase Git SHA), `inputsHash`, `fixtureHash`,
`settingsHash` (SHA-256 strings), and `cases`. Inputs hash identifies the exact code/dirty patch, lock, migrations,
report templates and runtime configuration; retain a sanitized manifest defining how each identity was computed.
A settings hash alone does not describe which branches were tested: enumerate those in the cases.

Each matrix case has:

- `id`: stable, unique feature/mode/scenario ID; `group`: one of T01 through T18. Each group must have at least
  one disposition; expand groups into as many cases as the source requires.
- `source`: desktop source/contract citation and the independently established expectation.
- `applicable`: boolean. False requires `reason` in the frozen matrix; retain a reviewer-readable source-backed
  explanation. Missing implementation is not N/A.
- `kind`: mutation, refusal, read-only or output.
- `requiredEvidence`: evidence names. Every applicable case requires browser and expected; mutations additionally
  require database and downstream; refusals require database proof of no business changes; output cases require
  output evidence. Add network/console/trace details to the browser artifact bundle as appropriate.

Create a run JSON with the same four identities, `matrixSha256` (hash of the exact matrix bytes), timezone-qualified
`startedAt`/`finishedAt`, `businessResponseMocks: 0`, and exactly one `cases` result per matrix ID.

Each result has `id`, `status` (passed, failed, blocked, untested, not-applicable), and for applicable cases:

- `observation`: actual business result or concrete failure/blocker; not just “OK”.
- `driver`: browser for passed cases. Source inspection, API injection or a direct module call cannot satisfy it.
- `desktopStatus`: matched, different, blocked or not-run. Source-derived expectations do not mean matched.
- `evidence`: object whose keys name artifacts; each value has `path` relative to evidence root and `sha256`.
  A file can be a sanitized index of screenshots, trace/network, intermediate calculations and DB/report diffs;
  retain and review those linked underlying files too. Hashes establish integrity, not authenticity or correctness.
- A desktop matched result additionally requires `desktopExecution: "original-windows"` and a desktop artifact
  recording the independent execution, binary/settings identities and compared outcomes.
- `transportFault: true` for declared transport-fault scenarios, with a fault artifact documenting what was
  injected and the real durable outcome. Synthetic business responses are disallowed. Record device fakes in
  observations/evidence and leave physical-device acceptance pending.

For example, one applicable case (this fragment is not a complete matrix):

```json
{
  "id": "fine-sale.sale.stale-second-save",
  "group": "T12",
  "source": "Feature contract: two operators cannot silently overwrite the same saved voucher",
  "applicable": true,
  "kind": "refusal",
  "requiredEvidence": ["browser", "expected", "database"]
}
```

The actual case must log two independent sessions loading the same voucher, the first successful save, the stale
second save's conflict, and proof that the first save's detail/stock/ledger values survived. Merely detecting a
version field in TypeScript does not satisfy it. When current behavior overwrites, record failed and its artifacts.

## Run the checker

From the repository root, with paths to the actual matrix, run record and isolated evidence directory:

```bash
python3 .kiro/skills/datacare-feature-browser-validation/scripts/validate_evidence.py MATRIX RUN --evidence-root EVIDENCE_DIR
```

Exit 0 means the bundle is structurally valid and every applicable browser case is recorded passed; exit 1 means
invalid or incomplete/failed coverage; exit 2 means unreadable/malformed input. Desktop blocked/not-run still
allows a browser-only pass, but desktop coverage stays below 100% and desktop/product acceptance stays open.

The checker rejects missing/unknown/duplicate IDs, changed matrix/identities, applicable cases relabelled N/A,
missing T groups, synthetic business responses and missing/modified required artifacts. It retains blocked and
untested cases in the denominator. Failed cases count toward execution coverage but not pass coverage.

It does not run the browser, verify the author honestly classified applicability, discover missing branches,
interpret screenshots or establish authenticity of Windows evidence. Inspect the underlying observations and
artifacts. Do not introduce this checker as an automatic product-release gate without integrating its reviewed
required set and provenance into the existing release-certification machinery.

## Verification summary for the PR

Report feature/modes in scope; candidate and input identities; exact case counts and case IDs; executed, browser
pass and desktop match coverage separately; commands with exit statuses; broken cases with reproduction steps;
blocked prerequisites; device/provider fakes; and links to sanitized evidence. Keep original failed runs when a
fix is verified. Update existing plan evidence/status fields without granting parent acceptance.
