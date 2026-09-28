using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class UT_EXPORT : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCancel")]
	private SimpleButton _BtnCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnRtLImoirt")]
	private SimpleButton _btnRtLImoirt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTrfrUpdate")]
	private SimpleButton _btnTrfrUpdate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnReSetData")]
	private SimpleButton _btnReSetData;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOpbl")]
	private SimpleButton _btnOpbl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBarData")]
	private SimpleButton _btnBarData;

	private Control CurActCtrl;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string TrfrMdbName;

	private string ImpSoftType;

	private string TrFrCoType;

	private DataTable RsTrFrIt;

	private DataTable RsDetl;

	private DataTable RsIdtl;

	private string CurProcess;

	private DataTable RsBVchNo;

	private string BVchNo;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDelete")]
	private virtual SimpleButton _BtnDelete;

	internal virtual SimpleButton BtnDelete
	{
		get
		{
			return _BtnDelete;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnDelete = value;
		}
	}

	internal virtual SimpleButton BtnCancel
	{
		[CompilerGenerated]
		get
		{
			return _BtnCancel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnCancel_Click;
			SimpleButton val = _BtnCancel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnCancel = value;
			val = _BtnCancel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private virtual SimpleButton _BtnSave;

	internal virtual SimpleButton BtnSave
	{
		get
		{
			return _BtnSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnSave = value;
		}
	}

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
			EventHandler eventHandler = BtnPrint_Click;
			SimpleButton val = _BtnPrint;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnPrint = value;
			val = _BtnPrint;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ProgressBar1")]
	private virtual ProgressBar _ProgressBar1;

	internal virtual ProgressBar ProgressBar1
	{
		get
		{
			return _ProgressBar1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_ProgressBar1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("dlgOpen")]
	private virtual FolderBrowserDialog _dlgOpen;

	internal virtual FolderBrowserDialog dlgOpen
	{
		get
		{
			return _dlgOpen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_dlgOpen = value;
		}
	}

	internal virtual SimpleButton btnRtLImoirt
	{
		[CompilerGenerated]
		get
		{
			return _btnRtLImoirt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnRtLImoirt_Click;
			SimpleButton val = _btnRtLImoirt;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnRtLImoirt = value;
			val = _btnRtLImoirt;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DlgOpn")]
	private virtual OpenFileDialog _DlgOpn;

	internal virtual OpenFileDialog DlgOpn
	{
		get
		{
			return _DlgOpn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DlgOpn = value;
		}
	}

	internal virtual SimpleButton btnTrfrUpdate
	{
		[CompilerGenerated]
		get
		{
			return _btnTrfrUpdate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnTrfrUpdate_Click;
			SimpleButton val = _btnTrfrUpdate;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTrfrUpdate = value;
			val = _btnTrfrUpdate;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnReSetData
	{
		[CompilerGenerated]
		get
		{
			return _btnReSetData;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnReSetData_Click;
			SimpleButton val = _btnReSetData;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnReSetData = value;
			val = _btnReSetData;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnOpbl
	{
		[CompilerGenerated]
		get
		{
			return _btnOpbl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnOpbl_Click;
			SimpleButton val = _btnOpbl;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOpbl = value;
			val = _btnOpbl;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnBarData
	{
		[CompilerGenerated]
		get
		{
			return _btnBarData;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnBarData_Click;
			SimpleButton val = _btnBarData;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBarData = value;
			val = _btnBarData;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public UT_EXPORT()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += UT_EXPORT_Load;
		((Form)this).Deactivate += UT_EXPORT_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(UT_EXPORT_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(UT_EXPORT_KeyDown);
		((Form)this).Closed += UT_EXPORT_Closed;
		TrFrCoType = "";
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
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Expected O, but got Unknown
		//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b4: Expected O, but got Unknown
		//IL_065d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0667: Expected O, but got Unknown
		//IL_06ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d4: Expected O, but got Unknown
		//IL_07af: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b9: Expected O, but got Unknown
		//IL_08dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e6: Expected O, but got Unknown
		//IL_09be: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c8: Expected O, but got Unknown
		//IL_0a64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6e: Expected O, but got Unknown
		//IL_0bb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbd: Expected O, but got Unknown
		//IL_0c95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9f: Expected O, but got Unknown
		//IL_0d3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d45: Expected O, but got Unknown
		//IL_0e8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e97: Expected O, but got Unknown
		//IL_0f6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f79: Expected O, but got Unknown
		//IL_1015: Unknown result type (might be due to invalid IL or missing references)
		//IL_101f: Expected O, but got Unknown
		//IL_1157: Unknown result type (might be due to invalid IL or missing references)
		//IL_1161: Expected O, but got Unknown
		//IL_1239: Unknown result type (might be due to invalid IL or missing references)
		//IL_1243: Expected O, but got Unknown
		//IL_12df: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e9: Expected O, but got Unknown
		//IL_142e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1438: Expected O, but got Unknown
		//IL_1510: Unknown result type (might be due to invalid IL or missing references)
		//IL_151a: Expected O, but got Unknown
		//IL_15b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c0: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_EXPORT));
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		lblBook = new Label();
		ProgressBar1 = new ProgressBar();
		btnRtLImoirt = new SimpleButton();
		DlgOpn = new OpenFileDialog();
		btnTrfrUpdate = new SimpleButton();
		btnReSetData = new SimpleButton();
		btnOpbl = new SimpleButton();
		btnBarData = new SimpleButton();
		((Control)PnlBotam).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 4;
		((BaseStyleControl)BtnExit).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExit.ImageOptions.SvgImage");
		((Control)BtnExit).Location = new Point(1215, 3);
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((Control)BtnExit).Size = new Size(91, 37);
		((Control)BtnExit).TabIndex = 4;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = Resources.actions_trash;
		((Control)BtnDelete).Location = new Point(1118, 3);
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((Control)BtnDelete).Size = new Size(91, 37);
		((Control)BtnDelete).TabIndex = 3;
		BtnDelete.Text = "&Delete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)BtnCancel).Location = new Point(1021, 3);
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((Control)BtnCancel).Size = new Size(91, 37);
		((Control)BtnCancel).TabIndex = 2;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		((Control)BtnSave).Location = new Point(924, 3);
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((Control)BtnSave).Size = new Size(91, 37);
		((Control)BtnSave).TabIndex = 0;
		BtnSave.Text = "&Save";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		((Control)BtnPrint).Location = new Point(827, 3);
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((Control)BtnPrint).Size = new Size(91, 37);
		((Control)BtnPrint).TabIndex = 1;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblBook).Dock = (DockStyle)1;
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).Font = new Font("Segoe UI", 14.25f);
		((Control)lblBook).ForeColor = Color.FromArgb(192, 0, 0);
		lblBook.ImeMode = (ImeMode)0;
		((Control)lblBook).Location = new Point(0, 0);
		((Control)lblBook).Name = "lblBook";
		((Control)lblBook).Size = new Size(1309, 32);
		((Control)lblBook).TabIndex = 6;
		lblBook.Text = "Data Transfer";
		lblBook.TextAlign = (ContentAlignment)32;
		((Control)ProgressBar1).Location = new Point(0, 323);
		((Control)ProgressBar1).Name = "ProgressBar1";
		((Control)ProgressBar1).Size = new Size(1309, 23);
		((Control)ProgressBar1).TabIndex = 1152;
		((BaseStyleControl)btnRtLImoirt).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnRtLImoirt).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnRtLImoirt).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnRtLImoirt).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnRtLImoirt).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnRtLImoirt).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnRtLImoirt).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnRtLImoirt).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnRtLImoirt).Appearance.Options.UseForeColor = true;
		((BaseButton)btnRtLImoirt).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnRtLImoirt).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnRtLImoirt).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnRtLImoirt).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnRtLImoirt).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnRtLImoirt).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnRtLImoirt).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnRtLImoirt).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnRtLImoirt).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnRtLImoirt).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnRtLImoirt).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnRtLImoirt).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnRtLImoirt).AppearancePressed.Options.UseFont = true;
		((Control)btnRtLImoirt).Location = new Point(542, 173);
		((BaseControl)btnRtLImoirt).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnRtLImoirt).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnRtLImoirt).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnRtLImoirt).Name = "btnRtLImoirt";
		((Control)btnRtLImoirt).Size = new Size(106, 32);
		((Control)btnRtLImoirt).TabIndex = 3;
		btnRtLImoirt.Text = "&Data Trfr";
		((BaseControl)btnRtLImoirt).ToolTip = "Party Help";
		((FileDialog)DlgOpn).FileName = "DlgOpen";
		((BaseStyleControl)btnTrfrUpdate).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnTrfrUpdate).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnTrfrUpdate).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnTrfrUpdate).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnTrfrUpdate).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnTrfrUpdate).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnTrfrUpdate).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnTrfrUpdate).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTrfrUpdate).Appearance.Options.UseForeColor = true;
		((BaseButton)btnTrfrUpdate).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnTrfrUpdate).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnTrfrUpdate).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnTrfrUpdate).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnTrfrUpdate).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnTrfrUpdate).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnTrfrUpdate).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnTrfrUpdate).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnTrfrUpdate).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnTrfrUpdate).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnTrfrUpdate).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnTrfrUpdate).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnTrfrUpdate).AppearancePressed.Options.UseFont = true;
		((Control)btnTrfrUpdate).Location = new Point(495, 394);
		((BaseControl)btnTrfrUpdate).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnTrfrUpdate).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnTrfrUpdate).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTrfrUpdate).Name = "btnTrfrUpdate";
		((Control)btnTrfrUpdate).Size = new Size(203, 32);
		((Control)btnTrfrUpdate).TabIndex = 1153;
		btnTrfrUpdate.Text = "&Update Trfr = N For This Pc";
		((BaseControl)btnTrfrUpdate).ToolTip = "Party Help";
		((Control)btnTrfrUpdate).Visible = false;
		((BaseStyleControl)btnReSetData).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnReSetData).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnReSetData).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnReSetData).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnReSetData).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnReSetData).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnReSetData).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnReSetData).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnReSetData).Appearance.Options.UseForeColor = true;
		((BaseButton)btnReSetData).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnReSetData).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnReSetData).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnReSetData).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnReSetData).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnReSetData).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnReSetData).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnReSetData).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnReSetData).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnReSetData).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnReSetData).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnReSetData).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnReSetData).AppearancePressed.Options.UseFont = true;
		((Control)btnReSetData).Location = new Point(542, 218);
		((BaseControl)btnReSetData).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnReSetData).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnReSetData).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnReSetData).Name = "btnReSetData";
		((Control)btnReSetData).Size = new Size(106, 32);
		((Control)btnReSetData).TabIndex = 1154;
		btnReSetData.Text = "Data &Reset";
		((BaseControl)btnReSetData).ToolTip = "Party Help";
		((BaseStyleControl)btnOpbl).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnOpbl).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnOpbl).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnOpbl).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnOpbl).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnOpbl).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnOpbl).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnOpbl).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnOpbl).Appearance.Options.UseForeColor = true;
		((BaseButton)btnOpbl).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnOpbl).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnOpbl).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnOpbl).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnOpbl).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnOpbl).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnOpbl).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnOpbl).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnOpbl).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnOpbl).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnOpbl).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnOpbl).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnOpbl).AppearancePressed.Options.UseFont = true;
		((Control)btnOpbl).Location = new Point(542, 263);
		((BaseControl)btnOpbl).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnOpbl).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnOpbl).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnOpbl).Name = "btnOpbl";
		((Control)btnOpbl).Size = new Size(106, 32);
		((Control)btnOpbl).TabIndex = 1155;
		btnOpbl.Text = "Opbl Trfr (A)";
		((BaseControl)btnOpbl).ToolTip = "Party Help";
		((Control)btnOpbl).Visible = false;
		((BaseStyleControl)btnBarData).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnBarData).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnBarData).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnBarData).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnBarData).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnBarData).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnBarData).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnBarData).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnBarData).Appearance.Options.UseForeColor = true;
		((BaseButton)btnBarData).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnBarData).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnBarData).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnBarData).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnBarData).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnBarData).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnBarData).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnBarData).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnBarData).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnBarData).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnBarData).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnBarData).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnBarData).AppearancePressed.Options.UseFont = true;
		((Control)btnBarData).Location = new Point(495, 447);
		((BaseControl)btnBarData).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnBarData).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnBarData).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnBarData).Name = "btnBarData";
		((Control)btnBarData).Size = new Size(203, 32);
		((Control)btnBarData).TabIndex = 1156;
		btnBarData.Text = "&BarData ReTrfr";
		((BaseControl)btnBarData).ToolTip = "Party Help";
		((Control)btnBarData).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)btnBarData);
		((Control)this).Controls.Add((Control)(object)btnOpbl);
		((Control)this).Controls.Add((Control)(object)btnReSetData);
		((Control)this).Controls.Add((Control)(object)btnTrfrUpdate);
		((Control)this).Controls.Add((Control)(object)btnRtLImoirt);
		((Control)this).Controls.Add((Control)(object)ProgressBar1);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "UT_EXPORT";
		((Form)this).Text = "Data Transfer";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	private void UT_EXPORT_Load(object sender, EventArgs e)
	{
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurProcess = DC_Main.MsUserRightForm;
		lblBook.Text = CurProcess;
		DC_Main.MsUserRightForm = "";
		if (dataTable.Rows.Count > 0)
		{
			UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));
			UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));
			UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));
		}
		((Control)this).SuspendLayout();
		((Control)this).ResumeLayout();
		double num = (DC_Main.PcW - DC_Main.MainPcW) / DC_Main.MainPcW;
		double num2 = (DC_Main.PcH - DC_Main.MainPcH) / DC_Main.MainPcH;
		ColCon = 1.0 + num;
		checked
		{
			foreach (Control control in ((Control)this).Controls)
			{
				Control val = control;
				Control val2;
				(val2 = val).Width = val2.Width + (int)Math.Round((double)val.Width * num);
				(val2 = val).Height = val2.Height + (int)Math.Round((double)val.Height * num2);
				(val2 = val).Left = val2.Left + (int)Math.Round((double)val.Left * num);
				(val2 = val).Top = val2.Top + (int)Math.Round((double)val.Top * num2);
			}
			foreach (object control2 in ((Control)PnlBotam).Controls)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(control2);
				object obj = objectValue;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			((Form)this).ClientSize = new Size((int)Math.Round(DC_Main.MainPcW), (int)Math.Round(DC_Main.MainPcH));
			((Control)this).Dock = (DockStyle)5;
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				((Form)this).BackColor = Color.Silver;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				Label obj4 = lblBook;
				object? obj5 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj4).ForeColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj7 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)btnRtLImoirt).Appearance;
				object? obj8 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj9 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj10 = lblBook;
				object? obj11 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj10).ForeColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj12 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)btnRtLImoirt).Appearance;
				object? obj13 = colorConverter.ConvertFromString("0, 0, 192");
				appearance2.ForeColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
			}
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				if (Operators.CompareString(DC_Main.MCo_Type, "A", false) != 0)
				{
					((Control)btnReSetData).Visible = false;
					((Control)btnOpbl).Visible = false;
				}
			}
			else if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0 && Operators.CompareString(DC_Main.MCo_Type, "B", false) != 0)
			{
				((Control)btnReSetData).Visible = false;
				((Control)btnOpbl).Visible = false;
			}
			if (Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0)
			{
				((Control)btnOpbl).Visible = true;
			}
			else
			{
				((Control)btnOpbl).Visible = false;
			}
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK056NEVK", false) == 0) & (Operators.CompareString(DC_Main.MCo_Type, "A", false) == 0))
			{
				((Control)btnOpbl).Visible = true;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS136NSBU", false) == 0 && Operators.CompareString(DC_Main.MCo_code, "01", false) == 0)
			{
				((Control)btnOpbl).Visible = true;
				((Control)btnRtLImoirt).Visible = false;
			}
			DC_Main.RsQry = "SELECT * FROM BOOK_IDTL WHERE SR_NO = 100";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.MsTrfrIp = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_BOOK"], (object)""));
				DC_Main.MsTrfrPwd = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SVR_PWD"], (object)""));
				DC_Main.MsTrfrSvr = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
				DC_Main.MsTrfrSvrMast = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
			}
			DC_Main.CnTr.ConnectionString = ("Data Source=" + DC_Main.MsTrfrIp + ";Initial Catalog=" + DC_Main.MsTrfrSvr + ";Persist Security Info=True;User ID=sa;Password=" + DC_Main.MsTrfrPwd) ?? "";
		}
	}

	public DataTable OpenRecordsetTrfr(string sql)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		DC_Main.NewTbl = new DataTable();
		DC_Main.Da = new SqlDataAdapter(sql, DC_Main.CnTr);
		((DbDataAdapter)(object)DC_Main.Da).Fill(DC_Main.NewTbl);
		return DC_Main.NewTbl;
	}

	public void ExeQuteCnTr(string Sql)
	{
		if (DC_Main.CnTr.State == ConnectionState.Open)
		{
			DC_Main.CnTr.Close();
		}
		DC_Main.CnTr.Open();
		DC_Main.Cmd.Connection = DC_Main.CnTr;
		DC_Main.Cmd.CommandText = Sql;
		DC_Main.Cmd.ExecuteNonQuery();
		DC_Main.CnTr.Close();
	}

	private void CLEAR_DATA()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		foreach (Control control in ((Control)this).Controls)
		{
			Control val = control;
			if (val is TextBox)
			{
				val.Text = "";
			}
			else if (val is MaskedTextBox)
			{
				val.Text = DC_Main.MMask;
			}
		}
		MainUser = DC_Main.MCo_User;
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void UT_EXPORT_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void UT_EXPORT_KeyPress(object sender, KeyPressEventArgs e)
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

	private void UT_EXPORT_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
		if (((int)e.KeyCode == 79) & e.Control)
		{
			((Control)btnTrfrUpdate).Visible = true;
			((Control)btnBarData).Visible = true;
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void UT_EXPORT_Closed(object sender, EventArgs e)
	{
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
		}
	}

	private void btnRtLImoirt_Click(object sender, EventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Invalid comparison between Unknown and I4
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		lblBook.Text = "Retail Software Export";
		((Control)ProgressBar1).Visible = true;
		if ((int)Interaction.MsgBox((object)"Are You Sure To Data Transfer.... ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM CO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_TYPE <> ''";
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count <= 0)
				{
					Interaction.MsgBox((object)"Please Insert CoType In Company Master...", (MsgBoxStyle)0, (object)null);
					return;
				}
				TrFrCoType = Conversions.ToString(DC_Main.Rshlp.Rows[0]["CO_TYPE"]);
			}
			else
			{
				TrFrCoType = DC_Main.MCo_Type;
			}
			if (Operators.CompareString(TrFrCoType, "T", false) == 0)
			{
				Ac_Item();
				Ac_AcMast();
				Ac_BookMast();
				Ab_BarData();
				Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
				return;
			}
			if (Operators.CompareString(TrFrCoType, "P", false) == 0)
			{
				Ac_Item();
				Ac_AcMast();
				Ac_BookMast();
				Ac_Sales();
				Ac_CashBank();
				if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM495NEKU", false) != 0) & (Operators.CompareString(DC_Main.SSRegSrNo, "VK209NEVK", false) != 0))
				{
					Ac_BarData();
				}
				Ac_Purchase();
				Ac_Karigar();
				Ac_Contra();
				Ac_OrdData();
				Ac_Scheme();
				Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
				return;
			}
			if (Operators.CompareString(TrFrCoType, "B", false) == 0)
			{
				Ab_Item();
				Ab_ItmOPbl();
				Ab_AcMast();
				Ab_BookMast();
				Ab_OpData();
				Ab_Sales();
				Ab_CashBank();
				Ab_Wh_Sale();
				Ab_Purchase();
				Ab_Karigar();
				Ab_BarData();
				Ab_Bar_Cancel();
				Ab_Contra_FineJv();
				Ab_OrdData();
				Ab_Scheme();
				Ab_RepData();
				BtoA_TmpBookData();
				Interaction.MsgBox((object)"Process Are Complete....Please B Data Refersh And Check Ledger And Stock Then Reset Data", (MsgBoxStyle)64, (object)null);
			}
		}
		Application.Exit();
	}

	private void Ab_RepData()
	{
		DC_Main.RsQry = "SELECT * FROM REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Reparing Data";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				int num = Strings.Len(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_NO"]));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["RE_TRFR"], (object)""), (object)"Y", false))
				{
					BVchNo = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["HD_VCH_NO"], (object)""));
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,MAX(VCH_NO) As LAST_VCH_SR,RIGHT('00000' + CAST(ISNULL(CAST(MAX(VCH_NO) AS INT), 0) + 1 AS VARCHAR(10)), " + Conversions.ToString(num) + ") AS NEXT_VCH_NO  From REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' Group By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK Order By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						RsBVchNo = OpenRecordsetTrfr(DC_Main.RsQry);
					}
					else
					{
						RsBVchNo = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					if (RsBVchNo.Rows.Count > 0)
					{
						BVchNo = Conversions.ToString(RsBVchNo.Rows[0]["NEXT_VCH_NO"]);
					}
					else
					{
						BVchNo = "00001";
					}
				}
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM REP_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM REP_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO REP_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,BILL_NO,BILL_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,VCH_TIME,BOOK_NAME,AC_CODE,AC_NAME,  NET_AMT,DISC_PRC,DISC_AMT,TAX_CODE,TAX_PRC,TAX_AMT,AC_GST_TYPE,IGST_TAX,CGST_TAX,SGST_TAX,  GR_WT,NET_WT,ROF_AMT,TOT_AMT,CASH_AMT,CHQ_AMT,BANK_AC,CHQ_NO,BANK_NAME,CARD_AMT,CARD_AC,  KASAR_AMT,BILL_OS,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,EMP_CODE,  VCH_DESC,DATA_TRFR,MAIN_USER,USER_UPDATE,USER_DELETE)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rshlp.Rows[DC_Main.M]["BILL_NO"]), (object)"',NULL, "), (object)" '"), rshlp.Rows[DC_Main.M]["VCH_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["INOUT_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["ENTRY_TYPE"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"', "), (object)" "), rshlp.Rows[DC_Main.M]["NET_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["DISC_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["DISC_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["TAX_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TAX_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TAX_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["AC_GST_TYPE"]), (object)"',"), rshlp.Rows[DC_Main.M]["IGST_TAX"]), (object)","), rshlp.Rows[DC_Main.M]["CGST_TAX"]), (object)","), rshlp.Rows[DC_Main.M]["SGST_TAX"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["GR_WT"]), (object)","), rshlp.Rows[DC_Main.M]["NET_WT"]), (object)","), rshlp.Rows[DC_Main.M]["ROF_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["TOT_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CASH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CHQ_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["BANK_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["CHQ_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"',"), rshlp.Rows[DC_Main.M]["CARD_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["CARD_AC"]), (object)"', "), (object)" "), rshlp.Rows[DC_Main.M]["KASAR_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["BILL_OS"]), (object)",'"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["OLD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["NEW_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["VCH_DESC"]), (object)"','"), rshlp.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["USER_UPDATE"]), (object)"','"), rshlp.Rows[DC_Main.M]["USER_DELETE"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int i = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM REP_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsDetl;
				for (rsDetl = RsDetl; i < rsDetl.Rows.Count; i++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO REP_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,  OLD_SRNO,VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,VCH_TIME,BOOK_NAME,  AC_CODE,IT_CODE,IT_NAME,IT_DESC,ITM_SIZE,TAG_NO,DESIGN_NO,VCH_SRNO,  ITM_PCS,ITM_GWT,ITM_OTH_WT,ADD_WT,LESS_WT,ITM_NWT,ITM_TOUCH,ITM_WEST,  ITM_FINE,LESS_FINE,ITM_RATE,ITM_AMT,LBR_TYPE,LBR_RATE,LBR_AMT,RATE_TYPE,  IT_TYPE,OTH_AMT,NET_AMT,REP_NO,REP_SRNO,REP_LC,REP_YRCD,REP_DBCD,REP_AC_CODE,  REP_AC_NAME,REP_HD_VCH_NO,REP_ADJ,ISU_NO,ISU_SRNO,ISU_LC,ISU_YRCD,ISU_DBCD,  ISU_AC_CODE,ISU_AC_NAME,ISU_HD_VCH_NO,ISU_ADJ,HD_VCH_NO,EMP_CODE,DATA_TRFR,  MAIN_USER,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,  HM_ID,ITM_COLOR,DESIGN_IMG_ID,LESS_TOUCH,ITM_LOT)   VALUES ('", rsDetl.Rows[i]["CO_CODE"]), (object)"','"), rsDetl.Rows[i]["LC_CODE"]), (object)"','"), rsDetl.Rows[i]["CO_YEAR"]), (object)"','"), rsDetl.Rows[i]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',"), rsDetl.Rows[i]["SR_NO"]), (object)", "), (object)" "), rsDetl.Rows[i]["OLD_SRNO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsDetl.Rows[i]["VCH_TYPE"]), (object)"','"), rsDetl.Rows[i]["INOUT_TYPE"]), (object)"','"), rsDetl.Rows[i]["ENTRY_TYPE"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rsDetl.Rows[i]["BOOK_NAME"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["AC_CODE"]), (object)"','"), rsDetl.Rows[i]["IT_CODE"]), (object)"','"), rsDetl.Rows[i]["IT_NAME"]), (object)"','"), rsDetl.Rows[i]["IT_DESC"]), (object)"','"), rsDetl.Rows[i]["ITM_SIZE"]), (object)"','"), rsDetl.Rows[i]["TAG_NO"]), (object)"','"), rsDetl.Rows[i]["DESIGN_NO"]), (object)"','"), rsDetl.Rows[i]["VCH_SRNO"]), (object)"', "), (object)" "), rsDetl.Rows[i]["ITM_PCS"]), (object)","), rsDetl.Rows[i]["ITM_GWT"]), (object)","), rsDetl.Rows[i]["ITM_OTH_WT"]), (object)","), rsDetl.Rows[i]["ADD_WT"]), (object)","), rsDetl.Rows[i]["LESS_WT"]), (object)","), rsDetl.Rows[i]["ITM_NWT"]), (object)","), rsDetl.Rows[i]["ITM_TOUCH"]), (object)","), rsDetl.Rows[i]["ITM_WEST"]), (object)", "), (object)" "), rsDetl.Rows[i]["ITM_FINE"]), (object)","), rsDetl.Rows[i]["LESS_FINE"]), (object)","), rsDetl.Rows[i]["ITM_RATE"]), (object)","), rsDetl.Rows[i]["ITM_AMT"]), (object)",'"), rsDetl.Rows[i]["LBR_TYPE"]), (object)"',"), rsDetl.Rows[i]["LBR_RATE"]), (object)","), rsDetl.Rows[i]["LBR_AMT"]), (object)",'"), rsDetl.Rows[i]["RATE_TYPE"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["IT_TYPE"]), (object)"',"), rsDetl.Rows[i]["OTH_AMT"]), (object)","), rsDetl.Rows[i]["NET_AMT"]), (object)",'"), rsDetl.Rows[i]["REP_NO"]), (object)"',"), rsDetl.Rows[i]["REP_SRNO"]), (object)",'"), rsDetl.Rows[i]["REP_LC"]), (object)"','"), rsDetl.Rows[i]["REP_YRCD"]), (object)"','"), rsDetl.Rows[i]["REP_DBCD"]), (object)"','"), rsDetl.Rows[i]["REP_AC_CODE"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["REP_AC_NAME"]), (object)"','"), rsDetl.Rows[i]["REP_HD_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["REP_ADJ"]), (object)"','"), rsDetl.Rows[i]["ISU_NO"]), (object)"',"), rsDetl.Rows[i]["ISU_SRNO"]), (object)",'"), rsDetl.Rows[i]["ISU_LC"]), (object)"','"), rsDetl.Rows[i]["ISU_YRCD"]), (object)"','"), rsDetl.Rows[i]["ISU_DBCD"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["ISU_AC_CODE"]), (object)"','"), rsDetl.Rows[i]["ISU_AC_NAME"]), (object)"','"), rsDetl.Rows[i]["ISU_HD_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["ISU_ADJ"]), (object)"','"), rsDetl.Rows[i]["VCH_NO"]), (object)"','"), rsDetl.Rows[i]["EMP_CODE"]), (object)"','"), rsDetl.Rows[i]["DATA_TRFR"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["MAIN_USER"]), (object)"','"), rsDetl.Rows[i]["HM_ID2"]), (object)"','"), rsDetl.Rows[i]["HM_ID3"]), (object)"','"), rsDetl.Rows[i]["HM_ID4"]), (object)"',"), rsDetl.Rows[i]["HM_ID_WT"]), (object)","), rsDetl.Rows[i]["HM_ID2_WT"]), (object)","), rsDetl.Rows[i]["HM_ID3_WT"]), (object)","), rsDetl.Rows[i]["HM_ID4_WT"]), (object)", "), (object)" '"), rsDetl.Rows[i]["HM_ID"]), (object)"','"), rsDetl.Rows[i]["ITM_COLOR"]), (object)"','"), rsDetl.Rows[i]["DESIGN_IMG_ID"]), (object)"',"), rsDetl.Rows[i]["LESS_TOUCH"]), (object)",'"), rsDetl.Rows[i]["ITM_LOT"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsDetl = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE REP_DATA SET DATA_TRFR = 'Y',HD_VCH_NO = '" + BVchNo + "',RE_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ab_Scheme()
	{
		DC_Main.ExeQuteDc("UPDATE AD_MAST Set DATA_TRFR = 'N' WHERE DATA_TRFR Is NULL");
		DC_Main.RsQry = "SELECT * FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Scheme Master";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '"), rshlp.Rows[DC_Main.M]["SCHM_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO AD_MAST(CO_CODE,SCHM_CODE,SCHM_NAME,SCHM_AMT,SCHM_AC,SCHM_TYPE,DATA_TRFR,MAIN_USER,BONUS_PRC,SCHM_MONTH,GOLD_RATE)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["SCHM_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["SCHM_NAME"]), (object)"',"), rshlp.Rows[DC_Main.M]["SCHM_AMT"]), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["SCHM_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["SCHM_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"',"), rshlp.Rows[DC_Main.M]["BONUS_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["SCHM_MONTH"]), (object)","), rshlp.Rows[DC_Main.M]["GOLD_RATE"]), (object)")"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AD_MAST SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '"), rshlp.Rows[DC_Main.M]["SCHM_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT * FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N' ORDER BY SCHM_CODE,MEMB_CODE";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Member Master";
			Application.DoEvents();
			DC_Main.M = 0;
			DC_Main.M = 0;
			DateTime dateTime = default(DateTime);
			DateTime dateTime2 = default(DateTime);
			DateTime dateTime3 = default(DateTime);
			DateTime dateTime4 = default(DateTime);
			DateTime dateTime5 = default(DateTime);
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp2 = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '"), rshlp2.Rows[DC_Main.M]["SCHM_CODE"]), (object)"' AND MEMB_CODE = '"), rshlp2.Rows[DC_Main.M]["MEMB_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["BIRTH_DATE"])))
				{
					dateTime = Conversions.ToDate(rshlp2.Rows[DC_Main.M]["BIRTH_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["L_BR_DATE"])))
				{
					dateTime2 = Conversions.ToDate(rshlp2.Rows[DC_Main.M]["L_BR_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["ANV_DATE"])))
				{
					dateTime3 = Conversions.ToDate(rshlp2.Rows[DC_Main.M]["ANV_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["JOIN_DATE"])))
				{
					dateTime4 = Conversions.ToDate(rshlp2.Rows[DC_Main.M]["JOIN_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["EXP_DATE"])))
				{
					dateTime5 = Conversions.ToDate(rshlp2.Rows[DC_Main.M]["EXP_DATE"]);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO AD_MEMB(CO_CODE,LC_CODE,SCHM_CODE,MEMB_CODE,MEMB_NAME,MEMB_AMT,ITM_GWT,EMP_CODE,AC_PHONE,  AC_MOBILE,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,AC_AREA,AC_MOBILE2,AC_PHONE2,ID_PROF,NOMINEE_NAME,AC_EMAIL,  AC_DISTRICT,BIRTH_DATE,ANV_DATE,L_BR_DATE,JOIN_DATE,EXP_DATE,BANK_NAME,BANK_AREA,BANK_AC_NO,BANK_RTGS_NO,  AC_REF_CODE,SCHM_SHORT,MEMB_BONUS,DATA_TRFR,MAIN_USER)   VALUES('", rshlp2.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["SCHM_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["MEMB_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["MEMB_NAME"]), (object)"',"), rshlp2.Rows[DC_Main.M]["MEMB_AMT"]), (object)","), rshlp2.Rows[DC_Main.M]["ITM_GWT"]), (object)",'"), rshlp2.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_PHONE"]), (object)"', "), (object)" '"), rshlp2.Rows[DC_Main.M]["AC_MOBILE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_ADD1"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_ADD2"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_ADD3"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_CITY"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_PIN"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_AREA"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_MOBILE2"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_PHONE2"]), (object)"','"), rshlp2.Rows[DC_Main.M]["ID_PROF"]), (object)"','"), rshlp2.Rows[DC_Main.M]["NOMINEE_NAME"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_EMAIL"]), (object)"', "), (object)" '"), rshlp2.Rows[DC_Main.M]["AC_DISTRICT"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["BIRTH_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["L_BR_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime2, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["ANV_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime3, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["JOIN_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime4, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["EXP_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime5, "MM/dd/yyyy") + "'"))), (object)",'"), rshlp2.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp2.Rows[DC_Main.M]["BANK_AREA"]), (object)"','"), rshlp2.Rows[DC_Main.M]["BANK_AC_NO"]), (object)"','"), rshlp2.Rows[DC_Main.M]["BANK_RTGS_NO"]), (object)"', "), (object)" '"), rshlp2.Rows[DC_Main.M]["AC_REF_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["SCHM_SHORT"]), (object)"','"), rshlp2.Rows[DC_Main.M]["MEMB_BONUS"]), (object)"','Y','"), rshlp2.Rows[DC_Main.M]["MAIN_USER"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AD_MEMB SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '"), rshlp2.Rows[DC_Main.M]["SCHM_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp2 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT * FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N' ORDER BY CO_BOOK,VCH_NO,SR_NO";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Ad Data";
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp3 = DC_Main.Rshlp;
				if (Operators.ConditionalCompareObjectEqual(rshlp3.Rows[DC_Main.M]["SR_NO"], (object)1, false))
				{
					int num = Strings.Len(RuntimeHelpers.GetObjectValue(rshlp3.Rows[DC_Main.M]["VCH_NO"]));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp3.Rows[DC_Main.M]["RE_TRFR"], (object)""), (object)"Y", false))
					{
						BVchNo = Conversions.ToString(Operators.ConcatenateObject(rshlp3.Rows[DC_Main.M]["HD_VCH_NO"], (object)""));
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,MAX(VCH_NO) As LAST_VCH_SR,RIGHT('00000' + CAST(ISNULL(CAST(MAX(VCH_NO) AS INT), 0) + 1 AS VARCHAR(10)), " + Conversions.ToString(num) + ") AS NEXT_VCH_NO  From AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp3.Rows[DC_Main.M]["CO_BOOK"]), (object)"' Group By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK Order By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK"));
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							RsBVchNo = OpenRecordsetTrfr(DC_Main.RsQry);
						}
						else
						{
							RsBVchNo = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						}
						if (RsBVchNo.Rows.Count > 0)
						{
							BVchNo = Conversions.ToString(RsBVchNo.Rows[0]["NEXT_VCH_NO"]);
						}
						else
						{
							BVchNo = "00001";
						}
					}
				}
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp3.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"' AND SR_NO = '"), rshlp3.Rows[DC_Main.M]["SR_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp3.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"' AND SR_NO = '"), rshlp3.Rows[DC_Main.M]["SR_NO"]), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp3.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"' AND SR_NO = '"), rshlp3.Rows[DC_Main.M]["SR_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp3.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"' AND SR_NO = '"), rshlp3.Rows[DC_Main.M]["SR_NO"]), (object)"'")));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO AD_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,SCHM_CODE,SCHM_DATE,MEMB_CODE,MEMB_AMT,  TOT_AMT,IT_DESC,MONTH_CODE,EMP_CODE,ENT_TYPE,REC_AC,ITM_GWT,ITM_RATE,BANK_NAME,CHQ_NO,ENTRY_TIME,HD_VCH_NO,MAIN_USER,  DATA_TRFR,VCH_TIME,VCH_TYPE,INOUT_TYPE,BOOK_NAME,WITH_UPI)   VALUES ('", rshlp3.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp3.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',"), rshlp3.Rows[DC_Main.M]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp3.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rshlp3.Rows[DC_Main.M]["SCHM_CODE"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp3.Rows[DC_Main.M]["SCHM_DATE"]), "MM/dd/yyyy")), (object)"','"), rshlp3.Rows[DC_Main.M]["MEMB_CODE"]), (object)"',"), rshlp3.Rows[DC_Main.M]["MEMB_AMT"]), (object)", "), (object)" "), rshlp3.Rows[DC_Main.M]["TOT_AMT"]), (object)",'"), rshlp3.Rows[DC_Main.M]["IT_DESC"]), (object)"','"), rshlp3.Rows[DC_Main.M]["MONTH_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["ENT_TYPE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["REC_AC"]), (object)"',"), rshlp3.Rows[DC_Main.M]["ITM_GWT"]), (object)","), rshlp3.Rows[DC_Main.M]["ITM_RATE"]), (object)",'"), rshlp3.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp3.Rows[DC_Main.M]["CHQ_NO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp3.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp3.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), rshlp3.Rows[DC_Main.M]["MAIN_USER"]), (object)"', "), (object)" 'Y','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp3.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp3.Rows[DC_Main.M]["VCH_TYPE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["INOUT_TYPE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["BOOK_NAME"]), (object)"','"), rshlp3.Rows[DC_Main.M]["WITH_UPI"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int i = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM UPI_DATA AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp3.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp3.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp3.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = "), rshlp3.Rows[DC_Main.M]["SR_NO"]), (object)" ORDER BY ISR_NO"));
				DataTable dataTable = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable2;
				for (dataTable2 = dataTable; i < dataTable2.Rows.Count; i++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO UPI_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TIME,  AC_CODE,UPI_AC_CODE,UPI_AC_NAME,UPI_AMT,MAIN_USER,UPI_ID)   VALUES ('", dataTable2.Rows[i]["CO_CODE"]), (object)"','"), dataTable2.Rows[i]["LC_CODE"]), (object)"','"), dataTable2.Rows[i]["CO_YEAR"]), (object)"','"), dataTable2.Rows[i]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',"), dataTable2.Rows[i]["SR_NO"]), (object)","), dataTable2.Rows[i]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[i]["VCH_DATE"]), "MM/dd/yyyy HH:mm:ss")), (object)"', "), (object)" '"), dataTable2.Rows[i]["AC_CODE"]), (object)"','"), dataTable2.Rows[i]["UPI_AC_CODE"]), (object)"','"), dataTable2.Rows[i]["UPI_AC_NAME"]), (object)"',"), dataTable2.Rows[i]["UPI_AMT"]), (object)",'"), dataTable2.Rows[i]["MAIN_USER"]), (object)"','"), dataTable2.Rows[i]["UPI_ID"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable2 = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AD_DATA SET DATA_TRFR = 'Y',HD_VCH_NO = '" + BVchNo + "',RE_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp3.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp3.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp3.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp3 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT * FROM AD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N' ORDER BY CO_BOOK,VCH_NO,SR_NO";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Ad Data";
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp4 = DC_Main.Rshlp;
				if (Operators.ConditionalCompareObjectEqual(rshlp4.Rows[DC_Main.M]["SR_NO"], (object)1, false))
				{
					int num2 = Strings.Len(RuntimeHelpers.GetObjectValue(rshlp4.Rows[DC_Main.M]["VCH_NO"]));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp4.Rows[DC_Main.M]["RE_TRFR"], (object)""), (object)"Y", false))
					{
						BVchNo = Conversions.ToString(Operators.ConcatenateObject(rshlp4.Rows[DC_Main.M]["HD_VCH_NO"], (object)""));
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,MAX(VCH_NO) As LAST_VCH_SR,RIGHT('00000' + CAST(ISNULL(CAST(MAX(VCH_NO) AS INT), 0) + 1 AS VARCHAR(10)), " + Conversions.ToString(num2) + ") AS NEXT_VCH_NO  From AD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp4.Rows[DC_Main.M]["CO_BOOK"]), (object)"' Group By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK Order By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK"));
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							RsBVchNo = OpenRecordsetTrfr(DC_Main.RsQry);
						}
						else
						{
							RsBVchNo = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						}
						if (RsBVchNo.Rows.Count > 0)
						{
							BVchNo = Conversions.ToString(RsBVchNo.Rows[0]["NEXT_VCH_NO"]);
						}
						else
						{
							BVchNo = "00001";
						}
					}
				}
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp4.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"' AND SR_NO = '"), rshlp4.Rows[DC_Main.M]["SR_NO"]), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp4.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"' AND SR_NO = '"), rshlp4.Rows[DC_Main.M]["SR_NO"]), (object)"'")));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO AD_ADJ(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,SCHM_CODE,MEMB_CODE,MEMB_AMT,MEMB_BONUS,MEMB_LESS,ADJ_AMT,AC_CODE,AC_NAME,SBILL_NO,  SBILL_LC_CODE,SBILL_YRCD,SBILL_DBCD,SBILL_AMT,SBILL_HD_VCH_NO,EMP_CODE,VCH_DESC,SIGN,HD_VCH_NO,MAIN_USER,  DATA_TRFR,USER_UPDATE,USER_DELETE,GOLD_WT,GOLD_RATE,GOLD_AMT)   VALUES('", rshlp4.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp4.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',"), rshlp4.Rows[DC_Main.M]["SR_NO"]), (object)",'"), (object)Strings.Format((object)Conversions.ToDate(rshlp4.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp4.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm")), (object)"','"), rshlp4.Rows[DC_Main.M]["VCH_TYPE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["INOUT_TYPE"]), (object)"', "), (object)" '"), rshlp4.Rows[DC_Main.M]["ENTRY_TYPE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["BOOK_NAME"]), (object)"','"), rshlp4.Rows[DC_Main.M]["SCHM_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["MEMB_CODE"]), (object)"',"), rshlp4.Rows[DC_Main.M]["MEMB_AMT"]), (object)","), rshlp4.Rows[DC_Main.M]["MEMB_BONUS"]), (object)","), rshlp4.Rows[DC_Main.M]["MEMB_LESS"]), (object)","), rshlp4.Rows[DC_Main.M]["ADJ_AMT"]), (object)",'"), rshlp4.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["AC_NAME"]), (object)"','"), rshlp4.Rows[DC_Main.M]["SBILL_NO"]), (object)"', "), (object)" '"), rshlp4.Rows[DC_Main.M]["SBILL_LC_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["SBILL_YRCD"]), (object)"','"), rshlp4.Rows[DC_Main.M]["SBILL_DBCD"]), (object)"',"), rshlp4.Rows[DC_Main.M]["SBILL_AMT"]), (object)",'"), rshlp4.Rows[DC_Main.M]["SBILL_HD_VCH_NO"]), (object)"','"), rshlp4.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["VCH_DESC"]), (object)"','"), rshlp4.Rows[DC_Main.M]["SIGN"]), (object)"','"), (object)BVchNo), (object)"','"), rshlp4.Rows[DC_Main.M]["MAIN_USER"]), (object)"', "), (object)" '"), rshlp4.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), rshlp4.Rows[DC_Main.M]["USER_UPDATE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["USER_DELETE"]), (object)"',"), rshlp4.Rows[DC_Main.M]["GOLD_WT"]), (object)","), rshlp4.Rows[DC_Main.M]["GOLD_RATE"]), (object)","), rshlp4.Rows[DC_Main.M]["GOLD_AMT"]), (object)")"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AD_ADJ SET DATA_TRFR = 'Y',HD_VCH_NO = '" + BVchNo + "',RE_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp4.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp4.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp4.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp4 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ab_OrdData()
	{
		DC_Main.RsQry = "SELECT A.* FROM SL_ORD_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Sales Order";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			DateTime dateTime = default(DateTime);
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				int num = Strings.Len(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_NO"]));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["RE_TRFR"], (object)""), (object)"Y", false))
				{
					BVchNo = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["HD_VCH_NO"], (object)""));
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,MAX(VCH_NO) As LAST_VCH_SR,RIGHT('00000' + CAST(ISNULL(CAST(MAX(VCH_NO) AS INT), 0) + 1 AS VARCHAR(10)), " + Conversions.ToString(num) + ") AS NEXT_VCH_NO  From SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' Group By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK Order By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						RsBVchNo = OpenRecordsetTrfr(DC_Main.RsQry);
					}
					else
					{
						RsBVchNo = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					if (RsBVchNo.Rows.Count > 0)
					{
						BVchNo = Conversions.ToString(RsBVchNo.Rows[0]["NEXT_VCH_NO"]);
					}
					else
					{
						BVchNo = "00001";
					}
				}
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["DEL_DATE"])))
				{
					dateTime = Conversions.ToDate(rshlp.Rows[DC_Main.M]["DEL_DATE"]);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_ORD_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CODE,AC_NAME,  NET_AMT,TAX_CODE,TAX_PRC,TAX_AMT,TOT_AMT,ADV_AMT,ORD_ADJ_AMT,OLD_GL_AMT,OLD_SL_AMT,CASH_AMT,CARD_AMT,CHQ_AMT,SCHM_AMT,DEL_DATE,  CARD_AC,BANK_AC,CHQ_NO,BANK_NAME,EMP_CODE,VCH_DESC,ENTRY_TIME,SL_BILL_TYPE,OLD_GL,ADJ_GOLD,OLD_SL,ADJ_SILVER,CARD_ADJ,DATA_TRFR,  OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,ADD1,ADD2,ADD3,CITY,MOBILE,  USER_UPDATE,USER_DELETE,MOB_ENTRY_SAVE,FUN_DATE,RCUT_RATE,RCUT_FINE,RCUT_AMT,UPI_AMT)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["BILL_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"', "), (object)" "), rshlp.Rows[DC_Main.M]["NET_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["TAX_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TAX_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TAX_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["TOT_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["ADV_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["ORD_ADJ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["OLD_GL_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["OLD_SL_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CASH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CARD_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CHQ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["SCHM_AMT"]), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["DEL_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'"))), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["CARD_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["CHQ_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_DESC"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["SL_BILL_TYPE"]), (object)"',"), rshlp.Rows[DC_Main.M]["OLD_GL"]), (object)","), rshlp.Rows[DC_Main.M]["ADJ_GOLD"]), (object)","), rshlp.Rows[DC_Main.M]["OLD_SL"]), (object)","), rshlp.Rows[DC_Main.M]["ADJ_SILVER"]), (object)",'"), rshlp.Rows[DC_Main.M]["CARD_ADJ"]), (object)"','Y', "), (object)" '"), rshlp.Rows[DC_Main.M]["OLD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["NEW_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD1"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD2"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD3"]), (object)"','"), rshlp.Rows[DC_Main.M]["CITY"]), (object)"','"), rshlp.Rows[DC_Main.M]["MOBILE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["USER_UPDATE"]), (object)"','"), rshlp.Rows[DC_Main.M]["USER_DELETE"]), (object)"','"), rshlp.Rows[DC_Main.M]["MOB_ENTRY_SAVE"]), (object)"',null,"), rshlp.Rows[DC_Main.M]["RCUT_RATE"]), (object)","), rshlp.Rows[DC_Main.M]["RCUT_FINE"]), (object)","), rshlp.Rows[DC_Main.M]["RCUT_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["UPI_AMT"]), (object)")"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int i = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_ORD_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsDetl;
				for (rsDetl = RsDetl; i < rsDetl.Rows.Count; i++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_ORD_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,  LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,ITM_REMARK,VCH_SRNO,  KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE,HD_VCH_NO,DATA_TRFR,OLD_VCH_NO,  NEW_VCH_NO,MAIN_USER,ADD_USER,DESIGN_ISU,TAG_GEN,TAG_SALE,ITM_GHT_PRC,HM_ID2,HM_ID3,HM_ID4,  HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,HM_ID)   VALUES ('", rsDetl.Rows[i]["CO_CODE"]), (object)"','"), rsDetl.Rows[i]["LC_CODE"]), (object)"','"), rsDetl.Rows[i]["CO_YEAR"]), (object)"','"), rsDetl.Rows[i]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"',"), rsDetl.Rows[i]["SR_NO"]), (object)","), rsDetl.Rows[i]["OLD_SRNO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"', "), (object)" '"), rsDetl.Rows[i]["VCH_TYPE"]), (object)"','"), rsDetl.Rows[i]["INOUT_TYPE"]), (object)"','"), rsDetl.Rows[i]["ENTRY_TYPE"]), (object)"','"), rsDetl.Rows[i]["BOOK_NAME"]), (object)"','"), rsDetl.Rows[i]["AC_CODE"]), (object)"','"), rsDetl.Rows[i]["IT_CODE"]), (object)"','"), rsDetl.Rows[i]["TAG_NO"]), (object)"','"), rsDetl.Rows[i]["LOT_NO"]), (object)"','"), rsDetl.Rows[i]["DESIGN_NO"]), (object)"','"), rsDetl.Rows[i]["TBL_CODE"]), (object)"','"), rsDetl.Rows[i]["ITM_SIZE"]), (object)"', "), (object)" "), rsDetl.Rows[i]["ITM_PCS"]), (object)","), rsDetl.Rows[i]["BAG_WT"]), (object)","), rsDetl.Rows[i]["ITM_GWT"]), (object)","), rsDetl.Rows[i]["ITM_OTH_WT"]), (object)","), rsDetl.Rows[i]["ITM_NWT"]), (object)","), rsDetl.Rows[i]["ITM_GHT_WT"]), (object)","), rsDetl.Rows[i]["ITM_TOUCH"]), (object)","), rsDetl.Rows[i]["ITM_WEST_PRC"]), (object)","), rsDetl.Rows[i]["ITM_FINE"]), (object)","), rsDetl.Rows[i]["LBR_PRC"]), (object)","), rsDetl.Rows[i]["LBR_RATE"]), (object)", "), (object)" '"), rsDetl.Rows[i]["LBR_TYPE"]), (object)"',"), rsDetl.Rows[i]["LBR_AMT"]), (object)","), rsDetl.Rows[i]["OTH_AMT"]), (object)","), rsDetl.Rows[i]["ITM_RATE"]), (object)","), rsDetl.Rows[i]["ITM_AMT"]), (object)","), rsDetl.Rows[i]["TAG_COST"]), (object)","), rsDetl.Rows[i]["ITM_MRP"]), (object)","), rsDetl.Rows[i]["TOT_AMT"]), (object)","), rsDetl.Rows[i]["TAX_PRC"]), (object)","), rsDetl.Rows[i]["NET_AMT"]), (object)",'"), rsDetl.Rows[i]["ITM_REMARK"]), (object)"','"), rsDetl.Rows[i]["VCH_SRNO"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["KR_NET_WT"]), (object)"','"), rsDetl.Rows[i]["KR_TOUCH"]), (object)"','"), rsDetl.Rows[i]["KR_WEST_PRC"]), (object)"','"), rsDetl.Rows[i]["KR_FINE"]), (object)"','"), rsDetl.Rows[i]["KR_NAME"]), (object)"','"), rsDetl.Rows[i]["RATE_TYPE"]), (object)"','"), rsDetl.Rows[i]["IT_TYPE"]), (object)"','"), rsDetl.Rows[i]["PR_CODE"]), (object)"','"), rsDetl.Rows[i]["VCH_NO"]), (object)"','"), rsDetl.Rows[i]["DATA_TRFR"]), (object)"','"), rsDetl.Rows[i]["OLD_VCH_NO"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["NEW_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["MAIN_USER"]), (object)"','"), rsDetl.Rows[i]["ADD_USER"]), (object)"','"), rsDetl.Rows[i]["DESIGN_ISU"]), (object)"','"), rsDetl.Rows[i]["TAG_GEN"]), (object)"','"), rsDetl.Rows[i]["TAG_SALE"]), (object)"',"), rsDetl.Rows[i]["ITM_GHT_PRC"]), (object)",'"), rsDetl.Rows[i]["HM_ID2"]), (object)"','"), rsDetl.Rows[i]["HM_ID3"]), (object)"','"), rsDetl.Rows[i]["HM_ID4"]), (object)"', "), (object)" "), rsDetl.Rows[i]["HM_ID_WT"]), (object)","), rsDetl.Rows[i]["HM_ID2_WT"]), (object)","), rsDetl.Rows[i]["HM_ID3_WT"]), (object)","), rsDetl.Rows[i]["HM_ID4_WT"]), (object)",'"), rsDetl.Rows[i]["HM_ID"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsDetl = null;
				int j = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_ORD_IDTL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsIdtl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsIdtl;
				for (rsIdtl = RsIdtl; j < rsIdtl.Rows.Count; j++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_ORD_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,  KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,  KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,  MAIN_USER,DM_ORIGIN,DM_REMARK,DM_COLOR,DM_NAME)   VALUES ('", rsIdtl.Rows[j]["CO_CODE"]), (object)"','"), rsIdtl.Rows[j]["LC_CODE"]), (object)"','"), rsIdtl.Rows[j]["CO_YEAR"]), (object)"','"), rsIdtl.Rows[j]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"',"), rsIdtl.Rows[j]["SR_NO"]), (object)","), rsIdtl.Rows[j]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsIdtl.Rows[j]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsIdtl.Rows[j]["VCH_TYPE"]), (object)"','"), rsIdtl.Rows[j]["INOUT_TYPE"]), (object)"', "), (object)" '"), rsIdtl.Rows[j]["ENTRY_TYPE"]), (object)"','"), rsIdtl.Rows[j]["BOOK_NAME"]), (object)"','"), rsIdtl.Rows[j]["AC_CODE"]), (object)"','"), rsIdtl.Rows[j]["TAG_NO"]), (object)"','"), rsIdtl.Rows[j]["VCH_SRNO"]), (object)"','"), rsIdtl.Rows[j]["IT_CODE"]), (object)"','"), rsIdtl.Rows[j]["IT_TYPE"]), (object)"','"), rsIdtl.Rows[j]["DM_CODE"]), (object)"','"), rsIdtl.Rows[j]["DM_SIZE"]), (object)"','"), rsIdtl.Rows[j]["DM_SFNO"]), (object)"','"), rsIdtl.Rows[j]["DM_LEB"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS_WT"]), (object)"', "), (object)" "), rsIdtl.Rows[j]["KR_WT"]), (object)","), rsIdtl.Rows[j]["KR_LESS_PRC"]), (object)","), rsIdtl.Rows[j]["IT_GWT"]), (object)",'"), rsIdtl.Rows[j]["IT_CON_PRC"]), (object)"',"), rsIdtl.Rows[j]["IT_CON_WT"]), (object)",'"), rsIdtl.Rows[j]["IT_RATE_TYPE"]), (object)"',"), rsIdtl.Rows[j]["IT_RATE"]), (object)","), rsIdtl.Rows[j]["IT_AMT"]), (object)","), rsIdtl.Rows[j]["IT_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["IT_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["IT_NET_AMT"]), (object)", "), (object)" "), rsIdtl.Rows[j]["KR_CON_PRC"]), (object)","), rsIdtl.Rows[j]["KR_CON_WT"]), (object)","), rsIdtl.Rows[j]["KR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_NET_AMT"]), (object)",'"), rsIdtl.Rows[j]["VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["OLD_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["NEW_VCH_NO"]), (object)"', "), (object)" '"), rsIdtl.Rows[j]["MAIN_USER"]), (object)"','"), rsIdtl.Rows[j]["DM_ORIGIN"]), (object)"','"), rsIdtl.Rows[j]["DM_REMARK"]), (object)"','"), rsIdtl.Rows[j]["DM_COLOR"]), (object)"','"), rsIdtl.Rows[j]["DM_NAME"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsIdtl = null;
				int k = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_PR_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				DataTable dataTable = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable2;
				for (dataTable2 = dataTable; k < dataTable2.Rows.Count; k++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_PR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_FINE,ITM_RATE,NET_AMT,IT_TYPE,HD_VCH_NO,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,  ITM_OTH_WT,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,HM_ID)   VALUES ('", dataTable2.Rows[k]["CO_CODE"]), (object)"','"), dataTable2.Rows[k]["LC_CODE"]), (object)"','"), dataTable2.Rows[k]["CO_YEAR"]), (object)"','"), dataTable2.Rows[k]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"',"), dataTable2.Rows[k]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[k]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[k]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), dataTable2.Rows[k]["VCH_TYPE"]), (object)"','"), dataTable2.Rows[k]["INOUT_TYPE"]), (object)"','"), dataTable2.Rows[k]["ENTRY_TYPE"]), (object)"','"), dataTable2.Rows[k]["BOOK_NAME"]), (object)"', "), (object)" '"), dataTable2.Rows[k]["AC_CODE"]), (object)"','"), dataTable2.Rows[k]["IT_CODE"]), (object)"','"), dataTable2.Rows[k]["IT_DESC"]), (object)"',"), dataTable2.Rows[k]["ITM_PCS"]), (object)","), dataTable2.Rows[k]["ITM_GWT"]), (object)","), dataTable2.Rows[k]["ITM_NWT"]), (object)","), dataTable2.Rows[k]["ITM_TOUCH"]), (object)","), dataTable2.Rows[k]["ITM_FINE"]), (object)","), dataTable2.Rows[k]["ITM_RATE"]), (object)","), dataTable2.Rows[k]["NET_AMT"]), (object)",'"), dataTable2.Rows[k]["IT_TYPE"]), (object)"','"), dataTable2.Rows[k]["VCH_NO"]), (object)"','Y','"), dataTable2.Rows[k]["OLD_VCH_NO"]), (object)"','"), dataTable2.Rows[k]["NEW_VCH_NO"]), (object)"','"), dataTable2.Rows[k]["MAIN_USER"]), (object)"', "), (object)" "), dataTable2.Rows[k]["ITM_OTH_WT"]), (object)",'"), dataTable2.Rows[k]["HM_ID2"]), (object)"','"), dataTable2.Rows[k]["HM_ID3"]), (object)"','"), dataTable2.Rows[k]["HM_ID4"]), (object)"',"), dataTable2.Rows[k]["HM_ID_WT"]), (object)","), dataTable2.Rows[k]["HM_ID2_WT"]), (object)","), dataTable2.Rows[k]["HM_ID3_WT"]), (object)","), dataTable2.Rows[k]["HM_ID4_WT"]), (object)",'"), dataTable2.Rows[k]["HM_ID"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable2 = null;
				int l = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_ORD_ADJ AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				DataTable dataTable3 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable4;
				for (dataTable4 = dataTable3; l < dataTable4.Rows.Count; l++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_ORD_ADJ(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,  VCH_TIME,BOOK_NAME,AC_CODE,AC_NAME,ORD_HD_VCH_NO,ORD_NO,ORD_LC,ORD_YRCD,ORD_DBCD,ORD_AC_CODE,ORD_SIGN,ORD_AMT,  ORD_GOLD,ORD_SILVER,PAID_AMT,OLD_VCH_NO,NEW_VCH_NO,DATA_TRFR,HD_VCH_NO,MAIN_USER,ADD_USER,KASAR_AMT,ORD_BAL_AMT,  IT_DESC,EMP_CODE,PAID_AC)   VALUES ('", dataTable4.Rows[l]["CO_CODE"]), (object)"','"), dataTable4.Rows[l]["LC_CODE"]), (object)"','"), dataTable4.Rows[l]["CO_YEAR"]), (object)"','"), dataTable4.Rows[l]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"',"), dataTable4.Rows[l]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable4.Rows[l]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), dataTable4.Rows[l]["VCH_TYPE"]), (object)"','"), dataTable4.Rows[l]["INOUT_TYPE"]), (object)"','"), dataTable4.Rows[l]["ENTRY_TYPE"]), (object)"', "), (object)" '"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable4.Rows[l]["VCH_TIME"]), "MM/dd/yyyy HH: mm : ss")), (object)"','"), dataTable4.Rows[l]["BOOK_NAME"]), (object)"','"), dataTable4.Rows[l]["AC_CODE"]), (object)"','"), dataTable4.Rows[l]["AC_NAME"]), (object)"','"), dataTable4.Rows[l]["ORD_NO"]), (object)"','"), dataTable4.Rows[l]["ORD_HD_VCH_NO"]), (object)"','"), dataTable4.Rows[l]["ORD_LC"]), (object)"','"), dataTable4.Rows[l]["ORD_YRCD"]), (object)"','"), dataTable4.Rows[l]["ORD_DBCD"]), (object)"','"), dataTable4.Rows[l]["ORD_AC_CODE"]), (object)"','"), dataTable4.Rows[l]["ORD_SIGN"]), (object)"',"), dataTable4.Rows[l]["ORD_AMT"]), (object)", "), (object)" "), dataTable4.Rows[l]["ORD_GOLD"]), (object)","), dataTable4.Rows[l]["ORD_SILVER"]), (object)","), dataTable4.Rows[l]["PAID_AMT"]), (object)",'"), dataTable4.Rows[l]["OLD_VCH_NO"]), (object)"','"), dataTable4.Rows[l]["NEW_VCH_NO"]), (object)"','"), dataTable4.Rows[l]["DATA_TRFR"]), (object)"','"), dataTable4.Rows[l]["HD_VCH_NO"]), (object)"','"), dataTable4.Rows[l]["MAIN_USER"]), (object)"','"), dataTable4.Rows[l]["ADD_USER"]), (object)"',"), dataTable4.Rows[l]["KASAR_AMT"]), (object)","), dataTable4.Rows[l]["ORD_BAL_AMT"]), (object)", "), (object)" '"), dataTable4.Rows[l]["IT_DESC"]), (object)"','"), dataTable4.Rows[l]["EMP_CODE"]), (object)"','"), dataTable4.Rows[l]["PAID_AC"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable4 = null;
				int m = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM UPI_DATA AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO,ISR_NO"));
				DataTable dataTable5 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable6;
				for (dataTable6 = dataTable5; m < dataTable6.Rows.Count; m++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO UPI_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TIME,  AC_CODE,UPI_AC_CODE,UPI_AC_NAME,UPI_AMT,MAIN_USER,UPI_ID)   VALUES ('", dataTable6.Rows[m]["CO_CODE"]), (object)"','"), dataTable6.Rows[m]["LC_CODE"]), (object)"','"), dataTable6.Rows[m]["CO_YEAR"]), (object)"','"), dataTable6.Rows[m]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"',"), dataTable6.Rows[m]["SR_NO"]), (object)","), dataTable6.Rows[m]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable6.Rows[m]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable6.Rows[m]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"', "), (object)" '"), dataTable6.Rows[m]["AC_CODE"]), (object)"','"), dataTable6.Rows[m]["UPI_AC_CODE"]), (object)"','"), dataTable6.Rows[m]["UPI_AC_NAME"]), (object)"',"), dataTable6.Rows[m]["UPI_AMT"]), (object)",'"), dataTable6.Rows[m]["MAIN_USER"]), (object)"','"), dataTable6.Rows[m]["UPI_ID"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable6 = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_ORD_DATA SET DATA_TRFR = 'Y',HD_VCH_NO = '" + BVchNo + "',RE_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			int n = 0;
			DC_Main.RsQry = "SELECT A.* FROM SL_ORD_ADJ AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N' AND B.MAIN_BOOK <> 'SALES' AND A.ORD_SIGN = '-' ORDER BY A.CO_BOOK,A.VCH_NO,A.SR_NO";
			DataTable dataTable7 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
			DataTable dataTable8;
			for (dataTable8 = dataTable7; n < dataTable8.Rows.Count; n++)
			{
				if (Operators.ConditionalCompareObjectEqual(dataTable8.Rows[n]["SR_NO"], (object)1, false))
				{
					int num2 = Strings.Len(RuntimeHelpers.GetObjectValue(dataTable8.Rows[n]["VCH_NO"]));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable8.Rows[n]["RE_TRFR"], (object)""), (object)"Y", false))
					{
						BVchNo = Conversions.ToString(Operators.ConcatenateObject(dataTable8.Rows[n]["HD_VCH_NO"], (object)""));
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,MAX(VCH_NO) As LAST_VCH_SR,RIGHT('00000' + CAST(ISNULL(CAST(MAX(VCH_NO) AS INT), 0) + 1 AS VARCHAR(10)), " + Conversions.ToString(num2) + ") AS NEXT_VCH_NO  From SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable8.Rows[n]["CO_BOOK"]), (object)"' Group By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK Order By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK"));
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							RsBVchNo = OpenRecordsetTrfr(DC_Main.RsQry);
						}
						else
						{
							RsBVchNo = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						}
						if (RsBVchNo.Rows.Count > 0)
						{
							BVchNo = Conversions.ToString(RsBVchNo.Rows[0]["NEXT_VCH_NO"]);
						}
						else
						{
							BVchNo = "00001";
						}
					}
				}
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable8.Rows[n]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"' AND SR_NO = "), dataTable8.Rows[n]["SR_NO"]), (object)"")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable8.Rows[n]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"' AND SR_NO = "), dataTable8.Rows[n]["SR_NO"]), (object)"")));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_ORD_ADJ(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,  VCH_TIME,BOOK_NAME,AC_CODE,AC_NAME,ORD_HD_VCH_NO,ORD_NO,ORD_LC,ORD_YRCD,ORD_DBCD,ORD_AC_CODE,ORD_SIGN,ORD_AMT,  ORD_GOLD,ORD_SILVER,PAID_AMT,OLD_VCH_NO,NEW_VCH_NO,DATA_TRFR,HD_VCH_NO,MAIN_USER,ADD_USER,KASAR_AMT,ORD_BAL_AMT,  IT_DESC,EMP_CODE,PAID_AC)   VALUES ('", dataTable8.Rows[n]["CO_CODE"]), (object)"','"), dataTable8.Rows[n]["LC_CODE"]), (object)"','"), dataTable8.Rows[n]["CO_YEAR"]), (object)"','"), dataTable8.Rows[n]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',"), dataTable8.Rows[n]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable8.Rows[n]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), dataTable8.Rows[n]["VCH_TYPE"]), (object)"','"), dataTable8.Rows[n]["INOUT_TYPE"]), (object)"','"), dataTable8.Rows[n]["ENTRY_TYPE"]), (object)"', "), (object)" '"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable8.Rows[n]["VCH_TIME"]), "MM/dd/yyyy HH: mm : ss")), (object)"','"), dataTable8.Rows[n]["BOOK_NAME"]), (object)"','"), dataTable8.Rows[n]["AC_CODE"]), (object)"','"), dataTable8.Rows[n]["AC_NAME"]), (object)"','"), dataTable8.Rows[n]["ORD_NO"]), (object)"','"), dataTable8.Rows[n]["ORD_HD_VCH_NO"]), (object)"','"), dataTable8.Rows[n]["ORD_LC"]), (object)"','"), dataTable8.Rows[n]["ORD_YRCD"]), (object)"','"), dataTable8.Rows[n]["ORD_DBCD"]), (object)"','"), dataTable8.Rows[n]["ORD_AC_CODE"]), (object)"','"), dataTable8.Rows[n]["ORD_SIGN"]), (object)"',"), dataTable8.Rows[n]["ORD_AMT"]), (object)", "), (object)" "), dataTable8.Rows[n]["ORD_GOLD"]), (object)","), dataTable8.Rows[n]["ORD_SILVER"]), (object)","), dataTable8.Rows[n]["PAID_AMT"]), (object)",'"), dataTable8.Rows[n]["OLD_VCH_NO"]), (object)"','"), dataTable8.Rows[n]["NEW_VCH_NO"]), (object)"','"), dataTable8.Rows[n]["DATA_TRFR"]), (object)"','"), dataTable8.Rows[n]["HD_VCH_NO"]), (object)"','"), dataTable8.Rows[n]["MAIN_USER"]), (object)"','"), dataTable8.Rows[n]["ADD_USER"]), (object)"',"), dataTable8.Rows[n]["KASAR_AMT"]), (object)","), dataTable8.Rows[n]["ORD_BAL_AMT"]), (object)", "), (object)" '"), dataTable8.Rows[n]["IT_DESC"]), (object)"','"), dataTable8.Rows[n]["EMP_CODE"]), (object)"','"), dataTable8.Rows[n]["PAID_AC"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_ORD_ADJ SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable8.Rows[n]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), dataTable8.Rows[n]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable8.Rows[n]["VCH_NO"]), (object)"' AND SR_NO = "), dataTable8.Rows[n]["SR_NO"]), (object)""));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
			}
			dataTable8 = null;
		}
	}

	private void Ab_ItmOPbl()
	{
		DC_Main.RsQry = "SELECT * FROM ITM_OPBL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.DATA_TRFR = 'N' ORDER BY A.IT_CODE";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Cash Bank";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ITM_OPBL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = '"), rshlp.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO ITM_OPBL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,IT_CODE,VCH_NO,SR_NO,  ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_FINE,ITM_RATE,ITM_AMT,LBR_AMT,OTH_AMT,NET_AMT,  DM_WT,DM_RATE,DM_AMT,MAIN_USER,ADD_DATE,LBR_RATE,LBR_TYPE,ITM_WEST_PRC,DATA_TRFR)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["IT_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"',"), rshlp.Rows[DC_Main.M]["SR_NO"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["ITM_PCS"]), (object)","), rshlp.Rows[DC_Main.M]["ITM_GWT"]), (object)","), rshlp.Rows[DC_Main.M]["ITM_NWT"]), (object)","), rshlp.Rows[DC_Main.M]["ITM_TOUCH"]), (object)","), rshlp.Rows[DC_Main.M]["ITM_FINE"]), (object)","), rshlp.Rows[DC_Main.M]["ITM_RATE"]), (object)","), rshlp.Rows[DC_Main.M]["ITM_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["LBR_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["OTH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["NET_AMT"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["DM_WT"]), (object)","), rshlp.Rows[DC_Main.M]["DM_RATE"]), (object)","), rshlp.Rows[DC_Main.M]["DM_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"',NULL,"), rshlp.Rows[DC_Main.M]["LBR_RATE"]), (object)",'"), rshlp.Rows[DC_Main.M]["LBR_TYPE"]), (object)"',"), rshlp.Rows[DC_Main.M]["ITM_WEST_PRC"]), (object)",'Y')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITM_OPBL SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = '"), rshlp.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ab_OpData()
	{
		DC_Main.RsQry = "SELECT * FROM OP_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.DATA_TRFR = 'N' ORDER BY A.AC_CODE";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Cash Bank";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"' AND DATA_TYPE = '"), rshlp.Rows[DC_Main.M]["DATA_TYPE"]), (object)"' "));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO OP_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,OP_AMT,OP_SIGN,  FINE_BAL,FINE_SIGN,SL_FINE_BAL,SL_FINE_SIGN,DATA_TYPE,MAIN_USER,ADD_USER,ADD_DATE,DATA_TRFR)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"',");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["OP_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["OP_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num), (object)",'"), rshlp.Rows[DC_Main.M]["OP_SIGN"]), (object)"', "), (object)" ");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["FINE_BAL"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["FINE_BAL"] = RuntimeHelpers.GetObjectValue(Value);
				object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)",'"), rshlp.Rows[DC_Main.M]["FINE_SIGN"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["SL_FINE_BAL"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["SL_FINE_BAL"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num3), (object)",'"), rshlp.Rows[DC_Main.M]["SL_FINE_SIGN"]), (object)"','"), rshlp.Rows[DC_Main.M]["DATA_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD_DATE"]), (object)"','Y')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE OP_DATA SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ab_Contra_FineJv()
	{
		DC_Main.RsQry = "SELECT * FROM CONTRA_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N' ORDER BY A.CO_BOOK,A.VCH_NO,A.SR_NO";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Contra and Fine Jv";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["SR_NO"])) == 1.0)
				{
					int num = Strings.Len(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_NO"]));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["RE_TRFR"], (object)""), (object)"Y", false))
					{
						BVchNo = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["HD_VCH_NO"], (object)""));
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,MAX(VCH_NO) As LAST_VCH_SR,RIGHT('00000' + CAST(ISNULL(CAST(MAX(VCH_NO) AS INT), 0) + 1 AS VARCHAR(10)), " + Conversions.ToString(num) + ") AS NEXT_VCH_NO  From CONTRA_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' Group By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK Order By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK"));
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							RsBVchNo = OpenRecordsetTrfr(DC_Main.RsQry);
						}
						else
						{
							RsBVchNo = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						}
						if (RsBVchNo.Rows.Count > 0)
						{
							BVchNo = Conversions.ToString(RsBVchNo.Rows[0]["NEXT_VCH_NO"]);
						}
						else
						{
							BVchNo = "00001";
						}
					}
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM CONTRA_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"' AND SR_NO = "), rshlp.Rows[DC_Main.M]["SR_NO"]), (object)" "));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO CONTRA_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,VCH_TIME,BOOK_NAME,AC_CODE,AC_NAME,LD_CODE,DR_AMT,CR_AMT,CRDR_TYPE,IT_DESC,LDR_TYPE,EMP_CODE,  OLD_VCH_NO,NEW_VCH_NO,DATA_TRFR,HD_VCH_NO,MAIN_USER,ADD_USER,CR_FINE,DR_FINE,IT_TYPE)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["SR_NO"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["SR_NO"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num2), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["INOUT_TYPE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["ENTRY_TYPE"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["LD_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["DR_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CR_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["CRDR_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["IT_DESC"]), (object)"','"), rshlp.Rows[DC_Main.M]["LDR_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["OLD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["NEW_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD_USER"]), (object)"',"), rshlp.Rows[DC_Main.M]["CR_FINE"]), (object)","), rshlp.Rows[DC_Main.M]["DR_FINE"]), (object)",'"), rshlp.Rows[DC_Main.M]["IT_TYPE"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE CONTRA_DATA SET DATA_TRFR = 'Y',HD_VCH_NO = '" + BVchNo + "',RE_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = "), rshlp.Rows[DC_Main.M]["SR_NO"]), (object)""));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ab_Bar_Cancel()
	{
		checked
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK056NEVK", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.* FROM BAR_CAN_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N' AND A.CO_BOOK <> '163'";
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				ProgressBar1.Value = 0;
				ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
				lblBook.Text = "Karigar";
				Application.DoEvents();
				DC_Main.M = 0;
				while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
				{
					DataTable rshlp = DC_Main.Rshlp;
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
						ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
						ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
					}
					else
					{
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_CAN_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,AC_CODE,  VCH_DESC,EMP_CODE,HD_VCH_NO,MAIN_USER,DATA_TRFR)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["VCH_DESC"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','Y')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					int i = 0;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM BAR_CAN_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					else
					{
						RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
					}
					DataTable rsDetl;
					for (rsDetl = RsDetl; i < rsDetl.Rows.Count; i++)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_CAN_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,  TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,  ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,ITM_REMARK,  VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_NAME,RATE_TYPE,IT_TYPE,  PR_CODE,HD_VCH_NO,MAIN_USER,ADD_USER,DATA_TRFR,ITM_SIGN,TRFR_IT_CODE,TO_TBL_CODE)   VALUES ('", rsDetl.Rows[i]["CO_CODE"]), (object)"','"), rsDetl.Rows[i]["LC_CODE"]), (object)"','"), rsDetl.Rows[i]["CO_YEAR"]), (object)"','"), rsDetl.Rows[i]["CO_BOOK"]), (object)"','"), rsDetl.Rows[i]["HD_VCH_NO"]), (object)"',"), rsDetl.Rows[i]["SR_NO"]), (object)","), rsDetl.Rows[i]["OLD_SRNO"]), (object)", "), (object)" '"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rsDetl.Rows[i]["VCH_TYPE"]), (object)"','"), rsDetl.Rows[i]["INOUT_TYPE"]), (object)"','"), rsDetl.Rows[i]["ENTRY_TYPE"]), (object)"','"), rsDetl.Rows[i]["BOOK_NAME"]), (object)"','"), rsDetl.Rows[i]["AC_CODE"]), (object)"','"), rsDetl.Rows[i]["IT_CODE"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["TAG_NO"]), (object)"','"), rsDetl.Rows[i]["LOT_NO"]), (object)"','"), rsDetl.Rows[i]["DESIGN_NO"]), (object)"','"), rsDetl.Rows[i]["TBL_CODE"]), (object)"','"), rsDetl.Rows[i]["ITM_SIZE"]), (object)"',"), rsDetl.Rows[i]["ITM_PCS"]), (object)","), rsDetl.Rows[i]["BAG_WT"]), (object)","), rsDetl.Rows[i]["ITM_GWT"]), (object)","), rsDetl.Rows[i]["ITM_OTH_WT"]), (object)","), rsDetl.Rows[i]["ITM_NWT"]), (object)", "), (object)" "), rsDetl.Rows[i]["ITM_GHT_WT"]), (object)","), rsDetl.Rows[i]["ITM_TOUCH"]), (object)","), rsDetl.Rows[i]["ITM_WEST_PRC"]), (object)","), rsDetl.Rows[i]["ITM_FINE"]), (object)","), rsDetl.Rows[i]["LBR_PRC"]), (object)","), rsDetl.Rows[i]["LBR_RATE"]), (object)",'"), rsDetl.Rows[i]["LBR_TYPE"]), (object)"', "), (object)" "), rsDetl.Rows[i]["LBR_AMT"]), (object)","), rsDetl.Rows[i]["OTH_AMT"]), (object)","), rsDetl.Rows[i]["ITM_RATE"]), (object)","), rsDetl.Rows[i]["ITM_AMT"]), (object)","), rsDetl.Rows[i]["TAG_COST"]), (object)","), rsDetl.Rows[i]["ITM_MRP"]), (object)",'"), rsDetl.Rows[i]["ITM_REMARK"]), (object)"', "), (object)" "), rsDetl.Rows[i]["VCH_SRNO"]), (object)","), rsDetl.Rows[i]["KR_NET_WT"]), (object)","), rsDetl.Rows[i]["KR_TOUCH"]), (object)","), rsDetl.Rows[i]["KR_WEST_PRC"]), (object)","), rsDetl.Rows[i]["KR_FINE"]), (object)",'"), rsDetl.Rows[i]["KR_NAME"]), (object)"','"), rsDetl.Rows[i]["RATE_TYPE"]), (object)"','"), rsDetl.Rows[i]["IT_TYPE"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["PR_CODE"]), (object)"','"), rsDetl.Rows[i]["VCH_NO"]), (object)"','"), rsDetl.Rows[i]["MAIN_USER"]), (object)"','"), rsDetl.Rows[i]["ADD_USER"]), (object)"','Y','"), rsDetl.Rows[i]["ITM_SIGN"]), (object)"','"), rsDetl.Rows[i]["TRFR_IT_CODE"]), (object)"','"), rsDetl.Rows[i]["TO_TBL_CODE"]), (object)"')"));
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							ExeQuteCnTr(DC_Main.RsQry);
						}
						else
						{
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
					}
					rsDetl = null;
					int j = 0;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM BAR_CAN_IDTL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO,ISR_NO"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					else
					{
						RsIdtl = OpenRecordsetTrfr(DC_Main.RsQry);
					}
					DataTable rsIdtl;
					for (rsIdtl = RsIdtl; j < rsIdtl.Rows.Count; j++)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_CAN_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,  DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,  IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER,HD_VCH_NO)   VALUES ('", rsIdtl.Rows[j]["CO_CODE"]), (object)"','"), rsIdtl.Rows[j]["LC_CODE"]), (object)"','"), rsIdtl.Rows[j]["CO_YEAR"]), (object)"','"), rsIdtl.Rows[j]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"',"), rsIdtl.Rows[j]["SR_NO"]), (object)","), rsIdtl.Rows[j]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsIdtl.Rows[j]["VCH_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), rsIdtl.Rows[j]["VCH_TYPE"]), (object)"','"), rsIdtl.Rows[j]["INOUT_TYPE"]), (object)"', '"), rsIdtl.Rows[j]["ENTRY_TYPE"]), (object)"','"), rsIdtl.Rows[j]["BOOK_NAME"]), (object)"','"), rsIdtl.Rows[j]["AC_CODE"]), (object)"','"), rsIdtl.Rows[j]["TAG_NO"]), (object)"',"), rsIdtl.Rows[j]["VCH_SRNO"]), (object)",'"), rsIdtl.Rows[j]["IT_CODE"]), (object)"','"), rsIdtl.Rows[j]["IT_TYPE"]), (object)"', "), (object)" '"), rsIdtl.Rows[j]["DM_CODE"]), (object)"','"), rsIdtl.Rows[j]["DM_SIZE"]), (object)"','"), rsIdtl.Rows[j]["DM_SFNO"]), (object)"','"), rsIdtl.Rows[j]["DM_LEB"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS"]), (object)"',"), rsIdtl.Rows[j]["IT_PCS_WT"]), (object)","), rsIdtl.Rows[j]["KR_WT"]), (object)","), rsIdtl.Rows[j]["KR_LESS_PRC"]), (object)","), rsIdtl.Rows[j]["IT_GWT"]), (object)","), rsIdtl.Rows[j]["IT_CON_PRC"]), (object)", "), (object)" "), rsIdtl.Rows[j]["IT_CON_WT"]), (object)",'"), rsIdtl.Rows[j]["IT_RATE_TYPE"]), (object)"',"), rsIdtl.Rows[j]["IT_RATE"]), (object)","), rsIdtl.Rows[j]["IT_AMT"]), (object)","), rsIdtl.Rows[j]["IT_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["IT_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["IT_NET_AMT"]), (object)","), rsIdtl.Rows[j]["KR_CON_PRC"]), (object)", "), (object)" "), rsIdtl.Rows[j]["KR_CON_WT"]), (object)","), rsIdtl.Rows[j]["KR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_NET_AMT"]), (object)",'"), rsIdtl.Rows[j]["MAIN_USER"]), (object)"','"), rsIdtl.Rows[j]["VCH_NO"]), (object)"')"));
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							ExeQuteCnTr(DC_Main.RsQry);
						}
						else
						{
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
					}
					rsIdtl = null;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_CAN_DATA SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					else
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					rshlp = null;
					DC_Main.M++;
					ProgressBar progressBar;
					(progressBar = ProgressBar1).Value = progressBar.Value + 1;
					Application.DoEvents();
				}
				return;
			}
			DC_Main.RsQry = "SELECT A.* FROM BAR_CAN_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N' AND A.CO_BOOK <> '163'";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Karigar";
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp2 = DC_Main.Rshlp;
				int num = Strings.Len(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["VCH_NO"]));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp2.Rows[DC_Main.M]["RE_TRFR"], (object)""), (object)"Y", false))
				{
					BVchNo = Conversions.ToString(Operators.ConcatenateObject(rshlp2.Rows[DC_Main.M]["HD_VCH_NO"], (object)""));
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,MAX(VCH_NO) As LAST_VCH_SR,RIGHT('00000' + CAST(ISNULL(CAST(MAX(VCH_NO) AS INT), 0) + 1 AS VARCHAR(10)), " + Conversions.ToString(num) + ") AS NEXT_VCH_NO  From BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' Group By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK Order By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						RsBVchNo = OpenRecordsetTrfr(DC_Main.RsQry);
					}
					else
					{
						RsBVchNo = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					if (RsBVchNo.Rows.Count > 0)
					{
						BVchNo = Conversions.ToString(RsBVchNo.Rows[0]["NEXT_VCH_NO"]);
					}
					else
					{
						BVchNo = "00001";
					}
				}
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_CAN_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,AC_CODE,  VCH_DESC,EMP_CODE,HD_VCH_NO,MAIN_USER,DATA_TRFR)   VALUES ('", rshlp2.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_CODE"]), (object)"', "), (object)" '"), rshlp2.Rows[DC_Main.M]["VCH_DESC"]), (object)"','"), rshlp2.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), rshlp2.Rows[DC_Main.M]["MAIN_USER"]), (object)"','Y')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int k = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM BAR_CAN_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp2.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsDetl2;
				for (rsDetl2 = RsDetl; k < rsDetl2.Rows.Count; k++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_CAN_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,  TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,  ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,ITM_REMARK,  VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_NAME,RATE_TYPE,IT_TYPE,  PR_CODE,HD_VCH_NO,MAIN_USER,ADD_USER,DATA_TRFR,ITM_SIGN,TRFR_IT_CODE,TO_TBL_CODE)   VALUES ('", rsDetl2.Rows[k]["CO_CODE"]), (object)"','"), rsDetl2.Rows[k]["LC_CODE"]), (object)"','"), rsDetl2.Rows[k]["CO_YEAR"]), (object)"','"), rsDetl2.Rows[k]["CO_BOOK"]), (object)"','"), rsDetl2.Rows[k]["HD_VCH_NO"]), (object)"',"), rsDetl2.Rows[k]["SR_NO"]), (object)","), rsDetl2.Rows[k]["OLD_SRNO"]), (object)", "), (object)" '"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl2.Rows[k]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl2.Rows[k]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rsDetl2.Rows[k]["VCH_TYPE"]), (object)"','"), rsDetl2.Rows[k]["INOUT_TYPE"]), (object)"','"), rsDetl2.Rows[k]["ENTRY_TYPE"]), (object)"','"), rsDetl2.Rows[k]["BOOK_NAME"]), (object)"','"), rsDetl2.Rows[k]["AC_CODE"]), (object)"','"), rsDetl2.Rows[k]["IT_CODE"]), (object)"', "), (object)" '"), rsDetl2.Rows[k]["TAG_NO"]), (object)"','"), rsDetl2.Rows[k]["LOT_NO"]), (object)"','"), rsDetl2.Rows[k]["DESIGN_NO"]), (object)"','"), rsDetl2.Rows[k]["TBL_CODE"]), (object)"','"), rsDetl2.Rows[k]["ITM_SIZE"]), (object)"',"), rsDetl2.Rows[k]["ITM_PCS"]), (object)","), rsDetl2.Rows[k]["BAG_WT"]), (object)","), rsDetl2.Rows[k]["ITM_GWT"]), (object)","), rsDetl2.Rows[k]["ITM_OTH_WT"]), (object)","), rsDetl2.Rows[k]["ITM_NWT"]), (object)", "), (object)" "), rsDetl2.Rows[k]["ITM_GHT_WT"]), (object)","), rsDetl2.Rows[k]["ITM_TOUCH"]), (object)","), rsDetl2.Rows[k]["ITM_WEST_PRC"]), (object)","), rsDetl2.Rows[k]["ITM_FINE"]), (object)","), rsDetl2.Rows[k]["LBR_PRC"]), (object)","), rsDetl2.Rows[k]["LBR_RATE"]), (object)",'"), rsDetl2.Rows[k]["LBR_TYPE"]), (object)"', "), (object)" "), rsDetl2.Rows[k]["LBR_AMT"]), (object)","), rsDetl2.Rows[k]["OTH_AMT"]), (object)","), rsDetl2.Rows[k]["ITM_RATE"]), (object)","), rsDetl2.Rows[k]["ITM_AMT"]), (object)","), rsDetl2.Rows[k]["TAG_COST"]), (object)","), rsDetl2.Rows[k]["ITM_MRP"]), (object)",'"), rsDetl2.Rows[k]["ITM_REMARK"]), (object)"', "), (object)" "), rsDetl2.Rows[k]["VCH_SRNO"]), (object)","), rsDetl2.Rows[k]["KR_NET_WT"]), (object)","), rsDetl2.Rows[k]["KR_TOUCH"]), (object)","), rsDetl2.Rows[k]["KR_WEST_PRC"]), (object)","), rsDetl2.Rows[k]["KR_FINE"]), (object)",'"), rsDetl2.Rows[k]["KR_NAME"]), (object)"','"), rsDetl2.Rows[k]["RATE_TYPE"]), (object)"','"), rsDetl2.Rows[k]["IT_TYPE"]), (object)"', "), (object)" '"), rsDetl2.Rows[k]["PR_CODE"]), (object)"','"), rsDetl2.Rows[k]["VCH_NO"]), (object)"','"), rsDetl2.Rows[k]["MAIN_USER"]), (object)"','"), rsDetl2.Rows[k]["ADD_USER"]), (object)"','Y','"), rsDetl2.Rows[k]["ITM_SIGN"]), (object)"','"), rsDetl2.Rows[k]["TRFR_IT_CODE"]), (object)"','"), rsDetl2.Rows[k]["TO_TBL_CODE"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsDetl2 = null;
				int l = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM BAR_CAN_IDTL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp2.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO,ISR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsIdtl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsIdtl2;
				for (rsIdtl2 = RsIdtl; l < rsIdtl2.Rows.Count; l++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_CAN_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,  DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,  IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER,HD_VCH_NO)   VALUES ('", rsIdtl2.Rows[l]["CO_CODE"]), (object)"','"), rsIdtl2.Rows[l]["LC_CODE"]), (object)"','"), rsIdtl2.Rows[l]["CO_YEAR"]), (object)"','"), rsIdtl2.Rows[l]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',"), rsIdtl2.Rows[l]["SR_NO"]), (object)","), rsIdtl2.Rows[l]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsIdtl2.Rows[l]["VCH_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), rsIdtl2.Rows[l]["VCH_TYPE"]), (object)"','"), rsIdtl2.Rows[l]["INOUT_TYPE"]), (object)"', '"), rsIdtl2.Rows[l]["ENTRY_TYPE"]), (object)"','"), rsIdtl2.Rows[l]["BOOK_NAME"]), (object)"','"), rsIdtl2.Rows[l]["AC_CODE"]), (object)"','"), rsIdtl2.Rows[l]["TAG_NO"]), (object)"',"), rsIdtl2.Rows[l]["VCH_SRNO"]), (object)",'"), rsIdtl2.Rows[l]["IT_CODE"]), (object)"','"), rsIdtl2.Rows[l]["IT_TYPE"]), (object)"', "), (object)" '"), rsIdtl2.Rows[l]["DM_CODE"]), (object)"','"), rsIdtl2.Rows[l]["DM_SIZE"]), (object)"','"), rsIdtl2.Rows[l]["DM_SFNO"]), (object)"','"), rsIdtl2.Rows[l]["DM_LEB"]), (object)"','"), rsIdtl2.Rows[l]["IT_PCS"]), (object)"',"), rsIdtl2.Rows[l]["IT_PCS_WT"]), (object)","), rsIdtl2.Rows[l]["KR_WT"]), (object)","), rsIdtl2.Rows[l]["KR_LESS_PRC"]), (object)","), rsIdtl2.Rows[l]["IT_GWT"]), (object)","), rsIdtl2.Rows[l]["IT_CON_PRC"]), (object)", "), (object)" "), rsIdtl2.Rows[l]["IT_CON_WT"]), (object)",'"), rsIdtl2.Rows[l]["IT_RATE_TYPE"]), (object)"',"), rsIdtl2.Rows[l]["IT_RATE"]), (object)","), rsIdtl2.Rows[l]["IT_AMT"]), (object)","), rsIdtl2.Rows[l]["IT_LBR_RATE"]), (object)","), rsIdtl2.Rows[l]["IT_LBR_AMT"]), (object)","), rsIdtl2.Rows[l]["IT_NET_AMT"]), (object)","), rsIdtl2.Rows[l]["KR_CON_PRC"]), (object)", "), (object)" "), rsIdtl2.Rows[l]["KR_CON_WT"]), (object)","), rsIdtl2.Rows[l]["KR_RATE"]), (object)","), rsIdtl2.Rows[l]["KR_AMT"]), (object)","), rsIdtl2.Rows[l]["KR_LBR_RATE"]), (object)","), rsIdtl2.Rows[l]["KR_LBR_AMT"]), (object)","), rsIdtl2.Rows[l]["KR_NET_AMT"]), (object)",'"), rsIdtl2.Rows[l]["MAIN_USER"]), (object)"','"), rsIdtl2.Rows[l]["VCH_NO"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsIdtl2 = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_CAN_DATA SET DATA_TRFR = 'Y',HD_VCH_NO = '" + BVchNo + "',RE_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp2.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp2 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ab_BarData()
	{
		checked
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK056NEVK", false) == 0)
			{
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc("UPDATE BAR_DATA SET HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND HD_VCH_NO IS NULL OR HD_VCH_NO = ''");
					DC_Main.ExeQuteDc("UPDATE BAR_DETL SET HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND HD_VCH_NO IS NULL OR HD_VCH_NO = ''");
				}
				else
				{
					ExeQuteCnTr("UPDATE BAR_DATA SET HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND HD_VCH_NO IS NULL OR HD_VCH_NO = ''");
					ExeQuteCnTr("UPDATE BAR_DETL SET HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND HD_VCH_NO IS NULL OR HD_VCH_NO = ''");
				}
				DC_Main.RsQry = "SELECT A.* FROM BAR_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N'";
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				ProgressBar1.Value = 0;
				ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
				lblBook.Text = "BarData";
				Application.DoEvents();
				DC_Main.M = 0;
				while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
				{
					DataTable rshlp = DC_Main.Rshlp;
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
						ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
						ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
					}
					else
					{
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"'")));
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,AC_CODE,CUST_AC,  OP_STK,STK_IT_CODE,EMP_CODE,VCH_DESC,HD_VCH_NO,MAIN_USER,DATA_TRFR)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CUST_AC"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["OP_STK"]), (object)"','"), rshlp.Rows[DC_Main.M]["STK_IT_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_DESC"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','Y')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					int i = 0;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM BAR_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					else
					{
						RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
					}
					DataTable rsDetl;
					for (rsDetl = RsDetl; i < rsDetl.Rows.Count; i++)
					{
						object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,  TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,  ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,  KR_NAME,KR_OTH_WT,KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,  KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,TAG_SRNO,VCH_SRNO,RATE_TYPE,IT_TYPE,  TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,ORD_AC,MAIN_USER,ADD_USER,DATA_TRFR,  HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,HM_ID,HM_ID2,HM_ID3,HM_ID4,  HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,DATA_TYPE,APP_TRFR,ITM_COLOR,  MAIN_MARGIN_PRC,MAIN_MRP,JDT_JDT_WT,JDT_GHT_WT,JDT_KUN_WT,JDT_WAX_WT,KR_WAX_WT,JDT_KUN_TOUCH,JDT_KUN_NET,EMP_ISU)   VALUES ('", rsDetl.Rows[i]["CO_CODE"]), (object)"','"), rsDetl.Rows[i]["LC_CODE"]), (object)"','"), rsDetl.Rows[i]["CO_YEAR"]), (object)"','"), rsDetl.Rows[i]["CO_BOOK"]), (object)"','"), rsDetl.Rows[i]["HD_VCH_NO"]), (object)"',"), rsDetl.Rows[i]["SR_NO"]), (object)","), rsDetl.Rows[i]["OLD_SRNO"]), (object)", "), (object)" '"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["STK_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_DATE"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rsDetl.Rows[i]["VCH_TYPE"]), (object)"','"), rsDetl.Rows[i]["INOUT_TYPE"]), (object)"','"), rsDetl.Rows[i]["ENTRY_TYPE"]), (object)"','"), rsDetl.Rows[i]["BOOK_NAME"]), (object)"','"), rsDetl.Rows[i]["AC_CODE"]), (object)"','"), rsDetl.Rows[i]["IT_CODE"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["TAG_NO"]), (object)""), (object)"','"), rsDetl.Rows[i]["LOT_NO"]), (object)""), (object)"','"), rsDetl.Rows[i]["DESIGN_NO"]), (object)""), (object)"','"), rsDetl.Rows[i]["TBL_CODE"]), (object)""), (object)"','"), rsDetl.Rows[i]["ITM_SIZE"]), (object)""), (object)"',"), rsDetl.Rows[i]["ITM_PCS"]), (object)","), rsDetl.Rows[i]["BAG_WT"]), (object)","), rsDetl.Rows[i]["ITM_GWT"]), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["ITM_OTH_WT"])), "0.000")), (object)","), rsDetl.Rows[i]["ITM_NWT"]), (object)", "), (object)" "), rsDetl.Rows[i]["ITM_GHT_PRC"]), (object)","), rsDetl.Rows[i]["ITM_GHT_WT"]), (object)","), rsDetl.Rows[i]["ITM_TOUCH"]), (object)","), rsDetl.Rows[i]["ITM_WEST_PRC"]), (object)","), rsDetl.Rows[i]["ITM_FINE"]), (object)","), rsDetl.Rows[i]["LBR_PRC"]), (object)","), rsDetl.Rows[i]["LBR_RATE"]), (object)",'"), rsDetl.Rows[i]["LBR_TYPE"]), (object)""), (object)"', "), (object)" "), rsDetl.Rows[i]["LBR_AMT"]), (object)","), rsDetl.Rows[i]["OTH_AMT"]), (object)","), rsDetl.Rows[i]["ITM_RATE"]), (object)","), rsDetl.Rows[i]["ITM_AMT"]), (object)","), rsDetl.Rows[i]["TAG_COST"]), (object)","), rsDetl.Rows[i]["ITM_MARGIN"]), (object)","), rsDetl.Rows[i]["ITM_MRP"]), (object)",'"), rsDetl.Rows[i]["ITM_REMARK"]), (object)""), (object)"','"), rsDetl.Rows[i]["SF_NO"]), (object)""), (object)"', "), (object)" '"), rsDetl.Rows[i]["KR_NAME"]), (object)"',"), rsDetl.Rows[i]["KR_OTH_WT"]), (object)","), rsDetl.Rows[i]["KR_NET_WT"]), (object)","), rsDetl.Rows[i]["KR_GHT_PRC"]), (object)","), rsDetl.Rows[i]["KR_GHT_WT"]), (object)","), rsDetl.Rows[i]["KR_TOUCH"]), (object)","), rsDetl.Rows[i]["KR_WEST_PRC"]), (object)","), rsDetl.Rows[i]["KR_FINE"]), (object)", "), (object)" "), rsDetl.Rows[i]["KR_LBR_RATE"]), (object)","), rsDetl.Rows[i]["KR_LBR_AMT"]), (object)","), rsDetl.Rows[i]["KR_OTH_AMT"]), (object)","), rsDetl.Rows[i]["KR_COST"]), (object)","), rsDetl.Rows[i]["TAG_SRNO"]), (object)","), rsDetl.Rows[i]["VCH_SRNO"]), (object)",'"), rsDetl.Rows[i]["RATE_TYPE"]), (object)"','"), rsDetl.Rows[i]["IT_TYPE"]), (object)""), (object)"', "), (object)" '"), rsDetl.Rows[i]["TAG_TYPE"]), (object)""), (object)"','"), rsDetl.Rows[i]["PR_CODE"]), (object)"','"), rsDetl.Rows[i]["APR_ISU"]), (object)"','"), rsDetl.Rows[i]["ORD_NO"]), (object)"',"), rsDetl.Rows[i]["ORD_SRNO"]), (object)",'"), rsDetl.Rows[i]["ORD_YRCD"]), (object)"','"), rsDetl.Rows[i]["ORD_DBCD"]), (object)"','"), rsDetl.Rows[i]["ORD_AC"]), (object)"','"), rsDetl.Rows[i]["MAIN_USER"]), (object)"','"), rsDetl.Rows[i]["ADD_USER"]), (object)"','"), rsDetl.Rows[i]["DATA_TRFR"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["VCH_NO"]), (object)"','"), rsDetl.Rows[i]["OLD_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["NEW_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["HM_ID"]), (object)"','"), rsDetl.Rows[i]["HM_ID2"]), (object)"','"), rsDetl.Rows[i]["HM_ID3"]), (object)"','"), rsDetl.Rows[i]["HM_ID4"]), (object)"', "), (object)" ");
						DataRow dataRow;
						object Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["HM_ID_WT"]);
						double num = DC_Main.Fnv(ref Value);
						dataRow["HM_ID_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["HM_ID2_WT"]);
						double num2 = DC_Main.Fnv(ref Value);
						dataRow["HM_ID2_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["HM_ID3_WT"]);
						double num3 = DC_Main.Fnv(ref Value);
						dataRow["HM_ID3_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num3), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["HM_ID4_WT"]);
						double num4 = DC_Main.Fnv(ref Value);
						dataRow["HM_ID4_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num4), (object)",'"), rsDetl.Rows[i]["DATA_TYPE"]), (object)"','"), rsDetl.Rows[i]["APP_TRFR"]), (object)"','"), rsDetl.Rows[i]["ITM_COLOR"]), (object)"', "), (object)" ");
						Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["MAIN_MARGIN_PRC"]);
						double num5 = DC_Main.Fnv(ref Value);
						dataRow["MAIN_MARGIN_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num5), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["MAIN_MRP"]);
						double num6 = DC_Main.Fnv(ref Value);
						dataRow["MAIN_MRP"] = RuntimeHelpers.GetObjectValue(Value);
						object obj7 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num6), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["JDT_JDT_WT"]);
						double num7 = DC_Main.Fnv(ref Value);
						dataRow["JDT_JDT_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj8 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, (object)num7), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["JDT_GHT_WT"]);
						double num8 = DC_Main.Fnv(ref Value);
						dataRow["JDT_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj9 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj8, (object)num8), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["JDT_KUN_WT"]);
						double num9 = DC_Main.Fnv(ref Value);
						dataRow["JDT_KUN_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj10 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj9, (object)num9), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["JDT_WAX_WT"]);
						double num10 = DC_Main.Fnv(ref Value);
						dataRow["JDT_WAX_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj11 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj10, (object)num10), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["KR_WAX_WT"]);
						double num11 = DC_Main.Fnv(ref Value);
						dataRow["KR_WAX_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj12 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj11, (object)num11), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["JDT_KUN_TOUCH"]);
						double num12 = DC_Main.Fnv(ref Value);
						dataRow["JDT_KUN_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
						object obj13 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj12, (object)num12), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["JDT_KUN_NET"]);
						double num13 = DC_Main.Fnv(ref Value);
						dataRow["JDT_KUN_NET"] = RuntimeHelpers.GetObjectValue(Value);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj13, (object)num13), (object)",'"), rsDetl.Rows[i]["EMP_ISU"]), (object)"')"));
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							ExeQuteCnTr(DC_Main.RsQry);
						}
						else
						{
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
					}
					rsDetl = null;
					int j = 0;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM BAR_IDTL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO,ISR_NO"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					else
					{
						RsIdtl = OpenRecordsetTrfr(DC_Main.RsQry);
					}
					DataTable rsIdtl;
					for (rsIdtl = RsIdtl; j < rsIdtl.Rows.Count; j++)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,  DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,  IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER)   VALUES ('", rsIdtl.Rows[j]["CO_CODE"]), (object)"','"), rsIdtl.Rows[j]["LC_CODE"]), (object)"','"), rsIdtl.Rows[j]["CO_YEAR"]), (object)"','"), rsIdtl.Rows[j]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"',"), rsIdtl.Rows[j]["SR_NO"]), (object)","), rsIdtl.Rows[j]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsIdtl.Rows[j]["VCH_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), rsIdtl.Rows[j]["VCH_TYPE"]), (object)"','"), rsIdtl.Rows[j]["INOUT_TYPE"]), (object)"', '"), rsIdtl.Rows[j]["ENTRY_TYPE"]), (object)"','"), rsIdtl.Rows[j]["BOOK_NAME"]), (object)"','"), rsIdtl.Rows[j]["AC_CODE"]), (object)"','"), rsIdtl.Rows[j]["TAG_NO"]), (object)"',"), rsIdtl.Rows[j]["VCH_SRNO"]), (object)",'"), rsIdtl.Rows[j]["IT_CODE"]), (object)"','"), rsIdtl.Rows[j]["IT_TYPE"]), (object)"', "), (object)" '"), rsIdtl.Rows[j]["DM_CODE"]), (object)"','"), rsIdtl.Rows[j]["DM_SIZE"]), (object)"','"), rsIdtl.Rows[j]["DM_SFNO"]), (object)"','"), rsIdtl.Rows[j]["DM_LEB"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS"]), (object)"',"), rsIdtl.Rows[j]["IT_PCS_WT"]), (object)","), rsIdtl.Rows[j]["KR_WT"]), (object)","), rsIdtl.Rows[j]["KR_LESS_PRC"]), (object)","), rsIdtl.Rows[j]["IT_GWT"]), (object)","), rsIdtl.Rows[j]["IT_CON_PRC"]), (object)", "), (object)" "), rsIdtl.Rows[j]["IT_CON_WT"]), (object)",'"), rsIdtl.Rows[j]["IT_RATE_TYPE"]), (object)"',"), rsIdtl.Rows[j]["IT_RATE"]), (object)","), rsIdtl.Rows[j]["IT_AMT"]), (object)","), rsIdtl.Rows[j]["IT_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["IT_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["IT_NET_AMT"]), (object)","), rsIdtl.Rows[j]["KR_CON_PRC"]), (object)", "), (object)" "), rsIdtl.Rows[j]["KR_CON_WT"]), (object)","), rsIdtl.Rows[j]["KR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_NET_AMT"]), (object)",'"), rsIdtl.Rows[j]["MAIN_USER"]), (object)"')"));
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							ExeQuteCnTr(DC_Main.RsQry);
						}
						else
						{
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
					}
					rsIdtl = null;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DATA SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					else
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					rshlp = null;
					DC_Main.M++;
					ProgressBar progressBar;
					(progressBar = ProgressBar1).Value = progressBar.Value + 1;
					Application.DoEvents();
				}
				TempbookVchInsert();
				return;
			}
			DC_Main.RsQry = "SELECT A.* FROM BAR_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N'";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "BarData";
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp2 = DC_Main.Rshlp;
				int num14 = Strings.Len(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["VCH_NO"]));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp2.Rows[DC_Main.M]["RE_TRFR"], (object)""), (object)"Y", false))
				{
					BVchNo = Conversions.ToString(Operators.ConcatenateObject(rshlp2.Rows[DC_Main.M]["HD_VCH_NO"], (object)""));
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,MAX(VCH_NO) As LAST_VCH_SR,RIGHT('00000' + CAST(ISNULL(CAST(MAX(VCH_NO) AS INT), 0) + 1 AS VARCHAR(10)), " + Conversions.ToString(num14) + ") AS NEXT_VCH_NO  From BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' Group By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK Order By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						RsBVchNo = OpenRecordsetTrfr(DC_Main.RsQry);
					}
					else
					{
						RsBVchNo = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					if (RsBVchNo.Rows.Count > 0)
					{
						BVchNo = Conversions.ToString(RsBVchNo.Rows[0]["NEXT_VCH_NO"]);
					}
					else
					{
						BVchNo = "00001";
					}
				}
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,AC_CODE,CUST_AC,  OP_STK,STK_IT_CODE,EMP_CODE,VCH_DESC,HD_VCH_NO,MAIN_USER,DATA_TRFR)   VALUES ('", rshlp2.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["CUST_AC"]), (object)"', "), (object)" '"), rshlp2.Rows[DC_Main.M]["OP_STK"]), (object)"','"), rshlp2.Rows[DC_Main.M]["STK_IT_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["VCH_DESC"]), (object)"','"), rshlp2.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), rshlp2.Rows[DC_Main.M]["MAIN_USER"]), (object)"','Y')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int k = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM BAR_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp2.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsDetl2;
				for (rsDetl2 = RsDetl; k < rsDetl2.Rows.Count; k++)
				{
					object obj14 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,  TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,  ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,  KR_NAME,KR_OTH_WT,KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,  KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,TAG_SRNO,VCH_SRNO,RATE_TYPE,IT_TYPE,  TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,ORD_AC,MAIN_USER,ADD_USER,DATA_TRFR,  HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,HM_ID,HM_ID2,HM_ID3,HM_ID4,  HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,DATA_TYPE,APP_TRFR,ITM_COLOR,  MAIN_MARGIN_PRC,MAIN_MRP,JDT_JDT_WT,JDT_GHT_WT,JDT_KUN_WT,JDT_WAX_WT,KR_WAX_WT,JDT_KUN_TOUCH,JDT_KUN_NET,EMP_ISU)   VALUES ('", rsDetl2.Rows[k]["CO_CODE"]), (object)"','"), rsDetl2.Rows[k]["LC_CODE"]), (object)"','"), rsDetl2.Rows[k]["CO_YEAR"]), (object)"','"), rsDetl2.Rows[k]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',"), rsDetl2.Rows[k]["SR_NO"]), (object)","), rsDetl2.Rows[k]["OLD_SRNO"]), (object)", "), (object)" '"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl2.Rows[k]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl2.Rows[k]["STK_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl2.Rows[k]["VCH_DATE"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rsDetl2.Rows[k]["VCH_TYPE"]), (object)"','"), rsDetl2.Rows[k]["INOUT_TYPE"]), (object)"','"), rsDetl2.Rows[k]["ENTRY_TYPE"]), (object)"','"), rsDetl2.Rows[k]["BOOK_NAME"]), (object)"','"), rsDetl2.Rows[k]["AC_CODE"]), (object)"','"), rsDetl2.Rows[k]["IT_CODE"]), (object)"', "), (object)" '"), rsDetl2.Rows[k]["TAG_NO"]), (object)""), (object)"','"), rsDetl2.Rows[k]["LOT_NO"]), (object)""), (object)"','"), rsDetl2.Rows[k]["DESIGN_NO"]), (object)""), (object)"','"), rsDetl2.Rows[k]["TBL_CODE"]), (object)""), (object)"','"), rsDetl2.Rows[k]["ITM_SIZE"]), (object)""), (object)"',"), rsDetl2.Rows[k]["ITM_PCS"]), (object)","), rsDetl2.Rows[k]["BAG_WT"]), (object)","), rsDetl2.Rows[k]["ITM_GWT"]), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(rsDetl2.Rows[k]["ITM_OTH_WT"])), "0.000")), (object)","), rsDetl2.Rows[k]["ITM_NWT"]), (object)", "), (object)" "), rsDetl2.Rows[k]["ITM_GHT_PRC"]), (object)","), rsDetl2.Rows[k]["ITM_GHT_WT"]), (object)","), rsDetl2.Rows[k]["ITM_TOUCH"]), (object)","), rsDetl2.Rows[k]["ITM_WEST_PRC"]), (object)","), rsDetl2.Rows[k]["ITM_FINE"]), (object)","), rsDetl2.Rows[k]["LBR_PRC"]), (object)","), rsDetl2.Rows[k]["LBR_RATE"]), (object)",'"), rsDetl2.Rows[k]["LBR_TYPE"]), (object)""), (object)"', "), (object)" "), rsDetl2.Rows[k]["LBR_AMT"]), (object)","), rsDetl2.Rows[k]["OTH_AMT"]), (object)","), rsDetl2.Rows[k]["ITM_RATE"]), (object)","), rsDetl2.Rows[k]["ITM_AMT"]), (object)","), rsDetl2.Rows[k]["TAG_COST"]), (object)","), rsDetl2.Rows[k]["ITM_MARGIN"]), (object)","), rsDetl2.Rows[k]["ITM_MRP"]), (object)",'"), rsDetl2.Rows[k]["ITM_REMARK"]), (object)""), (object)"','"), rsDetl2.Rows[k]["SF_NO"]), (object)""), (object)"', "), (object)" '"), rsDetl2.Rows[k]["KR_NAME"]), (object)"',"), rsDetl2.Rows[k]["KR_OTH_WT"]), (object)","), rsDetl2.Rows[k]["KR_NET_WT"]), (object)","), rsDetl2.Rows[k]["KR_GHT_PRC"]), (object)","), rsDetl2.Rows[k]["KR_GHT_WT"]), (object)","), rsDetl2.Rows[k]["KR_TOUCH"]), (object)","), rsDetl2.Rows[k]["KR_WEST_PRC"]), (object)","), rsDetl2.Rows[k]["KR_FINE"]), (object)", "), (object)" "), rsDetl2.Rows[k]["KR_LBR_RATE"]), (object)","), rsDetl2.Rows[k]["KR_LBR_AMT"]), (object)","), rsDetl2.Rows[k]["KR_OTH_AMT"]), (object)","), rsDetl2.Rows[k]["KR_COST"]), (object)","), rsDetl2.Rows[k]["TAG_SRNO"]), (object)","), rsDetl2.Rows[k]["VCH_SRNO"]), (object)",'"), rsDetl2.Rows[k]["RATE_TYPE"]), (object)"','"), rsDetl2.Rows[k]["IT_TYPE"]), (object)""), (object)"', "), (object)" '"), rsDetl2.Rows[k]["TAG_TYPE"]), (object)""), (object)"','"), rsDetl2.Rows[k]["PR_CODE"]), (object)"','"), rsDetl2.Rows[k]["APR_ISU"]), (object)"','"), rsDetl2.Rows[k]["ORD_NO"]), (object)"',"), rsDetl2.Rows[k]["ORD_SRNO"]), (object)",'"), rsDetl2.Rows[k]["ORD_YRCD"]), (object)"','"), rsDetl2.Rows[k]["ORD_DBCD"]), (object)"','"), rsDetl2.Rows[k]["ORD_AC"]), (object)"','"), rsDetl2.Rows[k]["MAIN_USER"]), (object)"','"), rsDetl2.Rows[k]["ADD_USER"]), (object)"','"), rsDetl2.Rows[k]["DATA_TRFR"]), (object)"', "), (object)" '"), rsDetl2.Rows[k]["VCH_NO"]), (object)"','"), rsDetl2.Rows[k]["OLD_VCH_NO"]), (object)"','"), rsDetl2.Rows[k]["NEW_VCH_NO"]), (object)"','"), rsDetl2.Rows[k]["HM_ID"]), (object)"','"), rsDetl2.Rows[k]["HM_ID2"]), (object)"','"), rsDetl2.Rows[k]["HM_ID3"]), (object)"','"), rsDetl2.Rows[k]["HM_ID4"]), (object)"', "), (object)" ");
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[k])["HM_ID_WT"]);
					double num15 = DC_Main.Fnv(ref Value);
					dataRow["HM_ID_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj15 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj14, (object)num15), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[k])["HM_ID2_WT"]);
					double num16 = DC_Main.Fnv(ref Value);
					dataRow["HM_ID2_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj16 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj15, (object)num16), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[k])["HM_ID3_WT"]);
					double num17 = DC_Main.Fnv(ref Value);
					dataRow["HM_ID3_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj17 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj16, (object)num17), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[k])["HM_ID4_WT"]);
					double num18 = DC_Main.Fnv(ref Value);
					dataRow["HM_ID4_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj18 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj17, (object)num18), (object)",'"), rsDetl2.Rows[k]["DATA_TYPE"]), (object)"','"), rsDetl2.Rows[k]["APP_TRFR"]), (object)"','"), rsDetl2.Rows[k]["ITM_COLOR"]), (object)"', "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[k])["MAIN_MARGIN_PRC"]);
					double num19 = DC_Main.Fnv(ref Value);
					dataRow["MAIN_MARGIN_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj19 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj18, (object)num19), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[k])["MAIN_MRP"]);
					double num20 = DC_Main.Fnv(ref Value);
					dataRow["MAIN_MRP"] = RuntimeHelpers.GetObjectValue(Value);
					object obj20 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj19, (object)num20), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[k])["JDT_JDT_WT"]);
					double num21 = DC_Main.Fnv(ref Value);
					dataRow["JDT_JDT_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj21 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj20, (object)num21), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[k])["JDT_GHT_WT"]);
					double num22 = DC_Main.Fnv(ref Value);
					dataRow["JDT_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj22 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj21, (object)num22), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[k])["JDT_KUN_WT"]);
					double num23 = DC_Main.Fnv(ref Value);
					dataRow["JDT_KUN_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj23 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj22, (object)num23), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[k])["JDT_WAX_WT"]);
					double num24 = DC_Main.Fnv(ref Value);
					dataRow["JDT_WAX_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj24 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj23, (object)num24), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[k])["KR_WAX_WT"]);
					double num25 = DC_Main.Fnv(ref Value);
					dataRow["KR_WAX_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj25 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj24, (object)num25), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[k])["JDT_KUN_TOUCH"]);
					double num26 = DC_Main.Fnv(ref Value);
					dataRow["JDT_KUN_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj26 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj25, (object)num26), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[k])["JDT_KUN_NET"]);
					double num27 = DC_Main.Fnv(ref Value);
					dataRow["JDT_KUN_NET"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj26, (object)num27), (object)",'"), rsDetl2.Rows[k]["EMP_ISU"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsDetl2 = null;
				int l = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM BAR_IDTL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp2.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO,ISR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsIdtl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsIdtl2;
				for (rsIdtl2 = RsIdtl; l < rsIdtl2.Rows.Count; l++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,  DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,  IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER)   VALUES ('", rsIdtl2.Rows[l]["CO_CODE"]), (object)"','"), rsIdtl2.Rows[l]["LC_CODE"]), (object)"','"), rsIdtl2.Rows[l]["CO_YEAR"]), (object)"','"), rsIdtl2.Rows[l]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',"), rsIdtl2.Rows[l]["SR_NO"]), (object)","), rsIdtl2.Rows[l]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsIdtl2.Rows[l]["VCH_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), rsIdtl2.Rows[l]["VCH_TYPE"]), (object)"','"), rsIdtl2.Rows[l]["INOUT_TYPE"]), (object)"', '"), rsIdtl2.Rows[l]["ENTRY_TYPE"]), (object)"','"), rsIdtl2.Rows[l]["BOOK_NAME"]), (object)"','"), rsIdtl2.Rows[l]["AC_CODE"]), (object)"','"), rsIdtl2.Rows[l]["TAG_NO"]), (object)"',"), rsIdtl2.Rows[l]["VCH_SRNO"]), (object)",'"), rsIdtl2.Rows[l]["IT_CODE"]), (object)"','"), rsIdtl2.Rows[l]["IT_TYPE"]), (object)"', "), (object)" '"), rsIdtl2.Rows[l]["DM_CODE"]), (object)"','"), rsIdtl2.Rows[l]["DM_SIZE"]), (object)"','"), rsIdtl2.Rows[l]["DM_SFNO"]), (object)"','"), rsIdtl2.Rows[l]["DM_LEB"]), (object)"','"), rsIdtl2.Rows[l]["IT_PCS"]), (object)"',"), rsIdtl2.Rows[l]["IT_PCS_WT"]), (object)","), rsIdtl2.Rows[l]["KR_WT"]), (object)","), rsIdtl2.Rows[l]["KR_LESS_PRC"]), (object)","), rsIdtl2.Rows[l]["IT_GWT"]), (object)","), rsIdtl2.Rows[l]["IT_CON_PRC"]), (object)", "), (object)" "), rsIdtl2.Rows[l]["IT_CON_WT"]), (object)",'"), rsIdtl2.Rows[l]["IT_RATE_TYPE"]), (object)"',"), rsIdtl2.Rows[l]["IT_RATE"]), (object)","), rsIdtl2.Rows[l]["IT_AMT"]), (object)","), rsIdtl2.Rows[l]["IT_LBR_RATE"]), (object)","), rsIdtl2.Rows[l]["IT_LBR_AMT"]), (object)","), rsIdtl2.Rows[l]["IT_NET_AMT"]), (object)","), rsIdtl2.Rows[l]["KR_CON_PRC"]), (object)", "), (object)" "), rsIdtl2.Rows[l]["KR_CON_WT"]), (object)","), rsIdtl2.Rows[l]["KR_RATE"]), (object)","), rsIdtl2.Rows[l]["KR_AMT"]), (object)","), rsIdtl2.Rows[l]["KR_LBR_RATE"]), (object)","), rsIdtl2.Rows[l]["KR_LBR_AMT"]), (object)","), rsIdtl2.Rows[l]["KR_NET_AMT"]), (object)",'"), rsIdtl2.Rows[l]["MAIN_USER"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsIdtl2 = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DATA SET DATA_TRFR = 'Y',HD_VCH_NO = '" + BVchNo + "',RE_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp2.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp2 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			TempbookVchInsert();
		}
	}

	private void TempbookVchInsert()
	{
		DC_Main.RsQry = "SELECT TOP 1 A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.VCH_NO,B.BOOK_NAME FROM BAR_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.MAIN_BOOK ='OPSTK' ORDER BY A.VCH_NO DESC";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"' "));
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			else
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TEMP_BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,BOOK_NAME) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"','"), DC_Main.Rshlp.Rows[0]["BOOK_NAME"]), (object)"')"));
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			else
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
		}
		DC_Main.RsQry = "SELECT TOP 1 A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.VCH_NO,B.BOOK_NAME FROM BAR_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.MAIN_BOOK ='TAG GEN' ORDER BY A.VCH_NO DESC";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"' "));
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			else
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TEMP_BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,BOOK_NAME) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"','"), DC_Main.Rshlp.Rows[0]["BOOK_NAME"]), (object)"')"));
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			else
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
		}
	}

	private void Ab_BookMast()
	{
		DC_Main.RsQry = "SELECT * FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Book Master";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"'")));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,CUR_USE,BOOK_INOUT,MAIN_BOOK,ITM_TYPE,  BOOK_TYPE,BOOK_VCH_TYPE,MAIN_USER,BOOK_SR_NAME,RESET_BOOK,DATA_TYPE)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_SNAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["CUR_USE"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_INOUT"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["ITM_TYPE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["BOOK_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_VCH_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_SR_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["RESET_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["DATA_TYPE"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int i = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM BOOK_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsDetl;
				for (rsDetl = RsDetl; i < rsDetl.Rows.Count; i++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BOOK_DETL(CO_CODE,LC_CODE,CO_BOOK,SR_NO,BOOK_NAME,BOOK_SNAME,BOOK_TYPE,ITM_TYPE,BOOK_INOUT,AC_CODE,  AC_NAME,MAIN_BOOK,RESET_BOOK,DATA_TYPE)   VALUES ('", rsDetl.Rows[i]["CO_CODE"]), (object)"','"), rsDetl.Rows[i]["LC_CODE"]), (object)"','"), rsDetl.Rows[i]["CO_BOOK"]), (object)"',"), rsDetl.Rows[i]["SR_NO"]), (object)",'"), rsDetl.Rows[i]["BOOK_NAME"]), (object)"','"), rsDetl.Rows[i]["BOOK_SNAME"]), (object)"','"), rsDetl.Rows[i]["BOOK_TYPE"]), (object)"','"), rsDetl.Rows[i]["ITM_TYPE"]), (object)"','"), rsDetl.Rows[i]["BOOK_INOUT"]), (object)"','"), rsDetl.Rows[i]["AC_CODE"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["AC_NAME"]), (object)"','"), rsDetl.Rows[i]["MAIN_BOOK"]), (object)"','"), rsDetl.Rows[i]["RESET_BOOK"]), (object)"','"), rsDetl.Rows[i]["DATA_TYPE"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsDetl = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BOOK_DATA SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ab_Karigar()
	{
		DC_Main.RsQry = "SELECT A.* FROM KR_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Karigar";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				int num = Strings.Len(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_NO"]));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["RE_TRFR"], (object)""), (object)"Y", false))
				{
					BVchNo = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["HD_VCH_NO"], (object)""));
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,MAX(VCH_NO) As LAST_VCH_SR,RIGHT('00000' + CAST(ISNULL(CAST(MAX(VCH_NO) AS INT), 0) + 1 AS VARCHAR(10)), " + Conversions.ToString(num) + ") AS NEXT_VCH_NO  From KR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' Group By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK Order By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						RsBVchNo = OpenRecordsetTrfr(DC_Main.RsQry);
					}
					else
					{
						RsBVchNo = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					if (RsBVchNo.Rows.Count > 0)
					{
						BVchNo = Conversions.ToString(RsBVchNo.Rows[0]["NEXT_VCH_NO"]);
					}
					else
					{
						BVchNo = "00001";
					}
				}
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
				}
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO KR_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CODE,  AC_NAME,NET_AMT,DISC_PRC,DISC_AMT,TAX_CODE,TAX_PRC,TAX_AMT,ROF_AMT,TOT_AMT,CASH_AMT,CARD_AMT,CHQ_AMT,KASAR_AMT,  BILL_OS,OS_ADJ_AMT,CR_DAYS,CARD_AC,BANK_AC,CHQ_NO,BANK_NAME,EMP_CODE,VCH_DESC,DATA_TRFR,ENTRY_TIME,ADD1,ADD2,  ADD3,CITY,MOBILE,AC_GST_TYPE,IGST_TAX,CGST_TAX,SGST_TAX,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,LBR_AMT,OTH_AMT,  SL_BILL_NO,SL_BILL_LC,SL_BILL_YRCD,SL_BILL_DBCD,PARTY_FINE,IT_TYPE,TCS_CODE,TCS_PRC,TCS_AMT)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["BILL_NO"]), (object)"','"), (object)BVchNo), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"',"), rshlp.Rows[DC_Main.M]["NET_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["DISC_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["DISC_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["TAX_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TAX_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TAX_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["ROF_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["TOT_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CASH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CARD_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CHQ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["KASAR_AMT"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["BILL_OS"]), (object)","), rshlp.Rows[DC_Main.M]["OS_ADJ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CR_DAYS"]), (object)",'"), rshlp.Rows[DC_Main.M]["CARD_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["CHQ_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_DESC"]), (object)"','"), rshlp.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), rshlp.Rows[DC_Main.M]["ENTRY_TIME"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD1"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD2"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["ADD3"]), (object)"','"), rshlp.Rows[DC_Main.M]["CITY"]), (object)"','"), rshlp.Rows[DC_Main.M]["MOBILE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_GST_TYPE"]), (object)"',"), rshlp.Rows[DC_Main.M]["IGST_TAX"]), (object)","), rshlp.Rows[DC_Main.M]["CGST_TAX"]), (object)","), rshlp.Rows[DC_Main.M]["SGST_TAX"]), (object)",'"), rshlp.Rows[DC_Main.M]["OLD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["NEW_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"',"), rshlp.Rows[DC_Main.M]["LBR_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["OTH_AMT"]), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["SL_BILL_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["SL_BILL_LC"]), (object)"','"), rshlp.Rows[DC_Main.M]["SL_BILL_YRCD"]), (object)"','"), rshlp.Rows[DC_Main.M]["SL_BILL_DBCD"]), (object)"',");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["PARTY_FINE"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["PARTY_FINE"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num2), (object)",'"), rshlp.Rows[DC_Main.M]["IT_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["TCS_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TCS_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TCS_AMT"]), (object)")"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int i = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM KR_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsDetl;
				for (rsDetl = RsDetl; i < rsDetl.Rows.Count; i++)
				{
					object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO KR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,VCH_TYPE,  INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,  ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,  OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,RATE_TYPE,IT_TYPE,WITH_STOCK,HD_VCH_NO,  OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,ADD_USER,ITM_OTH_RATE,ITM_OTH_FINE,SL_BILL_NO,SL_BILL_LC,SL_BILL_YRCD,  SL_BILL_DBCD,CONV_RATE,CONV_PRC,ITM_LESS_TCH,IT_DESC,ITM_LOSS_WT,VCH_SRNO)   VALUES ('", rsDetl.Rows[i]["CO_CODE"]), (object)"','"), rsDetl.Rows[i]["LC_CODE"]), (object)"','"), rsDetl.Rows[i]["CO_YEAR"]), (object)"','"), rsDetl.Rows[i]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',"), rsDetl.Rows[i]["SR_NO"]), (object)","), rsDetl.Rows[i]["OLD_SRNO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rsDetl.Rows[i]["VCH_TYPE"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["INOUT_TYPE"]), (object)"','"), rsDetl.Rows[i]["ENTRY_TYPE"]), (object)"','"), rsDetl.Rows[i]["BOOK_NAME"]), (object)"','"), rsDetl.Rows[i]["AC_CODE"]), (object)"','"), rsDetl.Rows[i]["IT_CODE"]), (object)"','"), rsDetl.Rows[i]["TAG_NO"]), (object)"','"), rsDetl.Rows[i]["LOT_NO"]), (object)"','"), rsDetl.Rows[i]["DESIGN_NO"]), (object)"','"), rsDetl.Rows[i]["TBL_CODE"]), (object)"','"), rsDetl.Rows[i]["ITM_SIZE"]), (object)"',"), rsDetl.Rows[i]["ITM_PCS"]), (object)","), rsDetl.Rows[i]["BAG_WT"]), (object)", "), (object)" "), rsDetl.Rows[i]["ITM_GWT"]), (object)","), rsDetl.Rows[i]["ITM_OTH_WT"]), (object)","), rsDetl.Rows[i]["ITM_NWT"]), (object)","), rsDetl.Rows[i]["ITM_GHT_WT"]), (object)","), rsDetl.Rows[i]["ITM_TOUCH"]), (object)","), rsDetl.Rows[i]["ITM_WEST_PRC"]), (object)","), rsDetl.Rows[i]["ITM_FINE"]), (object)","), rsDetl.Rows[i]["LBR_PRC"]), (object)","), rsDetl.Rows[i]["LBR_RATE"]), (object)",'"), rsDetl.Rows[i]["LBR_TYPE"]), (object)"',"), rsDetl.Rows[i]["LBR_AMT"]), (object)", "), (object)" "), rsDetl.Rows[i]["OTH_AMT"]), (object)","), rsDetl.Rows[i]["ITM_RATE"]), (object)","), rsDetl.Rows[i]["ITM_AMT"]), (object)","), rsDetl.Rows[i]["TAG_COST"]), (object)","), rsDetl.Rows[i]["ITM_MRP"]), (object)","), rsDetl.Rows[i]["TOT_AMT"]), (object)","), rsDetl.Rows[i]["TAX_PRC"]), (object)","), rsDetl.Rows[i]["NET_AMT"]), (object)",'"), rsDetl.Rows[i]["RATE_TYPE"]), (object)"','"), rsDetl.Rows[i]["IT_TYPE"]), (object)"','"), rsDetl.Rows[i]["WITH_STOCK"]), (object)"','"), rsDetl.Rows[i]["HD_VCH_NO"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["OLD_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["NEW_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["MAIN_USER"]), (object)"','"), rsDetl.Rows[i]["ADD_USER"]), (object)"','"), rsDetl.Rows[i]["ITM_OTH_RATE"]), (object)"','"), rsDetl.Rows[i]["ITM_OTH_FINE"]), (object)"','"), rsDetl.Rows[i]["SL_BILL_NO"]), (object)"','"), rsDetl.Rows[i]["SL_BILL_LC"]), (object)"','"), rsDetl.Rows[i]["SL_BILL_YRCD"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["SL_BILL_DBCD"]), (object)"',"), rsDetl.Rows[i]["CONV_RATE"]), (object)","), rsDetl.Rows[i]["CONV_PRC"]), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["ITM_LESS_TCH"]);
					double num3 = DC_Main.Fnv(ref Value);
					dataRow["ITM_LESS_TCH"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num3), (object)",'"), rsDetl.Rows[i]["IT_DESC"]), (object)"',"), rsDetl.Rows[i]["ITM_LOSS_WT"]), (object)","), (object)Conversion.Val(Operators.ConcatenateObject(rsDetl.Rows[i]["VCH_SRNO"], (object)""))), (object)")"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsDetl = null;
				int j = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM KR_IDTL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO,ISR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsIdtl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsIdtl;
				for (rsIdtl = RsIdtl; j < rsIdtl.Rows.Count; j++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO KR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,  KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,  KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,  MAIN_USER)   VALUES ('", rsIdtl.Rows[j]["CO_CODE"]), (object)"','"), rsIdtl.Rows[j]["LC_CODE"]), (object)"','"), rsIdtl.Rows[j]["CO_YEAR"]), (object)"','"), rsIdtl.Rows[j]["CO_BOOK"]), (object)"','"), rsIdtl.Rows[j]["HD_VCH_NO"]), (object)"',"), rsIdtl.Rows[j]["SR_NO"]), (object)","), rsIdtl.Rows[j]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsIdtl.Rows[j]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsIdtl.Rows[j]["VCH_TYPE"]), (object)"','"), rsIdtl.Rows[j]["INOUT_TYPE"]), (object)"', "), (object)" '"), rsIdtl.Rows[j]["ENTRY_TYPE"]), (object)"','"), rsIdtl.Rows[j]["BOOK_NAME"]), (object)"','"), rsIdtl.Rows[j]["AC_CODE"]), (object)"','"), rsIdtl.Rows[j]["TAG_NO"]), (object)"',"), rsIdtl.Rows[j]["VCH_SRNO"]), (object)",'"), rsIdtl.Rows[j]["IT_CODE"]), (object)"','"), rsIdtl.Rows[j]["IT_TYPE"]), (object)"','"), rsIdtl.Rows[j]["DM_CODE"]), (object)"','"), rsIdtl.Rows[j]["DM_SIZE"]), (object)"','"), rsIdtl.Rows[j]["DM_SFNO"]), (object)"','"), rsIdtl.Rows[j]["DM_LEB"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS"]), (object)"',"), rsIdtl.Rows[j]["IT_PCS_WT"]), (object)", "), (object)" "), rsIdtl.Rows[j]["KR_WT"]), (object)","), rsIdtl.Rows[j]["KR_LESS_PRC"]), (object)","), rsIdtl.Rows[j]["IT_GWT"]), (object)","), rsIdtl.Rows[j]["IT_CON_PRC"]), (object)","), rsIdtl.Rows[j]["IT_CON_WT"]), (object)",'"), rsIdtl.Rows[j]["IT_RATE_TYPE"]), (object)"',"), rsIdtl.Rows[j]["IT_RATE"]), (object)","), rsIdtl.Rows[j]["IT_AMT"]), (object)","), rsIdtl.Rows[j]["IT_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["IT_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["IT_NET_AMT"]), (object)", "), (object)" "), rsIdtl.Rows[j]["KR_CON_PRC"]), (object)","), rsIdtl.Rows[j]["KR_CON_WT"]), (object)","), rsIdtl.Rows[j]["KR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_NET_AMT"]), (object)",'"), rsIdtl.Rows[j]["HD_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["OLD_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["NEW_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["MAIN_USER"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsIdtl = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE KR_DATA SET DATA_TRFR = 'Y',HD_VCH_NO = '" + BVchNo + "',RE_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ab_Purchase()
	{
		DC_Main.RsQry = "SELECT A.* FROM PR_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Purchase";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				int num = Strings.Len(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_NO"]));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["RE_TRFR"], (object)""), (object)"Y", false))
				{
					BVchNo = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["HD_VCH_NO"], (object)""));
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,MAX(VCH_NO) As LAST_VCH_SR,RIGHT('00000' + CAST(ISNULL(CAST(MAX(VCH_NO) AS INT), 0) + 1 AS VARCHAR(10)), " + Conversions.ToString(num) + ") AS NEXT_VCH_NO  From PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' Group By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK Order By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						RsBVchNo = OpenRecordsetTrfr(DC_Main.RsQry);
					}
					else
					{
						RsBVchNo = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					if (RsBVchNo.Rows.Count > 0)
					{
						BVchNo = Conversions.ToString(RsBVchNo.Rows[0]["NEXT_VCH_NO"]);
					}
					else
					{
						BVchNo = "00001";
					}
				}
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO PR_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CODE,  AC_NAME,NET_AMT,DISC_PRC,DISC_AMT,TAX_CODE,TAX_PRC,TAX_AMT,ROF_AMT,TOT_AMT,CASH_AMT,CARD_AMT,CHQ_AMT,KASAR_AMT,  BILL_OS,OS_ADJ_AMT,CR_DAYS,CARD_AC,BANK_AC,CHQ_NO,BANK_NAME,EMP_CODE,VCH_DESC,DATA_TRFR,ENTRY_TIME,ADD1,ADD2,  ADD3,CITY,MOBILE,AC_GST_TYPE,IGST_TAX,CGST_TAX,SGST_TAX,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,LBR_AMT,OTH_AMT,  SL_BILL_NO,SL_BILL_LC,SL_BILL_YRCD,SL_BILL_DBCD,PARTY_FINE,IT_TYPE,TCS_CODE,TCS_PRC,TCS_AMT)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["BILL_NO"]), (object)"','"), (object)BVchNo), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"',"), rshlp.Rows[DC_Main.M]["NET_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["DISC_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["DISC_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["TAX_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TAX_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TAX_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["ROF_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["TOT_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CASH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CARD_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CHQ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["KASAR_AMT"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["BILL_OS"]), (object)","), rshlp.Rows[DC_Main.M]["OS_ADJ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CR_DAYS"]), (object)",'"), rshlp.Rows[DC_Main.M]["CARD_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["CHQ_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_DESC"]), (object)"','"), rshlp.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), rshlp.Rows[DC_Main.M]["ENTRY_TIME"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD1"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD2"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["ADD3"]), (object)"','"), rshlp.Rows[DC_Main.M]["CITY"]), (object)"','"), rshlp.Rows[DC_Main.M]["MOBILE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_GST_TYPE"]), (object)"',"), rshlp.Rows[DC_Main.M]["IGST_TAX"]), (object)","), rshlp.Rows[DC_Main.M]["CGST_TAX"]), (object)","), rshlp.Rows[DC_Main.M]["SGST_TAX"]), (object)",'"), rshlp.Rows[DC_Main.M]["OLD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["NEW_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"',"), rshlp.Rows[DC_Main.M]["LBR_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["OTH_AMT"]), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["SL_BILL_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["SL_BILL_LC"]), (object)"','"), rshlp.Rows[DC_Main.M]["SL_BILL_YRCD"]), (object)"','"), rshlp.Rows[DC_Main.M]["SL_BILL_DBCD"]), (object)"',"), rshlp.Rows[DC_Main.M]["PARTY_FINE"]), (object)",'"), rshlp.Rows[DC_Main.M]["IT_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["TCS_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TCS_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TCS_AMT"]), (object)")"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int i = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM PR_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsDetl;
				for (rsDetl = RsDetl; i < rsDetl.Rows.Count; i++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO PR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,VCH_TYPE,  INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,  ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,  OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,RATE_TYPE,IT_TYPE,WITH_STOCK,HD_VCH_NO,  OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,ADD_USER,ITM_OTH_RATE,ITM_OTH_FINE,SL_BILL_NO,SL_BILL_LC,SL_BILL_YRCD,  SL_BILL_DBCD,CONV_RATE,CONV_PRC,ITM_LESS_TCH,IT_DESC,ITM_LOSS_WT)   VALUES ('", rsDetl.Rows[i]["CO_CODE"]), (object)"','"), rsDetl.Rows[i]["LC_CODE"]), (object)"','"), rsDetl.Rows[i]["CO_YEAR"]), (object)"','"), rsDetl.Rows[i]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',"), rsDetl.Rows[i]["SR_NO"]), (object)","), rsDetl.Rows[i]["OLD_SRNO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rsDetl.Rows[i]["VCH_TYPE"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["INOUT_TYPE"]), (object)"','"), rsDetl.Rows[i]["ENTRY_TYPE"]), (object)"','"), rsDetl.Rows[i]["BOOK_NAME"]), (object)"','"), rsDetl.Rows[i]["AC_CODE"]), (object)"','"), rsDetl.Rows[i]["IT_CODE"]), (object)"','"), rsDetl.Rows[i]["TAG_NO"]), (object)"','"), rsDetl.Rows[i]["LOT_NO"]), (object)"','"), rsDetl.Rows[i]["DESIGN_NO"]), (object)"','"), rsDetl.Rows[i]["TBL_CODE"]), (object)"','"), rsDetl.Rows[i]["ITM_SIZE"]), (object)"',"), rsDetl.Rows[i]["ITM_PCS"]), (object)","), rsDetl.Rows[i]["BAG_WT"]), (object)", "), (object)" "), rsDetl.Rows[i]["ITM_GWT"]), (object)","), rsDetl.Rows[i]["ITM_OTH_WT"]), (object)","), rsDetl.Rows[i]["ITM_NWT"]), (object)","), rsDetl.Rows[i]["ITM_GHT_WT"]), (object)","), rsDetl.Rows[i]["ITM_TOUCH"]), (object)","), rsDetl.Rows[i]["ITM_WEST_PRC"]), (object)","), rsDetl.Rows[i]["ITM_FINE"]), (object)","), rsDetl.Rows[i]["LBR_PRC"]), (object)","), rsDetl.Rows[i]["LBR_RATE"]), (object)",'"), rsDetl.Rows[i]["LBR_TYPE"]), (object)"',"), rsDetl.Rows[i]["LBR_AMT"]), (object)", "), (object)" "), rsDetl.Rows[i]["OTH_AMT"]), (object)","), rsDetl.Rows[i]["ITM_RATE"]), (object)","), rsDetl.Rows[i]["ITM_AMT"]), (object)","), rsDetl.Rows[i]["TAG_COST"]), (object)","), rsDetl.Rows[i]["ITM_MRP"]), (object)","), rsDetl.Rows[i]["TOT_AMT"]), (object)","), rsDetl.Rows[i]["TAX_PRC"]), (object)","), rsDetl.Rows[i]["NET_AMT"]), (object)",'"), rsDetl.Rows[i]["RATE_TYPE"]), (object)"','"), rsDetl.Rows[i]["IT_TYPE"]), (object)"','"), rsDetl.Rows[i]["WITH_STOCK"]), (object)"','"), rsDetl.Rows[i]["HD_VCH_NO"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["OLD_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["NEW_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["MAIN_USER"]), (object)"','"), rsDetl.Rows[i]["ADD_USER"]), (object)"','"), rsDetl.Rows[i]["ITM_OTH_RATE"]), (object)"','"), rsDetl.Rows[i]["ITM_OTH_FINE"]), (object)"','"), rsDetl.Rows[i]["SL_BILL_NO"]), (object)"','"), rsDetl.Rows[i]["SL_BILL_LC"]), (object)"','"), rsDetl.Rows[i]["SL_BILL_YRCD"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["SL_BILL_DBCD"]), (object)"',"), rsDetl.Rows[i]["CONV_RATE"]), (object)","), rsDetl.Rows[i]["CONV_PRC"]), (object)","), rsDetl.Rows[i]["ITM_LESS_TCH"]), (object)",'"), rsDetl.Rows[i]["IT_DESC"]), (object)"',"), rsDetl.Rows[i]["ITM_LOSS_WT"]), (object)")"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsDetl = null;
				int j = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM PR_IDTL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO,ISR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsIdtl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsIdtl;
				for (rsIdtl = RsIdtl; j < rsIdtl.Rows.Count; j++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO PR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,  KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,  KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,  MAIN_USER)   VALUES ('", rsIdtl.Rows[j]["CO_CODE"]), (object)"','"), rsIdtl.Rows[j]["LC_CODE"]), (object)"','"), rsIdtl.Rows[j]["CO_YEAR"]), (object)"','"), rsIdtl.Rows[j]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',"), rsIdtl.Rows[j]["SR_NO"]), (object)","), rsIdtl.Rows[j]["ISR_NO"]), (object)",'"), rsIdtl.Rows[j]["VCH_DATE"]), (object)"','"), rsIdtl.Rows[j]["VCH_TYPE"]), (object)"','"), rsIdtl.Rows[j]["INOUT_TYPE"]), (object)"', "), (object)" '"), rsIdtl.Rows[j]["ENTRY_TYPE"]), (object)"','"), rsIdtl.Rows[j]["BOOK_NAME"]), (object)"','"), rsIdtl.Rows[j]["AC_CODE"]), (object)"','"), rsIdtl.Rows[j]["TAG_NO"]), (object)"',"), rsIdtl.Rows[j]["VCH_SRNO"]), (object)",'"), rsIdtl.Rows[j]["IT_CODE"]), (object)"','"), rsIdtl.Rows[j]["IT_TYPE"]), (object)"','"), rsIdtl.Rows[j]["DM_CODE"]), (object)"','"), rsIdtl.Rows[j]["DM_SIZE"]), (object)"','"), rsIdtl.Rows[j]["DM_SFNO"]), (object)"','"), rsIdtl.Rows[j]["DM_LEB"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS"]), (object)"',"), rsIdtl.Rows[j]["IT_PCS_WT"]), (object)", "), (object)" "), rsIdtl.Rows[j]["KR_WT"]), (object)","), rsIdtl.Rows[j]["KR_LESS_PRC"]), (object)","), rsIdtl.Rows[j]["IT_GWT"]), (object)","), rsIdtl.Rows[j]["IT_CON_PRC"]), (object)","), rsIdtl.Rows[j]["IT_CON_WT"]), (object)",'"), rsIdtl.Rows[j]["IT_RATE_TYPE"]), (object)"',"), rsIdtl.Rows[j]["IT_RATE"]), (object)","), rsIdtl.Rows[j]["IT_AMT"]), (object)","), rsIdtl.Rows[j]["IT_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["IT_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["IT_NET_AMT"]), (object)", "), (object)" "), rsIdtl.Rows[j]["KR_CON_PRC"]), (object)","), rsIdtl.Rows[j]["KR_CON_WT"]), (object)","), rsIdtl.Rows[j]["KR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_NET_AMT"]), (object)",'"), rsIdtl.Rows[j]["HD_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["OLD_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["NEW_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["MAIN_USER"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsIdtl = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE PR_DATA SET DATA_TRFR = 'Y',HD_VCH_NO = '" + BVchNo + "',RE_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ab_Wh_Sale()
	{
		DC_Main.RsQry = "SELECT A.*,B.BOOK_NAME As BookName FROM RATE_CUT_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Wh Sales";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				int num = Strings.Len(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_NO"]));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["RE_TRFR"], (object)""), (object)"Y", false))
				{
					BVchNo = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["HD_VCH_NO"], (object)""));
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,MAX(VCH_NO) As LAST_VCH_SR,RIGHT('00000' + CAST(ISNULL(CAST(MAX(VCH_NO) AS INT), 0) + 1 AS VARCHAR(10)), " + Conversions.ToString(num) + ") AS NEXT_VCH_NO  From RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' Group By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK Order By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						RsBVchNo = OpenRecordsetTrfr(DC_Main.RsQry);
					}
					else
					{
						RsBVchNo = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					if (RsBVchNo.Rows.Count > 0)
					{
						BVchNo = Conversions.ToString(RsBVchNo.Rows[0]["NEXT_VCH_NO"]);
					}
					else
					{
						BVchNo = "00001";
					}
				}
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"'")));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO RATE_CUT_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,IT_TYPE,  AC_CODE,AC_NAME,DR_AMT,CR_FINE,CR_AMT,DR_FINE,RATE_PAR,FINE_RATE,SL_FINE,PR_FINE,TOT_FINE_DR,TOT_FINE_CR,KSR_FINE_CR,  KSR_FINE_DR,SL_NET_AMT,SL_ITM_AMT,SL_LBR_AMT,SL_OTH_AMT,SL_ADV_AMT,SL_CASH_AMT,SL_CARD_AMT,SL_CHQ_AMT,SL_KASAR_AMT,  SL_BILL_OS,PR_NET_AMT,PR_ITM_AMT,PR_LBR_AMT,PR_OTH_AMT,PR_ADV_AMT,PR_CASH_AMT,PR_CARD_AMT,PR_CHQ_AMT,PR_KASAR_AMT,  PR_BILL_OS,CR_DAYS,CARD_AC,BANK_AC,CHQ_NO,BANK_NAME,EMP_CODE,VCH_DESC,ENTRY_TIME,ADD1,ADD2,ADD3,CITY,MOBILE,  DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,CONV_RATE,CONV_PRC,SILVER_FINE_DR,SILVER_FINE_CR)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["BILL_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["IT_TYPE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"',"), rshlp.Rows[DC_Main.M]["DR_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CR_FINE"]), (object)","), rshlp.Rows[DC_Main.M]["CR_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["DR_FINE"]), (object)",'"), rshlp.Rows[DC_Main.M]["RATE_PAR"]), (object)"',"), rshlp.Rows[DC_Main.M]["FINE_RATE"]), (object)","), rshlp.Rows[DC_Main.M]["SL_FINE"]), (object)","), rshlp.Rows[DC_Main.M]["PR_FINE"]), (object)","), rshlp.Rows[DC_Main.M]["TOT_FINE_DR"]), (object)","), rshlp.Rows[DC_Main.M]["TOT_FINE_CR"]), (object)","), rshlp.Rows[DC_Main.M]["KSR_FINE_CR"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["KSR_FINE_DR"]), (object)","), rshlp.Rows[DC_Main.M]["SL_NET_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["SL_ITM_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["SL_LBR_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["SL_OTH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["SL_ADV_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["SL_CASH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["SL_CARD_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["SL_CHQ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["SL_KASAR_AMT"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["SL_BILL_OS"]), (object)","), rshlp.Rows[DC_Main.M]["PR_NET_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["PR_ITM_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["PR_LBR_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["PR_OTH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["PR_ADV_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["PR_CASH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["PR_CARD_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["PR_CHQ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["PR_KASAR_AMT"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["PR_BILL_OS"]), (object)","), rshlp.Rows[DC_Main.M]["CR_DAYS"]), (object)",'"), rshlp.Rows[DC_Main.M]["CARD_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["CHQ_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_DESC"]), (object)"',NULL,'"), rshlp.Rows[DC_Main.M]["ADD1"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD2"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD3"]), (object)"','"), rshlp.Rows[DC_Main.M]["CITY"]), (object)"','"), rshlp.Rows[DC_Main.M]["MOBILE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), rshlp.Rows[DC_Main.M]["OLD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["NEW_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"',"), rshlp.Rows[DC_Main.M]["CONV_RATE"]), (object)","), rshlp.Rows[DC_Main.M]["CONV_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["SILVER_FINE_DR"]), (object)","), rshlp.Rows[DC_Main.M]["SILVER_FINE_CR"]), (object)")"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int i = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM RATE_CUT_ISU AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsDetl;
				for (rsDetl = RsDetl; i < rsDetl.Rows.Count; i++)
				{
					object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO RATE_CUT_ISU(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,  ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,  TOT_AMT,TAX_PRC,NET_AMT,ITM_REMARK,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE,  HD_VCH_NO,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,ADD_USER,LESS_TOUCH,ITM_OTH_RATE,ITM_OTH_FINE,CONV_RATE,CONV_PRC,  SILVER_FINE,ISU_NO,ISU_LC_CODE,ISU_YRCD,ISU_DBCD,ISU_SRNO,LESS_WT,TAG_GWT,TAG_NWT,MCX_RATE,HM_FINE,DESIGN_IMG_ID,ADJ_WT,ITM_LOT)   VALUES ('", rsDetl.Rows[i]["CO_CODE"]), (object)"','"), rsDetl.Rows[i]["LC_CODE"]), (object)"','"), rsDetl.Rows[i]["CO_YEAR"]), (object)"','"), rsDetl.Rows[i]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',"), rsDetl.Rows[i]["SR_NO"]), (object)","), rsDetl.Rows[i]["OLD_SRNO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rsDetl.Rows[i]["VCH_TYPE"]), (object)"','"), rsDetl.Rows[i]["INOUT_TYPE"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["ENTRY_TYPE"]), (object)"','"), rsDetl.Rows[i]["BOOK_NAME"]), (object)"','"), rsDetl.Rows[i]["AC_CODE"]), (object)"','"), rsDetl.Rows[i]["IT_CODE"]), (object)"','"), rsDetl.Rows[i]["TAG_NO"]), (object)"','"), rsDetl.Rows[i]["LOT_NO"]), (object)"','"), rsDetl.Rows[i]["DESIGN_NO"]), (object)"','"), rsDetl.Rows[i]["TBL_CODE"]), (object)"','"), rsDetl.Rows[i]["ITM_SIZE"]), (object)"',"), rsDetl.Rows[i]["ITM_PCS"]), (object)","), rsDetl.Rows[i]["BAG_WT"]), (object)","), rsDetl.Rows[i]["ITM_GWT"]), (object)","), rsDetl.Rows[i]["ITM_OTH_WT"]), (object)","), rsDetl.Rows[i]["ITM_NWT"]), (object)", "), (object)" "), rsDetl.Rows[i]["ITM_GHT_WT"]), (object)","), rsDetl.Rows[i]["ITM_TOUCH"]), (object)","), rsDetl.Rows[i]["ITM_WEST_PRC"]), (object)","), rsDetl.Rows[i]["ITM_FINE"]), (object)","), rsDetl.Rows[i]["LBR_PRC"]), (object)","), rsDetl.Rows[i]["LBR_RATE"]), (object)",'"), rsDetl.Rows[i]["LBR_TYPE"]), (object)"',"), rsDetl.Rows[i]["LBR_AMT"]), (object)","), rsDetl.Rows[i]["OTH_AMT"]), (object)","), rsDetl.Rows[i]["ITM_RATE"]), (object)","), rsDetl.Rows[i]["ITM_AMT"]), (object)","), rsDetl.Rows[i]["TAG_COST"]), (object)","), rsDetl.Rows[i]["ITM_MRP"]), (object)", "), (object)" "), rsDetl.Rows[i]["TOT_AMT"]), (object)","), rsDetl.Rows[i]["TAX_PRC"]), (object)","), rsDetl.Rows[i]["NET_AMT"]), (object)",'"), rsDetl.Rows[i]["ITM_REMARK"]), (object)"',"), rsDetl.Rows[i]["VCH_SRNO"]), (object)","), rsDetl.Rows[i]["KR_NET_WT"]), (object)","), rsDetl.Rows[i]["KR_TOUCH"]), (object)","), rsDetl.Rows[i]["KR_WEST_PRC"]), (object)","), rsDetl.Rows[i]["KR_FINE"]), (object)",'"), rsDetl.Rows[i]["KR_NAME"]), (object)"','"), rsDetl.Rows[i]["RATE_TYPE"]), (object)"','"), rsDetl.Rows[i]["IT_TYPE"]), (object)"','"), rsDetl.Rows[i]["PR_CODE"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["VCH_NO"]), (object)"','"), rsDetl.Rows[i]["DATA_TRFR"]), (object)"','"), rsDetl.Rows[i]["OLD_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["NEW_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["MAIN_USER"]), (object)"','"), rsDetl.Rows[i]["ADD_USER"]), (object)"',"), rsDetl.Rows[i]["LESS_TOUCH"]), (object)","), rsDetl.Rows[i]["ITM_OTH_RATE"]), (object)","), rsDetl.Rows[i]["ITM_OTH_FINE"]), (object)","), rsDetl.Rows[i]["CONV_RATE"]), (object)","), rsDetl.Rows[i]["CONV_PRC"]), (object)", "), (object)" "), rsDetl.Rows[i]["SILVER_FINE"]), (object)",'"), rsDetl.Rows[i]["ISU_NO"]), (object)"','"), rsDetl.Rows[i]["ISU_LC_CODE"]), (object)"','"), rsDetl.Rows[i]["ISU_YRCD"]), (object)"','"), rsDetl.Rows[i]["ISU_DBCD"]), (object)"',"), rsDetl.Rows[i]["ISU_SRNO"]), (object)","), rsDetl.Rows[i]["LESS_WT"]), (object)",");
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["TAG_GWT"]);
					double num2 = DC_Main.Fnv(ref Value);
					dataRow["TAG_GWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num2), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["TAG_NWT"]);
					double num3 = DC_Main.Fnv(ref Value);
					dataRow["TAG_NWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num3), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["MCX_RATE"]);
					double num4 = DC_Main.Fnv(ref Value);
					dataRow["MCX_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num4), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["HM_FINE"]);
					double num5 = DC_Main.Fnv(ref Value);
					dataRow["HM_FINE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num5), (object)",'"), rsDetl.Rows[i]["DESIGN_IMG_ID"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[i])["ADJ_WT"]);
					double num6 = DC_Main.Fnv(ref Value);
					dataRow["ADJ_WT"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num6), (object)",'"), rsDetl.Rows[i]["ITM_LOT"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsDetl = null;
				int j = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_IDTL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsIdtl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsIdtl;
				for (rsIdtl = RsIdtl; j < rsIdtl.Rows.Count; j++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,  KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,  KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,HD_VCH_NO,MAIN_USER)   VALUES ('", rsIdtl.Rows[j]["CO_CODE"]), (object)"','"), rsIdtl.Rows[j]["LC_CODE"]), (object)"','"), rsIdtl.Rows[j]["CO_YEAR"]), (object)"','"), rsIdtl.Rows[j]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',"), rsIdtl.Rows[j]["SR_NO"]), (object)","), rsIdtl.Rows[j]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsIdtl.Rows[j]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsIdtl.Rows[j]["VCH_TYPE"]), (object)"','"), rsIdtl.Rows[j]["INOUT_TYPE"]), (object)"', "), (object)" '"), rsIdtl.Rows[j]["ENTRY_TYPE"]), (object)"','"), rsIdtl.Rows[j]["BOOK_NAME"]), (object)"','"), rsIdtl.Rows[j]["AC_CODE"]), (object)"','"), rsIdtl.Rows[j]["TAG_NO"]), (object)"',"), rsIdtl.Rows[j]["VCH_SRNO"]), (object)",'"), rsIdtl.Rows[j]["IT_CODE"]), (object)"','"), rsIdtl.Rows[j]["IT_TYPE"]), (object)"','"), rsIdtl.Rows[j]["DM_CODE"]), (object)"','"), rsIdtl.Rows[j]["DM_SIZE"]), (object)"','"), rsIdtl.Rows[j]["DM_SFNO"]), (object)"','"), rsIdtl.Rows[j]["DM_LEB"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS_WT"]), (object)"', "), (object)" "), rsIdtl.Rows[j]["KR_WT"]), (object)","), rsIdtl.Rows[j]["KR_LESS_PRC"]), (object)","), rsIdtl.Rows[j]["IT_GWT"]), (object)",'"), rsIdtl.Rows[j]["IT_CON_PRC"]), (object)"',"), rsIdtl.Rows[j]["IT_CON_WT"]), (object)",'"), rsIdtl.Rows[j]["IT_RATE_TYPE"]), (object)"',"), rsIdtl.Rows[j]["IT_RATE"]), (object)","), rsIdtl.Rows[j]["IT_AMT"]), (object)","), rsIdtl.Rows[j]["IT_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["IT_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["IT_NET_AMT"]), (object)", "), (object)" "), rsIdtl.Rows[j]["KR_CON_PRC"]), (object)","), rsIdtl.Rows[j]["KR_CON_WT"]), (object)","), rsIdtl.Rows[j]["KR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_NET_AMT"]), (object)",'"), rsIdtl.Rows[j]["HD_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["MAIN_USER"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsIdtl = null;
				int k = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM RATE_CUT_REC AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				DataTable dataTable = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable2;
				for (dataTable2 = dataTable; k < dataTable2.Rows.Count; k++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO RATE_CUT_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,  ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,  TOT_AMT,TAX_PRC,NET_AMT,RATE_TYPE,IT_TYPE,WITH_STOCK,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,ADD_USER,LESS_TOUCH, ITM_OTH_RATE,ITM_OTH_FINE,ITM_REMARK,CONV_RATE,CONV_PRC,SILVER_FINE,LESS_WT,VCH_SRNO,OLD_VCH_SRNO)   VALUES ('", dataTable2.Rows[k]["CO_CODE"]), (object)"','"), dataTable2.Rows[k]["LC_CODE"]), (object)"','"), dataTable2.Rows[k]["CO_YEAR"]), (object)"','"), dataTable2.Rows[k]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',"), dataTable2.Rows[k]["SR_NO"]), (object)","), dataTable2.Rows[k]["OLD_SRNO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[k]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[k]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), dataTable2.Rows[k]["VCH_TYPE"]), (object)"','"), dataTable2.Rows[k]["INOUT_TYPE"]), (object)"', "), (object)" '"), dataTable2.Rows[k]["ENTRY_TYPE"]), (object)"','"), dataTable2.Rows[k]["BOOK_NAME"]), (object)"','"), dataTable2.Rows[k]["AC_CODE"]), (object)"','"), dataTable2.Rows[k]["IT_CODE"]), (object)"','"), dataTable2.Rows[k]["TAG_NO"]), (object)"','"), dataTable2.Rows[k]["LOT_NO"]), (object)"','"), dataTable2.Rows[k]["DESIGN_NO"]), (object)"','"), dataTable2.Rows[k]["TBL_CODE"]), (object)"','"), dataTable2.Rows[k]["ITM_SIZE"]), (object)"',"), dataTable2.Rows[k]["ITM_PCS"]), (object)","), dataTable2.Rows[k]["BAG_WT"]), (object)","), dataTable2.Rows[k]["ITM_GWT"]), (object)","), dataTable2.Rows[k]["ITM_OTH_WT"]), (object)","), dataTable2.Rows[k]["ITM_NWT"]), (object)", "), (object)" "), dataTable2.Rows[k]["ITM_GHT_WT"]), (object)","), dataTable2.Rows[k]["ITM_TOUCH"]), (object)","), dataTable2.Rows[k]["ITM_WEST_PRC"]), (object)","), dataTable2.Rows[k]["ITM_FINE"]), (object)","), dataTable2.Rows[k]["LBR_PRC"]), (object)","), dataTable2.Rows[k]["LBR_RATE"]), (object)",'"), dataTable2.Rows[k]["LBR_TYPE"]), (object)"',"), dataTable2.Rows[k]["LBR_AMT"]), (object)","), dataTable2.Rows[k]["OTH_AMT"]), (object)","), dataTable2.Rows[k]["ITM_RATE"]), (object)","), dataTable2.Rows[k]["ITM_AMT"]), (object)","), dataTable2.Rows[k]["TAG_COST"]), (object)","), dataTable2.Rows[k]["ITM_MRP"]), (object)", "), (object)" "), dataTable2.Rows[k]["TOT_AMT"]), (object)","), dataTable2.Rows[k]["TAX_PRC"]), (object)","), dataTable2.Rows[k]["NET_AMT"]), (object)",'"), dataTable2.Rows[k]["RATE_TYPE"]), (object)"','"), dataTable2.Rows[k]["IT_TYPE"]), (object)"','"), dataTable2.Rows[k]["WITH_STOCK"]), (object)"','"), dataTable2.Rows[k]["HD_VCH_NO"]), (object)"','"), dataTable2.Rows[k]["OLD_VCH_NO"]), (object)"','"), dataTable2.Rows[k]["NEW_VCH_NO"]), (object)"','"), dataTable2.Rows[k]["MAIN_USER"]), (object)"','"), dataTable2.Rows[k]["ADD_USER"]), (object)"',"), dataTable2.Rows[k]["LESS_TOUCH"]), (object)","), (object)" "), dataTable2.Rows[k]["ITM_OTH_RATE"]), (object)","), dataTable2.Rows[k]["ITM_OTH_FINE"]), (object)",'"), dataTable2.Rows[k]["ITM_REMARK"]), (object)"',"), dataTable2.Rows[k]["CONV_RATE"]), (object)","), dataTable2.Rows[k]["CONV_PRC"]), (object)","), dataTable2.Rows[k]["SILVER_FINE"]), (object)","), dataTable2.Rows[k]["LESS_WT"]), (object)","), dataTable2.Rows[k]["VCH_SRNO"]), (object)","), dataTable2.Rows[k]["OLD_VCH_SRNO"]), (object)")"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable2 = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE RATE_CUT_DATA SET DATA_TRFR = 'Y',HD_VCH_NO = '" + BVchNo + "',RE_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ab_CashBank()
	{
		DC_Main.RsQry = "SELECT * FROM CASH_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N' ORDER BY A.CO_BOOK,A.VCH_NO,A.SR_NO";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Cash Bank";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["SR_NO"])) == 1.0)
				{
					int num = Strings.Len(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_NO"]));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["RE_TRFR"], (object)""), (object)"Y", false))
					{
						BVchNo = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["HD_VCH_NO"], (object)""));
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,MAX(VCH_NO) As LAST_VCH_SR,RIGHT('00000' + CAST(ISNULL(CAST(MAX(VCH_NO) AS INT), 0) + 1 AS VARCHAR(10)), " + Conversions.ToString(num) + ") AS NEXT_VCH_NO  From CASH_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' Group By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK Order By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK"));
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							RsBVchNo = OpenRecordsetTrfr(DC_Main.RsQry);
						}
						else
						{
							RsBVchNo = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						}
						if (RsBVchNo.Rows.Count > 0)
						{
							BVchNo = Conversions.ToString(RsBVchNo.Rows[0]["NEXT_VCH_NO"]);
						}
						else
						{
							BVchNo = "00001";
						}
					}
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM CASH_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)BVchNo), (object)"' AND SR_NO = "), rshlp.Rows[DC_Main.M]["SR_NO"]), (object)" "));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO CASH_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,VCH_TIME,AC_CODE,AC_NAME,CHQ_NO,REC_AMT,KASAR_AMT,IT_DESC,BANK_NAME,EMP_CODE,  DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,HD_VCH_NO,MAIN_USER,ADD_USER,REC_AC_CODE,CHQ_PRINT_NAME,  CLR_DATE,USER_UPDATE,USER_DELETE,BANK_CHARGES,MOB_ENTRY_SAVE)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), (object)BVchNo), (object)"',");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["SR_NO"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["SR_NO"] = RuntimeHelpers.GetObjectValue(Value);
				object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num2), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["INOUT_TYPE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["ENTRY_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_NAME"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["CHQ_NO"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["REC_AMT"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["REC_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num3), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["KASAR_AMT"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num4), (object)",'"), rshlp.Rows[DC_Main.M]["IT_DESC"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), rshlp.Rows[DC_Main.M]["OLD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["NEW_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["REC_AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CHQ_PRINT_NAME"]), (object)"', "), (object)" "), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["CLR_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)Conversions.ToDate(rshlp.Rows[DC_Main.M]["CLR_DATE"]), "MM/dd/yyyy") + "'"))), (object)",'"), rshlp.Rows[DC_Main.M]["USER_UPDATE"]), (object)"','"), rshlp.Rows[DC_Main.M]["USER_DELETE"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_CHARGES"]), (object)"','"), rshlp.Rows[DC_Main.M]["MOB_ENTRY_SAVE"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE CASH_DATA SET DATA_TRFR = 'Y',HD_VCH_NO = '" + BVchNo + "',RE_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = "), rshlp.Rows[DC_Main.M]["SR_NO"]), (object)""));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ab_Sales()
	{
		DC_Main.RsQry = "SELECT A.*,B.BOOK_TYPE As BookType FROM SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Sales";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				string text;
				if (Operators.ConditionalCompareObjectEqual(rshlp.Rows[DC_Main.M]["BookType"], (object)"T", false))
				{
					text = Conversions.ToString(rshlp.Rows[DC_Main.M]["VCH_NO"]);
				}
				else
				{
					int num = Strings.Len(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_NO"]));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["RE_TRFR"], (object)""), (object)"Y", false))
					{
						BVchNo = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["HD_VCH_NO"], (object)""));
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,MAX(VCH_NO) As LAST_VCH_SR,RIGHT('00000' + CAST(ISNULL(CAST(MAX(VCH_NO) AS INT), 0) + 1 AS VARCHAR(10)), " + Conversions.ToString(num) + ") AS NEXT_VCH_NO  From SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' Group By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK Order By CO_CODE, LC_CODE, CO_YEAR, CO_BOOK"));
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							RsBVchNo = OpenRecordsetTrfr(DC_Main.RsQry);
						}
						else
						{
							RsBVchNo = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						}
						if (RsBVchNo.Rows.Count > 0)
						{
							BVchNo = Conversions.ToString(RsBVchNo.Rows[0]["NEXT_VCH_NO"]);
						}
						else
						{
							BVchNo = "00001";
						}
					}
					text = BVchNo;
				}
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)text), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)text), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)text), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)text), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DETL_RTN WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)text), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)text), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)text), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)text), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)text), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)text), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)text), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DETL_RTN WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)text), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)text), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), (object)text), (object)"'")));
				}
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CODE,AC_NAME,  NET_AMT,DISC_PRC,DISC_AMT,TAX_CODE,TAX_PRC,TAX_AMT,ROF_AMT,TOT_AMT,ADV_AMT,OLD_GL_AMT,OLD_SL_AMT,CASH_AMT,CARD_AMT,  CHQ_AMT,SCHM_AMT,CASH_PAID,KASAR_AMT,BILL_OS,OS_ADJ_AMT,CR_DAYS,CARD_AC,BANK_AC,CHQ_NO,BANK_NAME,EMP_CODE,VCH_DESC,  ENTRY_TIME,OLD_GL,OLD_SL,ADD1,ADD2,ADD3,CITY,MOBILE,AC_GST_TYPE,IGST_TAX,CGST_TAX,SGST_TAX,DATA_TRFR,OLD_VCH_NO,  NEW_VCH_NO,MAIN_USER,SCHM_AC,CARD_ADJ,ISU_NO,ISU_LC_CODE,ISU_YRCD,ISU_DBCD,RTN_NET_AMT,RTN_TOT_AMT,RTN_CHQ_AMT,  RTN_CARD_AMT,RTN_CASH_AMT,RTN_KASAR_AMT,RTN_BILL_OS,TCS_CODE,TCS_PRC,TCS_AMT,  HM_AMT,HM_TAX_PRC,HM_TAX_AMT,HM_TAX_CODE,TDS_CODE,TDS_PRC,TDS_AMT,CARD_COM_AMT,  USER_UPDATE,USER_DELETE,POINT_VAL,IRN_NO,ACK_NO,ACK_DATE,ORNA_ISU,MOB_ENTRY_SAVE,UPI_AMT,  LBR_AMT,OTH_AMT,CRNT_ADJ_AMT,PARTY_FINE,IT_TYPE,OZ_RATE,OZ_CONV,FX_RATE,FX_CODE,MTL_RATE,  TOT_TAX_FREE_AMT,ZERO_RATED_AMT)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), (object)text), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["BILL_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"', "), (object)" "), rshlp.Rows[DC_Main.M]["NET_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["DISC_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["DISC_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["TAX_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TAX_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TAX_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["ROF_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["TOT_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["ADV_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["OLD_GL_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["OLD_SL_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CASH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CARD_AMT"]), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["CHQ_AMT"]), (object)"','"), rshlp.Rows[DC_Main.M]["SCHM_AMT"]), (object)"','"), rshlp.Rows[DC_Main.M]["CASH_PAID"]), (object)"','"), rshlp.Rows[DC_Main.M]["KASAR_AMT"]), (object)"','"), rshlp.Rows[DC_Main.M]["BILL_OS"]), (object)"','"), rshlp.Rows[DC_Main.M]["OS_ADJ_AMT"]), (object)"','"), rshlp.Rows[DC_Main.M]["CR_DAYS"]), (object)"','"), rshlp.Rows[DC_Main.M]["CARD_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["CHQ_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_DESC"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["ENTRY_TIME"]), (object)"',"), rshlp.Rows[DC_Main.M]["OLD_GL"]), (object)","), rshlp.Rows[DC_Main.M]["OLD_SL"]), (object)",'"), rshlp.Rows[DC_Main.M]["ADD1"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD2"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD3"]), (object)"','"), rshlp.Rows[DC_Main.M]["CITY"]), (object)"','"), rshlp.Rows[DC_Main.M]["MOBILE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_GST_TYPE"]), (object)"',"), rshlp.Rows[DC_Main.M]["IGST_TAX"]), (object)","), rshlp.Rows[DC_Main.M]["CGST_TAX"]), (object)","), rshlp.Rows[DC_Main.M]["SGST_TAX"]), (object)",'"), rshlp.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), rshlp.Rows[DC_Main.M]["OLD_VCH_NO"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["NEW_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["SCHM_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["CARD_ADJ"]), (object)"','"), rshlp.Rows[DC_Main.M]["ISU_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["ISU_LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["ISU_YRCD"]), (object)"','"), rshlp.Rows[DC_Main.M]["ISU_DBCD"]), (object)"',"), rshlp.Rows[DC_Main.M]["RTN_NET_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["RTN_TOT_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["RTN_CHQ_AMT"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["RTN_CARD_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["RTN_CASH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["RTN_KASAR_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["RTN_BILL_OS"]), (object)",'"), rshlp.Rows[DC_Main.M]["TCS_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TCS_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TCS_AMT"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["HM_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["HM_TAX_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["HM_TAX_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["HM_TAX_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["TDS_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TDS_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TDS_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CARD_COM_AMT"]), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["USER_UPDATE"]), (object)"','"), rshlp.Rows[DC_Main.M]["USER_DELETE"]), (object)"',");
				object Value = Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["POINT_VAL"], (object)"");
				object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)DC_Main.Fnv(ref Value)), (object)",'"), rshlp.Rows[DC_Main.M]["IRN_NO"]), (object)""), (object)"','"), rshlp.Rows[DC_Main.M]["ACK_NO"]), (object)"',NULL,'"), rshlp.Rows[DC_Main.M]["ORNA_ISU"]), (object)"','"), rshlp.Rows[DC_Main.M]["MOB_ENTRY_SAVE"]), (object)"',");
				DataRow dataRow;
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["UPI_AMT"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["UPI_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["LBR_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["OTH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CRNT_ADJ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["PARTY_FINE"]), (object)",'"), rshlp.Rows[DC_Main.M]["IT_TYPE"]), (object)"',"), rshlp.Rows[DC_Main.M]["OZ_RATE"]), (object)","), rshlp.Rows[DC_Main.M]["OZ_CONV"]), (object)","), rshlp.Rows[DC_Main.M]["FX_RATE"]), (object)",'"), rshlp.Rows[DC_Main.M]["FX_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["MTL_RATE"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["TOT_TAX_FREE_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["ZERO_RATED_AMT"]), (object)")"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int i = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsDetl;
				for (rsDetl = RsDetl; i < rsDetl.Rows.Count; i++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,  ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,  TAG_COST,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,ITM_REMARK,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_NAME,  RATE_TYPE,IT_TYPE,PR_CODE,HD_VCH_NO,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,ADD_USER,ISU_NO,ISU_LC_CODE,ISU_YRCD,  ISU_DBCD,ISU_SRNO,ITM_GHT_PRC,GHT_AMT,HM_ID,HM_ID2,HM_ID3,HM_ID4,  HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,HM_AMT,IT_TAX_AMT,IT_DISC_AMT,TAG_GWT,TAG_NWT,  FINE_RATE,DISC_PRC,DISC_AMT,TAX_CODE,TAXABL_RATE,ITM_IGST_AMT,ITM_CGST_AMT,ITM_SGST_AMT,  GRAND_TOTAL,ITM_COLOR,EMP_CODE,ORD_TAG_STK_ADD,DESIGN_IMG_ID,RATE_WITH,ITM_LOT,  MCX_RATE,PRM_AMT,PRM_DISC,ITM_STYLE,TAX_TYPE,TAX_FREE_AMT,TAX_RVRS)   VALUES ('", rsDetl.Rows[i]["CO_CODE"]), (object)"','"), rsDetl.Rows[i]["LC_CODE"]), (object)"','"), rsDetl.Rows[i]["CO_YEAR"]), (object)"','"), rsDetl.Rows[i]["CO_BOOK"]), (object)"','"), (object)text), (object)"',"), rsDetl.Rows[i]["SR_NO"]), (object)","), rsDetl.Rows[i]["OLD_SRNO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rsDetl.Rows[i]["VCH_TYPE"]), (object)"','"), rsDetl.Rows[i]["INOUT_TYPE"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["ENTRY_TYPE"]), (object)"','"), rsDetl.Rows[i]["BOOK_NAME"]), (object)"','"), rsDetl.Rows[i]["AC_CODE"]), (object)"','"), rsDetl.Rows[i]["IT_CODE"]), (object)"','"), rsDetl.Rows[i]["TAG_NO"]), (object)"','"), rsDetl.Rows[i]["LOT_NO"]), (object)"','"), rsDetl.Rows[i]["DESIGN_NO"]), (object)"','"), rsDetl.Rows[i]["TBL_CODE"]), (object)"','"), rsDetl.Rows[i]["ITM_SIZE"]), (object)"',"), rsDetl.Rows[i]["ITM_PCS"]), (object)","), rsDetl.Rows[i]["BAG_WT"]), (object)","), rsDetl.Rows[i]["ITM_GWT"]), (object)","), rsDetl.Rows[i]["ITM_OTH_WT"]), (object)", "), (object)" "), rsDetl.Rows[i]["ITM_NWT"]), (object)","), rsDetl.Rows[i]["ITM_GHT_WT"]), (object)","), rsDetl.Rows[i]["ITM_TOUCH"]), (object)","), rsDetl.Rows[i]["ITM_WEST_PRC"]), (object)","), rsDetl.Rows[i]["ITM_FINE"]), (object)","), rsDetl.Rows[i]["LBR_PRC"]), (object)","), rsDetl.Rows[i]["LBR_RATE"]), (object)",'"), rsDetl.Rows[i]["LBR_TYPE"]), (object)"',"), rsDetl.Rows[i]["LBR_AMT"]), (object)","), rsDetl.Rows[i]["OTH_AMT"]), (object)","), rsDetl.Rows[i]["ITM_RATE"]), (object)","), rsDetl.Rows[i]["ITM_AMT"]), (object)", "), (object)" "), rsDetl.Rows[i]["TAG_COST"]), (object)","), rsDetl.Rows[i]["ITM_MRP"]), (object)","), rsDetl.Rows[i]["TOT_AMT"]), (object)","), rsDetl.Rows[i]["TAX_PRC"]), (object)","), rsDetl.Rows[i]["NET_AMT"]), (object)",'"), rsDetl.Rows[i]["ITM_REMARK"]), (object)"',"), rsDetl.Rows[i]["VCH_SRNO"]), (object)","), rsDetl.Rows[i]["KR_NET_WT"]), (object)","), rsDetl.Rows[i]["KR_TOUCH"]), (object)","), rsDetl.Rows[i]["KR_WEST_PRC"]), (object)","), rsDetl.Rows[i]["KR_FINE"]), (object)",'"), rsDetl.Rows[i]["KR_NAME"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["RATE_TYPE"]), (object)"','"), rsDetl.Rows[i]["IT_TYPE"]), (object)"','"), rsDetl.Rows[i]["PR_CODE"]), (object)"','"), rsDetl.Rows[i]["HD_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["DATA_TRFR"]), (object)"','"), rsDetl.Rows[i]["OLD_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["NEW_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["MAIN_USER"]), (object)"','"), rsDetl.Rows[i]["ADD_USER"]), (object)"','"), rsDetl.Rows[i]["ISU_NO"]), (object)"','"), rsDetl.Rows[i]["ISU_LC_CODE"]), (object)"','"), rsDetl.Rows[i]["ISU_YRCD"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["ISU_DBCD"]), (object)"',"), rsDetl.Rows[i]["ISU_SRNO"]), (object)","), rsDetl.Rows[i]["ITM_GHT_PRC"]), (object)","), rsDetl.Rows[i]["GHT_AMT"]), (object)",'"), rsDetl.Rows[i]["HM_ID"]), (object)"','"), rsDetl.Rows[i]["HM_ID2"]), (object)"','"), rsDetl.Rows[i]["HM_ID3"]), (object)"','"), rsDetl.Rows[i]["HM_ID4"]), (object)"',"), (object)" "), rsDetl.Rows[i]["HM_ID_WT"]), (object)","), rsDetl.Rows[i]["HM_ID2_WT"]), (object)","), rsDetl.Rows[i]["HM_ID3_WT"]), (object)","), rsDetl.Rows[i]["HM_ID4_WT"]), (object)","), rsDetl.Rows[i]["HM_AMT"]), (object)","), rsDetl.Rows[i]["IT_TAX_AMT"]), (object)","), rsDetl.Rows[i]["IT_DISC_AMT"]), (object)","), rsDetl.Rows[i]["TAG_GWT"]), (object)","), rsDetl.Rows[i]["TAG_NWT"]), (object)", "), (object)" "), rsDetl.Rows[i]["FINE_RATE"]), (object)","), rsDetl.Rows[i]["DISC_PRC"]), (object)","), rsDetl.Rows[i]["DISC_AMT"]), (object)",'"), rsDetl.Rows[i]["TAX_CODE"]), (object)"',"), rsDetl.Rows[i]["TAXABL_RATE"]), (object)","), rsDetl.Rows[i]["ITM_IGST_AMT"]), (object)","), rsDetl.Rows[i]["ITM_CGST_AMT"]), (object)","), rsDetl.Rows[i]["ITM_SGST_AMT"]), (object)", "), (object)" "), rsDetl.Rows[i]["GRAND_TOTAL"]), (object)",'"), rsDetl.Rows[i]["ITM_COLOR"]), (object)"','"), rsDetl.Rows[i]["EMP_CODE"]), (object)"','"), rsDetl.Rows[i]["ORD_TAG_STK_ADD"]), (object)"','"), rsDetl.Rows[i]["DESIGN_IMG_ID"]), (object)"','"), rsDetl.Rows[i]["RATE_WITH"]), (object)"','"), rsDetl.Rows[i]["ITM_LOT"]), (object)"', "), (object)" "), rsDetl.Rows[i]["MCX_RATE"]), (object)","), rsDetl.Rows[i]["PRM_AMT"]), (object)","), rsDetl.Rows[i]["PRM_DISC"]), (object)",'"), rsDetl.Rows[i]["ITM_STYLE"]), (object)"','"), rsDetl.Rows[i]["TAX_TYPE"]), (object)"',"), rsDetl.Rows[i]["TAX_FREE_AMT"]), (object)",'"), rsDetl.Rows[i]["TAX_RVRS"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsDetl = null;
				int j = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_IDTL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsIdtl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsIdtl;
				for (rsIdtl = RsIdtl; j < rsIdtl.Rows.Count; j++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,  KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,  KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,HD_VCH_NO,MAIN_USER)   VALUES ('", rsIdtl.Rows[j]["CO_CODE"]), (object)"','"), rsIdtl.Rows[j]["LC_CODE"]), (object)"','"), rsIdtl.Rows[j]["CO_YEAR"]), (object)"','"), rsIdtl.Rows[j]["CO_BOOK"]), (object)"','"), (object)text), (object)"',"), rsIdtl.Rows[j]["SR_NO"]), (object)","), rsIdtl.Rows[j]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsIdtl.Rows[j]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsIdtl.Rows[j]["VCH_TYPE"]), (object)"','"), rsIdtl.Rows[j]["INOUT_TYPE"]), (object)"', "), (object)" '"), rsIdtl.Rows[j]["ENTRY_TYPE"]), (object)"','"), rsIdtl.Rows[j]["BOOK_NAME"]), (object)"','"), rsIdtl.Rows[j]["AC_CODE"]), (object)"','"), rsIdtl.Rows[j]["TAG_NO"]), (object)"','"), rsIdtl.Rows[j]["VCH_SRNO"]), (object)"','"), rsIdtl.Rows[j]["IT_CODE"]), (object)"','"), rsIdtl.Rows[j]["IT_TYPE"]), (object)"','"), rsIdtl.Rows[j]["DM_CODE"]), (object)"','"), rsIdtl.Rows[j]["DM_SIZE"]), (object)"','"), rsIdtl.Rows[j]["DM_SFNO"]), (object)"','"), rsIdtl.Rows[j]["DM_LEB"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS_WT"]), (object)"', "), (object)" "), rsIdtl.Rows[j]["KR_WT"]), (object)","), rsIdtl.Rows[j]["KR_LESS_PRC"]), (object)","), rsIdtl.Rows[j]["IT_GWT"]), (object)",'"), rsIdtl.Rows[j]["IT_CON_PRC"]), (object)"',"), rsIdtl.Rows[j]["IT_CON_WT"]), (object)",'"), rsIdtl.Rows[j]["IT_RATE_TYPE"]), (object)"',"), rsIdtl.Rows[j]["IT_RATE"]), (object)","), rsIdtl.Rows[j]["IT_AMT"]), (object)","), rsIdtl.Rows[j]["IT_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["IT_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["IT_NET_AMT"]), (object)", "), (object)" "), rsIdtl.Rows[j]["KR_CON_PRC"]), (object)","), rsIdtl.Rows[j]["KR_CON_WT"]), (object)","), rsIdtl.Rows[j]["KR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_NET_AMT"]), (object)",'"), rsIdtl.Rows[j]["HD_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["MAIN_USER"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsIdtl = null;
				int k = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_ORD_ADJ AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				DataTable dataTable = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable2 = dataTable;
				for (; k < dataTable.Rows.Count; k++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_ORD_ADJ(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,  VCH_TIME,BOOK_NAME,AC_CODE,AC_NAME,ORD_HD_VCH_NO,ORD_NO,ORD_LC,ORD_YRCD,ORD_DBCD,ORD_AC_CODE,ORD_SIGN,ORD_AMT,  ORD_GOLD,ORD_SILVER,PAID_AMT,OLD_VCH_NO,NEW_VCH_NO,DATA_TRFR,HD_VCH_NO,MAIN_USER,ADD_USER,KASAR_AMT,ORD_BAL_AMT,  IT_DESC,EMP_CODE,PAID_AC)   VALUES ('", dataTable2.Rows[k]["CO_CODE"]), (object)"','"), dataTable2.Rows[k]["LC_CODE"]), (object)"','"), dataTable2.Rows[k]["CO_YEAR"]), (object)"','"), dataTable2.Rows[k]["CO_BOOK"]), (object)"','"), (object)text), (object)"',"), dataTable2.Rows[k]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[k]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), dataTable2.Rows[k]["VCH_TYPE"]), (object)"','"), dataTable2.Rows[k]["INOUT_TYPE"]), (object)"','"), dataTable2.Rows[k]["ENTRY_TYPE"]), (object)"', "), (object)" '"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[k]["VCH_TIME"]), "MM/dd/yyyy HH: mm : ss")), (object)"','"), dataTable2.Rows[k]["BOOK_NAME"]), (object)"','"), dataTable2.Rows[k]["AC_CODE"]), (object)"','"), dataTable2.Rows[k]["AC_NAME"]), (object)"','"), dataTable2.Rows[k]["ORD_HD_VCH_NO"]), (object)"','"), dataTable2.Rows[k]["ORD_NO"]), (object)"','"), dataTable2.Rows[k]["ORD_LC"]), (object)"','"), dataTable2.Rows[k]["ORD_YRCD"]), (object)"','"), dataTable2.Rows[k]["ORD_DBCD"]), (object)"','"), dataTable2.Rows[k]["ORD_AC_CODE"]), (object)"','"), dataTable2.Rows[k]["ORD_SIGN"]), (object)"',"), dataTable2.Rows[k]["ORD_AMT"]), (object)", "), (object)" "), dataTable2.Rows[k]["ORD_GOLD"]), (object)","), dataTable2.Rows[k]["ORD_SILVER"]), (object)","), dataTable2.Rows[k]["PAID_AMT"]), (object)",'"), dataTable2.Rows[k]["OLD_VCH_NO"]), (object)"','"), dataTable2.Rows[k]["NEW_VCH_NO"]), (object)"','"), dataTable2.Rows[k]["DATA_TRFR"]), (object)"','"), dataTable2.Rows[k]["HD_VCH_NO"]), (object)"','"), dataTable2.Rows[k]["MAIN_USER"]), (object)"','"), dataTable2.Rows[k]["ADD_USER"]), (object)"',"), dataTable2.Rows[k]["KASAR_AMT"]), (object)","), dataTable2.Rows[k]["ORD_BAL_AMT"]), (object)", "), (object)" '"), dataTable2.Rows[k]["IT_DESC"]), (object)"','"), dataTable2.Rows[k]["EMP_CODE"]), (object)"','"), dataTable2.Rows[k]["PAID_AC"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable2 = null;
				int l = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_DETL_RTN AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				DataTable dataTable3 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable4;
				for (dataTable4 = dataTable3; l < dataTable4.Rows.Count; l++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_DETL_RTN(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,VCH_TIME,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,TBL_CODE,DESIGN_NO,ITM_SIZE,ITM_PCS,ITM_GWT,ITM_OTH_WT,  ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,ITM_RATE,ITM_AMT,LBR_TYPE,LBR_PRC,LBR_RATE,LBR_AMT,OTH_AMT,  TAG_LBR_PRC,TAG_LBR_RATE,TAG_LBR_AMT,TAG_OTH_AMT,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,RATE_TYPE,IT_TYPE,HD_VCH_NO,  MAIN_USER,DATA_TRFR,KR_NAME,TAG_COST,ITM_MARGIN,VCH_SRNO,TAG_TYPE,PR_CODE,TAG_SRNO)   VALUES ('", dataTable4.Rows[l]["CO_CODE"]), (object)"','"), dataTable4.Rows[l]["LC_CODE"]), (object)"','"), dataTable4.Rows[l]["CO_YEAR"]), (object)"','"), dataTable4.Rows[l]["CO_BOOK"]), (object)"','"), (object)text), (object)"',"), dataTable4.Rows[l]["SR_NO"]), (object)","), dataTable4.Rows[l]["OLD_SRNO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable4.Rows[l]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), dataTable4.Rows[l]["VCH_TYPE"]), (object)"','"), dataTable4.Rows[l]["INOUT_TYPE"]), (object)"', "), (object)" '"), dataTable4.Rows[l]["ENTRY_TYPE"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable4.Rows[l]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), dataTable4.Rows[l]["BOOK_NAME"]), (object)"','"), dataTable4.Rows[l]["AC_CODE"]), (object)"','"), dataTable4.Rows[l]["IT_CODE"]), (object)"','"), dataTable4.Rows[l]["TAG_NO"]), (object)"','"), dataTable4.Rows[l]["TBL_CODE"]), (object)"','"), dataTable4.Rows[l]["DESIGN_NO"]), (object)"','"), dataTable4.Rows[l]["ITM_SIZE"]), (object)"','"), dataTable4.Rows[l]["ITM_PCS"]), (object)"','"), dataTable4.Rows[l]["ITM_GWT"]), (object)"','"), dataTable4.Rows[l]["ITM_OTH_WT"]), (object)"', "), (object)" "), dataTable4.Rows[l]["ITM_NWT"]), (object)","), dataTable4.Rows[l]["ITM_GHT_WT"]), (object)","), dataTable4.Rows[l]["ITM_TOUCH"]), (object)","), dataTable4.Rows[l]["ITM_WEST_PRC"]), (object)","), dataTable4.Rows[l]["ITM_FINE"]), (object)","), dataTable4.Rows[l]["ITM_RATE"]), (object)","), dataTable4.Rows[l]["ITM_AMT"]), (object)",'"), dataTable4.Rows[l]["LBR_TYPE"]), (object)"',"), dataTable4.Rows[l]["LBR_PRC"]), (object)","), dataTable4.Rows[l]["LBR_RATE"]), (object)","), dataTable4.Rows[l]["LBR_AMT"]), (object)","), dataTable4.Rows[l]["OTH_AMT"]), (object)", "), (object)" "), dataTable4.Rows[l]["TAG_LBR_PRC"]), (object)","), dataTable4.Rows[l]["TAG_LBR_RATE"]), (object)","), dataTable4.Rows[l]["TAG_LBR_AMT"]), (object)","), dataTable4.Rows[l]["TAG_OTH_AMT"]), (object)","), dataTable4.Rows[l]["ITM_MRP"]), (object)","), dataTable4.Rows[l]["TOT_AMT"]), (object)","), dataTable4.Rows[l]["TAX_PRC"]), (object)","), dataTable4.Rows[l]["NET_AMT"]), (object)",'"), dataTable4.Rows[l]["RATE_TYPE"]), (object)"','"), dataTable4.Rows[l]["IT_TYPE"]), (object)"','"), dataTable4.Rows[l]["HD_VCH_NO"]), (object)"', "), (object)" '"), dataTable4.Rows[l]["MAIN_USER"]), (object)"','"), dataTable4.Rows[l]["DATA_TRFR"]), (object)"','"), dataTable4.Rows[l]["KR_NAME"]), (object)"',"), dataTable4.Rows[l]["TAG_COST"]), (object)","), dataTable4.Rows[l]["ITM_MARGIN"]), (object)","), dataTable4.Rows[l]["VCH_SRNO"]), (object)",'"), dataTable4.Rows[l]["TAG_TYPE"]), (object)"','"), dataTable4.Rows[l]["PR_CODE"]), (object)"',"), dataTable4.Rows[l]["TAG_SRNO"]), (object)")"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable4 = null;
				int m = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_PR_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				DataTable dataTable5 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable6;
				for (dataTable6 = dataTable5; m < dataTable6.Rows.Count; m++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_PR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_FINE,ITM_RATE,NET_AMT,IT_TYPE,HD_VCH_NO,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,  ITM_OTH_WT,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,HM_ID)   VALUES ('", dataTable6.Rows[m]["CO_CODE"]), (object)"','"), dataTable6.Rows[m]["LC_CODE"]), (object)"','"), dataTable6.Rows[m]["CO_YEAR"]), (object)"','"), dataTable6.Rows[m]["CO_BOOK"]), (object)"','"), (object)text), (object)"',"), dataTable6.Rows[m]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable6.Rows[m]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable6.Rows[m]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), dataTable6.Rows[m]["VCH_TYPE"]), (object)"','"), dataTable6.Rows[m]["INOUT_TYPE"]), (object)"','"), dataTable6.Rows[m]["ENTRY_TYPE"]), (object)"','"), dataTable6.Rows[m]["BOOK_NAME"]), (object)"', "), (object)" '"), dataTable6.Rows[m]["AC_CODE"]), (object)"','"), dataTable6.Rows[m]["IT_CODE"]), (object)"','"), dataTable6.Rows[m]["IT_DESC"]), (object)"',"), dataTable6.Rows[m]["ITM_PCS"]), (object)","), dataTable6.Rows[m]["ITM_GWT"]), (object)","), dataTable6.Rows[m]["ITM_NWT"]), (object)","), dataTable6.Rows[m]["ITM_TOUCH"]), (object)","), dataTable6.Rows[m]["ITM_FINE"]), (object)","), dataTable6.Rows[m]["ITM_RATE"]), (object)","), dataTable6.Rows[m]["NET_AMT"]), (object)",'"), dataTable6.Rows[m]["IT_TYPE"]), (object)"','"), dataTable6.Rows[m]["VCH_NO"]), (object)"','Y','"), dataTable6.Rows[m]["OLD_VCH_NO"]), (object)"','"), dataTable6.Rows[m]["NEW_VCH_NO"]), (object)"','"), dataTable6.Rows[m]["MAIN_USER"]), (object)"', "), (object)" "), dataTable6.Rows[m]["ITM_OTH_WT"]), (object)",'"), dataTable6.Rows[m]["HM_ID2"]), (object)"','"), dataTable6.Rows[m]["HM_ID3"]), (object)"','"), dataTable6.Rows[m]["HM_ID4"]), (object)"',"), dataTable6.Rows[m]["HM_ID_WT"]), (object)","), dataTable6.Rows[m]["HM_ID2_WT"]), (object)","), dataTable6.Rows[m]["HM_ID3_WT"]), (object)","), dataTable6.Rows[m]["HM_ID4_WT"]), (object)",'"), dataTable6.Rows[m]["HM_ID"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable6 = null;
				int n = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM UPI_DATA AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO,ISR_NO"));
				DataTable dataTable7 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable8;
				for (dataTable8 = dataTable7; n < dataTable8.Rows.Count; n++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO UPI_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TIME,  AC_CODE,UPI_AC_CODE,UPI_AC_NAME,UPI_AMT,MAIN_USER,UPI_ID)   VALUES ('", dataTable8.Rows[n]["CO_CODE"]), (object)"','"), dataTable8.Rows[n]["LC_CODE"]), (object)"','"), dataTable8.Rows[n]["CO_YEAR"]), (object)"','"), dataTable8.Rows[n]["CO_BOOK"]), (object)"','"), (object)text), (object)"',"), dataTable8.Rows[n]["SR_NO"]), (object)","), dataTable8.Rows[n]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable8.Rows[n]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable8.Rows[n]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"', "), (object)" '"), dataTable8.Rows[n]["AC_CODE"]), (object)"','"), dataTable8.Rows[n]["UPI_AC_CODE"]), (object)"','"), dataTable8.Rows[n]["UPI_AC_NAME"]), (object)"',"), dataTable8.Rows[n]["UPI_AMT"]), (object)",'"), dataTable8.Rows[n]["MAIN_USER"]), (object)"','"), dataTable8.Rows[n]["UPI_ID"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable8 = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DATA SET DATA_TRFR = 'Y',HD_VCH_NO = '" + text + "',RE_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ab_AcMast()
	{
		DC_Main.RsQry = "SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Party Master";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			DateTime dateTime = default(DateTime);
			DateTime dateTime2 = default(DateTime);
			DateTime dateTime3 = default(DateTime);
			DateTime dateTime4 = default(DateTime);
			DateTime dateTime5 = default(DateTime);
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["BR_DATE"])))
				{
					dateTime = Conversions.ToDate(rshlp.Rows[DC_Main.M]["BR_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["L_BR_DATE"])))
				{
					dateTime2 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["L_BR_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["AN_DATE"])))
				{
					dateTime3 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["AN_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["LAST_DATE"])))
				{
					dateTime4 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["LAST_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["LAST_VISIT"])))
				{
					dateTime5 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["LAST_VISIT"]);
				}
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO AC_MAST(CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_PERSON,AC_ADD1,AC_ADD2,  AC_ADD3,AC_COUNTRY,AC_STATE,AC_DISTRICT,AC_CITY,AC_AREA,AC_PIN,AC_PHONE,AC_PHONE2,AC_MOBILE,AC_MOBILE2,AC_EMAIL,  AC_GSTNO,AC_GST_TYPE,AC_PANNO,AC_REF_CODE,AC_KHATA_NO,BR_DATE,L_BR_DATE,AN_DATE,AC_CR_DAYS,AC_INT_PRC,DPC_PRC,  BANK_NAME,BANK_AREA,BANK_AC_NO,BANK_RTGS_NO,BANK_DETL,AC_TYPE,LAST_DATE,DATA_TRFR,MAIN_USER,LAST_VISIT,VISIT_TRAN,  APP_TRFR,AC_REF_NAME)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_SHORT"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_MAIN_GR"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_GR"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_PERSON"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_ADD1"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_ADD2"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["AC_ADD3"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_COUNTRY"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_STATE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_DISTRICT"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CITY"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_AREA"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_PIN"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_PHONE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_PHONE2"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_MOBILE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_MOBILE2"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_EMAIL"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["AC_GSTNO"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_GST_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_PANNO"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_REF_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_KHATA_NO"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["BR_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["L_BR_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime2, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["AN_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime3, "MM/dd/yyyy") + "'"))), (object)",");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["AC_CR_DAYS"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["AC_CR_DAYS"] = RuntimeHelpers.GetObjectValue(Value);
				object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["AC_INT_PRC"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["AC_INT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["DPC_PRC"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["DPC_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num3), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AREA"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AC_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_RTGS_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_DETL"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_TYPE"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["LAST_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime4, "MM/dd/yyyy") + "'"))), (object)",'Y','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["LAST_VISIT"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime5, "MM/dd/yyyy") + "'"))), (object)" ,'"), rshlp.Rows[DC_Main.M]["VISIT_TRAN"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["APP_TRFR"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_REF_NAME"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AC_MAST SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ab_Item()
	{
		DC_Main.RsQry = "SELECT * FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Product Master";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '"), rshlp.Rows[DC_Main.M]["PR_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO PRODUCT_MAST(CO_CODE,PR_CODE,PR_NAME,MAIN_USER,DATA_TRFR)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["PR_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["PR_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','Y')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE PRODUCT_MAST SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '"), rshlp.Rows[DC_Main.M]["PR_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT * FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N'";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Group Master";
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp2 = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE = '"), rshlp2.Rows[DC_Main.M]["GR_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO GROUP_MAST(CO_CODE,GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,  GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_USER,TAX_PRC,AVG_TOUCH,AVG_FINE,AVG_NWT,DAY_OP_PCS,DAY_OP_WT,  DAY_CL_PCS,DAY_CL_WT,RATE_DISPLAY)   VALUES ('", rshlp2.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["GR_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["GR_NAME"]), (object)"','"), rshlp2.Rows[DC_Main.M]["GR_TYPE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["TRAD_TYPE"]), (object)"',"), rshlp2.Rows[DC_Main.M]["GR_TOUCH"]), (object)","), rshlp2.Rows[DC_Main.M]["GR_PURC_TOUCH"]), (object)","), rshlp2.Rows[DC_Main.M]["MELTING_PRC"]), (object)", "), (object)" "), rshlp2.Rows[DC_Main.M]["GR_RATE"]), (object)","), rshlp2.Rows[DC_Main.M]["WEST_PRC"]), (object)",'"), rshlp2.Rows[DC_Main.M]["SALE_AC"]), (object)"','"), rshlp2.Rows[DC_Main.M]["PURC_AC"]), (object)"','"), rshlp2.Rows[DC_Main.M]["HSN_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["MAIN_USER"]), (object)"',"), rshlp2.Rows[DC_Main.M]["TAX_PRC"]), (object)","), rshlp2.Rows[DC_Main.M]["AVG_TOUCH"]), (object)","), rshlp2.Rows[DC_Main.M]["AVG_FINE"]), (object)","), rshlp2.Rows[DC_Main.M]["AVG_NWT"]), (object)",0,0, "), (object)" 0,0,'"), rshlp2.Rows[DC_Main.M]["RATE_DISPLAY"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE GROUP_MAST SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE = '"), rshlp2.Rows[DC_Main.M]["GR_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp2 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT * FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N'";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Table Master";
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp3 = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TABLE_CODE = '"), rshlp3.Rows[DC_Main.M]["TABLE_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO TABLE_MAST(CO_CODE,LC_CODE,TABLE_CODE,TABLE_NAME,MAIN_USER)   VALUES ('", rshlp3.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["TABLE_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["TABLE_NAME"]), (object)"','"), rshlp3.Rows[DC_Main.M]["MAIN_USER"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE TABLE_MAST SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TABLE_CODE = '"), rshlp3.Rows[DC_Main.M]["TABLE_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp3 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT * FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N'";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Item Master";
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp4 = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '"), rshlp4.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO ITEM_MAST(CO_CODE,IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,  RATE_TYPE,HSN_CODE,ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,MIN_STK,MAIN_USER,  AVG_TOUCH,AVG_FINE,AVG_NWT,AC_ITEM,STK_DISPLAY,OTH_RATE,AVG_RATE,SAFE_NAME)   VALUES ('", rshlp4.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["IT_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["IT_NAME"]), (object)"','"), rshlp4.Rows[DC_Main.M]["IT_TYPE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["TAG_TYPE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["PR_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["GR_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["TRAD_TYPE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["UNIT_NAME"]), (object)"', "), (object)" '"), rshlp4.Rows[DC_Main.M]["RATE_TYPE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["HSN_CODE"]), (object)"',"), rshlp4.Rows[DC_Main.M]["ITEM_RATE"]), (object)","), rshlp4.Rows[DC_Main.M]["LBR_PRC"]), (object)","), rshlp4.Rows[DC_Main.M]["CON_PRC"]), (object)","), rshlp4.Rows[DC_Main.M]["DISC_PRC"]), (object)","), rshlp4.Rows[DC_Main.M]["IT_TOUCH"]), (object)","), rshlp4.Rows[DC_Main.M]["IT_WEST"]), (object)","), rshlp4.Rows[DC_Main.M]["OTHER_RATE"]), (object)","), rshlp4.Rows[DC_Main.M]["MIN_STK"]), (object)",'"), rshlp4.Rows[DC_Main.M]["MAIN_USER"]), (object)"', "), (object)" "), rshlp4.Rows[DC_Main.M]["AVG_TOUCH"]), (object)","), rshlp4.Rows[DC_Main.M]["AVG_FINE"]), (object)","), rshlp4.Rows[DC_Main.M]["AVG_NWT"]), (object)",'"), rshlp4.Rows[DC_Main.M]["AC_ITEM"]), (object)"','"), rshlp4.Rows[DC_Main.M]["STK_DISPLAY"]), (object)"',"), rshlp4.Rows[DC_Main.M]["OTH_RATE"]), (object)",");
				object Value = Operators.ConcatenateObject(rshlp4.Rows[DC_Main.M]["AVG_RATE"], (object)"");
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)DC_Main.Fnv(ref Value)), (object)",'"), rshlp4.Rows[DC_Main.M]["SAFE_NAME"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '"), rshlp4.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp4 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ac_Scheme()
	{
		DC_Main.ExeQuteDc("UPDATE AD_MAST Set DATA_TRFR = 'N' WHERE DATA_TRFR Is NULL");
		DC_Main.RsQry = "SELECT * FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Scheme Master";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '"), rshlp.Rows[DC_Main.M]["SCHM_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO AD_MAST(CO_CODE,SCHM_CODE,SCHM_NAME,SCHM_AMT,SCHM_AC,SCHM_TYPE,DATA_TRFR,MAIN_USER,BONUS_PRC,SCHM_MONTH,GOLD_RATE)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["SCHM_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["SCHM_NAME"]), (object)"',"), rshlp.Rows[DC_Main.M]["SCHM_AMT"]), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["SCHM_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["SCHM_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"',"), rshlp.Rows[DC_Main.M]["BONUS_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["SCHM_MONTH"]), (object)","), rshlp.Rows[DC_Main.M]["GOLD_RATE"]), (object)")"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AD_MAST SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '"), rshlp.Rows[DC_Main.M]["SCHM_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT * FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N' ORDER BY SCHM_CODE,MEMB_CODE";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Member Master";
			Application.DoEvents();
			DC_Main.M = 0;
			DC_Main.M = 0;
			DateTime dateTime = default(DateTime);
			DateTime dateTime2 = default(DateTime);
			DateTime dateTime3 = default(DateTime);
			DateTime dateTime4 = default(DateTime);
			DateTime dateTime5 = default(DateTime);
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp2 = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '"), rshlp2.Rows[DC_Main.M]["SCHM_CODE"]), (object)"' AND MEMB_CODE = '"), rshlp2.Rows[DC_Main.M]["MEMB_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["BIRTH_DATE"])))
				{
					dateTime = Conversions.ToDate(rshlp2.Rows[DC_Main.M]["BIRTH_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["L_BR_DATE"])))
				{
					dateTime2 = Conversions.ToDate(rshlp2.Rows[DC_Main.M]["L_BR_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["ANV_DATE"])))
				{
					dateTime3 = Conversions.ToDate(rshlp2.Rows[DC_Main.M]["ANV_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["JOIN_DATE"])))
				{
					dateTime4 = Conversions.ToDate(rshlp2.Rows[DC_Main.M]["JOIN_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["EXP_DATE"])))
				{
					dateTime5 = Conversions.ToDate(rshlp2.Rows[DC_Main.M]["EXP_DATE"]);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO AD_MEMB(CO_CODE,LC_CODE,SCHM_CODE,MEMB_CODE,MEMB_NAME,MEMB_AMT,ITM_GWT,EMP_CODE,AC_PHONE,  AC_MOBILE,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,AC_AREA,AC_MOBILE2,AC_PHONE2,ID_PROF,NOMINEE_NAME,AC_EMAIL,  AC_DISTRICT,BIRTH_DATE,ANV_DATE,L_BR_DATE,JOIN_DATE,EXP_DATE,BANK_NAME,BANK_AREA,BANK_AC_NO,BANK_RTGS_NO,  AC_REF_CODE,SCHM_SHORT,MEMB_BONUS,DATA_TRFR,MAIN_USER)   VALUES('", rshlp2.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["SCHM_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["MEMB_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["MEMB_NAME"]), (object)"',"), rshlp2.Rows[DC_Main.M]["MEMB_AMT"]), (object)","), rshlp2.Rows[DC_Main.M]["ITM_GWT"]), (object)",'"), rshlp2.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_PHONE"]), (object)"', "), (object)" '"), rshlp2.Rows[DC_Main.M]["AC_MOBILE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_ADD1"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_ADD2"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_ADD3"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_CITY"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_PIN"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_AREA"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_MOBILE2"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_PHONE2"]), (object)"','"), rshlp2.Rows[DC_Main.M]["ID_PROF"]), (object)"','"), rshlp2.Rows[DC_Main.M]["NOMINEE_NAME"]), (object)"','"), rshlp2.Rows[DC_Main.M]["AC_EMAIL"]), (object)"', "), (object)" '"), rshlp2.Rows[DC_Main.M]["AC_DISTRICT"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["BIRTH_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["L_BR_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime2, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["ANV_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime3, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["JOIN_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime4, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["EXP_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime5, "MM/dd/yyyy") + "'"))), (object)",'"), rshlp2.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp2.Rows[DC_Main.M]["BANK_AREA"]), (object)"','"), rshlp2.Rows[DC_Main.M]["BANK_AC_NO"]), (object)"','"), rshlp2.Rows[DC_Main.M]["BANK_RTGS_NO"]), (object)"', "), (object)" '"), rshlp2.Rows[DC_Main.M]["AC_REF_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["SCHM_SHORT"]), (object)"','"), rshlp2.Rows[DC_Main.M]["MEMB_BONUS"]), (object)"','Y','"), rshlp2.Rows[DC_Main.M]["MAIN_USER"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AD_MEMB SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '"), rshlp2.Rows[DC_Main.M]["SCHM_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp2 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT * FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N' ORDER BY CO_BOOK,VCH_NO,SR_NO";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Ad Data";
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp3 = DC_Main.Rshlp;
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp3.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp3.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = '"), rshlp3.Rows[DC_Main.M]["SR_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp3.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp3.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = '"), rshlp3.Rows[DC_Main.M]["SR_NO"]), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp3.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp3.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = '"), rshlp3.Rows[DC_Main.M]["SR_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp3.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp3.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = '"), rshlp3.Rows[DC_Main.M]["SR_NO"]), (object)"'")));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO AD_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,SCHM_CODE,SCHM_DATE,MEMB_CODE,MEMB_AMT,  TOT_AMT,IT_DESC,MONTH_CODE,EMP_CODE,ENT_TYPE,REC_AC,ITM_GWT,ITM_RATE,BANK_NAME,CHQ_NO,ENTRY_TIME,HD_VCH_NO,MAIN_USER,  DATA_TRFR,VCH_TIME,VCH_TYPE,INOUT_TYPE,BOOK_NAME,WITH_UPI)   VALUES ('", rshlp3.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp3.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp3.Rows[DC_Main.M]["VCH_NO"]), (object)"',"), rshlp3.Rows[DC_Main.M]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp3.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rshlp3.Rows[DC_Main.M]["SCHM_CODE"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp3.Rows[DC_Main.M]["SCHM_DATE"]), "MM/dd/yyyy")), (object)"','"), rshlp3.Rows[DC_Main.M]["MEMB_CODE"]), (object)"',"), rshlp3.Rows[DC_Main.M]["MEMB_AMT"]), (object)", "), (object)" "), rshlp3.Rows[DC_Main.M]["TOT_AMT"]), (object)",'"), rshlp3.Rows[DC_Main.M]["IT_DESC"]), (object)"','"), rshlp3.Rows[DC_Main.M]["MONTH_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["ENT_TYPE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["REC_AC"]), (object)"',"), rshlp3.Rows[DC_Main.M]["ITM_GWT"]), (object)","), rshlp3.Rows[DC_Main.M]["ITM_RATE"]), (object)",'"), rshlp3.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp3.Rows[DC_Main.M]["CHQ_NO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp3.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp3.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), rshlp3.Rows[DC_Main.M]["MAIN_USER"]), (object)"', "), (object)" 'Y','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp3.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp3.Rows[DC_Main.M]["VCH_TYPE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["INOUT_TYPE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["BOOK_NAME"]), (object)"','"), rshlp3.Rows[DC_Main.M]["WITH_UPI"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int i = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM UPI_DATA AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp3.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp3.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp3.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = "), rshlp3.Rows[DC_Main.M]["SR_NO"]), (object)" ORDER BY ISR_NO"));
				DataTable dataTable = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable2;
				for (dataTable2 = dataTable; i < dataTable2.Rows.Count; i++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO UPI_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TIME,  AC_CODE,UPI_AC_CODE,UPI_AC_NAME,UPI_AMT,MAIN_USER,UPI_ID)   VALUES ('", dataTable2.Rows[i]["CO_CODE"]), (object)"','"), dataTable2.Rows[i]["LC_CODE"]), (object)"','"), dataTable2.Rows[i]["CO_YEAR"]), (object)"','"), dataTable2.Rows[i]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"',"), dataTable2.Rows[i]["SR_NO"]), (object)","), dataTable2.Rows[i]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[i]["VCH_DATE"]), "MM/dd/yyyy HH:mm:ss")), (object)"', "), (object)" '"), dataTable2.Rows[i]["AC_CODE"]), (object)"','"), dataTable2.Rows[i]["UPI_AC_CODE"]), (object)"','"), dataTable2.Rows[i]["UPI_AC_NAME"]), (object)"',"), dataTable2.Rows[i]["UPI_AMT"]), (object)",'"), dataTable2.Rows[i]["MAIN_USER"]), (object)"','"), dataTable2.Rows[i]["UPI_ID"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable2 = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AD_DATA SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp3.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp3.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp3.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp3 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT * FROM AD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N' ORDER BY CO_BOOK,VCH_NO,SR_NO";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Ad Data";
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp4 = DC_Main.Rshlp;
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp4.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp4.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = '"), rshlp4.Rows[DC_Main.M]["SR_NO"]), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp4.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp4.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = '"), rshlp4.Rows[DC_Main.M]["SR_NO"]), (object)"'")));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO AD_ADJ(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,SCHM_CODE,MEMB_CODE,MEMB_AMT,MEMB_BONUS,MEMB_LESS,ADJ_AMT,AC_CODE,AC_NAME,SBILL_NO,  SBILL_LC_CODE,SBILL_YRCD,SBILL_DBCD,SBILL_AMT,SBILL_HD_VCH_NO,EMP_CODE,VCH_DESC,SIGN,HD_VCH_NO,MAIN_USER,  DATA_TRFR,USER_UPDATE,USER_DELETE,GOLD_WT,GOLD_RATE,GOLD_AMT)   VALUES('", rshlp4.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp4.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp4.Rows[DC_Main.M]["VCH_NO"]), (object)"',"), rshlp4.Rows[DC_Main.M]["SR_NO"]), (object)",'"), (object)Strings.Format((object)Conversions.ToDate(rshlp4.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp4.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm")), (object)"','"), rshlp4.Rows[DC_Main.M]["VCH_TYPE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["INOUT_TYPE"]), (object)"', "), (object)" '"), rshlp4.Rows[DC_Main.M]["ENTRY_TYPE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["BOOK_NAME"]), (object)"','"), rshlp4.Rows[DC_Main.M]["SCHM_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["MEMB_CODE"]), (object)"',"), rshlp4.Rows[DC_Main.M]["MEMB_AMT"]), (object)","), rshlp4.Rows[DC_Main.M]["MEMB_BONUS"]), (object)","), rshlp4.Rows[DC_Main.M]["MEMB_LESS"]), (object)","), rshlp4.Rows[DC_Main.M]["ADJ_AMT"]), (object)",'"), rshlp4.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["AC_NAME"]), (object)"','"), rshlp4.Rows[DC_Main.M]["SBILL_NO"]), (object)"', "), (object)" '"), rshlp4.Rows[DC_Main.M]["SBILL_LC_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["SBILL_YRCD"]), (object)"','"), rshlp4.Rows[DC_Main.M]["SBILL_DBCD"]), (object)"',"), rshlp4.Rows[DC_Main.M]["SBILL_AMT"]), (object)",'"), rshlp4.Rows[DC_Main.M]["SBILL_HD_VCH_NO"]), (object)"','"), rshlp4.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["VCH_DESC"]), (object)"','"), rshlp4.Rows[DC_Main.M]["SIGN"]), (object)"','"), rshlp4.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"','"), rshlp4.Rows[DC_Main.M]["MAIN_USER"]), (object)"', "), (object)" '"), rshlp4.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), rshlp4.Rows[DC_Main.M]["USER_UPDATE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["USER_DELETE"]), (object)"',"), rshlp4.Rows[DC_Main.M]["GOLD_WT"]), (object)","), rshlp4.Rows[DC_Main.M]["GOLD_RATE"]), (object)","), rshlp4.Rows[DC_Main.M]["GOLD_AMT"]), (object)")"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AD_ADJ SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp4.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp4.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp4.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp4 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ac_OrdData()
	{
		DC_Main.RsQry = "SELECT A.* FROM SL_ORD_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Sales Order";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			DateTime dateTime = default(DateTime);
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["DEL_DATE"])))
				{
					dateTime = Conversions.ToDate(rshlp.Rows[DC_Main.M]["DEL_DATE"]);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_ORD_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CODE,AC_NAME,  NET_AMT,TAX_CODE,TAX_PRC,TAX_AMT,TOT_AMT,ADV_AMT,ORD_ADJ_AMT,OLD_GL_AMT,OLD_SL_AMT,CASH_AMT,CARD_AMT,CHQ_AMT,SCHM_AMT,DEL_DATE,  CARD_AC,BANK_AC,CHQ_NO,BANK_NAME,EMP_CODE,VCH_DESC,ENTRY_TIME,SL_BILL_TYPE,OLD_GL,ADJ_GOLD,OLD_SL,ADJ_SILVER,CARD_ADJ,DATA_TRFR,  OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,ADD1,ADD2,ADD3,CITY,MOBILE,  USER_UPDATE,USER_DELETE,MOB_ENTRY_SAVE,FUN_DATE,RCUT_RATE,RCUT_FINE,RCUT_AMT,UPI_AMT)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["BILL_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"', "), (object)" "), rshlp.Rows[DC_Main.M]["NET_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["TAX_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TAX_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TAX_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["TOT_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["ADV_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["ORD_ADJ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["OLD_GL_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["OLD_SL_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CASH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CARD_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CHQ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["SCHM_AMT"]), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["DEL_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'"))), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["CARD_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["CHQ_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_DESC"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["SL_BILL_TYPE"]), (object)"',"), rshlp.Rows[DC_Main.M]["OLD_GL"]), (object)","), rshlp.Rows[DC_Main.M]["ADJ_GOLD"]), (object)","), rshlp.Rows[DC_Main.M]["OLD_SL"]), (object)","), rshlp.Rows[DC_Main.M]["ADJ_SILVER"]), (object)",'"), rshlp.Rows[DC_Main.M]["CARD_ADJ"]), (object)"','Y', "), (object)" '"), rshlp.Rows[DC_Main.M]["OLD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["NEW_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD1"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD2"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD3"]), (object)"','"), rshlp.Rows[DC_Main.M]["CITY"]), (object)"','"), rshlp.Rows[DC_Main.M]["MOBILE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["USER_UPDATE"]), (object)"','"), rshlp.Rows[DC_Main.M]["USER_DELETE"]), (object)"','"), rshlp.Rows[DC_Main.M]["MOB_ENTRY_SAVE"]), (object)"',null,"), rshlp.Rows[DC_Main.M]["RCUT_RATE"]), (object)","), rshlp.Rows[DC_Main.M]["RCUT_FINE"]), (object)","), rshlp.Rows[DC_Main.M]["RCUT_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["UPI_AMT"]), (object)")"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int i = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_ORD_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsDetl;
				for (rsDetl = RsDetl; i < rsDetl.Rows.Count; i++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_ORD_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,  LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,ITM_REMARK,VCH_SRNO,  KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE,HD_VCH_NO,DATA_TRFR,OLD_VCH_NO,  NEW_VCH_NO,MAIN_USER,ADD_USER,DESIGN_ISU,TAG_GEN,TAG_SALE,ITM_GHT_PRC,HM_ID2,HM_ID3,HM_ID4,  HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,HM_ID)   VALUES ('", rsDetl.Rows[i]["CO_CODE"]), (object)"','"), rsDetl.Rows[i]["LC_CODE"]), (object)"','"), rsDetl.Rows[i]["CO_YEAR"]), (object)"','"), rsDetl.Rows[i]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"',"), rsDetl.Rows[i]["SR_NO"]), (object)","), rsDetl.Rows[i]["OLD_SRNO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"', "), (object)" '"), rsDetl.Rows[i]["VCH_TYPE"]), (object)"','"), rsDetl.Rows[i]["INOUT_TYPE"]), (object)"','"), rsDetl.Rows[i]["ENTRY_TYPE"]), (object)"','"), rsDetl.Rows[i]["BOOK_NAME"]), (object)"','"), rsDetl.Rows[i]["AC_CODE"]), (object)"','"), rsDetl.Rows[i]["IT_CODE"]), (object)"','"), rsDetl.Rows[i]["TAG_NO"]), (object)"','"), rsDetl.Rows[i]["LOT_NO"]), (object)"','"), rsDetl.Rows[i]["DESIGN_NO"]), (object)"','"), rsDetl.Rows[i]["TBL_CODE"]), (object)"','"), rsDetl.Rows[i]["ITM_SIZE"]), (object)"', "), (object)" "), rsDetl.Rows[i]["ITM_PCS"]), (object)","), rsDetl.Rows[i]["BAG_WT"]), (object)","), rsDetl.Rows[i]["ITM_GWT"]), (object)","), rsDetl.Rows[i]["ITM_OTH_WT"]), (object)","), rsDetl.Rows[i]["ITM_NWT"]), (object)","), rsDetl.Rows[i]["ITM_GHT_WT"]), (object)","), rsDetl.Rows[i]["ITM_TOUCH"]), (object)","), rsDetl.Rows[i]["ITM_WEST_PRC"]), (object)","), rsDetl.Rows[i]["ITM_FINE"]), (object)","), rsDetl.Rows[i]["LBR_PRC"]), (object)","), rsDetl.Rows[i]["LBR_RATE"]), (object)", "), (object)" '"), rsDetl.Rows[i]["LBR_TYPE"]), (object)"',"), rsDetl.Rows[i]["LBR_AMT"]), (object)","), rsDetl.Rows[i]["OTH_AMT"]), (object)","), rsDetl.Rows[i]["ITM_RATE"]), (object)","), rsDetl.Rows[i]["ITM_AMT"]), (object)","), rsDetl.Rows[i]["TAG_COST"]), (object)","), rsDetl.Rows[i]["ITM_MRP"]), (object)","), rsDetl.Rows[i]["TOT_AMT"]), (object)","), rsDetl.Rows[i]["TAX_PRC"]), (object)","), rsDetl.Rows[i]["NET_AMT"]), (object)",'"), rsDetl.Rows[i]["ITM_REMARK"]), (object)"','"), rsDetl.Rows[i]["VCH_SRNO"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["KR_NET_WT"]), (object)"','"), rsDetl.Rows[i]["KR_TOUCH"]), (object)"','"), rsDetl.Rows[i]["KR_WEST_PRC"]), (object)"','"), rsDetl.Rows[i]["KR_FINE"]), (object)"','"), rsDetl.Rows[i]["KR_NAME"]), (object)"','"), rsDetl.Rows[i]["RATE_TYPE"]), (object)"','"), rsDetl.Rows[i]["IT_TYPE"]), (object)"','"), rsDetl.Rows[i]["PR_CODE"]), (object)"','"), rsDetl.Rows[i]["VCH_NO"]), (object)"','"), rsDetl.Rows[i]["DATA_TRFR"]), (object)"','"), rsDetl.Rows[i]["OLD_VCH_NO"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["NEW_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["MAIN_USER"]), (object)"','"), rsDetl.Rows[i]["ADD_USER"]), (object)"','"), rsDetl.Rows[i]["DESIGN_ISU"]), (object)"','"), rsDetl.Rows[i]["TAG_GEN"]), (object)"','"), rsDetl.Rows[i]["TAG_SALE"]), (object)"',"), rsDetl.Rows[i]["ITM_GHT_PRC"]), (object)",'"), rsDetl.Rows[i]["HM_ID2"]), (object)"','"), rsDetl.Rows[i]["HM_ID3"]), (object)"','"), rsDetl.Rows[i]["HM_ID4"]), (object)"', "), (object)" "), rsDetl.Rows[i]["HM_ID_WT"]), (object)","), rsDetl.Rows[i]["HM_ID2_WT"]), (object)","), rsDetl.Rows[i]["HM_ID3_WT"]), (object)","), rsDetl.Rows[i]["HM_ID4_WT"]), (object)",'"), rsDetl.Rows[i]["HM_ID"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsDetl = null;
				int j = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_ORD_IDTL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsIdtl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsIdtl;
				for (rsIdtl = RsIdtl; j < rsIdtl.Rows.Count; j++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_ORD_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,  KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,  KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,  MAIN_USER,DM_ORIGIN,DM_REMARK,DM_COLOR,DM_NAME)   VALUES ('", rsIdtl.Rows[j]["CO_CODE"]), (object)"','"), rsIdtl.Rows[j]["LC_CODE"]), (object)"','"), rsIdtl.Rows[j]["CO_YEAR"]), (object)"','"), rsIdtl.Rows[j]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"',"), rsIdtl.Rows[j]["SR_NO"]), (object)","), rsIdtl.Rows[j]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsIdtl.Rows[j]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsIdtl.Rows[j]["VCH_TYPE"]), (object)"','"), rsIdtl.Rows[j]["INOUT_TYPE"]), (object)"', "), (object)" '"), rsIdtl.Rows[j]["ENTRY_TYPE"]), (object)"','"), rsIdtl.Rows[j]["BOOK_NAME"]), (object)"','"), rsIdtl.Rows[j]["AC_CODE"]), (object)"','"), rsIdtl.Rows[j]["TAG_NO"]), (object)"','"), rsIdtl.Rows[j]["VCH_SRNO"]), (object)"','"), rsIdtl.Rows[j]["IT_CODE"]), (object)"','"), rsIdtl.Rows[j]["IT_TYPE"]), (object)"','"), rsIdtl.Rows[j]["DM_CODE"]), (object)"','"), rsIdtl.Rows[j]["DM_SIZE"]), (object)"','"), rsIdtl.Rows[j]["DM_SFNO"]), (object)"','"), rsIdtl.Rows[j]["DM_LEB"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS_WT"]), (object)"', "), (object)" "), rsIdtl.Rows[j]["KR_WT"]), (object)","), rsIdtl.Rows[j]["KR_LESS_PRC"]), (object)","), rsIdtl.Rows[j]["IT_GWT"]), (object)",'"), rsIdtl.Rows[j]["IT_CON_PRC"]), (object)"',"), rsIdtl.Rows[j]["IT_CON_WT"]), (object)",'"), rsIdtl.Rows[j]["IT_RATE_TYPE"]), (object)"',"), rsIdtl.Rows[j]["IT_RATE"]), (object)","), rsIdtl.Rows[j]["IT_AMT"]), (object)","), rsIdtl.Rows[j]["IT_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["IT_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["IT_NET_AMT"]), (object)", "), (object)" "), rsIdtl.Rows[j]["KR_CON_PRC"]), (object)","), rsIdtl.Rows[j]["KR_CON_WT"]), (object)","), rsIdtl.Rows[j]["KR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_NET_AMT"]), (object)",'"), rsIdtl.Rows[j]["VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["OLD_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["NEW_VCH_NO"]), (object)"', "), (object)" '"), rsIdtl.Rows[j]["MAIN_USER"]), (object)"','"), rsIdtl.Rows[j]["DM_ORIGIN"]), (object)"','"), rsIdtl.Rows[j]["DM_REMARK"]), (object)"','"), rsIdtl.Rows[j]["DM_COLOR"]), (object)"','"), rsIdtl.Rows[j]["DM_NAME"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsIdtl = null;
				int k = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_PR_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				DataTable dataTable = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable2;
				for (dataTable2 = dataTable; k < dataTable2.Rows.Count; k++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_PR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_FINE,ITM_RATE,NET_AMT,IT_TYPE,HD_VCH_NO,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,  ITM_OTH_WT,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,HM_ID)   VALUES ('", dataTable2.Rows[k]["CO_CODE"]), (object)"','"), dataTable2.Rows[k]["LC_CODE"]), (object)"','"), dataTable2.Rows[k]["CO_YEAR"]), (object)"','"), dataTable2.Rows[k]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"',"), dataTable2.Rows[k]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[k]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[k]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), dataTable2.Rows[k]["VCH_TYPE"]), (object)"','"), dataTable2.Rows[k]["INOUT_TYPE"]), (object)"','"), dataTable2.Rows[k]["ENTRY_TYPE"]), (object)"','"), dataTable2.Rows[k]["BOOK_NAME"]), (object)"', "), (object)" '"), dataTable2.Rows[k]["AC_CODE"]), (object)"','"), dataTable2.Rows[k]["IT_CODE"]), (object)"','"), dataTable2.Rows[k]["IT_DESC"]), (object)"',"), dataTable2.Rows[k]["ITM_PCS"]), (object)","), dataTable2.Rows[k]["ITM_GWT"]), (object)","), dataTable2.Rows[k]["ITM_NWT"]), (object)","), dataTable2.Rows[k]["ITM_TOUCH"]), (object)","), dataTable2.Rows[k]["ITM_FINE"]), (object)","), dataTable2.Rows[k]["ITM_RATE"]), (object)","), dataTable2.Rows[k]["NET_AMT"]), (object)",'"), dataTable2.Rows[k]["IT_TYPE"]), (object)"','"), dataTable2.Rows[k]["VCH_NO"]), (object)"','Y','"), dataTable2.Rows[k]["OLD_VCH_NO"]), (object)"','"), dataTable2.Rows[k]["NEW_VCH_NO"]), (object)"','"), dataTable2.Rows[k]["MAIN_USER"]), (object)"', "), (object)" "), dataTable2.Rows[k]["ITM_OTH_WT"]), (object)",'"), dataTable2.Rows[k]["HM_ID2"]), (object)"','"), dataTable2.Rows[k]["HM_ID3"]), (object)"','"), dataTable2.Rows[k]["HM_ID4"]), (object)"',"), dataTable2.Rows[k]["HM_ID_WT"]), (object)","), dataTable2.Rows[k]["HM_ID2_WT"]), (object)","), dataTable2.Rows[k]["HM_ID3_WT"]), (object)","), dataTable2.Rows[k]["HM_ID4_WT"]), (object)",'"), dataTable2.Rows[k]["HM_ID"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable2 = null;
				int l = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_ORD_ADJ AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				DataTable dataTable3 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable4;
				for (dataTable4 = dataTable3; l < dataTable4.Rows.Count; l++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_ORD_ADJ(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,  VCH_TIME,BOOK_NAME,AC_CODE,AC_NAME,ORD_HD_VCH_NO,ORD_NO,ORD_LC,ORD_YRCD,ORD_DBCD,ORD_AC_CODE,ORD_SIGN,ORD_AMT,  ORD_GOLD,ORD_SILVER,PAID_AMT,OLD_VCH_NO,NEW_VCH_NO,DATA_TRFR,HD_VCH_NO,MAIN_USER,ADD_USER,KASAR_AMT,ORD_BAL_AMT,  IT_DESC,EMP_CODE,PAID_AC)   VALUES ('", dataTable4.Rows[l]["CO_CODE"]), (object)"','"), dataTable4.Rows[l]["LC_CODE"]), (object)"','"), dataTable4.Rows[l]["CO_YEAR"]), (object)"','"), dataTable4.Rows[l]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"',"), dataTable4.Rows[l]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable4.Rows[l]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), dataTable4.Rows[l]["VCH_TYPE"]), (object)"','"), dataTable4.Rows[l]["INOUT_TYPE"]), (object)"','"), dataTable4.Rows[l]["ENTRY_TYPE"]), (object)"', "), (object)" '"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable4.Rows[l]["VCH_TIME"]), "MM/dd/yyyy HH: mm : ss")), (object)"','"), dataTable4.Rows[l]["BOOK_NAME"]), (object)"','"), dataTable4.Rows[l]["AC_CODE"]), (object)"','"), dataTable4.Rows[l]["AC_NAME"]), (object)"','"), dataTable4.Rows[l]["ORD_NO"]), (object)"','"), dataTable4.Rows[l]["ORD_HD_VCH_NO"]), (object)"','"), dataTable4.Rows[l]["ORD_LC"]), (object)"','"), dataTable4.Rows[l]["ORD_YRCD"]), (object)"','"), dataTable4.Rows[l]["ORD_DBCD"]), (object)"','"), dataTable4.Rows[l]["ORD_AC_CODE"]), (object)"','"), dataTable4.Rows[l]["ORD_SIGN"]), (object)"',"), dataTable4.Rows[l]["ORD_AMT"]), (object)", "), (object)" "), dataTable4.Rows[l]["ORD_GOLD"]), (object)","), dataTable4.Rows[l]["ORD_SILVER"]), (object)","), dataTable4.Rows[l]["PAID_AMT"]), (object)",'"), dataTable4.Rows[l]["OLD_VCH_NO"]), (object)"','"), dataTable4.Rows[l]["NEW_VCH_NO"]), (object)"','"), dataTable4.Rows[l]["DATA_TRFR"]), (object)"','"), dataTable4.Rows[l]["HD_VCH_NO"]), (object)"','"), dataTable4.Rows[l]["MAIN_USER"]), (object)"','"), dataTable4.Rows[l]["ADD_USER"]), (object)"',"), dataTable4.Rows[l]["KASAR_AMT"]), (object)","), dataTable4.Rows[l]["ORD_BAL_AMT"]), (object)", "), (object)" '"), dataTable4.Rows[l]["IT_DESC"]), (object)"','"), dataTable4.Rows[l]["EMP_CODE"]), (object)"','"), dataTable4.Rows[l]["PAID_AC"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable4 = null;
				int m = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM UPI_DATA AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				DataTable dataTable5 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable6;
				for (dataTable6 = dataTable5; m < dataTable6.Rows.Count; m++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO UPI_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TIME,  AC_CODE,UPI_AC_CODE,UPI_AC_NAME,UPI_AMT,MAIN_USER,UPI_ID)   VALUES ('", dataTable6.Rows[m]["CO_CODE"]), (object)"','"), dataTable6.Rows[m]["LC_CODE"]), (object)"','"), dataTable6.Rows[m]["CO_YEAR"]), (object)"','"), dataTable6.Rows[m]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"',"), dataTable6.Rows[m]["SR_NO"]), (object)","), dataTable6.Rows[m]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable6.Rows[m]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable6.Rows[m]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"', "), (object)" '"), dataTable6.Rows[m]["AC_CODE"]), (object)"','"), dataTable6.Rows[m]["UPI_AC_CODE"]), (object)"','"), dataTable6.Rows[m]["UPI_AC_NAME"]), (object)"',"), dataTable6.Rows[m]["UPI_AMT"]), (object)",'"), dataTable6.Rows[m]["MAIN_USER"]), (object)"','"), dataTable6.Rows[m]["UPI_ID"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable6 = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_ORD_DATA SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			int n = 0;
			DC_Main.RsQry = "SELECT A.* FROM SL_ORD_ADJ AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N' AND A.ORD_SIGN = '-' ORDER BY A.CO_BOOK,A.VCH_NO,A.SR_NO";
			DataTable dataTable7 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
			DataTable dataTable8;
			for (dataTable8 = dataTable7; n < dataTable8.Rows.Count; n++)
			{
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable8.Rows[n]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable8.Rows[n]["VCH_NO"]), (object)"' AND SR_NO = "), dataTable8.Rows[n]["SR_NO"]), (object)"")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable8.Rows[n]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable8.Rows[n]["VCH_NO"]), (object)"' AND SR_NO = "), dataTable8.Rows[n]["SR_NO"]), (object)"")));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_ORD_ADJ(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,  VCH_TIME,BOOK_NAME,AC_CODE,AC_NAME,ORD_HD_VCH_NO,ORD_NO,ORD_LC,ORD_YRCD,ORD_DBCD,ORD_AC_CODE,ORD_SIGN,ORD_AMT,  ORD_GOLD,ORD_SILVER,PAID_AMT,OLD_VCH_NO,NEW_VCH_NO,DATA_TRFR,HD_VCH_NO,MAIN_USER,ADD_USER,KASAR_AMT,ORD_BAL_AMT,  IT_DESC,EMP_CODE,PAID_AC)   VALUES ('", dataTable8.Rows[n]["CO_CODE"]), (object)"','"), dataTable8.Rows[n]["LC_CODE"]), (object)"','"), dataTable8.Rows[n]["CO_YEAR"]), (object)"','"), dataTable8.Rows[n]["CO_BOOK"]), (object)"','"), dataTable8.Rows[n]["VCH_NO"]), (object)"',"), dataTable8.Rows[n]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable8.Rows[n]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), dataTable8.Rows[n]["VCH_TYPE"]), (object)"','"), dataTable8.Rows[n]["INOUT_TYPE"]), (object)"','"), dataTable8.Rows[n]["ENTRY_TYPE"]), (object)"', "), (object)" '"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable8.Rows[n]["VCH_TIME"]), "MM/dd/yyyy HH: mm : ss")), (object)"','"), dataTable8.Rows[n]["BOOK_NAME"]), (object)"','"), dataTable8.Rows[n]["AC_CODE"]), (object)"','"), dataTable8.Rows[n]["AC_NAME"]), (object)"','"), dataTable8.Rows[n]["ORD_NO"]), (object)"','"), dataTable8.Rows[n]["ORD_HD_VCH_NO"]), (object)"','"), dataTable8.Rows[n]["ORD_LC"]), (object)"','"), dataTable8.Rows[n]["ORD_YRCD"]), (object)"','"), dataTable8.Rows[n]["ORD_DBCD"]), (object)"','"), dataTable8.Rows[n]["ORD_AC_CODE"]), (object)"','"), dataTable8.Rows[n]["ORD_SIGN"]), (object)"',"), dataTable8.Rows[n]["ORD_AMT"]), (object)", "), (object)" "), dataTable8.Rows[n]["ORD_GOLD"]), (object)","), dataTable8.Rows[n]["ORD_SILVER"]), (object)","), dataTable8.Rows[n]["PAID_AMT"]), (object)",'"), dataTable8.Rows[n]["OLD_VCH_NO"]), (object)"','"), dataTable8.Rows[n]["NEW_VCH_NO"]), (object)"','"), dataTable8.Rows[n]["DATA_TRFR"]), (object)"','"), dataTable8.Rows[n]["HD_VCH_NO"]), (object)"','"), dataTable8.Rows[n]["MAIN_USER"]), (object)"','"), dataTable8.Rows[n]["ADD_USER"]), (object)"',"), dataTable8.Rows[n]["KASAR_AMT"]), (object)","), dataTable8.Rows[n]["ORD_BAL_AMT"]), (object)", "), (object)" '"), dataTable8.Rows[n]["IT_DESC"]), (object)"','"), dataTable8.Rows[n]["EMP_CODE"]), (object)"','"), dataTable8.Rows[n]["PAID_AC"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_ORD_ADJ SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable8.Rows[n]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), dataTable8.Rows[n]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable8.Rows[n]["VCH_NO"]), (object)"' AND SR_NO = "), dataTable8.Rows[n]["SR_NO"]), (object)""));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
			}
			dataTable8 = null;
		}
	}

	private void Ac_Contra()
	{
		DC_Main.RsQry = "SELECT * FROM CONTRA_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N' ORDER BY A.CO_BOOK,A.VCH_NO,A.SR_NO";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Contra";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM CONTRA_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = "), rshlp.Rows[DC_Main.M]["SR_NO"]), (object)" "));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO CONTRA_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE, VCH_TIME,BOOK_NAME,AC_CODE,AC_NAME,LD_CODE,DR_AMT,CR_AMT,CRDR_TYPE,IT_DESC,LDR_TYPE,EMP_CODE,OLD_VCH_NO,NEW_VCH_NO, DATA_TRFR,HD_VCH_NO,MAIN_USER,ADD_USER,CR_FINE,DR_FINE,IT_TYPE)   VALUES('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"',"), rshlp.Rows[DC_Main.M]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["INOUT_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["ENTRY_TYPE"]), (object)"', "), (object)"'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["LD_CODE"]), (object)"','");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["DR_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["DR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num), (object)"','");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["CR_AMT"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["CR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)"','"), rshlp.Rows[DC_Main.M]["CRDR_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["IT_DESC"]), (object)"','"), rshlp.Rows[DC_Main.M]["LDR_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["OLD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["NEW_VCH_NO"]), (object)"', "), (object)"'Y','"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD_USER"]), (object)"','");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["CR_FINE"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["CR_FINE"] = RuntimeHelpers.GetObjectValue(Value);
				object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num3), (object)"','");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["DR_FINE"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["DR_FINE"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num4), (object)"','"), rshlp.Rows[DC_Main.M]["IT_TYPE"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE CONTRA_DATA SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = "), rshlp.Rows[DC_Main.M]["SR_NO"]), (object)""));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ac_BookMast()
	{
		DC_Main.RsQry = "SELECT * FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Party Master";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"'")));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,CUR_USE,BOOK_INOUT,MAIN_BOOK,ITM_TYPE,  BOOK_TYPE,BOOK_VCH_TYPE,MAIN_USER,BOOK_SR_NAME,RESET_BOOK,DATA_TYPE)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_SNAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["CUR_USE"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_INOUT"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["ITM_TYPE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["BOOK_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_VCH_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_SR_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["RESET_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["DATA_TYPE"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int i = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM BOOK_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsDetl;
				for (rsDetl = RsDetl; i < rsDetl.Rows.Count; i++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BOOK_DETL(CO_CODE,LC_CODE,CO_BOOK,SR_NO,BOOK_NAME,BOOK_SNAME,BOOK_TYPE,ITM_TYPE,BOOK_INOUT,AC_CODE,  AC_NAME,MAIN_BOOK,RESET_BOOK,DATA_TYPE)   VALUES ('", rsDetl.Rows[i]["CO_CODE"]), (object)"','"), rsDetl.Rows[i]["LC_CODE"]), (object)"','"), rsDetl.Rows[i]["CO_BOOK"]), (object)"',"), rsDetl.Rows[i]["SR_NO"]), (object)",'"), rsDetl.Rows[i]["BOOK_NAME"]), (object)"','"), rsDetl.Rows[i]["BOOK_SNAME"]), (object)"','"), rsDetl.Rows[i]["BOOK_TYPE"]), (object)"','"), rsDetl.Rows[i]["ITM_TYPE"]), (object)"','"), rsDetl.Rows[i]["BOOK_INOUT"]), (object)"','"), rsDetl.Rows[i]["AC_CODE"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["AC_NAME"]), (object)"','"), rsDetl.Rows[i]["MAIN_BOOK"]), (object)"','"), rsDetl.Rows[i]["RESET_BOOK"]), (object)"','"), rsDetl.Rows[i]["DATA_TYPE"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsDetl = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BOOK_DATA SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ac_Karigar()
	{
		DC_Main.RsQry = "SELECT A.* FROM KR_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.BOOK_TYPE = 'T' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Karigar";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM KR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO KR_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CODE,  AC_NAME,NET_AMT,DISC_PRC,DISC_AMT,TAX_CODE,TAX_PRC,TAX_AMT,ROF_AMT,TOT_AMT,CASH_AMT,CARD_AMT,CHQ_AMT,KASAR_AMT,  BILL_OS,OS_ADJ_AMT,CR_DAYS,CARD_AC,BANK_AC,CHQ_NO,BANK_NAME,EMP_CODE,VCH_DESC,DATA_TRFR,ENTRY_TIME,ADD1,ADD2,  ADD3,CITY,MOBILE,AC_GST_TYPE,IGST_TAX,CGST_TAX,SGST_TAX,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,LBR_AMT,OTH_AMT,  SL_BILL_NO,SL_BILL_LC,SL_BILL_YRCD,SL_BILL_DBCD,PARTY_FINE,IT_TYPE,TCS_CODE,TCS_PRC,TCS_AMT)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["BILL_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"',"), rshlp.Rows[DC_Main.M]["NET_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["DISC_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["DISC_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["TAX_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TAX_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TAX_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["ROF_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["TOT_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CASH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CARD_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CHQ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["KASAR_AMT"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["BILL_OS"]), (object)","), rshlp.Rows[DC_Main.M]["OS_ADJ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CR_DAYS"]), (object)",'"), rshlp.Rows[DC_Main.M]["CARD_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["CHQ_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_DESC"]), (object)"','"), rshlp.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), rshlp.Rows[DC_Main.M]["ENTRY_TIME"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD1"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD2"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["ADD3"]), (object)"','"), rshlp.Rows[DC_Main.M]["CITY"]), (object)"','"), rshlp.Rows[DC_Main.M]["MOBILE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_GST_TYPE"]), (object)"',"), rshlp.Rows[DC_Main.M]["IGST_TAX"]), (object)","), rshlp.Rows[DC_Main.M]["CGST_TAX"]), (object)","), rshlp.Rows[DC_Main.M]["SGST_TAX"]), (object)",'"), rshlp.Rows[DC_Main.M]["OLD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["NEW_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"',"), rshlp.Rows[DC_Main.M]["LBR_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["OTH_AMT"]), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["SL_BILL_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["SL_BILL_LC"]), (object)"','"), rshlp.Rows[DC_Main.M]["SL_BILL_YRCD"]), (object)"','"), rshlp.Rows[DC_Main.M]["SL_BILL_DBCD"]), (object)"',"), rshlp.Rows[DC_Main.M]["PARTY_FINE"]), (object)",'"), rshlp.Rows[DC_Main.M]["IT_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["TCS_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TCS_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TCS_AMT"]), (object)")"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int i = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM KR_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsDetl;
				for (rsDetl = RsDetl; i < rsDetl.Rows.Count; i++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO KR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,VCH_TYPE,  INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,  ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,  OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,RATE_TYPE,IT_TYPE,WITH_STOCK,HD_VCH_NO,  OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,ADD_USER,ITM_OTH_RATE,ITM_OTH_FINE,SL_BILL_NO,SL_BILL_LC,SL_BILL_YRCD,  SL_BILL_DBCD,CONV_RATE,CONV_PRC,ITM_LESS_TCH,IT_DESC,ITM_LOSS_WT)   VALUES ('", rsDetl.Rows[i]["CO_CODE"]), (object)"','"), rsDetl.Rows[i]["LC_CODE"]), (object)"','"), rsDetl.Rows[i]["CO_YEAR"]), (object)"','"), rsDetl.Rows[i]["CO_BOOK"]), (object)"','"), rsDetl.Rows[i]["VCH_NO"]), (object)"',"), rsDetl.Rows[i]["SR_NO"]), (object)","), rsDetl.Rows[i]["OLD_SRNO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rsDetl.Rows[i]["VCH_TYPE"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["INOUT_TYPE"]), (object)"','"), rsDetl.Rows[i]["ENTRY_TYPE"]), (object)"','"), rsDetl.Rows[i]["BOOK_NAME"]), (object)"','"), rsDetl.Rows[i]["AC_CODE"]), (object)"','"), rsDetl.Rows[i]["IT_CODE"]), (object)"','"), rsDetl.Rows[i]["TAG_NO"]), (object)"','"), rsDetl.Rows[i]["LOT_NO"]), (object)"','"), rsDetl.Rows[i]["DESIGN_NO"]), (object)"','"), rsDetl.Rows[i]["TBL_CODE"]), (object)"','"), rsDetl.Rows[i]["ITM_SIZE"]), (object)"',"), rsDetl.Rows[i]["ITM_PCS"]), (object)","), rsDetl.Rows[i]["BAG_WT"]), (object)", "), (object)" "), rsDetl.Rows[i]["ITM_GWT"]), (object)","), rsDetl.Rows[i]["ITM_OTH_WT"]), (object)","), rsDetl.Rows[i]["ITM_NWT"]), (object)","), rsDetl.Rows[i]["ITM_GHT_WT"]), (object)","), rsDetl.Rows[i]["ITM_TOUCH"]), (object)","), rsDetl.Rows[i]["ITM_WEST_PRC"]), (object)","), rsDetl.Rows[i]["ITM_FINE"]), (object)","), rsDetl.Rows[i]["LBR_PRC"]), (object)","), rsDetl.Rows[i]["LBR_RATE"]), (object)",'"), rsDetl.Rows[i]["LBR_TYPE"]), (object)"',"), rsDetl.Rows[i]["LBR_AMT"]), (object)", "), (object)" "), rsDetl.Rows[i]["OTH_AMT"]), (object)","), rsDetl.Rows[i]["ITM_RATE"]), (object)","), rsDetl.Rows[i]["ITM_AMT"]), (object)","), rsDetl.Rows[i]["TAG_COST"]), (object)","), rsDetl.Rows[i]["ITM_MRP"]), (object)","), rsDetl.Rows[i]["TOT_AMT"]), (object)","), rsDetl.Rows[i]["TAX_PRC"]), (object)","), rsDetl.Rows[i]["NET_AMT"]), (object)",'"), rsDetl.Rows[i]["RATE_TYPE"]), (object)"','"), rsDetl.Rows[i]["IT_TYPE"]), (object)"','"), rsDetl.Rows[i]["WITH_STOCK"]), (object)"','"), rsDetl.Rows[i]["HD_VCH_NO"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["OLD_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["NEW_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["MAIN_USER"]), (object)"','"), rsDetl.Rows[i]["ADD_USER"]), (object)"','"), rsDetl.Rows[i]["ITM_OTH_RATE"]), (object)"','"), rsDetl.Rows[i]["ITM_OTH_FINE"]), (object)"','"), rsDetl.Rows[i]["SL_BILL_NO"]), (object)"','"), rsDetl.Rows[i]["SL_BILL_LC"]), (object)"','"), rsDetl.Rows[i]["SL_BILL_YRCD"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["SL_BILL_DBCD"]), (object)"',"), rsDetl.Rows[i]["CONV_RATE"]), (object)","), rsDetl.Rows[i]["CONV_PRC"]), (object)","), rsDetl.Rows[i]["ITM_LESS_TCH"]), (object)",'"), rsDetl.Rows[i]["IT_DESC"]), (object)"',"), rsDetl.Rows[i]["ITM_LOSS_WT"]), (object)")"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsDetl = null;
				int j = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM KR_IDTL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO,ISR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsIdtl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsIdtl;
				for (rsIdtl = RsIdtl; j < rsIdtl.Rows.Count; j++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO KR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,  KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,  KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,  MAIN_USER)   VALUES ('", rsIdtl.Rows[j]["CO_CODE"]), (object)"','"), rsIdtl.Rows[j]["LC_CODE"]), (object)"','"), rsIdtl.Rows[j]["CO_YEAR"]), (object)"','"), rsIdtl.Rows[j]["CO_BOOK"]), (object)"','"), rsIdtl.Rows[j]["VCH_NO"]), (object)"',"), rsIdtl.Rows[j]["SR_NO"]), (object)","), rsIdtl.Rows[j]["ISR_NO"]), (object)",'"), (object)Strings.Format((object)Conversions.ToDate(rsIdtl.Rows[j]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsIdtl.Rows[j]["VCH_TYPE"]), (object)"','"), rsIdtl.Rows[j]["INOUT_TYPE"]), (object)"', "), (object)" '"), rsIdtl.Rows[j]["ENTRY_TYPE"]), (object)"','"), rsIdtl.Rows[j]["BOOK_NAME"]), (object)"','"), rsIdtl.Rows[j]["AC_CODE"]), (object)"','"), rsIdtl.Rows[j]["TAG_NO"]), (object)"',"), rsIdtl.Rows[j]["VCH_SRNO"]), (object)",'"), rsIdtl.Rows[j]["IT_CODE"]), (object)"','"), rsIdtl.Rows[j]["IT_TYPE"]), (object)"','"), rsIdtl.Rows[j]["DM_CODE"]), (object)"','"), rsIdtl.Rows[j]["DM_SIZE"]), (object)"','"), rsIdtl.Rows[j]["DM_SFNO"]), (object)"','"), rsIdtl.Rows[j]["DM_LEB"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS"]), (object)"',"), rsIdtl.Rows[j]["IT_PCS_WT"]), (object)", "), (object)" "), rsIdtl.Rows[j]["KR_WT"]), (object)","), rsIdtl.Rows[j]["KR_LESS_PRC"]), (object)","), rsIdtl.Rows[j]["IT_GWT"]), (object)","), rsIdtl.Rows[j]["IT_CON_PRC"]), (object)","), rsIdtl.Rows[j]["IT_CON_WT"]), (object)",'"), rsIdtl.Rows[j]["IT_RATE_TYPE"]), (object)"',"), rsIdtl.Rows[j]["IT_RATE"]), (object)","), rsIdtl.Rows[j]["IT_AMT"]), (object)","), rsIdtl.Rows[j]["IT_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["IT_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["IT_NET_AMT"]), (object)", "), (object)" "), rsIdtl.Rows[j]["KR_CON_PRC"]), (object)","), rsIdtl.Rows[j]["KR_CON_WT"]), (object)","), rsIdtl.Rows[j]["KR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_NET_AMT"]), (object)",'"), rsIdtl.Rows[j]["HD_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["OLD_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["NEW_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["MAIN_USER"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsIdtl = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE KR_DATA SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ac_Purchase()
	{
		DC_Main.RsQry = "SELECT A.* FROM PR_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.BOOK_TYPE = 'T' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Purchase";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO PR_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CODE,  AC_NAME,NET_AMT,DISC_PRC,DISC_AMT,TAX_CODE,TAX_PRC,TAX_AMT,ROF_AMT,TOT_AMT,CASH_AMT,CARD_AMT,CHQ_AMT,KASAR_AMT,  BILL_OS,OS_ADJ_AMT,CR_DAYS,CARD_AC,BANK_AC,CHQ_NO,BANK_NAME,EMP_CODE,VCH_DESC,DATA_TRFR,ENTRY_TIME,ADD1,ADD2,  ADD3,CITY,MOBILE,AC_GST_TYPE,IGST_TAX,CGST_TAX,SGST_TAX,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,LBR_AMT,OTH_AMT,  SL_BILL_NO,SL_BILL_LC,SL_BILL_YRCD,SL_BILL_DBCD,PARTY_FINE,IT_TYPE,TCS_CODE,TCS_PRC,TCS_AMT)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["BILL_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"',"), rshlp.Rows[DC_Main.M]["NET_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["DISC_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["DISC_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["TAX_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TAX_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TAX_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["ROF_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["TOT_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CASH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CARD_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CHQ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["KASAR_AMT"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["BILL_OS"]), (object)","), rshlp.Rows[DC_Main.M]["OS_ADJ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CR_DAYS"]), (object)",'"), rshlp.Rows[DC_Main.M]["CARD_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["CHQ_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_DESC"]), (object)"','"), rshlp.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), rshlp.Rows[DC_Main.M]["ENTRY_TIME"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD1"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD2"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["ADD3"]), (object)"','"), rshlp.Rows[DC_Main.M]["CITY"]), (object)"','"), rshlp.Rows[DC_Main.M]["MOBILE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_GST_TYPE"]), (object)"',"), rshlp.Rows[DC_Main.M]["IGST_TAX"]), (object)","), rshlp.Rows[DC_Main.M]["CGST_TAX"]), (object)","), rshlp.Rows[DC_Main.M]["SGST_TAX"]), (object)",'"), rshlp.Rows[DC_Main.M]["OLD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["NEW_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"',"), rshlp.Rows[DC_Main.M]["LBR_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["OTH_AMT"]), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["SL_BILL_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["SL_BILL_LC"]), (object)"','"), rshlp.Rows[DC_Main.M]["SL_BILL_YRCD"]), (object)"','"), rshlp.Rows[DC_Main.M]["SL_BILL_DBCD"]), (object)"',"), rshlp.Rows[DC_Main.M]["PARTY_FINE"]), (object)",'"), rshlp.Rows[DC_Main.M]["IT_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["TCS_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TCS_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TCS_AMT"]), (object)")"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int i = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM PR_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsDetl;
				for (rsDetl = RsDetl; i < rsDetl.Rows.Count; i++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO PR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,VCH_TYPE,  INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,  ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,  OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,RATE_TYPE,IT_TYPE,WITH_STOCK,HD_VCH_NO,  OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,ADD_USER,ITM_OTH_RATE,ITM_OTH_FINE,SL_BILL_NO,SL_BILL_LC,SL_BILL_YRCD,  SL_BILL_DBCD,CONV_RATE,CONV_PRC,ITM_LESS_TCH,IT_DESC,ITM_LOSS_WT)   VALUES ('", rsDetl.Rows[i]["CO_CODE"]), (object)"','"), rsDetl.Rows[i]["LC_CODE"]), (object)"','"), rsDetl.Rows[i]["CO_YEAR"]), (object)"','"), rsDetl.Rows[i]["CO_BOOK"]), (object)"','"), rsDetl.Rows[i]["VCH_NO"]), (object)"',"), rsDetl.Rows[i]["SR_NO"]), (object)","), rsDetl.Rows[i]["OLD_SRNO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rsDetl.Rows[i]["VCH_TYPE"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["INOUT_TYPE"]), (object)"','"), rsDetl.Rows[i]["ENTRY_TYPE"]), (object)"','"), rsDetl.Rows[i]["BOOK_NAME"]), (object)"','"), rsDetl.Rows[i]["AC_CODE"]), (object)"','"), rsDetl.Rows[i]["IT_CODE"]), (object)"','"), rsDetl.Rows[i]["TAG_NO"]), (object)"','"), rsDetl.Rows[i]["LOT_NO"]), (object)"','"), rsDetl.Rows[i]["DESIGN_NO"]), (object)"','"), rsDetl.Rows[i]["TBL_CODE"]), (object)"','"), rsDetl.Rows[i]["ITM_SIZE"]), (object)"',"), rsDetl.Rows[i]["ITM_PCS"]), (object)","), rsDetl.Rows[i]["BAG_WT"]), (object)", "), (object)" "), rsDetl.Rows[i]["ITM_GWT"]), (object)","), rsDetl.Rows[i]["ITM_OTH_WT"]), (object)","), rsDetl.Rows[i]["ITM_NWT"]), (object)","), rsDetl.Rows[i]["ITM_GHT_WT"]), (object)","), rsDetl.Rows[i]["ITM_TOUCH"]), (object)","), rsDetl.Rows[i]["ITM_WEST_PRC"]), (object)","), rsDetl.Rows[i]["ITM_FINE"]), (object)","), rsDetl.Rows[i]["LBR_PRC"]), (object)","), rsDetl.Rows[i]["LBR_RATE"]), (object)",'"), rsDetl.Rows[i]["LBR_TYPE"]), (object)"',"), rsDetl.Rows[i]["LBR_AMT"]), (object)", "), (object)" "), rsDetl.Rows[i]["OTH_AMT"]), (object)","), rsDetl.Rows[i]["ITM_RATE"]), (object)","), rsDetl.Rows[i]["ITM_AMT"]), (object)","), rsDetl.Rows[i]["TAG_COST"]), (object)","), rsDetl.Rows[i]["ITM_MRP"]), (object)","), rsDetl.Rows[i]["TOT_AMT"]), (object)","), rsDetl.Rows[i]["TAX_PRC"]), (object)","), rsDetl.Rows[i]["NET_AMT"]), (object)",'"), rsDetl.Rows[i]["RATE_TYPE"]), (object)"','"), rsDetl.Rows[i]["IT_TYPE"]), (object)"','"), rsDetl.Rows[i]["WITH_STOCK"]), (object)"','"), rsDetl.Rows[i]["HD_VCH_NO"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["OLD_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["NEW_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["MAIN_USER"]), (object)"','"), rsDetl.Rows[i]["ADD_USER"]), (object)"','"), rsDetl.Rows[i]["ITM_OTH_RATE"]), (object)"','"), rsDetl.Rows[i]["ITM_OTH_FINE"]), (object)"','"), rsDetl.Rows[i]["SL_BILL_NO"]), (object)"','"), rsDetl.Rows[i]["SL_BILL_LC"]), (object)"','"), rsDetl.Rows[i]["SL_BILL_YRCD"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["SL_BILL_DBCD"]), (object)"',"), rsDetl.Rows[i]["CONV_RATE"]), (object)","), rsDetl.Rows[i]["CONV_PRC"]), (object)","), rsDetl.Rows[i]["ITM_LESS_TCH"]), (object)",'"), rsDetl.Rows[i]["IT_DESC"]), (object)"',"), rsDetl.Rows[i]["ITM_LOSS_WT"]), (object)")"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsDetl = null;
				int j = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM PR_IDTL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO,ISR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsIdtl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsIdtl;
				for (rsIdtl = RsIdtl; j < rsIdtl.Rows.Count; j++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO PR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,  KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,  KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,  MAIN_USER)   VALUES ('", rsIdtl.Rows[j]["CO_CODE"]), (object)"','"), rsIdtl.Rows[j]["LC_CODE"]), (object)"','"), rsIdtl.Rows[j]["CO_YEAR"]), (object)"','"), rsIdtl.Rows[j]["CO_BOOK"]), (object)"','"), rsIdtl.Rows[j]["VCH_NO"]), (object)"',"), rsIdtl.Rows[j]["SR_NO"]), (object)","), rsIdtl.Rows[j]["ISR_NO"]), (object)",'"), (object)Strings.Format((object)Conversions.ToDate(rsIdtl.Rows[j]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsIdtl.Rows[j]["VCH_TYPE"]), (object)"','"), rsIdtl.Rows[j]["INOUT_TYPE"]), (object)"', "), (object)" '"), rsIdtl.Rows[j]["ENTRY_TYPE"]), (object)"','"), rsIdtl.Rows[j]["BOOK_NAME"]), (object)"','"), rsIdtl.Rows[j]["AC_CODE"]), (object)"','"), rsIdtl.Rows[j]["TAG_NO"]), (object)"',"), rsIdtl.Rows[j]["VCH_SRNO"]), (object)",'"), rsIdtl.Rows[j]["IT_CODE"]), (object)"','"), rsIdtl.Rows[j]["IT_TYPE"]), (object)"','"), rsIdtl.Rows[j]["DM_CODE"]), (object)"','"), rsIdtl.Rows[j]["DM_SIZE"]), (object)"','"), rsIdtl.Rows[j]["DM_SFNO"]), (object)"','"), rsIdtl.Rows[j]["DM_LEB"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS"]), (object)"',"), rsIdtl.Rows[j]["IT_PCS_WT"]), (object)", "), (object)" "), rsIdtl.Rows[j]["KR_WT"]), (object)","), rsIdtl.Rows[j]["KR_LESS_PRC"]), (object)","), rsIdtl.Rows[j]["IT_GWT"]), (object)","), rsIdtl.Rows[j]["IT_CON_PRC"]), (object)","), rsIdtl.Rows[j]["IT_CON_WT"]), (object)",'"), rsIdtl.Rows[j]["IT_RATE_TYPE"]), (object)"',"), rsIdtl.Rows[j]["IT_RATE"]), (object)","), rsIdtl.Rows[j]["IT_AMT"]), (object)","), rsIdtl.Rows[j]["IT_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["IT_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["IT_NET_AMT"]), (object)", "), (object)" "), rsIdtl.Rows[j]["KR_CON_PRC"]), (object)","), rsIdtl.Rows[j]["KR_CON_WT"]), (object)","), rsIdtl.Rows[j]["KR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_NET_AMT"]), (object)",'"), rsIdtl.Rows[j]["HD_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["OLD_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["NEW_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["MAIN_USER"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsIdtl = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE PR_DATA SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ac_BarData()
	{
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			ExeQuteCnTr("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ");
			ExeQuteCnTr("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ");
			ExeQuteCnTr("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ");
		}
		else
		{
			DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ");
			DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ");
			DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ");
		}
		string text = "00001";
		DC_Main.RsQry = "SELECT B.IT_TYPE,A.IT_CODE FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND TAG_NO <> 'N' GROUP BY B.IT_TYPE,A.IT_CODE ORDER BY B.IT_TYPE,A.IT_CODE ";
		DataTable dataTable = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = dataTable.Rows.Count;
		lblBook.Text = "Tag Transfer";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < dataTable.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND IT_CODE = '"), dataTable.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
				DataTable table = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataView dataView = new DataView(table);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.TAG_NO ,A.IT_CODE,C.VCH_SRNO  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND C.IT_CODE = '"), dataTable.Rows[DC_Main.M]["IT_CODE"]), (object)"' And A.TAG_NO <> '' AND C.STK_DATE <= '"), (object)Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy")), (object)"'"));
				DC_Main.RsQry += " GROUP BY A.TAG_NO,A.IT_CODE,C.VCH_SRNO ";
				DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO";
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DC_Main.i = 0;
				int num = 0;
				while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
				{
					num++;
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"TAG_NO = '", DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"]), (object)""));
					DataView dataView2 = dataView;
					object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,  TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,  ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,  KR_NAME,KR_OTH_WT,KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,  KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,TAG_SRNO,VCH_SRNO,RATE_TYPE,IT_TYPE,  TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,ORD_AC,MAIN_USER,ADD_USER,DATA_TRFR) VALUES  ('", dataView2[0]["CO_CODE"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), (object)DC_Main.MCo_year), (object)"','000','"), (object)text), (object)"',"), (object)num), (object)","), (object)num), (object)", "), (object)" '"), (object)Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["STK_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), dataView2[0]["VCH_TYPE"]), (object)"','I','O','"), dataView2[0]["BOOK_NAME"]), (object)"','"), dataView2[0]["AC_CODE"]), (object)"','"), dataView2[0]["IT_CODE"]), (object)"', "), (object)" '"), dataView2[0]["TAG_NO"]), (object)"','','"), dataView2[0]["DESIGN_NO"]), (object)"','001','"), dataView2[0]["ITM_SIZE"]), (object)"',");
					DataRowView dataRowView;
					object Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_PCS"]);
					double num2 = DC_Main.Fnv(ref Value);
					dataRowView["ITM_PCS"] = RuntimeHelpers.GetObjectValue(Value);
					object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num2), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["BAG_WT"]);
					double num3 = DC_Main.Fnv(ref Value);
					dataRowView["BAG_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num3), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_GWT"]);
					double num4 = DC_Main.Fnv(ref Value);
					dataRowView["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num4), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_GWT"]);
					double num5 = DC_Main.Fnv(ref Value);
					dataRowView["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num5), (object)"-");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_NWT"]);
					double num6 = DC_Main.Fnv(ref Value);
					dataRowView["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num6), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_NWT"]);
					double num7 = DC_Main.Fnv(ref Value);
					dataRowView["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj7 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num7), (object)", "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_GHT_PRC"]);
					double num8 = DC_Main.Fnv(ref Value);
					dataRowView["ITM_GHT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj8 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, (object)num8), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_GHT_WT"]);
					double num9 = DC_Main.Fnv(ref Value);
					dataRowView["ITM_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj9 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj8, (object)num9), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_TOUCH"]);
					double num10 = DC_Main.Fnv(ref Value);
					dataRowView["ITM_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj10 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj9, (object)num10), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_WEST_PRC"]);
					double num11 = DC_Main.Fnv(ref Value);
					dataRowView["ITM_WEST_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj11 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj10, (object)num11), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_FINE"]);
					double num12 = DC_Main.Fnv(ref Value);
					dataRowView["ITM_FINE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj12 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj11, (object)num12), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["LBR_PRC"]);
					double num13 = DC_Main.Fnv(ref Value);
					dataRowView["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj13 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj12, (object)num13), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["LBR_RATE"]);
					double num14 = DC_Main.Fnv(ref Value);
					dataRowView["LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj14 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj13, (object)num14), (object)",'"), dataView2[0]["LBR_TYPE"]), (object)"', "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["LBR_AMT"]);
					double num15 = DC_Main.Fnv(ref Value);
					dataRowView["LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj15 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj14, (object)num15), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["OTH_AMT"]);
					double num16 = DC_Main.Fnv(ref Value);
					dataRowView["OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj16 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj15, (object)num16), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_RATE"]);
					double num17 = DC_Main.Fnv(ref Value);
					dataRowView["ITM_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj17 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj16, (object)num17), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_AMT"]);
					double num18 = DC_Main.Fnv(ref Value);
					dataRowView["ITM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj18 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj17, (object)num18), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["TAG_COST"]);
					double num19 = DC_Main.Fnv(ref Value);
					dataRowView["TAG_COST"] = RuntimeHelpers.GetObjectValue(Value);
					object obj19 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj18, (object)num19), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_MARGIN"]);
					double num20 = DC_Main.Fnv(ref Value);
					dataRowView["ITM_MARGIN"] = RuntimeHelpers.GetObjectValue(Value);
					object obj20 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj19, (object)num20), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_MRP"]);
					double num21 = DC_Main.Fnv(ref Value);
					dataRowView["ITM_MRP"] = RuntimeHelpers.GetObjectValue(Value);
					object obj21 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj20, (object)num21), (object)",'"), dataView2[0]["ITM_REMARK"]), (object)"','"), dataView2[0]["SF_NO"]), (object)"', "), (object)" '"), dataView2[0]["KR_NAME"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_OTH_WT"]);
					double num22 = DC_Main.Fnv(ref Value);
					dataRowView["KR_OTH_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj22 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj21, (object)num22), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_NET_WT"]);
					double num23 = DC_Main.Fnv(ref Value);
					dataRowView["KR_NET_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj23 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj22, (object)num23), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_GHT_PRC"]);
					double num24 = DC_Main.Fnv(ref Value);
					dataRowView["KR_GHT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj24 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj23, (object)num24), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_GHT_WT"]);
					double num25 = DC_Main.Fnv(ref Value);
					dataRowView["KR_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj25 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj24, (object)num25), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_TOUCH"]);
					double num26 = DC_Main.Fnv(ref Value);
					dataRowView["KR_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj26 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj25, (object)num26), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_WEST_PRC"]);
					double num27 = DC_Main.Fnv(ref Value);
					dataRowView["KR_WEST_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj27 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj26, (object)num27), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_FINE"]);
					double num28 = DC_Main.Fnv(ref Value);
					dataRowView["KR_FINE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj28 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj27, (object)num28), (object)", "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_LBR_RATE"]);
					double num29 = DC_Main.Fnv(ref Value);
					dataRowView["KR_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj29 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj28, (object)num29), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_LBR_AMT"]);
					double num30 = DC_Main.Fnv(ref Value);
					dataRowView["KR_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj30 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj29, (object)num30), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_OTH_AMT"]);
					double num31 = DC_Main.Fnv(ref Value);
					dataRowView["KR_OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj31 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj30, (object)num31), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_COST"]);
					double num32 = DC_Main.Fnv(ref Value);
					dataRowView["KR_COST"] = RuntimeHelpers.GetObjectValue(Value);
					object obj32 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj31, (object)num32), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["TAG_SRNO"]);
					double num33 = DC_Main.Fnv(ref Value);
					dataRowView["TAG_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					object obj33 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj32, (object)num33), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["VCH_SRNO"]);
					double num34 = DC_Main.Fnv(ref Value);
					dataRowView["VCH_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj33, (object)num34), (object)",'"), dataView2[0]["RATE_TYPE"]), (object)"','"), dataView2[0]["IT_TYPE"]), (object)"', "), (object)" '"), dataView2[0]["TAG_TYPE"]), (object)"','"), dataView2[0]["PR_CODE"]), (object)"','N','','0','','','','"), (object)DC_Main.MCo_User), (object)"','"), (object)DC_Main.MCo_User), (object)"','N' )"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_TYPE FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"]), (object)" ORDER BY A.ISR_NO "));
					table = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
					DC_Main.R = 0;
					while (DC_Main.R < table.Rows.Count)
					{
						object obj34 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,  DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,  IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','" + text + "'," + Conversions.ToString(num) + "," + Conversions.ToString(DC_Main.R + 1) + ",'" + Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy") + "',  '"), table.Rows[DC_Main.R]["VCH_TYPE"]), (object)"','I','O','"), table.Rows[DC_Main.R]["BOOK_NAME"]), (object)"','"), table.Rows[DC_Main.R]["AC_CODE"]), (object)"','"), table.Rows[DC_Main.R]["TAG_NO"]), (object)"',"), table.Rows[DC_Main.R]["VCH_SRNO"]), (object)",'"), table.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), table.Rows[DC_Main.R]["IT_TYPE"]), (object)"', "), (object)" '"), table.Rows[DC_Main.R]["DM_CODE"]), (object)"','"), table.Rows[DC_Main.R]["DM_SIZE"]), (object)"','"), table.Rows[DC_Main.R]["DM_SFNO"]), (object)"','"), table.Rows[DC_Main.R]["DM_LEB"]), (object)"',");
						DataRow dataRow;
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["IT_PCS"]);
						double num35 = DC_Main.Fnv(ref Value);
						dataRow["IT_PCS"] = RuntimeHelpers.GetObjectValue(Value);
						object obj35 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj34, (object)num35), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["IT_PCS_WT"]);
						double num36 = DC_Main.Fnv(ref Value);
						dataRow["IT_PCS_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj36 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj35, (object)num36), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["KR_WT"]);
						double num37 = DC_Main.Fnv(ref Value);
						dataRow["KR_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj37 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj36, (object)num37), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["KR_LESS_PRC"]);
						double num38 = DC_Main.Fnv(ref Value);
						dataRow["KR_LESS_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						object obj38 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj37, (object)num38), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["IT_GWT"]);
						double num39 = DC_Main.Fnv(ref Value);
						dataRow["IT_GWT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj39 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj38, (object)num39), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["IT_CON_PRC"]);
						double num40 = DC_Main.Fnv(ref Value);
						dataRow["IT_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						object obj40 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj39, (object)num40), (object)", "), (object)" ");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["IT_CON_WT"]);
						double num41 = DC_Main.Fnv(ref Value);
						dataRow["IT_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj41 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj40, (object)num41), (object)",'"), table.Rows[DC_Main.R]["IT_RATE_TYPE"]), (object)"',");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["IT_RATE"]);
						double num42 = DC_Main.Fnv(ref Value);
						dataRow["IT_RATE"] = RuntimeHelpers.GetObjectValue(Value);
						object obj42 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj41, (object)num42), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["IT_AMT"]);
						double num43 = DC_Main.Fnv(ref Value);
						dataRow["IT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj43 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj42, (object)num43), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["IT_LBR_RATE"]);
						double num44 = DC_Main.Fnv(ref Value);
						dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
						object obj44 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj43, (object)num44), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["IT_LBR_AMT"]);
						double num45 = DC_Main.Fnv(ref Value);
						dataRow["IT_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj45 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj44, (object)num45), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["IT_NET_AMT"]);
						double num46 = DC_Main.Fnv(ref Value);
						dataRow["IT_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj46 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj45, (object)num46), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["KR_CON_PRC"]);
						double num47 = DC_Main.Fnv(ref Value);
						dataRow["KR_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						object obj47 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj46, (object)num47), (object)", "), (object)" ");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["KR_CON_WT"]);
						double num48 = DC_Main.Fnv(ref Value);
						dataRow["KR_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj48 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj47, (object)num48), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["KR_RATE"]);
						double num49 = DC_Main.Fnv(ref Value);
						dataRow["KR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
						object obj49 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj48, (object)num49), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["KR_AMT"]);
						double num50 = DC_Main.Fnv(ref Value);
						dataRow["KR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj50 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj49, (object)num50), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["KR_LBR_RATE"]);
						double num51 = DC_Main.Fnv(ref Value);
						dataRow["KR_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
						object obj51 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj50, (object)num51), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["KR_LBR_AMT"]);
						double num52 = DC_Main.Fnv(ref Value);
						dataRow["KR_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj52 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj51, (object)num52), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["KR_NET_AMT"]);
						double num53 = DC_Main.Fnv(ref Value);
						dataRow["KR_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj53 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj52, (object)num53), (object)",'");
						Value = RuntimeHelpers.GetObjectValue((dataRow = table.Rows[DC_Main.R])["MAIN_USER"]);
						double num54 = DC_Main.Fnv(ref Value);
						dataRow["MAIN_USER"] = RuntimeHelpers.GetObjectValue(Value);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj53, (object)num54), (object)"')"));
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							ExeQuteCnTr(DC_Main.RsQry);
						}
						else
						{
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						DC_Main.R++;
					}
					dataView2 = null;
					DC_Main.i++;
				}
				if (num > 0)
				{
					DC_Main.RsQry = "INSERT INTO BAR_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE, AC_CODE,CUST_AC,OP_STK,VCH_TIME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','" + text + "','" + Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy") + "','','','Y','" + Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy") + "')";
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					text = Strings.Format((object)(Conversion.Val(text) + 1.0), "00000");
					num = 0;
				}
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ac_CashBank()
	{
		DC_Main.RsQry = "SELECT * FROM CASH_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N' ORDER BY A.CO_BOOK,A.VCH_NO,A.SR_NO";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Case Bank";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM CASH_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = "), rshlp.Rows[DC_Main.M]["SR_NO"]), (object)" "));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO CASH_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,VCH_TIME,AC_CODE,AC_NAME,CHQ_NO,REC_AMT,KASAR_AMT,IT_DESC,BANK_NAME,EMP_CODE,  DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,HD_VCH_NO,MAIN_USER,ADD_USER,REC_AC_CODE,CHQ_PRINT_NAME,  CLR_DATE,USER_UPDATE,USER_DELETE,BANK_CHARGES,MOB_ENTRY_SAVE)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"',");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["SR_NO"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["SR_NO"] = RuntimeHelpers.GetObjectValue(Value);
				object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["INOUT_TYPE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["ENTRY_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_NAME"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["CHQ_NO"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["REC_AMT"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["REC_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["KASAR_AMT"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num3), (object)",'"), rshlp.Rows[DC_Main.M]["IT_DESC"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), rshlp.Rows[DC_Main.M]["OLD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["NEW_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["REC_AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CHQ_PRINT_NAME"]), (object)"', "), (object)" "), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["CLR_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)Conversions.ToDate(rshlp.Rows[DC_Main.M]["CLR_DATE"]), "MM/dd/yyyy") + "'"))), (object)",'"), rshlp.Rows[DC_Main.M]["USER_UPDATE"]), (object)"','"), rshlp.Rows[DC_Main.M]["USER_DELETE"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_CHARGES"]), (object)"','"), rshlp.Rows[DC_Main.M]["MOB_ENTRY_SAVE"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE CASH_DATA SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = "), rshlp.Rows[DC_Main.M]["SR_NO"]), (object)""));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ac_Sales()
	{
		DC_Main.RsQry = "SELECT A.* FROM SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.BOOK_TYPE = 'T' AND B.TRFR_BOOK = 'Y' AND A.DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Sales";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DETL_RTN WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DETL_RTN WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
				}
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CODE,AC_NAME,  NET_AMT,DISC_PRC,DISC_AMT,TAX_CODE,TAX_PRC,TAX_AMT,ROF_AMT,TOT_AMT,ADV_AMT,OLD_GL_AMT,OLD_SL_AMT,CASH_AMT,CARD_AMT,  CHQ_AMT,SCHM_AMT,CASH_PAID,KASAR_AMT,BILL_OS,OS_ADJ_AMT,CR_DAYS,CARD_AC,BANK_AC,CHQ_NO,BANK_NAME,EMP_CODE,VCH_DESC,  ENTRY_TIME,OLD_GL,OLD_SL,ADD1,ADD2,ADD3,CITY,MOBILE,AC_GST_TYPE,IGST_TAX,CGST_TAX,SGST_TAX,DATA_TRFR,OLD_VCH_NO,  NEW_VCH_NO,MAIN_USER,SCHM_AC,CARD_ADJ,ISU_NO,ISU_LC_CODE,ISU_YRCD,ISU_DBCD,RTN_NET_AMT,RTN_TOT_AMT,RTN_CHQ_AMT,  RTN_CARD_AMT,RTN_CASH_AMT,RTN_KASAR_AMT,RTN_BILL_OS,TCS_CODE,TCS_PRC,TCS_AMT,  HM_AMT,HM_TAX_PRC,HM_TAX_AMT,HM_TAX_CODE,TDS_CODE,TDS_PRC,TDS_AMT,CARD_COM_AMT,  USER_UPDATE,USER_DELETE,POINT_VAL,IRN_NO,ACK_NO,ACK_DATE,ORNA_ISU,MOB_ENTRY_SAVE,UPI_AMT,  LBR_AMT,OTH_AMT,CRNT_ADJ_AMT,PARTY_FINE,IT_TYPE,OZ_RATE,OZ_CONV,FX_RATE,FX_CODE,MTL_RATE,  TOT_TAX_FREE_AMT,ZERO_RATED_AMT)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rshlp.Rows[DC_Main.M]["BILL_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"', "), (object)" "), rshlp.Rows[DC_Main.M]["NET_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["DISC_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["DISC_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["TAX_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TAX_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TAX_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["ROF_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["TOT_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["ADV_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["OLD_GL_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["OLD_SL_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CASH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CARD_AMT"]), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["CHQ_AMT"]), (object)"','"), rshlp.Rows[DC_Main.M]["SCHM_AMT"]), (object)"','"), rshlp.Rows[DC_Main.M]["CASH_PAID"]), (object)"','"), rshlp.Rows[DC_Main.M]["KASAR_AMT"]), (object)"','"), rshlp.Rows[DC_Main.M]["BILL_OS"]), (object)"','"), rshlp.Rows[DC_Main.M]["OS_ADJ_AMT"]), (object)"','"), rshlp.Rows[DC_Main.M]["CR_DAYS"]), (object)"','"), rshlp.Rows[DC_Main.M]["CARD_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["CHQ_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_DESC"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["ENTRY_TIME"]), (object)"',"), rshlp.Rows[DC_Main.M]["OLD_GL"]), (object)","), rshlp.Rows[DC_Main.M]["OLD_SL"]), (object)",'"), rshlp.Rows[DC_Main.M]["ADD1"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD2"]), (object)"','"), rshlp.Rows[DC_Main.M]["ADD3"]), (object)"','"), rshlp.Rows[DC_Main.M]["CITY"]), (object)"','"), rshlp.Rows[DC_Main.M]["MOBILE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_GST_TYPE"]), (object)"',"), rshlp.Rows[DC_Main.M]["IGST_TAX"]), (object)","), rshlp.Rows[DC_Main.M]["CGST_TAX"]), (object)","), rshlp.Rows[DC_Main.M]["SGST_TAX"]), (object)",'"), rshlp.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), rshlp.Rows[DC_Main.M]["OLD_VCH_NO"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["NEW_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["SCHM_AC"]), (object)"','"), rshlp.Rows[DC_Main.M]["CARD_ADJ"]), (object)"','"), rshlp.Rows[DC_Main.M]["ISU_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["ISU_LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["ISU_YRCD"]), (object)"','"), rshlp.Rows[DC_Main.M]["ISU_DBCD"]), (object)"',"), rshlp.Rows[DC_Main.M]["RTN_NET_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["RTN_TOT_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["RTN_CHQ_AMT"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["RTN_CARD_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["RTN_CASH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["RTN_KASAR_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["RTN_BILL_OS"]), (object)",'"), rshlp.Rows[DC_Main.M]["TCS_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TCS_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TCS_AMT"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["HM_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["HM_TAX_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["HM_TAX_AMT"]), (object)",'"), rshlp.Rows[DC_Main.M]["HM_TAX_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["TDS_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["TDS_PRC"]), (object)","), rshlp.Rows[DC_Main.M]["TDS_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CARD_COM_AMT"]), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["USER_UPDATE"]), (object)"','"), rshlp.Rows[DC_Main.M]["USER_DELETE"]), (object)"',");
				object Value = Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["POINT_VAL"], (object)"");
				object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)DC_Main.Fnv(ref Value)), (object)",'"), rshlp.Rows[DC_Main.M]["IRN_NO"]), (object)""), (object)"','"), rshlp.Rows[DC_Main.M]["ACK_NO"]), (object)"',NULL,'"), rshlp.Rows[DC_Main.M]["ORNA_ISU"]), (object)"','"), rshlp.Rows[DC_Main.M]["MOB_ENTRY_SAVE"]), (object)"',");
				DataRow dataRow;
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["UPI_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["UPI_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["LBR_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["OTH_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["CRNT_ADJ_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["PARTY_FINE"]), (object)",'"), rshlp.Rows[DC_Main.M]["IT_TYPE"]), (object)"',"), rshlp.Rows[DC_Main.M]["OZ_RATE"]), (object)","), rshlp.Rows[DC_Main.M]["OZ_CONV"]), (object)","), rshlp.Rows[DC_Main.M]["FX_RATE"]), (object)",'"), rshlp.Rows[DC_Main.M]["FX_CODE"]), (object)"',"), rshlp.Rows[DC_Main.M]["MTL_RATE"]), (object)", "), (object)" "), rshlp.Rows[DC_Main.M]["TOT_TAX_FREE_AMT"]), (object)","), rshlp.Rows[DC_Main.M]["ZERO_RATED_AMT"]), (object)")"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				int i = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsDetl;
				for (rsDetl = RsDetl; i < rsDetl.Rows.Count; i++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,  ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,  TAG_COST,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,ITM_REMARK,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_NAME,  RATE_TYPE,IT_TYPE,PR_CODE,HD_VCH_NO,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,ADD_USER,ISU_NO,ISU_LC_CODE,ISU_YRCD,  ISU_DBCD,ISU_SRNO,ITM_GHT_PRC,GHT_AMT,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,HM_AMT,IT_TAX_AMT,IT_DISC_AMT,  ORD_NO,ORD_LC_CODE,ORD_YRCD,ORD_DBCD,ORD_SRNO,TAG_GWT,TAG_NWT,FINE_RATE,DISC_PRC,DISC_AMT,TAX_CODE,  TAXABL_RATE,ITM_IGST_AMT,ITM_CGST_AMT,ITM_SGST_AMT,GRAND_TOTAL,ITM_COLOR,EMP_CODE,ORD_TAG_STK_ADD,DESIGN_IMG_ID)   VALUES ('", rsDetl.Rows[i]["CO_CODE"]), (object)"','"), rsDetl.Rows[i]["LC_CODE"]), (object)"','"), rsDetl.Rows[i]["CO_YEAR"]), (object)"','"), rsDetl.Rows[i]["CO_BOOK"]), (object)"','"), rsDetl.Rows[i]["VCH_NO"]), (object)"',"), rsDetl.Rows[i]["SR_NO"]), (object)","), rsDetl.Rows[i]["OLD_SRNO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[i]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), rsDetl.Rows[i]["VCH_TYPE"]), (object)"','"), rsDetl.Rows[i]["INOUT_TYPE"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["ENTRY_TYPE"]), (object)"','"), rsDetl.Rows[i]["BOOK_NAME"]), (object)"','"), rsDetl.Rows[i]["AC_CODE"]), (object)"','"), rsDetl.Rows[i]["IT_CODE"]), (object)"','"), rsDetl.Rows[i]["TAG_NO"]), (object)"','"), rsDetl.Rows[i]["LOT_NO"]), (object)"','"), rsDetl.Rows[i]["DESIGN_NO"]), (object)"','"), rsDetl.Rows[i]["TBL_CODE"]), (object)"','"), rsDetl.Rows[i]["ITM_SIZE"]), (object)"',"), rsDetl.Rows[i]["ITM_PCS"]), (object)","), rsDetl.Rows[i]["BAG_WT"]), (object)","), rsDetl.Rows[i]["ITM_GWT"]), (object)","), rsDetl.Rows[i]["ITM_OTH_WT"]), (object)", "), (object)" "), rsDetl.Rows[i]["ITM_NWT"]), (object)","), rsDetl.Rows[i]["ITM_GHT_WT"]), (object)","), rsDetl.Rows[i]["ITM_TOUCH"]), (object)","), rsDetl.Rows[i]["ITM_WEST_PRC"]), (object)","), rsDetl.Rows[i]["ITM_FINE"]), (object)","), rsDetl.Rows[i]["LBR_PRC"]), (object)","), rsDetl.Rows[i]["LBR_RATE"]), (object)",'"), rsDetl.Rows[i]["LBR_TYPE"]), (object)"',"), rsDetl.Rows[i]["LBR_AMT"]), (object)","), rsDetl.Rows[i]["OTH_AMT"]), (object)","), rsDetl.Rows[i]["ITM_RATE"]), (object)","), rsDetl.Rows[i]["ITM_AMT"]), (object)", "), (object)" "), rsDetl.Rows[i]["TAG_COST"]), (object)","), rsDetl.Rows[i]["ITM_MRP"]), (object)","), rsDetl.Rows[i]["TOT_AMT"]), (object)","), rsDetl.Rows[i]["TAX_PRC"]), (object)","), rsDetl.Rows[i]["NET_AMT"]), (object)",'"), rsDetl.Rows[i]["ITM_REMARK"]), (object)"',"), rsDetl.Rows[i]["VCH_SRNO"]), (object)","), rsDetl.Rows[i]["KR_NET_WT"]), (object)","), rsDetl.Rows[i]["KR_TOUCH"]), (object)","), rsDetl.Rows[i]["KR_WEST_PRC"]), (object)","), rsDetl.Rows[i]["KR_FINE"]), (object)",'"), rsDetl.Rows[i]["KR_NAME"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["RATE_TYPE"]), (object)"','"), rsDetl.Rows[i]["IT_TYPE"]), (object)"','"), rsDetl.Rows[i]["PR_CODE"]), (object)"','"), rsDetl.Rows[i]["HD_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["DATA_TRFR"]), (object)"','"), rsDetl.Rows[i]["OLD_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["NEW_VCH_NO"]), (object)"','"), rsDetl.Rows[i]["MAIN_USER"]), (object)"','"), rsDetl.Rows[i]["ADD_USER"]), (object)"','"), rsDetl.Rows[i]["ISU_NO"]), (object)"','"), rsDetl.Rows[i]["ISU_LC_CODE"]), (object)"','"), rsDetl.Rows[i]["ISU_YRCD"]), (object)"', "), (object)" '"), rsDetl.Rows[i]["ISU_DBCD"]), (object)"',"), rsDetl.Rows[i]["ISU_SRNO"]), (object)","), rsDetl.Rows[i]["ITM_GHT_PRC"]), (object)","), rsDetl.Rows[i]["GHT_AMT"]), (object)", "), (object)" '"), rsDetl.Rows[i]["HM_ID"]), (object)"','"), rsDetl.Rows[i]["HM_ID2"]), (object)"','"), rsDetl.Rows[i]["HM_ID3"]), (object)"','"), rsDetl.Rows[i]["HM_ID4"]), (object)"',"), rsDetl.Rows[i]["HM_ID_WT"]), (object)","), rsDetl.Rows[i]["HM_ID2_WT"]), (object)","), rsDetl.Rows[i]["HM_ID3_WT"]), (object)","), rsDetl.Rows[i]["HM_ID4_WT"]), (object)","), rsDetl.Rows[i]["HM_AMT"]), (object)","), rsDetl.Rows[i]["IT_TAX_AMT"]), (object)","), rsDetl.Rows[i]["IT_DISC_AMT"]), (object)", "), (object)" '"), rsDetl.Rows[i]["ORD_NO"]), (object)"','"), rsDetl.Rows[i]["ORD_LC_CODE"]), (object)"','"), rsDetl.Rows[i]["ORD_YRCD"]), (object)"','"), rsDetl.Rows[i]["ORD_DBCD"]), (object)"',"), rsDetl.Rows[i]["ORD_SRNO"]), (object)","), rsDetl.Rows[i]["TAG_GWT"]), (object)","), rsDetl.Rows[i]["TAG_NWT"]), (object)","), rsDetl.Rows[i]["FINE_RATE"]), (object)","), rsDetl.Rows[i]["DISC_PRC"]), (object)","), rsDetl.Rows[i]["DISC_AMT"]), (object)",'"), rsDetl.Rows[i]["TAX_CODE"]), (object)"', "), (object)" "), rsDetl.Rows[i]["TAXABL_RATE"]), (object)","), rsDetl.Rows[i]["ITM_IGST_AMT"]), (object)","), rsDetl.Rows[i]["ITM_CGST_AMT"]), (object)","), rsDetl.Rows[i]["ITM_SGST_AMT"]), (object)","), rsDetl.Rows[i]["GRAND_TOTAL"]), (object)",'"), rsDetl.Rows[i]["ITM_COLOR"]), (object)"','"), rsDetl.Rows[i]["EMP_CODE"]), (object)"','"), rsDetl.Rows[i]["ORD_TAG_STK_ADD"]), (object)"','"), rsDetl.Rows[i]["DESIGN_IMG_ID"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsDetl = null;
				int j = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_IDTL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsIdtl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DataTable rsIdtl;
				for (rsIdtl = RsIdtl; j < rsIdtl.Rows.Count; j++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,  KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,  KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,HD_VCH_NO,MAIN_USER)   VALUES ('", rsIdtl.Rows[j]["CO_CODE"]), (object)"','"), rsIdtl.Rows[j]["LC_CODE"]), (object)"','"), rsIdtl.Rows[j]["CO_YEAR"]), (object)"','"), rsIdtl.Rows[j]["CO_BOOK"]), (object)"','"), rsIdtl.Rows[j]["VCH_NO"]), (object)"',"), rsIdtl.Rows[j]["SR_NO"]), (object)","), rsIdtl.Rows[j]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsIdtl.Rows[j]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsIdtl.Rows[j]["VCH_TYPE"]), (object)"','"), rsIdtl.Rows[j]["INOUT_TYPE"]), (object)"', "), (object)" '"), rsIdtl.Rows[j]["ENTRY_TYPE"]), (object)"','"), rsIdtl.Rows[j]["BOOK_NAME"]), (object)"','"), rsIdtl.Rows[j]["AC_CODE"]), (object)"','"), rsIdtl.Rows[j]["TAG_NO"]), (object)"','"), rsIdtl.Rows[j]["VCH_SRNO"]), (object)"','"), rsIdtl.Rows[j]["IT_CODE"]), (object)"','"), rsIdtl.Rows[j]["IT_TYPE"]), (object)"','"), rsIdtl.Rows[j]["DM_CODE"]), (object)"','"), rsIdtl.Rows[j]["DM_SIZE"]), (object)"','"), rsIdtl.Rows[j]["DM_SFNO"]), (object)"','"), rsIdtl.Rows[j]["DM_LEB"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS"]), (object)"','"), rsIdtl.Rows[j]["IT_PCS_WT"]), (object)"', "), (object)" "), rsIdtl.Rows[j]["KR_WT"]), (object)","), rsIdtl.Rows[j]["KR_LESS_PRC"]), (object)","), rsIdtl.Rows[j]["IT_GWT"]), (object)",'"), rsIdtl.Rows[j]["IT_CON_PRC"]), (object)"',"), rsIdtl.Rows[j]["IT_CON_WT"]), (object)",'"), rsIdtl.Rows[j]["IT_RATE_TYPE"]), (object)"',"), rsIdtl.Rows[j]["IT_RATE"]), (object)","), rsIdtl.Rows[j]["IT_AMT"]), (object)","), rsIdtl.Rows[j]["IT_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["IT_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["IT_NET_AMT"]), (object)", "), (object)" "), rsIdtl.Rows[j]["KR_CON_PRC"]), (object)","), rsIdtl.Rows[j]["KR_CON_WT"]), (object)","), rsIdtl.Rows[j]["KR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_LBR_RATE"]), (object)","), rsIdtl.Rows[j]["KR_LBR_AMT"]), (object)","), rsIdtl.Rows[j]["KR_NET_AMT"]), (object)",'"), rsIdtl.Rows[j]["HD_VCH_NO"]), (object)"','"), rsIdtl.Rows[j]["MAIN_USER"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				rsIdtl = null;
				int k = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_ORD_ADJ AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				DataTable dataTable = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable2;
				for (dataTable2 = dataTable; k < dataTable2.Rows.Count; k++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_ORD_ADJ(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,  VCH_TIME,BOOK_NAME,AC_CODE,AC_NAME,ORD_HD_VCH_NO,ORD_NO,ORD_LC,ORD_YRCD,ORD_DBCD,ORD_AC_CODE,ORD_SIGN,ORD_AMT,  ORD_GOLD,ORD_SILVER,PAID_AMT,OLD_VCH_NO,NEW_VCH_NO,DATA_TRFR,HD_VCH_NO,MAIN_USER,ADD_USER,KASAR_AMT,ORD_BAL_AMT,  IT_DESC,EMP_CODE,PAID_AC)   VALUES ('", dataTable2.Rows[k]["CO_CODE"]), (object)"','"), dataTable2.Rows[k]["LC_CODE"]), (object)"','"), dataTable2.Rows[k]["CO_YEAR"]), (object)"','"), dataTable2.Rows[k]["CO_BOOK"]), (object)"','"), dataTable2.Rows[k]["VCH_NO"]), (object)"',"), dataTable2.Rows[k]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[k]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), dataTable2.Rows[k]["VCH_TYPE"]), (object)"','"), dataTable2.Rows[k]["INOUT_TYPE"]), (object)"','"), dataTable2.Rows[k]["ENTRY_TYPE"]), (object)"', "), (object)" '"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[k]["VCH_TIME"]), "MM/dd/yyyy HH: mm : ss")), (object)"','"), dataTable2.Rows[k]["BOOK_NAME"]), (object)"','"), dataTable2.Rows[k]["AC_CODE"]), (object)"','"), dataTable2.Rows[k]["AC_NAME"]), (object)"','"), dataTable2.Rows[k]["ORD_HD_VCH_NO"]), (object)"','"), dataTable2.Rows[k]["ORD_NO"]), (object)"','"), dataTable2.Rows[k]["ORD_LC"]), (object)"','"), dataTable2.Rows[k]["ORD_YRCD"]), (object)"','"), dataTable2.Rows[k]["ORD_DBCD"]), (object)"','"), dataTable2.Rows[k]["ORD_AC_CODE"]), (object)"','"), dataTable2.Rows[k]["ORD_SIGN"]), (object)"',"), dataTable2.Rows[k]["ORD_AMT"]), (object)", "), (object)" "), dataTable2.Rows[k]["ORD_GOLD"]), (object)","), dataTable2.Rows[k]["ORD_SILVER"]), (object)","), dataTable2.Rows[k]["PAID_AMT"]), (object)",'"), dataTable2.Rows[k]["OLD_VCH_NO"]), (object)"','"), dataTable2.Rows[k]["NEW_VCH_NO"]), (object)"','"), dataTable2.Rows[k]["DATA_TRFR"]), (object)"','"), dataTable2.Rows[k]["HD_VCH_NO"]), (object)"','"), dataTable2.Rows[k]["MAIN_USER"]), (object)"','"), dataTable2.Rows[k]["ADD_USER"]), (object)"',"), dataTable2.Rows[k]["KASAR_AMT"]), (object)","), dataTable2.Rows[k]["ORD_BAL_AMT"]), (object)", "), (object)" '"), dataTable2.Rows[k]["IT_DESC"]), (object)"','"), dataTable2.Rows[k]["EMP_CODE"]), (object)"','"), dataTable2.Rows[k]["PAID_AC"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable2 = null;
				int l = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_DETL_RTN AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				DataTable dataTable3 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable4;
				for (dataTable4 = dataTable3; l < dataTable4.Rows.Count; l++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_DETL_RTN(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,VCH_TIME,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,TBL_CODE,DESIGN_NO,ITM_SIZE,ITM_PCS,ITM_GWT,ITM_OTH_WT,  ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,ITM_RATE,ITM_AMT,LBR_TYPE,LBR_PRC,LBR_RATE,LBR_AMT,OTH_AMT,  TAG_LBR_PRC,TAG_LBR_RATE,TAG_LBR_AMT,TAG_OTH_AMT,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,RATE_TYPE,IT_TYPE,HD_VCH_NO,  MAIN_USER,DATA_TRFR,KR_NAME,TAG_COST,ITM_MARGIN,VCH_SRNO,TAG_TYPE,PR_CODE,TAG_SRNO)   VALUES ('", dataTable4.Rows[l]["CO_CODE"]), (object)"','"), dataTable4.Rows[l]["LC_CODE"]), (object)"','"), dataTable4.Rows[l]["CO_YEAR"]), (object)"','"), dataTable4.Rows[l]["CO_BOOK"]), (object)"','"), dataTable4.Rows[l]["VCH_NO"]), (object)"',"), dataTable4.Rows[l]["SR_NO"]), (object)","), dataTable4.Rows[l]["OLD_SRNO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable4.Rows[l]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), dataTable4.Rows[l]["VCH_TYPE"]), (object)"','"), dataTable4.Rows[l]["INOUT_TYPE"]), (object)"', "), (object)" '"), dataTable4.Rows[l]["ENTRY_TYPE"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable4.Rows[l]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), dataTable4.Rows[l]["BOOK_NAME"]), (object)"','"), dataTable4.Rows[l]["AC_CODE"]), (object)"','"), dataTable4.Rows[l]["IT_CODE"]), (object)"','"), dataTable4.Rows[l]["TAG_NO"]), (object)"','"), dataTable4.Rows[l]["TBL_CODE"]), (object)"','"), dataTable4.Rows[l]["DESIGN_NO"]), (object)"','"), dataTable4.Rows[l]["ITM_SIZE"]), (object)"','"), dataTable4.Rows[l]["ITM_PCS"]), (object)"','"), dataTable4.Rows[l]["ITM_GWT"]), (object)"','"), dataTable4.Rows[l]["ITM_OTH_WT"]), (object)"', "), (object)" "), dataTable4.Rows[l]["ITM_NWT"]), (object)","), dataTable4.Rows[l]["ITM_GHT_WT"]), (object)","), dataTable4.Rows[l]["ITM_TOUCH"]), (object)","), dataTable4.Rows[l]["ITM_WEST_PRC"]), (object)","), dataTable4.Rows[l]["ITM_FINE"]), (object)","), dataTable4.Rows[l]["ITM_RATE"]), (object)","), dataTable4.Rows[l]["ITM_AMT"]), (object)",'"), dataTable4.Rows[l]["LBR_TYPE"]), (object)"',"), dataTable4.Rows[l]["LBR_PRC"]), (object)","), dataTable4.Rows[l]["LBR_RATE"]), (object)","), dataTable4.Rows[l]["LBR_AMT"]), (object)","), dataTable4.Rows[l]["OTH_AMT"]), (object)", "), (object)" "), dataTable4.Rows[l]["TAG_LBR_PRC"]), (object)","), dataTable4.Rows[l]["TAG_LBR_RATE"]), (object)","), dataTable4.Rows[l]["TAG_LBR_AMT"]), (object)","), dataTable4.Rows[l]["TAG_OTH_AMT"]), (object)","), dataTable4.Rows[l]["ITM_MRP"]), (object)","), dataTable4.Rows[l]["TOT_AMT"]), (object)","), dataTable4.Rows[l]["TAX_PRC"]), (object)","), dataTable4.Rows[l]["NET_AMT"]), (object)",'"), dataTable4.Rows[l]["RATE_TYPE"]), (object)"','"), dataTable4.Rows[l]["IT_TYPE"]), (object)"','"), dataTable4.Rows[l]["HD_VCH_NO"]), (object)"', "), (object)" '"), dataTable4.Rows[l]["MAIN_USER"]), (object)"','"), dataTable4.Rows[l]["DATA_TRFR"]), (object)"','"), dataTable4.Rows[l]["KR_NAME"]), (object)"',"), dataTable4.Rows[l]["TAG_COST"]), (object)","), dataTable4.Rows[l]["ITM_MARGIN"]), (object)","), dataTable4.Rows[l]["VCH_SRNO"]), (object)",'"), dataTable4.Rows[l]["TAG_TYPE"]), (object)"','"), dataTable4.Rows[l]["PR_CODE"]), (object)"',"), dataTable4.Rows[l]["TAG_SRNO"]), (object)")"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable4 = null;
				int m = 0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM UPI_DATA AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				DataTable dataTable5 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
				DataTable dataTable6;
				for (dataTable6 = dataTable5; m < dataTable6.Rows.Count; m++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO UPI_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TIME,  AC_CODE,UPI_AC_CODE,UPI_AC_NAME,UPI_AMT,MAIN_USER,UPI_ID)   VALUES ('", dataTable6.Rows[m]["CO_CODE"]), (object)"','"), dataTable6.Rows[m]["LC_CODE"]), (object)"','"), dataTable6.Rows[m]["CO_YEAR"]), (object)"','"), dataTable6.Rows[m]["CO_BOOK"]), (object)"','"), dataTable6.Rows[m]["VCH_NO"]), (object)"',"), dataTable6.Rows[m]["SR_NO"]), (object)","), dataTable6.Rows[m]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable6.Rows[m]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable6.Rows[m]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"', "), (object)" '"), dataTable6.Rows[m]["AC_CODE"]), (object)"','"), dataTable6.Rows[m]["UPI_AC_CODE"]), (object)"','"), dataTable6.Rows[m]["UPI_AC_NAME"]), (object)"',"), dataTable6.Rows[m]["UPI_AMT"]), (object)",'"), dataTable6.Rows[m]["MAIN_USER"]), (object)"','"), dataTable6.Rows[m]["UPI_ID"]), (object)"')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				dataTable6 = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DATA SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			if (Operators.CompareString(DC_Main.MCo_year, "2024-2025", false) != 0)
			{
				return;
			}
			DC_Main.RsQry = "SELECT A.CO_YEAR,A.CO_BOOK,A.VCH_NO,UPI_AMT FROM SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.BOOK_TYPE = 'T' AND B.TRFR_BOOK = 'Y' ORDER BY A.VCH_NO DESC";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Sales";
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp2 = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DATA SET UPI_AMT = " + Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["UPI_AMT"])), "0.00") + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), rshlp2.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), rshlp2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp2.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
				rshlp2 = null;
			}
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				ExeQuteCnTr("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND CO_BOOK = '026' ");
			}
			else
			{
				DC_Main.ExeQuteDc("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND CO_BOOK = '026'");
			}
			int num2 = 0;
			DC_Main.RsQry = "SELECT A.* FROM UPI_DATA AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND CO_BOOK = '026' ORDER BY VCH_NO,SR_NO";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Sales";
			Application.DoEvents();
			DataTable rshlp3 = DC_Main.Rshlp;
			while (num2 < rshlp3.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO UPI_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TIME,  AC_CODE,UPI_AC_CODE,UPI_AC_NAME,UPI_AMT,MAIN_USER,UPI_ID)   VALUES ('", rshlp3.Rows[num2]["CO_CODE"]), (object)"','"), rshlp3.Rows[num2]["LC_CODE"]), (object)"','"), rshlp3.Rows[num2]["CO_YEAR"]), (object)"','"), rshlp3.Rows[num2]["CO_BOOK"]), (object)"','"), rshlp3.Rows[num2]["VCH_NO"]), (object)"',"), rshlp3.Rows[num2]["SR_NO"]), (object)","), rshlp3.Rows[num2]["ISR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp3.Rows[num2]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp3.Rows[num2]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"', "), (object)" '"), rshlp3.Rows[num2]["AC_CODE"]), (object)"','"), rshlp3.Rows[num2]["UPI_AC_CODE"]), (object)"','"), rshlp3.Rows[num2]["UPI_AC_NAME"]), (object)"',"), rshlp3.Rows[num2]["UPI_AMT"]), (object)",'"), rshlp3.Rows[num2]["MAIN_USER"]), (object)"','"), rshlp3.Rows[num2]["UPI_ID"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				num2++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			rshlp3 = null;
		}
	}

	private void Ac_AcMast()
	{
		DC_Main.RsQry = "SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Party Master";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			DateTime dateTime = default(DateTime);
			DateTime dateTime2 = default(DateTime);
			DateTime dateTime3 = default(DateTime);
			DateTime dateTime4 = default(DateTime);
			DateTime dateTime5 = default(DateTime);
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["BR_DATE"])))
				{
					dateTime = Conversions.ToDate(rshlp.Rows[DC_Main.M]["BR_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["L_BR_DATE"])))
				{
					dateTime2 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["L_BR_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["AN_DATE"])))
				{
					dateTime3 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["AN_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["LAST_DATE"])))
				{
					dateTime4 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["LAST_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["LAST_VISIT"])))
				{
					dateTime5 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["LAST_VISIT"]);
				}
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO AC_MAST(CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_PERSON,AC_ADD1,AC_ADD2,  AC_ADD3,AC_COUNTRY,AC_STATE,AC_DISTRICT,AC_CITY,AC_AREA,AC_PIN,AC_PHONE,AC_PHONE2,AC_MOBILE,AC_MOBILE2,AC_EMAIL,  AC_GSTNO,AC_GST_TYPE,AC_PANNO,AC_REF_CODE,AC_KHATA_NO,BR_DATE,L_BR_DATE,AN_DATE,AC_CR_DAYS,AC_INT_PRC,DPC_PRC,  BANK_NAME,BANK_AREA,BANK_AC_NO,BANK_RTGS_NO,BANK_DETL,AC_TYPE,LAST_DATE,DATA_TRFR,MAIN_USER,LAST_VISIT,VISIT_TRAN,  APP_TRFR,AC_REF_NAME)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_SHORT"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_MAIN_GR"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_GR"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_PERSON"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_ADD1"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_ADD2"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["AC_ADD3"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_COUNTRY"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_STATE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_DISTRICT"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CITY"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_AREA"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_PIN"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_PHONE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_PHONE2"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_MOBILE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_MOBILE2"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_EMAIL"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["AC_GSTNO"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_GST_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_PANNO"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_REF_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_KHATA_NO"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["BR_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["L_BR_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime2, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["AN_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime3, "MM/dd/yyyy") + "'"))), (object)",");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["AC_CR_DAYS"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["AC_CR_DAYS"] = RuntimeHelpers.GetObjectValue(Value);
				object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["AC_INT_PRC"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["AC_INT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["DPC_PRC"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["DPC_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num3), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AREA"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AC_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_RTGS_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_DETL"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_TYPE"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["LAST_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime4, "MM/dd/yyyy") + "'"))), (object)",'Y','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["LAST_VISIT"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime5, "MM/dd/yyyy") + "'"))), (object)" ,'"), rshlp.Rows[DC_Main.M]["VISIT_TRAN"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["APP_TRFR"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_REF_NAME"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AC_MAST SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Ac_Item()
	{
		DC_Main.RsQry = "SELECT * FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Product Master";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '"), rshlp.Rows[DC_Main.M]["PR_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO PRODUCT_MAST(CO_CODE,PR_CODE,PR_NAME,MAIN_USER,DATA_TRFR)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["PR_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["PR_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','Y')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE PRODUCT_MAST SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '"), rshlp.Rows[DC_Main.M]["PR_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT * FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N'";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Group Master";
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp2 = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE = '"), rshlp2.Rows[DC_Main.M]["GR_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO GROUP_MAST(CO_CODE,GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,  GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_USER,TAX_PRC,AVG_TOUCH,AVG_FINE,AVG_NWT,DAY_OP_PCS,DAY_OP_WT,  DAY_CL_PCS,DAY_CL_WT,RATE_DISPLAY)   VALUES ('", rshlp2.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["GR_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["GR_NAME"]), (object)"','"), rshlp2.Rows[DC_Main.M]["GR_TYPE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["TRAD_TYPE"]), (object)"',"), rshlp2.Rows[DC_Main.M]["GR_TOUCH"]), (object)","), rshlp2.Rows[DC_Main.M]["GR_PURC_TOUCH"]), (object)","), rshlp2.Rows[DC_Main.M]["MELTING_PRC"]), (object)", "), (object)" "), rshlp2.Rows[DC_Main.M]["GR_RATE"]), (object)","), rshlp2.Rows[DC_Main.M]["WEST_PRC"]), (object)",'"), rshlp2.Rows[DC_Main.M]["SALE_AC"]), (object)"','"), rshlp2.Rows[DC_Main.M]["PURC_AC"]), (object)"','"), rshlp2.Rows[DC_Main.M]["HSN_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.M]["MAIN_USER"]), (object)"',"), rshlp2.Rows[DC_Main.M]["TAX_PRC"]), (object)","), rshlp2.Rows[DC_Main.M]["AVG_TOUCH"]), (object)","), rshlp2.Rows[DC_Main.M]["AVG_FINE"]), (object)","), rshlp2.Rows[DC_Main.M]["AVG_NWT"]), (object)",0,0, "), (object)" 0,0,'"), rshlp2.Rows[DC_Main.M]["RATE_DISPLAY"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE GROUP_MAST SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE = '"), rshlp2.Rows[DC_Main.M]["GR_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp2 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT * FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N'";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Table Master";
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp3 = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TABLE_CODE = '"), rshlp3.Rows[DC_Main.M]["TABLE_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO TABLE_MAST(CO_CODE,LC_CODE,TABLE_CODE,TABLE_NAME,MAIN_USER)   VALUES ('", rshlp3.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["TABLE_CODE"]), (object)"','"), rshlp3.Rows[DC_Main.M]["TABLE_NAME"]), (object)"','"), rshlp3.Rows[DC_Main.M]["MAIN_USER"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE TABLE_MAST SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TABLE_CODE = '"), rshlp3.Rows[DC_Main.M]["TABLE_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp3 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT * FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DATA_TRFR = 'N'";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Item Master";
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp4 = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '"), rshlp4.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO ITEM_MAST(CO_CODE,IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,  RATE_TYPE,HSN_CODE,ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,MIN_STK,MAIN_USER,  AVG_TOUCH,AVG_FINE,AVG_NWT,AC_ITEM,STK_DISPLAY,OTH_RATE,AVG_RATE,SAFE_NAME)   VALUES ('", rshlp4.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["IT_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["IT_NAME"]), (object)"','"), rshlp4.Rows[DC_Main.M]["IT_TYPE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["TAG_TYPE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["PR_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["GR_CODE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["TRAD_TYPE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["UNIT_NAME"]), (object)"', "), (object)" '"), rshlp4.Rows[DC_Main.M]["RATE_TYPE"]), (object)"','"), rshlp4.Rows[DC_Main.M]["HSN_CODE"]), (object)"',"), rshlp4.Rows[DC_Main.M]["ITEM_RATE"]), (object)","), rshlp4.Rows[DC_Main.M]["LBR_PRC"]), (object)","), rshlp4.Rows[DC_Main.M]["CON_PRC"]), (object)","), rshlp4.Rows[DC_Main.M]["DISC_PRC"]), (object)","), rshlp4.Rows[DC_Main.M]["IT_TOUCH"]), (object)","), rshlp4.Rows[DC_Main.M]["IT_WEST"]), (object)","), rshlp4.Rows[DC_Main.M]["OTHER_RATE"]), (object)","), rshlp4.Rows[DC_Main.M]["MIN_STK"]), (object)",'"), rshlp4.Rows[DC_Main.M]["MAIN_USER"]), (object)"', "), (object)" "), rshlp4.Rows[DC_Main.M]["AVG_TOUCH"]), (object)","), rshlp4.Rows[DC_Main.M]["AVG_FINE"]), (object)","), rshlp4.Rows[DC_Main.M]["AVG_NWT"]), (object)",'"), rshlp4.Rows[DC_Main.M]["AC_ITEM"]), (object)"','"), rshlp4.Rows[DC_Main.M]["STK_DISPLAY"]), (object)"',"), rshlp4.Rows[DC_Main.M]["OTH_RATE"]), (object)","), rshlp4.Rows[DC_Main.M]["AVG_RATE"]), (object)",'"), rshlp4.Rows[DC_Main.M]["SAFE_NAME"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET DATA_TRFR = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '"), rshlp4.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp4 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void btnTrfrUpdate_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_13cb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To All Data ReTransfer.... ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.ExeQuteDc("UPDATE AC_MAST SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE CASH_DATA SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE CONTRA_DATA SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE GROUP_MAST SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE ITEM_MAST SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE ITM_OPBL SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE KR_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE LBR_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE PAY_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE OP_DATA SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE PR_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE PRODUCT_MAST SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE RATE_CUT_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE RATE_CUT_ISU SET HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE RATE_CUT_REC SET HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE REP_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE SL_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE SL_ORD_ADJ SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE SL_ORD_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE TABLE_MAST SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE BAR_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE BAR_DETL SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE BAR_CAN_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE CASH_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE CARD_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE CONTRA_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("DELETE FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM PR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM KR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM KR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM KR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM LBR_ISU_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM LBR_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM SL_DETL_RTN WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM BAR_CAN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM CASH_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				ExeQuteCnTr("DELETE FROM CONTRA_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
			}
			else
			{
				ExeQuteCnTr("UPDATE AC_MAST SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE BOOK_DATA SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE CASH_DATA SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE CONTRA_DATA SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE GROUP_MAST SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE ITEM_MAST SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE ITM_OPBL SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE KR_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE LBR_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE PAY_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE OP_DATA SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE PR_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE PRODUCT_MAST SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE RATE_CUT_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE RATE_CUT_ISU SET HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE RATE_CUT_REC SET HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE REP_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE SL_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE SL_ORD_ADJ SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE SL_ORD_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE TABLE_MAST SET DATA_TRFR = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE BAR_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE BAR_DETL SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE BAR_CAN_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE CASH_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE CARD_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				ExeQuteCnTr("UPDATE CONTRA_DATA SET DATA_TRFR = 'N',HD_VCH_NO = VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM PR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM KR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM KR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM KR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM LBR_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_DETL_RTN WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM CASH_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.ExeQuteDc("DELETE FROM CONTRA_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
			}
		}
		Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
	}

	private void Sale_Reset()
	{
		DC_Main.RsQry = "SELECT A.* FROM SL_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.DATA_TRFR = 'Y' AND B.BOOK_TYPE IN ('M','F') AND B.RESET_BOOK = 'Y'  ORDER BY CO_BOOK,VCH_DATE,VCH_NO";
		DataTable dataTable = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
		if (dataTable.Rows.Count > 0)
		{
			lblBook.Text = "Estimate Sales Reset";
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = dataTable.Rows.Count;
		}
		DC_Main.M = 0;
		checked
		{
			int num = default(int);
			while (DC_Main.M < dataTable.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				for (int i = 0; i < DC_Main.Rshlp.Rows.Count; i++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.STK_IT_CODE FROM BAR_DETL AS A LEFT JOIN BAR_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO WHERE A.CO_CODE =  '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[i]["TAG_NO"]), (object)"' AND A.VCH_SRNO = "), DC_Main.Rshlp.Rows[i]["VCH_SRNO"]), (object)" "));
					DataTable dataTable2 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
					DataTable dataTable3;
					if (dataTable2.Rows.Count > 0)
					{
						if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(dataTable2.Rows[0]["STK_IT_CODE"], (object)""), (object)"", false))
						{
							DC_Main.RsQry = "SELECT * FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '163' AND VCH_DATE = '" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "' ";
							dataTable3 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
							if (dataTable3.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT MAX((VCH_NO)) AS CoCode  From BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '163' HAVING MAX((VCH_NO)) > 0";
								DataTable dataTable4 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
								string text = ((dataTable4.Rows.Count != 0) ? Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable4.Rows[0]["CoCode"], (object)"")) + 1.0), "00000") : "00001");
								if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
								{
									DC_Main.ExeQuteDc("INSERT INTO BAR_CAN_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,HD_VCH_NO) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "', '" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + text + "')");
									DC_Main.ExeQuteDc("INSERT INTO TEMP_BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,BOOK_NAME) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','163','" + text + "','Stock Adjust1')");
									DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_CAN_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,IT_CODE,ITM_REMARK,ITM_PCS,ITM_GWT,ITM_NWT,ITM_SIGN,TAG_NO,  BAG_WT,ITM_OTH_WT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "', 1,'" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','"), dataTable2.Rows[0]["STK_IT_CODE"]), (object)"','ORNAMENTS', "), (object)" "), dataTable2.Rows[0]["ITM_PCS"]), (object)","), dataTable2.Rows[0]["ITM_GWT"]), (object)","), dataTable2.Rows[0]["ITM_NWT"]), (object)",'-','N', "), (object)" 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)")));
								}
								else
								{
									ExeQuteCnTr("INSERT INTO BAR_CAN_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,HD_VCH_NO) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "', '" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + text + "')");
									ExeQuteCnTr("INSERT INTO TEMP_BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,BOOK_NAME) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','163','" + text + "','Stock Adjust1')");
									ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_CAN_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,IT_CODE,ITM_REMARK,ITM_PCS,ITM_GWT,ITM_NWT,ITM_SIGN,TAG_NO,  BAG_WT,ITM_OTH_WT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "', 1,'" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','"), dataTable2.Rows[0]["STK_IT_CODE"]), (object)"','ORNAMENTS', "), (object)" "), dataTable2.Rows[0]["ITM_PCS"]), (object)","), dataTable2.Rows[0]["ITM_GWT"]), (object)","), dataTable2.Rows[0]["ITM_NWT"]), (object)",'-','N', "), (object)" 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)")));
								}
							}
							else
							{
								string text = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["VCH_NO"], (object)"")), "00000");
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SR_NO AS CoCode  From BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '163' AND VCH_NO = '"), dataTable3.Rows[0]["VCH_NO"]), (object)"' ORDER BY SR_NO DESC"));
								DataTable dataTable4 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
								if (dataTable4.Rows.Count > 0)
								{
									num = (int)Math.Round(Conversion.Val(Operators.ConcatenateObject(dataTable4.Rows[0]["CoCode"], (object)"")) + 1.0);
								}
								if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
								{
									DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_CAN_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,IT_CODE,ITM_REMARK,ITM_PCS,ITM_GWT,ITM_NWT,ITM_SIGN,TAG_NO,  BAG_WT,ITM_OTH_WT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "', " + Conversions.ToString(num) + ",'" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','"), dataTable2.Rows[0]["STK_IT_CODE"]), (object)"','ORNAMENTS', "), (object)" "), dataTable2.Rows[0]["ITM_PCS"]), (object)","), dataTable2.Rows[0]["ITM_GWT"]), (object)","), dataTable2.Rows[0]["ITM_NWT"]), (object)",'-','N', "), (object)" 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)")));
								}
								else
								{
									ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_CAN_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,IT_CODE,ITM_REMARK,ITM_PCS,ITM_GWT,ITM_NWT,ITM_SIGN,TAG_NO,  BAG_WT,ITM_OTH_WT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "', " + Conversions.ToString(num) + ",'" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','"), dataTable2.Rows[0]["STK_IT_CODE"]), (object)"','ORNAMENTS', "), (object)" "), dataTable2.Rows[0]["ITM_PCS"]), (object)","), dataTable2.Rows[0]["ITM_GWT"]), (object)","), dataTable2.Rows[0]["ITM_NWT"]), (object)",'-','N', "), (object)" 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)")));
								}
							}
						}
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable2.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[0]["VCH_NO"]), (object)"' AND TAG_NO = '"), dataTable2.Rows[0]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable2.Rows[0]["VCH_SRNO"]), (object)" ")));
							DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable2.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[0]["VCH_NO"]), (object)"' AND TAG_NO = '"), dataTable2.Rows[0]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable2.Rows[0]["VCH_SRNO"]), (object)" ")));
							DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable2.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[0]["VCH_NO"]), (object)"' AND TAG_NO = '"), dataTable2.Rows[0]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable2.Rows[0]["VCH_SRNO"]), (object)" ")));
						}
						else
						{
							ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable2.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[0]["VCH_NO"]), (object)"' AND TAG_NO = '"), dataTable2.Rows[0]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable2.Rows[0]["VCH_SRNO"]), (object)" ")));
							ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable2.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[0]["VCH_NO"]), (object)"' AND TAG_NO = '"), dataTable2.Rows[0]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable2.Rows[0]["VCH_SRNO"]), (object)" ")));
							ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable2.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[0]["VCH_NO"]), (object)"' AND TAG_NO = '"), dataTable2.Rows[0]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable2.Rows[0]["VCH_SRNO"]), (object)" ")));
						}
						continue;
					}
					DC_Main.RsQry = "SELECT * FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '163' AND VCH_DATE = '" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "' ";
					dataTable3 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
					if (dataTable3.Rows.Count == 0)
					{
						DC_Main.RsQry = "SELECT MAX((VCH_NO)) AS CoCode  From BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '163' HAVING MAX((VCH_NO)) > 0";
						DataTable dataTable4 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
						string text = ((dataTable4.Rows.Count != 0) ? Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable4.Rows[0]["CoCode"], (object)"")) + 1.0), "00000") : "00001");
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							DC_Main.ExeQuteDc("INSERT INTO BAR_CAN_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,HD_VCH_NO) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "', '" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + text + "')");
							DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '163' AND VCH_NO = '" + text + "' ");
							DC_Main.ExeQuteDc("INSERT INTO TEMP_BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,BOOK_NAME) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','163','" + text + "','Stock Adjust1')");
							DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_CAN_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,IT_CODE,ITM_REMARK,ITM_PCS,ITM_GWT,ITM_NWT,ITM_SIGN,TAG_NO,  BAG_WT,ITM_OTH_WT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "', 1,'" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','"), DC_Main.Rshlp.Rows[i]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[i]["ITM_REMARK"]), (object)"', "), (object)" "), DC_Main.Rshlp.Rows[i]["ITM_PCS"]), (object)","), DC_Main.Rshlp.Rows[i]["ITM_GWT"]), (object)","), DC_Main.Rshlp.Rows[i]["ITM_NWT"]), (object)",'-','N', "), (object)" 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)")));
						}
						else
						{
							ExeQuteCnTr("INSERT INTO BAR_CAN_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,HD_VCH_NO) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "', '" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + text + "')");
							ExeQuteCnTr("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '163' AND VCH_NO = '" + text + "' ");
							ExeQuteCnTr("INSERT INTO TEMP_BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,BOOK_NAME) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','163','" + text + "','Stock Adjust1')");
							ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_CAN_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,IT_CODE,ITM_REMARK,ITM_PCS,ITM_GWT,ITM_NWT,ITM_SIGN,TAG_NO,  BAG_WT,ITM_OTH_WT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "', 1,'" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','"), DC_Main.Rshlp.Rows[i]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[i]["ITM_REMARK"]), (object)"', "), (object)" "), DC_Main.Rshlp.Rows[i]["ITM_PCS"]), (object)","), DC_Main.Rshlp.Rows[i]["ITM_GWT"]), (object)","), DC_Main.Rshlp.Rows[i]["ITM_NWT"]), (object)",'-','N', "), (object)" 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)")));
						}
					}
					else
					{
						string text = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["VCH_NO"], (object)"")), "00000");
						DC_Main.RsQry = "SELECT SR_NO AS CoCode  From BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '163' AND VCH_NO = '" + text + "' ORDER BY SR_NO DESC";
						DataTable dataTable4 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
						if (dataTable4.Rows.Count > 0)
						{
							num = (int)Math.Round(Conversion.Val(Operators.ConcatenateObject(dataTable4.Rows[0]["CoCode"], (object)"")) + 1.0);
						}
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_CAN_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,IT_CODE,ITM_REMARK,ITM_PCS,ITM_GWT,ITM_NWT,ITM_SIGN,TAG_NO,  BAG_WT,ITM_OTH_WT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "'," + Conversions.ToString(num) + ",'" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','"), DC_Main.Rshlp.Rows[i]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[i]["ITM_REMARK"]), (object)"', "), (object)" "), DC_Main.Rshlp.Rows[i]["ITM_PCS"]), (object)","), DC_Main.Rshlp.Rows[i]["ITM_GWT"]), (object)","), DC_Main.Rshlp.Rows[i]["ITM_NWT"]), (object)",'-','N', "), (object)" 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)")));
						}
						else
						{
							ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_CAN_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,IT_CODE,ITM_REMARK,ITM_PCS,ITM_GWT,ITM_NWT,ITM_SIGN,TAG_NO,  BAG_WT,ITM_OTH_WT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "'," + Conversions.ToString(num) + ",'" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','"), DC_Main.Rshlp.Rows[i]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[i]["ITM_REMARK"]), (object)"', "), (object)" "), DC_Main.Rshlp.Rows[i]["ITM_PCS"]), (object)","), DC_Main.Rshlp.Rows[i]["ITM_GWT"]), (object)","), DC_Main.Rshlp.Rows[i]["ITM_NWT"]), (object)",'-','N', "), (object)" 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0)")));
						}
					}
				}
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM FINE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
				}
				else
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM FINE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
				}
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void TagCancel_Reset()
	{
		DC_Main.ExeQuteDc("UPDATE BAR_DATA SET STK_IT_CODE = '' WHERE STK_IT_CODE IS NULL");
		DC_Main.RsQry = "SELECT A.* FROM BAR_CAN_DATA AS A INNER JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.DATA_TRFR = 'Y' AND B.RESET_BOOK = 'Y' AND A.CO_BOOK <> '163'  ORDER BY A.CO_BOOK,VCH_DATE,VCH_NO";
		DataTable dataTable = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
		if (dataTable.Rows.Count > 0)
		{
			lblBook.Text = "Tag Cancel Reset";
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = dataTable.Rows.Count;
		}
		DC_Main.M = 0;
		checked
		{
			int num = default(int);
			while (DC_Main.M < dataTable.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				for (int i = 0; i < DC_Main.Rshlp.Rows.Count; i++)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.STK_IT_CODE FROM BAR_DETL AS A LEFT JOIN BAR_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO WHERE A.CO_CODE =  '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[i]["TAG_NO"]), (object)"' AND A.VCH_SRNO = "), DC_Main.Rshlp.Rows[i]["VCH_SRNO"]), (object)" "));
					DataTable dataTable2 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
					if (dataTable2.Rows.Count <= 0)
					{
						continue;
					}
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(dataTable2.Rows[0]["STK_IT_CODE"], (object)""), (object)"", false))
					{
						DC_Main.RsQry = "SELECT * FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '163' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "' ";
						DataTable dataTable3 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
						if (dataTable3.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT MAX((VCH_NO)) AS CoCode  From BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '163' HAVING MAX((VCH_NO)) > 0";
							DataTable dataTable4 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
							string text = ((dataTable4.Rows.Count != 0) ? Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable4.Rows[0]["CoCode"])) + 1.0), "00000") : "00001");
							if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
							{
								DC_Main.ExeQuteDc("INSERT INTO BAR_CAN_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,HD_VCH_NO) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "', '" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + text + "')");
								DC_Main.ExeQuteDc("INSERT INTO TEMP_BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,BOOK_NAME) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','163','" + text + "','Stock Adjust1')");
								DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_CAN_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,IT_CODE,ITM_PCS,ITM_GWT,TAG_NWT,ITM_NWT,ITM_SIGN) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "', 1,'" + Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["VCH_DATE"]), "MM/dd/yyyy") + "','"), dataTable2.Rows[0]["STK_IT_CODE"]), (object)"', "), (object)" "), dataTable2.Rows[0]["ITM_PCS"]), (object)","), dataTable2.Rows[0]["ITM_GWT"]), (object)","), dataTable2.Rows[0]["ITM_NWT"]), (object)","), dataTable2.Rows[0]["ITM_NWT"]), (object)",'-')")));
							}
							else
							{
								ExeQuteCnTr("INSERT INTO BAR_CAN_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,HD_VCH_NO) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "', '" + Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[i]["VCH_DATE"]), "MM/dd/yyyy") + "','" + text + "')");
								ExeQuteCnTr("INSERT INTO TEMP_BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,BOOK_NAME) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','163','" + text + "','Stock Adjust1')");
								ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_CAN_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,IT_CODE,IT_DESC,ITM_PCS,ITM_GWT,TAG_NWT,ITM_NWT,ITM_SIGN) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "', 1,'" + Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["VCH_DATE"]), "MM/dd/yyyy") + "','"), dataTable2.Rows[0]["STK_IT_CODE"]), (object)"','ORNAMENTS', "), (object)" "), dataTable2.Rows[0]["ITM_PCS"]), (object)","), dataTable2.Rows[0]["ITM_GWT"]), (object)","), dataTable2.Rows[0]["ITM_NWT"]), (object)","), dataTable2.Rows[0]["ITM_NWT"]), (object)",'-')")));
							}
						}
						else
						{
							string text = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["VCH_NO"], (object)"")), "00000");
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SR_NO AS CoCode  From BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '163' AND VCH_NO = '"), dataTable3.Rows[0]["VCH_NO"]), (object)"' ORDER BY SR_NO DESC"));
							DataTable dataTable4 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? OpenRecordsetTrfr(DC_Main.RsQry) : DC_Main.OpenRecordSetDc(DC_Main.RsQry));
							if (dataTable4.Rows.Count > 0)
							{
								num = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable4.Rows[0]["CoCode"])) + 1.0);
							}
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_CAN_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,IT_CODE,ITM_REMARK,ITM_PCS,ITM_GWT,ITM_NWT,ITM_SIGN) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','163','" + text + "', " + Conversions.ToString(num) + ",'" + Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["VCH_DATE"]), "MM/dd/yyyy") + "','"), dataTable2.Rows[0]["STK_IT_CODE"]), (object)"','ORNMENTS', "), (object)" "), dataTable2.Rows[0]["ITM_PCS"]), (object)","), dataTable2.Rows[0]["ITM_GWT"]), (object)","), dataTable2.Rows[0]["ITM_NWT"]), (object)",'-')"));
							if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
							{
								DC_Main.ExeQuteDc(DC_Main.RsQry);
							}
							else
							{
								ExeQuteCnTr(DC_Main.RsQry);
							}
						}
					}
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable2.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[0]["VCH_NO"]), (object)"' AND TAG_NO = '"), dataTable2.Rows[0]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable2.Rows[0]["VCH_SRNO"]), (object)" ")));
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable2.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[0]["VCH_NO"]), (object)"' AND TAG_NO = '"), dataTable2.Rows[0]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable2.Rows[0]["VCH_SRNO"]), (object)" ")));
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable2.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[0]["VCH_NO"]), (object)"' AND TAG_NO = '"), dataTable2.Rows[0]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable2.Rows[0]["VCH_SRNO"]), (object)" ")));
					}
					else
					{
						ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable2.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[0]["VCH_NO"]), (object)"' AND TAG_NO = '"), dataTable2.Rows[0]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable2.Rows[0]["VCH_SRNO"]), (object)" ")));
						ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable2.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[0]["VCH_NO"]), (object)"' AND TAG_NO = '"), dataTable2.Rows[0]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable2.Rows[0]["VCH_SRNO"]), (object)" ")));
						ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable2.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable2.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[0]["VCH_NO"]), (object)"' AND TAG_NO = '"), dataTable2.Rows[0]["TAG_NO"]), (object)"' AND VCH_SRNO = "), dataTable2.Rows[0]["VCH_SRNO"]), (object)" ")));
					}
				}
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
				}
				else
				{
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
					ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_CAN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK  = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
				}
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void btnReSetData_Click(object sender, EventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Invalid comparison between Unknown and I4
		//IL_29e7: Unknown result type (might be due to invalid IL or missing references)
		lblBook.Text = "Retail Software Export";
		((Control)ProgressBar1).Visible = true;
		if ((int)Interaction.MsgBox((object)"Are You Sure To A Data Reset.... ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		if (Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) != 0)
		{
			Sale_Reset();
			TagCancel_Reset();
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = 12;
		checked
		{
			ProgressBar progressBar;
			if (Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0)
			{
				lblBook.Text = "Sales And Sales Returne";
				Application.DoEvents();
				DC_Main.RsQry = "DELETE AC_DATA FROM (AC_DATA AS B INNER JOIN SL_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE ROJ_MEL_DATA FROM (ROJ_MEL_DATA As B INNER JOIN SL_DATA As A On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_YEAR = B.CO_YEAR And A.CO_BOOK = B.CO_BOOK And A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA As C On A.CO_CODE = C.CO_CODE And A.LC_CODE = C.LC_CODE And A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE TAX_DATA FROM (TAX_DATA AS B INNER JOIN SL_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE MAIN_STOCK FROM (MAIN_STOCK AS B INNER JOIN SL_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE SL_IDTL FROM (SL_IDTL AS B INNER JOIN SL_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE SL_PR_DETL FROM (SL_PR_DETL AS B INNER JOIN SL_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE SL_ORD_ADJ FROM (SL_ORD_ADJ AS B INNER JOIN SL_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE UPI_DATA FROM (UPI_DATA AS B INNER JOIN SL_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE BILL_OS_DATA FROM (BILL_OS_DATA AS B INNER JOIN SL_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE SL_DETL_RTN FROM (SL_DETL_RTN AS B INNER JOIN SL_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE SL_DETL FROM (SL_DETL AS B INNER JOIN SL_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE SL_DATA FROM SL_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				lblBook.Text = "Wh Sales And Rate Cut";
				Application.DoEvents();
				DC_Main.RsQry = "DELETE AC_DATA FROM (AC_DATA AS B INNER JOIN RATE_CUT_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE ROJ_MEL_DATA FROM (ROJ_MEL_DATA As B INNER JOIN RATE_CUT_DATA As A On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_YEAR = B.CO_YEAR And A.CO_BOOK = B.CO_BOOK And A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA As C On A.CO_CODE = C.CO_CODE And A.LC_CODE = C.LC_CODE And A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE TAX_DATA FROM (TAX_DATA AS B INNER JOIN RATE_CUT_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE MAIN_STOCK FROM (MAIN_STOCK AS B INNER JOIN RATE_CUT_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE SL_IDTL FROM (SL_IDTL AS B INNER JOIN RATE_CUT_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE RATE_CUT_ISU FROM (RATE_CUT_ISU AS B INNER JOIN RATE_CUT_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE RATE_CUT_REC FROM (RATE_CUT_REC AS B INNER JOIN RATE_CUT_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE RATE_CUT_DATA FROM RATE_CUT_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				lblBook.Text = "Bar Data";
				Application.DoEvents();
				DC_Main.RsQry = "DELETE MAIN_STOCK FROM (MAIN_STOCK AS B INNER JOIN BAR_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE BAR_IDTL FROM (BAR_IDTL AS B INNER JOIN BAR_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE BAR_DETL FROM (BAR_DETL AS B INNER JOIN BAR_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE BAR_DATA FROM BAR_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				lblBook.Text = "Bar Cancel Data";
				Application.DoEvents();
				DC_Main.RsQry = "DELETE MAIN_STOCK FROM (MAIN_STOCK AS B INNER JOIN BAR_CAN_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE BAR_CAN_IDTL FROM (BAR_CAN_IDTL AS B INNER JOIN BAR_CAN_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE BAR_CAN_DETL FROM (BAR_CAN_DETL AS B INNER JOIN BAR_CAN_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE BAR_CAN_DATA FROM BAR_CAN_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
			}
			else
			{
				ProgressBar1.Value = 3;
			}
			(progressBar = ProgressBar1).Value = progressBar.Value + 1;
			lblBook.Text = "Cash And Bank";
			Application.DoEvents();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE AC_DATA FROM (AC_DATA AS B INNER JOIN CASH_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE ROJ_MEL_DATA FROM (ROJ_MEL_DATA As B INNER JOIN CASH_DATA As A On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_YEAR = B.CO_YEAR And A.CO_BOOK = B.CO_BOOK And A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA As C On A.CO_CODE = C.CO_CODE And A.LC_CODE = C.LC_CODE And A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE CASH_DATA FROM CASH_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			(progressBar = ProgressBar1).Value = progressBar.Value + 1;
			lblBook.Text = "Purechase and Purchase return";
			Application.DoEvents();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE AC_DATA FROM (AC_DATA AS B INNER JOIN PR_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE ROJ_MEL_DATA FROM (ROJ_MEL_DATA As B INNER JOIN PR_DATA As A On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_YEAR = B.CO_YEAR And A.CO_BOOK = B.CO_BOOK And A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA As C On A.CO_CODE = C.CO_CODE And A.LC_CODE = C.LC_CODE And A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE TAX_DATA FROM (TAX_DATA AS B INNER JOIN PR_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE MAIN_STOCK FROM (MAIN_STOCK AS B INNER JOIN PR_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE PR_IDTL FROM (PR_IDTL AS B INNER JOIN PR_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE PR_DETL FROM (PR_DETL AS B INNER JOIN PR_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = "DELETE PR_DATA FROM PR_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			(progressBar = ProgressBar1).Value = progressBar.Value + 1;
			lblBook.Text = "Karigar isu And Karigar Rec";
			Application.DoEvents();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE AC_DATA FROM (AC_DATA AS B INNER JOIN KR_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE ROJ_MEL_DATA FROM (ROJ_MEL_DATA As B INNER JOIN KR_DATA As A On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_YEAR = B.CO_YEAR And A.CO_BOOK = B.CO_BOOK And A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA As C On A.CO_CODE = C.CO_CODE And A.LC_CODE = C.LC_CODE And A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE TAX_DATA FROM (TAX_DATA AS B INNER JOIN KR_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE MAIN_STOCK FROM (MAIN_STOCK AS B INNER JOIN KR_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE KR_IDTL FROM (KR_IDTL AS B INNER JOIN KR_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE KR_DETL FROM (KR_DETL AS B INNER JOIN KR_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = "DELETE KR_DATA FROM KR_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			(progressBar = ProgressBar1).Value = progressBar.Value + 1;
			lblBook.Text = "Contra";
			Application.DoEvents();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE AC_DATA FROM (AC_DATA AS B INNER JOIN CONTRA_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE ROJ_MEL_DATA FROM (ROJ_MEL_DATA As B INNER JOIN CONTRA_DATA As A On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_YEAR = B.CO_YEAR And A.CO_BOOK = B.CO_BOOK And A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA As C On A.CO_CODE = C.CO_CODE And A.LC_CODE = C.LC_CODE And A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE CONTRA_DATA FROM CONTRA_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			(progressBar = ProgressBar1).Value = progressBar.Value + 1;
			lblBook.Text = "OpData";
			Application.DoEvents();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE AC_DATA FROM AC_DATA AS B INNER JOIN OP_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND A.DATA_TYPE  = 'B'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND DATA_TRFR = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND DATA_TYPE  = 'B'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			(progressBar = ProgressBar1).Value = progressBar.Value + 1;
			lblBook.Text = "Itm Opbl";
			Application.DoEvents();
			if (Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0)
			{
				DC_Main.RsQry = "DELETE MAIN_STOCK FROM MAIN_STOCK AS B INNER JOIN ITM_OPBL AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE FROM ITM_OPBL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND DATA_TRFR = 'Y'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
			}
			(progressBar = ProgressBar1).Value = progressBar.Value + 1;
			lblBook.Text = "Reparing Reset";
			Application.DoEvents();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE AC_DATA FROM (AC_DATA AS B INNER JOIN REP_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE ROJ_MEL_DATA FROM (ROJ_MEL_DATA As B INNER JOIN REP_DATA As A On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_YEAR = B.CO_YEAR And A.CO_BOOK = B.CO_BOOK And A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA As C On A.CO_CODE = C.CO_CODE And A.LC_CODE = C.LC_CODE And A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE TAX_DATA FROM (TAX_DATA AS B INNER JOIN REP_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE MAIN_STOCK FROM (MAIN_STOCK AS B INNER JOIN REP_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE REP_DETL FROM (REP_DETL AS B INNER JOIN REP_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = "DELETE REP_DATA FROM REP_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			(progressBar = ProgressBar1).Value = progressBar.Value + 1;
			lblBook.Text = "Order Reset";
			Application.DoEvents();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE AC_DATA FROM (AC_DATA AS B INNER JOIN SL_ORD_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE ROJ_MEL_DATA FROM (ROJ_MEL_DATA As B INNER JOIN SL_ORD_DATA As A On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_YEAR = B.CO_YEAR And A.CO_BOOK = B.CO_BOOK And A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA As C On A.CO_CODE = C.CO_CODE And A.LC_CODE = C.LC_CODE And A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE TAX_DATA FROM (TAX_DATA AS B INNER JOIN SL_ORD_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE MAIN_STOCK FROM (MAIN_STOCK AS B INNER JOIN SL_ORD_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = "DELETE SL_ORD_IDTL FROM (SL_ORD_IDTL AS B INNER JOIN SL_ORD_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = "DELETE SL_PR_DETL FROM (SL_PR_DETL AS B INNER JOIN SL_ORD_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = "DELETE SL_ORD_ADJ FROM (SL_ORD_ADJ AS B INNER JOIN SL_ORD_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = "DELETE UPI_DATA FROM (UPI_DATA AS B INNER JOIN SL_ORD_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE SL_ORD_DETL FROM (SL_ORD_DETL AS B INNER JOIN SL_ORD_DATA AS A ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y' "), Interaction.IIf(Operators.CompareString(DC_Main.MsOpblTrfrBtn, "Y", false) == 0, (object)"", (object)"AND C.BOOK_TYPE <> 'T'")), (object)" "));
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = "DELETE SL_ORD_DATA FROM SL_ORD_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DATA_TRFR = 'Y' AND C.RESET_BOOK = 'Y'";
			if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
			ProgressBar1.Value = 0;
		}
	}

	private void btnOpbl_Click(object sender, EventArgs e)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Invalid comparison between Unknown and I4
		//IL_0596: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		lblBook.Text = "Whsale Software Export";
		((Control)ProgressBar1).Visible = true;
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK056NEVK", false) == 0)
		{
			if ((int)Interaction.MsgBox((object)"Are You Sure To Cash Balance Transfer to CoType = A.... ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
			{
				DC_Main.RsQry = "DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND DATA_TYPE = 'B' AND AC_CODE = '00001'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND VCH_NO = '00000' AND DATA_TYPE = 'B' AND AC_CODE = '00001'";
				if (Operators.CompareString(DC_Main.MsIpWith, "B", false) == 0)
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.RsQry = "Select A.AC_CODE,format(Sum(A.CR_AMT-A.DR_AMT),'0.00') as Amount FROM AC_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' and VCH_DATE <= '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "'  AND A.AC_CODE = '00001'   GROUP BY A.AC_CODE ORDER BY A.AC_CODE ";
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					DC_Main.Tbl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				DC_Main.RsQry = "Select A.AC_CODE,format(Sum(A.CR_AMT-A.DR_AMT),'0.00') as Amount FROM AC_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' and VCH_DATE <= '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "' AND A.AC_CODE = '00001'   GROUP BY A.AC_CODE ORDER BY A.AC_CODE ";
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				else
				{
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				double num = 0.0;
				double num2 = 0.0;
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					num = ((!Operators.ConditionalCompareObjectLess(DC_Main.Tbl.Rows[0]["Amount"], (object)0, false)) ? Conversions.ToDouble(Operators.NegateObject(DC_Main.Tbl.Rows[0]["Amount"])) : Conversions.ToDouble(Operators.NegateObject(DC_Main.Tbl.Rows[0]["Amount"])));
				}
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					num2 = ((!Operators.ConditionalCompareObjectLess(DC_Main.Rshlp.Rows[0]["Amount"], (object)0, false)) ? Conversions.ToDouble(Operators.NegateObject(DC_Main.Rshlp.Rows[0]["Amount"])) : Conversions.ToDouble(Operators.NegateObject(DC_Main.Rshlp.Rows[0]["Amount"])));
				}
				double num3 = default(double);
				if (num2 > num)
				{
					num3 = num2 - num;
				}
				if (num2 < num)
				{
					num3 = num2 - num;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO OP_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,  OP_AMT,OP_SIGN,FINE_BAL,FINE_SIGN,SL_FINE_BAL,SL_FINE_SIGN,  DATA_TYPE,MAIN_USER,ADD_USER,ADD_DATE,DATA_TRFR) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','00000','00001',  " + Conversions.ToString(Math.Abs(num3)) + ","), Interaction.IIf(num3 > 0.0, (object)"'D'", (object)"'C'")), (object)",0,'',0,'C', "), (object)" 'B','"), (object)DC_Main.MCo_User), (object)"','',NULL,'Y')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
			}
		}
		else if (Operators.CompareString(DC_Main.SSRegSrNo, "VS136NSBU", false) == 0)
		{
			Pluse_OpblImport();
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Opning Balance Transfer to CoType = A.... ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			BtoA_TmpBookData();
			BtoA_Balance();
			BtoA_ItmStk();
			BtoA_Order();
			DC_Main.RsQry = "SELECT TOP 5 * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Tbl = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				Interaction.MsgBox((object)"Please Reset A Type Stock First Then Tag Stock Transfer....", (MsgBoxStyle)64, (object)null);
			}
			else
			{
				BtoA_BarData();
			}
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
			ProgressBar1.Value = 0;
		}
	}

	private void BtoA_Order()
	{
		DC_Main.RsQry = "DELETE FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		else
		{
			ExeQuteCnTr(DC_Main.RsQry);
		}
		DC_Main.RsQry = "SELECT A.AC_CODE,A.VCH_DATE,A.VCH_NO,A.ADV_AMT,SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_AMT ELSE 0 END) AS AdjAmount,SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_GOLD ELSE 0 END) AS AdjGold,  SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_SILVER ELSE 0 END) AS AdjSilver,A.CO_YEAR,A.CO_BOOK,A.HD_VCH_NO FROM SL_ORD_DATA AS A LEFT JOIN SL_ORD_ADJ AS B ON  A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC And A.CO_YEAR = B.ORD_YRCD And A.CO_BOOK = B.ORD_DBCD And A.VCH_NO = B.ORD_NO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "'  GROUP BY A.AC_CODE,A.VCH_DATE,A.VCH_NO,A.ADV_AMT,A.CO_YEAR,A.CO_BOOK,A.HD_VCH_NO HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END) + SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_GOLD ELSE - B.ORD_GOLD END) +SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_SILVER ELSE - B.ORD_SILVER END)  > 0  ORDER BY A.VCH_DATE,A.VCH_NO ";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Order Opning";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			DateTime dateTime = default(DateTime);
			DateTime dateTime2 = default(DateTime);
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.BOOK_SNAME,B.MAIN_BOOK,B.BOOK_INOUT FROM SL_ORD_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' and A.CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' "));
				DataTable dataTable = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? DC_Main.OpenRecordSetDc(DC_Main.RsQry) : OpenRecordsetTrfr(DC_Main.RsQry));
				DataTable dataTable2 = dataTable;
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["DEL_DATE"])))
				{
					dateTime = Conversions.ToDate(dataTable2.Rows[0]["DEL_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["FUN_DATE"])))
				{
					dateTime2 = Conversions.ToDate(dataTable2.Rows[0]["FUN_DATE"]);
				}
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_ORD_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,  BILL_NO,HD_VCH_NO,AC_CODE,AC_NAME,NET_AMT,TAX_CODE,TAX_PRC,TAX_AMT,TOT_AMT,ADV_AMT,  ORD_ADJ_AMT,OLD_GL_AMT,OLD_SL_AMT,CASH_AMT,CARD_AMT,CHQ_AMT,SCHM_AMT,DEL_DATE,  CARD_AC,BANK_AC,CHQ_NO,BANK_NAME,EMP_CODE,VCH_DESC,ENTRY_TIME,SL_BILL_TYPE,OLD_GL,  ADJ_GOLD,OLD_SL,ADJ_SILVER,CARD_ADJ,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,  ADD1,ADD2,ADD3,CITY,MOBILE,RCUT_AMT,MOB_ENTRY_SAVE,FUN_DATE,RCUT_RATE,RCUT_FINE,UPI_AMT) VALUES  ('", dataTable2.Rows[0]["CO_CODE"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), dataTable2.Rows[0]["CO_YEAR"]), (object)"','"), dataTable2.Rows[0]["CO_BOOK"]), (object)"','"), dataTable2.Rows[0]["VCH_NO"]), (object)"','"), (object)Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy")), (object)"', "), (object)" '"), dataTable2.Rows[0]["BILL_NO"]), (object)"','"), dataTable2.Rows[0]["HD_VCH_NO"]), (object)"','"), dataTable2.Rows[0]["AC_CODE"]), (object)"','"), dataTable2.Rows[0]["AC_NAME"]), (object)"',");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["NET_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num), (object)",'"), dataTable2.Rows[0]["TAX_CODE"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["TAX_PRC"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["TAX_AMT"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["TAX_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num3), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["TOT_AMT"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["TOT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num4), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["ADV_AMT"]);
				double num5 = DC_Main.Fnv(ref Value);
				dataRow["ADV_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num5), (object)", "), (object)" ");
				Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["AdjAmount"]);
				double num6 = DC_Main.Fnv(ref Value);
				dataRow["AdjAmount"] = RuntimeHelpers.GetObjectValue(Value);
				object obj7 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num6), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["OLD_GL_AMT"]);
				double num7 = DC_Main.Fnv(ref Value);
				dataRow["OLD_GL_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj8 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, (object)num7), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["OLD_SL_AMT"]);
				double num8 = DC_Main.Fnv(ref Value);
				dataRow["OLD_SL_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj9 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj8, (object)num8), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["CASH_AMT"]);
				double num9 = DC_Main.Fnv(ref Value);
				dataRow["CASH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj10 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj9, (object)num9), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["CARD_AMT"]);
				double num10 = DC_Main.Fnv(ref Value);
				dataRow["CARD_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj11 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj10, (object)num10), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["CHQ_AMT"]);
				double num11 = DC_Main.Fnv(ref Value);
				dataRow["CHQ_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj12 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj11, (object)num11), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["SCHM_AMT"]);
				double num12 = DC_Main.Fnv(ref Value);
				dataRow["SCHM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj13 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj12, (object)num12), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["DEL_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'"))), (object)", "), (object)" '"), dataTable2.Rows[0]["CARD_AC"]), (object)"','"), dataTable2.Rows[0]["BANK_AC"]), (object)"','"), dataTable2.Rows[0]["CHQ_NO"]), (object)"','"), dataTable2.Rows[0]["BANK_NAME"]), (object)"','"), dataTable2.Rows[0]["EMP_CODE"]), (object)"','"), dataTable2.Rows[0]["VCH_DESC"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["OLD_GL"]);
				double num13 = DC_Main.Fnv(ref Value);
				dataRow["OLD_GL"] = RuntimeHelpers.GetObjectValue(Value);
				object obj14 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj13, (object)num13), (object)", "), (object)" ");
				Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["AdjGold"]);
				double num14 = DC_Main.Fnv(ref Value);
				dataRow["AdjGold"] = RuntimeHelpers.GetObjectValue(Value);
				object obj15 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj14, (object)num14), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["OLD_SL"]);
				double num15 = DC_Main.Fnv(ref Value);
				dataRow["OLD_SL"] = RuntimeHelpers.GetObjectValue(Value);
				object obj16 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj15, (object)num15), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["AdjSilver"]);
				double num16 = DC_Main.Fnv(ref Value);
				dataRow["AdjSilver"] = RuntimeHelpers.GetObjectValue(Value);
				object obj17 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj16, (object)num16), (object)",'"), dataTable2.Rows[0]["CARD_ADJ"]), (object)"','Y','','','"), dataTable2.Rows[0]["MAIN_USER"]), (object)"', "), (object)" '"), dataTable2.Rows[0]["ADD1"]), (object)"','"), dataTable2.Rows[0]["ADD2"]), (object)"','"), dataTable2.Rows[0]["ADD3"]), (object)"','"), dataTable2.Rows[0]["CITY"]), (object)"','"), dataTable2.Rows[0]["MOBILE"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["RCUT_AMT"]);
				double num17 = DC_Main.Fnv(ref Value);
				dataRow["RCUT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj18 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj17, (object)num17), (object)",'"), dataTable2.Rows[0]["MOB_ENTRY_SAVE"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["FUN_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime2, "MM/dd/yyyy") + "'"))), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["RCUT_RATE"]);
				double num18 = DC_Main.Fnv(ref Value);
				dataRow["RCUT_RATE"] = RuntimeHelpers.GetObjectValue(Value);
				object obj19 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj18, (object)num18), (object)",");
				Value = Operators.ConcatenateObject(dataTable2.Rows[0]["RCUT_FINE"], (object)"");
				object obj20 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj19, (object)DC_Main.Fnv(ref Value)), (object)",");
				Value = Operators.ConcatenateObject(dataTable2.Rows[0]["UPI_AMT"], (object)"");
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj20, (object)DC_Main.Fnv(ref Value)), (object)")"));
				DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				dataTable2 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void BtoA_BarData()
	{
		DC_Main.RsQry = "DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '000'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		else
		{
			ExeQuteCnTr(DC_Main.RsQry);
		}
		DC_Main.RsQry = "DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '000'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		else
		{
			ExeQuteCnTr(DC_Main.RsQry);
		}
		DC_Main.RsQry = "DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '000'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		else
		{
			ExeQuteCnTr(DC_Main.RsQry);
		}
		string text = "00000";
		DC_Main.RsQry = "SELECT B.IT_TYPE,A.IT_CODE FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND TAG_NO <> 'N' GROUP BY B.IT_TYPE,A.IT_CODE ORDER BY B.IT_TYPE,A.IT_CODE ";
		DataTable dataTable = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? DC_Main.OpenRecordSetDc(DC_Main.RsQry) : OpenRecordsetTrfr(DC_Main.RsQry));
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = dataTable.Rows.Count;
		lblBook.Text = "Tag Transfer";
		DC_Main.RsQry = "SELECT MAX((VCH_NO)) AS CoCode  From BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '000' HAVING MAX((VCH_NO)) > 0";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			text = "00001";
		}
		else
		{
			text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"]), "00000");
			if (Operators.CompareString(text, "00000", false) == 0)
			{
				text = "00001";
			}
		}
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < dataTable.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND IT_CODE = '"), dataTable.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
				DataTable dataTable2 = ((Operators.CompareString(DC_Main.MsIpWith, "A", false) != 0) ? DC_Main.OpenRecordSetDc(DC_Main.RsQry) : OpenRecordsetTrfr(DC_Main.RsQry));
				if (dataTable2.Rows.Count > 0)
				{
					DataView dataView = new DataView(dataTable2);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.CO_CODE As CoCode,C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.STK_DATE As StkDate,C.TAG_NO,A.IT_CODE As ItCode,C.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_SIZE As Size,1 As Qty,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,C.LBR_RATE As LbrRate,C.LBR_PRC As Lbrprc,C.LBR_AMT AS LbrAmt,C.OTH_AMT As OthAmt,  C.KR_COST As PrCost,C.ITM_MRP As Mrp,C.KR_NAME As KrName,C.CO_BOOK As Book,C.BOOK_NAME As BookName,C.AC_CODE As AcCode,C.VCH_SRNO  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'  AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "' AND A.IT_CODE = '"), dataTable.Rows[DC_Main.M]["IT_CODE"]), (object)"' "), (object)" GROUP BY C.CO_CODE,C.VCH_TYPE,C.VCH_NO,C.STK_DATE,C.TAG_NO,A.IT_CODE,C.TBL_CODE,C.DESIGN_NO,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.LBR_RATE,C.LBR_PRC,C.LBR_AMT,C.OTH_AMT, "), (object)" C.KR_COST,C.ITM_MRP,C.KR_NAME,C.CO_BOOK,C.BOOK_NAME,C.AC_CODE,C.VCH_SRNO "), (object)" HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY C.TAG_NO"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
					}
					else
					{
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					DC_Main.i = 0;
					int num = 0;
					while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
					{
						num++;
						dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"TAG_NO = '", DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"]), (object)""));
						DataView dataView2 = dataView;
						if (dataView.Count > 0)
						{
							object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,  TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,  ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,  KR_NAME,KR_OTH_WT,KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,  KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,TAG_SRNO,VCH_SRNO,RATE_TYPE,IT_TYPE,  TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,ORD_AC,MAIN_USER,ADD_USER,DATA_TRFR,  HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,HM_ID,HM_ID2,HM_ID3,HM_ID4,  HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,DATA_TYPE,APP_TRFR,ITM_COLOR,  MAIN_MARGIN_PRC,MAIN_MRP,JDT_JDT_WT,JDT_GHT_WT,JDT_KUN_WT,JDT_WAX_WT,KR_WAX_WT,JDT_KUN_TOUCH,JDT_KUN_NET,EMP_ISU) VALUES  ('", dataView2[0]["CO_CODE"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), (object)DC_Main.MCo_year), (object)"','000','"), (object)text), (object)"',"), (object)num), (object)","), (object)num), (object)", "), (object)" '"), (object)Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["STK_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["STK_DATE"]), "MM/dd/yyyy")), (object)"','"), dataView2[0]["VCH_TYPE"]), (object)"','I','O','"), dataView2[0]["BOOK_NAME"]), (object)"','"), dataView2[0]["AC_CODE"]), (object)"','"), dataView2[0]["IT_CODE"]), (object)"', "), (object)" '"), dataView2[0]["TAG_NO"]), (object)"','','"), dataView2[0]["DESIGN_NO"]), (object)"','"), dataView2[0]["TBL_CODE"]), (object)"','"), dataView2[0]["ITM_SIZE"]), (object)"',");
							DataRowView dataRowView;
							object Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_PCS"]);
							double num2 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_PCS"] = RuntimeHelpers.GetObjectValue(Value);
							object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num2), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["BAG_WT"]);
							double num3 = DC_Main.Fnv(ref Value);
							dataRowView["BAG_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num3), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_GWT"]);
							double num4 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num4), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_GWT"]);
							double num5 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num5), (object)"-");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_NWT"]);
							double value = DC_Main.Fnv(ref Value);
							dataRowView["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)Math.Abs(value)), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_NWT"]);
							double num6 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj7 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num6), (object)", "), (object)" ");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_GHT_PRC"]);
							double num7 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_GHT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							object obj8 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, (object)num7), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_GHT_WT"]);
							double num8 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj9 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj8, (object)num8), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_TOUCH"]);
							double num9 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
							object obj10 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj9, (object)num9), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_WEST_PRC"]);
							double num10 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_WEST_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							object obj11 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj10, (object)num10), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_FINE"]);
							double num11 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_FINE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj12 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj11, (object)num11), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["LBR_PRC"]);
							double num12 = DC_Main.Fnv(ref Value);
							dataRowView["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							object obj13 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj12, (object)num12), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["LBR_RATE"]);
							double num13 = DC_Main.Fnv(ref Value);
							dataRowView["LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj14 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj13, (object)num13), (object)",'"), dataView2[0]["LBR_TYPE"]), (object)"', "), (object)" ");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["LBR_AMT"]);
							double num14 = DC_Main.Fnv(ref Value);
							dataRowView["LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj15 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj14, (object)num14), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["OTH_AMT"]);
							double num15 = DC_Main.Fnv(ref Value);
							dataRowView["OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj16 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj15, (object)num15), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_RATE"]);
							double num16 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj17 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj16, (object)num16), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_AMT"]);
							double num17 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj18 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj17, (object)num17), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["TAG_COST"]);
							double num18 = DC_Main.Fnv(ref Value);
							dataRowView["TAG_COST"] = RuntimeHelpers.GetObjectValue(Value);
							object obj19 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj18, (object)num18), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_MARGIN"]);
							double num19 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_MARGIN"] = RuntimeHelpers.GetObjectValue(Value);
							object obj20 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj19, (object)num19), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_MRP"]);
							double num20 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_MRP"] = RuntimeHelpers.GetObjectValue(Value);
							object obj21 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj20, (object)num20), (object)",'"), dataView2[0]["ITM_REMARK"]), (object)"','"), dataView2[0]["SF_NO"]), (object)"', "), (object)" '"), dataView2[0]["KR_NAME"]), (object)"',");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_OTH_WT"]);
							double num21 = DC_Main.Fnv(ref Value);
							dataRowView["KR_OTH_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj22 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj21, (object)num21), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_NET_WT"]);
							double num22 = DC_Main.Fnv(ref Value);
							dataRowView["KR_NET_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj23 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj22, (object)num22), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_GHT_PRC"]);
							double num23 = DC_Main.Fnv(ref Value);
							dataRowView["KR_GHT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							object obj24 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj23, (object)num23), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_GHT_WT"]);
							double num24 = DC_Main.Fnv(ref Value);
							dataRowView["KR_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj25 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj24, (object)num24), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_TOUCH"]);
							double num25 = DC_Main.Fnv(ref Value);
							dataRowView["KR_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
							object obj26 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj25, (object)num25), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_WEST_PRC"]);
							double num26 = DC_Main.Fnv(ref Value);
							dataRowView["KR_WEST_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							object obj27 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj26, (object)num26), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_FINE"]);
							double num27 = DC_Main.Fnv(ref Value);
							dataRowView["KR_FINE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj28 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj27, (object)num27), (object)", "), (object)" ");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_LBR_RATE"]);
							double num28 = DC_Main.Fnv(ref Value);
							dataRowView["KR_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj29 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj28, (object)num28), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_LBR_AMT"]);
							double num29 = DC_Main.Fnv(ref Value);
							dataRowView["KR_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj30 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj29, (object)num29), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_OTH_AMT"]);
							double num30 = DC_Main.Fnv(ref Value);
							dataRowView["KR_OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj31 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj30, (object)num30), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_COST"]);
							double num31 = DC_Main.Fnv(ref Value);
							dataRowView["KR_COST"] = RuntimeHelpers.GetObjectValue(Value);
							object obj32 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj31, (object)num31), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["TAG_SRNO"]);
							double num32 = DC_Main.Fnv(ref Value);
							dataRowView["TAG_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
							object obj33 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj32, (object)num32), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["VCH_SRNO"]);
							double num33 = DC_Main.Fnv(ref Value);
							dataRowView["VCH_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
							object obj34 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj33, (object)num33), (object)",'"), dataView2[0]["RATE_TYPE"]), (object)"','"), dataView2[0]["IT_TYPE"]), (object)"', "), (object)" '"), dataView2[0]["TAG_TYPE"]), (object)"','"), dataView2[0]["PR_CODE"]), (object)"','N','','0','','','','"), (object)DC_Main.MCo_User), (object)"','"), (object)DC_Main.MCo_User), (object)"','Y', "), (object)" '"), (object)text), (object)"','"), dataView2[0]["OLD_VCH_NO"]), (object)"','"), dataView2[0]["NEW_VCH_NO"]), (object)"','"), dataView2[0]["HM_ID"]), (object)"','"), dataView2[0]["HM_ID2"]), (object)"','"), dataView2[0]["HM_ID3"]), (object)"','"), dataView2[0]["HM_ID4"]), (object)"', "), (object)" ");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["HM_ID_WT"]);
							double num34 = DC_Main.Fnv(ref Value);
							dataRowView["HM_ID_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj35 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj34, (object)num34), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["HM_ID2_WT"]);
							double num35 = DC_Main.Fnv(ref Value);
							dataRowView["HM_ID2_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj36 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj35, (object)num35), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["HM_ID3_WT"]);
							double num36 = DC_Main.Fnv(ref Value);
							dataRowView["HM_ID3_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj37 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj36, (object)num36), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["HM_ID4_WT"]);
							double num37 = DC_Main.Fnv(ref Value);
							dataRowView["HM_ID4_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj38 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj37, (object)num37), (object)",'"), dataView2[0]["DATA_TYPE"]), (object)"','"), dataView2[0]["APP_TRFR"]), (object)"','"), dataView2[0]["ITM_COLOR"]), (object)"', "), (object)" ");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["MAIN_MARGIN_PRC"]);
							double num38 = DC_Main.Fnv(ref Value);
							dataRowView["MAIN_MARGIN_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							object obj39 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj38, (object)num38), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["MAIN_MRP"]);
							double num39 = DC_Main.Fnv(ref Value);
							dataRowView["MAIN_MRP"] = RuntimeHelpers.GetObjectValue(Value);
							object obj40 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj39, (object)num39), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["JDT_JDT_WT"]);
							double num40 = DC_Main.Fnv(ref Value);
							dataRowView["JDT_JDT_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj41 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj40, (object)num40), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["JDT_GHT_WT"]);
							double num41 = DC_Main.Fnv(ref Value);
							dataRowView["JDT_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj42 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj41, (object)num41), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["JDT_KUN_WT"]);
							double num42 = DC_Main.Fnv(ref Value);
							dataRowView["JDT_KUN_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj43 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj42, (object)num42), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["JDT_WAX_WT"]);
							double num43 = DC_Main.Fnv(ref Value);
							dataRowView["JDT_WAX_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj44 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj43, (object)num43), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_WAX_WT"]);
							double num44 = DC_Main.Fnv(ref Value);
							dataRowView["KR_WAX_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj45 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj44, (object)num44), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["JDT_KUN_TOUCH"]);
							double num45 = DC_Main.Fnv(ref Value);
							dataRowView["JDT_KUN_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
							object obj46 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj45, (object)num45), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["JDT_KUN_NET"]);
							double num46 = DC_Main.Fnv(ref Value);
							dataRowView["JDT_KUN_NET"] = RuntimeHelpers.GetObjectValue(Value);
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj46, (object)num46), (object)",'"), dataView2[0]["EMP_ISU"]), (object)"')"));
							if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
							{
								DC_Main.ExeQuteDc(DC_Main.RsQry);
							}
							else
							{
								ExeQuteCnTr(DC_Main.RsQry);
							}
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_TYPE FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"]), (object)" ORDER BY A.ISR_NO "));
							if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
							{
								RsIdtl = OpenRecordsetTrfr(DC_Main.RsQry);
							}
							else
							{
								RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							}
							DC_Main.R = 0;
							while (DC_Main.R < RsIdtl.Rows.Count)
							{
								object obj47 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,  DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,  IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER,  DM_NAME,DM_ORIGIN,DM_REMARK,DM_COLOR) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','" + text + "'," + Conversions.ToString(num) + "," + Conversions.ToString(DC_Main.R + 1) + ",'" + Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy") + "',  '"), RsIdtl.Rows[DC_Main.R]["VCH_TYPE"]), (object)"','I','O','"), RsIdtl.Rows[DC_Main.R]["BOOK_NAME"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["AC_CODE"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["TAG_NO"]), (object)"',"), RsIdtl.Rows[DC_Main.R]["VCH_SRNO"]), (object)",'"), RsIdtl.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["IT_TYPE"]), (object)"', "), (object)" '"), RsIdtl.Rows[DC_Main.R]["DM_CODE"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["DM_SIZE"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["DM_SFNO"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["DM_LEB"]), (object)"',");
								DataRow dataRow;
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_PCS"]);
								double num47 = DC_Main.Fnv(ref Value);
								dataRow["IT_PCS"] = RuntimeHelpers.GetObjectValue(Value);
								object obj48 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj47, (object)num47), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_PCS_WT"]);
								double num48 = DC_Main.Fnv(ref Value);
								dataRow["IT_PCS_WT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj49 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj48, (object)num48), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_WT"]);
								double num49 = DC_Main.Fnv(ref Value);
								dataRow["KR_WT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj50 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj49, (object)num49), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_LESS_PRC"]);
								double num50 = DC_Main.Fnv(ref Value);
								dataRow["KR_LESS_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								object obj51 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj50, (object)num50), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_GWT"]);
								double num51 = DC_Main.Fnv(ref Value);
								dataRow["IT_GWT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj52 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj51, (object)num51), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_CON_PRC"]);
								double num52 = DC_Main.Fnv(ref Value);
								dataRow["IT_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								object obj53 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj52, (object)num52), (object)", "), (object)" ");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_CON_WT"]);
								double num53 = DC_Main.Fnv(ref Value);
								dataRow["IT_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj54 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj53, (object)num53), (object)",'"), RsIdtl.Rows[DC_Main.R]["IT_RATE_TYPE"]), (object)"',");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_RATE"]);
								double num54 = DC_Main.Fnv(ref Value);
								dataRow["IT_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj55 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj54, (object)num54), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_AMT"]);
								double num55 = DC_Main.Fnv(ref Value);
								dataRow["IT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj56 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj55, (object)num55), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_LBR_RATE"]);
								double num56 = DC_Main.Fnv(ref Value);
								dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj57 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj56, (object)num56), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_LBR_AMT"]);
								double num57 = DC_Main.Fnv(ref Value);
								dataRow["IT_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj58 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj57, (object)num57), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_NET_AMT"]);
								double num58 = DC_Main.Fnv(ref Value);
								dataRow["IT_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj59 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj58, (object)num58), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_CON_PRC"]);
								double num59 = DC_Main.Fnv(ref Value);
								dataRow["KR_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								object obj60 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj59, (object)num59), (object)", "), (object)" ");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_CON_WT"]);
								double num60 = DC_Main.Fnv(ref Value);
								dataRow["KR_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj61 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj60, (object)num60), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_RATE"]);
								double num61 = DC_Main.Fnv(ref Value);
								dataRow["KR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj62 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj61, (object)num61), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_AMT"]);
								double num62 = DC_Main.Fnv(ref Value);
								dataRow["KR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj63 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj62, (object)num62), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_LBR_RATE"]);
								double num63 = DC_Main.Fnv(ref Value);
								dataRow["KR_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj64 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj63, (object)num63), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_LBR_AMT"]);
								double num64 = DC_Main.Fnv(ref Value);
								dataRow["KR_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj65 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj64, (object)num64), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_NET_AMT"]);
								double num65 = DC_Main.Fnv(ref Value);
								dataRow["KR_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj66 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj65, (object)num65), (object)",'");
								Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["MAIN_USER"]);
								double num66 = DC_Main.Fnv(ref Value);
								dataRow["MAIN_USER"] = RuntimeHelpers.GetObjectValue(Value);
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj66, (object)num66), (object)"', "), (object)" '"), RsIdtl.Rows[DC_Main.R]["DM_NAME"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["DM_ORIGIN"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["DM_REMARK"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["DM_COLOR"]), (object)"')"));
								if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
								{
									DC_Main.ExeQuteDc(DC_Main.RsQry);
								}
								else
								{
									ExeQuteCnTr(DC_Main.RsQry);
								}
								DC_Main.R++;
							}
						}
						dataView2 = null;
						DC_Main.i++;
					}
					if (num > 0)
					{
						DC_Main.RsQry = "INSERT INTO BAR_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE, AC_CODE,CUST_AC,OP_STK,VCH_TIME,DATA_TRFR)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','" + text + "','" + Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy") + "','','','Y','" + Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "MM/dd/yyyy") + "','Y')";
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						else
						{
							ExeQuteCnTr(DC_Main.RsQry);
						}
						text = Strings.Format((object)(Conversion.Val(text) + 1.0), "00000");
						num = 0;
					}
				}
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT TOP 2 CO_BOOK,VCH_NO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND BOOK_NAME IN ('OPSTK') GROUP BY CO_BOOK,VCH_NO ORDER BY VCH_NO DESC";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TEMP_BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,BOOK_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"','')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
			}
			DC_Main.RsQry = "SELECT TOP 2 CO_BOOK,VCH_NO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND BOOK_NAME IN ('TAG GEN') GROUP BY CO_BOOK,VCH_NO ORDER BY VCH_NO DESC";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"'"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TEMP_BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,BOOK_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"','"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"','')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
			}
		}
	}

	private void Pluse_OpblImport()
	{
		//IL_0f09: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "DELETE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ";
		DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Party Master";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			DateTime dateTime = default(DateTime);
			DateTime dateTime2 = default(DateTime);
			DateTime dateTime3 = default(DateTime);
			DateTime dateTime4 = default(DateTime);
			DateTime dateTime5 = default(DateTime);
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["BR_DATE"])))
				{
					dateTime = Conversions.ToDate(rshlp.Rows[DC_Main.M]["BR_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["L_BR_DATE"])))
				{
					dateTime2 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["L_BR_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["AN_DATE"])))
				{
					dateTime3 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["AN_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["LAST_DATE"])))
				{
					dateTime4 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["LAST_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["LAST_VISIT"])))
				{
					dateTime5 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["LAST_VISIT"]);
				}
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO AC_MAST(CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_PERSON,AC_ADD1,AC_ADD2,  AC_ADD3,AC_COUNTRY,AC_STATE,AC_DISTRICT,AC_CITY,AC_AREA,AC_PIN,AC_PHONE,AC_PHONE2,AC_MOBILE,AC_MOBILE2,AC_EMAIL,  AC_GSTNO,AC_GST_TYPE,AC_PANNO,AC_REF_CODE,AC_KHATA_NO,BR_DATE,L_BR_DATE,AN_DATE,AC_CR_DAYS,AC_INT_PRC,DPC_PRC,  BANK_NAME,BANK_AREA,BANK_AC_NO,BANK_RTGS_NO,BANK_DETL,AC_TYPE,LAST_DATE,DATA_TRFR,MAIN_USER,LAST_VISIT,VISIT_TRAN,  APP_TRFR,AC_REF_NAME)   VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"','','"), rshlp.Rows[DC_Main.M]["AC_MAIN_GR"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_GR"]), (object)"','','"), rshlp.Rows[DC_Main.M]["AC_ADD1"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_ADD2"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["AC_ADD3"]), (object)"','','"), rshlp.Rows[DC_Main.M]["AC_STATE"]), (object)"','','"), rshlp.Rows[DC_Main.M]["AC_CITY"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_AREA"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_PIN"]), (object)"','"), (object)Strings.Mid(Conversions.ToString(rshlp.Rows[DC_Main.M]["AC_PHONE"]), 1, 15)), (object)"','','"), (object)Strings.Mid(Conversions.ToString(rshlp.Rows[DC_Main.M]["AC_MOBILE"]), 1, 12)), (object)"','"), (object)Strings.Mid(Conversions.ToString(rshlp.Rows[DC_Main.M]["AC_MOBILE2"]), 1, 15)), (object)"','"), rshlp.Rows[DC_Main.M]["AC_EMAIL"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["GST_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["TAX_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_PANNO"]), (object)"','','"), rshlp.Rows[DC_Main.M]["AC_KHATA_NO"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["BR_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["L_BR_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime2, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["AN_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime3, "MM/dd/yyyy") + "'"))), (object)",");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["AC_CR_DAYS"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["AC_CR_DAYS"] = RuntimeHelpers.GetObjectValue(Value);
				object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["AC_INT_PRC"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["AC_INT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["DPC_PRC"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["DPC_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num3), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AREA"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AC_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_RTGS_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_DETL"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_TYPE"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["LAST_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime4, "MM/dd/yyyy") + "'"))), (object)",'Y','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["LAST_VISIT"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime5, "MM/dd/yyyy") + "'"))), (object)" ,'"), rshlp.Rows[DC_Main.M]["VISIT_TRAN"]), (object)"', "), (object)" 'N','')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.RsQry = "DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			else
			{
				ExeQuteCnTr(DC_Main.RsQry);
			}
			DC_Main.RsQry = "Select A.AC_CODE,format(Sum(A.CR_AMT-A.DR_AMT),'0.00') as Amount,format(SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as GoldWt,format(sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as SilverWt  FROM AC_DATA AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' and VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "'   GROUP BY A.AC_CODE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))+sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))+sum(iif(A.IT_TYPE = 'D',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))) <> 0 ORDER BY A.AC_CODE ";
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
			}
			else
			{
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Party Opning";
			Application.DoEvents();
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp2 = DC_Main.Rshlp;
				if (Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["Amount"]))) + Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["GoldWt"]))) + Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["SilverWt"]))) != 0.0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO OP_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,  OP_AMT,OP_SIGN,FINE_BAL,FINE_SIGN,SL_FINE_BAL,SL_FINE_SIGN,  DATA_TYPE,MAIN_USER,ADD_USER,ADD_DATE,DATA_TRFR) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','00000','"), rshlp2.Rows[DC_Main.M]["AC_CODE"]), (object)"', "), (object)" "), (object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["Amount"])))), (object)","), Interaction.IIf(Operators.ConditionalCompareObjectGreater(rshlp2.Rows[DC_Main.M]["Amount"], (object)0, false), (object)"'C'", (object)"'D'")), (object)","), (object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["GoldWt"])))), (object)","), Interaction.IIf(Operators.ConditionalCompareObjectGreater(rshlp2.Rows[DC_Main.M]["GoldWt"], (object)0, false), (object)"'C'", (object)"'D'")), (object)","), (object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.M]["SilverWt"])))), (object)","), Interaction.IIf(Operators.ConditionalCompareObjectGreater(rshlp2.Rows[DC_Main.M]["SilverWt"], (object)0, false), (object)"'C'", (object)"'D'")), (object)", "), (object)" 'A','"), (object)DC_Main.MCo_User), (object)"','',NULL,'Y')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					else
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
				}
				rshlp2 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.ExeQuteDc("UPDATE CO_SET SET VB_IMPORT = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			Interaction.MsgBox((object)"Data Import Is Done...", (MsgBoxStyle)0, (object)null);
			Application.Exit();
		}
	}

	private void BtoA_TmpBookData()
	{
		DC_Main.RsQry = "SELECT CO_CODE,LC_CODE,CO_BOOK,MAX(VCH_NO) AS VCH_NO,BOOK_NAME FROM CASH_DATA AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND BOOK_NAME = 'CASH REC'  GROUP BY CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME  UNION ALL SELECT CO_CODE,LC_CODE,CO_BOOK,MAX(VCH_NO) AS VCH_NO,BOOK_NAME FROM CASH_DATA AS B WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND BOOK_NAME = 'CASH PAY'  GROUP BY CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME  UNION ALL SELECT CO_CODE,LC_CODE,CO_BOOK,MAX(VCH_NO) AS VCH_NO,BOOK_NAME FROM CASH_DATA AS C WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND BOOK_NAME = 'BANK REC'  GROUP BY CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME  UNION ALL SELECT CO_CODE,LC_CODE,CO_BOOK,MAX(VCH_NO) AS VCH_NO,BOOK_NAME FROM CASH_DATA AS D WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND BOOK_NAME = 'BANK PAY'  GROUP BY CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME  UNION ALL SELECT E.CO_CODE,E.LC_CODE,E.CO_BOOK,MAX(E.VCH_NO) AS VCH_NO,S.MAIN_BOOK FROM BAR_CAN_DATA AS E LEFT JOIN BOOK_DATA AS S ON E.CO_CODE = S.CO_CODE AND E.LC_CODE = S.LC_CODE AND E.CO_BOOK = S.CO_BOOK WHERE E.CO_CODE = '" + DC_Main.MCo_code + "' AND E.CO_YEAR = '" + DC_Main.MCo_year + "' AND S.MAIN_BOOK = 'TAG CANCEL'  GROUP BY E.CO_CODE,E.LC_CODE,E.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT CO_CODE,LC_CODE,CO_BOOK,MAX(VCH_NO) AS VCH_NO,BOOK_NAME FROM CONTRA_DATA AS F WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND BOOK_NAME = 'CONTRA'  GROUP BY CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME  UNION ALL SELECT G.CO_CODE,G.LC_CODE,G.CO_BOOK,MAX(G.VCH_NO) AS VCH_NO,S.MAIN_BOOK FROM SL_ORD_DATA AS G LEFT JOIN BOOK_DATA AS S ON G.CO_CODE = S.CO_CODE AND G.LC_CODE = S.LC_CODE AND G.CO_BOOK = S.CO_BOOK WHERE G.CO_CODE = '" + DC_Main.MCo_code + "' AND G.CO_YEAR = '" + DC_Main.MCo_year + "' AND S.MAIN_BOOK = 'SALES ORDER'  GROUP BY G.CO_CODE,G.LC_CODE,G.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT H.CO_CODE,H.LC_CODE,H.CO_BOOK,MAX(H.VCH_NO) AS VCH_NO,S.MAIN_BOOK FROM SL_DATA AS H LEFT JOIN BOOK_DATA AS S ON H.CO_CODE = S.CO_CODE AND H.LC_CODE = S.LC_CODE AND H.CO_BOOK = S.CO_BOOK WHERE H.CO_CODE = '" + DC_Main.MCo_code + "' AND H.CO_YEAR = '" + DC_Main.MCo_year + "' AND S.MAIN_BOOK = 'SALES'  GROUP BY H.CO_CODE,H.LC_CODE,H.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT I.CO_CODE,I.LC_CODE,I.CO_BOOK,MAX(I.VCH_NO) AS VCH_NO,S.MAIN_BOOK FROM RATE_CUT_DATA AS I LEFT JOIN BOOK_DATA AS S ON I.CO_CODE = S.CO_CODE AND I.LC_CODE = S.LC_CODE AND I.CO_BOOK = S.CO_BOOK WHERE I.CO_CODE = '" + DC_Main.MCo_code + "' AND I.CO_YEAR = '" + DC_Main.MCo_year + "' AND S.MAIN_BOOK = 'WH SALES'  GROUP BY I.CO_CODE,I.LC_CODE,I.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT J.CO_CODE,J.LC_CODE,J.CO_BOOK,MAX(J.VCH_NO) AS VCH_NO,S.MAIN_BOOK FROM PR_DATA AS J LEFT JOIN BOOK_DATA AS S ON J.CO_CODE = S.CO_CODE AND J.LC_CODE = S.LC_CODE AND J.CO_BOOK = S.CO_BOOK WHERE J.CO_CODE = '" + DC_Main.MCo_code + "' AND J.CO_YEAR = '" + DC_Main.MCo_year + "' AND S.MAIN_BOOK = 'PURCHASE'  GROUP BY J.CO_CODE,J.LC_CODE,J.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT K.CO_CODE,K.LC_CODE,K.CO_BOOK,MAX(K.VCH_NO) AS VCH_NO,S.MAIN_BOOK FROM SL_DATA AS K LEFT JOIN BOOK_DATA AS S ON K.CO_CODE = S.CO_CODE AND K.LC_CODE = S.LC_CODE AND K.CO_BOOK = S.CO_BOOK WHERE K.CO_CODE = '" + DC_Main.MCo_code + "' AND K.CO_YEAR = '" + DC_Main.MCo_year + "' AND S.MAIN_BOOK = 'SALES RETURNE'  GROUP BY K.CO_CODE,K.LC_CODE,K.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT L.CO_CODE,L.LC_CODE,L.CO_BOOK,MAX(L.VCH_NO) AS VCH_NO,S.MAIN_BOOK FROM KR_DATA AS L LEFT JOIN BOOK_DATA AS S ON L.CO_CODE = S.CO_CODE AND L.LC_CODE = S.LC_CODE AND L.CO_BOOK = S.CO_BOOK WHERE L.CO_CODE = '" + DC_Main.MCo_code + "' AND L.CO_YEAR = '" + DC_Main.MCo_year + "' AND S.MAIN_BOOK = 'KARIGAR ISSUE'  GROUP BY L.CO_CODE,L.LC_CODE,L.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT M.CO_CODE,M.LC_CODE,M.CO_BOOK,MAX(M.VCH_NO) AS VCH_NO,S.MAIN_BOOK FROM KR_DATA AS M LEFT JOIN BOOK_DATA AS S ON M.CO_CODE = S.CO_CODE AND M.LC_CODE = S.LC_CODE AND M.CO_BOOK = S.CO_BOOK WHERE M.CO_CODE = '" + DC_Main.MCo_code + "' AND M.CO_YEAR = '" + DC_Main.MCo_year + "' AND S.MAIN_BOOK = 'KARIGAR RECEIPT'  GROUP BY M.CO_CODE,M.LC_CODE,M.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT N.CO_CODE,N.LC_CODE,N.CO_BOOK,MAX(N.VCH_NO) AS VCH_NO,S.MAIN_BOOK FROM RATE_CUT_DATA AS N LEFT JOIN BOOK_DATA AS S ON N.CO_CODE = S.CO_CODE AND N.LC_CODE = S.LC_CODE AND N.CO_BOOK = S.CO_BOOK WHERE N.CO_CODE = '" + DC_Main.MCo_code + "' AND N.CO_YEAR = '" + DC_Main.MCo_year + "' AND S.MAIN_BOOK = 'RATE CUT'  GROUP BY N.CO_CODE,N.LC_CODE,N.CO_BOOK,S.MAIN_BOOK  UNION ALL SELECT O.CO_CODE,O.LC_CODE,O.CO_BOOK,MAX(O.VCH_NO) AS VCH_NO,O.BOOK_NAME FROM CONTRA_DATA AS O WHERE O.CO_CODE = '" + DC_Main.MCo_code + "' AND O.CO_YEAR = '" + DC_Main.MCo_year + "' AND O.BOOK_NAME = 'FINE JV'  GROUP BY O.CO_CODE,O.LC_CODE,O.CO_BOOK,O.BOOK_NAME  UNION ALL SELECT P.CO_CODE,P.LC_CODE,P.CO_BOOK,MAX(P.VCH_NO) AS VCH_NO,P.BOOK_NAME FROM LBR_DATA AS P WHERE P.CO_CODE = '" + DC_Main.MCo_code + "' AND P.CO_YEAR = '" + DC_Main.MCo_year + "' AND P.BOOK_NAME = 'LABOUR WORK'  GROUP BY P.CO_CODE,P.LC_CODE,P.CO_BOOK,P.BOOK_NAME  UNION ALL SELECT Q.CO_CODE,Q.LC_CODE,Q.CO_BOOK,MAX(Q.VCH_NO) AS VCH_NO,Q.BOOK_NAME FROM PAY_DATA AS Q WHERE Q.CO_CODE = '" + DC_Main.MCo_code + "' AND Q.CO_YEAR = '" + DC_Main.MCo_year + "' AND Q.BOOK_NAME = 'OTH EXP'  GROUP BY Q.CO_CODE,Q.LC_CODE,Q.CO_BOOK,Q.BOOK_NAME   UNION ALL SELECT R.CO_CODE,R.LC_CODE,R.CO_BOOK,MAX(R.VCH_NO) AS VCH_NO,R.BOOK_NAME FROM REP_DETL AS R WHERE R.CO_CODE = '" + DC_Main.MCo_code + "' AND R.CO_YEAR = '" + DC_Main.MCo_year + "' AND R.BOOK_NAME = 'CUSTREP RECEIPT'  GROUP BY R.CO_CODE,R.LC_CODE,R.CO_BOOK,R.BOOK_NAME   UNION ALL SELECT W.CO_CODE,W.LC_CODE,W.CO_BOOK,MAX(W.VCH_NO) AS VCH_NO,W.BOOK_NAME FROM REP_DETL AS W WHERE W.CO_CODE = '" + DC_Main.MCo_code + "' AND W.CO_YEAR = '" + DC_Main.MCo_year + "' AND W.BOOK_NAME = 'KRREP ISSUE'  GROUP BY W.CO_CODE,W.LC_CODE,W.CO_BOOK,W.BOOK_NAME   UNION ALL SELECT T.CO_CODE,T.LC_CODE,T.CO_BOOK,MAX(T.VCH_NO) AS VCH_NO,T.BOOK_NAME FROM REP_DETL AS T WHERE T.CO_CODE = '" + DC_Main.MCo_code + "' AND T.CO_YEAR = '" + DC_Main.MCo_year + "' AND T.BOOK_NAME = 'KRREP RECEIPT'  GROUP BY T.CO_CODE,T.LC_CODE,T.CO_BOOK,T.BOOK_NAME  UNION ALL SELECT U.CO_CODE,U.LC_CODE,U.CO_BOOK,MAX(U.VCH_NO) AS VCH_NO,U.BOOK_NAME FROM REP_DETL AS U WHERE U.CO_CODE = '" + DC_Main.MCo_code + "' AND U.CO_YEAR = '" + DC_Main.MCo_year + "' AND U.BOOK_NAME = 'CUSTREP ISSUE'  GROUP BY U.CO_CODE,U.LC_CODE,U.CO_BOOK,U.BOOK_NAME ORDER BY LC_CODE,CO_BOOK ";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Tmp Book";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"' AND CO_BOOK = '"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' "));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TEMP_BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,BOOK_NAME) VALUES  ('" + DC_Main.MCo_code + "','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_NAME"]), (object)"')"));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				else
				{
					ExeQuteCnTr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void BtoA_ItmStk()
	{
		DC_Main.RsQry = "DELETE FROM ITM_OPBL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		else
		{
			ExeQuteCnTr(DC_Main.RsQry);
		}
		DC_Main.RsQry = "SELECT A.IT_CODE AS Code,B.IT_NAME AS Name,B.IT_TYPE,B.GR_CODE,B.AVG_TOUCH,SUM(iif(ITM_SIGN = '+', ITM_PCS, -ITM_PCS)) AS ClPcs,SUM(iif(ITM_SIGN = '+',ITM_NWT,-ITM_NWT)) AS ClWt ,SUM(iif(ITM_SIGN = '+',ITM_GWT,-ITM_GWT)) AS ClWtGr,SUM(iif(ITM_SIGN = '+', (ITM_PCS*B.ITEM_RATE), -(ITM_PCS*B.ITEM_RATE))) AS ItAmt FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "' AND A.IT_CODE <> '' AND (A.TAG_NO = 'N' OR A.TAG_NO = '' OR A.TAG_NO IS NULL)  GROUP BY A.IT_CODE,B.IT_NAME,B.IT_TYPE,B.GR_CODE,B.AVG_TOUCH ORDER BY B.GR_CODE,A.IT_CODE ";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Item Opning";
		Application.DoEvents();
		DC_Main.M = 0;
		while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
		{
			DataTable rshlp = DC_Main.Rshlp;
			double num = 0.0;
			DataRow dataRow;
			object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ClWt"]);
			double num2 = DC_Main.Fnv(ref Value);
			dataRow["ClWt"] = RuntimeHelpers.GetObjectValue(Value);
			bool num3 = num2 != 0.0;
			Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["AVG_TOUCH"]);
			double num4 = DC_Main.Fnv(ref Value);
			dataRow["AVG_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
			if (num3 && num4 != 0.0)
			{
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ClWt"]);
				double num5 = DC_Main.Fnv(ref Value);
				dataRow["ClWt"] = RuntimeHelpers.GetObjectValue(Value);
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["AVG_TOUCH"]);
				double num6 = DC_Main.Fnv(ref Value);
				dataRow["AVG_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
				num = Conversions.ToDouble(Strings.Format((object)Conversion.Val((object)(num5 * num6 / 100.0)), "0.000"));
			}
			checked
			{
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["ClWtGr"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["ClWt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["ClPcs"])) != 0.0)
				{
					object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO ITM_OPBL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,IT_CODE,VCH_NO,SR_NO,  ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_FINE,ITM_RATE,ITM_AMT,LBR_AMT,OTH_AMT,  NET_AMT,DM_WT,DM_RATE,DM_AMT,MAIN_USER,LBR_RATE,DATA_TRFR) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','"), rshlp.Rows[DC_Main.M]["Code"]), (object)"','"), rshlp.Rows[DC_Main.M]["IT_TYPE"]), (object)"',"), (object)(DC_Main.M + 1)), (object)", "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ClPcs"]);
					double num7 = DC_Main.Fnv(ref Value);
					dataRow["ClPcs"] = RuntimeHelpers.GetObjectValue(Value);
					object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)Strings.Format((object)num7, "0")), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ClWtGr"]);
					double num8 = DC_Main.Fnv(ref Value);
					dataRow["ClWtGr"] = RuntimeHelpers.GetObjectValue(Value);
					object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)Strings.Format((object)num8, "0.000")), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ClWt"]);
					double num9 = DC_Main.Fnv(ref Value);
					dataRow["ClWt"] = RuntimeHelpers.GetObjectValue(Value);
					object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)Strings.Format((object)num9, "0.000")), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["AVG_TOUCH"]);
					double num10 = DC_Main.Fnv(ref Value);
					dataRow["AVG_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num10), (object)","), (object)num), (object)",0,");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ItAmt"]);
					double num11 = DC_Main.Fnv(ref Value);
					dataRow["ItAmt"] = RuntimeHelpers.GetObjectValue(Value);
					object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num11), (object)",0,0, "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ItAmt"]);
					double num12 = DC_Main.Fnv(ref Value);
					dataRow["ItAmt"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num12), (object)",0,0,0,'"), (object)DC_Main.MCo_User), (object)"',0,'Y')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					else
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void BtoA_Balance()
	{
		DC_Main.RsQry = "DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		else
		{
			ExeQuteCnTr(DC_Main.RsQry);
		}
		DC_Main.RsQry = "Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,format(Sum(A.CR_AMT-A.DR_AMT),'0.00') as Amount,format(SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as GoldWt,format(sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as SilverWt  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' and VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "'   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))+sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))+sum(iif(A.IT_TYPE = 'D',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))) <> 0 ORDER BY B.AC_NAME ";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Party Opning";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				if (Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["Amount"]))) + Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["GoldWt"]))) + Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["SilverWt"]))) != 0.0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO OP_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,  OP_AMT,OP_SIGN,FINE_BAL,FINE_SIGN,SL_FINE_BAL,SL_FINE_SIGN,  DATA_TYPE,MAIN_USER,ADD_USER,ADD_DATE,DATA_TRFR) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','00000','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"', "), (object)" "), (object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["Amount"])))), (object)","), Interaction.IIf(Operators.ConditionalCompareObjectGreater(rshlp.Rows[DC_Main.M]["Amount"], (object)0, false), (object)"'C'", (object)"'D'")), (object)","), (object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["GoldWt"])))), (object)","), Interaction.IIf(Operators.ConditionalCompareObjectGreater(rshlp.Rows[DC_Main.M]["GoldWt"], (object)0, false), (object)"'C'", (object)"'D'")), (object)","), (object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["SilverWt"])))), (object)","), Interaction.IIf(Operators.ConditionalCompareObjectGreater(rshlp.Rows[DC_Main.M]["SilverWt"], (object)0, false), (object)"'C'", (object)"'D'")), (object)", "), (object)" 'A','"), (object)DC_Main.MCo_User), (object)"','',NULL,'Y')"));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					else
					{
						ExeQuteCnTr(DC_Main.RsQry);
					}
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void B_Data_Refresh()
	{
	}

	private void BtnBarData_Click(object sender, EventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Invalid comparison between Unknown and I4
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		lblBook.Text = "Retail Software Export";
		((Control)ProgressBar1).Visible = true;
		if ((int)Interaction.MsgBox((object)"Are You Sure To Data Transfer.... ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM CO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_TYPE <> ''";
				DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count <= 0)
				{
					Interaction.MsgBox((object)"Please Insert CoType In Company Master...", (MsgBoxStyle)0, (object)null);
					return;
				}
				TrFrCoType = Conversions.ToString(DC_Main.Rshlp.Rows[0]["CO_TYPE"]);
			}
			else
			{
				TrFrCoType = DC_Main.MCo_Type;
			}
			if (Operators.CompareString(TrFrCoType, "B", false) == 0)
			{
				BrDataReTrfr();
				Interaction.MsgBox((object)"Process Are Complete....Please B Data Refersh and Check Ledger and Stock Then Reset Data", (MsgBoxStyle)64, (object)null);
				return;
			}
		}
		Application.Exit();
	}

	private void BrDataReTrfr()
	{
		//IL_289b: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT C.CO_CODE As CoCode,C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.STK_DATE As StkDate,C.TAG_NO,A.IT_CODE As ItCode,C.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_SIZE As Size,1 As Qty,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,C.LBR_RATE As LbrRate,C.LBR_PRC As Lbrprc,C.LBR_AMT AS LbrAmt,C.OTH_AMT As OthAmt,  C.KR_COST As PrCost,C.ITM_MRP As Mrp,C.KR_NAME As KrName,C.CO_BOOK As Book,C.BOOK_NAME As BookName,C.AC_CODE As AcCode,C.VCH_SRNO,C.HD_VCH_NO  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'  AND A.TAG_NO <> 'N'  GROUP BY C.CO_CODE,C.VCH_TYPE,C.VCH_NO,C.STK_DATE,C.TAG_NO,A.IT_CODE,C.TBL_CODE,C.DESIGN_NO,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.LBR_RATE,C.LBR_PRC,C.LBR_AMT,C.OTH_AMT,  C.KR_COST,C.ITM_MRP,C.KR_NAME,C.CO_BOOK,C.BOOK_NAME,C.AC_CODE,C.VCH_SRNO,C.HD_VCH_NO  HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY C.TAG_NO";
		if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
		{
			DC_Main.Rshlp = OpenRecordsetTrfr(DC_Main.RsQry);
		}
		else
		{
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "BarData";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.TAG_NO,A.VCH_SRNO FROM BAR_DETL AS A  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), rshlp.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND VCH_SRNO = "), rshlp.Rows[DC_Main.M]["VCH_SRNO"]), (object)" "));
				if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
				{
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
				}
				if (RsDetl.Rows.Count == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.M]["Book"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VchNo"]), (object)"' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_SRNO"]), (object)""));
					if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
					{
						RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
					}
					else
					{
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					if (RsDetl.Rows.Count > 0)
					{
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), RsDetl.Rows[0]["CO_BOOK"]), (object)"' AND HD_VCH_NO = '"), RsDetl.Rows[0]["VCH_NO"]), (object)"' AND SR_NO = "), RsDetl.Rows[0]["SR_NO"]), (object)"")));
						}
						else
						{
							ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), RsDetl.Rows[0]["CO_BOOK"]), (object)"' AND HD_VCH_NO = '"), RsDetl.Rows[0]["VCH_NO"]), (object)"'AND SR_NO = "), RsDetl.Rows[0]["SR_NO"]), (object)"")));
							ExeQuteCnTr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), RsDetl.Rows[0]["CO_BOOK"]), (object)"' AND HD_VCH_NO = '"), RsDetl.Rows[0]["VCH_NO"]), (object)"'AND SR_NO = "), RsDetl.Rows[0]["SR_NO"]), (object)"")));
						}
						object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,  TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,  ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,  KR_NAME,KR_OTH_WT,KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,  KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,TAG_SRNO,VCH_SRNO,RATE_TYPE,IT_TYPE,  TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,ORD_AC,MAIN_USER,ADD_USER,DATA_TRFR,  HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,HM_ID,HM_ID2,HM_ID3,HM_ID4,  HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,DATA_TYPE,APP_TRFR,ITM_COLOR,  MAIN_MARGIN_PRC,MAIN_MRP,JDT_JDT_WT,JDT_GHT_WT,JDT_KUN_WT,JDT_WAX_WT,KR_WAX_WT,JDT_KUN_TOUCH,JDT_KUN_NET,EMP_ISU) VALUES  ('", RsDetl.Rows[0]["CO_CODE"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), (object)DC_Main.MCo_year), (object)"','"), RsDetl.Rows[0]["CO_BOOK"]), (object)"','"), RsDetl.Rows[0]["HD_VCH_NO"]), (object)"',"), RsDetl.Rows[0]["SR_NO"]), (object)","), RsDetl.Rows[0]["OLD_SRNO"]), (object)", "), (object)" '"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["STK_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["STK_DATE"]), "MM/dd/yyyy")), (object)"','"), RsDetl.Rows[0]["VCH_TYPE"]), (object)"','"), RsDetl.Rows[0]["INOUT_TYPE"]), (object)"','"), RsDetl.Rows[0]["ENTRY_TYPE"]), (object)"','"), RsDetl.Rows[0]["BOOK_NAME"]), (object)"','"), RsDetl.Rows[0]["AC_CODE"]), (object)"','"), RsDetl.Rows[0]["IT_CODE"]), (object)"', "), (object)" '"), RsDetl.Rows[0]["TAG_NO"]), (object)"','','"), RsDetl.Rows[0]["DESIGN_NO"]), (object)"','"), RsDetl.Rows[0]["TBL_CODE"]), (object)"','"), RsDetl.Rows[0]["ITM_SIZE"]), (object)"',");
						DataRow dataRow;
						object Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["ITM_PCS"]);
						double num = DC_Main.Fnv(ref Value);
						dataRow["ITM_PCS"] = RuntimeHelpers.GetObjectValue(Value);
						object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["BAG_WT"]);
						double num2 = DC_Main.Fnv(ref Value);
						dataRow["BAG_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["ITM_GWT"]);
						double num3 = DC_Main.Fnv(ref Value);
						dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num3), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["ITM_OTH_WT"]);
						double num4 = DC_Main.Fnv(ref Value);
						dataRow["ITM_OTH_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num4), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["ITM_NWT"]);
						double num5 = DC_Main.Fnv(ref Value);
						dataRow["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num5), (object)", "), (object)" ");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["ITM_GHT_PRC"]);
						double num6 = DC_Main.Fnv(ref Value);
						dataRow["ITM_GHT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						object obj7 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num6), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["ITM_GHT_WT"]);
						double num7 = DC_Main.Fnv(ref Value);
						dataRow["ITM_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj8 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, (object)num7), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["ITM_TOUCH"]);
						double num8 = DC_Main.Fnv(ref Value);
						dataRow["ITM_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
						object obj9 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj8, (object)num8), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["ITM_WEST_PRC"]);
						double num9 = DC_Main.Fnv(ref Value);
						dataRow["ITM_WEST_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						object obj10 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj9, (object)num9), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["ITM_FINE"]);
						double num10 = DC_Main.Fnv(ref Value);
						dataRow["ITM_FINE"] = RuntimeHelpers.GetObjectValue(Value);
						object obj11 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj10, (object)num10), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["LBR_PRC"]);
						double num11 = DC_Main.Fnv(ref Value);
						dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						object obj12 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj11, (object)num11), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["LBR_RATE"]);
						double num12 = DC_Main.Fnv(ref Value);
						dataRow["LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
						object obj13 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj12, (object)num12), (object)",'"), RsDetl.Rows[0]["LBR_TYPE"]), (object)"', "), (object)" ");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["LBR_AMT"]);
						double num13 = DC_Main.Fnv(ref Value);
						dataRow["LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj14 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj13, (object)num13), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["OTH_AMT"]);
						double num14 = DC_Main.Fnv(ref Value);
						dataRow["OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj15 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj14, (object)num14), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["ITM_RATE"]);
						double num15 = DC_Main.Fnv(ref Value);
						dataRow["ITM_RATE"] = RuntimeHelpers.GetObjectValue(Value);
						object obj16 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj15, (object)num15), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["ITM_AMT"]);
						double num16 = DC_Main.Fnv(ref Value);
						dataRow["ITM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj17 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj16, (object)num16), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["TAG_COST"]);
						double num17 = DC_Main.Fnv(ref Value);
						dataRow["TAG_COST"] = RuntimeHelpers.GetObjectValue(Value);
						object obj18 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj17, (object)num17), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["ITM_MARGIN"]);
						double num18 = DC_Main.Fnv(ref Value);
						dataRow["ITM_MARGIN"] = RuntimeHelpers.GetObjectValue(Value);
						object obj19 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj18, (object)num18), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["ITM_MRP"]);
						double num19 = DC_Main.Fnv(ref Value);
						dataRow["ITM_MRP"] = RuntimeHelpers.GetObjectValue(Value);
						object obj20 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj19, (object)num19), (object)",'"), RsDetl.Rows[0]["ITM_REMARK"]), (object)"','"), RsDetl.Rows[0]["SF_NO"]), (object)"', "), (object)" '"), RsDetl.Rows[0]["KR_NAME"]), (object)"',");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["KR_OTH_WT"]);
						double num20 = DC_Main.Fnv(ref Value);
						dataRow["KR_OTH_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj21 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj20, (object)num20), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["KR_NET_WT"]);
						double num21 = DC_Main.Fnv(ref Value);
						dataRow["KR_NET_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj22 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj21, (object)num21), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["KR_GHT_PRC"]);
						double num22 = DC_Main.Fnv(ref Value);
						dataRow["KR_GHT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						object obj23 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj22, (object)num22), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["KR_GHT_WT"]);
						double num23 = DC_Main.Fnv(ref Value);
						dataRow["KR_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj24 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj23, (object)num23), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["KR_TOUCH"]);
						double num24 = DC_Main.Fnv(ref Value);
						dataRow["KR_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
						object obj25 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj24, (object)num24), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["KR_WEST_PRC"]);
						double num25 = DC_Main.Fnv(ref Value);
						dataRow["KR_WEST_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						object obj26 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj25, (object)num25), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["KR_FINE"]);
						double num26 = DC_Main.Fnv(ref Value);
						dataRow["KR_FINE"] = RuntimeHelpers.GetObjectValue(Value);
						object obj27 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj26, (object)num26), (object)", "), (object)" ");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["KR_LBR_RATE"]);
						double num27 = DC_Main.Fnv(ref Value);
						dataRow["KR_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
						object obj28 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj27, (object)num27), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["KR_LBR_AMT"]);
						double num28 = DC_Main.Fnv(ref Value);
						dataRow["KR_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj29 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj28, (object)num28), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["KR_OTH_AMT"]);
						double num29 = DC_Main.Fnv(ref Value);
						dataRow["KR_OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj30 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj29, (object)num29), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["KR_COST"]);
						double num30 = DC_Main.Fnv(ref Value);
						dataRow["KR_COST"] = RuntimeHelpers.GetObjectValue(Value);
						object obj31 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj30, (object)num30), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["TAG_SRNO"]);
						double num31 = DC_Main.Fnv(ref Value);
						dataRow["TAG_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
						object obj32 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj31, (object)num31), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["VCH_SRNO"]);
						double num32 = DC_Main.Fnv(ref Value);
						dataRow["VCH_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
						object obj33 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj32, (object)num32), (object)",'"), RsDetl.Rows[0]["RATE_TYPE"]), (object)"','"), RsDetl.Rows[0]["IT_TYPE"]), (object)"', "), (object)" '"), RsDetl.Rows[0]["TAG_TYPE"]), (object)"','"), RsDetl.Rows[0]["PR_CODE"]), (object)"','N','','0','','','','"), (object)DC_Main.MCo_User), (object)"','"), (object)DC_Main.MCo_User), (object)"','N', "), (object)" '"), RsDetl.Rows[0]["HD_VCH_NO"]), (object)"','"), RsDetl.Rows[0]["OLD_VCH_NO"]), (object)"','"), RsDetl.Rows[0]["NEW_VCH_NO"]), (object)"','"), RsDetl.Rows[0]["HM_ID"]), (object)"','"), RsDetl.Rows[0]["HM_ID2"]), (object)"','"), RsDetl.Rows[0]["HM_ID3"]), (object)"','"), RsDetl.Rows[0]["HM_ID4"]), (object)"', "), (object)" ");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["HM_ID_WT"]);
						double num33 = DC_Main.Fnv(ref Value);
						dataRow["HM_ID_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj34 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj33, (object)num33), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["HM_ID2_WT"]);
						double num34 = DC_Main.Fnv(ref Value);
						dataRow["HM_ID2_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj35 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj34, (object)num34), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["HM_ID3_WT"]);
						double num35 = DC_Main.Fnv(ref Value);
						dataRow["HM_ID3_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj36 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj35, (object)num35), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["HM_ID4_WT"]);
						double num36 = DC_Main.Fnv(ref Value);
						dataRow["HM_ID4_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj37 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj36, (object)num36), (object)",'"), RsDetl.Rows[0]["DATA_TYPE"]), (object)"','"), RsDetl.Rows[0]["APP_TRFR"]), (object)"','"), RsDetl.Rows[0]["ITM_COLOR"]), (object)"', "), (object)" ");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["MAIN_MARGIN_PRC"]);
						double num37 = DC_Main.Fnv(ref Value);
						dataRow["MAIN_MARGIN_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						object obj38 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj37, (object)num37), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["MAIN_MRP"]);
						double num38 = DC_Main.Fnv(ref Value);
						dataRow["MAIN_MRP"] = RuntimeHelpers.GetObjectValue(Value);
						object obj39 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj38, (object)num38), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["JDT_JDT_WT"]);
						double num39 = DC_Main.Fnv(ref Value);
						dataRow["JDT_JDT_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj40 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj39, (object)num39), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["JDT_GHT_WT"]);
						double num40 = DC_Main.Fnv(ref Value);
						dataRow["JDT_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj41 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj40, (object)num40), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["JDT_KUN_WT"]);
						double num41 = DC_Main.Fnv(ref Value);
						dataRow["JDT_KUN_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj42 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj41, (object)num41), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["JDT_WAX_WT"]);
						double num42 = DC_Main.Fnv(ref Value);
						dataRow["JDT_WAX_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj43 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj42, (object)num42), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["KR_WAX_WT"]);
						double num43 = DC_Main.Fnv(ref Value);
						dataRow["KR_WAX_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj44 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj43, (object)num43), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["JDT_KUN_TOUCH"]);
						double num44 = DC_Main.Fnv(ref Value);
						dataRow["JDT_KUN_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
						object obj45 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj44, (object)num44), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[0])["JDT_KUN_NET"]);
						double num45 = DC_Main.Fnv(ref Value);
						dataRow["JDT_KUN_NET"] = RuntimeHelpers.GetObjectValue(Value);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj45, (object)num45), (object)",'"), RsDetl.Rows[0]["EMP_ISU"]), (object)"')"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_TYPE FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'  AND CO_BOOK = '"), RsDetl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), RsDetl.Rows[0]["VCH_NO"]), (object)"' AND SR_NO = "), RsDetl.Rows[0]["SR_NO"]), (object)" ORDER BY A.ISR_NO "));
						if (Operators.CompareString(DC_Main.MsIpWith, "A", false) == 0)
						{
							RsIdtl = OpenRecordsetTrfr(DC_Main.RsQry);
						}
						else
						{
							RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						}
						DC_Main.R = 0;
						while (DC_Main.R < RsIdtl.Rows.Count)
						{
							object obj46 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,  DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,  IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER,  DM_NAME,DM_ORIGIN,DM_REMARK,DM_COLOR) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','"), RsIdtl.Rows[DC_Main.R]["CO_BOOK"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["VCH_NO"]), (object)"',"), RsIdtl.Rows[DC_Main.R]["SR_NO"]), (object)","), RsIdtl.Rows[DC_Main.R]["OLD_SRNO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), RsIdtl.Rows[DC_Main.R]["VCH_TYPE"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["INOUT_TYPE"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["ENTRY_TYPE"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["BOOK_NAME"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["AC_CODE"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["TAG_NO"]), (object)"',"), RsIdtl.Rows[DC_Main.R]["VCH_SRNO"]), (object)",'"), RsIdtl.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["IT_TYPE"]), (object)"', "), (object)" '"), RsIdtl.Rows[DC_Main.R]["DM_CODE"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["DM_SIZE"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["DM_SFNO"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["DM_LEB"]), (object)"',");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_PCS"]);
							double num46 = DC_Main.Fnv(ref Value);
							dataRow["IT_PCS"] = RuntimeHelpers.GetObjectValue(Value);
							object obj47 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj46, (object)num46), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_PCS_WT"]);
							double num47 = DC_Main.Fnv(ref Value);
							dataRow["IT_PCS_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj48 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj47, (object)num47), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_WT"]);
							double num48 = DC_Main.Fnv(ref Value);
							dataRow["KR_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj49 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj48, (object)num48), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_LESS_PRC"]);
							double num49 = DC_Main.Fnv(ref Value);
							dataRow["KR_LESS_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							object obj50 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj49, (object)num49), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_GWT"]);
							double num50 = DC_Main.Fnv(ref Value);
							dataRow["IT_GWT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj51 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj50, (object)num50), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_CON_PRC"]);
							double num51 = DC_Main.Fnv(ref Value);
							dataRow["IT_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							object obj52 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj51, (object)num51), (object)", "), (object)" ");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_CON_WT"]);
							double num52 = DC_Main.Fnv(ref Value);
							dataRow["IT_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj53 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj52, (object)num52), (object)",'"), RsIdtl.Rows[DC_Main.R]["IT_RATE_TYPE"]), (object)"',");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_RATE"]);
							double num53 = DC_Main.Fnv(ref Value);
							dataRow["IT_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj54 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj53, (object)num53), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_AMT"]);
							double num54 = DC_Main.Fnv(ref Value);
							dataRow["IT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj55 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj54, (object)num54), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_LBR_RATE"]);
							double num55 = DC_Main.Fnv(ref Value);
							dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj56 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj55, (object)num55), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_LBR_AMT"]);
							double num56 = DC_Main.Fnv(ref Value);
							dataRow["IT_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj57 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj56, (object)num56), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["IT_NET_AMT"]);
							double num57 = DC_Main.Fnv(ref Value);
							dataRow["IT_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj58 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj57, (object)num57), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_CON_PRC"]);
							double num58 = DC_Main.Fnv(ref Value);
							dataRow["KR_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							object obj59 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj58, (object)num58), (object)", "), (object)" ");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_CON_WT"]);
							double num59 = DC_Main.Fnv(ref Value);
							dataRow["KR_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj60 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj59, (object)num59), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_RATE"]);
							double num60 = DC_Main.Fnv(ref Value);
							dataRow["KR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj61 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj60, (object)num60), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_AMT"]);
							double num61 = DC_Main.Fnv(ref Value);
							dataRow["KR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj62 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj61, (object)num61), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_LBR_RATE"]);
							double num62 = DC_Main.Fnv(ref Value);
							dataRow["KR_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj63 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj62, (object)num62), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_LBR_AMT"]);
							double num63 = DC_Main.Fnv(ref Value);
							dataRow["KR_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj64 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj63, (object)num63), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["KR_NET_AMT"]);
							double num64 = DC_Main.Fnv(ref Value);
							dataRow["KR_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj65 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj64, (object)num64), (object)",'");
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsIdtl.Rows[DC_Main.R])["MAIN_USER"]);
							double num65 = DC_Main.Fnv(ref Value);
							dataRow["MAIN_USER"] = RuntimeHelpers.GetObjectValue(Value);
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj65, (object)num65), (object)"', "), (object)" '"), RsIdtl.Rows[DC_Main.R]["DM_NAME"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["DM_ORIGIN"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["DM_REMARK"]), (object)"','"), RsIdtl.Rows[DC_Main.R]["DM_COLOR"]), (object)"')"));
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							DC_Main.R++;
						}
					}
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			Interaction.MsgBox((object)"Process Are Complete....Please A Data Refersh and Check Stock.....", (MsgBoxStyle)64, (object)null);
		}
	}
}
