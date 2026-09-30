#!/usr/bin/env python3
"""Mutation checks for X16 (wholesale sale / rate cut stock and money legs).

Each mutation edits one source file, runs the focused test that should catch it, records whether the
test FAILED (the desired outcome), and restores the file byte-for-byte. Run through local-test-env so the
database-backed tests are enabled. Core mutations run the core unit tests from source (packages/core), since
the API imports core's built dist.
"""
import json, subprocess, sys, pathlib

# parity-plan-2026-09-10/evidence/implementation-2026-09-29-x16/mutation-check.py → the repository's web/.
WEB = pathlib.Path(__file__).resolve().parents[3] / 'web'
RC = 'apps/api/src/modules/sales/rateCut.ts'
CORE_LINE = 'packages/core/src/wholesaleLine.ts'
LOOKUP = 'apps/api/src/modules/masters/lookup.ts'
UNIT = ['npx', 'vitest', 'run', 'test/rateCut.test.ts']
DB = ['npx', 'vitest', 'run', 'test/wholesaleRateCutStock.db.test.ts']
SETTLE = ['npx', 'vitest', 'run', 'test/rateCutSettlement.db.test.ts']
HTTP = ['npx', 'vitest', 'run', 'test/wholesaleRateCut.routes.db.test.ts']
CORE = ['npx', 'vitest', 'run', 'test/wholesaleLine.test.ts']
API_DIR = 'apps/api'
CORE_DIR = 'packages/core'
MUTATIONS = [
    # id, file, old, new, command[, cwd]
    ('legs-positional', RC,
     "      ...row,\n      legType,\n    } as LedgerLine);",
     "      ...row,\n    } as LedgerLine);", UNIT),
    ('fine-rate-on-every-leg', RC,
     "      FINE_WT: 0,\n      FINE_RATE: 0,\n      DR_AMT: 0,",
     "      FINE_WT: 0,\n      FINE_RATE: f.fineRate,\n      DR_AMT: 0,", UNIT),
    ('settlement-without-fine-rate', RC,
     "      fineRate: input.fineRate,\n      drAmt: input.settleDrAmt,",
     "      drAmt: input.settleDrAmt,", DB + ['-t', 'V2']),
    # TOT_FINE_CR = PR_FINE + CR_FINE is now computed by the core band; the API feeds it the received fine.
    ('tot-fine-cr-omits-received', RC,
     "    received: { fine: figures.prFine, netAmount: receivedNet },",
     "    received: { fine: 0, netAmount: receivedNet },", UNIT),
    ('sale-kasar-old-direction', RC,
     "  if (f.slKasarAmt > 0) pair(47, 48, slot('kasarAc'), 'CR', f.slKasarAmt);",
     "  if (f.slKasarAmt > 0) pair(47, 48, slot('kasarAc'), 'DR', f.slKasarAmt);", UNIT),
    ('no-stock-rows', RC,
     "    const stockRows = movesStock\n      ? buildStockRows(rowCtx, issuedRows, receivedRows, settings.oldGoldType)\n      : [];",
     "    const stockRows: Record<string, unknown>[] = [];", DB + ['-t', 'V1']),
    ('no-tag-reservation', RC,
     "    const tags = movesStock\n      ? await reserveIssuedTagsTx(tx, key, issuedInput)\n      : issuedInput.map(() => undefined);",
     "    const tags = issuedInput.map(() => undefined as ResolvedTagIdentity | undefined);",
     DB + ['-t', 'W1']),
    ('tag-stock-not-restored-on-delete', RC,
     "    for (const tag of restores) await restoreTagTx(tx, tenantId, tag);\n    return { reversed: true };",
     "    return { reversed: true };", DB + ['-t', 'TAG_STOCK-only']),
    ('duplicate-tag-accepted', RC,
     "    if (reserved.has(instance)) {",
     "    if (false) {", DB + ['-t', 'W1']),
    ('guard-accepts-any-book', RC,
     "  if (mainBook !== WORKFLOW_MAIN_BOOK[guard]) {",
     "  if (false) {", DB + ['-t', 'W9']),
    ('header-only-refused', RC,
     "  if (!issuedInput.length && !receivedInput.length && !settles) {",
     "  if (!issuedInput.length && !receivedInput.length) {", DB + ['-t', 'V6']),
    ('contra-legs-carry-party', RC,
     "      partyAc: customer,\n", "", DB + ['-t', 'V2']),
    ('bill-os-from-request', RC,
     "    SL_BILL_OS: headerTotals.slBillOs,",
     "    SL_BILL_OS: round0(num(p.billOs)),", DB + ['-t', 'V3']),
    ('received-hallmark-weight-gross', RC,
     "      HM_ID_WT: 0,\n      HM_ID2_WT: 0,",
     "      HM_ID_WT: num(l.grossWt),\n      HM_ID2_WT: 0,", DB + ['-t', 'V2']),
    # Was `TOT_AMT: wholesale ? 0 : c.totAmt` in rateCut.ts; the rule moved into the core issue-line math.
    ('wholesale-tot-amt-computed', CORE_LINE,
     "    otherAmountInFine: n(input.otherRate) !== 0 ? otherAmount : 0,\n    totalAmount: 0,",
     "    otherAmountInFine: n(input.otherRate) !== 0 ? otherAmount : 0,\n    totalAmount: netAmount,",
     CORE, CORE_DIR),
    ('issued-tot-amt-is-net', RC,
     "      TOT_AMT: c.totAmt,\n      TAX_PRC: num(l.taxPct),\n      NET_AMT: c.netAmt,\n      RATE_TYPE: l.rateType ?? 'G',\n      IT_TYPE: c.itType,\n      HD_VCH_NO",
     "      TOT_AMT: c.netAmt,\n      TAX_PRC: num(l.taxPct),\n      NET_AMT: c.netAmt,\n      RATE_TYPE: l.rateType ?? 'G',\n      IT_TYPE: c.itType,\n      HD_VCH_NO",
     DB + ['-t', 'V4']),
    ('stock-received-kr-from-kr', RC,
     "      KR_NWT: num(row.ITM_NWT),",
     "      KR_NWT: num(row.KR_NET_WT),", DB + ['-t', 'V2']),
    ('tag-defaults-ignored', RC,
     "    if (!hasValue(line.karigarName) && text(tag.KR_NAME)) out.karigarName = text(tag.KR_NAME);",
     "", DB + ['-t', 'V1']),
    ('delete-audit-main-book', RC,
     "          BOOK_NAME: text(classification.configured ? classification.displayName : '', 20),",
     "          BOOK_NAME: text(classification.bookName, 20),", DB + ['-t', 'W3/W2']),
    ('trade-fine-ignored', RC,
     "    tradeFine: String(row?.trad_fine ?? '') === 'Y',",
     "    tradeFine: false,", DB + ['-t', 'W5']),
    ('rojmel-fed-line-fine', RC,
     "        drFine: figures.drFine,\n        crFine: figures.crFine,\n        purchaseBillOs:",
     "        drFine: figures.prFine,\n        crFine: figures.slFine,\n        purchaseBillOs:", DB + ['-t', 'V6']),
    ('return-counts-signs', 'apps/api/src/modules/sales/wholesaleSaleReturn.ts',
     "  } else if (!lastIs(source.CO_YEAR, source.CO_BOOK, source.VCH_NO, '-')) {",
     "  } else if (!lastIs(source.CO_YEAR, source.CO_BOOK, source.VCH_NO, '+')) {", DB + ['-t', 'W8']),
    ('returned-tag-ambiguous', 'apps/api/src/modules/stock/stock.ts',
     "    `SELECT DISTINCT ON (coalesce(b.\"VCH_SRNO\",0),coalesce(b.\"IT_CODE\"::text,''))\n            b.\"CO_CODE\"",
     "    `SELECT b.\"CO_CODE\"", DB + ['-t', 'W8']),
    ('seed-wrong-main-book', 'apps/api/src/modules/ops/seedCompany.ts',
     "    mainBook: 'WH SALES',", "    mainBook: 'WH SALE',", HTTP),
    ('wholesale-rights-shared', 'apps/api/src/modules/rbac/routePolicy.ts',
     "route('Sales/Wholesale Sale', [", "route('Cash / Bank/Rate Cut (price fixing)', [", HTTP),
    # --- Round 2: the TR_WH_SALE grid arithmetic (core), its wiring, the picker and the party defaults ---
    ('core-less-weight-ignored', CORE_LINE,
     "  else fine = format3(((netWt + ghtWt) * pct) / 100 - lessWt + hallmarkFine);",
     "  else fine = format3(((netWt + ghtWt) * pct) / 100 + hallmarkFine);", CORE, CORE_DIR),
    ('core-net-labour-without-ghat', CORE_LINE,
     "        ? mathRound0((netWt + ghtWt) * rate)\n        : mathRound0(netWt * rate);",
     "        ? mathRound0(netWt * rate)\n        : mathRound0(netWt * rate);", CORE, CORE_DIR),
    ('core-kg-labour-basis-inverted', CORE_LINE,
     "      return code(settings.companyLabourType) === 'G'",
     "      return code(settings.companyLabourType) !== 'G'", CORE, CORE_DIR),
    ('core-priced-line-fine-counted', CORE_LINE,
     "    fine: format3(sum((line) => (line.itemAmount === 0 ? line.fine : 0) + line.otherFine)),",
     "    fine: format3(sum((line) => line.fine + line.otherFine)),", CORE, CORE_DIR),
    ('core-conversion-ignored', CORE_LINE,
     "  if (convRate !== 0 && convPct !== 0) return roundHalfEven((convRate / convPct) * 100, 2);\n",
     "", CORE, CORE_DIR),
    ('core-receive-less-touch-ignored', CORE_LINE,
     "(touchPlusWest - n(input.lessTouch))", "(touchPlusWest)", CORE, CORE_DIR),
    ('core-other-fine-stays-in-money', CORE_LINE,
     "    netAmount: format2(sum((line) => line.netAmount) - inFine),",
     "    netAmount: format2(sum((line) => line.netAmount)),", CORE, CORE_DIR),
    ('core-receive-tax-not-backed-out', CORE_LINE,
     "  const taxPct = n(input.taxPct);", "  const taxPct = 0 * n(input.taxPct);", CORE, CORE_DIR),
    ('core-stored-fine-ignored', CORE_LINE,
     "  if (input.fine != null && hallmarkFine === 0) fine = format3(n(input.fine));",
     "  if (false) fine = format3(n(input.fine));", CORE, CORE_DIR),
    ('core-money-half-up', CORE_LINE,
     "const mathRound0 = (x: number): number => roundHalfEven(x, 0);",
     "const mathRound0 = (x: number): number => round(x, 0);", CORE, CORE_DIR),
    ('wholesale-line-math-off', RC,
     "    const lineMath: LineMath =\n      workflow === 'wholesale'",
     "    const lineMath: LineMath =\n      workflow === ('none' as string)", DB + ['-t', 'a tag brings its labour']),
    ('fine-rate-line-fallback', RC,
     "      fineRate: settlement.fineRate,\n      drAmt: settlement.drAmt,",
     "      fineRate: settlement.fineRate || totals.rate,\n      drAmt: settlement.drAmt,",
     SETTLE + ['-t', 'FINE_RATE the header rate']),
    ('party-mobile-not-defaulted', RC,
     "      mobile: hasValue(input.mobile) ? input.mobile : (party?.mobile ?? input.mobile),",
     "      mobile: input.mobile,", DB + ['-t', 'a tag brings its labour']),
    ('tag-stored-fine-not-copied', RC,
     "      out.fine = num(tag.ITM_FINE);\n", "", DB + ['-t', 'a tag brings its labour']),
    ('tag-labour-rate-not-copied', RC,
     "    if (line.lbrRate == null && tag.LBR_RATE != null) out.lbrRate = num(tag.LBR_RATE);\n", "",
     DB + ['-t', 'a tag brings its labour']),
    ('available-tags-lists-sold', LOOKUP,
     "            AND ${barTagAvailableSql('b')}\n          ORDER BY b.\"TAG_NO\"",
     "          ORDER BY b.\"TAG_NO\"", DB + ['-t', 'tag picker']),
    ('available-tags-any-location', LOOKUP,
     "WHERE b.tenant_id=$1 AND b.\"CO_CODE\"=$2 AND ($3::text='' OR b.\"LC_CODE\"=$3)",
     "WHERE b.tenant_id=$1 AND b.\"CO_CODE\"=$2 AND ($3::text<>'' OR b.\"LC_CODE\"=$3)", DB + ['-t', 'tag picker']),
    ('available-tags-no-web-tags', LOOKUP,
     "SELECT * FROM (SELECT * FROM bar UNION ALL SELECT * FROM web) t",
     "SELECT * FROM (SELECT * FROM bar) t", DB + ['-t', 'tag picker']),
    # --- Round 3: the settlement band, tender paise, labour basis, typed ghat weight, instance labels ---
    ('band-net-half-up', CORE_LINE,
     "  const receivedNet = mathRound0(n(input.settlement.drAmt) + n(input.issued.netAmount));",
     "  const receivedNet = round(n(input.settlement.drAmt) + n(input.issued.netAmount), 0);", CORE, CORE_DIR),
    ('band-os-omits-kasar', CORE_LINE,
     "    paymentNet - payment.cash - payment.cheque - payment.card - payment.kasar,",
     "    paymentNet - payment.cash - payment.cheque - payment.card,", CORE, CORE_DIR),
    ('band-diff-side-inverted', CORE_LINE,
     "    paymentOs > receivedOs ? 'Pay' : paymentOs < receivedOs ? 'Rec' : '';",
     "    paymentOs > receivedOs ? 'Rec' : paymentOs < receivedOs ? 'Pay' : '';", CORE, CORE_DIR),
    ('band-tot-fine-omits-settled', CORE_LINE,
     "  const totFineCr = format3(n(input.received.fine) + n(input.settlement.crFine));",
     "  const totFineCr = format3(n(input.received.fine));", CORE, CORE_DIR),
    ('core-ghat-weight-ignored', CORE_LINE,
     "    input.ghtWt != null ? format3(n(input.ghtWt)) : format3((netWt * n(input.ghtPct)) / 100);",
     "    format3((netWt * n(input.ghtPct)) / 100);", CORE, CORE_DIR),
    ('tender-rounded-to-rupees', RC,
     "      slCashAmt: money2(p.cash),", "      slCashAmt: round0(num(p.cash)),", DB + ['-t', 'paise']),
    ('kasar-rounded-to-rupees', RC,
     "      slKasarAmt: money2(p.kasar),", "      slKasarAmt: round0(num(p.kasar)),", DB + ['-t', 'paise']),
    ('company-labour-basis-ignored', RC,
     "      workflow === 'wholesale' && line.lbrType == null",
     "      false && line.lbrType == null", DB + ['-t', 'company basis']),
    ('typed-ghat-weight-ignored', RC,
     "      ghtWt: hasValue(l.ghtWt) ? Number(l.ghtWt) : undefined,",
     "      ghtWt: undefined,", DB + ['-t', 'company basis']),
    ('ambiguous-instances-unlabelled', LOOKUP,
     "        name: ambiguous ? `${name} · #${serialText(row.VCH_SRNO)}` : name,",
     "        name,", DB + ['-t', 'shared tag number']),
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
