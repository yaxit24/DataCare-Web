# X13 original-sale source reader: root integration review

Scope: the new read-only source service, authenticated route adapters and exact source DTO. This does not accept the legacy import/create writer or enable source application, numeric editing, tag admission, stock consumption, accounting or reversal.

Root implemented two dedicated GET routes, `/sales-returns/source-vouchers` and `/sales-returns/source-items`, bound to `Sales/Sales Return` read rights. Both require the explicit current Return company/location/year/book. Original `sourceYear`, `sourceBook` and `sourceVchNo` stay separate from the selected Return scope. The central scope guard still rejects mismatched company/location/current year; strict query validation rejects arrays, unknown fields, client tenant and original company/location overrides. These routes deliberately do not use `book`, which the central guard treats as an alias for the current request book.

The first independent HTTP run passed54 route-policy checks plus7 authenticated source cases against disposable PostgreSQL55433 with the non-owner RLS role. The route universe is548. That run predates the final service-review corrections and is retained as `http-focused-first.txt`; final results must come from the later coordinated run. HTTP fixtures independently assert historical source year, same voucher in S73/S74, two authenticated tenants, OLD_SRNO31 components distinct from parent SR_NO17, exact large decimals/nulls/microseconds, source-generation changes and unchanged complete business-table snapshots after reads.

## Static findings sent to the service owner

1. The initial source-year parser allowed9 characters while configured YEAR_MAST and the source schema allow10. The list could return a registered10-character year that the detail rejected. Align the source parser to the actual10-character schema bound and test list/detail consistency.
2. Initial observed-row sorting used a canonical object containing physical locator before business values. That could order parents or children by ctid text instead of source SR_NO/ISR_NO, especially after unrelated inserts/updates. Return parent and child DTOs in explicit SQL numeric SR_NO/ISR_NO order with a stable physical tie breaker; retain raw values and physical versions separately. Test reversed insertion order and serials2/10.
3. Null/blank parent IT_CODE normalized to an empty lookup key and could resolve a blank item master. Preserve the raw code, provide an explicit blank-item diagnostic, and deny selection instead of treating a blank master as a valid item.
4. A linked Return with padded original location/year/book/voucher could be omitted by exact PostgreSQL string comparison, falsely leaving the source available. Find conservatively matching trimmed references and mark noncanonical raw references ambiguous. Preserve the exact original strings; never rewrite them or infer admission permission. Add padded location/year/voucher cases.

The service owner incorporated these changes before final acceptance. Its focused tests and the later root HTTP/full regression must verify the final source. Product-facing read-only explanations should tell operators that applying a source to a return is unavailable, while this evidence retains technical implementation boundaries.

## Remaining integration obligations

Read-time `version` and `recordId` are observation identities, not authorization to apply a sale. A future writer must resolve source/configuration and available consumption again atomically, preserve parent OLD_SRNO child ownership, reject unresolved companions, generate independent incoming admission identities, and update the complete incoming/outgoing/accounting write set with reversal and stale-edit protection. The new source readers must not be fed blindly into the old positional numerical payload.

No new source-selection UI, source-copy event wrapper, complete F1 transfer, physical desktop execution, customer-data mutation or business acceptance is claimed here.
