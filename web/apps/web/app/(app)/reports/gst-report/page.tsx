'use client';
import { useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { LookupPicker } from '../../../../components/LookupPicker';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { GstReportGrid } from './GstReportGrid';
import { useGstReport } from './useGstReport';
import type { GstSection } from './types';

/**
 * Report → Gst Report, the non-UAE desktop RP_GST screen (MDI_FORM.cs:8951-8971).
 * RP_GST.cs:1637-1717 supplies the section order/defaults; :2640-3031 the GSTR-1 grid;
 * :3148-3477 GSTR-2; :3479-3817 the source-settled GSTR-3B rows; :3077-3146 CSV.
 * The Lite mission deliberately exposes the grid/outputs that the desktop registration flag hid.
 */
const SECTIONS: Array<{ value: GstSection; label: string }> = [
  { value: '', label: '' },
  { value: 'B2B', label: 'B2B - Bill to Bill' },
  { value: 'B2CL', label: 'B2CL - B2C Large' },
  { value: 'B2CS', label: 'B2CS - B2C Small' },
  { value: 'CDNR', label: 'CDNR - Credit/Debit Note' },
  { value: 'CDNUR', label: 'CDNUR - Credit/Debit Note Unregistered' },
  { value: 'EXP', label: 'EXP - Export' },
  { value: 'AT', label: 'AT - Tax liability on Advances' },
  { value: 'ATADJ', label: 'ATADJ - Advance Adjustments' },
  { value: 'EXEMP', label: 'EXEMP - Intra-State Supp to Unreg persons' },
  { value: 'HSN', label: 'HSN - Summary For HSN' },
  { value: 'DOCS', label: 'DOCS - Summary Of Issue Rec Bill' },
];

const code = (value: string): string => value.replaceAll("'", '').toUpperCase();

export default function GstReportPage() {
  const router = useRouter();
  const { coYear } = useBusinessScope();
  const report = useGstReport(coYear);
  const { filters, setFilters } = report;

  useEffect(() => {
    const onKey = (event: KeyboardEvent) => {
      if (event.key !== 'Escape' || event.defaultPrevented) return;
      if (document.querySelector('[data-lookup-open]')) return;
      router.back();
    };
    document.addEventListener('keydown', onKey);
    return () => document.removeEventListener('keydown', onKey);
  }, [router]);

  return (
    <div>
      <h1>GST Report</h1>
      <div className="panel">
        <div className="row">
          <div className="field">
            <label htmlFor="gst-from">From Date</label>
            <input
              id="gst-from"
              type="date"
              min={report.bounds.start}
              max={report.bounds.end}
              value={filters.fromDate}
              autoFocus
              onChange={(event) => setFilters({ fromDate: event.target.value })}
            />
          </div>
          <div className="field">
            <label htmlFor="gst-to">To Date</label>
            <input
              id="gst-to"
              type="date"
              min={report.bounds.start}
              max={report.bounds.end}
              value={filters.toDate}
              onChange={(event) => setFilters({ toDate: event.target.value })}
            />
          </div>
          <div className="field" style={{ minWidth: 150 }}>
            <label>Book</label>
            <LookupPicker
              entity="books"
              ariaLabel="Book"
              value={filters.bookCode}
              resolveTypedCode
              onChange={(value) => setFilters({ bookCode: code(value) })}
              onPick={(row) => setFilters({ bookCode: String(row.code) })}
            />
          </div>
          <div className="field" style={{ minWidth: 190 }}>
            <label>Party</label>
            <LookupPicker
              entity="accounts"
              ariaLabel="Party"
              value={filters.partyCode}
              resolveTypedCode
              onChange={(value) => setFilters({ partyCode: code(value) })}
              onPick={(row) => setFilters({ partyCode: String(row.code) })}
            />
          </div>
          <div className="field" style={{ minWidth: 270 }}>
            <label htmlFor="gst-section">Section Type</label>
            <select
              id="gst-section"
              aria-label="Section Type"
              value={filters.section}
              onChange={(event) => setFilters({ section: event.target.value as GstSection })}
            >
              {SECTIONS.map((section) => (
                <option key={section.value || 'blank'} value={section.value}>
                  {section.label}
                </option>
              ))}
            </select>
          </div>
        </div>
        <div className="row" style={{ marginTop: 10 }}>
          <button
            type="button"
            className="primary"
            disabled={report.busyView !== null}
            onClick={() => void report.run('gstr1')}
          >
            {report.busyView === 'gstr1' ? 'Running…' : 'Gstr 1'}
          </button>
          <button
            type="button"
            className="ghost"
            disabled={report.busyView !== null}
            onClick={() => void report.run('gstr2')}
          >
            {report.busyView === 'gstr2' ? 'Running…' : 'Gstr 2'}
          </button>
          <button
            type="button"
            className="ghost"
            disabled={report.busyView !== null}
            onClick={() => void report.run('gstr3b')}
          >
            {report.busyView === 'gstr3b' ? 'Running…' : 'Gstr 3'}
          </button>
          <span className="spacer" />
          <button type="button" className="ghost" disabled={!report.ranQuery} onClick={report.csv}>
            Csv Fil
          </button>
          <button type="button" className="ghost" disabled={!report.ranQuery} onClick={report.xlsx}>
            Gsrt1 Csv
          </button>
          <button
            type="button"
            className="ghost"
            disabled={!report.ranQuery}
            onClick={() => void report.pdf()}
          >
            Download PDF
          </button>
          <button type="button" className="ghost" onClick={() => router.back()}>
            Exit
          </button>
        </div>
      </div>

      {report.error && (
        <div className="msg err" role="alert" data-testid="gst-report-error">
          {report.error}
        </div>
      )}
      {!report.error && report.message && (
        <div className="msg" role="status">
          {report.message}
        </div>
      )}
      {report.report && <GstReportGrid report={report.report} />}
    </div>
  );
}
