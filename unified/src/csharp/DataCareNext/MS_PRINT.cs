using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DataCareNext.My.Resources;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class MS_PRINT : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnView")]
	private SimpleButton _BtnView;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

	private Control CurActCtrl;

	internal virtual SimpleButton BtnPrint
	{
		[CompilerGenerated]
		get
		{
			return _BtnPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = BtnPrint_Click;
			KeyEventHandler val = new KeyEventHandler(BtnPrint_KeyDown);
			SimpleButton val2 = _BtnPrint;
			if (val2 != null)
			{
				((Control)val2).Click -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_BtnPrint = value;
			val2 = _BtnPrint;
			if (val2 != null)
			{
				((Control)val2).Click += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual SimpleButton BtnView
	{
		[CompilerGenerated]
		get
		{
			return _BtnView;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = BtnView_Click;
			KeyEventHandler val = new KeyEventHandler(BtnView_KeyDown);
			SimpleButton val2 = _BtnView;
			if (val2 != null)
			{
				((Control)val2).Click -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_BtnView = value;
			val2 = _BtnView;
			if (val2 != null)
			{
				((Control)val2).Click += eventHandler;
				((Control)val2).KeyDown += val;
			}
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkOrg")]
	private virtual CheckBox _chkOrg;

	internal virtual CheckBox chkOrg
	{
		get
		{
			return _chkOrg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkOrg = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ChkDup")]
	private virtual CheckBox _ChkDup;

	internal virtual CheckBox ChkDup
	{
		get
		{
			return _ChkDup;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_ChkDup = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkTrip")]
	private virtual CheckBox _chkTrip;

	internal virtual CheckBox chkTrip
	{
		get
		{
			return _chkTrip;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkTrip = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PanelControl1")]
	private virtual PanelControl _PanelControl1;

	internal virtual PanelControl PanelControl1
	{
		get
		{
			return _PanelControl1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelControl1 = value;
		}
	}

	public MS_PRINT()
	{
		((Form)this).Load += MS_LOGIN_Load;
		((Form)this).Activated += MS_PRINT_Activated;
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
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Expected O, but got Unknown
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Expected O, but got Unknown
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a3: Expected O, but got Unknown
		//IL_0678: Unknown result type (might be due to invalid IL or missing references)
		//IL_0682: Expected O, but got Unknown
		//IL_07d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e0: Expected O, but got Unknown
		//IL_0835: Unknown result type (might be due to invalid IL or missing references)
		//IL_083f: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_PRINT));
		BtnPrint = new SimpleButton();
		BtnView = new SimpleButton();
		BtnExit = new SimpleButton();
		chkOrg = new CheckBox();
		ChkDup = new CheckBox();
		chkTrip = new CheckBox();
		PanelControl1 = new PanelControl();
		((ISupportInitialize)PanelControl1).BeginInit();
		((Control)PanelControl1).SuspendLayout();
		((Control)this).SuspendLayout();
		((BaseStyleControl)BtnPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		((Control)BtnPrint).Location = new Point(108, 104);
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((Control)BtnPrint).Size = new Size(91, 37);
		((Control)BtnPrint).TabIndex = 1;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnView).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnView).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnView).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnView).Appearance.Options.UseForeColor = true;
		BtnView.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnView.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)BtnView).Location = new Point(11, 104);
		((BaseControl)BtnView).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnView).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnView).Name = "BtnView";
		((Control)BtnView).Size = new Size(91, 37);
		((Control)BtnView).TabIndex = 2;
		BtnView.Text = "&View";
		((BaseButton)BtnView).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnExit).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExit.ImageOptions.SvgImage");
		((Control)BtnExit).Location = new Point(205, 104);
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((Control)BtnExit).Size = new Size(91, 37);
		((Control)BtnExit).TabIndex = 0;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((ButtonBase)chkOrg).AutoSize = true;
		((ButtonBase)chkOrg).BackColor = Color.Transparent;
		chkOrg.Checked = true;
		chkOrg.CheckState = (CheckState)1;
		((Control)chkOrg).Font = new Font("Copperplate Gothic Bold", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkOrg).ForeColor = Color.White;
		((Control)chkOrg).Location = new Point(105, 23);
		((Control)chkOrg).Name = "chkOrg";
		((Control)chkOrg).Size = new Size(99, 20);
		((Control)chkOrg).TabIndex = 3;
		((ButtonBase)chkOrg).Text = "Original";
		((ButtonBase)chkOrg).UseVisualStyleBackColor = false;
		((ButtonBase)ChkDup).AutoSize = true;
		((ButtonBase)ChkDup).BackColor = Color.Transparent;
		((Control)ChkDup).Font = new Font("Copperplate Gothic Bold", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ChkDup).ForeColor = Color.White;
		((Control)ChkDup).Location = new Point(37, 64);
		((Control)ChkDup).Name = "ChkDup";
		((Control)ChkDup).Size = new Size(112, 20);
		((Control)ChkDup).TabIndex = 4;
		((ButtonBase)ChkDup).Text = "Duplicate";
		((ButtonBase)ChkDup).UseVisualStyleBackColor = false;
		((ButtonBase)chkTrip).AutoSize = true;
		((ButtonBase)chkTrip).BackColor = Color.Transparent;
		((Control)chkTrip).Font = new Font("Copperplate Gothic Bold", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkTrip).ForeColor = Color.White;
		((Control)chkTrip).Location = new Point(167, 64);
		((Control)chkTrip).Name = "chkTrip";
		((Control)chkTrip).Size = new Size(113, 20);
		((Control)chkTrip).TabIndex = 5;
		((ButtonBase)chkTrip).Text = "Triplicate";
		((ButtonBase)chkTrip).UseVisualStyleBackColor = false;
		PanelControl1.Appearance.BackColor = Color.FromArgb(255, 224, 192);
		PanelControl1.Appearance.Options.UseBackColor = true;
		PanelControl1.BorderStyle = (BorderStyles)5;
		PanelControl1.ContentImage = (Image)componentResourceManager.GetObject("PanelControl1.ContentImage");
		PanelControl1.ContentImageAlignment = (ContentAlignment)512;
		((Control)PanelControl1).Controls.Add((Control)(object)chkOrg);
		((Control)PanelControl1).Controls.Add((Control)(object)BtnExit);
		((Control)PanelControl1).Controls.Add((Control)(object)chkTrip);
		((Control)PanelControl1).Controls.Add((Control)(object)BtnPrint);
		((Control)PanelControl1).Controls.Add((Control)(object)BtnView);
		((Control)PanelControl1).Controls.Add((Control)(object)ChkDup);
		((Control)PanelControl1).Location = new Point(12, 12);
		((UserLookAndFeel)((XtraScrollableControl)PanelControl1).LookAndFeel).SkinName = "Valentine";
		((UserLookAndFeel)((XtraScrollableControl)PanelControl1).LookAndFeel).UseDefaultLookAndFeel = false;
		((Control)PanelControl1).Name = "PanelControl1";
		((Control)PanelControl1).Size = new Size(307, 165);
		((Control)PanelControl1).TabIndex = 0;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).BackColor = Color.FromArgb(109, 131, 130);
		((Control)this).BackgroundImage = (Image)componentResourceManager.GetObject("$this.BackgroundImage");
		((Control)this).BackgroundImageLayout = (ImageLayout)3;
		((Form)this).ClientSize = new Size(332, 190);
		((Form)this).ControlBox = false;
		((Control)this).Controls.Add((Control)(object)PanelControl1);
		((Control)this).DoubleBuffered = true;
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
		((Form)this).KeyPreview = true;
		((Form)this).MaximizeBox = false;
		((Form)this).MinimizeBox = false;
		((Control)this).Name = "MS_PRINT";
		((Form)this).ShowInTaskbar = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = " Print Menu";
		((ISupportInitialize)PanelControl1).EndInit();
		((Control)PanelControl1).ResumeLayout(false);
		((Control)PanelControl1).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	private void MS_LOGIN_Load(object sender, EventArgs e)
	{
		((Form)this).BackColor = default(Color);
		((Form)this).TransparencyKey = ((Form)this).BackColor;
		if (DC_Main.MsDupPrintStatus)
		{
			DC_Main.MsDupPrintStatus = false;
			ChkDup.Checked = true;
		}
		else
		{
			ChkDup.Checked = false;
		}
		((ContainerControl)this).ActiveControl = CurActCtrl;
		if (Operators.CompareString(DC_Main.MsPrintFormBtn, "P", false) == 0)
		{
			CurActCtrl = (Control)(object)BtnPrint;
		}
		else if (Operators.CompareString(DC_Main.MsPrintFormBtn, "V", false) == 0)
		{
			CurActCtrl = (Control)(object)BtnView;
		}
		else
		{
			CurActCtrl = (Control)(object)BtnExit;
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		DC_Main.MsPrintOpt = "CANCEL";
		((Form)this).Close();
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		DC_Main.MsPrintOpt = "PRINT";
		if (chkOrg.Checked)
		{
			DC_Main.MsPrintOg = true;
		}
		else
		{
			DC_Main.MsPrintOg = false;
		}
		if (ChkDup.Checked)
		{
			DC_Main.MsPrintDup = true;
		}
		else
		{
			DC_Main.MsPrintDup = false;
		}
		if (chkTrip.Checked)
		{
			DC_Main.MsPrintTrip = true;
		}
		else
		{
			DC_Main.MsPrintTrip = false;
		}
		DC_Main.MsPrintStatus = true;
		((Form)this).Close();
	}

	private void BtnPrint_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			DC_Main.MsPrintOpt = "PRINT";
			if (chkOrg.Checked)
			{
				DC_Main.MsPrintOg = true;
			}
			else
			{
				DC_Main.MsPrintOg = false;
			}
			if (ChkDup.Checked)
			{
				DC_Main.MsPrintDup = true;
			}
			else
			{
				DC_Main.MsPrintDup = false;
			}
			if (chkTrip.Checked)
			{
				DC_Main.MsPrintTrip = true;
			}
			else
			{
				DC_Main.MsPrintTrip = false;
			}
			DC_Main.MsPrintStatus = true;
			((Form)this).Close();
		}
	}

	private void BtnView_Click(object sender, EventArgs e)
	{
		DC_Main.MsPrintOpt = "VIEW";
		if (chkOrg.Checked)
		{
			DC_Main.MsPrintOg = true;
		}
		else
		{
			DC_Main.MsPrintOg = false;
		}
		if (ChkDup.Checked)
		{
			DC_Main.MsPrintDup = true;
		}
		else
		{
			DC_Main.MsPrintDup = false;
		}
		if (chkTrip.Checked)
		{
			DC_Main.MsPrintTrip = true;
		}
		else
		{
			DC_Main.MsPrintTrip = false;
		}
		DC_Main.MsPrintStatus = true;
		((Form)this).Close();
	}

	private void BtnView_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			DC_Main.MsPrintOpt = "VIEW";
			if (chkOrg.Checked)
			{
				DC_Main.MsPrintOg = true;
			}
			else
			{
				DC_Main.MsPrintOg = false;
			}
			if (ChkDup.Checked)
			{
				DC_Main.MsPrintDup = true;
			}
			else
			{
				DC_Main.MsPrintDup = false;
			}
			if (chkTrip.Checked)
			{
				DC_Main.MsPrintTrip = true;
			}
			else
			{
				DC_Main.MsPrintTrip = false;
			}
			DC_Main.MsPrintStatus = true;
			((Form)this).Close();
		}
	}

	private void MS_PRINT_Activated(object sender, EventArgs e)
	{
		((ContainerControl)this).ActiveControl = CurActCtrl;
		if (Operators.CompareString(DC_Main.MsPrintFormBtn, "P", false) == 0)
		{
			CurActCtrl = (Control)(object)BtnPrint;
		}
		else if (Operators.CompareString(DC_Main.MsPrintFormBtn, "V", false) == 0)
		{
			CurActCtrl = (Control)(object)BtnView;
		}
		else
		{
			CurActCtrl = (Control)(object)BtnExit;
		}
	}
}
