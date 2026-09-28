using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class BtmSchm : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlBotam")]
	private FlowLayoutPanel _PnlBotam;

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
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnItmStk")]
	private SimpleButton _BtnItmStk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnTagStock")]
	private SimpleButton _BtnTagStock;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnAcBalence")]
	private SimpleButton _BtnAcBalence;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnOrder")]
	private SimpleButton _BtnOrder;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDhrn")]
	private SimpleButton _BtnDhrn;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnLoan")]
	private SimpleButton _BtnLoan;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SimpleButton1")]
	private SimpleButton _SimpleButton1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnApr")]
	private SimpleButton _BtnApr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBillOs")]
	private SimpleButton _btnBillOs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTimeLdr")]
	private SimpleButton _btnTimeLdr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblJadtarTrfr")]
	private SimpleButton _lblJadtarTrfr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBillOrnaIsu")]
	private SimpleButton _btnBillOrnaIsu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnVptrfr")]
	private SimpleButton _btnVptrfr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBulTrfr")]
	private SimpleButton _btnBulTrfr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("brnOrdTraking")]
	private SimpleButton _brnOrdTraking;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnReparing")]
	private SimpleButton _btnReparing;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnLotTrfr")]
	private SimpleButton _btnLotTrfr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnIdtl")]
	private SimpleButton _btnIdtl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnMfgTrfr")]
	private SimpleButton _btnMfgTrfr;

	private Control CurActCtrl;

	private double ColCon;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string TrfrMdbName;

	private string CurProcess;

	private DataTable TrFrData;

	private DataTable RsData;

	private DataTable RsDetl;

	private DateTime mTrfr_dt;

	internal virtual FlowLayoutPanel PnlBotam
	{
		[CompilerGenerated]
		get
		{
			return _PnlBotam;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PnlBotam_DoubleClick;
			FlowLayoutPanel val = _PnlBotam;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PnlBotam = value;
			val = _PnlBotam;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
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

	internal virtual SimpleButton BtnItmStk
	{
		[CompilerGenerated]
		get
		{
			return _BtnItmStk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnItmStk_Click;
			SimpleButton val = _BtnItmStk;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnItmStk = value;
			val = _BtnItmStk;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnTagStock
	{
		[CompilerGenerated]
		get
		{
			return _BtnTagStock;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTagStock_Click;
			SimpleButton val = _BtnTagStock;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnTagStock = value;
			val = _BtnTagStock;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DlgOpn")]
	private virtual OpenFileDialog _DlgOpn;

	internal virtual OpenFileDialog DlgOpn
	{
		get
		{
			return _DlgOpn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DlgOpn = value;
		}
	}

	internal virtual SimpleButton BtnAcBalence
	{
		[CompilerGenerated]
		get
		{
			return _BtnAcBalence;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAcBalence_Click;
			SimpleButton val = _BtnAcBalence;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnAcBalence = value;
			val = _BtnAcBalence;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tYearCode")]
	private virtual TextBox _tYearCode;

	internal virtual TextBox tYearCode
	{
		get
		{
			return _tYearCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tYearCode = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblLcName")]
	private virtual Label _lblLcName;

	internal virtual Label lblLcName
	{
		get
		{
			return _lblLcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblLcName = value;
		}
	}

	internal virtual SimpleButton BtnOrder
	{
		[CompilerGenerated]
		get
		{
			return _BtnOrder;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOrder_Click;
			SimpleButton val = _BtnOrder;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnOrder = value;
			val = _BtnOrder;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnDhrn
	{
		[CompilerGenerated]
		get
		{
			return _BtnDhrn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDhrn_Click;
			SimpleButton val = _BtnDhrn;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnDhrn = value;
			val = _BtnDhrn;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnLoan
	{
		[CompilerGenerated]
		get
		{
			return _BtnLoan;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnLoan_Click;
			SimpleButton val = _BtnLoan;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnLoan = value;
			val = _BtnLoan;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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

	internal virtual SimpleButton BtnApr
	{
		[CompilerGenerated]
		get
		{
			return _BtnApr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnApr_Click;
			SimpleButton val = _BtnApr;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnApr = value;
			val = _BtnApr;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnBillOs
	{
		[CompilerGenerated]
		get
		{
			return _btnBillOs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnBillOs_Click;
			SimpleButton val = _btnBillOs;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBillOs = value;
			val = _btnBillOs;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnTimeLdr
	{
		[CompilerGenerated]
		get
		{
			return _btnTimeLdr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTimeLdr_Click;
			SimpleButton val = _btnTimeLdr;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTimeLdr = value;
			val = _btnTimeLdr;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton lblJadtarTrfr
	{
		[CompilerGenerated]
		get
		{
			return _lblJadtarTrfr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = LblJadtarTrfr_Click;
			SimpleButton val = _lblJadtarTrfr;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_lblJadtarTrfr = value;
			val = _lblJadtarTrfr;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnBillOrnaIsu
	{
		[CompilerGenerated]
		get
		{
			return _btnBillOrnaIsu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnBillOrnaIsu_Click;
			SimpleButton val = _btnBillOrnaIsu;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBillOrnaIsu = value;
			val = _btnBillOrnaIsu;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnVptrfr
	{
		[CompilerGenerated]
		get
		{
			return _btnVptrfr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnVptrfr_Click;
			SimpleButton val = _btnVptrfr;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnVptrfr = value;
			val = _btnVptrfr;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnBulTrfr
	{
		[CompilerGenerated]
		get
		{
			return _btnBulTrfr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnBulTrfr_Click;
			SimpleButton val = _btnBulTrfr;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBulTrfr = value;
			val = _btnBulTrfr;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton brnOrdTraking
	{
		[CompilerGenerated]
		get
		{
			return _brnOrdTraking;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BrnOrdTraking_Click;
			SimpleButton val = _brnOrdTraking;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_brnOrdTraking = value;
			val = _brnOrdTraking;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnReparing
	{
		[CompilerGenerated]
		get
		{
			return _btnReparing;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnReparing_Click;
			SimpleButton val = _btnReparing;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnReparing = value;
			val = _btnReparing;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnLotTrfr
	{
		[CompilerGenerated]
		get
		{
			return _btnLotTrfr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnLotTrfr_Click;
			SimpleButton val = _btnLotTrfr;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnLotTrfr = value;
			val = _btnLotTrfr;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnIdtl
	{
		[CompilerGenerated]
		get
		{
			return _btnIdtl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnIdtl_Click;
			SimpleButton val = _btnIdtl;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnIdtl = value;
			val = _btnIdtl;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnMfgTrfr
	{
		[CompilerGenerated]
		get
		{
			return _btnMfgTrfr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnMfgTrfr_Click;
			SimpleButton val = _btnMfgTrfr;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnMfgTrfr = value;
			val = _btnMfgTrfr;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public BtmSchm()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += MS_BAL_TRFR_Load;
		((Form)this).Activated += MS_BAL_TRFR_Activated;
		((Form)this).Deactivate += MS_BAL_TRFR_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_BAL_TRFR_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_BAL_TRFR_KeyDown);
		((Form)this).Closed += MS_BAL_TRFR_Closed;
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
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Expected O, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e0: Expected O, but got Unknown
		//IL_05fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0607: Expected O, but got Unknown
		//IL_066a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0674: Expected O, but got Unknown
		//IL_071d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0727: Expected O, but got Unknown
		//IL_078a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0794: Expected O, but got Unknown
		//IL_086f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0879: Expected O, but got Unknown
		//IL_099c: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a6: Expected O, but got Unknown
		//IL_0a7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a88: Expected O, but got Unknown
		//IL_0b24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2e: Expected O, but got Unknown
		//IL_0c62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6c: Expected O, but got Unknown
		//IL_0d44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4e: Expected O, but got Unknown
		//IL_0dea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df4: Expected O, but got Unknown
		//IL_0f39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f43: Expected O, but got Unknown
		//IL_101b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1025: Expected O, but got Unknown
		//IL_10c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10cb: Expected O, but got Unknown
		//IL_11dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e6: Expected O, but got Unknown
		//IL_1278: Unknown result type (might be due to invalid IL or missing references)
		//IL_1282: Expected O, but got Unknown
		//IL_1349: Unknown result type (might be due to invalid IL or missing references)
		//IL_1353: Expected O, but got Unknown
		//IL_142b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1435: Expected O, but got Unknown
		//IL_14d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_14db: Expected O, but got Unknown
		//IL_1613: Unknown result type (might be due to invalid IL or missing references)
		//IL_161d: Expected O, but got Unknown
		//IL_16f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ff: Expected O, but got Unknown
		//IL_179b: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a5: Expected O, but got Unknown
		//IL_18dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e7: Expected O, but got Unknown
		//IL_19bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c9: Expected O, but got Unknown
		//IL_1a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a6f: Expected O, but got Unknown
		//IL_1ba7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb1: Expected O, but got Unknown
		//IL_1c89: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c93: Expected O, but got Unknown
		//IL_1d2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d39: Expected O, but got Unknown
		//IL_1e71: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e7b: Expected O, but got Unknown
		//IL_1f53: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f5d: Expected O, but got Unknown
		//IL_1ff9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2003: Expected O, but got Unknown
		//IL_213b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2145: Expected O, but got Unknown
		//IL_221d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2227: Expected O, but got Unknown
		//IL_22c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_22cd: Expected O, but got Unknown
		//IL_2402: Unknown result type (might be due to invalid IL or missing references)
		//IL_240c: Expected O, but got Unknown
		//IL_24e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_24ee: Expected O, but got Unknown
		//IL_258a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2594: Expected O, but got Unknown
		//IL_26cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_26d6: Expected O, but got Unknown
		//IL_27ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_27b8: Expected O, but got Unknown
		//IL_2854: Unknown result type (might be due to invalid IL or missing references)
		//IL_285e: Expected O, but got Unknown
		//IL_29a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_29ad: Expected O, but got Unknown
		//IL_2a85: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a8f: Expected O, but got Unknown
		//IL_2b2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b35: Expected O, but got Unknown
		//IL_2c6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c77: Expected O, but got Unknown
		//IL_2d4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d59: Expected O, but got Unknown
		//IL_2df5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dff: Expected O, but got Unknown
		//IL_2f37: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f41: Expected O, but got Unknown
		//IL_3019: Unknown result type (might be due to invalid IL or missing references)
		//IL_3023: Expected O, but got Unknown
		//IL_30bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_30c9: Expected O, but got Unknown
		//IL_31fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_3208: Expected O, but got Unknown
		//IL_32e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_32ea: Expected O, but got Unknown
		//IL_3386: Unknown result type (might be due to invalid IL or missing references)
		//IL_3390: Expected O, but got Unknown
		//IL_34c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_34d2: Expected O, but got Unknown
		//IL_35aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_35b4: Expected O, but got Unknown
		//IL_3650: Unknown result type (might be due to invalid IL or missing references)
		//IL_365a: Expected O, but got Unknown
		//IL_3792: Unknown result type (might be due to invalid IL or missing references)
		//IL_379c: Expected O, but got Unknown
		//IL_3874: Unknown result type (might be due to invalid IL or missing references)
		//IL_387e: Expected O, but got Unknown
		//IL_391a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3924: Expected O, but got Unknown
		//IL_3a5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a66: Expected O, but got Unknown
		//IL_3b3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b48: Expected O, but got Unknown
		//IL_3be4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bee: Expected O, but got Unknown
		//IL_3d33: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d3d: Expected O, but got Unknown
		//IL_3e15: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e1f: Expected O, but got Unknown
		//IL_3ebb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ec5: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(BtmSchm));
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		lblBook = new Label();
		ProgressBar1 = new ProgressBar();
		BtnItmStk = new SimpleButton();
		BtnTagStock = new SimpleButton();
		DlgOpn = new OpenFileDialog();
		BtnAcBalence = new SimpleButton();
		tYearCode = new TextBox();
		lblLcName = new Label();
		BtnOrder = new SimpleButton();
		BtnDhrn = new SimpleButton();
		BtnLoan = new SimpleButton();
		SimpleButton1 = new SimpleButton();
		BtnApr = new SimpleButton();
		btnBillOs = new SimpleButton();
		btnTimeLdr = new SimpleButton();
		lblJadtarTrfr = new SimpleButton();
		btnBillOrnaIsu = new SimpleButton();
		btnVptrfr = new SimpleButton();
		btnBulTrfr = new SimpleButton();
		brnOrdTraking = new SimpleButton();
		btnReparing = new SimpleButton();
		btnLotTrfr = new SimpleButton();
		btnIdtl = new SimpleButton();
		btnMfgTrfr = new SimpleButton();
		((Control)PnlBotam).SuspendLayout();
		((Control)this).SuspendLayout();
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
		((Control)PnlBotam).TabIndex = 4;
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
		lblBook.Text = "Balance Transfer";
		lblBook.TextAlign = (ContentAlignment)32;
		((Control)ProgressBar1).Location = new Point(0, 426);
		((Control)ProgressBar1).Name = "ProgressBar1";
		((Control)ProgressBar1).Size = new Size(1309, 23);
		((Control)ProgressBar1).TabIndex = 1152;
		((BaseStyleControl)BtnItmStk).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnItmStk).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnItmStk).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnItmStk).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnItmStk).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnItmStk).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnItmStk).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnItmStk).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnItmStk).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnItmStk).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnItmStk).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnItmStk).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnItmStk).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnItmStk).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnItmStk).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnItmStk).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnItmStk).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnItmStk).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnItmStk).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnItmStk).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnItmStk).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnItmStk).AppearancePressed.Options.UseFont = true;
		((Control)BtnItmStk).Location = new Point(522, 150);
		((BaseControl)BtnItmStk).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnItmStk).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnItmStk).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnItmStk).Name = "BtnItmStk";
		((Control)BtnItmStk).Size = new Size(127, 32);
		((Control)BtnItmStk).TabIndex = 2;
		BtnItmStk.Text = "Item Stock";
		((BaseControl)BtnItmStk).ToolTip = "Item Stock Transfer";
		((BaseStyleControl)BtnTagStock).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnTagStock).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnTagStock).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnTagStock).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnTagStock).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnTagStock).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnTagStock).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnTagStock).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnTagStock).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnTagStock).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnTagStock).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnTagStock).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnTagStock).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnTagStock).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnTagStock).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnTagStock).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnTagStock).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnTagStock).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnTagStock).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnTagStock).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnTagStock).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnTagStock).AppearancePressed.Options.UseFont = true;
		((Control)BtnTagStock).Location = new Point(522, 188);
		((BaseControl)BtnTagStock).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnTagStock).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnTagStock).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnTagStock).Name = "BtnTagStock";
		((Control)BtnTagStock).Size = new Size(127, 32);
		((Control)BtnTagStock).TabIndex = 3;
		BtnTagStock.Text = "Tag Stock";
		((BaseControl)BtnTagStock).ToolTip = "Tag Stock Transfer";
		((FileDialog)DlgOpn).FileName = "DlgOpen";
		((BaseStyleControl)BtnAcBalence).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnAcBalence).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnAcBalence).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnAcBalence).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnAcBalence).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnAcBalence).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnAcBalence).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnAcBalence).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnAcBalence).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnAcBalence).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnAcBalence).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnAcBalence).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnAcBalence).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnAcBalence).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnAcBalence).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnAcBalence).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnAcBalence).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnAcBalence).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnAcBalence).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnAcBalence).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnAcBalence).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnAcBalence).AppearancePressed.Options.UseFont = true;
		((Control)BtnAcBalence).Location = new Point(522, 112);
		((BaseControl)BtnAcBalence).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnAcBalence).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnAcBalence).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnAcBalence).Name = "BtnAcBalence";
		((Control)BtnAcBalence).Size = new Size(127, 32);
		((Control)BtnAcBalence).TabIndex = 1;
		BtnAcBalence.Text = "Ac Balance";
		((BaseControl)BtnAcBalence).ToolTip = "Party Balace Transfer";
		((TextBoxBase)tYearCode).BackColor = Color.Gainsboro;
		((Control)tYearCode).Font = new Font("Segoe UI Semibold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tYearCode).ForeColor = Color.Maroon;
		((Control)tYearCode).Location = new Point(522, 71);
		((Control)tYearCode).Name = "tYearCode";
		((Control)tYearCode).Size = new Size(127, 27);
		((Control)tYearCode).TabIndex = 1153;
		tYearCode.TextAlign = (HorizontalAlignment)2;
		((Control)lblLcName).BackColor = Color.Transparent;
		((Control)lblLcName).Font = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblLcName).ForeColor = Color.Maroon;
		((Control)lblLcName).Location = new Point(385, 71);
		((Control)lblLcName).Name = "lblLcName";
		((Control)lblLcName).Size = new Size(131, 25);
		((Control)lblLcName).TabIndex = 1154;
		lblLcName.Text = "Transfer Year";
		lblLcName.TextAlign = (ContentAlignment)64;
		((BaseStyleControl)BtnOrder).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnOrder).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnOrder).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnOrder).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnOrder).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnOrder).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnOrder).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnOrder).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnOrder).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnOrder).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnOrder).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnOrder).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnOrder).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnOrder).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnOrder).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnOrder).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnOrder).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnOrder).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnOrder).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnOrder).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnOrder).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnOrder).AppearancePressed.Options.UseFont = true;
		((Control)BtnOrder).Location = new Point(522, 226);
		((BaseControl)BtnOrder).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnOrder).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnOrder).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnOrder).Name = "BtnOrder";
		((Control)BtnOrder).Size = new Size(127, 32);
		((Control)BtnOrder).TabIndex = 1155;
		BtnOrder.Text = "Sales Order";
		((BaseControl)BtnOrder).ToolTip = "Order Transfer";
		((BaseStyleControl)BtnDhrn).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnDhrn).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnDhrn).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnDhrn).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnDhrn).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnDhrn).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnDhrn).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnDhrn).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDhrn).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnDhrn).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnDhrn).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnDhrn).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnDhrn).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnDhrn).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnDhrn).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnDhrn).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnDhrn).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnDhrn).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnDhrn).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnDhrn).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnDhrn).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnDhrn).AppearancePressed.Options.UseFont = true;
		((Control)BtnDhrn).Location = new Point(522, 340);
		((BaseControl)BtnDhrn).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnDhrn).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnDhrn).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDhrn).Name = "BtnDhrn";
		((Control)BtnDhrn).Size = new Size(127, 32);
		((Control)BtnDhrn).TabIndex = 1156;
		BtnDhrn.Text = "Dhiran";
		((BaseControl)BtnDhrn).ToolTip = "Dhirna Transfer";
		((BaseStyleControl)BtnLoan).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnLoan).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnLoan).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnLoan).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnLoan).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnLoan).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnLoan).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnLoan).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnLoan).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnLoan).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnLoan).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnLoan).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnLoan).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnLoan).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnLoan).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnLoan).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnLoan).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnLoan).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnLoan).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnLoan).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnLoan).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnLoan).AppearancePressed.Options.UseFont = true;
		((Control)BtnLoan).Location = new Point(522, 378);
		((BaseControl)BtnLoan).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnLoan).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnLoan).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnLoan).Name = "BtnLoan";
		((Control)BtnLoan).Size = new Size(127, 32);
		((Control)BtnLoan).TabIndex = 1157;
		BtnLoan.Text = "Loan";
		((BaseControl)BtnLoan).ToolTip = "Loan Transfer";
		((BaseStyleControl)SimpleButton1).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)SimpleButton1).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)SimpleButton1).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)SimpleButton1).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)SimpleButton1).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)SimpleButton1).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)SimpleButton1).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)SimpleButton1).Appearance.Options.UseFont = true;
		((BaseStyleControl)SimpleButton1).Appearance.Options.UseForeColor = true;
		((BaseButton)SimpleButton1).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)SimpleButton1).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)SimpleButton1).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)SimpleButton1).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)SimpleButton1).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)SimpleButton1).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)SimpleButton1).AppearanceHovered.Options.UseFont = true;
		((BaseButton)SimpleButton1).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)SimpleButton1).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)SimpleButton1).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)SimpleButton1).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)SimpleButton1).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)SimpleButton1).AppearancePressed.Options.UseFont = true;
		((Control)SimpleButton1).Location = new Point(522, 302);
		((BaseControl)SimpleButton1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)SimpleButton1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)SimpleButton1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)SimpleButton1).Name = "SimpleButton1";
		((Control)SimpleButton1).Size = new Size(127, 32);
		((Control)SimpleButton1).TabIndex = 1158;
		SimpleButton1.Text = "Scheme";
		((BaseControl)SimpleButton1).ToolTip = "Scheme Transfer";
		((BaseStyleControl)BtnApr).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnApr).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnApr).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnApr).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnApr).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnApr).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnApr).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnApr).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnApr).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnApr).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnApr).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnApr).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnApr).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnApr).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnApr).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnApr).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnApr).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnApr).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnApr).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnApr).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnApr).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnApr).AppearancePressed.Options.UseFont = true;
		((Control)BtnApr).Location = new Point(522, 264);
		((BaseControl)BtnApr).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnApr).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnApr).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnApr).Name = "BtnApr";
		((Control)BtnApr).Size = new Size(127, 32);
		((Control)BtnApr).TabIndex = 1159;
		BtnApr.Text = "Approval";
		((BaseControl)BtnApr).ToolTip = "Approval Transfer";
		((BaseStyleControl)btnBillOs).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnBillOs).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnBillOs).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnBillOs).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnBillOs).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnBillOs).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnBillOs).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnBillOs).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnBillOs).Appearance.Options.UseForeColor = true;
		((BaseButton)btnBillOs).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnBillOs).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnBillOs).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnBillOs).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnBillOs).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnBillOs).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnBillOs).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnBillOs).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnBillOs).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnBillOs).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnBillOs).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnBillOs).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnBillOs).AppearancePressed.Options.UseFont = true;
		((Control)btnBillOs).Location = new Point(667, 112);
		((BaseControl)btnBillOs).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnBillOs).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnBillOs).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnBillOs).Name = "btnBillOs";
		((Control)btnBillOs).Size = new Size(127, 32);
		((Control)btnBillOs).TabIndex = 1160;
		btnBillOs.Text = "Bill Os Trfr";
		((BaseControl)btnBillOs).ToolTip = "Bill Os";
		((BaseStyleControl)btnTimeLdr).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnTimeLdr).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnTimeLdr).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnTimeLdr).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnTimeLdr).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnTimeLdr).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnTimeLdr).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnTimeLdr).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTimeLdr).Appearance.Options.UseForeColor = true;
		((BaseButton)btnTimeLdr).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnTimeLdr).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnTimeLdr).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnTimeLdr).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnTimeLdr).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnTimeLdr).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnTimeLdr).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnTimeLdr).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnTimeLdr).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnTimeLdr).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnTimeLdr).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnTimeLdr).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnTimeLdr).AppearancePressed.Options.UseFont = true;
		((Control)btnTimeLdr).Location = new Point(667, 150);
		((BaseControl)btnTimeLdr).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnTimeLdr).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnTimeLdr).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTimeLdr).Name = "btnTimeLdr";
		((Control)btnTimeLdr).Size = new Size(127, 32);
		((Control)btnTimeLdr).TabIndex = 1161;
		btnTimeLdr.Text = "Time Ldr Trfr";
		((BaseControl)btnTimeLdr).ToolTip = "Bill Os";
		((BaseStyleControl)lblJadtarTrfr).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)lblJadtarTrfr).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)lblJadtarTrfr).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)lblJadtarTrfr).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)lblJadtarTrfr).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)lblJadtarTrfr).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)lblJadtarTrfr).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)lblJadtarTrfr).Appearance.Options.UseFont = true;
		((BaseStyleControl)lblJadtarTrfr).Appearance.Options.UseForeColor = true;
		((BaseButton)lblJadtarTrfr).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)lblJadtarTrfr).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)lblJadtarTrfr).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)lblJadtarTrfr).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)lblJadtarTrfr).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)lblJadtarTrfr).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)lblJadtarTrfr).AppearanceHovered.Options.UseFont = true;
		((BaseButton)lblJadtarTrfr).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)lblJadtarTrfr).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)lblJadtarTrfr).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)lblJadtarTrfr).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)lblJadtarTrfr).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)lblJadtarTrfr).AppearancePressed.Options.UseFont = true;
		((Control)lblJadtarTrfr).Location = new Point(809, 150);
		((BaseControl)lblJadtarTrfr).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)lblJadtarTrfr).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)lblJadtarTrfr).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)lblJadtarTrfr).Name = "lblJadtarTrfr";
		((Control)lblJadtarTrfr).Size = new Size(127, 32);
		((Control)lblJadtarTrfr).TabIndex = 1162;
		lblJadtarTrfr.Text = "Jadtar Trfr";
		((BaseControl)lblJadtarTrfr).ToolTip = "Bill Os";
		((Control)lblJadtarTrfr).Visible = false;
		((BaseStyleControl)btnBillOrnaIsu).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnBillOrnaIsu).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnBillOrnaIsu).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnBillOrnaIsu).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnBillOrnaIsu).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnBillOrnaIsu).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnBillOrnaIsu).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnBillOrnaIsu).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnBillOrnaIsu).Appearance.Options.UseForeColor = true;
		((BaseButton)btnBillOrnaIsu).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnBillOrnaIsu).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnBillOrnaIsu).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnBillOrnaIsu).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnBillOrnaIsu).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnBillOrnaIsu).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnBillOrnaIsu).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnBillOrnaIsu).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnBillOrnaIsu).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnBillOrnaIsu).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnBillOrnaIsu).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnBillOrnaIsu).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnBillOrnaIsu).AppearancePressed.Options.UseFont = true;
		((Control)btnBillOrnaIsu).Location = new Point(667, 188);
		((BaseControl)btnBillOrnaIsu).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnBillOrnaIsu).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnBillOrnaIsu).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnBillOrnaIsu).Name = "btnBillOrnaIsu";
		((Control)btnBillOrnaIsu).Size = new Size(127, 32);
		((Control)btnBillOrnaIsu).TabIndex = 1163;
		btnBillOrnaIsu.Text = "Bill Orna Isu";
		((BaseControl)btnBillOrnaIsu).ToolTip = "Bill Orna Isu Panding";
		((BaseStyleControl)btnVptrfr).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnVptrfr).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnVptrfr).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnVptrfr).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnVptrfr).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnVptrfr).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnVptrfr).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnVptrfr).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnVptrfr).Appearance.Options.UseForeColor = true;
		((BaseButton)btnVptrfr).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnVptrfr).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnVptrfr).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnVptrfr).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnVptrfr).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnVptrfr).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnVptrfr).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnVptrfr).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnVptrfr).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnVptrfr).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnVptrfr).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnVptrfr).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnVptrfr).AppearancePressed.Options.UseFont = true;
		((Control)btnVptrfr).Location = new Point(667, 264);
		((BaseControl)btnVptrfr).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnVptrfr).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnVptrfr).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnVptrfr).Name = "btnVptrfr";
		((Control)btnVptrfr).Size = new Size(127, 32);
		((Control)btnVptrfr).TabIndex = 1164;
		btnVptrfr.Text = "Vp Trfr";
		((BaseControl)btnVptrfr).ToolTip = "Bill Os";
		((BaseStyleControl)btnBulTrfr).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnBulTrfr).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnBulTrfr).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnBulTrfr).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnBulTrfr).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnBulTrfr).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnBulTrfr).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnBulTrfr).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnBulTrfr).Appearance.Options.UseForeColor = true;
		((BaseButton)btnBulTrfr).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnBulTrfr).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnBulTrfr).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnBulTrfr).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnBulTrfr).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnBulTrfr).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnBulTrfr).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnBulTrfr).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnBulTrfr).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnBulTrfr).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnBulTrfr).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnBulTrfr).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnBulTrfr).AppearancePressed.Options.UseFont = true;
		((Control)btnBulTrfr).Location = new Point(809, 112);
		((BaseControl)btnBulTrfr).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnBulTrfr).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnBulTrfr).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnBulTrfr).Name = "btnBulTrfr";
		((Control)btnBulTrfr).Size = new Size(127, 32);
		((Control)btnBulTrfr).TabIndex = 1165;
		btnBulTrfr.Text = "Bullion Trfr";
		((BaseControl)btnBulTrfr).ToolTip = "Bullion Trfr";
		((BaseStyleControl)brnOrdTraking).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)brnOrdTraking).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)brnOrdTraking).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)brnOrdTraking).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)brnOrdTraking).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)brnOrdTraking).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)brnOrdTraking).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)brnOrdTraking).Appearance.Options.UseFont = true;
		((BaseStyleControl)brnOrdTraking).Appearance.Options.UseForeColor = true;
		((BaseButton)brnOrdTraking).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)brnOrdTraking).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)brnOrdTraking).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)brnOrdTraking).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)brnOrdTraking).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)brnOrdTraking).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)brnOrdTraking).AppearanceHovered.Options.UseFont = true;
		((BaseButton)brnOrdTraking).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)brnOrdTraking).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)brnOrdTraking).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)brnOrdTraking).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)brnOrdTraking).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)brnOrdTraking).AppearancePressed.Options.UseFont = true;
		((Control)brnOrdTraking).Location = new Point(667, 302);
		((BaseControl)brnOrdTraking).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)brnOrdTraking).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)brnOrdTraking).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)brnOrdTraking).Name = "brnOrdTraking";
		((Control)brnOrdTraking).Size = new Size(127, 32);
		((Control)brnOrdTraking).TabIndex = 1166;
		brnOrdTraking.Text = "Order Traking";
		((BaseControl)brnOrdTraking).ToolTip = "Bill Os";
		((BaseStyleControl)btnReparing).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnReparing).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnReparing).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnReparing).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnReparing).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnReparing).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnReparing).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnReparing).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnReparing).Appearance.Options.UseForeColor = true;
		((BaseButton)btnReparing).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnReparing).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnReparing).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnReparing).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnReparing).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnReparing).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnReparing).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnReparing).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnReparing).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnReparing).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnReparing).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnReparing).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnReparing).AppearancePressed.Options.UseFont = true;
		((Control)btnReparing).Location = new Point(667, 226);
		((BaseControl)btnReparing).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnReparing).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnReparing).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnReparing).Name = "btnReparing";
		((Control)btnReparing).Size = new Size(127, 32);
		((Control)btnReparing).TabIndex = 1167;
		btnReparing.Text = "Reparing Trfr";
		((BaseControl)btnReparing).ToolTip = "Bill Os";
		((BaseStyleControl)btnLotTrfr).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnLotTrfr).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnLotTrfr).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnLotTrfr).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnLotTrfr).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnLotTrfr).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnLotTrfr).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnLotTrfr).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnLotTrfr).Appearance.Options.UseForeColor = true;
		((BaseButton)btnLotTrfr).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnLotTrfr).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnLotTrfr).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnLotTrfr).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnLotTrfr).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnLotTrfr).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnLotTrfr).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnLotTrfr).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnLotTrfr).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnLotTrfr).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnLotTrfr).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnLotTrfr).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnLotTrfr).AppearancePressed.Options.UseFont = true;
		((Control)btnLotTrfr).Location = new Point(667, 340);
		((BaseControl)btnLotTrfr).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnLotTrfr).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnLotTrfr).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnLotTrfr).Name = "btnLotTrfr";
		((Control)btnLotTrfr).Size = new Size(127, 32);
		((Control)btnLotTrfr).TabIndex = 1168;
		btnLotTrfr.Text = "Item Lot Trfr";
		((BaseControl)btnLotTrfr).ToolTip = "Item Lot Trfr";
		((BaseStyleControl)btnIdtl).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnIdtl).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnIdtl).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnIdtl).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnIdtl).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnIdtl).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnIdtl).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnIdtl).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnIdtl).Appearance.Options.UseForeColor = true;
		((BaseButton)btnIdtl).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnIdtl).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnIdtl).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnIdtl).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnIdtl).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnIdtl).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnIdtl).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnIdtl).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnIdtl).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnIdtl).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnIdtl).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnIdtl).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnIdtl).AppearancePressed.Options.UseFont = true;
		((Control)btnIdtl).Location = new Point(522, 475);
		((BaseControl)btnIdtl).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnIdtl).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnIdtl).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnIdtl).Name = "btnIdtl";
		((Control)btnIdtl).Size = new Size(127, 32);
		((Control)btnIdtl).TabIndex = 1169;
		btnIdtl.Text = "Tag Idtl Trfr";
		((BaseControl)btnIdtl).ToolTip = "Tag Stock Transfer";
		((Control)btnIdtl).Visible = false;
		((BaseStyleControl)btnMfgTrfr).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnMfgTrfr).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnMfgTrfr).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnMfgTrfr).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnMfgTrfr).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnMfgTrfr).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnMfgTrfr).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnMfgTrfr).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnMfgTrfr).Appearance.Options.UseForeColor = true;
		((BaseButton)btnMfgTrfr).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnMfgTrfr).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnMfgTrfr).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnMfgTrfr).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnMfgTrfr).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnMfgTrfr).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnMfgTrfr).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnMfgTrfr).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnMfgTrfr).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnMfgTrfr).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnMfgTrfr).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnMfgTrfr).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnMfgTrfr).AppearancePressed.Options.UseFont = true;
		((Control)btnMfgTrfr).Location = new Point(809, 188);
		((BaseControl)btnMfgTrfr).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnMfgTrfr).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnMfgTrfr).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnMfgTrfr).Name = "btnMfgTrfr";
		((Control)btnMfgTrfr).Size = new Size(127, 32);
		((Control)btnMfgTrfr).TabIndex = 1170;
		btnMfgTrfr.Text = "Mfg Trfr";
		((BaseControl)btnMfgTrfr).ToolTip = "Bill Os";
		((Control)btnMfgTrfr).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)btnMfgTrfr);
		((Control)this).Controls.Add((Control)(object)btnIdtl);
		((Control)this).Controls.Add((Control)(object)btnLotTrfr);
		((Control)this).Controls.Add((Control)(object)btnReparing);
		((Control)this).Controls.Add((Control)(object)brnOrdTraking);
		((Control)this).Controls.Add((Control)(object)btnBulTrfr);
		((Control)this).Controls.Add((Control)(object)btnVptrfr);
		((Control)this).Controls.Add((Control)(object)btnBillOrnaIsu);
		((Control)this).Controls.Add((Control)(object)lblJadtarTrfr);
		((Control)this).Controls.Add((Control)(object)btnTimeLdr);
		((Control)this).Controls.Add((Control)(object)btnBillOs);
		((Control)this).Controls.Add((Control)(object)BtnApr);
		((Control)this).Controls.Add((Control)(object)SimpleButton1);
		((Control)this).Controls.Add((Control)(object)BtnLoan);
		((Control)this).Controls.Add((Control)(object)BtnDhrn);
		((Control)this).Controls.Add((Control)(object)BtnOrder);
		((Control)this).Controls.Add((Control)(object)lblLcName);
		((Control)this).Controls.Add((Control)(object)tYearCode);
		((Control)this).Controls.Add((Control)(object)BtnAcBalence);
		((Control)this).Controls.Add((Control)(object)BtnTagStock);
		((Control)this).Controls.Add((Control)(object)BtnItmStk);
		((Control)this).Controls.Add((Control)(object)ProgressBar1);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "BtmSchm";
		((Form)this).Text = "Balance Transfer";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MS_BAL_TRFR_Load(object sender, EventArgs e)
	{
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_0793: Unknown result type (might be due to invalid IL or missing references)
		//IL_079a: Expected O, but got Unknown
		//IL_07ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0804: Unknown result type (might be due to invalid IL or missing references)
		//IL_080e: Expected O, but got Unknown
		//IL_0896: Unknown result type (might be due to invalid IL or missing references)
		//IL_089b: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a5: Expected O, but got Unknown
		//IL_0917: Unknown result type (might be due to invalid IL or missing references)
		//IL_091c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0922: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurProcess = DC_Main.MsUserRightForm;
		lblBook.Text = CurProcess;
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
				AppearanceObject appearance = ((BaseStyleControl)BtnItmStk).Appearance;
				object? obj8 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnTagStock).Appearance;
				object? obj9 = colorConverter.ConvertFromString("233, 235, 240");
				appearance2.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj10 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj11 = lblBook;
				object? obj12 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj11).ForeColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj13 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AppearanceObject appearance3 = ((BaseStyleControl)BtnItmStk).Appearance;
				object? obj14 = colorConverter.ConvertFromString("Cornsilk");
				appearance3.BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AppearanceObject appearance4 = ((BaseStyleControl)BtnTagStock).Appearance;
				object? obj15 = colorConverter.ConvertFromString("Cornsilk");
				appearance4.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AppearanceObject appearance5 = ((BaseStyleControl)BtnItmStk).Appearance;
				object? obj16 = colorConverter.ConvertFromString("0, 0, 192");
				appearance5.ForeColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AppearanceObject appearance6 = ((BaseStyleControl)BtnTagStock).Appearance;
				object? obj17 = colorConverter.ConvertFromString("0, 0, 192");
				appearance6.ForeColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnAcBalence).Font.Size * (1.0 + num2));
				Font font = ((BaseStyleControl)BtnAcBalence).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is SimpleButton || val3 is MaskedTextBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
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
			if (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0)
			{
				((Control)lblJadtarTrfr).Visible = true;
			}
			if (Operators.CompareString(DC_Main.MsMfgType, "M", false) == 0)
			{
				((Control)btnMfgTrfr).Visible = true;
			}
			if (Operators.CompareString(DC_Main.MsOsBillOrnaIsu, "N", false) == 0)
			{
				((Control)btnBillOrnaIsu).Visible = true;
			}
			if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY OP_DATE DESC ";
			}
			else
			{
				DC_Main.RsQry = "SELECT * FROM YEAR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR > '" + DC_Main.MCo_year + "' ORDER BY CO_YEAR ";
			}
			DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)
				{
					tYearCode.Text = Conversions.ToString(Operators.ConcatenateObject((object)Strings.Mid(Conversions.ToString(DC_Main.Rshlp.Rows[0]["CO_YEAR"]), 1, 4), DC_Main.Rshlp.Rows[0]["YEAR_MONTH"]));
				}
				else
				{
					tYearCode.Text = Conversions.ToString(DC_Main.Rshlp.Rows[0]["CO_YEAR"]);
				}
				mTrfr_dt = Conversions.ToDate(DC_Main.Rshlp.Rows[0]["OP_DATE"]);
			}
			DC_Main.Rshlp.Clear();
		}
	}

	private void MS_BAL_TRFR_Activated(object sender, EventArgs e)
	{
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(tYearCode.Text, "", false) != 0)
		{
			if (Operators.CompareString(DC_Main.MsAlterYear, "Y", false) == 0)
			{
				TrfrMdbName = "Next" + Strings.Mid(tYearCode.Text, 3, 4);
			}
			else if (Operators.CompareString(DC_Main.MCo_Type, "P", false) == 0)
			{
				TrfrMdbName = "NxAc" + Strings.Mid(tYearCode.Text, 3, 2);
			}
			else if (Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0)
			{
				TrfrMdbName = "NxAb" + Strings.Mid(tYearCode.Text, 3, 2);
			}
			else
			{
				TrfrMdbName = "Next" + Strings.Mid(tYearCode.Text, 3, 2);
			}
			if (Operators.CompareString(DC_Main.LinkType, "W", false) == 0)
			{
				DC_Main.CnTr.ConnectionString = "Data Source=" + DC_Main.SqlServer + ";Initial Catalog=" + TrfrMdbName + ";Integrated Security=True";
			}
			else
			{
				DC_Main.CnTr.ConnectionString = ("Data Source=" + DC_Main.SqlServer + ";Initial Catalog=" + TrfrMdbName + ";Persist Security Info=True;User ID=" + DC_Main.SqlId + ";Password=" + DC_Main.SqlPwd) ?? "";
			}
		}
		else
		{
			Interaction.MsgBox((object)"There Are Not Found New Year Please Creat New Year And Try....", (MsgBoxStyle)0, (object)null);
		}
	}

	public DataTable OpenRecordSetTrFr(string sql)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		DC_Main.NewTbl = new DataTable();
		DC_Main.Da = new SqlDataAdapter(sql, DC_Main.CnTr);
		((DbDataAdapter)(object)DC_Main.Da).Fill(DC_Main.NewTbl);
		return DC_Main.NewTbl;
	}

	public void ExeQuteTrfr(string Sql)
	{
		if (DC_Main.CnTr.State == ConnectionState.Open)
		{
			DC_Main.CnTr.Close();
		}
		DC_Main.CnTr.Open();
		DC_Main.Cmd.Connection = DC_Main.CnTr;
		DC_Main.Cmd.CommandText = Sql;
		DC_Main.Cmd.ExecuteNonQuery();
		DC_Main.CnTr.Close();
	}

	private void BtnTagStock_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Data Transfer to Next Year ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			lblBook.Text = "Tag Import";
			((Control)ProgressBar1).Visible = true;
			Rtl_Item();
			Rtl_BarData();
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
			ProgressBar1.Value = 0;
		}
	}

	private void Rtl_Item()
	{
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = 4;
		lblBook.Text = "Item Master";
		Application.DoEvents();
		DC_Main.RsQry = "SELECT * FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT PR_CODE FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["PR_CODE"]), (object)"'"));
				TrFrData = OpenRecordSetTrFr(DC_Main.RsQry);
				if (TrFrData.Rows.Count == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO PRODUCT_MAST(CO_CODE,PR_CODE,PR_NAME,MAIN_USER) VALUES  ('" + DC_Main.MCo_code + "','"), DC_Main.Rshlp.Rows[DC_Main.M]["PR_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["PR_NAME"]), (object)"','"), (object)DC_Main.MCo_User), (object)"' ) "));
					OpenRecordSetTrFr(DC_Main.RsQry);
				}
				DC_Main.M++;
			}
			TrFrData.Clear();
			TrFrData.Columns.Clear();
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
			ProgressBar progressBar;
			(progressBar = ProgressBar1).Value = progressBar.Value + 1;
			DC_Main.RsQry = "SELECT * FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT GR_CODE FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["GR_CODE"]), (object)"'"));
				TrFrData = OpenRecordSetTrFr(DC_Main.RsQry);
				if (TrFrData.Rows.Count == 0)
				{
					object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO GROUP_MAST(CO_CODE,GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,  GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_USER,TAX_PRC,AVG_TOUCH,AVG_FINE,AVG_NWT) VALUES  ('", DC_Main.Rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["GR_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["GR_NAME"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["GR_TYPE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["TRAD_TYPE"]), (object)"',");
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["GR_TOUCH"]);
					double num = DC_Main.Fnv(ref Value);
					dataRow["GR_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num), (object)",0,");
					Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["MELTING_PRC"]);
					double num2 = DC_Main.Fnv(ref Value);
					dataRow["MELTING_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)", "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["GR_RATE"]);
					double num3 = DC_Main.Fnv(ref Value);
					dataRow["GR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num3), (object)",0,'"), DC_Main.Rshlp.Rows[DC_Main.M]["SALE_AC"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["PURC_AC"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["HSN_CODE"]), (object)"','"), (object)DC_Main.MCo_User), (object)"',0,0,0,0 )"));
					OpenRecordSetTrFr(DC_Main.RsQry);
				}
				DC_Main.M++;
			}
			TrFrData.Clear();
			TrFrData.Columns.Clear();
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
			(progressBar = ProgressBar1).Value = progressBar.Value + 1;
			DC_Main.RsQry = "SELECT * FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT TABLE_CODE FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TABLE_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["TABLE_CODE"]), (object)"'"));
				TrFrData = OpenRecordSetTrFr(DC_Main.RsQry);
				if (TrFrData.Rows.Count == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO TABLE_MAST(CO_CODE,LC_CODE,TABLE_CODE,TABLE_NAME,MAIN_USER) VALUES  ('", DC_Main.Rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["TABLE_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["TABLE_NAME"]), (object)"','"), (object)DC_Main.MCo_User), (object)"')"));
					OpenRecordSetTrFr(DC_Main.RsQry);
				}
				DC_Main.M++;
			}
			TrFrData.Clear();
			TrFrData.Columns.Clear();
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
			(progressBar = ProgressBar1).Value = progressBar.Value + 1;
			DC_Main.RsQry = "SELECT * FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT IT_CODE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
				TrFrData = OpenRecordSetTrFr(DC_Main.RsQry);
				if (TrFrData.Rows.Count == 0)
				{
					object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO ITEM_MAST(CO_CODE,IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,RATE_TYPE,HSN_CODE,  ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,MIN_STK,AVG_TOUCH,AVG_FINE,AVG_NWT,AC_ITEM,MAIN_USER) VALUES  ('", DC_Main.Rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["IT_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["IT_NAME"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["IT_TYPE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["TAG_TYPE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["PR_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["GR_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["TRAD_TYPE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["UNIT_NAME"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["RATE_TYPE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["HSN_CODE"]), (object)"', "), (object)" ");
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["ITEM_RATE"]);
					double num4 = DC_Main.Fnv(ref Value);
					dataRow["ITEM_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num4), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["LBR_PRC"]);
					double num5 = DC_Main.Fnv(ref Value);
					dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num5), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["CON_PRC"]);
					double num6 = DC_Main.Fnv(ref Value);
					dataRow["CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj7 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num6), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["DISC_PRC"]);
					double num7 = DC_Main.Fnv(ref Value);
					dataRow["DISC_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj8 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, (object)num7), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["IT_TOUCH"]);
					double num8 = DC_Main.Fnv(ref Value);
					dataRow["IT_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj9 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj8, (object)num8), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["IT_WEST"]);
					double num9 = DC_Main.Fnv(ref Value);
					dataRow["IT_WEST"] = RuntimeHelpers.GetObjectValue(Value);
					object obj10 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj9, (object)num9), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["OTHER_RATE"]);
					double num10 = DC_Main.Fnv(ref Value);
					dataRow["OTHER_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj11 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj10, (object)num10), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["MIN_STK"]);
					double num11 = DC_Main.Fnv(ref Value);
					dataRow["MIN_STK"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj11, (object)num11), (object)",0,0,0,'"), DC_Main.Rshlp.Rows[DC_Main.M]["IT_CODE"]), (object)"','"), (object)DC_Main.MCo_User), (object)"')"));
					OpenRecordSetTrFr(DC_Main.RsQry);
				}
				DC_Main.M++;
			}
			TrFrData.Clear();
			TrFrData.Columns.Clear();
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
			(progressBar = ProgressBar1).Value = progressBar.Value + 1;
		}
	}

	private void Rtl_BarData()
	{
		ExeQuteTrfr("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)mTrfr_dt.AddDays(-1.0), "MM/dd/yyyy") + "'");
		ExeQuteTrfr("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)mTrfr_dt.AddDays(-1.0), "MM/dd/yyyy") + "'");
		ExeQuteTrfr("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)mTrfr_dt.AddDays(-1.0), "MM/dd/yyyy") + "'");
		string text = "00001";
		string text2 = "00000";
		string text3 = "00000";
		DC_Main.RsQry = "SELECT B.IT_TYPE,A.IT_CODE FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND TAG_NO <> 'N' GROUP BY B.IT_TYPE,A.IT_CODE ORDER BY B.IT_TYPE,A.IT_CODE ";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = dataTable.Rows.Count;
		lblBook.Text = "Tag Transfer";
		DC_Main.RsQry = "SELECT VCH_NO AS CoCode  From BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tYearCode.Text + "' and CO_BOOK = '000' ORDER BY VCH_NO";
		DC_Main.Rshlp = OpenRecordSetTrFr(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			text2 = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])), "00000");
		}
		DC_Main.RsQry = "SELECT MAX((VCH_NO)) AS CoCode  From BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tYearCode.Text + "' and CO_BOOK = '000' HAVING MAX((VCH_NO)) > 0";
		DC_Main.Rshlp = OpenRecordSetTrFr(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			text3 = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["CoCode"])) + 1.0), "00000");
		}
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < dataTable.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND IT_CODE = '"), dataTable.Rows[DC_Main.M]["IT_CODE"]), (object)"' ORDER BY VCH_TIME DESC,TAG_NO DESC"));
				DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable2.Rows.Count > 0)
				{
					DataView dataView = new DataView(dataTable2);
					if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.TAG_NO ,A.IT_CODE,C.VCH_SRNO  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE   WHERE A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND C.IT_CODE = '"), dataTable.Rows[DC_Main.M]["IT_CODE"]), (object)"' And A.TAG_NO <> 'N' AND C.VCH_DATE <= '"), (object)Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy")), (object)"'"));
						DC_Main.RsQry += " GROUP BY A.TAG_NO,A.IT_CODE,C.VCH_SRNO ";
						DC_Main.RsQry += " HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO";
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.CO_CODE As CoCode,C.VCH_TYPE As VchTyp,C.VCH_NO VchNo,C.STK_DATE As StkDate,C.TAG_NO,A.IT_CODE As ItCode,C.TBL_CODE As Counter,C.DESIGN_NO As Design,C.ITM_SIZE As Size,1 As Qty,C.ITM_PCS as Pcs,C.ITM_GWT As Grwt,C.ITM_NWT AS NetWt,C.LBR_RATE As LbrRate,C.LBR_PRC As Lbrprc,C.LBR_AMT AS LbrAmt,C.OTH_AMT As OthAmt,  C.KR_COST As PrCost,C.ITM_MRP As Mrp,C.KR_NAME As KrName,C.CO_BOOK As Book,C.BOOK_NAME As BookName,C.AC_CODE As AcCode,C.VCH_SRNO  from (MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  And A.TAG_NO = C.TAG_NO And A.VCH_SRNO = C.VCH_SRNO And A.IT_CODE = C.IT_CODE)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'  AND A.TAG_NO <> 'N' AND A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "' AND A.IT_CODE = '"), dataTable.Rows[DC_Main.M]["IT_CODE"]), (object)"' "), (object)" GROUP BY C.CO_CODE,C.VCH_TYPE,C.VCH_NO,C.STK_DATE,C.TAG_NO,A.IT_CODE,C.TBL_CODE,C.DESIGN_NO,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.ITM_NWT,C.LBR_RATE,C.LBR_PRC,C.LBR_AMT,C.OTH_AMT, "), (object)" C.KR_COST,C.ITM_MRP,C.KR_NAME,C.CO_BOOK,C.BOOK_NAME,C.AC_CODE,C.VCH_SRNO "), (object)" HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY C.TAG_NO"));
					}
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.i = 0;
					int num = 0;
					while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
					{
						if (Operators.CompareString(text2, text, false) == 0)
						{
							text = text3;
						}
						num++;
						dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"TAG_NO = '", DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"]), (object)""));
						DataView dataView2 = dataView;
						if (dataView.Count > 0)
						{
							object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,  TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,  ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,  KR_NAME,KR_OTH_WT,KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,  KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,TAG_SRNO,VCH_SRNO,RATE_TYPE,IT_TYPE,  TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,ORD_AC,MAIN_USER,ADD_USER,DATA_TRFR,  HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,HM_ID,HM_ID2,HM_ID3,HM_ID4,  HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,DATA_TYPE,APP_TRFR,ITM_COLOR,  MAIN_MARGIN_PRC,MAIN_MRP,JDT_JDT_WT,JDT_GHT_WT,JDT_KUN_WT,JDT_WAX_WT,KR_WAX_WT,JDT_KUN_TOUCH,JDT_KUN_NET,EMP_ISU,LBR_CODE,DESIGN_IMG_ID, SL_TYPE,KR_OTH_RATE,KR_OTH_FINE,KR_TOT_FINE,KR_GWT_TOUCH,ITM_STYLE,ORD_LC_CODE,MFG_YRCD,MFG_DBCD,MFG_NO,MFG_SRNO) VALUES  ('", dataView2[0]["CO_CODE"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), (object)tYearCode.Text), (object)"','000','"), (object)text), (object)"',"), (object)num), (object)","), (object)num), (object)", "), (object)" '"), (object)Strings.Format((object)mTrfr_dt.AddDays(-1.0), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["STK_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataView2[0]["STK_DATE"]), "MM/dd/yyyy")), (object)"','"), dataView2[0]["VCH_TYPE"]), (object)"','I','O','"), dataView2[0]["BOOK_NAME"]), (object)"','"), dataView2[0]["AC_CODE"]), (object)"','"), dataView2[0]["IT_CODE"]), (object)"', "), (object)" '"), dataView2[0]["TAG_NO"]), (object)"','','"), dataView2[0]["DESIGN_NO"]), (object)"','"), dataView2[0]["TBL_CODE"]), (object)"','"), dataView2[0]["ITM_SIZE"]), (object)"',");
							DataRowView dataRowView;
							object Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_PCS"]);
							double num2 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_PCS"] = RuntimeHelpers.GetObjectValue(Value);
							object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num2), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["BAG_WT"], (object)"");
							object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["ITM_GWT"], (object)"");
							object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["ITM_OTH_WT"], (object)"");
							object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["ITM_NWT"], (object)"");
							object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)DC_Main.Fnv(ref Value)), (object)", "), (object)" ");
							Value = Operators.ConcatenateObject(dataView2[0]["ITM_GHT_PRC"], (object)"");
							object obj7 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["ITM_GHT_WT"], (object)"");
							object obj8 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["ITM_TOUCH"], (object)"");
							object obj9 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj8, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["ITM_WEST_PRC"], (object)"");
							object obj10 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj9, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["ITM_FINE"], (object)"");
							object obj11 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj10, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["LBR_PRC"], (object)"");
							object obj12 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj11, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["LBR_RATE"], (object)"");
							object obj13 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj12, (object)DC_Main.Fnv(ref Value)), (object)",'"), dataView2[0]["LBR_TYPE"]), (object)"', "), (object)" ");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["LBR_AMT"]);
							double num3 = DC_Main.Fnv(ref Value);
							dataRowView["LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj14 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj13, (object)num3), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["OTH_AMT"]);
							double num4 = DC_Main.Fnv(ref Value);
							dataRowView["OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj15 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj14, (object)num4), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_RATE"]);
							double num5 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj16 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj15, (object)num5), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_AMT"]);
							double num6 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj17 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj16, (object)num6), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["TAG_COST"]);
							double num7 = DC_Main.Fnv(ref Value);
							dataRowView["TAG_COST"] = RuntimeHelpers.GetObjectValue(Value);
							object obj18 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj17, (object)num7), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_MARGIN"]);
							double num8 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_MARGIN"] = RuntimeHelpers.GetObjectValue(Value);
							object obj19 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj18, (object)num8), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["ITM_MRP"]);
							double num9 = DC_Main.Fnv(ref Value);
							dataRowView["ITM_MRP"] = RuntimeHelpers.GetObjectValue(Value);
							object obj20 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj19, (object)num9), (object)",'"), dataView2[0]["ITM_REMARK"]), (object)"','"), dataView2[0]["SF_NO"]), (object)"', "), (object)" '"), dataView2[0]["KR_NAME"]), (object)"',");
							Value = Operators.ConcatenateObject(dataView2[0]["KR_OTH_WT"], (object)"");
							object obj21 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj20, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["KR_NET_WT"], (object)"");
							object obj22 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj21, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["KR_GHT_PRC"], (object)"");
							object obj23 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj22, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_GHT_WT"]);
							double num10 = DC_Main.Fnv(ref Value);
							dataRowView["KR_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj24 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj23, (object)num10), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_TOUCH"]);
							double num11 = DC_Main.Fnv(ref Value);
							dataRowView["KR_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
							object obj25 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj24, (object)num11), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_WEST_PRC"]);
							double num12 = DC_Main.Fnv(ref Value);
							dataRowView["KR_WEST_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							object obj26 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj25, (object)num12), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_FINE"]);
							double num13 = DC_Main.Fnv(ref Value);
							dataRowView["KR_FINE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj27 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj26, (object)num13), (object)", "), (object)" ");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_LBR_RATE"]);
							double num14 = DC_Main.Fnv(ref Value);
							dataRowView["KR_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj28 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj27, (object)num14), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_LBR_AMT"]);
							double num15 = DC_Main.Fnv(ref Value);
							dataRowView["KR_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj29 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj28, (object)num15), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_OTH_AMT"]);
							double num16 = DC_Main.Fnv(ref Value);
							dataRowView["KR_OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj30 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj29, (object)num16), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRowView = dataView2[0])["KR_COST"]);
							double num17 = DC_Main.Fnv(ref Value);
							dataRowView["KR_COST"] = RuntimeHelpers.GetObjectValue(Value);
							object obj31 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj30, (object)num17), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["TAG_SRNO"], (object)"");
							object obj32 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj31, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["VCH_SRNO"], (object)"");
							object obj33 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj32, (object)DC_Main.Fnv(ref Value)), (object)",'"), dataView2[0]["RATE_TYPE"]), (object)"','"), dataView2[0]["IT_TYPE"]), (object)"', "), (object)" '"), dataView2[0]["TAG_TYPE"]), (object)"','"), dataView2[0]["PR_CODE"]), (object)"','N','"), dataView2[0]["ORD_NO"]), (object)"',");
							Value = Operators.ConcatenateObject(dataView2[0]["ORD_SRNO"], (object)"");
							object obj34 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj33, (object)DC_Main.Fnv(ref Value)), (object)",'"), dataView2[0]["ORD_YRCD"]), (object)"','"), dataView2[0]["ORD_DBCD"]), (object)"','"), dataView2[0]["ORD_AC"]), (object)"','"), (object)DC_Main.MCo_User), (object)"','"), (object)DC_Main.MCo_User), (object)"','N', "), (object)" '"), (object)text), (object)"','"), dataView2[0]["OLD_VCH_NO"]), (object)"','"), dataView2[0]["NEW_VCH_NO"]), (object)"','"), dataView2[0]["HM_ID"]), (object)"','"), dataView2[0]["HM_ID2"]), (object)"','"), dataView2[0]["HM_ID3"]), (object)"','"), dataView2[0]["HM_ID4"]), (object)"', "), (object)" ");
							Value = Operators.ConcatenateObject(dataView2[0]["HM_ID_WT"], (object)"");
							object obj35 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj34, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["HM_ID2_WT"], (object)"");
							object obj36 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj35, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["HM_ID3_WT"], (object)"");
							object obj37 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj36, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["HM_ID4_WT"], (object)"");
							object obj38 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj37, (object)DC_Main.Fnv(ref Value)), (object)",'"), dataView2[0]["DATA_TYPE"]), (object)"','"), dataView2[0]["APP_TRFR"]), (object)"','"), dataView2[0]["ITM_COLOR"]), (object)"', "), (object)" ");
							Value = Operators.ConcatenateObject(dataView2[0]["MAIN_MARGIN_PRC"], (object)"");
							object obj39 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj38, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["MAIN_MRP"], (object)"");
							object obj40 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj39, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["JDT_JDT_WT"], (object)"");
							object obj41 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj40, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["JDT_GHT_WT"], (object)"");
							object obj42 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj41, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["JDT_KUN_WT"], (object)"");
							object obj43 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj42, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["JDT_WAX_WT"], (object)"");
							object obj44 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj43, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["KR_WAX_WT"], (object)"");
							object obj45 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj44, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["JDT_KUN_TOUCH"], (object)"");
							object obj46 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj45, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["JDT_KUN_NET"], (object)"");
							object obj47 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj46, (object)DC_Main.Fnv(ref Value)), (object)",'"), dataView2[0]["EMP_ISU"]), (object)"','"), dataView2[0]["LBR_CODE"]), (object)"','"), dataView2[0]["DESIGN_IMG_ID"]), (object)"', "), (object)" '"), dataView2[0]["SL_TYPE"]), (object)"',");
							Value = Operators.ConcatenateObject(dataView2[0]["KR_OTH_RATE"], (object)"");
							object obj48 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj47, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["KR_OTH_FINE"], (object)"");
							object obj49 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj48, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["KR_TOT_FINE"], (object)"");
							object obj50 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj49, (object)DC_Main.Fnv(ref Value)), (object)",");
							Value = Operators.ConcatenateObject(dataView2[0]["KR_GWT_TOUCH"], (object)"");
							object obj51 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj50, (object)DC_Main.Fnv(ref Value)), (object)",'"), dataView2[0]["ITM_STYLE"]), (object)"','"), dataView2[0]["ORD_LC_CODE"]), (object)"','"), dataView2[0]["MFG_YRCD"]), (object)"','"), dataView2[0]["MFG_DBCD"]), (object)"','"), dataView2[0]["MFG_NO"]), (object)"',");
							Value = Operators.ConcatenateObject(dataView2[0]["MFG_SRNO"], (object)"");
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj51, (object)DC_Main.Fnv(ref Value)), (object)")"));
							ExeQuteTrfr(DC_Main.RsQry);
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_TYPE FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"]), (object)" ORDER BY A.ISR_NO "));
							dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.R = 0;
							while (DC_Main.R < dataTable2.Rows.Count)
							{
								object obj52 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,  DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,  IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER,  DM_NAME,DM_ORIGIN,DM_REMARK,DM_COLOR,KR_ACT_WT,KR_ACT_PRC,KR_RATE_TYPE,IT_DISC_PRC,IT_DISC_AMT) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + tYearCode.Text + "','000','" + text + "'," + Conversions.ToString(num) + "," + Conversions.ToString(DC_Main.R + 1) + ",'" + Strings.Format((object)mTrfr_dt.AddDays(-1.0), "MM/dd/yyyy") + "',  '"), dataTable2.Rows[DC_Main.R]["VCH_TYPE"]), (object)"','I','O','"), dataTable2.Rows[DC_Main.R]["BOOK_NAME"]), (object)"','"), dataTable2.Rows[DC_Main.R]["AC_CODE"]), (object)"','"), dataTable2.Rows[DC_Main.R]["TAG_NO"]), (object)"',"), dataTable2.Rows[DC_Main.R]["VCH_SRNO"]), (object)",'"), dataTable2.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), dataTable2.Rows[DC_Main.R]["IT_TYPE"]), (object)"', "), (object)" '"), dataTable2.Rows[DC_Main.R]["DM_CODE"]), (object)"','"), dataTable2.Rows[DC_Main.R]["DM_SIZE"]), (object)"','"), dataTable2.Rows[DC_Main.R]["DM_SFNO"]), (object)"','"), dataTable2.Rows[DC_Main.R]["DM_LEB"]), (object)"',");
								DataRow dataRow;
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_PCS"]);
								double num18 = DC_Main.Fnv(ref Value);
								dataRow["IT_PCS"] = RuntimeHelpers.GetObjectValue(Value);
								object obj53 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj52, (object)num18), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_PCS_WT"]);
								double num19 = DC_Main.Fnv(ref Value);
								dataRow["IT_PCS_WT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj54 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj53, (object)num19), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_WT"]);
								double num20 = DC_Main.Fnv(ref Value);
								dataRow["KR_WT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj55 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj54, (object)num20), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_LESS_PRC"]);
								double num21 = DC_Main.Fnv(ref Value);
								dataRow["KR_LESS_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								object obj56 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj55, (object)num21), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_GWT"]);
								double num22 = DC_Main.Fnv(ref Value);
								dataRow["IT_GWT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj57 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj56, (object)num22), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_CON_PRC"]);
								double num23 = DC_Main.Fnv(ref Value);
								dataRow["IT_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								object obj58 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj57, (object)num23), (object)", "), (object)" ");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_CON_WT"]);
								double num24 = DC_Main.Fnv(ref Value);
								dataRow["IT_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj59 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj58, (object)num24), (object)",'"), dataTable2.Rows[DC_Main.R]["IT_RATE_TYPE"]), (object)"',");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_RATE"]);
								double num25 = DC_Main.Fnv(ref Value);
								dataRow["IT_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj60 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj59, (object)num25), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_AMT"]);
								double num26 = DC_Main.Fnv(ref Value);
								dataRow["IT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj61 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj60, (object)num26), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_LBR_RATE"]);
								double num27 = DC_Main.Fnv(ref Value);
								dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj62 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj61, (object)num27), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_LBR_AMT"]);
								double num28 = DC_Main.Fnv(ref Value);
								dataRow["IT_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj63 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj62, (object)num28), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_NET_AMT"]);
								double num29 = DC_Main.Fnv(ref Value);
								dataRow["IT_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj64 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj63, (object)num29), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_CON_PRC"]);
								double num30 = DC_Main.Fnv(ref Value);
								dataRow["KR_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								object obj65 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj64, (object)num30), (object)", "), (object)" ");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_CON_WT"]);
								double num31 = DC_Main.Fnv(ref Value);
								dataRow["KR_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj66 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj65, (object)num31), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_RATE"]);
								double num32 = DC_Main.Fnv(ref Value);
								dataRow["KR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj67 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj66, (object)num32), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_AMT"]);
								double num33 = DC_Main.Fnv(ref Value);
								dataRow["KR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj68 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj67, (object)num33), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_LBR_RATE"]);
								double num34 = DC_Main.Fnv(ref Value);
								dataRow["KR_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj69 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj68, (object)num34), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_LBR_AMT"]);
								double num35 = DC_Main.Fnv(ref Value);
								dataRow["KR_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj70 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj69, (object)num35), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_NET_AMT"]);
								double num36 = DC_Main.Fnv(ref Value);
								dataRow["KR_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj71 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj70, (object)num36), (object)",'");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["MAIN_USER"]);
								double num37 = DC_Main.Fnv(ref Value);
								dataRow["MAIN_USER"] = RuntimeHelpers.GetObjectValue(Value);
								object obj72 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj71, (object)num37), (object)"', "), (object)" '"), dataTable2.Rows[DC_Main.R]["DM_NAME"]), (object)"','"), dataTable2.Rows[DC_Main.R]["DM_ORIGIN"]), (object)"','"), dataTable2.Rows[DC_Main.R]["DM_REMARK"]), (object)"','"), dataTable2.Rows[DC_Main.R]["DM_COLOR"]), (object)"',");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_ACT_WT"]);
								double num38 = DC_Main.Fnv(ref Value);
								dataRow["KR_ACT_WT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj73 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj72, (object)num38), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_ACT_PRC"]);
								double num39 = DC_Main.Fnv(ref Value);
								dataRow["KR_ACT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								object obj74 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj73, (object)num39), (object)",'"), dataTable2.Rows[DC_Main.R]["KR_RATE_TYPE"]), (object)"',");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_DISC_PRC"]);
								double num40 = DC_Main.Fnv(ref Value);
								dataRow["IT_DISC_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								object obj75 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj74, (object)num40), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_DISC_AMT"]);
								double num41 = DC_Main.Fnv(ref Value);
								dataRow["IT_DISC_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj75, (object)num41), (object)")"));
								OpenRecordSetTrFr(DC_Main.RsQry);
								DC_Main.R++;
							}
						}
						dataView2 = null;
						DC_Main.i++;
					}
					if (num > 0)
					{
						DC_Main.RsQry = "INSERT INTO BAR_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE, AC_CODE,CUST_AC,OP_STK,VCH_TIME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + tYearCode.Text + "','000','" + text + "','" + Strings.Format((object)mTrfr_dt.AddDays(-1.0), "MM/dd/yyyy") + "','','','Y','" + Strings.Format((object)mTrfr_dt.AddDays(-1.0), "MM/dd/yyyy") + "')";
						ExeQuteTrfr(DC_Main.RsQry);
						text = Strings.Format((object)(Conversion.Val(text) + 1.0), "00000");
						num = 0;
					}
				}
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
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
			else if (val is MaskedTextBox)
			{
				val.Text = DC_Main.MMask;
			}
		}
		MainUser = DC_Main.MCo_User;
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void MS_BAL_TRFR_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_BAL_TRFR_KeyPress(object sender, KeyPressEventArgs e)
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

	private void MS_BAL_TRFR_KeyDown(object sender, KeyEventArgs e)
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

	private void MS_BAL_TRFR_Closed(object sender, EventArgs e)
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

	private void BtnDelete_Click(object sender, EventArgs e)
	{
	}

	private void BtnAcBalence_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Data Transfer to Next Year ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		DC_Main.RsQry = "UPDATE A SET A.AC_MAIN_GR = B.AC_MAIN_GR FROM AC_MAST AS A,AC_GROUP AS B WHERE A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR AND A.CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT A.AC_CODE,(SELECT TOP(1) VCH_DATE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = A.AC_CODE ORDER BY VCH_DATE DESC) As VchDate,(SELECT TOP(1) CO_BOOK FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = A.AC_CODE ORDER BY VCH_DATE DESC) As CoBook FROM AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR IN ('04','15','05','10','20') ORDER BY A.AC_CODE DESC";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.X = 0;
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				int num = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["CoBook"])))
					{
						OpenRecordSetTrFr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE AC_MAST SET LAST_VISIT = '" + Strings.Format((object)Conversions.ToDate(DC_Main.Rshlp.Rows[DC_Main.X]["VchDate"]), "MM/dd/yyyy") + "',VISIT_TRAN = '"), DC_Main.Rshlp.Rows[DC_Main.X]["CoBook"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND  AC_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.X]["AC_CODE"]), (object)"'")));
					}
					DC_Main.X++;
				}
			}
			Rtl_AcMast();
			Rtl_AcOpbl();
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
		}
	}

	private void Rtl_AcOpbl()
	{
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Invalid comparison between Unknown and I4
		DC_Main.ExeQuteDc("UPDATE AC_MAST SET AC_MAST.AC_MAIN_GR = B.AC_MAIN_GR FROM AC_MAST,AC_GROUP AS B WHERE AC_MAST.CO_CODE = B.CO_CODE AND AC_MAST.AC_GR = B.AC_GR AND AC_MAST.CO_CODE = '" + DC_Main.MCo_code + "' AND AC_MAST.LC_CODE = '" + DC_Main.MLc_code + "' AND AC_MAST.AC_MAIN_GR <> B.AC_MAIN_GR");
		ExeQuteTrfr("DELETE FROM OP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ");
		DC_Main.ExeQuteDc("UPDATE AC_DATA SET DATA_TYPE = 'A' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND (DATA_TYPE IS NULL OR DATA_TYPE = '') ");
		if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
		{
			if (Operators.CompareString(DC_Main.MsDataType, "C", false) == 0)
			{
				if ((int)Interaction.MsgBox((object)"A And B Data Merge Transfer...", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
				{
					DC_Main.RsQry = "Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,'A' As DataType,format(Sum(A.CR_AMT-A.DR_AMT),'0.00') as Amount,format(SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as GoldWt,format(sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as SilverWt  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.AC_MAIN_GR < '3' and VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "'   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))+sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))+sum(iif(A.IT_TYPE = 'D',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))) <> 0 ORDER BY B.AC_NAME ";
				}
				else
				{
					DC_Main.RsQry = "Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE As DataType,format(Sum(A.CR_AMT-A.DR_AMT),'0.00') as Amount,format(SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as GoldWt,format(sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as SilverWt  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.AC_MAIN_GR < '3' and VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "'   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))+sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))+sum(iif(A.IT_TYPE = 'D',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))) <> 0 ORDER BY B.AC_NAME ";
				}
			}
			else
			{
				DC_Main.RsQry = "Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE As DataType,format(Sum(A.CR_AMT-A.DR_AMT),'0.00') as Amount,format(SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as GoldWt,format(sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as SilverWt  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.AC_MAIN_GR < '3' and VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "'   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))+sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))+sum(iif(A.IT_TYPE = 'D',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))) <> 0 ORDER BY B.AC_NAME ";
			}
		}
		else
		{
			DC_Main.RsQry = "Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE As DataType,format(Sum(A.CR_AMT-A.DR_AMT),'0.00') as Amount,format(SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as GoldWt,format(sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as SilverWt  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.AC_MAIN_GR < '3' and VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "'   GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,A.DATA_TYPE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))+sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))+sum(iif(A.IT_TYPE = 'D',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))) <> 0 ORDER BY B.AC_NAME ";
		}
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Party Opning";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				if (Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["Amount"]))) + Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["GoldWt"]))) + Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["SilverWt"]))) != 0.0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO OP_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,  OP_AMT,OP_SIGN,FINE_BAL,FINE_SIGN,SL_FINE_BAL,SL_FINE_SIGN,  DATA_TYPE,MAIN_USER,ADD_USER,ADD_DATE,DATA_TRFR) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + tYearCode.Text + "','000','00000','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"', "), (object)" "), (object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["Amount"])))), (object)","), Interaction.IIf(Operators.ConditionalCompareObjectGreater(rshlp.Rows[DC_Main.M]["Amount"], (object)0, false), (object)"'C'", (object)"'D'")), (object)","), (object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["GoldWt"])))), (object)","), Interaction.IIf(Operators.ConditionalCompareObjectGreater(rshlp.Rows[DC_Main.M]["GoldWt"], (object)0, false), (object)"'C'", (object)"'D'")), (object)","), (object)Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["SilverWt"])))), (object)","), Interaction.IIf(Operators.ConditionalCompareObjectGreater(rshlp.Rows[DC_Main.M]["SilverWt"], (object)0, false), (object)"'C'", (object)"'D'")), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["DataType"]), (object)"','"), (object)DC_Main.MCo_User), (object)"','',NULL,'Y')"));
					OpenRecordSetTrFr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void Rtl_AcMast()
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		string text4 = "";
		DC_Main.M = 0;
		DC_Main.RsQry = "SELECT A.* FROM AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY AC_CODE";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT AC_CODE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		TrFrData = OpenRecordSetTrFr(DC_Main.RsQry);
		DataView dataView = new DataView(TrFrData);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		DC_Main.X = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Party Master";
		Application.DoEvents();
		checked
		{
			DateTime dateTime = default(DateTime);
			DateTime dateTime2 = default(DateTime);
			DateTime dateTime3 = default(DateTime);
			DateTime dateTime4 = default(DateTime);
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_CODE = ", rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)""));
				if (dataView.Count == 0)
				{
					text = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["AC_ADD1"], (object)""));
					int num = Strings.Len(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["AC_ADD1"], (object)""));
					DC_Main.R = 1;
					while (DC_Main.R <= num)
					{
						if (Operators.CompareString(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["AC_ADD1"], (object)"")), DC_Main.R, 1), "'", false) == 0)
						{
							text = "";
						}
						DC_Main.R++;
					}
					text2 = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["AC_ADD2"], (object)""));
					int num2 = Strings.Len(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["AC_ADD2"], (object)""));
					DC_Main.R = 1;
					while (DC_Main.R <= num2)
					{
						if (Operators.CompareString(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["AC_ADD2"], (object)"")), DC_Main.R, 1), "'", false) == 0)
						{
							text2 = "";
						}
						DC_Main.R++;
					}
					text3 = Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["AC_ADD3"], (object)""));
					int num3 = Strings.Len(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["AC_ADD3"], (object)""));
					DC_Main.R = 1;
					while (DC_Main.R <= num3)
					{
						if (Operators.CompareString(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["AC_ADD3"], (object)"")), DC_Main.R, 1), "'", false) == 0)
						{
							text3 = "";
						}
						DC_Main.R++;
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["BR_DATE"])))
					{
						dateTime = Conversions.ToDate(rshlp.Rows[DC_Main.M]["BR_DATE"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["L_BR_DATE"])))
					{
						dateTime2 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["L_BR_DATE"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["AN_DATE"])))
					{
						dateTime3 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["AN_DATE"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["LAST_DATE"])))
					{
						dateTime4 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["LAST_DATE"]);
					}
					object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO AC_MAST(CO_CODE,AC_CODE,LC_CODE,AC_NAME,AC_SHORT,AC_MAIN_GR,AC_GR,AC_PERSON,  AC_ADD1,AC_ADD2,AC_ADD3,AC_COUNTRY,AC_STATE,AC_DISTRICT,AC_CITY,AC_AREA,AC_PIN,AC_PHONE,AC_PHONE2,  AC_MOBILE,AC_MOBILE2,AC_EMAIL,AC_GSTNO,AC_GST_TYPE,AC_PANNO,AC_REF_CODE,AC_KHATA_NO,  BR_DATE,L_BR_DATE,AN_DATE,AC_CR_DAYS,AC_INT_PRC,DPC_PRC,BANK_NAME,BANK_AREA,BANK_AC_NO,  BANK_RTGS_NO,BANK_DETL,AC_TYPE,LAST_DATE,DATA_TRFR,MAIN_USER) VALUES  ('" + DC_Main.MCo_code + "','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"', '"), (object)DC_Main.MLc_code), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_SHORT"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_MAIN_GR"]), (object)"','"), (object)Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["AC_GR"], (object)"")), 1, 2)), (object)"','"), rshlp.Rows[DC_Main.M]["AC_PERSON"]), (object)"', "), (object)" '"), (object)text), (object)"','"), (object)text2), (object)"','"), (object)text3), (object)"','"), rshlp.Rows[DC_Main.M]["AC_COUNTRY"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_STATE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_DISTRICT"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CITY"]), (object)"','"), (object)Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["AC_AREA"], (object)"")), 1, 25)), (object)"','"), rshlp.Rows[DC_Main.M]["AC_PIN"]), (object)""), (object)"','"), (object)Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["AC_PHONE"], (object)"")), 1, 10)), (object)"','"), (object)Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["AC_PHONE2"], (object)"")), 1, 10)), (object)"', "), (object)" '"), (object)Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["AC_MOBILE"], (object)"")), 1, 11)), (object)"','"), (object)Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(rshlp.Rows[DC_Main.M]["AC_MOBILE2"], (object)"")), 1, 11)), (object)"','"), rshlp.Rows[DC_Main.M]["AC_EMAIL"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_GSTNO"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_GST_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_PANNO"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_REF_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_KHATA_NO"]), (object)"', "), (object)" "), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["BR_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["L_BR_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime2, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["AN_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime3, "MM/dd/yyyy") + "'"))), (object)",");
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["AC_CR_DAYS"]);
					double num4 = DC_Main.Fnv(ref Value);
					dataRow["AC_CR_DAYS"] = RuntimeHelpers.GetObjectValue(Value);
					object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num4), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["AC_INT_PRC"]);
					double num5 = DC_Main.Fnv(ref Value);
					dataRow["AC_INT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num5), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["DPC_PRC"]);
					double num6 = DC_Main.Fnv(ref Value);
					dataRow["DPC_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num6), (object)",'"), rshlp.Rows[DC_Main.M]["BANK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AREA"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_AC_NO"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["BANK_RTGS_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["BANK_DETL"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_TYPE"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["LAST_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime4, "MM/dd/yyyy") + "'"))), (object)",'N','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"') "));
					OpenRecordSetTrFr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
			TrFrData.Clear();
			TrFrData.Columns.Clear();
			DC_Main.M = 0;
		}
	}

	private void BtnItmStk_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_067f: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Data Transfer to Next Year ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		Rtl_Item();
		DC_Main.AvgTouch(DC_Main.MsSysDate, DC_Main.MLc_code);
		ExeQuteTrfr("DELETE FROM ITM_OPBL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
		DC_Main.RsQry = "SELECT A.IT_CODE AS Code,B.IT_NAME AS Name,B.IT_TYPE,B.GR_CODE,B.AVG_TOUCH,SUM(iif(ITM_SIGN = '+', ITM_PCS, -ITM_PCS)) AS ClPcs,SUM(iif(ITM_SIGN = '+',ITM_NWT,-ITM_NWT)) AS ClWt ,SUM(iif(ITM_SIGN = '+',ITM_GWT,-ITM_GWT)) AS ClWtGr,SUM(iif(ITM_SIGN = '+', (ITM_PCS*B.ITEM_RATE), -(ITM_PCS*B.ITEM_RATE))) AS ItAmt FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "' AND A.IT_CODE <> '' AND (A.TAG_NO = 'N' OR A.TAG_NO = '' OR A.TAG_NO IS NULL)  GROUP BY A.IT_CODE,B.IT_NAME,B.IT_TYPE,B.GR_CODE,B.AVG_TOUCH ORDER BY B.GR_CODE,A.IT_CODE ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Item Opning";
		Application.DoEvents();
		DC_Main.M = 0;
		while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
		{
			DataTable rshlp = DC_Main.Rshlp;
			double num = 0.0;
			DataRow dataRow;
			object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ClWt"]);
			double num2 = DC_Main.Fnv(ref Value);
			dataRow["ClWt"] = RuntimeHelpers.GetObjectValue(Value);
			bool num3 = num2 != 0.0;
			Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["AVG_TOUCH"]);
			double num4 = DC_Main.Fnv(ref Value);
			dataRow["AVG_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
			if (num3 && num4 != 0.0)
			{
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ClWt"]);
				double num5 = DC_Main.Fnv(ref Value);
				dataRow["ClWt"] = RuntimeHelpers.GetObjectValue(Value);
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["AVG_TOUCH"]);
				double num6 = DC_Main.Fnv(ref Value);
				dataRow["AVG_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
				num = Conversions.ToDouble(Strings.Format((object)Conversion.Val((object)(num5 * num6 / 100.0)), "0.000"));
			}
			checked
			{
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["ClWtGr"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["ClWt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["ClPcs"])) != 0.0)
				{
					object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO ITM_OPBL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,IT_CODE,VCH_NO,SR_NO,  ITM_PCS,ITM_GWT,ITM_NWT,ITM_TOUCH,ITM_FINE,ITM_RATE,ITM_AMT,LBR_AMT,OTH_AMT,  NET_AMT,DM_WT,DM_RATE,DM_AMT,MAIN_USER,LBR_RATE,DATA_TRFR,DATA_TYPE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + tYearCode.Text + "','000','"), rshlp.Rows[DC_Main.M]["Code"]), (object)"','"), rshlp.Rows[DC_Main.M]["IT_TYPE"]), (object)"',"), (object)(DC_Main.M + 1)), (object)", "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ClPcs"]);
					double num7 = DC_Main.Fnv(ref Value);
					dataRow["ClPcs"] = RuntimeHelpers.GetObjectValue(Value);
					object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)Strings.Format((object)num7, "0")), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ClWtGr"]);
					double num8 = DC_Main.Fnv(ref Value);
					dataRow["ClWtGr"] = RuntimeHelpers.GetObjectValue(Value);
					object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)Strings.Format((object)num8, "0.000")), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ClWt"]);
					double num9 = DC_Main.Fnv(ref Value);
					dataRow["ClWt"] = RuntimeHelpers.GetObjectValue(Value);
					object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)Strings.Format((object)num9, "0.000")), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["AVG_TOUCH"]);
					double num10 = DC_Main.Fnv(ref Value);
					dataRow["AVG_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num10), (object)","), (object)num), (object)",0,");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ItAmt"]);
					double num11 = DC_Main.Fnv(ref Value);
					dataRow["ItAmt"] = RuntimeHelpers.GetObjectValue(Value);
					object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num11), (object)",0,0, "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ItAmt"]);
					double num12 = DC_Main.Fnv(ref Value);
					dataRow["ItAmt"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num12), (object)",0,0,0,'"), (object)DC_Main.MCo_User), (object)"',0,'Y','A')"));
					OpenRecordSetTrFr(DC_Main.RsQry);
				}
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
		Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
	}

	private void BtnOrder_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Data Transfer to Next Year ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			Rtl_AcMast();
			Rtl_Order();
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
		}
	}

	private void Rtl_Order()
	{
		int num = 0;
		DC_Main.RsQry = "SELECT IT_CODE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY IT_CODE ";
		RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ExeQuteTrfr("DELETE FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
		ExeQuteTrfr("DELETE FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
		ExeQuteTrfr("DELETE FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
		DC_Main.RsQry = "SELECT A.AC_CODE,A.VCH_DATE,A.VCH_NO,A.ADV_AMT,SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_AMT ELSE 0 END) AS AdjAmount,SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_GOLD ELSE 0 END) AS AdjGold,  SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_SILVER ELSE 0 END) AS AdjSilver,A.CO_YEAR,A.CO_BOOK,A.HD_VCH_NO FROM SL_ORD_DATA AS A LEFT JOIN SL_ORD_ADJ AS B ON  A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC And A.CO_YEAR = B.ORD_YRCD And A.CO_BOOK = B.ORD_DBCD And A.VCH_NO = B.ORD_NO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "'  GROUP BY A.AC_CODE,A.VCH_DATE,A.VCH_NO,A.ADV_AMT,A.CO_YEAR,A.CO_BOOK,A.HD_VCH_NO HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END) + SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_GOLD ELSE - B.ORD_GOLD END) +SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_SILVER ELSE - B.ORD_SILVER END)  > 0  ORDER BY A.VCH_DATE,A.VCH_NO ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Sales Order";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			DateTime dateTime = default(DateTime);
			DateTime dateTime2 = default(DateTime);
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.BOOK_SNAME,B.MAIN_BOOK,B.BOOK_INOUT FROM SL_ORD_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' and A.CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' "));
				RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DataTable rsData = RsData;
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rsData.Rows[0]["DEL_DATE"])))
				{
					dateTime = Conversions.ToDate(rsData.Rows[0]["DEL_DATE"]);
				}
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rsData.Rows[0]["FUN_DATE"])))
				{
					dateTime2 = Conversions.ToDate(rsData.Rows[0]["FUN_DATE"]);
				}
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO SL_ORD_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,  BILL_NO,HD_VCH_NO,AC_CODE,AC_NAME,NET_AMT,TAX_CODE,TAX_PRC,TAX_AMT,TOT_AMT,ADV_AMT,  ORD_ADJ_AMT,OLD_GL_AMT,OLD_SL_AMT,CASH_AMT,CARD_AMT,CHQ_AMT,SCHM_AMT,DEL_DATE,  CARD_AC,BANK_AC,CHQ_NO,BANK_NAME,EMP_CODE,VCH_DESC,ENTRY_TIME,SL_BILL_TYPE,OLD_GL,  ADJ_GOLD,OLD_SL,ADJ_SILVER,CARD_ADJ,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,  ADD1,ADD2,ADD3,CITY,MOBILE,RCUT_AMT,MOB_ENTRY_SAVE,FUN_DATE,RCUT_RATE,RCUT_FINE,UPI_AMT) VALUES  ('", rsData.Rows[0]["CO_CODE"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), rsData.Rows[0]["CO_YEAR"]), (object)"','"), rsData.Rows[0]["CO_BOOK"]), (object)"','"), rsData.Rows[0]["VCH_NO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[0]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[0]["VCH_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), rsData.Rows[0]["BILL_NO"]), (object)"','"), rsData.Rows[0]["HD_VCH_NO"]), (object)"','"), rsData.Rows[0]["AC_CODE"]), (object)"','"), rsData.Rows[0]["AC_NAME"]), (object)"',");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["NET_AMT"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num2), (object)",'"), rsData.Rows[0]["TAX_CODE"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["TAX_PRC"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num3), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["TAX_AMT"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["TAX_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num4), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["TOT_AMT"]);
				double num5 = DC_Main.Fnv(ref Value);
				dataRow["TOT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num5), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["ADV_AMT"]);
				double num6 = DC_Main.Fnv(ref Value);
				dataRow["ADV_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num6), (object)", "), (object)" ");
				Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["AdjAmount"]);
				double num7 = DC_Main.Fnv(ref Value);
				dataRow["AdjAmount"] = RuntimeHelpers.GetObjectValue(Value);
				object obj7 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num7), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["OLD_GL_AMT"]);
				double num8 = DC_Main.Fnv(ref Value);
				dataRow["OLD_GL_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj8 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, (object)num8), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["OLD_SL_AMT"]);
				double num9 = DC_Main.Fnv(ref Value);
				dataRow["OLD_SL_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj9 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj8, (object)num9), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["CASH_AMT"]);
				double num10 = DC_Main.Fnv(ref Value);
				dataRow["CASH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj10 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj9, (object)num10), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["CARD_AMT"]);
				double num11 = DC_Main.Fnv(ref Value);
				dataRow["CARD_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj11 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj10, (object)num11), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["CHQ_AMT"]);
				double num12 = DC_Main.Fnv(ref Value);
				dataRow["CHQ_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj12 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj11, (object)num12), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["SCHM_AMT"]);
				double num13 = DC_Main.Fnv(ref Value);
				dataRow["SCHM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj13 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj12, (object)num13), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rsData.Rows[0]["DEL_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'"))), (object)", "), (object)" '"), rsData.Rows[0]["CARD_AC"]), (object)"','"), rsData.Rows[0]["BANK_AC"]), (object)"','"), rsData.Rows[0]["CHQ_NO"]), (object)"','"), rsData.Rows[0]["BANK_NAME"]), (object)"','"), rsData.Rows[0]["EMP_CODE"]), (object)"','"), rsData.Rows[0]["VCH_DESC"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[0]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["OLD_GL"]);
				double num14 = DC_Main.Fnv(ref Value);
				dataRow["OLD_GL"] = RuntimeHelpers.GetObjectValue(Value);
				object obj14 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj13, (object)num14), (object)", "), (object)" ");
				Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["AdjGold"]);
				double num15 = DC_Main.Fnv(ref Value);
				dataRow["AdjGold"] = RuntimeHelpers.GetObjectValue(Value);
				object obj15 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj14, (object)num15), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["OLD_SL"]);
				double num16 = DC_Main.Fnv(ref Value);
				dataRow["OLD_SL"] = RuntimeHelpers.GetObjectValue(Value);
				object obj16 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj15, (object)num16), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["AdjSilver"]);
				double num17 = DC_Main.Fnv(ref Value);
				dataRow["AdjSilver"] = RuntimeHelpers.GetObjectValue(Value);
				object obj17 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj16, (object)num17), (object)",'"), rsData.Rows[0]["CARD_ADJ"]), (object)"','"), rsData.Rows[0]["DATA_TRFR"]), (object)"','','','"), rsData.Rows[0]["MAIN_USER"]), (object)"', "), (object)" '"), rsData.Rows[0]["ADD1"]), (object)"','"), rsData.Rows[0]["ADD2"]), (object)"','"), rsData.Rows[0]["ADD3"]), (object)"','"), rsData.Rows[0]["CITY"]), (object)"','"), rsData.Rows[0]["MOBILE"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["RCUT_AMT"]);
				double num18 = DC_Main.Fnv(ref Value);
				dataRow["RCUT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj18 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj17, (object)num18), (object)",'"), rsData.Rows[0]["MOB_ENTRY_SAVE"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rsData.Rows[0]["FUN_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime2, "MM/dd/yyyy") + "'"))), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[0])["RCUT_RATE"]);
				double num19 = DC_Main.Fnv(ref Value);
				dataRow["RCUT_RATE"] = RuntimeHelpers.GetObjectValue(Value);
				object obj19 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj18, (object)num19), (object)",");
				Value = Operators.ConcatenateObject(rsData.Rows[0]["RCUT_FINE"], (object)"");
				object obj20 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj19, (object)DC_Main.Fnv(ref Value)), (object)",");
				Value = Operators.ConcatenateObject(rsData.Rows[0]["UPI_AMT"], (object)"");
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj20, (object)DC_Main.Fnv(ref Value)), (object)")"));
				OpenRecordSetTrFr(DC_Main.RsQry);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.BOOK_SNAME,B.MAIN_BOOK,B.BOOK_INOUT FROM SL_ORD_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' and A.CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY A.SR_NO"));
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < RsDetl.Rows.Count)
				{
					DataTable rsDetl = RsDetl;
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rsDetl.Rows[DC_Main.R]["ORD_DEL_DATE"])))
					{
						dateTime = Conversions.ToDate(rsDetl.Rows[DC_Main.R]["ORD_DEL_DATE"]);
					}
					object obj21 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO SL_ORD_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,  LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,ITM_REMARK,  VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE,  HD_VCH_NO,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,ADD_USER,DESIGN_ISU,TAG_GEN,TAG_SALE,ITM_GHT_PRC,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,  OLD_TBL_CODE,ITM_COLOR,ORD_DEL_DATE,ORD_REC_AMT,EMP_CODE,TAG_STK_LESS,RATE_FIX,DESIGN_IMG_ID) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), rsDetl.Rows[DC_Main.R]["CO_YEAR"]), (object)"','"), rsDetl.Rows[DC_Main.R]["CO_BOOK"]), (object)"','"), rsDetl.Rows[DC_Main.R]["VCH_NO"]), (object)"',"), rsDetl.Rows[DC_Main.R]["SR_NO"]), (object)","), rsDetl.Rows[DC_Main.R]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), rsDetl.Rows[DC_Main.R]["BOOK_SNAME"]), (object)"','"), rsDetl.Rows[DC_Main.R]["BOOK_INOUT"]), (object)"','O','"), rsDetl.Rows[DC_Main.R]["MAIN_BOOK"]), (object)"','"), rsDetl.Rows[DC_Main.R]["AC_CODE"]), (object)"','"), rsDetl.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), rsDetl.Rows[DC_Main.R]["TAG_NO"]), (object)"','','"), (object)Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(rsDetl.Rows[DC_Main.R]["DESIGN_NO"], (object)"")), 1, 15)), (object)"','','"), (object)Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(rsDetl.Rows[DC_Main.R]["ITM_SIZE"], (object)"")), 1, 15)), (object)"', "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_PCS"]);
					double num20 = DC_Main.Fnv(ref Value);
					dataRow["ITM_PCS"] = RuntimeHelpers.GetObjectValue(Value);
					object obj22 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj21, (object)num20), (object)",0,");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_GWT"]);
					double num21 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj23 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj22, (object)num21), (object)",0,");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_NWT"]);
					double num22 = DC_Main.Fnv(ref Value);
					dataRow["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj24 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj23, (object)num22), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_GHT_WT"]);
					double num23 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj25 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj24, (object)num23), (object)",0,0,0,");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["LBR_PRC"]);
					double num24 = DC_Main.Fnv(ref Value);
					dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj26 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj25, (object)num24), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["LBR_RATE"]);
					double num25 = DC_Main.Fnv(ref Value);
					dataRow["LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj27 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj26, (object)num25), (object)", "), (object)" '',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["LBR_AMT"]);
					double num26 = DC_Main.Fnv(ref Value);
					dataRow["LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj28 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj27, (object)num26), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["OTH_AMT"]);
					double num27 = DC_Main.Fnv(ref Value);
					dataRow["OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj29 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj28, (object)num27), (object)", ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_RATE"]);
					double num28 = DC_Main.Fnv(ref Value);
					dataRow["ITM_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj30 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj29, (object)num28), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_AMT"]);
					double num29 = DC_Main.Fnv(ref Value);
					dataRow["ITM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj31 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj30, (object)num29), (object)",0,0,");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["TOT_AMT"]);
					double num30 = DC_Main.Fnv(ref Value);
					dataRow["TOT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj32 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj31, (object)num30), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["TAX_PRC"]);
					double num31 = DC_Main.Fnv(ref Value);
					dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj33 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj32, (object)num31), (object)", ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["NET_AMT"]);
					double num32 = DC_Main.Fnv(ref Value);
					dataRow["NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj34 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj33, (object)num32), (object)",'"), rsDetl.Rows[DC_Main.R]["ITM_REMARK"]), (object)"', "), (object)" 0,0,0,0,0,'','','','"), rsDetl.Rows[DC_Main.R]["PR_CODE"]), (object)"', "), (object)" '"), rsDetl.Rows[DC_Main.R]["VCH_NO"]), (object)"','N','','','"), (object)DC_Main.MCo_User), (object)"','"), (object)DC_Main.MCo_User), (object)"','"), rsDetl.Rows[DC_Main.R]["DESIGN_ISU"]), (object)"','"), rsDetl.Rows[DC_Main.R]["TAG_GEN"]), (object)"','"), rsDetl.Rows[DC_Main.R]["TAG_SALE"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_GHT_PRC"]);
					double num33 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GHT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj35 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj34, (object)num33), (object)", "), (object)" '"), rsDetl.Rows[DC_Main.R]["HM_ID"]), (object)"','"), rsDetl.Rows[DC_Main.R]["HM_ID2"]), (object)"','"), rsDetl.Rows[DC_Main.R]["HM_ID3"]), (object)"','"), rsDetl.Rows[DC_Main.R]["HM_ID4"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["HM_ID_WT"]);
					double num34 = DC_Main.Fnv(ref Value);
					dataRow["HM_ID_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj36 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj35, (object)num34), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["HM_ID2_WT"]);
					double num35 = DC_Main.Fnv(ref Value);
					dataRow["HM_ID2_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj37 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj36, (object)num35), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["HM_ID3_WT"]);
					double num36 = DC_Main.Fnv(ref Value);
					dataRow["HM_ID3_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj38 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj37, (object)num36), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["HM_ID4_WT"]);
					double num37 = DC_Main.Fnv(ref Value);
					dataRow["HM_ID4_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj39 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj38, (object)num37), (object)", "), (object)" '"), rsDetl.Rows[DC_Main.R]["OLD_TBL_CODE"]), (object)"','"), rsDetl.Rows[DC_Main.R]["ITM_COLOR"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rsDetl.Rows[DC_Main.R]["ORD_DEL_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'"))), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ORD_REC_AMT"]);
					double num38 = DC_Main.Fnv(ref Value);
					dataRow["ORD_REC_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj39, (object)num38), (object)",'"), rsDetl.Rows[DC_Main.R]["EMP_CODE"]), (object)"','"), rsDetl.Rows[DC_Main.R]["TAG_STK_LESS"]), (object)"','"), rsDetl.Rows[DC_Main.R]["RATE_FIX"]), (object)"','"), rsDetl.Rows[DC_Main.R]["DESIGN_IMG_ID"]), (object)"')"));
					OpenRecordSetTrFr(DC_Main.RsQry);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.SL_ORD_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,  INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,  IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,  IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,HD_VCH_NO,  OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,DM_ORIGIN,DM_REMARK,DM_COLOR,DM_NAME,KR_RATE_TYPE,IT_DISC_PRC,IT_DISC_AMT)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,  INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,  IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,  IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,HD_VCH_NO,  OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,DM_ORIGIN,DM_REMARK,DM_COLOR,DM_NAME,KR_RATE_TYPE,IT_DISC_PRC,IT_DISC_AMT  FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), RsDetl.Rows[DC_Main.R]["CO_YEAR"]), (object)"' and CO_BOOK = '"), RsDetl.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND VCH_NO = '"), RsDetl.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND SR_NO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.R]["OLD_SRNO"]))), (object)""));
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					rsDetl = null;
					DC_Main.R++;
				}
				rsData = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.RsQry = "SELECT A.*,B.BOOK_SNAME,B.MAIN_BOOK,B.BOOK_INOUT FROM SL_ORD_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_SALE = 'N' ORDER BY A.SR_NO";
			RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = RsDetl.Rows.Count;
			lblBook.Text = "Order Tag Booking";
			Application.DoEvents();
			DC_Main.R = 0;
			DateTime dateTime3 = default(DateTime);
			while (DC_Main.R < RsDetl.Rows.Count)
			{
				DataTable rsDetl2 = RsDetl;
				if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rsDetl2.Rows[DC_Main.R]["ORD_DEL_DATE"])))
				{
					dateTime3 = Conversions.ToDate(rsDetl2.Rows[DC_Main.R]["ORD_DEL_DATE"]);
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT VCH_NO FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), RsDetl.Rows[DC_Main.R]["CO_YEAR"]), (object)"' and CO_BOOK = '"), RsDetl.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND VCH_NO = '"), RsDetl.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND SR_NO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.R]["SR_NO"]))), (object)" "));
				DC_Main.Tbl = OpenRecordSetTrFr(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					object obj40 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO SL_ORD_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,  LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,ITM_REMARK,  VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE,  HD_VCH_NO,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,ADD_USER,DESIGN_ISU,TAG_GEN,TAG_SALE,ITM_GHT_PRC,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,  OLD_TBL_CODE,ITM_COLOR,ORD_DEL_DATE,ORD_REC_AMT,EMP_CODE,TAG_STK_LESS,RATE_FIX,DESIGN_IMG_ID) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), rsDetl2.Rows[DC_Main.R]["CO_YEAR"]), (object)"','"), rsDetl2.Rows[DC_Main.R]["CO_BOOK"]), (object)"','"), rsDetl2.Rows[DC_Main.R]["VCH_NO"]), (object)"',"), rsDetl2.Rows[DC_Main.R]["SR_NO"]), (object)","), rsDetl2.Rows[DC_Main.R]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl2.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl2.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), rsDetl2.Rows[DC_Main.R]["BOOK_SNAME"]), (object)"','"), rsDetl2.Rows[DC_Main.R]["BOOK_INOUT"]), (object)"','O','"), rsDetl2.Rows[DC_Main.R]["MAIN_BOOK"]), (object)"','"), rsDetl2.Rows[DC_Main.R]["AC_CODE"]), (object)"','"), rsDetl2.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), rsDetl2.Rows[DC_Main.R]["TAG_NO"]), (object)"','','"), (object)Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(rsDetl2.Rows[DC_Main.R]["DESIGN_NO"], (object)"")), 1, 15)), (object)"','','"), (object)Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(rsDetl2.Rows[DC_Main.R]["ITM_SIZE"], (object)"")), 1, 15)), (object)"', "), (object)" ");
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["ITM_PCS"]);
					double num39 = DC_Main.Fnv(ref Value);
					dataRow["ITM_PCS"] = RuntimeHelpers.GetObjectValue(Value);
					object obj41 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj40, (object)num39), (object)",0,");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["ITM_GWT"]);
					double num40 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj42 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj41, (object)num40), (object)",0,");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["ITM_NWT"]);
					double num41 = DC_Main.Fnv(ref Value);
					dataRow["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj43 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj42, (object)num41), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["ITM_GHT_WT"]);
					double num42 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj44 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj43, (object)num42), (object)",0,0,0,");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["LBR_PRC"]);
					double num43 = DC_Main.Fnv(ref Value);
					dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj45 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj44, (object)num43), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["LBR_RATE"]);
					double num44 = DC_Main.Fnv(ref Value);
					dataRow["LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj46 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj45, (object)num44), (object)", "), (object)" '',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["LBR_AMT"]);
					double num45 = DC_Main.Fnv(ref Value);
					dataRow["LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj47 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj46, (object)num45), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["OTH_AMT"]);
					double num46 = DC_Main.Fnv(ref Value);
					dataRow["OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj48 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj47, (object)num46), (object)", ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["ITM_RATE"]);
					double num47 = DC_Main.Fnv(ref Value);
					dataRow["ITM_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj49 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj48, (object)num47), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["ITM_AMT"]);
					double num48 = DC_Main.Fnv(ref Value);
					dataRow["ITM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj50 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj49, (object)num48), (object)",0,0,");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["TOT_AMT"]);
					double num49 = DC_Main.Fnv(ref Value);
					dataRow["TOT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj51 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj50, (object)num49), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["TAX_PRC"]);
					double num50 = DC_Main.Fnv(ref Value);
					dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj52 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj51, (object)num50), (object)", ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["NET_AMT"]);
					double num51 = DC_Main.Fnv(ref Value);
					dataRow["NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj53 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj52, (object)num51), (object)",'"), rsDetl2.Rows[DC_Main.R]["ITM_REMARK"]), (object)"', "), (object)" 0,0,0,0,0,'','','','"), rsDetl2.Rows[DC_Main.R]["PR_CODE"]), (object)"', "), (object)" '"), rsDetl2.Rows[DC_Main.R]["VCH_NO"]), (object)"','N','','','"), (object)DC_Main.MCo_User), (object)"','"), (object)DC_Main.MCo_User), (object)"','"), rsDetl2.Rows[DC_Main.R]["DESIGN_ISU"]), (object)"','"), rsDetl2.Rows[DC_Main.R]["TAG_GEN"]), (object)"','"), rsDetl2.Rows[DC_Main.R]["TAG_SALE"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["ITM_GHT_PRC"]);
					double num52 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GHT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj54 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj53, (object)num52), (object)", "), (object)" '"), rsDetl2.Rows[DC_Main.R]["HM_ID"]), (object)"','"), rsDetl2.Rows[DC_Main.R]["HM_ID2"]), (object)"','"), rsDetl2.Rows[DC_Main.R]["HM_ID3"]), (object)"','"), rsDetl2.Rows[DC_Main.R]["HM_ID4"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["HM_ID_WT"]);
					double num53 = DC_Main.Fnv(ref Value);
					dataRow["HM_ID_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj55 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj54, (object)num53), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["HM_ID2_WT"]);
					double num54 = DC_Main.Fnv(ref Value);
					dataRow["HM_ID2_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj56 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj55, (object)num54), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["HM_ID3_WT"]);
					double num55 = DC_Main.Fnv(ref Value);
					dataRow["HM_ID3_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj57 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj56, (object)num55), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["HM_ID4_WT"]);
					double num56 = DC_Main.Fnv(ref Value);
					dataRow["HM_ID4_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj58 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj57, (object)num56), (object)", "), (object)" '"), rsDetl2.Rows[DC_Main.R]["OLD_TBL_CODE"]), (object)"','"), rsDetl2.Rows[DC_Main.R]["ITM_COLOR"]), (object)"',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rsDetl2.Rows[DC_Main.R]["ORD_DEL_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime3, "MM/dd/yyyy") + "'"))), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl2.Rows[DC_Main.R])["ORD_REC_AMT"]);
					double num57 = DC_Main.Fnv(ref Value);
					dataRow["ORD_REC_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj58, (object)num57), (object)",'"), rsDetl2.Rows[DC_Main.R]["EMP_CODE"]), (object)"','"), rsDetl2.Rows[DC_Main.R]["TAG_STK_LESS"]), (object)"','"), rsDetl2.Rows[DC_Main.R]["RATE_FIX"]), (object)"','"), rsDetl2.Rows[DC_Main.R]["DESIGN_IMG_ID"]), (object)"')"));
					OpenRecordSetTrFr(DC_Main.RsQry);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.SL_ORD_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,  INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,  IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,  IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,HD_VCH_NO,  OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,DM_ORIGIN,DM_REMARK,DM_COLOR,DM_NAME,KR_RATE_TYPE,IT_DISC_PRC,IT_DISC_AMT)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,  INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,  IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,  IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,HD_VCH_NO,  OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,DM_ORIGIN,DM_REMARK,DM_COLOR,DM_NAME,KR_RATE_TYPE,IT_DISC_PRC,IT_DISC_AMT  FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), RsDetl.Rows[DC_Main.R]["CO_YEAR"]), (object)"' and CO_BOOK = '"), RsDetl.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND VCH_NO = '"), RsDetl.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND SR_NO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.R]["OLD_SRNO"]))), (object)""));
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				rsDetl2 = null;
				DC_Main.R++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void SimpleButton1_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Data Transfer to Next Year ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			Rtl_AcMast();
			Rtl_Scheme();
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
		}
	}

	private void Rtl_Scheme()
	{
		DC_Main.RsQry = "SELECT * FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SCHM_CODE FROM AD_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND SCHM_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["SCHM_CODE"]), (object)"'"));
				TrFrData = OpenRecordSetTrFr(DC_Main.RsQry);
				if (TrFrData.Rows.Count == 0)
				{
					object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO AD_MAST(CO_CODE,SCHM_CODE,SCHM_NAME,SCHM_AMT,SCHM_AC,SCHM_TYPE,DATA_TRFR,MAIN_USER,BONUS_PRC,SCHM_MONTH,GOLD_RATE) VALUES  ('" + DC_Main.MCo_code + "','"), DC_Main.Rshlp.Rows[DC_Main.M]["SCHM_CODE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["SCHM_NAME"]), (object)"',");
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["SCHM_AMT"]);
					double num = DC_Main.Fnv(ref Value);
					dataRow["SCHM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num), (object)", "), (object)"  '"), DC_Main.Rshlp.Rows[DC_Main.M]["SCHM_AC"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["SCHM_TYPE"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["DATA_TRFR"]), (object)"','"), DC_Main.Rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["BONUS_PRC"]);
					double num2 = DC_Main.Fnv(ref Value);
					dataRow["BONUS_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["SCHM_MONTH"]);
					double num3 = DC_Main.Fnv(ref Value);
					dataRow["SCHM_MONTH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num3), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["GOLD_RATE"]);
					double num4 = DC_Main.Fnv(ref Value);
					dataRow["GOLD_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num4), (object)")"));
					OpenRecordSetTrFr(DC_Main.RsQry);
				}
				DC_Main.M++;
			}
			TrFrData.Clear();
			TrFrData.Columns.Clear();
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
			DC_Main.RsQry = "SELECT * FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.M = 0;
			DateTime dateTime = default(DateTime);
			DateTime dateTime2 = default(DateTime);
			DateTime dateTime3 = default(DateTime);
			DateTime dateTime4 = default(DateTime);
			DateTime dateTime5 = default(DateTime);
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT MEMB_CODE FROM AD_MEMB WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["SCHM_CODE"]), (object)"' AND MEMB_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["MEMB_CODE"]), (object)"'"));
				TrFrData = OpenRecordSetTrFr(DC_Main.RsQry);
				if (TrFrData.Rows.Count == 0)
				{
					DataTable rshlp = DC_Main.Rshlp;
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["BIRTH_DATE"])))
					{
						dateTime = Conversions.ToDate(rshlp.Rows[DC_Main.M]["BIRTH_DATE"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["L_BR_DATE"])))
					{
						dateTime2 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["L_BR_DATE"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["ANV_DATE"])))
					{
						dateTime3 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["ANV_DATE"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["JOIN_DATE"])))
					{
						dateTime4 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["JOIN_DATE"]);
					}
					if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["EXP_DATE"])))
					{
						dateTime5 = Conversions.ToDate(rshlp.Rows[DC_Main.M]["EXP_DATE"]);
					}
					object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO AD_MEMB(CO_CODE,LC_CODE,SCHM_CODE,MEMB_CODE,MEMB_NAME,MEMB_AMT,ITM_GWT,EMP_CODE,  AC_PHONE,AC_MOBILE,AC_ADD1,AC_ADD2,AC_ADD3,AC_CITY,AC_PIN,AC_AREA,AC_MOBILE2,AC_PHONE2,ID_PROF,  NOMINEE_NAME,AC_EMAIL,AC_DISTRICT,BIRTH_DATE,ANV_DATE,L_BR_DATE,JOIN_DATE,EXP_DATE,BANK_NAME,  BANK_AREA,BANK_AC_NO,BANK_RTGS_NO,AC_REF_CODE,SCHM_SHORT,MEMB_BONUS,DATA_TRFR,MAIN_USER) VALUES ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), rshlp.Rows[DC_Main.M]["SCHM_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["MEMB_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["MEMB_NAME"]), (object)"',");
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["MEMB_AMT"]);
					double num5 = DC_Main.Fnv(ref Value);
					dataRow["MEMB_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num5), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ITM_GWT"]);
					double num6 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj7 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num6), (object)",'"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["AC_PHONE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_MOBILE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_ADD1"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_ADD2"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_ADD3"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CITY"]), (object)"','','"), rshlp.Rows[DC_Main.M]["AC_AREA"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_MOBILE2"]), (object)"','','"), rshlp.Rows[DC_Main.M]["ID_PROF"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["NOMINEE_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_EMAIL"]), (object)"','',"), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["BIRTH_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["ANV_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime3, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["L_BR_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime2, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["JOIN_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime4, "MM/dd/yyyy") + "'"))), (object)","), Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["EXP_DATE"])), (object)"Null", (object)("'" + Strings.Format((object)dateTime5, "MM/dd/yyyy") + "'"))), (object)",'', "), (object)" '','"), rshlp.Rows[DC_Main.M]["BANK_AC_NO"]), (object)"','','','"), rshlp.Rows[DC_Main.M]["SCHM_SHORT"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["MEMB_BONUS"]);
					double num7 = DC_Main.Fnv(ref Value);
					dataRow["MEMB_BONUS"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, (object)num7), (object)",'N','"), (object)DC_Main.MCo_User), (object)"')"));
					OpenRecordSetTrFr(DC_Main.RsQry);
					rshlp = null;
				}
				DC_Main.M++;
			}
			TrFrData.Clear();
			TrFrData.Columns.Clear();
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
			string text = "";
			double num8 = 0.0;
			double num9 = 0.0;
			int num10 = 0;
			ExeQuteTrfr("DELETE FROM AD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '075'");
			ExeQuteTrfr("DELETE FROM AD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
			DC_Main.RsQry = "Select A.SCHM_CODE,A.MEMB_CODE,B.MEMB_NAME,B.AC_ADD1,B.AC_MOBILE,B.EMP_CODE,SUM(CASE WHEN A.OS_TYPE = 'A' THEN (CASE WHEN A.SIGN = '+' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) as SchmAmt,SUM(CASE WHEN A.OS_TYPE = 'D' THEN (CASE WHEN A.SIGN = '-' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) as SchmAdj,SUM(CASE WHEN A.OS_TYPE = 'B' THEN (CASE WHEN A.SIGN = '-' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) as BonusAmt FROM AD_OS AS A LEFT JOIN AD_MEMB AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.MEMB_CODE = B.MEMB_CODE AND A.SCHM_CODE = B.SCHM_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' and VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "' GROUP BY A.SCHM_CODE,A.MEMB_CODE,B.MEMB_NAME,B.AC_ADD1,B.AC_MOBILE,B.EMP_CODE  HAVING SUM(CASE WHEN A.OS_TYPE = 'A' THEN (CASE WHEN A.SIGN = '+' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) - SUM(CASE WHEN A.OS_TYPE = 'D' THEN (CASE WHEN A.SIGN = '-' THEN A.ADJ_AMT ELSE 0 END) ELSE 0 END) > 0 ORDER BY A.SCHM_CODE,A.MEMB_CODE ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.M = 0;
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Scheme Data";
			Application.DoEvents();
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				text = Strings.Format((object)(Conversion.Val(text) + 1.0), "00000");
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.BOOK_SNAME,B.BOOK_INOUT,B.MAIN_BOOK FROM AD_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.SCHM_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["SCHM_CODE"]), (object)"' AND A.MEMB_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["MEMB_CODE"]), (object)"' ORDER BY A.VCH_DATE,A.SCHM_DATE"));
				RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < RsData.Rows.Count)
				{
					DataTable rsData = RsData;
					string text2 = "";
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT UPI_TYPE,UPI_AMT,UPI_AC_NAME FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), RsData.Rows[DC_Main.R]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), RsData.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND VCH_NO = '"), RsData.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND SR_NO = "), RsData.Rows[DC_Main.R]["SR_NO"]), (object)" "));
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DataRow dataRow;
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						int num11 = DC_Main.Tbl.Rows.Count - 1;
						for (int i = 0; i <= num11; i++)
						{
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[i]["UPI_TYPE"], (object)""), (object)"", false))
							{
								string text3 = text2;
								object obj8 = Operators.ConcatenateObject(DC_Main.Tbl.Rows[i]["UPI_AC_NAME"], (object)"/");
								Type? typeFromHandle = typeof(Math);
								object[] obj9 = new object[2]
								{
									(dataRow = DC_Main.Tbl.Rows[i])["UPI_AMT"],
									0
								};
								object[] array = obj9;
								bool[] obj10 = new bool[2] { true, false };
								bool[] array2 = obj10;
								object obj11 = NewLateBinding.LateGet((object)null, typeFromHandle, "Round", obj9, (string[])null, (Type[])null, obj10);
								if (array2[0])
								{
									dataRow["UPI_AMT"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
								}
								text2 = Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(obj8, obj11), (object)"  ")));
							}
							else
							{
								string text4 = text2;
								object obj12 = Operators.ConcatenateObject(DC_Main.Tbl.Rows[i]["UPI_TYPE"], (object)"/");
								Type? typeFromHandle2 = typeof(Math);
								object[] obj13 = new object[2]
								{
									(dataRow = DC_Main.Tbl.Rows[i])["UPI_AMT"],
									0
								};
								object[] array = obj13;
								bool[] obj14 = new bool[2] { true, false };
								bool[] array2 = obj14;
								object obj15 = NewLateBinding.LateGet((object)null, typeFromHandle2, "Round", obj13, (string[])null, (Type[])null, obj14);
								if (array2[0])
								{
									dataRow["UPI_AMT"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
								}
								text2 = Conversions.ToString(Operators.AddObject((object)text4, Operators.ConcatenateObject(Operators.ConcatenateObject(obj12, obj15), (object)"  ")));
							}
						}
					}
					if (Strings.Len(text2) > 225)
					{
						text2 = Strings.Mid(text2, 1, 225);
					}
					object obj16 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO AD_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,SCHM_CODE,SCHM_DATE,  MEMB_CODE,MEMB_AMT,TOT_AMT,IT_DESC,MONTH_CODE,EMP_CODE,ENT_TYPE,REC_AC,ITM_GWT,ITM_RATE,BANK_NAME,  CHQ_NO,ENTRY_TIME,HD_VCH_NO,MAIN_USER,DATA_TRFR,VCH_TIME,VCH_TYPE,INOUT_TYPE,BOOK_NAME,UPI_NAME) VALUES  ('", rsData.Rows[DC_Main.R]["CO_CODE"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), (object)tYearCode.Text), (object)"','075','"), (object)text), (object)"',"), (object)(DC_Main.R + 1)), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsData.Rows[DC_Main.R]["SCHM_CODE"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[DC_Main.R]["SCHM_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), rsData.Rows[DC_Main.R]["MEMB_CODE"]), (object)"',");
					object Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["MEMB_AMT"]);
					double num12 = DC_Main.Fnv(ref Value);
					dataRow["MEMB_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj17 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj16, (object)num12), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["TOT_AMT"]);
					double num13 = DC_Main.Fnv(ref Value);
					dataRow["TOT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj18 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj17, (object)num13), (object)",'"), rsData.Rows[DC_Main.R]["IT_DESC"]), (object)"','"), rsData.Rows[DC_Main.R]["MONTH_CODE"]), (object)"','"), rsData.Rows[DC_Main.R]["EMP_CODE"]), (object)"','"), rsData.Rows[DC_Main.R]["ENT_TYPE"]), (object)"','"), rsData.Rows[DC_Main.R]["REC_AC"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["ITM_GWT"]);
					double num14 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj19 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj18, (object)num14), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["ITM_RATE"]);
					double num15 = DC_Main.Fnv(ref Value);
					dataRow["ITM_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj19, (object)num15), (object)",'"), rsData.Rows[DC_Main.R]["BANK_NAME"]), (object)"', "), (object)" '"), rsData.Rows[DC_Main.R]["CHQ_NO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsData.Rows[DC_Main.R]["VCH_NO"]), (object)"','"), (object)DC_Main.MCo_User), (object)"','N','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsData.Rows[DC_Main.R]["BOOK_SNAME"]), (object)"','"), rsData.Rows[DC_Main.R]["BOOK_INOUT"]), (object)"','"), rsData.Rows[DC_Main.R]["MAIN_BOOK"]), (object)"','"), (object)text2), (object)"')"));
					OpenRecordSetTrFr(DC_Main.RsQry);
					rsData = null;
					DC_Main.R++;
				}
				RsData.Clear();
				RsData.Columns.Clear();
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.BOOK_SNAME,B.BOOK_INOUT,B.MAIN_BOOK FROM AD_ADJ AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.SCHM_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["SCHM_CODE"]), (object)"' AND A.MEMB_CODE = '"), DC_Main.Rshlp.Rows[DC_Main.M]["MEMB_CODE"]), (object)"' ORDER BY A.VCH_DATE,A.VCH_NO "));
				RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < RsData.Rows.Count)
				{
					DataTable rsData2 = RsData;
					object obj20 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO AD_ADJ(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  SCHM_CODE,MEMB_CODE,MEMB_AMT,MEMB_BONUS,MEMB_LESS,ADJ_AMT,AC_CODE,AC_NAME,SBILL_NO,SBILL_LC_CODE,SBILL_YRCD,SBILL_DBCD,  SBILL_AMT,SBILL_HD_VCH_NO,EMP_CODE,VCH_DESC,SIGN,HD_VCH_NO,MAIN_USER,DATA_TRFR,  USER_UPDATE,USER_DELETE,GOLD_WT,GOLD_RATE,GOLD_AMT) VALUES  ('", rsData2.Rows[DC_Main.R]["CO_CODE"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), rsData2.Rows[DC_Main.R]["CO_YEAR"]), (object)"','"), rsData2.Rows[DC_Main.R]["CO_BOOK"]), (object)"','"), rsData2.Rows[DC_Main.R]["VCH_NO"]), (object)"',"), rsData2.Rows[DC_Main.R]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData2.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData2.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsData2.Rows[DC_Main.R]["BOOK_SNAME"]), (object)"','"), rsData2.Rows[DC_Main.R]["BOOK_INOUT"]), (object)"','A','"), rsData2.Rows[DC_Main.R]["MAIN_BOOK"]), (object)"', "), (object)" '"), rsData2.Rows[DC_Main.R]["SCHM_CODE"]), (object)"','"), rsData2.Rows[DC_Main.R]["MEMB_CODE"]), (object)"',");
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = rsData2.Rows[DC_Main.R])["MEMB_AMT"]);
					double num16 = DC_Main.Fnv(ref Value);
					dataRow["MEMB_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj21 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj20, (object)num16), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData2.Rows[DC_Main.R])["MEMB_BONUS"]);
					double num17 = DC_Main.Fnv(ref Value);
					dataRow["MEMB_BONUS"] = RuntimeHelpers.GetObjectValue(Value);
					object obj22 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj21, (object)num17), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData2.Rows[DC_Main.R])["MEMB_LESS"]);
					double num18 = DC_Main.Fnv(ref Value);
					dataRow["MEMB_LESS"] = RuntimeHelpers.GetObjectValue(Value);
					object obj23 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj22, (object)num18), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData2.Rows[DC_Main.R])["ADJ_AMT"]);
					double num19 = DC_Main.Fnv(ref Value);
					dataRow["ADJ_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj24 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj23, (object)num19), (object)",'"), rsData2.Rows[DC_Main.R]["AC_CODE"]), (object)"','"), rsData2.Rows[DC_Main.R]["AC_NAME"]), (object)"','"), rsData2.Rows[DC_Main.R]["SBILL_NO"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), rsData2.Rows[DC_Main.R]["SBILL_YRCD"]), (object)"','"), rsData2.Rows[DC_Main.R]["SBILL_DBCD"]), (object)"', "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData2.Rows[DC_Main.R])["SBILL_AMT"]);
					double num20 = DC_Main.Fnv(ref Value);
					dataRow["SBILL_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj25 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj24, (object)num20), (object)",'"), rsData2.Rows[DC_Main.R]["SBILL_NO"]), (object)"','"), rsData2.Rows[DC_Main.R]["EMP_CODE"]), (object)"','"), rsData2.Rows[DC_Main.R]["VCH_DESC"]), (object)"','"), rsData2.Rows[DC_Main.R]["SIGN"]), (object)"','"), rsData2.Rows[DC_Main.R]["VCH_NO"]), (object)"','"), (object)DC_Main.MCo_User), (object)"','N', "), (object)" '"), rsData2.Rows[DC_Main.R]["USER_UPDATE"]), (object)"','"), rsData2.Rows[DC_Main.R]["USER_DELETE"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData2.Rows[DC_Main.R])["GOLD_WT"]);
					double num21 = DC_Main.Fnv(ref Value);
					dataRow["GOLD_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj26 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj25, (object)num21), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData2.Rows[DC_Main.R])["GOLD_RATE"]);
					double num22 = DC_Main.Fnv(ref Value);
					dataRow["GOLD_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj27 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj26, (object)num22), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData2.Rows[DC_Main.R])["GOLD_AMT"]);
					double num23 = DC_Main.Fnv(ref Value);
					dataRow["GOLD_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj27, (object)num23), (object)")"));
					OpenRecordSetTrFr(DC_Main.RsQry);
					rsData2 = null;
					DC_Main.R++;
				}
				RsData.Clear();
				RsData.Columns.Clear();
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
		}
	}

	private void BtnDhrn_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Data Transfer to Next Year ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			Rtl_AcMast();
			Rtl_Dhrn();
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
		}
	}

	private void Rtl_Dhrn()
	{
		ExeQuteTrfr("DELETE FROM DHRN_ISU_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "' AND ENTRY_TYPE = 'D'");
		ExeQuteTrfr("DELETE FROM DHRN_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "' AND ENTRY_TYPE = 'D'");
		ExeQuteTrfr("DELETE FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "' AND ENTRY_TYPE = 'D'");
		ExeQuteTrfr("DELETE FROM DHRN_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "' AND ENTRY_TYPE = 'D'");
		ExeQuteTrfr("DELETE FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "' AND ENTRY_TYPE = 'D'");
		DC_Main.RsQry = "SELECT A.*,B.BOOK_SNAME,B.BOOK_INOUT,B.MAIN_BOOK FROM DHRN_ISU_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.DHRN_AMT - A.DHRN_REC_AMT > 0 AND A.ENTRY_TYPE = 'D' ORDER BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Dhrn Isu Data";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO DHRN_ISU_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,VCH_TIME,BOOK_NAME,AC_CODE,AC_NAME,LEDR_ACCD,DHRN_BILL,TO_DATE,  DHRN_AMT,DHRN_REC_AMT,DHRN_MONTH,INT_MONTH,INT_PRC,INT_AMT,INT_REC_AMT,GOLD_DESC,  GOLD_AMT,GOLD_WT,VCH_DESC,EMP_CODE,MONTH_INT_AMT,OLD_ISU_NO,OLD_ISU_LC,OLD_ISU_YRCD,OLD_ISU_DBCD,OLD_ITEM_ADJ,  INT_DAYS,OTH_AMT,PACKET_NO,HD_VCH_NO,MAIN_USER,ISU_REC,GOLD_NWT,SILVER_NWT,DHRN_LIC_NO,DATA_TRFR,LOAN_TYPE,UNCHAK_DHRN_REC) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["BOOK_SNAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_INOUT"]), (object)"','D','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["LEDR_ACCD"]), (object)"','"), rshlp.Rows[DC_Main.M]["DHRN_BILL"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["TO_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" ");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["DHRN_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["DHRN_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["DHRN_REC_AMT"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["DHRN_REC_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["DHRN_MONTH"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["DHRN_MONTH"] = RuntimeHelpers.GetObjectValue(Value);
				object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num3), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["INT_MONTH"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["INT_MONTH"] = RuntimeHelpers.GetObjectValue(Value);
				object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num4), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["INT_PRC"]);
				double num5 = DC_Main.Fnv(ref Value);
				dataRow["INT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num5), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["INT_AMT"]);
				double num6 = DC_Main.Fnv(ref Value);
				dataRow["INT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj7 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num6), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["INT_REC_AMT"]);
				double num7 = DC_Main.Fnv(ref Value);
				dataRow["INT_REC_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj8 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, (object)num7), (object)",'"), rshlp.Rows[DC_Main.M]["GOLD_DESC"]), (object)"', "), (object)" ");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["GOLD_AMT"]);
				double num8 = DC_Main.Fnv(ref Value);
				dataRow["GOLD_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj9 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj8, (object)num8), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["GOLD_WT"]);
				double num9 = DC_Main.Fnv(ref Value);
				dataRow["GOLD_WT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj10 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj9, (object)num9), (object)",'"), rshlp.Rows[DC_Main.M]["VCH_DESC"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["MONTH_INT_AMT"]);
				double num10 = DC_Main.Fnv(ref Value);
				dataRow["MONTH_INT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj11 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj10, (object)num10), (object)",'"), rshlp.Rows[DC_Main.M]["OLD_ISU_NO"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), rshlp.Rows[DC_Main.M]["OLD_ISU_YRCD"]), (object)"','"), rshlp.Rows[DC_Main.M]["OLD_ISU_DBCD"]), (object)"','"), rshlp.Rows[DC_Main.M]["OLD_ITEM_ADJ"]), (object)"', "), (object)" ");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["INT_DAYS"]);
				double num11 = DC_Main.Fnv(ref Value);
				dataRow["INT_DAYS"] = RuntimeHelpers.GetObjectValue(Value);
				object obj12 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj11, (object)num11), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["OTH_AMT"]);
				double num12 = DC_Main.Fnv(ref Value);
				dataRow["OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj13 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj12, (object)num12), (object)",'"), rshlp.Rows[DC_Main.M]["PACKET_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["ISU_REC"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["GOLD_NWT"]);
				double num13 = DC_Main.Fnv(ref Value);
				dataRow["GOLD_NWT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj14 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj13, (object)num13), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["SILVER_NWT"]);
				double num14 = DC_Main.Fnv(ref Value);
				dataRow["SILVER_NWT"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj14, (object)num14), (object)",'"), rshlp.Rows[DC_Main.M]["DHRN_LIC_NO"]), (object)"','N','"), rshlp.Rows[DC_Main.M]["LOAN_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["UNCHAK_DHRN_REC"]), (object)"')"));
				OpenRecordSetTrFr(DC_Main.RsQry);
				rshlp = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.BOOK_SNAME,B.BOOK_INOUT,B.MAIN_BOOK,C.RATE_TYPE,C.IT_TYPE FROM (DHRN_ISU_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK)LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND A.CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.SR_NO"));
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < RsDetl.Rows.Count)
				{
					DataTable rsDetl = RsDetl;
					object obj15 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO DHRN_ISU_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,VCH_TIME,BOOK_NAME,AC_CODE,IT_CODE,IT_NAME,  ITM_PCS,ITM_GWT,ITM_OTH_WT,ITM_NWT,REC_NWT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  ITM_RATE,ITM_AMT,NET_AMT,IT_DESC,RATE_TYPE,IT_TYPE,HD_VCH_NO,MAIN_USER,DATA_TRFR,  PACKET_NO,CUST_NAME,PACKET_REC,DHRN_NO,DHRN_YRCD,DHRN_DBCD,HM_ID) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), rsDetl.Rows[DC_Main.R]["CO_YEAR"]), (object)"','"), rsDetl.Rows[DC_Main.R]["CO_BOOK"]), (object)"','"), rsDetl.Rows[DC_Main.R]["VCH_NO"]), (object)"',"), rsDetl.Rows[DC_Main.R]["SR_NO"]), (object)","), rsDetl.Rows[DC_Main.R]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), rsDetl.Rows[DC_Main.R]["BOOK_SNAME"]), (object)"','"), rsDetl.Rows[DC_Main.R]["BOOK_INOUT"]), (object)"','D','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsDetl.Rows[DC_Main.R]["MAIN_BOOK"]), (object)"','"), rsDetl.Rows[DC_Main.R]["AC_CODE"]), (object)"','"), rsDetl.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), rsDetl.Rows[DC_Main.R]["IT_NAME"]), (object)"', "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_PCS"]);
					double num15 = DC_Main.Fnv(ref Value);
					dataRow["ITM_PCS"] = RuntimeHelpers.GetObjectValue(Value);
					object obj16 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj15, (object)num15), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_GWT"]);
					double num16 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj17 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj16, (object)num16), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_GWT"]);
					double num17 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_NWT"]);
					double num18 = DC_Main.Fnv(ref Value);
					dataRow["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj18 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj17, (object)(num17 - num18)), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_NWT"]);
					double num19 = DC_Main.Fnv(ref Value);
					dataRow["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj19 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj18, (object)num19), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["REC_NWT"]);
					double num20 = DC_Main.Fnv(ref Value);
					dataRow["REC_NWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj20 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj19, (object)num20), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_TOUCH"]);
					double num21 = DC_Main.Fnv(ref Value);
					dataRow["ITM_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj21 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj20, (object)num21), (object)",0,");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_FINE"]);
					double num22 = DC_Main.Fnv(ref Value);
					dataRow["ITM_FINE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj22 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj21, (object)num22), (object)", "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_RATE"]);
					double num23 = DC_Main.Fnv(ref Value);
					dataRow["ITM_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj23 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj22, (object)num23), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_AMT"]);
					double num24 = DC_Main.Fnv(ref Value);
					dataRow["ITM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj24 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj23, (object)num24), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_AMT"]);
					double num25 = DC_Main.Fnv(ref Value);
					dataRow["ITM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj24, (object)num25), (object)",'"), rsDetl.Rows[DC_Main.R]["IT_DESC"]), (object)"','"), rsDetl.Rows[DC_Main.R]["RATE_TYPE"]), (object)"','"), rsDetl.Rows[DC_Main.R]["IT_TYPE"]), (object)"','"), rsDetl.Rows[DC_Main.R]["VCH_NO"]), (object)"','"), rsDetl.Rows[DC_Main.R]["MAIN_USER"]), (object)"','N', "), (object)" '"), rsDetl.Rows[DC_Main.R]["PACKET_NO"]), (object)"','"), rsDetl.Rows[DC_Main.R]["CUST_NAME"]), (object)"','"), rsDetl.Rows[DC_Main.R]["PACKET_REC"]), (object)"','"), rsDetl.Rows[DC_Main.R]["DHRN_NO"]), (object)"','"), rsDetl.Rows[DC_Main.R]["DHRN_YRCD"]), (object)"','"), rsDetl.Rows[DC_Main.R]["DHRN_DBCD"]), (object)"','"), rsDetl.Rows[DC_Main.R]["HM_ID"]), (object)"')"));
					OpenRecordSetTrFr(DC_Main.RsQry);
					rsDetl = null;
					DC_Main.R++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.BOOK_SNAME,B.BOOK_INOUT,B.MAIN_BOOK FROM DHRN_REC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE =  '" + DC_Main.MLc_code + "' AND ISU_YRCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND ISU_DBCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND ISU_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO"));
				RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < RsData.Rows.Count)
				{
					DataTable rsData = RsData;
					object obj25 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO DHRN_REC_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,DHRN_BILL,DHRN_DATE,DHRN_MONTH,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,VCH_TIME,BOOK_NAME,AC_CODE,AC_NAME,LEDR_ACCD,FROM_DATE,TO_DATE,  DHRN_AMT,DHRN_ADJ_AMT,DHRN_OS_AMT,DHRN_REC_AMT,DHRN_DAY,INT_MONTH,INT_DAY,INT_PRC,INT_AMT,INT_REC_AMT,  KASAR_AMT,GOLD_AMT,GOLD_WT,ISU_LC,ISU_NO,ISU_DBCD,ISU_YRCD,VCH_DESC,EMP_CODE,MONTH_INT_AMT,  PACKET_NO,PAN_ADJ_AMT,ADJ_INT,ADJ_DHRN,HD_VCH_NO,ORNA_AMT,DHRN_LIC_NO,DATA_TRFR,MAIN_USER,LOAN_TYPE,UNCHAK_DHRN_REC,  USER_UPDATE,USER_DELETE,RCUT_RATE,RCUT_AMT,RCUT_PAY_AMT,RCUT_OS_AMT) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), rsData.Rows[DC_Main.R]["CO_YEAR"]), (object)"','"), rsData.Rows[DC_Main.R]["CO_BOOK"]), (object)"','"), rsData.Rows[DC_Main.R]["VCH_NO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsData.Rows[DC_Main.R]["DHRN_BILL"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[DC_Main.R]["DHRN_DATE"]), "MM/dd/yyyy")), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["DHRN_MONTH"]);
					double num26 = DC_Main.Fnv(ref Value);
					dataRow["DHRN_MONTH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj26 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj25, (object)num26), (object)", "), (object)" '"), rsData.Rows[DC_Main.R]["BOOK_SNAME"]), (object)"','"), rsData.Rows[DC_Main.R]["BOOK_INOUT"]), (object)"','D','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsData.Rows[DC_Main.R]["MAIN_BOOK"]), (object)"','"), rsData.Rows[DC_Main.R]["AC_CODE"]), (object)"','"), rsData.Rows[DC_Main.R]["AC_NAME"]), (object)"','"), rsData.Rows[DC_Main.R]["LEDR_ACCD"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[DC_Main.R]["FROM_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[DC_Main.R]["TO_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["DHRN_AMT"]);
					double num27 = DC_Main.Fnv(ref Value);
					dataRow["DHRN_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj27 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj26, (object)num27), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["DHRN_ADJ_AMT"]);
					double num28 = DC_Main.Fnv(ref Value);
					dataRow["DHRN_ADJ_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj28 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj27, (object)num28), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["DHRN_OS_AMT"]);
					double num29 = DC_Main.Fnv(ref Value);
					dataRow["DHRN_OS_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj29 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj28, (object)num29), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["DHRN_REC_AMT"]);
					double num30 = DC_Main.Fnv(ref Value);
					dataRow["DHRN_REC_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj30 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj29, (object)num30), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["DHRN_DAY"]);
					double num31 = DC_Main.Fnv(ref Value);
					dataRow["DHRN_DAY"] = RuntimeHelpers.GetObjectValue(Value);
					object obj31 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj30, (object)num31), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["INT_MONTH"]);
					double num32 = DC_Main.Fnv(ref Value);
					dataRow["INT_MONTH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj32 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj31, (object)num32), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["INT_DAY"]);
					double num33 = DC_Main.Fnv(ref Value);
					dataRow["INT_DAY"] = RuntimeHelpers.GetObjectValue(Value);
					object obj33 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj32, (object)num33), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["INT_PRC"]);
					double num34 = DC_Main.Fnv(ref Value);
					dataRow["INT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj34 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj33, (object)num34), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["INT_AMT"]);
					double num35 = DC_Main.Fnv(ref Value);
					dataRow["INT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj35 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj34, (object)num35), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["INT_REC_AMT"]);
					double num36 = DC_Main.Fnv(ref Value);
					dataRow["INT_REC_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj36 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj35, (object)num36), (object)", "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["KASAR_AMT"]);
					double num37 = DC_Main.Fnv(ref Value);
					dataRow["KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj37 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj36, (object)num37), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["GOLD_AMT"]);
					double num38 = DC_Main.Fnv(ref Value);
					dataRow["GOLD_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj38 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj37, (object)num38), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["GOLD_WT"]);
					double num39 = DC_Main.Fnv(ref Value);
					dataRow["GOLD_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj39 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj38, (object)num39), (object)",'"), (object)DC_Main.MLc_code), (object)"','"), rsData.Rows[DC_Main.R]["ISU_NO"]), (object)"','"), rsData.Rows[DC_Main.R]["ISU_DBCD"]), (object)"','"), rsData.Rows[DC_Main.R]["ISU_YRCD"]), (object)"','"), rsData.Rows[DC_Main.R]["VCH_DESC"]), (object)"','"), rsData.Rows[DC_Main.R]["EMP_CODE"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["MONTH_INT_AMT"]);
					double num40 = DC_Main.Fnv(ref Value);
					dataRow["MONTH_INT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj40 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj39, (object)num40), (object)", "), (object)" '"), rsData.Rows[DC_Main.R]["PACKET_NO"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["PAN_ADJ_AMT"]);
					double num41 = DC_Main.Fnv(ref Value);
					dataRow["PAN_ADJ_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj41 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj40, (object)num41), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["ADJ_INT"]);
					double num42 = DC_Main.Fnv(ref Value);
					dataRow["ADJ_INT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj42 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj41, (object)num42), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["ADJ_DHRN"]);
					double num43 = DC_Main.Fnv(ref Value);
					dataRow["ADJ_DHRN"] = RuntimeHelpers.GetObjectValue(Value);
					object obj43 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj42, (object)num43), (object)",'"), rsData.Rows[DC_Main.R]["HD_VCH_NO"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["ORNA_AMT"]);
					double num44 = DC_Main.Fnv(ref Value);
					dataRow["ORNA_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj44 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj43, (object)num44), (object)",'"), rsData.Rows[DC_Main.R]["DHRN_LIC_NO"]), (object)"','N','"), (object)DC_Main.MCo_User), (object)"','"), rsData.Rows[DC_Main.R]["LOAN_TYPE"]), (object)"','"), rsData.Rows[DC_Main.R]["UNCHAK_DHRN_REC"]), (object)"', "), (object)" '"), rsData.Rows[DC_Main.R]["USER_UPDATE"]), (object)"','"), rsData.Rows[DC_Main.R]["USER_DELETE"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["RCUT_RATE"]);
					double num45 = DC_Main.Fnv(ref Value);
					dataRow["RCUT_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj45 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj44, (object)num45), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["RCUT_AMT"]);
					double num46 = DC_Main.Fnv(ref Value);
					dataRow["RCUT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj46 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj45, (object)num46), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["RCUT_PAY_AMT"]);
					double num47 = DC_Main.Fnv(ref Value);
					dataRow["RCUT_PAY_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj47 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj46, (object)num47), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["RCUT_OS_AMT"]);
					double num48 = DC_Main.Fnv(ref Value);
					dataRow["RCUT_OS_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj47, (object)num48), (object)")"));
					OpenRecordSetTrFr(DC_Main.RsQry);
					rsData = null;
					DC_Main.R++;
				}
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void BtnLoan_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Data Transfer to Next Year ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			Rtl_AcMast();
			Rtl_Loan();
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
		}
	}

	private void Rtl_Loan()
	{
		ExeQuteTrfr("DELETE FROM DHRN_ISU_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "' AND ENTRY_TYPE = 'L'");
		ExeQuteTrfr("DELETE FROM DHRN_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "' AND ENTRY_TYPE = 'L'");
		ExeQuteTrfr("DELETE FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "' AND ENTRY_TYPE = 'L'");
		ExeQuteTrfr("DELETE FROM DHRN_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "' AND ENTRY_TYPE = 'L'");
		ExeQuteTrfr("DELETE FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "' AND ENTRY_TYPE = 'L'");
		DC_Main.RsQry = "SELECT A.*,B.BOOK_SNAME,B.BOOK_INOUT,B.MAIN_BOOK FROM DHRN_ISU_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.DHRN_AMT - A.DHRN_REC_AMT > 0 AND A.ENTRY_TYPE = 'L' ORDER BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Loan Rec Data";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO DHRN_ISU_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,VCH_TIME,BOOK_NAME,AC_CODE,AC_NAME,LEDR_ACCD,DHRN_BILL,TO_DATE,  DHRN_AMT,DHRN_REC_AMT,DHRN_MONTH,INT_MONTH,INT_PRC,INT_AMT,INT_REC_AMT,GOLD_DESC,  GOLD_AMT,GOLD_WT,VCH_DESC,EMP_CODE,MONTH_INT_AMT,OLD_ISU_NO,OLD_ISU_LC,OLD_ISU_YRCD,OLD_ISU_DBCD,OLD_ITEM_ADJ,  INT_DAYS,OTH_AMT,PACKET_NO,HD_VCH_NO,MAIN_USER,ISU_REC,GOLD_NWT,SILVER_NWT,DHRN_LIC_NO,DATA_TRFR,LOAN_TYPE,UNCHAK_DHRN_REC) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["BOOK_SNAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_INOUT"]), (object)"','L','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["AC_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["LEDR_ACCD"]), (object)"','"), rshlp.Rows[DC_Main.M]["DHRN_BILL"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["TO_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" ");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["DHRN_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["DHRN_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["DHRN_REC_AMT"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["DHRN_REC_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["DHRN_MONTH"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["DHRN_MONTH"] = RuntimeHelpers.GetObjectValue(Value);
				object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num3), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["INT_MONTH"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["INT_MONTH"] = RuntimeHelpers.GetObjectValue(Value);
				object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num4), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["INT_PRC"]);
				double num5 = DC_Main.Fnv(ref Value);
				dataRow["INT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num5), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["INT_AMT"]);
				double num6 = DC_Main.Fnv(ref Value);
				dataRow["INT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj7 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num6), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["INT_REC_AMT"]);
				double num7 = DC_Main.Fnv(ref Value);
				dataRow["INT_REC_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj8 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, (object)num7), (object)",'"), rshlp.Rows[DC_Main.M]["GOLD_DESC"]), (object)"', "), (object)" ");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["GOLD_AMT"]);
				double num8 = DC_Main.Fnv(ref Value);
				dataRow["GOLD_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj9 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj8, (object)num8), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["GOLD_WT"]);
				double num9 = DC_Main.Fnv(ref Value);
				dataRow["GOLD_WT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj10 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj9, (object)num9), (object)",'"), rshlp.Rows[DC_Main.M]["VCH_DESC"]), (object)"','"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["MONTH_INT_AMT"]);
				double num10 = DC_Main.Fnv(ref Value);
				dataRow["MONTH_INT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj11 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj10, (object)num10), (object)",'"), rshlp.Rows[DC_Main.M]["OLD_ISU_NO"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), rshlp.Rows[DC_Main.M]["OLD_ISU_YRCD"]), (object)"','"), rshlp.Rows[DC_Main.M]["OLD_ISU_DBCD"]), (object)"','"), rshlp.Rows[DC_Main.M]["OLD_ITEM_ADJ"]), (object)"', "), (object)" ");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["INT_DAYS"]);
				double num11 = DC_Main.Fnv(ref Value);
				dataRow["INT_DAYS"] = RuntimeHelpers.GetObjectValue(Value);
				object obj12 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj11, (object)num11), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["OTH_AMT"]);
				double num12 = DC_Main.Fnv(ref Value);
				dataRow["OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj13 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj12, (object)num12), (object)",'"), rshlp.Rows[DC_Main.M]["PACKET_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["ISU_REC"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["GOLD_NWT"]);
				double num13 = DC_Main.Fnv(ref Value);
				dataRow["GOLD_NWT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj14 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj13, (object)num13), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["SILVER_NWT"]);
				double num14 = DC_Main.Fnv(ref Value);
				dataRow["SILVER_NWT"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj14, (object)num14), (object)",'"), rshlp.Rows[DC_Main.M]["DHRN_LIC_NO"]), (object)"','N','"), rshlp.Rows[DC_Main.M]["LOAN_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["UNCHAK_DHRN_REC"]), (object)"')"));
				OpenRecordSetTrFr(DC_Main.RsQry);
				rshlp = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.*,B.BOOK_SNAME,B.BOOK_INOUT,B.MAIN_BOOK,C.RATE_TYPE,C.IT_TYPE FROM (DHRN_ISU_DETL As A LEFT JOIN BOOK_DATA As B On A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN ITEM_MAST As C On A.CO_CODE = C.CO_CODE And A.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND A.CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.SR_NO"));
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < RsDetl.Rows.Count)
				{
					DataTable rsDetl = RsDetl;
					object obj15 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO DHRN_ISU_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,VCH_TIME,BOOK_NAME,AC_CODE,IT_CODE,IT_NAME,  ITM_PCS,ITM_GWT,ITM_OTH_WT,ITM_NWT,REC_NWT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  ITM_RATE,ITM_AMT,NET_AMT,IT_DESC,RATE_TYPE,IT_TYPE,HD_VCH_NO,MAIN_USER,DATA_TRFR,  PACKET_NO,CUST_NAME,PACKET_REC,DHRN_NO,DHRN_YRCD,DHRN_DBCD,HM_ID) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), rsDetl.Rows[DC_Main.R]["CO_YEAR"]), (object)"','"), rsDetl.Rows[DC_Main.R]["CO_BOOK"]), (object)"','"), rsDetl.Rows[DC_Main.R]["VCH_NO"]), (object)"',"), rsDetl.Rows[DC_Main.R]["SR_NO"]), (object)","), rsDetl.Rows[DC_Main.R]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), rsDetl.Rows[DC_Main.R]["BOOK_SNAME"]), (object)"','"), rsDetl.Rows[DC_Main.R]["BOOK_INOUT"]), (object)"','L','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsDetl.Rows[DC_Main.R]["MAIN_BOOK"]), (object)"','"), rsDetl.Rows[DC_Main.R]["AC_CODE"]), (object)"','"), rsDetl.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), rsDetl.Rows[DC_Main.R]["IT_NAME"]), (object)"', "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_PCS"]);
					double num15 = DC_Main.Fnv(ref Value);
					dataRow["ITM_PCS"] = RuntimeHelpers.GetObjectValue(Value);
					object obj16 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj15, (object)num15), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_GWT"]);
					double num16 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj17 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj16, (object)num16), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_GWT"]);
					double num17 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_NWT"]);
					double num18 = DC_Main.Fnv(ref Value);
					dataRow["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj18 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj17, (object)(num17 - num18)), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_NWT"]);
					double num19 = DC_Main.Fnv(ref Value);
					dataRow["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj19 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj18, (object)num19), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["REC_NWT"]);
					double num20 = DC_Main.Fnv(ref Value);
					dataRow["REC_NWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj20 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj19, (object)num20), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_TOUCH"]);
					double num21 = DC_Main.Fnv(ref Value);
					dataRow["ITM_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj21 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj20, (object)num21), (object)",0,");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_FINE"]);
					double num22 = DC_Main.Fnv(ref Value);
					dataRow["ITM_FINE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj22 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj21, (object)num22), (object)", "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_RATE"]);
					double num23 = DC_Main.Fnv(ref Value);
					dataRow["ITM_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj23 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj22, (object)num23), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_AMT"]);
					double num24 = DC_Main.Fnv(ref Value);
					dataRow["ITM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj24 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj23, (object)num24), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[DC_Main.R])["ITM_AMT"]);
					double num25 = DC_Main.Fnv(ref Value);
					dataRow["ITM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj24, (object)num25), (object)",'"), rsDetl.Rows[DC_Main.R]["IT_DESC"]), (object)"','"), rsDetl.Rows[DC_Main.R]["RATE_TYPE"]), (object)"','"), rsDetl.Rows[DC_Main.R]["IT_TYPE"]), (object)"','"), rsDetl.Rows[DC_Main.R]["VCH_NO"]), (object)"','"), rsDetl.Rows[DC_Main.R]["MAIN_USER"]), (object)"','N', "), (object)" '"), rsDetl.Rows[DC_Main.R]["PACKET_NO"]), (object)"','"), rsDetl.Rows[DC_Main.R]["CUST_NAME"]), (object)"','"), rsDetl.Rows[DC_Main.R]["PACKET_REC"]), (object)"','"), rsDetl.Rows[DC_Main.R]["DHRN_NO"]), (object)"','"), rsDetl.Rows[DC_Main.R]["DHRN_YRCD"]), (object)"','"), rsDetl.Rows[DC_Main.R]["DHRN_DBCD"]), (object)"','"), rsDetl.Rows[DC_Main.R]["HM_ID"]), (object)"')"));
					OpenRecordSetTrFr(DC_Main.RsQry);
					rsDetl = null;
					DC_Main.R++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.BOOK_SNAME,B.BOOK_INOUT,B.MAIN_BOOK FROM DHRN_REC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE =  '" + DC_Main.MLc_code + "' AND ISU_YRCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND ISU_DBCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND ISU_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO"));
				RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < RsData.Rows.Count)
				{
					DataTable rsData = RsData;
					object obj25 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO DHRN_REC_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,DHRN_BILL,DHRN_DATE,DHRN_MONTH,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,VCH_TIME,BOOK_NAME,AC_CODE,AC_NAME,LEDR_ACCD,FROM_DATE,TO_DATE,  DHRN_AMT,DHRN_ADJ_AMT,DHRN_OS_AMT,DHRN_REC_AMT,DHRN_DAY,INT_MONTH,INT_DAY,INT_PRC,INT_AMT,INT_REC_AMT,  KASAR_AMT,GOLD_AMT,GOLD_WT,ISU_LC,ISU_NO,ISU_DBCD,ISU_YRCD,VCH_DESC,EMP_CODE,MONTH_INT_AMT,  PACKET_NO,PAN_ADJ_AMT,ADJ_INT,ADJ_DHRN,HD_VCH_NO,ORNA_AMT,DHRN_LIC_NO,DATA_TRFR,MAIN_USER,LOAN_TYPE,UNCHAK_DHRN_REC,  USER_UPDATE,USER_DELETE,RCUT_RATE,RCUT_AMT,RCUT_PAY_AMT,RCUT_OS_AMT) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), rsData.Rows[DC_Main.R]["CO_YEAR"]), (object)"','"), rsData.Rows[DC_Main.R]["CO_BOOK"]), (object)"','"), rsData.Rows[DC_Main.R]["VCH_NO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsData.Rows[DC_Main.R]["DHRN_BILL"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[DC_Main.R]["DHRN_DATE"]), "MM/dd/yyyy")), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["DHRN_MONTH"]);
					double num26 = DC_Main.Fnv(ref Value);
					dataRow["DHRN_MONTH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj26 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj25, (object)num26), (object)", "), (object)" '"), rsData.Rows[DC_Main.R]["BOOK_SNAME"]), (object)"','"), rsData.Rows[DC_Main.R]["BOOK_INOUT"]), (object)"','L','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rsData.Rows[DC_Main.R]["MAIN_BOOK"]), (object)"','"), rsData.Rows[DC_Main.R]["AC_CODE"]), (object)"','"), rsData.Rows[DC_Main.R]["AC_NAME"]), (object)"','"), rsData.Rows[DC_Main.R]["LEDR_ACCD"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[DC_Main.R]["FROM_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsData.Rows[DC_Main.R]["TO_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["DHRN_AMT"]);
					double num27 = DC_Main.Fnv(ref Value);
					dataRow["DHRN_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj27 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj26, (object)num27), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["DHRN_ADJ_AMT"]);
					double num28 = DC_Main.Fnv(ref Value);
					dataRow["DHRN_ADJ_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj28 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj27, (object)num28), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["DHRN_OS_AMT"]);
					double num29 = DC_Main.Fnv(ref Value);
					dataRow["DHRN_OS_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj29 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj28, (object)num29), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["DHRN_REC_AMT"]);
					double num30 = DC_Main.Fnv(ref Value);
					dataRow["DHRN_REC_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj30 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj29, (object)num30), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["DHRN_DAY"]);
					double num31 = DC_Main.Fnv(ref Value);
					dataRow["DHRN_DAY"] = RuntimeHelpers.GetObjectValue(Value);
					object obj31 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj30, (object)num31), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["INT_MONTH"]);
					double num32 = DC_Main.Fnv(ref Value);
					dataRow["INT_MONTH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj32 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj31, (object)num32), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["INT_DAY"]);
					double num33 = DC_Main.Fnv(ref Value);
					dataRow["INT_DAY"] = RuntimeHelpers.GetObjectValue(Value);
					object obj33 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj32, (object)num33), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["INT_PRC"]);
					double num34 = DC_Main.Fnv(ref Value);
					dataRow["INT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj34 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj33, (object)num34), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["INT_AMT"]);
					double num35 = DC_Main.Fnv(ref Value);
					dataRow["INT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj35 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj34, (object)num35), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["INT_REC_AMT"]);
					double num36 = DC_Main.Fnv(ref Value);
					dataRow["INT_REC_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj36 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj35, (object)num36), (object)", "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["KASAR_AMT"]);
					double num37 = DC_Main.Fnv(ref Value);
					dataRow["KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj37 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj36, (object)num37), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["GOLD_AMT"]);
					double num38 = DC_Main.Fnv(ref Value);
					dataRow["GOLD_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj38 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj37, (object)num38), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["GOLD_WT"]);
					double num39 = DC_Main.Fnv(ref Value);
					dataRow["GOLD_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj39 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj38, (object)num39), (object)",'"), (object)DC_Main.MLc_code), (object)"','"), rsData.Rows[DC_Main.R]["ISU_NO"]), (object)"','"), rsData.Rows[DC_Main.R]["ISU_DBCD"]), (object)"','"), rsData.Rows[DC_Main.R]["ISU_YRCD"]), (object)"','"), rsData.Rows[DC_Main.R]["VCH_DESC"]), (object)"','"), rsData.Rows[DC_Main.R]["EMP_CODE"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["MONTH_INT_AMT"]);
					double num40 = DC_Main.Fnv(ref Value);
					dataRow["MONTH_INT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj40 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj39, (object)num40), (object)", "), (object)" '"), rsData.Rows[DC_Main.R]["PACKET_NO"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["PAN_ADJ_AMT"]);
					double num41 = DC_Main.Fnv(ref Value);
					dataRow["PAN_ADJ_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj41 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj40, (object)num41), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["ADJ_INT"]);
					double num42 = DC_Main.Fnv(ref Value);
					dataRow["ADJ_INT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj42 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj41, (object)num42), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["ADJ_DHRN"]);
					double num43 = DC_Main.Fnv(ref Value);
					dataRow["ADJ_DHRN"] = RuntimeHelpers.GetObjectValue(Value);
					object obj43 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj42, (object)num43), (object)",'"), rsData.Rows[DC_Main.R]["HD_VCH_NO"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["ORNA_AMT"]);
					double num44 = DC_Main.Fnv(ref Value);
					dataRow["ORNA_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj44 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj43, (object)num44), (object)",'"), rsData.Rows[DC_Main.R]["DHRN_LIC_NO"]), (object)"','N','"), (object)DC_Main.MCo_User), (object)"','"), rsData.Rows[DC_Main.R]["LOAN_TYPE"]), (object)"','"), rsData.Rows[DC_Main.R]["UNCHAK_DHRN_REC"]), (object)"', "), (object)" '"), rsData.Rows[DC_Main.R]["USER_UPDATE"]), (object)"','"), rsData.Rows[DC_Main.R]["USER_DELETE"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["RCUT_RATE"]);
					double num45 = DC_Main.Fnv(ref Value);
					dataRow["RCUT_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj45 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj44, (object)num45), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["RCUT_AMT"]);
					double num46 = DC_Main.Fnv(ref Value);
					dataRow["RCUT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj46 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj45, (object)num46), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["RCUT_PAY_AMT"]);
					double num47 = DC_Main.Fnv(ref Value);
					dataRow["RCUT_PAY_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj47 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj46, (object)num47), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsData.Rows[DC_Main.R])["RCUT_OS_AMT"]);
					double num48 = DC_Main.Fnv(ref Value);
					dataRow["RCUT_OS_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj47, (object)num48), (object)")"));
					OpenRecordSetTrFr(DC_Main.RsQry);
					rsData = null;
					DC_Main.R++;
				}
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void BtnApr_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Data Transfer to Next Year ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.ExeQuteDc("UPDATE APR_DETL SET ISU_REC = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
			DC_Main.RsQry = "Update APR_DETL SET ISU_REC = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' And LC_CODE = '" + DC_Main.MLc_code + "' And EXISTS (Select 1 FROM (Select A.ISU_YRCD,A.ISU_DBCD,A.ISU_NO,A.ISU_SRNO From APR_DETL A  Where A.CO_CODE = '" + DC_Main.MCo_code + "' And A.LC_CODE = '" + DC_Main.MLc_code + "' And A.BOOK_NAME = 'APR RTN' And A.ISU_NO <> ''  UNION ALL Select B.ISU_YRCD,B.ISU_DBCD,B.ISU_NO,B.ISU_SRNO From SL_DETL B Where B.CO_CODE = '" + DC_Main.MCo_code + "' And B.LC_CODE = '" + DC_Main.MLc_code + "' And B.BOOK_NAME = 'SALES' And B.ISU_NO <> ''  UNION ALL Select C.ISU_YRCD,C.ISU_DBCD,C.ISU_NO,C.ISU_SRNO From RATE_CUT_ISU C Where C.CO_CODE = '" + DC_Main.MCo_code + "' And C.LC_CODE = '" + DC_Main.MLc_code + "' And C.BOOK_NAME = 'WH SALES' And C.ISU_NO <> ''  UNION ALL Select D.ISU_YRCD,D.ISU_DBCD,D.ISU_NO,D.ISU_SRNO From RATE_CUT_ISU D Where D.CO_CODE = '" + DC_Main.MCo_code + "' And D.LC_CODE = '" + DC_Main.MLc_code + "' And D.BOOK_NAME = 'RATE CUT' And D.ISU_NO <> '' ) AS X  WHERE X.ISU_YRCD = APR_DETL.CO_YEAR And X.ISU_DBCD = APR_DETL.CO_BOOK And X.ISU_NO = APR_DETL.VCH_NO And X.ISU_SRNO = APR_DETL.OLD_SRNO )";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("UPDATE BAR_DETL SET APR_ISU = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
			DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.APR_ISU = 'Y' FROM BAR_DETL,APR_DETL AS B WHERE BAR_DETL.CO_CODE = B.CO_CODE AND BAR_DETL.TAG_NO = B.TAG_NO AND BAR_DETL.VCH_SRNO = B.VCH_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.ISU_REC = 'N'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Rtl_AcMast();
			Rtl_Approval();
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
		}
	}

	private void Rtl_Approval()
	{
		int num = 0;
		ExeQuteTrfr("DELETE FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
		ExeQuteTrfr("DELETE FROM APR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
		ExeQuteTrfr("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '218'");
		ExeQuteTrfr("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '218'");
		DC_Main.RsQry = "SELECT A.* FROM APR_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.MAIN_BOOK = 'APR ISU' AND ISU_REC = 'N'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Approvel Isu";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO APR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,AC_CODE,VCH_TIME,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,NET_AMT,  ITM_REMARK,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_NAME,RATE_TYPE,IT_TYPE,  PR_CODE,HD_VCH_NO,MAIN_USER,ISU_REC,ISU_NO,ISU_YRCD,ISU_DBCD,ISU_SRNO,ISU_AC_CODE,ISU_AC_NAME,MTL_COLOR,ADJ_GWT,ADJ_NWT,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,  ITM_COLOR,ORNA_REC_DATE,EMP_CODE,ITM_LESS_TCH,ITM_LOSS_WT,EMP_SALE,DESIGN_IMG_ID) VALUES  ('", rshlp.Rows[DC_Main.M]["CO_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["LC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"','"), rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["SR_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["OLD_SRNO"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["VCH_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["INOUT_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["ENTRY_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["BOOK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["IT_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["TAG_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["LOT_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["DESIGN_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["TBL_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["ITM_SIZE"]), (object)"', "), (object)" ");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ITM_PCS"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["ITM_PCS"] = RuntimeHelpers.GetObjectValue(Value);
				object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num2), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["BAG_WT"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["BAG_WT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num3), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ITM_GWT"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num4), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ITM_OTH_WT"]);
				double num5 = DC_Main.Fnv(ref Value);
				dataRow["ITM_OTH_WT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num5), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ITM_NWT"]);
				double num6 = DC_Main.Fnv(ref Value);
				dataRow["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num6), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ITM_GHT_WT"]);
				double num7 = DC_Main.Fnv(ref Value);
				dataRow["ITM_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj7 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num7), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ITM_TOUCH"]);
				double num8 = DC_Main.Fnv(ref Value);
				dataRow["ITM_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
				object obj8 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, (object)num8), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ITM_WEST_PRC"]);
				double num9 = DC_Main.Fnv(ref Value);
				dataRow["ITM_WEST_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				object obj9 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj8, (object)num9), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ITM_FINE"]);
				double num10 = DC_Main.Fnv(ref Value);
				dataRow["ITM_FINE"] = RuntimeHelpers.GetObjectValue(Value);
				object obj10 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj9, (object)num10), (object)", "), (object)" ");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["LBR_PRC"]);
				double num11 = DC_Main.Fnv(ref Value);
				dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				object obj11 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj10, (object)num11), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["LBR_RATE"]);
				double num12 = DC_Main.Fnv(ref Value);
				dataRow["LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
				object obj12 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj11, (object)num12), (object)",'"), rshlp.Rows[DC_Main.M]["LBR_TYPE"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["LBR_AMT"]);
				double num13 = DC_Main.Fnv(ref Value);
				dataRow["LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj13 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj12, (object)num13), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["OTH_AMT"]);
				double num14 = DC_Main.Fnv(ref Value);
				dataRow["OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj14 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj13, (object)num14), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ITM_RATE"]);
				double num15 = DC_Main.Fnv(ref Value);
				dataRow["ITM_RATE"] = RuntimeHelpers.GetObjectValue(Value);
				object obj15 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj14, (object)num15), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ITM_AMT"]);
				double num16 = DC_Main.Fnv(ref Value);
				dataRow["ITM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj16 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj15, (object)num16), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["TAG_COST"]);
				double num17 = DC_Main.Fnv(ref Value);
				dataRow["TAG_COST"] = RuntimeHelpers.GetObjectValue(Value);
				object obj17 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj16, (object)num17), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ITM_MRP"]);
				double num18 = DC_Main.Fnv(ref Value);
				dataRow["ITM_MRP"] = RuntimeHelpers.GetObjectValue(Value);
				object obj18 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj17, (object)num18), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["NET_AMT"]);
				double num19 = DC_Main.Fnv(ref Value);
				dataRow["NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj19 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj18, (object)num19), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["ITM_REMARK"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["VCH_SRNO"]);
				double num20 = DC_Main.Fnv(ref Value);
				dataRow["VCH_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
				object obj20 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj19, (object)num20), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["KR_NET_WT"]);
				double num21 = DC_Main.Fnv(ref Value);
				dataRow["KR_NET_WT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj21 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj20, (object)num21), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["KR_TOUCH"]);
				double num22 = DC_Main.Fnv(ref Value);
				dataRow["KR_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
				object obj22 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj21, (object)num22), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["KR_WEST_PRC"]);
				double num23 = DC_Main.Fnv(ref Value);
				dataRow["KR_WEST_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				object obj23 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj22, (object)num23), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["KR_FINE"]);
				double num24 = DC_Main.Fnv(ref Value);
				dataRow["KR_FINE"] = RuntimeHelpers.GetObjectValue(Value);
				object obj24 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj23, (object)num24), (object)",'"), rshlp.Rows[DC_Main.M]["KR_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["RATE_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.M]["IT_TYPE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.M]["PR_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["HD_VCH_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["MAIN_USER"]), (object)"','"), rshlp.Rows[DC_Main.M]["ISU_REC"]), (object)"','"), rshlp.Rows[DC_Main.M]["ISU_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["ISU_YRCD"]), (object)"','"), rshlp.Rows[DC_Main.M]["ISU_DBCD"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ISU_SRNO"]);
				double num25 = DC_Main.Fnv(ref Value);
				dataRow["ISU_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
				object obj25 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj24, (object)num25), (object)",'"), rshlp.Rows[DC_Main.M]["ISU_AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["ISU_AC_NAME"]), (object)"','"), rshlp.Rows[DC_Main.M]["MTL_COLOR"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ADJ_GWT"]);
				double num26 = DC_Main.Fnv(ref Value);
				dataRow["ADJ_GWT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj26 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj25, (object)num26), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ADJ_NWT"]);
				double num27 = DC_Main.Fnv(ref Value);
				dataRow["ADJ_NWT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj27 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj26, (object)num27), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["HM_ID"]), (object)"','"), rshlp.Rows[DC_Main.M]["HM_ID2"]), (object)"','"), rshlp.Rows[DC_Main.M]["HM_ID3"]), (object)"','"), rshlp.Rows[DC_Main.M]["HM_ID4"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["HM_ID_WT"]);
				double num28 = DC_Main.Fnv(ref Value);
				dataRow["HM_ID_WT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj28 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj27, (object)num28), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["HM_ID2_WT"]);
				double num29 = DC_Main.Fnv(ref Value);
				dataRow["HM_ID2_WT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj29 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj28, (object)num29), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["HM_ID3_WT"]);
				double num30 = DC_Main.Fnv(ref Value);
				dataRow["HM_ID3_WT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj30 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj29, (object)num30), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["HM_ID4_WT"]);
				double num31 = DC_Main.Fnv(ref Value);
				dataRow["HM_ID4_WT"] = RuntimeHelpers.GetObjectValue(Value);
				object obj31 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj30, (object)num31), (object)", "), (object)" '"), rshlp.Rows[DC_Main.M]["ITM_COLOR"]), (object)"',NULL,'"), rshlp.Rows[DC_Main.M]["EMP_CODE"]), (object)"',");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ITM_LESS_TCH"]);
				double num32 = DC_Main.Fnv(ref Value);
				dataRow["ITM_LESS_TCH"] = RuntimeHelpers.GetObjectValue(Value);
				object obj32 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj31, (object)num32), (object)",");
				Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.M])["ITM_LOSS_WT"]);
				double num33 = DC_Main.Fnv(ref Value);
				dataRow["ITM_LOSS_WT"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj32, (object)num33), (object)",'"), rshlp.Rows[DC_Main.M]["EMP_SALE"]), (object)"','"), rshlp.Rows[DC_Main.M]["DESIGN_IMG_ID"]), (object)"')"));
				OpenRecordSetTrFr(DC_Main.RsQry);
				rshlp = null;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM APR_IDTL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR  = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' And VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND SR_NO = "), DC_Main.Rshlp.Rows[DC_Main.M]["SR_NO"]), (object)" ORDER BY A.ISR_NO "));
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < RsDetl.Rows.Count)
				{
					object obj33 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO APR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,  DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,  IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER,  DM_ORIGIN,DM_REMARK,DM_COLOR,DM_NAME) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','"), RsDetl.Rows[DC_Main.R]["CO_YEAR"]), (object)"','"), RsDetl.Rows[DC_Main.R]["CO_BOOK"]), (object)"','"), RsDetl.Rows[DC_Main.R]["VCH_NO"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["SR_NO"]);
					double num34 = DC_Main.Fnv(ref Value);
					dataRow["SR_NO"] = RuntimeHelpers.GetObjectValue(Value);
					object obj34 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj33, (object)num34), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["ISR_NO"]);
					double num35 = DC_Main.Fnv(ref Value);
					dataRow["ISR_NO"] = RuntimeHelpers.GetObjectValue(Value);
					object obj35 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj34, (object)num35), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), RsDetl.Rows[DC_Main.R]["VCH_TYPE"]), (object)"','"), RsDetl.Rows[DC_Main.R]["INOUT_TYPE"]), (object)"','"), RsDetl.Rows[DC_Main.R]["ENTRY_TYPE"]), (object)"','"), RsDetl.Rows[DC_Main.R]["BOOK_NAME"]), (object)"','"), RsDetl.Rows[DC_Main.R]["AC_CODE"]), (object)"','"), RsDetl.Rows[DC_Main.R]["TAG_NO"]), (object)"',"), RsDetl.Rows[DC_Main.R]["VCH_SRNO"]), (object)",'"), RsDetl.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), RsDetl.Rows[DC_Main.R]["IT_TYPE"]), (object)"', "), (object)" '"), RsDetl.Rows[DC_Main.R]["DM_CODE"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_SIZE"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_SFNO"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_LEB"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_PCS"]);
					double num36 = DC_Main.Fnv(ref Value);
					dataRow["IT_PCS"] = RuntimeHelpers.GetObjectValue(Value);
					object obj36 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj35, (object)num36), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_PCS_WT"]);
					double num37 = DC_Main.Fnv(ref Value);
					dataRow["IT_PCS_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj37 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj36, (object)num37), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_WT"]);
					double num38 = DC_Main.Fnv(ref Value);
					dataRow["KR_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj38 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj37, (object)num38), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_LESS_PRC"]);
					double num39 = DC_Main.Fnv(ref Value);
					dataRow["KR_LESS_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj39 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj38, (object)num39), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_GWT"]);
					double num40 = DC_Main.Fnv(ref Value);
					dataRow["IT_GWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj40 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj39, (object)num40), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_CON_PRC"]);
					double num41 = DC_Main.Fnv(ref Value);
					dataRow["IT_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj41 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj40, (object)num41), (object)", "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_CON_WT"]);
					double num42 = DC_Main.Fnv(ref Value);
					dataRow["IT_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj42 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj41, (object)num42), (object)",'"), RsDetl.Rows[DC_Main.R]["IT_RATE_TYPE"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_RATE"]);
					double num43 = DC_Main.Fnv(ref Value);
					dataRow["IT_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj43 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj42, (object)num43), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_AMT"]);
					double num44 = DC_Main.Fnv(ref Value);
					dataRow["IT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj44 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj43, (object)num44), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_LBR_RATE"]);
					double num45 = DC_Main.Fnv(ref Value);
					dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj45 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj44, (object)num45), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_LBR_AMT"]);
					double num46 = DC_Main.Fnv(ref Value);
					dataRow["IT_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj46 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj45, (object)num46), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_NET_AMT"]);
					double num47 = DC_Main.Fnv(ref Value);
					dataRow["IT_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj47 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj46, (object)num47), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_CON_PRC"]);
					double num48 = DC_Main.Fnv(ref Value);
					dataRow["KR_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj48 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj47, (object)num48), (object)", "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_CON_WT"]);
					double num49 = DC_Main.Fnv(ref Value);
					dataRow["KR_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj49 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj48, (object)num49), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_RATE"]);
					double num50 = DC_Main.Fnv(ref Value);
					dataRow["KR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj50 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj49, (object)num50), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_AMT"]);
					double num51 = DC_Main.Fnv(ref Value);
					dataRow["KR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj51 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj50, (object)num51), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_LBR_RATE"]);
					double num52 = DC_Main.Fnv(ref Value);
					dataRow["KR_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj52 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj51, (object)num52), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_LBR_AMT"]);
					double num53 = DC_Main.Fnv(ref Value);
					dataRow["KR_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj53 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj52, (object)num53), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_NET_AMT"]);
					double num54 = DC_Main.Fnv(ref Value);
					dataRow["KR_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj54 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj53, (object)num54), (object)",'");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["MAIN_USER"]);
					double num55 = DC_Main.Fnv(ref Value);
					dataRow["MAIN_USER"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj54, (object)num55), (object)"', "), (object)" '"), RsDetl.Rows[DC_Main.R]["DM_ORIGIN"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_REMARK"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_COLOR"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_NAME"]), (object)"')"));
					OpenRecordSetTrFr(DC_Main.RsQry);
					DC_Main.R++;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_SRNO"]), (object)" ORDER BY VCH_TIME DESC"));
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (RsDetl.Rows.Count > 0)
				{
					DataTable rsDetl = RsDetl;
					object obj55 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BAR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,  TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,  ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,  KR_NAME,KR_OTH_WT,KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,  KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,TAG_SRNO,VCH_SRNO,RATE_TYPE,IT_TYPE,  TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,ORD_AC,MAIN_USER,ADD_USER,DATA_TRFR,  HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,HM_ID,HM_ID2,HM_ID3,HM_ID4,  HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,DATA_TYPE,APP_TRFR,  ITM_COLOR,MAIN_MARGIN_PRC,MAIN_MRP,JDT_JDT_WT,JDT_GHT_WT,JDT_KUN_WT,JDT_WAX_WT,KR_WAX_WT,  JDT_KUN_TOUCH,JDT_KUN_NET,EMP_ISU,LBR_CODE,DESIGN_IMG_ID) VALUES  ('", rsDetl.Rows[0]["CO_CODE"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), (object)tYearCode.Text), (object)"','218','00001',"), (object)DC_Main.M), (object)","), (object)DC_Main.M), (object)", "), (object)" '"), (object)Strings.Format((object)mTrfr_dt.AddDays(-1.0), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[0]["STK_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rsDetl.Rows[0]["STK_DATE"]), "MM/dd/yyyy HH:mm:ss")), (object)"','APRTG','I','O','APR TAG','"), rsDetl.Rows[0]["AC_CODE"]), (object)"','"), rsDetl.Rows[0]["IT_CODE"]), (object)"', "), (object)" '"), rsDetl.Rows[0]["TAG_NO"]), (object)"','','"), rsDetl.Rows[0]["DESIGN_NO"]), (object)"','"), rsDetl.Rows[0]["TBL_CODE"]), (object)"','"), rsDetl.Rows[0]["ITM_SIZE"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["ITM_PCS"]);
					double num56 = DC_Main.Fnv(ref Value);
					dataRow["ITM_PCS"] = RuntimeHelpers.GetObjectValue(Value);
					object obj56 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj55, (object)num56), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["BAG_WT"]);
					double num57 = DC_Main.Fnv(ref Value);
					dataRow["BAG_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj57 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj56, (object)num57), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["ITM_GWT"]);
					double num58 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj58 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj57, (object)num58), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["ITM_GWT"]);
					double num59 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj59 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj58, (object)num59), (object)"-");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["ITM_NWT"]);
					double num60 = DC_Main.Fnv(ref Value);
					dataRow["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj60 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj59, (object)num60), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["ITM_NWT"]);
					double num61 = DC_Main.Fnv(ref Value);
					dataRow["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj61 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj60, (object)num61), (object)", "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["ITM_GHT_PRC"]);
					double num62 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GHT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj62 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj61, (object)num62), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["ITM_GHT_WT"]);
					double num63 = DC_Main.Fnv(ref Value);
					dataRow["ITM_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj63 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj62, (object)num63), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["ITM_TOUCH"]);
					double num64 = DC_Main.Fnv(ref Value);
					dataRow["ITM_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj64 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj63, (object)num64), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["ITM_WEST_PRC"]);
					double num65 = DC_Main.Fnv(ref Value);
					dataRow["ITM_WEST_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj65 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj64, (object)num65), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["ITM_FINE"]);
					double num66 = DC_Main.Fnv(ref Value);
					dataRow["ITM_FINE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj66 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj65, (object)num66), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["LBR_PRC"]);
					double num67 = DC_Main.Fnv(ref Value);
					dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj67 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj66, (object)num67), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["LBR_RATE"]);
					double num68 = DC_Main.Fnv(ref Value);
					dataRow["LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj68 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj67, (object)num68), (object)",'"), rsDetl.Rows[0]["LBR_TYPE"]), (object)"', "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["LBR_AMT"]);
					double num69 = DC_Main.Fnv(ref Value);
					dataRow["LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj69 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj68, (object)num69), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["OTH_AMT"]);
					double num70 = DC_Main.Fnv(ref Value);
					dataRow["OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj70 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj69, (object)num70), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["ITM_RATE"]);
					double num71 = DC_Main.Fnv(ref Value);
					dataRow["ITM_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj71 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj70, (object)num71), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["ITM_AMT"]);
					double num72 = DC_Main.Fnv(ref Value);
					dataRow["ITM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj72 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj71, (object)num72), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["TAG_COST"]);
					double num73 = DC_Main.Fnv(ref Value);
					dataRow["TAG_COST"] = RuntimeHelpers.GetObjectValue(Value);
					object obj73 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj72, (object)num73), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["ITM_MARGIN"]);
					double num74 = DC_Main.Fnv(ref Value);
					dataRow["ITM_MARGIN"] = RuntimeHelpers.GetObjectValue(Value);
					object obj74 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj73, (object)num74), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["ITM_MRP"]);
					double num75 = DC_Main.Fnv(ref Value);
					dataRow["ITM_MRP"] = RuntimeHelpers.GetObjectValue(Value);
					object obj75 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj74, (object)num75), (object)",'"), rsDetl.Rows[0]["ITM_REMARK"]), (object)"','"), rsDetl.Rows[0]["SF_NO"]), (object)"', "), (object)" '"), rsDetl.Rows[0]["KR_NAME"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["KR_OTH_WT"]);
					double num76 = DC_Main.Fnv(ref Value);
					dataRow["KR_OTH_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj76 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj75, (object)num76), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["KR_NET_WT"]);
					double num77 = DC_Main.Fnv(ref Value);
					dataRow["KR_NET_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj77 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj76, (object)num77), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["KR_GHT_PRC"]);
					double num78 = DC_Main.Fnv(ref Value);
					dataRow["KR_GHT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj78 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj77, (object)num78), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["KR_GHT_WT"]);
					double num79 = DC_Main.Fnv(ref Value);
					dataRow["KR_GHT_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj79 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj78, (object)num79), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["KR_TOUCH"]);
					double num80 = DC_Main.Fnv(ref Value);
					dataRow["KR_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
					object obj80 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj79, (object)num80), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["KR_WEST_PRC"]);
					double num81 = DC_Main.Fnv(ref Value);
					dataRow["KR_WEST_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj81 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj80, (object)num81), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["KR_FINE"]);
					double num82 = DC_Main.Fnv(ref Value);
					dataRow["KR_FINE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj82 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj81, (object)num82), (object)", "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["KR_LBR_RATE"]);
					double num83 = DC_Main.Fnv(ref Value);
					dataRow["KR_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj83 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj82, (object)num83), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["KR_LBR_AMT"]);
					double num84 = DC_Main.Fnv(ref Value);
					dataRow["KR_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj84 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj83, (object)num84), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["KR_OTH_AMT"]);
					double num85 = DC_Main.Fnv(ref Value);
					dataRow["KR_OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj85 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj84, (object)num85), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["KR_COST"]);
					double num86 = DC_Main.Fnv(ref Value);
					dataRow["KR_COST"] = RuntimeHelpers.GetObjectValue(Value);
					object obj86 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj85, (object)num86), (object)",1,");
					Value = RuntimeHelpers.GetObjectValue((dataRow = rsDetl.Rows[0])["VCH_SRNO"]);
					double num87 = DC_Main.Fnv(ref Value);
					dataRow["VCH_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					object obj87 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj86, (object)num87), (object)",'"), rsDetl.Rows[0]["RATE_TYPE"]), (object)"','"), rsDetl.Rows[0]["IT_TYPE"]), (object)"', "), (object)" '"), rsDetl.Rows[0]["TAG_TYPE"]), (object)"','"), rsDetl.Rows[0]["PR_CODE"]), (object)"','Y','','0','','','','"), (object)DC_Main.MCo_User), (object)"','"), (object)DC_Main.MCo_User), (object)"','N', "), (object)" '"), rsDetl.Rows[0]["HD_VCH_NO"]), (object)"','"), rsDetl.Rows[0]["OLD_VCH_NO"]), (object)"','"), rsDetl.Rows[0]["NEW_VCH_NO"]), (object)"','"), rsDetl.Rows[0]["HM_ID"]), (object)""), (object)"','"), rsDetl.Rows[0]["HM_ID2"]), (object)""), (object)"','"), rsDetl.Rows[0]["HM_ID3"]), (object)""), (object)"','"), rsDetl.Rows[0]["HM_ID4"]), (object)""), (object)"', "), (object)" ");
					Value = Operators.ConcatenateObject(rsDetl.Rows[0]["HM_ID_WT"], (object)"");
					object obj88 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj87, (object)DC_Main.Fnv(ref Value)), (object)",");
					Value = Operators.ConcatenateObject(rsDetl.Rows[0]["HM_ID2_WT"], (object)"");
					object obj89 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj88, (object)DC_Main.Fnv(ref Value)), (object)",");
					Value = Operators.ConcatenateObject(rsDetl.Rows[0]["HM_ID3_WT"], (object)"");
					object obj90 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj89, (object)DC_Main.Fnv(ref Value)), (object)",");
					Value = Operators.ConcatenateObject(rsDetl.Rows[0]["HM_ID4_WT"], (object)"");
					object obj91 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj90, (object)DC_Main.Fnv(ref Value)), (object)",'"), rsDetl.Rows[0]["DATA_TYPE"]), (object)"','"), rsDetl.Rows[0]["APP_TRFR"]), (object)"', "), (object)" '"), rsDetl.Rows[0]["ITM_COLOR"]), (object)"',");
					Value = Operators.ConcatenateObject(rsDetl.Rows[0]["MAIN_MARGIN_PRC"], (object)"");
					object obj92 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj91, (object)DC_Main.Fnv(ref Value)), (object)",");
					Value = Operators.ConcatenateObject(rsDetl.Rows[0]["MAIN_MRP"], (object)"");
					object obj93 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj92, (object)DC_Main.Fnv(ref Value)), (object)",");
					Value = Operators.ConcatenateObject(rsDetl.Rows[0]["JDT_JDT_WT"], (object)"");
					object obj94 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj93, (object)DC_Main.Fnv(ref Value)), (object)",");
					Value = Operators.ConcatenateObject(rsDetl.Rows[0]["JDT_GHT_WT"], (object)"");
					object obj95 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj94, (object)DC_Main.Fnv(ref Value)), (object)",");
					Value = Operators.ConcatenateObject(rsDetl.Rows[0]["JDT_KUN_WT"], (object)"");
					object obj96 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj95, (object)DC_Main.Fnv(ref Value)), (object)",");
					Value = Operators.ConcatenateObject(rsDetl.Rows[0]["JDT_WAX_WT"], (object)"");
					object obj97 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj96, (object)DC_Main.Fnv(ref Value)), (object)",");
					Value = Operators.ConcatenateObject(rsDetl.Rows[0]["KR_WAX_WT"], (object)"");
					object obj98 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj97, (object)DC_Main.Fnv(ref Value)), (object)", "), (object)" ");
					Value = Operators.ConcatenateObject(rsDetl.Rows[0]["JDT_KUN_TOUCH"], (object)"");
					object obj99 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj98, (object)DC_Main.Fnv(ref Value)), (object)",");
					Value = Operators.ConcatenateObject(rsDetl.Rows[0]["JDT_KUN_NET"], (object)"");
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj99, (object)DC_Main.Fnv(ref Value)), (object)",'"), rsDetl.Rows[0]["EMP_ISU"]), (object)"','"), rsDetl.Rows[0]["LBR_CODE"]), (object)"','"), rsDetl.Rows[0]["DESIGN_IMG_ID"]), (object)"')"));
					ExeQuteTrfr(DC_Main.RsQry);
					rsDetl = null;
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_TYPE FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_SRNO"]), (object)" ORDER BY A.ISR_NO "));
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				while (DC_Main.R < RsDetl.Rows.Count)
				{
					object obj100 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,  DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,  IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER,  DM_NAME,DM_ORIGIN,DM_REMARK,DM_COLOR,KR_ACT_WT,KR_ACT_PRC) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','218','00001'," + Conversions.ToString(DC_Main.M) + "," + Conversions.ToString(DC_Main.R + 1) + ",'" + Strings.Format((object)mTrfr_dt.AddDays(-1.0), "MM/dd/yyyy") + "',  'APRTG','I','O','APR TAG','"), RsDetl.Rows[DC_Main.R]["AC_CODE"]), (object)"','"), RsDetl.Rows[DC_Main.R]["TAG_NO"]), (object)"',"), RsDetl.Rows[DC_Main.R]["VCH_SRNO"]), (object)",'"), RsDetl.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), RsDetl.Rows[DC_Main.R]["IT_TYPE"]), (object)"', "), (object)" '"), RsDetl.Rows[DC_Main.R]["DM_CODE"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_SIZE"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_SFNO"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_LEB"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_PCS"]);
					double num88 = DC_Main.Fnv(ref Value);
					dataRow["IT_PCS"] = RuntimeHelpers.GetObjectValue(Value);
					object obj101 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj100, (object)num88), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_PCS_WT"]);
					double num89 = DC_Main.Fnv(ref Value);
					dataRow["IT_PCS_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj102 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj101, (object)num89), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_WT"]);
					double num90 = DC_Main.Fnv(ref Value);
					dataRow["KR_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj103 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj102, (object)num90), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_LESS_PRC"]);
					double num91 = DC_Main.Fnv(ref Value);
					dataRow["KR_LESS_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj104 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj103, (object)num91), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_GWT"]);
					double num92 = DC_Main.Fnv(ref Value);
					dataRow["IT_GWT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj105 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj104, (object)num92), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_CON_PRC"]);
					double num93 = DC_Main.Fnv(ref Value);
					dataRow["IT_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj106 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj105, (object)num93), (object)", "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_CON_WT"]);
					double num94 = DC_Main.Fnv(ref Value);
					dataRow["IT_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj107 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj106, (object)num94), (object)",'"), RsDetl.Rows[DC_Main.R]["IT_RATE_TYPE"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_RATE"]);
					double num95 = DC_Main.Fnv(ref Value);
					dataRow["IT_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj108 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj107, (object)num95), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_AMT"]);
					double num96 = DC_Main.Fnv(ref Value);
					dataRow["IT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj109 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj108, (object)num96), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_LBR_RATE"]);
					double num97 = DC_Main.Fnv(ref Value);
					dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj110 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj109, (object)num97), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_LBR_AMT"]);
					double num98 = DC_Main.Fnv(ref Value);
					dataRow["IT_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj111 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj110, (object)num98), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_NET_AMT"]);
					double num99 = DC_Main.Fnv(ref Value);
					dataRow["IT_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj112 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj111, (object)num99), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_CON_PRC"]);
					double num100 = DC_Main.Fnv(ref Value);
					dataRow["KR_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					object obj113 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj112, (object)num100), (object)", "), (object)" ");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_CON_WT"]);
					double num101 = DC_Main.Fnv(ref Value);
					dataRow["KR_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj114 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj113, (object)num101), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_RATE"]);
					double num102 = DC_Main.Fnv(ref Value);
					dataRow["KR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj115 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj114, (object)num102), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_AMT"]);
					double num103 = DC_Main.Fnv(ref Value);
					dataRow["KR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj116 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj115, (object)num103), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_LBR_RATE"]);
					double num104 = DC_Main.Fnv(ref Value);
					dataRow["KR_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
					object obj117 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj116, (object)num104), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_LBR_AMT"]);
					double num105 = DC_Main.Fnv(ref Value);
					dataRow["KR_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj118 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj117, (object)num105), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_NET_AMT"]);
					double num106 = DC_Main.Fnv(ref Value);
					dataRow["KR_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj119 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj118, (object)num106), (object)",'");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["MAIN_USER"]);
					double num107 = DC_Main.Fnv(ref Value);
					dataRow["MAIN_USER"] = RuntimeHelpers.GetObjectValue(Value);
					object obj120 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj119, (object)num107), (object)"', "), (object)" '"), RsDetl.Rows[DC_Main.R]["DM_NAME"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_ORIGIN"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_REMARK"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_COLOR"]), (object)"',");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_ACT_WT"]);
					double num108 = DC_Main.Fnv(ref Value);
					dataRow["KR_ACT_WT"] = RuntimeHelpers.GetObjectValue(Value);
					object obj121 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj120, (object)num108), (object)",");
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_ACT_PRC"]);
					double num109 = DC_Main.Fnv(ref Value);
					dataRow["KR_ACT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj121, (object)num109), (object)")"));
					OpenRecordSetTrFr(DC_Main.RsQry);
					DC_Main.R++;
				}
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void btnBillOs_Click(object sender, EventArgs e)
	{
		//IL_0905: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		DataTable dataTable = default(DataTable);
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
						ExeQuteTrfr("DELETE FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
						goto IL_0054;
					case 2456:
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
								goto IL_0054;
							case 3:
								goto IL_008e;
							case 4:
								goto IL_009f;
							case 5:
								goto IL_00ae;
							case 6:
								goto IL_00cb;
							case 7:
								goto IL_00de;
							case 8:
								goto IL_00e6;
							case 11:
								goto IL_00f3;
							case 12:
								goto IL_01ba;
							case 13:
								goto IL_01cd;
							case 14:
								goto IL_01d6;
							case 17:
								goto IL_01e5;
							case 18:
								goto IL_01ef;
							case 19:
								goto IL_083e;
							case 20:
								goto IL_084d;
							case 21:
								goto IL_085d;
							case 15:
							case 16:
							case 22:
								goto IL_0860;
							case 23:
								goto IL_0883;
							case 24:
								goto IL_0892;
							case 25:
								goto IL_08ad;
							case 9:
							case 10:
							case 26:
								goto IL_08b7;
							case 27:
								goto IL_08d9;
							case 28:
								goto IL_08e7;
							case 29:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 30:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_083e:
						num2 = 19;
						OpenRecordSetTrFr(DC_Main.RsQry);
						goto IL_084d;
						IL_084d:
						num2 = 20;
						DC_Main.R++;
						goto IL_085d;
						IL_01ef:
						num2 = 18;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO BILL_OS_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,LD_CODE,BILL_AMT,REC_AMT,KASAR_AMT,BILL_GOLD,REC_GOLD,KASAR_GOLD,BILL_SILVER,REC_SILVER,KASAR_SILVER,BILL_LC,BILL_YRCD,  BILL_DBCD,BILL_NO,BILL_HD_VCH_NO,MAIN_USER,DATA_TRFR,DATA_TYPE,OLD_ADJ_AMT,OLD_ADJ_GOLD,OLD_ADJ_SILVER,HD_VCH_NO,BILL_SRNO,  OLD_VCH_NO,NEW_VCH_NO) VALUES  ('", dataTable.Rows[DC_Main.R]["CO_CODE"]), (object)"','"), (object)DC_Main.MLc_code), (object)"','"), dataTable.Rows[DC_Main.R]["CO_YEAR"]), (object)"','"), dataTable.Rows[DC_Main.R]["CO_BOOK"]), (object)"','"), dataTable.Rows[DC_Main.R]["VCH_NO"]), (object)"',"), dataTable.Rows[DC_Main.R]["SR_NO"]), (object)",'"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.R]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.R]["VCH_TIME"]), "MM/dd/yyyy HH:mm:ss")), (object)"','"), dataTable.Rows[DC_Main.R]["VCH_TYPE"]), (object)"','"), dataTable.Rows[DC_Main.R]["INOUT_TYPE"]), (object)"','"), dataTable.Rows[DC_Main.R]["ENTRY_TYPE"]), (object)"','"), dataTable.Rows[DC_Main.R]["BOOK_NAME"]), (object)"', "), (object)" '"), dataTable.Rows[DC_Main.R]["AC_CODE"]), (object)"','"), dataTable.Rows[DC_Main.R]["LD_CODE"]), (object)"',"), dataTable.Rows[DC_Main.R]["BILL_AMT"]), (object)","), dataTable.Rows[DC_Main.R]["REC_AMT"]), (object)","), dataTable.Rows[DC_Main.R]["KASAR_AMT"]), (object)","), dataTable.Rows[DC_Main.R]["BILL_GOLD"]), (object)","), dataTable.Rows[DC_Main.R]["REC_GOLD"]), (object)","), dataTable.Rows[DC_Main.R]["KASAR_GOLD"]), (object)","), dataTable.Rows[DC_Main.R]["BILL_SILVER"]), (object)","), dataTable.Rows[DC_Main.R]["REC_SILVER"]), (object)","), dataTable.Rows[DC_Main.R]["KASAR_SILVER"]), (object)",'"), dataTable.Rows[DC_Main.R]["BILL_LC"]), (object)"','"), dataTable.Rows[DC_Main.R]["BILL_YRCD"]), (object)"', "), (object)" '"), dataTable.Rows[DC_Main.R]["BILL_DBCD"]), (object)"','"), dataTable.Rows[DC_Main.R]["BILL_NO"]), (object)"','"), dataTable.Rows[DC_Main.R]["BILL_HD_VCH_NO"]), (object)"','"), dataTable.Rows[DC_Main.R]["MAIN_USER"]), (object)"','"), dataTable.Rows[DC_Main.R]["DATA_TRFR"]), (object)"','"), dataTable.Rows[DC_Main.R]["DATA_TYPE"]), (object)"',"), dataTable.Rows[DC_Main.R]["OLD_ADJ_AMT"]), (object)","), dataTable.Rows[DC_Main.R]["OLD_ADJ_GOLD"]), (object)","), dataTable.Rows[DC_Main.R]["OLD_ADJ_SILVER"]), (object)",'"), dataTable.Rows[DC_Main.R]["HD_VCH_NO"]), (object)"',"), dataTable.Rows[DC_Main.R]["BILL_SRNO"]), (object)", "), (object)" '"), dataTable.Rows[DC_Main.R]["OLD_VCH_NO"]), (object)"','"), dataTable.Rows[DC_Main.R]["NEW_VCH_NO"]), (object)"')"));
						goto IL_083e;
						IL_085d:
						dataTable = null;
						goto IL_0860;
						IL_0054:
						num2 = 2;
						DC_Main.RsQry = "SELECT B.BOOK_NAME,BILL_LC,BILL_YRCD,BILL_DBCD,BILL_NO,BILL_AMT,BILL_HD_VCH_NO,SUM(REC_AMT) As AdjAmt,SUM(KASAR_AMT) As KsrAmt FROM BILL_OS_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.BILL_DBCD = B.CO_BOOK AND A.LC_CODE = B.LC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY  B.BOOK_NAME,BILL_LC,BILL_YRCD,BILL_DBCD,BILL_NO,BILL_HD_VCH_NO,BILL_AMT HAVING (BILL_AMT) - (SUM(REC_AMT)+SUM(KASAR_AMT)) > 0 ORDER BY BILL_LC,BILL_YRCD,BILL_DBCD,BILL_NO";
						goto IL_008e;
						IL_008e:
						num2 = 3;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_009f;
						IL_009f:
						num2 = 4;
						ProgressBar1.Value = 0;
						goto IL_00ae;
						IL_00ae:
						num2 = 5;
						ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
						goto IL_00cb;
						IL_00cb:
						num2 = 6;
						lblBook.Text = "Bill Wise Os";
						goto IL_00de;
						IL_00de:
						num2 = 7;
						Application.DoEvents();
						goto IL_00e6;
						IL_00e6:
						num2 = 8;
						DC_Main.M = 0;
						goto IL_08b7;
						IL_08b7:
						num2 = 10;
						if (DC_Main.M < DC_Main.Rshlp.Rows.Count)
						{
							goto IL_00f3;
						}
						goto IL_08d9;
						IL_08d9:
						num2 = 27;
						DC_Main.Rshlp.Clear();
						goto IL_08e7;
						IL_08e7:
						num2 = 28;
						DC_Main.Rshlp.Columns.Clear();
						break;
						IL_00f3:
						num2 = 11;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM BILL_OS_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND BILL_YRCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["BILL_YRCD"]), (object)"' AND BILL_DBCD = '"), DC_Main.Rshlp.Rows[DC_Main.M]["BILL_DBCD"]), (object)"' AND BILL_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["BILL_NO"]), (object)"'  ORDER BY CO_BOOK,VCH_NO,SR_NO "));
						goto IL_01ba;
						IL_01ba:
						num2 = 12;
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_01cd;
						IL_01cd:
						num2 = 13;
						DC_Main.R = 0;
						goto IL_01d6;
						IL_01d6:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_0860;
						IL_0860:
						num2 = 16;
						if (DC_Main.R < RsDetl.Rows.Count)
						{
							goto IL_01e5;
						}
						goto IL_0883;
						IL_0883:
						num2 = 23;
						DC_Main.M++;
						goto IL_0892;
						IL_0892:
						num2 = 24;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_08ad;
						IL_08ad:
						num2 = 25;
						Application.DoEvents();
						goto IL_08b7;
						IL_01e5:
						num2 = 17;
						dataTable = RsDetl;
						goto IL_01ef;
						end_IL_0001_2:
						break;
					}
					num2 = 29;
					Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 2456;
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

	private void BtnTimeLdr_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Transfer Time Ledger to Next Year ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		ExeQuteTrfr("DELETE FROM OP_LDR WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ");
		DC_Main.ExeQuteDc("UPDATE AC_DATA SET DATA_TYPE = 'A' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND (DATA_TYPE IS NULL OR DATA_TYPE = '') ");
		DC_Main.RsQry = "Select A.AC_CODE,format(Sum(A.CR_AMT-A.DR_AMT),'0.00') as Amount,format(SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as GoldWt,format(sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0)),'0.000') as SilverWt  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.AC_MAIN_GR < '3' and VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "'   GROUP BY A.AC_CODE  HAVING (Sum(A.CR_AMT-A.DR_AMT)+ SUM(iif(A.IT_TYPE = 'G',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))+sum(iif(A.IT_TYPE = 'S',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))+sum(iif(A.IT_TYPE = 'D',iif(A.SIGN = '+',A.FINE_WT,-A.FINE_WT),0))) <> 0 ORDER BY A.AC_CODE ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Party Opning";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.CO_BOOK,A.VCH_DATE,A.VCH_NO,B.DATA_TYPE,B.BOOK_SNAME,B.BOOK_INOUT,B.MAIN_BOOK,  SUM(A.CR_AMT) As CrAmt,SUM(A.DR_AMT) as DrAmt,  SUM(CASE WHEN IT_TYPE = 'G' AND SIGN = '+' THEN FINE_WT ELSE 0 END) AS CrGold,  SUM(CASE WHEN IT_TYPE = 'G' AND SIGN = '-' THEN FINE_WT ELSE 0 END) AS DrGold,  SUM(CASE WHEN IT_TYPE = 'S' AND SIGN = '+' THEN FINE_WT ELSE 0 END) AS CrSl,  SUM(CASE WHEN IT_TYPE = 'S' AND SIGN = '-' THEN FINE_WT ELSE 0 END) AS DrSl   FROM AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.AC_CODE = '"), rshlp.Rows[DC_Main.M]["AC_CODE"]), (object)"'   AND A.VCH_DATE <= '"), (object)Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy")), (object)"' "), (object)" GROUP BY A.AC_CODE,A.CO_BOOK,A.VCH_DATE,A.VCH_NO,B.DATA_TYPE,B.BOOK_SNAME,B.BOOK_INOUT,B.MAIN_BOOK  ORDER BY A.CO_BOOK,A.VCH_DATE,A.VCH_NO "));
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < dataTable.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO OP_LDR(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,DATA_TYPE,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,  CR_AMT,DR_AMT,CR_GL_FINE,DR_GL_FINE,CR_SL_FINE,DR_SL_FINE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + tYearCode.Text + "','"), dataTable.Rows[DC_Main.i]["CO_BOOK"]), (object)"','"), dataTable.Rows[DC_Main.i]["VCH_NO"]), (object)"','"), dataTable.Rows[DC_Main.i]["DATA_TYPE"]), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"', "), (object)" '"), dataTable.Rows[DC_Main.i]["BOOK_SNAME"]), (object)"','"), dataTable.Rows[DC_Main.i]["BOOK_INOUT"]), (object)"','"), dataTable.Rows[DC_Main.i]["BOOK_INOUT"]), (object)"','"), dataTable.Rows[DC_Main.i]["MAIN_BOOK"]), (object)"','"), dataTable.Rows[DC_Main.i]["AC_CODE"]), (object)"', "), (object)" "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["CrAmt"]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["DrAmt"]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["CrGold"]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["DrGold"]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["CrSl"]))), (object)","), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["DrSl"]))), (object)" )"));
					OpenRecordSetTrFr(DC_Main.RsQry);
					DC_Main.i++;
					Application.DoEvents();
				}
				rshlp = null;
				DC_Main.M++;
				if (DC_Main.Rshlp.Rows.Count != 0)
				{
					ProgressBar progressBar;
					(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				}
				Application.DoEvents();
			}
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
		}
	}

	private void LblJadtarTrfr_Click(object sender, EventArgs e)
	{
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		ExeQuteTrfr("DELETE FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
		ExeQuteTrfr("DELETE FROM MFG_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
		DC_Main.RsQry = "SELECT DESIGN_NO FROM MFG_DETL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND DESIGN_NO <> '' GROUP BY  DESIGN_NO ORDER BY DESIGN_NO";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Jadtar Process";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT DESIGN_NO FROM BAR_DETL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND DESIGN_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["DESIGN_NO"]), (object)"' "));
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R = 0;
				if (RsDetl.Rows.Count == 0)
				{
					DataTable rsDetl = RsDetl;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.MFG_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,VCH_SRNO,LOT_NO,DESIGN_NO,DESIGN_SRNO,  ITM_PCS,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,ITM_GHT_PRC,ITM_GHT_WT,TOT_GWT,  TOT_LWT,TOT_NWT,KR_JDT_WT,KR_KUNDAN_WT,KR_WAX_WT,KR_GHAT_WT,KR_MINO_WT,KR_MINO_AMT,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,OLD_FINE,OLD_LBR_AMT,OLD_OTH,KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE,  ADJ_DATE,REP_ADJ,REP_YRCD,REP_DBCD,REP_NO,REP_SRNO,REP_AC_CODE,HD_VCH_NO,MAIN_USER,ADD_USER,  DATA_TRFR,ITM_REMARK,ITM_SIZE,NET_AMT,OLD_GWT,OLD_NWT,ADD_OTH_WT,LESS_OTH_WT,FTNG_GWT,FTNG_NWT,  FTNG_TOUCH,FTNG_FINE,FTNG_IT_CODE,KR_CODE,RTN_GHIS,RTN_CHOL,MTRL_WT,MTRL_IT_CODE,DESIGN_IMG_ID,  DM_PCS,DM_WT,ISU_IT_CODE,ORD_NO,ORD_YRCD,ORD_DBCD,ORD_SRNO,ORD_AC_CODE,DM_GHT,TOT_GHT,DM_GHT_TOUCH,ORD_DESIGN)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,VCH_SRNO,LOT_NO,DESIGN_NO,DESIGN_SRNO,  ITM_PCS,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,ITM_GHT_PRC,ITM_GHT_WT,TOT_GWT,  TOT_LWT,TOT_NWT,KR_JDT_WT,KR_KUNDAN_WT,KR_WAX_WT,KR_GHAT_WT,KR_MINO_WT,KR_MINO_AMT,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,OLD_FINE,OLD_LBR_AMT,OLD_OTH,KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE,  ADJ_DATE,REP_ADJ,REP_YRCD,REP_DBCD,REP_NO,REP_SRNO,REP_AC_CODE,HD_VCH_NO,MAIN_USER,ADD_USER,  DATA_TRFR,ITM_REMARK,ITM_SIZE,NET_AMT,OLD_GWT,OLD_NWT,ADD_OTH_WT,LESS_OTH_WT,FTNG_GWT,FTNG_NWT,  FTNG_TOUCH,FTNG_FINE,FTNG_IT_CODE,KR_CODE,RTN_GHIS,RTN_CHOL,MTRL_WT,MTRL_IT_CODE,DESIGN_IMG_ID,  DM_PCS,DM_WT,ISU_IT_CODE,ORD_NO,ORD_YRCD,ORD_DBCD,ORD_SRNO,ORD_AC_CODE,DM_GHT,TOT_GHT,DM_GHT_TOUCH,ORD_DESIGN FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND DESIGN_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["DESIGN_NO"]), (object)"'"));
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.MFG_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,IT_PCS,IT_PCS_WT,IT_GWT,IT_CON_PRC,IT_CON_WT,  IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,HD_VCH_NO,MAIN_USER,OLD_ITM_ISU,KR_CODE,  RTN_PCS,RTN_GWT,BROK_PCS,BROK_WT,DM_PCS_GHT,DM_TOT_GHT,ORD_PCS,ORD_WT,DM_SIZE)   SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,IT_PCS,IT_PCS_WT,IT_GWT,IT_CON_PRC,IT_CON_WT,  IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,HD_VCH_NO,MAIN_USER,OLD_ITM_ISU,KR_CODE,  RTN_PCS,RTN_GWT,BROK_PCS,BROK_WT,DM_PCS_GHT,DM_TOT_GHT,ORD_PCS,ORD_WT,DM_SIZE  FROM MFG_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["DESIGN_NO"]), (object)"'"));
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					rsDetl = null;
				}
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
		}
	}

	private void BtnVptrfr_Click(object sender, EventArgs e)
	{
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		ExeQuteTrfr("DELETE FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
		DC_Main.RsQry = "SELECT A.* FROM RATE_CUT_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK    WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.MAIN_BOOK = 'VP PARCEL' AND A.VP_AMT - A.VP_ADJ_AMT > 0 ORDER BY A.VCH_DATE,A.VCH_NO ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Panding Vp Parcel";
		Application.DoEvents();
		DC_Main.R = 0;
		checked
		{
			while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.RATE_CUT_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,IT_TYPE,  AC_CODE,AC_NAME,DR_AMT,CR_FINE,CR_AMT,DR_FINE,RATE_PAR,FINE_RATE,SL_FINE,PR_FINE,TOT_FINE_DR,TOT_FINE_CR,KSR_FINE_CR,  KSR_FINE_DR,SL_NET_AMT,SL_ITM_AMT,SL_LBR_AMT,SL_OTH_AMT,SL_ADV_AMT,SL_CASH_AMT,SL_CARD_AMT,SL_CHQ_AMT,SL_KASAR_AMT,  SL_BILL_OS,PR_NET_AMT,PR_ITM_AMT,PR_LBR_AMT,PR_OTH_AMT,PR_ADV_AMT,PR_CASH_AMT,PR_CARD_AMT,PR_CHQ_AMT,PR_KASAR_AMT,  PR_BILL_OS,CR_DAYS,CARD_AC,BANK_AC,CHQ_NO,BANK_NAME,EMP_CODE,VCH_DESC,ENTRY_TIME,ADD1,ADD2,ADD3,CITY,MOBILE,  DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,CONV_RATE,CONV_PRC,SILVER_FINE_DR,SILVER_FINE_CR,VP_AMT,VP_INS_AMT,VP_CHARG_AMT,  VP_ADJ_AMT,VP_AMT_TYPE,AC_ANGDIYA,USER_UPDATE,USER_DELETE,TAX_CODE,TAX_PRC,PR_TAX_AMT,PR_TOT_AMT,SL_TAX_AMT,  SL_TOT_AMT,INT_DAYS,INT_PRC_FINE,INT_FINE,SLV_FINE_CR,SLV_FINE_DR,SLV_AMT_CR,SLV_AMT_DR,SLV_FINE_RATE,  MOB_ENTRY_SAVE,TDS_CODE,TDS_PRC,SL_TDS_AMT,PR_TDS_AMT)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,IT_TYPE,  AC_CODE,AC_NAME,DR_AMT,CR_FINE,CR_AMT,DR_FINE,RATE_PAR,FINE_RATE,SL_FINE,PR_FINE,TOT_FINE_DR,TOT_FINE_CR,KSR_FINE_CR,  KSR_FINE_DR,SL_NET_AMT,SL_ITM_AMT,SL_LBR_AMT,SL_OTH_AMT,SL_ADV_AMT,SL_CASH_AMT,SL_CARD_AMT,SL_CHQ_AMT,SL_KASAR_AMT,  SL_BILL_OS,PR_NET_AMT,PR_ITM_AMT,PR_LBR_AMT,PR_OTH_AMT,PR_ADV_AMT,PR_CASH_AMT,PR_CARD_AMT,PR_CHQ_AMT,PR_KASAR_AMT,  PR_BILL_OS,CR_DAYS,CARD_AC,BANK_AC,CHQ_NO,BANK_NAME,EMP_CODE,VCH_DESC,ENTRY_TIME,ADD1,ADD2,ADD3,CITY,MOBILE,  DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,CONV_RATE,CONV_PRC,SILVER_FINE_DR,SILVER_FINE_CR,VP_AMT,VP_INS_AMT,VP_CHARG_AMT,  VP_ADJ_AMT,VP_AMT_TYPE,AC_ANGDIYA,USER_UPDATE,USER_DELETE,TAX_CODE,TAX_PRC,PR_TAX_AMT,PR_TOT_AMT,SL_TAX_AMT,  SL_TOT_AMT,INT_DAYS,INT_PRC_FINE,INT_FINE,SLV_FINE_CR,SLV_FINE_DR,SLV_AMT_CR,SLV_AMT_DR,SLV_FINE_RATE,  MOB_ENTRY_SAVE,TDS_CODE,TDS_PRC,SL_TDS_AMT,PR_TDS_AMT  FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)"'"));
				DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.R++;
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
		}
	}

	private void BtnBillOrnaIsu_Click(object sender, EventArgs e)
	{
		ExeQuteTrfr("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
		ExeQuteTrfr("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
		DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ORNA_ISU = 'N'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Orna Isu Panding";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.SL_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CODE,  AC_NAME,NET_AMT,DISC_PRC,DISC_AMT,TAX_CODE,TAX_PRC,TAX_AMT,ROF_AMT,TOT_AMT,ADV_AMT,OLD_GL_AMT,OLD_SL_AMT,  CASH_AMT,CARD_AMT,CHQ_AMT,SCHM_AMT,CASH_PAID,KASAR_AMT,BILL_OS,OS_ADJ_AMT,CR_DAYS,CARD_AC,BANK_AC,CHQ_NO,  BANK_NAME,EMP_CODE,VCH_DESC,ENTRY_TIME,OLD_GL,OLD_SL,ADD1,ADD2,ADD3,CITY,MOBILE,AC_GST_TYPE,IGST_TAX,  CGST_TAX,SGST_TAX,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,SCHM_AC,CARD_ADJ,ISU_NO,ISU_LC_CODE,ISU_YRCD,  ISU_DBCD,RTN_NET_AMT,RTN_TOT_AMT,RTN_CHQ_AMT,RTN_CARD_AMT,RTN_CASH_AMT,RTN_KASAR_AMT,RTN_BILL_OS,TCS_CODE,  TCS_PRC,TCS_AMT,HM_AMT,HM_TAX_PRC,HM_TAX_AMT,HM_TAX_CODE,CARD_COM_AMT,TDS_CODE,TDS_PRC,TDS_AMT,USER_UPDATE,  USER_DELETE,POINT_VAL,IRN_NO,ACK_NO,ACK_DATE,ORNA_ISU,MOB_ENTRY_SAVE,UPI_AMT) SELECT  CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,VCH_DATE,VCH_TIME,BILL_NO,HD_VCH_NO,AC_CODE,  AC_NAME,NET_AMT,DISC_PRC,DISC_AMT,TAX_CODE,TAX_PRC,TAX_AMT,ROF_AMT,TOT_AMT,ADV_AMT,OLD_GL_AMT,OLD_SL_AMT,  CASH_AMT,CARD_AMT,CHQ_AMT,SCHM_AMT,CASH_PAID,KASAR_AMT,BILL_OS,OS_ADJ_AMT,CR_DAYS,CARD_AC,BANK_AC,CHQ_NO,  BANK_NAME,EMP_CODE,VCH_DESC,ENTRY_TIME,OLD_GL,OLD_SL,ADD1,ADD2,ADD3,CITY,MOBILE,AC_GST_TYPE,IGST_TAX,  CGST_TAX,SGST_TAX,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,SCHM_AC,CARD_ADJ,ISU_NO,ISU_LC_CODE,ISU_YRCD,  ISU_DBCD,RTN_NET_AMT,RTN_TOT_AMT,RTN_CHQ_AMT,RTN_CARD_AMT,RTN_CASH_AMT,RTN_KASAR_AMT,RTN_BILL_OS,TCS_CODE,  TCS_PRC,TCS_AMT,HM_AMT,HM_TAX_PRC,HM_TAX_AMT,HM_TAX_CODE,CARD_COM_AMT,TDS_CODE,TDS_PRC,TDS_AMT,USER_UPDATE,  USER_DELETE,POINT_VAL,IRN_NO,ACK_NO,ACK_DATE,ORNA_ISU,MOB_ENTRY_SAVE,UPI_AMT  FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' "));
				DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.SL_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,  VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,ITM_REMARK,VCH_SRNO,KR_NET_WT,KR_TOUCH,  KR_WEST_PRC,KR_FINE,KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE,HD_VCH_NO,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,  ADD_USER,ISU_NO,ISU_LC_CODE,ISU_YRCD,ISU_DBCD,ISU_SRNO,ITM_GHT_PRC,GHT_AMT,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,  HM_ID3_WT,HM_ID4_WT,HM_ID,HM_AMT,IT_TAX_AMT,IT_DISC_AMT,ORD_NO,ORD_LC_CODE,ORD_YRCD,ORD_DBCD,ORD_SRNO,TAG_GWT,  TAG_NWT,FINE_RATE,DISC_PRC,DISC_AMT,ITM_COLOR,TAX_CODE,TAXABL_RATE,ITM_IGST_AMT,ITM_CGST_AMT,ITM_SGST_AMT,  GRAND_TOTAL,EMP_CODE,ORD_TAG_STK_ADD,DESIGN_IMG_ID) SELECT  CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,  VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,ITM_REMARK,VCH_SRNO,KR_NET_WT,KR_TOUCH,  KR_WEST_PRC,KR_FINE,KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE,HD_VCH_NO,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,  ADD_USER,ISU_NO,ISU_LC_CODE,ISU_YRCD,ISU_DBCD,ISU_SRNO,ITM_GHT_PRC,GHT_AMT,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,  HM_ID3_WT,HM_ID4_WT,HM_ID,HM_AMT,IT_TAX_AMT,IT_DISC_AMT,ORD_NO,ORD_LC_CODE,ORD_YRCD,ORD_DBCD,ORD_SRNO,TAG_GWT,  TAG_NWT,FINE_RATE,DISC_PRC,DISC_AMT,ITM_COLOR,TAX_CODE,TAXABL_RATE,ITM_IGST_AMT,ITM_CGST_AMT,ITM_SGST_AMT,  GRAND_TOTAL,EMP_CODE,ORD_TAG_STK_ADD,DESIGN_IMG_ID  FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' "));
				DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
		}
	}

	private void btnBulTrfr_Click(object sender, EventArgs e)
	{
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		ExeQuteTrfr("DELETE FROM BUL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
		DC_Main.RsQry = "SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,OLD_SRNO FROM BUL_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND ITM_GWT - ADJ_WT > 0  ORDER BY CO_YEAR,CO_BOOK,VCH_NO,OLD_SRNO";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Bullion Trfr";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rsDetl = RsDetl;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.BUL_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,ITM_GWT,ITM_NWT,ADJ_WT,IT_TYPE,  ITM_RATE,ITM_AMT,AMT_TYPE,PRM_AMT,TAX_PRC,TOT_AMT,RATE_TYPE,HD_VCH_NO,IT_DESC,MAIN_USER,DATA_TRFR,DATA_TYPE,  ENTRY_TIME,EMP_CODE,USER_UPDATE,USER_DELETE,MCX_RATE,TO_LC_CODE,TO_CO_BOOK,TO_VCH_NO)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,ITM_GWT,ITM_NWT,ADJ_WT,IT_TYPE,  ITM_RATE,ITM_AMT,AMT_TYPE,PRM_AMT,TAX_PRC,TOT_AMT,RATE_TYPE,HD_VCH_NO,IT_DESC,MAIN_USER,DATA_TRFR,DATA_TYPE,  ENTRY_TIME,EMP_CODE,USER_UPDATE,USER_DELETE,MCX_RATE,TO_LC_CODE,TO_CO_BOOK,TO_VCH_NO FROM BUL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND OLD_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.M]["OLD_SRNO"]), (object)""));
				DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				rsDetl = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
		}
	}

	private void BrnOrdTraking_Click(object sender, EventArgs e)
	{
		//IL_0cb4: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					ProgressBar progressBar;
					DataTable dataTable;
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						DC_Main.RsQry = "Select A.*,B.DEL_DATE,B.FUN_DATE  FROM SL_ORD_DETL AS A LEFT JOIN SL_ORD_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_YEAR = B.CO_YEAR And A.CO_BOOK = B.CO_BOOK And A.VCH_NO = B.VCH_NO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' and A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "' ";
						goto IL_004b;
					case 3455:
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
								goto IL_004b;
							case 3:
								goto IL_0061;
							case 4:
								goto IL_0077;
							case 5:
								goto IL_0088;
							case 6:
								goto IL_0097;
							case 7:
								goto IL_00b4;
							case 8:
								goto IL_00c7;
							case 9:
								goto IL_00cf;
							case 12:
								goto IL_00de;
							case 13:
								goto IL_00e7;
							case 14:
								goto IL_01dd;
							case 15:
								goto IL_02e2;
							case 16:
								goto IL_02f0;
							case 17:
								goto IL_03e6;
							case 18:
								goto IL_04eb;
							case 19:
								goto IL_04f9;
							case 20:
								goto IL_0538;
							case 21:
								goto IL_0688;
							case 22:
								goto IL_07e7;
							case 23:
							case 24:
								goto IL_07f7;
							case 25:
								goto IL_0836;
							case 26:
								goto IL_083f;
							case 27:
								goto IL_098d;
							case 28:
								goto IL_099f;
							case 29:
								goto IL_09bd;
							case 30:
								goto IL_0aa1;
							case 31:
							case 32:
								goto IL_0ab1;
							case 33:
								goto IL_0c10;
							case 34:
							case 35:
								goto IL_0c20;
							case 36:
								goto IL_0c30;
							case 37:
								goto IL_0c32;
							case 38:
								goto IL_0c41;
							case 39:
								goto IL_0c5c;
							case 10:
							case 11:
							case 40:
								goto IL_0c66;
							case 41:
								goto IL_0c88;
							case 42:
								goto IL_0c96;
							case 43:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 44:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0c32:
						num2 = 37;
						DC_Main.M++;
						goto IL_0c41;
						IL_0c41:
						num2 = 38;
						(progressBar = ProgressBar1).Value = progressBar.Value + 1;
						goto IL_0c5c;
						IL_0c30:
						dataTable = null;
						goto IL_0c32;
						IL_0c5c:
						num2 = 39;
						Application.DoEvents();
						goto IL_0c66;
						IL_004b:
						num2 = 2;
						DC_Main.RsQry += " And A.TAG_SALE = 'N'";
						goto IL_0061;
						IL_0061:
						num2 = 3;
						DC_Main.RsQry += "ORDER BY A.VCH_DATE,A.VCH_NO,A.SR_NO ";
						goto IL_0077;
						IL_0077:
						num2 = 4;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0088;
						IL_0088:
						num2 = 5;
						ProgressBar1.Value = 0;
						goto IL_0097;
						IL_0097:
						num2 = 6;
						ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
						goto IL_00b4;
						IL_00b4:
						num2 = 7;
						lblBook.Text = "Panding Vp Parcel";
						goto IL_00c7;
						IL_00c7:
						num2 = 8;
						Application.DoEvents();
						goto IL_00cf;
						IL_00cf:
						num2 = 9;
						DC_Main.R = 0;
						goto IL_0c66;
						IL_0c66:
						num2 = 11;
						if (DC_Main.R < DC_Main.Rshlp.Rows.Count)
						{
							goto IL_00de;
						}
						goto IL_0c88;
						IL_0c88:
						num2 = 41;
						DC_Main.Rshlp.Clear();
						goto IL_0c96;
						IL_0c96:
						num2 = 42;
						DC_Main.Rshlp.Columns.Clear();
						break;
						IL_00de:
						num2 = 12;
						dataTable = DC_Main.Rshlp;
						goto IL_00e7;
						IL_00e7:
						num2 = 13;
						ExeQuteTrfr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND SR_NO = "), DC_Main.Rshlp.Rows[DC_Main.R]["SR_NO"]), (object)"")));
						goto IL_01dd;
						IL_01dd:
						num2 = 14;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.SL_ORD_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,  VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,  BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,  ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,ITM_REMARK,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,  KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE,HD_VCH_NO,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,ADD_USER,DESIGN_ISU,TAG_GEN,  TAG_SALE,ITM_GHT_PRC,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,HM_ID,OLD_TBL_CODE,ITM_COLOR,ORD_DEL_DATE,  ORD_REC_AMT,EMP_CODE,TAG_STK_LESS,RATE_FIX,DESIGN_IMG_ID,ITM_QTY,ITM_LOT)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,  VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,  BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,  ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,TOT_AMT,TAX_PRC,NET_AMT,ITM_REMARK,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,  KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE,HD_VCH_NO,DATA_TRFR,OLD_VCH_NO,NEW_VCH_NO,MAIN_USER,ADD_USER,DESIGN_ISU,TAG_GEN,  TAG_SALE,ITM_GHT_PRC,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,HM_ID,OLD_TBL_CODE,ITM_COLOR,ORD_DEL_DATE,  ORD_REC_AMT,EMP_CODE,TAG_STK_LESS,RATE_FIX,DESIGN_IMG_ID,ITM_QTY,ITM_LOT  FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND SR_NO = "), DC_Main.Rshlp.Rows[DC_Main.R]["SR_NO"]), (object)""));
						goto IL_02e2;
						IL_02e2:
						num2 = 15;
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_02f0;
						IL_02f0:
						num2 = 16;
						ExeQuteTrfr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ISU_YRCD = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_YEAR"]), (object)"' AND ISU_DBCD = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND ISU_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND ISU_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.R]["SR_NO"]), (object)"")));
						goto IL_03e6;
						IL_03e6:
						num2 = 17;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.APR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,AC_CODE,VCH_TIME,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,  ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,NET_AMT,  ITM_REMARK,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE,HD_VCH_NO,MAIN_USER,ADD_USER,  ISU_REC,ISU_NO,ISU_YRCD,ISU_DBCD,ISU_SRNO,ISU_AC_CODE,ISU_AC_NAME,MTL_COLOR,ADJ_GWT,ADJ_NWT,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,  HM_ID3_WT,HM_ID4_WT,HM_ID,ITM_COLOR,ORNA_REC_DATE,EMP_CODE,EMP_SALE,ITM_LESS_TCH,ITM_LOSS_WT,DESIGN_IMG_ID,ITM_LOT,ISU_LC_CODE,ITM_STYLE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,AC_CODE,VCH_TIME,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,  ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MRP,NET_AMT,  ITM_REMARK,VCH_SRNO,KR_NET_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE,HD_VCH_NO,MAIN_USER,ADD_USER,  ISU_REC,ISU_NO,ISU_YRCD,ISU_DBCD,ISU_SRNO,ISU_AC_CODE,ISU_AC_NAME,MTL_COLOR,ADJ_GWT,ADJ_NWT,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,  HM_ID3_WT,HM_ID4_WT,HM_ID,ITM_COLOR,ORNA_REC_DATE,EMP_CODE,EMP_SALE,ITM_LESS_TCH,ITM_LOSS_WT,DESIGN_IMG_ID,ITM_LOT,ISU_LC_CODE,ITM_STYLE  FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ISU_YRCD = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_YEAR"]), (object)"' AND ISU_DBCD = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND ISU_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND ISU_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.R]["SR_NO"]), (object)" "));
						goto IL_04eb;
						IL_04eb:
						num2 = 18;
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_04f9;
						IL_04f9:
						num2 = 19;
						if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TAG_NO"], (object)""), (object)"", false))
						{
							goto IL_0538;
						}
						goto IL_07f7;
						IL_0538:
						num2 = 20;
						ExeQuteTrfr(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ORD_YRCD = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_YEAR"]), (object)"' AND ORD_DBCD = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND ORD_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND ORD_SRNO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["SR_NO"]), (object)"' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_SRNO"]), (object)"")));
						goto IL_0688;
						IL_0688:
						num2 = 21;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.BAR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,  STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,  ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,  LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,KR_OTH_WT,  KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,TAG_SRNO,  VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,ORD_AC,MAIN_USER,ADD_USER,  DATA_TRFR,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,HM_ID,  DATA_TYPE,APP_TRFR,ITM_COLOR,MAIN_MARGIN_PRC,MAIN_MRP,JDT_JDT_WT,JDT_GHT_WT,JDT_KUN_WT,JDT_WAX_WT,KR_WAX_WT,  JDT_KUN_TOUCH,JDT_KUN_NET,EMP_ISU,LBR_CODE,DESIGN_IMG_ID,SL_TYPE,KR_OTH_RATE,KR_OTH_FINE,KR_TOT_FINE,  KR_GWT_TOUCH,ITM_STYLE,ORD_LC_CODE,MFG_YRCD,MFG_DBCD,MFG_NO,MFG_SRNO)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,  STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,  ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,  LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,KR_OTH_WT,  KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,TAG_SRNO,  VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,ORD_AC,MAIN_USER,ADD_USER,  DATA_TRFR,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,HM_ID,  DATA_TYPE,APP_TRFR,ITM_COLOR,MAIN_MARGIN_PRC,MAIN_MRP,JDT_JDT_WT,JDT_GHT_WT,JDT_KUN_WT,JDT_WAX_WT,KR_WAX_WT,  JDT_KUN_TOUCH,JDT_KUN_NET,EMP_ISU,LBR_CODE,DESIGN_IMG_ID,SL_TYPE,KR_OTH_RATE,KR_OTH_FINE,KR_TOT_FINE,  KR_GWT_TOUCH,ITM_STYLE,ORD_LC_CODE,MFG_YRCD,MFG_DBCD,MFG_NO,MFG_SRNO  FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ORD_YRCD = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_YEAR"]), (object)"' AND ORD_DBCD = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND ORD_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND ORD_SRNO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["SR_NO"]), (object)"' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_SRNO"]), (object)" "));
						goto IL_07e7;
						IL_07e7:
						num2 = 22;
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_07f7;
						IL_07f7:
						num2 = 24;
						if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["TAG_NO"], (object)""), (object)"", false))
						{
							goto IL_0836;
						}
						goto IL_0c20;
						IL_0836:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_083f;
						IL_083f:
						num2 = 26;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BAR_DETL BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ORD_YRCD = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_YEAR"]), (object)"' AND ORD_DBCD = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND ORD_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND ORD_SRNO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["SR_NO"]), (object)"' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_SRNO"]), (object)" "));
						goto IL_098d;
						IL_098d:
						num2 = 27;
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_099f;
						IL_099f:
						num2 = 28;
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							goto IL_09bd;
						}
						goto IL_0ab1;
						IL_09bd:
						num2 = 29;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_SRNO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"' AND SR_NO = "), DC_Main.Tbl.Rows[0]["SR_NO"]), (object)""));
						goto IL_0aa1;
						IL_0aa1:
						num2 = 30;
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						goto IL_0ab1;
						IL_0ab1:
						num2 = 32;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.BAR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,  VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,  DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,  IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,  MAIN_USER,DM_NAME,OLD_VCH_NO,NEW_VCH_NO,DM_ORIGIN,DM_REMARK,DM_COLOR,KR_ACT_WT,KR_ACT_PRC,KR_RATE_TYPE,IT_DISC_PRC,IT_DISC_AMT)  SELECT B.CO_CODE,B.LC_CODE,B.CO_YEAR,B.CO_BOOK,B.VCH_NO,B.SR_NO,B.ISR_NO,  B.VCH_DATE,B.VCH_TYPE,B.INOUT_TYPE,B.ENTRY_TYPE,B.BOOK_NAME,B.AC_CODE,B.TAG_NO,B.VCH_SRNO,B.IT_CODE,B.IT_TYPE,B.DM_CODE,B.DM_SIZE,  B.DM_SFNO,B.DM_LEB,B.IT_PCS,B.IT_PCS_WT,B.KR_WT,B.KR_LESS_PRC,B.IT_GWT,B.IT_CON_PRC,B.IT_CON_WT,B.IT_RATE_TYPE,B.IT_RATE,B.IT_AMT,  B.IT_LBR_RATE,B.IT_LBR_AMT,B.IT_NET_AMT,B.KR_CON_PRC,B.KR_CON_WT,B.KR_RATE,B.KR_AMT,B.KR_LBR_RATE,B.KR_LBR_AMT,B.KR_NET_AMT,  B.MAIN_USER,B.DM_NAME,B.OLD_VCH_NO,B.NEW_VCH_NO,B.DM_ORIGIN,B.DM_REMARK,B.DM_COLOR,B.KR_ACT_WT,B.KR_ACT_PRC,KR_RATE_TYPE,IT_DISC_PRC,IT_DISC_AMT  FROM BAR_DETL AS A INNER JOIN BAR_IDTL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND  A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO AND A.OLD_SRNO = B.SR_NO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ORD_YRCD = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_YEAR"]), (object)"' AND A.ORD_DBCD = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND A.ORD_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND A.ORD_SRNO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["SR_NO"]), (object)"' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["TAG_NO"]), (object)"' AND A.VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_SRNO"]), (object)"  "));
						goto IL_0c10;
						IL_0c10:
						num2 = 33;
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0c20;
						IL_0c20:
						num2 = 35;
						DC_Main.R++;
						goto IL_0c30;
						end_IL_0001_2:
						break;
					}
					num2 = 43;
					Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 3455;
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

	private void BtnReparing_Click(object sender, EventArgs e)
	{
		//IL_072f: Unknown result type (might be due to invalid IL or missing references)
		ExeQuteTrfr("DELETE FROM REP_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
		DC_Main.RsQry = "Select A.*  FROM REP_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' and A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "' AND B.MAIN_BOOK IN ('CUSTREP RECEIPT') ";
		DC_Main.RsQry += " And A.REP_ADJ = 'N'";
		DC_Main.RsQry += "ORDER BY A.VCH_DATE,A.VCH_NO,A.SR_NO ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Reparing Transfer";
		Application.DoEvents();
		DC_Main.R = 0;
		checked
		{
			while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM REP_DETL WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND SR_NO = "), DC_Main.Rshlp.Rows[DC_Main.R]["SR_NO"]), (object)""));
				DC_Main.Tbl = OpenRecordSetTrFr(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.REP_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,VCH_TIME,BOOK_NAME,AC_CODE,IT_CODE,IT_NAME,IT_DESC,ITM_SIZE,TAG_NO,  DESIGN_NO,VCH_SRNO,ITM_PCS,ITM_GWT,ITM_OTH_WT,ADD_WT,LESS_WT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,LESS_FINE,  ITM_RATE,ITM_AMT,LBR_TYPE,LBR_RATE,LBR_AMT,RATE_TYPE,IT_TYPE,OTH_AMT,NET_AMT,REP_NO,REP_SRNO,REP_LC,REP_YRCD,  REP_DBCD,REP_AC_CODE,REP_AC_NAME,REP_HD_VCH_NO,REP_ADJ,ISU_NO,ISU_SRNO,ISU_LC,ISU_YRCD,ISU_DBCD,ISU_AC_CODE,  ISU_AC_NAME,ISU_HD_VCH_NO,ISU_ADJ,HD_VCH_NO,EMP_CODE,DATA_TRFR,MAIN_USER,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,  HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,HM_ID,ITM_COLOR,DESIGN_IMG_ID,LESS_TOUCH)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,VCH_TIME,BOOK_NAME,AC_CODE,IT_CODE,IT_NAME,IT_DESC,ITM_SIZE,TAG_NO,  DESIGN_NO,VCH_SRNO,ITM_PCS,ITM_GWT,ITM_OTH_WT,ADD_WT,LESS_WT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,LESS_FINE,  ITM_RATE,ITM_AMT,LBR_TYPE,LBR_RATE,LBR_AMT,RATE_TYPE,IT_TYPE,OTH_AMT,NET_AMT,REP_NO,REP_SRNO,REP_LC,REP_YRCD,  REP_DBCD,REP_AC_CODE,REP_AC_NAME,REP_HD_VCH_NO,REP_ADJ,ISU_NO,ISU_SRNO,ISU_LC,ISU_YRCD,ISU_DBCD,ISU_AC_CODE,  ISU_AC_NAME,ISU_HD_VCH_NO,ISU_ADJ,HD_VCH_NO,EMP_CODE,DATA_TRFR,MAIN_USER,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,  HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,HM_ID,ITM_COLOR,DESIGN_IMG_ID,LESS_TOUCH  FROM REP_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND SR_NO = "), DC_Main.Rshlp.Rows[DC_Main.R]["SR_NO"]), (object)""));
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				DC_Main.R++;
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
			DC_Main.RsQry = "Select A.*  FROM REP_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' and A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy") + "' AND B.MAIN_BOOK IN ('CUSTREP RECEIPT','KRREP RECEIPT','KRREP ISSUE') ";
			DC_Main.RsQry += " And A.REP_ADJ = 'N' OR A.ISU_ADJ = 'N' ";
			DC_Main.RsQry += "ORDER BY A.VCH_DATE,A.VCH_NO,A.SR_NO ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
			lblBook.Text = "Reparing Transfer";
			Application.DoEvents();
			DC_Main.R = 0;
			while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp2 = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM REP_DETL WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND SR_NO = "), DC_Main.Rshlp.Rows[DC_Main.R]["SR_NO"]), (object)""));
				DC_Main.Tbl = OpenRecordSetTrFr(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.REP_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,VCH_TIME,BOOK_NAME,AC_CODE,IT_CODE,IT_NAME,IT_DESC,ITM_SIZE,TAG_NO,  DESIGN_NO,VCH_SRNO,ITM_PCS,ITM_GWT,ITM_OTH_WT,ADD_WT,LESS_WT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,LESS_FINE,  ITM_RATE,ITM_AMT,LBR_TYPE,LBR_RATE,LBR_AMT,RATE_TYPE,IT_TYPE,OTH_AMT,NET_AMT,REP_NO,REP_SRNO,REP_LC,REP_YRCD,  REP_DBCD,REP_AC_CODE,REP_AC_NAME,REP_HD_VCH_NO,REP_ADJ,ISU_NO,ISU_SRNO,ISU_LC,ISU_YRCD,ISU_DBCD,ISU_AC_CODE,  ISU_AC_NAME,ISU_HD_VCH_NO,ISU_ADJ,HD_VCH_NO,EMP_CODE,DATA_TRFR,MAIN_USER,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,  HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,HM_ID,ITM_COLOR,DESIGN_IMG_ID,LESS_TOUCH)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,VCH_TIME,BOOK_NAME,AC_CODE,IT_CODE,IT_NAME,IT_DESC,ITM_SIZE,TAG_NO,  DESIGN_NO,VCH_SRNO,ITM_PCS,ITM_GWT,ITM_OTH_WT,ADD_WT,LESS_WT,ITM_NWT,ITM_TOUCH,ITM_WEST,ITM_FINE,LESS_FINE,  ITM_RATE,ITM_AMT,LBR_TYPE,LBR_RATE,LBR_AMT,RATE_TYPE,IT_TYPE,OTH_AMT,NET_AMT,REP_NO,REP_SRNO,REP_LC,REP_YRCD,  REP_DBCD,REP_AC_CODE,REP_AC_NAME,REP_HD_VCH_NO,REP_ADJ,ISU_NO,ISU_SRNO,ISU_LC,ISU_YRCD,ISU_DBCD,ISU_AC_CODE,  ISU_AC_NAME,ISU_HD_VCH_NO,ISU_ADJ,HD_VCH_NO,EMP_CODE,DATA_TRFR,MAIN_USER,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,  HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,HM_ID,ITM_COLOR,DESIGN_IMG_ID,LESS_TOUCH  FROM REP_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.R]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.R]["VCH_NO"]), (object)"' AND SR_NO = "), DC_Main.Rshlp.Rows[DC_Main.R]["SR_NO"]), (object)""));
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				DC_Main.R++;
				rshlp2 = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
		}
	}

	private void btnLotTrfr_Click(object sender, EventArgs e)
	{
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		ExeQuteTrfr("DELETE FROM LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.LOT_NO,A.IT_CODE,A.IT_TYPE,  SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_PCS ELSE -A.IT_PCS END) As ItmPcs,SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_GWT ELSE -A.IT_GWT END) As ItmGwt,SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_NWT ELSE -A.IT_NWT END) As ItmNwt   FROM LOT_DETL AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE <= '"), (object)Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy")), (object)"' GROUP BY A.LOT_NO,A.IT_CODE,A.IT_TYPE HAVING SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_PCS ELSE -A.IT_PCS END) > 0  "));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Lot Transfer";
		Application.DoEvents();
		string text = "00001";
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rshlp = DC_Main.Rshlp;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LOT_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,  BOOK_NAME,AC_CODE,LOT_NO,IT_CODE,IT_TYPE,IT_PCS,IT_GWT,IT_NWT,IT_SIGN,HD_VCH_NO,MAIN_USER,DATA_TYPE,DATA_TRFR,  TAG_NO,VCH_SRNO,TAG_IT_CODE,EMP_CODE,KR_CODE,PR_CODE,ITM_LOT) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','" + text + "',1,'" + Strings.Format((object)mTrfr_dt.AddDays(-1.0), "MM/dd/yyyy") + "','LOTOP','I','L',  'LOT OPNING','','"), rshlp.Rows[DC_Main.M]["LOT_NO"]), (object)"','"), rshlp.Rows[DC_Main.M]["IT_CODE"]), (object)"','"), rshlp.Rows[DC_Main.M]["IT_TYPE"]), (object)"',"), rshlp.Rows[DC_Main.M]["ItmPcs"]), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["ItmGwt"])), "0.000")), (object)","), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.M]["ItmNwt"])), "0.000")), (object)",'+','"), (object)text), (object)"','"), (object)DC_Main.MCo_User), (object)"','A','N', "), (object)" '',0,'','001','','','')"));
				OpenRecordSetTrFr(DC_Main.RsQry);
				text = Strings.Format((object)(Conversion.Val(text) + 1.0), "00000");
				rshlp = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
		}
	}

	private void btnIdtl_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0e85: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Data Transfer to Next Year ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		lblBook.Text = "Tag OthDetl Import";
		((Control)ProgressBar1).Visible = true;
		DC_Main.RsQry = "SELECT B.IT_TYPE,A.IT_CODE FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND TAG_NO <> 'N' GROUP BY B.IT_TYPE,A.IT_CODE ORDER BY B.IT_TYPE,A.IT_CODE ";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = dataTable.Rows.Count;
		lblBook.Text = "Tag Transfer";
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < dataTable.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tYearCode.Text + "' AND IT_CODE = '"), dataTable.Rows[DC_Main.M]["IT_CODE"]), (object)"' AND VCH_DATE <= '"), (object)Strings.Format((object)DC_Main.MCl_dt, "MM/dd/yyyy")), (object)"' ORDER BY VCH_TIME DESC,TAG_NO DESC"));
				DC_Main.Rshlp = OpenRecordSetTrFr(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					DC_Main.i = 0;
					while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"]), (object)" "));
						DC_Main.Tbl = OpenRecordSetTrFr(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_TYPE FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"]), (object)" ORDER BY A.ISR_NO "));
							DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.R = 0;
							while (DC_Main.R < dataTable2.Rows.Count)
							{
								object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,  DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,  IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER,  DM_NAME,DM_ORIGIN,DM_REMARK,DM_COLOR,KR_ACT_WT,KR_ACT_PRC) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + tYearCode.Text + "','000','"), DC_Main.Rshlp.Rows[DC_Main.i]["VCH_NO"]), (object)"',"), DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"]), (object)","), (object)(DC_Main.R + 1)), (object)",'"), (object)Strings.Format((object)mTrfr_dt.AddDays(-1.0), "MM/dd/yyyy")), (object)"', "), (object)" '"), dataTable2.Rows[DC_Main.R]["VCH_TYPE"]), (object)"','I','O','"), dataTable2.Rows[DC_Main.R]["BOOK_NAME"]), (object)"','"), dataTable2.Rows[DC_Main.R]["AC_CODE"]), (object)"','"), dataTable2.Rows[DC_Main.R]["TAG_NO"]), (object)"',"), dataTable2.Rows[DC_Main.R]["VCH_SRNO"]), (object)",'"), dataTable2.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), dataTable2.Rows[DC_Main.R]["IT_TYPE"]), (object)"', "), (object)" '"), dataTable2.Rows[DC_Main.R]["DM_CODE"]), (object)"','"), dataTable2.Rows[DC_Main.R]["DM_SIZE"]), (object)"','"), dataTable2.Rows[DC_Main.R]["DM_SFNO"]), (object)"','"), dataTable2.Rows[DC_Main.R]["DM_LEB"]), (object)"',");
								DataRow dataRow;
								object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_PCS"]);
								double num = DC_Main.Fnv(ref Value);
								dataRow["IT_PCS"] = RuntimeHelpers.GetObjectValue(Value);
								object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_PCS_WT"]);
								double num2 = DC_Main.Fnv(ref Value);
								dataRow["IT_PCS_WT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_WT"]);
								double num3 = DC_Main.Fnv(ref Value);
								dataRow["KR_WT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num3), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_LESS_PRC"]);
								double num4 = DC_Main.Fnv(ref Value);
								dataRow["KR_LESS_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num4), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_GWT"]);
								double num5 = DC_Main.Fnv(ref Value);
								dataRow["IT_GWT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num5), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_CON_PRC"]);
								double num6 = DC_Main.Fnv(ref Value);
								dataRow["IT_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								object obj7 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num6), (object)", "), (object)" ");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_CON_WT"]);
								double num7 = DC_Main.Fnv(ref Value);
								dataRow["IT_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj8 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, (object)num7), (object)",'"), dataTable2.Rows[DC_Main.R]["IT_RATE_TYPE"]), (object)"',");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_RATE"]);
								double num8 = DC_Main.Fnv(ref Value);
								dataRow["IT_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj9 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj8, (object)num8), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_AMT"]);
								double num9 = DC_Main.Fnv(ref Value);
								dataRow["IT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj10 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj9, (object)num9), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_LBR_RATE"]);
								double num10 = DC_Main.Fnv(ref Value);
								dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj11 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj10, (object)num10), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_LBR_AMT"]);
								double num11 = DC_Main.Fnv(ref Value);
								dataRow["IT_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj12 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj11, (object)num11), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["IT_NET_AMT"]);
								double num12 = DC_Main.Fnv(ref Value);
								dataRow["IT_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj13 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj12, (object)num12), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_CON_PRC"]);
								double num13 = DC_Main.Fnv(ref Value);
								dataRow["KR_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								object obj14 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj13, (object)num13), (object)", "), (object)" ");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_CON_WT"]);
								double num14 = DC_Main.Fnv(ref Value);
								dataRow["KR_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj15 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj14, (object)num14), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_RATE"]);
								double num15 = DC_Main.Fnv(ref Value);
								dataRow["KR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj16 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj15, (object)num15), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_AMT"]);
								double num16 = DC_Main.Fnv(ref Value);
								dataRow["KR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj17 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj16, (object)num16), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_LBR_RATE"]);
								double num17 = DC_Main.Fnv(ref Value);
								dataRow["KR_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj18 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj17, (object)num17), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_LBR_AMT"]);
								double num18 = DC_Main.Fnv(ref Value);
								dataRow["KR_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj19 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj18, (object)num18), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_NET_AMT"]);
								double num19 = DC_Main.Fnv(ref Value);
								dataRow["KR_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj20 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj19, (object)num19), (object)",'");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["MAIN_USER"]);
								double num20 = DC_Main.Fnv(ref Value);
								dataRow["MAIN_USER"] = RuntimeHelpers.GetObjectValue(Value);
								object obj21 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj20, (object)num20), (object)"', "), (object)" '"), dataTable2.Rows[DC_Main.R]["DM_NAME"]), (object)"','"), dataTable2.Rows[DC_Main.R]["DM_ORIGIN"]), (object)"','"), dataTable2.Rows[DC_Main.R]["DM_REMARK"]), (object)"','"), dataTable2.Rows[DC_Main.R]["DM_COLOR"]), (object)"',");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_ACT_WT"]);
								double num21 = DC_Main.Fnv(ref Value);
								dataRow["KR_ACT_WT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj22 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj21, (object)num21), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[DC_Main.R])["KR_ACT_PRC"]);
								double num22 = DC_Main.Fnv(ref Value);
								dataRow["KR_ACT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj22, (object)num22), (object)")"));
								OpenRecordSetTrFr(DC_Main.RsQry);
								DC_Main.R++;
								Application.DoEvents();
							}
						}
						DC_Main.i++;
					}
				}
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
			ProgressBar1.Value = 0;
		}
	}

	private void PnlBotam_DoubleClick(object sender, EventArgs e)
	{
		((Control)btnIdtl).Visible = true;
	}

	private void btnMfgTrfr_Click(object sender, EventArgs e)
	{
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		ExeQuteTrfr("DELETE FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
		ExeQuteTrfr("DELETE FROM MFG_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR <> '" + tYearCode.Text + "'");
		DC_Main.RsQry = "SELECT A.ITM_LOT,C.RecIt,B.IT_NAME,SUM(CASE WHEN ITM_SIGN = '-' THEN IR_PCS ELSE 0 END)As IsPcsM,SUM(CASE WHEN ITM_SIGN = '+' THEN IR_PCS ELSE 0 END)As RcPcsM,SUM(CASE WHEN ITM_SIGN = '-' THEN ITM_GWT ELSE 0 END)As IsuWtW,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE 0 END) As RecWtW,  SUM(CASE WHEN ITM_SIGN = '-' THEN ITM_GWT ELSE 0 END)-SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE 0 END) As DifWtW,A.IT_CODE As IsuItL,A.IR_YRCD As MfgYearL,A.IR_DBCD As MfgDbCdL,A.IR_NO As MfgNoL,A.IR_SRNO As MfgSrNo,SUM(CASE WHEN ITM_SIGN = '-' THEN ITM_NWT ELSE 0 END)-SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE 0 END) As DifNwtW  FROM (MFG_ISU_REC AS A INNER JOIN(SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISU_IT_CODE As RecIt FROM MFG_DETL) AS C ON A.CO_CODE = C.CO_CODE And A.LC_CODE = C.LC_CODE And A.CO_YEAR = C.CO_YEAR And A.CO_BOOK = C.CO_BOOK And A.VCH_NO = C.VCH_NO And A.SR_NO = C.SR_NO)LEFT JOIN ITEM_MAST AS B ON C.CO_CODE = B.CO_CODE And C.RecIt = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_LOT <> '' AND A.IR_TYPE IN ('S')  GROUP BY A.ITM_LOT,A.IT_CODE,B.IT_NAME,C.RecIt,A.IR_YRCD,A.IR_DBCD,A.IR_NO,A.IR_SRNO  HAVING SUM(CASE WHEN ITM_SIGN = '-' THEN IR_PCS ELSE 0 END)-SUM(CASE WHEN ITM_SIGN = '+' THEN IR_PCS ELSE 0 END) > 0 ORDER BY A.ITM_LOT DESC,B.IT_NAME ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		ProgressBar1.Value = 0;
		ProgressBar1.Maximum = DC_Main.Rshlp.Rows.Count;
		lblBook.Text = "Mfg Process";
		Application.DoEvents();
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
			{
				DataTable rsDetl = RsDetl;
				object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.MFG_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,VCH_SRNO,LOT_NO,DESIGN_NO,DESIGN_SRNO,  ITM_PCS,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,ITM_GHT_PRC,ITM_GHT_WT,TOT_GWT,  TOT_LWT,TOT_NWT,KR_JDT_WT,KR_KUNDAN_WT,KR_WAX_WT,KR_GHAT_WT,KR_MINO_WT,KR_MINO_AMT,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,OLD_FINE,OLD_LBR_AMT,OLD_OTH,KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE,  ADJ_DATE,REP_ADJ,REP_YRCD,REP_DBCD,REP_NO,REP_SRNO,REP_AC_CODE,HD_VCH_NO,MAIN_USER,ADD_USER,  DATA_TRFR,ITM_REMARK,ITM_SIZE,NET_AMT,OLD_GWT,OLD_NWT,ADD_OTH_WT,LESS_OTH_WT,FTNG_GWT,FTNG_NWT,  FTNG_TOUCH,FTNG_FINE,FTNG_IT_CODE,KR_CODE,RTN_GHIS,RTN_CHOL,MTRL_WT,MTRL_IT_CODE,DESIGN_IMG_ID,  DM_PCS,DM_WT,ISU_IT_CODE,ORD_NO,ORD_YRCD,ORD_DBCD,ORD_SRNO,ORD_AC_CODE,DM_GHT,TOT_GHT,DM_GHT_TOUCH,ORD_DESIGN,  LAST_IR_TYPE,CHOL_IT_CODE,ORD_PCS,ORD_GWT,ORD_OTH_WT,ORD_NWT,ITM_LOT_AC_CODE,REC_YRCD,REC_DBCD,REC_NO,REC_SRNO)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_TIME,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,VCH_SRNO,LOT_NO,DESIGN_NO,DESIGN_SRNO,  "), DC_Main.Rshlp.Rows[DC_Main.M]["IsPcsM"]), (object)"-"), DC_Main.Rshlp.Rows[DC_Main.M]["RcPcsM"]), (object)",ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,ITM_GHT_PRC,ITM_GHT_WT,TOT_GWT, "), (object)" TOT_LWT,TOT_NWT,KR_JDT_WT,KR_KUNDAN_WT,KR_WAX_WT,KR_GHAT_WT,KR_MINO_WT,KR_MINO_AMT,LBR_RATE,LBR_TYPE, "), (object)" LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,OLD_FINE,OLD_LBR_AMT,OLD_OTH,KR_NAME,RATE_TYPE,IT_TYPE,PR_CODE, "), (object)" ADJ_DATE,REP_ADJ,REP_YRCD,REP_DBCD,REP_NO,REP_SRNO,REP_AC_CODE,HD_VCH_NO,MAIN_USER,ADD_USER, "), (object)" DATA_TRFR,ITM_REMARK,ITM_SIZE,NET_AMT,OLD_GWT,OLD_NWT,ADD_OTH_WT,LESS_OTH_WT,FTNG_GWT,FTNG_NWT, "), (object)" FTNG_TOUCH,FTNG_FINE,FTNG_IT_CODE,KR_CODE,RTN_GHIS,RTN_CHOL,MTRL_WT,MTRL_IT_CODE,DESIGN_IMG_ID, "), (object)" DM_PCS,DM_WT,ISU_IT_CODE,ORD_NO,ORD_YRCD,ORD_DBCD,ORD_SRNO,ORD_AC_CODE,DM_GHT,TOT_GHT,DM_GHT_TOUCH,ORD_DESIGN, "), (object)" LAST_IR_TYPE,CHOL_IT_CODE,ORD_PCS,ORD_GWT,ORD_OTH_WT,ORD_NWT,ITM_LOT_AC_CODE,REC_YRCD,REC_DBCD,REC_NO,REC_SRNO FROM MFG_DETL WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.M]["MfgYearL"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.M]["MfgDbCdL"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["MfgNoL"]), (object)"' AND OLD_SRNO = ");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["MfgSrNo"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["MfgSrNo"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num), (object)""));
				DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO " + TrfrMdbName + ".dbo.MFG_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,IT_PCS,IT_PCS_WT,IT_GWT,IT_CON_PRC,IT_CON_WT,  IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,HD_VCH_NO,MAIN_USER,OLD_ITM_ISU,KR_CODE,  RTN_PCS,RTN_GWT,BROK_PCS,BROK_WT,DM_PCS_GHT,DM_TOT_GHT,ORD_PCS,ORD_WT,DM_SIZE,ITM_LOT,ITM_LOT_AC_CODE)   SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,  ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,IT_PCS,IT_PCS_WT,IT_GWT,IT_CON_PRC,IT_CON_WT,  IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,HD_VCH_NO,MAIN_USER,OLD_ITM_ISU,KR_CODE,  RTN_PCS,RTN_GWT,BROK_PCS,BROK_WT,DM_PCS_GHT,DM_TOT_GHT,ORD_PCS,ORD_WT,DM_SIZE,ITM_LOT,ITM_LOT_AC_CODE  FROM MFG_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[DC_Main.M]["MfgYearL"]), (object)"' AND CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.M]["MfgDbCdL"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.M]["MfgNoL"]), (object)"' AND SR_NO = ");
				Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Rshlp.Rows[DC_Main.M])["MfgSrNo"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["MfgSrNo"] = RuntimeHelpers.GetObjectValue(Value);
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num2), (object)""));
				DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				rsDetl = null;
				DC_Main.M++;
				ProgressBar progressBar;
				(progressBar = ProgressBar1).Value = progressBar.Value + 1;
				Application.DoEvents();
			}
			DC_Main.Rshlp.Clear();
			DC_Main.Rshlp.Columns.Clear();
			Interaction.MsgBox((object)"Process Are Complete....", (MsgBoxStyle)64, (object)null);
		}
	}
}
