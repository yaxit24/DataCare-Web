'use client';
import { useState } from 'react';

export interface PickerItem {
  code: string;
  name: string;
}

/**
 * The InOut item picker (RP_STOCK.cs:5857-5976, PnlIt / DGV_ITM): the items of the chosen Item Type with a tick box
 * each (columns Ok, Sr, Itm Name, It Code). Ok hands the ticked codes on; none ticked is answered by the parent with
 * "Item Selection Not Done...". Cancel closes the panel and forgets the ticks (btnItCancel_Click).
 */
export function ItemPicker({
  items,
  onOk,
  onCancel,
}: {
  items: PickerItem[];
  onOk: (codes: string[]) => void;
  onCancel: () => void;
}) {
  const [ticked, setTicked] = useState<Set<string>>(new Set());
  const toggle = (code: string) =>
    setTicked((prev) => {
      const next = new Set(prev);
      if (next.has(code)) next.delete(code);
      else next.add(code);
      return next;
    });
  return (
    <div className="panel" data-testid="stock-item-picker" role="group" aria-label="Item selection">
      <div className="row">
        <button
          type="button"
          className="ghost"
          onClick={() => onOk(items.filter((i) => ticked.has(i.code)).map((i) => i.code))}
        >
          Ok
        </button>
        <button type="button" className="ghost" onClick={onCancel}>
          Cancel
        </button>
      </div>
      <div style={{ overflow: 'auto', maxHeight: '40vh' }}>
        <table className="grid dense">
          <thead>
            <tr>
              <th>Ok</th>
              <th>Sr</th>
              <th>Itm Name</th>
              <th>It Code</th>
            </tr>
          </thead>
          <tbody>
            {items.map((item, i) => (
              <tr key={item.code} data-it={item.code}>
                <td>
                  <input
                    type="checkbox"
                    aria-label={`Select ${item.name}`}
                    checked={ticked.has(item.code)}
                    onChange={() => toggle(item.code)}
                  />
                </td>
                <td>{i + 1}</td>
                <td>{item.name}</td>
                <td>{item.code}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}
