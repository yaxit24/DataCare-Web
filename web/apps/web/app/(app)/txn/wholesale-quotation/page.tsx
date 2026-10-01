import { WholesaleVoucherForm } from '../../../../components/WholesaleVoucherForm';

/**
 * Desktop Wh Quotation: TR_WH_SALE opened on a configured MAIN_BOOK='WH QUOT'. It persists the full
 * issue/receive document but the posting routines deliberately exclude WH QUOT, so no ledger, Rojmel,
 * stock or booking draw-down is produced.
 */
export default function WholesaleQuotationPage() {
  return <WholesaleVoucherForm workflow="wholesale-quotation" />;
}
