using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[StandardModule]
internal sealed class PolicyModels
{
	public class AuthRequest
	{
		public string key { get; set; }

		public string value { get; set; }
	}

	public class AuthResponse
	{
		public string result { get; set; }

		public string token { get; set; }
	}

	public class GeneratePolicyRequest
	{
		public List<TagItem> TagList { get; set; }
	}

	public class TagItem
	{
		public string token { get; set; }

		public string id { get; set; }

		public string name { get; set; }

		public string grosswt { get; set; }

		public List<MetalDetail> metaldetails { get; set; }

		public List<StoneDetail> stonedetails { get; set; }

		public List<DecorativeItem> decovativeitem { get; set; }

		public List<JewelleryCertificate> jewellerycertificatedetails { get; set; }

		public string hallmarked { get; set; }

		public string inv_no { get; set; }

		public string inv_dt { get; set; }

		public string inv_itemsrno { get; set; }

		public string cust_name { get; set; }

		public string cust_email { get; set; }

		public string cust_mobile { get; set; }

		public string inv_amt { get; set; }

		public string insurance { get; set; }
	}

	public class MetalDetail
	{
		public string wt { get; set; }

		public string unitofwt { get; set; }

		public string type { get; set; }

		public string purity { get; set; }
	}

	public class StoneDetail
	{
		public string name { get; set; }

		public string properties { get; set; }

		public string wt { get; set; }

		public string unitofwt { get; set; }

		public string stonecnt { get; set; }

		public string certified { get; set; }

		public string cert_by { get; set; }

		public string cert_no { get; set; }

		public string cert_dt { get; set; }
	}

	public class DecorativeItem
	{
		public string name { get; set; }

		public string wt { get; set; }

		public string unitofwt { get; set; }
	}

	public class JewelleryCertificate
	{
		public string certified { get; set; }

		public string number { get; set; }

		public string dt { get; set; }

		public string by { get; set; }
	}

	public class PolicyResponse
	{
		public string id { get; set; }

		public string oid { get; set; }

		public string message { get; set; }

		public string url { get; set; }
	}
}
