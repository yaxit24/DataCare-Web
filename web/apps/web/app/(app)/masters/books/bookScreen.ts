import { ApiError } from '../../../../lib/api';
import type { BookSlotRow } from '../../../../components/BookSlotGrid';

/** Company → Books (MS_BOOK): the desktop texts, combos and shapes of the screen (page.tsx). */
export const NO_RIGHTS = 'You Have No Rights.....';
export const NO_PRINT_RIGHTS = 'You Have No Print Rights.....';
export const RESERVED = 'This Is a Reserve Code You Cant Use It...';
export const SHORT_REQUIRED = 'Please Insert Book Short Name';
export const DETAIL_REQUIRED = 'Error Found : Please Enter Book Detail First...';
export const NAME_FIRST = 'Error Found : Please Enter Book Name First...';
export const SAVED = 'Data Are Saved.';
export const SELECT_FOR_DELETE = 'Please Select Product For Delete.';
export const DELETE_CONFIRM = 'Are You Sure To Delete This Book now?';
export const DELETED = 'Delete Success.';
export const SEARCH_TEXT = 'SEARCH RECORD';
export const RESERVED_CODES = ['218', '888', '999'];
export const codeTaken = (name: string) =>
  `This Book Code already Exist in  '${name}'  Book Name... Please Change Book Code...`;
export const nameTaken = (code: string) =>
  `This Book Name already Exist in  '${code}'  Book Code... Please Change Book Name...`;

/** The combos' entries (MS_BOOK.cs:2099-2112); each stores its first letter. */
export const CUR_USE = ['Yes', 'No'];
export const ITEM_TYPES = ['All', 'Gold', 'Silver'];
export const DIRECTIONS = ['Inword', 'Outword'];
export const INVOICE_TYPES = ['Free', 'Tax Invoice', 'Mix'];

export interface Rights {
  canUpdate: boolean;
  canDelete: boolean;
  canPrint: boolean;
}
export interface ListRow {
  code: string;
  name: string;
  trfr: string;
}
export interface Header {
  dataType: string;
  code: string;
  name: string;
  short: string;
  curUse: string;
  family: string;
  itemType: string;
  inout: string;
  bookType: string;
  resetBook: string;
  vchSeries: string;
  trfrBook: string;
  mobileEntry: string;
}
export interface SlotView {
  srNo: number;
  desc: string;
  acCode: string;
  acName: string;
}
export const blankHeader: Header = {
  dataType: 'A',
  code: '',
  name: '',
  short: '',
  curUse: 'Y',
  family: '',
  itemType: 'A',
  inout: 'I',
  bookType: 'F',
  resetBook: '',
  vchSeries: '',
  trfrBook: '',
  mobileEntry: '',
};
/** MS_BOOK_KeyPress: every key but Book Name's upper-cased, the apostrophe refused (:2752-2763). */
export const typed = (value: string) => value.toUpperCase().replace(/'/g, '');
export const toRows = (slots: SlotView[]): BookSlotRow[] =>
  slots.map((slot) => ({
    srNo: String(slot.srNo),
    desc: slot.desc,
    acCode: slot.acCode,
    acName: slot.acName,
  }));
export const messageOf = (error: unknown) =>
  error instanceof ApiError
    ? String(error.body?.message || error.body?.detail || error.body?.error || error.message)
    : String((error as Error)?.message ?? error);
