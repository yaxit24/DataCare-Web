#!/usr/bin/env python3
import re
import sys
from pathlib import Path

if len(sys.argv) < 2:
    raise SystemExit("usage: fix_field_accessed_auto_properties.py FILE_OR_DIR [FILE_OR_DIR...]")

PROPERTY_RE = re.compile(
    r'(?P<indent>[ \t]*)\[field: AccessedThroughProperty\("(?P<accessed>[^"]+)"\)\]\r?\n'
    r'(?P=indent)(?P<mods>(?:public|private|internal|protected|static|virtual|override|sealed|new|readonly|unsafe|extern|partial|async|[ \t])+?)'
    r'(?P<type>[A-Za-z_][A-Za-z0-9_<>,\.\?\[\] ]*[A-Za-z0-9_\]\?])\s+'
    r'(?P<name>[A-Za-z_][A-Za-z0-9_]*)\r?\n'
    r'(?P=indent)\{\r?\n'
    r'(?P=indent)\tget; \[MethodImpl\(MethodImplOptions\.Synchronized\)\]\r?\n'
    r'(?P=indent)\tset;\r?\n'
    r'(?P=indent)\}',
    re.MULTILINE,
)

def backing_name(name: str) -> str:
    return "_" + name if not name.startswith("_") else "_" + name

def convert(match: re.Match) -> str:
    indent = match.group("indent")
    accessed = match.group("accessed")
    mods = " ".join(match.group("mods").split())
    type_name = " ".join(match.group("type").split())
    prop_name = match.group("name")
    field_name = backing_name(prop_name)
    return (
        f'{indent}[CompilerGenerated]\n'
        f'{indent}[DebuggerBrowsable(DebuggerBrowsableState.Never)]\n'
        f'{indent}[AccessedThroughProperty("{accessed}")]\n'
        f'{indent}private {type_name} {field_name};\n\n'
        f'{indent}{mods} {type_name} {prop_name}\n'
        f'{indent}{{\n'
        f'{indent}\tget\n'
        f'{indent}\t{{\n'
        f'{indent}\t\treturn {field_name};\n'
        f'{indent}\t}}\n'
        f'{indent}\t[MethodImpl(MethodImplOptions.Synchronized)]\n'
        f'{indent}\tset\n'
        f'{indent}\t{{\n'
        f'{indent}\t\t{field_name} = value;\n'
        f'{indent}\t}}\n'
        f'{indent}}}'
    )

paths = []
for arg in sys.argv[1:]:
    path = Path(arg)
    if path.is_dir():
        paths.extend(sorted(path.rglob("*.cs")))
    else:
        paths.append(path)

changed = 0
for path in paths:
    text = path.read_text(errors="ignore")
    new_text, count = PROPERTY_RE.subn(convert, text)
    if count:
        # Preserve original line endings by checking if we have \r\n
        if "\r\n" in text and "\r\n" not in new_text:
            new_text = new_text.replace("\n", "\r\n")
        path.write_text(new_text, encoding="utf-8")
        print(f"{path}: converted {count}")
        changed += count

print(f"total_converted={changed}")
