// V4 computation parity — recompute REAL desktop invoices (Next24.SL_DATA) through the web calc
// engine (@datacare/core billTotals) and compare to the desktop-stored TAX_AMT / TOT_AMT.
// Run: node apps/api/integration/compute_parity.live.mjs   (SQL Edge must be up with Next24 attached)
import sql from 'mssql';
import { billTotals } from '@datacare/core';

const cfg = {
  server: 'localhost',
  port: 11433,
  // Credentials come from the environment; never commit secrets to source.
  user: process.env.CUTOVER_SOURCE_USER || 'sa',
  password: process.env.CUTOVER_SOURCE_PASSWORD || '',
  database: 'Next24',
  options: { encrypt: false, trustServerCertificate: true },
  requestTimeout: 120000,
};
const n = (v) => Number(v ?? 0);
const r2 = (x) => Math.round((x + Number.EPSILON) * 100) / 100;

async function main() {
  const pool = await sql.connect(cfg);
  const rows = (
    await pool
      .request()
      .query(
        `SELECT VCH_NO, NET_AMT, DISC_AMT, TAX_PRC, IGST_TAX, CGST_TAX, SGST_TAX, TAX_AMT, ROF_AMT, TOT_AMT FROM dbo.SL_DATA`,
      )
  ).recordset;

  let total = 0,
    taxExact = 0,
    taxClose = 0,
    totExact = 0,
    totClose = 0,
    storedConsistent = 0;
  const samples = [];
  for (const s of rows) {
    total++;
    const inter = n(s.IGST_TAX) > 0;
    const bt = billTotals({
      lineNetTotal: n(s.NET_AMT),
      discountAmount: n(s.DISC_AMT),
      taxRatePct: n(s.TAX_PRC),
      interState: inter,
    });
    const dTax = r2(n(s.TAX_AMT)),
      dTot = r2(n(s.TOT_AMT));
    const taxd = Math.abs(bt.tax - dTax),
      totd = Math.abs(bt.total - dTot);
    if (taxd < 0.05) taxExact++;
    else if (taxd <= 1.0) taxClose++;
    if (totd < 0.05) totExact++;
    else if (totd <= 1.0) totClose++;
    // desktop internal consistency: TAX_AMT ≈ CGST+SGST+IGST
    if (Math.abs(dTax - r2(n(s.CGST_TAX) + n(s.SGST_TAX) + n(s.IGST_TAX))) < 0.05)
      storedConsistent++;
    if (samples.length < 4)
      samples.push({
        vch: s.VCH_NO,
        net: n(s.NET_AMT),
        rate: n(s.TAX_PRC),
        inter,
        webTax: bt.tax,
        dTax,
        webTot: bt.total,
        dTot,
      });
  }
  console.log(`invoices=${total}`);
  console.log(
    `TAX recompute: exact(<0.05)=${taxExact} close(≤1)=${taxClose} -> ${Math.round((100 * (taxExact + taxClose)) / total)}% within ₹1`,
  );
  console.log(
    `TOTAL recompute: exact(<0.05)=${totExact} close(≤1)=${totClose} -> ${Math.round((100 * (totExact + totClose)) / total)}% within ₹1`,
  );
  console.log(`desktop stored TAX_AMT == CGST+SGST+IGST: ${storedConsistent}/${total}`);
  console.log('samples: ' + JSON.stringify(samples));
  await pool.close();
  const ok = taxExact + taxClose >= total * 0.8 && totExact + totClose >= total * 0.8;
  console.log(ok ? 'COMPUTE_PARITY_OK' : 'COMPUTE_PARITY_REVIEW');
}
main().catch((e) => {
  console.error('FATAL', e.message);
  process.exit(1);
});
