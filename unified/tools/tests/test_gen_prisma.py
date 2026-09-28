#!/usr/bin/env python3
"""Tier-1 unit tests for gen_prisma.py."""
import sys
import unittest
from pathlib import Path

sys.path.insert(0, str(Path(__file__).resolve().parents[1]))
import gen_prisma as gp  # noqa: E402


def col(name, type_, length=None, nullable=True, default=None):
    return {"name": name, "type": type_, "length": length, "nullable": nullable, "default": default}


class GenPrismaTest(unittest.TestCase):
    def test_type_mapping(self):
        self.assertEqual(gp.map_type(col("CO_CODE", "VARCHAR", 2)), ("String", "@db.VarChar(2)"))
        self.assertEqual(gp.map_type(col("NET_AMT", "FLOAT")), ("Decimal", "@db.Decimal(18, 2)"))
        self.assertEqual(gp.map_type(col("ITM_FINE", "FLOAT")), ("Decimal", "@db.Decimal(14, 3)"))
        self.assertEqual(gp.map_type(col("ITM_NWT", "FLOAT")), ("Decimal", "@db.Decimal(14, 3)"))
        self.assertEqual(gp.map_type(col("TAX_PRC", "FLOAT")), ("Decimal", "@db.Decimal(9, 4)"))
        self.assertEqual(gp.map_type(col("VCH_DATE", "DATE")), ("DateTime", "@db.Date"))
        self.assertEqual(gp.map_type(col("AC_IMAGE", "IMAGE")), ("Bytes", ""))

    def test_emit_model_with_pk(self):
        tbl = {
            "columns": [col("CO_CODE", "VARCHAR", 2, nullable=False),
                        col("VCH_NO", "VARCHAR", 10, nullable=False),
                        col("NET_AMT", "FLOAT")],
            "primaryKey": ["CO_CODE", "VCH_NO"], "tenantKeys": ["CO_CODE"], "source": "ddl",
        }
        m = gp.emit_model("SL_DATA", tbl)
        self.assertIn('tenantId String @map("tenant_id")', m)
        self.assertIn("@@id([tenantId, CO_CODE, VCH_NO])", m)
        self.assertIn('@@map("SL_DATA")', m)
        self.assertIn("NET_AMT Decimal", m)
        self.assertNotIn("rowId", m)  # has PK, no surrogate

    def test_emit_model_without_pk_uses_surrogate(self):
        tbl = {"columns": [col("CO_CODE", "VARCHAR", 2), col("TAG_NO", "VARCHAR", 15)],
               "primaryKey": [], "tenantKeys": ["CO_CODE"], "source": "code"}
        m = gp.emit_model("TAG_MAST", tbl)
        self.assertIn("rowId BigInt @id @default(autoincrement())", m)
        self.assertIn("@@index([tenantId])", m)

    def test_rls_emits_policy_per_table(self):
        rls = gp.build_rls({"tables": {"SL_DATA": {}, "AC_DATA": {}}})
        self.assertIn('ALTER TABLE "SL_DATA" ENABLE ROW LEVEL SECURITY;', rls)
        self.assertIn("CREATE POLICY tenant_isolation ON \"AC_DATA\"", rls)
        self.assertIn("current_setting('app.tenant_id', true)", rls)


if __name__ == "__main__":
    unittest.main(verbosity=2)
