using System.Collections.Generic;

namespace DataCareNext;

public class ClsItemList
{
	public string SlNo;

	public string PrdDesc;

	public string IsServc;

	public string HsnCd;

	public decimal Qty;

	public decimal FreeQty;

	public string Unit;

	public decimal UnitPrice;

	public decimal TotAmt;

	public decimal Discount;

	public decimal PreTaxVal;

	public decimal AssAmt;

	public decimal GstRt;

	public decimal IgstAmt;

	public decimal CgstAmt;

	public decimal SgstAmt;

	public decimal CesRt;

	public decimal CesAmt;

	public decimal CesNonAdvlAmt;

	public decimal StateCesRt;

	public decimal StateCesAmt;

	public decimal StateCesNonAdvlAmt;

	public decimal OthChrg;

	public decimal TotItemVal;

	public string PrdSlNo;

	public ClsBchDtls BchDtls;

	public List<ClsAttribDtls> AttribDtls;

	public ClsItemList()
	{
		SlNo = "1";
		PrdDesc = "Rice";
		IsServc = "N";
		HsnCd = "100610";
		Qty = 100.345m;
		FreeQty = 10m;
		Unit = "BAG";
		UnitPrice = 99.545m;
		TotAmt = 9988.84m;
		Discount = 10m;
		PreTaxVal = 1m;
		AssAmt = 9978.84m;
		GstRt = 12m;
		IgstAmt = 1197.46m;
		CgstAmt = default(decimal);
		SgstAmt = default(decimal);
		CesRt = 5m;
		CesAmt = 498.94m;
		CesNonAdvlAmt = 10m;
		StateCesRt = 12m;
		StateCesAmt = 1197.46m;
		StateCesNonAdvlAmt = 5m;
		OthChrg = 10m;
		TotItemVal = 12897.7m;
		PrdSlNo = "12345";
		BchDtls = new ClsBchDtls();
		AttribDtls = new List<ClsAttribDtls>();
	}
}
