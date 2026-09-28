using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
using Crystal;
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
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_USER : Form
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
	[AccessedThroughProperty("BtnSave")]
	private SimpleButton _BtnSave;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DETL")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_DETL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnList")]
	private QButton _BtnList;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboUser")]
	private ComboBox _cboUser;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBookCode")]
	private TextBox _tBookCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnExel")]
	private SimpleButton _btnExel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAll")]
	private QButton _btnAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnItCancel")]
	private QButton _btnItCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOk")]
	private QButton _btnOk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkItmlist")]
	private CheckBox _chkItmlist;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsAcSum;

	private double ColCon;

	private string CurRpt;

	private string SelectIt;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int cSrNo = 0;

	private const int cUser = 1;

	private const int cBookSname = 2;

	private const int cVchDate = 3;

	private const int cVchNo = 4;

	private const int cAcName = 5;

	private const int cItCode = 6;

	private const int cItPcs = 7;

	private const int cItmGwt = 8;

	private const int cItmNwt = 9;

	private const int cGhtPrc = 10;

	private const int cItFine = 11;

	private const int cItRate = 12;

	private const int cItAmt = 13;

	private const int cLbrRate = 14;

	private const int clbrAmt = 15;

	private const int cOthAmt = 16;

	private const int cDrAmt = 17;

	private const int cCrAmt = 18;

	private const int cDrFine = 19;

	private const int cCrFine = 20;

	private const int cDrSilver = 21;

	private const int cCrSilver = 22;

	private const int cTaxAmt = 23;

	private const int cCashRec = 24;

	private const int cBankRec = 25;

	private const int cUpiAmt = 26;

	private const int cCardRec = 27;

	private const int cOrdAdjAmt = 28;

	private const int cOldGlAmt = 29;

	private const int cOldSlAmt = 30;

	private const int cSchmAdj = 31;

	private const int cKasar = 32;

	private const int cCashPaid = 33;

	private const int cMobile = 34;

	private const int cAcCode = 35;

	private const int cCoBook = 36;

	private const int cMainBook = 37;

	private const int cUSrNo = 0;

	private const int cUBook = 1;

	private const int cUBookName = 2;

	private const int cUVchNo = 3;

	private const int cUVchDate = 4;

	private const int cUEdtDate = 5;

	private const int cUEntryTime = 6;

	private const int cUColName = 7;

	private const int cUOldVal = 8;

	private const int cUNewVal = 9;

	private const int cUAcName = 10;

	private const int cUMainUser = 11;

	private const int cUEditUser = 12;

	private const int cUEntryChk = 13;

	private const int cUMainBook = 14;

	private const int cUAcCode = 15;

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
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_DETL
	{
		[CompilerGenerated]
		get
		{
			return _DGV_DETL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_DETL_CellFormatting);
			EventHandler eventHandler = DGV_DETL_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val2 = _DGV_DETL;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV_DETL = value;
			val2 = _DGV_DETL;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting += val;
				((Control)val2).DoubleClick += eventHandler;
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

	internal virtual QButton BtnList
	{
		[CompilerGenerated]
		get
		{
			return _BtnList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnList_Click;
			QButton val = _BtnList;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnList = value;
			val = _BtnList;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mFromDt_KeyDown);
			EventHandler eventHandler = mFromDt_GotFocus;
			MaskedTextBox val2 = _mFromDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_mFromDt = value;
			val2 = _mFromDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
			}
		}
	}

	internal virtual ComboBox cboUser
	{
		[CompilerGenerated]
		get
		{
			return _cboUser;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboUser_KeyDown);
			ComboBox val2 = _cboUser;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboUser = value;
			val2 = _cboUser;
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

	internal virtual TextBox tBookCode
	{
		[CompilerGenerated]
		get
		{
			return _tBookCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBookCode_KeyDown);
			TextBox val2 = _tBookCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBookCode = value;
			val2 = _tBookCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label5")]
	private virtual Label _Label5;

	internal virtual Label Label5
	{
		get
		{
			return _Label5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label5 = value;
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
			EventHandler eventHandler = btnExel_Click;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkPandingEntry")]
	private virtual CheckBox _chkPandingEntry;

	internal virtual CheckBox chkPandingEntry
	{
		get
		{
			return _chkPandingEntry;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkPandingEntry = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlIt")]
	private virtual Panel _PnlIt;

	internal virtual Panel PnlIt
	{
		get
		{
			return _PnlIt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlIt = value;
		}
	}

	internal virtual QButton btnAll
	{
		[CompilerGenerated]
		get
		{
			return _btnAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnAll_Click;
			QButton val = _btnAll;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAll = value;
			val = _btnAll;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnItCancel
	{
		[CompilerGenerated]
		get
		{
			return _btnItCancel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnItCancel_Click;
			QButton val = _btnItCancel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnItCancel = value;
			val = _btnItCancel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnOk
	{
		[CompilerGenerated]
		get
		{
			return _btnOk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnOk_Click;
			QButton val = _btnOk;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOk = value;
			val = _btnOk;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_ITM")]
	private virtual DevComponents.DotNetBar.Controls.DataGridViewX _DGV_ITM;

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_ITM
	{
		get
		{
			return _DGV_ITM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DGV_ITM = value;
		}
	}

	internal virtual CheckBox chkItmlist
	{
		[CompilerGenerated]
		get
		{
			return _chkItmlist;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkItmlist_Click;
			CheckBox val = _chkItmlist;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_chkItmlist = value;
			val = _chkItmlist;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public int newindex { get; set; }

	public RP_USER()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += RP_USER_Load;
		((Form)this).Activated += RP_USER_Activated;
		((Form)this).Deactivate += RP_USER_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_USER_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_USER_KeyDown);
		((Form)this).Closed += RP_USER_Closed;
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
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Expected O, but got Unknown
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Expected O, but got Unknown
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Expected O, but got Unknown
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Expected O, but got Unknown
		//IL_06aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b4: Expected O, but got Unknown
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_0721: Expected O, but got Unknown
		//IL_07ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d4: Expected O, but got Unknown
		//IL_0837: Unknown result type (might be due to invalid IL or missing references)
		//IL_0841: Expected O, but got Unknown
		//IL_08ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f4: Expected O, but got Unknown
		//IL_0957: Unknown result type (might be due to invalid IL or missing references)
		//IL_0961: Expected O, but got Unknown
		//IL_0a3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a46: Expected O, but got Unknown
		//IL_0ab4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abe: Expected O, but got Unknown
		//IL_0b6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b77: Expected O, but got Unknown
		//IL_0bf1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfb: Expected O, but got Unknown
		//IL_0c7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c89: Expected O, but got Unknown
		//IL_0d57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d61: Expected O, but got Unknown
		//IL_0df6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e00: Expected O, but got Unknown
		//IL_0e7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e88: Expected O, but got Unknown
		//IL_0f6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f74: Expected O, but got Unknown
		//IL_0fdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe7: Expected O, but got Unknown
		//IL_108d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1097: Expected O, but got Unknown
		//IL_131b: Unknown result type (might be due to invalid IL or missing references)
		//IL_133f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1363: Unknown result type (might be due to invalid IL or missing references)
		//IL_1387: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ba: Expected O, but got Unknown
		//IL_13dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_143c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1446: Expected O, but got Unknown
		//IL_14f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fe: Expected O, but got Unknown
		//IL_159e: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a8: Expected O, but got Unknown
		//IL_1614: Unknown result type (might be due to invalid IL or missing references)
		//IL_161e: Expected O, but got Unknown
		//IL_16cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d9: Expected O, but got Unknown
		//IL_1756: Unknown result type (might be due to invalid IL or missing references)
		//IL_1760: Expected O, but got Unknown
		//IL_1830: Unknown result type (might be due to invalid IL or missing references)
		//IL_183a: Expected O, but got Unknown
		//IL_18d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e0: Expected O, but got Unknown
		//IL_1966: Unknown result type (might be due to invalid IL or missing references)
		//IL_1970: Expected O, but got Unknown
		//IL_1a4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a54: Expected O, but got Unknown
		//IL_1abd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac7: Expected O, but got Unknown
		//IL_1ba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1baa: Expected O, but got Unknown
		//IL_1f3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f63: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f87: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fab: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fde: Expected O, but got Unknown
		//IL_2001: Unknown result type (might be due to invalid IL or missing references)
		//IL_2265: Unknown result type (might be due to invalid IL or missing references)
		//IL_2289: Unknown result type (might be due to invalid IL or missing references)
		//IL_22ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_22d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_22fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2304: Expected O, but got Unknown
		//IL_232a: Unknown result type (might be due to invalid IL or missing references)
		//IL_258e: Unknown result type (might be due to invalid IL or missing references)
		//IL_25b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_25d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_25fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2623: Unknown result type (might be due to invalid IL or missing references)
		//IL_262d: Expected O, but got Unknown
		//IL_2653: Unknown result type (might be due to invalid IL or missing references)
		//IL_26e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_26f3: Expected O, but got Unknown
		//IL_278f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2799: Expected O, but got Unknown
		//IL_281f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2829: Expected O, but got Unknown
		//IL_2903: Unknown result type (might be due to invalid IL or missing references)
		//IL_290d: Expected O, but got Unknown
		//IL_2976: Unknown result type (might be due to invalid IL or missing references)
		//IL_2980: Expected O, but got Unknown
		//IL_2a33: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a3d: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_USER));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		DataGridViewCellStyle val7 = new DataGridViewCellStyle();
		DataGridViewCellStyle val8 = new DataGridViewCellStyle();
		DataGridViewCellStyle val9 = new DataGridViewCellStyle();
		DataGridViewCellStyle val10 = new DataGridViewCellStyle();
		DataGridViewCellStyle val11 = new DataGridViewCellStyle();
		DataGridViewCellStyle val12 = new DataGridViewCellStyle();
		DataGridViewCellStyle val13 = new DataGridViewCellStyle();
		DataGridViewCellStyle val14 = new DataGridViewCellStyle();
		DataGridViewCellStyle val15 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		btnExel = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label2 = new Label();
		DGV_DETL = new DevComponents.DotNetBar.Controls.DataGridViewX();
		mToDt = new MaskedTextBox();
		BtnList = new QButton();
		Label1 = new Label();
		mFromDt = new MaskedTextBox();
		cboUser = new ComboBox();
		Label3 = new Label();
		tBookCode = new TextBox();
		Label5 = new Label();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		chkPandingEntry = new CheckBox();
		PnlIt = new Panel();
		btnAll = new QButton();
		btnItCancel = new QButton();
		btnOk = new QButton();
		DGV_ITM = new DevComponents.DotNetBar.Controls.DataGridViewX();
		chkItmlist = new CheckBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((Control)PnlIt).SuspendLayout();
		((ISupportInitialize)DGV_ITM).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)btnExel);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 6;
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
		((Control)BtnExit).TabIndex = 7;
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
		((Control)BtnDelete).TabIndex = 6;
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
		((Control)BtnCancel).TabIndex = 5;
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
		((Control)BtnSave).TabIndex = 4;
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
		((Control)BtnPrint).TabIndex = 3;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnExel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnExel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnExel).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnExel).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnExel.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnExel.ImageOptions.SvgImage");
		((Control)btnExel).Location = new Point(730, 3);
		((BaseControl)btnExel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnExel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnExel).Name = "btnExel";
		((Control)btnExel).Size = new Size(91, 37);
		((Control)btnExel).TabIndex = 8;
		btnExel.Text = "&Excel";
		((BaseButton)btnExel).ToolTipAnchor = (ToolTipAnchor)1;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1247, 476);
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
		lblBook.Text = "User Work Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(482, 45);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(66, 22);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f);
		((Control)tAcName).Location = new Point(553, 45);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(213, 23);
		((Control)tAcName).TabIndex = 1129;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(412, 44);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(64, 20);
		((Control)Label2).TabIndex = 1132;
		Label2.Text = "Ac Code";
		Label2.TextAlign = (ContentAlignment)64;
		((DataGridView)DGV_DETL).AllowUserToAddRows = false;
		((DataGridView)DGV_DETL).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DETL).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV_DETL).BackgroundColor = Color.Snow;
		((DataGridView)DGV_DETL).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DETL).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV_DETL).ColumnHeadersHeight = 30;
		((DataGridView)DGV_DETL).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).DefaultCellStyle = val3;
		((DataGridView)DGV_DETL).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_DETL).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_DETL).Location = new Point(13, 82);
		((Control)DGV_DETL).Name = "DGV_DETL";
		DGV_DETL.PaintEnhancedSelection = false;
		((DataGridView)DGV_DETL).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_DETL).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_DETL).RowHeadersVisible = false;
		((DataGridView)DGV_DETL).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_DETL).RowsDefaultCellStyle = val5;
		DGV_DETL.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_DETL.SelectAllSignVisible = false;
		((DataGridView)DGV_DETL).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_DETL).Size = new Size(1159, 473);
		((DataGridView)DGV_DETL).StandardTab = true;
		((Control)DGV_DETL).TabIndex = 1133;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(144, 45);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((QControl)BtnList).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnList).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnList).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnList).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnList).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnList).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnList).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnList).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnList).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnList).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnList).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnList).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnList).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnList).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnList.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnList.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnList.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnList.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnList.Image = null;
		((QControl)BtnList).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnList).Location = new Point(1067, 41);
		((Control)BtnList).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnList).Name = "BtnList";
		((Control)BtnList).Size = new Size(70, 33);
		((Control)BtnList).TabIndex = 5;
		BtnList.Text = "Ok";
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(10, 44);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(44, 20);
		((Control)Label1).TabIndex = 1167;
		Label1.Text = "Date";
		Label1.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(60, 45);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		cboUser.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboUser).Font = new Font("Tahoma", 9f);
		((ListControl)cboUser).FormattingEnabled = true;
		((Control)cboUser).Location = new Point(278, 45);
		((Control)cboUser).Name = "cboUser";
		((Control)cboUser).Size = new Size(128, 22);
		((Control)cboUser).TabIndex = 2;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(227, 46);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(47, 20);
		((Control)Label3).TabIndex = 1169;
		Label3.Text = "User";
		Label3.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tBookCode).BackColor = Color.White;
		((Control)tBookCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookCode).Location = new Point(827, 45);
		((TextBoxBase)tBookCode).MaxLength = 8;
		((Control)tBookCode).Name = "tBookCode";
		((Control)tBookCode).Size = new Size(60, 23);
		((Control)tBookCode).TabIndex = 4;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(774, 46);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(47, 20);
		((Control)Label5).TabIndex = 1171;
		Label5.Text = "Book";
		Label5.TextAlign = (ContentAlignment)64;
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV).ColumnHeadersHeight = 30;
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val8;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Location = new Point(13, 83);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV).RowHeadersVisible = false;
		((DataGridView)DGV).RowHeadersWidth = 20;
		val10.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val10;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(1160, 471);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 1172;
		((Control)DGV).Visible = false;
		((ButtonBase)chkPandingEntry).BackColor = Color.FromArgb(255, 224, 192);
		chkPandingEntry.Checked = true;
		chkPandingEntry.CheckState = (CheckState)1;
		((Control)chkPandingEntry).Font = new Font("Arial", 9.75f);
		((Control)chkPandingEntry).ForeColor = Color.Black;
		((ButtonBase)chkPandingEntry).ImeMode = (ImeMode)0;
		((Control)chkPandingEntry).Location = new Point(908, 3);
		((Control)chkPandingEntry).Name = "chkPandingEntry";
		((Control)chkPandingEntry).RightToLeft = (RightToLeft)0;
		((Control)chkPandingEntry).Size = new Size(144, 27);
		((Control)chkPandingEntry).TabIndex = 1173;
		((ButtonBase)chkPandingEntry).Text = "Only Panding Chk";
		((ButtonBase)chkPandingEntry).UseVisualStyleBackColor = false;
		((Control)chkPandingEntry).Visible = false;
		((Control)PnlIt).BackColor = Color.LavenderBlush;
		PnlIt.BorderStyle = (BorderStyle)1;
		((Control)PnlIt).Controls.Add((Control)(object)btnAll);
		((Control)PnlIt).Controls.Add((Control)(object)btnItCancel);
		((Control)PnlIt).Controls.Add((Control)(object)btnOk);
		((Control)PnlIt).Controls.Add((Control)(object)DGV_ITM);
		((Control)PnlIt).Location = new Point(716, 83);
		((Control)PnlIt).Name = "PnlIt";
		((Control)PnlIt).Size = new Size(456, 299);
		((Control)PnlIt).TabIndex = 1207;
		((Control)PnlIt).Visible = false;
		((QControl)btnAll).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAll).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAll).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAll).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAll).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAll).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAll).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAll).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAll).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAll).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAll).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAll).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAll).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAll).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAll.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAll.Image = null;
		((QControl)btnAll).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAll).Location = new Point(53, 249);
		((Control)btnAll).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAll).Name = "btnAll";
		((Control)btnAll).Size = new Size(100, 38);
		((Control)btnAll).TabIndex = 1159;
		btnAll.Text = "All";
		((QControl)btnItCancel).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnItCancel).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnItCancel).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnItCancel).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnItCancel).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnItCancel).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnItCancel).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnItCancel).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnItCancel).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnItCancel).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnItCancel).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnItCancel).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnItCancel).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnItCancel).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnItCancel.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnItCancel.Image = null;
		((QControl)btnItCancel).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnItCancel).Location = new Point(317, 249);
		((Control)btnItCancel).Margin = new Padding(3, 6, 3, 6);
		((Control)btnItCancel).Name = "btnItCancel";
		((Control)btnItCancel).Size = new Size(100, 38);
		((Control)btnItCancel).TabIndex = 1158;
		btnItCancel.Text = "Cancel";
		((QControl)btnOk).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOk).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOk).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOk.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Image = null;
		((QControl)btnOk).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOk).Location = new Point(184, 249);
		((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Size = new Size(100, 38);
		((Control)btnOk).TabIndex = 1157;
		btnOk.Text = "Ok";
		((DataGridView)DGV_ITM).AllowUserToAddRows = false;
		((DataGridView)DGV_ITM).AllowUserToDeleteRows = false;
		((DataGridView)DGV_ITM).AllowUserToResizeRows = false;
		val11.BackColor = Color.PapayaWhip;
		val11.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val11.ForeColor = Color.FromArgb(64, 64, 64);
		val11.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val11.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle = val11;
		((DataGridView)DGV_ITM).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_ITM).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_ITM).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val12.Alignment = (DataGridViewContentAlignment)16;
		val12.BackColor = SystemColors.Control;
		val12.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val12.ForeColor = Color.FromArgb(64, 64, 64);
		val12.SelectionBackColor = SystemColors.ScrollBar;
		val12.SelectionForeColor = Color.White;
		val12.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle = val12;
		((DataGridView)DGV_ITM).ColumnHeadersHeight = 30;
		((DataGridView)DGV_ITM).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val13.Alignment = (DataGridViewContentAlignment)16;
		val13.BackColor = SystemColors.Window;
		val13.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val13.ForeColor = Color.FromArgb(64, 64, 64);
		val13.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val13.SelectionForeColor = Color.Maroon;
		val13.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_ITM).DefaultCellStyle = val13;
		((DataGridView)DGV_ITM).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_ITM).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_ITM).Location = new Point(11, 11);
		((Control)DGV_ITM).Name = "DGV_ITM";
		DGV_ITM.PaintEnhancedSelection = false;
		val14.Alignment = (DataGridViewContentAlignment)16;
		val14.BackColor = Color.MintCream;
		val14.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val14.ForeColor = SystemColors.WindowText;
		val14.SelectionBackColor = SystemColors.Highlight;
		val14.SelectionForeColor = SystemColors.HighlightText;
		val14.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_ITM).RowHeadersDefaultCellStyle = val14;
		((DataGridView)DGV_ITM).RowHeadersVisible = false;
		((DataGridView)DGV_ITM).RowHeadersWidth = 20;
		val15.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val15.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_ITM).RowsDefaultCellStyle = val15;
		DGV_ITM.ScrollBarAppearance = (eScrollBarAppearance)0;
		((DataGridView)DGV_ITM).ScrollBars = (ScrollBars)2;
		DGV_ITM.SelectAllSignVisible = false;
		((DataGridView)DGV_ITM).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_ITM).Size = new Size(433, 229);
		((DataGridView)DGV_ITM).StandardTab = true;
		((Control)DGV_ITM).TabIndex = 1156;
		((ButtonBase)chkItmlist).BackColor = Color.Transparent;
		((Control)chkItmlist).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkItmlist).ForeColor = Color.Black;
		((Control)chkItmlist).Location = new Point(937, 48);
		((Control)chkItmlist).Name = "chkItmlist";
		((Control)chkItmlist).RightToLeft = (RightToLeft)0;
		((Control)chkItmlist).Size = new Size(100, 19);
		((Control)chkItmlist).TabIndex = 1209;
		((ButtonBase)chkItmlist).Text = "Select Item";
		((ButtonBase)chkItmlist).UseVisualStyleBackColor = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)chkItmlist);
		((Control)this).Controls.Add((Control)(object)PnlIt);
		((Control)this).Controls.Add((Control)(object)chkPandingEntry);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)tBookCode);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)cboUser);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)BtnList);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)DGV_DETL);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_USER";
		((Form)this).Text = "User Work Report ";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((Control)PnlIt).ResumeLayout(false);
		((ISupportInitialize)DGV_ITM).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void EntryCheckSumm()
	{
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected O, but got Unknown
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Expected O, but got Unknown
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Expected O, but got Unknown
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Expected O, but got Unknown
		//IL_07f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0803: Expected O, but got Unknown
		//IL_084f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0859: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT ROW_NUMBER() OVER (ORDER BY A.EDIT_DATE,A.CO_BOOK,A.VCH_NO) AS SrNo,A.CO_BOOK,B.BOOK_NAME,B.MAIN_BOOK,C.AC_NAME,A.VCH_NO,A.VCH_DATE,A.EDIT_DATE,A.USER_NAME,A.NEW_USER,A.AC_CODE,A.ENTRY_CHECK FROM (USER_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE  WHERE A.CO_CODE ='" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(chkPandingEntry.Checked, (object)"AND ENTRY_CHECK <> 'Y'", (object)"")), Interaction.IIf(Operators.CompareString(cboUser.Text, "", false) == 0, (object)"", (object)("AND A.USER_NAME = '" + cboUser.Text + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)("AND A.AC_CODE = '" + tAcCode.Text + "'"))), (object)" AND A.EDIT_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.EDIT_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  GROUP BY A.CO_BOOK,B.BOOK_NAME,B.MAIN_BOOK,C.AC_NAME,A.VCH_NO,A.VCH_DATE,A.EDIT_DATE,A.USER_NAME,A.NEW_USER,A.AC_CODE,A.ENTRY_CHECK ORDER BY A.EDIT_DATE,A.CO_BOOK,A.VCH_NO"));
		DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(table);
		((DataGridView)DGV).MultiSelect = false;
		((DataGridView)DGV).AutoGenerateColumns = false;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV).ColumnCount = 16;
		checked
		{
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns[0].DataPropertyName = "SrNo";
			((DataGridView)DGV).Columns[0].HeaderText = "SrNo";
			((DataGridView)DGV).Columns[1].Visible = false;
			((DataGridView)DGV).Columns[1].DataPropertyName = "CO_BOOK";
			((DataGridView)DGV).Columns[1].HeaderText = "Code";
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(190.0 * ColCon);
			((DataGridView)DGV).Columns[2].DataPropertyName = "BOOK_NAME";
			((DataGridView)DGV).Columns[2].HeaderText = "Book Name";
			((DataGridView)DGV).Columns[3].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[3].DataPropertyName = "VCH_NO";
			((DataGridView)DGV).Columns[3].HeaderText = "VchNo";
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[4].DataPropertyName = "VCH_DATE";
			((DataGridView)DGV).Columns[4].HeaderText = "VchDate";
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[5].DataPropertyName = "EDIT_DATE";
			((DataGridView)DGV).Columns[5].HeaderText = "EditDate";
			((DataGridView)DGV).Columns[6].Visible = false;
			((DataGridView)DGV).Columns[7].Visible = false;
			((DataGridView)DGV).Columns[8].Visible = false;
			((DataGridView)DGV).Columns[9].Visible = false;
			((DataGridView)DGV).Columns[10].Width = (int)Math.Round(280.0 * ColCon);
			((DataGridView)DGV).Columns[10].DataPropertyName = "AC_NAME";
			((DataGridView)DGV).Columns[10].HeaderText = "AcName";
			((DataGridView)DGV).Columns[11].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[11].DataPropertyName = "USER_NAME";
			((DataGridView)DGV).Columns[11].HeaderText = "UserName";
			((DataGridView)DGV).Columns[12].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[12].DataPropertyName = "NEW_USER";
			((DataGridView)DGV).Columns[12].HeaderText = "EditUser";
			((DataGridView)DGV).Columns[13].Visible = false;
			((DataGridView)DGV).Columns[14].Visible = false;
			((DataGridView)DGV).Columns[15].Visible = false;
			DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
			((DataGridViewColumn)val).Name = "EntryChk";
			((DataGridViewColumn)val).HeaderText = "Entry Check";
			((DataGridViewColumn)val).DataPropertyName = "ENTRY_CHECK";
			val.TrueValue = "Y";
			val.FalseValue = "N";
			val.IndeterminateValue = DBNull.Value;
			((DataGridViewColumn)val).Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns.Add((DataGridViewColumn)(object)val);
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			if (dataView.Count > 0)
			{
				((DataGridView)DGV).DataSource = dataView;
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
			}
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected O, but got Unknown
		//IL_0824: Unknown result type (might be due to invalid IL or missing references)
		//IL_082e: Expected O, but got Unknown
		((Control)DGV).Visible = false;
		BtnExit.Text = "&Back";
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select ROW_NUMBER() OVER (ORDER BY A.EDIT_DATE DESC) As SrNo,A.CO_BOOK,B.BOOK_NAME,B.MAIN_BOOK,C.AC_NAME,A.VCH_NO,A.VCH_DATE,A.EDIT_DATE,A.USER_NAME,A.NEW_USER,A.AC_CODE,A.ENTRY_CHECK,A.COL_TYPE,A.OLD_VAL,A.NEW_VAL,A.ENTRY_TIME FROM (USER_DATA As A LEFT JOIN BOOK_DATA As B On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST As C On A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE WHERE A.CO_CODE ='" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_BOOK = '"), ((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells[1].Value), (object)""), (object)"' AND A.VCH_NO = '"), ((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells[3].Value), (object)""), (object)"' AND A.EDIT_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.EDIT_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  ORDER BY A.EDIT_DATE DESC"));
		DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(table);
		((DataGridView)DGV_DETL).MultiSelect = false;
		((DataGridView)DGV_DETL).AutoGenerateColumns = false;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_DETL).ColumnCount = 16;
		checked
		{
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[0].DataPropertyName = "SrNo";
			((DataGridView)DGV_DETL).Columns[0].HeaderText = "SrNo";
			((DataGridView)DGV_DETL).Columns[1].Visible = false;
			((DataGridView)DGV_DETL).Columns[1].DataPropertyName = "CO_BOOK";
			((DataGridView)DGV_DETL).Columns[1].HeaderText = "Code";
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[2].DataPropertyName = "BOOK_NAME";
			((DataGridView)DGV_DETL).Columns[2].HeaderText = "Book Name";
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[3].DataPropertyName = "VCH_NO";
			((DataGridView)DGV_DETL).Columns[3].HeaderText = "VchNo";
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[4].DataPropertyName = "VCH_DATE";
			((DataGridView)DGV_DETL).Columns[4].HeaderText = "VchDate";
			((DataGridView)DGV_DETL).Columns[5].Visible = false;
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(150.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[6].DataPropertyName = "ENTRY_TIME";
			((DataGridView)DGV_DETL).Columns[6].HeaderText = "Time";
			((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[7].DataPropertyName = "COL_TYPE";
			((DataGridView)DGV_DETL).Columns[7].HeaderText = "Field";
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[8].DataPropertyName = "OLD_VAL";
			((DataGridView)DGV_DETL).Columns[8].HeaderText = "OldVal";
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[9].DataPropertyName = "NEW_VAL";
			((DataGridView)DGV_DETL).Columns[9].HeaderText = "NewVal";
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[10].DataPropertyName = "AC_NAME";
			((DataGridView)DGV_DETL).Columns[10].HeaderText = "AcName";
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[11].DataPropertyName = "USER_NAME";
			((DataGridView)DGV_DETL).Columns[11].HeaderText = "UserName";
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[12].DataPropertyName = "NEW_USER";
			((DataGridView)DGV_DETL).Columns[12].HeaderText = "EditUser";
			((DataGridView)DGV_DETL).Columns[13].Visible = false;
			((DataGridView)DGV_DETL).Columns[14].Visible = false;
			((DataGridView)DGV_DETL).Columns[15].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			if (dataView.Count > 0)
			{
				((DataGridView)DGV_DETL).DataSource = dataView;
			}
		}
	}

	private void DGV_ITM_FILL()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_137b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1385: Expected O, but got Unknown
		//IL_3ec6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ed0: Expected O, but got Unknown
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_DETL).AutoGenerateColumns = false;
		((DataGridView)DGV_DETL).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[0].Frozen = true;
			((DataGridView)DGV_DETL).Columns.Add("", "User");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[1].Frozen = true;
			((DataGridView)DGV_DETL).Columns.Add("", "Book");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[2].Frozen = true;
			((DataGridView)DGV_DETL).Columns.Add("", "VchDate");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[3].Frozen = true;
			((DataGridView)DGV_DETL).Columns.Add("", "VchNo");
			((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(65.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[4].Frozen = true;
			((DataGridView)DGV_DETL).Columns.Add("", "Ac Name");
			((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[5].Frozen = true;
			((DataGridView)DGV_DETL).Columns.Add("", "ItCode");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Pcs");
			((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N";
			((DataGridView)DGV_DETL).Columns.Add("", "GWt");
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Nwt");
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Format = "N3";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK095NEVK", false) == 0)
			{
				((DataGridView)DGV_DETL).Columns.Add("", "Ght%");
				((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N2";
			}
			else
			{
				((DataGridView)DGV_DETL).Columns.Add("", "Ght%");
				((DataGridView)DGV_DETL).Columns[10].Visible = false;
			}
			((DataGridView)DGV_DETL).Columns.Add("", "Fine");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Rate");
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "ItAmt");
			((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "LRate");
			((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "LAmt");
			((DataGridView)DGV_DETL).Columns[15].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "OthAmt");
			((DataGridView)DGV_DETL).Columns[16].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "DrAmt");
			((DataGridView)DGV_DETL).Columns[17].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "CrAmt");
			((DataGridView)DGV_DETL).Columns[18].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[18].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "DrFine");
			((DataGridView)DGV_DETL).Columns[19].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[19].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "CrFine");
			((DataGridView)DGV_DETL).Columns[20].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[20].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "DrSilver");
			((DataGridView)DGV_DETL).Columns[21].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[21].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "CrSilver");
			((DataGridView)DGV_DETL).Columns[22].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[22].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[22].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Tax");
			((DataGridView)DGV_DETL).Columns[23].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[23].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[23].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Cash");
			((DataGridView)DGV_DETL).Columns[24].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[24].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[24].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Bank");
			((DataGridView)DGV_DETL).Columns[25].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[25].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[25].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "UpiAmt");
			((DataGridView)DGV_DETL).Columns[26].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[26].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[26].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Card");
			((DataGridView)DGV_DETL).Columns[27].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[27].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[27].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "OrdAdj");
			((DataGridView)DGV_DETL).Columns[28].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[28].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[28].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "OGlAmt");
			((DataGridView)DGV_DETL).Columns[29].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[29].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[29].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "OSlAmt");
			((DataGridView)DGV_DETL).Columns[30].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[30].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[30].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "SchmAdj");
			((DataGridView)DGV_DETL).Columns[31].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[31].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[31].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Kasar");
			((DataGridView)DGV_DETL).Columns[32].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[32].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[32].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "CashPaid");
			((DataGridView)DGV_DETL).Columns[33].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[33].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[33].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Mobile");
			((DataGridView)DGV_DETL).Columns[34].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "AcCode");
			((DataGridView)DGV_DETL).Columns[35].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "CoBook");
			((DataGridView)DGV_DETL).Columns[36].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "MainBook");
			((DataGridView)DGV_DETL).Columns[37].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			DC_Main.M = 0;
			DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
			if (Operators.CompareString(SelectIt, "", false) != 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_STOCK_PRINT(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,BOOK_NAME,VCH_TYPE,MAIN_USER,AC_CODE,GHT_PRC)   SELECT D.CO_CODE,D.LC_CODE,D.CO_YEAR,D.CO_BOOK,D.VCH_NO,D.VCH_DATE,F.MAIN_BOOK,F.BOOK_SNAME,D.MAIN_USER,D.AC_CODE,D.GHT_PRC FROM MAIN_STOCK As D LEFT JOIN BOOK_DATA As F On D.CO_CODE = F.CO_CODE And D.LC_CODE = F.LC_CODE And D.CO_BOOK = F.CO_BOOK WHERE D.CO_CODE = '" + DC_Main.MCo_code + "' AND D.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND F.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND D.IT_CODE IN (" + SelectIt + ")"))), (object)"  And D.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND D.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' GROUP BY D.CO_CODE,D.LC_CODE,D.CO_YEAR,D.CO_BOOK,D.VCH_NO,D.VCH_DATE,D.MAIN_USER,F.MAIN_BOOK,F.BOOK_SNAME,D.AC_CODE,D.GHT_PRC ORDER BY D.MAIN_USER,D.VCH_DATE,D.CO_BOOK"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_STOCK_PRINT(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,BOOK_NAME,VCH_TYPE,MAIN_USER,AC_CODE,GHT_PRC)   SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,C.MAIN_BOOK,C.BOOK_SNAME,A.MAIN_USER,A.PARTY_AC_CODE,0 AS GHT_PRC FROM AC_DATA AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND C.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" and A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' AND A.PARTY_AC_CODE <> '' GROUP BY A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.MAIN_USER,C.MAIN_BOOK,C.BOOK_SNAME,A.PARTY_AC_CODE "), (object)" UNION ALL Select D.CO_CODE,D.LC_CODE,D.CO_YEAR,D.CO_BOOK,D.VCH_NO,D.VCH_DATE,F.MAIN_BOOK,F.BOOK_SNAME,D.MAIN_USER,D.AC_CODE,D.GHT_PRC FROM MAIN_STOCK As D LEFT JOIN BOOK_DATA As F On D.CO_CODE = F.CO_CODE And D.LC_CODE = F.LC_CODE And D.CO_BOOK = F.CO_BOOK WHERE D.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND D.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND F.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  And D.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND D.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' GROUP BY D.CO_CODE,D.LC_CODE,D.CO_YEAR,D.CO_BOOK,D.VCH_NO,D.VCH_DATE,D.MAIN_USER,F.MAIN_BOOK,F.BOOK_SNAME,D.AC_CODE,D.GHT_PRC ORDER BY A.MAIN_USER,A.VCH_DATE,A.CO_BOOK"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_BOOK,VCH_NO,VCH_DATE,BOOK_NAME,VCH_TYPE,MAIN_USER,AC_CODE FROM TAG_STOCK_PRINT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(cboUser.Text, "", false) == 0, (object)"", (object)("AND MAIN_USER = '" + cboUser.Text + "'"))), Interaction.IIf(Operators.CompareString(tAcCode.Text, "", false) == 0, (object)"", (object)("AND AC_CODE = '" + tAcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND CO_BOOK = '" + tBookCode.Text + "'"))), (object)" GROUP BY CO_BOOK,VCH_NO,VCH_DATE,BOOK_NAME,VCH_TYPE,MAIN_USER,AC_CODE ORDER BY MAIN_USER,VCH_DATE,CO_BOOK,VCH_NO "));
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			double num = default(double);
			double num2 = default(double);
			double num3 = default(double);
			double num4 = default(double);
			double num5 = default(double);
			double num6 = default(double);
			double num7 = default(double);
			double num8 = default(double);
			double num9 = default(double);
			double num10 = default(double);
			double num11 = default(double);
			double num12 = default(double);
			double num13 = default(double);
			double num14 = default(double);
			double num15 = default(double);
			double num16 = default(double);
			double num17 = default(double);
			double num20 = default(double);
			double num21 = default(double);
			double num22 = default(double);
			double num23 = default(double);
			double num24 = default(double);
			double num25 = default(double);
			double num26 = default(double);
			if (dataTable.Rows.Count > 0)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
				while (DC_Main.X < dataTable.Rows.Count)
				{
					((DataGridView)dGV_DETL).Rows.Add();
					DC_Main.R = ((DataGridView)dGV_DETL).Rows.Count - 1;
					((DataGridView)dGV_DETL)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV_DETL)[1, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["MAIN_USER"], (object)"");
					((DataGridView)dGV_DETL)[2, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_TYPE"], (object)"");
					((DataGridView)dGV_DETL)[4, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_NO"], (object)"");
					((DataGridView)dGV_DETL)[3, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["VCH_DATE"], (object)"");
					string value = "";
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select AC_NAME,AC_MOBILE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '"), dataTable.Rows[DC_Main.X]["AC_CODE"]), (object)"' "));
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						((DataGridView)dGV_DETL)[5, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)"");
						value = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
						((DataGridView)dGV_DETL)[34, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MOBILE"], (object)"");
					}
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(A.DR_AMT) As DrAmt,SUM(A.CR_AMT)CrAmt,  SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END)ELSE 0 END) As DrGold,  SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE 0 END)ELSE 0 END) As CrGold,  SUM(Case When A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '-' THEN A.FINE_WT ELSE 0 END)ELSE 0 END) As DrSilver,  SUM(Case When A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE 0 END)ELSE 0 END) As CrSilver  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.X]["VCH_NO"]), (object)"' AND A.AC_CODE = '"), dataTable.Rows[DC_Main.X]["AC_CODE"]), (object)"' "));
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						((DataGridView)dGV_DETL)[17, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DrAmt"], (object)"")), "0.00");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[17, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[17, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[18, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CrAmt"], (object)"")), "0.00");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[18, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[18, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[19, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DrGold"], (object)"")), "0.000");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[19, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[19, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[20, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CrGold"], (object)"")), "0.000");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[20, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[20, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[21, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DrSilver"], (object)"")), "0.000");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[21, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[21, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[22, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CrSilver"], (object)"")), "0.000");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[22, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[22, DC_Main.R].Value = "";
						}
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[18, DC_Main.R].Value));
						num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[17, DC_Main.R].Value));
						num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[20, DC_Main.R].Value));
						num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[19, DC_Main.R].Value));
						num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[22, DC_Main.R].Value));
						num6 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[21, DC_Main.R].Value));
					}
					object obj = dataTable.Rows[DC_Main.X]["BOOK_NAME"];
					if (Operators.ConditionalCompareObjectEqual(obj, (object)"SALES", false))
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select DISC_AMT,TAX_AMT,CASH_AMT,CHQ_AMT,CARD_AMT,ADV_AMT,OLD_GL_AMT,OLD_SL_AMT,SCHM_AMT,KASAR_AMT,UPI_AMT,CASH_PAID  FROM SL_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.X]["VCH_NO"]), (object)"'"));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							((DataGridView)dGV_DETL)[23, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAX_AMT"], (object)"")), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[23, DC_Main.R].Value)) == 0.0)
							{
								((DataGridView)dGV_DETL)[23, DC_Main.R].Value = "";
							}
							((DataGridView)dGV_DETL)[24, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CASH_AMT"], (object)"")), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[24, DC_Main.R].Value)) == 0.0)
							{
								((DataGridView)dGV_DETL)[24, DC_Main.R].Value = "";
							}
							((DataGridView)dGV_DETL)[25, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CHQ_AMT"], (object)"")), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[25, DC_Main.R].Value)) == 0.0)
							{
								((DataGridView)dGV_DETL)[25, DC_Main.R].Value = "";
							}
							((DataGridView)dGV_DETL)[26, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["UPI_AMT"], (object)"")), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[26, DC_Main.R].Value)) == 0.0)
							{
								((DataGridView)dGV_DETL)[26, DC_Main.R].Value = "";
							}
							((DataGridView)dGV_DETL)[27, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CARD_AMT"], (object)"")), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[27, DC_Main.R].Value)) == 0.0)
							{
								((DataGridView)dGV_DETL)[27, DC_Main.R].Value = "";
							}
							((DataGridView)dGV_DETL)[28, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["ADV_AMT"], (object)"")), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[28, DC_Main.R].Value)) == 0.0)
							{
								((DataGridView)dGV_DETL)[28, DC_Main.R].Value = "";
							}
							((DataGridView)dGV_DETL)[29, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OLD_GL_AMT"], (object)"")), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[29, DC_Main.R].Value)) == 0.0)
							{
								((DataGridView)dGV_DETL)[29, DC_Main.R].Value = "";
							}
							((DataGridView)dGV_DETL)[30, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OLD_SL_AMT"], (object)"")), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[30, DC_Main.R].Value)) == 0.0)
							{
								((DataGridView)dGV_DETL)[30, DC_Main.R].Value = "";
							}
							((DataGridView)dGV_DETL)[31, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SCHM_AMT"], (object)"")), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[31, DC_Main.R].Value)) == 0.0)
							{
								((DataGridView)dGV_DETL)[31, DC_Main.R].Value = "";
							}
							((DataGridView)dGV_DETL)[32, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["KASAR_AMT"], (object)"")) + Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DISC_AMT"], (object)""))), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[32, DC_Main.R].Value)) == 0.0)
							{
								((DataGridView)dGV_DETL)[32, DC_Main.R].Value = "";
							}
							((DataGridView)dGV_DETL)[33, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CASH_PAID"], (object)"")), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[33, DC_Main.R].Value)) == 0.0)
							{
								((DataGridView)dGV_DETL)[33, DC_Main.R].Value = "";
							}
						}
						num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[23, DC_Main.R].Value));
						num8 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[24, DC_Main.R].Value));
						num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[25, DC_Main.R].Value));
						num10 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[26, DC_Main.R].Value));
						num11 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[27, DC_Main.R].Value));
						num12 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[28, DC_Main.R].Value));
						num13 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[29, DC_Main.R].Value));
						num14 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[30, DC_Main.R].Value));
						num15 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[31, DC_Main.R].Value));
						num16 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[32, DC_Main.R].Value));
						num17 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[33, DC_Main.R].Value));
					}
					else if (Operators.ConditionalCompareObjectEqual(obj, (object)"MEMB ENTRY", false))
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(A.MEMB_AMT) As RecAmt,A.REC_AC FROM AD_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.REC_AC = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.X]["VCH_NO"]), (object)"' AND A.WITH_UPI <> 'Y' GROUP BY A.REC_AC"));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							int num18 = DC_Main.Tbl.Rows.Count - 1;
							for (int i = 0; i <= num18; i++)
							{
								if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[i]["REC_AC"], (object)""), (object)"00001", false))
								{
									((DataGridView)dGV_DETL)[24, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[i]["RecAmt"], (object)"")), "0.00");
									if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[24, DC_Main.R].Value)) == 0.0)
									{
										((DataGridView)dGV_DETL)[24, DC_Main.R].Value = "";
									}
									num8 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[24, DC_Main.R].Value));
								}
								else
								{
									((DataGridView)dGV_DETL)[25, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[i]["RecAmt"], (object)"")), "0.00");
									if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[25, DC_Main.R].Value)) == 0.0)
									{
										((DataGridView)dGV_DETL)[25, DC_Main.R].Value = "";
									}
									num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[25, DC_Main.R].Value));
								}
							}
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(UPI_AMT) As UpiAmt FROM UPI_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.X]["VCH_NO"]), (object)"'"));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							((DataGridView)dGV_DETL)[26, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["UpiAmt"], (object)"")), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[26, DC_Main.R].Value)) == 0.0)
							{
								((DataGridView)dGV_DETL)[26, DC_Main.R].Value = "";
							}
							num10 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[26, DC_Main.R].Value));
						}
					}
					else if (Operators.ConditionalCompareObjectEqual(obj, (object)"BILL REC", false))
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select SUM(A.REC_AMT) As RecAmt,A.REC_AC_CODE FROM CASH_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.REC_AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.X]["VCH_NO"]), (object)"' GROUP BY A.REC_AC_CODE"));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							int num19 = DC_Main.Tbl.Rows.Count - 1;
							for (int j = 0; j <= num19; j++)
							{
								if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[j]["REC_AC_CODE"], (object)""), (object)"00001", false))
								{
									((DataGridView)dGV_DETL)[24, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[j]["RecAmt"], (object)"")), "0.00");
									if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[24, DC_Main.R].Value)) == 0.0)
									{
										((DataGridView)dGV_DETL)[24, DC_Main.R].Value = "";
									}
									num8 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[24, DC_Main.R].Value));
								}
								else
								{
									((DataGridView)dGV_DETL)[25, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[j]["RecAmt"], (object)"")), "0.00");
									if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[25, DC_Main.R].Value)) == 0.0)
									{
										((DataGridView)dGV_DETL)[25, DC_Main.R].Value = "";
									}
									num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[25, DC_Main.R].Value));
								}
							}
						}
					}
					((DataGridView)dGV_DETL)[35, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["AC_CODE"], (object)"");
					((DataGridView)dGV_DETL)[36, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["CO_BOOK"], (object)"");
					((DataGridView)dGV_DETL)[37, DC_Main.R].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["BOOK_NAME"], (object)"");
					((DataGridView)dGV_DETL).Rows[DC_Main.R].DefaultCellStyle.ForeColor = Color.Maroon;
					int k = 0;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable.Rows[DC_Main.X]["VCH_NO"]), (object)"' "), Interaction.IIf(Operators.CompareString(SelectIt, "", false) == 0, (object)"", (object)("AND IT_CODE IN (" + SelectIt + ")"))), (object)""));
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					for (; k < DC_Main.Tbl.Rows.Count; k++)
					{
						if (k != 0)
						{
							((DataGridView)dGV_DETL).Rows.Add();
							DC_Main.R = ((DataGridView)dGV_DETL).Rows.Count - 1;
							((DataGridView)dGV_DETL).Rows[DC_Main.R].DefaultCellStyle.ForeColor = Color.Blue;
						}
						((DataGridView)dGV_DETL)[0, DC_Main.R].Value = DC_Main.R + 1;
						((DataGridView)dGV_DETL)[1, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["MAIN_USER"], (object)"");
						((DataGridView)dGV_DETL)[2, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["VCH_TYPE"], (object)"");
						((DataGridView)dGV_DETL)[4, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["VCH_NO"], (object)"");
						((DataGridView)dGV_DETL)[3, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["VCH_DATE"], (object)"");
						((DataGridView)dGV_DETL)[5, DC_Main.R].Value = value;
						((DataGridView)dGV_DETL)[6, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["IT_CODE"], (object)"");
						((DataGridView)dGV_DETL)[7, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["ITM_PCS"], (object)"")), "0");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[7, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[8, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["ITM_GWT"], (object)"")), "0.000");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[8, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[8, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[9, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["ITM_NWT"], (object)"")), "0.000");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[9, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[9, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[10, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["GHT_PRC"], (object)"")), "0.00");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[10, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[10, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[11, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["ITM_FINE"], (object)"")), "0.000");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[11, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[11, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[12, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["ITM_RATE"], (object)"")), "0.00");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[12, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[12, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[13, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["ITM_AMT"], (object)"")), "0.00");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[13, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[13, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[14, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["LBR_RATE"], (object)"")), "0.00");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[14, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[14, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[15, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["LBR_AMT"], (object)"")), "0.00");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[15, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[15, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[16, DC_Main.R].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["OTH_AMT"], (object)"")), "0.00");
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[16, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV_DETL)[16, DC_Main.R].Value = "";
						}
						((DataGridView)dGV_DETL)[2, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["VCH_TYPE"], (object)"");
						((DataGridView)dGV_DETL)[4, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["VCH_NO"], (object)"");
						((DataGridView)dGV_DETL)[35, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["AC_CODE"], (object)"");
						((DataGridView)dGV_DETL)[36, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["CO_BOOK"], (object)"");
						((DataGridView)dGV_DETL)[37, DC_Main.R].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[k]["BOOK_NAME"], (object)"");
						num20 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[7, DC_Main.R].Value));
						num21 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[8, DC_Main.R].Value));
						num22 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[9, DC_Main.R].Value));
						num23 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[11, DC_Main.R].Value));
						num24 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[13, DC_Main.R].Value));
						num25 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[15, DC_Main.R].Value));
						num26 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_DETL)[16, DC_Main.R].Value));
					}
					DC_Main.X++;
				}
				dGV_DETL = null;
			}
			DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL2 = DGV_DETL;
			((DataGridView)dGV_DETL2).Rows.Add();
			((DataGridView)dGV_DETL2).Rows.Add();
			DC_Main.R = ((DataGridView)dGV_DETL2).Rows.Count - 1;
			((DataGridView)dGV_DETL2)[1, DC_Main.R].Value = "Total :";
			((DataGridView)dGV_DETL2)[17, DC_Main.R].Value = Strings.Format((object)num2, "0.000");
			((DataGridView)dGV_DETL2)[18, DC_Main.R].Value = Strings.Format((object)num, "0.000");
			((DataGridView)dGV_DETL2)[19, DC_Main.R].Value = Strings.Format((object)num4, "0.000");
			((DataGridView)dGV_DETL2)[20, DC_Main.R].Value = Strings.Format((object)num3, "0.000");
			((DataGridView)dGV_DETL2)[22, DC_Main.R].Value = Strings.Format((object)num5, "0.00");
			((DataGridView)dGV_DETL2)[21, DC_Main.R].Value = Strings.Format((object)num6, "0.00");
			((DataGridView)dGV_DETL2)[23, DC_Main.R].Value = Strings.Format((object)num7, "0.00");
			((DataGridView)dGV_DETL2)[24, DC_Main.R].Value = Strings.Format((object)num8, "0.00");
			((DataGridView)dGV_DETL2)[25, DC_Main.R].Value = Strings.Format((object)num9, "0.00");
			((DataGridView)dGV_DETL2)[26, DC_Main.R].Value = Strings.Format((object)num10, "0.00");
			((DataGridView)dGV_DETL2)[27, DC_Main.R].Value = Strings.Format((object)num11, "0.00");
			((DataGridView)dGV_DETL2)[28, DC_Main.R].Value = Strings.Format((object)num12, "0.00");
			((DataGridView)dGV_DETL2)[29, DC_Main.R].Value = Strings.Format((object)num13, "0.00");
			((DataGridView)dGV_DETL2)[30, DC_Main.R].Value = Strings.Format((object)num14, "0.00");
			((DataGridView)dGV_DETL2)[31, DC_Main.R].Value = Strings.Format((object)num15, "0.00");
			((DataGridView)dGV_DETL2)[32, DC_Main.R].Value = Strings.Format((object)num16, "0.00");
			((DataGridView)dGV_DETL2)[33, DC_Main.R].Value = Strings.Format((object)num17, "0.00");
			((DataGridView)dGV_DETL2)[7, DC_Main.R].Value = Strings.Format((object)num20, "0");
			((DataGridView)dGV_DETL2)[8, DC_Main.R].Value = Strings.Format((object)num21, "0.000");
			((DataGridView)dGV_DETL2)[9, DC_Main.R].Value = Strings.Format((object)num22, "0.000");
			((DataGridView)dGV_DETL2)[11, DC_Main.R].Value = Strings.Format((object)num23, "0.000");
			((DataGridView)dGV_DETL2)[13, DC_Main.R].Value = Strings.Format((object)num24, "0.00");
			((DataGridView)dGV_DETL2)[15, DC_Main.R].Value = Strings.Format((object)num25, "0.00");
			((DataGridView)dGV_DETL2)[16, DC_Main.R].Value = Strings.Format((object)num26, "0.00");
			dGV_DETL2 = null;
			((DataGridView)DGV_DETL).Rows[DC_Main.R].DefaultCellStyle.ForeColor = Color.DarkBlue;
			((DataGridView)DGV_DETL).Rows[DC_Main.R].DefaultCellStyle.Font = new Font("Segoe UI", 9f, (FontStyle)1);
		}
	}

	private void DGV_DETL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
					if (((uint)(columnIndex - 18) <= 4u || (uint)(columnIndex - 34) <= 2u) && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 113:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_00a7;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 113;
				continue;
			}
			break;
			IL_00a7:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			int num = ((DataGridView)DGV).Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV).Rows[i].Cells["EntryChk"].Value, (object)"Y", false))
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE USER_DATA SET ENTRY_CHECK = 'Y'  WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)DGV).Rows[i].Cells[1].Value), (object)"' AND VCH_NO = '"), ((DataGridView)DGV).Rows[i].Cells[3].Value), (object)"' AND EDIT_DATE = '"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(((DataGridView)DGV).Rows[i].Cells[5].Value), "MM/dd/yyyy")), (object)"'"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
			}
			Interaction.MsgBox((object)"Data Are Update.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		}
	}

	private void RP_USER_Load(object sender, EventArgs e)
	{
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_0853: Unknown result type (might be due to invalid IL or missing references)
		//IL_085a: Expected O, but got Unknown
		//IL_08ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d9: Expected O, but got Unknown
		//IL_0961: Unknown result type (might be due to invalid IL or missing references)
		//IL_0966: Unknown result type (might be due to invalid IL or missing references)
		//IL_0970: Expected O, but got Unknown
		//IL_09e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ed: Expected O, but got Unknown
		//IL_0a9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aae: Expected O, but got Unknown
		//IL_0acd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0adc: Expected O, but got Unknown
		//IL_0afb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0a: Expected O, but got Unknown
		//IL_0b8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9b: Expected O, but got Unknown
		//IL_0bba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc9: Expected O, but got Unknown
		//IL_0be8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf7: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurRpt = DC_Main.MsUserRightForm;
		lblBook.Text = "User Work Report";
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
				CheckBox obj4 = chkPandingEntry;
				object? obj5 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj4).BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				Label obj6 = lblBook;
				object? obj7 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj6).ForeColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj8 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
				object? obj9 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DETL).BackgroundColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj10 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj11 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((ButtonBase)chkPandingEntry).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL2 = DGV_DETL;
				object? obj12 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_DETL2).BackgroundColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				ComboBox obj14 = cboUser;
				object? obj15 = colorConverter.ConvertFromString("233, 235, 240");
				obj14.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj16 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((ButtonBase)chkPandingEntry).BackColor = Color.Cornsilk;
				Label obj17 = lblBook;
				object? obj18 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj17).ForeColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj19 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL3 = DGV_DETL;
				object? obj20 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DETL3).BackgroundColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj21 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				ComboBox obj22 = cboUser;
				object? obj23 = colorConverter.ConvertFromString("Cornsilk");
				obj22.BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tAcCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tAcCode).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is CheckBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
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
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_DETL).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_DETL).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_DETL).RowTemplate.Height * (1.0 + num2));
				}
			}
			cboUser.Items.Clear();
			DC_Main.RsQry = "SELECT LOGIN_NAME FROM LOGIN_MAST WHERE CO_CODE = '01' GROUP BY LOGIN_NAME ORDER BY LOGIN_NAME ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			cboUser.Items.Clear();
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboUser.Items.Add((object)"");
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboUser.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["LOGIN_NAME"], (object)""));
					DC_Main.X++;
				}
				cboUser.SelectedIndex = 0;
			}
			else
			{
				cboUser.Items.Add((object)"");
			}
			if (Operators.CompareString(CurRpt, "Entry Check", false) == 0)
			{
				((Control)chkItmlist).Visible = false;
				lblBook.Text = "Entry Check Report";
				((Control)chkPandingEntry).Visible = true;
				DC_Main.ExeQuteDc("DELETE FROM USER_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND EDIT_DATE < '" + Strings.Format((object)DateAndTime.Now.AddDays(-60.0), "MM/dd/yyyy") + "'");
			}
			CLEAR_DATA();
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
		mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		if (Operators.CompareString(CurRpt, "Entry Check", false) == 0)
		{
			BtnExit.Text = "&Exit";
			((Control)DGV).Visible = true;
			EntryCheckSumm();
		}
		else
		{
			DGV_ITM_FILL();
		}
		((Control)mFromDt).Focus();
	}

	private void RP_USER_Activated(object sender, EventArgs e)
	{
		CurActCtrl.Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			((DataGridView)DGV_DETL).DataSource = null;
			((DataGridView)DGV_DETL).ClearSelection();
			((DataGridView)DGV_DETL).Rows.Clear();
			((Control)DGV_DETL).Refresh();
			BtnExit.Text = "&Exit";
			((Control)DGV).Visible = true;
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void RP_USER_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_USER_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_USER_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_USER_Closed(object sender, EventArgs e)
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

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.LC_CODE,A.AC_NAME";
				}
				else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
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
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
		if (Operators.CompareString(CurRpt, "Entry Check", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[1].Value), (object)""), (object)"' "));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[36].Value), (object)""), (object)"' "));
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
		if (Operators.CompareString(CurRpt, "Entry Check", false) == 0)
		{
			DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[3].Value, (object)""));
		}
		else
		{
			DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[4].Value, (object)""));
		}
		if (Operators.CompareString(DC_Main.CurBookMain, "OPSTK", false) == 0)
		{
			TR_TAG_OPBL tR_TAG_OPBL = new TR_TAG_OPBL();
			((Form)tR_TAG_OPBL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_OPBL).Show();
			((Control)tR_TAG_OPBL).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "TAG GEN", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR TAG", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG TAG", false) == 0))
		{
			TR_TAG_OPBL tR_TAG_OPBL2 = new TR_TAG_OPBL();
			((Form)tR_TAG_OPBL2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_OPBL2).Show();
			((Control)tR_TAG_OPBL2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES ORDER", false) == 0)
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

	private void mToDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToDt).SelectionStart = 0;
		((TextBoxBase)mToDt).SelectionLength = Strings.Len(mToDt.Text);
	}

	private void cboItmType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			DGV_ITM_FILL();
		}
	}

	private void BtnList_Click(object sender, EventArgs e)
	{
		SelectIt = "";
		chkItmlist.Checked = false;
		if (Operators.CompareString(CurRpt, "Entry Check", false) == 0)
		{
			BtnExit.Text = "&Exit";
			((Control)DGV).Visible = true;
			((Control)chkPandingEntry).Visible = true;
			EntryCheckSumm();
		}
		else
		{
			DGV_ITM_FILL();
		}
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

	private void mFromDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mFromDt).SelectionStart = 0;
		((TextBoxBase)mFromDt).SelectionLength = Strings.Len(mFromDt.Text);
	}

	private void cboUser_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tBookCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + tBookCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT A.BOOK_NAME As BookNameL,A.CO_BOOK As BookL FROM BOOK_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  ORDER BY A.BOOK_NAME";
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
						tBookCode.Text = DC_Main.ColValue[1];
					}
					((Control)tBookCode).Focus();
				}
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
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
		string text = "'User Detail Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		DC_Main.ExeQuteDc("DELETE FROM REPORT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
		DC_Main.RsQry = "INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,COL_1,COL_2,COL_3,COL_4,COL_5,COL_6,COL_7,  COL_8,COL_9,COL_10,COL_11,COL_12,COL_13,COL_14,COL_15,COL_16,COL_17,COL_18,COL_19,COL_20,  COL_21,COL_22,COL_23,COL_24,COL_25,COL_26,COL_27,COL_28,COL_29,COL_30,COL_31,COL_32,COL_33)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','0','" + ((DataGridView)dGV_DETL).Columns[1].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[2].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[3].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[4].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[5].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[6].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[7].HeaderText + "',  '" + ((DataGridView)dGV_DETL).Columns[8].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[9].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[10].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[11].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[12].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[13].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[14].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[15].HeaderText + "',  '" + ((DataGridView)dGV_DETL).Columns[16].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[17].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[18].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[19].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[20].HeaderText + "',  '" + ((DataGridView)dGV_DETL).Columns[21].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[22].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[23].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[24].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[25].HeaderText + "',  '" + ((DataGridView)dGV_DETL).Columns[26].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[27].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[28].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[29].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[30].HeaderText + "','" + ((DataGridView)dGV_DETL).Columns[31].HeaderText + "','','')";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		checked
		{
			int num = ((DataGridView)dGV_DETL).RowCount - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,COL_1,COL_2,COL_3,COL_4,COL_5,COL_6,COL_7,  COL_8,COL_9,COL_10,COL_11,COL_12,COL_13,COL_14,COL_15,COL_16,COL_17,COL_18,COL_19,COL_20,  COL_21,COL_22,COL_23,COL_24,COL_25,COL_26,COL_27,COL_28,COL_29,COL_30,COL_31,COL_32,COL_33)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), ((DataGridView)dGV_DETL)[0, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[1, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[2, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[3, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[4, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[5, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[6, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[7, DC_Main.X].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_DETL)[8, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[9, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[10, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[11, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[12, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[13, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[14, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[15, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[16, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[17, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[18, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[19, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[20, DC_Main.X].Value), (object)"', "), (object)" '"), ((DataGridView)dGV_DETL)[21, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[22, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[23, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[24, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[25, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[26, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[27, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[28, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[29, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[30, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV_DETL)[31, DC_Main.X].Value), (object)"','','')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.X++;
			}
			dGV_DETL = null;
			DC_Main.RsQry = "SELECT * FROM REPORT_DATA";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\UserDtlRpt.RPT";
			Cr.SelectionFormula = "{REPORT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {REPORT_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' ";
			Cr[(short)0] = ("RptTitel = " + text) ?? "";
			Cr[(short)1] = "RptShow = 'R'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.PageZoom((short)DC_Main.MsPrintZoom);
			Cr.Action = -1;
		}
	}

	private void btnExel_Click(object sender, EventArgs e)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		object objectValue = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application", ""));
		object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Add", new object[0], (string[])null, (Type[])null, (bool[])null));
		object objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, (Type)null, "Sheets", new object[1] { 1 }, (string[])null, (Type[])null, (bool[])null));
		objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, (Type)null, "Sheets", new object[1] { "sheet1" }, (string[])null, (Type[])null, (bool[])null));
		NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3] { 1, 1, "Sheet 1 content" }, (string[])null, (Type[])null);
		checked
		{
			int num = ((DataGridView)DGV_DETL).ColumnCount - 1;
			for (int i = 0; i <= num; i++)
			{
				NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3]
				{
					1,
					i + 1,
					((DataGridView)DGV_DETL).Columns[i].HeaderText
				}, (string[])null, (Type[])null);
			}
			int num2 = 0;
			int num3 = ((DataGridView)DGV_DETL).RowCount - 1;
			DC_Main.i = 0;
			while (DC_Main.i <= num3)
			{
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[35, DC_Main.i].Value)) != 0.0)
				{
					num2++;
					int num4 = ((DataGridView)DGV_DETL).ColumnCount - 1;
					for (int j = 0; j <= num4; j++)
					{
						if (((DataGridView)DGV_DETL)[j, DC_Main.i].Value != null)
						{
							NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3]
							{
								num2 + 2,
								j + 1,
								((DataGridView)DGV_DETL)[j, DC_Main.i].Value.ToString()
							}, (string[])null, (Type[])null);
						}
					}
				}
				DC_Main.i++;
			}
			ColorConverter colorConverter = new ColorConverter();
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateSet(objectValue, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
			Cursor.Current = Cursors.Default;
			objectValue3 = null;
			objectValue2 = null;
			objectValue = null;
			GC.Collect();
		}
	}

	private void chkItmlist_Click(object sender, EventArgs e)
	{
		if (chkItmlist.Checked)
		{
			ItmList();
			((Control)PnlIt).Visible = true;
		}
		else
		{
			((Control)PnlIt).Visible = false;
		}
	}

	private void ItmList()
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		ColorConverter colorConverter = new ColorConverter();
		DC_Main.RsQry = "SELECT A.IT_CODE,A.IT_NAME FROM ITEM_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY IT_TYPE,A.IT_NAME ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV_ITM).Rows.Count <= 0)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_ITM = DGV_ITM;
				((DataGridView)dGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_ITM).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_ITM).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_ITM).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)dGV_ITM).AutoGenerateColumns = false;
				DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV_ITM).Columns.Add((DataGridViewColumn)(object)val);
				((DataGridView)dGV_ITM).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV_ITM).Columns.Add("", "Sr");
				((DataGridView)dGV_ITM).Columns[1].Width = (int)Math.Round(40.0 * ColCon);
				((DataGridView)dGV_ITM).Columns.Add("", "Itm Name");
				((DataGridView)dGV_ITM).Columns[2].Width = (int)Math.Round(224.0 * ColCon);
				((DataGridView)dGV_ITM).Columns.Add("", "It Code");
				((DataGridView)dGV_ITM).Columns[3].Width = (int)Math.Round(80.0 * ColCon);
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV_ITM).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dGV_ITM).Rows.Add();
					((DataGridView)dGV_ITM)[1, DC_Main.i].Value = DC_Main.i + 1;
					((DataGridView)dGV_ITM)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["IT_NAME"]);
					((DataGridView)dGV_ITM)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["IT_CODE"]);
					DC_Main.i++;
				}
				dGV_ITM = null;
			}
		}
	}

	private void btnAll_Click(object sender, EventArgs e)
	{
		checked
		{
			int num = ((DataGridView)DGV_ITM).Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells["Ok"].Value = true;
				DC_Main.M++;
			}
		}
	}

	private void btnOk_Click(object sender, EventArgs e)
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		SelectIt = "";
		checked
		{
			int num = ((DataGridView)DGV_ITM).Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells["Ok"].Value, (object)true, false))
				{
					SelectIt = Conversions.ToString(Operators.AddObject(Operators.AddObject((object)(SelectIt + "'"), ((DataGridView)DGV_ITM).Rows[DC_Main.M].Cells[3].Value), (object)"',"));
				}
				DC_Main.M++;
			}
			if (Operators.CompareString(SelectIt, "", false) == 0)
			{
				Interaction.MsgBox((object)"Item Selection Not Done...", (MsgBoxStyle)0, (object)null);
				((Control)PnlIt).Visible = false;
				return;
			}
			SelectIt = Strings.Mid(SelectIt, 1, Strings.Len(SelectIt) - 1);
			((Control)PnlIt).Visible = false;
			((DataGridView)DGV_ITM).DataSource = null;
			((DataGridView)DGV_ITM).ClearSelection();
			((DataGridView)DGV_ITM).Rows.Clear();
			((Control)DGV_ITM).Refresh();
			DGV_ITM_FILL();
		}
	}

	private void btnItCancel_Click(object sender, EventArgs e)
	{
		((DataGridView)DGV_ITM).DataSource = null;
		((DataGridView)DGV_ITM).ClearSelection();
		((DataGridView)DGV_ITM).Rows.Clear();
		((Control)DGV_ITM).Refresh();
		SelectIt = "";
		((Control)PnlIt).Visible = false;
	}
}
