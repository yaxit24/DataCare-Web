"""Round14-only required-proof validation; historical checkpoint rules are unchanged.

Credential bytes are never archived. Runtime maps are hash-only, except the
explicit compiled kernelConformance.js public-source seed. This validates local evidence,
not installed toolchain bytes, Windows equivalence or full product acceptance.
"""
from pathlib import Path
import hashlib
import importlib.util
import json
import re

PLAN = 'parity-plan-2026-09-10/'
EVIDENCE = PLAN + 'evidence/implementation-2026-09-12-round14/'
PRIOR = '39-implementation-checkpoint-round13.json'
PRIOR_SHA = 'db25b3e107d6e67629f2d445cb2ee191ff9794220cb19dac8cfc7ac9edfababf'
PRIVATE_PATHS = frozenset(('web/.env.parity-test', 'web/.env', 'web/packages/db/.env',
                           'web/packages/db/prisma/.env', 'web/apps/api/.env'))
BROWSERS = frozenset(('browser-bound', 'browser-context-bound', 'browser-labour-bound'))
RED_GATES = frozenset(('kernel-final', 'dead-cells-final', 'depth-final'))
COMMON = ('web/package.json', 'web/pnpm-lock.yaml', 'web/tsconfig')
API = COMMON + ('web/apps/api/', 'web/packages/', 'web/scripts/')
WEB = COMMON + ('web/apps/api/src/', 'web/apps/api/package.json', 'web/apps/api/tsconfig',
                'web/apps/web/app/', 'web/apps/web/components/', 'web/apps/web/lib/',
                'web/apps/web/package.json', 'web/apps/web/tsconfig', 'web/apps/web/next.config',
                'web/packages/', 'web/scripts/')
API_EXTERNAL = (
    'web/apps/web/app/', 'web/apps/web/components/', 'web/apps/web/test/',
    'web/docs/COMPLETION-REGISTER.json', 'web/deploy/.env.example',
    'web/deploy/docker-compose.prod.yml', 'web/docker-compose.yml',
    '.github/workflows/', 'web/.github/workflows/', 'project-memory/contracts/',
    'unified/src/csharp/DataCareNext/', 'project-memory/parity/PARITY-RATCHET.json',
    'project-memory/parity/g5/parity-diff-latest.json',
    'project-memory/parity/reports/report-comparison-latest.json',
    'project-memory/parity/restore-drill-result.json',
    PLAN + 'evidence/report-register.json',
)
MINIMUM_PREFIXES = {
    'api-qualified': API + API_EXTERNAL,
    'api-final-test-types': API,
    'core-final': COMMON + ('web/packages/core/',),
    'core-final-test-types': COMMON + ('web/packages/core/',),
    'workspace-final-build': WEB,
    'workspace-final-lint': WEB,
    'web-final': WEB + ('web/apps/web/test/fixtures/', 'web/apps/web/test/run-unit-tests.mjs'),
    **{label: API + WEB + ('web/apps/web/test/', 'parity-plan-2026-09-10/evidence/implementation-2026-09-12-round13/return-labour-preview-browser/browser-required-checks.json',) for label in BROWSERS},
    'kernel-final': ('web/apps/api/src/', 'web/apps/api/dist/modules/ops/kernelConformance.js',
                     'web/scripts/check-kernel-conformance.mjs'),
    'dead-cells-final': ('web/apps/api/src/', 'web/apps/web/app/', 'web/scripts/'),
    'depth-final': ('web/apps/api/src/', 'web/apps/web/app/', 'web/apps/web/components/',
                    'web/apps/web/lib/', 'web/scripts/', 'web/parity/',
                    'project-memory/parity/', 'unified/src/csharp/DataCareNext/'),
    'scanner-final': ('web/scripts/',),
    'completion-final': ('web/scripts/check-completion-register.mjs',
                         'web/docs/COMPLETION-REGISTER.json'),
    'docs-refs-qualified': ('web/docs/', 'web/scripts/', 'web/package.json',
                       'web/apps/api/test/'),
    'checkpoint-chain-recorded': (PLAN + 'validate_current_review.py',),
    'recipe-controls-recorded': (PLAN + 'checkpoint_recipe_round14.py',
                              PLAN + 'test_checkpoint_recipe_round14.py'),
}
# Concrete Round14 command/result contract, copied once from the reviewed candidate.
# This is independent of the mutable recipe loaded during capture.
EXPECTED_PROOFS = {'api-qualified': {'command': ['env',
                               'NODE_OPTIONS=--max-old-space-size=4096',
                               'node',
                               'scripts/parity-test-env.mjs',
                               '--',
                               'pnpm',
                               '--filter',
                               '@datacare/api',
                               'test'],
                   'requiredText': ['Test Files  271 passed (271)', 'Tests  3158 passed (3158)']},
 'api-final-test-types': {'command': ['env',
                                      'NODE_OPTIONS=--max-old-space-size=4096',
                                      'pnpm',
                                      '--filter',
                                      '@datacare/api',
                                      'exec',
                                      'tsc',
                                      '-p',
                                      'tsconfig.test.json',
                                      '--noEmit'],
                          'requiredText': []},
 'core-final': {'command': ['pnpm', '--filter', '@datacare/core', 'test'],
                'requiredText': ['Test Files  21 passed (21)', 'Tests  1059 passed (1059)']},
 'core-final-test-types': {'command': ['pnpm',
                                       '--filter',
                                       '@datacare/core',
                                       'exec',
                                       'tsc',
                                       '--noEmit',
                                       '--strict',
                                       '--noUncheckedIndexedAccess',
                                       '--isolatedModules',
                                       '--target',
                                       'ES2022',
                                       '--module',
                                       'NodeNext',
                                       '--moduleResolution',
                                       'NodeNext',
                                       '--resolveJsonModule',
                                       '--esModuleInterop',
                                       '--skipLibCheck',
                                       'test/saleReturnIncomingSaveProjection.test.ts',
                                       'test/saleReturnHeaderFloat.test.ts',
                                       'test/saleReturnNBarCompanions.test.ts'],
                           'requiredText': []},
 'workspace-final-build': {'command': ['env', 'API_ORIGIN=http://127.0.0.1:4410', 'pnpm', 'build'],
                           'requiredText': ['7 successful, 7 total']},
 'workspace-final-lint': {'command': ['pnpm', 'lint'], 'requiredText': ['10 successful, 10 total']},
 'web-final': {'command': ['pnpm', '--filter', '@datacare/web', 'test'],
               'requiredText': ['Test Files  36 passed (36)',
                                'Tests  522 passed (522)',
                                'tests 6',
                                'pass 6',
                                'fail 0',
                                'skipped 0']},
 'browser-bound': {'command': ['env',
                                   'PARITY_ARTIFACT_DIR=test-results/parity-real-stack-round14-bound',
                                   'node',
                                   'scripts/parity-test-env.mjs',
                                   '--',
                                   'node',
                                   'apps/web/test/parity.real-stack.mjs'],
                       'requiredText': ['PARITY_REAL_STACK_PASSED:',
                                        'resolved labour preview; zero mocked requests']},
 'browser-context-bound': {'command': ['env',
                                           'SESSION_CONTEXT_ARTIFACT_DIR=test-results/session-context-round14-bound',
                                           'node',
                                           'scripts/parity-test-env.mjs',
                                           '--',
                                           'node',
                                           'apps/web/test/session-context.real-stack.additive.mjs'],
                               'requiredText': ['SESSION_CONTEXT_REAL_STACK_PASSED: 14 checks '
                                                '(original12 + additive2), real responses with 5 '
                                                'declared transport injections; no synthetic business '
                                                'response']},
 'browser-labour-bound': {'command': ['env',
                                          'LABOUR_PREVIEW_ARTIFACT_DIR=test-results/labour-preview-lifecycle-round14-bound',
                                          'node',
                                          'scripts/parity-test-env.mjs',
                                          '--',
                                          'node',
                                          'apps/web/test/labour-preview-lifecycle.real-stack.mjs'],
                              'requiredText': ['LABOUR_PREVIEW_LIFECYCLE_PASSED: 5/5 checks; 4/4 '
                                               'explicit actual-response faults; zero synthetic '
                                               'business responses']},
 'kernel-final': {'command': ['node', 'scripts/check-kernel-conformance.mjs'],
                  'requiredText': ['127 bypass(es)',
                                   'KERNEL_CONFORMANCE_RED',
                                   'rounding: 127 bypasses']},
 'dead-cells-final': {'command': ['node', 'scripts/check-dead-cells.mjs'],
                      'requiredText': ['sale-return: 33 dead of 48', 'DEAD CELLS: 33.']},
 'depth-final': {'command': ['node', 'scripts/check-depth.mjs'],
                 'requiredText': ['unreachable API fields 106',
                                  'DEPTH GATE FAILED',
                                  '96 -> 106 (regression)']},
 'scanner-final': {'command': ['node',
                               '--test',
                               'scripts/test/request-field-trace.test.mjs',
                               'scripts/test/ui-descriptors.test.mjs'],
                   'requiredText': ['tests 31', 'pass 31', 'fail 0', 'skipped 0']},
 'completion-final': {'command': ['node', 'scripts/check-completion-register.mjs', '--strict'],
                      'requiredText': ['198  implemented-unverified', 'REGISTER_OK']},
 'docs-refs-qualified': {'command': ['pnpm', 'docs:refs'], 'requiredText': ['DOC_REFS_OK']},
 'checkpoint-chain-recorded': {'command': ['python3',
                                        '../parity-plan-2026-09-10/validate_current_review.py',
                                        '--self-test-checkpoint-chain'],
                            'requiredText': ['"status": "passed"', '"errors": []', '"rejected": true']},
 'recipe-controls-recorded': {'command': ['python3',
                                       '../parity-plan-2026-09-10/test_checkpoint_recipe_round14.py'],
                           'requiredText': ['ROUND14_RECIPE_CONTROLS_PASSED']}}
REQUIRED_LABELS = frozenset(MINIMUM_PREFIXES)
SHA = re.compile(r'[0-9a-f]{64}')
RUNNABLE_WEB = re.compile(r'^web/apps/web/test/.*\.(?:test|spec)\.[cm]?[jt]sx?$')


def canonical_path(value):
    return (isinstance(value, str) and bool(value) and '\\' not in value
            and not value.startswith('/') and all(p not in ('', '.', '..')
            for p in value.rstrip('/').split('/')))


def hash_map(value, *, nullable=True):
    return (isinstance(value, dict) and all(canonical_path(k) and not k.endswith('/')
            and ((v is None and nullable) or isinstance(v, str) and SHA.fullmatch(v))
            for k, v in value.items()))


def validate_recipe(recipe):
    """Fixed minimum proof set. Stronger prefixes are allowed, omissions are not."""
    errors = []
    if not isinstance(recipe, dict):
        return ['Required recipe must be an object']
    if recipe.get('priorCheckpoint') != PRIOR or recipe.get('priorCheckpointSha256') != PRIOR_SHA:
        errors.append('Required recipe must identify immutable checkpoint39')
    checks = recipe.get('checks')
    if not isinstance(checks, list) or not checks or any(not isinstance(r, dict) for r in checks):
        return errors + ['Required recipe checks must be a nonempty list of objects']
    labels = [r.get('label') for r in checks]
    if any(not isinstance(x, str) for x in labels) or len(set(str(x) for x in labels)) != len(labels):
        errors.append('Required recipe labels must be unique strings')
    if set(str(x) for x in labels) != REQUIRED_LABELS:
        errors.append('Required recipe must contain the exact18 Round14 labels')
    for row in checks:
        label = row.get('label')
        if not isinstance(label, str) or label not in REQUIRED_LABELS:
            continue
        for key, expected in EXPECTED_PROOFS[label].items():
            if row.get(key) != expected:
                errors.append(label + ': changed fixed proof ' + key)
        expected_exit = 1 if label in RED_GATES else 0
        if (row.get('status') != ('failed' if expected_exit else 'passed')
                or type(row.get('requiredExitCode')) is not int
                or row['requiredExitCode'] != expected_exit or row.get('requiredCwd') != 'web'):
            errors.append(label + ': invalid required status/exit/cwd')
        command = row.get('command')
        if not isinstance(command, list) or not command or any(not isinstance(s, str) or not s for s in command):
            errors.append(label + ': command must be a nonempty string array')
        if label == 'api-qualified' or label in BROWSERS:
            if not isinstance(command, list) or 'scripts/parity-test-env.mjs' not in command:
                errors.append(label + ': qualified command requires the captured private-input wrapper')
        text = row.get('requiredText')
        if not isinstance(text, list) or any(not isinstance(s, str) or not s for s in text):
            errors.append(label + ': requiredText must contain nonempty literal strings')
        elif label not in ('api-final-test-types', 'core-final-test-types') and not text:
            errors.append(label + ': requiredText cannot omit the observed result')
        prefixes = row.get('requireCurrentPrefixes')
        if (not isinstance(prefixes, list) or not prefixes
                or any(not canonical_path(p) for p in prefixes)
                or len(set(prefixes)) != len(prefixes)):
            errors.append(label + ': current prefixes must be nonempty, canonical and unique')
            continue
        for minimum in MINIMUM_PREFIXES[label]:
            if not any(minimum.startswith(prefix) for prefix in prefixes):
                errors.append(label + ': missing current domain ' + minimum)
        if 'requireCurrentWebTestMembership' in row and type(row['requireCurrentWebTestMembership']) is not bool:
            errors.append(label + ': web test membership flag must be boolean')
        if label in ('web-final', 'workspace-final-lint') and row.get('requireCurrentWebTestMembership') is not True:
            errors.append(label + ': current runnable web test membership is required')
    return errors


def _read(root, name):
    if not canonical_path(name) or name.endswith('/'):
        raise ValueError('Invalid evidence path')
    path = root / name
    if path.is_symlink() or not path.is_file() or not path.resolve().is_relative_to(root.resolve()):
        raise ValueError('Missing/nonregular evidence: ' + name)
    return path.read_bytes()


def _identity_read(root, name, sha):
    data = _read(root, name)
    if not isinstance(sha, str) or not SHA.fullmatch(sha) or hashlib.sha256(data).hexdigest() != sha:
        raise ValueError('Changed evidence identity: ' + str(name))
    return data


def _changed(old, current, prefixes):
    # Membership is significant even when a newly declared absent path has value None.
    return [name for name in sorted(set(old) | set(current))
            if any(name.startswith(p) for p in prefixes)
            and (name not in old or name not in current or old[name] != current[name])]


def validate_required_runs(root, recipe, verification, current, private_current, runtime_current):
    """Validate mandatory runs from their retained records, not derived summary arrays."""
    errors = validate_recipe(recipe)
    if errors:
        return errors
    if not hash_map(current) or set(current) & PRIVATE_PATHS:
        return ['Current public map is invalid or contains private input identities']
    if not hash_map(private_current) or set(private_current) != PRIVATE_PATHS:
        return ['Current private map must contain exactly the five hash-only identities']
    if not hash_map(runtime_current, nullable=False):
        return ['Current runtime map is invalid']
    if not isinstance(verification, list) or any(not isinstance(r, dict) for r in verification):
        return ['Verification must be a list of records']
    by_label = {}
    for run in verification:
        label = run.get('label')
        if isinstance(label, str) and label in REQUIRED_LABELS:
            if label in by_label:
                errors.append('Duplicate mandatory run: ' + label)
            by_label[label] = run
    for requirement in recipe['checks']:
        label = requirement['label']
        try:
            run = by_label.get(label)
            if run is None:
                raise ValueError('Missing mandatory run')
            record = run.get('record')
            if not isinstance(record, dict) or record.get('path') != EVIDENCE + label + '.run.json':
                raise ValueError('Mandatory run has no exact retained record identity')
            raw = json.loads(_identity_read(root, record['path'], record.get('sha256')))
            if not isinstance(raw, dict) or any(run.get(key) != value for key, value in raw.items()):
                raise ValueError('Checkpoint run differs from retained record')
            for key, expected in [('status', requirement['status']), ('exitCode', requirement['requiredExitCode']),
                                  ('cwd', requirement['requiredCwd']), ('command', requirement['command'])]:
                if raw.get(key) != expected or (key == 'exitCode' and type(raw.get(key)) is not int):
                    raise ValueError('Run differs from required ' + key)
            if raw.get('changedInputs') != []:
                raise ValueError('Public inputs changed during required run')
            if raw.get('inputManifest') != EVIDENCE + label + '.inputs.json' or raw.get('log') != EVIDENCE + label + '.txt':
                raise ValueError('Mandatory log/input manifest is not the named run')
            inputs = json.loads(_identity_read(root, raw['inputManifest'], raw.get('inputManifestSha256')))
            original = inputs.get('files')
            if not hash_map(original) or set(original) & PRIVATE_PATHS:
                raise ValueError('Invalid public input manifest')
            if type(raw.get('inputCount')) is not int or raw['inputCount'] != len(original):
                raise ValueError('Input count does not match the retained map')
            if inputs.get('sourceRoot') != str(root):
                raise ValueError('Input sourceRoot differs from the current workspace')
            prefixes = requirement['requireCurrentPrefixes']
            changes = _changed(original, current, prefixes)
            if changes:
                raise ValueError('Current required input membership/hash differs: ' + ', '.join(changes[:3]))
            for minimum in MINIMUM_PREFIXES[label]:
                if not any(name.startswith(minimum) for name in original):
                    raise ValueError('Required domain has no observed present/absent input: ' + minimum)
            if requirement.get('requireCurrentWebTestMembership'):
                old_tests = {k: v for k, v in original.items() if RUNNABLE_WEB.fullmatch(k) and v is not None}
                new_tests = {k: v for k, v in current.items() if RUNNABLE_WEB.fullmatch(k) and v is not None}
                if not new_tests or old_tests != new_tests:
                    raise ValueError('Current runnable web test membership/hash differs')
            if 'scripts/parity-test-env.mjs' in raw['command']:
                private = inputs.get('privateInputFiles')
                if (not hash_map(private) or set(private) != PRIVATE_PATHS or private != private_current
                        or raw.get('changedPrivateInputs') != []):
                    raise ValueError('Wrapper private-five membership/hash changed or was omitted')
            if label in BROWSERS:
                runtime = inputs.get('runtimeInputFiles')
                sentinels = ('web/apps/api/dist/app.js', 'web/apps/web/.next/BUILD_ID')
                groups = ('web/apps/api/dist/', 'web/apps/web/.next/server/', 'web/apps/web/.next/static/')
                if (not hash_map(runtime, nullable=False) or not runtime or runtime != runtime_current
                        or any(k not in runtime for k in sentinels)
                        or any(not any(k.startswith(p) for k in runtime) for p in groups)
                        or raw.get('changedRuntimeInputs') != []):
                    raise ValueError('Browser built-runtime membership/hash changed or was omitted')
            text = _identity_read(root, raw['log'], raw.get('logSha256')).decode('utf-8')
            for literal in requirement['requiredText']:
                if literal not in text:
                    raise ValueError('Required result literal missing: ' + literal)
        except (KeyError, TypeError, ValueError, OSError, UnicodeError) as exc:
            errors.append(label + ': ' + str(exc))
    return errors


def observe_public_inputs(root, seeds):
    """Re-observe the same inherited public universe, including new directory members."""
    path = root / PLAN / 'capture_implementation_checkpoint_round12_isolated.py'
    spec = importlib.util.spec_from_file_location('_round14_public_universe', path)
    module = importlib.util.module_from_spec(spec)
    spec.loader.exec_module(module)
    seeds = set(seeds)
    seeds.update(str(p.relative_to(root)) for p in (root / 'web/docs').rglob('*')
                 if p.is_file() and p.suffix in {'.md', '.json'})
    seeds.update(str(p.relative_to(root)) for p in (root / 'project-memory/parity').glob('*.py'))
    result = {}
    for name in sorted(module.universe(root, seeds)):
        if not canonical_path(name) or name in PRIVATE_PATHS:
            raise ValueError('Invalid/private name in public capture')
        path = root / name
        result[name] = (hashlib.sha256(_read(root, name)).hexdigest()
                        if path.exists() or path.is_symlink() else None)
    return result


def validate_latest_checkpoint(root, checkpoint):
    """Only call for the actual latest R14 checkpoint, never a historical/synthetic39."""
    try:
        if checkpoint.get('priorCheckpoint') != PRIOR or checkpoint.get('priorCheckpointSha256') != PRIOR_SHA:
            raise ValueError('Latest checkpoint must reference unchanged checkpoint39')
        _identity_read(root, PLAN + PRIOR, PRIOR_SHA)
        rows = checkpoint['sourceFiles']
        absent = checkpoint['observedAbsentInputs']
        if (not isinstance(rows, list) or not isinstance(absent, list)
                or any(not isinstance(r, dict) for r in rows)
                or any(not canonical_path(p) or p.endswith('/') for p in absent)):
            raise ValueError('Invalid current source/absence identities')
        current = {r['path']: r['sha256'] for r in rows}
        if len(current) != len(rows) or len(set(absent)) != len(absent) or set(current) & set(absent):
            raise ValueError('Duplicate/contradictory current source/absence identities')
        for name in absent:
            path = root / name
            if path.exists() or path.is_symlink():
                raise ValueError('An observed absent input is now present: ' + name)
            current[name] = None
        if not hash_map(current) or observe_public_inputs(root, current) != current:
            raise ValueError('Current public universe membership/hash differs from checkpoint')
        private = {}
        for name in PRIVATE_PATHS:
            path = root / name
            private[name] = hashlib.sha256(_read(root, name)).hexdigest() if path.exists() or path.is_symlink() else None
        if checkpoint.get('privateInputFiles') != private:
            raise ValueError('Checkpoint private identities differ from current hash-only observation')
        from round14_runtime_inputs import runtime_inputs
        runtime = runtime_inputs(root)
        if checkpoint.get('runtimeInputFiles') != runtime:
            raise ValueError('Checkpoint runtime identities differ from current observation')
        identity = checkpoint['requiredCheckRecipe']
        if identity.get('path') != EVIDENCE + 'checkpoint-required-checks.json':
            raise ValueError('Latest checkpoint must identify the Round14 recipe')
        recipe = json.loads(_identity_read(root, identity['path'], identity.get('sha256')))
        return validate_required_runs(root, recipe, checkpoint['verification'], current, private, runtime)
    except (KeyError, TypeError, ValueError, OSError, UnicodeError) as exc:
        return ['Round14 required recipe: ' + str(exc)]
