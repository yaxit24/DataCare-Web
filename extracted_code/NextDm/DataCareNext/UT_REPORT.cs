using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using DataCareNext.My;
using DevNet.Models;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class UT_REPORT : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSendWapp")]
	private Button _btnSendWapp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btneMail")]
	private Button _btneMail;

	private Module_WhatsApp whatsApp;

	private bool MsFormLoad;

	private ReportDocument ReportDc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Timer1")]
	private virtual Timer _Timer1;

	internal virtual Timer Timer1
	{
		get
		{
			return _Timer1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Timer1 = value;
		}
	}

	internal virtual Button btnSendWapp
	{
		[CompilerGenerated]
		get
		{
			return _btnSendWapp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSendWapp_Click;
			Button val = _btnSendWapp;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSendWapp = value;
			val = _btnSendWapp;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CrViewer")]
	private virtual CrystalReportViewer _CrViewer;

	private virtual CrystalReportViewer CrViewer
	{
		get
		{
			return _CrViewer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_CrViewer = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CrystalReportViewer1")]
	private virtual CrystalReportViewer _CrystalReportViewer1;

	private virtual CrystalReportViewer CrystalReportViewer1
	{
		get
		{
			return _CrystalReportViewer1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_CrystalReportViewer1 = value;
		}
	}

	internal virtual Button btneMail
	{
		[CompilerGenerated]
		get
		{
			return _btneMail;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btneMail_Click;
			Button val = _btneMail;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btneMail = value;
			val = _btneMail;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public UT_REPORT()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		((Form)this).Activated += UT_REPORT_Activated;
		((Control)this).KeyDown += new KeyEventHandler(UT_REPORT_KeyDown);
		((Form)this).Load += UT_REPORT_Load;
		((Form)this).Closed += UT_REPORT_Closed;
		whatsApp = UT_WHATSAPP.whatsApp;
		ReportDc = new ReportDocument();
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
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_REPORT));
		Timer1 = new Timer(components);
		CrViewer = new CrystalReportViewer();
		CrystalReportViewer1 = new CrystalReportViewer();
		btnSendWapp = new Button();
		btneMail = new Button();
		((Control)this).SuspendLayout();
		Timer1.Enabled = true;
		Timer1.Interval = 10000;
		CrViewer.ActiveViewIndex = -1;
		componentResourceManager.ApplyResources(CrViewer, "CrViewer");
		((UserControl)CrViewer).BorderStyle = (BorderStyle)1;
		((Control)CrViewer).Cursor = Cursors.Default;
		((Control)CrViewer).ForeColor = Color.Maroon;
		((Control)CrViewer).Name = "CrViewer";
		CrystalReportViewer1.ActiveViewIndex = -1;
		((UserControl)CrystalReportViewer1).BorderStyle = (BorderStyle)1;
		((Control)CrystalReportViewer1).Cursor = Cursors.Default;
		componentResourceManager.ApplyResources(CrystalReportViewer1, "CrystalReportViewer1");
		((Control)CrystalReportViewer1).Name = "CrystalReportViewer1";
		componentResourceManager.ApplyResources(btnSendWapp, "btnSendWapp");
		((Control)btnSendWapp).Name = "btnSendWapp";
		((ButtonBase)btnSendWapp).UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(btneMail, "btneMail");
		((Control)btneMail).Name = "btneMail";
		((ButtonBase)btneMail).UseVisualStyleBackColor = true;
		componentResourceManager.ApplyResources(this, "$this");
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.Silver;
		((Control)this).Controls.Add((Control)(object)btneMail);
		((Control)this).Controls.Add((Control)(object)btnSendWapp);
		((Control)this).Controls.Add((Control)(object)CrystalReportViewer1);
		((Control)this).Controls.Add((Control)(object)CrViewer);
		((Form)this).KeyPreview = true;
		((Control)this).Name = "UT_REPORT";
		((Control)this).Tag = "0";
		((Form)this).WindowState = (FormWindowState)2;
		((Control)this).ResumeLayout(false);
	}

	private void UT_REPORT_Activated(object sender, EventArgs e)
	{
		//IL_09c8: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num2 = 2;
					if (MsFormLoad)
					{
						goto end_IL_0001;
					}
					ReportDc.Load(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + DC_Main.RptName + ".rpt");
					ReportDc.RecordSelectionFormula = DC_Main.RptFormula;
					ReportDc.SetDatabaseLogon(DC_Main.SqlId, DC_Main.SqlPwd);
					if (Operators.CompareString(DC_Main.MsWappPrintType, "All", false) != 0)
					{
						if (Operators.CompareString(DC_Main.MsWappPrintType, "AmtBal", false) == 0)
						{
							ReportDc.DataDefinition.FormulaFields["OpAmt"].Text = Conversions.ToString(DC_Main.MsWappOpAmt);
							ReportDc.DataDefinition.FormulaFields["ClAmt"].Text = Conversions.ToString(DC_Main.MsWappClAmt);
						}
						else if (Operators.CompareString(DC_Main.MsWappPrintType, "SchmEnt", false) == 0)
						{
							ReportDc.DataDefinition.FormulaFields["TotalRecAmt"].Text = Conversions.ToString(DC_Main.MsWappOpAmt);
						}
						else if (Operators.CompareString(DC_Main.MsWappPrintType, "SlOrder", false) == 0)
						{
							ReportDc.DataDefinition.FormulaFields["OldItem"].Text = DC_Main.MsWappOrdOldItm;
							ReportDc.DataDefinition.FormulaFields["OpAmt"].Text = Conversions.ToString(DC_Main.MsWappOpAmt);
							ReportDc.DataDefinition.FormulaFields["ClAmt"].Text = Conversions.ToString(DC_Main.MsWappClAmt);
						}
						else if (Operators.CompareString(DC_Main.MsWappPrintType, "RtlSale", false) == 0)
						{
							ReportDc.DataDefinition.FormulaFields["OpAmt"].Text = Conversions.ToString(DC_Main.MsWappOpAmt);
							ReportDc.DataDefinition.FormulaFields["ClAmt"].Text = Conversions.ToString(DC_Main.MsWappClAmt);
						}
						else
						{
							if ((Operators.CompareString(DC_Main.MsWappPrintType, "WhSale", false) == 0) | (Operators.CompareString(DC_Main.MsWappPrintType, "KrIsu", false) == 0) | (Operators.CompareString(DC_Main.MsWappPrintType, "LbrWork", false) == 0) | (Operators.CompareString(DC_Main.MsWappPrintType, "WithFine", false) == 0))
							{
								ReportDc.DataDefinition.FormulaFields["OpGold"].Text = Conversions.ToString(DC_Main.MsWappOpGlFine);
								ReportDc.DataDefinition.FormulaFields["ClGold"].Text = Conversions.ToString(DC_Main.MsWappClGlFine);
								ReportDc.DataDefinition.FormulaFields["OpSilver"].Text = Conversions.ToString(DC_Main.MsWappOpSlFine);
								ReportDc.DataDefinition.FormulaFields["ClSilver"].Text = Conversions.ToString(DC_Main.MsWappClSlFine);
							}
							ReportDc.DataDefinition.FormulaFields["OpAmt"].Text = Conversions.ToString(DC_Main.MsWappOpAmt);
							ReportDc.DataDefinition.FormulaFields["ClAmt"].Text = Conversions.ToString(DC_Main.MsWappClAmt);
						}
					}
					if (Operators.CompareString(DC_Main.MsRptTitel, "", false) != 0 && Operators.CompareString(DC_Main.MsRptTitel, "", false) != 0)
					{
						ReportDc.DataDefinition.FormulaFields[DC_Main.MsRptTitel].Text = DC_Main.MsRptTitelStr;
					}
					if (Operators.CompareString(DC_Main.MsPrintType, "", false) != 0 && Operators.CompareString(DC_Main.MsPrintType, "", false) != 0)
					{
						ReportDc.DataDefinition.FormulaFields[DC_Main.MsPrintType].Text = DC_Main.MaPirntCopy;
					}
					if (Operators.CompareString(DC_Main.MsCrForName1, "", false) != 0)
					{
						if (Operators.CompareString(DC_Main.MsCrForStr1, "", false) != 0)
						{
							ReportDc.DataDefinition.FormulaFields[DC_Main.MsCrForName1].Text = DC_Main.MsCrForStr1;
						}
						else
						{
							ReportDc.DataDefinition.FormulaFields[DC_Main.MsCrForName1].Text = DC_Main.MsCrForVal1;
						}
					}
					if (Operators.CompareString(DC_Main.MsCrForName2, "", false) != 0)
					{
						if (Operators.CompareString(DC_Main.MsCrForStr2, "", false) != 0)
						{
							ReportDc.DataDefinition.FormulaFields[DC_Main.MsCrForName2].Text = DC_Main.MsCrForStr2;
						}
						else
						{
							ReportDc.DataDefinition.FormulaFields[DC_Main.MsCrForName2].Text = DC_Main.MsCrForVal2;
						}
					}
					if (Operators.CompareString(DC_Main.MsCrForName3, "", false) != 0)
					{
						if (Operators.CompareString(DC_Main.MsCrForStr3, "", false) != 0)
						{
							ReportDc.DataDefinition.FormulaFields[DC_Main.MsCrForName3].Text = DC_Main.MsCrForStr3;
						}
						else
						{
							ReportDc.DataDefinition.FormulaFields[DC_Main.MsCrForName3].Text = DC_Main.MsCrForVal3;
						}
					}
					if (Operators.CompareString(DC_Main.MsCrForName4, "", false) != 0)
					{
						if (Operators.CompareString(DC_Main.MsCrForStr4, "", false) != 0)
						{
							ReportDc.DataDefinition.FormulaFields[DC_Main.MsCrForName4].Text = DC_Main.MsCrForStr4;
						}
						else
						{
							ReportDc.DataDefinition.FormulaFields[DC_Main.MsCrForName4].Text = DC_Main.MsCrForVal4;
						}
					}
					if (Operators.CompareString(DC_Main.MsCrForName5, "", false) != 0)
					{
						if (Operators.CompareString(DC_Main.MsCrForStr5, "", false) != 0)
						{
							ReportDc.DataDefinition.FormulaFields[DC_Main.MsCrForName5].Text = DC_Main.MsCrForStr5;
						}
						else
						{
							ReportDc.DataDefinition.FormulaFields[DC_Main.MsCrForName5].Text = DC_Main.MsCrForVal5;
						}
					}
					if (Operators.CompareString(DC_Main.MsCrForName6, "", false) != 0)
					{
						if (Operators.CompareString(DC_Main.MsCrForStr6, "", false) != 0)
						{
							ReportDc.DataDefinition.FormulaFields[DC_Main.MsCrForName6].Text = DC_Main.MsCrForStr6;
						}
						else
						{
							ReportDc.DataDefinition.FormulaFields[DC_Main.MsCrForName6].Text = DC_Main.MsCrForVal6;
						}
					}
					if (Operators.CompareString(DC_Main.MsCrForName7, "", false) != 0)
					{
						if (Operators.CompareString(DC_Main.MsCrForStr7, "", false) != 0)
						{
							ReportDc.DataDefinition.FormulaFields[DC_Main.MsCrForName7].Text = DC_Main.MsCrForStr7;
						}
						else
						{
							ReportDc.DataDefinition.FormulaFields[DC_Main.MsCrForName6].Text = DC_Main.MsCrForVal7;
						}
					}
					if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
					{
						ReportDc.PrintToPrinter(1, false, 0, 0);
					}
					else
					{
						CrystalReportViewer1.ToolPanelView = (ToolPanelViewType)0;
						CrystalReportViewer1.ReportSource = ReportDc;
						CrystalReportViewer1.Zoom(DC_Main.MsPrintZoom);
					}
					DC_Main.MsWappOpAmt = 0.0;
					DC_Main.MsWappClAmt = 0.0;
					DC_Main.MsWappOpGlFine = 0.0;
					DC_Main.MsWappClGlFine = 0.0;
					DC_Main.MsWappOpSlFine = 0.0;
					DC_Main.MsWappClSlFine = 0.0;
					DC_Main.MsRptTitel = "";
					DC_Main.MsRptTitelStr = "";
					DC_Main.MsPrintType = "";
					DC_Main.MaPirntCopy = "";
					DC_Main.MsCrForName1 = "";
					DC_Main.MsCrForName2 = "";
					DC_Main.MsCrForName3 = "";
					DC_Main.MsCrForName4 = "";
					DC_Main.MsCrForName5 = "";
					DC_Main.MsCrForName6 = "";
					DC_Main.MsCrForName7 = "";
					DC_Main.MsCrForStr1 = "";
					DC_Main.MsCrForStr2 = "";
					DC_Main.MsCrForStr3 = "";
					DC_Main.MsCrForStr4 = "";
					DC_Main.MsCrForStr5 = "";
					DC_Main.MsCrForStr6 = "";
					DC_Main.MsCrForStr7 = "";
					DC_Main.MsCrForVal1 = Conversions.ToString(0);
					DC_Main.MsCrForVal2 = Conversions.ToString(0);
					DC_Main.MsCrForVal3 = Conversions.ToString(0);
					DC_Main.MsCrForVal4 = Conversions.ToString(0);
					DC_Main.MsCrForVal5 = Conversions.ToString(0);
					DC_Main.MsCrForVal6 = Conversions.ToString(0);
					DC_Main.MsCrForVal6 = Conversions.ToString(0);
					goto end_IL_0001;
				case 2512:
					num = -1;
					switch (num2)
					{
					case 2:
						Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
						goto end_IL_0001;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 2512;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void UT_REPORT_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void UT_REPORT_Load(object sender, EventArgs e)
	{
		MsFormLoad = true;
		((Form)this).Text = DC_Main.RptName + " Report";
		if (!Directory.Exists(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\PDF Reports"))
		{
			Directory.CreateDirectory(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\PDF Reports\\");
		}
		if (DC_Main.MsEmailOpen)
		{
			((Control)btneMail).Visible = true;
		}
		else
		{
			((Control)btneMail).Visible = false;
		}
	}

	private void BtnSendWapp_Click(object sender, EventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		if (Strings.Len(DC_Main.MsCustWappNo) <= 9)
		{
			Interaction.MsgBox((object)"Mobile No is Not Valid..", (MsgBoxStyle)0, (object)null);
		}
		else if (CheckForInternetConnection())
		{
			((Control)this).Cursor = Cursors.WaitCursor;
			Timer1.Enabled = true;
			if (!Directory.Exists(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\PDF Reports"))
			{
				Directory.CreateDirectory(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\PDF Reports\\");
			}
			DiskFileDestinationOptions val = new DiskFileDestinationOptions();
			PdfRtfWordFormatOptions exportFormatOptions = new PdfRtfWordFormatOptions();
			val.DiskFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\PDF Reports\\Report.pdf";
			ExportOptions val2 = (ExportOptions)NewLateBinding.LateGet(CrystalReportViewer1.ReportSource, (Type)null, "ExportOptions", new object[0], (string[])null, (Type[])null, (bool[])null);
			ExportOptions val3 = val2;
			val3.ExportDestinationType = (ExportDestinationType)1;
			val3.ExportFormatType = (ExportFormatType)5;
			val3.ExportDestinationOptions = (ExportDestinationOptions)(object)val;
			val3.ExportFormatOptions = (ExportFormatOptions)(object)exportFormatOptions;
			val3 = null;
			NewLateBinding.LateCall(CrystalReportViewer1.ReportSource, (Type)null, "Export", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			WhatsAppSender();
		}
		else
		{
			MessageBox.Show("Please check your internet connection", "Checking", (MessageBoxButtons)0, (MessageBoxIcon)16);
		}
	}

	private void UT_REPORT_Closed(object sender, EventArgs e)
	{
		string path = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\PDF Reports";
		string[] files = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
		foreach (string path2 in files)
		{
			File.Delete(path2);
		}
	}

	public bool CheckForInternetConnection()
	{
		Thread.Sleep(1000);
		bool result;
		try
		{
			using WebClient webClient = new WebClient();
			using (webClient.OpenRead("http://www.google.com"))
			{
				result = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private async void WhatsAppSender()
	{
		((Control)this).Cursor = Cursors.WaitCursor;
		Timer1.Enabled = true;
		try
		{
			MessageRequest val = new MessageRequest();
			val.Phone = DC_Main.MsCustWappNo;
			val.Message = "This is a " + DC_Main.MCo_Name + " File..";
			val.AttachmentPath = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\PDF Reports\\Report.pdf";
			MessageRequest request = val;
			object objectValue = RuntimeHelpers.GetObjectValue(await whatsApp.Send(request));
			MessageBox.Show(Conversions.ToString(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, (Type)null, "Status", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Description", new object[0], (string[])null, (Type[])null, (bool[])null))));
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			MessageBox.Show(ex3.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void btneMail_Click(object sender, EventArgs e)
	{
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Expected O, but got Unknown
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		if (CheckForInternetConnection())
		{
			string text = "";
			string text2 = "";
			DC_Main.RsQry = "SELECT CO_MAIL,MAIL_API From CO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND MAIL_API <> ''";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CO_MAIL"], (object)""));
				text2 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MAIL_API"], (object)""));
				if (Operators.CompareString(DC_Main.MsCustMail, "", false) != 0)
				{
					((Control)this).Cursor = Cursors.WaitCursor;
					Timer1.Enabled = true;
					if (!Directory.Exists(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\PDF Reports"))
					{
						Directory.CreateDirectory(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\PDF Reports\\");
					}
					DiskFileDestinationOptions val = new DiskFileDestinationOptions();
					PdfRtfWordFormatOptions exportFormatOptions = new PdfRtfWordFormatOptions();
					val.DiskFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\PDF Reports\\Report.pdf";
					ExportOptions val2 = (ExportOptions)NewLateBinding.LateGet(CrystalReportViewer1.ReportSource, (Type)null, "ExportOptions", new object[0], (string[])null, (Type[])null, (bool[])null);
					ExportOptions val3 = val2;
					val3.ExportDestinationType = (ExportDestinationType)1;
					val3.ExportFormatType = (ExportFormatType)5;
					val3.ExportDestinationOptions = (ExportDestinationOptions)(object)val;
					val3.ExportFormatOptions = (ExportFormatOptions)(object)exportFormatOptions;
					val3 = null;
					NewLateBinding.LateCall(CrystalReportViewer1.ReportSource, (Type)null, "Export", new object[0], (string[])null, (Type[])null, (bool[])null, true);
					try
					{
						MailMessage mailMessage = new MailMessage();
						mailMessage.From = new MailAddress(text);
						mailMessage.To.Add(DC_Main.MsCustMail);
						mailMessage.Subject = DC_Main.MCo_Name + " PDF Attachment";
						mailMessage.Body = "Please find the attached PDF file...";
						Attachment attachment = new Attachment(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\PDF Reports\\Report.pdf");
						mailMessage.Attachments.Add(attachment);
						SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
						smtpClient.Credentials = new NetworkCredential(text, text2);
						smtpClient.EnableSsl = true;
						smtpClient.Send(mailMessage);
						MessageBox.Show("Email sent successfully.");
						attachment.Dispose();
						((Control)this).Cursor = Cursors.Default;
						return;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						Interaction.MsgBox((object)"Mail Send Faild...", (MsgBoxStyle)0, (object)null);
						((Control)this).Cursor = Cursors.Default;
						ProjectData.ClearProjectError();
						return;
					}
					finally
					{
						GC.Collect();
						GC.WaitForPendingFinalizers();
					}
				}
				Interaction.MsgBox((object)"Please Insert e Mail id in Party Master then Try...", (MsgBoxStyle)0, (object)null);
			}
			else
			{
				Interaction.MsgBox((object)"Please Update Company Mail Id and Api Then Try...", (MsgBoxStyle)0, (object)null);
			}
		}
		else
		{
			MessageBox.Show("Please check your internet connection", "Checking", (MessageBoxButtons)0, (MessageBoxIcon)16);
		}
	}
}
