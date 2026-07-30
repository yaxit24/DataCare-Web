#!/usr/bin/env python3
import json
import sys
from pathlib import Path

LOCAL_SITE_PACKAGES = Path("/Users/yakshitsavaliya/Library/Python/3.9/lib/python/site-packages")
if LOCAL_SITE_PACKAGES.exists():
    sys.path.insert(0, str(LOCAL_SITE_PACKAGES))

import dotnetfile

def fixed_version(pe):
    info = pe.VS_FIXEDFILEINFO[0]
    file_ms = info.FileVersionMS
    file_ls = info.FileVersionLS
    product_ms = info.ProductVersionMS
    product_ls = info.ProductVersionLS
    return {
        "file": [
            (file_ms >> 16) & 0xFFFF,
            file_ms & 0xFFFF,
            (file_ls >> 16) & 0xFFFF,
            file_ls & 0xFFFF,
        ],
        "product": [
            (product_ms >> 16) & 0xFFFF,
            product_ms & 0xFFFF,
            (product_ls >> 16) & 0xFFFF,
            product_ls & 0xFFFF,
        ],
    }

def identity(path):
    pe = dotnetfile.DotNetPE(str(path))
    assembly_version = pe.Assembly.get_assembly_version_information()
    return {
        "path": str(path),
        "assembly_name": pe.Assembly.get_assembly_name(),
        "assembly_version": [
            assembly_version.MajorVersion,
            assembly_version.MinorVersion,
            assembly_version.BuildNumber,
            assembly_version.RevisionNumber,
        ],
        "assembly_refs": pe.AssemblyRef.get_assemblyref_names(),
        "win32_resource_entry_count": getattr(pe, "_PE__total_resource_entries_count", None),
        "win32_resource_bytes": getattr(pe, "_PE__total_resource_bytes", None),
        "fixed_version": fixed_version(pe),
        "streams": pe.get_stream_names(),
    }

if len(sys.argv) != 3:
    raise SystemExit("usage: compare_pe_identity.py ORIGINAL_EXE REBUILT_EXE")

original = identity(Path(sys.argv[1]))
rebuilt = identity(Path(sys.argv[2]))
checks = {
    "assembly_name": original["assembly_name"] == rebuilt["assembly_name"],
    "assembly_version": original["assembly_version"] == rebuilt["assembly_version"],
    "assembly_refs": original["assembly_refs"] == rebuilt["assembly_refs"],
    "win32_resource_entry_count": original["win32_resource_entry_count"] == rebuilt["win32_resource_entry_count"],
    "win32_resource_bytes": original["win32_resource_bytes"] == rebuilt["win32_resource_bytes"],
    "fixed_version": original["fixed_version"] == rebuilt["fixed_version"],
}
result = {"original": original, "rebuilt": rebuilt, "checks": checks}
print(json.dumps(result, indent=2))
raise SystemExit(0 if all(checks.values()) else 1)
