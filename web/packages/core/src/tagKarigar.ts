import { round } from './money.js';

/**
 * The karigar weight block of the tag grid: desktop TR_TAG_OPBL columns 17-23, KrOthWt, KrNwt, KrGht%, KrGht,
 * KrTouch, KrWst% and KrFine (headers at TR_TAG_OPBL.cs:5146-5172). Cells hold numbers or the text typed in them.
 */
export interface TagKarigarInput {
  grossWt?: number | string | null;
  netWt?: number | string | null;
  karigarOthWt?: number | string | null;
  karigarNetWt?: number | string | null;
  karigarGhtWt?: number | string | null;
  karigarTouch?: number | string | null;
  karigarWestPct?: number | string | null;
  /** KrFine as typed; blank or 0 when it should be worked out. */
  karigarFine?: number | string | null;
}

/** What CommPassTotal leaves in the two worked-out cells. */
export interface TagKarigarBlock {
  karigarNetWt: number;
  karigarFine: number;
}

/** The tag's own touch, wastage and fine (columns 27-29), which a save falls back to. */
export interface TagKarigarSaveInput extends TagKarigarInput {
  karigarGhtPct?: number | string | null;
  touch?: number | string | null;
  westPct?: number | string | null;
  fineWt?: number | string | null;
}

/** The BAR_DETL karigar columns a save writes. */
export interface TagKarigarColumns {
  KR_OTH_WT: number;
  KR_NET_WT: number;
  KR_GHT_PRC: number;
  KR_GHT_WT: number;
  KR_TOUCH: number;
  KR_WEST_PRC: number;
  KR_FINE: number;
}

const value = (input: unknown): number => {
  const parsed = typeof input === 'number' ? input : Number(String(input ?? '').trim() || 0);
  return Number.isFinite(parsed) ? parsed : 0;
};

/**
 * KrNwt and KrFine as CommPassTotal leaves them when a cell is left (TR_TAG_OPBL.cs:6679-6826), for a tag typed
 * on the screen; the order, manufacturing and lot paths fill these cells from their own vouchers.
 *
 * - KrNwt is gross − KrOthWt while both are non-zero (`:6679-6686`). Otherwise a blank KrNwt takes the net
 *   weight and a typed one stays (`:6690-6704`), so a later change to the net weight does not move it.
 * - With no karigar touch or wastage KrFine is KrNwt + KrGht (`:6793-6800`). Otherwise a typed KrFine stays and a
 *   blank one is (KrNwt + KrGht) × (KrTouch + KrWst%) / 100 (`:6804-6811`); the screen clears a typed KrFine when
 *   KrNwt, KrTouch, KrWst% or KrGht changes, as the desktop recomputes it then (`:6712`, `:6749`, `:6771`,
 *   `:6815`).
 *
 * The cells use the "0.000" format, which rounds half away from zero.
 */
export function tagKarigarBlock(input: TagKarigarInput): TagKarigarBlock {
  const gross = value(input.grossWt);
  const othWt = value(input.karigarOthWt);
  const typedNet = value(input.karigarNetWt);
  const karigarNetWt = round(
    othWt !== 0 && gross !== 0 ? gross - othWt : typedNet !== 0 ? typedNet : value(input.netWt),
    3,
  );
  const ghtWt = value(input.karigarGhtWt);
  const percent = value(input.karigarTouch) + value(input.karigarWestPct);
  const typedFine = value(input.karigarFine);
  const karigarFine =
    percent === 0
      ? round(karigarNetWt + ghtWt, 3)
      : typedFine !== 0
        ? round(typedFine, 3)
        : round(((karigarNetWt + ghtWt) * percent) / 100, 3);
  return { karigarNetWt, karigarFine };
}

/**
 * The karigar columns BtnSave_Click writes to BAR_DETL (TR_TAG_OPBL.cs:10975-11022). KR_NET_WT is the KrNwt cell
 * (`:10986`). With no karigar touch the row takes the tag's own touch, wastage and fine (`:11010-11012`), so a
 * KrWst% or KrFine typed without a KrTouch is not kept; with one it takes the three karigar cells (`:11017-11019`).
 * The lot path (`:10990-11005`) needs a lot header the web screen does not have.
 */
export function tagKarigarColumns(input: TagKarigarSaveInput): TagKarigarColumns {
  const block = tagKarigarBlock(input);
  const touch = value(input.karigarTouch);
  return {
    KR_OTH_WT: round(value(input.karigarOthWt), 3),
    KR_NET_WT: block.karigarNetWt,
    KR_GHT_PRC: round(value(input.karigarGhtPct), 2),
    KR_GHT_WT: round(value(input.karigarGhtWt), 3),
    KR_TOUCH: touch !== 0 ? round(touch, 2) : round(value(input.touch), 2),
    KR_WEST_PRC:
      touch !== 0 ? round(value(input.karigarWestPct), 2) : round(value(input.westPct), 2),
    KR_FINE: touch !== 0 ? block.karigarFine : round(value(input.fineWt), 3),
  };
}

/** The MAIN_STOCK karigar columns Tag_Opbl_Stk copies from the tag's BAR_DETL row (Ac_Stock.cs:28). */
export function tagKarigarStock(columns: TagKarigarColumns) {
  return {
    KR_NWT: columns.KR_NET_WT,
    KR_TOUCH: columns.KR_TOUCH,
    KR_WEST: columns.KR_WEST_PRC,
    KR_FINE: columns.KR_FINE,
  };
}
