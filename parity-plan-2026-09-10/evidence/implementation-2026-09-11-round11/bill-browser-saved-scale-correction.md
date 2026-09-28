# First browser run: exact saved-scale assertion correction

The first real run passed the previous fifteen journeys and reached the new bill preview. It stopped in the raw saved-value display check because the test expected NET_AMT `0` while the UI correctly displayed `0.00`. The failed log `browser-real.txt`, original result and failure screenshot remain unchanged.

Schema evidence: SL_DATA.NET_AMT/TAX_AMT/TOT_AMT are Decimal(18,2) at schema.prisma:5654/5659/5661; RTN_NET_AMT/RTN_TOT_AMT are Float at5702/5703. The saved reader retains SQL textual observations using `jsonb_each_text(to_jsonb(t))` (savedSaleReturn.ts:159). Consequently this physical fixture's exact raw values are NET_AMT `0.00`, TAX_AMT `7.00`, TOT_AMT `0.00`, RTN_NET_AMT `160`, and RTN_TOT_AMT `166.75`; the two nullable outstanding values remain NULL.

Only those three expected storage representations changed. The loop additionally checks each exact literal against both the metadata saved read and v2 savedHeader, and verifies the displayed value equals that exact metadata raw observation (NULL renders `Not stored`). Existing complete savedHeader equality remains. The independent numeric vector, phase matrices/totals and immutable required checks are unchanged. No API, UI or database changes were made. The corrected journey passed Node syntax checking; a new real browser run is still required.
