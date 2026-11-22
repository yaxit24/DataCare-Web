# WP-19 Gst Report: decisions on the study's open questions (2026-11-22)

Owner decisions (asked and answered 2026-11-22):

- **Q1 GSTR-3B date scope:** the web sums From..To. The desktop sums only the From date although the title names the
  month; that is a desktop defect in a statutory figure. Deliberate difference.
- **Q2 "All Other ITC":** purchases only, as the web does now. The desktop also nets sales-return tax into ITC with a
  minus sign; not copied. Deliberate difference.
- **Q3 6.1 "State/Ut Tax":** the SGST total. The desktop prints the CGST total there; a desktop defect, not copied.

Architect decisions (owner may override):

- **Q4:** keep the web's `date-outside-year` and `invalid-date-range` refusals (a hosted service refuses impossible
  ranges); the cases expect the web texts and record the difference.
- **Q5:** RFC-4180 quoting plus spreadsheet-formula neutralisation in GST CSV is an accepted adaptation (G10).
- **Q6:** one whole-workbook XLSX with the desktop sheet names and order is the accepted adaptation of the Excel COM
  export (G11).
- **Q7:** there are 12 blocked cases, not 13; the master plan's count was stale.
- **Q8:** the worker that writes the tests reads the ranges the study did not (designer 905-1473, the print-rights
  message, the account and location key handlers, TCS in `shared/taxDataRows.ts`, `MsAlterYear`).
- **Q9:** the EXP.csv byte layout stays blocked until a Windows desktop run confirms it.
