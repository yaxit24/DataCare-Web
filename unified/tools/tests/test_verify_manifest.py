#!/usr/bin/env python3
"""Tier-1 unit tests for verify_manifest.py."""
import json
import sys
import tempfile
import unittest
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parents[1]))
import verify_manifest as vm  # noqa: E402


class VerifyManifestTest(unittest.TestCase):
    def _mk(self, present_exists: bool):
        d = tempfile.TemporaryDirectory()
        root = Path(d.name)
        (root / "reports").mkdir(parents=True)
        if present_exists:
            (root / "reports" / "A.rpt").write_text("x")
        manifest = {
            "layoutCheck": {"reports": True, "src/csharp": True},
            "artifacts": [
                {"id": "a.rpt", "category": "report", "status": "present", "location": "reports/A.rpt"},
                {"id": "gone.rpt", "category": "report", "status": "external-blocker", "location": None},
            ],
        }
        mpath = root / "manifest.json"
        mpath.write_text(json.dumps(manifest))
        return d, root, mpath

    def test_ok_when_present_exists(self):
        d, root, mpath = self._mk(present_exists=True)
        try:
            r = vm.verify(root, mpath)
            self.assertTrue(r["ok"])
            self.assertEqual(r["checkedPresent"], 1)
            self.assertEqual(r["missingPresent"], [])
        finally:
            d.cleanup()

    def test_fail_when_present_missing(self):
        d, root, mpath = self._mk(present_exists=False)
        try:
            r = vm.verify(root, mpath)
            self.assertFalse(r["ok"])
            self.assertEqual(len(r["missingPresent"]), 1)
            self.assertEqual(r["missingPresent"][0]["location"], "reports/A.rpt")
        finally:
            d.cleanup()

    def test_layout_missing_fails(self):
        d, root, mpath = self._mk(present_exists=True)
        try:
            m = json.loads(mpath.read_text())
            m["layoutCheck"]["database/schema"] = False
            mpath.write_text(json.dumps(m))
            r = vm.verify(root, mpath)
            self.assertFalse(r["ok"])
            self.assertIn("database/schema", r["layoutMissing"])
        finally:
            d.cleanup()


if __name__ == "__main__":
    unittest.main(verbosity=2)
