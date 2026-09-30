#!/usr/bin/env python3
"""Mutation checks for N18 (Tag Cancel X19 / Tag Transfer X18, desktop TR_TAG_CAN).

Each mutation edits one source file to break one contract clause, runs the focused test that should catch it,
records whether the test FAILED (the desired outcome), and restores the file byte-for-byte. Run through the local
test environment so the database-backed tests are enabled:

    /projects/local-test-env.sh python3 mutation-check.py [mutation-id ...]

API tests import `@datacare/core` from its built dist, so core mutations run the core unit tests from source
(packages/core); web-model mutations run the web unit tests (apps/web).
"""
import json, subprocess, sys, pathlib

WEB = pathlib.Path('/projects/sandbox/DataCare-Web/web')
TC = 'apps/api/src/modules/stock/tagCancel.ts'
TCR = 'apps/api/src/modules/stock/tagCancelRows.ts'
STOCK = 'apps/api/src/modules/stock/stock.ts'
TXN = 'apps/api/src/routes/txn.ts'
SEED = 'apps/api/src/modules/ops/seedCompany.ts'
POLICY = 'apps/api/src/modules/rbac/routePolicy.ts'
CORE_LINE = 'packages/core/src/tagCancelLine.ts'
WEB_LIB = 'apps/web/lib/tagCancelVoucher.ts'
UNIT = ['npx', 'vitest', 'run', 'test/tagCancelRows.test.ts']
LIFE = ['npx', 'vitest', 'run', 'test/tagCancelLifecycle.db.test.ts']
HTTP = ['npx', 'vitest', 'run', 'test/tagCancel.routes.db.test.ts']
PROV = ['npx', 'vitest', 'run', 'test/provisioning.db.test.ts']
CORE = ['npx', 'vitest', 'run', 'test/tagCancelLine.test.ts']
WEBT = ['npx', 'vitest', 'run', 'test/tagCancelVoucher.test.ts']
API_DIR = 'apps/api'
CORE_DIR = 'packages/core'
WEB_DIR = 'apps/web'

MUTATIONS = [
    # id, file, old, new, command[, cwd]
    # --- K1 book and mode ---
    ('book-other-mode-accepted', TC,
     "  if (mainBook !== expected) {", "  if (false) {", LIFE + ['-t', 'V12']),
    ('book-not-in-use-accepted', TC,
     "  if (typedText(row.CUR_USE) !== 'Y') {", "  if (false) {", LIFE + ['-t', 'V12']),
    ('stock-data-type-blank', TC,
     "    dataType: dbText(row.DATA_TYPE).trim().slice(0, 1) || 'A',",
     "    dataType: dbText(row.DATA_TYPE).trim().slice(0, 1),", LIFE + ['-t', 'V1:']),
    # --- K2 identity and locks ---
    ('duplicate-tag-accepted', TC,
     "    if (seen.has(tagNo)) {", "    if (false) {", LIFE + ['-t', 'V5']),
    ('shared-resolver-picks-first', STOCK,
     "  if (barRows.length > 1) throw new TagIdentityAmbiguousValidationError(key.TAG_NO);", "",
     LIFE + ['-t', 'V4']),
    ('tag-locks-unsorted', TC,
     "  const sorted = [...new Set([...tagNos].filter(Boolean))].sort();",
     "  const sorted = [...new Set([...tagNos].filter(Boolean))];", LIFE + ['-t', 'sorted order']),
    ('tags-not-pre-locked', TC,
     "  const sorted = [...new Set([...tagNos].filter(Boolean))].sort();",
     "  const sorted: string[] = [];", LIFE + ['-t', 'sorted order']),
    ('conflict-not-recognised', TC,
     "    code === 'P2034' ||\n    /\\b40P01\\b|\\b40001\\b|deadlock detected|could not serialize access/i.test(message)",
     "    false", HTTP + ['-t', 'deadlock']),
    ('conflict-not-409', TXN,
     "        n === 'EBillConflictError' ||\n        n === 'TagCancelConflictError'",
     "        n === 'EBillConflictError'", HTTP + ['-t', 'deadlock']),
    # --- K3 tag fill ---
    ('kr-net-three-places', TCR,
     "    krNetWt: f2(source.KR_NET_WT),", "    krNetWt: f3(source.KR_NET_WT),", UNIT),
    ('karigar-purity-not-taken', TCR,
     "  const karigarPurity = touch === 0;", "  const karigarPurity = false;", UNIT),
    # --- K4 the operator's edits ---
    ('given-cells-not-stored', TCR,
     "    if (given(value)) cells = { ...cells, [step.field]: step.format(value) };", "", UNIT),
    ('unchanged-cell-is-an-edit', TCR,
     "      if (next !== num(cells[step.field])) {", "      if (true) {", UNIT),
    ('readonly-pcs-accepted', TCR,
     "    if (given(input.pcs) && f0(input.pcs) !== f0(base.pcs)) refuse('Pcs comes from the tag');", "", UNIT),
    ('transfer-labour-refused-again', TCR,
     "  { field: 'mrp', label: 'Mrp', format: f2 },\n];",
     "  { field: 'mrp', label: 'Mrp', format: f2 },\n  { field: 'lbrAmt' as 'mrp', label: 'LbrAmt', format: f2 },\n];",
     UNIT),
    ('stone-effect-skipped', TCR,
     "    if (step.field === 'grossWt' && options.stonesGiven) {", "    if (false) {", UNIT),
    # --- K5 stones ---
    ('stones-every-bar-row', TC,
     "        AND s.\"CO_YEAR\" IS NOT DISTINCT FROM $4 AND s.\"CO_BOOK\" IS NOT DISTINCT FROM $5\n"
     "        AND s.\"VCH_NO\" IS NOT DISTINCT FROM $6\n"
     "        AND coalesce(s.\"SR_NO\",0)::numeric=$7::numeric AND s.\"TAG_NO\"=$8",
     "        AND ($4::text IS NULL OR true) AND ($5::text IS NULL OR true)\n"
     "        AND ($6::text IS NULL OR true)\n"
     "        AND ($7::numeric IS NULL OR true) AND s.\"TAG_NO\"=$8"
     "\n        AND coalesce(s.\"VCH_SRNO\",0)::numeric=(SELECT coalesce(b.\"VCH_SRNO\",0)::numeric FROM \"BAR_DETL\" b"
     " WHERE b.tenant_id=s.tenant_id AND b.\"TAG_NO\"=s.\"TAG_NO\" ORDER BY b.row_id LIMIT 1)",
     LIFE + ['-t', 'V11']),
    ('kept-line-loses-stones', TC,
     "sourceStones = sameTag ? (saved!.stonesByLine.get(num(kept!.OLD_SRNO)) ?? []) : source.stones;",
     "sourceStones = sameTag ? [] : source.stones;", LIFE + ['-t', 'V2']),
    ('loose-line-stones-accepted', TC,
     "    if (!tagged && givenStones.length) {", "    if (false) {",
     LIFE + ['-t', 'refuses what the desktop grid']),
    ('empty-stones-saved', TCR,
     "  num(stone.pcs) + num(stone.grossWt) + num(stone.netAmount) !== 0;", "  true;", UNIT),
    # --- K6 register rows ---
    ('trfr-item-in-cancel', TCR,
     "    ...(ctx.mode === 'transfer' ? { TRFR_IT_CODE: c.trfrItCode } : {}),",
     "    TRFR_IT_CODE: c.trfrItCode,", UNIT),
    ('web-extra-column-written', TCR,
     "    DESIGN_IMG_ID: c.designImageId,\n  };\n}",
     "    DESIGN_IMG_ID: c.designImageId,\n    HM_ID: 'HUID5CD',\n  };\n}", LIFE + ['-t', 'V1:']),
    ('loose-tag-not-n', TCR,
     "    TAG_NO: isLoose(c.tagNo) ? 'N' : c.tagNo,\n    TBL_CODE: c.tblCode,",
     "    TAG_NO: c.tagNo,\n    TBL_CODE: c.tblCode,", LIFE + ['-t', 'V1:']),
    ('non-qualifying-tag-skipped', TC,
     "    if (!qualifies && tagged) {", "    if (false) {", LIFE + ['-t', 'refuses what the desktop grid']),
    # --- K7 stock ---
    ('stock-sign-plus', TCR,
     "    TR_TYPE: 'O',\n    ITM_SIGN: '-',", "    TR_TYPE: 'O',\n    ITM_SIGN: '+',", LIFE + ['-t', 'V1:']),
    ('transfer-plus-row-missing', TCR,
     "  if (ctx.mode === 'transfer') {\n    for (const d of details) {",
     "  if (false) {\n    for (const d of details) {", LIFE + ['-t', 'T1']),
    ('transfer-plus-row-keeps-labour', TCR,
     "        LBR_RATE: 0,\n        LBR_AMT: 0,\n        OTH_AMT: 0,",
     "        LBR_RATE: 0,\n        LBR_AMT: d.LBR_AMT,\n        OTH_AMT: 0,", LIFE + ['-t', 'T1']),
    ('transfer-plus-row-keeps-tag', TCR,
     "        TAG_NO: 'N',\n        VCH_SRNO: 0,", "        TAG_NO: d.TAG_NO,\n        VCH_SRNO: 0,", LIFE + ['-t', 'T1']),
    # --- K8 diamond register ---
    ('dm-data-in-transfer', TCR,
     "  if (ctx.mode !== 'cancel') return [];", "", LIFE + ['-t', 'T1']),
    ('dm-data-ignores-posting-flag', TCR,
     "      if (!items.get(stone.itCode.trim().toUpperCase())?.postsDiamonds) continue;", "",
     LIFE + ['-t', 'V1:']),
    # --- K9 numbers, time and user ---
    ('edit-new-hidden-number', TC,
     "    hiddenVoucherNo = persistedHidden;", "    hiddenVoucherNo = '';", LIFE + ['-t', 'hidden number']),
    ('edit-takes-acting-user', TC,
     "    mainUser = dbText(persisted.MAIN_USER);",
     "    mainUser = String(input.mainUser ?? '').trim().slice(0, 15);", LIFE + ['-t', 'V2']),
    ('edit-resets-clock', TC,
     "    vchTime = voucherTimestamp(date, persisted.VCH_CLOCK);", "    vchTime = voucherTimestamp(date);",
     LIFE + ['-t', 'V2']),
    ('kept-line-renumbered', TC,
     "    const oldSrNo = kept ? num(kept.OLD_SRNO) : saved ? ++nextOld : srNo;",
     "    const oldSrNo = srNo;", LIFE + ['-t', 'V2']),
    # --- K10/K11 edit release and delete ---
    ('edit-does-not-release', TC,
     "    await deleteWriteSetTx(tx, scope, voucherNo, persistedHidden);\n", "", LIFE + ['-t', 'V2']),
    ('delete-no-audit', TC,
     "      await insertRowTx(tx, 'DELETE_DATA', scope.tenantId, row);", "", LIFE + ['-t', 'V3']),
    ('delete-audit-fine-is-fine', TCR,
     "    VCH_FINE_CR: num(row.ITM_NWT),", "    VCH_FINE_CR: num(row.ITM_FINE),", UNIT),
    ('delete-audit-main-book', TCR,
     "    BOOK_NAME: book.name.slice(0, 20),", "    BOOK_NAME: book.mainBook.slice(0, 20),", UNIT),
    ('delete-keeps-hidden-number', TC,
     "  if (hiddenVoucherNo) {\n    await tx.$executeRawUnsafe(\n      `DELETE FROM \"TEMP_BOOK_DATA\"",
     "  if (false) {\n    await tx.$executeRawUnsafe(\n      `DELETE FROM \"TEMP_BOOK_DATA\"", LIFE + ['-t', 'V3']),
    ('tag-stock-not-restored', TC,
     "    for (const restore of restores) await restoreTagTx(tx, scope.tenantId, restore);\n    return {",
     "    return {", LIFE + ['-t', 'V10']),
    # --- K12/K13 guards ---
    ('delete-ignores-lock-date', TC,
     "    await assertOpenTx(tx, scope, new Date(`${savedDate}T00:00:00.000Z`));\n", "", LIFE + ['-t', 'V9']),
    ('transfer-item-optional', TC,
     "      if (!trfrItCode) {\n        throw new TagCancelValidationError(`row ${row}: enter the transfer item (TrfrItm)`);",
     "      if (false) {\n        throw new TagCancelValidationError(`row ${row}: enter the transfer item (TrfrItm)`);",
     LIFE + ['-t', 'T2']),
    # --- K16 provisioning and rights ---
    ('seed-transfer-main-book', SEED,
     "    mainBook: 'TAG TRFR',", "    mainBook: 'TAG TRANSFER',", PROV),
    ('transfer-shares-cancel-right', POLICY,
     "route('Inventory/Tag Transfer', [", "route('Inventory/Tag Cancel', [", HTTP + ['-t', 'own right']),
    # --- core arithmetic (CommPassTotal / CommPassTotal_Idtl / MSG_TOT_FILL / the save filter) ---
    ('core-less-not-forced', CORE_LINE,
     "  if (n(c.lessWt) !== 0 && n(c.grossWt) !== 0) c.netWt = f3(n(c.grossWt) - n(c.lessWt));", "",
     CORE, CORE_DIR),
    ('core-fine-without-ghat', CORE_LINE,
     "  const purityFine = () => f3(((n(c.netWt) + n(c.ghtWt)) * (n(c.touch) + n(c.westPct))) / 100);",
     "  const purityFine = () => f3((n(c.netWt) * (n(c.touch) + n(c.westPct))) / 100);", CORE, CORE_DIR),
    ('core-labour-ignores-lbr-with-ght', CORE_LINE,
     "        c.lbrAmt = settings.labourIncludesGhat\n          ? r0((n(c.netWt) + n(c.ghtWt)) * lbrRate)\n          : r0(n(c.netWt) * lbrRate);",
     "        c.lbrAmt = r0((n(c.netWt) + n(c.ghtWt)) * lbrRate);", CORE, CORE_DIR),
    ('core-money-half-up', CORE_LINE,
     "const r0 = (x: number): number => roundHalfEven(x, 0);",
     "const r0 = (x: number): number => round(x, 0);", CORE, CORE_DIR),
    ('core-tag-row-copies-karigar', CORE_LINE,
     "  if (!c.tagged) {\n    c.krNetWt = f3(n(c.netWt));", "  if (true) {\n    c.krNetWt = f3(n(c.netWt));",
     CORE, CORE_DIR),
    ('core-unchanged-gross-recomputes', CORE_LINE,
     "  if (changed3(c.grossWt, b.grossWt)) {\n    b.grossWt = f3(n(c.grossWt));",
     "  if (true) {\n    b.grossWt = f3(n(c.grossWt));", CORE, CORE_DIR),
    ('core-stone-p-by-weight', CORE_LINE,
     "  } else if (perPiece === 'P' && roundHalfEven(rate, 0) !== 0) {\n    s.amount = f2(rate * n(s.pcs));",
     "  } else if (perPiece === 'P' && roundHalfEven(rate, 0) !== 0) {\n    s.amount = f2(rate * n(s.grossWt));",
     CORE, CORE_DIR),
    ('core-stones-other-amount-ignored', CORE_LINE,
     "  if (netAmount !== 0) out.othAmt = f2(netAmount);", "", CORE, CORE_DIR),
    ('core-mrp-line-not-written', CORE_LINE,
     "  if (named && n(row.mrp) !== 0) return true;", "", CORE, CORE_DIR),
    # --- the screen's model (lib/tagCancelVoucher.ts) ---
    ('web-pcs-recomputes', WEB_LIB,
     "  if (field === 'pcs') return formatted;\n", "", WEBT, WEB_DIR),
    ('web-stones-always-sent', WEB_LIB,
     "  if (row.stonesEdited) {\n    line.stones", "  if (true) {\n    line.stones", WEBT, WEB_DIR),
    ('web-no-transfer-copy', WEB_LIB,
     "      ? withPreviousTransfer(next, rows[i - 1], mode)\n      : next;",
     "      ? next\n      : next;", WEBT, WEB_DIR),
    ('web-duplicate-counts-own-row', WEB_LIB,
     "    rows.some((row, i) => i !== index && row.fromTag && row.tagNo.trim().toUpperCase() === wanted)",
     "    rows.some((row) => row.fromTag && row.tagNo.trim().toUpperCase() === wanted)", WEBT, WEB_DIR),
    ('web-retyped-tag-counts-as-resolved', WEB_LIB,
     "  row.tagNo.trim() !== '' && row.tagNo.trim() !== row.filledTag;", "  false;", WEBT, WEB_DIR),
    ('web-baseline-not-loaded', WEB_LIB,
     "  row.baseline = baselineFromCells({\n    grossWt: n(row.grossWt),",
     "  row.baseline = baselineFromCells(null) ?? ({\n    grossWt: n(row.grossWt),", WEBT, WEB_DIR),
    ('web-payload-omits-karigar-fine', WEB_LIB,
     "    krFine: n(row.krFine),\n  };\n  if (mode === 'transfer')", "  };\n  if (mode === 'transfer')", WEBT, WEB_DIR),
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
