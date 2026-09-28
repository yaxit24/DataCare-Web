import { describe, expect, it } from 'vitest';
import { readFileSync } from 'node:fs';
import { join } from 'node:path';

const source = readFileSync(
  join(__dirname, '..', 'app', '(app)', 'txn', 'wholesale-sale', 'page.tsx'),
  'utf8',
);

describe('wholesale-sale rate-cut family payload', () => {
  it('renders editable full-grid body cells for the extended desktop columns', () => {
    expect(source).toContain('<ExtendedHeaderCells full={fullGrid} fields={extendedLineFields} />');
    expect(source).toContain('<ExtendedBodyCells');
    for (const label of ['IsuYear', 'IsuBook', 'IsuNo', 'IsuSr']) {
      expect(source).toContain(`'${label}'`);
    }
  });

  it('uses the scoped bullion-booking picker and posts nested isuRef', () => {
    for (const field of [
      'entity="bullion-bookings"',
      'searchPath={bookingSearchPath}',
      'ariaLabel={`Bullion booking source wholesale line',
      'issueYear: String(row.issueYear',
      'issueBook: String(row.issueBook',
      'issueNo: String(row.issueNo',
      'issueSrno: String(row.issueSrno',
      'const sourceRef =',
      'isuRef: sourceRef',
      'yrcd: l.issueYear.trim()',
      'dbcd: l.issueBook.trim()',
      'no: l.issueNo.trim()',
      'srno: l.issueSrno.trim()',
    ]) {
      expect(source).toContain(field);
    }
  });
});
