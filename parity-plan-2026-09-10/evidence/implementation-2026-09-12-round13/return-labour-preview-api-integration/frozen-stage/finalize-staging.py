from pathlib import Path
import datetime,difflib,hashlib,json,re
S=Path('/tmp/datacare-return-labour-preview-api')
R=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted/web')
def h(p): return hashlib.sha256(p.read_bytes()).hexdigest()
def out(name,value): (S/name).write_text(json.dumps(value,indent=2)+'\n')
webfiles=sorted(p for p in (S/'web').rglob('*') if p.is_file())
assert len(webfiles)==10
modified=[p for p in webfiles if (S/'baseline'/p.relative_to(S/'web')).exists()]
assert len(modified)==4
baseline=[]
patch=[]
for p in webfiles:
    rel=p.relative_to(S/'web'); b=S/'baseline'/rel
    if b.exists():
        assert (R/rel).read_bytes()==b.read_bytes(), f'Parent changed {rel}; integrate as reviewed patch, never overwrite.'
        baseline.append({'path':str(R/rel),'baseline':str(b),'sha256':h(b),'unchanged':True})
    patch.extend(difflib.unified_diff(b.read_text().splitlines(True) if b.exists() else [],p.read_text().splitlines(True),fromfile='a/web/'+str(rel) if b.exists() else '/dev/null',tofile='b/web/'+str(rel)))
(S/'labour-preview-api.patch').write_text(''.join(patch))
old=(S/'baseline/apps/api/src/modules/sales/saleReturnBillReplay.ts').read_text(); new=(S/'web/apps/api/src/modules/sales/saleReturnBillReplay.ts').read_text()
# Template contents remain exact, including the existing SQL and hash inputs.
templates=lambda x: re.findall(r'`(?:\\.|[^`])*`',x)
assert templates(old)==templates(new)
pat=re.compile(r'\b(?:app|server)\.(get|post|put|patch|delete)\(\s*([\'\"`])([^\'\"`]+)\2')
routes=lambda paths:[(m[0].upper(),m[2]) for p in paths for m in pat.findall(p.read_text())]
a=routes([R/'apps/api/src/app.ts',S/'baseline/apps/api/src/routes/txn.ts'])
b=routes([R/'apps/api/src/app.ts',S/'web/apps/api/src/routes/txn.ts'])
added=sorted(set(b)-set(a)); expected=[('GET','/sales-returns/:vchNo/incoming-labour-replay-state'),('POST','/sales-returns/:vchNo/incoming-labour-observation'),('POST','/sales-returns/:vchNo/incoming-labour-replay')]
assert len(a)==553 and len(b)==556 and len(set(b))==556 and added==expected and not(set(a)-set(b))
service=(S/'web/apps/api/src/modules/sales/saleReturnLabourReplay.ts').read_text()
assert not re.search(r'\bwithTenant\b|\$executeRaw|\$queryRaw|\$transaction',service)
review=json.loads((S/'independent-review/inputs.json').read_text())
for item in review['files']: assert h(Path(item['path']))==item['sha256'],item['path']
fixture=S/'web/apps/api/test/fixtures/saleReturnLabourReplay.independent.json'
assert h(fixture)=='22cdfb8963c39dd50e3c41d1277d5d7549f3a65fb507598e1d8013deadc258bc'
out('static-preservation-check.json',{'status':'static-checks-complete-not-runtime-validation','baselines':baseline,'billTemplateLiteralsUnchanged':len(templates(old)),'oldRouteIdentitiesRetained':len(a),'newRouteCount':len(b),'newUniqueRouteCount':len(set(b)),'onlyAddedRoutes':[{'method':m,'path':p} for m,p in added],'oldReducersAndPreviewAllowlists':'No staged files modify these modules. Final integration must run existing regressions.','newServiceDirectDatabaseMutationOrNestedTransactionCalls':False,'independentReviewReferencesVerified':len(review['files']),'frozenLiteralFixtureSha256':h(fixture)})
(S/'README.md').write_text('''# Saved Return labour preview API — staged handoff

Ready for parent integration and coordinated checks. This directory contains ten staged web files: four replacements (the existing bill observer, transaction routes, route policy and its inventory test) and six new service/test/fixture files. `labour-preview-api.patch` uses repository-relative `web/` paths. Parent must apply against the captured baselines, integrate the separately owned session read helper, and run verification before assigning acceptance credit.

No compiler, runtime test, database, browser, production build or mainrepo mutation was performed by this owner. New executable coverage is **30 parser/error-bound cases + 17 real PostgreSQL cases + 10 authenticated HTTP cases = 57 declared cases**, currently unexecuted. The existing 54-case route policy file retains its assertions, updates only the exact 553→556 inventory and adds all three named Sales Return read actions to its existing ownership table. The input manifest and static preservation check are evidence of staged bytes and bounded source inspection, not test passes.

## Implemented profile

`x13-saved-incoming-labour-bill-replay-v1` / `saved-primary-incoming-resolved-labour-bill-preview-v1` exposes a separate GET state, POST code observation, and POST append preview. All three require both current page-context headers and fresh Sales Return View admission through the separately owned RepeatableRead session helper. Both POSTs are read policies and receive no-store responses. The helper retains its session SHARE lock and final live/context check; it is not a universal guarantee for unrelated writers. No extra session touch, receipt, refresh rotation, financial write or numeric save was added.

The saved bill observer now exports its existing same-transaction observation with one optional before-projection hook. Existing wrappers omit the hook; their DTO, version inputs, saved phases and money allowlist remain unchanged. The hook lets the third profile compare the base token and every distinct historical master observation before projection and before admitting a new code. New tokens bind the admitted logical session identity/epoch, exact saved scope, existing bill dependency version and semantic versions; JTI-only refresh does not become a semantic dependency.

Lookup reconstructs the complete accepted prefix and validates a private pre-calculation code copy without appending or calculating that candidate. Append reconstructs the same complete prefix, verifies the candidate observation and applies exactly one event. Money and resolved c13/c29 events may interleave. Same-code Enter remains an event. The pure composer owns complete pre-copy rollback through row, totals and bill; exposing the row reducer alone would not provide that guarantee. A matched but unreconstructable old prefix is refused, never silently shortened or rebased.

Ordinary candidate 422 responses include the exact previous prefix, and are emitted only after the read helper's final live/context check. Stale responses carry no replacement prefix. Request JSON is limited to 65,536 bytes and 100 accepted events; every complete public success/error envelope is limited to 2,097,152 bytes. If the complete error plus recovery exceeds this bound, a short 422 unsupported-output response omits recovery entirely. No partial/truncated prefix is emitted; the browser must retain its local prefix/draft and explicitly reload. The exact-bound unit case qualifies only the serializer boundary, not an observed production-sized saved document.

## Source and literal expectations

The approved contract remains `/tmp/datacare-return-labour-preview-next/implementation-contract.md`. The independent 62,675-byte fixture was frozen before this API implementation, SHA256 `22cdfb8963c39dd50e3c41d1277d5d7549f3a65fb507598e1d8013deadc258bc`. `author-http-literals.py` supplies literal expectations and shape copies without executing a calculator. It records complete 63-cell visible, eight-cache, twelve-editor, 71-total and 9×6 bill states for the loaded/opened baseline and eight reachable prefixes. Historical contract candidates and the earlier 24-copy/23-composition fixtures remain immutable.

Primary desktop `TR_SALE_RTN.cs` 4248–4380 supplies c13/c29 Enter copy and callback order; 4866–5158 supplies row calculation and downstream callbacks; 5162–5202 supplies the ordered totals fold; 16381–16458 supplies bill/tax cache phases. Saved row/header projection comes from 10353–10438 and 10112–10169. The pre-existing source review/contract records the precise mathematical decimal profile rather than claiming measured Double/Format or Windows runtime parity.

The literal fixture discriminates BB→AA tax history (132 then 121, not restoration to 117), interleaved money events, unchanged AA/tag category04 callbacks, fixed category03 amount overwritten by an old rate-cache difference, and zero-rate copying. DB tests assert all literal cells/caches/phases. A separate source-derived large-value recipe targets actual post-copy bill rejection and compares its whole recovered prefix to a separately successful first-prefix request; this recipe is unexecuted and must be diagnosed from source if it fails, never adjusted merely to observed output.

## Verification and limits

The DB/HTTP fixtures use isolated tenant IDs, owner seeding and the runtime app_user client. They preserve exact JSON text plus xmin/ctid across 33 business/configuration/session tables; xmax is excluded because row locks affect it. Intentional authenticated HTTP audit rows are checked separately, including rejected POSTs that reach the audited handler; early authentication/page-header rejection retains existing audit behavior. The HTTP harness waits for its appended onResponse completion hook before checking audit state. Real signed login/session/cookies and a same-scope epoch bump are covered, without mocking authentication or the new service.

Master admission observes full raw SQL text and physical extant-row identity in the caller's RepeatableRead snapshot. Current PostgreSQL case/ASCII-space aliases are conservatively contained; this does not prove historical SQL Server collation parity or absent→insert→delete history. A coherent as-of-start snapshot is not a promise of the latest state at response time. The new profile remains bounded to existing supported saved incoming states and configured nonzero c13/c29 widths. Source/F1/new-row/outgoing admission, full financial parity, closing authority, numeric persistence and application of a source remain unavailable.

The peer review under `independent-review/` found no confirmed source blocker and includes the complete public error-envelope correction; it grants no runtime credit. `ready-manifest.json` pins current staged bytes, baselines, contract, literal author/fixture, review, shared helper and directly relevant existing dependencies. Parent owns final integrated input snapshots, compiler, focused old/new regressions and real browser evidence. No integration or production acceptance is implied by this handoff.
''')
refs={}
def ref(p,kind):
 p=Path(p); assert p.is_file(),p
 refs[str(p)]={'path':str(p),'kind':kind,'bytes':p.stat().st_size,'sha256':h(p)}
for p in webfiles: ref(p,'staged-web-input')
for p in (S/'baseline').rglob('*'):
 if p.is_file(): ref(p,'unchanged-integration-baseline')
for name in ['README.md','labour-preview-api.patch','static-preservation-check.json','baseline-inputs.json','author-http-literals.py','finalize-staging.py','independent-review/service-read-review.md','independent-review/inputs.json']:ref(S/name,'handoff-evidence')
for name in ['implementation-contract.md','http-ui-independent-candidates.json','inputs.json']:ref(Path('/tmp/datacare-return-labour-preview-next')/name,'frozen-prospective-contract')
for item in review['files']: ref(item['path'],'source-review-input')
for rel in ['apps/api/src/app.ts','apps/api/src/modules/auth/sessionContextReadSnapshot.ts','apps/api/src/modules/auth/sessionContextAccess.ts','apps/api/src/modules/sales/savedSaleReturn.ts','apps/api/src/modules/sales/saleReturnIncomingConfiguration.ts','apps/api/test/fixtures/saleReturnBillReplay.fixture.ts','packages/core/src/index.ts','packages/core/src/saleReturnIncoming.ts','packages/core/src/saleReturnIncomingProjection.ts','packages/core/src/saleReturnBillProjection.ts','packages/core/src/saleReturnIncomingAggregate.ts','packages/core/src/saleReturnBillTaxPolicy.ts','packages/core/src/saleReturnIncomingLabour.ts','packages/core/src/money.ts']:
 ref(R/rel,'current-integration-dependency')
ref(R.parent/'unified/src/csharp/DataCareNext/TR_SALE_RTN.cs','desktop-primary-source')
ref('/tmp/datacare-return-labour-compose-contract/inputs.json','frozen-composition-contract')
out('ready-manifest.json',{'kind':'staged-saved-return-labour-preview-api','status':'frozen-ready-for-parent-integration-unexecuted','capturedAtUtc':datetime.datetime.now(datetime.timezone.utc).isoformat(),'validation':{'runtime':'not-run','compiler':'not-run','database':'not-run','browser':'not-run','newDeclaredCases':{'unit':30,'database':17,'http':10,'total':57},'existingRoutePolicyCases':54,'stagedWebFiles':10,'modifiedBaselineFiles':4,'newWebFiles':6,'staticChecks':'static-preservation-check.json'},'integrationFiles':[str(p.relative_to(S)) for p in webfiles],'references':list(refs.values())})
print(json.dumps({'manifest':str(S/'ready-manifest.json'),'manifestSha256':h(S/'ready-manifest.json'),'patchSha256':h(S/'labour-preview-api.patch'),'referenceCount':len(refs),'webFiles':len(webfiles),'readmeSha256':h(S/'README.md')}))
