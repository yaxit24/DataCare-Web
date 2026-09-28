#!/usr/bin/env python3
"""
build_coverage_matrix.py — complete desktop→web form coverage matrix.
For every desktop form (module-map.json + behavior index) determine the web status by matching against
the actual web surface (page.tsx slugs + nav.ts hrefs + MASTERS route keys), with a curated alias map
for the confident correspondences and a normalized-token fuzzy fallback. Output:
  catalogs/coverage-matrix.json  + a printed human summary.
"""
import json, re, glob, os

ROOT = '/Users/yakshitsavaliya/Desktop/imodule-extracted'
WEB = f'{ROOT}/web/apps/web'
API = f'{ROOT}/web/apps/api'

mm = json.load(open(f'{ROOT}/project-memory/catalogs/module-map.json'))['forms']
beh = {r['form']: r for r in json.load(open(f'{ROOT}/project-memory/catalogs/form-behavior/_index.json'))['index']}

# ---- web surface ----
pages = set()
for p in glob.glob(f'{WEB}/app/**/page.tsx', recursive=True):
    slug = p.split('/app/')[1].rsplit('/page.tsx', 1)[0]
    slug = re.sub(r'\(app\)/', '', slug).strip('/')
    pages.add(slug)
nav_hrefs = set(re.findall(r"href: '([^']+)'", open(f'{WEB}/lib/nav.ts').read()))
master_keys = set(re.findall(r"^\s+'?([a-z-]+)'?: [A-Z_]+_CONFIG", open(f'{API}/src/modules/masters/configs.ts').read(), re.M))
routes = set(re.findall(r"app\.(?:get|post|put|delete)\('([^']+)'", '\n'.join(open(f).read() for f in glob.glob(f'{API}/src/routes/*.ts'))))

def norm(s):
    return re.sub(r'[^a-z0-9]', '', s.lower())

web_slugs = {norm(s.split('/')[-1]): s for s in pages}
web_slugs.update({norm(h.split('/')[-1]): h for h in nav_hrefs})
for mk in master_keys:
    web_slugs.setdefault(norm(mk), f'/masters/{mk}')

# curated form -> web slug (the confident correspondences)
CUR = {
 'TR_SALE': 'sales', 'TR_BUL_SALE': 'sales', 'TR_WH_SALE': 'wholesale-sale', 'TR_TOUR_SALE': 'tour',
 'TR_SALE_HM': 'hallmark-sale', 'TR_SALE_RTN': 'sale-return', 'TR_TOUR_RTN': 'tour-return',
 'TR_PURC': 'purchase', 'TR_PURC_HM': 'purchase-hm', 'TR_SALE_ORD': 'sales-order', 'TR_ORD_CANCEL': 'order-cancel',
 'TR_CASH': 'receipt', 'TR_CARD_REC': 'batch-receipt', 'TR_CONTRA': 'contra', 'TR_JV': 'journal',
 'TR_DHRN_ISU': 'dhrn-issue', 'TR_DHRN_REC': 'dhrn-receipt', 'TR_DHRN_INTREC': 'dhrn-interest',
 'TR_TAG_OPBL': 'tag-opening', 'TR_TAG_PRINT': 'tag-print', 'TR_TAG_SPLIT': 'tag-split',
 'TR_TAG_TRANS': 'tag-transfer', 'TR_TAG_CANCEL': 'tag-cancel', 'TR_TAG_WT_DIFF': 'tag-weight-diff',
 'TR_KR_ISU': 'karigar-issue', 'TR_KR_REC': 'karigar-receive', 'TR_KRECV': 'karigar-receive', 'TR_KISU': 'karigar-issue',
 'TR_MFG_ISU': 'mfg-issue', 'TR_MFG_REC': 'mfg-receive', 'TR_MFG_ORD': 'mfg-order-issue',
 'TR_JOB_ISU': 'jobwork-issue', 'TR_JOB_REC': 'jobwork-receive', 'TR_MELT': 'melting',
 'TR_RATE_CUT': 'rate-cut', 'TR_FINE_SL': 'fine-sale', 'TR_FINE_INOUT': 'fine-inout', 'TR_FN_INOUT': 'fine-inout',
 'TR_AC_OPBL': 'ac-opbl', 'TR_ITM_OPBL': 'item-opening', 'TR_PHY_STK': 'physical-stock', 'TR_STK_ADJ': 'stock-adjust',
 'TR_CNT_TRANS': 'counter-transfer', 'TR_BILL_TO': 'bill-to-bill', 'TR_BUL_BOOKING': 'bullion', 'TR_BUL_SALE': 'sales',
 'TR_LBR': 'labour-sale', 'TR_LBR_SALE': 'labour-sale', 'TR_MEMB': 'membership', 'TR_ESTIMATE': 'estimate',
 'TR_APR_ISU': 'estimate', 'TR_EMP_JV': 'employee-jv', 'TR_FINE_JV': 'fine-jv', 'TR_LEDR_ADJ': 'ledger-adjust',
 'TR_SALE_RTN_UAE': 'sale-return', 'TR_PR_SL_UAE': 'purchase', 'TR_UPI_REC': 'receipt', 'TR_ITEM_LOT': 'item-lot',
 'MS_ACCT': 'party', 'MS_ITEM': 'items', 'MS_GROUP': 'groups', 'MS_PRODUCT': 'products', 'MS_COMPANY': 'companies',
 'MS_BOOK': 'books', 'MS_TAX': 'taxes', 'MS_EMP': 'employees', 'MS_RATE': 'rates', 'MS_ADD_MAST': 'addresses',
 'MS_TABLE': 'counters', 'MS_TOUCH': 'touch', 'MS_AC_GROUP': 'ac-groups', 'MS_YEAR': 'year-create',
 'MS_AUTO_ITEM': 'auto-item', 'MS_LOCATION': 'locations', 'MS_DESIGN': 'designs', 'MS_MODEL': 'models',
 'MS_DM': 'diamonds', 'MS_POINT': 'points', 'MS_LBR_TYPE': 'labour', 'MS_CONV': 'conversions', 'MS_MFG_MAST': 'mfg',
 'MS_MEMB': 'membership', 'MS_SCHEME': 'schemes', 'MS_USER': 'users', 'MS_STATE': 'states', 'MS_COL': 'styles',
 'MS_TRADE': 'trade', 'MS_PRINT': 'print-formats', 'UT_SETTING_MAIN': 'settings', 'UT_BACKUP': 'backup',
 'UT_BKP': 'backup', 'UT_E_INVOICE': 'e-invoice', 'UT_VCH_RENUM': 'voucher-renumber', 'UT_YEAR_END': 'year-end',
 'MS_DAILY_RATE': 'daily-rate', 'TR_DAILY_RATE': 'daily-rate', 'TR_SCHM': 'scheme', 'TR_SCHM_INST': 'scheme',
 # false-negative reconciliations (web page exists under a differently-tokenised name)
 'TR_OTH_PURC': 'other-purchase', 'TR_ITM_LOT': 'item-lot', 'TR_PHYSTK': 'physical-stock', 'TR_PHY_STK': 'physical-stock',
 'TR_SALE_LBR': 'labour-sale', 'TR_MEMB_ADJ': 'membership', 'TR_MEMB_ENT': 'membership', 'TR_SL_ORD_ADJ': 'sales-order',
 'TR_WH_SALE_RTN': 'wholesale-sale', 'MS_LOCT': 'locations', 'MS_OPNCOMP': 'select', 'UT_VCH_RE_NUMBR': 'voucher-renumber',
 'UT_PWD_UPDATE': 'users', 'TR_BANK_REC': 'receipt', 'TR_BANK_PAY': 'payment', 'TR_PAY': 'payment', 'TR_MELT_PRO': 'melting',
 'TR_MLT_PRO': 'melting', 'TR_BATCH_REC': 'batch-receipt', 'MS_SchemeMast': 'schemes', 'TR_REP_ISU': 'jobwork-issue',
}

def classify(form):
    rich = beh.get(form, {})
    r = {'grid': rich.get('gridCols', 0), 'sql': rich.get('sql', 0), 'calc': rich.get('calc', 0), 'valid': rich.get('validations', 0)}
    # curated
    slug = CUR.get(form)
    if slug and (norm(slug) in web_slugs or any(norm(slug) == norm(p.split('/')[-1]) for p in pages)):
        return 'PAGE', slug, r
    # fuzzy: strip prefix
    base = re.sub(r'^(TR|MS|RP|UT)_', '', form)
    nb = norm(base)
    if nb in web_slugs:
        return 'PAGE', web_slugs[nb], r
    for ws, path in web_slugs.items():
        if nb and (nb in ws or ws in nb) and len(nb) > 3:
            return 'PAGE', path, r
    return 'MISSING', None, r

UI = {'transaction', 'master', 'report', 'utility'}
rows = []
for form, meta in mm.items():
    mod = meta['module']
    if mod not in UI:
        continue
    status, slug, rich = classify(form)
    rows.append({'form': form, 'module': mod, 'status': status, 'web': slug,
                 'posting': bool(meta.get('tablesInserted') or meta.get('tablesUpdated')),
                 'tables': (meta.get('tablesInserted', []) + meta.get('tablesUpdated', []))[:6], 'rich': rich})

# reports: web has a spec-driven generic renderer for all 254 → mark RP as SPEC unless a dedicated page
for r in rows:
    if r['module'] == 'report' and r['status'] == 'MISSING':
        r['status'] = 'SPEC'  # rendered by the report-layout engine from extracted specs
        r['web'] = '/reports/report-layouts'

import collections
by = collections.Counter((r['module'], r['status']) for r in rows)
json.dump({'total': len(rows), 'byModuleStatus': {f'{m}/{s}': c for (m, s), c in by.items()}, 'rows': rows},
          open(f'{ROOT}/project-memory/catalogs/coverage-matrix.json', 'w'), indent=1)

print(f'UI forms analysed: {len(rows)}  (web pages={len(pages)}, routes={len(routes)}, master keys={len(master_keys)})')
for mod in ('transaction', 'master', 'report', 'utility'):
    ms = [r for r in rows if r['module'] == mod]
    pg = sum(1 for r in ms if r['status'] == 'PAGE'); sp = sum(1 for r in ms if r['status'] == 'SPEC'); mi = sum(1 for r in ms if r['status'] == 'MISSING')
    print(f'  {mod:12} total={len(ms):3}  PAGE={pg:3}  SPEC={sp:3}  MISSING={mi:3}')
miss = [r['form'] for r in rows if r['status'] == 'MISSING']
print(f'\nMISSING web surface ({len(miss)}): {", ".join(sorted(miss))}')
