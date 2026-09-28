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
public class TR_BUL_SALE : Form
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
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcName")]
	private TextBox _tAcName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpCode")]
	private TextBox _tEmpCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchDesc")]
	private TextBox _tVchDesc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG2_TOTAL")]
	private AxMSFlexGrid _MSG2_TOTAL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_PR")]
	private AxMSFlexGrid _MSG_PR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY_2")]
	private TextBox _TEXT_ENTRY_2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_PR")]
	private TextBox _TEXT_PR;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBillNo")]
	private TextBox _tBillNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobile")]
	private TextBox _tMobile;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCity")]
	private TextBox _tCity;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAdd3")]
	private TextBox _tAdd3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAdd2")]
	private TextBox _tAdd2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAdd1")]
	private TextBox _tAdd1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nAcDrAmt")]
	private TextBox _nAcDrAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nAcCrFine")]
	private TextBox _nAcCrFine;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nAcCrAmt")]
	private TextBox _nAcCrAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nAcDrFine")]
	private TextBox _nAcDrFine;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nFineKsrDr")]
	private TextBox _nFineKsrDr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nFineKsrCr")]
	private TextBox _nFineKsrCr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nFineRate")]
	private TextBox _nFineRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCrDays")]
	private TextBox _nCrDays;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboItemTyp")]
	private ComboBox _cboItemTyp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nConvPrc")]
	private TextBox _nConvPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nConvRate")]
	private TextBox _nConvRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboBillType")]
	private ComboBox _cboBillType;

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

	private string OldAcCode;

	private string AcGstType;

	private string CurRatePar;

	private double CurItGwtStk;

	private int OldCurRow;

	private double SlOthAmtLess;

	private double PrOthAmtLess;

	private double CustOpAmt;

	private double CustOpGold;

	private double CustOpSilver;

	private double CustClAmt;

	private double CustClGold;

	private double CustClSilver;

	private double OldAcCrAmt;

	private double OldAcDrAmt;

	private double OldAcCrFine;

	private double OldAcDrFine;

	private double OldFineRate;

	private double TotCrFine;

	private double TotDrFine;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OldValTot;

	private double NewValTot;

	private string CurTagNo;

	private string MsVchSrno;

	private double OldConRate;

	private DataTable RsData;

	private DataTable RsDetl;

	private DataTable RsIdtl;

	private DataTable RsPrDetl;

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

	private bool RowChang;

	private double SlSilverFine;

	private const int cSrNo = 0;

	private const int cIsuNo = 1;

	private const int cItCode = 2;

	private const int cItName = 3;

	private const int cHmId = 4;

	private const int cPcs = 5;

	private const int cGrWt = 6;

	private const int cOthWt = 7;

	private const int cNetWt = 8;

	private const int cTouch = 9;

	private const int cLessTch = 10;

	private const int cLessWt = 11;

	private const int cFine = 12;

	private const int cAdjWt = 13;

	private const int cMcxRate = 14;

	private const int cPremium = 15;

	private const int cItRate = 16;

	private const int cItAmt = 17;

	private const int cLbrType = 18;

	private const int cLbrRate = 19;

	private const int cLbrAmt = 20;

	private const int cOthAmt = 21;

	private const int cNetAmt = 22;

	private const int cTotAmt = 23;

	private const int cTaxPrc = 24;

	private const int cCounter = 25;

	private const int cDesign = 26;

	private const int cSize = 27;

	private const int cBagWt = 28;

	private const int cGhtPrc = 29;

	private const int cGhtWt = 30;

	private const int cWestPrc = 31;

	private const int cSilverFine = 32;

	private const int cConvertRate = 33;

	private const int cConvertPrc = 34;

	private const int cLbrPrc = 35;

	private const int cOthFine = 36;

	private const int cMrp = 37;

	private const int cKrName = 38;

	private const int cKrOthWt = 39;

	private const int cKrNetWt = 40;

	private const int cKrGhatPrc = 41;

	private const int cKrGhatWt = 42;

	private const int cKrTouch = 43;

	private const int cKrWestPrc = 44;

	private const int cKrFine = 45;

	private const int cKrLRate = 46;

	private const int cKrLAmt = 47;

	private const int cKrOthAmt = 48;

	private const int cPrCost = 49;

	private const int cVchSrno = 50;

	private const int cTagCost = 51;

	private const int cMargin = 52;

	private const int cImageTake = 53;

	private const int cTagSrNo = 54;

	private const int cOldSrNo = 55;

	private const int cRateType = 56;

	private const int cItType = 57;

	private const int cTagType = 58;

	private const int cPrCode = 59;

	private const int cEntryMod = 60;

	private const int cOldTagType = 61;

	private const int cOldPrCode = 62;

	private const int cOldGrWt = 63;

	private const int cOldNtWt = 64;

	private const int cOldGhatPrc = 65;

	private const int cOldGhatWt = 66;

	private const int cOldTouch = 67;

	private const int cOldWestPrc = 68;

	private const int cOldKrNetWt = 69;

	private const int cOldKrTouch = 70;

	private const int cOldKrWest = 71;

	private const int cOldOthWt = 72;

	private const int cIsuYrCd = 73;

	private const int cIsuDbCd = 74;

	private const int cIsuSrNo = 75;

	private const int cOldItRate = 76;

	private const int cOldLessWt = 77;

	private const int cBookingWt = 78;

	private const int cOldLessTch = 79;

	private const int cOldFine = 80;

	private const int cTitel2 = 0;

	private const int cNetAmt2 = 1;

	private const int cTax2 = 2;

	private const int cTdsTax2 = 3;

	private const int cTot2 = 4;

	private const int cChq2 = 5;

	private const int cCard2 = 6;

	private const int cCash2 = 7;

	private const int cKasar2 = 8;

	private const int cOs2 = 9;

	private const int cPrSrNo = 0;

	private const int cPrIsuNo = 1;

	private const int cPrItCode = 2;

	private const int cPrItName = 3;

	private const int cPrPcs = 4;

	private const int cPrGrWt = 5;

	private const int cPrOthWt = 6;

	private const int cPrNetWt = 7;

	private const int cPrTouch = 8;

	private const int cPrLessTch = 9;

	private const int cPrLessWt = 10;

	private const int cPrFine = 11;

	private const int cPrAdjWt = 12;

	private const int cPrMcxRate = 13;

	private const int cPrPremium = 14;

	private const int cPrRate = 15;

	private const int cPrItAmt = 16;

	private const int cPrLbrType = 17;

	private const int cPrLbrRate = 18;

	private const int cPrLbrAmt = 19;

	private const int cPrOthAmt = 20;

	private const int cPrNetAmt = 21;

	private const int cPrCounter = 22;

	private const int cPrBagWt = 23;

	private const int cPrPcsWt = 24;

	private const int cPrGhtWt = 25;

	private const int cPrWestPrc = 26;

	private const int cPrSilverFine = 27;

	private const int cPrConvRate = 28;

	private const int cPrConvPrc = 29;

	private const int cPrLbrPrc = 30;

	private const int cPrOthFine = 31;

	private const int cPrMrp = 32;

	private const int cPrHmFine = 33;

	private const int cPrTotAmt = 34;

	private const int cPrTaxPrc = 35;

	private const int cPrItType = 36;

	private const int cPrRateType = 37;

	private const int cPrOldGwt = 38;

	private const int cPrOldNwt = 39;

	private const int cPrOldTouch = 40;

	private const int cPrOldWest = 41;

	private const int cPrOldRate = 42;

	private const int cPrIsuYrCd = 43;

	private const int cPrIsuDbCd = 44;

	private const int cPrIsuSrNo = 45;

	private const int cPrBookingWt = 46;

	private const int cPrOldLessWt = 47;

	private const int cPrOldLessTch = 48;

	private const int cPrOldFine = 49;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblItem")]
	private virtual Label _lblItem;

	internal virtual Label lblItem
	{
		get
		{
			return _lblItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblItem = value;
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = tAcCode_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tAcCode_KeyDown);
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tAcName
	{
		[CompilerGenerated]
		get
		{
			return _tAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = tAcName_GotFocus;
			EventHandler eventHandler2 = tAcName_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tAcName_KeyDown);
			TextBox val2 = _tAcName;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).TextChanged -= eventHandler2;
				((Control)val2).KeyDown -= val;
			}
			_tAcName = value;
			val2 = _tAcName;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
				((Control)val2).TextChanged += eventHandler2;
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

	internal virtual TextBox tVchDesc
	{
		[CompilerGenerated]
		get
		{
			return _tVchDesc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tVchDesc_KeyDown);
			EventHandler eventHandler = tVchDesc_DoubleClick;
			TextBox val2 = _tVchDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_tVchDesc = value;
			val2 = _tVchDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler;
			}
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

	internal virtual AxMSFlexGrid MSG_PR
	{
		[CompilerGenerated]
		get
		{
			return _MSG_PR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_PR_ClickEvent;
			EventHandler eventHandler2 = MSG_PR_EnterCell;
			EventHandler eventHandler3 = MSG_PR_LeaveCell;
			AxMSFlexGrid val = _MSG_PR;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_PR = value;
			val = _MSG_PR;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
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
			EventHandler eventHandler2 = TEXT_ENTRY_2_GotFocus;
			TextBox val2 = _TEXT_ENTRY_2;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler2;
			}
			_TEXT_ENTRY_2 = value;
			val2 = _TEXT_ENTRY_2;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler2;
			}
		}
	}

	internal virtual TextBox TEXT_PR
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_PR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_PR_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_PR_KeyDown);
			TextBox val2 = _TEXT_PR;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_PR = value;
			val2 = _TEXT_PR;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label8")]
	private virtual Label _Label8;

	internal virtual Label Label8
	{
		get
		{
			return _Label8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label8 = value;
		}
	}

	internal virtual TextBox tBillNo
	{
		[CompilerGenerated]
		get
		{
			return _tBillNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBillNo_KeyDown);
			TextBox val2 = _tBillNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBillNo = value;
			val2 = _tBillNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PanelAdd")]
	private virtual Panel _PanelAdd;

	internal virtual Panel PanelAdd
	{
		get
		{
			return _PanelAdd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PanelAdd = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label13")]
	private virtual Label _Label13;

	internal virtual Label Label13
	{
		get
		{
			return _Label13;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label13 = value;
		}
	}

	internal virtual TextBox tMobile
	{
		[CompilerGenerated]
		get
		{
			return _tMobile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tMobile_KeyDown);
			TextBox val2 = _tMobile;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tMobile = value;
			val2 = _tMobile;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label11")]
	private virtual Label _Label11;

	internal virtual Label Label11
	{
		get
		{
			return _Label11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label11 = value;
		}
	}

	internal virtual TextBox tCity
	{
		[CompilerGenerated]
		get
		{
			return _tCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCity_KeyDown);
			TextBox val2 = _tCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tCity = value;
			val2 = _tCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label10")]
	private virtual Label _Label10;

	internal virtual Label Label10
	{
		get
		{
			return _Label10;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label10 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label9")]
	private virtual Label _Label9;

	internal virtual Label Label9
	{
		get
		{
			return _Label9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label9 = value;
		}
	}

	internal virtual TextBox tAdd3
	{
		[CompilerGenerated]
		get
		{
			return _tAdd3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAdd3_KeyDown);
			TextBox val2 = _tAdd3;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAdd3 = value;
			val2 = _tAdd3;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tAdd2
	{
		[CompilerGenerated]
		get
		{
			return _tAdd2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAdd2_KeyDown);
			TextBox val2 = _tAdd2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAdd2 = value;
			val2 = _tAdd2;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tAdd1
	{
		[CompilerGenerated]
		get
		{
			return _tAdd1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAdd1_KeyDown);
			TextBox val2 = _tAdd1;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAdd1 = value;
			val2 = _tAdd1;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_PR_TOT")]
	private virtual AxMSFlexGrid _MSG_PR_TOT;

	internal virtual AxMSFlexGrid MSG_PR_TOT
	{
		get
		{
			return _MSG_PR_TOT;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_MSG_PR_TOT = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nTotFineCr")]
	private virtual TextBox _nTotFineCr;

	internal virtual TextBox nTotFineCr
	{
		get
		{
			return _nTotFineCr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nTotFineCr = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nTotFineDr")]
	private virtual TextBox _nTotFineDr;

	internal virtual TextBox nTotFineDr
	{
		get
		{
			return _nTotFineDr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nTotFineDr = value;
		}
	}

	internal virtual TextBox nAcDrAmt
	{
		[CompilerGenerated]
		get
		{
			return _nAcDrAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nAcDrAmt_KeyDown);
			TextBox val2 = _nAcDrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nAcDrAmt = value;
			val2 = _nAcDrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nAcCrFine
	{
		[CompilerGenerated]
		get
		{
			return _nAcCrFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nAcCrFine_KeyDown);
			TextBox val2 = _nAcCrFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nAcCrFine = value;
			val2 = _nAcCrFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nAcCrAmt
	{
		[CompilerGenerated]
		get
		{
			return _nAcCrAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nAcCrAmt_KeyDown);
			TextBox val2 = _nAcCrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nAcCrAmt = value;
			val2 = _nAcCrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nAcDrFine
	{
		[CompilerGenerated]
		get
		{
			return _nAcDrFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nAcDrFine_KeyDown);
			TextBox val2 = _nAcDrFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nAcDrFine = value;
			val2 = _nAcDrFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nFineKsrDr
	{
		[CompilerGenerated]
		get
		{
			return _nFineKsrDr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nFineKsrDr_KeyDown);
			TextBox val2 = _nFineKsrDr;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nFineKsrDr = value;
			val2 = _nFineKsrDr;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nFineKsrCr
	{
		[CompilerGenerated]
		get
		{
			return _nFineKsrCr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nFineKsrCr_KeyDown);
			TextBox val2 = _nFineKsrCr;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nFineKsrCr = value;
			val2 = _nFineKsrCr;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDiffFine")]
	private virtual TextBox _nDiffFine;

	internal virtual TextBox nDiffFine
	{
		get
		{
			return _nDiffFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nDiffFine = value;
		}
	}

	internal virtual TextBox nFineRate
	{
		[CompilerGenerated]
		get
		{
			return _nFineRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nFineRate_KeyDown);
			TextBox val2 = _nFineRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nFineRate = value;
			val2 = _nFineRate;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label14")]
	private virtual Label _Label14;

	internal virtual Label Label14
	{
		get
		{
			return _Label14;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label14 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label15")]
	private virtual Label _Label15;

	internal virtual Label Label15
	{
		get
		{
			return _Label15;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label15 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label16")]
	private virtual Label _Label16;

	internal virtual Label Label16
	{
		get
		{
			return _Label16;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label16 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label17")]
	private virtual Label _Label17;

	internal virtual Label Label17
	{
		get
		{
			return _Label17;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label17 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label18")]
	private virtual Label _Label18;

	internal virtual Label Label18
	{
		get
		{
			return _Label18;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label18 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label19")]
	private virtual Label _Label19;

	internal virtual Label Label19
	{
		get
		{
			return _Label19;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label19 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label20")]
	private virtual Label _Label20;

	internal virtual Label Label20
	{
		get
		{
			return _Label20;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label20 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblRate")]
	private virtual Label _lblRate;

	internal virtual Label lblRate
	{
		get
		{
			return _lblRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblRate = value;
		}
	}

	internal virtual TextBox nCrDays
	{
		[CompilerGenerated]
		get
		{
			return _nCrDays;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nCrDays_KeyDown);
			TextBox val2 = _nCrDays;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCrDays = value;
			val2 = _nCrDays;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label22")]
	private virtual Label _Label22;

	internal virtual Label Label22
	{
		get
		{
			return _Label22;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label22 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblDiffAmt")]
	private virtual Label _lblDiffAmt;

	internal virtual Label lblDiffAmt
	{
		get
		{
			return _lblDiffAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblDiffAmt = value;
		}
	}

	internal virtual ComboBox cboItemTyp
	{
		[CompilerGenerated]
		get
		{
			return _cboItemTyp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboItemTyp_KeyDown);
			ComboBox val2 = _cboItemTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboItemTyp = value;
			val2 = _cboItemTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label7")]
	private virtual Label _Label7;

	internal virtual Label Label7
	{
		get
		{
			return _Label7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label7 = value;
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

	internal virtual TextBox nConvPrc
	{
		[CompilerGenerated]
		get
		{
			return _nConvPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nConvPrc_KeyDown);
			TextBox val2 = _nConvPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nConvPrc = value;
			val2 = _nConvPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nConvRate
	{
		[CompilerGenerated]
		get
		{
			return _nConvRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nConvRate_KeyDown);
			TextBox val2 = _nConvRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nConvRate = value;
			val2 = _nConvRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label21")]
	private virtual Label _Label21;

	internal virtual Label Label21
	{
		get
		{
			return _Label21;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label21 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label23")]
	private virtual Label _Label23;

	internal virtual Label Label23
	{
		get
		{
			return _Label23;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label23 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkItmImage")]
	private virtual CheckBox _chkItmImage;

	internal virtual CheckBox chkItmImage
	{
		get
		{
			return _chkItmImage;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkItmImage = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkHuIdPrint")]
	private virtual CheckBox _chkHuIdPrint;

	internal virtual CheckBox chkHuIdPrint
	{
		get
		{
			return _chkHuIdPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkHuIdPrint = value;
		}
	}

	internal virtual ComboBox cboBillType
	{
		[CompilerGenerated]
		get
		{
			return _cboBillType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboBillType_KeyDown);
			ComboBox val2 = _cboBillType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboBillType = value;
			val2 = _cboBillType;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label24")]
	private virtual Label _Label24;

	internal virtual Label Label24
	{
		get
		{
			return _Label24;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label24 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblItStock")]
	private virtual Label _lblItStock;

	internal virtual Label lblItStock
	{
		get
		{
			return _lblItStock;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblItStock = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkWapp")]
	private virtual CheckBox _chkWapp;

	internal virtual CheckBox chkWapp
	{
		get
		{
			return _chkWapp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkWapp = value;
		}
	}

	public TR_BUL_SALE()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		((Form)this).Load += TR_BUL_SALE_Load;
		((Form)this).Deactivate += TR_BUL_SALE_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_BUL_SALE_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_BUL_SALE_KeyDown);
		((Form)this).Activated += TR_BUL_SALE_Activated;
		((Form)this).Closed += TR_BUL_SALE_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_BUL_SALE_KeyUp);
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
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Expected O, but got Unknown
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected O, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected O, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected O, but got Unknown
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Expected O, but got Unknown
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected O, but got Unknown
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Expected O, but got Unknown
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_034c: Expected O, but got Unknown
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Expected O, but got Unknown
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Expected O, but got Unknown
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected O, but got Unknown
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected O, but got Unknown
		//IL_037e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Expected O, but got Unknown
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected O, but got Unknown
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Expected O, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected O, but got Unknown
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected O, but got Unknown
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Expected O, but got Unknown
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Expected O, but got Unknown
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Expected O, but got Unknown
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Expected O, but got Unknown
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_040c: Expected O, but got Unknown
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Expected O, but got Unknown
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Expected O, but got Unknown
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected O, but got Unknown
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected O, but got Unknown
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Expected O, but got Unknown
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected O, but got Unknown
		//IL_0512: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Expected O, but got Unknown
		//IL_05ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d8: Expected O, but got Unknown
		//IL_065b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0665: Expected O, but got Unknown
		//IL_0702: Unknown result type (might be due to invalid IL or missing references)
		//IL_070c: Expected O, but got Unknown
		//IL_07ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c4: Expected O, but got Unknown
		//IL_084b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0855: Expected O, but got Unknown
		//IL_08f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fa: Expected O, but got Unknown
		//IL_0989: Unknown result type (might be due to invalid IL or missing references)
		//IL_0993: Expected O, but got Unknown
		//IL_09f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a00: Expected O, but got Unknown
		//IL_0aa9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab3: Expected O, but got Unknown
		//IL_0b16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b20: Expected O, but got Unknown
		//IL_0bc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd3: Expected O, but got Unknown
		//IL_0cf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfa: Expected O, but got Unknown
		//IL_0e05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0f: Expected O, but got Unknown
		//IL_0e72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7c: Expected O, but got Unknown
		//IL_100e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1125: Unknown result type (might be due to invalid IL or missing references)
		//IL_112f: Expected O, but got Unknown
		//IL_11da: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e4: Expected O, but got Unknown
		//IL_1290: Unknown result type (might be due to invalid IL or missing references)
		//IL_129a: Expected O, but got Unknown
		//IL_1392: Unknown result type (might be due to invalid IL or missing references)
		//IL_139c: Expected O, but got Unknown
		//IL_14ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b7: Expected O, but got Unknown
		//IL_1534: Unknown result type (might be due to invalid IL or missing references)
		//IL_153e: Expected O, but got Unknown
		//IL_1608: Unknown result type (might be due to invalid IL or missing references)
		//IL_1612: Expected O, but got Unknown
		//IL_1673: Unknown result type (might be due to invalid IL or missing references)
		//IL_167d: Expected O, but got Unknown
		//IL_16fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1706: Expected O, but got Unknown
		//IL_17de: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e8: Expected O, but got Unknown
		//IL_1884: Unknown result type (might be due to invalid IL or missing references)
		//IL_188e: Expected O, but got Unknown
		//IL_19c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d3: Expected O, but got Unknown
		//IL_1a1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a28: Expected O, but got Unknown
		//IL_1aa5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aaf: Expected O, but got Unknown
		//IL_1b30: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b3a: Expected O, but got Unknown
		//IL_1c04: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c0e: Expected O, but got Unknown
		//IL_1cb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cbf: Expected O, but got Unknown
		//IL_1d40: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4a: Expected O, but got Unknown
		//IL_1dcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dd9: Expected O, but got Unknown
		//IL_1e8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e97: Expected O, but got Unknown
		//IL_1f4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f55: Expected O, but got Unknown
		//IL_200d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2017: Expected O, but got Unknown
		//IL_207e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2088: Expected O, but got Unknown
		//IL_20e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_20ed: Expected O, but got Unknown
		//IL_218c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2196: Expected O, but got Unknown
		//IL_2214: Unknown result type (might be due to invalid IL or missing references)
		//IL_221e: Expected O, but got Unknown
		//IL_22cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_22d6: Expected O, but got Unknown
		//IL_24c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_24cc: Expected O, but got Unknown
		//IL_2579: Unknown result type (might be due to invalid IL or missing references)
		//IL_2583: Expected O, but got Unknown
		//IL_2612: Unknown result type (might be due to invalid IL or missing references)
		//IL_261c: Expected O, but got Unknown
		//IL_26ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_26d4: Expected O, but got Unknown
		//IL_2763: Unknown result type (might be due to invalid IL or missing references)
		//IL_276d: Expected O, but got Unknown
		//IL_281b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2825: Expected O, but got Unknown
		//IL_28d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_28dd: Expected O, but got Unknown
		//IL_296c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2976: Expected O, but got Unknown
		//IL_2a05: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a0f: Expected O, but got Unknown
		//IL_2a9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aa7: Expected O, but got Unknown
		//IL_2b6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b74: Expected O, but got Unknown
		//IL_2bce: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bd8: Expected O, but got Unknown
		//IL_2c98: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ca2: Expected O, but got Unknown
		//IL_2d56: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d60: Expected O, but got Unknown
		//IL_2de9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2df3: Expected O, but got Unknown
		//IL_2e7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e89: Expected O, but got Unknown
		//IL_2f12: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f1c: Expected O, but got Unknown
		//IL_2fa8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fb2: Expected O, but got Unknown
		//IL_303b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3045: Expected O, but got Unknown
		//IL_30d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_30db: Expected O, but got Unknown
		//IL_318d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3197: Expected O, but got Unknown
		//IL_323f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3249: Expected O, but got Unknown
		//IL_3301: Unknown result type (might be due to invalid IL or missing references)
		//IL_330b: Expected O, but got Unknown
		//IL_33c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_33d0: Expected O, but got Unknown
		//IL_3484: Unknown result type (might be due to invalid IL or missing references)
		//IL_348e: Expected O, but got Unknown
		//IL_3542: Unknown result type (might be due to invalid IL or missing references)
		//IL_354c: Expected O, but got Unknown
		//IL_35fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3607: Expected O, but got Unknown
		//IL_36b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_36c2: Expected O, but got Unknown
		//IL_3773: Unknown result type (might be due to invalid IL or missing references)
		//IL_377d: Expected O, but got Unknown
		//IL_3831: Unknown result type (might be due to invalid IL or missing references)
		//IL_383b: Expected O, but got Unknown
		//IL_38ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_38f6: Expected O, but got Unknown
		//IL_39aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_39b4: Expected O, but got Unknown
		//IL_3a42: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a4c: Expected O, but got Unknown
		//IL_3b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b0a: Expected O, but got Unknown
		//IL_3bca: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bd4: Expected O, but got Unknown
		//IL_3c3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c47: Expected O, but got Unknown
		//IL_3cf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d02: Expected O, but got Unknown
		//IL_3db6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3dc0: Expected O, but got Unknown
		//IL_3e74: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e7e: Expected O, but got Unknown
		//IL_3f32: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f3c: Expected O, but got Unknown
		//IL_3ff3: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ffd: Expected O, but got Unknown
		//IL_40b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_40be: Expected O, but got Unknown
		//IL_4172: Unknown result type (might be due to invalid IL or missing references)
		//IL_417c: Expected O, but got Unknown
		//IL_421e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4228: Expected O, but got Unknown
		//IL_42d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_42da: Expected O, but got Unknown
		//IL_4395: Unknown result type (might be due to invalid IL or missing references)
		//IL_439f: Expected O, but got Unknown
		//IL_4463: Unknown result type (might be due to invalid IL or missing references)
		//IL_446d: Expected O, but got Unknown
		//IL_44d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_44e0: Expected O, but got Unknown
		//IL_458e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4598: Expected O, but got Unknown
		//IL_464c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4656: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_BUL_SALE));
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
		chkHuIdPrint = new CheckBox();
		chkItmImage = new CheckBox();
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
		TEXT_ENTRY = new TextBox();
		lblItem = new Label();
		MSG_TOT = new AxMSFlexGrid();
		MSG = new AxMSFlexGrid();
		DlgOpen = new OpenFileDialog();
		BtnF1 = new SimpleButton();
		Cr = new AxCrystalReport();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label1 = new Label();
		tHdVchNo = new TextBox();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label3 = new Label();
		Label4 = new Label();
		tVchDesc = new TextBox();
		MSG2_TOTAL = new AxMSFlexGrid();
		MSG_PR = new AxMSFlexGrid();
		TEXT_ENTRY_2 = new TextBox();
		TEXT_PR = new TextBox();
		Label8 = new Label();
		tBillNo = new TextBox();
		PanelAdd = new Panel();
		Label13 = new Label();
		tMobile = new TextBox();
		Label11 = new Label();
		tCity = new TextBox();
		Label10 = new Label();
		Label9 = new Label();
		tAdd3 = new TextBox();
		tAdd2 = new TextBox();
		tAdd1 = new TextBox();
		Label6 = new Label();
		MSG_PR_TOT = new AxMSFlexGrid();
		nTotFineCr = new TextBox();
		nTotFineDr = new TextBox();
		nAcDrAmt = new TextBox();
		nAcCrFine = new TextBox();
		nAcCrAmt = new TextBox();
		nAcDrFine = new TextBox();
		nFineKsrDr = new TextBox();
		nFineKsrCr = new TextBox();
		nDiffFine = new TextBox();
		nFineRate = new TextBox();
		Label5 = new Label();
		Label12 = new Label();
		Label14 = new Label();
		Label15 = new Label();
		Label16 = new Label();
		Label17 = new Label();
		Label18 = new Label();
		Label19 = new Label();
		Label20 = new Label();
		lblRate = new Label();
		nCrDays = new TextBox();
		Label22 = new Label();
		lblDiffAmt = new Label();
		cboItemTyp = new ComboBox();
		Label7 = new Label();
		LOpAmt = new Label();
		LOpGold = new Label();
		LOpSilver = new Label();
		LClSilver = new Label();
		lClGold = new Label();
		LClAmt = new Label();
		nConvPrc = new TextBox();
		nConvRate = new TextBox();
		Label21 = new Label();
		Label23 = new Label();
		cboBillType = new ComboBox();
		Label24 = new Label();
		lblItStock = new Label();
		chkWapp = new CheckBox();
		((Control)PnlBotam).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG2_TOTAL).BeginInit();
		((ISupportInitialize)MSG_PR).BeginInit();
		((Control)PanelAdd).SuspendLayout();
		((ISupportInitialize)MSG_PR_TOT).BeginInit();
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
		lblBook.Text = "Bullion Sales";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(312, 37);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(229, 38);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(22, 39);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(62, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchNo).Location = new Point(105, 37);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 23);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDay).Location = new Point(483, 37);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(394, 37);
		((TextBoxBase)mTime).MaxLength = 8;
		((Control)mTime).Name = "mTime";
		((TextBoxBase)mTime).ReadOnly = true;
		((Control)mTime).Size = new Size(83, 23);
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
		((Control)PnlBotam).TabIndex = 23;
		((Control)FlowLayoutPanel1).BackColor = Color.Transparent;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkWapp);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkHuIdPrint);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkItmImage);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(246, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(575, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((ButtonBase)chkHuIdPrint).BackColor = Color.Transparent;
		((Control)chkHuIdPrint).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkHuIdPrint).ForeColor = Color.Black;
		((Control)chkHuIdPrint).Location = new Point(362, 3);
		((Control)chkHuIdPrint).Name = "chkHuIdPrint";
		((Control)chkHuIdPrint).RightToLeft = (RightToLeft)0;
		((Control)chkHuIdPrint).Size = new Size(98, 27);
		((Control)chkHuIdPrint).TabIndex = 4;
		((ButtonBase)chkHuIdPrint).Text = "HuId Print";
		((ButtonBase)chkHuIdPrint).UseVisualStyleBackColor = false;
		((ButtonBase)chkItmImage).BackColor = Color.Transparent;
		((Control)chkItmImage).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkItmImage).ForeColor = Color.Black;
		((Control)chkItmImage).Location = new Point(245, 3);
		((Control)chkItmImage).Name = "chkItmImage";
		((Control)chkItmImage).RightToLeft = (RightToLeft)0;
		((Control)chkItmImage).Size = new Size(111, 27);
		((Control)chkItmImage).TabIndex = 3;
		((ButtonBase)chkItmImage).Text = "Item Image";
		((ButtonBase)chkItmImage).UseVisualStyleBackColor = false;
		((Control)chkItmImage).Visible = false;
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
		((Control)TEXT_ENTRY).Location = new Point(741, 146);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 8;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)lblItem).Font = new Font("Franklin Gothic Book", 9.75f);
		((Control)lblItem).ForeColor = Color.Black;
		lblItem.ImeMode = (ImeMode)0;
		((Control)lblItem).Location = new Point(766, 67);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(246, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)16;
		((Control)MSG_TOT).Location = new Point(14, 204);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1155, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 95);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1158, 107);
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
		((Control)BtnF1).Location = new Point(187, 37);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1181, 393);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(312, 66);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 5;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(394, 66);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(366, 23);
		((Control)tAcName).TabIndex = 6;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(230, 65);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(75, 20);
		((Control)Label1).TabIndex = 1157;
		Label1.Text = "Party Code";
		Label1.TextAlign = (ContentAlignment)16;
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
		((Control)tEmpCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpCode).Location = new Point(464, 397);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(44, 23);
		((Control)tEmpCode).TabIndex = 20;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(514, 397);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(109, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(391, 396);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(385, 452);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(73, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(464, 455);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(159, 39);
		((Control)tVchDesc).TabIndex = 22;
		((Control)MSG2_TOTAL).Location = new Point(629, 357);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(541, 202);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG_PR).Location = new Point(12, 230);
		((Control)MSG_PR).Name = "MSG_PR";
		((AxHost)MSG_PR).OcxState = (State)componentResourceManager.GetObject("MSG_PR.OcxState");
		((Control)MSG_PR).Size = new Size(1158, 101);
		((Control)MSG_PR).TabIndex = 1168;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(942, 450);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 19;
		((Control)TEXT_ENTRY_2).Visible = false;
		((TextBoxBase)TEXT_PR).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_PR).BorderStyle = (BorderStyle)0;
		((Control)TEXT_PR).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_PR).ForeColor = Color.White;
		((Control)TEXT_PR).Location = new Point(408, 291);
		((Control)TEXT_PR).Name = "TEXT_PR";
		((Control)TEXT_PR).Size = new Size(100, 18);
		((Control)TEXT_PR).TabIndex = 9;
		((Control)TEXT_PR).Visible = false;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(22, 66);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(62, 20);
		((Control)Label8).TabIndex = 1178;
		Label8.Text = "Ref No";
		Label8.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tBillNo).BackColor = Color.White;
		((Control)tBillNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBillNo).Location = new Point(105, 66);
		((TextBoxBase)tBillNo).MaxLength = 20;
		((Control)tBillNo).Name = "tBillNo";
		((Control)tBillNo).Size = new Size(117, 23);
		((Control)tBillNo).TabIndex = 4;
		((Control)PanelAdd).BackColor = Color.FromArgb(255, 224, 192);
		PanelAdd.BorderStyle = (BorderStyle)2;
		((Control)PanelAdd).Controls.Add((Control)(object)Label13);
		((Control)PanelAdd).Controls.Add((Control)(object)tMobile);
		((Control)PanelAdd).Controls.Add((Control)(object)Label11);
		((Control)PanelAdd).Controls.Add((Control)(object)tCity);
		((Control)PanelAdd).Controls.Add((Control)(object)Label10);
		((Control)PanelAdd).Controls.Add((Control)(object)Label9);
		((Control)PanelAdd).Controls.Add((Control)(object)tAdd3);
		((Control)PanelAdd).Controls.Add((Control)(object)tAdd2);
		((Control)PanelAdd).Controls.Add((Control)(object)tAdd1);
		((Control)PanelAdd).Controls.Add((Control)(object)Label6);
		((Control)PanelAdd).Location = new Point(312, 94);
		((Control)PanelAdd).Name = "PanelAdd";
		((Control)PanelAdd).Size = new Size(408, 152);
		((Control)PanelAdd).TabIndex = 7;
		((Control)PanelAdd).Visible = false;
		((Control)Label13).BackColor = Color.Transparent;
		((Control)Label13).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label13).ForeColor = Color.Maroon;
		Label13.ImeMode = (ImeMode)0;
		((Control)Label13).Location = new Point(3, 119);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(73, 20);
		((Control)Label13).TabIndex = 1169;
		Label13.Text = "Mobile No  :";
		Label13.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tMobile).BackColor = Color.White;
		((Control)tMobile).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tMobile).ForeColor = Color.Maroon;
		((Control)tMobile).Location = new Point(82, 118);
		((TextBoxBase)tMobile).MaxLength = 12;
		((Control)tMobile).Name = "tMobile";
		((Control)tMobile).Size = new Size(205, 23);
		((Control)tMobile).TabIndex = 4;
		((Control)Label11).BackColor = Color.Transparent;
		((Control)Label11).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label11).ForeColor = Color.Maroon;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(17, 90);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(59, 20);
		((Control)Label11).TabIndex = 1166;
		Label11.Text = "City  :";
		Label11.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tCity).BackColor = Color.White;
		((Control)tCity).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tCity).ForeColor = Color.Maroon;
		((Control)tCity).Location = new Point(82, 90);
		((TextBoxBase)tCity).MaxLength = 20;
		((Control)tCity).Name = "tCity";
		((Control)tCity).Size = new Size(301, 23);
		((Control)tCity).TabIndex = 3;
		((Control)Label10).BackColor = Color.Transparent;
		((Control)Label10).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label10).ForeColor = Color.Maroon;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(17, 62);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(59, 20);
		((Control)Label10).TabIndex = 1163;
		Label10.Text = "Add 3  :";
		Label10.TextAlign = (ContentAlignment)64;
		((Control)Label9).BackColor = Color.Transparent;
		((Control)Label9).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label9).ForeColor = Color.Maroon;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(17, 34);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(59, 20);
		((Control)Label9).TabIndex = 1162;
		Label9.Text = "Add 2  :";
		Label9.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tAdd3).BackColor = Color.White;
		((Control)tAdd3).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tAdd3).ForeColor = Color.Maroon;
		((Control)tAdd3).Location = new Point(82, 62);
		((TextBoxBase)tAdd3).MaxLength = 50;
		((Control)tAdd3).Name = "tAdd3";
		((Control)tAdd3).Size = new Size(301, 23);
		((Control)tAdd3).TabIndex = 2;
		((TextBoxBase)tAdd2).BackColor = Color.White;
		((Control)tAdd2).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tAdd2).ForeColor = Color.Maroon;
		((Control)tAdd2).Location = new Point(82, 34);
		((TextBoxBase)tAdd2).MaxLength = 50;
		((Control)tAdd2).Name = "tAdd2";
		((Control)tAdd2).Size = new Size(301, 23);
		((Control)tAdd2).TabIndex = 1;
		((TextBoxBase)tAdd1).BackColor = Color.White;
		((Control)tAdd1).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tAdd1).ForeColor = Color.Maroon;
		((Control)tAdd1).Location = new Point(82, 6);
		((TextBoxBase)tAdd1).MaxLength = 50;
		((Control)tAdd1).Name = "tAdd1";
		((Control)tAdd1).Size = new Size(301, 23);
		((Control)tAdd1).TabIndex = 0;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Maroon;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(17, 6);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(59, 20);
		((Control)Label6).TabIndex = 1158;
		Label6.Text = "Add 1  :";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)MSG_PR_TOT).Location = new Point(15, 334);
		((Control)MSG_PR_TOT).Name = "MSG_PR_TOT";
		((AxHost)MSG_PR_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_PR_TOT.OcxState");
		((Control)MSG_PR_TOT).Size = new Size(1154, 15);
		((Control)MSG_PR_TOT).TabIndex = 1179;
		((TextBoxBase)nTotFineCr).BackColor = Color.FromArgb(255, 224, 192);
		((Control)nTotFineCr).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nTotFineCr).ForeColor = Color.FromArgb(0, 0, 192);
		((Control)nTotFineCr).Location = new Point(95, 398);
		((TextBoxBase)nTotFineCr).MaxLength = 10;
		((Control)nTotFineCr).Name = "nTotFineCr";
		((TextBoxBase)nTotFineCr).ReadOnly = true;
		((Control)nTotFineCr).Size = new Size(90, 22);
		((Control)nTotFineCr).TabIndex = 1180;
		nTotFineCr.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nTotFineDr).BackColor = Color.FromArgb(255, 224, 192);
		((Control)nTotFineDr).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nTotFineDr).ForeColor = Color.FromArgb(0, 0, 192);
		((Control)nTotFineDr).Location = new Point(286, 398);
		((TextBoxBase)nTotFineDr).MaxLength = 10;
		((Control)nTotFineDr).Name = "nTotFineDr";
		((TextBoxBase)nTotFineDr).ReadOnly = true;
		((Control)nTotFineDr).Size = new Size(90, 22);
		((Control)nTotFineDr).TabIndex = 1181;
		nTotFineDr.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nAcDrAmt).BackColor = Color.White;
		((Control)nAcDrAmt).Font = new Font("Tahoma", 9f);
		((Control)nAcDrAmt).Location = new Point(95, 426);
		((TextBoxBase)nAcDrAmt).MaxLength = 10;
		((Control)nAcDrAmt).Name = "nAcDrAmt";
		((Control)nAcDrAmt).Size = new Size(90, 22);
		((Control)nAcDrAmt).TabIndex = 10;
		nAcDrAmt.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nAcCrFine).BackColor = Color.White;
		((Control)nAcCrFine).Font = new Font("Tahoma", 9f);
		((Control)nAcCrFine).Location = new Point(286, 426);
		((TextBoxBase)nAcCrFine).MaxLength = 10;
		((Control)nAcCrFine).Name = "nAcCrFine";
		((Control)nAcCrFine).Size = new Size(90, 22);
		((Control)nAcCrFine).TabIndex = 11;
		nAcCrFine.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nAcCrAmt).BackColor = Color.White;
		((Control)nAcCrAmt).Font = new Font("Tahoma", 9f);
		((Control)nAcCrAmt).Location = new Point(95, 455);
		((TextBoxBase)nAcCrAmt).MaxLength = 10;
		((Control)nAcCrAmt).Name = "nAcCrAmt";
		((Control)nAcCrAmt).Size = new Size(90, 22);
		((Control)nAcCrAmt).TabIndex = 12;
		nAcCrAmt.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nAcDrFine).BackColor = Color.White;
		((Control)nAcDrFine).Font = new Font("Tahoma", 9f);
		((Control)nAcDrFine).Location = new Point(286, 455);
		((TextBoxBase)nAcDrFine).MaxLength = 10;
		((Control)nAcDrFine).Name = "nAcDrFine";
		((Control)nAcDrFine).Size = new Size(90, 22);
		((Control)nAcDrFine).TabIndex = 13;
		nAcDrFine.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nFineKsrDr).BackColor = Color.Honeydew;
		((Control)nFineKsrDr).Font = new Font("Tahoma", 9f);
		((Control)nFineKsrDr).Location = new Point(95, 483);
		((TextBoxBase)nFineKsrDr).MaxLength = 10;
		((Control)nFineKsrDr).Name = "nFineKsrDr";
		((Control)nFineKsrDr).Size = new Size(90, 22);
		((Control)nFineKsrDr).TabIndex = 14;
		nFineKsrDr.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nFineKsrCr).BackColor = Color.Honeydew;
		((Control)nFineKsrCr).Font = new Font("Tahoma", 9f);
		((Control)nFineKsrCr).Location = new Point(286, 483);
		((TextBoxBase)nFineKsrCr).MaxLength = 10;
		((Control)nFineKsrCr).Name = "nFineKsrCr";
		((Control)nFineKsrCr).Size = new Size(90, 22);
		((Control)nFineKsrCr).TabIndex = 15;
		nFineKsrCr.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nDiffFine).BackColor = Color.Lavender;
		((Control)nDiffFine).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nDiffFine).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nDiffFine).Location = new Point(95, 539);
		((TextBoxBase)nDiffFine).MaxLength = 10;
		((Control)nDiffFine).Name = "nDiffFine";
		((TextBoxBase)nDiffFine).ReadOnly = true;
		((Control)nDiffFine).Size = new Size(90, 22);
		((Control)nDiffFine).TabIndex = 1188;
		nDiffFine.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nFineRate).BackColor = Color.Lavender;
		((Control)nFineRate).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nFineRate).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nFineRate).Location = new Point(286, 539);
		((TextBoxBase)nFineRate).MaxLength = 10;
		((Control)nFineRate).Name = "nFineRate";
		((Control)nFineRate).Size = new Size(90, 22);
		((Control)nFineRate).TabIndex = 18;
		nFineRate.TextAlign = (HorizontalAlignment)1;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.FromArgb(192, 0, 0);
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(10, 400);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(79, 20);
		((Control)Label5).TabIndex = 1190;
		Label5.Text = "Tot Fine Cr";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)Label12).BackColor = Color.Transparent;
		((Control)Label12).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label12).ForeColor = Color.FromArgb(192, 0, 0);
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(202, 400);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(79, 20);
		((Control)Label12).TabIndex = 1191;
		Label12.Text = "Tot Fine Dr";
		Label12.TextAlign = (ContentAlignment)64;
		((Control)Label14).BackColor = Color.Transparent;
		((Control)Label14).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(202, 428);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(79, 20);
		((Control)Label14).TabIndex = 1192;
		Label14.Text = "Ac Fine Cr";
		Label14.TextAlign = (ContentAlignment)64;
		((Control)Label15).BackColor = Color.Transparent;
		((Control)Label15).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(202, 456);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(79, 20);
		((Control)Label15).TabIndex = 1193;
		Label15.Text = "Ac Fine Dr";
		Label15.TextAlign = (ContentAlignment)64;
		((Control)Label16).BackColor = Color.Transparent;
		((Control)Label16).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label16).ForeColor = Color.Black;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(10, 428);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(79, 20);
		((Control)Label16).TabIndex = 1194;
		Label16.Text = "Ac Amt Dr";
		Label16.TextAlign = (ContentAlignment)64;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(10, 456);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(79, 20);
		((Control)Label17).TabIndex = 1195;
		Label17.Text = "Ac Amt Cr";
		Label17.TextAlign = (ContentAlignment)64;
		((Control)Label18).BackColor = Color.Transparent;
		((Control)Label18).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label18).ForeColor = Color.Black;
		Label18.ImeMode = (ImeMode)0;
		((Control)Label18).Location = new Point(10, 484);
		((Control)Label18).Name = "Label18";
		((Control)Label18).Size = new Size(79, 20);
		((Control)Label18).TabIndex = 1196;
		Label18.Text = "Ksr Fine Dr";
		Label18.TextAlign = (ContentAlignment)64;
		((Control)Label19).BackColor = Color.Transparent;
		((Control)Label19).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label19).ForeColor = Color.Black;
		Label19.ImeMode = (ImeMode)0;
		((Control)Label19).Location = new Point(202, 484);
		((Control)Label19).Name = "Label19";
		((Control)Label19).Size = new Size(79, 20);
		((Control)Label19).TabIndex = 1197;
		Label19.Text = "Ksr Fine Cr";
		Label19.TextAlign = (ContentAlignment)64;
		((Control)Label20).BackColor = Color.Transparent;
		((Control)Label20).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label20).ForeColor = Color.Navy;
		Label20.ImeMode = (ImeMode)0;
		((Control)Label20).Location = new Point(11, 541);
		((Control)Label20).Name = "Label20";
		((Control)Label20).Size = new Size(79, 20);
		((Control)Label20).TabIndex = 1198;
		Label20.Text = "Os Fine";
		Label20.TextAlign = (ContentAlignment)64;
		((Control)lblRate).BackColor = Color.Transparent;
		((Control)lblRate).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblRate).ForeColor = Color.Navy;
		lblRate.ImeMode = (ImeMode)0;
		((Control)lblRate).Location = new Point(202, 539);
		((Control)lblRate).Name = "lblRate";
		((Control)lblRate).Size = new Size(79, 20);
		((Control)lblRate).TabIndex = 1199;
		lblRate.Text = "Fine Rate";
		lblRate.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nCrDays).BackColor = Color.White;
		((Control)nCrDays).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nCrDays).Location = new Point(464, 426);
		((TextBoxBase)nCrDays).MaxLength = 3;
		((Control)nCrDays).Name = "nCrDays";
		((Control)nCrDays).Size = new Size(44, 23);
		((Control)nCrDays).TabIndex = 21;
		nCrDays.TextAlign = (HorizontalAlignment)2;
		((Control)Label22).BackColor = Color.Transparent;
		((Control)Label22).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label22).ForeColor = Color.Black;
		Label22.ImeMode = (ImeMode)0;
		((Control)Label22).Location = new Point(389, 423);
		((Control)Label22).Name = "Label22";
		((Control)Label22).Size = new Size(69, 20);
		((Control)Label22).TabIndex = 1201;
		Label22.Text = "Cr Days";
		Label22.TextAlign = (ContentAlignment)64;
		((Control)lblDiffAmt).BackColor = Color.Transparent;
		((Control)lblDiffAmt).Font = new Font("Arial", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblDiffAmt).ForeColor = Color.Maroon;
		lblDiffAmt.ImeMode = (ImeMode)0;
		((Control)lblDiffAmt).Location = new Point(514, 426);
		((Control)lblDiffAmt).Name = "lblDiffAmt";
		((Control)lblDiffAmt).Size = new Size(109, 20);
		((Control)lblDiffAmt).TabIndex = 1202;
		lblDiffAmt.Text = "Diff Amount";
		lblDiffAmt.TextAlign = (ContentAlignment)64;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(657, 38);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(103, 22);
		((Control)cboItemTyp).TabIndex = 2;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(574, 39);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(74, 20);
		((Control)Label7).TabIndex = 1204;
		Label7.Text = "Item Type";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(1018, 35);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(148, 20);
		((Control)LOpAmt).TabIndex = 1205;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LOpGold).BackColor = Color.Transparent;
		((Control)LOpGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpGold).ForeColor = Color.Black;
		LOpGold.ImeMode = (ImeMode)0;
		((Control)LOpGold).Location = new Point(1018, 54);
		((Control)LOpGold).Name = "LOpGold";
		((Control)LOpGold).Size = new Size(148, 20);
		((Control)LOpGold).TabIndex = 1206;
		LOpGold.Text = "OpGold";
		LOpGold.TextAlign = (ContentAlignment)64;
		((Control)LOpSilver).BackColor = Color.Transparent;
		((Control)LOpSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpSilver).ForeColor = Color.Black;
		LOpSilver.ImeMode = (ImeMode)0;
		((Control)LOpSilver).Location = new Point(1018, 72);
		((Control)LOpSilver).Name = "LOpSilver";
		((Control)LOpSilver).Size = new Size(148, 20);
		((Control)LOpSilver).TabIndex = 1207;
		LOpSilver.Text = "OpSilver";
		LOpSilver.TextAlign = (ContentAlignment)64;
		((Control)LClSilver).BackColor = Color.Transparent;
		((Control)LClSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClSilver).ForeColor = Color.Black;
		LClSilver.ImeMode = (ImeMode)0;
		((Control)LClSilver).Location = new Point(480, 541);
		((Control)LClSilver).Name = "LClSilver";
		((Control)LClSilver).Size = new Size(148, 20);
		((Control)LClSilver).TabIndex = 1210;
		LClSilver.Text = "ClSilver";
		LClSilver.TextAlign = (ContentAlignment)64;
		((Control)lClGold).BackColor = Color.Transparent;
		((Control)lClGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lClGold).ForeColor = Color.Black;
		lClGold.ImeMode = (ImeMode)0;
		((Control)lClGold).Location = new Point(480, 521);
		((Control)lClGold).Name = "lClGold";
		((Control)lClGold).Size = new Size(148, 20);
		((Control)lClGold).TabIndex = 1209;
		lClGold.Text = "ClGold";
		lClGold.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(480, 500);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(148, 20);
		((Control)LClAmt).TabIndex = 1208;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nConvPrc).BackColor = Color.Beige;
		((Control)nConvPrc).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nConvPrc).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nConvPrc).Location = new Point(95, 511);
		((TextBoxBase)nConvPrc).MaxLength = 10;
		((Control)nConvPrc).Name = "nConvPrc";
		((Control)nConvPrc).Size = new Size(90, 22);
		((Control)nConvPrc).TabIndex = 16;
		nConvPrc.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nConvRate).BackColor = Color.Beige;
		((Control)nConvRate).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nConvRate).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nConvRate).Location = new Point(286, 511);
		((TextBoxBase)nConvRate).MaxLength = 10;
		((Control)nConvRate).Name = "nConvRate";
		((Control)nConvRate).Size = new Size(90, 22);
		((Control)nConvRate).TabIndex = 17;
		nConvRate.TextAlign = (HorizontalAlignment)1;
		((Control)Label21).BackColor = Color.Transparent;
		((Control)Label21).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label21).ForeColor = Color.FromArgb(192, 0, 0);
		Label21.ImeMode = (ImeMode)0;
		((Control)Label21).Location = new Point(202, 513);
		((Control)Label21).Name = "Label21";
		((Control)Label21).Size = new Size(79, 20);
		((Control)Label21).TabIndex = 1213;
		Label21.Text = "Convrt Rate";
		Label21.TextAlign = (ContentAlignment)64;
		((Control)Label23).BackColor = Color.Transparent;
		((Control)Label23).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label23).ForeColor = Color.FromArgb(192, 0, 0);
		Label23.ImeMode = (ImeMode)0;
		((Control)Label23).Location = new Point(10, 513);
		((Control)Label23).Name = "Label23";
		((Control)Label23).Size = new Size(79, 20);
		((Control)Label23).TabIndex = 1214;
		Label23.Text = "Conv %";
		Label23.TextAlign = (ContentAlignment)64;
		cboBillType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboBillType).Font = new Font("Tahoma", 9f);
		((ListControl)cboBillType).FormattingEnabled = true;
		((Control)cboBillType).Location = new Point(855, 37);
		((Control)cboBillType).Name = "cboBillType";
		((Control)cboBillType).Size = new Size(83, 22);
		((Control)cboBillType).TabIndex = 3;
		((Control)Label24).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label24).ForeColor = Color.Black;
		Label24.ImeMode = (ImeMode)0;
		((Control)Label24).Location = new Point(775, 39);
		((Control)Label24).Name = "Label24";
		((Control)Label24).Size = new Size(74, 20);
		((Control)Label24).TabIndex = 1216;
		Label24.Text = "Bill Type";
		Label24.TextAlign = (ContentAlignment)64;
		((Control)lblItStock).BackColor = Color.Transparent;
		((Control)lblItStock).Font = new Font("Tahoma", 9f);
		((Control)lblItStock).ForeColor = Color.Blue;
		lblItStock.ImeMode = (ImeMode)0;
		((Control)lblItStock).Location = new Point(12, 357);
		((Control)lblItStock).Name = "lblItStock";
		((Control)lblItStock).Size = new Size(259, 20);
		((Control)lblItStock).TabIndex = 1235;
		lblItStock.Text = "Itm Stock :";
		lblItStock.TextAlign = (ContentAlignment)16;
		((ButtonBase)chkWapp).BackColor = Color.Transparent;
		((Control)chkWapp).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWapp).ForeColor = Color.Black;
		((Control)chkWapp).Location = new Point(466, 3);
		((Control)chkWapp).Name = "chkWapp";
		((Control)chkWapp).RightToLeft = (RightToLeft)0;
		((Control)chkWapp).Size = new Size(106, 27);
		((Control)chkWapp).TabIndex = 8;
		((ButtonBase)chkWapp).Text = "Wapp";
		((ButtonBase)chkWapp).UseVisualStyleBackColor = false;
		((Control)chkWapp).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)lblItStock);
		((Control)this).Controls.Add((Control)(object)Label24);
		((Control)this).Controls.Add((Control)(object)cboBillType);
		((Control)this).Controls.Add((Control)(object)Label23);
		((Control)this).Controls.Add((Control)(object)Label21);
		((Control)this).Controls.Add((Control)(object)nConvRate);
		((Control)this).Controls.Add((Control)(object)nConvPrc);
		((Control)this).Controls.Add((Control)(object)LClSilver);
		((Control)this).Controls.Add((Control)(object)lClGold);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpSilver);
		((Control)this).Controls.Add((Control)(object)LOpGold);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)lblDiffAmt);
		((Control)this).Controls.Add((Control)(object)nCrDays);
		((Control)this).Controls.Add((Control)(object)Label22);
		((Control)this).Controls.Add((Control)(object)lblRate);
		((Control)this).Controls.Add((Control)(object)Label20);
		((Control)this).Controls.Add((Control)(object)Label19);
		((Control)this).Controls.Add((Control)(object)Label18);
		((Control)this).Controls.Add((Control)(object)Label17);
		((Control)this).Controls.Add((Control)(object)Label16);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)nFineRate);
		((Control)this).Controls.Add((Control)(object)nDiffFine);
		((Control)this).Controls.Add((Control)(object)nFineKsrCr);
		((Control)this).Controls.Add((Control)(object)nFineKsrDr);
		((Control)this).Controls.Add((Control)(object)nAcDrFine);
		((Control)this).Controls.Add((Control)(object)nAcCrAmt);
		((Control)this).Controls.Add((Control)(object)nAcCrFine);
		((Control)this).Controls.Add((Control)(object)nAcDrAmt);
		((Control)this).Controls.Add((Control)(object)nTotFineDr);
		((Control)this).Controls.Add((Control)(object)nTotFineCr);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG_PR_TOT);
		((Control)this).Controls.Add((Control)(object)PanelAdd);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tBillNo);
		((Control)this).Controls.Add((Control)(object)TEXT_PR);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY_2);
		((Control)this).Controls.Add((Control)(object)MSG_PR);
		((Control)this).Controls.Add((Control)(object)MSG2_TOTAL);
		((Control)this).Controls.Add((Control)(object)tVchDesc);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)tEmpCode);
		((Control)this).Controls.Add((Control)(object)tEmpName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)tHdVchNo);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)BtnF1);
		((Control)this).Controls.Add((Control)(object)lblItem);
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
		((Control)this).Name = "TR_BUL_SALE";
		((Form)this).Text = "Bullion Sales";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG2_TOTAL).EndInit();
		((ISupportInitialize)MSG_PR).EndInit();
		((Control)PanelAdd).ResumeLayout(false);
		((Control)PanelAdd).PerformLayout();
		((ISupportInitialize)MSG_PR_TOT).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_PR_CLEAR()
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		mSG_PR.Clear();
		mSG_PR.Cols = 50;
		mSG_PR.FixedRows = 1;
		mSG_PR.Rows = 2;
		mSG_PR.Row = 1;
		mSG_PR[0] = 0;
		mSG_PR[1] = 0;
		mSG_PR.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_PR[0] = (int)Math.Round(500.0 * ColCon);
			mSG_PR[0] = 3;
			mSG_PR[0, 0] = "Sr";
			if (Operators.CompareString(DC_Main.MsBulProcess, "N", false) == 0)
			{
				mSG_PR[1] = (int)Math.Round(0.0 * ColCon);
				mSG_PR[1] = 0;
				mSG_PR[0, 1] = "PrOrdNo";
				mSG_PR[14] = (int)Math.Round(0.0 * ColCon);
				mSG_PR[14] = 7;
				mSG_PR[0, 14] = "Premium";
				mSG_PR[13] = (int)Math.Round(0.0 * ColCon);
				mSG_PR[13] = 7;
				mSG_PR[0, 13] = "McxRate";
			}
			else
			{
				mSG_PR[1] = (int)Math.Round(1100.0 * ColCon);
				mSG_PR[1] = 0;
				mSG_PR[0, 1] = "PrOrdNo";
				mSG_PR[14] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[14] = 7;
				mSG_PR[0, 14] = "Premium";
				mSG_PR[13] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[13] = 7;
				mSG_PR[0, 13] = "McxRate";
			}
			mSG_PR[2] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[2] = 0;
			mSG_PR[0, 2] = "ItCode";
			mSG_PR[3] = (int)Math.Round(2400.0 * ColCon);
			mSG_PR[3] = 0;
			mSG_PR[0, 3] = "ItName";
			mSG_PR[4] = (int)Math.Round(600.0 * ColCon);
			mSG_PR[4] = 7;
			mSG_PR[0, 4] = "Pcs";
			mSG_PR[5] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[5] = 7;
			mSG_PR[0, 5] = "GrWt";
			mSG_PR[6] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[6] = 7;
			mSG_PR[0, 6] = "OthWt";
			mSG_PR[7] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[7] = 7;
			mSG_PR[0, 7] = "NetWt";
			mSG_PR[8] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[8] = 7;
			mSG_PR[0, 8] = "Touch";
			mSG_PR[9] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[9] = 7;
			mSG_PR[0, 9] = "LTouch";
			mSG_PR[10] = (int)Math.Round(850.0 * ColCon);
			mSG_PR[10] = 7;
			mSG_PR[0, 10] = "LesWt";
			mSG_PR[11] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[11] = 7;
			mSG_PR[0, 11] = "Fine";
			mSG_PR[12] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[12] = 7;
			mSG_PR[0, 12] = "AdjWt";
			mSG_PR[15] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[15] = 7;
			mSG_PR[0, 15] = "Rate";
			mSG_PR[16] = (int)Math.Round(1400.0 * ColCon);
			mSG_PR[16] = 7;
			mSG_PR[0, 16] = "ItAmt";
			mSG_PR[20] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[20] = 7;
			mSG_PR[0, 20] = "OthAmt";
			mSG_PR[21] = (int)Math.Round(1400.0 * ColCon);
			mSG_PR[21] = 7;
			mSG_PR[0, 21] = "NetAmt";
			mSG_PR[22] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[22] = 0;
			mSG_PR[0, 22] = "Counter";
			mSG_PR[23] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[23] = 7;
			mSG_PR[0, 23] = "BagWt";
			mSG_PR[24] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[24] = 7;
			mSG_PR[0, 24] = "PsWt";
			mSG_PR[25] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[25] = 7;
			mSG_PR[0, 25] = "GhtWt";
			mSG_PR[26] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[26] = 7;
			mSG_PR[0, 26] = "West%";
			mSG_PR[33] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[33] = 7;
			mSG_PR[0, 33] = "HmFine";
			mSG_PR[27] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[27] = 7;
			mSG_PR[0, 27] = "SlvFine";
			mSG_PR[28] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[28] = 7;
			mSG_PR[0, 28] = "ConRate";
			mSG_PR[29] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[29] = 7;
			mSG_PR[0, 29] = "Con%";
			mSG_PR[30] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[30] = 7;
			mSG_PR[0, 30] = "Lbr%";
			mSG_PR[17] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[17] = 3;
			mSG_PR[0, 17] = "Ltype";
			mSG_PR[18] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[18] = 7;
			mSG_PR[0, 18] = "LRate";
			mSG_PR[19] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[19] = 7;
			mSG_PR[0, 19] = "LAmt";
			mSG_PR[31] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[31] = 7;
			mSG_PR[0, 31] = "OFine";
			mSG_PR[32] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[32] = 7;
			mSG_PR[0, 32] = "Mrp";
			mSG_PR[34] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[34] = 7;
			mSG_PR[0, 34] = "TotAmt";
			mSG_PR[35] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[35] = 7;
			mSG_PR[0, 35] = "TaxPrc";
			mSG_PR[36] = 0;
			mSG_PR[37] = 0;
			mSG_PR[38] = 0;
			mSG_PR[39] = 0;
			mSG_PR[40] = 0;
			mSG_PR[41] = 0;
			mSG_PR[42] = 0;
			mSG_PR[43] = 0;
			mSG_PR[44] = 0;
			mSG_PR[45] = 0;
			mSG_PR[46] = 0;
			mSG_PR[47] = 0;
			mSG_PR[48] = 0;
			mSG_PR[49] = 0;
			mSG_PR.Row = 1;
			mSG_PR.Col = 1;
			((Control)TEXT_PR).Visible = false;
			DataView dataView = new DataView(DC_Main.RsClDetl);
			if (dataView.Count > 0)
			{
				int num = mSG_PR.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = " BOOK_NAME = 'BUL_REC' AND COL_NAME = '" + mSG_PR[0, DC_Main.M] + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							mSG_PR[DC_Main.M] = 0;
						}
						mSG_PR[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
					DC_Main.M++;
				}
			}
			mSG_PR[0] = (int)Math.Round(325.0 * ColCon);
			mSG_PR[1] = (int)Math.Round(300.0 * ColCon);
			mSG_PR.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd_Pr();
			mSG_PR = null;
			AxMSFlexGrid mSG_PR_TOT = MSG_PR_TOT;
			mSG_PR_TOT.Cols = MSG_PR.Cols;
			int num2 = MSG_PR.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num2)
			{
				mSG_PR_TOT[DC_Main.M] = MSG_PR[DC_Main.M];
				mSG_PR_TOT[DC_Main.M] = MSG_PR[DC_Main.M];
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.MsGridScroll, "N", false) == 0)
			{
				MSG_PR_TOT.ScrollBars = (ScrollBarsSettings)0;
			}
			MSG_PR_TOT_FILL();
			mSG_PR_TOT = null;
		}
	}

	private void CommPassAdd_Pr()
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		mSG_PR[mSG_PR.Row, 0] = Conversions.ToString(mSG_PR.Row);
		mSG_PR[mSG_PR.Row, 17] = "G";
		mSG_PR = null;
	}

	private void TEXT_PR_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_PR_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_05ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f1: Invalid comparison between Unknown and I4
		//IL_0623: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Invalid comparison between Unknown and I4
		//IL_0652: Unknown result type (might be due to invalid IL or missing references)
		//IL_0655: Invalid comparison between Unknown and I4
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		//IL_0683: Invalid comparison between Unknown and I4
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b8: Invalid comparison between Unknown and I4
		//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0939: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		AxMSFlexGrid mSG_PR = MSG_PR;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = mSG_PR.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						mSG_PR[mSG_PR.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					TEXT_PR.Text = "";
					MSG_PR_TOT_FILL();
					BILL_TOTAL();
					Interaction.MsgBox((object)"Record is Deleted....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			if (mSG_PR.Col == 12)
			{
				if (Operators.CompareString(EntryMode, "A", false) == 0)
				{
					TEXT_PR.Text = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 46]) - Conversion.Val(mSG_PR[mSG_PR.Row, 5])), "0.000");
					mSG_PR[mSG_PR.Row, 12] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
				}
				return;
			}
			DC_Main.RsQry = "SELECT * FROM TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + MSG_PR[MSG_PR.Row, 2] + "'";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (mSG_PR.Col == 8)
			{
				if (dataTable.Rows.Count == 0)
				{
					DC_Main.ExeQuteDc("INSERT INTO TOUCH_MAST (CO_CODE,LC_CODE,AC_CODE,AC_IT_CODE,AC_TOUCH,AC_WEST,AC_LBR_RATE) VALUES('" + DC_Main.MCo_code + "' ,'" + DC_Main.MLc_code + "','" + tAcCode.Text + "', '" + mSG_PR[mSG_PR.Row, 2] + "' ," + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + ",0,0) ");
				}
				else
				{
					DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_TOUCH = " + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG_PR[mSG_PR.Row, 2] + "'");
				}
			}
			else if (mSG_PR.Col == 26)
			{
				if (dataTable.Rows.Count == 0)
				{
					DC_Main.ExeQuteDc("INSERT INTO TOUCH_MAST (CO_CODE,LC_CODE,AC_CODE,AC_IT_CODE,AC_TOUCH,AC_WEST,AC_LBR_RATE) VALUES('" + DC_Main.MCo_code + "' ,'" + DC_Main.MLc_code + "','" + tAcCode.Text + "', '" + mSG_PR[mSG_PR.Row, 2] + "' ," + Conversions.ToString(Conversion.Val(mSG_PR[mSG_PR.Row, 8])) + "," + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + ",0) ");
				}
				else
				{
					DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_WEST = " + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG_PR[mSG_PR.Row, 2] + "' ");
				}
			}
			else if (mSG_PR.Col == 18)
			{
				if (dataTable.Rows.Count == 0)
				{
					DC_Main.ExeQuteDc("INSERT INTO TOUCH_MAST (CO_CODE,LC_CODE,AC_CODE,AC_IT_CODE,AC_TOUCH,AC_WEST,AC_LBR_RATE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + tAcCode.Text + "', '" + mSG_PR[mSG_PR.Row, 2] + "' ,0,0," + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + ") ");
				}
				else
				{
					DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_LBR_RATE = " + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG_PR[mSG_PR.Row, 2] + "'");
				}
			}
			Interaction.MsgBox((object)"Touch Update...", (MsgBoxStyle)0, (object)null);
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG_PR.Col > 1)
				{
					Msgleft = true;
					mSG_PR.Col = checked(mSG_PR.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				if (mSG_PR.Col < 21)
				{
					mSG_PR.Col = checked(mSG_PR.Col + 1);
				}
				return;
			}
			if ((int)keyCode == 38)
			{
				if (mSG_PR.Row > 1)
				{
					mSG_PR.Row = checked(mSG_PR.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_PR.Row < mSG_PR.Rows - 1)
					{
						mSG_PR.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG_PR.Col)
					{
					case 1:
						if (Operators.CompareString(TEXT_PR.Text, "", false) == 0)
						{
							break;
						}
						DC_Main.RsQry = "Select A.*, B.IT_TYPE As ItType,B.RATE_TYPE, B.PR_CODE as PrCode From BUL_DATA AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + mSG_PR[mSG_PR.Row, 43] + "' AND CO_BOOK = '" + mSG_PR[mSG_PR.Row, 44] + "' AND OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG_PR[mSG_PR.Row, 45])) + " AND VCH_NO = '" + TEXT_PR.Text + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,C.AC_NAME as CustNameL,B.IT_NAME As ItNameL,A.IT_DESC AS OrderDescL,A.ITM_GWT As ItmWtW,A.ADJ_WT As AdjWtW,A.OLD_SRNO AS SrNoM,A.CO_YEAR As YearM,A.CO_BOOK As BookL,A.IT_CODE As ItCodeL,A.ITM_RATE As RateR,A.PRM_AMT As PremiumR,A.TAX_PRC As TaxR,D.EMP_NAME As EmpNameL,A.AMT_TYPE As CasBnkM FROM ((BUL_DATA AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE)LEFT JOIN EMP_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.EMP_CODE = D.EMP_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' AND A.INOUT_TYPE = 'I' AND A.ITM_GWT-A.ADJ_WT > 0   ORDER BY A.VCH_NO,A.SR_NO";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[16];
							DC_Main.ColWidth[0] = 80.0;
							DC_Main.ColWidth[1] = 220.0;
							DC_Main.ColWidth[2] = 160.0;
							DC_Main.ColWidth[3] = 140.0;
							DC_Main.ColWidth[4] = 90.0;
							DC_Main.ColWidth[5] = 90.0;
							DC_Main.ColWidth[6] = 55.0;
							DC_Main.ColWidth[7] = 0.0;
							DC_Main.ColWidth[8] = 0.0;
							DC_Main.ColWidth[9] = 0.0;
							DC_Main.ColWidth[10] = 90.0;
							DC_Main.ColWidth[11] = 90.0;
							DC_Main.ColWidth[12] = 60.0;
							DC_Main.ColWidth[13] = 130.0;
							DC_Main.ColWidth[14] = 70.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								TEXT_PR.Text = DC_Main.ColValue[0];
								mSG_PR[mSG_PR.Row, 3] = DC_Main.ColValue[1];
								mSG_PR[mSG_PR.Row, 2] = DC_Main.ColValue[9];
								mSG_PR[mSG_PR.Row, 5] = Strings.Format((object)(Conversion.Val(DC_Main.ColValue[4]) - Conversion.Val(DC_Main.ColValue[5])), "0.000");
								mSG_PR[mSG_PR.Row, 7] = Strings.Format((object)(Conversion.Val(DC_Main.ColValue[4]) - Conversion.Val(DC_Main.ColValue[5])), "0.000");
								mSG_PR[mSG_PR.Row, 46] = Strings.Format((object)(Conversion.Val(DC_Main.ColValue[4]) - Conversion.Val(DC_Main.ColValue[5])), "0.000");
								mSG_PR[mSG_PR.Row, 1] = DC_Main.ColValue[0];
								mSG_PR[mSG_PR.Row, 43] = DC_Main.ColValue[7];
								mSG_PR[mSG_PR.Row, 44] = DC_Main.ColValue[8];
								mSG_PR[mSG_PR.Row, 45] = DC_Main.ColValue[6];
								if (Conversions.ToDouble(DC_Main.ColValue[12]) != 0.0)
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
										double num2 = DC_Main.Fnv(ref Value);
										dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
										mSG2_TOTAL[2, 2] = Strings.Format((object)num2, "0.00");
										MSG2_TOTAL[2, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
									}
								}
								((Control)TEXT_PR).Focus();
							}
							else
							{
								mSG_PR[mSG_PR.Row, 1] = "";
								mSG_PR[mSG_PR.Row, 43] = "";
								mSG_PR[mSG_PR.Row, 44] = "";
								mSG_PR[mSG_PR.Row, 45] = "";
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						DC_Main.i = mSG_PR.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG_PR[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_NO"], (object)""));
							mSG_PR[DC_Main.i, 43] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
							mSG_PR[DC_Main.i, 44] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_BOOK"], (object)""));
							mSG_PR[DC_Main.i, 45] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OLD_SRNO"], (object)""));
							mSG_PR[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG_PR[DC_Main.i, 5] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ADJ_WT"]))), "0.000");
							mSG_PR[DC_Main.i, 7] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ADJ_WT"]))), "0.000");
							mSG_PR[DC_Main.i, 46] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ADJ_WT"]))), "0.000");
							mSG_PR[DC_Main.i, 11] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ADJ_WT"]))), "0.000");
							mSG_PR[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["MCX_RATE"])), "0.00");
							mSG_PR[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
							mSG_PR[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["PRM_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TOT_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 37] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
							mSG_PR[DC_Main.i, 36] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
						}
						MsgOldRow = 0;
						CommPassTotal_Pr(mSG_PR.Row);
						MSG_PR_TOT_FILL();
						BILL_TOTAL();
						break;
					case 2:
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_PR.Text + "'"), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "All", false) == 0, (object)"", (object)(" AND IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)""));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "All", false) == 0, (object)"", (object)(" AND IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)"  ORDER BY A.IT_NAME"));
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
									TEXT_PR.Text = DC_Main.ColValue[1];
									mSG_PR[mSG_PR.Row, 2] = DC_Main.ColValue[1];
									mSG_PR[mSG_PR.Row, 3] = DC_Main.ColValue[0];
									mSG_PR[mSG_PR.Row, 36] = DC_Main.ColValue[4];
								}
								((Control)TEXT_PR).Focus();
							}
							return;
						}
						mSG_PR[mSG_PR.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_PR[mSG_PR.Row, 36] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 37] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						if ((Operators.CompareString(EntryMode, "E", false) != 0) & (Operators.CompareString(DC_Main.MsSoftType, "L", false) != 0))
						{
							DC_Main.RsQry = "Select * From TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_IT_CODE = '" + mSG_PR[mSG_PR.Row, 2] + "' AND AC_CODE  = '" + tAcCode.Text + "'";
							DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable2.Rows.Count > 0)
							{
								DataRow dataRow;
								object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_TOUCH"]);
								double num3 = DC_Main.Fnv(ref Value);
								dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_WEST"]);
								double num4 = DC_Main.Fnv(ref Value);
								dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
								if (num3 + num4 != 0.0)
								{
									AxMSFlexGrid obj = mSG_PR;
									int row = mSG_PR.Row;
									Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_TOUCH"]);
									double num5 = DC_Main.Fnv(ref Value);
									dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
									obj[row, 8] = Strings.Format((object)num5, "0.00");
									AxMSFlexGrid obj2 = mSG_PR;
									int row2 = mSG_PR.Row;
									Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_WEST"]);
									double num6 = DC_Main.Fnv(ref Value);
									dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
									obj2[row2, 26] = Strings.Format((object)num6, "0.00");
									if ((Conversion.Val(mSG_PR[mSG_PR.Row, 7]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 8]) != 0.0))
									{
										mSG_PR[mSG_PR.Row, 11] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 7]) * (Conversion.Val(mSG_PR[mSG_PR.Row, 8]) + Conversion.Val(mSG_PR[mSG_PR.Row, 26])) / 100.0), "0.000");
									}
								}
							}
						}
						ItmStk(MSG_PR.Row, "R");
						break;
					case 5:
						if ((Conversion.Val(TEXT_PR.Text) == 0.0) & (Operators.CompareString(mSG_PR[mSG_PR.Row, 37], "P", false) != 0))
						{
							((Control)TEXT_PR).Focus();
							return;
						}
						break;
					case 21:
						if (mSG_PR.Row == mSG_PR.Rows - 1)
						{
							mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
							CommPassTotal_Pr(mSG_PR.Row);
							MsgClearIdtl = true;
							mSG_PR.Rows += 1;
							mSG_PR.Row += 1;
							MsgClearIdtl = false;
							mSG_PR.Col = 1;
							CommPassAdd_Pr();
							((Control)TEXT_PR).Visible = true;
							((Control)TEXT_PR).Focus();
						}
						else
						{
							mSG_PR.Row += 1;
							mSG_PR.Col = 1;
							((Control)TEXT_PR).Visible = true;
							((Control)TEXT_PR).Focus();
						}
						return;
					}
					if (mSG_PR.Col < mSG_PR.Cols - 1)
					{
						mSG_PR.Col += 1;
					}
					((Control)TEXT_PR).Visible = true;
					((Control)TEXT_PR).Focus();
				}
			}
		}
		mSG_PR = null;
	}

	private void MSG_PR_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		checked
		{
			if (mSG_PR.CellWidth >= 0)
			{
				((Control)TEXT_PR).Left = (int)Math.Round((double)((Control)mSG_PR).Left + (double)mSG_PR.CellLeft / 15.0);
				((Control)TEXT_PR).Top = (int)Math.Round((double)((Control)mSG_PR).Top + (double)mSG_PR.CellTop / 15.0);
				((Control)TEXT_PR).Width = (int)Math.Round((double)mSG_PR.CellWidth / 15.0);
				((Control)TEXT_PR).Height = (int)Math.Round((double)mSG_PR.CellHeight / 15.0);
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				((Control)TEXT_PR).Visible = true;
				((TextBoxBase)TEXT_PR).SelectAll();
				((Control)TEXT_PR).Focus();
				mSG_PR = null;
			}
		}
	}

	private void MSG_PR_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		checked
		{
			if (mSG_PR[mSG_PR.Col] == 0)
			{
				TEXT_PR.Text = "";
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = "";
				DC_Main.M = 1;
				while (mSG_PR[mSG_PR.Col] == 0)
				{
					if (Msgleft)
					{
						if (mSG_PR.Col > 1)
						{
							mSG_PR.Col -= 1;
						}
					}
					else if (mSG_PR.Col < mSG_PR.Cols - 1)
					{
						mSG_PR.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 10)
					{
						break;
					}
				}
			}
			if (((mSG_PR.Row == 0) | (mSG_PR.CellWidth <= 0)) || mSG_PR[mSG_PR.Col] == 0)
			{
				return;
			}
			((Control)TEXT_PR).Left = (int)Math.Round((double)((Control)mSG_PR).Left + (double)mSG_PR.CellLeft / 15.0);
			((Control)TEXT_PR).Top = (int)Math.Round((double)((Control)mSG_PR).Top + (double)mSG_PR.CellTop / 15.0);
			((Control)TEXT_PR).Width = (int)Math.Round((double)mSG_PR.CellWidth / 15.0);
			((Control)TEXT_PR).Height = (int)Math.Round((double)mSG_PR.CellHeight / 15.0);
			((Control)TEXT_PR).Visible = true;
			((TextBoxBase)TEXT_PR).ReadOnly = false;
			switch (MSG_PR.Col)
			{
			case 0:
			case 2:
				((TextBoxBase)TEXT_PR).MaxLength = 5;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 3:
				((TextBoxBase)TEXT_PR).MaxLength = 50;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 22:
				((TextBoxBase)TEXT_PR).MaxLength = 3;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 1:
				((TextBoxBase)TEXT_PR).MaxLength = 15;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 17:
				((TextBoxBase)TEXT_PR).MaxLength = 1;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 4:
				((TextBoxBase)TEXT_PR).MaxLength = 8;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0");
				break;
			case 8:
			case 9:
			case 13:
			case 14:
			case 15:
			case 16:
			case 18:
			case 19:
			case 20:
			case 21:
			case 26:
			case 28:
			case 29:
			case 30:
			case 32:
			case 34:
			case 35:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				break;
			case 5:
			case 6:
			case 7:
			case 10:
			case 12:
			case 23:
			case 24:
			case 25:
			case 27:
			case 31:
			case 33:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				break;
			case 11:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				if (Operators.CompareString(DC_Main.MsSlNwtLock, "Y", false) == 0)
				{
					((TextBoxBase)TEXT_PR).ReadOnly = true;
				}
				break;
			}
			mSG_PR = null;
			((TextBoxBase)TEXT_PR).SelectAll();
		}
	}

	private void MSG_PR_LeaveCell(object sender, EventArgs e)
	{
		if (!MsgClearIdtl && MSG_PR.Row != 0 && MSG_PR[MSG_PR.Col] != 0 && ((Control)TEXT_PR).Visible)
		{
			AxMSFlexGrid mSG_PR = MSG_PR;
			switch (MSG_PR.Col)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			case 17:
			case 22:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
				break;
			case 4:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0");
				CommPassTotal_Pr(mSG_PR.Row);
				break;
			case 8:
			case 9:
			case 13:
			case 14:
			case 15:
			case 16:
			case 18:
			case 19:
			case 20:
			case 21:
			case 26:
			case 28:
			case 29:
			case 30:
			case 32:
			case 34:
			case 35:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
				CommPassTotal_Pr(mSG_PR.Row);
				break;
			case 5:
			case 6:
			case 7:
			case 10:
			case 11:
			case 12:
			case 23:
			case 24:
			case 25:
			case 27:
			case 31:
			case 33:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
				CommPassTotal_Pr(mSG_PR.Row);
				break;
			}
			mSG_PR = null;
		}
	}

	private void CommPassTotal_Pr(int CRow)
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
				case 6364:
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
							goto IL_004a;
						case 5:
							goto IL_007c;
						case 6:
							goto IL_00c0;
						case 7:
						case 8:
							goto IL_00d9;
						case 9:
							goto IL_0122;
						case 10:
						case 11:
							goto IL_0169;
						case 12:
							goto IL_01c1;
						case 13:
							goto IL_0212;
						case 14:
							goto IL_022a;
						case 15:
						case 16:
							goto IL_0256;
						case 17:
							goto IL_028a;
						case 18:
							goto IL_02a2;
						case 19:
							goto IL_02ba;
						case 20:
						case 21:
							goto IL_02f0;
						case 22:
							goto IL_0326;
						case 23:
							goto IL_0359;
						case 24:
							goto IL_03ba;
						case 26:
							goto IL_044a;
						case 25:
						case 27:
						case 28:
						case 29:
							goto IL_04a8;
						case 30:
							goto IL_04de;
						case 31:
							goto IL_0511;
						case 32:
							goto IL_0572;
						case 33:
						case 34:
						case 35:
							goto IL_0602;
						case 36:
							goto IL_0639;
						case 37:
							goto IL_066d;
						case 38:
							goto IL_06ce;
						case 39:
						case 40:
						case 41:
							goto IL_075e;
						case 42:
							goto IL_0798;
						case 43:
						case 44:
							goto IL_07f5;
						case 45:
							goto IL_0829;
						case 46:
							goto IL_085d;
						case 47:
						case 48:
							goto IL_0877;
						case 49:
							goto IL_0893;
						case 50:
						case 51:
							goto IL_08dd;
						case 52:
							goto IL_0929;
						case 54:
							goto IL_0985;
						case 55:
							goto IL_09af;
						case 53:
						case 56:
						case 57:
						case 58:
							goto IL_09e6;
						case 59:
							goto IL_0a53;
						case 61:
							goto IL_0a9c;
						case 63:
							goto IL_0aef;
						case 65:
							goto IL_0b4d;
						case 67:
							goto IL_0ba8;
						case 60:
						case 62:
						case 64:
						case 66:
						case 68:
						case 69:
						case 70:
							goto IL_0bfb;
						case 71:
							goto IL_0c11;
						case 72:
							goto IL_0c9c;
						case 73:
							goto IL_0ccd;
						case 74:
							goto IL_0ced;
						case 76:
							goto IL_0d36;
						case 78:
							goto IL_0d8a;
						case 80:
							goto IL_0de9;
						case 82:
							goto IL_0e45;
						case 75:
						case 77:
						case 79:
						case 81:
						case 83:
						case 84:
							goto IL_0e97;
						case 85:
						case 86:
							goto IL_0eeb;
						case 87:
						case 88:
						case 89:
							goto IL_0f23;
						case 90:
							goto IL_0f51;
						case 92:
							goto IL_0f9a;
						case 94:
							goto IL_0fed;
						case 95:
							goto IL_1009;
						case 97:
							goto IL_105a;
						case 100:
							goto IL_10c2;
						case 102:
							goto IL_1130;
						case 91:
						case 93:
						case 96:
						case 98:
						case 99:
						case 101:
						case 103:
						case 104:
						case 105:
							goto IL_1182;
						case 106:
							goto IL_11de;
						case 107:
							goto IL_1205;
						case 108:
						case 109:
							goto IL_123b;
						case 110:
							goto IL_1251;
						case 111:
							goto IL_127e;
						case 112:
							goto IL_12e0;
						case 113:
							goto IL_1342;
						case 114:
							goto IL_136f;
						case 115:
							goto IL_13b5;
						case 117:
							goto IL_1402;
						case 118:
							goto IL_144b;
						case 119:
							goto IL_1467;
						case 121:
							goto IL_14b2;
						case 124:
							goto IL_1514;
						case 125:
							goto IL_155a;
						case 127:
							goto IL_15b1;
						case 128:
							goto IL_15f7;
						case 132:
							goto IL_1648;
						case 116:
						case 120:
						case 122:
						case 123:
						case 126:
						case 129:
						case 130:
						case 131:
						case 133:
						case 134:
						case 135:
							goto IL_1682;
						case 136:
							goto IL_168f;
						case 137:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 138:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_1648:
					num2 = 132;
					val[val.Row, 21] = Strings.Format((object)Conversion.Val(val[val.Row, 34]), "0.00");
					goto IL_1682;
					IL_1682:
					num2 = 135;
					MSG_PR_TOT_FILL();
					goto IL_168f;
					IL_15f7:
					num2 = 128;
					val[val.Row, 18] = Strings.Format((object)(Conversion.Val(val[val.Row, 19]) / Conversion.Val(val[val.Row, 5])), "0.00");
					goto IL_1682;
					IL_168f:
					num2 = 136;
					BILL_TOTAL();
					break;
					IL_000c:
					num2 = 2;
					val = MSG_PR;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Conversion.Val(val[val.Row, 5]) != Conversion.Val(val[val.Row, 38]))
					{
						goto IL_004a;
					}
					goto IL_00d9;
					IL_004a:
					num2 = 4;
					val[val.Row, 38] = Strings.Format((object)Conversion.Val(val[val.Row, 5]), "0.000");
					goto IL_007c;
					IL_007c:
					num2 = 5;
					val[val.Row, 7] = Strings.Format((object)(Conversion.Val(val[val.Row, 5]) - Conversion.Val(val[val.Row, 6])), "0.000");
					goto IL_00c0;
					IL_00c0:
					num2 = 6;
					val[val.Row, 42] = Conversions.ToString(0);
					goto IL_00d9;
					IL_00d9:
					num2 = 8;
					if ((Conversion.Val(val[val.Row, 6]) != 0.0) & (Conversion.Val(val[val.Row, 5]) != 0.0))
					{
						goto IL_0122;
					}
					goto IL_0169;
					IL_0122:
					num2 = 9;
					val[val.Row, 7] = Strings.Format((object)(Conversion.Val(val[val.Row, 5]) - Conversion.Val(val[val.Row, 6])), "0.000");
					goto IL_0169;
					IL_0169:
					num2 = 11;
					if ((Conversion.Val(val[val.Row, 9]) != Conversion.Val(val[val.Row, 48])) & (Conversion.Val(val[val.Row, 7]) != 0.0))
					{
						goto IL_01c1;
					}
					goto IL_0256;
					IL_01c1:
					num2 = 12;
					val[val.Row, 10] = Strings.Format((object)(Conversion.Val(val[val.Row, 7]) * Conversion.Val(val[val.Row, 9]) / 100.0), "0.000");
					goto IL_0212;
					IL_0212:
					num2 = 13;
					val[val.Row, 47] = Conversions.ToString(0);
					goto IL_022a;
					IL_022a:
					num2 = 14;
					val[val.Row, 48] = Conversions.ToString(Conversion.Val(val[val.Row, 9]));
					goto IL_0256;
					IL_0256:
					num2 = 16;
					if (Conversion.Val(val[val.Row, 10]) != Conversion.Val(val[val.Row, 47]))
					{
						goto IL_028a;
					}
					goto IL_02f0;
					IL_028a:
					num2 = 17;
					val[val.Row, 39] = Conversions.ToString(0);
					goto IL_02a2;
					IL_02a2:
					num2 = 18;
					val[val.Row, 42] = Conversions.ToString(0);
					goto IL_02ba;
					IL_02ba:
					num2 = 19;
					val[val.Row, 47] = Strings.Format((object)Conversion.Val(val[val.Row, 10]), "0.000");
					goto IL_02f0;
					IL_02f0:
					num2 = 21;
					if (Conversion.Val(val[val.Row, 7]) != Conversion.Val(val[val.Row, 39]))
					{
						goto IL_0326;
					}
					goto IL_04a8;
					IL_0326:
					num2 = 22;
					val[val.Row, 39] = Strings.Format((object)Conversion.Val(val[val.Row, 7]), "0.000");
					goto IL_0359;
					IL_0359:
					num2 = 23;
					if ((Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 26]) != 0.0) & (Conversion.Val(val[val.Row, 7]) != 0.0))
					{
						goto IL_03ba;
					}
					goto IL_044a;
					IL_03ba:
					num2 = 24;
					val[val.Row, 11] = Strings.Format((object)((Conversion.Val(val[val.Row, 7]) + Conversion.Val(val[val.Row, 25])) * (Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 26])) / 100.0 - Conversion.Val(val[val.Row, 10])), "0.000");
					goto IL_04a8;
					IL_044a:
					num2 = 26;
					val[val.Row, 11] = Strings.Format((object)(Conversion.Val(val[val.Row, 7]) + Conversion.Val(val[val.Row, 25]) - Conversion.Val(val[val.Row, 10])), "0.000");
					goto IL_04a8;
					IL_04a8:
					num2 = 29;
					if (Conversion.Val(val[val.Row, 8]) != Conversion.Val(val[val.Row, 40]))
					{
						goto IL_04de;
					}
					goto IL_0602;
					IL_04de:
					num2 = 30;
					val[val.Row, 40] = Strings.Format((object)Conversion.Val(val[val.Row, 8]), "0.00");
					goto IL_0511;
					IL_0511:
					num2 = 31;
					if ((Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 26]) != 0.0) & (Conversion.Val(val[val.Row, 7]) != 0.0))
					{
						goto IL_0572;
					}
					goto IL_0602;
					IL_0572:
					num2 = 32;
					val[val.Row, 11] = Strings.Format((object)((Conversion.Val(val[val.Row, 7]) + Conversion.Val(val[val.Row, 25])) * (Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 26])) / 100.0 - Conversion.Val(val[val.Row, 10])), "0.000");
					goto IL_0602;
					IL_0602:
					num2 = 35;
					if (Conversion.Val(val[val.Row, 26]) != Conversion.Val(val[val.Row, 41]))
					{
						goto IL_0639;
					}
					goto IL_075e;
					IL_0639:
					num2 = 36;
					val[val.Row, 41] = Strings.Format((object)Conversion.Val(val[val.Row, 26]), "0.00");
					goto IL_066d;
					IL_066d:
					num2 = 37;
					if ((Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 26]) != 0.0) & (Conversion.Val(val[val.Row, 7]) != 0.0))
					{
						goto IL_06ce;
					}
					goto IL_075e;
					IL_06ce:
					num2 = 38;
					val[val.Row, 11] = Strings.Format((object)((Conversion.Val(val[val.Row, 7]) + Conversion.Val(val[val.Row, 25])) * (Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 26])) / 100.0 - Conversion.Val(val[val.Row, 10])), "0.000");
					goto IL_075e;
					IL_075e:
					num2 = 41;
					if (Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 26]) == 0.0)
					{
						goto IL_0798;
					}
					goto IL_07f5;
					IL_0798:
					num2 = 42;
					val[val.Row, 11] = Strings.Format((object)(Conversion.Val(val[val.Row, 7]) + Conversion.Val(val[val.Row, 25]) - Conversion.Val(val[val.Row, 10])), "0.000");
					goto IL_07f5;
					IL_07f5:
					num2 = 44;
					if (Conversion.Val(val[val.Row, 11]) != Conversion.Val(val[val.Row, 49]))
					{
						goto IL_0829;
					}
					goto IL_0877;
					IL_0829:
					num2 = 45;
					val[val.Row, 49] = Strings.Format((object)Conversion.Val(val[val.Row, 11]), "0.000");
					goto IL_085d;
					IL_085d:
					num2 = 46;
					val[val.Row, 42] = Conversions.ToString(0);
					goto IL_0877;
					IL_0877:
					num2 = 48;
					if (Operators.CompareString(DC_Main.MsBulProcess, "N", false) != 0)
					{
						goto IL_0893;
					}
					goto IL_08dd;
					IL_0893:
					num2 = 49;
					val[val.Row, 15] = Strings.Format((object)(Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 14])), "0.00");
					goto IL_08dd;
					IL_08dd:
					num2 = 51;
					if ((Conversion.Val(val[val.Row, 28]) != 0.0) & (Conversion.Val(val[val.Row, 29]) != 0.0))
					{
						goto IL_0929;
					}
					goto IL_0985;
					IL_0929:
					num2 = 52;
					val[val.Row, 15] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 28]) / Conversion.Val(val[val.Row, 29]) * 100.0, 2), "0.00");
					goto IL_09e6;
					IL_0985:
					num2 = 54;
					if (Conversion.Val(val[val.Row, 28]) != 0.0)
					{
						goto IL_09af;
					}
					goto IL_09e6;
					IL_09af:
					num2 = 55;
					val[val.Row, 15] = Strings.Format((object)Conversion.Val(val[val.Row, 28]), "0.00");
					goto IL_09e6;
					IL_09e6:
					num2 = 58;
					if ((Conversion.Val(val[val.Row, 15]) != Conversion.Val(val[val.Row, 42])) & (Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 4]) != 0.0))
					{
						goto IL_0a53;
					}
					goto IL_0bfb;
					IL_0a53:
					num2 = 59;
					switch (val[val.Row, 37])
					{
					case "P":
						break;
					case "1":
						goto IL_0aef;
					case "K":
						goto IL_0b4d;
					default:
						goto IL_0ba8;
					}
					goto IL_0a9c;
					IL_0ba8:
					num2 = 67;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 11]) * Conversion.Val(val[val.Row, 15]), 0), "0.00");
					goto IL_0bfb;
					IL_0b4d:
					num2 = 65;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 11]) * (Conversion.Val(val[val.Row, 15]) / 1000.0), 0), "0.00");
					goto IL_0bfb;
					IL_0aef:
					num2 = 63;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 11]) * (Conversion.Val(val[val.Row, 15]) / 10.0), 0), "0.00");
					goto IL_0bfb;
					IL_0a9c:
					num2 = 61;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 4]) * Conversion.Val(val[val.Row, 15]), 0), "0.00");
					goto IL_0bfb;
					IL_0bfb:
					num2 = 70;
					if (val.Col == 16)
					{
						goto IL_0c11;
					}
					goto IL_0f23;
					IL_0c11:
					num2 = 71;
					if ((Conversion.Val(val[val.Row, 15]) != 0.0) | ((Conversion.Val(val[val.Row, 16]) != Conversion.Val(TEXT_PR.Text)) & (Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 4]) != 0.0)))
					{
						goto IL_0c9c;
					}
					goto IL_0f23;
					IL_0c9c:
					num2 = 72;
					val[val.Row, 16] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
					goto IL_0ccd;
					IL_0ccd:
					num2 = 73;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "HM396NEHM", false) != 0)
					{
						goto IL_0ced;
					}
					goto IL_0eeb;
					IL_0ced:
					num2 = 74;
					switch (val[val.Row, 37])
					{
					case "P":
						break;
					case "1":
						goto IL_0d8a;
					case "K":
						goto IL_0de9;
					default:
						goto IL_0e45;
					}
					goto IL_0d36;
					IL_0e45:
					num2 = 82;
					val[val.Row, 15] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / Conversion.Val(val[val.Row, 11]), DC_Main.MsItmRateRof), "0.00");
					goto IL_0e97;
					IL_0de9:
					num2 = 80;
					val[val.Row, 15] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / Conversion.Val(val[val.Row, 11]) * 1000.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_0e97;
					IL_0d8a:
					num2 = 78;
					val[val.Row, 15] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / Conversion.Val(val[val.Row, 11]) * 10.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_0e97;
					IL_0d36:
					num2 = 76;
					val[val.Row, 15] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / Conversion.Val(val[val.Row, 4]), DC_Main.MsItmRateRof), "0.00");
					goto IL_0e97;
					IL_0e97:
					num2 = 84;
					val[val.Row, 13] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 15]) - Conversion.Val(val[val.Row, 14]), DC_Main.MsItmRateRof), "0.00");
					goto IL_0eeb;
					IL_0eeb:
					num2 = 86;
					val[val.Row, 42] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.00");
					goto IL_0f23;
					IL_0f23:
					num2 = 89;
					if (Conversion.Val(val[val.Row, 18]) != 0.0)
					{
						goto IL_0f51;
					}
					goto IL_1182;
					IL_0f51:
					num2 = 90;
					switch (val[val.Row, 17])
					{
					case "P":
						break;
					case "N":
						goto IL_0fed;
					case "K":
						goto IL_10c2;
					default:
						goto IL_1130;
					}
					goto IL_0f9a;
					IL_1130:
					num2 = 102;
					val[val.Row, 19] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 5]) * Conversion.Val(val[val.Row, 18]), 0), "0.00");
					goto IL_1182;
					IL_10c2:
					num2 = 100;
					val[val.Row, 19] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 7]) + Conversion.Val(val[val.Row, 25])) * (Conversion.Val(val[val.Row, 18]) / 1000.0), 0), "0.00");
					goto IL_1182;
					IL_0fed:
					num2 = 94;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_1009;
					}
					goto IL_105a;
					IL_1009:
					num2 = 95;
					val[val.Row, 19] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 7]) * Conversion.Val(val[val.Row, 18]), 0), "0.00");
					goto IL_1182;
					IL_105a:
					num2 = 97;
					val[val.Row, 19] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 7]) + Conversion.Val(val[val.Row, 25])) * Conversion.Val(val[val.Row, 18]), 0), "0.00");
					goto IL_1182;
					IL_0f9a:
					num2 = 92;
					val[val.Row, 19] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 4]) * Conversion.Val(val[val.Row, 18]), 0), "0.00");
					goto IL_1182;
					IL_1182:
					num2 = 105;
					val[val.Row, 34] = Strings.Format((object)(Conversion.Val(val[val.Row, 19]) + Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 16])), "0.00");
					goto IL_11de;
					IL_11de:
					num2 = 106;
					if (Conversion.Val(val[val.Row, 35]) == 0.0)
					{
						goto IL_1205;
					}
					goto IL_123b;
					IL_1205:
					num2 = 107;
					val[val.Row, 21] = Strings.Format((object)Conversion.Val(val[val.Row, 34]), "0.00");
					goto IL_123b;
					IL_123b:
					num2 = 109;
					if (val.Col == 35)
					{
						goto IL_1251;
					}
					goto IL_1682;
					IL_1251:
					num2 = 110;
					if (Conversion.Val(val[val.Row, 35]) != 0.0)
					{
						goto IL_127e;
					}
					goto IL_1648;
					IL_127e:
					num2 = 111;
					val[val.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 34]) / (Conversion.Val(val[val.Row, 35]) + 100.0) * 100.0, 0), "0.00");
					goto IL_12e0;
					IL_12e0:
					num2 = 112;
					val[val.Row, 19] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 21]) - Conversion.Val(val[val.Row, 16]) - Conversion.Val(val[val.Row, 20]), 0), "0.00");
					goto IL_1342;
					IL_1342:
					num2 = 113;
					if (Conversion.Val(val[val.Row, 19]) != 0.0)
					{
						goto IL_136f;
					}
					goto IL_1682;
					IL_136f:
					num2 = 114;
					if ((Operators.CompareString(val[val.Row, 17], "P", false) == 0) & (Conversion.Val(val[val.Row, 4]) != 0.0))
					{
						goto IL_13b5;
					}
					goto IL_1402;
					IL_13b5:
					num2 = 115;
					val[val.Row, 18] = Strings.Format((object)(Conversion.Val(val[val.Row, 19]) / Conversion.Val(val[val.Row, 4])), "0.00");
					goto IL_1682;
					IL_1402:
					num2 = 117;
					if ((Operators.CompareString(val[val.Row, 17], "N", false) == 0) & (Conversion.Val(val[val.Row, 7]) != 0.0))
					{
						goto IL_144b;
					}
					goto IL_1514;
					IL_144b:
					num2 = 118;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_1467;
					}
					goto IL_14b2;
					IL_1467:
					num2 = 119;
					val[val.Row, 18] = Strings.Format((object)(Conversion.Val(val[val.Row, 19]) / Conversion.Val(val[val.Row, 7])), "0.00");
					goto IL_1682;
					IL_14b2:
					num2 = 121;
					val[val.Row, 18] = Strings.Format((object)(Conversion.Val(val[val.Row, 19]) / (Conversion.Val(val[val.Row, 7]) + Conversion.Val(val[val.Row, 25]))), "0.00");
					goto IL_1682;
					IL_1514:
					num2 = 124;
					if ((Operators.CompareString(val[val.Row, 17], "K", false) == 0) & (Conversion.Val(val[val.Row, 5]) != 0.0))
					{
						goto IL_155a;
					}
					goto IL_15b1;
					IL_155a:
					num2 = 125;
					val[val.Row, 18] = Strings.Format((object)(Conversion.Val(val[val.Row, 19]) / Conversion.Val(val[val.Row, 5]) * 1000.0), "0.00");
					goto IL_1682;
					IL_15b1:
					num2 = 127;
					if ((Operators.CompareString(val[val.Row, 17], "G", false) == 0) & (Conversion.Val(val[val.Row, 5]) != 0.0))
					{
						goto IL_15f7;
					}
					goto IL_1682;
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
				try0001_dispatch = 6364;
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

	private void MSG_PR_TOT_FILL()
	{
		if (UpDown)
		{
			return;
		}
		TotCrFine = 0.0;
		PrOthAmtLess = 0.0;
		AxMSFlexGrid mSG_PR_TOT = MSG_PR_TOT;
		checked
		{
			int num = MSG_PR.Cols - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num)
			{
				mSG_PR_TOT[0, DC_Main.M] = "";
				DC_Main.M++;
			}
			mSG_PR_TOT[0, 1] = "Total :";
			int num2 = MSG_PR.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num2)
			{
				mSG_PR_TOT[0, 4] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 4]) + Conversion.Val(MSG_PR[DC_Main.M, 4]))), "0");
				mSG_PR_TOT[0, 23] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 23]) + Conversion.Val(MSG_PR[DC_Main.M, 23]))), "0.000");
				mSG_PR_TOT[0, 5] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 5]) + Conversion.Val(MSG_PR[DC_Main.M, 5]))), "0.000");
				mSG_PR_TOT[0, 6] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 6]) + Conversion.Val(MSG_PR[DC_Main.M, 6]))), "0.000");
				mSG_PR_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 7]) + Conversion.Val(MSG_PR[DC_Main.M, 7]))), "0.000");
				mSG_PR_TOT[0, 25] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 25]) + Conversion.Val(MSG_PR[DC_Main.M, 25]))), "0.000");
				mSG_PR_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 11]) + Conversion.Val(MSG_PR[DC_Main.M, 11]))), "0.000");
				mSG_PR_TOT[0, 27] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 27]) + Conversion.Val(MSG_PR[DC_Main.M, 27]))), "0.00");
				mSG_PR_TOT[0, 16] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 16]) + Conversion.Val(MSG_PR[DC_Main.M, 16]))), "0.00");
				mSG_PR_TOT[0, 19] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 19]) + Conversion.Val(MSG_PR[DC_Main.M, 19]))), "0.00");
				mSG_PR_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 20]) + Conversion.Val(MSG_PR[DC_Main.M, 20]))), "0.00");
				if (Conversion.Val(MSG_PR[DC_Main.M, 14]) != 0.0)
				{
					PrOthAmtLess += Conversion.Val(MSG_PR[DC_Main.M, 20]);
				}
				mSG_PR_TOT[0, 31] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 31]) + Conversion.Val(MSG_PR[DC_Main.M, 31]))), "0.000");
				mSG_PR_TOT[0, 32] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 32]) + Conversion.Val(MSG_PR[DC_Main.M, 32]))), "0.000");
				mSG_PR_TOT[0, 34] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 34]) + Conversion.Val(MSG_PR[DC_Main.M, 34]))), "0.00");
				mSG_PR_TOT[0, 21] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 21]) + Conversion.Val(MSG_PR[DC_Main.M, 21]))), "0.00");
				if (Conversion.Val(MSG_PR[DC_Main.M, 16]) == 0.0)
				{
					TotCrFine += Conversion.Val(MSG_PR[DC_Main.M, 11]);
				}
				DC_Main.M++;
			}
			mSG_PR_TOT = null;
		}
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 81;
		mSG.Rows = 2;
		mSG.Row = 0;
		mSG[0] = 0;
		mSG[1] = 0;
		mSG.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG[0] = (int)Math.Round(500.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr";
			if (Operators.CompareString(DC_Main.MsBulProcess, "N", false) == 0)
			{
				mSG[1] = 0;
				mSG[1] = 0;
				mSG[0, 1] = "SlOrdNo";
				mSG[15] = 0;
				mSG[15] = 7;
				mSG[0, 15] = "Premium";
				mSG[14] = 0;
				mSG[14] = 7;
				mSG[0, 14] = "McxRate";
			}
			else
			{
				mSG[1] = (int)Math.Round(1100.0 * ColCon);
				mSG[1] = 0;
				mSG[0, 1] = "SlOrdNo";
				mSG[15] = (int)Math.Round(1000.0 * ColCon);
				mSG[15] = 7;
				mSG[0, 15] = "Premium";
				mSG[14] = (int)Math.Round(1000.0 * ColCon);
				mSG[14] = 7;
				mSG[0, 14] = "McxRate";
			}
			mSG[2] = (int)Math.Round(900.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "ItCode";
			mSG[3] = (int)Math.Round(2400.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "ItName";
			mSG[5] = (int)Math.Round(600.0 * ColCon);
			mSG[5] = 7;
			mSG[0, 5] = "Pcs";
			mSG[6] = (int)Math.Round(1100.0 * ColCon);
			mSG[6] = 7;
			mSG[0, 6] = "GrWt";
			mSG[7] = (int)Math.Round(900.0 * ColCon);
			mSG[7] = 7;
			mSG[0, 7] = "OthWt";
			mSG[8] = (int)Math.Round(1100.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "NetWt";
			mSG[9] = (int)Math.Round(750.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "Touch";
			mSG[10] = (int)Math.Round(750.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "LTouch";
			mSG[11] = (int)Math.Round(850.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "LessWt";
			mSG[12] = (int)Math.Round(1100.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "Fine";
			mSG[21] = (int)Math.Round(1000.0 * ColCon);
			mSG[21] = 7;
			mSG[0, 21] = "OthAmt";
			mSG[13] = (int)Math.Round(900.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "AdjWt";
			mSG[16] = (int)Math.Round(1000.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "ItRate";
			mSG[17] = (int)Math.Round(1400.0 * ColCon);
			mSG[17] = 7;
			mSG[0, 17] = "ItAmt";
			mSG[22] = (int)Math.Round(1400.0 * ColCon);
			mSG[22] = 7;
			mSG[0, 22] = "NetAmt";
			mSG[25] = 0;
			mSG[25] = 0;
			mSG[0, 25] = "Counter";
			mSG[26] = 0;
			mSG[26] = 0;
			mSG[0, 26] = "Design";
			mSG[27] = 0;
			mSG[27] = 0;
			mSG[0, 27] = "Size";
			mSG[4] = 0;
			mSG[4] = 0;
			mSG[0, 4] = "HuId";
			mSG[28] = 0;
			mSG[28] = 7;
			mSG[0, 28] = "BagWt";
			mSG[39] = 0;
			mSG[39] = 7;
			mSG[0, 39] = "KrOthWt";
			mSG[40] = 0;
			mSG[40] = 7;
			mSG[0, 40] = "KrNwt";
			mSG[41] = 0;
			mSG[41] = 7;
			mSG[0, 41] = "KrGht%";
			mSG[42] = 0;
			mSG[42] = 7;
			mSG[0, 42] = "KrGht";
			mSG[43] = 0;
			mSG[43] = 7;
			mSG[0, 43] = "KrTouch";
			mSG[44] = 0;
			mSG[44] = 7;
			mSG[0, 44] = "KrWst%";
			mSG[45] = 0;
			mSG[45] = 7;
			mSG[0, 45] = "KrFine";
			mSG[29] = 0;
			mSG[29] = 7;
			mSG[0, 29] = "Ght%";
			mSG[30] = 0;
			mSG[30] = 7;
			mSG[0, 30] = "GhtWt";
			mSG[31] = 0;
			mSG[31] = 7;
			mSG[0, 31] = "West%";
			mSG[32] = 0;
			mSG[32] = 7;
			mSG[0, 32] = "SlvrFine";
			mSG[33] = 0;
			mSG[33] = 7;
			mSG[0, 33] = "ConRate";
			mSG[34] = 0;
			mSG[34] = 7;
			mSG[0, 34] = "Con%";
			mSG[35] = 0;
			mSG[35] = 7;
			mSG[0, 35] = "Lbr%";
			mSG[18] = 750;
			mSG[18] = 3;
			mSG[0, 18] = "LType";
			mSG[19] = (int)Math.Round(900.0 * ColCon);
			mSG[19] = 7;
			mSG[0, 19] = "LbrRate";
			mSG[20] = (int)Math.Round(1000.0 * ColCon);
			mSG[20] = 7;
			mSG[0, 20] = "LbrAmt";
			mSG[36] = 0;
			mSG[36] = 7;
			mSG[0, 36] = "OFine";
			mSG[46] = 0;
			mSG[46] = 7;
			mSG[0, 46] = "KrLRate";
			mSG[47] = 0;
			mSG[47] = 7;
			mSG[0, 47] = "KrLAmt";
			mSG[48] = 0;
			mSG[48] = 7;
			mSG[0, 48] = "KrOthAmt";
			mSG[49] = 0;
			mSG[49] = 7;
			mSG[0, 49] = "PrCost";
			mSG[51] = 0;
			mSG[51] = 7;
			mSG[0, 51] = "TagCost";
			mSG[52] = 0;
			mSG[52] = 7;
			mSG[0, 52] = "Margin";
			mSG[37] = 0;
			mSG[37] = 7;
			mSG[0, 37] = "Mrp";
			mSG[23] = 0;
			mSG[23] = 7;
			mSG[0, 23] = "TotAmt";
			mSG[24] = 0;
			mSG[24] = 7;
			mSG[0, 24] = "Tax%";
			mSG[53] = 0;
			mSG[53] = 3;
			mSG[0, 53] = "Image";
			mSG[38] = 0;
			mSG[38] = 7;
			mSG[0, 38] = "KrCode";
			mSG[54] = 0;
			mSG[55] = 0;
			mSG[56] = 0;
			mSG[57] = 0;
			mSG[58] = 0;
			mSG[59] = 0;
			mSG[50] = 0;
			mSG[60] = 0;
			mSG[61] = 0;
			mSG[62] = 0;
			mSG[63] = 0;
			mSG[64] = 0;
			mSG[65] = 0;
			mSG[66] = 0;
			mSG[67] = 0;
			mSG[68] = 0;
			mSG[69] = 0;
			mSG[70] = 0;
			mSG[71] = 0;
			mSG[72] = 0;
			mSG[75] = 0;
			mSG[73] = 0;
			mSG[74] = 0;
			mSG[76] = 0;
			mSG[77] = 0;
			mSG[78] = 0;
			mSG[79] = 0;
			mSG[80] = 0;
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			DataView dataView = new DataView(DC_Main.RsClDetl);
			if (dataView.Count > 0)
			{
				int num = mSG.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = " BOOK_NAME = 'BUL_ISU' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							mSG[DC_Main.M] = 0;
						}
						mSG[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
					DC_Main.M++;
				}
			}
			MsgLastCol = 22;
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			mSG.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd();
			mSG = null;
			AxMSFlexGrid mSG_TOT = MSG_TOT;
			mSG_TOT.Cols = MSG.Cols;
			int num2 = MSG.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num2)
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
		TotDrFine = 0.0;
		SlOthAmtLess = 0.0;
		AxMSFlexGrid mSG_TOT = MSG_TOT;
		checked
		{
			int num = MSG.Cols - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num)
			{
				mSG_TOT[0, DC_Main.M] = "";
				DC_Main.M++;
			}
			mSG_TOT[0, 26] = "Total :";
			int num2 = MSG.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num2)
			{
				mSG_TOT[0, 5] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 5]) + Conversion.Val(MSG[DC_Main.M, 5]))), "0");
				mSG_TOT[0, 28] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 28]) + Conversion.Val(MSG[DC_Main.M, 28]))), "0.000");
				mSG_TOT[0, 6] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 6]) + Conversion.Val(MSG[DC_Main.M, 6]))), "0.000");
				mSG_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 7]) + Conversion.Val(MSG[DC_Main.M, 7]))), "0.000");
				mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0.000");
				mSG_TOT[0, 30] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 30]) + Conversion.Val(MSG[DC_Main.M, 30]))), "0.000");
				mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[DC_Main.M, 12]))), "0.000");
				mSG_TOT[0, 32] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 32]) + Conversion.Val(MSG[DC_Main.M, 32]))), "0.00");
				mSG_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 17]) + Conversion.Val(MSG[DC_Main.M, 17]))), "0.00");
				mSG_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 20]) + Conversion.Val(MSG[DC_Main.M, 20]))), "0.00");
				mSG_TOT[0, 21] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 21]) + Conversion.Val(MSG[DC_Main.M, 21]))), "0.00");
				mSG_TOT[0, 36] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 36]) + Conversion.Val(MSG[DC_Main.M, 36]))), "0.000");
				mSG_TOT[0, 51] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 51]) + Conversion.Val(MSG[DC_Main.M, 51]))), "0.00");
				mSG_TOT[0, 37] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 37]) + Conversion.Val(MSG[DC_Main.M, 37]))), "0.000");
				mSG_TOT[0, 23] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 23]) + Conversion.Val(MSG[DC_Main.M, 23]))), "0.00");
				mSG_TOT[0, 22] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 22]) + Conversion.Val(MSG[DC_Main.M, 22]))), "0.00");
				mSG_TOT[0, 39] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 39]) + Conversion.Val(MSG[DC_Main.M, 39]))), "0.000");
				mSG_TOT[0, 40] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 40]) + Conversion.Val(MSG[DC_Main.M, 40]))), "0.000");
				mSG_TOT[0, 42] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 42]) + Conversion.Val(MSG[DC_Main.M, 42]))), "0.000");
				mSG_TOT[0, 45] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 45]) + Conversion.Val(MSG[DC_Main.M, 45]))), "0.000");
				mSG_TOT[0, 47] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 47]) + Conversion.Val(MSG[DC_Main.M, 47]))), "0.00");
				mSG_TOT[0, 48] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 48]) + Conversion.Val(MSG[DC_Main.M, 48]))), "0.00");
				mSG_TOT[0, 49] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 49]) + Conversion.Val(MSG[DC_Main.M, 49]))), "0.00");
				if (Conversion.Val(MSG[DC_Main.M, 17]) == 0.0)
				{
					TotDrFine += Conversion.Val(MSG[DC_Main.M, 12]);
				}
				DC_Main.M++;
			}
			mSG_TOT = null;
			NewValTot = Conversion.Val(MSG_TOT[0, 6]) + Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 40]) + Conversion.Val(MSG_TOT[0, 21]) + Conversion.Val(MSG_TOT[0, 20]);
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 18] = DC_Main.MsLbrType;
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			mSG[mSG.Row, 55] = Conversions.ToString(MSG.Row);
		}
		else
		{
			mSG[mSG.Row, 55] = Conversions.ToString(Conversion.Val(mSG[checked(mSG.Rows - 2), 55]) + 1.0);
		}
		mSG[mSG.Row, 60] = "A";
		mSG[mSG.Row, 53] = "N";
		mSG = null;
	}

	private void MSG_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		((Control)TEXT_PR).Visible = false;
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
				mSG.Row = MSG.Row;
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
				if ((mSG.Col != 25) & (mSG.Col != 26) & (mSG.Col != 27))
				{
					mSG[mSG.Row, mSG.Col] = "";
				}
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
			switch (MSG.Col)
			{
			case 0:
			case 38:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 2:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 4:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 25:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 3:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 1:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 26:
			case 27:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 18:
			case 53:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 5:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				break;
			case 9:
			case 10:
			case 29:
			case 31:
			case 32:
			case 35:
			case 43:
			case 44:
			case 52:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 14:
			case 15:
			case 16:
			case 17:
			case 19:
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 33:
			case 34:
			case 37:
			case 46:
			case 47:
			case 48:
			case 49:
			case 51:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 6:
			case 7:
			case 8:
			case 11:
			case 13:
			case 28:
			case 30:
			case 36:
			case 39:
			case 40:
			case 41:
			case 42:
			case 45:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				break;
			case 12:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				if (Operators.CompareString(DC_Main.MsSlNwtLock, "Y", false) == 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			}
			mSG = null;
			((TextBoxBase)TEXT_ENTRY).SelectAll();
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
			case 3:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 26:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 0:
			case 1:
			case 4:
			case 18:
			case 25:
			case 27:
			case 38:
			case 53:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 5:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				break;
			case 9:
			case 10:
			case 29:
			case 31:
			case 32:
			case 35:
			case 43:
			case 44:
			case 52:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 14:
			case 15:
			case 16:
			case 17:
			case 19:
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 33:
			case 34:
			case 37:
			case 46:
			case 47:
			case 48:
			case 49:
			case 51:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 7:
			case 39:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal();
				break;
			case 6:
			case 8:
			case 11:
			case 12:
			case 13:
			case 28:
			case 30:
			case 36:
			case 40:
			case 41:
			case 42:
			case 45:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal();
				break;
			}
			mSG = null;
		}
	}

	private void CommPassTotal()
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
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
				case 7744:
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
							goto IL_0030;
						case 5:
							goto IL_0055;
						case 6:
							goto IL_0077;
						case 8:
						case 9:
						case 10:
						case 11:
							goto IL_00b0;
						case 12:
							goto IL_00e6;
						case 13:
							goto IL_0119;
						case 14:
							goto IL_015e;
						case 15:
							goto IL_01a5;
						case 16:
						case 17:
							goto IL_01bf;
						case 18:
							goto IL_01ea;
						case 19:
							goto IL_0238;
						case 20:
							goto IL_027e;
						case 21:
							goto IL_0296;
						case 22:
						case 23:
						case 24:
							goto IL_02df;
						case 25:
							goto IL_02f4;
						case 26:
							goto IL_0339;
						case 27:
						case 28:
							goto IL_036d;
						case 29:
							goto IL_03a0;
						case 30:
							goto IL_03d3;
						case 31:
						case 32:
						case 33:
							goto IL_041a;
						case 34:
							goto IL_0472;
						case 35:
							goto IL_048a;
						case 36:
							goto IL_04b4;
						case 37:
						case 38:
							goto IL_0507;
						case 39:
							goto IL_053b;
						case 40:
							goto IL_0553;
						case 41:
							goto IL_056b;
						case 42:
						case 43:
							goto IL_05a1;
						case 44:
							goto IL_05ff;
						case 45:
							goto IL_0632;
						case 46:
							goto IL_0666;
						case 47:
							goto IL_06c8;
						case 49:
							goto IL_0759;
						case 48:
						case 50:
						case 51:
						case 52:
							goto IL_07b7;
						case 53:
							goto IL_07ee;
						case 54:
							goto IL_0822;
						case 55:
							goto IL_0884;
						case 56:
						case 57:
						case 58:
							goto IL_0915;
						case 59:
							goto IL_094c;
						case 60:
							goto IL_0980;
						case 61:
							goto IL_09e2;
						case 62:
						case 63:
						case 64:
							goto IL_0a73;
						case 65:
							goto IL_0aae;
						case 66:
						case 67:
							goto IL_0b0b;
						case 68:
							goto IL_0b3f;
						case 69:
							goto IL_0b73;
						case 70:
						case 71:
							goto IL_0b8d;
						case 72:
							goto IL_0bd8;
						case 73:
						case 74:
							goto IL_0c21;
						case 75:
							goto IL_0c58;
						case 76:
							goto IL_0c8c;
						case 77:
							goto IL_0cec;
						case 79:
							goto IL_0d6a;
						case 78:
						case 80:
						case 81:
						case 82:
							goto IL_0da1;
						case 83:
							goto IL_0dd8;
						case 84:
							goto IL_0e0c;
						case 85:
							goto IL_0e6c;
						case 86:
						case 87:
						case 88:
							goto IL_0eea;
						case 89:
							goto IL_0f21;
						case 90:
							goto IL_0f55;
						case 91:
							goto IL_0fb5;
						case 92:
						case 93:
						case 94:
							goto IL_1033;
						case 95:
							goto IL_106e;
						case 96:
						case 97:
							goto IL_10b8;
						case 98:
							goto IL_10d4;
						case 99:
						case 100:
							goto IL_1124;
						case 101:
							goto IL_1170;
						case 103:
							goto IL_11cc;
						case 104:
							goto IL_11f6;
						case 102:
						case 105:
						case 106:
						case 107:
							goto IL_122d;
						case 108:
							goto IL_129a;
						case 110:
							goto IL_12e3;
						case 112:
							goto IL_1336;
						case 114:
							goto IL_1394;
						case 116:
							goto IL_13ef;
						case 109:
						case 111:
						case 113:
						case 115:
						case 117:
						case 118:
							goto IL_1440;
						case 119:
						case 120:
							goto IL_1476;
						case 121:
							goto IL_148c;
						case 122:
							goto IL_1517;
						case 123:
							goto IL_1549;
						case 125:
							goto IL_1592;
						case 127:
							goto IL_15e6;
						case 129:
							goto IL_1645;
						case 131:
							goto IL_16a4;
						case 124:
						case 126:
						case 128:
						case 130:
						case 132:
						case 133:
							goto IL_16f9;
						case 134:
							goto IL_174e;
						case 135:
						case 136:
						case 137:
							goto IL_1789;
						case 138:
							goto IL_17ba;
						case 140:
							goto IL_1806;
						case 142:
							goto IL_185c;
						case 143:
							goto IL_187b;
						case 145:
							goto IL_18cf;
						case 148:
							goto IL_193a;
						case 150:
							goto IL_19ab;
						case 139:
						case 141:
						case 144:
						case 146:
						case 147:
						case 149:
						case 151:
						case 152:
						case 153:
							goto IL_1a00;
						case 154:
							goto IL_1a4b;
						case 155:
							goto IL_1aaa;
						case 156:
							goto IL_1ada;
						case 157:
							goto IL_1af4;
						case 158:
							goto IL_1b0e;
						case 159:
							goto IL_1b45;
						case 160:
						case 161:
							goto IL_1b7f;
						case 162:
							goto IL_1b81;
						case 163:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 7:
						case 164:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_1b45:
					num2 = 159;
					val[val.Row, 22] = Strings.Format((object)Conversion.Val(val[val.Row, 37]), "0.00");
					goto IL_1b7f;
					IL_1b7f:
					val = null;
					goto IL_1b81;
					IL_1b0e:
					num2 = 158;
					val[val.Row, 17] = Strings.Format((object)Conversion.Val(val[val.Row, 37]), "0.00");
					goto IL_1b45;
					IL_1b81:
					num2 = 162;
					MSG_TOT_FILL();
					break;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Operators.CompareString(DC_Main.MsNegativeStkSale, "N", false) == 0)
					{
						goto IL_0030;
					}
					goto IL_00b0;
					IL_0030:
					num2 = 4;
					if ((val.Col == 6) | (val.Col == 7) | (val.Col == 8))
					{
						goto IL_0055;
					}
					goto IL_00b0;
					IL_0055:
					num2 = 5;
					if (Conversion.Val(val[val.Row, 6]) > CurItGwtStk)
					{
						goto IL_0077;
					}
					goto IL_00b0;
					IL_0077:
					num2 = 6;
					Interaction.MsgBox((object)("Negative Stock is Not Allow Curent Stock = " + Strings.Format((object)CurItGwtStk, "0.000") + " "), (MsgBoxStyle)0, (object)null);
					goto end_IL_0001_3;
					IL_00b0:
					num2 = 11;
					if (Conversion.Val(val[val.Row, 6]) != Conversion.Val(val[val.Row, 63]))
					{
						goto IL_00e6;
					}
					goto IL_01bf;
					IL_00e6:
					num2 = 12;
					val[val.Row, 63] = Strings.Format((object)Conversion.Val(val[val.Row, 6]), "0.000");
					goto IL_0119;
					IL_0119:
					num2 = 13;
					val[val.Row, 8] = Strings.Format((object)(Conversion.Val(val[val.Row, 6]) - Conversion.Val(val[val.Row, 7])), "0.000");
					goto IL_015e;
					IL_015e:
					num2 = 14;
					val[val.Row, 40] = Strings.Format((object)(Conversion.Val(val[val.Row, 6]) - Conversion.Val(val[val.Row, 39])), "0.000");
					goto IL_01a5;
					IL_01a5:
					num2 = 15;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_01bf;
					IL_01bf:
					num2 = 17;
					if ((Operators.CompareString(DC_Main.MsMetalType, "S", false) == 0) & (val[28] != 0))
					{
						goto IL_01ea;
					}
					goto IL_02df;
					IL_01ea:
					num2 = 18;
					if ((Conversion.Val(val[val.Row, 28]) != 0.0) & (Conversion.Val(val[val.Row, 6]) != 0.0))
					{
						goto IL_0238;
					}
					goto IL_02df;
					IL_0238:
					num2 = 19;
					val[val.Row, 7] = Strings.Format((object)(Conversion.Val(val[val.Row, 28]) * Conversion.Val(val[val.Row, 5])), "0.000");
					goto IL_027e;
					IL_027e:
					num2 = 20;
					val[val.Row, 72] = Conversions.ToString(0);
					goto IL_0296;
					IL_0296:
					num2 = 21;
					val[val.Row, 8] = Strings.Format((object)(Conversion.Val(val[val.Row, 6]) - Conversion.Val(val[val.Row, 7])), "0.000");
					goto IL_02df;
					IL_02df:
					num2 = 24;
					if (val.Col == 7)
					{
						goto IL_02f4;
					}
					goto IL_041a;
					IL_02f4:
					num2 = 25;
					if ((Conversion.Val(TEXT_ENTRY.Text) == 0.0) & (Conversion.Val(val[val.Row, 7]) != 0.0))
					{
						goto IL_0339;
					}
					goto IL_036d;
					IL_0339:
					num2 = 26;
					val[val.Row, 8] = Strings.Format((object)Conversion.Val(val[val.Row, 6]), "0.000");
					goto IL_036d;
					IL_036d:
					num2 = 28;
					if (Conversion.Val(val[val.Row, 7]) != Conversion.Val(val[val.Row, 72]))
					{
						goto IL_03a0;
					}
					goto IL_041a;
					IL_03a0:
					num2 = 29;
					val[val.Row, 72] = Strings.Format((object)Conversion.Val(val[val.Row, 7]), "0.000");
					goto IL_03d3;
					IL_03d3:
					num2 = 30;
					val[val.Row, 8] = Strings.Format((object)(Conversion.Val(val[val.Row, 6]) - Conversion.Val(TEXT_ENTRY.Text)), "0.000");
					goto IL_041a;
					IL_041a:
					num2 = 33;
					if ((Conversion.Val(val[val.Row, 10]) != Conversion.Val(val[val.Row, 79])) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_0472;
					}
					goto IL_0507;
					IL_0472:
					num2 = 34;
					val[val.Row, 77] = Conversions.ToString(0);
					goto IL_048a;
					IL_048a:
					num2 = 35;
					val[val.Row, 79] = Conversions.ToString(Conversion.Val(val[val.Row, 10]));
					goto IL_04b4;
					IL_04b4:
					num2 = 36;
					val[val.Row, 11] = Strings.Format((object)(Conversion.Val(val[val.Row, 8]) * Conversion.Val(val[val.Row, 10]) / 100.0), "0.000");
					goto IL_0507;
					IL_0507:
					num2 = 38;
					if (Conversion.Val(val[val.Row, 11]) != Conversion.Val(val[val.Row, 77]))
					{
						goto IL_053b;
					}
					goto IL_05a1;
					IL_053b:
					num2 = 39;
					val[val.Row, 64] = Conversions.ToString(0);
					goto IL_0553;
					IL_0553:
					num2 = 40;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_056b;
					IL_056b:
					num2 = 41;
					val[val.Row, 77] = Strings.Format((object)Conversion.Val(val[val.Row, 11]), "0.000");
					goto IL_05a1;
					IL_05a1:
					num2 = 43;
					if (Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 30]) != Conversion.Val(val[val.Row, 64]) + Conversion.Val(val[val.Row, 66]))
					{
						goto IL_05ff;
					}
					goto IL_07b7;
					IL_05ff:
					num2 = 44;
					val[val.Row, 64] = Strings.Format((object)Conversion.Val(val[val.Row, 8]), "0.000");
					goto IL_0632;
					IL_0632:
					num2 = 45;
					val[val.Row, 66] = Strings.Format((object)Conversion.Val(val[val.Row, 30]), "0.000");
					goto IL_0666;
					IL_0666:
					num2 = 46;
					if ((Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 31]) != 0.0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_06c8;
					}
					goto IL_0759;
					IL_06c8:
					num2 = 47;
					val[val.Row, 12] = Strings.Format((object)((Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 30])) * (Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 31])) / 100.0 - Conversion.Val(val[val.Row, 11])), "0.000");
					goto IL_07b7;
					IL_0759:
					num2 = 49;
					val[val.Row, 12] = Strings.Format((object)(Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 30]) - Conversion.Val(val[val.Row, 11])), "0.000");
					goto IL_07b7;
					IL_07b7:
					num2 = 52;
					if (Conversion.Val(val[val.Row, 9]) != Conversion.Val(val[val.Row, 67]))
					{
						goto IL_07ee;
					}
					goto IL_0915;
					IL_07ee:
					num2 = 53;
					val[val.Row, 67] = Strings.Format((object)Conversion.Val(val[val.Row, 9]), "0.00");
					goto IL_0822;
					IL_0822:
					num2 = 54;
					if ((Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 31]) != 0.0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_0884;
					}
					goto IL_0915;
					IL_0884:
					num2 = 55;
					val[val.Row, 12] = Strings.Format((object)((Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 30])) * (Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 31])) / 100.0 - Conversion.Val(val[val.Row, 11])), "0.000");
					goto IL_0915;
					IL_0915:
					num2 = 58;
					if (Conversion.Val(val[val.Row, 31]) != Conversion.Val(val[val.Row, 68]))
					{
						goto IL_094c;
					}
					goto IL_0a73;
					IL_094c:
					num2 = 59;
					val[val.Row, 68] = Strings.Format((object)Conversion.Val(val[val.Row, 31]), "0.00");
					goto IL_0980;
					IL_0980:
					num2 = 60;
					if ((Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 31]) != 0.0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_09e2;
					}
					goto IL_0a73;
					IL_09e2:
					num2 = 61;
					val[val.Row, 12] = Strings.Format((object)((Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 30])) * (Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 31])) / 100.0 - Conversion.Val(val[val.Row, 11])), "0.000");
					goto IL_0a73;
					IL_0a73:
					num2 = 64;
					if (Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 31]) == 0.0)
					{
						goto IL_0aae;
					}
					goto IL_0b0b;
					IL_0aae:
					num2 = 65;
					val[val.Row, 12] = Strings.Format((object)(Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 30]) - Conversion.Val(val[val.Row, 11])), "0.000");
					goto IL_0b0b;
					IL_0b0b:
					num2 = 67;
					if (Conversion.Val(val[val.Row, 12]) != Conversion.Val(val[val.Row, 80]))
					{
						goto IL_0b3f;
					}
					goto IL_0b8d;
					IL_0b3f:
					num2 = 68;
					val[val.Row, 80] = Strings.Format((object)Conversion.Val(val[val.Row, 12]), "0.000");
					goto IL_0b73;
					IL_0b73:
					num2 = 69;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_0b8d;
					IL_0b8d:
					num2 = 71;
					if ((Conversion.Val(val[val.Row, 39]) != 0.0) & (Conversion.Val(val[val.Row, 6]) != 0.0))
					{
						goto IL_0bd8;
					}
					goto IL_0c21;
					IL_0bd8:
					num2 = 72;
					val[val.Row, 40] = Strings.Format((object)(Conversion.Val(val[val.Row, 6]) - Conversion.Val(val[val.Row, 39])), "0.000");
					goto IL_0c21;
					IL_0c21:
					num2 = 74;
					if (Conversion.Val(val[val.Row, 40]) != Conversion.Val(val[val.Row, 69]))
					{
						goto IL_0c58;
					}
					goto IL_0da1;
					IL_0c58:
					num2 = 75;
					val[val.Row, 69] = Strings.Format((object)Conversion.Val(val[val.Row, 40]), "0.000");
					goto IL_0c8c;
					IL_0c8c:
					num2 = 76;
					if ((Conversion.Val(val[val.Row, 43]) + Conversion.Val(val[val.Row, 44]) != 0.0) & (Conversion.Val(val[val.Row, 40]) != 0.0))
					{
						goto IL_0cec;
					}
					goto IL_0d6a;
					IL_0cec:
					num2 = 77;
					val[val.Row, 45] = Strings.Format((object)((Conversion.Val(val[val.Row, 40]) + Conversion.Val(val[val.Row, 42])) * (Conversion.Val(val[val.Row, 43]) + Conversion.Val(val[val.Row, 44])) / 100.0), "0.000");
					goto IL_0da1;
					IL_0d6a:
					num2 = 79;
					val[val.Row, 45] = Strings.Format((object)Conversion.Val(val[val.Row, 40]), "0.000");
					goto IL_0da1;
					IL_0da1:
					num2 = 82;
					if (Conversion.Val(val[val.Row, 43]) != Conversion.Val(val[val.Row, 70]))
					{
						goto IL_0dd8;
					}
					goto IL_0eea;
					IL_0dd8:
					num2 = 83;
					val[val.Row, 70] = Strings.Format((object)Conversion.Val(val[val.Row, 43]), "0.00");
					goto IL_0e0c;
					IL_0e0c:
					num2 = 84;
					if ((Conversion.Val(val[val.Row, 43]) + Conversion.Val(val[val.Row, 44]) != 0.0) & (Conversion.Val(val[val.Row, 40]) != 0.0))
					{
						goto IL_0e6c;
					}
					goto IL_0eea;
					IL_0e6c:
					num2 = 85;
					val[val.Row, 45] = Strings.Format((object)((Conversion.Val(val[val.Row, 40]) + Conversion.Val(val[val.Row, 42])) * (Conversion.Val(val[val.Row, 43]) + Conversion.Val(val[val.Row, 44])) / 100.0), "0.000");
					goto IL_0eea;
					IL_0eea:
					num2 = 88;
					if (Conversion.Val(val[val.Row, 44]) != Conversion.Val(val[val.Row, 71]))
					{
						goto IL_0f21;
					}
					goto IL_1033;
					IL_0f21:
					num2 = 89;
					val[val.Row, 71] = Strings.Format((object)Conversion.Val(val[val.Row, 44]), "0.00");
					goto IL_0f55;
					IL_0f55:
					num2 = 90;
					if ((Conversion.Val(val[val.Row, 43]) + Conversion.Val(val[val.Row, 44]) != 0.0) & (Conversion.Val(val[val.Row, 40]) != 0.0))
					{
						goto IL_0fb5;
					}
					goto IL_1033;
					IL_0fb5:
					num2 = 91;
					val[val.Row, 45] = Strings.Format((object)((Conversion.Val(val[val.Row, 40]) + Conversion.Val(val[val.Row, 42])) * (Conversion.Val(val[val.Row, 43]) + Conversion.Val(val[val.Row, 44])) / 100.0), "0.000");
					goto IL_1033;
					IL_1033:
					num2 = 94;
					if (Conversion.Val(val[val.Row, 43]) + Conversion.Val(val[val.Row, 44]) == 0.0)
					{
						goto IL_106e;
					}
					goto IL_10b8;
					IL_106e:
					num2 = 95;
					val[val.Row, 45] = Strings.Format((object)(Conversion.Val(val[val.Row, 40]) + Conversion.Val(val[val.Row, 42])), "0.000");
					goto IL_10b8;
					IL_10b8:
					num2 = 97;
					if (Operators.CompareString(DC_Main.MsBulProcess, "N", false) != 0)
					{
						goto IL_10d4;
					}
					goto IL_1124;
					IL_10d4:
					num2 = 98;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]), 2), "0.00");
					goto IL_1124;
					IL_1124:
					num2 = 100;
					if ((Conversion.Val(val[val.Row, 33]) != 0.0) & (Conversion.Val(val[val.Row, 34]) != 0.0))
					{
						goto IL_1170;
					}
					goto IL_11cc;
					IL_1170:
					num2 = 101;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 33]) / Conversion.Val(val[val.Row, 34]) * 100.0, 2), "0.00");
					goto IL_122d;
					IL_11cc:
					num2 = 103;
					if (Conversion.Val(val[val.Row, 33]) != 0.0)
					{
						goto IL_11f6;
					}
					goto IL_122d;
					IL_11f6:
					num2 = 104;
					val[val.Row, 16] = Strings.Format((object)Conversion.Val(val[val.Row, 33]), "0.00");
					goto IL_122d;
					IL_122d:
					num2 = 107;
					if ((Conversion.Val(val[val.Row, 16]) != Conversion.Val(val[val.Row, 76])) & (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 5]) != 0.0))
					{
						goto IL_129a;
					}
					goto IL_1476;
					IL_129a:
					num2 = 108;
					switch (val[val.Row, 56])
					{
					case "P":
						break;
					case "1":
						goto IL_1336;
					case "K":
						goto IL_1394;
					default:
						goto IL_13ef;
					}
					goto IL_12e3;
					IL_13ef:
					num2 = 116;
					val[val.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 12]) * Conversion.Val(val[val.Row, 16]), 0), "0.00");
					goto IL_1440;
					IL_1394:
					num2 = 114;
					val[val.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 12]) * (Conversion.Val(val[val.Row, 16]) / 1000.0), 0), "0.00");
					goto IL_1440;
					IL_1336:
					num2 = 112;
					val[val.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 12]) * (Conversion.Val(val[val.Row, 16]) / 10.0), 0), "0.00");
					goto IL_1440;
					IL_12e3:
					num2 = 110;
					val[val.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 5]) * Conversion.Val(val[val.Row, 16]), 0), "0.00");
					goto IL_1440;
					IL_1440:
					num2 = 118;
					val[val.Row, 76] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.00");
					goto IL_1476;
					IL_1476:
					num2 = 120;
					if (val.Col == 17)
					{
						goto IL_148c;
					}
					goto IL_1789;
					IL_148c:
					num2 = 121;
					if ((Conversion.Val(val[val.Row, 16]) != 0.0) | ((Conversion.Val(val[val.Row, 17]) != Conversion.Val(TEXT_ENTRY.Text)) & (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 5]) != 0.0)))
					{
						goto IL_1517;
					}
					goto IL_1789;
					IL_1517:
					num2 = 122;
					val[val.Row, 17] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
					goto IL_1549;
					IL_1549:
					num2 = 123;
					switch (val[val.Row, 56])
					{
					case "P":
						break;
					case "1":
						goto IL_15e6;
					case "K":
						goto IL_1645;
					default:
						goto IL_16a4;
					}
					goto IL_1592;
					IL_16a4:
					num2 = 131;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 12]), DC_Main.MsItmRateRof), "0.00");
					goto IL_16f9;
					IL_1645:
					num2 = 129;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 12]) * 1000.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_16f9;
					IL_15e6:
					num2 = 127;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 12]) * 10.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_16f9;
					IL_1592:
					num2 = 125;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 5]), DC_Main.MsItmRateRof), "0.00");
					goto IL_16f9;
					IL_16f9:
					num2 = 133;
					val[val.Row, 14] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 16]) - Conversion.Val(val[val.Row, 15]), DC_Main.MsItmRateRof), "0.00");
					goto IL_174e;
					IL_174e:
					num2 = 134;
					val[val.Row, 76] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.00");
					goto IL_1789;
					IL_1789:
					num2 = 137;
					if (Conversion.Val(val[val.Row, 19]) != 0.0)
					{
						goto IL_17ba;
					}
					goto IL_1a00;
					IL_17ba:
					num2 = 138;
					switch (val[val.Row, 18])
					{
					case "P":
						break;
					case "N":
						goto IL_185c;
					case "K":
						goto IL_193a;
					default:
						goto IL_19ab;
					}
					goto IL_1806;
					IL_19ab:
					num2 = 150;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 6]) * Conversion.Val(val[val.Row, 19]), 0), "0.00");
					goto IL_1a00;
					IL_193a:
					num2 = 148;
					val[val.Row, 20] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 30])) * (Conversion.Val(val[val.Row, 19]) / 1000.0), 0), "0.00");
					goto IL_1a00;
					IL_185c:
					num2 = 142;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_187b;
					}
					goto IL_18cf;
					IL_187b:
					num2 = 143;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 8]) * Conversion.Val(val[val.Row, 19]), 0), "0.00");
					goto IL_1a00;
					IL_18cf:
					num2 = 145;
					val[val.Row, 20] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 30])) * Conversion.Val(val[val.Row, 19]), 0), "0.00");
					goto IL_1a00;
					IL_1806:
					num2 = 140;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 5]) * Conversion.Val(val[val.Row, 19]), 0), "0.00");
					goto IL_1a00;
					IL_1a00:
					num2 = 153;
					val[val.Row, 49] = Strings.Format((object)(Conversion.Val(val[val.Row, 47]) + Conversion.Val(val[val.Row, 48])), "0.0");
					goto IL_1a4b;
					IL_1a4b:
					num2 = 154;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21]) + Conversion.Val(val[val.Row, 17])), "0.00");
					goto IL_1aaa;
					IL_1aaa:
					num2 = 155;
					if (Conversion.Val(val[val.Row, 37]) != 0.0)
					{
						goto IL_1ada;
					}
					goto IL_1b7f;
					IL_1ada:
					num2 = 156;
					val[val.Row, 20] = "";
					goto IL_1af4;
					IL_1af4:
					num2 = 157;
					val[val.Row, 21] = "";
					goto IL_1b0e;
					end_IL_0001_2:
					break;
				}
				num2 = 163;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 7744;
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
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_07a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a8: Invalid comparison between Unknown and I4
		//IL_07ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bc: Invalid comparison between Unknown and I4
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d1: Invalid comparison between Unknown and I4
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_083a: Unknown result type (might be due to invalid IL or missing references)
		//IL_083d: Invalid comparison between Unknown and I4
		//IL_08b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b9: Invalid comparison between Unknown and I4
		//IL_090a: Unknown result type (might be due to invalid IL or missing references)
		//IL_090d: Invalid comparison between Unknown and I4
		//IL_0799: Unknown result type (might be due to invalid IL or missing references)
		//IL_0965: Unknown result type (might be due to invalid IL or missing references)
		//IL_0968: Invalid comparison between Unknown and I4
		//IL_0c40: Unknown result type (might be due to invalid IL or missing references)
		//IL_1819: Unknown result type (might be due to invalid IL or missing references)
		//IL_22fa: Unknown result type (might be due to invalid IL or missing references)
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
					int num = (int)Math.Round(Conversion.Val(mSG[mSG.Row, 0]));
					int num2 = mSG.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num2)
					{
						mSG[mSG.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					MSG[mSG.Row, 55] = Conversions.ToString(num);
					TEXT_ENTRY.Text = "";
					MSG_TOT_FILL();
					BILL_TOTAL();
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			if (mSG.Col == 13)
			{
				if (Operators.CompareString(EntryMode, "A", false) == 0)
				{
					TEXT_ENTRY.Text = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 78]) - Conversion.Val(mSG[mSG.Row, 6])), "0.000");
					mSG[mSG.Row, 13] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				}
				return;
			}
			if (mSG.Col == 17)
			{
				if ((Conversion.Val(mSG[mSG.Row, 16]) != 0.0) & (Conversion.Val(TEXT_ENTRY.Text) != 0.0))
				{
					mSG[mSG.Row, 6] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(mSG[mSG.Row, 16]), 2), "0.000");
					mSG[mSG.Row, 8] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 6]), "0.000");
					mSG[mSG.Row, 16] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(mSG[mSG.Row, 8])), "0.000");
					mSG[mSG.Row, 22] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
					mSG[mSG.Row, 17] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
					return;
				}
			}
			else
			{
				DC_Main.RsQry = "SELECT * FROM TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + MSG[MSG.Row, 2] + "'";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (mSG.Col == 9)
				{
					if (dataTable.Rows.Count == 0)
					{
						DC_Main.ExeQuteDc("INSERT INTO TOUCH_MAST (CO_CODE,LC_CODE,AC_CODE,AC_IT_CODE,AC_TOUCH,AC_WEST,AC_LBR_RATE) VALUES('" + DC_Main.MCo_code + "' ,'" + DC_Main.MLc_code + "','" + tAcCode.Text + "', '" + mSG[mSG.Row, 2] + "' ," + Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text)) + ",0,0) ");
					}
					else
					{
						DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_TOUCH = " + Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG[mSG.Row, 2] + "'");
					}
				}
				else if (mSG.Col == 31)
				{
					if (dataTable.Rows.Count == 0)
					{
						DC_Main.ExeQuteDc("INSERT INTO TOUCH_MAST (CO_CODE,LC_CODE,AC_CODE,AC_IT_CODE,AC_TOUCH,AC_WEST,AC_LBR_RATE) VALUES('" + DC_Main.MCo_code + "' ,'" + DC_Main.MLc_code + "','" + tAcCode.Text + "', '" + mSG[mSG.Row, 2] + "' ," + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 9])) + "," + Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text)) + ",0) ");
					}
					else
					{
						DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_WEST = " + Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG[mSG.Row, 2] + "' ");
					}
				}
				else if (mSG.Col == 19)
				{
					if (dataTable.Rows.Count == 0)
					{
						DC_Main.ExeQuteDc("INSERT INTO TOUCH_MAST (CO_CODE,LC_CODE,AC_CODE,AC_IT_CODE,AC_TOUCH,AC_WEST,AC_LBR_RATE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + tAcCode.Text + "', '" + mSG[mSG.Row, 2] + "' ,0,0," + Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text)) + ") ");
					}
					else
					{
						DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_LBR_RATE = " + Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG[mSG.Row, 2] + "'");
					}
				}
				Interaction.MsgBox((object)"Touch Update...", (MsgBoxStyle)0, (object)null);
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
					((TextBoxBase)TEXT_ENTRY).SelectAll();
					((Control)TEXT_ENTRY).Focus();
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
					case 1:
						if ((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (mSG.Row == mSG.Rows - 1) & (Operators.CompareString(EntryMode, "A", false) == 0))
						{
							DC_Main.RsQry = "Select A.*, B.IT_TYPE As ItType,B.RATE_TYPE, B.PR_CODE as PrCode From BUL_DATA AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[mSG.Row, 73] + "' AND CO_BOOK = '" + mSG[mSG.Row, 74] + "' AND OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 75])) + " AND VCH_NO = '" + TEXT_ENTRY.Text + "'";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,C.AC_NAME as CustNameL,B.IT_NAME As ItNameL,A.IT_DESC AS OrderDescL,A.ITM_GWT As ItmWtW,A.ADJ_WT As AdjWtW,A.OLD_SRNO AS SrNoM,A.CO_YEAR As YearM,A.CO_BOOK As BookL,A.IT_CODE As ItCodeL,A.ITM_RATE As RateR,A.PRM_AMT As PremiumR,A.TAX_PRC As TaxR,D.EMP_NAME As EmpNameL,A.AMT_TYPE As CasBnkM FROM ((BUL_DATA AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE)LEFT JOIN EMP_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.EMP_CODE = D.EMP_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' AND A.BOOK_NAME = 'BUL SALE' AND A.INOUT_TYPE = 'O' AND A.ITM_GWT-A.ADJ_WT > 0   ORDER BY A.VCH_NO,A.SR_NO";
								DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.ColWidth = new double[16];
								DC_Main.ColWidth[0] = 80.0;
								DC_Main.ColWidth[1] = 220.0;
								DC_Main.ColWidth[2] = 160.0;
								DC_Main.ColWidth[3] = 140.0;
								DC_Main.ColWidth[4] = 90.0;
								DC_Main.ColWidth[5] = 90.0;
								DC_Main.ColWidth[6] = 55.0;
								DC_Main.ColWidth[7] = 0.0;
								DC_Main.ColWidth[8] = 0.0;
								DC_Main.ColWidth[9] = 0.0;
								DC_Main.ColWidth[10] = 90.0;
								DC_Main.ColWidth[11] = 90.0;
								DC_Main.ColWidth[12] = 60.0;
								DC_Main.ColWidth[13] = 130.0;
								DC_Main.ColWidth[14] = 70.0;
								DC_Main.HelpSelect = 1;
								((Form)MyProject.Forms.MS_HELP).ShowDialog();
								if (DC_Main.HelpClose)
								{
									return;
								}
								if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[0];
									mSG[mSG.Row, 3] = DC_Main.ColValue[1];
									mSG[mSG.Row, 2] = DC_Main.ColValue[9];
									mSG[mSG.Row, 6] = Strings.Format((object)(Conversion.Val(DC_Main.ColValue[4]) - Conversion.Val(DC_Main.ColValue[5])), "0.000");
									mSG[mSG.Row, 8] = Strings.Format((object)(Conversion.Val(DC_Main.ColValue[4]) - Conversion.Val(DC_Main.ColValue[5])), "0.000");
									mSG[mSG.Row, 78] = Strings.Format((object)(Conversion.Val(DC_Main.ColValue[4]) - Conversion.Val(DC_Main.ColValue[5])), "0.000");
									mSG[mSG.Row, 1] = DC_Main.ColValue[0];
									mSG[mSG.Row, 73] = DC_Main.ColValue[7];
									mSG[mSG.Row, 74] = DC_Main.ColValue[8];
									mSG[mSG.Row, 75] = DC_Main.ColValue[6];
									if (Conversions.ToDouble(DC_Main.ColValue[12]) != 0.0)
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
											double num3 = DC_Main.Fnv(ref Value);
											dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
											mSG2_TOTAL[2, 2] = Strings.Format((object)num3, "0.00");
											MSG2_TOTAL[2, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
										}
									}
									((Control)TEXT_ENTRY).Focus();
								}
								else
								{
									mSG[mSG.Row, 1] = "";
									mSG[mSG.Row, 73] = "";
									mSG[mSG.Row, 74] = "";
									mSG[mSG.Row, 75] = "";
									mSG[mSG.Row, 50] = "";
									((Control)TEXT_ENTRY).Focus();
								}
								return;
							}
							DC_Main.i = mSG.Row;
							if (DC_Main.Rshlp.Rows.Count > 0)
							{
								mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_NO"], (object)""));
								mSG[DC_Main.i, 73] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
								mSG[DC_Main.i, 74] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_BOOK"], (object)""));
								mSG[DC_Main.i, 75] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OLD_SRNO"], (object)""));
								mSG[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
								mSG[DC_Main.i, 6] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ADJ_WT"]))), "0.000");
								mSG[DC_Main.i, 63] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ADJ_WT"]))), "0.000");
								mSG[DC_Main.i, 8] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ADJ_WT"]))), "0.000");
								mSG[DC_Main.i, 64] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ADJ_WT"]))), "0.000");
								mSG[DC_Main.i, 78] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ADJ_WT"]))), "0.000");
								mSG[DC_Main.i, 12] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ADJ_WT"]))), "0.000");
								mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["MCX_RATE"])), "0.00");
								mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["PRM_AMT"])), "0.00");
								mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
								mSG[DC_Main.i, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
								mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
								mSG[DC_Main.i, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TOT_AMT"])), "0.00");
								mSG[DC_Main.i, 56] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
								mSG[DC_Main.i, 57] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
								mSG[DC_Main.i, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PrCode"], (object)""));
								mSG[DC_Main.i, 62] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PrCode"], (object)""));
							}
							MsgOldRow = 0;
							CommPassTotal();
							MSG_RowColChange(MSG, new EventArgs());
							MSG_TOT_FILL();
							BILL_TOTAL();
						}
						else if (Operators.CompareString(DC_Main.MCo_Book, "261", false) == 0)
						{
							((Control)TEXT_ENTRY).Visible = false;
							MSG_TOT_FILL();
							MSG_PR.Row = 1;
							MSG_PR.Col = 1;
							MSG_PR_EnterCell(MSG_PR, new EventArgs());
							((Control)TEXT_PR).Focus();
							return;
						}
						break;
					case 2:
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_ENTRY.Text + "'"), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "All", false) == 0, (object)"", (object)(" AND IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)""));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "All", false) == 0, (object)"", (object)(" AND IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" ORDER BY A.IT_NAME"));
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
									TEXT_ENTRY.Text = DC_Main.ColValue[1];
									mSG[mSG.Row, 2] = DC_Main.ColValue[1];
									mSG[mSG.Row, 3] = DC_Main.ColValue[0];
									mSG[mSG.Row, 59] = DC_Main.ColValue[3];
									mSG[mSG.Row, 57] = DC_Main.ColValue[4];
									mSG[mSG.Row, 58] = DC_Main.ColValue[4];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG[mSG.Row, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						mSG[mSG.Row, 57] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG[mSG.Row, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						mSG[mSG.Row, 56] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						if (Conversion.Val((object)mSG[28]) != 0.0 && ((Operators.CompareString(mSG[mSG.Row, 60], "A", false) == 0) & (mSG.Row == mSG.Rows - 1)))
						{
							AxMSFlexGrid obj = mSG;
							int row = mSG.Row;
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_BAG_WT"]);
							double num4 = DC_Main.Fnv(ref Value);
							dataRow["IT_BAG_WT"] = RuntimeHelpers.GetObjectValue(Value);
							obj[row, 28] = Strings.Format((object)num4, "0.000");
						}
						lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)" : It Name"));
						ItmStk(MSG.Row, "I");
						if ((Operators.CompareString(mSG[mSG.Row, 60], "E", false) != 0) & (Operators.CompareString(DC_Main.MsSoftType, "L", false) != 0))
						{
							DC_Main.RsQry = "Select * From TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_IT_CODE = '" + mSG[mSG.Row, 2] + "' AND AC_CODE  = '" + tAcCode.Text + "'";
							DataTable dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable3.Rows.Count > 0)
							{
								DataRow dataRow;
								object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["AC_TOUCH"]);
								double num5 = DC_Main.Fnv(ref Value);
								dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["AC_WEST"]);
								double num6 = DC_Main.Fnv(ref Value);
								dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
								if (num5 + num6 != 0.0)
								{
									AxMSFlexGrid obj2 = mSG;
									int row2 = mSG.Row;
									Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["AC_TOUCH"]);
									double num7 = DC_Main.Fnv(ref Value);
									dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
									obj2[row2, 9] = Strings.Format((object)num7, "0.00");
									AxMSFlexGrid obj3 = mSG;
									int row3 = mSG.Row;
									Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["AC_WEST"]);
									double num8 = DC_Main.Fnv(ref Value);
									dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
									obj3[row3, 31] = Strings.Format((object)num8, "0.00");
									if ((Conversion.Val(mSG[mSG.Row, 8]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 9]) != 0.0))
									{
										mSG[mSG.Row, 12] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 8]) * (Conversion.Val(mSG[mSG.Row, 9]) + Conversion.Val(mSG[mSG.Row, 31])) / 100.0), "0.000");
									}
								}
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["AC_LBR_RATE"]);
								double num9 = DC_Main.Fnv(ref Value);
								dataRow["AC_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								if ((num9 != 0.0) & (Conversion.Val(mSG[mSG.Row, 19]) == 0.0))
								{
									AxMSFlexGrid obj4 = mSG;
									int row4 = mSG.Row;
									Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["AC_LBR_RATE"]);
									double num10 = DC_Main.Fnv(ref Value);
									dataRow["AC_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
									obj4[row4, 19] = Strings.Format((object)num10, "0.00");
									mSG[mSG.Row, 18] = Conversions.ToString(Operators.ConcatenateObject(dataTable3.Rows[0]["AC_LBR_TYPE"], (object)""));
								}
							}
							else
							{
								DC_Main.RsQry = "Select IT_TOUCH,IT_WEST From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + mSG[mSG.Row, 2] + "' ";
								dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								if (dataTable3.Rows.Count > 0 && Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["IT_TOUCH"], (object)"")) + Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["IT_WEST"], (object)"")) != 0.0)
								{
									AxMSFlexGrid obj5 = mSG;
									int row5 = mSG.Row;
									DataRow dataRow;
									object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["IT_TOUCH"]);
									double num11 = DC_Main.Fnv(ref Value);
									dataRow["IT_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
									obj5[row5, 9] = Strings.Format((object)num11, "0.00");
									AxMSFlexGrid obj6 = mSG;
									int row6 = mSG.Row;
									Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["IT_WEST"]);
									double num12 = DC_Main.Fnv(ref Value);
									dataRow["IT_WEST"] = RuntimeHelpers.GetObjectValue(Value);
									obj6[row6, 31] = Strings.Format((object)num12, "0.00");
									if ((Conversion.Val(mSG[mSG.Row, 8]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 9]) != 0.0))
									{
										mSG[mSG.Row, 12] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 8]) * (Conversion.Val(mSG[mSG.Row, 9]) + Conversion.Val(mSG[mSG.Row, 31])) / 100.0), "0.000");
									}
								}
							}
						}
						if (Conversion.Val((object)mSG[19]) != 0.0 && Conversions.ToBoolean(Operators.AndObject((object)(Conversion.Val(mSG[mSG.Row, 19]) == 0.0), Operators.CompareObjectNotEqual(DC_Main.Tbl.Rows[0]["IT_LBR_RATE"], (object)0, false))) && ((Operators.CompareString(mSG[mSG.Row, 60], "A", false) == 0) & (mSG.Row == mSG.Rows - 1)))
						{
							AxMSFlexGrid obj7 = mSG;
							int row7 = mSG.Row;
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_LBR_RATE"]);
							double num13 = DC_Main.Fnv(ref Value);
							dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							obj7[row7, 19] = Strings.Format((object)num13, "0.00");
						}
						break;
					case 25:
						DC_Main.RsQry = "Select * From TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' and LC_CODE = '" + DC_Main.MLc_code + "'  AND TABLE_CODE = '" + TEXT_ENTRY.Text + "'";
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
									TEXT_ENTRY.Text = DC_Main.ColValue[1];
									mSG[mSG.Row, 25] = DC_Main.ColValue[1];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
						break;
					case 6:
						if ((Conversion.Val(TEXT_ENTRY.Text) == 0.0) & (Operators.CompareString(mSG[mSG.Row, 56], "P", false) != 0))
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						break;
					case 22:
						if (mSG.Row == mSG.Rows - 1)
						{
							if (Operators.CompareString(DC_Main.MsTchAutoSave, "Y", false) == 0)
							{
								DC_Main.RsQry = "SELECT * FROM TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + MSG[MSG.Row, 2] + "'";
								DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								if (dataTable2.Rows.Count == 0)
								{
									DC_Main.ExeQuteDc("INSERT INTO TOUCH_MAST (CO_CODE,LC_CODE,AC_CODE,AC_IT_CODE,AC_TOUCH,AC_WEST,AC_LBR_RATE,AC_LBR_TYPE) VALUES('" + DC_Main.MCo_code + "' ,'" + DC_Main.MLc_code + "','" + tAcCode.Text + "', '" + mSG[mSG.Row, 2] + "' ," + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 9])) + "," + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 31])) + "," + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 19])) + ",'" + mSG[mSG.Row, 18] + "') ");
								}
								else if ((Conversion.Val(mSG[mSG.Row, 9]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 31]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 19]) != 0.0))
								{
									DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_TOUCH = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 9])) + ", AC_WEST = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 31])) + ",AC_LBR_RATE = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 19])) + ", AC_LBR_TYPE = '" + mSG[mSG.Row, 18] + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG[mSG.Row, 2] + "'");
								}
								else if ((Conversion.Val(mSG[mSG.Row, 9]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 31]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 19]) == 0.0))
								{
									DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_TOUCH = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 9])) + ", AC_WEST = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 31])) + ",AC_LBR_RATE = 0, AC_LBR_TYPE = '' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG[mSG.Row, 2] + "'");
								}
								else if ((Conversion.Val(mSG[mSG.Row, 9]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 19]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 31]) == 0.0))
								{
									DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_TOUCH = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 9])) + ", AC_WEST = 0,AC_LBR_RATE = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 19])) + ", AC_LBR_TYPE = '" + mSG[mSG.Row, 18] + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG[mSG.Row, 2] + "'");
								}
							}
							MsgClear = true;
							mSG.Rows += 1;
							mSG.Row += 1;
							MsgClear = false;
							MSG.Col = 1;
							CommPassAdd();
						}
						else
						{
							mSG.Row += 1;
							MSG.Col = 1;
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

	private void TR_BUL_SALE_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0f7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8a: Expected O, but got Unknown
		//IL_0faf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbe: Expected O, but got Unknown
		//IL_0fe3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff2: Expected O, but got Unknown
		//IL_1031: Unknown result type (might be due to invalid IL or missing references)
		//IL_1036: Unknown result type (might be due to invalid IL or missing references)
		//IL_1040: Expected O, but got Unknown
		//IL_105a: Unknown result type (might be due to invalid IL or missing references)
		//IL_105f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1069: Expected O, but got Unknown
		//IL_1083: Unknown result type (might be due to invalid IL or missing references)
		//IL_1088: Unknown result type (might be due to invalid IL or missing references)
		//IL_1092: Expected O, but got Unknown
		//IL_10ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10bb: Expected O, but got Unknown
		//IL_10d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10da: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e4: Expected O, but got Unknown
		//IL_110c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1113: Expected O, but got Unknown
		//IL_11e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f8: Expected O, but got Unknown
		//IL_1280: Unknown result type (might be due to invalid IL or missing references)
		//IL_1285: Unknown result type (might be due to invalid IL or missing references)
		//IL_128f: Expected O, but got Unknown
		//IL_1328: Unknown result type (might be due to invalid IL or missing references)
		//IL_132d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1333: Expected O, but got Unknown
		//IL_13bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_13cc: Expected O, but got Unknown
		//IL_13f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1400: Expected O, but got Unknown
		//IL_142d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1437: Expected O, but got Unknown
		//IL_1479: Unknown result type (might be due to invalid IL or missing references)
		//IL_1483: Expected O, but got Unknown
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
				AxMSFlexGrid mSG_PR = MSG_PR;
				object? obj15 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG_PR2 = MSG_PR;
				object? obj16 = colorConverter.ConvertFromString("DarkGray");
				mSG_PR2.BackColorBkg = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG_PR3 = MSG_PR;
				object? obj17 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_PR3.BackColorFixed = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG_PR_TOT = MSG_PR_TOT;
				object? obj18 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG_PR_TOT2 = MSG_PR_TOT;
				object? obj19 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT2.BackColorBkg = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG_PR_TOT3 = MSG_PR_TOT;
				object? obj20 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT3.BackColorFixed = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				object? obj21 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				object? obj22 = colorConverter.ConvertFromString("DarkGray");
				mSG2_TOTAL2.BackColorBkg = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				object? obj23 = colorConverter.ConvertFromString("255, 224, 192");
				mSG2_TOTAL3.BackColorFixed = ((obj23 != null) ? ((Color)obj23) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj24 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj25 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj26 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj27 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj28 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj29 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj30 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj31 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG_PR4 = MSG_PR;
				object? obj32 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR4.BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG_PR5 = MSG_PR;
				object? obj33 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_PR5.BackColorBkg = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG_PR6 = MSG_PR;
				object? obj34 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_PR6.BackColorFixed = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG_PR_TOT4 = MSG_PR_TOT;
				object? obj35 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT4.BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG_PR_TOT5 = MSG_PR_TOT;
				object? obj36 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT5.BackColorBkg = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG_PR_TOT6 = MSG_PR_TOT;
				object? obj37 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT6.BackColorFixed = ((obj37 != null) ? ((Color)obj37) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj38 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj38 != null) ? ((Color)obj38) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj39 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj39 != null) ? ((Color)obj39) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj40 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj40 != null) ? ((Color)obj40) : default(Color));
				ComboBox obj41 = cboItemTyp;
				object? obj42 = colorConverter.ConvertFromString("233, 235, 240");
				obj41.BackColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj43 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj43 != null) ? ((Color)obj43) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj44 = lblBook;
				object? obj45 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj44).ForeColor = ((obj45 != null) ? ((Color)obj45) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj46 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj46 != null) ? ((Color)obj46) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj47 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj47 != null) ? ((Color)obj47) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj48 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj48 != null) ? ((Color)obj48) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj49 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj49 != null) ? ((Color)obj49) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj50 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj50 != null) ? ((Color)obj50) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj51 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj51 != null) ? ((Color)obj51) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj52 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj52 != null) ? ((Color)obj52) : default(Color));
				AxMSFlexGrid mSG_PR7 = MSG_PR;
				object? obj53 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR7.BackColor = ((obj53 != null) ? ((Color)obj53) : default(Color));
				AxMSFlexGrid mSG_PR8 = MSG_PR;
				object? obj54 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_PR8.BackColorBkg = ((obj54 != null) ? ((Color)obj54) : default(Color));
				AxMSFlexGrid mSG_PR9 = MSG_PR;
				object? obj55 = colorConverter.ConvertFromString("Cornsilk");
				mSG_PR9.BackColorFixed = ((obj55 != null) ? ((Color)obj55) : default(Color));
				AxMSFlexGrid mSG_PR_TOT7 = MSG_PR_TOT;
				object? obj56 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT7.BackColor = ((obj56 != null) ? ((Color)obj56) : default(Color));
				AxMSFlexGrid mSG_PR_TOT8 = MSG_PR_TOT;
				object? obj57 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT8.BackColorBkg = ((obj57 != null) ? ((Color)obj57) : default(Color));
				AxMSFlexGrid mSG_PR_TOT9 = MSG_PR_TOT;
				object? obj58 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT9.BackColorFixed = ((obj58 != null) ? ((Color)obj58) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj59 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj59 != null) ? ((Color)obj59) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj60 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj60 != null) ? ((Color)obj60) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj61 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj61 != null) ? ((Color)obj61) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj62 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj62 != null) ? ((Color)obj62) : default(Color));
				ComboBox obj63 = cboItemTyp;
				object? obj64 = colorConverter.ConvertFromString("238, 244, 236");
				obj63.BackColor = ((obj64 != null) ? ((Color)obj64) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_PR).AutoSize = false;
				((TextBoxBase)TEXT_ENTRY_2).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_PR).Font = new Font(((Control)TEXT_PR).Font.FontFamily, (float)num3, ((Control)TEXT_PR).Font.Style);
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_ENTRY_2).Font = new Font(((Control)TEXT_ENTRY_2).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY_2).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG_PR.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_PR_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG2_TOTAL.Font = new Font("Segoe UI Semibold", (float)num3, MSG2_TOTAL.Font.Style);
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_IDTL", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_PR", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY_2", false) != 0)))
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
						if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue2, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"chkBillImage", false))
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
				num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
				((Control)chkHuIdPrint).Font = new Font("Segoe UI Semibold", (float)num3, (FontStyle)0);
				if (DC_Main.ScreenHight > 1.0)
				{
					MSG_TOT.ScrollBars = (ScrollBarsSettings)0;
					MSG_PR_TOT.ScrollBars = (ScrollBarsSettings)0;
				}
				((Control)chkWapp).Font = new Font("Segoe UI Semibold", (float)num3, (FontStyle)0);
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
			if (Operators.CompareString(DC_Main.MsWhBillImg, "Y", false) == 0)
			{
				((Control)chkItmImage).Visible = true;
			}
			if ((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) | DC_Main.MsEmailOpen)
			{
				((Control)chkWapp).Visible = true;
			}
			cboBillType.Items.Add((object)"Cash");
			cboBillType.Items.Add((object)"");
			cboBillType.SelectedIndex = 0;
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
		DataTrfr = "N";
		lblItem.Text = "Item :";
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		OldAcCode = "";
		((TextBoxBase)tVchNo).ReadOnly = true;
		nConvPrc.Text = "99.50";
		tEmpCode.Text = "001";
		chkHuIdPrint.Checked = false;
		CurItGwtStk = 0.0;
		tAdd1.Text = "";
		tAdd2.Text = "";
		tAdd3.Text = "";
		tCity.Text = "";
		tMobile.Text = "";
		((Control)PanelAdd).Visible = false;
		UsUPdate = "N";
		UsDelete = "N";
		OldValTot = 0.0;
		NewValTot = 0.0;
		TotCrFine = 0.0;
		TotDrFine = 0.0;
		SlOthAmtLess = 0.0;
		PrOthAmtLess = 0.0;
		OldConRate = 0.0;
		SlSilverFine = 0.0;
		cboBillType.SelectedIndex = 0;
		if (Operators.CompareString(DC_Main.MCo_Book, "260", false) == 0)
		{
			tAcCode.Text = "00045";
		}
		else
		{
			tAcCode.Text = "00050";
		}
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
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		AcGstType = "L";
		lblDiffAmt.Text = "Diff Amount";
		if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
		{
			lblRate.Text = "10gm Rate";
			CurRatePar = "T";
		}
		else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
		{
			lblRate.Text = "Kg Rate";
			CurRatePar = "K";
		}
		else
		{
			lblRate.Text = "1gm Rate";
			CurRatePar = "G";
		}
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)TEXT_PR).Visible = false;
		MSG_CLEAR();
		MSG_PR_CLEAR();
		MSG2_CLEAR();
		if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
		{
			cboItemTyp.SelectedIndex = 0;
		}
		else
		{
			cboItemTyp.SelectedIndex = 1;
		}
		if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
		{
			tEmpCode.Text = DC_Main.MsUserEmpCode;
			tEmpName.Text = DC_Main.MsUserEmpName;
		}
		DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		DC_Main.RsQry = "SELECT * FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
				tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HD_VCH_NO"], (object)""));
				tBillNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BILL_NO"], (object)""));
				tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
				OldAcCode = tAcCode.Text;
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_NAME"], (object)""));
				if ((Operators.CompareString(tAcCode.Text, "00045", false) == 0) | (Operators.CompareString(tAcCode.Text, "00050", false) == 0))
				{
					cboBillType.SelectedIndex = 0;
				}
				else
				{
					cboBillType.SelectedIndex = 1;
				}
				nAcDrAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_AMT"]), "0.00");
				OldAcDrAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_AMT"]), "0.00"));
				nAcCrFine.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CR_FINE"]), "0.000");
				OldAcCrFine = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CR_FINE"]), "0.000"));
				nAcCrAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CR_AMT"]), "0.00");
				OldAcCrAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CR_AMT"]), "0.00"));
				nAcDrFine.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_FINE"]), "0.000");
				OldAcDrFine = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_FINE"]), "0.000"));
				nConvRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CONV_RATE"]), "0.00");
				OldConRate = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CONV_RATE"]), "0.00"));
				nConvPrc.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CONV_PRC"]), "0.00");
				nFineRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["FINE_RATE"]), "0.00");
				OldFineRate = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["FINE_RATE"]), "0.00"));
				CurRatePar = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["RATE_PAR"], (object)""));
				if (Operators.CompareString(CurRatePar, "T", false) == 0)
				{
					lblRate.Text = "10gm Rate";
				}
				else if (Operators.CompareString(CurRatePar, "K", false) == 0)
				{
					lblRate.Text = "Kg Rate";
				}
				else
				{
					lblRate.Text = "1gm Rate";
				}
				nTotFineCr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_FINE_CR"]), "0.000");
				nTotFineDr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_FINE_DR"]), "0.000");
				nFineKsrCr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["KSR_FINE_CR"]), "0.000");
				nFineKsrDr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["KSR_FINE_DR"]), "0.000");
				TotDrFine = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_FINE"]), "0.000"));
				TotCrFine = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_FINE"]), "0.000"));
				if (Operators.ConditionalCompareObjectEqual(RsData.Rows[0]["IT_TYPE"], (object)"G", false))
				{
					cboItemTyp.SelectedIndex = 0;
				}
				else
				{
					cboItemTyp.SelectedIndex = 1;
				}
				MSG2_TOTAL[2, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TAX_CODE"], (object)""));
				MSG2_TOTAL[2, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"]), "0.00");
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[2, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[2, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
				}
				MSG2_TOTAL[3, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TDS_CODE"], (object)""));
				MSG2_TOTAL[3, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TDS_PRC"]), "0.00");
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[3, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[3, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
				}
				MSG2_TOTAL[1, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_NET_AMT"]), "0.00");
				MSG2_TOTAL[2, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_TAX_AMT"]), "0.00");
				MSG2_TOTAL[3, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_TDS_AMT"]), "0.00");
				MSG2_TOTAL[4, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_TOT_AMT"]), "0.00");
				MSG2_TOTAL[5, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CHQ_AMT"]), "0.00");
				MSG2_TOTAL[6, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CARD_AMT"]), "0.00");
				MSG2_TOTAL[7, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CASH_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["SL_KASAR_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["SL_KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[8, 4] = Strings.Format((object)num, "0.00");
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["SL_BILL_OS"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["SL_BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL2[9, 4] = Strings.Format((object)num2, "0.00");
				MSG2_TOTAL[1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_NET_AMT"]), "0.00");
				MSG2_TOTAL[2, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_TAX_AMT"]), "0.00");
				MSG2_TOTAL[3, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_TDS_AMT"]), "0.00");
				MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_TOT_AMT"]), "0.00");
				MSG2_TOTAL[5, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_CHQ_AMT"]), "0.00");
				MSG2_TOTAL[6, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_CARD_AMT"]), "0.00");
				MSG2_TOTAL[7, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_CASH_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["PR_KASAR_AMT"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["PR_KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL3[8, 3] = Strings.Format((object)num3, "0.00");
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["PR_BILL_OS"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["PR_BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL4[9, 3] = Strings.Format((object)num4, "0.00");
				MSG2_TOTAL[5, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[5, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[5, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[5, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[6, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[6, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[6, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
				DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
				}
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
				nCrDays.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CR_DAYS"], (object)""));
				tAdd1.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD1"], (object)""));
				tAdd2.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD2"], (object)""));
				tAdd3.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD3"], (object)""));
				tCity.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CITY"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MOBILE"], (object)""));
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
				MSG_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM RATE_CUT_ISU AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 55] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_NO"], (object)""));
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					mSG[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG[DC_Main.i + 1, 26] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 27] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 72] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LESS_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 79] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LESS_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LESS_WT"])), "0.000");
					mSG[DC_Main.i + 1, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LESS_WT"])), "0.000");
					mSG[DC_Main.i + 1, 67] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LESS_TOUCH"]))), "0.00");
					mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 80] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["SILVER_FINE"])), "0.00");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ADJ_WT"])), "0.000");
					mSG[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 18] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["PRM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["CONV_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["CONV_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["MCX_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 38] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 56] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 57] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 59] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 50] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG[DC_Main.i + 1, 62] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 60] = "E";
					mSG[DC_Main.i + 1, 73] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 74] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_DBCD"], (object)""));
					AxMSFlexGrid obj = mSG;
					int num5 = DC_Main.i + 1;
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.i])["ISU_SRNO"]);
					double num6 = DC_Main.Fnv(ref Value);
					dataRow["ISU_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					obj[num5, 75] = Conversions.ToString(num6);
					mSG.Rows += 1;
					DC_Main.i++;
				}
				if (mSG.Rows > 2)
				{
					mSG.Rows -= 1;
				}
				mSG = null;
				MSG_TOT_FILL();
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE FROM RATE_CUT_REC AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsPrDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG_PR = MSG_PR;
				while (DC_Main.i < RsPrDetl.Rows.Count)
				{
					mSG_PR[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_PR[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					mSG_PR[DC_Main.i + 1, 22] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 4] = Conversions.ToString(RsPrDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_PR[DC_Main.i + 1, 5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LESS_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LESS_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LESS_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LESS_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 40] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_TOUCH"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LESS_TOUCH"]))), "0.00");
					mSG_PR[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ADJ_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["SILVER_FINE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 17] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["PRM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_OTH_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["CONV_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["CONV_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["MCX_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG_PR[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 37] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 36] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["ISU_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 43] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["ISU_YRCD"], (object)""));
					mSG_PR[DC_Main.i + 1, 44] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["ISU_DBCD"], (object)""));
					AxMSFlexGrid obj2 = mSG_PR;
					int num7 = DC_Main.i + 1;
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsPrDetl.Rows[DC_Main.i])["ISU_SRNO"]);
					double num8 = DC_Main.Fnv(ref Value);
					dataRow["ISU_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					obj2[num7, 45] = Conversions.ToString(num8);
					mSG_PR.Rows += 1;
					DC_Main.i++;
				}
				if (mSG_PR.Rows > 2)
				{
					mSG_PR.Rows -= 1;
				}
				mSG_PR = null;
				MSG_PR_TOT_FILL();
				BILL_TOTAL();
				OldValTot = Conversion.Val(MSG_TOT[0, 6]) + Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 40]) + Conversion.Val(MSG_TOT[0, 21]) + Conversion.Val(MSG_TOT[0, 20]) + Conversion.Val(MSG2_TOTAL[9, 3]);
				NewValTot = Conversion.Val(MSG_TOT[0, 6]) + Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 40]) + Conversion.Val(MSG_TOT[0, 21]) + Conversion.Val(MSG_TOT[0, 20]) + Conversion.Val(MSG2_TOTAL[9, 3]);
				EntryMode = "E";
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

	private void TR_BUL_SALE_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_BUL_SALE_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
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
						if (Operators.CompareString(tAcCode.Text, "", false) == 0)
						{
							Interaction.MsgBox((object)"Please Insert Party and try", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							((Control)tAcCode).Focus();
							goto end_IL_0001;
						}
						if (Operators.CompareString(tVchNo.Text, "", false) == 0)
						{
							Interaction.MsgBox((object)"Please Insert VchNo and try", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						MSG_TOT_FILL();
						MSG_PR_TOT_FILL();
						ProjectData.ClearProjectError();
						num2 = 2;
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							DC_Main.RsQry = "SELECT * FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count > 0)
							{
								DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
							DC_Main.RsQry = "UPDATE BUL_DATA SET BUL_DATA.ADJ_WT = BUL_DATA.ADJ_WT - B.ITM_GWT-B.ADJ_WT FROM BUL_DATA,RATE_CUT_ISU AS B WHERE BUL_DATA.CO_CODE = B.CO_CODE AND BUL_DATA.LC_CODE = B.LC_CODE AND BUL_DATA.CO_YEAR = B.ISU_YRCD  AND BUL_DATA.CO_BOOK = B.ISU_DBCD AND BUL_DATA.VCH_NO = B.ISU_NO AND BUL_DATA.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							DC_Main.RsQry = "UPDATE BUL_DATA SET BUL_DATA.ADJ_WT = BUL_DATA.ADJ_WT - B.ITM_GWT-B.ADJ_WT FROM BUL_DATA,RATE_CUT_REC AS B WHERE BUL_DATA.CO_CODE = B.CO_CODE AND BUL_DATA.LC_CODE = B.LC_CODE AND BUL_DATA.CO_YEAR = B.ISU_YRCD  AND BUL_DATA.CO_BOOK = B.ISU_DBCD AND BUL_DATA.VCH_NO = B.ISU_NO AND BUL_DATA.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						DC_Main.ExeQuteDc("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						if ((Conversion.Val(MSG_TOT[0, 37]) != 0.0) | (Conversion.Val(MSG_TOT[0, 5]) + Conversion.Val(MSG_TOT[0, 4]) + Conversion.Val(MSG2_TOTAL[1, 3]) + Conversion.Val(MSG2_TOTAL[1, 4]) + Conversion.Val(nTotFineCr.Text) + Conversion.Val(nTotFineDr.Text) != 0.0))
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
							DC_Main.RsQry = "SELECT * FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
							RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.MsInsertData();
							DataRow dataRow2 = RsData.NewRow();
							dataRow2["CO_CODE"] = DC_Main.MCo_code;
							dataRow2["LC_CODE"] = DC_Main.MLc_code;
							dataRow2["CO_YEAR"] = DC_Main.MCo_year;
							dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
							dataRow2["VCH_NO"] = tVchNo.Text;
							dataRow2["AC_CODE"] = tAcCode.Text;
							dataRow2["VCH_DATE"] = mVchDate.Text;
							dataRow2["BILL_NO"] = tBillNo.Text;
							dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
							dataRow2["AC_CODE"] = tAcCode.Text;
							dataRow2["AC_NAME"] = tAcName.Text;
							dataRow2["DR_AMT"] = Conversion.Val(nAcDrAmt.Text);
							dataRow2["CR_FINE"] = Conversion.Val(nAcCrFine.Text);
							dataRow2["CR_AMT"] = Conversion.Val(nAcCrAmt.Text);
							dataRow2["DR_FINE"] = Conversion.Val(nAcDrFine.Text);
							dataRow2["CONV_RATE"] = Conversion.Val(nConvRate.Text);
							dataRow2["CONV_PRC"] = Conversion.Val(nConvPrc.Text);
							dataRow2["RATE_PAR"] = CurRatePar;
							dataRow2["FINE_RATE"] = Conversion.Val(nFineRate.Text);
							dataRow2["SL_FINE"] = TotDrFine + Conversion.Val(MSG_TOT[0, 36]);
							dataRow2["PR_FINE"] = TotCrFine + Conversion.Val(MSG_PR_TOT[0, 31]);
							dataRow2["SILVER_FINE_DR"] = Conversion.Val(MSG_TOT[0, 32]);
							dataRow2["SILVER_FINE_CR"] = Conversion.Val(MSG_PR_TOT[0, 27]);
							dataRow2["TOT_FINE_CR"] = Conversion.Val(nTotFineCr.Text);
							dataRow2["TOT_FINE_DR"] = Conversion.Val(nTotFineDr.Text);
							dataRow2["KSR_FINE_CR"] = Conversion.Val(nFineKsrCr.Text);
							dataRow2["KSR_FINE_DR"] = Conversion.Val(nFineKsrDr.Text);
							dataRow2["IT_TYPE"] = Strings.Mid(cboItemTyp.Text, 1, 1);
							dataRow2["SL_ITM_AMT"] = Conversion.Val(MSG_TOT[0, 17]);
							dataRow2["SL_LBR_AMT"] = Conversion.Val(MSG_TOT[0, 20]);
							dataRow2["SL_OTH_AMT"] = Conversion.Val(MSG_TOT[0, 21]) - SlOthAmtLess;
							dataRow2["TAX_PRC"] = Conversion.Val(MSG2_TOTAL[2, 2]);
							dataRow2["TAX_CODE"] = MSG2_TOTAL[2, 5];
							dataRow2["TDS_PRC"] = Conversion.Val(MSG2_TOTAL[3, 2]);
							dataRow2["TDS_CODE"] = MSG2_TOTAL[3, 5];
							dataRow2["SL_NET_AMT"] = Conversion.Val(MSG2_TOTAL[1, 4]);
							dataRow2["SL_TAX_AMT"] = Conversion.Val(MSG2_TOTAL[2, 4]);
							dataRow2["SL_TDS_AMT"] = Conversion.Val(MSG2_TOTAL[3, 4]);
							dataRow2["SL_TOT_AMT"] = Conversion.Val(MSG2_TOTAL[4, 4]);
							dataRow2["SL_CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[5, 4]);
							dataRow2["SL_CARD_AMT"] = Conversion.Val(MSG2_TOTAL[6, 4]);
							dataRow2["SL_CASH_AMT"] = Conversion.Val(MSG2_TOTAL[7, 4]);
							dataRow2["SL_ADV_AMT"] = 0;
							dataRow2["SL_KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[8, 4]);
							dataRow2["SL_BILL_OS"] = Conversion.Val(MSG2_TOTAL[9, 4]);
							dataRow2["PR_ITM_AMT"] = Conversion.Val(MSG_PR_TOT[0, 16]);
							dataRow2["PR_LBR_AMT"] = Conversion.Val(MSG_PR_TOT[0, 19]);
							dataRow2["PR_OTH_AMT"] = Conversion.Val(MSG_PR_TOT[0, 20]) - PrOthAmtLess;
							dataRow2["PR_NET_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
							dataRow2["PR_TAX_AMT"] = Conversion.Val(MSG2_TOTAL[2, 3]);
							dataRow2["PR_TDS_AMT"] = Conversion.Val(MSG2_TOTAL[3, 3]);
							dataRow2["PR_TOT_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
							dataRow2["PR_CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
							dataRow2["PR_CARD_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
							dataRow2["PR_ADV_AMT"] = 0;
							dataRow2["PR_CASH_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
							dataRow2["PR_KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);
							dataRow2["PR_BILL_OS"] = Conversion.Val(MSG2_TOTAL[9, 3]);
							dataRow2["CARD_AC"] = MSG2_TOTAL[6, 5];
							dataRow2["BANK_AC"] = MSG2_TOTAL[5, 5];
							dataRow2["CHQ_NO"] = MSG2_TOTAL[5, 2];
							dataRow2["ADD1"] = tAdd1.Text;
							dataRow2["ADD2"] = tAdd2.Text;
							dataRow2["ADD3"] = tAdd3.Text;
							dataRow2["CITY"] = tCity.Text;
							dataRow2["MOBILE"] = tMobile.Text;
							dataRow2["CR_DAYS"] = Conversion.Val(nCrDays.Text);
							dataRow2["INT_DAYS"] = 0;
							dataRow2["INT_PRC_FINE"] = 0;
							dataRow2["INT_FINE"] = 0;
							dataRow2["EMP_CODE"] = tEmpCode.Text;
							dataRow2["VCH_DESC"] = tVchDesc.Text;
							dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
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
						DC_Main.RsQry = "SELECT * FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow3 = RsDetl.NewRow();
						int num3 = MSG.Rows - 1;
						DC_Main.i = 1;
						while (DC_Main.i <= num3)
						{
							AxMSFlexGrid mSG = MSG;
							if (((Operators.CompareString(mSG[DC_Main.i, 2], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 37]) != 0.0)) | (Conversion.Val(mSG[DC_Main.i, 6]) + Conversion.Val(mSG[DC_Main.i, 22]) + Conversion.Val(mSG[DC_Main.i, 21]) != 0.0))
							{
								dataRow3["CO_CODE"] = DC_Main.MCo_code;
								dataRow3["LC_CODE"] = DC_Main.MLc_code;
								dataRow3["CO_YEAR"] = DC_Main.MCo_year;
								dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
								dataRow3["VCH_NO"] = tVchNo.Text;
								dataRow3["VCH_DATE"] = mVchDate.Text;
								dataRow3["HD_VCH_NO"] = tHdVchNo.Text;
								dataRow3["AC_CODE"] = tAcCode.Text;
								dataRow3["VCH_TYPE"] = FormBookSname;
								dataRow3["INOUT_TYPE"] = FormBookInOut;
								dataRow3["ENTRY_TYPE"] = "W";
								dataRow3["BOOK_NAME"] = FormMainBook;
								dataRow3["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
								dataRow3["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 55]);
								dataRow3["IT_CODE"] = mSG[DC_Main.i, 2];
								dataRow3["ITM_REMARK"] = mSG[DC_Main.i, 3];
								dataRow3["TAG_NO"] = "N";
								dataRow3["TBL_CODE"] = mSG[DC_Main.i, 25];
								dataRow3["DESIGN_NO"] = mSG[DC_Main.i, 26];
								dataRow3["ITM_SIZE"] = mSG[DC_Main.i, 27];
								dataRow3["HM_ID"] = mSG[DC_Main.i, 4];
								dataRow3["BAG_WT"] = Conversion.Val(mSG[DC_Main.i, 28]);
								dataRow3["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 5]);
								dataRow3["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 6]);
								dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 7]);
								dataRow3["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 8]);
								dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 30]);
								dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 9]);
								dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 31]);
								dataRow3["LESS_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 10]);
								dataRow3["LESS_WT"] = Conversion.Val(mSG[DC_Main.i, 11]);
								dataRow3["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 12]);
								dataRow3["SILVER_FINE"] = Conversion.Val(mSG[DC_Main.i, 32]);
								dataRow3["ADJ_WT"] = Conversion.Val(mSG[DC_Main.i, 13]);
								dataRow3["LBR_PRC"] = Conversion.Val(mSG[DC_Main.i, 35]);
								dataRow3["LBR_TYPE"] = mSG[DC_Main.i, 18];
								dataRow3["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 19]);
								dataRow3["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 20]);
								dataRow3["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 21]);
								dataRow3["PRM_AMT"] = Conversion.Val(mSG[DC_Main.i, 15]);
								dataRow3["ITM_OTH_RATE"] = 0;
								dataRow3["ITM_OTH_FINE"] = Conversion.Val(mSG[DC_Main.i, 36]);
								dataRow3["CONV_RATE"] = Conversion.Val(mSG[DC_Main.i, 33]);
								dataRow3["CONV_PRC"] = Conversion.Val(mSG[DC_Main.i, 34]);
								dataRow3["MCX_RATE"] = Conversion.Val(mSG[DC_Main.i, 14]);
								dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 16]);
								dataRow3["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 17]);
								dataRow3["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 37]);
								dataRow3["TOT_AMT"] = Conversion.Val(mSG[DC_Main.i, 23]);
								dataRow3["TAX_PRC"] = Conversion.Val(mSG[DC_Main.i, 24]);
								dataRow3["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 22]);
								dataRow3["KR_NET_WT"] = Conversion.Val(mSG[DC_Main.i, 40]);
								dataRow3["KR_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 43]);
								dataRow3["KR_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 44]);
								dataRow3["KR_FINE"] = Conversion.Val(mSG[DC_Main.i, 45]);
								dataRow3["KR_NAME"] = mSG[DC_Main.i, 38];
								dataRow3["RATE_TYPE"] = mSG[DC_Main.i, 56];
								dataRow3["IT_TYPE"] = mSG[DC_Main.i, 57];
								dataRow3["PR_CODE"] = mSG[DC_Main.i, 59];
								dataRow3["VCH_SRNO"] = Conversion.Val(mSG[DC_Main.i, 50]);
								dataRow3["ISU_NO"] = mSG[DC_Main.i, 1];
								dataRow3["ISU_LC_CODE"] = DC_Main.MLc_code;
								dataRow3["ISU_YRCD"] = mSG[DC_Main.i, 73];
								dataRow3["ISU_DBCD"] = mSG[DC_Main.i, 74];
								dataRow3["ISU_SRNO"] = Conversion.Val(mSG[DC_Main.i, 75]);
								dataRow3["HM_ID2"] = "";
								dataRow3["HM_ID3"] = "";
								dataRow3["HM_ID4"] = "";
								dataRow3["HM_ID_WT"] = Conversion.Val(mSG[DC_Main.i, 6]);
								dataRow3["HM_ID2_WT"] = 0;
								dataRow3["HM_ID3_WT"] = 0;
								dataRow3["HM_ID4_WT"] = 0;
								dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
								dataRow3["MAIN_USER"] = MainUser;
								RsDetl.Rows.Add(dataRow3);
								((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
								RsDetl.Clear();
							}
							mSG = null;
							DC_Main.i++;
						}
						DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
						DC_Main.RsQry = "SELECT * FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
						RsPrDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow4 = RsPrDetl.NewRow();
						int num4 = MSG_PR.Rows - 1;
						DC_Main.i = 1;
						while (DC_Main.i <= num4)
						{
							AxMSFlexGrid mSG_PR = MSG_PR;
							if ((Conversion.Val(MSG_PR[DC_Main.i, 7]) + Conversion.Val(MSG_PR[DC_Main.i, 21]) != 0.0) & (Operators.CompareString(MSG_PR[DC_Main.i, 2], "", false) != 0))
							{
								dataRow4["CO_CODE"] = DC_Main.MCo_code;
								dataRow4["LC_CODE"] = DC_Main.MLc_code;
								dataRow4["CO_YEAR"] = DC_Main.MCo_year;
								dataRow4["CO_BOOK"] = DC_Main.MCo_Book;
								dataRow4["VCH_NO"] = tVchNo.Text;
								dataRow4["VCH_DATE"] = mVchDate.Text;
								dataRow4["HD_VCH_NO"] = tHdVchNo.Text;
								dataRow4["AC_CODE"] = tAcCode.Text;
								dataRow4["VCH_TYPE"] = FormBookSname;
								dataRow4["INOUT_TYPE"] = FormBookInOut;
								dataRow4["ENTRY_TYPE"] = "P";
								dataRow4["BOOK_NAME"] = FormMainBook;
								dataRow4["SR_NO"] = Conversion.Val(mSG_PR[DC_Main.i, 0]);
								dataRow4["OLD_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 0]);
								dataRow4["IT_CODE"] = mSG_PR[DC_Main.i, 2];
								dataRow4["ITM_REMARK"] = mSG_PR[DC_Main.i, 3];
								dataRow4["TAG_NO"] = "N";
								dataRow4["TBL_CODE"] = mSG_PR[DC_Main.i, 22];
								dataRow4["BAG_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 23]);
								dataRow4["ITM_PCS"] = Conversion.Val(mSG_PR[DC_Main.i, 4]);
								dataRow4["ITM_GWT"] = Conversion.Val(mSG_PR[DC_Main.i, 5]);
								dataRow4["ITM_OTH_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 6]);
								dataRow4["ITM_NWT"] = Conversion.Val(mSG_PR[DC_Main.i, 7]);
								dataRow4["ITM_GHT_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 25]);
								dataRow4["ITM_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 8]);
								dataRow4["ITM_WEST_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 26]);
								dataRow4["LESS_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 9]);
								dataRow4["LESS_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 10]);
								dataRow4["ITM_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 11]);
								dataRow4["ADJ_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 12]);
								dataRow4["SILVER_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 27]);
								dataRow4["LBR_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 30]);
								dataRow4["LBR_TYPE"] = mSG_PR[DC_Main.i, 17];
								dataRow4["LBR_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 18]);
								dataRow4["LBR_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 19]);
								dataRow4["OTH_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 20]);
								dataRow4["PRM_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 14]);
								dataRow4["ITM_OTH_RATE"] = 0;
								dataRow4["ITM_OTH_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 31]);
								dataRow4["CONV_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 28]);
								dataRow4["CONV_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 29]);
								dataRow4["MCX_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 13]);
								dataRow4["ITM_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 15]);
								dataRow4["ITM_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 16]);
								dataRow4["ITM_MRP"] = Conversion.Val(mSG_PR[DC_Main.i, 32]);
								dataRow4["TOT_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 34]);
								dataRow4["TAX_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 35]);
								dataRow4["NET_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 21]);
								dataRow4["RATE_TYPE"] = mSG_PR[DC_Main.i, 37];
								dataRow4["IT_TYPE"] = mSG_PR[DC_Main.i, 36];
								dataRow4["ISU_NO"] = mSG_PR[DC_Main.i, 1];
								dataRow4["ISU_LC_CODE"] = DC_Main.MLc_code;
								dataRow4["ISU_YRCD"] = mSG_PR[DC_Main.i, 43];
								dataRow4["ISU_DBCD"] = mSG_PR[DC_Main.i, 44];
								dataRow4["ISU_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 45]);
								dataRow4["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
								dataRow4["WITH_STOCK"] = "Y";
								dataRow4["MAIN_USER"] = MainUser;
								RsPrDetl.Rows.Add(dataRow4);
								((DbDataAdapter)(object)DC_Main.Da).Update(RsPrDetl);
								RsPrDetl.Clear();
							}
							mSG_PR = null;
							DC_Main.i++;
						}
						DC_Main.RsQry = "UPDATE BUL_DATA SET BUL_DATA.ADJ_WT = BUL_DATA.ADJ_WT + B.ITM_GWT+B.ADJ_WT FROM BUL_DATA,RATE_CUT_ISU AS B WHERE BUL_DATA.CO_CODE = B.CO_CODE AND BUL_DATA.LC_CODE = B.LC_CODE AND BUL_DATA.CO_YEAR = B.ISU_YRCD  AND BUL_DATA.CO_BOOK = B.ISU_DBCD AND BUL_DATA.VCH_NO = B.ISU_NO AND BUL_DATA.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = "UPDATE BUL_DATA SET BUL_DATA.ADJ_WT = BUL_DATA.ADJ_WT + B.ITM_GWT+B.ADJ_WT FROM BUL_DATA,RATE_CUT_REC AS B WHERE BUL_DATA.CO_CODE = B.CO_CODE AND BUL_DATA.LC_CODE = B.LC_CODE AND BUL_DATA.CO_YEAR = B.ISU_YRCD  AND BUL_DATA.CO_BOOK = B.ISU_DBCD AND BUL_DATA.VCH_NO = B.ISU_NO AND BUL_DATA.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Ac_Ledr.Wh_Sales_Ledr(DC_Main.MCo_Book, tVchNo.Text);
						DC_Main.RsQry = "DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Ac_Tax.Bul_Sales_GST(DC_Main.MCo_Book, tVchNo.Text);
						DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Ac_Rojmel.Wh_Sales_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
						DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						Ac_Stock.Wh_Sale_Stk(DC_Main.MCo_Book, tVchNo.Text);
						Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
						if (Operators.CompareString(FormVchNo, "", false) != 0)
						{
							CLEAR_DATA();
							((Form)this).Close();
							goto end_IL_0001;
						}
						CurPrnVch = tVchNo.Text;
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
							CustOpAmt = DC_Main.MsAcAmtOpBal;
							CustClAmt = DC_Main.MsAcAmtClBal;
							CustOpGold = DC_Main.MsAcGoldOpBal;
							CustClGold = DC_Main.MsAcGoldClBal;
							CustOpSilver = DC_Main.MsAcSilverOpBal;
							CustClSilver = DC_Main.MsAcSilverClBal;
						}
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
						goto end_IL_0001;
					}
					case 11198:
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
				try0001_dispatch = 11198;
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
		//IL_06ce: Unknown result type (might be due to invalid IL or missing references)
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
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,0,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  SUBSTRING(B.BOOK_NAME,1,20),AC_CODE,AC_NAME,SL_NET_AMT,PR_NET_AMT,IT_TYPE,TOT_FINE_DR,TOT_FINE_CR,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',SUBSTRING(VCH_DESC,1,150) FROM RATE_CUT_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE BUL_DATA SET BUL_DATA.ADJ_WT = BUL_DATA.ADJ_WT - B.ITM_GWT-B.ADJ_WT FROM BUL_DATA,RATE_CUT_ISU AS B WHERE BUL_DATA.CO_CODE = B.CO_CODE AND BUL_DATA.LC_CODE = B.LC_CODE AND BUL_DATA.CO_YEAR = B.ISU_YRCD  AND BUL_DATA.CO_BOOK = B.ISU_DBCD AND BUL_DATA.VCH_NO = B.ISU_NO AND BUL_DATA.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE BUL_DATA SET BUL_DATA.ADJ_WT = BUL_DATA.ADJ_WT - B.ITM_GWT-B.ADJ_WT FROM BUL_DATA,RATE_CUT_REC AS B WHERE BUL_DATA.CO_CODE = B.CO_CODE AND BUL_DATA.LC_CODE = B.LC_CODE AND BUL_DATA.CO_YEAR = B.ISU_YRCD  AND BUL_DATA.CO_BOOK = B.ISU_DBCD AND BUL_DATA.VCH_NO = B.ISU_NO AND BUL_DATA.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_BUL_SALE_KeyDown(object sender, KeyEventArgs e)
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
					MSG.Col = 1;
					((Control)TEXT_ENTRY).Visible = false;
					MSG_TOT_FILL();
					MSG2_TOTAL.Row = 2;
					MSG2_TOTAL.Col = 1;
					MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
					((Control)TEXT_ENTRY_2).Focus();
				}
				else if (((Control)TEXT_PR).Visible)
				{
					MSG_PR_LeaveCell(MSG, new EventArgs());
					MSG_PR.Row = MSG_PR.Rows - 1;
					MSG_PR.Col = 1;
					((Control)TEXT_PR).Visible = false;
					MSG2_TOTAL.Row = 2;
					MSG2_TOTAL.Col = 1;
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
			chkItmImage.Checked = false;
			return;
		}
		DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,LESS_WT) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,'I',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,LESS_WT  FROM RATE_CUT_ISU WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,LESS_WT) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,'R',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_OTH_FINE,CONV_RATE,CONV_PRC,LESS_WT  FROM RATE_CUT_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		if ((Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0) | chkWapp.Checked)
		{
			DC_Main.MsCustWappNo = DC_Main.MsCountryId + tMobile.Text;
			DC_Main.MsCustMail = "";
			if (Operators.CompareString(tMobile.Text, "", false) == 0)
			{
				DC_Main.MsCustWappNo = "";
			}
			DC_Main.RsQry = "SELECT B.AC_EMAIL,B.AC_MOBILE FROM RATE_CUT_DATA AS A INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND  A.VCH_NO = '" + CurPrnVch + "' AND (B.AC_EMAIL <> '' OR B.AC_MOBILE <> '')";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				DC_Main.MsCustMail = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_EMAIL"], (object)""));
				if (Operators.CompareString(tMobile.Text, "", false) == 0)
				{
					DC_Main.MsCustWappNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)DC_Main.MsCountryId, DC_Main.Tbl.Rows[0]["AC_MOBILE"]), (object)""));
				}
			}
			string rptName;
			if (chkHuIdPrint.Checked)
			{
				rptName = "WhHuidPrint";
			}
			else
			{
				DC_Main.RsQry = "SELECT * FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				rptName = ((DC_Main.Rshlp.Rows.Count == 0) ? "RateCutBill" : ((Operators.CompareString(FormMainBook, "RATE CUT", false) != 0) ? "WhSalesBill" : "RateCutBill"));
			}
			DC_Main.RptName = rptName;
			DC_Main.MsWappOpAmt = Conversions.ToDouble(Strings.Format((object)CustOpAmt, "0.00"));
			DC_Main.MsWappClAmt = Conversions.ToDouble(Strings.Format((object)CustClAmt, "0.00"));
			DC_Main.MsWappOpGlFine = Conversions.ToDouble(Strings.Format((object)CustOpGold, "0.000"));
			DC_Main.MsWappClGlFine = Conversions.ToDouble(Strings.Format((object)CustClGold, "0.000"));
			DC_Main.MsWappOpSlFine = Conversions.ToDouble(Strings.Format((object)CustOpSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00"))));
			DC_Main.MsWappClSlFine = Conversions.ToDouble(Strings.Format((object)CustClSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00"))));
			DC_Main.MsWappPrintType = "WhSale";
			DC_Main.RptFormula = "{RATE_CUT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_CUT_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {RATE_CUT_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {RATE_CUT_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {RATE_CUT_DATA.VCH_NO} = '" + CurPrnVch + "'";
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
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
		if (chkHuIdPrint.Checked)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\WhHuidPrint.RPT";
		}
		else
		{
			DC_Main.RsQry = "SELECT * FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\RateCutBill.RPT";
			}
			else if (Operators.CompareString(FormMainBook, "RATE CUT", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\RateCutItmBill.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\WhSalesBill.RPT";
			}
		}
		Cr.SelectionFormula = "{RATE_CUT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {RATE_CUT_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {RATE_CUT_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {RATE_CUT_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {RATE_CUT_DATA.VCH_NO} = '" + CurPrnVch + "'";
		if (!chkHuIdPrint.Checked)
		{
			Cr[(short)2] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
			Cr[(short)3] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
			Cr[(short)4] = ("OpGold = " + Strings.Format((object)CustOpGold, "0.000")) ?? "";
			Cr[(short)5] = ("ClGold = " + Strings.Format((object)CustClGold, "0.000")) ?? "";
			Cr[(short)6] = ("OpSilver = " + Strings.Format((object)CustOpSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00")))) ?? "";
			Cr[(short)7] = ("ClSilver = " + Strings.Format((object)CustClSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00")))) ?? "";
		}
		checked
		{
			if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
			{
				if (DC_Main.MsPrintOg)
				{
					Cr[(short)1] = "InVoiceType = 'ORIGINAL'";
					Cr.Destination = (DestinationConstants)1;
					Cr.Action = -1;
				}
				if (DC_Main.MsPrintDup)
				{
					Cr[(short)1] = "InVoiceType = 'DUPLICATE'";
					Cr.Destination = (DestinationConstants)1;
					Cr.Action = -1;
				}
				if (DC_Main.MsPrintTrip)
				{
					Cr[(short)1] = "InVoiceType = 'TRIPLICATE'";
					Cr.Destination = (DestinationConstants)1;
					Cr.Action = -1;
				}
			}
			else
			{
				Cr[(short)1] = "InVoiceType = 'ORIGINAL'";
				Cr.Destination = (DestinationConstants)0;
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
			}
			DC_Main.MsPrintStatus = false;
			if ((Operators.CompareString(DC_Main.MsWhBillImg, "Y", false) == 0) & chkItmImage.Checked)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\WhSalesImage.RPT";
				Cr[(short)1] = "InVoiceType = 'ORIGINAL'";
				Cr.Destination = (DestinationConstants)0;
				Cr.WindowState = (WindowStateConstants)2;
				Cr.Action = -1;
				Cr.PageZoom((short)DC_Main.MsPrintZoom);
				DC_Main.MsPrintStatus = false;
			}
			chkItmImage.Checked = false;
		}
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

	private void TR_BUL_SALE_Activated(object sender, EventArgs e)
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
			tAcCode.Text = DC_Main.MsCode;
			tAcName.Text = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,BILL_NO AS RefNoL,A.VCH_DESC As VchDescL,format(TOT_FINE_CR,'0.000') AS FineCrW,format(TOT_FINE_DR,'0.000') AS FineDrW,format(PR_NET_AMT,'0.00') AS CrAmtR,format(SL_NET_AMT,'0.00') AS DrAmtR FROM RATE_CUT_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[10];
		DC_Main.ColWidth[0] = 80.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 80.0;
		DC_Main.ColWidth[4] = 200.0;
		DC_Main.ColWidth[5] = 100.0;
		DC_Main.ColWidth[6] = 100.0;
		DC_Main.ColWidth[7] = 100.0;
		DC_Main.ColWidth[8] = 100.0;
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
			lblItem.Text = "Itm : " + MSG[MSG.Row, 3];
			ItmStk(MSG.Row, "I");
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
				SendKeys.Send("{TAB}");
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
				DC_Main.RsQry = "SELECT VCH_NO FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM RATE_CUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_BUL_SALE_Closed(object sender, EventArgs e)
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

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
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
				DC_Main.MsGrCode = "20";
				MS_ACCT mS_ACCT = new MS_ACCT();
				((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)mS_ACCT).Show();
				((Control)mS_ACCT).Focus();
			}
			else
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
			AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				nCrDays.Text = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CR_DAYS"], (object)"")), "0");
			}
			AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
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
		if ((Operators.CompareString(tAcCode.Text, "00045", false) == 0) | (Operators.CompareString(tAcCode.Text, "00050", false) == 0))
		{
			((TextBoxBase)tAcName).ReadOnly = false;
			((Control)tAcName).Focus();
		}
		else if (Operators.CompareString(DC_Main.MCo_Book, "261", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsBulProcess, "N", false) == 0)
			{
				MSG_PR.Col = 2;
			}
			else
			{
				MSG_PR.Col = 1;
			}
			MSG_PR.Row = 1;
			MSG_PR_EnterCell(MSG_PR, new EventArgs());
			((Control)TEXT_PR).Focus();
		}
		else
		{
			if (Operators.CompareString(DC_Main.MsBulProcess, "N", false) == 0)
			{
				MSG.Col = 2;
			}
			else
			{
				MSG.Col = 1;
			}
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
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
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
		if (((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)) && (int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM RATE_CUT_DATA WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[3];
			DC_Main.ColWidth[0] = 700.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tVchDesc.Text = DC_Main.ColValue[0];
				((TextBoxBase)tVchDesc).SelectionStart = Strings.Len(tVchDesc.Text);
			}
		}
	}

	private void lblBook_DoubleClick(object sender, EventArgs e)
	{
		((Control)tHdVchNo).Visible = true;
	}

	private void MSG2_CLEAR()
	{
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		mSG2_TOTAL.Clear();
		mSG2_TOTAL.Rows = 10;
		mSG2_TOTAL.Row = 0;
		mSG2_TOTAL.Cols = 6;
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
			mSG2_TOTAL[4] = (int)Math.Round(1500.0 * ColCon);
			mSG2_TOTAL[5] = 7;
			mSG2_TOTAL[5] = 0;
			ColorConverter colorConverter = new ColorConverter();
			mSG2_TOTAL.FillStyle = (FillStyleSettings)1;
			mSG2_TOTAL[8] = 0;
			mSG2_TOTAL[9] = 0;
			DC_Main.i = 0;
			do
			{
				mSG2_TOTAL.Row = DC_Main.i;
				mSG2_TOTAL[DC_Main.i] = (int)Math.Round(300.0 * ColCon);
				switch (DC_Main.i)
				{
				case 0:
				case 9:
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
				case 5:
				case 6:
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
				case 1:
				case 4:
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
			while (DC_Main.i <= 9);
			mSG2_TOTAL[0, 3] = "Payment    ";
			mSG2_TOTAL[0, 4] = "Received    ";
			mSG2_TOTAL[1, 0] = "Net Amt : ";
			mSG2_TOTAL[2, 0] = "Tax Amt : ";
			mSG2_TOTAL[3, 0] = "Tds Amt : ";
			mSG2_TOTAL[4, 0] = "Total Amt : ";
			mSG2_TOTAL[5, 0] = "Cheque Amt : ";
			mSG2_TOTAL[6, 0] = "Card Amt : ";
			mSG2_TOTAL[7, 0] = "Cash Amt : ";
			mSG2_TOTAL[8, 0] = "Kasar Amt : ";
			mSG2_TOTAL[9, 0] = "Os Amt : ";
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
			((Control)TEXT_ENTRY_2).Focus();
			switch (MSG2_TOTAL.Col)
			{
			case 1:
				((TextBoxBase)TEXT_ENTRY_2).MaxLength = 50;
				TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 9))
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
				if ((mSG2_TOTAL.Row == 5) | (mSG2_TOTAL.Row == 6))
				{
					TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				}
				else
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 2))
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
				if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 9))
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
				}
				else
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = false;
				}
				break;
			case 4:
				((TextBoxBase)TEXT_ENTRY_2).MaxLength = 12;
				TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 9))
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
			if ((mSG2_TOTAL.Row == 5) | (mSG2_TOTAL.Row == 6))
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
		case 4:
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
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_0882: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
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
					if (((mSG2_TOTAL.Row == 5) | (mSG2_TOTAL.Row == 6)) && Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_NAME = '" + TEXT_ENTRY_2.Text + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (mSG2_TOTAL.Row == 5)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '02','22','03','23')  ORDER BY A.AC_NAME";
							}
							else if (mSG2_TOTAL.Row == 6)
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
									mSG2_TOTAL[mSG2_TOTAL.Row, 5] = DC_Main.ColValue[1];
									RowChang = true;
								}
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							mSG2_TOTAL[mSG2_TOTAL.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
							mSG2_TOTAL[mSG2_TOTAL.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
							if (Conversion.Val(MSG2_TOTAL[1, 3]) != 0.0)
							{
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row += 1;
								mSG2_TOTAL.Col = 3;
								MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
							}
							else
							{
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row += 1;
								mSG2_TOTAL.Col = 4;
								MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
							}
							RowChang = true;
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
										mSG2_TOTAL[2, 5] = DC_Main.ColValue[2];
										BILL_TOTAL();
									}
									else
									{
										TEXT_ENTRY_2.Text = "TAX FREE";
										mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "TAX FREE";
										mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "0.00";
										mSG2_TOTAL[mSG2_TOTAL.Row, 5] = "00";
									}
									MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
									mSG2_TOTAL.Row = 3;
									mSG2_TOTAL.Col = 1;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[mSG2_TOTAL.Row, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00");
								double num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00"));
								mSG2_TOTAL[mSG2_TOTAL.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 5;
								if (Conversion.Val(MSG2_TOTAL[1, 3]) != 0.0)
								{
									mSG2_TOTAL.Col = 3;
								}
								else
								{
									mSG2_TOTAL.Col = 4;
								}
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							mSG2_TOTAL.Row = 5;
							if (Conversion.Val(MSG2_TOTAL[1, 3]) != 0.0)
							{
								mSG2_TOTAL.Col = 3;
							}
							else
							{
								mSG2_TOTAL.Col = 4;
							}
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (mSG2_TOTAL.Row != 3 || Operators.CompareString(TEXT_ENTRY_2.Text, "", false) == 0)
					{
						break;
					}
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
								mSG2_TOTAL[3, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.00");
								mSG2_TOTAL[3, 5] = DC_Main.ColValue[2];
								BILL_TOTAL();
							}
							else
							{
								TEXT_ENTRY_2.Text = "TAX FREE";
								mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "TAX FREE";
								mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "0.00";
								mSG2_TOTAL[mSG2_TOTAL.Row, 5] = "00";
							}
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row = 5;
							if (Conversion.Val(MSG2_TOTAL[1, 3]) != 0.0)
							{
								mSG2_TOTAL.Col = 3;
							}
							else
							{
								mSG2_TOTAL.Col = 4;
							}
							((Control)TEXT_ENTRY_2).Focus();
						}
					}
					else
					{
						mSG2_TOTAL[mSG2_TOTAL.Row, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00");
						double num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00"));
						mSG2_TOTAL[mSG2_TOTAL.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row = 5;
						if (Conversion.Val(MSG2_TOTAL[1, 3]) != 0.0)
						{
							mSG2_TOTAL.Col = 3;
						}
						else
						{
							mSG2_TOTAL.Col = 4;
						}
						((Control)TEXT_ENTRY_2).Focus();
					}
					return;
				case 3:
					switch (mSG2_TOTAL.Row)
					{
					case 7:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 3:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 5:
					case 6:
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
					case 8:
						CommPassTotal();
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						BILL_TOTAL();
						((Control)TEXT_ENTRY_2).Visible = false;
						((Control)tEmpCode).Focus();
						return;
					}
					if (mSG2_TOTAL.Row == mSG2_TOTAL.Rows - 1)
					{
						CommPassTotal();
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
				case 4:
					switch (mSG2_TOTAL.Row)
					{
					case 7:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 4;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 3:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 4;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 5:
					case 6:
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
							mSG2_TOTAL.Col = 4;
							((Control)TEXT_ENTRY_2).Visible = true;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					case 8:
						CommPassTotal();
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						BILL_TOTAL();
						((Control)TEXT_ENTRY_2).Visible = false;
						((Control)tEmpCode).Focus();
						return;
					}
					if (mSG2_TOTAL.Row == mSG2_TOTAL.Rows - 1)
					{
						CommPassTotal();
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

	private void BILL_TOTAL()
	{
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		if ((Conversion.Val(nConvRate.Text) != 0.0) & (Conversion.Val(nConvPrc.Text) != 0.0))
		{
			nFineRate.Text = Strings.Format((object)Math.Round(Conversion.Val(nConvRate.Text) / Conversion.Val(nConvPrc.Text) * 100.0, 2), "0.00");
		}
		else if (Conversion.Val(nConvRate.Text) != 0.0)
		{
			nFineRate.Text = Strings.Format((object)Conversion.Val(nConvRate.Text), "0.00");
		}
		if ((Conversion.Val(nAcDrAmt.Text) != 0.0) & (Conversion.Val(nAcCrFine.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nFineRate.Text) == 0.0)
				{
					nFineRate.Text = Strings.Format((object)(Conversion.Val(nAcDrAmt.Text) * 10.0 / Conversion.Val(nAcCrFine.Text)), "0.000");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nFineRate.Text) == 0.0)
				{
					nFineRate.Text = Strings.Format((object)(Conversion.Val(nAcDrAmt.Text) * 1000.0 / Conversion.Val(nAcCrFine.Text)), "0.000");
				}
			}
			else if (Conversion.Val(nFineRate.Text) == 0.0)
			{
				nFineRate.Text = Strings.Format((object)(Conversion.Val(nAcDrAmt.Text) / Conversion.Val(nAcCrFine.Text)), "0.000");
			}
		}
		if ((Conversion.Val(nAcCrAmt.Text) != 0.0) & (Conversion.Val(nAcDrFine.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nFineRate.Text) == 0.0)
				{
					nFineRate.Text = Strings.Format((object)(Conversion.Val(nAcCrAmt.Text) * 10.0 / Conversion.Val(nAcDrFine.Text)), "0.000");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nFineRate.Text) == 0.0)
				{
					nFineRate.Text = Strings.Format((object)(Conversion.Val(nAcCrAmt.Text) * 1000.0 / Conversion.Val(nAcDrFine.Text)), "0.000");
				}
			}
			else if (Conversion.Val(nFineRate.Text) == 0.0)
			{
				nFineRate.Text = Strings.Format((object)(Conversion.Val(nAcCrAmt.Text) / Conversion.Val(nAcDrFine.Text)), "0.000");
			}
		}
		if ((Conversion.Val(nFineRate.Text) != 0.0) & (Conversion.Val(nAcCrFine.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nAcDrAmt.Text) == 0.0)
				{
					nAcDrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nAcCrFine.Text) * (Conversion.Val(nFineRate.Text) / 10.0), 0), "0.00");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nAcDrAmt.Text) == 0.0)
				{
					nAcDrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nAcCrFine.Text) * (Conversion.Val(nFineRate.Text) / 1000.0), 0), "0.00");
				}
			}
			else if (Conversion.Val(nAcDrAmt.Text) == 0.0)
			{
				nAcDrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nAcCrFine.Text) * Conversion.Val(nFineRate.Text), 0), "0.00");
			}
		}
		if ((Conversion.Val(nFineRate.Text) != 0.0) & (Conversion.Val(nAcDrFine.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nAcCrAmt.Text) == 0.0)
				{
					nAcCrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nAcDrFine.Text) * (Conversion.Val(nFineRate.Text) / 10.0), 0), "0.00");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nAcCrAmt.Text) == 0.0)
				{
					nAcCrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nAcDrFine.Text) * (Conversion.Val(nFineRate.Text) / 1000.0), 0), "0.00");
				}
			}
			else if (Conversion.Val(nAcCrAmt.Text) == 0.0)
			{
				nAcCrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nAcDrFine.Text) * Conversion.Val(nFineRate.Text), 0), "0.00");
			}
		}
		if ((Conversion.Val(nFineRate.Text) != 0.0) & (Conversion.Val(nAcDrAmt.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nAcCrFine.Text) == 0.0)
				{
					nAcCrFine.Text = Strings.Format((object)(Conversion.Val(nAcDrAmt.Text) * 10.0 / Conversion.Val(nFineRate.Text)), "0.000");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nAcCrFine.Text) == 0.0)
				{
					nAcCrFine.Text = Strings.Format((object)(Conversion.Val(nAcDrAmt.Text) * 1000.0 / Conversion.Val(nFineRate.Text)), "0.000");
				}
			}
			else if (Conversion.Val(nAcCrFine.Text) == 0.0)
			{
				nAcCrFine.Text = Strings.Format((object)(Conversion.Val(nAcDrAmt.Text) / Conversion.Val(nFineRate.Text)), "0.000");
			}
		}
		if ((Conversion.Val(nFineRate.Text) != 0.0) & (Conversion.Val(nAcCrAmt.Text) != 0.0))
		{
			if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
			{
				if (Conversion.Val(nAcDrFine.Text) == 0.0)
				{
					nAcDrFine.Text = Strings.Format((object)(Conversion.Val(nAcCrAmt.Text) * 10.0 / Conversion.Val(nFineRate.Text)), "0.000");
				}
			}
			else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
			{
				if (Conversion.Val(nAcDrFine.Text) == 0.0)
				{
					nAcDrFine.Text = Strings.Format((object)(Conversion.Val(nAcCrAmt.Text) * 1000.0 / Conversion.Val(nFineRate.Text)), "0.000");
				}
			}
			else if (Conversion.Val(nAcDrFine.Text) == 0.0)
			{
				nAcDrFine.Text = Strings.Format((object)(Conversion.Val(nAcCrAmt.Text) / Conversion.Val(nFineRate.Text)), "0.000");
			}
		}
		nTotFineDr.Text = Strings.Format((object)(TotDrFine + Conversion.Val(nAcDrFine.Text) + Conversion.Val(nFineKsrDr.Text) + Conversion.Val(MSG_TOT[0, 36])), "0.000");
		nTotFineCr.Text = Strings.Format((object)(TotCrFine + Conversion.Val(nAcCrFine.Text) + Conversion.Val(nFineKsrCr.Text) + Conversion.Val(MSG_PR_TOT[0, 31])), "0.000");
		nDiffFine.Text = Strings.Format((object)(Conversion.Val(nTotFineDr.Text) - Conversion.Val(nTotFineCr.Text)), "0.000");
		double num = 0.0;
		double num2 = 0.0;
		mSG2_TOTAL[1, 4] = Strings.Format((object)Math.Round(Conversion.Val(nAcDrAmt.Text) + num + Conversion.Val(MSG_TOT[0, 22]) - SlOthAmtLess, 0), "0.00");
		mSG2_TOTAL[1, 3] = Strings.Format((object)Math.Round(Conversion.Val(nAcCrAmt.Text) + num2 + Conversion.Val(MSG_PR_TOT[0, 21]) - PrOthAmtLess, 0), "0.00");
		if ((Conversion.Val(mSG2_TOTAL[2, 2]) != 0.0) & (Conversion.Val(mSG2_TOTAL[1, 3]) != 0.0))
		{
			mSG2_TOTAL[2, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[1, 3]) * Conversion.Val(mSG2_TOTAL[2, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
		}
		else
		{
			mSG2_TOTAL[2, 3] = "";
		}
		if ((Conversion.Val(mSG2_TOTAL[2, 2]) != 0.0) & (Conversion.Val(mSG2_TOTAL[1, 4]) != 0.0))
		{
			mSG2_TOTAL[2, 4] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[1, 4]) * Conversion.Val(mSG2_TOTAL[2, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
		}
		else
		{
			mSG2_TOTAL[2, 4] = "";
		}
		if ((Conversion.Val(mSG2_TOTAL[3, 2]) != 0.0) & (Conversion.Val(mSG2_TOTAL[1, 3]) != 0.0))
		{
			mSG2_TOTAL[3, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[1, 3]) * Conversion.Val(mSG2_TOTAL[3, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
		}
		else
		{
			mSG2_TOTAL[3, 3] = "";
		}
		if ((Conversion.Val(mSG2_TOTAL[3, 2]) != 0.0) & (Conversion.Val(mSG2_TOTAL[1, 4]) != 0.0))
		{
			mSG2_TOTAL[3, 4] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[1, 4]) * Conversion.Val(mSG2_TOTAL[3, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
		}
		else
		{
			mSG2_TOTAL[3, 4] = "";
		}
		mSG2_TOTAL[4, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[3, 3])), "0.00");
		mSG2_TOTAL[4, 4] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[1, 4]) + Conversion.Val(mSG2_TOTAL[2, 4]) - Conversion.Val(mSG2_TOTAL[3, 4])), "0.00");
		if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
		{
			mSG2_TOTAL[7, 4] = Strings.Format((object)Conversion.Val(mSG2_TOTAL[4, 4]), "0.00");
		}
		if (Operators.CompareString(tAcCode.Text, "00050", false) == 0)
		{
			mSG2_TOTAL[7, 3] = Strings.Format((object)Conversion.Val(mSG2_TOTAL[4, 3]), "0.00");
		}
		mSG2_TOTAL[9, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[4, 3]) - Conversion.Val(mSG2_TOTAL[7, 3]) - Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[8, 3])), "0.00");
		mSG2_TOTAL[9, 4] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[4, 4]) - Conversion.Val(mSG2_TOTAL[7, 4]) - Conversion.Val(mSG2_TOTAL[5, 4]) - Conversion.Val(mSG2_TOTAL[6, 4]) - Conversion.Val(mSG2_TOTAL[8, 4])), "0.00");
		if (Conversion.Val(mSG2_TOTAL[9, 3]) > Conversion.Val(mSG2_TOTAL[9, 4]))
		{
			lblDiffAmt.Text = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[9, 4])), "0.00") + "  Pay";
		}
		else if (Conversion.Val(mSG2_TOTAL[9, 3]) < Conversion.Val(mSG2_TOTAL[9, 4]))
		{
			lblDiffAmt.Text = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[9, 4]) - Conversion.Val(mSG2_TOTAL[9, 3])), "0.00") + "  Rec";
		}
		else
		{
			lblDiffAmt.Text = ".";
		}
		if (CustOpAmt > 0.0)
		{
			CustClAmt = CustOpAmt + Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[9, 4]);
		}
		else if (CustOpAmt < 0.0)
		{
			CustClAmt = Conversion.Val(mSG2_TOTAL[9, 3]) - (Math.Abs(CustOpAmt) + Conversion.Val(mSG2_TOTAL[9, 4]));
		}
		else
		{
			CustClAmt = Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[9, 4]);
		}
		if (cboItemTyp.SelectedIndex == 0)
		{
			if (CustOpGold > 0.0)
			{
				CustClGold = CustOpGold + Conversion.Val(nTotFineCr.Text) - Conversion.Val(nTotFineDr.Text);
			}
			else if (CustOpGold < 0.0)
			{
				CustClGold = Conversion.Val(nTotFineCr.Text) - (Math.Abs(CustOpGold) + Conversion.Val(nTotFineDr.Text));
			}
			else
			{
				CustClGold = Conversion.Val(nTotFineCr.Text) - Conversion.Val(nTotFineDr.Text);
			}
		}
		else
		{
			CustClGold = CustOpGold;
		}
		if (cboItemTyp.SelectedIndex == 1)
		{
			if (CustOpSilver > 0.0)
			{
				CustClSilver = CustOpSilver + Conversion.Val(nTotFineCr.Text) - Conversion.Val(nTotFineDr.Text);
			}
			else if (CustOpSilver < 0.0)
			{
				CustClSilver = Conversion.Val(nTotFineCr.Text) - (Math.Abs(CustOpSilver) + Conversion.Val(nTotFineDr.Text));
			}
			else
			{
				CustClSilver = Conversion.Val(nTotFineCr.Text) - Conversion.Val(nTotFineDr.Text);
			}
		}
		else
		{
			CustClSilver = CustOpSilver;
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

	private void tBillNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tBankName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tAcName_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)tAcName).SelectionStart = 0;
		((TextBoxBase)tAcName).SelectionLength = Strings.Len(tAcName.Text);
		if ((Operators.CompareString(tAcCode.Text, "00045", false) == 0) | (Operators.CompareString(tAcCode.Text, "00050", false) == 0))
		{
			((TextBoxBase)tAcName).ReadOnly = false;
		}
		else
		{
			((TextBoxBase)tAcName).ReadOnly = true;
		}
	}

	private void tAcName_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if ((int)Interaction.MsgBox((object)"Creat New Addres ?", (MsgBoxStyle)292, (object)null) == 6)
		{
			((Control)PanelAdd).Visible = true;
			if ((int)e.KeyCode == 13)
			{
				SendKeys.Send("{TAB}");
			}
		}
		else if (Operators.CompareString(DC_Main.MCo_Book, "261", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsBulProcess, "N", false) == 0)
			{
				MSG_PR.Col = 2;
			}
			else
			{
				MSG_PR.Col = 1;
			}
			MSG_PR.Row = 1;
			MSG_PR_EnterCell(MSG_PR, new EventArgs());
			((Control)TEXT_PR).Focus();
		}
		else
		{
			if (Operators.CompareString(DC_Main.MsBulProcess, "N", false) == 0)
			{
				MSG.Col = 2;
			}
			else
			{
				MSG.Col = 1;
			}
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void tAdd1_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tAdd2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tAdd3_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tCity_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tMobile_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		((Control)PanelAdd).Visible = false;
		if (Operators.CompareString(DC_Main.MCo_Book, "261", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsBulProcess, "N", false) == 0)
			{
				MSG_PR.Col = 2;
			}
			else
			{
				MSG_PR.Col = 1;
			}
			MSG_PR.Row = 1;
			MSG_PR_EnterCell(MSG_PR, new EventArgs());
			((Control)TEXT_PR).Focus();
		}
		else
		{
			if (Operators.CompareString(DC_Main.MsBulProcess, "N", false) == 0)
			{
				MSG.Col = 2;
			}
			else
			{
				MSG.Col = 1;
			}
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void nAcDrAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nAcDrAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nAcDrAmt.Text)), "0.00");
			if ((OldAcDrAmt != 0.0) & (OldAcDrAmt != Conversion.Val(nAcDrAmt.Text)) & (OldAcCrFine != 0.0))
			{
				nFineRate.Text = "";
			}
			OldAcDrAmt = Conversion.Val(nAcDrAmt.Text);
			if (OldAcCrAmt == 0.0)
			{
				nAcCrAmt.Text = "";
			}
			if (OldAcDrAmt == 0.0)
			{
				nAcDrAmt.Text = "";
			}
			if (OldAcCrFine == 0.0)
			{
				nAcCrFine.Text = "";
			}
			if (OldAcDrFine == 0.0)
			{
				nAcDrFine.Text = "";
			}
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nAcCrFine_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nAcCrFine.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nAcCrFine.Text)), "0.000");
			if ((OldAcCrFine != 0.0) & (OldAcCrFine != Conversion.Val(nAcCrFine.Text)) & (OldAcDrAmt != 0.0))
			{
				nFineRate.Text = "";
			}
			OldAcCrFine = Conversion.Val(nAcCrFine.Text);
			if (OldAcCrAmt == 0.0)
			{
				nAcCrAmt.Text = "";
			}
			if (OldAcDrAmt == 0.0)
			{
				nAcDrAmt.Text = "";
			}
			if (OldAcCrFine == 0.0)
			{
				nAcCrFine.Text = "";
			}
			if (OldAcDrFine == 0.0)
			{
				nAcDrFine.Text = "";
			}
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nAcCrAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nAcCrAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nAcCrAmt.Text)), "0.00");
			if ((OldAcCrAmt != 0.0) & (OldAcCrAmt != Conversion.Val(nAcCrAmt.Text)) & (OldAcDrFine != 0.0))
			{
				nFineRate.Text = "";
			}
			OldAcCrAmt = Conversion.Val(nAcCrAmt.Text);
			if (OldAcCrAmt == 0.0)
			{
				nAcCrAmt.Text = "";
			}
			if (OldAcDrAmt == 0.0)
			{
				nAcDrAmt.Text = "";
			}
			if (OldAcCrFine == 0.0)
			{
				nAcCrFine.Text = "";
			}
			if (OldAcDrFine == 0.0)
			{
				nAcDrFine.Text = "";
			}
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nAcDrFine_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nAcDrFine.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nAcDrFine.Text)), "0.000");
			if ((OldAcDrFine != 0.0) & (OldAcDrFine != Conversion.Val(nAcDrFine.Text)) & (OldAcCrAmt != 0.0))
			{
				nFineRate.Text = "";
			}
			OldAcDrFine = Conversion.Val(nAcDrFine.Text);
			if (OldAcCrAmt == 0.0)
			{
				nAcCrAmt.Text = "";
			}
			if (OldAcDrAmt == 0.0)
			{
				nAcDrAmt.Text = "";
			}
			if (OldAcCrFine == 0.0)
			{
				nAcCrFine.Text = "";
			}
			if (OldAcDrFine == 0.0)
			{
				nAcDrFine.Text = "";
			}
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nFineKsrDr_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nFineKsrDr.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFineKsrDr.Text)), "0.000");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nFineKsrCr_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nFineKsrCr.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFineKsrCr.Text)), "0.000");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nFineRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Conversion.Val(nFineRate.Text) != 0.0)
		{
			if (Conversion.Val(nFineRate.Text) != OldFineRate)
			{
				if (OldAcCrAmt == 0.0)
				{
					nAcCrAmt.Text = "";
				}
				if (OldAcDrAmt == 0.0)
				{
					nAcDrAmt.Text = "";
				}
				if (OldAcCrFine == 0.0)
				{
					nAcCrFine.Text = "";
				}
				if (OldAcDrFine == 0.0)
				{
					nAcDrFine.Text = "";
				}
			}
			nFineRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFineRate.Text)), "0.00");
			BILL_TOTAL();
			MSG2_TOTAL.Row = 2;
			MSG2_TOTAL.Col = 1;
			MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
			((Control)TEXT_ENTRY_2).Focus();
		}
		else
		{
			MSG2_TOTAL.Row = 2;
			MSG2_TOTAL.Col = 1;
			MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
			((Control)TEXT_ENTRY_2).Focus();
		}
	}

	private void nCrDays_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nCrDays.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nCrDays.Text)), "0");
			SendKeys.Send("{TAB}");
		}
	}

	private void cboItemTyp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void TEXT_ENTRY_2_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)TEXT_ENTRY_2).SelectionStart = 0;
		((TextBoxBase)TEXT_ENTRY_2).SelectionLength = Strings.Len(TEXT_ENTRY_2.Text);
	}

	private void nConvPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nConvPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nConvPrc.Text)), "0.00");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nConvRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (OldConRate != Conversion.Val(nConvRate.Text))
		{
			if ((OldConRate != 0.0) & (Conversion.Val(nConvRate.Text) == 0.0))
			{
				nFineRate.Text = "";
			}
			OldConRate = Conversion.Val(nConvRate.Text);
			if (OldAcCrAmt == 0.0)
			{
				nAcCrAmt.Text = "";
			}
			if (OldAcDrAmt == 0.0)
			{
				nAcDrAmt.Text = "";
			}
			if (OldAcCrFine == 0.0)
			{
				nAcCrFine.Text = "";
			}
			if (OldAcDrFine == 0.0)
			{
				nAcDrFine.Text = "";
			}
			if (OldFineRate == 0.0)
			{
				nFineRate.Text = "";
			}
		}
		nConvRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nConvRate.Text)), "0.00");
		BILL_TOTAL();
		SendKeys.Send("{TAB}");
	}

	private void TR_BUL_SALE_KeyUp(object sender, KeyEventArgs e)
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
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Invalid comparison between Unknown and I4
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Invalid comparison between Unknown and I4
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Invalid comparison between Unknown and I4
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Invalid comparison between Unknown and I4
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Invalid comparison between Unknown and I4
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ENTRY", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_ENTRY).SelectionStart = 0;
			((TextBoxBase)TEXT_ENTRY).SelectionLength = Strings.Len(TEXT_ENTRY.Text);
		}
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_PR", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_PR).SelectionStart = 0;
			((TextBoxBase)TEXT_PR).SelectionLength = Strings.Len(TEXT_PR.Text);
		}
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ENTRY_2", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_ENTRY_2).SelectionStart = 0;
			((TextBoxBase)TEXT_ENTRY_2).SelectionLength = Strings.Len(TEXT_ENTRY_2.Text);
		}
	}

	private void cboBillType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (cboBillType.SelectedIndex == 1 && Operators.CompareString(EntryMode, "A", false) == 0)
			{
				tAcCode.Text = "";
			}
			((Control)tBillNo).Focus();
		}
	}

	private void tVchDesc_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
	}

	private void ItmStk(int Row, string Type)
	{
		if (Operators.CompareString(Type, "R", false) == 0)
		{
			DC_Main.RsQry = "Select A.IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS StkPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) AS StkGwt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS StkNwt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.IT_CODE = '" + MSG_PR[Row, 2] + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND TAG_NO = 'N'  GROUP BY A.IT_CODE ";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				lblItStock.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"P = ", dataTable.Rows[0]["StkPcs"]), (object)"  G = "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.00")), (object)"  N = "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkNwt"])), "0.00")));
				CurItGwtStk = Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.000"));
			}
			else
			{
				CurItGwtStk = 0.0;
				lblItStock.Text = "Itm Stk :";
			}
		}
		else
		{
			DC_Main.RsQry = "Select A.IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS StkPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) AS StkGwt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS StkNwt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.IT_CODE = '" + MSG[Row, 2] + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "'  GROUP BY A.IT_CODE ";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				lblItStock.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"P = ", dataTable.Rows[0]["StkPcs"]), (object)"  G = "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.00")), (object)"  N = "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkNwt"])), "0.00")));
				CurItGwtStk = Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.000"));
			}
			else
			{
				CurItGwtStk = 0.0;
				lblItStock.Text = "Itm Stk :";
			}
		}
	}
}
