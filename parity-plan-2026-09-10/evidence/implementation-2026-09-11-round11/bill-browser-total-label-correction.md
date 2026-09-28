# Pre-browser total-label expectation correction

Root review identified an omitted literal in the new browser assertion builder. Primary TR_SALE_RTN:5178 sets `MSG_PR_TOT[0,5] = "Total :"` after clearing columns and before folding incoming rows. The loaded phase remains all blank; opened and calculated event phases include this label. The new journey now adds the exact label only when `totalsAllBlank` is not true. The full71-cell equality check is retained. No numeric expected value, production code, frozen independent vector or required-check definition changed.

The complete bill matrix labels were separately reread at TR_SALE_RTN:15917–15926, saved tax/bank/card mapping at10129–10169, and the old net/tax cache initialization at10129/10132. Their literals match the journey's independent full-matrix builder and frozen expected caches; no further adjustment was identified.

`node --check apps/web/test/sales-return-bill-replay.journey.mjs` passed after this one-line expectation correction. No browser or database run has occurred. The original `bill-browser-journey-ready.json` remains unchanged as historical pre-correction readiness; the new corrected manifest pins both that history and the updated journey.
