#!/usr/bin/env python3
"""Mutation checks for N19 (Tag Split X20, desktop TR_TAG_SPLIT).

Each mutation edits one source file to break one contract clause, runs the focused test that should catch it,
records whether the test FAILED (the desired outcome), and restores the file byte-for-byte. Run through the local
test environment so the database-backed tests are enabled:

    /projects/local-test-env.sh python3 mutation-check.py [mutation-id ...]

API tests import `@datacare/core` from its built dist, so core mutations run the core unit tests from source
(packages/core); web-model mutations run the web unit tests (apps/web).

Contract: parity-plan-2026-09-10/evidence/implementation-2026-09-30-n19/contract.md.
"""
import json, subprocess, sys, pathlib

WEB = pathlib.Path('/projects/sandbox/DataCare-Web/web')
TS = 'apps/api/src/modules/stock/tagSplit.ts'
TSR = 'apps/api/src/modules/stock/tagSplitRows.ts'
STOCK = 'apps/api/src/modules/stock/stock.ts'
TXN = 'apps/api/src/routes/txn.ts'
SEED = 'apps/api/src/modules/ops/seedCompany.ts'
POLICY = 'apps/api/src/modules/rbac/routePolicy.ts'
CORE_LINE = 'packages/core/src/tagSplitLine.ts'
WEB_LIB = 'apps/web/lib/tagSplitVoucher.ts'
UNIT = ['npx', 'vitest', 'run', 'test/tagSplitRows.test.ts']
LIFE = ['npx', 'vitest', 'run', 'test/tagSplitLifecycle.db.test.ts']
HTTP = ['npx', 'vitest', 'run', 'test/tagSplit.routes.db.test.ts']
IDENT = ['npx', 'vitest', 'run', 'test/tagSplitIdentity.db.test.ts']
PROV = ['npx', 'vitest', 'run', 'test/provisioning.db.test.ts']
CORE = ['npx', 'vitest', 'run', 'test/tagSplitLine.test.ts']
WEBT = ['npx', 'vitest', 'run', 'test/tagSplitVoucher.test.ts']
API_DIR = 'apps/api'
CORE_DIR = 'packages/core'
WEB_DIR = 'apps/web'

MUTATIONS = [
    # id, file, old, new, command[, cwd]
    # --- K1 book and mode ---
    ('book-other-main-book-accepted', TS,
     "  if (typedText(row.MAIN_BOOK) !== TAG_SPLIT_MAIN_BOOK) {", "  if (false) {",
     HTTP + ['-t', 'not in use']),
    ('book-not-in-use-accepted', TS,
     "  if (typedText(row.CUR_USE) !== 'Y') {", "  if (false) {", LIFE + ['-t', 'not in use']),
    # --- K2 identity, locks and conflict ---
    ('duplicate-parent-accepted', TS,
     "    if (seen.has(t)) throw new TagSplitValidationError(`${DESKTOP_MESSAGES.DUPLICATE_TAG}: ${t}`);",
     "    if (false) throw new TagSplitValidationError(`${DESKTOP_MESSAGES.DUPLICATE_TAG}: ${t}`);",
     LIFE + ['-t', 'V6']),
    ('shared-resolver-picks-first', STOCK,
     "  if (barRows.length > 1) throw new TagIdentityAmbiguousValidationError(key.TAG_NO);", "",
     IDENT + ['-t', 'ambiguous']),
    ('parent-location-not-isolated', STOCK,
     "    'b.\"LC_CODE\"::text=$2',", "    'true or b.\"LC_CODE\"::text=$2',",
     IDENT + ['-t', 'another location']),
    ('conflict-not-recognised', TS,
     "    code === 'P2034' ||\n    /\\b40P01\\b|\\b40001\\b|deadlock detected|could not serialize access/i.test(message)",
     "    false", HTTP + ['-t', 'deadlock']),
    ('conflict-not-409', TXN,
     "        n === 'TagCancelConflictError' ||\n        n === 'TagSplitConflictError'",
     "        n === 'TagCancelConflictError'", HTTP + ['-t', 'deadlock']),
    # --- K7 conservation ---
    ('short-split-without-account-accepted', TS,
     "  if (!acCode && !tagSplitConserves(parentNet, childNet)) {", "  if (false) {",
     LIFE + ['-t', 'V2']),
    # --- K8 register rows and stock ---
    ('stock-parent-sign-plus', TSR,
     "      TR_TYPE: 'O',\n      ITM_SIGN: '-',", "      TR_TYPE: 'O',\n      ITM_SIGN: '+',",
     LIFE + ['-t', 'V1:']),
    ('child-bar-keeps-itm-sign', TSR,
     "  const { ITM_SIGN: _sign, ...bar } = childReceiveRow(ctx, line);\n  return {\n    ...bar,",
     "  const bar = childReceiveRow(ctx, line);\n  return {\n    ...bar,", LIFE + ['-t', 'V1:']),
    # --- K8 diamond register (Dm_Tag_Split_Detl) ---
    ('dm-ignores-posting-flag', TSR,
     "      if (posts(stone.itCode)) dm(1, p.srNo, p, stone, '-', 'O');",
     "      dm(1, p.srNo, p, stone, '-', 'O');", LIFE + ['-t', 'V1:']),
    ('dm-parent-stone-items-absent', TS,
     "    ...writeParents.flatMap((p) => p.stones.map((s) => typedText(s.itCode ?? '', 5))),\n", "",
     LIFE + ['-t', 'V1:']),
    # --- K9 numbers, time and user on edit ---
    ('edit-new-hidden-number', TS,
     "    hiddenVoucherNo = persistedHidden;", "    hiddenVoucherNo = '';",
     HTTP + ['-t', 'hidden number across an edit']),
    ('edit-takes-acting-user', TS,
     "    mainUser = dbText(persisted.MAIN_USER);",
     "    mainUser = String(input.mainUser ?? '').trim().slice(0, 15);", HTTP + ['-t', 'lifecycle']),
    ('edit-resets-clock', TS,
     "    vchTime = voucherTimestamp(date, (persisted as { VCH_CLOCK?: unknown }).VCH_CLOCK);",
     "    vchTime = voucherTimestamp(date);", HTTP + ['-t', 'lifecycle']),
    # --- K10/K11 edit release and delete ---
    ('edit-does-not-release', TS,
     "    await deleteWriteSetTx(tx, scope, voucherNo, persistedHidden);\n", "",
     HTTP + ['-t', 'lifecycle']),
    ('delete-no-audit', TS,
     "      await insertRowTx(tx, 'DELETE_DATA', scope.tenantId, row);", "", LIFE + ['-t', 'V5']),
    ('delete-audit-fine-is-fine', TSR,
     "    VCH_FINE_CR: num(row.ITM_NWT),", "    VCH_FINE_CR: num(row.ITM_FINE),", LIFE + ['-t', 'V5']),
    ('delete-audit-main-book', TSR,
     "    BOOK_NAME: book.name.slice(0, 20),", "    BOOK_NAME: book.mainBook.slice(0, 20),",
     LIFE + ['-t', 'V5']),
    # --- K12 guards ---
    ('delete-ignores-lock-date', TS,
     "    await assertOpenTx(tx, scope, new Date(`${savedDate}T00:00:00.000Z`));\n", "",
     LIFE + ['-t', 'V9']),
    # --- K16 provisioning and rights ---
    ('seed-split-main-book', SEED,
     "    mainBook: 'TAG SPLIT',", "    mainBook: 'TAG SPLITT',", PROV + ['-t', 'Tag Split']),
    ('split-shares-cancel-right', POLICY,
     "route('Inventory/Tag Split', [", "route('Inventory/Tag Cancel', [", HTTP + ['-t', 'own right']),
    # --- core child arithmetic (CommPassTotal_Pr) ---
    ('core-net-not-less-forced', CORE_LINE,
     "  c.netWt = f3(n(c.grossWt) - n(c.lessWt));", "  c.netWt = f3(n(c.grossWt));", CORE, CORE_DIR),
    ('core-fine-without-ghat', CORE_LINE,
     "    purity !== 0 ? f3((n(c.netWt) + n(c.ghtWt)) * (purity / 100)) : f3(n(c.netWt) + n(c.ghtWt));",
     "    purity !== 0 ? f3(n(c.netWt) * (purity / 100)) : f3(n(c.netWt) + n(c.ghtWt));",
     CORE, CORE_DIR),
    ('core-stone-net-not-moved', CORE_LINE,
     "  if (netAmount !== 0) out.othAmt = f2(netAmount);", "", CORE, CORE_DIR),
    # --- the screen's model (lib/tagSplitVoucher.ts) ---
    ('web-conserves-inverted', WEB_LIB,
     "  return tagSplitConserves(parentNetTotal(parents), childTotals(children).netWt);",
     "  return !tagSplitConserves(parentNetTotal(parents), childTotals(children).netWt);", WEBT, WEB_DIR),
    ('web-duplicate-counts-own-row', WEB_LIB,
     "    rows.some((row, i) => i !== index && row.fromTag && row.tagNo.trim().toUpperCase() === wanted)",
     "    rows.some((row) => row.fromTag && row.tagNo.trim().toUpperCase() === wanted)", WEBT, WEB_DIR),
]

only = set(sys.argv[1:])
results = []
for spec in MUTATIONS:
    mid, rel, old, new, cmd = spec[:5]
    cwd = spec[5] if len(spec) > 5 else API_DIR
    if only and mid not in only:
        continue
    path = WEB / rel
    original = path.read_bytes()
    text = original.decode()
    if text.count(old) != 1:
        results.append({'id': mid, 'status': 'MUTATION-NOT-APPLIED', 'matches': text.count(old)})
        continue
    try:
        path.write_text(text.replace(old, new))
        proc = subprocess.run(cmd, cwd=WEB / cwd, capture_output=True, text=True, timeout=900)
        out = proc.stdout + proc.stderr
        failed = proc.returncode != 0
        results.append({'id': mid, 'file': rel, 'test': ' '.join(cmd[3:]),
                        'status': 'CAUGHT' if failed else 'SURVIVED', 'exit': proc.returncode,
                        'summary': [l.strip() for l in out.splitlines() if 'Tests ' in l or '×' in l][:4]})
    finally:
        path.write_bytes(original)
print(json.dumps(results, indent=1))
print('ALL_CAUGHT' if results and all(r['status'] == 'CAUGHT' for r in results) else 'NOT_ALL_CAUGHT')
