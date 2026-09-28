using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class MS_STYLE : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tStyleName")]
	private TextBox _tStyleName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Text1")]
	private TextBox _Text1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDelete")]
	private SimpleButton _BtnDelete;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCancel")]
	private SimpleButton _BtnCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private SimpleButton _BtnSave;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private double ColCon;

	private string CurDgvClear;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string CurMast;

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

	internal virtual TextBox tStyleName
	{
		[CompilerGenerated]
		get
		{
			return _tStyleName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPrName_KeyDown);
			CancelEventHandler cancelEventHandler = tPrName_Validating;
			TextBox val2 = _tStyleName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).Validating -= cancelEventHandler;
			}
			_tStyleName = value;
			val2 = _tStyleName;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).Validating += cancelEventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label1")]
	private virtual Label _Label1;

	internal virtual Label Label1
	{
		get
		{
			return _Label1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label1 = value;
		}
	}

	public virtual TextBox Text1
	{
		[CompilerGenerated]
		get
		{
			return _Text1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Text1_TextChanged;
			EventHandler eventHandler2 = Text1_Click;
			TextBox val = _Text1;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
				((TextBoxBase)val).Click -= eventHandler2;
			}
			_Text1 = value;
			val = _Text1;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
				((TextBoxBase)val).Click += eventHandler2;
			}
		}
	}

	internal virtual DataGridViewX DGV
	{
		[CompilerGenerated]
		get
		{
			return _DGV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(DGV_KeyDown);
			EventHandler eventHandler = DGV_DoubleClick;
			DataGridViewX val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV = value;
			val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler;
			}
		}
	}

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

	internal virtual SimpleButton BtnDelete
	{
		[CompilerGenerated]
		get
		{
			return _BtnDelete;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDelete_Click;
			SimpleButton val = _BtnDelete;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnDelete = value;
			val = _BtnDelete;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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

	public MS_STYLE()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += MS_STYLE_Load;
		((Form)this).Activated += MS_STYLE_Activated;
		((Form)this).Deactivate += UT_TASTING_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(UT_TASTING_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_STYLE_KeyDown);
		((Form)this).Closed += MS_STYLE_Closed;
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
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Expected O, but got Unknown
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected O, but got Unknown
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Expected O, but got Unknown
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Expected O, but got Unknown
		//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e1: Expected O, but got Unknown
		//IL_0644: Unknown result type (might be due to invalid IL or missing references)
		//IL_064e: Expected O, but got Unknown
		//IL_06bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c7: Expected O, but got Unknown
		//IL_0798: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a2: Expected O, but got Unknown
		//IL_0885: Unknown result type (might be due to invalid IL or missing references)
		//IL_088f: Expected O, but got Unknown
		//IL_08f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fc: Expected O, but got Unknown
		//IL_096b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0975: Expected O, but got Unknown
		//IL_09d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e2: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_STYLE));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		lblBook = new Label();
		tStyleName = new TextBox();
		Label1 = new Label();
		Text1 = new TextBox();
		DGV = new DataGridViewX();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		((ISupportInitialize)DGV).BeginInit();
		((Control)PnlBotam).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		componentResourceManager.ApplyResources(lblBook, "lblBook");
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		((Control)lblBook).Name = "lblBook";
		((TextBoxBase)tStyleName).BackColor = Color.White;
		componentResourceManager.ApplyResources(tStyleName, "tStyleName");
		((Control)tStyleName).Name = "tStyleName";
		componentResourceManager.ApplyResources(Label1, "Label1");
		((Control)Label1).ForeColor = Color.Black;
		((Control)Label1).Name = "Label1";
		Text1.AcceptsReturn = true;
		((TextBoxBase)Text1).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)Text1).BorderStyle = (BorderStyle)0;
		((Control)Text1).Cursor = Cursors.IBeam;
		componentResourceManager.ApplyResources(Text1, "Text1");
		((TextBoxBase)Text1).ForeColor = Color.Navy;
		((Control)Text1).Name = "Text1";
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val2;
		componentResourceManager.ApplyResources(DGV, "DGV");
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val3;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		((DataGridView)DGV).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV).RowHeadersVisible = false;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((DataGridView)DGV).StandardTab = true;
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		componentResourceManager.ApplyResources(PnlBotam, "PnlBotam");
		((Control)PnlBotam).Name = "PnlBotam";
		((BaseStyleControl)BtnExit).Appearance.Font = (Font)componentResourceManager.GetObject("BtnExit.Appearance.Font");
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExit.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnExit, "BtnExit");
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = (Font)componentResourceManager.GetObject("BtnDelete.Appearance.Font");
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = Resources.actions_trash;
		componentResourceManager.ApplyResources(BtnDelete, "BtnDelete");
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = (Font)componentResourceManager.GetObject("BtnCancel.Appearance.Font");
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		componentResourceManager.ApplyResources(BtnCancel, "BtnCancel");
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = (Font)componentResourceManager.GetObject("BtnSave.Appearance.Font");
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnSave, "BtnSave");
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = (Font)componentResourceManager.GetObject("BtnPrint.Appearance.Font");
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		componentResourceManager.ApplyResources(BtnPrint, "BtnPrint");
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		componentResourceManager.ApplyResources(this, "$this");
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)Text1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)tStyleName);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_STYLE";
		((ISupportInitialize)DGV).EndInit();
		((Control)PnlBotam).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
	}

	private void MS_STYLE_Load(object sender, EventArgs e)
	{
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_079f: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a6: Expected O, but got Unknown
		//IL_080b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0810: Unknown result type (might be due to invalid IL or missing references)
		//IL_081a: Expected O, but got Unknown
		//IL_08a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b1: Expected O, but got Unknown
		//IL_0923: Unknown result type (might be due to invalid IL or missing references)
		//IL_0928: Unknown result type (might be due to invalid IL or missing references)
		//IL_092e: Expected O, but got Unknown
		//IL_09e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ef: Expected O, but got Unknown
		//IL_0a0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1d: Expected O, but got Unknown
		//IL_0a3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4b: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurMast = DC_Main.MsUserRightForm;
		lblBook.Text = CurMast;
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
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				Label obj2 = lblBook;
				object? obj3 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj2).BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
				Label obj4 = lblBook;
				object? obj5 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj4).ForeColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				((DataGridView)DGV).BackgroundColor = Color.DarkGray;
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj8 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.SlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DataGridViewX dGV = DGV;
				object? obj9 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj10 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj11 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj12 = lblBook;
				object? obj13 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj12).ForeColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj14 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				DataGridViewX dGV2 = DGV;
				object? obj15 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj16 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tStyleName).Font.Size * (1.0 + num2));
				Font font = ((Control)tStyleName).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
				}
				finally
				{
					((IDisposable)font)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((Control)lblBook).Font.Size * (1.0 + num2));
				((Control)lblBook).Font = new Font(((Control)lblBook).Font.FontFamily, (float)num3, ((Control)lblBook).Font.Style);
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnSave).Font.Size * (1.0 + num2));
				Font font2 = ((BaseStyleControl)BtnSave).Font;
				try
				{
					foreach (object control4 in ((Control)PnlBotam).Controls)
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(control4);
						NewLateBinding.LateSet(objectValue2, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
				}
			}
			if (Operators.CompareString(CurMast, "Design", false) == 0)
			{
				((TextBoxBase)tStyleName).MaxLength = 40;
				DC_Main.RsQry = "SELECT DESIGN_NO AS STYLE_NAME FROM DESIGN_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY DESIGN_NO ";
			}
			else if (Operators.CompareString(CurMast, "Style", false) == 0)
			{
				((TextBoxBase)tStyleName).MaxLength = 30;
				DC_Main.RsQry = "SELECT MODEL_NAME AS STYLE_NAME FROM MODEL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY MODEL_NAME ";
			}
			else if (Operators.CompareString(CurMast, "Item City", false) == 0)
			{
				((TextBoxBase)tStyleName).MaxLength = 30;
				DC_Main.RsQry = "SELECT ITM_CITY AS STYLE_NAME FROM ITM_CITY WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY ITM_CITY ";
			}
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DGV_FILL();
			EntryMode = "A";
			CurActCtrl = (Control)(object)tStyleName;
		}
	}

	private void MS_STYLE_Activated(object sender, EventArgs e)
	{
		((ContainerControl)this).ActiveControl = CurActCtrl;
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV).DataSource = null;
	}

	private void DGV_FILL()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		DGV_CLEAR();
		DataView dataView = new DataView(RsMast);
		if (dataView.Count > 0)
		{
			((DataGridView)DGV).MultiSelect = false;
			((DataGridView)DGV).AutoGenerateColumns = false;
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 11f, (FontStyle)1);
			if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
				((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
				((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
				((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
			}
			((DataGridView)DGV).ColumnCount = 1;
			((DataGridView)DGV).Columns[0].Width = checked((int)Math.Round(350.0 * ColCon));
			((DataGridView)DGV).Columns[0].DataPropertyName = "STYLE_NAME";
			((DataGridView)DGV).Columns[0].HeaderText = "Name";
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			((DataGridView)DGV).DataSource = dataView;
		}
	}

	private void CLEAR_DATA()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		CurDgvClear = "N";
		foreach (Control control in ((Control)this).Controls)
		{
			Control val = control;
			if (val is TextBox)
			{
				val.Text = "";
			}
		}
		MainUser = DC_Main.MCo_User;
		CurDgvClear = "Y";
		Text1.Text = "SEARCH RECORD";
		DGV_CLEAR();
		DGV_FILL();
		EntryMode = "A";
		((Control)tStyleName).Focus();
	}

	private void DISPLAY_DATA()
	{
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = "STYLE_NAME = '" + tStyleName.Text + "'";
		if (dataView.Count > 0)
		{
			DataView dataView2 = dataView;
			tStyleName.Text = Conversions.ToString(Operators.ConcatenateObject(dataView2[0]["STYLE_NAME"], (object)""));
			dataView2 = null;
			EntryMode = "E";
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void UT_TASTING_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void UT_TASTING_KeyPress(object sender, KeyPressEventArgs e)
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

	private void tPrName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tStyleName.Text, "", false) == 0)
		{
			if (Operators.CompareString(CurMast, "Design", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert Design Name ...", (MsgBoxStyle)0, (object)null);
			}
			else if (Operators.CompareString(CurMast, "Style", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert Model Name ...", (MsgBoxStyle)0, (object)null);
			}
			else if (Operators.CompareString(CurMast, "Item City", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert Item City Name ...", (MsgBoxStyle)0, (object)null);
			}
			((Control)tStyleName).Focus();
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tPrName_Validating(object sender, CancelEventArgs e)
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		if (RsMast.Rows.Count == 0)
		{
			return;
		}
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = "STYLE_NAME = '" + tStyleName.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["STYLE_NAME"], (object)tStyleName.Text, false))
			{
				if (Operators.CompareString(CurMast, "Design", false) == 0)
				{
					Interaction.MsgBox((object)"This Design Name already Exist Please Change It...", (MsgBoxStyle)0, (object)null);
				}
				else if (Operators.CompareString(CurMast, "Style", false) == 0)
				{
					Interaction.MsgBox((object)"This Style Name already Exist Please Change It...", (MsgBoxStyle)0, (object)null);
				}
				else if (Operators.CompareString(CurMast, "Item City", false) == 0)
				{
					Interaction.MsgBox((object)"This Item City Name already Exist Please Change It...", (MsgBoxStyle)0, (object)null);
				}
				cancel = true;
				((TextBoxBase)tStyleName).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void Text1_TextChanged(object sender, EventArgs e)
	{
		if (((Operators.CompareString(Text1.Text, "", false) == 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0)) && Operators.CompareString(CurDgvClear, "N", false) != 0)
		{
			DGV_FILL();
		}
		else if ((Operators.CompareString(Text1.Text, "", false) != 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
		{
			DGV_CLEAR();
			DataView dataView = new DataView(RsMast);
			dataView.RowFilter = "STYLE_NAME Like  '" + Text1.Text + "%' ";
			if (dataView.Count > 0)
			{
				((DataGridView)DGV).AutoGenerateColumns = false;
				((DataGridView)DGV).Columns[0].Width = 350;
				((DataGridView)DGV).Columns[0].DataPropertyName = "STYLE_NAME";
				((DataGridView)DGV).DataSource = dataView;
			}
		}
	}

	private void MS_STYLE_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
		if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))
		{
			((Control)DGV).Focus();
		}
	}

	private void Text1_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) == 0)
		{
			Text1.Text = "";
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
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
					if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
					{
						Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
					ProjectData.ClearProjectError();
					num2 = 2;
					if (Operators.CompareString(tStyleName.Text, "", false) == 0)
					{
						if (Operators.CompareString(CurMast, "Design", false) == 0)
						{
							Interaction.MsgBox((object)"Enter Design First...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						}
						else if (Operators.CompareString(CurMast, "Style", false) == 0)
						{
							Interaction.MsgBox((object)"Enter Style Name First.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						}
						else if (Operators.CompareString(CurMast, "Item City", false) == 0)
						{
							Interaction.MsgBox((object)"Enter Item City First....", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						}
						((Control)tStyleName).Focus();
						goto end_IL_0001;
					}
					if (Operators.CompareString(CurMast, "Design", false) == 0)
					{
						DC_Main.RsQry = "DELETE FROM DESIGN_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  DESIGN_NO = '" + tStyleName.Text + "'";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = "INSERT INTO DESIGN_MAST(CO_CODE,DESIGN_NO,MAIN_USER) VALUES  ('" + DC_Main.MCo_code + "','" + tStyleName.Text + "','" + MainUser + "')";
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						DC_Main.RsQry = "SELECT DESIGN_NO AS STYLE_NAME FROM DESIGN_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY DESIGN_NO ";
						RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					else if (Operators.CompareString(CurMast, "Style", false) == 0)
					{
						DC_Main.RsQry = "DELETE FROM MODEL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  MODEL_NAME = '" + tStyleName.Text + "'";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = "INSERT INTO MODEL_MAST(CO_CODE,MODEL_NAME,MAIN_USER) VALUES  ('" + DC_Main.MCo_code + "','" + tStyleName.Text + "','" + MainUser + "')";
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						DC_Main.RsQry = "SELECT MODEL_NAME AS STYLE_NAME FROM MODEL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY MODEL_NAME ";
						RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					else if (Operators.CompareString(CurMast, "Item City", false) == 0)
					{
						DC_Main.RsQry = "DELETE FROM ITM_CITY WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  ITM_CITY = '" + tStyleName.Text + "'";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = "INSERT INTO ITM_CITY (CO_CODE,ITM_CITY,MAIN_USER) VALUES  ('" + DC_Main.MCo_code + "','" + tStyleName.Text + "','" + MainUser + "')";
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						DC_Main.RsQry = "SELECT ITM_CITY AS STYLE_NAME FROM ITM_CITY WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY ITM_CITY ";
						RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					}
					if (DC_Main.MsCreat)
					{
						DC_Main.MsName = tStyleName.Text;
						((Form)this).Close();
					}
					else
					{
						CLEAR_DATA();
						DGV_FILL();
					}
					goto end_IL_0001;
				case 1118:
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
				try0001_dispatch = 1118;
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

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(tStyleName.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Style For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Record now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			if (Operators.CompareString(CurMast, "Design", false) == 0)
			{
				DC_Main.RsQry = "DELETE FROM DESIGN_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  DESIGN_NO = '" + tStyleName.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				CLEAR_DATA();
				DC_Main.RsQry = "SELECT DESIGN_NO AS STYLE_NAME FROM DESIGN_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY DESIGN_NO ";
				RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else if (Operators.CompareString(CurMast, "Style", false) == 0)
			{
				DC_Main.RsQry = "DELETE FROM MODEL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  MODEL_NAME = '" + tStyleName.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				CLEAR_DATA();
				DC_Main.RsQry = "SELECT MODEL_NAME AS STYLE_NAME FROM MODEL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY MODEL_NAME ";
				RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			else if (Operators.CompareString(CurMast, "Item City", false) == 0)
			{
				DC_Main.RsQry = "DELETE FROM ITM_CITY WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  ITM_CITY = '" + tStyleName.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				CLEAR_DATA();
				DC_Main.RsQry = "SELECT ITM_CITY AS STYLE_NAME FROM ITM_CITY WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY ITM_CITY ";
				RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			}
			CLEAR_DATA();
		}
	}

	private void DGV_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Invalid comparison between Unknown and I4
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
				case 327:
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
							goto IL_001b;
						case 6:
							goto IL_0034;
						case 7:
							goto IL_0046;
						case 8:
							goto IL_0074;
						case 9:
							goto IL_007d;
						case 11:
							goto IL_008f;
						case 12:
							goto IL_00a1;
						case 13:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 4:
						case 5:
						case 10:
						case 14:
						case 15:
						case 16:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_007d:
					num2 = 9;
					((Control)tStyleName).Focus();
					goto end_IL_0001_3;
					IL_008f:
					num2 = 11;
					if ((int)e.KeyCode != 8)
					{
						goto end_IL_0001_3;
					}
					goto IL_00a1;
					IL_0074:
					num2 = 8;
					DISPLAY_DATA();
					goto IL_007d;
					IL_00a1:
					num2 = 12;
					if (Strings.Len(Text1.Text) <= 0)
					{
						goto end_IL_0001_3;
					}
					break;
					IL_000b:
					num2 = 2;
					if ((int)e.KeyCode == 112)
					{
						goto IL_001b;
					}
					goto IL_0034;
					IL_001b:
					num2 = 3;
					((Control)Text1).Focus();
					goto end_IL_0001_3;
					IL_0034:
					num2 = 6;
					if ((int)e.KeyCode == 13)
					{
						goto IL_0046;
					}
					goto IL_008f;
					IL_0046:
					num2 = 7;
					tStyleName.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
					goto IL_0074;
					end_IL_0001_2:
					break;
				}
				num2 = 13;
				Text1.Text = Strings.Mid(Text1.Text, 1, checked(Strings.Len(Text1.Text) - 1));
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 327;
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

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		tStyleName.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
		DISPLAY_DATA();
		((Control)tStyleName).Focus();
	}

	private void MS_STYLE_Closed(object sender, EventArgs e)
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
}
