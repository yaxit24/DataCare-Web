from pathlib import Path
import json,re,hashlib
ROOT=Path('/Users/yakshitsavaliya/Desktop/imodule-extracted')
OUT=Path('/tmp/datacare-return-save-effects-analysis')
SRC=ROOT/'unified/src/csharp/DataCareNext'
def ref(name,line):
 p=SRC/name
 return {'path':str(p),'sha256':hashlib.sha256(p.read_bytes()).hexdigest(),'line':line}
def split_sql(value):
 # Only split source SELECT expressions at top-level commas, retaining quoted SQL text.
 out=[];start=0;depth=0;quoted=False;i=0
 while i<len(value):
  ch=value[i]
  if ch=="'":
   if quoted and i+1<len(value) and value[i+1]=="'":i+=2;continue
   quoted=not quoted
  elif not quoted:
   if ch=='(':depth+=1
   elif ch==')':depth-=1
   elif ch==',' and depth==0:out.append(value[start:i].strip());start=i+1
  i+=1
 out.append(value[start:].strip());assert not quoted and depth==0
 return out
specs=[('incoming-customer-ledger','Ac_Ledr.cs',1324),('incoming-sale-account-ledger','Ac_Ledr.cs',1326),('incoming-stock','Ac_Stock.cs',247),('return-outstanding-rojmel','Ac_Rojmel.cs',586),('return-taxbook-summary-rojmel','Ac_Rojmel.cs',588),('return-nontaxbook-detail-rojmel','Ac_Rojmel.cs',590),('return-tax-sr1','Ac_Tax.cs',191),('return-tax-sr2','Ac_Tax.cs',193),('return-interstate-tax-sr3','Ac_Tax.cs',195),('outgoing-diamond','Ac_Stock.cs',806),('incoming-diamond','Ac_Stock.cs',808)]
queries=[]
for ident,name,line in specs:
 s=(SRC/name).read_text().splitlines()[line-1]
 m=re.search(r'(?:INSERT INTO|Insert Into) (\w+)\s*\((.*?)\)\s+Select (.*?)\s+FROM',s)
 assert m,(ident,line)
 cols=split_sql(m[2]);exprs=split_sql(m[3]);assert len(cols)==len(exprs),(ident,len(cols),len(exprs))
 queries.append({'id':ident,'table':m[1],'source':ref(name,line),'fields':[{'column':c,'expression':e} for c,e in zip(cols,exprs)],'fullSourceStatement':s.strip(),'qualification':'Source expression index only. Database/locale-dependent results and missing configuration are not invented values.'})
ls=(SRC/'TR_SALE_RTN.cs').read_text().splitlines()
assignments=[]
for ident,var,lo,hi in [('temp-header','dataRow',12520,12574),('saved-header','dataRow2',12575,12944),('bar-header','dataRow6',13072,13140),('bar-parent','dataRow7',13901,14225),('incoming-parent','dataRow5',14252,14584)]:
 rows=[]
 for i in range(lo-1,hi):
  m=re.search(r'\b'+var+r'\["([^"]+)"\] = (.*);',ls[i])
  if m:rows.append({'column':m[1],'expression':m[2],'line':i+1})
 assignments.append({'id':ident,'source':ref('TR_SALE_RTN.cs',lo),'range':[lo,hi],'assignments':rows,'qualification':'Ordered assignments; conditional alternatives and subsequent overrides must be resolved from the cited method, not merged as unconditional rows.'})
(OUT/'source-effect-index.json').write_text(json.dumps({'kind':'source-derived-static-index-no-runtime-execution','queries':queries,'dataRowAssignments':assignments},indent=2)+'\n')
print('SQL mappings',[(q['id'],len(q['fields'])) for q in queries]);print('dataRow mappings',[(a['id'],len(a['assignments'])) for a in assignments])
