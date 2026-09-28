'use client';
import { useEffect, useRef, useState } from 'react';
import { get } from '../lib/api';
import { BookSelect } from './BookSelect';
import { LookupPicker } from './LookupPicker';
import { useBusinessScope } from './BusinessScope';
import {
  mfgLotComponents,
  mfgLotDisplayName,
  mfgLotFamilies,
  mfgLotFields,
  mfgLotValue,
  type MfgLotKind,
  type MfgLotDisplayLabels,
  type MfgLotRow,
  type MfgLotSettings,
  type MfgLotDocument,
  type MfgLotPage,
  type MfgLotSourceView,
} from '../lib/mfgLotView';

function CurrentName({
  field,
  code,
  labels,
}: {
  field: string;
  code: unknown;
  labels?: MfgLotDisplayLabels;
}) {
  const name = mfgLotDisplayName(field, code, labels);
  return name ? <small style={{ display: 'block' }}>Current name: {name}</small> : null;
}
function Fields({ row, labels }: { row: MfgLotRow; labels?: MfgLotDisplayLabels }) {
  return (
    <dl
      style={{
        display: 'grid',
        gridTemplateColumns: 'repeat(auto-fit,minmax(220px,1fr))',
        gap: 12,
      }}
    >
      {mfgLotFields(row).map((field) => (
        <div key={field.key}>
          <dt>{field.label}</dt>
          <dd style={{ margin: 0, overflowWrap: 'anywhere', whiteSpace: 'pre-wrap' }}>
            {field.value}
          </dd>
          <CurrentName field={field.key} code={row[field.key]} labels={labels} />
        </div>
      ))}
    </dl>
  );
}
function Records({
  title,
  rows,
  labels,
}: {
  title: string;
  rows: MfgLotRow[];
  labels?: MfgLotDisplayLabels;
}) {
  return (
    <details>
      <summary>
        {title} ({rows.length})
      </summary>
      {rows.map((row, index) => (
        <details key={index}>
          <summary>
            Row {mfgLotValue(row.SR_NO)} / {mfgLotValue(row.ISR_NO)} · {mfgLotValue(row.IT_CODE)}
          </summary>
          <Fields row={row} labels={labels} />
        </details>
      ))}
    </details>
  );
}
export default function MfgLotForm({ kind }: { kind: MfgLotKind }) {
  const scope = useBusinessScope();
  const [book, setBook] = useState(''),
    [search, setSearch] = useState(''),
    [voucher, setVoucher] = useState('');
  const [account, setAccount] = useState(''),
    [sourceBook, setSourceBook] = useState(''),
    [sourceSearch, setSourceSearch] = useState('');
  const scopeKey = JSON.stringify([scope.coCode, scope.lcCode, scope.coYear, book, kind]);
  const sourceKey = JSON.stringify([scopeKey, account, sourceBook, sourceSearch]);
  const scopeRef = useRef(scopeKey),
    sourceRef = useRef(sourceKey);
  scopeRef.current = scopeKey;
  sourceRef.current = sourceKey;
  const query = new URLSearchParams({
    coCode: scope.coCode,
    lcCode: scope.lcCode,
    coYear: scope.coYear,
    coBook: book,
  }).toString();
  const base = `/mfg/lot/${kind}`;
  const [settings, setSettings] = useState<{ key: string; value: MfgLotSettings } | null>(null);
  const [browse, setBrowse] = useState<{ key: string; value: MfgLotPage<MfgLotRow> } | null>(null);
  const [saved, setSaved] = useState<{ key: string; value: MfgLotDocument } | null>(null);
  const [sources, setSources] = useState<{
    key: string;
    value: MfgLotPage<MfgLotSourceView>;
  } | null>(null);
  const [selectedSource, setSelectedSource] = useState<{
    key: string;
    value: MfgLotSourceView;
  } | null>(null);
  const [error, setError] = useState<{ key: string; message: string } | null>(null);
  const [pending, setPending] = useState(false),
    [attempt, setAttempt] = useState(0);
  const request = useRef(0),
    settingsRequest = useRef(0);
  const currentSettings = settings?.key === scopeKey ? settings.value : null;
  const currentBrowse = browse?.key === scopeKey ? browse.value : null;
  const currentSaved = saved?.key === scopeKey ? saved.value : null;
  const currentSources = sources?.key === sourceKey ? sources.value : null;
  const currentSource = selectedSource?.key === sourceKey ? selectedSource.value : null;
  const title = kind === 'issue' ? 'Lot Setting Issue' : 'Lot Setting Receipt';
  useEffect(() => {
    const id = ++settingsRequest.current;
    let cancelled = false;
    request.current++;
    setPending(false);
    setError(null);
    setSaved(null);
    setBrowse(null);
    setSources(null);
    setSelectedSource(null);
    setSettings(null);
    setSourceBook('');
    if (!book) return;
    void get<MfgLotSettings>(`${base}/settings?${query}`)
      .then((result) => {
        if (!cancelled && id === settingsRequest.current && scopeRef.current === scopeKey)
          setSettings({ key: scopeKey, value: result });
      })
      .catch((cause) => {
        if (!cancelled && id === settingsRequest.current && scopeRef.current === scopeKey)
          setError({
            key: scopeKey,
            message:
              cause instanceof Error ? cause.message : 'Could not load Setting configuration.',
          });
      });
    return () => {
      cancelled = true;
    };
  }, [base, book, query, scopeKey, attempt]);
  async function run(action: 'browse' | 'load' | 'sources', offset = 0) {
    const id = ++request.current;
    setPending(true);
    setError(null);
    if (action === 'load') setSaved(null);
    if (action === 'sources') {
      setSources(null);
      setSelectedSource(null);
    }
    try {
      if (action === 'browse') {
        const result = await get<MfgLotPage<MfgLotRow>>(
          `${base}/list?${query}&${new URLSearchParams({ search, offset: String(offset) })}`,
        );
        if (id === request.current && scopeRef.current === scopeKey)
          setBrowse({ key: scopeKey, value: result });
      } else if (action === 'load') {
        const result = await get<MfgLotDocument>(
          `${base}/${encodeURIComponent(voucher.trim())}?${query}`,
        );
        if (id === request.current && scopeRef.current === scopeKey)
          setSaved({ key: scopeKey, value: result });
      } else {
        const result = await get<MfgLotPage<MfgLotSourceView>>(
          `${base}/sources?${query}&${new URLSearchParams({ acCode: account, sourceBook, search: sourceSearch, offset: String(offset), sourceKind: currentSettings!.sourceKind })}`,
        );
        if (
          id === request.current &&
          scopeRef.current === scopeKey &&
          sourceRef.current === sourceKey
        )
          setSources({ key: sourceKey, value: result });
      }
    } catch (cause) {
      if (id === request.current && scopeRef.current === scopeKey)
        setError({
          key: scopeKey,
          message: cause instanceof Error ? cause.message : 'Could not load lot records.',
        });
    } finally {
      if (id === request.current) setPending(false);
    }
  }
  return (
    <div style={{ minWidth: 0, maxWidth: '100%' }}>
      <h1>{title}</h1>
      <p>Review saved lot entries and the material available at each source.</p>
      <div className="panel">
        <label>
          Setting book
          <BookSelect
            key={`${scope.coCode}/${scope.lcCode}/${scope.coYear}`}
            value={book}
            onChange={setBook}
            mainBooks={[mfgLotFamilies[kind]]}
          />
        </label>
      </div>
      {error?.key === scopeKey && (
        <div role="alert" className="msg err">
          {error.message}
          <button type="button" onClick={() => setAttempt((n) => n + 1)}>
            Reload configuration
          </button>
        </div>
      )}
      {book && !currentSettings && !error && <p role="status">Loading Setting configuration…</p>}
      {currentSettings && (
        <>
          <p role="note">{currentSettings.unavailableReason}</p>
          <details>
            <summary>Configured process</summary>
            <Fields row={currentSettings.book} />
            {currentSettings.stage && <Fields row={currentSettings.stage} />}
          </details>
        </>
      )}
      <section className="panel" aria-label="Saved lot browse">
        <h2>Saved entries</h2>
        <div className="row">
          <label>
            Search entries
            <input
              aria-label="Search lot entries"
              value={search}
              onChange={(e) => setSearch(e.target.value)}
            />
          </label>
          <button type="button" disabled={!book || pending} onClick={() => void run('browse')}>
            Browse saved entries
          </button>
          <label>
            Voucher number
            <input
              aria-label="Lot voucher number"
              value={voucher}
              onChange={(e) => setVoucher(e.target.value)}
            />
          </label>
          <button
            type="button"
            disabled={!book || pending || !voucher.trim()}
            onClick={() => void run('load')}
          >
            Load lot entry
          </button>
        </div>
        {currentBrowse && (
          <>
            <div className="grid-scroll" style={{ maxWidth: '100%', overflowX: 'auto' }}>
              <table>
                <thead>
                  <tr>
                    {['Voucher', 'Date', 'Account', 'Bill reference', 'Gross', 'Net', 'Amount'].map(
                      (label) => (
                        <th key={label}>{label}</th>
                      ),
                    )}
                  </tr>
                </thead>
                <tbody>
                  {currentBrowse.rows.map((row) => (
                    <tr key={String(row.VCH_NO)}>
                      {[
                        'VCH_NO',
                        'VCH_DATE',
                        'AC_CODE',
                        'BILL_NO',
                        'GR_WT',
                        'NET_WT',
                        'NET_AMT',
                      ].map((key) => (
                        <td key={key}>
                          {mfgLotValue(row[key])}
                          <CurrentName
                            field={key}
                            code={row[key]}
                            labels={currentBrowse.displayLabels}
                          />
                        </td>
                      ))}
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            {!currentBrowse.rows.length && <p>No saved entries match this book and search.</p>}
            <button
              disabled={pending || !currentBrowse.offset}
              onClick={() =>
                void run('browse', Math.max(0, currentBrowse.offset - currentBrowse.limit))
              }
            >
              Previous entries
            </button>
            <button
              disabled={pending || !currentBrowse.hasMore}
              onClick={() => void run('browse', currentBrowse.offset + currentBrowse.limit)}
            >
              Next entries
            </button>
          </>
        )}
      </section>
      {currentSaved && (
        <section className="panel" aria-label="Saved lot entry">
          <h2>Saved entry {mfgLotValue(currentSaved.header.VCH_NO)}</h2>
          <Fields row={currentSaved.header} labels={currentSaved.displayLabels} />
          <h3>Items and components</h3>
          {currentSaved.lines.map((line) => (
            <details key={String(line.SR_NO)} open>
              <summary>
                Item row {mfgLotValue(line.SR_NO)} · {mfgLotValue(line.IT_CODE)} ·{' '}
                {mfgLotValue(line.LOT_NO)}
              </summary>
              <Fields row={line} labels={currentSaved.displayLabels} />
              <Records
                title="Components"
                rows={mfgLotComponents(currentSaved, line)}
                labels={currentSaved.displayLabels}
              />
            </details>
          ))}
          <Records
            title="Posted manufacturing movements"
            rows={currentSaved.movements}
            labels={currentSaved.displayLabels}
          />
          <Records
            title="Posted stock movements"
            rows={currentSaved.stock}
            labels={currentSaved.displayLabels}
          />
        </section>
      )}
      <section className="panel" aria-label="Lot source selection">
        <h2>Inspect material sources</h2>
        <p>
          Balances are shown for review. Selecting a source does not reserve or consume material.
        </p>
        {currentSettings?.sourceUnavailableReason && (
          <p>{currentSettings.sourceUnavailableReason}</p>
        )}
        {kind === 'receive' && (
          <div className="row">
            <label>
              Karigar
              <LookupPicker
                entity="accounts"
                ariaLabel="Lot source karigar"
                value={account}
                onChange={setAccount}
              />
            </label>
            <label>
              Issue source book
              <select
                aria-label="Lot issue source book"
                value={sourceBook}
                onChange={(e) => setSourceBook(e.target.value)}
              >
                <option value="">Select issue source book…</option>
                {currentSettings?.sourceBooks.map((row) => (
                  <option key={String(row.CO_BOOK)} value={String(row.CO_BOOK)}>
                    {row.CO_BOOK} — {row.BOOK_NAME}
                  </option>
                ))}
              </select>
            </label>
          </div>
        )}
        <label>
          Find material lot
          <input
            aria-label="Find material lot"
            value={sourceSearch}
            onChange={(e) => setSourceSearch(e.target.value)}
          />
        </label>
        <button
          disabled={
            pending ||
            !currentSettings?.sourceSelection ||
            (kind === 'receive' && (!account || !sourceBook))
          }
          onClick={() => void run('sources')}
        >
          Find source balances
        </button>
        {currentSources && (
          <>
            <div className="grid-scroll" style={{ maxWidth: '100%', overflowX: 'auto' }}>
              <table>
                <thead>
                  <tr>
                    {[
                      'Material lot',
                      'Item',
                      'Source date',
                      'Source year / book / voucher / row',
                      'Remaining pieces',
                      'Remaining gross',
                      'Remaining net',
                      'Availability basis',
                      '',
                    ].map((label, index) => (
                      <th key={index}>{label}</th>
                    ))}
                  </tr>
                </thead>
                <tbody>
                  {currentSources.rows.map((row) => (
                    <tr key={row.key}>
                      <td>{mfgLotValue(row.materialLot)}</td>
                      <td>
                        {mfgLotValue(row.itemCode)}
                        <CurrentName
                          field="itemCode"
                          code={row.itemCode}
                          labels={currentSources.displayLabels}
                        />
                      </td>
                      <td>{mfgLotValue(row.sourceDate)}</td>
                      <td>
                        {row.kind === 'stock-material'
                          ? 'Stock movement contributors'
                          : `${mfgLotValue(row.sourceYear)} / ${mfgLotValue(row.sourceBook)} / ${mfgLotValue(row.sourceVoucher)} / ${mfgLotValue(row.sourceOldSrNo)}`}
                      </td>
                      <td>{mfgLotValue(row.remainingPieces)}</td>
                      <td>{mfgLotValue(row.remainingWeight)}</td>
                      <td>{mfgLotValue(row.remainingNetWeight)}</td>
                      <td>{row.availabilityBasis}</td>
                      <td>
                        <button onClick={() => setSelectedSource({ key: sourceKey, value: row })}>
                          Inspect source
                        </button>
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
            {!currentSources.rows.length && (
              <p>No positive source balances match this selection.</p>
            )}
            <button
              disabled={pending || !currentSources.offset}
              onClick={() =>
                void run('sources', Math.max(0, currentSources.offset - currentSources.limit))
              }
            >
              Previous sources
            </button>
            <button
              disabled={pending || !currentSources.hasMore}
              onClick={() => void run('sources', currentSources.offset + currentSources.limit)}
            >
              Next sources
            </button>
          </>
        )}
        {currentSource && (
          <div aria-label="Selected lot source">
            <h3>Selected source {mfgLotValue(currentSource.materialLot)}</h3>
            <Fields row={currentSource.identity} labels={currentSources?.displayLabels} />
            <Records
              title="Contributing movements"
              rows={currentSource.contributors}
              labels={currentSources?.displayLabels}
            />
          </div>
        )}
      </section>
    </div>
  );
}
