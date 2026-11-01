'use client';

import { round } from '@datacare/core';
import { LookupPicker } from './LookupPicker';
import { useGridKeyboard } from './GridKeyboard';
import SubDetailGrid, {
  stoneRowFromApi,
  type SubDetailRow,
  type useSubDetail,
} from './SubDetailGrid';
import { ExtendedBodyCells, ExtendedHeaderCells, GridModeToggle } from './ExtendedGrid';

export interface ApprovalLine {
  origSrNo: string;
  oldSrNo: string;
  vchSrno: string;
  itCode: string;
  tagNo: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  fineWt: string;
  lotNo: string;
  itmColor: string;
  tagCost: string;
  hallmarkId2: string;
  hallmarkId3: string;
  hallmarkId4: string;
  hallmarkIdWt: string;
  hallmarkId2Wt: string;
  hallmarkId3Wt: string;
  hallmarkId4Wt: string;
  adjustGrossWt: string;
  adjustNetWt: string;
  lessTouch: string;
  lossWt: string;
  remark: string;
  isuAcName: string;
  metalColor: string;
  isuAcCode: string;
  tblCode: string;
  designNo: string;
  itmSize: string;
  huid: string;
  bagWt: string;
  lessWt: string;
  ghtWt: string;
  westPct: string;
  labourPct: string;
  labourType: string;
  labourRate: string;
  labourAmount: string;
  otherAmount: string;
  rate: string;
  amount: string;
  mrp: string;
  karigarNetWt: string;
  karigarTouch: string;
  karigarWestPct: string;
  karigarFine: string;
  karigarName: string;
  rateType: string;
  prCode: string;
  isuYrcd: string;
  isuDbcd: string;
  isuLcCode: string;
  isuSrNo: string;
  designImageId: string;
}

export const blankApprovalLine = (): ApprovalLine => ({
  origSrNo: '',
  oldSrNo: '',
  vchSrno: '',
  itCode: '',
  tagNo: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  fineWt: '',
  lotNo: '',
  itmColor: '',
  tagCost: '',
  hallmarkId2: '',
  hallmarkId3: '',
  hallmarkId4: '',
  hallmarkIdWt: '',
  hallmarkId2Wt: '',
  hallmarkId3Wt: '',
  hallmarkId4Wt: '',
  adjustGrossWt: '',
  adjustNetWt: '',
  lessTouch: '',
  lossWt: '',
  remark: '',
  isuAcName: '',
  metalColor: '',
  isuAcCode: '',
  tblCode: '',
  designNo: '',
  itmSize: '',
  huid: '',
  bagWt: '',
  lessWt: '',
  ghtWt: '',
  westPct: '',
  labourPct: '',
  labourType: '',
  labourRate: '',
  labourAmount: '',
  otherAmount: '',
  rate: '',
  amount: '',
  mrp: '',
  karigarNetWt: '',
  karigarTouch: '',
  karigarWestPct: '',
  karigarFine: '',
  karigarName: '',
  rateType: '',
  prCode: '',
  isuYrcd: '',
  isuDbcd: '',
  isuLcCode: '',
  isuSrNo: '',
  designImageId: '',
});

const fields = Object.keys(blankApprovalLine()) as Array<keyof ApprovalLine>;
export function approvalLineFromApi(raw: Record<string, unknown>): ApprovalLine {
  const line = blankApprovalLine();
  for (const field of fields) {
    const value = raw[field];
    if (value != null && String(value) !== '0') line[field] = String(value);
  }
  if (!line.pcs) line.pcs = '0';
  if (line.tagNo === 'N') line.tagNo = '';
  return line;
}

const NUMERIC = new Set<keyof ApprovalLine>([
  'origSrNo',
  'oldSrNo',
  'vchSrno',
  'pcs',
  'grossWt',
  'netWt',
  'touch',
  'fineWt',
  'tagCost',
  'hallmarkIdWt',
  'hallmarkId2Wt',
  'hallmarkId3Wt',
  'hallmarkId4Wt',
  'adjustGrossWt',
  'adjustNetWt',
  'lessTouch',
  'lossWt',
  'bagWt',
  'lessWt',
  'ghtWt',
  'westPct',
  'labourPct',
  'labourRate',
  'labourAmount',
  'otherAmount',
  'rate',
  'amount',
  'mrp',
  'karigarNetWt',
  'karigarTouch',
  'karigarWestPct',
  'karigarFine',
  'isuSrNo',
]);

export function approvalLineInput(line: ApprovalLine, stones?: Record<string, unknown>[]) {
  const out: Record<string, unknown> = {};
  for (const field of fields) {
    const value = line[field].trim();
    if (!value) continue;
    out[field] = NUMERIC.has(field) ? Number(value) : value;
  }
  if (stones?.length) out.stones = stones;
  return out;
}

export function approvalStonesFromApi(raw: Record<string, unknown>): SubDetailRow[] {
  const stones = Array.isArray(raw.stones) ? raw.stones : [];
  return stones.length
    ? stones.map((stone) => stoneRowFromApi(stone as Record<string, unknown>))
    : [{}];
}

export type ApprovalExtendedField = [keyof ApprovalLine, string];

const number = (value: string) => Number(value || 0);
export const approvalFine = (line: ApprovalLine) =>
  line.fineWt.trim()
    ? Number(line.fineWt)
    : round((number(line.netWt) * number(line.touch)) / 100, 3);

export function ApprovalGrid({
  kind,
  lines,
  setLines,
  full,
  setFull,
  extended,
  sub,
  disabled,
}: {
  kind: 'issue' | 'return';
  lines: ApprovalLine[];
  setLines: React.Dispatch<React.SetStateAction<ApprovalLine[]>>;
  full: boolean;
  setFull: React.Dispatch<React.SetStateAction<boolean>>;
  extended: ApprovalExtendedField[];
  sub: ReturnType<typeof useSubDetail>;
  disabled?: boolean;
}) {
  const set = (row: number, field: keyof ApprovalLine, value: string) =>
    setLines((current) =>
      current.map((line, index) => (index === row ? { ...line, [field]: value } : line)),
    );
  const add = () => {
    setLines((current) => [...current, blankApprovalLine()]);
    sub.appendLine();
  };
  const remove = (row: number) => {
    setLines((current) =>
      current.length === 1 ? [blankApprovalLine()] : current.filter((_, i) => i !== row),
    );
    sub.removeLine(row);
  };
  const keyboard = useGridKeyboard({
    rowCount: lines.length,
    onAppendRow: add,
    onRemoveRow: (row) => {
      remove(row);
      return true;
    },
    onEscape: () => {},
  });
  const fillTag = (row: number, value: Record<string, unknown>) => {
    setLines((current) =>
      current.map((line, index) =>
        index === row
          ? {
              ...line,
              tagNo: String(value.code ?? ''),
              vchSrno: String(value.VCH_SRNO ?? ''),
              itCode: String(value.IT_CODE ?? line.itCode),
              pcs: String(value.ITM_PCS ?? line.pcs),
              grossWt: String(value.ITM_GWT ?? line.grossWt),
              netWt: String(value.ITM_NWT ?? line.netWt),
              touch: String(value.ITM_TOUCH ?? line.touch),
              fineWt: String(value.ITM_FINE ?? line.fineWt),
              tblCode: String(value.TBL_CODE ?? line.tblCode),
              designNo: String(value.DESIGN_NO ?? line.designNo),
              itmSize: String(value.ITM_SIZE ?? line.itmSize),
              huid: String(value.HM_ID ?? line.huid),
              labourType: String(value.LBR_TYPE ?? line.labourType),
              labourRate: String(value.LBR_RATE ?? line.labourRate),
              labourAmount: String(value.LBR_AMT ?? line.labourAmount),
              otherAmount: String(value.OTH_AMT ?? line.otherAmount),
              rate: String(value.ITM_RATE ?? line.rate),
              mrp: String(value.ITM_MRP ?? line.mrp),
              karigarName: String(value.KR_NAME ?? line.karigarName),
              prCode: String(value.PR_CODE ?? line.prCode),
            }
          : line,
      ),
    );
  };
  return (
    <div className="panel" style={{ overflow: 'auto' }}>
      <div className="toolbar">
        <h2>{kind === 'issue' ? 'Items issued on approval' : 'Items returned'}</h2>
        <span className="spacer" />
        <GridModeToggle
          full={full}
          setFull={setFull}
          extendedCount={extended.length}
          testId={`approval-${kind}-grid-mode`}
        />
      </div>
      <table className="grid" onKeyDown={keyboard}>
        <thead>
          <tr>
            {kind === 'return' && <th>Orig Sr</th>}
            <th>Item</th>
            <th>Tag</th>
            <th>Pcs</th>
            <th>Gross</th>
            <th>Net Wt</th>
            <th>Touch%</th>
            <th>Fine</th>
            <ExtendedHeaderCells full={full} fields={extended} />
            <th></th>
          </tr>
        </thead>
        <tbody>
          {lines.map((line, row) => (
            <tr key={row} onFocus={() => sub.setActiveLine(row)}>
              {kind === 'return' && (
                <td>
                  <input aria-label={`Orig Sr line ${row + 1}`} value={line.origSrNo} readOnly />
                </td>
              )}
              <td>
                {kind === 'issue' ? (
                  <LookupPicker
                    entity="items"
                    value={line.itCode}
                    onChange={(v) => set(row, 'itCode', v)}
                    ariaLabel={`ItCode line ${row + 1}`}
                  />
                ) : (
                  <input aria-label={`ItCode line ${row + 1}`} value={line.itCode} readOnly />
                )}
              </td>
              <td>
                {kind === 'issue' ? (
                  <LookupPicker
                    entity="available-tags"
                    value={line.tagNo}
                    onChange={(v) => set(row, 'tagNo', v)}
                    onPick={(value) => fillTag(row, value)}
                    ariaLabel={`TagNo line ${row + 1}`}
                  />
                ) : (
                  <input aria-label={`TagNo line ${row + 1}`} value={line.tagNo} readOnly />
                )}
              </td>
              {(['pcs', 'grossWt', 'netWt', 'touch'] as const).map((field) => (
                <td key={field}>
                  <input
                    aria-label={`${field === 'pcs' ? 'Pcs' : field === 'grossWt' ? 'GrWt' : field === 'netWt' ? 'NetWt' : 'Touch'} line ${row + 1}`}
                    value={line[field]}
                    onChange={(event) => set(row, field, event.target.value)}
                    readOnly={kind === 'return'}
                  />
                </td>
              ))}
              <td>{approvalFine(line).toLocaleString('en-IN')}</td>
              <ExtendedBodyCells
                full={full}
                fields={extended}
                line={line}
                row={row}
                baseColumns={kind === 'return' ? 9 : 8}
                setValue={set}
                readOnlyFields={kind === 'return' ? extended.map(([field]) => field) : undefined}
              />
              <td>
                <button
                  type="button"
                  className="danger"
                  aria-label={`Remove line ${row + 1}`}
                  onClick={() => remove(row)}
                  disabled={disabled}
                >
                  ×
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      <button type="button" className="ghost" onClick={add} disabled={disabled}>
        + Add line
      </button>
      <SubDetailGrid
        rows={sub.rowsFor(sub.activeLine)}
        onRowsChange={(rows) => sub.setRowsFor(sub.activeLine, rows)}
        parentLabel={`line ${sub.activeLine + 1}`}
        desktopSource="TR_APR_ISU / MSG_IDTL"
        disabled={disabled || kind === 'return'}
        testId={`approval-${kind}-stones`}
      />
    </div>
  );
}
