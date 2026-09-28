using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataCareNext;

[DesignerGenerated]
public class OlockerService : Form
{
	public delegate void PolicyErrorEventHandler(string message);

	private IContainer components;

	private readonly string authUrl;

	private readonly string policyUrl;

	public event PolicyErrorEventHandler PolicyError;

	public OlockerService()
	{
		authUrl = "https://olocker.co/api_v6/public/Policies/authenticate";
		policyUrl = "https://olocker.co/api_v6/public/Policies/generatePolicies";
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
		}
		finally
		{
			((Form)this).Dispose(disposing);
		}
	}

	[DebuggerStepThrough]
	private void InitializeComponent()
	{
		((Control)this).SuspendLayout();
		((ContainerControl)this).AutoScaleDimensions = new SizeF(12f, 25f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(800, 450);
		((Control)this).Name = "OlockerService";
		((Form)this).Text = "OlockerService";
		((Control)this).ResumeLayout(false);
	}

	public async Task<string> GetToken()
	{
		PolicyModels.AuthRequest authRequest = new PolicyModels.AuthRequest
		{
			key = DC_Main.MsOLocerKey,
			value = DC_Main.MsOLocerVal
		};
		HttpClient val = new HttpClient();
		try
		{
			string text = JsonConvert.SerializeObject((object)authRequest);
			StringContent val2 = new StringContent(text, Encoding.UTF8, "application/json");
			PolicyModels.AuthResponse authResponse = JsonConvert.DeserializeObject<PolicyModels.AuthResponse>(await (await val.PostAsync(authUrl, (HttpContent)(object)val2)).Content.ReadAsStringAsync());
			return authResponse.token;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public async void GeneratePolicy(string token, string CurBook, string CurVchNo)
	{
		DC_Main.RsQry = "SELECT A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.SR_NO,A.ITM_GWT,A.ITM_NWT,A.ITM_AMT,B.AC_NAME,B.AC_MOBILE  FROM (SL_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE)LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + CurBook + "' AND VCH_NO = '" + CurVchNo + "'";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count == 0)
		{
			MessageBox.Show("No Data Found...");
			return;
		}
		int num = ((!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VCH_DATE"]))) ? (DateTime.Today - Convert.ToDateTime(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["VCH_DATE"]))).Days : 0);
		if (num > 7)
		{
			MessageBox.Show("Maximum 7 days old bill Valid....");
			return;
		}
		try
		{
			List<PolicyModels.TagItem> list = new List<PolicyModels.TagItem>();
			foreach (DataRow row in dataTable.Rows)
			{
				string inv_no = row["VCH_NO"].ToString();
				string inv_dt = Convert.ToDateTime(RuntimeHelpers.GetObjectValue(row["VCH_DATE"])).ToString("yyyy-MM-dd");
				string id = row["TAG_NO"].ToString();
				string name = row["IT_NAME"].ToString();
				string text = row["SR_NO"].ToString();
				string grosswt = row["ITM_GWT"].ToString();
				row["ITM_NWT"].ToString();
				string text2 = row["ITM_AMT"].ToString();
				string cust_name = row["AC_NAME"].ToString();
				string cust_mobile = row["AC_MOBILE"].ToString();
				PolicyModels.TagItem item = new PolicyModels.TagItem
				{
					token = token,
					id = id,
					name = name,
					grosswt = grosswt,
					metaldetails = GetMetalDetails(CurBook, CurVchNo, Conversions.ToInteger(text)),
					stonedetails = GetStoneDetails(CurBook, CurVchNo, Conversions.ToInteger(text)),
					decovativeitem = new List<PolicyModels.DecorativeItem>(),
					jewellerycertificatedetails = new List<PolicyModels.JewelleryCertificate>(),
					hallmarked = "yes",
					inv_no = inv_no,
					inv_dt = inv_dt,
					inv_itemsrno = text,
					cust_name = cust_name,
					cust_mobile = cust_mobile,
					inv_amt = text2,
					insurance = text2
				};
				list.Add(item);
			}
			PolicyModels.GeneratePolicyRequest generatePolicyRequest = new PolicyModels.GeneratePolicyRequest
			{
				TagList = list
			};
			HttpClient val = new HttpClient();
			try
			{
				string text3 = JsonConvert.SerializeObject((object)generatePolicyRequest);
				StringContent val2 = new StringContent(text3, Encoding.UTF8, "application/json");
				JArray val3 = JArray.Parse(await (await val.PostAsync(policyUrl, (HttpContent)(object)val2)).Content.ReadAsStringAsync());
				if (((JContainer)val3).Count > 0)
				{
					string fileName = val3[0][(object)"url"].ToString();
					Process.Start(fileName);
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			PolicyError?.Invoke(ex3.Message);
			ProjectData.ClearProjectError();
		}
	}

	private List<PolicyModels.MetalDetail> GetMetalDetails(string CurBook, string CurVchNo, int CurSrNo)
	{
		DC_Main.RsQry = ("SELECT A.ITM_GWT,A.ITM_NWT,B.IT_TYPE,B.GR_CODE FROM SL_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + CurBook + "' AND VCH_NO = '" + CurVchNo + "' AND A.SR_NO = " + Conversions.ToString(CurSrNo)) ?? "";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		List<PolicyModels.MetalDetail> list = new List<PolicyModels.MetalDetail>();
		if (DC_Main.Tbl != null && DC_Main.Tbl.Rows.Count > 0)
		{
			foreach (DataRow row in DC_Main.Tbl.Rows)
			{
				list.Add(new PolicyModels.MetalDetail
				{
					wt = row["ITM_GWT"].ToString(),
					unitofwt = row["ITM_NWT"].ToString(),
					type = row["IT_TYPE"].ToString(),
					purity = row["GR_CODE"].ToString()
				});
			}
		}
		return list;
	}

	private List<PolicyModels.StoneDetail> GetStoneDetails(string CurBook, string CurVchNo, int CurSrNo)
	{
		DC_Main.RsQry = ("SELECT B.IT_NAME,A.IT_GWT,B.IT_TYPE FROM SL_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + CurBook + "' AND VCH_NO = '" + CurVchNo + "' AND A.SR_NO = " + Conversions.ToString(CurSrNo)) ?? "";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		List<PolicyModels.StoneDetail> list = new List<PolicyModels.StoneDetail>();
		if (DC_Main.Tbl != null && DC_Main.Tbl.Rows.Count > 0)
		{
			foreach (DataRow row in DC_Main.Tbl.Rows)
			{
				list.Add(new PolicyModels.StoneDetail
				{
					name = row["IT_NAME"].ToString(),
					properties = row["IT_TYPE"].ToString(),
					wt = row["IT_GWT"].ToString(),
					unitofwt = "GM",
					stonecnt = "1",
					certified = "",
					cert_by = "",
					cert_no = "",
					cert_dt = ""
				});
			}
		}
		return list;
	}
}
