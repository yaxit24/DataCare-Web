#!/usr/bin/env python3
import hashlib
import json
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
LOCAL_SITE_PACKAGES = Path("/Users/yakshitsavaliya/Library/Python/3.9/lib/python/site-packages")
if LOCAL_SITE_PACKAGES.exists():
    sys.path.insert(0, str(LOCAL_SITE_PACKAGES))

try:
    import dotnetfile
except Exception as exc:
    raise SystemExit(f"dotnetfile is required for metadata parity audit: {exc}")

TARGETS = {
    "DataCareNext": {
        "exe": ROOT / "DataCareNext.exe",
        "source_root": ROOT / "extracted_code" / "DataCareNext",
    },
    "NextDm": {
        "exe": ROOT / "NextDm.exe",
        "source_root": ROOT / "extracted_code" / "NextDm",
    },
}

def sha256(path: Path) -> str:
    h = hashlib.sha256()
    with path.open("rb") as f:
        for chunk in iter(lambda: f.read(1024 * 1024), b""):
            h.update(chunk)
    return h.hexdigest()

def cs_files(source_root: Path):
    return sorted((source_root / "DataCareNext").glob("*.cs"))

def resx_resource_names(source_root: Path):
    names = {p.stem + ".resources" for p in source_root.glob("*.resx")}
    license_file = source_root / "DataCareNext.exe.licenses"
    if license_file.exists():
        names.add("DataCareNext.exe.licenses")
    return sorted(names)

def initialize_component_classes(source_root: Path):
    found = []
    for path in cs_files(source_root):
        if "InitializeComponent" in path.read_text(errors="ignore"):
            found.append(path.stem)
    return sorted(found)

def rpt_literals(source_root: Path):
    names = {}
    for path in cs_files(source_root):
        text = path.read_text(errors="ignore")
        for match in re.finditer(r'"([^"]+\.rpt)"', text, flags=re.I):
            raw = match.group(1)
            base = re.split(r"\\|/", raw)[-1]
            names.setdefault(base, str(path.relative_to(ROOT)))
    return dict(sorted(names.items(), key=lambda item: item[0].lower()))

def manifest_resources(exe: Path):
    pe = dotnetfile.DotNetPE(str(exe))
    resource_names = sorted(pe.ManifestResource.get_resource_names())
    subresource_counts = {}
    for item in pe.dotnet_resources:
        subresource_counts[item["Name"]] = item.get("NumberOfSubResources")
    return resource_names, subresource_counts

def assembly_refs(exe: Path):
    pe = dotnetfile.DotNetPE(str(exe))
    return sorted(pe.AssemblyRef.get_assemblyref_names())

def method_count(exe: Path):
    pe = dotnetfile.DotNetPE(str(exe))
    return len(pe.MethodDef.get_method_names())

def main():
    package_rpts = {p.name.lower(): p.name for p in ROOT.glob("*.rpt")}
    result = {
        "package": {
            "zip": str(ROOT / "Next_1106.zip"),
            "root_rpt_count": len(package_rpts),
            "root_rpts": sorted(package_rpts.values(), key=str.lower),
        },
        "targets": {},
    }
    for name, info in TARGETS.items():
        exe = info["exe"]
        source_root = info["source_root"]
        manifest, subcounts = manifest_resources(exe)
        source_resx = resx_resource_names(source_root)
        init_classes = initialize_component_classes(source_root)
        rpt_names = rpt_literals(source_root)
        present_rpts = sorted([r for r in rpt_names if r.lower() in package_rpts], key=str.lower)
        missing_rpts = sorted([r for r in rpt_names if r.lower() not in package_rpts], key=str.lower)
        result["targets"][name] = {
            "exe_size": exe.stat().st_size,
            "exe_sha256": sha256(exe),
            "assembly_refs": assembly_refs(exe),
            "assembly_ref_count": len(assembly_refs(exe)),
            "metadata_method_count": method_count(exe),
            "manifest_resource_count": len(manifest),
            "manifest_resources": manifest,
            "source_resx_count_including_license": len(source_resx),
            "missing_source_resources": sorted(set(manifest) - set(source_resx)),
            "extra_source_resources": sorted(set(source_resx) - set(manifest)),
            "subresource_counts_for_missing_source_resources": {
                key: subcounts.get(key) for key in sorted(set(manifest) - set(source_resx))
            },
            "initialize_component_class_count": len(init_classes),
            "rpt_literal_count": len(rpt_names),
            "rpt_present_in_package_count": len(present_rpts),
            "rpt_missing_from_package_count": len(missing_rpts),
            "rpt_missing_from_package": {name: rpt_names[name] for name in missing_rpts},
        }
    out_dir = ROOT / "audit"
    out_dir.mkdir(exist_ok=True)
    out_path = out_dir / "next1106-parity.json"
    out_path.write_text(json.dumps(result, indent=2), encoding="utf-8")
    print(out_path)

if __name__ == "__main__":
    main()
