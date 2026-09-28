"""Literal source mapping fixtures. No imports/evaluation of any TS implementation.
Copies complete literal maps and applies explicitly authored scalar overrides only.
Run once before saleReturnIncomingSaveProjection.ts exists; refuses overwrite.
"""
from pathlib import Path
from copy import deepcopy
import json, hashlib

ROOT = Path(__file__).parent
SOURCE = ROOT / 'web/packages/core/src/saleReturnIncomingSaveProjection.ts'
TARGET = ROOT / 'web/packages/core/test/fixtures/saleReturnIncomingSave.independent.json'
assert not SOURCE.exists() and not TARGET.exists()

# Full current SL_DETL_RTN scalar shape plus one future raw extension.
RAW = {
    'tenant_id':'map-fixture', 'CO_CODE':'01', 'LC_CODE':'01', 'CO_YEAR':'2024-2025',
    'CO_BOOK':'R11', 'VCH_NO':'00017', 'SR_NO':'1', 'OLD_SRNO':'31',
    'VCH_DATE':'2024-07-10', 'VCH_TYPE':'SR', 'INOUT_TYPE':'I', 'ENTRY_TYPE':'P',
    'VCH_TIME':'2024-07-09T23:59:59.999999', 'BOOK_NAME':'SALES RETURN', 'AC_CODE':'CUST',
    'IT_CODE':'GOLD', 'TAG_NO':'N', 'TBL_CODE':'001', 'DESIGN_NO':' D-raw ', 'ITM_SIZE':None,
    'ITM_PCS':'1.000','ITM_GWT':'10.000','ITM_OTH_WT':'0.000','ITM_NWT':'10.000',
    'ITM_GHT_WT':'0.000','ITM_TOUCH':'100.000','ITM_WEST_PRC':'0.0000','ITM_FINE':'10.000',
    'ITM_RATE':'10.00','ITM_AMT':'100.00','LBR_TYPE':'N','LBR_PRC':'0.0000',
    'LBR_RATE':'1.00','LBR_AMT':'10.00','OTH_AMT':'0.00','TAG_LBR_PRC':'0.0000',
    'TAG_LBR_RATE':'0.00','TAG_LBR_AMT':'0.00','TAG_OTH_AMT':'0.00','ITM_MRP':'0.00',
    'TOT_AMT':'110.00','TAX_PRC':'0.0000','NET_AMT':'110.00','RATE_TYPE':'N','IT_TYPE':'G',
    'HD_VCH_NO':'HD-17','MAIN_USER':'original user','DATA_TRFR':None,'KR_NAME':'KR',
    'TAG_COST':'0.00','ITM_MARGIN':None,'VCH_SRNO':'500001','TAG_TYPE':'A','PR_CODE':'P1',
    'TAG_SRNO':'123','ITM_GHT_PRC':'0.0000','HM_ID2':None,'HM_ID3':'H3','HM_ID4':'H4',
    'HM_ID_WT':'0.000','HM_ID2_WT':'0.000','HM_ID3_WT':'0.000','HM_ID4_WT':'0.000',
    'HM_ID':'H1','ITM_REMARK':None,'ITM_COLOR':'retained color','EMP_CODE':None,
    'LBR_CODE':'AA','TAG_MRP':'0.00','TAG_LBR_CODE':'','DESIGN_IMG_ID':None,
    'EMP_ISU':'N','APR_ISU':'N','ITM_STYLE':'Style','ITM_LOT':None,
    'DISC_PRC':'0.0000','DISC_AMT':'0.00','RTN_IT_TAX_AMT':None,'DATA_TYPE':'A',
    'FUTURE_EXTENSION':'raw\ntext\u2603',
}
VISIBLE = {
    '0':'1','1':'GOLD','2':'N','3':'Current master name','4':'001','5':' D-raw ',
    '6':'Style','7':'','8':'H1','9':'1.000','10':'10.000','11':'0.000','12':'10.000',
    '13':'AA','14':'0.00','15':'0.000','16':'100.00','17':'0.00','18':'10.000',
    '19':'10.00','20':'100.00','21':'0.00','22':'N','23':'1.00','24':'10.00',
    '25':'0.00','26':'0.00','27':'0.00','28':'0.00','29':'AA','30':'0.00',
    '31':'0.00','32':'0.00','33':'0.00','34':'0.00','35':'0.00','36':'110.00',
    '37':'0.00','38':'110.00','39':'KR','40':'500001','41':'','42':'','43':'G',
    '44':'N','50':'N','51':'31','52':'P1','53':'UNUSED53','54':'A','55':'G',
    '56':'123','57':'UNUSED57','59':'','60':'H3','61':'H4','62':'0.000',
    '63':'0.000','64':'0.000','65':'0.000','68':'N','69':'','70':'A',
}
# All58 target values entered independently of a generated source/column loop.
FIELDS = {
    'SR_NO':'1','OLD_SRNO':'31','IT_CODE':'GOLD','ITM_REMARK':'Current master name',
    'TAG_NO':'N','TBL_CODE':'001','DESIGN_NO':' D-raw ','ITM_STYLE':'Style','ITM_SIZE':'',
    'HM_ID':'H1','ITM_PCS':'1','ITM_GWT':'10','ITM_OTH_WT':'0','ITM_NWT':'10',
    'ITM_GHT_PRC':'0','ITM_GHT_WT':'0','ITM_TOUCH':'100','ITM_WEST_PRC':'0','ITM_FINE':'10',
    'ITM_RATE':'10','ITM_AMT':'100','LBR_CODE':'AA','LBR_PRC':'0','LBR_TYPE':'N',
    'LBR_RATE':'1','LBR_AMT':'10','DISC_PRC':'0','DISC_AMT':'0','OTH_AMT':'0','ITM_MRP':'0',
    'TAG_LBR_CODE':'AA','TAG_LBR_PRC':'0','TAG_LBR_RATE':'0','TAG_LBR_AMT':'0',
    'TAG_OTH_AMT':'0','TAG_COST':'0','TAG_MRP':'0','TOT_AMT':'110','TAX_PRC':'0','NET_AMT':'110',
    'KR_NAME':'KR','VCH_SRNO':'500001','RATE_TYPE':'N','PR_CODE':'P1','TAG_TYPE':'A',
    'TAG_SRNO':'123','HM_ID2':'','HM_ID3':'H3','HM_ID4':'H4','HM_ID_WT':'0','HM_ID2_WT':'0',
    'HM_ID3_WT':'0','HM_ID4_WT':'0','APR_ISU':'N','EMP_ISU':'N','IT_TYPE':'G',
    'DESIGN_IMG_ID':'','DATA_TYPE':'A',
}
assert len(VISIBLE)==63 and len(FIELDS)==58
CASES=[]
def case(id, note, visible=None, raw=None, mapped=None, patch=None, code=None, ordinal=1):
    v=deepcopy(VISIBLE);v.update(visible or {});r=deepcopy(RAW);r.update(raw or {})
    f=deepcopy(FIELDS);f.update(mapped or {})
    CASES.append({'id':id,'note':note,'input':{'rowIdentity':'a'*64,'ordinal':ordinal,'raw':r,'visible':v},
        'expected':{'status':'unsupported' if code else 'ready','sourceFieldValues':f,
        'candidatePatch':None if code else patch or {},'diagnosticCode':code,'raw':deepcopy(r),
        'canCommit':False}})
case('S01','Full mapping, no-effect row projection, raw description NULL and TAG_LBR_CODE fallback retained')
case('S02','Literal c27 0→1 poststate, no calculator execution',{'27':'1.00','36':'111.00','38':'111.00'},mapped={'OTH_AMT':'1','TOT_AMT':'111','NET_AMT':'111'},patch={'OTH_AMT':'1.00','TOT_AMT':'111.00','NET_AMT':'111.00'})
case('S03','Literal fractional Other; header rounding not part of this fixture',{'27':'0.01','36':'110.01','38':'110.01'},mapped={'OTH_AMT':'0.01','TOT_AMT':'110.01','NET_AMT':'110.01'},patch={'OTH_AMT':'0.01','TOT_AMT':'110.01','NET_AMT':'110.01'})
case('S04','Blank Val numeric means zero without touching raw zero',{'27':'   '})
case('S05','Exact blank tag and row-data defaults reproduce stable stored values',{'2':'','70':''})
case('S06','Blank Val rate/amount mapping may remain zero without NULL coercion',{'23':'','24':''},raw={'LBR_RATE':'0.00','LBR_AMT':'0.00'},mapped={'LBR_RATE':'0','LBR_AMT':'0'})
case('S07','Source c54 used for TAG_TYPE, c55 ignored',{'54':'B','55':'NOT-SAVED'},raw={'TAG_TYPE':'B'},mapped={'TAG_TYPE':'B'})
case('S08','Large exact numeric18,2 above Number precision',{'27':'9999999999999998.99','36':'9999999999999999.99','38':'9999999999999999.99'},mapped={'OTH_AMT':'9999999999999998.99','TOT_AMT':'9999999999999999.99','NET_AMT':'9999999999999999.99'},patch={'OTH_AMT':'9999999999999998.99','TOT_AMT':'9999999999999999.99','NET_AMT':'9999999999999999.99'})
case('S09','Owned raw scale and negative zero preserved when mathematically equal',raw={'OTH_AMT':'-0.00','TOT_AMT':'110.000','NET_AMT':'110.000'})
case('S10','Source c12+c38 cancellation omits row',{'27':'-120.00','36':'-10.00','38':'-10.00'},mapped={'OTH_AMT':'-120','TOT_AMT':'-10','NET_AMT':'-10'},code='unsupported-row-omission')
case('S11','Blank item source omission',{'1':''},mapped={'IT_CODE':''},code='unsupported-row-omission')
case('S12','Source serial normalization refuses imported17',raw={'SR_NO':'17'},code='unsupported-row-renumber')
case('S13','Zero instance source allocation refuses',{'40':'0'},raw={'VCH_SRNO':'0'},mapped={'VCH_SRNO':'0'},code='unsupported-instance-allocation')
case('S14','Hidden old serial conflict',{'51':'32'},mapped={'OLD_SRNO':'32'},code='row-identity-conflict')
case('S15','Hidden tag serial conflict',{'56':'124'},mapped={'TAG_SRNO':'124'},code='row-identity-conflict')
case('S16','Unowned numeric side effect requires expanded ownership',{'24':'11.00'},mapped={'LBR_AMT':'11'},code='unowned-numeric-change')
case('S17','Saved precision lost in display remains unowned and refused',raw={'LBR_PRC':'0.0049'},code='unowned-numeric-change')
case('S18','Required raw numeric NULL remains visible in refusal',raw={'LBR_RATE':None},code='unsupported-raw-numeric-null')
case('S19','Storage scale cannot silently round',{'27':'0.001'},mapped={'OTH_AMT':'0.001'},code='unsupported-storage-precision')
case('S20','Storage magnitude cannot overflow',{'27':'10000000000000000'},mapped={'OTH_AMT':'10000000000000000'},code='unsupported-storage-precision')
case('S21','Zero row net is outside first ordinary credit subprofile',{'27':'-110.00','36':'0.00','38':'0.00'},mapped={'OTH_AMT':'-110','TOT_AMT':'0','NET_AMT':'0'},code='unsupported-credit-row')
case('S22','Negative net received-side state refused',{'27':'-200.00','36':'-90.00','38':'-90.00'},mapped={'OTH_AMT':'-200','TOT_AMT':'-90','NET_AMT':'-90'},code='unsupported-credit-row')
case('S23','Nonzero row tax is outside initial writer subprofile',{'37':'1.00'},raw={'TAX_PRC':'1.0000'},mapped={'TAX_PRC':'1'},code='unsupported-row-tax')
case('S24','Missing raw data type cannot be silently defaulted',{'70':''},raw={'DATA_TYPE':None},code='row-identity-conflict')
case('S25','Canonical B row data is separate from session mode',{'70':'B'},raw={'DATA_TYPE':'B'},mapped={'DATA_TYPE':'B'})
case('S26','Positive row amount below whole-unit threshold only maps; final bill guard still required',{'27':'-109.51','36':'0.49','38':'0.49'},mapped={'OTH_AMT':'-109.51','TOT_AMT':'0.49','NET_AMT':'0.49'},patch={'OTH_AMT':'-109.51','TOT_AMT':'0.49','NET_AMT':'0.49'})
obj={'kind':'independent-full-save-map-literals-v1','authorship':'Authored before new implementation exists; all58 expected targets and raw/visible literals are source-entered. Override copying performs no source calculator/projection execution. Maps are candidate poststates, not proven replay or write effects.','sources':['TR_SALE_RTN.cs:14252,14307-14584','schema.prisma:5867-5960','mandatory stock identity erratum; effects remain unimplemented'],'cases':CASES}
TARGET.write_text(json.dumps(obj,indent=2)+'\n')
(ROOT/'fixture-authorship.json').write_text(json.dumps({'implementationExisted':False,'runtimeExecuted':False,'literalCases':len(CASES),'visibleFields':63,'sourceTargetFields':58,'fixtureSha256':hashlib.sha256(TARGET.read_bytes()).hexdigest()},indent=2)+'\n')
print(hashlib.sha256(TARGET.read_bytes()).hexdigest())
