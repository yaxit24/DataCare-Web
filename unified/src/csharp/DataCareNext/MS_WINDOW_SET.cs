using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxMSFlexGridLib;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class MS_WINDOW_SET : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY")]
	private TextBox _TEXT_ENTRY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG")]
	private AxMSFlexGrid _MSG;

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
	[AccessedThroughProperty("btnWindowMenu")]
	private QButton _btnWindowMenu;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private DataTable RsMast1;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private bool MsgClear;

	private bool UpDown;

	private int MsgOldRow;

	private bool Msgleft;

	private DataTable RsData;

	private DataTable RsDetl;

	private double ColCon;

	private string MaxVchNo;

	private long FGRow;

	private const int cSrNo = 0;

	private const int cMenuName = 1;

	private const int cDisplayName = 2;

	private const int cItmShow = 3;

	private const int cShortName = 4;

	private const int ctileName = 5;

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

	internal virtual TextBox TEXT_ENTRY
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_ENTRY;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(TEXT_ENTRY_KeyDown);
			TextBox val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_TEXT_ENTRY = value;
			val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual AxMSFlexGrid MSG
	{
		[CompilerGenerated]
		get
		{
			return _MSG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_ClickEvent;
			EventHandler eventHandler2 = MSG_EnterCell;
			EventHandler eventHandler3 = MSG_LeaveCell;
			EventHandler eventHandler4 = MSG_RowColChange;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
				val.RowColChange -= eventHandler4;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
				val.RowColChange += eventHandler4;
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

	internal virtual QButton btnWindowMenu
	{
		[CompilerGenerated]
		get
		{
			return _btnWindowMenu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnWindowMenu_Click;
			QButton val = _btnWindowMenu;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWindowMenu = value;
			val = _btnWindowMenu;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboWindowMenu")]
	private virtual ComboBox _cboWindowMenu;

	internal virtual ComboBox cboWindowMenu
	{
		get
		{
			return _cboWindowMenu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboWindowMenu = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label6")]
	private virtual Label _Label6;

	internal virtual Label Label6
	{
		get
		{
			return _Label6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label6 = value;
		}
	}

	public MS_WINDOW_SET()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += MS_WINDOW_SET_Load;
		((Form)this).Activated += MS_WINDOW_SET_Activated;
		((Form)this).Deactivate += MS_WINDOW_SET_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_WINDOW_SET_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_WINDOW_SET_KeyDown);
		((Form)this).Closed += MS_WINDOW_SET_Closed;
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
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Expected O, but got Unknown
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Expected O, but got Unknown
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Expected O, but got Unknown
		//IL_0604: Unknown result type (might be due to invalid IL or missing references)
		//IL_060e: Expected O, but got Unknown
		//IL_072c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0736: Expected O, but got Unknown
		//IL_0799: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a3: Expected O, but got Unknown
		//IL_084d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0857: Expected O, but got Unknown
		//IL_08ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c4: Expected O, but got Unknown
		//IL_0b67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c06: Expected O, but got Unknown
		//IL_0c2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cba: Expected O, but got Unknown
		//IL_0d38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d42: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_WINDOW_SET));
		lblBook = new Label();
		TEXT_ENTRY = new TextBox();
		MSG = new AxMSFlexGrid();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		btnWindowMenu = new QButton();
		cboWindowMenu = new ComboBox();
		Label6 = new Label();
		((ISupportInitialize)MSG).BeginInit();
		((Control)PnlBotam).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblBook).Dock = (DockStyle)1;
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).Font = new Font("Segoe UI", 14.25f);
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		lblBook.ImeMode = (ImeMode)0;
		((Control)lblBook).Location = new Point(0, 0);
		((Control)lblBook).Name = "lblBook";
		((Control)lblBook).Size = new Size(1309, 32);
		((Control)lblBook).TabIndex = 101;
		lblBook.Text = "Window Menu Set";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(607, 186);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 1;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)MSG).Location = new Point(282, 53);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(627, 424);
		((Control)MSG).TabIndex = 1;
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
		((Control)PnlBotam).TabIndex = 1130;
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
		((Control)BtnExit).TabIndex = 25;
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
		((Control)BtnDelete).TabIndex = 24;
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
		((Control)BtnCancel).TabIndex = 23;
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
		((Control)BtnSave).TabIndex = 22;
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
		((Control)BtnPrint).TabIndex = 26;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((QControl)btnWindowMenu).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnWindowMenu).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWindowMenu).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnWindowMenu).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnWindowMenu).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnWindowMenu).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWindowMenu).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnWindowMenu).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnWindowMenu).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnWindowMenu).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnWindowMenu).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWindowMenu).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnWindowMenu).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnWindowMenu).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnWindowMenu.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWindowMenu.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWindowMenu.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWindowMenu.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWindowMenu.Image = null;
		((QControl)btnWindowMenu).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnWindowMenu).Location = new Point(536, 501);
		((Control)btnWindowMenu).Margin = new Padding(3, 6, 3, 6);
		((Control)btnWindowMenu).Name = "btnWindowMenu";
		((Control)btnWindowMenu).Size = new Size(181, 32);
		((Control)btnWindowMenu).TabIndex = 1166;
		btnWindowMenu.Text = "Window Menu Set";
		cboWindowMenu.AutoCompleteMode = (AutoCompleteMode)2;
		cboWindowMenu.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboWindowMenu).Font = new Font("Tahoma", 9f);
		((ListControl)cboWindowMenu).FormattingEnabled = true;
		((Control)cboWindowMenu).Location = new Point(422, 507);
		cboWindowMenu.MaxLength = 25;
		((Control)cboWindowMenu).Name = "cboWindowMenu";
		((Control)cboWindowMenu).Size = new Size(106, 22);
		((Control)cboWindowMenu).TabIndex = 1165;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(197, 507);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(217, 20);
		((Control)Label6).TabIndex = 1164;
		Label6.Text = "Window Menu Show";
		Label6.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)btnWindowMenu);
		((Control)this).Controls.Add((Control)(object)cboWindowMenu);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_WINDOW_SET";
		((Form)this).Text = "Window Menu Set";
		((ISupportInitialize)MSG).EndInit();
		((Control)PnlBotam).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 6;
		mSG.Rows = 2;
		mSG.Row = 0;
		mSG[0] = 325;
		checked
		{
			mSG[0] = (int)Math.Round(700.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr.";
			mSG[1] = (int)Math.Round(2500.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "Menu Name";
			mSG[2] = (int)Math.Round(2000.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "Display Name";
			mSG[3] = 1000;
			mSG[3] = 3;
			mSG[0, 3] = "ItType";
			mSG[4] = (int)Math.Round(1000.0 * ColCon);
			mSG[4] = 3;
			mSG[0, 4] = "Short";
			mSG[5] = 0;
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			mSG = null;
		}
	}

	private void MSG_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		UpDown = false;
		checked
		{
			if (mSG.CellWidth >= 0)
			{
				((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
				((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
				((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
				((Control)TEXT_ENTRY).Height = (int)Math.Round((double)mSG.CellHeight / 15.0);
				((Control)TEXT_ENTRY).Visible = true;
				((TextBoxBase)TEXT_ENTRY).SelectAll();
				((Control)TEXT_ENTRY).Focus();
				mSG = null;
			}
		}
	}

	private void MSG_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		int col;
		checked
		{
			if (mSG[mSG.Col] == 0)
			{
				TEXT_ENTRY.Text = "";
				mSG[mSG.Row, mSG.Col] = "";
				DC_Main.M = 1;
				while (mSG[mSG.Col] == 0)
				{
					if (Msgleft)
					{
						if (mSG.Col > 1)
						{
							mSG.Col -= 1;
						}
					}
					else if (mSG.Col < mSG.Cols - 1)
					{
						mSG.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 10)
					{
						break;
					}
				}
			}
			if (((mSG.Row == 0) | (mSG.CellWidth <= 0)) || MSG[MSG.Col] == 0)
			{
				return;
			}
			((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
			((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
			((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
			((Control)TEXT_ENTRY).Height = (int)Math.Round((double)mSG.CellHeight / 15.0);
			((Control)TEXT_ENTRY).Visible = true;
			((TextBoxBase)TEXT_ENTRY).ReadOnly = false;
			col = MSG.Col;
		}
		if (col == 0 || col == 0 - ((((TextBoxBase)TEXT_ENTRY).MaxLength == 5) ? 1 : 0))
		{
			TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
			((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
		}
		else
		{
			switch (col)
			{
			case 1:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 25;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			case 2:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 25;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 3:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 4:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 2;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			}
		}
		mSG = null;
		((TextBoxBase)TEXT_ENTRY).SelectAll();
	}

	private void MSG_LeaveCell(object sender, EventArgs e)
	{
		if (!UpDown && !MsgClear && MSG.Row != 0 && MSG[MSG.Col] != 0 && ((Control)TEXT_ENTRY).Visible)
		{
			AxMSFlexGrid mSG = MSG;
			int col = MSG.Col;
			if ((uint)col <= 5u)
			{
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			}
			mSG = null;
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG = null;
	}

	private void MS_WINDOW_SET_Load(object sender, EventArgs e)
	{
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_07f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ff: Expected O, but got Unknown
		//IL_083e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0843: Unknown result type (might be due to invalid IL or missing references)
		//IL_084d: Expected O, but got Unknown
		//IL_089a: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a1: Expected O, but got Unknown
		//IL_0927: Unknown result type (might be due to invalid IL or missing references)
		//IL_092c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0936: Expected O, but got Unknown
		//IL_09be: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cd: Expected O, but got Unknown
		//IL_0a3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4a: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		DC_Main.MsUserRightForm = "";
		if (dataTable.Rows.Count > 0)
		{
			UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));
			UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));
			UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));
		}
		DC_Main.MCo_Book = "000";
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
				AxMSFlexGrid mSG = MSG;
				object? obj7 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj8 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj8 != null) ? ((Color)obj8) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj9 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj9 != null) ? ((Color)obj9) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj10 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AxMSFlexGrid mSG4 = MSG;
				object? obj11 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj12 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj12 != null) ? ((Color)obj12) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj13 != null) ? ((Color)obj13) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj14 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj15 = lblBook;
				object? obj16 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj15).ForeColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj17 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj18 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj19 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj20 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj20 != null) ? ((Color)obj20) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				num3 = (int)Math.Ceiling((double)((Control)cboWindowMenu).Font.Size * (1.0 + num2));
				Font font = ((Control)cboWindowMenu).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is SimpleButton || val3 is MaskedTextBox || val3 is QButton) && ((Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "lblBook", false) != 0)))
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
			cboWindowMenu.Items.Add((object)"Left");
			cboWindowMenu.Items.Add((object)"Right");
			cboWindowMenu.Items.Add((object)"Window");
			DC_Main.RsQry = "SELECT * From CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TILE_MENU"], (object)""), (object)"W", false))
				{
					cboWindowMenu.SelectedIndex = 2;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TILE_MENU"], (object)""), (object)"R", false))
				{
					cboWindowMenu.SelectedIndex = 1;
				}
				else
				{
					cboWindowMenu.SelectedIndex = 0;
				}
			}
			EntryMode = "A";
		}
	}

	private void MS_WINDOW_SET_Activated(object sender, EventArgs e)
	{
		((ContainerControl)this).ActiveControl = CurActCtrl;
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
		}
		MainUser = DC_Main.MCo_User;
		MSG_CLEAR();
		CommPassAdd();
		EntryMode = "A";
		DISPLAY_DATA();
	}

	private void DISPLAY_DATA()
	{
		MSG_CLEAR();
		DC_Main.RsQry = "SELECT A.* FROM TILE_DATA AS A ORDER BY A.SR_NO ";
		DC_Main.Tbl = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		DC_Main.i = 0;
		AxMSFlexGrid mSG = MSG;
		checked
		{
			while (DC_Main.i < DC_Main.Tbl.Rows.Count)
			{
				mSG[DC_Main.i + 1, 0] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["SR_NO"], (object)""));
				mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["SM_MAIN_NAME"], (object)""));
				mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["DISPLAY_NAME"], (object)""));
				mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["ITM_SHOW"], (object)""));
				mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["SHORT_NAME"], (object)""));
				mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["TILE_NAME"], (object)""));
				mSG.Rows += 1;
				DC_Main.i++;
			}
			if (mSG.Rows > 2)
			{
				mSG.Rows -= 1;
			}
			MSG.Row = 1;
			MSG.Col = 2;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
			mSG = null;
			EntryMode = "E";
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

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				DC_Main.RsQry = "UPDATE TILE_DATA SET SM_MAIN_NAME = '" + MSG[DC_Main.i, 1] + "',  DISPLAY_NAME = '" + MSG[DC_Main.i, 2] + "',  ITM_SHOW = '" + MSG[DC_Main.i, 3] + "'  WHERE SR_NO = '" + MSG[DC_Main.i, 0] + "' ";
				DC_Main.ExeQuteMc(DC_Main.RsQry);
				DC_Main.i++;
			}
			Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
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

	private void MS_WINDOW_SET_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_WINDOW_SET_KeyPress(object sender, KeyPressEventArgs e)
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

	private void MS_WINDOW_SET_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			MSG_LeaveCell(MSG, new EventArgs());
			MSG.Row = checked(MSG.Rows - 1);
			MSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			((Control)BtnSave).Focus();
		}
	}

	private void MSG_RowColChange(object sender, EventArgs e)
	{
		if (MsgOldRow != MSG.Row)
		{
			MsgOldRow = MSG.Row;
		}
	}

	private void TEXT_ENTRY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected I4, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		checked
		{
			if (unchecked((int)keyCode) != 13)
			{
				switch (unchecked(keyCode - 37))
				{
				case 0:
					if (mSG.Col > 1)
					{
						UpDown = true;
						mSG.Col -= 1;
					}
					return;
				case 2:
					if (mSG.Col < mSG.Cols - 1)
					{
						UpDown = true;
						mSG.Col += 1;
					}
					return;
				case 1:
					if (mSG.Row > 1)
					{
						UpDown = true;
						mSG.Row -= 1;
					}
					return;
				case 3:
					if (mSG.Row < mSG.Rows - 1)
					{
						UpDown = true;
						mSG.Row += 1;
					}
					return;
				}
			}
			else
			{
				switch (mSG.Col)
				{
				case 2:
					if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
					{
						DC_Main.RsQry = "SELECT SM_MAIN_NAME As MenuNameL,BTN_NAME As MainMenuL FROM MENU_DATA WHERE TILE_ITEM = 'Y' ORDER BY MAIN_SRNO,SM_CODE ";
						DC_Main.RsDg = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						DC_Main.YearHelp = false;
						DC_Main.ColWidth = new double[3];
						DC_Main.ColWidth[0] = 250.0;
						DC_Main.ColWidth[1] = 200.0;
						DC_Main.HelpSelect = 1;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
						{
							TEXT_ENTRY.Text = DC_Main.ColValue[0];
							mSG[mSG.Row, 1] = DC_Main.ColValue[0];
							mSG[mSG.Row, 2] = DC_Main.ColValue[0];
							((TextBoxBase)TEXT_ENTRY).SelectAll();
						}
						return;
					}
					break;
				case 3:
					if (mSG.Row == mSG.Rows - 1)
					{
						((Control)TEXT_ENTRY).Visible = false;
						((Control)BtnSave).Enabled = true;
						((Control)BtnSave).Focus();
					}
					else
					{
						mSG.Row += 1;
						mSG.Col = 2;
						((Control)TEXT_ENTRY).Visible = true;
						((Control)TEXT_ENTRY).Focus();
					}
					return;
				}
				if (mSG.Col < mSG.Cols - 1)
				{
					MSG.Col += 1;
				}
				((Control)TEXT_ENTRY).Visible = true;
				((Control)TEXT_ENTRY).Focus();
			}
			mSG = null;
		}
	}

	private void MS_WINDOW_SET_Closed(object sender, EventArgs e)
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

	private void BtnWindowMenu_Click(object sender, EventArgs e)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET TILE_MENU = '" + Strings.Mid(cboWindowMenu.Text, 1, 1) + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.MsTileMenuShow = Strings.Mid(cboWindowMenu.Text, 1, 1);
		Interaction.MsgBox((object)"Window Menu Side Is Set ....", (MsgBoxStyle)0, (object)null);
	}
}
