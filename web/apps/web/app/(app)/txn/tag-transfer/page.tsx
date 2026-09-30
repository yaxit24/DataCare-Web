'use client';
import { TagCancelForm } from '../../../../components/TagCancelForm';

/**
 * Tag Transfer — desktop TR_TAG_CAN on a TAG TRFR book (MDI_FORM.cs:8664, `CurBookHelp("TAG TRFR")`): a tag's metal
 * moves to a loose item. The same form serves Tag Cancel on a TAG CANCEL book (/txn/tag-cancel).
 */
export default function TagTransferPage() {
  return <TagCancelForm mode="transfer" />;
}
