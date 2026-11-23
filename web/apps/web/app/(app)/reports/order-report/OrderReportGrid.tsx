import { formatCell, type OrderColumn, type OrderResult, type OrderRowLevel } from './types';

/**
 * The grid, CSV and XLSX are built from one server result. These display lines follow the same order as
 * exportRows.ts: each group band, its printed rows, its subtotal, then the grand total in the footer. A
 * suppressed detail band (Making Summ answered Yes) still prints its group bands and every total.
 */
type DisplayLine = {
  kind: 'band' | 'row' | 'subtotal';
  label?: string;
  level?: OrderRowLevel;
  cells: Record<string, string>;
};

function buildLines(report: OrderResult): DisplayLine[] {
  const lines: DisplayLine[] = [];
  const subtotalOf = new Map(report.groupLevels.map((level, depth) => [depth, level]));
  const totalLine = (label: string, totals: Record<string, number>): DisplayLine => {
    const cells: Record<string, string> = {};
    for (const column of report.columns)
      if (totals[column.key] !== undefined)
        cells[column.key] = formatCell(column.kind, totals[column.key] ?? null);
    return { kind: 'subtotal', label, cells };
  };
  let rowIndex = 0;
  const pathKey = (path: string[]) => path.join('\u0000');
  const flush = (key: string | null) => {
    while (
      rowIndex < report.rows.length &&
      (key === null || pathKey(report.rows[rowIndex]!.groupPath) === key)
    ) {
      const row = report.rows[rowIndex]!;
      const cells: Record<string, string> = {};
      for (const column of report.columns)
        if (column.level === row.level)
          cells[column.key] = formatCell(column.kind, row.cells[column.key] ?? null);
      lines.push({ kind: 'row', level: row.level, cells });
      rowIndex += 1;
    }
  };
  for (let index = 0; index < report.groups.length; index += 1) {
    const group = report.groups[index]!;
    const level = subtotalOf.get(group.depth);
    if (!level) continue;
    const isLeaf = group.depth === report.groupLevels.length - 1;
    const label = `${'  '.repeat(group.depth)}${group.label}`;
    if (level.subtotal === 'header') lines.push(totalLine(label, group.totals));
    else lines.push({ kind: 'band', label, cells: {} });
    if (isLeaf) {
      flush(pathKey(group.groupPath));
      if (level.subtotal === 'footer')
        lines.push(totalLine(level.subtotalCaption ?? 'Total', group.totals));
    }
    const next = report.groups[index + 1];
    for (let depth = group.depth - 1; depth >= 0; depth -= 1) {
      const outer = subtotalOf.get(depth);
      if (!outer || (next && next.depth > depth)) continue;
      if (outer.subtotal !== 'footer') continue;
      const outerGroup = [...report.groups.slice(0, index + 1)]
        .reverse()
        .find((g) => g.depth === depth);
      if (outerGroup) lines.push(totalLine(outer.subtotalCaption ?? 'Total', outerGroup.totals));
    }
  }
  flush(null);
  return lines;
}

function firstCell(column: OrderColumn, line: DisplayLine): string {
  if (line.kind === 'band') return line.label ?? '';
  if (line.kind === 'subtotal') return line.label ?? '';
  return line.cells[column.key] ?? '';
}

export function OrderReportGrid({ report }: { report: OrderResult }) {
  const lines = buildLines(report);
  return (
    <div className="panel" style={{ overflow: 'auto' }}>
      <h2 style={{ marginTop: 0 }}>{report.title}</h2>
      <table className="grid">
        <thead>
          <tr>
            {report.columns.map((column) => (
              <th key={column.key}>{column.caption}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          {lines.map((line, index) => (
            <tr key={`${line.kind}-${index}`} className={line.kind}>
              {line.kind === 'band' ? (
                <td colSpan={report.columns.length || 1}>{line.label}</td>
              ) : (
                report.columns.map((column, columnIndex) => (
                  <td key={column.key}>
                    {columnIndex === 0 && line.kind === 'subtotal'
                      ? firstCell(column, line)
                      : (line.cells[column.key] ?? '')}
                  </td>
                ))
              )}
            </tr>
          ))}
        </tbody>
        {report.grandTotal && (
          <tfoot>
            <tr className="totals">
              {report.columns.map((column) => (
                <td key={column.key}>
                  {column.total ? formatCell(column.kind, report.totals[column.key] ?? 0) : ''}
                </td>
              ))}
            </tr>
          </tfoot>
        )}
      </table>
      {lines.length === 0 && <p className="muted">No Record Found....</p>}
    </div>
  );
}
