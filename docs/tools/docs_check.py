#!/usr/bin/env python3
"""Validate the documentation hub and regenerate its generated views.

Usage (from any directory):
  python3 docs/tools/docs_check.py           # check only; exit 1 on any problem
  python3 docs/tools/docs_check.py --write   # regenerate the two generated Markdown views, then check

What it proves (structure and evidence pointers only, not product behaviour):
  * docs/handbook/menu-catalog.jsonl has exactly one row per desktop menu in web/docs/COMPLETION-REGISTER.json;
    every desktop form has a decompiled source file; every dispatch range is inside MDI_FORM.cs and names one of
    the row's forms; every web screen resolves to a page.tsx; every API route is declared in app.ts or
    routes/txn.ts; every plan owner exists in the plan; every cited evidence path exists and its line range fits.
  * docs/handbook/doc-register.json classifies every Markdown file in the repository (first matching rule wins)
    and every rule matches at least one file.
  * Relative links and backtick file citations (`path/to/file.ts:10-20`) in the hub, handbooks, plan documents
    12-14, ADR-0004, AGENTS.md and agent skills resolve and their line ranges fit; a file that a planned slice will
    create is declared with <!-- planned: path -->. Those files contain no credential-shaped strings.
  * docs/handbook/menu-catalog.md and docs/handbook/doc-register.md equal what this script generates.
"""
from __future__ import annotations

import fnmatch
import json
import re
import subprocess
import sys
from collections import Counter, defaultdict
from pathlib import Path
from urllib.parse import unquote

REPO = Path(__file__).resolve().parents[2]
HANDBOOK = REPO / 'docs' / 'handbook'
PLAN = REPO / 'docs' / 'master-parity-plan-2026-09-29'
CATALOG = HANDBOOK / 'menu-catalog.jsonl'
CATALOG_MD = HANDBOOK / 'menu-catalog.md'
REGISTER = HANDBOOK / 'doc-register.json'
REGISTER_MD = HANDBOOK / 'doc-register.md'
DESKTOP_SRC = REPO / 'unified' / 'src' / 'csharp' / 'DataCareNext'
MDI = DESKTOP_SRC / 'MDI_FORM.cs'
WEB_APP = REPO / 'web' / 'apps' / 'web' / 'app'
API_ROUTE_FILES = [REPO / 'web/apps/api/src/app.ts', REPO / 'web/apps/api/src/routes/txn.ts']
MASTER_CONFIGS = REPO / 'web/apps/api/src/modules/masters/configs.ts'

STATUSES = ['FULL', 'PARTIAL', 'REPORT', 'CONTAINED', 'MISSING']
PHASES = ['P1-core', 'P1-edition', 'P2', 'defer']
CAPS = 'CREDPL'
CAP_NAMES = ['create', 'reopen', 'edit', 'delete', 'print', 'list']
ROW_KEYS = ['id', 'tab', 'menu', 'forms', 'mode', 'dispatch', 'purpose', 'looks', 'tables', 'ui', 'api', 'can',
            'status', 'gaps', 'owners', 'phase', 'sources']
OPTIONAL_KEYS = {'fix'}
DOC_STATUSES = ['current', 'generated', 'reference', 'historical', 'superseded', 'evidence']
# The same route pattern web/apps/api/test/routePolicy.test.ts uses for the declared route universe.
ROUTE_RE = re.compile(r"\b(?:app|server)\.(get|post|put|patch|delete)\(\s*(['\"`])([^'\"`]+)\2")
LINK_RE = re.compile(r'(?<!!)\[[^\]]+\]\(([^)\s]+)\)')
# A backtick citation of a repository file, optionally with line ranges: `web/apps/api/src/app.ts:241-246,300`.
CITE_RE = re.compile(r'`((?:[A-Za-z0-9_.()\[\]@-]+/)+[A-Za-z0-9_.()\[\]@-]+\.(?:cs|vb|ts|tsx|mjs|cjs|js|json|jsonl|md|sql|'
                     r'prisma|py|yml|yaml|sh|txt|xml|html|css|toml|srt))(?::([\d,-]+))?`')
# A document may name a file that a planned slice will create: <!-- planned: web/apps/api/src/routes/index.ts -->
PLANNED_RE = re.compile(r'<!--\s*planned:\s*(\S+)\s*-->')
SECRET_PATTERNS = [
    ('connection string with credentials', re.compile(r'\b(?:postgres(?:ql)?|mssql|sqlserver|mysql)://[^\s:/@]+:[^\s@]+@')),
    ('password assignment', re.compile(r'(?i)\b(?:password|passwd|pwd)\s*[:=]\s*["\']?[^\s"\'`<>{}|]{6,}')),
    ('private key block', re.compile(r'-----BEGIN [A-Z ]*PRIVATE KEY-----')),
    ('JSON web token', re.compile(r'\beyJ[A-Za-z0-9_-]{10,}\.[A-Za-z0-9_-]{10,}\.[A-Za-z0-9_-]{10,}')),
    ('AWS access key', re.compile(r'\bAKIA[0-9A-Z]{16}\b')),
    ('Indian mobile number', re.compile(r'(?<![\d.,/-])[6-9]\d{9}(?![\d.,/-])')),
]

errors: list[str] = []


def check(condition: bool, message: str) -> None:
    if not condition:
        errors.append(message)


def read(path: Path) -> str:
    return path.read_text(encoding='utf-8')


def line_count(path: Path) -> int:
    return len(read(path).splitlines())


# ---------------------------------------------------------------- reference data
def plan_ids() -> set[str]:
    ids: set[str] = set()
    backlog = json.loads(read(PLAN / 'execution-backlog.json'))
    ids |= {s['id'] for s in backlog['newSlices']}
    ids |= {c['id'] for c in backlog['priorCards']}
    ids |= {p['id'] for p in backlog['priorPackages']}
    ids |= set(backlog.get('releaseGates', []))
    for name in ('10-gap-register-2026-10-01.md', '11-audit-implementation-plan-2026-10-01.md',
                 '12-lineage-verification-2026-10-01.md'):
        path = PLAN / name
        if path.is_file():
            ids |= set(re.findall(r'^\| (G\d{2}) \|', read(path), re.M))
            ids |= set(re.findall(r'^\| (D\d{2}) \|', read(path), re.M))
    ids |= set(re.findall(r'^\| (D\d{2}) \|', read(PLAN / '08-decisions-and-delivery.md'), re.M))
    ids |= set(re.findall(r'^### (J\d{2}) — ', read(PLAN / '04-verification-playbook.md'), re.M))
    phase2 = PLAN / 'phase2-backlog.json'
    if phase2.is_file():
        ids |= {s['id'] for s in json.loads(read(phase2))['slices']}
    return ids


def declared_routes() -> set[str]:
    routes = set()
    for path in API_ROUTE_FILES:
        for m in ROUTE_RE.finditer(read(path)):
            routes.add(f'{m.group(1).upper()} {m.group(3)}')
    return routes


def page_routes() -> tuple[set[str], set[str]]:
    """Static page routes and dynamic route templates (with [segment]) from page.tsx files."""
    static, dynamic = set(), set()
    for page in WEB_APP.rglob('page.tsx'):
        parts = [p for p in page.relative_to(WEB_APP).parent.parts if not (p.startswith('(') and p.endswith(')'))]
        route = '/' + '/'.join(parts) if parts else '/'
        (dynamic if '[' in route else static).add(route)
    return static, dynamic


def master_names() -> set[str]:
    return set(re.findall(r"^\s+['\"]?([a-z][a-z0-9-]*)['\"]?\s*:\s*[A-Z_]+_CONFIG\b", read(MASTER_CONFIGS), re.M))


def ui_route_ok(route: str, static: set[str], dynamic: set[str], masters: set[str], routes: set[str]) -> bool:
    path = route.split('?', 1)[0].rstrip('/') or '/'
    if path in static:
        return True
    parts = path.strip('/').split('/')
    for template in dynamic:
        tparts = template.strip('/').split('/')
        if len(tparts) != len(parts):
            continue
        if all(t == p or (t.startswith('[') and t.endswith(']')) for t, p in zip(tparts, parts)):
            if tparts[0] == 'masters' and tparts[-1] == '[name]':
                return parts[-1] in masters
            if tparts[0] == 'reports' and tparts[-1] == '[report]':
                return any(r.split(' ', 1)[1].startswith(path) for r in routes)
            return True
    return False


def evidence_ok(ref: str) -> str | None:
    """Return an error message for a 'path[:start[-end]]' reference, or None when it resolves."""
    m = re.match(r'^(.+?)(?::(\d+)(?:-(\d+))?)?$', ref)
    path = REPO / m.group(1)
    if not path.is_file():
        return f'missing file {m.group(1)}'
    if m.group(2):
        start, end = int(m.group(2)), int(m.group(3) or m.group(2))
        total = line_count(path)
        if not (1 <= start <= end <= total):
            return f'line range {start}-{end} outside 1-{total} in {m.group(1)}'
    return None


# ---------------------------------------------------------------- menu catalog
def load_catalog() -> list[dict]:
    rows = []
    for number, line in enumerate(read(CATALOG).splitlines(), 1):
        if not line.strip():
            continue
        try:
            rows.append(json.loads(line))
        except json.JSONDecodeError as exc:
            errors.append(f'menu-catalog.jsonl line {number}: invalid JSON ({exc})')
    return rows


def check_catalog(rows: list[dict]) -> dict:
    register = json.loads(read(REPO / 'web/docs/COMPLETION-REGISTER.json'))['items']
    expected = {f"{i['tab']}/{i['menu']}": i for i in register}
    ids = [r.get('id') for r in rows]
    check(len(ids) == len(set(ids)), 'menu catalog has duplicate ids')
    check(set(ids) == set(expected), 'menu catalog ids differ from the completion register: missing '
          + ','.join(sorted(set(expected) - set(ids))) + '; extra ' + ','.join(sorted(set(ids) - set(expected))))
    owners_known = plan_ids()
    routes = declared_routes()
    static, dynamic = page_routes()
    masters = master_names()
    mdi_lines = read(MDI).splitlines()
    for row in rows:
        rid = row.get('id', '?')
        keys = set(row)
        check(set(ROW_KEYS) <= keys and keys <= set(ROW_KEYS) | OPTIONAL_KEYS, f'{rid}: unexpected key set')
        if not set(ROW_KEYS) <= keys:
            continue
        reg = expected.get(rid)
        if reg:
            check(row['tab'] == reg['tab'] and row['menu'] == reg['menu'], f'{rid}: tab/menu differ from register')
        check(row['status'] in STATUSES, f'{rid}: unknown status {row["status"]}')
        check(row['phase'] in PHASES, f'{rid}: unknown phase {row["phase"]}')
        check(isinstance(row['can'], str) and len(row['can']) == 6
              and all(c in (CAPS[i], '-') for i, c in enumerate(row['can'])), f'{rid}: capability flags malformed')
        for field in ('purpose', 'looks', 'gaps', 'mode'):
            check(isinstance(row[field], str) and row[field].strip() != '', f'{rid}: empty {field}')
        for form in row['forms']:
            check((DESKTOP_SRC / f'{form}.cs').is_file(), f'{rid}: no decompiled source for form {form}')
        if row['dispatch'] is None:
            check(row['forms'] == [], f'{rid}: forms listed without a dispatch range')
        else:
            m = re.match(r'^unified/src/csharp/DataCareNext/MDI_FORM\.cs:(\d+)-(\d+)$', row['dispatch'])
            check(bool(m), f'{rid}: dispatch must be MDI_FORM.cs:start-end')
            if m:
                start, end = int(m.group(1)), int(m.group(2))
                inside = 1 <= start <= end <= len(mdi_lines)
                check(inside, f'{rid}: dispatch range outside MDI_FORM.cs')
                if inside:
                    window = '\n'.join(mdi_lines[max(0, start - 4):min(len(mdi_lines), end + 3)])
                    check(any(re.search(rf'\b{re.escape(f)}\b', window) for f in row['forms']),
                          f'{rid}: none of {row["forms"]} appears in MDI_FORM.cs:{start}-{end}')
        for route in row['ui']:
            check(ui_route_ok(route, static, dynamic, masters, routes), f'{rid}: web screen {route} has no page')
        for route in row['api']:
            check(route in routes, f'{rid}: API route not declared: {route}')
        if row['status'] != 'MISSING':
            check(bool(row['ui'] or row['api']), f'{rid}: implemented status without a web surface')
        check(bool(row['owners']), f'{rid}: no plan owner')
        for owner in row['owners']:
            check(owner in owners_known, f'{rid}: unknown plan owner {owner}')
        for ref in row['sources']:
            problem = evidence_ok(ref)
            check(problem is None, f'{rid}: source {ref}: {problem}')
        check(bool(row['sources']), f'{rid}: no evidence source')
    return {'rows': len(rows), 'apiRoutes': len(routes), 'pages': len(static) + len(dynamic)}


def capability_text(can: str) -> str:
    return ', '.join(name for name, flag in zip(CAP_NAMES, can) if flag != '-') or 'none'


def link(ref: str, base: Path) -> str:
    m = re.match(r'^(.+?)(?::(\d+)(?:-(\d+))?)?$', ref)
    rel = Path('../' * len(base.relative_to(REPO).parent.parts) + m.group(1)).as_posix()
    rel = rel.replace('(', '%28').replace(')', '%29')  # Next.js route groups such as (app)
    anchor = f'#L{m.group(2)}' + (f'-L{m.group(3)}' if m.group(3) else '') if m.group(2) else ''
    return f'[{ref.split("/")[-1]}]({rel}{anchor})'


def render_catalog(rows: list[dict]) -> str:
    tabs = sorted({r['tab'] for r in rows}, key=lambda t: (
        ['Company', 'Master', 'Transaction', 'ExtraTran', 'Karigar', 'Dhiran', 'Scheme', 'Mfg', 'Report', 'More',
         'Analysis', 'Other', 'Crm'].index(t)))
    by_tab = defaultdict(list)
    for row in rows:
        by_tab[row['tab']].append(row)
    out = [
        '# Desktop menu catalog',
        '',
        '<!-- Generated by docs/tools/docs_check.py --write from menu-catalog.jsonl. Edit the JSONL, not this file. -->',
        '',
        'One entry per desktop menu (the 198 named `MENU_DATA` items in 13 ribbon tabs): the desktop form it opens, '
        'what it does for the business, how the screen looks, the tables it writes (reads, for reports), where the '
        'web implements it, what the web screen can do today, what is still missing and which plan items own the '
        'remainder. Desktop behaviour is described from the decompiled source, the official tutorial videos '
        '(`project-memory/video-research/_kb`) and the form catalogs; the web columns were read from the code at '
        'the date of the last edit.',
        '',
        'Statuses are this catalog\'s own engineering grade, not acceptance: no menu is accepted until it passes the '
        'desktop comparison and business sign-off in [document 04](../master-parity-plan-2026-09-29/04-verification-playbook.md).',
        '',
        '| Status | Meaning |',
        '|---|---|',
        '| FULL | Every desktop mode, lifecycle action and print exists on the web; only acceptance remains |',
        '| PARTIAL | A working web workflow exists but desktop modes, lifecycle actions, fields or prints are missing |',
        '| REPORT | Report data is shown, but desktop modes, filters, drill-downs or the print layout are incomplete |',
        '| CONTAINED | The web refuses the operation on purpose until it is safe (see the containment registry) |',
        '| MISSING | No equivalent web workflow exists |',
        '',
        'Capabilities: C create, R reopen a saved voucher, E edit it, D delete it, P print/document, L list saved '
        'vouchers (for reports: L shows rows, P prints or exports). Phases: **P1-core** is needed for desktop parity '
        'in a typical jewellery business; **P1-edition** only for specific editions or settings; **defer** has no '
        'desktop workflow.',
        '',
        '## Summary',
        '',
        '| Tab | Menus | ' + ' | '.join(STATUSES) + ' | P1-core | P1-edition | defer |',
        '|---|---:|' + '---:|' * (len(STATUSES) + 3),
    ]
    total_status, total_phase = Counter(), Counter()
    for tab in tabs:
        status = Counter(r['status'] for r in by_tab[tab])
        phase = Counter(r['phase'] for r in by_tab[tab])
        total_status.update(status)
        total_phase.update(phase)
        out.append(f'| {tab} | {len(by_tab[tab])} | ' + ' | '.join(str(status[s]) for s in STATUSES) + ' | '
                   + ' | '.join(str(phase[p]) for p in ('P1-core', 'P1-edition', 'defer')) + ' |')
    out.append(f'| **All** | **{len(rows)}** | ' + ' | '.join(f'**{total_status[s]}**' for s in STATUSES) + ' | '
               + ' | '.join(f'**{total_phase[p]}**' for p in ('P1-core', 'P1-edition', 'defer')) + ' |')
    fixes = [r for r in rows if r.get('fix')]
    out += ['', '## Completion-register corrections', '']
    if fixes:
        out += [f'{len(fixes)} rows of `web/docs/COMPLETION-REGISTER.json` name the wrong desktop form or web surface. '
                'The register is a hashed source of the requirement index, so it is corrected in its own revision, '
                'not edited in place. Until then this catalog is the corrected view.', '',
                '| Menu | Correction |', '|---|---|']
        out += [f'| {r["id"]} | {r["fix"]} |' for r in fixes]
    else:
        out += ['None. Slice N85 (gap G71) corrected the register to this catalog; `pnpm register:check` (web) '
                'now fails when a register row names a form the dispatch does not open or a surface the menu does '
                'not use.']
    for tab in tabs:
        out += ['', f'## {tab}', '', '| Menu | Desktop form | Web screen | C R E D P L | Status | Phase |',
                '|---|---|---|---|---|---|']
        for r in by_tab[tab]:
            forms = ', '.join(f'`{f}`' for f in r['forms']) or '—'
            ui = ', '.join(f'`{u}`' for u in r['ui']) or '—'
            out.append(f'| {r["menu"]} | {forms} | {ui} | `{" ".join(r["can"])}` | {r["status"]} | {r["phase"]} |')
        for r in by_tab[tab]:
            out += ['', f'### {r["menu"]}', '']
            dispatch = link(r['dispatch'], CATALOG_MD) if r['dispatch'] else 'not dispatched'
            out.append(f'- **Desktop:** {", ".join(f"`{f}`" for f in r["forms"]) or "no form"} — {r["mode"]} '
                       f'({dispatch}).')
            out.append(f'- **Does:** {r["purpose"]}')
            out.append(f'- **Looks:** {r["looks"]}')
            if r['tables']:
                verb = 'Reads' if r['status'] == 'REPORT' else 'Writes'
                out.append(f'- **{verb}:** {", ".join(r["tables"])}.')
            web = ', '.join(f'`{u}`' for u in r['ui']) or 'no screen'
            api = ', '.join(f'`{a}`' for a in r['api']) or 'no API'
            out.append(f'- **Web:** {web}; {api}. Can: {capability_text(r["can"])}.')
            out.append(f'- **Remaining:** {r["gaps"]}')
            out.append(f'- **Owners:** {", ".join(r["owners"])}.')
            if r.get('fix'):
                out.append(f'- **Register correction:** {r["fix"]}')
            out.append(f'- **Evidence:** {", ".join(link(s, CATALOG_MD) for s in r["sources"])}.')
    return '\n'.join(out) + '\n'


# ---------------------------------------------------------------- document register
def markdown_files() -> list[str]:
    result = subprocess.run(['git', 'ls-files', '--cached', '--others', '--exclude-standard', '*.md'],
                            cwd=REPO, check=True, capture_output=True, text=True)
    return sorted({p for p in result.stdout.splitlines() if (REPO / p).is_file()})


def classify(files: list[str], rules: list[dict]) -> tuple[dict[int, list[str]], list[str]]:
    matched: dict[int, list[str]] = defaultdict(list)
    unmatched = []
    for path in files:
        for index, rule in enumerate(rules):
            patterns = rule['match'] if isinstance(rule['match'], list) else [rule['match']]
            if any(fnmatch.fnmatchcase(path, p) for p in patterns):
                matched[index].append(path)
                break
        else:
            unmatched.append(path)
    return matched, unmatched


def check_register(register: dict, files: list[str]) -> tuple[dict[int, list[str]], dict]:
    rules = register['rules']
    for index, rule in enumerate(rules):
        name = rule.get('match')
        check(rule.get('status') in DOC_STATUSES, f'doc register rule {name}: unknown status')
        for key in ('area', 'kind', 'purpose'):
            check(bool(rule.get(key)), f'doc register rule {name}: missing {key}')
        for successor in rule.get('successor', []):
            check((REPO / successor).exists(), f'doc register rule {name}: missing successor {successor}')
    matched, unmatched = classify(files, rules)
    check(not unmatched, 'Markdown files not classified by docs/handbook/doc-register.json: ' + ', '.join(unmatched))
    for index, rule in enumerate(rules):
        check(bool(matched.get(index)), f'doc register rule matches no file: {rule["match"]}')
    status = Counter()
    for index, paths in matched.items():
        status[rules[index]['status']] += len(paths)
    return matched, {'markdownFiles': len(files), 'rules': len(rules), 'byStatus': dict(sorted(status.items()))}


def render_register(register: dict, matched: dict[int, list[str]]) -> str:
    rules = register['rules']
    out = [
        '# Documentation register',
        '',
        '<!-- Generated by docs/tools/docs_check.py --write from doc-register.json. Edit the JSON, not this file. -->',
        '',
        'Every Markdown file in the repository, classified by the first matching rule in `doc-register.json`. The '
        'check fails when a new Markdown file matches no rule, so new documents must be classified when they are '
        'added. Historical files are never moved or rewritten: links, test comments and evidence manifests refer '
        'to them by path.',
        '',
        '| Status | Meaning |',
        '|---|---|',
    ]
    out += [f'| {name} | {text} |' for name, text in register['statuses'].items()]
    areas = []
    for rule in rules:
        if rule['area'] not in areas:
            areas.append(rule['area'])
    for area in areas:
        out += ['', f'## {area}', '', '| Path | Files | Kind | Status | Superseded by / see | Purpose |',
                '|---|---:|---|---|---|---|']
        for index, rule in enumerate(rules):
            if rule['area'] != area:
                continue
            patterns = rule['match'] if isinstance(rule['match'], list) else [rule['match']]
            paths = matched.get(index, [])
            shown = '<br>'.join(f'`{p}`' for p in patterns)
            if len(paths) == 1 and paths[0] == patterns[0]:
                shown = f'[`{paths[0]}`]({"../../" + paths[0]})'
            successor = '<br>'.join(f'[`{s}`]({"../../" + s})' for s in rule.get('successor', [])) or '—'
            out.append(f'| {shown} | {len(paths)} | {rule["kind"]} | {rule["status"]} | {successor} | '
                       f'{rule["purpose"]} |')
    return '\n'.join(out) + '\n'


# ---------------------------------------------------------------- links and secrets
def hub_files() -> list[Path]:
    files = [REPO / 'docs' / 'README.md', REPO / 'AGENTS.md']
    files += sorted(HANDBOOK.rglob('*.md'))
    files += sorted((REPO / '.kiro' / 'skills').rglob('SKILL.md'))
    files += sorted((REPO / '.kiro' / 'steering').glob('*.md'))
    files += [PLAN / name for name in ('12-lineage-verification-2026-10-01.md', '13-phase1-delivery-plan.md',
                                       '14-phase2-saas-plan.md')]
    files += [REPO / 'project-memory' / 'decisions' / 'ADR-0004-two-phase-delivery.md']
    return [f for f in files if f.is_file()]


def check_links_and_secrets(files: list[Path]) -> dict:
    links = citations = 0
    lengths: dict[Path, int] = {}
    for path in files:
        text = read(path)
        planned = set(PLANNED_RE.findall(text))
        for target in LINK_RE.findall(text):
            target = unquote(target.strip('<>'))
            if '://' in target or target.startswith(('mailto:', '#')):
                continue
            links += 1
            resolved = (path.parent / target.split('#', 1)[0]).resolve()
            check(resolved.exists(), f'{path.relative_to(REPO)}: broken link {target}')
        for cited, ranges in CITE_RE.findall(text):
            if cited in planned:
                continue
            citations += 1
            target = REPO / cited
            if not target.is_file():
                errors.append(f'{path.relative_to(REPO)}: cited file does not exist: {cited}')
                continue
            if ranges:
                total = lengths.setdefault(target, line_count(target))
                for part in filter(None, ranges.split(',')):
                    bounds = [int(b) for b in part.split('-') if b]
                    ok = len(bounds) in (1, 2) and 1 <= bounds[0] <= bounds[-1] <= total
                    check(ok, f'{path.relative_to(REPO)}: {cited}:{part} is outside 1-{total}')
        for label, pattern in SECRET_PATTERNS:
            for m in pattern.finditer(text):
                errors.append(f'{path.relative_to(REPO)}: {label} pattern at offset {m.start()}')
    for label, pattern in SECRET_PATTERNS:
        for m in pattern.finditer(read(CATALOG)):
            errors.append(f'menu-catalog.jsonl: {label} pattern at offset {m.start()}')
    return {'files': len(files), 'relativeLinks': links, 'fileCitations': citations}


def check_module_map() -> dict:
    modules = {p.name for p in (REPO / 'web/apps/api/src/modules').iterdir() if p.is_dir()}
    text = read(HANDBOOK / 'web' / 'modules.md') if (HANDBOOK / 'web' / 'modules.md').is_file() else ''
    listed = set(re.findall(r'^\| `([a-z]+)` \|', text, re.M))
    check(modules <= listed, 'docs/handbook/web/modules.md misses API modules: ' + ', '.join(sorted(modules - listed)))
    check(listed <= modules, 'docs/handbook/web/modules.md lists unknown modules: ' + ', '.join(sorted(listed - modules)))
    return {'apiModules': len(modules)}


def main() -> int:
    write = '--write' in sys.argv[1:]
    rows = load_catalog()
    register = json.loads(read(REGISTER))
    if write:
        # Write the catalog view first, then classify (which must see both generated files), then render the register.
        CATALOG_MD.write_text(render_catalog(rows), encoding='utf-8')
        if not REGISTER_MD.exists():
            REGISTER_MD.write_text('placeholder\n', encoding='utf-8')
        matched, _ = classify(markdown_files(), register['rules'])
        REGISTER_MD.write_text(render_register(register, matched), encoding='utf-8')
    catalog_counts = check_catalog(rows)
    files = markdown_files()
    matched, register_counts = check_register(register, files)
    for path, text in {CATALOG_MD: render_catalog(rows), REGISTER_MD: render_register(register, matched)}.items():
        check(path.is_file() and read(path) == text,
              f'{path.relative_to(REPO)} is stale: run python3 docs/tools/docs_check.py --write')
    link_counts = check_links_and_secrets(hub_files())
    module_counts = check_module_map()
    print(json.dumps({
        'status': 'pass' if not errors else 'fail',
        'meaning': 'Documentation structure and evidence pointers only; no product behaviour is certified.',
        'counts': {'menuCatalog': catalog_counts, 'docRegister': register_counts, 'hub': link_counts,
                   'moduleMap': module_counts},
        'errors': errors,
    }, indent=2))
    return 1 if errors else 0


if __name__ == '__main__':
    sys.exit(main())
