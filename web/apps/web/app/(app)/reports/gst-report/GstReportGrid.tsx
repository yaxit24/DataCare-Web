import type { GstReportResult } from './types';

/** RP_GST's grid is flat: server-owned columns, display strings and totals in desktop order. */
export function GstReportGrid({ report }: { report: GstReportResult }) {
  return (
    <div className="panel" style={{ overflow: 'auto' }}>
      <h2 style={{ marginTop: 0 }}>{report.title}</h2>
      <table className="grid">
        <thead>
          <tr>
            {report.columns.map((column) => (
              <th key={column.key}>{column.header}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          {report.rows.map((row, index) => (
            <tr key={`${report.section ?? report.view}-${index}`}>
              {report.columns.map((column) => (
                <td key={column.key}>{row[column.key] ?? ''}</td>
              ))}
            </tr>
          ))}
          {report.rows.length === 0 && (
            <tr>
              <td colSpan={report.columns.length || 1} className="muted">
                No Record Found....
              </td>
            </tr>
          )}
        </tbody>
        {Object.keys(report.totals).length > 0 && (
          <tfoot>
            <tr className="totals">
              {report.columns.map((column, index) => (
                <td key={column.key}>
                  {report.totals[column.key] ?? (index === 0 ? 'TOTAL' : '')}
                </td>
              ))}
            </tr>
          </tfoot>
        )}
      </table>
      {(report.metadata.blockedSections?.length || report.metadata.blockedRows?.length) && (
        <p className="muted" role="note" style={{ marginBottom: 0 }}>
          Source-incomplete desktop areas remain blocked:{' '}
          {[
            ...(report.metadata.blockedSections ?? []),
            ...(report.metadata.blockedRows ?? []),
          ].join(', ')}
        </p>
      )}
    </div>
  );
}
