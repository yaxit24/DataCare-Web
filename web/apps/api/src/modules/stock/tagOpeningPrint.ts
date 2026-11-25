import { roundHalfEven, vbVal } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import { stageTagPrintRowsTx } from './tagPrint.js';
import { tagPrintLabelsTx, tagPrintSetDefault } from './tagPrintScreen.js';

/**
 * The residual print family of Tag Opening / Only Tag Entry (WP-32, desktop TR_TAG_OPBL).
 *
 * - The label-file chooser lists PRINT_MAST of PRINT_TYPE 'QR' when QR_CODE_GEN is on, else 'TAG'
 *   (TR_TAG_OPBL.cs:10086 / :10090), the row marked PRINT_SET_A 'Y' selected.
 * - Print (BtnPrint_Click :11477-11551) needs the print right (:11477-11479 "You Have No Print
 *   Rights.....", enforced by the route policy, not here), clears TAG_PRINT_DATA, writes the label
 *   skip rows with IT_CODE '00' and VCH_SRNO 0 (:11485-11492, `Math.Round` — banker's, so 2.5 skips
 *   2), then copies the voucher's BAR_DETL rows with the shared 60-column staging statement
 *   (:11523 `ITM_COLOR,LBR_CODE,ITM_STYLE FROM BAR_DETL WHERE CO_CODE`), and renders the sheet.
 * - Set (BtnTagSet_Click :12345-12364) marks the chosen file PRINT_SET_A 'Y' and answers "Tag Print
 *   Report Default Set" (:12362) — the same operation as UT_TAG_PRINT's, so it reuses
 *   `tagPrintSetDefault`.
 * - `MsUserKrTouchHide` (CO_SET_NEW.USER_KR_TOUCH_HIDE, MS_OPNCOMP.cs:979) hides the KrTouch, KrWst%
 *   and KrFine columns from a non-admin (TR_TAG_OPBL.cs:5156-5172 zeroes their widths); the setting
 *   is served to the page, which keeps the payload fields intact.
 * - `MsTagVchAutoSave` / `MsTagRowAutoPrint` (CO_SET_NEW.TAG_VCH_AUTO_SAVE / TAG_AUTO_PRINT,
 *   MS_OPNCOMP.cs:962-964) gate the Enter-on-last-cell auto save and row print
 *   (TR_TAG_OPBL.cs:9108-9114).
 *
 * Hosted corrections, per the WP-32 frozen case list: the staging delete is tenant-scoped (forced RLS)
 * and the RENDER runs in the same transaction as the staging, so each operator's response carries
 * exactly the job they staged — the desktop's unqualified `DELETE FROM TAG_PRINT_DATA` (:11482) is not
 * reproduced across operators. The web writes no IMAGE_DATA QR rows (the QR picture is rendered into
 * the sheet).
 */
export class TagOpeningPrintValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'TagOpeningPrintValidationError';
  }
}

// TR_TAG_OPBL.cs:10787 (save) and :11374 (delete): "You Have No Rights.....".
export const TAG_OPENING_NO_RIGHTS = 'You Have No Rights.....';
// TR_TAG_OPBL.cs:11479: "You Have No Print Rights.....".
export const TAG_OPENING_NO_PRINT_RIGHTS = 'You Have No Print Rights.....';

/**
 * The desktop text a rights refusal on this screen's routes answers with, or undefined for other
 * routes. The app-level authorization hook sends it with the 403, so a direct API call and the page
 * both see the exact desktop sentence. The urls alone identify the routes (the method is not part of
 * the hook's input), and PUT and DELETE share `:vchNo`, which is correct: both refusals are
 * "You Have No Rights.....".
 */
const REFUSAL_ROUTES = new Set([
  '/stock/tag-opening',
  '/stock/tag-opening/:vchNo',
  '/stock/tag-opening/:vchNo/print',
]);

export function tagOpeningRefusalText(url: string, action: string): string | undefined {
  if (!REFUSAL_ROUTES.has(url)) return undefined;
  return action === 'print' ? TAG_OPENING_NO_PRINT_RIGHTS : TAG_OPENING_NO_RIGHTS;
}

export interface TagOpeningPrintScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
}

export interface TagOpeningColumnSetting {
  /** COL_MAST.COL_NAME — the desktop grid header, and the stable identity the page keys its input to. */
  name: string;
  /** COL_MAST.COL_NEW_NAME — the header the operator renamed the column to. */
  newName: string;
  /** COL_MAST.YES_NO — 'N' hides the column (TR_TAG_OPBL.cs:5398). */
  visible: boolean;
}

export interface TagOpeningSetup {
  labelFiles: string[];
  defaultLabelFile: string;
  qr: boolean;
  hideKarigarTouch: boolean;
  autoSave: boolean;
  autoRowPrint: boolean;
  /** COL_MAST rows of the two grids (BOOK_NAME 'TAG_DETL' and 'TAG_IDTL', DC_Main.cs:1688). */
  columns: Record<'TAG_DETL' | 'TAG_IDTL', TagOpeningColumnSetting[]>;
}

const text = (value: unknown): string => String(value ?? '').trim();
const flag = (value: unknown): boolean =>
  String(value ?? '')
    .trim()
    .toUpperCase() === 'Y';

/** The one CO_SET_NEW row's switches this screen reads; absence behaves as blank (MS_OPNCOMP blanks). */
async function tagOpeningSwitchesTx(
  tx: any,
  scope: { tenantId: string; coCode: string },
): Promise<{
  qr: boolean;
  hideKarigarTouch: boolean;
  autoSave: boolean;
  autoRowPrint: boolean;
}> {
  const behavior = await resolveSettingsBehaviorTx(tx, scope);
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "USER_KR_TOUCH_HIDE","TAG_VCH_AUTO_SAVE","TAG_AUTO_PRINT" FROM "CO_SET_NEW"
       WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
    scope.tenantId,
    scope.coCode,
  );
  const row = rows[0] ?? {};
  return {
    qr: behavior.qrCodeGeneration,
    hideKarigarTouch: flag(row.USER_KR_TOUCH_HIDE),
    autoSave: flag(row.TAG_VCH_AUTO_SAVE),
    autoRowPrint: flag(row.TAG_AUTO_PRINT),
  };
}

/** COL_MAST rows of one book family, as the grid applies them (TR_TAG_OPBL.cs:5395-5402). */
async function columnSettingsTx(
  tx: any,
  scope: { tenantId: string; coCode: string },
  book: 'TAG_DETL' | 'TAG_IDTL',
): Promise<TagOpeningColumnSetting[]> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "COL_NAME","COL_NEW_NAME","YES_NO" FROM "COL_MAST"
       WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "BOOK_NAME"=$3
       ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    book,
  );
  return rows.map((row) => ({
    name: text(row.COL_NAME),
    newName: text(row.COL_NEW_NAME),
    visible: text(row.YES_NO).toUpperCase() !== 'N',
  }));
}

/** What the screen's chooser, Set button and grid need: the label files, switches and COL_MAST rows. */
export async function tagOpeningSetup(
  prisma: any,
  scope: { tenantId: string; coCode: string; lcCode: string },
  isAdmin: boolean,
): Promise<TagOpeningSetup> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const switches = await tagOpeningSwitchesTx(tx, scope);
    const files: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "PRINT_FILE","PRINT_SET_A" FROM "PRINT_MAST"
         WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "PRINT_TYPE"=$3
         ORDER BY "PRINT_FILE", row_id`,
      scope.tenantId,
      scope.coCode,
      switches.qr ? 'QR' : 'TAG',
    );
    const marked = [...files].reverse().find((row) => text(row.PRINT_SET_A) === 'Y');
    return {
      labelFiles: files.map((row) => text(row.PRINT_FILE)).filter(Boolean),
      defaultLabelFile: marked ? text(marked.PRINT_FILE) : '',
      qr: switches.qr,
      // TR_TAG_OPBL.cs:5156: the hide applies to a non-admin only (MCo_UserType <> 'A').
      hideKarigarTouch: switches.hideKarigarTouch && !isAdmin,
      autoSave: switches.autoSave,
      autoRowPrint: switches.autoRowPrint,
      columns: {
        TAG_DETL: await columnSettingsTx(tx, scope, 'TAG_DETL'),
        TAG_IDTL: await columnSettingsTx(tx, scope, 'TAG_IDTL'),
      },
    };
  });
}

export interface TagOpeningPrintInput {
  /** `nLableSkip.Text`: blank labels before the first real one; .NET Math.Round, i.e. banker's. */
  labelSkip?: number | string;
  /** `cboPrintfile.Text`: the label file; refused when PRINT_MAST does not know it. */
  labelFile?: string;
  /** TagLastRowPrint (:9189-9190) stages one SR_NO; the full voucher prints when absent. */
  srNo?: number;
}

/**
 * BtnPrint_Click (:11482-11538) for one voucher: stage the skip rows and the voucher's tags, then
 * render the sheet — staging and rendering in ONE transaction, so the response is this operator's job
 * and nothing else's.
 */
export async function tagOpeningPrint(
  prisma: any,
  scope: TagOpeningPrintScope,
  voucherNo: string,
  input: TagOpeningPrintInput,
): Promise<{ html: string; skipped: number; staged: number; file: string }> {
  const voucher = String(voucherNo ?? '').trim();
  if (!voucher) throw new TagOpeningPrintValidationError('open a voucher first');
  const file = text(input.labelFile);
  // TR_TAG_OPBL.cs:11485: (int)Math.Round(Conversion.Val(nLableSkip.Text)) — banker's rounding.
  const skip = Math.max(0, roundHalfEven(vbVal(input.labelSkip), 0));
  if (skip > 500) throw new TagOpeningPrintValidationError('Lable Skip is at most 500');
  const srNo = Number(input.srNo ?? 0);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const headers: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO" FROM "BAR_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
         AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 FOR UPDATE`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucher,
    );
    if (headers.length !== 1)
      throw new TagOpeningPrintValidationError(`tag-opening voucher not found: ${voucher}`);
    if (file) {
      // The desktop hands any text to Crystal and fails at run time (:11551); the web refuses a name
      // PRINT_MAST lacks before anything is cleared.
      const switches = await tagOpeningSwitchesTx(tx, scope);
      const known: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
        `SELECT 1 FROM "PRINT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "PRINT_TYPE"=$3
           AND "PRINT_FILE"=$4 LIMIT 1`,
        scope.tenantId,
        scope.coCode,
        switches.qr ? 'QR' : 'TAG',
        file,
      );
      if (!known.length) throw new TagOpeningPrintValidationError(`Unknown print file: ${file}`);
    }
    const staged = await stageTagPrintRowsTx(
      tx,
      scope.tenantId,
      scope,
      voucher,
      srNo > 0 ? [srNo] : undefined,
      skip,
    );
    const html = await tagPrintLabelsTx(
      tx,
      {
        tenantId: scope.tenantId,
        coCode: scope.coCode,
        lcCode: scope.lcCode,
        coYear: scope.coYear,
      },
      file,
    );
    return { html, skipped: skip, staged, file };
  });
}

/** BtnTagSet_Click (:12345-12364): the chosen file becomes the default of its TAG/QR family. */
export function tagOpeningSetDefaultLabelFile(
  prisma: any,
  scope: { tenantId: string; coCode: string; lcCode: string; coYear: string },
  file: string,
) {
  return tagPrintSetDefault(prisma, scope, file);
}
