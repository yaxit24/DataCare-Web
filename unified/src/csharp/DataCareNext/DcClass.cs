using System.Collections.Generic;

namespace DataCareNext;

public class DcClass
{
	public string Version;

	public ClsTranDtls TranDtls;

	public ClsDocDtls DocDtls;

	public ClsSellerDtls SellerDtls;

	public ClsBuyerDtls BuyerDtls;

	public ClsDispDtls DispDtls;

	public ClsShipDtls ShipDtls;

	public List<ClsItemList> ItemList;

	public ClsValDtls ValDtls;

	public ClsRefDtls RefDtls;

	public DcClass()
	{
		Version = "1.1";
		TranDtls = new ClsTranDtls();
		DocDtls = new ClsDocDtls();
		SellerDtls = new ClsSellerDtls();
		BuyerDtls = new ClsBuyerDtls();
		DispDtls = new ClsDispDtls();
		ShipDtls = new ClsShipDtls();
		ItemList = new List<ClsItemList>();
		ValDtls = new ClsValDtls();
		RefDtls = new ClsRefDtls();
	}
}
