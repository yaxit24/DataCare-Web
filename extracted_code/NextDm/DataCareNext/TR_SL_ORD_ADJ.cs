using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using MSFlexGridLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class TR_SL_ORD_ADJ : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblBook")]
	private Label _lblBook;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mVchDate")]
	private MaskedTextBox _mVchDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchNo")]
	private TextBox _tVchNo;

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
	[AccessedThroughProperty("BtnFirst")]
	private SimpleButton _BtnFirst;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnLast")]
	private SimpleButton _BtnLast;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnF1")]
	private SimpleButton _BtnF1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpCode")]
	private TextBox _tEmpCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_TAG")]
	private AxMSFlexGrid _MSG_TAG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_TAG")]
	private TextBox _TEXT_TAG;

	private string UsUPdate;

	private string UsDelete;

	private string DataTrfr;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private double LessAdvAmt;

	private double CustOpAmt;

	private double CustClAmt;

	private string PartyAcCode;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OldValTot;

	private double NewValTot;

	private string CurTagNo;

	private string MsVchSrno;

	private DataTable RsData;

	private DataTable RsDetl;

	private DataTable RsIdtl;

	private int FilRow;

	private DataTable DtIdtl;

	private DataRow dr;

	private bool Msgleft;

	private bool UpDown;

	private bool MsTxtDelete;

	private int MsgOldRow;

	private bool MsgIdtlLeft;

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

	private const int cOrdNo = 1;

	private const int cAcCode = 2;

	private const int cAcName = 3;

	private const int cItDesc = 4;

	private const int cOrdBalAmt = 5;

	private const int cOrdAdj = 6;

	private const int cKasarAmt = 7;

	private const int cPaidAmt = 8;

	private const int cPaidAc = 9;

	private const int cPaidAcName = 10;

	private const int cOrdYrcd = 11;

	private const int cOrdDbCd = 12;

	private const int cOrHdVchNo = 13;

	private const int cEntryMod = 14;

	private const int cOrdLc = 15;

	private const int c1SrNo = 0;

	private const int cTagNo = 1;

	private const int cTagOrdNo = 2;

	private const int cItCode = 3;

	private const int cItName = 4;

	private const int cCounter = 5;

	private const int cDesign = 6;

	private const int cPcs = 7;

	private const int cGrWt = 8;

	private const int cOthWt = 9;

	private const int cNetWt = 10;

	private const int cMrp = 11;

	private const int cTagOrdYrcd = 12;

	private const int cTagOrdDbCd = 13;

	private const int cTagOrdSrNo = 14;

	private const int cVchSrNo = 15;

	private const int cTagAcCode = 16;

	internal virtual Label lblBook
	{
		[CompilerGenerated]
		get
		{
			return _lblBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = lblBook_DoubleClick;
			Label val = _lblBook;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_lblBook = value;
			val = _lblBook;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual MaskedTextBox mVchDate
	{
		[CompilerGenerated]
		get
		{
			return _mVchDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = mVchDate_GotFocus;
			KeyEventHandler val = new KeyEventHandler(mVchDate_KeyDown);
			MaskedTextBox val2 = _mVchDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_mVchDate = value;
			val2 = _mVchDate;
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

	internal virtual TextBox tVchNo
	{
		[CompilerGenerated]
		get
		{
			return _tVchNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TVchNo_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tVchNo_KeyDown);
			TextBox val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tVchNo = value;
			val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mDay")]
	private virtual TextBox _mDay;

	internal virtual TextBox mDay
	{
		get
		{
			return _mDay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_mDay = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mTime")]
	private virtual TextBox _mTime;

	internal virtual TextBox mTime
	{
		get
		{
			return _mTime;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_mTime = value;
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
			EventHandler eventHandler = TEXT_ENTRY_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_ENTRY_KeyDown);
			TextBox val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_ENTRY = value;
			val2 = _TEXT_ENTRY;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
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

	internal virtual SimpleButton BtnF1
	{
		[CompilerGenerated]
		get
		{
			return _BtnF1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnF1_Click;
			SimpleButton val = _BtnF1;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnF1 = value;
			val = _BtnF1;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tHdVchNo")]
	private virtual TextBox _tHdVchNo;

	internal virtual TextBox tHdVchNo
	{
		get
		{
			return _tHdVchNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tHdVchNo = value;
		}
	}

	internal virtual TextBox tEmpCode
	{
		[CompilerGenerated]
		get
		{
			return _tEmpCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tEmpCode_KeyDown);
			TextBox val2 = _tEmpCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tEmpCode = value;
			val2 = _tEmpCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpName")]
	private virtual TextBox _tEmpName;

	internal virtual TextBox tEmpName
	{
		get
		{
			return _tEmpName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tEmpName = value;
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
	[AccessedThroughProperty("LOpAmt")]
	private virtual Label _LOpAmt;

	internal virtual Label LOpAmt
	{
		get
		{
			return _LOpAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LOpAmt = value;
		}
	}

	internal virtual AxMSFlexGrid MSG_TAG
	{
		[CompilerGenerated]
		get
		{
			return _MSG_TAG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_TAG_ClickEvent;
			EventHandler eventHandler2 = MSG_TAG_EnterCell;
			EventHandler eventHandler3 = MSG_TAG_LeaveCell;
			AxMSFlexGrid val = _MSG_TAG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_TAG = value;
			val = _MSG_TAG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	internal virtual TextBox TEXT_TAG
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_TAG;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_TAG_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_TAG_KeyDown);
			TextBox val2 = _TEXT_TAG;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_TAG = value;
			val2 = _TEXT_TAG;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	public TR_SL_ORD_ADJ()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_SL_ORD_ADJ_Load;
		((Form)this).Deactivate += TR_SL_ORD_ADJ_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_SL_ORD_ADJ_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_SL_ORD_ADJ_KeyDown);
		((Form)this).Activated += TR_SL_ORD_ADJ_Activated;
		((Form)this).Closed += TR_SL_ORD_ADJ_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_SL_ORD_ADJ_KeyUp);
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
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Expected O, but got Unknown
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Expected O, but got Unknown
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected O, but got Unknown
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Expected O, but got Unknown
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0534: Expected O, but got Unknown
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Expected O, but got Unknown
		//IL_0665: Unknown result type (might be due to invalid IL or missing references)
		//IL_066f: Expected O, but got Unknown
		//IL_06d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Expected O, but got Unknown
		//IL_0785: Unknown result type (might be due to invalid IL or missing references)
		//IL_078f: Expected O, but got Unknown
		//IL_07f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fc: Expected O, but got Unknown
		//IL_08a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08af: Expected O, but got Unknown
		//IL_09cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d6: Expected O, but got Unknown
		//IL_0ae1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aeb: Expected O, but got Unknown
		//IL_0b4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b58: Expected O, but got Unknown
		//IL_0cea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da8: Expected O, but got Unknown
		//IL_0ea0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eaa: Expected O, but got Unknown
		//IL_0fbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc5: Expected O, but got Unknown
		//IL_106c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1076: Expected O, but got Unknown
		//IL_10d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e1: Expected O, but got Unknown
		//IL_1163: Unknown result type (might be due to invalid IL or missing references)
		//IL_116d: Expected O, but got Unknown
		//IL_1245: Unknown result type (might be due to invalid IL or missing references)
		//IL_124f: Expected O, but got Unknown
		//IL_12eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f5: Expected O, but got Unknown
		//IL_1430: Unknown result type (might be due to invalid IL or missing references)
		//IL_143a: Expected O, but got Unknown
		//IL_149e: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a8: Expected O, but got Unknown
		//IL_154c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1556: Expected O, but got Unknown
		//IL_15d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15da: Expected O, but got Unknown
		//IL_1662: Unknown result type (might be due to invalid IL or missing references)
		//IL_166c: Expected O, but got Unknown
		//IL_171d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1727: Expected O, but got Unknown
		//IL_17f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_17fe: Expected O, but got Unknown
		//IL_185c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1866: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_SL_ORD_ADJ));
		lblBook = new Label();
		mVchDate = new MaskedTextBox();
		lblBDate = new Label();
		Label2 = new Label();
		tVchNo = new TextBox();
		mDay = new TextBox();
		mTime = new TextBox();
		BtnPrint = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnExit = new SimpleButton();
		PnlBotam = new FlowLayoutPanel();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
		TEXT_ENTRY = new TextBox();
		MSG_TOT = new AxMSFlexGrid();
		MSG = new AxMSFlexGrid();
		DlgOpen = new OpenFileDialog();
		BtnF1 = new SimpleButton();
		Cr = new AxCrystalReport();
		tHdVchNo = new TextBox();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label3 = new Label();
		LOpAmt = new Label();
		MSG_TAG = new AxMSFlexGrid();
		TEXT_TAG = new TextBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG_TAG).BeginInit();
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
		lblBook.Text = "Order Cancel";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mVchDate).Location = new Point(287, 48);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 22);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(214, 49);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(19, 49);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(61, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tVchNo).Location = new Point(86, 48);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 22);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mDay).Location = new Point(448, 48);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 22);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mTime).Location = new Point(368, 48);
		((TextBoxBase)mTime).MaxLength = 8;
		((Control)mTime).Name = "mTime";
		((TextBoxBase)mTime).ReadOnly = true;
		((Control)mTime).Size = new Size(75, 22);
		((Control)mTime).TabIndex = 1132;
		mTime.TextAlign = (HorizontalAlignment)2;
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
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(246, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(575, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((BaseStyleControl)BtnLast).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnLast).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnLast).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnLast).Appearance.Options.UseForeColor = true;
		((Control)BtnLast).Location = new Point(199, 3);
		((BaseControl)BtnLast).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnLast).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnLast).Name = "BtnLast";
		((Control)BtnLast).Size = new Size(41, 37);
		((Control)BtnLast).TabIndex = 5;
		BtnLast.Text = ">";
		((BaseButton)BtnLast).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnFirst).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnFirst).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnFirst).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnFirst).Appearance.Options.UseForeColor = true;
		((Control)BtnFirst).Location = new Point(152, 3);
		((BaseControl)BtnFirst).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnFirst).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnFirst).Name = "BtnFirst";
		((Control)BtnFirst).Size = new Size(41, 37);
		((Control)BtnFirst).TabIndex = 6;
		BtnFirst.Text = "<";
		((BaseButton)BtnFirst).ToolTipAnchor = (ToolTipAnchor)1;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(526, 192);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 3;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)MSG_TOT).Location = new Point(20, 322);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1138, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(19, 85);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1140, 235);
		((Control)MSG).TabIndex = 1135;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((BaseStyleControl)BtnF1).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnF1).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnF1).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnF1).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnF1).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnF1).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnF1).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnF1).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnF1).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnF1).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnF1).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnF1).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnF1).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnF1).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnF1).AppearancePressed.Options.UseFont = true;
		((Control)BtnF1).Location = new Point(170, 47);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1200, 379);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((TextBoxBase)tHdVchNo).BackColor = Color.FromArgb(255, 224, 192);
		((TextBoxBase)tHdVchNo).BorderStyle = (BorderStyle)0;
		((Control)tHdVchNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((TextBoxBase)tHdVchNo).ForeColor = Color.Maroon;
		((Control)tHdVchNo).Location = new Point(8, 8);
		((TextBoxBase)tHdVchNo).MaxLength = 8;
		((Control)tHdVchNo).Name = "tHdVchNo";
		((TextBoxBase)tHdVchNo).ReadOnly = true;
		((Control)tHdVchNo).Size = new Size(56, 15);
		((Control)tHdVchNo).TabIndex = 1159;
		((Control)tHdVchNo).Visible = false;
		((TextBoxBase)tEmpCode).BackColor = Color.White;
		((Control)tEmpCode).Font = new Font("Tahoma", 9f);
		((Control)tEmpCode).Location = new Point(107, 525);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 22);
		((Control)tEmpCode).TabIndex = 4;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tEmpName).Location = new Point(170, 525);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(249, 22);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(25, 525);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)16;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(951, 527);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(207, 20);
		((Control)LOpAmt).TabIndex = 1207;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)MSG_TAG).Location = new Point(19, 343);
		((Control)MSG_TAG).Name = "MSG_TAG";
		((AxHost)MSG_TAG).OcxState = (State)componentResourceManager.GetObject("MSG_TAG.OcxState");
		((Control)MSG_TAG).Size = new Size(1140, 176);
		((Control)MSG_TAG).TabIndex = 1208;
		((TextBoxBase)TEXT_TAG).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_TAG).BorderStyle = (BorderStyle)0;
		((Control)TEXT_TAG).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_TAG).ForeColor = Color.White;
		((Control)TEXT_TAG).Location = new Point(431, 400);
		((Control)TEXT_TAG).Name = "TEXT_TAG";
		((Control)TEXT_TAG).Size = new Size(100, 18);
		((Control)TEXT_TAG).TabIndex = 1209;
		((Control)TEXT_TAG).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)TEXT_TAG);
		((Control)this).Controls.Add((Control)(object)MSG_TAG);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)tEmpCode);
		((Control)this).Controls.Add((Control)(object)tEmpName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)tHdVchNo);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)BtnF1);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG_TOT);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)mDay);
		((Control)this).Controls.Add((Control)(object)mTime);
		((Control)this).Controls.Add((Control)(object)mVchDate);
		((Control)this).Controls.Add((Control)(object)lblBDate);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tVchNo);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "TR_SL_ORD_ADJ";
		((Form)this).Text = "Order Cancel";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG_TAG).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_TAG_CLEAR()
	{
		AxMSFlexGrid mSG_TAG = MSG_TAG;
		MsgClear = true;
		mSG_TAG.Clear();
		mSG_TAG.Cols = 17;
		mSG_TAG.Rows = 2;
		mSG_TAG.Row = 0;
		mSG_TAG[0] = 0;
		mSG_TAG[1] = 0;
		mSG_TAG.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_TAG[0] = (int)Math.Round(500.0 * ColCon);
			mSG_TAG[0] = 3;
			mSG_TAG[0, 0] = "Sr";
			mSG_TAG[1] = (int)Math.Round(1300.0 * ColCon);
			mSG_TAG[1] = 0;
			mSG_TAG[0, 1] = "TagNo";
			mSG_TAG[2] = (int)Math.Round(1100.0 * ColCon);
			mSG_TAG[2] = 0;
			mSG_TAG[0, 2] = "OrdNo";
			mSG_TAG[3] = (int)Math.Round(1000.0 * ColCon);
			mSG_TAG[3] = 0;
			mSG_TAG[0, 3] = "ItCode";
			mSG_TAG[4] = (int)Math.Round(3300.0 * ColCon);
			mSG_TAG[4] = 0;
			mSG_TAG[0, 4] = "ItName";
			mSG_TAG[5] = (int)Math.Round(1100.0 * ColCon);
			mSG_TAG[5] = 0;
			mSG_TAG[0, 5] = "Counter";
			mSG_TAG[6] = (int)Math.Round(1400.0 * ColCon);
			mSG_TAG[6] = 0;
			mSG_TAG[0, 6] = "Design";
			mSG_TAG[7] = (int)Math.Round(800.0 * ColCon);
			mSG_TAG[7] = 7;
			mSG_TAG[0, 7] = "Pcs";
			mSG_TAG[8] = (int)Math.Round(1100.0 * ColCon);
			mSG_TAG[8] = 7;
			mSG_TAG[0, 8] = "GrWt";
			mSG_TAG[9] = (int)Math.Round(1000.0 * ColCon);
			mSG_TAG[9] = 7;
			mSG_TAG[0, 9] = "LsWt";
			mSG_TAG[10] = (int)Math.Round(1100.0 * ColCon);
			mSG_TAG[10] = 7;
			mSG_TAG[0, 10] = "NetWt";
			mSG_TAG[11] = (int)Math.Round(1200.0 * ColCon);
			mSG_TAG[11] = 7;
			mSG_TAG[0, 11] = "Mrp";
			mSG_TAG[12] = 0;
			mSG_TAG[13] = 0;
			mSG_TAG[14] = 0;
			mSG_TAG[15] = 0;
			mSG_TAG[16] = 0;
			mSG_TAG.Row = 1;
			mSG_TAG.Col = 0;
			MsgClear = false;
			MsgLastCol = 11;
			mSG_TAG[0] = (int)Math.Round(325.0 * ColCon);
			mSG_TAG[1] = (int)Math.Round(300.0 * ColCon);
			mSG_TAG.ScrollBars = (ScrollBarsSettings)3;
			CommPassAddTag();
			mSG_TAG = null;
			((Control)TEXT_TAG).Visible = false;
		}
	}

	private void CommPassAddTag()
	{
		AxMSFlexGrid mSG_TAG = MSG_TAG;
		mSG_TAG[mSG_TAG.Row, 0] = Conversions.ToString(MSG_TAG.Row);
		mSG_TAG = null;
	}

	private void MSG_TAG_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_TAG = MSG_TAG;
		UpDown = false;
		checked
		{
			if (mSG_TAG.CellWidth >= 0)
			{
				((Control)TEXT_TAG).Left = (int)Math.Round((double)((Control)mSG_TAG).Left + (double)mSG_TAG.CellLeft / 15.0);
				((Control)TEXT_TAG).Top = (int)Math.Round((double)((Control)mSG_TAG).Top + (double)mSG_TAG.CellTop / 15.0);
				((Control)TEXT_TAG).Width = (int)Math.Round((double)mSG_TAG.CellWidth / 15.0);
				((Control)TEXT_TAG).Height = (int)Math.Round((double)mSG_TAG.CellHeight / 15.0);
				TEXT_TAG.Text = mSG_TAG[mSG_TAG.Row, mSG_TAG.Col];
				if (MsgOldRow != MSG.Row)
				{
					MsgOldRow = 0;
				}
				((Control)TEXT_TAG).Visible = true;
				((TextBoxBase)TEXT_TAG).SelectAll();
				((Control)TEXT_TAG).Focus();
				mSG_TAG = null;
			}
		}
	}

	private void MSG_TAG_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_TAG = MSG_TAG;
		checked
		{
			if (mSG_TAG[mSG_TAG.Col] == 0)
			{
				TEXT_TAG.Text = "";
				if ((mSG_TAG.Col != 5) & (mSG_TAG.Col != 6))
				{
					mSG_TAG[mSG_TAG.Row, mSG_TAG.Col] = "";
				}
				DC_Main.M = 1;
				while (mSG_TAG[mSG_TAG.Col] == 0)
				{
					if (Msgleft)
					{
						if (mSG_TAG.Col > 1)
						{
							mSG_TAG.Col -= 1;
						}
					}
					else if (mSG_TAG.Col < mSG_TAG.Cols - 1)
					{
						mSG_TAG.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 10)
					{
						break;
					}
				}
			}
			if (!((mSG_TAG.Row == 0) | (mSG_TAG.CellWidth <= 0)) && MSG_TAG[MSG_TAG.Col] != 0)
			{
				((Control)TEXT_TAG).Left = (int)Math.Round((double)((Control)mSG_TAG).Left + (double)mSG_TAG.CellLeft / 15.0);
				((Control)TEXT_TAG).Top = (int)Math.Round((double)((Control)mSG_TAG).Top + (double)mSG_TAG.CellTop / 15.0);
				((Control)TEXT_TAG).Width = (int)Math.Round((double)mSG_TAG.CellWidth / 15.0);
				((Control)TEXT_TAG).Height = (int)Math.Round((double)mSG_TAG.CellHeight / 15.0);
				((Control)TEXT_TAG).Visible = true;
				((TextBoxBase)TEXT_TAG).ReadOnly = false;
				switch (MSG_TAG.Col)
				{
				case 0:
				case 3:
					((TextBoxBase)TEXT_TAG).MaxLength = 5;
					TEXT_TAG.Text = mSG_TAG[mSG_TAG.Row, mSG_TAG.Col];
					break;
				case 5:
					((TextBoxBase)TEXT_TAG).MaxLength = 3;
					TEXT_TAG.Text = mSG_TAG[mSG_TAG.Row, mSG_TAG.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_TAG).MaxLength = 10;
					TEXT_TAG.Text = mSG_TAG[mSG_TAG.Row, mSG_TAG.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_TAG).MaxLength = 15;
					TEXT_TAG.Text = mSG_TAG[mSG_TAG.Row, mSG_TAG.Col];
					break;
				case 6:
					((TextBoxBase)TEXT_TAG).MaxLength = 20;
					TEXT_TAG.Text = mSG_TAG[mSG_TAG.Row, mSG_TAG.Col];
					break;
				case 4:
					((TextBoxBase)TEXT_TAG).MaxLength = 50;
					TEXT_TAG.Text = mSG_TAG[mSG_TAG.Row, mSG_TAG.Col];
					break;
				case 7:
					((TextBoxBase)TEXT_TAG).MaxLength = 8;
					TEXT_TAG.Text = Strings.Format((object)Conversion.Val(mSG_TAG[mSG_TAG.Row, mSG_TAG.Col]), "0");
					break;
				case 11:
					((TextBoxBase)TEXT_TAG).MaxLength = 10;
					TEXT_TAG.Text = Strings.Format((object)Conversion.Val(mSG_TAG[mSG_TAG.Row, mSG_TAG.Col]), "0.00");
					break;
				case 8:
				case 9:
				case 10:
					((TextBoxBase)TEXT_TAG).MaxLength = 10;
					TEXT_TAG.Text = Strings.Format((object)Conversion.Val(mSG_TAG[mSG_TAG.Row, mSG_TAG.Col]), "0.000");
					break;
				}
				mSG_TAG = null;
				((TextBoxBase)TEXT_TAG).SelectAll();
			}
		}
	}

	private void MSG_TAG_LeaveCell(object sender, EventArgs e)
	{
		if (UpDown || MsgClear || MSG_TAG.Row == 0 || MSG_TAG[MSG_TAG.Col] == 0 || !((Control)TEXT_TAG).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG_TAG = MSG_TAG;
		switch (MSG_TAG.Col)
		{
		case 2:
		case 3:
			mSG_TAG[mSG_TAG.Row, mSG_TAG.Col] = TEXT_TAG.Text;
			break;
		case 6:
			mSG_TAG[mSG_TAG.Row, mSG_TAG.Col] = TEXT_TAG.Text;
			if (Operators.CompareString(MSG_TAG[MSG_TAG.Row, 1], "", false) == 0)
			{
				if (Operators.CompareString(MSG_TAG[MSG_TAG.Row, 6], "", false) != 0)
				{
					DC_Main.MsImageNo = MSG_TAG[MSG_TAG.Row, 6] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tHdVchNo.Text;
				}
				else
				{
					DC_Main.MsImageNo = "";
				}
				DC_Main.MsImageType = "TagImage";
				DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
			}
			break;
		case 0:
		case 1:
		case 5:
			mSG_TAG[mSG_TAG.Row, mSG_TAG.Col] = TEXT_TAG.Text;
			break;
		case 7:
			mSG_TAG[mSG_TAG.Row, mSG_TAG.Col] = Strings.Format((object)Conversion.Val(TEXT_TAG.Text), "0");
			break;
		case 11:
			mSG_TAG[mSG_TAG.Row, mSG_TAG.Col] = Strings.Format((object)Conversion.Val(TEXT_TAG.Text), "0.00");
			break;
		case 8:
		case 9:
		case 10:
			mSG_TAG[mSG_TAG.Row, mSG_TAG.Col] = Strings.Format((object)Conversion.Val(TEXT_TAG.Text), "0.000");
			break;
		}
		mSG_TAG = null;
	}

	private void CommPassTotalTag()
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		AxMSFlexGrid val = default(AxMSFlexGrid);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000c;
				case 247:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_000c;
						case 3:
							goto IL_0015;
						case 4:
							goto IL_007e;
						case 5:
						case 6:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 7:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_000c:
					num2 = 2;
					val = MSG_TAG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (!((Conversion.Val(val[val.Row, 9]) != 0.0) & (Conversion.Val(val[val.Row, 8]) != 0.0) & (Conversion.Val(val[val.Row, 10]) == 0.0)))
					{
						break;
					}
					goto IL_007e;
					IL_007e:
					num2 = 4;
					val[val.Row, 10] = Strings.Format((object)(Conversion.Val(val[val.Row, 8]) - Conversion.Val(val[val.Row, 9])), "0.000");
					break;
					end_IL_0001_2:
					break;
				}
				val = null;
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 247;
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

	private void TEXT_TAG_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_TAG_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Invalid comparison between Unknown and I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Invalid comparison between Unknown and I4
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Invalid comparison between Unknown and I4
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Invalid comparison between Unknown and I4
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Invalid comparison between Unknown and I4
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Invalid comparison between Unknown and I4
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d49: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		AxMSFlexGrid mSG_TAG = MSG_TAG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = mSG_TAG.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						mSG_TAG[mSG_TAG.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					TEXT_TAG.Text = "";
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 46)
		{
			MsTxtDelete = true;
		}
		else if ((int)keyCode == 8)
		{
			MsTxtDelete = true;
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG_TAG.Col > 1)
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
					mSG_TAG.Col = checked(mSG_TAG.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				checked
				{
					if (mSG_TAG.Col >= MsgLastCol)
					{
						((Control)TEXT_TAG).Focus();
					}
					else if (mSG_TAG.Col < mSG_TAG.Cols - 1)
					{
						if (MsTxtDelete)
						{
							MsTxtDelete = false;
						}
						else
						{
							UpDown = true;
						}
						mSG_TAG.Col += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 38)
			{
				if (mSG_TAG.Row > 1)
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
					mSG_TAG.Row = checked(mSG_TAG.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_TAG.Row < mSG_TAG.Rows - 1)
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
						mSG_TAG.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG_TAG.Col)
					{
					case 1:
						if (!((Operators.CompareString(TEXT_TAG.Text, "", false) == 0) | (Operators.CompareString(TEXT_TAG.Text, mSG_TAG[mSG_TAG.Row, 1], false) != 0)))
						{
							break;
						}
						DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,D.AC_NAME As AcNameL,A.ORD_NO As OrdNoL,A.DESIGN_NO AS DesignNoL,C.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,A.ITM_GWT AS GrWtW,A.ITM_NWT AS NetWtW,A.ITM_MRP as MrpR,A.VCH_SRNO,A.ORD_YRCD As OrdYrCdL,A.ORD_DBCD As OrdDbCdL,A.ORD_SRNO As OrdSrNoL,B.TAG_STK_LESS As TagStkLessM,B.AC_CODE AS AcCodeL  From ((BAR_DETL AS A LEFT JOIN SL_ORD_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.ORD_YRCD = B.CO_YEAR AND A.ORD_DBCD = B.CO_BOOK AND A.ORD_NO = B.VCH_NO AND A.ORD_SRNO = B.OLD_SRNO)LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE =  C.IT_CODE)  LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.ORD_AC = D.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND  A.LC_CODE = '" + DC_Main.MLc_code + "' and A.ORD_NO <> '' AND B.TAG_SALE = 'N' AND B.TAG_STK_LESS = 'Y' ORDER BY A.ORD_NO,A.TAG_NO";
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.ColWidth = new double[16];
						DC_Main.ColWidth[0] = 110.0;
						DC_Main.ColWidth[1] = 275.0;
						DC_Main.ColWidth[2] = 100.0;
						DC_Main.ColWidth[3] = 100.0;
						DC_Main.ColWidth[4] = 200.0;
						DC_Main.ColWidth[5] = 80.0;
						DC_Main.ColWidth[6] = 100.0;
						DC_Main.ColWidth[7] = 100.0;
						DC_Main.ColWidth[8] = 110.0;
						DC_Main.ColWidth[9] = 0.0;
						DC_Main.ColWidth[10] = 0.0;
						DC_Main.ColWidth[11] = 0.0;
						DC_Main.ColWidth[12] = 0.0;
						DC_Main.ColWidth[13] = 100.0;
						DC_Main.ColWidth[14] = 0.0;
						DC_Main.HelpSelect = 1;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						if (DC_Main.HelpClose)
						{
							return;
						}
						if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
						{
							TEXT_TAG.Text = DC_Main.ColValue[0];
							DC_Main.i = 0;
							DC_Main.RsQry = "SELECT * FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.ColValue[10] + "' AND CO_BOOK = '" + DC_Main.ColValue[11] + "' AND VCH_NO = '" + DC_Main.ColValue[2] + "' AND OLD_SRNO = '" + DC_Main.ColValue[12] + "'";
							RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (RsDetl.Rows.Count <= 0)
							{
								break;
							}
							int num2 = mSG_TAG.Rows - 1;
							DC_Main.X = 1;
							while (DC_Main.X <= num2)
							{
								if ((Operators.CompareString(mSG_TAG[DC_Main.X, 1], TEXT_TAG.Text, false) == 0) & (mSG_TAG.Row != DC_Main.X))
								{
									Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
									return;
								}
								DC_Main.X++;
							}
							mSG_TAG[mSG_TAG.Row, 2] = DC_Main.ColValue[2];
							mSG_TAG[mSG_TAG.Row, 12] = DC_Main.ColValue[10];
							mSG_TAG[mSG_TAG.Row, 13] = DC_Main.ColValue[11];
							mSG_TAG[mSG_TAG.Row, 14] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[12]));
							mSG_TAG[mSG_TAG.Row, 16] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[14]));
							mSG_TAG[mSG_TAG.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
							mSG_TAG[mSG_TAG.Row, 4] = DC_Main.ColValue[4];
							mSG_TAG[mSG_TAG.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
							mSG_TAG[mSG_TAG.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
							mSG_TAG[mSG_TAG.Row, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
							mSG_TAG[mSG_TAG.Row, 7] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
							mSG_TAG[mSG_TAG.Row, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
							mSG_TAG[mSG_TAG.Row, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
							mSG_TAG[mSG_TAG.Row, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
							mSG_TAG[mSG_TAG.Row, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
							mSG_TAG[mSG_TAG.Row, 15] = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["VCH_SRNO"])));
							if (Operators.CompareString(EntryMode, "A", false) == 0)
							{
								NewValTot = Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"]));
							}
							if (mSG_TAG.Row == mSG_TAG.Rows - 1)
							{
								MsgClear = true;
								mSG_TAG.Rows += 1;
								mSG_TAG.Row += 1;
								MsgClear = false;
								mSG_TAG.Col = 1;
								CommPassAddTag();
								return;
							}
							break;
						}
						TEXT_TAG.Text = "";
						mSG_TAG[mSG_TAG.Row, 1] = "";
						mSG_TAG[mSG_TAG.Row, 15] = Conversions.ToString(0);
						mSG_TAG[mSG_TAG.Row, 7] = "";
						mSG_TAG[mSG_TAG.Row, 8] = "";
						mSG_TAG[mSG_TAG.Row, 9] = "";
						mSG_TAG[mSG_TAG.Row, 10] = "";
						mSG_TAG[mSG_TAG.Row, 11] = "";
						mSG_TAG[mSG_TAG.Row, 2] = "";
						mSG_TAG[mSG_TAG.Row, 12] = "";
						mSG_TAG[mSG_TAG.Row, 13] = "";
						mSG_TAG[mSG_TAG.Row, 14] = "";
						mSG_TAG[mSG_TAG.Row, 16] = "";
						((Control)TEXT_TAG).Focus();
						return;
					case 3:
						DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_TAG.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.IT_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[7];
							DC_Main.ColWidth[0] = 300.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 250.0;
							DC_Main.ColWidth[3] = 0.0;
							DC_Main.ColWidth[4] = 0.0;
							DC_Main.ColWidth[5] = 0.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_TAG.Text = DC_Main.ColValue[1];
									mSG_TAG[mSG_TAG.Row, 3] = DC_Main.ColValue[1];
									mSG_TAG[mSG_TAG.Row, 4] = DC_Main.ColValue[0];
								}
								((Control)TEXT_TAG).Focus();
							}
							return;
						}
						mSG_TAG[mSG_TAG.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						break;
					case 5:
						DC_Main.RsQry = "Select * From TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' and LC_CODE = '" + DC_Main.MLc_code + "'  AND TABLE_CODE = '" + TEXT_TAG.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT TABLE_NAME As CounterL,TABLE_CODE as CodeL  FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY TABLE_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[3];
							DC_Main.ColWidth[0] = 400.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_TAG.Text = DC_Main.ColValue[1];
									mSG_TAG[mSG_TAG.Row, 5] = DC_Main.ColValue[1];
								}
								((Control)TEXT_TAG).Focus();
							}
							return;
						}
						mSG_TAG[mSG_TAG.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
						break;
					case 8:
						if (Conversion.Val(TEXT_TAG.Text) == 0.0)
						{
							((Control)TEXT_TAG).Focus();
							return;
						}
						break;
					case 11:
						if (mSG_TAG.Row == mSG_TAG.Rows - 1)
						{
							MsgClear = true;
							mSG_TAG.Rows += 1;
							mSG_TAG.Row += 1;
							MsgClear = false;
							mSG_TAG.Col = 1;
							CommPassAddTag();
						}
						else
						{
							mSG_TAG.Row += 1;
							mSG_TAG.Col = 1;
							((Control)TEXT_TAG).Visible = true;
							((Control)TEXT_TAG).Focus();
						}
						return;
					}
					if (mSG_TAG.Col < mSG_TAG.Cols - 1)
					{
						MSG_TAG.Col += 1;
					}
					((Control)TEXT_TAG).Visible = true;
					((Control)TEXT_TAG).Focus();
				}
			}
		}
		mSG_TAG = null;
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 16;
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
			mSG[1] = (int)Math.Round(1100.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "OrdNo";
			mSG[2] = (int)Math.Round(1200.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "AcCode";
			mSG[3] = (int)Math.Round(2800.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "Ac Name";
			mSG[4] = (int)Math.Round(2200.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "It Desc";
			mSG[5] = (int)Math.Round(1100.0 * ColCon);
			mSG[5] = 7;
			mSG[0, 5] = "OrdAmt";
			mSG[6] = (int)Math.Round(1100.0 * ColCon);
			mSG[6] = 7;
			mSG[0, 6] = "AdjAmt";
			mSG[7] = (int)Math.Round(1100.0 * ColCon);
			mSG[7] = 7;
			mSG[0, 7] = "KsarAmt";
			mSG[8] = (int)Math.Round(1100.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "PaidAmt";
			mSG[9] = (int)Math.Round(1200.0 * ColCon);
			mSG[9] = 3;
			mSG[0, 9] = "PaiidAc";
			mSG[10] = (int)Math.Round(2500.0 * ColCon);
			mSG[10] = 0;
			mSG[0, 10] = "Paid Ac Name";
			mSG[11] = 0;
			mSG[12] = 0;
			mSG[13] = 0;
			mSG[14] = 0;
			mSG[15] = 0;
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			MsgLastCol = 6;
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			mSG.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd();
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

	private void MSG_TOT_FILL()
	{
		if (UpDown)
		{
			return;
		}
		AxMSFlexGrid mSG_TOT = MSG_TOT;
		checked
		{
			if (MSG.Rows > 1)
			{
				int num = MSG.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					mSG_TOT[0, DC_Main.M] = "";
					DC_Main.M++;
				}
				mSG_TOT[0, 3] = "Total :";
				int num2 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_TOT[0, 5] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 5]) + Conversion.Val(MSG[DC_Main.M, 5]))), "0.00");
					mSG_TOT[0, 6] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 6]) + Conversion.Val(MSG[DC_Main.M, 6]))), "0.00");
					mSG_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 7]) + Conversion.Val(MSG[DC_Main.M, 7]))), "0.00");
					mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0.00");
					DC_Main.M++;
				}
			}
			mSG_TOT = null;
			NewValTot = Conversion.Val(MSG_TOT[0, 5]) + Conversion.Val(MSG_TOT[0, 6]);
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 9] = "00001";
		mSG[mSG.Row, 10] = "CASH ON HAND";
		mSG[mSG.Row, 14] = "A";
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
				case 2:
				case 9:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 4:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 150;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
				case 10:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 5:
				case 7:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 6:
				case 8:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
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
			case 2:
			case 9:
			case 10:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 0:
			case 1:
			case 3:
			case 4:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 5:
			case 6:
			case 7:
			case 8:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			}
			mSG = null;
		}
	}

	private void CommPassTotal()
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		AxMSFlexGrid val = default(AxMSFlexGrid);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_000c;
				case 143:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_000c;
						case 3:
							goto IL_0015;
						case 4:
							goto IL_005a;
						case 5:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 6:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					val[val.Row, 8] = Strings.Format((object)(Conversion.Val(val[val.Row, 6]) - Conversion.Val(val[val.Row, 7])), "0.00");
					goto IL_005a;
					IL_005a:
					val = null;
					break;
					end_IL_0001_2:
					break;
				}
				num2 = 5;
				MSG_TOT_FILL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 143;
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
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e55: Unknown result type (might be due to invalid IL or missing references)
		//IL_1212: Unknown result type (might be due to invalid IL or missing references)
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
					checked
					{
						switch (mSG.Col)
						{
						case 1:
						{
							if (!((Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0) | (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 1], false) != 0)))
							{
								break;
							}
							DC_Main.RsQry = "SELECT * FROM SL_ORD_DATA AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[mSG.Row, 11] + "' AND CO_BOOK = '" + mSG[mSG.Row, 12] + "' AND VCH_NO = '" + TEXT_ENTRY.Text + "' ";
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME AS PartyNameL,A.AC_CODE AS AcCodeL,A.VCH_NO AS VchNoT,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS OrderDtL,A.ADV_AMT AS AmountR,SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_AMT ELSE 0 END) AS AdjAmtR ,A.CO_YEAR AS YearL,A.CO_BOOK as BookL,A.HD_VCH_NO As HdVchNoL FROM SL_ORD_DATA AS A LEFT JOIN SL_ORD_ADJ AS B ON  A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC AND A.CO_YEAR = B.ORD_YRCD AND A.CO_BOOK = B.ORD_DBCD AND A.VCH_NO = B.ORD_NO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  GROUP BY A.AC_NAME,A.AC_CODE,A.VCH_NO,A.VCH_DATE,A.ADV_AMT,A.CO_YEAR,A.CO_BOOK,A.HD_VCH_NO HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END) > 0  ORDER BY A.VCH_DATE,A.VCH_NO ";
								DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.ColWidth = new double[10];
								DC_Main.ColWidth[0] = 320.0;
								DC_Main.ColWidth[1] = 100.0;
								DC_Main.ColWidth[2] = 95.0;
								DC_Main.ColWidth[3] = 130.0;
								DC_Main.ColWidth[4] = 115.0;
								DC_Main.ColWidth[5] = 115.0;
								DC_Main.ColWidth[6] = 110.0;
								DC_Main.ColWidth[7] = 90.0;
								DC_Main.ColWidth[8] = 0.0;
								DC_Main.HelpSelect = 1;
								((Form)MyProject.Forms.MS_HELP).ShowDialog();
								if (!DC_Main.HelpClose)
								{
									if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
									{
										TEXT_ENTRY.Text = DC_Main.ColValue[2];
										mSG[mSG.Row, 3] = DC_Main.ColValue[0];
										mSG[mSG.Row, 11] = DC_Main.ColValue[6];
										mSG[mSG.Row, 12] = DC_Main.ColValue[7];
										mSG[mSG.Row, 2] = DC_Main.ColValue[1];
										mSG[mSG.Row, 13] = DC_Main.ColValue[8];
										mSG[mSG.Row, 15] = DC_Main.MLc_code;
										LessAdvAmt = Conversions.ToDouble(DC_Main.ColValue[5]);
									}
									((Control)TEXT_ENTRY).Focus();
								}
								return;
							}
							mSG[mSG.Row, 1] = TEXT_ENTRY.Text;
							mSG[mSG.Row, 12] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CO_BOOK"], (object)""));
							mSG[mSG.Row, 13] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["HD_VCH_NO"], (object)""));
							AxMSFlexGrid obj = mSG;
							int row = mSG.Row;
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["ADV_AMT"]);
							double num = DC_Main.Fnv(ref Value);
							dataRow["ADV_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							obj[row, 5] = Strings.Format((object)(num - LessAdvAmt), "0.00");
							AxMSFlexGrid obj2 = mSG;
							int row2 = mSG.Row;
							Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["ADV_AMT"]);
							double num2 = DC_Main.Fnv(ref Value);
							dataRow["ADV_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							obj2[row2, 6] = Strings.Format((object)(num2 - LessAdvAmt), "0.00");
							if (Conversion.Val(mSG[mSG.Row, 8]) == 0.0)
							{
								AxMSFlexGrid obj3 = mSG;
								int row3 = mSG.Row;
								Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["ADV_AMT"]);
								double num3 = DC_Main.Fnv(ref Value);
								dataRow["ADV_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								obj3[row3, 8] = Strings.Format((object)(num3 - LessAdvAmt), "0.00");
							}
							mSG[mSG.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CODE"], (object)""));
							mSG[mSG.Row, 15] = DC_Main.MLc_code;
							LessAdvAmt = 0.0;
							DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_ORD_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[mSG.Row, 11] + "' AND CO_BOOK = '" + mSG[mSG.Row, 12] + "' AND VCH_NO = '" + mSG[mSG.Row, 1] + "' AND A.TAG_SALE = 'N' AND A.TAG_STK_LESS = 'Y'";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count > 0)
							{
								DC_Main.i = 0;
								DC_Main.R = 1;
								while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
								{
									MSG_TAG[DC_Main.R, 0] = Conversions.ToString(DC_Main.R);
									MSG_TAG[DC_Main.R, 16] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["AC_CODE"], (object)""));
									MSG_TAG[DC_Main.R, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"], (object)""));
									MSG_TAG[DC_Main.R, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_NO"], (object)""));
									MSG_TAG[DC_Main.R, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)""));
									MSG_TAG[DC_Main.R, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)""));
									MSG_TAG[DC_Main.R, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TBL_CODE"], (object)""));
									MSG_TAG[DC_Main.R, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
									MSG_TAG[DC_Main.R, 7] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_PCS"]);
									MSG_TAG[DC_Main.R, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
									MSG_TAG[DC_Main.R, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
									MSG_TAG[DC_Main.R, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
									MSG_TAG[DC_Main.R, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
									MSG_TAG[DC_Main.R, 15] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
									MSG_TAG[DC_Main.R, 12] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["CO_YEAR"], (object)""));
									MSG_TAG[DC_Main.R, 13] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["CO_BOOK"], (object)""));
									MSG_TAG[DC_Main.R, 14] = Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"], (object)"")));
									MSG_TAG.Rows += 1;
									DC_Main.R++;
									DC_Main.i++;
								}
								MSG_TAG.Rows -= 1;
							}
							break;
						}
						case 2:
							DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + TEXT_ENTRY.Text + "'";
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count == 0)
							{
								if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
								{
									DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.LC_CODE,A.AC_NAME";
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
								if (DC_Main.HelpClose)
								{
									return;
								}
								if (DC_Main.MsCreat)
								{
									MS_ACCT mS_ACCT2 = new MS_ACCT();
									((Form)mS_ACCT2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
									((Control)mS_ACCT2).Show();
									((Control)mS_ACCT2).Focus();
									return;
								}
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[1];
									mSG[mSG.Row, 2] = DC_Main.ColValue[1];
									if (Operators.CompareString(mSG[mSG.Row, 2], "00020", false) != 0)
									{
										mSG[mSG.Row, 3] = DC_Main.ColValue[0];
									}
								}
								((Control)TEXT_ENTRY).Focus();
								return;
							}
							if (Operators.CompareString(mSG[mSG.Row, 2], "00020", false) != 0)
							{
								mSG[mSG.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
							}
							DC_Main.MsAcBal(mSG[mSG.Row, 2], Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
							if (DC_Main.MsAcAmtOpBal > 0.0)
							{
								LOpAmt.Text = Strings.Format((object)DC_Main.MsAcAmtOpBal, "0.00") + " : Cr Amt";
								((Control)LOpAmt).ForeColor = Color.Blue;
							}
							else if (DC_Main.MsAcAmtOpBal < 0.0)
							{
								LOpAmt.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcAmtOpBal), "0.00") + " : Dr Amt";
								((Control)LOpAmt).ForeColor = Color.Red;
							}
							else
							{
								LOpAmt.Text = ": Amt";
							}
							CustOpAmt = DC_Main.MsAcAmtOpBal;
							DC_Main.MsAcAmtOpBal = 0.0;
							DC_Main.MsAcGoldOpBal = 0.0;
							DC_Main.MsAcSilverOpBal = 0.0;
							DC_Main.MsAcAmtClBal = 0.0;
							DC_Main.MsAcGoldClBal = 0.0;
							DC_Main.MsAcSilverClBal = 0.0;
							break;
						case 9:
							DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + TEXT_ENTRY.Text + "'";
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_ADD1 As AddressL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 200   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_ADD1,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
								DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.ColWidth = new double[7];
								DC_Main.ColWidth[0] = 300.0;
								DC_Main.ColWidth[1] = 100.0;
								DC_Main.ColWidth[2] = 220.0;
								DC_Main.ColWidth[3] = 280.0;
								DC_Main.ColWidth[4] = 120.0;
								DC_Main.HelpSelect = 1;
								((Form)MyProject.Forms.MS_HELP).ShowDialog();
								if (DC_Main.HelpClose)
								{
									return;
								}
								if (DC_Main.MsCreat)
								{
									MS_ACCT mS_ACCT = new MS_ACCT();
									((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
									((Control)mS_ACCT).Show();
									((Control)mS_ACCT).Focus();
									return;
								}
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[1];
									mSG[mSG.Row, 9] = DC_Main.ColValue[1];
									mSG[mSG.Row, 10] = DC_Main.ColValue[0];
								}
								((Control)TEXT_ENTRY).Focus();
								return;
							}
							mSG[mSG.Row, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
							break;
						case 6:
							if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
							{
								((Control)TEXT_ENTRY).Focus();
								return;
							}
							break;
						case 10:
							if (mSG.Row == mSG.Rows - 1)
							{
								mSG[mSG.Row, 10] = TEXT_ENTRY.Text;
								MsgClear = true;
								mSG.Rows += 1;
								mSG.Row += 1;
								MsgClear = false;
								mSG.Col = 1;
								CommPassAdd();
							}
							else
							{
								mSG.Row += 1;
								mSG.Col = 1;
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
			if ((int)keyCode == 46)
			{
				MsTxtDelete = true;
			}
		}
		mSG = null;
	}

	private void TR_SL_ORD_ADJ_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0a72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a81: Expected O, but got Unknown
		//IL_0aa6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab5: Expected O, but got Unknown
		//IL_0af4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b03: Expected O, but got Unknown
		//IL_0b1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2c: Expected O, but got Unknown
		//IL_0b46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b55: Expected O, but got Unknown
		//IL_0b7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b84: Expected O, but got Unknown
		//IL_0c15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c24: Expected O, but got Unknown
		//IL_0cac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbb: Expected O, but got Unknown
		//IL_0d2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d38: Expected O, but got Unknown
		//IL_0dc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dcf: Expected O, but got Unknown
		//IL_0df4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e03: Expected O, but got Unknown
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
				TextBox obj4 = tHdVchNo;
				object? obj5 = colorConverter.ConvertFromString("MistyRose");
				((TextBoxBase)obj4).BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				Label obj6 = lblBook;
				object? obj7 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj6).ForeColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj8 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				AxMSFlexGrid mSG = MSG;
				object? obj9 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj10 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj10 != null) ? ((Color)obj10) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj11 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj11 != null) ? ((Color)obj11) : default(Color));
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				object? obj12 = colorConverter.ConvertFromString("Silver");
				mSG_TOT.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				AxMSFlexGrid mSG_TOT2 = MSG_TOT;
				object? obj13 = colorConverter.ConvertFromString("Silver");
				mSG_TOT2.BackColorBkg = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG_TOT3 = MSG_TOT;
				object? obj14 = colorConverter.ConvertFromString("Silver");
				mSG_TOT3.BackColorFixed = ((obj14 != null) ? ((Color)obj14) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj15 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj16 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj17 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj18 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj19 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj20 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj21 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj22 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj22 != null) ? ((Color)obj22) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj23 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj24 = lblBook;
				object? obj25 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj24).ForeColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj26 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj27 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj28 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj29 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj30 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj31 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj32 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj33 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_TAG).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_TAG).Font = new Font(((Control)TEXT_TAG).Font.FontFamily, (float)num3, ((Control)TEXT_TAG).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_TAG.Font = new Font("Segoe UI Semibold", (float)num3, MSG_TAG.Font.Style);
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_TAG", false) != 0)))
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
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnFirst).Font.Size * (1.0 + num2));
				((BaseStyleControl)BtnFirst).Font = new Font(((BaseStyleControl)BtnFirst).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnFirst).Font.Style);
				((BaseStyleControl)BtnLast).Font = new Font(((BaseStyleControl)BtnLast).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnLast).Font.Style);
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
			CurActCtrl = (Control)(object)tVchNo;
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
		DataTrfr = "N";
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		((TextBoxBase)tVchNo).ReadOnly = true;
		OldValTot = 0.0;
		NewValTot = 0.0;
		LessAdvAmt = 0.0;
		UsUPdate = "N";
		UsDelete = "N";
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_TAG).Visible = false;
		LOpAmt.Text = ": Amt";
		((Control)LOpAmt).ForeColor = Color.Black;
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		MSG_CLEAR();
		MSG_TAG_CLEAR();
		FilRow = 0;
		if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
		{
			tEmpCode.Text = DC_Main.MsUserEmpCode;
			tEmpName.Text = DC_Main.MsUserEmpName;
		}
		DC_Main.RsQry = "Select VCH_NO As VchNo  From SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "'  UNION ALL SELECT VCH_NO FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' GROUP BY VCH_NO ORDER BY VCH_NO DESC";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			tVchNo.Text = "00001";
		}
		else
		{
			tVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
			MaxVchNo = tVchNo.Text;
		}
		LastVchNo = tVchNo.Text;
		DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			tHdVchNo.Text = "00001";
		}
		else
		{
			tHdVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
		}
		EntryMode = "A";
		((Control)BtnSave).Enabled = true;
		((Control)tVchNo).Focus();
	}

	private void DISPLAY_DATA()
	{
		MSG_CLEAR();
		MSG_TAG_CLEAR();
		DC_Main.RsQry = "SELECT * FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
		RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (RsData.Rows.Count > 0)
			{
				tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_NO"], (object)""));
				tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HD_VCH_NO"], (object)""));
				tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
				DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["EMP_NAME"], (object)""));
				}
				CurPrnVch = tVchNo.Text;
				mVchDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DATE"], (object)""));
				mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
				mTime.Text = Strings.Format((object)Conversions.ToDate(RsData.Rows[0]["VCH_TIME"]), "HH:mm:ss");
				MainUser = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MAIN_USER"], (object)""));
				UsUPdate = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_UPDATE"], (object)""));
				UsDelete = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_DELETE"], (object)""));
				DataTrfr = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["DATA_TRFR"], (object)""));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["RE_TRFR"], (object)""), (object)"Y", false))
				{
					DataTrfr = "Y";
				}
				if (Operators.CompareString(UsUPdate, "Y", false) == 0)
				{
					((BaseStyleControl)BtnSave).ForeColor = Color.Green;
				}
				if (Operators.CompareString(UsDelete, "Y", false) == 0)
				{
					((BaseStyleControl)BtnDelete).ForeColor = Color.Green;
				}
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsData.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["ORD_NO"], (object)""));
					mSG[DC_Main.i + 1, 13] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["ORD_HD_VCH_NO"], (object)""));
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["AC_CODE"], (object)""));
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["AC_NAME"], (object)""));
					AxMSFlexGrid obj = mSG;
					int num = DC_Main.i + 1;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[DC_Main.i])["ORD_BAL_AMT"]);
					double num2 = DC_Main.Fnv(ref Value);
					dataRow["ORD_BAL_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					obj[num, 5] = Strings.Format((object)num2, "0.00");
					AxMSFlexGrid obj2 = mSG;
					int num3 = DC_Main.i + 1;
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[DC_Main.i])["ORD_AMT"]);
					double num4 = DC_Main.Fnv(ref Value);
					dataRow["ORD_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					obj2[num3, 6] = Strings.Format((object)num4, "0.00");
					AxMSFlexGrid obj3 = mSG;
					int num5 = DC_Main.i + 1;
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[DC_Main.i])["KASAR_AMT"]);
					double num6 = DC_Main.Fnv(ref Value);
					dataRow["KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					obj3[num5, 7] = Strings.Format((object)num6, "0.00");
					mSG[DC_Main.i + 1, 15] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["ORD_LC"], (object)""));
					mSG[DC_Main.i + 1, 11] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["ORD_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 12] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["ORD_DBCD"], (object)""));
					AxMSFlexGrid obj4 = mSG;
					int num7 = DC_Main.i + 1;
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[DC_Main.i])["PAID_AMT"]);
					double num8 = DC_Main.Fnv(ref Value);
					dataRow["PAID_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					obj4[num7, 8] = Strings.Format((object)num8, "0.00");
					mSG[DC_Main.i + 1, 9] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["PAID_AC"], (object)""));
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '"), RsData.Rows[DC_Main.i]["PAID_AC"]), (object)""), (object)"'"));
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						mSG[DC_Main.i + 1, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
					}
					DC_Main.Rshlp.Clear();
					DC_Main.Rshlp.Columns.Clear();
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["IT_DESC"], (object)""));
					mSG[DC_Main.i + 1, 14] = "E";
					PartyAcCode = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[DC_Main.i]["AC_CODE"], (object)""));
					DC_Main.MsAcBal(PartyAcCode, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
					if (DC_Main.MsAcAmtOpBal > 0.0)
					{
						LOpAmt.Text = Strings.Format((object)DC_Main.MsAcAmtOpBal, "0.00") + " : Cr Amt";
						((Control)LOpAmt).ForeColor = Color.Blue;
					}
					else if (DC_Main.MsAcAmtOpBal < 0.0)
					{
						LOpAmt.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcAmtOpBal), "0.00") + " : Dr Amt";
						((Control)LOpAmt).ForeColor = Color.Red;
					}
					else
					{
						LOpAmt.Text = ": Amt";
					}
					CustOpAmt = DC_Main.MsAcAmtOpBal;
					CustClAmt = DC_Main.MsAcAmtClBal;
					DC_Main.MsAcAmtOpBal = 0.0;
					DC_Main.MsAcGoldOpBal = 0.0;
					DC_Main.MsAcSilverOpBal = 0.0;
					DC_Main.MsAcAmtClBal = 0.0;
					DC_Main.MsAcGoldClBal = 0.0;
					DC_Main.MsAcSilverClBal = 0.0;
					mSG.Rows += 1;
					DC_Main.i++;
					DC_Main.R++;
				}
				if (mSG.Rows > 2)
				{
					mSG.Rows -= 1;
				}
				OrderTagFeel();
				mSG = null;
			}
			else
			{
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (RsDetl.Rows.Count <= 0)
				{
					((Control)mVchDate).Focus();
					EntryMode = "A";
					return;
				}
				OrderTagFeel();
			}
			MSG_TOT_FILL();
			OldValTot = Conversion.Val(MSG_TOT[0, 5]) + Conversion.Val(MSG_TOT[0, 6]);
			NewValTot = Conversion.Val(MSG_TOT[0, 5]) + Conversion.Val(MSG_TOT[0, 6]);
			EntryMode = "E";
			MsVchSrno = "";
			((TextBoxBase)tVchNo).ReadOnly = true;
			((Control)mVchDate).Focus();
		}
	}

	private void OrderTagFeel()
	{
		DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
		RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.i = 0;
		if (RsDetl.Rows.Count > 0 && Operators.CompareString(tEmpCode.Text, "", false) == 0)
		{
			tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["EMP_CODE"], (object)""));
			DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["EMP_NAME"], (object)""));
			}
		}
		AxMSFlexGrid mSG_TAG = MSG_TAG;
		checked
		{
			while (DC_Main.i < RsDetl.Rows.Count)
			{
				mSG_TAG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
				mSG_TAG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_NO"], (object)""));
				mSG_TAG[DC_Main.i + 1, 16] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["AC_CODE"], (object)""));
				mSG_TAG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
				mSG_TAG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
				{
					mSG_TAG[DC_Main.i + 1, 1] = "";
				}
				else
				{
					mSG_TAG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
				}
				mSG_TAG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
				mSG_TAG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
				mSG_TAG[DC_Main.i + 1, 7] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
				mSG_TAG[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
				mSG_TAG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
				mSG_TAG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
				mSG_TAG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
				mSG_TAG[DC_Main.i + 1, 12] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_YRCD"], (object)""));
				mSG_TAG[DC_Main.i + 1, 13] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_DBCD"], (object)""));
				mSG_TAG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_SRNO"], (object)"")), "0");
				mSG_TAG[DC_Main.i + 1, 15] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
				mSG_TAG[DC_Main.i + 1, 14] = "E";
				mSG_TAG.Rows += 1;
				DC_Main.i++;
			}
			mSG_TAG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
			mSG_TAG = null;
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void TR_SL_ORD_ADJ_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_SL_ORD_ADJ_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
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
						if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
						{
							Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
							goto end_IL_0001;
						}
						if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
						{
							Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
							((Control)tEmpCode).Focus();
							goto end_IL_0001;
						}
						if ((Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
						{
							Interaction.MsgBox((object)"You Cant Save This Voucher Becouse This Company Type is B......", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						((Control)BtnSave).Enabled = false;
						if ((DateTime.Compare(Conversions.ToDate(DC_Main.MCo_OpDate), Conversions.ToDate(mVchDate.Text)) > 0) | (DateTime.Compare(Conversions.ToDate(DC_Main.MCo_ClDate), Conversions.ToDate(mVchDate.Text)) < 0))
						{
							Interaction.MsgBox((object)"You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
						{
							Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						if (Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0)))
						{
							Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						if (Operators.CompareString(tVchNo.Text, "", false) == 0)
						{
							Interaction.MsgBox((object)"Please Insert VchNo and try", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						MSG_TOT_FILL();
						ProjectData.ClearProjectError();
						num2 = 2;
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							DC_Main.RsQry = "SELECT * FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count > 0)
							{
								DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
								DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								if (DC_Main.Rshlp.Rows.Count > 0)
								{
									Interaction.MsgBox((object)("Current Voucher No has been changd New Voucher No is  '" + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000") + "'"), (MsgBoxStyle)0, (object)null);
									tVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
								}
							}
							DC_Main.RsQry = "SELECT * FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count > 0)
							{
								DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
								DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								if (DC_Main.Rshlp.Rows.Count > 0)
								{
									tHdVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
								}
							}
						}
						DC_Main.ExeQuteDc("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						if (Conversion.Val(MSG_TOT[0, 5]) + Conversion.Val(MSG_TOT[0, 6]) != 0.0)
						{
							DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
							DC_Main.RsQry = "SELECT * FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
							DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.MsInsertData();
							DataRow dataRow = dataTable.NewRow();
							dataRow["CO_CODE"] = DC_Main.MCo_code;
							dataRow["LC_CODE"] = DC_Main.MLc_code;
							dataRow["CO_BOOK"] = DC_Main.MCo_Book;
							dataRow["VCH_NO"] = tHdVchNo.Text;
							dataRow["BOOK_NAME"] = FormName;
							dataTable.Rows.Add(dataRow);
							((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
							dataTable.Clear();
							DC_Main.R = 0;
							DC_Main.RsQry = "SELECT * FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
							RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.MsInsertData();
							DataRow dataRow2 = RsData.NewRow();
							int num3 = MSG.Rows - 1;
							DC_Main.i = 1;
							while (DC_Main.i <= num3)
							{
								AxMSFlexGrid mSG = MSG;
								if ((Operators.CompareString(mSG[DC_Main.i, 2], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 6]) + Conversion.Val(mSG[DC_Main.i, 5]) != 0.0))
								{
									dataRow2["CO_CODE"] = DC_Main.MCo_code;
									dataRow2["LC_CODE"] = DC_Main.MLc_code;
									dataRow2["CO_YEAR"] = DC_Main.MCo_year;
									dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
									dataRow2["VCH_NO"] = tVchNo.Text;
									dataRow2["VCH_DATE"] = mVchDate.Text;
									dataRow2["VCH_TYPE"] = FormBookSname;
									dataRow2["INOUT_TYPE"] = FormBookInOut;
									dataRow2["ENTRY_TYPE"] = "C";
									dataRow2["BOOK_NAME"] = FormMainBook;
									dataRow2["AC_CODE"] = mSG[DC_Main.i, 2];
									dataRow2["AC_NAME"] = mSG[DC_Main.i, 3];
									dataRow2["ORD_HD_VCH_NO"] = mSG[DC_Main.i, 13];
									dataRow2["ORD_NO"] = mSG[DC_Main.i, 1];
									dataRow2["ORD_LC"] = mSG[DC_Main.i, 15];
									dataRow2["ORD_YRCD"] = mSG[DC_Main.i, 11];
									dataRow2["ORD_DBCD"] = mSG[DC_Main.i, 12];
									dataRow2["ORD_AC_CODE"] = mSG[DC_Main.i, 2];
									dataRow2["ORD_SIGN"] = "-";
									dataRow2["ORD_BAL_AMT"] = Conversion.Val(mSG[DC_Main.i, 5]);
									dataRow2["ORD_AMT"] = Conversion.Val(mSG[DC_Main.i, 6]);
									dataRow2["PAID_AC"] = mSG[DC_Main.i, 9];
									dataRow2["PAID_AMT"] = Conversion.Val(mSG[DC_Main.i, 8]);
									dataRow2["KASAR_AMT"] = Conversion.Val(mSG[DC_Main.i, 7]);
									dataRow2["ORD_GOLD"] = 0;
									dataRow2["ORD_SILVER"] = 0;
									dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
									if (Operators.CompareString(EntryMode, "A", false) == 0)
									{
										dataRow2["MAIN_USER"] = DC_Main.MCo_User;
									}
									dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
									dataRow2["IT_DESC"] = mSG[DC_Main.i, 4];
									dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
									dataRow2["EMP_CODE"] = tEmpCode.Text;
									dataRow2["DATA_TRFR"] = "N";
									if (Operators.CompareString(DataTrfr, "Y", false) == 0)
									{
										dataRow2["RE_TRFR"] = "Y";
									}
									else
									{
										dataRow2["RE_TRFR"] = "N";
									}
									dataRow2["MAIN_USER"] = MainUser;
									dataRow2["USER_UPDATE"] = "N";
									dataRow2["USER_DELETE"] = "N";
									RsData.Rows.Add(dataRow2);
									((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
									RsData.Clear();
								}
								mSG = null;
								DC_Main.i++;
							}
						}
						DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						DC_Main.ExeQuteDc("DELETE FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						DC_Main.RsQry = "SELECT * FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow3 = RsDetl.NewRow();
						int num4 = MSG_TAG.Rows - 1;
						DC_Main.i = 1;
						while (DC_Main.i <= num4)
						{
							AxMSFlexGrid mSG_TAG = MSG_TAG;
							if (((Operators.CompareString(mSG_TAG[DC_Main.i, 3], "", false) != 0) & (Operators.CompareString(mSG_TAG[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(mSG_TAG[DC_Main.i, 11]) != 0.0)) | (Conversion.Val(mSG_TAG[DC_Main.i, 7]) + Conversion.Val(mSG_TAG[DC_Main.i, 8]) != 0.0))
							{
								dataRow3["CO_CODE"] = DC_Main.MCo_code;
								dataRow3["LC_CODE"] = DC_Main.MLc_code;
								dataRow3["CO_YEAR"] = DC_Main.MCo_year;
								dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
								dataRow3["VCH_NO"] = tVchNo.Text;
								dataRow3["VCH_DATE"] = mVchDate.Text;
								dataRow3["HD_VCH_NO"] = tHdVchNo.Text;
								dataRow3["AC_CODE"] = mSG_TAG[DC_Main.i, 16];
								dataRow3["VCH_TYPE"] = FormBookSname;
								dataRow3["INOUT_TYPE"] = FormBookInOut;
								dataRow3["ENTRY_TYPE"] = "I";
								dataRow3["BOOK_NAME"] = FormMainBook;
								dataRow3["SR_NO"] = Conversion.Val(mSG_TAG[DC_Main.i, 0]);
								dataRow3["OLD_SRNO"] = Conversion.Val(mSG_TAG[DC_Main.i, 0]);
								dataRow3["ISU_NO"] = mSG_TAG[DC_Main.i, 2];
								dataRow3["ISU_AC_NAME"] = "";
								dataRow3["ITM_REMARK"] = mSG_TAG[DC_Main.i, 4];
								dataRow3["MTL_COLOR"] = "";
								dataRow3["ISU_AC_CODE"] = mSG_TAG[DC_Main.i, 16];
								dataRow3["IT_CODE"] = mSG_TAG[DC_Main.i, 3];
								if (Operators.CompareString(mSG_TAG[DC_Main.i, 1], "", false) == 0)
								{
									dataRow3["TAG_NO"] = "N";
									dataRow3["VCH_SRNO"] = 0;
								}
								else
								{
									dataRow3["TAG_NO"] = mSG_TAG[DC_Main.i, 1];
									dataRow3["VCH_SRNO"] = Conversion.Val(mSG_TAG[DC_Main.i, 15]);
								}
								dataRow3["TBL_CODE"] = mSG_TAG[DC_Main.i, 5];
								dataRow3["DESIGN_NO"] = mSG_TAG[DC_Main.i, 6];
								dataRow3["ITM_PCS"] = Conversion.Val(mSG_TAG[DC_Main.i, 7]);
								dataRow3["ITM_GWT"] = Conversion.Val(mSG_TAG[DC_Main.i, 8]);
								dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG_TAG[DC_Main.i, 9]);
								dataRow3["ITM_NWT"] = Conversion.Val(mSG_TAG[DC_Main.i, 10]);
								dataRow3["ITM_MRP"] = Conversion.Val(mSG_TAG[DC_Main.i, 11]);
								dataRow3["ISU_REC"] = "Y";
								dataRow3["ISU_YRCD"] = mSG_TAG[DC_Main.i, 12];
								dataRow3["ISU_DBCD"] = mSG_TAG[DC_Main.i, 13];
								dataRow3["ISU_SRNO"] = Conversion.Val(mSG_TAG[DC_Main.i, 14]);
								dataRow3["EMP_SALE"] = "N";
								dataRow3["DESIGN_IMG_ID"] = "N";
								dataRow3["ORNA_REC_DATE"] = mVchDate.Text;
								dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
								dataRow3["MAIN_USER"] = MainUser;
								dataRow3["EMP_CODE"] = tEmpCode.Text;
								DC_Main.RsQry = "INSERT INTO BAR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,STK_DATE,VCH_TIME,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,  BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,  LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,KR_OTH_WT,  KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,  TAG_SRNO,VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,ORD_AC,  MAIN_USER,ADD_USER,DATA_TRFR,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,  HM_ID4_WT,HM_ID,DATA_TYPE,APP_TRFR,ITM_COLOR,MAIN_MARGIN_PRC,MAIN_MRP,JDT_JDT_WT,JDT_GHT_WT,JDT_KUN_WT,JDT_WAX_WT,  KR_WAX_WT,JDT_KUN_TOUCH,JDT_KUN_NET,EMP_ISU,LBR_CODE,DESIGN_IMG_ID)   SELECT TOP 1 CO_CODE,LC_CODE,'" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "'," + Conversions.ToString(Conversion.Val(mSG_TAG[DC_Main.i, 0])) + "," + Conversions.ToString(Conversion.Val(mSG_TAG[DC_Main.i, 0])) + ",'" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "',STK_DATE,'" + Strings.Format((object)Conversions.ToDate(mVchDate.Text + " " + mTime.Text), "MM/dd/yyyy HH:mm:ss") + "',  '" + FormBookSname + "','" + FormBookInOut + "','D','" + FormMainBook + "',AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,'" + mSG_TAG[DC_Main.i, 5] + "',ITM_SIZE,ITM_PCS,  BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,  LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,KR_OTH_WT,  KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,  TAG_SRNO," + Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 1, 1) + Conversions.ToString(Conversion.Val(DC_Main.MCo_Book)) + Conversions.ToString(Conversion.Val(tVchNo.Text)) + Conversions.ToString(Conversion.Val(mSG_TAG[DC_Main.i, 0])) + ",RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,APR_ISU,'',0,'','','',  MAIN_USER,ADD_USER,DATA_TRFR,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,  HM_ID4_WT,HM_ID,DATA_TYPE,APP_TRFR,ITM_COLOR,MAIN_MARGIN_PRC,MAIN_MRP,JDT_JDT_WT,JDT_GHT_WT,JDT_KUN_WT,JDT_WAX_WT,  KR_WAX_WT,JDT_KUN_TOUCH,JDT_KUN_NET,EMP_ISU,LBR_CODE,DESIGN_IMG_ID FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO =  '" + mSG_TAG[DC_Main.i, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG_TAG[DC_Main.i, 15])) + " ORDER BY VCH_TIME DESC ";
								DC_Main.ExeQuteDc(DC_Main.RsQry);
								DC_Main.RsQry = "INSERT INTO BAR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,  BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,  KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER,DM_NAME,OLD_VCH_NO,NEW_VCH_NO,DM_ORIGIN,  DM_REMARK,DM_COLOR,KR_ACT_WT,KR_ACT_PRC)   SELECT CO_CODE,LC_CODE,'" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "'," + Conversions.ToString(Conversion.Val(mSG_TAG[DC_Main.i, 0])) + ",ISR_NO,'" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "','" + FormBookSname + "','" + FormBookInOut + "','D',  '" + FormMainBook + "',AC_CODE,TAG_NO," + Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 1, 1) + Conversions.ToString(Conversion.Val(DC_Main.MCo_Book)) + Conversions.ToString(Conversion.Val(tVchNo.Text)) + Conversions.ToString(Conversion.Val(mSG_TAG[DC_Main.i, 0])) + ",IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,  KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER,DM_NAME,OLD_VCH_NO,NEW_VCH_NO,DM_ORIGIN,  DM_REMARK,DM_COLOR,KR_ACT_WT,KR_ACT_PRC FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO =  '" + mSG_TAG[DC_Main.i, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG_TAG[DC_Main.i, 15])) + "  ";
								DC_Main.ExeQuteDc(DC_Main.RsQry);
								RsDetl.Rows.Add(dataRow3);
								((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
								RsDetl.Clear();
							}
							mSG_TAG = null;
							DC_Main.i++;
						}
						DC_Main.RsQry = "UPDATE SL_ORD_DETL  SET SL_ORD_DETL.TAG_SALE = 'Y'  FROM SL_ORD_DETL,APR_DETL AS A WHERE SL_ORD_DETL.CO_CODE = A.CO_CODE AND SL_ORD_DETL.LC_CODE = A.LC_CODE AND SL_ORD_DETL.VCH_NO = A.ISU_NO AND SL_ORD_DETL.CO_YEAR = A.ISU_YRCD AND SL_ORD_DETL.CO_BOOK = A.ISU_DBCD AND SL_ORD_DETL.OLD_SRNO = A.ISU_SRNO  AND A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  AND A.VCH_NO ='" + tVchNo.Text + "'";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Ac_Ledr.Order_Adj_Ledr(DC_Main.MCo_Book, tVchNo.Text);
						DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Ac_Rojmel.Order_Adj_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
						DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Ac_Stock.Ord_Adj_Stk(DC_Main.MCo_Book, tVchNo.Text);
						if (Operators.CompareString(FormVchNo, "", false) != 0)
						{
							CLEAR_DATA();
							((Form)this).Close();
							goto end_IL_0001;
						}
						CurPrnVch = tVchNo.Text;
						DC_Main.MsAcBal(PartyAcCode, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
						CustOpAmt = DC_Main.MsAcAmtOpBal;
						CustClAmt = DC_Main.MsAcAmtClBal;
						CLEAR_DATA();
						BtnPrint_Click(BtnPrint, new EventArgs());
						CurPrnVch = "";
						CustOpAmt = 0.0;
						CustClAmt = 0.0;
						DC_Main.MsAcAmtOpBal = 0.0;
						DC_Main.MsAcAmtClBal = 0.0;
						DC_Main.MsAcGoldOpBal = 0.0;
						DC_Main.MsAcGoldClBal = 0.0;
						DC_Main.MsAcSilverOpBal = 0.0;
						DC_Main.MsAcSilverClBal = 0.0;
						goto end_IL_0001;
					}
					case 7044:
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
				try0001_dispatch = 7044;
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
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(UsDelete, "Y", false) != 0 && Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "UPDATE SL_ORD_DETL  SET SL_ORD_DETL.TAG_SALE = 'N'  FROM SL_ORD_DETL,APR_DETL AS A WHERE SL_ORD_DETL.CO_CODE = A.CO_CODE AND SL_ORD_DETL.LC_CODE = A.LC_CODE AND SL_ORD_DETL.VCH_NO = A.ISU_NO AND SL_ORD_DETL.CO_YEAR = A.ISU_YRCD AND SL_ORD_DETL.CO_BOOK = A.ISU_DBCD AND SL_ORD_DETL.OLD_SRNO = A.ISU_SRNO  AND A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  AND A.VCH_NO ='" + tVchNo.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_SL_ORD_ADJ_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			checked
			{
				if (((Control)TEXT_ENTRY).Visible)
				{
					MSG_LeaveCell(MSG, new EventArgs());
					MSG.Row = MSG.Rows - 1;
					MSG.Col = 0;
					((Control)TEXT_ENTRY).Visible = false;
					MSG_TOT_FILL();
					MSG_TAG.Row = MSG_TAG.Rows - 1;
					MSG_TAG.Col = 1;
					MSG_TAG_EnterCell(MSG_TAG, new EventArgs());
					((Control)TEXT_TAG).Focus();
				}
				else if (((Control)TEXT_TAG).Visible)
				{
					MSG_TAG_LeaveCell(MSG_TAG, new EventArgs());
					MSG_TAG.Row = MSG_TAG.Rows - 1;
					MSG_TAG.Col = 0;
					((Control)TEXT_TAG).Visible = false;
					((Control)tEmpCode).Focus();
				}
				else if (OldValTot == NewValTot)
				{
					((Form)this).Close();
				}
			}
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		((Form)MyProject.Forms.MS_PRINT).ShowDialog();
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
		{
			return;
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = "OrderCancelVch";
			DC_Main.RptFormula = "{SL_ORD_ADJ.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_ORD_ADJ.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_ORD_ADJ.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_ORD_ADJ.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_ORD_ADJ.VCH_NO} = '" + CurPrnVch + "'";
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
			return;
		}
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OrderCancelVch.RPT";
		Cr.SelectionFormula = "{SL_ORD_ADJ.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_ORD_ADJ.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_ORD_ADJ.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_ORD_ADJ.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_ORD_ADJ.VCH_NO} = '" + CurPrnVch + "'";
		if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
		{
			if (DC_Main.MsPrintOg)
			{
				Cr[(short)1] = "InVoiceType = 'ORIGINAL FOR RECIPIENT'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
			if (DC_Main.MsPrintDup)
			{
				Cr[(short)1] = "InVoiceType = 'DUPLICATE FOR SUPPLIER'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
			if (DC_Main.MsPrintTrip)
			{
				Cr[(short)1] = "InVoiceType = 'TRIPLICATE FOR TRANSPORTER'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
		}
		else
		{
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
		DC_Main.MsPrintStatus = false;
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CustOpAmt = 0.0;
		CustClAmt = 0.0;
		CLEAR_DATA();
	}

	private void TR_SL_ORD_ADJ_Activated(object sender, EventArgs e)
	{
		DC_Main.MCo_Book = FormBook;
		DC_Main.MCo_BookType = FormBookType;
		lblBook.Text = FormName;
		if ((Operators.CompareString(FormVchNo, "", false) != 0) & (Operators.CompareString(DC_Main.CurBookVch, "", false) != 0))
		{
			DC_Main.CurBookVch = "";
			tVchNo.Text = FormVchNo;
			DISPLAY_DATA();
			Application.DoEvents();
			((Control)TEXT_ENTRY).Visible = false;
			((Control)mVchDate).Focus();
			return;
		}
		if (DC_Main.MsCreat)
		{
			DC_Main.MsCreat = false;
			TEXT_ENTRY.Text = DC_Main.MsCode;
			MSG[MSG.Row, 10] = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,A.IT_DESC As VchDescL,A.MAIN_USER As UserL,SUM(ORD_AMT) As OrdAmtR,SUM(A.PAID_AMT) As PaidAmtR FROM SL_ORD_ADJ AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' GROUP BY A.VCH_NO,A.VCH_DATE,A.AC_NAME,A.IT_DESC,A.MAIN_USER  UNION ALL SELECT A.VCH_NO,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/'),B.AC_NAME,'Order Tag',A.MAIN_USER As UserL,0,0 FROM APR_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' GROUP BY A.VCH_NO,A.VCH_DATE,B.AC_NAME,A.MAIN_USER ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[8];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 250.0;
		DC_Main.ColWidth[4] = 100.0;
		DC_Main.ColWidth[5] = 100.0;
		DC_Main.ColWidth[6] = 100.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				CLEAR_DATA();
				tVchNo.Text = DC_Main.ColValue[0];
				DISPLAY_DATA();
				((Control)mVchDate).Focus();
			}
			else
			{
				((Control)tVchNo).Focus();
			}
		}
	}

	private void MSG_RowColChange(object sender, EventArgs e)
	{
		if (MSG.Row != 0 && ((MsgOldRow != MSG.Row) & !MsgClear))
		{
			MsgOldRow = MSG.Row;
			DC_Main.MsAcBal(MSG[MSG.Row, 2], Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
			if (DC_Main.MsAcAmtOpBal > 0.0)
			{
				LOpAmt.Text = Strings.Format((object)DC_Main.MsAcAmtOpBal, "0.00") + " : Cr Amt";
				((Control)LOpAmt).ForeColor = Color.Blue;
			}
			else if (DC_Main.MsAcAmtOpBal < 0.0)
			{
				LOpAmt.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcAmtOpBal), "0.00") + " : Dr Amt";
				((Control)LOpAmt).ForeColor = Color.Red;
			}
			else
			{
				LOpAmt.Text = ": Amt";
			}
			CustOpAmt = DC_Main.MsAcAmtOpBal;
			CustClAmt = DC_Main.MsAcAmtClBal;
			DC_Main.MsAcAmtOpBal = 0.0;
			DC_Main.MsAcGoldOpBal = 0.0;
			DC_Main.MsAcSilverOpBal = 0.0;
			DC_Main.MsAcAmtClBal = 0.0;
			DC_Main.MsAcGoldClBal = 0.0;
			DC_Main.MsAcSilverClBal = 0.0;
		}
	}

	private void TVchNo_TextChanged(object sender, EventArgs e)
	{
	}

	private void tVchNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Invalid comparison between Unknown and I4
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			BtnF1_Click(BtnF1, new EventArgs());
		}
		if ((int)e.KeyCode == 38)
		{
			BtnLast_Click(BtnLast, new EventArgs());
		}
		if ((int)e.KeyCode == 40)
		{
			BtnFirst_Click(BtnFirst, new EventArgs());
		}
		if ((int)e.KeyCode == 13)
		{
			DISPLAY_DATA();
		}
	}

	private void mVchDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mVchDate).SelectionStart = 0;
		((TextBoxBase)mVchDate).SelectionLength = Strings.Len(mVchDate.Text);
	}

	private void mVchDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Invalid comparison between Unknown and I4
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		if (((int)e.KeyCode == 112) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			DC_Main.MsReqBook = DC_Main.MCo_Book;
			DC_Main.MsReqVch = tVchNo.Text;
			DC_Main.MsReqUser = DC_Main.MCo_User;
			DC_Main.MsReqAc = "";
			((Form)MyProject.Forms.UT_USER_REQUEST).ShowDialog();
		}
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mVchDate;
			DC_Main.SetDate(ref MsDate);
			mVchDate = MsDate;
			if (!DC_Main.RongDate)
			{
				MSG.Col = 1;
				MSG.Row = 1;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
		}
	}

	private void BtnFirst_Click(object sender, EventArgs e)
	{
		if (Conversion.Val(tVchNo.Text) < 2.0)
		{
			return;
		}
		string text = Strings.Format((object)(Conversion.Val(tVchNo.Text) - 1.0), "00000");
		DC_Main.i = 1;
		checked
		{
			do
			{
				DC_Main.RsQry = "SELECT VCH_NO FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count != 0 || Conversion.Val(text) == 1.0)
				{
					break;
				}
				text = Strings.Format((object)(Conversion.Val(text) - 1.0), "00000");
				DC_Main.i++;
			}
			while (DC_Main.i <= 10);
			CLEAR_DATA();
			tVchNo.Text = text;
			DISPLAY_DATA();
			((Control)tVchNo).Focus();
		}
	}

	private void BtnLast_Click(object sender, EventArgs e)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (Conversion.Val(tVchNo.Text) >= Conversion.Val(LastVchNo))
		{
			Interaction.MsgBox((object)"Last Record...", (MsgBoxStyle)0, (object)null);
			((Control)tVchNo).Focus();
			return;
		}
		string text = Strings.Format((object)(Conversions.ToDouble(tVchNo.Text) + 1.0), "00000");
		DC_Main.i = 1;
		checked
		{
			do
			{
				DC_Main.RsQry = "SELECT VCH_NO FROM SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count != 0 || Conversion.Val(text) == Conversion.Val(LastVchNo))
				{
					break;
				}
				text = Strings.Format((object)(Conversion.Val(text) + 1.0), "00000");
				DC_Main.i++;
			}
			while (DC_Main.i <= 10);
			CLEAR_DATA();
			tVchNo.Text = text;
			DISPLAY_DATA();
			((Control)tVchNo).Focus();
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

	private void TR_SL_ORD_ADJ_Closed(object sender, EventArgs e)
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

	private void tEmpCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND EMP_CODE = '" + tEmpCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT EMP_NAME As EmpNameL,EMP_CODE As EmpL FROM EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY EMP_NAME";
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
					tEmpCode.Text = DC_Main.ColValue[1];
					tEmpName.Text = DC_Main.ColValue[0];
				}
				((Control)tEmpCode).Focus();
			}
		}
		else
		{
			tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["EMP_NAME"], (object)""));
			SendKeys.Send("{tab}");
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

	private void lblBook_DoubleClick(object sender, EventArgs e)
	{
		((Control)tHdVchNo).Visible = true;
	}

	private void TR_SL_ORD_ADJ_KeyUp(object sender, KeyEventArgs e)
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
