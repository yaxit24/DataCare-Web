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
public class RP_BALANCE : Form
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
	[AccessedThroughProperty("BtnTrialBalance")]
	private QButton _BtnTrialBalance;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPandL")]
	private QButton _BtnPandL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Btnbalsheet")]
	private QButton _Btnbalsheet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLcCode")]
	private TextBox _tLcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nSilverAmt")]
	private TextBox _nSilverAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nGoldAmt")]
	private TextBox _nGoldAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnFine")]
	private QButton _btnFine;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnBalanceZoom")]
	private QButton _BtnBalanceZoom;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPandLZoom")]
	private QButton _BtnPandLZoom;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnZoom")]
	private QButton _btnZoom;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkOpBal")]
	private CheckBox _chkOpBal;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkTodayBal")]
	private CheckBox _chkTodayBal;

	private Control CurActCtrl;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string CurRpt;

	private string RptData;

	private string CurFormula;

	private double Gr1Amt;

	private double Gr2Amt;

	private double Gr3Amt;

	private double Gr4Amt;

	private const int cSrNo = 0;

	private const int cTradCode = 1;

	private const int cTradName = 2;

	private const int cClPcs = 3;

	private const int cPcsVal = 4;

	private const int cClWt = 5;

	private const int cClFine = 6;

	private const int cAcFine = 7;

	private const int cFineVal = 8;

	private const int cTotVal = 9;

	private const int cClosingVal = 10;

	private const int cAcCode = 11;

	private const int cLdCode = 12;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PanelSale")]
	private virtual Panel _PanelSale;

	internal virtual Panel PanelSale
	{
		get
		{
			return _PanelSale;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelSale = value;
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

	internal virtual QButton BtnTrialBalance
	{
		[CompilerGenerated]
		get
		{
			return _BtnTrialBalance;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTrialBalance_Click;
			QButton val = _BtnTrialBalance;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnTrialBalance = value;
			val = _BtnTrialBalance;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnPandL
	{
		[CompilerGenerated]
		get
		{
			return _BtnPandL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnPandL_Click;
			QButton val = _BtnPandL;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnPandL = value;
			val = _BtnPandL;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton Btnbalsheet
	{
		[CompilerGenerated]
		get
		{
			return _Btnbalsheet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Btnbalsheet_Click;
			QButton val = _Btnbalsheet;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_Btnbalsheet = value;
			val = _Btnbalsheet;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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
			MaskedTextBox val2 = _mFromDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mFromDt = value;
			val2 = _mFromDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nSilverAmt
	{
		[CompilerGenerated]
		get
		{
			return _nSilverAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nSilverAmt_KeyDown);
			TextBox val2 = _nSilverAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nSilverAmt = value;
			val2 = _nSilverAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nGoldAmt
	{
		[CompilerGenerated]
		get
		{
			return _nGoldAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nGoldAmt_KeyDown);
			TextBox val2 = _nGoldAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nGoldAmt = value;
			val2 = _nGoldAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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
			DataGridViewX val2 = _DGV;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting -= val;
			}
			_DGV = value;
			val2 = _DGV;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting += val;
			}
		}
	}

	internal virtual QButton btnFine
	{
		[CompilerGenerated]
		get
		{
			return _btnFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnFine_Click;
			QButton val = _btnFine;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnFine = value;
			val = _btnFine;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnBalanceZoom
	{
		[CompilerGenerated]
		get
		{
			return _BtnBalanceZoom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnBalanceZoom_Click;
			QButton val = _BtnBalanceZoom;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnBalanceZoom = value;
			val = _BtnBalanceZoom;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnPandLZoom
	{
		[CompilerGenerated]
		get
		{
			return _BtnPandLZoom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnPandLZoom_Click;
			QButton val = _BtnPandLZoom;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnPandLZoom = value;
			val = _BtnPandLZoom;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnZoom
	{
		[CompilerGenerated]
		get
		{
			return _btnZoom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnZoom_Click;
			QButton val = _btnZoom;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnZoom = value;
			val = _btnZoom;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkOpBal
	{
		[CompilerGenerated]
		get
		{
			return _chkOpBal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkOpBal_CheckedChanged;
			CheckBox val = _chkOpBal;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkOpBal = value;
			val = _chkOpBal;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkTodayBal
	{
		[CompilerGenerated]
		get
		{
			return _chkTodayBal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkTodayBal_CheckedChanged;
			CheckBox val = _chkTodayBal;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkTodayBal = value;
			val = _chkTodayBal;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	public RP_BALANCE()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += RP_BALANCE_Load;
		((Form)this).Deactivate += RP_BALANCE_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_BALANCE_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_BALANCE_KeyDown);
		((Form)this).Closed += RP_BALANCE_Closed;
		((Form)this).Activated += RP_BALANCE_Activated;
		Gr1Amt = 0.0;
		Gr2Amt = 0.0;
		Gr3Amt = 0.0;
		Gr4Amt = 0.0;
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
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Expected O, but got Unknown
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Expected O, but got Unknown
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Expected O, but got Unknown
		//IL_0527: Unknown result type (might be due to invalid IL or missing references)
		//IL_0531: Expected O, but got Unknown
		//IL_064f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0659: Expected O, but got Unknown
		//IL_06bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c6: Expected O, but got Unknown
		//IL_0770: Unknown result type (might be due to invalid IL or missing references)
		//IL_077a: Expected O, but got Unknown
		//IL_07dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e7: Expected O, but got Unknown
		//IL_08bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c9: Expected O, but got Unknown
		//IL_0937: Unknown result type (might be due to invalid IL or missing references)
		//IL_0941: Expected O, but got Unknown
		//IL_0ce7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d86: Expected O, but got Unknown
		//IL_0da9: Unknown result type (might be due to invalid IL or missing references)
		//IL_100c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1030: Unknown result type (might be due to invalid IL or missing references)
		//IL_1054: Unknown result type (might be due to invalid IL or missing references)
		//IL_1078: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ab: Expected O, but got Unknown
		//IL_10ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_1331: Unknown result type (might be due to invalid IL or missing references)
		//IL_1355: Unknown result type (might be due to invalid IL or missing references)
		//IL_1379: Unknown result type (might be due to invalid IL or missing references)
		//IL_139d: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d0: Expected O, but got Unknown
		//IL_13f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1656: Unknown result type (might be due to invalid IL or missing references)
		//IL_167a: Unknown result type (might be due to invalid IL or missing references)
		//IL_169e: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_16eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f5: Expected O, but got Unknown
		//IL_1715: Unknown result type (might be due to invalid IL or missing references)
		//IL_1978: Unknown result type (might be due to invalid IL or missing references)
		//IL_199c: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a17: Expected O, but got Unknown
		//IL_1a37: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d06: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d39: Expected O, but got Unknown
		//IL_1d5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2007: Unknown result type (might be due to invalid IL or missing references)
		//IL_202b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2054: Unknown result type (might be due to invalid IL or missing references)
		//IL_205e: Expected O, but got Unknown
		//IL_2081: Unknown result type (might be due to invalid IL or missing references)
		//IL_20f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2101: Expected O, but got Unknown
		//IL_21b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_21bc: Expected O, but got Unknown
		//IL_226d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2277: Expected O, but got Unknown
		//IL_2328: Unknown result type (might be due to invalid IL or missing references)
		//IL_2332: Expected O, but got Unknown
		//IL_23c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_23d3: Expected O, but got Unknown
		//IL_2464: Unknown result type (might be due to invalid IL or missing references)
		//IL_246e: Expected O, but got Unknown
		//IL_252c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2536: Expected O, but got Unknown
		//IL_25cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_25d7: Expected O, but got Unknown
		//IL_2678: Unknown result type (might be due to invalid IL or missing references)
		//IL_2682: Expected O, but got Unknown
		//IL_270d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2717: Expected O, but got Unknown
		//IL_27c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_27cc: Expected O, but got Unknown
		//IL_2861: Unknown result type (might be due to invalid IL or missing references)
		//IL_286b: Expected O, but got Unknown
		//IL_28e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_28f3: Expected O, but got Unknown
		//IL_29cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_29d5: Expected O, but got Unknown
		//IL_2a3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a48: Expected O, but got Unknown
		//IL_2aee: Unknown result type (might be due to invalid IL or missing references)
		//IL_2af8: Expected O, but got Unknown
		//IL_2bab: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bb5: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_BALANCE));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		PanelSale = new Panel();
		btnFine = new QButton();
		BtnBalanceZoom = new QButton();
		BtnPandLZoom = new QButton();
		btnZoom = new QButton();
		BtnTrialBalance = new QButton();
		BtnPandL = new QButton();
		Btnbalsheet = new QButton();
		Label1 = new Label();
		Label2 = new Label();
		Label4 = new Label();
		tLcCode = new TextBox();
		tLcName = new TextBox();
		Label6 = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		nSilverAmt = new TextBox();
		nGoldAmt = new TextBox();
		DGV = new DataGridViewX();
		chkOpBal = new CheckBox();
		chkTodayBal = new CheckBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((Control)PanelSale).SuspendLayout();
		((ISupportInitialize)DGV).BeginInit();
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
		lblBook.Text = "Report All";
		lblBook.TextAlign = (ContentAlignment)32;
		((Control)PanelSale).BackColor = SystemColors.ButtonHighlight;
		((Control)PanelSale).Controls.Add((Control)(object)btnFine);
		((Control)PanelSale).Controls.Add((Control)(object)BtnBalanceZoom);
		((Control)PanelSale).Controls.Add((Control)(object)BtnPandLZoom);
		((Control)PanelSale).Controls.Add((Control)(object)btnZoom);
		((Control)PanelSale).Controls.Add((Control)(object)BtnTrialBalance);
		((Control)PanelSale).Controls.Add((Control)(object)BtnPandL);
		((Control)PanelSale).Controls.Add((Control)(object)Btnbalsheet);
		((Control)PanelSale).Location = new Point(237, 157);
		((Control)PanelSale).Name = "PanelSale";
		((Control)PanelSale).Size = new Size(663, 174);
		((Control)PanelSale).TabIndex = 9;
		((QControl)btnFine).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnFine).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFine).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnFine).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnFine).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnFine).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnFine).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnFine).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnFine).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnFine).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnFine).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnFine).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnFine).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnFine).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnFine.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFine.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFine.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFine.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnFine.Image = null;
		((QControl)btnFine).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnFine).Location = new Point(285, 116);
		((Control)btnFine).Margin = new Padding(3, 6, 3, 6);
		((Control)btnFine).Name = "btnFine";
		((Control)btnFine).Size = new Size(143, 37);
		((Control)btnFine).TabIndex = 7;
		btnFine.Text = "Total Fine Report";
		((QControl)BtnBalanceZoom).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnBalanceZoom).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnBalanceZoom).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnBalanceZoom).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnBalanceZoom).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnBalanceZoom).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnBalanceZoom).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnBalanceZoom).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnBalanceZoom).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnBalanceZoom).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnBalanceZoom).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnBalanceZoom).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnBalanceZoom).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnBalanceZoom).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnBalanceZoom.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnBalanceZoom.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnBalanceZoom.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnBalanceZoom.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnBalanceZoom.Image = null;
		((QControl)BtnBalanceZoom).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnBalanceZoom).Location = new Point(441, 67);
		((Control)BtnBalanceZoom).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnBalanceZoom).Name = "BtnBalanceZoom";
		((Control)BtnBalanceZoom).Size = new Size(143, 37);
		((Control)BtnBalanceZoom).TabIndex = 5;
		BtnBalanceZoom.Text = "Balance Zoom";
		((QControl)BtnPandLZoom).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnPandLZoom).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnPandLZoom).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnPandLZoom).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnPandLZoom).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnPandLZoom).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnPandLZoom).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnPandLZoom).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnPandLZoom).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnPandLZoom).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnPandLZoom).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnPandLZoom).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnPandLZoom).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnPandLZoom).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnPandLZoom.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnPandLZoom.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnPandLZoom.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnPandLZoom.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnPandLZoom.Image = null;
		((QControl)BtnPandLZoom).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnPandLZoom).Location = new Point(285, 67);
		((Control)BtnPandLZoom).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnPandLZoom).Name = "BtnPandLZoom";
		((Control)BtnPandLZoom).Size = new Size(143, 37);
		((Control)BtnPandLZoom).TabIndex = 4;
		BtnPandLZoom.Text = "P / L  Zoom";
		((QControl)btnZoom).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnZoom).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnZoom).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnZoom).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnZoom).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnZoom).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnZoom).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnZoom).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnZoom).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnZoom).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnZoom).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnZoom).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnZoom).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnZoom).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnZoom.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnZoom.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnZoom.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnZoom.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnZoom.Image = null;
		((QControl)btnZoom).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnZoom).Location = new Point(127, 67);
		((Control)btnZoom).Margin = new Padding(3, 6, 3, 6);
		((Control)btnZoom).Name = "btnZoom";
		((Control)btnZoom).Size = new Size(143, 37);
		((Control)btnZoom).TabIndex = 3;
		btnZoom.Text = "Trial Zoom";
		((QControl)BtnTrialBalance).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnTrialBalance).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnTrialBalance).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnTrialBalance).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnTrialBalance).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnTrialBalance).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnTrialBalance).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnTrialBalance).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnTrialBalance).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnTrialBalance).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnTrialBalance).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnTrialBalance).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnTrialBalance).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnTrialBalance).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnTrialBalance.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTrialBalance.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTrialBalance.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTrialBalance.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTrialBalance.Image = null;
		((QControl)BtnTrialBalance).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnTrialBalance).Location = new Point(127, 18);
		((Control)BtnTrialBalance).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnTrialBalance).Name = "BtnTrialBalance";
		((Control)BtnTrialBalance).Size = new Size(143, 37);
		((Control)BtnTrialBalance).TabIndex = 0;
		BtnTrialBalance.Text = "Trial Balance";
		((QControl)BtnPandL).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnPandL).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnPandL).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnPandL).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnPandL).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnPandL).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnPandL).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnPandL).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnPandL).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnPandL).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnPandL).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnPandL).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnPandL).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnPandL).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnPandL.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnPandL.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnPandL.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnPandL.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnPandL.Image = null;
		((QControl)BtnPandL).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnPandL).Location = new Point(285, 18);
		((Control)BtnPandL).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnPandL).Name = "BtnPandL";
		((Control)BtnPandL).Size = new Size(143, 37);
		((Control)BtnPandL).TabIndex = 1;
		BtnPandL.Text = "Profit and Loss";
		((QControl)Btnbalsheet).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)Btnbalsheet).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)Btnbalsheet).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)Btnbalsheet).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)Btnbalsheet).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)Btnbalsheet).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)Btnbalsheet).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)Btnbalsheet).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)Btnbalsheet).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)Btnbalsheet).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)Btnbalsheet).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)Btnbalsheet).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)Btnbalsheet).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)Btnbalsheet).ColorScheme).InheritCurrentThemeFromGlobal = false;
		Btnbalsheet.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		Btnbalsheet.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		Btnbalsheet.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		Btnbalsheet.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		Btnbalsheet.Image = null;
		((QControl)Btnbalsheet).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)Btnbalsheet).Location = new Point(441, 18);
		((Control)Btnbalsheet).Margin = new Padding(3, 6, 3, 6);
		((Control)Btnbalsheet).Name = "Btnbalsheet";
		((Control)Btnbalsheet).Size = new Size(143, 37);
		((Control)Btnbalsheet).TabIndex = 2;
		Btnbalsheet.Text = "Balance Sheet";
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(436, 97);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(111, 20);
		((Control)Label1).TabIndex = 1160;
		Label1.Text = "Gold Rate 10 gm";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(446, 63);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(102, 20);
		((Control)Label2).TabIndex = 1162;
		Label2.Text = "As On Date";
		Label2.TextAlign = (ContentAlignment)64;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(433, 127);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(114, 20);
		((Control)Label4).TabIndex = 1171;
		Label4.Text = "Silver Rate 10 gm";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcCode).Location = new Point(708, 64);
		((TextBoxBase)tLcCode).MaxLength = 8;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(55, 23);
		((Control)tLcCode).TabIndex = 2;
		tLcCode.TextAlign = (HorizontalAlignment)2;
		((Control)tLcCode).Visible = false;
		((TextBoxBase)tLcName).BackColor = Color.White;
		((Control)tLcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLcName).Location = new Point(769, 64);
		((TextBoxBase)tLcName).MaxLength = 8;
		((Control)tLcName).Name = "tLcName";
		((Control)tLcName).Size = new Size(216, 23);
		((Control)tLcName).TabIndex = 1177;
		((Control)tLcName).Visible = false;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(641, 64);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(60, 20);
		((Control)Label6).TabIndex = 1176;
		Label6.Text = "lc Code";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)Label6).Visible = false;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(554, 64);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(387, 63);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((Control)mFromDt).Visible = false;
		((TextBoxBase)nSilverAmt).BackColor = Color.White;
		((Control)nSilverAmt).Font = new Font("Tahoma", 9f);
		((Control)nSilverAmt).Location = new Point(554, 126);
		((TextBoxBase)nSilverAmt).MaxLength = 6;
		((Control)nSilverAmt).Name = "nSilverAmt";
		((Control)nSilverAmt).Size = new Size(76, 22);
		((Control)nSilverAmt).TabIndex = 1179;
		nSilverAmt.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nGoldAmt).BackColor = Color.White;
		((Control)nGoldAmt).Font = new Font("Tahoma", 9f);
		((Control)nGoldAmt).Location = new Point(554, 95);
		((TextBoxBase)nGoldAmt).MaxLength = 6;
		((Control)nGoldAmt).Name = "nGoldAmt";
		((Control)nGoldAmt).Size = new Size(76, 22);
		((Control)nGoldAmt).TabIndex = 1178;
		nGoldAmt.TextAlign = (HorizontalAlignment)1;
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
		((Control)DGV).Location = new Point(13, 349);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
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
		((Control)DGV).Size = new Size(1158, 204);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 1180;
		((ButtonBase)chkOpBal).BackColor = Color.Transparent;
		((Control)chkOpBal).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkOpBal).ForeColor = Color.Black;
		((Control)chkOpBal).Location = new Point(655, 97);
		((Control)chkOpBal).Name = "chkOpBal";
		((Control)chkOpBal).RightToLeft = (RightToLeft)0;
		((Control)chkOpBal).Size = new Size(141, 20);
		((Control)chkOpBal).TabIndex = 1181;
		((ButtonBase)chkOpBal).Text = "Opning Balance";
		((ButtonBase)chkOpBal).UseVisualStyleBackColor = false;
		((ButtonBase)chkTodayBal).BackColor = Color.Transparent;
		((Control)chkTodayBal).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkTodayBal).ForeColor = Color.Black;
		((Control)chkTodayBal).Location = new Point(655, 127);
		((Control)chkTodayBal).Name = "chkTodayBal";
		((Control)chkTodayBal).RightToLeft = (RightToLeft)0;
		((Control)chkTodayBal).Size = new Size(141, 20);
		((Control)chkTodayBal).TabIndex = 1182;
		((ButtonBase)chkTodayBal).Text = "ToDay Balance";
		((ButtonBase)chkTodayBal).UseVisualStyleBackColor = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)chkTodayBal);
		((Control)this).Controls.Add((Control)(object)chkOpBal);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)nSilverAmt);
		((Control)this).Controls.Add((Control)(object)nGoldAmt);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)PanelSale);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)tLcName);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_BALANCE";
		((Form)this).Text = "Report All";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((Control)PanelSale).ResumeLayout(false);
		((ISupportInitialize)DGV).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void DGV_CLEAR()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_08b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bf: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).AutoGenerateColumns = false;
		((DataGridView)DGV).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(35.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Code");
			((DataGridView)DGV).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Gr Name");
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(130.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Cl Pcs");
			((DataGridView)DGV).Columns[3].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[3].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Pcs Val");
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "ClNwt");
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Format = "N3";
			if (Operators.CompareString(DC_Main.MsBalanceSheetType, "A", false) == 0)
			{
				((DataGridView)DGV).Columns.Add("", "ClFine");
				((DataGridView)DGV).Columns[6].Visible = false;
				((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[6].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV).Columns.Add("", "AcFine");
				((DataGridView)DGV).Columns[7].Visible = false;
				((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV).Columns.Add("", "Net Amt");
				((DataGridView)DGV).Columns[8].Width = (int)Math.Round(110.0 * ColCon);
				((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[8].DefaultCellStyle.Format = "N2";
			}
			else
			{
				((DataGridView)DGV).Columns.Add("", "ClFine");
				((DataGridView)DGV).Columns[6].Width = (int)Math.Round(85.0 * ColCon);
				((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[6].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV).Columns.Add("", "AcFine");
				((DataGridView)DGV).Columns[7].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV).Columns.Add("", "Fine Val");
				((DataGridView)DGV).Columns[8].Width = (int)Math.Round(110.0 * ColCon);
				((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[8].DefaultCellStyle.Format = "N2";
			}
			((DataGridView)DGV).Columns.Add("", "Total Val");
			((DataGridView)DGV).Columns[9].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "Balance Val");
			((DataGridView)DGV).Columns[10].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "Ac Code");
			((DataGridView)DGV).Columns[11].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV).Columns.Add("", "Ld Code");
			((DataGridView)DGV).Columns[12].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			Dgv_Fill();
		}
	}

	private void Dgv_Fill()
	{
		Ac_Final.Trading_Stock(Conversions.ToDate(mToDt.Text), Conversions.ToString(Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)tLcCode.Text)), Conversion.Val(nGoldAmt.Text), Conversion.Val(nSilverAmt.Text));
		DC_Main.R = 0;
		if (Ac_Final.DtTradStock == null)
		{
			return;
		}
		checked
		{
			int num = Ac_Final.DtTradStock.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				DataGridViewX dGV = DGV;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClPcs"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClNwt"])) != 0.0)
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV)[1, DC_Main.R].Value = Operators.ConcatenateObject(Ac_Final.DtTradStock.Rows[DC_Main.M]["Code"], (object)"");
					((DataGridView)dGV)[2, DC_Main.R].Value = Operators.ConcatenateObject(Ac_Final.DtTradStock.Rows[DC_Main.M]["Name"], (object)"");
					((DataGridView)dGV)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClPcs"]);
					if (Operators.CompareString(DC_Main.MsBalanceSheetType, "A", false) == 0)
					{
						((DataGridView)dGV)[4, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClPcs"])) * Conversion.Val(RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["PCS_RATE"]))), "0.00");
						((DataGridView)dGV)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClNwt"]);
						((DataGridView)dGV)[6, DC_Main.R].Value = 0;
						((DataGridView)dGV)[8, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClNwt"])) * Conversion.Val(RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClRate"]))), "0.00");
					}
					else
					{
						((DataGridView)dGV)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["AVG_AMT"]);
						((DataGridView)dGV)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClNwt"]);
						((DataGridView)dGV)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClFine"]);
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(Ac_Final.DtTradStock.Rows[DC_Main.M]["ItType"], (object)""), (object)"G", false))
						{
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(Ac_Final.DtTradStock.Rows[DC_Main.M]["Code"], (object)""), (object)"GO", false))
							{
								((DataGridView)dGV)[7, DC_Main.R].Value = Strings.Format((object)(0.0 - Ac_Final.AcLdrFineGold), "0.000");
								double num2 = ((Ac_Final.AcLdrFineGold > 0.0) ? (Conversion.Val(RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClFine"])) - Ac_Final.AcLdrFineGold) : ((!(Ac_Final.AcLdrFineGold < 0.0)) ? Conversion.Val(RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClFine"])) : (Conversion.Val(RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClFine"])) + Math.Abs(Ac_Final.AcLdrFineGold))));
								if (Conversion.Val(nGoldAmt.Text) != 0.0)
								{
									((DataGridView)dGV)[8, DC_Main.R].Value = num2 * (Conversion.Val(nGoldAmt.Text) / 10.0);
								}
							}
							else if (Conversion.Val(nGoldAmt.Text) != 0.0)
							{
								((DataGridView)dGV)[8, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClFine"])) * (Conversion.Val(nGoldAmt.Text) / 10.0);
							}
						}
						else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(Ac_Final.DtTradStock.Rows[DC_Main.M]["ItType"], (object)""), (object)"S", false))
						{
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(Ac_Final.DtTradStock.Rows[DC_Main.M]["Code"], (object)""), (object)"SL", false))
							{
								((DataGridView)dGV)[7, DC_Main.R].Value = Strings.Format((object)(0.0 - Ac_Final.AcLdrFineSilver), "0.00");
								double num3 = ((Ac_Final.AcLdrFineSilver > 0.0) ? (Conversion.Val(RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClFine"])) - Ac_Final.AcLdrFineSilver) : ((!(Ac_Final.AcLdrFineSilver < 0.0)) ? Conversion.Val(RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClFine"])) : (Conversion.Val(RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClFine"])) + Math.Abs(Ac_Final.AcLdrFineSilver))));
								if (Conversion.Val(nSilverAmt.Text) != 0.0)
								{
									((DataGridView)dGV)[8, DC_Main.R].Value = num3 * (Conversion.Val(nSilverAmt.Text) / 10.0);
								}
							}
							else if (Conversion.Val(nSilverAmt.Text) != 0.0)
							{
								((DataGridView)dGV)[8, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["ClFine"])) * (Conversion.Val(nSilverAmt.Text) / 10.0);
							}
						}
					}
					((DataGridView)dGV)[9, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[8, DC_Main.R].Value, (object)"")) + Conversion.Val(Operators.ConcatenateObject(((DataGridView)dGV)[4, DC_Main.R].Value, (object)""));
					((DataGridView)dGV)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(Ac_Final.DtTradStock.Rows[DC_Main.M]["TRAD_AMT"]);
					((DataGridView)dGV)[11, DC_Main.R].Value = Operators.ConcatenateObject(Ac_Final.DtTradStock.Rows[DC_Main.M]["CLOSING_AC"], (object)"");
					((DataGridView)dGV)[12, DC_Main.R].Value = Operators.ConcatenateObject(Ac_Final.DtTradStock.Rows[DC_Main.M]["CLG_AC"], (object)"");
					DC_Main.R++;
				}
				dGV = null;
				DC_Main.M++;
			}
		}
	}

	private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
		int columnIndex = e.ColumnIndex;
		if (((uint)(columnIndex - 3) <= 3u || (uint)(columnIndex - 8) <= 2u) && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
		{
			((ConvertEventArgs)e).Value = "";
			e.FormattingApplied = true;
		}
	}

	private void RP_BALANCE_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_09f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fa: Expected O, but got Unknown
		//IL_0a75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a84: Expected O, but got Unknown
		//IL_0b0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1b: Expected O, but got Unknown
		//IL_0b8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b98: Expected O, but got Unknown
		//IL_0c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c59: Expected O, but got Unknown
		//IL_0c78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c87: Expected O, but got Unknown
		//IL_0ca6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb5: Expected O, but got Unknown
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
			foreach (object control3 in ((Control)PanelSale).Controls)
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(control3);
				object obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
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
				((Control)PanelSale).BackColor = Color.Silver;
				DataGridViewX dGV = DGV;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV).BackgroundColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj9 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				Panel panelSale = PanelSale;
				object? obj10 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)panelSale).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewX dGV2 = DGV;
				object? obj11 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV2).BackgroundColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj12 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj13 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj14 = lblBook;
				object? obj15 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj14).ForeColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj16 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				Panel panelSale2 = PanelSale;
				object? obj17 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panelSale2).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				DataGridViewX dGV3 = DGV;
				object? obj18 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV3).BackgroundColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj19 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)nGoldAmt).Font.Size * (1.0 + num2));
				Font font = ((Control)nGoldAmt).Font;
				try
				{
					foreach (Control control4 in ((Control)this).Controls)
					{
						Control val3 = control4;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is DateEdit || val3 is CheckBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
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
					foreach (object control5 in ((Control)PnlBotam).Controls)
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(control5);
						NewLateBinding.LateSet(objectValue3, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
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
			mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
			mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			tLcCode.Text = DC_Main.MLc_code;
			if (DC_Main.MsLcBoxShow)
			{
				((Control)tLcCode).Visible = true;
				((Control)Label6).Visible = true;
			}
			if (Operators.CompareString(DC_Main.MsBalanceSheetType, "A", false) == 0)
			{
				lblBook.Text += " With Amount";
			}
			else
			{
				lblBook.Text += " With Fine";
				Ac_Final.AcLdrFineGold = 0.0;
				Ac_Final.AcLdrFineSilver = 0.0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND CO_BOOK = '888' "));
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					if (DC_Main.MsOnlyOpBalnce)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE ,SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END) ELSE 0 END) as GoldWt,sum(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END) ELSE 0 END) as SilverWt FROM AC_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy")), (object)"' and AC_CODE NOT IN ('00045','00050','00098') "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  GROUP BY  A.AC_CODE "));
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE ,SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END) ELSE 0 END) as GoldWt,sum(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END) ELSE 0 END) as SilverWt FROM AC_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)"  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'  and AC_CODE NOT IN ('00045','00050','00098') "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"  GROUP BY  A.AC_CODE "));
					}
					DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					double num5 = default(double);
					double num6 = default(double);
					double num7 = default(double);
					double num8 = default(double);
					if (dataTable2.Rows.Count > 0)
					{
						int num4 = dataTable2.Rows.Count - 1;
						DC_Main.M = 0;
						while (DC_Main.M <= num4)
						{
							if (Operators.ConditionalCompareObjectGreater(dataTable2.Rows[DC_Main.M]["GoldWt"], (object)0, false))
							{
								num5 += Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["GoldWt"]), "0.000"));
							}
							else
							{
								num6 += Conversions.ToDouble(Strings.Format((object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["GoldWt"]))), "0.000"));
							}
							if (Operators.ConditionalCompareObjectGreater(dataTable2.Rows[DC_Main.M]["SilverWt"], (object)0, false))
							{
								num7 += Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["SilverWt"]), "0.000"));
							}
							else
							{
								num8 += Conversions.ToDouble(Strings.Format((object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["SilverWt"]))), "0.000"));
							}
							DC_Main.M++;
						}
					}
					Ac_Final.AcLdrFineGold = num5 - num6;
					Ac_Final.AcLdrFineSilver = num7 - num8;
				}
			}
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
		tLcCode.Text = DC_Main.MLc_code;
		mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		DC_Main.RsQry = "SELECT VCH_DATE,FINE_GL_RATE,FINE_SL_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY VCH_DATE,FINE_GL_RATE,FINE_SL_RATE ORDER BY VCH_DATE DESC ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			nGoldAmt.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_GL_RATE"])), "0.00");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_SL_RATE"])) != 0.0)
			{
				nSilverAmt.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_SL_RATE"])) / 100.0), "0.00");
			}
		}
		DGV_CLEAR();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_BALANCE_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_BALANCE_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_BALANCE_KeyDown(object sender, KeyEventArgs e)
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
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_BALANCE_Closed(object sender, EventArgs e)
	{
		DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Delete from AC_DATA where CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '999' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)"")));
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
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

	private void cboCity_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboArea_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void cboItemTyp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void AcGroupBal()
	{
		Gr1Amt = 0.0;
		Gr2Amt = 0.0;
		Gr3Amt = 0.0;
		Gr4Amt = 0.0;
		DC_Main.X = 0;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT  SUM(CR_AMT ) AS Gr1Tot, SUM(DR_AMT ) AS Gr2Tot  FROM (LEDR_AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE) LEFT JOIN AC_GROUP AS C ON B.CO_CODE = C.CO_CODE AND B.AC_GR = C.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" And C.AC_MAIN_GR < '3'"));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			while (DC_Main.X < DC_Main.Rshlp.Rows.Count)
			{
				object Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Gr1Tot"], (object)"");
				if (DC_Main.Fnv(ref Value) != 0.0)
				{
					ref double gr1Amt = ref Gr1Amt;
					double num = gr1Amt;
					Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Gr1Tot"], (object)"");
					gr1Amt = num + DC_Main.Fnv(ref Value);
				}
				Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Gr2Tot"], (object)"");
				if (DC_Main.Fnv(ref Value) != 0.0)
				{
					ref double gr2Amt = ref Gr2Amt;
					double num2 = gr2Amt;
					Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Gr2Tot"], (object)"");
					gr2Amt = num2 + DC_Main.Fnv(ref Value);
				}
				DC_Main.X++;
			}
			DC_Main.X = 0;
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT  SUM(CR_AMT ) AS Gr3Tot, SUM(DR_AMT ) AS Gr4Tot  FROM (LEDR_AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE) LEFT JOIN AC_GROUP AS C ON B.CO_CODE = C.CO_CODE AND B.AC_GR = C.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" And C.AC_MAIN_GR >= '3'"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			while (DC_Main.X < DC_Main.Rshlp.Rows.Count)
			{
				object Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Gr3Tot"], (object)"");
				if (DC_Main.Fnv(ref Value) != 0.0)
				{
					ref double gr3Amt = ref Gr3Amt;
					double num3 = gr3Amt;
					Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Gr3Tot"], (object)"");
					gr3Amt = num3 + DC_Main.Fnv(ref Value);
				}
				Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Gr4Tot"], (object)"");
				if (DC_Main.Fnv(ref Value) != 0.0)
				{
					ref double gr4Amt = ref Gr4Amt;
					double num4 = gr4Amt;
					Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Gr4Tot"], (object)"");
					gr4Amt = num4 + DC_Main.Fnv(ref Value);
				}
				DC_Main.X++;
			}
		}
	}

	private void BtnTrialBalance_Click(object sender, EventArgs e)
	{
		RptData = "T";
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr[(short)5] = "";
			Cr[(short)6] = "";
		}
		Ac_Final.AcBalInsert(DC_Main.MsOnlyOpBalnce, Conversions.ToDate(mFromDt.Text), Conversions.ToDate(mToDt.Text), RptData, Conversions.ToString(DC_Main.MsTodayBalance), tLcCode.Text);
		AcGroupBal();
		CurFormula = "{LEDR_AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LEDR_AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {LEDR_AC_DATA.VCH_DT} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {LEDR_AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "TRialBalhz";
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'TRIAL BALANCE AS ON " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsCrForName1 = "1Amt";
			DC_Main.MsCrForVal1 = Strings.Format((object)Gr1Amt, "0.00");
			DC_Main.MsCrForName2 = "2Amt";
			DC_Main.MsCrForVal2 = Strings.Format((object)Gr2Amt, "0.00");
			DC_Main.MsCrForName3 = "3Amt";
			DC_Main.MsCrForVal3 = Strings.Format((object)Gr3Amt, "0.00");
			DC_Main.MsCrForName4 = "4Amt";
			DC_Main.MsCrForVal4 = Strings.Format((object)Gr4Amt, "0.00");
			DC_Main.MsCrForName5 = "13Amt";
			DC_Main.MsCrForVal5 = Strings.Format((object)(Gr1Amt + Gr3Amt), "0.00");
			DC_Main.MsCrForName6 = "24Amt";
			DC_Main.MsCrForVal6 = Strings.Format((object)(Gr2Amt + Gr4Amt), "0.00");
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TRialBalhz.RPT";
			Cr[(short)0] = "RptTitel = 'TRIAL BALANCE AS ON " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr[(short)1] = ("1Amt = " + Strings.Format((object)Gr1Amt, "0.00")) ?? "";
			Cr[(short)2] = ("2Amt = " + Strings.Format((object)Gr2Amt, "0.00")) ?? "";
			Cr[(short)3] = ("3Amt = " + Strings.Format((object)Gr3Amt, "0.00")) ?? "";
			Cr[(short)4] = ("4Amt = " + Strings.Format((object)Gr4Amt, "0.00")) ?? "";
			Cr[(short)5] = ("13Amt = " + Strings.Format((object)(Gr1Amt + Gr3Amt), "0.00")) ?? "";
			Cr[(short)6] = ("24Amt = " + Strings.Format((object)(Gr2Amt + Gr4Amt), "0.00")) ?? "";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			CurFormula = "";
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

	private void BtnPandL_Click(object sender, EventArgs e)
	{
		RptData = "P";
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr[(short)5] = "";
			Cr[(short)6] = "";
		}
		if (Operators.CompareString(RptData, "T", false) != 0)
		{
			Ac_Final.Trading_Stock(Conversions.ToDate(mToDt.Text), Conversions.ToString(Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)tLcCode.Text)), Conversion.Val(nGoldAmt.Text), Conversion.Val(nSilverAmt.Text));
		}
		Ac_Final.AcBalInsert(DC_Main.MsOnlyOpBalnce, Conversions.ToDate(mFromDt.Text), Conversions.ToDate(mToDt.Text), RptData, Conversions.ToString(DC_Main.MsTodayBalance), tLcCode.Text);
		AcGroupBal();
		CurFormula = "{LEDR_AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LEDR_AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {LEDR_AC_DATA.VCH_DT} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {LEDR_AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "ProfitLossHz";
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Profit and Loss AS ON " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ProfitLossHz.RPT";
			Cr[(short)0] = "RptTitel = 'Profit and Loss AS ON " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.SelectionFormula = CurFormula;
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			CurFormula = "";
		}
	}

	private void Btnbalsheet_Click(object sender, EventArgs e)
	{
		RptData = "B";
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr[(short)0] = "";
			Cr[(short)1] = "";
			Cr[(short)2] = "";
			Cr[(short)3] = "";
			Cr[(short)4] = "";
			Cr[(short)5] = "";
			Cr[(short)6] = "";
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\BalanceHz.RPT";
		}
		if (Operators.CompareString(RptData, "T", false) != 0)
		{
			Ac_Final.Trading_Stock(Conversions.ToDate(mToDt.Text), Conversions.ToString(Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)tLcCode.Text)), Conversion.Val(nGoldAmt.Text), Conversion.Val(nSilverAmt.Text));
		}
		Ac_Final.AcBalInsert(DC_Main.MsOnlyOpBalnce, Conversions.ToDate(mFromDt.Text), Conversions.ToDate(mToDt.Text), RptData, Conversions.ToString(DC_Main.MsTodayBalance), tLcCode.Text);
		AcGroupBal();
		CurFormula = "{LEDR_AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LEDR_AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {LEDR_AC_DATA.VCH_DT} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			CurFormula = CurFormula + " And {LEDR_AC_DATA.LC_CODE} = '" + tLcCode.Text + "'";
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "BalanceHz";
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'Balancesheet AS ON " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsCrForName1 = "1Amt";
			DC_Main.MsCrForVal1 = Strings.Format((object)Gr1Amt, "0.00");
			DC_Main.MsCrForName2 = "2Amt";
			DC_Main.MsCrForVal2 = Strings.Format((object)Gr2Amt, "0.00");
			DC_Main.RptFormula = CurFormula;
			Module_Save.ShowReportPreview();
			CurFormula = "";
		}
		else
		{
			Cr.SelectionFormula = CurFormula;
			Cr[(short)0] = "RptTitel = 'Balancesheet AS ON " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr[(short)1] = ("1Amt = " + Strings.Format((object)Gr1Amt, "0.00")) ?? "";
			Cr[(short)2] = ("2Amt = " + Strings.Format((object)Gr2Amt, "0.00")) ?? "";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			CurFormula = "";
		}
	}

	private void nGoldAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nGoldAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nGoldAmt.Text)), "0.00");
			DGV_CLEAR();
			SendKeys.Send("{TAB}");
		}
	}

	private void nSilverAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nSilverAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nSilverAmt.Text)), "0.00");
			DGV_CLEAR();
			SendKeys.Send("{TAB}");
		}
	}

	private void mToDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToDt).SelectionStart = 0;
		((TextBoxBase)mToDt).SelectionLength = Strings.Len(mToDt.Text);
	}

	private void RP_BALANCE_Activated(object sender, EventArgs e)
	{
		if (DC_Main.MsOnlyOpBalnce)
		{
			chkOpBal.Checked = true;
		}
		else
		{
			chkOpBal.Checked = false;
		}
		if (DC_Main.MsTodayBalance)
		{
			chkTodayBal.Checked = true;
		}
		else
		{
			chkTodayBal.Checked = false;
		}
		DC_Main.AvgTouch(Conversions.ToDate(mToDt.Text), Conversions.ToString(Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)tLcCode.Text)));
		DC_Main.RsQry = "SELECT VCH_DATE,FINE_GL_RATE,FINE_SL_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY VCH_DATE,FINE_GL_RATE,FINE_SL_RATE ORDER BY VCH_DATE DESC ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			nGoldAmt.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_GL_RATE"])), "0.00");
			if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_SL_RATE"])) != 0.0)
			{
				nSilverAmt.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["FINE_SL_RATE"])) / 100.0), "0.00");
			}
		}
		DGV_CLEAR();
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0764: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.ExeQuteDc("Delete from AC_DATA where CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '999'");
		DC_Main.ExeQuteDc("Delete from AC_DATA where CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '888'");
		DataGridViewX dGV = DGV;
		checked
		{
			int num = ((DataGridView)DGV).Rows.Count - 1;
			DC_Main.R = 0;
			while (DC_Main.R <= num)
			{
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[10, DC_Main.R].Value)) != 0.0)
				{
					object Value;
					DataGridViewCell val;
					if (DateTime.Compare(DC_Main.MCl_dt, DC_Main.MsSysDate) <= 0)
					{
						object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_TYPE,VCH_NO,VCH_DATE,LEDR_KEY,BOOK_NAME,BILL_NO,BILL_DATE,CHQ_NO,AC_CODE,LD_CODE,  CR_AMT,DR_AMT,IT_TYPE,SIGN,FINE_WT,IT_DESC,ENTRY_TIME,HD_VCH_NO,CLR_DATE,DATA_TYPE,DATA_TRFR,MAIN_USER,FINE_RATE,PARTY_AC_CODE)  VALUES ('" + DC_Main.MCo_code + "' ,'" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "' ,'888','CLGBL','00001','" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "','" + DC_Main.MCo_code), ((DataGridView)dGV)[1, DC_Main.R].Value), (object)"','FINAL BALANCE','',NULL,'', '"), ((DataGridView)dGV)[11, DC_Main.R].Value), (object)"','"), ((DataGridView)dGV)[12, DC_Main.R].Value), (object)"', "), (object)" ");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[10, DC_Main.R]).Value);
						double num2 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num2), (object)", 0,'','',0,'','"), (object)Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy")), (object)"','',NULL,'A','N','"), (object)DC_Main.MCo_User), (object)"',0,'')"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_TYPE,VCH_NO,VCH_DATE,LEDR_KEY,BOOK_NAME,BILL_NO,BILL_DATE,CHQ_NO,AC_CODE,LD_CODE,  CR_AMT,DR_AMT,IT_TYPE,SIGN,FINE_WT,IT_DESC,ENTRY_TIME,HD_VCH_NO,CLR_DATE,DATA_TYPE,DATA_TRFR,MAIN_USER,FINE_RATE,PARTY_AC_CODE)  VALUES ('" + DC_Main.MCo_code + "' ,'" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "' ,'888','CLGBL','00001','" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "','" + DC_Main.MCo_code), ((DataGridView)dGV)[1, DC_Main.R].Value), (object)1), (object)"','FINAL BALANCE','',NULL,'','"), ((DataGridView)dGV)[12, DC_Main.R].Value), (object)"', '"), ((DataGridView)dGV)[11, DC_Main.R].Value), (object)"', "), (object)" 0,");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[10, DC_Main.R]).Value);
						double num3 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num3), (object)", '','',0,'','"), (object)Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy")), (object)"','',NULL,'A','N','"), (object)DC_Main.MCo_User), (object)"',0,'')"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					else
					{
						object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_TYPE,VCH_NO,VCH_DATE,LEDR_KEY,BOOK_NAME,BILL_NO,BILL_DATE,CHQ_NO,AC_CODE,LD_CODE,  CR_AMT,DR_AMT,IT_TYPE,SIGN,FINE_WT,IT_DESC,ENTRY_TIME,HD_VCH_NO,CLR_DATE,DATA_TYPE,DATA_TRFR,MAIN_USER,FINE_RATE,PARTY_AC_CODE)  VALUES ('" + DC_Main.MCo_code + "' ,'" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "' ,'888','CLGBL','00001','" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "','" + DC_Main.MCo_code), ((DataGridView)dGV)[1, DC_Main.R].Value), (object)"','FINAL BALANCE','',NULL,'', '"), ((DataGridView)dGV)[11, DC_Main.R].Value), (object)"','"), ((DataGridView)dGV)[12, DC_Main.R].Value), (object)"', "), (object)" ");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[10, DC_Main.R]).Value);
						double num4 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num4), (object)", 0,'','',0,'','"), (object)Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")), (object)"','',NULL,'A','N','"), (object)DC_Main.MCo_User), (object)"',0,'')"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_TYPE,VCH_NO,VCH_DATE,LEDR_KEY,BOOK_NAME,BILL_NO,BILL_DATE,CHQ_NO,AC_CODE,LD_CODE,  CR_AMT,DR_AMT,IT_TYPE,SIGN,FINE_WT,IT_DESC,ENTRY_TIME,HD_VCH_NO,CLR_DATE,DATA_TYPE,DATA_TRFR,MAIN_USER,FINE_RATE,PARTY_AC_CODE)  VALUES ('" + DC_Main.MCo_code + "' ,'" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "' ,'888','CLGBL','00001','" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "','" + DC_Main.MCo_code), ((DataGridView)dGV)[1, DC_Main.R].Value), (object)1), (object)"','FINAL BALANCE','',NULL,'','"), ((DataGridView)dGV)[12, DC_Main.R].Value), (object)"', '"), ((DataGridView)dGV)[11, DC_Main.R].Value), (object)"', "), (object)" 0,");
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[10, DC_Main.R]).Value);
						double num5 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num5), (object)", '','',0,'','"), (object)Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")), (object)"','',NULL,'A','N','"), (object)DC_Main.MCo_User), (object)"',0,'')"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					string[] obj5 = new string[5] { "UPDATE BAL_GR SET TRAD_AMT = ", null, null, null, null };
					Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[10, DC_Main.R]).Value);
					double num6 = DC_Main.Fnv(ref Value);
					val.Value = RuntimeHelpers.GetObjectValue(Value);
					obj5[1] = Conversions.ToString(num6);
					obj5[2] = " WHERE CO_CODE = '";
					obj5[3] = DC_Main.MCo_code;
					obj5[4] = "' AND TRAD_TYPE = '";
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)string.Concat(obj5), ((DataGridView)dGV)[1, DC_Main.R].Value), (object)"'")));
				}
				DC_Main.R++;
			}
			dGV = null;
			Interaction.MsgBox((object)"Closing Stock is Save....", (MsgBoxStyle)0, (object)null);
		}
	}

	private void BtnZoom_Click(object sender, EventArgs e)
	{
		DC_Main.MsRptBalZoomType = "T";
		RP_BAL_ZOOM rP_BAL_ZOOM = new RP_BAL_ZOOM();
		((Form)rP_BAL_ZOOM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
		((Control)rP_BAL_ZOOM).Show();
		((Control)rP_BAL_ZOOM).Focus();
	}

	private void BtnPandLZoom_Click(object sender, EventArgs e)
	{
		DC_Main.MsRptBalZoomType = "P";
		RP_BAL_ZOOM rP_BAL_ZOOM = new RP_BAL_ZOOM();
		((Form)rP_BAL_ZOOM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
		((Control)rP_BAL_ZOOM).Show();
		((Control)rP_BAL_ZOOM).Focus();
	}

	private void BtnBalanceZoom_Click(object sender, EventArgs e)
	{
		DC_Main.MsRptBalZoomType = "B";
		RP_BAL_ZOOM rP_BAL_ZOOM = new RP_BAL_ZOOM();
		((Form)rP_BAL_ZOOM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
		((Control)rP_BAL_ZOOM).Show();
		((Control)rP_BAL_ZOOM).Focus();
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Account now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.ExeQuteDc("Delete from AC_DATA where CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '999'");
			DC_Main.ExeQuteDc("Delete from AC_DATA where CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '888'");
			DC_Main.ExeQuteDc("Delete from LEDR_AC_DATA where CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '888'");
			DC_Main.ExeQuteDc("UPDATE BAL_GR SET TRAD_AMT = 0 WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
			DataGridViewX dGV = DGV;
			checked
			{
				int num = ((DataGridView)DGV).Rows.Count - 1;
				DC_Main.R = 0;
				while (DC_Main.R <= num)
				{
					((DataGridView)dGV)[10, DC_Main.R].Value = "";
					DC_Main.R++;
				}
				dGV = null;
				Interaction.MsgBox((object)"Closing Stock is Delete...", (MsgBoxStyle)0, (object)null);
			}
		}
	}

	private void chkOpBal_CheckedChanged(object sender, EventArgs e)
	{
		if (chkOpBal.Checked)
		{
			chkTodayBal.Checked = false;
		}
		if (chkOpBal.Checked)
		{
			DC_Main.MsTodayBalance = false;
		}
		DC_Main.MsOnlyOpBalnce = Conversions.ToBoolean(Interaction.IIf(chkOpBal.Checked, (object)true, (object)false));
	}

	private void btnFine_Click(object sender, EventArgs e)
	{
		DC_Main.MsRptBalZoomType = "F";
		if (!((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0)) || Operators.CompareString(DC_Main.MsDataType, "C", false) == 0)
		{
			RP_BAL_ZOOM rP_BAL_ZOOM = new RP_BAL_ZOOM();
			((Form)rP_BAL_ZOOM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)rP_BAL_ZOOM).Show();
			((Control)rP_BAL_ZOOM).Focus();
		}
	}

	private void chkTodayBal_CheckedChanged(object sender, EventArgs e)
	{
		if (chkTodayBal.Checked)
		{
			chkOpBal.Checked = false;
		}
		if (chkTodayBal.Checked)
		{
			DC_Main.MsOnlyOpBalnce = false;
		}
		DC_Main.MsTodayBalance = Conversions.ToBoolean(Interaction.IIf(chkTodayBal.Checked, (object)true, (object)false));
	}
}
