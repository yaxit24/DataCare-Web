#!/usr/bin/env python3
"""Tier-1 unit tests for build_data_model.py."""
import sys
import tempfile
import unittest
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parents[1]))
import build_data_model as dm  # noqa: E402


def _w(p: Path, t: str) -> None:
    p.parent.mkdir(parents=True, exist_ok=True)
    p.write_text(t, encoding="utf-8")


SCHEMA = (
    "USE master\nGO\n"
    "IF OBJECT_ID('FOO','U') IS NULL\nBEGIN\n"
    "CREATE TABLE FOO(CO_CODE VARCHAR(2) NOT NULL,LC_CODE VARCHAR(2),"
    "AMT FLOAT Not NULL DEFAULT 0,NM VARCHAR(50) DEFAULT ''  "
    "PRIMARY KEY (CO_CODE,LC_CODE))\nEND\nGO\n"
)


class DataModelTest(unittest.TestCase):
    def test_parse_ddl_columns_pk_tenantkeys(self):
        t = dm.parse_ddl(SCHEMA)["FOO"]
        names = [c["name"] for c in t["columns"]]
        self.assertEqual(names, ["CO_CODE", "LC_CODE", "AMT", "NM"])
        co = t["columns"][0]
        self.assertEqual((co["type"], co["length"], co["nullable"]), ("VARCHAR", 2, False))
        amt = t["columns"][2]
        self.assertEqual((amt["type"], amt["nullable"]), ("FLOAT", False))
        self.assertEqual(amt["default"], "0")
        self.assertEqual(t["primaryKey"], ["CO_CODE", "LC_CODE"])
        self.assertEqual(t["tenantKeys"], ["CO_CODE", "LC_CODE"])

    def test_recover_columns_from_code(self):
        with tempfile.TemporaryDirectory() as d:
            src = Path(d) / "src" / "csharp" / "DataCareNext"
            _w(src / "X.cs", 'q = "INSERT INTO BARTBL (CO_CODE,LC_CODE,AMT,XCOL) VALUES (...)";')
            rec = dm.recover_columns_from_code(src)
            self.assertEqual(rec["BARTBL"], ["CO_CODE", "LC_CODE", "AMT", "XCOL"])

    def test_build_merges_ddl_and_code_with_type_inference(self):
        with tempfile.TemporaryDirectory() as d:
            root = Path(d) / "unified"
            _w(root / "database" / "schema" / "01_Schema.sql", SCHEMA)
            _w(root / "src" / "csharp" / "DataCareNext" / "X.cs",
               'q = "INSERT INTO BARTBL (CO_CODE,LC_CODE,AMT,XCOL) VALUES (...)";')
            tables_txt = Path(d) / "tables.txt"
            tables_txt.write_text("FOO\nBARTBL\nPlease\n")
            model = dm.build(root, tables_txt)
            self.assertIn("FOO", model["tables"])
            self.assertIn("BARTBL", model["tables"])
            self.assertNotIn("PLEASE", model["tables"])      # noise excluded
            bar = model["tables"]["BARTBL"]
            self.assertEqual(bar["source"], "code")
            by_name = {c["name"]: c for c in bar["columns"]}
            self.assertEqual(by_name["CO_CODE"]["type"], "VARCHAR")   # inferred from FOO
            self.assertEqual(by_name["AMT"]["type"], "FLOAT")          # inferred from FOO
            self.assertEqual(by_name["XCOL"]["type"], "unknown")       # not in DDL map
            self.assertEqual(bar["tenantKeys"], ["CO_CODE", "LC_CODE"])
            self.assertEqual(model["summary"]["unresolved"], 0)


if __name__ == "__main__":
    unittest.main(verbosity=2)
