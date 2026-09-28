using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class MS_YEAR : Form
{
	private IContainer components;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tYearCode")]
	private TextBox _tYearCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMonth")]
	private TextBox _tMonth;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mOpDate")]
	private MaskedTextBox _mOpDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mClDate")]
	private MaskedTextBox _mClDate;

	private Control CurActCtrl;

	private double ColCon;

	private DataTable RsMast;

	private string EntryMode;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

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
	[AccessedThroughProperty("Cr")]
	private virtual AxCrystalReport _Cr;

	internal virtual AxCrystalReport Cr
	{
		get
		{
			return _Cr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Cr = value;
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
			TextBox val2 = _tYearCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tYearCode = value;
			val2 = _tYearCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tMonth
	{
		[CompilerGenerated]
		get
		{
			return _tMonth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tMonth_KeyDown);
			TextBox val2 = _tMonth;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tMonth = value;
			val2 = _tMonth;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label2")]
	private virtual Label _Label2;

	internal virtual Label Label2
	{
		get
		{
			return _Label2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label2 = value;
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

	internal virtual MaskedTextBox mOpDate
	{
		[CompilerGenerated]
		get
		{
			return _mOpDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = mOpDate_GotFocus;
			KeyEventHandler val = new KeyEventHandler(mOpDate_KeyDown);
			MaskedTextBox val2 = _mOpDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_mOpDate = value;
			val2 = _mOpDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label3")]
	private virtual Label _Label3;

	internal virtual Label Label3
	{
		get
		{
			return _Label3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label3 = value;
		}
	}

	internal virtual MaskedTextBox mClDate
	{
		[CompilerGenerated]
		get
		{
			return _mClDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = mClDate_GotFocus;
			KeyEventHandler val = new KeyEventHandler(mClDate_KeyDown);
			MaskedTextBox val2 = _mClDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_mClDate = value;
			val2 = _mClDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	public MS_YEAR()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((Form)this).Load += MS_YEAR_Load;
		((Form)this).Deactivate += MS_YEAR_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_YEAR_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_YEAR_KeyDown);
		((Form)this).Closed += MS_YEAR_Closed;
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
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected O, but got Unknown
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Expected O, but got Unknown
		//IL_056c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0576: Expected O, but got Unknown
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e3: Expected O, but got Unknown
		//IL_068c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0696: Expected O, but got Unknown
		//IL_06f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0703: Expected O, but got Unknown
		//IL_07da: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e4: Expected O, but got Unknown
		//IL_0852: Unknown result type (might be due to invalid IL or missing references)
		//IL_085c: Expected O, but got Unknown
		//IL_090e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0918: Expected O, but got Unknown
		//IL_0999: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a3: Expected O, but got Unknown
		//IL_0a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3b: Expected O, but got Unknown
		//IL_0ad8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae2: Expected O, but got Unknown
		//IL_0b93: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9d: Expected O, but got Unknown
		//IL_0c23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2d: Expected O, but got Unknown
		//IL_0ce1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ceb: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_YEAR));
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tYearCode = new TextBox();
		tMonth = new TextBox();
		Label2 = new Label();
		Label1 = new Label();
		mOpDate = new MaskedTextBox();
		Label3 = new Label();
		mClDate = new MaskedTextBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)Cr);
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
		((Control)BtnExit).TabIndex = 3;
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
		((Control)BtnDelete).TabIndex = 2;
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
		((Control)BtnCancel).TabIndex = 1;
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
		((Control)BtnPrint).TabIndex = 4;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(793, 3);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 10;
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
		lblBook.Text = "Year Create";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tYearCode).BackColor = Color.White;
		((Control)tYearCode).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tYearCode).Location = new Point(558, 199);
		((TextBoxBase)tYearCode).MaxLength = 15;
		((Control)tYearCode).Name = "tYearCode";
		((Control)tYearCode).Size = new Size(89, 22);
		((Control)tYearCode).TabIndex = 0;
		((TextBoxBase)tMonth).BackColor = Color.White;
		((Control)tMonth).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tMonth).Location = new Point(653, 199);
		((TextBoxBase)tMonth).MaxLength = 15;
		((Control)tMonth).Name = "tMonth";
		((Control)tMonth).Size = new Size(36, 22);
		((Control)tMonth).TabIndex = 1;
		((Control)tMonth).Visible = false;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(428, 199);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(124, 20);
		((Control)Label2).TabIndex = 15;
		Label2.Text = "Create New Year";
		Label2.TextAlign = (ContentAlignment)64;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(432, 227);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(121, 20);
		((Control)Label1).TabIndex = 124;
		Label1.Text = "Opening Date";
		Label1.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mOpDate).BackColor = Color.White;
		((Control)mOpDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mOpDate).Location = new Point(558, 227);
		mOpDate.Mask = "00/00/0000";
		((Control)mOpDate).Name = "mOpDate";
		((Control)mOpDate).Size = new Size(89, 23);
		((Control)mOpDate).TabIndex = 2;
		mOpDate.ValidatingType = typeof(DateTime);
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(392, 256);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(160, 20);
		((Control)Label3).TabIndex = 126;
		Label3.Text = "Closing Date";
		Label3.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mClDate).BackColor = Color.White;
		((Control)mClDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mClDate).Location = new Point(558, 256);
		mClDate.Mask = "00/00/0000";
		((Control)mClDate).Name = "mClDate";
		((Control)mClDate).Size = new Size(89, 23);
		((Control)mClDate).TabIndex = 3;
		mClDate.ValidatingType = typeof(DateTime);
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)mClDate);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)mOpDate);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tYearCode);
		((Control)this).Controls.Add((Control)(object)tMonth);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_YEAR";
		((Form)this).Text = "Year Create";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MS_YEAR_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_064d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0654: Expected O, but got Unknown
		//IL_06b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06be: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c8: Expected O, but got Unknown
		//IL_0750: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Unknown result type (might be due to invalid IL or missing references)
		//IL_075f: Expected O, but got Unknown
		//IL_07d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07dc: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
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
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj8 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj9 = lblBook;
				object? obj10 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj9).ForeColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj11 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tYearCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tYearCode).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is SimpleButton || val3 is MaskedTextBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
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
			}
			CLEAR_DATA();
			if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)
			{
				tMonth.Text = Strings.Format((object)DateAndTime.Now, "MM");
				((Control)tMonth).Visible = true;
			}
			else
			{
				((Control)tMonth).Visible = false;
				tMonth.Text = "04";
			}
			EntryMode = "A";
			CurActCtrl = (Control)(object)tYearCode;
		}
	}

	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "SELECT * FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + tYearCode.Text + "' AND YEAR_MONTH = '" + tMonth.Text + "' ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			tYearCode.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
			tMonth.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["YEAR_MONTH"], (object)""));
			mOpDate.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OP_DATE"], (object)""));
			mClDate.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CL_DATE"], (object)""));
			EntryMode = "E";
		}
		else
		{
			EntryMode = "A";
		}
	}

	private void CLEAR_DATA()
	{
		BtnCancel_Click(BtnCancel, new EventArgs());
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void MS_YEAR_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_YEAR_KeyPress(object sender, KeyPressEventArgs e)
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

	private void MS_YEAR_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This User now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "SELECT * FROM  LOGIN_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LOGIN_NAME = '" + tYearCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			DC_Main.ExeQuteMc("DELETE FROM LOGIN_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  LOGIN_NAME = '" + tYearCode.Text + "'");
			DC_Main.ExeQuteMc("DELETE FROM USER_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  USER_NAME = '" + tYearCode.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			DC_Main.RsQry = "SELECT * FROM LOGIN_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY LOGIN_NAME ";
			RsMast = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
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
		if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)
		{
			tMonth.Text = Strings.Mid(Conversions.ToString(DateAndTime.Today), 4, 2);
			if ((DateAndTime.Month(DateAndTime.Today) > 3) & (DateAndTime.Month(DateAndTime.Today) <= 12))
			{
				tYearCode.Text = Strings.Mid(Conversions.ToString(DateAndTime.Today), 7, 4) + "-" + Conversions.ToString(Conversions.ToDouble(Strings.Mid(Conversions.ToString(DateAndTime.Today), 7, 4)) + 1.0);
				mOpDate.Text = "01/" + tMonth.Text + "/" + Strings.Mid(tYearCode.Text, 1, 4);
				mClDate.Text = "01/" + tMonth.Text + "/" + Strings.Mid(tYearCode.Text, 6, 4);
			}
			else
			{
				tYearCode.Text = Conversions.ToString(Conversions.ToDouble(Strings.Mid(Conversions.ToString(DateAndTime.Today), 7, 4)) - 1.0) + "-" + Strings.Mid(Conversions.ToString(DateAndTime.Today), 7, 4);
				mOpDate.Text = "01/" + tMonth.Text + "/" + Strings.Mid(tYearCode.Text, 6, 4);
				mClDate.Text = "01/" + tMonth.Text + "/" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(tYearCode.Text, 6, 4)) + 1.0), "00");
			}
		}
		else if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
		{
			tYearCode.Text = Strings.Mid(Conversions.ToString(DateAndTime.Today), 7, 4) + "-" + Conversions.ToString(Conversions.ToDouble(Strings.Mid(Conversions.ToString(DateAndTime.Today), 7, 4)) + 1.0);
			mOpDate.Text = "01/01/" + Strings.Mid(tYearCode.Text, 1, 4);
			mClDate.Text = "31/12/" + Strings.Mid(tYearCode.Text, 1, 4);
			tMonth.Text = "01";
		}
		else
		{
			if ((DateAndTime.Month(DateAndTime.Today) > 3) & (DateAndTime.Month(DateAndTime.Today) <= 12))
			{
				tYearCode.Text = Strings.Mid(Conversions.ToString(DateAndTime.Today), 7, 4) + "-" + Conversions.ToString(Conversions.ToDouble(Strings.Mid(Conversions.ToString(DateAndTime.Today), 7, 4)) + 1.0);
				mOpDate.Text = "01/04/" + Strings.Mid(tYearCode.Text, 1, 4);
				mClDate.Text = "31/03/" + Strings.Mid(tYearCode.Text, 6, 4);
			}
			else
			{
				tYearCode.Text = Conversions.ToString(Conversions.ToDouble(Strings.Mid(Conversions.ToString(DateAndTime.Today), 7, 4)) - 1.0) + "-" + Strings.Mid(Conversions.ToString(DateAndTime.Today), 7, 4);
				mOpDate.Text = "01/04/" + Strings.Mid(tYearCode.Text, 1, 4);
				mClDate.Text = "31/03/" + Strings.Mid(tYearCode.Text, 6, 4);
			}
			tMonth.Text = "04";
		}
		EntryMode = "A";
		if (Operators.CompareString(tYearCode.Text, "", false) != 0)
		{
			DISPLAY_DATA();
		}
		((Control)tYearCode).Focus();
	}

	private void MS_YEAR_Closed(object sender, EventArgs e)
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

	private void tMonth_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tYearCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13 && Operators.CompareString(tYearCode.Text, "", false) != 0)
		{
			DISPLAY_DATA();
			SendKeys.Send("{tab}");
		}
	}

	private void mOpDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mOpDate).SelectionStart = 0;
		((TextBoxBase)mOpDate).SelectionLength = Strings.Len(mOpDate.Text);
	}

	private void mOpDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		MaskedTextBox MsDate = mOpDate;
		DC_Main.SetDate(ref MsDate);
		mOpDate = MsDate;
		if (!DC_Main.RongDate)
		{
			if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)
			{
				tMonth.Text = Strings.Mid(mOpDate.Text, 4, 2);
			}
			SendKeys.Send("{TAB}");
		}
	}

	private void mClDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mClDate).SelectionStart = 0;
		((TextBoxBase)mClDate).SelectionLength = Strings.Len(mClDate.Text);
	}

	private void mClDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mClDate;
			DC_Main.SetDate(ref MsDate);
			mClDate = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{TAB}");
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_146a: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_137f: Unknown result type (might be due to invalid IL or missing references)
		//IL_144d: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		bool flag = false;
		if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM YEAR_MAST WHERE CO_YEAR = '" + Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text + "' AND YEAR_MONTH = '" + tMonth.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				flag = true;
			}
		}
		else
		{
			DC_Main.RsQry = "SELECT * FROM YEAR_MAST WHERE  CO_YEAR = '" + tYearCode.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				flag = true;
			}
		}
		if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)
		{
			DC_Main.ExeQuteMc("DELETE FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text + "' AND YEAR_MONTH = '" + tMonth.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text + "' AND YEAR_MONTH = '" + tMonth.Text + "'");
			DC_Main.RsQry = "SELECT * FROM YEAR_MAST  WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text + "' AND YEAR_MONTH = '" + tMonth.Text + "'";
		}
		else
		{
			DC_Main.ExeQuteMc("DELETE FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + tYearCode.Text + "' AND YEAR_MONTH = '" + tMonth.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + tYearCode.Text + "' AND YEAR_MONTH = '" + tMonth.Text + "'");
			DC_Main.RsQry = "SELECT * FROM YEAR_MAST  WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + tYearCode.Text + "' AND YEAR_MONTH = '" + tMonth.Text + "'";
		}
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow = DC_Main.Rshlp.NewRow();
		dataRow["CO_CODE"] = DC_Main.MCo_code;
		if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)
		{
			dataRow["CO_YEAR"] = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;
		}
		else
		{
			dataRow["CO_YEAR"] = tYearCode.Text;
		}
		dataRow["OP_DATE"] = mOpDate.Text;
		dataRow["CL_DATE"] = mClDate.Text;
		dataRow["OLD_METHOD"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0, (object)"N", (object)"Y"));
		dataRow["YEAR_MONTH"] = tMonth.Text;
		dataRow["MAIN_USER"] = DC_Main.MCo_User;
		DC_Main.Rshlp.Rows.Add(dataRow);
		((DbDataAdapter)(object)DC_Main.Da).Update(DC_Main.Rshlp);
		DC_Main.Rshlp.Clear();
		if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM YEAR_MAST  WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text + "' AND YEAR_MONTH = '" + tMonth.Text + "'";
		}
		else
		{
			DC_Main.RsQry = "SELECT * FROM YEAR_MAST  WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + tYearCode.Text + "' AND YEAR_MONTH = '" + tMonth.Text + "'";
		}
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow2 = DC_Main.Rshlp.NewRow();
		dataRow2["CO_CODE"] = DC_Main.MCo_code;
		if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)
		{
			dataRow2["CO_YEAR"] = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;
		}
		else
		{
			dataRow2["CO_YEAR"] = tYearCode.Text;
		}
		dataRow2["OP_DATE"] = mOpDate.Text;
		dataRow2["CL_DATE"] = mClDate.Text;
		dataRow2["OLD_METHOD"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0, (object)"N", (object)"Y"));
		dataRow2["YEAR_MONTH"] = tMonth.Text;
		dataRow2["MAIN_USER"] = DC_Main.MCo_User;
		DC_Main.Rshlp.Rows.Add(dataRow2);
		((DbDataAdapter)(object)DC_Main.Da).Update(DC_Main.Rshlp);
		DC_Main.Rshlp.Clear();
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			if (flag)
			{
				string text = ((Operators.CompareString(DC_Main.SSCompSrNo1, "A/FQKV5G3/CNCMK0018H02E0/Z", false) != 0) ? (((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\SqlData\\") : "D:\\DataCareNext\\SqlData\\");
				if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)
				{
					flag = false;
					string text2 = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\SqlData\\Next" + Strings.Mid(tYearCode.Text, 3, 2) + tMonth.Text + ".mdf";
					string text3 = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\SqlData\\Next" + Strings.Mid(tYearCode.Text, 3, 2) + tMonth.Text + ".ldf";
					string text4;
					string text5;
					if (Strings.Len(DC_Main.MCo_year) == 9)
					{
						text4 = "Next" + Strings.Mid(tYearCode.Text, 3, 2) + tMonth.Text;
						text5 = "Next" + Strings.Mid(DC_Main.MCo_year, 3, 2);
					}
					else
					{
						text4 = "Next" + Strings.Mid(tYearCode.Text, 3, 2) + tMonth.Text;
						text5 = "Next" + Strings.Mid(DC_Main.MCo_year, 3, 4);
					}
					if (Operators.CompareString(FileSystem.Dir(text2, (FileAttribute)0), "", false) == 0)
					{
						DC_Main.ExeQuteDc("BACKUP DATABASE " + DC_Main.SqlData + " TO DISK ='" + text + text5 + ".BAK' WITH COPY_ONLY");
						string text6 = text + "NextMain";
						if (Operators.CompareString(FileSystem.Dir(text6 + ".BAK", (FileAttribute)0), "", false) != 0)
						{
							FileSystem.Kill(text6 + ".BAK");
						}
						DC_Main.ExeQuteDc("BACKUP DATABASE " + DC_Main.SqlMain + " TO DISK ='" + text6 + ".BAK'");
						DC_Main.ExeQuteDc("CREATE DATABASE " + text4 + " ON PRIMARY(NAME = " + text4 + "_Data,FILENAME = '" + text2 + "',SIZE = 5MB,MAXSIZE = 300MB, FILEGROWTH = 10%)  LOG ON (NAME = " + text4 + "_Log,FILENAME = '" + text3 + "',SIZE = 1MB,MAXSIZE = 300MB,FILEGROWTH = 10%) ");
						string text7 = "";
						string text8 = "";
						DC_Main.Dc.ConnectionString = ("Data Source=" + DC_Main.SqlServer + ";Initial Catalog=master;Persist Security Info=True;User ID=" + DC_Main.SqlId + ";Password=" + DC_Main.SqlPwd) ?? "";
						DC_Main.RsQry = "USE [master]  RESTORE FILELISTONLY FROM  DISK = N'" + text + text5 + ".BAK' WITH  NOUNLOAD,  FILE = 1";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["LogicalName"], (object)"", false))
							{
								text7 = Conversions.ToString(DC_Main.Rshlp.Rows[0]["LogicalName"]);
							}
							if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Rshlp.Rows[1]["LogicalName"], (object)"", false))
							{
								text8 = Conversions.ToString(DC_Main.Rshlp.Rows[1]["LogicalName"]);
							}
						}
						DC_Main.RsQry = "USE [master] ALTER DATABASE [" + text4 + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE  RESTORE DATABASE " + text4 + " FROM  DISK = N'" + text + text5 + ".BAK'  WITH  FILE = 1,  MOVE N'" + text7 + "' TO N'" + text2 + "',  MOVE N'" + text8 + "' TO N'" + text3 + "',  NOUNLOAD,  REPLACE,  STATS = 10   ALTER DATABASE " + text4 + " SET MULTI_USER WITH ROLLBACK IMMEDIATE";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.ExeQuteDc("USE [master]   DBCC SHRINKDATABASE (N'" + text4 + "', 95)");
						DC_Main.ExeQuteDc("USE [master]   DBCC SHRINKDATABASE (" + text4 + ", TRUNCATEONLY);");
					}
				}
				else
				{
					flag = false;
					string text2;
					string text3;
					string text4;
					string text5;
					if (Operators.CompareString(DC_Main.MCo_Type, "P", false) == 0)
					{
						text2 = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\SqlData\\NxAc" + Strings.Mid(tYearCode.Text, 3, 2) + ".mdf";
						text3 = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\SqlData\\NxAc" + Strings.Mid(tYearCode.Text, 3, 2) + ".ldf";
						text4 = "NxAc" + Strings.Mid(tYearCode.Text, 3, 2);
						text5 = "NxAc" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(tYearCode.Text, 3, 2)) - 1.0), "00");
					}
					else if (Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0)
					{
						text2 = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\SqlData\\NxAb" + Strings.Mid(tYearCode.Text, 3, 2) + ".mdf";
						text3 = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\SqlData\\NxAb" + Strings.Mid(tYearCode.Text, 3, 2) + ".ldf";
						text4 = "NxAb" + Strings.Mid(tYearCode.Text, 3, 2);
						text5 = "NxAb" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(tYearCode.Text, 3, 2)) - 1.0), "00");
					}
					else if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/FQKV5G3/CNCMK0018H02E0/Z", false) == 0)
					{
						text2 = "D:\\DataCareNext\\SqlData\\Next" + Strings.Mid(tYearCode.Text, 3, 2) + ".mdf";
						text3 = "D:\\DataCareNext\\SqlData\\Next" + Strings.Mid(tYearCode.Text, 3, 2) + ".ldf";
						text4 = "Next" + Strings.Mid(tYearCode.Text, 3, 2);
						text5 = "Next" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(tYearCode.Text, 3, 2)) - 1.0), "00");
					}
					else
					{
						text2 = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\SqlData\\Next" + Strings.Mid(tYearCode.Text, 3, 2) + ".mdf";
						text3 = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\SqlData\\Next" + Strings.Mid(tYearCode.Text, 3, 2) + ".ldf";
						text4 = "Next" + Strings.Mid(tYearCode.Text, 3, 2);
						text5 = "Next" + Strings.Format((object)(Conversions.ToDouble(Strings.Mid(tYearCode.Text, 3, 2)) - 1.0), "00");
					}
					if (Operators.CompareString(FileSystem.Dir(text2, (FileAttribute)0), "", false) == 0)
					{
						if (Operators.CompareString(FileSystem.Dir(text + text5 + ".BAK", (FileAttribute)0), "", false) != 0)
						{
							FileSystem.Kill(text + text5 + ".BAK");
						}
						DC_Main.ExeQuteDc("BACKUP DATABASE " + DC_Main.SqlData + " TO DISK ='" + text + text5 + ".BAK' WITH COPY_ONLY");
						string text6 = text + "NextMain";
						if (Operators.CompareString(FileSystem.Dir(text6 + ".BAK", (FileAttribute)0), "", false) != 0)
						{
							FileSystem.Kill(text6 + ".BAK");
						}
						DC_Main.ExeQuteDc("BACKUP DATABASE " + DC_Main.SqlMain + " TO DISK ='" + text6 + ".BAK'");
						DC_Main.ExeQuteDc("CREATE DATABASE " + text4 + " ON PRIMARY(NAME = " + text4 + "_Data,FILENAME = '" + text2 + "',SIZE = 5MB,MAXSIZE = 300MB, FILEGROWTH = 10%)  LOG ON (NAME = " + text4 + "_Log,FILENAME = '" + text3 + "',SIZE = 1MB,MAXSIZE = 300MB,FILEGROWTH = 10%) ");
						string text9 = "";
						string text10 = "";
						DC_Main.Dc.ConnectionString = ("Data Source=" + DC_Main.SqlServer + ";Initial Catalog=master;Persist Security Info=True;User ID=" + DC_Main.SqlId + ";Password=" + DC_Main.SqlPwd) ?? "";
						DC_Main.RsQry = "USE [master]  RESTORE FILELISTONLY FROM  DISK = N'" + text + text5 + ".BAK' WITH  NOUNLOAD,  FILE = 1";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["LogicalName"], (object)"", false))
							{
								text9 = Conversions.ToString(DC_Main.Rshlp.Rows[0]["LogicalName"]);
							}
							if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Rshlp.Rows[1]["LogicalName"], (object)"", false))
							{
								text10 = Conversions.ToString(DC_Main.Rshlp.Rows[1]["LogicalName"]);
							}
						}
						DC_Main.RsQry = "USE [master] ALTER DATABASE [" + text4 + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE  RESTORE DATABASE " + text4 + " FROM  DISK = N'" + text + text5 + ".BAK'  WITH  FILE = 1,  MOVE N'" + text9 + "' TO N'" + text2 + "',  MOVE N'" + text10 + "' TO N'" + text3 + "',  NOUNLOAD,  REPLACE,  STATS = 10   ALTER DATABASE " + text4 + " SET MULTI_USER WITH ROLLBACK IMMEDIATE";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.ExeQuteDc("USE [master]   DBCC SHRINKDATABASE (N'" + text4 + "', 95)");
						DC_Main.ExeQuteDc("USE [master]   DBCC SHRINKDATABASE (" + text4 + ", TRUNCATEONLY);");
					}
				}
			}
			if (Operators.CompareString(DC_Main.NewCompCode, "", false) != 0)
			{
				DC_Main.NewYearCode = tYearCode.Text;
				NewCompParmCreat();
				Interaction.MsgBox((object)"All Master And Parameter are Created...Now ReOpen Sofware...", (MsgBoxStyle)0, (object)null);
			}
			else if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)
			{
				DC_Main.MCo_year = Strings.Mid(tYearCode.Text, 1, 4) + tMonth.Text;
				DC_Main.SqlData = "Next" + Strings.Mid(tYearCode.Text, 3, 2) + tMonth.Text;
				DC_Main.DataConYear();
				DeleteOldYear_Data();
				Interaction.MsgBox((object)"New Year are Created...Now ReOpen Sofware...", (MsgBoxStyle)0, (object)null);
			}
			else
			{
				DC_Main.MCo_year = tYearCode.Text;
				if (Operators.CompareString(DC_Main.MCo_Type, "P", false) == 0)
				{
					DC_Main.SqlData = "NxAc" + Strings.Mid(tYearCode.Text, 3, 2);
				}
				else if (Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0)
				{
					DC_Main.SqlData = "NxAb" + Strings.Mid(tYearCode.Text, 3, 2);
				}
				else
				{
					DC_Main.SqlData = "Next" + Strings.Mid(tYearCode.Text, 3, 2);
				}
				DC_Main.DataConYear();
				DeleteOldYear_Data();
				Interaction.MsgBox((object)"New Year are Created...Now ReOpen Sofware...", (MsgBoxStyle)0, (object)null);
			}
		}
		else
		{
			DC_Main.NewYearCode = "";
			Interaction.MsgBox((object)"Year Is Already Exist...Now ReOpen Sofware...", (MsgBoxStyle)0, (object)null);
			Application.Exit();
		}
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			Application.Exit();
		}
	}

	private void DeleteOldYear_Data()
	{
		DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM AD_ADJ WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM AD_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM AD_OS WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM APR_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM APR_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM APR_IDTL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM BANK_RECONCILE");
		DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_IDTL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM BILL_OS_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM BUL_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM CARD_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM CASH_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM CONTRA_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM CRNT_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM CUT_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM CUT_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM CUT_STK_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM DELETE_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM DHRN_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM DHRN_ISU_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM DHRN_ISU_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM DM_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM DM_KR_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM E_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM EMP_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM FINE_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM INOUT_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM INOUT_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM INOUT_IDTL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM ITM_LOT_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM ITM_OPBL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM KR_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM KR_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM KR_IDTL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM LBR_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_IDTL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM LBR_REC_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM LDR_ADJ_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM LOCT_AMT WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM LOT_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM MFG_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM MFG_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM MFG_IDTL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM MFG_ISU_REC WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM MLT_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM MLT_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM OP_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM OP_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM OP_LDR WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM PAY_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM PAY_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM PR_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM PR_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM PR_IDTL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU_REC WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_REC WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM RATE_MAST WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM REP_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM REP_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM ROJMEL_BAL");
		DC_Main.ExeQuteDc("DELETE FROM SL_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM SL_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM SL_DETL_RTN WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM SL_IDTL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM SL_ORD_ADJ WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM SL_ORD_IDTL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM SL_PR_DETL WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM TAG_SUM_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM TEMP_AD_DATA");
		DC_Main.ExeQuteDc("DELETE FROM TEMP_ADD");
		DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA ");
		DC_Main.ExeQuteDc("DELETE FROM UPI_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM USER_REQUEST WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM USER_DATA WHERE CO_CODE <> '" + DC_Main.MCo_code + "'");
		DC_Main.ExeQuteDc("DELETE FROM USER_REQUEST WHERE CO_CODE <> '" + DC_Main.MCo_code + "'");
		DC_Main.ExeQuteDc("DELETE FROM VP_ADJ_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
		DC_Main.ExeQuteDc("DELETE FROM WEB_DATA WHERE CO_YEAR <> '" + DC_Main.MCo_year + "'");
	}

	private void NewCompParmCreat()
	{
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Invalid comparison between Unknown and I4
		if (Operators.CompareString(DC_Main.MsOldCoCode, "", false) != 0)
		{
			DC_Main.ExeQuteDc("DELETE FROM AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO AC_GROUP (CO_CODE,AC_GR,AC_GR_NAME,AC_MAIN_GR,AC_SUB_GR,MAIN_USER)  SELECT '" + DC_Main.MCo_code + "',AC_GR,AC_GR_NAME,AC_MAIN_GR,AC_SUB_GR,MAIN_USER FROM AC_GROUP WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "'");
			if ((int)Interaction.MsgBox((object)("Import All Party from Ac Master Of " + DC_Main.MsOldCoCode + " Compnay...?"), (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
			{
				DC_Main.ExeQuteDc("DELETE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("INSERT INTO AC_MAST (CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_GST_TYPE,DATA_TRFR,AC_PERSON,AC_ADD1,AC_ADD2,AC_ADD3,AC_COUNTRY,AC_STATE,AC_DISTRICT,AC_CITY,AC_AREA,AC_PIN,AC_PHONE,AC_MOBILE,AC_EMAIL,AC_GSTNO,AC_PANNO,AC_ADHAR_NO,BR_DATE,AN_DATE)  SELECT '" + DC_Main.MCo_code + "',AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_GST_TYPE,'N',AC_PERSON,AC_ADD1,AC_ADD2,AC_ADD3,AC_COUNTRY,AC_STATE,AC_DISTRICT,AC_CITY,AC_AREA,AC_PIN,AC_PHONE,AC_MOBILE,AC_EMAIL,AC_GSTNO,AC_PANNO,AC_ADHAR_NO,BR_DATE,AN_DATE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "' AND LC_CODE = '00' ");
			}
			else
			{
				DC_Main.ExeQuteDc("DELETE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("INSERT INTO AC_MAST (CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_GST_TYPE,DATA_TRFR)  SELECT '" + DC_Main.MCo_code + "',AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_GST_TYPE,'N' FROM AC_MAST WHERE CO_CODE = '01' AND LC_CODE = '00' AND AC_CODE < '00101'");
			}
			DC_Main.ExeQuteDc("DELETE FROM BAL_GR WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO BAL_GR (CO_CODE,TRAD_TYPE,TRAD_NAME,SALE_AC,PURC_AC,CLOSING_AC,OP_AC,TRAD_AMT,TRAD_WT,CLG_AC)  SELECT '" + DC_Main.MCo_code + "',TRAD_TYPE,TRAD_NAME,SALE_AC,PURC_AC,CLOSING_AC,OP_AC,TRAD_AMT,TRAD_WT,CLG_AC FROM BAL_GR WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "'");
			DC_Main.ExeQuteDc("DELETE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_DATA (CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,CUR_USE,BOOK_INOUT,MAIN_BOOK,ITM_TYPE,BOOK_TYPE,BOOK_VCH_TYPE,MAIN_USER,BOOK_SR_NAME,RESET_BOOK,DATA_TYPE,TRFR_BOOK,DATA_TRFR,USER_EMP_CODE,WITH_MOBILE_ENTRY,MENU_NAME,BOOK_TBL_NAME,BOOK_TBL_DETL)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,CUR_USE,BOOK_INOUT,MAIN_BOOK,ITM_TYPE,BOOK_TYPE,BOOK_VCH_TYPE,MAIN_USER,BOOK_SR_NAME,RESET_BOOK,DATA_TYPE,TRFR_BOOK,DATA_TRFR,USER_EMP_CODE,WITH_MOBILE_ENTRY,MENU_NAME,BOOK_TBL_NAME,BOOK_TBL_DETL FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "' AND LC_CODE = '00'");
			DC_Main.ExeQuteDc("DELETE FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_DETL(CO_CODE,LC_CODE,CO_BOOK,SR_NO,BOOK_NAME,BOOK_SNAME,BOOK_TYPE,ITM_TYPE,BOOK_INOUT,AC_CODE,AC_NAME,MAIN_BOOK,RESET_BOOK,DATA_TYPE)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,CO_BOOK,SR_NO,BOOK_NAME,BOOK_SNAME,BOOK_TYPE,ITM_TYPE,BOOK_INOUT,AC_CODE,AC_NAME,MAIN_BOOK,RESET_BOOK,DATA_TYPE FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "' AND LC_CODE = '00'");
			DC_Main.ExeQuteDc("DELETE FROM CO_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO CO_SET (CO_CODE,BTN_NAME,THEME,COUNTRY_CODE,LBR_TYPE,AC_LC_CODE_LEN,LOCK_DATE,TAX_ROF,RATE_PAR,SL_ROW_CHANGE,  VB_IMPORT,TAG_RPT,FINE_STK_TYPE,RATE_MAST_OPEN,LBR_RATE_GEN,DHRN_INT_TYPE,INT_YEAR_DAYS,OP_DHRN,INT_DAY,HELP_SERCH,WEIGHT_PORT,LDR_SUMM,  SL_AMT_TYPE,SMS_LINK,OP_LOAN,LOAN_INT_TYPE,TRAD_FINE,LBR_ROF,REMINDER_OPEN,ITM_RATE_ROF,ADMIN_SMS,CUST_SMS,PURC_WITH_LBR,DHIRN_COMPOUND,  GRID_SCROLL,STK_RPT_TYPE,TOUCH_AUTO_SAVE,PAN_CARD_VAL,DHRN_PRC,DUP_PRINT,TAX_CODE,IP_WITH_PC,CO_STK_MERGE,STK_RPT_VIEW,PR_AMT_TYPE,  CARD_COM_ADJ,CASH_PURC_AC,EMP_CODE_MANDATORY,STOCK_RPT_TYPE,LAST_DAY_LOCK,CASH_LIMIT,DHRN_WAPP,SCHM_WAPP,LEDR_BILL_COL,ALL_ROF_REMOVE,  OZ_CON_VAL,FX_RATE,FX_CODE)  SELECT '" + DC_Main.MCo_code + "',BTN_NAME,THEME,COUNTRY_CODE,LBR_TYPE,AC_LC_CODE_LEN,LOCK_DATE,TAX_ROF,RATE_PAR,SL_ROW_CHANGE,  VB_IMPORT,TAG_RPT,FINE_STK_TYPE,RATE_MAST_OPEN,LBR_RATE_GEN,DHRN_INT_TYPE,INT_YEAR_DAYS,OP_DHRN,INT_DAY,HELP_SERCH,WEIGHT_PORT,LDR_SUMM,  SL_AMT_TYPE,SMS_LINK,OP_LOAN,LOAN_INT_TYPE,TRAD_FINE,LBR_ROF,REMINDER_OPEN,ITM_RATE_ROF,ADMIN_SMS,CUST_SMS,PURC_WITH_LBR,DHIRN_COMPOUND,  GRID_SCROLL,STK_RPT_TYPE,TOUCH_AUTO_SAVE,PAN_CARD_VAL,DHRN_PRC,DUP_PRINT,TAX_CODE,IP_WITH_PC,CO_STK_MERGE,STK_RPT_VIEW,PR_AMT_TYPE,  CARD_COM_ADJ,CASH_PURC_AC,EMP_CODE_MANDATORY,STOCK_RPT_TYPE,LAST_DAY_LOCK,CASH_LIMIT,DHRN_WAPP,SCHM_WAPP,LEDR_BILL_COL,ALL_ROF_REMOVE,  OZ_CON_VAL,FX_RATE,FX_CODE FROM CO_SET WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "'");
			DC_Main.ExeQuteDc("DELETE FROM CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO CO_SET_NEW (CO_CODE,COUNTER_STK,ESTMATE_BANK_LOCK,OLD_PURC_TOUCH,NEGATIVE_STK_SALE,SL_NWT_LOCK,WH_BILL_IMG,  PROFIT_RPT_TYPE,WEB_IMAGE,WEB_PATH,QR_CODE_GEN,OS_BILL_SMS,SL_BILL_IMG,TOT_FINE_STK_TYPE,OPBL_TRFR_BTN,TAG_VCH_AUTO_SAVE,DESIGN_HELP,  SALES_WITH_HMTAX,TILE_MENU,PR_RATE_ROF,LEN_IMG_PATH,SL_TDS_TAX,PR_TDS_TAX,OS_FINE_INT,PURC_WITH_HMTAX,SL_TAG_WT_DIFF,WAPP_DELAY,  COUNTRY_ID,WAPP_SL_PRINT,BILL_PROFIT,OLD_GOLD_TYPE,TAG_ENTRY_DESIGN_GEN,ORD_IMG_PRINT,OS_BILL_ORNA_ISU,PURC_LOT,MOBILE_HELP,  PRINT_FORM_BTN,FONT_CHANGE,FONT_SIZE,FONT_NAME,FONT_STYLE_TYPE,GRID_ROW_HIGHT,TOT_AMT_ROF,ESTMATE_TAX,TAG_AUTO_PRINT,RPT_TOT_SHOW,  DEFAULT_REMINDER,VCH_DESC_HELP_LENT,ORD_TAG_STK_LESS,BRANCH_ALL_AC_SHOW,SL_MRP_TAX_REVERC,EMP_AS_USER,WAPP_IMG_GWT,YEAR_GOLD_SL,  YEAR_SILVER_SL,F_DISC_DATE,T_DISC_DATE,DHRN_IMG_PRINT,LBR_WITH_GHT,APR_IMG_PRINT,OTH_ITM_WT_REMOVE,SILVER_THREE_DIGIT,KR_DESIGN_IMG_PRINT,  ITM_WITH_LOT_STK,USER_KR_TOUCH_HIDE,CUR_DAY_POSTING,MAIN_FONT_CHANGE,STK_LMIT_WITH_DESIGN,ITM_FINE_LOCK)  SELECT '" + DC_Main.MCo_code + "',COUNTER_STK,ESTMATE_BANK_LOCK,OLD_PURC_TOUCH,NEGATIVE_STK_SALE,SL_NWT_LOCK,WH_BILL_IMG,  PROFIT_RPT_TYPE,WEB_IMAGE,WEB_PATH,QR_CODE_GEN,OS_BILL_SMS,SL_BILL_IMG,TOT_FINE_STK_TYPE,OPBL_TRFR_BTN,TAG_VCH_AUTO_SAVE,DESIGN_HELP,  SALES_WITH_HMTAX,TILE_MENU,PR_RATE_ROF,LEN_IMG_PATH,SL_TDS_TAX,PR_TDS_TAX,OS_FINE_INT,PURC_WITH_HMTAX,SL_TAG_WT_DIFF,WAPP_DELAY,  COUNTRY_ID,WAPP_SL_PRINT,BILL_PROFIT,OLD_GOLD_TYPE,TAG_ENTRY_DESIGN_GEN,ORD_IMG_PRINT,OS_BILL_ORNA_ISU,PURC_LOT,MOBILE_HELP,  PRINT_FORM_BTN,FONT_CHANGE,FONT_SIZE,FONT_NAME,FONT_STYLE_TYPE,GRID_ROW_HIGHT,TOT_AMT_ROF,ESTMATE_TAX,TAG_AUTO_PRINT,RPT_TOT_SHOW,  DEFAULT_REMINDER,VCH_DESC_HELP_LENT,ORD_TAG_STK_LESS,BRANCH_ALL_AC_SHOW,SL_MRP_TAX_REVERC,EMP_AS_USER,WAPP_IMG_GWT,YEAR_GOLD_SL,  YEAR_SILVER_SL,F_DISC_DATE,T_DISC_DATE,DHRN_IMG_PRINT,LBR_WITH_GHT,APR_IMG_PRINT,OTH_ITM_WT_REMOVE,SILVER_THREE_DIGIT,KR_DESIGN_IMG_PRINT,  ITM_WITH_LOT_STK,USER_KR_TOUCH_HIDE,CUR_DAY_POSTING,MAIN_FONT_CHANGE,STK_LMIT_WITH_DESIGN,ITM_FINE_LOCK FROM CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "'");
			DC_Main.ExeQuteDc("DELETE FROM COL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO COL_MAST (CO_CODE,BOOK_NAME,COL_NAME,COL_RPT,COL_NEW_NAME,YES_NO)  SELECT '" + DC_Main.MCo_code + "',BOOK_NAME,COL_NAME,COL_RPT,COL_NEW_NAME,YES_NO FROM COL_MAST WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "'");
			DC_Main.ExeQuteDc("DELETE FROM CONV_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO CONV_MAST (CO_CODE,CON_CODE,CON_NAME,RATE_DATE,GOLD_OZ_RATE,SILVER_OZ_RATE,CURRENCY_RATE,OUNCES_CONV,GOLD_CONV,SILVER_CONV,GOLD_PR_RATE,GOLD_SL_RATE,SILVER_PR_RATE,SILVER_SL_RATE,MAIN_USER)  SELECT '" + DC_Main.MCo_code + "',CON_CODE,CON_NAME,RATE_DATE,GOLD_OZ_RATE,SILVER_OZ_RATE,CURRENCY_RATE,OUNCES_CONV,GOLD_CONV,SILVER_CONV,GOLD_PR_RATE,GOLD_SL_RATE,SILVER_PR_RATE,SILVER_SL_RATE,MAIN_USER FROM CONV_MAST WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "'");
			DC_Main.ExeQuteDc("DELETE FROM EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO EMP_MAST (CO_CODE,EMP_CODE,EMP_NAME,USER_NAME,EMP_TYPE,EMP_AC,EMP_AMT,MAIN_USER,TDS_PRC,TDS_AMT,PF_PRC,PF_AMT,DAY_HOURS)  SELECT '" + DC_Main.MCo_code + "',EMP_CODE,EMP_NAME,USER_NAME,EMP_TYPE,EMP_AC,EMP_AMT,MAIN_USER,TDS_PRC,TDS_AMT,PF_PRC,PF_AMT,DAY_HOURS FROM EMP_MAST WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "' ");
			DC_Main.ExeQuteDc("DELETE FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO GROUP_MAST (CO_CODE,GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_USER,TAX_PRC,AVG_TOUCH,AVG_FINE,AVG_NWT,DAY_OP_PCS,DAY_OP_WT,DAY_CL_PCS,DAY_CL_WT,RATE_DISPLAY,DATA_TRFR)  SELECT '" + DC_Main.MCo_code + "',GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_USER,TAX_PRC,AVG_TOUCH,AVG_FINE,AVG_NWT,DAY_OP_PCS,DAY_OP_WT,DAY_CL_PCS,DAY_CL_WT,RATE_DISPLAY,DATA_TRFR  FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "'");
			DC_Main.ExeQuteDc("DELETE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO ITEM_MAST (CO_CODE,IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,RATE_TYPE,HSN_CODE,ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,MIN_STK,MAIN_USER,AVG_TOUCH,AVG_FINE,AVG_NWT,AC_ITEM,  STK_DISPLAY,OTH_RATE,AVG_RATE,SAFE_NAME,DATA_TRFR,IT_BAG_WT,IT_LBR_RATE,UNICODE_NAME,TAG_IDTL_COL)  SELECT '" + DC_Main.MCo_code + "',IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,RATE_TYPE,HSN_CODE,ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,MIN_STK,MAIN_USER,AVG_TOUCH,AVG_FINE,AVG_NWT,AC_ITEM,  STK_DISPLAY,OTH_RATE,AVG_RATE,SAFE_NAME,DATA_TRFR,IT_BAG_WT,IT_LBR_RATE,UNICODE_NAME,TAG_IDTL_COL  FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "'");
			DC_Main.ExeQuteDc("DELETE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO LOCT_MAST (CO_CODE,LC_CODE,LC_NAME,LC_ADD1,LC_ADD2,LC_ADD3,LC_CITY,LC_PHONE,LC_MOBILE,MAIN_USER)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,LC_NAME,LC_ADD1,LC_ADD2,LC_ADD3,LC_CITY,LC_PHONE,LC_MOBILE,MAIN_USER FROM LOCT_MAST WHERE CO_CODE = '01' AND LC_CODE = '00'");
			DC_Main.ExeQuteMc("DELETE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteMc("INSERT INTO LOCT_MAST (CO_CODE,LC_CODE,LC_NAME,LC_ADD1,LC_ADD2,LC_ADD3,LC_CITY,LC_PHONE,LC_MOBILE,MAIN_USER)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,LC_NAME,LC_ADD1,LC_ADD2,LC_ADD3,LC_CITY,LC_PHONE,LC_MOBILE,MAIN_USER FROM LOCT_MAST WHERE CO_CODE = '01' AND LC_CODE = '00'");
			DC_Main.ExeQuteDc("DELETE FROM PRINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO PRINT_MAST (CO_CODE,PRINT_TYPE,PRINT_FILE,BOOK_TYPE,PRINT_SET_A)  SELECT '" + DC_Main.MCo_code + "',PRINT_TYPE,PRINT_FILE,BOOK_TYPE,PRINT_SET_A FROM PRINT_MAST WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "' ");
			DC_Main.ExeQuteDc("DELETE FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO PRODUCT_MAST (CO_CODE,PR_CODE,PR_NAME,MAIN_USER)  SELECT '" + DC_Main.MCo_code + "',PR_CODE,PR_NAME,MAIN_USER FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "'");
			DC_Main.ExeQuteDc("DELETE FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO TABLE_MAST (CO_CODE,LC_CODE,TABLE_CODE,TABLE_NAME)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,TABLE_CODE,TABLE_NAME FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO TAX_MAST (CO_CODE,TAX_CODE,SR_NO,TAX_GROUP,TAX_NAME,TAX_PRC,ADD_TAX_PRC,TAX_AC,MAIN_USER)  SELECT '" + DC_Main.MCo_code + "',TAX_CODE,SR_NO,TAX_GROUP,TAX_NAME,TAX_PRC,ADD_TAX_PRC,TAX_AC,MAIN_USER FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MsOldCoCode + "'");
		}
		else
		{
			DC_Main.ExeQuteDc("DELETE FROM AC_GROUP WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO AC_GROUP (CO_CODE,AC_GR,AC_GR_NAME,AC_MAIN_GR,AC_SUB_GR,MAIN_USER)  SELECT '" + DC_Main.MCo_code + "',AC_GR,AC_GR_NAME,AC_MAIN_GR,AC_SUB_GR,MAIN_USER FROM AC_GROUP WHERE CO_CODE = '01'");
			DC_Main.ExeQuteDc("DELETE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO AC_MAST (CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_GST_TYPE,DATA_TRFR)  SELECT '" + DC_Main.MCo_code + "',AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_GST_TYPE,'N' FROM AC_MAST WHERE CO_CODE = '01' AND LC_CODE = '00'  AND CAST(AC_CODE AS INT) < 101");
			DC_Main.ExeQuteDc("DELETE FROM BAL_GR WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO BAL_GR (CO_CODE,TRAD_TYPE,TRAD_NAME,SALE_AC,PURC_AC,CLOSING_AC,OP_AC,TRAD_AMT,TRAD_WT,CLG_AC)  SELECT '" + DC_Main.MCo_code + "',TRAD_TYPE,TRAD_NAME,SALE_AC,PURC_AC,CLOSING_AC,OP_AC,TRAD_AMT,TRAD_WT,CLG_AC FROM BAL_GR WHERE CO_CODE = '01'");
			DC_Main.ExeQuteDc("DELETE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_DATA (CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,CUR_USE,BOOK_INOUT,MAIN_BOOK,ITM_TYPE,BOOK_TYPE,BOOK_VCH_TYPE,MAIN_USER,BOOK_SR_NAME,RESET_BOOK,DATA_TYPE,TRFR_BOOK,DATA_TRFR)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,CUR_USE,BOOK_INOUT,MAIN_BOOK,ITM_TYPE,BOOK_TYPE,BOOK_VCH_TYPE,MAIN_USER,BOOK_SR_NAME,RESET_BOOK,DATA_TYPE,TRFR_BOOK,DATA_TRFR FROM BOOK_DATA WHERE CO_CODE = '01' AND LC_CODE = '00'");
			DC_Main.ExeQuteDc("DELETE FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO BOOK_DETL(CO_CODE,LC_CODE,CO_BOOK,SR_NO,BOOK_NAME,BOOK_SNAME,BOOK_TYPE,ITM_TYPE,BOOK_INOUT,AC_CODE,AC_NAME,MAIN_BOOK,RESET_BOOK,DATA_TYPE)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,CO_BOOK,SR_NO,BOOK_NAME,BOOK_SNAME,BOOK_TYPE,ITM_TYPE,BOOK_INOUT,AC_CODE,AC_NAME,MAIN_BOOK,RESET_BOOK,DATA_TYPE FROM BOOK_DETL WHERE CO_CODE = '01' AND LC_CODE = '00'");
			DC_Main.ExeQuteDc("DELETE FROM CO_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO CO_SET (CO_CODE,BTN_NAME,THEME,COUNTRY_CODE,LBR_TYPE,AC_LC_CODE_LEN,LOCK_DATE,TAX_ROF,RATE_PAR,SL_ROW_CHANGE,  VB_IMPORT,TAG_RPT,FINE_STK_TYPE,RATE_MAST_OPEN,LBR_RATE_GEN,DHRN_INT_TYPE,INT_YEAR_DAYS,OP_DHRN,INT_DAY,HELP_SERCH,WEIGHT_PORT,LDR_SUMM,  SL_AMT_TYPE,SMS_LINK,OP_LOAN,LOAN_INT_TYPE,TRAD_FINE,LBR_ROF,REMINDER_OPEN,ITM_RATE_ROF,ADMIN_SMS,CUST_SMS,PURC_WITH_LBR,DHIRN_COMPOUND,  GRID_SCROLL,STK_RPT_TYPE,TOUCH_AUTO_SAVE,PAN_CARD_VAL,DHRN_PRC,DUP_PRINT,TAX_CODE,IP_WITH_PC,CO_STK_MERGE,STK_RPT_VIEW,PR_AMT_TYPE,  CARD_COM_ADJ,CASH_PURC_AC,EMP_CODE_MANDATORY,STOCK_RPT_TYPE,LAST_DAY_LOCK,CASH_LIMIT,DHRN_WAPP,SCHM_WAPP,LEDR_BILL_COL,ALL_ROF_REMOVE,  OZ_CON_VAL,FX_RATE,FX_CODE)  SELECT '" + DC_Main.MCo_code + "',BTN_NAME,THEME,COUNTRY_CODE,LBR_TYPE,AC_LC_CODE_LEN,LOCK_DATE,TAX_ROF,RATE_PAR,SL_ROW_CHANGE,  VB_IMPORT,TAG_RPT,FINE_STK_TYPE,RATE_MAST_OPEN,LBR_RATE_GEN,DHRN_INT_TYPE,INT_YEAR_DAYS,OP_DHRN,INT_DAY,HELP_SERCH,WEIGHT_PORT,LDR_SUMM,  SL_AMT_TYPE,SMS_LINK,OP_LOAN,LOAN_INT_TYPE,TRAD_FINE,LBR_ROF,REMINDER_OPEN,ITM_RATE_ROF,ADMIN_SMS,CUST_SMS,PURC_WITH_LBR,DHIRN_COMPOUND,  GRID_SCROLL,STK_RPT_TYPE,TOUCH_AUTO_SAVE,PAN_CARD_VAL,DHRN_PRC,DUP_PRINT,TAX_CODE,IP_WITH_PC,CO_STK_MERGE,STK_RPT_VIEW,PR_AMT_TYPE,  CARD_COM_ADJ,CASH_PURC_AC,EMP_CODE_MANDATORY,STOCK_RPT_TYPE,LAST_DAY_LOCK,CASH_LIMIT,DHRN_WAPP,SCHM_WAPP,LEDR_BILL_COL,ALL_ROF_REMOVE,  OZ_CON_VAL,FX_RATE,FX_CODE FROM CO_SET WHERE CO_CODE = '01'");
			DC_Main.ExeQuteDc("DELETE FROM CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO CO_SET_NEW (CO_CODE,COUNTER_STK,ESTMATE_BANK_LOCK,OLD_PURC_TOUCH,NEGATIVE_STK_SALE,SL_NWT_LOCK,WH_BILL_IMG,  PROFIT_RPT_TYPE,WEB_IMAGE,WEB_PATH,QR_CODE_GEN,OS_BILL_SMS,SL_BILL_IMG,TOT_FINE_STK_TYPE,OPBL_TRFR_BTN,TAG_VCH_AUTO_SAVE,DESIGN_HELP,  SALES_WITH_HMTAX,TILE_MENU,PR_RATE_ROF,LEN_IMG_PATH,SL_TDS_TAX,PR_TDS_TAX,OS_FINE_INT,PURC_WITH_HMTAX,SL_TAG_WT_DIFF,WAPP_DELAY,  COUNTRY_ID,WAPP_SL_PRINT,BILL_PROFIT,OLD_GOLD_TYPE,TAG_ENTRY_DESIGN_GEN,ORD_IMG_PRINT,OS_BILL_ORNA_ISU,PURC_LOT,MOBILE_HELP,  PRINT_FORM_BTN,FONT_CHANGE,FONT_SIZE,FONT_NAME,FONT_STYLE_TYPE,GRID_ROW_HIGHT,TOT_AMT_ROF,ESTMATE_TAX,TAG_AUTO_PRINT,RPT_TOT_SHOW,  DEFAULT_REMINDER,VCH_DESC_HELP_LENT,ORD_TAG_STK_LESS,BRANCH_ALL_AC_SHOW,SL_MRP_TAX_REVERC,EMP_AS_USER,WAPP_IMG_GWT,YEAR_GOLD_SL,  YEAR_SILVER_SL,F_DISC_DATE,T_DISC_DATE,DHRN_IMG_PRINT,LBR_WITH_GHT,APR_IMG_PRINT,OTH_ITM_WT_REMOVE,SILVER_THREE_DIGIT,KR_DESIGN_IMG_PRINT,  ITM_WITH_LOT_STK,USER_KR_TOUCH_HIDE,CUR_DAY_POSTING,MAIN_FONT_CHANGE,STK_LMIT_WITH_DESIGN,ITM_FINE_LOCK)  SELECT '" + DC_Main.MCo_code + "',COUNTER_STK,ESTMATE_BANK_LOCK,OLD_PURC_TOUCH,NEGATIVE_STK_SALE,SL_NWT_LOCK,WH_BILL_IMG,  PROFIT_RPT_TYPE,WEB_IMAGE,WEB_PATH,QR_CODE_GEN,OS_BILL_SMS,SL_BILL_IMG,TOT_FINE_STK_TYPE,OPBL_TRFR_BTN,TAG_VCH_AUTO_SAVE,DESIGN_HELP,  SALES_WITH_HMTAX,TILE_MENU,PR_RATE_ROF,LEN_IMG_PATH,SL_TDS_TAX,PR_TDS_TAX,OS_FINE_INT,PURC_WITH_HMTAX,SL_TAG_WT_DIFF,WAPP_DELAY,  COUNTRY_ID,WAPP_SL_PRINT,BILL_PROFIT,OLD_GOLD_TYPE,TAG_ENTRY_DESIGN_GEN,ORD_IMG_PRINT,OS_BILL_ORNA_ISU,PURC_LOT,MOBILE_HELP,  PRINT_FORM_BTN,FONT_CHANGE,FONT_SIZE,FONT_NAME,FONT_STYLE_TYPE,GRID_ROW_HIGHT,TOT_AMT_ROF,ESTMATE_TAX,TAG_AUTO_PRINT,RPT_TOT_SHOW,  DEFAULT_REMINDER,VCH_DESC_HELP_LENT,ORD_TAG_STK_LESS,BRANCH_ALL_AC_SHOW,SL_MRP_TAX_REVERC,EMP_AS_USER,WAPP_IMG_GWT,YEAR_GOLD_SL,  YEAR_SILVER_SL,F_DISC_DATE,T_DISC_DATE,DHRN_IMG_PRINT,LBR_WITH_GHT,APR_IMG_PRINT,OTH_ITM_WT_REMOVE,SILVER_THREE_DIGIT,KR_DESIGN_IMG_PRINT,  ITM_WITH_LOT_STK,USER_KR_TOUCH_HIDE,CUR_DAY_POSTING,MAIN_FONT_CHANGE,STK_LMIT_WITH_DESIGN,ITM_FINE_LOCK FROM CO_SET_NEW WHERE CO_CODE = '01'");
			DC_Main.ExeQuteDc("DELETE FROM COL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO COL_MAST (CO_CODE,BOOK_NAME,COL_NAME,COL_RPT,COL_NEW_NAME,YES_NO)  SELECT '" + DC_Main.MCo_code + "',BOOK_NAME,COL_NAME,COL_RPT,COL_NEW_NAME,YES_NO FROM COL_MAST WHERE CO_CODE = '01'");
			DC_Main.ExeQuteDc("DELETE FROM CONV_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO CONV_MAST (CO_CODE,CON_CODE,CON_NAME,RATE_DATE,GOLD_OZ_RATE,SILVER_OZ_RATE,CURRENCY_RATE,OUNCES_CONV,GOLD_CONV,SILVER_CONV,GOLD_PR_RATE,GOLD_SL_RATE,SILVER_PR_RATE,SILVER_SL_RATE,MAIN_USER)  SELECT '" + DC_Main.MCo_code + "',CON_CODE,CON_NAME,RATE_DATE,GOLD_OZ_RATE,SILVER_OZ_RATE,CURRENCY_RATE,OUNCES_CONV,GOLD_CONV,SILVER_CONV,GOLD_PR_RATE,GOLD_SL_RATE,SILVER_PR_RATE,SILVER_SL_RATE,MAIN_USER FROM CONV_MAST WHERE CO_CODE = '01'");
			DC_Main.ExeQuteDc("DELETE FROM EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO EMP_MAST (CO_CODE,EMP_CODE,EMP_NAME,USER_NAME,EMP_TYPE,EMP_AC,EMP_AMT,MAIN_USER)  SELECT '" + DC_Main.MCo_code + "',EMP_CODE,EMP_NAME,USER_NAME,EMP_TYPE,EMP_AC,EMP_AMT,MAIN_USER FROM EMP_MAST WHERE CO_CODE = '01' AND EMP_CODE = '001'");
			DC_Main.ExeQuteDc("DELETE FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO GROUP_MAST (CO_CODE,GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_USER,TAX_PRC,AVG_TOUCH,AVG_FINE,AVG_NWT,DAY_OP_PCS,DAY_OP_WT,DAY_CL_PCS,DAY_CL_WT)  SELECT '" + DC_Main.MCo_code + "',GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_USER,TAX_PRC,AVG_TOUCH,AVG_FINE,AVG_NWT,DAY_OP_PCS,DAY_OP_WT,DAY_CL_PCS,DAY_CL_WT  FROM GROUP_MAST WHERE CO_CODE = '01' AND GR_CODE  IN ('916','DM','EM','FGL','FSL','GO','OG','ORD','OS','OT','SL','SN') ");
			DC_Main.ExeQuteDc("DELETE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO ITEM_MAST (CO_CODE,IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,RATE_TYPE,HSN_CODE,ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,MIN_STK,MAIN_USER,AVG_TOUCH,AVG_FINE,AVG_NWT,AC_ITEM,  STK_DISPLAY,OTH_RATE,AVG_RATE,SAFE_NAME,DATA_TRFR,IT_BAG_WT,IT_LBR_RATE,UNICODE_NAME,TAG_IDTL_COL)  SELECT '" + DC_Main.MCo_code + "',IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,RATE_TYPE,HSN_CODE,ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,MIN_STK,MAIN_USER,AVG_TOUCH,AVG_FINE,AVG_NWT,AC_ITEM,  STK_DISPLAY,OTH_RATE,AVG_RATE,SAFE_NAME,DATA_TRFR,IT_BAG_WT,IT_LBR_RATE,UNICODE_NAME,TAG_IDTL_COL  FROM ITEM_MAST WHERE CO_CODE = '01' AND IT_CODE  IN ('999','DM','EM','FSL','HM','OG','ORG','ORS','OS','OT','RD','SN') ");
			DC_Main.ExeQuteDc("DELETE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO LOCT_MAST (CO_CODE,LC_CODE,LC_NAME,LC_ADD1,LC_ADD2,LC_ADD3,LC_CITY,LC_PHONE,LC_MOBILE,MAIN_USER)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,LC_NAME,LC_ADD1,LC_ADD2,LC_ADD3,LC_CITY,LC_PHONE,LC_MOBILE,MAIN_USER FROM LOCT_MAST WHERE CO_CODE = '01' AND LC_CODE = '00'");
			DC_Main.ExeQuteMc("DELETE FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteMc("INSERT INTO LOCT_MAST (CO_CODE,LC_CODE,LC_NAME,LC_ADD1,LC_ADD2,LC_ADD3,LC_CITY,LC_PHONE,LC_MOBILE,MAIN_USER)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,LC_NAME,LC_ADD1,LC_ADD2,LC_ADD3,LC_CITY,LC_PHONE,LC_MOBILE,MAIN_USER FROM LOCT_MAST WHERE CO_CODE = '01' AND LC_CODE = '00'");
			DC_Main.ExeQuteDc("DELETE FROM PRINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO PRINT_MAST (CO_CODE,PRINT_TYPE,PRINT_FILE,BOOK_TYPE,PRINT_SET_A)  SELECT '" + DC_Main.MCo_code + "',PRINT_TYPE,PRINT_FILE,BOOK_TYPE,PRINT_SET_A FROM PRINT_MAST WHERE CO_CODE = '01' ");
			DC_Main.ExeQuteDc("DELETE FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO PRODUCT_MAST (CO_CODE,PR_CODE,PR_NAME,MAIN_USER)  SELECT '" + DC_Main.MCo_code + "',PR_CODE,PR_NAME,MAIN_USER FROM PRODUCT_MAST WHERE CO_CODE = '01' AND PR_CODE  IN ('DM','EM','FN','HM','OD','OG','OR','OS','OT','RD','SN') ");
			DC_Main.ExeQuteDc("DELETE FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO TABLE_MAST (CO_CODE,LC_CODE,TABLE_CODE,TABLE_NAME)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,TABLE_CODE,TABLE_NAME FROM TABLE_MAST WHERE CO_CODE = '01' AND TABLE_CODE = '001'");
			DC_Main.ExeQuteDc("DELETE FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.ExeQuteDc("INSERT INTO TAX_MAST (CO_CODE,TAX_CODE,SR_NO,TAX_GROUP,TAX_NAME,TAX_PRC,ADD_TAX_PRC,TAX_AC,MAIN_USER)  SELECT '" + DC_Main.MCo_code + "',TAX_CODE,SR_NO,TAX_GROUP,TAX_NAME,TAX_PRC,ADD_TAX_PRC,TAX_AC,MAIN_USER FROM TAX_MAST WHERE CO_CODE = '01'");
		}
		DC_Main.MsOldCoCode = "";
	}
}
