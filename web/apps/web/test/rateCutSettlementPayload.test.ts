import { describe, expect, it } from 'vitest';
import { readFileSync } from 'node:fs';
import { join } from 'node:path';

const source = readFileSync(
  join(__dirname, '..', 'app', '(app)', 'txn', 'rate-cut', 'page.tsx'),
  'utf8',
);

describe('rate-cut settlement payload', () => {
  it('exposes desktop tender fields for both issue and receive sides', () => {
    for (const label of [
      'Cheque',
      'Card',
      'Bill O/S',
      'Cheque Bank A/c',
      'Cheque No',
      'Card A/c',
      'City',
      'Mobile',
      'Bank Name',
      'Received Cash',
      'Received Cheque',
      'Received Card',
      'Received Kasar',
      'Received Bill O/S',
      'Received Bank A/c',
      'Received Cheque No',
      'Received Card A/c',
    ]) {
      expect(source).toContain(`<label>${label}</label>`);
    }
  });

  it('posts receive-side tender under receivedPay instead of folding it into pay', () => {
    expect(source).toContain('receivedPay: {');
    for (const field of [
      'cash: n(receivedCash)',
      'chq: n(receivedChq)',
      'card: n(receivedCard)',
      'kasar: n(receivedKasar)',
      'billOs: n(receivedBillOs)',
      'bankAc: receivedBankAc.trim()',
      'chqNo: receivedChqNo.trim()',
      'cardAc: receivedCardAc.trim()',
    ]) {
      expect(source).toContain(field);
    }
  });

  it('exposes the rate-cut line fields already accepted by the API writer', () => {
    for (const label of [
      'ItemName',
      'Design',
      'LotNo',
      'ItemLot',
      'Pcs',
      'GrossWt',
      'OthWt',
      'Ght%',
      'LessWt',
      'LessTouch',
      'LbrType',
      'LbrRate',
      'LbrAmt',
      'OthAmt',
      'OthRate',
      'OthFine',
      'MRP',
      'Tax%',
      'TagCost',
      'TagGwt',
      'TagNwt',
      'LineConvRate',
      'LineConv%',
      'PrCode',
      'McxRate',
      'HmFine',
      'AdjWt',
      'SlvFine',
      'IsuLc',
      'IsuYear',
      'IsuBook',
      'IsuNo',
      'IsuSr',
    ]) {
      expect(source).toContain(`'${label}'`);
    }
  });

  it('posts source references as the nested isuRef object the API persists', () => {
    for (const field of [
      'fineRate: fineRate.trim()',
      'convRate: convRate.trim()',
      'convPct: convPct.trim()',
      'city: city.trim()',
      'mobile: mobile.trim()',
      'bankName: bankName.trim()',
      'itemName: l.itemName.trim()',
      'designNo: l.designNo.trim()',
      'lotNo: l.lotNo.trim()',
      'itemLot: l.itemLot.trim()',
      'pcs: l.pcs.trim()',
      'grossWt: l.grossWt.trim()',
      'othWt: l.othWt.trim()',
      'ghtPct: l.ghtPct.trim()',
      'lessWt: l.lessWt.trim()',
      'lbrAmt: l.lbrAmt.trim()',
      'othAmt: l.othAmt.trim()',
      'lessTouch: l.lessTouch.trim()',
      'lbrType: l.lbrType.trim()',
      'lbrRate: l.lbrRate.trim()',
      'otherRate: l.otherRate.trim()',
      'otherFine: l.otherFine.trim()',
      'mrp: l.mrp.trim()',
      'taxPct: l.taxPct.trim()',
      'tagCost: l.tagCost.trim()',
      'tagGrossWt: l.tagGrossWt.trim()',
      'tagNetWt: l.tagNetWt.trim()',
      'convRate: l.lineConvRate.trim()',
      'convPct: l.lineConvPct.trim()',
      'prCode: l.prCode.trim()',
      'mcxRate: l.mcxRate.trim()',
      'hallmarkFine: l.hallmarkFine.trim()',
      'adjustWt: l.adjustWt.trim()',
      'silverFine: l.silverFine.trim()',
      'issueLcCode: l.issueLcCode.trim()',
      'isuRef:',
      'yrcd: l.issueYear.trim()',
      'dbcd: l.issueBook.trim()',
      'no: l.issueNo.trim()',
      'srno: l.issueSrno.trim()',
    ]) {
      expect(source).toContain(field);
    }
  });

  it('offers a scoped bullion-booking picker that fills the source reference fields', () => {
    for (const field of [
      'entity="bullion-bookings"',
      'searchPath={bookingSearchPath}',
      'issueYear: String(row.issueYear',
      'issueBook: String(row.issueBook',
      'issueNo: String(row.issueNo',
      'issueSrno: String(row.issueSrno',
      'issueLcCode: String(row.issueLcCode',
      'ariaLabel={`Bullion booking source line',
      'ariaLabel={`Bullion booking source received line',
    ]) {
      expect(source).toContain(field);
    }
  });
});
