#!/usr/bin/env python3
"""Recover the five explicit order documents, including their linked OrdRec subreport.

The older catalog extraction selected the first descendant ReportDefinition, which belongs
to OrdRec. Direct child paths are essential: main and subreport sections share names.
This bounded extractor deliberately does not regenerate the rest of the report universe.
"""
import argparse
import hashlib
import json
from pathlib import Path
import xml.etree.ElementTree as ET

WEB = Path(__file__).resolve().parents[1]
EXTRACTED = WEB.parent / 'extraction_output' / 'rpt_xml'
REPORTS = ('OrderVch', 'OrderBill', 'TourOrdVch', 'OrdVchImg', 'TourOrdImg')
IMAGE_REPORTS = ('OrdVchImg', 'TourOrdImg')
parser = argparse.ArgumentParser(description=__doc__)
parser.add_argument('--check', action='store_true', help='Verify committed outputs without writing files')
CHECK = parser.parse_args().check


def write_or_check(path, content):
    if CHECK:
        if path.read_text() != content:
            raise SystemExit(f'Extraction output is stale: {path}')
    else:
        path.write_text(content)


def flag(element, key):
    return element is not None and element.get(key) == 'True'


def parse_report(report, name):
    areas = []
    for area in report.findall('./ReportDefinition/Areas/Area'):
        sections = []
        for section in area.findall('./Sections/Section'):
            objects = []
            for obj in section.findall('./ReportObjects/*'):
                fmt = obj.find('./ObjectFormat')
                font = obj.find('./Font')
                value = {
                    'type': obj.tag, 'name': obj.get('Name'),
                    **{key.lower(): int(obj.get(key, '0')) for key in ('Left', 'Top', 'Width', 'Height')},
                    'suppressed': flag(fmt, 'EnableSuppress'),
                    'canGrow': flag(fmt, 'EnableCanGrow'),
                }
                for source, target in [('DataSource', 'dataSource'), ('SubreportName', 'subreportName')]:
                    if obj.get(source) is not None:
                        value[target] = obj.get(source)
                if obj.find('./Text') is not None:
                    value['text'] = obj.findtext('./Text', '')
                if fmt is not None:
                    value['alignment'] = fmt.get('HorizontalAlignment', 'DefaultAlign')
                if font is not None:
                    value['font'] = {'name': font.get('Name'), 'points': float(font.get('SizeinPoints', '9')),
                                     'bold': flag(font, 'Bold'), 'italic': flag(font, 'Italic')}
                conditional = obj.find('./ObjectFormatConditionFormulas')
                if conditional is not None and conditional.get('EnableSuppress'):
                    value['suppressWhen'] = conditional.get('EnableSuppress').strip()
                objects.append(value)
            fmt = section.find('./SectionFormat')
            value = {'name': section.get('Name'), 'kind': section.get('Kind'),
                     'height': int(section.get('Height', '0')), 'objects': objects,
                     'suppressed': flag(fmt, 'EnableSuppress') or flag(area.find('./AreaFormat'), 'EnableSuppress')}
            conditional = section.find('./SectionFormat/SectionAreaConditionFormulas')
            if conditional is not None and conditional.get('EnableSuppress'):
                value['suppressWhen'] = conditional.get('EnableSuppress').strip()
            sections.append(value)
        areas.append({'kind': area.get('Kind'), 'name': area.get('Name'), 'sections': sections})
    formulas = [{'name': f.get('Name'), 'ref': f.get('FormulaName'),
                 'type': f.get('ValueType'), 'text': (f.text or '').strip()}
                for f in report.findall('./DataDefinition/FormulaFieldDefinitions/*')]
    sections = [s for a in areas for s in a['sections']]
    return {
        'report': name, 'areas': areas, 'formulas': formulas,
        'sectionCount': len(sections), 'objectCount': sum(len(s['objects']) for s in sections),
        'formulaCount': len(formulas),
        'groups': [g.get('ConditionField') for g in report.findall('./DataDefinition/Groups/Group')],
        'databaseFields': {f.get('FormulaForm')[1:-1]: f.get('Type')
                           for t in report.findall('./Database/Tables/Table') for f in t.findall('./Fields/Field')},
        'runningTotals': [dict(f.attrib) for f in report.findall('./DataDefinition/RunningTotalFieldDefinitions/*')],
        'subreportLinks': [dict(link.attrib) for link in report.findall('./SubReportLinks/SubReportLink')],
        'subreports': {r.get('Name'): parse_report(r, r.get('Name')) for r in report.findall('./SubReports/Report')},
    }


recovered = {}
for name in REPORTS:
    path = EXTRACTED / (name + '.xml')
    root = ET.parse(path).getroot()
    result = parse_report(root, name)
    if name in IMAGE_REPORTS:
        # RptToXml omits BlobFieldObject.DataSource. Both source reports have exactly one
        # used blob database field and one visible blob object. Record this explicit mapping;
        # never infer arbitrary future report bindings from the first blob field.
        blobs = [f for t in root.findall('./Database/Tables/Table') for f in t.findall('./Fields/Field')
                 if f.get('Type') == 'crFieldValueTypeBlobField' and f.get('UseCount') == '1']
        assert len(blobs) == 1 and blobs[0].get('FormulaForm') == '{IMAGE_DATA.TAG_IMAGE}'
        section = next(s for a in result['areas'] for s in a['sections'] if s['name'] == 'Section17')
        objects = [o for a in result['areas'] for s in a['sections'] for o in s['objects']
                   if o['type'] == 'BlobFieldObject']
        assert len(objects) == 1 and objects[0]['name'] == 'Field22' and objects[0] in section['objects']
        objects[0]['dataSource'] = '{IMAGE_DATA.TAG_IMAGE}'
        result['imageBindingEvidence'] = {
            'section': 'Section17', 'object': 'Field22', 'field': 'IMAGE_DATA.TAG_IMAGE',
            'proof': 'only blob field with UseCount=1 and only BlobFieldObject in main XML',
        }
    result['source'] = {'kind': 'order-xml-v1', 'xml': str(path.relative_to(WEB.parent)),
                        'sha256': hashlib.sha256(path.read_bytes()).hexdigest()}
    result['printOptions'] = dict(root.find('./PrintOptions').attrib)
    margins = root.find('./PrintOptions/PageMargins')
    if margins is not None:
        result['printOptions'].update({f'margin{edge.title()}': margins.get(f'{edge}Margin', '0')
                                       for edge in ('top', 'right', 'bottom', 'left')})
    target = WEB / 'apps' / 'api' / 'report-specs' / (name + '.spec.json')
    write_or_check(target, json.dumps(result, indent=2) + '\n')
    recovered[name] = result
    print(f'{name}: {result["sectionCount"]} main sections, {result["objectCount"]} main objects; '
          f'{len(result["subreports"])} independent subreport(s)')

# Keep listReportSpecs metadata consistent while preserving every unrelated catalog entry.
index_path = WEB / 'apps' / 'api' / 'report-specs' / 'report-layouts-index.json'
index = json.loads(index_path.read_text())
for entry in index:
    if entry['report'] in recovered:
        spec = recovered[entry['report']]
        entry.update(areas=len(spec['areas']), sections=spec['sectionCount'],
                     objects=spec['objectCount'], formulas=spec['formulaCount'])
write_or_check(index_path, json.dumps(index, indent=2) + '\n')
