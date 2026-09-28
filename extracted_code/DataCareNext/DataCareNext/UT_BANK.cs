using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
using AxMSFlexGridLib;
using Crystal;
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
public class UT_BANK : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private SimpleButton _BtnSave;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCancel")]
	private SimpleButton _BtnCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDelete")]
	private SimpleButton _BtnDelete;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG")]
	private AxMSFlexGrid _MSG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY")]
	private TextBox _TEXT_ENTRY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBalance")]
	private SimpleButton _btnBalance;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private double CustOpAmt;

	private double CustClAmt;

	private string PartyAcCode;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OldValTot;

	private double NewValTot;

	private DataTable RsData;

	private int FilRow;

	private DataTable DtIdtl;

	private DataRow dr;

	private bool Msgleft;

	private bool UpDown;

	private bool MsTxtDelete;

	private int MsgOldRow;

	private string FormBook;

	private string FormName;

	private string FormBookType;

	private string FormItmType;

	private string FormVchNo;

	private string FormMainBook;

	private string FormBookSname;

	private string FormBookInOut;

	private string MaxVchNo;

	private string LastVchNo;

	private const int cSrNo = 0;

	private const int cBookType = 1;

	private const int cLdAcName = 2;

	private const int cTranId = 3;

	private const int cVchNo = 4;

	private const int cVchDate = 5;

	private const int cChqNo = 6;

	private const int cClDate = 7;

	private const int cDrAmt = 8;

	private const int cCrAmt = 9;

	private const int cAmtBal = 10;

	private const int cCrDrType = 11;

	private const int cBookCode = 12;

	private const int cBookName = 13;

	private const int cLdAcCode = 14;

	private const int cBookYear = 15;

	private const int cBookKey = 16;

	private const int cBookSrNo = 17;

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

	internal virtual MaskedTextBox mFromDt
	{
		[CompilerGenerated]
		get
		{
			return _mFromDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = mVchDate_GotFocus;
			KeyEventHandler val = new KeyEventHandler(mFromDt_KeyDown);
			MaskedTextBox val2 = _mFromDt;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_mFromDt = value;
			val2 = _mFromDt;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblBDate")]
	private virtual Label _lblBDate;

	internal virtual Label lblBDate
	{
		get
		{
			return _lblBDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblBDate = value;
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
			EventHandler eventHandler5 = MSG_Scroll;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
				val.RowColChange -= eventHandler4;
				val.Scroll -= eventHandler5;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
				val.RowColChange += eventHandler4;
				val.Scroll += eventHandler5;
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_ENTRY_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_ENTRY_KeyDown);
			KeyEventHandler val2 = new KeyEventHandler(TEXT_ENTRY_KeyUp);
			TextBox val3 = _TEXT_ENTRY;
			if (val3 != null)
			{
				((Control)val3).TextChanged -= eventHandler;
				((Control)val3).KeyDown -= val;
				((Control)val3).KeyUp -= val2;
			}
			_TEXT_ENTRY = value;
			val3 = _TEXT_ENTRY;
			if (val3 != null)
			{
				((Control)val3).TextChanged += eventHandler;
				((Control)val3).KeyDown += val;
				((Control)val3).KeyUp += val2;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DlgOpen")]
	private virtual OpenFileDialog _DlgOpen;

	internal virtual OpenFileDialog DlgOpen
	{
		get
		{
			return _DlgOpen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DlgOpen = value;
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

	internal virtual TextBox tAcCode
	{
		[CompilerGenerated]
		get
		{
			return _tAcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAcCode_KeyDown);
			EventHandler eventHandler = tAcCode_GotFocus;
			EventHandler eventHandler2 = tAcCode_TextChanged;
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).TextChanged -= eventHandler2;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
				((Control)val2).TextChanged += eventHandler2;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcName")]
	private virtual TextBox _tAcName;

	internal virtual TextBox tAcName
	{
		get
		{
			return _tAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tAcName = value;
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

	internal virtual MaskedTextBox mToDt
	{
		[CompilerGenerated]
		get
		{
			return _mToDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mToDt_KeyDown);
			EventHandler eventHandler = mToDt_GotFocus;
			MaskedTextBox val2 = _mToDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_mToDt = value;
			val2 = _mToDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnBalance
	{
		[CompilerGenerated]
		get
		{
			return _btnBalance;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnBalance_Click;
			SimpleButton val = _btnBalance;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBalance = value;
			val = _btnBalance;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public UT_BANK()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += UT_BANK_Load;
		((Form)this).Deactivate += UT_BANK_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(UT_BANK_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(UT_BANK_KeyDown);
		((Form)this).Activated += UT_BANK_Activated;
		((Form)this).Closed += UT_BANK_Closed;
		((Control)this).KeyUp += new KeyEventHandler(UT_BANK_KeyUp);
		DtIdtl = new DataTable();
		dr = DtIdtl.NewRow();
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
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Expected O, but got Unknown
		//IL_0491: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Expected O, but got Unknown
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Expected O, but got Unknown
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Expected O, but got Unknown
		//IL_06d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e2: Expected O, but got Unknown
		//IL_07ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f7: Expected O, but got Unknown
		//IL_085a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0864: Expected O, but got Unknown
		//IL_09c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2b: Expected O, but got Unknown
		//IL_0a8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a98: Expected O, but got Unknown
		//IL_0b5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b65: Expected O, but got Unknown
		//IL_0c0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c16: Expected O, but got Unknown
		//IL_0c77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c81: Expected O, but got Unknown
		//IL_0d09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d13: Expected O, but got Unknown
		//IL_0d4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d54: Expected O, but got Unknown
		//IL_0e05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0f: Expected O, but got Unknown
		//IL_0e8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e96: Expected O, but got Unknown
		//IL_0f1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f25: Expected O, but got Unknown
		//IL_0fd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe0: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_BANK));
		lblBook = new Label();
		mFromDt = new MaskedTextBox();
		lblBDate = new Label();
		BtnPrint = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnExit = new SimpleButton();
		PnlBotam = new FlowLayoutPanel();
		btnBalance = new SimpleButton();
		TEXT_ENTRY = new TextBox();
		MSG_TOT = new AxMSFlexGrid();
		MSG = new AxMSFlexGrid();
		DlgOpen = new OpenFileDialog();
		Cr = new AxCrystalReport();
		Label1 = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label3 = new Label();
		mToDt = new MaskedTextBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((Control)this).SuspendLayout();
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
		lblBook.Text = "Bank Reconcile";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mFromDt).Location = new Point(73, 50);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 22);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(11, 52);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(61, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "From Dt";
		lblBDate.TextAlign = (ContentAlignment)16;
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
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)btnBalance);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 4;
		((BaseStyleControl)btnBalance).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnBalance).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnBalance).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnBalance).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnBalance.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnBalance.ImageOptions.SvgImage");
		((Control)btnBalance).Location = new Point(724, 3);
		((BaseControl)btnBalance).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnBalance).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnBalance).Name = "btnBalance";
		((Control)btnBalance).Size = new Size(97, 37);
		((Control)btnBalance).TabIndex = 28;
		btnBalance.Text = "&Bal Chk";
		((BaseButton)btnBalance).ToolTipAnchor = (ToolTipAnchor)1;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(526, 192);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 3;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)MSG_TOT).Location = new Point(18, 538);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1132, 17);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(13, 83);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1145, 453);
		((Control)MSG).TabIndex = 1135;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1181, 449);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(164, 51);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(44, 20);
		((Control)Label1).TabIndex = 1156;
		Label1.Text = "To Dt";
		Label1.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(390, 48);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 2;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(472, 48);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(282, 23);
		((Control)tAcName).TabIndex = 1167;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(308, 50);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(75, 20);
		((Control)Label3).TabIndex = 1168;
		Label3.Text = "Bank Code";
		Label3.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(214, 50);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG_TOT);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)lblBDate);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "UT_BANK";
		((Form)this).Text = "Bank Reconcile";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)Cr).EndInit();
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
		mSG[0] = 0;
		mSG[1] = 0;
		mSG.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG[0] = (int)Math.Round(700.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr";
			mSG[1] = (int)Math.Round(1300.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "BookType";
			mSG[2] = (int)Math.Round(3300.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "Ac Name";
			mSG[3] = (int)Math.Round(1700.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "Tran Id";
			mSG[4] = (int)Math.Round(1100.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "VchNo";
			mSG[5] = (int)Math.Round(1500.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "VchDate";
			mSG[6] = (int)Math.Round(1100.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "ChqNo";
			mSG[7] = (int)Math.Round(1400.0 * ColCon);
			mSG[7] = 0;
			mSG[0, 7] = "ClrDate";
			mSG[8] = (int)Math.Round(1300.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "DrAmt";
			mSG[9] = (int)Math.Round(1300.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "CrAmt";
			mSG[10] = (int)Math.Round(1300.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "AmtBal";
			mSG[11] = (int)Math.Round(700.0 * ColCon);
			mSG[11] = 3;
			mSG[0, 11] = "CrDr";
			mSG[12] = 0;
			mSG[13] = 0;
			mSG[14] = 0;
			mSG[15] = 0;
			mSG[16] = 0;
			mSG[17] = 0;
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			MsgLastCol = 7;
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			mSG.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd();
			mSG = null;
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		NewValTot = MSG.Row;
		mSG = null;
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
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
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
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 1:
				case 11:
				case 14:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
					break;
				case 4:
				case 5:
				case 6:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
					break;
				case 7:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 25;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
					break;
				case 2:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
					break;
				case 8:
				case 9:
				case 10:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
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
			case 1:
			case 3:
			case 4:
			case 5:
			case 6:
			case 11:
			case 14:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 8:
			case 9:
			case 10:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				break;
			case 7:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			}
			mSG = null;
		}
	}

	private void TEXT_ENTRY_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_ENTRY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected I4, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Invalid comparison between Unknown and I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Invalid comparison between Unknown and I4
		UpDown = false;
		Msgleft = false;
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode <= 13)
		{
			if ((int)keyCode != 8)
			{
				if ((int)keyCode == 13)
				{
					int col = mSG.Col;
					checked
					{
						if (col == 7)
						{
							if (Strings.Len(TEXT_ENTRY.Text) != 10)
							{
								((Control)TEXT_ENTRY).Focus();
							}
							else if (mSG.Row == mSG.Rows - 1)
							{
								mSG[mSG.Row, 7] = TEXT_ENTRY.Text;
								MsgClear = true;
								mSG.Rows += 1;
								mSG.Row += 1;
								MsgClear = false;
								mSG.Col = 7;
							}
							else
							{
								mSG.Row += 1;
								mSG.Col = 7;
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
				}
			}
			else
			{
				MsTxtDelete = true;
			}
		}
		else
		{
			checked
			{
				switch (unchecked(keyCode - 37))
				{
				case 0:
					if (mSG.Col > 1)
					{
						if (MsTxtDelete)
						{
							MsTxtDelete = false;
						}
						else
						{
							Msgleft = true;
							UpDown = true;
						}
						mSG.Col -= 1;
					}
					return;
				case 2:
					if (mSG.Col >= MsgLastCol)
					{
						((Control)TEXT_ENTRY).Focus();
					}
					else if (mSG.Col < mSG.Cols - 1)
					{
						if (MsTxtDelete)
						{
							MsTxtDelete = false;
						}
						else
						{
							UpDown = true;
						}
						mSG.Col += 1;
					}
					return;
				case 1:
					if (mSG.Row > 1)
					{
						if (MsTxtDelete)
						{
							MsTxtDelete = false;
						}
						else
						{
							UpDown = true;
						}
						MsgOldRow = 0;
						mSG.Row -= 1;
					}
					return;
				case 3:
					if (mSG.Row < mSG.Rows - 1)
					{
						if (MsTxtDelete)
						{
							MsTxtDelete = false;
						}
						else
						{
							UpDown = true;
						}
						MsgOldRow = 0;
						mSG.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode != 46)
			{
				if ((int)keyCode == 112)
				{
					TEXT_ENTRY.Text = Conversions.ToString(DC_Main.MsSysDate);
					mSG[mSG.Row, 7] = Conversions.ToString(DC_Main.MsSysDate);
				}
			}
			else
			{
				MsTxtDelete = true;
			}
		}
		mSG = null;
	}

	private void UT_BANK_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_09b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c4: Expected O, but got Unknown
		//IL_0a03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a12: Expected O, but got Unknown
		//IL_0a2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3b: Expected O, but got Unknown
		//IL_0a63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6a: Expected O, but got Unknown
		//IL_0afb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0a: Expected O, but got Unknown
		//IL_0b92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba1: Expected O, but got Unknown
		//IL_0c13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1e: Expected O, but got Unknown
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr.Connect = DC_Main.CrConnect;
		}
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
				Font font = ((Control)tAcCode).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_IDTL", false) != 0)))
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
				if (DC_Main.ScreenHight > 1.0)
				{
					MSG_TOT.ScrollBars = (ScrollBarsSettings)0;
				}
			}
			FormBook = DC_Main.CurBook;
			FormName = DC_Main.CurBookName;
			FormBookType = DC_Main.CurBookType;
			FormItmType = DC_Main.CurBookItm;
			FormMainBook = DC_Main.CurBookMain;
			FormBookSname = DC_Main.CurBookSname;
			FormBookInOut = DC_Main.CurBookInOut;
			DC_Main.MCo_Book = FormBook;
			if (Operators.CompareString(FormItmType, "", false) == 0)
			{
				FormItmType = "A";
			}
			if (Operators.CompareString(DC_Main.CurBookVch, "", false) != 0)
			{
				FormVchNo = DC_Main.CurBookVch;
			}
			DC_Main.CurBook = "";
			DC_Main.CurBookName = "";
			DC_Main.CurBookType = "";
			DC_Main.CurBookItm = "";
			DC_Main.CurBookMain = "";
			DC_Main.CurBookSname = "";
			DC_Main.CurBookInOut = "";
			BtnCancel_Click(BtnCancel, new EventArgs());
			CurActCtrl = (Control)(object)mFromDt;
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
			else if (val is MaskedTextBox)
			{
				val.Text = DC_Main.MMask;
			}
		}
		MainUser = DC_Main.MCo_User;
		if ((DateAndTime.Month(DateAndTime.Today) > 3) & (DateAndTime.Month(DateAndTime.Today) <= 12))
		{
			mFromDt.Text = "01/" + Strings.Format((object)DateAndTime.Month(DateAndTime.Today), "00") + "/" + Strings.Mid(DC_Main.MCo_year, 1, 4);
			mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		}
		else
		{
			mFromDt.Text = "01/" + Strings.Format((object)DateAndTime.Month(DateAndTime.Today), "00") + "/" + Strings.Mid(DC_Main.MCo_year, 6, 4);
			mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		}
		OldValTot = 1.0;
		NewValTot = 1.0;
		((Control)TEXT_ENTRY).Visible = false;
		MSG_CLEAR();
		EntryMode = "A";
		((Control)BtnSave).Enabled = true;
		((Control)mFromDt).Focus();
	}

	private void DISPLAY_DATA()
	{
		MSG_CLEAR();
		((Control)mFromDt).Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void UT_BANK_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void UT_BANK_KeyPress(object sender, KeyPressEventArgs e)
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

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
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
						((Control)BtnSave).Enabled = false;
						if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
						{
							Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						ProjectData.ClearProjectError();
						num2 = 2;
						AxMSFlexGrid mSG = MSG;
						int num3 = mSG.Rows - 1;
						DC_Main.i = 1;
						while (DC_Main.i <= num3)
						{
							if (Operators.CompareString(mSG[DC_Main.i, 4], "", false) != 0)
							{
								if (Operators.CompareString(mSG[DC_Main.i, 7], "", false) == 0)
								{
									DC_Main.RsQry = "UPDATE AC_DATA SET CLR_DATE = null WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' and LEDR_KEY = '" + mSG[DC_Main.i, 16] + "'";
									DC_Main.ExeQuteDc(DC_Main.RsQry);
									DC_Main.RsQry = "UPDATE CASH_DATA SET CLR_DATE = VCH_DATE WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' and CO_YEAR = '" + mSG[DC_Main.i, 15] + "' and CO_BOOK = '" + mSG[DC_Main.i, 12] + "' and VCH_NO = '" + mSG[DC_Main.i, 4] + "' and AC_CODE = '" + mSG[DC_Main.i, 14] + "'";
									DC_Main.ExeQuteDc(DC_Main.RsQry);
								}
								else
								{
									DC_Main.RsQry = "UPDATE AC_DATA SET CLR_DATE = '" + Strings.Format((object)Conversions.ToDate(mSG[DC_Main.i, 7]), "MM/dd/yyyy") + "' WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' and LEDR_KEY ='" + mSG[DC_Main.i, 16] + "'";
									DC_Main.ExeQuteDc(DC_Main.RsQry);
									DC_Main.RsQry = "UPDATE CASH_DATA SET CLR_DATE = '" + Strings.Format((object)Conversions.ToDate(mSG[DC_Main.i, 7]), "MM/dd/yyyy") + "' WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' and CO_YEAR = '" + mSG[DC_Main.i, 15] + "' and CO_BOOK = '" + mSG[DC_Main.i, 12] + "' and VCH_NO = '" + mSG[DC_Main.i, 4] + "' and AC_CODE = '" + mSG[DC_Main.i, 14] + "'";
									DC_Main.ExeQuteDc(DC_Main.RsQry);
								}
							}
							DC_Main.i++;
						}
						mSG = null;
						Interaction.MsgBox((object)"Data Are Updated...", (MsgBoxStyle)0, (object)null);
						btnBalance_Click(btnBalance, new EventArgs());
						goto end_IL_0001;
					}
					case 939:
						num = -1;
						switch (num2)
						{
						case 2:
							((Control)BtnSave).Enabled = true;
							EntryMode = "E";
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
				try0001_dispatch = 939;
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
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Invalid comparison between Unknown and I4
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mFromDt.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void UT_BANK_KeyDown(object sender, KeyEventArgs e)
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
				((Control)BtnSave).Focus();
			}
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr[(short)5] = "";
		Cr[(short)6] = "";
		Cr[(short)7] = "";
		DC_Main.RsQry = "SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' HAVING SUM(CR_AMT-DR_AMT) <> 0 ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		double num = default(double);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num = Conversions.ToDouble(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BalAmt"], (object)""));
		}
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\BankAdj.RPT";
		Cr.SelectionFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.LC_CODE} = '" + DC_Main.MLc_code + "'  AND {AC_DATA.CO_YEAR}= '" + DC_Main.MCo_year + "'  AND {AC_DATA.AC_CODE} = '" + tAcCode.Text + "' AND  Not(IsNull({AC_DATA.CLR_DATE})) AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		Cr[(short)0] = "RptTitel = '" + Strings.UCase(tAcName.Text) + " Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)mFromDt.Text, "dd") + ") ";
		Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + ", " + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + ", " + Strings.Format((object)mToDt.Text, "dd") + ") ";
		Cr[(short)3] = ("AcOpAmt = " + Strings.Format((object)num, "0.00")) ?? "";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		DC_Main.MsPrintStatus = false;
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CustOpAmt = 0.0;
		CustClAmt = 0.0;
		CLEAR_DATA();
	}

	private void UT_BANK_Activated(object sender, EventArgs e)
	{
		DC_Main.MCo_Book = FormBook;
		DC_Main.MCo_BookType = FormBookType;
		lblBook.Text = FormName;
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void MSG_RowColChange(object sender, EventArgs e)
	{
		if (MSG.Row != 0 && ((MsgOldRow != MSG.Row) & !MsgClear))
		{
			MsgOldRow = MSG.Row;
		}
	}

	private void mVchDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mFromDt).SelectionStart = 0;
		((TextBoxBase)mFromDt).SelectionLength = Strings.Len(mFromDt.Text);
	}

	private void mFromDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mFromDt;
			DC_Main.SetDate(ref MsDate);
			mFromDt = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void mToDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mToDt;
			DC_Main.SetDate(ref MsDate);
			mToDt = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void MSG_Scroll(object sender, EventArgs e)
	{
		if (MSG_TOT.LeftCol != MSG.LeftCol)
		{
			MSG_TOT.LeftCol = MSG.LeftCol;
			MSG_TOT.ScrollTrack = MSG.LeftCol != 0;
		}
	}

	private void UT_BANK_Closed(object sender, EventArgs e)
	{
		FormVchNo = "";
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
		}
	}

	private void tVchDesc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void TEXT_ENTRY_KeyUp(object sender, KeyEventArgs e)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		if (MSG.Col == 7 && (int)e.KeyCode != 8)
		{
			if (Strings.Len(TEXT_ENTRY.Text) == 2)
			{
				TEXT_ENTRY.Text += "/";
			}
			else if (Strings.Len(TEXT_ENTRY.Text) == 5)
			{
				TEXT_ENTRY.Text += "/";
			}
			((TextBoxBase)TEXT_ENTRY).SelectionStart = Strings.Len(TEXT_ENTRY.Text);
		}
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "' AND AC_GR IN ('02','22','23')";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
			}
			else
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY A.AC_NAME";
			}
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[8];
			DC_Main.ColWidth[0] = 270.0;
			DC_Main.ColWidth[1] = 80.0;
			DC_Main.ColWidth[2] = 170.0;
			DC_Main.ColWidth[3] = 180.0;
			DC_Main.ColWidth[4] = 220.0;
			DC_Main.ColWidth[5] = 160.0;
			DC_Main.ColWidth[6] = 110.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tAcCode.Text = DC_Main.ColValue[1];
					tAcName.Text = DC_Main.ColValue[0];
				}
				((Control)tAcCode).Focus();
			}
		}
		else
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			DGV_DETL_FILL();
			MSG.Row = 2;
			MSG.Col = 7;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void DGV_DETL_FILL()
	{
		MSG_CLEAR();
		DC_Main.RsQry = "SELECT CO_BOOK,VCH_NO,AC_NAME FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
		DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(table);
		DC_Main.RsQry = "SELECT CO_BOOK,VCH_NO,AC_NAME FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
		DataTable table2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView2 = new DataView(table2);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt  FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.AC_CODE = '" + tAcCode.Text + "' and A.VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.BOOK_NAME,A.CO_BOOK,A.CO_YEAR,A.VCH_NO,A.VCH_DATE,A.CLR_DATE,A.CHQ_NO,A.LEDR_KEY,A.LD_CODE As AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,B.MAIN_BOOK,C.AC_AREA,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt  FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.LD_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.AC_CODE = '" + tAcCode.Text + "' and A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""), (object)" GROUP BY B.BOOK_NAME,A.CO_BOOK,A.CO_YEAR,A.VCH_NO,A.VCH_DATE,A.CLR_DATE,A.CHQ_NO,A.LEDR_KEY,A.LD_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,B.MAIN_BOOK,C.AC_AREA ORDER BY A.VCH_DATE,B.BOOK_NAME,A.VCH_NO"));
		DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		int num7 = 0;
		checked
		{
			MSG.Rows += 1;
			if (dataTable.Rows.Count > 0)
			{
				AxMSFlexGrid mSG = MSG;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) != 0.0)
				{
					mSG[num7 + 1, 0] = Conversions.ToString(num7 + 1);
					mSG[num7 + 1, 1] = "";
					mSG[num7 + 1, 2] = "Op Balance";
					mSG[num7 + 1, 8] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["DrAmt"], (object)"")), "0.00");
					mSG[num7 + 1, 9] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["CrAmt"], (object)"")), "0.00");
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable.Rows[0]["DrAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable.Rows[0]["CrAmt"]));
					mSG[num7 + 1, 10] = Strings.Format((object)Conversion.Val((object)Math.Abs(num2 - num)), "0.00");
					if (num2 - num > 0.0)
					{
						mSG[num7 + 1, 11] = "Cr";
					}
					else if (num2 - num < 0.0)
					{
						mSG[num7 + 1, 11] = "Dr";
					}
					else
					{
						mSG[num7 + 1, 11] = "Dr";
					}
				}
				else
				{
					MSG[num7 + 1, 0] = Conversions.ToString(num7 + 1);
					MSG[num7 + 1, 1] = "";
					MSG[num7 + 1, 2] = "Op Balance";
				}
				mSG = null;
			}
			else
			{
				MSG[num7 + 1, 0] = Conversions.ToString(num7 + 1);
				MSG[num7 + 1, 1] = "";
				MSG[num7 + 1, 2] = "Op Balance";
			}
			num7++;
			if (dataTable2.Rows.Count <= 0)
			{
				return;
			}
			MSG.Rows += 1;
			int num8 = dataTable2.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num8)
			{
				AxMSFlexGrid mSG2 = MSG;
				mSG2[num7 + 1, 0] = Conversions.ToString(num7 + 1);
				mSG2[num7 + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["BOOK_NAME"], (object)""));
				if (Operators.ConditionalCompareObjectEqual(dataTable2.Rows[DC_Main.M]["MAIN_BOOK"], (object)"MEMB ENTRY", false))
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.SCHM_CODE,A.MEMB_CODE,B.MEMB_NAME FROM AD_DATA AS A LEFT JOIN AD_MEMB AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.SCHM_CODE = B.SCHM_CODE AND A.MEMB_CODE = B.MEMB_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.SR_NO = "), (object)Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["LEDR_KEY"], (object)"")), Strings.Len(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["LEDR_KEY"])) - 1, Strings.Len(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["LEDR_KEY"])))), (object)" "));
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						mSG2[num7 + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SCHM_CODE"], (object)""), (object)" - "), DC_Main.Tbl.Rows[0]["MEMB_CODE"]), (object)""), (object)" - "), DC_Main.Tbl.Rows[0]["MEMB_NAME"]), (object)""));
					}
					else
					{
						mSG2[num7 + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["AC_NAME"], (object)""));
					}
				}
				else
				{
					mSG2[num7 + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["AC_NAME"], (object)""));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.UPI_ID FROM UPI_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					mSG2[num7 + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["UPI_ID"], (object)""));
				}
				mSG2[num7 + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.M]["VCH_NO"], (object)""));
				mSG2[num7 + 1, 5] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy") ?? "";
				mSG2[num7 + 1, 6] = Conversions.ToString(dataTable2.Rows[DC_Main.M]["CHQ_NO"]);
				if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CLR_DATE"])))
				{
					mSG2[num7 + 1, 7] = "";
				}
				else
				{
					mSG2[num7 + 1, 7] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CLR_DATE"]), "dd/MM/yyyy") ?? "";
				}
				mSG2[num7 + 1, 8] = Conversions.ToString(dataTable2.Rows[DC_Main.M]["DrAmt"]);
				mSG2[num7 + 1, 9] = Conversions.ToString(dataTable2.Rows[DC_Main.M]["CrAmt"]);
				mSG2[num7 + 1, 12] = Conversions.ToString(dataTable2.Rows[DC_Main.M]["CO_BOOK"]);
				mSG2[num7 + 1, 13] = Conversions.ToString(dataTable2.Rows[DC_Main.M]["MAIN_BOOK"]);
				mSG2[num7 + 1, 14] = Conversions.ToString(dataTable2.Rows[DC_Main.M]["AC_CODE"]);
				mSG2[num7 + 1, 15] = Conversions.ToString(dataTable2.Rows[DC_Main.M]["CO_YEAR"]);
				mSG2[num7 + 1, 16] = Conversions.ToString(dataTable2.Rows[DC_Main.M]["LEDR_KEY"]);
				mSG2[num7 + 1, 17] = "0";
				num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable2.Rows[DC_Main.M]["DrAmt"]));
				num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable2.Rows[DC_Main.M]["CrAmt"]));
				mSG2[num7 + 1, 10] = Strings.Format((object)Math.Abs(num2 - num), "0.00");
				if (num2 - num > 0.0)
				{
					mSG2[num7 + 1, 11] = "Cr";
				}
				else if (num2 - num < 0.0)
				{
					mSG2[num7 + 1, 11] = "Dr";
				}
				else
				{
					mSG2[num7 + 1, 11] = "";
				}
				num7++;
				mSG2.Rows += 1;
				mSG2 = null;
				DC_Main.M++;
			}
			num7 = MSG.Rows - 1;
			MSG[num7, 2] = "Total :";
			MSG[num7, 8] = Strings.Format((object)num, "0.00");
			MSG[num7, 9] = Strings.Format((object)num2, "0.00");
			MSG[num7, 10] = Strings.Format((object)Math.Abs(num2 - num), "0.00");
			if (num2 - num > 0.0)
			{
				MSG[num7, 11] = "Cr";
			}
			else if (num2 - num < 0.0)
			{
				MSG[num7, 11] = "Dr";
			}
			else
			{
				MSG[num7, 11] = "Dr";
			}
		}
	}

	private void mToDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToDt).SelectionStart = 0;
		((TextBoxBase)mToDt).SelectionLength = Strings.Len(mToDt.Text);
	}

	private void tAcCode_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)tAcCode).SelectionStart = 0;
		((TextBoxBase)tAcCode).SelectionLength = Strings.Len(tAcCode.Text);
	}

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void btnBalance_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.RsQry = "SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' HAVING SUM(CR_AMT-DR_AMT) <> 0 ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		double num = default(double);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num = Conversions.ToDouble(DC_Main.Rshlp.Rows[0]["BalAmt"]);
		}
		AxMSFlexGrid mSG = MSG;
		checked
		{
			int num2 = mSG.Rows - 1;
			DC_Main.i = 2;
			while (DC_Main.i <= num2)
			{
				if (Operators.CompareString(mSG[DC_Main.i, 7], "", false) != 0)
				{
					if ((DateTime.Compare(Conversions.ToDate(mSG[DC_Main.i, 7]), Conversions.ToDate(mFromDt.Text)) >= 0) & (DateTime.Compare(Conversions.ToDate(mSG[DC_Main.i, 7]), Conversions.ToDate(mToDt.Text)) <= 0))
					{
						num += Conversion.Val(mSG[DC_Main.i, 9]) - Conversion.Val(mSG[DC_Main.i, 8]);
						mSG[DC_Main.i, 10] = Strings.Format((object)Math.Abs(num), "0.00");
						mSG[DC_Main.i, 11] = Conversions.ToString(Interaction.IIf(Conversion.Val((object)num) > 0.0, (object)"Cr", (object)"Dr"));
					}
					else
					{
						mSG[DC_Main.i, 10] = "";
						mSG[DC_Main.i, 11] = "";
					}
				}
				else
				{
					mSG[DC_Main.i, 10] = "";
					mSG[DC_Main.i, 11] = "";
				}
				DC_Main.i++;
			}
			mSG = null;
		}
	}

	private void UT_BANK_KeyUp(object sender, KeyEventArgs e)
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
