import { readFileSync, readdirSync, statSync } from 'node:fs';
import { join, relative } from 'node:path';
import { describe, expect, it } from 'vitest';

const webRoot = join(__dirname, '..');
const sourceRoots = ['app', 'components', 'lib'];

function sourceFiles(dir: string): Array<{ path: string; text: string }> {
  const full = join(webRoot, dir);
  return readdirSync(full).flatMap((entry) => {
    const child = join(full, entry);
    if (statSync(child).isDirectory()) return sourceFiles(relative(webRoot, child));
    return /\.tsx?$/.test(entry)
      ? [{ path: relative(webRoot, child), text: readFileSync(child, 'utf8') }]
      : [];
  });
}

const files = sourceRoots.flatMap(sourceFiles);
const displayOwners: Record<string, number> = {
  'components/EBillEntry.tsx': 1,
  'components/RateTicker.tsx': 1,
  'components/SaleReturnSavedPanel.tsx': 2,
  'components/TagCancelForm.tsx': 1,
  'components/TagSplitForm.tsx': 1,
  'app/(app)/masters/year-create/page.tsx': 6,
  'app/(app)/reports/karigar-ledger/page.tsx': 1,
  'app/(app)/reports/tag-stock/page.tsx': 1,
  'app/(app)/reports/voucher-register/page.tsx': 1,
  'app/(app)/txn/bank-recon/page.tsx': 2,
  'app/(app)/txn/consi-purchase/page.tsx': 1,
  'app/(app)/txn/daily-rate/page.tsx': 3,
  'app/(app)/txn/e-crnt-note/page.tsx': 1,
  'app/(app)/txn/e-invoice/page.tsx': 1,
  'app/(app)/txn/order-cancel/page.tsx': 2,
  'app/(app)/txn/reminders/page.tsx': 1,
  'app/(app)/txn/repair-karigar-issue/page.tsx': 1,
  'app/(app)/txn/sales-order/page.tsx': 1,
  'app/(app)/txn/tour-order/page.tsx': 1,
  'app/(app)/utilities/e-invoice/page.tsx': 1,
  'app/(app)/utilities/estimate-reset/page.tsx': 1,
  'app/(app)/utilities/reminder-entry/page.tsx': 2,
  'app/(app)/utilities/reminders/page.tsx': 2,
  'app/(app)/utilities/user-request/page.tsx': 1,
  'app/(app)/utilities/voucher-renumber/page.tsx': 1,
};

describe('N56 browser date conformance (D19)', () => {
  it('does not normalize transported date fields by slicing their string form', () => {
    const dateSlice =
      /\b(?:String|text|t|txt|str|dbText|inputValue)\([^\n]*(?:[A-Z_]*(?:DATE|DAY)[A-Z_]*|\b[vtforc]d\b|\bed\b|[_\.](?:date|day)\b|[a-z](?:Date|Day)\b|\b(?:date|day|clr|yesterday)\b)[^\n]*\)\.slice\(0,\s*10\)/;
    const offenders = files.flatMap((file) =>
      file.text
        .split('\n')
        .flatMap((line, index) =>
          dateSlice.test(line) ? [`${file.path}:${index + 1} ${line.trim()}`] : [],
        ),
    );
    expect(offenders).toEqual([]);
  });

  it('routes every known textual date display through formatDesktopDate', () => {
    const byPath = new Map(files.map((file) => [file.path, file.text]));
    const shortfalls = Object.entries(displayOwners).flatMap(([path, minimum]) => {
      const count = byPath.get(path)?.match(/formatDesktopDate\(/g)?.length ?? 0;
      return count >= minimum ? [] : [`${path}: expected at least ${minimum}, found ${count}`];
    });
    expect(shortfalls).toEqual([]);
  });
});
