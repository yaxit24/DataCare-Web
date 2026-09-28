using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DataCareNext.My;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class MS_OPNCOMP : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LblExit")]
	private Label _LblExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tlcCode")]
	private TextBox _tlcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tYearCode")]
	private TextBox _tYearCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCoCode")]
	private TextBox _tCoCode;

	private bool CurProcess;

	private bool MsRegSoft;

	private bool MsWhoutAmc;

	internal virtual Label LblExit
	{
		[CompilerGenerated]
		get
		{
			return _LblExit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = LblExit_Click;
			Label val = _LblExit;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_LblExit = value;
			val = _LblExit;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblLcName")]
	private virtual Label _lblLcName;

	internal virtual Label lblLcName
	{
		get
		{
			return _lblLcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblLcName = value;
		}
	}

	internal virtual TextBox tlcCode
	{
		[CompilerGenerated]
		get
		{
			return _tlcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TlcCode_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tlcCode_KeyDown);
			TextBox val2 = _tlcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tlcCode = value;
			val2 = _tlcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tYearCode
	{
		[CompilerGenerated]
		get
		{
			return _tYearCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tYearCode_KeyDown);
			EventHandler eventHandler = tYearCode_TextChanged;
			EventHandler eventHandler2 = tYearCode_GotFocus;
			TextBox val2 = _tYearCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).GotFocus -= eventHandler2;
			}
			_tYearCode = value;
			val2 = _tYearCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).GotFocus += eventHandler2;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblCompany")]
	private virtual Label _lblCompany;

	internal virtual Label lblCompany
	{
		get
		{
			return _lblCompany;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblCompany = value;
		}
	}

	internal virtual TextBox tCoCode
	{
		[CompilerGenerated]
		get
		{
			return _tCoCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TCoCode_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tCoCode_KeyDown);
			EventHandler eventHandler2 = tCoCode_GotFocus;
			TextBox val2 = _tCoCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler2;
			}
			_tCoCode = value;
			val2 = _tCoCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler2;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMonth")]
	private virtual TextBox _tMonth;

	internal virtual TextBox tMonth
	{
		get
		{
			return _tMonth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tMonth = value;
		}
	}

	public MS_OPNCOMP()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		((Form)this).Load += MS_OPNCOMP_Load;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_OPNCOMP_KeyPress);
		CurProcess = false;
		MsRegSoft = true;
		MsWhoutAmc = false;
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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected O, but got Unknown
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected O, but got Unknown
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Expected O, but got Unknown
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0546: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_OPNCOMP));
		LblExit = new Label();
		lblLcName = new Label();
		tlcCode = new TextBox();
		tYearCode = new TextBox();
		lblCompany = new Label();
		tCoCode = new TextBox();
		tMonth = new TextBox();
		((Control)this).SuspendLayout();
		LblExit.AutoSize = true;
		((Control)LblExit).BackColor = Color.Transparent;
		((Control)LblExit).Font = new Font("Segoe UI Semibold", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)LblExit).ForeColor = Color.White;
		((Control)LblExit).Location = new Point(628, 252);
		((Control)LblExit).Name = "LblExit";
		((Control)LblExit).Size = new Size(44, 25);
		((Control)LblExit).TabIndex = 3;
		LblExit.Text = "Exit";
		((Control)lblLcName).BackColor = Color.Transparent;
		((Control)lblLcName).Font = new Font("Segoe UI Semibold", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblLcName).ForeColor = Color.White;
		((Control)lblLcName).Location = new Point(421, 184);
		((Control)lblLcName).Name = "lblLcName";
		((Control)lblLcName).Size = new Size(456, 25);
		((Control)lblLcName).TabIndex = 12;
		lblLcName.Text = "Location Name";
		lblLcName.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tlcCode).BackColor = Color.Gainsboro;
		((Control)tlcCode).Font = new Font("Segoe UI Semibold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tlcCode).ForeColor = Color.Maroon;
		((Control)tlcCode).Location = new Point(610, 150);
		((Control)tlcCode).Name = "tlcCode";
		((Control)tlcCode).Size = new Size(75, 27);
		((Control)tlcCode).TabIndex = 9;
		tlcCode.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)tYearCode).BackColor = Color.Gainsboro;
		((Control)tYearCode).Font = new Font("Segoe UI Semibold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tYearCode).ForeColor = Color.Maroon;
		((Control)tYearCode).Location = new Point(593, 222);
		((Control)tYearCode).Name = "tYearCode";
		((Control)tYearCode).Size = new Size(110, 27);
		((Control)tYearCode).TabIndex = 10;
		tYearCode.TextAlign = (HorizontalAlignment)2;
		((Control)lblCompany).BackColor = Color.Transparent;
		((Control)lblCompany).Font = new Font("Segoe UI Semibold", 14.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblCompany).ForeColor = Color.White;
		((Control)lblCompany).Location = new Point(420, 113);
		((Control)lblCompany).Name = "lblCompany";
		((Control)lblCompany).Size = new Size(456, 25);
		((Control)lblCompany).TabIndex = 11;
		lblCompany.Text = "Company Name";
		lblCompany.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tCoCode).BackColor = Color.Gainsboro;
		((Control)tCoCode).Font = new Font("Segoe UI Semibold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tCoCode).ForeColor = Color.Maroon;
		((Control)tCoCode).Location = new Point(619, 78);
		((Control)tCoCode).Name = "tCoCode";
		((Control)tCoCode).Size = new Size(58, 27);
		((Control)tCoCode).TabIndex = 8;
		tCoCode.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)tMonth).BackColor = Color.Gainsboro;
		((Control)tMonth).Font = new Font("Segoe UI Semibold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tMonth).ForeColor = Color.Maroon;
		((Control)tMonth).Location = new Point(710, 222);
		((TextBoxBase)tMonth).MaxLength = 2;
		((Control)tMonth).Name = "tMonth";
		((TextBoxBase)tMonth).ReadOnly = true;
		((Control)tMonth).Size = new Size(36, 27);
		((Control)tMonth).TabIndex = 13;
		tMonth.TextAlign = (HorizontalAlignment)2;
		((Control)tMonth).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).AutoSize = true;
		((Control)this).BackgroundImage = (Image)componentResourceManager.GetObject("$this.BackgroundImage");
		((Control)this).BackgroundImageLayout = (ImageLayout)3;
		((Form)this).ClientSize = new Size(1366, 768);
		((Control)this).Controls.Add((Control)(object)tMonth);
		((Control)this).Controls.Add((Control)(object)lblLcName);
		((Control)this).Controls.Add((Control)(object)tlcCode);
		((Control)this).Controls.Add((Control)(object)tYearCode);
		((Control)this).Controls.Add((Control)(object)lblCompany);
		((Control)this).Controls.Add((Control)(object)tCoCode);
		((Control)this).Controls.Add((Control)(object)LblExit);
		((Control)this).DoubleBuffered = true;
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Control)this).Name = "MS_OPNCOMP";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "S_U";
		((Form)this).WindowState = (FormWindowState)2;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MS_OPNCOMP_Load(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS023NPBU", false) != 0)
		{
			DC_Main.MainPcW = 1366.0;
			DC_Main.MainPcH = 768.0;
			DC_Main.PcW = Screen.PrimaryScreen.Bounds.Width;
			DC_Main.PcH = Screen.PrimaryScreen.Bounds.Height;
			((Control)this).SuspendLayout();
			((Control)this).ResumeLayout();
			((Control)tCoCode).Location = new Point(619, 78);
			((Control)lblCompany).Location = new Point(420, 113);
			((Control)tlcCode).Location = new Point(610, 150);
			((Control)lblLcName).Location = new Point(421, 184);
			((Control)tYearCode).Location = new Point(592, 219);
			((Control)tMonth).Location = new Point(710, 219);
			((Control)LblExit).Location = new Point(628, 252);
			((Control)this).Dock = (DockStyle)5;
		}
		tlcCode.Text = DC_Main.CurLc;
		DC_Main.MLc_code = DC_Main.CurLc;
		if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/953XBZ2/CNFCW0097502A5/Z", false) == 0)
		{
			tlcCode.Text = "01";
			DC_Main.CurLc = "01";
		}
		if (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2G6QZ4Z", false) == 0)
		{
			tlcCode.Text = "02";
			DC_Main.CurLc = "02";
		}
	}

	private void LblExit_Click(object sender, EventArgs e)
	{
		Application.Exit();
	}

	private void TCoCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tCoCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		CurProcess = false;
		if ((Operators.CompareString(DC_Main.MsOneCoOpen, "", false) != 0) & (Operators.CompareString(tCoCode.Text, "", false) != 0))
		{
			DC_Main.RsQry = "Select * From CO_MAST WHERE  CO_CODE = '" + tCoCode.Text + "' and " + DC_Main.MsOneCoOpen + " = " + tCoCode.Text + " ";
		}
		else
		{
			DC_Main.RsQry = "Select * From CO_MAST WHERE  CO_CODE = '" + tCoCode.Text + "'";
		}
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count <= 0)
		{
			if (Operators.CompareString(DC_Main.MsOneCoOpen, "", false) != 0)
			{
				DC_Main.RsQry = "SELECT CO_CODE As CodeL,CO_NAME as NameL,CO_ADD1 As AddressL,CO_CITY as CityL FROM CO_MAST WHERE CO_CODE = '" + DC_Main.MsOneCoOpen + "' ";
			}
			else
			{
				DC_Main.RsQry = "SELECT CO_CODE As CodeL,CO_NAME as NameL,CO_ADD1 As AddressL,CO_CITY as CityL FROM CO_MAST ORDER BY CO_CODE";
			}
			DC_Main.RsDg = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[4];
			DC_Main.ColWidth[0] = 70.0;
			DC_Main.ColWidth[1] = 280.0;
			DC_Main.ColWidth[2] = 300.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tCoCode.Text = DC_Main.ColValue[0];
				lblCompany.Text = DC_Main.ColValue[1];
				DC_Main.MCo_code = tCoCode.Text;
				((TextBoxBase)tCoCode).SelectAll();
			}
			return;
		}
		lblCompany.Text = Conversions.ToString(DC_Main.Rshlp.Rows[0]["CO_NAME"]);
		DC_Main.MCo_code = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_CODE"], (object)""));
		DC_Main.MCo_Name = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_NAME"], (object)""));
		DC_Main.MCo_Type = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_TYPE"], (object)""));
		DC_Main.MCo_SName = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_SNAME"], (object)""));
		DC_Main.MsAdminMobile = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_MOBILE"], (object)""));
		DC_Main.MCo_State = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_STATE"], (object)""));
		DC_Main.MsAlterYear = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ALTER_YEAR"], (object)""));
		DC_Main.MsWorkType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["WORK_TYPE"], (object)""));
		if (Operators.CompareString(DC_Main.MsWorkType, "", false) == 0)
		{
			DC_Main.MsWorkType = "R";
		}
		DC_Main.MsMetalType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["METAL_TYPE"], (object)""));
		if (Operators.CompareString(DC_Main.MsMetalType, "", false) == 0)
		{
			DC_Main.MsMetalType = "G";
		}
		DC_Main.MCo_Path = new FileInfo(Application.ExecutablePath).DirectoryName;
		DC_Main.RsQry = "SELECT * FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY CO_YEAR DESC";
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			tYearCode.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
		}
		((Control)tlcCode).Focus();
	}

	private void ImgDataCreat()
	{
		string text = "NextImage";
		if (Operators.CompareString(DC_Main.LinkType, "W", false) == 0)
		{
			DC_Main.Img.ConnectionString = "Data Source=" + DC_Main.SqlServer + ";Initial Catalog=" + text + ";Integrated Security=True";
		}
		else
		{
			DC_Main.Img.ConnectionString = ("Data Source=" + DC_Main.SqlServer + ";Initial Catalog=" + text + ";Persist Security Info=True;User ID=" + DC_Main.SqlId + ";Password=" + DC_Main.SqlPwd) ?? "";
		}
	}

	private void tYearCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_3fdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c14: Invalid comparison between Unknown and I4
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
					if ((int)e.KeyCode != 13 || CurProcess)
					{
						goto end_IL_0001;
					}
					DC_Main.RsQry = "Select * From YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + tYearCode.Text + "' ";
					DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count == 0)
					{
						DC_Main.RsQry = "SELECT CO_YEAR As YearM,OP_DATE As OpeningDtM,CL_DATE as ClosingDtM FROM YEAR_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY OP_DATE desc";
						DC_Main.RsDg = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						DC_Main.YearHelp = false;
						DC_Main.ColWidth = new double[4];
						DC_Main.ColWidth[0] = 200.0;
						DC_Main.ColWidth[1] = 200.0;
						DC_Main.ColWidth[2] = 200.0;
						DC_Main.HelpSelect = 1;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						if (!DC_Main.HelpClose)
						{
							if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								tYearCode.Text = DC_Main.ColValue[0];
								DC_Main.FirstImageLode = true;
							}
							else
							{
								tYearCode.Text = "";
							}
							((Control)tYearCode).Focus();
							((TextBoxBase)tYearCode).SelectAll();
						}
						goto end_IL_0001;
					}
					DC_Main.DcDateFormat();
					DC_Main.MsOldMethod = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OLD_METHOD"], (object)""));
					tMonth.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["YEAR_MONTH"], (object)""));
					if (Operators.CompareString(DC_Main.MCo_Type, "", false) != 0)
					{
						DC_Main.MCo_year = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
						DC_Main.SqlData = Strings.Mid(DC_Main.SqlData, 1, 4) + Strings.Mid(DC_Main.MCo_year, 3, 2);
					}
					else if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)
					{
						if (Operators.CompareString(DC_Main.MsOldMethod, "Y", false) == 0)
						{
							DC_Main.MCo_year = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
							DC_Main.SqlData = "Next" + Strings.Mid(DC_Main.MCo_year, 3, 2);
						}
						else
						{
							((Control)tMonth).Visible = true;
							DC_Main.MCo_year = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;
							DC_Main.SqlData = "Next" + Strings.Mid(DC_Main.MCo_year, 3, 2) + tMonth.Text;
							Application.DoEvents();
						}
					}
					else if (Operators.CompareString(DC_Main.MsOldMethod, "N", false) == 0)
					{
						((Control)tMonth).Visible = true;
						DC_Main.MCo_year = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;
						DC_Main.SqlData = "Next" + Strings.Mid(DC_Main.MCo_year, 3, 2) + tMonth.Text;
						Application.DoEvents();
					}
					else
					{
						DC_Main.MCo_year = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
						DC_Main.SqlData = "Next" + Strings.Mid(DC_Main.MCo_year, 3, 2);
					}
					DC_Main.MMask = "__/__/____";
					DC_Main.MOp_dt = Conversions.ToDate(DC_Main.Rshlp.Rows[0]["OP_DATE"]);
					DC_Main.MCl_dt = Conversions.ToDate(DC_Main.Rshlp.Rows[0]["CL_DATE"]);
					DC_Main.MCo_OpDate = Strings.Format((object)DC_Main.MOp_dt, "dd/MM/yyyy");
					DC_Main.MCo_ClDate = Strings.Format((object)DC_Main.MCl_dt, "dd/MM/yyyy");
					DC_Main.MsYearChange = true;
					DC_Main.DataConYear();
					FildInsert();
					if (CurProcess)
					{
						goto end_IL_0001;
					}
					DC_Main.MsSoftType = "L";
					DC_Main.RsQry = "SELECT * FROM HDD_MAST WHERE REF_NO <> ''";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsSoftOpen = true;
					if (DC_Main.Rshlp.Rows.Count == 0)
					{
						((Control)MyProject.Forms.UT_HDD).Show();
						goto end_IL_0001;
					}
					DC_Main.SSRegSrNo = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["REF_NO"], (object)""));
					DC_Main.RsQry = "SELECT AC_GR FROM AC_MAST_SRNO WHERE CO_CODE = '01' AND LC_CODE = '00' AND AC_CODE = '00001' AND MAIN_USER = 'ABC'";
					DC_Main.Tbl = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
					checked
					{
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							DC_Main.MsAmcUnlockDay = (int)Math.Round(Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GR"], (object)"")));
						}
						else
						{
							DC_Main.MsAmcUnlockDay = 0;
						}
						CoRegNo();
						if ((Strings.Len(DC_Main.SSRegSrNo) == 1) & DC_Main.MembReg)
						{
							if ((Operators.CompareString(DC_Main.SSRegSrNo, "L", false) != 0) & (Operators.CompareString(DC_Main.SSRegSrNo, "B", false) != 0) & (Operators.CompareString(DC_Main.SSRegSrNo, "S", false) != 0) & (Operators.CompareString(DC_Main.SSRegSrNo, "U", false) != 0) & (Operators.CompareString(DC_Main.SSRegSrNo, "P", false) != 0) & (Operators.CompareString(DC_Main.SSRegSrNo, "A", false) != 0) & (Operators.CompareString(DC_Main.SSRegSrNo, "E", false) != 0))
							{
								DC_Main.MsSoftType = "L";
							}
							else
							{
								DC_Main.MsSoftType = DC_Main.SSRegSrNo;
							}
						}
						else if ((Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 7, 1), "L", false) == 0) | (Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 7, 1), "B", false) == 0) | (Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 7, 1), "S", false) == 0) | (Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 7, 1), "U", false) == 0) | (Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 7, 1), "P", false) == 0) | (Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 7, 1), "A", false) == 0) | (Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 7, 1), "E", false) == 0))
						{
							DC_Main.MsSoftType = Strings.Mid(DC_Main.SSRegSrNo, 7, 1);
						}
						else
						{
							DC_Main.MsSoftType = "L";
						}
						ImgDataCreat();
						DC_Main.OpenTable_ColMast();
						CurProcess = true;
						DC_Main.RsQry = "SELECT * From CO_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count >= 0)
						{
							DC_Main.MsMainBtn = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BTN_NAME"], (object)""));
							DC_Main.MsCoTheme = Conversions.ToInteger(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["THEME"], (object)""));
							DC_Main.MsCountryCode = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["COUNTRY_CODE"], (object)""));
							DC_Main.MsLbrType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							DC_Main.AcLcCodeLen = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_LC_CODE_LEN"], (object)""));
							DC_Main.MsLockDt = Conversions.ToDate(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LOCK_DATE"], (object)""));
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["TAX_ROF"]);
							double a = DC_Main.Fnv(ref Value);
							dataRow["TAX_ROF"] = RuntimeHelpers.GetObjectValue(Value);
							DC_Main.MsTaxRof = (int)Math.Round(a);
							DC_Main.MsRatePar = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_PAR"], (object)""));
							DC_Main.MsSlRowChange = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_ROW_CHANGE"], (object)""));
							DC_Main.MsVbImport = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VB_IMPORT"], (object)""));
							DC_Main.MsLbrGen = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_RATE_GEN"], (object)""));
							DC_Main.MsRateMastOpen = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_MAST_OPEN"], (object)""));
							DC_Main.MsFineStkType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FINE_STK_TYPE"], (object)""));
							DC_Main.MsTagRpt = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_RPT"], (object)""));
							DC_Main.MsDhrnIntType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DHRN_INT_TYPE"], (object)""));
							DC_Main.MsIntYearDays = Conversions.ToDouble(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["INT_YEAR_DAYS"], (object)""));
							DC_Main.MsOpDhiran = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OP_DHRN"], (object)""));
							DC_Main.MsIntDayCalc = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["INT_DAY"], (object)""));
							DC_Main.MsHelpSearch = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HELP_SERCH"], (object)""));
							DC_Main.MsWeightPort = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["WEIGHT_PORT"], (object)""));
							DC_Main.MsLdrSumm = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LDR_SUMM"], (object)""));
							DC_Main.MsSlAmtType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_AMT_TYPE"], (object)""));
							DC_Main.SmsLink = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SMS_LINK"], (object)""));
							DC_Main.MsOpLoan = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OP_LOAN"], (object)""));
							DC_Main.MsLoanIntType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LOAN_INT_TYPE"], (object)""));
							DC_Main.MsTradFine = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TRAD_FINE"], (object)""));
							DC_Main.MsLbrRof = Conversions.ToInteger(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_ROF"], (object)""));
							DC_Main.MsReminderOpen = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["REMINDER_OPEN"], (object)""));
							DC_Main.MsItmRateRof = Conversions.ToInteger(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_RATE_ROF"], (object)""));
							DC_Main.MsAdminSms = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ADMIN_SMS"], (object)""));
							DC_Main.MsCustSms = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CUST_SMS"], (object)""));
							DC_Main.MsPurcWithLbr = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PURC_WITH_LBR"], (object)""));
							DC_Main.MsDhrnCompound = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DHIRN_COMPOUND"], (object)""));
							DC_Main.MsGridScroll = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GRID_SCROLL"], (object)""));
							DC_Main.MsStkRptType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["STK_RPT_TYPE"], (object)""));
							DC_Main.MsTchAutoSave = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TOUCH_AUTO_SAVE"], (object)""));
							DC_Main.MsPanCardVal = Conversions.ToDouble(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PAN_CARD_VAL"], (object)""));
							DC_Main.MsDhrnPrc = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["DHRN_PRC"]), "0.00"));
							DC_Main.MsSlDupPrint = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DUP_PRINT"], (object)""));
							DC_Main.MsTaxCode = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
							DC_Main.MsIpWith = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IP_WITH_PC"], (object)""));
							DC_Main.MsCoStockMerge = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_STK_MERGE"], (object)""));
							DC_Main.MsPrAmtType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_AMT_TYPE"], (object)""));
							DC_Main.MsCardComAdj = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CARD_COM_ADJ"], (object)""));
							DC_Main.MsCashPurcAc = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CASH_PURC_AC"], (object)""));
							DC_Main.MsEmpCodeMendetry = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["EMP_CODE_MANDATORY"], (object)""));
							DC_Main.MsStockRptView = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["STOCK_RPT_TYPE"], (object)""));
							DC_Main.MsLastDayLock = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LAST_DAY_LOCK"], (object)""));
							DC_Main.MsCashLimit = Conversions.ToDouble(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CASH_LIMIT"], (object)""));
							DC_Main.MsDhrnWapp = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DHRN_WAPP"], (object)""));
							DC_Main.MsSchmWapp = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SCHM_WAPP"], (object)""));
							DC_Main.MsLedrBillColShow = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LEDR_BILL_COL"], (object)""));
							DC_Main.MsAllRofRemove = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ALL_ROF_REMOVE"], (object)""));
							DC_Main.MsSlPrOzConv = Conversions.ToDouble(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OZ_CON_VAL"], (object)""));
							DC_Main.MsFxRate = Conversions.ToDouble(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FX_RATE"], (object)""));
							DC_Main.MsFxCode = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FX_CODE"], (object)""));
							if (Operators.CompareString(DC_Main.MsMainBtn, "", false) == 0)
							{
								DC_Main.MsMainBtn = "Transaction";
							}
							if (DC_Main.MsCoTheme == 0)
							{
								DC_Main.MsCoTheme = 1;
							}
							if (Operators.CompareString(DC_Main.MsCountryCode, "", false) == 0)
							{
								DC_Main.MsCountryCode = "INR";
							}
							if (Operators.CompareString(DC_Main.MsLbrType, "", false) == 0)
							{
								DC_Main.MsLbrType = "G";
							}
							if (Operators.CompareString(DC_Main.AcLcCodeLen, "", false) == 0)
							{
								DC_Main.AcLcCodeLen = Conversions.ToString(1);
							}
							if (DC_Main.MsTaxRof > 5)
							{
								DC_Main.MsTaxRof = 2;
							}
							if (Operators.CompareString(DC_Main.MsRatePar, "", false) == 0)
							{
								DC_Main.MsRatePar = "G";
							}
							if (Operators.CompareString(DC_Main.MsSlRowChange, "", false) == 0)
							{
								DC_Main.MsSlRowChange = "N";
							}
							if (Operators.CompareString(DC_Main.MsVbImport, "", false) == 0)
							{
								DC_Main.MsVbImport = "N";
							}
							if (Operators.CompareString(DC_Main.MsLbrGen, "", false) == 0)
							{
								DC_Main.MsLbrGen = "N";
							}
							if (Operators.CompareString(DC_Main.MsRateMastOpen, "", false) == 0)
							{
								DC_Main.MsRateMastOpen = "Y";
							}
							if (Operators.CompareString(DC_Main.MsFineStkType, "", false) == 0)
							{
								DC_Main.MsFineStkType = "F";
							}
							if (Operators.CompareString(DC_Main.MsTagRpt, "", false) == 0)
							{
								DC_Main.MsTagRpt = "N";
							}
							if (Operators.CompareString(DC_Main.MsDhrnIntType, "", false) == 0)
							{
								DC_Main.MsDhrnIntType = "M";
							}
							if (DC_Main.MsIntYearDays == 0.0)
							{
								DC_Main.MsIntYearDays = 360.0;
							}
							if (Operators.CompareString(DC_Main.MsOpDhiran, "", false) == 0)
							{
								DC_Main.MsOpDhiran = "N";
							}
							if (Operators.CompareString(DC_Main.MsIntDayCalc, "", false) == 0)
							{
								DC_Main.MsIntDayCalc = "1";
							}
							if (Operators.CompareString(DC_Main.MsHelpSearch, "", false) == 0)
							{
								DC_Main.MsHelpSearch = "S";
							}
							if (Operators.CompareString(DC_Main.MsWeightPort, "", false) == 0)
							{
								DC_Main.MsWeightPort = "0";
							}
							if (Operators.CompareString(DC_Main.MsLdrSumm, "", false) == 0)
							{
								DC_Main.MsLdrSumm = "N";
							}
							if (Operators.CompareString(DC_Main.SmsLink, "", false) == 0)
							{
								DC_Main.SmsLink = "001";
							}
							if (Operators.CompareString(DC_Main.MsOpLoan, "", false) == 0)
							{
								DC_Main.MsOpLoan = "N";
							}
							if (Operators.CompareString(DC_Main.MsLoanIntType, "", false) == 0)
							{
								DC_Main.MsLoanIntType = "M";
							}
							if (Operators.CompareString(DC_Main.MsTradFine, "", false) == 0)
							{
								DC_Main.MsTradFine = "N";
							}
							if (DC_Main.MsLbrRof > 3)
							{
								DC_Main.MsLbrRof = 0;
							}
							if (Operators.CompareString(DC_Main.MsReminderOpen, "", false) == 0)
							{
								DC_Main.MsReminderOpen = "N";
							}
							if (DC_Main.MsItmRateRof > 3)
							{
								DC_Main.MsItmRateRof = 0;
							}
							if (Operators.CompareString(DC_Main.MsAdminSms, "", false) == 0)
							{
								DC_Main.MsAdminSms = "N";
							}
							if (Operators.CompareString(DC_Main.MsCustSms, "", false) == 0)
							{
								DC_Main.MsCustSms = "N";
							}
							if (Operators.CompareString(DC_Main.MsPurcWithLbr, "", false) == 0)
							{
								DC_Main.MsPurcWithLbr = "Y";
							}
							if (Operators.CompareString(DC_Main.MsDhrnCompound, "", false) == 0)
							{
								DC_Main.MsDhrnCompound = "Y";
							}
							if (Operators.CompareString(DC_Main.MsGridScroll, "", false) == 0)
							{
								DC_Main.MsGridScroll = "Y";
							}
							if (Operators.CompareString(DC_Main.MsStkRptType, "", false) == 0)
							{
								DC_Main.MsStkRptType = "N";
							}
							if (Operators.CompareString(DC_Main.MsTchAutoSave, "", false) == 0)
							{
								DC_Main.MsTchAutoSave = "N";
							}
							if (DC_Main.MsPanCardVal == 0.0)
							{
								DC_Main.MsPanCardVal = 200000.0;
							}
							if (DC_Main.MsDhrnPrc == 0.0)
							{
								DC_Main.MsDhrnPrc = 2.0;
							}
							if (Operators.CompareString(DC_Main.MsSlDupPrint, "", false) == 0)
							{
								DC_Main.MsSlDupPrint = "N";
							}
							if (Operators.CompareString(DC_Main.MsTaxCode, "", false) == 0)
							{
								DC_Main.MsTaxCode = "10";
							}
							if (Operators.CompareString(DC_Main.MsIpWith, "", false) == 0)
							{
								DC_Main.MsIpWith = "A";
							}
							if (Operators.CompareString(DC_Main.MsCoStockMerge, "", false) == 0)
							{
								DC_Main.MsCoStockMerge = "N";
							}
							if (Operators.CompareString(DC_Main.MsSlAmtType, "", false) == 0)
							{
								DC_Main.MsSlAmtType = "N";
							}
							if (Operators.CompareString(DC_Main.MsPrAmtType, "", false) == 0)
							{
								DC_Main.MsPrAmtType = "F";
							}
							if (Operators.CompareString(DC_Main.MsCardComAdj, "", false) == 0)
							{
								DC_Main.MsCardComAdj = "N";
							}
							if (Operators.CompareString(DC_Main.MsCashPurcAc, "", false) == 0)
							{
								DC_Main.MsCashPurcAc = "N";
							}
							if (Operators.CompareString(DC_Main.MsEmpCodeMendetry, "", false) == 0)
							{
								DC_Main.MsEmpCodeMendetry = "N";
							}
							if (Operators.CompareString(DC_Main.MsStockRptView, "", false) == 0)
							{
								DC_Main.MsStockRptView = "OLD";
							}
							if (Operators.CompareString(DC_Main.MsLastDayLock, "", false) == 0)
							{
								DC_Main.MsLastDayLock = "N";
							}
							if (DC_Main.MsCashLimit < 0.0)
							{
								DC_Main.MsCashLimit = 0.0;
							}
							if (Operators.CompareString(DC_Main.MsDhrnWapp, "", false) == 0)
							{
								DC_Main.MsDhrnWapp = "N";
							}
							if (Operators.CompareString(DC_Main.MsSchmWapp, "", false) == 0)
							{
								DC_Main.MsSchmWapp = "N";
							}
							if (Operators.CompareString(DC_Main.MsDefaulterAc, "", false) == 0)
							{
								DC_Main.MsSchmWapp = "N";
							}
							if (Operators.CompareString(DC_Main.MsLedrBillColShow, "", false) == 0)
							{
								DC_Main.MsLedrBillColShow = "N";
							}
							if (Operators.CompareString(DC_Main.MsAllRofRemove, "", false) == 0)
							{
								DC_Main.MsAllRofRemove = "N";
							}
							if (DC_Main.MsSlPrOzConv == 0.0)
							{
								DC_Main.MsSlPrOzConv = 31.1035;
							}
							if (DC_Main.MsFxRate == 0.0)
							{
								DC_Main.MsFxRate = 87.0;
							}
							if (Operators.CompareString(DC_Main.MsFxCode, "", false) == 0)
							{
								DC_Main.MsFxCode = "INR";
							}
						}
						DC_Main.MsFDiscDt = Conversions.ToDate(Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "dd/MM/yyyy"));
						DC_Main.MsTDiscDt = Conversions.ToDate(Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "dd/MM/yyyy"));
						DC_Main.RsQry = "SELECT * From CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count >= 0)
						{
							DC_Main.MsCntrStk = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["COUNTER_STK"], (object)""));
							DC_Main.MsEstmateBankLock = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ESTMATE_BANK_LOCK"], (object)""));
							DC_Main.MsOldPurcTchGen = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OLD_PURC_TOUCH"], (object)""));
							DC_Main.MsNegativeStkSale = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["NEGATIVE_STK_SALE"], (object)""));
							DC_Main.MsSlNwtLock = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_NWT_LOCK"], (object)""));
							DC_Main.MsWhBillImg = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["WH_BILL_IMG"], (object)""));
							DC_Main.MsBalanceSheetType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PROFIT_RPT_TYPE"], (object)""));
							DC_Main.MsQrCodeGen = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["QR_CODE_GEN"], (object)""));
							DC_Main.MsOsBillSms = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OS_BILL_SMS"], (object)""));
							DC_Main.MsSlBillImg = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_BILL_IMG"], (object)""));
							DC_Main.MsTotFineStkType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TOT_FINE_STK_TYPE"], (object)""));
							DC_Main.MsOpblTrfrBtn = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OPBL_TRFR_BTN"], (object)""));
							DC_Main.MsTagVchAutoSave = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_VCH_AUTO_SAVE"], (object)""));
							DC_Main.MsTagRowAutoPrint = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_AUTO_PRINT"], (object)""));
							DC_Main.MsDesignHelp = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_HELP"], (object)""));
							DC_Main.MsSalesWithHmTax = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SALES_WITH_HMTAX"], (object)""));
							DC_Main.MsTileMenuShow = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TILE_MENU"], (object)""));
							DC_Main.MsPrRateRof = Conversions.ToInteger(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_RATE_ROF"], (object)""));
							DC_Main.MsLenImgPath = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LEN_IMG_PATH"], (object)""));
							DC_Main.MsSlTdsTax = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_TDS_TAX"], (object)""));
							DC_Main.MsPrTdsTax = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_TDS_TAX"], (object)""));
							DC_Main.MsFineInt = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OS_FINE_INT"], (object)""));
							DC_Main.MsPurcWithHmTax = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PURC_WITH_HMTAX"], (object)""));
							DC_Main.MsSlAndTagWtDiff = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_TAG_WT_DIFF"], (object)""));
							DC_Main.MsCountryId = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["COUNTRY_ID"], (object)""));
							DC_Main.MsWappSlPrint = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["WAPP_SL_PRINT"], (object)""));
							DC_Main.MsBillProfit = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BILL_PROFIT"], (object)""));
							DC_Main.MsOldGoldType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OLD_GOLD_TYPE"], (object)""));
							DC_Main.MsDesignMastHelp = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_ENTRY_DESIGN_GEN"], (object)""));
							DC_Main.MsOrdImgPrint = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_IMG_PRINT"], (object)""));
							DC_Main.MsOsBillOrnaIsu = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OS_BILL_ORNA_ISU"], (object)""));
							DC_Main.MsPurcLot = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PURC_LOT"], (object)""));
							DC_Main.MsMobileHelp = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MOBILE_HELP"], (object)""));
							DC_Main.MsPrintFormBtn = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PRINT_FORM_BTN"], (object)""));
							DC_Main.MsFontChange = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FONT_CHANGE"], (object)""));
							DC_Main.MsFontSize = Conversions.ToSingle(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FONT_SIZE"], (object)""));
							DC_Main.MsFontName = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FONT_NAME"], (object)""));
							DC_Main.MsFontStyle = (FontStyle)Conversions.ToInteger(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FONT_STYLE_TYPE"], (object)""));
							DC_Main.MsGridRowHeight = Conversions.ToInteger(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GRID_ROW_HIGHT"], (object)""));
							DC_Main.MsTotAmtRof = Conversions.ToInteger(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TOT_AMT_ROF"], (object)""));
							DC_Main.MsTaxWithEstmate = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ESTMATE_TAX"], (object)""));
							DC_Main.MsRptTotShow = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RPT_TOT_SHOW"], (object)""));
							DC_Main.MsDefaultReminder = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DEFAULT_REMINDER"], (object)""));
							DC_Main.MsVchDescHelpLenth = Conversions.ToInteger(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_DESC_HELP_LENT"], (object)""));
							DC_Main.MsOrdTagLessInStk = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_TAG_STK_LESS"], (object)""));
							DC_Main.MsAllBranchAcShow = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BRANCH_ALL_AC_SHOW"], (object)""));
							DC_Main.MsMrpTaxReverc = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SL_MRP_TAX_REVERC"], (object)""));
							DC_Main.MsEmpAsUser = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["EMP_AS_USER"], (object)""));
							DC_Main.MsWappImgGwt = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["WAPP_IMG_GWT"], (object)""));
							DC_Main.MsYearGoldSl = Conversions.ToDouble(Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["YEAR_GOLD_SL"], (object)"")), "0.000"));
							DC_Main.MsYearSilverSl = Conversions.ToDouble(Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["YEAR_SILVER_SL"], (object)"")), "0.000"));
							DC_Main.MsFDiscDt = Conversions.ToDate(DC_Main.Rshlp.Rows[0]["F_DISC_DATE"]);
							DC_Main.MsTDiscDt = Conversions.ToDate(DC_Main.Rshlp.Rows[0]["T_DISC_DATE"]);
							DC_Main.MsDhrnImgPrint = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DHRN_IMG_PRINT"], (object)""));
							DC_Main.MsLbrWithGht = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_WITH_GHT"], (object)""));
							DC_Main.MsAprImgPrint = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["APR_IMG_PRINT"], (object)""));
							DC_Main.MsOthItmWtRemove = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OTH_ITM_WT_REMOVE"], (object)""));
							DC_Main.MsSilverWt3Digit = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SILVER_THREE_DIGIT"], (object)""));
							DC_Main.MsKrDesignImgPrint = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_DESIGN_IMG_PRINT"], (object)""));
							DC_Main.MsItmWitLotStk = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_WITH_LOT_STK"], (object)""));
							DC_Main.MsUserKrTouchHide = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["USER_KR_TOUCH_HIDE"], (object)""));
							DC_Main.MsCurDayPosting = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CUR_DAY_POSTING"], (object)""));
							DC_Main.MsMainFontChange = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_FONT_CHANGE"], (object)""));
							DC_Main.MsStkLimitWithDesign = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["STK_LMIT_WITH_DESIGN"], (object)""));
							DC_Main.MsItmFineLock = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_FINE_LOCK"], (object)""));
							DC_Main.MsPrintZoom = Conversions.ToInteger(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PRINT_ZOOM"], (object)""));
							DC_Main.MsCrystalRptType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CRYSTAL_RPT"], (object)""));
							DC_Main.MsWappApiKey = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["WAPP_API"], (object)""));
							DC_Main.MsWappApiMobile = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["WAPP_API_MOBILE"], (object)""));
							DC_Main.MsWappApiId = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["WAPP_API_ID"], (object)""));
							Module_Save.MsRendomTag = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RENDOM_TAG"], (object)""));
							Module_Save.MsRendomWithPrCode = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RENDOM_WITH_PRCODE"], (object)""));
							if (Operators.CompareString(DC_Main.MsCntrStk, "", false) == 0)
							{
								DC_Main.MsCntrStk = "N";
							}
							if (Operators.CompareString(DC_Main.MsEstmateBankLock, "", false) == 0)
							{
								DC_Main.MsEstmateBankLock = "N";
							}
							if (Operators.CompareString(DC_Main.MsOldPurcTchGen, "", false) == 0)
							{
								DC_Main.MsOldPurcTchGen = "N";
							}
							if (Operators.CompareString(DC_Main.MsNegativeStkSale, "", false) == 0)
							{
								DC_Main.MsNegativeStkSale = "Y";
							}
							if (Operators.CompareString(DC_Main.MsSlNwtLock, "", false) == 0)
							{
								DC_Main.MsSlNwtLock = "N";
							}
							if (Operators.CompareString(DC_Main.MsWhBillImg, "", false) == 0)
							{
								DC_Main.MsWhBillImg = "N";
							}
							if (Operators.CompareString(DC_Main.MsBalanceSheetType, "", false) == 0)
							{
								DC_Main.MsBalanceSheetType = "F";
							}
							if (Operators.CompareString(DC_Main.MsQrCodeGen, "", false) == 0)
							{
								DC_Main.MsQrCodeGen = "N";
							}
							if (Operators.CompareString(DC_Main.MsOsBillSms, "", false) == 0)
							{
								DC_Main.MsOsBillSms = "N";
							}
							if (Operators.CompareString(DC_Main.MsSlBillImg, "", false) == 0)
							{
								DC_Main.MsSlBillImg = "N";
							}
							if (Operators.CompareString(DC_Main.MsTotFineStkType, "", false) == 0)
							{
								DC_Main.MsTotFineStkType = "I";
							}
							if (Operators.CompareString(DC_Main.MsOpblTrfrBtn, "", false) == 0)
							{
								DC_Main.MsOpblTrfrBtn = "N";
							}
							if (Operators.CompareString(DC_Main.MsTagVchAutoSave, "", false) == 0)
							{
								DC_Main.MsTagVchAutoSave = "N";
							}
							if (Operators.CompareString(DC_Main.MsTagRowAutoPrint, "", false) == 0)
							{
								DC_Main.MsTagRowAutoPrint = "N";
							}
							if (Operators.CompareString(DC_Main.MsDesignHelp, "", false) == 0)
							{
								DC_Main.MsDesignHelp = "N";
							}
							if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "", false) == 0)
							{
								DC_Main.MsSalesWithHmTax = "N";
							}
							if (Operators.CompareString(DC_Main.MsTileMenuShow, "", false) == 0)
							{
								DC_Main.MsTileMenuShow = "L";
							}
							if (DC_Main.MsPrRateRof > 3)
							{
								DC_Main.MsPrRateRof = 3;
							}
							if (Operators.CompareString(Strings.Mid(DC_Main.MsLenImgPath, 1, 2), "\\\\", false) != 0)
							{
								DC_Main.MsLenImgPath = "";
							}
							if (Operators.CompareString(DC_Main.MsSlTdsTax, "", false) == 0)
							{
								DC_Main.MsPrTdsTax = "N";
							}
							if (Operators.CompareString(DC_Main.MsPrTdsTax, "", false) == 0)
							{
								DC_Main.MsPrTdsTax = "N";
							}
							if (Operators.CompareString(DC_Main.MsFineInt, "", false) == 0)
							{
								DC_Main.MsFineInt = "N";
							}
							if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "", false) == 0)
							{
								DC_Main.MsPurcWithHmTax = "N";
							}
							if (Operators.CompareString(DC_Main.MsSlAndTagWtDiff, "", false) == 0)
							{
								DC_Main.MsSlAndTagWtDiff = "N";
							}
							if (Operators.CompareString(DC_Main.MsCountryId, "", false) == 0)
							{
								DC_Main.MsCountryId = "91";
							}
							if (Operators.CompareString(DC_Main.MsWappSlPrint, "", false) == 0)
							{
								DC_Main.MsWappSlPrint = "N";
							}
							if (Operators.CompareString(DC_Main.MsBillProfit, "", false) == 0)
							{
								DC_Main.MsBillProfit = "N";
							}
							if (Operators.CompareString(DC_Main.MsOldGoldType, "", false) == 0)
							{
								DC_Main.MsOldGoldType = "N";
							}
							if (Operators.CompareString(DC_Main.MsDesignMastHelp, "", false) == 0)
							{
								DC_Main.MsDesignMastHelp = "N";
							}
							if (Operators.CompareString(DC_Main.MsOrdImgPrint, "", false) == 0)
							{
								DC_Main.MsOrdImgPrint = "N";
							}
							if (Operators.CompareString(DC_Main.MsOsBillOrnaIsu, "", false) == 0)
							{
								DC_Main.MsOsBillOrnaIsu = "Y";
							}
							if (Operators.CompareString(DC_Main.MsPurcLot, "", false) == 0)
							{
								DC_Main.MsPurcLot = "N";
							}
							if (Operators.CompareString(DC_Main.MsMobileHelp, "", false) == 0)
							{
								DC_Main.MsMobileHelp = "N";
							}
							if (Operators.CompareString(DC_Main.MsPrintFormBtn, "", false) == 0)
							{
								DC_Main.MsPrintFormBtn = "E";
							}
							if (Operators.CompareString(DC_Main.MsFontChange, "", false) == 0)
							{
								DC_Main.MsFontChange = "N";
							}
							if (DC_Main.MsFontSize == 0f)
							{
								DC_Main.MsFontSize = 11f;
							}
							if (Operators.CompareString(DC_Main.MsFontName, "", false) == 0)
							{
								DC_Main.MsPrintFormBtn = "Calibri";
							}
							if (unchecked((int)DC_Main.MsFontStyle) >= 5)
							{
								DC_Main.MsPrintFormBtn = Conversions.ToString(0);
							}
							if (DC_Main.MsGridRowHeight < 20)
							{
								DC_Main.MsPrintFormBtn = Conversions.ToString(20);
							}
							if (DC_Main.MsTotAmtRof >= 4)
							{
								DC_Main.MsTotAmtRof = 0;
							}
							if (Operators.CompareString(DC_Main.MsTaxWithEstmate, "", false) == 0)
							{
								DC_Main.MsTaxWithEstmate = "N";
							}
							if (Operators.CompareString(DC_Main.MsRptTotShow, "", false) == 0)
							{
								DC_Main.MsRptTotShow = "N";
							}
							if (Operators.CompareString(DC_Main.MsDefaultReminder, "", false) == 0)
							{
								DC_Main.MsDefaultReminder = "R";
							}
							if (DC_Main.MsVchDescHelpLenth == 0)
							{
								DC_Main.MsVchDescHelpLenth = 25;
							}
							if (Operators.CompareString(DC_Main.MsOrdTagLessInStk, "Y", false) != 0)
							{
								DC_Main.MsOrdTagLessInStk = "N";
							}
							if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) != 0)
							{
								DC_Main.MsAllBranchAcShow = "N";
							}
							if (Operators.CompareString(DC_Main.MsMrpTaxReverc, "", false) == 0)
							{
								DC_Main.MsMrpTaxReverc = "N";
							}
							if (Operators.CompareString(DC_Main.MsEmpAsUser, "", false) == 0)
							{
								DC_Main.MsEmpAsUser = "N";
							}
							if (Operators.CompareString(DC_Main.MsWappImgGwt, "", false) == 0)
							{
								DC_Main.MsWappImgGwt = "Y";
							}
							if (Operators.CompareString(DC_Main.MsDhrnImgPrint, "", false) == 0)
							{
								DC_Main.MsDhrnImgPrint = "N";
							}
							if (Operators.CompareString(DC_Main.MsLbrWithGht, "", false) == 0)
							{
								DC_Main.MsLbrWithGht = "Y";
							}
							if (Operators.CompareString(DC_Main.MsAprImgPrint, "", false) == 0)
							{
								DC_Main.MsAprImgPrint = "N";
							}
							if (Operators.CompareString(DC_Main.MsOthItmWtRemove, "", false) == 0)
							{
								DC_Main.MsOthItmWtRemove = "N";
							}
							if (Operators.CompareString(DC_Main.MsSilverWt3Digit, "", false) == 0)
							{
								DC_Main.MsSilverWt3Digit = "N";
							}
							if (Operators.CompareString(DC_Main.MsKrDesignImgPrint, "", false) == 0)
							{
								DC_Main.MsKrDesignImgPrint = "N";
							}
							if (Operators.CompareString(DC_Main.MsItmWitLotStk, "", false) == 0)
							{
								DC_Main.MsItmWitLotStk = "N";
							}
							if (Operators.CompareString(DC_Main.MsUserKrTouchHide, "", false) == 0)
							{
								DC_Main.MsUserKrTouchHide = "N";
							}
							if (Operators.CompareString(DC_Main.MsCurDayPosting, "", false) == 0)
							{
								DC_Main.MsCurDayPosting = "N";
							}
							if (Operators.CompareString(DC_Main.MsMainFontChange, "", false) == 0)
							{
								DC_Main.MsMainFontChange = "N";
							}
							if (Operators.CompareString(DC_Main.MsStkLimitWithDesign, "", false) == 0)
							{
								DC_Main.MsStkLimitWithDesign = "N";
							}
							if (Operators.CompareString(DC_Main.MsItmFineLock, "", false) == 0)
							{
								DC_Main.MsItmFineLock = "N";
							}
							if (DC_Main.MsPrintZoom < 100)
							{
								DC_Main.MsPrintZoom = 110;
							}
							if (Operators.CompareString(DC_Main.MsCrystalRptType, "", false) == 0)
							{
								DC_Main.MsCrystalRptType = "O";
							}
							if (Operators.CompareString(DC_Main.MsWappApiKey, "", false) == 0)
							{
								DC_Main.MsWappApiKey = "";
							}
							if (Operators.CompareString(DC_Main.MsWappApiMobile, "", false) == 0)
							{
								DC_Main.MsWappApiMobile = "";
							}
							if (Operators.CompareString(DC_Main.MsWappApiId, "", false) == 0)
							{
								DC_Main.MsWappApiId = "";
							}
							if (Operators.CompareString(Module_Save.MsRendomTag, "", false) == 0)
							{
								Module_Save.MsRendomTag = "N";
							}
							if (Operators.CompareString(Module_Save.MsRendomWithPrCode, "", false) == 0)
							{
								Module_Save.MsRendomWithPrCode = "Y";
							}
						}
						if (Operators.CompareString(DC_Main.MsAllRofRemove, "Y", false) == 0)
						{
							DC_Main.MsItmRateRof = 2;
							DC_Main.MsLbrRof = 2;
							DC_Main.MsItmRateRof = 2;
							DC_Main.MsTotAmtRof = 2;
							DC_Main.MsTaxRof = 2;
						}
						if (Operators.CompareString(Strings.Mid(((ApplicationBase)MyProject.Application).Info.DirectoryPath, 1, 2), "\\\\", false) == 0 && Operators.CompareString(DC_Main.MsLenImgPath, "", false) != 0)
						{
							DC_Main.MSImageSavePath = DC_Main.MsLenImgPath;
						}
						if ((Operators.CompareString(DC_Main.MsLenImgPath, "", false) != 0) & (Operators.CompareString(DC_Main.SSRegSrNo, "VK165NEVK", false) == 0))
						{
							DC_Main.MSImageSavePath = DC_Main.MsLenImgPath;
						}
						if ((Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_code, "01", false) != 0))
						{
							Ac_Image.All_Co_ItmMast_Same();
						}
						if (Operators.CompareString(DC_Main.SSRegSrNo, "HM103NSKU", false) == 0)
						{
							DC_Main.MCo_Type = "T";
						}
						SMS_PACK();
						Estmate_Reset();
						BulPorcess();
						Ac_Image.WappReg();
						MfgType();
						CrmProcess();
						BDataReset();
						MailSendOpen();
						AppSchm();
						NextAi();
						WappApi();
						RendomTagSet();
						OlocarActive();
						FanSaleOpen();
						LastYearTagSiresCantinu();
						SoftHang();
						if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
						{
							DC_Main.RsQry = "SELECT POINT_CODE,POINT_AMT FROM POINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CUR_IN_USE = 'Y' ORDER BY POINT_CODE";
							DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable.Rows.Count > 0)
							{
								DC_Main.MsPointCode = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["POINT_CODE"], (object)""));
								DC_Main.MsOnePointVal = Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["POINT_AMT"], (object)""));
							}
						}
						if ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK017NASD", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM048NSKU", false) == 0))
						{
							DC_Main.MsUserNotShowGr = "";
							DC_Main.RsQry = "SELECT AC_GR FROM AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND USER_SHOW_GROUP = 'N' ORDER BY AC_GR";
							DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.M = 0;
							while (DC_Main.M < dataTable2.Rows.Count)
							{
								DC_Main.MsUserNotShowGr = Conversions.ToString(Operators.AddObject((object)DC_Main.MsUserNotShowGr, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"'", dataTable2.Rows[DC_Main.M]["AC_GR"]), (object)"'"), (object)",")));
								DC_Main.M++;
							}
							if (Strings.Len(DC_Main.MsUserNotShowGr) > 0)
							{
								DC_Main.MsUserNotShowGr = Strings.Mid(DC_Main.MsUserNotShowGr, 1, Strings.Len(DC_Main.MsUserNotShowGr) - 1);
							}
							dataTable2.Rows.Clear();
							dataTable2.Columns.Clear();
							DC_Main.M = 0;
						}
						DC_Main.MsSysDate = Conversions.ToDate(Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy"));
						if (Operators.CompareString(DC_Main.MsRateMastOpen, "Y", false) == 0)
						{
							DC_Main.RsQry = "Select CO_CODE,LC_CODE,VCH_DATE,SR_NO,GR_CODE,GR_RATE,GR_TOUCH,GR_TAX_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "'";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count > 0)
							{
								DC_Main.RtView = new DataView(DC_Main.Rshlp);
							}
							else
							{
								DC_Main.MsDailyRateGen = true;
							}
						}
						else
						{
							DC_Main.RsQry = "SELECT CO_CODE,LC_CODE,VCH_DATE,SR_NO,GR_CODE,GR_RATE,GR_TOUCH,GR_TAX_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "'";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count > 0)
							{
								DC_Main.RtView = new DataView(DC_Main.Rshlp);
							}
						}
						if (Conversions.ToDouble(DC_Main.AcLcCodeLen) == 1.0)
						{
							if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
							{
								DC_Main.RsQry = "SELECT TOP 2 AC_CODE,AC_NAME,AC_GR FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(AC_CODE) = 6 AND CAST(AC_CODE AS INT) > 99  ORDER BY AC_CODE DESC";
							}
							else
							{
								DC_Main.RsQry = "SELECT TOP 2 AC_CODE,AC_NAME,AC_GR FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(AC_CODE AS INT) > 99  ORDER BY AC_CODE DESC";
							}
						}
						else
						{
							DC_Main.RsQry = "SELECT TOP 2 AC_CODE,AC_NAME,AC_GR FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(AC_CODE AS INT) > 99  ORDER BY AC_CODE DESC";
						}
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT AC_CODE,AC_NAME,AC_GR FROM AC_MAST_SRNO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '"), DC_Main.Rshlp.Rows[0]["AC_CODE"]), (object)"'"));
							DataTable dataTable3 = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
							if (dataTable3.Rows.Count == 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO AC_MAST_SRNO(CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_GR) VALUES  ('" + DC_Main.MCo_code + "','"), DC_Main.Rshlp.Rows[0]["AC_CODE"]), (object)"', '"), (object)DC_Main.MLc_code), (object)"','"), DC_Main.Rshlp.Rows[0]["AC_NAME"]), (object)"','"), (object)Strings.Mid(Conversions.ToString(DC_Main.Rshlp.Rows[0]["AC_GR"]), 1, 2)), (object)"') "));
								DC_Main.OpenRecordSetMc(DC_Main.RsQry);
							}
						}
						if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
						{
							DC_Main.RsQry = "SELECT LC_CODE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count > 1)
							{
								if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)
								{
									DC_Main.MsLcBoxShow = true;
								}
								else
								{
									DC_Main.MsLcBoxShow = false;
								}
							}
						}
						DC_Main.RsQry = "SELECT ITEM_DISCOUNT FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count > 0 && Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITEM_DISCOUNT"], (object)""), (object)"N", false))
						{
							DC_Main.MsFDiscDt = Conversions.ToDate(Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "dd/MM/yyyy"));
							DC_Main.MsTDiscDt = Conversions.ToDate(Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "dd/MM/yyyy"));
						}
						if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
						{
							DC_Main.RsQry = "SELECT EMP_CODE,EMP_NAME FROM EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND USER_NAME = '" + DC_Main.MCo_User + "'";
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count > 0)
							{
								DC_Main.MsUserEmpCode = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["EMP_CODE"], (object)""));
								DC_Main.MsUserEmpName = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["EMP_NAME"], (object)""));
							}
						}
						DC_Main.RsQry = "SELECT HTTP_NAME,URL_NAME,URL_ID,URL_PWD FROM CO_MAST WHERE CO_CODE = '01'";
						DC_Main.Tbl = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							DC_Main.MsHttpPath = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["HTTP_NAME"], (object)""));
							DC_Main.MsUrlPath = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["URL_NAME"], (object)""));
							DC_Main.MsUrlId = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["URL_ID"], (object)""));
							DC_Main.MsUrlPwd = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["URL_PWD"], (object)""));
						}
						((Form)this).Close();
						CurProcess = false;
						DC_Main.MsDataType = "C";
						if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
						{
							DC_Main.MsDataType = "A";
						}
						switch (DC_Main.SSRegSrNo)
						{
						case "HM283NEKU":
						case "HM287NEKU":
						case "HM310NEPK":
						case "HM307NEKU":
						case "HM340NEKU":
						case "VK142NEVK":
						case "HM382NEKU":
						case "HM190NEKU":
						case "DM119NEDG":
							DC_Main.MsDataType = "C";
							break;
						}
						switch (DC_Main.SSRegSrNo)
						{
						case "HM047NEPK":
						case "VS137NEBU":
						case "HM037NEKU":
						case "KJ014NPKJ":
						case "HM244NEKU":
						case "HM283NEKU":
						case "HM240NPPK":
						case "HM425NEKU":
						case "HM303NEKU":
						case "VS059NEBU":
						case "HM169NSKU":
						case "KJ001NEKJ":
						case "VS287NEBU":
							if (Operators.CompareString(DC_Main.MCo_User, "ABC", false) == 0 && !DC_Main.MembReg && DC_Main.MsSSPwd)
							{
								Interaction.MsgBox((object)"User Id And Password Is Not valid...", (MsgBoxStyle)0, (object)null);
								Application.Exit();
							}
							break;
						}
						DC_Main.RsQry = "SELECT TOP 1 TAG_NO FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
						DC_Main.ExeQuteImg(DC_Main.RsQry);
						DC_Main.MsImgDataOpen = true;
						if (Operators.CompareString(DC_Main.MsLastDayLock, "Y", false) == 0)
						{
							DC_Main.ExeQuteDc("UPDATE CO_SET SET LOCK_DATE = '" + Strings.Format((object)DC_Main.MsSysDate.AddDays(-1.0), "MM/dd/yyyy") + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
							DC_Main.MsLockDt = Conversions.ToDate(Strings.Format((object)DC_Main.MsSysDate.AddDays(-1.0), "dd/MM/yyyy"));
						}
						DC_Main.RsQry = "SELECT TOP 1 KR_RATE_TYPE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						((Control)MyProject.Forms.MDI_FORM).Show();
						if (DC_Main.BDataRest)
						{
							Slreset();
						}
						goto end_IL_0001;
					}
				case 16365:
					num = -1;
					switch (num2)
					{
					case 2:
						Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
						Ac_Image.CoFieldAdd();
						goto end_IL_0001;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 16365;
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

	private void MembRegEntry()
	{
		if (Operators.CompareString(DC_Main.SSCompSrNo2, "98FE2B0F", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/FQKV5G3/CNCMK0018H02E0/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3QSKYY2/CNCMK009AK0067/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/8P65M33/CNCMK0006B080C/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/BYMX9H2/CNCMK0073T0319/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/8FLJ9H2/CN1296377M1582/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "AC1KS96D008FZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "AL2HF77C04D5Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A1ZSUH4AJ32ZZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/B2SVN12/CN129634BD00C5/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/1MJJJC2/              /Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APF0TNUFNZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/8YNXFH2/CN1296379H002B/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "AC02445205KMG3N3ASZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "AWB03150481Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APF10FEQ3Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/8JC4H72/CN1296361C0176/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "ABase Board Serial NumberZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "ANXMPKSI005448029263400Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APF01E167Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "ACB24136211Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "AL2HF77C04D5Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7H1GQ72/CN1296364H0056/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/8PQ3CT1/CN7590026800MI/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/CHRNTN2/CNCMK0085M130F/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "AL1HF98T002SZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APF0UJ03SZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "AL1HF84300PGZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APJLTU018JD63D1Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APCSCN012C1U5XCZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/H04GN12/CN129634B40014/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APKPSF00WBFF05EZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/GJNYZ72/CN12963597GFNF/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/G22J562/CN129635B2020B/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APFUFP018J930SIZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/53Y0V32/CN1296357900EC/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/4TN1W32/CN1296357N02D6/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "AW1KS84N13BGZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3PRJW33/CNCMK000631598/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "AL2HF82T00P9Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "AC1KS83M0089Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "AL2HF81H00S6Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APF11XJ1JZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/BRRSK63/CNCMK0009E04F1/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3TTBS73/CNCMK000BJ0FA8/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "AL1HF98E047JZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APF0IFVNUZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/DKFVZQ2/TW32070996008A/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APFKCT00WB182FLZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/F905VG3/CNWSC001BO1B09/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APF252TDWZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APLKSR00WBFQ1KAZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/86DY5Y2/CNCMK0098E00FF/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK038JGR3N9Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APGNUUJ6MYA8OIZZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APKXMAB51VGRE24Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "AL833NRCX0062WRMBZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/9WY31N2/CN1296383F013B/Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "APGSLU00WBBC7NAZ", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A2958-9191-4960-8620-7782-1363-73Z", false) == 0)
		{
			DC_Main.MembReg = true;
		}
		else if (Operators.CompareString(DC_Main.SSCompSrNo2, "D4371B0B", false) == 0)
		{
			DC_Main.MembReg = true;
		}
	}

	private void tYearCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void CoRegNo()
	{
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0669: Unknown result type (might be due to invalid IL or missing references)
		//IL_0704: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0862: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c78: Unknown result type (might be due to invalid IL or missing references)
		MembRegEntry();
		SoftNoneUse();
		if (MsWhoutAmc)
		{
			return;
		}
		switch (Strings.Mid(DC_Main.SSRegSrNo, 1, 2))
		{
		case "AB":
			Self();
			break;
		case "KJ":
			Kishor();
			break;
		case "HM":
			Hemal();
			break;
		case "VS":
			Vishal();
			break;
		case "VK":
			Vikas();
			break;
		case "DH":
			Dhrupal();
			break;
		case "DD":
			Dipak();
			break;
		case "AK":
			Ajay();
			break;
		case "DM":
		case "KS":
			Devendra();
			break;
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK052NEVK", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo2, "48659CF4", false) == 0))
		{
			MsRegSoft = true;
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo2, "74E307FC", false) == 0))
		{
			MsRegSoft = true;
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo2, "F835E01D", false) == 0))
		{
			MsRegSoft = true;
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK188NESD", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo2, "BC59D433", false) == 0))
		{
			MsRegSoft = true;
		}
		if (Operators.CompareString(DC_Main.SSCompSrNo1, "", false) == 0)
		{
			DC_Main.MsSoftNoUse = "N";
		}
		if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7GRH8M2/CNFCW007AU02CH/Z", false) == 0)
		{
			DC_Main.AmcEndDate = Conversions.ToDate("30/06/2025").AddDays(700.0);
			if (DateTime.Compare(DateAndTime.Now, DC_Main.AmcEndDate) > 0)
			{
				Interaction.MsgBox((object)("Your Licence Period is Over End Date = " + Conversions.ToString(DC_Main.AmcEndDate) + "...."), (MsgBoxStyle)0, (object)null);
				Application.Exit();
			}
			DC_Main.MembReg = true;
			return;
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "AB000NEAB", false) == 0) & DC_Main.MembReg)
		{
			DC_Main.AmcEndDate = Conversions.ToDate("27/07/2025").AddDays(1000.0);
			if (DateTime.Compare(DateAndTime.Now, DC_Main.AmcEndDate) > 0)
			{
				Interaction.MsgBox((object)("Your Licence Period is Over End Date = " + Conversions.ToString(DC_Main.AmcEndDate) + "...."), (MsgBoxStyle)0, (object)null);
				Application.Exit();
			}
			return;
		}
		if (((Operators.CompareString(DC_Main.SSRegSrNo, "HM244NEKU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM283NEKU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM391NEKU", false) == 0)) && Operators.CompareString(DC_Main.SSCompSrNo1, "APPWSH028JIW2GLZ", false) == 0)
		{
			MsRegSoft = true;
		}
		if (((Operators.CompareString(DC_Main.SSRegSrNo, "DM127NUDM", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "DM128NUDM", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "DM129NUDM", false) == 0)) && Operators.CompareString(DC_Main.SSCompSrNo1, "APREZF0F8JLS0CCZ", false) == 0)
		{
			MsRegSoft = true;
		}
		if (((Operators.CompareString(DC_Main.SSRegSrNo, "VS055NEVS", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VS182NEBU", false) == 0)) && Operators.CompareString(DC_Main.SSCompSrNo1, "APHWJL00WBCS3RNZ", false) == 0)
		{
			MsRegSoft = true;
		}
		if (((Operators.CompareString(DC_Main.SSRegSrNo, "VK061NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK103NEVK", false) == 0)) && Operators.CompareString(DC_Main.SSCompSrNo2, "F835E01D", false) == 0)
		{
			MsRegSoft = true;
		}
		if (Operators.CompareString(DC_Main.SSCompSrNo1, "ANBK9P1100G325000AD2NEDZ", false) == 0)
		{
			DC_Main.AmcEndDate = Conversions.ToDate("06/09/2025").AddDays(7.0);
			if (DateTime.Compare(DateAndTime.Now, DC_Main.AmcEndDate) > 0)
			{
				Interaction.MsgBox((object)("Your Licence Period is Over End Date = " + Conversions.ToString(DC_Main.AmcEndDate) + "...."), (MsgBoxStyle)0, (object)null);
				Application.Exit();
			}
			DC_Main.MembReg = true;
			return;
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM047NEPK", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo1, "ACB23385115Z", false) == 0))
		{
			DC_Main.AmcEndDate = Conversions.ToDate("23/10/2024").AddDays(10.0);
			if (DateTime.Compare(DateAndTime.Now, DC_Main.AmcEndDate) > 0)
			{
				Interaction.MsgBox((object)("Your Licence Period is Over End Date = " + Conversions.ToString(DC_Main.AmcEndDate) + "...."), (MsgBoxStyle)0, (object)null);
				Application.Exit();
			}
			DC_Main.MembReg = true;
			return;
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "DM049NSDM", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))
		{
			DC_Main.AmcEndDate = Conversions.ToDate("17/12/2025").AddDays(6.0);
			if (DateTime.Compare(DateAndTime.Now, DC_Main.AmcEndDate) > 0)
			{
				Interaction.MsgBox((object)("Your Freee Pc Licence Period is Over End Date = " + Conversions.ToString(DC_Main.AmcEndDate) + "...."), (MsgBoxStyle)0, (object)null);
				Application.Exit();
			}
			DC_Main.MembReg = true;
			return;
		}
		if (((Operators.CompareString(DC_Main.SSRegSrNo, "HM729NAKU", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo1, "ABTWW408003QSZ", false) == 0)) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/42WJQM3/CNCMC00225026F/Z", false) == 0))
		{
			DC_Main.AmcEndDate = Conversions.ToDate("19/02/2026").AddDays(30.0);
			if (DateTime.Compare(DateAndTime.Now, DC_Main.AmcEndDate) > 0)
			{
				Interaction.MsgBox((object)("Your Freee Pc Licence Period is Over End Date = " + Conversions.ToString(DC_Main.AmcEndDate) + "...."), (MsgBoxStyle)0, (object)null);
				Application.Exit();
			}
			DC_Main.MembReg = true;
			return;
		}
		if (((Operators.CompareString(DC_Main.SSRegSrNo, "VS188NEBU", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo2, "6E3D493B", false) == 0)) | (Operators.CompareString(DC_Main.SSCompSrNo2, "5ACB5D31", false) == 0))
		{
			DC_Main.AmcEndDate = Conversions.ToDate("14/05/2026").AddDays(30.0);
			if (DateTime.Compare(DateAndTime.Now, DC_Main.AmcEndDate) > 0)
			{
				Interaction.MsgBox((object)("Your Freee Pc Licence Period is Over End Date = " + Conversions.ToString(DC_Main.AmcEndDate) + "...."), (MsgBoxStyle)0, (object)null);
				Application.Exit();
			}
			DC_Main.MembReg = true;
			return;
		}
		switch (DC_Main.SSRegSrNo)
		{
		case "VS055NEVS":
		case "HM037NEKU":
		case "HM039NEKU":
		case "KJ027NPKJ":
		case "AK022NSAK":
		case "HM516NEKU":
		case "HM291NSHP":
		case "HM204NSHM":
		case "AK027NSAK":
		case "HM452NUHM":
		case "HM463NSPK":
		case "AK011NEAK":
		case "HM252NPHP":
		case "VK162NEVK":
		case "HM321NAHM":
		case "HM267NSHP":
		case "AK042NEAK":
		case "DM083NBDM":
		case "HM603NAHM":
		case "HM154NLHM":
		case "HM747NBHM":
			if (Operators.CompareString(DC_Main.SSCompSrNo1, "", false) == 0)
			{
				MsRegSoft = true;
			}
			break;
		}
		if ((DC_Main.MsAmcUnlockDay >= 10) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM029NSPK", false) == 0))
		{
			AmcFreeDayReset();
		}
		if ((DC_Main.MsAmcUnlockDay >= 10) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM569NUSR", false) == 0))
		{
			AmcFreeDayReset();
		}
		if (!DC_Main.MembReg)
		{
			if (Strings.Len(DC_Main.SSRegSrNo) == 1)
			{
				Interaction.MsgBox((object)"Yor Regester Id Is Not Valid Please Contact  9879966455", (MsgBoxStyle)0, (object)null);
				Application.Exit();
			}
			if (!MsRegSoft)
			{
				Interaction.MsgBox((object)"Yor Regester Id Is Not Valid Please Contact  9879966455", (MsgBoxStyle)0, (object)null);
				Application.Exit();
			}
		}
	}

	private void Slreset()
	{
		Module_Schm.CompnyRest();
	}

	private void SoftNoneUse()
	{
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS083NPBU", false) == 0)
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM129NSHM", false) == 0)
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if (Operators.CompareString(DC_Main.SSCompSrNo1, "A.JJ2VSZ1.CN1296641F0020.Z", false) == 0)
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM033NEPK", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo1, "A/CVGH622/CN1296345LGFW2/Z", false) == 0))
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM528NSKU", false) == 0) & ((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo2, "74F1D327", false) != 0)))
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM376NEHM", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo1, "A/4M29QW3/VNCMV003A20091/Z", false) == 0))
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM272NPPK", false) == 0)
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK017NASD", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo1, "A/6JMNVB2/CN7620665L055A/Z", false) == 0))
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK080NAVK", false) == 0)
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK109NEVK", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo1, "AR105NBCV00L09TMBZ", false) == 0))
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM111NPHM", false) == 0)
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM232NAHM", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo1, "ABSN12345678901234567Z", false) == 0))
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK038NEVK", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo1, "APLKSR00WBG50EOZ", false) == 0))
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM243NPKU", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo1, "AYB10628355Z", false) == 0))
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM225NAPK", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3T58S73/CNCMK000BJ049E/Z", false) == 0))
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM317NAHP", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo1, "A/38R37S2/CNCMK008CE07CB/Z", false) == 0))
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM275NSHM", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo1, "APEGTPE21W6TA0HZ", false) == 0))
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3QSKYY2/CNCMK009AK0067/Z", false) == 0)
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM071NPKU", false) == 0) & (Operators.CompareString(DC_Main.SSCompSrNo1, "APF0TMV0BZ", false) == 0))
		{
			MsWhoutAmc = true;
			DC_Main.MsSoftNoUse = "Y";
		}
	}

	private void Self()
	{
		if (Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "AB", false) == 0 && Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) != 0)
		{
			Self_Amc();
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "AB002NPAB", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AVS81801365Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ALB47PTCJ000UXHMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKVYH018JFODYZZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AB001NPAB", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMWXA078JI21R5Z", false) != 0) && Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "AB", false) == 0)
		{
			MsRegSoft = false;
		}
	}

	private void Kishor()
	{
		if (Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "KJ", false) == 0 && Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) != 0)
		{
			Kishor_Amc();
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "KJ078NPKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2NJ13WZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ077NBKR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A211194061903157Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ075NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATC52NXCV005FT6MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ074NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMXL33216JZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ073NUKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJSUK0A8JGB0YKZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ072NPKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ071NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGSXR0I0GCDFXMZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ070NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFTQ028JFM0K7Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ069NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFSLF0BWJ253ICZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ068NBKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/536RHL2/CNPE10078L05W2/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/G99KZT3/CNCMC002BU0352/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/133V6T2/CNPE1008AS0V8R/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ067NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJSCQ00WBFAA6FZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ066NLKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP19BLHUZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ065NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AM521NBCX00H8R9MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ064NLKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ063NLKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_O31E593862Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ062NBKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APLKRE048JGB04VZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ061NLKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH048JGNK4HZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ060NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALID             Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ059NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "B805E21C", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ058NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APESRK0PCY93633Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ057NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ056NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APUYZQ038JL01G6Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ055NLKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKUSN028JEF07SZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ054NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ053NLKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMB48NBCV01AFZHMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ052NSKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHVQV118JGA0DJZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ051NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ049NSKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/45YS3F3/CNCMK0015404BF/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBU028JJZ2JBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AACWS432004ZMZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2ZKYNBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ048NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APESRK0HCY4207LZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ047NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0F8JJG19SZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ046NPKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/JW592N2/TW3207088A0011/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ045NEKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/6P4PSY2/BRFCB0097F0004/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/G2P8SG2/CN7220067R00AN/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ044NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AN939NBCX00EPYVMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ043NEKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.H96TVS1.CN701662AQ0CHT.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ042NUKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/9221YF3/CNCMC001710703/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ASGH534RXJFZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ041NUKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFSV018JG5996Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ040NUKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0D8JJW0G9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHQERB31WB9HQPZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ039NPKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF1ETKM5Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ038NSKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGZAL0A8JCG6E0Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ037NUKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APFYTH0GCY93BN5Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTHNU028JKA3QEZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ036NBKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP20ZK86Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/BTVJ793/CNCMA000CA00EA/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ035NEKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APGATU0FK996Q1RZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AQS00590097Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ034NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH078JJ96VAZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ033NPKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ032NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APESRK0WCYAM4A9Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ031NSKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ030NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ACZC4342S0QZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ029NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRSPB028JHV1YPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ028NPKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/53R1QN2/CN1296384G004E/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ027NPKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APQECF0A8JHP04TZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP05K3SQZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ026NBKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APKKMCB31VEFPYXZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF52CY8VZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGSXR0J0GCMO7CZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ025NBKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/JGN1MJ2/CNWSC0077Q00AJ/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AJPA3346GM5Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ024NEKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A.JR9T922.CN701635BL00M5.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA4261T3GZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ023NEKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA233115TZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGVZA1AK9A5037Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ022NBKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6VMCGK2/CNFCW0075N00UG/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ021NPKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/G7JH152/CN7016353P014U/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/27CFBB3/CNWSC000AD2MRI/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ020NPKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/GZH4NM3/CNWS20035O009D/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFEJAF3WV8O6VIZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ019NPKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKXMAD21VEY433Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ018NPKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ016NPKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP27VYXNZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ015NPKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/H4FSKJ2/CNWSC0077H036B/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2DJ7AZZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ014NPKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/4G8GNV2/CNCMK0094F040B/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ASNZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/2DR0LQ2/CNPE10086416KB/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ013NSKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT521NBCX009405MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ012NEKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/3639TC2/              /Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/694J5R3/CNCMC0029A04A9/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/53QSJS1/CN7360417M01TW/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ011NSKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF30PF32Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ010NPKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP26ZWYEZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ009NPKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A171012533104296Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ008NLKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/58G04C2/CN762066AG00VQ/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AGEHO22101NQKZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ007NPKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A.ÿÿÿÿÿÿÿ.              .Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGGFDB3NM52B0CZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/45YS3F3/CNCMK0015404BF/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ006NEKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AN625NBCX00JW4TMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA5191VN6Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ006NEKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA5191VN6Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ006NEKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.25BCW32.CN1296652H04AA.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ005NEKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AC02630200VYGVYVALZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ005NEKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APGXAR038JC53IEZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.3YZ4D32.CN7620653J05H2.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APDXVV00WB7X0COZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ004NPKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ003NPKJ", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/11ZQ713/CNPEC009BR028P/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/2222222/              /Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "KJ001NEKJ", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/HTDL882/              /Z", false) != 0) && Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "KJ", false) == 0)
		{
			MsRegSoft = false;
		}
	}

	private void Hemal()
	{
		if (Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "HM", false) == 0 && Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) != 0)
		{
			Hemal_Amc();
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM777NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJJBNH21WE8EBEZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM776NUKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AM906MC00PQZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM775NUKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/HQYW6Z3/CNCMC0038O0E92/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/BMY7M24/CNFCW003CG034E/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM774NAKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AL1HF14F0785Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/F8P4MD4/CNWSC005A80VX7/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM773NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2Z61TEZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM772NLSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKWRPB31UFY7ZTZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM771NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT623PTCJ000A3AMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM770NUHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1T7D5CZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM769NPPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADX002D37Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM768NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATB48NBRJ011236MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM767NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AW104PFCJ0038WUMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM766NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2TB03YZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM765NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPYFB098JJQ1TTZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM764NBSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFYTH0LCYAN5XIZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM763NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "04FE7BC5", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGWHQ00WBCB767Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRSPC068JKG2T7Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTMYQ038JKZ38TZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM762NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT937NBCV00BJN9MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM761NBHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/GHJKL78/              /Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "6E5EF195", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM760NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0ACY9M4JXZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM759NBKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A230926643700834Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APVCNT018JL2FGOZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM758NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/25F10G2/CN1296373N0323/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM757NUHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJCKH0BMVCOBUKZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM756NAPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT522NBCV00VNH2MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM755NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07D9030_P71C082207Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM754NPPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/8QM3393/CNCMC000BJ1383/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM753NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ASA42PTCJ000FL4MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM752NPPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJUYED21WDMS51Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM751NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLRSR018JLQBNLZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM750NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ALC50NBCX009JFTMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM749NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRCSU0D8JKO048Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM748NBSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM747NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM746NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFDL048JIX4SVZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM745NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/7WYY4R2/CNPE10083Q0QDV/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM744NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/4JHRWN2/CNWSC0087I0184/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM743NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/4VKRN13/CNCMK0002T0161/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM742NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/HFDW3D3/CNCMK0023R005C/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM741NSSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/2TVYVP2/CNPE10084O0C3J/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM740NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APVAQN028JLR04XZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM739NBSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT938NBCV00D7ZYMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM738NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF4DY059Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM737NPPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPYFB048JIA3UYZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM736NBPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A.3GZN232.CN762064AD0103.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTJXT028JJO0PDZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM735NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT416NBCV008DNFMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM734NAKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                        Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APURAEE3WVKRRRJZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM733NAPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AM415NBLP002PDWMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF1LKZG0Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM732NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM730NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/7W2VVX3/CNFCW0033L0388/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM729NAKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/5TJ1N24/CNWS2004A200YB/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM728NUKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A210890362705124Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM727NBSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM726NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/98MZXM3/CNCMC001CO0C22/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM725NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/HVVDPC4/CNCMC0058707AB/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM724NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF3FWA57Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM723NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBR018JHT17YZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM722NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/17H91P2/CNWSC008AC01S3/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM721NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/9S9NP24/CNCMC004CD0091/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM720NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ALB46NXCV00BSB4MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM719NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APTXKL028JJY6CHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM718NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF42RVFAZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM717NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AM729NRCX00H98VMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM716NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM715NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT936NBRJ004041MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM714NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBV058JKH03FZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM713NBSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF30PB32Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM712NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/7692NJ2/CNWSC0078A064X/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM711NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKXMAB5MYGR80MZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM710NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF3S21WPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM709NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK048JH55GPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM708NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APUSVT028JKP6LZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM707NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT623NBCX001CFXMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM706NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APUSZL018JLE0XPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM705NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APUSZL018JLE113Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM704NLSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM703NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/C3NZM33/TW3207005G007C/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM702NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM701NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM700NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/9VJD5Y2/              /Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM699NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ABTWW112009BMZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM698NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRRUL038JIW9S0Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM697NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/F016R24/CNFCW0057I03E4/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM696NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMA43NBCX00SAPPMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM695NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMA43NBCX00SAPPMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM694NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP26YVAXZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRSPB088JKRBQ6Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP26YVBHZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2Z4N62Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APUNUH0E8JL57CXZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM693NPPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT206PFCJ001081MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM692NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQNNB068JIG46HZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM691NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/F5VZLN2/CNPE10082J1D7E/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM690NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0HCY37JPBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM689NAPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM688NEHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/B7NSPL3/CNWSC0025S0IG5/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM687NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM686NUHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM685NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKGWA028JFE1EBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM684NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLMUQG3MYHOTH9Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM683NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM682NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.4S06D32.CN7620653K0027.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM681NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF57PVJNZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM680NUPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0D8JKM03MZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM679NAPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/8PZL593/CNCMK000C20AC1/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKPSN00WBFL5K9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/GDPT6D3/CNCMK0014T06AA/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM678NUKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AS727NBQC000M9PMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM677NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/FG0M654/CNCMC0051T0E73/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM676NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/J75RDX3/CNWSC0035V1QM9/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM675NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/JX2L954/VNWSV0048S0JGG/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM674NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM673NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APUPBK00WBL50HAZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM672NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR833NBCV00JCNTMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM671NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM670NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.J4T9HJ3.CNCMC0019K085E.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM669NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/C98F7L2/CNWSC0083M001B/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM668NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGWLN00WBBK1UAZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM667NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2Z61YZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM666NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APUSVC028JL32BYZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM665NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFSV068JJN5CAZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM664NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/4NNM944/CNCMC0051P0622/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM663NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/DRTM944/CNCMC0051P0647/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM662NUKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/4GN1P24/CNWS20051D00BM/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM661NLBR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/B0P9003/CNWSC0009U1GA2/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM660NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR414NBCV004MM8MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM659NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFTQ048JGV3BPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM658NUHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_O91E564889Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_O91E204871Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM657NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A123490EN400015Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM656NBSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APTHNU028JKC306Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM655NBSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM654NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJSUH0A8JFYAZZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM653NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGNERM3MY88U3SZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM652NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/JCRR273/CNCMK000AB015C/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM651NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/86501C2/CN7620668O0871/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM650NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/D1322R2/TW320709AH04DC/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM648NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APURDR028JKJ0HNZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM647NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07D3710_N21E208138Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM646NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM645NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF2VTZHDZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM644NBSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/2KSVS44/CNCMC0051R0F1C/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM643NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/BX3S9K3/CNCMA001BI2126/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM642NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AS938NBQC000C1CMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM641NUKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/B6QHBV3/CNWS2002BN03BD/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "C861E9B6", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM640NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPXLF048JHV09BZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM639NBSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM638NLSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGATU0J0GADGJJZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM637NEHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/CK07WL3/CNWSC002930TSG/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "76A2F974", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM636NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR937NXCV0039HFMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM635NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/7KKHR34/CNCMC0045H0824/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM634NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQNNB028JHV2ITZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM633NUHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMXL2292YBHZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGWKK00WBBK0B9Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM632NUHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.FWK1514.CNCMC0045801FD.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM631NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/96D0CZ2/CNFCW0097404K5/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM630NBSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_OA1A501724Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM629NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/GPY66Q2/CNFCW0085P014B/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM628NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APG02PG5TZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM627NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/BMCNR32/CN129635630F13/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM626NBHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/BLLD9F2/CN7443167F05PS/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFXMPH31V44BWSZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM625NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/79NFC93/              /Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM624NUPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHYZHB31WCFX18Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM623NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF5HWXPKZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM622NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM621NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_P11E423008Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM620NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2DVZC9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF23KHXZZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM619NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM618NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF13VTPKZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM617NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF4W5BH8Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM616NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/F0112S3/CNCMK0025B142D/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM615NBSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM614NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/JH2P754/CNCMC0049H0417/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM613NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/7KQ2S53/CNCMC000860E33/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM612NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFPRK0A8J901UCZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM611NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/G7HTB63/CNWSC000BT0447/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM610NBSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF54ZYM4Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM609NBSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AYX0BNY09Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM608NBSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF4Y33RBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM607NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBT028JJYAWSZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM606NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/7C8BN24/CNFCW004AC010Q/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/B1TDM24/CNFCW0043P021Z/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/6R03N24/CNFCW0047F00O8/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/BGR1N24/CNFCW0047F00NM/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/B02CN24/CNFCW004AC01R1/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/FQCCM24/CNFCW0043Q007B/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/2WFD554/CNCMC0048D0498/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/2R03N24/CNFCW0052A02NS/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM605NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/JF34PQ2/CNCMK008780052/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM604NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMGNKF2MYFPPJ0Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM603NAHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "7C558D6B", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM602NUHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/3W7K473/CNCMK000A40A73/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM601NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM600NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/7M6LS32/CN1296356J013B/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM599NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AS937NBQC0005CVMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM598NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/4KTDL13/CNCMK000370061/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM597NEPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "2C3F85EB", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP10U1DBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRSQB048JJ90I3Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM596NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH078JJBABDZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM595NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AO5PF00XAY001BLZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM594NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "F8AE3163", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APSTWN0D8JK603FZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM593NUPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM592NUPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AYB04194441Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/40VMZX2/CNPE10099705LO/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM591NUPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1FUP51Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM590NUPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF4KBMZZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM589NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF31CGFZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM588NUKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/4RF2J93/CNCMC000CT1387/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM587NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.D03YXR3.CNCMC0025O09A1.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM586NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APSTWP0D8JJU0TFZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM585NUHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/9YMN2F2/CNWSC0073104H3/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM584NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/BCWVM24/CNCMC004780F14/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM583NLHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/1234567/CNWSC001CA1J3B/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM582NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM581NBHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/GYHDRR2/CNPE10088205OT/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/GZMC2G2/CN1296374C00BD/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM580NUPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM579NUPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AM80-H9018400626Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM578NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKEFBI31UFWFH7Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM577NUHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APUQDQ00WBKP2DCZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM576NUHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF285JJBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/50DRZX2/CNCMC0098H0325/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM575NUKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/198ML83/CNFCW0009B03IU/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMFBD068JIF04ZZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM574NUHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF407WBSZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM573NUPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM572NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRCSR0A8JIF0T3Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM571NUHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APSKQHM21WJ963OZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM570NUKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ANot ApplicableZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM569NUSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFGCUC31T9A3HVZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM568NPSR", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFPRH0A8J985ABZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM567NUPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/5HW42F2/CNWSC0072J00SC/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM566NBHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHQERB31VBIJCYZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM565NEHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/GGQ7854/CNCMC00482090F/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMC48NBCV004JE2MBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM564NLHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APCWJB001X5LMY6Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM563NUPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/HY0NTT2/CNCMK0091V05C6/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFKZU00WBAF3F9Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM562NUHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHJFCE51TCF5O6Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM561NUHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APHUQC0BCYCT41TZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBR018JHS23QZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM560NUPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2Z3A4DZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM559NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM558NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM557NUKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APGHWF00WBBE07CZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHYZHB31TCG9W7Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM556NPHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_O31E105915Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM555NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.83KVXM1.CN701660BK0067.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM554NUKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/F6FFSQ2/CNCMK0088O0CC7/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM553NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMTXE038JFU0LAZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM552NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/D2P1NZ3/CNCMC003960152/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM551NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM549NEHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AP900XTXPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM548NBHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AL1HF9CT02T9Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM547NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/4GLW7Y1/CN7220036I015G/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/H78BTS1/CN7360422O0A3N/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM546NUKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ANot ApplicableZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM545NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKKMEB3MYEIKHIZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM544NUKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM543NPHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/BW4TLL3/VNWSV0022I017C/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM542NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AS626NBCV00TNW5MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM539NEHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APG03JV96Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM538NEKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM537NEKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRCWU0GCYKE679Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM536NEKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKDWPC31WDZH4VZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM535NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/20FH3X2/CNCMK009CT0A5F/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM534NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGWKF00WBCT0FEZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM533NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2HY6N8Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0D8JJB132Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKXMBB41TG20EEZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM532NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMWXA078JIK0XOZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM531NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/C4C2YR3/CNCMC0028Q0760/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM530NEHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APFKFP0ACY9X0BCZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A230318043301009Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3N24V34/CNCMC0044C076F/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANBK9P1100G325000AD2NEDZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM529NPHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/36BD0P2/CNWSC0089N00V3/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM528NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A220909787900786Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "74F1D327", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM527NEHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APMPLF0A8JGL2FVZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM526NEHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APW00ZRQSZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM525NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHWKA00WBDL3M5Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM524NEPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF5522E9Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM523NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/FG05514/CNCMC0046E03BD/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM522NLHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ACoffelakeZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM521NPPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7K5YMF2/CNCMK0092I0BF9/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM520NPPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/7QS83F2/CNWSC0073D00SZ/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM519NEKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHZMP1AHCCG07KZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM518NEHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A07E0522_N41E651003Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_M91E089940Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM517NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM515NBHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APFYTH0TCYBT0ZHZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFYTH0LCYAN5XIZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM514NLHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFSV038JGS0KZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM513NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLSWBE31UFS8VQZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM512NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.BYKVK73.CNCMC000B9009C.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM511NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ARC49NBCV004WJKMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM510NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APTHNU018JJB023Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM509NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AN312NBCV00ZC6PMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM508NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK088JJP1FOZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM507NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRSQB048JIF2JCZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM507NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRSQB048JIF2JCZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM506NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM505NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.J55DM42.CNPE10087502YP.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM504NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH078JJACO6Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM503NEPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                        Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AL1HF2620068Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM502NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APRCSU0E8JLF0Y3Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF3ZDE4QZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM501NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0E8JJ63KMZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM500NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJDVBK2WVDYQG6Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM499NPHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APW00M35EZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM498NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APG02PZHEZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "54CF4598", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM497NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APKDWQD21TFPB6PZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "54CF4598", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM496NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRSPB058JI62Q5Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM495NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "F8AE3163", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/9RW7N33/CNFCW0003M07E3/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/6YNH4Z2/CNFCW0097300XH/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/J0K9HZ2/CNFCW0098J02YA/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM494NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APSADNF2WVHTKP3Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM493NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AN0CV1831MB0047344Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AYX0CXPPNZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM492NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK078JIWNDMZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM491NAPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/DP3PVJ2/CNWSC007BS00ZD/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM490NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF0JDAXEZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM489NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF4GQXH8Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM488NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.68LZGY1.CN7016336400JP.           Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM487NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/J5B42R2/TW320709AP0599/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM486NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR416NBCV00M6C5MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM485NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMMG5S0000055005MP016RZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM484NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APTHNU028JJN0QRZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM483NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2B270RZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM482NAPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APLKRE048JG96NQZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APLRSR018JLQE4VZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM481NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/J8L1P04/CNCMC003BL1C94/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM480NAKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/4JW6M24/CNFCW003CR00H3/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7W2VVX3/CNFCW0033L0388/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/CXJPR24/CNFCW005AF01ZU/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM479NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/1LDP0Z3/CNCMC003CM01F9/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM478NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH078JHVCC1Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHJMVC21WD2E4LZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM477NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFYVB0D0Z7074VZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM476NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AN0CV1847MB0023740Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM475NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/JSQT9Y2/CNCMK009A500BB/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM474NLHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM473NUPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/C186X64/CNCMC004BA05B3/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM472NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJSCQ00WBEECQRZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM471NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2ERGYZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM470NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ANoneZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP24YZCBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM469NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0ED61815UZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/4290DD2/CN7220065N02CX/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM468NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHJFCE31TB869QZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM467NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR936NBCX002D7KMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM466NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/8RDVZV2/CNFCW008CQ00FW/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANBQ59110039247A8B43400Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM465NSHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH07QDIX2FBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM464NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHQERB31WC0NFZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM463NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/FCSNQM2/CNWS2007C900ZH/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM462NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APG03S4YYZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM461NLHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AC1KS82T01BKZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM460NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPYFB078JJ9078Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM459NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF471J0AZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM458NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "486910A8", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/HVS8VQ3/CNPE100328034O/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.585N7X1.CN1296131OGEPP.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM457NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A123490EN400015Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM456NLPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                      Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM455NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/DX4DJ93/CNCMC000CR00E5/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/B1YJ1Z3/CNCMC003850330/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHWCVE31UCL8O2Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM454NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_P11E412787Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM453NEHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APG03KGW0Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "98BCE1B1", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APG03KGTZZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF3BNS2YZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPNMNH31WGSV8BZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM452NUHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2DJKG6Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANBGE61100163014C407600Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM450NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APSJHCABNNJ3E7UZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM449NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM448NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JHV321Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM447NEKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMFRP028JFV6ZTZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM446NAPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/FDKYGJ3/CNCMC0019P0613/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRSQC038JJB0DYZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM445NLHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLKRE028JG5QCNZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM444NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/1PZFPX3/CNWSC003BA0OVJ/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM443NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/9SLFG92/CNPE10018T0092/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMKJK4B0GHLB0IZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2ANTQFZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0E8JJ81F5Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "58B1B6D4", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGXQD038JAY4AEZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM442NBHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/BSR8L33/CNCMK0007B0366/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM441NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/1KDQJY3/CNCMC0036G05A2/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM440NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFSV058JIZ1PWZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM439NPKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/JGKHR34/CNCMC00445065B/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/JCRR273/CNCMK000AB015C/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM438NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH078JIW3P3Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM437NEHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APRXZCG31WIAFBSZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANoneZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM436NEHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6H45ZB2/CN7620667P009Z/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM435NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AW1KS88D10DCZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM434NEHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "A6490D8D", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/JBTB7N3/CNWS20021E02H1/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/G6GJGL3/CNWSC0023313G0/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM433NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH078JIUG1BZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM432NSHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0D8JIT4LJZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK078JIHGO2Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM431NSHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBU018JIG2TOZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.DTYH6C3.CNCMC00139008D.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM430NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/4VJRMC2/CN1296368I02AE/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM429NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFTN048JGR0W5Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM428NAKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/4B8T7X1/CN701632CI0060/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM427NEHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "2614D538", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMREK0GCYHS308Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMREK0GCYHS15NZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMREK0GCYHS4BKZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMREK0GCYHS4C4Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMREK0GCYHS1ZRZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/6223NZ3/CNFCW003AE02QE/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMREK0KCYIK3ULZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/8GFQZT3/CNCMC002BQ0655/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/9N3Q944/CNCMC0051I0369/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMREK0KCYIJ9U1Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/6RYMR34/CNCMC004440415/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMREK0KCYIJ9U1Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/5G23514/CNCMC0045S0530/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/8C7ZW64/CNCMC004BC02CC/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APJSBN00WBED108Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRCWU0ECYJC6T0Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRCWU0ECYJC6H9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMREH0ECYIBC4BZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRCWU0GCYKC83EZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/24ZN4G4/CNCMC005B80196/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM426NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/C271LW2/CNWSC0002300AK/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM425NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "92DFD737", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AM80-G7008000855Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APLSWBE3WVFTIQ6Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/G1HVPX2/CNFCW00947026E/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/38W57D3/CNCMK0014O09CF/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM424NAKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/DW44NF3/CNCMC0015T008E/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/H0Q5TG3/CNWSC001BR1RW3/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM423NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1AUV9MZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM422NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/8DT64W3/CNCMC0033M1012/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM420NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AL116246745Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM419NBKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A200873199600758Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFEJKH21W8O1UBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/H85ML44/CNCMC0051R1116/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM418NBHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/3RL19L2/CNWSC0084A00KJ/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM417NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APETKD0ED62327OZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ACZC5462F1WZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APETKD0GD643C9RZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/27B07Z3/CNCMC0038N0D82/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM416NEPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APFRGV0A8J411HTZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/9DRSPQ3/CNWS20045M00LB/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFXPNH4MY50HMZZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFRGV0A8J411HTZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM415NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM414NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFDL048JIK1F0Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM413NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APG02PFTJZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM412NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JHC0YRZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM411NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF16RJMHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM410NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/GGMD013/CNFCW009AA02OW/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/DP6CFN2/CNWS20081800PB/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ABTWW408003QSZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM409NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "54A662A2", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM408NEKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQTDC018JHD0DWZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM407NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMT7012K21201037Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANBKQ811008333AB1073400Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM406NPPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APG03RW6DZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM405NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQNNB038JIO0XMZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM404NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF3ZV8W3Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM403NLHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFEQ048JHV0LZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM402NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFUAK018J2102XZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM401NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AYB04542385Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM400NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF3Z70MPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM399NEHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APPXLF058JII08QZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "2C3F85EB", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM398NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/C0N9B53/CNCMC0006K0656/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM397NBHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/1MDHJY3/CNCMC0036G0870/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM396NEHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APJHTH0A8JGQ0ZVZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFEGR0D0Z273H5Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "D411808D", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APEWKU0E0Z26V78Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM396NEHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A147843860001794Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM396NEHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APEWPL0G0Z6352NZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM396NEHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFRGV0A8J5516AZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM395NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMA40NBCV004U34MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM394NBHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHQERB31WBB8I9Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM393NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF5Y1MQ9Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM392NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.3QJ86W3.CNCMC0035900B3.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM391NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/J9ZSVM3/CNFCW0021J00VJ/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMUFQ038JFZ5P9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMUFQ038JFZ5P9Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM390NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/H1991P2/CNWSC008AC0002/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM389NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFDL038JHTD3JZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM388NEPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR833NBLP0014M8MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM387NEPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/CLRCNJ3/CNCMC001A30FF8/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQTDC058JIK0RNZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM386NUHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT834NBCV00KC6DMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM385NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPXLF058JIA0GQZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM384NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJRVL00WBEU0LHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM383NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJSUK0A8JFZ418Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM382NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/BX1R5W3/CNCMC0033P01BA/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM381NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM380NBHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP26WENZZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRSQB048JJ90I3Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP10U1DBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM379NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJJBNH2MYE84SXZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/J0Q7LC2/CN1296367G020B/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "C08462F4", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/5YPXYN2/CNWSC0088F00KQ/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM377NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF1KQTNCZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM376NEHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "4ADA9A03", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A4CR1L6Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF3L3L72Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AR624NXCV005RWKMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/5YPXYN2/CNWSC0088F00KQ/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1E94D9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AR207NXCV003S5LMBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM374NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/BQKRSG3/CNWSC001BO23XW/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM373NAHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ABTBE34100JRVZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM372NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/2NL2WT2/CNCMK009370B61/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM371NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT313NBCV00N2SHMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM370NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.GK7TPH3.CNCMC0018H02AB.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM369NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ANBM1K110072330005F6600Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH068JH2C1UZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM368NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM367NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APW00NTMQZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM364NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/C9SHVN3/CNCMC0024K0512/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/GD73P24/CNWS200528003O/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM363NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM361NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APUNUH0D8JKP0ZXZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM360NAPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF0B85VFZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM359NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/2RGY253/CNCMK0007A0A2E/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM358NAKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGWJB00WBBJ2K2Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM356NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPXLF048JHH0IQZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM355NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM354NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AS625NBCV00NC1EMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM353NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AP L61G 01 1Z ZN 2WPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM352NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM351NAKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6992YD2/CNWSC0071101IX/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM350NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/9H08514/CNCMC0045G045C/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM349NEPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMXL3292S67Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM348NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AYX0CYYQ3Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM347NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/CPHQ5W3/CNCMC0033Q07EC/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM346NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JHY1PKZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM345NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/BB4SCT2/CNFCW0091204V3/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM344NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ANBKDE110083173F7E03400Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM343NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6P8KNN2/CN1296383V030F/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM342NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLEDA018JFT107Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM341NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH078JHSCM4Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM340NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/9FV2XG3/CNFCW0015E01QR/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF3V2QLGZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/65WJZM2/CN1296382N050D/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.337WXH2.CNWS2007CF00I6.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.G17WXH2.CNWS2007CF001M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF3V9DEFZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/59KNZM2/CN1296382O0081/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM339NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/49RLDX3/CNCMC003260709/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM337NSHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JHV2LFZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH078JIXYUNZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM336NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/8SQTYM3/CNCMC00229078B/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM335NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "0C54C2A6", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/4XCF9T3/CNCMC002BO0051/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTHNU028JJP110Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM334NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/17HX7S3/CNWSC002BU0MOG/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM333NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APRNRTC3WVHLW2LZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ACB22715178Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM332NBHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/4R161Z3/CNCMC0036R028D/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM331NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6L83NM3/CNWS20033B000C/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM330NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AL209NBCX000WWSMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ABSS-0123456789Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM329NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/H6B5754/CNCMC0051S0D34/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM328NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APKEFBH31UFHD1HZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK078JJ949KZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM327NPKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/962N8G3/CNCMK00353001D/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APLQRQ0A8JG10DMZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM326NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/331JSN2/CNCMK008CG1920/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM325NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/D9QLQN2/CN1296384P007E/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/DSH9KG3/CNWSC001B51EH6/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM324NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMXL2410Q8ZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM323NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A147535670004223Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF11NR10Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM322NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2B7RDDZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM321NAHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APJHTH0A8JFC1M9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                      Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.FZH9M42.CNPE10087501PV.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM320NPPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF496WBKZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM319NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.24ZM682.CN762065C902MI.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM318NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF3KXN70Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM317NAHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMXL4091F0TZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM316NPPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0D8JKM0L2Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A136063720001676Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM315NPKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APGQAR018J960HZZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APUNUH0D8JKO19XZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM314NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1FR7BVZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANot ApplicableZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM313NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/14YRPZ3/CNCMC003AC0E71/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JIB08NZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/HXDQPZ3/CNCMC003AC115E/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM312NAPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "18815199", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/6P8S7V1/CN1296127KGGS2/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AT624NBCV00F35EMBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM311NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APG03P6AZZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AC0274330294HWVTAXZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM310NEPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "E85E5965", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALID             Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM309NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APTHNU028JKB95SZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM308NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.4Y8R432.CN762064BI00CM.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM307NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ASGH229TF6YZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7Y4VWQ1/CN736041920371/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM307NEKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ASGH217QQQ2Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM307NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ATo Be Filled By O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM306NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0E8JJ626PZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM305NPKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF38P62HZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK078JIG49QZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM304NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AM727NBCV0075NAMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APETKD0KCY61F30Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF550WLXZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM303NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "4C6758C8", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHRXHC21UCFS4AZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM302NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1AMRVUZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM301NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/4B9BMW2/CNWSC0003A000C/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/34CS4W3/CNCMC0031S0B58/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM300NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A12222334455666Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM299NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/7FCNR32/CN129635630A6C/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/JBNJHX3/CNWSC0038M10NE/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM298NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AM622NBCV0044V6MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM297NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JHC0NCZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM296NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQDQK00WB94195Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM295NPKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JHA1VOZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM294NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJRRP00WBDY0GNZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM293NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFTQ048JGV3BPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM292NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK048JHH0CUZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM291NSHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AAUD4260JXSZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/GX2BQ12/CN129634CI0002/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ASGH528T42YZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM290NAPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM289NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/73VSPQ3/CNWS20045M00AJ/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM288NPPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "84CCD5EF", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM287NEKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQDQK00WB971IVZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM286NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/G0FDM74/CNCMC00452017D/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APFUAK018J210M6Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHHSL1CK9B75JGZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APJABQ00WBCY153Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "F0F836DB", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGHWE00WBCV0FKZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGHWH00WBA31N0Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/618JNL3/CNWSC0025Q007W/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKLJAJ2WVFDFDZZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKLJAJ2WVFDFDZZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM284NAKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0D8JJX0FLZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF17F6YMZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.JJ2VSZ1.CN1296641F0020.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM282NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AC02516606GWG91QALZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/FD78T44/CNWSC0048B140J/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGUWF028J900CCZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM281NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.8G4MYH2.CNWS20076500FP.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM280NUKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP26SCKWZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM279NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM278NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APGNERN41UA11TYZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                        Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/HM7MZQ2/TW320708AO0C82/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFYSD0D0Z85SYKZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM277NSHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APE006FYGZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALIDZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM276NSHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA3322MNFZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7WLMH12/CN1296347O032F/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM275NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "6450DAD7", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHQERB31WC0SW7Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APUSVQ018JKH2YFZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM274NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFSV018JG5HWVZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM273NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJUVLF21UE2HNYZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM272NPPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APJHUQ0A8JEN2CYZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APLFSV058JIY8QYZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM271NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/CS5W4P2/CNWSC00914013H/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHJFCE31VB4XI1Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM269NEHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2YNWA4Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APUNUH0D8JKD2R4Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANot ApplicableZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM268NPHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK048JHHAJBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2ZBSACZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM267NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/5FKDNK2/CNFCW007480013/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM266NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMPLD0A8JGI0HFZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM265NUHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APRUHUE21WIH2ZUZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/CW0QKJ2/CNWSC0077G01L5/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM264NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKEAQ018JFS27KZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM263NPPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JHA2PNZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JHF18XZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM262NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH068JH23ZDZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM261NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKXMAB51WH49JDZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM260NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM259NEPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM258NAHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/FCG2R32/CN1296355K04AE/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ACND0460YBHZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM257NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH088JK093SZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM256NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF30AHE3Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM255NAPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHF028JEG1XYZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AA217060201EP149AZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM254NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_M91D033920Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM253NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/430W0F2/CNWSC0071J018X/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM252NPHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0ECY20POPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM251NSHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APETKD0JCY54QQYZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APJHKF1B0GES0M7Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM250NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLKRD028JG99ICZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM249NEHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF4KX7S5Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP10YXQRZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/GNRW6T2/CNWS2008AH00CE/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1AX3N8Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF5GZQ99Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM248NPPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFPRH0A8J5029DZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM247NEPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJDVBK2WVDYQG6Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM246NPHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/7TZHGF2/CNPE10021U00JF/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AYX0E8YLWZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM245NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH048JGN2CIZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM244NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "F8AE3163", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/CTW5GR3/CNFCW0025S018P/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/640FGP2/CNWS200838014A/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/35JBHJ3/CNCMC0019O073B/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.HL5HH92.CN7016368P02C3.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/HMVX4V3/CNFCW0029902KS/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/2TD9YR3/CNCMC0028G0161/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMUFQ038JFZ5P9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/8QQBYX3/CNFCW0033704QT/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTHNU028JK03UPZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7XG63S3/CNFCW002830385/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP28M84PZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM244NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/GLG97T3/CNFCW003590296/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTHNU028JK03UPZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/2TD9YR3/CNCMC0028G0161/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/2TD9YR3/CNCMC0028G0161/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMUFQ038JFZ5P9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/HMRPKW3/CNFCW002CM01XA/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMREH0ECYIA3QLZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM244NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APMREH0ACYGOEP7Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/8QQBYX3/CNFCW0033704QT/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3Q3SN24/CNFCW004B800JC/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM244NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/BVDQR24/CNFCW005AF00PK/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/20SRR24/CNFCW005AE02QG/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM244NEKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/J9ZSVM3/CNFCW0021J00VJ/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM243NPKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JI11GAZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/FHNGKC4/CNWS20058800OF/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM242NPHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMB44NBCV006RSJMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM241NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHQERB3MYCBRFHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM240NPPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBR018JKD5WBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APUSVC018JLS1TKZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM239NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/8GYW4F2/CNWSC0074B0285/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM238NPHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/31TRV64/CNCMC004B41554/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM237NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP24YN0HZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM236NEHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AS729NBQC000USDMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AT416PTCJ000W88MBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM235NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKVYH048JGL620Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM234NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6HD00X2/CNCMK009660058/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM233NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJDVBJ21VCGXBFZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM232NAHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/1CSYW14/CNWSC0037S08RI/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/FXYSQD3/CNWSC0011M232U/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRSQB048JJ90L0Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM231NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APPNMLH31VGS34QZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APEMLE018J7J11JZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM230NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AM102NBCX004D7TMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3L2LX14/CNFCW0039K0099/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/HBCJ8S2/CNCMK009140049/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM229NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF550TMWZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM228NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM227NAHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/F73CN32/CN1296354E0086/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "CAD787C1", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM226NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JGV0KBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM225NAPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/BNL4YW1/CN1296133E01BE/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AC02628201AJGPX4AZZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/2NJY1N2/TW32070847005F/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/1KFHWD2/TW3207079C01B3/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/9KSZRG2/              /Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM224NSPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.FLBF0X1.CN1296634I0473.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM223NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJHTH0A8JE457FZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM222NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AS522NRCX00BZLUMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APLKRE048JGADPCZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM221NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF0AU3EBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/GDN5524/CNCMC0042L0B86/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM220NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR731NBCV0173A8MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM219NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJSUH0A8JGB3RZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM218NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR626NBCX00A84DMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM217NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF49ZJJZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM216NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKBUK00WBEP1XXZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM215NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07E0522_O21B086686Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM214NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1F7K94Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM213NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AL116246745Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM212NAPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A1Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF34RGSXZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM211NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF2ZE9NXZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM210NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLSWBB31VFZMSPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM209NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A07D2212_O11E291640Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPPFV0ACYGD67SZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM208NEPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/4PRFKG3/CNWSC001B616W1/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMWXA028JG937RZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTHNU028JKF9B3Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM207NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGVXV0D8JBZVSIZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM206NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AL939NBCV00C61XMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/HD7TWT3/CNWS20042300FI/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/HD7TWT3/CNWS20042300FI/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM205NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP24PY4AZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM204NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APLQRH0A8JG10LLZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AN/AZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALID             Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM202NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APJKQA048JEAEA3Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANoneZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFEJKH41V9AI0WZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM201NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.D771MV1.CN7016628TG15C.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM200NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/1BWB9L2/CNWSC0084F000E/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/D1XF654/CNCMC0048300E7/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM199NEPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APSNWDN3MYIJP7AZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHREK018JBI0UNZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM198NEPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1VQV1XZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/CCSQ4N3/CNCMC0022N14FF/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2B1MKLZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2DJF9VZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM197NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ASGH616QX8KZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM196NAKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1RNSQPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM195NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLSWBE3MYFT6RHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM194NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/5X8LPH3/CNCMC0017U05AB/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM193NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/7VR6XK2/CNFCW0074A01L9/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM192NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF0UMXGDZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM191NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP24PQZZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM190NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AKNQN03510291Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMMTT018JFI6CAZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMLUH00WBFX00QZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APJRVL00WBET05FZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM190NEKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AS626NBCV00TNW5MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM189NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APG04CCDEZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH078JIGBNUZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APG03FF8XZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM188NESR", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "8431840E", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMFRP028JGC41DZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM187NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/FXHVLW2/CNWSC0002S00LG/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM186NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AR937NXCV003030MBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKDWQD21TFPRF5Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM185NPKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APGCHE018J374IUZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMA41NBCV00DCVZMBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM184NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM183NPPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM182NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRSPB068JIJ5KBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM181NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AO5FX00T4M000D8Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM180NPHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/5CGYTJ3/CNFCW0017N04QQ/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM179NBKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/B17H8C2/CN7220063100Y2/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM178NEPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ANONEZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APLNRB018JFNBXJZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM177NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A143088190003206Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.7JDZLV1.CN1296127TGEU3.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM176NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF2ZWGCBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGSYU0H0GBZK6VZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGTXL0HCYC5VO4Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3T54P24/CNWS200528014M/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM175NAPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/BJ9J882/CN7016359J02XI/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM174NLKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ACZC10195Z7Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGNAR1A0G90112Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM173NPHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APENMFE21V8R5VVZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM172NPHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APGVYF2A0GAD00YZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM171NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANB47NBCV00P3K4MBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM170NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF4J3LVPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM169NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APKVYH048JFJ0M0Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/4FRV8Z2/CNFCW00984041H/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM168NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AGEBF422001TXZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/9B8YVF2/CN12963724013C/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/84H68F3/CNCMC0017F1610/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM167NAPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/738WTJ2/              /Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM166NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM165NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APGAVK0A8JD11BNZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF38JYEQZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANBDBE11002525001EC6L01Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM164NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALIDZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM163NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/4MCZPH3/CNCMC0017T104B/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM162NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/JDCSQM2/CNWS20085302H0/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHJFCE41VC9FUBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM161NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/7JZ0HJ3/CNCMC0019O04EF/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM160NPHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJHTH0A8JFK4WZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM159NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A.36J7042.CN129665A7003F.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JHV1ZMZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM158NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.F9P0512.CN7620645H0075.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM157NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APGGFDD21T693CDZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/DFRD4C2/CN762066AP00H6/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM156NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM155NPHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/48Y3JK3/CNCMC001AQ086A/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ACB07918150Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM154NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A160882577603103Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM153NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/14TL9H2/CN1296377N2541/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM152NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APGTXL0BCYB42IKZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AGEBE845007WMZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM151NEHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/FW1CML3/CNWSC002570T5B/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM150NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1KDPRLZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM149NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQLBCJ3WVHAUHXZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM148NPKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM147NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "2C3F85EB", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1VY0C0Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTHNU028JJY0K0Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPJEH0D8JJ80FIZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APUNUH0E8JLG0XBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM146NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2ZYXHAZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM145NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF0J27YQZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM144NPKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/HJ4YS32/CN1296356N000C/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AFV9802605N5J22GD0Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM143NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1TBVE3Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM142NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFDVA018J8R2XHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM141NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKVYH028JER14QZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM140NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AR101NBCV004M0FMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/61CJ8D3/CNCMA000A701DA/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM139NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMWXA058JHI0F6Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM138NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKXMAD21WF7YUHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM137NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKXMDF2MYEZEUUZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM136NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APJSBN00WBEL07WZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM135NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH028JF3BL5Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/1RNF7T3/CNFCW0028R006D/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH058JH0C4PZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM134NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/2CVBL73/CNCMC000BA0B43/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM133NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKVYH038JFH53CZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM132NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AVS81801804Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM131NEPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "B659E190", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APLKSR00WBG715CZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGHWK00WBC11H2Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APLKSR00WBG50P6Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGHWK00WB8922TZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM130NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AGEPA22100TZ2Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM129NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF0QD6UBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM128NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/72SNYM2/CN1296382A0148/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF3XRKK9Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM127NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGSYU0J0GCLEAYZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM126NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKEFU0EMVEW3JHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM125NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJHTH0A8JEY4KTZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM124NEHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF23KTH0Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2B0R96Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM123NSHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF0XD0UMZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM122NEPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A07D8211_M81D040229Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ABTWW310003A5Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM121NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/13GKPJ2/CNWSC0078R04CW/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKDWPC41UEXGKTZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/9FHP9W2/CNPE10098602IB/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM120NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJJBLC2MYF89QHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM119NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKEFBF21TF50JRZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM118NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQRNEQ3WVIKZFSZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM117NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR414NBCX0004NFMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM116NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFJDKE21W9SFB2Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM115NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJRRP00WBEU1BNZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM114NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJJBLI21TEZY1UZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM113NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH018JF23PMZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM112NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM111NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM110NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF0XU3S5Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM109NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM108NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/92M3MJ2/CNWSC0077R00B1/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/8Z4XC82/CN7620663U00CO/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM107NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF4GQXH8Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKVYH018JFS6RTZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKVYH018JFS6RTZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM106NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APG03JVB0Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM105NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH018JES7T5Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM104NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.G11M912.CN7620649701ZR.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM103NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ABQML244001E2Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1A6KFQZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM102NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/37DGCP2/CNPE10082I0TWF/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANBC1F1100125035E191601Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM101NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR90X9M5AZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM100NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR90VPAMEZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM099NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/37FTFD3/CNCMC0013R0342/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/5PQBPH3/CNCMC0018N11DA/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM098NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_O91E204871Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3YMDDL2/CNWSC0086B07PN/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM097NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF3K8FB9Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM096NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM095NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/HTVM173/CNCMC000AC008C/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM094NEPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1N91J3Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM093NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APHWGH00WBCY85JZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF3Z8LRNZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/6YVY733/CNCMK0004A193E/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APDXVC00WD7PUJFZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM092NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF0R2RFFZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF36Y7S2Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM091NEKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM090NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ABSN12345678901234567Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM089NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP05HZ5DZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM088NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "86C8169E", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM087NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATB2015103509H0305Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM086NPHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/C69MNJ2/CNWSC0078G063U/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF50QA3PZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM085NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/5J0G1Q3/CNCMC0025C0A58/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM084NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM083NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AVS81772312Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM082NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGZAL0A8JAS42KZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM081NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/2N9HGP2/CNPE1007CL06YK/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM080NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM079NPKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF2C85XHZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1NZD7PZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRSPB068JIGEKIZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM078NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A.7PT3P24.CNFCP0052H009X.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/2P89823/CNWS2009CB00TH/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/GC9DCV2/CNWS20091R004Y/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP090E0BZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM077NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AN/AZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTHNU028JKC37DZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM076NPKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/BJK54L3/CNCMC001CD106B/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/BJK54L3/CNCMC001CD106B/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF42TKGPZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM075NSHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                        Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFLAA00WBAM316Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM074NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF1EW9UVZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKVYH018JFOICLZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM073NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AN101NBCV006FZRMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM072NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.2FP9772.CN7016364B00N9.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM071NPKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APUSZN018JKX87PZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGNERM31W88V1WZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHKVEB21VAYY9UZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM070NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APKVYH048JFIEU0Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                        Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM069NPHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/3231GZ1/CN701633B9007P/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM068NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/8VW7152/CN1296353UGFFQ/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM067NPPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0E8JJA4ALZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7HQK9X2/CNWS20095800FR/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7HXK9X2/CNWS20098M02TV/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM066NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APGZAL0A8JC9452Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3DZ2M24/CNWS20042L0006/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM065NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APGUUB0A8JBZ0UOZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/4SS3M24/CNWS20042L000D/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM064NLKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFJDKD21U9P24BZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM063NEHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APJLRL018JDG0IWZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APJLRL028JDH4LOZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM062NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF2E4EGSZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM061NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJJBRH21UE414YZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM060NUKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/GGJP7S3/VNWSV002AI02R7/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM059NBPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/4V001Q2/CNFCW0086303X3/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM058NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF2R7CTDZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM057NEPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA5321H68Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM056NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ANBMVH1100F54318D4A7600Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM055NPPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALID             Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM054NPHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF15UU24Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH028JFOD19Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM053NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.5RBMXP1.CN701660CHG3YC.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM052NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AP901BB7UZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM051NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AN/AZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM050NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM049NPPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP159UZ9Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM048NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1RDFK5Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTQQUH5MYKCHFTZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM047NEPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APFKZU00WB444MXZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGZAL0A8JDI0W4Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM046NPPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF4AGXN6Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM045NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A.BVWQFY1.CN7620635L00TU.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AK316559666Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM044NPHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/J5FGZJ3/CNPE1001AM02PW/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM043NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/D10TYL2/CN129667A711FD/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM042NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR833NBCV00JBRDMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM041NSKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFDUU018J8Q0H3Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM040NPHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ABSS-0123456789Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM039NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/F1772P2/CNWSC008AU05PQ/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/5QJ51B3/CNWSC0014907SW/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "C468CE8B", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM038NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APKEFBH31VFNHAZZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JGZ0ULZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM037NEKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF19U5DXZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF0E0WKBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "F8AE3163", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM036NAKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1RPH5EZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF3LA811Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/DVNPR14/CNCMC0046H0FAD/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM035NPKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APKVYH038JF2FXXZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM034NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AC021192005SNN6017Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM033NEPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/5SL8VC3/CNCMC001350903/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/1WZT3N3/CNPE10025U041C/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM032NPKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A.6SFZKF3.CNCMC00163053B.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3L8LFW2/CNWSC009AV0116/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM031NSKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF208MHVZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPJEH0D8JJ80FIZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM030NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJSBP00WBDZ1ARZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM029NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM028NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/HRZS703/CNCMC009BF0096/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM027NPPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APELUDI2WV7TQ1IZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM026NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2DVZSPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM025NSPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM024NPPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMXL3292S67Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM023NPPK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM022NSPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APFJDKE2MY10L37Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQRNBO2MYH0NOQZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH07QDIX3XSZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM021NEHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A.8BFDZH2.CNWS20078N0167.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/D8HG0Y2/CNCMC0098501FC/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ASB45PTCJ000369MBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM020NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A220399309602211Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AN0CV1844MB0037157Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ALB46NBCV006PUEMBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM018NSPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2AAH0ZZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1EGYKHZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM017NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF3BAC78Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM016NPKU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AQCCXKP22A93500259Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP154589Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM015NPPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF09MU3RZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKXMBC41UEUOJ2Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM014NSHM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AO5PF00Y6C000KKZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AVS81945928Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM012NPHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APKDWQD21TFP2G8Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFPRK0A8J9258AZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGNERN7NMAKLS2Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM011NSHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF0G1Z2JZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPXLF048JHT2NSZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM010NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF0HW3G5Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM009NPHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA5170WQGZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM008NSHP", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AJPA350Q2Z8Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM007NSHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/HBJVQG2/CN722006BL01NW/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM006NPHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM005NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALIDZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM004NLHM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AGEBF30200MWZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM003NPKU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/8VW9Q03/CNFCW0098J02A9/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM002NLHP", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/JX0LDX2/CNCMC0098B033D/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "HM001NEPK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                        Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANot ApplicableZ", false) == 0))) && Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "HM", false) == 0)
		{
			MsRegSoft = false;
		}
	}

	private void Vishal()
	{
		if (Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "VS", false) == 0 && Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) != 0)
		{
			Vishal_Amc();
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "VS368NBVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2ZR30KZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS367NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH078JIHOXBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS366NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/7NV0MQ2/CNCMK0089N0C21/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "6A6DE67F", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS365NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS364NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AYX0EX8ASZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS363NBVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/1WP7KC4/CNCMC0057V00B1/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS362NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS361NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APUSVC018JLSB29Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS360NUVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/41TMWL3/CNWSC0029B0OIG/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS359NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2ZXX2KZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS358NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKVYH088JIL4HRZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS357NEBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JIF0DPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS356NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07E4410_P51E755255Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS355NBVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMMG5S0000112618KP00CNZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS354NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AYX0GVL8FZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS353NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "E676DB56", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS352NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AS520NBCV00JM46MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS351NBVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1TKCV8Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS350NUVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF5L9R6QZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS349NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6XJG703/CNPE1009960A79/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS348NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK088JJZDX6Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS347NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07E4410_P91E315236Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS346NBVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AYX0G985VZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS345NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS344NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "087D9744", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "B068001D", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGWKE00WBCB0C9Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS343NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/D9MJ5G3/CNFCW0016K011V/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS342NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AL1HF01E0797Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS341NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/3G0SWN2/CNWSC0087J00HO/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS340NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/G9NQRD3/CNWS20013V04DP/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS339NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.86NP4G4.CNCMC005BE004F.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS338NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APREFQ1C0GHCBQEZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS337NBVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLSWBE21UFS04YZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS336NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT522PTCJ001644MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS335NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKPSF00WBFM6ZPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS334NBBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0F8JJM2AFZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0F8JJG1ONZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS333NBVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/5HLFPC4/CNCMC005871023/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS332NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/206SML3/CNWSC0025E22W5/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS331NLBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT728NBRJ000919MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS330NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "78C7764B", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS329NSVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APJMUA048JDJ3V9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS328NBVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHF028JEZB0FZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS327NEVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/HC8PF93/CNWSC000AO065R/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANBGCE11008634024F76600Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS326NPVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRSNT038JHV0JNZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS325NLVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT727NBCV002MCEMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS324NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS323NBVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/9L3C8D3/CNCMK001410506/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS322NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKBUK00WBEZ1EVZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS321NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APUSVT028JKP4AWZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS320NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/83WNKL3/CNWSC0024B00HR/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS319NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.68FYVB4.CNCMC0056I0183.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS318NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMREH0KCYKQE95Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS317NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AS102NBCX0058NSMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS316NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/1M29152/CN7220051S00YR/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS315NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMMG5S00001125188P011TZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS314NLBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHWHN00WBDF5N8Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS313NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/7VQSND3/              /Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS312NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APTQQCF5MYKEYK6Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS311NLHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR625NBCV00R7S7MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS310NUBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                        Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF3NJRM9Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS309NBVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR310NBCV006CVEMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS308NLVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGRVD0ACY83174Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS307NSVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2G8AS3Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APEWKU0H0Z443WGZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS306NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/7WYDYN2/CNWSC00883007D/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS305NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AN622NRCX001ZR7MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS303NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/FSJXW64/CNCMC004BF12C1/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS302NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/F8DHMF2/CN7220068U03N4/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS301NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK088JJO68OZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS300NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/GPGYWF3/CNCMC0015V0368/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS299NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/DNBSF92/CNPE1000AB007T/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.H9MDZH2.CNWS20078O012K.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AS730PTCJ000SUJMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.6DDZL42.CNPE10087501VK.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/D5JC6P2/CNWSC00929000E/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFANB018J8J0G8Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.7JH6YH2.CNWS20083H00CG.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS298NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/8QMT8S2/CNCMK00915073F/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS297NABU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APPTGB048JHF02OZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ACS02629178Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS296NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "C0236CFD", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS295NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ASB48NBCX00BBU3MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS294NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AS521NBCX00B1UMMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS293NLBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.GGTZ302.CN1296642A05D9.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS292NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/DR2Z7Q2/CNPE10084701PR/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS291NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/H2DRRK3/CNCMC001BN1B23/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS290NBVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07C5221_N71E727775Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS289NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/GFJMYR3/CNCMC0028P03BB/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/G4VB0Q2/CNPE10083C13RM/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS288NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A.B97HN24.CNWS3004BG01A0.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2G6R1TZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS288NEBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/953XBZ2/CNFCW0097502A5/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS288NEBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2G6QZ4Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS287NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APEZYA1AWR9S042Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1TQCXCZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP26WRFDZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/5Q7BVD2/CN129636580190/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS286NEBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6NVQGP2/CNFCW0097V01N3/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS285NEVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APSGEB0A8JIQ04LZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JGZ0YCZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS284NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFUFR028J790MZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS283NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/45MSYN1/CN129611781F6E/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS282NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH078JIK614Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS281NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/G16Z0Z2/CNCMK0099T0A38/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS280NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRBZKF31WJVB63Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS279NLBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFTP018JG50EMZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS278NLBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ACB06650665Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS277NLBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AWB08344549Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS276NAVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/8V3VDS3/CNWSC0033I0R1C/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS275NBVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQWDFG2MYHVAA5Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS274NBVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/FH5JG53/CNWS20005D00KB/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS273NEVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APTXKN038JJO2K2Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS272NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/7TX82R2/TW320709BF011E/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFLAA00WBB21OVZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS271NEBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS270NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA5282CHRZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS269NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07E3011_O91E591265Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS268NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFKDP00WB371C0Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS267NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS266NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF2F2NQWZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS265NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/CB5KZT3/CNCMC002C6001B/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS264NUVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKEFBF21VEZGXZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS263NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/7J2M9T3/CNCMC002BI00F6/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS262NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2PMCJ8Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS261NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AM80-H9018400533Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS260NUBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A12222334455666Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS259NLHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AP200K694Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS258NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/9DWMSX1/CN7443154R01HV/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS257NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH028JFH4WDZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS256NBVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS255NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS254NEBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "9C03AE04", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS253NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A.G8LVK73.CNCMC000B9054E.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/93S1BT2/CNFCW008AV015E/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS252NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "14EDCBC7", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APJSCQ00WBELHO7Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFXPNE31V30BXKZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS251NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS250NEVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2B27H4Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS249NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/6NVQGP2/CNFCW0097V01N3/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/D7G7N63/CNCMC0009910FC/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS248NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A5573116100003Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGWRD048JAK4U2Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/1Z5GSQ2/CNCMK0088P0221/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS247NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AN936NBCX002ACFMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMBPN018JGF01MZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS246NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/H41Y604/CNWS20049B00RO/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKVYH048JFJBVZZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS245NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.CPB0FP2.CNCMC0085E006E.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS244NEVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK078JIHI5NZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1FNSEVZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS243NLBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQDQK00WB9433MZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS242NEVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APTEZT028JJN00EZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APCELA212C1GQNSZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS241NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2AFZW0Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFKCT00WB2422RZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS240NEVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/F1YYZP3/CNFCW0023H01SZ/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APLFTQ018JGA5LYZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS239NEBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS238NEVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2ZWQGRZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AR730NBCV012V0CMBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS237NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07E4410_O41B186170Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS236NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0D8JJW0GBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS235NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/FKYLPF2/CN129636BP17BE/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/6Y5MWT3/CNWS20038A00N9/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS234NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APTQPV028JKF0UBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/BCRN3C2/CN762066AC043J/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS233NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2BBP0EZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2BCDM7Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                        Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1RQEV9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/62JLHB3/CNCMC000CC029B/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1RPETMZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS232NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/DL4RZX2/CNCMC0098G02B5/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/JB4ZM24/CNCMC0043S014A/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS231NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2GLCCEZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS230NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/BZH2CM2/CNPE1007AU0MJG/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS229NEVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGDUE00WBAF0XPZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS228NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/2VJQ6P2/CNWSC0092L00NC/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS227NPVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APJLRL018JD10KJZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTMYR038JJL007Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2BB6YKZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS226NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A.15PLXP1.CN701660CIG235.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AQCCXKP22A93503059Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS225NBBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/9Z7D1B4/VNCMV00543092F/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS224NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07E4410_O21E376367Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS223NSVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF0G0RS7Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1SWFY2Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS222NEVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2DVX8CZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2DJFPYZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1NC53GZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS221NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK078JJ93PHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS220NPVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "D0396054", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "9AD708C1", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS219NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "0E3F6D7A", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS218NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF3VR03TZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS217NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS216NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGWJB00WBDS01CZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS215NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A07D9021_N71E788261Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1QVDSRZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS214NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "D21A816F", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS213NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.7YJX432.CN762064BK00AE.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS212NLBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "E292A51D", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS211NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APESRK0CCY9U4R8Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/BMD2YD2/CNWSC0071102RP/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS210NLBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS209NAVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/GMKMWL3/CNWSC0029B0OU7/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF1XDVQRZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS208NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK078JIHG2EZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS207NLBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPWSH028JH5C42Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS206NLVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHWKA00WBEQ1L8Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS205NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AH216731285Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/JW5RSQ2/CNCMK0088S026D/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AK916452799Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS204NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JIG01ZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS203NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AYD068V9RZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS202NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/5QV6YR3/CNCMC002930A8E/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS201NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/BW335R2/CNPE10084412X4/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS200NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK078JIHSJ0Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.93WS5Z2.CNCMC0098O009E.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.93WS5Z2.CNCMC0098O009E.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS199NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJHVE0A8JGL1RQZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS198NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/D0VB453/CNCMK0006S0668/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS197NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPXLF058JII1M4Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS196NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/2LRQSQ2/              /Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS195NAVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/B5MMWT3/CNWS20038G005C/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/BGMMWT3/CNWS20038H0005/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS194NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF2R62W3Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS193NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APPXLF048JH43HGZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1F31CQZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS192NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AL2HF85S0130Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2DJFNWZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP295MYRZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS191NAVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/3WX2YQ2/CNCMC0087V0082/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS190NLHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/DX82DT2/CNWSC0092N0066/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS189NPVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AJB16839100Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/GBPY6Z3/CNCMC0038O10FC/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS188NEBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6NVQGP2/CNFCW0097V01N3/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS187NEVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APJGGP00WBES09OZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH068JHDELWZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "BA43B1D2", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS186NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK048JHE6FBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS185NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0D8JJM2J1Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS184NUVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS183NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF0NUC3UZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS182NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/8VWZPM2/CNFCW007AE00Q9/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JIG07CZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0ED6181O7Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS181NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/8B1NHB2/CN7220065309Q6/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS180NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/FTVB5R3/CNCMC002950D38/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS179NSHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APETKD0ED6234N6Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS178NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/JV6CPC4/CNCMC005880860/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS177NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APFKCT00WBB805VZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFXPPI41W46HYGZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS176NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/7LGH382/CN722005BD024X/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS175NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AM625NBCV00M2TPMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS174NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/GX47343/MYNAPFC03PN1WF/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHWGL00WBDA4PDZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS173NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AM937NRCX00E7XCMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS172NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JHV1XKZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS171NAVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS170NABU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AR938NXCV004MNZMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AN623NBCX004VSLMBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS169NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0A8JID08IZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFPRH0A8J2715KZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0F8JJG0F8Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS168NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/BTXSCB4/CNWS20056C00OJ/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS167NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF43LAPDZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS165NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/2Q42KY3/CNCMC0034I028D/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS164NPVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/HRQRFD3/CNCMC0014D19B8/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANBAAP11004314D63C33400Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS163NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APQWDKC21WHR9QFZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGWHD00WBAV0OBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS162NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.14QYXM3.CNCMC0022A0E44.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS161NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AYX0AG6HNZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS160NSVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_MA1E683945Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AN311NBCV00KECEMBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS159NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6Z3CKR2/CNCMC0088E01AC/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS158NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLKRE048JGBDHJZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS157NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLKRE048JGB02BZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS156NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/6N2LPL2/TW320707C800D1/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/6ZCFPS3/CNWSC0028M0ZSZ/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS155NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGWKK00WBCM4ISZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS154NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/79PNZT3/CNCMC002BO0510/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS153NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR413NBCX0002FRMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS152NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLQRH0A8JG10EEZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS151NSVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1G6A62Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "60798984", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APUSVC018JLS1FBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS150NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "6CF4F576", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS149NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJWMNE4MYGBMFGZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS148NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFJDKE2MY16W1RZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS147NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJLRL018JEJ0GXZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS146NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF17NXGGZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS145NABU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP295TZ2Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS144NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ACS02541039Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/D3KZLJ2/CNWSC0077P0BO4/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS143NAHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJUVLF21VEBE93Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS142NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AL1HF71A01VJZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS141NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/4MJVKJ3/CNWSC001592PX3/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS140NSHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/D17ZKJ2/CNWSC0077L007H/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS139NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/25S6HB2/CN7220063J00Z2/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS138NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF0XTBV2Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTXKL028JJP2FRZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF0VDWL5Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS137NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/75XBVD2/TW3207068O0253/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0MCY704BLZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AC02519603YUG36DA4Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS136NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/G7B33G3/CNCMC00191060D/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS135NSVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APPXLF048JGM31HZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A170397282703055Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS134NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2AJ7W7Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS133NAVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6TD6B44/CNWSC0045V0YH7/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS132NSVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APHWGL00WBDX1M3Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKEFBF21VFACRGZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS131NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/HF96X64/CNCMC004B8066F/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH048JGN46EZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS130NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF2L646EZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF43S65MZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS129NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/B9RP1Q3/CNCMC0025A0035/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/6D0WYL2/CN129667AD0DA0/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS128NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMKHU4A0GG8BD1Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS127NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/61GMLC2/CN1296368300C5/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS126NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APG02Y4EYZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS125NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APGGFFD2WV66UFWZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/G34PMN2/CNPE10082J1I1F/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS124NEVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/94S52S2/CNWS20088I006R/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS123NPVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AK8G0038462Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/JZTQZT3/CNCMC002BM0855/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/8X2GB33/CNPEC0002G03LX/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS122NSHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1AAGXZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS121NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQSRRAAK9HGA5BZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS120NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMWXA028JGAN1EZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS119NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "0C335256", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.2JT8ZH2.CNWS20024U00BF.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/54W3Y54/CNWS20049H00AH/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS118NEVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1AARSNZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTXKN038JJP3XFZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS117NEBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/4FG0P04/CNCMC003BK084D/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS116NEBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APVCNT018JL2QT2Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS115NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AJPA310JNF5Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS114NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/60V25N3/CNCMC0022O0BD3/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS113NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK018JGE2JAZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS112NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMWXA028JGF1CNZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS111NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.JVTZVG3.CNWSC001BO0OET.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS110NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS109NPVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APEUDQ0JP1597DNZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.GDPMLR1.CN7016622H00XW.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFYTH0GCY81FJWZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS108NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMFRK018JG53GEZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS107NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFSV068JJK0NHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS106NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP26WHG6Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS105NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/G097N83/CNWSC000C11RVQ/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGDUD00WBAE0YCZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALID             Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS104NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/B7HVHK3/CNCMC001B80045/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS103NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APHJFCE51WBHLD1Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0LD65746ZZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS102NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/D3DRFD3/CNCMC0014E0643/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS101NLHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH048JH542LZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS100NEHG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JI6194Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APLKRN048JGN0NYZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS099NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF2MT8H1Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS098NSHG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A210281582900144Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AM728NBCV00L6YWMBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS097NAVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHZMH1ANNCB88DZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS096NABU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.CF56512.CN7620646C00Z7.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS095NSVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APHJFCE51WBHA1XZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "44B627F2", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS094NPHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF2SAXLAZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS093NSHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AN/AZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS092NPHG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ALB47PTCJ000X2MMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMA41NBCV00F0VVMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AR519NBCV0063C3MBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS091NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/6RG1HZ1/CN701633B705EA/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "9JTYB12", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/C0TCJY3/CNCMC0036M1302/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS090NPVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APURDV028JL40X9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHJELF51VBUUYYZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFXMBM21U63HAAZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS089NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AW2KS92N10VYZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS088NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK048JH2C7VZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK048JH5I7PZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFXNRN21U65V5VZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS087NAVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/D4THPH2/CN129637BI10B0/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS086NPHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ABTWW30300HS5Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS085NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APJKQB02QDD611IZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS084NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APLMUQE31UFA0NIZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGHWH00WBAE0Z6Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1RQSEGZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS084NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/G1L83F3/CNCMK0017E06AC/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/J5W2813/CNPE1009A70A2G/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS083NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ABTEN337002QAZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS082NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/5CXN6S3/CNCMK0028T0015/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS081NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/34DRR22/CN744314A906RE/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF4JLBQBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF2S8W5EZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2BCL0AZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS080NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ALB47PTCJ000R80MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS079NABU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP20ZE85Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS078NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKDWPC31UEMGN5Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS077NEVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKWLC038JFJ1SEZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS076NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP17GA7TZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS075NSHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1ZGAW7Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS074NUVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/HRBKG92/CNPE10017N00RI/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS073NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ASGH430TGN3Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS072NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALIDZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS071NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APKXMBE5WVG1JIAZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS070NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AN311NBCV00LVKMMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS069NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATC52NXCV005HARMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS068NPHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0A8JI201OZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS067NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A.43CB532.CN762064BQ00AH.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/574Z7F3/CNCMC0017G04A4/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS066NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AA10290004111130AZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS065NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ASC50NBCX0049J0MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS064NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APHKVR028JBG2JEZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_N71B400491Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS063NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ABTTC042000BVZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS062NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKEFBF21VF33EQZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS061NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT623PTCJ000A6CMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS060NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AUSH505L1DKZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS059NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APUPCC00WBLI0F5Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AYD04FTYPZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK048JH521SZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/CCVM1B3/CNWSC001740W8Y/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS058NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "1046E70B", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS057NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBR068JJV2ISZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS056NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ACB25380528Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS055NEVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                        Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0ACY9E3I7Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0ACY9G5BPZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JHH2N3Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APETKD0JCY521MYZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/BYCKV52/CN7016356N02Q5/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS055NEVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/FXHXGB2/CN70163639023N/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                        Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP24YDVBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS054NEVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "92062BF9", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS053NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/7GZM863/CNWSC000BB0181/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF1NVAPZZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS052NABU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGUTD0A8JCTEVSZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS051NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH028JF4QGVZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS050NLHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AC07620600UWG3NCDDZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS049NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APUNUH0E8JKW0WMZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS048NSHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1W2X9RZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS047NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/9PK2ZZ2/CNWSC0006H00B7/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS046NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFRGV0A8J551R5Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS045NEHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/9TY7MJ2/CNWSC0077U00CE/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS044NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFUFR018JA703FZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS043NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APEPYLD2WV7IBQ6Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS042NPVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF2AR1Z4Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS041NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/C6M5V34/CNCMC0045A09B1/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS040NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "9A842EA2", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS039NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A038MU52B11AM8001C310388Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS038NPHG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ASGH615QHMFZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AL832NBCX00311SMBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS037NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/7H5J9X2/CNWS200958010W/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7H9P9X2/CNWS2009580002/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS036NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1RD72QZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS035NEBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/33HZG53/TW3207007A00F1/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/CJ2PY12/CN7220045P003H/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS034NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS033NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLEHV038JGA9QCZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS032NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/JGD2P63/CNCMC0009N0784/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS031NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/FGDTJH2/CNFCW00738006J/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS030NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/C03HX32/CN1296678J021D/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS029NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/7RLK1Q3/CNCMC0025C2232/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS028NEHG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APFYTH0KCYAJUIXZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/9VVMWN2/CNWSC0087G02M4/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA4330QCSZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS027NPVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK048JH3E7JZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS026NSVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/889MNJ2/CNWSC0078G064N/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS025NPHG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APESRK0PCY933D6Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFKCQ00WBA122WZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS024NEVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFSV058JJB1FAZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS023NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF3LRM97Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS022NPHG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APGWJB00WBC01G1Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF1K8D6EZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS021NPVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APQEDU0A8JHG0DNZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANBADD11007136A6ED93400Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQEDU0A8JHG0DNZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS020NPBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.JJ044Y1.CN7016334M05VF.           Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS019NLHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLSWBB31WG0YC1Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS018NEHG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ARC48PFWT0003R0MBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALIDZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1G67XXZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS017NLBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLKRE048JGBDHJZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS016NPHG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APRCSU0E8JKX38NZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRCSU0E8JKX38WZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRCSU0E8JKX2PNZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS015NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLFDL028JHG5BFZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS014NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1E98UYZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/G39S082/CN7220058K027W/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS013NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR90VMVBJZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS012NPHG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0D8JJM0YGZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3SM98F3/CNCMC0017F1A5A/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS011NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APEUEL0CWB1402QZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS010NPBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/9GMQQM2/CNWS2007BH01XP/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AR3008B6AZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS009NSVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                        Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF24J97FZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2A80RDZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHQERB31WCNVPFZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS008NSHG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/2XTMXN2/CNWSC0088Q00PL/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS007NPVS", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHWGH00WBCJ2CTZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS006NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APGZAL0A8JAX0TRZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS005NSBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGDSE00WBB5018Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS004NSBU", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF1NVAPZZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7GZM863/CNWSC000BB0181/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS003NLBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFEHFF21U9OX42Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS002NLBU", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AVS00337038Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VS001NAVS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/1600MX3/CNWSC003AL00E6/Z", false) != 0) && Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "VS", false) == 0)
		{
			MsRegSoft = false;
		}
	}

	private void Vikas()
	{
		//IL_5dcc: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "VK", false) == 0 && Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) != 0)
		{
			Vikas_Amc();
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK324NBDS", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH068JHH6W8Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK323NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APMREH0CCYHJ42ZZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMREH0BCYH944LZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/4BC0BC3/CNCMK0015QA69A/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK322NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF4SSN5RZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK321NEPH", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2ZWR90Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                        Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/4W4VN24/CNFCW004B800JN/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMWXA018JG467IZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/J3YDZT3/CNFCW0028P01EJ/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK320NAPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/H55NSX1/CN7443152C000A/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK319NEPH", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APLMUQE31UFACNUZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK318NAPH", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK317NAPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK316NADS", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/DCK5524/CNCMC0042J078A/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK315NEVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0ECY208PFZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK314NBPJ", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A.CFNV982.CN7620662B02DY.Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK313NUST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AL2HF79V00S7Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK312NUST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF5NWQVMZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK311NBVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APUSVC018JLCEAKZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK310NBSS", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF3K8GE3Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK309NAPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2ZD7WFZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK308NUST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APSJHBAAK9HUAIWZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK307NBDS", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/4JF1ML3/CNWSC002550JEH/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK306NAVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/FZL0SR3/CNFCW0027P03UF/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK305NUST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APRCSR0E8JLC0B6Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK304NLDS", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JI34T3Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK303NUST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APMREH0KCYKR2BZZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK302NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APW02PA2BZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK301NAST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APW051782Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK300NUST", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APMFRP028JG01NBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMFRP028JG01PSZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK299NSPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/4KSM893/CNCMA000C7040A/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK298NLVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA41324G5Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1MKNC6Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK297NEPH", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APF3XRKPRZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF4LJHWHZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK296NBDS", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A07E0530_P61E166671Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK295NUPJ", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/HWWRXT3/CNFCW0028F02M8/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK294NBDS", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AT623NBCV000JJCMBZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK293NLPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK292NBPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0MCY663CRZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK291NPDS", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APUSVT028JKP3Q5Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK290NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/G2KX654/CNCMC0049D0081/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/3BJ4V34/CNCMC0045A0413/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/9MXSCB4/CNWS20056C00RE/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/CTQGKC4/CNWS20058801BD/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/CSQVCB4/CNWS20058800C5/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK288NAVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AAUD4200G0SZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK287NPVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APUYZB028JLC37XZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHQERB3WVBXTUWZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK286NUST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JIJ0J2Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK285NSVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/7W28P24/CNWS20052C03F0/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/92CDCB4/CNWSC0055F17RP/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK284NUST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF58VNHMZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK283NSDS", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ACB14289544Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK282NAST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APJJCNH2WVESFCJZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK281NAST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo2, "582AB7D9", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK279NUST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APJUVKG2WVEMXVKZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK278NBPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/99RSPN2/CN1296384F012E/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK277NBPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF1BYP4WZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK276NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK275NUST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF2N0DPZZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK274NPPH", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/30ZL654/CNCMC0051Q04CD/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK273NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK272NAST", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "ANBADD1100730481BE63400Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGWXH0B0GB9BF0Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK271NSPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AS521NBCV00RF0LMBZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK270NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/J2HHMR2/CNFCW0088203SU/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK269NPPJ", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK268NUST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APW0BH7N2Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK267NEPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF1FKHXZZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK266NUPJ", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APJGGP00WBEC5RBZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK265NUST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APQZHQ098JJD0VPZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK264NBPJ", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF1JUV4QZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK263NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ACoffelakeZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, " ACoffelakeZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A07E4410_P81F028416Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK262NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AT207NXCV0020XAMBZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK261NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/J41JNJ2/CNWSC00776007V/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK260NUST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF3J0JH8Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK259NBVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APRSPA078JJI0DAZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK258NBPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK257NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APUUMU1AK9KQB9UZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK256NBDS", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_P31E110234Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK255NEVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A00000000Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK254NUST", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APTQRAJ3MYKTC1VZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK253NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/CYJ5514/CNCMC0045C083F/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AL729NBCX005ZA0MBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7QC7754/CNCMC0049H090B/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK252NUST", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2DTCA4Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2DTCA4Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/CWTH9V2/CNWS2008CA00WK/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK250NEPH", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/1DSQK13/CNCMK0001S0062/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/CR05NM3/CNWS20036E00L8/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK249NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APUGJA038JK1220Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK248NUPJ", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ANot ApplicableZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK247NLPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH078JIFTKAZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK246NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF1NZ256Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK245NSPH", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AA781620100KM016AZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AJPH6201S14Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK244NSPH", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APF4Y7X0YZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/76YDX93/CNWSC0015417XI/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK243NSPH", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AYD067H41Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3WLTN93/CNWSC001290P32/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK242NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ADBSZ0110015310131530B1Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK241NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK240NBVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APESRK0KCY651HWZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK239NEVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APDXVV00WB8C0GUZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK238NUVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ANBKWZ11001416019414560Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK237NUVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF57SKXRZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK236NEVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/CS9WXF3/CNCMC0017B0A52/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK235NPPH", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APRSQC038JJ91EHZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/2CGS373/CNCMK000A50006/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK234NBDS", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK233NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AP39N9018JB4087Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK232NUDS", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/6127W52/CN1296358JGKUY/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK231NLDS", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF4GP01YZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK230NBVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APGGFFD2MY652PAZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK229NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AS937NBQC0006A1MBZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK228NPPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF4KJE78Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK227NUDS", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/DL84J93/CNCMC000C10A41/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK226NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JHA2OSZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK225NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A00000000Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK224NUVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A.9SSL654.CNCMC0048S0D2E.Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK223NLPJ", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_P61E093072Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK222NAPH", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGTXL0JCYC94GGZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK221NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK219NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APJHUQ0A8JEK7V4Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK218NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APHJMF0TCYBB1V0Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK217NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "ACZC31439BWZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTXKP038JK80RLZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK216NBPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2B0XP8Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK215NBPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AWB07663561Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK214NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo2, "E62B21BD", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APJSCQ00WBFFNAYZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK213NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APGZAL0A8JAWBEEZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK212NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK211NLPJ", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF4GHMXQZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK210NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AL1HF91H0244Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK209NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2AR53MZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/1T44G92/CNPE10014U0080/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/2VXSCB4/CNWS20056C00IH/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APG04K73HZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK208NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APHKVEB21WAS2VSZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK207NBVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APLFDL058JJI49XZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK206NBPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APFYTE0GCYA3646Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK205NPPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AL2HF81R02ZKZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK204NEVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2BC9DKZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK203NBSD", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APQMFQ0A8JH504KZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1FURYPZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK202NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A.HQZR6BS.CN7016608QG1WH.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2DH886Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AL2HF1B803KTZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2AS8TVZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/13XQ353/CNCMK0013I00CC/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK201NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APFYTH0WCYC84QTZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK200NSPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK199NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APLFSU038JILBQDZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK198NBPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/9JK2C33/CNCMC0003A0488/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK197NSVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0E8JJA49TZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK078JIH6UKZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANB-1234567890Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK196NLPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK078JIG8KPZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK195NEPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APMREH0FCYIM2L6Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK194NEVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APHZMP1AHCCE10TZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK193NLSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK192NBVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APHWGL00WBDP1R0Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK191NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo2, "2C3F85EB", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AR90XALL4Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APJSUK0A8JGB0X1Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7QYKC24/CNCMC0042O0582/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/D0SXYL3/CNCMC0018715CB/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK190NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A07E0522_N81E676064Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK189NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/95J5672S2/CNWS20089F00PS/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK188NESD", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AC1KS83V017YZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                        Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2Z4N21Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2AJ7X6Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/5Y15NZ3/CNFCW0038H0BOL/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                        Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK187NBSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/JKT3SF2/CN1296371601C1/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK186NSSD", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/DKD7F72/CN129635CA01EA/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK185NBVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APLFTQ018JGK39WZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK184NLSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF0WUTVMZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK183NEPH", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JIF0Z1Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0ACY9F1XJZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHWGH00WBDG5ZRZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF28WYY8Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK182NSPJ", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/4W47JB2/CN7220064P02LF/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/2W2SM24/CNWS20047101OL/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK181NSPH", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APJJBLD3NMFOOADZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK180NLSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APETKD0KCY73FUFZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK179NAVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA5321CYGZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF2ALND8Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK178NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFZJF018J234BUZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/2C06NQ2/CNCMK008AD0093/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/88BVQF2/CN129636CF023F/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGUTD0A8JAS1J1Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APLEGU018JFJ0GPZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.5JH13X1.CN1296637Q0334.Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK177NESD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/15808F3/CNCMC0017F1C4F/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK176NESD", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALID             Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGWHT00WBCF95UZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A240131409100178Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALID             Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A07E4410_P51E755993Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK175NBSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF49EHW6Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK174NSVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1LEJRKZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2AJC2VZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK173NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/C5SK2Z2/CNCMK009980221/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK172NBVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/1W15NM3/CNWS20036H00TV/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK171NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0D8JJI09FZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0D8JJI0T4Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AYX083ZPMZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK170NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK169NPVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AR935NBCV000NFXMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF0TNLQDZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK168NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/C6M3HZ2/CNPE10098V020G/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/CY0QD43/CNFCW0005400MD/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AA75755211621847AZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/BQZ78G3/CNCMK0018J0030/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK167NESD", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AM833NBCV00KKYVMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANoneZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK166NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0D8JJB1AQZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0D8JJG02AZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0D8JJG02TZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRCST0D8JJG060Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK165NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP15LE9DZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKVYH038JFH0ISZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JIF31LZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMFBD058JI31V8Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK164NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/4WRR7H2/CN1296376U15FE/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1FYTB9Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK163NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APQWDLG4WVJ093RZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH028JF3OJSZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3T3YQ13/CNFCW009CE01C8/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK162NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APESRK0CCY9U3NPZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2K4ERVZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/DN1PR22/CN7220049B03RE/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK160NLSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AR104NBCV00K34WMBZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK159NLSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/5H71Z93/CNWSC0013B0H5R/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK158NPSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APETKD0LCY779DUZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK157NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1TTEHBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF444JKZZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK156NLSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK155NBVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF3S095YZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK154NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/FQWNJZ3/CNCMC0039F1A56/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK153NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH078JHV29RZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK152NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APRWVA0A8JI30Q1Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK151NBSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AM80-G7008001780Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK150NBSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AP901L8ZPZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK149NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APRCWT0ACYHX1RWZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRCWT0ACYHW2HGZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRCWT0BCYI260XZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK148NBVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/6LWKZ23/CNWS20001D00D7/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK147NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AC02819400AGH69FATZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK146NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APHDBE00WBCC023Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AC077086066XGTQMF2Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APJSUK0A8JHY02PZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK145NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK144NPSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AMP270RHFZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK143NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2DVZWRZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/CW8NGL2/CNPE1007930Q6U/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AN102NBCX006834MBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.JB1DLD2.CN4864369L01LJ.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/C8MJDL3/CNWSC002260SP3/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1AMZ3HZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/HRS4233/CNFCW009AV03Z5/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7R0G833/CNFCW009AV0331/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/HM0BD33/CNFCW009BJ00NT/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/9SS4233/CNFCW009AV02OX/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/2K2VHW2/CNWSC009CC00NZ/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/FK2VHW2/CNWSC009CC00OA/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/6J2VHW2/CNWSC009CC00NN/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/DJ2VHW2/CNWSC009CC00NT/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRCWT0GCYJ2JX3Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/5R03Q13/CNCMK0002C0226/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/H0LH8S2/CNCMK008CU02CE/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK141NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0CCY9N0H4Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK140NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/FPP9VC3/CNCMC00132039D/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK139NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ALSWBB31WG0S3AZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK138NPSD", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/HHSZTT2/CNCMK00924018A/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP24WLMKZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK137NEVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APJHUQ0A8JEK7NIZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK136NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/C6H51Z2/              /Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK135NSVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFXNRN21U65V5VZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A07D2212_LA1E306038Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK134NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo2, "5AD3BDD6", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JHA0J5Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHQERB31WB7H3UZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ASGH609PQRPZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A150442672900495Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF4EW9RDZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK133NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APF3ZR9F2Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/G8FF9V2/CNPE10089T01ZC/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK131NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APMREH0BCYH944LZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK130NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_M91D002126Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK129NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APJRRP00WBDY5A6Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK128NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APESRK0MCY781THZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AJPA540YDHNZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRQCA048JIT2YPZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK127NUSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF3RBXDKZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK126NPSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APRCSU0D8JJG0AGZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK125NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AMP17QCNPZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK124NLSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/2CNXP03/CNCMC009C80839/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK123NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APMFBD048JHJ0S5Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK122NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APUSVQ028JKYFFCZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK121NEVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALID             Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK120NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4624_P41E006809Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3XV9LP2/CNCMC0086B07D6/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK119NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH068JHDDXFZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK118NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APHRXHD41UBLX1DZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK117NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APKXMEG41VGFE73Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK116NBSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH058JGNCVVZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK115NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APJJGT0ACYDQ05BZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APETKD0DCY183ZCZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APCSGD012C2673AZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGHWK00WBCZ06MZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK114NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ANBMVM1100453407FCF7600Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK113NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APTNXCK4MYJNKTVZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APUUMV1BK9L5ADDZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTNXCK5MYKDE0XZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTNXCK41WJO24SZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFEGR0B0Z9V26KZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK112NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APHZZU00WBCR0JQZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK111NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APEHYCG21T7PCV3Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK110NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/FRQG5C2/CN762066BF00MN/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK109NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AMXL432366DZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0ECY1155KZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/34NXYL3/CNFCW001AO01WR/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK108NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APJHUQ0A8JEK7V4Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK107NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF32PG18Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK106NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APFUKU3A0G820Q7Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA5241DV7Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFLAA00WBBN3N0Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AJAY09324347315Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APUSVT028JKO03RZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK105NPVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/FXM8514/CNCMC0045E0AA2/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APENEU00WB9L2TAZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK104NAVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A1ZSUH42W4E1Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK103NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A123490EN400015Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/FQBKFT2/CNWSC009440036/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK102NSSD", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APLFDL018JGDH7AZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3HPWN53/CNCMK0007Q1B54/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK101NSVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APJRRP00WBEK158Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/6WH92G2/CN1296374808D0/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK100NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH078JIW5U9Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK099NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A.3NXR6BS.CN7016607EG1BS.Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK098NPSD", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APRSPB028JHV1W3Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/G7PC9F2/CN7443165P004N/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK097NPVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKVYH088JIK5LIZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK096NSSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APMPLF0A8JGM0J4Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK095NEVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/JMYL4N3/CNCMC0023302D9/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK094NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF3ZEHFDZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK093NAVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APJHWD0A8JF41SXZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMFC1CNNGUDGLZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK092NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF3G6L11Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK091NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APMPLF0A8JGM0K7Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK090NLSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APLKRE048JGB00DZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK089NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF0DEWG1Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK088NPSD", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2GAZE3Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/9GKB5Q2/CNCMK0086K01A0/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK087NASD", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/2PNFN63/CNCMC000970ABF/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AYN006FLFZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK086NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APKLJAJ21TFC9VSZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK085NPSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK084NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/2DSDXW3/CNCMC0032609C3/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK083NASD", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/J3PTZF2/CN1296373I01BC/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGATU0JNNAJLBXZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK082NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF0N1ZK0Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK081NSVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/FM378F3/CNCMC0014U04D1/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/H1FWR53/CNCMC0009S00EA/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK080NAVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/5FH5NK2/CNFCW00748009L/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AA83225720200836AZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGNEFN51WAW63XZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGRVD0CCYADCFZZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK079NPVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA3130FZNZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK078NPVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APKEFBF21VF3M0MZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK077NPVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0F8JJF0FEZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AN/AZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK076NESD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF1PFMVWZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK075NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AL1HF19R05M2Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK074NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APJHTH0A8JF42DGZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK073NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/HYWJMN2/CNPE10081D07BT/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK072NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AM80-DA024600100Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK071NPSD", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AL936PTCJ00025FMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1VQHMXZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK070NSVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/J98YL72/CN1296362O034F/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2G47GTZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A07E4410_O31E701355Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK069NPVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APF0PWCJKZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF4CA57DZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK068NBSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK067NPVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APF0P9SL6Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKWRPE31UFLMK5Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK065NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/83G84H2/CN1296376301A2/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/J97DNQ2/CNCMK0086S04F2/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APEUEL0CWB1344JZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP24YBL6Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK064NESD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APGZAN0A8JC74M6Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK063NESD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AC024252038VG36DARZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK061NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0F8JKN0AQZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK060NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ANoneZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK059NPVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/DJJYWF3/CNFCW0014T00OS/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/1BZ9KH3/CNFCW0016C001U/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH038JFJHDBZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK058NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APJHUU0A8JFE29HZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APSGEB0A8JIQ02TZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK057NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AM728NBLP000ZYLMBZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK056NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APF0ULVG7Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AL216133090Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHQERB31WBV0S5Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA5041V13Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK055NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/HNQZKQ1/CN7590017S01UA/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK054NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/1VNDSY1/CN129613A10025/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK053NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AR519NRCX003HVAMBZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK052NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/GVQT5S2/CNCMK008BQ00BF/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AYB06262248Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRCSR0D8JJG0S2Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP28DA18Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2A7967Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AL1HF98K0125Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AYX0G0KM6Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/JGW3X93/CNWSC0017105Y6/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/F6W3X93/CNWSC0017106TN/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK051NPVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/7HPNLF3/CNCMC0014T0307/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMLUP1A0GFJAFHZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APUSVQ028JKY02SZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK050NEVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A9633-6599-6036-9367-8253-4513-77Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK049NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APURFP018JKF1Q0Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK048NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AMMG5S00000550091P0080Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK047NEHR", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AL940NBLP0004NXMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGWJB00WBCQ1HMZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK046NEVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A.8PDHD02.CN1296641HGFHY.Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK044NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APCTXB028J3T6ONZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK043NPSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JGR3FBZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK042NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK041NSHR", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALID                         Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK040NPSD", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AWA0ZMC01ZU Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK039NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF0KYW9UZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK038NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA54521X2Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A07D2212_M41E043035Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK037NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ALR0D0RAPZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK036NPVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/46R9KF2/CN72200685014P/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APCWBB1B2G5B8EBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/HFMZBX1/CN7443132S098B/Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK035NLVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APGGFDD21U60RFBZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK034NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APGCHE018J685X3Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK033NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APF0LWJK1Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK032NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2BNJRBZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK030NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APRSPC0687KD0O4Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK029NEVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APHJFCE51WBHKYZZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK028NEVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APRSQC028JHS0BZZ", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK027NBVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/H8QR4P2/CNWSC0091101E2/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK026NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AWB06756941Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK025NEVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/6B29DL3/CNWSC002250C47/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK024NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1ANS99Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK022NPVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APF1PFYSMZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1QK6ZVZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK021NPVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2B9ZSEZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AN313NRCX00VEEYMBZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK020NPVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APCSGD012C2C9M4Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK019NEVK", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APESRK0PCY972FCZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APESRK0WCYAA1LEZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APLMUQF2MYFN55GZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK018NPSD", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "APPTGB028JGA4C6Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANoneZ", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK017NASD", false) == 0 && ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/GQFLWC3/CNCMC0009K09C3/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH068JH21CEZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK016NPVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "ABSN12345678901234567Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK015NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "A/3PTHSJ2/CNWSC007A100KG/Z", false) == 0) || (Operators.CompareString(DC_Main.SSRegSrNo, "VK014NSVK", false) == 0 && Operators.CompareString(DC_Main.SSCompSrNo1, "APGUJE0GMVCH5LDZ", false) == 0))
		{
			return;
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK014NSVK", false) == 0)
		{
			if (Operators.CompareString(DC_Main.SSCompSrNo1, "AL836NRCX00M3CTMBZ", false) == 0)
			{
				DC_Main.AmcEndDate = Conversions.ToDate("18/02/2022").AddDays(15.0);
				return;
			}
			if (DateTime.Compare(DateAndTime.Now, DC_Main.AmcEndDate) > 0)
			{
				Interaction.MsgBox((object)("Your Len Pc Period Is Over End Date = " + Conversions.ToString(DC_Main.AmcEndDate) + "...."), (MsgBoxStyle)0, (object)null);
				Application.Exit();
			}
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK013NSVK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGWRD068JBD55TZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VK012NSSD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ABSN12345678901234567Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VK011NSVK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBV058JKF325Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VK010NSSD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/F7XST43/CNCMC000750B80/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VK009NPVK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6JD0DX2/CNCMC0095V0146/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VK008NEVK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMB47NBCX00ZRC6MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VK007NLVK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A123490EN400015Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VK006NPVK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ACZK44M1002HZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VK004NSVK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/1MNTWB2/CN7620666804A1/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VK003NLVK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF0JDMSHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VK002NLVK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AN/AZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "VK001NLVK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/GDWRXV1/CN70163298005M/Z", false) != 0) && Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "VK", false) == 0)
		{
			MsRegSoft = false;
		}
	}

	private void Dhrupal()
	{
		if (Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "DH", false) == 0 && Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) != 0)
		{
			Dhrupal_Amc();
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "DH009NPDH", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ACB11223744Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DH008NSDH", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DH007NPDH", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AL730NBCV010E71MBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A123490EN400015Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DH006NPDH", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGNEPM31W90Z9GZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DH005NPDH", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ABQFL43900156Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DH004NPDH", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF38SMXKZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DH003NPDH", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF33KJNCZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.2H76832.CN7620652402BO.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DH001NPDH", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.19Q42Q3.CNCMC0024T0094.Z", false) != 0) && Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "DH", false) == 0)
		{
			MsRegSoft = false;
		}
	}

	private void Dipak()
	{
		if (Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "DD", false) == 0 && Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) != 0)
		{
			Dipak_Amc();
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "DD055NBDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD054NBDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/412D3X2/CNCMK009CS0F8C/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD053NBDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2ZREBLZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD052NBDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APLEHH038JGUMJIZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD051NBDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2ZN8LLZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD050NBDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD049NLDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF1RLWT8Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD048NBDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD047NSDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2G7G63Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD046NBDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF5GLXJ1Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD045NBDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFYTH0GCY8369ZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD044NBDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/G276754/CNCMC0051S050C/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD043NBDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APGWHT00WBC90A2Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD042NSDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJGGC0ACYCT16HZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD041NBDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD040NSDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_O31B418136Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD039NSDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A151261449402298Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD038NEDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A07D9921_O71B409581Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AR937NXCV003A0JMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A250353180000197Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD037NUDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF3YHAG4Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD036NUDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHZMN1A0GCG04GZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD035NLDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF5F9T3NZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD034NSDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APTXKL028JJP2I3Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD033NSDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/9WT39H2/CN12963785007C/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD032NBDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/DJD9M34/CNCMC0044T008E/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD031NBDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHBQT018JAL0CRZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD030NBDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF2TXQC4Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1KS52HZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD029NBDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2DKAAHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD028NSDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ALR0BVTNCZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD027NSDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AGERY63100AG9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKWRQB4WVG5A2WZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD026NSDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBR038JI618PZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD025NSDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AR90QJTQ9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2Z2MEFZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD024NSDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APFYSD0H0ZATAR5Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2ZBXXZZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AL1HF58X073JZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD023NPDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APTXKN038JJYEUPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD022NSDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APETKD0JE25666GZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRCSR0D8JJA0XUZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD021NEDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JHH1TPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD020NADD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APQMFQ0A8JGV07CZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/HBCM4G4/CNCMC005BB018B/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD019NSDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A.32SQXH2.CNWS20073O00H7.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_P31B613298Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD018NSDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/HVQDS32/CN1296356D00B0/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD017NSDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APG03FNMNZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/1GQGPH2/CN129637BJ0161/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD016NPDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMPLH0A8JGM4U1Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD015NSDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF2R7JH1Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF3M8L2MZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD014NSDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMFQ0A8JGV064Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD013NSDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP24PPYNZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD012NPDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APKWRRB41TG15X9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AVS80192220Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD011NSDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AYN0065DVZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD010NSDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ALA44PTCJ000WHXMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A1ZKCA1BF4JLZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD009NSDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AL1HF1AM00ZKZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD008NPDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A07D9022_O11E800051Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/JQKWLW2/CNWSC0002T0045/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APGHWH00WBAS0KPZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD007NSDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ASGH545TN9QZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD006NSDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJJBNH21WE6TXBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD005NLDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6461P04/CNCMC003BH1836/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD004NSDD", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/FMH35N3/CNCMC0022M0587/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ALXTVQ0C0630420105B2000Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD002NSDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1AAH5SZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DD001NSDD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMREH0DCYI15WRZ", false) != 0) && Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "DD", false) == 0)
		{
			MsRegSoft = false;
		}
	}

	private void Ajay()
	{
		if (Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "AK", false) == 0 && Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) != 0)
		{
			Ajay_Amc();
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "AK098NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AP90158LWZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK097NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF28GRHYZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK096NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF5WM90NZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK095NAAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/B1PN944/CNCMC0051T08F5/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2ZAD2ZZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK094NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/F5VSK72/CN129636980298/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK093NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APTSCCI31WKQYJWZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK092NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AYX0G3TZFZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK090NEAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/GMM44W3/CNCMC0033H04D2/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APJHTH0A8JFK2NJZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/39KWR24/CNWS2005C50050/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK089NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APVCNT018JL54Z0Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK088NPAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP23Y0PRZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK087NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBT028JK22CPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK086NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRSNT048JIG42SZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK085NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK084NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF5MKXKAZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK083NAAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/JHTWP24/CNCMC004980670/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK082NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ANot ApplicableZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK082NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ANot ApplicableZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK081NPAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK048JHD0CWZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK080NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBT028JJZ5DSZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK079NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH058JGRGPVZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK078NPAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/19XD8R3/CNCMC0027A119B/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK077NUAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH088JJWB5NZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK076NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APEBJK00WB8A4AQZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK075NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF5ASGXNZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK074NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APTHNU028JKE1EMZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK073NUAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/9VYNDW2/CNFCW0093U008U/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK072NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK071NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH038JFJJ0LZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK070NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.DX1M344.CNCMC0052E0C7C.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK069NEAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK068NEAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK067NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/G9D5Y64/VNCMV004990048/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK066NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBR018JK02SEZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK065NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07E4410_O91E029616Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK064NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A07E4410_O91E851915Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK063NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ARA41NRCX00270BMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK062NUAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A  Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK061NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AS730NBCV00SZW0MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK060NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ANBGDH110087131F5E57600Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK059NEAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/89CJS64/CNCMC004A80130/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK058NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/45XM7X1/CN12961318GERM/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK057NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF4WHCHJZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK056NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF4YY23GZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK055NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK078JJAAH7Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK054NUAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ALC50PTCJ000DH3MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK053NUAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JIB01SZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK052NSAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "F699C07F", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "2A25A0CA", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK051NEAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ABTCR33700HGAZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK050NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF551RAGZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK049NPAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK048NPAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/HPCTZL2/CNPE10077O06FA/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/J4WNZL2/CNPE10078702PW/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK047NPAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/3WF80V3/CNCMC002CH07DA/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK046NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK045NSAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "2C3F85EB", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF32X5ZNZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AL2HF7BN0KSSZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK044NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.HD87424.CNCMC004270622.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK043NSAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMC51NBCV0126F7MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK042NEAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AR302N494Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.5FLYQG2.CN7016368B01OO.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AR302N4FKZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AR302N4AXZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AK216227903Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AK916799841Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK041NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APG041ANSZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK040NSAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/DD1QN04/CNCMC003BL0412/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK039NPAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR312NBCV00MJSAMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK038NSAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF3YRZCLZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK037NPAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/BM4PJY3/CNCMC00348002A/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK036NEAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHWGH00WBEM1HJZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK036NEAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APHWGH00WBDX20QZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHWHN00WBDUTBRZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK035NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ANBKDE11009341B5E8E3400Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK034NPAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AW1KS9CS10RZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK033NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK032NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMMG5S00001125188P006JZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK031NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF4C59VFZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK030NPAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF3GBT1EZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK029NEAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APMWXA018JG52RHZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKXMBC31UEIPZZZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AGEFN242005SLZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APUSZQ018JLICX0Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK028NSAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AN/AZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK027NSAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK026NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMWXA028JGAJ1MZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK025NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1VQX5ZZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK024NSAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/6Z6D0H3/CNCMC001A71217/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.6FF1582.CN762065B601BZ.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK023NPAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/4QQLN63/CNCMC0008T0400/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/774JKH2/CNFCW0094200YK/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.4C5S754.CNCMC004890B40.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK022NSAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AFV9038200KFJ2V8F0Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATA40NBCV002J79MBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK021NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APDMAE018J5D0LHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK020NLAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKWLNF4MYG9I64Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK019NEAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/5RTZ5Q3/CNFCW0026O016K/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRBVDG21WHCHW0Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APTHPB058JJO00UZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK019NEAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/64XPXZ2/CNWSC0005R007Z/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK019NEAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/96R17S3/CNWSC002A81AZB/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK019NEAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRBVEG21WGVL1RZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK019NEAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ANBVPR11002147225587600Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK019NEAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/CFH7S14/VNWSV0043105RS/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK018NPAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AO5PF00Y6K0012DZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK017NSAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ASGH434RDYHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK016NPAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ANBQZ9110025302B02B7600Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK015NPAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AM625NBCX00MMMFMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK014NEAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "92E84430", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK013NEAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHF038JFG4RQZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2KAL2BZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK012NBAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/1ZSV5J3/CNCMK001BG0470/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK011NEAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APFJDKD21T9O0Z7Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JIJ37RZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHHSL1BK9B11ELZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK010NPAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AK916837270Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK009NPAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APFXNQJ31U354ODZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A.       .CNPE10003N02US.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A1ZLMC2CE2K6Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK008NPAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/2BFY924/CNWSC0039S0MWK/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7BFY924/CNWSC0044J01JG/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH058JGS6NRZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ASGH344RBNMZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK007NEAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A123490EN400015Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF5EPWP0Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "98D872D9", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK006NPAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK005NPAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AO5NG00Y2D003EMZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKVYE028JF3JKQZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK004NEAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APUVXDE31WKQVTXZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/5XMJDB3/CNCMK0012100B4/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMREH0HCYJM2DZZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK004NEAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/7SZ23G3/CNCMC001920421/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK003NPAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A.1XT1B12.CN7620649B05EU.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF2GV00RZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK002NPAK", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AM833NBCX00EJ20MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "AK001NAAK", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AYD081G1KZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AR911BSTVZ", false) == 0))) && Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "AK", false) == 0)
		{
			MsRegSoft = false;
		}
	}

	private void Devendra()
	{
		if (Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "DM", false) == 0 && Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) != 0)
		{
			Devendra_Amc();
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "DM129NUDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JHH3HRZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM128NUDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1AN06AZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM127NUDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APLEQB0A8JGC0W9Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APREZF0F8JLS0CCZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM126NBDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/8L9KZD2/CNWSC006CA00A2/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM125NPDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF5E0SMTZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM124NPDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JHA0MNZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM123NPDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APUSZQ018JL50MOZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM122NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT522NBCV00VSP6MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM121NEDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/5K3N573/CNCMK000A92413/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM120NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APVCNT018JL47EEZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AT418NBCX00ABU1MBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANot ApplicableZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ANot ApplicableZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM118NBRD", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/CHRNTN2/CNCMK0085M130F/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM117NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBT028JJZ2PNZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM116NSDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM115NBDG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APJHKR1A0GCM226Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/2PH3WP2/CNPE10084O0AU2/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM114NBDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM113NPDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMPLD0A8JGL1FCZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM112NBDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM111NSDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A160573412300855Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/DKG7B2S/CN73604183034R/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/DKG7B2S/CN73604183034R/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ABTWW30300FWZZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM110NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/18L5BK3/CNCMK001BS1167/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM109NSDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT833PTCJ000N0BMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM108NLDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT834NBCV00MWB3MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM107NUDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AS833NBQC0006RJMBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKWHH078JHSFUJZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM106NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM105NBDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6G7XZ53/              /Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM104NADM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AL2HF26A0303Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM103NBDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A00000000Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM102NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFYTH0TCYBP0IWZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM101NBDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AINA601WR5XZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AINA437SFHNZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM100NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFKZU00WBAR9NXZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM099NBDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRSPC058JI72ZYZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM098NLDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBR018JKE9HHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM097NBDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCH048JGY3B2Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM096NLDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJPKP028JE202XZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM095NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2LYBM7Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM094NPDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMGNLF21WFF7O0Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM093NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF0N5DJAZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM092NADG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AQCCXKE1PG84602330Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM091NSDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM090NSDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APFKZU00WB564FAZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APJRZQ00WBEX3MKZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM089NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APRCSU0E8JL43FDZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM087NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR626NRCX009362MBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM086NSDG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo2, "2C3F85EB", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AC02629300QJGVYVANZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBT028JK05DFZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM085NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APMFRK018JG51SYZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM084NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM083NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0HD632HBBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM082NBKX", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/F9VLZD3/CNCMK001720662/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM081NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPXLF048JHF0ZPZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM080NLDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APCELA212C19Q5FZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM079NADM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APJSAL00WBET0KNZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM078NEDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/CHRNTN2/CNCMK0085M130F/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM077NBDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AR90P324TZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM076NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APFUFP018JAP0VDZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM075NBDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/7JY47Y2/CNCMK0097G00AF/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/6GJBQV2/CNCMK0095A0215/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM074NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP19QDWSZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM073NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AAUD4170KJ5Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM072NUDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A123490EN400015Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM071NLDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF30YBXGZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM070NLDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/5NMB3B3/CNWSC0017K0KV5/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM069NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF3RVFXVZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM068NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APKXMAB5MYGR472Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM067NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM066NEDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/7X9GPH3/CNCMC0018O0663/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AMP24V4WXZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "2C3F85EB", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM065NPDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/31TQM24/CNFCW0043P00ER/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM064NEDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALID             Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/1DXRN04/CNCMC003BI02E5/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM063NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM062NLDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/DZLWM72/              /Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM061NSDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AJPH711YKCTZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA50413G2Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA3121P6ZZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM060NLDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/27L34H2/CN1296376202D1/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM059NSDG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0E8JJ82BOZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK088JJOBB9Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM058NUDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AT101NBQC0000RRMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM057NEDG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APKXMAC2MYHWXQAZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFYVB0G0ZAC7HXZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM056NADM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/6GJBQV2/CNCMK0095A0215/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/7JY47Y2/CNCMK0097G00AF/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM055NLDG", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF3R1MWAZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM054NSDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APESRK0FCY305LSZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM053NSDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APRQBR038JI39UIZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM052NEDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/61P3524/CNCMC0042F0066/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APMLUP1A0GFPDG6Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM051NLDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/BF584W3/CNCMC0033O05AD/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM050NPDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/D0H5063/CNCMK0009O0042/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM049NSDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/2XTMXN2/CNWSC0088Q00PL/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JHM0E5Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM048NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/3JPG5C2/              /Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM047NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AKC50NBCV00A39KMBZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM046NLDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6QHXCX2/CNCMC0095P0002/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM045NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APJHTH0A8JFI23RZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM044NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF4ETX3NZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM043NEDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/G3573F2/CNWSC0073C0201/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKPSF00WBFF075Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM043NEDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/4ZT98S2/CNCMK009140247/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/4RLWLW2/CNWSC0002T00I1/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APF5EWF5HZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/50B0MT2/              /Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APKWJE068JFE5YGZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM042NLDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM041NEDG", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/DKFJYM3/CNCMC0035K0096/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/BS02P24/CNWS2004BT02DO/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM040NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPXLF048JHA4G8Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM039NBDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM038NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AJPA414C5T6Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM037NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "86DDB8E5", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM036NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APF0DKQMSZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM035NPDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A2UA5232DVHZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM034NPDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM033NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM032NADM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/8813XT3/CNFCW0028F02K0/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/HGZSD82/CN7620664L003F/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM031NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHR0A8JHN0BIZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM030NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/C3PNZT3/CNCMC002BO0684/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM029NADM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JHH49TZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AN835NBCV00LRSNMBZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM028NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/6NXD7S3/CNWSC002BC0PIN/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM027NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2DVZZFZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM026NADM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APETKD0GCY45LNHZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM025NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AINVALID             Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM024NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo2, "38B50EF9", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM023NLDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/GQLQXY2/CNCMK009BB0337/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM022NEDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APF0VXPRWZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/9970BM3/CNWS2001CO017X/Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM021NLDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AWM17MC0169Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM020NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPXLF048JHH52DZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM019NEDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0ACY9H96CZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AR3002XFEZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APESZC0ACY9H96CZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APETKD0MCY7875LZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APETKD0ACY9L8MCZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APETKD0HCY51455Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHVQV058JC60YDZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM018NADM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/G2108F3/CNCMC0017C17D2/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM017NEDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AM726NBCV0004K8MBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APFKDP00WB9W181Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM016NPDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A140932621501477Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM015NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A/CD9NTW1/CN701632CH003R/Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM014NEDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "D402091C", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AVS81529474Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM013NEDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1ARLS4Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM012NEDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A/6JVKDF2/CNPE1001AR00LH/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ASGH404RNQPZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3TVG7S2/CNCMK008CK0FDC/Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo2, "3C9ADDC0", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM012NEDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AJPA613FV4KZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM011NEDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APQMHT0A8JHA2G9Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM010NADM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "A.6S3RXH2.CNWS20073R00CZ.Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM009NADM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APLUER0BCYF58T2Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APHVRD028JCA0Q3Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM008NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP2515YAZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM007NEDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "APESRK0CCY9X5OBZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "AC1KS868017FZ", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "A                    Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM006NADM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APPVCK038JGNGC1Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM005NSDM", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "ADefault stringZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM004NSDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "AMP1PNTN1Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "APUNUH0E8JLG20QZ", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM003NSKS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APESRK0KCY5922SZ", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM002NSDM", false) != 0 || !((Operators.CompareString(DC_Main.SSCompSrNo1, "A07D4822_NB1E520059Z", false) == 0) | (Operators.CompareString(DC_Main.SSCompSrNo1, "ATo be filled by O.E.M.Z", false) == 0))) && (Operators.CompareString(DC_Main.SSRegSrNo, "DM001NSKS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "AMP283YB3Z", false) != 0) && (Operators.CompareString(DC_Main.SSRegSrNo, "KS001NBKS", false) != 0 || Operators.CompareString(DC_Main.SSCompSrNo1, "APHHWC0JCYC80ZPZ", false) != 0) && Operators.CompareString(Strings.Mid(DC_Main.SSRegSrNo, 1, 2), "DM", false) == 0)
		{
			MsRegSoft = false;
		}
	}

	private void AmcFreeDayReset()
	{
		DC_Main.ExeQuteMc("DELETE FROM AC_MAST_SRNO WHERE CO_CODE = '01' AND LC_CODE = '00' AND AC_CODE = '00001' AND MAIN_USER = 'ABC' ");
	}

	private void Self_Amc()
	{
		// Refactored from giant if/else chain — 0 AMC serial numbers
		var amcDates = new System.Collections.Generic.Dictionary<string, string>
		{

		};

		if (!amcDates.TryGetValue(DC_Main.SSRegSrNo ?? "", out string amcDateStr))
		{
#if DEV_MODE
			return; // Unknown serial — allow in dev mode
#else
			DC_Main.MsSoftNoUse = "Y";
			return;
#endif
		}

		DC_Main.AmcEndDate = Microsoft.VisualBasic.CompilerServices.Conversions.ToDate(amcDateStr).AddDays(365.0);
		if ((DC_Main.MsAmcUnlockDay > 0) & (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) < 0))
			AmcFreeDayReset();
		if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) <= 0)
			return;
		Microsoft.VisualBasic.Interaction.MsgBox((object)("Your Amc Period is Over End Date = " + DC_Main.AmcEndDate.ToString() + "...."), (Microsoft.VisualBasic.MsgBoxStyle)0, (object)null);
		if (DC_Main.MsAmcUnlockDay > 0)
		{
			DC_Main.AmcEndDate = DC_Main.AmcEndDate.AddDays(DC_Main.MsAmcUnlockDay);
			if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) > 0)
				System.Windows.Forms.Application.Exit();
		}
		else
			DC_Main.MsSoftNoUse = "Y";
	}

	private void Kishor_Amc()
	{
		// Refactored from giant if/else chain — 73 AMC serial numbers
		var amcDates = new System.Collections.Generic.Dictionary<string, string>
		{
			{ "KJ078NPKJ", "30/05/2026" },
			{ "KJ077NBKR", "12/05/2026" },
			{ "KJ075NBKJ", "15/04/2026" },
			{ "KJ074NBKJ", "10/04/2026" },
			{ "KJ073NUKJ", "08/04/2026" },
			{ "KJ072NPKJ", "18/03/2026" },
			{ "KJ071NBKJ", "21/03/2026" },
			{ "KJ070NBKJ", "18/02/2026" },
			{ "KJ069NBKJ", "16/01/2026" },
			{ "KJ068NBKJ", "16/01/2026" },
			{ "KJ067NBKJ", "30/12/2025" },
			{ "KJ066NLKJ", "18/12/2025" },
			{ "KJ065NBKJ", "20/11/2025" },
			{ "KJ064NLKJ", "22/11/2025" },
			{ "KJ063NLKJ", "17/10/2025" },
			{ "KJ062NBKJ", "22/09/2025" },
			{ "KJ061NLKJ", "08/09/2025" },
			{ "KJ060NBKJ", "05/09/2025" },
			{ "KJ059NBKJ", "28/08/2025" },
			{ "KJ058NBKJ", "26/08/2025" },
			{ "KJ057NBKJ", "18/08/2025" },
			{ "KJ056NBKJ", "28/07/2025" },
			{ "KJ055NLKJ", "19/07/2025" },
			{ "KJ054NBKJ", "12/07/2025" },
			{ "KJ053NLKJ", "18/06/2025" },
			{ "KJ052NSKJ", "25/06/2025" },
			{ "KJ051NBKJ", "27/06/2025" },
			{ "KJ049NSKJ", "18/05/2026" },
			{ "KJ048NBKJ", "15/04/2026" },
			{ "KJ047NBKJ", "08/04/2026" },
			{ "KJ046NPKJ", "18/03/2026" },
			{ "KJ045NEKJ", "15/03/2026" },
			{ "KJ044NBKJ", "08/03/2026" },
			{ "KJ043NEKJ", "31/01/2026" },
			{ "KJ042NUKJ", "31/01/2026" },
			{ "KJ041NUKJ", "20/01/2026" },
			{ "KJ040NUKJ", "01/05/2026" },
			{ "KJ039NPKJ", "01/04/2026" },
			{ "KJ038NSKJ", "01/01/2026" },
			{ "KJ037NUKJ", "19/08/2025" },
			{ "KJ036NBKJ", "10/10/2025" },
			{ "KJ035NEKJ", "18/10/2025" },
			{ "KJ034NBKJ", "18/10/2025" },
			{ "KJ032NBKJ", "30/08/2025" },
			{ "KJ031NSKJ", "20/08/2024" },
			{ "KJ030NBKJ", "01/04/2026" },
			{ "KJ029NBKJ", "30/04/2026" },
			{ "KJ028NPKJ", "30/04/2026" },
			{ "KJ027NPKJ", "30/04/2026" },
			{ "KJ026NBKJ", "18/04/2026" },
			{ "KJ025NBKJ", "16/01/2024" },
			{ "KJ024NEKJ", "01/04/2026" },
			{ "KJ023NEKJ", "01/04/2026" },
			{ "KJ022NBKJ", "18/12/2025" },
			{ "KJ021NPKJ", "18/10/2025" },
			{ "KJ020NPKJ", "14/10/2025" },
			{ "KJ019NPKJ", "23/09/2023" },
			{ "KJ018NPKJ", "15/07/2023" },
			{ "KJ016NPKJ", "15/07/2025" },
			{ "KJ015NPKJ", "28/04/2026" },
			{ "KJ014NPKJ", "06/05/2026" },
			{ "KJ013NSKJ", "25/04/2026" },
			{ "KJ012NEKJ", "24/03/2026" },
			{ "KJ011NSKJ", "14/12/2025" },
			{ "KJ010NPKJ", "22/09/2023" },
			{ "KJ009NPKJ", "27/05/2026" },
			{ "KJ008NLKJ", "27/05/2026" },
			{ "KJ007NPKJ", "04/04/2026" },
			{ "KJ006NEKJ", "26/11/2025" },
			{ "KJ005NEKJ", "15/06/2025" },
			{ "KJ004NPKJ", "06/04/2026" },
			{ "KJ003NPKJ", "29/06/2025" },
			{ "KJ002NPKJ", "17/06/2020" }
		};

		if (!amcDates.TryGetValue(DC_Main.SSRegSrNo ?? "", out string amcDateStr))
		{
#if DEV_MODE
			return; // Unknown serial — allow in dev mode
#else
			DC_Main.MsSoftNoUse = "Y";
			return;
#endif
		}

		DC_Main.AmcEndDate = Microsoft.VisualBasic.CompilerServices.Conversions.ToDate(amcDateStr).AddDays(365.0);
		if ((DC_Main.MsAmcUnlockDay > 0) & (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) < 0))
			AmcFreeDayReset();
		if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) <= 0)
			return;
		Microsoft.VisualBasic.Interaction.MsgBox((object)("Your Amc Period is Over End Date = " + DC_Main.AmcEndDate.ToString() + "...."), (Microsoft.VisualBasic.MsgBoxStyle)0, (object)null);
		if (DC_Main.MsAmcUnlockDay > 0)
		{
			DC_Main.AmcEndDate = DC_Main.AmcEndDate.AddDays(DC_Main.MsAmcUnlockDay);
			if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) > 0)
				System.Windows.Forms.Application.Exit();
		}
		else
			DC_Main.MsSoftNoUse = "Y";
	}

	private void Hemal_Amc()
	{
		// Refactored from giant if/else chain — 763 AMC serial numbers
		var amcDates = new System.Collections.Generic.Dictionary<string, string>
		{
			{ "HM777NBKU", "02/06/2026" },
			{ "HM776NUKU", "02/06/2026" },
			{ "HM775NUKU", "02/06/2026" },
			{ "HM774NAKU", "02/06/2026" },
			{ "HM772NLSR", "19/05/2026" },
			{ "HM771NSKU", "30/04/2026" },
			{ "HM770NUHM", "08/05/2026" },
			{ "HM769NPPK", "08/05/2026" },
			{ "HM768NBHM", "30/04/2026" },
			{ "HM767NSHM", "30/04/2026" },
			{ "HM766NBKU", "23/04/2026" },
			{ "HM765NBKU", "21/04/2026" },
			{ "HM764NBSR", "18/04/2026" },
			{ "HM763NEKU", "18/04/2026" },
			{ "HM762NBHM", "10/04/2026" },
			{ "HM761NBHM", "07/04/2026" },
			{ "HM760NSHM", "06/04/2026" },
			{ "HM759NBKU", "06/04/2026" },
			{ "HM758NBHM", "28/03/2026" },
			{ "HM757NUHM", "28/03/2026" },
			{ "HM756NAPK", "28/03/2026" },
			{ "HM755NBHM", "26/03/2026" },
			{ "HM754NPPK", "25/03/2026" },
			{ "HM753NSPK", "18/03/2026" },
			{ "HM752NPPK", "18/03/2026" },
			{ "HM751NBKU", "17/03/2026" },
			{ "HM750NSKU", "27/02/2026" },
			{ "HM749NSKU", "28/02/2026" },
			{ "HM748NBSR", "05/03/2026" },
			{ "HM747NBHM", "05/03/2026" },
			{ "HM746NBKU", "26/02/2026" },
			{ "HM745NBKU", "25/02/2026" },
			{ "HM744NLPK", "26/02/2026" },
			{ "HM743NBHM", "23/02/2026" },
			{ "HM742NSKU", "23/02/2026" },
			{ "HM741NSSR", "19/02/2026" },
			{ "HM740NBKU", "17/02/2026" },
			{ "HM739NBSR", "17/02/2026" },
			{ "HM738NLHM", "11/02/2026" },
			{ "HM737NPPK", "04/02/2026" },
			{ "HM736NBPK", "04/02/2026" },
			{ "HM735NBKU", "31/01/2026" },
			{ "HM734NAKU", "27/01/2026" },
			{ "HM733NAPK", "21/01/2026" },
			{ "HM732NSKU", "22/12/2025" },
			{ "HM730NBKU", "19/01/2026" },
			{ "HM729NAKU", "08/01/2026" },
			{ "HM728NUKU", "07/01/2026" },
			{ "HM726NBKU", "30/12/2025" },
			{ "HM725NBKU", "30/12/2025" },
			{ "HM724NBHM", "30/12/2025" },
			{ "HM723NSPK", "30/12/2025" },
			{ "HM722NLKU", "27/12/2025" },
			{ "HM721NBKU", "08/06/2026" },
			{ "HM720NLKU", "26/12/2025" },
			{ "HM719NBHM", "25/12/2025" },
			{ "HM718NBPK", "24/12/2025" },
			{ "HM717NBPK", "19/12/2025" },
			{ "HM716NBHM", "19/12/2025" },
			{ "HM715NLPK", "14/12/2025" },
			{ "HM714NBPK", "14/12/2025" },
			{ "HM713NBSR", "10/12/2025" },
			{ "HM712NBHM", "06/04/2026" },
			{ "HM711NBPK", "27/11/2025" },
			{ "HM710NLKU", "13/11/2025" },
			{ "HM709NSPK", "13/11/2025" },
			{ "HM708NLKU", "31/10/2025" },
			{ "HM707NBKU", "31/10/2025" },
			{ "HM706NBKU", "31/10/2025" },
			{ "HM705NBKU", "31/10/2025" },
			{ "HM704NLSR", "31/10/2025" },
			{ "HM703NLPK", "28/10/2025" },
			{ "HM702NLPK", "28/10/2025" },
			{ "HM701NLPK", "28/10/2025" },
			{ "HM700NLPK", "27/10/2025" },
			{ "HM699NLPK", "27/10/2025" },
			{ "HM698NLPK", "27/10/2025" },
			{ "HM697NBKU", "27/10/2025" },
			{ "HM696NLKU", "17/10/2025" },
			{ "HM695NBKU", "16/10/2025" },
			{ "HM694NEKU", "14/10/2025" },
			{ "HM693NPPK", "07/10/2025" },
			{ "HM692NBKU", "03/10/2025" },
			{ "HM691NLPK", "30/09/2025" },
			{ "HM690NBPK", "01/10/2025" },
			{ "HM689NAPK", "01/10/2025" },
			{ "HM688NEHM", "26/09/2025" },
			{ "HM687NBHM", "23/09/2025" },
			{ "HM686NUHM", "23/09/2025" },
			{ "HM685NBPK", "22/09/2025" },
			{ "HM684NBKU", "22/09/2025" },
			{ "HM683NLHM", "22/09/2025" },
			{ "HM682NLPK", "19/09/2025" },
			{ "HM681NBPK", "19/09/2025" },
			{ "HM680NUPK", "19/09/2025" },
			{ "HM679NAPK", "19/09/2025" },
			{ "HM678NUKU", "11/09/2025" },
			{ "HM677NBKU", "04/09/2025" },
			{ "HM676NLKU", "01/09/2025" },
			{ "HM675NBKU", "31/08/2025" },
			{ "HM674NBHM", "26/08/2025" },
			{ "HM673NLPK", "22/08/2025" },
			{ "HM672NLPK", "22/08/2025" },
			{ "HM671NBPK", "21/08/2025" },
			{ "HM670NLKU", "18/08/2025" },
			{ "HM669NLKU", "15/08/2025" },
			{ "HM668NBHM", "11/08/2025" },
			{ "HM667NLPK", "11/08/2025" },
			{ "HM666NLPK", "11/08/2025" },
			{ "HM665NSPK", "11/08/2025" },
			{ "HM664NBKU", "08/08/2025" },
			{ "HM663NBKU", "03/08/2025" },
			{ "HM662NUKU", "22/07/2025" },
			{ "HM661NLBR", "14/07/2025" },
			{ "HM660NLKU", "12/07/2025" },
			{ "HM659NSKU", "12/07/2025" },
			{ "HM658NUHM", "09/07/2025" },
			{ "HM657NLPK", "02/07/2026" },
			{ "HM656NBSR", "28/06/2025" },
			{ "HM655NBSR", "26/06/2025" },
			{ "HM654NLKU", "22/06/2025" },
			{ "HM653NLPK", "21/06/2026" },
			{ "HM652NSKU", "20/06/2025" },
			{ "HM651NLKU", "20/06/2025" },
			{ "HM650NBKU", "19/06/2025" },
			{ "HM648NBKU", "19/06/2025" },
			{ "HM647NSPK", "20/04/2026" },
			{ "HM646NBPK", "15/06/2026" },
			{ "HM645NBPK", "14/06/2026" },
			{ "HM644NBSR", "12/06/2025" },
			{ "HM643NLHM", "09/06/2026" },
			{ "HM642NPHM", "09/06/2026" },
			{ "HM641NUKU", "02/06/2026" },
			{ "HM640NBKU", "27/05/2026" },
			{ "HM639NBSR", "27/05/2026" },
			{ "HM638NLSR", "01/06/2026" },
			{ "HM637NEHM", "23/05/2026" },
			{ "HM636NPHM", "31/03/2026" },
			{ "HM635NSPK", "24/04/2025" },
			{ "HM634NBKU", "23/04/2026" },
			{ "HM633NUHM", "19/04/2026" },
			{ "HM632NUHM", "18/04/2026" },
			{ "HM631NSKU", "12/04/2026" },
			{ "HM630NBSR", "12/04/2026" },
			{ "HM629NSKU", "11/04/2025" },
			{ "HM628NBKU", "18/03/2026" },
			{ "HM627NLKU", "09/04/2026" },
			{ "HM626NBHM", "09/04/2026" },
			{ "HM625NLKU", "09/04/2026" },
			{ "HM624NUPK", "22/03/2026" },
			{ "HM623NBPK", "07/03/2026" },
			{ "HM622NBPK", "29/03/2026" },
			{ "HM621NBHM", "05/04/2026" },
			{ "HM620NSKU", "05/04/2026" },
			{ "HM619NBHM", "04/04/2026" },
			{ "HM618NLPK", "08/03/2026" },
			{ "HM617NBKU", "31/03/2026" },
			{ "HM616NBPK", "29/03/2026" },
			{ "HM615NBSR", "29/03/2025" },
			{ "HM614NSKU", "27/03/2026" },
			{ "HM613NLKU", "27/03/2025" },
			{ "HM612NSKU", "27/03/2025" },
			{ "HM611NLHM", "26/03/2026" },
			{ "HM610NBSR", "22/03/2025" },
			{ "HM609NBSR", "22/03/2025" },
			{ "HM608NBSR", "20/03/2026" },
			{ "HM607NSPK", "21/08/2025" },
			{ "HM606NEKU", "17/03/2026" },
			{ "HM605NBHM", "12/03/2025" },
			{ "HM604NLKU", "04/03/2026" },
			{ "HM603NAHM", "19/02/2026" },
			{ "HM602NUHM", "10/02/2026" },
			{ "HM601NLPK", "06/02/2026" },
			{ "HM600NLPK", "04/02/2025" },
			{ "HM599NBHM", "07/02/2026" },
			{ "HM598NLHM", "07/03/2026" },
			{ "HM597NEPK", "11/02/2026" },
			{ "HM596NLKU", "30/01/2026" },
			{ "HM595NBHM", "06/02/2026" },
			{ "HM594NEKU", "04/02/2026" },
			{ "HM593NUPK", "31/01/2026" },
			{ "HM592NUPK", "31/01/2026" },
			{ "HM591NUPK", "31/01/2026" },
			{ "HM590NUPK", "31/01/2026" },
			{ "HM589NBPK", "31/01/2026" },
			{ "HM588NUKU", "27/03/2026" },
			{ "HM587NBPK", "26/01/2026" },
			{ "HM586NBHM", "26/01/2026" },
			{ "HM585NUHM", "01/04/2026" },
			{ "HM584NBPK", "23/01/2026" },
			{ "HM583NLHP", "23/01/2026" },
			{ "HM582NLHM", "21/01/2026" },
			{ "HM581NBHM", "21/01/2026" },
			{ "HM580NUPK", "20/01/2026" },
			{ "HM579NUPK", "09/01/2026" },
			{ "HM578NPHM", "09/01/2026" },
			{ "HM577NUHP", "09/01/2026" },
			{ "HM576NUHP", "09/01/2026" },
			{ "HM575NUKU", "08/01/2026" },
			{ "HM574NUHP", "02/01/2026" },
			{ "HM573NUPK", "02/01/2026" },
			{ "HM572NSKU", "02/01/2026" },
			{ "HM571NUHM", "02/01/2026" },
			{ "HM570NUKU", "02/01/2026" },
			{ "HM569NUSR", "31/12/2025" },
			{ "HM568NPSR", "31/12/2025" },
			{ "HM567NUPK", "31/12/2025" },
			{ "HM566NBHP", "31/12/2025" },
			{ "HM565NEHP", "30/01/2026" },
			{ "HM564NLHP", "31/12/2024" },
			{ "HM563NUPK", "31/12/2026" },
			{ "HM562NUHM", "26/12/2025" },
			{ "HM561NUHM", "26/12/2025" },
			{ "HM560NUPK", "14/12/2025" },
			{ "HM558NLPK", "21/12/2025" },
			{ "HM557NUKU", "19/12/2025" },
			{ "HM556NPHP", "11/12/2025" },
			{ "HM555NBHM", "09/12/2025" },
			{ "HM554NUKU", "08/12/2025" },
			{ "HM553NBHM", "04/12/2025" },
			{ "HM552NLPK", "04/12/2025" },
			{ "HM551NBKU", "03/12/2025" },
			{ "HM550NLHP", "29/11/2024" },
			{ "HM548NBHP", "26/11/2025" },
			{ "HM547NSHM", "08/04/2026" },
			{ "HM546NUKU", "22/11/2025" },
			{ "HM545NBKU", "25/11/2025" },
			{ "HM544NUKU", "21/11/2025" },
			{ "HM543NPHP", "20/11/2025" },
			{ "HM542NBHM", "11/11/2025" },
			{ "HM541NEHM", "31/10/2024" },
			{ "HM540NEPK", "31/10/2024" },
			{ "HM539NEHM", "31/10/2025" },
			{ "HM538NEKU", "31/10/2024" },
			{ "HM537NEKU", "31/10/2025" },
			{ "HM536NEKU", "31/10/2025" },
			{ "HM535NBKU", "10/12/2025" },
			{ "HM534NBKU", "07/12/2025" },
			{ "HM533NEKU", "01/04/2026" },
			{ "HM532NBKU", "31/10/2025" },
			{ "HM531NSHM", "28/10/2025" },
			{ "HM549NEHP", "28/10/2025" },
			{ "HM530NEHP", "24/10/2025" },
			{ "HM529NPHP", "23/10/2025" },
			{ "HM528NSKU", "18/10/2025" },
			{ "HM527NEHP", "18/10/2025" },
			{ "HM526NEHM", "15/10/2025" },
			{ "HM525NPHM", "15/10/2025" },
			{ "HM524NEPK", "14/10/2025" },
			{ "HM523NSKU", "14/10/2025" },
			{ "HM522NLHP", "11/10/2025" },
			{ "HM521NPPK", "10/10/2025" },
			{ "HM520NPPK", "10/10/2025" },
			{ "HM519NEKU", "07/10/2025" },
			{ "HM518NEHP", "05/10/2025" },
			{ "HM517NBKU", "30/09/2024" },
			{ "HM516NEKU", "27/09/2024" },
			{ "HM515NBHM", "25/09/2025" },
			{ "HM514NLHP", "21/08/2025" },
			{ "HM513NSHM", "10/09/2025" },
			{ "HM512NPKU", "10/09/2025" },
			{ "HM511NPKU", "10/09/2025" },
			{ "HM510NSKU", "10/09/2025" },
			{ "HM509NSKU", "10/09/2025" },
			{ "HM508NLKU", "07/09/2025" },
			{ "HM507NSKU", "05/09/2024" },
			{ "HM506NBHM", "28/08/2025" },
			{ "HM505NBPK", "25/07/2025" },
			{ "HM504NLKU", "30/07/2024" },
			{ "HM503NEPK", "31/10/2025" },
			{ "HM502NSKU", "19/07/2025" },
			{ "HM501NSHP", "19/07/2025" },
			{ "HM500NSPK", "17/07/2024" },
			{ "HM499NPHP", "15/07/2025" },
			{ "HM498NSHM", "13/07/2025" },
			{ "HM497NSHM", "13/07/2025" },
			{ "HM496NSPK", "10/07/2025" },
			{ "HM495NEKU", "10/07/2025" },
			{ "HM494NBKU", "10/07/2024" },
			{ "HM493NEKU", "30/11/2024" },
			{ "HM492NSKU", "09/07/2024" },
			{ "HM491NAPK", "23/07/2025" },
			{ "HM490NBHM", "08/07/2024" },
			{ "HM489NPHM", "06/07/2025" },
			{ "HM488NBHM", "06/07/2025" },
			{ "HM487NSPK", "03/07/2025" },
			{ "HM486NLHM", "01/07/2025" },
			{ "HM485NBPK", "01/07/2025" },
			{ "HM484NSKU", "26/06/2025" },
			{ "HM483NSKU", "25/06/2025" },
			{ "HM482NAPK", "24/06/2026" },
			{ "HM481NPHM", "18/06/2026" },
			{ "HM480NAKU", "01/01/2026" },
			{ "HM479NBKU", "05/06/2026" },
			{ "HM478NSKU", "04/06/2026" },
			{ "HM477NBPK", "27/05/2026" },
			{ "HM476NBPK", "23/05/2025" },
			{ "HM475NSHM", "24/05/2024" },
			{ "HM474NLHP", "24/05/2026" },
			{ "HM473NUPK", "07/05/2026" },
			{ "HM472NBPK", "02/05/2026" },
			{ "HM471NBHM", "01/05/2025" },
			{ "HM470NPHM", "30/04/2025" },
			{ "HM469NPHM", "01/05/2026" },
			{ "HM468NLHM", "30/04/2026" },
			{ "HM467NSPK", "30/04/2026" },
			{ "HM466NSKU", "26/04/2026" },
			{ "HM465NSHP", "24/04/2026" },
			{ "HM464NBPK", "24/04/2026" },
			{ "HM463NSPK", "19/04/2026" },
			{ "HM462NBHM", "19/04/2026" },
			{ "HM461NLHP", "13/04/2026" },
			{ "HM460NLKU", "13/04/2026" },
			{ "HM459NBHM", "12/04/2026" },
			{ "HM458NEKU", "11/04/2025" },
			{ "HM457NPKU", "10/04/2024" },
			{ "HM456NLPK", "06/04/2026" },
			{ "HM455NPHM", "04/04/2026" },
			{ "HM454NSHP", "30/03/2026" },
			{ "HM453NEHP", "15/03/2024" },
			{ "HM452NUHM", "14/11/2025" },
			{ "HM450NSHP", "30/03/2026" },
			{ "HM449NBHM", "30/03/2026" },
			{ "HM448NBKU", "30/03/2025" },
			{ "HM447NEKU", "26/03/2026" },
			{ "HM446NAPK", "26/03/2026" },
			{ "HM445NLHP", "20/03/2026" },
			{ "HM444NSHM", "04/04/2026" },
			{ "HM443NEKU", "06/06/2026" },
			{ "HM442NBHP", "10/03/2026" },
			{ "HM441NSKU", "28/02/2026" },
			{ "HM440NSKU", "27/03/2026" },
			{ "HM439NPKU", "09/03/2026" },
			{ "HM438NBKU", "08/03/2026" },
			{ "HM436NEHP", "28/02/2024" },
			{ "HM435NBKU", "12/07/2025" },
			{ "HM434NEHP", "14/02/2026" },
			{ "HM433NSKU", "16/04/2026" },
			{ "HM432NSHP", "04/02/2026" },
			{ "HM431NSHP", "03/02/2026" },
			{ "HM430NBHM", "29/01/2024" },
			{ "HM429NSKU", "20/01/2024" },
			{ "HM428NAKU", "12/07/2025" },
			{ "HM427NEHP", "09/01/2026" },
			{ "HM426NBKU", "31/12/2025" },
			{ "HM425NEKU", "31/03/2026" },
			{ "HM424NAKU", "29/12/2025" },
			{ "HM423NPKU", "28/12/2023" },
			{ "HM422NPHM", "27/12/2025" },
			{ "HM420NBHM", "18/12/2024" },
			{ "HM419NBKU", "18/12/2025" },
			{ "HM418NBHP", "14/12/2025" },
			{ "HM417NSHM", "09/07/2025" },
			{ "HM416NEPK", "15/12/2025" },
			{ "HM415NBKU", "15/12/2025" },
			{ "HM414NBKU", "13/12/2023" },
			{ "HM413NLKU", "11/12/2025" },
			{ "HM412NBKU", "11/12/2025" },
			{ "HM411NSKU", "07/12/2025" },
			{ "HM410NEKU", "29/11/2025" },
			{ "HM409NLKU", "25/11/2023" },
			{ "HM408NEKU", "30/11/2023" },
			{ "HM407NEKU", "30/11/2025" },
			{ "HM406NPPK", "26/09/2025" },
			{ "HM405NSKU", "17/10/2025" },
			{ "HM404NSHM", "23/11/2025" },
			{ "HM403NLHP", "21/05/2026" },
			{ "HM402NBHM", "25/01/2026" },
			{ "HM401NBHM", "04/11/2025" },
			{ "HM400NSHP", "29/10/2023" },
			{ "HM399NEHP", "26/10/2025" },
			{ "HM398NBHM", "26/10/2025" },
			{ "HM397NBHP", "24/10/2025" },
			{ "HM396NEHM", "25/10/2025" },
			{ "HM395NSPK", "26/09/2023" },
			{ "HM394NBHP", "20/03/2026" },
			{ "HM393NLHM", "26/09/2025" },
			{ "HM392NBHM", "19/09/2025" },
			{ "HM391NEKU", "19/11/2025" },
			{ "HM390NSHM", "04/09/2025" },
			{ "HM389NLKU", "11/09/2025" },
			{ "HM388NEPK", "09/10/2025" },
			{ "HM387NEPK", "30/12/2025" },
			{ "HM386NUHM", "18/03/2026" },
			{ "HM385NSHP", "27/08/2023" },
			{ "HM384NLKU", "24/08/2025" },
			{ "HM383NSKU", "23/08/2025" },
			{ "HM382NEKU", "23/08/2025" },
			{ "HM381NSHM", "16/05/2026" },
			{ "HM380NBHM", "21/08/2025" },
			{ "HM379NPHM", "14/08/2025" },
			{ "HM378NAPK", "12/08/2025" },
			{ "HM377NSHM", "09/08/2025" },
			{ "HM376NEHM", "01/08/2023" },
			{ "HM375NLKU", "29/07/2023" },
			{ "HM374NPKU", "29/07/2025" },
			{ "HM373NAHM", "01/08/2025" },
			{ "HM372NLHM", "24/07/2025" },
			{ "HM371NSHM", "20/07/2025" },
			{ "HM370NLKU", "16/12/2025" },
			{ "HM369NSHM", "17/07/2023" },
			{ "HM368NLHM", "15/07/2025" },
			{ "HM367NSHM", "15/07/2025" },
			{ "HM366NPPK", "15/07/2023" },
			{ "HM365NSPK", "15/07/2023" },
			{ "HM364NEKU", "21/04/2026" },
			{ "HM363NPKU", "15/07/2023" },
			{ "HM362NPKU", "15/07/2023" },
			{ "HM361NSKU", "15/07/2025" },
			{ "HM360NAPK", "12/08/2025" },
			{ "HM359NSKU", "27/07/2026" },
			{ "HM358NAKU", "12/07/2025" },
			{ "HM356NPKU", "11/12/2023" },
			{ "HM355NLKU", "15/07/2023" },
			{ "HM354NPKU", "10/03/2026" },
			{ "HM353NSKU", "05/09/2024" },
			{ "HM352NSKU", "15/07/2023" },
			{ "HM351NAKU", "30/03/2024" },
			{ "HM350NSKU", "01/02/2025" },
			{ "HM349NEPK", "15/07/2025" },
			{ "HM348NSHP", "12/07/2025" },
			{ "HM347NSKU", "12/07/2025" },
			{ "HM346NLKU", "11/07/2025" },
			{ "HM345NSKU", "11/07/2025" },
			{ "HM344NLKU", "10/07/2024" },
			{ "HM343NLKU", "09/07/2025" },
			{ "HM342NSPK", "04/07/2025" },
			{ "HM341NLKU", "29/06/2025" },
			{ "HM340NEKU", "27/06/2024" },
			{ "HM339NSKU", "24/06/2025" },
			{ "HM337NSHP", "01/06/2026" },
			{ "HM336NPHM", "02/06/2023" },
			{ "HM335NEKU", "18/10/2025" },
			{ "HM334NSKU", "23/03/2026" },
			{ "HM333NPHM", "27/05/2024" },
			{ "HM332NBHM", "11/05/2026" },
			{ "HM331NSHM", "15/05/2026" },
			{ "HM330NSKU", "08/03/2026" },
			{ "HM329NSHP", "04/04/2026" },
			{ "HM328NEKU", "31/10/2025" },
			{ "HM327NPKU", "30/04/2025" },
			{ "HM326NLKU", "26/04/2026" },
			{ "HM325NSKU", "26/04/2026" },
			{ "HM324NSKU", "25/04/2026" },
			{ "HM323NSKU", "25/04/2026" },
			{ "HM322NSKU", "25/04/2026" },
			{ "HM321NAHM", "22/04/2026" },
			{ "HM320NPPK", "19/04/2026" },
			{ "HM319NLKU", "19/04/2026" },
			{ "HM318NSKU", "17/04/2026" },
			{ "HM317NAHP", "17/04/2026" },
			{ "HM316NPPK", "17/04/2026" },
			{ "HM315NPKU", "17/04/2025" },
			{ "HM314NEKU", "31/10/2025" },
			{ "HM313NSKU", "19/10/2025" },
			{ "HM312NAPK", "19/08/2025" },
			{ "HM311NPHM", "08/04/2026" },
			{ "HM310NEPK", "07/04/2026" },
			{ "HM309NSKU", "07/04/2026" },
			{ "HM308NSHP", "05/04/2026" },
			{ "HM307NEKU", "05/04/2023" },
			{ "HM306NPHM", "11/09/2025" },
			{ "HM305NPKU", "03/04/2026" },
			{ "HM304NSKU", "03/04/2026" },
			{ "HM303NEKU", "01/04/2026" },
			{ "HM302NLKU", "30/03/2023" },
			{ "HM301NEKU", "30/03/2026" },
			{ "HM300NSKU", "22/03/2026" },
			{ "HM299NSKU", "22/03/2026" },
			{ "HM298NBKU", "15/10/2025" },
			{ "HM297NSPK", "15/07/2025" },
			{ "HM296NSKU", "18/03/2026" },
			{ "HM295NPKU", "11/03/2026" },
			{ "HM294NSKU", "04/03/2026" },
			{ "HM293NSKU", "28/02/2023" },
			{ "HM292NSKU", "21/02/2026" },
			{ "HM291NSHP", "24/01/2026" },
			{ "HM290NAPK", "20/04/2026" },
			{ "HM289NSPK", "31/01/2026" },
			{ "HM288NPPK", "18/06/2026" },
			{ "HM287NEKU", "31/10/2025" },
			{ "HM286NPKU", "24/01/2026" },
			{ "HM285NEKU", "16/01/2026" },
			{ "HM284NAKU", "02/05/2026" },
			{ "HM283NEKU", "09/01/2025" },
			{ "HM282NEKU", "15/04/2026" },
			{ "HM281NSKU", "06/01/2026" },
			{ "HM280NUKU", "28/07/2025" },
			{ "HM279NSKU", "04/01/2026" },
			{ "HM278NEKU", "31/10/2025" },
			{ "HM277NSHP", "31/12/2025" },
			{ "HM276NSHP", "31/12/2025" },
			{ "HM275NSHM", "02/01/2026" },
			{ "HM274NSHM", "02/01/2026" },
			{ "HM273NPKU", "02/01/2026" },
			{ "HM272NPPK", "31/03/2024" },
			{ "HM271NSKU", "31/12/2025" },
			{ "HM269NEHP", "29/12/2025" },
			{ "HM268NPHP", "27/12/2026" },
			{ "HM267NSHP", "27/12/2025" },
			{ "HM266NSKU", "26/12/2025" },
			{ "HM265NUHP", "28/03/2026" },
			{ "HM264NLKU", "20/12/2025" },
			{ "HM263NPPK", "26/12/2025" },
			{ "HM262NSPK", "19/12/2025" },
			{ "HM261NLKU", "11/04/2024" },
			{ "HM260NSPK", "17/12/2025" },
			{ "HM259NEPK", "01/10/2025" },
			{ "HM258NAHP", "31/12/2022" },
			{ "HM257NSPK", "08/12/2025" },
			{ "HM256NSHM", "10/12/2025" },
			{ "HM255NAPK", "09/12/2025" },
			{ "HM254NSPK", "06/12/2025" },
			{ "HM253NSHP", "23/01/2024" },
			{ "HM252NPHP", "28/11/2024" },
			{ "HM251NSHP", "30/11/2025" },
			{ "HM250NSPK", "29/11/2025" },
			{ "HM249NEHP", "27/11/2025" },
			{ "HM248NPPK", "06/11/2025" },
			{ "HM247NEPK", "15/01/2026" },
			{ "HM246NPHP", "15/11/2025" },
			{ "HM245NPHM", "15/11/2025" },
			{ "HM244NEKU", "20/02/2026" },
			{ "HM243NPKU", "14/11/2025" },
			{ "HM242NPHP", "04/11/2025" },
			{ "HM241NSHP", "16/10/2025" },
			{ "HM240NPPK", "27/09/2025" },
			{ "HM239NSPK", "26/09/2025" },
			{ "HM238NPHP", "07/04/2026" },
			{ "HM237NPKU", "07/10/2025" },
			{ "HM236NEHP", "04/10/2025" },
			{ "HM235NLKU", "02/10/2025" },
			{ "HM234NLKU", "21/09/2024" },
			{ "HM233NLKU", "19/09/2024" },
			{ "HM232NAHM", "31/03/2026" },
			{ "HM231NSHM", "24/08/2025" },
			{ "HM230NEKU", "24/04/2026" },
			{ "HM229NSHM", "15/08/2025" },
			{ "HM228NSHM", "13/08/2025" },
			{ "HM227NAHM", "10/08/2025" },
			{ "HM226NSPK", "10/08/2025" },
			{ "HM225NAPK", "05/05/2026" },
			{ "HM224NSPK", "07/07/2025" },
			{ "HM223NLKU", "10/08/2025" },
			{ "HM222NSKU", "04/01/2026" },
			{ "HM221NSKU", "08/06/2026" },
			{ "HM220NPHM", "07/06/2026" },
			{ "HM219NLKU", "04/06/2025" },
			{ "HM218NPKU", "31/05/2026" },
			{ "HM217NLKU", "26/05/2026" },
			{ "HM216NSHM", "23/05/2025" },
			{ "HM215NSHM", "06/08/2025" },
			{ "HM214NSKU", "21/06/2025" },
			{ "HM213NSHM", "30/04/2026" },
			{ "HM212NAPK", "11/12/2025" },
			{ "HM211NSHM", "08/04/2026" },
			{ "HM210NSKU", "28/04/2022" },
			{ "HM209NSHM", "27/04/2026" },
			{ "HM208NEPK", "24/04/2026" },
			{ "HM207NSHP", "18/04/2025" },
			{ "HM206NSHM", "13/04/2026" },
			{ "HM205NSHM", "13/04/2026" },
			{ "HM204NSHM", "13/04/2026" },
			{ "HM202NEKU", "08/07/2025" },
			{ "HM201NSHM", "13/05/2024" },
			{ "HM200NSKU", "05/04/2026" },
			{ "HM199NEPK", "30/03/2026" },
			{ "HM198NEPK", "01/10/2025" },
			{ "HM197NSHM", "28/03/2026" },
			{ "HM196NAKU", "05/05/2025" },
			{ "HM195NSKU", "28/03/2026" },
			{ "HM194NSKU", "25/03/2025" },
			{ "HM193NLKU", "25/04/2025" },
			{ "HM192NSKU", "16/03/2023" },
			{ "HM191NSKU", "15/03/2026" },
			{ "HM190NEKU", "01/01/2026" },
			{ "HM189NSKU", "01/03/2026" },
			{ "HM188NESR", "13/06/2025" },
			{ "HM187NPHM", "11/02/2026" },
			{ "HM186NPHM", "12/03/2026" },
			{ "HM185NPKU", "15/09/2025" },
			{ "HM184NSKU", "31/01/2026" },
			{ "HM183NPPK", "01/06/2026" },
			{ "HM182NSPK", "05/02/2026" },
			{ "HM181NSPK", "04/01/2026" },
			{ "HM180NPHP", "12/01/2026" },
			{ "HM179NBKU", "11/01/2026" },
			{ "HM178NEPK", "29/11/2025" },
			{ "HM177NPHM", "11/01/2026" },
			{ "HM176NEKU", "15/01/2026" },
			{ "HM175NAPK", "25/01/2026" },
			{ "HM174NLKU", "02/01/2026" },
			{ "HM173NPHP", "07/01/2022" },
			{ "HM172NPHP", "13/01/2026" },
			{ "HM171NSHM", "24/12/2025" },
			{ "HM170NSHP", "07/01/2026" },
			{ "HM169NSKU", "14/12/2025" },
			{ "HM168NPHM", "07/12/2025" },
			{ "HM167NAPK", "05/12/2025" },
			{ "HM166NSKU", "30/06/2022" },
			{ "HM165NSHM", "27/11/2025" },
			{ "HM164NPHM", "27/11/2025" },
			{ "HM163NSKU", "25/11/2025" },
			{ "HM162NPHM", "15/11/2025" },
			{ "HM161NSKU", "08/11/2025" },
			{ "HM160NPHP", "02/11/2025" },
			{ "HM159NPHM", "27/10/2025" },
			{ "HM158NSHM", "30/10/2021" },
			{ "HM157NPHM", "22/10/2025" },
			{ "HM156NSKU", "21/10/2025" },
			{ "HM155NPHP", "16/10/2023" },
			{ "HM154NLHM", "14/10/2022" },
			{ "HM153NSHP", "08/10/2025" },
			{ "HM152NPHM", "05/10/2025" },
			{ "HM151NEHP", "25/03/2026" },
			{ "HM150NLKU", "25/11/2025" },
			{ "HM149NSKU", "30/09/2021" },
			{ "HM148NPKU", "05/10/2021" },
			{ "HM147NEKU", "24/03/2026" },
			{ "HM146NSKU", "28/09/2025" },
			{ "HM145NSKU", "28/09/2025" },
			{ "HM144NPKU", "25/09/2025" },
			{ "HM143NLKU", "25/09/2021" },
			{ "HM142NSHM", "23/09/2025" },
			{ "HM141NSKU", "21/09/2025" },
			{ "HM140NEKU", "20/09/2025" },
			{ "HM139NSHM", "14/09/2025" },
			{ "HM138NSHP", "25/03/2023" },
			{ "HM137NSKU", "08/09/2021" },
			{ "HM136NPHM", "06/09/2025" },
			{ "HM135NEKU", "26/01/2026" },
			{ "HM134NSKU", "04/09/2025" },
			{ "HM133NSHP", "13/06/2023" },
			{ "HM132NSHP", "27/05/2023" },
			{ "HM131NEPK", "29/08/2025" },
			{ "HM130NLHM", "19/08/2025" },
			{ "HM129NSHM", "10/08/2022" },
			{ "HM128NSHM", "10/08/2025" },
			{ "HM127NPKU", "24/02/2026" },
			{ "HM126NSKU", "08/08/2025" },
			{ "HM125NSHM", "01/09/2025" },
			{ "HM124NEHM", "22/10/2025" },
			{ "HM123NSHP", "15/07/2025" },
			{ "HM122NEPK", "24/07/2025" },
			{ "HM121NSKU", "22/07/2025" },
			{ "HM120NSKU", "21/07/2025" },
			{ "HM119NLKU", "21/07/2025" },
			{ "HM118NSKU", "21/07/2025" },
			{ "HM117NSKU", "10/06/2025" },
			{ "HM116NSKU", "17/06/2025" },
			{ "HM115NPKU", "10/07/2025" },
			{ "HM114NPKU", "24/05/2026" },
			{ "HM113NPKU", "26/10/2025" },
			{ "HM112NLKU", "25/04/2025" },
			{ "HM111NPHM", "19/04/2025" },
			{ "HM110NSKU", "14/09/2025" },
			{ "HM109NSKU", "12/04/2026" },
			{ "HM108NPHM", "13/06/2022" },
			{ "HM107NPHM", "12/04/2026" },
			{ "HM106NPHM", "12/04/2026" },
			{ "HM105NPKU", "11/04/2026" },
			{ "HM104NPKU", "11/04/2026" },
			{ "HM103NSKU", "01/04/2021" },
			{ "HM102NPHM", "31/03/2025" },
			{ "HM101NSHM", "12/03/2021" },
			{ "HM100NPKU", "09/03/2021" },
			{ "HM099NSKU", "09/03/2026" },
			{ "HM098NPHM", "27/02/2026" },
			{ "HM097NSKU", "27/08/2025" },
			{ "HM096NSKU", "26/02/2024" },
			{ "HM095NSKU", "20/02/2026" },
			{ "HM094NEPK", "05/04/2026" },
			{ "HM093NSKU", "25/01/2026" },
			{ "HM092NSKU", "27/08/2021" },
			{ "HM091NEKU", "31/10/2025" },
			{ "HM090NPKU", "19/01/2026" },
			{ "HM089NPKU", "12/01/2026" },
			{ "HM088NSHM", "12/01/2022" },
			{ "HM087NSKU", "11/01/2026" },
			{ "HM086NPHP", "06/01/2026" },
			{ "HM085NSPK", "25/12/2025" },
			{ "HM084NSKU", "31/12/2025" },
			{ "HM083NSKU", "31/12/2025" },
			{ "HM082NSKU", "31/12/2025" },
			{ "HM081NSKU", "30/12/2025" },
			{ "HM080NSKU", "13/02/2024" },
			{ "HM079NPKU", "20/12/2025" },
			{ "HM078NEKU", "31/10/2025" },
			{ "HM077NSKU", "17/12/2025" },
			{ "HM076NPKU", "25/09/2025" },
			{ "HM075NSHP", "01/02/2025" },
			{ "HM074NSKU", "25/11/2025" },
			{ "HM073NPHM", "10/04/2026" },
			{ "HM072NSPK", "11/11/2025" },
			{ "HM071NPKU", "11/11/2025" },
			{ "HM070NEKU", "31/10/2025" },
			{ "HM069NPHP", "25/11/2025" },
			{ "HM068NSPK", "26/10/2025" },
			{ "HM067NPPK", "23/10/2025" },
			{ "HM066NEKU", "20/10/2025" },
			{ "HM065NEKU", "21/10/2025" },
			{ "HM064NLKU", "25/01/2023" },
			{ "HM063NEHP", "04/10/2025" },
			{ "HM062NSKU", "11/10/2025" },
			{ "HM061NPKU", "12/02/2022" },
			{ "HM060NUKU", "12/05/2026" },
			{ "HM059NBPK", "14/03/2026" },
			{ "HM058NPKU", "07/10/2025" },
			{ "HM057NEPK", "07/12/2025" },
			{ "HM056NSKU", "08/04/2026" },
			{ "HM055NPPK", "10/10/2025" },
			{ "HM054NPHP", "07/09/2025" },
			{ "HM053NPKU", "03/09/2020" },
			{ "HM052NPKU", "03/09/2020" },
			{ "HM051NSKU", "02/03/2023" },
			{ "HM050NPHM", "22/08/2025" },
			{ "HM049NPPK", "22/08/2025" },
			{ "HM048NSKU", "05/08/2025" },
			{ "HM047NEPK", "27/12/2025" },
			{ "HM046NPPK", "07/07/2025" },
			{ "HM045NSKU", "29/06/2025" },
			{ "HM044NPHM", "26/06/2022" },
			{ "HM043NSKU", "29/12/2025" },
			{ "HM042NSPK", "22/03/2026" },
			{ "HM041NSKU", "16/06/2025" },
			{ "HM040NPHP", "12/06/2025" },
			{ "HM039NEKU", "21/02/2026" },
			{ "HM038NSKU", "05/06/2026" },
			{ "HM037NEKU", "25/06/2023" },
			{ "HM036NAKU", "03/06/2026" },
			{ "HM035NPKU", "23/05/2026" },
			{ "HM034NPHM", "23/05/2026" },
			{ "HM033NEPK", "05/05/2026" },
			{ "HM032NPKU", "14/06/2024" },
			{ "HM031NSKU", "27/04/2025" },
			{ "HM030NPKU", "21/04/2026" },
			{ "HM029NSPK", "05/04/2025" },
			{ "HM028NPKU", "01/04/2020" },
			{ "HM027NPPK", "02/01/2026" },
			{ "HM026NSPK", "03/06/2026" },
			{ "HM025NSPK", "19/03/2020" },
			{ "HM024NPPK", "18/03/2020" },
			{ "HM023NPPK", "16/03/2026" },
			{ "HM022NSPK", "14/03/2026" },
			{ "HM021NEHM", "31/12/2024" },
			{ "HM020NSHM", "09/03/2026" },
			{ "HM019NPKU", "01/04/2020" },
			{ "HM018NSPK", "25/02/2024" },
			{ "HM017NSHM", "22/02/2026" },
			{ "HM016NPKU", "10/04/2023" },
			{ "HM015NPPK", "12/02/2021" },
			{ "HM014NSHM", "29/03/2026" },
			{ "HM012NPHP", "04/08/2025" },
			{ "HM011NSHP", "29/03/2026" },
			{ "HM010NPHM", "23/01/2021" },
			{ "HM009NPHM", "23/01/2020" },
			{ "HM008NSHP", "16/01/2026" },
			{ "HM007NSHM", "16/01/2026" },
			{ "HM006NPHP", "13/01/2026" },
			{ "HM005NLHM", "02/01/2022" },
			{ "HM004NLHM", "02/01/2021" },
			{ "HM003NPKU", "01/04/2026" },
			{ "HM002NLHP", "13/12/2022" }
		};

		if (!amcDates.TryGetValue(DC_Main.SSRegSrNo ?? "", out string amcDateStr))
		{
#if DEV_MODE
			return; // Unknown serial — allow in dev mode
#else
			DC_Main.MsSoftNoUse = "Y";
			return;
#endif
		}

		DC_Main.AmcEndDate = Microsoft.VisualBasic.CompilerServices.Conversions.ToDate(amcDateStr).AddDays(365.0);
		if ((DC_Main.MsAmcUnlockDay > 0) & (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) < 0))
			AmcFreeDayReset();
		if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) <= 0)
			return;
		Microsoft.VisualBasic.Interaction.MsgBox((object)("Your Amc Period is Over End Date = " + DC_Main.AmcEndDate.ToString() + "...."), (Microsoft.VisualBasic.MsgBoxStyle)0, (object)null);
		if (DC_Main.MsAmcUnlockDay > 0)
		{
			DC_Main.AmcEndDate = DC_Main.AmcEndDate.AddDays(DC_Main.MsAmcUnlockDay);
			if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) > 0)
				System.Windows.Forms.Application.Exit();
		}
		else
			DC_Main.MsSoftNoUse = "Y";
	}

	private void Vishal_Amc()
	{
		// Refactored from giant if/else chain — 365 AMC serial numbers
		var amcDates = new System.Collections.Generic.Dictionary<string, string>
		{
			{ "VS368NBVS", "10/06/2026" },
			{ "VS367NBBU", "27/05/2026" },
			{ "VS366NSBU", "26/05/2026" },
			{ "VS365NPVS", "13/05/2026" },
			{ "VS364NSVS", "12/05/2026" },
			{ "VS363NBVS", "21/04/2026" },
			{ "VS362NBBU", "18/04/2026" },
			{ "VS361NPVS", "13/04/2026" },
			{ "VS360NUVS", "04/04/2026" },
			{ "VS359NPBU", "03/04/2026" },
			{ "VS358NBBU", "03/04/2026" },
			{ "VS357NEBU", "01/04/2026" },
			{ "VS356NUBU", "27/03/2026" },
			{ "VS355NBVS", "26/03/2026" },
			{ "VS354NSBU", "26/03/2026" },
			{ "VS353NBBU", "26/03/2026" },
			{ "VS352NBBU", "26/03/2026" },
			{ "VS351NBVS", "26/03/2026" },
			{ "VS350NUVS", "25/03/2026" },
			{ "VS349NBBU", "24/03/2026" },
			{ "VS348NSVS", "20/03/2026" },
			{ "VS347NSVS", "19/03/2026" },
			{ "VS346NBVS", "18/03/2026" },
			{ "VS345NBBU", "18/03/2026" },
			{ "VS344NEBU", "06/03/2026" },
			{ "VS343NBBU", "06/03/2026" },
			{ "VS342NBBU", "06/03/2026" },
			{ "VS341NBBU", "25/02/2026" },
			{ "VS340NSVS", "18/02/2026" },
			{ "VS339NBBU", "16/02/2026" },
			{ "VS338NSBU", "01/02/2026" },
			{ "VS337NBVS", "30/01/2026" },
			{ "VS336NUBU", "18/01/2026" },
			{ "VS335NSBU", "13/01/2026" },
			{ "VS334NBBU", "09/01/2026" },
			{ "VS333NBVS", "01/01/2026" },
			{ "VS332NUBU", "26/12/2025" },
			{ "VS331NLBU", "26/12/2025" },
			{ "VS330NSBU", "16/12/2025" },
			{ "VS329NSVS", "12/12/2025" },
			{ "VS328NBVS", "05/12/2025" },
			{ "VS327NEVS", "24/11/2025" },
			{ "VS326NPVS", "13/11/2025" },
			{ "VS325NLVS", "13/11/2025" },
			{ "VS324NPBU", "15/10/2025" },
			{ "VS323NBVS", "15/10/2025" },
			{ "VS322NBBU", "10/10/2025" },
			{ "VS321NUBU", "09/10/2025" },
			{ "VS320NSBU", "06/10/2025" },
			{ "VS319NBBU", "30/09/2025" },
			{ "VS318NBBU", "30/09/2025" },
			{ "VS317NSBU", "29/09/2025" },
			{ "VS316NPBU", "25/09/2025" },
			{ "VS315NBBU", "23/09/2025" },
			{ "VS314NLBU", "23/09/2025" },
			{ "VS313NUBU", "19/09/2025" },
			{ "VS312NBBU", "13/09/2025" },
			{ "VS311NLHG", "11/09/2025" },
			{ "VS310NUBU", "21/08/2025" },
			{ "VS309NBVS", "20/08/2025" },
			{ "VS308NLVS", "15/08/2025" },
			{ "VS307NSVS", "14/08/2025" },
			{ "VS306NPVS", "11/08/2025" },
			{ "VS305NUBU", "08/08/2025" },
			{ "VS303NSVS", "26/07/2025" },
			{ "VS302NUBU", "22/07/2025" },
			{ "VS301NSVS", "22/07/2025" },
			{ "VS300NUBU", "20/09/2025" },
			{ "VS299NEBU", "02/06/2026" },
			{ "VS298NBBU", "02/06/2026" },
			{ "VS297NABU", "29/05/2026" },
			{ "VS296NBBU", "24/05/2026" },
			{ "VS295NSBU", "22/05/2026" },
			{ "VS294NSBU", "21/05/2026" },
			{ "VS293NLBU", "28/04/2026" },
			{ "VS292NUBU", "28/04/2026" },
			{ "VS291NUBU", "12/04/2026" },
			{ "VS290NBVS", "09/04/2026" },
			{ "VS289NEBU", "31/03/2026" },
			{ "VS288NEBU", "29/03/2026" },
			{ "VS287NEBU", "28/03/2026" },
			{ "VS286NEBU", "27/03/2026" },
			{ "VS285NEVS", "20/03/2026" },
			{ "VS284NPVS", "01/04/2026" },
			{ "VS283NPVS", "01/04/2026" },
			{ "VS282NPVS", "01/04/2026" },
			{ "VS281NBBU", "05/03/2025" },
			{ "VS280NUBU", "04/03/2025" },
			{ "VS279NLBU", "28/02/2025" },
			{ "VS278NLBU", "26/02/2026" },
			{ "VS277NLBU", "27/02/2025" },
			{ "VS276NAVS", "25/02/2026" },
			{ "VS275NBVS", "22/02/2026" },
			{ "VS274NBVS", "21/02/2026" },
			{ "VS273NEVS", "13/02/2026" },
			{ "VS272NEBU", "13/02/2026" },
			{ "VS271NEBU", "01/04/2026" },
			{ "VS270NPBU", "25/04/2026" },
			{ "VS269NPVS", "27/01/2026" },
			{ "VS268NPBU", "24/01/2026" },
			{ "VS267NPVS", "24/01/2025" },
			{ "VS266NSBU", "23/01/2026" },
			{ "VS265NUBU", "16/01/2026" },
			{ "VS264NUVS", "16/01/2026" },
			{ "VS263NUBU", "16/01/2026" },
			{ "VS262NUBU", "16/01/2026" },
			{ "VS261NUBU", "13/01/2026" },
			{ "VS260NUBU", "10/01/2026" },
			{ "VS259NLHG", "07/01/2026" },
			{ "VS258NBBU", "06/01/2026" },
			{ "VS257NSBU", "24/12/2025" },
			{ "VS256NBVS", "29/11/2024" },
			{ "VS255NBBU", "19/11/2025" },
			{ "VS254NEBU", "22/03/2026" },
			{ "VS253NEBU", "31/03/2026" },
			{ "VS252NEBU", "31/03/2026" },
			{ "VS251NSBU", "26/01/2026" },
			{ "VS250NEVS", "31/10/2025" },
			{ "VS249NEBU", "01/04/2026" },
			{ "VS248NSBU", "01/04/2026" },
			{ "VS247NEBU", "27/10/2025" },
			{ "VS246NEBU", "27/10/2025" },
			{ "VS245NPVS", "27/10/2025" },
			{ "VS244NEVS", "27/10/2025" },
			{ "VS243NLBU", "24/10/2024" },
			{ "VS242NEVS", "24/10/2025" },
			{ "VS241NEBU", "21/10/2025" },
			{ "VS240NEVS", "04/12/2025" },
			{ "VS239NEBU", "21/10/2025" },
			{ "VS238NEVS", "19/10/2025" },
			{ "VS237NSVS", "10/04/2026" },
			{ "VS236NPVS", "16/10/2025" },
			{ "VS235NEBU", "10/10/2025" },
			{ "VS234NEBU", "30/04/2026" },
			{ "VS233NEBU", "10/01/2026" },
			{ "VS232NEBU", "01/10/2025" },
			{ "VS231NSVS", "14/09/2025" },
			{ "VS230NSBU", "12/09/2024" },
			{ "VS229NEVS", "25/02/2026" },
			{ "VS228NSBU", "03/09/2024" },
			{ "VS227NPVS", "02/09/2025" },
			{ "VS226NPBU", "03/04/2026" },
			{ "VS225NBBU", "31/07/2025" },
			{ "VS224NSBU", "20/07/2025" },
			{ "VS223NSVS", "06/01/2026" },
			{ "VS222NEVS", "11/07/2025" },
			{ "VS221NSVS", "26/06/2025" },
			{ "VS220NPVS", "21/05/2026" },
			{ "VS219NPVS", "18/05/2025" },
			{ "VS218NSBU", "16/08/2025" },
			{ "VS217NSBU", "01/04/2025" },
			{ "VS216NPBU", "30/04/2026" },
			{ "VS215NSBU", "30/06/2025" },
			{ "VS214NSBU", "30/04/2026" },
			{ "VS213NPBU", "25/04/2025" },
			{ "VS212NLBU", "03/04/2026" },
			{ "VS211NPBU", "31/03/2026" },
			{ "VS210NLBU", "30/03/2026" },
			{ "VS209NAVS", "30/03/2026" },
			{ "VS208NPVS", "30/03/2026" },
			{ "VS207NLBU", "30/03/2026" },
			{ "VS206NLVS", "28/03/2026" },
			{ "VS205NSBU", "22/03/2025" },
			{ "VS204NPVS", "15/03/2026" },
			{ "VS203NSBU", "15/03/2024" },
			{ "VS202NSVS", "15/03/2026" },
			{ "VS201NSVS", "12/03/2026" },
			{ "VS200NEBU", "26/10/2025" },
			{ "VS199NPVS", "13/02/2024" },
			{ "VS198NSBU", "12/02/2026" },
			{ "VS197NSVS", "08/02/2026" },
			{ "VS196NPBU", "03/07/2026" },
			{ "VS195NAVS", "12/01/2026" },
			{ "VS194NSVS", "07/01/2024" },
			{ "VS193NPBU", "02/01/2026" },
			{ "VS192NPBU", "02/01/2026" },
			{ "VS191NAVS", "30/12/2025" },
			{ "VS190NLHG", "30/12/2025" },
			{ "VS189NPVS", "11/12/2025" },
			{ "VS188NEBU", "13/11/2025" },
			{ "VS187NEVS", "26/10/2025" },
			{ "VS186NPVS", "21/10/2025" },
			{ "VS185NPBU", "10/10/2025" },
			{ "VS184NUVS", "06/10/2025" },
			{ "VS183NSBU", "26/09/2023" },
			{ "VS182NEBU", "26/09/2025" },
			{ "VS181NSBU", "11/09/2025" },
			{ "VS180NSVS", "15/08/2025" },
			{ "VS179NSHG", "14/08/2025" },
			{ "VS178NSVS", "21/07/2025" },
			{ "VS177NPBU", "17/07/2023" },
			{ "VS176NPBU", "15/07/2025" },
			{ "VS175NSVS", "15/07/2025" },
			{ "VS174NEBU", "11/07/2025" },
			{ "VS173NSVS", "10/07/2023" },
			{ "VS172NSBU", "06/07/2025" },
			{ "VS171NAVS", "25/10/2025" },
			{ "VS170NABU", "01/07/2025" },
			{ "VS169NEBU", "23/06/2025" },
			{ "VS168NSBU", "12/06/2025" },
			{ "VS167NPVS", "12/06/2025" },
			{ "VS165NPBU", "17/05/2025" },
			{ "VS164NPVS", "02/05/2026" },
			{ "VS163NPBU", "30/04/2026" },
			{ "VS162NSVS", "30/04/2026" },
			{ "VS161NSVS", "28/04/2026" },
			{ "VS160NSVS", "26/04/2026" },
			{ "VS159NPVS", "18/04/2026" },
			{ "VS158NPBU", "02/04/2026" },
			{ "VS157NPBU", "18/03/2026" },
			{ "VS156NEBU", "13/03/2026" },
			{ "VS155NSBU", "11/03/2026" },
			{ "VS154NSBU", "06/03/2026" },
			{ "VS153NPVS", "24/02/2026" },
			{ "VS152NPVS", "18/02/2026" },
			{ "VS151NSVS", "16/02/2026" },
			{ "VS150NSBU", "31/01/2023" },
			{ "VS149NSBU", "20/01/2026" },
			{ "VS148NSVS", "18/01/2023" },
			{ "VS147NSBU", "19/01/2026" },
			{ "VS146NPBU", "17/01/2026" },
			{ "VS145NABU", "12/01/2026" },
			{ "VS144NSBU", "10/01/2026" },
			{ "VS143NAHG", "09/01/2026" },
			{ "VS142NPVS", "09/01/2026" },
			{ "VS141NPBU", "09/01/2026" },
			{ "VS140NSHG", "31/12/2025" },
			{ "VS139NSBU", "27/12/2025" },
			{ "VS138NPBU", "19/12/2025" },
			{ "VS137NEBU", "13/12/2025" },
			{ "VS136NSBU", "15/01/2024" },
			{ "VS135NSVS", "25/11/2025" },
			{ "VS134NSBU", "24/11/2025" },
			{ "VS133NAVS", "01/06/2026" },
			{ "VS132NSVS", "10/10/2025" },
			{ "VS131NSBU", "10/10/2025" },
			{ "VS130NSBU", "07/10/2025" },
			{ "VS129NPBU", "21/09/2025" },
			{ "VS128NSVS", "03/11/2025" },
			{ "VS127NSVS", "06/01/2028" },
			{ "VS126NPBU", "24/09/2022" },
			{ "VS125NPBU", "23/09/2025" },
			{ "VS124NEVS", "21/09/2023" },
			{ "VS123NPVS", "16/09/2025" },
			{ "VS122NSHG", "14/09/2025" },
			{ "VS121NPVS", "21/10/2024" },
			{ "VS120NSVS", "01/09/2025" },
			{ "VS119NPBU", "30/08/2025" },
			{ "VS118NEVS", "27/08/2025" },
			{ "VS117NEBU", "12/08/2025" },
			{ "VS116NEBU", "29/07/2025" },
			{ "VS115NSBU", "28/07/2025" },
			{ "VS114NPVS", "11/07/2025" },
			{ "VS113NSVS", "16/06/2025" },
			{ "VS112NSVS", "01/06/2026" },
			{ "VS111NSVS", "31/05/2024" },
			{ "VS110NPBU", "28/05/2026" },
			{ "VS109NPVS", "02/09/2025" },
			{ "VS108NPBU", "28/04/2026" },
			{ "VS107NSBU", "23/04/2024" },
			{ "VS106NPBU", "10/04/2026" },
			{ "VS105NPBU", "01/05/2026" },
			{ "VS104NPBU", "29/03/2026" },
			{ "VS103NPBU", "01/04/2026" },
			{ "VS102NPVS", "22/03/2026" },
			{ "VS101NLHG", "17/03/2026" },
			{ "VS100NEHG", "21/08/2025" },
			{ "VS099NSBU", "21/11/2025" },
			{ "VS098NSHG", "24/02/2026" },
			{ "VS097NAVS", "22/02/2022" },
			{ "VS096NABU", "09/06/2026" },
			{ "VS095NSVS", "17/02/2026" },
			{ "VS094NPHG", "12/02/2026" },
			{ "VS093NSHG", "10/02/2022" },
			{ "VS092NPHG", "25/03/2026" },
			{ "VS091NSBU", "03/02/2026" },
			{ "VS090NPVS", "01/02/2026" },
			{ "VS089NSVS", "08/01/2026" },
			{ "VS088NPBU", "01/01/2026" },
			{ "VS087NAVS", "01/01/2026" },
			{ "VS086NPHG", "30/12/2021" },
			{ "VS085NPBU", "20/12/2025" },
			{ "VS084NEBU", "19/05/2026" },
			{ "VS083NPBU", "07/12/2021" },
			{ "VS082NPVS", "30/12/2025" },
			{ "VS081NEBU", "19/05/2026" },
			{ "VS080NPVS", "29/11/2025" },
			{ "VS079NABU", "19/12/2025" },
			{ "VS078NPVS", "06/02/2026" },
			{ "VS077NEVS", "31/10/2025" },
			{ "VS076NSBU", "17/10/2021" },
			{ "VS075NSHG", "25/10/2025" },
			{ "VS074NUVS", "01/05/2026" },
			{ "VS073NSBU", "06/10/2025" },
			{ "VS072NSVS", "30/09/2021" },
			{ "VS071NSBU", "10/09/2023" },
			{ "VS070NPVS", "09/09/2023" },
			{ "VS069NSBU", "27/08/2025" },
			{ "VS068NPHG", "06/08/2025" },
			{ "VS067NPBU", "02/08/2023" },
			{ "VS066NSBU", "21/04/2026" },
			{ "VS065NSVS", "28/07/2025" },
			{ "VS064NSBU", "22/07/2025" },
			{ "VS063NPBU", "14/07/2022" },
			{ "VS062NSBU", "05/07/2025" },
			{ "VS061NSVS", "06/07/2025" },
			{ "VS060NSBU", "03/07/2025" },
			{ "VS059NEBU", "05/03/2026" },
			{ "VS058NPVS", "25/05/2025" },
			{ "VS057NSVS", "23/04/2026" },
			{ "VS056NSVS", "03/04/2026" },
			{ "VS055NEVS", "20/04/2025" },
			{ "VS054NEVS", "25/03/2026" },
			{ "VS053NSBU", "13/06/2025" },
			{ "VS052NABU", "26/02/2025" },
			{ "VS051NPVS", "26/06/2025" },
			{ "VS050NLHG", "02/02/2026" },
			{ "VS049NSBU", "27/01/2026" },
			{ "VS048NSHG", "20/01/2026" },
			{ "VS047NSBU", "08/12/2025" },
			{ "VS046NPBU", "17/11/2025" },
			{ "VS045NEHG", "08/04/2025" },
			{ "VS044NPBU", "27/07/2024" },
			{ "VS043NPBU", "31/08/2020" },
			{ "VS042NPVS", "29/08/2022" },
			{ "VS041NPVS", "27/08/2025" },
			{ "VS040NPBU", "19/08/2025" },
			{ "VS039NPVS", "20/08/2023" },
			{ "VS038NPHG", "08/08/2025" },
			{ "VS037NSBU", "04/08/2025" },
			{ "VS036NSBU", "06/07/2025" },
			{ "VS035NEBU", "27/10/2025" },
			{ "VS034NPBU", "10/07/2025" },
			{ "VS033NSBU", "20/04/2026" },
			{ "VS032NPBU", "24/06/2025" },
			{ "VS031NSVS", "24/06/2025" },
			{ "VS030NPBU", "16/06/2025" },
			{ "VS029NPBU", "11/06/2025" },
			{ "VS028NEHG", "01/06/2026" },
			{ "VS027NPVS", "24/05/2026" },
			{ "VS026NSVS", "23/05/2023" },
			{ "VS025NPHG", "20/05/2026" },
			{ "VS024NEVS", "16/10/2025" },
			{ "VS023NPBU", "22/06/2025" },
			{ "VS022NPHG", "27/04/2026" },
			{ "VS021NPVS", "18/03/2026" },
			{ "VS020NPBU", "18/03/2026" },
			{ "VS019NLHG", "17/03/2026" },
			{ "VS018NEHG", "07/10/2025" },
			{ "VS017NLBU", "12/03/2023" },
			{ "VS016NPHG", "01/03/2026" },
			{ "VS015NSBU", "17/10/2025" },
			{ "VS014NSBU", "03/04/2026" },
			{ "VS013NSBU", "12/02/2026" },
			{ "VS012NPHG", "25/01/2026" },
			{ "VS011NSBU", "23/01/2026" },
			{ "VS010NPBU", "01/04/2021" },
			{ "VS009NSVS", "18/01/2025" },
			{ "VS008NSHG", "16/01/2020" },
			{ "VS007NPVS", "01/02/2026" },
			{ "VS006NSBU", "03/01/2026" },
			{ "VS005NSBU", "01/01/2023" },
			{ "VS004NSBU", "26/12/2023" },
			{ "VS003NLBU", "13/12/2019" },
			{ "VS002NLBU", "01/11/2023" }
		};

		if (!amcDates.TryGetValue(DC_Main.SSRegSrNo ?? "", out string amcDateStr))
		{
#if DEV_MODE
			return; // Unknown serial — allow in dev mode
#else
			DC_Main.MsSoftNoUse = "Y";
			return;
#endif
		}

		DC_Main.AmcEndDate = Microsoft.VisualBasic.CompilerServices.Conversions.ToDate(amcDateStr).AddDays(365.0);
		if ((DC_Main.MsAmcUnlockDay > 0) & (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) < 0))
			AmcFreeDayReset();
		if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) <= 0)
			return;
		Microsoft.VisualBasic.Interaction.MsgBox((object)("Your Amc Period is Over End Date = " + DC_Main.AmcEndDate.ToString() + "...."), (Microsoft.VisualBasic.MsgBoxStyle)0, (object)null);
		if (DC_Main.MsAmcUnlockDay > 0)
		{
			DC_Main.AmcEndDate = DC_Main.AmcEndDate.AddDays(DC_Main.MsAmcUnlockDay);
			if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) > 0)
				System.Windows.Forms.Application.Exit();
		}
		else
			DC_Main.MsSoftNoUse = "Y";
	}

	private void Vikas_Amc()
	{
		// Refactored from giant if/else chain — 318 AMC serial numbers
		var amcDates = new System.Collections.Generic.Dictionary<string, string>
		{
			{ "VK324NBDS", "02/04/2026" },
			{ "VK323NEVK", "01/04/2026" },
			{ "VK322NSVK", "01/04/2026" },
			{ "VK321NEPH", "25/03/2026" },
			{ "VK320NAPH", "10/04/2026" },
			{ "VK319NEPH", "10/04/2026" },
			{ "VK318NAPH", "10/04/2026" },
			{ "VK317NAPH", "10/04/2026" },
			{ "VK316NADS", "12/03/2026" },
			{ "VK315NEVK", "05/03/2026" },
			{ "VK314NBPJ", "02/03/2026" },
			{ "VK313NUST", "26/02/2026" },
			{ "VK312NUST", "18/02/2026" },
			{ "VK311NBVK", "28/01/2026" },
			{ "VK310NBSS", "16/01/2026" },
			{ "VK309NAPH", "02/01/2026" },
			{ "VK308NUST", "30/12/2025" },
			{ "VK307NBDS", "26/12/2025" },
			{ "VK306NAVK", "24/12/2025" },
			{ "VK305NUST", "16/12/2025" },
			{ "VK304NLDS", "12/11/2025" },
			{ "VK303NUST", "31/10/2025" },
			{ "VK302NSVK", "31/10/2025" },
			{ "VK301NAST", "31/10/2025" },
			{ "VK300NUST", "18/10/2025" },
			{ "VK299NSPH", "16/10/2025" },
			{ "VK298NLVK", "16/10/2025" },
			{ "VK297NEPH", "08/10/2025" },
			{ "VK296NBDS", "19/05/2026" },
			{ "VK295NUPJ", "01/10/2025" },
			{ "VK294NBDS", "27/09/2025" },
			{ "VK293NLPH", "26/09/2025" },
			{ "VK292NBPH", "26/09/2025" },
			{ "VK291NPDS", "24/09/2025" },
			{ "VK290NLVK", "18/09/2025" },
			{ "VK289NEPH", "16/09/2025" },
			{ "VK288NAVK", "16/09/2025" },
			{ "VK287NPVK", "11/09/2025" },
			{ "VK286NUST", "04/09/2025" },
			{ "VK285NSVK", "30/08/2025" },
			{ "VK284NUST", "29/08/2025" },
			{ "VK283NSDS", "26/08/2025" },
			{ "VK282NAST", "22/08/2025" },
			{ "VK281NAST", "21/08/2025" },
			{ "VK279NUST", "18/08/2025" },
			{ "VK278NBPH", "14/08/2025" },
			{ "VK277NBPH", "13/08/2025" },
			{ "VK276NLVK", "13/08/2025" },
			{ "VK275NUST", "07/08/2025" },
			{ "VK274NPPH", "02/08/2025" },
			{ "VK273NPVK", "29/07/2025" },
			{ "VK272NAST", "28/07/2025" },
			{ "VK271NSPH", "23/07/2025" },
			{ "VK270NLVK", "23/07/2025" },
			{ "VK269NPPJ", "21/07/2025" },
			{ "VK268NUST", "19/07/2025" },
			{ "VK267NEPH", "08/10/2025" },
			{ "VK266NUPJ", "15/07/2025" },
			{ "VK265NUST", "15/07/2025" },
			{ "VK264NBPJ", "11/07/2025" },
			{ "VK263NEVK", "07/07/2025" },
			{ "VK262NLVK", "07/07/2025" },
			{ "VK261NLVK", "05/07/2025" },
			{ "VK260NUST", "30/06/2025" },
			{ "VK259NBVK", "26/06/2025" },
			{ "VK258NBPH", "24/06/2025" },
			{ "VK257NPVK", "21/06/2025" },
			{ "VK256NBDS", "20/06/2025" },
			{ "VK255NEVK", "20/06/2025" },
			{ "VK254NUST", "19/06/2025" },
			{ "VK253NEVK", "13/06/2025" },
			{ "VK252NUST", "12/06/2025" },
			{ "VK251NBPH", "12/06/2025" },
			{ "VK250NEPH", "09/06/2026" },
			{ "VK249NSVK", "02/06/2026" },
			{ "VK248NUPJ", "28/05/2026" },
			{ "VK247NLPH", "26/05/2026" },
			{ "VK246NSVK", "18/05/2025" },
			{ "VK245NSPH", "11/04/2026" },
			{ "VK244NSPH", "08/04/2026" },
			{ "VK243NSPH", "08/04/2026" },
			{ "VK242NLVK", "06/04/2026" },
			{ "VK241NSVK", "04/04/2026" },
			{ "VK240NBVK", "01/04/2026" },
			{ "VK239NEVK", "31/03/2026" },
			{ "VK238NUVK", "21/03/2025" },
			{ "VK237NUVK", "19/03/2026" },
			{ "VK236NEVK", "12/03/2026" },
			{ "VK235NPPH", "08/08/2025" },
			{ "VK234NBDS", "05/02/2026" },
			{ "VK233NSVK", "30/01/2026" },
			{ "VK232NUDS", "29/01/2026" },
			{ "VK231NLDS", "22/01/2026" },
			{ "VK230NBVK", "20/01/2026" },
			{ "VK229NSVK", "20/01/2026" },
			{ "VK228NPPH", "20/01/2026" },
			{ "VK227NUDS", "17/01/2026" },
			{ "VK226NPVK", "01/04/2026" },
			{ "VK225NPVK", "11/01/2025" },
			{ "VK224NUVK", "01/01/2025" },
			{ "VK223NLPJ", "23/12/2025" },
			{ "VK222NAPH", "10/04/2026" },
			{ "VK221NEVK", "18/12/2025" },
			{ "VK219NLVK", "17/12/2025" },
			{ "VK218NSVK", "07/08/2025" },
			{ "VK217NEVK", "22/11/2025" },
			{ "VK216NBPH", "12/11/2025" },
			{ "VK215NBPH", "07/11/2024" },
			{ "VK214NEVK", "13/10/2025" },
			{ "VK213NPVK", "01/04/2026" },
			{ "VK212NLVK", "15/10/2025" },
			{ "VK211NLPJ", "08/10/2025" },
			{ "VK210NSVK", "07/10/2025" },
			{ "VK209NEVK", "02/10/2025" },
			{ "VK208NLVK", "01/10/2025" },
			{ "VK207NBVK", "13/09/2025" },
			{ "VK206NBPH", "09/09/2025" },
			{ "VK205NPPH", "03/09/2025" },
			{ "VK204NEVK", "28/10/2025" },
			{ "VK203NBSD", "16/07/2025" },
			{ "VK202NEVK", "04/07/2025" },
			{ "VK201NSSD", "03/07/2025" },
			{ "VK200NSPH", "26/07/2025" },
			{ "VK199NLVK", "06/06/2024" },
			{ "VK198NBPH", "05/06/2024" },
			{ "VK197NSVK", "24/05/2026" },
			{ "VK196NLPH", "25/05/2024" },
			{ "VK195NEPH", "24/05/2025" },
			{ "VK194NEVK", "17/05/2024" },
			{ "VK193NLSD", "09/05/2026" },
			{ "VK192NBVK", "17/06/2025" },
			{ "VK191NEVK", "04/05/2026" },
			{ "VK190NPVK", "30/04/2026" },
			{ "VK189NSVK", "30/04/2024" },
			{ "VK188NESD", "30/04/2026" },
			{ "VK187NBSD", "26/04/2026" },
			{ "VK186NSSD", "17/04/2026" },
			{ "VK185NBVK", "16/04/2026" },
			{ "VK184NLSD", "09/04/2024" },
			{ "VK183NEPH", "04/10/2025" },
			{ "VK182NSPJ", "05/04/2026" },
			{ "VK181NSPH", "31/01/2026" },
			{ "VK180NLSD", "30/03/2026" },
			{ "VK179NAVK", "26/02/2026" },
			{ "VK178NEVK", "21/03/2025" },
			{ "VK177NESD", "21/10/2025" },
			{ "VK176NESD", "18/03/2026" },
			{ "VK175NBSD", "05/03/2025" },
			{ "VK174NSVK", "04/03/2026" },
			{ "VK173NSSD", "27/02/2026" },
			{ "VK172NBVK", "10/02/2026" },
			{ "VK171NEVK", "06/02/2026" },
			{ "VK170NLVK", "01/02/2026" },
			{ "VK169NPVK", "18/01/2026" },
			{ "VK168NEVK", "10/01/2026" },
			{ "VK167NESD", "31/12/2025" },
			{ "VK166NEVK", "10/06/2026" },
			{ "VK165NEVK", "29/12/2025" },
			{ "VK164NEVK", "29/12/2025" },
			{ "VK163NEVK", "01/04/2026" },
			{ "VK162NEVK", "25/12/2025" },
			{ "VK160NLSD", "01/11/2025" },
			{ "VK159NLSD", "30/10/2023" },
			{ "VK158NPSD", "27/10/2025" },
			{ "VK157NEVK", "17/10/2025" },
			{ "VK156NLSD", "14/10/2025" },
			{ "VK155NBVK", "26/09/2025" },
			{ "VK154NSVK", "20/09/2024" },
			{ "VK153NSSD", "18/09/2025" },
			{ "VK152NSSD", "12/09/2025" },
			{ "VK151NBSD", "25/08/2025" },
			{ "VK150NBSD", "12/08/2025" },
			{ "VK149NEVK", "02/08/2025" },
			{ "VK148NBVK", "01/08/2025" },
			{ "VK147NLVK", "31/07/2025" },
			{ "VK146NEVK", "29/07/2025" },
			{ "VK145NLVK", "27/07/2025" },
			{ "VK144NPSD", "27/07/2025" },
			{ "VK143NPVK", "21/07/2025" },
			{ "VK142NEVK", "17/07/2025" },
			{ "VK141NLVK", "17/07/2025" },
			{ "VK140NLVK", "15/07/2025" },
			{ "VK139NSSD", "15/07/2023" },
			{ "VK138NPSD", "15/07/2025" },
			{ "VK137NEVK", "29/10/2025" },
			{ "VK136NPVK", "28/06/2025" },
			{ "VK135NSVK", "23/06/2025" },
			{ "VK134NEVK", "15/06/2025" },
			{ "VK133NEVK", "10/06/2026" },
			{ "VK132NEVK", "09/06/2023" },
			{ "VK131NEVK", "07/10/2025" },
			{ "VK130NSSD", "29/05/2026" },
			{ "VK129NSSD", "16/05/2026" },
			{ "VK128NEVK", "12/05/2026" },
			{ "VK127NUSD", "23/04/2026" },
			{ "VK126NPSD", "02/04/2026" },
			{ "VK125NSSD", "30/04/2026" },
			{ "VK124NLSD", "22/04/2025" },
			{ "VK123NSSD", "01/09/2025" },
			{ "VK122NPVK", "01/04/2026" },
			{ "VK121NEVK", "01/04/2026" },
			{ "VK120NEVK", "01/04/2026" },
			{ "VK119NLVK", "22/03/2026" },
			{ "VK118NSSD", "20/03/2026" },
			{ "VK117NSSD", "17/03/2026" },
			{ "VK116NBSD", "02/01/2026" },
			{ "VK115NEVK", "04/02/2025" },
			{ "VK114NSSD", "30/01/2026" },
			{ "VK113NEVK", "26/01/2026" },
			{ "VK112NSSD", "19/01/2026" },
			{ "VK111NSSD", "10/01/2026" },
			{ "VK110NSVK", "10/01/2024" },
			{ "VK109NEVK", "07/01/2026" },
			{ "VK108NSSD", "05/01/2026" },
			{ "VK107NSSD", "04/01/2026" },
			{ "VK106NEVK", "02/01/2026" },
			{ "VK105NPVK", "28/12/2025" },
			{ "VK104NAVK", "21/12/2025" },
			{ "VK103NEVK", "22/11/2025" },
			{ "VK102NSSD", "14/11/2025" },
			{ "VK101NSVK", "21/10/2025" },
			{ "VK100NSVK", "10/10/2025" },
			{ "VK099NPVK", "24/09/2025" },
			{ "VK098NPSD", "21/09/2025" },
			{ "VK097NPVK", "21/09/2025" },
			{ "VK096NSSD", "12/09/2025" },
			{ "VK095NEVK", "26/08/2022" },
			{ "VK094NPVK", "18/11/2025" },
			{ "VK093NAVK", "02/08/2025" },
			{ "VK092NSVK", "11/07/2025" },
			{ "VK091NPVK", "23/06/2026" },
			{ "VK090NLSD", "14/06/2025" },
			{ "VK089NSVK", "23/05/2022" },
			{ "VK088NPSD", "02/05/2026" },
			{ "VK087NASD", "29/09/2025" },
			{ "VK086NPVK", "20/07/2025" },
			{ "VK085NPSD", "31/01/2026" },
			{ "VK084NPVK", "31/01/2026" },
			{ "VK083NASD", "29/09/2025" },
			{ "VK082NSVK", "27/06/2025" },
			{ "VK081NSVK", "10/04/2026" },
			{ "VK080NAVK", "08/11/2023" },
			{ "VK079NPVK", "31/12/2025" },
			{ "VK078NPVK", "17/12/2025" },
			{ "VK077NPVK", "16/12/2025" },
			{ "VK076NESD", "28/10/2025" },
			{ "VK075NPVK", "08/12/2025" },
			{ "VK074NSVK", "01/12/2025" },
			{ "VK073NPVK", "25/10/2025" },
			{ "VK072NLVK", "30/10/2021" },
			{ "VK071NPSD", "15/10/2025" },
			{ "VK070NSVK", "16/12/2025" },
			{ "VK069NPVK", "31/03/2026" },
			{ "VK068NBSD", "19/05/2026" },
			{ "VK067NPVK", "31/03/2026" },
			{ "VK065NEVK", "31/03/2026" },
			{ "VK064NESD", "07/10/2023" },
			{ "VK063NESD", "07/10/2023" },
			{ "VK062NSVK", "15/09/2021" },
			{ "VK061NEVK", "13/09/2025" },
			{ "VK060NPVK", "13/09/2025" },
			{ "VK059NPVK", "06/09/2021" },
			{ "VK058NEVK", "26/10/2025" },
			{ "VK057NSVK", "30/10/2025" },
			{ "VK056NEVK", "19/08/2025" },
			{ "VK055NPVK", "20/12/2025" },
			{ "VK054NLVK", "27/07/2024" },
			{ "VK053NSVK", "23/07/2025" },
			{ "VK052NEVK", "07/07/2026" },
			{ "VK051NPVK", "03/07/2025" },
			{ "VK050NEVK", "08/06/2024" },
			{ "VK049NSVK", "02/06/2026" },
			{ "VK048NSVK", "04/12/2024" },
			{ "VK047NEHR", "26/10/2025" },
			{ "VK046NEVK", "02/10/2025" },
			{ "VK044NPVK", "12/04/2022" },
			{ "VK043NPSD", "03/04/2026" },
			{ "VK042NSVK", "02/04/2021" },
			{ "VK041NSHR", "30/03/2026" },
			{ "VK040NPSD", "04/02/2026" },
			{ "VK039NPVK", "22/07/2023" },
			{ "VK038NEVK", "23/10/2025" },
			{ "VK037NPVK", "27/05/2020" },
			{ "VK036NPVK", "19/11/2025" },
			{ "VK035NLVK", "01/01/2026" },
			{ "VK034NPVK", "02/05/2026" },
			{ "VK033NPVK", "19/09/2025" },
			{ "VK032NPVK", "31/07/2025" },
			{ "VK031NPVK", "14/08/2020" },
			{ "VK030NPVK", "21/06/2025" },
			{ "VK029NEVK", "31/10/2025" },
			{ "VK028NEVK", "14/10/2025" },
			{ "VK027NBVK", "31/10/2025" },
			{ "VK026NPVK", "14/03/2020" },
			{ "VK025NEVK", "08/10/2025" },
			{ "VK024NPVK", "13/03/2026" },
			{ "VK023NPVK", "01/04/2020" },
			{ "VK022NPVK", "31/03/2026" },
			{ "VK021NPVK", "07/03/2026" },
			{ "VK020NPVK", "09/02/2026" },
			{ "VK019NEVK", "09/02/2026" },
			{ "VK018NPSD", "09/02/2026" },
			{ "VK017NASD", "31/03/2026" },
			{ "VK016NPVK", "27/01/2020" },
			{ "VK015NSVK", "20/01/2020" },
			{ "VK014NSVK", "20/01/2026" },
			{ "VK013NSVK", "17/01/2026" },
			{ "VK012NSSD", "18/01/2022" },
			{ "VK011NSVK", "01/01/2026" },
			{ "VK010NSSD", "01/01/2026" },
			{ "VK009NPVK", "29/12/2025" },
			{ "VK008NEVK", "02/02/2026" },
			{ "VK007NLVK", "25/11/2020" },
			{ "VK006NPVK", "11/02/2026" },
			{ "VK005NSVK", "18/11/2019" },
			{ "VK004NSVK", "31/08/2024" },
			{ "VK003NLVK", "05/11/2025" },
			{ "VK002NLVK", "03/11/2025" }
		};

		if (!amcDates.TryGetValue(DC_Main.SSRegSrNo ?? "", out string amcDateStr))
		{
#if DEV_MODE
			return; // Unknown serial — allow in dev mode
#else
			DC_Main.MsSoftNoUse = "Y";
			return;
#endif
		}

		DC_Main.AmcEndDate = Microsoft.VisualBasic.CompilerServices.Conversions.ToDate(amcDateStr).AddDays(365.0);
		if ((DC_Main.MsAmcUnlockDay > 0) & (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) < 0))
			AmcFreeDayReset();
		if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) <= 0)
			return;
		Microsoft.VisualBasic.Interaction.MsgBox((object)("Your Amc Period is Over End Date = " + DC_Main.AmcEndDate.ToString() + "...."), (Microsoft.VisualBasic.MsgBoxStyle)0, (object)null);
		if (DC_Main.MsAmcUnlockDay > 0)
		{
			DC_Main.AmcEndDate = DC_Main.AmcEndDate.AddDays(DC_Main.MsAmcUnlockDay);
			if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) > 0)
				System.Windows.Forms.Application.Exit();
		}
		else
			DC_Main.MsSoftNoUse = "Y";
	}

	private void Dhrupal_Amc()
	{
		// Refactored from giant if/else chain — 9 AMC serial numbers
		var amcDates = new System.Collections.Generic.Dictionary<string, string>
		{
			{ "DH010NPDH", "16/06/2020" },
			{ "DH009NPDH", "24/05/2021" },
			{ "DH008NSDH", "20/03/2026" },
			{ "DH007NPDH", "13/03/2026" },
			{ "DH006NPDH", "07/02/2020" },
			{ "DH005NPDH", "24/01/2020" },
			{ "DH004NPDH", "01/04/2025" },
			{ "DH003NPDH", "13/01/2026" },
			{ "DH002NSDH", "04/01/2020" }
		};

		if (!amcDates.TryGetValue(DC_Main.SSRegSrNo ?? "", out string amcDateStr))
		{
#if DEV_MODE
			return; // Unknown serial — allow in dev mode
#else
			DC_Main.MsSoftNoUse = "Y";
			return;
#endif
		}

		DC_Main.AmcEndDate = Microsoft.VisualBasic.CompilerServices.Conversions.ToDate(amcDateStr).AddDays(365.0);
		if ((DC_Main.MsAmcUnlockDay > 0) & (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) < 0))
			AmcFreeDayReset();
		if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) <= 0)
			return;
		Microsoft.VisualBasic.Interaction.MsgBox((object)("Your Amc Period is Over End Date = " + DC_Main.AmcEndDate.ToString() + "...."), (Microsoft.VisualBasic.MsgBoxStyle)0, (object)null);
		if (DC_Main.MsAmcUnlockDay > 0)
		{
			DC_Main.AmcEndDate = DC_Main.AmcEndDate.AddDays(DC_Main.MsAmcUnlockDay);
			if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) > 0)
				System.Windows.Forms.Application.Exit();
		}
		else
			DC_Main.MsSoftNoUse = "Y";
	}

	private void Dipak_Amc()
	{
		// Refactored from giant if/else chain — 54 AMC serial numbers
		var amcDates = new System.Collections.Generic.Dictionary<string, string>
		{
			{ "DD055NBDD", "18/04/2026" },
			{ "DD054NBDD", "14/04/2026" },
			{ "DD053NBDD", "27/03/2026" },
			{ "DD052NBDD", "17/03/2026" },
			{ "DD051NBDD", "17/03/2026" },
			{ "DD050NBDD", "03/03/2026" },
			{ "DD049NLDD", "27/02/2026" },
			{ "DD048NBDD", "12/02/2026" },
			{ "DD047NSDD", "01/01/2026" },
			{ "DD046NBDD", "30/12/2025" },
			{ "DD045NBDD", "29/11/2025" },
			{ "DD044NBDD", "21/06/2025" },
			{ "DD043NBDD", "26/05/2026" },
			{ "DD042NSDD", "25/04/2026" },
			{ "DD041NBDD", "03/03/2026" },
			{ "DD040NSDD", "17/02/2026" },
			{ "DD039NSDD", "05/05/2026" },
			{ "DD038NEDD", "30/01/2026" },
			{ "DD037NUDD", "11/01/2026" },
			{ "DD036NUDD", "29/12/2025" },
			{ "DD035NLDD", "03/12/2026" },
			{ "DD034NSDD", "25/11/2025" },
			{ "DD033NSDD", "21/11/2025" },
			{ "DD032NBDD", "30/09/2025" },
			{ "DD031NBDD", "21/09/2025" },
			{ "DD030NBDD", "14/09/2025" },
			{ "DD029NBDD", "25/04/2026" },
			{ "DD028NSDD", "21/02/2026" },
			{ "DD027NSDD", "01/12/2025" },
			{ "DD026NSDD", "18/03/2026" },
			{ "DD025NSDD", "27/07/2025" },
			{ "DD024NSDD", "12/07/2025" },
			{ "DD023NPDD", "11/07/2025" },
			{ "DD022NSDD", "22/06/2025" },
			{ "DD021NEDD", "06/06/2025" },
			{ "DD020NADD", "25/04/2026" },
			{ "DD019NSDD", "18/04/2026" },
			{ "DD018NSDD", "10/02/2026" },
			{ "DD017NSDD", "09/02/2026" },
			{ "DD016NPDD", "17/11/2025" },
			{ "DD015NSDD", "16/08/2025" },
			{ "DD014NSDD", "27/04/2026" },
			{ "DD013NSDD", "09/03/2026" },
			{ "DD012NPDD", "01/02/2026" },
			{ "DD011NSDD", "26/01/2026" },
			{ "DD010NSDD", "08/01/2024" },
			{ "DD009NSDD", "27/08/2025" },
			{ "DD008NPDD", "01/06/2025" },
			{ "DD007NSDD", "22/12/2024" },
			{ "DD006NSDD", "03/05/2026" },
			{ "DD005NLDD", "05/09/2025" },
			{ "DD004NSDD", "29/08/2025" },
			{ "DD003NLDD", "11/07/2020" },
			{ "DD002NSDD", "14/03/2020" }
		};

		if (!amcDates.TryGetValue(DC_Main.SSRegSrNo ?? "", out string amcDateStr))
		{
#if DEV_MODE
			return; // Unknown serial — allow in dev mode
#else
			DC_Main.MsSoftNoUse = "Y";
			return;
#endif
		}

		DC_Main.AmcEndDate = Microsoft.VisualBasic.CompilerServices.Conversions.ToDate(amcDateStr).AddDays(365.0);
		if ((DC_Main.MsAmcUnlockDay > 0) & (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) < 0))
			AmcFreeDayReset();
		if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) <= 0)
			return;
		Microsoft.VisualBasic.Interaction.MsgBox((object)("Your Amc Period is Over End Date = " + DC_Main.AmcEndDate.ToString() + "...."), (Microsoft.VisualBasic.MsgBoxStyle)0, (object)null);
		if (DC_Main.MsAmcUnlockDay > 0)
		{
			DC_Main.AmcEndDate = DC_Main.AmcEndDate.AddDays(DC_Main.MsAmcUnlockDay);
			if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) > 0)
				System.Windows.Forms.Application.Exit();
		}
		else
			DC_Main.MsSoftNoUse = "Y";
	}

	private void Ajay_Amc()
	{
		// Refactored from giant if/else chain — 96 AMC serial numbers
		var amcDates = new System.Collections.Generic.Dictionary<string, string>
		{
			{ "AK098NLAK", "23/04/2026" },
			{ "AK097NLAK", "15/04/2026" },
			{ "AK096NLAK", "10/03/2026" },
			{ "AK095NAAK", "09/03/2026" },
			{ "AK094NLAK", "21/02/2026" },
			{ "AK093NLAK", "31/01/2026" },
			{ "AK092NBAK", "22/11/2025" },
			{ "AK090NEAK", "16/01/2026" },
			{ "AK089NLAK", "28/10/2025" },
			{ "AK088NPAK", "14/10/2025" },
			{ "AK087NLAK", "11/10/2025" },
			{ "AK086NLAK", "11/10/2025" },
			{ "AK085NBAK", "09/10/2025" },
			{ "AK084NLAK", "07/10/2025" },
			{ "AK083NAAK", "04/10/2025" },
			{ "AK082NLAK", "22/09/2025" },
			{ "AK081NPAK", "16/07/2025" },
			{ "AK080NLAK", "12/07/2025" },
			{ "AK079NLAK", "06/07/2025" },
			{ "AK078NPAK", "04/05/2026" },
			{ "AK077NUAK", "26/06/2025" },
			{ "AK076NLAK", "19/06/2025" },
			{ "AK075NLAK", "04/06/2025" },
			{ "AK074NBAK", "10/05/2026" },
			{ "AK073NUAK", "27/04/2026" },
			{ "AK072NBAK", "23/04/2026" },
			{ "AK071NBAK", "17/04/2026" },
			{ "AK070NLAK", "10/04/2026" },
			{ "AK069NEAK", "31/03/2025" },
			{ "AK068NEAK", "31/03/2025" },
			{ "AK067NBAK", "20/03/2026" },
			{ "AK066NLAK", "11/03/2026" },
			{ "AK065NBAK", "25/01/2026" },
			{ "AK064NBAK", "26/01/2026" },
			{ "AK063NLAK", "21/01/2026" },
			{ "AK062NUAK", "18/01/2026" },
			{ "AK061NLAK", "16/01/2026" },
			{ "AK060NBAK", "16/01/2026" },
			{ "AK059NEAK", "13/01/2026" },
			{ "AK058NBAK", "11/01/2026" },
			{ "AK057NLAK", "10/01/2026" },
			{ "AK056NLAK", "10/01/2026" },
			{ "AK055NLAK", "30/12/2025" },
			{ "AK054NUAK", "15/01/2026" },
			{ "AK053NUAK", "26/12/2025" },
			{ "AK052NSAK", "15/12/2025" },
			{ "AK051NEAK", "31/10/2025" },
			{ "AK050NBAK", "04/10/2025" },
			{ "AK049NPAK", "10/09/2025" },
			{ "AK048NPAK", "10/09/2025" },
			{ "AK047NPAK", "31/07/2025" },
			{ "AK046NBAK", "12/07/2025" },
			{ "AK045NSAK", "05/07/2025" },
			{ "AK044NBAK", "19/06/2024" },
			{ "AK043NSAK", "13/05/2026" },
			{ "AK042NEAK", "31/10/2025" },
			{ "AK041NBAK", "27/04/2026" },
			{ "AK040NSAK", "05/04/2026" },
			{ "AK039NPAK", "15/03/2026" },
			{ "AK038NSAK", "21/02/2026" },
			{ "AK037NPAK", "09/01/2026" },
			{ "AK036NEAK", "02/02/2025" },
			{ "AK035NLAK", "23/01/2026" },
			{ "AK034NPAK", "03/11/2025" },
			{ "AK033NBAK", "02/11/2025" },
			{ "AK032NBAK", "13/09/2025" },
			{ "AK031NLAK", "29/08/2025" },
			{ "AK030NPAK", "30/07/2025" },
			{ "AK029NEAK", "18/07/2025" },
			{ "AK028NSAK", "21/06/2025" },
			{ "AK027NSAK", "12/06/2025" },
			{ "AK026NLAK", "01/06/2025" },
			{ "AK025NLAK", "27/05/2026" },
			{ "AK024NSAK", "26/04/2023" },
			{ "AK023NPAK", "08/04/2026" },
			{ "AK022NSAK", "22/02/2026" },
			{ "AK021NLAK", "28/03/2023" },
			{ "AK020NLAK", "28/03/2026" },
			{ "AK019NEAK", "23/03/2026" },
			{ "AK018NPAK", "06/02/2026" },
			{ "AK017NSAK", "02/01/2026" },
			{ "AK016NPAK", "03/05/2026" },
			{ "AK015NPAK", "28/04/2026" },
			{ "AK014NEAK", "31/03/2023" },
			{ "AK013NEAK", "31/03/2026" },
			{ "AK012NBAK", "25/09/2025" },
			{ "AK011NEAK", "26/12/2025" },
			{ "AK010NPAK", "22/07/2023" },
			{ "AK009NPAK", "31/03/2026" },
			{ "AK008NPAK", "03/02/2026" },
			{ "AK007NEAK", "01/01/2026" },
			{ "AK006NPAK", "26/11/2025" },
			{ "AK005NPAK", "25/11/2025" },
			{ "AK004NEAK", "02/01/2026" },
			{ "AK003NPAK", "13/03/2026" },
			{ "AK002NPAK", "14/03/2023" }
		};

		if (!amcDates.TryGetValue(DC_Main.SSRegSrNo ?? "", out string amcDateStr))
		{
#if DEV_MODE
			return; // Unknown serial — allow in dev mode
#else
			DC_Main.MsSoftNoUse = "Y";
			return;
#endif
		}

		DC_Main.AmcEndDate = Microsoft.VisualBasic.CompilerServices.Conversions.ToDate(amcDateStr).AddDays(365.0);
		if ((DC_Main.MsAmcUnlockDay > 0) & (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) < 0))
			AmcFreeDayReset();
		if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) <= 0)
			return;
		Microsoft.VisualBasic.Interaction.MsgBox((object)("Your Amc Period is Over End Date = " + DC_Main.AmcEndDate.ToString() + "...."), (Microsoft.VisualBasic.MsgBoxStyle)0, (object)null);
		if (DC_Main.MsAmcUnlockDay > 0)
		{
			DC_Main.AmcEndDate = DC_Main.AmcEndDate.AddDays(DC_Main.MsAmcUnlockDay);
			if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) > 0)
				System.Windows.Forms.Application.Exit();
		}
		else
			DC_Main.MsSoftNoUse = "Y";
	}

	private void Devendra_Amc()
	{
		// Refactored from giant if/else chain — 128 AMC serial numbers
		var amcDates = new System.Collections.Generic.Dictionary<string, string>
		{
			{ "DM129NUDM", "31/05/2026" },
			{ "DM128NUDM", "31/05/2026" },
			{ "DM127NUDM", "31/05/2026" },
			{ "DM126NBDG", "27/05/2026" },
			{ "DM125NPDG", "21/05/2026" },
			{ "DM124NPDM", "18/05/2026" },
			{ "DM123NPDG", "06/05/2026" },
			{ "DM122NSDM", "05/05/2026" },
			{ "DM121NEDM", "01/05/2026" },
			{ "DM120NBDM", "01/05/2026" },
			{ "DM119NEDG", "23/04/2026" },
			{ "DM118NBRD", "27/03/2026" },
			{ "DM117NSDM", "06/03/2026" },
			{ "DM116NSDG", "06/03/2026" },
			{ "DM115NBDG", "21/02/2026" },
			{ "DM114NBDG", "20/02/2026" },
			{ "DM113NPDM", "17/02/2026" },
			{ "DM112NBDG", "12/02/2026" },
			{ "DM111NSDM", "11/02/2026" },
			{ "DM110NSDM", "17/01/2026" },
			{ "DM109NSDG", "17/04/2026" },
			{ "DM108NLDM", "15/12/2025" },
			{ "DM107NUDM", "18/12/2025" },
			{ "DM106NBDM", "15/12/2025" },
			{ "DM105NBDG", "01/12/2025" },
			{ "DM104NADM", "07/11/2025" },
			{ "DM103NBDG", "28/10/2025" },
			{ "DM102NBDM", "15/10/2025" },
			{ "DM101NBDM", "10/10/2025" },
			{ "DM100NBDM", "10/10/2025" },
			{ "DM099NBDG", "01/10/2025" },
			{ "DM098NLDM", "26/09/2025" },
			{ "DM097NBDG", "18/09/2025" },
			{ "DM096NLDM", "08/09/2025" },
			{ "DM095NBDM", "03/09/2025" },
			{ "DM094NPDG", "14/08/2025" },
			{ "DM093NBDM", "23/07/2025" },
			{ "DM092NADG", "04/09/2025" },
			{ "DM091NSDG", "15/07/2025" },
			{ "DM090NSDM", "26/06/2026" },
			{ "DM089NBDM", "16/06/2025" },
			{ "DM087NSDM", "15/12/2025" },
			{ "DM086NSDG", "22/05/2025" },
			{ "DM085NBDM", "20/05/2025" },
			{ "DM084NSDM", "05/05/2026" },
			{ "DM083NBDM", "01/05/2026" },
			{ "DM082NBKX", "01/05/2025" },
			{ "DM081NSDM", "25/04/2026" },
			{ "DM080NLDM", "17/04/2026" },
			{ "DM079NADM", "16/04/2026" },
			{ "DM078NEDM", "31/03/2025" },
			{ "DM077NBDG", "21/03/2026" },
			{ "DM076NBDM", "21/03/2025" },
			{ "DM075NBDM", "12/03/2026" },
			{ "DM074NBDM", "24/02/2025" },
			{ "DM073NSDM", "18/02/2026" },
			{ "DM072NUDG", "13/02/2025" },
			{ "DM071NLDM", "07/02/2026" },
			{ "DM070NLDG", "31/01/2026" },
			{ "DM069NBDM", "02/01/2026" },
			{ "DM068NBDM", "31/12/2025" },
			{ "DM067NBDM", "22/12/2024" },
			{ "DM066NEDM", "12/12/2025" },
			{ "DM065NPDG", "06/12/2024" },
			{ "DM064NEDM", "01/04/2026" },
			{ "DM063NSDM", "29/10/2024" },
			{ "DM062NLDG", "07/10/2025" },
			{ "DM061NSDM", "17/02/2026" },
			{ "DM060NLDM", "09/09/2025" },
			{ "DM059NSDG", "31/08/2025" },
			{ "DM058NUDM", "26/05/2026" },
			{ "DM057NEDG", "14/10/2025" },
			{ "DM056NADM", "29/06/2025" },
			{ "DM055NLDG", "24/06/2025" },
			{ "DM054NSDM", "18/06/2025" },
			{ "DM053NSDM", "17/06/2025" },
			{ "DM052NEDM", "30/04/2026" },
			{ "DM051NLDM", "10/04/2026" },
			{ "DM050NPDM", "19/02/2026" },
			{ "DM049NSDM", "01/04/2026" },
			{ "DM048NSDM", "15/07/2025" },
			{ "DM047NSDM", "10/02/2026" },
			{ "DM046NLDM", "09/02/2026" },
			{ "DM045NSDM", "22/01/2026" },
			{ "DM044NBDM", "19/01/2025" },
			{ "DM043NEDM", "15/01/2026" },
			{ "DM042NLDM", "10/01/2026" },
			{ "DM041NEDG", "23/10/2025" },
			{ "DM040NSDM", "20/12/2025" },
			{ "DM039NBDM", "21/05/2026" },
			{ "DM038NSDM", "13/09/2025" },
			{ "DM037NSDM", "19/03/2026" },
			{ "DM036NSDM", "15/07/2023" },
			{ "DM035NPDM", "14/07/2025" },
			{ "DM034NPDM", "14/07/2024" },
			{ "DM033NSDM", "08/07/2025" },
			{ "DM032NADM", "23/06/2025" },
			{ "DM031NSDM", "07/06/2024" },
			{ "DM030NSDM", "25/11/2023" },
			{ "DM029NADM", "05/06/2025" },
			{ "DM028NSDM", "03/06/2026" },
			{ "DM027NSDM", "28/05/2025" },
			{ "DM026NADM", "01/04/2026" },
			{ "DM025NSDM", "08/04/2026" },
			{ "DM024NSDM", "05/04/2026" },
			{ "DM023NLDM", "29/01/2026" },
			{ "DM022NEDM", "22/12/2025" },
			{ "DM021NLDM", "30/03/2026" },
			{ "DM020NSDM", "23/03/2026" },
			{ "DM019NEDM", "01/12/2025" },
			{ "DM018NADM", "18/03/2026" },
			{ "DM017NEDM", "05/04/2026" },
			{ "DM016NPDM", "11/02/2026" },
			{ "DM015NSDM", "04/02/2026" },
			{ "DM014NEDM", "23/01/2026" },
			{ "DM013NEDM", "26/10/2025" },
			{ "DM012NEDM", "30/03/2026" },
			{ "DM011NEDM", "03/01/2026" },
			{ "DM010NADM", "02/01/2026" },
			{ "DM009NADM", "30/11/2025" },
			{ "DM008NSDM", "21/11/2025" },
			{ "DM007NEDM", "31/10/2025" },
			{ "DM006NADM", "09/06/2026" },
			{ "DM005NSDM", "22/09/2025" },
			{ "DM004NSDM", "26/07/2025" },
			{ "DM003NSKS", "23/06/2025" },
			{ "DM002NSDM", "02/04/2026" },
			{ "DM001NSKS", "20/09/2023" }
		};

		if (!amcDates.TryGetValue(DC_Main.SSRegSrNo ?? "", out string amcDateStr))
		{
#if DEV_MODE
			return; // Unknown serial — allow in dev mode
#else
			DC_Main.MsSoftNoUse = "Y";
			return;
#endif
		}

		DC_Main.AmcEndDate = Microsoft.VisualBasic.CompilerServices.Conversions.ToDate(amcDateStr).AddDays(365.0);
		if ((DC_Main.MsAmcUnlockDay > 0) & (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) < 0))
			AmcFreeDayReset();
		if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) <= 0)
			return;
		Microsoft.VisualBasic.Interaction.MsgBox((object)("Your Amc Period is Over End Date = " + DC_Main.AmcEndDate.ToString() + "...."), (Microsoft.VisualBasic.MsgBoxStyle)0, (object)null);
		if (DC_Main.MsAmcUnlockDay > 0)
		{
			DC_Main.AmcEndDate = DC_Main.AmcEndDate.AddDays(DC_Main.MsAmcUnlockDay);
			if (DateTime.Compare(DateTime.Now, DC_Main.AmcEndDate) > 0)
				System.Windows.Forms.Application.Exit();
		}
		else
			DC_Main.MsSoftNoUse = "Y";
	}

	private void RegEntry()
	{
		DC_Main.ExeQuteDc("UPDATE BOOK_IDTL SET AC_CODE = AC_CODE + 1 WHERE MAIN_BOOK = 'PURC RETURN' AND SR_NO = 5");
		DC_Main.RsQry = "SELECT AC_CODE FROM BOOK_IDTL  WHERE MAIN_BOOK = 'PURC RETURN' AND SR_NO = 5";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0 && Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["AC_CODE"])) > 30.0)
		{
			DC_Main.MsSoftDemoName = "This Is Demo Virson";
		}
	}

	private void MS_OPNCOMP_KeyPress(object sender, KeyPressEventArgs e)
	{
		short num;
		checked
		{
			num = (short)Strings.Asc(e.KeyChar);
			num = (short)Strings.Asc(Strings.UCase(Strings.Chr(unchecked((int)num))));
		}
		e.KeyChar = Strings.Chr((int)num);
		if (num == 0 || num == 39)
		{
			e.Handled = true;
		}
	}

	private void tCoCode_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)tCoCode).SelectionStart = 0;
		((TextBoxBase)tCoCode).SelectionLength = Strings.Len(tCoCode.Text);
	}

	private void tYearCode_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)tYearCode).SelectionStart = 0;
		((TextBoxBase)tYearCode).SelectionLength = Strings.Len(tYearCode.Text);
	}

	private void TlcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tlcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		CurProcess = false;
		if ((Operators.CompareString(DC_Main.CurLc, "00", false) != 0) & (Operators.CompareString(tlcCode.Text, "", false) != 0))
		{
			DC_Main.RsQry = "Select * From LOCT_MAST WHERE  CO_CODE = '" + tCoCode.Text + "' AND LC_CODE = '" + tlcCode.Text + "' AND " + DC_Main.CurLc + " = " + tlcCode.Text + " ";
		}
		else if (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0)
		{
			DC_Main.RsQry = "Select * From LOCT_MAST WHERE  CO_CODE = '" + tCoCode.Text + "' AND LC_CODE = '" + tlcCode.Text + "'";
		}
		else if (Operators.CompareString(tlcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From LOCT_MAST WHERE  CO_CODE = '" + tCoCode.Text + "' AND LC_CODE = '" + DC_Main.CurLc + "' AND " + DC_Main.CurLc + " = " + tlcCode.Text + " ";
		}
		else
		{
			DC_Main.RsQry = "Select * From LOCT_MAST WHERE  CO_CODE = '" + tCoCode.Text + "' AND LC_CODE = '" + tlcCode.Text + "'";
		}
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count <= 0)
		{
			if (Operators.CompareString(DC_Main.CurLc, "00", false) != 0)
			{
				DC_Main.RsQry = "Select LC_CODE As CodeL,LC_NAME As NameL,LC_ADD1 As AddressL,LC_CITY As CityL FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.CurLc + "' ";
			}
			else if (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0)
			{
				DC_Main.RsQry = "Select LC_CODE As CodeL,LC_NAME As NameL,LC_ADD1 As AddressL,LC_CITY As CityL FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY LC_CODE";
			}
			else
			{
				DC_Main.RsQry = "Select LC_CODE As CodeL,LC_NAME As NameL,LC_ADD1 As AddressL,LC_CITY As CityL FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.CurLc + "' ";
			}
			DC_Main.RsDg = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[5];
			DC_Main.ColWidth[0] = 70.0;
			DC_Main.ColWidth[1] = 280.0;
			DC_Main.ColWidth[2] = 300.0;
			DC_Main.ColWidth[3] = 250.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tlcCode.Text = DC_Main.ColValue[0];
				lblLcName.Text = DC_Main.ColValue[1];
				DC_Main.MLc_code = tlcCode.Text;
				DC_Main.MLc_Name = DC_Main.ColValue[1];
			}
		}
		else
		{
			lblLcName.Text = Conversions.ToString(DC_Main.Rshlp.Rows[0]["LC_NAME"]);
			DC_Main.MLc_code = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LC_CODE"], (object)""));
			DC_Main.MLc_Name = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LC_NAME"], (object)""));
			((Control)tYearCode).Enabled = true;
			((Control)tYearCode).Focus();
		}
	}

	private void SMS_PACK()
	{
		DC_Main.SmsUser = "";
		DC_Main.SmsId = "";
		DC_Main.SmsPwd = "";
		if (Operators.CompareString(DC_Main.SmsLink, "002", false) == 0)
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM040NPHP", false) == 0)
			{
				DC_Main.SmsUser = "MURLIDHAR";
				DC_Main.SmsId = "JEWELS";
				DC_Main.SmsPwd = "abc123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM017NSHM", false) == 0)
			{
				DC_Main.SmsUser = "SSGOLD";
				DC_Main.SmsId = "JEWELS";
				DC_Main.SmsPwd = "Datacare@123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM033NEPK", false) == 0)
			{
				DC_Main.SmsUser = "ABHUSANJ";
				DC_Main.SmsId = "sSUVRn";
				DC_Main.SmsPwd = "abc123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM026NSPK", false) == 0)
			{
				DC_Main.SmsUser = "bhagwatijwgdham";
				DC_Main.SmsId = "JEWELS";
				DC_Main.SmsPwd = "Datacare@123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM021NEHM", false) == 0)
			{
				DC_Main.SmsUser = "MADHUVAN";
				DC_Main.SmsId = "MDVNGD";
				DC_Main.SmsPwd = "abc123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM073NPHM", false) == 0)
			{
				DC_Main.SmsUser = "ShyamJwss";
				DC_Main.SmsId = "SHYMAL";
				DC_Main.SmsPwd = "abc123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM073NPHM", false) == 0)
			{
				DC_Main.SmsUser = "ShyamJwss";
				DC_Main.SmsId = "SHYMAL";
				DC_Main.SmsPwd = "abc123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM094NEPK", false) == 0)
			{
				DC_Main.SmsUser = "TirupatiJwW";
				DC_Main.SmsId = "TRUPTJ";
				DC_Main.SmsPwd = "abc123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ005NEKJ", false) == 0)
			{
				DC_Main.SmsUser = "SNMAHORNRODA";
				DC_Main.SmsId = "SONAMH";
				DC_Main.SmsPwd = "Datacare@123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK014NEAK", false) == 0)
			{
				DC_Main.SmsUser = "KANGAN";
				DC_Main.SmsId = "KANGAN";
				DC_Main.SmsPwd = "kangan";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DD020NADD", false) == 0)
			{
				DC_Main.SmsUser = "SHRISHYAM";
				DC_Main.SmsId = "SSHYMJ";
				DC_Main.SmsPwd = "abc123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM307NEKU", false) == 0)
			{
				DC_Main.SmsUser = "8b37b75ef95002a3a22738c2bb869e2f";
				DC_Main.SmsId = "SHRLGP";
				DC_Main.SmsPwd = "abc123";
			}
		}
		else if (Operators.CompareString(DC_Main.SmsLink, "012", false) == 0)
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS022NPHG", false) == 0)
			{
				DC_Main.SmsUser = "rudrakshlakadiya";
				DC_Main.SmsId = "RJLKDA";
				DC_Main.SmsPwd = "Delta@123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS012NPHG", false) == 0)
			{
				DC_Main.SmsUser = "daaginadiyodar";
				DC_Main.SmsId = "DAGINA";
				DC_Main.SmsPwd = "delta";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS010NPBU", false) == 0)
			{
				DC_Main.SmsUser = "bhagawatijw";
				DC_Main.SmsId = "BGWATJ";
				DC_Main.SmsPwd = "delta";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS042NPVS", false) == 0)
			{
				DC_Main.SmsUser = "veergoldpalace";
				DC_Main.SmsId = "VIRGLD";
				DC_Main.SmsPwd = "delta";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS021NPVS", false) == 0)
			{
				DC_Main.SmsUser = "KmJeweller";
				DC_Main.SmsId = "JWELRY";
				DC_Main.SmsPwd = "abc123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS038NPHG", false) == 0)
			{
				DC_Main.SmsUser = "kjjewellers";
				DC_Main.SmsId = "KJSONI";
				DC_Main.SmsPwd = "Delta@123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS041NPVS", false) == 0)
			{
				DC_Main.SmsUser = "nandihunsur";
				DC_Main.SmsId = "NANDEE";
				DC_Main.SmsPwd = "delta";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS024NEVS", false) == 0)
			{
				DC_Main.SmsUser = "shreejwmanaramji";
				DC_Main.SmsId = "SJEVST";
				DC_Main.SmsPwd = "Delta@123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS039NPVS", false) == 0)
			{
				DC_Main.SmsUser = "kundanjwashokji";
				DC_Main.SmsId = "KDNJEW";
				DC_Main.SmsPwd = "Delta@123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS052NABU", false) == 0)
			{
				DC_Main.SmsUser = "nkjewels";
				DC_Main.SmsId = "NKJWLS";
				DC_Main.SmsPwd = "Delta@123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS059NEBU", false) == 0)
			{
				DC_Main.SmsUser = "mahaveerniky";
				DC_Main.SmsId = "MAHEVR";
				DC_Main.SmsPwd = "Delta@123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS081NEBU", false) == 0)
			{
				DC_Main.SmsUser = "jagadambajw";
				DC_Main.SmsId = "JAGADM";
				DC_Main.SmsPwd = "Delta@123";
			}
		}
		else if (Operators.CompareString(DC_Main.SmsLink, "022", false) == 0)
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK026NPVK", false) == 0)
			{
				DC_Main.SmsUser = "alankarjew";
				DC_Main.SmsId = "ALNKAR";
				DC_Main.SmsPwd = "Datacare@123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK023NPVK", false) == 0)
			{
				DC_Main.SmsUser = "ankurjw";
				DC_Main.SmsId = "ANKURJ";
				DC_Main.SmsPwd = "vikas123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK021NPVK", false) == 0)
			{
				DC_Main.SmsUser = "murlidharjwchiloda";
				DC_Main.SmsId = "MJEWEL";
				DC_Main.SmsPwd = "vikas123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK033NPVK", false) == 0)
			{
				DC_Main.SmsUser = "arihantjwpune";
				DC_Main.SmsId = "JARHNT";
				DC_Main.SmsPwd = "Datacare@123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM070NEKU", false) == 0)
			{
				DC_Main.SmsUser = "KRISHNAADIPUR";
				DC_Main.SmsId = "KRISNA";
				DC_Main.SmsPwd = "abc123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS022NPHG", false) == 0)
			{
				DC_Main.SmsUser = "rudrakshlakadiya";
				DC_Main.SmsId = "RJLKDA";
				DC_Main.SmsPwd = "Delta@123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS106NPBU", false) == 0)
			{
				DC_Main.SmsUser = "veergolddineshji";
				DC_Main.SmsId = "VEERGO";
				DC_Main.SmsPwd = "Delta@123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK088NPSD", false) == 0)
			{
				DC_Main.SmsUser = "bhumigold";
				DC_Main.SmsId = "GBHUMI";
				DC_Main.SmsPwd = "Datacare@123";
			}
		}
		else if (Operators.CompareString(DC_Main.SmsLink, "032", false) == 0)
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DH007NPDH", false) == 0)
			{
				DC_Main.SmsUser = "UMIYAJWK";
				DC_Main.SmsId = "UMIYAJ";
				DC_Main.SmsPwd = "D1211";
			}
		}
		else if (Operators.CompareString(DC_Main.SmsLink, "042", false) == 0)
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK007NEAK", false) == 0)
			{
				DC_Main.SmsUser = "603f35133d032";
				DC_Main.SmsId = "KALASJ";
				DC_Main.SmsPwd = "oom7WQF*";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK004NPAK", false) == 0)
			{
				DC_Main.SmsUser = "navkarjewellers";
				DC_Main.SmsId = "NVKRJW";
				DC_Main.SmsPwd = "navkarjewellers";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK009NPAK", false) == 0)
			{
				DC_Main.SmsUser = "prakashjw";
				DC_Main.SmsId = "PJVJEW";
				DC_Main.SmsPwd = "Prakash@123";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK008NPAK", false) == 0)
			{
				DC_Main.SmsUser = "60fff411bc0e5";
				DC_Main.SmsId = "MRJPLT";
				DC_Main.SmsPwd = "Mangal@1211";
			}
		}
	}

	private void Estmate_Reset()
	{
		DC_Main.MsEstmateReset = "N";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS010NPBU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS036NSBU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DH007NPDH", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS046NPBU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DD001NSDD", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS052NABU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS059NEBU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM121NSKU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS066NSBU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM076NPKU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS088NPBU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS026NSVS", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM161NSKU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS066NSBU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS139NSBU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM230NEKU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM208NEPK", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM222NSKU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM283NEKU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DD020NADD", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DD008NPDD", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM333NPHM", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM336NPHM", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AK028NSAK", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS169NEBU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AK022NSAK", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AK042NEAK", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM135NEKU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM383NSKU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AK052NSAK", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DD036NUDD", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM585NUHM", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM417NSHM", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AK077NUAK", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS310NUBU", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AK054NUAK", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK316NADS", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
		if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
		{
			DC_Main.MsEstmateReset = "Y";
		}
	}

	private void BulPorcess()
	{
		DC_Main.MsBulProcess = "N";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK089NSVK", false) == 0)
		{
			DC_Main.MsBulProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM369NSHM", false) == 0)
		{
			DC_Main.MsBulProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK154NSVK", false) == 0)
		{
			DC_Main.MsBulProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ049NSKJ", false) == 0)
		{
			DC_Main.MsBulProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM288NPPK", false) == 0)
		{
			DC_Main.MsBulProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ052NSKJ", false) == 0)
		{
			DC_Main.MsBulProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK311NBVK", false) == 0)
		{
			DC_Main.MsBulProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM741NSSR", false) == 0)
		{
			DC_Main.MsBulProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM777NBKU", false) == 0)
		{
			DC_Main.MsBulProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
		{
			DC_Main.MsBulProcess = "Y";
		}
	}

	private void MfgType()
	{
		DC_Main.MsMfgType = "";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS127NSVS", false) == 0)
		{
			DC_Main.MsMfgType = "B";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK080NAVK", false) == 0)
		{
			DC_Main.MsMfgType = "J";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK134NEVK", false) == 0)
		{
			DC_Main.MsMfgType = "J";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0)
		{
			DC_Main.MsMfgType = "J";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK165NEVK", false) == 0)
		{
			DC_Main.MsMfgType = "J";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM446NAPK", false) == 0)
		{
			DC_Main.MsMfgType = "J";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK166NEVK", false) == 0)
		{
			DC_Main.MsMfgType = "J";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK229NSVK", false) == 0)
		{
			DC_Main.MsMfgType = "J";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK273NPVK", false) == 0)
		{
			DC_Main.MsMfgType = "J";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK322NSVK", false) == 0)
		{
			DC_Main.MsMfgType = "J";
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "DM053NSDM", false) == 0) & (DateTime.Compare(DateAndTime.Now, Conversions.ToDate("12/03/2025")) < 0))
		{
			DC_Main.MsMfgType = "J";
		}
		DC_Main.MsOrderWithJadtar = "N";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK229NSVK", false) == 0)
		{
			DC_Main.MsOrderWithJadtar = "Y";
			DC_Main.MsMfgOneFormEntry = "N";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM429NSKU", false) == 0)
		{
			DC_Main.MsMfgType = "M";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DM017NEDM", false) == 0)
		{
			DC_Main.MsMfgType = "M";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK195NEPH", false) == 0)
		{
			DC_Main.MsMfgType = "M";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS205NSBU", false) == 0)
		{
			DC_Main.MsMfgType = "M";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
		{
			DC_Main.MsMfgType = "M";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK300NUST", false) == 0)
		{
			DC_Main.MsMfgType = "M";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DM061NSDM", false) == 0)
		{
			DC_Main.MsMfgType = "M";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK321NEPH", false) == 0)
		{
			DC_Main.MsMfgType = "M";
		}
		DC_Main.MsMfgOneFormEntry = "Y";
		DC_Main.MsMfgWithOrder = "N";
		DC_Main.MsMfgWithLedger = "N";
		DC_Main.MsMfgWithLot = "N";
		DC_Main.MsMeltingLotGenrate = "N";
		DC_Main.MsItmWitLotStk = "Y";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "J", false) == 0)
		{
			DC_Main.MsMfgType = "J";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "K", false) == 0)
		{
			DC_Main.MsMfgType = "M";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "M", false) == 0)
		{
			DC_Main.MsMfgType = "M";
			DC_Main.MsMfgWithOrder = "Y";
			DC_Main.MsMfgOneFormEntry = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "C", false) == 0)
		{
			DC_Main.MsMfgType = "M";
			DC_Main.MsMfgWithOrder = "Y";
			DC_Main.MsMfgOneFormEntry = "Y";
			DC_Main.MsItmWitLotStk = "Y";
		}
		if (Operators.CompareString(DC_Main.MsMfgType, "M", false) == 0)
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
			{
				DC_Main.MsMfgWithLot = "Y";
				DC_Main.MsMfgOneFormEntry = "N";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK321NEPH", false) == 0)
			{
				DC_Main.MsMfgWithLot = "Y";
				DC_Main.MsMfgOneFormEntry = "N";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM017NEDM", false) == 0)
			{
				DC_Main.MsMfgWithLedger = "Y";
			}
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "DM017NEDM", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VS205NSBU", false) == 0))
			{
				DC_Main.MsMfgWithOrder = "Y";
				DC_Main.MsMfgOneFormEntry = "N";
			}
			if (Strings.Len(DC_Main.SSRegSrNo) == 1)
			{
				DC_Main.MsMfgWorkType = DC_Main.SSRegSrNo;
			}
			if (Operators.CompareString(DC_Main.MsMfgWorkType, "K", false) == 0)
			{
				DC_Main.MsMfgOneFormEntry = "N";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM061NSDM", false) == 0)
			{
				DC_Main.MsMfgWorkType = "M";
			}
			if (Operators.CompareString(DC_Main.MsMfgWorkType, "M", false) == 0)
			{
				DC_Main.MsMfgWithOrder = "Y";
				DC_Main.MsMfgOneFormEntry = "Y";
				DC_Main.MsMeltingLotGenrate = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK300NUST", false) == 0)
			{
				DC_Main.MsMfgWorkType = "C";
			}
			if (Operators.CompareString(DC_Main.MsMfgWorkType, "C", false) == 0)
			{
				DC_Main.MsMfgWithOrder = "Y";
				DC_Main.MsMfgOneFormEntry = "Y";
				DC_Main.MsItmWitLotStk = "Y";
			}
			if (Operators.CompareString(DC_Main.MsMfgType, "M", false) == 0)
			{
				DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_VIEW = 'Y' WHERE MAIN_SRNO = '02' AND SM_MAIN_CODE = '24' ");
			}
		}
		DC_Main.MsItmMfg = "N";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "I", false) == 0)
		{
			DC_Main.MsItmMfg = "Y";
		}
	}

	private void BDataReset()
	{
		DC_Main.BAllDataReSet = "N";
		DC_Main.MsMasterResetAllData = "N";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK109NEVK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK149NEVK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK165NEVK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK166NEVK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK093NAVK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK221NEVK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK128NEVK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK183NEPH", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK250NEPH", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS222NEVS", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS170NABU", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM530NEHP", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK133NEVK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK083NASD", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ023NEKJ", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK297NEPH", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK267NEPH", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK137NEVK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK167NESD", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DM026NADM", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK087NASD", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS001NAVS", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK017NASD", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM480NAKU", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ024NEKJ", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK179NAVK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AK090NEAK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK315NEVK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK317NAPH", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK318NAPH", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK222NAPH", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK319NEPH", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK320NAPH", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK321NEPH", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK146NEVK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM178NEPK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM387NEPK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DM018NADM", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DM054NSDM", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
			DC_Main.MsMasterResetAllData = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DM003NSKS", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
			DC_Main.MsMasterResetAllData = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK176NESD", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
			DC_Main.MsMasterResetAllData = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DM037NSDM", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
			DC_Main.MsMasterResetAllData = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK052NEVK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
			DC_Main.MsMasterResetAllData = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK134NEVK", false) == 0)
		{
			DC_Main.BAllDataReSet = "Y";
			DC_Main.MsMasterResetAllData = "Y";
		}
	}

	private void CrmProcess()
	{
		DC_Main.MsCrmProcess = "N";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK115NEVK", false) == 0)
		{
			DC_Main.MsCrmProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS055NEVS", false) == 0)
		{
			DC_Main.MsCrmProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DM012NEDM", false) == 0)
		{
			DC_Main.MsCrmProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS232NEBU", false) == 0)
		{
			DC_Main.MsCrmProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ035NEKJ", false) == 0)
		{
			DC_Main.MsCrmProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS182NEBU", false) == 0)
		{
			DC_Main.MsCrmProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "E", false) == 0)
		{
			DC_Main.MsCrmProcess = "Y";
		}
		if (Operators.CompareString(DC_Main.MsCrmProcess, "Y", false) == 0)
		{
			string text = "CrmData";
			DC_Main.Crm.ConnectionString = ("Data Source=" + DC_Main.SqlServer + ";Initial Catalog=" + text + ";Persist Security Info=True;User ID=" + DC_Main.SqlId + ";Password=" + DC_Main.SqlPwd) ?? "";
		}
	}

	private void SoftHang()
	{
		if (Versioned.IsNumeric((object)Strings.Mid(DC_Main.SqlServer, 1, 2)) && Operators.CompareString(DC_Main.SSRegSrNo, "VK056NEVK", false) == 0 && Conversion.Val(DC_Main.MCo_code) > 5.0)
		{
			DC_Main.MsSoftHang = "Y";
		}
	}

	private void MailSendOpen()
	{
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM637NEHM", false) == 0)
		{
			DC_Main.MsEmailOpen = true;
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "E", false) == 0)
		{
			DC_Main.MsEmailOpen = true;
		}
	}

	private void AppSchm()
	{
		AppDgGold();
		DC_Main.MsAppSchem = "N";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AB000NEAB", false) == 0)
		{
			DC_Main.MsAppSchem = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS300NUBU", false) == 0)
		{
			DC_Main.MsAppSchem = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DM104NADM", false) == 0)
		{
			DC_Main.MsAppSchem = "Y";
		}
	}

	private void AppDgGold()
	{
		DC_Main.MsAppDgGold = "N";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AB000NEAB", false) == 0)
		{
			DC_Main.MsAppDgGold = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS300NUBU", false) == 0)
		{
			DC_Main.MsAppDgGold = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DM104NADM", false) == 0)
		{
			DC_Main.MsAppDgGold = "Y";
		}
	}

	private void NextAi()
	{
		DC_Main.MsNextAi = "N";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AB000NEAB", false) == 0)
		{
			DC_Main.MsNextAi = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS209NAVS", false) == 0)
		{
			DC_Main.MsNextAi = "Y";
			if (Operators.CompareString(Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy"), Strings.Format((object)Conversions.ToDate("30/12/2025").AddDays(31.0), "dd/MM/yyyy"), false) == 0)
			{
				DC_Main.MsNextAi = "N";
			}
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM135NEKU", false) == 0)
		{
			DC_Main.MsNextAi = "Y";
			if (Operators.CompareString(Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy"), Strings.Format((object)Conversions.ToDate("30/01/2026").AddDays(365.0), "dd/MM/yyyy"), false) == 0)
			{
				DC_Main.MsNextAi = "N";
			}
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM198NEPK", false) == 0)
		{
			DC_Main.MsNextAi = "Y";
			if (Operators.CompareString(Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy"), Strings.Format((object)Conversions.ToDate("05/02/2026").AddDays(365.0), "dd/MM/yyyy"), false) == 0)
			{
				DC_Main.MsNextAi = "N";
			}
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VS222NEVS", false) == 0)
		{
			DC_Main.MsNextAi = "Y";
			if (Operators.CompareString(Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy"), Strings.Format((object)Conversions.ToDate("06/02/2026").AddDays(365.0), "dd/MM/yyyy"), false) == 0)
			{
				DC_Main.MsNextAi = "N";
			}
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK245NSPH", false) == 0)
		{
			DC_Main.MsNextAi = "Y";
			if (Operators.CompareString(Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy"), Strings.Format((object)Conversions.ToDate("19/02/2026").AddDays(365.0), "dd/MM/yyyy"), false) == 0)
			{
				DC_Main.MsNextAi = "N";
			}
		}
	}

	private void WappApi()
	{
		DC_Main.MsWappApiActive = "N";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AB000NEAB", false) == 0)
		{
			DC_Main.MsWappApiActive = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DM000NEAN", false) == 0)
		{
			DC_Main.MsWappApiActive = "Y";
		}
		checked
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK056NLAK", false) == 0)
			{
				DC_Main.MsWappApiActive = "Y";
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/03/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					DC_Main.MsWappApiActive = "N";
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK095NAAK", false) == 0)
			{
				DC_Main.MsWappApiActive = "Y";
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("06/04/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					DC_Main.MsWappApiActive = "N";
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK028NEVK", false) == 0)
			{
				DC_Main.MsWappApiActive = "Y";
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("13/04/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					DC_Main.MsWappApiActive = "N";
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
			{
				DC_Main.MsWappApiActive = "Y";
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("15/05/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					DC_Main.MsWappApiActive = "N";
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM269NEHP", false) == 0)
			{
				DC_Main.MsWappApiActive = "Y";
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("29/05/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					DC_Main.MsWappApiActive = "N";
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM773NBPK", false) == 0)
			{
				DC_Main.MsWappApiActive = "Y";
				DC_Main.MsWappEndDay = (int)DateAndTime.DateDiff((DateInterval)4, DateAndTime.Now, Conversions.ToDate("06/06/2026").AddDays(366.0), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
				DC_Main.MsWappMember = true;
				if (DC_Main.MsWappEndDay <= 0)
				{
					DC_Main.MsWappApiActive = "N";
				}
			}
		}
	}

	private void OlocarActive()
	{
		DC_Main.MsOlocarActive = "N";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AB000NEAB", false) == 0)
		{
			DC_Main.MsOlocarActive = "Y";
			DC_Main.MsOLocerKey = "f05d2d7eb771c88ce1314e43ef658e9d";
			DC_Main.MsOLocerVal = "73fde2f22075b389fdb69cb3f5db8627";
			if (Operators.CompareString(Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy"), Strings.Format((object)Conversions.ToDate("14/04/2026").AddDays(365.0), "dd/MM/yyyy"), false) == 0)
			{
				DC_Main.MsOlocarActive = "N";
			}
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AK007NEAK", false) == 0)
		{
			DC_Main.MsOlocarActive = "Y";
			DC_Main.MsOLocerKey = "0eb4fc2230b263a2b47f7c01dc0919b3";
			DC_Main.MsOLocerVal = "4a6e37b4ac05a428bb5d4ae153e27ba8";
			if (Operators.CompareString(Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy"), Strings.Format((object)Conversions.ToDate("14/04/2026").AddDays(365.0), "dd/MM/yyyy"), false) == 0)
			{
				DC_Main.MsOlocarActive = "N";
			}
		}
	}

	private void FanSaleOpen()
	{
		DC_Main.FanMenuOpen = "N";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AB000NEAB", false) == 0)
		{
			DC_Main.FanMenuOpen = "Y";
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM190NEKU", false) == 0)
		{
			DC_Main.FanMenuOpen = "Y";
		}
	}

	private void LastYearTagSiresCantinu()
	{
		DC_Main.MsLastYearTagSires = "N";
		switch (DC_Main.SSRegSrNo)
		{
		case "VS054NEVS":
		case "KJ012NEKJ":
		case "HM553NBHM":
		case "VS098NSHG":
		case "HM202NEKU":
		case "HM244NEKU":
		case "VK142NEVK":
		case "VK067NPVK":
		case "HM126NSKU":
			DC_Main.MsLastYearTagSires = "Y";
			break;
		}
	}

	private void RendomTagSet()
	{
		if (Strings.Len(DC_Main.SSRegSrNo) != 1)
		{
			Module_Save.MsRendomTag = "N";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK317NAPH", false) == 0)
			{
				Module_Save.MsRendomTag = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK318NAPH", false) == 0)
			{
				Module_Save.MsRendomTag = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK222NAPH", false) == 0)
			{
				Module_Save.MsRendomTag = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK319NEPH", false) == 0)
			{
				Module_Save.MsRendomTag = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK320NAPH", false) == 0)
			{
				Module_Save.MsRendomTag = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK321NEPH", false) == 0)
			{
				Module_Save.MsRendomTag = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM178NEPK", false) == 0)
			{
				Module_Save.MsRendomTag = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK179NAVK", false) == 0)
			{
				Module_Save.MsRendomTag = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM387NEPK", false) == 0)
			{
				Module_Save.MsRendomTag = "Y";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM198NEPK", false) == 0)
			{
				Module_Save.MsRendomTag = "Y";
			}
		}
	}

	private void FildInsert()
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000b;
				case 671:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_000b;
						case 3:
							goto IL_0018;
						case 4:
							goto IL_0025;
						case 5:
							goto IL_0038;
						case 6:
							goto IL_0045;
						case 7:
							goto IL_0052;
						case 8:
							goto IL_005f;
						case 9:
							goto IL_006c;
						case 10:
							goto IL_007a;
						case 11:
							goto IL_0088;
						case 12:
							goto IL_009e;
						case 13:
							goto IL_00ac;
						case 14:
							goto IL_00ba;
						case 15:
							goto IL_00d0;
						case 16:
							goto IL_00de;
						case 17:
							goto IL_00ec;
						case 18:
							goto IL_00fa;
						case 19:
							goto IL_0110;
						case 20:
							goto IL_011e;
						case 21:
							goto IL_012c;
						case 22:
							goto IL_0142;
						case 23:
							goto IL_0150;
						case 24:
							goto IL_015e;
						case 25:
							goto IL_0174;
						case 26:
							goto IL_0182;
						case 27:
							goto IL_0190;
						case 28:
							goto IL_01a6;
						case 29:
							goto IL_01b4;
						case 30:
							goto IL_01c2;
						case 31:
							goto IL_01d8;
						case 32:
							goto IL_01e6;
						case 33:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 34:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_01c2:
					num2 = 30;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_01d8;
					}
					goto IL_01e6;
					IL_01d8:
					num2 = 31;
					DC_Main.Dc.Close();
					goto IL_01e6;
					IL_01b4:
					num2 = 29;
					DC_Main.ExeQuteDc("ALTER TABLE BAR_IDTL ADD KR_LESS_WT FLOAT Not NULL Default 0");
					goto IL_01c2;
					IL_01e6:
					num2 = 32;
					DC_Main.ExeQuteDc("ALTER TABLE SL_DATA ADD LDR_CODE VARCHAR(10)Not NULL DEFAULT ''");
					break;
					IL_000b:
					num2 = 2;
					DC_Main.ExeQuteDc("ALTER TABLE BOOK_DATA ADD WITH_MOBILE_ENTRY VARCHAR(1)Not NULL DEFAULT 'N'");
					goto IL_0018;
					IL_0018:
					num2 = 3;
					DC_Main.ExeQuteDc("ALTER TABLE PR_DETL ADD TAG_NWT FLOAT Not NULL Default 0");
					goto IL_0025;
					IL_0025:
					num2 = 4;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0038;
					}
					goto IL_0045;
					IL_0038:
					num2 = 5;
					DC_Main.Dc.Close();
					goto IL_0045;
					IL_0045:
					num2 = 6;
					DC_Main.ExeQuteDc("ALTER TABLE MFG_ISU_REC ADD LAST_IR_TYPE VARCHAR(1)Not NULL DEFAULT ''");
					goto IL_0052;
					IL_0052:
					num2 = 7;
					DC_Main.ExeQuteDc("ALTER TABLE MFG_DETL ADD LAST_IR_TYPE VARCHAR(1)Not NULL DEFAULT ''");
					goto IL_005f;
					IL_005f:
					num2 = 8;
					DC_Main.ExeQuteDc("ALTER TABLE MLT_DETL ADD RTN_IT_CODE VARCHAR(6)Not NULL DEFAULT '',RTN_WT FLOAT Not NULL DEFAULT 0,MLT_WT FLOAT Not NULL DEFAULT 0");
					goto IL_006c;
					IL_006c:
					num2 = 9;
					DC_Main.ExeQuteDc("ALTER TABLE MFG_DETL ADD CHOL_IT_CODE VARCHAR(6)Not NULL DEFAULT ''");
					goto IL_007a;
					IL_007a:
					num2 = 10;
					DC_Main.ExeQuteDc("ALTER TABLE BOOK_DATA ALTER COLUMN BOOK_SR_NAME VARCHAR(15)");
					goto IL_0088;
					IL_0088:
					num2 = 11;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_009e;
					}
					goto IL_00ac;
					IL_009e:
					num2 = 12;
					DC_Main.Dc.Close();
					goto IL_00ac;
					IL_00ac:
					num2 = 13;
					DC_Main.ExeQuteDc("ALTER TABLE CUT_DETL ADD ITM_NWT FLOAT Not NULL Default 0,ITM_TOUCH FLOAT Not NULL Default 0");
					goto IL_00ba;
					IL_00ba:
					num2 = 14;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_00d0;
					}
					goto IL_00de;
					IL_00d0:
					num2 = 15;
					DC_Main.Dc.Close();
					goto IL_00de;
					IL_00de:
					num2 = 16;
					DC_Main.ExeQuteDc("ALTER TABLE UPI_DATA ADD OLD_VCH_NO VARCHAR(10)Not NULL DEFAULT '',NEW_VCH_NO VARCHAR(10)Not NULL DEFAULT ''");
					goto IL_00ec;
					IL_00ec:
					num2 = 17;
					DC_Main.ExeQuteDc("ALTER TABLE CUT_DATA ADD DISC_PRC FLOAT Not NULL Default 0,DISC_AMT FLOAT Not NULL Default 0");
					goto IL_00fa;
					IL_00fa:
					num2 = 18;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0110;
					}
					goto IL_011e;
					IL_0110:
					num2 = 19;
					DC_Main.Dc.Close();
					goto IL_011e;
					IL_011e:
					num2 = 20;
					DC_Main.ExeQuteDc("ALTER TABLE LBR_DATA ADD CONV_RATE FLOAT Not NULL Default 0,CONV_PRC FLOAT Not NULL Default 0");
					goto IL_012c;
					IL_012c:
					num2 = 21;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0142;
					}
					goto IL_0150;
					IL_0142:
					num2 = 22;
					DC_Main.Dc.Close();
					goto IL_0150;
					IL_0150:
					num2 = 23;
					DC_Main.ExeQuteDc("ALTER TABLE PR_DETL ADD KUNDAN_WT FLOAT Not NULL Default 0,KUNDAN_TOUCH FLOAT Not NULL Default 0,KUNDAN_FINE FLOAT Not NULL Default 0");
					goto IL_015e;
					IL_015e:
					num2 = 24;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_0174;
					}
					goto IL_0182;
					IL_0174:
					num2 = 25;
					DC_Main.Dc.Close();
					goto IL_0182;
					IL_0182:
					num2 = 26;
					DC_Main.ExeQuteDc("ALTER TABLE KR_DETL ADD KUNDAN_WT FLOAT Not NULL Default 0,KUNDAN_TOUCH FLOAT Not NULL Default 0,KUNDAN_FINE FLOAT Not NULL Default 0");
					goto IL_0190;
					IL_0190:
					num2 = 27;
					if (DC_Main.Dc.State == ConnectionState.Open)
					{
						goto IL_01a6;
					}
					goto IL_01b4;
					IL_01a6:
					num2 = 28;
					DC_Main.Dc.Close();
					goto IL_01b4;
					end_IL_0001_2:
					break;
				}
				num2 = 33;
				DC_Main.ExeQuteDc("ALTER TABLE SL_DETL_RTN ADD TAG_LBR_CODE VARCHAR(4)Not NULL DEFAULT ''");
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 671;
				continue;
			}
			throw ProjectData.CreateProjectError(-2146828237);
			continue;
			end_IL_0001_3:
			break;
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}
}
