using Microsoft.VisualBasic;

namespace DataCareNext;

public class ClsDocDtls
{
	public string Typ;

	public string No;

	public string Dt;

	public ClsDocDtls()
	{
		Typ = "INV";
		No = "00001";
		Dt = Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy");
	}
}
