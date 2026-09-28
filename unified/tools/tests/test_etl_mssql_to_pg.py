#!/usr/bin/env python3
"""Tier-1 unit tests for etl_mssql_to_pg.py."""
import datetime as dt
import sys
import unittest
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parents[1]))
import etl_mssql_to_pg as etl  # noqa: E402


def col(name, type_, length=None):
    return {"name": name, "type": type_, "length": length, "nullable": True, "default": None}


class EtlTest(unittest.TestCase):
    def test_money_coerced_to_2dp(self):
        self.assertEqual(etl.coerce_value(100.004, col("NET_AMT", "FLOAT")), 100.0)
        self.assertEqual(etl.coerce_value("2.345", col("SL_AMT", "FLOAT")), 2.35)

    def test_weight_coerced_to_3dp(self):
        self.assertEqual(etl.coerce_value(9.16666, col("ITM_NWT", "FLOAT")), 9.167)
        self.assertEqual(etl.coerce_value(1.0 / 3, col("ITM_FINE", "FLOAT")), 0.333)

    def test_date_iso(self):
        self.assertEqual(etl.coerce_value(dt.datetime(2024, 4, 1, 10, 0), col("VCH_DATE", "DATE")), "2024-04-01")
        self.assertEqual(etl.coerce_value("2024-04-01 10:00:00", col("VCH_DATE", "DATE")), "2024-04-01")

    def test_varchar_and_none(self):
        self.assertEqual(etl.coerce_value("01", col("CO_CODE", "VARCHAR", 2)), "01")
        self.assertIsNone(etl.coerce_value(None, col("AC_CODE", "VARCHAR", 8)))

    def test_map_row_injects_tenant_and_known_cols(self):
        cols = [col("CO_CODE", "VARCHAR", 2), col("NET_AMT", "FLOAT")]
        row = {"co_code": "01", "NET_AMT": 100.004, "UNKNOWN_COL": "x"}
        out = etl.map_row(cols, row, tenant_id="tnt1")
        self.assertEqual(out, {"tenant_id": "tnt1", "CO_CODE": "01", "NET_AMT": 100.0})
        self.assertNotIn("UNKNOWN_COL", out)


if __name__ == "__main__":
    unittest.main(verbosity=2)
