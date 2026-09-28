#!/usr/bin/env python3
import sys
from pathlib import Path

if len(sys.argv) < 2:
    raise SystemExit("usage: fix_timer_ambiguities.py FILE_OR_DIR [FILE_OR_DIR...]")

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
    new_text = text
    
    # Replace the decompiler artifacts
    new_text = new_text.replace("System.Windows.Forms.Timer1", "Timer1")
    new_text = new_text.replace("System.Windows.Forms.Timer1_Tick", "Timer1_Tick")
    
    if new_text != text:
        path.write_text(new_text, encoding="utf-8")
        print(f"{path}: fixed timer ambiguities")
        changed += 1

print(f"total_files_changed={changed}")
