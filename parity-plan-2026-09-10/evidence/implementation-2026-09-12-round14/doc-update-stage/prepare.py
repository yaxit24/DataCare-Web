from pathlib import Path
import ast
import difflib
import hashlib
import json

ROOT = Path('/Users/yakshitsavaliya/Desktop/imodule-extracted')
OUT = Path('/tmp/datacare-round14-doc-update')
PLAN = 'parity-plan-2026-09-10/'
EVIDENCE = PLAN + 'evidence/implementation-2026-09-12-round14/'

def sha(data):
    return hashlib.sha256(data).hexdigest()

def dump(path, value):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(json.dumps(value, indent=2) + '\n')

bar = '''The integrated core `saleReturnNBarCompanions.ts` projects and compares all 12 BAR_DATA header targets and 70 final BAR_DETL parent targets. The parent map follows 74 ordered desktop assignments, including overwritten values and branch alternatives. The [frozen fixture and implementation stage](evidence/implementation-2026-09-12-round14/bar-companion-integration/frozen-stage/ready-manifest.json) contains 22 independently authored complete before/after cases. The [independent review](evidence/implementation-2026-09-12-round14/bar-companion-independent-review/implementation-read-review.md) compares all 44 phases with the primary source.

The two inclusion predicates remain distinct. The parent requires a nonblank tag and nonzero sum of row pieces, net weight and net amount; literal N and literal 0 are both nonblank in the source. The header uses the supplied full 71-cell incoming totals: total MRP is nonzero, or total pieces plus net weight plus Other amount is nonzero. It does not recompute those totals from the row. Other=-11 can remove the header while the N parent remains. The source's inner blank-tag-to-N default is unreachable under the parent guard. Allocation from a zero instance is reported unsupported, not synthesized.

`matchSaleReturnNBarCompanions` accepts complete 63-cell before/after rows, actual totals, separately qualified 16-field context and exact observed physical rows. The finite N/SR1 profile requires unchanged companion membership and all mapped values, exactly one matching header and parent, and consistent tenant, scope, voucher, instance, ordinal and raw physical identity. It preserves original raw strings, NULLs, unowned fields and observation tokens; numeric equality does not rewrite stored scale. Unsupported phases retain independently valid sibling projections. Every result, including matched, has `canCommit:false`. Caller-supplied qualified context or hashes do not authenticate data or grant Save authority. Date/clock/user target strings remain explicit unresolved adapter inputs: the fractional timestamp fixture is a supplied placeholder, not proof of the saved-open whole-second Windows conversion or date-versus-text schema representation.

The staged 61 focused cases and strict compiler pass are retained with their initial compiler-only closure-narrowing correction. After repository formatting, the [integrated core run](evidence/implementation-2026-09-12-round14/core-final.run.json) again passes all 61 BAR cases, and the [integrated strict test compilation](evidence/implementation-2026-09-12-round14/core-final-test-types.run.json) passes. The [integration record](evidence/implementation-2026-09-12-round14/bar-companion-integration/integration.json) distinguishes staged and formatted hashes. These are pure projection/matching checks, without BAR SQL, a numeric endpoint, a writer or changes to existing preview guards. Complete trusted replay, source context, Save guards and every financial/companion effect remain prerequisites below.'''

draft_path = Path('/tmp/datacare-round14-plan-review/proposed-draft.md')
draft = draft_path.read_text()
assert draft.count('BAR_STATUS_PLACEHOLDER') == 1
assert draft.count('VERIFICATION_PLACEHOLDER') == 1
filled = draft.replace('BAR_STATUS_PLACEHOLDER', bar)
assert filled.replace(bar, 'BAR_STATUS_PLACEHOLDER') == draft
assert filled.count('VERIFICATION_PLACEHOLDER') == 1
progress_path = OUT / '40-implementation-progress-round14.md'
progress_path.write_text(filled)

changes = []
diffs = []
def replace_file(path, replacements):
    original = (ROOT / path).read_text()
    result = original
    ops = []
    for old, new in replacements:
        assert old != new and result.count(old) == 1, (path, old[:100], result.count(old))
        result = result.replace(old, new, 1)
        ops.append({'old': old, 'new': new, 'expectedOccurrences': 1})
    target = OUT / 'staged' / path
    target.parent.mkdir(parents=True, exist_ok=True)
    target.write_text(result)
    changes.append({'path': path, 'baseSha256': sha(original.encode()),
                    'resultSha256': sha(result.encode()), 'replacements': ops})
    diffs.extend(difflib.unified_diff(original.splitlines(True), result.splitlines(True),
                                    fromfile='a/' + path, tofile='b/' + path))
    return result

def line_start(path, prefix):
    matches = [line for line in (ROOT / path).read_text().splitlines() if line.startswith(prefix)]
    assert len(matches) == 1, (path, prefix)
    return matches[0]

path = PLAN + '02-implementation-plan.md'
old = line_start(path, '**The conversion is not complete.**')
new = '''**The conversion is not complete.** All 198 menu entries declare web surfaces, while all 34 execution cards, 83 original packages and 198 whole-menu acceptances remain open. Preserve the implemented session/browser controls, six guarded Sales/Tour mutations, exact Tour saved values and separate saved Return metadata, row, bill and labour previews. Round 14 adds diagnostic incoming Save mapping, exact qualification of three Float header targets, source-shaped N BAR companion matching and a separate internal Serializable Return Update coordinator. None enables a numeric Return save or known closing balance; the pure mapping results retain `canCommit:false`. Read [current progress and the complete next-write sequence](40-implementation-progress-round14.md) and [checkpoint 41](41-implementation-checkpoint-round14.json) for actual verification and limits. The next implementation requires a complete independent Option A fixture, fully bound effects and Save guards, fresh versioned admission, exact atomic persistence with rollback/conflict/recovery tests, then UI/report/desktop verification. Remaining source, outgoing, variant, settlement and production acceptance stay open. [Round 13 progress](38-implementation-progress-round13.md) and [checkpoint 39](39-implementation-checkpoint-round13.json), together with [Round 10 progress](32-implementation-progress-round10.md) and [checkpoint 33](33-implementation-checkpoint-round10.json), retain their historical evidence and qualifications. Functional completion percentage remains unmeasured.'''
replace_file(path, [(old, new)])

path = PLAN + 'README.md'
old = line_start(path, 'Updated **12 September 2026, round 13 in progress**:')
new = old.replace('round 13 in progress', 'round 14')
old_bullet = line_start(path, '- [Current implementation continuation]')
new_bullet = '''- [Current Round 14 continuation](40-implementation-progress-round14.md) and [checkpoint 41](41-implementation-checkpoint-round14.json): diagnostic incoming Save mapping, exact header Float qualification, N BAR companion matching and an internal Serializable Return Update coordinator. Numeric saves and known closing remain disabled. The complete next-write prerequisites, actual verification and retained failures are recorded there; all 34 cards, 83 packages and 198 whole-menu acceptances remain open.
- [Round 13 continuation](38-implementation-progress-round13.md) and [checkpoint 39](39-implementation-checkpoint-round13.json): historical session/browser, Sales/Tour and saved Return labour-preview integration, with the Round 14 dependency-coverage erratum retained separately.'''
replace_file(path, [(old, new), (old_bullet, new_bullet)])

path = PLAN + 'execution-addendum-intro.md'
old_intro = 'Current implementation progress is recorded in [document 38](38-implementation-progress-round13.md), following '
new_intro = 'Current implementation progress and the complete next-write sequence are recorded in [document 40](40-implementation-progress-round14.md), with actual verification in [checkpoint 41](41-implementation-checkpoint-round14.json), following [round 13 in document 38](38-implementation-progress-round13.md), '
old_queue = line_start(path, '2. X13/X02:')
new_queue = '''2. X13/X02: preserve the existing metadata, row, bill and resolved-labour previews, session/browser controls and six Sales/Tour write guards. [Document 40](40-implementation-progress-round14.md) records the implemented diagnostic Save map, exact header Float qualifier, N BAR matcher and separate Serializable Return Update coordinator; none grants a numeric capability. Follow its complete next-write sequence together with the frozen [finite numeric-write contract](evidence/implementation-2026-09-12-round13/return-next-write-contract/implementation-contract.md), mandatory [independent review and stock erratum](evidence/implementation-2026-09-12-round13/return-next-write-contract-review/review.md) and [complete source-effect inventory](evidence/implementation-2026-09-12-round14/return-save-effects-analysis/effects-contract.md). First freeze the fully bound Option A fixture, including raw cells/caches, policy, per-prefix bill phases, N companions, all Save guards and complete effects. Then implement the pure effect plan, fresh versioned observation/admission, exact transaction-owned commit and failure/recovery tests before a separate endpoint and UI Save. MAIN_STOCK.SR_NO=2 and ISR_NO comes from incoming SR_NO; row and book data types have distinct ownership. Revalidate zero, omitted-row, received-side and changed BAR membership after replay; qualify cash, edition/audit and hidden-number/key collision behavior explicitly. The generic salesReturn writer and existing preview tokens do not authorize this path. Trusted mode and same-snapshot ledger/closing integration, remaining financial-writer adoption, source/child/tag admission, outgoing/variant workflows, settlement/reversal, reports and desktop/business/production acceptance remain open. The round4/x13-sale-return-33-next-contract.md classification still governs all 33 incoming, outgoing, hidden/reference and UAE field findings.'''
replace_file(path, [(old_intro, new_intro), (old_queue, new_queue)])

path = PLAN + 'build_execution_addendum.py'
anchor = '\n\nfor _card in TASKS:\n    if _card[\'id\'] in IMPLEMENTATION_PROGRESS:\n'
new_block = '''

# Round14 records diagnostic save prerequisites; earlier round records remain intact.
IMPLEMENTATION_PROGRESS['X13'].update(
    asOf='2026-09-12 round 14',
    progressDocument='parity-plan-2026-09-10/40-implementation-progress-round14.md')
IMPLEMENTATION_PROGRESS['X13']['implementedOrInvestigated'] += (
    ' Round14 adds the complete incoming Save field projection, exact binary64 qualification '
    'for three Float header targets, source-shaped N BAR header/parent matching and a separate '
    'internal Serializable Return Update coordinator. The pure mappings remain canCommit:false; '
    'no numeric endpoint, writer, known closing or existing preview capability is enabled. '
    'Document40 and checkpoint41 record actual verification, source qualifications and retained '
    'failures, including the Round13 final-source API dependency-coverage erratum. Earlier '
    'round counts above remain historical evidence with their stated limits.')
IMPLEMENTATION_PROGRESS['X13']['remainingBeforeAcceptance'][0] = (
    'Follow document40 and checkpoint41, the frozen Round13 return-next-write-contract and '
    'mandatory review/stock erratum, and the Round14 return-save-effects-analysis. Preserve all '
    'existing previews and session/browser/order contracts. Freeze a complete independent Option A '
    'fixture with raw header/rows,63 visible cells, eight caches, width/calculation policy, full '
    'loaded/opened/per-prefix bill phases, qualified16-field N BAR context, all master/config/guard '
    'facts and every before/after effect. Resolve symbolic bindings before claiming executable '
    'goldens. Build the pure effect plan:221 source-owned entries per phase across seven conditional '
    'financial rows plus full saved line/header and retained/absent companions; preserve unowned '
    'NULL/text/identities. MAIN_STOCK.SR_NO is2 and ISR_NO comes from incoming SR_NO, with row '
    'and book data types kept distinct. Add separately versioned fresh Update admission, exact '
    'physical/dependency versions, Save guards, cash/edition/audit authority and cross-year '
    'temporary/key collision checks. Replay only the accepted ordered c27 history and refuse '
    'unsupported zero/omission/received/BAR-membership transitions; no-op means the whole plan '
    'is unchanged. Implement one exact Serializable commit with deterministic locks, typed '
    'row-qualified DML, affected-count/conservation checks and final context/clock, without '
    'generic salesReturn writer reuse or automatic retry. Verify complete rollback, stale/SSI '
    'conflicts and ambiguous acknowledgment recovery before endpoint/UI adoption; then verify '
    'reopen, reports and independent desktop outcomes. Continue all other writer adoption, '
    'trusted mode/ledger/closing, source/tag/child and outgoing/variant workflows, settlement '
    'and full business/production acceptance. A hash, selected book or caller-qualified context '
    'does not establish authority; numeric/source/closing capability remains disabled.')

for _card in TASKS:
    if _card['id'] in IMPLEMENTATION_PROGRESS:
'''
old_finding = "            'Bounded saved incoming metadata and separately versioned row/bill previews are implemented. '\n            'Pure ledger-mode, canonical saved-clock, internal balance and atomic labour-copy calculation prerequisites plus separately versioned labour API/UI previews are implemented. Atomic session lifecycle, browser guards and six order transaction entries are implemented; remaining writer adoption, trusted mode authority, same-snapshot ledger/closing integration, full source admission, outgoing and variant workflows, numeric '\n            'stock/financial persistence, settlement/reversal and complete desktop/business acceptance remain open.')"
new_finding = "            'Saved incoming metadata, separate row/bill/labour previews, session/browser controls '\n            'and six guarded order mutations are implemented. Round14 adds diagnostic incoming Save '\n            'mapping, exact header Float qualification, N BAR companion matching and an internal '\n            'Serializable Return Update coordinator. Numeric saves and known closing remain disabled. '\n            'Document40 and checkpoint41 govern the complete independent fixture, effects, Save guards, '\n            'versioned admission and exact atomic writer prerequisites; all remaining source/variant, '\n            'ledger/closing, settlement, report and desktop/business/production acceptance stays open.')"
old_latest = "'latestImplementationProgress': 'parity-plan-2026-09-10/38-implementation-progress-round13.md'"
new_latest = old_latest.replace('38-implementation-progress-round13.md', '40-implementation-progress-round14.md')
old_note = "    work['note'] = 'Original 83 delivery packages retained. Current open status records incomplete acceptance, not absence of implementation. See 11/12/13 for measured review and detailed continuation; document38 records round13 session/browser controls, six guarded order mutations, exact Tour roundtrips, separately versioned labour API/UI previews, actual verification and remaining parity acceptance.'"
new_note = "    work['note'] = 'Original 83 delivery packages retained. Open status records incomplete acceptance, not absent implementation. See 11/12/13 for the review and execution cards; document40 and checkpoint41 record Round14 diagnostic Save/header/BAR prerequisites, the internal Serializable coordinator, actual verification, retained failures and the complete next-write sequence. Numeric saves, known closing and full parity acceptance remain open; earlier round evidence is preserved.'"
generator = replace_file(path, [(anchor, new_block), (old_finding, new_finding), (old_latest, new_latest), (old_note, new_note)])
ast.parse(generator, filename=path)

shared = 'Round 14 adds diagnostic incoming Save mapping, exact header Float qualification, N BAR companion matching and a separate internal Serializable Return Update coordinator. Existing session/browser, Sales/Tour and saved Return previews remain implemented. Numeric Return saves and known closing remain disabled. Complete independent fixtures, source effects, Save guards, fresh admission, atomic write/recovery verification and full desktop/business/production acceptance remain required.'
links = '[Round 14 progress and complete next steps](../../parity-plan-2026-09-10/40-implementation-progress-round14.md) and [checkpoint 41](../../parity-plan-2026-09-10/41-implementation-checkpoint-round14.json)'
path = 'web/docs/TECHNICAL-REFERENCE.md'
old = line_start(path, '**Architecture narrative last reviewed:**')
new = '**Architecture narrative last reviewed:** 2026-08-01. The inventory below has current 12 September source/test counts where stated; inventory is separate from execution evidence. Use ' + links + ' for actual runs, source qualifications and retained failures. ' + shared
replace_file(path, [(old, new),
    ('31 module directories, 247 source TS files', '31 module directories, 248 source TS files'),
    ('| API top-level TypeScript test files | 263 |', '| API top-level TypeScript test files | 266 |'),
    ('| DB test files | 149 |', '| DB test files | 151 |')])

path = 'web/docs/STATE-OF-PARITY.md'
old = line_start(path, '> Current status supersedes this dated narrative:')
new = '> Current status supersedes this dated narrative: read ' + links + ', together with [the completion review](../../parity-plan-2026-09-10/11-current-completion-review.md). ' + shared + ' All 34 cards, 83 packages and 198 whole-menu acceptances remain open; heuristic surface counts do not measure functional parity.'
replace_file(path, [(old, new)])

path = 'web/docs/HANDOFF.md'
old = line_start(path, '> Current implementation and safe test startup:')
new = '> Current implementation and safe test startup: ' + links + '. Run `pnpm test:parity:api` for the isolated API suite, or `node scripts/parity-test-env.mjs -- <command>` for another isolated test command. Calling the wrapper without a command only provisions the test DB. ' + shared + ' Keep each actual run bound to its full dependency snapshot; current totals and failure qualifications belong in the checkpoint. The older environment instructions below remain historical.'
replace_file(path, [(old, new)])

replacement_document = {
    'kind': 'round14-current-document-replacements-v1',
    'workspaceRoot': str(ROOT),
    'applicationStatus': 'staged-only; root owns application, verification completion and checkpoint sealing',
    'progressDraft': str(progress_path),
    'progressDraftSha256': sha(progress_path.read_bytes()),
    'sourceDraft': str(draft_path),
    'sourceDraftSha256': sha(draft_path.read_bytes()),
    'draftEdit': 'Only BAR_STATUS_PLACEHOLDER replaced; VERIFICATION_PLACEHOLDER retained exactly once; accepted seven semantic corrections unchanged.',
    'checkpointLinkQualification': '40/41 are the root-owned current-progress/final-checkpoint destinations. This stage does not assert checkpoint41 exists or is sealed. Apply current links with the completed root handoff.',
    'changes': changes,
}
dump(OUT / 'replacements.json', replacement_document)
(OUT / 'current-status.patch').write_text(''.join(diffs))

# Check the exact edited surface and source-stage distinction without executing a generator/test.
integration_path = ROOT / EVIDENCE / 'bar-companion-integration/integration.json'
integration = json.loads(integration_path.read_text())
active_bar = []
for item in integration['files']:
    actual = sha((ROOT / item['path']).read_bytes())
    assert actual == item['afterRepositoryFormattingSha256']
    active_bar.append({'path': item['path'], 'currentSha256': actual,
                       'stagedSha256': item['stagedSha256'], 'matchesIntegratedFormattedRevision': True})
dump(OUT / 'staging-validation.json', {
    'checks': ['seven replacement files; unique old anchors; unchanged original source files',
               'only BAR placeholder changed in accepted progress draft',
               'VERIFICATION_PLACEHOLDER retained once',
               'staged generator ast.parse succeeds without executing generator',
               'three active BAR implementation inputs match repository-formatted integration hashes'],
    'replacementFileCount': len(changes),
    'allActiveBaseFilesUnchanged': all(sha((ROOT / x['path']).read_bytes()) == x['baseSha256'] for x in changes),
    'activeBarInputs': active_bar,
    'inventoryCountAttribution': 'Root supplied current API source248 / top-level TS tests266 / DB tests151 in the staging task update; these are inventory counts, not inferred test pass totals.',
    'limits': 'No active writes, generator execution, tests, builds, DB or browser runs. Final verification counts remain root-owned.'
})
assert len(changes) == 7
assert all(sha((ROOT / x['path']).read_bytes()) == x['baseSha256'] for x in changes)

refs = [draft_path, Path('/tmp/datacare-round14-plan-review/semantic-replacements.json'),
        integration_path,
        ROOT / EVIDENCE / 'bar-companion-integration/frozen-stage/focused-final.run.json',
        ROOT / EVIDENCE / 'bar-companion-independent-review/ready-manifest.json',
        ROOT / EVIDENCE / 'core-final.run.json', ROOT / EVIDENCE / 'core-final.txt',
        ROOT / EVIDENCE / 'core-final-test-types.run.json']
refs += [ROOT / x['path'] for x in changes]
refs += [ROOT / x['path'] for x in integration['files']]
dump(OUT / 'read-inputs.json', {'files': [{'path': str(p), 'sha256': sha(p.read_bytes())} for p in refs]})
print(json.dumps({'stagedFiles': len(changes), 'progressSha256': sha(progress_path.read_bytes()),
                  'replacementSha256': sha((OUT / 'replacements.json').read_bytes()),
                  'activeFilesChangedByStage': False, 'verificationPlaceholderRetained': True}))
