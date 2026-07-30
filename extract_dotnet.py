#!/usr/bin/env python3
"""
Advanced .NET Assembly Metadata Extractor using dotnetfile library.
Extracts: TypeDefs (classes), MethodDefs, FieldDefs, Assembly references,
Module references, User strings, embedded resources, and more.
"""
import sys
sys.path.insert(0, '/Users/yakshitsavaliya/Library/Python/3.9/lib/python/site-packages')

import dotnetfile
import json
import os
from collections import defaultdict

def extract_dotnet_metadata(filepath):
    """Extract comprehensive .NET metadata from a PE file."""
    result = {
        'file': os.path.basename(filepath),
        'file_size': os.path.getsize(filepath),
    }
    
    try:
        dotnet_file = dotnetfile.DotNetPE(filepath)
    except Exception as e:
        result['error'] = str(e)
        return result
    
    # 1. Assembly info
    try:
        if hasattr(dotnet_file, 'Assembly') and dotnet_file.Assembly:
            assembly = dotnet_file.Assembly
            result['assembly'] = {
                'name': str(getattr(assembly, 'Name', 'N/A')),
            }
    except Exception as e:
        result['assembly_error'] = str(e)
    
    # 2. Assembly References (dependencies)
    try:
        if hasattr(dotnet_file, 'AssemblyRef'):
            refs = []
            for ref in dotnet_file.AssemblyRef:
                refs.append({
                    'name': str(getattr(ref, 'Name', 'N/A')),
                    'version': str(getattr(ref, 'Version', 'N/A')),
                })
            result['assembly_references'] = refs
    except Exception as e:
        result['assembly_references_error'] = str(e)
    
    # 3. TypeDefs (classes, structs, enums, etc.)
    try:
        if hasattr(dotnet_file, 'TypeDef'):
            types = []
            for typedef in dotnet_file.TypeDef:
                type_info = {
                    'name': str(getattr(typedef, 'Name', 'N/A')),
                    'namespace': str(getattr(typedef, 'Namespace', '')),
                }
                # Try to get methods for this type
                try:
                    if hasattr(typedef, 'MethodList'):
                        type_info['method_count'] = len(list(typedef.MethodList)) if typedef.MethodList else 0
                except:
                    pass
                # Try to get fields for this type
                try:
                    if hasattr(typedef, 'FieldList'):
                        type_info['field_count'] = len(list(typedef.FieldList)) if typedef.FieldList else 0
                except:
                    pass
                types.append(type_info)
            result['type_definitions'] = types
    except Exception as e:
        result['type_definitions_error'] = str(e)
    
    # 4. MethodDefs
    try:
        if hasattr(dotnet_file, 'MethodDef'):
            methods = []
            for method in dotnet_file.MethodDef:
                method_info = {
                    'name': str(getattr(method, 'Name', 'N/A')),
                }
                try:
                    if hasattr(method, 'Flags'):
                        method_info['flags'] = str(method.Flags)
                except:
                    pass
                methods.append(method_info)
            result['method_definitions'] = methods
            result['method_count'] = len(methods)
    except Exception as e:
        result['method_definitions_error'] = str(e)
    
    # 5. FieldDefs  
    try:
        if hasattr(dotnet_file, 'Field'):
            fields = []
            for field in dotnet_file.Field:
                field_info = {
                    'name': str(getattr(field, 'Name', 'N/A')),
                }
                fields.append(field_info)
            result['field_definitions'] = fields
            result['field_count'] = len(fields)
    except Exception as e:
        result['field_definitions_error'] = str(e)
    
    # 6. User Strings
    try:
        if hasattr(dotnet_file, 'UserString'):
            user_strings = []
            for us in dotnet_file.UserString:
                s = str(us)
                if len(s) > 1 and not all(c in '\x00\x01\x02' for c in s):
                    user_strings.append(s)
            result['user_strings'] = user_strings
            result['user_string_count'] = len(user_strings)
    except Exception as e:
        result['user_strings_error'] = str(e)
    
    # 7. Module References
    try:
        if hasattr(dotnet_file, 'ModuleRef'):
            module_refs = []
            for ref in dotnet_file.ModuleRef:
                module_refs.append(str(getattr(ref, 'Name', 'N/A')))
            result['module_references'] = module_refs
    except Exception as e:
        result['module_references_error'] = str(e)
    
    # 8. Type References (external types used)
    try:
        if hasattr(dotnet_file, 'TypeRef'):
            type_refs = []
            for ref in dotnet_file.TypeRef:
                type_refs.append({
                    'name': str(getattr(ref, 'Name', 'N/A')),
                    'namespace': str(getattr(ref, 'Namespace', '')),
                })
            result['type_references'] = type_refs
            result['type_reference_count'] = len(type_refs)
    except Exception as e:
        result['type_references_error'] = str(e)
    
    # 9. MemberRef (external method/field references)
    try:
        if hasattr(dotnet_file, 'MemberRef'):
            member_refs = []
            for ref in dotnet_file.MemberRef:
                member_refs.append({
                    'name': str(getattr(ref, 'Name', 'N/A')),
                })
            result['member_references'] = member_refs
            result['member_reference_count'] = len(member_refs)
    except Exception as e:
        result['member_references_error'] = str(e)
    
    # 10. Manifest Resources
    try:
        if hasattr(dotnet_file, 'ManifestResource'):
            resources = []
            for res in dotnet_file.ManifestResource:
                resources.append({
                    'name': str(getattr(res, 'Name', 'N/A')),
                })
            result['manifest_resources'] = resources
    except Exception as e:
        result['manifest_resources_error'] = str(e)
    
    # 11. Strings metadata stream
    try:
        if hasattr(dotnet_file, 'Strings'):
            strings_list = []
            for s in dotnet_file.Strings:
                if s and len(str(s)) > 1:
                    strings_list.append(str(s))
            result['metadata_strings'] = strings_list
            result['metadata_string_count'] = len(strings_list)
    except Exception as e:
        result['metadata_strings_error'] = str(e)
    
    return result

def analyze_architecture(metadata):
    """Analyze the extracted metadata to understand architecture."""
    analysis = {
        'forms': [],
        'modules': [],
        'data_access': [],
        'reports': [],
        'utilities': [],
        'services': [],
        'other': [],
    }
    
    if 'type_definitions' in metadata:
        for typedef in metadata['type_definitions']:
            name = typedef.get('name', '')
            ns = typedef.get('namespace', '')
            full = f"{ns}.{name}" if ns else name
            
            if name.startswith('MS_') or name.startswith('MDI_'):
                analysis['forms'].append(full)
            elif name.startswith('TR_'):
                analysis['forms'].append(full)  # Transaction forms
            elif name.startswith('RP_'):
                analysis['reports'].append(full)
            elif name.startswith('UT_'):
                analysis['utilities'].append(full)
            elif name.startswith('Module_') or name.startswith('Ac_') or name.startswith('Itm_'):
                analysis['data_access'].append(full)
            elif 'Service' in name:
                analysis['services'].append(full)
            elif name.startswith('Cls'):
                analysis['data_access'].append(full)
            else:
                analysis['other'].append(full)
    
    return analysis

def main():
    base_dir = '/Users/yakshitsavaliya/Desktop/imodule-extracted'
    output_dir = os.path.join(base_dir, 'extraction_output')
    os.makedirs(output_dir, exist_ok=True)
    
    exe_files = ['DataCareNext.exe', 'NextDm.exe']
    
    for exe in exe_files:
        filepath = os.path.join(base_dir, exe)
        if not os.path.exists(filepath):
            print(f"Skipping {exe}")
            continue
        
        print(f"\n{'='*60}")
        print(f"Deep .NET Analysis: {exe}")
        print(f"{'='*60}")
        
        metadata = extract_dotnet_metadata(filepath)
        
        # Print summary
        for key in ['method_count', 'field_count', 'user_string_count', 
                     'type_reference_count', 'member_reference_count',
                     'metadata_string_count']:
            if key in metadata:
                print(f"  {key}: {metadata[key]}")
        
        if 'type_definitions' in metadata:
            print(f"  type_definitions: {len(metadata['type_definitions'])}")
        if 'assembly_references' in metadata:
            print(f"  assembly_references: {len(metadata['assembly_references'])}")
            for ref in metadata['assembly_references']:
                print(f"    - {ref['name']} v{ref.get('version', '?')}")
        if 'manifest_resources' in metadata:
            print(f"  manifest_resources: {len(metadata['manifest_resources'])}")
        
        # Architecture analysis
        architecture = analyze_architecture(metadata)
        print(f"\n  Architecture Breakdown:")
        for category, items in architecture.items():
            if items:
                print(f"    {category}: {len(items)} types")
        
        # Save detailed output
        exe_name = exe.replace('.exe', '')
        
        # Full metadata (may be large)
        with open(os.path.join(output_dir, f'{exe_name}_dotnet_metadata.json'), 'w') as f:
            json.dump(metadata, f, indent=2, default=str)
        
        # Architecture analysis
        with open(os.path.join(output_dir, f'{exe_name}_architecture.json'), 'w') as f:
            json.dump(architecture, f, indent=2)
        
        # Type definitions only
        if 'type_definitions' in metadata:
            with open(os.path.join(output_dir, f'{exe_name}_types.json'), 'w') as f:
                json.dump(metadata['type_definitions'], f, indent=2)
        
        # Method definitions only
        if 'method_definitions' in metadata:
            with open(os.path.join(output_dir, f'{exe_name}_methods.json'), 'w') as f:
                json.dump(metadata['method_definitions'], f, indent=2)
        
        # User strings (most valuable for understanding logic)
        if 'user_strings' in metadata:
            with open(os.path.join(output_dir, f'{exe_name}_user_strings.txt'), 'w') as f:
                for s in metadata['user_strings']:
                    f.write(s + '\n')
        
        # Assembly references
        if 'assembly_references' in metadata:
            with open(os.path.join(output_dir, f'{exe_name}_dependencies.json'), 'w') as f:
                json.dump(metadata['assembly_references'], f, indent=2)
        
        print(f"\n  Output saved to {output_dir}/{exe_name}_*")
    
    print("\n\nDone! All .NET metadata extracted.")

if __name__ == '__main__':
    main()
