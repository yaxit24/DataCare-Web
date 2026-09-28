using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class UT_USER_REQUEST : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private SimpleButton _BtnSave;

	private Control CurActCtrl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlBotam")]
	private virtual FlowLayoutPanel _PnlBotam;

	internal virtual FlowLayoutPanel PnlBotam
	{
		get
		{
			return _PnlBotam;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlBotam = value;
		}
	}

	internal virtual SimpleButton BtnExit
	{
		[CompilerGenerated]
		get
		{
			return _BtnExit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnExit_Click;
			SimpleButton val = _BtnExit;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnExit = value;
			val = _BtnExit;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnSave
	{
		[CompilerGenerated]
		get
		{
			return _BtnSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSave_Click;
			SimpleButton val = _BtnSave;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSave = value;
			val = _BtnSave;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RadioDelete")]
	private virtual RadioButton _RadioDelete;

	internal virtual RadioButton RadioDelete
	{
		get
		{
			return _RadioDelete;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_RadioDelete = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("RadioEdit")]
	private virtual RadioButton _RadioEdit;

	internal virtual RadioButton RadioEdit
	{
		get
		{
			return _RadioEdit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_RadioEdit = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label4")]
	private virtual Label _Label4;

	internal virtual Label Label4
	{
		get
		{
			return _Label4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label4 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItDesc")]
	private virtual TextBox _tItDesc;

	internal virtual TextBox tItDesc
	{
		get
		{
			return _tItDesc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tItDesc = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblBook")]
	private virtual Label _lblBook;

	internal virtual Label lblBook
	{
		get
		{
			return _lblBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblBook = value;
		}
	}

	public UT_USER_REQUEST()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((Form)this).Load += UT_USER_REQUEST_Load;
		((Control)this).KeyDown += new KeyEventHandler(UT_USER_REQUEST_KeyDown);
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
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected O, but got Unknown
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Expected O, but got Unknown
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Expected O, but got Unknown
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Expected O, but got Unknown
		//IL_05bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c9: Expected O, but got Unknown
		//IL_067e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_USER_REQUEST));
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnSave = new SimpleButton();
		Label4 = new Label();
		tItDesc = new TextBox();
		RadioEdit = new RadioButton();
		RadioDelete = new RadioButton();
		lblBook = new Label();
		((Control)PnlBotam).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Panel)PnlBotam).BorderStyle = (BorderStyle)1;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 257);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(408, 47);
		((Control)PnlBotam).TabIndex = 2;
		((BaseStyleControl)BtnExit).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnExit).DialogResult = (DialogResult)2;
		((ImageCollectionImageOptions)BtnExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExit.ImageOptions.SvgImage");
		((Control)BtnExit).Location = new Point(312, 3);
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((Control)BtnExit).Size = new Size(91, 37);
		((Control)BtnExit).TabIndex = 25;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		((Control)BtnSave).Location = new Point(215, 3);
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((Control)BtnSave).Size = new Size(91, 37);
		((Control)BtnSave).TabIndex = 22;
		BtnSave.Text = "&Save";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(11, 40);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(106, 20);
		((Control)Label4).TabIndex = 3;
		Label4.Text = "Edit Remark";
		Label4.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tItDesc).BackColor = Color.White;
		((Control)tItDesc).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tItDesc).Location = new Point(13, 69);
		((TextBoxBase)tItDesc).MaxLength = 250;
		tItDesc.Multiline = true;
		((Control)tItDesc).Name = "tItDesc";
		tItDesc.ScrollBars = (ScrollBars)2;
		((Control)tItDesc).Size = new Size(384, 144);
		((Control)tItDesc).TabIndex = 0;
		((ButtonBase)RadioEdit).AutoSize = true;
		RadioEdit.Checked = true;
		((Control)RadioEdit).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)RadioEdit).Location = new Point(70, 223);
		((Control)RadioEdit).Name = "RadioEdit";
		((Control)RadioEdit).Size = new Size(108, 24);
		((Control)RadioEdit).TabIndex = 1;
		RadioEdit.TabStop = true;
		((ButtonBase)RadioEdit).Text = "Edit Request";
		((ButtonBase)RadioEdit).UseVisualStyleBackColor = true;
		((ButtonBase)RadioDelete).AutoSize = true;
		((Control)RadioDelete).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)RadioDelete).Location = new Point(225, 224);
		((Control)RadioDelete).Name = "RadioDelete";
		((Control)RadioDelete).Size = new Size(126, 24);
		((Control)RadioDelete).TabIndex = 1;
		((ButtonBase)RadioDelete).Text = "Delete Request";
		((ButtonBase)RadioDelete).UseVisualStyleBackColor = true;
		((Control)lblBook).BackColor = Color.SandyBrown;
		lblBook.BorderStyle = (BorderStyle)2;
		((Control)lblBook).Dock = (DockStyle)1;
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).Font = new Font("Segoe UI", 14.25f);
		((Control)lblBook).ForeColor = Color.FromArgb(255, 255, 192);
		lblBook.ImeMode = (ImeMode)0;
		((Control)lblBook).Location = new Point(0, 0);
		((Control)lblBook).Name = "lblBook";
		((Control)lblBook).Size = new Size(408, 31);
		((Control)lblBook).TabIndex = 4;
		lblBook.Text = "User Request";
		lblBook.TextAlign = (ContentAlignment)32;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.Gainsboro;
		((Form)this).ClientSize = new Size(408, 304);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)RadioDelete);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)RadioEdit);
		((Control)this).Controls.Add((Control)(object)tItDesc);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Control)this).Name = "UT_USER_REQUEST";
		((Form)this).StartPosition = (FormStartPosition)4;
		((Form)this).Text = "User Request";
		((Form)this).TopMost = true;
		((Control)PnlBotam).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(tItDesc.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Insert Reseon For Edit Or Delete in Remarks...", (MsgBoxStyle)0, (object)null);
			((Control)tItDesc).Focus();
			return;
		}
		DC_Main.ExeQuteDc("DELETE FROM USER_REQUEST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MsReqBook + "' AND VCH_NO = '" + DC_Main.MsReqVch + "' ");
		DC_Main.RsQry = "SELECT A.CO_BOOK,A.VCH_NO,A.VCH_DATE,B.AC_CODE,B.AC_NAME,A.MAIN_USER FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MsReqBook + "' AND A.VCH_NO = '" + DC_Main.MsReqVch + "' AND A.AC_CODE = '" + DC_Main.MsReqAc + "'  GROUP BY A.CO_BOOK,A.VCH_NO,A.VCH_DATE,B.AC_CODE,B.AC_NAME,A.MAIN_USER  UNION ALL SELECT C.CO_BOOK,C.VCH_NO,C.VCH_DATE,D.AC_CODE,D.AC_NAME,C.MAIN_USER FROM MAIN_STOCK AS C LEFT JOIN AC_MAST AS D ON C.CO_CODE = D.CO_CODE AND C.AC_CODE = D.AC_CODE WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND C.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND C.CO_BOOK = '" + DC_Main.MsReqBook + "' AND C.VCH_NO = '" + DC_Main.MsReqVch + "' AND C.AC_CODE = '" + DC_Main.MsReqAc + "' GROUP BY C.CO_BOOK,C.VCH_NO,C.VCH_DATE,D.AC_CODE,D.AC_NAME,C.MAIN_USER ";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count > 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO USER_REQUEST(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,AC_CODE,AC_NAME,TOT_AMT,TOT_FINE,ITM_TYPE,EMP_CODE,USER_NAME,EDIT_USER,EDIT_RMARK,REQ_TIME,REQ_TYPE,PARMATION_TYPE)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','"), dataTable.Rows[0]["CO_BOOK"]), (object)""), (object)"','"), dataTable.Rows[0]["VCH_NO"]), (object)""), (object)"','"), (object)Strings.Format((object)Conversions.ToDate(dataTable.Rows[0]["VCH_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), (object)DC_Main.MsReqAc), (object)"','"), dataTable.Rows[0]["AC_NAME"]), (object)""), (object)"',0,0,'','','"), dataTable.Rows[0]["MAIN_USER"]), (object)""), (object)"','"), (object)DC_Main.MsReqUser), (object)"', '"), (object)tItDesc.Text), (object)"','"), (object)Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:MM")), (object)"','"), Interaction.IIf(RadioEdit.Checked, (object)"E", (object)"D")), (object)"','P')"));
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		DC_Main.MsReqBook = "";
		DC_Main.MsReqVch = "";
		DC_Main.MsReqUser = "";
		DC_Main.MsReqAc = "";
		tItDesc.Text = "";
		Interaction.MsgBox((object)"Request Sent Successfully...", (MsgBoxStyle)0, (object)null);
		((Form)this).Close();
	}

	private void UT_USER_REQUEST_Load(object sender, EventArgs e)
	{
		((Control)this).SuspendLayout();
		((Control)this).ResumeLayout();
		ColorConverter colorConverter = new ColorConverter();
		if (DC_Main.MsCoTheme == 2)
		{
			((Form)this).BackColor = Color.Silver;
			Label obj = lblBook;
			object? obj2 = colorConverter.ConvertFromString("MistyRose");
			((Control)obj).BackColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
			Label obj3 = lblBook;
			object? obj4 = colorConverter.ConvertFromString("64, 0, 64");
			((Control)obj3).ForeColor = ((obj4 != null) ? ((Color)obj4) : default(Color));
			FlowLayoutPanel pnlBotam = PnlBotam;
			object? obj5 = colorConverter.ConvertFromString("MistyRose");
			((Control)pnlBotam).BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
		}
		else if (DC_Main.MsCoTheme == 3)
		{
			object? obj6 = colorConverter.ConvertFromString("200, 205, 210");
			((Form)this).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
			((Control)lblBook).BackColor = Color.SlateGray;
			((Control)lblBook).ForeColor = Color.White;
			((Control)PnlBotam).BackColor = Color.SlateGray;
		}
		else if (DC_Main.MsCoTheme == 4)
		{
			object? obj7 = colorConverter.ConvertFromString("205, 220, 220");
			((Form)this).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
			Label obj8 = lblBook;
			object? obj9 = colorConverter.ConvertFromString("CadetBlue");
			((Control)obj8).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
			((Control)lblBook).ForeColor = Color.White;
			FlowLayoutPanel pnlBotam2 = PnlBotam;
			object? obj10 = colorConverter.ConvertFromString("CadetBlue");
			((Control)pnlBotam2).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
		}
		CurActCtrl = (Control)(object)tItDesc;
	}

	private void UT_USER_REQUEST_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27 && Operators.CompareString(tItDesc.Text, "", false) != 0)
		{
			((Control)BtnSave).Focus();
		}
	}
}
