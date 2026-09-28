using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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

namespace DataCareNext;

[DesignerGenerated]
public class MS_MFG_MAST : Form
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
	[AccessedThroughProperty("btnMenuReset")]
	private SimpleButton _btnMenuReset;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnEntryDelete")]
	private SimpleButton _btnEntryDelete;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private DataTable RsMast1;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OldValTot;

	private double NewValTot;

	private bool MsgClear;

	private bool UpDown;

	private int MsgOldRow;

	private bool Msgleft;

	private DataTable RsDetl;

	private double ColCon;

	private const int cSr = 0;

	private const int cMainCode = 1;

	private const int cMainMenu = 2;

	private const int cCoBook = 3;

	private const int cTrnCode = 4;

	private const int cTrnName = 5;

	private const int cBookSname = 6;

	private const int cCurInUse = 7;

	private const int cLastTran = 8;

	private const int cEntryType = 9;

	private const int cNextTran = 10;

	private const int cMainBook = 11;

	private const int cStkILess = 12;

	private const int cStkAdd = 13;

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
			EventHandler eventHandler = TEXT_ENTRY_TextChanged;
			TextBox val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_TEXT_ENTRY = value;
			val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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

	internal virtual SimpleButton btnMenuReset
	{
		[CompilerGenerated]
		get
		{
			return _btnMenuReset;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnMenuReset_Click;
			SimpleButton val = _btnMenuReset;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnMenuReset = value;
			val = _btnMenuReset;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnEntryDelete
	{
		[CompilerGenerated]
		get
		{
			return _btnEntryDelete;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnEntryDelete_Click;
			SimpleButton val = _btnEntryDelete;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnEntryDelete = value;
			val = _btnEntryDelete;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public MS_MFG_MAST()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		((Form)this).Load += MS_MFG_MAST_Load;
		((Form)this).Activated += MS_MFG_MAST_Activated;
		((Form)this).Deactivate += MS_MFG_MAST_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_MFG_MAST_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_MFG_MAST_KeyDown);
		((Form)this).Closed += MS_MFG_MAST_Closed;
		((Control)this).KeyUp += new KeyEventHandler(MS_MFG_MAST_KeyUp);
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
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Expected O, but got Unknown
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Expected O, but got Unknown
		//IL_06e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06eb: Expected O, but got Unknown
		//IL_074e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0758: Expected O, but got Unknown
		//IL_0802: Unknown result type (might be due to invalid IL or missing references)
		//IL_080c: Expected O, but got Unknown
		//IL_086f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0879: Expected O, but got Unknown
		//IL_0923: Unknown result type (might be due to invalid IL or missing references)
		//IL_092d: Expected O, but got Unknown
		//IL_0990: Unknown result type (might be due to invalid IL or missing references)
		//IL_099a: Expected O, but got Unknown
		//IL_0a66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a70: Expected O, but got Unknown
		//IL_0ab1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abb: Expected O, but got Unknown
		//IL_0b1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b28: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_MFG_MAST));
		lblBook = new Label();
		TEXT_ENTRY = new TextBox();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		btnMenuReset = new SimpleButton();
		MSG = new AxMSFlexGrid();
		btnEntryDelete = new SimpleButton();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)MSG).BeginInit();
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
		lblBook.Text = "Mfg Master";
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
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)btnMenuReset);
		((Control)PnlBotam).Controls.Add((Control)(object)btnEntryDelete);
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
		((BaseStyleControl)btnMenuReset).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnMenuReset).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnMenuReset).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnMenuReset).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnMenuReset.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnMenuReset.ImageOptions.SvgImage");
		((Control)btnMenuReset).Location = new Point(663, 3);
		((BaseControl)btnMenuReset).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnMenuReset).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnMenuReset).Name = "btnMenuReset";
		((Control)btnMenuReset).Size = new Size(158, 37);
		((Control)btnMenuReset).TabIndex = 27;
		btnMenuReset.Text = "&Rest Menu";
		((BaseButton)btnMenuReset).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)MSG).Location = new Point(45, 77);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1069, 458);
		((Control)MSG).TabIndex = 1;
		((BaseStyleControl)btnEntryDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnEntryDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnEntryDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnEntryDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnEntryDelete.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("SimpleButton1.ImageOptions.SvgImage");
		((Control)btnEntryDelete).Location = new Point(499, 3);
		((BaseControl)btnEntryDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnEntryDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnEntryDelete).Name = "btnEntryDelete";
		((Control)btnEntryDelete).Size = new Size(158, 37);
		((Control)btnEntryDelete).TabIndex = 28;
		btnEntryDelete.Text = "&Mfg Entry delete";
		((BaseButton)btnEntryDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_MFG_MAST";
		((Form)this).Text = "Mfg Master";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)MSG).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 14;
		mSG.Rows = 2;
		mSG.Row = 0;
		mSG[0] = 325;
		checked
		{
			mSG[0] = (int)Math.Round(450.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr.";
			mSG[1] = (int)Math.Round(900.0 * ColCon);
			mSG[1] = 2;
			mSG[0, 1] = "MnuCode";
			mSG[2] = (int)Math.Round(2000.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "Mnu Name";
			mSG[3] = (int)Math.Round(800.0 * ColCon);
			mSG[3] = 3;
			mSG[0, 3] = "Book";
			mSG[4] = (int)Math.Round(1000.0 * ColCon);
			mSG[4] = 3;
			mSG[0, 4] = "TrnCode";
			mSG[5] = 2100;
			mSG[5] = 0;
			mSG[0, 5] = "Trn Name";
			mSG[6] = (int)Math.Round(1200.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "BksName";
			mSG[7] = (int)Math.Round(800.0 * ColCon);
			mSG[7] = 3;
			mSG[0, 7] = "CurUse";
			mSG[8] = (int)Math.Round(1000.0 * ColCon);
			mSG[8] = 3;
			mSG[0, 8] = "LastTrn";
			mSG[9] = (int)Math.Round(1000.0 * ColCon);
			mSG[9] = 3;
			mSG[0, 9] = "TrnType";
			mSG[10] = (int)Math.Round(1000.0 * ColCon);
			mSG[10] = 3;
			mSG[0, 10] = "NextTrn";
			mSG[11] = (int)Math.Round(1800.0 * ColCon);
			mSG[11] = 0;
			mSG[0, 11] = "MainBook";
			mSG[13] = (int)Math.Round(900.0 * ColCon);
			mSG[13] = 3;
			mSG[0, 13] = "StkAdd";
			mSG[12] = (int)Math.Round(900.0 * ColCon);
			mSG[12] = 3;
			mSG[0, 12] = "StkLes";
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
			if (!((mSG.Row == 0) | (mSG.CellWidth <= 0)) && MSG[MSG.Col] != 0)
			{
				((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
				((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
				((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
				((Control)TEXT_ENTRY).Height = (int)Math.Round((double)mSG.CellHeight / 15.0);
				((Control)TEXT_ENTRY).Visible = true;
				((TextBoxBase)TEXT_ENTRY).ReadOnly = false;
				switch (MSG.Col)
				{
				case 0:
				case 1:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 2;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
					break;
				case 4:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 2;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
					break;
				case 5:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 11:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
					break;
				case 6:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 7:
				case 12:
				case 13:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 9:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 2;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
					break;
				case 8:
				case 10:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 2;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				}
				mSG = null;
				((TextBoxBase)TEXT_ENTRY).SelectAll();
			}
		}
	}

	private void MSG_LeaveCell(object sender, EventArgs e)
	{
		if (!UpDown && !MsgClear && MSG.Row != 0 && MSG[MSG.Col] != 0 && ((Control)TEXT_ENTRY).Visible)
		{
			AxMSFlexGrid mSG = MSG;
			switch (MSG.Col)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 8:
			case 10:
			case 11:
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 6:
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 7:
			case 9:
			case 12:
			case 13:
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
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

	private void MS_MFG_MAST_Load(object sender, EventArgs e)
	{
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_07f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ff: Expected O, but got Unknown
		//IL_083e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0843: Unknown result type (might be due to invalid IL or missing references)
		//IL_084d: Expected O, but got Unknown
		//IL_0897: Unknown result type (might be due to invalid IL or missing references)
		//IL_089c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a6: Expected O, but got Unknown
		//IL_0918: Unknown result type (might be due to invalid IL or missing references)
		//IL_091d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0923: Expected O, but got Unknown
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
				num3 = (int)Math.Ceiling((double)((Control)lblBook).Font.Size * (1.0 + num2));
				((Control)lblBook).Font = new Font(((Control)lblBook).Font.FontFamily, (float)num3, ((Control)lblBook).Font.Style);
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnSave).Font.Size * (1.0 + num2));
				Font font = ((BaseStyleControl)BtnSave).Font;
				try
				{
					foreach (object control3 in ((Control)PnlBotam).Controls)
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(control3);
						NewLateBinding.LateSet(objectValue2, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font)?.Dispose();
				}
			}
			CLEAR_DATA();
			EntryMode = "A";
			CurActCtrl = (Control)(object)TEXT_ENTRY;
		}
	}

	private void MS_MFG_MAST_Activated(object sender, EventArgs e)
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
		OldValTot = 0.0;
		NewValTot = 0.0;
		EntryMode = "A";
		DISPLAY_DATA();
		MSG.Row = 1;
		MSG.Col = 3;
		MSG_EnterCell(MSG, new EventArgs());
		((Control)TEXT_ENTRY).Focus();
	}

	private void DISPLAY_DATA()
	{
		MSG_CLEAR();
		if (Operators.CompareString(DC_Main.MsDataType, "C", false) == 0)
		{
			string text = "A";
		}
		else
		{
			string text = DC_Main.MsDataType;
		}
		DC_Main.RsQry = "SELECT * FROM MFG_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY SM_CODE";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.i = 0;
		AxMSFlexGrid mSG = MSG;
		checked
		{
			while (DC_Main.i < DC_Main.Tbl.Rows.Count)
			{
				mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
				mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["SM_MAIN_CODE"], (object)""));
				mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["MENU_NAME"], (object)""));
				mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["SM_CODE"], (object)""));
				mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["TRAN_NAME"], (object)""));
				mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["CO_BOOK"], (object)""));
				mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["BOOK_SNAME"], (object)""));
				mSG[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["CUR_IN_USE"], (object)""));
				mSG[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["LAST_TRAN"], (object)""));
				mSG[DC_Main.i + 1, 9] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["ENTRY_TYPE"], (object)""));
				mSG[DC_Main.i + 1, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["NEXT_TRAN"], (object)""));
				mSG[DC_Main.i + 1, 11] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["MAIN_BOOK"], (object)""));
				mSG[DC_Main.i + 1, 12] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["STK_ISU"], (object)""));
				mSG[DC_Main.i + 1, 13] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["STK_REC"], (object)""));
				mSG.Rows += 1;
				DC_Main.i++;
			}
			if (mSG.Rows > 2)
			{
				mSG.Rows -= 1;
			}
			mSG = null;
			OldValTot = 0.0;
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
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f6: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.RsQry = "SELECT * FROM MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK IN ('301','302','303','304','305','306','307','308','309','310','311','312','313','314','315','316','317','318','319')";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 10)
		{
			Interaction.MsgBox((object)"You Cant Save Mfg Master Because More Then 10 Transection in MFG_DATA First Delete It and Try...", (MsgBoxStyle)0, (object)null);
			return;
		}
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				if (Operators.CompareString(MSG[DC_Main.i, 7], "Y", false) == 0)
				{
					if (Operators.CompareString(MSG[DC_Main.i, 5], "", false) == 0)
					{
						Interaction.MsgBox((object)"Please Insert Transection Name First and Try...", (MsgBoxStyle)0, (object)null);
						return;
					}
					if (Operators.CompareString(MSG[DC_Main.i, 6], "", false) == 0)
					{
						Interaction.MsgBox((object)"Please Insert BookSName First and Try...", (MsgBoxStyle)0, (object)null);
						return;
					}
					if (Operators.CompareString(MSG[DC_Main.i, 10], "", false) == 0)
					{
						Interaction.MsgBox((object)"Please Insert Next Transection Processand Try...", (MsgBoxStyle)0, (object)null);
						return;
					}
					if (Operators.CompareString(MSG[DC_Main.i, 11], "", false) == 0)
					{
						Interaction.MsgBox((object)"Please Insert Main book Name and Try...", (MsgBoxStyle)0, (object)null);
						return;
					}
				}
				DC_Main.i++;
			}
			DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET CUR_USE ='N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK IN ('301','302','303','304','305','306','307','308','309','310','311','312','313','314','315','316','317','318','319')");
			DC_Main.OpenRecordSetDc("DELETE FROM MFG_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DC_Main.RsQry = "SELECT * FROM MFG_MAST WHERE CO_CODE  = '" + DC_Main.MCo_code + "' ";
			RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow = RsDetl.NewRow();
			int num2 = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num2)
			{
				dataRow["CO_CODE"] = DC_Main.MCo_code;
				dataRow["SM_MAIN_CODE"] = MSG[DC_Main.i, 1];
				dataRow["MENU_NAME"] = MSG[DC_Main.i, 2];
				dataRow["SM_CODE"] = MSG[DC_Main.i, 4];
				dataRow["TRAN_NAME"] = MSG[DC_Main.i, 5];
				dataRow["CO_BOOK"] = MSG[DC_Main.i, 3];
				dataRow["BOOK_SNAME"] = MSG[DC_Main.i, 6];
				dataRow["CUR_IN_USE"] = MSG[DC_Main.i, 7];
				dataRow["LAST_TRAN"] = MSG[DC_Main.i, 8];
				dataRow["ENTRY_TYPE"] = MSG[DC_Main.i, 9];
				dataRow["NEXT_TRAN"] = MSG[DC_Main.i, 10];
				dataRow["MAIN_BOOK"] = MSG[DC_Main.i, 11];
				dataRow["STK_ISU"] = MSG[DC_Main.i, 12];
				dataRow["STK_REC"] = MSG[DC_Main.i, 13];
				RsDetl.Rows.Add(dataRow);
				((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
				RsDetl.Clear();
				DC_Main.i++;
			}
			DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_VIEW = 'N' WHERE SM_MAIN_CODE IN ('02','03','04','05','06','07','08','09','10','11','12','13','14','15','16','17','18','19','20') AND BTN_NAME = 'Mfg' ");
			int num3 = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num3)
			{
				if (Operators.CompareString(MSG[DC_Main.i, 7], "Y", false) == 0)
				{
					DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_CODE = '" + MSG[DC_Main.i, 4] + "',SM_NAME = '" + MSG[DC_Main.i, 5] + "',SM_VIEW = 'Y' WHERE SM_MAIN_NAME = '" + MSG[DC_Main.i, 2] + "' AND BTN_NAME = 'Mfg' ");
					DC_Main.ExeQuteDc("UPDATE BOOK_DATA SET BOOK_NAME = '" + MSG[DC_Main.i, 5] + "',BOOK_SNAME = '" + MSG[DC_Main.i, 6] + "',CUR_USE ='Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + MSG[DC_Main.i, 3] + "'");
				}
				else
				{
					DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_VIEW = 'N',SM_CODE = '" + MSG[DC_Main.i, 4] + "' WHERE SM_MAIN_NAME = '" + MSG[DC_Main.i, 2] + "' AND BTN_NAME = 'Mfg' ");
				}
				DC_Main.i++;
			}
			DC_Main.RsQry = "UPDATE MFG_MAST SET  SM_MAIN_CODE = SM_CODE WHERE CO_CODE = '" + DC_Main.MCo_code + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.i = 2;
			do
			{
				string text = Strings.Format((object)(DC_Main.i + 60), "00");
				DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_MAIN_CODE = " + text + " WHERE SM_MAIN_CODE = '" + Strings.Format((object)DC_Main.i, "00") + "' AND BTN_NAME = 'Mfg' ");
				DC_Main.i++;
			}
			while (DC_Main.i <= 20);
			DC_Main.RsQry = "UPDATE MENU_DATA SET  SM_MAIN_CODE = SM_CODE WHERE BTN_NAME = 'Mfg' ";
			DC_Main.ExeQuteMc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE MENU_DATA SET SM_VIEW = 'N' WHERE BTN_NAME = 'Mfg' AND SM_MAIN_NAME = 'Mfg Mast'";
			DC_Main.ExeQuteMc(DC_Main.RsQry);
			Interaction.MsgBox((object)"Data Are Saved.. Please Save All Mfg Book Reng(301 to 319 book No) In Book Master...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			Application.Exit();
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		Interaction.MsgBox((object)"You Cant Delete Mfg Mast Please Contect Our Tem and Reset It...", (MsgBoxStyle)0, (object)null);
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void MS_MFG_MAST_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_MFG_MAST_KeyPress(object sender, KeyPressEventArgs e)
	{
	}

	private void MS_MFG_MAST_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		if (((int)e.KeyCode == 79) & e.Control)
		{
			((Control)btnMenuReset).Visible = true;
		}
		if ((int)e.KeyCode == 27)
		{
			if (OldValTot == NewValTot)
			{
				((Form)this).Close();
			}
			else if (((Control)TEXT_ENTRY).Visible)
			{
				MSG_LeaveCell(MSG, new EventArgs());
				MSG.Row = checked(MSG.Rows - 1);
				MSG.Col = 0;
				((Control)TEXT_ENTRY).Visible = false;
				((Control)BtnSave).Focus();
			}
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
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
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
				case 1:
					if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
					{
						((Control)TEXT_ENTRY).Visible = false;
						((Control)BtnSave).Enabled = true;
						((Control)BtnSave).Focus();
						return;
					}
					break;
				case 11:
					DC_Main.RsQry = "Select MAIN_BOOK From BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND MAIN_BOOK = '" + TEXT_ENTRY.Text + "'";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count == 0)
					{
						DC_Main.RsQry = "SELECT MAIN_BOOK As MainBookL FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK IN ('301','302','303','304','305','306','307','308','309','310','311','312','313','314','315','316','317','318','319') ORDER BY CO_BOOK";
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.ColWidth = new double[2];
						DC_Main.ColWidth[0] = 400.0;
						DC_Main.HelpSelect = 1;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						if (!DC_Main.HelpClose)
						{
							if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								TEXT_ENTRY.Text = DC_Main.ColValue[0];
								mSG[mSG.Row, 11] = DC_Main.ColValue[0];
							}
							((Control)TEXT_ENTRY).Focus();
						}
						return;
					}
					mSG[mSG.Row, 11] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MAIN_BOOK"], (object)""));
					break;
				case 13:
					if (mSG.Row == mSG.Rows - 1)
					{
						mSG.Rows += 1;
						mSG.Row += 1;
						CommPassAdd();
						mSG.Col = 1;
					}
					else
					{
						mSG.Row += 1;
						mSG.Col = 4;
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

	private void MS_MFG_MAST_Closed(object sender, EventArgs e)
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

	private void MS_MFG_MAST_KeyUp(object sender, KeyEventArgs e)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Invalid comparison between Unknown and I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Invalid comparison between Unknown and I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Invalid comparison between Unknown and I4
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ENTRY", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_ENTRY).SelectionStart = 0;
			((TextBoxBase)TEXT_ENTRY).SelectionLength = Strings.Len(TEXT_ENTRY.Text);
		}
	}

	private void BtnMenuReset_Click(object sender, EventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Invalid comparison between Unknown and I4
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0586: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		DataTable dataTable = default(DataTable);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						if (unchecked((int)Interaction.MsgBox((object)"Are You Sure To Reset Mfg Menu...?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) != 6)
						{
							goto end_IL_0001;
						}
						goto IL_001e;
					case 1724:
						{
							num = num2;
							switch ((num3 <= -2) ? 1 : num3)
							{
							case 1:
								break;
							default:
								goto end_IL_0001_2;
							}
							int num4 = unchecked(num + 1);
							num = 0;
							switch (num4)
							{
							case 1:
								break;
							case 2:
								goto IL_001e;
							case 3:
								goto IL_002a;
							case 4:
								goto IL_003b;
							case 5:
								goto IL_0056;
							case 7:
							case 8:
								goto IL_006c;
							case 9:
								goto IL_0079;
							case 10:
								goto IL_0095;
							case 11:
								goto IL_009e;
							case 12:
								goto IL_00ba;
							case 14:
								goto IL_00c6;
							case 15:
								goto IL_00e2;
							case 17:
								goto IL_00ef;
							case 13:
							case 16:
							case 18:
							case 19:
							case 20:
								goto IL_00fb;
							case 21:
								goto IL_0108;
							case 22:
								goto IL_0116;
							case 23:
								goto IL_0123;
							case 24:
								goto IL_0135;
							case 25:
								goto IL_0153;
							case 28:
								goto IL_0161;
							case 29:
								goto IL_01a0;
							case 30:
								goto IL_01ae;
							case 31:
								goto IL_021e;
							case 32:
								goto IL_022c;
							case 26:
							case 27:
							case 33:
								goto IL_023c;
							case 35:
								goto IL_0262;
							case 36:
								goto IL_026f;
							case 37:
								goto IL_027d;
							case 38:
								goto IL_02c0;
							case 34:
							case 39:
							case 40:
								goto IL_02cf;
							case 41:
								goto IL_02dc;
							case 42:
								goto IL_02ee;
							case 43:
								goto IL_030c;
							case 46:
								goto IL_031a;
							case 47:
								goto IL_0323;
							case 48:
								goto IL_0330;
							case 49:
								goto IL_033f;
							case 52:
								goto IL_034a;
							case 53:
								goto IL_03e6;
							case 54:
								goto IL_03f8;
							case 55:
								goto IL_0416;
							case 56:
								goto IL_0500;
							case 57:
							case 58:
								goto IL_0510;
							case 50:
							case 51:
							case 59:
								goto IL_051a;
							case 60:
								goto IL_0536;
							case 44:
							case 45:
							case 61:
								goto IL_0546;
							case 62:
							case 63:
								goto IL_056a;
							case 64:
								goto IL_0573;
							case 65:
								goto IL_057c;
							case 66:
								goto end_IL_0001_3;
							default:
								goto end_IL_0001_2;
							case 6:
							case 67:
							case 68:
								goto end_IL_0001;
							}
							goto default;
						}
						IL_056a:
						num2 = 63;
						DC_Main.OpenTable_ColMast();
						goto IL_0573;
						IL_0573:
						num2 = 64;
						Mfg_Module.Uae_Setting();
						goto IL_057c;
						IL_0510:
						num2 = 58;
						num5++;
						goto IL_051a;
						IL_057c:
						num2 = 65;
						Interaction.MsgBox((object)"Mfg Master Reset Ok....", (MsgBoxStyle)0, (object)null);
						break;
						IL_001e:
						num2 = 2;
						DC_Main.RsQry = "SELECT * FROM MFG_DATA WHERE CO_BOOK IN ('301','302','303','304','305','306','307','308','309','310','311','312','313','314','315','316','317','318','319')";
						goto IL_002a;
						IL_002a:
						num2 = 3;
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_003b;
						IL_003b:
						num2 = 4;
						if (DC_Main.Tbl.Rows.Count > 10)
						{
							goto IL_0056;
						}
						goto IL_006c;
						IL_0056:
						num2 = 5;
						Interaction.MsgBox((object)"You Cant Reset Mfg Master Because More Then 10 Transection in MFG_DATA First Delete It and Try...", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
						IL_006c:
						num2 = 8;
						DC_Main.OpenRecordSetMc("DELETE FROM MENU_DATA WHERE BTN_NAME = 'Mfg' AND SM_MAIN_NAME <> 'Mfg Mast'");
						goto IL_0079;
						IL_0079:
						num2 = 9;
						if (Operators.CompareString(DC_Main.MsMfgType, "M", false) == 0)
						{
							goto IL_0095;
						}
						goto IL_00fb;
						IL_0095:
						num2 = 10;
						Mfg_Module.ItemCreate();
						goto IL_009e;
						IL_009e:
						num2 = 11;
						if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
						{
							goto IL_00ba;
						}
						goto IL_00c6;
						IL_00ba:
						num2 = 12;
						Mfg_Module.Mfg_With_lot();
						goto IL_00fb;
						IL_00c6:
						num2 = 14;
						if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
						{
							goto IL_00e2;
						}
						goto IL_00ef;
						IL_00e2:
						num2 = 15;
						Mfg_Module.Mfg_With_Order();
						goto IL_00fb;
						IL_00ef:
						num2 = 17;
						Mfg_Module.Mfg_menu_set();
						goto IL_00fb;
						IL_00fb:
						num2 = 20;
						DC_Main.RsQry = "DELETE FROM USER_SET WHERE CO_CODE <> '01'";
						goto IL_0108;
						IL_0108:
						num2 = 21;
						DC_Main.ExeQuteMc(DC_Main.RsQry);
						goto IL_0116;
						IL_0116:
						num2 = 22;
						DC_Main.RsQry = "SELECT LC_CODE FROM LOCT_MAST WHERE CO_CODE = '01' ORDER BY LC_CODE";
						goto IL_0123;
						IL_0123:
						num2 = 23;
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0135;
						IL_0135:
						num2 = 24;
						if (DC_Main.Tbl.Rows.Count > 1)
						{
							goto IL_0153;
						}
						goto IL_0262;
						IL_0153:
						num2 = 25;
						DC_Main.M = 0;
						goto IL_023c;
						IL_023c:
						num2 = 27;
						if (DC_Main.M < DC_Main.Tbl.Rows.Count)
						{
							goto IL_0161;
						}
						goto IL_02cf;
						IL_0161:
						num2 = 28;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"DELETE FROM USER_SET WHERE CO_CODE = '01' AND LC_CODE = '", DC_Main.Tbl.Rows[DC_Main.M]["LC_CODE"]), (object)"' AND  USER_NAME = 'ABC'"));
						goto IL_01a0;
						IL_01a0:
						num2 = 29;
						DC_Main.ExeQuteMc(DC_Main.RsQry);
						goto IL_01ae;
						IL_01ae:
						num2 = 30;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO USER_SET (CO_CODE,LC_CODE,MAIN_SRNO, SUB_SRNO, USER_NAME, MAIN_MENU, SUB_MENU, FRM_VIEW, FRM_EDIT, FRM_DELETE, FRM_PRINT) SELECT '01','", DC_Main.Tbl.Rows[DC_Main.M]["LC_CODE"]), (object)"',MAIN_SRNO,SM_MAIN_CODE,'ABC',BTN_NAME,SM_MAIN_NAME,'Y','Y','Y','Y' FROM MENU_DATA "), Interaction.IIf(Operators.CompareString(DC_Main.MsMfgType, "", false) == 0, (object)"WHERE BTN_NAME NOT IN('Jadtar','Mfg')", (object)"")), (object)" "));
						goto IL_021e;
						IL_021e:
						num2 = 31;
						DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						goto IL_022c;
						IL_022c:
						num2 = 32;
						DC_Main.M++;
						goto IL_023c;
						IL_0262:
						num2 = 35;
						DC_Main.RsQry = "DELETE FROM USER_SET WHERE CO_CODE = '01' AND LC_CODE = '00' AND  USER_NAME = 'ABC'";
						goto IL_026f;
						IL_026f:
						num2 = 36;
						DC_Main.ExeQuteMc(DC_Main.RsQry);
						goto IL_027d;
						IL_027d:
						num2 = 37;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO USER_SET (CO_CODE,LC_CODE,MAIN_SRNO, SUB_SRNO, USER_NAME, MAIN_MENU, SUB_MENU, FRM_VIEW, FRM_EDIT, FRM_DELETE, FRM_PRINT) SELECT '01','00',MAIN_SRNO,SM_MAIN_CODE,'ABC',BTN_NAME,SM_MAIN_NAME,'Y','Y','Y','Y' FROM MENU_DATA ", Interaction.IIf(Operators.CompareString(DC_Main.MsMfgType, "", false) == 0, (object)"WHERE BTN_NAME NOT IN('Jadtar','Mfg')", (object)"")), (object)" "));
						goto IL_02c0;
						IL_02c0:
						num2 = 38;
						DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						goto IL_02cf;
						IL_02cf:
						num2 = 40;
						DC_Main.RsQry = "SELECT LOGIN_NAME FROM LOGIN_MAST WHERE LOGIN_NAME <> 'ABC' GROUP BY LOGIN_NAME ORDER BY LOGIN_NAME";
						goto IL_02dc;
						IL_02dc:
						num2 = 41;
						DC_Main.Tbl = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						goto IL_02ee;
						IL_02ee:
						num2 = 42;
						if (DC_Main.Tbl.Rows.Count > 1)
						{
							goto IL_030c;
						}
						goto IL_056a;
						IL_030c:
						num2 = 43;
						DC_Main.M = 0;
						goto IL_0546;
						IL_0546:
						num2 = 45;
						if (DC_Main.M < DC_Main.Tbl.Rows.Count)
						{
							goto IL_031a;
						}
						goto IL_056a;
						IL_031a:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_0323;
						IL_0323:
						num2 = 47;
						DC_Main.RsQry = "SELECT * FROM USER_SET WHERE CO_CODE = '01' AND LC_CODE = '00' AND  USER_NAME = 'ABC' ORDER BY MAIN_SRNO,SUB_SRNO";
						goto IL_0330;
						IL_0330:
						num2 = 48;
						dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						goto IL_033f;
						IL_033f:
						num2 = 49;
						num5 = 0;
						goto IL_051a;
						IL_051a:
						num2 = 51;
						if (num5 < dataTable.Rows.Count)
						{
							goto IL_034a;
						}
						goto IL_0536;
						IL_0536:
						num2 = 60;
						DC_Main.M++;
						goto IL_0546;
						IL_034a:
						num2 = 52;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT MAIN_MENU FROM USER_SET WHERE CO_CODE = '01' AND LC_CODE = '" + DC_Main.MLc_code + "' AND USER_NAME = '"), DC_Main.Tbl.Rows[DC_Main.M]["LOGIN_NAME"]), (object)"' AND MAIN_SRNO = '"), dataTable.Rows[num5]["MAIN_SRNO"]), (object)"' AND SUB_SRNO = '"), dataTable.Rows[num5]["SUB_SRNO"]), (object)"'"));
						goto IL_03e6;
						IL_03e6:
						num2 = 53;
						DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						goto IL_03f8;
						IL_03f8:
						num2 = 54;
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							goto IL_0416;
						}
						goto IL_0510;
						IL_0416:
						num2 = 55;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO USER_SET (CO_CODE,LC_CODE,MAIN_SRNO, SUB_SRNO, USER_NAME, MAIN_MENU, SUB_MENU, FRM_VIEW, FRM_EDIT, FRM_DELETE, FRM_PRINT)  VALUES ('01','" + DC_Main.MLc_code + "','"), dataTable.Rows[num5]["MAIN_SRNO"]), (object)"','"), dataTable.Rows[num5]["SUB_SRNO"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.M]["LOGIN_NAME"]), (object)"','"), dataTable.Rows[num5]["MAIN_MENU"]), (object)"','"), dataTable.Rows[num5]["SUB_MENU"]), (object)"','Y','Y','Y','Y') "));
						goto IL_0500;
						IL_0500:
						num2 = 56;
						DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						goto IL_0510;
						end_IL_0001_3:
						break;
					}
					num2 = 66;
					Application.Exit();
					break;
				}
				end_IL_0001_2:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1724;
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

	private void TEXT_ENTRY_TextChanged(object sender, EventArgs e)
	{
	}

	private void btnEntryDelete_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "UPDATE SL_ORD_DETL SET SL_ORD_DETL.DESIGN_ISU = 'N' FROM SL_ORD_DETL,MFG_DETL AS B WHERE SL_ORD_DETL.CO_CODE = B.CO_CODE AND SL_ORD_DETL.LC_CODE = B.LC_CODE AND SL_ORD_DETL.CO_YEAR = B.ORD_YRCD  AND SL_ORD_DETL.CO_BOOK = B.ORD_DBCD AND SL_ORD_DETL.VCH_NO = B.ORD_NO AND SL_ORD_DETL.OLD_SRNO = B.ORD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK IN ('301','302','303','304','305','306','307','308','309','310','311','312','313','314','315','316')";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK IN ('301','302','303','304','305','306','307','308','309','310','311','312','313','314','315','316')");
			DC_Main.ExeQuteDc("DELETE FROM MFG_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ");
			DC_Main.ExeQuteDc("DELETE FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
			DC_Main.ExeQuteDc("DELETE FROM MFG_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
			DC_Main.RsQry = "UPDATE MENU_DATA SET SM_VIEW = 'N' WHERE BTN_NAME = 'Mfg' AND SM_MAIN_NAME = 'Mfg Mast'";
			DC_Main.ExeQuteMc(DC_Main.RsQry);
			Interaction.MsgBox((object)"Delete Success.Please Stock and AcData Refresh...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			Application.Exit();
		}
	}
}
