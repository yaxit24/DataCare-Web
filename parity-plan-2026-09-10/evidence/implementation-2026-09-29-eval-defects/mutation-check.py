#!/usr/bin/env python3
"""Temporary mutation checks for the evaluation-defect fixes (not committed).

Each mutation edits one source file, runs the focused test that should catch it, records whether the
test FAILED (the desired outcome), and restores the file byte-for-byte.
"""
import json, subprocess, sys, pathlib

WEB = pathlib.Path('/projects/sandbox/DataCare-Web/web')
MUTATIONS = [
    # id, file, old, new, cwd, command
    ('core-P-basis', 'packages/core/src/saleAmount.ts',
     "  if (code === 'P') return { quantity: pcs.toNumber(), rateDivisor: 1 };",
     "  if (code === 'P') return { quantity: weight.plus(ghat).toNumber(), rateDivisor: 1 };",
     'packages/core', ['npx', 'vitest', 'run', 'test/saleAmount.test.ts']),
    ('core-blank-is-fine', 'packages/core/src/saleAmount.ts',
     "  return saleRateWithCode(value) || 'N';",
     "  return saleRateWithCode(value) || 'F';",
     'packages/core', ['npx', 'vitest', 'run', 'test/saleAmount.test.ts']),
    ('loader-blank-sentinel', 'apps/api/src/modules/shared/settingsBehavior.ts',
     "saleAmountType: enumValue(values.SL_AMT_TYPE, 'SL_AMT_TYPE', ['N', 'G', 'F', 'P'], 'N'),",
     "saleAmountType: enumValue(values.SL_AMT_TYPE, 'SL_AMT_TYPE', ['N', 'G', 'F', 'P'], ''),",
     'apps/api', ['npx', 'vitest', 'run', 'test/sales.lifecycle.db.test.ts', '-t', 'D6-1']),
    ('writer-ignores-line-rtwith', 'apps/api/src/modules/sales/sales.ts',
     "      effectiveSaleRateWith(line.rateWith, amountType),",
     "      effectiveSaleRateWith('', amountType),",
     'apps/api', ['npx', 'vitest', 'run', 'test/sales.lifecycle.db.test.ts', '-t', 'D6-3']),
    ('finance-no-family-check', 'apps/api/src/modules/finance/finance.ts',
     "  if (!allowed) {\n    throw new FinanceValidationError(",
     "  if (false) {\n    throw new FinanceValidationError(",
     'apps/api', ['npx', 'vitest', 'run', 'test/financeBookFamily.db.test.ts', '-t', 'D1-5']),
    ('kasar-slot-1', 'apps/api/src/modules/finance/finance.ts',
     "  const account = await resolveBookSlotAccountTx(tx, scope, 'kasar', 2);",
     "  const account = await resolveBookSlotAccountTx(tx, scope, 'kasar', 1);",
     'apps/api', ['npx', 'vitest', 'run', 'test/financeBookFamily.db.test.ts', '-t', 'D1-3']),
    ('kasar-no-settlement-guard', 'apps/api/src/modules/finance/finance.ts',
     "  if (account === settlementAc) {",
     "  if (account === '__never__') {",
     'apps/api', ['npx', 'vitest', 'run', 'test/financeBookFamily.db.test.ts', '-t', 'D1-7']),
    ('seed-no-kasar-slot', 'apps/api/src/modules/ops/seedCompany.ts',
     "    slots: [\n      { srNo: 1, acCode: 'CASH' },\n      { srNo: 2, acCode: 'KASAR' },\n    ],\n  },\n  {\n    book: 'PAY',",
     "    slots: [\n      { srNo: 1, acCode: 'CASH' },\n      { srNo: 2, acCode: 'CASH' },\n    ],\n  },\n  {\n    book: 'PAY',",
     'apps/api', ['npx', 'vitest', 'run', 'test/financeBookSelection.routes.db.test.ts']),
    ('report-screen-missing', 'apps/api/src/routes/txn.ts',
     "  app.get('/reports/huid', auth, async (req) =>\n    REPORT_BUILDERS.huid(prisma, readScope(req), range(req)),\n  );\n",
     "",
     'apps/api', ['npx', 'vitest', 'run', 'test/reportScreens.routes.db.test.ts']),
    ('report-slug-unmapped', 'apps/api/src/modules/reports/reportAuthorization.ts',
     "  'balance-sheet': 'Reports/Balance Sheet',\n",
     "",
     'apps/api', ['npx', 'vitest', 'run', 'test/reportScreens.routes.db.test.ts', '-t', 'D4']),
    ('labour-type-unguarded', 'apps/api/src/modules/sales/sales.ts',
     "  if (line.labourType && !SALE_LABOUR_TYPES.has(line.labourType)) {",
     "  if (false) {",
     'apps/api', ['npx', 'vitest', 'run', 'test/saleAmountBasis.routes.db.test.ts', '-t', 'labour type']),
    ('tax-rate-unguarded', 'apps/api/src/modules/sales/salesReturn.ts',
     "  assertSaleTaxRate(input.taxRatePct);\n  const salesAc",
     "  const salesAc",
     'apps/api', ['npx', 'vitest', 'run', 'test/saleAmountBasis.routes.db.test.ts', '-t', 'tax rate']),
    ('web-slug-strips-digits', 'apps/web/lib/reportSlug.ts',
     "replace(/[^a-z0-9-]/g, '')",
     "replace(/[^a-z-]/g, '')",
     'apps/web', ['npx', 'vitest', 'run', 'test/reportSlug.test.ts']),
    ('web-preview-old-basis', 'apps/web/lib/lineRecalc.ts',
     "    effectiveSaleRateWith(line.rateWith, options.saleAmountType),",
     "    effectiveSaleRateWith(line.rateWith, 'F'),",
     'apps/web', ['npx', 'vitest', 'run', 'test/lineRecalc.test.ts']),
    ('web-settings-bare-key', 'apps/web/lib/companySettings.ts',
     "  for (const table of ['CO_SET', 'CO_SET_NEW']) {",
     "  for (const table of [] as string[]) {",
     'apps/web', ['npx', 'vitest', 'run', 'test/financeBooks.test.ts']),
]

only = set(sys.argv[1:])
results = []
for mid, rel, old, new, cwd, cmd in MUTATIONS:
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
        # Core consumers read the built package, so rebuild core for core mutations.
        if rel.startswith('packages/core') and cwd != 'packages/core':
            subprocess.run(['pnpm', 'build'], cwd=WEB / 'packages/core', capture_output=True)
        proc = subprocess.run(cmd, cwd=WEB / cwd, capture_output=True, text=True, timeout=900)
        out = proc.stdout + proc.stderr
        failed = proc.returncode != 0
        results.append({'id': mid, 'status': 'CAUGHT' if failed else 'SURVIVED',
                        'exit': proc.returncode,
                        'summary': [l.strip() for l in out.splitlines() if 'Tests ' in l or '×' in l][:4]})
    finally:
        path.write_bytes(original)
print(json.dumps(results, indent=1))
print('ALL_CAUGHT' if results and all(r['status'] == 'CAUGHT' for r in results) else 'NOT_ALL_CAUGHT')
