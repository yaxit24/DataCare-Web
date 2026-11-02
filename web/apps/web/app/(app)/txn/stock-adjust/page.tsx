'use client';
import { TagCancelForm } from '../../../../components/TagCancelForm';

/**
 * Stock Adjust — desktop TR_TAG_CAN on a STOCK ADJUST book (MDI_FORM.cs:8616-8627, `CurBookHelp("STOCK ADJUST")`):
 * the Tag Cancel form with the Sign column, where a line adds to stock (+) or takes it out (−).
 */
export default function StockAdjustPage() {
  return <TagCancelForm mode="adjust" />;
}
