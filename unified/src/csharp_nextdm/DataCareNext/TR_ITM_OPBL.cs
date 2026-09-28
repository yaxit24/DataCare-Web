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
using MSFlexGridLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class TR_ITM_OPBL : Form
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
	[AccessedThroughProperty("cboItemTyp")]
	private ComboBox _cboItemTyp;

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

	private DataTable RsData;

	private DataTable RsDetl;

	private double ColCon;

	private string MaxVchNo;

	private long FGRow;

	private const int cSr = 0;

	private const int cItCode = 1;

	private const int cItName = 2;

	private const int cRateType = 3;

	private const int cPcs = 4;

	private const int cGrWt = 5;

	private const int cNetWt = 6;

	private const int cTouch = 7;

	private const int cWestPrc = 8;

	private const int cFine = 9;

	private const int cRate = 10;

	private const int cItmAmt = 11;

	private const int clbrType = 12;

	private const int cLbrRate = 13;

	private const int cLbrAmt = 14;

	private const int cOthAmt = 15;

	private const int cNetAmt = 16;

	private const int cItType = 17;

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
			EventHandler eventHandler4 = MSG_Scroll;
			EventHandler eventHandler5 = MSG_RowColChange;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
				val.Scroll -= eventHandler4;
				val.RowColChange -= eventHandler5;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
				val.Scroll += eventHandler4;
				val.RowColChange += eventHandler5;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_TOT")]
	private virtual AxMSFlexGrid _MSG_TOT;

	internal virtual AxMSFlexGrid MSG_TOT
	{
		get
		{
			return _MSG_TOT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_MSG_TOT = value;
		}
	}

	internal virtual ComboBox cboItemTyp
	{
		[CompilerGenerated]
		get
		{
			return _cboItemTyp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboItemTyp_KeyDown);
			ComboBox val2 = _cboItemTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboItemTyp = value;
			val2 = _cboItemTyp;
			if (val2 != null)
			{
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

	public TR_ITM_OPBL()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		((Form)this).Load += TR_ITM_OPBL_Load;
		((Form)this).Activated += TR_ITM_OPBL_Activated;
		((Form)this).Deactivate += TR_ITM_OPBL_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_ITM_OPBL_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_ITM_OPBL_KeyDown);
		((Form)this).Closed += TR_ITM_OPBL_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_ITM_OPBL_KeyUp);
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
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Expected O, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Expected O, but got Unknown
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Expected O, but got Unknown
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Unknown result type (might be due to invalid IL or missing references)
		//IL_058a: Expected O, but got Unknown
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f7: Expected O, but got Unknown
		//IL_06a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ab: Expected O, but got Unknown
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c1: Expected O, but got Unknown
		//IL_08df: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e9: Expected O, but got Unknown
		//IL_094c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0956: Expected O, but got Unknown
		//IL_0a00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0a: Expected O, but got Unknown
		//IL_0a6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a77: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_ITM_OPBL));
		lblBook = new Label();
		TEXT_ENTRY = new TextBox();
		MSG_TOT = new AxMSFlexGrid();
		MSG = new AxMSFlexGrid();
		cboItemTyp = new ComboBox();
		Label3 = new Label();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		((ISupportInitialize)MSG_TOT).BeginInit();
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
		lblBook.Text = "Item Opening";
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
		((Control)MSG_TOT).Location = new Point(15, 510);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1154, 16);
		((Control)MSG_TOT).TabIndex = 1123;
		((Control)MSG).Location = new Point(12, 75);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1157, 424);
		((Control)MSG).TabIndex = 1;
		cboItemTyp.AutoCompleteMode = (AutoCompleteMode)3;
		cboItemTyp.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboItemTyp).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(105, 42);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(187, 24);
		((Control)cboItemTyp).TabIndex = 1128;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(12, 43);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(87, 20);
		((Control)Label3).TabIndex = 1129;
		Label3.Text = "Item Type";
		Label3.TextAlign = (ContentAlignment)16;
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
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)MSG_TOT);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "TR_ITM_OPBL";
		((Form)this).Text = "Item Opening";
		((ISupportInitialize)MSG_TOT).EndInit();
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
		mSG.Cols = 18;
		mSG.Rows = 2;
		mSG.Row = 0;
		mSG[0] = 325;
		checked
		{
			mSG[0] = (int)Math.Round(450.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr.";
			mSG[1] = (int)Math.Round(900.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "ItCode";
			mSG[2] = (int)Math.Round(2300.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "Item Name";
			mSG[3] = (int)Math.Round(800.0 * ColCon);
			mSG[3] = 3;
			mSG[0, 3] = "Rtype";
			mSG[4] = (int)Math.Round(750.0 * ColCon);
			mSG[4] = 7;
			mSG[0, 4] = "Pcs";
			mSG[5] = (int)Math.Round(1100.0 * ColCon);
			mSG[5] = 7;
			mSG[0, 5] = "GrWt";
			mSG[6] = (int)Math.Round(1100.0 * ColCon);
			mSG[6] = 7;
			mSG[0, 6] = "NetWt";
			mSG[7] = (int)Math.Round(800.0 * ColCon);
			mSG[7] = 7;
			mSG[0, 7] = "Touch";
			mSG[8] = (int)Math.Round(800.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "West%";
			mSG[9] = (int)Math.Round(1100.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "Fine";
			mSG[10] = (int)Math.Round(900.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "Rate";
			mSG[11] = (int)Math.Round(1150.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "ItmAmt";
			mSG[13] = (int)Math.Round(900.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "LRate";
			mSG[12] = (int)Math.Round(800.0 * ColCon);
			mSG[12] = 3;
			mSG[0, 12] = "LType";
			mSG[14] = (int)Math.Round(1000.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "LbrAmt";
			mSG[15] = (int)Math.Round(900.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "OthAmt";
			mSG[16] = (int)Math.Round(1200.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "NetAmt";
			mSG[17] = 0;
			mSG[16] = 7;
			mSG[0, 17] = "ItType";
			mSG.Row = 1;
			mSG.Col = 0;
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			mSG = null;
			AxMSFlexGrid mSG_TOT = MSG_TOT;
			mSG_TOT.Cols = MSG.Cols;
			int num = MSG.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				mSG_TOT[DC_Main.M] = MSG[DC_Main.M];
				mSG_TOT[DC_Main.M] = MSG[DC_Main.M];
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.MsGridScroll, "N", false) == 0)
			{
				MSG_TOT.ScrollBars = (ScrollBarsSettings)0;
			}
			MSG_TOT_FILL();
			mSG_TOT = null;
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
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
				case 12:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 100;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 4:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
					break;
				case 7:
				case 8:
				case 10:
				case 11:
				case 13:
				case 14:
				case 15:
				case 16:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 5:
				case 6:
				case 9:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
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
			case 12:
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 4:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				CommPassTotal();
				break;
			case 7:
			case 8:
			case 10:
			case 11:
			case 13:
			case 14:
			case 15:
			case 16:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 5:
			case 6:
			case 9:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal();
				break;
			}
			mSG = null;
		}
	}

	private void MSG_Scroll(object sender, EventArgs e)
	{
		if (MSG_TOT.LeftCol != MSG.LeftCol)
		{
			MSG_TOT.LeftCol = MSG.LeftCol;
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG = null;
	}

	private void CommPassTotal()
	{
		AxMSFlexGrid mSG = MSG;
		if (Conversion.Val(mSG[mSG.Row, 6]) == 0.0)
		{
			mSG[mSG.Row, 6] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 5]), "0.000");
		}
		if ((Conversion.Val(mSG[mSG.Row, 7]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 6]) != 0.0))
		{
			mSG[mSG.Row, 9] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 6]) * (Conversion.Val(mSG[mSG.Row, 7]) + Conversion.Val(mSG[mSG.Row, 8])) / 100.0), "0.000");
		}
		else
		{
			mSG[mSG.Row, 9] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 6]), "0.000");
		}
		if ((Operators.CompareString(mSG[mSG.Row, 3], "P", false) == 0) & (Conversion.Val(mSG[mSG.Row, 9]) == 0.0) & (Conversion.Val(mSG[mSG.Row, 4]) != 0.0))
		{
			mSG[mSG.Row, 11] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 4]) * Conversion.Val(mSG[mSG.Row, 10])), "0.00");
		}
		else if ((Conversion.Val(mSG[mSG.Row, 10]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 9]) != 0.0))
		{
			mSG[mSG.Row, 11] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 9]) * Conversion.Val(mSG[mSG.Row, 10])), "0.00");
		}
		if (Conversion.Val(mSG[mSG.Row, 13]) != 0.0)
		{
			switch (mSG[mSG.Row, 12])
			{
			case "P":
				mSG[mSG.Row, 14] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 4]) * Conversion.Val(mSG[mSG.Row, 13]), 0), "0.00");
				break;
			case "N":
				mSG[mSG.Row, 14] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 6]) * Conversion.Val(mSG[mSG.Row, 13]), 0), "0.00");
				break;
			case "K":
				mSG[mSG.Row, 14] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 6]) * (Conversion.Val(mSG[mSG.Row, 13]) / 1000.0), 0), "0.00");
				break;
			case "G":
				mSG[mSG.Row, 14] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 5]) * Conversion.Val(mSG[mSG.Row, 13]), 0), "0.00");
				break;
			default:
				mSG[mSG.Row, 14] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 6]) * Conversion.Val(mSG[mSG.Row, 13]), 0), "0.00");
				break;
			}
		}
		if (Conversion.Val(mSG[mSG.Row, 11]) != 0.0)
		{
			mSG[mSG.Row, 16] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 11]) + Conversion.Val(mSG[mSG.Row, 14]) + Conversion.Val(mSG[mSG.Row, 15])), "0.00");
		}
		mSG[mSG.Row, 16] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 11]) + Conversion.Val(mSG[mSG.Row, 14]) + Conversion.Val(mSG[mSG.Row, 15])), "0.00");
		mSG = null;
		MSG_TOT_FILL();
	}

	private void MSG_TOT_FILL()
	{
		checked
		{
			if (!UpDown)
			{
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				int num = MSG.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					mSG_TOT[0, DC_Main.M] = "";
					DC_Main.M++;
				}
				mSG_TOT[0, 2] = "Total :";
				int num2 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_TOT[0, 4] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 4]) + Conversion.Val(MSG[DC_Main.M, 4]))), "0");
					mSG_TOT[0, 5] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 5]) + Conversion.Val(MSG[DC_Main.M, 5]))), "0.000");
					mSG_TOT[0, 6] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 6]) + Conversion.Val(MSG[DC_Main.M, 6]))), "0.000");
					mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) + Conversion.Val(MSG[DC_Main.M, 9]))), "0.000");
					mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0.00");
					mSG_TOT[0, 16] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 16]) + Conversion.Val(MSG[DC_Main.M, 16]))), "0.00");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 5]) + Conversion.Val(MSG_TOT[0, 6]) + Conversion.Val(MSG_TOT[0, 15]) + Conversion.Val(MSG_TOT[0, 14]);
			}
		}
	}

	private void TOTAL_FILL()
	{
	}

	private void TR_ITM_OPBL_Load(object sender, EventArgs e)
	{
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_0995: Unknown result type (might be due to invalid IL or missing references)
		//IL_099a: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a4: Expected O, but got Unknown
		//IL_09e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f2: Expected O, but got Unknown
		//IL_0a0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1b: Expected O, but got Unknown
		//IL_0a68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6f: Expected O, but got Unknown
		//IL_0aea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af9: Expected O, but got Unknown
		//IL_0b81: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b90: Expected O, but got Unknown
		//IL_0c02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0d: Expected O, but got Unknown
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
			((Control)MSG_TOT).Top = ((Control)MSG).Bottom + 1;
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
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				object? obj10 = colorConverter.ConvertFromString("Silver");
				mSG_TOT.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				AxMSFlexGrid mSG_TOT2 = MSG_TOT;
				object? obj11 = colorConverter.ConvertFromString("Silver");
				mSG_TOT2.BackColorBkg = ((obj11 != null) ? ((Color)obj11) : default(Color));
				AxMSFlexGrid mSG_TOT3 = MSG_TOT;
				object? obj12 = colorConverter.ConvertFromString("Silver");
				mSG_TOT3.BackColorFixed = ((obj12 != null) ? ((Color)obj12) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj13 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AxMSFlexGrid mSG4 = MSG;
				object? obj14 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj15 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj16 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj17 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj18 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj19 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj19 != null) ? ((Color)obj19) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj20 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj21 = lblBook;
				object? obj22 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj21).ForeColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj23 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj24 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj25 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj26 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj27 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj28 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj29 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj29 != null) ? ((Color)obj29) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				num3 = (int)Math.Ceiling((double)((Control)cboItemTyp).Font.Size * (1.0 + num2));
				Font font = ((Control)cboItemTyp).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && ((Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "lblBook", false) != 0)))
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
			cboItemTyp.Items.Add((object)" ");
			cboItemTyp.Items.Add((object)"Gold");
			cboItemTyp.Items.Add((object)"Silver");
			cboItemTyp.Items.Add((object)"Diamond");
			cboItemTyp.Items.Add((object)"Real Stone");
			cboItemTyp.Items.Add((object)"Emitation");
			cboItemTyp.Items.Add((object)"Other");
			cboItemTyp.Items.Add((object)"Platinum");
			cboItemTyp.SelectedIndex = 0;
			CLEAR_DATA();
			EntryMode = "A";
			CurActCtrl = (Control)(object)cboItemTyp;
		}
	}

	private void TR_ITM_OPBL_Activated(object sender, EventArgs e)
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
		cboItemTyp.SelectedIndex = 0;
		((Control)cboItemTyp).Focus();
	}

	private void DISPLAY_DATA()
	{
		MSG_CLEAR();
		string text = ((Operators.CompareString(DC_Main.MsDataType, "C", false) != 0) ? DC_Main.MsDataType : "A");
		DC_Main.RsQry = "SELECT * FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_TYPE ='" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'  ORDER BY IT_TYPE,GR_CODE,IT_NAME";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.i = 0;
		AxMSFlexGrid mSG = MSG;
		checked
		{
			while (DC_Main.i < DC_Main.Tbl.Rows.Count)
			{
				mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
				mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["IT_CODE"], (object)""));
				mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["IT_NAME"], (object)""));
				mSG[DC_Main.i + 1, 17] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
				mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM ITM_OPBL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE ='" + DC_Main.MLc_code + "' AND IT_CODE = '"), DC_Main.Tbl.Rows[DC_Main.i]["IT_CODE"]), (object)"' AND DATA_TYPE = '"), (object)text), (object)"'"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					mSG[DC_Main.i + 1, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_PCS"]), "0");
					mSG[DC_Main.i + 1, 5] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"]), "0.000");
					mSG[DC_Main.i + 1, 6] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"]), "0.000");
					mSG[DC_Main.i + 1, 7] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"]), "0.00");
					mSG[DC_Main.i + 1, 8] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"]), "0.00");
					mSG[DC_Main.i + 1, 9] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"]), "0.000");
					mSG[DC_Main.i + 1, 10] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"]), "0.00");
					mSG[DC_Main.i + 1, 11] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"]), "0.00");
					mSG[DC_Main.i + 1, 13] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"]), "0.00");
					mSG[DC_Main.i + 1, 12] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 14] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"]), "0.00");
					mSG[DC_Main.i + 1, 15] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"]), "0.00");
					mSG[DC_Main.i + 1, 16] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["NET_AMT"]), "0.00");
					if (Conversion.Val(mSG[DC_Main.i + 1, 4]) == 0.0)
					{
						mSG[DC_Main.i + 1, 4] = "";
					}
					if (Conversion.Val(mSG[DC_Main.i + 1, 5]) == 0.0)
					{
						mSG[DC_Main.i + 1, 5] = "";
					}
					if (Conversion.Val(mSG[DC_Main.i + 1, 6]) == 0.0)
					{
						mSG[DC_Main.i + 1, 6] = "";
					}
					if (Conversion.Val(mSG[DC_Main.i + 1, 7]) == 0.0)
					{
						mSG[DC_Main.i + 1, 7] = "";
					}
					if (Conversion.Val(mSG[DC_Main.i + 1, 9]) == 0.0)
					{
						mSG[DC_Main.i + 1, 9] = "";
					}
					if (Conversion.Val(mSG[DC_Main.i + 1, 10]) == 0.0)
					{
						mSG[DC_Main.i + 1, 10] = "";
					}
					if (Conversion.Val(mSG[DC_Main.i + 1, 11]) == 0.0)
					{
						mSG[DC_Main.i + 1, 11] = "";
					}
					if (Conversion.Val(mSG[DC_Main.i + 1, 14]) == 0.0)
					{
						mSG[DC_Main.i + 1, 14] = "";
					}
					if (Conversion.Val(mSG[DC_Main.i + 1, 15]) == 0.0)
					{
						mSG[DC_Main.i + 1, 15] = "";
					}
					if (Conversion.Val(mSG[DC_Main.i + 1, 16]) == 0.0)
					{
						mSG[DC_Main.i + 1, 16] = "";
					}
				}
				else
				{
					mSG[DC_Main.i + 1, 4] = "";
					mSG[DC_Main.i + 1, 5] = "";
					mSG[DC_Main.i + 1, 6] = "";
					mSG[DC_Main.i + 1, 7] = "";
					mSG[DC_Main.i + 1, 9] = "";
					mSG[DC_Main.i + 1, 10] = "";
					mSG[DC_Main.i + 1, 11] = "";
					mSG[DC_Main.i + 1, 14] = "";
					mSG[DC_Main.i + 1, 15] = "";
					mSG[DC_Main.i + 1, 16] = "";
				}
				mSG.Rows += 1;
				DC_Main.i++;
			}
			if (mSG.Rows > 2)
			{
				mSG.Rows -= 1;
			}
			mSG = null;
			MSG_TOT_FILL();
			OldValTot = Conversion.Val(MSG_TOT[0, 5]) + Conversion.Val(MSG_TOT[0, 6]) + Conversion.Val(MSG_TOT[0, 15]) + Conversion.Val(MSG_TOT[0, 14]);
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
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_063c: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
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
					{
						if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
						{
							Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
							goto end_IL_0001;
						}
						if (Operators.CompareString(Strings.Mid(cboItemTyp.Text, 1, 1), "", false) == 0)
						{
							Interaction.MsgBox((object)"Please Select Metaltype....", (MsgBoxStyle)0, (object)null);
							goto end_IL_0001;
						}
						ProjectData.ClearProjectError();
						num2 = 2;
						MSG_TOT_FILL();
						string text = ((Operators.CompareString(DC_Main.MsDataType, "C", false) != 0) ? DC_Main.MsDataType : "A");
						DC_Main.OpenRecordSetDc("DELETE FROM ITM_OPBL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND  VCH_NO = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' AND DATA_TYPE = '" + text + "'");
						DC_Main.RsQry = "SELECT * FROM ITM_OPBL WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND  VCH_NO = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' AND DATA_TYPE = '" + text + "' ";
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow = RsDetl.NewRow();
						int num3 = MSG.Rows - 1;
						DC_Main.i = 1;
						while (DC_Main.i <= num3)
						{
							if (Conversion.Val(MSG[DC_Main.i, 5]) + Conversion.Val(MSG[DC_Main.i, 4]) != 0.0)
							{
								dataRow["CO_CODE"] = DC_Main.MCo_code;
								dataRow["LC_CODE"] = DC_Main.MLc_code;
								dataRow["CO_YEAR"] = DC_Main.MCo_year;
								dataRow["CO_BOOK"] = "000";
								dataRow["VCH_NO"] = Strings.Mid(cboItemTyp.Text, 1, 1);
								dataRow["SR_NO"] = DC_Main.i;
								dataRow["IT_CODE"] = MSG[DC_Main.i, 1];
								dataRow["ITM_PCS"] = Conversion.Val(MSG[DC_Main.i, 4]);
								dataRow["ITM_GWT"] = Conversion.Val(MSG[DC_Main.i, 5]);
								dataRow["ITM_NWT"] = Conversion.Val(MSG[DC_Main.i, 6]);
								dataRow["ITM_TOUCH"] = Conversion.Val(MSG[DC_Main.i, 7]);
								dataRow["ITM_WEST_PRC"] = Conversion.Val(MSG[DC_Main.i, 8]);
								dataRow["ITM_FINE"] = Conversion.Val(MSG[DC_Main.i, 9]);
								dataRow["ITM_RATE"] = Conversion.Val(MSG[DC_Main.i, 10]);
								dataRow["ITM_AMT"] = Conversion.Val(MSG[DC_Main.i, 11]);
								dataRow["LBR_TYPE"] = MSG[DC_Main.i, 12];
								dataRow["LBR_RATE"] = Conversion.Val(MSG[DC_Main.i, 13]);
								dataRow["LBR_AMT"] = Conversion.Val(MSG[DC_Main.i, 14]);
								dataRow["OTH_AMT"] = Conversion.Val(MSG[DC_Main.i, 15]);
								dataRow["NET_AMT"] = Conversion.Val(MSG[DC_Main.i, 16]);
								dataRow["MAIN_USER"] = MainUser;
								dataRow["DATA_TYPE"] = text;
								RsDetl.Rows.Add(dataRow);
								((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
								RsDetl.Clear();
							}
							DC_Main.i++;
						}
						DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND VCH_NO = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Ac_Stock.Itm_Opbl_Stk("000", Strings.Mid(cboItemTyp.Text, 1, 1));
						DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND VCH_NO = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Ac_Stock.Dm_Itm_Opbl_Detl("000", Strings.Mid(cboItemTyp.Text, 1, 1));
						Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						CLEAR_DATA();
						goto end_IL_0001;
					}
					case 1652:
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
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1652;
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
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(cboItemTyp.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Item For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete All Item Opening From This Record now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND VCH_NO = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND VCH_NO = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM ITM_OPBL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '000' AND VCH_NO = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
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

	private void TR_ITM_OPBL_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_ITM_OPBL_KeyPress(object sender, KeyPressEventArgs e)
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

	private void TR_ITM_OPBL_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
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
				MSG_TOT_FILL();
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
				case 16:
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

	private void cboItemTyp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			DISPLAY_DATA();
			MSG.Row = 1;
			MSG.Col = 3;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void TR_ITM_OPBL_Closed(object sender, EventArgs e)
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

	private void TR_ITM_OPBL_KeyUp(object sender, KeyEventArgs e)
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
}
