# X13 bill preview UI: activation correction and scoped verification

Status: frontend implementation locally verified and frozen for root integration. Browser, production build and zero-business-write verification remain root-owned and pending in this note. This supersedes the product stage in x13-bill-replay-ui-ready.md and its run manifest; those original bytes remain unchanged as historical evidence.

## Actual independent finding and fix

The peer read review found a same-render activation race: the parent could reject preview activation because current metadata was dirty, a saved operation was pending, or the saved identity/owner had changed, yet the child's void callback still allowed open/busy/GET. That left a possible visible preview with no metadata-freezing owner. A successful isolated helper ownership test did not prove that integration was safe.

Both child start handlers now request parent acknowledgment **before** acquiring a request token, opening, marking busy or making GET. Explicit false aborts immediately. The parent returns the synchronous outcome of full saved context/generation/document matching and live operation/draft eligibility. The shared ownership helper refuses ineligible active claims; release remains possible for its own context even if eligibility changes later. Other-kind and stale-context closes still cannot release a current owner.

The existing v1 API, helper, journal, computation and test assertions are unchanged. Its component has only the callback return type broadened to boolean|void for existing-callback compatibility and the activation acknowledgment moved before startup. The new v2 component follows the same handshake. Old v1 behavior on an accepted activation is preserved; actual browser regression remains required.

All other response, transport, phase display and selector contracts from x13-bill-replay-ui-ready.md remain applicable. The new feature stays preview-only, with unresolved closing shown explicitly and no numeric values sent to metadata or legacy writers. The false acknowledgment fix does not expand any calculation, financial or permission capability.

## Verification after the fix

| Check | Evidence | Result |
| --- | --- | --- |
| New bill helper/ownership + unchanged v1/saved regressions | bill-ui-focused-activation.txt | 3 files,130 tests:67 new,32 v1,31 saved; zero skips |
| Complete web tsconfig typecheck | bill-ui-types-activation.txt | exit0 |
| Explicit strict isolatedModules test compile with JSX/import support | bill-ui-test-types-activation.txt | exit0 |
| Configured focused React Hooks ESLint | bill-ui-lint-activation.txt | exit0 |
| Nine owned/dependent input hashes before/after these checks | bill-ui-activation-inputs.json and bill-ui-activation-input-verification.json | unchanged |

The added case establishes false acknowledgment when live eligibility changes before the disabled render, no granted owner, subsequent valid acquisition, and release despite later ineligibility. The peer then independently re-read both start handlers and the actual parent integration and found no further confirmed phase/event/ownership/late-callback defect. That is static review, not a browser execution claim.

Historical ready-stage and initial compiler artifacts remain retained. In particular, the exploratory noUncheckedIndexedAccess run was not the web project's configured compiler and exposed old api.ts/v1-helper diagnostics; no repository-wide noUnchecked claim is made. The current standard strict web compiler and explicit strict isolated test compiler pass.

The next root browser must still exercise the new real API observation/journal and independent v1 controls, held requests, close/focus, stale document/config/master versions, input preservation, unsupported/empty/view-only states, table visibility/overflow and complete business-row snapshots before/after preview. Successful mathematical preview will not establish complete Sales Return source admission, financial writing, outgoing exchange, refund/tender/ledger posting or measured desktop-runtime parity.
