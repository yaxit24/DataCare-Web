#!/usr/bin/env python3
import sys
from pathlib import Path

LOCAL_SITE_PACKAGES = Path("/Users/yakshitsavaliya/Library/Python/3.9/lib/python/site-packages")
if LOCAL_SITE_PACKAGES.exists():
    sys.path.insert(0, str(LOCAL_SITE_PACKAGES))

import dotnetfile

def names(path):
    pe = dotnetfile.DotNetPE(str(path))
    return set(pe.ManifestResource.get_resource_names())

if len(sys.argv) != 3:
    raise SystemExit("usage: compare_manifest_resources.py ORIGINAL_EXE REBUILT_EXE")

original = Path(sys.argv[1])
rebuilt = Path(sys.argv[2])
original_names = names(original)
rebuilt_names = names(rebuilt)

missing = sorted(original_names - rebuilt_names)
extra = sorted(rebuilt_names - original_names)

print(f"original={original} resources={len(original_names)}")
print(f"rebuilt={rebuilt} resources={len(rebuilt_names)}")
print(f"missing={len(missing)}")
for item in missing:
    print(f"  - {item}")
print(f"extra={len(extra)}")
for item in extra:
    print(f"  + {item}")

raise SystemExit(1 if missing or extra else 0)
