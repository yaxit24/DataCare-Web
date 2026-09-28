from pathlib import Path
import json
P=Path('/tmp/datacare-return-save-effects-analysis')
idx=json.loads((P/'source-effect-index.json').read_text())
queries={q['id']:q for q in idx['queries']}
# These deltas are authored literals from the cited source expressions, not calculator output.
changes={
'incoming-customer-ledger':{'CR_AMT':['110.00','111.00']},
'incoming-sale-account-ledger':{'DR_AMT':['110.00','111.00']},
'incoming-stock':{'OTH_AMT':['0.00','1.00'],'NET_AMT':['110.00','111.00']},
'return-outstanding-rojmel':{'CR_AMT':['110.00','111.00']},
'return-taxbook-summary-rojmel':{'DR_AMT':['110.00','111.00']},
'return-tax-sr1':{'NET_AMT':['110.00','111.00'],'TOT_AMT':['110.00','111.00']},
'return-tax-sr2':{'NET_AMT':['110.00','111.00'],'TOT_AMT':['110.00','111.00']}}
rows=[]
for ident,deltas in changes.items():
 q=queries[ident];before={};after={}
 for field in q['fields']:
  c=field['column'];expr=field['expression']
  if c in deltas:before[c],after[c]=deltas[c]
  elif expr.lower()=='null':before[c]=after[c]=None
  elif expr.isdigit():before[c]=after[c]={'sourceNumericLiteral':expr,'storedText':'must bind target type/scale; no JS Number'}
  elif len(expr)>=2 and expr[0]==expr[-1]=="'" and "'" not in expr[1:-1]:before[c]=after[c]=expr[1:-1]
  else:before[c]=after[c]={'unchangedSourceBinding':expr,'resolution':'exact trusted raw/master/config plus separately qualified source expression; unresolved is not empty/zero'}
 rows.append({'role':ident,'table':q['table'],'cardinality':1,'source':q['source'],'beforeSourceOwnedColumns':before,'afterSourceOwnedColumns':after,'typedDelta':{k:{'before':v[0],'after':v[1]} for k,v in deltas.items()},'allOtherStoredColumns':'preserve exact observed strings/NULL, row identity, locator and revision unless this row has a nonempty typedDelta; do not insert defaults for unmentioned schema columns'})
def unchanged(table,count,source,qual):return {'table':table,'beforeCount':count,'afterCount':count,'source':source,'action':'preserve exact raw/physical snapshot when admitted','qualification':qual}
fixture={
'kind':'independent-source-bound-before-after-inventory',
'status':'symbolic metadata bindings retained; NOT an executable complete SQL fixture or implementation acceptance',
'profile':{'id':'P1-T-split-zero-tax-other-one-prospective','event':{'kind':'moneyLeave','fieldId':'x13.primary-incoming.c27','editorText':'1'},'requiredCompleteRowBranch':'One saved P/I N incoming row, SR_NO/ordinal1, OLD_SRNO1, stable nonzero instance, PCS1/NWT10, retained metal100/labour10, MRP0/discount0/rowtax0, authoritative configuration keeping every unowned persisted field unchanged. Full core hydration fixture must be independently supplied.','header':'RTN_NET/RTN_TOT/RTN_BILL_OS110; all received monetary fields/tenders/kasar/header tax/hallmark tax zero; account !=00045; source clocks/header metadata already exact.','book':'One canonical BOOK_DATA MAIN_BOOK SALES RETURNE / INOUT I / BOOK_TYPE T / BOOK_TBL_NAME SL_DATA, and exactly one qualifying BOOK_DETL SR_NO1 with coherent type/name/data type; date>=qualified MOp_dt.','tax':'Non-UAE company; exact account GST type N; exactly one matching TAX_MAST row SR1 and SR2, no other matching alias/duplicate/interstate or hallmark effect; both TAX_PRC0.','remainingAuthority':'Current preview restrictions, BAR N branch and USER_UPDATE N policy must be resolved by an explicitly reviewed next profile; no existing capability is upgraded by this fixture.'},
'principalChanges':[
 {'table':'SL_DETL_RTN','cardinality':1,'identity':{'SR_NO':'1','OLD_SRNO':'1','TAG_NO':'N','VCH_SRNO':'trusted unchanged nonzero raw','TAG_SRNO':'trusted unchanged raw','IT_CODE':'trusted unchanged exact item'},'typedDelta':{'OTH_AMT':{'before':'0.00','after':'1.00'},'TOT_AMT':{'before':'110.00','after':'111.00'},'NET_AMT':{'before':'110.00','after':'111.00'}},'source':'TR_SALE_RTN14307–14584; exact candidates must come from source mapper plus complete event replay','allOtherColumns':'unchanged raw, including NULL description and all hidden scalars'},
 {'table':'SL_DATA','cardinality':1,'typedDelta':{'RTN_NET_AMT':{'before':'110','after':'111'},'RTN_TOT_AMT':{'before':'110','after':'111'},'RTN_BILL_OS':{'before':'110','after':'111'}},'source':'TR_SALE_RTN12707,12789,12809','allOtherColumns':'unchanged raw under proposed limited web edit; source full Save resets are not silently adopted'}],
'financialEffects':rows,
'preservedOrAbsent':[
 unchanged('BAR_DATA',1,'TR_SALE_RTN13072–13140','Source condition MRP!=0 OR PCS+NWT+OTHER!=0 holds before11 and after12. Twelve source assignments plus Vch_Remark scoped AC_CODE blank maintenance qualify source-shaped header; absence is a separate unsupported/source-difference decision.'),
 unchanged('BAR_DETL',1,'TR_SALE_RTN10369,13901–14229','Literal N is nonblank; source condition PCS+NWT+NET!=0 holds before121 and after122. All74 ordered source assignments indexed. None directly reads c27/36/38 as a stored valuation; code29/30/31/32/33/34/35 owns tag valuation. Require every mapped BAR value unchanged. Current preview rejects this parent; not admitted by this inventory.'),
 unchanged('TEMP_BOOK_DATA',1,'TR_SALE_RTN12515–12570','Identity is company/location/book/HD_VCH_NO without year. BOOK_NAME comes from FormName/current configured book display name. Must observe all competing year/header references to that hidden number.'),
 unchanged('REMARK_DATA','0 if exact saved VCH_DESC empty or SQL NULL; otherwise1','Ac_Tax563–824, especially751','MsSrNo0 + BOOK_TBL_NAME SL_DATA selects SR_NO0, header AC_CODE/date/VCH_DESC and master AC_NAME. Canonical master cardinality and existing remark must agree. No numeric delta.'),
 unchanged('SL_DETL',0,'TR_SALE_RTN12499; Ac_Stock245; Ac_Ledr1345/1347','No outgoing exchange.'),
 unchanged('SL_IDTL',0,'TR_SALE_RTN12503; Ac_Stock806','No outgoing components.'),
 unchanged('BAR_IDTL',0,'TR_SALE_RTN13164–13185; Ac_Stock808','No source incoming component rows; prove absence independently of BAR parent N.'),
 unchanged('DM_DATA',0,'TR_SALE_RTN13451–13459; Ac_Stock804–810','Both component joins have no rows; unknown existing DM means refusal, not delete.'),
 unchanged('BILL_OS_DATA',0,'TR_SALE_RTN13194–13225','Received total remains0; payment RTN_BILL_OS111 does not create an outstanding row.'),
 unchanged('USER_DATA','conditional unresolved','TR_SALE_RTN13465–13564','Edition E saved edit creates per-changed-header field audit rows with current clock, users and caption metadata. This is not proved inert by incoming-only/tax0. Qualify edition or a deliberate web audit compatibility policy before release.'),
 unchanged('all source/settlement/allocation/transfer references','unchanged membership','First write admission requirement','Do not infer absence from empty effect tables. Enumerate reference owners and lock/version protocol before DML; unknown rows block.'),
 unchanged('all unrelated tenant/company/location/year/book/voucher rows','unchanged','Bounded web ownership policy','Do not execute desktop global BAR_DATA AC_CODE NULL or SL_DATA RATE_UNFIX NULL maintenance.')],
'rowCountQualification':'When the exact T/noninterstate/master predicates and source-shaped BAR/temp metadata qualify, nine existing rows have numeric deltas: one saved line, one header, two account, one stock, two Rojmel, two tax. BAR header/parent/temp and optional remark have no value delta. Physical preservation for unchanged rows is the intended web policy, not desktop delete/reinsert parity. USER_DATA remains a release blocker until edition/audit policy is qualified.',
'bodyAndAuthority':'Only server-replayed c27 history and retained exact scope/context/document/dependency tokens; no client rows/mode/table/policy/effect values. All save capabilities remain false in this analysis.'}
(P/'expected-before-after.inventory.json').write_text(json.dumps(fixture,indent=2)+'\n')
print('source-owned financial columns',sum(len(r['beforeSourceOwnedColumns']) for r in rows),'effect roles',len(rows))
