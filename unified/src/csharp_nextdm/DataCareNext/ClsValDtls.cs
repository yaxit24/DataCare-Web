namespace DataCareNext;

public class ClsValDtls
{
	public decimal AssVal;

	public decimal CgstVal;

	public decimal SgstVal;

	public decimal IgstVal;

	public decimal CesVal;

	public decimal StCesVal;

	public decimal Discount;

	public decimal OthChrg;

	public decimal RndOffAmt;

	public decimal TotInvVal;

	public decimal TotInvValFc;

	public ClsValDtls()
	{
		AssVal = 11.1m;
		CgstVal = default(decimal);
		SgstVal = default(decimal);
		IgstVal = default(decimal);
		CesVal = default(decimal);
		StCesVal = default(decimal);
		Discount = default(decimal);
		OthChrg = default(decimal);
		RndOffAmt = default(decimal);
		TotInvVal = 11.1m;
		TotInvValFc = default(decimal);
	}
}
