'use client';

import { useState } from 'react';
import { useGridKeyboard } from './GridKeyboard';
import { LookupPicker } from './LookupPicker';

/**
 * Shared stone / component sub-detail grid — the desktop's `*_IDTL` row set.
 *
 * WHY ONE COMPONENT
 * The desktop has 38 sub-detail grids across 35 forms (`project-memory/parity/IDTL-REFERENCE.md`),
 * and the web rendered NONE of them while seven API modules already persisted them. Every one of
 * those modules accepts a row shape extending `StoneSubDetailInput`, with the same field names, so
 * the divergence was purely at the screen. A single prop-driven grid closes all of them at once.
 *
 * WHY A STONE HAS TWO VALUATIONS
 * `modules/shared/stoneSubDetail.ts` states it: a stone is priced twice — once to the customer
 * (`IT_*`) and once for the karigar's job-work settlement (`KR_*`). Dropping the karigar block
 * leaves karigar settlement with no basis for the stone portion of a job, so both are offered here.
 *
 * COLUMN SETS ARE PER FORM
 * Desktop grids range from 16 columns (`TR_JDT_REC`) to 41 (`TR_TAG_OPBL`). A form passes the subset
 * its own grid declares rather than inheriting a superset, because rendering columns a form never had
 * is as wrong as omitting the ones it did.
 */

/** Every field the shared `StoneSubDetailInput` contract accepts, plus the identity columns. */
export type SubDetailField =
  | 'itCode'
  | 'dmCode'
  | 'dmName'
  | 'dmColor'
  | 'dmSize'
  | 'dmOrigin'
  | 'dmRemark'
  | 'dmSfNo'
  | 'dmLeb'
  | 'pcs'
  | 'pcsWt'
  | 'grossWt'
  | 'conPct'
  | 'conWt'
  | 'rateType'
  | 'rate'
  | 'amount'
  | 'lbrRate'
  | 'lbrAmount'
  | 'netAmount'
  | 'itType'
  | 'karigarWt'
  | 'karigarLessPct'
  | 'karigarConPct'
  | 'karigarConWt'
  | 'karigarRate'
  | 'karigarAmount'
  | 'karigarLabourRate'
  | 'karigarLabourAmount'
  | 'karigarNetAmount'
  // Manufacturing return / breakage columns. Desktop headers RtnPcs, RtnWt, BrkPcs, BrkWt appear on
  // 5-6 of the 38 sub-detail grids (TR_MFG_ORD_REC.cs:3499-3598 and the other MFG_IDTL grids), where
  // a component can come back unused or broken.
  | 'rtnPcs'
  | 'rtnWt'
  | 'brokPcs'
  | 'brokWt'
  | 'oldItmIsu';

export interface SubDetailColumnSpec {
  /** Desktop grid header, verbatim, so a screen can be checked against the decompiled source. */
  label: string;
  numeric?: boolean;
  width?: number;
  /** Master picker to attach, when the column is a coded reference. */
  lookup?: 'items' | 'diamonds';
}

/**
 * Canonical label per field, transcribed from the desktop headers rather than invented. The
 * frequency comment is the number of the 38 desktop sub-detail grids that declare that column, from
 * IDTL-REFERENCE.md, which is what makes the "core versus tail" split evidence-based.
 */
export const SUB_DETAIL_COLUMNS: Record<SubDetailField, SubDetailColumnSpec> = {
  itCode: { label: 'ItCode', width: 90, lookup: 'items' }, // 36 forms
  dmCode: { label: 'DmCode', width: 90, lookup: 'diamonds' }, // 24
  dmName: { label: 'DmName', width: 130 }, // 24
  dmColor: { label: 'DmColor', width: 80 }, // 15
  dmSize: { label: 'DmSize', width: 80 }, // 25
  dmOrigin: { label: 'DmOrigin', width: 90 }, // 15
  dmRemark: { label: 'DmRemark', width: 120 }, // 5 (labelled `Remark` on 10 more)
  dmSfNo: { label: 'DmSfNo', width: 90 }, // 24
  dmLeb: { label: 'DmLeb', width: 90 }, // certificate / lab reference (DM_LEB)
  pcs: { label: 'Pcs', numeric: true, width: 60 }, // 37
  pcsWt: { label: 'PcsWt', numeric: true, width: 75 }, // 14
  grossWt: { label: 'Weight', numeric: true, width: 80 }, // 34 — IT_GWT
  conPct: { label: 'Con%', numeric: true, width: 70 }, // 36
  conWt: { label: 'ConWt', numeric: true, width: 80 }, // 35
  rateType: { label: 'P/W', width: 55 }, // 35 — IT_RATE_TYPE, piece- or weight-wise
  rate: { label: 'Rate', numeric: true, width: 85 }, // 35
  amount: { label: 'ItAmt', numeric: true, width: 90 }, // 35
  lbrRate: { label: 'LbrRate', numeric: true, width: 80 }, // 34
  lbrAmount: { label: 'LbrAmt', numeric: true, width: 85 }, // 34
  netAmount: { label: 'NetAmt', numeric: true, width: 90 }, // 35
  itType: { label: 'ItType', width: 60 }, // 35
  karigarWt: { label: 'KrWt', numeric: true, width: 75 }, // 28
  karigarLessPct: { label: 'KrLs%', numeric: true, width: 65 }, // 10
  karigarConPct: { label: 'KrCon%', numeric: true, width: 70 }, // 3
  karigarConWt: { label: 'KrConWt', numeric: true, width: 80 }, // 28
  karigarRate: { label: 'KrRate', numeric: true, width: 85 },
  karigarAmount: { label: 'KrAmt', numeric: true, width: 90 },
  karigarLabourRate: { label: 'KrLRate', numeric: true, width: 80 },
  karigarLabourAmount: { label: 'KrLAmt', numeric: true, width: 85 },
  karigarNetAmount: { label: 'KrNetAmt', numeric: true, width: 90 },
  rtnPcs: { label: 'RtnPcs', numeric: true, width: 65 }, // 5 forms
  rtnWt: { label: 'RtnWt', numeric: true, width: 75 }, // 6
  brokPcs: { label: 'BrkPcs', numeric: true, width: 65 }, // 5
  brokWt: { label: 'BrkWt', numeric: true, width: 75 }, // 5
  oldItmIsu: { label: 'OldItm', width: 60 }, // 6
};

/**
 * Columns for a manufacturing component row (`MFG_IDTL`), which tracks consumption, return and
 * breakage rather than stone identity. Desktop reference: `TR_MFG_ORD_REC.cs:3499-3598` (28 cols),
 * `TR_MFG_ISU_REC.cs:3055-3145` (22), `TR_MFG_ITEM.cs:3005-3110` (23).
 */
export const SUB_DETAIL_COMPONENT: readonly SubDetailField[] = [
  'itCode',
  'pcs',
  'pcsWt',
  'grossWt',
  'conPct',
  'conWt',
  'rtnPcs',
  'rtnWt',
  'brokPcs',
  'brokWt',
  'rateType',
  'rate',
  'amount',
  'lbrRate',
  'lbrAmount',
  'netAmount',
  'oldItmIsu',
  'itType',
];

/**
 * The columns present in a clear majority of desktop sub-detail grids (24-37 of 38). A form with no
 * specific requirement can start here; a form with a declared grid should pass its own list.
 */
export const SUB_DETAIL_CORE: readonly SubDetailField[] = [
  'itCode',
  'dmCode',
  'dmName',
  'dmSize',
  'dmSfNo',
  'pcs',
  'grossWt',
  'conPct',
  'rateType',
  'rate',
  'amount',
  'lbrRate',
  'lbrAmount',
  'netAmount',
  'conWt',
  'karigarWt',
  'karigarConWt',
  'itType',
];

/** The karigar-side valuation block, for forms that settle job work on the stone portion. */
export const SUB_DETAIL_KARIGAR: readonly SubDetailField[] = [
  'karigarWt',
  'karigarLessPct',
  'karigarConPct',
  'karigarConWt',
  'karigarRate',
  'karigarAmount',
  'karigarLabourRate',
  'karigarLabourAmount',
  'karigarNetAmount',
];

/** A row is held as strings, matching every other grid on the web so inputs stay uncontrolled-free. */
export type SubDetailRow = Partial<Record<SubDetailField, string>>;

export const blankSubDetailRow = (): SubDetailRow => ({});

const numeric = (value: string | undefined): number | undefined => {
  if (value == null || value.trim() === '') return undefined;
  const parsed = Number(value);
  return Number.isFinite(parsed) ? parsed : undefined;
};
const textual = (value: string | undefined): string | undefined => {
  const trimmed = (value ?? '').trim();
  return trimmed === '' ? undefined : trimmed;
};

/**
 * Convert a row to the API shape, omitting anything the operator left blank.
 *
 * Blank must become `undefined`, not `0` or `''`. Sending a zero is an assertion that the stone is
 * worth nothing; sending nothing lets the server apply its own policy. That distinction is exactly
 * the class of defect P1 fixed on the labour and interest fields, and it would be reintroduced here
 * by a `Number(x || 0)`.
 */
export const toSubDetailInput = (row: SubDetailRow): Record<string, unknown> => {
  const out: Record<string, unknown> = {};
  for (const field of Object.keys(SUB_DETAIL_COLUMNS) as SubDetailField[]) {
    const spec = SUB_DETAIL_COLUMNS[field];
    const value = spec.numeric ? numeric(row[field]) : textual(row[field]);
    if (value !== undefined) out[field] = value;
  }
  return out;
};

/** True when the operator has entered anything at all; blank rows are never submitted. */
export const isSubDetailRowFilled = (row: SubDetailRow): boolean =>
  Object.values(row).some((value) => (value ?? '').trim() !== '');

/**
 * Convert a row the API returned back into editable form, so a reopened voucher shows its
 * sub-detail. Zeros and blanks come back as empty cells rather than literal `0`, matching how the
 * operator left them; otherwise every reopened stone would display a wall of zeros that then get
 * re-submitted as explicit values.
 */
export const stoneRowFromApi = (
  source: Record<string, unknown> | null | undefined,
): SubDetailRow => {
  const row: SubDetailRow = {};
  if (!source) return row;
  for (const field of Object.keys(SUB_DETAIL_COLUMNS) as SubDetailField[]) {
    const raw = (source as Record<string, unknown>)[field];
    if (raw == null) continue;
    if (typeof raw === 'number') {
      if (raw !== 0) row[field] = String(raw);
      continue;
    }
    const asText = String(raw).trim();
    if (asText !== '') row[field] = asText;
  }
  return row;
};

export const subDetailInputs = (rows: readonly SubDetailRow[]): Record<string, unknown>[] =>
  rows.filter(isSubDetailRowFilled).map(toSubDetailInput);

/**
 * `MfgComponent` names two fields differently from `StoneSubDetailInput` — `lbrAmt`/`netAmt` rather
 * than `lbrAmount`/`netAmount`. Renaming rather than widening the server contract keeps the desktop
 * column provenance comments in `mfg.ts` accurate; silently sending the wrong key would drop the
 * value with no error, which is the failure mode this whole phase exists to remove.
 */
export const toComponentInput = (row: SubDetailRow): Record<string, unknown> => {
  const out = toSubDetailInput(row);
  if ('lbrAmount' in out) {
    out.lbrAmt = out.lbrAmount;
    delete out.lbrAmount;
  }
  if ('netAmount' in out) {
    out.netAmt = out.netAmount;
    delete out.netAmount;
  }
  return out;
};

export const componentInputs = (rows: readonly SubDetailRow[]): Record<string, unknown>[] =>
  rows.filter(isSubDetailRowFilled).map(toComponentInput);

/**
 * Per-parent-line sub-detail state, with the cascade the desktop performs.
 *
 * Two behaviours are easy to get wrong per page and are therefore centralised:
 *
 * 1. CASCADE. Removing an item line must remove its stones. The desktop does this explicitly
 *    (`TR_PURC.cs:6887-6905` removes the sub-rows with their parent). Left to each page, an
 *    orphaned stone block would silently re-attach to whichever line inherited the index — a
 *    data-corruption bug that looks like a UI glitch.
 * 2. FILTERED VIEW. The desktop shows only the selected parent's sub-rows, driven by
 *    `RowColChange` (`TR_SALE.cs:16791-16876`). Rendering one grid for the active line matches
 *    that, and avoids stacking N grids down the page.
 *
 * `inputsFor` is index-based deliberately: the caller must pair stones with the ORIGINAL line
 * index, because voucher pages filter empty lines before submitting and the filtered position no
 * longer matches.
 */
export function useSubDetail(lineCount: number) {
  const [byLine, setByLine] = useState<SubDetailRow[][]>(() => [[blankSubDetailRow()]]);
  const [activeLine, setActiveLine] = useState(0);
  const rowsFor = (index: number): SubDetailRow[] => byLine[index] ?? [blankSubDetailRow()];

  const setRowsFor = (index: number, rows: SubDetailRow[]) =>
    setByLine((current) => {
      const next = current.slice();
      while (next.length <= index) next.push([blankSubDetailRow()]);
      next[index] = rows;
      return next;
    });

  /** Call when a parent line is appended, so the sub-detail array stays aligned. */
  const appendLine = () => setByLine((current) => [...current, [blankSubDetailRow()]]);

  /** Call when a parent line is removed, so its stones go with it. */
  const removeLine = (index: number) =>
    setByLine((current) => {
      const next = current.filter((_, i) => i !== index);
      return next.length ? next : [[blankSubDetailRow()]];
    });

  const reset = () => {
    setByLine([[blankSubDetailRow()]]);
    setActiveLine(0);
  };

  /** Replace all sub-detail state from a loaded voucher, one entry per parent line. */
  const load = (perLine: SubDetailRow[][]) => {
    setByLine(
      perLine.length
        ? perLine.map((rows) => (rows.length ? rows : [blankSubDetailRow()]))
        : [[blankSubDetailRow()]],
    );
    setActiveLine(0);
  };

  /** The API payload for one parent line, or undefined when the operator entered no stones. */
  const inputsFor = (index: number): Record<string, unknown>[] | undefined => {
    const rows = subDetailInputs(rowsFor(index));
    return rows.length ? rows : undefined;
  };

  /** As `inputsFor`, but in the `MfgComponent` field naming. */
  const componentsFor = (index: number): Record<string, unknown>[] | undefined => {
    const rows = componentInputs(rowsFor(index));
    return rows.length ? rows : undefined;
  };

  const totalRows = byLine.reduce((sum, rows) => sum + subDetailInputs(rows).length, 0);
  const safeActive = Math.min(activeLine, Math.max(0, lineCount - 1));

  return {
    activeLine: safeActive,
    setActiveLine,
    rowsFor,
    setRowsFor,
    appendLine,
    removeLine,
    reset,
    load,
    inputsFor,
    componentsFor,
    totalRows,
  };
}

export interface SubDetailGridProps {
  /** Sub-detail rows for the currently selected parent line. */
  rows: SubDetailRow[];
  onRowsChange: (rows: SubDetailRow[]) => void;
  /** Columns this form's desktop grid declares. */
  columns?: readonly SubDetailField[];
  /** 1-based parent line number, shown so the operator knows which item these belong to. */
  parentLabel?: string;
  /** Desktop form and grid this mirrors, e.g. `TR_PURC / MSG_IDTL (34 cols)`. */
  desktopSource?: string;
  disabled?: boolean;
}

export default function SubDetailGrid({
  rows,
  onRowsChange,
  columns = SUB_DETAIL_CORE,
  parentLabel,
  desktopSource,
  disabled,
}: SubDetailGridProps) {
  const setCell = (index: number, field: SubDetailField, value: string) =>
    onRowsChange(rows.map((row, i) => (i === index ? { ...row, [field]: value } : row)));

  const handleGridKey = useGridKeyboard({
    rowCount: rows.length,
    onAppendRow: () => onRowsChange([...rows, blankSubDetailRow()]),
    onRemoveRow: (row) => {
      onRowsChange(
        rows.length === 1 ? [blankSubDetailRow()] : rows.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });

  return (
    <div className="panel" style={{ overflow: 'auto' }}>
      <h3 style={{ margin: '0 0 6px' }}>
        Stones / components{parentLabel ? ` — ${parentLabel}` : ''}{' '}
        {desktopSource ? (
          <span className="muted" style={{ fontWeight: 400 }}>
            — {desktopSource}
          </span>
        ) : null}
      </h3>
      <table className="grid" onKeyDown={handleGridKey}>
        <thead>
          <tr>
            <th style={{ width: 40 }}>Sr</th>
            {columns.map((field) => (
              <th
                key={field}
                className={SUB_DETAIL_COLUMNS[field].numeric ? 'num' : undefined}
                style={{ width: SUB_DETAIL_COLUMNS[field].width }}
              >
                {SUB_DETAIL_COLUMNS[field].label}
              </th>
            ))}
            <th />
          </tr>
        </thead>
        <tbody>
          {rows.map((row, index) => (
            <tr key={index}>
              <td className="muted">{index + 1}</td>
              {columns.map((field) => {
                const spec = SUB_DETAIL_COLUMNS[field];
                return (
                  <td key={field} className={spec.numeric ? 'num' : undefined}>
                    {spec.lookup ? (
                      <LookupPicker
                        entity={spec.lookup}
                        value={row[field] ?? ''}
                        onChange={(value) => setCell(index, field, value)}
                        style={{ width: spec.width }}
                      />
                    ) : (
                      <input
                        value={row[field] ?? ''}
                        onChange={(event) => setCell(index, field, event.target.value)}
                        style={{ width: spec.width }}
                        disabled={disabled}
                        aria-label={`${spec.label} row ${index + 1}`}
                      />
                    )}
                  </td>
                );
              })}
              <td>
                <button
                  type="button"
                  className="ghost"
                  onClick={() =>
                    onRowsChange(
                      rows.length === 1
                        ? [blankSubDetailRow()]
                        : rows.filter((_, i) => i !== index),
                    )
                  }
                  aria-label={`Remove stone row ${index + 1}`}
                >
                  ×
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <button
        type="button"
        className="ghost"
        style={{ marginTop: 6 }}
        onClick={() => onRowsChange([...rows, blankSubDetailRow()])}
      >
        Add stone row
      </button>
    </div>
  );
}
