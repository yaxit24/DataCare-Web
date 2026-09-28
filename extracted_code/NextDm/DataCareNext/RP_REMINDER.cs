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
public class RP_REMINDER : Form
{
	public enum GridViewColumnType
	{
		TextBox,
		InvisibleTextBoxCell
	}

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
	[AccessedThroughProperty("btnBirthday")]
	private Button _btnBirthday;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnDhrn")]
	private Button _btnDhrn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnWhSales")]
	private Button _btnWhSales;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSales")]
	private Button _BtnSales;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOrder")]
	private Button _btnOrder;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnSchm")]
	private Button _btnSchm;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Timer1")]
	private Timer _Timer1;

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
	[AccessedThroughProperty("btnReminder")]
	private Button _btnReminder;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnUserReqest")]
	private Button _btnUserReqest;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnWebData")]
	private Button _btnWebData;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTodaySale")]
	private Button _btnTodaySale;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnItmInOut")]
	private Button _btnItmInOut;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SimpleButton1")]
	private SimpleButton _SimpleButton1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkKrOrdRec")]
	private CheckBox _chkKrOrdRec;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnPurc")]
	private Button _btnPurc;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string RptTitel;

	private string RptShow;

	private string LastOpenMenu;

	private double ColCon;

	private int BookCol;

	private int VchCol;

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
	[AccessedThroughProperty("Panel1")]
	private virtual Panel _Panel1;

	internal virtual Panel Panel1
	{
		get
		{
			return _Panel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Panel1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Panel2")]
	private virtual Panel _Panel2;

	internal virtual Panel Panel2
	{
		get
		{
			return _Panel2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Panel2 = value;
		}
	}

	internal virtual Button btnBirthday
	{
		[CompilerGenerated]
		get
		{
			return _btnBirthday;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnBirthday_Click;
			Button val = _btnBirthday;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBirthday = value;
			val = _btnBirthday;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button btnDhrn
	{
		[CompilerGenerated]
		get
		{
			return _btnDhrn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDhrn_Click;
			Button val = _btnDhrn;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnDhrn = value;
			val = _btnDhrn;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button btnWhSales
	{
		[CompilerGenerated]
		get
		{
			return _btnWhSales;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnWhSales_Click;
			Button val = _btnWhSales;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWhSales = value;
			val = _btnWhSales;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button BtnSales
	{
		[CompilerGenerated]
		get
		{
			return _BtnSales;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSales_Click;
			Button val = _BtnSales;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSales = value;
			val = _BtnSales;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button btnOrder
	{
		[CompilerGenerated]
		get
		{
			return _btnOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOrder_Click;
			Button val = _btnOrder;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOrder = value;
			val = _btnOrder;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button btnSchm
	{
		[CompilerGenerated]
		get
		{
			return _btnSchm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSchm_Click;
			Button val = _btnSchm;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnSchm = value;
			val = _btnSchm;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblClock")]
	private virtual Label _lblClock;

	internal virtual Label lblClock
	{
		get
		{
			return _lblClock;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblClock = value;
		}
	}

	internal virtual Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return _Timer1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Timer1_Tick;
			Timer val = _Timer1;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			_Timer1 = value;
			val = _Timer1;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblDay")]
	private virtual Label _lblDay;

	internal virtual Label lblDay
	{
		get
		{
			return _lblDay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblDay = value;
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

	internal virtual Button btnReminder
	{
		[CompilerGenerated]
		get
		{
			return _btnReminder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnReminder_Click;
			Button val = _btnReminder;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnReminder = value;
			val = _btnReminder;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button btnUserReqest
	{
		[CompilerGenerated]
		get
		{
			return _btnUserReqest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnUserReqest_Click;
			Button val = _btnUserReqest;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnUserReqest = value;
			val = _btnUserReqest;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button btnWebData
	{
		[CompilerGenerated]
		get
		{
			return _btnWebData;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnWebData_Click;
			Button val = _btnWebData;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWebData = value;
			val = _btnWebData;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button btnTodaySale
	{
		[CompilerGenerated]
		get
		{
			return _btnTodaySale;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnTodaySale_Click;
			Button val = _btnTodaySale;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTodaySale = value;
			val = _btnTodaySale;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button btnItmInOut
	{
		[CompilerGenerated]
		get
		{
			return _btnItmInOut;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnItmInOut_Click;
			Button val = _btnItmInOut;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnItmInOut = value;
			val = _btnItmInOut;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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

	internal virtual SimpleButton SimpleButton1
	{
		[CompilerGenerated]
		get
		{
			return _SimpleButton1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = SimpleButton1_Click;
			SimpleButton val = _SimpleButton1;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_SimpleButton1 = value;
			val = _SimpleButton1;
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
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(DGV_CellDoubleClick);
			DataGridViewX val2 = _DGV;
			if (val2 != null)
			{
				((DataGridView)val2).CellDoubleClick -= val;
			}
			_DGV = value;
			val2 = _DGV;
			if (val2 != null)
			{
				((DataGridView)val2).CellDoubleClick += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Button1")]
	private virtual Button _Button1;

	internal virtual Button Button1
	{
		get
		{
			return _Button1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Button1 = value;
		}
	}

	internal virtual CheckBox chkKrOrdRec
	{
		[CompilerGenerated]
		get
		{
			return _chkKrOrdRec;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkKrOrdRec_Click;
			CheckBox val = _chkKrOrdRec;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_chkKrOrdRec = value;
			val = _chkKrOrdRec;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Button btnPurc
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
			EventHandler eventHandler = BtnPurc_Click;
			Button val = _btnPurc;
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

	public RP_REMINDER()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((Form)this).Load += RP_REMINDER_Load;
		((Form)this).Closed += RP_REMINDER_Closed;
		((Control)this).KeyDown += new KeyEventHandler(RP_REMINDER_KeyDown);
		BookCol = 0;
		VchCol = 0;
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
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected O, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Expected O, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047f: Expected O, but got Unknown
		//IL_04e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ec: Expected O, but got Unknown
		//IL_0596: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Expected O, but got Unknown
		//IL_0615: Unknown result type (might be due to invalid IL or missing references)
		//IL_061f: Expected O, but got Unknown
		//IL_06c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d3: Expected O, but got Unknown
		//IL_0736: Unknown result type (might be due to invalid IL or missing references)
		//IL_0740: Expected O, but got Unknown
		//IL_07ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f4: Expected O, but got Unknown
		//IL_0857: Unknown result type (might be due to invalid IL or missing references)
		//IL_0861: Expected O, but got Unknown
		//IL_090b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0915: Expected O, but got Unknown
		//IL_0978: Unknown result type (might be due to invalid IL or missing references)
		//IL_0982: Expected O, but got Unknown
		//IL_0a5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a64: Expected O, but got Unknown
		//IL_0ad2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0adc: Expected O, but got Unknown
		//IL_0d3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d44: Expected O, but got Unknown
		//IL_0d78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dee: Expected O, but got Unknown
		//IL_0e22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea9: Expected O, but got Unknown
		//IL_0edd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f64: Expected O, but got Unknown
		//IL_0f98: Unknown result type (might be due to invalid IL or missing references)
		//IL_1015: Unknown result type (might be due to invalid IL or missing references)
		//IL_101f: Expected O, but got Unknown
		//IL_1053: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10da: Expected O, but got Unknown
		//IL_110e: Unknown result type (might be due to invalid IL or missing references)
		//IL_118a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1194: Expected O, but got Unknown
		//IL_11c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1244: Unknown result type (might be due to invalid IL or missing references)
		//IL_124e: Expected O, but got Unknown
		//IL_1282: Unknown result type (might be due to invalid IL or missing references)
		//IL_12fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1308: Expected O, but got Unknown
		//IL_133c: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c2: Expected O, but got Unknown
		//IL_13f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1472: Unknown result type (might be due to invalid IL or missing references)
		//IL_147c: Expected O, but got Unknown
		//IL_14b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_152c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1536: Expected O, but got Unknown
		//IL_1567: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ed: Expected O, but got Unknown
		//IL_161e: Unknown result type (might be due to invalid IL or missing references)
		//IL_172f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1739: Expected O, but got Unknown
		//IL_177a: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_17f3: Expected O, but got Unknown
		//IL_1833: Unknown result type (might be due to invalid IL or missing references)
		//IL_189f: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a9: Expected O, but got Unknown
		//IL_1954: Unknown result type (might be due to invalid IL or missing references)
		//IL_195e: Expected O, but got Unknown
		//IL_19f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a00: Expected O, but got Unknown
		//IL_1a81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8b: Expected O, but got Unknown
		//IL_1b59: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b63: Expected O, but got Unknown
		//IL_1bf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c02: Expected O, but got Unknown
		//IL_1c80: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c8a: Expected O, but got Unknown
		//IL_1d5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d69: Expected O, but got Unknown
		//IL_1dd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ddc: Expected O, but got Unknown
		//IL_1e7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e89: Expected O, but got Unknown
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_REMINDER));
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
		SimpleButton1 = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		Panel1 = new Panel();
		Button1 = new Button();
		btnUserReqest = new Button();
		btnWebData = new Button();
		btnTodaySale = new Button();
		btnPurc = new Button();
		btnItmInOut = new Button();
		btnReminder = new Button();
		btnSchm = new Button();
		btnBirthday = new Button();
		btnDhrn = new Button();
		btnWhSales = new Button();
		BtnSales = new Button();
		btnOrder = new Button();
		Panel2 = new Panel();
		lblDay = new Label();
		lblClock = new Label();
		Timer1 = new Timer(components);
		Label2 = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		Label1 = new Label();
		DGV = new DataGridViewX();
		chkKrOrdRec = new CheckBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((Control)Panel1).SuspendLayout();
		((Control)Panel2).SuspendLayout();
		((ISupportInitialize)DGV).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)SimpleButton1);
		((Control)PnlBotam).Controls.Add((Control)(object)Cr);
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
		((Control)BtnExit).Location = new Point(1219, 3);
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((Control)BtnExit).Size = new Size(87, 37);
		((Control)BtnExit).TabIndex = 25;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnDelete.ImageOptions.SvgImage");
		((Control)BtnDelete).Location = new Point(1126, 3);
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((Control)BtnDelete).Size = new Size(87, 37);
		((Control)BtnDelete).TabIndex = 24;
		BtnDelete.Text = "&Delete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnCancel.ImageOptions.SvgImage");
		((Control)BtnCancel).Location = new Point(1033, 3);
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((Control)BtnCancel).Size = new Size(87, 37);
		((Control)BtnCancel).TabIndex = 23;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		((Control)BtnSave).Location = new Point(940, 3);
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((Control)BtnSave).Size = new Size(87, 37);
		((Control)BtnSave).TabIndex = 22;
		BtnSave.Text = "&Save";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		((Control)BtnPrint).Location = new Point(847, 3);
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((Control)BtnPrint).Size = new Size(87, 37);
		((Control)BtnPrint).TabIndex = 26;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)SimpleButton1).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)SimpleButton1).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)SimpleButton1).Appearance.Options.UseFont = true;
		((BaseStyleControl)SimpleButton1).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)SimpleButton1.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("SimpleButton1.ImageOptions.SvgImage");
		((Control)SimpleButton1).Location = new Point(750, 3);
		((BaseControl)SimpleButton1).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)SimpleButton1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)SimpleButton1).Name = "SimpleButton1";
		((Control)SimpleButton1).Size = new Size(91, 37);
		((Control)SimpleButton1).TabIndex = 28;
		SimpleButton1.Text = "&Excel";
		((BaseButton)SimpleButton1).ToolTipAnchor = (ToolTipAnchor)1;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(716, 3);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 27;
		((Control)lblBook).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblBook).Dock = (DockStyle)1;
		lblBook.FlatStyle = (FlatStyle)1;
		((Control)lblBook).Font = new Font("Segoe UI", 14.25f);
		((Control)lblBook).ForeColor = Color.FromArgb(64, 0, 64);
		lblBook.ImeMode = (ImeMode)0;
		((Control)lblBook).Location = new Point(0, 0);
		((Control)lblBook).Name = "lblBook";
		((Control)lblBook).Size = new Size(1309, 32);
		((Control)lblBook).TabIndex = 8;
		lblBook.Text = "Reminder Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((Control)Panel1).BackColor = Color.Silver;
		((Control)Panel1).Controls.Add((Control)(object)Button1);
		((Control)Panel1).Controls.Add((Control)(object)btnUserReqest);
		((Control)Panel1).Controls.Add((Control)(object)btnWebData);
		((Control)Panel1).Controls.Add((Control)(object)btnTodaySale);
		((Control)Panel1).Controls.Add((Control)(object)btnPurc);
		((Control)Panel1).Controls.Add((Control)(object)btnItmInOut);
		((Control)Panel1).Controls.Add((Control)(object)btnReminder);
		((Control)Panel1).Controls.Add((Control)(object)btnSchm);
		((Control)Panel1).Controls.Add((Control)(object)btnBirthday);
		((Control)Panel1).Controls.Add((Control)(object)btnDhrn);
		((Control)Panel1).Controls.Add((Control)(object)btnWhSales);
		((Control)Panel1).Controls.Add((Control)(object)BtnSales);
		((Control)Panel1).Controls.Add((Control)(object)btnOrder);
		((Control)Panel1).Controls.Add((Control)(object)Panel2);
		((Control)Panel1).Dock = (DockStyle)4;
		((Control)Panel1).Location = new Point(1158, 32);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(151, 534);
		((Control)Panel1).TabIndex = 9;
		((Control)Button1).Dock = (DockStyle)1;
		((Control)Button1).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Button1).Location = new Point(0, 492);
		((Control)Button1).Name = "Button1";
		((Control)Button1).Padding = new Padding(15, 0, 0, 0);
		((Control)Button1).Size = new Size(151, 35);
		((Control)Button1).TabIndex = 14;
		((ButtonBase)Button1).TextAlign = (ContentAlignment)16;
		((ButtonBase)Button1).UseVisualStyleBackColor = true;
		((Control)btnUserReqest).Dock = (DockStyle)1;
		((Control)btnUserReqest).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)btnUserReqest).Location = new Point(0, 457);
		((Control)btnUserReqest).Name = "btnUserReqest";
		((Control)btnUserReqest).Padding = new Padding(15, 0, 0, 0);
		((Control)btnUserReqest).Size = new Size(151, 35);
		((Control)btnUserReqest).TabIndex = 13;
		((ButtonBase)btnUserReqest).Text = "User Request";
		((ButtonBase)btnUserReqest).TextAlign = (ContentAlignment)16;
		((ButtonBase)btnUserReqest).UseVisualStyleBackColor = true;
		((Control)btnWebData).Dock = (DockStyle)1;
		((Control)btnWebData).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)btnWebData).Location = new Point(0, 422);
		((Control)btnWebData).Name = "btnWebData";
		((Control)btnWebData).Padding = new Padding(15, 0, 0, 0);
		((Control)btnWebData).Size = new Size(151, 35);
		((Control)btnWebData).TabIndex = 12;
		((ButtonBase)btnWebData).Text = "Web Data";
		((ButtonBase)btnWebData).TextAlign = (ContentAlignment)16;
		((ButtonBase)btnWebData).UseVisualStyleBackColor = true;
		((Control)btnTodaySale).Dock = (DockStyle)1;
		((Control)btnTodaySale).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)btnTodaySale).Location = new Point(0, 387);
		((Control)btnTodaySale).Name = "btnTodaySale";
		((Control)btnTodaySale).Padding = new Padding(15, 0, 0, 0);
		((Control)btnTodaySale).Size = new Size(151, 35);
		((Control)btnTodaySale).TabIndex = 11;
		((ButtonBase)btnTodaySale).Text = "ToDay Sales";
		((ButtonBase)btnTodaySale).TextAlign = (ContentAlignment)16;
		((ButtonBase)btnTodaySale).UseVisualStyleBackColor = true;
		((Control)btnPurc).Dock = (DockStyle)1;
		((Control)btnPurc).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)btnPurc).Location = new Point(0, 352);
		((Control)btnPurc).Name = "btnPurc";
		((Control)btnPurc).Padding = new Padding(15, 0, 0, 0);
		((Control)btnPurc).Size = new Size(151, 35);
		((Control)btnPurc).TabIndex = 10;
		((ButtonBase)btnPurc).Text = "Purchase Rem";
		((ButtonBase)btnPurc).TextAlign = (ContentAlignment)16;
		((ButtonBase)btnPurc).UseVisualStyleBackColor = true;
		((Control)btnItmInOut).Dock = (DockStyle)1;
		((Control)btnItmInOut).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)btnItmInOut).Location = new Point(0, 317);
		((Control)btnItmInOut).Name = "btnItmInOut";
		((Control)btnItmInOut).Padding = new Padding(15, 0, 0, 0);
		((Control)btnItmInOut).Size = new Size(151, 35);
		((Control)btnItmInOut).TabIndex = 8;
		((ButtonBase)btnItmInOut).Text = "Item In Out";
		((ButtonBase)btnItmInOut).TextAlign = (ContentAlignment)16;
		((ButtonBase)btnItmInOut).UseVisualStyleBackColor = true;
		((Control)btnReminder).Dock = (DockStyle)1;
		((Control)btnReminder).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)btnReminder).Location = new Point(0, 282);
		((Control)btnReminder).Name = "btnReminder";
		((Control)btnReminder).Padding = new Padding(15, 0, 0, 0);
		((Control)btnReminder).Size = new Size(151, 35);
		((Control)btnReminder).TabIndex = 7;
		((ButtonBase)btnReminder).Text = "Reminder Rpt";
		((ButtonBase)btnReminder).TextAlign = (ContentAlignment)16;
		((ButtonBase)btnReminder).UseVisualStyleBackColor = true;
		((Control)btnSchm).Dock = (DockStyle)1;
		((Control)btnSchm).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)btnSchm).Location = new Point(0, 247);
		((Control)btnSchm).Name = "btnSchm";
		((Control)btnSchm).Padding = new Padding(15, 0, 0, 0);
		((Control)btnSchm).Size = new Size(151, 35);
		((Control)btnSchm).TabIndex = 6;
		((ButtonBase)btnSchm).Text = "Schm Rem";
		((ButtonBase)btnSchm).TextAlign = (ContentAlignment)16;
		((ButtonBase)btnSchm).UseVisualStyleBackColor = true;
		((Control)btnBirthday).Dock = (DockStyle)1;
		((Control)btnBirthday).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)btnBirthday).Location = new Point(0, 212);
		((Control)btnBirthday).Name = "btnBirthday";
		((Control)btnBirthday).Padding = new Padding(15, 0, 0, 0);
		((Control)btnBirthday).Size = new Size(151, 35);
		((Control)btnBirthday).TabIndex = 5;
		((ButtonBase)btnBirthday).Text = "Birthday And Anv";
		((ButtonBase)btnBirthday).TextAlign = (ContentAlignment)16;
		((ButtonBase)btnBirthday).UseVisualStyleBackColor = true;
		((Control)btnDhrn).Dock = (DockStyle)1;
		((Control)btnDhrn).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)btnDhrn).Location = new Point(0, 177);
		((Control)btnDhrn).Name = "btnDhrn";
		((Control)btnDhrn).Padding = new Padding(15, 0, 0, 0);
		((Control)btnDhrn).Size = new Size(151, 35);
		((Control)btnDhrn).TabIndex = 4;
		((ButtonBase)btnDhrn).Text = "Dhiran Rem";
		((ButtonBase)btnDhrn).TextAlign = (ContentAlignment)16;
		((ButtonBase)btnDhrn).UseVisualStyleBackColor = true;
		((Control)btnWhSales).Dock = (DockStyle)1;
		((Control)btnWhSales).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)btnWhSales).Location = new Point(0, 142);
		((Control)btnWhSales).Name = "btnWhSales";
		((Control)btnWhSales).Padding = new Padding(15, 0, 0, 0);
		((Control)btnWhSales).Size = new Size(151, 35);
		((Control)btnWhSales).TabIndex = 3;
		((ButtonBase)btnWhSales).Text = "Wh Sales Rem";
		((ButtonBase)btnWhSales).TextAlign = (ContentAlignment)16;
		((ButtonBase)btnWhSales).UseVisualStyleBackColor = true;
		((Control)BtnSales).Dock = (DockStyle)1;
		((Control)BtnSales).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)BtnSales).Location = new Point(0, 107);
		((Control)BtnSales).Name = "BtnSales";
		((Control)BtnSales).Padding = new Padding(15, 0, 0, 0);
		((Control)BtnSales).Size = new Size(151, 35);
		((Control)BtnSales).TabIndex = 2;
		((ButtonBase)BtnSales).Text = "Sales Rem";
		((ButtonBase)BtnSales).TextAlign = (ContentAlignment)16;
		((ButtonBase)BtnSales).UseVisualStyleBackColor = true;
		((Control)btnOrder).Dock = (DockStyle)1;
		((Control)btnOrder).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)btnOrder).Location = new Point(0, 72);
		((Control)btnOrder).Name = "btnOrder";
		((Control)btnOrder).Padding = new Padding(15, 0, 0, 0);
		((Control)btnOrder).Size = new Size(151, 35);
		((Control)btnOrder).TabIndex = 1;
		((ButtonBase)btnOrder).Text = "Order  Rem";
		((ButtonBase)btnOrder).TextAlign = (ContentAlignment)16;
		((ButtonBase)btnOrder).UseVisualStyleBackColor = true;
		((Control)Panel2).BackColor = Color.Silver;
		((Control)Panel2).Controls.Add((Control)(object)lblDay);
		((Control)Panel2).Controls.Add((Control)(object)lblClock);
		((Control)Panel2).Dock = (DockStyle)1;
		((Control)Panel2).Location = new Point(0, 0);
		((Control)Panel2).Name = "Panel2";
		((Control)Panel2).Size = new Size(151, 72);
		((Control)Panel2).TabIndex = 0;
		((Control)lblDay).Dock = (DockStyle)1;
		((Control)lblDay).Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblDay).ForeColor = Color.Black;
		((Control)lblDay).Location = new Point(0, 37);
		((Control)lblDay).Name = "lblDay";
		((Control)lblDay).Padding = new Padding(0, 0, 0, 7);
		((Control)lblDay).Size = new Size(151, 30);
		((Control)lblDay).TabIndex = 1;
		lblDay.Text = "Day";
		lblDay.TextAlign = (ContentAlignment)32;
		((Control)lblClock).Dock = (DockStyle)1;
		((Control)lblClock).Font = new Font("Bahnschrift SemiBold", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblClock).ForeColor = Color.Black;
		((Control)lblClock).Location = new Point(0, 0);
		((Control)lblClock).Name = "lblClock";
		((Control)lblClock).Padding = new Padding(0, 7, 0, 0);
		((Control)lblClock).Size = new Size(151, 37);
		((Control)lblClock).TabIndex = 0;
		lblClock.Text = "Clock";
		lblClock.TextAlign = (ContentAlignment)32;
		Timer1.Enabled = true;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(12, 49);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(80, 20);
		((Control)Label2).TabIndex = 123;
		Label2.Text = "From Date";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(245, 49);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 125;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(96, 49);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 124;
		mFromDt.ValidatingType = typeof(DateTime);
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(177, 49);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(62, 20);
		((Control)Label1).TabIndex = 1157;
		Label1.Text = "To Date";
		Label1.TextAlign = (ContentAlignment)64;
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.Snow;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV).ColumnHeadersHeight = 30;
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val3;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Location = new Point(11, 84);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV).RowHeadersVisible = false;
		((DataGridView)DGV).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(840, 269);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 1158;
		((ButtonBase)chkKrOrdRec).BackColor = Color.Transparent;
		((Control)chkKrOrdRec).Font = new Font("Arial", 9.75f);
		((Control)chkKrOrdRec).ForeColor = Color.Black;
		((ButtonBase)chkKrOrdRec).ImeMode = (ImeMode)0;
		((Control)chkKrOrdRec).Location = new Point(363, 47);
		((Control)chkKrOrdRec).Name = "chkKrOrdRec";
		((Control)chkKrOrdRec).RightToLeft = (RightToLeft)0;
		((Control)chkKrOrdRec).Size = new Size(229, 27);
		((Control)chkKrOrdRec).TabIndex = 1159;
		((ButtonBase)chkKrOrdRec).Text = "Cust Order Rec From Karigar";
		((ButtonBase)chkKrOrdRec).UseVisualStyleBackColor = false;
		((Control)chkKrOrdRec).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)chkKrOrdRec);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Panel1);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_REMINDER";
		((Form)this).StartPosition = (FormStartPosition)1;
		((Form)this).Text = "Reminder Report";
		((Form)this).WindowState = (FormWindowState)2;
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((Control)Panel1).ResumeLayout(false);
		((Control)Panel2).ResumeLayout(false);
		((ISupportInitialize)DGV).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void RP_REMINDER_Load(object sender, EventArgs e)
	{
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_0919: Unknown result type (might be due to invalid IL or missing references)
		//IL_091e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0928: Expected O, but got Unknown
		//IL_094d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0952: Unknown result type (might be due to invalid IL or missing references)
		//IL_095c: Expected O, but got Unknown
		//IL_09cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09da: Expected O, but got Unknown
		//IL_09f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a08: Expected O, but got Unknown
		//IL_0ab5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abc: Expected O, but got Unknown
		//IL_0b21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b30: Expected O, but got Unknown
		//IL_0b9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba9: Expected O, but got Unknown
		//IL_0c31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c40: Expected O, but got Unknown
		//IL_0cb2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbd: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
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
		DC_Main.MainPcW = 1366.0;
		DC_Main.MainPcH = 768.0;
		DC_Main.PcW = Screen.PrimaryScreen.Bounds.Width;
		DC_Main.PcH = Screen.PrimaryScreen.Bounds.Height;
		((Control)this).SuspendLayout();
		((Control)this).ResumeLayout();
		double num = (DC_Main.PcW - DC_Main.MainPcW) / DC_Main.MainPcW;
		double num2 = (DC_Main.PcH - DC_Main.MainPcH) / DC_Main.MainPcH;
		ColCon = 1.0 + num;
		checked
		{
			if (unchecked(num != 0.0 && num2 != 0.0))
			{
				((Control)this).Width = (int)Math.Round(DC_Main.PcW);
				((Control)this).Height = (int)Math.Round(DC_Main.PcH);
			}
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
				((Control)Panel1).BackColor = Color.Gray;
				((Control)Panel2).BackColor = Color.Gray;
				((Control)lblClock).ForeColor = Color.White;
				((Control)lblDay).ForeColor = Color.White;
				((DataGridView)DGV).BackgroundColor = Color.DarkGray;
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj8 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				Panel panel = Panel1;
				object? obj9 = colorConverter.ConvertFromString("174, 184, 194");
				((Control)panel).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				Panel panel2 = Panel2;
				object? obj10 = colorConverter.ConvertFromString("174, 184, 194");
				((Control)panel2).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewX dGV = DGV;
				object? obj11 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
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
				Panel panel3 = Panel1;
				object? obj16 = colorConverter.ConvertFromString("CadetBlue");
				((Control)panel3).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				Panel panel4 = Panel2;
				object? obj17 = colorConverter.ConvertFromString("CadetBlue");
				((Control)panel4).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj18 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				DataGridViewX dGV2 = DGV;
				object? obj19 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj20 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)mFromDt).AutoSize = false;
				((TextBoxBase)mToDt).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)mFromDt).Font.Size * (1.0 + num2));
				((Control)mFromDt).Font = new Font(((Control)mFromDt).Font.FontFamily, (float)num3, ((Control)mFromDt).Font.Style);
				((Control)mToDt).Font = new Font(((Control)mFromDt).Font.FontFamily, (float)num3, ((Control)mFromDt).Font.Style);
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
				}
				num3 = (int)Math.Ceiling((double)((Control)btnOrder).Font.Size * (1.0 + num2));
				Font font = ((Control)btnOrder).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
						{
							val3.Font = new Font(font.FontFamily, (float)num3, font.Style);
						}
					}
					foreach (object control4 in ((Control)Panel1).Controls)
					{
						object objectValue2 = RuntimeHelpers.GetObjectValue(control4);
						NewLateBinding.LateSet(objectValue2, (Type)null, "Font", new object[1] { (object)new Font(font.FontFamily, (float)num3, font.Style) }, (string[])null, (Type[])null);
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
			}
			lblDay.Text = Strings.Format((object)DateAndTime.Now, "dddd");
			mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK035NLVK", false) == 0)
			{
				((Control)btnWhSales).Visible = false;
				((Control)btnBirthday).Visible = false;
				((Control)btnTodaySale).Visible = false;
				((Control)btnItmInOut).Visible = false;
				((Control)btnDhrn).Visible = false;
				((Control)btnSchm).Visible = false;
			}
			if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) != 0) & (Operators.CompareString(DC_Main.MsSoftType, "E", false) != 0))
			{
				((ButtonBase)btnWebData).Text = "";
			}
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) != 0)
			{
				((ButtonBase)btnUserReqest).Text = "";
			}
			if (DC_Main.MsOpenUserRequest)
			{
				UserRequest();
				return;
			}
			if (Operators.CompareString(DC_Main.MsDefaultReminder, "R", false) == 0)
			{
				Reminder();
			}
			else if (Operators.CompareString(DC_Main.MsDefaultReminder, "B", false) == 0)
			{
				BtnBirthday_Click(btnBirthday, new EventArgs());
			}
			else if (Operators.CompareString(DC_Main.MsDefaultReminder, "O", false) == 0)
			{
				((Control)chkKrOrdRec).Visible = true;
				BtnOrder_Click(btnOrder, new EventArgs());
			}
			else if (Operators.CompareString(DC_Main.MsDefaultReminder, "S", false) == 0)
			{
				BtnSales_Click(BtnSales, new EventArgs());
			}
			else if (Operators.CompareString(DC_Main.MsDefaultReminder, "W", false) == 0)
			{
				BtnWhSales_Click(btnWhSales, new EventArgs());
			}
			else if (Operators.CompareString(DC_Main.MsDefaultReminder, "D", false) == 0)
			{
				BtnDhrn_Click(btnDhrn, new EventArgs());
			}
			else if (Operators.CompareString(DC_Main.MsDefaultReminder, "M", false) == 0)
			{
				BtnSchm_Click(btnSchm, new EventArgs());
			}
			LastOpenMenu = DC_Main.MsDefaultReminder;
		}
	}

	private void UserRequest()
	{
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Expected O, but got Unknown
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Expected O, but got Unknown
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected O, but got Unknown
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Expected O, but got Unknown
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Expected O, but got Unknown
		//IL_0720: Unknown result type (might be due to invalid IL or missing references)
		//IL_072a: Expected O, but got Unknown
		RptShow = "U";
		RptTitel = "'User Request Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		lblBook.Text = "User Request Report";
		if (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.*,B.BOOK_SNAME,B.MAIN_BOOK,B.BOOK_TBL_NAME FROM USER_REQUEST AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND PARMATION_TYPE = 'P'";
		}
		else
		{
			DC_Main.RsQry = "SELECT A.*,B.BOOK_SNAME,B.MAIN_BOOK,B.BOOK_TBL_NAME FROM USER_REQUEST AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND REQ_TIME >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text).AddDays(-1.0), "MM-dd-yyyy") + "' AND REQ_TIME <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(1.0), "MM-dd-yyyy") + "'";
		}
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0 && DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT A.*,B.BOOK_SNAME,B.MAIN_BOOK,B.BOOK_TBL_NAME FROM USER_REQUEST AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND REQ_TIME >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text).AddDays(-1.0), "MM-dd-yyyy") + "' AND REQ_TIME <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(1.0), "MM-dd-yyyy") + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		DataGridViewX dGV = DGV;
		((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)dGV).AutoGenerateColumns = false;
		DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
		((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
		checked
		{
			((DataGridView)dGV).Columns[0].Width = (int)Math.Round(45.0 * ColCon);
			((DataGridViewColumn)val).Name = "Ok";
			((DataGridView)dGV).Columns.Add("", "SrNo");
			((DataGridView)dGV).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Book");
			((DataGridView)dGV).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "VchNo");
			((DataGridView)dGV).Columns[3].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "VchDate");
			((DataGridView)dGV).Columns[4].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "AcName");
			((DataGridView)dGV).Columns[5].Width = (int)Math.Round(180.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Remark");
			((DataGridView)dGV).Columns[6].Width = (int)Math.Round(140.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "MainUser");
			((DataGridView)dGV).Columns[7].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "ReqUser");
			((DataGridView)dGV).Columns[8].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "RType");
			((DataGridView)dGV).Columns[9].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "PType");
			((DataGridView)dGV).Columns[10].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Book");
			((DataGridView)dGV).Columns[11].Visible = false;
			((DataGridView)dGV).Columns.Add("", "MainBook");
			((DataGridView)dGV).Columns[12].Visible = false;
			((DataGridView)dGV).Columns.Add("", "BkTbl");
			((DataGridView)dGV).Columns[13].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			BookCol = 11;
			VchCol = 3;
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				((DataGridView)dGV).Rows.Add();
				((DataGridView)dGV)[1, DC_Main.X].Value = DC_Main.X + 1;
				((DataGridView)dGV)[2, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["BOOK_SNAME"]);
				((DataGridView)dGV)[3, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_NO"]);
				((DataGridView)dGV)[4, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
				((DataGridView)dGV)[5, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_NAME"]);
				((DataGridView)dGV)[6, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["EDIT_RMARK"]);
				((DataGridView)dGV)[7, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["USER_NAME"]);
				((DataGridView)dGV)[8, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["EDIT_USER"]);
				((DataGridView)dGV)[9, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["TOT_AMT"]);
				if (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0)
				{
					if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[DC_Main.X]["REQ_TYPE"], (object)"E", false))
					{
						((DataGridView)dGV)[9, DC_Main.X].Value = "Edit";
					}
					else
					{
						((DataGridView)dGV)[9, DC_Main.X].Value = "Delete";
					}
					if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[DC_Main.X]["PARMATION_TYPE"], (object)"A", false))
					{
						((DataGridView)dGV)[10, DC_Main.X].Value = "Accept";
					}
					else if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[DC_Main.X]["PARMATION_TYPE"], (object)"R", false))
					{
						((DataGridView)dGV)[10, DC_Main.X].Value = "Reject";
					}
					else if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[DC_Main.X]["PARMATION_TYPE"], (object)"P", false))
					{
						((DataGridView)dGV)[10, DC_Main.X].Value = "Panding";
					}
				}
				else
				{
					if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[DC_Main.X]["REQ_TYPE"], (object)"E", false))
					{
						((DataGridView)dGV)[9, DC_Main.X].Value = "Edit";
					}
					else
					{
						((DataGridView)dGV)[9, DC_Main.X].Value = "Delete";
					}
					if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[DC_Main.X]["PARMATION_TYPE"], (object)"A", false))
					{
						((DataGridView)dGV)[10, DC_Main.X].Value = "Accept";
					}
					else if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[DC_Main.X]["PARMATION_TYPE"], (object)"R", false))
					{
						((DataGridView)dGV)[10, DC_Main.X].Value = "Reject";
					}
					else if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[DC_Main.X]["PARMATION_TYPE"], (object)"P", false))
					{
						((DataGridView)dGV)[10, DC_Main.X].Value = "Panding";
					}
				}
				((DataGridView)dGV)[11, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CO_BOOK"]);
				((DataGridView)dGV)[12, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["MAIN_BOOK"]);
				((DataGridView)dGV)[13, DC_Main.X].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["BOOK_TBL_NAME"], (object)"");
				DC_Main.X++;
			}
			dGV = null;
		}
	}

	private void Reminder()
	{
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Expected O, but got Unknown
		((Control)chkKrOrdRec).Visible = false;
		RptShow = "R";
		RptTitel = "'Reminder Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		DC_Main.RsQry = "SELECT A.*,B.AC_MOBILE FROM REM_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' and A.LC_CODE = '" + DC_Main.MLc_code + "' AND REM_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND REM_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' ORDER BY REM_DATE,A.AC_NAME ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		DataGridViewX dGV = DGV;
		((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)dGV).AutoGenerateColumns = false;
		DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
		((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
		((DataGridView)dGV).Columns[0].Visible = false;
		((DataGridViewColumn)val).Name = "Ok";
		((DataGridView)dGV).Columns.Add("", "SrNo");
		checked
		{
			((DataGridView)dGV).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "AcName");
			((DataGridView)dGV).Columns[2].Width = (int)Math.Round(250.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Remark");
			((DataGridView)dGV).Columns[3].Width = (int)Math.Round(320.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "EntDate");
			((DataGridView)dGV).Columns[4].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "RemDate");
			((DataGridView)dGV).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Mobile");
			((DataGridView)dGV).Columns[6].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Book");
			((DataGridView)dGV).Columns[7].Visible = false;
			((DataGridView)dGV).Columns.Add("", "VchNo");
			((DataGridView)dGV).Columns[8].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[9].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[10].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[11].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[12].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[13].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			BookCol = 7;
			VchCol = 8;
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				((DataGridView)dGV).Rows.Add();
				((DataGridView)dGV)[1, DC_Main.X].Value = DC_Main.X + 1;
				((DataGridView)dGV)[2, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_NAME"]);
				((DataGridView)dGV)[3, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["IT_DESC"]);
				((DataGridView)dGV)[4, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
				((DataGridView)dGV)[5, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["REM_DATE"]), "dd/MM/yyyy");
				((DataGridView)dGV)[6, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_MOBILE"]);
				((DataGridView)dGV)[7, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CO_BOOK"]);
				((DataGridView)dGV)[8, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_NO"]);
				DC_Main.X++;
			}
			dGV = null;
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		lblClock.Text = Conversions.ToString(DateAndTime.TimeOfDay);
	}

	private void BtnReminder_Click(object sender, EventArgs e)
	{
		((Control)chkKrOrdRec).Visible = false;
		Reminder();
	}

	private void RP_REMINDER_Closed(object sender, EventArgs e)
	{
		DC_Main.ExeQuteDc("DELETE FROM REPORT_DATA ");
		DC_Main.MsOpenUserRequest = false;
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		Reminder();
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
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		MaskedTextBox MsDate = mToDt;
		DC_Main.SetDate(ref MsDate);
		mToDt = MsDate;
		if (!DC_Main.RongDate)
		{
			if (Operators.CompareString(LastOpenMenu, "R", false) == 0)
			{
				Reminder();
			}
			else if (Operators.CompareString(LastOpenMenu, "B", false) == 0)
			{
				BtnBirthday_Click(btnBirthday, new EventArgs());
			}
			else if (Operators.CompareString(LastOpenMenu, "O", false) == 0)
			{
				BtnOrder_Click(btnOrder, new EventArgs());
			}
			else if (Operators.CompareString(LastOpenMenu, "S", false) == 0)
			{
				BtnSales_Click(BtnSales, new EventArgs());
			}
			else if (Operators.CompareString(LastOpenMenu, "W", false) == 0)
			{
				BtnWhSales_Click(btnWhSales, new EventArgs());
			}
			else if (Operators.CompareString(LastOpenMenu, "D", false) == 0)
			{
				BtnDhrn_Click(btnDhrn, new EventArgs());
			}
			else if (Operators.CompareString(LastOpenMenu, "M", false) == 0)
			{
				BtnSchm_Click(btnSchm, new EventArgs());
			}
			else if (Operators.CompareString(LastOpenMenu, "P", false) == 0)
			{
				BtnPurc_Click(btnSchm, new EventArgs());
			}
		}
	}

	private void mFromDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mFromDt).SelectionStart = 0;
		((TextBoxBase)mFromDt).SelectionLength = Strings.Len(mFromDt.Text);
	}

	private void mToDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToDt).SelectionStart = 0;
		((TextBoxBase)mToDt).SelectionLength = Strings.Len(mToDt.Text);
	}

	private void BtnOrder_Click(object sender, EventArgs e)
	{
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected O, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Expected O, but got Unknown
		//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0903: Expected O, but got Unknown
		//IL_0933: Unknown result type (might be due to invalid IL or missing references)
		((Control)chkKrOrdRec).Visible = true;
		LastOpenMenu = "O";
		RptTitel = "'Order Reminder Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		lblBook.Text = "Order Reminder";
		if (chkKrOrdRec.Checked)
		{
			DC_Main.RsQry = "SELECT A.*,B.AC_NAME,B.AC_MOBILE,C.IT_NAME FROM (APR_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE)LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ORNA_REC_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.ORNA_REC_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' ORDER BY A.ORNA_REC_DATE,B.AC_NAME ";
		}
		else
		{
			DC_Main.RsQry = "SELECT A.*,B.AC_MOBILE FROM SL_ORD_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.DEL_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.DEL_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' ORDER BY A.DEL_DATE,A.AC_NAME ";
		}
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		DataGridViewX dGV = DGV;
		((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)dGV).AutoGenerateColumns = false;
		DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
		((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
		((DataGridView)dGV).Columns[0].Visible = false;
		((DataGridViewColumn)val).Name = "Ok";
		checked
		{
			if (chkKrOrdRec.Checked)
			{
				((DataGridView)dGV).Columns.Add("", "SrNo");
				((DataGridView)dGV).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "AcName");
				((DataGridView)dGV).Columns[2].Width = (int)Math.Round(210.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Mobile");
				((DataGridView)dGV).Columns[3].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "IsuDate");
				((DataGridView)dGV).Columns[4].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Book");
				((DataGridView)dGV).Columns[5].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "IsuNo");
				((DataGridView)dGV).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Remark");
				((DataGridView)dGV).Columns[7].Width = (int)Math.Round(150.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Order Ac Name");
				((DataGridView)dGV).Columns[8].Width = (int)Math.Round(225.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "It Name");
				((DataGridView)dGV).Columns[9].Width = (int)Math.Round(150.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "ItmWt");
				((DataGridView)dGV).Columns[10].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)dGV).Columns[10].DefaultCellStyle.Format = "N3";
			}
			else
			{
				((DataGridView)dGV).Columns.Add("", "SrNo");
				((DataGridView)dGV).Columns[1].Width = (int)Math.Round(60.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "AcName");
				((DataGridView)dGV).Columns[2].Width = (int)Math.Round(250.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Mobile");
				((DataGridView)dGV).Columns[3].Width = (int)Math.Round(110.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "OrdDate");
				((DataGridView)dGV).Columns[4].Width = (int)Math.Round(110.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Book");
				((DataGridView)dGV).Columns[5].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "OrdNo");
				((DataGridView)dGV).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Remark");
				((DataGridView)dGV).Columns[7].Width = (int)Math.Round(140.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "OrdAmt");
				((DataGridView)dGV).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)dGV).Columns[8].DefaultCellStyle.Format = "N2";
				((DataGridView)dGV).Columns.Add("", "");
				((DataGridView)dGV).Columns[9].Visible = false;
				((DataGridView)dGV).Columns.Add("", "");
				((DataGridView)dGV).Columns[10].Visible = false;
			}
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[11].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[12].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[13].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			BookCol = 5;
			VchCol = 6;
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
				return;
			}
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				if (chkKrOrdRec.Checked)
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[1, DC_Main.X].Value = DC_Main.X + 1;
					((DataGridView)dGV)[2, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_NAME"]);
					((DataGridView)dGV)[3, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_MOBILE"]);
					((DataGridView)dGV)[4, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
					((DataGridView)dGV)[5, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CO_BOOK"]);
					((DataGridView)dGV)[6, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_NO"]);
					((DataGridView)dGV)[7, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["ITM_REMARK"]);
					((DataGridView)dGV)[8, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["ISU_AC_NAME"]);
					((DataGridView)dGV)[9, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["IT_NAME"]);
					((DataGridView)dGV)[10, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["ITM_GWT"]);
				}
				else
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[1, DC_Main.X].Value = DC_Main.X + 1;
					((DataGridView)dGV)[2, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_NAME"]);
					((DataGridView)dGV)[3, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_MOBILE"]);
					((DataGridView)dGV)[4, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
					((DataGridView)dGV)[5, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CO_BOOK"]);
					((DataGridView)dGV)[6, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_NO"]);
					((DataGridView)dGV)[7, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DESC"]);
					((DataGridView)dGV)[8, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["NET_AMT"]);
				}
				DC_Main.X++;
			}
			dGV = null;
		}
	}

	private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
	{
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND CO_BOOK = '"), ((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells[BookCol].Value), (object)""), (object)"' "));
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
		DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells[VchCol].Value, (object)""));
		if (Operators.CompareString(DC_Main.CurBookMain, "OPSTK", false) == 0)
		{
			if (Strings.Len(DC_Main.CurBookVch) != 1)
			{
				TR_TAG_OPBL tR_TAG_OPBL = new TR_TAG_OPBL();
				((Form)tR_TAG_OPBL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_TAG_OPBL).Show();
				((Control)tR_TAG_OPBL).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "REM ENTRY", false) == 0)
		{
			UT_REMINDER uT_REMINDER = new UT_REMINDER();
			((Form)uT_REMINDER).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)uT_REMINDER).Show();
			((Control)uT_REMINDER).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "TAG GEN", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR TAG", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG TAG", false) == 0))
		{
			TR_TAG_OPBL tR_TAG_OPBL2 = new TR_TAG_OPBL();
			((Form)tR_TAG_OPBL2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_OPBL2).Show();
			((Control)tR_TAG_OPBL2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG CANCEL", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN = new TR_TAG_CAN();
			((Form)tR_TAG_CAN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN).Show();
			((Control)tR_TAG_CAN).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "STOCK ADJUST", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN2 = new TR_TAG_CAN();
			((Form)tR_TAG_CAN2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN2).Show();
			((Control)tR_TAG_CAN2).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "APR ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CON REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CON ISU", false) == 0))
		{
			TR_APR_ISU tR_APR_ISU = new TR_APR_ISU();
			((Form)tR_APR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_APR_ISU).Show();
			((Control)tR_APR_ISU).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "APR RTN", false) == 0)
		{
			TR_APR_ISU tR_APR_ISU2 = new TR_APR_ISU();
			((Form)tR_APR_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_APR_ISU2).Show();
			((Control)tR_APR_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES ORDER", false) == 0)
		{
			TR_SALE_ORD tR_SALE_ORD = new TR_SALE_ORD();
			((Form)tR_SALE_ORD).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_ORD).Show();
			((Control)tR_SALE_ORD).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES ORDER", false) == 0)
		{
			TR_SALE_ORD tR_SALE_ORD2 = new TR_SALE_ORD();
			((Form)tR_SALE_ORD2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_ORD2).Show();
			((Control)tR_SALE_ORD2).Focus();
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
			TR_TAG_CAN tR_TAG_CAN3 = new TR_TAG_CAN();
			((Form)tR_TAG_CAN3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN3).Show();
			((Control)tR_TAG_CAN3).Focus();
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

	private void BtnSales_Click(object sender, EventArgs e)
	{
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
		//IL_0692: Expected O, but got Unknown
		//IL_06c2: Unknown result type (might be due to invalid IL or missing references)
		((Control)chkKrOrdRec).Visible = false;
		LastOpenMenu = "S";
		RptTitel = "'Sales Reminder Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		lblBook.Text = "Sales Reminder";
		DC_Main.ExeQuteDc("UPDATE SL_DATA SET CR_DAYS = 0 WHERE CR_DAYS IS NULL");
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.BOOK_SNAME,C.AC_MOBILE As PARTY_MOBILE FROM (SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE ='" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CR_DAYS <> 0 AND A.BILL_OS <> 0 AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text).AddDays(-60.0), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(60.0), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" ORDER BY A.AC_NAME,A.VCH_NO "));
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		DataGridViewX dGV = DGV;
		((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)dGV).AutoGenerateColumns = false;
		DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
		((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
		((DataGridView)dGV).Columns[0].Visible = false;
		((DataGridViewColumn)val).Name = "Ok";
		((DataGridView)dGV).Columns.Add("", "SrNo");
		checked
		{
			((DataGridView)dGV).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "AcName");
			((DataGridView)dGV).Columns[2].Width = (int)Math.Round(260.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Mobile");
			((DataGridView)dGV).Columns[3].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "VchDate");
			((DataGridView)dGV).Columns[4].Width = (int)Math.Round(105.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "VType");
			((DataGridView)dGV).Columns[5].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Book");
			((DataGridView)dGV).Columns[6].Visible = false;
			((DataGridView)dGV).Columns.Add("", "VchNo");
			((DataGridView)dGV).Columns[7].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "TotAmt");
			((DataGridView)dGV).Columns[8].Width = (int)Math.Round(95.0 * ColCon);
			((DataGridView)dGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)dGV).Columns.Add("", "OsAmt");
			((DataGridView)dGV).Columns[9].Width = (int)Math.Round(95.0 * ColCon);
			((DataGridView)dGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[9].DefaultCellStyle.Format = "N2";
			((DataGridView)dGV).Columns.Add("", "LedrBal");
			((DataGridView)dGV).Columns[10].Width = (int)Math.Round(95.0 * ColCon);
			((DataGridView)dGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[11].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[12].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[13].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			BookCol = 6;
			VchCol = 7;
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
				return;
			}
			DateTime now = DateAndTime.Now;
			DateTime now2 = DateAndTime.Now;
			DC_Main.R = 0;
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				now = Conversions.ToDate(mFromDt.Text).AddDays(0.0 - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CR_DAYS"])));
				now2 = Conversions.ToDate(mToDt.Text).AddDays(0.0 - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CR_DAYS"])));
				if ((DateTime.Compare(Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy")), now) >= 0) & (DateTime.Compare(Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy")), now2) <= 0))
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(A.REC_AMT+KASAR_AMT) As AdjAmt FROM BILL_OS_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.BILL_YRCD = '"), DC_Main.Tbl.Rows[DC_Main.X]["CO_YEAR"]), (object)"' AND A.BILL_DBCD = '"), DC_Main.Tbl.Rows[DC_Main.X]["CO_BOOK"]), (object)"' AND A.BILL_NO = '"), DC_Main.Tbl.Rows[DC_Main.X]["VCH_NO"]), (object)"' AND B.MAIN_BOOK <> 'SALES'  HAVING SUM(A.REC_AMT) > 0 "));
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable.Rows.Count > 0)
					{
						object obj = DC_Main.Tbl.Rows[DC_Main.X]["NET_AMT"];
						object Value = Operators.ConcatenateObject(dataTable.Rows[0]["AdjAmt"], (object)"");
						if (Operators.ConditionalCompareObjectGreater(obj, (object)DC_Main.Fnv(ref Value), false))
						{
							object obj2 = DC_Main.Tbl.Rows[DC_Main.X]["BILL_OS"];
							Value = Operators.ConcatenateObject(dataTable.Rows[0]["AdjAmt"], (object)"");
							if (Operators.ConditionalCompareObjectGreater(Operators.SubtractObject(obj2, (object)DC_Main.Fnv(ref Value)), (object)0, false))
							{
								((DataGridView)dGV).Rows.Add();
								((DataGridView)dGV)[1, DC_Main.R].Value = DC_Main.R + 1;
								((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_NAME"]);
								((DataGridView)dGV)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["PARTY_MOBILE"]);
								((DataGridView)dGV)[4, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
								((DataGridView)dGV)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["BOOK_SNAME"]);
								((DataGridView)dGV)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CO_BOOK"]);
								((DataGridView)dGV)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_NO"]);
								((DataGridView)dGV)[8, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["NET_AMT"]);
								DataGridViewCell obj3 = ((DataGridView)dGV)[9, DC_Main.R];
								object obj4 = DC_Main.Tbl.Rows[DC_Main.X]["BILL_OS"];
								Value = Operators.ConcatenateObject(dataTable.Rows[0]["AdjAmt"], (object)"");
								obj3.Value = Operators.SubtractObject(obj4, (object)DC_Main.Fnv(ref Value));
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND AC_CODE = '"), DC_Main.Tbl.Rows[DC_Main.X]["AC_CODE"]), (object)"' and VCH_DATE < '"), (object)Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING SUM(CR_AMT-DR_AMT) <> 0 "));
								DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								if (DC_Main.Rshlp.Rows.Count > 0)
								{
									((DataGridView)dGV)[10, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00");
								}
								DC_Main.R++;
							}
						}
					}
					else
					{
						((DataGridView)dGV).Rows.Add();
						((DataGridView)dGV)[1, DC_Main.R].Value = DC_Main.R + 1;
						((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_NAME"]);
						((DataGridView)dGV)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["PARTY_MOBILE"]);
						((DataGridView)dGV)[4, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
						((DataGridView)dGV)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["BOOK_SNAME"]);
						((DataGridView)dGV)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CO_BOOK"]);
						((DataGridView)dGV)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_NO"]);
						((DataGridView)dGV)[8, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["NET_AMT"]);
						((DataGridView)dGV)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["BILL_OS"]);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND AC_CODE = '"), DC_Main.Tbl.Rows[DC_Main.X]["AC_CODE"]), (object)"' and VCH_DATE < '"), (object)Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING SUM(CR_AMT-DR_AMT) <> 0 "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							((DataGridView)dGV)[10, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00");
						}
						DC_Main.R++;
					}
				}
				DC_Main.X++;
			}
			dGV = null;
		}
	}

	private void BtnWhSales_Click(object sender, EventArgs e)
	{
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected O, but got Unknown
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected O, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e9: Expected O, but got Unknown
		//IL_0719: Unknown result type (might be due to invalid IL or missing references)
		((Control)chkKrOrdRec).Visible = false;
		LastOpenMenu = "W";
		RptShow = "W";
		RptTitel = "'Whsales Reminder Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		lblBook.Text = "Whsales Reminder";
		DC_Main.ExeQuteDc("UPDATE RATE_CUT_DATA SET CR_DAYS = 0 WHERE CR_DAYS IS NULL");
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.BOOK_SNAME FROM RATE_CUT_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE ='" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CR_DAYS <> 0 AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text).AddDays(-60.0), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(60.0), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" ORDER BY A.AC_NAME,A.VCH_NO "));
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		DataGridViewX dGV = DGV;
		((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)dGV).AutoGenerateColumns = false;
		DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
		((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
		((DataGridView)dGV).Columns[0].Visible = false;
		((DataGridViewColumn)val).Name = "Ok";
		((DataGridView)dGV).Columns.Add("", "SrNo");
		checked
		{
			((DataGridView)dGV).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "AcName");
			((DataGridView)dGV).Columns[2].Width = (int)Math.Round(240.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "VchDate");
			((DataGridView)dGV).Columns[3].Width = (int)Math.Round(95.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "VchType");
			((DataGridView)dGV).Columns[4].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Book");
			((DataGridView)dGV).Columns[5].Visible = false;
			((DataGridView)dGV).Columns.Add("", "VchNo");
			((DataGridView)dGV).Columns[6].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Type");
			((DataGridView)dGV).Columns[7].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "IsuFine");
			((DataGridView)dGV).Columns[8].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)dGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[8].DefaultCellStyle.Format = "N3";
			((DataGridView)dGV).Columns.Add("", "RecFine");
			((DataGridView)dGV).Columns[9].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)dGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)dGV).Columns.Add("", "TotAmt");
			((DataGridView)dGV).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)dGV).Columns.Add("", "OsAmt");
			((DataGridView)dGV).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[11].DefaultCellStyle.Format = "N2";
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[12].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[13].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			BookCol = 5;
			VchCol = 6;
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
				return;
			}
			DateTime now = DateAndTime.Now;
			DateTime now2 = DateAndTime.Now;
			DC_Main.R = 0;
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				now = Conversions.ToDate(mFromDt.Text).AddDays(0.0 - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CR_DAYS"])));
				now2 = Conversions.ToDate(mToDt.Text).AddDays(0.0 - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CR_DAYS"])));
				if ((DateTime.Compare(Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy")), now) >= 0) & (DateTime.Compare(Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy")), now2) <= 0))
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[1, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_NAME"]);
					((DataGridView)dGV)[3, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
					((DataGridView)dGV)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["BOOK_SNAME"]);
					((DataGridView)dGV)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CO_BOOK"]);
					((DataGridView)dGV)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_NO"]);
					if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[DC_Main.X]["IT_TYPE"], (object)"G", false))
					{
						((DataGridView)dGV)[7, DC_Main.R].Value = "Gold";
					}
					else
					{
						((DataGridView)dGV)[7, DC_Main.R].Value = "Silver";
					}
					((DataGridView)dGV)[8, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["TOT_FINE_DR"]);
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, DC_Main.R].Value)) == 0.0)
					{
						((DataGridView)dGV)[8, DC_Main.R].Value = "";
					}
					((DataGridView)dGV)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["TOT_FINE_CR"]);
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, DC_Main.R].Value)) == 0.0)
					{
						((DataGridView)dGV)[9, DC_Main.R].Value = "";
					}
					((DataGridView)dGV)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["SL_NET_AMT"]);
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, DC_Main.R].Value)) == 0.0)
					{
						((DataGridView)dGV)[10, DC_Main.R].Value = "";
					}
					((DataGridView)dGV)[11, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["SL_BILL_OS"]);
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, DC_Main.R].Value)) == 0.0)
					{
						((DataGridView)dGV)[11, DC_Main.R].Value = "";
					}
					DC_Main.R++;
				}
				DC_Main.X++;
			}
			dGV = null;
		}
	}

	private void BtnDhrn_Click(object sender, EventArgs e)
	{
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_0377: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected O, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected O, but got Unknown
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Expected O, but got Unknown
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_073a: Expected O, but got Unknown
		//IL_09ea: Unknown result type (might be due to invalid IL or missing references)
		((Control)chkKrOrdRec).Visible = false;
		LastOpenMenu = "D";
		RptTitel = "'Dhiran Reminder Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		lblBook.Text = "Dharan Reminder";
		DC_Main.RsQry = "SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.AC_CODE,A.AC_NAME,A.VCH_NO,A.VCH_DATE,A.DHRN_AMT,SUM(B.DHRN_REC_AMT) As DhrnRec,(A.DHRN_AMT - SUM(B.DHRN_REC_AMT)) As PanDhrn,A.INT_PRC,E.AC_MOBILE, (SELECT TOP 1 C.TO_DATE FROM DHRN_DATA AS C WHERE C.CO_CODE = A.CO_CODE AND C.LC_CODE = A.LC_CODE AND  C.ISU_YRCD = A.CO_YEAR  AND  C.ISU_DBCD = A.CO_BOOK AND  C.ISU_NO = A.VCH_NO ORDER BY C.TO_DATE DESC) As FromDt, DATEDIFF(DAY,(SELECT TOP 1 D.TO_DATE FROM DHRN_DATA AS D WHERE D.CO_CODE = A.CO_CODE AND D.LC_CODE = A.LC_CODE AND  D.ISU_YRCD = A.CO_YEAR  AND  D.ISU_DBCD = A.CO_BOOK AND  D.ISU_NO = A.VCH_NO ORDER BY D.TO_DATE DESC),'" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "') AS IntDays,A.DHRN_DUE_DATE FROM ((DHRN_ISU_DATA AS A LEFT JOIN DHRN_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.ISU_YRCD AND A.CO_BOOK = B.ISU_DBCD AND A.VCH_NO = B.ISU_NO)LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE) LEFT JOIN BOOK_DATA AS F ON A.CO_CODE = F.CO_CODE AND A.LC_CODE = F.LC_CODE AND A.CO_BOOK = F.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.DHRN_DUE_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.DHRN_DUE_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND A.DHRN_DUE_DATE IS NOT NULL GROUP BY A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.AC_CODE,A.AC_NAME,A.VCH_NO,A.VCH_DATE,A.DHRN_AMT,A.INT_PRC,E.AC_MOBILE,A.DHRN_DUE_DATE ORDER BY A.AC_NAME,A.DHRN_DUE_DATE ";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.AC_CODE,A.AC_NAME,A.VCH_NO,A.VCH_DATE,A.DHRN_AMT,SUM(B.DHRN_REC_AMT) As DhrnRec,(A.DHRN_AMT - SUM(B.DHRN_REC_AMT)) As PanDhrn,A.INT_PRC,E.AC_MOBILE, (SELECT TOP 1 C.TO_DATE FROM DHRN_DATA AS C WHERE C.CO_CODE = A.CO_CODE AND C.LC_CODE = A.LC_CODE AND  C.ISU_YRCD = A.CO_YEAR  AND  C.ISU_DBCD = A.CO_BOOK AND  C.ISU_NO = A.VCH_NO ORDER BY C.TO_DATE DESC) As FromDt, DATEDIFF(DAY,(SELECT TOP 1 D.TO_DATE FROM DHRN_DATA AS D WHERE D.CO_CODE = A.CO_CODE AND D.LC_CODE = A.LC_CODE AND  D.ISU_YRCD = A.CO_YEAR  AND  D.ISU_DBCD = A.CO_BOOK AND  D.ISU_NO = A.VCH_NO ORDER BY D.TO_DATE DESC),'" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "') AS IntDays FROM ((DHRN_ISU_DATA AS A LEFT JOIN DHRN_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.ISU_YRCD AND A.CO_BOOK = B.ISU_DBCD AND A.VCH_NO = B.ISU_NO)LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE) LEFT JOIN BOOK_DATA AS F ON A.CO_CODE = F.CO_CODE AND A.LC_CODE = F.LC_CODE AND A.CO_BOOK = F.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND F.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.ENTRY_TYPE = 'D' AND DAY(A.VCH_DATE) >="), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd")), (object)" AND DAY(A.VCH_DATE) <="), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd")), (object)" GROUP BY A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.AC_CODE,A.AC_NAME,A.VCH_NO,A.VCH_DATE,A.DHRN_AMT,A.INT_PRC,E.AC_MOBILE  HAVING(A.DHRN_AMT - SUM(B.DHRN_REC_AMT)) > 0 ORDER BY A.AC_NAME,A.VCH_DATE "));
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		DataGridViewX dGV = DGV;
		((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)dGV).AutoGenerateColumns = false;
		DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
		((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
		((DataGridView)dGV).Columns[0].Visible = false;
		((DataGridViewColumn)val).Name = "Ok";
		((DataGridView)dGV).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)dGV).Columns[1].Width = (int)Math.Round(45.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "AcName");
			((DataGridView)dGV).Columns[2].Width = (int)Math.Round(210.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "VchDate");
			((DataGridView)dGV).Columns[3].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "FromDt");
			((DataGridView)dGV).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "DueDate");
			((DataGridView)dGV).Columns[5].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "IntDay");
			((DataGridView)dGV).Columns[6].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Book");
			((DataGridView)dGV).Columns[7].Visible = false;
			((DataGridView)dGV).Columns.Add("", "VchNo");
			((DataGridView)dGV).Columns[8].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "MobileNo");
			((DataGridView)dGV).Columns[9].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "DhrAmt");
			((DataGridView)dGV).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)dGV).Columns.Add("", "PanDhrn");
			((DataGridView)dGV).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[11].DefaultCellStyle.Format = "N2";
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[12].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[13].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			BookCol = 7;
			VchCol = 8;
			DateTime now = DateAndTime.Now;
			DateTime now2 = DateAndTime.Now;
			bool flag = false;
			int num = dataTable.Rows.Count - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				((DataGridView)dGV).Rows.Add();
				((DataGridView)dGV)[1, DC_Main.X].Value = DC_Main.X + 1;
				((DataGridView)dGV)[2, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.X]["AC_NAME"]);
				((DataGridView)dGV)[3, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
				((DataGridView)dGV)[4, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.X]["FromDt"]), "dd/MM/yyyy");
				((DataGridView)dGV)[5, DC_Main.X].Value = Operators.ConcatenateObject(dataTable.Rows[DC_Main.X]["DHRN_DUE_DATE"], (object)"");
				((DataGridView)dGV)[6, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.X]["IntDays"]);
				((DataGridView)dGV)[7, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.X]["CO_BOOK"]);
				((DataGridView)dGV)[8, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.X]["VCH_NO"]);
				((DataGridView)dGV)[9, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.X]["AC_MOBILE"]);
				((DataGridView)dGV)[10, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.X]["DHRN_AMT"]);
				((DataGridView)dGV)[11, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.X]["PanDhrn"]);
				flag = true;
				DC_Main.X++;
			}
			if (!flag && DC_Main.Tbl.Rows.Count == 0)
			{
				Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
				return;
			}
			int num2 = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num2)
			{
				((DataGridView)dGV).Rows.Add();
				((DataGridView)dGV)[1, DC_Main.X].Value = DC_Main.X + 1;
				((DataGridView)dGV)[2, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_NAME"]);
				((DataGridView)dGV)[3, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
				((DataGridView)dGV)[4, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["FromDt"]), "dd/MM/yyyy");
				((DataGridView)dGV)[5, DC_Main.X].Value = "";
				((DataGridView)dGV)[6, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["IntDays"]);
				((DataGridView)dGV)[7, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CO_BOOK"]);
				((DataGridView)dGV)[8, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_NO"]);
				((DataGridView)dGV)[9, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_MOBILE"]);
				((DataGridView)dGV)[10, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["DHRN_AMT"]);
				((DataGridView)dGV)[11, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["PanDhrn"]);
				DC_Main.X++;
			}
			dGV = null;
		}
	}

	private void BtnBirthday_Click(object sender, EventArgs e)
	{
		//IL_07f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Expected O, but got Unknown
		//IL_0833: Unknown result type (might be due to invalid IL or missing references)
		//IL_0838: Unknown result type (might be due to invalid IL or missing references)
		//IL_0842: Expected O, but got Unknown
		//IL_085b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0860: Unknown result type (might be due to invalid IL or missing references)
		//IL_086a: Expected O, but got Unknown
		//IL_0883: Unknown result type (might be due to invalid IL or missing references)
		//IL_0888: Unknown result type (might be due to invalid IL or missing references)
		//IL_0892: Expected O, but got Unknown
		//IL_08bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c4: Expected O, but got Unknown
		//IL_0c5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c64: Expected O, but got Unknown
		//IL_0ca0: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		DataGridViewX val = default(DataGridViewX);
		DataGridViewCheckBoxColumn val2 = default(DataGridViewCheckBoxColumn);
		int num5 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					DateTime now;
					DateTime now2;
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						((Control)chkKrOrdRec).Visible = false;
						goto IL_0011;
					case 4153:
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
								goto IL_0011;
							case 3:
								goto IL_001e;
							case 4:
								goto IL_008d;
							case 5:
								goto IL_00a0;
							case 6:
								goto IL_00a9;
							case 7:
								goto IL_00c5;
							case 8:
								goto IL_03f6;
							case 10:
								goto IL_040e;
							case 11:
								goto IL_0776;
							case 9:
							case 12:
							case 13:
								goto IL_0789;
							case 14:
								goto IL_0799;
							case 15:
								goto IL_07ad;
							case 16:
								goto IL_07c1;
							case 17:
								goto IL_07d1;
							case 18:
								goto IL_07dc;
							case 19:
								goto IL_07fc;
							case 20:
								goto IL_081b;
							case 21:
								goto IL_0843;
							case 22:
								goto IL_086b;
							case 23:
								goto IL_0893;
							case 24:
							case 25:
								goto IL_08ae;
							case 26:
								goto IL_08ba;
							case 27:
								goto IL_08c4;
							case 28:
								goto IL_08d6;
							case 29:
								goto IL_08ed;
							case 30:
								goto IL_08fd;
							case 31:
								goto IL_0917;
							case 32:
								goto IL_0943;
							case 33:
								goto IL_095d;
							case 34:
								goto IL_0989;
							case 35:
								goto IL_09a3;
							case 36:
								goto IL_09cf;
							case 37:
								goto IL_09e9;
							case 38:
								goto IL_0a15;
							case 39:
								goto IL_0a2f;
							case 40:
								goto IL_0a5b;
							case 41:
								goto IL_0a75;
							case 42:
								goto IL_0aa1;
							case 43:
								goto IL_0abb;
							case 44:
								goto IL_0ae7;
							case 45:
								goto IL_0b01;
							case 46:
								goto IL_0b2d;
							case 47:
								goto IL_0b47;
							case 48:
								goto IL_0b5f;
							case 49:
								goto IL_0b79;
							case 50:
								goto IL_0b91;
							case 51:
								goto IL_0bab;
							case 52:
								goto IL_0bc3;
							case 53:
								goto IL_0bdd;
							case 54:
								goto IL_0bf5;
							case 55:
								goto IL_0c0f;
							case 56:
								goto IL_0c27;
							case 57:
								goto IL_0c40;
							case 58:
							case 59:
								goto IL_0c67;
							case 60:
								goto IL_0c71;
							case 61:
								goto IL_0c7b;
							case 62:
								goto IL_0c96;
							case 64:
							case 65:
								goto IL_0cad;
							case 66:
								goto IL_0cb7;
							case 67:
								goto IL_0cc1;
							case 68:
								goto IL_0ce2;
							case 69:
								goto IL_0cf2;
							case 70:
								goto IL_0d14;
							case 71:
								goto IL_0d4d;
							case 72:
								goto IL_0d99;
							case 73:
								goto IL_0de5;
							case 74:
								goto IL_0e1e;
							case 75:
								goto IL_0e57;
							case 76:
								goto IL_0e90;
							case 77:
								goto IL_0ec9;
							case 78:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 63:
							case 79:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0ec9:
						num2 = 77;
						DC_Main.X++;
						goto IL_0ed8;
						IL_0e90:
						num2 = 76;
						((DataGridView)val)[8, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["Area"]);
						goto IL_0ec9;
						IL_0d99:
						num2 = 72;
						((DataGridView)val)[4, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AN_DATE"]), "dd/MM/yyyy") ?? "";
						goto IL_0de5;
						IL_0de5:
						num2 = 73;
						((DataGridView)val)[5, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_CITY"]);
						goto IL_0e1e;
						IL_0011:
						num2 = 2;
						LastOpenMenu = "B";
						goto IL_001e;
						IL_001e:
						num2 = 3;
						RptTitel = "'Birthday Reminder Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
						goto IL_008d;
						IL_008d:
						num2 = 4;
						lblBook.Text = "Birthday Reminder";
						goto IL_00a0;
						IL_00a0:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_00a9;
						IL_00a9:
						num2 = 6;
						if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
						{
							goto IL_00c5;
						}
						goto IL_040e;
						IL_00c5:
						num2 = 7;
						DC_Main.RsQry = "SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,FORMAT(BR_DATE, 'dd') AS LHour,'P' As AcType,AC_AREA As Area FROM AC_MAST  AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND ((DAY(BR_DATE) >=  " + Strings.Mid(mFromDt.Text, 1, 2) + "  AND MONTH(BR_DATE) >=  " + Strings.Mid(mFromDt.Text, 4, 2) + "  AND DAY(BR_DATE) <=  " + Strings.Mid(mToDt.Text, 1, 2) + "  AND MONTH(BR_DATE) <=  " + Strings.Mid(mToDt.Text, 4, 2) + ") or (DAY(AN_DATE) >=  " + Strings.Mid(mFromDt.Text, 1, 2) + "  AND MONTH(AN_DATE) >=  " + Strings.Mid(mFromDt.Text, 4, 2) + "  AND DAY(AN_DATE) <=  " + Strings.Mid(mToDt.Text, 1, 2) + "  AND MONTH(AN_DATE) <=  " + Strings.Mid(mToDt.Text, 4, 2) + "))  UNION ALL SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,FORMAT(BR_DATE, 'dd') AS LHour,'A' As AcType,AC_AREA As Area  FROM ADD_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND ((DAY(BR_DATE) >= " + Strings.Mid(mFromDt.Text, 1, 2) + " AND MONTH(BR_DATE) >=  " + Strings.Mid(mFromDt.Text, 4, 2) + " AND DAY(BR_DATE) <=  " + Strings.Mid(mToDt.Text, 1, 2) + "  AND MONTH(BR_DATE) <=  " + Strings.Mid(mToDt.Text, 4, 2) + ") or (DAY(AN_DATE) >=  " + Strings.Mid(mFromDt.Text, 1, 2) + "  AND MONTH(AN_DATE) >=  " + Strings.Mid(mFromDt.Text, 4, 2) + "  AND DAY(AN_DATE) <=  " + Strings.Mid(mToDt.Text, 1, 2) + "  AND MONTH(AN_DATE) <=  " + Strings.Mid(mToDt.Text, 4, 2) + "))  UNION ALL SELECT MEMB_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BIRTH_DATE,ANV_DATE,FORMAT(BIRTH_DATE, 'dd') AS LHour,'S' As AcType,AC_AREA As Area  FROM AD_MEMB  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND ((DAY(BIRTH_DATE) >= " + Strings.Mid(mFromDt.Text, 1, 2) + " AND MONTH(BIRTH_DATE) >=  " + Strings.Mid(mFromDt.Text, 4, 2) + " AND DAY(BIRTH_DATE) <= " + Strings.Mid(mToDt.Text, 1, 2) + " AND MONTH(BIRTH_DATE) <=  " + Strings.Mid(mToDt.Text, 4, 2) + ") or (DAY(ANV_DATE) >=  " + Strings.Mid(mFromDt.Text, 1, 2) + "  AND MONTH(ANV_DATE) >=  " + Strings.Mid(mFromDt.Text, 4, 2) + "  AND DAY(ANV_DATE) <=  " + Strings.Mid(mToDt.Text, 1, 2) + "  AND MONTH(ANV_DATE) <=  " + Strings.Mid(mToDt.Text, 4, 2) + ")) ORDER BY FORMAT(BR_DATE, 'dd'),BR_DATE";
						goto IL_03f6;
						IL_03f6:
						num2 = 8;
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0789;
						IL_040e:
						num2 = 10;
						DC_Main.RsQry = "SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,FORMAT(BR_DATE, 'dd') AS LHour,'P' As AcType,AC_AREA As Area FROM AC_MAST  AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND ((DAY(BR_DATE) >=  " + Strings.Mid(mFromDt.Text, 1, 2) + "  AND MONTH(BR_DATE) >=  " + Strings.Mid(mFromDt.Text, 4, 2) + "  AND DAY(BR_DATE) <=  " + Strings.Mid(mToDt.Text, 1, 2) + "  AND MONTH(BR_DATE) <=  " + Strings.Mid(mToDt.Text, 4, 2) + ") or (DAY(AN_DATE) >=  " + Strings.Mid(mFromDt.Text, 1, 2) + "  AND MONTH(AN_DATE) >=  " + Strings.Mid(mFromDt.Text, 4, 2) + "  AND DAY(AN_DATE) <=  " + Strings.Mid(mToDt.Text, 1, 2) + "  AND MONTH(AN_DATE) <=  " + Strings.Mid(mToDt.Text, 4, 2) + "))  UNION ALL SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,FORMAT(BR_DATE, 'dd') AS LHour,'A' As AcType,AC_AREA As Area  FROM ADD_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND ((DAY(BR_DATE) >= " + Strings.Mid(mFromDt.Text, 1, 2) + " AND MONTH(BR_DATE) >=  " + Strings.Mid(mFromDt.Text, 4, 2) + " AND DAY(BR_DATE) <=  " + Strings.Mid(mToDt.Text, 1, 2) + "  AND MONTH(BR_DATE) <=  " + Strings.Mid(mToDt.Text, 4, 2) + ") or (DAY(AN_DATE) >=  " + Strings.Mid(mFromDt.Text, 1, 2) + "  AND MONTH(AN_DATE) >=  " + Strings.Mid(mFromDt.Text, 4, 2) + "  AND DAY(AN_DATE) <=  " + Strings.Mid(mToDt.Text, 1, 2) + "  AND MONTH(AN_DATE) <=  " + Strings.Mid(mToDt.Text, 4, 2) + "))  UNION ALL SELECT MEMB_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BIRTH_DATE,ANV_DATE,FORMAT(BIRTH_DATE, 'dd') AS LHour,'S' As AcType,AC_AREA As Area  FROM AD_MEMB  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND ((DAY(BIRTH_DATE) >= " + Strings.Mid(mFromDt.Text, 1, 2) + " AND MONTH(BIRTH_DATE) >=  " + Strings.Mid(mFromDt.Text, 4, 2) + " AND DAY(BIRTH_DATE) <= " + Strings.Mid(mToDt.Text, 1, 2) + " AND MONTH(BIRTH_DATE) <=  " + Strings.Mid(mToDt.Text, 4, 2) + ") or (DAY(ANV_DATE) >=  " + Strings.Mid(mFromDt.Text, 1, 2) + "  AND MONTH(ANV_DATE) >=  " + Strings.Mid(mFromDt.Text, 4, 2) + "  AND DAY(ANV_DATE) <=  " + Strings.Mid(mToDt.Text, 1, 2) + "  AND MONTH(ANV_DATE) <=  " + Strings.Mid(mToDt.Text, 4, 2) + ")) ORDER BY FORMAT(BR_DATE, 'dd'),BR_DATE";
						goto IL_0776;
						IL_0776:
						num2 = 11;
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0789;
						IL_0789:
						num2 = 13;
						((DataGridView)DGV).DataSource = null;
						goto IL_0799;
						IL_0799:
						num2 = 14;
						((DataGridView)DGV).Columns.Clear();
						goto IL_07ad;
						IL_07ad:
						num2 = 15;
						((DataGridView)DGV).Rows.Clear();
						goto IL_07c1;
						IL_07c1:
						num2 = 16;
						((Control)DGV).Refresh();
						goto IL_07d1;
						IL_07d1:
						num2 = 17;
						val = DGV;
						goto IL_07dc;
						IL_07dc:
						num2 = 18;
						((DataGridView)val).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
						goto IL_07fc;
						IL_07fc:
						num2 = 19;
						if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
						{
							goto IL_081b;
						}
						goto IL_08ae;
						IL_081b:
						num2 = 20;
						((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_0843;
						IL_0843:
						num2 = 21;
						((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_086b;
						IL_086b:
						num2 = 22;
						((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						goto IL_0893;
						IL_0893:
						num2 = 23;
						((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
						goto IL_08ae;
						IL_08ae:
						num2 = 25;
						((DataGridView)val).AutoGenerateColumns = false;
						goto IL_08ba;
						IL_08ba:
						num2 = 26;
						val2 = new DataGridViewCheckBoxColumn();
						goto IL_08c4;
						IL_08c4:
						num2 = 27;
						((DataGridView)val).Columns.Add((DataGridViewColumn)(object)val2);
						goto IL_08d6;
						IL_08d6:
						num2 = 28;
						((DataGridView)val).Columns[0].Visible = false;
						goto IL_08ed;
						IL_08ed:
						num2 = 29;
						((DataGridViewColumn)val2).Name = "Ok";
						goto IL_08fd;
						IL_08fd:
						num2 = 30;
						((DataGridView)val).Columns.Add("", "SrNo");
						goto IL_0917;
						IL_0917:
						num2 = 31;
						((DataGridView)val).Columns[1].Width = (int)Math.Round(60.0 * ColCon);
						goto IL_0943;
						IL_0943:
						num2 = 32;
						((DataGridView)val).Columns.Add("", "AcName");
						goto IL_095d;
						IL_095d:
						num2 = 33;
						((DataGridView)val).Columns[2].Width = (int)Math.Round(250.0 * ColCon);
						goto IL_0989;
						IL_0989:
						num2 = 34;
						((DataGridView)val).Columns.Add("", "BrDay");
						goto IL_09a3;
						IL_09a3:
						num2 = 35;
						((DataGridView)val).Columns[3].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_09cf;
						IL_09cf:
						num2 = 36;
						((DataGridView)val).Columns.Add("", "AnDay");
						goto IL_09e9;
						IL_09e9:
						num2 = 37;
						((DataGridView)val).Columns[4].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_0a15;
						IL_0a15:
						num2 = 38;
						((DataGridView)val).Columns.Add("", "City");
						goto IL_0a2f;
						IL_0a2f:
						num2 = 39;
						((DataGridView)val).Columns[5].Width = (int)Math.Round(150.0 * ColCon);
						goto IL_0a5b;
						IL_0a5b:
						num2 = 40;
						((DataGridView)val).Columns.Add("", "Add");
						goto IL_0a75;
						IL_0a75:
						num2 = 41;
						((DataGridView)val).Columns[6].Width = (int)Math.Round(180.0 * ColCon);
						goto IL_0aa1;
						IL_0aa1:
						num2 = 42;
						((DataGridView)val).Columns.Add("", "MobileNo");
						goto IL_0abb;
						IL_0abb:
						num2 = 43;
						((DataGridView)val).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
						goto IL_0ae7;
						IL_0ae7:
						num2 = 44;
						((DataGridView)val).Columns.Add("", "Area");
						goto IL_0b01;
						IL_0b01:
						num2 = 45;
						((DataGridView)val).Columns[8].Width = (int)Math.Round(150.0 * ColCon);
						goto IL_0b2d;
						IL_0b2d:
						num2 = 46;
						((DataGridView)val).Columns.Add("", "");
						goto IL_0b47;
						IL_0b47:
						num2 = 47;
						((DataGridView)val).Columns[9].Visible = false;
						goto IL_0b5f;
						IL_0b5f:
						num2 = 48;
						((DataGridView)val).Columns.Add("", "");
						goto IL_0b79;
						IL_0b79:
						num2 = 49;
						((DataGridView)val).Columns[10].Visible = false;
						goto IL_0b91;
						IL_0b91:
						num2 = 50;
						((DataGridView)val).Columns.Add("", "");
						goto IL_0bab;
						IL_0bab:
						num2 = 51;
						((DataGridView)val).Columns[11].Visible = false;
						goto IL_0bc3;
						IL_0bc3:
						num2 = 52;
						((DataGridView)val).Columns.Add("", "");
						goto IL_0bdd;
						IL_0bdd:
						num2 = 53;
						((DataGridView)val).Columns[12].Visible = false;
						goto IL_0bf5;
						IL_0bf5:
						num2 = 54;
						((DataGridView)val).Columns.Add("", "");
						goto IL_0c0f;
						IL_0c0f:
						num2 = 55;
						((DataGridView)val).Columns[13].Visible = false;
						goto IL_0c27;
						IL_0c27:
						num2 = 56;
						if (DC_Main.ScreenHight > 1.0)
						{
							goto IL_0c40;
						}
						goto IL_0c67;
						IL_0c40:
						num2 = 57;
						((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
						goto IL_0c67;
						IL_0c67:
						num2 = 59;
						BookCol = 0;
						goto IL_0c71;
						IL_0c71:
						num2 = 60;
						VchCol = 0;
						goto IL_0c7b;
						IL_0c7b:
						num2 = 61;
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							goto IL_0c96;
						}
						goto IL_0cad;
						IL_0c96:
						num2 = 62;
						Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001_3;
						IL_0cad:
						num2 = 65;
						now = DateAndTime.Now;
						goto IL_0cb7;
						IL_0cb7:
						num2 = 66;
						now2 = DateAndTime.Now;
						goto IL_0cc1;
						IL_0cc1:
						num2 = 67;
						num5 = DC_Main.Tbl.Rows.Count - 1;
						DC_Main.X = 0;
						goto IL_0ed8;
						IL_0ed8:
						if (DC_Main.X > num5)
						{
							break;
						}
						goto IL_0ce2;
						IL_0ce2:
						num2 = 68;
						((DataGridView)val).Rows.Add();
						goto IL_0cf2;
						IL_0cf2:
						num2 = 69;
						((DataGridView)val)[1, DC_Main.X].Value = DC_Main.X + 1;
						goto IL_0d14;
						IL_0d14:
						num2 = 70;
						((DataGridView)val)[2, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_NAME"]);
						goto IL_0d4d;
						IL_0d4d:
						num2 = 71;
						((DataGridView)val)[3, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["BR_DATE"]), "dd/MM/yyyy") ?? "";
						goto IL_0d99;
						IL_0e57:
						num2 = 75;
						((DataGridView)val)[7, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_MOBILE"]);
						goto IL_0e90;
						IL_0e1e:
						num2 = 74;
						((DataGridView)val)[6, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_ADD1"]);
						goto IL_0e57;
						end_IL_0001_2:
						break;
					}
					val = null;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 4153;
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

	private void BtnSchm_Click(object sender, EventArgs e)
	{
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Expected O, but got Unknown
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0600: Unknown result type (might be due to invalid IL or missing references)
		//IL_060a: Expected O, but got Unknown
		//IL_063a: Unknown result type (might be due to invalid IL or missing references)
		((Control)chkKrOrdRec).Visible = false;
		LastOpenMenu = "M";
		RptTitel = "'Scheme Reminder Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + "'";
		lblBook.Text = "Scheme Reminder";
		DC_Main.RsQry = "SELECT B.SCHM_CODE,B.MEMB_CODE,A.MEMB_AMT AS MembAmt,A.MEMB_NAME,A.JOIN_DATE,A.AC_MOBILE FROM AD_MEMB AS A INNER JOIN AD_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.SCHM_CODE = B.SCHM_CODE AND A.MEMB_CODE = B.MEMB_CODE WHERE a.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND DAY(A.JOIN_DATE) >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + "' AND DAY(A.JOIN_DATE) <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + "' AND A.EXP_DATE >= '" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "' GROUP BY  B.SCHM_CODE,B.MEMB_CODE,A.MEMB_AMT,A.MEMB_NAME,A.JOIN_DATE,A.AC_MOBILE ORDER BY B.SCHM_CODE,B.MEMB_CODE ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		DataGridViewX dGV = DGV;
		((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)dGV).AutoGenerateColumns = false;
		DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
		((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
		((DataGridView)dGV).Columns[0].Visible = false;
		((DataGridViewColumn)val).Name = "Ok";
		((DataGridView)dGV).Columns.Add("", "SrNo");
		checked
		{
			((DataGridView)dGV).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Schm");
			((DataGridView)dGV).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Memb");
			((DataGridView)dGV).Columns[3].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "MembName");
			((DataGridView)dGV).Columns[4].Width = (int)Math.Round(275.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "JoinDate");
			((DataGridView)dGV).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "LastRecDt");
			((DataGridView)dGV).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "MobileNo");
			((DataGridView)dGV).Columns[7].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "MembAmt");
			((DataGridView)dGV).Columns[8].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)dGV).Columns.Add("", "OsDay");
			((DataGridView)dGV).Columns[9].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)dGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)dGV).Columns[9].DefaultCellStyle.Format = "N0";
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[10].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[11].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[12].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[13].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			BookCol = 0;
			VchCol = 0;
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
				return;
			}
			DateTime now = DateAndTime.Now;
			DateTime now2 = DateAndTime.Now;
			DC_Main.X = 0;
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.MEMB_AMT,B.JOIN_DATE,A.SCHM_DATE,B.EXP_DATE FROM AD_DATA AS A LEFT JOIN AD_MEMB AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.SCHM_CODE = B.SCHM_CODE AND A.MEMB_CODE = B.MEMB_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.SCHM_CODE = '"), DC_Main.Tbl.Rows[DC_Main.X]["SCHM_CODE"]), (object)"' AND A.MEMB_CODE = '"), DC_Main.Tbl.Rows[DC_Main.X]["MEMB_CODE"]), (object)"' AND MONTH(SCHM_DATE) = '"), (object)Strings.Format((object)Conversions.ToDate(DC_Main.Tbl.Rows[DC_Main.X]["JOIN_DATE"]), "MM")), (object)"' AND B.EXP_DATE >= '"), (object)Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")), (object)"'  ORDER BY A.SCHM_DATE DESC "));
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count >= 0)
				{
					if (Operators.CompareString(DC_Main.SSRegSrNo, "HM244NEKU", false) == 0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SCHM_CODE,MEMB_CODE,SUM(CASE WHEN SIGN = '+' THEN ADJ_AMT ELSE -ADJ_AMT END) As Bal FROM AD_OS AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.MEMB_CODE = '"), DC_Main.Tbl.Rows[DC_Main.X]["MEMB_CODE"]), (object)"' AND A.SCHM_CODE = '"), DC_Main.Tbl.Rows[DC_Main.X]["SCHM_CODE"]), (object)"' GROUP BY SCHM_CODE,MEMB_CODE HAVING SUM(CASE WHEN SIGN = '+' THEN ADJ_AMT ELSE -ADJ_AMT END) > 0 "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							((DataGridView)dGV).Rows.Add();
							((DataGridView)dGV)[1, DC_Main.X].Value = DC_Main.X + 1;
							((DataGridView)dGV)[2, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["SCHM_CODE"]);
							((DataGridView)dGV)[3, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["MEMB_CODE"]);
							((DataGridView)dGV)[4, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["MEMB_NAME"]);
							((DataGridView)dGV)[5, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["JOIN_DATE"]), "dd/MM/yyyy") ?? "";
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT top 1 A.SCHM_DATE FROM AD_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.SCHM_CODE = '"), DC_Main.Tbl.Rows[DC_Main.X]["SCHM_CODE"]), (object)"' AND A.MEMB_CODE = '"), DC_Main.Tbl.Rows[DC_Main.X]["MEMB_CODE"]), (object)"'  ORDER BY A.SCHM_DATE DESC "));
							dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable.Rows.Count > 0)
							{
								((DataGridView)dGV)[6, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SCHM_DATE"]), "dd/MM/yyyy") ?? "";
							}
							((DataGridView)dGV)[7, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_MOBILE"]);
							((DataGridView)dGV)[8, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["MembAmt"]);
							if (dataTable.Rows.Count > 0)
							{
								string text = Strings.Mid(Conversions.ToString(((DataGridView)dGV)[5, DC_Main.X].Value), 1, 2);
								string text2 = Strings.Format((object)DC_Main.MsSysDate, "dd");
								string text3 = Strings.Format((object)Conversion.Val(Strings.Mid(Conversions.ToString(dataTable.Rows[0]["SCHM_DATE"]), 1, 2)), "00");
								string text4 = Strings.Format((object)Conversion.Val(Strings.Mid(Conversions.ToString(dataTable.Rows[0]["SCHM_DATE"]), 4, 2)), "00");
								string text5 = Strings.Format((object)DC_Main.MsSysDate, "MM");
								double num2 = DateAndTime.DateDiff((DateInterval)4, DC_Main.MsSysDate, Conversions.ToDate(dataTable.Rows[0]["SCHM_DATE"]), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
								if (num2 + 31.0 < 0.0)
								{
									if (num2 < -30.0)
									{
										if (Conversions.ToDouble(text4) - (Conversions.ToDouble(text5) - 1.0) == 0.0)
										{
											((DataGridView)dGV)[9, DC_Main.X].Value = Conversions.ToDouble(text) - Conversions.ToDouble(text2);
											((DataGridView)dGV).Rows[DC_Main.X].Cells[9].Style.ForeColor = Color.Red;
										}
										else if (Conversions.ToDouble(text4) - Conversions.ToDouble(text5) == 0.0)
										{
											((DataGridView)dGV)[9, DC_Main.X].Value = Conversions.ToDouble(text) - Conversions.ToDouble(text2);
											((DataGridView)dGV).Rows[DC_Main.X].Cells[9].Style.ForeColor = Color.Red;
										}
										else
										{
											((DataGridView)dGV)[9, DC_Main.X].Value = num2;
											((DataGridView)dGV).Rows[DC_Main.X].Cells[9].Style.ForeColor = Color.Red;
										}
									}
									else
									{
										((DataGridView)dGV)[9, DC_Main.X].Value = num2 + 30.0;
										((DataGridView)dGV).Rows[DC_Main.X].Cells[9].Style.ForeColor = Color.Red;
									}
								}
								else if (Conversions.ToDouble(text4) - Conversions.ToDouble(text5) == 0.0)
								{
									if (Operators.CompareString(text3, text, false) < 0)
									{
										((DataGridView)dGV)[9, DC_Main.X].Value = Conversions.ToDouble(text) - Conversions.ToDouble(text3);
										((DataGridView)dGV).Rows[DC_Main.X].Cells[9].Style.ForeColor = Color.Green;
									}
									else
									{
										((DataGridView)dGV)[9, DC_Main.X].Value = Conversions.ToDouble(text) - Conversions.ToDouble(text2);
										((DataGridView)dGV).Rows[DC_Main.X].Cells[9].Style.ForeColor = Color.Red;
									}
								}
								else
								{
									((DataGridView)dGV)[9, DC_Main.X].Value = Conversions.ToDouble(text) - Conversions.ToDouble(text2);
									((DataGridView)dGV).Rows[DC_Main.X].Cells[9].Style.ForeColor = Color.Red;
								}
							}
						}
					}
					else
					{
						((DataGridView)dGV).Rows.Add();
						((DataGridView)dGV)[1, DC_Main.X].Value = DC_Main.X + 1;
						((DataGridView)dGV)[2, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["SCHM_CODE"]);
						((DataGridView)dGV)[3, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["MEMB_CODE"]);
						((DataGridView)dGV)[4, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["MEMB_NAME"]);
						((DataGridView)dGV)[5, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["JOIN_DATE"]), "dd/MM/yyyy") ?? "";
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT top 1 A.SCHM_DATE FROM AD_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.SCHM_CODE = '"), DC_Main.Tbl.Rows[DC_Main.X]["SCHM_CODE"]), (object)"' AND A.MEMB_CODE = '"), DC_Main.Tbl.Rows[DC_Main.X]["MEMB_CODE"]), (object)"'  ORDER BY A.SCHM_DATE DESC "));
						dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (dataTable.Rows.Count > 0)
						{
							((DataGridView)dGV)[6, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["SCHM_DATE"]), "dd/MM/yyyy") ?? "";
						}
						((DataGridView)dGV)[7, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_MOBILE"]);
						((DataGridView)dGV)[8, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["MembAmt"]);
						if (dataTable.Rows.Count > 0)
						{
							string text6 = Strings.Mid(Conversions.ToString(((DataGridView)dGV)[5, DC_Main.X].Value), 1, 2);
							string text7 = Strings.Format((object)DC_Main.MsSysDate, "dd");
							string text8 = Strings.Format((object)Conversion.Val(Strings.Mid(Conversions.ToString(dataTable.Rows[0]["SCHM_DATE"]), 1, 2)), "00");
							string text9 = Strings.Format((object)Conversion.Val(Strings.Mid(Conversions.ToString(dataTable.Rows[0]["SCHM_DATE"]), 4, 2)), "00");
							string text10 = Strings.Format((object)DC_Main.MsSysDate, "MM");
							double num3 = DateAndTime.DateDiff((DateInterval)4, DC_Main.MsSysDate, Conversions.ToDate(dataTable.Rows[0]["SCHM_DATE"]), (FirstDayOfWeek)1, (FirstWeekOfYear)1);
							if (num3 + 31.0 < 0.0)
							{
								if (num3 < -30.0)
								{
									if (Conversions.ToDouble(text9) - (Conversions.ToDouble(text10) - 1.0) == 0.0)
									{
										((DataGridView)dGV)[9, DC_Main.X].Value = Conversions.ToDouble(text6) - Conversions.ToDouble(text7);
										((DataGridView)dGV).Rows[DC_Main.X].Cells[9].Style.ForeColor = Color.Red;
									}
									else if (Conversions.ToDouble(text9) - Conversions.ToDouble(text10) == 0.0)
									{
										((DataGridView)dGV)[9, DC_Main.X].Value = Conversions.ToDouble(text6) - Conversions.ToDouble(text7);
										((DataGridView)dGV).Rows[DC_Main.X].Cells[9].Style.ForeColor = Color.Red;
									}
									else
									{
										((DataGridView)dGV)[9, DC_Main.X].Value = num3;
										((DataGridView)dGV).Rows[DC_Main.X].Cells[9].Style.ForeColor = Color.Red;
									}
								}
								else
								{
									((DataGridView)dGV)[9, DC_Main.X].Value = num3 + 30.0;
									((DataGridView)dGV).Rows[DC_Main.X].Cells[9].Style.ForeColor = Color.Red;
								}
							}
							else if (Conversions.ToDouble(text9) - Conversions.ToDouble(text10) == 0.0)
							{
								if (Operators.CompareString(text8, text6, false) < 0)
								{
									((DataGridView)dGV)[9, DC_Main.X].Value = Conversions.ToDouble(text6) - Conversions.ToDouble(text8);
									((DataGridView)dGV).Rows[DC_Main.X].Cells[9].Style.ForeColor = Color.Green;
								}
								else
								{
									((DataGridView)dGV)[9, DC_Main.X].Value = Conversions.ToDouble(text6) - Conversions.ToDouble(text7);
									((DataGridView)dGV).Rows[DC_Main.X].Cells[9].Style.ForeColor = Color.Red;
								}
							}
							else
							{
								((DataGridView)dGV)[9, DC_Main.X].Value = Conversions.ToDouble(text6) - Conversions.ToDouble(text7);
								((DataGridView)dGV).Rows[DC_Main.X].Cells[9].Style.ForeColor = Color.Red;
							}
						}
					}
				}
				DC_Main.X++;
			}
			dGV = null;
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
		DC_Main.ExeQuteDc("DELETE FROM REPORT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		DataGridViewX dGV = DGV;
		DC_Main.RsQry = "INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,COL_1,COL_2,COL_3,COL_4,COL_5,COL_6,COL_7,  COL_8,COL_9,COL_10,COL_11,COL_12,COL_13)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','0','" + ((DataGridView)dGV).Columns[1].HeaderText + "','" + ((DataGridView)dGV).Columns[2].HeaderText + "','" + ((DataGridView)dGV).Columns[3].HeaderText + "','" + ((DataGridView)dGV).Columns[4].HeaderText + "','" + ((DataGridView)dGV).Columns[5].HeaderText + "','" + ((DataGridView)dGV).Columns[6].HeaderText + "','" + ((DataGridView)dGV).Columns[7].HeaderText + "',  '" + ((DataGridView)dGV).Columns[8].HeaderText + "','" + ((DataGridView)dGV).Columns[9].HeaderText + "','" + ((DataGridView)dGV).Columns[10].HeaderText + "','" + ((DataGridView)dGV).Columns[11].HeaderText + "','" + ((DataGridView)dGV).Columns[12].HeaderText + "','" + ((DataGridView)dGV).Columns[13].HeaderText + "')";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		checked
		{
			int num = ((DataGridView)dGV).RowCount - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO REPORT_DATA(CO_CODE,LC_CODE,SR_NO,COL_1,COL_2,COL_3,COL_4,COL_5,COL_6,COL_7,  COL_8,COL_9,COL_10,COL_11,COL_12,COL_13)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), ((DataGridView)dGV)[0, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[1, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[2, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[3, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[4, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[5, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[6, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[7, DC_Main.X].Value), (object)"', "), (object)" '"), ((DataGridView)dGV)[8, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[9, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[10, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[11, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[12, DC_Main.X].Value), (object)"','"), ((DataGridView)dGV)[13, DC_Main.X].Value), (object)"')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.X++;
			}
			dGV = null;
			DC_Main.RsQry = "SELECT * FROM REPORT_DATA";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (Operators.CompareString(LastOpenMenu, "M", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ReminderSchm.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ReminderAll.RPT";
			}
			Cr.SelectionFormula = "{REPORT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {REPORT_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' ";
			Cr[(short)0] = ("RptTitel = " + RptTitel) ?? "";
			Cr[(short)1] = "RptShow = '" + RptShow + "'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.PageZoom((short)DC_Main.MsPrintZoom);
			Cr.Action = -1;
		}
	}

	private void RP_REMINDER_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void btnItmInOut_Click(object sender, EventArgs e)
	{
		((Control)chkKrOrdRec).Visible = false;
		DC_Main.MsUserRightForm = "Item InOut";
		RP_ALL rP_ALL = new RP_ALL();
		((Form)rP_ALL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
		((Form)rP_ALL).Text = "Item InOut";
		((Control)rP_ALL).Show();
		((Control)rP_ALL).Focus();
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
		ColorConverter colorConverter = default(ColorConverter);
		int num10 = default(int);
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
					case 1540:
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
								goto IL_0168;
							case 14:
								goto IL_0177;
							case 15:
								goto IL_017d;
							case 16:
								goto IL_019a;
							case 17:
								goto IL_01d4;
							case 18:
								goto IL_01dd;
							case 19:
								goto IL_01f4;
							case 20:
								goto IL_0217;
							case 21:
							case 22:
								goto IL_0269;
							case 23:
							case 24:
								goto IL_027d;
							case 25:
								goto IL_0298;
							case 26:
								goto IL_02a2;
							case 27:
								goto IL_02f5;
							case 28:
								goto IL_034a;
							case 29:
								goto IL_03a2;
							case 30:
								goto IL_0410;
							case 31:
								goto IL_0453;
							case 32:
								goto IL_0482;
							case 33:
								goto IL_04c5;
							case 34:
								goto IL_0506;
							case 35:
								goto IL_0527;
							case 36:
								goto IL_0535;
							case 37:
								goto IL_053b;
							case 38:
								goto IL_0541;
							case 39:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 40:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_027d:
						num2 = 24;
						DC_Main.i++;
						goto IL_028c;
						IL_0120:
						num2 = 12;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num5 + 1,
							((DataGridView)DGV).Columns[num5].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_0168;
						IL_0269:
						num2 = 22;
						num6++;
						goto IL_0272;
						IL_0168:
						num2 = 13;
						num5++;
						goto IL_0171;
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
						num7 = ((DataGridView)DGV).ColumnCount - 1;
						num5 = 0;
						goto IL_0171;
						IL_0171:
						if (num5 <= num7)
						{
							goto IL_0120;
						}
						goto IL_0177;
						IL_0177:
						num2 = 14;
						num8 = 0;
						goto IL_017d;
						IL_017d:
						num2 = 15;
						num9 = ((DataGridView)DGV).RowCount - 1;
						DC_Main.i = 0;
						goto IL_028c;
						IL_028c:
						if (DC_Main.i <= num9)
						{
							goto IL_019a;
						}
						goto IL_0298;
						IL_0298:
						num2 = 25;
						colorConverter = new ColorConverter();
						goto IL_02a2;
						IL_02a2:
						num2 = 26;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_02f5;
						IL_02f5:
						num2 = 27;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_034a;
						IL_034a:
						num2 = 28;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_03a2;
						IL_03a2:
						num2 = 29;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_0410;
						IL_0410:
						num2 = 30;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0453;
						IL_0453:
						num2 = 31;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0482;
						IL_0482:
						num2 = 32;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_04c5;
						IL_04c5:
						num2 = 33;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0506;
						IL_0506:
						num2 = 34;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_0527;
						IL_0527:
						num2 = 35;
						Cursor.Current = Cursors.Default;
						goto IL_0535;
						IL_0535:
						num2 = 36;
						obj = null;
						goto IL_053b;
						IL_053b:
						num2 = 37;
						obj3 = null;
						goto IL_0541;
						IL_0541:
						num2 = 38;
						obj2 = null;
						break;
						IL_019a:
						num2 = 16;
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[1, DC_Main.i].Value)) != 0.0)
						{
							goto IL_01d4;
						}
						goto IL_027d;
						IL_01d4:
						num2 = 17;
						num8++;
						goto IL_01dd;
						IL_01dd:
						num2 = 18;
						num10 = ((DataGridView)DGV).ColumnCount - 1;
						num6 = 0;
						goto IL_0272;
						IL_0272:
						if (num6 <= num10)
						{
							goto IL_01f4;
						}
						goto IL_027d;
						IL_01f4:
						num2 = 19;
						if (((DataGridView)DGV)[num6, DC_Main.i].Value != null)
						{
							goto IL_0217;
						}
						goto IL_0269;
						IL_0217:
						num2 = 20;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							num8 + 2,
							num6 + 1,
							((DataGridView)DGV)[num6, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0269;
						end_IL_0001_2:
						break;
					}
					num2 = 39;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 1540;
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

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		if (!DC_Main.MsOpenUserRequest)
		{
			return;
		}
		string text = "";
		checked
		{
			int num = ((DataGridView)DGV).RowCount - 1;
			DC_Main.i = 0;
			while (DC_Main.i <= num)
			{
				text = Conversions.ToString(((DataGridView)DGV)[13, DC_Main.i].Value);
				DataGridViewX dGV = DGV;
				if (Operators.ConditionalCompareObjectEqual(((DataGridView)dGV)[0, DC_Main.i].Value, (object)true, false))
				{
					if (Operators.ConditionalCompareObjectEqual(((DataGridView)dGV)[9, DC_Main.i].Value, (object)"Edit", false))
					{
						if (Operators.CompareString(text, "", false) != 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE " + text + " SET USER_UPDATE = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)dGV)[11, DC_Main.i].Value), (object)"' AND VCH_NO = '"), ((DataGridView)dGV)[3, DC_Main.i].Value), (object)"'"));
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE USER_REQUEST SET PARMATION_TYPE = 'A' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)dGV)[11, DC_Main.i].Value), (object)"' AND VCH_NO = '"), ((DataGridView)dGV)[3, DC_Main.i].Value), (object)"'"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					else
					{
						if (Operators.CompareString(text, "", false) != 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE " + text + " SET USER_DELETE = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)dGV)[11, DC_Main.i].Value), (object)"' AND VCH_NO = '"), ((DataGridView)dGV)[3, DC_Main.i].Value), (object)"'"));
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE USER_REQUEST SET PARMATION_TYPE = 'A' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)dGV)[11, DC_Main.i].Value), (object)"' AND VCH_NO = '"), ((DataGridView)dGV)[3, DC_Main.i].Value), (object)"'"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE USER_REQUEST SET PARMATION_TYPE = 'R' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '"), ((DataGridView)dGV)[11, DC_Main.i].Value), (object)"' AND VCH_NO = '"), ((DataGridView)dGV)[3, DC_Main.i].Value), (object)"'"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				dGV = null;
				DC_Main.i++;
			}
			Interaction.MsgBox((object)"User Request Is Update.....", (MsgBoxStyle)0, (object)null);
		}
	}

	private void BtnUserReqest_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
		{
			UserRequest();
		}
	}

	private void BtnWebData_Click(object sender, EventArgs e)
	{
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected O, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected O, but got Unknown
		//IL_0512: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Expected O, but got Unknown
		RptShow = "W";
		RptTitel = "'Web Data Entry Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		lblBook.Text = "Web Data Entry Report";
		DC_Main.RsQry = "SELECT A.*,B.BOOK_NAME,B.MAIN_BOOK,B.BOOK_TBL_NAME FROM WEB_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		DataGridViewX dGV = DGV;
		((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)dGV).Columns.Add("", "SrNo");
		checked
		{
			((DataGridView)dGV).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Book");
			((DataGridView)dGV).Columns[1].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "VchNo");
			((DataGridView)dGV).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "VchDate");
			((DataGridView)dGV).Columns[3].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "AcName");
			((DataGridView)dGV).Columns[4].Width = (int)Math.Round(180.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "TotAmt");
			((DataGridView)dGV).Columns[5].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "TotFine");
			((DataGridView)dGV).Columns[6].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "RecAmt");
			((DataGridView)dGV).Columns[7].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "RecFine");
			((DataGridView)dGV).Columns[8].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "EmpName");
			((DataGridView)dGV).Columns[9].Width = (int)Math.Round(105.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Book");
			((DataGridView)dGV).Columns[10].Visible = false;
			((DataGridView)dGV).Columns.Add("", "MainBook");
			((DataGridView)dGV).Columns[11].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			BookCol = 10;
			VchCol = 2;
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				((DataGridView)dGV).Rows.Add();
				((DataGridView)dGV)[1, DC_Main.X].Value = DC_Main.X + 1;
				((DataGridView)dGV)[2, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["BOOK_NAME"]);
				((DataGridView)dGV)[3, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_NO"]);
				((DataGridView)dGV)[4, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
				((DataGridView)dGV)[5, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_NAME"]);
				((DataGridView)dGV)[6, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["TOT_AMT"]);
				((DataGridView)dGV)[7, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["TOT_FINE"]);
				((DataGridView)dGV)[8, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["REC_AMT"]);
				((DataGridView)dGV)[9, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["REC_FINE"]);
				((DataGridView)dGV)[10, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["EMP_NAME"]);
				((DataGridView)dGV)[11, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CO_BOOK"]);
				((DataGridView)dGV)[12, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["MAIN_BOOK"]);
				DC_Main.X++;
			}
			dGV = null;
		}
	}

	private void chkKrOrdRec_Click(object sender, EventArgs e)
	{
		if (chkKrOrdRec.Checked)
		{
			BtnOrder_Click(btnOrder, new EventArgs());
		}
		else
		{
			BtnOrder_Click(btnOrder, new EventArgs());
		}
	}

	private void BtnPurc_Click(object sender, EventArgs e)
	{
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Expected O, but got Unknown
		//IL_06ab: Unknown result type (might be due to invalid IL or missing references)
		((Control)chkKrOrdRec).Visible = false;
		LastOpenMenu = "P";
		RptTitel = "'Purchase Reminder Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		lblBook.Text = "Purchase Reminder";
		DC_Main.ExeQuteDc("UPDATE PR_DATA SET CR_DAYS = 0 WHERE CR_DAYS IS NULL");
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.BOOK_SNAME FROM PR_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE ='" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CR_DAYS <> 0 AND A.BILL_OS + A.PARTY_FINE <> 0 AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text).AddDays(-60.0), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text).AddDays(60.0), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" ORDER BY A.AC_NAME,A.VCH_NO "));
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		DataGridViewX dGV = DGV;
		((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)dGV).AutoGenerateColumns = false;
		DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
		((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
		((DataGridView)dGV).Columns[0].Visible = false;
		((DataGridViewColumn)val).Name = "Ok";
		((DataGridView)dGV).Columns.Add("", "SrNo");
		checked
		{
			((DataGridView)dGV).Columns[1].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "AcName");
			((DataGridView)dGV).Columns[2].Width = (int)Math.Round(275.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "VchDate");
			((DataGridView)dGV).Columns[3].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "VchType");
			((DataGridView)dGV).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Book");
			((DataGridView)dGV).Columns[5].Visible = false;
			((DataGridView)dGV).Columns.Add("", "VchNo");
			((DataGridView)dGV).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "TotAmt");
			((DataGridView)dGV).Columns[7].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)dGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)dGV).Columns.Add("", "OsAmt");
			((DataGridView)dGV).Columns[8].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)dGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)dGV).Columns.Add("", "OsFine");
			((DataGridView)dGV).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)dGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[10].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[11].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[12].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[13].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			BookCol = 5;
			VchCol = 6;
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
				return;
			}
			DateTime now = DateAndTime.Now;
			DateTime now2 = DateAndTime.Now;
			DC_Main.R = 0;
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				now = Conversions.ToDate(mFromDt.Text).AddDays(0.0 - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CR_DAYS"])));
				now2 = Conversions.ToDate(mToDt.Text).AddDays(0.0 - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CR_DAYS"])));
				if ((DateTime.Compare(Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy")), now) >= 0) & (DateTime.Compare(Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy")), now2) <= 0))
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[1, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_NAME"]);
					((DataGridView)dGV)[3, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
					((DataGridView)dGV)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["BOOK_SNAME"]);
					((DataGridView)dGV)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CO_BOOK"]);
					((DataGridView)dGV)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_NO"]);
					((DataGridView)dGV)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["NET_AMT"]);
					((DataGridView)dGV)[8, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["BILL_OS"]);
					((DataGridView)dGV)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["PARTY_FINE"]);
					DC_Main.R++;
				}
				DC_Main.X++;
			}
			dGV = null;
		}
	}

	private void btnTodaySale_Click(object sender, EventArgs e)
	{
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected O, but got Unknown
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_060f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0619: Expected O, but got Unknown
		//IL_0649: Unknown result type (might be due to invalid IL or missing references)
		((Control)chkKrOrdRec).Visible = false;
		LastOpenMenu = "S";
		RptTitel = "'Today Sales Report From " + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		lblBook.Text = "Today Sales Reminder";
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.BOOK_SNAME,C.AC_MOBILE AS PARTY_MOBILE FROM (SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE ='" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND B.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" ORDER BY A.AC_NAME,A.VCH_NO "));
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		DataGridViewX dGV = DGV;
		((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)dGV).AutoGenerateColumns = false;
		DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
		((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
		((DataGridView)dGV).Columns[0].Visible = false;
		((DataGridViewColumn)val).Name = "Ok";
		((DataGridView)dGV).Columns.Add("", "SrNo");
		checked
		{
			((DataGridView)dGV).Columns[1].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "AcName");
			((DataGridView)dGV).Columns[2].Width = (int)Math.Round(275.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Mobile");
			((DataGridView)dGV).Columns[3].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "VchDate");
			((DataGridView)dGV).Columns[4].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "VchType");
			((DataGridView)dGV).Columns[5].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Book");
			((DataGridView)dGV).Columns[6].Visible = false;
			((DataGridView)dGV).Columns.Add("", "VchNo");
			((DataGridView)dGV).Columns[7].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "TotAmt");
			((DataGridView)dGV).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)dGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)dGV).Columns.Add("", "OsAmt");
			((DataGridView)dGV).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)dGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[9].DefaultCellStyle.Format = "N2";
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[10].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[11].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[12].Visible = false;
			((DataGridView)dGV).Columns.Add("", "");
			((DataGridView)dGV).Columns[13].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			BookCol = 5;
			VchCol = 6;
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
				return;
			}
			DateTime now = DateAndTime.Now;
			DateTime now2 = DateAndTime.Now;
			DC_Main.R = 0;
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				now = Conversions.ToDate(mFromDt.Text).AddDays(0.0 - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CR_DAYS"])));
				now2 = Conversions.ToDate(mToDt.Text).AddDays(0.0 - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CR_DAYS"])));
				if ((DateTime.Compare(Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy")), now) >= 0) & (DateTime.Compare(Conversions.ToDate(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy")), now2) <= 0))
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[1, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_NAME"]);
					((DataGridView)dGV)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["PARTY_MOBILE"]);
					((DataGridView)dGV)[4, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_DATE"]), "dd/MM/yyyy");
					((DataGridView)dGV)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["BOOK_SNAME"]);
					((DataGridView)dGV)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["CO_BOOK"]);
					((DataGridView)dGV)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["VCH_NO"]);
					((DataGridView)dGV)[8, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["NET_AMT"]);
					((DataGridView)dGV)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["BILL_OS"]);
					DC_Main.R++;
				}
				DC_Main.X++;
			}
			dGV = null;
		}
	}
}
