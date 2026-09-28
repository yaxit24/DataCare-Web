#!/usr/bin/env python3
"""Tier-1 unit tests for audit_completeness.py (stdlib unittest, no external deps)."""
import sys
import tempfile
import unittest
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parents[1]))
import audit_completeness as ac  # noqa: E402


def _write(p: Path, text: str = "") -> None:
    p.parent.mkdir(parents=True, exist_ok=True)
    p.write_text(text, encoding="utf-8")


class CompletenessAuditTest(unittest.TestCase):
    def setUp(self):
        self.tmp = tempfile.TemporaryDirectory()
        self.raw = Path(self.tmp.name)
        self.unified = self.raw / "unified"
        # reports: one present
        _write(self.unified / "reports" / "SalesBillA4.rpt", "RPTDATA")
        # source referencing 3 rpts: present, missing-but-in-raw, gone
        _write(
            self.unified / "src" / "csharp" / "DataCareNext" / "TR_SALE.cs",
            'x = "SalesBillA4.rpt"; y = "MissingButRaw.RPT"; z = "GoneForever.rpt";',
        )
        # schema with one table; tables list expects two
        _write(
            self.unified / "database" / "schema" / "01_Schema.sql",
            "CREATE TABLE AC_DATA(CO_CODE VARCHAR(2) PRIMARY KEY (CO_CODE))\nGO\n",
        )
        _write(self.unified / "extraction_metadata" / "database_tables.txt", "AC_DATA\nGHOST_TBL\n")
        _write(self.unified / "extraction_metadata" / "audit" / "datacarenext-missing-rpt.txt", "")
        # presence inventories
        _write(self.unified / "libs" / "Newtonsoft.Json.dll", "x")
        _write(self.unified / "resources" / "DataCareNext" / "DataCareNext.MS_ITEM.resx", "x")
        _write(self.unified / "fonts" / "FRE3OF9X.TTF", "x")
        _write(self.unified / "config" / "App.config", "x")
        # Raw_Source copy of the missing-but-recoverable report
        _write(self.raw / "Report" / "MissingButRaw.rpt", "RPTDATA")

    def tearDown(self):
        self.tmp.cleanup()

    def _by_id(self, manifest, cat, _id):
        for a in manifest["artifacts"]:
            if a["category"] == cat and a["id"] == _id:
                return a
        return None

    def test_report_present(self):
        m = ac.build_manifest(self.unified, self.raw)
        a = self._by_id(m, "report", "salesbilla4.rpt")
        self.assertIsNotNone(a)
        self.assertEqual(a["status"], "present")
        self.assertIn("TR_SALE.cs", " ".join(a["referencedBy"]))

    def test_report_missing_recoverable_from_raw(self):
        m = ac.build_manifest(self.unified, self.raw)
        a = self._by_id(m, "report", "missingbutraw.rpt")
        self.assertIsNotNone(a)
        self.assertEqual(a["status"], "missing")
        self.assertTrue(a["rawSourceLocation"].endswith("MissingButRaw.rpt"))

    def test_report_external_blocker(self):
        m = ac.build_manifest(self.unified, self.raw)
        a = self._by_id(m, "report", "goneforever.rpt")
        self.assertIsNotNone(a)
        self.assertEqual(a["status"], "external-blocker")
        self.assertIsNone(a["rawSourceLocation"])

    def test_table_present_and_missing(self):
        m = ac.build_manifest(self.unified, self.raw)
        present = self._by_id(m, "db_table", "AC_DATA")
        missing = self._by_id(m, "db_table", "GHOST_TBL")
        self.assertEqual(present["status"], "present")
        self.assertEqual(missing["status"], "missing")

    def test_presence_inventories(self):
        m = ac.build_manifest(self.unified, self.raw)
        cats = {a["category"] for a in m["artifacts"]}
        for c in ("lib", "resx", "font", "config", "source_form"):
            self.assertIn(c, cats, f"missing category {c}")

    def test_summary_and_totals_consistent(self):
        m = ac.build_manifest(self.unified, self.raw)
        s = sum(c["present"] + c["missing"] + c["external-blocker"] for c in m["summary"].values())
        self.assertEqual(s, m["totals"]["artifacts"])
        self.assertGreaterEqual(m["totals"]["missing"], 1)
        self.assertGreaterEqual(m["totals"]["external_blocker"], 1)

    def test_schema_table_parser(self):
        tables = ac.schema_tables(self.unified / "database" / "schema" / "01_Schema.sql")
        self.assertEqual(tables, {"AC_DATA"})


if __name__ == "__main__":
    unittest.main(verbosity=2)
