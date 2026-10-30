"""Synthetic contract tests; these are not DataCare feature-validation evidence."""
import copy
import hashlib
import json
import subprocess
import sys
import tempfile
import unittest
from pathlib import Path

from validate_evidence import validate


class EvidenceContractTests(unittest.TestCase):
    def setUp(self):
        self.temp = tempfile.TemporaryDirectory()
        self.addCleanup(self.temp.cleanup)
        self.root = Path(self.temp.name)
        artifact = self.root / 'observation.txt'
        artifact.write_text('Synthetic checker fixture; not business evidence.')
        self.artifact = {'path': artifact.name, 'sha256': hashlib.sha256(artifact.read_bytes()).hexdigest()}
        self.matrix = {
            'feature': 'synthetic contract fixture', 'candidate': 'a' * 40,
            'inputsHash': 'b' * 64, 'fixtureHash': 'c' * 64, 'settingsHash': 'd' * 64,
            'cases': [{'id': f'case-{i}', 'group': f'T{i:02}', 'source': 'synthetic test contract',
                       'applicable': True, 'kind': 'read-only', 'requiredEvidence': ['browser', 'expected']}
                      for i in range(1, 19)],
        }
        self.run = {k: self.matrix[k] for k in ['candidate', 'inputsHash', 'fixtureHash', 'settingsHash']}
        self.run.update(matrixSha256='e' * 64, businessResponseMocks=0,
                        startedAt='2026-10-30T00:00:00+00:00', finishedAt='2026-10-30T00:01:00+00:00',
                        cases=[{'id': c['id'], 'status': 'passed', 'observation': 'synthetic observed value',
                                'driver': 'browser', 'desktopStatus': 'not-run',
                                'evidence': {'browser': self.artifact, 'expected': self.artifact}}
                               for c in self.matrix['cases']])

    def check(self):
        return validate(self.matrix, self.run, 'e' * 64, self.root)

    def test_cli_exit_codes_distinguish_pass_incomplete_and_malformed(self):
        matrix_path = self.root / 'matrix.json'
        run_path = self.root / 'run.json'
        matrix_path.write_text(json.dumps(self.matrix))
        self.run['matrixSha256'] = hashlib.sha256(matrix_path.read_bytes()).hexdigest()
        command = [sys.executable, str(Path(__file__).with_name('validate_evidence.py')),
                   str(matrix_path), str(run_path), '--evidence-root', str(self.root)]
        for status, expected in [('passed', 0), ('blocked', 1)]:
            self.run['cases'][0]['status'] = status
            run_path.write_text(json.dumps(self.run))
            result = subprocess.run(command, capture_output=True, text=True)
            self.assertEqual(result.returncode, expected, result.stdout)
        run_path.write_text('{invalid')
        self.assertEqual(subprocess.run(command, capture_output=True).returncode, 2)

    def test_browser_pass_does_not_imply_desktop_match(self):
        result = self.check()
        self.assertTrue(result['allRequiredBrowserCasesPassed'])
        self.assertEqual(result['browserBusinessPassPct'], 100)
        self.assertEqual(result['desktopMatchPct'], 0)

    def test_missing_unknown_and_duplicate_cases_are_rejected(self):
        for change in ['missing', 'unknown', 'duplicate']:
            with self.subTest(change=change):
                original = copy.deepcopy(self.run)
                if change == 'missing':
                    self.run['cases'].pop()
                elif change == 'unknown':
                    self.run['cases'][0]['id'] = 'unknown'
                else:
                    self.run['cases'].append(copy.deepcopy(self.run['cases'][0]))
                self.assertFalse(self.check()['bundleValid'])
                self.run = original

    def test_blocked_and_untested_stay_in_denominator(self):
        for state in ['blocked', 'untested']:
            self.run['cases'][0]['status'] = state
            result = self.check()
            self.assertTrue(result['bundleValid'])
            self.assertEqual(result['applicableCases'], 18)
            self.assertEqual(result['browserBusinessPassPct'], 94.44)
            self.assertFalse(result['allRequiredBrowserCasesPassed'])

    def test_failure_counts_as_execution_but_not_pass(self):
        self.run['cases'][0]['status'] = 'failed'
        result = self.check()
        self.assertEqual(result['executedCoveragePct'], 100)
        self.assertEqual(result['browserBusinessPassPct'], 94.44)

    def test_na_cannot_replace_applicable_case(self):
        self.run['cases'][0]['status'] = 'not-applicable'
        self.assertFalse(self.check()['bundleValid'])
        self.matrix['cases'][0].update(applicable=False, reason='synthetic source excludes this operation')
        self.assertEqual(self.check()['applicableCases'], 17)
        self.assertTrue(self.check()['allRequiredBrowserCasesPassed'])

    def test_changed_matrix_or_candidate_is_rejected(self):
        self.run['matrixSha256'] = 'f' * 64
        self.run['candidate'] = 'f' * 40
        self.assertFalse(self.check()['bundleValid'])

    def test_changed_or_missing_artifact_is_rejected(self):
        (self.root / 'observation.txt').write_text('changed')
        self.assertFalse(self.check()['bundleValid'])
        (self.root / 'observation.txt').unlink()
        self.assertFalse(self.check()['bundleValid'])

    def test_path_traversal_is_rejected(self):
        self.run['cases'][0]['evidence']['browser'] = {'path': '../outside', 'sha256': '0' * 64}
        self.assertFalse(self.check()['bundleValid'])

    def test_api_only_pass_and_mocked_business_response_are_rejected(self):
        self.run['cases'][0]['driver'] = 'api'
        self.run['businessResponseMocks'] = 1
        self.assertFalse(self.check()['bundleValid'])

    def test_mutations_require_persistence_and_downstream_proof(self):
        self.matrix['cases'][0]['kind'] = 'mutation'
        self.assertFalse(self.check()['bundleValid'])
        self.matrix['cases'][0]['requiredEvidence'] += ['database', 'downstream']
        self.assertFalse(self.check()['bundleValid'])
        self.run['cases'][0]['evidence'].update(database=self.artifact, downstream=self.artifact)
        self.assertTrue(self.check()['bundleValid'])

    def test_source_derived_expectation_is_not_windows_execution(self):
        self.run['cases'][0].update(desktopStatus='matched', desktopExecution='source-derived')
        self.run['cases'][0]['evidence']['desktop'] = self.artifact
        self.assertFalse(self.check()['bundleValid'])

    def test_fault_injection_requires_evidence(self):
        self.run['cases'][0]['transportFault'] = True
        self.assertFalse(self.check()['bundleValid'])
        self.run['cases'][0]['evidence']['fault'] = self.artifact
        self.assertTrue(self.check()['bundleValid'])

    def test_required_group_cannot_be_omitted(self):
        self.matrix['cases'].pop()
        self.run['cases'].pop()
        self.assertFalse(self.check()['bundleValid'])


if __name__ == '__main__':
    unittest.main()
