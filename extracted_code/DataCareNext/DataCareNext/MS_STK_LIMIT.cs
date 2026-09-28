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
public class MS_STK_LIMIT : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Text1")]
	private TextBox _Text1;

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
	[AccessedThroughProperty("DGV")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItCode")]
	private TextBox _tItCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tDesignNo")]
	private TextBox _tDesignNo;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private bool MsgClear;

	private string CurMast;

	private DataTable RsData;

	private DataTable RsDetl;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int cSrNo = 0;

	private const int cFromWt = 1;

	private const int cToWt = 2;

	private const int cMinPcs = 3;

	private const int cLbrCode = 4;

	private const int cGhtPrc = 5;

	private const int cLbrPrc = 6;

	private const int cMinLbrPrc = 7;

	private const int cLbrType = 8;

	private const int cLbrRate = 9;

	private const int cLbrAmt = 10;

	private const int cDmSrNo = 0;

	private const int cDmSize = 1;

	private const int cDmWt = 2;

	private const int cDmPcsGht = 3;

	private const int cDmPcsLbr = 4;

	private const int cDmRateType = 5;

	private const int cDmRate = 6;

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
			EventHandler eventHandler2 = MSG_Enter;
			EventHandler eventHandler3 = MSG_EnterCell;
			EventHandler eventHandler4 = MSG_LeaveCell;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				((Control)val).Enter -= eventHandler2;
				val.EnterCell -= eventHandler3;
				val.LeaveCell -= eventHandler4;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				((Control)val).Enter += eventHandler2;
				val.EnterCell += eventHandler3;
				val.LeaveCell += eventHandler4;
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

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV
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
			EventHandler eventHandler = DGV_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val = _DGV;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_DGV = value;
			val = _DGV;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual TextBox tItCode
	{
		[CompilerGenerated]
		get
		{
			return _tItCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tItCode_KeyDown);
			TextBox val2 = _tItCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tItCode = value;
			val2 = _tItCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItName")]
	private virtual TextBox _tItName;

	internal virtual TextBox tItName
	{
		get
		{
			return _tItName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tItName = value;
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
	[AccessedThroughProperty("Label11")]
	private virtual Label _Label11;

	internal virtual Label Label11
	{
		get
		{
			return _Label11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label11 = value;
		}
	}

	internal virtual TextBox tDesignNo
	{
		[CompilerGenerated]
		get
		{
			return _tDesignNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tDesignNo_KeyDown);
			TextBox val2 = _tDesignNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tDesignNo = value;
			val2 = _tDesignNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	public MS_STK_LIMIT()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		((Form)this).Load += MS_STK_LIMIT_Load;
		((Form)this).Activated += MS_STK_LIMIT_Activated;
		((Form)this).Deactivate += MS_STK_LIMIT_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_STK_LIMIT_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_STK_LIMIT_KeyDown);
		((Form)this).Closed += MS_STK_LIMIT_Closed;
		((Control)this).KeyUp += new KeyEventHandler(MS_STK_LIMIT_KeyUp);
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected O, but got Unknown
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Expected O, but got Unknown
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_057e: Expected O, but got Unknown
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_062f: Expected O, but got Unknown
		//IL_0738: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Expected O, but got Unknown
		//IL_085d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0867: Expected O, but got Unknown
		//IL_08ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d4: Expected O, but got Unknown
		//IL_097b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0985: Expected O, but got Unknown
		//IL_09e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f2: Expected O, but got Unknown
		//IL_0ac4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ace: Expected O, but got Unknown
		//IL_0b63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6d: Expected O, but got Unknown
		//IL_0beb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf5: Expected O, but got Unknown
		//IL_0cce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd8: Expected O, but got Unknown
		//IL_0d41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4b: Expected O, but got Unknown
		//IL_0dee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df8: Expected O, but got Unknown
		//IL_0e75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7f: Expected O, but got Unknown
		//IL_0f03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0d: Expected O, but got Unknown
		//IL_0faa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb4: Expected O, but got Unknown
		//IL_1072: Unknown result type (might be due to invalid IL or missing references)
		//IL_107c: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_STK_LIMIT));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		lblBook = new Label();
		Text1 = new TextBox();
		MSG = new AxMSFlexGrid();
		TEXT_ENTRY = new TextBox();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		tItCode = new TextBox();
		tItName = new TextBox();
		Label4 = new Label();
		Label11 = new Label();
		tDesignNo = new TextBox();
		((ISupportInitialize)MSG).BeginInit();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)DGV).BeginInit();
		((Control)this).SuspendLayout();
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblBook).Dock = (DockStyle)1;
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).Font = new Font("Segoe UI", 14.25f);
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		((Control)lblBook).Location = new Point(0, 0);
		((Control)lblBook).Name = "lblBook";
		((Control)lblBook).Size = new Size(1309, 32);
		((Control)lblBook).TabIndex = 101;
		lblBook.Text = "Item Stock Limit Master";
		lblBook.TextAlign = (ContentAlignment)32;
		Text1.AcceptsReturn = true;
		((TextBoxBase)Text1).BackColor = SystemColors.ButtonHighlight;
		((TextBoxBase)Text1).BorderStyle = (BorderStyle)0;
		((Control)Text1).Cursor = Cursors.IBeam;
		((Control)Text1).Font = new Font("Franklin Gothic Book", 11.25f);
		((TextBoxBase)Text1).ForeColor = Color.Navy;
		((Control)Text1).Location = new Point(64, 42);
		((Control)Text1).Margin = new Padding(2);
		((TextBoxBase)Text1).MaxLength = 50;
		((Control)Text1).Name = "Text1";
		((Control)Text1).RightToLeft = (RightToLeft)0;
		((Control)Text1).Size = new Size(402, 18);
		((Control)Text1).TabIndex = 4;
		Text1.Text = "SEARCH RECORD";
		Text1.TextAlign = (HorizontalAlignment)2;
		((Control)MSG).Location = new Point(513, 165);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(632, 318);
		((Control)MSG).TabIndex = 9;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)TEXT_ENTRY).Location = new Point(827, 354);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 2;
		((Control)TEXT_ENTRY).Visible = false;
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
		((Control)PnlBotam).TabIndex = 3;
		((BaseStyleControl)BtnExit).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
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
		((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
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
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
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
		((BaseStyleControl)BtnSave).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
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
		((BaseStyleControl)BtnPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1);
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
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV).ColumnHeadersHeight = 30;
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val3;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(127, 127, 127);
		((Control)DGV).Location = new Point(63, 69);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		((DataGridView)DGV).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV).RowHeadersVisible = false;
		((DataGridView)DGV).RowHeadersWidth = 20;
		val5.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(404, 469);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 111;
		((TextBoxBase)tItCode).BackColor = Color.White;
		((Control)tItCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tItCode).Location = new Point(613, 97);
		((TextBoxBase)tItCode).MaxLength = 8;
		((Control)tItCode).Name = "tItCode";
		((Control)tItCode).Size = new Size(76, 23);
		((Control)tItCode).TabIndex = 0;
		((TextBoxBase)tItName).BackColor = Color.White;
		((Control)tItName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tItName).Location = new Point(695, 97);
		((TextBoxBase)tItName).MaxLength = 8;
		((Control)tItName).Name = "tItName";
		((Control)tItName).Size = new Size(375, 23);
		((Control)tItName).TabIndex = 1175;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(546, 96);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(60, 20);
		((Control)Label4).TabIndex = 1174;
		Label4.Text = "It Code";
		Label4.TextAlign = (ContentAlignment)64;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(513, 131);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(94, 20);
		((Control)Label11).TabIndex = 1185;
		Label11.Text = "Design";
		Label11.TextAlign = (ContentAlignment)64;
		((Control)Label11).Visible = false;
		((TextBoxBase)tDesignNo).BackColor = Color.White;
		((Control)tDesignNo).Font = new Font("Tahoma", 9f);
		((Control)tDesignNo).Location = new Point(613, 132);
		((TextBoxBase)tDesignNo).MaxLength = 15;
		((Control)tDesignNo).Name = "tDesignNo";
		((Control)tDesignNo).Size = new Size(145, 22);
		((Control)tDesignNo).TabIndex = 1;
		((Control)tDesignNo).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)tDesignNo);
		((Control)this).Controls.Add((Control)(object)tItCode);
		((Control)this).Controls.Add((Control)(object)tItName);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)Text1);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_STK_LIMIT";
		((Form)this).Text = "Item Stock Limit Master";
		((ISupportInitialize)MSG).EndInit();
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)DGV).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (Operators.CompareString(CurMast, "Dm Size", false) == 0)
			{
				mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
				if (mSG.Row > 1)
				{
					mSG[mSG.Row, 3] = Strings.Format((object)Conversion.Val(mSG[mSG.Row - 1, 3]), "0.000");
					mSG[mSG.Row, 4] = mSG[mSG.Row - 1, 4];
				}
			}
			else
			{
				mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
				if (mSG.Row > 1)
				{
					mSG[mSG.Row, 1] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row - 1, 2]) + 0.001), "0.000");
					mSG[mSG.Row, 4] = mSG[mSG.Row - 1, 4];
					mSG[mSG.Row, 5] = Strings.Format((object)Conversion.Val(mSG[mSG.Row - 1, 5]), "0.00");
					mSG[mSG.Row, 6] = Strings.Format((object)Conversion.Val(mSG[mSG.Row - 1, 6]), "0.00");
					mSG[mSG.Row, 8] = mSG[mSG.Row - 1, 8];
					mSG[mSG.Row, 9] = Strings.Format((object)Conversion.Val(mSG[mSG.Row - 1, 9]), "0.00");
				}
			}
			mSG = null;
		}
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		checked
		{
			if (Operators.CompareString(CurMast, "Dm Size", false) == 0)
			{
				mSG.Cols = 7;
				mSG.Rows = 2;
				mSG.Row = 0;
				mSG[0] = 325;
				mSG[0] = (int)Math.Round(500.0 * ColCon);
				mSG[0] = 3;
				mSG[0, 0] = "Sr";
				mSG[1] = (int)Math.Round(1500.0 * ColCon);
				mSG[1] = 0;
				mSG[0, 1] = "DmSize";
				mSG[2] = (int)Math.Round(1100.0 * ColCon);
				mSG[2] = 7;
				mSG[0, 2] = "DmWt";
				mSG[3] = (int)Math.Round(1100.0 * ColCon);
				mSG[3] = 7;
				mSG[0, 3] = "PcsGht";
				mSG[4] = (int)Math.Round(1100.0 * ColCon);
				mSG[4] = 7;
				mSG[0, 4] = "PcsLbr";
				mSG[5] = (int)Math.Round(900.0 * ColCon);
				mSG[5] = 3;
				mSG[0, 5] = "RtType";
				mSG[6] = (int)Math.Round(1100.0 * ColCon);
				mSG[6] = 7;
				mSG[0, 6] = "Rate";
			}
			else
			{
				mSG.Cols = 11;
				mSG.Rows = 2;
				mSG.Row = 0;
				mSG[0] = 325;
				mSG[0] = (int)Math.Round(500.0 * ColCon);
				mSG[0] = 3;
				mSG[0, 0] = "Sr";
				mSG[1] = (int)Math.Round(900.0 * ColCon);
				mSG[1] = 7;
				mSG[0, 1] = "FormWt";
				mSG[2] = (int)Math.Round(900.0 * ColCon);
				mSG[2] = 7;
				mSG[0, 2] = "ToWt";
				mSG[3] = (int)Math.Round(700.0 * ColCon);
				mSG[3] = 3;
				mSG[0, 3] = "Pcs";
				mSG[4] = (int)Math.Round(900.0 * ColCon);
				mSG[4] = 3;
				mSG[0, 4] = "LbrCode";
				mSG[5] = (int)Math.Round(750.0 * ColCon);
				mSG[5] = 7;
				mSG[0, 5] = "Ght%";
				mSG[6] = (int)Math.Round(800.0 * ColCon);
				mSG[6] = 7;
				mSG[0, 6] = "Lbr%";
				mSG[7] = (int)Math.Round(850.0 * ColCon);
				mSG[7] = 7;
				mSG[0, 7] = "MinLbr%";
				mSG[8] = (int)Math.Round(800.0 * ColCon);
				mSG[8] = 3;
				mSG[0, 8] = "LType";
				mSG[9] = (int)Math.Round(1000.0 * ColCon);
				mSG[9] = 7;
				mSG[0, 9] = "LbrRate";
				mSG[10] = (int)Math.Round(1000.0 * ColCon);
				mSG[10] = 7;
				mSG[0, 10] = "LbrAmt";
			}
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			CommPassAdd();
			mSG = null;
		}
	}

	private void MSG_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
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
				mSG = null;
			}
		}
	}

	private void MSG_Enter(object sender, EventArgs e)
	{
		if (((Control)TEXT_ENTRY).Visible)
		{
			TEXT_ENTRY.Text = MSG[MSG.Row, MSG.Col];
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void MSG_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		if (MsgClear || ((mSG.Row == 0) | (mSG.CellWidth <= 0)))
		{
			return;
		}
		checked
		{
			((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
			((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
			((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
			((Control)TEXT_ENTRY).Height = (int)Math.Round((double)mSG.CellHeight / 15.0);
			((Control)TEXT_ENTRY).Visible = true;
			if (((Control)TEXT_ENTRY).Visible)
			{
				((Control)TEXT_ENTRY).Focus();
			}
			((TextBoxBase)TEXT_ENTRY).ReadOnly = false;
			Application.DoEvents();
			if (Operators.CompareString(CurMast, "Dm Size", false) == 0)
			{
				switch (MSG.Col)
				{
				case 0:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 5:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 4:
				case 6:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 2:
				case 3:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
					break;
				}
			}
			else
			{
				switch (MSG.Col)
				{
				case 0:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
					break;
				case 8:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 4:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 4;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 5:
				case 6:
				case 7:
				case 9:
				case 10:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 1:
				case 2:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
					break;
				}
			}
			mSG = null;
			((TextBoxBase)TEXT_ENTRY).SelectAll();
		}
	}

	private void MSG_LeaveCell(object sender, EventArgs e)
	{
		if (MsgClear || MSG.Row == 0 || !((Control)TEXT_ENTRY).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG = MSG;
		if (Operators.CompareString(CurMast, "Dm Size", false) == 0)
		{
			switch (MSG.Col)
			{
			case 0:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				break;
			case 1:
			case 5:
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 4:
			case 6:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				break;
			case 2:
			case 3:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				break;
			}
		}
		else
		{
			switch (MSG.Col)
			{
			case 0:
			case 3:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				break;
			case 4:
			case 8:
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 5:
			case 6:
			case 7:
			case 9:
			case 10:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				break;
			case 1:
			case 2:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				break;
			}
		}
		((Control)TEXT_ENTRY).Visible = false;
		mSG = null;
	}

	private void TEXT_ENTRY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Invalid comparison between Unknown and I4
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected I4, but got Unknown
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
		//IL_060f: Unknown result type (might be due to invalid IL or missing references)
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
						mSG.Col -= 1;
					}
					return;
				case 2:
					if (mSG.Col < mSG.Cols - 1)
					{
						mSG.Col += 1;
					}
					return;
				case 1:
					if (mSG.Row > 1)
					{
						mSG.Row -= 1;
					}
					return;
				case 3:
					if (mSG.Row < mSG.Rows - 1)
					{
						mSG.Row += 1;
					}
					return;
				}
			}
			else
			{
				if (Operators.CompareString(CurMast, "Dm Size", false) == 0)
				{
					if (mSG.Col == 1)
					{
						if (mSG.Row == mSG.Rows - 1 && Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
						{
							((Control)BtnSave).Enabled = true;
							((Control)BtnSave).Focus();
							MSG_LeaveCell(MSG, new EventArgs());
							return;
						}
					}
					else if (mSG.Col != 5)
					{
						if (mSG.Col == 2)
						{
							if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
							{
								return;
							}
						}
						else if (mSG.Col != 3 && mSG.Col == 6)
						{
							if (mSG.Row == mSG.Rows - 1)
							{
								MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
								mSG.Rows += 1;
								mSG.Row += 1;
								CommPassAdd();
								mSG.Col = 1;
							}
							else
							{
								mSG.Row += 1;
							}
							return;
						}
					}
				}
				else if (mSG.Col == 1)
				{
					if (mSG.Row == mSG.Rows - 1)
					{
						if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
						{
							((Control)BtnSave).Enabled = true;
							((Control)BtnSave).Focus();
							MSG_LeaveCell(MSG, new EventArgs());
							return;
						}
					}
					else if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
					{
						return;
					}
				}
				else if (mSG.Col == 4)
				{
					if (Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From LBR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LBR_CODE = '" + TEXT_ENTRY.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT LBR_CODE As LbrCodeL,LBR_CATG as CategoryL,LBR_VAL As LbrValueR  FROM LBR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY LBR_CATG,LBR_CODE";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[4];
							DC_Main.ColWidth[0] = 90.0;
							DC_Main.ColWidth[1] = 250.0;
							DC_Main.ColWidth[2] = 110.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[0];
									mSG[mSG.Row, 4] = DC_Main.ColValue[0];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CODE"], (object)""));
					}
				}
				else if (mSG.Col == 2)
				{
					if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
					{
						return;
					}
				}
				else if (mSG.Col == 3)
				{
					if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
					{
						return;
					}
				}
				else if (mSG.Col == 8)
				{
					if (Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0 && ((Operators.CompareString(TEXT_ENTRY.Text, "G", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, "N", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, "P", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, "F", false) != 0)))
					{
						Interaction.MsgBox((object)"Please Insert Lbr Type = G Gross OR N Net OR P Pcs Wise OR F fix OR K Kg Wise Then Try...", (MsgBoxStyle)0, (object)null);
						return;
					}
				}
				else if (mSG.Col == 10)
				{
					if (mSG.Row == mSG.Rows - 1)
					{
						MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
						mSG.Rows += 1;
						mSG.Row += 1;
						CommPassAdd();
						mSG.Col = 1;
					}
					else
					{
						mSG.Row += 1;
					}
				}
				if (mSG.Col < mSG.Cols - 1)
				{
					MSG.Col += 1;
					((Control)TEXT_ENTRY).Visible = true;
					((Control)TEXT_ENTRY).Focus();
				}
			}
			mSG = null;
		}
	}

	private void MS_STK_LIMIT_Load(object sender, EventArgs e)
	{
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_0935: Unknown result type (might be due to invalid IL or missing references)
		//IL_093a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0944: Expected O, but got Unknown
		//IL_0983: Unknown result type (might be due to invalid IL or missing references)
		//IL_0988: Unknown result type (might be due to invalid IL or missing references)
		//IL_0992: Expected O, but got Unknown
		//IL_0a06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a15: Expected O, but got Unknown
		//IL_0a34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a43: Expected O, but got Unknown
		//IL_0a62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a71: Expected O, but got Unknown
		//IL_0b1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b25: Expected O, but got Unknown
		//IL_0ba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baf: Expected O, but got Unknown
		//IL_0c37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c46: Expected O, but got Unknown
		//IL_0cb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc3: Expected O, but got Unknown
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
				AxMSFlexGrid mSG = MSG;
				object? obj8 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj9 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj9 != null) ? ((Color)obj9) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj10 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj10 != null) ? ((Color)obj10) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj11 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				object? obj12 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj14 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj15 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj16 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj16 != null) ? ((Color)obj16) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj17 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				((TextBoxBase)Text1).BackColor = ((Form)this).BackColor;
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj18 = lblBook;
				object? obj19 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj18).ForeColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj20 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				object? obj21 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj22 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj23 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj24 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj25 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj25 != null) ? ((Color)obj25) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
				}
				num3 = (int)Math.Ceiling((double)((Control)tItCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tItCode).Font;
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
			if (Operators.CompareString(DC_Main.MsStkLimitWithDesign, "Y", false) == 0)
			{
				((Control)Label11).Visible = true;
				((Control)tDesignNo).Visible = true;
			}
			CLEAR_DATA();
			CurActCtrl = (Control)(object)tItCode;
		}
	}

	private void MS_STK_LIMIT_Activated(object sender, EventArgs e)
	{
		((ContainerControl)this).ActiveControl = CurActCtrl;
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV).DataSource = null;
	}

	private void DGV_FILL()
	{
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Expected O, but got Unknown
		DGV_CLEAR();
		if (Operators.CompareString(CurMast, "Dm Size", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.IT_CODE,A.DM_SIZE As IT_NAME, '' As DesignL FROM DM_SIZE AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY A.IT_CODE,A.DM_SIZE  ORDER BY A.IT_CODE,A.DM_SIZE ";
		}
		else
		{
			DC_Main.RsQry = "SELECT A.IT_CODE,B.IT_NAME,A.IT_DESIGN FROM ITM_WT_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY A.IT_CODE,B.IT_NAME,A.IT_DESIGN  ORDER BY A.IT_CODE,A.IT_DESIGN ";
		}
		RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(RsMast);
		checked
		{
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
				((DataGridView)DGV).ColumnCount = 3;
				((DataGridView)DGV).Columns[0].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV).Columns[0].DataPropertyName = "IT_CODE";
				((DataGridView)DGV).Columns[0].HeaderText = "Code";
				if (Operators.CompareString(DC_Main.MsStkLimitWithDesign, "Y", false) == 0)
				{
					((DataGridView)DGV).Columns[1].Width = (int)Math.Round(200.0 * ColCon);
				}
				else
				{
					((DataGridView)DGV).Columns[1].Width = (int)Math.Round(300.0 * ColCon);
				}
				((DataGridView)DGV).Columns[1].DataPropertyName = "IT_NAME";
				if (Operators.CompareString(CurMast, "Dm Size", false) == 0)
				{
					((DataGridView)DGV).Columns[1].HeaderText = "Size";
				}
				else
				{
					((DataGridView)DGV).Columns[1].HeaderText = "Name";
				}
				if (Operators.CompareString(DC_Main.MsStkLimitWithDesign, "Y", false) == 0)
				{
					((DataGridView)DGV).Columns[2].Width = (int)Math.Round(110.0 * ColCon);
					((DataGridView)DGV).Columns[2].DataPropertyName = "IT_DESIGN";
					((DataGridView)DGV).Columns[2].HeaderText = "Design";
				}
				else
				{
					((DataGridView)DGV).Columns[2].Visible = false;
				}
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				((DataGridView)DGV).DataSource = dataView;
			}
		}
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
		DGV_CLEAR();
		MSG_CLEAR();
		CommPassAdd();
		((TextBoxBase)tItCode).ReadOnly = false;
		Text1.Text = "SEARCH RECORD";
		EntryMode = "A";
		if (Operators.CompareString(CurMast, "Dm Size", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.IT_CODE,A.DM_SIZE FROM DM_SIZE AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY A.IT_CODE,A.DM_SIZE  ORDER BY A.IT_CODE,A.DM_SIZE ";
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.RsQry = "SELECT A.IT_CODE,B.IT_NAME FROM ITM_WT_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY A.IT_CODE,B.IT_NAME  ORDER BY A.IT_CODE ";
			RsMast = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		DGV_FILL();
		EntryMode = "A";
		((Control)tItCode).Focus();
	}

	private void DISPLAY_DATA()
	{
		MSG_CLEAR();
		if (Operators.CompareString(tItCode.Text, "", false) == 0)
		{
			return;
		}
		checked
		{
			if (Operators.CompareString(CurMast, "Dm Size", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM DM_SIZE AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.IT_CODE = '" + tItCode.Text + "' ORDER BY DM_SIZE ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tItCode.Text = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"]);
					tItName.Text = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"]);
				}
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 2] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_WT"], (object)"")), "0.000");
					mSG[DC_Main.i + 1, 3] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PCS_GHT"], (object)"")), "0.000");
					mSG[DC_Main.i + 1, 4] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PCS_LBR"], (object)"")), "0.00");
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 6] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_RATE"], (object)"")), "0.00");
					mSG.Rows += 1;
					DC_Main.i++;
				}
				if (mSG.Rows > 2)
				{
					mSG.Rows -= 1;
				}
				mSG = null;
			}
			else
			{
				if ((Operators.CompareString(tDesignNo.Text, "", false) == 0) | (Operators.CompareString(tDesignNo.Text, "N", false) == 0))
				{
					DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM ITM_WT_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.IT_CODE = '" + tItCode.Text + "' AND A.IT_DESIGN = 'N' ORDER BY A.SR_NO ";
				}
				else
				{
					DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM ITM_WT_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.IT_CODE = '" + tItCode.Text + "' AND A.IT_DESIGN = '" + tDesignNo.Text + "' ORDER BY A.SR_NO ";
				}
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tItCode.Text = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"]);
					tItName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)""));
					tDesignNo.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_DESIGN"], (object)""));
				}
				AxMSFlexGrid mSG2 = MSG;
				while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
				{
					mSG2[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG2[DC_Main.i + 1, 1] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["FROM_WT"], (object)"")), "0.000");
					mSG2[DC_Main.i + 1, 2] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TO_WT"], (object)"")), "0.000");
					mSG2[DC_Main.i + 1, 3] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["MIN_PCS"], (object)"")), "0");
					mSG2[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_CODE"], (object)""));
					mSG2[DC_Main.i + 1, 5] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["GHT_PRC"], (object)"")), "0.00");
					mSG2[DC_Main.i + 1, 6] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_PRC"], (object)"")), "0.00");
					mSG2[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["MIN_LBR_PRC"], (object)"")), "0.00");
					mSG2[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG2[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_RATE"], (object)"")), "0.00");
					mSG2[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_AMT"], (object)"")), "0.00");
					mSG2.Rows += 1;
					DC_Main.i++;
				}
				if (mSG2.Rows > 2)
				{
					mSG2.Rows -= 1;
				}
				mSG2 = null;
			}
			EntryMode = "E";
			((TextBoxBase)tItCode).ReadOnly = true;
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
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(tItCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Error Found : Please Enter Item code First...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			return;
		}
		checked
		{
			if (Operators.CompareString(CurMast, "Dm Size", false) == 0)
			{
				DC_Main.RsQry = "DELETE FROM DM_SIZE WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  IT_CODE = '" + tItCode.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "SELECT * FROM DM_SIZE WHERE CO_CODE  = '" + DC_Main.MCo_code + "'  AND IT_CODE  = '" + tItCode.Text + "' ";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow = RsDetl.NewRow();
				int num = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num)
				{
					if ((Operators.CompareString(tItCode.Text, "", false) != 0) & (Operators.CompareString(MSG[DC_Main.i, 1], "", false) != 0))
					{
						dataRow["CO_CODE"] = DC_Main.MCo_code;
						dataRow["IT_CODE"] = tItCode.Text;
						dataRow["DM_SIZE"] = MSG[DC_Main.i, 1];
						dataRow["DM_WT"] = Conversion.Val(MSG[DC_Main.i, 2]);
						dataRow["PCS_GHT"] = Conversion.Val(MSG[DC_Main.i, 3]);
						dataRow["PCS_LBR"] = Conversion.Val(MSG[DC_Main.i, 4]);
						dataRow["RATE_TYPE"] = MSG[DC_Main.i, 5];
						dataRow["DM_RATE"] = Conversion.Val(MSG[DC_Main.i, 6]);
						RsDetl.Rows.Add(dataRow);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
					DC_Main.i++;
				}
			}
			else
			{
				DC_Main.RsQry = "DELETE FROM ITM_WT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  IT_CODE = '" + tItCode.Text + "' AND IT_DESIGN = '" + tDesignNo.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "SELECT * FROM ITM_WT_MAST WHERE CO_CODE  = '" + DC_Main.MCo_code + "'  AND IT_CODE  = '" + tItCode.Text + "' AND IT_DESIGN = '" + tDesignNo.Text + "' ";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow2 = RsDetl.NewRow();
				int num2 = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num2)
				{
					if (((Operators.CompareString(tItCode.Text, "", false) != 0) & (Conversion.Val(MSG[DC_Main.i, 1]) + Conversion.Val(MSG[DC_Main.i, 2]) != 0.0) & (Operators.CompareString(MSG[DC_Main.i, 4], "", false) != 0)) | (Conversion.Val(MSG[DC_Main.i, 6]) + Conversion.Val(MSG[DC_Main.i, 9]) + Conversion.Val(MSG[DC_Main.i, 3]) + Conversion.Val(MSG[DC_Main.i, 10]) + Conversion.Val(MSG[DC_Main.i, 5]) != 0.0))
					{
						dataRow2["CO_CODE"] = DC_Main.MCo_code;
						dataRow2["IT_CODE"] = tItCode.Text;
						if (Operators.CompareString(tDesignNo.Text, "", false) == 0)
						{
							dataRow2["IT_DESIGN"] = "N";
						}
						else
						{
							dataRow2["IT_DESIGN"] = tDesignNo.Text;
						}
						dataRow2["SR_NO"] = DC_Main.i;
						dataRow2["FROM_WT"] = Conversion.Val(MSG[DC_Main.i, 1]);
						dataRow2["TO_WT"] = Conversion.Val(MSG[DC_Main.i, 2]);
						dataRow2["MIN_PCS"] = Conversion.Val(MSG[DC_Main.i, 3]);
						dataRow2["LBR_CODE"] = MSG[DC_Main.i, 4];
						dataRow2["GHT_PRC"] = Conversion.Val(MSG[DC_Main.i, 5]);
						dataRow2["LBR_PRC"] = Conversion.Val(MSG[DC_Main.i, 6]);
						dataRow2["MIN_LBR_PRC"] = Conversion.Val(MSG[DC_Main.i, 7]);
						dataRow2["LBR_TYPE"] = MSG[DC_Main.i, 8];
						dataRow2["LBR_RATE"] = Conversion.Val(MSG[DC_Main.i, 9]);
						dataRow2["LBR_AMT"] = Conversion.Val(MSG[DC_Main.i, 10]);
						RsDetl.Rows.Add(dataRow2);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
					DC_Main.i++;
				}
			}
			Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(tItCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Product For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Record now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			if (Operators.CompareString(CurMast, "Dm Size", false) == 0)
			{
				DC_Main.RsQry = "DELETE FROM DM_SIZE WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  IT_CODE = '" + tItCode.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			}
			else
			{
				DC_Main.RsQry = "DELETE FROM ITM_WT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  IT_CODE = '" + tItCode.Text + "' AND IT_DESIGN = '" + tDesignNo.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			}
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void MS_STK_LIMIT_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_STK_LIMIT_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "tBkName", false) != 0)
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
	}

	private void Text1_TextChanged(object sender, EventArgs e)
	{
		checked
		{
			if ((Operators.CompareString(Text1.Text, "", false) == 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
			{
				DGV_FILL();
			}
			else if ((Operators.CompareString(Text1.Text, "", false) != 0) & (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) != 0))
			{
				DGV_CLEAR();
				DataView dataView = new DataView(RsMast);
				dataView.RowFilter = "IT_NAME Like  '" + Text1.Text + "%' ";
				if (dataView.Count > 0)
				{
					((DataGridView)DGV).AutoGenerateColumns = false;
					((DataGridView)DGV).Columns[0].Width = (int)Math.Round(70.0 * ColCon);
					((DataGridView)DGV).Columns[0].DataPropertyName = "IT_CODE";
					((DataGridView)DGV).Columns[0].HeaderText = "Code";
					((DataGridView)DGV).Columns[1].Width = (int)Math.Round(300.0 * ColCon);
					((DataGridView)DGV).Columns[1].DataPropertyName = "IT_NAME";
					((DataGridView)DGV).Columns[1].HeaderText = "Name";
					((DataGridView)DGV).DataSource = dataView;
				}
			}
		}
	}

	private void MS_STK_LIMIT_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void Text1_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(Text1.Text, "SEARCH RECORD", false) == 0)
		{
			Text1.Text = "";
		}
	}

	private void DGV_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			((Control)Text1).Focus();
		}
		else if ((int)e.KeyCode == 13)
		{
			tItCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
			DISPLAY_DATA();
		}
		else if ((int)e.KeyCode == 8 && Strings.Len(Text1.Text) > 0)
		{
			Text1.Text = Strings.Mid(Text1.Text, 1, checked(Strings.Len(Text1.Text) - 1));
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		tItCode.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[0].Value);
		if (Operators.CompareString(DC_Main.MsStkLimitWithDesign, "Y", false) == 0)
		{
			tDesignNo.Text = Conversions.ToString(((DataGridView)DGV).CurrentRow.Cells[2].Value);
		}
		DISPLAY_DATA();
		((Control)tItCode).Focus();
	}

	private void MS_STK_LIMIT_Closed(object sender, EventArgs e)
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

	private void tDataType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void tItCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + tItCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT A.IT_NAME As ItNameL,A.IT_CODE As ItCodeL FROM ITEM_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.IT_TYPE,A.IT_CODE";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[3];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tItCode.Text = DC_Main.ColValue[1];
					tItName.Text = DC_Main.ColValue[0];
				}
				((Control)tItCode).Focus();
			}
		}
		else
		{
			tItName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
			if (Operators.CompareString(DC_Main.MsStkLimitWithDesign, "Y", false) == 0)
			{
				((Control)tDesignNo).Focus();
				return;
			}
			DISPLAY_DATA();
			MSG.Row = 1;
			MSG.Col = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void MS_STK_LIMIT_KeyUp(object sender, KeyEventArgs e)
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

	private void tDesignNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			DISPLAY_DATA();
			MSG.Row = 1;
			MSG.Col = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}
}
