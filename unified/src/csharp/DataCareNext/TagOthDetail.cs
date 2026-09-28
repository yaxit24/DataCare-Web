namespace DataCareNext;

public class TagOthDetail
{
	public string OtSrNo;

	public string OtItCode;

	public string OtItName;

	public decimal OtPcs;

	public decimal OtGwt;

	public decimal OtRate;

	public decimal OtAmt;

	public decimal OtNetAmt;

	public TagOthDetail()
	{
		OtSrNo = "1";
		OtItCode = "Dm";
		OtItName = "Dimand";
		OtPcs = 1m;
		OtGwt = 10m;
		OtRate = 350m;
		OtAmt = 4000m;
		OtNetAmt = 42000m;
	}
}
