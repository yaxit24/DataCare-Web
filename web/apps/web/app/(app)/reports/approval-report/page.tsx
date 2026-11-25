'use client';
import { useCallback, useEffect, useRef, useState, type KeyboardEvent } from 'react';
import { useRouter } from 'next/navigation';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { focusNext } from '../../../../components/focus';
import { get } from '../../../../lib/api';
import { openDocument } from '../../../../lib/openDocument';
import { useScreenEscape, type ScreenKeyEvent } from '../../../../lib/screenEscape';
import { ApprovalReportGrid } from './ApprovalReportGrid';
import { ListField } from './ListField';
import { LookupField, desktopText, focusControl, type HelpRow } from './LookupField';
import { ITEM_TYPES, setDate, type ApprovalReportMode } from './types';
import { approvalQuery, useApprovalReport } from './useApprovalReport';

/**
 * Report → Approval Rpt: the desktop RP_ALL form opened with the "Approval Rpt" menu caption
 * (MDI_FORM.cs:8921 {{case "Approval Rpt":}}; RP_ALL.cs:6658 {{CurRpt = DC_Main.MsUserRightForm;}}), which shows
 * PanelApr over the sales panel (RP_ALL.cs:6707-6711). The three buttons open AprPartyWise, AprInOut and AprPan.
 */
const CAPTION = 'Approval Rpt';

/** PanelApr in tab order; the ampersand is the WinForms mnemonic, shown underlined (RP_ALL.cs:5165, :5191, :5217). */
const BUTTONS: ReadonlyArray<{ mode: ApprovalReportMode; caption: string }> = [
  { mode: 'issue', caption: 'Approval Isu' },
  { mode: 'inout', caption: 'Approval InOut' },
  { mode: 'pending', caption: 'Approval Panding' },
];

/** A caption with its WinForms mnemonic letter underlined; the accessible name stays the plain caption. */
function Mnemonic({ text, at }: { text: string; at: number }) {
  return (
    <>
      {text.slice(0, at)}
      <u>{text.charAt(at)}</u>
      {text.slice(at + 1)}
    </>
  );
}

export default function ApprovalReportPage() {
  const router = useRouter();
  const { lcCode, coYear } = useBusinessScope();
  const report = useApprovalReport(lcCode);
  const { filters, setFilters } = report;
  const [message, setMessage] = useState('');
  const locations = useRef<Promise<HelpRow[]> | null>(null);
  const [cities, setCities] = useState<string[]>([]);
  const [areas, setAreas] = useState<string[]>([]);

  // Esc closes the form from any control (RP_ALL.cs:7261 {{if ((int)e.KeyCode == 27)}}; :7263 Close()).
  const onEscape = useCallback(
    (event: ScreenKeyEvent) => {
      if (event.key !== 'Escape' || event.defaultPrevented) return;
      event.preventDefault();
      router.back();
    },
    [router],
  );
  const screenRef = useScreenEscape<HTMLFormElement>(onEscape);

  const runMode = useCallback(
    async (mode: ApprovalReportMode) => {
      const built = approvalQuery(mode, filters, lcCode);
      if (built.error) {
        setMessage(built.error);
        return;
      }
      setMessage('');
      await report.run(mode);
    },
    [filters, lcCode, report],
  );

  /**
   * From/To Enter: DC_Main.SetDate completes or refuses the mask, and the form tabs only when RongDate is false
   * (RP_ALL.cs:7517-7521, :7533-7537). A refused date shows the desktop message, resets the mask and SelectAlls.
   */
  const onDateKey = (field: 'fromDate' | 'toDate') => (event: KeyboardEvent<HTMLInputElement>) => {
    if (event.key !== 'Enter') return;
    event.preventDefault();
    const input = event.currentTarget;
    const outcome = setDate(filters[field], { coYear, today: new Date() });
    setFilters({ [field]: outcome.text });
    if (!outcome.ok) {
      setMessage(outcome.message ?? '');
      requestAnimationFrame(() => input.select());
      return;
    }
    setMessage('');
    focusNext(input);
  };

  // Book help lists the company's books ordered by BOOK_NAME (RP_ALL.cs:7303 {{ORDER BY A.BOOK_NAME}}).
  const loadBooks = useCallback(async (term: string) => {
    const rows = await get<HelpRow[]>(`/lookup/books?q=${encodeURIComponent(term)}&limit=50`);
    return [...rows].sort((a, b) => String(a.name ?? '').localeCompare(String(b.name ?? '')));
  }, []);
  const loadAccounts = useCallback(
    (term: string) => get<HelpRow[]>(`/lookup/accounts?q=${encodeURIComponent(term)}&limit=50`),
    [],
  );
  // Pr Code matches PRODUCT_MAST.PR_CODE (RP_ALL.cs:7477 {{AND PR_CODE}}), never ITEM_MAST.IT_CODE.
  const loadProducts = useCallback(
    (term: string) => get<HelpRow[]>(`/lookup/products?q=${encodeURIComponent(term)}&limit=50`),
    [],
  );
  // Gr Code reads GROUP_MAST (RP_ALL.cs:9265 {{Select * From GROUP_MAST}}).
  const loadGroups = useCallback(
    (term: string) => get<HelpRow[]>(`/lookup/groups?q=${encodeURIComponent(term)}&limit=50`),
    [],
  );
  // lc Code reads LOCT_MAST (RP_ALL.cs:7691 {{Select * From LOCT_MAST}}).
  const loadLocations = useCallback(async () => {
    locations.current ??= get<Array<{ LC_CODE: string; LC_NAME: string | null }>>(
      '/context/locations',
    )
      .then((rows) => rows.map((row) => ({ code: row.LC_CODE, name: row.LC_NAME ?? '' })))
      .catch((error: unknown) => {
        locations.current = null;
        throw error;
      });
    return locations.current;
  }, []);

  // City and Area list the distinct live AC_MAST values when the form opens (RP_ALL.cs:7087, :7121).
  useEffect(() => {
    let live = true;
    const distinct = (rows: Array<{ code: unknown }>) =>
      [...new Set(rows.map((row) => String(row.code ?? '').trim()).filter(Boolean))].sort();
    get<Array<{ code: unknown }>>('/lookup/cities?limit=50')
      .then((rows) => live && setCities(distinct(rows)))
      .catch(() => undefined);
    get<Array<{ code: unknown }>>('/lookup/areas?limit=50')
      .then((rows) => live && setAreas(distinct(rows)))
      .catch(() => undefined);
    return () => {
      live = false;
    };
  }, []);

  const error = message || report.error;
  const exports = (['csv', 'xlsx', 'pdf'] as const).map((extension) => ({
    extension,
    path: report.exportPath(extension),
  }));

  return (
    <div>
      <h1>{CAPTION}</h1>
      <form
        ref={screenRef}
        aria-label={CAPTION}
        onKeyDown={onEscape}
        onSubmit={(event) => event.preventDefault()}
      >
        <div className="panel">
          <div className="row">
            <div className="field">
              <label htmlFor="ar-from">From / To Date</label>
              <input
                id="ar-from"
                aria-label="From"
                value={filters.fromDate}
                autoFocus
                maxLength={10}
                onFocus={(event) => event.currentTarget.select()}
                onChange={(event) => setFilters({ fromDate: event.target.value })}
                onKeyDown={onDateKey('fromDate')}
              />
            </div>
            <div className="field">
              <label htmlFor="ar-to">&nbsp;</label>
              <input
                id="ar-to"
                aria-label="To"
                value={filters.toDate}
                maxLength={10}
                onFocus={(event) => event.currentTarget.select()}
                onChange={(event) => setFilters({ toDate: event.target.value })}
                onKeyDown={onDateKey('toDate')}
              />
            </div>
            <LookupField
              label="lc Code"
              value={filters.lcCode}
              disabled={lcCode !== '00'}
              onChange={(value) => setFilters({ lcCode: value })}
              load={loadLocations}
              maxLength={8}
              focusAfter="Book"
            />
            <LookupField
              label="Book"
              value={filters.bookCode}
              onChange={(value) => setFilters({ bookCode: value })}
              load={loadBooks}
              maxLength={8}
              focusAfter="Pr Code"
            />
            <LookupField
              label="Pr Code"
              value={filters.prCode}
              onChange={(value) => setFilters({ prCode: value })}
              load={loadProducts}
              maxLength={8}
              focusAfter="Gr Code"
              blankFocus="City"
            />
            <LookupField
              label="Gr Code"
              value={filters.grCode}
              onChange={(value) => setFilters({ grCode: value })}
              load={loadGroups}
              maxLength={8}
              focusAfter="Party Code"
              helpOnBlank
            />
            <LookupField
              label="Party Code"
              value={filters.partyCode}
              onChange={(value) => setFilters({ partyCode: value })}
              load={loadAccounts}
              maxLength={8}
              focusAfter="Cust Name"
            />
            <div className="field" style={{ minWidth: 140 }}>
              <label htmlFor="ar-Cust-Name">Cust Name</label>
              <input
                id="ar-Cust-Name"
                aria-label="Cust Name"
                value={filters.custName}
                maxLength={50}
                onChange={(event) => setFilters({ custName: desktopText(event.target.value) })}
                onKeyDown={(event) => {
                  if (event.key !== 'Enter') return;
                  event.preventDefault();
                  // Outside the Order caption Enter clears the box and jumps to City (RP_ALL.cs:9717-9718).
                  setFilters({ custName: '' });
                  focusControl('City');
                }}
              />
            </div>
            <ListField
              label="City"
              value={filters.city}
              options={cities}
              onChange={(value) => setFilters({ city: value })}
            />
            <ListField
              label="Area"
              value={filters.area}
              options={areas}
              onChange={(value) => setFilters({ area: value })}
            />
            <div className="field" style={{ minWidth: 130 }}>
              <label htmlFor="ar-item-type">Item Type</label>
              <select
                id="ar-item-type"
                aria-label="Item Type"
                value={filters.itemType}
                onChange={(event) => setFilters({ itemType: event.target.value })}
                onKeyDown={(event) => {
                  if (event.key !== 'Enter') return;
                  event.preventDefault();
                  focusNext(event.currentTarget);
                }}
              >
                {ITEM_TYPES.map((type) => (
                  <option key={type} value={type}>
                    {type}
                  </option>
                ))}
              </select>
            </div>
          </div>
          <div className="row" data-panel="approval" style={{ marginTop: 10 }}>
            {BUTTONS.map((button) => (
              <button
                key={button.mode}
                type="button"
                className="ghost"
                aria-label={button.caption}
                disabled={report.busy}
                onClick={() => void runMode(button.mode)}
              >
                <Mnemonic text={button.caption} at={0} />
              </button>
            ))}
          </div>
          <div className="row" data-panel="bottom" style={{ marginTop: 8 }}>
            {/* PnlBotam (RP_ALL.cs:4266-4270). Save and Delete have no click handler (RP_ALL.cs:521, :565) and
                the bottom Print handler is empty (RP_ALL.cs:7267-7270): none of them writes or prints. */}
            <button type="button" className="ghost" aria-label="Save">
              <Mnemonic text="Save" at={0} />
            </button>
            <button type="button" className="ghost" aria-label="Delete">
              <Mnemonic text="Delete" at={0} />
            </button>
            <button
              type="button"
              className="ghost"
              aria-label="Cancel"
              onClick={() => {
                report.clear();
                setMessage('');
                focusControl('From');
              }}
            >
              <Mnemonic text="Cancel" at={0} />
            </button>
            <button type="button" className="ghost" aria-label="Print">
              <Mnemonic text="Print" at={0} />
            </button>
            <button type="button" className="ghost" aria-label="Exit" onClick={() => router.back()}>
              <Mnemonic text="Exit" at={1} />
            </button>
          </div>
          <div className="row" style={{ marginTop: 8 }}>
            {exports.map(({ extension, path }) => (
              <button
                key={extension}
                type="button"
                className="ghost"
                disabled={!path}
                onClick={() => path && openDocument(`/api${path}`)}
              >
                {extension.toUpperCase()}
              </button>
            ))}
          </div>
        </div>
        {error && (
          <div className="msg err" role="alert">
            {error}
          </div>
        )}
      </form>
      {report.result && <ApprovalReportGrid report={report.result} />}
    </div>
  );
}
