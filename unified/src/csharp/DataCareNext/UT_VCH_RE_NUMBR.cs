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
using DevComponents.DotNetBar;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class UT_VCH_RE_NUMBR : Form
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
	[AccessedThroughProperty("Pnl1")]
	private Panel _Pnl1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSales")]
	private QButton _btnSales;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPurc")]
	private QButton _btnPurc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnCash")]
	private QButton _btnCash;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBank")]
	private QButton _btnBank;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnCashPay")]
	private QButton _btnCashPay;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBankPay")]
	private QButton _btnBankPay;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnWhSale")]
	private QButton _btnWhSale;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBookCode")]
	private TextBox _tBookCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSlWithAc")]
	private QButton _btnSlWithAc;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsMast;

	private bool MsgClear;

	private bool UpDown;

	private bool Msgleft;

	private int MsgOldRow;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private DataTable RsData;

	private DataTable RsDetl;

	private double ColCon;

	private string MaxVchNo;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private virtual SimpleButton _BtnSave;

	internal virtual SimpleButton BtnSave
	{
		get
		{
			return _BtnSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnSave = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private virtual SimpleButton _BtnPrint;

	internal virtual SimpleButton BtnPrint
	{
		get
		{
			return _BtnPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnPrint = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Pnl3")]
	private virtual Panel _Pnl3;

	internal virtual Panel Pnl3
	{
		get
		{
			return _Pnl3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Pnl3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Pnl2")]
	private virtual Panel _Pnl2;

	internal virtual Panel Pnl2
	{
		get
		{
			return _Pnl2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Pnl2 = value;
		}
	}

	internal virtual Panel Pnl1
	{
		[CompilerGenerated]
		get
		{
			return _Pnl1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Pnl1_DoubleClick;
			Panel val = _Pnl1;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_Pnl1 = value;
			val = _Pnl1;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual QButton btnSales
	{
		[CompilerGenerated]
		get
		{
			return _btnSales;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnSales_Click;
			QButton val = _btnSales;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSales = value;
			val = _btnSales;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnPurc
	{
		[CompilerGenerated]
		get
		{
			return _btnPurc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnPurc_Click;
			QButton val = _btnPurc;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnPurc = value;
			val = _btnPurc;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnCash
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
			QButton val = _btnCash;
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

	internal virtual QButton btnBank
	{
		[CompilerGenerated]
		get
		{
			return _btnBank;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnBank_Click;
			QButton val = _btnBank;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBank = value;
			val = _btnBank;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnCashPay
	{
		[CompilerGenerated]
		get
		{
			return _btnCashPay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnCashPay_Click;
			QButton val = _btnCashPay;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnCashPay = value;
			val = _btnCashPay;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnBankPay
	{
		[CompilerGenerated]
		get
		{
			return _btnBankPay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnBankPay_Click;
			QButton val = _btnBankPay;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBankPay = value;
			val = _btnBankPay;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnWhSale
	{
		[CompilerGenerated]
		get
		{
			return _btnWhSale;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnWhSale_Click;
			QButton val = _btnWhSale;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWhSale = value;
			val = _btnWhSale;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabMenu")]
	private virtual SuperTabControl _TabMenu;

	internal virtual SuperTabControl TabMenu
	{
		get
		{
			return _TabMenu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabMenu = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPanel3")]
	private virtual SuperTabControlPanel _TabPanel3;

	internal virtual SuperTabControlPanel TabPanel3
	{
		get
		{
			return _TabPanel3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabPanel3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Tab3")]
	private virtual SuperTabItem _Tab3;

	internal virtual SuperTabItem Tab3
	{
		get
		{
			return _Tab3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Tab3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPanel2")]
	private virtual SuperTabControlPanel _TabPanel2;

	internal virtual SuperTabControlPanel TabPanel2
	{
		get
		{
			return _TabPanel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabPanel2 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Tab2")]
	private virtual SuperTabItem _Tab2;

	internal virtual SuperTabItem Tab2
	{
		get
		{
			return _Tab2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Tab2 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TabPanel1")]
	private virtual SuperTabControlPanel _TabPanel1;

	internal virtual SuperTabControlPanel TabPanel1
	{
		get
		{
			return _TabPanel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TabPanel1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Tab1")]
	private virtual SuperTabItem _Tab1;

	internal virtual SuperTabItem Tab1
	{
		get
		{
			return _Tab1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Tab1 = value;
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
	[AccessedThroughProperty("tBookName")]
	private virtual TextBox _tBookName;

	internal virtual TextBox tBookName
	{
		get
		{
			return _tBookName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tBookName = value;
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
	[AccessedThroughProperty("ProgressBar1")]
	private virtual ProgressBar _ProgressBar1;

	internal virtual ProgressBar ProgressBar1
	{
		get
		{
			return _ProgressBar1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_ProgressBar1 = value;
		}
	}

	internal virtual QButton btnSlWithAc
	{
		[CompilerGenerated]
		get
		{
			return _btnSlWithAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSlWithAc_Click;
			QButton val = _btnSlWithAc;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSlWithAc = value;
			val = _btnSlWithAc;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public UT_VCH_RE_NUMBR()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		((Form)this).Activated += UT_VCH_RE_NUMBR_Activated;
		((Form)this).Deactivate += UT_VCH_RE_NUMBR_Deactivate;
		((Control)this).KeyDown += new KeyEventHandler(UT_VCH_RE_NUMBR_KeyDown);
		((Form)this).Closed += UT_VCH_RE_NUMBR_Closed;
		((Form)this).Load += UT_VCH_RE_NUMBR_Load;
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
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Expected O, but got Unknown
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Expected O, but got Unknown
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Expected O, but got Unknown
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Expected O, but got Unknown
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ff: Expected O, but got Unknown
		//IL_071b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0725: Expected O, but got Unknown
		//IL_0788: Unknown result type (might be due to invalid IL or missing references)
		//IL_0792: Expected O, but got Unknown
		//IL_083a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0844: Expected O, but got Unknown
		//IL_08a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b1: Expected O, but got Unknown
		//IL_0a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6f: Expected O, but got Unknown
		//IL_0ab5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abf: Expected O, but got Unknown
		//IL_0f3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fde: Expected O, but got Unknown
		//IL_1001: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e0: Expected O, but got Unknown
		//IL_1161: Unknown result type (might be due to invalid IL or missing references)
		//IL_116b: Expected O, but got Unknown
		//IL_11ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f9: Expected O, but got Unknown
		//IL_1497: Unknown result type (might be due to invalid IL or missing references)
		//IL_14bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_14df: Unknown result type (might be due to invalid IL or missing references)
		//IL_1503: Unknown result type (might be due to invalid IL or missing references)
		//IL_152c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1536: Expected O, but got Unknown
		//IL_155c: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1808: Unknown result type (might be due to invalid IL or missing references)
		//IL_182c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1855: Unknown result type (might be due to invalid IL or missing references)
		//IL_185f: Expected O, but got Unknown
		//IL_1885: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b31: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b55: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b88: Expected O, but got Unknown
		//IL_1bae: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e12: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e36: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eb1: Expected O, but got Unknown
		//IL_1ed7: Unknown result type (might be due to invalid IL or missing references)
		//IL_213b: Unknown result type (might be due to invalid IL or missing references)
		//IL_215f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2183: Unknown result type (might be due to invalid IL or missing references)
		//IL_21a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_21da: Expected O, but got Unknown
		//IL_2200: Unknown result type (might be due to invalid IL or missing references)
		//IL_2464: Unknown result type (might be due to invalid IL or missing references)
		//IL_2488: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_24d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_24f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2503: Expected O, but got Unknown
		//IL_2526: Unknown result type (might be due to invalid IL or missing references)
		//IL_278a: Unknown result type (might be due to invalid IL or missing references)
		//IL_27ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_27f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_281f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2829: Expected O, but got Unknown
		//IL_284c: Unknown result type (might be due to invalid IL or missing references)
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_VCH_RE_NUMBR));
		lblBook = new Label();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		TabMenu = new SuperTabControl();
		TabPanel1 = new SuperTabControlPanel();
		Pnl1 = new Panel();
		btnSlWithAc = new QButton();
		ProgressBar1 = new ProgressBar();
		tBookCode = new TextBox();
		tBookName = new TextBox();
		Label1 = new Label();
		btnWhSale = new QButton();
		btnBankPay = new QButton();
		btnCashPay = new QButton();
		btnBank = new QButton();
		btnCash = new QButton();
		btnPurc = new QButton();
		btnSales = new QButton();
		Tab1 = new SuperTabItem();
		TabPanel2 = new SuperTabControlPanel();
		Pnl2 = new Panel();
		Tab2 = new SuperTabItem();
		TabPanel3 = new SuperTabControlPanel();
		Pnl3 = new Panel();
		Tab3 = new SuperTabItem();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)TabMenu).BeginInit();
		((Control)TabMenu).SuspendLayout();
		((Control)TabPanel1).SuspendLayout();
		((Control)Pnl1).SuspendLayout();
		((Control)TabPanel2).SuspendLayout();
		((Control)TabPanel3).SuspendLayout();
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
		((Control)lblBook).TabIndex = 101;
		lblBook.Text = "Voucher ReNumbaring";
		lblBook.TextAlign = (ContentAlignment)32;
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
		((Control)PnlBotam).TabIndex = 1126;
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
		((Control)BtnExit).TabIndex = 25;
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
		((Control)BtnDelete).TabIndex = 24;
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
		((Control)BtnCancel).TabIndex = 23;
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
		((Control)BtnSave).TabIndex = 22;
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
		((Control)BtnPrint).TabIndex = 26;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseItem)TabMenu.ControlBox.CloseBox).Name = "";
		((BaseItem)TabMenu.ControlBox.MenuBox).Name = "";
		((BaseItem)TabMenu.ControlBox).Name = "";
		((BaseItem)TabMenu.ControlBox).SubItems.AddRange((BaseItem[])(object)new BaseItem[2]
		{
			(BaseItem)TabMenu.ControlBox.MenuBox,
			(BaseItem)TabMenu.ControlBox.CloseBox
		});
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel1);
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel2);
		((Control)TabMenu).Controls.Add((Control)(object)TabPanel3);
		((Control)TabMenu).Dock = (DockStyle)5;
		((Control)TabMenu).Location = new Point(0, 32);
		((Control)TabMenu).Name = "TabMenu";
		TabMenu.ReorderTabsEnabled = true;
		TabMenu.SelectedTabFont = new Font("Microsoft Sans Serif", 11.25f);
		TabMenu.SelectedTabIndex = 0;
		((Control)TabMenu).Size = new Size(1309, 534);
		TabMenu.TabAlignment = (eTabStripAlignment)3;
		TabMenu.TabFont = new Font("Microsoft Sans Serif", 11.25f);
		((Control)TabMenu).TabIndex = 1127;
		TabMenu.TabLayoutType = (eSuperTabLayoutType)1;
		TabMenu.Tabs.AddRange((BaseItem[])(object)new BaseItem[3]
		{
			(BaseItem)Tab1,
			(BaseItem)Tab2,
			(BaseItem)Tab3
		});
		TabMenu.TabStyle = (eSuperTabStyle)1;
		((Control)TabMenu).Text = "SuperTabControl1";
		((PanelControl)TabPanel1).CanvasColor = Color.Black;
		((Control)TabPanel1).Controls.Add((Control)(object)Pnl1);
		TabPanel1.Dock = (DockStyle)5;
		((Control)TabPanel1).Location = new Point(0, 0);
		((Control)TabPanel1).Name = "TabPanel1";
		((Control)TabPanel1).Size = new Size(1309, 507);
		((Control)TabPanel1).TabIndex = 0;
		TabPanel1.TabItem = Tab1;
		((Control)Pnl1).Controls.Add((Control)(object)btnSlWithAc);
		((Control)Pnl1).Controls.Add((Control)(object)ProgressBar1);
		((Control)Pnl1).Controls.Add((Control)(object)tBookCode);
		((Control)Pnl1).Controls.Add((Control)(object)tBookName);
		((Control)Pnl1).Controls.Add((Control)(object)Label1);
		((Control)Pnl1).Controls.Add((Control)(object)btnWhSale);
		((Control)Pnl1).Controls.Add((Control)(object)btnBankPay);
		((Control)Pnl1).Controls.Add((Control)(object)btnCashPay);
		((Control)Pnl1).Controls.Add((Control)(object)btnBank);
		((Control)Pnl1).Controls.Add((Control)(object)btnCash);
		((Control)Pnl1).Controls.Add((Control)(object)btnPurc);
		((Control)Pnl1).Controls.Add((Control)(object)btnSales);
		((Control)Pnl1).Dock = (DockStyle)5;
		((Control)Pnl1).Location = new Point(0, 0);
		((Control)Pnl1).Name = "Pnl1";
		((Control)Pnl1).Size = new Size(1309, 507);
		((Control)Pnl1).TabIndex = 0;
		((QControl)btnSlWithAc).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSlWithAc).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlWithAc).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSlWithAc).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSlWithAc).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSlWithAc).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSlWithAc).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnSlWithAc).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSlWithAc).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSlWithAc).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSlWithAc).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSlWithAc).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSlWithAc).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSlWithAc).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSlWithAc.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlWithAc.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlWithAc.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlWithAc.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSlWithAc.Image = null;
		((QControl)btnSlWithAc).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSlWithAc).Location = new Point(693, 79);
		((Control)btnSlWithAc).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSlWithAc).Name = "btnSlWithAc";
		((Control)btnSlWithAc).Size = new Size(121, 32);
		((Control)btnSlWithAc).TabIndex = 1166;
		btnSlWithAc.Text = "Sl With Ac";
		((Control)btnSlWithAc).Visible = false;
		((Control)ProgressBar1).Location = new Point(0, 407);
		((Control)ProgressBar1).Name = "ProgressBar1";
		((Control)ProgressBar1).Size = new Size(1309, 23);
		((Control)ProgressBar1).TabIndex = 1165;
		((TextBoxBase)tBookCode).BackColor = Color.White;
		((Control)tBookCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookCode).Location = new Point(408, 40);
		((TextBoxBase)tBookCode).MaxLength = 8;
		((Control)tBookCode).Name = "tBookCode";
		((Control)tBookCode).Size = new Size(76, 23);
		((Control)tBookCode).TabIndex = 1162;
		((TextBoxBase)tBookName).BackColor = Color.White;
		((Control)tBookName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookName).Location = new Point(490, 39);
		((TextBoxBase)tBookName).MaxLength = 8;
		((Control)tBookName).Name = "tBookName";
		((Control)tBookName).Size = new Size(282, 23);
		((Control)tBookName).TabIndex = 1164;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(341, 41);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(60, 20);
		((Control)Label1).TabIndex = 1163;
		Label1.Text = "Book";
		Label1.TextAlign = (ContentAlignment)64;
		((QControl)btnWhSale).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnWhSale).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWhSale).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnWhSale).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnWhSale).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnWhSale).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWhSale).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnWhSale).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnWhSale).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnWhSale).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnWhSale).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWhSale).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnWhSale).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnWhSale).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnWhSale.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSale.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSale.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSale.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhSale.Image = null;
		((QControl)btnWhSale).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnWhSale).Location = new Point(507, 343);
		((Control)btnWhSale).Margin = new Padding(3, 6, 3, 6);
		((Control)btnWhSale).Name = "btnWhSale";
		((Control)btnWhSale).Size = new Size(121, 32);
		((Control)btnWhSale).TabIndex = 1154;
		btnWhSale.Text = "WhSale";
		((QControl)btnBankPay).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnBankPay).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBankPay).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnBankPay).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnBankPay).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnBankPay).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBankPay).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnBankPay).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnBankPay).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnBankPay).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnBankPay).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnBankPay).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnBankPay).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnBankPay).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnBankPay.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBankPay.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBankPay.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBankPay.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBankPay.Image = null;
		((QControl)btnBankPay).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnBankPay).Location = new Point(507, 299);
		((Control)btnBankPay).Margin = new Padding(3, 6, 3, 6);
		((Control)btnBankPay).Name = "btnBankPay";
		((Control)btnBankPay).Size = new Size(121, 32);
		((Control)btnBankPay).TabIndex = 1153;
		btnBankPay.Text = "Bank Pay";
		((QControl)btnCashPay).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnCashPay).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCashPay).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnCashPay).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnCashPay).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnCashPay).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCashPay).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnCashPay).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnCashPay).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnCashPay).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnCashPay).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnCashPay).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnCashPay).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnCashPay).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnCashPay.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCashPay.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCashPay.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCashPay.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCashPay.Image = null;
		((QControl)btnCashPay).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnCashPay).Location = new Point(507, 211);
		((Control)btnCashPay).Margin = new Padding(3, 6, 3, 6);
		((Control)btnCashPay).Name = "btnCashPay";
		((Control)btnCashPay).Size = new Size(121, 32);
		((Control)btnCashPay).TabIndex = 1152;
		btnCashPay.Text = "Cash Pay";
		((QControl)btnBank).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnBank).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBank).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnBank).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnBank).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnBank).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBank).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnBank).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnBank).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnBank).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnBank).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnBank).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnBank).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnBank).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnBank.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBank.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBank.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBank.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBank.Image = null;
		((QControl)btnBank).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnBank).Location = new Point(507, 255);
		((Control)btnBank).Margin = new Padding(3, 6, 3, 6);
		((Control)btnBank).Name = "btnBank";
		((Control)btnBank).Size = new Size(121, 32);
		((Control)btnBank).TabIndex = 1151;
		btnBank.Text = "Bank Rec";
		((QControl)btnCash).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnCash).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCash).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnCash).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnCash).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnCash).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnCash).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnCash).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnCash).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnCash).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnCash).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnCash).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnCash).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnCash).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnCash.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCash.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCash.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCash.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnCash.Image = null;
		((QControl)btnCash).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnCash).Location = new Point(507, 167);
		((Control)btnCash).Margin = new Padding(3, 6, 3, 6);
		((Control)btnCash).Name = "btnCash";
		((Control)btnCash).Size = new Size(121, 32);
		((Control)btnCash).TabIndex = 1148;
		btnCash.Text = "Cash Rec";
		((QControl)btnPurc).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnPurc).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurc).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnPurc).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnPurc).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnPurc).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnPurc).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnPurc).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnPurc).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnPurc).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnPurc).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnPurc).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnPurc).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnPurc).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnPurc.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurc.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurc.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurc.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnPurc.Image = null;
		((QControl)btnPurc).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnPurc).Location = new Point(507, 123);
		((Control)btnPurc).Margin = new Padding(3, 6, 3, 6);
		((Control)btnPurc).Name = "btnPurc";
		((Control)btnPurc).Size = new Size(121, 32);
		((Control)btnPurc).TabIndex = 1136;
		btnPurc.Text = "Purchase";
		((QControl)btnSales).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnSales).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSales).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnSales).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnSales).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnSales).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnSales).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)btnSales).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnSales).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnSales).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnSales).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnSales).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnSales).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnSales).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnSales.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSales.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSales.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSales.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnSales.Image = null;
		((QControl)btnSales).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnSales).Location = new Point(507, 79);
		((Control)btnSales).Margin = new Padding(3, 6, 3, 6);
		((Control)btnSales).Name = "btnSales";
		((Control)btnSales).Size = new Size(121, 32);
		((Control)btnSales).TabIndex = 1133;
		btnSales.Text = "Sales";
		Tab1.AttachedControl = (Control)(object)TabPanel1;
		((BaseItem)Tab1).GlobalItem = false;
		((BaseItem)Tab1).Name = "Tab1";
		Tab1.Text = "Setting1";
		Tab1.TextAlignment = (eItemAlignment)2;
		((Control)TabPanel2).Controls.Add((Control)(object)Pnl2);
		TabPanel2.Dock = (DockStyle)5;
		((Control)TabPanel2).Location = new Point(0, 0);
		((Control)TabPanel2).Name = "TabPanel2";
		((Control)TabPanel2).Size = new Size(1309, 507);
		((Control)TabPanel2).TabIndex = 0;
		TabPanel2.TabItem = Tab2;
		((Control)Pnl2).Dock = (DockStyle)5;
		((Control)Pnl2).Location = new Point(0, 0);
		((Control)Pnl2).Name = "Pnl2";
		((Control)Pnl2).Size = new Size(1309, 507);
		((Control)Pnl2).TabIndex = 0;
		Tab2.AttachedControl = (Control)(object)TabPanel2;
		((BaseItem)Tab2).GlobalItem = false;
		((BaseItem)Tab2).Name = "Tab2";
		Tab2.Text = "Setting2";
		Tab2.TextAlignment = (eItemAlignment)2;
		((Control)TabPanel3).Controls.Add((Control)(object)Pnl3);
		TabPanel3.Dock = (DockStyle)5;
		((Control)TabPanel3).Location = new Point(0, 0);
		((Control)TabPanel3).Name = "TabPanel3";
		((Control)TabPanel3).Size = new Size(1309, 507);
		((Control)TabPanel3).TabIndex = 0;
		TabPanel3.TabItem = Tab3;
		((Control)Pnl3).Dock = (DockStyle)5;
		((Control)Pnl3).Location = new Point(0, 0);
		((Control)Pnl3).Name = "Pnl3";
		((Control)Pnl3).Size = new Size(1309, 507);
		((Control)Pnl3).TabIndex = 1;
		Tab3.AttachedControl = (Control)(object)TabPanel3;
		((BaseItem)Tab3).GlobalItem = false;
		((BaseItem)Tab3).Name = "Tab3";
		Tab3.Text = "Setting3";
		Tab3.TextAlignment = (eItemAlignment)2;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)TabMenu);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "UT_VCH_RE_NUMBR";
		((Form)this).Text = "Voucher ReNumbaring";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)TabMenu).EndInit();
		((Control)TabMenu).ResumeLayout(false);
		((Control)TabPanel1).ResumeLayout(false);
		((Control)Pnl1).ResumeLayout(false);
		((Control)Pnl1).PerformLayout();
		((Control)TabPanel2).ResumeLayout(false);
		((Control)TabPanel3).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
	}

	private void UT_VCH_RE_NUMBR_Activated(object sender, EventArgs e)
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
		EntryMode = "A";
	}

	private void DISPLAY_DATA()
	{
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void UT_VCH_RE_NUMBR_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void UT_VCH_RE_NUMBR_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Invalid comparison between Unknown and I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
		}
		if ((e.KeyCode & 0xFFFF) == 69 && (int)e.Modifiers == 262144)
		{
			BtnExit_Click(BtnExit, new EventArgs());
		}
		else if ((e.KeyCode & 0xFFFF) == 67 && (int)e.Modifiers == 262144)
		{
			BtnCancel_Click(BtnCancel, new EventArgs());
		}
	}

	private void UT_VCH_RE_NUMBR_Closed(object sender, EventArgs e)
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

	private void UT_VCH_RE_NUMBR_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
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
				if (val is AxMSFlexGrid)
				{
					Control val2;
					(val2 = val).Width = val2.Width + (int)Math.Round((double)val.Width * num);
					(val2 = val).Height = val2.Height + (int)Math.Round((double)val.Height * num2);
					(val2 = val).Left = val2.Left + (int)Math.Round((double)val.Left * num);
					(val2 = val).Top = val2.Top + ((int)Math.Round((double)val.Top * num2) + (int)Math.Round((double)val.Top / 15.0));
				}
				else
				{
					Control val2;
					(val2 = val).Width = val2.Width + (int)Math.Round((double)val.Width * num);
					(val2 = val).Height = val2.Height + (int)Math.Round((double)val.Height * num2);
					(val2 = val).Left = val2.Left + (int)Math.Round((double)val.Left * num);
					(val2 = val).Top = val2.Top + (int)Math.Round((double)val.Top * num2);
				}
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
			CLEAR_DATA();
			EntryMode = "A";
		}
	}

	private void btnSales_Click(object sender, EventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_178b: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e8: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		string text = default(string);
		DataTable dataTable = default(DataTable);
		DataTable dataTable2 = default(DataTable);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					ProgressBar progressBar;
					switch (try0001_dispatch)
					{
					default:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000b;
					case 6455:
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
								goto IL_000b;
							case 3:
								goto IL_0023;
							case 4:
								goto IL_0032;
							case 5:
								goto IL_0041;
							case 6:
								goto IL_00cc;
							case 7:
								goto IL_00da;
							case 10:
								goto IL_00e7;
							case 11:
								goto IL_0161;
							case 12:
								goto IL_0170;
							case 13:
								goto IL_0188;
							case 14:
								goto IL_0198;
							case 15:
							case 16:
								goto IL_01b5;
							case 17:
								goto IL_01bf;
							case 20:
								goto IL_01cd;
							case 21:
								goto IL_029a;
							case 22:
								goto IL_035c;
							case 23:
								goto IL_0429;
							case 24:
								goto IL_04eb;
							case 25:
								goto IL_05b8;
							case 26:
								goto IL_067a;
							case 27:
								goto IL_0747;
							case 28:
								goto IL_0809;
							case 29:
								goto IL_08d6;
							case 30:
								goto IL_0975;
							case 31:
								goto IL_0a42;
							case 32:
								goto IL_0b04;
							case 33:
								goto IL_0bd1;
							case 34:
								goto IL_0c93;
							case 35:
								goto IL_0cb2;
							case 36:
								goto IL_0d74;
							case 38:
								goto IL_0e3d;
							case 39:
								goto IL_0eff;
							case 37:
							case 40:
							case 41:
								goto IL_0fc2;
							case 42:
								goto IL_1075;
							case 43:
								goto IL_1128;
							case 44:
								goto IL_114d;
							case 45:
								goto IL_1168;
							case 46:
								goto IL_1171;
							case 18:
							case 19:
							case 47:
								goto IL_1181;
							case 48:
								goto IL_11a0;
							case 49:
								goto IL_121a;
							case 50:
								goto IL_1229;
							case 51:
								goto IL_1241;
							case 52:
								goto IL_1251;
							case 53:
							case 54:
								goto IL_126e;
							case 57:
								goto IL_127c;
							case 58:
								goto IL_1321;
							case 59:
								goto IL_13c6;
							case 60:
								goto IL_146b;
							case 61:
								goto IL_1510;
							case 62:
								goto IL_15b5;
							case 63:
								goto IL_165a;
							case 64:
								goto IL_16ff;
							case 65:
								goto IL_171a;
							case 66:
								goto IL_1723;
							case 55:
							case 56:
							case 67:
								goto IL_1733;
							case 68:
								goto IL_1752;
							case 8:
							case 9:
							case 69:
								goto IL_1762;
							case 70:
								goto IL_1781;
							case 71:
								goto IL_1791;
							case 72:
								goto IL_17a1;
							case 73:
								goto end_IL_0001_2;
							case 76:
								num2 = 76;
								Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)"");
								goto end_IL_0001_3;
							default:
								goto end_IL_0001;
							case 74:
							case 75:
							case 77:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_114d:
						num2 = 44;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_1168;
						IL_1168:
						num2 = 45;
						Application.DoEvents();
						goto IL_1171;
						IL_1128:
						num2 = 43;
						text = Strings.Format((object)(Conversions.ToDouble(text) + 1.0), "00000");
						goto IL_114d;
						IL_1171:
						num2 = 46;
						DC_Main.M++;
						goto IL_1181;
						IL_000b:
						num2 = 2;
						if (unchecked((int)Interaction.MsgBox((object)"Are you sure to Voucher Re Numbering Data?", (MsgBoxStyle)4, (object)null)) != 6)
						{
							goto end_IL_0001_3;
						}
						goto IL_0023;
						IL_0023:
						num2 = 3;
						((Control)BtnExit).Enabled = false;
						goto IL_0032;
						IL_0032:
						num2 = 4;
						((Control)BtnCancel).Enabled = false;
						goto IL_0041;
						IL_0041:
						num2 = 5;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND MAIN_BOOK = 'SALES'  ORDER BY CO_BOOK"));
						goto IL_00cc;
						IL_00cc:
						num2 = 6;
						dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_00da;
						IL_00da:
						num2 = 7;
						DC_Main.X = 0;
						goto IL_1762;
						IL_1762:
						num2 = 9;
						if (DC_Main.X < dataTable.Rows.Count)
						{
							goto IL_00e7;
						}
						goto IL_1781;
						IL_1781:
						num2 = 70;
						Interaction.MsgBox((object)"Voucher are sucessfully Re Numbering.. Please Data Refresh After Vch No Is Re Numbring.....", (MsgBoxStyle)0, (object)null);
						goto IL_1791;
						IL_1791:
						num2 = 71;
						((Control)BtnExit).Enabled = true;
						goto IL_17a1;
						IL_17a1:
						num2 = 72;
						((Control)BtnCancel).Enabled = true;
						break;
						IL_00e7:
						num2 = 10;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO,VCH_DATE,CO_BOOK,OLD_VCH_NO FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY VCH_DATE,VCH_NO"));
						goto IL_0161;
						IL_0161:
						num2 = 11;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0170;
						IL_0170:
						num2 = 12;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_0188;
						}
						goto IL_01b5;
						IL_0188:
						num2 = 13;
						ProgressBar1.Value = 0;
						goto IL_0198;
						IL_0198:
						num2 = 14;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_01b5;
						IL_01b5:
						num2 = 16;
						text = "00001";
						goto IL_01bf;
						IL_01bf:
						num2 = 17;
						DC_Main.M = 0;
						goto IL_1181;
						IL_1181:
						num2 = 19;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_01cd;
						}
						goto IL_11a0;
						IL_11a0:
						num2 = 48;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO,VCH_DATE,CO_BOOK,OLD_VCH_NO FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY VCH_DATE,VCH_NO"));
						goto IL_121a;
						IL_121a:
						num2 = 49;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_1229;
						IL_1229:
						num2 = 50;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_1241;
						}
						goto IL_126e;
						IL_1241:
						num2 = 51;
						ProgressBar1.Value = 0;
						goto IL_1251;
						IL_1251:
						num2 = 52;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_126e;
						IL_126e:
						num2 = 54;
						DC_Main.M = 0;
						goto IL_1733;
						IL_1733:
						num2 = 56;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_127c;
						}
						goto IL_1752;
						IL_1752:
						num2 = 68;
						DC_Main.X++;
						goto IL_1762;
						IL_127c:
						num2 = 57;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DATA SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_1321;
						IL_1321:
						num2 = 58;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DETL SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_13c6;
						IL_13c6:
						num2 = 59;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_IDTL SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_146b;
						IL_146b:
						num2 = 60;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_PR_DETL SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_1510;
						IL_1510:
						num2 = 61;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_ORD_ADJ SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_15b5;
						IL_15b5:
						num2 = 62;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BILL_OS_DATA SET VCH_NO = NEW_VCH_NO,BILL_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_165a;
						IL_165a:
						num2 = 63;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE UPI_DATA SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_16ff;
						IL_16ff:
						num2 = 64;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_171a;
						IL_171a:
						num2 = 65;
						Application.DoEvents();
						goto IL_1723;
						IL_1723:
						num2 = 66;
						DC_Main.M++;
						goto IL_1733;
						IL_01cd:
						num2 = 20;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE SL_DATA SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND  CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_029a;
						IL_029a:
						num2 = 21;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DATA SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_035c;
						IL_035c:
						num2 = 22;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE SL_DETL SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND  CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0429;
						IL_0429:
						num2 = 23;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DETL SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_04eb;
						IL_04eb:
						num2 = 24;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE SL_IDTL SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_05b8;
						IL_05b8:
						num2 = 25;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_IDTL SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_067a;
						IL_067a:
						num2 = 26;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE SL_PR_DETL SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0747;
						IL_0747:
						num2 = 27;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_PR_DETL SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0809;
						IL_0809:
						num2 = 28;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE SL_ORD_ADJ SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
						goto IL_08d6;
						IL_08d6:
						num2 = 29;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_ORD_ADJ SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0975;
						IL_0975:
						num2 = 30;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE BILL_OS_DATA SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
						goto IL_0a42;
						IL_0a42:
						num2 = 31;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BILL_OS_DATA SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0b04;
						IL_0b04:
						num2 = 32;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE UPI_DATA SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
						goto IL_0bd1;
						IL_0bd1:
						num2 = 33;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE UPI_DATA SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0c93;
						IL_0c93:
						num2 = 34;
						if (Operators.CompareString(DC_Main.MCo_Type, "", false) == 0)
						{
							goto IL_0cb2;
						}
						goto IL_0e3d;
						IL_0cb2:
						num2 = 35;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AD_ADJ SET SBILL_NO = '" + text + "',SBILL_HD_VCH_NO = '" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SBILL_LC_CODE = '" + DC_Main.MLc_code + "' AND SBILL_YRCD = '" + DC_Main.MCo_year + "' AND SBILL_DBCD = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND SBILL_NO <> '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0d74;
						IL_0d74:
						num2 = 36;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BILL_OS_DATA SET BILL_NO = '" + text + "',BILL_HD_VCH_NO = '" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND BILL_LC = '" + DC_Main.MLc_code + "' AND BILL_YRCD = '" + DC_Main.MCo_year + "' AND BILL_DBCD = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND BILL_NO <> '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0fc2;
						IL_0e3d:
						num2 = 38;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AD_ADJ SET SBILL_NO = '" + text + "',SBILL_HD_VCH_NO = '" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SBILL_LC_CODE = '" + DC_Main.MLc_code + "' AND SBILL_YRCD = '" + DC_Main.MCo_year + "' AND SBILL_DBCD = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND SBILL_NO <> '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0eff;
						IL_0eff:
						num2 = 39;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BILL_OS_DATA SET BILL_NO = '" + text + "',BILL_HD_VCH_NO = '" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND BILL_LC = '" + DC_Main.MLc_code + "' AND BILL_YRCD = '" + DC_Main.MCo_year + "' AND BILL_DBCD = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND BILL_NO <> '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0fc2;
						IL_0fc2:
						num2 = 41;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE PR_DATA SET SL_BILL_NO = '" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SL_BILL_LC = '" + DC_Main.MLc_code + "' AND SL_BILL_YRCD = '" + DC_Main.MCo_year + "' AND SL_BILL_DBCD = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND SL_BILL_NO <> '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_1075;
						IL_1075:
						num2 = 42;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE PR_DETL SET SL_BILL_NO = '" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SL_BILL_LC = '" + DC_Main.MLc_code + "' AND SL_BILL_YRCD = '" + DC_Main.MCo_year + "' AND SL_BILL_DBCD = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND SL_BILL_NO <> '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_1128;
						end_IL_0001_2:
						break;
					}
					num2 = 73;
					ProgressBar1.Value = 0;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 6455;
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

	private void btnPurc_Click(object sender, EventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_10a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_10df: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		string text = default(string);
		DataTable dataTable = default(DataTable);
		DataTable dataTable2 = default(DataTable);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					ProgressBar progressBar;
					switch (try0001_dispatch)
					{
					default:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000b;
					case 4590:
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
								goto IL_000b;
							case 3:
								goto IL_0023;
							case 4:
								goto IL_00ae;
							case 5:
								goto IL_00bc;
							case 8:
								goto IL_00c9;
							case 9:
								goto IL_0142;
							case 10:
								goto IL_0151;
							case 11:
								goto IL_0169;
							case 12:
								goto IL_0179;
							case 13:
							case 14:
								goto IL_0196;
							case 15:
								goto IL_01a0;
							case 18:
								goto IL_01ae;
							case 19:
								goto IL_027b;
							case 20:
								goto IL_033d;
							case 21:
								goto IL_040a;
							case 22:
								goto IL_04cc;
							case 23:
								goto IL_0599;
							case 24:
								goto IL_065b;
							case 25:
								goto IL_0728;
							case 26:
								goto IL_07ea;
							case 27:
								goto IL_08b7;
							case 28:
								goto IL_0956;
							case 29:
								goto IL_0a23;
							case 30:
								goto IL_0ae5;
							case 31:
								goto IL_0b0a;
							case 32:
								goto IL_0b25;
							case 33:
								goto IL_0b2e;
							case 16:
							case 17:
							case 34:
								goto IL_0b3e;
							case 35:
								goto IL_0b5d;
							case 36:
								goto IL_0bd7;
							case 37:
								goto IL_0be6;
							case 38:
								goto IL_0bfe;
							case 39:
								goto IL_0c0e;
							case 40:
							case 41:
								goto IL_0c2b;
							case 44:
								goto IL_0c39;
							case 45:
								goto IL_0cde;
							case 46:
								goto IL_0d83;
							case 47:
								goto IL_0e28;
							case 48:
								goto IL_0ecd;
							case 49:
								goto IL_0f72;
							case 50:
								goto IL_1017;
							case 51:
								goto IL_1032;
							case 52:
								goto IL_103b;
							case 42:
							case 43:
							case 53:
								goto IL_104b;
							case 54:
								goto IL_106a;
							case 6:
							case 7:
							case 55:
								goto IL_107a;
							case 56:
								goto IL_1098;
							case 57:
								goto end_IL_0001_2;
							case 60:
								num2 = 60;
								Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)"");
								goto end_IL_0001_3;
							default:
								goto end_IL_0001;
							case 58:
							case 59:
							case 61:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0b0a:
						num2 = 31;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_0b25;
						IL_0b25:
						num2 = 32;
						Application.DoEvents();
						goto IL_0b2e;
						IL_0ae5:
						num2 = 30;
						text = Strings.Format((object)(Conversions.ToDouble(text) + 1.0), "00000");
						goto IL_0b0a;
						IL_0b2e:
						num2 = 33;
						DC_Main.M++;
						goto IL_0b3e;
						IL_000b:
						num2 = 2;
						if (unchecked((int)Interaction.MsgBox((object)"Are you sure to Voucher Re Numbering Data?", (MsgBoxStyle)4, (object)null)) != 6)
						{
							goto end_IL_0001_3;
						}
						goto IL_0023;
						IL_0023:
						num2 = 3;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND MAIN_BOOK = 'PURCHASE' ORDER BY CO_BOOK"));
						goto IL_00ae;
						IL_00ae:
						num2 = 4;
						dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_00bc;
						IL_00bc:
						num2 = 5;
						DC_Main.X = 0;
						goto IL_107a;
						IL_107a:
						num2 = 7;
						if (DC_Main.X < dataTable.Rows.Count)
						{
							goto IL_00c9;
						}
						goto IL_1098;
						IL_1098:
						num2 = 56;
						Interaction.MsgBox((object)"Voucher are sucessfully Re Numbering.. Please Data Refresh After Vch No Is Re Numbring.....", (MsgBoxStyle)0, (object)null);
						break;
						IL_00c9:
						num2 = 8;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO,VCH_DATE,CO_BOOK,OLD_VCH_NO FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY VCH_DATE,VCH_NO"));
						goto IL_0142;
						IL_0142:
						num2 = 9;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0151;
						IL_0151:
						num2 = 10;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_0169;
						}
						goto IL_0196;
						IL_0169:
						num2 = 11;
						ProgressBar1.Value = 0;
						goto IL_0179;
						IL_0179:
						num2 = 12;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_0196;
						IL_0196:
						num2 = 14;
						text = "00001";
						goto IL_01a0;
						IL_01a0:
						num2 = 15;
						DC_Main.M = 0;
						goto IL_0b3e;
						IL_0b3e:
						num2 = 17;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_01ae;
						}
						goto IL_0b5d;
						IL_0b5d:
						num2 = 35;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO,VCH_DATE,CO_BOOK,OLD_VCH_NO FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY VCH_DATE,VCH_NO"));
						goto IL_0bd7;
						IL_0bd7:
						num2 = 36;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0be6;
						IL_0be6:
						num2 = 37;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_0bfe;
						}
						goto IL_0c2b;
						IL_0bfe:
						num2 = 38;
						ProgressBar1.Value = 0;
						goto IL_0c0e;
						IL_0c0e:
						num2 = 39;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_0c2b;
						IL_0c2b:
						num2 = 41;
						DC_Main.M = 0;
						goto IL_104b;
						IL_104b:
						num2 = 43;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_0c39;
						}
						goto IL_106a;
						IL_106a:
						num2 = 54;
						DC_Main.X++;
						goto IL_107a;
						IL_0c39:
						num2 = 44;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE PR_DATA SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0cde;
						IL_0cde:
						num2 = 45;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE PR_DETL SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0d83;
						IL_0d83:
						num2 = 46;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE PR_IDTL SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0e28;
						IL_0e28:
						num2 = 47;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DATA SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0ecd;
						IL_0ecd:
						num2 = 48;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0f72;
						IL_0f72:
						num2 = 49;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_IDTL SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_1017;
						IL_1017:
						num2 = 50;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_1032;
						IL_1032:
						num2 = 51;
						Application.DoEvents();
						goto IL_103b;
						IL_103b:
						num2 = 52;
						DC_Main.M++;
						goto IL_104b;
						IL_01ae:
						num2 = 18;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE PR_DATA SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND  CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_027b;
						IL_027b:
						num2 = 19;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE PR_DATA SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_033d;
						IL_033d:
						num2 = 20;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE PR_DETL SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND  CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_040a;
						IL_040a:
						num2 = 21;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE PR_DETL SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_04cc;
						IL_04cc:
						num2 = 22;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE PR_IDTL SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0599;
						IL_0599:
						num2 = 23;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE PR_IDTL SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_065b;
						IL_065b:
						num2 = 24;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE BAR_DATA SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0728;
						IL_0728:
						num2 = 25;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DATA SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_07ea;
						IL_07ea:
						num2 = 26;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE BAR_DETL SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
						goto IL_08b7;
						IL_08b7:
						num2 = 27;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0956;
						IL_0956:
						num2 = 28;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE BAR_IDTL SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
						goto IL_0a23;
						IL_0a23:
						num2 = 29;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_IDTL SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0ae5;
						end_IL_0001_2:
						break;
					}
					num2 = 57;
					ProgressBar1.Value = 0;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 4590;
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

	private void btnCash_Click(object sender, EventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		string text = default(string);
		DataTable dataTable = default(DataTable);
		DataTable dataTable2 = default(DataTable);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					ProgressBar progressBar;
					switch (try0001_dispatch)
					{
					default:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000b;
					case 1729:
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
								goto IL_000b;
							case 3:
								goto IL_0023;
							case 4:
								goto IL_00ae;
							case 5:
								goto IL_00bc;
							case 8:
								goto IL_00c9;
							case 9:
								goto IL_0132;
							case 10:
								goto IL_0141;
							case 11:
								goto IL_0159;
							case 12:
								goto IL_0169;
							case 13:
							case 14:
								goto IL_0186;
							case 15:
								goto IL_0190;
							case 18:
								goto IL_019e;
							case 19:
								goto IL_026b;
							case 20:
								goto IL_032d;
							case 21:
								goto IL_0352;
							case 22:
								goto IL_036d;
							case 23:
								goto IL_0376;
							case 16:
							case 17:
							case 24:
								goto IL_0386;
							case 25:
								goto IL_03a5;
							case 26:
								goto IL_041f;
							case 27:
								goto IL_042e;
							case 28:
								goto IL_0446;
							case 29:
								goto IL_0456;
							case 30:
							case 31:
								goto IL_0473;
							case 34:
								goto IL_0481;
							case 35:
								goto IL_0526;
							case 36:
								goto IL_0541;
							case 37:
								goto IL_054a;
							case 32:
							case 33:
							case 38:
								goto IL_055a;
							case 39:
								goto IL_0579;
							case 6:
							case 7:
							case 40:
								goto IL_0589;
							case 41:
								goto IL_05a7;
							case 42:
								goto end_IL_0001_2;
							case 45:
								num2 = 45;
								Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)"");
								goto end_IL_0001_3;
							default:
								goto end_IL_0001;
							case 43:
							case 44:
							case 46:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0352:
						num2 = 21;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_036d;
						IL_036d:
						num2 = 22;
						Application.DoEvents();
						goto IL_0376;
						IL_032d:
						num2 = 20;
						text = Strings.Format((object)(Conversions.ToDouble(text) + 1.0), "00000");
						goto IL_0352;
						IL_0376:
						num2 = 23;
						DC_Main.M++;
						goto IL_0386;
						IL_000b:
						num2 = 2;
						if (unchecked((int)Interaction.MsgBox((object)"Are you sure to Voucher Re Numbering Data?", (MsgBoxStyle)4, (object)null)) != 6)
						{
							goto end_IL_0001_3;
						}
						goto IL_0023;
						IL_0023:
						num2 = 3;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND MAIN_BOOK = 'CASH REC' ORDER BY CO_BOOK"));
						goto IL_00ae;
						IL_00ae:
						num2 = 4;
						dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_00bc;
						IL_00bc:
						num2 = 5;
						DC_Main.X = 0;
						goto IL_0589;
						IL_0589:
						num2 = 7;
						if (DC_Main.X < dataTable.Rows.Count)
						{
							goto IL_00c9;
						}
						goto IL_05a7;
						IL_05a7:
						num2 = 41;
						Interaction.MsgBox((object)"Voucher are sucessfully Re Numbering.. Please Data Refresh After Vch No Is Re Numbring.....", (MsgBoxStyle)0, (object)null);
						break;
						IL_00c9:
						num2 = 8;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO,VCH_DATE,CO_BOOK,OLD_VCH_NO FROM CASH_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY VCH_DATE,VCH_NO"));
						goto IL_0132;
						IL_0132:
						num2 = 9;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0141;
						IL_0141:
						num2 = 10;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_0159;
						}
						goto IL_0186;
						IL_0159:
						num2 = 11;
						ProgressBar1.Value = 0;
						goto IL_0169;
						IL_0169:
						num2 = 12;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_0186;
						IL_0186:
						num2 = 14;
						text = "00001";
						goto IL_0190;
						IL_0190:
						num2 = 15;
						DC_Main.M = 0;
						goto IL_0386;
						IL_0386:
						num2 = 17;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_019e;
						}
						goto IL_03a5;
						IL_03a5:
						num2 = 25;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO,VCH_DATE,CO_BOOK,OLD_VCH_NO FROM CASH_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY VCH_DATE,VCH_NO"));
						goto IL_041f;
						IL_041f:
						num2 = 26;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_042e;
						IL_042e:
						num2 = 27;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_0446;
						}
						goto IL_0473;
						IL_0446:
						num2 = 28;
						ProgressBar1.Value = 0;
						goto IL_0456;
						IL_0456:
						num2 = 29;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_0473;
						IL_0473:
						num2 = 31;
						DC_Main.M = 0;
						goto IL_055a;
						IL_055a:
						num2 = 33;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_0481;
						}
						goto IL_0579;
						IL_0579:
						num2 = 39;
						DC_Main.X++;
						goto IL_0589;
						IL_0481:
						num2 = 34;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE CASH_DATA SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0526;
						IL_0526:
						num2 = 35;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_0541;
						IL_0541:
						num2 = 36;
						Application.DoEvents();
						goto IL_054a;
						IL_054a:
						num2 = 37;
						DC_Main.M++;
						goto IL_055a;
						IL_019e:
						num2 = 18;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE CASH_DATA SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND  CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_026b;
						IL_026b:
						num2 = 19;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE CASH_DATA SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_032d;
						end_IL_0001_2:
						break;
					}
					num2 = 42;
					ProgressBar1.Value = 0;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1729;
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

	private void btnCashPay_Click(object sender, EventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		string text = default(string);
		DataTable dataTable = default(DataTable);
		DataTable dataTable2 = default(DataTable);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					ProgressBar progressBar;
					switch (try0001_dispatch)
					{
					default:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000b;
					case 1729:
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
								goto IL_000b;
							case 3:
								goto IL_0023;
							case 4:
								goto IL_00ae;
							case 5:
								goto IL_00bc;
							case 8:
								goto IL_00c9;
							case 9:
								goto IL_0132;
							case 10:
								goto IL_0141;
							case 11:
								goto IL_0159;
							case 12:
								goto IL_0169;
							case 13:
							case 14:
								goto IL_0186;
							case 15:
								goto IL_0190;
							case 18:
								goto IL_019e;
							case 19:
								goto IL_026b;
							case 20:
								goto IL_032d;
							case 21:
								goto IL_0352;
							case 22:
								goto IL_036d;
							case 23:
								goto IL_0376;
							case 16:
							case 17:
							case 24:
								goto IL_0386;
							case 25:
								goto IL_03a5;
							case 26:
								goto IL_041f;
							case 27:
								goto IL_042e;
							case 28:
								goto IL_0446;
							case 29:
								goto IL_0456;
							case 30:
							case 31:
								goto IL_0473;
							case 34:
								goto IL_0481;
							case 35:
								goto IL_0526;
							case 36:
								goto IL_0541;
							case 37:
								goto IL_054a;
							case 32:
							case 33:
							case 38:
								goto IL_055a;
							case 39:
								goto IL_0579;
							case 6:
							case 7:
							case 40:
								goto IL_0589;
							case 41:
								goto IL_05a7;
							case 42:
								goto end_IL_0001_2;
							case 45:
								num2 = 45;
								Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)"");
								goto end_IL_0001_3;
							default:
								goto end_IL_0001;
							case 43:
							case 44:
							case 46:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0352:
						num2 = 21;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_036d;
						IL_036d:
						num2 = 22;
						Application.DoEvents();
						goto IL_0376;
						IL_032d:
						num2 = 20;
						text = Strings.Format((object)(Conversions.ToDouble(text) + 1.0), "00000");
						goto IL_0352;
						IL_0376:
						num2 = 23;
						DC_Main.M++;
						goto IL_0386;
						IL_000b:
						num2 = 2;
						if (unchecked((int)Interaction.MsgBox((object)"Are you sure to Voucher Re Numbering Data?", (MsgBoxStyle)4, (object)null)) != 6)
						{
							goto end_IL_0001_3;
						}
						goto IL_0023;
						IL_0023:
						num2 = 3;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND MAIN_BOOK = 'CASH PAY' ORDER BY CO_BOOK"));
						goto IL_00ae;
						IL_00ae:
						num2 = 4;
						dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_00bc;
						IL_00bc:
						num2 = 5;
						DC_Main.X = 0;
						goto IL_0589;
						IL_0589:
						num2 = 7;
						if (DC_Main.X < dataTable.Rows.Count)
						{
							goto IL_00c9;
						}
						goto IL_05a7;
						IL_05a7:
						num2 = 41;
						Interaction.MsgBox((object)"Voucher are sucessfully Re Numbering.. Please Data Refresh After Vch No Is Re Numbring.....", (MsgBoxStyle)0, (object)null);
						break;
						IL_00c9:
						num2 = 8;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO,VCH_DATE,CO_BOOK,OLD_VCH_NO FROM CASH_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY VCH_DATE,VCH_NO"));
						goto IL_0132;
						IL_0132:
						num2 = 9;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0141;
						IL_0141:
						num2 = 10;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_0159;
						}
						goto IL_0186;
						IL_0159:
						num2 = 11;
						ProgressBar1.Value = 0;
						goto IL_0169;
						IL_0169:
						num2 = 12;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_0186;
						IL_0186:
						num2 = 14;
						text = "00001";
						goto IL_0190;
						IL_0190:
						num2 = 15;
						DC_Main.M = 0;
						goto IL_0386;
						IL_0386:
						num2 = 17;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_019e;
						}
						goto IL_03a5;
						IL_03a5:
						num2 = 25;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO,VCH_DATE,CO_BOOK,OLD_VCH_NO FROM CASH_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY VCH_DATE,VCH_NO"));
						goto IL_041f;
						IL_041f:
						num2 = 26;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_042e;
						IL_042e:
						num2 = 27;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_0446;
						}
						goto IL_0473;
						IL_0446:
						num2 = 28;
						ProgressBar1.Value = 0;
						goto IL_0456;
						IL_0456:
						num2 = 29;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_0473;
						IL_0473:
						num2 = 31;
						DC_Main.M = 0;
						goto IL_055a;
						IL_055a:
						num2 = 33;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_0481;
						}
						goto IL_0579;
						IL_0579:
						num2 = 39;
						DC_Main.X++;
						goto IL_0589;
						IL_0481:
						num2 = 34;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE CASH_DATA SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0526;
						IL_0526:
						num2 = 35;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_0541;
						IL_0541:
						num2 = 36;
						Application.DoEvents();
						goto IL_054a;
						IL_054a:
						num2 = 37;
						DC_Main.M++;
						goto IL_055a;
						IL_019e:
						num2 = 18;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE CASH_DATA SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND  CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_026b;
						IL_026b:
						num2 = 19;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE CASH_DATA SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_032d;
						end_IL_0001_2:
						break;
					}
					num2 = 42;
					ProgressBar1.Value = 0;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1729;
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

	private void btnBank_Click(object sender, EventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_07f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0832: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		string text = default(string);
		DataTable dataTable = default(DataTable);
		DataTable dataTable2 = default(DataTable);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					ProgressBar progressBar;
					switch (try0001_dispatch)
					{
					default:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000b;
					case 2321:
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
								goto IL_000b;
							case 3:
								goto IL_0023;
							case 4:
								goto IL_00ae;
							case 5:
								goto IL_00bc;
							case 8:
								goto IL_00c9;
							case 9:
								goto IL_0142;
							case 10:
								goto IL_0151;
							case 11:
								goto IL_0169;
							case 12:
								goto IL_0179;
							case 13:
							case 14:
								goto IL_0196;
							case 15:
								goto IL_01a0;
							case 18:
								goto IL_01ae;
							case 19:
								goto IL_027b;
							case 20:
								goto IL_033d;
							case 21:
								goto IL_040a;
							case 22:
								goto IL_04cc;
							case 23:
								goto IL_04f1;
							case 24:
								goto IL_050c;
							case 25:
								goto IL_0515;
							case 16:
							case 17:
							case 26:
								goto IL_0525;
							case 27:
								goto IL_0544;
							case 28:
								goto IL_05be;
							case 29:
								goto IL_05cd;
							case 30:
								goto IL_05e5;
							case 31:
								goto IL_05f5;
							case 32:
							case 33:
								goto IL_0612;
							case 36:
								goto IL_0620;
							case 37:
								goto IL_06c5;
							case 38:
								goto IL_076a;
							case 39:
								goto IL_0785;
							case 40:
								goto IL_078e;
							case 34:
							case 35:
							case 41:
								goto IL_079e;
							case 42:
								goto IL_07bd;
							case 6:
							case 7:
							case 43:
								goto IL_07cd;
							case 44:
								goto IL_07eb;
							case 45:
								goto end_IL_0001_2;
							case 48:
								num2 = 48;
								Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)"");
								goto end_IL_0001_3;
							default:
								goto end_IL_0001;
							case 46:
							case 47:
							case 49:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_04f1:
						num2 = 23;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_050c;
						IL_050c:
						num2 = 24;
						Application.DoEvents();
						goto IL_0515;
						IL_04cc:
						num2 = 22;
						text = Strings.Format((object)(Conversions.ToDouble(text) + 1.0), "00000");
						goto IL_04f1;
						IL_0515:
						num2 = 25;
						DC_Main.M++;
						goto IL_0525;
						IL_000b:
						num2 = 2;
						if (unchecked((int)Interaction.MsgBox((object)"Are you sure to Voucher Re Numbering Data?", (MsgBoxStyle)4, (object)null)) != 6)
						{
							goto end_IL_0001_3;
						}
						goto IL_0023;
						IL_0023:
						num2 = 3;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND MAIN_BOOK = 'BANK REC' ORDER BY CO_BOOK"));
						goto IL_00ae;
						IL_00ae:
						num2 = 4;
						dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_00bc;
						IL_00bc:
						num2 = 5;
						DC_Main.X = 0;
						goto IL_07cd;
						IL_07cd:
						num2 = 7;
						if (DC_Main.X < dataTable.Rows.Count)
						{
							goto IL_00c9;
						}
						goto IL_07eb;
						IL_07eb:
						num2 = 44;
						Interaction.MsgBox((object)"Voucher are sucessfully Re Numbering.. Please Data Refresh After Vch No Is Re Numbring.....", (MsgBoxStyle)0, (object)null);
						break;
						IL_00c9:
						num2 = 8;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO,VCH_DATE,CO_BOOK,OLD_VCH_NO FROM CASH_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY VCH_DATE,VCH_NO"));
						goto IL_0142;
						IL_0142:
						num2 = 9;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0151;
						IL_0151:
						num2 = 10;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_0169;
						}
						goto IL_0196;
						IL_0169:
						num2 = 11;
						ProgressBar1.Value = 0;
						goto IL_0179;
						IL_0179:
						num2 = 12;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_0196;
						IL_0196:
						num2 = 14;
						text = "00001";
						goto IL_01a0;
						IL_01a0:
						num2 = 15;
						DC_Main.M = 0;
						goto IL_0525;
						IL_0525:
						num2 = 17;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_01ae;
						}
						goto IL_0544;
						IL_0544:
						num2 = 27;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO,VCH_DATE,CO_BOOK,OLD_VCH_NO FROM CASH_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY VCH_DATE,VCH_NO"));
						goto IL_05be;
						IL_05be:
						num2 = 28;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_05cd;
						IL_05cd:
						num2 = 29;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_05e5;
						}
						goto IL_0612;
						IL_05e5:
						num2 = 30;
						ProgressBar1.Value = 0;
						goto IL_05f5;
						IL_05f5:
						num2 = 31;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_0612;
						IL_0612:
						num2 = 33;
						DC_Main.M = 0;
						goto IL_079e;
						IL_079e:
						num2 = 35;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_0620;
						}
						goto IL_07bd;
						IL_07bd:
						num2 = 42;
						DC_Main.X++;
						goto IL_07cd;
						IL_0620:
						num2 = 36;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE CASH_DATA SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_06c5;
						IL_06c5:
						num2 = 37;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE UPI_DATA SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_076a;
						IL_076a:
						num2 = 38;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_0785;
						IL_0785:
						num2 = 39;
						Application.DoEvents();
						goto IL_078e;
						IL_078e:
						num2 = 40;
						DC_Main.M++;
						goto IL_079e;
						IL_01ae:
						num2 = 18;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE CASH_DATA SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND  CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_027b;
						IL_027b:
						num2 = 19;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE CASH_DATA SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_033d;
						IL_033d:
						num2 = 20;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE UPI_DATA SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' ")));
						goto IL_040a;
						IL_040a:
						num2 = 21;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE UPI_DATA SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_04cc;
						end_IL_0001_2:
						break;
					}
					num2 = 45;
					ProgressBar1.Value = 0;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 2321;
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

	private void btnBankPay_Click(object sender, EventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		string text = default(string);
		DataTable dataTable = default(DataTable);
		DataTable dataTable2 = default(DataTable);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					ProgressBar progressBar;
					switch (try0001_dispatch)
					{
					default:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000b;
					case 1745:
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
								goto IL_000b;
							case 3:
								goto IL_0023;
							case 4:
								goto IL_00ae;
							case 5:
								goto IL_00bc;
							case 8:
								goto IL_00c9;
							case 9:
								goto IL_0142;
							case 10:
								goto IL_0151;
							case 11:
								goto IL_0169;
							case 12:
								goto IL_0179;
							case 13:
							case 14:
								goto IL_0196;
							case 15:
								goto IL_01a0;
							case 18:
								goto IL_01ae;
							case 19:
								goto IL_027b;
							case 20:
								goto IL_033d;
							case 21:
								goto IL_0362;
							case 22:
								goto IL_037d;
							case 23:
								goto IL_0386;
							case 16:
							case 17:
							case 24:
								goto IL_0396;
							case 25:
								goto IL_03b5;
							case 26:
								goto IL_042f;
							case 27:
								goto IL_043e;
							case 28:
								goto IL_0456;
							case 29:
								goto IL_0466;
							case 30:
							case 31:
								goto IL_0483;
							case 34:
								goto IL_0491;
							case 35:
								goto IL_0536;
							case 36:
								goto IL_0551;
							case 37:
								goto IL_055a;
							case 32:
							case 33:
							case 38:
								goto IL_056a;
							case 39:
								goto IL_0589;
							case 6:
							case 7:
							case 40:
								goto IL_0599;
							case 41:
								goto IL_05b7;
							case 42:
								goto end_IL_0001_2;
							case 45:
								num2 = 45;
								Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)"");
								goto end_IL_0001_3;
							default:
								goto end_IL_0001;
							case 43:
							case 44:
							case 46:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0362:
						num2 = 21;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_037d;
						IL_037d:
						num2 = 22;
						Application.DoEvents();
						goto IL_0386;
						IL_033d:
						num2 = 20;
						text = Strings.Format((object)(Conversions.ToDouble(text) + 1.0), "00000");
						goto IL_0362;
						IL_0386:
						num2 = 23;
						DC_Main.M++;
						goto IL_0396;
						IL_000b:
						num2 = 2;
						if (unchecked((int)Interaction.MsgBox((object)"Are you sure to Voucher Re Numbering Data?", (MsgBoxStyle)4, (object)null)) != 6)
						{
							goto end_IL_0001_3;
						}
						goto IL_0023;
						IL_0023:
						num2 = 3;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND MAIN_BOOK = 'BANK PAY' ORDER BY CO_BOOK"));
						goto IL_00ae;
						IL_00ae:
						num2 = 4;
						dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_00bc;
						IL_00bc:
						num2 = 5;
						DC_Main.X = 0;
						goto IL_0599;
						IL_0599:
						num2 = 7;
						if (DC_Main.X < dataTable.Rows.Count)
						{
							goto IL_00c9;
						}
						goto IL_05b7;
						IL_05b7:
						num2 = 41;
						Interaction.MsgBox((object)"Voucher are sucessfully Re Numbering.. Please Data Refresh After Vch No Is Re Numbring.....", (MsgBoxStyle)0, (object)null);
						break;
						IL_00c9:
						num2 = 8;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO,VCH_DATE,CO_BOOK,OLD_VCH_NO FROM CASH_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY VCH_DATE,VCH_NO"));
						goto IL_0142;
						IL_0142:
						num2 = 9;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0151;
						IL_0151:
						num2 = 10;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_0169;
						}
						goto IL_0196;
						IL_0169:
						num2 = 11;
						ProgressBar1.Value = 0;
						goto IL_0179;
						IL_0179:
						num2 = 12;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_0196;
						IL_0196:
						num2 = 14;
						text = "00001";
						goto IL_01a0;
						IL_01a0:
						num2 = 15;
						DC_Main.M = 0;
						goto IL_0396;
						IL_0396:
						num2 = 17;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_01ae;
						}
						goto IL_03b5;
						IL_03b5:
						num2 = 25;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO,VCH_DATE,CO_BOOK,OLD_VCH_NO FROM CASH_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY VCH_DATE,VCH_NO"));
						goto IL_042f;
						IL_042f:
						num2 = 26;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_043e;
						IL_043e:
						num2 = 27;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_0456;
						}
						goto IL_0483;
						IL_0456:
						num2 = 28;
						ProgressBar1.Value = 0;
						goto IL_0466;
						IL_0466:
						num2 = 29;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_0483;
						IL_0483:
						num2 = 31;
						DC_Main.M = 0;
						goto IL_056a;
						IL_056a:
						num2 = 33;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_0491;
						}
						goto IL_0589;
						IL_0589:
						num2 = 39;
						DC_Main.X++;
						goto IL_0599;
						IL_0491:
						num2 = 34;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE CASH_DATA SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0536;
						IL_0536:
						num2 = 35;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_0551;
						IL_0551:
						num2 = 36;
						Application.DoEvents();
						goto IL_055a;
						IL_055a:
						num2 = 37;
						DC_Main.M++;
						goto IL_056a;
						IL_01ae:
						num2 = 18;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE CASH_DATA SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND  CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_027b;
						IL_027b:
						num2 = 19;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE CASH_DATA SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_033d;
						end_IL_0001_2:
						break;
					}
					num2 = 42;
					ProgressBar1.Value = 0;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1745;
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
						tBookName.Text = DC_Main.ColValue[0];
					}
					((Control)tBookCode).Focus();
				}
			}
			else
			{
				tBookName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["BOOK_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void BtnWhSale_Click(object sender, EventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_0c5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9a: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		string text = default(string);
		DataTable dataTable = default(DataTable);
		DataTable dataTable2 = default(DataTable);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					ProgressBar progressBar;
					switch (try0001_dispatch)
					{
					default:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000b;
					case 3473:
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
								goto IL_000b;
							case 3:
								goto IL_0023;
							case 4:
								goto IL_00ae;
							case 5:
								goto IL_00bc;
							case 8:
								goto IL_00c9;
							case 9:
								goto IL_0142;
							case 10:
								goto IL_0151;
							case 11:
								goto IL_0169;
							case 12:
								goto IL_0179;
							case 13:
							case 14:
								goto IL_0196;
							case 15:
								goto IL_01a0;
							case 18:
								goto IL_01ae;
							case 19:
								goto IL_027b;
							case 20:
								goto IL_033d;
							case 21:
								goto IL_040a;
							case 22:
								goto IL_04cc;
							case 23:
								goto IL_0599;
							case 24:
								goto IL_065b;
							case 25:
								goto IL_0728;
							case 26:
								goto IL_07ea;
							case 27:
								goto IL_080f;
							case 28:
								goto IL_082a;
							case 29:
								goto IL_0833;
							case 16:
							case 17:
							case 30:
								goto IL_0843;
							case 31:
								goto IL_0862;
							case 32:
								goto IL_08dc;
							case 33:
								goto IL_08eb;
							case 34:
								goto IL_0903;
							case 35:
								goto IL_0913;
							case 36:
							case 37:
								goto IL_0930;
							case 40:
								goto IL_093e;
							case 41:
								goto IL_09e3;
							case 42:
								goto IL_0a88;
							case 43:
								goto IL_0b2d;
							case 44:
								goto IL_0bd2;
							case 45:
								goto IL_0bed;
							case 46:
								goto IL_0bf6;
							case 38:
							case 39:
							case 47:
								goto IL_0c06;
							case 48:
								goto IL_0c25;
							case 6:
							case 7:
							case 49:
								goto IL_0c35;
							case 50:
								goto IL_0c53;
							case 51:
								goto end_IL_0001_2;
							case 54:
								num2 = 54;
								Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)"");
								goto end_IL_0001_3;
							default:
								goto end_IL_0001;
							case 52:
							case 53:
							case 55:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_080f:
						num2 = 27;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_082a;
						IL_082a:
						num2 = 28;
						Application.DoEvents();
						goto IL_0833;
						IL_07ea:
						num2 = 26;
						text = Strings.Format((object)(Conversions.ToDouble(text) + 1.0), "00000");
						goto IL_080f;
						IL_0833:
						num2 = 29;
						DC_Main.M++;
						goto IL_0843;
						IL_000b:
						num2 = 2;
						if (unchecked((int)Interaction.MsgBox((object)"Are you sure to Voucher Re Numbering Data?", (MsgBoxStyle)4, (object)null)) != 6)
						{
							goto end_IL_0001_3;
						}
						goto IL_0023;
						IL_0023:
						num2 = 3;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND MAIN_BOOK IN ('WH SALES','RATE CUT')  ORDER BY CO_BOOK"));
						goto IL_00ae;
						IL_00ae:
						num2 = 4;
						dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_00bc;
						IL_00bc:
						num2 = 5;
						DC_Main.X = 0;
						goto IL_0c35;
						IL_0c35:
						num2 = 7;
						if (DC_Main.X < dataTable.Rows.Count)
						{
							goto IL_00c9;
						}
						goto IL_0c53;
						IL_0c53:
						num2 = 50;
						Interaction.MsgBox((object)"Voucher are sucessfully Re Numbering.. Please Data Refresh After Vch No Is Re Numbring.....", (MsgBoxStyle)0, (object)null);
						break;
						IL_00c9:
						num2 = 8;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO,VCH_DATE,CO_BOOK,OLD_VCH_NO FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY VCH_DATE,VCH_NO"));
						goto IL_0142;
						IL_0142:
						num2 = 9;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0151;
						IL_0151:
						num2 = 10;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_0169;
						}
						goto IL_0196;
						IL_0169:
						num2 = 11;
						ProgressBar1.Value = 0;
						goto IL_0179;
						IL_0179:
						num2 = 12;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_0196;
						IL_0196:
						num2 = 14;
						text = "00001";
						goto IL_01a0;
						IL_01a0:
						num2 = 15;
						DC_Main.M = 0;
						goto IL_0843;
						IL_0843:
						num2 = 17;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_01ae;
						}
						goto IL_0862;
						IL_0862:
						num2 = 31;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO,VCH_DATE,CO_BOOK,OLD_VCH_NO FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY VCH_DATE,VCH_NO"));
						goto IL_08dc;
						IL_08dc:
						num2 = 32;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_08eb;
						IL_08eb:
						num2 = 33;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_0903;
						}
						goto IL_0930;
						IL_0903:
						num2 = 34;
						ProgressBar1.Value = 0;
						goto IL_0913;
						IL_0913:
						num2 = 35;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_0930;
						IL_0930:
						num2 = 37;
						DC_Main.M = 0;
						goto IL_0c06;
						IL_0c06:
						num2 = 39;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_093e;
						}
						goto IL_0c25;
						IL_0c25:
						num2 = 48;
						DC_Main.X++;
						goto IL_0c35;
						IL_093e:
						num2 = 40;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE RATE_CUT_DATA SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_09e3;
						IL_09e3:
						num2 = 41;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE RATE_CUT_ISU SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0a88;
						IL_0a88:
						num2 = 42;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE RATE_CUT_REC SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0b2d;
						IL_0b2d:
						num2 = 43;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_IDTL SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0bd2;
						IL_0bd2:
						num2 = 44;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_0bed;
						IL_0bed:
						num2 = 45;
						Application.DoEvents();
						goto IL_0bf6;
						IL_0bf6:
						num2 = 46;
						DC_Main.M++;
						goto IL_0c06;
						IL_01ae:
						num2 = 18;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE RATE_CUT_DATA SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND  CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_027b;
						IL_027b:
						num2 = 19;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE RATE_CUT_DATA SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_033d;
						IL_033d:
						num2 = 20;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE RATE_CUT_ISU SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND  CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_040a;
						IL_040a:
						num2 = 21;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE RATE_CUT_ISU SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_04cc;
						IL_04cc:
						num2 = 22;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE RATE_CUT_REC SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0599;
						IL_0599:
						num2 = 23;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE RATE_CUT_REC SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_065b;
						IL_065b:
						num2 = 24;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE SL_IDTL SET OLD_VCH_NO = '", dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0728;
						IL_0728:
						num2 = 25;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_IDTL SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_07ea;
						end_IL_0001_2:
						break;
					}
					num2 = 51;
					ProgressBar1.Value = 0;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 3473;
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

	private void Pnl1_DoubleClick(object sender, EventArgs e)
	{
		((Control)btnSlWithAc).Visible = true;
	}

	private void BtnSlWithAc_Click(object sender, EventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between Unknown and I4
		//IL_0bc3: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		string text = default(string);
		DataTable dataTable = default(DataTable);
		DataTable dataTable2 = default(DataTable);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					ProgressBar progressBar;
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						if (unchecked((int)Interaction.MsgBox((object)"Are you sure to Voucher Re Numbering Data?", (MsgBoxStyle)4, (object)null)) != 6)
						{
							goto end_IL_0001;
						}
						goto IL_001a;
					case 3288:
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
								goto IL_001a;
							case 3:
								goto IL_0023;
							case 4:
								goto IL_00ae;
							case 5:
								goto IL_00bc;
							case 8:
								goto IL_00c9;
							case 9:
								goto IL_0142;
							case 10:
								goto IL_0151;
							case 11:
								goto IL_0169;
							case 12:
								goto IL_0179;
							case 13:
							case 14:
								goto IL_0196;
							case 15:
								goto IL_01a0;
							case 18:
								goto IL_01ae;
							case 19:
								goto IL_02d8;
							case 20:
								goto IL_03e4;
							case 21:
								goto IL_03f6;
							case 22:
								goto IL_0414;
							case 23:
								goto IL_04ff;
							case 24:
								goto IL_0531;
							case 25:
								goto IL_063c;
							case 26:
								goto IL_064e;
							case 27:
								goto IL_066c;
							case 28:
							case 29:
							case 30:
							case 31:
								goto IL_0733;
							case 32:
								goto IL_07f5;
							case 33:
								goto IL_081a;
							case 34:
								goto IL_0835;
							case 35:
								goto IL_083e;
							case 16:
							case 17:
							case 36:
								goto IL_084e;
							case 37:
								goto IL_086d;
							case 38:
								goto IL_08e7;
							case 39:
								goto IL_08f6;
							case 40:
								goto IL_090e;
							case 41:
								goto IL_091e;
							case 42:
							case 43:
								goto IL_093b;
							case 46:
								goto IL_0949;
							case 47:
								goto IL_09ee;
							case 48:
								goto IL_0a93;
							case 49:
								goto IL_0b38;
							case 50:
								goto IL_0b53;
							case 51:
								goto IL_0b5c;
							case 44:
							case 45:
							case 52:
								goto IL_0b6c;
							case 53:
								goto IL_0b8b;
							case 6:
							case 7:
							case 54:
								goto IL_0b9b;
							case 55:
								goto IL_0bb9;
							case 56:
								goto end_IL_0001_3;
							default:
								goto end_IL_0001_2;
							case 57:
							case 58:
								goto end_IL_0001;
							}
							goto default;
						}
						IL_081a:
						num2 = 33;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_0835;
						IL_0835:
						num2 = 34;
						Application.DoEvents();
						goto IL_083e;
						IL_07f5:
						num2 = 32;
						text = Strings.Format((object)(Conversions.ToDouble(text) + 1.0), "00000");
						goto IL_081a;
						IL_083e:
						num2 = 35;
						DC_Main.M++;
						goto IL_084e;
						IL_001a:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_0023;
						IL_0023:
						num2 = 3;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND CO_BOOK = '" + tBookCode.Text + "'"))), (object)" AND MAIN_BOOK = 'SALES'  ORDER BY CO_BOOK"));
						goto IL_00ae;
						IL_00ae:
						num2 = 4;
						dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_00bc;
						IL_00bc:
						num2 = 5;
						DC_Main.X = 0;
						goto IL_0b9b;
						IL_0b9b:
						num2 = 7;
						if (DC_Main.X < dataTable.Rows.Count)
						{
							goto IL_00c9;
						}
						goto IL_0bb9;
						IL_0bb9:
						num2 = 55;
						Interaction.MsgBox((object)"Voucher are sucessfully Re Numbering.. Please Data Refresh After Vch No Is Re Numbring.....", (MsgBoxStyle)0, (object)null);
						break;
						IL_00c9:
						num2 = 8;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_BOOK,VCH_DATE,AC_CODE,NET_AMT,TOT_AMT FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY CO_BOOK,VCH_DATE,AC_CODE"));
						goto IL_0142;
						IL_0142:
						num2 = 9;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0151;
						IL_0151:
						num2 = 10;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_0169;
						}
						goto IL_0196;
						IL_0169:
						num2 = 11;
						ProgressBar1.Value = 0;
						goto IL_0179;
						IL_0179:
						num2 = 12;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_0196;
						IL_0196:
						num2 = 14;
						text = "00001";
						goto IL_01a0;
						IL_01a0:
						num2 = 15;
						DC_Main.M = 0;
						goto IL_084e;
						IL_084e:
						num2 = 17;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_01ae;
						}
						goto IL_086d;
						IL_086d:
						num2 = 37;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO,VCH_DATE,CO_BOOK,OLD_VCH_NO,AC_CODE,NET_AMT FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable.Rows[DC_Main.X]["CO_BOOK"]), (object)"' ORDER BY VCH_DATE,VCH_NO"));
						goto IL_08e7;
						IL_08e7:
						num2 = 38;
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_08f6;
						IL_08f6:
						num2 = 39;
						if (dataTable2.Rows.Count > 0)
						{
							goto IL_090e;
						}
						goto IL_093b;
						IL_090e:
						num2 = 40;
						ProgressBar1.Value = 0;
						goto IL_091e;
						IL_091e:
						num2 = 41;
						ProgressBar1.Maximum = dataTable2.Rows.Count;
						goto IL_093b;
						IL_093b:
						num2 = 43;
						DC_Main.M = 0;
						goto IL_0b6c;
						IL_0b6c:
						num2 = 45;
						if (DC_Main.M < dataTable2.Rows.Count)
						{
							goto IL_0949;
						}
						goto IL_0b8b;
						IL_0b8b:
						num2 = 53;
						DC_Main.X++;
						goto IL_0b9b;
						IL_0949:
						num2 = 46;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DATA SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_09ee;
						IL_09ee:
						num2 = 47;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DETL SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0a93;
						IL_0a93:
						num2 = 48;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_IDTL SET VCH_NO = NEW_VCH_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), dataTable2.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
						goto IL_0b38;
						IL_0b38:
						num2 = 49;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_0b53;
						IL_0b53:
						num2 = 50;
						Application.DoEvents();
						goto IL_0b5c;
						IL_0b5c:
						num2 = 51;
						DC_Main.M++;
						goto IL_0b6c;
						IL_01ae:
						num2 = 18;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DATA SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND AC_CODE = '"), dataTable2.Rows[DC_Main.M]["AC_CODE"]), (object)"' AND NET_AMT = "), dataTable2.Rows[DC_Main.M]["NET_AMT"]), (object)" AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(dataTable2.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"'")));
						goto IL_02d8;
						IL_02d8:
						num2 = 19;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_BOOK,VCH_NO,VCH_DATE,AC_CODE,SUM(NET_AMT) As NetAmt,SUM(OTH_AMT) As OthAmt FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND AC_CODE = '"), dataTable2.Rows[DC_Main.M]["AC_CODE"]), (object)"' AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(dataTable2.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"' GROUP BY CO_BOOK,VCH_NO,VCH_DATE,AC_CODE HAVING SUM(NET_AMT) = "), dataTable2.Rows[DC_Main.M]["NET_AMT"]), (object)" "));
						goto IL_03e4;
						IL_03e4:
						num2 = 20;
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_03f6;
						IL_03f6:
						num2 = 21;
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							goto IL_0414;
						}
						goto IL_0733;
						IL_0414:
						num2 = 22;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DETL SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND AC_CODE = '"), dataTable2.Rows[DC_Main.M]["AC_CODE"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
						goto IL_04ff;
						IL_04ff:
						num2 = 23;
						if (Operators.ConditionalCompareObjectGreater(DC_Main.Tbl.Rows[0]["OthAmt"], (object)0, false))
						{
							goto IL_0531;
						}
						goto IL_0733;
						IL_0531:
						num2 = 24;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_BOOK,VCH_NO,VCH_DATE,AC_CODE,SUM(IT_NET_AMT) As NetAmt FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND AC_CODE = '"), dataTable2.Rows[DC_Main.M]["AC_CODE"]), (object)"' AND VCH_DATE = '"), (object)Strings.Format((object)Conversions.ToDate(dataTable2.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"' GROUP BY CO_BOOK,VCH_NO,VCH_DATE,AC_CODE HAVING SUM(IT_NET_AMT) = "), DC_Main.Tbl.Rows[0]["OthAmt"]), (object)" "));
						goto IL_063c;
						IL_063c:
						num2 = 25;
						DC_Main.RsIt = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_064e;
						IL_064e:
						num2 = 26;
						if (DC_Main.RsIt.Rows.Count > 0)
						{
							goto IL_066c;
						}
						goto IL_0733;
						IL_066c:
						num2 = 27;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_IDTL SET NEW_VCH_NO = '" + text + "',VCH_NO = 'A" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"'  AND VCH_NO = '"), DC_Main.RsIt.Rows[0]["VCH_NO"]), (object)"'")));
						goto IL_0733;
						IL_0733:
						num2 = 31;
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AD_ADJ SET SBILL_NO = '" + text + "',SBILL_HD_VCH_NO = '" + text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SBILL_LC_CODE = '" + DC_Main.MLc_code + "' AND SBILL_YRCD = '" + DC_Main.MCo_year + "' AND SBILL_DBCD = '"), dataTable2.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND SBILL_AMT <> '"), dataTable2.Rows[DC_Main.M]["TOT_AMT"]), (object)"'")));
						goto IL_07f5;
						end_IL_0001_3:
						break;
					}
					num2 = 56;
					ProgressBar1.Value = 0;
					break;
				}
				end_IL_0001_2:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 3288;
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
}
