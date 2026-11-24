import { formatCell, type SalesResult, type SalesRowLevel } from './types';

/**
 * The grid, CSV, XLSX and print are built from one server result. The display lines follow the same order as
 * exportRows.ts: each group band, its printed rows, its subtotal, then the grand total in the footer. Totals are
 * the server's; nothing is summed here.
 */
export interface DisplayLine {
  kind: 'band' | 'row' | 'subtotal';
  label?: string;
  level?: SalesRowLevel;
  /** `lcCode|coBook|vchNo` of a printed row, for the zoom to the voucher. */
  voucherKey?: string;
  cells: Record<string, string>;
}

export function buildLines(report: SalesResult): DisplayLine[] {
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
      lines.push({ kind: 'row', level: row.level, voucherKey: row.voucherKey, cells });
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
    else if (label.trim() !== '') lines.push({ kind: 'band', label, cells: {} });
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

/** The report as text rows: head, body and the grand-total footer, the same cells the CSV carries. */
export function reportTable(report: SalesResult): {
  head: string[];
  body: string[][];
  foot: string[][];
} {
  const lines = buildLines(report);
  const head = ['Band', ...report.columns.map((column) => column.caption)];
  const body = lines.map((line) => [
    line.label ?? line.level ?? '',
    ...report.columns.map((column) => line.cells[column.key] ?? ''),
  ]);
  const foot = report.grandTotal
    ? [
        [
          report.grandTotalCaption ?? 'Total',
          ...report.columns.map((column) =>
            column.total ? formatCell(column.kind, report.totals[column.key] ?? 0) : '',
          ),
        ],
      ]
    : [];
  return { head, body, foot };
}

/** Print: a preview window with the whole report as one table (the desktop opens the Crystal preview). */
export function openPrintPreview(report: SalesResult): void {
  const preview = window.open('', '_blank');
  if (!preview) return;
  const { head, body, foot } = reportTable(report);
  const doc = preview.document;
  doc.title = report.title;
  const style = doc.createElement('style');
  style.textContent =
    'body{font:12px sans-serif;margin:16px}table{border-collapse:collapse;width:100%}' +
    'th,td{border:1px solid #999;padding:2px 6px;text-align:left}thead{display:table-header-group}';
  doc.head.appendChild(style);
  const title = doc.createElement('h2');
  title.textContent = report.title;
  const table = doc.createElement('table');
  const section = (tag: 'thead' | 'tbody' | 'tfoot', rows: string[][], cell: 'th' | 'td') => {
    const element = doc.createElement(tag);
    for (const values of rows) {
      const tr = doc.createElement('tr');
      for (const value of values) {
        const td = doc.createElement(cell);
        td.textContent = value;
        tr.appendChild(td);
      }
      element.appendChild(tr);
    }
    table.appendChild(element);
  };
  section('thead', [head], 'th');
  section('tbody', body, 'td');
  if (foot.length) section('tfoot', foot, 'td');
  doc.body.replaceChildren(title, table);
}

export function SalesReportGrid({
  report,
  onZoom,
}: {
  report: SalesResult;
  onZoom: (voucherKey: string) => void;
}) {
  const lines = buildLines(report);
  const { foot } = reportTable(report);
  return (
    <div className="panel" style={{ overflow: 'auto' }}>
      <h2 style={{ marginTop: 0 }}>{report.title}</h2>
      <table className="grid">
        <thead>
          <tr>
            <th>Band</th>
            {report.columns.map((column) => (
              <th key={column.key}>{column.caption}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          {lines.map((line, index) => (
            <tr
              key={`${line.kind}-${index}`}
              className={line.kind}
              tabIndex={line.voucherKey ? 0 : undefined}
              title={
                line.voucherKey ? 'Double-click or press Enter to open the voucher' : undefined
              }
              onDoubleClick={() => line.voucherKey && onZoom(line.voucherKey)}
              onKeyDown={(event) => {
                if (
                  event.key === 'Enter' &&
                  line.voucherKey &&
                  event.target === event.currentTarget
                ) {
                  event.preventDefault();
                  onZoom(line.voucherKey);
                }
              }}
            >
              <td>{line.label ?? line.level ?? ''}</td>
              {report.columns.map((column) => (
                <td key={column.key}>{line.cells[column.key] ?? ''}</td>
              ))}
            </tr>
          ))}
        </tbody>
        {foot.length > 0 && (
          <tfoot>
            {foot.map((values, index) => (
              <tr key={index} className="totals">
                {values.map((value, cell) => (
                  <td key={cell}>{value}</td>
                ))}
              </tr>
            ))}
          </tfoot>
        )}
      </table>
      {lines.length === 0 && <p className="muted">No Record Found....</p>}
    </div>
  );
}
