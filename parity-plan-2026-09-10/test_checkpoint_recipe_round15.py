"""Small synthetic proof controls; no application, compiler, browser or DB run."""
from copy import deepcopy
from pathlib import Path
import hashlib
import json
import shutil
import tempfile
import unittest

from checkpoint_recipe_round15 import (
    API_EXTERNAL, BROWSERS, EVIDENCE, EXPECTED_PROOFS, MINIMUM_PREFIXES, PLAN,
    PRIVATE_PATHS, PRIOR, PRIOR_SHA, RED_GATES, observe_public_inputs,
    validate_recipe, validate_required_runs,
)

SHA = '1' * 64


def recipe():
    return {'priorCheckpoint': PRIOR, 'priorCheckpointSha256': PRIOR_SHA, 'checks': [
        dict(label=label, status='failed' if label in RED_GATES else 'passed',
             requiredExitCode=1 if label in RED_GATES else 0, requiredCwd='web',
             command=deepcopy(EXPECTED_PROOFS[label]['command']),
             requiredText=deepcopy(EXPECTED_PROOFS[label]['requiredText']),
             requireCurrentPrefixes=list(dict.fromkeys(prefixes)),
             **({'requireCurrentWebTestMembership': True}
                if label in ('web-final', 'workspace-final-lint') else {}))
        for label, prefixes in MINIMUM_PREFIXES.items()]}


class RecipeControls(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory(prefix='round15-recipe-control-')
        self.addCleanup(self.temp.cleanup)
        self.root = Path(self.temp.name)
        self.recipe = recipe()
        names = {p + 'fixture.ts' if p.endswith('/') else p
                 for prefixes in MINIMUM_PREFIXES.values() for p in prefixes}
        names.add('web/apps/web/test/fixture.test.ts')
        self.current = {p: SHA for p in names}
        self.current['project-memory/parity/reports/report-comparison-latest.json'] = None
        self.private = {p: None for p in PRIVATE_PATHS}
        self.private['web/.env.parity-test'] = SHA
        self.runtime = {p: SHA for p in ('web/apps/api/dist/app.js', 'web/apps/web/.next/BUILD_ID',
                        'web/apps/web/.next/server/page.js', 'web/apps/web/.next/static/chunk.js')}
        self.runs = []
        for row in self.recipe['checks']:
            label = row['label']
            inputs = dict(sourceRoot=str(self.root), files=deepcopy(self.current),
                          privateInputFiles=deepcopy(self.private), runtimeInputFiles=deepcopy(self.runtime))
            log = '\n'.join(row['requiredText']) + '\n'
            input_name = EVIDENCE + label + '.inputs.json'
            log_name = EVIDENCE + label + '.txt'
            raw = dict(command=deepcopy(row['command']), cwd='web', status=row['status'],
                       exitCode=row['requiredExitCode'], changedInputs=[], changedPrivateInputs=[],
                       changedRuntimeInputs=[], inputManifest=input_name,
                       inputManifestSha256=self.write(input_name, inputs), inputCount=len(self.current),
                       log=log_name, logSha256=self.write(log_name, log))
            self.runs.append(self.record(label, raw))

    def write(self, name, value):
        path = self.root / name
        path.parent.mkdir(parents=True, exist_ok=True)
        data = (value if isinstance(value, str) else json.dumps(value, sort_keys=True)).encode()
        path.write_bytes(data)
        return hashlib.sha256(data).hexdigest()

    def record(self, label, raw):
        name = EVIDENCE + label + '.run.json'
        return dict(raw, label=label, record={'path': name, 'sha256': self.write(name, raw)})

    def mutate_run(self, label, *, raw_mutation=None, input_mutation=None):
        index = next(i for i, r in enumerate(self.runs) if r['label'] == label)
        run = self.runs[index]
        raw = json.loads((self.root / run['record']['path']).read_text())
        if input_mutation:
            inputs = json.loads((self.root / raw['inputManifest']).read_text())
            input_mutation(inputs)
            raw['inputManifestSha256'] = self.write(raw['inputManifest'], inputs)
        if raw_mutation:
            raw_mutation(raw)
        self.runs[index] = self.record(label, raw)

    def errors(self):
        return validate_required_runs(self.root, self.recipe, self.runs, self.current, self.private, self.runtime)

    def test_positive_complete_recipe_and_records(self):
        self.assertEqual(validate_recipe(self.recipe), [])
        self.assertEqual(self.errors(), [])

    def test_schema_omissions_duplicates_and_wrong_prior(self):
        mutations = [lambda d: d.update(checks=[]), lambda d: d['checks'].pop(),
                     lambda d: d['checks'].append(deepcopy(d['checks'][0])),
                     lambda d: d.update(priorCheckpoint='37-implementation-checkpoint-round12.json'),
                     lambda d: d.update(priorCheckpointSha256='0' * 64),
                     lambda d: d['checks'][0].update(requireCurrentPrefixes=[]),
                     lambda d: d['checks'][0].update(requiredExitCode=True),
                     lambda d: d['checks'][0].update(requiredCwd='.'),
                     lambda d: d['checks'][0].update(requireCurrentPrefixes=['../']),
                     lambda d: d['checks'][0].update(label=[])]
        for i, mutate in enumerate(mutations):
            with self.subTest(i=i):
                candidate = deepcopy(self.recipe)
                mutate(candidate)
                self.assertTrue(validate_recipe(candidate))

    def test_each_external_api_domain_is_mandatory(self):
        for prefix in API_EXTERNAL:
            with self.subTest(prefix=prefix):
                candidate = deepcopy(self.recipe)
                row = candidate['checks'][0]
                row['requireCurrentPrefixes'].remove(prefix)
                self.assertTrue(validate_recipe(candidate))

    def test_echo_command_is_rejected_even_if_retained_record_agrees(self):
        row = self.recipe['checks'][0]
        row['command'] = ['echo', 'fake result']
        self.mutate_run(row['label'], raw_mutation=lambda r: r.update(command=row['command']))
        self.assertTrue(self.errors())

    def test_lowered_success_count_and_false_green_red_gate_are_rejected(self):
        candidate = deepcopy(self.recipe)
        candidate['checks'][0]['requiredText'] = ['Tests  1 passed (1)']
        self.assertTrue(validate_recipe(candidate))
        red = next(r for r in candidate['checks'] if r['label'] == 'kernel-final')
        red.update(status='passed', requiredExitCode=0)
        self.assertTrue(validate_recipe(candidate))

    def test_missing_and_duplicate_required_runs(self):
        removed = self.runs.pop()
        self.assertTrue(self.errors())
        self.runs.append(removed)
        self.runs.append(deepcopy(removed))
        self.assertTrue(self.errors())

    def test_unrelated_historical_failure_is_retained_without_new_schema(self):
        self.runs.append({'label': 'historical-failed-attempt', 'status': 'failed', 'exitCode': 1})
        self.assertEqual(self.errors(), [])

    def test_retained_record_command_mismatch(self):
        self.runs[0]['command'] = ['echo', 'fake']
        self.assertTrue(self.errors())

    def test_retained_input_hash_tampering(self):
        (self.root / self.runs[0]['inputManifest']).write_text('{}')
        self.assertTrue(self.errors())

    def test_public_during_run_drift_even_with_empty_derived_difference(self):
        self.mutate_run('api-qualified', raw_mutation=lambda r: r.update(changedInputs=[{'path': 'x'}]))
        self.runs[0]['currentCaptureDifferences'] = []
        self.assertTrue(self.errors())

    def test_post_run_public_hash_or_membership_change(self):
        self.current['web/apps/api/new.test.ts'] = SHA
        self.assertTrue(self.errors())

    def test_absent_to_present_and_absence_identity_omission(self):
        name = 'project-memory/parity/reports/report-comparison-latest.json'
        self.current[name] = SHA
        self.assertTrue(self.errors())
        self.current[name] = None
        self.assertEqual(self.errors(), [])
        self.mutate_run('api-qualified', input_mutation=lambda x: x['files'].pop(name))
        self.assertTrue(self.errors())

    def test_private_membership_cannot_omit_a_null_identity(self):
        self.mutate_run('api-qualified', input_mutation=lambda x: x['privateInputFiles'].pop('web/apps/api/.env'))
        self.assertTrue(self.errors())

    def test_private_change_and_during_run_change(self):
        self.private['web/apps/api/.env'] = SHA
        self.assertTrue(self.errors())
        self.private['web/apps/api/.env'] = None
        self.mutate_run('api-qualified', raw_mutation=lambda r: r.update(changedPrivateInputs=[{'path': 'private'}]))
        self.assertTrue(self.errors())

    def test_nonwrapper_does_not_need_private_or_runtime_run_map(self):
        self.mutate_run('core-final', input_mutation=lambda x: (x.pop('privateInputFiles'), x.pop('runtimeInputFiles')))
        self.assertEqual(self.errors(), [])

    def test_browser_runtime_mandatory_membership_during_run_and_current_hash(self):
        label = 'browser-bound'
        self.mutate_run(label, input_mutation=lambda x: x.update(runtimeInputFiles={}))
        self.assertTrue(self.errors())
        self.mutate_run(label, input_mutation=lambda x: x.update(runtimeInputFiles=deepcopy(self.runtime)),
                        raw_mutation=lambda r: r.update(changedRuntimeInputs=[{'path': 'runtime'}]))
        self.assertTrue(self.errors())
        self.mutate_run(label, raw_mutation=lambda r: r.update(changedRuntimeInputs=[]))
        self.assertEqual(self.errors(), [])
        self.runtime['web/apps/web/.next/server/new.js'] = SHA
        self.assertTrue(self.errors())

    def test_derived_runtime_difference_array_cannot_hide_stale_inputs(self):
        self.runs[0]['currentRuntimeCaptureDifferences'] = []
        self.runtime['web/apps/api/dist/app.js'] = '2' * 64
        self.assertTrue(self.errors())

    def test_web_test_membership_and_hash_even_when_prefix_is_selective(self):
        self.current['web/apps/web/test/fixture.test.ts'] = '2' * 64
        self.assertTrue(self.errors())

    def test_private_cannot_enter_public_source_map(self):
        self.current['web/.env'] = SHA
        self.assertTrue(self.errors())

    def test_new_public_file_is_observed_without_changing_existing_hashes(self):
        # Use the actual inherited universe function, not a duplicate scanner.
        origin = Path(__file__).resolve().parent / 'capture_implementation_checkpoint_round12_isolated.py'
        target = self.root / PLAN / origin.name
        target.parent.mkdir(parents=True, exist_ok=True)
        shutil.copyfile(origin, target)
        before = observe_public_inputs(self.root, [])
        self.write('web/apps/api/test/new-membership.test.ts', '// new test\n')
        after = observe_public_inputs(self.root, before)
        self.assertNotEqual(before, after)
        self.assertEqual({k: after[k] for k in before}, before)
        self.assertIn('web/apps/api/test/new-membership.test.ts', after)
        self.write('web/docs/new-reference.md', 'New citation\n')
        self.assertIn('web/docs/new-reference.md', observe_public_inputs(self.root, before))


if __name__ == '__main__':
    outcome = unittest.TextTestRunner(verbosity=2).run(unittest.defaultTestLoader.loadTestsFromTestCase(RecipeControls))
    if outcome.wasSuccessful():
        print('ROUND15_RECIPE_CONTROLS_PASSED')
    raise SystemExit(0 if outcome.wasSuccessful() else 1)
