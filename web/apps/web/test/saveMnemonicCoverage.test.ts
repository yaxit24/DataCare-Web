import { readdirSync, readFileSync, statSync } from 'node:fs';
import { dirname, join } from 'node:path';
import { fileURLToPath } from 'node:url';
import { describe, expect, it } from 'vitest';
import { SAVE_MNEMONIC_ATTRIBUTE } from '../lib/saveMnemonic';

/**
 * G200: the desktop voucher forms all save with the &Save mnemonic (for example `TR_KR_ISU.cs:2330`
 * `BtnSave.Text = "&Save"`), and Alt+S presses the button marked with `data-save-mnemonic`. A voucher screen whose
 * primary Save button is not marked silently loses the key, as 20 screens did after N163. This scan keeps every
 * voucher page marked: a page under `app/(app)/txn` with a primary button labelled Save, Saving, Update, Post,
 * Issue or Receive must carry the attribute itself or render a shared form that does.
 */
const here = dirname(fileURLToPath(import.meta.url));
const txnRoot = join(here, '..', 'app', '(app)', 'txn');
/** Shared forms that mark their own save button. */
const MARKING_COMPONENTS = [
  'VoucherChrome',
  'PaymentForm',
  'KarigarForm',
  'StockInoutForm',
  'EBillEntry',
  'TagSplitForm',
  'TagCancelForm',
  'WholesaleVoucherForm',
];
const SAVE_LABEL = /\b(Save|Saving|Update|Post|Issue|Receive)\b/;
/**
 * Pages with several independent forms, each with its own primary button. Alt+S there must press the Save of the
 * form that has focus, which `findSaveButton` does not do yet; neither menu is in the Standard edition (D31).
 */
const MULTI_FORM_PAGES: Record<string, string> = {
  'membership/page.tsx': 'two forms: enrolment and points',
  'scheme/page.tsx': 'three forms: enrolment, installment and maturity',
};

function primaryButtons(source: string): string[] {
  const found: string[] = [];
  const pattern = /<button\b[^>]*className="primary"[^>]*>([\s\S]{0,240}?)<\/button>/g;
  for (const match of source.matchAll(pattern)) found.push(match[0]);
  return found;
}

describe('every voucher screen answers Alt+S (G200)', () => {
  const pages = readdirSync(txnRoot)
    .map((name) => join(txnRoot, name, 'page.tsx'))
    .filter((file) => {
      try {
        return statSync(file).isFile();
      } catch {
        return false;
      }
    });

  it('finds the voucher pages', () => {
    expect(pages.length).toBeGreaterThan(50);
  });

  it('marks the primary Save button on every page that has one', () => {
    const unmarked: string[] = [];
    for (const file of pages) {
      const source = readFileSync(file, 'utf8');
      if (MARKING_COMPONENTS.some((name) => source.includes(`<${name}`))) continue;
      if (MULTI_FORM_PAGES[file.slice(txnRoot.length + 1)]) continue;
      for (const button of primaryButtons(source)) {
        if (SAVE_LABEL.test(button) && !button.includes(SAVE_MNEMONIC_ATTRIBUTE))
          unmarked.push(file.slice(txnRoot.length + 1));
      }
    }
    expect(unmarked).toEqual([]);
  });

  it('marks at most one button per page, so Alt+S never has to choose', () => {
    const doubled = pages.filter(
      (file) => readFileSync(file, 'utf8').split(SAVE_MNEMONIC_ATTRIBUTE).length - 1 > 1,
    );
    expect(doubled.map((file) => file.slice(txnRoot.length + 1))).toEqual([]);
  });
});
