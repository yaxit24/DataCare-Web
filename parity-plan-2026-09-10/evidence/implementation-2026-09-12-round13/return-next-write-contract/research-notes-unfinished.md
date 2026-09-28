# Unfinished research notes — paused for integrated API fixture diagnosis

Read-only research, no acceptance or implementation. Authoring was paused before the next contract or input manifest was complete.

Main plan X13 remains open (12-execution-addendum.md:548–582): complete source admission, outgoing/variants, trusted mode/closing, numeric stock/accounting writes, settlement/reversal. Newly integrated labour preview does not confer save authority.

Current generic writer is web/apps/api/src/modules/sales/salesReturn.ts (plural). It uses generic sales computeLine/billTotals and Number input, creates new Return, not the new ordered saved incoming replay. It writes ENTRY_TYPE R whereas saved preview supports P incoming; header writes NET/TAX/TOT and generic refund fields, not the full desktop RTN payment/received phase contract. Reusing its create/replacement path for saved preview would erase raw values/identities and change arithmetic. No new product fault conclusion made: it is a different currently bounded path.

Desktop TR_SALE_RTN BtnSave region starts before12180. At12376+ it calls outgoing MSG_TOT_FILL then incoming MSG_PR_TOT_FILL before zero-value guard; it does not simply calculate every row on save. At12496+ it deletes/recreates header/outgoing sets; numeric acceptance must trace complete footprint and deliberately retain transactional atomicity, not copy destructive SQL blindly. Need exact later row/BAR/AC/stock/tax/commission mappings still to inspect.

Known ledger remains blocked by authority: sessionContextValue accepts only unknown mode/null and three reasons, while core pure mode and desktopAccountBalance internal reader accept semantic A/B/C without authentication. Clock adapter is implemented canonical saved PG Date plus timestamp time. A server-approved classification provider/mode command authorization/persisted provenance contract is still missing; cannot hardcode or accept browser mode. Full helper qualification needs monetary, Gold and Silver sums, not amount alone (round10 source addendum). New balance must join same RR with session/header/config/master/physical ledger and invalidate old prefix on dependencies. Neither pure mode nor preview token authorizes save.

Potential smallest safe next code slice (not finalized): pure immutable source save-projection/effect-plan prerequisite for already admitted saved rows/bill state, no DML, no guessed defaults, explicit unsupported external effects. Known closing remains a separate authority-gated integration; no fake zero.
