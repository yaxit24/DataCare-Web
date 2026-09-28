using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
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

[StandardModule]
internal sealed class Module_Save
{
	public static SqlTransaction TagEntTran;

	public static SqlTransaction SlTran;

	public static SqlTransaction WhTran;

	public static SqlTransaction LbrTran;

	public static SqlTransaction PurcTran;

	public static SqlTransaction TranPosting;

	public static string MsRendomTag;

	public static string MsRendomWithPrCode;

	private static Module_WhatsApp whatsApp = UT_WHATSAPP.whatsApp;

	private static bool MsFormLoad;

	public static DataTable OpenRecordSetDcSave(string sql, SqlTransaction tran = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		DataTable dataTable = new DataTable();
		DC_Main.Da = new SqlDataAdapter();
		SqlCommand val = new SqlCommand(sql, DC_Main.Dc);
		if (tran != null)
		{
			val.Transaction = tran;
		}
		DC_Main.Da.SelectCommand = val;
		((DbDataAdapter)(object)DC_Main.Da).Fill(dataTable);
		return dataTable;
	}

	public static void ExeQuteDcSave(string sql, SqlTransaction tran = null)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		if (DC_Main.Dc.State != ConnectionState.Open)
		{
			DC_Main.Dc.Open();
		}
		SqlCommand val = new SqlCommand(sql, DC_Main.Dc);
		try
		{
			if (tran != null)
			{
				val.Transaction = tran;
			}
			val.ExecuteNonQuery();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void MsInsertDataSave(SqlTransaction tran = null)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		DC_Main.SqlBldr = new SqlCommandBuilder(DC_Main.Da);
		DC_Main.Da.InsertCommand = DC_Main.SqlBldr.GetInsertCommand();
		if (tran != null)
		{
			DC_Main.Da.InsertCommand.Transaction = tran;
			DC_Main.Da.InsertCommand.Connection = DC_Main.Dc;
		}
	}

	public static void PrintReportDirect()
	{
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Expected O, but got Unknown
		try
		{
			ReportDocument val = new ReportDocument();
			try
			{
				val.Load(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + DC_Main.RptName + ".rpt");
				val.RecordSelectionFormula = DC_Main.RptFormula;
				val.SetDatabaseLogon(DC_Main.SqlId, DC_Main.SqlPwd);
				if (Operators.CompareString(DC_Main.MsWappPrintType, "All", false) != 0)
				{
					if (Operators.CompareString(DC_Main.MsWappPrintType, "AmtBal", false) == 0)
					{
						val.DataDefinition.FormulaFields["OpAmt"].Text = Conversions.ToString(DC_Main.MsWappOpAmt);
						val.DataDefinition.FormulaFields["ClAmt"].Text = Conversions.ToString(DC_Main.MsWappClAmt);
					}
					else if (Operators.CompareString(DC_Main.MsWappPrintType, "SchmEnt", false) == 0)
					{
						val.DataDefinition.FormulaFields["TotalRecAmt"].Text = Conversions.ToString(DC_Main.MsWappOpAmt);
					}
					else if (Operators.CompareString(DC_Main.MsWappPrintType, "SlOrder", false) == 0)
					{
						val.DataDefinition.FormulaFields["OldItem"].Text = DC_Main.MsWappOrdOldItm;
						val.DataDefinition.FormulaFields["OpAmt"].Text = Conversions.ToString(DC_Main.MsWappOpAmt);
						val.DataDefinition.FormulaFields["ClAmt"].Text = Conversions.ToString(DC_Main.MsWappClAmt);
					}
					else if (Operators.CompareString(DC_Main.MsWappPrintType, "RtlSale", false) == 0)
					{
						val.DataDefinition.FormulaFields["OpAmt"].Text = Conversions.ToString(DC_Main.MsWappOpAmt);
						val.DataDefinition.FormulaFields["ClAmt"].Text = Conversions.ToString(DC_Main.MsWappClAmt);
					}
					else
					{
						if ((Operators.CompareString(DC_Main.MsWappPrintType, "WhSale", false) == 0) | (Operators.CompareString(DC_Main.MsWappPrintType, "KrIsu", false) == 0) | (Operators.CompareString(DC_Main.MsWappPrintType, "LbrWork", false) == 0) | (Operators.CompareString(DC_Main.MsWappPrintType, "WithFine", false) == 0))
						{
							val.DataDefinition.FormulaFields["OpGold"].Text = Conversions.ToString(DC_Main.MsWappOpGlFine);
							val.DataDefinition.FormulaFields["ClGold"].Text = Conversions.ToString(DC_Main.MsWappClGlFine);
							val.DataDefinition.FormulaFields["OpSilver"].Text = Conversions.ToString(DC_Main.MsWappOpSlFine);
							val.DataDefinition.FormulaFields["ClSilver"].Text = Conversions.ToString(DC_Main.MsWappClSlFine);
						}
						val.DataDefinition.FormulaFields["OpAmt"].Text = Conversions.ToString(DC_Main.MsWappOpAmt);
						val.DataDefinition.FormulaFields["ClAmt"].Text = Conversions.ToString(DC_Main.MsWappClAmt);
					}
				}
				if (Operators.CompareString(DC_Main.MsRptTitel, "", false) != 0 && Operators.CompareString(DC_Main.MsRptTitel, "", false) != 0)
				{
					val.DataDefinition.FormulaFields[DC_Main.MsRptTitel].Text = DC_Main.MsRptTitelStr;
				}
				if (Operators.CompareString(DC_Main.MsPrintType, "", false) != 0 && Operators.CompareString(DC_Main.MsPrintType, "", false) != 0)
				{
					val.DataDefinition.FormulaFields[DC_Main.MsPrintType].Text = DC_Main.MaPirntCopy;
				}
				val.PrintToPrinter(1, false, 0, 0);
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
			Interaction.MsgBox((object)("Print error: " + ex2.Message), (MsgBoxStyle)48, (object)"Print Error");
			ProjectData.ClearProjectError();
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
	}

	public static void ShowReportPreview()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_085c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0861: Unknown result type (might be due to invalid IL or missing references)
		//IL_0877: Unknown result type (might be due to invalid IL or missing references)
		//IL_0884: Expected O, but got Unknown
		//IL_0884: Unknown result type (might be due to invalid IL or missing references)
		//IL_088b: Expected O, but got Unknown
		//IL_08db: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0906: Unknown result type (might be due to invalid IL or missing references)
		//IL_0912: Unknown result type (might be due to invalid IL or missing references)
		//IL_091c: Expected O, but got Unknown
		//IL_0922: Expected O, but got Unknown
		//IL_0923: Unknown result type (might be due to invalid IL or missing references)
		//IL_0928: Unknown result type (might be due to invalid IL or missing references)
		//IL_0934: Unknown result type (might be due to invalid IL or missing references)
		//IL_0942: Unknown result type (might be due to invalid IL or missing references)
		//IL_094e: Unknown result type (might be due to invalid IL or missing references)
		//IL_095a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0964: Expected O, but got Unknown
		//IL_096a: Expected O, but got Unknown
		//IL_0a87: Unknown result type (might be due to invalid IL or missing references)
		ReportDocument val = new ReportDocument();
		val.Load(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + DC_Main.RptName + ".rpt");
		val.SetDatabaseLogon(DC_Main.SqlId, DC_Main.SqlPwd);
		if (Operators.CompareString(DC_Main.MsWappPrintType, "All", false) != 0)
		{
			if (Operators.CompareString(DC_Main.MsWappPrintType, "AmtBal", false) == 0)
			{
				val.DataDefinition.FormulaFields["OpAmt"].Text = Conversions.ToString(DC_Main.MsWappOpAmt);
				val.DataDefinition.FormulaFields["ClAmt"].Text = Conversions.ToString(DC_Main.MsWappClAmt);
			}
			else if (Operators.CompareString(DC_Main.MsWappPrintType, "SchmEnt", false) == 0)
			{
				val.DataDefinition.FormulaFields["TotalRecAmt"].Text = Conversions.ToString(DC_Main.MsWappOpAmt);
			}
			else if (Operators.CompareString(DC_Main.MsWappPrintType, "SlOrder", false) == 0)
			{
				val.DataDefinition.FormulaFields["OldItem"].Text = DC_Main.MsWappOrdOldItm;
				val.DataDefinition.FormulaFields["OpAmt"].Text = Conversions.ToString(DC_Main.MsWappOpAmt);
				val.DataDefinition.FormulaFields["ClAmt"].Text = Conversions.ToString(DC_Main.MsWappClAmt);
			}
			else if (Operators.CompareString(DC_Main.MsWappPrintType, "RtlSale", false) == 0)
			{
				val.DataDefinition.FormulaFields["OpAmt"].Text = Conversions.ToString(DC_Main.MsWappOpAmt);
				val.DataDefinition.FormulaFields["ClAmt"].Text = Conversions.ToString(DC_Main.MsWappClAmt);
			}
			else
			{
				val.DataDefinition.FormulaFields["OpAmt"].Text = Conversions.ToString(DC_Main.MsWappOpAmt);
				val.DataDefinition.FormulaFields["ClAmt"].Text = Conversions.ToString(DC_Main.MsWappClAmt);
				if ((Operators.CompareString(DC_Main.MsWappPrintType, "WhSale", false) == 0) | (Operators.CompareString(DC_Main.MsWappPrintType, "KrIsu", false) == 0) | (Operators.CompareString(DC_Main.MsWappPrintType, "LbrWork", false) == 0) | (Operators.CompareString(DC_Main.MsWappPrintType, "WithFine", false) == 0))
				{
					val.DataDefinition.FormulaFields["OpGold"].Text = Conversions.ToString(DC_Main.MsWappOpGlFine);
					val.DataDefinition.FormulaFields["ClGold"].Text = Conversions.ToString(DC_Main.MsWappClGlFine);
					val.DataDefinition.FormulaFields["OpSilver"].Text = Conversions.ToString(DC_Main.MsWappOpSlFine);
					val.DataDefinition.FormulaFields["ClSilver"].Text = Conversions.ToString(DC_Main.MsWappClSlFine);
				}
			}
		}
		if (Operators.CompareString(DC_Main.MsRptTitel, "", false) != 0 && Operators.CompareString(DC_Main.MsRptTitel, "", false) != 0)
		{
			val.DataDefinition.FormulaFields[DC_Main.MsRptTitel].Text = DC_Main.MsRptTitelStr;
		}
		if (Operators.CompareString(DC_Main.MsPrintType, "", false) != 0 && Operators.CompareString(DC_Main.MsPrintType, "", false) != 0)
		{
			val.DataDefinition.FormulaFields[DC_Main.MsPrintType].Text = DC_Main.MaPirntCopy;
		}
		if (Operators.CompareString(DC_Main.MsCrForName1, "", false) != 0)
		{
			if (Operators.CompareString(DC_Main.MsCrForStr1, "", false) != 0)
			{
				val.DataDefinition.FormulaFields[DC_Main.MsCrForName1].Text = DC_Main.MsCrForStr1;
			}
			else
			{
				val.DataDefinition.FormulaFields[DC_Main.MsCrForName1].Text = DC_Main.MsCrForVal1;
			}
		}
		if (Operators.CompareString(DC_Main.MsCrForName2, "", false) != 0)
		{
			if (Operators.CompareString(DC_Main.MsCrForStr2, "", false) != 0)
			{
				val.DataDefinition.FormulaFields[DC_Main.MsCrForName2].Text = DC_Main.MsCrForStr2;
			}
			else
			{
				val.DataDefinition.FormulaFields[DC_Main.MsCrForName2].Text = DC_Main.MsCrForVal2;
			}
		}
		if (Operators.CompareString(DC_Main.MsCrForName3, "", false) != 0)
		{
			if (Operators.CompareString(DC_Main.MsCrForStr3, "", false) != 0)
			{
				val.DataDefinition.FormulaFields[DC_Main.MsCrForName3].Text = DC_Main.MsCrForStr3;
			}
			else
			{
				val.DataDefinition.FormulaFields[DC_Main.MsCrForName3].Text = DC_Main.MsCrForVal3;
			}
		}
		if (Operators.CompareString(DC_Main.MsCrForName4, "", false) != 0)
		{
			if (Operators.CompareString(DC_Main.MsCrForStr4, "", false) != 0)
			{
				val.DataDefinition.FormulaFields[DC_Main.MsCrForName4].Text = DC_Main.MsCrForStr4;
			}
			else
			{
				val.DataDefinition.FormulaFields[DC_Main.MsCrForName4].Text = DC_Main.MsCrForVal4;
			}
		}
		if (Operators.CompareString(DC_Main.MsCrForName5, "", false) != 0)
		{
			if (Operators.CompareString(DC_Main.MsCrForStr5, "", false) != 0)
			{
				val.DataDefinition.FormulaFields[DC_Main.MsCrForName5].Text = DC_Main.MsCrForStr5;
			}
			else
			{
				val.DataDefinition.FormulaFields[DC_Main.MsCrForName5].Text = DC_Main.MsCrForVal5;
			}
		}
		if (Operators.CompareString(DC_Main.MsCrForName6, "", false) != 0)
		{
			if (Operators.CompareString(DC_Main.MsCrForStr6, "", false) != 0)
			{
				val.DataDefinition.FormulaFields[DC_Main.MsCrForName6].Text = DC_Main.MsCrForStr6;
			}
			else
			{
				val.DataDefinition.FormulaFields[DC_Main.MsCrForName6].Text = DC_Main.MsCrForVal6;
			}
		}
		if (Operators.CompareString(DC_Main.MsCrForName7, "", false) != 0)
		{
			if (Operators.CompareString(DC_Main.MsCrForStr7, "", false) != 0)
			{
				val.DataDefinition.FormulaFields[DC_Main.MsCrForName7].Text = DC_Main.MsCrForStr7;
			}
			else
			{
				val.DataDefinition.FormulaFields[DC_Main.MsCrForName6].Text = DC_Main.MsCrForVal7;
			}
		}
		if (Operators.CompareString(DC_Main.RptFormula, "", false) != 0)
		{
			val.RecordSelectionFormula = DC_Main.RptFormula;
		}
		if (Operators.CompareString(DC_Main.MsPrintType, "", false) != 0 && Operators.CompareString(DC_Main.MaPirntCopy, "", false) != 0)
		{
			val.DataDefinition.FormulaFields[DC_Main.MsPrintType].Text = DC_Main.MaPirntCopy;
		}
		Form val2 = new Form
		{
			Text = "Report Preview - " + DC_Main.RptName,
			WindowState = (FormWindowState)2
		};
		CrystalReportViewer val3 = new CrystalReportViewer();
		((Control)val3).Dock = (DockStyle)5;
		val3.ToolPanelView = (ToolPanelViewType)0;
		val3.ReportSource = val;
		CrystalReportViewer val4 = val3;
		val4.Zoom(DC_Main.MsPrintZoom);
		int height = 30;
		int width = 125;
		int y = 5;
		int num = 175;
		int num2 = 10;
		Button val5 = new Button
		{
			Text = "Send WhatsApp",
			Size = new Size(width, height),
			BackColor = Color.Transparent,
			Font = new Font("Segoe UI", 10f, (FontStyle)0)
		};
		Button val6 = new Button
		{
			Text = "Send Email",
			Size = new Size(width, height),
			BackColor = Color.Transparent,
			Font = new Font("Segoe UI", 10f, (FontStyle)0)
		};
		checked
		{
			((Control)val5).Location = new Point(val2.ClientSize.Width - ((Control)val5).Width - num, y);
			((Control)val6).Location = new Point(val2.ClientSize.Width - ((Control)val5).Width - ((Control)val6).Width - num2 - num, y);
			((Control)val2).Resize += [SpecialName] (object sender, EventArgs e) =>
			{
				((Control)val5).Location = new Point(val2.ClientSize.Width - ((Control)val5).Width - num, y);
				((Control)val6).Location = new Point(val2.ClientSize.Width - ((Control)val5).Width - ((Control)val6).Width - num2 - num, y);
			};
			((Control)val6).Click += [SpecialName] (object sender, EventArgs e) =>
			{
				//IL_0248: Unknown result type (might be due to invalid IL or missing references)
				//IL_0282: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
				//IL_021d: Unknown result type (might be due to invalid IL or missing references)
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
							Cursor.Current = Cursors.WaitCursor;
							string text3 = Path.Combine(((ApplicationBase)MyProject.Application).Info.DirectoryPath, "PDF Reports\\Report.pdf");
							if (!Directory.Exists(Path.Combine(((ApplicationBase)MyProject.Application).Info.DirectoryPath, "PDF Reports")))
							{
								Directory.CreateDirectory(Path.Combine(((ApplicationBase)MyProject.Application).Info.DirectoryPath, "PDF Reports"));
							}
							val.ExportToDisk((ExportFormatType)5, text3);
							try
							{
								MailMessage mailMessage = new MailMessage
								{
									From = new MailAddress(text),
									To = { DC_Main.MsCustMail },
									Subject = DC_Main.MCo_Name + " PDF Attachment",
									Body = "Please find the attached PDF file..."
								};
								Attachment attachment = new Attachment(((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\PDF Reports\\Report.pdf");
								mailMessage.Attachments.Add(attachment);
								SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
								smtpClient.Credentials = new NetworkCredential(text, text2);
								smtpClient.EnableSsl = true;
								smtpClient.Send(mailMessage);
								MessageBox.Show("Email sent successfully.");
								attachment.Dispose();
								Cursor.Current = Cursors.Default;
								return;
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception ex2 = ex;
								Interaction.MsgBox((object)"Mail Send Faild...", (MsgBoxStyle)0, (object)null);
								Cursor.Current = Cursors.Default;
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
			};
			((Control)val5).Click += [SpecialName] (object sender, EventArgs e) =>
			{
				//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
				//IL_001d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0045: Unknown result type (might be due to invalid IL or missing references)
				if (Strings.Len(DC_Main.MsCustWappNo) <= 9)
				{
					Interaction.MsgBox((object)"Mobile No is Not Valid..", (MsgBoxStyle)0, (object)null);
				}
				else
				{
					if (CheckForInternetConnection())
					{
						Cursor.Current = Cursors.WaitCursor;
						try
						{
							string text = Path.Combine(((ApplicationBase)MyProject.Application).Info.DirectoryPath, "PDF Reports\\Report.pdf");
							if (!Directory.Exists(Path.Combine(((ApplicationBase)MyProject.Application).Info.DirectoryPath, "PDF Reports")))
							{
								Directory.CreateDirectory(Path.Combine(((ApplicationBase)MyProject.Application).Info.DirectoryPath, "PDF Reports"));
							}
							val.ExportToDisk((ExportFormatType)5, text);
							WhatsAppSender();
							return;
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							Interaction.MsgBox((object)ex2.Message, (MsgBoxStyle)Conversions.ToInteger("Error"), (object)null);
							ProjectData.ClearProjectError();
							return;
						}
						finally
						{
							Cursor.Current = Cursors.Default;
						}
					}
					Interaction.MsgBox((object)"Please check your internet connection", (MsgBoxStyle)Conversions.ToInteger("Checking"), (object)null);
				}
			};
			((Control)val2).Controls.Add((Control)(object)val6);
			((Control)val2).Controls.Add((Control)(object)val5);
			((Control)val2).Controls.Add((Control)(object)val4);
			val2.ShowDialog();
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
		}
	}

	private static bool CheckForInternetConnection()
	{
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

	private static async void WhatsAppSender()
	{
		Cursor.Current = Cursors.WaitCursor;
		try
		{
			string attachmentPath = Path.Combine(((ApplicationBase)MyProject.Application).Info.DirectoryPath, "PDF Reports\\Report.pdf");
			MessageRequest val = new MessageRequest();
			val.Phone = DC_Main.MsCustWappNo;
			val.Message = null;
			val.AttachmentPath = attachmentPath;
			MessageRequest request = val;
			object objectValue = RuntimeHelpers.GetObjectValue(await whatsApp.Send(request));
			MessageBox.Show(Conversions.ToString(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, (Type)null, "Status", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Description", new object[0], (string[])null, (Type[])null, (bool[])null))), "WhatsApp", (MessageBoxButtons)0, (MessageBoxIcon)64);
			Application.DoEvents();
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK282NAST", false) != 0)
			{
				string message = "This Pdf File Is " + DC_Main.MCo_Name + " File..";
				MessageRequest val2 = new MessageRequest();
				val2.Phone = DC_Main.MsCountryId + DC_Main.MsCustWappNo;
				val2.Message = message;
				val2.AttachmentPath = "";
				MessageRequest request2 = val2;
				RuntimeHelpers.GetObjectValue(await whatsApp.Send(request2));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			MessageBox.Show(ex3.Message, "Error", (MessageBoxButtons)0, (MessageBoxIcon)16);
			ProjectData.ClearProjectError();
		}
		finally
		{
			Cursor.Current = Cursors.Default;
		}
	}

	public static string RendomTagGen(string CoBook, string TagPrefix = "")
	{
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		string text2 = "";
		Random random = new Random(Guid.NewGuid().GetHashCode());
		string text3 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		int num = 100;
		int num2 = ((Operators.CompareString(MsRendomWithPrCode, "Y", false) != 0) ? 7 : 5);
		int num3 = num;
		checked
		{
			for (int i = 1; i <= num3; i++)
			{
				text = "";
				int num4 = num2;
				for (int j = 1; j <= num4; j++)
				{
					text += Conversions.ToString(text3[random.Next(0, text3.Length)]);
				}
				text2 = TagPrefix + text;
				DC_Main.RsQry = "SELECT TAG_NO FROM BAR_DETL WHERE TAG_NO = '" + text2 + "'";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count == 0)
				{
					DC_Main.RsQry = "SELECT TAG_NO FROM TAG_SET WHERE TAG_NO = '" + text2 + "'";
					DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable2.Rows.Count == 0)
					{
						return text2;
					}
				}
			}
			Interaction.MsgBox((object)("Random Tag Generation Failed After " + Conversions.ToString(num) + " Attempts!"), (MsgBoxStyle)48, (object)"Tag Error");
			return "";
		}
	}
}
