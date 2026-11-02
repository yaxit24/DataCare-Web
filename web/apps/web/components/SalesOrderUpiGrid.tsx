'use client';
import { LookupPicker } from './LookupPicker';
import { blankUpiRow, type UpiRow } from '../lib/salesOrderForm';

/**
 * G206: the Sales Order's UPI grid, TR_SALE_ORD MSG_UPI (Sr., AcCode, Upi Bank Name, UpiType, Upi Id, UpiAmt). The
 * account is picked from the account master, whose name fills Upi Bank Name. `onChange` receives an updater, so a
 * lookup that answers after the next cell was typed cannot undo that typing.
 */
export function SalesOrderUpiGrid({
  rows,
  onChange,
  disabled,
}: {
  rows: UpiRow[];
  onChange: (update: (rows: UpiRow[]) => UpiRow[]) => void;
  disabled?: boolean;
}) {
  const set = (key: string, patch: Partial<UpiRow>) =>
    onChange((current) => current.map((row) => (row.key === key ? { ...row, ...patch } : row)));
  return (
    <fieldset style={{ marginTop: 8 }}>
      <legend>UPI</legend>
      {rows.length > 0 && (
        <table>
          <thead>
            <tr>
              <th>Sr.</th>
              <th>AcCode</th>
              <th>Upi Bank Name</th>
              <th>UpiType</th>
              <th>Upi Id</th>
              <th className="num">UpiAmt</th>
              <th />
            </tr>
          </thead>
          <tbody>
            {rows.map((row, index) => (
              <tr key={row.key}>
                <td>{index + 1}</td>
                <td>
                  <LookupPicker
                    entity="accounts"
                    ariaLabel={`UPI AcCode line ${index + 1}`}
                    value={row.upiAc}
                    onChange={(code) =>
                      set(
                        row.key,
                        code === row.upiAc ? { upiAc: code } : { upiAc: code, upiName: '' },
                      )
                    }
                    onPick={(picked) =>
                      set(row.key, {
                        upiAc: String(picked.code),
                        upiName: String(picked.name ?? ''),
                      })
                    }
                  />
                </td>
                <td data-testid={`upi-name-${index + 1}`}>{row.upiName}</td>
                <td>
                  <input
                    aria-label={`UPI Type line ${index + 1}`}
                    value={row.upiType}
                    maxLength={25}
                    disabled={disabled}
                    onChange={(e) => set(row.key, { upiType: e.target.value })}
                  />
                </td>
                <td>
                  <input
                    aria-label={`UPI Id line ${index + 1}`}
                    value={row.upiId}
                    maxLength={25}
                    disabled={disabled}
                    onChange={(e) => set(row.key, { upiId: e.target.value })}
                  />
                </td>
                <td>
                  <input
                    aria-label={`UPI Amt line ${index + 1}`}
                    inputMode="decimal"
                    value={row.amount}
                    disabled={disabled}
                    onChange={(e) => set(row.key, { amount: e.target.value })}
                    style={{ width: 100, textAlign: 'right' }}
                  />
                </td>
                <td>
                  <button
                    type="button"
                    className="danger"
                    aria-label={`Remove UPI line ${index + 1}`}
                    disabled={disabled}
                    onClick={() => onChange((current) => current.filter((r) => r.key !== row.key))}
                  >
                    ×
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
      <button
        type="button"
        disabled={disabled}
        onClick={() => onChange((current) => [...current, blankUpiRow()])}
      >
        + Add UPI row
      </button>
    </fieldset>
  );
}
