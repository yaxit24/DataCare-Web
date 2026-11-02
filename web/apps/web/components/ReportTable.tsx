import { formatReportCell, type ReportCellDescriptors } from '../lib/reportPresentation';

export type ReportRow = Record<string, unknown>;

type ReportTableProps = {
  rows: ReportRow[];
  onRowClick?: (row: ReportRow) => void;
  cellDescriptors?: ReportCellDescriptors;
};

export function ReportTable({ rows, onRowClick, cellDescriptors }: ReportTableProps) {
  if (!rows.length) return <p className="muted">No rows.</p>;
  const cols = Object.keys(rows[0]);
  const isNum = (v: unknown) =>
    typeof v === 'number' || (!isNaN(Number(v)) && v !== '' && v !== null);
  return (
    <table className="grid">
      <thead>
        <tr>
          {cols.map((c) => (
            <th key={c} className={isNum(rows[0][c]) ? 'num' : ''}>
              {c}
            </th>
          ))}
        </tr>
      </thead>
      <tbody>
        {rows.map((r, i) => (
          <tr
            key={i}
            onClick={onRowClick ? () => onRowClick(r) : undefined}
            style={onRowClick ? { cursor: 'pointer' } : undefined}
          >
            {cols.map((c) => (
              <td key={c} className={isNum(r[c]) ? 'num' : ''}>
                {formatReportCell(r[c], cellDescriptors?.[c])}
              </td>
            ))}
          </tr>
        ))}
      </tbody>
    </table>
  );
}
