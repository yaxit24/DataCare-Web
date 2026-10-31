import { tagKarigarColumns, tagKarigarStock, type TagKarigarColumns } from '@datacare/core';

/** The tag line fields the karigar weight block is worked out from (TR_TAG_OPBL columns 14-23 and 27-29). */
export interface TagKarigarLine {
  grossWt?: number;
  netWt?: number;
  touch?: number;
  westPct?: number;
  karigarOthWt?: number;
  karigarNetWt?: number;
  karigarGhtPct?: number;
  karigarGhtWt?: number;
  karigarTouch?: number;
  karigarWestPct?: number;
  karigarFine?: number;
}

/**
 * The BAR_DETL karigar columns of one tag line (TR_TAG_OPBL.cs:10975-11022, N204) and the MAIN_STOCK copy of
 * Tag_Opbl_Stk (Ac_Stock.cs:28). `fineWt` is the line's ITM_FINE, which a row without a KrTouch falls back to.
 */
export function tagKarigarLineColumns(
  line: TagKarigarLine,
  fineWt: number,
): { detail: TagKarigarColumns; stock: ReturnType<typeof tagKarigarStock> } {
  const detail = tagKarigarColumns({
    grossWt: line.grossWt,
    netWt: line.netWt,
    touch: line.touch,
    westPct: line.westPct,
    fineWt,
    karigarOthWt: line.karigarOthWt,
    karigarNetWt: line.karigarNetWt,
    karigarGhtPct: line.karigarGhtPct,
    karigarGhtWt: line.karigarGhtWt,
    karigarTouch: line.karigarTouch,
    karigarWestPct: line.karigarWestPct,
    karigarFine: line.karigarFine,
  });
  return { detail, stock: tagKarigarStock(detail) };
}
