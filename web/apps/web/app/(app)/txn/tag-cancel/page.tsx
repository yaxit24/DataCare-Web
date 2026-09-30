'use client';
import { TagCancelForm } from '../../../../components/TagCancelForm';

/**
 * Tag Cancel — desktop TR_TAG_CAN on a TAG CANCEL book (MDI_FORM.cs:8586, `CurBookHelp("TAG CANCEL")`).
 * The same form serves Tag Transfer on a TAG TRFR book (/txn/tag-transfer).
 */
export default function TagCancelPage() {
  return <TagCancelForm mode="cancel" />;
}
