"""Build review-only registers from fresh measurements and the retained mapping.

Run from anywhere: python3 parity-plan-2026-09-10/build_registers.py
No application, baseline, customer data or earlier progress file is modified.
Mappings inherited from the old matrix are candidates, never parity certificates.
"""
from pathlib import Path
import collections
import json
import re

OUT = Path(__file__).resolve().parent
ROOT = OUT.parent
E = OUT / 'evidence'

def read(path):
    return json.loads(path.read_text())

def dump(name, value):
    (E / name).write_text(json.dumps(value, indent=2, ensure_ascii=False) + '\n')

def cell(value):
    return str(value).replace('|', '\\|').replace('\n', ' ')

def link(path, label=None):
    return f'[{label or path}](<../{path}>)'

matrix = read(ROOT / 'project-memory/parity/DESKTOP-WEB-PARITY-MATRIX.json')
desktop = read(E / 'DESKTOP-RICHNESS.json')
web = read(E / 'WEB-RICHNESS.json')
dby = {x['form']: x for x in desktop['forms']}
wby = {x['file']: x for x in web['pages']}

def track(form, category):
    if form in {'TR_PR_SL_UAE', 'TR_SALE_RTN_UAE'}:
        return 'P00 / P13'
    if form == 'UT_TAG_PRINT':
        return 'P07 / P10 / P11'
    if form in {'OlockerService', 'PolicyModels'}:
        return 'P05 / P11'
    if category == 'report' or form in {'Ac_Final', 'Ac_Ledger', 'Ac_Rojmel'}:
        return 'P10'
    if category == 'master' or form.startswith('MS_'):
        return 'P03'
    if any(x in form for x in ['MFG', 'KR_', 'MLT', 'JDT']):
        return 'P08'
    if any(x in form for x in ['DHRN', 'MEMB']):
        return 'P09'
    if any(x in form for x in ['TAG', 'PHYSTK', 'ITM_LOT', 'ITM_OPBL']):
        return 'P07'
    if any(x in form for x in ['BUL_', 'PR_SL_HEDG', 'FINE_SL_PR']):
        return 'P06'
    if any(x in form for x in ['PURC', 'OTH_COMM']):
        return 'P04'
    if any(x in form for x in ['SALE', 'SL_', 'APR_', 'TOUR', 'VP', 'REP_']):
        return 'P05'
    if any(x in form for x in ['CASH', 'CONTRA', 'BILL_TO', 'CARD', 'UPI', 'LEDR_ADJ', 'EMP_JV', 'GOLD_BOOK', 'FN_INOUT', 'INOUT', 'AC_OPBL', 'LOCT_AMT']):
        return 'P06'
    if category == 'utility' or form.startswith('UT_'):
        return 'P11 / P12'
    return 'P00 / P01 / P02'

rows = []
requirements = []
control_requirements = []
event_requirements = []
input_types = {'TextBox','MaskedTextBox','ComboBox','CheckBox','RadioButton','DateTimePicker',
               'NumericUpDown','ListBox','CheckedListBox','RichTextBox','TextEdit','ComboBoxEdit',
               'DateEdit','CheckEdit','SpinEdit','LookUpEdit','MemoEdit','ToggleSwitch'}
control_decl = re.compile(r'^\s*(?:private|public|internal|protected)\s+([A-Za-z_][\w.]*)\s+(_?[A-Za-z_]\w*)\s*;\s*$')
md = ['# Form, engine and menu register', '',
      'Snapshot: 10 September 2026. All 204 desktop source units are accounted for here; 153 have a positive field surface in the heuristic extractor. The remaining units include launchers and shared logic. They still require behavioural disposition. A web route mapping below is inherited from the earlier matrix and rechecked only for file existence. It does not establish that a screen is equivalent or a workflow is working.', '',
      'Use this register with P00–P14 in the implementation plan. Each unit must acquire an approved behaviour contract, per-mode mapping, field and transition tests, desktop differential evidence, and business acceptance. Shared pages require separate tests for each desktop variant.', '',
      'The JSON companion records every named grid column and its source line candidates. All requirements start `unverified`; there is no automatic promotion from a matching label or a passing source scan.', '',
      'The [additional source register](09-additional-source-register.md) adds 916 modifier-bearing input declarations missed by this frozen scanner and eight supporting C# files outside the 204-unit directory. Use both registers; these counts are not exhaustive business requirements.', '',
      'Control declarations and event-handler locations are also indexed in `evidence/control-requirements.json` and `evidence/event-requirements.json`. Counts of validations/confirmations are scanner candidates: message-box style, caption, visibility and runtime branches still require interpretation.', '',
      '| Unit | Track | Inputs | Named / declared grid columns | Candidate web routes |',
      '| --- | --- | ---: | ---: | --- |']
details = []
for f in matrix['forms']:
    form = f['id']; d = dby[form]; source = f['desktop']['source']
    source_lines = (ROOT / source).read_text(errors='replace').splitlines()
    controls = []
    for n, line in enumerate(source_lines, 1):
        m = control_decl.match(line)
        if m and m[1].split('.')[-1] in input_types:
            c = {'id': f'F-{form}-CONTROL-{m[2].lstrip("_")}', 'form': form,
                 'control': m[2], 'type': m[1], 'source': source, 'sourceLine': n,
                 'status': 'unverified', 'visibilityRule': None, 'default': None,
                 'webPath': None, 'requestPath': None, 'persistedColumns': [], 'tests': []}
            controls.append(c); control_requirements.append(c)
    for handler in d['eventHandlerNames']:
        candidates = [n for n,line in enumerate(source_lines,1) if re.search(r'\bvoid\s+'+re.escape(handler)+r'\s*\(',line)]
        event_requirements.append({'id':f'F-{form}-EVENT-{handler}', 'form':form, 'handler':handler,
                                   'source':source,'sourceLineCandidates':candidates,'status':'unverified',
                                   'businessEffect':None,'webAction':None,'tests':[]})
    mapped = f['web'].get('frontendFiles', [])
    row = {
        'id': form, 'category': f['category'], 'track': track(form, f['category']),
        'status': 'unverified', 'desktopSource': source,
        'inputControls': d['inputControls'], 'namedGridColumns': d['gridNamedColsTotal'],
        'declaredGridColumns': d['gridDeclaredColsTotal'],
        'gridCellEvents': d['gridCellEventNames'], 'desktopGrids': d['grids'],
        'candidateRoutes': f['web'].get('frontendRoutes', []),
        'candidateFiles': [{'path': p, 'exists': (ROOT / p).exists()} for p in mapped],
        'candidateApiRoutes': f['web'].get('apiRoutes', []),
        'candidateModules': f['web'].get('apiModules', []),
        'retainedWriteTables': f['desktop'].get('writeTables', []),
        'retainedReportReferences': f['desktop'].get('reportsReferenced', []),
        'relatedTestsNotProof': f['web'].get('mappedDomainTests', []),
        'mappingClassification': f.get('mappingClassification'),
        'requiredEvidence': ['approved-contract', 'field-path-map', 'transition-matrix', 'role-setting-modes', 'api-db-browser-tests', 'desktop-differential', 'business-acceptance'],
    }
    rows.append(row)
    md.append(f"| `{form}` | {row['track']} | {d['inputControls']} | {d['gridNamedColsTotal']} / {d['gridDeclaredColsTotal']} | {cell(', '.join(row['candidateRoutes']) or 'No candidate surface')} |")
    details += [f'## {form}', '',
                f"Track **{row['track']}**. Category `{f['category']}`. {link(source, 'Desktop source')}. Status: **unverified**.", '',
                'Candidate web files: ' + ('; '.join(link(p) for p in mapped) or 'none'), '',
                'Candidate API modules: ' + ('; '.join(link(p) for p in row['candidateModules']) or 'none'), '',
                'Retained write-table candidates: ' + (', '.join(f'`{x}`' for x in row['retainedWriteTables']) or 'none recorded; verify shared engines and indirect writes') + '.', '',
                f"Source extraction: {d['inputControls']} inputs; {d['gridNamedColsTotal']} named columns; {d['distinctValidationMessages']} distinct validation-message candidates; {d['confirmationPrompts']} confirmation candidates; {d['gridCellEvents']} grid-cell handlers.", '']
    if controls:
        details += ['Declared input controls: '+', '.join(f"`{c['control']}` ({c['type']}, line {c['sourceLine']})" for c in controls)+'.', '']
    for g in d['grids']:
        details += [f"**{g['grid']}** — {g['namedCols']} named / {g['declaredCols']} declared columns: " + ', '.join(f'`{x}`' for x in g['columns']) + '.', '']
        for i, header in enumerate(g['columns'], 1):
            candidates = [n for n, line in enumerate(source_lines, 1) if re.search(r'\[0,\s*\d+\]', line) and f'"{header}"' in line]
            requirements.append({'id': f"F-{form}-{g['grid']}-H{i:03}", 'form': form, 'grid': g['grid'],
                                 'header': header, 'source': source, 'sourceLineCandidates': candidates,
                                 'status': 'unverified', 'fieldClass': 'to-classify',
                                 'visibilityRule': None, 'webPath': None, 'apiPath': None,
                                 'persistedColumns': [], 'calculationVector': None,
                                 'tests': [], 'desktopCapture': None})
    if d['gridCellEventNames']:
        details += ['Recalculation/selection handlers to trace: ' + ', '.join(f'`{x}`' for x in d['gridCellEventNames']) + '.', '']
    details += ['Closure checklist: classify all controls and conditional modes; follow lookup and cell-exit effects; compare validation and confirmation branches; implement every supported create/open/edit/delete/print/convert transition; test unchanged saves and reversals; compare all touched rows plus reports; obtain operator acceptance. For read-only or engine units, justify inapplicable lifecycle steps and test their callers.', '']

(OUT / '04-form-register.md').write_text('\n'.join(md + [''] + details) + '\n')
dump('form-register.json', rows)
dump('grid-requirements.json', requirements)
dump('control-requirements.json', control_requirements)
dump('event-requirements.json', event_requirements)

menus = read(ROOT / 'web/docs/COMPLETION-REGISTER.json')['items']
md = ['# Menu, report and data coverage registers', '',
      'These are separate denominators. Menu entries, source forms, report screens, report templates and database tables cannot be added into a single parity percentage. Historical statuses are copied for traceability and require revalidation.', '',
      '## All 198 retained menu entries', '',
      'Several absence labels are already stale (for example bill profit and stock-level reports have newer implementations). Even a corrected mapping remains unverified until its mode and workflow pass.', '',
      '| Menu | Retained state | Desktop candidate | Web candidate |', '| --- | --- | --- | --- |']
for x in menus:
    md.append('| ' + ' | '.join(cell(v) for v in [x['tab']+'/'+x['menu'], x['state'], ', '.join(x['desktopForms']), str(x.get('webSurface') or 'unmapped')]) + ' |')
md += ['', '## All 275 retained report references', '',
       '255 supplied Crystal names plus 20 absent referenced names. Validate the absent names against the original installation; they may be dynamic names, edition variants, missing files, or obsolete references. An absent reference is unresolved scope, not automatically a supported screen. Binary/spec presence below is checked now; semantic binding and desktop comparison remain unverified.', '',
       '| Report | Kind | Binary present | Web spec present | Retained binder candidate |', '| --- | --- | --- | --- | --- |']
reports=[]
for x in matrix['reports']:
    d=x['desktop'];w=x['web'];b=d.get('rptBinary');s=w.get('layoutSpec')
    r={'id':x['id'],'kind':x['category'],'binary':b,'binaryPresent':bool(b and (ROOT/b).exists()),'webSpec':s,'webSpecPresent':bool(s and (ROOT/s).exists()),'retainedBinder':w.get('currentBinderFamily'),'status':'unverified','requiredEvidence':['parameter-map','explicit-dataset-binding','filters-and-scope','desktop-data-diff','visual-and-physical-output','print-rights']}
    reports.append(r)
    md.append('| '+' | '.join(cell(v) for v in [r['id'],r['kind'],r['binaryPresent'],r['webSpecPresent'],r['retainedBinder']])+' |')
md += ['', '## All retained desktop table units', '',
       'This matrix has 146 table units; other historical schema reports count 145 initialised tables or larger restored schemas. P00/P12 must reconcile these sets against the actual source database, including shared/auxiliary databases, images, staging and audit tables. Every retained table below needs an ownership key, migration rule, comparison rule and disposition.', '',
       '| Table | Category | Required disposition |', '| --- | --- | --- |']
tables=[]
for x in matrix['tables']:
    tables.append({'id':x['id'],'category':x.get('category'),'status':'unverified','ownershipKey':None,'migrationDisposition':None,'comparisonEvidence':None})
    md.append(f"| `{cell(x['id'])}` | {cell(x.get('category'))} | Map ownership; migrate or rebuild with proof; reconcile rows/types/keys |")
(OUT/'05-menu-report-data-register.md').write_text('\n'.join(md)+'\n')
dump('report-register.json',reports);dump('table-register.json',tables)

# Settings: preserve the original scanner output but add alias leads. This is a candidate
# index, not a claim of complete data flow or runtime effect.
parity=read(E/'SETTINGS-PARITY.json'); effects=read(E/'SETTINGS-EFFECT.json')
loader=ROOT/'web/apps/api/src/modules/shared/settingsBehavior.ts'
loader_src=loader.read_text()
start=loader_src.index('export function resolveSettingsBehavior(')
end=loader_src.index('const BLANK_FLAG_DEFAULT',start)
block=loader_src[start:end]
prop_chunks=list(re.finditer(r'^    ([a-zA-Z]\w*):',block,re.M))
aliases={}
for i,m in enumerate(prop_chunks):
    chunk=block[m.end():prop_chunks[i+1].start() if i+1<len(prop_chunks) else len(block)]
    for key in re.findall(r'values\.([A-Z][A-Z0-9_]+)',chunk):aliases.setdefault(key,[]).append(m[1])
corpus=[]
for base in [ROOT/'web/apps/api/src/modules',ROOT/'web/apps/web/app',ROOT/'web/apps/web/components',ROOT/'web/apps/web/lib']:
    for p in base.rglob('*'):
        if p.suffix not in {'.ts','.tsx'} or p==loader:continue
        src=p.read_text();src=re.sub(r'/\*.*?\*/','',src,flags=re.S);src=re.sub(r'//[^\n]*','',src)
        corpus.append((str(p.relative_to(ROOT)),src))
setting_rows=[]
for x in effects['rows']:
    key=x['key']; consumers=[]
    for alias in aliases.get(key,[]):
        for path,src in corpus:
            if re.search(r'\.'+re.escape(alias)+r'\b',src):consumers.append(path)
    setting_rows.append({**x,'typedAliases':aliases.get(key,[]),'aliasConsumerCandidates':sorted(set(consumers)),'certification':'unverified; requires mode-specific effect tests'})
dump('settings-review.json',setting_rows)
md=['# Settings and API field review register','','The original raw-key scan is not a settings-effect certificate. It excludes the typed loader and misses camelCase consumers; it can also count comments, collisions or unrelated uses. The alias column below is a code-search lead, not a complete data-flow proof. Every key requires an observed outcome for each allowed value, blank/missing/default handling and invalid-value rejection. A setting need not be operator input merely because it is stored.','','| Key | Raw scanner class | Typed alias | Consumer leads outside loader | Desktop reader count |','| --- | --- | --- | --- | ---: |']
for x in setting_rows:
    md.append('| '+' | '.join(cell(v) for v in [x['key'],x['webStatus'],', '.join(x['typedAliases']) or 'none found','; '.join(x['aliasConsumerCandidates']) or 'none found',len(x.get('desktopReaderForms',[]))])+' |')
triage=read(E/'UNREACHABLE-TRIAGE.json')
md+=['','## API fields with no frontend name match','','Fresh scan: 96 fields; classifier proposes 14 operator fields, 53 server-derived and 29 internal. These categories need validation against each actual request adapter. A same-name occurrence on an unrelated page does not prove reachability. Do not expose tenant IDs, ledger-account slots or audit identities to clear a metric.','','| Interface | Module | Operator candidates |','| --- | --- | --- |']
for x in triage['operatorBacklog']:md.append(f"| `{x['interface']}` | {x['module']} | {', '.join(x['fields'])} |")
md+=['','Every exposed field must be traced through UI state → request → route adapter → domain input → calculation/writer → reader → hydration → unchanged save → print/export. Fields that only exist in JSON interfaces remain incomplete. See `evidence/GAP-MANIFEST.json` for every scanned interface and `evidence/UNREACHABLE-TRIAGE.json` for the complete candidate classification.','']
(OUT/'06-settings-api-register.md').write_text('\n'.join(md)+'\n')

# Exact registry count: handle quoted and unquoted TypeScript property names.
src=(ROOT/'web/apps/api/src/modules/reports/reportAuthorization.ts').read_text()
block=src.split('Object.freeze({',1)[1].split('} as const',1)[0]
slugs=re.findall(r"^\s*(?:'([^']+)'|(\w+)):\s*'([^']+)'",block,re.M)
dump('report-slugs.json',[{'slug':a or b,'form':c} for a,b,c in slugs])
summary={'sourceUnits':len(rows),'positiveSurfaceUnits':sum(x['inputControls']+x['gridNamedColsTotal']>0 for x in desktop['forms']),
         'namedGridRequirements':len(requirements),'inputControlRequirements':len(control_requirements),
         'eventHandlerRequirements':len(event_requirements),'menuUnits':len(menus),'reportReferences':len(reports),'tableUnits':len(tables),
         'actualReportRegistryEntries':len(slugs),'settingsRows':len(setting_rows),
         'aliasConsumerCandidatesAmongRawInert':sum(bool(x['aliasConsumerCandidates']) and x['webStatus']=='inert' for x in setting_rows)}
dump('register-summary.json',summary)

# A machine-readable scheduling view of the authored work packages. Phase dependencies
# are explicit; source prose remains the complete implementation/acceptance contract.
plan=(OUT/'02-implementation-plan.md').read_text()
phase_deps={
 'P00':[], 'P01':['P00'], 'P02':['P00','P01'], 'P03':['P01','P02'],
 'P04':['P03','P07'], 'P05':['P03','P04','P07'], 'P06':['P01','P03'],
 'P07':['P01','P03'], 'P08':['P03','P07'], 'P09':['P03','P06'],
 'P10':['P00'], 'P11':['P01','P02'], 'P12':['P00'], 'P13':['P00'],
 'P14':[f'P{i:02}' for i in range(14)]}
owners={'P00':'Technical lead / desktop specialist / QA','P01':'Backend domain lead',
 'P02':'Frontend lead / QA','P03':'Master-data full-stack owner','P04':'Purchasing domain owner',
 'P05':'Sales domain owner','P06':'Accounting / bullion owner','P07':'Inventory owner',
 'P08':'Manufacturing owner','P09':'Lending / scheme owner','P10':'Reporting owner / accountant',
 'P11':'Platform / full-stack owner','P12':'Database / platform owner',
 'P13':'Product owner / desktop specialist','P14':'QA / business / operations leads'}
scenario_groups={'P00':['SET','OPS'],'P01':['FIN','STK','OPS'],'P02':['SET','SAL','OPS'],
 'P03':['SET'],'P04':['PUR'],'P05':['SAL','FLOW'],'P06':['FIN'],'P07':['STK'],
 'P08':['MFG'],'P09':['SCH'],'P10':['RPT'],'P11':['OPS'],'P12':['OPS'],'P13':['SET','RPT'],'P14':['ALL']}
matches=list(re.finditer(r'^### (P\d{2}-\d{2}) — (.+)$',plan,re.M))
work=[]
for i,m in enumerate(matches):
    body=plan[m.end():matches[i+1].start() if i+1<len(matches) else len(plan)].strip()
    # Exclude the next phase heading and final execution section from the work-item body.
    body=re.split(r'^## ',body,flags=re.M)[0].strip()
    phase=m[1].split('-')[0]
    accept=re.findall(r'\*\*Accept[\s\S]+?\*\*',body)
    work.append({'id':m[1],'phase':phase,'title':m[2],'status':'planned',
                 'baseline':'Current code may partly implement this package; revalidate before changing it.',
                 'leadRole':owners[phase],'phaseStartDependencies':phase_deps[phase],
                 'dependencyNote':'Discovery in P10/P12 starts early; their certification also requires related family completion. Within a phase, follow the authored task prerequisites.',
                 'implementationAndChecks':body,'acceptance':accept,
                 'testMatrix':['FORM-01 through FORM-18 where applicable'],
                 'requiredCompletionObligations':['all-discovered-descendant-requirements', 'applicable-cross-module-evidence', 'exact-required-case-set', 'actual-candidate-provenance'],
                 'scenarioGroups':scenario_groups[phase], 'evidence':[],
                 'businessAcceptance':None,'desktopComparison':None})
(OUT/'07-work-items.json').write_text(json.dumps({'kind':'datacare.parity-plan-work-items/1.0',
 'date':'2026-09-10','note':'A plan, not a completion certificate. Estimates and named assignees follow P00 calibration.',
 'completionContract':{'scope':'Full reachable primary desktop product; subset certification cannot close this delivery', 'fixedTaskCountIsCompletionCeiling':False, 'requiredRegisters':['04-form-register.md','05-menu-report-data-register.md','06-settings-api-register.md','09-additional-source-register.md'], 'releaseSpecification':'03-verification-and-release.md#exact-set-completeness-and-certification-contract', 'crossModuleCertification':'P10/P11/P12 start dependencies permit discovery only; acceptance requires all related family contracts and release evidence; P14 requires every required descendant closed', 'runtimeEnforced':False},
 'phaseDependencies':phase_deps,'workItems':work},indent=2,ensure_ascii=False)+'\n')
print('work packages',len(work))
print(json.dumps(summary,indent=2))
