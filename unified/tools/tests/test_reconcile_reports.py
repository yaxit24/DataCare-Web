#!/usr/bin/env python3
"""Tier-1 unit tests for reconcile_reports.py."""
import json
import sys
import tempfile
import unittest
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parents[1]))
import reconcile_reports as rr  # noqa: E402


def _w(p: Path, t: str = "") -> None:
    p.parent.mkdir(parents=True, exist_ok=True)
    p.write_text(t, encoding="utf-8")


class ReconcileTest(unittest.TestCase):
    def setUp(self):
        self.tmp = tempfile.TemporaryDirectory()
        self.root = Path(self.tmp.name)
        self.unified = self.root / "unified"
        self.raw = self.root / "raw"
        _w(self.unified / "reports" / "Conflict.rpt", "UNIFIED")     # existing, will conflict
        _w(self.raw / "src" / "Missing1.rpt", "AAA")                 # recoverable
        _w(self.raw / "src" / "Conflict.rpt", "RAWDIFF")             # differs from unified
        manifest = {"artifacts": [
            {"id": "missing1.rpt", "category": "report", "status": "missing"},
            {"id": "conflict.rpt", "category": "report", "status": "missing"},
            {"id": "gone.rpt", "category": "report", "status": "external-blocker"},
        ]}
        self.manifest = self.root / "manifest.json"
        self.manifest.write_text(json.dumps(manifest), encoding="utf-8")

    def tearDown(self):
        self.tmp.cleanup()

    def test_index_finds_rpt(self):
        idx = rr.index_rpt([self.raw], exclude=self.unified)
        self.assertIn("missing1.rpt", idx)
        self.assertIn("conflict.rpt", idx)

    def test_dry_run_copies_nothing(self):
        res = rr.reconcile(self.unified, self.manifest, [self.raw], apply=False)
        self.assertEqual(res["summary"]["copied"], 1)        # missing1 recorded as to-copy
        self.assertEqual(res["summary"]["conflicts"], 1)     # conflict detected
        self.assertEqual(res["summary"]["stillMissing"], 1)  # gone
        self.assertFalse((self.unified / "reports" / "Missing1.rpt").exists())  # not actually copied

    def test_apply_copies_recoverable(self):
        res = rr.reconcile(self.unified, self.manifest, [self.raw], apply=True)
        self.assertTrue((self.unified / "reports" / "Missing1.rpt").exists())
        self.assertEqual((self.unified / "reports" / "Conflict.rpt").read_text(), "UNIFIED")  # unchanged
        names = {c["report"] for c in res["conflicts"]}
        self.assertEqual(names, {"conflict.rpt"})


if __name__ == "__main__":
    unittest.main(verbosity=2)
