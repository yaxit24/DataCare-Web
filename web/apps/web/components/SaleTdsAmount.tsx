/** The totals grid's TDS cell: computed from TDS %, never typed (TR_SALE.cs:19261-19275). */
export function SaleTdsAmount({ amount }: { amount: number }) {
  return (
    <div className="field">
      <label htmlFor="saleTdsAmount">TDS Amount</label>
      <input id="saleTdsAmount" value={amount ? amount.toFixed(2) : ''} readOnly />
    </div>
  );
}
