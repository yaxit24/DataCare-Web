using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
using AxMSFlexGridLib;
using Crystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_ROJMEL : Form
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
	[AccessedThroughProperty("tLcCode")]
	private TextBox _tLcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnGstr1")]
	private SimpleButton _BtnGstr1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnGold")]
	private QButton _BtnGold;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnAmt")]
	private QButton _BtnAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG")]
	private AxMSFlexGrid _MSG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSilver")]
	private QButton _BtnSilver;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnLast")]
	private SimpleButton _BtnLast;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnFirst")]
	private SimpleButton _BtnFirst;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnGrPrint")]
	private SimpleButton _BtnGrPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnCash")]
	private SimpleButton _btnCash;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY")]
	private TextBox _TEXT_ENTRY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnDailyWork")]
	private QButton _btnDailyWork;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnExel")]
	private SimpleButton _btnExel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nClBal")]
	private TextBox _nClBal;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBalSave")]
	private SimpleButton _btnBalSave;

	private Control CurActCtrl;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string CurRpt;

	private string RptType;

	private string CurFormula;

	private const int cSrNoCr = 0;

	private const int cBookCr = 1;

	private const int cVchNoCr = 2;

	private const int cLdAcNameCr = 3;

	private const int cCrAmt = 4;

	private const int CSrNoDr = 5;

	private const int cBookDr = 6;

	private const int cVchNoDr = 7;

	private const int cLdAcNameDr = 8;

	private const int cDrAmt = 9;

	private const int cBookCodeCr = 10;

	private const int cBookNameCr = 11;

	private const int cBookCodeDr = 12;

	private const int cBookNameDr = 13;

	private const int cVchDate = 14;

	private const int cMSrNo = 0;

	private const int cMBkName = 1;

	private const int cMVchNo = 2;

	private const int cMAcName = 3;

	private const int cMDiscAmt = 4;

	private const int cMTotAmt = 5;

	private const int cMCashRec = 6;

	private const int cMBankRec = 7;

	private const int cMCardRec = 8;

	private const int cMUpiRec = 9;

	private const int cMOldGo = 10;

	private const int cMOldSl = 11;

	private const int cMOglWt = 12;

	private const int cMOslWt = 13;

	private const int cMSchmAmt = 14;

	private const int cMOrdAmt = 15;

	private const int cMKasar = 16;

	private const int cMOsAmt = 17;

	private const int cMOrdAdv = 18;

	private const int cMGlGrWt = 19;

	private const int cMGlNwt = 20;

	private const int cMGlFine = 21;

	private const int cMSLGrWt = 22;

	private const int cMSLNwt = 23;

	private const int cMSLFine = 24;

	private const int cMCoBook = 25;

	private const int cMMainBook = 26;

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

	internal virtual TextBox tLcCode
	{
		[CompilerGenerated]
		get
		{
			return _tLcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tLcCode_KeyDown);
			TextBox val2 = _tLcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tLcCode = value;
			val2 = _tLcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLcName")]
	private virtual TextBox _tLcName;

	internal virtual TextBox tLcName
	{
		get
		{
			return _tLcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tLcName = value;
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

	internal virtual SimpleButton BtnGstr1
	{
		[CompilerGenerated]
		get
		{
			return _BtnGstr1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnGstr1_Click;
			SimpleButton val = _BtnGstr1;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnGstr1 = value;
			val = _BtnGstr1;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnGold
	{
		[CompilerGenerated]
		get
		{
			return _BtnGold;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnGold_Click;
			QButton val = _BtnGold;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnGold = value;
			val = _BtnGold;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnAmt
	{
		[CompilerGenerated]
		get
		{
			return _BtnAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAmt_Click;
			QButton val = _BtnAmt;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnAmt = value;
			val = _BtnAmt;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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
			EventHandler eventHandler = MSG_DblClick;
			EventHandler eventHandler2 = MSG_Enter;
			EventHandler eventHandler3 = MSG_EnterCell;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.DblClick -= eventHandler;
				((Control)val).Enter -= eventHandler2;
				val.EnterCell -= eventHandler3;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.DblClick += eventHandler;
				((Control)val).Enter += eventHandler2;
				val.EnterCell += eventHandler3;
			}
		}
	}

	internal virtual QButton BtnSilver
	{
		[CompilerGenerated]
		get
		{
			return _BtnSilver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSilver_Click;
			QButton val = _BtnSilver;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSilver = value;
			val = _BtnSilver;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FlowLayoutPanel1")]
	private virtual FlowLayoutPanel _FlowLayoutPanel1;

	internal virtual FlowLayoutPanel FlowLayoutPanel1
	{
		get
		{
			return _FlowLayoutPanel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_FlowLayoutPanel1 = value;
		}
	}

	internal virtual SimpleButton BtnLast
	{
		[CompilerGenerated]
		get
		{
			return _BtnLast;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnLast_Click;
			SimpleButton val = _BtnLast;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnLast = value;
			val = _BtnLast;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnFirst
	{
		[CompilerGenerated]
		get
		{
			return _BtnFirst;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnFirst_Click;
			SimpleButton val = _BtnFirst;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnFirst = value;
			val = _BtnFirst;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnGrPrint
	{
		[CompilerGenerated]
		get
		{
			return _BtnGrPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnGrPrint_Click;
			SimpleButton val = _BtnGrPrint;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnGrPrint = value;
			val = _BtnGrPrint;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnCash
	{
		[CompilerGenerated]
		get
		{
			return _btnCash;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnCash_Click;
			SimpleButton val = _btnCash;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnCash = value;
			val = _btnCash;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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
			EventHandler eventHandler = TEXT_ENTRY_DoubleClick;
			TextBox val = _TEXT_ENTRY;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_TEXT_ENTRY = value;
			val = _TEXT_ENTRY;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual QButton btnDailyWork
	{
		[CompilerGenerated]
		get
		{
			return _btnDailyWork;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDailyWork_Click;
			QButton val = _btnDailyWork;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnDailyWork = value;
			val = _btnDailyWork;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			EventHandler eventHandler = DGV_DoubleClick;
			DataGridViewX val2 = _DGV;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV = value;
			val2 = _DGV;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting += val;
				((Control)val2).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnExel
	{
		[CompilerGenerated]
		get
		{
			return _btnExel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SimpleButton1_Click;
			SimpleButton val = _btnExel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnExel = value;
			val = _btnExel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual TextBox nClBal
	{
		[CompilerGenerated]
		get
		{
			return _nClBal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nClBal_KeyDown);
			TextBox val2 = _nClBal;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nClBal = value;
			val2 = _nClBal;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual SimpleButton btnBalSave
	{
		[CompilerGenerated]
		get
		{
			return _btnBalSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnBalSave_Click;
			SimpleButton val = _btnBalSave;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBalSave = value;
			val = _btnBalSave;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public RP_ROJMEL()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += RP_ROJMEL_Load;
		((Form)this).Closed += RP_ROJMEL_Closed;
		((Form)this).Activated += RP_ROJMEL_Activated;
		((Control)this).KeyDown += new KeyEventHandler(RP_ROJMEL_KeyDown);
		RptType = "Amt";
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
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Expected O, but got Unknown
		//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Expected O, but got Unknown
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e3: Expected O, but got Unknown
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Expected O, but got Unknown
		//IL_075b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0765: Expected O, but got Unknown
		//IL_080e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0818: Expected O, but got Unknown
		//IL_087b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0885: Expected O, but got Unknown
		//IL_092f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0939: Expected O, but got Unknown
		//IL_099c: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a6: Expected O, but got Unknown
		//IL_0a50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5a: Expected O, but got Unknown
		//IL_0abd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac7: Expected O, but got Unknown
		//IL_0b70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7a: Expected O, but got Unknown
		//IL_0bdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be7: Expected O, but got Unknown
		//IL_0c90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9a: Expected O, but got Unknown
		//IL_0cfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d07: Expected O, but got Unknown
		//IL_0e1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e99: Expected O, but got Unknown
		//IL_0f6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f78: Expected O, but got Unknown
		//IL_1011: Unknown result type (might be due to invalid IL or missing references)
		//IL_101b: Expected O, but got Unknown
		//IL_10bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1144: Unknown result type (might be due to invalid IL or missing references)
		//IL_114e: Expected O, but got Unknown
		//IL_116d: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f4: Expected O, but got Unknown
		//IL_1230: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b3: Expected O, but got Unknown
		//IL_13ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b6: Expected O, but got Unknown
		//IL_14e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_14eb: Expected O, but got Unknown
		//IL_1559: Unknown result type (might be due to invalid IL or missing references)
		//IL_1563: Expected O, but got Unknown
		//IL_1615: Unknown result type (might be due to invalid IL or missing references)
		//IL_161f: Expected O, but got Unknown
		//IL_169c: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a6: Expected O, but got Unknown
		//IL_172a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1734: Expected O, but got Unknown
		//IL_19d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a67: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a71: Expected O, but got Unknown
		//IL_1a94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d63: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d96: Expected O, but got Unknown
		//IL_1db9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e39: Expected O, but got Unknown
		//IL_1ecd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed7: Expected O, but got Unknown
		//IL_1f98: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa2: Expected O, but got Unknown
		//IL_21dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2200: Unknown result type (might be due to invalid IL or missing references)
		//IL_2224: Unknown result type (might be due to invalid IL or missing references)
		//IL_2248: Unknown result type (might be due to invalid IL or missing references)
		//IL_2271: Unknown result type (might be due to invalid IL or missing references)
		//IL_227b: Expected O, but got Unknown
		//IL_229e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2321: Unknown result type (might be due to invalid IL or missing references)
		//IL_232b: Expected O, but got Unknown
		//IL_25ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_25d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_25f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2619: Unknown result type (might be due to invalid IL or missing references)
		//IL_2642: Unknown result type (might be due to invalid IL or missing references)
		//IL_264c: Expected O, but got Unknown
		//IL_266f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2713: Unknown result type (might be due to invalid IL or missing references)
		//IL_271d: Expected O, but got Unknown
		//IL_27b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_27bc: Expected O, but got Unknown
		//IL_283a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2844: Expected O, but got Unknown
		//IL_2926: Unknown result type (might be due to invalid IL or missing references)
		//IL_2930: Expected O, but got Unknown
		//IL_2999: Unknown result type (might be due to invalid IL or missing references)
		//IL_29a3: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_ROJMEL));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnGrPrint = new SimpleButton();
		btnCash = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnGstr1 = new SimpleButton();
		btnExel = new SimpleButton();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		btnBalSave = new SimpleButton();
		nClBal = new TextBox();
		Label1 = new Label();
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tLcCode = new TextBox();
		tLcName = new TextBox();
		Label6 = new Label();
		BtnGold = new QButton();
		BtnAmt = new QButton();
		mToDt = new MaskedTextBox();
		Label4 = new Label();
		MSG = new AxMSFlexGrid();
		BtnSilver = new QButton();
		TEXT_ENTRY = new TextBox();
		btnDailyWork = new QButton();
		DGV = new DataGridViewX();
		((Control)PnlBotam).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnGrPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)btnCash);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnGstr1);
		((Control)PnlBotam).Controls.Add((Control)(object)btnExel);
		((Control)PnlBotam).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnLast);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnFirst);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 5;
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
		((Control)BtnExit).TabIndex = 6;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)BtnCancel).Location = new Point(1118, 3);
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((Control)BtnCancel).Size = new Size(91, 37);
		((Control)BtnCancel).TabIndex = 4;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = Resources.actions_trash;
		((Control)BtnDelete).Location = new Point(1021, 3);
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((Control)BtnDelete).Size = new Size(91, 37);
		((Control)BtnDelete).TabIndex = 5;
		BtnDelete.Text = "&JmaUdr";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
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
		BtnSave.Text = "Bk Prn";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnGrPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnGrPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnGrPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnGrPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnGrPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnGrPrint.ImageOptions.SvgImage");
		((Control)BtnGrPrint).Location = new Point(827, 3);
		((BaseControl)BtnGrPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnGrPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnGrPrint).Name = "BtnGrPrint";
		((Control)BtnGrPrint).Size = new Size(91, 37);
		((Control)BtnGrPrint).TabIndex = 31;
		BtnGrPrint.Text = "Gr Prn";
		((BaseButton)BtnGrPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnCash).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnCash).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnCash).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnCash).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnCash.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnCash.ImageOptions.SvgImage");
		((Control)btnCash).Location = new Point(730, 3);
		((BaseControl)btnCash).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnCash).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnCash).Name = "btnCash";
		((Control)btnCash).Size = new Size(91, 37);
		((Control)btnCash).TabIndex = 32;
		btnCash.Text = "Cash";
		((BaseButton)btnCash).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		((Control)BtnPrint).Location = new Point(633, 3);
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((Control)BtnPrint).Size = new Size(91, 37);
		((Control)BtnPrint).TabIndex = 1;
		BtnPrint.Text = "Cr Dr";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnGstr1).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnGstr1).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnGstr1).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnGstr1).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnGstr1.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnGstr1.ImageOptions.SvgImage");
		((Control)BtnGstr1).Location = new Point(536, 3);
		((BaseControl)BtnGstr1).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnGstr1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnGstr1).Name = "BtnGstr1";
		((Control)BtnGstr1).Size = new Size(91, 37);
		((Control)BtnGstr1).TabIndex = 2;
		BtnGstr1.Text = "Item";
		((BaseButton)BtnGstr1).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnExel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnExel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnExel).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnExel).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnExel.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnExel.ImageOptions.SvgImage");
		((Control)btnExel).Location = new Point(439, 3);
		((BaseControl)btnExel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnExel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnExel).Name = "btnExel";
		((Control)btnExel).Size = new Size(91, 37);
		((Control)btnExel).TabIndex = 33;
		btnExel.Text = "Excel";
		((BaseButton)btnExel).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)btnBalSave);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)nClBal);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)Label1);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(249, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Padding = new Padding(0, 4, 0, 0);
		((Control)FlowLayoutPanel1).Size = new Size(184, 36);
		((Control)FlowLayoutPanel1).TabIndex = 30;
		((BaseStyleControl)btnBalSave).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnBalSave).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnBalSave).Appearance.Font = new Font("Arial", 9f);
		((BaseStyleControl)btnBalSave).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnBalSave).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnBalSave).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnBalSave).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnBalSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnBalSave).Appearance.Options.UseForeColor = true;
		((BaseButton)btnBalSave).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnBalSave).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnBalSave).AppearanceHovered.Font = new Font("Arial", 9f);
		((BaseButton)btnBalSave).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnBalSave).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnBalSave).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnBalSave).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnBalSave).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnBalSave).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnBalSave).AppearancePressed.Font = new Font("Arial", 9f);
		((BaseButton)btnBalSave).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnBalSave).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnBalSave).AppearancePressed.Options.UseFont = true;
		((Control)btnBalSave).Location = new Point(150, 5);
		((BaseControl)btnBalSave).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnBalSave).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnBalSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnBalSave).Margin = new Padding(3, 1, 4, 3);
		((Control)btnBalSave).Name = "btnBalSave";
		((Control)btnBalSave).Size = new Size(30, 25);
		((Control)btnBalSave).TabIndex = 1182;
		btnBalSave.Text = "S";
		((BaseControl)btnBalSave).ToolTip = "Closing Balance Save";
		((TextBoxBase)nClBal).BackColor = Color.White;
		((Control)nClBal).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nClBal).Location = new Point(58, 6);
		((Control)nClBal).Margin = new Padding(3, 2, 3, 3);
		((TextBoxBase)nClBal).MaxLength = 12;
		((Control)nClBal).Name = "nClBal";
		((Control)nClBal).Size = new Size(86, 23);
		((Control)nClBal).TabIndex = 3;
		nClBal.TextAlign = (HorizontalAlignment)1;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(6, 8);
		((Control)Label1).Margin = new Padding(3, 4, 3, 0);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(46, 20);
		((Control)Label1).TabIndex = 1181;
		Label1.Text = "Cl Bal";
		Label1.TextAlign = (ContentAlignment)64;
		((BaseStyleControl)BtnLast).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnLast).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnLast).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnLast).Appearance.Options.UseForeColor = true;
		((Control)BtnLast).Location = new Point(202, 3);
		((BaseControl)BtnLast).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnLast).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnLast).Name = "BtnLast";
		((Control)BtnLast).Size = new Size(41, 37);
		((Control)BtnLast).TabIndex = 28;
		BtnLast.Text = ">";
		((BaseButton)BtnLast).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnFirst).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnFirst).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnFirst).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnFirst).Appearance.Options.UseForeColor = true;
		((Control)BtnFirst).Location = new Point(155, 3);
		((BaseControl)BtnFirst).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnFirst).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnFirst).Name = "BtnFirst";
		((Control)BtnFirst).Size = new Size(41, 37);
		((Control)BtnFirst).TabIndex = 29;
		BtnFirst.Text = "<";
		((BaseButton)BtnFirst).ToolTipAnchor = (ToolTipAnchor)1;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1239, 204);
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
		lblBook.Text = "Rojmel Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcCode).Location = new Point(218, 42);
		((TextBoxBase)tLcCode).MaxLength = 8;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(56, 23);
		((Control)tLcCode).TabIndex = 5;
		((TextBoxBase)tLcName).BackColor = Color.White;
		((Control)tLcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcName).Location = new Point(280, 42);
		((TextBoxBase)tLcName).MaxLength = 8;
		((Control)tLcName).Name = "tLcName";
		((Control)tLcName).Size = new Size(178, 23);
		((Control)tLcName).TabIndex = 1177;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(152, 42);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(60, 20);
		((Control)Label6).TabIndex = 1176;
		Label6.Text = "Lc Code";
		Label6.TextAlign = (ContentAlignment)64;
		((QControl)BtnGold).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnGold).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGold).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnGold).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnGold).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnGold).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGold).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnGold).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnGold).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnGold).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnGold).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnGold).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnGold).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnGold).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnGold.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGold.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGold.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGold.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGold.Image = null;
		((QControl)BtnGold).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnGold).Location = new Point(844, 42);
		((Control)BtnGold).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnGold).Name = "BtnGold";
		((Control)BtnGold).Size = new Size(143, 37);
		((Control)BtnGold).TabIndex = 2;
		BtnGold.Text = "Gold Fine";
		((QControl)BtnAmt).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnAmt).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnAmt).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnAmt).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnAmt).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnAmt).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnAmt).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnAmt).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnAmt).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnAmt).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnAmt).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnAmt).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnAmt).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnAmt).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnAmt.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAmt.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAmt.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAmt.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAmt.Image = null;
		((QControl)BtnAmt).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnAmt).Location = new Point(685, 42);
		((Control)BtnAmt).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnAmt).Name = "BtnAmt";
		((Control)BtnAmt).Size = new Size(143, 37);
		((Control)BtnAmt).TabIndex = 1;
		BtnAmt.Text = "Amount";
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(64, 40);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 0;
		mToDt.ValidatingType = typeof(DateTime);
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(12, 42);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(46, 20);
		((Control)Label4).TabIndex = 1180;
		Label4.Text = "Date";
		Label4.TextAlign = (ContentAlignment)64;
		((Control)MSG).Location = new Point(11, 74);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1160, 481);
		((Control)MSG).TabIndex = 4;
		((QControl)BtnSilver).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnSilver).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSilver).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnSilver).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnSilver).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnSilver).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSilver).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnSilver).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnSilver).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnSilver).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnSilver).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSilver).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnSilver).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnSilver).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnSilver.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSilver.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSilver.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSilver.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSilver.Image = null;
		((QControl)BtnSilver).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnSilver).Location = new Point(1003, 42);
		((Control)BtnSilver).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnSilver).Name = "BtnSilver";
		((Control)BtnSilver).Size = new Size(143, 37);
		((Control)BtnSilver).TabIndex = 3;
		BtnSilver.Text = "Silver Fine";
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.Moccasin;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(527, 250);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 1181;
		((Control)TEXT_ENTRY).Visible = false;
		((QControl)btnDailyWork).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnDailyWork).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnDailyWork).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnDailyWork).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnDailyWork).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnDailyWork).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnDailyWork).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnDailyWork).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnDailyWork).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnDailyWork).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnDailyWork).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnDailyWork).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnDailyWork).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnDailyWork).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnDailyWork.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDailyWork.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDailyWork.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDailyWork.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnDailyWork.Image = null;
		((QControl)btnDailyWork).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnDailyWork).Location = new Point(527, 42);
		((Control)btnDailyWork).Margin = new Padding(3, 6, 3, 6);
		((Control)btnDailyWork).Name = "btnDailyWork";
		((Control)btnDailyWork).Size = new Size(143, 37);
		((Control)btnDailyWork).TabIndex = 1182;
		btnDailyWork.Text = "Day Work";
		((Control)btnDailyWork).Visible = false;
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.Snow;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
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
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Location = new Point(11, 74);
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
		((Control)DGV).Size = new Size(1160, 481);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 1183;
		((Control)DGV).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)BtnSilver);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)BtnAmt);
		((Control)this).Controls.Add((Control)(object)BtnGold);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)tLcName);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)btnDailyWork);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_ROJMEL";
		((Form)this).Text = "Rojmel Report";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((Control)FlowLayoutPanel1).PerformLayout();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void BtnDailyWork_Click(object sender, EventArgs e)
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_111b: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
		((DataGridView)DGV).MultiSelect = false;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV).AutoGenerateColumns = false;
		((DataGridView)DGV).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV).Columns[0].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "Book");
			((DataGridView)DGV).Columns[1].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV).Columns[1].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "VchNo");
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV).Columns[2].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "AcName");
			((DataGridView)DGV).Columns[3].Width = (int)Math.Round(160.0 * ColCon);
			((DataGridView)DGV).Columns[3].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "DisAmt");
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "TotAmt");
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "CashRec");
			((DataGridView)DGV).Columns[6].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "BankRec");
			((DataGridView)DGV).Columns[7].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "CardRec");
			((DataGridView)DGV).Columns[8].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "UpiRec");
			((DataGridView)DGV).Columns[9].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "OldGlAmt");
			((DataGridView)DGV).Columns[10].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "OldSlAmt");
			((DataGridView)DGV).Columns[11].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "OGlWt");
			((DataGridView)DGV).Columns[12].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "OSlWt");
			((DataGridView)DGV).Columns[13].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "SchmAdj");
			((DataGridView)DGV).Columns[14].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[14].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "OrdAdj");
			((DataGridView)DGV).Columns[15].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[15].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "KsrAmt");
			((DataGridView)DGV).Columns[16].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[16].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "OsAmt");
			((DataGridView)DGV).Columns[17].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "OrdAdv");
			((DataGridView)DGV).Columns[18].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[18].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "GLGWt");
			((DataGridView)DGV).Columns[19].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[19].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "GLNwt");
			((DataGridView)DGV).Columns[20].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[20].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "GLFine");
			((DataGridView)DGV).Columns[21].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[21].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "SLGWt");
			((DataGridView)DGV).Columns[22].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[22].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[22].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "SLNwt");
			((DataGridView)DGV).Columns[23].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[23].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[23].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "SLFine");
			((DataGridView)DGV).Columns[24].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[24].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[24].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "CoBook");
			((DataGridView)DGV).Columns[25].Visible = false;
			((DataGridView)DGV).Columns.Add("", "MainBook");
			((DataGridView)DGV).Columns[26].Visible = false;
			((Control)TEXT_ENTRY).Visible = false;
			((Control)MSG).Visible = false;
			((Control)DGV).Visible = true;
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_BOOK,A.VCH_NO,B.BOOK_SNAME,B.MAIN_BOOK,B.DATA_TYPE FROM AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'  AND B.MAIN_BOOK IN ('MEMB ENTRY','SALES','SALES ORDER','MEMB ENTRY','CASH REC','BANK REC','KARIGAR ISSUE','VP PARCEL','BILL REC','CUSTREP RECEIPT','CUSTREP ISSUE','CARD ADJUST') And A.VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.CO_BOOK,A.VCH_NO,B.BOOK_SNAME,B.MAIN_BOOK,B.DATA_TYPE "), (object)" UNION ALL SELECT D.CO_BOOK,D.VCH_NO,E.BOOK_SNAME,E.MAIN_BOOK,E.DATA_TYPE FROM RATE_CUT_DATA AS D LEFT JOIN BOOK_DATA AS E ON D.CO_CODE = E.CO_CODE AND D.LC_CODE = E.LC_CODE AND D.CO_BOOK = E.CO_BOOK WHERE D.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND D.LC_CODE = '"), (object)tLcCode.Text), (object)"' AND D.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), (object)" AND E.MAIN_BOOK IN ('WH SALES','RATE CUT','BUL WH SALE','TOUR SALES') AND SL_NET_AMT+SL_FINE <> 0 And D.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND E.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY D.CO_BOOK,D.VCH_NO,E.BOOK_SNAME,E.MAIN_BOOK,E.DATA_TYPE "), (object)" UNION ALL SELECT F.CO_BOOK,F.VCH_NO,G.BOOK_SNAME,G.MAIN_BOOK,G.DATA_TYPE FROM SL_DATA AS F LEFT JOIN BOOK_DATA AS G ON F.CO_CODE = G.CO_CODE AND F.LC_CODE = G.LC_CODE AND F.CO_BOOK = G.CO_BOOK WHERE F.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND F.LC_CODE = '"), (object)tLcCode.Text), (object)"' AND F.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), (object)" AND G.MAIN_BOOK = 'SALES RETURNE' AND F.NET_AMT <> 0 And F.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND G.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY F.CO_BOOK,F.VCH_NO,G.BOOK_SNAME,G.MAIN_BOOK,G.DATA_TYPE ORDER BY B.MAIN_BOOK,A.CO_BOOK,A.VCH_NO "));
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count == 0)
			{
				Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
				((Control)mToDt).Focus();
				((TextBoxBase)mToDt).SelectionStart = 0;
				((TextBoxBase)mToDt).SelectionLength = Strings.Len(mToDt.Text);
				return;
			}
			DC_Main.RsQry = "Select * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
			DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView = new DataView(table);
			DC_Main.RsQry = "SELECT A.CO_BOOK,A.VCH_NO,B.IT_TYPE,SUM(ITM_GWT) As Gwt,SUM(ITM_NWT) As Nwt,SUM(ITM_FINE) As Fine FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND A.ITM_SIGN = '-' AND B.IT_TYPE IN ('G','S') GROUP BY A.CO_BOOK,A.VCH_NO,B.IT_TYPE";
			DataTable table2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView2 = new DataView(table2);
			DC_Main.RsQry = "SELECT  A.CO_BOOK,A.VCH_NO,SUM(UPI_AMT) As UpiAmt FROM UPI_DATA AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND A.UPI_AMT <> 0 GROUP BY A.CO_BOOK,A.VCH_NO HAVING SUM(UPI_AMT) > 0  ";
			DataTable table3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView3 = new DataView(table3);
			DC_Main.RsQry = "SELECT * FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
			DataTable table4 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView4 = new DataView(table4);
			DC_Main.RsQry = "SELECT * FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' ";
			DataTable table5 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView5 = new DataView(table5);
			DC_Main.R = 0;
			double num6;
			double num7;
			double num2 = default(double);
			double num3 = default(double);
			double num4 = default(double);
			double num8;
			double num9;
			double num10;
			double num11;
			double num12;
			double num13;
			double num14;
			double num15;
			double num16;
			double num17;
			double num18;
			double num19;
			double num20;
			double num21;
			double num22;
			double num23;
			if (dataTable.Rows.Count > 0)
			{
				int num = dataTable.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					DataGridViewX dGV = DGV;
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["BOOK_SNAME"]);
					((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["VCH_NO"]);
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
					if (dataView.Count > 0)
					{
						((DataGridView)dGV)[3, DC_Main.R].Value = Operators.ConcatenateObject(dataView[0]["AC_NAME"], (object)"");
						((DataGridView)dGV)[4, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView[0]["DISC_AMT"], (object)""));
						((DataGridView)dGV)[5, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView[0]["TOT_AMT"], (object)""));
						((DataGridView)dGV)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView[0]["CASH_AMT"], (object)""));
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView[0]["CHQ_NO"], (object)""), (object)"U", false))
						{
							((DataGridView)dGV)[9, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView[0]["CHQ_AMT"], (object)""));
						}
						else
						{
							((DataGridView)dGV)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView[0]["CHQ_AMT"], (object)""));
						}
						((DataGridView)dGV)[8, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView[0]["CARD_AMT"], (object)""));
						((DataGridView)dGV)[10, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView[0]["OLD_GL_AMT"], (object)""));
						((DataGridView)dGV)[11, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView[0]["OLD_SL_AMT"], (object)""));
						((DataGridView)dGV)[12, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView[0]["OLD_GL"], (object)""));
						((DataGridView)dGV)[13, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView[0]["OLD_SL"], (object)""));
						((DataGridView)dGV)[14, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView[0]["SCHM_AMT"], (object)""));
						((DataGridView)dGV)[15, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView[0]["ADV_AMT"], (object)""));
						((DataGridView)dGV)[16, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView[0]["KASAR_AMT"], (object)""));
						((DataGridView)dGV)[17, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView[0]["BILL_OS"], (object)""));
						((DataGridView)dGV)[18, DC_Main.R].Value = 0;
						dataView3.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' "));
						if (dataView3.Count > 0)
						{
							DataGridViewCell val;
							(val = ((DataGridView)dGV)[9, DC_Main.R]).Value = Operators.AddObject(val.Value, dataView3[0]["UpiAmt"]);
						}
						dataView2.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND IT_TYPE = 'G'"));
						if (dataView2.Count > 0)
						{
							((DataGridView)dGV)[19, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Gwt"], (object)""));
							((DataGridView)dGV)[20, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Nwt"], (object)""));
						}
						dataView2.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND IT_TYPE = 'S'"));
						if (dataView2.Count > 0)
						{
							((DataGridView)dGV)[22, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Gwt"], (object)""));
							((DataGridView)dGV)[23, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Nwt"], (object)""));
						}
					}
					dataView4.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' "));
					if (dataView4.Count > 0)
					{
						((DataGridView)dGV)[3, DC_Main.R].Value = Operators.ConcatenateObject(dataView4[0]["AC_NAME"], (object)"");
						((DataGridView)dGV)[4, DC_Main.R].Value = 0;
						((DataGridView)dGV)[5, DC_Main.R].Value = 0;
						((DataGridView)dGV)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView4[0]["CASH_AMT"], (object)""));
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView4[0]["CHQ_NO"], (object)""), (object)"U", false))
						{
							((DataGridView)dGV)[9, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView4[0]["CHQ_AMT"], (object)""));
						}
						else
						{
							((DataGridView)dGV)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView4[0]["CHQ_AMT"], (object)""));
						}
						((DataGridView)dGV)[8, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView4[0]["CARD_AMT"], (object)""));
						((DataGridView)dGV)[10, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView4[0]["OLD_GL_AMT"], (object)""));
						((DataGridView)dGV)[11, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView4[0]["OLD_SL_AMT"], (object)""));
						((DataGridView)dGV)[12, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView4[0]["OLD_GL"], (object)""));
						((DataGridView)dGV)[13, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView4[0]["OLD_SL"], (object)""));
						dataView3.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' "));
						if (dataView3.Count > 0)
						{
							DataGridViewCell val;
							(val = ((DataGridView)dGV)[9, DC_Main.R]).Value = Operators.AddObject(val.Value, dataView3[0]["UpiAmt"]);
						}
						((DataGridView)dGV)[14, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView4[0]["SCHM_AMT"], (object)""));
						((DataGridView)dGV)[15, DC_Main.R].Value = 0;
						((DataGridView)dGV)[16, DC_Main.R].Value = 0;
						((DataGridView)dGV)[17, DC_Main.R].Value = 0;
						((DataGridView)dGV)[18, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView4[0]["ADV_AMT"], (object)""));
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.BOOK_NAME,A.AC_CODE,B.AC_NAME,A.REC_AMT As PayAmt,A.REC_AC_CODE FROM CASH_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.CLR_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.BOOK_NAME IN ('CASH REC','BANK REC','BILL REC') AND A.REC_AMT <> 0 ORDER BY A.SR_NO"));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.X = 0;
					while (DC_Main.X < table.Rows.Count)
					{
						if (DC_Main.X >= 1)
						{
							((DataGridView)dGV)[25, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["CO_BOOK"]);
							((DataGridView)dGV)[26, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["MAIN_BOOK"]);
							num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV)[6, DC_Main.R].Value));
							num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV)[7, DC_Main.R].Value));
							((DataGridView)dGV).Rows.Add();
							DC_Main.R++;
							((DataGridView)dGV)[0, DC_Main.R].Value = DC_Main.R + 1;
							((DataGridView)dGV)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["BOOK_SNAME"]);
							((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["VCH_NO"]);
						}
						((DataGridView)dGV)[3, DC_Main.R].Value = Operators.ConcatenateObject(table.Rows[DC_Main.X]["AC_NAME"], (object)"");
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(table.Rows[DC_Main.X]["BOOK_NAME"], (object)""), (object)"CASH REC", false))
						{
							((DataGridView)dGV)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[DC_Main.X]["PayAmt"], (object)""));
						}
						else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(table.Rows[DC_Main.X]["BOOK_NAME"], (object)""), (object)"BILL REC", false))
						{
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(table.Rows[DC_Main.X]["REC_AC_CODE"], (object)""), (object)"00001", false))
							{
								((DataGridView)dGV)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[DC_Main.X]["PayAmt"], (object)""));
							}
							else
							{
								((DataGridView)dGV)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[DC_Main.X]["PayAmt"], (object)""));
							}
						}
						else
						{
							((DataGridView)dGV)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[DC_Main.X]["PayAmt"], (object)""));
						}
						DC_Main.X++;
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.BOOK_NAME,A.AC_CODE,B.AC_NAME,A.CARD_REC_AMT As PayAmt,A.AC_CODE FROM CARD_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.CARD_REC_AMT <> 0 AND A.BILL_NO = '' "));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.X = 0;
					while (DC_Main.X < table.Rows.Count)
					{
						if (DC_Main.X >= 1)
						{
							((DataGridView)dGV)[25, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["CO_BOOK"]);
							((DataGridView)dGV)[26, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["MAIN_BOOK"]);
							num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV)[8, DC_Main.R].Value));
							((DataGridView)dGV).Rows.Add();
							DC_Main.R++;
							((DataGridView)dGV)[0, DC_Main.R].Value = DC_Main.R + 1;
							((DataGridView)dGV)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["BOOK_SNAME"]);
							((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["VCH_NO"]);
						}
						((DataGridView)dGV)[3, DC_Main.R].Value = Operators.ConcatenateObject(table.Rows[DC_Main.X]["AC_NAME"], (object)"");
						((DataGridView)dGV)[8, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[DC_Main.X]["PayAmt"], (object)""));
						DC_Main.X++;
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.BOOK_NAME,A.MEMB_CODE,B.MEMB_NAME,A.MEMB_AMT,A.REC_AC,A.SCHM_CODE As PayAmt,A.CHQ_NO,C.AC_GR,A.WITH_UPI,A.CO_BOOK,A.CO_YEAR,A.VCH_NO,A.SR_NO FROM (AD_DATA AS A LEFT JOIN AD_MEMB AS B ON A.CO_CODE = B.CO_CODE AND A.SCHM_CODE = B.SCHM_CODE AND A.MEMB_CODE = B.MEMB_CODE)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.REC_AC = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' ORDER BY A.SR_NO"));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.X = 0;
					while (DC_Main.X < table.Rows.Count)
					{
						((DataGridView)dGV)[3, DC_Main.R].Value = Operators.ConcatenateObject(table.Rows[DC_Main.X]["MEMB_NAME"], (object)"");
						if (Operators.ConditionalCompareObjectEqual(table.Rows[DC_Main.X]["WITH_UPI"], (object)"Y", false))
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT UPI_AC_CODE,UPI_AMT As UpiAmt FROM UPI_DATA AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), table.Rows[DC_Main.X]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), table.Rows[DC_Main.X]["VCH_NO"]), (object)"' AND A.SR_NO = "), table.Rows[DC_Main.X]["SR_NO"]), (object)" "));
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							int num5 = DC_Main.Tbl.Rows.Count - 1;
							DC_Main.i = 0;
							while (DC_Main.i <= num5)
							{
								if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[DC_Main.i]["UPI_AC_CODE"], (object)"00001", false))
								{
									((DataGridView)dGV)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["UpiAmt"], (object)""));
								}
								else
								{
									DataGridViewCell val;
									(val = ((DataGridView)dGV)[9, DC_Main.R]).Value = Operators.AddObject(val.Value, (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["UpiAmt"], (object)"")));
								}
								DC_Main.i++;
							}
						}
						else
						{
							if (DC_Main.X >= 1)
							{
								((DataGridView)dGV)[25, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["CO_BOOK"]);
								((DataGridView)dGV)[26, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["MAIN_BOOK"]);
								num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV)[6, DC_Main.R].Value));
								num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV)[7, DC_Main.R].Value));
								((DataGridView)dGV).Rows.Add();
								DC_Main.R++;
								((DataGridView)dGV)[0, DC_Main.R].Value = DC_Main.R + 1;
								((DataGridView)dGV)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["BOOK_SNAME"]);
								((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["VCH_NO"]);
							}
							((DataGridView)dGV)[3, DC_Main.R].Value = Operators.ConcatenateObject(table.Rows[DC_Main.X]["MEMB_NAME"], (object)"");
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(table.Rows[DC_Main.X]["REC_AC"], (object)""), (object)"00001", false))
							{
								((DataGridView)dGV)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[DC_Main.X]["MEMB_AMT"], (object)""));
							}
							else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(table.Rows[DC_Main.X]["AC_GR"], (object)""), (object)"19", false))
							{
								((DataGridView)dGV)[8, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[DC_Main.X]["MEMB_AMT"], (object)""));
							}
							else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(table.Rows[DC_Main.X]["CHQ_NO"], (object)""), (object)"U", false))
							{
								((DataGridView)dGV)[9, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["MEMB_AMT"], (object)""));
							}
							else
							{
								((DataGridView)dGV)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[DC_Main.X]["MEMB_AMT"], (object)""));
							}
						}
						DC_Main.X++;
					}
					dataView5.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
					if (dataView5.Count > 0)
					{
						((DataGridView)dGV)[3, DC_Main.R].Value = Operators.ConcatenateObject(dataView5[0]["AC_NAME"], (object)"");
						((DataGridView)dGV)[4, DC_Main.R].Value = 0;
						((DataGridView)dGV)[5, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView5[0]["SL_TOT_AMT"], (object)""));
						((DataGridView)dGV)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView5[0]["SL_CASH_AMT"], (object)""));
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView5[0]["CHQ_NO"], (object)""), (object)"U", false))
						{
							((DataGridView)dGV)[9, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView5[0]["SL_CHQ_AMT"], (object)""));
						}
						else
						{
							((DataGridView)dGV)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView5[0]["SL_CHQ_AMT"], (object)""));
						}
						((DataGridView)dGV)[8, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView5[0]["SL_CARD_AMT"], (object)""));
						((DataGridView)dGV)[15, DC_Main.R].Value = 0;
						((DataGridView)dGV)[16, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView5[0]["SL_KASAR_AMT"], (object)""));
						((DataGridView)dGV)[17, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView5[0]["SL_BILL_OS"], (object)""));
						dataView2.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND IT_TYPE = 'G'"));
						if (dataView2.Count > 0)
						{
							((DataGridView)dGV)[19, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Gwt"], (object)""));
							((DataGridView)dGV)[20, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Nwt"], (object)""));
							((DataGridView)dGV)[21, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Fine"], (object)""));
						}
						dataView2.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND IT_TYPE = 'S'"));
						if (dataView2.Count > 0)
						{
							((DataGridView)dGV)[22, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Gwt"], (object)""));
							((DataGridView)dGV)[23, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Nwt"], (object)""));
							((DataGridView)dGV)[24, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Fine"], (object)""));
						}
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT AC_NAME FROM KR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (table.Rows.Count > 0)
					{
						((DataGridView)dGV)[3, DC_Main.R].Value = Operators.ConcatenateObject(table.Rows[0]["AC_NAME"], (object)"");
						dataView2.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND IT_TYPE = 'G'"));
						if (dataView2.Count > 0)
						{
							((DataGridView)dGV)[19, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Gwt"], (object)""));
							((DataGridView)dGV)[20, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Nwt"], (object)""));
							((DataGridView)dGV)[21, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Fine"], (object)""));
						}
						dataView2.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND IT_TYPE = 'S'"));
						if (dataView2.Count > 0)
						{
							((DataGridView)dGV)[22, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Gwt"], (object)""));
							((DataGridView)dGV)[23, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Nwt"], (object)""));
							((DataGridView)dGV)[24, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Fine"], (object)""));
						}
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.BOOK_NAME,A.AC_CODE,B.AC_NAME,SUM(A.CR_AMT) As RecAmt,A.LD_CODE FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.BOOK_NAME IN ('CUSTREP RECEIPT') AND A.CR_AMT <> 0 GROUP BY A.BOOK_NAME,A.AC_CODE,B.AC_NAME,A.LD_CODE"));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.X = 0;
					while (DC_Main.X < table.Rows.Count)
					{
						if (DC_Main.X >= 1)
						{
							((DataGridView)dGV)[25, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["CO_BOOK"]);
							((DataGridView)dGV)[26, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["MAIN_BOOK"]);
							num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV)[6, DC_Main.R].Value));
							num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV)[7, DC_Main.R].Value));
							((DataGridView)dGV).Rows.Add();
							DC_Main.R++;
							((DataGridView)dGV)[0, DC_Main.R].Value = DC_Main.R + 1;
							((DataGridView)dGV)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["BOOK_SNAME"]);
							((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["VCH_NO"]);
						}
						((DataGridView)dGV)[3, DC_Main.R].Value = Operators.ConcatenateObject(table.Rows[DC_Main.X]["AC_NAME"], (object)"");
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(table.Rows[0]["LD_CODE"], (object)""), (object)"00001", false))
						{
							((DataGridView)dGV)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[DC_Main.X]["RecAmt"], (object)""));
						}
						else
						{
							((DataGridView)dGV)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[DC_Main.X]["RecAmt"], (object)""));
						}
						DC_Main.X++;
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (table.Rows.Count > 0)
					{
						((DataGridView)dGV)[3, DC_Main.R].Value = Operators.ConcatenateObject(table.Rows[0]["AC_NAME"], (object)"");
						((DataGridView)dGV)[4, DC_Main.R].Value = 0;
						((DataGridView)dGV)[5, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["NET_AMT"], (object)""));
						((DataGridView)dGV)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CASH_AMT"], (object)""));
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(table.Rows[0]["CHQ_NO"], (object)""), (object)"U", false))
						{
							((DataGridView)dGV)[9, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CHQ_AMT"], (object)""));
						}
						else
						{
							((DataGridView)dGV)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CHQ_AMT"], (object)""));
						}
						((DataGridView)dGV)[8, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CARD_AMT"], (object)""));
						((DataGridView)dGV)[17, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["BILL_OS"], (object)""));
						dataView2.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND IT_TYPE = 'G'"));
						if (dataView2.Count > 0)
						{
							((DataGridView)dGV)[19, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Gwt"], (object)""));
							((DataGridView)dGV)[20, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Nwt"], (object)""));
							((DataGridView)dGV)[21, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Fine"], (object)""));
						}
						dataView2.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"CO_BOOK = '", dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND IT_TYPE = 'S'"));
						if (dataView2.Count > 0)
						{
							((DataGridView)dGV)[22, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Gwt"], (object)""));
							((DataGridView)dGV)[23, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Nwt"], (object)""));
							((DataGridView)dGV)[24, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(dataView2[0]["Fine"], (object)""));
						}
					}
					((DataGridView)dGV)[25, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["CO_BOOK"]);
					((DataGridView)dGV)[26, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["MAIN_BOOK"]);
					DC_Main.R++;
					dGV = null;
					DC_Main.M++;
				}
				num6 = 0.0;
				num7 = 0.0;
				num2 = 0.0;
				num3 = 0.0;
				num4 = 0.0;
				num8 = 0.0;
				num9 = 0.0;
				num10 = 0.0;
				num11 = 0.0;
				num12 = 0.0;
				num13 = 0.0;
				num14 = 0.0;
				num15 = 0.0;
				num16 = 0.0;
				num17 = 0.0;
				num18 = 0.0;
				num19 = 0.0;
				num20 = 0.0;
				num21 = 0.0;
				num22 = 0.0;
				num23 = 0.0;
				int num24 = ((DataGridView)DGV).Rows.Count - 1;
				for (int i = 0; i <= num24; i++)
				{
					DataGridViewX dGV2 = DGV;
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV2)[4, i].Value));
					num7 = Conversions.ToDouble(Operators.AddObject((object)num7, ((DataGridView)dGV2)[5, i].Value));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV2)[6, i].Value));
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV2)[7, i].Value));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV2)[8, i].Value));
					num8 = Conversions.ToDouble(Operators.AddObject((object)num8, ((DataGridView)dGV2)[9, i].Value));
					num9 = Conversions.ToDouble(Operators.AddObject((object)num9, ((DataGridView)dGV2)[10, i].Value));
					num10 = Conversions.ToDouble(Operators.AddObject((object)num10, ((DataGridView)dGV2)[11, i].Value));
					num11 = Conversions.ToDouble(Operators.AddObject((object)num11, ((DataGridView)dGV2)[12, i].Value));
					num12 = Conversions.ToDouble(Operators.AddObject((object)num12, ((DataGridView)dGV2)[13, i].Value));
					num13 = Conversions.ToDouble(Operators.AddObject((object)num13, ((DataGridView)dGV2)[14, i].Value));
					num14 = Conversions.ToDouble(Operators.AddObject((object)num14, ((DataGridView)dGV2)[15, i].Value));
					num15 = Conversions.ToDouble(Operators.AddObject((object)num15, ((DataGridView)dGV2)[16, i].Value));
					num16 = Conversions.ToDouble(Operators.AddObject((object)num16, ((DataGridView)dGV2)[17, i].Value));
					num17 = Conversions.ToDouble(Operators.AddObject((object)num17, ((DataGridView)dGV2)[18, i].Value));
					num18 = Conversions.ToDouble(Operators.AddObject((object)num18, ((DataGridView)dGV2)[19, i].Value));
					num19 = Conversions.ToDouble(Operators.AddObject((object)num19, ((DataGridView)dGV2)[20, i].Value));
					num20 = Conversions.ToDouble(Operators.AddObject((object)num20, ((DataGridView)dGV2)[21, i].Value));
					num21 = Conversions.ToDouble(Operators.AddObject((object)num21, ((DataGridView)dGV2)[22, i].Value));
					num22 = Conversions.ToDouble(Operators.AddObject((object)num22, ((DataGridView)dGV2)[23, i].Value));
					num23 = Conversions.ToDouble(Operators.AddObject((object)num23, ((DataGridView)dGV2)[24, i].Value));
					dGV2 = null;
				}
				((DataGridView)DGV).Rows.Add();
				((DataGridView)DGV).Rows.Add();
				DC_Main.R++;
				DataGridViewX dGV3 = DGV;
				((DataGridView)dGV3)[3, DC_Main.R].Value = "Total :";
				((DataGridView)dGV3)[4, DC_Main.R].Value = num6;
				((DataGridView)dGV3)[5, DC_Main.R].Value = num7;
				((DataGridView)dGV3)[6, DC_Main.R].Value = num2;
				((DataGridView)dGV3)[7, DC_Main.R].Value = num3;
				((DataGridView)dGV3)[8, DC_Main.R].Value = num4;
				((DataGridView)dGV3)[9, DC_Main.R].Value = num8;
				((DataGridView)dGV3)[10, DC_Main.R].Value = num9;
				((DataGridView)dGV3)[11, DC_Main.R].Value = num10;
				((DataGridView)dGV3)[12, DC_Main.R].Value = num11;
				((DataGridView)dGV3)[13, DC_Main.R].Value = num12;
				((DataGridView)dGV3)[14, DC_Main.R].Value = num13;
				((DataGridView)dGV3)[15, DC_Main.R].Value = num14;
				((DataGridView)dGV3)[16, DC_Main.R].Value = num15;
				((DataGridView)dGV3)[17, DC_Main.R].Value = num16;
				((DataGridView)dGV3)[18, DC_Main.R].Value = num17;
				((DataGridView)dGV3)[19, DC_Main.R].Value = num18;
				((DataGridView)dGV3)[20, DC_Main.R].Value = num19;
				((DataGridView)dGV3)[21, DC_Main.R].Value = num20;
				((DataGridView)dGV3)[22, DC_Main.R].Value = num21;
				((DataGridView)dGV3)[23, DC_Main.R].Value = num22;
				((DataGridView)dGV3)[24, DC_Main.R].Value = num23;
				dGV3 = null;
			}
			((DataGridView)DGV).Rows[DC_Main.R].DefaultCellStyle.ForeColor = Color.Blue;
			((DataGridView)DGV).Rows.Add();
			((DataGridView)DGV).Rows.Add();
			DC_Main.R += 2;
			num6 = 0.0;
			num7 = 0.0;
			num2 = 0.0;
			num3 = 0.0;
			num4 = 0.0;
			num8 = 0.0;
			num9 = 0.0;
			num10 = 0.0;
			num11 = 0.0;
			num12 = 0.0;
			num13 = 0.0;
			num14 = 0.0;
			num15 = 0.0;
			num16 = 0.0;
			num17 = 0.0;
			num18 = 0.0;
			num19 = 0.0;
			num20 = 0.0;
			num21 = 0.0;
			num22 = 0.0;
			num23 = 0.0;
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_BOOK,A.VCH_NO,B.BOOK_SNAME,B.MAIN_BOOK FROM AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'  AND B.MAIN_BOOK IN ('PURCHASE','CASH PAY','BANK PAY','KARIGAR RECEIPT','SALES RETURNE','MEMB ADJUST','ORDER CANCEL','KRREP RECEIPT') And A.VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.CO_BOOK,A.VCH_NO,B.BOOK_SNAME,B.MAIN_BOOK "), (object)" UNION ALL SELECT D.CO_BOOK,D.VCH_NO,E.BOOK_SNAME,E.MAIN_BOOK FROM RATE_CUT_DATA AS D LEFT JOIN BOOK_DATA AS E ON D.CO_CODE = E.CO_CODE AND D.LC_CODE = E.LC_CODE AND D.CO_BOOK = E.CO_BOOK WHERE D.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND D.LC_CODE = '"), (object)tLcCode.Text), (object)"' AND D.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' "), (object)" AND E.MAIN_BOOK IN ('WH SALES','RATE CUT','BUL WH SALE','TOUR SALES') AND PR_NET_AMT+PR_FINE <> 0 And D.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND E.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY D.CO_BOOK,D.VCH_NO,E.BOOK_SNAME,E.MAIN_BOOK ORDER BY B.MAIN_BOOK,A.CO_BOOK,A.VCH_NO "));
			dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count <= 0)
			{
				return;
			}
			int num25 = dataTable.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num25)
			{
				DataGridViewX dGV4 = DGV;
				((DataGridView)dGV4).Rows.Add();
				((DataGridView)dGV4)[0, DC_Main.R].Value = DC_Main.R + 1;
				((DataGridView)dGV4)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["BOOK_SNAME"]);
				((DataGridView)dGV4)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["VCH_NO"]);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (table.Rows.Count > 0)
				{
					((DataGridView)dGV4)[3, DC_Main.R].Value = Operators.ConcatenateObject(table.Rows[0]["AC_NAME"], (object)"");
					((DataGridView)dGV4)[4, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["DISC_AMT"], (object)""));
					((DataGridView)dGV4)[5, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["TOT_AMT"], (object)""));
					((DataGridView)dGV4)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CASH_AMT"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(table.Rows[0]["CHQ_NO"], (object)""), (object)"U", false))
					{
						((DataGridView)dGV4)[9, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CHQ_AMT"], (object)""));
					}
					else
					{
						((DataGridView)dGV4)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CHQ_AMT"], (object)""));
					}
					((DataGridView)dGV4)[8, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CARD_AMT"], (object)""));
					((DataGridView)dGV4)[17, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["BILL_OS"], (object)""));
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(ITM_GWT) As Gwt,SUM(ITM_NWT) As Nwt,SUM(ITM_FINE) As Fine FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '+' AND B.IT_TYPE = 'G'"));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (table.Rows.Count > 0)
					{
						((DataGridView)dGV4)[19, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Gwt"], (object)""));
						((DataGridView)dGV4)[20, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Nwt"], (object)""));
						((DataGridView)dGV4)[21, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Fine"], (object)""));
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(ITM_GWT) As Gwt,SUM(ITM_NWT) As Nwt,SUM(ITM_FINE) As Fine FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '+' AND B.IT_TYPE = 'S'"));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (table.Rows.Count > 0)
					{
						((DataGridView)dGV4)[22, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Gwt"], (object)""));
						((DataGridView)dGV4)[23, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Nwt"], (object)""));
						((DataGridView)dGV4)[24, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Fine"], (object)""));
					}
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM KR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (table.Rows.Count > 0)
				{
					((DataGridView)dGV4)[3, DC_Main.R].Value = Operators.ConcatenateObject(table.Rows[0]["AC_NAME"], (object)"");
					((DataGridView)dGV4)[4, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["DISC_AMT"], (object)""));
					((DataGridView)dGV4)[5, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["TOT_AMT"], (object)""));
					((DataGridView)dGV4)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CASH_AMT"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(table.Rows[0]["CHQ_NO"], (object)""), (object)"U", false))
					{
						((DataGridView)dGV4)[9, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CHQ_AMT"], (object)""));
					}
					else
					{
						((DataGridView)dGV4)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CHQ_AMT"], (object)""));
					}
					((DataGridView)dGV4)[8, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CARD_AMT"], (object)""));
					((DataGridView)dGV4)[17, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["BILL_OS"], (object)""));
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(ITM_GWT) As Gwt,SUM(ITM_NWT) As Nwt,SUM(ITM_FINE) As Fine FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '+' AND B.IT_TYPE = 'G'"));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (table.Rows.Count > 0)
					{
						((DataGridView)dGV4)[19, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Gwt"], (object)""));
						((DataGridView)dGV4)[20, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Nwt"], (object)""));
						((DataGridView)dGV4)[21, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Fine"], (object)""));
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(ITM_GWT) As Gwt,SUM(ITM_NWT) As Nwt,SUM(ITM_FINE) As Fine FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '+' AND B.IT_TYPE = 'S'"));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (table.Rows.Count > 0)
					{
						((DataGridView)dGV4)[22, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Gwt"], (object)""));
						((DataGridView)dGV4)[23, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Nwt"], (object)""));
						((DataGridView)dGV4)[24, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Fine"], (object)""));
					}
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND B.MAIN_BOOK = 'SALES RETURNE' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "));
				table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (table.Rows.Count > 0)
				{
					((DataGridView)dGV4)[3, DC_Main.R].Value = Operators.ConcatenateObject(table.Rows[0]["AC_NAME"], (object)"");
					((DataGridView)dGV4)[5, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["RTN_TOT_AMT"], (object)""));
					((DataGridView)dGV4)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["RTN_CASH_AMT"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(table.Rows[0]["CHQ_NO"], (object)""), (object)"U", false))
					{
						((DataGridView)dGV4)[9, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["RTN_CHQ_AMT"], (object)""));
					}
					else
					{
						((DataGridView)dGV4)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["RTN_CHQ_AMT"], (object)""));
					}
					((DataGridView)dGV4)[8, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["RTN_CARD_AMT"], (object)""));
					((DataGridView)dGV4)[16, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["RTN_KASAR_AMT"], (object)""));
					((DataGridView)dGV4)[17, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["RTN_BILL_OS"], (object)""));
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(ITM_GWT) As Gwt,SUM(ITM_NWT) As Nwt,SUM(ITM_FINE) As Fine FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '+' AND B.IT_TYPE = 'G'"));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (table.Rows.Count > 0)
					{
						((DataGridView)dGV4)[19, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Gwt"], (object)""));
						((DataGridView)dGV4)[20, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Nwt"], (object)""));
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(ITM_GWT) As Gwt,SUM(ITM_NWT) As Nwt,SUM(ITM_FINE) As Fine FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '+' AND B.IT_TYPE = 'S'"));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (table.Rows.Count > 0)
					{
						((DataGridView)dGV4)[22, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Gwt"], (object)""));
						((DataGridView)dGV4)[23, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Nwt"], (object)""));
					}
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND PR_NET_AMT+PR_FINE <> 0"));
				table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (table.Rows.Count > 0)
				{
					((DataGridView)dGV4)[3, DC_Main.R].Value = Operators.ConcatenateObject(table.Rows[0]["AC_NAME"], (object)"");
					((DataGridView)dGV4)[4, DC_Main.R].Value = 0;
					((DataGridView)dGV4)[5, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["PR_TOT_AMT"], (object)""));
					((DataGridView)dGV4)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["PR_CASH_AMT"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(table.Rows[0]["CHQ_NO"], (object)""), (object)"U", false))
					{
						((DataGridView)dGV4)[9, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["PR_CHQ_AMT"], (object)""));
					}
					else
					{
						((DataGridView)dGV4)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["PR_CHQ_AMT"], (object)""));
					}
					((DataGridView)dGV4)[8, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["PR_CARD_AMT"], (object)""));
					((DataGridView)dGV4)[15, DC_Main.R].Value = 0;
					((DataGridView)dGV4)[16, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["PR_KASAR_AMT"], (object)""));
					((DataGridView)dGV4)[17, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["PR_BILL_OS"], (object)""));
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(ITM_GWT) As Gwt,SUM(ITM_NWT) As Nwt,SUM(ITM_FINE) As Fine FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '+' AND B.IT_TYPE = 'G'"));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (table.Rows.Count > 0)
					{
						((DataGridView)dGV4)[19, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Gwt"], (object)""));
						((DataGridView)dGV4)[20, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Nwt"], (object)""));
						((DataGridView)dGV4)[21, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Fine"], (object)""));
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(ITM_GWT) As Gwt,SUM(ITM_NWT) As Nwt,SUM(ITM_FINE) As Fine FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '+' AND B.IT_TYPE = 'S'"));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (table.Rows.Count > 0)
					{
						((DataGridView)dGV4)[22, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Gwt"], (object)""));
						((DataGridView)dGV4)[23, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Nwt"], (object)""));
						((DataGridView)dGV4)[24, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Fine"], (object)""));
					}
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.BOOK_NAME,A.AC_CODE,B.AC_NAME,SUM(A.DR_AMT) As PayAmt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.BOOK_NAME IN ('CASH PAY','BANK PAY') AND A.DR_AMT <> 0 GROUP BY A.BOOK_NAME,A.AC_CODE,B.AC_NAME"));
				table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.X = 0;
				while (DC_Main.X < table.Rows.Count)
				{
					if (DC_Main.X >= 1)
					{
						((DataGridView)dGV4)[25, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["CO_BOOK"]);
						((DataGridView)dGV4)[26, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["MAIN_BOOK"]);
						num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV4)[6, DC_Main.R].Value));
						num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV4)[7, DC_Main.R].Value));
						((DataGridView)dGV4).Rows.Add();
						DC_Main.R++;
						((DataGridView)dGV4)[0, DC_Main.R].Value = DC_Main.R + 1;
						((DataGridView)dGV4)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["BOOK_SNAME"]);
						((DataGridView)dGV4)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["VCH_NO"]);
					}
					((DataGridView)dGV4)[3, DC_Main.R].Value = Operators.ConcatenateObject(table.Rows[DC_Main.X]["AC_NAME"], (object)"");
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(table.Rows[0]["BOOK_NAME"], (object)""), (object)"CASH PAY", false))
					{
						((DataGridView)dGV4)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[DC_Main.X]["PayAmt"], (object)""));
					}
					else
					{
						((DataGridView)dGV4)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[DC_Main.X]["PayAmt"], (object)""));
					}
					DC_Main.X++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.BOOK_NAME,A.AC_CODE,B.AC_NAME,SUM(A.DR_AMT) As PayAmt,A.LD_CODE FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.BOOK_NAME IN ('MEMB ADJUST','ORDER CANCEL') AND A.DR_AMT <> 0 GROUP BY A.BOOK_NAME,A.AC_CODE,B.AC_NAME,A.LD_CODE"));
				table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.X = 0;
				while (DC_Main.X < table.Rows.Count)
				{
					if (DC_Main.X >= 1)
					{
						((DataGridView)dGV4)[25, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["CO_BOOK"]);
						((DataGridView)dGV4)[26, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["MAIN_BOOK"]);
						num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV4)[6, DC_Main.R].Value));
						num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV4)[7, DC_Main.R].Value));
						((DataGridView)dGV4).Rows.Add();
						DC_Main.R++;
						((DataGridView)dGV4)[0, DC_Main.R].Value = DC_Main.R + 1;
						((DataGridView)dGV4)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["BOOK_SNAME"]);
						((DataGridView)dGV4)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["VCH_NO"]);
					}
					((DataGridView)dGV4)[3, DC_Main.R].Value = Operators.ConcatenateObject(table.Rows[DC_Main.X]["AC_NAME"], (object)"");
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(table.Rows[0]["LD_CODE"], (object)""), (object)"00001", false))
					{
						((DataGridView)dGV4)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[DC_Main.X]["PayAmt"], (object)""));
					}
					else
					{
						((DataGridView)dGV4)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[DC_Main.X]["PayAmt"], (object)""));
					}
					DC_Main.X++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (table.Rows.Count > 0)
				{
					((DataGridView)dGV4)[3, DC_Main.R].Value = Operators.ConcatenateObject(table.Rows[0]["AC_NAME"], (object)"");
					((DataGridView)dGV4)[4, DC_Main.R].Value = 0;
					((DataGridView)dGV4)[5, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["NET_AMT"], (object)""));
					((DataGridView)dGV4)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CASH_AMT"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(table.Rows[0]["CHQ_NO"], (object)""), (object)"U", false))
					{
						((DataGridView)dGV4)[9, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CHQ_AMT"], (object)""));
					}
					else
					{
						((DataGridView)dGV4)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CHQ_AMT"], (object)""));
					}
					((DataGridView)dGV4)[8, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["CARD_AMT"], (object)""));
					((DataGridView)dGV4)[17, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["BILL_OS"], (object)""));
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(ITM_GWT) As Gwt,SUM(ITM_NWT) As Nwt,SUM(ITM_FINE) As Fine FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '+' AND B.IT_TYPE = 'G'"));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (table.Rows.Count > 0)
					{
						((DataGridView)dGV4)[19, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Gwt"], (object)""));
						((DataGridView)dGV4)[20, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Nwt"], (object)""));
						((DataGridView)dGV4)[21, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Fine"], (object)""));
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(ITM_GWT) As Gwt,SUM(ITM_NWT) As Nwt,SUM(ITM_FINE) As Fine FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '"), dataTable.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), dataTable.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND A.VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.ITM_SIGN = '+' AND B.IT_TYPE = 'S'"));
					table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (table.Rows.Count > 0)
					{
						((DataGridView)dGV4)[22, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Gwt"], (object)""));
						((DataGridView)dGV4)[23, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Nwt"], (object)""));
						((DataGridView)dGV4)[24, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[0]["Fine"], (object)""));
					}
				}
				((DataGridView)dGV4)[25, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["CO_BOOK"]);
				((DataGridView)dGV4)[26, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.M]["MAIN_BOOK"]);
				num6 = Conversions.ToDouble(Operators.AddObject((object)num6, ((DataGridView)dGV4)[4, DC_Main.R].Value));
				num7 = Conversions.ToDouble(Operators.AddObject((object)num7, ((DataGridView)dGV4)[5, DC_Main.R].Value));
				num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV4)[6, DC_Main.R].Value));
				num3 = Conversions.ToDouble(Operators.AddObject((object)num3, ((DataGridView)dGV4)[7, DC_Main.R].Value));
				num4 = Conversions.ToDouble(Operators.AddObject((object)num4, ((DataGridView)dGV4)[8, DC_Main.R].Value));
				num8 = Conversions.ToDouble(Operators.AddObject((object)num8, ((DataGridView)dGV4)[9, DC_Main.R].Value));
				num9 = Conversions.ToDouble(Operators.AddObject((object)num9, ((DataGridView)dGV4)[10, DC_Main.R].Value));
				num10 = Conversions.ToDouble(Operators.AddObject((object)num10, ((DataGridView)dGV4)[11, DC_Main.R].Value));
				num11 = Conversions.ToDouble(Operators.AddObject((object)num11, ((DataGridView)dGV4)[12, DC_Main.R].Value));
				num12 = Conversions.ToDouble(Operators.AddObject((object)num12, ((DataGridView)dGV4)[13, DC_Main.R].Value));
				num13 = Conversions.ToDouble(Operators.AddObject((object)num13, ((DataGridView)dGV4)[14, DC_Main.R].Value));
				num14 = Conversions.ToDouble(Operators.AddObject((object)num14, ((DataGridView)dGV4)[15, DC_Main.R].Value));
				num15 = Conversions.ToDouble(Operators.AddObject((object)num15, ((DataGridView)dGV4)[16, DC_Main.R].Value));
				num16 = Conversions.ToDouble(Operators.AddObject((object)num16, ((DataGridView)dGV4)[17, DC_Main.R].Value));
				num17 = Conversions.ToDouble(Operators.AddObject((object)num17, ((DataGridView)dGV4)[18, DC_Main.R].Value));
				num18 = Conversions.ToDouble(Operators.AddObject((object)num18, ((DataGridView)dGV4)[19, DC_Main.R].Value));
				num19 = Conversions.ToDouble(Operators.AddObject((object)num19, ((DataGridView)dGV4)[20, DC_Main.R].Value));
				num20 = Conversions.ToDouble(Operators.AddObject((object)num20, ((DataGridView)dGV4)[21, DC_Main.R].Value));
				num21 = Conversions.ToDouble(Operators.AddObject((object)num21, ((DataGridView)dGV4)[22, DC_Main.R].Value));
				num22 = Conversions.ToDouble(Operators.AddObject((object)num22, ((DataGridView)dGV4)[23, DC_Main.R].Value));
				num23 = Conversions.ToDouble(Operators.AddObject((object)num23, ((DataGridView)dGV4)[24, DC_Main.R].Value));
				DC_Main.R++;
				dGV4 = null;
				DC_Main.M++;
			}
			DC_Main.RsQry = "SELECT A.*,B.BOOK_SNAME FROM SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.MAIN_BOOK = 'SALES' AND A.VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND A.CASH_PAID <> 0 ORDER BY A.CO_BOOK,A.VCH_NO ";
			table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			int num26 = table.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num26)
			{
				DataGridViewX dGV5 = DGV;
				((DataGridView)dGV5).Rows.Add();
				((DataGridView)dGV5)[0, DC_Main.R].Value = DC_Main.R + 1;
				((DataGridView)dGV5)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(table.Rows[DC_Main.M]["BOOK_SNAME"]);
				((DataGridView)dGV5)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(table.Rows[DC_Main.M]["VCH_NO"]);
				((DataGridView)dGV5)[3, DC_Main.R].Value = Operators.ConcatenateObject(table.Rows[DC_Main.M]["AC_NAME"], (object)"");
				((DataGridView)dGV5)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(table.Rows[DC_Main.M]["CASH_PAID"], (object)""));
				num2 = Conversions.ToDouble(Operators.AddObject((object)num2, ((DataGridView)dGV5)[6, DC_Main.R].Value));
				DC_Main.R++;
				dGV5 = null;
				DC_Main.M++;
			}
			((DataGridView)DGV).Rows.Add();
			((DataGridView)DGV).Rows.Add();
			DC_Main.R++;
			DataGridViewX dGV6 = DGV;
			((DataGridView)dGV6)[3, DC_Main.R].Value = "Total :";
			((DataGridView)dGV6)[4, DC_Main.R].Value = num6;
			((DataGridView)dGV6)[5, DC_Main.R].Value = num7;
			((DataGridView)dGV6)[6, DC_Main.R].Value = num2;
			((DataGridView)dGV6)[7, DC_Main.R].Value = num3;
			((DataGridView)dGV6)[8, DC_Main.R].Value = num4;
			((DataGridView)dGV6)[9, DC_Main.R].Value = num8;
			((DataGridView)dGV6)[10, DC_Main.R].Value = num9;
			((DataGridView)dGV6)[11, DC_Main.R].Value = num10;
			((DataGridView)dGV6)[12, DC_Main.R].Value = num11;
			((DataGridView)dGV6)[13, DC_Main.R].Value = num12;
			((DataGridView)dGV6)[14, DC_Main.R].Value = num13;
			((DataGridView)dGV6)[15, DC_Main.R].Value = num14;
			((DataGridView)dGV6)[16, DC_Main.R].Value = num15;
			((DataGridView)dGV6)[17, DC_Main.R].Value = num16;
			((DataGridView)dGV6)[18, DC_Main.R].Value = num17;
			((DataGridView)dGV6)[19, DC_Main.R].Value = num18;
			((DataGridView)dGV6)[20, DC_Main.R].Value = num19;
			((DataGridView)dGV6)[21, DC_Main.R].Value = num20;
			((DataGridView)dGV6)[22, DC_Main.R].Value = num21;
			((DataGridView)dGV6)[23, DC_Main.R].Value = num22;
			((DataGridView)dGV6)[24, DC_Main.R].Value = num23;
			dGV6 = null;
			((DataGridView)DGV).Rows[DC_Main.R].DefaultCellStyle.ForeColor = Color.Red;
		}
	}

	private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
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
				{
					ProjectData.ClearProjectError();
					num2 = 2;
					int columnIndex = e.ColumnIndex;
					if ((uint)(columnIndex - 4) <= 20u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 104:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_009e;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 104;
				continue;
			}
			break;
			IL_009e:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		mSG.Clear();
		mSG.Cols = 15;
		mSG.Rows = 2;
		mSG[0] = 325;
		mSG[0] = 0;
		checked
		{
			mSG[0] = (int)Math.Round(700.0 * ColCon);
			mSG[0, 0] = "Sr.";
			mSG[1] = 0;
			mSG[1] = (int)Math.Round(1100.0 * ColCon);
			mSG[0, 1] = "Book";
			mSG[2] = 0;
			mSG[2] = (int)Math.Round(1150.0 * ColCon);
			mSG[0, 2] = "VchNo";
			mSG[3] = 0;
			mSG[3] = (int)Math.Round(4000.0 * ColCon);
			mSG[0, 3] = "Name";
			mSG[4] = 7;
			mSG[4] = (int)Math.Round(1500.0 * ColCon);
			mSG[0, 4] = "Jama";
			mSG[5] = 0;
			mSG[5] = (int)Math.Round(700.0 * ColCon);
			mSG[0, 5] = "Sr.";
			mSG[6] = 0;
			mSG[6] = (int)Math.Round(1100.0 * ColCon);
			mSG[0, 6] = "Book";
			mSG[7] = 0;
			mSG[7] = (int)Math.Round(1150.0 * ColCon);
			mSG[0, 7] = "VchNo";
			mSG[8] = 0;
			mSG[8] = (int)Math.Round(4000.0 * ColCon);
			mSG[0, 8] = "Name";
			mSG[9] = 7;
			mSG[9] = (int)Math.Round(1500.0 * ColCon);
			mSG[0, 9] = "Udhar";
			mSG[10] = 0;
			mSG[11] = 0;
			mSG[12] = 0;
			mSG[13] = 0;
			mSG[14] = 0;
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			mSG.Row = 1;
			mSG = null;
		}
	}

	private void RP_ROJMEL_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_08a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ae: Expected O, but got Unknown
		//IL_0929: Unknown result type (might be due to invalid IL or missing references)
		//IL_092e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0938: Expected O, but got Unknown
		//IL_09c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cf: Expected O, but got Unknown
		//IL_0a41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4c: Expected O, but got Unknown
		//IL_0ae1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af0: Expected O, but got Unknown
		//IL_0b2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3e: Expected O, but got Unknown
		//IL_0bb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc1: Expected O, but got Unknown
		//IL_0be0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bef: Expected O, but got Unknown
		//IL_0c0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1d: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurRpt = DC_Main.MsUserRightForm;
		lblBook.Text = CurRpt;
		DC_Main.MsUserRightForm = "";
		if (dataTable.Rows.Count > 0)
		{
			UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));
			UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));
			UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr.Connect = DC_Main.CrConnect;
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
				AxMSFlexGrid mSG = MSG;
				object? obj7 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj8 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj8 != null) ? ((Color)obj8) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj9 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj9 != null) ? ((Color)obj9) : default(Color));
				TextBox tEXT_ENTRY = TEXT_ENTRY;
				object? obj10 = colorConverter.ConvertFromString("255, 224, 192");
				((TextBoxBase)tEXT_ENTRY).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj11 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AxMSFlexGrid mSG4 = MSG;
				object? obj12 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj13 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj14 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj14 != null) ? ((Color)obj14) : default(Color));
				TextBox tEXT_ENTRY2 = TEXT_ENTRY;
				object? obj15 = colorConverter.ConvertFromString("200, 205, 210");
				((TextBoxBase)tEXT_ENTRY2).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj16 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj17 = lblBook;
				object? obj18 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj17).ForeColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj19 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj20 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj21 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj22 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj22 != null) ? ((Color)obj22) : default(Color));
				TextBox tEXT_ENTRY3 = TEXT_ENTRY;
				object? obj23 = colorConverter.ConvertFromString("205, 220, 220");
				((TextBoxBase)tEXT_ENTRY3).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)mToDt).Font.Size * (1.0 + num2));
				Font font = ((Control)mToDt).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is SearchControl || val3 is CheckBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
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
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
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
			}
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				lblBook.Text = "Day Book Report";
				((Form)this).Text = "Day Book";
			}
			if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0))
			{
				((Control)btnDailyWork).Visible = true;
			}
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				((Control)btnDailyWork).Visible = true;
			}
			CLEAR_DATA();
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) != 0)
			{
				((Control)Label6).Visible = false;
				((Control)tLcCode).Visible = false;
				((Control)tLcName).Visible = false;
			}
			else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				((Control)Label6).Visible = false;
				((Control)tLcCode).Visible = false;
				((Control)tLcName).Visible = false;
			}
			tLcCode.Text = DC_Main.MLc_code;
			tLcName.Text = DC_Main.MLc_Name;
			CurActCtrl = (Control)(object)mToDt;
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
		((Control)TEXT_ENTRY).Visible = false;
		MSG_CLEAR();
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		((Control)mToDt).Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr[(short)5] = "";
			Cr[(short)6] = "";
			Cr[(short)7] = "";
		}
		DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA ");
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select CO_BOOK,VCH_NO,VCH_DATE,PARTY_AC_CODE,DATA_TYPE,SUM(CR_AMT) As CrAmt,SUM(DR_AMT) AS DrAmt,SUM(CASE WHEN SIGN = '+' AND IT_TYPE = 'G' THEN FINE_WT ELSE 0 END) AS CrFine,SUM(CASE WHEN SIGN = '-' AND IT_TYPE = 'G' THEN FINE_WT ELSE 0 END) AS DrFine ,  SUM(CASE WHEN SIGN = '+' AND IT_TYPE = 'S' THEN FINE_WT ELSE 0 END) AS CrSilver,SUM(CASE WHEN SIGN = '-' AND IT_TYPE = 'S' THEN FINE_WT ELSE 0 END) AS DrSilver FROM AC_DATA AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' and VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.PARTY_AC_CODE <> '' GROUP BY CO_BOOK,VCH_NO,VCH_DATE,PARTY_AC_CODE,DATA_TYPE ORDER BY CO_BOOK,VCH_NO,PARTY_AC_CODE "));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.X = 0;
		checked
		{
			while (DC_Main.X < dataTable.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LEDR_AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_DT,MAIN_USER,AC_CODE,CR_AMT,DR_AMT,CR_FINE_WT,DR_FINE_WT,CR_SL_FINE,DR_SL_FINE,DATA_TYPE) VALUES('" + DC_Main.MCo_code + "','" + tLcCode.Text + "','" + DC_Main.MCo_year + "','"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"','"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"','"), dataTable.Rows[DC_Main.X]["VCH_NO"]), (object)"','"), dataTable.Rows[DC_Main.X]["PARTY_AC_CODE"]), (object)"',"), dataTable.Rows[DC_Main.X]["CrAmt"]), (object)","), dataTable.Rows[DC_Main.X]["DrAmt"]), (object)","), dataTable.Rows[DC_Main.X]["CrFine"]), (object)","), dataTable.Rows[DC_Main.X]["DrFine"]), (object)","), dataTable.Rows[DC_Main.X]["CrSilver"]), (object)","), dataTable.Rows[DC_Main.X]["DrSilver"]), (object)",'"), (object)DC_Main.MsDataType), (object)"')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.X++;
			}
			DC_Main.RsQry = "SELECT * FROM LEDR_AC_DATA";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			ItStk();
			CurFormula = "{LEDR_AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LEDR_AC_DATA.LC_CODE} = '" + tLcCode.Text + "' AND {LEDR_AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {LEDR_AC_DATA.VCH_DT} = #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(DC_Main.MsDataType, "C", false) != 0)
			{
				CurFormula = CurFormula + " and {LEDR_AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) AS AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"AND VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					DC_Main.MsCrForName1 = "OpenCashAmt";
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
					double num = DC_Main.Fnv(ref Value);
					dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.MsCrForVal1 = Strings.Format((object)num, "0.00");
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) AS AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					DC_Main.MsCrForName2 = "ClgCashAmt";
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
					double num2 = DC_Main.Fnv(ref Value);
					dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.MsCrForVal2 = Strings.Format((object)num2, "0.00");
				}
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'RojMel Report Date " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				DC_Main.MsCrForName4 = "FromDate";
				DC_Main.MsCrForStr4 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
				DC_Main.RptName = "RojMelCrDr";
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptFormula = CurFormula;
				Module_Save.ShowReportPreview();
				CurFormula = "";
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) AS AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					AxCrystalReport cr = Cr;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
					double num3 = DC_Main.Fnv(ref Value);
					dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
					cr[(short)1] = "OpenCashAmt = " + Strings.Format((object)num3, "0.00");
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) AS AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					AxCrystalReport cr2 = Cr;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
					double num4 = DC_Main.Fnv(ref Value);
					dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
					cr2[(short)2] = "ClgCashAmt = " + Strings.Format((object)num4, "0.00");
				}
				Cr[(short)0] = "RptTitel = 'RojMel Report Date " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				Cr[(short)3] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\RojMelCrDr.RPT";
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
				CurFormula = "";
			}
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
		tLcCode.Text = DC_Main.MLc_code;
	}

	private void RP_ROJMEL_Closed(object sender, EventArgs e)
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

	private void tLcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From LOCT_MAST WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count <= 0)
			{
				DC_Main.RsQry = "Select LC_CODE As CodeL,LC_NAME As NameL,LC_ADD1 As AddressL,LC_CITY As CityL FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY LC_CODE";
				DC_Main.RsDg = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[5];
				DC_Main.ColWidth[0] = 70.0;
				DC_Main.ColWidth[1] = 280.0;
				DC_Main.ColWidth[2] = 300.0;
				DC_Main.ColWidth[3] = 250.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tLcCode.Text = DC_Main.ColValue[0];
					tLcName.Text = DC_Main.ColValue[1];
				}
			}
			else
			{
				tLcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LC_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboSectionType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void BtnGstr1_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr[(short)5] = "";
			Cr[(short)6] = "";
			Cr[(short)7] = "";
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) AS AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"AND VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AxCrystalReport cr = Cr;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
				cr[(short)1] = "OpenCashAmt = " + Strings.Format((object)num, "0.00");
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT ) AS DrMount,SUM(CR_AMT ) AS CrMount  From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AxCrystalReport cr2 = Cr;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["DrMount"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["DrMount"] = RuntimeHelpers.GetObjectValue(Value);
				cr2[(short)2] = ("RjDrAmt = " + Strings.Format((object)num2, "0.00")) ?? "";
				AxCrystalReport cr3 = Cr;
				Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["CRMount"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["CRMount"] = RuntimeHelpers.GetObjectValue(Value);
				cr3[(short)3] = ("RjCrAmt = " + Strings.Format((object)num3, "0.00")) ?? "";
			}
			else
			{
				Cr[(short)2] = "RjDrAmt = 0";
				Cr[(short)3] = "RjCrAmt = 0";
			}
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\RojMelItem.RPT";
			CurFormula = "{ROJ_MEL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {ROJ_MEL_DATA.LC_CODE} = '" + tLcCode.Text + "' AND {ROJ_MEL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {ROJ_MEL_DATA.VCH_DATE} = #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(DC_Main.MsDataType, "C", false) != 0)
			{
				CurFormula = CurFormula + " and {ROJ_MEL_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			Cr[(short)0] = "RptTitel = 'RojMel Report Date " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr[(short)4] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
			Cr[(short)5] = "DataType = '" + DC_Main.MsDataType + "'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			CurFormula = "";
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) AS AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"AND VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.MsCrForName1 = "OpenCashAmt";
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.MsCrForVal1 = Strings.Format((object)num4, "0.00");
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT ) AS DrMount,SUM(CR_AMT ) AS CrMount  From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.MsCrForName2 = "RjDrAmt";
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["DrMount"]);
				double num5 = DC_Main.Fnv(ref Value);
				dataRow["DrMount"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.MsCrForVal2 = Strings.Format((object)num5, "0.00");
				DC_Main.MsCrForName3 = "RjCrAmt";
				Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["CRMount"]);
				double num6 = DC_Main.Fnv(ref Value);
				dataRow["CRMount"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.MsCrForVal3 = Strings.Format((object)num6, "0.00");
			}
			else
			{
				DC_Main.MsCrForName2 = "RjDrAmt";
				DC_Main.MsCrForVal2 = Conversions.ToString(0);
				DC_Main.MsCrForName3 = "RjCrAmt";
				DC_Main.MsCrForVal3 = Conversions.ToString(0);
			}
			CurFormula = "{ROJ_MEL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {ROJ_MEL_DATA.LC_CODE} = '" + tLcCode.Text + "' AND {ROJ_MEL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {ROJ_MEL_DATA.VCH_DATE} = #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(DC_Main.MsDataType, "C", false) != 0)
			{
				CurFormula = CurFormula + " and {ROJ_MEL_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'RojMel Report Date " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsCrForName4 = "FromDate";
			DC_Main.MsCrForStr4 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
			DC_Main.MsCrForName5 = "DataType";
			DC_Main.MsCrForStr5 = "'" + DC_Main.MsDataType + "'";
			DC_Main.RptName = "RojMelItem";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
	}

	private void ItStk()
	{
		DC_Main.ExeQuteDc("UPDATE GROUP_MAST SET DAY_OP_WT = 0,DAY_CL_WT = 0,DAY_OP_PCS = 0,DAY_CL_PCS = 0 ");
		DC_Main.RsQry = "SELECT * FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.X = 0;
		checked
		{
			while (DC_Main.X < dataTable.Rows.Count)
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.GR_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS CloseWt,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS ClosePcs FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.GR_CODE = '"), dataTable.Rows[DC_Main.X]["GR_CODE"]), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" and VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' GROUP BY B.GR_CODE"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CloseWt"]), "0.000"));
					num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ClosePcs"]), "0.000"));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.GR_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS CloseWt,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS ClosePcs FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.GR_CODE = '"), dataTable.Rows[DC_Main.X]["GR_CODE"]), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' GROUP BY B.GR_CODE"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CloseWt"]), "0.000"));
					num4 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ClosePcs"]), "0.000"));
				}
				DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE GROUP_MAST SET DAY_OP_WT = " + Conversions.ToString(num) + ",DAY_CL_WT = " + Conversions.ToString(num2) + ",DAY_OP_PCS = " + Conversions.ToString(num3) + ",DAY_CL_PCS = " + Conversions.ToString(num4) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE = '"), dataTable.Rows[DC_Main.X]["GR_CODE"]), (object)"'")));
				DC_Main.X++;
			}
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr[(short)5] = "";
			Cr[(short)6] = "";
			Cr[(short)7] = "";
			ItStk();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) AS AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AxCrystalReport cr = Cr;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
				cr[(short)1] = "OpenCashAmt = " + Strings.Format((object)num, "0.00");
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT ) AS DrMount,SUM(CR_AMT ) AS CrMount  From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AxCrystalReport cr2 = Cr;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["DrMount"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["DrMount"] = RuntimeHelpers.GetObjectValue(Value);
				cr2[(short)2] = ("RjDrAmt = " + Strings.Format((object)num2, "0.00")) ?? "";
				AxCrystalReport cr3 = Cr;
				Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["CRMount"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["CRMount"] = RuntimeHelpers.GetObjectValue(Value);
				cr3[(short)3] = ("RjCrAmt = " + Strings.Format((object)num3, "0.00")) ?? "";
			}
			else
			{
				Cr[(short)2] = "RjDrAmt = 0";
				Cr[(short)3] = "RjCrAmt = 0";
			}
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM107NPHM", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM106NPHM", false) == 0))
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\RojMelEstmat.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\RojMel.RPT";
			}
			CurFormula = "{ROJ_MEL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {ROJ_MEL_DATA.LC_CODE} = '" + tLcCode.Text + "' AND {ROJ_MEL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {ROJ_MEL_DATA.VCH_DATE} = #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(DC_Main.MsDataType, "C", false) != 0)
			{
				CurFormula = CurFormula + " and {ROJ_MEL_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			Cr[(short)0] = "RptTitel = 'RojMel Report Date " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr[(short)4] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
			Cr[(short)5] = "DataType = '" + DC_Main.MsDataType + "'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			CurFormula = "";
		}
		else
		{
			ItStk();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) AS AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"AND VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.MsCrForName1 = "OpenCashAmt";
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.MsCrForVal1 = Strings.Format((object)num4, "0.00");
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT ) AS DrMount,SUM(CR_AMT ) AS CrMount  From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.MsCrForName2 = "RjDrAmt";
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["DrMount"]);
				double num5 = DC_Main.Fnv(ref Value);
				dataRow["DrMount"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.MsCrForVal2 = Strings.Format((object)num5, "0.00");
				DC_Main.MsCrForName3 = "RjCrAmt";
				Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["CRMount"]);
				double num6 = DC_Main.Fnv(ref Value);
				dataRow["CRMount"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.MsCrForVal3 = Strings.Format((object)num6, "0.00");
			}
			else
			{
				DC_Main.MsCrForName2 = "RjDrAmt";
				DC_Main.MsCrForVal2 = Conversions.ToString(0);
				DC_Main.MsCrForName3 = "RjCrAmt";
				DC_Main.MsCrForVal3 = Conversions.ToString(0);
			}
			CurFormula = "{ROJ_MEL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {ROJ_MEL_DATA.LC_CODE} = '" + tLcCode.Text + "' AND {ROJ_MEL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {ROJ_MEL_DATA.VCH_DATE} = #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(DC_Main.MsDataType, "C", false) != 0)
			{
				CurFormula = CurFormula + " and {ROJ_MEL_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'RojMel Report Date " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsCrForName4 = "FromDate";
			DC_Main.MsCrForStr4 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
			DC_Main.MsCrForName5 = "DataType";
			DC_Main.MsCrForStr5 = "'" + DC_Main.MsDataType + "'";
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM107NPHM", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM106NPHM", false) == 0))
			{
				DC_Main.RptName = "RojMelEstmat";
			}
			else
			{
				DC_Main.RptName = "RojMel";
			}
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
	}

	private void mToDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		MaskedTextBox MsDate = mToDt;
		DC_Main.SetDate(ref MsDate);
		mToDt = MsDate;
		if (!DC_Main.RongDate)
		{
			DC_Main.RsQry = "SELECT * FROM ROJMEL_BAL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				nClBal.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["CLOSING_CASH"])), "0.00");
			}
			else
			{
				nClBal.Text = "";
			}
			SendKeys.Send("{tab}");
		}
	}

	private void mToDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToDt).SelectionStart = 0;
		((TextBoxBase)mToDt).SelectionLength = Strings.Len(mToDt.Text);
	}

	private void BtnGold_Click(object sender, EventArgs e)
	{
		//IL_0a44: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num6 = default(int);
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
						if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
						{
							DC_Main.SoftLoad();
						}
						((Control)DGV).Visible = false;
						((Control)TEXT_ENTRY).Visible = true;
						((Control)MSG).Visible = true;
						RptType = "Gl";
						MSG_CLEAR();
						double num3 = 0.0;
						double num4 = 0.0;
						ProjectData.ClearProjectError();
						num2 = 2;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND ITM_FINE <> 0 AND SIGN = '+' AND IT_TYPE = 'G' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 1;
						DC_Main.X = 0;
						AxMSFlexGrid mSG = MSG;
						while (DC_Main.X < DC_Main.Rshlp.Rows.Count)
						{
							if (Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[DC_Main.X]["SIGN"], (object)"+", false))
							{
								mSG[DC_Main.i, 0] = Conversions.ToString(DC_Main.i);
								mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_TYPE"], (object)""));
								mSG[DC_Main.i, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["CO_BOOK"], (object)""));
								mSG[DC_Main.i, 11] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["BOOK_NAME"], (object)""));
								if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_NAME"], (object)""), (object)"", false))
								{
									mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_NAME"], (object)""));
								}
								else
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.X]["AC_CODE"]), (object)"'"));
									DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
									if (dataTable.Rows.Count > 0)
									{
										mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["AC_NAME"], (object)""));
									}
								}
								mSG[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_NO"], (object)""));
								mSG[DC_Main.i, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["ITM_FINE"]), "0.000");
								mSG[DC_Main.i, 14] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
								num4 += Conversion.Val(mSG[DC_Main.i, 4]);
								DC_Main.i++;
								mSG.Rows += 1;
							}
							DC_Main.X++;
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND ITM_FINE <> 0 AND SIGN = '-' AND IT_TYPE = 'G' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 1;
						DC_Main.X = 0;
						while (DC_Main.X < DC_Main.Rshlp.Rows.Count)
						{
							if (Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[DC_Main.X]["SIGN"], (object)"-", false))
							{
								mSG[DC_Main.i, 5] = Conversions.ToString(DC_Main.i);
								mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_TYPE"], (object)""));
								mSG[DC_Main.i, 12] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["CO_BOOK"], (object)""));
								mSG[DC_Main.i, 13] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["BOOK_NAME"], (object)""));
								if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_NAME"], (object)""), (object)"", false))
								{
									mSG[DC_Main.i, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_NAME"], (object)""));
								}
								else
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.X]["AC_CODE"]), (object)"'"));
									DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
									if (dataTable.Rows.Count > 0)
									{
										mSG[DC_Main.i, 8] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["AC_NAME"], (object)""));
									}
								}
								mSG[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_NO"], (object)""));
								mSG[DC_Main.i, 9] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["ITM_FINE"]), "0.000");
								mSG[DC_Main.i, 14] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
								num3 += Conversion.Val(mSG[DC_Main.i, 9]);
								DC_Main.i++;
								mSG.Rows += 1;
							}
							DC_Main.X++;
						}
						int num5 = mSG.Rows - 1;
						DC_Main.R = 1;
						while (DC_Main.R <= num5)
						{
							if ((Operators.CompareString(mSG[DC_Main.R, 0], "", false) == 0) & (Operators.CompareString(mSG[DC_Main.R, 5], "", false) == 0))
							{
								num6++;
							}
							DC_Main.R++;
						}
						num6--;
						if (mSG.Rows > 2)
						{
							mSG.Rows -= num6;
						}
						mSG.Rows += 2;
						DC_Main.i = mSG.Rows - 1;
						mSG[DC_Main.i, 3] = " Grand Total Jama :";
						mSG[DC_Main.i, 8] = " Grand Total Udhar :";
						mSG[DC_Main.i, 9] = Strings.Format((object)num3, "0.000");
						mSG[DC_Main.i, 4] = Strings.Format((object)num4, "0.000");
						mSG.Row = DC_Main.i;
						int num7 = mSG.Cols - 1;
						DC_Main.i = 0;
						while (DC_Main.i <= num7)
						{
							mSG.Col = DC_Main.i;
							mSG.CellForeColor = Color.Blue;
							DC_Main.i++;
						}
						mSG = null;
						MSG.Col = 1;
						MSG.Row = 1;
						((Control)MSG).Focus();
						goto end_IL_0001;
					}
					case 2636:
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
				try0001_dispatch = 2636;
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

	private void BtnAmt_Click(object sender, EventArgs e)
	{
		//IL_10c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num11 = default(int);
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
						if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
						{
							DC_Main.SoftLoad();
						}
						((Control)DGV).Visible = false;
						((Control)TEXT_ENTRY).Visible = true;
						((Control)MSG).Visible = true;
						RptType = "Amt";
						MSG_CLEAR();
						ProjectData.ClearProjectError();
						num2 = 2;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select Sum(A.CR_AMT-A.DR_AMT) as BalAmt,SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) as GoldWt,sum(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END) ELSE 0 END) as SilverWt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' and A.LC_CODE = '" + tLcCode.Text + "'  AND A.AC_CODE = '00001' and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 1;
						AxMSFlexGrid mSG = MSG;
						mSG[DC_Main.i, 3] = "Opening Balance";
						mSG[DC_Main.i, 8] = "Opening Balance";
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["BalAmt"]);
							double num3 = DC_Main.Fnv(ref Value);
							dataRow["BalAmt"] = RuntimeHelpers.GetObjectValue(Value);
							if (num3 > 0.0)
							{
								AxMSFlexGrid obj = mSG;
								int i = DC_Main.i;
								Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["BalAmt"]);
								double num4 = DC_Main.Fnv(ref Value);
								dataRow["BalAmt"] = RuntimeHelpers.GetObjectValue(Value);
								obj[i, 9] = Strings.Format((object)num4, "0.00");
								mSG[DC_Main.i, 3] = "";
							}
							else
							{
								AxMSFlexGrid obj2 = mSG;
								int i2 = DC_Main.i;
								Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["BalAmt"]);
								double value = DC_Main.Fnv(ref Value);
								dataRow["BalAmt"] = RuntimeHelpers.GetObjectValue(Value);
								obj2[i2, 4] = Strings.Format((object)Math.Abs(value), "0.00");
								mSG[DC_Main.i, 8] = "";
							}
						}
						mSG.Row = DC_Main.i;
						int num5 = mSG.Cols - 1;
						DC_Main.i = 0;
						while (DC_Main.i <= num5)
						{
							mSG.Col = DC_Main.i;
							mSG.CellBackColor = Color.Moccasin;
							mSG.CellForeColor = Color.Blue;
							DC_Main.i++;
						}
						mSG.Rows += 1;
						mSG = null;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CR_AMT + DR_AMT <> 0  AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" ORDER BY VCH_TYPE,CO_BOOK,VCH_NO,LEDR_KEY"));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
							((Control)mToDt).Focus();
							((TextBoxBase)mToDt).SelectionStart = 0;
							((TextBoxBase)mToDt).SelectionLength = Strings.Len(mToDt.Text);
							goto end_IL_0001;
						}
						double num6 = 0.0;
						double num7 = 0.0;
						DC_Main.i = 2;
						DC_Main.X = 0;
						AxMSFlexGrid mSG2 = MSG;
						while (DC_Main.X < DC_Main.Rshlp.Rows.Count)
						{
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.X])["CR_AMT"]);
							double num8 = DC_Main.Fnv(ref Value);
							dataRow["CR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							if (num8 != 0.0)
							{
								mSG2[DC_Main.i, 0] = Conversions.ToString(DC_Main.i - 1);
								mSG2[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_TYPE"], (object)""));
								mSG2[DC_Main.i, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["CO_BOOK"], (object)""));
								mSG2[DC_Main.i, 11] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["BOOK_NAME"], (object)""));
								if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_NAME"], (object)""), (object)"", false))
								{
									mSG2[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_NAME"], (object)""));
								}
								else
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.X]["AC_CODE"]), (object)"'"));
									DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
									if (dataTable.Rows.Count > 0)
									{
										mSG2[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["AC_NAME"], (object)""));
									}
								}
								mSG2[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_NO"], (object)""));
								mSG2[DC_Main.i, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["CR_AMT"]), "0.00");
								mSG2[DC_Main.i, 14] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
								num7 += Conversion.Val(mSG2[DC_Main.i, 4]);
								DC_Main.i++;
								mSG2.Rows += 1;
							}
							DC_Main.X++;
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND DR_AMT <> 0 AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" ORDER BY VCH_TYPE,CO_BOOK,AC_CODE,VCH_NO"));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 2;
						DC_Main.X = 0;
						while (DC_Main.X < DC_Main.Rshlp.Rows.Count)
						{
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.X])["DR_AMT"]);
							double num9 = DC_Main.Fnv(ref Value);
							dataRow["DR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							if (num9 != 0.0)
							{
								mSG2[DC_Main.i, 5] = Conversions.ToString(DC_Main.i - 1);
								mSG2[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_TYPE"], (object)""));
								mSG2[DC_Main.i, 12] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["CO_BOOK"], (object)""));
								mSG2[DC_Main.i, 13] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["BOOK_NAME"], (object)""));
								if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_NAME"], (object)""), (object)"", false))
								{
									mSG2[DC_Main.i, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_NAME"], (object)""));
								}
								else
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.X]["AC_CODE"]), (object)"'"));
									DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
									if (dataTable.Rows.Count > 0)
									{
										mSG2[DC_Main.i, 8] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["AC_NAME"], (object)""));
									}
								}
								mSG2[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_NO"], (object)""));
								mSG2[DC_Main.i, 9] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["DR_AMT"]), "0.00");
								mSG2[DC_Main.i, 14] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
								num6 += Conversion.Val(mSG2[DC_Main.i, 9]);
								if (DC_Main.i == mSG2.Rows - 1)
								{
									mSG2.Rows += 1;
								}
								DC_Main.i++;
							}
							DC_Main.X++;
						}
						int num10 = mSG2.Rows - 1;
						DC_Main.R = 1;
						while (DC_Main.R <= num10)
						{
							if ((Operators.CompareString(mSG2[DC_Main.R, 0], "", false) == 0) & (Operators.CompareString(mSG2[DC_Main.R, 5], "", false) == 0))
							{
								num11++;
							}
							DC_Main.R++;
						}
						num11--;
						if (mSG2.Rows > 2)
						{
							mSG2.Rows -= num11;
						}
						mSG2.Rows += 2;
						DC_Main.i = mSG2.Rows - 1;
						mSG2[DC_Main.i, 3] = " Grand Total Jama :";
						mSG2[DC_Main.i, 8] = " Grand Total Udhar :";
						mSG2[DC_Main.i, 9] = Strings.Format((object)(num6 + Conversion.Val(mSG2[1, 9])), "0.00");
						mSG2[DC_Main.i, 4] = Strings.Format((object)(num7 + Conversion.Val(mSG2[1, 4])), "0.00");
						mSG2.Row = DC_Main.i;
						int num12 = mSG2.Cols - 1;
						DC_Main.i = 0;
						while (DC_Main.i <= num12)
						{
							mSG2.Col = DC_Main.i;
							mSG2.CellForeColor = Color.Blue;
							DC_Main.i++;
						}
						mSG2 = null;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt, Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'G' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'G' THEN -FINE_WT ELSE 0 END) END) As GoldWt ,Sum(CASE WHEN SIGN = '+' THEN (CASE WHEN IT_TYPE = 'S' THEN FINE_WT ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'S' THEN -FINE_WT ELSE 0 END) END) As SilverWt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND AC_CODE = '00001' and VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING (SUM(CR_AMT-DR_AMT) <> 0 or SUM(CASE WHEN SIGN = '+' THEN FINE_WT ELSE -FINE_WT END) <> 0)"));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						AxMSFlexGrid mSG3 = MSG;
						mSG3.Rows += 2;
						DC_Main.i = mSG3.Rows - 1;
						mSG3[DC_Main.i, 3] = "Closing Balance";
						mSG3[DC_Main.i, 8] = "Closing Balance";
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["BalAmt"]);
							double num13 = DC_Main.Fnv(ref Value);
							dataRow["BalAmt"] = RuntimeHelpers.GetObjectValue(Value);
							if (num13 > 0.0)
							{
								mSG3[DC_Main.i, 9] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00");
								mSG3[DC_Main.i, 3] = "";
							}
							else
							{
								AxMSFlexGrid obj3 = mSG3;
								int i3 = DC_Main.i;
								Type? typeFromHandle = typeof(Math);
								object[] obj4 = new object[1] { (dataRow = DC_Main.Rshlp.Rows[0])["BalAmt"] };
								object[] array = obj4;
								bool[] obj5 = new bool[1] { true };
								bool[] array2 = obj5;
								object obj6 = NewLateBinding.LateGet((object)null, typeFromHandle, "Abs", obj4, (string[])null, (Type[])null, obj5);
								if (array2[0])
								{
									dataRow["BalAmt"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
								}
								obj3[i3, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(obj6), "0.00");
								mSG3[DC_Main.i, 8] = "";
							}
						}
						mSG3.Row = DC_Main.i;
						int num14 = mSG3.Cols - 1;
						DC_Main.i = 0;
						while (DC_Main.i <= num14)
						{
							mSG3.Col = DC_Main.i;
							mSG3.CellBackColor = Color.Moccasin;
							mSG3.CellForeColor = Color.Blue;
							DC_Main.i++;
						}
						mSG3 = null;
						MSG.Col = 1;
						MSG.Row = 1;
						((Control)MSG).Focus();
						goto end_IL_0001;
					}
					case 4298:
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
			catch (object obj7) when (obj7 is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj7);
				try0001_dispatch = 4298;
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

	private void MSG_DblClick(object sender, EventArgs e)
	{
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		if (MSG.Col < 5)
		{
			DC_Main.RsQry = "SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_BOOK = '" + MSG[MSG.Row, 10] + "' ";
		}
		else
		{
			DC_Main.RsQry = "SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_BOOK = '" + MSG[MSG.Row, 12] + "' ";
		}
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count <= 0)
		{
			return;
		}
		DC_Main.CurBook = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["CO_BOOK"], (object)""));
		DC_Main.CurBookName = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_NAME"], (object)""));
		DC_Main.CurBookType = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_TYPE"], (object)""));
		DC_Main.CurBookItm = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["ITM_TYPE"], (object)""));
		DC_Main.CurBookMain = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["MAIN_BOOK"], (object)""));
		DC_Main.CurBookSname = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_SNAME"], (object)""));
		DC_Main.CurBookInOut = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_INOUT"], (object)""));
		DC_Main.MsUserRightForm = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["MENU_NAME"], (object)""));
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable2 = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (dataTable2.Rows.Count > 0 && Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable2.Rows[0]["FRM_VIEW"], (object)""), (object)"N", false))
		{
			DC_Main.MsUserRightForm = "";
			Interaction.MsgBox((object)"You Have No Rights...", (MsgBoxStyle)0, (object)null);
			return;
		}
		AxMSFlexGrid mSG = MSG;
		if (MSG.Col < 5)
		{
			DC_Main.CurBookVch = mSG[mSG.Row, 2];
		}
		else
		{
			DC_Main.CurBookVch = mSG[mSG.Row, 7];
		}
		if (Operators.CompareString(DC_Main.CurBookMain, "SALES ORDER", false) == 0)
		{
			TR_SALE_ORD tR_SALE_ORD = new TR_SALE_ORD();
			((Form)tR_SALE_ORD).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_ORD).Show();
			((Control)tR_SALE_ORD).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "Y", false) == 0)
			{
				TR_SALE_HM tR_SALE_HM = new TR_SALE_HM();
				((Form)tR_SALE_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_HM).Show();
				((Control)tR_SALE_HM).Focus();
			}
			else
			{
				TR_SALE tR_SALE = new TR_SALE();
				((Form)tR_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE).Show();
				((Control)tR_SALE).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "PURCHASE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "Y", false) == 0)
			{
				TR_PURC_HM tR_PURC_HM = new TR_PURC_HM();
				((Form)tR_PURC_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_PURC_HM).Show();
				((Control)tR_PURC_HM).Focus();
			}
			else
			{
				TR_PURC tR_PURC = new TR_PURC();
				((Form)tR_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_PURC).Show();
				((Control)tR_PURC).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "PURC RETURN", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				TR_SALE_RTN_UAE tR_SALE_RTN_UAE = new TR_SALE_RTN_UAE();
				((Form)tR_SALE_RTN_UAE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN_UAE).Show();
				((Control)tR_SALE_RTN_UAE).Focus();
			}
			else
			{
				TR_KR_ISU tR_KR_ISU = new TR_KR_ISU();
				((Form)tR_KR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_KR_ISU).Show();
				((Control)tR_KR_ISU).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "B2B SALES", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE).Show();
			((Control)tR_PR_SL_UAE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "B2B PURC", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE2 = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE2).Show();
			((Control)tR_PR_SL_UAE2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "HEDGING FIX", false) == 0)
		{
			TR_PR_SL_HEDG tR_PR_SL_HEDG = new TR_PR_SL_HEDG();
			((Form)tR_PR_SL_HEDG).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_HEDG).Show();
			((Control)tR_PR_SL_HEDG).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CASH REC", false) == 0)
		{
			TR_CASH tR_CASH = new TR_CASH();
			((Form)tR_CASH).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH).Show();
			((Control)tR_CASH).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CASH PAY", false) == 0)
		{
			TR_CASH tR_CASH2 = new TR_CASH();
			((Form)tR_CASH2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH2).Show();
			((Control)tR_CASH2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BANK REC", false) == 0)
		{
			TR_CASH tR_CASH3 = new TR_CASH();
			((Form)tR_CASH3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH3).Show();
			((Control)tR_CASH3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BANK PAY", false) == 0)
		{
			TR_CASH tR_CASH4 = new TR_CASH();
			((Form)tR_CASH4).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH4).Show();
			((Control)tR_CASH4).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "WH SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "RATE CUT", false) == 0))
		{
			TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
			((Form)tR_WH_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE).Show();
			((Control)tR_WH_SALE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CONTRA", false) == 0)
		{
			TR_CONTRA tR_CONTRA = new TR_CONTRA();
			((Form)tR_CONTRA).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CONTRA).Show();
			((Control)tR_CONTRA).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "FINE JV", false) == 0)
		{
			TR_CONTRA tR_CONTRA2 = new TR_CONTRA();
			((Form)tR_CONTRA2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CONTRA2).Show();
			((Control)tR_CONTRA2).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "KARIGAR ISSUE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MTL ISU", false) == 0))
		{
			TR_KR_ISU tR_KR_ISU2 = new TR_KR_ISU();
			((Form)tR_KR_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_KR_ISU2).Show();
			((Control)tR_KR_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "KARIGAR RECEIPT", false) == 0)
		{
			TR_PURC tR_PURC2 = new TR_PURC();
			((Form)tR_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC2).Show();
			((Control)tR_PURC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "ORDER CANCEL", false) == 0)
		{
			TR_SL_ORD_ADJ tR_SL_ORD_ADJ = new TR_SL_ORD_ADJ();
			((Form)tR_SL_ORD_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_ORD_ADJ).Show();
			((Control)tR_SL_ORD_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG WT CHANGE", false) == 0)
		{
			TR_TAG_WT_DIFF tR_TAG_WT_DIFF = new TR_TAG_WT_DIFF();
			((Form)tR_TAG_WT_DIFF).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_WT_DIFF).Show();
			((Control)tR_TAG_WT_DIFF).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "MEMB ENTRY", false) == 0)
		{
			TR_MEMB_ENT tR_MEMB_ENT = new TR_MEMB_ENT();
			((Form)tR_MEMB_ENT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_MEMB_ENT).Show();
			((Control)tR_MEMB_ENT).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "MEMB ADJUST", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MEMB GOLD ADJ", false) == 0))
		{
			TR_MEMB_ADJ tR_MEMB_ADJ = new TR_MEMB_ADJ();
			((Form)tR_MEMB_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_MEMB_ADJ).Show();
			((Control)tR_MEMB_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "DHIRAN ISSUE", false) == 0)
		{
			TR_DHRN_ISU tR_DHRN_ISU = new TR_DHRN_ISU();
			((Form)tR_DHRN_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_ISU).Show();
			((Control)tR_DHRN_ISU).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "DHIRAN RECEIVED", false) == 0)
		{
			TR_DHRN_REC tR_DHRN_REC = new TR_DHRN_REC();
			((Form)tR_DHRN_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_REC).Show();
			((Control)tR_DHRN_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "INTREST RECIVED", false) == 0)
		{
			TR_DHRN_INTREC tR_DHRN_INTREC = new TR_DHRN_INTREC();
			((Form)tR_DHRN_INTREC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_INTREC).Show();
			((Control)tR_DHRN_INTREC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LABOUR WORK", false) == 0)
		{
			TR_SALE_LBR tR_SALE_LBR = new TR_SALE_LBR();
			((Form)tR_SALE_LBR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_LBR).Show();
			((Control)tR_SALE_LBR).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES RETURNE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				TR_SALE_RTN_UAE tR_SALE_RTN_UAE2 = new TR_SALE_RTN_UAE();
				((Form)tR_SALE_RTN_UAE2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN_UAE2).Show();
				((Control)tR_SALE_RTN_UAE2).Focus();
			}
			else
			{
				TR_SALE_RTN tR_SALE_RTN = new TR_SALE_RTN();
				((Form)tR_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN).Show();
				((Control)tR_SALE_RTN).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN REC", false) == 0)
		{
			TR_DHRN_ISU tR_DHRN_ISU2 = new TR_DHRN_ISU();
			((Form)tR_DHRN_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_ISU2).Show();
			((Control)tR_DHRN_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN INT ENTRY", false) == 0)
		{
			TR_DHRN_INTREC tR_DHRN_INTREC2 = new TR_DHRN_INTREC();
			((Form)tR_DHRN_INTREC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_INTREC2).Show();
			((Control)tR_DHRN_INTREC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN ISSUE", false) == 0)
		{
			TR_DHRN_REC tR_DHRN_REC2 = new TR_DHRN_REC();
			((Form)tR_DHRN_REC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_REC2).Show();
			((Control)tR_DHRN_REC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OLD ITEM SALES", false) == 0)
		{
			TR_PURC tR_PURC3 = new TR_PURC();
			((Form)tR_PURC3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC3).Show();
			((Control)tR_PURC3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH EXP", false) == 0)
		{
			TR_OTH_PURC tR_OTH_PURC = new TR_OTH_PURC();
			((Form)tR_OTH_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_PURC).Show();
			((Control)tR_OTH_PURC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH INC", false) == 0)
		{
			TR_OTH_PURC tR_OTH_PURC2 = new TR_OTH_PURC();
			((Form)tR_OTH_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_PURC2).Show();
			((Control)tR_OTH_PURC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BILL REC", false) == 0)
		{
			TR_BILL_TO tR_BILL_TO = new TR_BILL_TO();
			((Form)tR_BILL_TO).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_BILL_TO).Show();
			((Control)tR_BILL_TO).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG TRFR", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN = new TR_TAG_CAN();
			((Form)tR_TAG_CAN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN).Show();
			((Control)tR_TAG_CAN).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "CUSTREP RECEIPT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "KRREP ISSUE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "KRREP RECEIPT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CUSTREP ISSUE", false) == 0))
		{
			TR_REP_REC tR_REP_REC = new TR_REP_REC();
			((Form)tR_REP_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_REP_REC).Show();
			((Control)tR_REP_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CON PUR", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE3 = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE3).Show();
			((Control)tR_PR_SL_UAE3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "EMP JV", false) == 0)
		{
			TR_EMP_JV tR_EMP_JV = new TR_EMP_JV();
			((Form)tR_EMP_JV).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_EMP_JV).Show();
			((Control)tR_EMP_JV).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "VP PARCEL", false) == 0)
		{
			TR_VP tR_VP = new TR_VP();
			((Form)tR_VP).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_VP).Show();
			((Control)tR_VP).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CARD ADJUST", false) == 0)
		{
			TR_CARD_REC tR_CARD_REC = new TR_CARD_REC();
			((Form)tR_CARD_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CARD_REC).Show();
			((Control)tR_CARD_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BUL WH SALE", false) == 0)
		{
			TR_BUL_SALE tR_BUL_SALE = new TR_BUL_SALE();
			((Form)tR_BUL_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_BUL_SALE).Show();
			((Control)tR_BUL_SALE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "E INVOICE", false) == 0)
		{
			TR_SL_EBILL tR_SL_EBILL = new TR_SL_EBILL();
			((Form)tR_SL_EBILL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_EBILL).Show();
			((Control)tR_SL_EBILL).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "GHAT REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FTNG ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FTNG REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CHEDIYA ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CHEDIYA REC", false) == 0))
		{
			TR_JDT_REC tR_JDT_REC = new TR_JDT_REC();
			((Form)tR_JDT_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_JDT_REC).Show();
			((Control)tR_JDT_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH COMM", false) == 0)
		{
			TR_OTH_COMM tR_OTH_COMM = new TR_OTH_COMM();
			((Form)tR_OTH_COMM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_COMM).Show();
			((Control)tR_OTH_COMM).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG SPLIT", false) == 0)
		{
			TR_TAG_SPLIT tR_TAG_SPLIT = new TR_TAG_SPLIT();
			((Form)tR_TAG_SPLIT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_SPLIT).Show();
			((Control)tR_TAG_SPLIT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TOUR SALES", false) == 0)
		{
			TR_TOUR_SALE tR_TOUR_SALE = new TR_TOUR_SALE();
			((Form)tR_TOUR_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TOUR_SALE).Show();
			((Control)tR_TOUR_SALE).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "AMT OUT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "AMT IN", false) == 0))
		{
			TR_LOCT_AMT tR_LOCT_AMT = new TR_LOCT_AMT();
			((Form)tR_LOCT_AMT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_LOCT_AMT).Show();
			((Control)tR_LOCT_AMT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG PURCHASE", false) == 0)
		{
			TR_PURC_HM tR_PURC_HM2 = new TR_PURC_HM();
			((Form)tR_PURC_HM2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC_HM2).Show();
			((Control)tR_PURC_HM2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "ITM LOT", false) == 0)
		{
			TR_ITM_LOT tR_ITM_LOT = new TR_ITM_LOT();
			((Form)tR_ITM_LOT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_ITM_LOT).Show();
			((Control)tR_ITM_LOT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LD ADJUST", false) == 0)
		{
			TR_LEDR_ADJ tR_LEDR_ADJ = new TR_LEDR_ADJ();
			((Form)tR_LEDR_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_LEDR_ADJ).Show();
			((Control)tR_LEDR_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "WH RTN", false) == 0)
		{
			TR_WH_SALE_RTN tR_WH_SALE_RTN = new TR_WH_SALE_RTN();
			((Form)tR_WH_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE_RTN).Show();
			((Control)tR_WH_SALE_RTN).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "FINE SALE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FINE PURC", false) == 0))
		{
			TR_FINE_SL_PR tR_FINE_SL_PR = new TR_FINE_SL_PR();
			((Form)tR_FINE_SL_PR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_FINE_SL_PR).Show();
			((Control)tR_FINE_SL_PR).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "ITEM SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "ITEM PURC", false) == 0))
		{
			TR_SL_PR_ITEM tR_SL_PR_ITEM = new TR_SL_PR_ITEM();
			((Form)tR_SL_PR_ITEM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_PR_ITEM).Show();
			((Control)tR_SL_PR_ITEM).Focus();
		}
		mSG = null;
	}

	private void RP_ROJMEL_Activated(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		if (((Control)DGV).Visible)
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK188NESD", false) != 0)
			{
				BtnDailyWork_Click(btnDailyWork, new EventArgs());
			}
		}
		else if (Operators.CompareString(RptType, "Sl", false) == 0)
		{
			BtnSilver_Click(BtnSilver, new EventArgs());
		}
		else if (Operators.CompareString(RptType, "Gl", false) == 0)
		{
			BtnGold_Click(BtnGold, new EventArgs());
		}
		else
		{
			BtnAmt_Click(BtnAmt, new EventArgs());
		}
		DC_Main.RsQry = "SELECT * FROM ROJMEL_BAL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			nClBal.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["CLOSING_CASH"])), "0.00");
		}
		else
		{
			nClBal.Text = "";
		}
	}

	private void BtnSilver_Click(object sender, EventArgs e)
	{
		//IL_0a44: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num6 = default(int);
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
						if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
						{
							DC_Main.SoftLoad();
						}
						((Control)DGV).Visible = false;
						((Control)TEXT_ENTRY).Visible = true;
						((Control)MSG).Visible = true;
						RptType = "Sl";
						MSG_CLEAR();
						double num3 = 0.0;
						double num4 = 0.0;
						ProjectData.ClearProjectError();
						num2 = 2;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND ITM_FINE <> 0 AND SIGN = '+' AND IT_TYPE = 'S' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 1;
						DC_Main.X = 0;
						AxMSFlexGrid mSG = MSG;
						while (DC_Main.X < DC_Main.Rshlp.Rows.Count)
						{
							if (Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[DC_Main.X]["SIGN"], (object)"+", false))
							{
								mSG[DC_Main.i, 0] = Conversions.ToString(DC_Main.i);
								mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_TYPE"], (object)""));
								mSG[DC_Main.i, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["CO_BOOK"], (object)""));
								mSG[DC_Main.i, 11] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["BOOK_NAME"], (object)""));
								if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_NAME"], (object)""), (object)"", false))
								{
									mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_NAME"], (object)""));
								}
								else
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.X]["AC_CODE"]), (object)"'"));
									DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
									if (dataTable.Rows.Count > 0)
									{
										mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["AC_NAME"], (object)""));
									}
								}
								mSG[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_NO"], (object)""));
								mSG[DC_Main.i, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["ITM_FINE"]), "0.000");
								mSG[DC_Main.i, 14] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
								num4 += Conversion.Val(mSG[DC_Main.i, 4]);
								DC_Main.i++;
								mSG.Rows += 1;
							}
							DC_Main.X++;
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND ITM_FINE <> 0 AND SIGN = '-' AND IT_TYPE = 'S' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)""));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 1;
						DC_Main.X = 0;
						while (DC_Main.X < DC_Main.Rshlp.Rows.Count)
						{
							if (Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[DC_Main.X]["SIGN"], (object)"-", false))
							{
								mSG[DC_Main.i, 5] = Conversions.ToString(DC_Main.i);
								mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_TYPE"], (object)""));
								mSG[DC_Main.i, 12] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["CO_BOOK"], (object)""));
								mSG[DC_Main.i, 13] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["BOOK_NAME"], (object)""));
								if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_NAME"], (object)""), (object)"", false))
								{
									mSG[DC_Main.i, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_NAME"], (object)""));
								}
								else
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.X]["AC_CODE"]), (object)"'"));
									DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
									if (dataTable.Rows.Count > 0)
									{
										mSG[DC_Main.i, 8] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["AC_NAME"], (object)""));
									}
								}
								mSG[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_NO"], (object)""));
								mSG[DC_Main.i, 9] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["ITM_FINE"]), "0.000");
								mSG[DC_Main.i, 14] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
								num3 += Conversion.Val(mSG[DC_Main.i, 9]);
								DC_Main.i++;
								mSG.Rows += 1;
							}
							DC_Main.X++;
						}
						int num5 = mSG.Rows - 1;
						DC_Main.R = 1;
						while (DC_Main.R <= num5)
						{
							if ((Operators.CompareString(mSG[DC_Main.R, 0], "", false) == 0) & (Operators.CompareString(mSG[DC_Main.R, 5], "", false) == 0))
							{
								num6++;
							}
							DC_Main.R++;
						}
						num6--;
						if (mSG.Rows > 2)
						{
							mSG.Rows -= num6;
						}
						mSG.Rows += 2;
						DC_Main.i = mSG.Rows - 1;
						mSG[DC_Main.i, 3] = " Grand Total Jama :";
						mSG[DC_Main.i, 8] = " Grand Total Udhar :";
						mSG[DC_Main.i, 9] = Strings.Format((object)num3, "0.000");
						mSG[DC_Main.i, 4] = Strings.Format((object)num4, "0.000");
						mSG.Row = DC_Main.i;
						int num7 = mSG.Cols - 1;
						DC_Main.i = 0;
						while (DC_Main.i <= num7)
						{
							mSG.Col = DC_Main.i;
							mSG.CellForeColor = Color.Blue;
							DC_Main.i++;
						}
						mSG = null;
						MSG.Col = 1;
						MSG.Row = 1;
						((Control)MSG).Focus();
						goto end_IL_0001;
					}
					case 2636:
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
				try0001_dispatch = 2636;
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

	private void BtnFirst_Click(object sender, EventArgs e)
	{
		mToDt.Text = Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(-1.0), "dd/MM/yyyy");
		BtnAmt_Click(BtnAmt, new EventArgs());
		DC_Main.RsQry = "SELECT * FROM ROJMEL_BAL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			nClBal.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["CLOSING_CASH"])), "0.00");
		}
		else
		{
			nClBal.Text = "";
		}
	}

	private void BtnLast_Click(object sender, EventArgs e)
	{
		mToDt.Text = Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(1.0), "dd/MM/yyyy");
		BtnAmt_Click(BtnAmt, new EventArgs());
		DC_Main.RsQry = "SELECT * FROM ROJMEL_BAL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			nClBal.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["CLOSING_CASH"])), "0.00");
		}
		else
		{
			nClBal.Text = "";
		}
	}

	private void RP_ROJMEL_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			if (MSG.Rows > 2)
			{
				CLEAR_DATA();
			}
			else
			{
				BtnExit_Click(BtnExit, new EventArgs());
			}
		}
	}

	private void MSG_Enter(object sender, EventArgs e)
	{
	}

	private void BtnGrPrint_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr[(short)5] = "";
			Cr[(short)6] = "";
			Cr[(short)7] = "";
			ItStk();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) AS AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AxCrystalReport cr = Cr;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
				cr[(short)1] = "OpenCashAmt = " + Strings.Format((object)num, "0.00");
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT ) AS DrMount,SUM(CR_AMT ) AS CrMount  From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AxCrystalReport cr2 = Cr;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["DrMount"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["DrMount"] = RuntimeHelpers.GetObjectValue(Value);
				cr2[(short)2] = ("RjDrAmt = " + Strings.Format((object)num2, "0.00")) ?? "";
				AxCrystalReport cr3 = Cr;
				Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["CRMount"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["CRMount"] = RuntimeHelpers.GetObjectValue(Value);
				cr3[(short)3] = ("RjCrAmt = " + Strings.Format((object)num3, "0.00")) ?? "";
			}
			else
			{
				Cr[(short)2] = "RjDrAmt = 0";
				Cr[(short)3] = "RjCrAmt = 0";
			}
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\RojMelGr.RPT";
			CurFormula = "{ROJ_MEL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {ROJ_MEL_DATA.LC_CODE} = '" + tLcCode.Text + "' AND {ROJ_MEL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {ROJ_MEL_DATA.VCH_DATE} = #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(DC_Main.MsDataType, "C", false) != 0)
			{
				CurFormula = CurFormula + " and {ROJ_MEL_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			Cr[(short)0] = "RptTitel = 'RojMel Report Date " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr[(short)4] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
			Cr[(short)5] = "DataType = '" + DC_Main.MsDataType + "'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			CurFormula = "";
		}
		else
		{
			ItStk();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) AS AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"AND VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.MsCrForName1 = "OpenCashAmt";
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.MsCrForVal1 = Strings.Format((object)num4, "0.00");
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT ) AS DrMount,SUM(CR_AMT ) AS CrMount  From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.MsCrForName2 = "RjDrAmt";
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["DrMount"]);
				double num5 = DC_Main.Fnv(ref Value);
				dataRow["DrMount"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.MsCrForVal2 = Strings.Format((object)num5, "0.00");
				DC_Main.MsCrForName3 = "RjCrAmt";
				Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["CRMount"]);
				double num6 = DC_Main.Fnv(ref Value);
				dataRow["CRMount"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.MsCrForVal3 = Strings.Format((object)num6, "0.00");
			}
			else
			{
				DC_Main.MsCrForName2 = "RjDrAmt";
				DC_Main.MsCrForVal2 = Conversions.ToString(0);
				DC_Main.MsCrForName3 = "RjCrAmt";
				DC_Main.MsCrForVal3 = Conversions.ToString(0);
			}
			CurFormula = "{ROJ_MEL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {ROJ_MEL_DATA.LC_CODE} = '" + tLcCode.Text + "' AND {ROJ_MEL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {ROJ_MEL_DATA.VCH_DATE} = #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(DC_Main.MsDataType, "C", false) != 0)
			{
				CurFormula = CurFormula + " and {ROJ_MEL_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'RojMel Report Date " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsCrForName4 = "FromDate";
			DC_Main.MsCrForStr4 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
			DC_Main.MsCrForName5 = "DataType";
			DC_Main.MsCrForStr5 = "'" + DC_Main.MsDataType + "'";
			DC_Main.RptName = "RojMelGr";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
	}

	private void btnCash_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr[(short)5] = "";
			Cr[(short)6] = "";
			Cr[(short)7] = "";
			ItStk();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) AS AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AxCrystalReport cr = Cr;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
				cr[(short)1] = "OpenCashAmt = " + Strings.Format((object)num, "0.00");
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT ) AS DrMount,SUM(CR_AMT ) AS CrMount  From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AxCrystalReport cr2 = Cr;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["DrMount"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["DrMount"] = RuntimeHelpers.GetObjectValue(Value);
				cr2[(short)2] = ("RjDrAmt = " + Strings.Format((object)num2, "0.00")) ?? "";
				AxCrystalReport cr3 = Cr;
				Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["CRMount"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["CRMount"] = RuntimeHelpers.GetObjectValue(Value);
				cr3[(short)3] = ("RjCrAmt = " + Strings.Format((object)num3, "0.00")) ?? "";
			}
			else
			{
				Cr[(short)2] = "RjDrAmt = 0";
				Cr[(short)3] = "RjCrAmt = 0";
			}
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\RojMelCash.RPT";
			CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.LC_CODE} = '" + tLcCode.Text + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.VCH_DATE} = #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			Cr[(short)0] = "RptTitel = 'RojMel Report Date " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr[(short)4] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
			Cr[(short)5] = "DataType = '" + DC_Main.MsDataType + "'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			CurFormula = "";
		}
		else
		{
			ItStk();
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) AS AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"AND VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.MsCrForName1 = "OpenCashAmt";
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.MsCrForVal1 = Strings.Format((object)num4, "0.00");
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT ) AS DrMount,SUM(CR_AMT ) AS CrMount  From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.MsCrForName2 = "RjDrAmt";
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["DrMount"]);
				double num5 = DC_Main.Fnv(ref Value);
				dataRow["DrMount"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.MsCrForVal2 = Strings.Format((object)num5, "0.00");
				DC_Main.MsCrForName3 = "RjCrAmt";
				Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["CRMount"]);
				double num6 = DC_Main.Fnv(ref Value);
				dataRow["CRMount"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.MsCrForVal3 = Strings.Format((object)num6, "0.00");
			}
			else
			{
				DC_Main.MsCrForName2 = "RjDrAmt";
				DC_Main.MsCrForVal2 = Conversions.ToString(0);
				DC_Main.MsCrForName3 = "RjCrAmt";
				DC_Main.MsCrForVal3 = Conversions.ToString(0);
			}
			CurFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.LC_CODE} = '" + tLcCode.Text + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.VCH_DATE} = #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(DC_Main.MsDataType, "C", false) != 0)
			{
				CurFormula = CurFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
			}
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'RojMel Report Date " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsCrForName4 = "FromDate";
			DC_Main.MsCrForStr4 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
			DC_Main.MsCrForName5 = "DataType";
			DC_Main.MsCrForStr5 = "'" + DC_Main.MsDataType + "'";
			DC_Main.RptName = "RojMelCash";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
	}

	private void MSG_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (!((mSG.Row == 0) | (mSG.CellWidth <= 0)) && MSG[MSG.Col] != 0)
			{
				((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
				((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
				((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
				((Control)TEXT_ENTRY).Height = (int)Math.Round((double)mSG.CellHeight / 15.0);
				((Control)TEXT_ENTRY).Visible = true;
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				((Control)TEXT_ENTRY).Enabled = false;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				mSG = null;
			}
		}
	}

	private void TEXT_ENTRY_DoubleClick(object sender, EventArgs e)
	{
		MSG_DblClick(MSG, new EventArgs());
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr[(short)5] = "";
			Cr[(short)6] = "";
			Cr[(short)7] = "";
		}
		DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.PARTY_AC_CODE,A.DATA_TYPE,B.BOOK_SNAME,SUM(CR_AMT) As CrAmt,SUM(DR_AMT) AS DrAmt,SUM(CASE WHEN SIGN = '+' AND IT_TYPE = 'G' THEN FINE_WT ELSE 0 END) AS CrFine,SUM(CASE WHEN SIGN = '-' AND IT_TYPE = 'G' THEN FINE_WT ELSE 0 END) AS DrFine ,  SUM(CASE WHEN SIGN = '+' AND IT_TYPE = 'S' THEN FINE_WT ELSE 0 END) AS CrSilver,SUM(CASE WHEN SIGN = '-' AND IT_TYPE = 'S' THEN FINE_WT ELSE 0 END) AS DrSilver  FROM AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + tLcCode.Text + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' and VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.PARTY_AC_CODE <> '' GROUP BY A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.PARTY_AC_CODE,A.DATA_TYPE,B.BOOK_SNAME ORDER BY A.CO_BOOK,A.VCH_NO,A.PARTY_AC_CODE "));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.X = 0;
		checked
		{
			while (DC_Main.X < dataTable.Rows.Count)
			{
				string text = "";
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT IT_DESC FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.X]["VCH_NO"]), (object)"' AND AC_CODE = '"), dataTable.Rows[DC_Main.X]["PARTY_AC_CODE"]), (object)"' AND IT_DESC <> ''"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_DESC"], (object)""));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.X]["VCH_NO"]), (object)"' ORDER BY SR_NO,ISR_NO"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					DC_Main.M = 0;
					while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
					{
						DataTable rshlp = DC_Main.Rshlp;
						if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(rshlp.Rows[DC_Main.M]["SR_NO"], (object)1, false), Operators.CompareObjectEqual(rshlp.Rows[DC_Main.M]["ISR_NO"], (object)1, false))))
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO TAG_STOCK_PRINT(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,BOOK_NAME,  IT_CODE,TAG_NO,VCH_SRNO,ITM_SIGN,ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,DATA_TYPE,  CR_AMT,DR_AMT,CR_GOLD,DR_GOLD,CR_SILVER,DR_SILVER,AC_CODE,IT_DESC)   Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,ISR_NO,VCH_DATE,'", dataTable.Rows[DC_Main.X]["BOOK_SNAME"]), (object)"','',BOOK_NAME, "), (object)" IT_CODE,TAG_NO,VCH_SRNO,ITM_SIGN,1,ITM_PCS,ITM_GWT,ITM_NWT,'"), dataTable.Rows[DC_Main.X]["DATA_TYPE"]), (object)"', "), (object)" "), dataTable.Rows[DC_Main.X]["CrAmt"]), (object)","), dataTable.Rows[DC_Main.X]["DrAmt"]), (object)","), dataTable.Rows[DC_Main.X]["CrFine"]), (object)","), dataTable.Rows[DC_Main.X]["DrFine"]), (object)","), dataTable.Rows[DC_Main.X]["CrSilver"]), (object)","), dataTable.Rows[DC_Main.X]["DrSilver"]), (object)",'"), dataTable.Rows[DC_Main.X]["PARTY_AC_CODE"]), (object)"','"), (object)text), (object)"' "), (object)" FROM MAIN_STOCK WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)tLcCode.Text), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  "), (object)" AND CO_BOOK ='"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = "), rshlp.Rows[DC_Main.M]["SR_NO"]), (object)" AND ISR_NO = "), rshlp.Rows[DC_Main.M]["ISR_NO"]), (object)""));
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						else
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO TAG_STOCK_PRINT(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,BOOK_NAME,  IT_CODE,TAG_NO,VCH_SRNO,ITM_SIGN,ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,DATA_TYPE,  DR_AMT,CR_AMT,DR_GOLD,CR_GOLD,DR_SILVER,CR_SILVER,AC_CODE,IT_DESC)   Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,ISR_NO,VCH_DATE,'", dataTable.Rows[DC_Main.X]["BOOK_SNAME"]), (object)"','',BOOK_NAME, "), (object)" IT_CODE,TAG_NO,VCH_SRNO,ITM_SIGN,1,ITM_PCS,ITM_GWT,ITM_NWT,'"), dataTable.Rows[DC_Main.X]["DATA_TYPE"]), (object)"', "), (object)" 0,0,0,0,0,0,'"), dataTable.Rows[DC_Main.X]["PARTY_AC_CODE"]), (object)"','' "), (object)" FROM MAIN_STOCK WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)tLcCode.Text), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  "), (object)" AND CO_BOOK ='"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = "), rshlp.Rows[DC_Main.M]["SR_NO"]), (object)" AND ISR_NO = "), rshlp.Rows[DC_Main.M]["ISR_NO"]), (object)""));
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						rshlp = null;
						DC_Main.M++;
					}
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_STOCK_PRINT(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,BOOK_NAME,  IT_CODE,TAG_NO,VCH_SRNO,ITM_SIGN,ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,DATA_TYPE,  CR_AMT,DR_AMT,CR_GOLD,DR_GOLD,CR_SILVER,DR_SILVER,AC_CODE,IT_DESC)   VALUES ('" + DC_Main.MCo_code + "','" + tLcCode.Text + "','" + DC_Main.MCo_year + "','"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"','"), dataTable.Rows[DC_Main.X]["VCH_NO"]), (object)"',1,'"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"','"), dataTable.Rows[DC_Main.X]["BOOK_SNAME"]), (object)"','','', "), (object)" '','',0,'',0,0,0,0,'"), dataTable.Rows[DC_Main.X]["DATA_TYPE"]), (object)"', "), (object)" "), dataTable.Rows[DC_Main.X]["CrAmt"]), (object)","), dataTable.Rows[DC_Main.X]["DrAmt"]), (object)","), dataTable.Rows[DC_Main.X]["CrFine"]), (object)","), dataTable.Rows[DC_Main.X]["DrFine"]), (object)","), dataTable.Rows[DC_Main.X]["CrSilver"]), (object)","), dataTable.Rows[DC_Main.X]["DrSilver"]), (object)",'"), dataTable.Rows[DC_Main.X]["PARTY_AC_CODE"]), (object)"','"), (object)text), (object)"') "));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.X++;
			}
			DC_Main.RsQry = "Select * FROM LEDR_AC_DATA";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) As AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					AxCrystalReport cr = Cr;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
					double num = DC_Main.Fnv(ref Value);
					dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
					cr[(short)1] = "OpenCashAmt = " + Strings.Format((object)num, "0.00");
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) AS AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					AxCrystalReport cr2 = Cr;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
					double num2 = DC_Main.Fnv(ref Value);
					dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
					cr2[(short)2] = "ClgCashAmt = " + Strings.Format((object)num2, "0.00");
				}
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\RojMelJmaUdhar.RPT";
				CurFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAG_STOCK_PRINT.LC_CODE} = '" + tLcCode.Text + "' AND {TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} = #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				if (Operators.CompareString(DC_Main.MsDataType, "C", false) != 0)
				{
					CurFormula = CurFormula + " and {TAG_STOCK_PRINT.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				Cr[(short)0] = "RptTitel = 'RojMel Report Date " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				Cr[(short)3] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
				Cr.SelectionFormula = CurFormula;
				Cr.Destination = (DestinationConstants)0;
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
				CurFormula = "";
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) AS AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"AND VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					DC_Main.MsCrForName1 = "OpenCashAmt";
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
					double num3 = DC_Main.Fnv(ref Value);
					dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.MsCrForVal1 = Strings.Format((object)num3, "0.00");
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(DR_AMT - CR_AMT) AS AMount From AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND AC_CODE = '00001' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					DC_Main.MsCrForName2 = "ClgCashAmt";
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[0])["Amount"]);
					double num4 = DC_Main.Fnv(ref Value);
					dataRow["Amount"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.MsCrForVal2 = Strings.Format((object)num4, "0.00");
				}
				CurFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAG_STOCK_PRINT.LC_CODE} = '" + tLcCode.Text + "' AND {TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} = #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
				if (Operators.CompareString(DC_Main.MsDataType, "C", false) != 0)
				{
					CurFormula = CurFormula + " and {TAG_STOCK_PRINT.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
				}
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'RojMel Report Date " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				DC_Main.MsCrForName4 = "FromDate";
				DC_Main.MsCrForStr4 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
				DC_Main.RptName = "RojMelJmaUdhar";
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptFormula = CurFormula;
				Module_Save.ShowReportPreview();
				CurFormula = "";
			}
		}
	}

	private void SimpleButton1_Click(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		object obj = default(object);
		int num5 = default(int);
		int num6 = default(int);
		object obj2 = default(object);
		object obj3 = default(object);
		int num7 = default(int);
		int num8 = default(int);
		int num9 = default(int);
		int num10 = default(int);
		int num11 = default(int);
		int num12 = default(int);
		ColorConverter colorConverter = default(ColorConverter);
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
						if (Operators.CompareString(UserPrint, "Y", false) != 0)
						{
							goto IL_001e;
						}
						goto IL_0034;
					case 1682:
						{
							num = num2;
							switch ((num3 <= -2) ? 1 : num3)
							{
							case 1:
								break;
							default:
								goto end_IL_0001;
							}
							int num4 = unchecked(num + 1);
							num = 0;
							switch (num4)
							{
							case 1:
								break;
							case 2:
								goto IL_001e;
							case 4:
							case 5:
								goto IL_0034;
							case 6:
								goto IL_004b;
							case 7:
								goto IL_007d;
							case 8:
								goto IL_00a5;
							case 9:
								goto IL_00ae;
							case 10:
								goto IL_00d6;
							case 11:
								goto IL_0109;
							case 12:
								goto IL_0120;
							case 13:
								goto IL_0137;
							case 14:
								goto IL_017f;
							case 15:
								goto IL_018e;
							case 16:
								goto IL_01ab;
							case 17:
								goto IL_01c5;
							case 18:
								goto IL_01e8;
							case 19:
							case 20:
								goto IL_023d;
							case 21:
								goto IL_024f;
							case 23:
								goto IL_0271;
							case 24:
								goto IL_028b;
							case 25:
								goto IL_02a2;
							case 26:
								goto IL_02eb;
							case 27:
								goto IL_02fa;
							case 22:
							case 28:
							case 29:
								goto IL_0316;
							case 30:
								goto IL_0320;
							case 31:
								goto IL_0373;
							case 32:
								goto IL_03c8;
							case 33:
								goto IL_0420;
							case 34:
								goto IL_048e;
							case 35:
								goto IL_04d1;
							case 36:
								goto IL_0500;
							case 37:
								goto IL_0543;
							case 38:
								goto IL_0584;
							case 39:
								goto IL_05a5;
							case 40:
								goto IL_05b3;
							case 41:
								goto IL_05b9;
							case 42:
								goto IL_05bf;
							case 43:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 44:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_02fa:
						num2 = 27;
						DC_Main.i++;
						goto IL_0309;
						IL_02a2:
						num2 = 25;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							MSG[DC_Main.i, num5]
						}, (string[])null, (Type[])null);
						goto IL_02eb;
						IL_02f4:
						if (num5 <= num6)
						{
							goto IL_02a2;
						}
						goto IL_02fa;
						IL_02eb:
						num2 = 26;
						num5++;
						goto IL_02f4;
						IL_001e:
						num2 = 2;
						Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001_3;
						IL_0034:
						num2 = 5;
						obj2 = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application", ""));
						goto IL_004b;
						IL_004b:
						num2 = 6;
						obj3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj2, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Add", new object[0], (string[])null, (Type[])null, (bool[])null));
						goto IL_007d;
						IL_007d:
						num2 = 7;
						obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj3, (Type)null, "Sheets", new object[1] { 1 }, (string[])null, (Type[])null, (bool[])null));
						goto IL_00a5;
						IL_00a5:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_00ae;
						IL_00ae:
						num2 = 9;
						obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj3, (Type)null, "Sheets", new object[1] { "sheet1" }, (string[])null, (Type[])null, (bool[])null));
						goto IL_00d6;
						IL_00d6:
						num2 = 10;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3] { 1, 1, "Sheet 1 content" }, (string[])null, (Type[])null);
						goto IL_0109;
						IL_0109:
						num2 = 11;
						if (((Control)DGV).Visible)
						{
							goto IL_0120;
						}
						goto IL_0271;
						IL_0120:
						num2 = 12;
						num7 = ((DataGridView)DGV).ColumnCount - 1;
						num8 = 0;
						goto IL_0188;
						IL_0188:
						if (num8 <= num7)
						{
							goto IL_0137;
						}
						goto IL_018e;
						IL_018e:
						num2 = 15;
						num9 = ((DataGridView)DGV).RowCount - 1;
						DC_Main.i = 0;
						goto IL_025e;
						IL_025e:
						if (DC_Main.i <= num9)
						{
							goto IL_01ab;
						}
						goto IL_0316;
						IL_01ab:
						num2 = 16;
						num10 = ((DataGridView)DGV).ColumnCount - 1;
						num11 = 0;
						goto IL_0246;
						IL_0246:
						if (num11 <= num10)
						{
							goto IL_01c5;
						}
						goto IL_024f;
						IL_024f:
						num2 = 21;
						DC_Main.i++;
						goto IL_025e;
						IL_01c5:
						num2 = 17;
						if (((DataGridView)DGV)[num11, DC_Main.i].Value != null)
						{
							goto IL_01e8;
						}
						goto IL_023d;
						IL_01e8:
						num2 = 18;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num11 + 1,
							((DataGridView)DGV)[num11, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_023d;
						IL_023d:
						num2 = 20;
						num11++;
						goto IL_0246;
						IL_0137:
						num2 = 13;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num8 + 1,
							((DataGridView)DGV).Columns[num8].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_017f;
						IL_017f:
						num2 = 14;
						num8++;
						goto IL_0188;
						IL_0271:
						num2 = 23;
						num12 = MSG.Rows - 1;
						DC_Main.i = 0;
						goto IL_0309;
						IL_0309:
						if (DC_Main.i <= num12)
						{
							goto IL_028b;
						}
						goto IL_0316;
						IL_0316:
						num2 = 29;
						colorConverter = new ColorConverter();
						goto IL_0320;
						IL_0320:
						num2 = 30;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_0373;
						IL_0373:
						num2 = 31;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_03c8;
						IL_03c8:
						num2 = 32;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_0420;
						IL_0420:
						num2 = 33;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_048e;
						IL_048e:
						num2 = 34;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_04d1;
						IL_04d1:
						num2 = 35;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0500;
						IL_0500:
						num2 = 36;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0543;
						IL_0543:
						num2 = 37;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0584;
						IL_0584:
						num2 = 38;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_05a5;
						IL_05a5:
						num2 = 39;
						Cursor.Current = Cursors.Default;
						goto IL_05b3;
						IL_05b3:
						num2 = 40;
						obj = null;
						goto IL_05b9;
						IL_05b9:
						num2 = 41;
						obj3 = null;
						goto IL_05bf;
						IL_05bf:
						num2 = 42;
						obj2 = null;
						break;
						IL_028b:
						num2 = 24;
						num6 = MSG.Cols - 1;
						num5 = 0;
						goto IL_02f4;
						end_IL_0001_2:
						break;
					}
					num2 = 43;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 1682;
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
		if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0 || Operators.CompareString(tLcCode.Text, DC_Main.MLc_code, false) != 0)
		{
			return;
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND CO_BOOK = '"), ((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells[25].Value), (object)""), (object)"' "));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count <= 0)
		{
			return;
		}
		DC_Main.CurBook = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["CO_BOOK"], (object)""));
		DC_Main.CurBookName = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_NAME"], (object)""));
		DC_Main.CurBookType = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_TYPE"], (object)""));
		DC_Main.CurBookItm = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["ITM_TYPE"], (object)""));
		DC_Main.CurBookMain = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["MAIN_BOOK"], (object)""));
		DC_Main.CurBookSname = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_SNAME"], (object)""));
		DC_Main.CurBookInOut = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_INOUT"], (object)""));
		DC_Main.MsUserRightForm = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["MENU_NAME"], (object)""));
		DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells[2].Value, (object)""));
		if (Operators.CompareString(DC_Main.CurBookMain, "SALES ORDER", false) == 0)
		{
			TR_SALE_ORD tR_SALE_ORD = new TR_SALE_ORD();
			((Form)tR_SALE_ORD).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_ORD).Show();
			((Control)tR_SALE_ORD).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "Y", false) == 0)
			{
				TR_SALE_HM tR_SALE_HM = new TR_SALE_HM();
				((Form)tR_SALE_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_HM).Show();
				((Control)tR_SALE_HM).Focus();
			}
			else
			{
				TR_SALE tR_SALE = new TR_SALE();
				((Form)tR_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE).Show();
				((Control)tR_SALE).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "PURCHASE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "Y", false) == 0)
			{
				TR_PURC_HM tR_PURC_HM = new TR_PURC_HM();
				((Form)tR_PURC_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_PURC_HM).Show();
				((Control)tR_PURC_HM).Focus();
			}
			else
			{
				TR_PURC tR_PURC = new TR_PURC();
				((Form)tR_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_PURC).Show();
				((Control)tR_PURC).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "PURC RETURN", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				TR_SALE_RTN_UAE tR_SALE_RTN_UAE = new TR_SALE_RTN_UAE();
				((Form)tR_SALE_RTN_UAE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN_UAE).Show();
				((Control)tR_SALE_RTN_UAE).Focus();
			}
			else
			{
				TR_KR_ISU tR_KR_ISU = new TR_KR_ISU();
				((Form)tR_KR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_KR_ISU).Show();
				((Control)tR_KR_ISU).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "B2B SALES", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE).Show();
			((Control)tR_PR_SL_UAE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "B2B PURC", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE2 = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE2).Show();
			((Control)tR_PR_SL_UAE2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "HEDGING FIX", false) == 0)
		{
			TR_PR_SL_HEDG tR_PR_SL_HEDG = new TR_PR_SL_HEDG();
			((Form)tR_PR_SL_HEDG).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_HEDG).Show();
			((Control)tR_PR_SL_HEDG).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CASH REC", false) == 0)
		{
			TR_CASH tR_CASH = new TR_CASH();
			((Form)tR_CASH).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH).Show();
			((Control)tR_CASH).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CASH PAY", false) == 0)
		{
			TR_CASH tR_CASH2 = new TR_CASH();
			((Form)tR_CASH2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH2).Show();
			((Control)tR_CASH2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BANK REC", false) == 0)
		{
			TR_CASH tR_CASH3 = new TR_CASH();
			((Form)tR_CASH3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH3).Show();
			((Control)tR_CASH3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BANK PAY", false) == 0)
		{
			TR_CASH tR_CASH4 = new TR_CASH();
			((Form)tR_CASH4).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH4).Show();
			((Control)tR_CASH4).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "WH SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "RATE CUT", false) == 0))
		{
			TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
			((Form)tR_WH_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE).Show();
			((Control)tR_WH_SALE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CONTRA", false) == 0)
		{
			TR_CONTRA tR_CONTRA = new TR_CONTRA();
			((Form)tR_CONTRA).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CONTRA).Show();
			((Control)tR_CONTRA).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "FINE JV", false) == 0)
		{
			TR_CONTRA tR_CONTRA2 = new TR_CONTRA();
			((Form)tR_CONTRA2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CONTRA2).Show();
			((Control)tR_CONTRA2).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "KARIGAR ISSUE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MTL ISU", false) == 0))
		{
			TR_KR_ISU tR_KR_ISU2 = new TR_KR_ISU();
			((Form)tR_KR_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_KR_ISU2).Show();
			((Control)tR_KR_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "KARIGAR RECEIPT", false) == 0)
		{
			TR_PURC tR_PURC2 = new TR_PURC();
			((Form)tR_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC2).Show();
			((Control)tR_PURC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "ORDER CANCEL", false) == 0)
		{
			TR_SL_ORD_ADJ tR_SL_ORD_ADJ = new TR_SL_ORD_ADJ();
			((Form)tR_SL_ORD_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_ORD_ADJ).Show();
			((Control)tR_SL_ORD_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG WT CHANGE", false) == 0)
		{
			TR_TAG_WT_DIFF tR_TAG_WT_DIFF = new TR_TAG_WT_DIFF();
			((Form)tR_TAG_WT_DIFF).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_WT_DIFF).Show();
			((Control)tR_TAG_WT_DIFF).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "MEMB ENTRY", false) == 0)
		{
			TR_MEMB_ENT tR_MEMB_ENT = new TR_MEMB_ENT();
			((Form)tR_MEMB_ENT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_MEMB_ENT).Show();
			((Control)tR_MEMB_ENT).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "MEMB ADJUST", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MEMB GOLD ADJ", false) == 0))
		{
			TR_MEMB_ADJ tR_MEMB_ADJ = new TR_MEMB_ADJ();
			((Form)tR_MEMB_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_MEMB_ADJ).Show();
			((Control)tR_MEMB_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "DHIRAN ISSUE", false) == 0)
		{
			TR_DHRN_ISU tR_DHRN_ISU = new TR_DHRN_ISU();
			((Form)tR_DHRN_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_ISU).Show();
			((Control)tR_DHRN_ISU).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "DHIRAN RECEIVED", false) == 0)
		{
			TR_DHRN_REC tR_DHRN_REC = new TR_DHRN_REC();
			((Form)tR_DHRN_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_REC).Show();
			((Control)tR_DHRN_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "INTREST RECIVED", false) == 0)
		{
			TR_DHRN_INTREC tR_DHRN_INTREC = new TR_DHRN_INTREC();
			((Form)tR_DHRN_INTREC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_INTREC).Show();
			((Control)tR_DHRN_INTREC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LABOUR WORK", false) == 0)
		{
			TR_SALE_LBR tR_SALE_LBR = new TR_SALE_LBR();
			((Form)tR_SALE_LBR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_LBR).Show();
			((Control)tR_SALE_LBR).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES RETURNE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				TR_SALE_RTN_UAE tR_SALE_RTN_UAE2 = new TR_SALE_RTN_UAE();
				((Form)tR_SALE_RTN_UAE2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN_UAE2).Show();
				((Control)tR_SALE_RTN_UAE2).Focus();
			}
			else
			{
				TR_SALE_RTN tR_SALE_RTN = new TR_SALE_RTN();
				((Form)tR_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN).Show();
				((Control)tR_SALE_RTN).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN REC", false) == 0)
		{
			TR_DHRN_ISU tR_DHRN_ISU2 = new TR_DHRN_ISU();
			((Form)tR_DHRN_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_ISU2).Show();
			((Control)tR_DHRN_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN INT ENTRY", false) == 0)
		{
			TR_DHRN_INTREC tR_DHRN_INTREC2 = new TR_DHRN_INTREC();
			((Form)tR_DHRN_INTREC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_INTREC2).Show();
			((Control)tR_DHRN_INTREC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN ISSUE", false) == 0)
		{
			TR_DHRN_REC tR_DHRN_REC2 = new TR_DHRN_REC();
			((Form)tR_DHRN_REC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_REC2).Show();
			((Control)tR_DHRN_REC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OLD ITEM SALES", false) == 0)
		{
			TR_PURC tR_PURC3 = new TR_PURC();
			((Form)tR_PURC3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC3).Show();
			((Control)tR_PURC3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH EXP", false) == 0)
		{
			TR_OTH_PURC tR_OTH_PURC = new TR_OTH_PURC();
			((Form)tR_OTH_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_PURC).Show();
			((Control)tR_OTH_PURC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH INC", false) == 0)
		{
			TR_OTH_PURC tR_OTH_PURC2 = new TR_OTH_PURC();
			((Form)tR_OTH_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_PURC2).Show();
			((Control)tR_OTH_PURC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BILL REC", false) == 0)
		{
			TR_BILL_TO tR_BILL_TO = new TR_BILL_TO();
			((Form)tR_BILL_TO).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_BILL_TO).Show();
			((Control)tR_BILL_TO).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG TRFR", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN = new TR_TAG_CAN();
			((Form)tR_TAG_CAN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN).Show();
			((Control)tR_TAG_CAN).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "CUSTREP RECEIPT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "KRREP ISSUE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "KRREP RECEIPT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CUSTREP ISSUE", false) == 0))
		{
			TR_REP_REC tR_REP_REC = new TR_REP_REC();
			((Form)tR_REP_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_REP_REC).Show();
			((Control)tR_REP_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CON PUR", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE3 = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE3).Show();
			((Control)tR_PR_SL_UAE3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "EMP JV", false) == 0)
		{
			TR_EMP_JV tR_EMP_JV = new TR_EMP_JV();
			((Form)tR_EMP_JV).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_EMP_JV).Show();
			((Control)tR_EMP_JV).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "VP PARCEL", false) == 0)
		{
			TR_VP tR_VP = new TR_VP();
			((Form)tR_VP).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_VP).Show();
			((Control)tR_VP).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CARD ADJUST", false) == 0)
		{
			TR_CARD_REC tR_CARD_REC = new TR_CARD_REC();
			((Form)tR_CARD_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CARD_REC).Show();
			((Control)tR_CARD_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BUL WH SALE", false) == 0)
		{
			TR_BUL_SALE tR_BUL_SALE = new TR_BUL_SALE();
			((Form)tR_BUL_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_BUL_SALE).Show();
			((Control)tR_BUL_SALE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "E INVOICE", false) == 0)
		{
			TR_SL_EBILL tR_SL_EBILL = new TR_SL_EBILL();
			((Form)tR_SL_EBILL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_EBILL).Show();
			((Control)tR_SL_EBILL).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "GHAT REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FTNG ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FTNG REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CHEDIYA ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CHEDIYA REC", false) == 0))
		{
			TR_JDT_REC tR_JDT_REC = new TR_JDT_REC();
			((Form)tR_JDT_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_JDT_REC).Show();
			((Control)tR_JDT_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH COMM", false) == 0)
		{
			TR_OTH_COMM tR_OTH_COMM = new TR_OTH_COMM();
			((Form)tR_OTH_COMM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_COMM).Show();
			((Control)tR_OTH_COMM).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG SPLIT", false) == 0)
		{
			TR_TAG_SPLIT tR_TAG_SPLIT = new TR_TAG_SPLIT();
			((Form)tR_TAG_SPLIT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_SPLIT).Show();
			((Control)tR_TAG_SPLIT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TOUR SALES", false) == 0)
		{
			TR_TOUR_SALE tR_TOUR_SALE = new TR_TOUR_SALE();
			((Form)tR_TOUR_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TOUR_SALE).Show();
			((Control)tR_TOUR_SALE).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "AMT OUT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "AMT IN", false) == 0))
		{
			TR_LOCT_AMT tR_LOCT_AMT = new TR_LOCT_AMT();
			((Form)tR_LOCT_AMT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_LOCT_AMT).Show();
			((Control)tR_LOCT_AMT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG PURCHASE", false) == 0)
		{
			TR_PURC_HM tR_PURC_HM2 = new TR_PURC_HM();
			((Form)tR_PURC_HM2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC_HM2).Show();
			((Control)tR_PURC_HM2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "ITM LOT", false) == 0)
		{
			TR_ITM_LOT tR_ITM_LOT = new TR_ITM_LOT();
			((Form)tR_ITM_LOT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_ITM_LOT).Show();
			((Control)tR_ITM_LOT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LD ADJUST", false) == 0)
		{
			TR_LEDR_ADJ tR_LEDR_ADJ = new TR_LEDR_ADJ();
			((Form)tR_LEDR_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_LEDR_ADJ).Show();
			((Control)tR_LEDR_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "WH RTN", false) == 0)
		{
			TR_WH_SALE_RTN tR_WH_SALE_RTN = new TR_WH_SALE_RTN();
			((Form)tR_WH_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE_RTN).Show();
			((Control)tR_WH_SALE_RTN).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "FINE SALE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FINE PURC", false) == 0))
		{
			TR_FINE_SL_PR tR_FINE_SL_PR = new TR_FINE_SL_PR();
			((Form)tR_FINE_SL_PR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_FINE_SL_PR).Show();
			((Control)tR_FINE_SL_PR).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "ITEM SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "ITEM PURC", false) == 0))
		{
			TR_SL_PR_ITEM tR_SL_PR_ITEM = new TR_SL_PR_ITEM();
			((Form)tR_SL_PR_ITEM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_PR_ITEM).Show();
			((Control)tR_SL_PR_ITEM).Focus();
		}
	}

	private void btnBalSave_Click(object sender, EventArgs e)
	{
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "DELETE FROM ROJMEL_BAL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "INSERT INTO ROJMEL_BAL (CO_CODE,LC_CODE,VCH_DATE,CLOSING_CASH,MAIN_USER) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'," + Conversions.ToString(Conversion.Val(nClBal.Text)) + ",'" + DC_Main.MCo_User + "')";
		DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
	}

	private void nClBal_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)btnBalSave).Focus();
		}
	}
}
