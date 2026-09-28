#!/usr/bin/env python3
"""Tier-1 unit tests for build_form_specs.py."""
import sys
import unittest
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parents[1]))
import build_form_specs as bf  # noqa: E402


class FormSpecTest(unittest.TestCase):
    def test_classify_module(self):
        self.assertEqual(bf.classify_module("TR_SALE"), "transaction")
        self.assertEqual(bf.classify_module("MS_ITEM"), "master")
        self.assertEqual(bf.classify_module("RP_GST"), "report")
        self.assertEqual(bf.classify_module("UT_BKP"), "utility")
        self.assertEqual(bf.classify_module("Ac_Ledr"), "other")

    def test_extract_ops_filters_to_known_tables_and_orders(self):
        known = {"SL_DATA", "SL_DETL", "TAG_STOCK", "AC_DATA", "ITEM_MAST"}
        text = (
            'q="INSERT INTO SL_DATA (CO_CODE) VALUES (1)";\n'
            'q="INSERT INTO SL_DETL (CO_CODE) VALUES (1)";\n'
            'q="UPDATE TAG_STOCK SET STK=0 WHERE TAG_NO=1";\n'
            'q="INSERT INTO NOPE (X) VALUES (1)";\n'           # unknown -> filtered
            'q="DELETE FROM AC_DATA WHERE VCH_NO=1";\n'
            'q="SELECT * FROM ITEM_MAST";\n'
        )
        ops = bf.extract_ops(text, known)
        self.assertEqual(ops["tablesInserted"], ["SL_DATA", "SL_DETL"])
        self.assertEqual(ops["tablesUpdated"], ["TAG_STOCK"])
        self.assertEqual(ops["tablesDeleted"], ["AC_DATA"])
        self.assertIn("ITEM_MAST", ops["tablesRead"])
        kinds = [(k, t) for (_l, k, t) in ops["sequence"]]
        self.assertEqual(kinds, [("INSERT", "SL_DATA"), ("INSERT", "SL_DETL"),
                                 ("UPDATE", "TAG_STOCK"), ("DELETE", "AC_DATA")])

    def test_extract_validations(self):
        text = 'if(x){ MsgBox("Account is required"); return; }\nMessageBox.Show("At least one item required");'
        vals = bf.extract_validations(text)
        self.assertIn("Account is required", vals)
        self.assertIn("At least one item required", vals)


if __name__ == "__main__":
    unittest.main(verbosity=2)
