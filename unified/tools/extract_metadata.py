#!/usr/bin/env python3
"""
Deep .NET PE metadata extractor for DataCareNext.exe and NextDm.exe
Extracts: CLR header info, all strings, SQL queries, form/class/method names,
database schema references, API endpoints, configuration, embedded resources info.
"""
import struct
import sys
import os
import re
import json
from collections import defaultdict

def read_pe_header(filepath):
    """Read PE header and extract .NET metadata root info."""
    info = {}
    with open(filepath, 'rb') as f:
        # MZ header
        mz = f.read(2)
        if mz != b'MZ':
            return {"error": "Not a PE file"}
        
        # PE offset
        f.seek(0x3C)
        pe_offset = struct.unpack('<I', f.read(4))[0]
        
        # PE signature
        f.seek(pe_offset)
        pe_sig = f.read(4)
        if pe_sig != b'PE\x00\x00':
            return {"error": "Invalid PE signature"}
        
        # COFF header
        machine = struct.unpack('<H', f.read(2))[0]
        num_sections = struct.unpack('<H', f.read(2))[0]
        timestamp = struct.unpack('<I', f.read(4))[0]
        f.read(8)  # PointerToSymbolTable, NumberOfSymbols
        size_optional = struct.unpack('<H', f.read(2))[0]
        characteristics = struct.unpack('<H', f.read(2))[0]
        
        info['machine'] = hex(machine)
        info['num_sections'] = num_sections
        info['timestamp'] = timestamp
        info['characteristics'] = hex(characteristics)
        
        # Optional header
        optional_start = f.tell()
        magic = struct.unpack('<H', f.read(2))[0]
        info['pe_type'] = 'PE32' if magic == 0x10b else 'PE32+' if magic == 0x20b else f'Unknown({hex(magic)})'
        
        if magic == 0x10b:  # PE32
            f.seek(optional_start + 208)  # CLR runtime header directory
            clr_rva = struct.unpack('<I', f.read(4))[0]
            clr_size = struct.unpack('<I', f.read(4))[0]
            info['clr_header_rva'] = hex(clr_rva)
            info['clr_header_size'] = clr_size
            info['is_dotnet'] = clr_rva != 0
        
        # Section headers
        f.seek(optional_start + size_optional)
        sections = []
        for _ in range(num_sections):
            name = f.read(8).rstrip(b'\x00').decode('ascii', errors='replace')
            virtual_size = struct.unpack('<I', f.read(4))[0]
            virtual_addr = struct.unpack('<I', f.read(4))[0]
            raw_size = struct.unpack('<I', f.read(4))[0]
            raw_offset = struct.unpack('<I', f.read(4))[0]
            f.read(12)  # relocations, linenumbers, reloc count, linenum count
            characteristics = struct.unpack('<I', f.read(4))[0]
            sections.append({
                'name': name,
                'virtual_size': virtual_size,
                'virtual_addr': hex(virtual_addr),
                'raw_size': raw_size,
                'raw_offset': hex(raw_offset),
            })
        info['sections'] = sections
        
        # Read .text section for .NET metadata
        text_section = None
        for s in sections:
            if s['name'] == '.text':
                text_section = s
                break
        
        if text_section and info.get('is_dotnet'):
            # Try to find .NET version string
            f.seek(int(text_section['raw_offset'], 16))
            text_data = f.read(text_section['raw_size'])
            
            # Search for .NET version strings
            version_pattern = rb'v\d+\.\d+\.\d+'
            versions = re.findall(version_pattern, text_data)
            if versions:
                info['dotnet_versions'] = list(set(v.decode() for v in versions))
            
            # Search for assembly info
            assembly_pattern = rb'DataCareNext, Version=[\d.]+'
            assemblies = re.findall(assembly_pattern, text_data)
            if assemblies:
                info['assembly_version'] = list(set(a.decode() for a in assemblies))
    
    return info

def extract_all_strings(filepath, min_length=4):
    """Extract all readable strings from the binary."""
    strings = []
    with open(filepath, 'rb') as f:
        data = f.read()
    
    # ASCII strings
    ascii_pattern = re.compile(rb'[\x20-\x7e]{%d,}' % min_length)
    for match in ascii_pattern.finditer(data):
        try:
            s = match.group().decode('ascii')
            strings.append(('ASCII', s))
        except:
            pass
    
    # Unicode strings (UTF-16 LE)
    i = 0
    while i < len(data) - 2:
        chars = []
        j = i
        while j < len(data) - 1:
            lo, hi = data[j], data[j+1]
            if hi == 0 and 0x20 <= lo <= 0x7e:
                chars.append(chr(lo))
                j += 2
            else:
                break
        if len(chars) >= min_length:
            s = ''.join(chars)
            if s not in [x[1] for x in strings]:  # avoid duplicates
                strings.append(('UTF16', s))
        i = j + 2 if j == i else j
    
    return strings

def categorize_strings(strings):
    """Categorize extracted strings into meaningful groups."""
    categories = defaultdict(list)
    
    for stype, s in strings:
        # SQL queries
        if re.search(r'\b(SELECT|INSERT|UPDATE|DELETE|CREATE|ALTER|DROP)\b', s, re.IGNORECASE) and len(s) > 15:
            categories['sql_queries'].append(s)
        # Table names (from SQL context)
        elif re.match(r'^[A-Z][a-z]+[A-Z]', s) and '_' not in s and len(s) > 3 and len(s) < 30:
            if any(kw in s.lower() for kw in ['mast', 'detl', 'head', 'summ', 'rate', 'gold', 'item']):
                categories['possible_table_names'].append(s)
        # Form/class names
        elif s.startswith('DataCareNext.') and '.resources' not in s:
            categories['class_names'].append(s)
        elif s.endswith('.resources'):
            categories['resource_names'].append(s)
        # Event handlers
        elif s.endswith('_Click') or s.endswith('_Load') or s.endswith('_Closed'):
            categories['event_handlers'].append(s)
        # Properties (get_/set_)
        elif s.startswith('get_') or s.startswith('set_'):
            categories['properties'].append(s)
        # URLs
        elif 'http' in s.lower() or 'www.' in s.lower():
            categories['urls'].append(s)
        # Connection strings
        elif 'Data Source' in s or 'Provider=' in s or 'connectionString' in s.lower():
            categories['connection_strings'].append(s)
        # Namespaces
        elif re.match(r'^(System|Microsoft|DevExpress|Qios)\.\w+', s):
            categories['namespaces_references'].append(s)
        # Module names
        elif s.startswith('Module_'):
            categories['modules'].append(s)
        # Field names (Hungarian notation - common in VB.NET)
        elif re.match(r'^(txt|cbo|dgv|lbl|btn|chk|pnl|grp|pic|cmb|frm|mnu)[A-Z]', s):
            categories['ui_controls'].append(s)
        # Database field patterns
        elif re.match(r'^[a-z]{1,3}[A-Z][a-zA-Z]+$', s) and len(s) > 4 and len(s) < 25:
            categories['field_variables'].append(s)
        # Error messages / user-facing strings
        elif re.search(r'(error|warning|success|failed|invalid|please|enter|select)', s, re.IGNORECASE) and len(s) > 10:
            categories['messages'].append(s)
    
    # Deduplicate
    for key in categories:
        categories[key] = sorted(set(categories[key]))
    
    return dict(categories)

def extract_embedded_resources_info(filepath):
    """Extract info about embedded resources from .rsrc section."""
    resources = []
    with open(filepath, 'rb') as f:
        data = f.read()
    
    # Find resource names (pattern: DataCareNext.XXXX.resources)
    pattern = rb'DataCareNext\.\w+\.resources'
    for match in re.finditer(pattern, data):
        resources.append(match.group().decode('ascii', errors='replace'))
    
    return sorted(set(resources))

def analyze_form_structure(strings):
    """Analyze form structures from the extracted string data."""
    forms = defaultdict(lambda: {
        'event_handlers': [],
        'controls': [],
        'properties': []
    })
    
    for stype, s in strings:
        # Match form event handlers like MS_LOGIN_Load, TR_SALE_Click etc
        form_event = re.match(r'^(MS_\w+|TR_\w+|RP_\w+|UT_\w+|MDI_\w+)_(Load|Closed|Activated|Deactivate|KeyDown|KeyPress|KeyUp|Validated)$', s)
        if form_event:
            form_name = form_event.group(1)
            event = form_event.group(2)
            forms[form_name]['event_handlers'].append(event)
        
        # Match button click handlers within forms
        btn_match = re.match(r'^(Btn\w+)_Click$', s)
        if btn_match:
            # Try to figure out which form it belongs to from context
            forms['_global_buttons']['controls'].append(btn_match.group(1))
    
    return dict(forms)

def extract_database_schema_hints(strings):
    """Extract database table and column name hints."""
    tables = set()
    columns = set()
    
    for stype, s in strings:
        # Ac_ prefixed items are often data access classes mapping to tables
        if re.match(r'^Ac_\w+$', s):
            tables.add(s)
        # Common table naming patterns
        if re.match(r'^(Mst|Trn|Rpt|Tmp|Vw_)\w+$', s):
            tables.add(s)
        # Column-like patterns
        if re.match(r'^(c|m|g|t)[A-Z][a-zA-Z]{2,20}$', s):
            if not any(kw in s for kw in ['Click', 'Load', 'Event', 'Handler', 'Button', 'Control']):
                columns.add(s)
    
    return {
        'data_access_classes': sorted(tables),
        'possible_columns': sorted(list(columns)[:100])  # Limit output
    }

def main():
    base_dir = '/Users/yakshitsavaliya/Desktop/imodule-extracted'
    output_dir = os.path.join(base_dir, 'extraction_output')
    os.makedirs(output_dir, exist_ok=True)
    
    exe_files = ['DataCareNext.exe', 'NextDm.exe']
    
    for exe in exe_files:
        filepath = os.path.join(base_dir, exe)
        if not os.path.exists(filepath):
            print(f"Skipping {exe} - file not found")
            continue
        
        print(f"\n{'='*60}")
        print(f"Analyzing: {exe}")
        print(f"File size: {os.path.getsize(filepath):,} bytes")
        print(f"{'='*60}")
        
        # 1. PE Header info
        print("\n[1] PE Header Analysis...")
        pe_info = read_pe_header(filepath)
        print(json.dumps(pe_info, indent=2, default=str))
        
        # 2. Extract all strings
        print("\n[2] Extracting strings...")
        all_strings = extract_all_strings(filepath)
        print(f"   Total strings extracted: {len(all_strings)}")
        
        # 3. Categorize strings
        print("\n[3] Categorizing strings...")
        categories = categorize_strings(all_strings)
        for cat, items in sorted(categories.items()):
            print(f"   {cat}: {len(items)} items")
        
        # 4. Embedded resources
        print("\n[4] Embedded resources...")
        resources = extract_embedded_resources_info(filepath)
        print(f"   Found {len(resources)} resource entries")
        
        # 5. Form structure analysis
        print("\n[5] Form structure analysis...")
        forms = analyze_form_structure(all_strings)
        print(f"   Found {len(forms)} form/class structures")
        
        # 6. Database schema hints
        print("\n[6] Database schema analysis...")
        db_schema = extract_database_schema_hints(all_strings)
        print(f"   Data access classes: {len(db_schema['data_access_classes'])}")
        print(f"   Possible columns: {len(db_schema['possible_columns'])}")
        
        # Write all output
        exe_name = exe.replace('.exe', '')
        
        # Write categorized strings
        with open(os.path.join(output_dir, f'{exe_name}_categorized.json'), 'w') as f:
            json.dump(categories, f, indent=2)
        
        # Write form structures
        with open(os.path.join(output_dir, f'{exe_name}_forms.json'), 'w') as f:
            json.dump(forms, f, indent=2, default=list)
        
        # Write PE info
        with open(os.path.join(output_dir, f'{exe_name}_pe_info.json'), 'w') as f:
            json.dump(pe_info, f, indent=2, default=str)
        
        # Write database schema hints
        with open(os.path.join(output_dir, f'{exe_name}_db_schema.json'), 'w') as f:
            json.dump(db_schema, f, indent=2)
        
        # Write all strings to text file
        with open(os.path.join(output_dir, f'{exe_name}_all_strings.txt'), 'w') as f:
            for stype, s in all_strings:
                f.write(f"[{stype}] {s}\n")
        
        # Write resources list
        with open(os.path.join(output_dir, f'{exe_name}_resources.txt'), 'w') as f:
            for r in resources:
                f.write(r + '\n')
        
        print(f"\n   Output written to {output_dir}/{exe_name}_*")
    
    print(f"\n\nAll extraction complete. Files saved to: {output_dir}")

if __name__ == '__main__':
    main()
