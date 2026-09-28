# Actual browser correction: committed item amount is recalculated

The second combined Round9 browser passed all fourteen earlier journeys, including the unchanged saved-book delayed-load regression, and reached the new preview's large saved editor case. It failed the new test's assumption that an explicit c20 ItAmt event containing `1200` would remain `1200.00` in the calculated preview.

The production response `1000.00` matches the primary desktop source. `TR_SALE_RTN.cs:4592–4664` formats a c20 LeaveCell then calls `CommPassTotal_Pr`. At4915–4936 the fixture's `SL_AMT_TYPE=N` yields net-plus-ghat basis10. At4941–4956, nonzero rate100 and nonzero basis-plus-pieces enter the amount switch on **every** numeric commit; saved `RATE_TYPE=N` selects the default `Math.Round(basis × rate,0)` branch. The rate cache comparison above does not guard this amount recalculation. Therefore the original editor event is `1200`, while the resulting amount is `1000.00`.

Only the test was corrected. It now asserts the exact submitted and returned original c20 event text/status, the recalculated1000.00, and the unchanged large baseline `9999999999999999.99`. All fifteen check descriptions remain unchanged. No product or formula was changed to fit the test. The failed `round9-corrected` browser evidence remains historical; a fresh combined run is required.
