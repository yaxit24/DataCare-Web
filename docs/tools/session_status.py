#!/usr/bin/env python3
"""Print what other work is in flight for this repository, for a new DataCare session.

Read-only. It reads only session *metadata* (title, time, and the short tool-purpose lines at the end of the
log) for sessions whose process is still running — never the conversation content — and runs read-only git and
gh commands. It prints nothing secret. Run from anywhere:

  python3 docs/tools/session_status.py
"""
from __future__ import annotations

import json
import os
import re
import subprocess
import sys
import time
from pathlib import Path

SESS = Path(os.environ.get('KIRO_HOME', Path.home() / '.kiro')) / 'sessions' / 'cli'
SELF = os.environ.get('KIRO_SESSION_ID', '')
REPO = Path(__file__).resolve().parents[2]


def run(cmd: list[str], cwd: Path | None = None, timeout: int = 20) -> str:
    try:
        return subprocess.run(cmd, cwd=cwd, capture_output=True, text=True, timeout=timeout).stdout.strip()
    except Exception:
        return ''


def pid_is_kiro(pid: int) -> bool:
    """True only if the PID is live AND its command is a kiro-cli process (a reused PID is not)."""
    if not isinstance(pid, int) or pid <= 0:
        return False
    cmd = run(['ps', '-p', str(pid), '-o', 'command='], timeout=5)
    return 'kiro' in cmd.lower()


def tail_purposes(log: Path, n: int = 3) -> list[str]:
    """The last few __tool_use_purpose strings — a one-line hint of what the session is doing."""
    try:
        size = log.stat().st_size
        with log.open('rb') as fh:
            fh.seek(max(0, size - 200_000))
            text = fh.read().decode('utf-8', 'ignore')
    except OSError:
        return []
    purposes = re.findall(r'"__tool_use_purpose"\s*:\s*"((?:[^"\\]|\\.){0,200})"', text)
    out = []
    for p in purposes[-n:]:
        try:
            out.append(json.loads(f'"{p}"'))
        except Exception:
            out.append(p)
    return out


def active_sessions() -> list[dict]:
    rows = []
    for lock in sorted(SESS.glob('*.lock')):
        sid = lock.stem
        if sid == SELF:
            continue
        try:
            pid = json.loads(lock.read_text()).get('pid')
        except Exception:
            continue
        if not isinstance(pid, int) or not pid_is_kiro(pid):
            continue  # stale lock from a crashed session, or a reused PID
        try:
            if time.time() - lock.stat().st_mtime > 2 * 86400:
                continue  # not touched for two days; treat as abandoned
        except OSError:
            pass
        meta_path, log_path = SESS / f'{sid}.json', SESS / f'{sid}.jsonl'
        meta = {}
        try:
            meta = json.loads(meta_path.read_text())
        except Exception:
            pass
        rows.append({
            'sid': sid[:8],
            'pid': pid,
            'cwd': meta.get('cwd', '?'),
            'title': (meta.get('title') or '').strip()[:80],
            'updated': meta.get('updated_at', '?'),
            'doing': tail_purposes(log_path),
        })
    rows.sort(key=lambda r: r['updated'], reverse=True)
    return rows


def main() -> int:
    print('# Other work in flight for DataCare-Web\n')

    rows = active_sessions()
    repo_rows = [r for r in rows if 'imodule-extracted' in r['cwd'] or r['cwd'] in ('?', str(Path.home()))]
    print(f'## Active kiro-cli sessions (excluding this one): {len(rows)}')
    for r in rows:
        here = ' [this repo or home]' if r in repo_rows else ''
        print(f'- {r["sid"]} pid {r["pid"]} · updated {r["updated"]}{here}')
        if r['title']:
            print(f'    title: {r["title"]}')
        for d in r['doing']:
            print(f'    doing: {d[:110]}')
    if not rows:
        print('- none')

    print('\n## git worktrees')
    print(run(['git', 'worktree', 'list'], cwd=REPO) or '- none')

    print('\n## main')
    print(run(['git', 'log', '--oneline', '-3', 'origin/main'], cwd=REPO) or '(run: git fetch origin)')

    print('\n## open pull requests')
    prs = run(['gh', 'pr', 'list', '--repo', 'yaxit24/DataCare-Web', '--state', 'open',
               '--json', 'number,title,headRefName',
               '--jq', '.[] | "#\\(.number) \\(.headRefName) — \\(.title)"'])
    print(prs or '- none (or gh not authenticated)')

    print('\n## recently pushed branches')
    print(run(['git', 'for-each-ref', '--sort=-committerdate',
               '--format=%(committerdate:short) %(refname:short)', 'refs/remotes/origin'], cwd=REPO)[:600] or '-')

    print('\n## test database port 55433')
    busy = run(['bash', '-c', 'lsof -i :55433 -sTCP:LISTEN -t 2>/dev/null | head -1'])
    print('- in use — another session may be running database tests; do not start the isolated DB suite'
          if busy else '- free')

    print(f'\n(generated {time.strftime("%Y-%m-%dT%H:%M:%S%z")}; this session {SELF[:8] or "unknown"})')
    return 0


if __name__ == '__main__':
    sys.exit(main())
