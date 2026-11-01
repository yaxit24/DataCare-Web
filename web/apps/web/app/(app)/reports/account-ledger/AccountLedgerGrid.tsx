'use client';
import { formatDesktopDate } from '@datacare/core';
import type {
  AccountLedgerResult,
  AgeingRow,
  DetailRow,
  SummaryRow,
} from './types';

/** en-IN money (2dp) and weight (3dp) formatting; blank for zero so the grid reads like the desktop. */
const money = (n: number): string =>
  n ? Number(n).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 }) : '';
const wt = (n: number): string =>
  n ? Number(n).toLocaleString('en-IN', { minimumFractionDigits: 3, maximumFractionDigits: 3 }) : '';
const t = (k: string, totals: Record<string, number | string>): number => Number(totals[k] ?? 0);

export function AccountLedgerGrid({
  result,
  onOpenAccount,
}: {
  result: AccountLedgerResult;
  onOpenAccount: (acCode: string) => void;
}) {
  if (result.view === 'summary') return <SummaryGrid result={result} onOpenAccount={onOpenAccount} />;
  if (result.view === 'ageing') return <AgeingGrid result={result} />;
  return <DetailGrid result={result} />;
}

function SummaryGrid({
  result,
  onOpenAccount,
}: {
  result: AccountLedgerResult;
  onOpenAccount: (acCode: string) => void;
}) {
  const rows = result.rows as SummaryRow[];
  const tot = result.totals;
  return (
    <table className="grid">
      <thead>
        <tr>
          <th>Sr</th>
          <th>Party Name</th>
          <th>Mobile</th>
          <th className="num">Dr Amt</th>
          <th className="num">Cr Amt</th>
          <th className="num">Dr Gold</th>
          <th className="num">Cr Gold</th>
          <th className="num">Dr Silver</th>
          <th className="num">Cr Silver</th>
        </tr>
      </thead>
      <tbody>
        {rows.map((r) => (
          <tr
            key={r.acCode}
            tabIndex={0}
            style={{ cursor: 'pointer' }}
            onDoubleClick={() => onOpenAccount(r.acCode)}
            onKeyDown={(e) => {
              if (e.key === 'Enter') onOpenAccount(r.acCode);
            }}
          >
            <td>{r.srNo}</td>
            <td>{r.acName ?? r.acCode}</td>
            <td>{r.mobile ?? ''}</td>
            <td className="num">{money(r.drAmt)}</td>
            <td className="num">{money(r.crAmt)}</td>
            <td className="num">{wt(r.drGold)}</td>
            <td className="num">{wt(r.crGold)}</td>
            <td className="num">{wt(r.drSilver)}</td>
            <td className="num">{wt(r.crSilver)}</td>
          </tr>
        ))}
        {rows.length === 0 && (
          <tr>
            <td colSpan={9} className="muted">
              No accounts for the selected filters.
            </td>
          </tr>
        )}
      </tbody>
      {rows.length > 0 && (
        <tfoot>
          <tr className="totals">
            <td colSpan={3}>Total</td>
            <td className="num">{money(t('drAmt', tot))}</td>
            <td className="num">{money(t('crAmt', tot))}</td>
            <td className="num">{wt(t('drGold', tot))}</td>
            <td className="num">{wt(t('crGold', tot))}</td>
            <td className="num">{wt(t('drSilver', tot))}</td>
            <td className="num">{wt(t('crSilver', tot))}</td>
          </tr>
        </tfoot>
      )}
    </table>
  );
}

function DetailGrid({ result }: { result: AccountLedgerResult }) {
  const rows = result.rows as DetailRow[];
  const tot = result.totals;
  return (
    <table className="grid">
      <thead>
        <tr>
          <th>Sr</th>
          <th>Book</th>
          <th>Vch No</th>
          <th>Date</th>
          <th>Party Name</th>
          <th className="num">Cr Amt</th>
          <th className="num">Dr Amt</th>
          <th className="num">Bal Amt</th>
          <th>Cr/Dr</th>
          <th className="num">Cr Gold</th>
          <th className="num">Dr Gold</th>
          <th className="num">Bal Gold</th>
          <th className="num">Cr Silver</th>
          <th className="num">Dr Silver</th>
          <th className="num">Bal Silver</th>
          <th>Remark</th>
        </tr>
      </thead>
      <tbody>
        {rows.map((r) => (
          <tr key={r.srNo}>
            <td>{r.srNo}</td>
            <td>{r.bookName ?? r.book ?? ''}</td>
            <td>{r.vchNo ?? ''}</td>
            <td>{formatDesktopDate(r.date)}</td>
            <td>{r.party ?? ''}</td>
            <td className="num">{money(r.crAmt)}</td>
            <td className="num">{money(r.drAmt)}</td>
            <td className="num">{money(Math.abs(r.balAmt))}</td>
            <td>{r.amtSide}</td>
            <td className="num">{wt(r.crGold)}</td>
            <td className="num">{wt(r.drGold)}</td>
            <td className="num">{wt(Math.abs(r.balGold))}</td>
            <td className="num">{wt(r.crSilver)}</td>
            <td className="num">{wt(r.drSilver)}</td>
            <td className="num">{wt(Math.abs(r.balSilver))}</td>
            <td>{r.remark ?? ''}</td>
          </tr>
        ))}
        {rows.length === 0 && (
          <tr>
            <td colSpan={16} className="muted">
              No ledger entries for the selected filters.
            </td>
          </tr>
        )}
      </tbody>
      {rows.length > 0 && (
        <tfoot>
          <tr className="totals">
            <td colSpan={5}>Total</td>
            <td className="num">{money(t('crAmt', tot))}</td>
            <td className="num">{money(t('drAmt', tot))}</td>
            <td className="num">{money(t('balAmt', tot))}</td>
            <td>{String(tot.amtSide ?? '')}</td>
            <td className="num">{wt(t('crGold', tot))}</td>
            <td className="num">{wt(t('drGold', tot))}</td>
            <td className="num">{wt(t('balGold', tot))}</td>
            <td className="num">{wt(t('crSilver', tot))}</td>
            <td className="num">{wt(t('drSilver', tot))}</td>
            <td className="num">{wt(t('balSilver', tot))}</td>
            <td />
          </tr>
        </tfoot>
      )}
    </table>
  );
}

function AgeingGrid({ result }: { result: AccountLedgerResult }) {
  const rows = result.rows as AgeingRow[];
  const tot = result.totals;
  return (
    <table className="grid">
      <thead>
        <tr>
          <th>Party Name</th>
          <th className="num">0-15</th>
          <th className="num">16-30</th>
          <th className="num">31-45</th>
          <th className="num">46-60</th>
          <th className="num">61-90</th>
          <th className="num">91-120</th>
          <th className="num">121-150</th>
          <th className="num">151+</th>
          <th className="num">Total</th>
        </tr>
      </thead>
      <tbody>
        {rows.map((r) => (
          <tr key={r.acCode}>
            <td>{r.acName ?? r.acCode}</td>
            <td className="num">{money(r.amt15)}</td>
            <td className="num">{money(r.amt30)}</td>
            <td className="num">{money(r.amt45)}</td>
            <td className="num">{money(r.amt60)}</td>
            <td className="num">{money(r.amt90)}</td>
            <td className="num">{money(r.amt120)}</td>
            <td className="num">{money(r.amt150)}</td>
            <td className="num">{money(r.amt151)}</td>
            <td className="num">{money(r.amt)}</td>
          </tr>
        ))}
        {rows.length === 0 && (
          <tr>
            <td colSpan={10} className="muted">
              No outstanding debit balances as of the selected date.
            </td>
          </tr>
        )}
      </tbody>
      {rows.length > 0 && (
        <tfoot>
          <tr className="totals">
            <td>Total</td>
            <td className="num">{money(t('amt15', tot))}</td>
            <td className="num">{money(t('amt30', tot))}</td>
            <td className="num">{money(t('amt45', tot))}</td>
            <td className="num">{money(t('amt60', tot))}</td>
            <td className="num">{money(t('amt90', tot))}</td>
            <td className="num">{money(t('amt120', tot))}</td>
            <td className="num">{money(t('amt150', tot))}</td>
            <td className="num">{money(t('amt151', tot))}</td>
            <td className="num">{money(t('amt', tot))}</td>
          </tr>
        </tfoot>
      )}
    </table>
  );
}
