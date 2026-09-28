#!/usr/bin/env python3
"""rpt_xml_to_spec.py — turn the RptToXml geometry (extraction_output/rpt_xml/*.xml, produced by the
Windows GitHub Actions run) into per-report LAYOUT SPECS the web report engine can render pixel-exact:
Areas → Sections (kind/height) → positioned objects (Field/Text with Left/Top/Width/Height in twips,
DataSource field/formula) + the report's formula definitions.

Output: project-memory/catalogs/report-layouts/<REPORT>.spec.json  +  report-layouts-index.json
macOS-only (the XML is already extracted); completes the reports pipeline (names→fields→geometry).
"""
import glob, json, os
import xml.etree.ElementTree as ET

ROOT = os.path.abspath(os.path.join(os.path.dirname(__file__), '..', '..'))
XMLDIR = os.path.join(ROOT, 'extraction_output', 'rpt_xml')
OUTDIR = os.path.join(ROOT, 'project-memory', 'catalogs', 'report-layouts')


def txt(el):
    return ' '.join(''.join(el.itertext()).split())[:200]


def parse(path):
    source_error = None
    try:
        root = ET.parse(path).getroot()
    except Exception as e:
        source_error = str(e)
        try:
            # RptToXml can terminate while serialising a malformed Crystal text object.
            # Preserve the complete XML prefix instead of losing every preceding section/object,
            # but mark the resulting spec as partial so it can never be certified as exact.
            from lxml import etree

            parser = etree.XMLParser(recover=True, huge_tree=True)
            root = etree.parse(path, parser).getroot()
            if root is None:
                raise ValueError("recovery produced no document root")
        except Exception as recovery_error:
            return {
                'report': os.path.basename(path)[:-4],
                'status': 'failed',
                'error': source_error,
                'recoveryError': str(recovery_error),
            }
    # formulas
    formulas = []
    for fd in root.iter('FormulaFieldDefinition'):
        formulas.append({'name': fd.get('Name'), 'ref': fd.get('FormulaName'), 'type': fd.get('ValueType'), 'text': txt(fd)})
    # areas → sections → objects
    areas = []
    rd = root.find('.//ReportDefinition')
    for area in (rd.iter('Area') if rd is not None else []):
        secs = []
        for sec in area.findall('.//Section'):
            objs = []
            for ro in sec.findall('.//ReportObjects/*'):
                o = {'type': ro.tag, 'name': ro.get('Name'),
                     'left': int(ro.get('Left', 0) or 0), 'top': int(ro.get('Top', 0) or 0),
                     'width': int(ro.get('Width', 0) or 0), 'height': int(ro.get('Height', 0) or 0)}
                if ro.get('DataSource'):
                    o['dataSource'] = ro.get('DataSource')
                if ro.tag == 'TextObject':
                    o['text'] = txt(ro)
                objs.append(o)
            objs.sort(key=lambda o: (o['top'], o['left']))
            secs.append({'name': sec.get('Name'), 'kind': sec.get('Kind'), 'height': int(sec.get('Height', 0) or 0), 'objects': objs})
        areas.append({'kind': area.get('Kind'), 'name': area.get('Name'), 'sections': secs})
    nobj = sum(len(s['objects']) for a in areas for s in a['sections'])
    result = {
        'report': os.path.basename(path)[:-4],
        'status': 'partial' if source_error else 'complete',
        'areas': areas,
        'formulas': formulas,
        'sectionCount': sum(len(a['sections']) for a in areas),
        'objectCount': nobj,
        'formulaCount': len(formulas),
    }
    if source_error:
        result['sourceError'] = source_error
    return result


def main():
    os.makedirs(OUTDIR, exist_ok=True)
    idx = []
    for f in sorted(glob.glob(os.path.join(XMLDIR, '*.xml'))):
        s = parse(f)
        json.dump(s, open(os.path.join(OUTDIR, s['report'] + '.spec.json'), 'w'), indent=1)
        if 'error' not in s:
            idx.append({'report': s['report'], 'areas': len(s['areas']), 'sections': s['sectionCount'], 'objects': s['objectCount'], 'formulas': s['formulaCount']})
    idx.sort(key=lambda x: -x['objects'])
    json.dump(idx, open(os.path.join(OUTDIR, 'report-layouts-index.json'), 'w'), indent=1)
    print(f'reports={len(idx)}  totalSections={sum(i["sections"] for i in idx)}  totalObjects={sum(i["objects"] for i in idx)}  totalFormulas={sum(i["formulas"] for i in idx)}')
    print(f'output_dir={OUTDIR}')
    for i in idx[:6]:
        print(f"  {i['report']}: {i['areas']} areas, {i['sections']} sections, {i['objects']} objects, {i['formulas']} formulas")


if __name__ == '__main__':
    main()
