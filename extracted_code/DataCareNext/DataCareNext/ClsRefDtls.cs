using System.Collections.Generic;

namespace DataCareNext;

public class ClsRefDtls
{
	public string InvRm;

	public ClsDocPerdDtls DocPerdDtls;

	public List<ClsPrecDocDtls> PrecDocDtls;

	public List<ClsContrDtls> ContrDtls;

	public ClsRefDtls()
	{
		InvRm = "TEST";
		DocPerdDtls = new ClsDocPerdDtls();
		PrecDocDtls = new List<ClsPrecDocDtls>();
		ContrDtls = new List<ClsContrDtls>();
	}
}
