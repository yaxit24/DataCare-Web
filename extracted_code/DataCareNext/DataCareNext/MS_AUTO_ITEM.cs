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
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class MS_AUTO_ITEM : Form
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
	[AccessedThroughProperty("tGrCode")]
	private TextBox _tGrCode;

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
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPrCode")]
	private TextBox _tPrCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMembAcCode")]
	private TextBox _tMembAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboUPdateType")]
	private ComboBox _cboUPdateType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nMrpMargin")]
	private TextBox _nMrpMargin;

	private string EntryMode;

	private Control CurActCtrl;

	private bool MsgClear;

	private bool UpDown;

	private int MsgOldRow;

	private bool Msgleft;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private DataTable RsDetl;

	private double ColCon;

	private string MaxVchNo;

	private long FGRow;

	private string CurMast;

	private const int cSr = 0;

	private const int cPrCode = 1;

	private const int cPrName = 2;

	private const int cMinStk = 3;

	private const int cYN = 4;

	private const int cAppItem = 5;

	private const int cRateType = 6;

	private const int cAvgTouch = 7;

	private const int cMembCom = 8;

	private const int cTouch = 9;

	private const int cWestPrc = 10;

	private const int cGhatPrc = 11;

	private const int cLbrPrc = 12;

	private const int cLbrType = 13;

	private const int cLbrRate = 14;

	private const int cItRate = 15;

	private const int cEmpComPrc = 16;

	private const int cGrCode = 17;

	private const int cGrName = 18;

	private const int cMainUser = 19;

	private const int cStkDisplay = 20;

	private const int cOthDtlPosting = 21;

	private const int cItmWithLotStk = 22;

	private const int cUSrNo = 0;

	private const int cUItCode = 1;

	private const int cUItName = 2;

	private const int cULbrRate = 3;

	private const int cUNewLbrRate = 4;

	private const int cULbrPrc = 5;

	private const int cUNewLbrPrc = 6;

	private const int cULbrAmt = 7;

	private const int cUNewLbrAmt = 8;

	private const int cUMrp = 9;

	private const int cUMrpPrc = 10;

	private const int cUNewMrp = 11;

	private const int cUItRate = 12;

	private const int cUNewItRate = 13;

	private const int cUOthRate = 14;

	private const int cUNewOthRate = 15;

	private const int cUWestPrc = 16;

	private const int cUNewWestPrc = 17;

	private const int cUGhtPrc = 18;

	private const int cUNewGhtPrc = 19;

	private const int cUKrTouch = 20;

	private const int cUNewKrTouch = 21;

	private const int cUKrWestPrc = 22;

	private const int cUNewKrWestPrc = 23;

	private const int cDSrNo = 0;

	private const int cDItCode = 1;

	private const int cDItName = 2;

	private const int cDLbrDisc = 3;

	private const int cFixGhtPrc = 4;

	private const int cFixWestPrc = 5;

	private const int cDMrpDisc = 6;

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
			EventHandler eventHandler4 = MSG_RowColChange;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
				val.RowColChange -= eventHandler4;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
				val.RowColChange += eventHandler4;
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
	[AccessedThroughProperty("tGrName")]
	private virtual TextBox _tGrName;

	internal virtual TextBox tGrName
	{
		get
		{
			return _tGrName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tGrName = value;
		}
	}

	internal virtual TextBox tGrCode
	{
		[CompilerGenerated]
		get
		{
			return _tGrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tGrCode_KeyDown);
			TextBox val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tGrCode = value;
			val2 = _tGrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tGrType")]
	private virtual TextBox _tGrType;

	internal virtual TextBox tGrType
	{
		get
		{
			return _tGrType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tGrType = value;
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = BtnSave_Click;
			KeyEventHandler val = new KeyEventHandler(BtnSave_KeyDown);
			SimpleButton val2 = _BtnSave;
			if (val2 != null)
			{
				((Control)val2).Click -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_BtnSave = value;
			val2 = _BtnSave;
			if (val2 != null)
			{
				((Control)val2).Click += eventHandler;
				((Control)val2).KeyDown += val;
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
	[AccessedThroughProperty("tHsnCode")]
	private virtual TextBox _tHsnCode;

	internal virtual TextBox tHsnCode
	{
		get
		{
			return _tHsnCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tHsnCode = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTradType")]
	private virtual TextBox _tTradType;

	internal virtual TextBox tTradType
	{
		get
		{
			return _tTradType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tTradType = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblFromDt")]
	private virtual Label _lblFromDt;

	internal virtual Label lblFromDt
	{
		get
		{
			return _lblFromDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblFromDt = value;
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
	[AccessedThroughProperty("lblTodt")]
	private virtual Label _lblTodt;

	internal virtual Label lblTodt
	{
		get
		{
			return _lblTodt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblTodt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblPrCode")]
	private virtual Label _lblPrCode;

	internal virtual Label lblPrCode
	{
		get
		{
			return _lblPrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblPrCode = value;
		}
	}

	internal virtual TextBox tPrCode
	{
		[CompilerGenerated]
		get
		{
			return _tPrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPrCode_KeyDown);
			TextBox val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPrCode = value;
			val2 = _tPrCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMembAcName")]
	private virtual TextBox _tMembAcName;

	internal virtual TextBox tMembAcName
	{
		get
		{
			return _tMembAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tMembAcName = value;
		}
	}

	internal virtual TextBox tMembAcCode
	{
		[CompilerGenerated]
		get
		{
			return _tMembAcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tMembAcCode_KeyDown);
			TextBox val2 = _tMembAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tMembAcCode = value;
			val2 = _tMembAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblMembAc")]
	private virtual Label _lblMembAc;

	internal virtual Label lblMembAc
	{
		get
		{
			return _lblMembAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblMembAc = value;
		}
	}

	internal virtual ComboBox cboUPdateType
	{
		[CompilerGenerated]
		get
		{
			return _cboUPdateType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboUPdateType_KeyDown);
			EventHandler eventHandler = cboUPdateType_SelectedIndexChanged;
			ComboBox val2 = _cboUPdateType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				val2.SelectedIndexChanged -= eventHandler;
			}
			_cboUPdateType = value;
			val2 = _cboUPdateType;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				val2.SelectedIndexChanged += eventHandler;
			}
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

	internal virtual TextBox nMrpMargin
	{
		[CompilerGenerated]
		get
		{
			return _nMrpMargin;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nMrpMargin_KeyDown);
			TextBox val2 = _nMrpMargin;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nMrpMargin = value;
			val2 = _nMrpMargin;
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

	public MS_AUTO_ITEM()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((Form)this).Load += MS_AUTO_ITEM_Load;
		((Form)this).Activated += MS_AUTO_ITEM_Activated;
		((Form)this).Deactivate += MS_AUTO_ITEM_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_AUTO_ITEM_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_AUTO_ITEM_KeyDown);
		((Control)this).KeyUp += new KeyEventHandler(MS_AUTO_ITEM_KeyUp);
		((Form)this).Closed += MS_AUTO_ITEM_Closed;
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
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Expected O, but got Unknown
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Expected O, but got Unknown
		//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Expected O, but got Unknown
		//IL_0581: Unknown result type (might be due to invalid IL or missing references)
		//IL_058b: Expected O, but got Unknown
		//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0709: Expected O, but got Unknown
		//IL_076c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0776: Expected O, but got Unknown
		//IL_081e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0828: Expected O, but got Unknown
		//IL_0932: Unknown result type (might be due to invalid IL or missing references)
		//IL_093c: Expected O, but got Unknown
		//IL_0a58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a62: Expected O, but got Unknown
		//IL_0ac5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acf: Expected O, but got Unknown
		//IL_0b77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b81: Expected O, but got Unknown
		//IL_0be4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bee: Expected O, but got Unknown
		//IL_0cbb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc5: Expected O, but got Unknown
		//IL_0d5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d67: Expected O, but got Unknown
		//IL_0dd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dde: Expected O, but got Unknown
		//IL_0e9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea9: Expected O, but got Unknown
		//IL_0f54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5e: Expected O, but got Unknown
		//IL_0ff5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fff: Expected O, but got Unknown
		//IL_10ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b6: Expected O, but got Unknown
		//IL_1171: Unknown result type (might be due to invalid IL or missing references)
		//IL_117b: Expected O, but got Unknown
		//IL_1206: Unknown result type (might be due to invalid IL or missing references)
		//IL_1210: Expected O, but got Unknown
		//IL_129f: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a9: Expected O, but got Unknown
		//IL_1330: Unknown result type (might be due to invalid IL or missing references)
		//IL_133a: Expected O, but got Unknown
		//IL_1402: Unknown result type (might be due to invalid IL or missing references)
		//IL_140c: Expected O, but got Unknown
		//IL_1493: Unknown result type (might be due to invalid IL or missing references)
		//IL_149d: Expected O, but got Unknown
		//IL_1558: Unknown result type (might be due to invalid IL or missing references)
		//IL_1562: Expected O, but got Unknown
		//IL_15dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e6: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_AUTO_ITEM));
		lblBook = new Label();
		TEXT_ENTRY = new TextBox();
		Label3 = new Label();
		MSG = new AxMSFlexGrid();
		tGrName = new TextBox();
		tGrCode = new TextBox();
		tGrType = new TextBox();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		tHsnCode = new TextBox();
		tTradType = new TextBox();
		lblFromDt = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		lblTodt = new Label();
		lblPrCode = new Label();
		tPrCode = new TextBox();
		tMembAcName = new TextBox();
		tMembAcCode = new TextBox();
		lblMembAc = new Label();
		cboUPdateType = new ComboBox();
		Label6 = new Label();
		nMrpMargin = new TextBox();
		Label1 = new Label();
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
		lblBook.Text = "Auto Item";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(305, 209);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 1;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(51, 49);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(95, 20);
		((Control)Label3).TabIndex = 1129;
		Label3.Text = "Group Code";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)MSG).Location = new Point(155, 86);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(590, 462);
		((Control)MSG).TabIndex = 1;
		((TextBoxBase)tGrName).BackColor = Color.PapayaWhip;
		((Control)tGrName).Enabled = false;
		((Control)tGrName).Font = new Font("Tahoma", 9f);
		((Control)tGrName).Location = new Point(243, 47);
		((TextBoxBase)tGrName).MaxLength = 50;
		((Control)tGrName).Name = "tGrName";
		((Control)tGrName).Size = new Size(270, 22);
		((Control)tGrName).TabIndex = 1131;
		((TextBoxBase)tGrCode).BackColor = Color.White;
		((Control)tGrCode).Font = new Font("Tahoma", 9f);
		((Control)tGrCode).Location = new Point(155, 47);
		((TextBoxBase)tGrCode).MaxLength = 3;
		((Control)tGrCode).Name = "tGrCode";
		((TextBoxBase)tGrCode).ReadOnly = true;
		((Control)tGrCode).Size = new Size(83, 22);
		((Control)tGrCode).TabIndex = 1130;
		((TextBoxBase)tGrType).BackColor = Color.White;
		((TextBoxBase)tGrType).BorderStyle = (BorderStyle)1;
		((Control)tGrType).Enabled = false;
		((Control)tGrType).Font = new Font("Tahoma", 9f);
		((Control)tGrType).Location = new Point(525, 47);
		((TextBoxBase)tGrType).MaxLength = 1;
		((Control)tGrType).Name = "tGrType";
		((Control)tGrType).Size = new Size(26, 22);
		((Control)tGrType).TabIndex = 1132;
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
		((Control)PnlBotam).TabIndex = 1133;
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
		((TextBoxBase)tHsnCode).BackColor = Color.White;
		((TextBoxBase)tHsnCode).BorderStyle = (BorderStyle)1;
		((Control)tHsnCode).Enabled = false;
		((Control)tHsnCode).Font = new Font("Tahoma", 9f);
		((Control)tHsnCode).Location = new Point(603, 47);
		((TextBoxBase)tHsnCode).MaxLength = 1;
		((Control)tHsnCode).Name = "tHsnCode";
		((Control)tHsnCode).Size = new Size(104, 22);
		((Control)tHsnCode).TabIndex = 1134;
		((TextBoxBase)tTradType).BackColor = Color.White;
		((TextBoxBase)tTradType).BorderStyle = (BorderStyle)1;
		((Control)tTradType).Enabled = false;
		((Control)tTradType).Font = new Font("Tahoma", 9f);
		((Control)tTradType).Location = new Point(557, 47);
		((TextBoxBase)tTradType).MaxLength = 2;
		((Control)tTradType).Name = "tTradType";
		((Control)tTradType).Size = new Size(40, 22);
		((Control)tTradType).TabIndex = 1135;
		((Control)lblFromDt).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblFromDt).ForeColor = Color.Black;
		lblFromDt.ImeMode = (ImeMode)0;
		((Control)lblFromDt).Location = new Point(271, 516);
		((Control)lblFromDt).Name = "lblFromDt";
		((Control)lblFromDt).Size = new Size(84, 20);
		((Control)lblFromDt).TabIndex = 1138;
		lblFromDt.Text = "From Date";
		lblFromDt.TextAlign = (ContentAlignment)64;
		((Control)lblFromDt).Visible = false;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(524, 515);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1137;
		mToDt.ValidatingType = typeof(DateTime);
		((Control)mToDt).Visible = false;
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(360, 515);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 1136;
		mFromDt.ValidatingType = typeof(DateTime);
		((Control)mFromDt).Visible = false;
		((Control)lblTodt).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblTodt).ForeColor = Color.Black;
		lblTodt.ImeMode = (ImeMode)0;
		((Control)lblTodt).Location = new Point(447, 517);
		((Control)lblTodt).Name = "lblTodt";
		((Control)lblTodt).Size = new Size(66, 20);
		((Control)lblTodt).TabIndex = 1139;
		lblTodt.Text = "To Date";
		lblTodt.TextAlign = (ContentAlignment)64;
		((Control)lblTodt).Visible = false;
		((Control)lblPrCode).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblPrCode).ForeColor = Color.Black;
		lblPrCode.ImeMode = (ImeMode)0;
		((Control)lblPrCode).Location = new Point(713, 48);
		((Control)lblPrCode).Name = "lblPrCode";
		((Control)lblPrCode).Size = new Size(64, 20);
		((Control)lblPrCode).TabIndex = 1140;
		lblPrCode.Text = "Pr Code";
		lblPrCode.TextAlign = (ContentAlignment)64;
		((Control)lblPrCode).Visible = false;
		((TextBoxBase)tPrCode).BackColor = Color.White;
		((Control)tPrCode).Font = new Font("Tahoma", 9f);
		((Control)tPrCode).Location = new Point(784, 48);
		((TextBoxBase)tPrCode).MaxLength = 2;
		((Control)tPrCode).Name = "tPrCode";
		((Control)tPrCode).Size = new Size(53, 22);
		((Control)tPrCode).TabIndex = 1164;
		((Control)tPrCode).Visible = false;
		((TextBoxBase)tMembAcName).BackColor = Color.PapayaWhip;
		((Control)tMembAcName).Font = new Font("Tahoma", 9f);
		((Control)tMembAcName).Location = new Point(970, 86);
		((TextBoxBase)tMembAcName).MaxLength = 50;
		((Control)tMembAcName).Name = "tMembAcName";
		((Control)tMembAcName).Size = new Size(198, 22);
		((Control)tMembAcName).TabIndex = 1167;
		((Control)tMembAcName).Visible = false;
		((TextBoxBase)tMembAcCode).BackColor = Color.White;
		((Control)tMembAcCode).Font = new Font("Tahoma", 9f);
		((Control)tMembAcCode).Location = new Point(889, 86);
		((TextBoxBase)tMembAcCode).MaxLength = 3;
		((Control)tMembAcCode).Name = "tMembAcCode";
		((TextBoxBase)tMembAcCode).ReadOnly = true;
		((Control)tMembAcCode).Size = new Size(75, 22);
		((Control)tMembAcCode).TabIndex = 1166;
		((Control)tMembAcCode).Visible = false;
		((Control)lblMembAc).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblMembAc).ForeColor = Color.Black;
		lblMembAc.ImeMode = (ImeMode)0;
		((Control)lblMembAc).Location = new Point(756, 86);
		((Control)lblMembAc).Name = "lblMembAc";
		((Control)lblMembAc).Size = new Size(127, 20);
		((Control)lblMembAc).TabIndex = 1165;
		lblMembAc.Text = "Memb Com% Sem";
		lblMembAc.TextAlign = (ContentAlignment)64;
		((Control)lblMembAc).Visible = false;
		cboUPdateType.AutoCompleteMode = (AutoCompleteMode)2;
		cboUPdateType.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboUPdateType).Font = new Font("Tahoma", 9f);
		((ListControl)cboUPdateType).FormattingEnabled = true;
		((Control)cboUPdateType).Location = new Point(946, 49);
		cboUPdateType.MaxLength = 5;
		((Control)cboUPdateType).Name = "cboUPdateType";
		((Control)cboUPdateType).Size = new Size(95, 22);
		((Control)cboUPdateType).TabIndex = 1169;
		((Control)cboUPdateType).Visible = false;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(843, 49);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(97, 20);
		((Control)Label6).TabIndex = 1170;
		Label6.Text = "Update Type";
		Label6.TextAlign = (ContentAlignment)16;
		((Control)Label6).Visible = false;
		((TextBoxBase)nMrpMargin).BackColor = Color.White;
		((Control)nMrpMargin).Font = new Font("Tahoma", 9f);
		((Control)nMrpMargin).Location = new Point(1104, 49);
		((TextBoxBase)nMrpMargin).MaxLength = 4;
		((Control)nMrpMargin).Name = "nMrpMargin";
		((Control)nMrpMargin).Size = new Size(46, 22);
		((Control)nMrpMargin).TabIndex = 1172;
		((Control)nMrpMargin).Visible = false;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(1045, 49);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(52, 20);
		((Control)Label1).TabIndex = 1171;
		Label1.Text = "Mrp%";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)Label1).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)nMrpMargin);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)cboUPdateType);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)tMembAcName);
		((Control)this).Controls.Add((Control)(object)tMembAcCode);
		((Control)this).Controls.Add((Control)(object)lblMembAc);
		((Control)this).Controls.Add((Control)(object)tPrCode);
		((Control)this).Controls.Add((Control)(object)lblPrCode);
		((Control)this).Controls.Add((Control)(object)lblTodt);
		((Control)this).Controls.Add((Control)(object)lblFromDt);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)tTradType);
		((Control)this).Controls.Add((Control)(object)tHsnCode);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)tGrType);
		((Control)this).Controls.Add((Control)(object)tGrName);
		((Control)this).Controls.Add((Control)(object)tGrCode);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_AUTO_ITEM";
		((Form)this).Text = "Auto Item";
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
		checked
		{
			if (Operators.CompareString(CurMast, "Labour Disc", false) == 0)
			{
				((TextBoxBase)tGrCode).ReadOnly = false;
				((Control)MSG).Width = (int)Math.Round(710.0 * ColCon);
				mSG.Cols = 7;
				mSG.Rows = 2;
				mSG.Row = 0;
				mSG[0] = 325;
				mSG[0] = (int)Math.Round(500.0 * ColCon);
				mSG[0] = 3;
				mSG[0, 0] = "Sr.";
				mSG[1] = (int)Math.Round(1200.0 * ColCon);
				mSG[1] = 0;
				mSG[0, 1] = "It Code";
				mSG[2] = (int)Math.Round(3300.0 * ColCon);
				mSG[2] = 0;
				mSG[0, 2] = "It Name";
				mSG[3] = (int)Math.Round(1300.0 * ColCon);
				mSG[3] = 7;
				mSG[0, 3] = "LbrDisc%";
				mSG[4] = (int)Math.Round(1300.0 * ColCon);
				mSG[4] = 7;
				mSG[0, 4] = "FixGht%";
				mSG[5] = (int)Math.Round(1300.0 * ColCon);
				mSG[5] = 7;
				mSG[0, 5] = "FixWest%";
				mSG[6] = (int)Math.Round(1300.0 * ColCon);
				mSG[6] = 7;
				mSG[0, 6] = "MrpDisc%";
			}
			else if (Operators.CompareString(CurMast, "Labour Update", false) == 0)
			{
				((TextBoxBase)tGrCode).ReadOnly = false;
				((Control)MSG).Left = (int)Math.Round((double)((Control)this).Left * ColCon + 14.0 * ColCon);
				((Control)MSG).Width = (int)Math.Round(1150.0 * ColCon);
				mSG.Cols = 24;
				mSG.Rows = 2;
				mSG.Row = 0;
				mSG.FixedCols = 3;
				mSG[0] = 325;
				mSG[0] = (int)Math.Round(500.0 * ColCon);
				mSG[0] = 3;
				mSG[0, 0] = "Sr.";
				mSG[1] = (int)Math.Round(1200.0 * ColCon);
				mSG[1] = 0;
				mSG[0, 1] = "It Code";
				mSG[2] = (int)Math.Round(3000.0 * ColCon);
				mSG[2] = 0;
				mSG[0, 2] = "It Name";
				mSG[3] = (int)Math.Round(1200.0 * ColCon);
				mSG[3] = 7;
				mSG[0, 3] = "OLbr";
				mSG[4] = (int)Math.Round(1200.0 * ColCon);
				mSG[4] = 7;
				mSG[0, 4] = "NLbr";
				mSG[5] = (int)Math.Round(1100.0 * ColCon);
				mSG[5] = 7;
				mSG[0, 5] = "OLbr%";
				mSG[6] = (int)Math.Round(1100.0 * ColCon);
				mSG[6] = 7;
				mSG[0, 6] = "NLbr%";
				mSG[9] = (int)Math.Round(1200.0 * ColCon);
				mSG[9] = 7;
				mSG[0, 9] = "OMrp";
				mSG[10] = (int)Math.Round(1000.0 * ColCon);
				mSG[10] = 7;
				mSG[0, 10] = "Mrgn%";
				mSG[11] = (int)Math.Round(1200.0 * ColCon);
				mSG[11] = 7;
				mSG[0, 11] = "NMrp";
				mSG[7] = (int)Math.Round(1200.0 * ColCon);
				mSG[7] = 7;
				mSG[0, 7] = "OLbrAmt";
				mSG[8] = (int)Math.Round(1200.0 * ColCon);
				mSG[8] = 7;
				mSG[0, 8] = "NLbrAmt";
				mSG[12] = (int)Math.Round(1200.0 * ColCon);
				mSG[12] = 7;
				mSG[0, 12] = "ItRate";
				mSG[13] = (int)Math.Round(1200.0 * ColCon);
				mSG[13] = 7;
				mSG[0, 13] = "NewitRt";
				mSG[14] = (int)Math.Round(1200.0 * ColCon);
				mSG[14] = 7;
				mSG[0, 14] = "OthRat";
				mSG[15] = (int)Math.Round(1200.0 * ColCon);
				mSG[15] = 7;
				mSG[0, 15] = "NewOtRt";
				mSG[16] = (int)Math.Round(1100.0 * ColCon);
				mSG[16] = 7;
				mSG[0, 16] = "OWest%";
				mSG[17] = (int)Math.Round(1100.0 * ColCon);
				mSG[17] = 7;
				mSG[0, 17] = "NWest%";
				mSG[18] = (int)Math.Round(1100.0 * ColCon);
				mSG[18] = 7;
				mSG[0, 18] = "Ght%";
				mSG[19] = (int)Math.Round(1100.0 * ColCon);
				mSG[19] = 7;
				mSG[0, 19] = "NGht%";
				mSG[20] = (int)Math.Round(1100.0 * ColCon);
				mSG[20] = 7;
				mSG[0, 20] = "OKrTch";
				mSG[21] = (int)Math.Round(1100.0 * ColCon);
				mSG[21] = 7;
				mSG[0, 21] = "KrTch";
				mSG[22] = (int)Math.Round(1100.0 * ColCon);
				mSG[22] = 7;
				mSG[0, 22] = "OKrWst%";
				mSG[23] = (int)Math.Round(1100.0 * ColCon);
				mSG[23] = 7;
				mSG[0, 23] = "KrWst%";
			}
			else
			{
				mSG.Cols = 23;
				mSG.Rows = 2;
				mSG.Row = 0;
				mSG[0] = 325;
				mSG[0] = (int)Math.Round(500.0 * ColCon);
				mSG[0] = 3;
				mSG[0, 0] = "Sr.";
				mSG[1] = (int)Math.Round(1000.0 * ColCon);
				mSG[1] = 0;
				mSG[0, 1] = "Pr Code";
				mSG[2] = (int)Math.Round(2850.0 * ColCon);
				mSG[2] = 0;
				mSG[0, 2] = "Pr Name";
				if (Operators.CompareString(CurMast, "Item Touch", false) == 0)
				{
					((Control)MSG).Width = (int)Math.Round(910.0 * ColCon);
					mSG[3] = (int)Math.Round(0.0 * ColCon);
					mSG[3] = 7;
					mSG[0, 3] = "MinStk";
					if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)
					{
						mSG[5] = (int)Math.Round(850.0 * ColCon);
						mSG[5] = 3;
						mSG[0, 5] = "ApItm";
					}
					else
					{
						mSG[5] = 0;
						mSG[5] = 3;
						mSG[0, 5] = "AppItm";
					}
					mSG[4] = (int)Math.Round(900.0 * ColCon);
					mSG[4] = 3;
					mSG[0, 4] = "BulkSl";
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
					{
						mSG[8] = (int)Math.Round(1100.0 * ColCon);
						mSG[8] = 7;
						mSG[0, 8] = "Memb%";
					}
					else
					{
						mSG[8] = 0;
					}
					mSG[6] = (int)Math.Round(800.0 * ColCon);
					mSG[6] = 3;
					mSG[0, 6] = "RType";
					mSG[7] = (int)Math.Round(900.0 * ColCon);
					mSG[7] = 7;
					mSG[0, 7] = "AvgTch";
					mSG[9] = (int)Math.Round(900.0 * ColCon);
					mSG[9] = 7;
					mSG[0, 9] = "Touch";
					mSG[10] = (int)Math.Round(900.0 * ColCon);
					mSG[10] = 7;
					mSG[0, 10] = "West%";
					mSG[11] = (int)Math.Round(900.0 * ColCon);
					mSG[11] = 7;
					mSG[0, 11] = "Ghat%";
					mSG[12] = (int)Math.Round(900.0 * ColCon);
					mSG[12] = 7;
					mSG[0, 12] = "Lbr%";
					mSG[13] = (int)Math.Round(0.0 * ColCon);
					mSG[13] = 3;
					mSG[0, 13] = "LbrType";
					mSG[14] = (int)Math.Round(900.0 * ColCon);
					mSG[14] = 7;
					mSG[0, 14] = "LbrRate";
					mSG[15] = (int)Math.Round(1000.0 * ColCon);
					mSG[15] = 7;
					mSG[0, 15] = "OthRate";
					if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
					{
						mSG[16] = (int)Math.Round(1150.0 * ColCon);
						mSG[16] = 7;
						mSG[0, 16] = "EmpCom%";
					}
					else
					{
						mSG[16] = (int)Math.Round(0.0 * ColCon);
					}
				}
				else if (Operators.CompareString(CurMast, "Labour", false) == 0)
				{
					((Control)MSG).Width = (int)Math.Round(910.0 * ColCon);
					mSG[3] = (int)Math.Round(0.0 * ColCon);
					mSG[3] = 7;
					mSG[0, 3] = "MinStk";
					mSG[4] = (int)Math.Round(0.0 * ColCon);
					mSG[4] = 3;
					mSG[0, 4] = "Y/N";
					mSG[5] = (int)Math.Round(0.0 * ColCon);
					mSG[7] = (int)Math.Round(0.0 * ColCon);
					mSG[6] = (int)Math.Round(0.0 * ColCon);
					mSG[16] = (int)Math.Round(0.0 * ColCon);
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
					{
						mSG[8] = (int)Math.Round(1100.0 * ColCon);
						mSG[8] = 7;
						mSG[0, 8] = "Memb%";
					}
					else
					{
						mSG[8] = 0;
					}
					mSG[9] = (int)Math.Round(1100.0 * ColCon);
					mSG[9] = 0;
					mSG[0, 9] = "Touch";
					mSG[10] = (int)Math.Round(1100.0 * ColCon);
					mSG[10] = 0;
					mSG[0, 10] = "West%";
					mSG[11] = (int)Math.Round(1000.0 * ColCon);
					mSG[11] = 0;
					mSG[0, 11] = "Ghat%";
					mSG[12] = (int)Math.Round(1000.0 * ColCon);
					mSG[12] = 0;
					mSG[0, 12] = "Lbr%";
					mSG[13] = (int)Math.Round(1000.0 * ColCon);
					mSG[13] = 0;
					mSG[0, 13] = "LbrType";
					mSG[14] = (int)Math.Round(1200.0 * ColCon);
					mSG[14] = 0;
					mSG[0, 14] = "LbrRate";
					mSG[15] = (int)Math.Round(1200.0 * ColCon);
					mSG[15] = 0;
					mSG[0, 15] = "ItRate";
				}
				else
				{
					mSG[3] = (int)Math.Round(900.0 * ColCon);
					mSG[3] = 7;
					mSG[0, 3] = "MinStk";
					mSG[4] = (int)Math.Round(1200.0 * ColCon);
					mSG[4] = 3;
					mSG[0, 4] = "Y/N";
					mSG[5] = (int)Math.Round(0.0 * ColCon);
					mSG[7] = (int)Math.Round(0.0 * ColCon);
					mSG[6] = (int)Math.Round(0.0 * ColCon);
					mSG[16] = (int)Math.Round(0.0 * ColCon);
					mSG[8] = 0;
					mSG[9] = (int)Math.Round(0.0 * ColCon);
					mSG[9] = 0;
					mSG[0, 9] = "Touch";
					mSG[10] = (int)Math.Round(0.0 * ColCon);
					mSG[10] = 0;
					mSG[0, 10] = "West%";
					mSG[11] = (int)Math.Round(0.0 * ColCon);
					mSG[11] = 0;
					mSG[0, 11] = "Ghat%";
					mSG[12] = (int)Math.Round(0.0 * ColCon);
					mSG[12] = 0;
					mSG[0, 12] = "Lbr%";
					mSG[13] = (int)Math.Round(0.0 * ColCon);
					mSG[13] = 0;
					mSG[0, 13] = "LbrType";
					mSG[14] = (int)Math.Round(0.0 * ColCon);
					mSG[14] = 0;
					mSG[0, 14] = "LbrRate";
					mSG[15] = (int)Math.Round(0.0 * ColCon);
					mSG[15] = 0;
					mSG[0, 15] = "ItRate";
				}
				mSG[17] = 0;
				mSG[18] = 0;
				mSG[19] = 0;
				mSG[20] = 0;
				mSG[21] = 0;
				mSG[22] = 0;
			}
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			mSG = null;
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
			if (((mSG.Row == 0) | (mSG.CellWidth <= 0)) || MSG[MSG.Col] == 0)
			{
				return;
			}
			((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
			((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
			((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
			((Control)TEXT_ENTRY).Height = (int)Math.Round((double)mSG.CellHeight / 15.0);
			((Control)TEXT_ENTRY).Visible = true;
			((TextBoxBase)TEXT_ENTRY).ReadOnly = false;
			if (Operators.CompareString(CurMast, "Labour Disc", false) == 0)
			{
				switch (MSG.Col)
				{
				case 1:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
				case 4:
				case 5:
				case 6:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				}
			}
			else if (Operators.CompareString(CurMast, "Labour Update", false) == 0)
			{
				switch (MSG.Col)
				{
				case 1:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
				case 5:
				case 7:
				case 9:
				case 16:
				case 18:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
					break;
				case 4:
				case 6:
				case 8:
				case 10:
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
				case 17:
				case 19:
				case 21:
				case 23:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				}
			}
			else
			{
				switch (MSG.Col)
				{
				case 1:
					if (Operators.CompareString(CurMast, "Labour", false) == 0)
					{
						((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					}
					else
					{
						((TextBoxBase)TEXT_ENTRY).MaxLength = 2;
					}
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 5:
				case 6:
				case 13:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 6;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
					break;
				case 7:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 6;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
					break;
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
				case 14:
				case 15:
				case 16:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 6;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 4:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				}
			}
			mSG = null;
			((TextBoxBase)TEXT_ENTRY).SelectAll();
		}
	}

	private void MSG_LeaveCell(object sender, EventArgs e)
	{
		if (UpDown || MsgClear || MSG.Row == 0 || MSG[MSG.Col] == 0 || !((Control)TEXT_ENTRY).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG = MSG;
		if (Operators.CompareString(CurMast, "Labour Disc", false) == 0)
		{
			switch (MSG.Col)
			{
			case 0:
			case 1:
			case 2:
			case 5:
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 3:
			case 4:
			case 6:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				break;
			}
		}
		else if (Operators.CompareString(CurMast, "Labour Update", false) == 0)
		{
			switch (MSG.Col)
			{
			case 0:
			case 1:
			case 2:
			case 5:
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 3:
			case 4:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 21:
			case 23:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				break;
			}
		}
		else
		{
			switch (MSG.Col)
			{
			case 0:
			case 1:
			case 2:
			case 4:
			case 5:
			case 6:
			case 13:
				MSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 3:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				break;
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 14:
			case 15:
			case 16:
				MSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				break;
			}
		}
		mSG = null;
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		if (Operators.CompareString(CurMast, "Labour Disc", false) == 0)
		{
			mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		}
		else if (Operators.CompareString(CurMast, "Labour Update", false) == 0)
		{
			mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		}
		else
		{
			mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
			mSG[mSG.Row, 19] = MainUser;
			mSG[mSG.Row, 20] = "Y";
			mSG[mSG.Row, 21] = "N";
		}
		mSG = null;
	}

	private void MS_AUTO_ITEM_Load(object sender, EventArgs e)
	{
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0875: Unknown result type (might be due to invalid IL or missing references)
		//IL_087a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0884: Expected O, but got Unknown
		//IL_08c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d2: Expected O, but got Unknown
		//IL_091f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0926: Expected O, but got Unknown
		//IL_09a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b0: Expected O, but got Unknown
		//IL_0a38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a47: Expected O, but got Unknown
		//IL_0ab9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac4: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurMast = DC_Main.MsUserRightForm;
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
				AxMSFlexGrid mSG = MSG;
				object? obj7 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj8 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj8 != null) ? ((Color)obj8) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj9 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj9 != null) ? ((Color)obj9) : default(Color));
				TextBox obj10 = tGrName;
				object? obj11 = colorConverter.ConvertFromString("243, 240, 239");
				((TextBoxBase)obj10).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj12 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AxMSFlexGrid mSG4 = MSG;
				object? obj13 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj14 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj15 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj15 != null) ? ((Color)obj15) : default(Color));
				TextBox obj16 = tGrName;
				object? obj17 = colorConverter.ConvertFromString("233, 235, 240");
				((TextBoxBase)obj16).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj18 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj19 = lblBook;
				object? obj20 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj19).ForeColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj21 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj22 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj23 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj24 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj24 != null) ? ((Color)obj24) : default(Color));
				TextBox obj25 = tGrName;
				object? obj26 = colorConverter.ConvertFromString("Cornsilk");
				((TextBoxBase)obj25).BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				num3 = (int)Math.Ceiling((double)((Control)tGrCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tGrCode).Font;
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
			cboUPdateType.Items.Add((object)"");
			CLEAR_DATA();
			if (Operators.CompareString(CurMast, "Labour Disc", false) == 0)
			{
				Label3.Text = "Gr Code";
				lblBook.Text = "Labour And Mrp Discount Set";
				((TextBoxBase)tGrCode).MaxLength = 5;
				((Control)tGrType).Visible = false;
				((Control)tTradType).Visible = false;
				((Control)tHsnCode).Visible = false;
				((Control)MSG).Width = (int)Math.Round(710.0 * ColCon);
				((Control)MSG).Height = (int)Math.Round(425.0 * DC_Main.ScreenHight);
				((Control)lblFromDt).Top = (int)Math.Round((double)((Control)MSG).Top + 435.0 * DC_Main.ScreenHight);
				((Control)lblTodt).Top = (int)Math.Round((double)((Control)MSG).Top + 435.0 * DC_Main.ScreenHight);
				((Control)mFromDt).Top = (int)Math.Round((double)((Control)MSG).Top + 435.0 * DC_Main.ScreenHight);
				((Control)mToDt).Top = (int)Math.Round((double)((Control)MSG).Top + 435.0 * DC_Main.ScreenHight);
				((Control)lblFromDt).Visible = true;
				((Control)lblTodt).Visible = true;
				((Control)mFromDt).Visible = true;
				((Control)mToDt).Visible = true;
				DC_Main.RsQry = "SELECT F_DISC_DATE,T_DISC_DATE FROM CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					mFromDt.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["F_DISC_DATE"], (object)""));
					mToDt.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["T_DISC_DATE"], (object)""));
				}
			}
			else if (Operators.CompareString(CurMast, "Labour Update", false) == 0)
			{
				Label3.Text = "Gr Code";
				lblBook.Text = "Labour and Mrp Update";
				((TextBoxBase)tGrCode).MaxLength = 10;
				((Control)tGrType).Visible = false;
				((Control)tTradType).Visible = false;
				((Control)tHsnCode).Visible = false;
				((Control)tPrCode).Visible = true;
				((Control)lblPrCode).Visible = true;
				((Control)Label6).Visible = true;
				((Control)cboUPdateType).Visible = true;
				cboUPdateType.Items.Add((object)"LbrRate");
				cboUPdateType.Items.Add((object)"Lbr%");
				cboUPdateType.Items.Add((object)"LbrAmt");
				cboUPdateType.Items.Add((object)"Mrp");
				cboUPdateType.Items.Add((object)"ItRate");
				cboUPdateType.Items.Add((object)"West%");
				cboUPdateType.Items.Add((object)"Ght%");
				cboUPdateType.Items.Add((object)"KrWest%");
				cboUPdateType.Items.Add((object)"OthRate");
			}
			else if (Operators.CompareString(CurMast, "Labour", false) == 0)
			{
				Label3.Text = "Party Code";
				lblBook.Text = "Party Wise Labour";
				((TextBoxBase)tGrCode).MaxLength = 10;
				((Control)tGrType).Visible = false;
				((Control)tTradType).Visible = false;
				((Control)tHsnCode).Visible = false;
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
				{
					((Control)lblMembAc).Visible = true;
					((Control)tMembAcCode).Visible = true;
					((Control)tMembAcName).Visible = true;
					((Control)lblMembAc).Top = ((Control)tGrType).Top;
					((Control)tMembAcCode).Top = ((Control)tGrType).Top;
					((Control)tMembAcName).Top = ((Control)tGrType).Top;
					((Control)lblMembAc).Left = ((Control)tGrType).Left;
					((Control)tMembAcCode).Left = (int)Math.Round((double)((Control)lblMembAc).Left + 132.0 * ColCon);
					((Control)tMembAcName).Left = (int)Math.Round((double)((Control)tMembAcCode).Left + 80.0 * ColCon);
				}
			}
			else if (Operators.CompareString(CurMast, "Item Touch", false) == 0)
			{
				lblBook.Text = "Item Touch";
				((TextBoxBase)tGrCode).ReadOnly = false;
				((Control)tGrType).Visible = false;
				((Control)tTradType).Visible = false;
				((Control)tHsnCode).Visible = false;
				DISPLAY_DATA();
			}
			cboUPdateType.SelectedIndex = 0;
			EntryMode = "A";
			CurActCtrl = (Control)(object)tGrCode;
		}
	}

	private void MS_AUTO_ITEM_Activated(object sender, EventArgs e)
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
		cboUPdateType.SelectedIndex = 0;
		EntryMode = "A";
		((Control)tGrCode).Focus();
	}

	private void DISPLAY_DATA()
	{
		MSG_CLEAR();
		checked
		{
			if (Operators.CompareString(CurMast, "Labour Disc", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select GR_CODE,IT_CODE,IT_NAME,DISC_PRC,MRP_DISC_PRC,ITM_FIX_GHT_PRC,ITM_FIX_WEST_PRC FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) != 0, (object)("AND GR_CODE = '" + tGrCode.Text + "'"), (object)"")), (object)" ORDER BY GR_CODE,IT_NAME"));
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < DC_Main.Tbl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG[DC_Main.i + 1, 3] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["DISC_PRC"], (object)"")), "0.00");
					if (Conversion.Val(mSG[DC_Main.i + 1, 3]) == 0.0)
					{
						mSG[DC_Main.i + 1, 3] = "";
					}
					mSG[DC_Main.i + 1, 4] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["ITM_FIX_GHT_PRC"], (object)"")), "0.00");
					if (Conversion.Val(mSG[DC_Main.i + 1, 4]) == 0.0)
					{
						mSG[DC_Main.i + 1, 4] = "";
					}
					mSG[DC_Main.i + 1, 5] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["ITM_FIX_WEST_PRC"], (object)"")), "0.00");
					if (Conversion.Val(mSG[DC_Main.i + 1, 5]) == 0.0)
					{
						mSG[DC_Main.i + 1, 5] = "";
					}
					mSG[DC_Main.i + 1, 6] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["MRP_DISC_PRC"], (object)"")), "0.00");
					if (Conversion.Val(mSG[DC_Main.i + 1, 6]) == 0.0)
					{
						mSG[DC_Main.i + 1, 6] = "";
					}
					mSG.Rows += 1;
					DC_Main.i++;
				}
				if (mSG.Rows > 2)
				{
					mSG.Rows -= 1;
				}
				DC_Main.RsQry = "SELECT F_DISC_DATE,T_DISC_DATE FROM CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					mFromDt.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["F_DISC_DATE"], (object)""));
					mToDt.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["T_DISC_DATE"], (object)""));
				}
				mSG = null;
			}
			else if (Operators.CompareString(CurMast, "Labour Update", false) == 0)
			{
				ColorConverter colorConverter = new ColorConverter();
				MSG_CLEAR();
				if (Operators.CompareString(cboUPdateType.Text, "Mrp", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,0 AS LBR_RATE,0 AS LBR_PRC,0 AS ITM_WEST_PRC,ITM_MRP,0 AS KR_TOUCH,0 AS KR_WEST_PRC,0 AS LBR_AMT,0 AS ITM_RATE,0 AS IT_RATE,0 AS ITM_GHT_PRC FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_MRP <> 0 "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" "), (object)" And TAG_NO NOT IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO <> 'N' AND B.GR_CODE = '"), (object)tGrCode.Text), (object)"' "), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) = 0) GROUP BY B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,A.ITM_MRP ORDER BY B.IT_TYPE,B.GR_CODE,B.IT_NAME "));
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else if (Operators.CompareString(cboUPdateType.Text, "ItRate", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,0 AS LBR_RATE,0 AS LBR_PRC,0 AS ITM_WEST_PRC,0 AS ITM_MRP,0 AS KR_TOUCH,0 AS KR_WEST_PRC,0 AS LBR_AMT,ITM_RATE,0 AS IT_RATE,0 AS ITM_GHT_PRC FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_RATE <> 0 "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" "), (object)" And TAG_NO NOT IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO <> 'N' AND B.GR_CODE = '"), (object)tGrCode.Text), (object)"' "), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) = 0) GROUP BY B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,A.ITM_RATE ORDER BY B.IT_TYPE,B.GR_CODE,B.IT_NAME, ITM_RATE DESC "));
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else if (Operators.CompareString(cboUPdateType.Text, "OthRate", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_TYPE,B.GR_CODE,C.IT_CODE,B.IT_NAME,0 AS LBR_RATE,0 AS LBR_PRC,0 AS ITM_WEST_PRC,0 AS ITM_MRP,0 AS KR_TOUCH,0 AS KR_WEST_PRC,0 AS LBR_AMT,0 AS ITM_RATE,C.IT_RATE, 0 AS ITM_GHT_PRC FROM ((BAR_DETL AS A LEFT JOIN BAR_IDTL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO) LEFT JOIN ITEM_MAST AS B ON C.CO_CODE = B.CO_CODE AND C.IT_CODE = B.IT_CODE)LEFT JOIN ITEM_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.IT_CODE = E.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND C.IT_RATE > 0 "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND E.PR_CODE = '" + tPrCode.Text + "'"))), (object)" "), (object)" And A.TAG_NO NOT IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.IT_CODE = D.IT_CODE  WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO <> 'N' AND C.IT_RATE > 0 "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND E.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND E.PR_CODE = '" + tPrCode.Text + "'"))), (object)" GROUP BY A.TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',A.VCH_SRNO,-A.VCH_SRNO)) = 0) GROUP BY B.IT_TYPE,B.GR_CODE,C.IT_CODE,B.IT_NAME,C.IT_RATE ORDER BY B.IT_TYPE,B.GR_CODE,B.IT_NAME,IT_RATE DESC "));
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else if (Operators.CompareString(cboUPdateType.Text, "LbrRate", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,LBR_RATE,0 AS LBR_PRC,0 AS ITM_WEST_PRC,0 AS ITM_MRP,0 AS KR_TOUCH,0 AS KR_WEST_PRC,0 AS LBR_AMT,0 AS ITM_RATE,0 AS IT_RATE,0 AS ITM_GHT_PRC FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.LBR_RATE <> 0 "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" "), (object)" And TAG_NO NOT IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO <> 'N' AND B.GR_CODE = '"), (object)tGrCode.Text), (object)"' "), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) = 0) GROUP BY B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,A.LBR_RATE ORDER BY B.IT_TYPE,B.GR_CODE,B.IT_NAME,LBR_RATE DESC "));
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else if (Operators.CompareString(cboUPdateType.Text, "Lbr%", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,0 AS LBR_RATE,A.LBR_PRC,0 AS ITM_WEST_PRC,0 AS ITM_MRP,0 AS KR_TOUCH,0 AS KR_WEST_PRC,0 AS LBR_AMT,0 AS ITM_RATE,0 AS IT_RATE FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.LBR_PRC <> 0 "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" "), (object)" And TAG_NO NOT IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO <> 'N' AND B.GR_CODE = '"), (object)tGrCode.Text), (object)"' "), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) = 0) GROUP BY B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,A.LBR_PRC ORDER BY B.IT_TYPE,B.GR_CODE,B.IT_NAME,A.LBR_PRC DESC "));
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else if (Operators.CompareString(cboUPdateType.Text, "LbrAmt", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,0 AS LBR_RATE,0 AS LBR_PRC,0 AS ITM_WEST_PRC,0 AS ITM_MRP,0 AS KR_TOUCH,0 AS KR_WEST_PRC,A.LBR_AMT,0 AS ITM_RATE,0 AS IT_RATE, 0 AS ITM_GHT_PRC FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.LBR_AMT <> 0 AND A.LBR_RATE = 0  "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" "), (object)" And TAG_NO NOT IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO <> 'N' AND B.GR_CODE = '"), (object)tGrCode.Text), (object)"' "), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) = 0) GROUP BY B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,A.LBR_AMT ORDER BY B.IT_TYPE,B.GR_CODE,B.IT_NAME,A.LBR_AMT DESC "));
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else if (Operators.CompareString(cboUPdateType.Text, "West%", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,0 AS LBR_RATE,0 AS LBR_PRC,A.ITM_WEST_PRC,0 AS ITM_MRP,0 AS KR_TOUCH,0 AS KR_WEST_PRC,0 AS LBR_AMT,0 AS ITM_RATE,0 AS IT_RATE, 0 AS ITM_GHT_PRC FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_WEST_PRC <> 0 "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" "), (object)" And TAG_NO NOT IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO <> 'N' AND B.GR_CODE = '"), (object)tGrCode.Text), (object)"' "), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) = 0) GROUP BY B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,A.ITM_WEST_PRC ORDER BY B.IT_TYPE,B.GR_CODE,B.IT_NAME,A.ITM_WEST_PRC DESC "));
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else if (Operators.CompareString(cboUPdateType.Text, "Ght%", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,0 AS LBR_RATE,0 AS LBR_PRC,0 AS ITM_WEST_PRC,0 AS ITM_MRP,0 AS KR_TOUCH,0 AS KR_WEST_PRC,0 AS LBR_AMT,0 AS ITM_RATE,0 AS IT_RATE,A.ITM_GHT_PRC FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_GHT_PRC <> 0 "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" "), (object)" And TAG_NO NOT IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO <> 'N' AND B.GR_CODE = '"), (object)tGrCode.Text), (object)"' "), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) = 0) GROUP BY B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,A.ITM_GHT_PRC ORDER BY B.IT_TYPE,B.GR_CODE,B.IT_NAME,A.ITM_GHT_PRC DESC "));
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else if (Operators.CompareString(cboUPdateType.Text, "KrWest%", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,0 AS LBR_RATE,0 AS LBR_PRC,0 AS ITM_WEST_PRC,0 AS ITM_MRP,0 AS KR_TOUCH,A.KR_WEST_PRC,0 AS LBR_AMT,0 AS ITM_RATE,0 AS IT_RATE,0 AS ITM_GHT_PRC FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.KR_WEST_PRC <> 0 "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" "), (object)" And TAG_NO NOT IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO <> 'N' AND B.GR_CODE = '"), (object)tGrCode.Text), (object)"' "), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) = 0) GROUP BY B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,A.KR_WEST_PRC ORDER BY B.IT_TYPE,B.GR_CODE,B.IT_NAME,A.KR_WEST_PRC DESC "));
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,A.LBR_RATE,A.LBR_PRC,A.ITM_WEST_PRC,A.ITM_MRP,A.KR_TOUCH,A.KR_WEST_PRC,CASE WHEN A.LBR_PRC+A.LBR_RATE = 0 THEN A.LBR_AMT ELSE 0 END AS LBR_AMT,A.ITM_RATE,0 AS IT_RATE,0 AS ITM_GHT_PRC FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" "), (object)" And TAG_NO NOT IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO <> 'N' AND B.GR_CODE = '"), (object)tGrCode.Text), (object)"' "), Interaction.IIf(Operators.CompareString(tPrCode.Text, "", false) == 0, (object)"", (object)("AND B.PR_CODE = '" + tPrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) = 0) GROUP BY B.IT_TYPE,B.GR_CODE,A.IT_CODE,B.IT_NAME,A.LBR_RATE,A.LBR_PRC,A.ITM_WEST_PRC,A.ITM_MRP,A.KR_TOUCH,A.KR_WEST_PRC,CASE WHEN A.LBR_PRC+A.LBR_RATE = 0 THEN A.LBR_AMT ELSE 0 END,A.ITM_RATE ORDER BY B.IT_TYPE,B.GR_CODE,B.IT_NAME "));
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				}
				DC_Main.i = 0;
				DC_Main.R = 1;
				bool flag = false;
				string text = "";
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					AxMSFlexGrid mSG2 = MSG;
					((Control)TEXT_ENTRY).Visible = false;
					if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectNotEqual(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(RsDetl.Rows[DC_Main.i]["LBR_RATE"], RsDetl.Rows[DC_Main.i]["LBR_PRC"]), RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"]), RsDetl.Rows[DC_Main.i]["ITM_MRP"]), RsDetl.Rows[DC_Main.i]["LBR_AMT"]), RsDetl.Rows[DC_Main.i]["ITM_RATE"]), (object)Conversion.Val(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_RATE"], (object)""))), (object)0, false), Operators.CompareObjectEqual(Operators.AddObject(RsDetl.Rows[DC_Main.i]["KR_TOUCH"], RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"]), (object)0, false))))
					{
						mSG2[DC_Main.R, 0] = Conversions.ToString(DC_Main.R);
						mSG2[DC_Main.R, 1] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["IT_CODE"]);
						mSG2[DC_Main.R, 2] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["IT_NAME"]);
						mSG2[DC_Main.R, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"]), "0.00");
						if (Conversion.Val(mSG2[DC_Main.R, 3]) == 0.0)
						{
							mSG2[DC_Main.R, 3] = "";
						}
						mSG2[DC_Main.R, 4] = "";
						mSG2[DC_Main.R, 5] = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"]), "0.00");
						if (Conversion.Val(mSG2[DC_Main.R, 5]) == 0.0)
						{
							mSG2[DC_Main.R, 5] = "";
						}
						mSG2[DC_Main.R, 6] = "";
						mSG2[DC_Main.R, 9] = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"]), "0.00");
						if (Conversion.Val(mSG2[DC_Main.R, 9]) == 0.0)
						{
							mSG2[DC_Main.R, 9] = "";
						}
						mSG2[DC_Main.R, 11] = "";
						mSG2[DC_Main.R, 7] = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"]), "0.00");
						if (Conversion.Val(mSG2[DC_Main.R, 7]) == 0.0)
						{
							mSG2[DC_Main.R, 7] = "";
						}
						mSG2[DC_Main.R, 8] = "";
						mSG2[DC_Main.R, 12] = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"]), "0.00");
						if (Conversion.Val(mSG2[DC_Main.R, 12]) == 0.0)
						{
							mSG2[DC_Main.R, 12] = "";
						}
						mSG2[DC_Main.R, 13] = "";
						mSG2[DC_Main.R, 16] = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"]), "0.00");
						if (Conversion.Val(mSG2[DC_Main.R, 16]) == 0.0)
						{
							mSG2[DC_Main.R, 16] = "";
						}
						mSG2[DC_Main.R, 17] = "";
						mSG2[DC_Main.R, 18] = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"]), "0.00");
						if (Conversion.Val(mSG2[DC_Main.R, 18]) == 0.0)
						{
							mSG2[DC_Main.R, 18] = "";
						}
						mSG2[DC_Main.R, 19] = "";
						mSG2[DC_Main.R, 20] = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"]), "0.00");
						if (Conversion.Val(mSG2[DC_Main.R, 20]) == 0.0)
						{
							mSG2[DC_Main.R, 20] = "";
						}
						mSG2[DC_Main.R, 21] = "";
						mSG2[DC_Main.R, 22] = Strings.Format(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"]), "0.00");
						if (Conversion.Val(mSG2[DC_Main.R, 22]) == 0.0)
						{
							mSG2[DC_Main.R, 22] = "";
						}
						mSG2[DC_Main.R, 23] = "";
						mSG2[DC_Main.R, 14] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_RATE"], (object)"")), "0.00");
						if (Conversion.Val(mSG2[DC_Main.R, 14]) == 0.0)
						{
							mSG2[DC_Main.R, 14] = "";
						}
						mSG2[DC_Main.R, 15] = "";
						if (Operators.ConditionalCompareObjectNotEqual((object)text, RsDetl.Rows[DC_Main.i]["IT_CODE"], false))
						{
							mSG2.Row = DC_Main.R;
							text = Conversions.ToString(RsDetl.Rows[DC_Main.i]["IT_CODE"]);
							int num = mSG2.Cols - 1;
							for (int i = 2; i <= num; i++)
							{
								mSG2.Col = i;
								AxMSFlexGrid obj = mSG2;
								object? obj2 = colorConverter.ConvertFromString("&HD7D5EA");
								obj.CellBackColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
							}
						}
						mSG2.Rows += 1;
						DC_Main.R++;
					}
					DC_Main.i++;
					mSG2 = null;
				}
				MSG.Col = 1;
			}
			else if (Operators.CompareString(CurMast, "Item Touch", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select IT_CODE, IT_NAME, IT_TOUCH, IT_WEST, AVG_TOUCH, LBR_PRC, OTH_RATE,IT_LBR_RATE,RATE_TYPE,BULK_SALE,IT_GHT_PRC,APP_ITEM,EMP_COM_PRC,AC_MEMB_COM_PRC FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) != 0, (object)("AND GR_CODE = '" + tGrCode.Text + "'"), (object)"")), (object)" ORDER BY GR_CODE,IT_NAME"));
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG3 = MSG;
				while (DC_Main.i < DC_Main.Tbl.Rows.Count)
				{
					mSG3[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG3[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG3[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG3[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["BULK_SALE"], (object)""));
					mSG3[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["APP_ITEM"], (object)""), (object)"Y", false))
					{
						mSG3[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["APP_ITEM"], (object)""));
					}
					else
					{
						mSG3[DC_Main.i + 1, 5] = "";
					}
					mSG3[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["IT_TOUCH"], (object)"")), "0.00");
					if (Conversion.Val(mSG3[DC_Main.i + 1, 9]) == 0.0)
					{
						mSG3[DC_Main.i + 1, 9] = "";
					}
					mSG3[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["IT_WEST"], (object)"")), "0.00");
					if (Conversion.Val(mSG3[DC_Main.i + 1, 10]) == 0.0)
					{
						mSG3[DC_Main.i + 1, 10] = "";
					}
					mSG3[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["AVG_TOUCH"], (object)"")), "0.00");
					if (Conversion.Val(mSG3[DC_Main.i + 1, 7]) == 0.0)
					{
						mSG3[DC_Main.i + 1, 7] = "";
					}
					mSG3[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["LBR_PRC"], (object)"")), "0.00");
					if (Conversion.Val(mSG3[DC_Main.i + 1, 12]) == 0.0)
					{
						mSG3[DC_Main.i + 1, 12] = "";
					}
					mSG3[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["IT_GHT_PRC"], (object)"")), "0.00");
					if (Conversion.Val(mSG3[DC_Main.i + 1, 11]) == 0.0)
					{
						mSG3[DC_Main.i + 1, 11] = "";
					}
					mSG3[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["OTH_RATE"], (object)"")), "0.00");
					if (Conversion.Val(mSG3[DC_Main.i + 1, 15]) == 0.0)
					{
						mSG3[DC_Main.i + 1, 15] = "";
					}
					mSG3[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["IT_LBR_RATE"], (object)"")), "0.00");
					if (Conversion.Val(mSG3[DC_Main.i + 1, 14]) == 0.0)
					{
						mSG3[DC_Main.i + 1, 14] = "";
					}
					mSG3[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["EMP_COM_PRC"], (object)"")), "0.00");
					if (Conversion.Val(mSG3[DC_Main.i + 1, 16]) == 0.0)
					{
						mSG3[DC_Main.i + 1, 16] = "";
					}
					mSG3[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["AC_MEMB_COM_PRC"], (object)"")), "0.00");
					if (Conversion.Val(mSG3[DC_Main.i + 1, 8]) == 0.0)
					{
						mSG3[DC_Main.i + 1, 8] = "";
					}
					mSG3.CellForeColor = Color.Red;
					mSG3.Rows += 1;
					DC_Main.i++;
				}
				if (mSG3.Rows > 2)
				{
					mSG3.Rows -= 1;
				}
				mSG3 = null;
			}
			else if (Operators.CompareString(CurMast, "Labour", false) == 0)
			{
				DC_Main.RsQry = "SELECT IT_CODE,IT_NAME FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY GR_CODE,IT_NAME";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG4 = MSG;
				while (DC_Main.i < DC_Main.Tbl.Rows.Count)
				{
					mSG4[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG4[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG4[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					if (Operators.CompareString(tMembAcCode.Text, "", false) != 0)
					{
						DC_Main.RsQry = "SELECT * FROM TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE ='" + tMembAcCode.Text + "' AND AC_IT_CODE = '" + MSG[DC_Main.i + 1, 1] + "'";
					}
					else
					{
						DC_Main.RsQry = "SELECT * FROM TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE ='" + tGrCode.Text + "' AND AC_IT_CODE = '" + MSG[DC_Main.i + 1, 1] + "'";
					}
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						mSG4[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MEMB_COM_PRC"], (object)"")), "0.00");
						if (Conversion.Val(mSG4[DC_Main.i + 1, 8]) == 0.0)
						{
							mSG4[DC_Main.i + 1, 8] = "";
						}
						mSG4[DC_Main.i + 1, 9] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["AC_TOUCH"]), "0.00");
						if (Conversion.Val(mSG4[DC_Main.i + 1, 9]) == 0.0)
						{
							mSG4[DC_Main.i + 1, 9] = "";
						}
						mSG4[DC_Main.i + 1, 10] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["AC_WEST"]), "0.00");
						if (Conversion.Val(mSG4[DC_Main.i + 1, 10]) == 0.0)
						{
							mSG4[DC_Main.i + 1, 10] = "";
						}
						mSG4[DC_Main.i + 1, 11] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["AC_GHAT_PRC"]), "0.00");
						if (Conversion.Val(mSG4[DC_Main.i + 1, 11]) == 0.0)
						{
							mSG4[DC_Main.i + 1, 11] = "";
						}
						mSG4[DC_Main.i + 1, 12] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["AC_LBR_PRC"]), "0.00");
						if (Conversion.Val(mSG4[DC_Main.i + 1, 12]) == 0.0)
						{
							mSG4[DC_Main.i + 1, 12] = "";
						}
						mSG4[DC_Main.i + 1, 14] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["AC_LBR_RATE"]), "0.00");
						if (Conversion.Val(mSG4[DC_Main.i + 1, 14]) == 0.0)
						{
							mSG4[DC_Main.i + 1, 14] = "";
						}
						mSG4[DC_Main.i + 1, 15] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["AC_RATE"]), "0.00");
						if (Conversion.Val(mSG4[DC_Main.i + 1, 15]) == 0.0)
						{
							mSG4[DC_Main.i + 1, 15] = "";
						}
						mSG4[DC_Main.i + 1, 16] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["EMP_COM_PRC"]), "0.00");
						if (Conversion.Val(mSG4[DC_Main.i + 1, 16]) == 0.0)
						{
							mSG4[DC_Main.i + 1, 16] = "";
						}
						mSG4[DC_Main.i + 1, 13] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_LBR_TYPE"], (object)""));
						mSG4[DC_Main.i + 1, 19] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_USER"], (object)""));
						mSG4.CellForeColor = Color.Red;
					}
					mSG4.Rows += 1;
					DC_Main.i++;
				}
				if (mSG4.Rows > 2)
				{
					mSG4.Rows -= 1;
				}
				mSG4 = null;
			}
			else
			{
				DC_Main.RsQry = "SELECT * FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE NOT IN ('HM','DM','OG','OS','SN','FN','RD','EM','OT') ORDER BY PR_CODE,PR_NAME";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG5 = MSG;
				while (DC_Main.i < DC_Main.Tbl.Rows.Count)
				{
					mSG5[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG5[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG5[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["PR_NAME"], (object)""));
					DC_Main.RsQry = "SELECT * FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE ='" + tGrCode.Text + "' AND PR_CODE = '" + MSG[DC_Main.i + 1, 1] + "'";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						mSG5[DC_Main.i + 1, 4] = "Y";
						mSG5[DC_Main.i + 1, 19] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_USER"], (object)""));
						mSG5[DC_Main.i + 1, 20] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["STK_DISPLAY"], (object)""));
						mSG5[DC_Main.i + 1, 21] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OTH_DETL_POSTING"], (object)""));
						mSG5[DC_Main.i + 1, 22] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_WITH_LOT_STK"], (object)""));
						mSG5.CellForeColor = Color.Red;
					}
					else
					{
						mSG5[DC_Main.i + 1, 4] = "N";
						mSG5[DC_Main.i + 1, 20] = "Y";
					}
					mSG5.Rows += 1;
					DC_Main.i++;
				}
				if (mSG5.Rows > 2)
				{
					mSG5.Rows -= 1;
				}
				mSG5 = null;
			}
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
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Invalid comparison between Unknown and I4
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad7: Unknown result type (might be due to invalid IL or missing references)
		//IL_253c: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		checked
		{
			if (Operators.CompareString(CurMast, "Labour Disc", false) == 0)
			{
				if (!((MSG.Rows > 1) & (Operators.CompareString(MSG[1, 1], "", false) != 0)))
				{
					Interaction.MsgBox((object)"Please Select Group First And Try ...", (MsgBoxStyle)0, (object)null);
					return;
				}
				int num = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num)
				{
					DC_Main.RsQry = "UPDATE ITEM_MAST SET DISC_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 3])) + ",  ITM_FIX_GHT_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 4])) + ",  ITM_FIX_WEST_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 5])) + ",  MRP_DISC_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 6])) + "  WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + MSG[DC_Main.i, 1] + "' ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.i++;
				}
				if (Operators.CompareString(mFromDt.Text, "  /  /", false) == 0)
				{
					mFromDt.Text = Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "dd/MM/yyyy");
				}
				if (Operators.CompareString(mToDt.Text, "  /  /", false) == 0)
				{
					mToDt.Text = Strings.Format((object)DC_Main.MOp_dt.AddDays(-1.0), "dd/MM/yyyy");
				}
				DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET F_DISC_DATE = '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.ExeQuteDc("UPDATE CO_SET_NEW SET T_DISC_DATE = '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
				DC_Main.MsFDiscDt = Conversions.ToDate(mFromDt.Text);
				DC_Main.MsTDiscDt = Conversions.ToDate(mToDt.Text);
			}
			else
			{
				if (Operators.CompareString(CurMast, "Labour Update", false) == 0)
				{
					if (unchecked((int)Interaction.MsgBox((object)"New Value Replace With Old Value permantley ?", (MsgBoxStyle)20, (object)null)) == 6)
					{
						if (Operators.CompareString(cboUPdateType.Text, "ItRate", false) == 0)
						{
							int num2 = MSG.Rows - 1;
							DC_Main.i = 1;
							while (DC_Main.i <= num2)
							{
								if ((Conversion.Val(MSG[DC_Main.i, 12]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 13]) != 0.0))
								{
									DC_Main.RsQry = "SELECT A.TAG_NO,A.VCH_SRNO,B.KR_FINE,B.ITM_RATE,B.LBR_AMT,B.OTH_AMT,B.IT_CODE FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.IT_CODE = '" + MSG[DC_Main.i, 1] + "' AND B.ITM_RATE = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 12])) + " GROUP BY A.TAG_NO,A.VCH_SRNO,B.KR_FINE,B.ITM_RATE,B.LBR_AMT,B.OTH_AMT,B.IT_CODE HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY TAG_NO ";
									DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
									DC_Main.M = 0;
									while (DC_Main.M < DC_Main.Tbl.Rows.Count)
									{
										double num3 = Conversions.ToDouble(Strings.Format((object)Math.Round(Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["KR_FINE"], (object)"")) * Conversion.Val(MSG[DC_Main.i, 13]), 0), "0.00"));
										double num4 = Conversions.ToDouble(Strings.Format((object)Math.Round(num3 + Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["LBR_AMT"], (object)"")) + Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["OTH_AMT"], (object)"")), 0), "0.00"));
										DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET ITM_RATE = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 13])) + ",ITM_AMT = " + Conversions.ToString(num3) + ", KR_COST = " + Conversions.ToString(num4) + ",TAG_COST = " + Conversions.ToString(num4) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Tbl.Rows[DC_Main.M]["VCH_SRNO"]), (object)" AND ITM_RATE = "), (object)Conversion.Val(MSG[DC_Main.i, 12])), (object)" "));
										DC_Main.ExeQuteDc(DC_Main.RsQry);
										DC_Main.M++;
									}
								}
								DC_Main.i++;
							}
						}
						else if (Operators.CompareString(cboUPdateType.Text, "OthRate", false) == 0)
						{
							int num5 = MSG.Rows - 1;
							DC_Main.i = 1;
							while (DC_Main.i <= num5)
							{
								if ((Conversion.Val(MSG[DC_Main.i, 14]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 15]) != 0.0))
								{
									DC_Main.RsQry = "SELECT A.TAG_NO,A.VCH_SRNO,B.IT_PCS,B.IT_GWT,B.IT_RATE,B.IT_LBR_AMT,B.IT_CODE,B.IT_RATE_TYPE,B.ISR_NO FROM MAIN_STOCK AS A LEFT JOIN BAR_IDTL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.IT_CODE = '" + MSG[DC_Main.i, 1] + "' AND B.IT_RATE = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 14])) + " GROUP BY A.TAG_NO,A.VCH_SRNO,B.IT_PCS,B.IT_GWT,B.IT_RATE,B.IT_LBR_AMT,B.IT_CODE,B.IT_RATE_TYPE,B.ISR_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY A.TAG_NO,B.ISR_NO ";
									DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
									DC_Main.M = 0;
									while (DC_Main.M < DC_Main.Tbl.Rows.Count)
									{
										double num6 = ((!Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_RATE_TYPE"], (object)""), (object)"P", false)) ? Conversions.ToDouble(Strings.Format((object)Math.Round(Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"], (object)"")) * Conversion.Val(MSG[DC_Main.i, 15]), 0), "0.00")) : Conversions.ToDouble(Strings.Format((object)Math.Round(Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"], (object)"")) * Conversion.Val(MSG[DC_Main.i, 15]), 0), "0.00")));
										double num7 = Conversions.ToDouble(Strings.Format((object)Math.Round(num6 + Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_LBR_AMT"], (object)"")), 0), "0.00"));
										DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_IDTL SET IT_RATE = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 15])) + ",IT_AMT = " + Conversions.ToString(num6) + ", IT_NET_AMT = " + Conversions.ToString(num7) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Tbl.Rows[DC_Main.M]["VCH_SRNO"]), (object)" AND IT_RATE = "), (object)Conversion.Val(MSG[DC_Main.i, 14])), (object)" AND ISR_NO = "), DC_Main.Tbl.Rows[DC_Main.M]["ISR_NO"]), (object)" "));
										DC_Main.ExeQuteDc(DC_Main.RsQry);
										DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(IT_NET_AMT) As NetAmt FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Tbl.Rows[DC_Main.M]["VCH_SRNO"]), (object)" "));
										DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
										if (dataTable.Rows.Count > 0)
										{
											DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET OTH_AMT = " + Strings.Format((object)Math.Round(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["NetAmt"], (object)"")), 0), "0.00") + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Tbl.Rows[DC_Main.M]["VCH_SRNO"]), (object)" "));
											DC_Main.ExeQuteDc(DC_Main.RsQry);
											DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET KR_COST = ROUND(ITM_AMT+LBR_AMT+OTH_AMT,0),TAG_COST = ROUND(ITM_AMT+LBR_AMT+OTH_AMT,0) WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND VCH_SRNO = "), DC_Main.Tbl.Rows[DC_Main.M]["VCH_SRNO"]), (object)" "));
											DC_Main.ExeQuteDc(DC_Main.RsQry);
										}
										DC_Main.M++;
									}
								}
								DC_Main.i++;
							}
						}
						else
						{
							int num8 = MSG.Rows - 1;
							DC_Main.i = 1;
							while (DC_Main.i <= num8)
							{
								if ((Conversion.Val(MSG[DC_Main.i, 3]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 4]) != 0.0))
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET LBR_RATE = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 4])) + ",LBR_AMT = 0 WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = '" + MSG[DC_Main.i, 1] + "' AND LBR_RATE = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 3])) + " And TAG_NO IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) > 0)"));
									DC_Main.ExeQuteDc(DC_Main.RsQry);
								}
								if ((Conversion.Val(MSG[DC_Main.i, 3]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 6]) != 0.0))
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET LBR_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 6])) + ",LBR_RATE = 0,LBR_AMT = 0 WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = '" + MSG[DC_Main.i, 1] + "' AND LBR_RATE = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 3])) + " AND LBR_RATE <> 0 AND TAG_NO IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) > 0)"));
									DC_Main.ExeQuteDc(DC_Main.RsQry);
								}
								if ((Conversion.Val(MSG[DC_Main.i, 4]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 5]) != 0.0))
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET LBR_RATE = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 4])) + ",LBR_PRC = 0,LBR_AMT = 0 WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = '" + MSG[DC_Main.i, 1] + "' AND LBR_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 5])) + " AND LBR_PRC <> 0 AND TAG_NO IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) > 0)"));
									DC_Main.ExeQuteDc(DC_Main.RsQry);
								}
								if ((Conversion.Val(MSG[DC_Main.i, 5]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 6]) != 0.0))
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET LBR_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 6])) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = '" + MSG[DC_Main.i, 1] + "' AND LBR_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 5])) + " AND TAG_NO IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) > 0)"));
									DC_Main.ExeQuteDc(DC_Main.RsQry);
								}
								if ((Conversion.Val(MSG[DC_Main.i, 7]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 8]) != 0.0))
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET LBR_AMT = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 8])) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = '" + MSG[DC_Main.i, 1] + "' AND LBR_AMT = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 7])) + " AND LBR_RATE+LBR_PRC = 0 AND TAG_NO IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) > 0)"));
									DC_Main.ExeQuteDc(DC_Main.RsQry);
								}
								if ((Conversion.Val(MSG[DC_Main.i, 9]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 11]) != 0.0))
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET ITM_MRP = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 11])) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = '" + MSG[DC_Main.i, 1] + "' AND ITM_MRP = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 9])) + " AND TAG_NO IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.TAG_NO <> 'N'"), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) > 0)"));
									DC_Main.ExeQuteDc(DC_Main.RsQry);
								}
								if ((Conversion.Val(MSG[DC_Main.i, 16]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 17]) != 0.0))
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET ITM_WEST = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 17])) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = '" + MSG[DC_Main.i, 1] + "' AND ITM_WEST = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 16])) + " AND TAG_NO IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) > 0)"));
									DC_Main.ExeQuteDc(DC_Main.RsQry);
								}
								if ((Conversion.Val(MSG[DC_Main.i, 18]) != 0.0) & (Conversion.Val(MSG[DC_Main.i, 19]) != 0.0))
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET ITM_GHT_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 19])) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = '" + MSG[DC_Main.i, 1] + "' AND ITM_GHT_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 18])) + " AND TAG_NO IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) > 0)"));
									DC_Main.ExeQuteDc(DC_Main.RsQry);
								}
								if (Conversion.Val(MSG[DC_Main.i, 21]) != 0.0)
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET KR_TOUCH = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 21])) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = '" + MSG[DC_Main.i, 1] + "' AND KR_TOUCH = 0 TAG_NO IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) > 0)"));
									DC_Main.ExeQuteDc(DC_Main.RsQry);
								}
								if (Conversion.Val(MSG[DC_Main.i, 23]) != 0.0)
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET KR_WEST_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 23])) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = '" + MSG[DC_Main.i, 1] + "' AND KR_WEST_PRC = 0 AND TAG_NO IN (SELECT A.TAG_NO FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(tGrCode.Text, "", false) == 0, (object)"", (object)("AND B.GR_CODE = '" + tGrCode.Text + "'"))), (object)" GROUP BY TAG_NO HAVING SUM(IIF(ITM_SIGN = '+',VCH_SRNO,-VCH_SRNO)) > 0)"));
									DC_Main.ExeQuteDc(DC_Main.RsQry);
								}
								DC_Main.i++;
							}
						}
					}
					Interaction.MsgBox((object)"Please First Data Refresh Then Labour Or lbr% Or Mrp Or West%  Value Is Change Re Print Label..", (MsgBoxStyle)0, (object)null);
					CLEAR_DATA();
					return;
				}
				if (Operators.CompareString(CurMast, "Item Touch", false) == 0)
				{
					int num9 = MSG.Rows - 1;
					DC_Main.i = 1;
					while (DC_Main.i <= num9)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET IT_TOUCH = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 9])) + ",  IT_WEST = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 10])) + ",  LBR_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 12])) + ",  IT_GHT_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 11])) + ",  OTH_RATE = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 15])) + ",  EMP_COM_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 16])) + ",  IT_LBR_RATE = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 14])) + ",  AC_MEMB_COM_PRC = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 8])) + ",  RATE_TYPE = '" + MSG[DC_Main.i, 6] + "',  APP_ITEM = '"), Interaction.IIf(Operators.CompareString(MSG[DC_Main.i, 5], "Y", false) == 0, (object)"Y", (object)"N")), (object)"', "), (object)" BULK_SALE = '"), (object)MSG[DC_Main.i, 4]), (object)"' "), (object)" WHERE CO_CODE  = '"), (object)DC_Main.MCo_code), (object)"' AND IT_CODE = '"), (object)MSG[DC_Main.i, 1]), (object)"' "));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.i++;
					}
				}
				else if (Operators.CompareString(CurMast, "Labour", false) == 0)
				{
					DC_Main.RsQry = "DELETE FROM TOUCH_MAST WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tGrCode.Text + "'";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = "SELECT * FROM TOUCH_MAST WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tGrCode.Text + "'";
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow = RsDetl.NewRow();
					int num10 = MSG.Rows - 1;
					DC_Main.i = 1;
					while (DC_Main.i <= num10)
					{
						if ((Operators.CompareString(MSG[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(MSG[DC_Main.i, 8]) + Conversion.Val(MSG[DC_Main.i, 9]) + Conversion.Val(MSG[DC_Main.i, 10]) + Conversion.Val(MSG[DC_Main.i, 11]) + Conversion.Val(MSG[DC_Main.i, 12]) + Conversion.Val(MSG[DC_Main.i, 14]) + Conversion.Val(MSG[DC_Main.i, 15]) != 0.0))
						{
							dataRow["CO_CODE"] = DC_Main.MCo_code;
							dataRow["LC_CODE"] = DC_Main.MLc_code;
							dataRow["AC_CODE"] = tGrCode.Text;
							dataRow["AC_IT_CODE"] = MSG[DC_Main.i, 1];
							dataRow["AC_MEMB_COM_PRC"] = Conversion.Val(MSG[DC_Main.i, 8]);
							dataRow["AC_TOUCH"] = Conversion.Val(MSG[DC_Main.i, 9]);
							dataRow["AC_WEST"] = Conversion.Val(MSG[DC_Main.i, 10]);
							dataRow["AC_GHAT_PRC"] = Conversion.Val(MSG[DC_Main.i, 11]);
							dataRow["AC_LBR_PRC"] = Conversion.Val(MSG[DC_Main.i, 12]);
							dataRow["AC_LBR_RATE"] = Conversion.Val(MSG[DC_Main.i, 14]);
							dataRow["AC_RATE"] = Conversion.Val(MSG[DC_Main.i, 15]);
							dataRow["AC_LBR_TYPE"] = MSG[DC_Main.i, 13];
							dataRow["MAIN_USER"] = MSG[DC_Main.i, 19];
							RsDetl.Rows.Add(dataRow);
							((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
							RsDetl.Clear();
						}
						DC_Main.i++;
					}
				}
				else
				{
					DC_Main.RsQry = "SELECT * FROM ITEM_MAST WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND GR_CODE = '" + tGrCode.Text + "'";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DataView dataView = new DataView(DC_Main.Rshlp);
					DC_Main.RsQry = "SELECT * FROM ITEM_MAST WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND GR_CODE = '" + tGrCode.Text + "'";
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow2 = RsDetl.NewRow();
					int num11 = MSG.Rows - 1;
					DC_Main.i = 1;
					while (DC_Main.i <= num11)
					{
						if ((Operators.CompareString(MSG[DC_Main.i, 1], "", false) != 0) & (Operators.CompareString(MSG[DC_Main.i, 4], "Y", false) == 0))
						{
							dataView.RowFilter = "CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE  = '" + MSG[DC_Main.i, 1] + tGrCode.Text + "' ";
							if (dataView.Count == 0)
							{
								dataRow2["CO_CODE"] = DC_Main.MCo_code;
								dataRow2["IT_CODE"] = MSG[DC_Main.i, 1] + tGrCode.Text;
								dataRow2["IT_NAME"] = MSG[DC_Main.i, 2] + " " + tGrCode.Text;
								dataRow2["IT_TYPE"] = tGrType.Text;
								dataRow2["TAG_TYPE"] = tGrType.Text;
								dataRow2["TRAD_TYPE"] = tTradType.Text;
								dataRow2["PR_CODE"] = MSG[DC_Main.i, 1];
								dataRow2["GR_CODE"] = tGrCode.Text;
								dataRow2["SAFE_NAME"] = "MAIN";
								dataRow2["HSN_CODE"] = tHsnCode.Text;
								dataRow2["UNIT_NAME"] = "GMS";
								dataRow2["RATE_TYPE"] = "G";
								dataRow2["EMP_COM_PRC"] = 0;
								dataRow2["MIN_STK"] = Conversion.Val(MSG[DC_Main.i, 3]);
								dataRow2["MAIN_USER"] = MSG[DC_Main.i, 19];
								dataRow2["STK_DISPLAY"] = MSG[DC_Main.i, 20];
								dataRow2["DATA_TRFR"] = "N";
								dataRow2["TAG_IDTL_COL"] = "N";
								dataRow2["OTH_DETL_POSTING"] = "N";
								dataRow2["OTH_ITM_WT_REMOVE"] = "N";
								dataRow2["TAX_FREE_ITEM"] = "N";
								RsDetl.Rows.Add(dataRow2);
								((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
								RsDetl.Clear();
							}
						}
						DC_Main.i++;
					}
				}
			}
			Interaction.MsgBox((object)"Data Are Saved.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Invalid comparison between Unknown and I4
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(CurMast, "Labour", false) == 0 && (int)Interaction.MsgBox((object)"Are You Sure To Delete This Record now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "DELETE FROM TOUCH_MAST WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tGrCode.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Interaction.MsgBox((object)"Data Are Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
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

	private void MS_AUTO_ITEM_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_AUTO_ITEM_KeyPress(object sender, KeyPressEventArgs e)
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

	private void MS_AUTO_ITEM_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 27)
		{
			return;
		}
		if (((Control)TEXT_ENTRY).Visible)
		{
			MSG_LeaveCell(MSG, new EventArgs());
			MSG.Row = checked(MSG.Rows - 1);
			MSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			if (Operators.CompareString(CurMast, "Labour Disc", false) == 0)
			{
				((Control)mFromDt).Focus();
			}
			else
			{
				((Control)BtnSave).Focus();
			}
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void MS_AUTO_ITEM_KeyUp(object sender, KeyEventArgs e)
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

	private void MSG_TOT_Scroll(object sender, EventArgs e)
	{
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
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Invalid comparison between Unknown and I4
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Invalid comparison between Unknown and I4
		//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
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
				if (unchecked((int)keyCode) == 112)
				{
					if ((Operators.CompareString(CurMast, "Labour Disc", false) == 0) & (MSG.Row == 1))
					{
						if (unchecked((int)Interaction.MsgBox((object)"All Item Descount % Set...?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) == 6)
						{
							int num = MSG.Rows - 1;
							DC_Main.i = 1;
							while (DC_Main.i <= num)
							{
								MSG[DC_Main.i, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
								DC_Main.i++;
							}
						}
					}
					else
					{
						TEXT_ENTRY.Text = mSG[mSG.Row - 1, mSG.Col];
					}
				}
			}
			else
			{
				if (Operators.CompareString(CurMast, "Labour Disc", false) == 0)
				{
					if (mSG.Row == mSG.Rows - 1)
					{
						mSG.Rows += 1;
						mSG.Row += 1;
						CommPassAdd();
						mSG.Col = 3;
						((Control)TEXT_ENTRY).Visible = false;
						((Control)mFromDt).Focus();
					}
					else
					{
						mSG.Row += 1;
						((Control)TEXT_ENTRY).Visible = true;
						((Control)TEXT_ENTRY).Focus();
					}
					return;
				}
				if (Operators.CompareString(CurMast, "Labour Update", false) == 0)
				{
					switch (mSG.Col)
					{
					case 10:
						if (Conversion.Val(TEXT_ENTRY.Text) > 0.0)
						{
							mSG[mSG.Row, 11] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 9]) * (1.0 + Conversion.Val(TEXT_ENTRY.Text) / 100.0)), "0.00");
						}
						break;
					case 4:
					case 6:
					case 11:
					case 17:
					case 19:
					case 21:
					case 23:
						if (mSG.Row == mSG.Rows - 1)
						{
							mSG.Rows += 1;
							mSG.Row += 1;
							CommPassAdd();
							mSG.Col = 4;
							((Control)TEXT_ENTRY).Visible = false;
							((Control)BtnSave).Enabled = true;
							((Control)BtnSave).Focus();
						}
						else
						{
							mSG.Row += 1;
							((Control)TEXT_ENTRY).Visible = true;
							((Control)TEXT_ENTRY).Focus();
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
					case 4:
						if ((Operators.CompareString(TEXT_ENTRY.Text, "Y", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, "N", false) != 0))
						{
							Interaction.MsgBox((object)"Please Enter Y or N and Try Again...", (MsgBoxStyle)0, (object)null);
						}
						else if (mSG.Row == mSG.Rows - 1)
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
					case 15:
					case 16:
						if (Operators.CompareString(CurMast, "Labour", false) != 0 && ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) & (mSG.Col == 15)))
						{
							MSG.Col += 1;
							((Control)TEXT_ENTRY).Visible = true;
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						if (mSG.Row == mSG.Rows - 1)
						{
							mSG.Rows += 1;
							mSG.Row += 1;
							CommPassAdd();
							mSG.Col = 1;
							return;
						}
						mSG.Row += 1;
						if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
						{
							mSG.Col = 8;
						}
						else
						{
							mSG.Col = 9;
						}
						((Control)TEXT_ENTRY).Visible = true;
						((Control)TEXT_ENTRY).Focus();
						return;
					}
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

	private void tGrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0799: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(CurMast, "Labour Update", false) == 0)
		{
			DC_Main.RsQry = "Select * From GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND GR_CODE = '" + tGrCode.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT GR_NAME As GrNameL,GR_CODE as GrCodeL,GR_TYPE as TypeL,TRAD_TYPE As TradTypeL,HSN_CODE As HsnCodeL FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY GR_NAME";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[6];
				DC_Main.ColWidth[0] = 300.0;
				DC_Main.ColWidth[1] = 100.0;
				DC_Main.ColWidth[2] = 100.0;
				DC_Main.ColWidth[3] = 100.0;
				DC_Main.ColWidth[4] = 120.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
					{
						tGrCode.Text = DC_Main.ColValue[1];
						tGrName.Text = DC_Main.ColValue[0];
						tGrType.Text = DC_Main.ColValue[2];
						tTradType.Text = DC_Main.ColValue[3];
						tHsnCode.Text = DC_Main.ColValue[4];
					}
					((TextBoxBase)tGrCode).SelectAll();
				}
			}
			else
			{
				tGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_NAME"], (object)""));
				tGrType.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_TYPE"], (object)""));
				tTradType.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TRAD_TYPE"], (object)""));
				((Control)tPrCode).Focus();
			}
			return;
		}
		if (Operators.CompareString(CurMast, "Item Touch", false) == 0)
		{
			if (Operators.CompareString(tGrCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = "Select * From GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND GR_CODE = '" + tGrCode.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count == 0)
				{
					DC_Main.RsQry = "SELECT GR_NAME As GrNameL,GR_CODE as GrCodeL,GR_TYPE as TypeL,TRAD_TYPE As TradTypeL,HSN_CODE As HsnCodeL FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY GR_NAME";
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.ColWidth = new double[6];
					DC_Main.ColWidth[0] = 300.0;
					DC_Main.ColWidth[1] = 100.0;
					DC_Main.ColWidth[2] = 100.0;
					DC_Main.ColWidth[3] = 100.0;
					DC_Main.ColWidth[4] = 120.0;
					DC_Main.HelpSelect = 1;
					((Form)MyProject.Forms.MS_HELP).ShowDialog();
					if (DC_Main.HelpClose)
					{
						return;
					}
					if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
					{
						tGrCode.Text = DC_Main.ColValue[1];
						tGrName.Text = DC_Main.ColValue[0];
						tGrType.Text = DC_Main.ColValue[2];
						tTradType.Text = DC_Main.ColValue[3];
						tHsnCode.Text = DC_Main.ColValue[4];
						DISPLAY_DATA();
						MSG.Row = 1;
						if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
						{
							MSG.Col = 8;
						}
						else
						{
							MSG.Col = 9;
						}
						MSG_EnterCell(MSG, new EventArgs());
						((Control)TEXT_ENTRY).Focus();
					}
					((TextBoxBase)tGrCode).SelectAll();
				}
				else
				{
					tGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_NAME"], (object)""));
					tGrType.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_TYPE"], (object)""));
					tTradType.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TRAD_TYPE"], (object)""));
					DISPLAY_DATA();
					MSG.Row = 1;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
					{
						MSG.Col = 8;
					}
					else
					{
						MSG.Col = 9;
					}
					MSG_EnterCell(MSG, new EventArgs());
					((Control)TEXT_ENTRY).Focus();
				}
			}
			else
			{
				DISPLAY_DATA();
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
				{
					MSG.Col = 8;
				}
				else
				{
					MSG.Col = 9;
				}
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
			return;
		}
		if (Operators.CompareString(CurMast, "Labour", false) == 0)
		{
			tMembAcCode.Text = "";
			DC_Main.RsQry = "Select AC_CODE,AC_NAME From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tGrCode.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL,B.AC_GR_NAME as GroupL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.AC_NAME";
				}
				else
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL,B.AC_GR_NAME as GroupL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY A.AC_NAME";
				}
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[4];
				DC_Main.ColWidth[0] = 300.0;
				DC_Main.ColWidth[1] = 100.0;
				DC_Main.ColWidth[2] = 200.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (DC_Main.HelpClose)
				{
					return;
				}
				if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tGrCode.Text = DC_Main.ColValue[1];
					tGrName.Text = DC_Main.ColValue[0];
					DISPLAY_DATA();
					MSG.Row = 1;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
					{
						MSG.Col = 8;
					}
					else
					{
						MSG.Col = 9;
					}
					MSG_EnterCell(MSG, new EventArgs());
					((Control)TEXT_ENTRY).Focus();
				}
				((TextBoxBase)tGrCode).SelectAll();
			}
			else
			{
				tGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
				tGrType.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
				DISPLAY_DATA();
				MSG.Row = 1;
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
				{
					MSG.Col = 8;
				}
				else
				{
					MSG.Col = 9;
				}
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
			return;
		}
		DC_Main.RsQry = "Select * From GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND GR_CODE = '" + tGrCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT GR_NAME As GrNameL,GR_CODE as GrCodeL,GR_TYPE as TypeL,TRAD_TYPE As TradTypeL,HSN_CODE As HsnCodeL FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY GR_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[6];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 100.0;
			DC_Main.ColWidth[3] = 100.0;
			DC_Main.ColWidth[4] = 120.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (DC_Main.HelpClose)
			{
				return;
			}
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tGrCode.Text = DC_Main.ColValue[1];
				tGrName.Text = DC_Main.ColValue[0];
				tGrType.Text = DC_Main.ColValue[2];
				tTradType.Text = DC_Main.ColValue[3];
				tHsnCode.Text = DC_Main.ColValue[4];
				DISPLAY_DATA();
				MSG.Row = 1;
				if (Operators.CompareString(CurMast, "Labour Disc", false) == 0)
				{
					MSG.Col = 3;
				}
				else
				{
					MSG.Col = 4;
				}
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
			((TextBoxBase)tGrCode).SelectAll();
		}
		else
		{
			tGrName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_NAME"], (object)""));
			tGrType.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GR_TYPE"], (object)""));
			tTradType.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TRAD_TYPE"], (object)""));
			DISPLAY_DATA();
			MSG.Row = 1;
			if (Operators.CompareString(CurMast, "Labour Disc", false) == 0)
			{
				MSG.Col = 3;
			}
			else
			{
				MSG.Col = 4;
			}
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void MS_AUTO_ITEM_Closed(object sender, EventArgs e)
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
				((Control)BtnSave).Enabled = true;
				((Control)BtnSave).Focus();
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

	private void tPrCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tPrCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND PR_CODE = '" + tPrCode.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT PR_NAME As PrNameL,PR_CODE as PrCodeL FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY PR_NAME";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[3];
				DC_Main.ColWidth[1] = 100.0;
				DC_Main.ColWidth[0] = 300.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
					{
						tPrCode.Text = DC_Main.ColValue[1];
					}
					((TextBoxBase)tPrCode).SelectAll();
				}
			}
			else
			{
				DISPLAY_DATA();
				MSG.Row = 1;
				MSG.Col = 4;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
		}
		else
		{
			DISPLAY_DATA();
			MSG.Row = 1;
			MSG.Col = 4;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void tMembAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tGrCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select AcCode First...And Try", (MsgBoxStyle)0, (object)null);
			((Control)tGrCode).Focus();
			return;
		}
		DC_Main.RsQry = "Select A.AC_CODE,B.AC_NAME From TOUCH_MAST AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_CODE <> '" + tGrCode.Text + "' AND A.AC_CODE = '" + tMembAcCode.Text + "' GROUP BY A.AC_CODE,B.AC_NAME";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT B.AC_NAME As AcNameL,A.AC_CODE as AcCodeL,C.AC_GR_NAME as GroupL FROM (TOUCH_MAST AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE) LEFT JOIN AC_GROUP AS C ON B.CO_CODE = C.CO_CODE AND B.AC_GR = C.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_CODE <> '" + tGrCode.Text + "' GROUP BY  B.AC_NAME,A.AC_CODE,C.AC_GR_NAME ORDER BY B.AC_NAME";
			}
			else
			{
				DC_Main.RsQry = "SELECT B.AC_NAME As AcNameL,A.AC_CODE as AcCodeL,C.AC_GR_NAME as GroupL FROM (TOUCH_MAST AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE) LEFT JOIN AC_GROUP AS C ON B.CO_CODE = C.CO_CODE AND B.AC_GR = C.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE <> '" + tGrCode.Text + "' GROUP BY B.AC_NAME,A.AC_CODE,C.AC_GR_NAME ORDER BY B.AC_NAME";
			}
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[4];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 200.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tMembAcCode.Text = DC_Main.ColValue[1];
					tMembAcName.Text = DC_Main.ColValue[0];
					DISPLAY_DATA();
					MSG.Row = 1;
					MSG.Col = 8;
					MSG_EnterCell(MSG, new EventArgs());
					((Control)TEXT_ENTRY).Focus();
				}
				((TextBoxBase)tMembAcCode).SelectAll();
			}
		}
		else
		{
			tMembAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
			tMembAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
			DISPLAY_DATA();
			MSG.Row = 1;
			MSG.Col = 8;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void cboUPdateType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			DISPLAY_DATA();
			MSG.Row = 1;
			MSG.Col = 4;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
			if (Operators.CompareString(cboUPdateType.Text, "Mrp", false) == 0)
			{
				((Control)nMrpMargin).Visible = true;
				((Control)Label1).Visible = true;
			}
			else
			{
				nMrpMargin.Text = "";
				((Control)nMrpMargin).Visible = false;
				((Control)Label1).Visible = false;
			}
		}
	}

	private void nMrpMargin_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13 || Operators.CompareString(nMrpMargin.Text, "", false) == 0)
		{
			return;
		}
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				AxMSFlexGrid mSG = MSG;
				mSG[DC_Main.i, 10] = Strings.Format((object)Conversion.Val(nMrpMargin.Text), "0.00");
				if ((Conversion.Val(mSG[DC_Main.i, 9]) > 0.0) & (Conversion.Val(nMrpMargin.Text) != 0.0))
				{
					double num2 = Conversion.Val(mSG[DC_Main.i, 9]);
					double num3 = Conversion.Val(nMrpMargin.Text);
					double value = num2 * (1.0 + num3 / 100.0);
					mSG[DC_Main.i, 11] = Strings.Format((object)Math.Round(value, 2), "0.00");
				}
				mSG = null;
				DC_Main.i++;
			}
		}
	}

	private void cboUPdateType_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void BtnSave_KeyDown(object sender, KeyEventArgs e)
	{
	}
}
