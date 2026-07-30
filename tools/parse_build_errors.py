#!/usr/bin/env python3
import json
import re
import sys
from collections import Counter, defaultdict
from pathlib import Path

if len(sys.argv) != 2:
    raise SystemExit("usage: parse_build_errors.py BUILD_LOG")

log_path = Path(sys.argv[1])
lines = log_path.read_text(errors="ignore").splitlines()
errors = []
warnings = []

for line in lines:
    error_match = re.search(r"(?P<file>.*?\.(?:cs|resx|csproj))\((?P<line>\d+),(?P<col>\d+)\): error (?P<code>CS\d+|MSB\d+|NETSDK\d+): (?P<message>.*?)(?: \[.*\])?$", line)
    if error_match:
        errors.append(error_match.groupdict())
        continue
    warning_match = re.search(r"(?P<file>.*?\.(?:cs|resx|csproj))\((?P<line>\d+),(?P<col>\d+)\): warning (?P<code>CS\d+|MSB\d+|NETSDK\d+): (?P<message>.*?)(?: \[.*\])?$", line)
    if warning_match:
        warnings.append(warning_match.groupdict())

missing_types = Counter()
files_by_code = defaultdict(Counter)
for item in errors:
    code = item["code"]
    files_by_code[code][item["file"]] += 1
    missing = re.search(r"The type or namespace name '([^']+)' could not be found", item["message"])
    if missing:
        missing_types[missing.group(1)] += 1

summary_match = None
for line in lines:
    m = re.search(r"^\s*(\d+)\s+Error\(s\)", line)
    if m:
        summary_match = int(m.group(1))

result = {
    "log": str(log_path),
    "parsed_error_lines": len(errors),
    "msbuild_summary_errors": summary_match,
    "total_errors": summary_match if summary_match is not None else len(errors),
    "parsed_warning_lines": len(warnings),
    "errors_by_code": Counter(item["code"] for item in errors),
    "missing_types": missing_types,
    "top_files_by_code": {
        code: dict(counter.most_common(20)) for code, counter in files_by_code.items()
    },
}

print(json.dumps(result, indent=2))
raise SystemExit(1 if result["total_errors"] else 0)
