'use client';
import { OtherPurcForm } from '../../../../components/OtherPurcForm';

// OTHER EXPENSES — desktop "Other Expenses": TR_OTH_PURC on an OTH EXP book (MDI_FORM.cs:8372-8383). It is the
// same form as Other Income, posted by the same mirrored routines (Ac_Ledr.Oth_Purc_Ledr), so it shares the form.
//
// The page used to post a web-only "expense purchase" with one expense account per line, no book and no
// hidden voucher, to a writer that never ran: voucher numbering requires a configured book, so every save
// was refused. It also wrote BILL_OS_DATA, which the desktop OTH EXP footprint (book 355) does not have.
export default function OtherPurchasePage() {
  return <OtherPurcForm mode="OTH EXP" />;
}
