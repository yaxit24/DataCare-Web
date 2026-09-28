using System.Collections.Generic;

namespace DataCareNext;

public class ClassTagList
{
	public string SlNo;

	public string ItCode;

	public string TagNo;

	public decimal Pcs;

	public decimal GrWt;

	public decimal OthWt;

	public decimal NetWt;

	public decimal Touch;

	public decimal West;

	public decimal Fine;

	public decimal lbrPrc;

	public decimal lbrRate;

	public decimal lbrAmt;

	public decimal OthAmt;

	public decimal NetAmt;

	public string KrName;

	public List<TagOthDetail> TagOth;

	public ClassTagList()
	{
		SlNo = "1";
		ItCode = "CH916";
		TagNo = "CHG0001";
		Pcs = 1m;
		GrWt = 10m;
		OthWt = 2m;
		NetWt = 8m;
		Touch = 92m;
		West = 5m;
		Fine = 9.7m;
		lbrPrc = 12m;
		lbrRate = 350m;
		lbrAmt = 4000m;
		OthAmt = 150m;
		NetAmt = 42000m;
		KrName = "KRG";
		TagOth = new List<TagOthDetail>();
	}
}
