import { readFileSync } from 'node:fs';
import { join } from 'node:path';
import { describe, expect, it } from 'vitest';

const read = (path: string) => readFileSync(join(__dirname, '..', path), 'utf8');
const page = read('app/(app)/txn/fine-jv/page.tsx');
const css = read('app/globals.css');

describe('Fine Jv Entry page (TR_CONTRA in FINE JV mode)', () => {
  it('labels every header control with the desktop caption (TR_CONTRA.cs:1107-1372)', () => {
    for (const [id, label] of [
      ['fine-jv-vch-no', 'Vch No'],
      ['fine-jv-year', 'Year'],
      ['fine-jv-location', 'Location'],
      ['fine-jv-date', 'Vch Date'],
      ['fine-jv-metal', 'Item Type'],
    ]) {
      expect(page).toContain(`<label htmlFor="${id}">${label}</label>`);
      expect(page).toContain(`id="${id}"`);
    }
    expect(page).toContain('ariaLabel="Employee"');
    expect(page).toContain('entity="employees"');
    expect(page).toContain('mainBooks={FINE_JV_MAIN_BOOKS}');
    expect(page).toContain("const FINE_JV_MAIN_BOOKS = ['FINE JV'];");
  });

  it('is the desktop grid: Sr, Cr/Dr, AcCode, Ac Name, It Desc, CrFine and DrFine (TR_CONTRA.cs:1426-1446)', () => {
    for (const header of ['Sr', 'Cr/Dr', 'AcCode', 'Ac Name', 'It Desc', 'CrFine', 'DrFine'])
      expect(page).toContain(
        `<th${header === 'CrFine' || header === 'DrFine' ? ' className="num"' : ''}>${header}</th>`,
      );
    for (const label of ['Cr/Dr row', 'It Desc row', 'Fine row'])
      expect(page).toContain('aria-label={`' + label + ' ${i + 1}`}');
    expect(page).toContain('ariaLabel={`AcCode row ${i + 1}`}');
    expect(page).toContain('aria-label="CrFine total"');
    expect(page).toContain('aria-label="DrFine total"');
  });

  it('keeps account names server-resolved and uses the desktop confirmations', () => {
    const payload = page.slice(
      page.indexOf('lines: filled.map'),
      page.indexOf('const saved = loadedVch'),
    );
    expect(payload).not.toContain('acName');
    expect(page).toContain("window.confirm('This Row Record will Removed permantley ?')");
    expect(page).toContain("window.confirm('Are You Sure To Delete This Voucher now?')");
    expect(page).toContain("setNotice('Delete Success.')");
    expect(page).toContain('data-save-mnemonic');
  });

  it('uses WCAG-AA-safe colors for screen success feedback and sidebar group labels', () => {
    expect(css).toContain('--ok: #187344;');
    expect(css).toContain('color: #8297ad;');
  });
});
