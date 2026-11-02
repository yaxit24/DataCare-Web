'use client';
import { LookupPicker } from './LookupPicker';
import { blankOldMetalRow, deriveOldMetal, type OldMetalRow } from '../lib/salesOrderOldMetal';

const fixed = (value: number, dp: number) => (value ? value.toFixed(dp) : '');

/**
 * G206: the Sales Order's old gold / old silver grid, TR_SALE_ORD MSG_OLD (Sr, ItCode, ItName, Pcs, GrWt, OthWt, NetWt,
 * Touch, Fine, RTyp, Rate, NetAmt). The operator types the item, pieces, gross and other weight, touch, rate type and
 * the rate or the amount; net weight and fine are derived, and so is the one of rate and amount that was not typed last
 * (CommPassTotal_Old, `TR_SALE_ORD.cs:4427-4500`). `onChange` receives an updater, so a lookup that answers after the
 * next cell was typed cannot undo that typing.
 */
export function SalesOrderOldMetalGrid({
  rows,
  onChange,
  disabled,
}: {
  rows: OldMetalRow[];
  onChange: (update: (rows: OldMetalRow[]) => OldMetalRow[]) => void;
  disabled?: boolean;
}) {
  const set = (key: string, patch: Partial<OldMetalRow>) =>
    onChange((current) => current.map((row) => (row.key === key ? { ...row, ...patch } : row)));
  const input = (
    row: OldMetalRow,
    index: number,
    name: string,
    field: keyof OldMetalRow,
    width: number,
    patch?: Partial<OldMetalRow>,
  ) => (
    <input
      aria-label={`Old metal ${name} line ${index + 1}`}
      inputMode="decimal"
      value={String(row[field])}
      disabled={disabled}
      onChange={(e) => set(row.key, { [field]: e.target.value, ...patch })}
      style={{ width, textAlign: 'right' }}
    />
  );
  return (
    <fieldset style={{ marginTop: 8 }}>
      <legend>Old gold / old silver</legend>
      {rows.length > 0 && (
        <table>
          <thead>
            <tr>
              <th>Sr</th>
              <th>ItCode</th>
              <th>ItName</th>
              <th className="num">Pcs</th>
              <th className="num">GrWt</th>
              <th className="num">OthWt</th>
              <th className="num">NetWt</th>
              <th className="num">Touch</th>
              <th className="num">Fine</th>
              <th>RTyp</th>
              <th className="num">Rate</th>
              <th className="num">NetAmt</th>
              <th />
            </tr>
          </thead>
          <tbody>
            {rows.map((row, index) => {
              const d = deriveOldMetal(row);
              const touched = Number(row.touch) > 0;
              return (
                <tr key={row.key}>
                  <td>{index + 1}</td>
                  <td>
                    <LookupPicker
                      entity="items"
                      ariaLabel={`Old metal item line ${index + 1}`}
                      value={row.itCode}
                      resolveTypedCode
                      onChange={(code) =>
                        set(
                          row.key,
                          code === row.itCode
                            ? { itCode: code }
                            : { itCode: code, itName: '', itType: '' },
                        )
                      }
                      onPick={(picked) =>
                        set(row.key, {
                          itCode: String(picked.code),
                          itName: String(picked.name ?? ''),
                          itType: String(picked.IT_TYPE ?? ''),
                        })
                      }
                      style={{ width: 90 }}
                    />
                  </td>
                  <td data-testid={`old-metal-name-${index + 1}`}>{row.itName}</td>
                  <td>{input(row, index, 'pcs', 'pcs', 50)}</td>
                  <td>{input(row, index, 'gross', 'grossWt', 80)}</td>
                  <td>{input(row, index, 'other', 'otherWt', 80)}</td>
                  <td>
                    <input
                      aria-label={`Old metal net line ${index + 1}`}
                      value={fixed(d.netWt, 3)}
                      readOnly
                      tabIndex={-1}
                      style={{ width: 80, textAlign: 'right', background: '#eef2f6' }}
                    />
                  </td>
                  <td>{input(row, index, 'touch', 'touch', 64)}</td>
                  <td>
                    {touched || !row.fine ? (
                      <input
                        aria-label={`Old metal fine line ${index + 1}`}
                        value={fixed(d.fine, 3)}
                        readOnly={touched}
                        disabled={disabled}
                        tabIndex={touched ? -1 : undefined}
                        onChange={(e) => set(row.key, { fine: e.target.value })}
                        style={{
                          width: 80,
                          textAlign: 'right',
                          background: touched ? '#eef2f6' : undefined,
                        }}
                      />
                    ) : (
                      input(row, index, 'fine', 'fine', 80)
                    )}
                  </td>
                  <td>
                    <select
                      aria-label={`Old metal rate type line ${index + 1}`}
                      value={row.rateType}
                      disabled={disabled}
                      onChange={(e) => set(row.key, { rateType: e.target.value as 'N' | 'F' })}
                    >
                      <option value="F">F - Fine Wise</option>
                      <option value="N">N - Net Wise</option>
                    </select>
                  </td>
                  <td>
                    {row.source === 'rate' ? (
                      input(row, index, 'rate', 'rate', 80, { source: 'rate' })
                    ) : (
                      <input
                        aria-label={`Old metal rate line ${index + 1}`}
                        inputMode="decimal"
                        value={fixed(d.rate, 2)}
                        disabled={disabled}
                        onChange={(e) => set(row.key, { rate: e.target.value, source: 'rate' })}
                        style={{ width: 80, textAlign: 'right' }}
                      />
                    )}
                  </td>
                  <td>
                    {row.source === 'amount' ? (
                      input(row, index, 'amount', 'amount', 90, { source: 'amount' })
                    ) : (
                      <input
                        aria-label={`Old metal amount line ${index + 1}`}
                        inputMode="decimal"
                        value={fixed(d.amount, 2)}
                        disabled={disabled}
                        onChange={(e) => set(row.key, { amount: e.target.value, source: 'amount' })}
                        style={{ width: 90, textAlign: 'right' }}
                      />
                    )}
                  </td>
                  <td>
                    <button
                      type="button"
                      className="danger"
                      aria-label={`Remove old metal line ${index + 1}`}
                      disabled={disabled}
                      onClick={() =>
                        onChange((current) => current.filter((r) => r.key !== row.key))
                      }
                    >
                      ×
                    </button>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
      )}
      <button
        type="button"
        disabled={disabled}
        onClick={() => onChange((current) => [...current, blankOldMetalRow()])}
      >
        + Add old metal row
      </button>
    </fieldset>
  );
}
