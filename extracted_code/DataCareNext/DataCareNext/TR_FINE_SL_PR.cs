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
using DevNet.Models;
using MSFlexGridLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class TR_FINE_SL_PR : Form
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
	[AccessedThroughProperty("MSG_IDTL")]
	private AxMSFlexGrid _MSG_IDTL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_IDTL")]
	private TextBox _TEXT_IDTL;

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
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG2_TOTAL")]
	private AxMSFlexGrid _MSG2_TOTAL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY_2")]
	private TextBox _TEXT_ENTRY_2;

	private Module_WhatsApp whatsApp;

	private string UsUPdate;

	private string UsDelete;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private bool RowChang;

	private string CurRatePar;

	private double OldTdsPrc;

	private double OldDiscPrc;

	private double OldDiscAmt;

	private double CustOpAmt;

	private double CustOpGold;

	private double CustOpSilver;

	private double CustClAmt;

	private double CustClGold;

	private double CustClSilver;

	private string OldAcCode;

	private double BillAdjAmt;

	private string AcGstType;

	private double OldNetAmt;

	private double OldTaxPrc;

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

	private double AcTcsAmt;

	private double OldTcsPrc;

	private string MaxVchNo;

	private string LastVchNo;

	private const int cSrNo = 0;

	private const int cItmNwt = 1;

	private const int cItmTch = 2;

	private const int cFine = 3;

	private const int cConvertRate = 4;

	private const int cConvertPrc = 5;

	private const int cRate = 6;

	private const int cItmAmt = 7;

	private const int cTotAmt = 8;

	private const int cVatPrc = 9;

	private const int cNetAmt = 10;

	private const int cOldRate = 11;

	private const int cOldAmt = 12;

	private const int cOldFine = 13;

	private const int c1SrNo = 0;

	private const int c1BillNo = 1;

	private const int c1BookName = 2;

	private const int c1BillSrNo = 3;

	private const int c1ItCode = 4;

	private const int c1ItName = 5;

	private const int c1Pcs = 6;

	private const int c1GrWt = 7;

	private const int c1NetWt = 8;

	private const int c1Touch = 9;

	private const int c1WestPrc = 10;

	private const int c1Fine = 11;

	private const int c1StkFine = 12;

	private const int c1StkGwt = 13;

	private const int c1StkNwt = 14;

	private const int c1StkPcs = 15;

	private const int c1StkNetAmt = 16;

	private const int c1BillYrCd = 17;

	private const int c1BillDbCd = 18;

	private const int c1EntryMod = 19;

	private const int c1TagNo = 20;

	private const int c1DesignNo = 21;

	private const int c1LotType = 22;

	private const int c1VchSrNo = 23;

	private const int c1HmId = 24;

	private const int c1HmId2 = 25;

	private const int c1HmId3 = 26;

	private const int c1HmId4 = 27;

	private const int c1BillDt = 28;

	private const int c1StkItmAmt = 29;

	private const int c1StkItmRate = 30;

	private const int cNetAmt2 = 0;

	private const int cLbrDisc2 = 1;

	private const int cTax2 = 2;

	private const int cTcs2 = 3;

	private const int cTds2 = 4;

	private const int cRof2 = 5;

	private const int cTot2 = 6;

	private const int cChq2 = 7;

	private const int cCard2 = 8;

	private const int cCash2 = 9;

	private const int cKasar2 = 10;

	private const int cOs2 = 11;

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
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = tVchNo_DoubleClick;
			EventHandler eventHandler2 = TVchNo_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tVchNo_KeyDown);
			TextBox val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).DoubleClick -= eventHandler;
				((Control)val2).TextChanged -= eventHandler2;
				((Control)val2).KeyDown -= val;
			}
			_tVchNo = value;
			val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).DoubleClick += eventHandler;
				((Control)val2).TextChanged += eventHandler2;
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

	internal virtual AxMSFlexGrid MSG_IDTL
	{
		[CompilerGenerated]
		get
		{
			return _MSG_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_IDTL_ClickEvent;
			EventHandler eventHandler2 = MSG_IDTL_EnterCell;
			EventHandler eventHandler3 = MSG_IDTL_LeaveCell;
			AxMSFlexGrid val = _MSG_IDTL;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_IDTL = value;
			val = _MSG_IDTL;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	internal virtual TextBox TEXT_IDTL
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_IDTL_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_IDTL_KeyDown);
			TextBox val2 = _TEXT_IDTL;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_IDTL = value;
			val2 = _TEXT_IDTL;
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
			EventHandler eventHandler = TAcCode_TextChanged;
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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
	[AccessedThroughProperty("LOpSilver")]
	private virtual Label _LOpSilver;

	internal virtual Label LOpSilver
	{
		get
		{
			return _LOpSilver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LOpSilver = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LOpGold")]
	private virtual Label _LOpGold;

	internal virtual Label LOpGold
	{
		get
		{
			return _LOpGold;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LOpGold = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_BILL_TOT")]
	private virtual AxMSFlexGrid _MSG_BILL_TOT;

	internal virtual AxMSFlexGrid MSG_BILL_TOT
	{
		get
		{
			return _MSG_BILL_TOT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_MSG_BILL_TOT = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LClSilver")]
	private virtual Label _LClSilver;

	internal virtual Label LClSilver
	{
		get
		{
			return _LClSilver;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LClSilver = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lClGold")]
	private virtual Label _lClGold;

	internal virtual Label lClGold
	{
		get
		{
			return _lClGold;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lClGold = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LClAmt")]
	private virtual Label _LClAmt;

	internal virtual Label LClAmt
	{
		get
		{
			return _LClAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LClAmt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboItemTyp")]
	private virtual ComboBox _cboItemTyp;

	internal virtual ComboBox cboItemTyp
	{
		get
		{
			return _cboItemTyp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboItemTyp = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label12")]
	private virtual Label _Label12;

	internal virtual Label Label12
	{
		get
		{
			return _Label12;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label12 = value;
		}
	}

	internal virtual AxMSFlexGrid MSG2_TOTAL
	{
		[CompilerGenerated]
		get
		{
			return _MSG2_TOTAL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG2_TOTAL_ClickEvent;
			EventHandler eventHandler2 = MSG2_TOTAL_EnterCell;
			EventHandler eventHandler3 = MSG2_TOTAL_LeaveCell;
			AxMSFlexGrid val = _MSG2_TOTAL;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG2_TOTAL = value;
			val = _MSG2_TOTAL;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobileNo")]
	private virtual TextBox _tMobileNo;

	internal virtual TextBox tMobileNo
	{
		get
		{
			return _tMobileNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tMobileNo = value;
		}
	}

	internal virtual TextBox TEXT_ENTRY_2
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_ENTRY_2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_ENTRY_2_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_ENTRY_2_KeyDown);
			TextBox val2 = _TEXT_ENTRY_2;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_ENTRY_2 = value;
			val2 = _TEXT_ENTRY_2;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchDesc")]
	private virtual TextBox _tVchDesc;

	internal virtual TextBox tVchDesc
	{
		get
		{
			return _tVchDesc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tVchDesc = value;
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

	public TR_FINE_SL_PR()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_FINE_SL_PR_Load;
		((Form)this).Deactivate += TR_FINE_SL_PR_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_FINE_SL_PR_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_FINE_SL_PR_KeyDown);
		((Form)this).Activated += TR_FINE_SL_PR_Activated;
		((Form)this).Closed += TR_FINE_SL_PR_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_FINE_SL_PR_KeyUp);
		whatsApp = UT_WHATSAPP.whatsApp;
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
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Expected O, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected O, but got Unknown
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected O, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected O, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Expected O, but got Unknown
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Expected O, but got Unknown
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Expected O, but got Unknown
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Expected O, but got Unknown
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c9: Expected O, but got Unknown
		//IL_0574: Unknown result type (might be due to invalid IL or missing references)
		//IL_057e: Expected O, but got Unknown
		//IL_0602: Unknown result type (might be due to invalid IL or missing references)
		//IL_060c: Expected O, but got Unknown
		//IL_06a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Expected O, but got Unknown
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0747: Expected O, but got Unknown
		//IL_07aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b4: Expected O, but got Unknown
		//IL_085d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0867: Expected O, but got Unknown
		//IL_08ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d4: Expected O, but got Unknown
		//IL_097d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0987: Expected O, but got Unknown
		//IL_0aa4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aae: Expected O, but got Unknown
		//IL_0bb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc3: Expected O, but got Unknown
		//IL_0c26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c30: Expected O, but got Unknown
		//IL_0dc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e80: Expected O, but got Unknown
		//IL_0f78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f82: Expected O, but got Unknown
		//IL_1093: Unknown result type (might be due to invalid IL or missing references)
		//IL_109d: Expected O, but got Unknown
		//IL_113b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1145: Expected O, but got Unknown
		//IL_11ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f6: Expected O, but got Unknown
		//IL_125a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1264: Expected O, but got Unknown
		//IL_12c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12cf: Expected O, but got Unknown
		//IL_134e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1358: Expected O, but got Unknown
		//IL_1430: Unknown result type (might be due to invalid IL or missing references)
		//IL_143a: Expected O, but got Unknown
		//IL_14d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_14e0: Expected O, but got Unknown
		//IL_161b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1625: Expected O, but got Unknown
		//IL_1689: Unknown result type (might be due to invalid IL or missing references)
		//IL_1693: Expected O, but got Unknown
		//IL_1733: Unknown result type (might be due to invalid IL or missing references)
		//IL_173d: Expected O, but got Unknown
		//IL_17b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c1: Expected O, but got Unknown
		//IL_1849: Unknown result type (might be due to invalid IL or missing references)
		//IL_1853: Expected O, but got Unknown
		//IL_1904: Unknown result type (might be due to invalid IL or missing references)
		//IL_190e: Expected O, but got Unknown
		//IL_1988: Unknown result type (might be due to invalid IL or missing references)
		//IL_1992: Expected O, but got Unknown
		//IL_1a17: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a21: Expected O, but got Unknown
		//IL_1acf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad9: Expected O, but got Unknown
		//IL_1b8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b97: Expected O, but got Unknown
		//IL_1c4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c55: Expected O, but got Unknown
		//IL_1d1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d29: Expected O, but got Unknown
		//IL_1d77: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d81: Expected O, but got Unknown
		//IL_1e38: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e42: Expected O, but got Unknown
		//IL_1ef9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f03: Expected O, but got Unknown
		//IL_1fc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd0: Expected O, but got Unknown
		//IL_203d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2047: Expected O, but got Unknown
		//IL_2111: Unknown result type (might be due to invalid IL or missing references)
		//IL_211b: Expected O, but got Unknown
		//IL_216c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2176: Expected O, but got Unknown
		//IL_2205: Unknown result type (might be due to invalid IL or missing references)
		//IL_220f: Expected O, but got Unknown
		//IL_22a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_22ae: Expected O, but got Unknown
		//IL_234d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2357: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_FINE_SL_PR));
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
		TEXT_IDTL = new TextBox();
		MSG_IDTL = new AxMSFlexGrid();
		MSG_TOT = new AxMSFlexGrid();
		MSG = new AxMSFlexGrid();
		DlgOpen = new OpenFileDialog();
		BtnF1 = new SimpleButton();
		Cr = new AxCrystalReport();
		tHdVchNo = new TextBox();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label3 = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label1 = new Label();
		LOpSilver = new Label();
		LOpGold = new Label();
		LOpAmt = new Label();
		MSG_BILL_TOT = new AxMSFlexGrid();
		LClSilver = new Label();
		lClGold = new Label();
		LClAmt = new Label();
		cboItemTyp = new ComboBox();
		Label12 = new Label();
		MSG2_TOTAL = new AxMSFlexGrid();
		tMobileNo = new TextBox();
		TEXT_ENTRY_2 = new TextBox();
		tVchDesc = new TextBox();
		Label4 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)MSG_IDTL).BeginInit();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG_BILL_TOT).BeginInit();
		((ISupportInitialize)MSG2_TOTAL).BeginInit();
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
		((Control)lblBook).TabIndex = 7;
		lblBook.Text = "Fine Sales";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mVchDate).Location = new Point(297, 42);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 22);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(227, 43);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(19, 43);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(68, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tVchNo).Location = new Point(104, 42);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 22);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mDay).Location = new Point(458, 42);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 22);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mTime).Location = new Point(378, 42);
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
		((Control)PnlBotam).TabIndex = 6;
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
		((Control)TEXT_ENTRY).Location = new Point(353, 133);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 3;
		((Control)TEXT_ENTRY).Visible = false;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(521, 245);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 4;
		((Control)TEXT_IDTL).Visible = false;
		((Control)MSG_IDTL).Location = new Point(23, 197);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(1140, 101);
		((Control)MSG_IDTL).TabIndex = 1140;
		((Control)MSG_TOT).Location = new Point(27, 173);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(617, 17);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(28, 104);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(913, 67);
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
		((Control)BtnF1).Location = new Point(186, 41);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1215, 171);
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
		((Control)tHdVchNo).TabIndex = 8;
		((Control)tHdVchNo).Visible = false;
		((TextBoxBase)tEmpCode).BackColor = Color.White;
		((Control)tEmpCode).Font = new Font("Tahoma", 9f);
		((Control)tEmpCode).Location = new Point(115, 367);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 22);
		((Control)tEmpCode).TabIndex = 5;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tEmpName).Location = new Point(178, 367);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(249, 22);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(29, 367);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(104, 71);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 2;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(186, 71);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(355, 23);
		((Control)tAcName).TabIndex = 1210;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(19, 70);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(75, 20);
		((Control)Label1).TabIndex = 1211;
		Label1.Text = "Party Code";
		Label1.TextAlign = (ContentAlignment)16;
		((Control)LOpSilver).BackColor = Color.Transparent;
		((Control)LOpSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpSilver).ForeColor = Color.Black;
		LOpSilver.ImeMode = (ImeMode)0;
		((Control)LOpSilver).Location = new Point(990, 83);
		((Control)LOpSilver).Name = "LOpSilver";
		((Control)LOpSilver).Size = new Size(168, 20);
		((Control)LOpSilver).TabIndex = 1214;
		LOpSilver.Text = "OpSilver";
		LOpSilver.TextAlign = (ContentAlignment)64;
		((Control)LOpGold).BackColor = Color.Transparent;
		((Control)LOpGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpGold).ForeColor = Color.Black;
		LOpGold.ImeMode = (ImeMode)0;
		((Control)LOpGold).Location = new Point(990, 63);
		((Control)LOpGold).Name = "LOpGold";
		((Control)LOpGold).Size = new Size(168, 20);
		((Control)LOpGold).TabIndex = 1213;
		LOpGold.Text = "OpGold";
		LOpGold.TextAlign = (ContentAlignment)64;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(990, 43);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(168, 20);
		((Control)LOpAmt).TabIndex = 1212;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)MSG_BILL_TOT).Location = new Point(28, 300);
		((Control)MSG_BILL_TOT).Name = "MSG_BILL_TOT";
		((AxHost)MSG_BILL_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_BILL_TOT.OcxState");
		((Control)MSG_BILL_TOT).Size = new Size(1134, 17);
		((Control)MSG_BILL_TOT).TabIndex = 1215;
		((Control)LClSilver).BackColor = Color.Transparent;
		((Control)LClSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClSilver).ForeColor = Color.Black;
		LClSilver.ImeMode = (ImeMode)0;
		((Control)LClSilver).Location = new Point(539, 531);
		((Control)LClSilver).Name = "LClSilver";
		((Control)LClSilver).Size = new Size(177, 20);
		((Control)LClSilver).TabIndex = 1218;
		LClSilver.Text = "ClSilver";
		LClSilver.TextAlign = (ContentAlignment)64;
		((Control)lClGold).BackColor = Color.Transparent;
		((Control)lClGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lClGold).ForeColor = Color.Black;
		lClGold.ImeMode = (ImeMode)0;
		((Control)lClGold).Location = new Point(538, 511);
		((Control)lClGold).Name = "lClGold";
		((Control)lClGold).Size = new Size(177, 20);
		((Control)lClGold).TabIndex = 1217;
		lClGold.Text = "ClGold";
		lClGold.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(538, 490);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(177, 20);
		((Control)LClAmt).TabIndex = 1216;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(632, 43);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(117, 22);
		((Control)cboItemTyp).TabIndex = 1220;
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(547, 42);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(74, 20);
		((Control)Label12).TabIndex = 1221;
		Label12.Text = "Item Type";
		Label12.TextAlign = (ContentAlignment)16;
		((Control)MSG2_TOTAL).Location = new Point(722, 320);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(441, 239);
		((Control)MSG2_TOTAL).TabIndex = 1222;
		((TextBoxBase)tMobileNo).BackColor = Color.White;
		((Control)tMobileNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tMobileNo).Location = new Point(548, 71);
		((TextBoxBase)tMobileNo).MaxLength = 10;
		((Control)tMobileNo).Name = "tMobileNo";
		((Control)tMobileNo).Size = new Size(97, 23);
		((Control)tMobileNo).TabIndex = 1219;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(881, 452);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 1223;
		((Control)TEXT_ENTRY_2).Visible = false;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(115, 403);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(402, 53);
		((Control)tVchDesc).TabIndex = 1224;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(17, 403);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(76, 20);
		((Control)Label4).TabIndex = 1225;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)tVchDesc);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY_2);
		((Control)this).Controls.Add((Control)(object)MSG2_TOTAL);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)tMobileNo);
		((Control)this).Controls.Add((Control)(object)LClSilver);
		((Control)this).Controls.Add((Control)(object)lClGold);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)MSG_BILL_TOT);
		((Control)this).Controls.Add((Control)(object)LOpSilver);
		((Control)this).Controls.Add((Control)(object)LOpGold);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)tEmpCode);
		((Control)this).Controls.Add((Control)(object)tEmpName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)tHdVchNo);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)BtnF1);
		((Control)this).Controls.Add((Control)(object)TEXT_IDTL);
		((Control)this).Controls.Add((Control)(object)MSG_IDTL);
		((Control)this).Controls.Add((Control)(object)MSG_TOT);
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
		((Control)this).Name = "TR_FINE_SL_PR";
		((Form)this).Text = "Fine Sales";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)MSG_IDTL).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG_BILL_TOT).EndInit();
		((ISupportInitialize)MSG2_TOTAL).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		mSG_IDTL.Clear();
		mSG_IDTL.Cols = 31;
		mSG_IDTL.FixedRows = 1;
		mSG_IDTL.Rows = 2;
		mSG_IDTL.Row = 1;
		mSG_IDTL[0] = 0;
		mSG_IDTL[1] = 0;
		mSG_IDTL.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_IDTL[0] = (int)Math.Round(500.0 * ColCon);
			mSG_IDTL[0] = 3;
			mSG_IDTL[0, 0] = "Sr";
			mSG_IDTL[1] = (int)Math.Round(1200.0 * ColCon);
			mSG_IDTL[1] = 0;
			mSG_IDTL[0, 1] = "BillNo";
			mSG_IDTL[2] = (int)Math.Round(2000.0 * ColCon);
			mSG_IDTL[2] = 0;
			mSG_IDTL[0, 2] = "Book";
			mSG_IDTL[3] = (int)Math.Round(700.0 * ColCon);
			mSG_IDTL[3] = 3;
			mSG_IDTL[0, 3] = "BkSr";
			mSG_IDTL[4] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[4] = 0;
			mSG_IDTL[0, 4] = "ItCode";
			mSG_IDTL[5] = (int)Math.Round(2200.0 * ColCon);
			mSG_IDTL[5] = 0;
			mSG_IDTL[0, 5] = "ItName";
			mSG_IDTL[6] = (int)Math.Round(700.0 * ColCon);
			mSG_IDTL[6] = 7;
			mSG_IDTL[0, 6] = "Pcs";
			mSG_IDTL[7] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[7] = 7;
			mSG_IDTL[0, 7] = "GrWt";
			mSG_IDTL[8] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[8] = 7;
			mSG_IDTL[0, 8] = "NetWt";
			mSG_IDTL[9] = (int)Math.Round(800.0 * ColCon);
			mSG_IDTL[9] = 7;
			mSG_IDTL[0, 9] = "Touch";
			mSG_IDTL[10] = (int)Math.Round(800.0 * ColCon);
			mSG_IDTL[10] = 7;
			mSG_IDTL[0, 10] = "West%";
			mSG_IDTL[11] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[11] = 7;
			mSG_IDTL[0, 11] = "Fine";
			mSG_IDTL[12] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[12] = 7;
			mSG_IDTL[0, 12] = "CutFine";
			mSG_IDTL[13] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[13] = 7;
			mSG_IDTL[0, 13] = "CutGwt";
			mSG_IDTL[14] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[14] = 7;
			mSG_IDTL[0, 14] = "CutNwt";
			mSG_IDTL[15] = (int)Math.Round(700.0 * ColCon);
			mSG_IDTL[15] = 7;
			mSG_IDTL[0, 15] = "CutPcs";
			mSG_IDTL[16] = (int)Math.Round(0.0 * ColCon);
			mSG_IDTL[16] = 7;
			mSG_IDTL[0, 16] = "CutAmt";
			mSG_IDTL[17] = 0;
			mSG_IDTL[18] = 0;
			mSG_IDTL[19] = 0;
			mSG_IDTL[20] = 0;
			mSG_IDTL[21] = 0;
			mSG_IDTL[22] = 0;
			mSG_IDTL[23] = 0;
			mSG_IDTL[24] = 0;
			mSG_IDTL[25] = 0;
			mSG_IDTL[26] = 0;
			mSG_IDTL[27] = 0;
			mSG_IDTL[28] = 0;
			mSG_IDTL[29] = 0;
			mSG_IDTL[30] = 0;
			mSG_IDTL.Row = 1;
			mSG_IDTL.Col = 0;
			((Control)TEXT_IDTL).Visible = false;
			mSG_IDTL[0] = (int)Math.Round(325.0 * ColCon);
			mSG_IDTL[1] = (int)Math.Round(300.0 * ColCon);
			mSG_IDTL.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd_Idtl();
			AxMSFlexGrid mSG_BILL_TOT = MSG_BILL_TOT;
			mSG_BILL_TOT.Cols = MSG_IDTL.Cols;
			int num = MSG_IDTL.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				mSG_BILL_TOT[DC_Main.M] = MSG_IDTL[DC_Main.M];
				mSG_BILL_TOT[DC_Main.M] = MSG_IDTL[DC_Main.M];
				DC_Main.M++;
			}
			MSG_BILL_TOT_FILL();
			mSG_BILL_TOT = null;
			mSG_IDTL = null;
		}
	}

	private void CommPassAdd_Idtl()
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		mSG_IDTL[mSG_IDTL.Row, 0] = Conversions.ToString(mSG_IDTL.Row);
		mSG_IDTL[mSG_IDTL.Row, 28] = mVchDate.Text;
		mSG_IDTL = null;
	}

	private void TEXT_IDTL_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_IDTL_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Invalid comparison between Unknown and I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Invalid comparison between Unknown and I4
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Invalid comparison between Unknown and I4
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Invalid comparison between Unknown and I4
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Invalid comparison between Unknown and I4
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Invalid comparison between Unknown and I4
		//IL_0a4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = mSG_IDTL.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						mSG_IDTL[mSG_IDTL.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					CommPassTotal_Idtl(1);
					TEXT_IDTL.Text = "";
					Interaction.MsgBox((object)"Record is Deleted....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG_IDTL.Col > 1)
				{
					MsgIdtlLeft = true;
					mSG_IDTL.Col = checked(mSG_IDTL.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				if (mSG_IDTL.Col < 10)
				{
					mSG_IDTL.Col = checked(mSG_IDTL.Col + 1);
				}
				return;
			}
			if ((int)keyCode == 38)
			{
				if (mSG_IDTL.Row > 1)
				{
					mSG_IDTL.Row = checked(mSG_IDTL.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_IDTL.Row < mSG_IDTL.Rows - 1)
					{
						mSG_IDTL.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG_IDTL.Col)
					{
					case 1:
					{
						if (!((Operators.CompareString(TEXT_IDTL.Text, "", false) != 0) & (Operators.CompareString(TEXT_IDTL.Text, mSG_IDTL[mSG_IDTL.Row, 1], false) != 0)))
						{
							break;
						}
						if (Operators.CompareString(FormMainBook, "FINE PURC", false) == 0)
						{
							DC_Main.RsQry = "Select A.*, B.IT_NAME,B.IT_TYPE As ItType,B.RATE_TYPE, B.PR_CODE as PrCode From PR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG_IDTL[mSG_IDTL.Row, 17] + "' AND CO_BOOK = '" + mSG_IDTL[mSG_IDTL.Row, 18] + "' AND OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 3])) + " AND VCH_NO = '" + TEXT_IDTL.Text + "'";
						}
						else
						{
							DC_Main.RsQry = "Select A.*, B.IT_NAME,B.IT_TYPE As ItType,B.RATE_TYPE, B.PR_CODE as PrCode From RATE_CUT_ISU AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG_IDTL[mSG_IDTL.Row, 17] + "' AND CO_BOOK = '" + mSG_IDTL[mSG_IDTL.Row, 18] + "' AND OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 3])) + " AND VCH_NO = '" + TEXT_IDTL.Text + "'";
						}
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (Operators.CompareString(FormMainBook, "FINE PURC", false) == 0)
							{
								DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,C.IT_NAME As ItNameL,A.AC_NAME as CustNameL,B.ITM_GWT AS GrWtW,B.FINE_CUT_GWT AS GwtAdjW,B.OLD_SRNO AS SrNoM,B.CO_YEAR,B.CO_BOOK,B.IT_CODE,B.ITM_FINE AS FineW,B.FINE_CUT_FINE AS FineAdjW,D.BOOK_NAME As BookL,B.ITM_FINE - B.FINE_CUT_FINE AS BalFineW  FROM ((PR_DATA AS A INNER JOIN PR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.IT_CODE = C.IT_CODE WHERE B.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  AND D.MAIN_BOOK IN ('PURCHASE') AND B.ITM_AMT = 0 AND B.WITH_STOCK = 'Y' AND B.ITM_FINE > B.FINE_CUT_FINE ORDER BY B.VCH_NO,B.SR_NO";
							}
							else
							{
								DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,C.IT_NAME As ItNameL,A.AC_NAME as CustNameL,B.ITM_GWT AS GrWtW,B.FINE_CUT_GWT AS GwtAdjW,B.OLD_SRNO AS SrNoM,B.CO_YEAR,B.CO_BOOK,B.IT_CODE,B.ITM_FINE AS FineW,B.FINE_CUT_FINE AS FineAdjW,D.BOOK_NAME As BookL,B.ITM_FINE - B.FINE_CUT_FINE AS BalFineW  FROM ((RATE_CUT_DATA AS A INNER JOIN RATE_CUT_ISU AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.IT_CODE = C.IT_CODE WHERE B.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  AND D.MAIN_BOOK IN ('WH SALES') AND B.ITM_AMT = 0 AND B.ITM_FINE > B.FINE_CUT_FINE ORDER BY B.VCH_NO,B.SR_NO";
							}
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[15];
							DC_Main.ColWidth[0] = 90.0;
							DC_Main.ColWidth[1] = 120.0;
							DC_Main.ColWidth[2] = 180.0;
							DC_Main.ColWidth[3] = 275.0;
							DC_Main.ColWidth[4] = 90.0;
							DC_Main.ColWidth[5] = 90.0;
							DC_Main.ColWidth[6] = 65.0;
							DC_Main.ColWidth[7] = 0.0;
							DC_Main.ColWidth[8] = 0.0;
							DC_Main.ColWidth[9] = 0.0;
							DC_Main.ColWidth[10] = 90.0;
							DC_Main.ColWidth[11] = 90.0;
							DC_Main.ColWidth[12] = 0.0;
							DC_Main.ColWidth[13] = 90.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
								{
									TEXT_IDTL.Text = DC_Main.ColValue[0];
									mSG_IDTL[mSG_IDTL.Row, 4] = DC_Main.ColValue[9];
									mSG_IDTL[mSG_IDTL.Row, 5] = DC_Main.ColValue[2];
									mSG_IDTL[mSG_IDTL.Row, 3] = DC_Main.ColValue[6];
									mSG_IDTL[mSG_IDTL.Row, 17] = DC_Main.ColValue[7];
									mSG_IDTL[mSG_IDTL.Row, 18] = DC_Main.ColValue[8];
									mSG_IDTL[mSG_IDTL.Row, 2] = DC_Main.ColValue[12];
								}
								else
								{
									mSG_IDTL[mSG_IDTL.Row, 1] = "";
									mSG_IDTL[mSG_IDTL.Row, 3] = "";
									mSG_IDTL[mSG_IDTL.Row, 17] = "";
									mSG_IDTL[mSG_IDTL.Row, 18] = "";
									mSG_IDTL[mSG_IDTL.Row, 2] = "";
								}
								((Control)TEXT_IDTL).Focus();
							}
							return;
						}
						DC_Main.i = mSG_IDTL.Row;
						AxMSFlexGrid mSG_IDTL2 = MSG_IDTL;
						mSG_IDTL2[DC_Main.i, 1] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["VCH_NO"]);
						mSG_IDTL2[DC_Main.i, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OLD_SRNO"]), "0");
						mSG_IDTL2[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
						mSG_IDTL2[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
						mSG_IDTL2[DC_Main.i, 6] = Strings.Format(Operators.SubtractObject(DC_Main.Rshlp.Rows[0]["ITM_PCS"], DC_Main.Rshlp.Rows[0]["FINE_CUT_PCS"]), "0");
						mSG_IDTL2[DC_Main.i, 7] = Strings.Format(Operators.SubtractObject(DC_Main.Rshlp.Rows[0]["ITM_GWT"], DC_Main.Rshlp.Rows[0]["FINE_CUT_GWT"]), "0.000");
						mSG_IDTL2[DC_Main.i, 8] = Strings.Format(Operators.SubtractObject(DC_Main.Rshlp.Rows[0]["ITM_NWT"], DC_Main.Rshlp.Rows[0]["FINE_CUT_NWT"]), "0.000");
						mSG_IDTL2[DC_Main.i, 9] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"]), "0.00");
						mSG_IDTL2[DC_Main.i, 10] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"]), "0.00");
						mSG_IDTL2[DC_Main.i, 11] = Strings.Format(Operators.SubtractObject(DC_Main.Rshlp.Rows[0]["ITM_FINE"], DC_Main.Rshlp.Rows[0]["FINE_CUT_FINE"]), "0.000");
						mSG_IDTL2[DC_Main.i, 19] = "A";
						mSG_IDTL2[DC_Main.i, 17] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
						mSG_IDTL2[DC_Main.i, 18] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_BOOK"], (object)""));
						mSG_IDTL2[DC_Main.i, 28] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VCH_DATE"]), "dd/MM/yyyy");
						mSG_IDTL2 = null;
						MSG_BILL_TOT_FILL();
						mSG_IDTL.Col = 11;
						((Control)TEXT_IDTL).Visible = true;
						((Control)TEXT_IDTL).Focus();
						break;
					}
					case 12:
						if (Conversion.Val(TEXT_IDTL.Text) == 0.0)
						{
							return;
						}
						if (Conversion.Val(TEXT_IDTL.Text) > Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 11]))
						{
							Interaction.MsgBox((object)"Please Enter Less Value form Item Fine...and Try...", (MsgBoxStyle)0, (object)null);
							return;
						}
						break;
					case 15:
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							mSG_IDTL[mSG_IDTL.Row, 15] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0");
							CommPassTotal_Idtl(mSG_IDTL.Row);
							MsgClearIdtl = true;
							mSG_IDTL.Rows += 1;
							mSG_IDTL.Row += 1;
							MsgClearIdtl = false;
							mSG_IDTL.Col = 1;
							CommPassAdd_Idtl();
						}
						else
						{
							mSG_IDTL.Row += 1;
							mSG_IDTL.Col = 8;
							((Control)TEXT_IDTL).Visible = true;
							((Control)TEXT_IDTL).Focus();
						}
						return;
					}
					if (mSG_IDTL.Col < mSG_IDTL.Cols - 1)
					{
						mSG_IDTL.Col += 1;
					}
					((Control)TEXT_IDTL).Visible = true;
					((Control)TEXT_IDTL).Focus();
				}
			}
		}
		mSG_IDTL = null;
	}

	private void MSG_IDTL_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		checked
		{
			if (mSG_IDTL.CellWidth >= 0)
			{
				((Control)TEXT_IDTL).Left = (int)Math.Round((double)((Control)mSG_IDTL).Left + (double)mSG_IDTL.CellLeft / 15.0);
				((Control)TEXT_IDTL).Top = (int)Math.Round((double)((Control)mSG_IDTL).Top + (double)mSG_IDTL.CellTop / 15.0);
				((Control)TEXT_IDTL).Width = (int)Math.Round((double)mSG_IDTL.CellWidth / 15.0);
				((Control)TEXT_IDTL).Height = (int)Math.Round((double)mSG_IDTL.CellHeight / 15.0);
				TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
				((Control)TEXT_IDTL).Visible = true;
				((Control)TEXT_ENTRY).Visible = false;
				((TextBoxBase)TEXT_IDTL).SelectAll();
				((Control)TEXT_IDTL).Focus();
				mSG_IDTL = null;
			}
		}
	}

	private void MSG_IDTL_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		int col;
		checked
		{
			if (mSG_IDTL[mSG_IDTL.Col] == 0)
			{
				TEXT_IDTL.Text = "";
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = "";
				DC_Main.M = 1;
				while (mSG_IDTL[mSG_IDTL.Col] == 0)
				{
					if (MsgIdtlLeft)
					{
						if (mSG_IDTL.Col > 1)
						{
							mSG_IDTL.Col -= 1;
						}
					}
					else if (mSG_IDTL.Col < mSG_IDTL.Cols - 1)
					{
						mSG_IDTL.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 10)
					{
						break;
					}
				}
			}
			if (((mSG_IDTL.Row == 0) | (mSG_IDTL.CellWidth <= 0)) || mSG_IDTL[mSG_IDTL.Col] == 0)
			{
				return;
			}
			((Control)TEXT_IDTL).Left = (int)Math.Round((double)((Control)mSG_IDTL).Left + (double)mSG_IDTL.CellLeft / 15.0);
			((Control)TEXT_IDTL).Top = (int)Math.Round((double)((Control)mSG_IDTL).Top + (double)mSG_IDTL.CellTop / 15.0);
			((Control)TEXT_IDTL).Width = (int)Math.Round((double)mSG_IDTL.CellWidth / 15.0);
			((Control)TEXT_IDTL).Height = (int)Math.Round((double)mSG_IDTL.CellHeight / 15.0);
			((Control)TEXT_IDTL).Visible = true;
			((TextBoxBase)TEXT_IDTL).ReadOnly = false;
			col = MSG_IDTL.Col;
		}
		if (col == 0)
		{
			((TextBoxBase)TEXT_IDTL).MaxLength = 5;
			TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
		}
		else if (col == 1)
		{
			((TextBoxBase)TEXT_IDTL).MaxLength = 8;
			TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
		}
		else if (col == 2)
		{
			((TextBoxBase)TEXT_IDTL).MaxLength = 50;
			TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
			((TextBoxBase)TEXT_IDTL).ReadOnly = true;
		}
		else if (col == 3)
		{
			((TextBoxBase)TEXT_IDTL).MaxLength = 6;
			TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0");
			((TextBoxBase)TEXT_IDTL).ReadOnly = true;
		}
		else if (col == 4)
		{
			((TextBoxBase)TEXT_IDTL).MaxLength = 5;
			TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
			((TextBoxBase)TEXT_IDTL).ReadOnly = true;
		}
		else if (col == 5)
		{
			((TextBoxBase)TEXT_IDTL).MaxLength = 50;
			TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
			((TextBoxBase)TEXT_IDTL).ReadOnly = true;
		}
		else if (col == 19)
		{
			((TextBoxBase)TEXT_IDTL).MaxLength = 1;
			TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
		}
		else if (col == 9 || col == 10)
		{
			((TextBoxBase)TEXT_IDTL).MaxLength = 10;
			TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.00");
			((TextBoxBase)TEXT_IDTL).ReadOnly = true;
		}
		else if (col == 11 || col == 8 || col == 7 || col == 0 - ((((TextBoxBase)TEXT_IDTL).MaxLength == 10) ? 1 : 0))
		{
			TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.000");
			((TextBoxBase)TEXT_IDTL).ReadOnly = true;
		}
		else
		{
			switch (col)
			{
			case 6:
				((TextBoxBase)TEXT_IDTL).MaxLength = 6;
				TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0");
				((TextBoxBase)TEXT_IDTL).ReadOnly = true;
				break;
			case 15:
				((TextBoxBase)TEXT_IDTL).MaxLength = 6;
				TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0");
				break;
			case 12:
				((TextBoxBase)TEXT_IDTL).MaxLength = 11;
				TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.000");
				break;
			default:
				if (col == 12 || col == 13 || col == 14)
				{
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.000");
					((TextBoxBase)TEXT_IDTL).ReadOnly = true;
				}
				else if (col == 16)
				{
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.00");
					((TextBoxBase)TEXT_IDTL).ReadOnly = true;
				}
				break;
			}
		}
		mSG_IDTL = null;
		((TextBoxBase)TEXT_IDTL).SelectAll();
	}

	private void MSG_IDTL_LeaveCell(object sender, EventArgs e)
	{
		if (!MsgClearIdtl && MSG_IDTL.Row != 0 && MSG_IDTL[MSG_IDTL.Col] != 0 && ((Control)TEXT_IDTL).Visible)
		{
			AxMSFlexGrid mSG_IDTL = MSG_IDTL;
			switch (MSG_IDTL.Col)
			{
			case 0:
			case 1:
			case 2:
			case 4:
			case 5:
			case 19:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = TEXT_IDTL.Text;
				break;
			case 3:
			case 6:
			case 15:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 9:
			case 10:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 7:
			case 8:
			case 11:
			case 12:
			case 13:
			case 14:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			}
			mSG_IDTL = null;
		}
	}

	private void CommPassTotal_Idtl(int CRow)
	{
		BillAdjAmt = Conversion.Val(MSG_TOT[0, 10]);
		double num = 0.0;
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 8]) == 0.0)
		{
			mSG_IDTL[mSG_IDTL.Row, 8] = Strings.Format((object)mSG_IDTL[mSG_IDTL.Row, 7], "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 8]) != 0.0) & (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 9]) + Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) != 0.0))
		{
			mSG_IDTL[mSG_IDTL.Row, 11] = Strings.Format((object)(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 8]) * (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 9]) + Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10])) / 100.0), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 9]) + Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) == 0.0) & (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 11]) == 0.0))
		{
			mSG_IDTL[mSG_IDTL.Row, 11] = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 8]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 9]) + Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) != 0.0))
		{
			mSG_IDTL[mSG_IDTL.Row, 14] = Strings.Format((object)(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) / (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 9]) + Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10])) * 100.0), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 9]) + Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 10]) == 0.0))
		{
			mSG_IDTL[mSG_IDTL.Row, 14] = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 14]) != 0.0) & (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 7]) != 0.0) & (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 8]) != 0.0))
		{
			mSG_IDTL[mSG_IDTL.Row, 13] = Strings.Format((object)(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 14]) * Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 7]) / Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 8])), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 14]) != 0.0) & (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 6]) != 0.0) & (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 8]) != 0.0))
		{
			mSG_IDTL[mSG_IDTL.Row, 15] = Strings.Format((object)Math.Round(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 14]) * Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 6]) / Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 8]), 0), "0");
		}
		double num2 = ((Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0) ? Conversions.ToDouble(Strings.Format((object)(Conversion.Val(MSG[1, 6]) / 10.0), "0.00")) : ((Operators.CompareString(DC_Main.MsRatePar, "K", false) != 0) ? Conversions.ToDouble(Strings.Format((object)Conversion.Val(MSG[1, 6]), "0.00")) : Conversions.ToDouble(Strings.Format((object)(Conversion.Val(MSG[1, 6]) / 1000.0), "0.00"))));
		if ((num2 != 0.0) & (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) != 0.0))
		{
			mSG_IDTL[mSG_IDTL.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) * num2, 0), "0.00");
			mSG_IDTL[mSG_IDTL.Row, 30] = Strings.Format((object)num2, "0.00");
		}
		MSG_BILL_TOT_FILL();
		mSG_IDTL = null;
	}

	private void MSG_BILL_TOT_FILL()
	{
		checked
		{
			if (!UpDown)
			{
				AxMSFlexGrid mSG_BILL_TOT = MSG_BILL_TOT;
				int num = MSG_IDTL.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					mSG_BILL_TOT[0, DC_Main.M] = "";
					DC_Main.M++;
				}
				mSG_BILL_TOT[0, 2] = "Total :";
				int num2 = MSG_IDTL.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_BILL_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_BILL_TOT[0, 8]) + Conversion.Val(MSG_IDTL[DC_Main.M, 8]))), "0.000");
					mSG_BILL_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_BILL_TOT[0, 11]) + Conversion.Val(MSG_IDTL[DC_Main.M, 11]))), "0.000");
					mSG_BILL_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_BILL_TOT[0, 12]) + Conversion.Val(MSG_IDTL[DC_Main.M, 12]))), "0.000");
					DC_Main.M++;
				}
				mSG_BILL_TOT = null;
			}
		}
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 14;
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
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
			{
				mSG[1] = (int)Math.Round(1100.0 * ColCon);
				mSG[1] = 7;
				mSG[0, 1] = "NetWt";
				mSG[2] = (int)Math.Round(900.0 * ColCon);
				mSG[2] = 7;
				mSG[0, 2] = "Touch";
			}
			else
			{
				mSG[1] = 0;
				mSG[1] = 7;
				mSG[0, 1] = "NetWt";
				mSG[2] = 0;
				mSG[2] = 7;
				mSG[0, 2] = "Touch";
			}
			mSG[3] = (int)Math.Round(1200.0 * ColCon);
			mSG[3] = 7;
			mSG[0, 3] = "Fine";
			mSG[4] = (int)Math.Round(1200.0 * ColCon);
			mSG[4] = 7;
			mSG[0, 4] = "ConRate";
			mSG[5] = (int)Math.Round(1000.0 * ColCon);
			mSG[5] = 7;
			mSG[0, 5] = "Con%";
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				mSG[6] = (int)Math.Round(1200.0 * ColCon);
				mSG[6] = 7;
				mSG[0, 6] = "Rate10gm";
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				mSG[6] = (int)Math.Round(1200.0 * ColCon);
				mSG[6] = 7;
				mSG[0, 6] = "RateKg";
			}
			else
			{
				mSG[6] = (int)Math.Round(1200.0 * ColCon);
				mSG[6] = 7;
				mSG[0, 6] = "Rate1Gm";
			}
			mSG[7] = (int)Math.Round(1300.0 * ColCon);
			mSG[7] = 7;
			mSG[0, 7] = "Amount";
			mSG[8] = (int)Math.Round(1300.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "TotAmt";
			mSG[9] = (int)Math.Round(1000.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "Tax%";
			mSG[10] = (int)Math.Round(1300.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "NetAmt";
			mSG[11] = 0;
			mSG[12] = 0;
			mSG[13] = 0;
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			MsgLastCol = 9;
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
		checked
		{
			if (!UpDown)
			{
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				int num = MSG.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					mSG_TOT[0, DC_Main.M] = "";
					DC_Main.M++;
				}
				mSG_TOT[0, 6] = "Total :";
				int num2 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_TOT[0, 3] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 3]) + Conversion.Val(MSG[DC_Main.M, 3]))), "0.00");
					mSG_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 7]) + Conversion.Val(MSG[DC_Main.M, 7]))), "0.00");
					mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0.00");
					mSG_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 10]) + Conversion.Val(MSG[DC_Main.M, 10]))), "0.000");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 9]);
			}
		}
	}

	private void BILL_TOTAL()
	{
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		if (Conversion.Val(MSG_TOT[0, 10]) != 0.0)
		{
			mSG2_TOTAL[0, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 10]), 0), "0.00");
			if (Conversion.Val(mSG2_TOTAL[1, 2]) != OldDiscPrc)
			{
				OldDiscPrc = Conversion.Val(mSG2_TOTAL[1, 2]);
				OldNetAmt = 0.0;
			}
			if (Conversion.Val(mSG2_TOTAL[1, 3]) != OldDiscAmt)
			{
				OldDiscAmt = Conversion.Val(mSG2_TOTAL[1, 3]);
				OldNetAmt = 0.0;
			}
			if ((Conversion.Val(mSG2_TOTAL[0, 3]) != OldNetAmt) | (Conversion.Val(mSG2_TOTAL[2, 2]) != OldTaxPrc))
			{
				OldNetAmt = Conversion.Val(mSG2_TOTAL[0, 3]);
				OldTaxPrc = Conversion.Val(mSG2_TOTAL[2, 2]);
				if (Conversion.Val(mSG2_TOTAL[1, 2]) != 0.0)
				{
					mSG2_TOTAL[1, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) * Conversion.Val(mSG2_TOTAL[1, 2]) / 100.0, 0), "0.00");
				}
				mSG2_TOTAL[2, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[2, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
				OldTcsPrc = 111.0;
			}
			if (OldTcsPrc != Conversion.Val(MSG2_TOTAL[3, 2]))
			{
				OldTcsPrc = Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG2_TOTAL[3, 2]), "0.000"));
				if ((Conversion.Val(mSG2_TOTAL[3, 2]) != 0.0) & (Conversion.Val(mSG2_TOTAL[0, 3]) != 0.0))
				{
					mSG2_TOTAL[3, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[3, 2]) / 100.0, 0), "0.00");
				}
				else
				{
					mSG2_TOTAL[3, 3] = "";
				}
			}
		}
		else
		{
			mSG2_TOTAL[0, 3] = "";
			mSG2_TOTAL[2, 3] = "";
			mSG2_TOTAL[6, 3] = "";
			mSG2_TOTAL[11, 3] = "";
		}
		if (((Conversion.Val(mSG2_TOTAL[4, 2]) != 0.0) & (Conversion.Val(mSG2_TOTAL[0, 3]) != 0.0)) && OldTdsPrc != Conversion.Val(mSG2_TOTAL[4, 2]))
		{
			OldTdsPrc = Conversion.Val(mSG2_TOTAL[4, 2]);
			mSG2_TOTAL[4, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[4, 2]) / 100.0, 0), "0.00");
		}
		mSG2_TOTAL[6, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) - (Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[4, 3])) + Conversion.Val(mSG2_TOTAL[5, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]), 0), "0.00");
		mSG2_TOTAL[11, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[7, 3]) - Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[10, 3])), "0.00");
		if (CustOpAmt > 0.0)
		{
			CustClAmt = CustOpAmt + Conversion.Val(mSG2_TOTAL[11, 3]);
		}
		else if (CustOpAmt < 0.0)
		{
			CustClAmt = Conversion.Val(mSG2_TOTAL[11, 3]) - Math.Abs(CustOpAmt);
		}
		else
		{
			CustClAmt = Conversion.Val(mSG2_TOTAL[11, 3]);
		}
		if (CustClAmt > 0.0)
		{
			LClAmt.Text = Strings.Format((object)CustClAmt, "0.00") + " : Cr Amt";
			((Control)LClAmt).ForeColor = Color.Blue;
		}
		else if (CustClAmt < 0.0)
		{
			LClAmt.Text = Strings.Format((object)Math.Abs(CustClAmt), "0.00") + " : Dr Amt";
			((Control)LClAmt).ForeColor = Color.Red;
		}
		else
		{
			LClAmt.Text = ": Amt";
		}
		if (CustClGold > 0.0)
		{
			lClGold.Text = Strings.Format((object)CustClGold, "0.000") + " : Cr Gold";
			((Control)lClGold).ForeColor = Color.Blue;
		}
		else if (CustClGold < 0.0)
		{
			lClGold.Text = Strings.Format((object)Math.Abs(CustClGold), "0.000") + " : Dr Gold";
			((Control)lClGold).ForeColor = Color.Red;
		}
		else
		{
			lClGold.Text = ": Gold";
		}
		if (CustClSilver > 0.0)
		{
			LClSilver.Text = Strings.Format((object)CustClSilver, "0.000") + " : Cr Silvr";
			((Control)LClSilver).ForeColor = Color.Blue;
		}
		else if (CustClSilver < 0.0)
		{
			LClSilver.Text = Strings.Format((object)Math.Abs(CustClSilver), "0.000") + " : Dr Silvr";
			((Control)LClSilver).ForeColor = Color.Red;
		}
		else
		{
			LClSilver.Text = ": Silvr";
		}
		mSG2_TOTAL = null;
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 11] = "A";
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
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 1:
				case 3:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 12;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
					break;
				case 2:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 12;
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
			case 0:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 1:
			case 3:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal();
				break;
			case 2:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
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
		int num2 = default(int);
		int digits = default(int);
		int num = default(int);
		int num3 = default(int);
		AxMSFlexGrid val = default(AxMSFlexGrid);
		int digits2 = default(int);
		int num6 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				int num5;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					digits = 0;
					goto IL_0006;
				case 1985:
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
							goto IL_0006;
						case 3:
							goto IL_000b;
						case 4:
							goto IL_0010;
						case 5:
							goto IL_002b;
						case 6:
							goto IL_002f;
						case 7:
							goto IL_0034;
						case 8:
						case 9:
							goto IL_003b;
						case 10:
							goto IL_0045;
						case 11:
							goto IL_0050;
						case 12:
							goto IL_006c;
						case 14:
							goto IL_0076;
						case 15:
							goto IL_0092;
						case 17:
							goto IL_00a0;
						case 13:
						case 16:
						case 18:
						case 19:
							goto IL_00a7;
						case 20:
							goto IL_00f5;
						case 21:
						case 22:
							goto IL_014c;
						case 23:
							goto IL_019a;
						case 25:
							goto IL_01fa;
						case 26:
							goto IL_0225;
						case 24:
						case 27:
						case 28:
						case 29:
							goto IL_025e;
						case 30:
							goto IL_02cf;
						case 31:
							goto IL_031e;
						case 32:
						case 33:
							goto IL_0370;
						case 34:
							goto IL_03cd;
						case 35:
							goto IL_0422;
						case 36:
						case 37:
							goto IL_047a;
						case 38:
							goto IL_04d7;
						case 39:
							goto IL_0526;
						case 40:
						case 41:
							goto IL_0578;
						case 42:
							goto IL_05a7;
						case 43:
							goto IL_05e3;
						case 45:
							goto IL_064e;
						case 46:
							goto IL_068a;
						case 44:
						case 47:
						case 48:
							goto IL_06c9;
						case 49:
							goto IL_06cc;
						case 50:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 51:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_068a:
					num2 = 46;
					val[val.Row, 10] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 8]), 0), "0.00");
					goto IL_06c9;
					IL_06c9:
					val = null;
					goto IL_06cc;
					IL_064e:
					num2 = 45;
					val[val.Row, 8] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 7]), 0), "0.00");
					goto IL_068a;
					IL_06cc:
					num2 = 49;
					MSG_TOT_FILL();
					break;
					IL_0006:
					num2 = 2;
					num5 = 0;
					goto IL_000b;
					IL_000b:
					num2 = 3;
					digits2 = 0;
					goto IL_0010;
					IL_0010:
					num2 = 4;
					if (Operators.CompareString(DC_Main.MsAllRofRemove, "Y", false) == 0)
					{
						goto IL_002b;
					}
					goto IL_003b;
					IL_002b:
					num2 = 5;
					digits = 2;
					goto IL_002f;
					IL_002f:
					num2 = 6;
					num5 = 2;
					goto IL_0034;
					IL_0034:
					num2 = 7;
					digits2 = 2;
					goto IL_003b;
					IL_003b:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_0045;
					IL_0045:
					num2 = 10;
					val = MSG;
					goto IL_0050;
					IL_0050:
					num2 = 11;
					if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
					{
						goto IL_006c;
					}
					goto IL_0076;
					IL_006c:
					num2 = 12;
					num6 = 10;
					goto IL_00a7;
					IL_0076:
					num2 = 14;
					if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
					{
						goto IL_0092;
					}
					goto IL_00a0;
					IL_0092:
					num2 = 15;
					num6 = 1000;
					goto IL_00a7;
					IL_00a0:
					num2 = 17;
					num6 = 1;
					goto IL_00a7;
					IL_00a7:
					num2 = 19;
					if ((Conversion.Val(val[val.Row, 1]) != 0.0) & (Conversion.Val(val[val.Row, 2]) != 0.0))
					{
						goto IL_00f5;
					}
					goto IL_014c;
					IL_00f5:
					num2 = 20;
					val[val.Row, 3] = Strings.Format((object)(Conversion.Val(val[val.Row, 1]) * Conversion.Val(val[val.Row, 2]) / 100.0), "0.000");
					goto IL_014c;
					IL_014c:
					num2 = 22;
					if ((Conversion.Val(val[val.Row, 4]) != 0.0) & (Conversion.Val(val[val.Row, 5]) != 0.0))
					{
						goto IL_019a;
					}
					goto IL_01fa;
					IL_019a:
					num2 = 23;
					val[val.Row, 6] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 4]) / Conversion.Val(val[val.Row, 5]) * 100.0, digits2), "0.00");
					goto IL_025e;
					IL_01fa:
					num2 = 25;
					if (Conversion.Val(val[val.Row, 4]) != 0.0)
					{
						goto IL_0225;
					}
					goto IL_025e;
					IL_0225:
					num2 = 26;
					val[val.Row, 6] = Strings.Format((object)Conversion.Val(val[val.Row, 4]), "0.00");
					goto IL_025e;
					IL_025e:
					num2 = 29;
					if ((Conversion.Val(val[val.Row, 6]) == 0.0) & (Conversion.Val(val[val.Row, 7]) != 0.0) & (Conversion.Val(val[val.Row, 3]) != 0.0))
					{
						goto IL_02cf;
					}
					goto IL_0370;
					IL_02cf:
					num2 = 30;
					val[val.Row, 6] = Strings.Format((object)(Conversion.Val(val[val.Row, 7]) / Conversion.Val(val[val.Row, 3]) * (double)num6), "0.000");
					goto IL_031e;
					IL_031e:
					num2 = 31;
					val[val.Row, 11] = Strings.Format((object)(Conversion.Val(val[val.Row, 7]) / Conversion.Val(val[val.Row, 3]) * (double)num6), "0.000");
					goto IL_0370;
					IL_0370:
					num2 = 33;
					if ((Conversion.Val(val[val.Row, 6]) != 0.0) & (Conversion.Val(val[val.Row, 3]) != Conversion.Val(val[val.Row, 13])))
					{
						goto IL_03cd;
					}
					goto IL_047a;
					IL_03cd:
					num2 = 34;
					val[val.Row, 7] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 3]) * (Conversion.Val(val[val.Row, 6]) / (double)num6), digits), "0.00");
					goto IL_0422;
					IL_0422:
					num2 = 35;
					val[val.Row, 12] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 3]) * (Conversion.Val(val[val.Row, 6]) / (double)num6), digits), "0.00");
					goto IL_047a;
					IL_047a:
					num2 = 37;
					if ((Conversion.Val(val[val.Row, 6]) != 0.0) & (Conversion.Val(val[val.Row, 7]) != Conversion.Val(val[val.Row, 12])))
					{
						goto IL_04d7;
					}
					goto IL_0578;
					IL_04d7:
					num2 = 38;
					val[val.Row, 3] = Strings.Format((object)(Conversion.Val(val[val.Row, 7]) / (Conversion.Val(val[val.Row, 6]) / (double)num6)), "0.000");
					goto IL_0526;
					IL_0526:
					num2 = 39;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 7]) / (Conversion.Val(val[val.Row, 6]) / (double)num6)), "0.000");
					goto IL_0578;
					IL_0578:
					num2 = 41;
					if (Conversion.Val(val[val.Row, 9]) != 0.0)
					{
						goto IL_05a7;
					}
					goto IL_064e;
					IL_05a7:
					num2 = 42;
					val[val.Row, 8] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 7]), 0), "0.00");
					goto IL_05e3;
					IL_05e3:
					num2 = 43;
					val[val.Row, 10] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 8]) / (Conversion.Val(val[val.Row, 9]) + 100.0) * 100.0, 0), "0.00");
					goto IL_06c9;
					end_IL_0001_2:
					break;
				}
				num2 = 50;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1985;
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
		UpDown = false;
		Msgleft = false;
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = mSG.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						mSG[mSG.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					TEXT_ENTRY.Text = "";
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
					mSG.Col = checked(mSG.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				checked
				{
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
				}
			}
			if ((int)keyCode == 38)
			{
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
					mSG.Row = checked(mSG.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
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
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG.Col)
					{
					case 6:
						if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						break;
					case 9:
						mSG[mSG.Row, 9] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
						CommPassTotal();
						if (mSG.Row == mSG.Rows - 1)
						{
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
							if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
							{
								MSG.Col = 1;
							}
							else
							{
								MSG.Col = 3;
							}
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
		mSG = null;
	}

	private void TR_FINE_SL_PR_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0c0b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1a: Expected O, but got Unknown
		//IL_0c3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4e: Expected O, but got Unknown
		//IL_0c73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c78: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c82: Expected O, but got Unknown
		//IL_0cc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd0: Expected O, but got Unknown
		//IL_0cea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf9: Expected O, but got Unknown
		//IL_0d13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d22: Expected O, but got Unknown
		//IL_0d3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4b: Expected O, but got Unknown
		//IL_0d73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d7a: Expected O, but got Unknown
		//IL_0e5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e6a: Expected O, but got Unknown
		//IL_0ef2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f01: Expected O, but got Unknown
		//IL_0f9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa5: Expected O, but got Unknown
		//IL_102f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1034: Unknown result type (might be due to invalid IL or missing references)
		//IL_103e: Expected O, but got Unknown
		//IL_1063: Unknown result type (might be due to invalid IL or missing references)
		//IL_1068: Unknown result type (might be due to invalid IL or missing references)
		//IL_1072: Expected O, but got Unknown
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
				AxMSFlexGrid mSG_IDTL = MSG_IDTL;
				object? obj15 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG_IDTL2 = MSG_IDTL;
				object? obj16 = colorConverter.ConvertFromString("DarkGray");
				mSG_IDTL2.BackColorBkg = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG_IDTL3 = MSG_IDTL;
				object? obj17 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_IDTL3.BackColorFixed = ((obj17 != null) ? ((Color)obj17) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj18 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj19 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj20 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj21 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj22 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj23 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj24 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj25 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG_IDTL4 = MSG_IDTL;
				object? obj26 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL4.BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG_IDTL5 = MSG_IDTL;
				object? obj27 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_IDTL5.BackColorBkg = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG_IDTL6 = MSG_IDTL;
				object? obj28 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_IDTL6.BackColorFixed = ((obj28 != null) ? ((Color)obj28) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj29 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj30 = lblBook;
				object? obj31 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj30).ForeColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj32 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj33 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj34 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj35 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj36 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj37 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj37 != null) ? ((Color)obj37) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj38 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj38 != null) ? ((Color)obj38) : default(Color));
				AxMSFlexGrid mSG_IDTL7 = MSG_IDTL;
				object? obj39 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL7.BackColor = ((obj39 != null) ? ((Color)obj39) : default(Color));
				AxMSFlexGrid mSG_IDTL8 = MSG_IDTL;
				object? obj40 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_IDTL8.BackColorBkg = ((obj40 != null) ? ((Color)obj40) : default(Color));
				AxMSFlexGrid mSG_IDTL9 = MSG_IDTL;
				object? obj41 = colorConverter.ConvertFromString("Cornsilk");
				mSG_IDTL9.BackColorFixed = ((obj41 != null) ? ((Color)obj41) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj42 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_IDTL).AutoSize = false;
				((TextBoxBase)TEXT_ENTRY_2).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_IDTL).Font = new Font(((Control)TEXT_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_IDTL).Font.Style);
				((Control)TEXT_ENTRY_2).Font = new Font(((Control)TEXT_ENTRY_2).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY_2).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_IDTL.Font = new Font("Segoe UI Semibold", (float)num3, MSG_IDTL.Font.Style);
				MSG2_TOTAL.Font = new Font("Segoe UI Semibold", (float)num3, MSG2_TOTAL.Font.Style);
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is CheckBox) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_IDTL", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ORD", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_UPI", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY_2", false) != 0)))
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
						if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue2, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"chkWapp", false))
						{
							NewLateBinding.LateSet(objectValue2, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
						}
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnFirst).Font.Size * (1.0 + num2));
				((BaseStyleControl)BtnFirst).Font = new Font(((BaseStyleControl)BtnFirst).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnFirst).Font.Style);
				((BaseStyleControl)BtnLast).Font = new Font(((BaseStyleControl)BtnLast).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnLast).Font.Style);
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
			cboItemTyp.Items.Add((object)"Gold");
			cboItemTyp.Items.Add((object)"Silver");
			if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
			{
				cboItemTyp.SelectedIndex = 0;
			}
			else
			{
				cboItemTyp.SelectedIndex = 1;
			}
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
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		AcTcsAmt = 0.0;
		OldTcsPrc = 0.0;
		OldValTot = 0.0;
		NewValTot = 0.0;
		BillAdjAmt = 0.0;
		OldNetAmt = 0.0;
		OldTaxPrc = 0.0;
		OldTdsPrc = 0.0;
		OldDiscPrc = 0.0;
		OldDiscAmt = 0.0;
		OldAcCode = "";
		UsUPdate = "N";
		UsDelete = "N";
		AcGstType = "L";
		if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
		{
			CurRatePar = "T";
		}
		else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
		{
			CurRatePar = "K";
		}
		else
		{
			CurRatePar = "G";
		}
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_IDTL).Visible = false;
		((Control)TEXT_ENTRY_2).Visible = false;
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		LOpAmt.Text = ": Amt";
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpGold.Text = ": Gold";
		((Control)LOpGold).ForeColor = Color.Black;
		LOpSilver.Text = ": Silvr";
		((Control)LOpSilver).ForeColor = Color.Black;
		LClAmt.Text = ": Amt";
		((Control)LClAmt).ForeColor = Color.Black;
		lClGold.Text = ": Gold";
		((Control)lClGold).ForeColor = Color.Black;
		LClSilver.Text = ": Silvr";
		((Control)LClSilver).ForeColor = Color.Black;
		if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
		{
			cboItemTyp.SelectedIndex = 0;
		}
		else
		{
			cboItemTyp.SelectedIndex = 1;
		}
		MSG_CLEAR();
		MSG_IDTL_CLEAR();
		MSG2_CLEAR();
		if ((Operators.CompareString(FormBookType, "T", false) == 0) | (Operators.CompareString(DC_Main.MsTaxWithEstmate, "Y", false) == 0))
		{
			DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '" + DC_Main.MsTaxCode + "'";
			DC_Main.RsTax = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.RsTax.Rows.Count > 0)
			{
				TEXT_ENTRY_2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
				MSG2_TOTAL[2, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[2, 2] = Strings.Format((object)num, "0.00");
				MSG2_TOTAL[2, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
			}
		}
		if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
		{
			tEmpCode.Text = DC_Main.MsUserEmpCode;
			tEmpName.Text = DC_Main.MsUserEmpName;
		}
		DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		MSG_IDTL_CLEAR();
		DC_Main.RsQry = "SELECT A.*,B.AC_NAME As RecName,C.AC_MOBILE FROM (CUT_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ";
		RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (RsData.Rows.Count > 0)
			{
				tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_NO"], (object)""));
				CurPrnVch = tVchNo.Text;
				mVchDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DATE"], (object)""));
				mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
				mTime.Text = Strings.Format((object)Conversions.ToDate(RsData.Rows[0]["VCH_TIME"]), "HH:mm:ss");
				tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME,AC_GST_TYPE FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_GST_TYPE"], (object)""));
				}
				OldAcCode = tAcCode.Text;
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["IT_TYPE"], (object)""), (object)"G", false))
				{
					cboItemTyp.SelectedIndex = 0;
				}
				else
				{
					cboItemTyp.SelectedIndex = 1;
				}
				MSG2_TOTAL[0, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00");
				OldNetAmt = Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"])), "0.00"));
				MSG2_TOTAL[1, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_PRC"]), "0.00");
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["DISC_PRC"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["DISC_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				OldDiscPrc = Conversions.ToDouble(Strings.Format((object)num, "0.00"));
				MSG2_TOTAL[1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_AMT"]), "0.00");
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["DISC_AMT"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["DISC_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				OldDiscAmt = Conversions.ToDouble(Strings.Format((object)num2, "0.00"));
				MSG2_TOTAL[2, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TAX_CODE"], (object)""));
				MSG2_TOTAL[2, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"]), "0.00");
				OldTaxPrc = Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"])), "0.00"));
				MSG2_TOTAL[2, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_AMT"]), "0.00");
				MSG2_TOTAL[3, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TCS_CODE"], (object)""));
				MSG2_TOTAL[3, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_PRC"]), "0.000");
				OldTcsPrc = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_PRC"]), "0.000"));
				MSG2_TOTAL[3, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_AMT"]), "0.00");
				MSG2_TOTAL[4, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TDS_CODE"], (object)""));
				MSG2_TOTAL[4, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TDS_PRC"]), "0.000");
				OldTdsPrc = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TDS_PRC"]), "0.000"));
				MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TDS_AMT"]), "0.00");
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[4, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[4, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
				}
				MSG2_TOTAL[5, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ROF_AMT"]), "0.00");
				MSG2_TOTAL[6, 3] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_AMT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TDS_AMT"]))), "0.00");
				MSG2_TOTAL[7, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CHQ_AMT"]), "0.00");
				MSG2_TOTAL[8, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_AMT"]), "0.00");
				MSG2_TOTAL[9, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["KASAR_AMT"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[10, 3] = Strings.Format((object)num3, "0.00");
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["BILL_OS"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL2[11, 3] = Strings.Format((object)num4, "0.00");
				MSG2_TOTAL[7, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[7, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[7, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[7, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[8, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[8, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[8, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[2, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[2, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
				}
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[3, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[3, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
				}
				tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
				DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
				}
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
				MainUser = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MAIN_USER"], (object)""));
				UsUPdate = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_UPDATE"], (object)""));
				UsDelete = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_DELETE"], (object)""));
				if (Operators.CompareString(UsUPdate, "Y", false) == 0)
				{
					((BaseStyleControl)BtnSave).ForeColor = Color.Green;
				}
				if (Operators.CompareString(UsDelete, "Y", false) == 0)
				{
					((BaseStyleControl)BtnDelete).ForeColor = Color.Green;
				}
				DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
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
				if (DC_Main.MsAcGoldOpBal > 0.0)
				{
					LOpGold.Text = Strings.Format((object)DC_Main.MsAcGoldOpBal, "0.000") + " : Cr Gold";
					((Control)LOpGold).ForeColor = Color.Blue;
				}
				else if (DC_Main.MsAcGoldOpBal < 0.0)
				{
					LOpGold.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcGoldOpBal), "0.000") + " : Dr Gold";
					((Control)LOpGold).ForeColor = Color.Red;
				}
				else
				{
					LOpGold.Text = ": Gold";
				}
				if (DC_Main.MsAcSilverOpBal > 0.0)
				{
					LOpSilver.Text = Strings.Format((object)DC_Main.MsAcSilverOpBal, "0.000") + " : Cr Silvr";
					((Control)LOpSilver).ForeColor = Color.Blue;
				}
				else if (DC_Main.MsAcSilverOpBal < 0.0)
				{
					LOpSilver.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcSilverOpBal), "0.000") + " : Dr Silvr";
					((Control)LOpSilver).ForeColor = Color.Red;
				}
				else
				{
					LOpSilver.Text = ": Silvr";
				}
				if (DC_Main.MsAcAmtClBal > 0.0)
				{
					LClAmt.Text = Strings.Format((object)DC_Main.MsAcAmtClBal, "0.00") + " : Cr Amt";
					((Control)LClAmt).ForeColor = Color.Blue;
				}
				else if (DC_Main.MsAcAmtClBal < 0.0)
				{
					LClAmt.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcAmtClBal), "0.00") + " : Dr Amt";
					((Control)LClAmt).ForeColor = Color.Red;
				}
				else
				{
					LClAmt.Text = ": Amt";
				}
				if (DC_Main.MsAcGoldClBal > 0.0)
				{
					lClGold.Text = Strings.Format((object)DC_Main.MsAcGoldClBal, "0.000") + " : Cr Gold";
					((Control)lClGold).ForeColor = Color.Blue;
				}
				else if (DC_Main.MsAcGoldClBal < 0.0)
				{
					lClGold.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcGoldClBal), "0.000") + " : Dr Gold";
					((Control)lClGold).ForeColor = Color.Red;
				}
				else
				{
					lClGold.Text = ": Gold";
				}
				if (DC_Main.MsAcSilverClBal > 0.0)
				{
					LClSilver.Text = Strings.Format((object)DC_Main.MsAcSilverClBal, "0.000") + " : Cr Silvr";
					((Control)LClSilver).ForeColor = Color.Blue;
				}
				else if (DC_Main.MsAcSilverClBal < 0.0)
				{
					LClSilver.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcSilverClBal), "0.000") + " : Dr Silvr";
					((Control)LClSilver).ForeColor = Color.Red;
				}
				else
				{
					LClSilver.Text = ": Silvr";
				}
				CustOpAmt = DC_Main.MsAcAmtOpBal;
				CustClAmt = DC_Main.MsAcAmtClBal;
				CustOpGold = DC_Main.MsAcGoldOpBal;
				CustClGold = DC_Main.MsAcGoldClBal;
				CustOpSilver = DC_Main.MsAcSilverOpBal;
				CustClSilver = DC_Main.MsAcSilverClBal;
				DC_Main.MsAcAmtOpBal = 0.0;
				DC_Main.MsAcGoldOpBal = 0.0;
				DC_Main.MsAcSilverOpBal = 0.0;
				DC_Main.MsAcAmtClBal = 0.0;
				DC_Main.MsAcGoldClBal = 0.0;
				DC_Main.MsAcSilverClBal = 0.0;
				DC_Main.i = 0;
				DC_Main.RsQry = "Select A.* From CUT_DETL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'  Order By Sr_No";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					AxMSFlexGrid mSG = MSG;
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 1] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ITM_NWT"]), "0.000");
					mSG[DC_Main.i + 1, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ITM_TOUCH"]), "0.000");
					if (Operators.CompareString(FormMainBook, "FINE SALE", false) == 0)
					{
						mSG[DC_Main.i + 1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["CR_FINE"]), "0.000");
					}
					else
					{
						mSG[DC_Main.i + 1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["DR_FINE"]), "0.000");
					}
					CurRatePar = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["RATE_PAR"], (object)""));
					mSG[DC_Main.i + 1, 6] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["FINE_RATE"]), "0.00");
					mSG[DC_Main.i + 1, 4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["CONV_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["CONV_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 7] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["TOT_AMT"]), "0.00");
					mSG[DC_Main.i + 1, 8] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["TOT_AMT"]), "0.00");
					mSG[DC_Main.i + 1, 9] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["TAX_PRC"]), "0.00");
					mSG[DC_Main.i + 1, 10] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["NET_AMT"]), "0.00");
					mSG.Rows += 1;
					DC_Main.i++;
					mSG = null;
				}
				DC_Main.i = 0;
				DC_Main.RsQry = "Select A.*,B.IT_NAME,C.BOOK_NAME As SlBook From (CUT_STK_DETL AS A LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.SL_DBCD = C.CO_BOOK) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'  Order By Sr_No";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					AxMSFlexGrid mSG_IDTL = MSG_IDTL;
					mSG_IDTL[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_IDTL[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["SL_NO"], (object)""));
					mSG_IDTL[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["SL_SRNO"], (object)""));
					mSG_IDTL[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG_IDTL[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG_IDTL[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["SlBook"], (object)""));
					mSG_IDTL[DC_Main.i + 1, 6] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ITM_PCS"]), "0");
					mSG_IDTL[DC_Main.i + 1, 7] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ITM_GWT"]), "0.000");
					mSG_IDTL[DC_Main.i + 1, 8] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ITM_NWT"]), "0.000");
					mSG_IDTL[DC_Main.i + 1, 9] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ITM_TOUCH"]), "0.00");
					mSG_IDTL[DC_Main.i + 1, 10] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ITM_WEST_PRC"]), "0.00");
					mSG_IDTL[DC_Main.i + 1, 11] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ITM_FINE"]), "0.000");
					mSG_IDTL[DC_Main.i + 1, 12] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["STK_FINE"]), "0.000");
					mSG_IDTL[DC_Main.i + 1, 13] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["STK_GWT"]), "0.000");
					mSG_IDTL[DC_Main.i + 1, 14] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["STK_NWT"]), "0.000");
					mSG_IDTL[DC_Main.i + 1, 15] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["STK_PCS"]), "0");
					mSG_IDTL[DC_Main.i + 1, 30] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["STK_ITM_RATE"]), "0.00");
					mSG_IDTL[DC_Main.i + 1, 29] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["STK_ITM_AMT"]), "0.00");
					mSG_IDTL[DC_Main.i + 1, 16] = Strings.Format(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["STK_NET_AMT"]), "0.00");
					mSG_IDTL[DC_Main.i + 1, 28] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["SL_DATE"], (object)""));
					mSG_IDTL[DC_Main.i + 1, 17] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["SL_YRCD"], (object)""));
					mSG_IDTL[DC_Main.i + 1, 18] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["SL_DBCD"], (object)""));
					mSG_IDTL[DC_Main.i + 1, 22] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["LOT_TYPE"], (object)""));
					mSG_IDTL[DC_Main.i + 1, 24] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG_IDTL[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG_IDTL[DC_Main.i + 1, 26] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG_IDTL[DC_Main.i + 1, 27] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG_IDTL[DC_Main.i + 1, 20] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					mSG_IDTL[DC_Main.i + 1, 21] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG_IDTL[DC_Main.i + 1, 23] = Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["VCH_SRNO"], (object)"")));
					mSG_IDTL[DC_Main.i + 1, 27] = Conversions.ToString(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG_IDTL.Rows += 1;
					DC_Main.i++;
					mSG_IDTL = null;
				}
				if (MSG_IDTL.Rows > 2)
				{
					MSG_IDTL.Rows -= 1;
				}
				MSG_TOT_FILL();
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				OldValTot = Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 9]);
				NewValTot = Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 9]);
				EntryMode = "E";
				CommPassTotal_Idtl(1);
				MsVchSrno = "";
				((TextBoxBase)tVchNo).ReadOnly = true;
				((Control)mVchDate).Focus();
			}
			else
			{
				((Control)mVchDate).Focus();
				EntryMode = "A";
			}
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void TR_FINE_SL_PR_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_FINE_SL_PR_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if ((Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save This Voucher Becouse This Company Type is B......", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
		{
			Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
			((Control)tEmpCode).Focus();
			return;
		}
		((Control)BtnSave).Enabled = false;
		if ((DateTime.Compare(Conversions.ToDate(DC_Main.MCo_OpDate), Conversions.ToDate(mVchDate.Text)) > 0) | (DateTime.Compare(Conversions.ToDate(DC_Main.MCo_ClDate), Conversions.ToDate(mVchDate.Text)) < 0))
		{
			Interaction.MsgBox((object)"You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0)))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (Operators.CompareString(tVchNo.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Insert VchNo and try", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		MSG_TOT_FILL();
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		if (Operators.CompareString(EntryMode, "E", false) == 0)
		{
			if (Operators.CompareString(FormMainBook, "FINE PURC", false) == 0)
			{
				DC_Main.RsQry = "UPDATE PR_DETL SET PR_DETL.FINE_CUT_FINE = PR_DETL.FINE_CUT_FINE-B.STK_FINE ,PR_DETL.FINE_CUT_NWT = PR_DETL.FINE_CUT_NWT -B.STK_NWT,PR_DETL.FINE_CUT_GWT = PR_DETL.FINE_CUT_GWT-B.STK_GWT ,PR_DETL.FINE_CUT_PCS = PR_DETL.FINE_CUT_PCS-B.STK_PCS FROM PR_DETL,CUT_STK_DETL AS B WHERE PR_DETL.CO_CODE = B.CO_CODE AND PR_DETL.LC_CODE = B.LC_CODE AND PR_DETL.CO_YEAR = B.SL_YRCD AND PR_DETL.CO_BOOK = B.SL_DBCD AND PR_DETL.VCH_NO = B.SL_NO AND PR_DETL.OLD_SRNO = B.SL_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.RsQry = "UPDATE RATE_CUT_ISU SET RATE_CUT_ISU.FINE_CUT_FINE = RATE_CUT_ISU.FINE_CUT_FINE-B.STK_FINE ,RATE_CUT_ISU.FINE_CUT_NWT = RATE_CUT_ISU.FINE_CUT_NWT -B.STK_NWT,RATE_CUT_ISU.FINE_CUT_GWT = RATE_CUT_ISU.FINE_CUT_GWT-B.STK_GWT ,RATE_CUT_ISU.FINE_CUT_PCS = RATE_CUT_ISU.FINE_CUT_PCS-B.STK_PCS FROM RATE_CUT_ISU,CUT_STK_DETL AS B WHERE RATE_CUT_ISU.CO_CODE = B.CO_CODE AND RATE_CUT_ISU.LC_CODE = B.LC_CODE AND RATE_CUT_ISU.CO_YEAR = B.SL_YRCD AND RATE_CUT_ISU.CO_BOOK = B.SL_DBCD AND RATE_CUT_ISU.VCH_NO = B.SL_NO AND RATE_CUT_ISU.OLD_SRNO = B.SL_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
		}
		DC_Main.ExeQuteDc("DELETE FROM CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM CUT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM CUT_STK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		if (Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 3]) + Conversion.Val(MSG_TOT[0, 7]) != 0.0)
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
			DC_Main.RsQry = "SELECT * FROM CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow2 = RsData.NewRow();
			AxMSFlexGrid mSG = MSG;
			dataRow2["CO_CODE"] = DC_Main.MCo_code;
			dataRow2["LC_CODE"] = DC_Main.MLc_code;
			dataRow2["CO_YEAR"] = DC_Main.MCo_year;
			dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
			dataRow2["VCH_NO"] = tVchNo.Text;
			dataRow2["AC_CODE"] = tAcCode.Text;
			dataRow2["VCH_DATE"] = mVchDate.Text;
			dataRow2["AC_CODE"] = tAcCode.Text;
			dataRow2["AC_NAME"] = tAcName.Text;
			dataRow2["NET_AMT"] = Conversion.Val(MSG2_TOTAL[0, 3]);
			dataRow2["DISC_PRC"] = Conversion.Val(MSG2_TOTAL[1, 2]);
			dataRow2["DISC_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
			dataRow2["TAX_CODE"] = MSG2_TOTAL[2, 4];
			dataRow2["TAX_PRC"] = Conversion.Val(MSG2_TOTAL[2, 2]);
			dataRow2["TAX_AMT"] = Conversion.Val(MSG2_TOTAL[2, 3]);
			dataRow2["TCS_CODE"] = MSG2_TOTAL[3, 4];
			dataRow2["TCS_PRC"] = Conversion.Val(MSG2_TOTAL[3, 2]);
			dataRow2["TCS_AMT"] = Conversion.Val(MSG2_TOTAL[3, 3]);
			dataRow2["TDS_CODE"] = MSG2_TOTAL[4, 4];
			dataRow2["TDS_PRC"] = Conversion.Val(MSG2_TOTAL[4, 2]);
			dataRow2["TDS_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
			dataRow2["ROF_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
			dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]) + Conversion.Val(MSG2_TOTAL[4, 3]);
			dataRow2["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
			dataRow2["CARD_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);
			dataRow2["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);
			dataRow2["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[10, 3]);
			dataRow2["BILL_OS"] = Conversion.Val(MSG2_TOTAL[11, 3]);
			dataRow2["CARD_AC"] = MSG2_TOTAL[8, 4];
			dataRow2["BANK_AC"] = MSG2_TOTAL[7, 4];
			dataRow2["CHQ_NO"] = MSG2_TOTAL[7, 2];
			dataRow2["AC_GST_TYPE"] = AcGstType;
			if (Conversion.Val(MSG2_TOTAL[2, 3]) != 0.0)
			{
				if (Operators.CompareString(AcGstType, "I", false) == 0)
				{
					dataRow2["IGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]);
					dataRow2["SGST_TAX"] = 0;
					dataRow2["CGST_TAX"] = 0;
				}
				else
				{
					dataRow2["IGST_TAX"] = 0;
					dataRow2["SGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]) / 2.0;
					dataRow2["CGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]) / 2.0;
				}
			}
			else
			{
				dataRow2["IGST_TAX"] = 0;
				dataRow2["SGST_TAX"] = 0;
				dataRow2["CGST_TAX"] = 0;
			}
			dataRow2["IT_TYPE"] = Strings.Mid(cboItemTyp.Text, 1, 1);
			dataRow2["EMP_CODE"] = tEmpCode.Text;
			dataRow2["VCH_DESC"] = tVchDesc.Text;
			dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
			dataRow2["DATA_TRFR"] = "N";
			dataRow2["MAIN_USER"] = MainUser;
			dataRow2["USER_UPDATE"] = "N";
			dataRow2["USER_DELETE"] = "N";
			RsData.Rows.Add(dataRow2);
			((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
			RsData.Clear();
			mSG = null;
		}
		DC_Main.RsQry = "SELECT * FROM CUT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
		RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow3 = RsDetl.NewRow();
		checked
		{
			int num = MSG.Rows - 1;
			for (int i = 0; i <= num; i++)
			{
				AxMSFlexGrid mSG2 = MSG;
				if ((Conversion.Val(mSG2[i, 3]) != 0.0) & (Conversion.Val(mSG2[i, 10]) != 0.0))
				{
					dataRow3["CO_CODE"] = DC_Main.MCo_code;
					dataRow3["LC_CODE"] = DC_Main.MLc_code;
					dataRow3["CO_YEAR"] = DC_Main.MCo_year;
					dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow3["VCH_NO"] = tVchNo.Text;
					dataRow3["SR_NO"] = Conversion.Val(mSG2[i, 0]);
					dataRow3["OLD_SRNO"] = Conversion.Val(mSG2[i, 0]);
					dataRow3["VCH_DATE"] = mVchDate.Text;
					dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow3["VCH_TYPE"] = FormBookSname;
					dataRow3["INOUT_TYPE"] = FormBookInOut;
					dataRow3["ENTRY_TYPE"] = "O";
					dataRow3["BOOK_NAME"] = FormMainBook;
					dataRow3["AC_CODE"] = tAcCode.Text;
					dataRow3["IT_TYPE"] = Strings.Mid(cboItemTyp.Text, 1, 1);
					dataRow3["ITM_NWT"] = Conversion.Val(mSG2[i, 1]);
					dataRow3["ITM_TOUCH"] = Conversion.Val(mSG2[i, 2]);
					if (Operators.CompareString(FormMainBook, "FINE PURC", false) == 0)
					{
						dataRow3["DR_AMT"] = 0;
						dataRow3["CR_FINE"] = 0;
						dataRow3["CR_AMT"] = Conversion.Val(mSG2[i, 10]);
						dataRow3["DR_FINE"] = Conversion.Val(mSG2[i, 3]);
					}
					else
					{
						dataRow3["DR_AMT"] = Conversion.Val(mSG2[i, 10]);
						dataRow3["CR_FINE"] = Conversion.Val(mSG2[i, 3]);
						dataRow3["CR_AMT"] = 0;
						dataRow3["DR_FINE"] = 0;
					}
					dataRow3["CONV_RATE"] = Conversion.Val(mSG2[i, 4]);
					dataRow3["CONV_PRC"] = Conversion.Val(mSG2[i, 5]);
					dataRow3["RATE_PAR"] = CurRatePar;
					dataRow3["FINE_RATE"] = Conversion.Val(mSG2[i, 6]);
					dataRow3["TOT_AMT"] = Conversion.Val(mSG2[i, 8]);
					dataRow3["TAX_PRC"] = Conversion.Val(mSG2[i, 9]);
					dataRow3["NET_AMT"] = Conversion.Val(mSG2[i, 10]);
					dataRow3["MAIN_USER"] = MainUser;
					RsDetl.Rows.Add(dataRow3);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
					RsDetl.Clear();
				}
				mSG2 = null;
			}
			DC_Main.RsQry = "SELECT * FROM CUT_STK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow4 = RsIdtl.NewRow();
			int num2 = MSG_IDTL.Rows - 1;
			for (int j = 0; j <= num2; j++)
			{
				AxMSFlexGrid mSG_IDTL = MSG_IDTL;
				if ((Operators.CompareString(mSG_IDTL[j, 4], "", false) != 0) & (Conversion.Val(mSG_IDTL[j, 12]) + Conversion.Val(mSG_IDTL[j, 8]) != 0.0))
				{
					dataRow4["CO_CODE"] = DC_Main.MCo_code;
					dataRow4["LC_CODE"] = DC_Main.MLc_code;
					dataRow4["CO_YEAR"] = DC_Main.MCo_year;
					dataRow4["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow4["VCH_NO"] = tVchNo.Text;
					dataRow4["SR_NO"] = Conversion.Val(mSG_IDTL[j, 0]);
					dataRow4["OLD_SRNO"] = Conversion.Val(mSG_IDTL[j, 0]);
					dataRow4["VCH_DATE"] = mVchDate.Text;
					dataRow4["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow4["VCH_TYPE"] = FormBookSname;
					dataRow4["INOUT_TYPE"] = FormBookInOut;
					dataRow4["ENTRY_TYPE"] = "O";
					dataRow4["BOOK_NAME"] = FormMainBook;
					dataRow4["AC_CODE"] = tAcCode.Text;
					dataRow4["SL_NO"] = mSG_IDTL[j, 1];
					dataRow4["SL_SRNO"] = Conversion.Val(mSG_IDTL[j, 3]);
					dataRow4["IT_CODE"] = mSG_IDTL[j, 4];
					dataRow4["ITM_PCS"] = Conversion.Val(mSG_IDTL[j, 6]);
					dataRow4["ITM_GWT"] = Conversion.Val(mSG_IDTL[j, 7]);
					dataRow4["ITM_OTH_WT"] = Strings.Format((object)(Conversion.Val(mSG_IDTL[j, 7]) - Conversion.Val(mSG_IDTL[j, 8])), "0.000");
					dataRow4["ITM_NWT"] = Conversion.Val(mSG_IDTL[j, 8]);
					dataRow4["ITM_GHT_WT"] = 0;
					dataRow4["ITM_TOUCH"] = Conversion.Val(mSG_IDTL[j, 9]);
					dataRow4["ITM_WEST_PRC"] = Conversion.Val(mSG_IDTL[j, 10]);
					dataRow4["ITM_FINE"] = Conversion.Val(mSG_IDTL[j, 11]);
					dataRow4["STK_FINE"] = Conversion.Val(mSG_IDTL[j, 12]);
					dataRow4["STK_GWT"] = Conversion.Val(mSG_IDTL[j, 13]);
					dataRow4["STK_NWT"] = Conversion.Val(mSG_IDTL[j, 14]);
					dataRow4["STK_PCS"] = Conversion.Val(mSG_IDTL[j, 15]);
					dataRow4["STK_ITM_RATE"] = Conversion.Val(mSG_IDTL[j, 30]);
					dataRow4["STK_ITM_AMT"] = Conversion.Val(mSG_IDTL[j, 29]);
					dataRow4["STK_NET_AMT"] = Conversion.Val(mSG_IDTL[j, 16]);
					dataRow4["SL_DATE"] = mSG_IDTL[j, 28];
					dataRow4["SL_LC_CODE"] = DC_Main.MLc_code;
					dataRow4["SL_YRCD"] = mSG_IDTL[j, 17];
					dataRow4["SL_DBCD"] = mSG_IDTL[j, 18];
					dataRow4["STK_IT_CODE"] = mSG_IDTL[j, 4];
					dataRow4["LOT_TYPE"] = mSG_IDTL[j, 22];
					dataRow4["HM_ID"] = mSG_IDTL[j, 24];
					dataRow4["HM_ID2"] = mSG_IDTL[j, 25];
					dataRow4["HM_ID3"] = mSG_IDTL[j, 26];
					dataRow4["HM_ID4"] = mSG_IDTL[j, 27];
					dataRow4["HM_ID_WT"] = 0;
					dataRow4["HM_ID2_WT"] = 0;
					dataRow4["HM_ID3_WT"] = 0;
					dataRow4["HM_ID4_WT"] = 0;
					dataRow4["TAG_NO"] = mSG_IDTL[j, 20];
					dataRow4["LOT_NO"] = "";
					dataRow4["DESIGN_NO"] = mSG_IDTL[j, 21];
					dataRow4["TBL_CODE"] = "";
					dataRow4["ITM_SIZE"] = "";
					dataRow4["VCH_SRNO"] = Conversion.Val(mSG_IDTL[j, 23]);
					dataRow4["MAIN_USER"] = MainUser;
					dataRow4["DATA_TRFR"] = "N";
					RsIdtl.Rows.Add(dataRow4);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
					RsIdtl.Clear();
				}
				mSG_IDTL = null;
			}
			if (Operators.CompareString(FormMainBook, "FINE PURC", false) == 0)
			{
				DC_Main.RsQry = "UPDATE PR_DETL SET PR_DETL.FINE_CUT_FINE = PR_DETL.FINE_CUT_FINE+B.STK_FINE ,PR_DETL.FINE_CUT_NWT = PR_DETL.FINE_CUT_NWT +B.STK_NWT,PR_DETL.FINE_CUT_GWT = PR_DETL.FINE_CUT_GWT+B.STK_GWT ,PR_DETL.FINE_CUT_PCS = PR_DETL.FINE_CUT_PCS+B.STK_PCS FROM PR_DETL,CUT_STK_DETL AS B WHERE PR_DETL.CO_CODE = B.CO_CODE AND PR_DETL.LC_CODE = B.LC_CODE AND PR_DETL.CO_YEAR = B.SL_YRCD AND PR_DETL.CO_BOOK = B.SL_DBCD AND PR_DETL.VCH_NO = B.SL_NO AND PR_DETL.OLD_SRNO = B.SL_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "SELECT * FROM CUT_STK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
				DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < dataTable2.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE MAIN_STOCK SET MAIN_STOCK.ITM_PCS = B.ITM_PCS-B.FINE_CUT_PCS,MAIN_STOCK.ITM_GWT = B.ITM_GWT-B.FINE_CUT_GWT,MAIN_STOCK.ITM_NWT = B.ITM_NWT-B.FINE_CUT_NWT,MAIN_STOCK.ITM_FINE = B.ITM_FINE-B.FINE_CUT_FINE FROM MAIN_STOCK,PR_DETL AS B  WHERE MAIN_STOCK.CO_CODE = B.CO_CODE AND MAIN_STOCK.LC_CODE = B.LC_CODE AND MAIN_STOCK.CO_YEAR = B.CO_YEAR AND MAIN_STOCK.CO_BOOK = B.CO_BOOK AND MAIN_STOCK.VCH_NO = B.VCH_NO AND MAIN_STOCK.SR_NO = B.OLD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '"), dataTable2.Rows[DC_Main.i]["SL_YRCD"]), (object)"' AND B.CO_BOOK = '"), dataTable2.Rows[DC_Main.i]["SL_DBCD"]), (object)"' AND B.VCH_NO = '"), dataTable2.Rows[DC_Main.i]["SL_NO"]), (object)"' AND B.OLD_SRNO = "), dataTable2.Rows[DC_Main.i]["SR_NO"]), (object)""));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.i++;
				}
			}
			else
			{
				DC_Main.RsQry = "UPDATE RATE_CUT_ISU SET RATE_CUT_ISU.FINE_CUT_FINE = RATE_CUT_ISU.FINE_CUT_FINE+B.STK_FINE ,RATE_CUT_ISU.FINE_CUT_NWT = RATE_CUT_ISU.FINE_CUT_NWT +B.STK_NWT,RATE_CUT_ISU.FINE_CUT_GWT = RATE_CUT_ISU.FINE_CUT_GWT+B.STK_GWT ,RATE_CUT_ISU.FINE_CUT_PCS = RATE_CUT_ISU.FINE_CUT_PCS+B.STK_PCS FROM RATE_CUT_ISU,CUT_STK_DETL AS B WHERE RATE_CUT_ISU.CO_CODE = B.CO_CODE AND RATE_CUT_ISU.LC_CODE = B.LC_CODE AND RATE_CUT_ISU.CO_YEAR = B.SL_YRCD AND RATE_CUT_ISU.CO_BOOK = B.SL_DBCD AND RATE_CUT_ISU.VCH_NO = B.SL_NO AND RATE_CUT_ISU.OLD_SRNO = B.SL_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "SELECT * FROM CUT_STK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
				DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < dataTable2.Rows.Count)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE MAIN_STOCK SET MAIN_STOCK.ITM_PCS = B.ITM_PCS-B.FINE_CUT_PCS,MAIN_STOCK.ITM_GWT = B.ITM_GWT-B.FINE_CUT_GWT,MAIN_STOCK.ITM_NWT = B.ITM_NWT-B.FINE_CUT_NWT,MAIN_STOCK.ITM_FINE = B.ITM_FINE-B.FINE_CUT_FINE FROM MAIN_STOCK,RATE_CUT_ISU AS B  WHERE MAIN_STOCK.CO_CODE = B.CO_CODE AND MAIN_STOCK.LC_CODE = B.LC_CODE AND MAIN_STOCK.CO_YEAR = B.CO_YEAR AND MAIN_STOCK.CO_BOOK = B.CO_BOOK AND MAIN_STOCK.VCH_NO = B.VCH_NO AND MAIN_STOCK.SR_NO = B.OLD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '"), dataTable2.Rows[DC_Main.i]["SL_YRCD"]), (object)"' AND B.CO_BOOK = '"), dataTable2.Rows[DC_Main.i]["SL_DBCD"]), (object)"' AND B.VCH_NO = '"), dataTable2.Rows[DC_Main.i]["SL_NO"]), (object)"' AND B.OLD_SRNO = "), dataTable2.Rows[DC_Main.i]["SR_NO"]), (object)""));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.i++;
				}
			}
			DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Ledr.Fine_CUT_Ledr(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Rojmel.Fine_CUT_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Tax.Fine_Cut_GST(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Stock.Fine_CUT_Stk(DC_Main.MCo_Book, tVchNo.Text);
			Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
			if (Operators.CompareString(FormVchNo, "", false) != 0)
			{
				CLEAR_DATA();
				((Form)this).Close();
				return;
			}
			CurPrnVch = tVchNo.Text;
			DC_Main.MsAcBal(PartyAcCode, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
			CustOpAmt = DC_Main.MsAcAmtOpBal;
			CustClAmt = DC_Main.MsAcAmtClBal;
			CustOpGold = DC_Main.MsAcGoldOpBal;
			CustClGold = DC_Main.MsAcGoldClBal;
			CustOpSilver = DC_Main.MsAcSilverOpBal;
			CustClSilver = DC_Main.MsAcSilverClBal;
			CLEAR_DATA();
			BtnPrint_Click(BtnPrint, new EventArgs());
			CurPrnVch = "";
			DC_Main.MsAcAmtOpBal = 0.0;
			DC_Main.MsAcAmtClBal = 0.0;
			DC_Main.MsAcGoldOpBal = 0.0;
			DC_Main.MsAcGoldClBal = 0.0;
			DC_Main.MsAcSilverOpBal = 0.0;
			DC_Main.MsAcSilverClBal = 0.0;
			CustOpAmt = 0.0;
			CustClAmt = 0.0;
			CustOpGold = 0.0;
			CustClGold = 0.0;
			CustOpSilver = 0.0;
			CustClSilver = 0.0;
		}
	}

	private async void WappReport(string CustMo, string CustMsg)
	{
		try
		{
			if (Operators.CompareString(((ButtonBase)MyProject.Forms.MDI_FORM.chkWappId).Text, "Whatsapp Open", false) != 0)
			{
				MessageRequest val = new MessageRequest();
				val.Phone = DC_Main.MsCountryId + CustMo;
				val.Message = CustMsg;
				val.AttachmentPath = "";
				MessageRequest request = val;
				object objectValue = RuntimeHelpers.GetObjectValue(await whatsApp.Send(request));
				MessageBox.Show(Conversions.ToString(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, (Type)null, "Status", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Description", new object[0], (string[])null, (Type[])null, (bool[])null))));
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			MessageBox.Show(ex3.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_088b: Unknown result type (might be due to invalid IL or missing references)
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(UsDelete, "Y", false) != 0 && Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else
		{
			if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
			{
				return;
			}
			checked
			{
				if (Operators.CompareString(FormMainBook, "FINE PURC", false) == 0)
				{
					DC_Main.RsQry = "UPDATE PR_DETL SET PR_DETL.FINE_CUT_FINE = PR_DETL.FINE_CUT_FINE-B.STK_FINE ,PR_DETL.FINE_CUT_NWT = PR_DETL.FINE_CUT_NWT -B.STK_NWT,PR_DETL.FINE_CUT_GWT = PR_DETL.FINE_CUT_GWT-B.STK_GWT ,PR_DETL.FINE_CUT_PCS = PR_DETL.FINE_CUT_PCS-B.STK_PCS FROM PR_DETL,CUT_STK_DETL AS B WHERE PR_DETL.CO_CODE = B.CO_CODE AND PR_DETL.LC_CODE = B.LC_CODE AND PR_DETL.CO_YEAR = B.SL_YRCD AND PR_DETL.CO_BOOK = B.SL_DBCD AND PR_DETL.VCH_NO = B.SL_NO AND PR_DETL.OLD_SRNO = B.SL_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = "SELECT * FROM CUT_STK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.i = 0;
					while (DC_Main.i < dataTable.Rows.Count)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE MAIN_STOCK SET MAIN_STOCK.ITM_PCS = B.ITM_PCS-B.FINE_CUT_PCS,MAIN_STOCK.ITM_GWT = B.ITM_GWT-B.FINE_CUT_GWT,MAIN_STOCK.ITM_NWT = B.ITM_NWT-B.FINE_CUT_NWT,MAIN_STOCK.ITM_FINE = B.ITM_FINE-B.FINE_CUT_FINE FROM MAIN_STOCK,PR_DETL AS B  WHERE MAIN_STOCK.CO_CODE = B.CO_CODE AND MAIN_STOCK.LC_CODE = B.LC_CODE AND MAIN_STOCK.CO_YEAR = B.CO_YEAR AND MAIN_STOCK.CO_BOOK = B.CO_BOOK AND MAIN_STOCK.VCH_NO = B.VCH_NO AND MAIN_STOCK.SR_NO = B.OLD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '"), dataTable.Rows[DC_Main.i]["SL_YRCD"]), (object)"' AND B.CO_BOOK = '"), dataTable.Rows[DC_Main.i]["SL_DBCD"]), (object)"' AND B.VCH_NO = '"), dataTable.Rows[DC_Main.i]["SL_NO"]), (object)"' AND B.OLD_SRNO = "), dataTable.Rows[DC_Main.i]["SR_NO"]), (object)""));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.i++;
					}
				}
				else
				{
					DC_Main.RsQry = "UPDATE RATE_CUT_ISU SET RATE_CUT_ISU.FINE_CUT_FINE = RATE_CUT_ISU.FINE_CUT_FINE-B.STK_FINE ,RATE_CUT_ISU.FINE_CUT_NWT = RATE_CUT_ISU.FINE_CUT_NWT -B.STK_NWT,RATE_CUT_ISU.FINE_CUT_GWT = RATE_CUT_ISU.FINE_CUT_GWT-B.STK_GWT ,RATE_CUT_ISU.FINE_CUT_PCS = RATE_CUT_ISU.FINE_CUT_PCS-B.STK_PCS FROM RATE_CUT_ISU,CUT_STK_DETL AS B WHERE RATE_CUT_ISU.CO_CODE = B.CO_CODE AND RATE_CUT_ISU.LC_CODE = B.LC_CODE AND RATE_CUT_ISU.CO_YEAR = B.SL_YRCD AND RATE_CUT_ISU.CO_BOOK = B.SL_DBCD AND RATE_CUT_ISU.VCH_NO = B.SL_NO AND RATE_CUT_ISU.OLD_SRNO = B.SL_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = "SELECT * FROM CUT_STK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.i = 0;
					while (DC_Main.i < dataTable.Rows.Count)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE MAIN_STOCK SET MAIN_STOCK.ITM_PCS = B.ITM_PCS+B.FINE_CUT_PCS,MAIN_STOCK.ITM_GWT = B.ITM_GWT+B.FINE_CUT_GWT,MAIN_STOCK.ITM_NWT = B.ITM_NWT+B.FINE_CUT_NWT,MAIN_STOCK.ITM_FINE = B.ITM_FINE+B.FINE_CUT_FINE FROM MAIN_STOCK,RATE_CUT_ISU AS B  WHERE MAIN_STOCK.CO_CODE = B.CO_CODE AND MAIN_STOCK.LC_CODE = B.LC_CODE AND MAIN_STOCK.CO_YEAR = B.CO_YEAR AND MAIN_STOCK.CO_BOOK = B.CO_BOOK AND MAIN_STOCK.VCH_NO = B.VCH_NO AND MAIN_STOCK.SR_NO = B.OLD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '"), dataTable.Rows[DC_Main.i]["SL_YRCD"]), (object)"' AND B.CO_BOOK = '"), dataTable.Rows[DC_Main.i]["SL_DBCD"]), (object)"' AND B.VCH_NO = '"), dataTable.Rows[DC_Main.i]["SL_NO"]), (object)"' AND B.OLD_SRNO = "), dataTable.Rows[DC_Main.i]["SR_NO"]), (object)""));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.i++;
					}
				}
				DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
				DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
				DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.ExeQuteDc("DELETE FROM CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM CUT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM CUT_STK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				CLEAR_DATA();
			}
		}
	}

	private void TR_FINE_SL_PR_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			if (((Control)TEXT_ENTRY).Visible)
			{
				MSG_LeaveCell(MSG, new EventArgs());
				MSG.Row = checked(MSG.Rows - 1);
				MSG.Col = 1;
				((Control)TEXT_ENTRY).Visible = false;
				MSG_IDTL.Row = 1;
				MSG_IDTL.Col = 1;
				MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
				((Control)TEXT_IDTL).Focus();
				((TextBoxBase)TEXT_IDTL).SelectAll();
			}
			else if (((Control)TEXT_IDTL).Visible)
			{
				MSG_IDTL_LeaveCell(MSG_IDTL, new EventArgs());
				MSG_IDTL.Col = 20;
				((Control)TEXT_IDTL).Visible = false;
				MSG2_TOTAL.Row = 1;
				MSG2_TOTAL.Col = 3;
				MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
				((Control)TEXT_ENTRY_2).Focus();
			}
			else if (((Control)TEXT_ENTRY_2).Visible)
			{
				MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
				((Control)TEXT_ENTRY_2).Visible = false;
				((Control)tEmpCode).Focus();
			}
			else if (OldValTot == NewValTot)
			{
				((Form)this).Close();
			}
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(DC_Main.MsSlDupPrint, "Y", false) == 0)
		{
			DC_Main.MsDupPrintStatus = true;
		}
		((Form)MyProject.Forms.MS_PRINT).ShowDialog();
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
		{
			return;
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			string rptName = "FineSalesGstBill";
			DC_Main.MsWappOpAmt = Conversions.ToDouble(Strings.Format((object)CustOpAmt, "0.00"));
			DC_Main.MsWappClAmt = Conversions.ToDouble(Strings.Format((object)CustClAmt, "0.00"));
			DC_Main.MsWappOpGlFine = Conversions.ToDouble(Strings.Format((object)CustOpGold, "0.000"));
			DC_Main.MsWappClGlFine = Conversions.ToDouble(Strings.Format((object)CustClGold, "0.000"));
			DC_Main.MsWappOpSlFine = Conversions.ToDouble(Strings.Format((object)CustOpSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00"))));
			DC_Main.MsWappClSlFine = Conversions.ToDouble(Strings.Format((object)CustClSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00"))));
			DC_Main.MsWappPrintType = "WhSale";
			DC_Main.RptName = rptName;
			DC_Main.RptFormula = "{CUT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {CUT_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {CUT_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {CUT_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {CUT_DATA.VCH_NO} = '" + CurPrnVch + "'";
			if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
			{
				if (DC_Main.MsPrintDup)
				{
					DC_Main.MsPrintType = "InVoiceType";
					DC_Main.MaPirntCopy = "'CUSTOMER COPY'";
					Module_Save.PrintReportDirect();
					Application.DoEvents();
				}
				if (DC_Main.MsPrintOg)
				{
					DC_Main.MsPrintType = "InVoiceType";
					DC_Main.MaPirntCopy = "'ACCOUNT COPY'";
					Module_Save.PrintReportDirect();
					Application.DoEvents();
				}
				return;
			}
			if (DC_Main.MsPrintDup)
			{
				DC_Main.MsPrintType = "InVoiceType";
				DC_Main.MaPirntCopy = "'CUSTOMER COPY'";
				UT_REPORT uT_REPORT = new UT_REPORT();
				((Control)uT_REPORT).Show();
				((Control)uT_REPORT).Focus();
			}
			if (DC_Main.MsPrintOg)
			{
				DC_Main.MsPrintType = "InVoiceType";
				DC_Main.MaPirntCopy = "'ACCOUNT COPY'";
				UT_REPORT uT_REPORT2 = new UT_REPORT();
				((Control)uT_REPORT2).Show();
				((Control)uT_REPORT2).Focus();
			}
			return;
		}
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr[(short)5] = "";
		Cr[(short)6] = "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\FineSalesGstBill.RPT";
		Cr.SelectionFormula = "{CUT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {CUT_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {CUT_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {CUT_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {CUT_DATA.VCH_NO} = '" + CurPrnVch + "'";
		Cr[(short)2] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
		Cr[(short)3] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
		Cr[(short)4] = ("OpGold = " + Strings.Format((object)CustOpGold, "0.000")) ?? "";
		Cr[(short)5] = ("ClGold = " + Strings.Format((object)CustClGold, "0.000")) ?? "";
		Cr[(short)6] = ("OpSilver = " + Strings.Format((object)CustOpSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00")))) ?? "";
		Cr[(short)7] = ("ClSilver = " + Strings.Format((object)CustClSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00")))) ?? "";
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
		CustOpGold = 0.0;
		CustClGold = 0.0;
		CustOpSilver = 0.0;
		CustClSilver = 0.0;
		CLEAR_DATA();
	}

	private void TR_FINE_SL_PR_Activated(object sender, EventArgs e)
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
			MSG[MSG.Row, 6] = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,B.AC_ADD1 As AddressL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL,A.TOT_AMT As TotAmtR FROM CUT_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[8];
		DC_Main.ColWidth[0] = 80.0;
		DC_Main.ColWidth[1] = 110.0;
		DC_Main.ColWidth[2] = 250.0;
		DC_Main.ColWidth[3] = 220.0;
		DC_Main.ColWidth[4] = 210.0;
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
		}
	}

	private void tVchNo_DoubleClick(object sender, EventArgs e)
	{
		((TextBoxBase)tVchNo).ReadOnly = false;
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
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		if (((int)e.KeyCode == 112) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			DC_Main.MsReqBook = DC_Main.MCo_Book;
			DC_Main.MsReqVch = tVchNo.Text;
			DC_Main.MsReqUser = DC_Main.MCo_User;
			DC_Main.MsReqAc = tAcCode.Text;
			((Form)MyProject.Forms.UT_USER_REQUEST).ShowDialog();
		}
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mVchDate;
			DC_Main.SetDate(ref MsDate);
			mVchDate = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{tab}");
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
				DC_Main.RsQry = "SELECT VCH_NO FROM CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_FINE_SL_PR_Closed(object sender, EventArgs e)
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

	private void lblBook_DoubleClick(object sender, EventArgs e)
	{
		((Control)tHdVchNo).Visible = true;
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR <> '15' ORDER BY A.LC_CODE,A.AC_NAME";
			}
			else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR <> '15' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
			}
			else
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR <> '15' ORDER BY A.AC_NAME";
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
			return;
		}
		if (Operators.CompareString(tAcCode.Text, OldAcCode, false) != 0)
		{
			OldAcCode = tAcCode.Text;
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			tMobileNo.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MOBILE"], (object)""));
			DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
			if ((Operators.CompareString(tAcCode.Text, "00045", false) != 0) | (Operators.CompareString(tAcCode.Text, "00040", false) != 0) | (Operators.CompareString(tAcCode.Text, "00100", false) != 0))
			{
				DC_Main.RsQry = "SELECT AC_CODE,SUM(DR_AMT)As TcsDr FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND DATA_TYPE = 'A' AND VCH_DATE >= '" + Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy") + "' GROUP BY AC_CODE";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					AcTcsAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TcsDr"]), "0.00"));
				}
				else
				{
					AcTcsAmt = 0.0;
				}
			}
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
			if (DC_Main.MsAcGoldOpBal > 0.0)
			{
				LOpGold.Text = Strings.Format((object)DC_Main.MsAcGoldOpBal, "0.000") + " : Cr Gold";
				((Control)LOpGold).ForeColor = Color.Blue;
			}
			else if (DC_Main.MsAcGoldOpBal < 0.0)
			{
				LOpGold.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcGoldOpBal), "0.000") + " : Dr Gold";
				((Control)LOpGold).ForeColor = Color.Red;
			}
			else
			{
				LOpGold.Text = ": Gold";
			}
			if (DC_Main.MsAcSilverOpBal > 0.0)
			{
				LOpSilver.Text = Strings.Format((object)DC_Main.MsAcSilverOpBal, "0.000") + " : Cr Silvr";
				((Control)LOpSilver).ForeColor = Color.Blue;
			}
			else if (DC_Main.MsAcSilverOpBal < 0.0)
			{
				LOpSilver.Text = Strings.Format((object)Math.Abs(DC_Main.MsAcSilverOpBal), "0.000") + " : Dr Silvr";
				((Control)LOpSilver).ForeColor = Color.Red;
			}
			else
			{
				LOpSilver.Text = ": Silvr";
			}
			CustOpAmt = DC_Main.MsAcAmtOpBal;
			CustOpGold = DC_Main.MsAcGoldOpBal;
			CustOpSilver = DC_Main.MsAcSilverOpBal;
			DC_Main.MsAcAmtOpBal = 0.0;
			DC_Main.MsAcGoldOpBal = 0.0;
			DC_Main.MsAcSilverOpBal = 0.0;
			DC_Main.MsAcAmtClBal = 0.0;
			DC_Main.MsAcGoldClBal = 0.0;
			DC_Main.MsAcSilverClBal = 0.0;
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
		{
			MSG.Col = 1;
		}
		else
		{
			MSG.Col = 3;
		}
		MSG.Row = 1;
		MSG_EnterCell(MSG, new EventArgs());
		((Control)TEXT_ENTRY).Focus();
	}

	private void TR_FINE_SL_PR_KeyUp(object sender, KeyEventArgs e)
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
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Invalid comparison between Unknown and I4
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Invalid comparison between Unknown and I4
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Invalid comparison between Unknown and I4
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Invalid comparison between Unknown and I4
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Invalid comparison between Unknown and I4
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ENTRY", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_ENTRY).SelectionStart = 0;
			((TextBoxBase)TEXT_ENTRY).SelectionLength = Strings.Len(TEXT_ENTRY.Text);
		}
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_IDTL", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_IDTL).SelectionStart = 0;
			((TextBoxBase)TEXT_IDTL).SelectionLength = Strings.Len(TEXT_IDTL.Text);
		}
	}

	private void MSG2_CLEAR()
	{
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		mSG2_TOTAL.Clear();
		mSG2_TOTAL.Rows = 12;
		mSG2_TOTAL.Row = 0;
		mSG2_TOTAL.Cols = 5;
		mSG2_TOTAL.ScrollBars = (ScrollBarsSettings)0;
		mSG2_TOTAL[0] = 7;
		checked
		{
			mSG2_TOTAL[0] = (int)Math.Round(1800.0 * ColCon);
			mSG2_TOTAL[1] = 0;
			mSG2_TOTAL[1] = (int)Math.Round(2500.0 * ColCon);
			mSG2_TOTAL[2] = 7;
			mSG2_TOTAL[2] = (int)Math.Round(800.0 * ColCon);
			mSG2_TOTAL[3] = 7;
			mSG2_TOTAL[3] = (int)Math.Round(1500.0 * ColCon);
			mSG2_TOTAL[4] = 7;
			mSG2_TOTAL[4] = 0;
			ColorConverter colorConverter = new ColorConverter();
			mSG2_TOTAL.FillStyle = (FillStyleSettings)1;
			DC_Main.i = 0;
			do
			{
				mSG2_TOTAL.Row = DC_Main.i;
				mSG2_TOTAL[DC_Main.i] = (int)Math.Round(300.0 * ColCon);
				switch (DC_Main.i)
				{
				case 0:
				case 6:
				case 11:
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					if (DC_Main.MsCoTheme == 3)
					{
						AxMSFlexGrid obj9 = mSG2_TOTAL;
						object? obj10 = colorConverter.ConvertFromString("233, 235, 240");
						obj9.CellBackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
					}
					else if (DC_Main.MsCoTheme == 4)
					{
						AxMSFlexGrid obj11 = mSG2_TOTAL;
						object? obj12 = colorConverter.ConvertFromString("Cornsilk");
						obj11.CellBackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
					}
					else
					{
						AxMSFlexGrid obj13 = mSG2_TOTAL;
						object? obj14 = colorConverter.ConvertFromString("255, 224, 192");
						obj13.CellBackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
					}
					break;
				case 7:
				case 8:
				{
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					AxMSFlexGrid obj7 = mSG2_TOTAL;
					object? obj8 = colorConverter.ConvertFromString("DarkBlue");
					obj7.CellForeColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
					break;
				}
				case 9:
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					if (DC_Main.MsCoTheme == 3)
					{
						AxMSFlexGrid obj = mSG2_TOTAL;
						object? obj2 = colorConverter.ConvertFromString("233, 235, 240");
						obj.CellBackColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
					}
					else if (DC_Main.MsCoTheme == 4)
					{
						AxMSFlexGrid obj3 = mSG2_TOTAL;
						object? obj4 = colorConverter.ConvertFromString("238, 244, 236");
						obj3.CellBackColor = ((obj4 != null) ? ((Color)obj4) : default(Color));
					}
					else
					{
						AxMSFlexGrid obj5 = mSG2_TOTAL;
						object? obj6 = colorConverter.ConvertFromString("Linen");
						obj5.CellBackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
					}
					break;
				}
				DC_Main.i++;
			}
			while (DC_Main.i <= 10);
			mSG2_TOTAL[0, 0] = "Net Amt : ";
			mSG2_TOTAL[1, 0] = "Disc Amt : ";
			mSG2_TOTAL[2, 0] = "Tax Amt : ";
			mSG2_TOTAL[3, 0] = "Tcs Amt : ";
			mSG2_TOTAL[4, 0] = "Tds Amt : ";
			mSG2_TOTAL[5, 0] = "Rof Amt : ";
			mSG2_TOTAL[6, 0] = "Total Amt : ";
			mSG2_TOTAL[7, 0] = "Cheque Amt : ";
			mSG2_TOTAL[8, 0] = "Card Amt : ";
			mSG2_TOTAL[9, 0] = "Cash Amt : ";
			mSG2_TOTAL[10, 0] = "Kasar Amt : ";
			mSG2_TOTAL[11, 0] = "Os Amt : ";
			mSG2_TOTAL.Row = 1;
			mSG2_TOTAL.Col = 1;
			((Control)TEXT_ENTRY_2).Visible = false;
			mSG2_TOTAL = null;
		}
	}

	private void MSG2_TOTAL_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		checked
		{
			if (mSG2_TOTAL.CellWidth >= 0)
			{
				((Control)TEXT_ENTRY_2).Left = (int)Math.Round((double)((Control)mSG2_TOTAL).Left + (double)mSG2_TOTAL.CellLeft / 15.0);
				((Control)TEXT_ENTRY_2).Top = (int)Math.Round((double)((Control)mSG2_TOTAL).Top + (double)mSG2_TOTAL.CellTop / 15.0);
				((Control)TEXT_ENTRY_2).Width = (int)Math.Round((double)mSG2_TOTAL.CellWidth / 15.0);
				((Control)TEXT_ENTRY_2).Height = (int)Math.Round((double)mSG2_TOTAL.CellHeight / 15.0);
				TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				((Control)TEXT_ENTRY_2).Visible = true;
				((TextBoxBase)TEXT_ENTRY_2).SelectAll();
				((Control)TEXT_ENTRY_2).Focus();
				mSG2_TOTAL = null;
			}
		}
	}

	private void MSG2_TOTAL_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		if (!((Control)BtnSave).Enabled || ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.CellWidth <= 0)) || mSG2_TOTAL[mSG2_TOTAL.Col] == 0)
		{
			return;
		}
		checked
		{
			((Control)TEXT_ENTRY_2).Left = (int)Math.Round((double)((Control)mSG2_TOTAL).Left + (double)mSG2_TOTAL.CellLeft / 15.0);
			((Control)TEXT_ENTRY_2).Top = (int)Math.Round((double)((Control)mSG2_TOTAL).Top + (double)mSG2_TOTAL.CellTop / 15.0);
			((Control)TEXT_ENTRY_2).Width = (int)Math.Round((double)mSG2_TOTAL.CellWidth / 15.0);
			((Control)TEXT_ENTRY_2).Height = (int)Math.Round((double)mSG2_TOTAL.CellHeight / 15.0);
			((Control)TEXT_ENTRY_2).Visible = true;
			((TextBoxBase)TEXT_ENTRY_2).ReadOnly = false;
			switch (MSG2_TOTAL.Col)
			{
			case 1:
				((TextBoxBase)TEXT_ENTRY_2).MaxLength = 50;
				TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 11))
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
				}
				else
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = false;
				}
				break;
			case 2:
				((TextBoxBase)TEXT_ENTRY_2).MaxLength = 10;
				if ((mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 8))
				{
					TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				}
				else
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 11) | (mSG2_TOTAL.Row == 2))
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
				}
				else
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = false;
				}
				break;
			case 3:
				((TextBoxBase)TEXT_ENTRY_2).MaxLength = 12;
				TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 11))
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
				}
				else
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = false;
				}
				break;
			}
			mSG2_TOTAL = null;
			((TextBoxBase)TEXT_ENTRY_2).SelectAll();
		}
	}

	private void MSG2_TOTAL_LeaveCell(object sender, EventArgs e)
	{
		if (!((Control)BtnSave).Enabled || MSG2_TOTAL.Row == 0 || MSG2_TOTAL[MSG2_TOTAL.Col] == 0 || !((Control)TEXT_ENTRY_2).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		switch (MSG2_TOTAL.Col)
		{
		case 1:
			mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = TEXT_ENTRY_2.Text;
			BILL_TOTAL();
			break;
		case 2:
			if ((mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 8))
			{
				mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = TEXT_ENTRY_2.Text;
				break;
			}
			mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY_2.Text), "0.00");
			BILL_TOTAL();
			break;
		case 3:
			mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY_2.Text), "0.00");
			BILL_TOTAL();
			break;
		}
		mSG2_TOTAL = null;
	}

	private void TEXT_ENTRY_2_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_ENTRY_2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Invalid comparison between Unknown and I4
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected I4, but got Unknown
		//IL_046b: Unknown result type (might be due to invalid IL or missing references)
		//IL_07be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3d: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		Keys keyCode = e.KeyCode;
		checked
		{
			if (unchecked((int)keyCode) != 13)
			{
				switch (unchecked(keyCode - 37))
				{
				case 0:
					if (mSG2_TOTAL.Col > 1)
					{
						mSG2_TOTAL.Col -= 1;
					}
					return;
				case 2:
					if (mSG2_TOTAL.Col < mSG2_TOTAL.Cols - 1)
					{
						mSG2_TOTAL.Col += 1;
					}
					break;
				case 1:
					if (mSG2_TOTAL.Row > 1)
					{
						mSG2_TOTAL.Row -= 1;
					}
					break;
				case 3:
					if (mSG2_TOTAL.Row < mSG2_TOTAL.Rows - 1)
					{
						mSG2_TOTAL.Row += 1;
					}
					break;
				}
			}
			else
			{
				bool flag = true;
				switch (mSG2_TOTAL.Col)
				{
				case 1:
					if (((mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 8)) && Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_NAME = '" + TEXT_ENTRY_2.Text + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (mSG2_TOTAL.Row == 7)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '02','22','03','23')  ORDER BY A.AC_NAME";
							}
							else if (mSG2_TOTAL.Row == 8)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '19','22','23')  ORDER BY A.AC_NAME";
							}
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[3];
							DC_Main.ColWidth[0] = 400.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 250.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_ENTRY_2.Text = DC_Main.ColValue[0];
									mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = DC_Main.ColValue[0];
									mSG2_TOTAL[mSG2_TOTAL.Row, 4] = DC_Main.ColValue[1];
									RowChang = true;
								}
								((Control)TEXT_ENTRY_2).Focus();
							}
							return;
						}
						mSG2_TOTAL[mSG2_TOTAL.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
						mSG2_TOTAL[mSG2_TOTAL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
						RowChang = true;
					}
					if (mSG2_TOTAL.Row == 3)
					{
						if (Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
						{
							DC_Main.RsQry = "Select * From TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND SR_NO = 0 AND TAX_NAME = '" + TEXT_ENTRY_2.Text + "'  ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT A.TAX_NAME As TaxNameL,A.TAX_PRC as TaxPrcW, TAX_CODE AS TaxCodeL FROM TAX_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE IN ('20','00') AND A.SR_NO = 0 ORDER BY A.TAX_CODE";
								DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.ColWidth = new double[4];
								DC_Main.ColWidth[0] = 250.0;
								DC_Main.ColWidth[1] = 100.0;
								DC_Main.ColWidth[2] = 0.0;
								DC_Main.HelpSelect = 1;
								((Form)MyProject.Forms.MS_HELP).ShowDialog();
								if (!DC_Main.HelpClose)
								{
									if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
									{
										TEXT_ENTRY_2.Text = DC_Main.ColValue[0];
										mSG2_TOTAL[3, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.000");
										OldTcsPrc = 111.0;
										mSG2_TOTAL[3, 4] = DC_Main.ColValue[2];
										BILL_TOTAL();
									}
									else
									{
										TEXT_ENTRY_2.Text = "";
										mSG2_TOTAL[3, 1] = "";
										mSG2_TOTAL[3, 2] = "";
										mSG2_TOTAL[3, 3] = "";
										mSG2_TOTAL[3, 4] = "";
									}
									MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
									mSG2_TOTAL.Row = 7;
									mSG2_TOTAL.Col = 3;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[3, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
								mSG2_TOTAL[3, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 7;
								mSG2_TOTAL.Col = 3;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							if (Operators.CompareString(DC_Main.MCo_BookType, "T", false) != 0)
							{
								TEXT_ENTRY_2.Text = "";
								mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "";
								mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "";
								mSG2_TOTAL[mSG2_TOTAL.Row, 4] = "";
							}
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row = 7;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (mSG2_TOTAL.Row == 2)
					{
						if (Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
						{
							DC_Main.RsQry = "Select * From TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND SR_NO = 0 AND TAX_NAME = '" + TEXT_ENTRY_2.Text + "'  ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT A.TAX_NAME As TaxNameL,A.TAX_PRC as TaxPrcR, TAX_CODE AS TaxCodeL FROM TAX_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.SR_NO = 0 ORDER BY A.TAX_CODE";
								DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.ColWidth = new double[4];
								DC_Main.ColWidth[0] = 250.0;
								DC_Main.ColWidth[1] = 100.0;
								DC_Main.ColWidth[2] = 0.0;
								DC_Main.HelpSelect = 1;
								((Form)MyProject.Forms.MS_HELP).ShowDialog();
								if (!DC_Main.HelpClose)
								{
									if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
									{
										TEXT_ENTRY_2.Text = DC_Main.ColValue[0];
										mSG2_TOTAL[2, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.00");
										mSG2_TOTAL[2, 4] = DC_Main.ColValue[2];
										BILL_TOTAL();
									}
									else
									{
										TEXT_ENTRY_2.Text = "TAX FREE";
										mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "TAX FREE";
										mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "0.00";
										mSG2_TOTAL[mSG2_TOTAL.Row, 4] = "00";
									}
									MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
									mSG2_TOTAL.Row = 4;
									mSG2_TOTAL.Col = 1;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[mSG2_TOTAL.Row, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00");
								double num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00"));
								mSG2_TOTAL[mSG2_TOTAL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 4;
								mSG2_TOTAL.Col = 1;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							if (Operators.CompareString(DC_Main.MCo_BookType, "T", false) != 0)
							{
								TEXT_ENTRY_2.Text = "TAX FREE";
								mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "TAX FREE";
								mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "0.00";
								mSG2_TOTAL[mSG2_TOTAL.Row, 4] = "00";
							}
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row = 7;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (mSG2_TOTAL.Row != 4)
					{
						break;
					}
					if (Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND SR_NO = 0 AND TAX_NAME = '" + TEXT_ENTRY_2.Text + "'  ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.TAX_NAME As TaxNameL,A.TAX_PRC as TaxPrcW, TAX_CODE AS TaxCodeL FROM TAX_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE NOT IN ('01','02','10','11','12','13','14','20') AND A.SR_NO = 0 ORDER BY A.TAX_CODE";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[4];
							DC_Main.ColWidth[0] = 250.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 0.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_ENTRY_2.Text = DC_Main.ColValue[0];
									mSG2_TOTAL[4, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.000");
									mSG2_TOTAL[4, 4] = DC_Main.ColValue[2];
									mSG2_TOTAL[4, 3] = "";
									OldTdsPrc = 0.0;
									BILL_TOTAL();
								}
								else
								{
									TEXT_ENTRY_2.Text = "";
									mSG2_TOTAL[4, 1] = "";
									mSG2_TOTAL[4, 2] = "";
									mSG2_TOTAL[4, 3] = "";
									mSG2_TOTAL[4, 4] = "";
								}
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 7;
								mSG2_TOTAL.Col = 3;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							mSG2_TOTAL[5, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
							mSG2_TOTAL[5, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
							mSG2_TOTAL[5, 3] = "";
							OldTdsPrc = 0.0;
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row = 7;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Focus();
						}
					}
					else
					{
						TEXT_ENTRY_2.Text = "";
						mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "";
						mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "";
						mSG2_TOTAL[mSG2_TOTAL.Row, 3] = "";
						mSG2_TOTAL[mSG2_TOTAL.Row, 4] = "";
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row = 7;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Focus();
					}
					return;
				case 3:
					switch (mSG2_TOTAL.Row)
					{
					case 9:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 7:
					case 8:
						if ((Conversion.Val(TEXT_ENTRY_2.Text) != 0.0) & !RowChang)
						{
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Col = 1;
							MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
							if (Operators.CompareString(TEXT_ENTRY_2.Text, "", false) == 0)
							{
								TEXT_ENTRY_2.Text = ".";
							}
							((Control)TEXT_ENTRY_2).Focus();
						}
						else
						{
							RowChang = false;
							BILL_TOTAL();
							mSG2_TOTAL.Row += 1;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Visible = true;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					case 10:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						BILL_TOTAL();
						((Control)tEmpCode).Focus();
						return;
					}
					if (mSG2_TOTAL.Row == mSG2_TOTAL.Rows - 1)
					{
						BILL_TOTAL();
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						((Control)BtnSave).Enabled = true;
						((Control)BtnSave).Focus();
						return;
					}
					mSG2_TOTAL.Row += 1;
					mSG2_TOTAL.Col = 1;
					((Control)TEXT_ENTRY_2).Visible = true;
					((Control)TEXT_ENTRY_2).Focus();
					flag = false;
					break;
				}
				if (flag)
				{
					MSG2_TOTAL.Col += 1;
					((Control)TEXT_ENTRY_2).Visible = true;
					((Control)TEXT_ENTRY_2).Focus();
				}
			}
			mSG2_TOTAL = null;
		}
	}

	private void TAcCode_TextChanged(object sender, EventArgs e)
	{
	}
}
