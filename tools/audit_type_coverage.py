#!/usr/bin/env python3
import json
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
LOCAL_SITE_PACKAGES = Path("/Users/yakshitsavaliya/Library/Python/3.9/lib/python/site-packages")
if LOCAL_SITE_PACKAGES.exists():
    sys.path.insert(0, str(LOCAL_SITE_PACKAGES))

import dotnetfile

TARGETS = {
    "DataCareNext": {
        "exe": ROOT / "DataCareNext.exe",
        "source_roots": [
            ROOT / "extracted_code" / "DataCareNext" / "DataCareNext",
            ROOT / "extracted_code" / "DataCareNext" / "DataCareNext.My",
            ROOT / "extracted_code" / "DataCareNext" / "DataCareNext.My.Resources",
            ROOT / "extracted_code" / "DataCareNext",
            ROOT / "extracted_code" / "DataCareNext" / "Properties",
        ],
    },
    "NextDm": {
        "exe": ROOT / "NextDm.exe",
        "source_roots": [
            ROOT / "extracted_code" / "NextDm" / "DataCareNext",
            ROOT / "extracted_code" / "NextDm" / "DataCareNext.My",
            ROOT / "extracted_code" / "NextDm" / "DataCareNext.My.Resources",
            ROOT / "extracted_code" / "NextDm",
            ROOT / "extracted_code" / "NextDm" / "Properties",
        ],
    },
}

DECL_RE = re.compile(r"\b(class|struct|interface|enum|delegate)\s+([A-Za-z_][A-Za-z0-9_]*)")

def metadata_types(exe):
    pe = dotnetfile.DotNetPE(str(exe))
    names = set(pe.TypeDef.get_type_names())
    return sorted(name for name in names if name != "<Module>")

def source_types(source_roots):
    names = set()
    files_by_name = {}
    for root in source_roots:
        if root.is_file() and root.suffix == ".cs":
            paths = [root]
        elif root.is_dir():
            paths = sorted(root.glob("*.cs"))
        else:
            paths = []
        for path in paths:
            text = path.read_text(errors="ignore")
            for match in DECL_RE.finditer(text):
                name = match.group(2)
                names.add(name)
                files_by_name.setdefault(name, str(path.relative_to(ROOT)))
    return names, files_by_name

def main():
    result = {}
    failed = False
    for target, info in TARGETS.items():
        metadata = set(metadata_types(info["exe"]))
        source, files = source_types(info["source_roots"])
        missing = sorted(metadata - source)
        extra = sorted(source - metadata)
        result[target] = {
            "metadata_type_count": len(metadata),
            "source_type_count": len(source),
            "missing_metadata_types_in_source": missing,
            "extra_source_types_not_in_metadata": extra,
            "source_files_by_type": {name: files[name] for name in sorted(files)},
        }
        # Filter out compiler-generated nested types / delegates that don't need distinct files
        real_missing = [
            m for m in missing
            if not m.startswith("<")
            and not "_" in m
            and not "AnonymousDelegate" in m
            and not "DisplayClass" in m
        ]
        result[target]["real_missing_type_count"] = len(real_missing)
        result[target]["real_missing_types"] = real_missing
        if real_missing:
            failed = True
            
    out_dir = ROOT / "audit"
    out_dir.mkdir(exist_ok=True)
    out_path = out_dir / "type-coverage.json"
    out_path.write_text(json.dumps(result, indent=2), encoding="utf-8")
    print(out_path)
    raise SystemExit(1 if failed else 0)

if __name__ == "__main__":
    main()
