using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
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
public class TR_SALE_LBR : Form
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
	[AccessedThroughProperty("PicImage")]
	private PictureBox _PicImage;

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
	[AccessedThroughProperty("PicZoom")]
	private PictureBox _PicZoom;

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
	[AccessedThroughProperty("nCrAmt")]
	private TextBox _nCrAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCrFine")]
	private TextBox _nCrFine;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDrAmt")]
	private TextBox _nDrAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDrFine")]
	private TextBox _nDrFine;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDrRate")]
	private TextBox _nDrRate;

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
	[AccessedThroughProperty("MSG_ORD")]
	private AxMSFlexGrid _MSG_ORD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ORD")]
	private TextBox _TEXT_ORD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_UPI")]
	private AxMSFlexGrid _MSG_UPI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_UPI")]
	private TextBox _TEXT_UPI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nConvRate")]
	private TextBox _nConvRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nConvPrc")]
	private TextBox _nConvPrc;

	private string UsUPdate;

	private string UsDelete;

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

	private double LessAdvAmt;

	private double LessAdvNetWt;

	private double CrDrTot;

	private DataTable VchOldData;

	private double OldCardAmt;

	private string CardCommAdj;

	private string CustMobile;

	private double SlOthAmtLess;

	private double PrOthAmtLess;

	private double CustOpAmt;

	private double CustOpGold;

	private double CustOpSilver;

	private double CustClAmt;

	private double CustClGold;

	private double CustClSilver;

	private bool UpiTypeAdd;

	private double TotCrFine;

	private double TotDrFine;

	private double ToDayGlRate;

	private double ToDaySlRate;

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

	private DataTable RsPrDetl;

	private DataTable RsBarDetl;

	private DataTable RsBillOs;

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

	private bool RowChang;

	private const int cSrNo = 0;

	private const int cTagNo = 1;

	private const int cItCode = 2;

	private const int cItName = 3;

	private const int cDesign = 4;

	private const int cHmId = 5;

	private const int cPcs = 6;

	private const int cGrWt = 7;

	private const int cOthWt = 8;

	private const int cNetWt = 9;

	private const int cGhtPrc = 10;

	private const int cGhtWt = 11;

	private const int cTouch = 12;

	private const int cWestPrc = 13;

	private const int cFine = 14;

	private const int cLbrPrc = 15;

	private const int cLbrType = 16;

	private const int cLbrRate = 17;

	private const int cLbrAmt = 18;

	private const int cOthAmt = 19;

	private const int cNetAmt = 20;

	private const int cOldSrNo = 21;

	private const int cEntryMod = 22;

	private const int cCounter = 23;

	private const int cKrName = 24;

	private const int cVchSrno = 25;

	private const int cItType = 26;

	private const int cTagType = 27;

	private const int cPrCode = 28;

	private const int cMrp = 29;

	private const int cKrOthWt = 30;

	private const int cKrNetWt = 31;

	private const int cKrTouch = 32;

	private const int cKrWestPrc = 33;

	private const int cKrFine = 34;

	private const int cTagCost = 35;

	private const int cItmRate = 36;

	private const int cDesignImgId = 37;

	private const int cOldLbrRate = 38;

	private const int cOldLbrAmt = 39;

	private const int cHmId2 = 40;

	private const int cHmId3 = 41;

	private const int cHmId4 = 42;

	private const int cHmIdWt = 43;

	private const int cHmId2Wt = 44;

	private const int cHmId3Wt = 45;

	private const int cHmId4wt = 46;

	private const int cRateType = 47;

	private const int cOldNetWt = 48;

	private const int cOldLbrType = 49;

	private const int cOrdNo = 50;

	private const int cOrdYrCd = 51;

	private const int cOrdDbCd = 52;

	private const int cOrdSrNo = 53;

	private const int cOrdTagStkAdd = 54;

	private const int cItProfit = 55;

	private const int cKrLAmt = 56;

	private const int cKrOthAmt = 57;

	private const int cItAmt = 58;

	private const int cOldPcs = 59;

	private const int c1SrNo = 0;

	private const int c1ItCode = 1;

	private const int c1ItName = 2;

	private const int c1DmCode = 3;

	private const int c1DmName = 4;

	private const int c1DmSize = 5;

	private const int c1DmSfNo = 6;

	private const int c1MotiPcs = 7;

	private const int c1MotiWt = 8;

	private const int c1Pcs = 9;

	private const int c1PcsWt = 10;

	private const int c1KrWt = 11;

	private const int c1GrWt = 12;

	private const int c1ConPrc = 13;

	private const int c1RateType = 14;

	private const int c1ItRate = 15;

	private const int c1ItmAmt = 16;

	private const int c1LbrRate = 17;

	private const int c1LbrAmt = 18;

	private const int c1NetAmt = 19;

	private const int c1ConWt = 20;

	private const int c1KrConWt = 21;

	private const int c1ItType = 22;

	private const int c1RowSr = 23;

	private const int cTitel2 = 0;

	private const int cNetAmt2 = 1;

	private const int cTax2 = 2;

	private const int cOthAmt2 = 3;

	private const int cOthTax2 = 4;

	private const int cLbrAmt2 = 5;

	private const int cLbrDisc2 = 6;

	private const int cLbrTax2 = 7;

	private const int cTot2 = 8;

	private const int cChq2 = 9;

	private const int cCard2 = 10;

	private const int cOrder2 = 11;

	private const int cCash2 = 12;

	private const int cKasar2 = 13;

	private const int cOs2 = 14;

	private const int cPrSrNo = 0;

	private const int cPrItCode = 1;

	private const int cPrItName = 2;

	private const int cPrPcs = 3;

	private const int cPrGrWt = 4;

	private const int cPrNetWt = 5;

	private const int cPrTouch = 6;

	private const int cPrLessTch = 7;

	private const int cPrFine = 8;

	private const int cPrGhtWt = 9;

	private const int cPrCounter = 10;

	private const int cPrDesign = 11;

	private const int cPrBagWt = 12;

	private const int cPrPcsWt = 13;

	private const int cPrOthWt = 14;

	private const int cPrWestPrc = 15;

	private const int cPrHmFine = 16;

	private const int cPrSilverFine = 17;

	private const int cPrSign = 18;

	private const int cPrRate = 19;

	private const int cPrItAmt = 20;

	private const int cPrLbrPrc = 21;

	private const int cPrLbrType = 22;

	private const int cPrLbrRate = 23;

	private const int cPrLbrAmt = 24;

	private const int cPrOthAmt = 25;

	private const int cPrOthRate = 26;

	private const int cPrOthFine = 27;

	private const int cPrMrp = 28;

	private const int cPrNetAmt = 29;

	private const int cPrTotAmt = 30;

	private const int cPrTaxPrc = 31;

	private const int cPrItType = 32;

	private const int cPrRateType = 33;

	private const int cPrOldGwt = 34;

	private const int cPrOldNwt = 35;

	private const int cPrOldTouch = 36;

	private const int cPrOldWest = 37;

	private const int cPrOldRate = 38;

	private const int cOrSrNo = 0;

	private const int cOrVchNo = 1;

	private const int cOrFineWt = 2;

	private const int cOrVchAmt = 3;

	private const int cOrLc = 4;

	private const int cOrYrCd = 5;

	private const int cOrDbCd = 6;

	private const int cOrAcCode = 7;

	private const int cOrHdVchNo = 8;

	private const int cUpSrNo = 0;

	private const int cUpAcCode = 1;

	private const int cUpAcName = 2;

	private const int cUpUpiType = 3;

	private const int cUpUpiId = 4;

	private const int cUpUpiAmt = 5;

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
			EventHandler eventHandler2 = tVchNo_DoubleClick;
			TextBox val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler2;
			}
			_tVchNo = value;
			val2 = _tVchNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler2;
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

	internal virtual PictureBox PicImage
	{
		[CompilerGenerated]
		get
		{
			return _PicImage;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PicImage_DoubleClick;
			PictureBox val = _PicImage;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PicImage = value;
			val = _PicImage;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
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

	internal virtual PictureBox PicZoom
	{
		[CompilerGenerated]
		get
		{
			return _PicZoom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PicZoom_DoubleClick;
			PictureBox val = _PicZoom;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PicZoom = value;
			val = _PicZoom;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
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
	[AccessedThroughProperty("nTotWtCr")]
	private virtual TextBox _nTotWtCr;

	internal virtual TextBox nTotWtCr
	{
		get
		{
			return _nTotWtCr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nTotWtCr = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nTotWtDr")]
	private virtual TextBox _nTotWtDr;

	internal virtual TextBox nTotWtDr
	{
		get
		{
			return _nTotWtDr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nTotWtDr = value;
		}
	}

	internal virtual TextBox nCrAmt
	{
		[CompilerGenerated]
		get
		{
			return _nCrAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nCrAmt_KeyDown);
			TextBox val2 = _nCrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCrAmt = value;
			val2 = _nCrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nCrFine
	{
		[CompilerGenerated]
		get
		{
			return _nCrFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nCrFine_KeyDown);
			TextBox val2 = _nCrFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nCrFine = value;
			val2 = _nCrFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nDrAmt
	{
		[CompilerGenerated]
		get
		{
			return _nDrAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nDrAmt_KeyDown);
			TextBox val2 = _nDrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nDrAmt = value;
			val2 = _nDrAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nDrFine
	{
		[CompilerGenerated]
		get
		{
			return _nDrFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nDrFine_KeyDown);
			TextBox val2 = _nDrFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nDrFine = value;
			val2 = _nDrFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nDrRate
	{
		[CompilerGenerated]
		get
		{
			return _nDrRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nDrRate_KeyDown);
			TextBox val2 = _nDrRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nDrRate = value;
			val2 = _nDrRate;
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
	[AccessedThroughProperty("nOrdWt")]
	private virtual TextBox _nOrdWt;

	internal virtual TextBox nOrdWt
	{
		get
		{
			return _nOrdWt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nOrdWt = value;
		}
	}

	internal virtual AxMSFlexGrid MSG_ORD
	{
		[CompilerGenerated]
		get
		{
			return _MSG_ORD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_ORD_ClickEvent;
			EventHandler eventHandler2 = MSG_ORD_EnterCell;
			EventHandler eventHandler3 = MSG_ORD_LeaveCell;
			AxMSFlexGrid val = _MSG_ORD;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_ORD = value;
			val = _MSG_ORD;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	internal virtual TextBox TEXT_ORD
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_ORD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_ORD_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_ORD_KeyDown);
			TextBox val2 = _TEXT_ORD;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_ORD = value;
			val2 = _TEXT_ORD;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nItmRate")]
	private virtual TextBox _nItmRate;

	internal virtual TextBox nItmRate
	{
		get
		{
			return _nItmRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nItmRate = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlUpi")]
	private virtual Panel _PnlUpi;

	internal virtual Panel PnlUpi
	{
		get
		{
			return _PnlUpi;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlUpi = value;
		}
	}

	internal virtual AxMSFlexGrid MSG_UPI
	{
		[CompilerGenerated]
		get
		{
			return _MSG_UPI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_UPI_ClickEvent;
			EventHandler eventHandler2 = MSG_UPI_EnterCell;
			EventHandler eventHandler3 = MSG_UPI_LeaveCell;
			AxMSFlexGrid val = _MSG_UPI;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_UPI = value;
			val = _MSG_UPI;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	internal virtual TextBox TEXT_UPI
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_UPI;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(TEXT_UPI_KeyDown);
			TextBox val2 = _TEXT_UPI;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_TEXT_UPI = value;
			val2 = _TEXT_UPI;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nItProfit")]
	private virtual Label _nItProfit;

	internal virtual Label nItProfit
	{
		get
		{
			return _nItProfit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nItProfit = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nBillProfit")]
	private virtual TextBox _nBillProfit;

	internal virtual TextBox nBillProfit
	{
		get
		{
			return _nBillProfit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nBillProfit = value;
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

	public TR_SALE_LBR()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_SALE_LBR_Load;
		((Form)this).Deactivate += TR_SALE_LBR_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_SALE_LBR_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_SALE_LBR_KeyDown);
		((Form)this).Activated += TR_SALE_LBR_Activated;
		((Form)this).Closed += TR_SALE_LBR_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_SALE_LBR_KeyUp);
		LessAdvAmt = 0.0;
		LessAdvNetWt = 0.0;
		CrDrTot = 0.0;
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
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f8: Expected O, but got Unknown
		//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b4: Expected O, but got Unknown
		//IL_0637: Unknown result type (might be due to invalid IL or missing references)
		//IL_0641: Expected O, but got Unknown
		//IL_06de: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e8: Expected O, but got Unknown
		//IL_0796: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a0: Expected O, but got Unknown
		//IL_0827: Unknown result type (might be due to invalid IL or missing references)
		//IL_0831: Expected O, but got Unknown
		//IL_08cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d6: Expected O, but got Unknown
		//IL_0965: Unknown result type (might be due to invalid IL or missing references)
		//IL_096f: Expected O, but got Unknown
		//IL_09d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09dc: Expected O, but got Unknown
		//IL_0a85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8f: Expected O, but got Unknown
		//IL_0af2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afc: Expected O, but got Unknown
		//IL_0ba5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baf: Expected O, but got Unknown
		//IL_0ccc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd6: Expected O, but got Unknown
		//IL_0de1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0deb: Expected O, but got Unknown
		//IL_0e4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e58: Expected O, but got Unknown
		//IL_0fea: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e3: Expected O, but got Unknown
		//IL_1198: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a2: Expected O, but got Unknown
		//IL_1235: Unknown result type (might be due to invalid IL or missing references)
		//IL_123f: Expected O, but got Unknown
		//IL_1337: Unknown result type (might be due to invalid IL or missing references)
		//IL_1341: Expected O, but got Unknown
		//IL_1452: Unknown result type (might be due to invalid IL or missing references)
		//IL_145c: Expected O, but got Unknown
		//IL_14d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_14e0: Expected O, but got Unknown
		//IL_15a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ab: Expected O, but got Unknown
		//IL_1652: Unknown result type (might be due to invalid IL or missing references)
		//IL_165c: Expected O, but got Unknown
		//IL_1757: Unknown result type (might be due to invalid IL or missing references)
		//IL_1761: Expected O, but got Unknown
		//IL_17c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_17cc: Expected O, but got Unknown
		//IL_18d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_18df: Expected O, but got Unknown
		//IL_19b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c1: Expected O, but got Unknown
		//IL_1a5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a67: Expected O, but got Unknown
		//IL_1ba2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bac: Expected O, but got Unknown
		//IL_1bf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c01: Expected O, but got Unknown
		//IL_1c7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c85: Expected O, but got Unknown
		//IL_1d06: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d10: Expected O, but got Unknown
		//IL_1dd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de1: Expected O, but got Unknown
		//IL_1e88: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e92: Expected O, but got Unknown
		//IL_1f13: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f1d: Expected O, but got Unknown
		//IL_1fa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fac: Expected O, but got Unknown
		//IL_2060: Unknown result type (might be due to invalid IL or missing references)
		//IL_206a: Expected O, but got Unknown
		//IL_211e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2128: Expected O, but got Unknown
		//IL_21e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ea: Expected O, but got Unknown
		//IL_2251: Unknown result type (might be due to invalid IL or missing references)
		//IL_225b: Expected O, but got Unknown
		//IL_22b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_22c0: Expected O, but got Unknown
		//IL_235f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2369: Expected O, but got Unknown
		//IL_2410: Unknown result type (might be due to invalid IL or missing references)
		//IL_241a: Expected O, but got Unknown
		//IL_2474: Unknown result type (might be due to invalid IL or missing references)
		//IL_247e: Expected O, but got Unknown
		//IL_253e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2548: Expected O, but got Unknown
		//IL_25f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2603: Expected O, but got Unknown
		//IL_2699: Unknown result type (might be due to invalid IL or missing references)
		//IL_26a3: Expected O, but got Unknown
		//IL_272c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2736: Expected O, but got Unknown
		//IL_27cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d9: Expected O, but got Unknown
		//IL_2865: Unknown result type (might be due to invalid IL or missing references)
		//IL_286f: Expected O, but got Unknown
		//IL_2917: Unknown result type (might be due to invalid IL or missing references)
		//IL_2921: Expected O, but got Unknown
		//IL_29dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_29e6: Expected O, but got Unknown
		//IL_2aa1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aab: Expected O, but got Unknown
		//IL_2b5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b66: Expected O, but got Unknown
		//IL_2c1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c24: Expected O, but got Unknown
		//IL_2cd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cdf: Expected O, but got Unknown
		//IL_2d93: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d9d: Expected O, but got Unknown
		//IL_2e51: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e5b: Expected O, but got Unknown
		//IL_2edc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ee6: Expected O, but got Unknown
		//IL_2f9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fa4: Expected O, but got Unknown
		//IL_3064: Unknown result type (might be due to invalid IL or missing references)
		//IL_306e: Expected O, but got Unknown
		//IL_30d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_30e1: Expected O, but got Unknown
		//IL_3192: Unknown result type (might be due to invalid IL or missing references)
		//IL_319c: Expected O, but got Unknown
		//IL_3250: Unknown result type (might be due to invalid IL or missing references)
		//IL_325a: Expected O, but got Unknown
		//IL_330e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3318: Expected O, but got Unknown
		//IL_33cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_33d6: Expected O, but got Unknown
		//IL_348a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3494: Expected O, but got Unknown
		//IL_3548: Unknown result type (might be due to invalid IL or missing references)
		//IL_3552: Expected O, but got Unknown
		//IL_3606: Unknown result type (might be due to invalid IL or missing references)
		//IL_3610: Expected O, but got Unknown
		//IL_36c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_36cb: Expected O, but got Unknown
		//IL_3789: Unknown result type (might be due to invalid IL or missing references)
		//IL_3793: Expected O, but got Unknown
		//IL_37ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_37f8: Expected O, but got Unknown
		//IL_3896: Unknown result type (might be due to invalid IL or missing references)
		//IL_38a0: Expected O, but got Unknown
		//IL_395b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3965: Expected O, but got Unknown
		//IL_3aa1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3aab: Expected O, but got Unknown
		//IL_3b4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b55: Expected O, but got Unknown
		//IL_3ba2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bac: Expected O, but got Unknown
		//IL_3c48: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c52: Expected O, but got Unknown
		//IL_3d10: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d1a: Expected O, but got Unknown
		//IL_3dd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ddc: Expected O, but got Unknown
		//IL_3e94: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e9e: Expected O, but got Unknown
		//IL_3f43: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f4d: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_SALE_LBR));
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
		chkWapp = new CheckBox();
		nItProfit = new Label();
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
		TEXT_ENTRY = new TextBox();
		lblItem = new Label();
		TEXT_IDTL = new TextBox();
		MSG_IDTL = new AxMSFlexGrid();
		PicImage = new PictureBox();
		MSG_TOT = new AxMSFlexGrid();
		MSG = new AxMSFlexGrid();
		DlgOpen = new OpenFileDialog();
		PicZoom = new PictureBox();
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
		MSG_PR_TOT = new AxMSFlexGrid();
		nTotWtCr = new TextBox();
		nTotWtDr = new TextBox();
		nCrAmt = new TextBox();
		nCrFine = new TextBox();
		nDrAmt = new TextBox();
		nDrFine = new TextBox();
		nDrRate = new TextBox();
		Label5 = new Label();
		Label12 = new Label();
		Label14 = new Label();
		Label15 = new Label();
		Label16 = new Label();
		Label17 = new Label();
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
		Label6 = new Label();
		nOrdWt = new TextBox();
		MSG_ORD = new AxMSFlexGrid();
		TEXT_ORD = new TextBox();
		Label8 = new Label();
		nItmRate = new TextBox();
		PnlUpi = new Panel();
		TEXT_UPI = new TextBox();
		MSG_UPI = new AxMSFlexGrid();
		nBillProfit = new TextBox();
		Label9 = new Label();
		Label23 = new Label();
		Label21 = new Label();
		nConvRate = new TextBox();
		nConvPrc = new TextBox();
		((Control)PnlBotam).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((ISupportInitialize)MSG_IDTL).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG2_TOTAL).BeginInit();
		((ISupportInitialize)MSG_PR).BeginInit();
		((ISupportInitialize)MSG_PR_TOT).BeginInit();
		((ISupportInitialize)MSG_ORD).BeginInit();
		((Control)PnlUpi).SuspendLayout();
		((ISupportInitialize)MSG_UPI).BeginInit();
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
		lblBook.Text = "Labour Work ";
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
		((Control)PnlBotam).TabIndex = 16;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkWapp);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)nItProfit);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(246, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(575, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((ButtonBase)chkWapp).BackColor = Color.Transparent;
		((Control)chkWapp).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWapp).ForeColor = Color.Black;
		((Control)chkWapp).Location = new Point(486, 3);
		((Control)chkWapp).Name = "chkWapp";
		((Control)chkWapp).RightToLeft = (RightToLeft)0;
		((Control)chkWapp).Size = new Size(86, 27);
		((Control)chkWapp).TabIndex = 8;
		((ButtonBase)chkWapp).Text = "Wapp";
		((ButtonBase)chkWapp).UseVisualStyleBackColor = false;
		((Control)chkWapp).Visible = false;
		((Control)nItProfit).BackColor = Color.Transparent;
		((Control)nItProfit).Font = new Font("Bahnschrift SemiCondensed", 11.25f);
		((Control)nItProfit).ForeColor = Color.White;
		((Control)nItProfit).Location = new Point(21, 0);
		((Control)nItProfit).Name = "nItProfit";
		((Control)nItProfit).Size = new Size(459, 34);
		((Control)nItProfit).TabIndex = 0;
		nItProfit.Text = "It Profit :";
		nItProfit.TextAlign = (ContentAlignment)16;
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
		((Control)TEXT_ENTRY).Location = new Point(360, 126);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 5;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)lblItem).Font = new Font("Franklin Gothic Book", 9.75f);
		((Control)lblItem).ForeColor = Color.Black;
		lblItem.ImeMode = (ImeMode)0;
		((Control)lblItem).Location = new Point(780, 39);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(299, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)16;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(205, 216);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 6;
		((Control)TEXT_IDTL).Visible = false;
		((Control)MSG_IDTL).Location = new Point(12, 200);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(778, 78);
		((Control)MSG_IDTL).TabIndex = 1140;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(1067, 203);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(103, 74);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((Control)MSG_TOT).Location = new Point(14, 181);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1156, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 97);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1158, 83);
		((Control)MSG).TabIndex = 1135;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(1181, 367);
		((Control)PicZoom).Name = "PicZoom";
		((Control)PicZoom).Size = new Size(35, 20);
		PicZoom.SizeMode = (PictureBoxSizeMode)4;
		PicZoom.TabIndex = 1147;
		PicZoom.TabStop = false;
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
		((Control)tAcCode).Location = new Point(105, 66);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(187, 66);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(379, 23);
		((Control)tAcName).TabIndex = 4;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(23, 65);
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
		((Control)tEmpCode).Location = new Point(464, 475);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(44, 23);
		((Control)tEmpCode).TabIndex = 13;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(514, 475);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(109, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(389, 476);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(385, 530);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(73, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(464, 530);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(159, 30);
		((Control)tVchDesc).TabIndex = 15;
		((Control)MSG2_TOTAL).Location = new Point(629, 285);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(541, 273);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG_PR).Location = new Point(12, 285);
		((Control)MSG_PR).Name = "MSG_PR";
		((AxHost)MSG_PR).OcxState = (State)componentResourceManager.GetObject("MSG_PR.OcxState");
		((Control)MSG_PR).Size = new Size(611, 69);
		((Control)MSG_PR).TabIndex = 1168;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(896, 388);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 12;
		((Control)TEXT_ENTRY_2).Visible = false;
		((TextBoxBase)TEXT_PR).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_PR).BorderStyle = (BorderStyle)0;
		((Control)TEXT_PR).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_PR).ForeColor = Color.White;
		((Control)TEXT_PR).Location = new Point(388, 312);
		((Control)TEXT_PR).Name = "TEXT_PR";
		((Control)TEXT_PR).RightToLeft = (RightToLeft)0;
		((Control)TEXT_PR).Size = new Size(100, 18);
		((Control)TEXT_PR).TabIndex = 7;
		((Control)MSG_PR_TOT).Location = new Point(16, 356);
		((Control)MSG_PR_TOT).Name = "MSG_PR_TOT";
		((AxHost)MSG_PR_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_PR_TOT.OcxState");
		((Control)MSG_PR_TOT).Size = new Size(603, 15);
		((Control)MSG_PR_TOT).TabIndex = 1179;
		((TextBoxBase)nTotWtCr).BackColor = Color.FromArgb(255, 224, 192);
		((Control)nTotWtCr).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nTotWtCr).ForeColor = Color.FromArgb(0, 0, 192);
		((Control)nTotWtCr).Location = new Point(464, 419);
		((TextBoxBase)nTotWtCr).MaxLength = 10;
		((Control)nTotWtCr).Name = "nTotWtCr";
		((TextBoxBase)nTotWtCr).ReadOnly = true;
		((Control)nTotWtCr).Size = new Size(90, 22);
		((Control)nTotWtCr).TabIndex = 16;
		nTotWtCr.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nTotWtDr).BackColor = Color.FromArgb(255, 224, 192);
		((Control)nTotWtDr).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nTotWtDr).ForeColor = Color.FromArgb(0, 0, 192);
		((Control)nTotWtDr).Location = new Point(464, 393);
		((TextBoxBase)nTotWtDr).MaxLength = 10;
		((Control)nTotWtDr).Name = "nTotWtDr";
		((TextBoxBase)nTotWtDr).ReadOnly = true;
		((Control)nTotWtDr).Size = new Size(90, 22);
		((Control)nTotWtDr).TabIndex = 15;
		nTotWtDr.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nCrAmt).BackColor = Color.White;
		((Control)nCrAmt).Font = new Font("Tahoma", 9f);
		((Control)nCrAmt).Location = new Point(95, 537);
		((TextBoxBase)nCrAmt).MaxLength = 10;
		((Control)nCrAmt).Name = "nCrAmt";
		((TextBoxBase)nCrAmt).ReadOnly = true;
		((Control)nCrAmt).Size = new Size(90, 22);
		((Control)nCrAmt).TabIndex = 19;
		nCrAmt.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nCrFine).BackColor = Color.Linen;
		((Control)nCrFine).Font = new Font("Tahoma", 9f);
		((Control)nCrFine).Location = new Point(95, 509);
		((TextBoxBase)nCrFine).MaxLength = 10;
		((Control)nCrFine).Name = "nCrFine";
		((Control)nCrFine).Size = new Size(90, 22);
		((Control)nCrFine).TabIndex = 17;
		nCrFine.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nDrAmt).BackColor = Color.White;
		((Control)nDrAmt).Font = new Font("Tahoma", 9f);
		((Control)nDrAmt).Location = new Point(286, 538);
		((TextBoxBase)nDrAmt).MaxLength = 10;
		((Control)nDrAmt).Name = "nDrAmt";
		((TextBoxBase)nDrAmt).ReadOnly = true;
		((Control)nDrAmt).Size = new Size(90, 22);
		((Control)nDrAmt).TabIndex = 20;
		nDrAmt.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nDrFine).BackColor = Color.Linen;
		((Control)nDrFine).Font = new Font("Tahoma", 9f);
		((Control)nDrFine).Location = new Point(286, 510);
		((TextBoxBase)nDrFine).MaxLength = 10;
		((Control)nDrFine).Name = "nDrFine";
		((Control)nDrFine).Size = new Size(90, 22);
		((Control)nDrFine).TabIndex = 18;
		nDrFine.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nDrRate).BackColor = Color.Lavender;
		((Control)nDrRate).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nDrRate).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nDrRate).Location = new Point(286, 482);
		((TextBoxBase)nDrRate).MaxLength = 10;
		((Control)nDrRate).Name = "nDrRate";
		((Control)nDrRate).Size = new Size(90, 22);
		((Control)nDrRate).TabIndex = 11;
		nDrRate.TextAlign = (HorizontalAlignment)1;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.FromArgb(192, 0, 0);
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(379, 421);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(79, 20);
		((Control)Label5).TabIndex = 1190;
		Label5.Text = "Tot Wt Cr";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)Label12).BackColor = Color.Transparent;
		((Control)Label12).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label12).ForeColor = Color.FromArgb(192, 0, 0);
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(380, 393);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(79, 20);
		((Control)Label12).TabIndex = 1191;
		Label12.Text = "Tot Wt Dr";
		Label12.TextAlign = (ContentAlignment)64;
		((Control)Label14).BackColor = Color.Transparent;
		((Control)Label14).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(12, 510);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(79, 20);
		((Control)Label14).TabIndex = 1192;
		Label14.Text = "Cr Fine";
		Label14.TextAlign = (ContentAlignment)64;
		((Control)Label15).BackColor = Color.Transparent;
		((Control)Label15).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(201, 509);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(79, 20);
		((Control)Label15).TabIndex = 1193;
		Label15.Text = "Dr Fine";
		Label15.TextAlign = (ContentAlignment)64;
		((Control)Label16).BackColor = Color.Transparent;
		((Control)Label16).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label16).ForeColor = Color.Black;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(11, 538);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(79, 20);
		((Control)Label16).TabIndex = 1194;
		Label16.Text = "Cr Amount";
		Label16.TextAlign = (ContentAlignment)64;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(201, 539);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(79, 20);
		((Control)Label17).TabIndex = 1195;
		Label17.Text = "Dr Amount";
		Label17.TextAlign = (ContentAlignment)64;
		((Control)lblRate).BackColor = Color.Transparent;
		((Control)lblRate).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblRate).ForeColor = Color.Navy;
		lblRate.ImeMode = (ImeMode)0;
		((Control)lblRate).Location = new Point(202, 483);
		((Control)lblRate).Name = "lblRate";
		((Control)lblRate).Size = new Size(79, 20);
		((Control)lblRate).TabIndex = 1199;
		lblRate.Text = "Dr Rate";
		lblRate.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nCrDays).BackColor = Color.White;
		((Control)nCrDays).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nCrDays).Location = new Point(464, 503);
		((TextBoxBase)nCrDays).MaxLength = 3;
		((Control)nCrDays).Name = "nCrDays";
		((Control)nCrDays).Size = new Size(44, 23);
		((Control)nCrDays).TabIndex = 14;
		((Control)Label22).BackColor = Color.Transparent;
		((Control)Label22).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label22).ForeColor = Color.Black;
		Label22.ImeMode = (ImeMode)0;
		((Control)Label22).Location = new Point(389, 504);
		((Control)Label22).Name = "Label22";
		((Control)Label22).Size = new Size(69, 20);
		((Control)Label22).TabIndex = 1201;
		Label22.Text = "Cr Days";
		Label22.TextAlign = (ContentAlignment)64;
		((Control)lblDiffAmt).BackColor = Color.Transparent;
		((Control)lblDiffAmt).Font = new Font("Arial", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblDiffAmt).ForeColor = Color.Maroon;
		lblDiffAmt.ImeMode = (ImeMode)0;
		((Control)lblDiffAmt).Location = new Point(514, 501);
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
		((Control)LOpAmt).Location = new Point(805, 203);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(113, 20);
		((Control)LOpAmt).TabIndex = 1205;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LOpGold).BackColor = Color.Transparent;
		((Control)LOpGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpGold).ForeColor = Color.Black;
		LOpGold.ImeMode = (ImeMode)0;
		((Control)LOpGold).Location = new Point(805, 229);
		((Control)LOpGold).Name = "LOpGold";
		((Control)LOpGold).Size = new Size(113, 20);
		((Control)LOpGold).TabIndex = 1206;
		LOpGold.Text = "OpGold";
		LOpGold.TextAlign = (ContentAlignment)64;
		((Control)LOpSilver).BackColor = Color.Transparent;
		((Control)LOpSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpSilver).ForeColor = Color.Black;
		LOpSilver.ImeMode = (ImeMode)0;
		((Control)LOpSilver).Location = new Point(805, 255);
		((Control)LOpSilver).Name = "LOpSilver";
		((Control)LOpSilver).Size = new Size(113, 20);
		((Control)LOpSilver).TabIndex = 1207;
		LOpSilver.Text = "OpSilver";
		LOpSilver.TextAlign = (ContentAlignment)64;
		((Control)LClSilver).BackColor = Color.Transparent;
		((Control)LClSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClSilver).ForeColor = Color.Black;
		LClSilver.ImeMode = (ImeMode)0;
		((Control)LClSilver).Location = new Point(948, 255);
		((Control)LClSilver).Name = "LClSilver";
		((Control)LClSilver).Size = new Size(113, 20);
		((Control)LClSilver).TabIndex = 1210;
		LClSilver.Text = "ClSilver";
		LClSilver.TextAlign = (ContentAlignment)64;
		((Control)lClGold).BackColor = Color.Transparent;
		((Control)lClGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lClGold).ForeColor = Color.Black;
		lClGold.ImeMode = (ImeMode)0;
		((Control)lClGold).Location = new Point(948, 229);
		((Control)lClGold).Name = "lClGold";
		((Control)lClGold).Size = new Size(113, 20);
		((Control)lClGold).TabIndex = 1209;
		lClGold.Text = "ClGold";
		lClGold.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(948, 203);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(113, 20);
		((Control)LClAmt).TabIndex = 1208;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Navy;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(380, 448);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(79, 20);
		((Control)Label6).TabIndex = 1212;
		Label6.Text = "Order Wt";
		Label6.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nOrdWt).BackColor = Color.Lavender;
		((Control)nOrdWt).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nOrdWt).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nOrdWt).Location = new Point(464, 447);
		((TextBoxBase)nOrdWt).MaxLength = 10;
		((Control)nOrdWt).Name = "nOrdWt";
		((Control)nOrdWt).Size = new Size(90, 22);
		((Control)nOrdWt).TabIndex = 17;
		nOrdWt.TextAlign = (HorizontalAlignment)1;
		((Control)MSG_ORD).Location = new Point(12, 375);
		((Control)MSG_ORD).Name = "MSG_ORD";
		((AxHost)MSG_ORD).OcxState = (State)componentResourceManager.GetObject("MSG_ORD.OcxState");
		((Control)MSG_ORD).Size = new Size(326, 70);
		((Control)MSG_ORD).TabIndex = 1213;
		((TextBoxBase)TEXT_ORD).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ORD).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ORD).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ORD).ForeColor = Color.White;
		((Control)TEXT_ORD).Location = new Point(199, 406);
		((Control)TEXT_ORD).Name = "TEXT_ORD";
		((Control)TEXT_ORD).RightToLeft = (RightToLeft)0;
		((Control)TEXT_ORD).Size = new Size(100, 18);
		((Control)TEXT_ORD).TabIndex = 8;
		((Control)Label8).BackColor = Color.Transparent;
		((Control)Label8).Enabled = false;
		((Control)Label8).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(573, 67);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(76, 20);
		((Control)Label8).TabIndex = 1216;
		Label8.Text = "Itm Rate";
		Label8.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nItmRate).BackColor = Color.White;
		((Control)nItmRate).Enabled = false;
		((Control)nItmRate).Font = new Font("Tahoma", 9f);
		((Control)nItmRate).Location = new Point(657, 68);
		((TextBoxBase)nItmRate).MaxLength = 10;
		((Control)nItmRate).Name = "nItmRate";
		((TextBoxBase)nItmRate).ReadOnly = true;
		((Control)nItmRate).Size = new Size(103, 22);
		((Control)nItmRate).TabIndex = 1215;
		nItmRate.TextAlign = (HorizontalAlignment)1;
		((Control)PnlUpi).Controls.Add((Control)(object)TEXT_UPI);
		((Control)PnlUpi).Controls.Add((Control)(object)MSG_UPI);
		((Control)PnlUpi).Location = new Point(1176, 285);
		((Control)PnlUpi).Name = "PnlUpi";
		((Control)PnlUpi).Size = new Size(611, 268);
		((Control)PnlUpi).TabIndex = 1217;
		((Control)PnlUpi).Visible = false;
		((TextBoxBase)TEXT_UPI).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_UPI).BorderStyle = (BorderStyle)0;
		((Control)TEXT_UPI).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_UPI).ForeColor = Color.White;
		((Control)TEXT_UPI).Location = new Point(255, 124);
		((Control)TEXT_UPI).Name = "TEXT_UPI";
		((Control)TEXT_UPI).Size = new Size(100, 18);
		((Control)TEXT_UPI).TabIndex = 11;
		((Control)TEXT_UPI).Visible = false;
		((Control)MSG_UPI).Location = new Point(7, 7);
		((Control)MSG_UPI).Name = "MSG_UPI";
		((AxHost)MSG_UPI).OcxState = (State)componentResourceManager.GetObject("MSG_UPI.OcxState");
		((Control)MSG_UPI).Size = new Size(598, 256);
		((Control)MSG_UPI).TabIndex = 0;
		((TextBoxBase)nBillProfit).BackColor = Color.White;
		((Control)nBillProfit).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nBillProfit).Location = new Point(95, 480);
		((TextBoxBase)nBillProfit).MaxLength = 10;
		((Control)nBillProfit).Name = "nBillProfit";
		((Control)nBillProfit).Size = new Size(90, 23);
		((Control)nBillProfit).TabIndex = 1229;
		nBillProfit.TextAlign = (HorizontalAlignment)1;
		((Control)nBillProfit).Visible = false;
		((Control)Label9).BackColor = Color.Transparent;
		((Control)Label9).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(11, 480);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(79, 20);
		((Control)Label9).TabIndex = 1230;
		Label9.Text = "Bill Profit";
		Label9.TextAlign = (ContentAlignment)64;
		((Control)Label9).Visible = false;
		((Control)Label23).BackColor = Color.Transparent;
		((Control)Label23).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label23).ForeColor = Color.FromArgb(192, 0, 0);
		Label23.ImeMode = (ImeMode)0;
		((Control)Label23).Location = new Point(9, 452);
		((Control)Label23).Name = "Label23";
		((Control)Label23).Size = new Size(79, 20);
		((Control)Label23).TabIndex = 1234;
		Label23.Text = "Conv %";
		Label23.TextAlign = (ContentAlignment)64;
		((Control)Label21).BackColor = Color.Transparent;
		((Control)Label21).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label21).ForeColor = Color.FromArgb(192, 0, 0);
		Label21.ImeMode = (ImeMode)0;
		((Control)Label21).Location = new Point(201, 455);
		((Control)Label21).Name = "Label21";
		((Control)Label21).Size = new Size(79, 20);
		((Control)Label21).TabIndex = 1233;
		Label21.Text = "Convrt Rate";
		Label21.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nConvRate).BackColor = Color.Beige;
		((Control)nConvRate).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nConvRate).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nConvRate).Location = new Point(286, 455);
		((TextBoxBase)nConvRate).MaxLength = 10;
		((Control)nConvRate).Name = "nConvRate";
		((Control)nConvRate).Size = new Size(90, 22);
		((Control)nConvRate).TabIndex = 10;
		nConvRate.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nConvPrc).BackColor = Color.Beige;
		((Control)nConvPrc).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nConvPrc).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nConvPrc).Location = new Point(94, 452);
		((TextBoxBase)nConvPrc).MaxLength = 10;
		((Control)nConvPrc).Name = "nConvPrc";
		((Control)nConvPrc).Size = new Size(90, 22);
		((Control)nConvPrc).TabIndex = 9;
		nConvPrc.TextAlign = (HorizontalAlignment)1;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label23);
		((Control)this).Controls.Add((Control)(object)Label21);
		((Control)this).Controls.Add((Control)(object)nConvRate);
		((Control)this).Controls.Add((Control)(object)nConvPrc);
		((Control)this).Controls.Add((Control)(object)PnlUpi);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)nItmRate);
		((Control)this).Controls.Add((Control)(object)TEXT_ORD);
		((Control)this).Controls.Add((Control)(object)MSG_ORD);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)nOrdWt);
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
		((Control)this).Controls.Add((Control)(object)Label17);
		((Control)this).Controls.Add((Control)(object)Label16);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)nDrRate);
		((Control)this).Controls.Add((Control)(object)nDrFine);
		((Control)this).Controls.Add((Control)(object)nDrAmt);
		((Control)this).Controls.Add((Control)(object)nCrFine);
		((Control)this).Controls.Add((Control)(object)nCrAmt);
		((Control)this).Controls.Add((Control)(object)nTotWtDr);
		((Control)this).Controls.Add((Control)(object)nTotWtCr);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG_PR_TOT);
		((Control)this).Controls.Add((Control)(object)MSG);
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
		((Control)this).Controls.Add((Control)(object)PicZoom);
		((Control)this).Controls.Add((Control)(object)TEXT_IDTL);
		((Control)this).Controls.Add((Control)(object)MSG_IDTL);
		((Control)this).Controls.Add((Control)(object)lblItem);
		((Control)this).Controls.Add((Control)(object)PicImage);
		((Control)this).Controls.Add((Control)(object)MSG_TOT);
		((Control)this).Controls.Add((Control)(object)mDay);
		((Control)this).Controls.Add((Control)(object)mTime);
		((Control)this).Controls.Add((Control)(object)mVchDate);
		((Control)this).Controls.Add((Control)(object)lblBDate);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tVchNo);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)nBillProfit);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "TR_SALE_LBR";
		((Form)this).Text = "Labour Work";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((ISupportInitialize)MSG_IDTL).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG2_TOTAL).EndInit();
		((ISupportInitialize)MSG_PR).EndInit();
		((ISupportInitialize)MSG_PR_TOT).EndInit();
		((ISupportInitialize)MSG_ORD).EndInit();
		((Control)PnlUpi).ResumeLayout(false);
		((Control)PnlUpi).PerformLayout();
		((ISupportInitialize)MSG_UPI).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_UPI_CLEAR()
	{
		AxMSFlexGrid mSG_UPI = MSG_UPI;
		MsgClear = true;
		mSG_UPI.Clear();
		mSG_UPI.Cols = 6;
		mSG_UPI.Rows = 2;
		mSG_UPI.Row = 0;
		mSG_UPI[0] = 325;
		checked
		{
			mSG_UPI[0] = (int)Math.Round(450.0 * ColCon);
			mSG_UPI[0] = 3;
			mSG_UPI[0, 0] = "Sr.";
			mSG_UPI[1] = (int)Math.Round(1000.0 * ColCon);
			mSG_UPI[1] = 0;
			mSG_UPI[0, 1] = "AcCode";
			mSG_UPI[2] = (int)Math.Round(2700.0 * ColCon);
			mSG_UPI[2] = 0;
			mSG_UPI[0, 2] = "Upi Bank Name";
			mSG_UPI[3] = (int)Math.Round(1400.0 * ColCon);
			mSG_UPI[3] = 0;
			mSG_UPI[0, 3] = "UpiType";
			mSG_UPI[4] = (int)Math.Round(1900.0 * ColCon);
			mSG_UPI[4] = 0;
			mSG_UPI[0, 4] = "Upi Id";
			mSG_UPI[5] = (int)Math.Round(1200.0 * ColCon);
			mSG_UPI[5] = 7;
			mSG_UPI[0, 5] = "UpiAmt";
			mSG_UPI[0] = (int)Math.Round(325.0 * ColCon);
			mSG_UPI[1] = (int)Math.Round(300.0 * ColCon);
			mSG_UPI.Row = 1;
			mSG_UPI.Col = 0;
			((Control)TEXT_UPI).Visible = false;
			MsgClear = false;
			mSG_UPI = null;
		}
	}

	private void CommPassAddUpi()
	{
		AxMSFlexGrid mSG_UPI = MSG_UPI;
		mSG_UPI[mSG_UPI.Row, 0] = Conversions.ToString(MSG_UPI.Row);
		mSG_UPI = null;
	}

	private void MSG_UPI_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_UPI = MSG_UPI;
		UpDown = false;
		checked
		{
			if (mSG_UPI.CellWidth >= 0)
			{
				((Control)TEXT_UPI).Left = (int)Math.Round((double)((Control)mSG_UPI).Left + (double)mSG_UPI.CellLeft / 15.0);
				((Control)TEXT_UPI).Top = (int)Math.Round((double)((Control)mSG_UPI).Top + (double)mSG_UPI.CellTop / 15.0);
				((Control)TEXT_UPI).Width = (int)Math.Round((double)mSG_UPI.CellWidth / 15.0);
				((Control)TEXT_UPI).Height = (int)Math.Round((double)mSG_UPI.CellHeight / 15.0);
				((Control)TEXT_UPI).Visible = true;
				((TextBoxBase)TEXT_UPI).SelectAll();
				((Control)TEXT_UPI).Focus();
				mSG_UPI = null;
			}
		}
	}

	private void MSG_UPI_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_UPI = MSG_UPI;
		checked
		{
			if (mSG_UPI[mSG_UPI.Col] == 0)
			{
				TEXT_UPI.Text = "";
				mSG_UPI[mSG_UPI.Row, mSG_UPI.Col] = "";
				DC_Main.M = 1;
				while (mSG_UPI[mSG_UPI.Col] == 0)
				{
					if (Msgleft)
					{
						if (mSG_UPI.Col > 1)
						{
							mSG_UPI.Col -= 1;
						}
					}
					else if (mSG_UPI.Col < mSG_UPI.Cols - 1)
					{
						mSG_UPI.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 5)
					{
						break;
					}
				}
			}
			if (!((mSG_UPI.Row == 0) | (mSG_UPI.CellWidth <= 0)) && MSG_UPI[MSG_UPI.Col] != 0)
			{
				((Control)TEXT_UPI).Left = (int)Math.Round((double)((Control)mSG_UPI).Left + (double)mSG_UPI.CellLeft / 15.0);
				((Control)TEXT_UPI).Top = (int)Math.Round((double)((Control)mSG_UPI).Top + (double)mSG_UPI.CellTop / 15.0);
				((Control)TEXT_UPI).Width = (int)Math.Round((double)mSG_UPI.CellWidth / 15.0);
				((Control)TEXT_UPI).Height = (int)Math.Round((double)mSG_UPI.CellHeight / 15.0);
				((Control)TEXT_UPI).Visible = true;
				((TextBoxBase)TEXT_UPI).ReadOnly = false;
				switch (MSG_UPI.Col)
				{
				case 0:
					((TextBoxBase)TEXT_UPI).MaxLength = 5;
					TEXT_UPI.Text = mSG_UPI[mSG_UPI.Row, mSG_UPI.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_UPI).MaxLength = 10;
					TEXT_UPI.Text = mSG_UPI[mSG_UPI.Row, mSG_UPI.Col];
					break;
				case 3:
				case 4:
					((TextBoxBase)TEXT_UPI).MaxLength = 25;
					TEXT_UPI.Text = mSG_UPI[mSG_UPI.Row, mSG_UPI.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_UPI).MaxLength = 50;
					TEXT_UPI.Text = mSG_UPI[mSG_UPI.Row, mSG_UPI.Col];
					break;
				case 5:
					((TextBoxBase)TEXT_UPI).MaxLength = 10;
					TEXT_UPI.Text = Strings.Format((object)Conversion.Val(mSG_UPI[mSG_UPI.Row, mSG_UPI.Col]), "0.00");
					break;
				}
				mSG_UPI = null;
				((TextBoxBase)TEXT_UPI).SelectAll();
			}
		}
	}

	private void MSG_UPI_LeaveCell(object sender, EventArgs e)
	{
		if (!UpDown && !MsgClear && MSG_UPI.Row != 0 && MSG_UPI[MSG_UPI.Col] != 0 && ((Control)TEXT_UPI).Visible)
		{
			AxMSFlexGrid mSG_UPI = MSG_UPI;
			switch (MSG_UPI.Col)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
				MSG_UPI[mSG_UPI.Row, mSG_UPI.Col] = TEXT_UPI.Text;
				break;
			case 5:
				MSG_UPI[mSG_UPI.Row, mSG_UPI.Col] = Strings.Format((object)Conversion.Val(TEXT_UPI.Text), "0.00");
				TotAmt();
				break;
			}
			mSG_UPI = null;
		}
	}

	private void TotAmt()
	{
		checked
		{
			int num = MSG_UPI.Rows - 1;
			double num2 = default(double);
			for (int i = 1; i <= num; i++)
			{
				if ((Operators.CompareString(MSG_UPI[i, 1], "", false) != 0) & (Conversion.Val(MSG_UPI[i, 5]) != 0.0))
				{
					num2 += Conversion.Val(MSG_UPI[i, 5]);
				}
			}
			MSG2_TOTAL[12, 1] = Strings.Format((object)num2, "0.00");
			BILL_TOTAL();
		}
	}

	private void TEXT_UPI_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Invalid comparison between Unknown and I4
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Invalid comparison between Unknown and I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Invalid comparison between Unknown and I4
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Invalid comparison between Unknown and I4
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Invalid comparison between Unknown and I4
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Invalid comparison between Unknown and I4
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Invalid comparison between Unknown and I4
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_0682: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		AxMSFlexGrid mSG_UPI = MSG_UPI;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == 112)
		{
			if (mSG_UPI.Col == 3)
			{
				UpiTypeAdd = true;
			}
		}
		else if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = mSG_UPI.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						mSG_UPI[mSG_UPI.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					TEXT_UPI.Text = "";
					TotAmt();
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG_UPI.Col > 1)
				{
					mSG_UPI.Col = checked(mSG_UPI.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				checked
				{
					if (mSG_UPI.Col < mSG_UPI.Cols - 1)
					{
						mSG_UPI.Col += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 38)
			{
				if (mSG_UPI.Row > 1)
				{
					mSG_UPI.Row = checked(mSG_UPI.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_UPI.Row < mSG_UPI.Rows - 1)
					{
						mSG_UPI.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG_UPI.Col)
					{
					case 1:
						if (Operators.CompareString(TEXT_UPI.Text, "", false) == 0)
						{
							TotAmt();
							((Control)PnlUpi).Visible = false;
							((Control)TEXT_UPI).Visible = false;
							MSG2_TOTAL.Col = 3;
							MSG2_TOTAL.Row = 12;
							MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
							((Control)TEXT_ENTRY_2).Visible = true;
							((Control)TEXT_ENTRY_2).Focus();
							return;
						}
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + TEXT_UPI.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '19','22','23','21','02') ORDER BY A.LC_CODE,A.AC_NAME";
							}
							else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
							{
								DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND C.AC_GR in('19','22','23','21','02') AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 AND A.AC_GR in( '19','22','23','21','02') ORDER BY C.AC_NAME ";
							}
							else
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR in( '19','22','23','02') ORDER BY A.AC_NAME";
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
								MS_ACCT mS_ACCT = new MS_ACCT();
								((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
								((Control)mS_ACCT).Show();
								((Control)mS_ACCT).Focus();
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
							{
								TEXT_UPI.Text = DC_Main.ColValue[1];
								mSG_UPI[mSG_UPI.Row, 1] = DC_Main.ColValue[1];
								mSG_UPI[mSG_UPI.Row, 2] = DC_Main.ColValue[0];
							}
							((Control)TEXT_UPI).Focus();
							return;
						}
						mSG_UPI[mSG_UPI.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CODE"], (object)""));
						mSG_UPI[mSG_UPI.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
						break;
					case 3:
					{
						DC_Main.RsQry = "SELECT UPI_TYPE As UpiTypeL  From UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND UPI_TYPE = '" + TEXT_UPI.Text + "' ORDER BY UPI_TYPE";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count != 0)
						{
							break;
						}
						int num2 = MSG_UPI.Rows - 1;
						for (int i = 1; i <= num2; i++)
						{
							if (Operators.CompareString(mSG_UPI[i, 3], TEXT_UPI.Text, false) == 0)
							{
								UpiTypeAdd = true;
							}
						}
						if (!UpiTypeAdd)
						{
							DC_Main.RsQry = "SELECT DISTINCT UPI_TYPE As UpiTypeL From UPI_DATA ORDER BY UPI_TYPE";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[2];
							DC_Main.ColWidth[0] = 350.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								TEXT_UPI.Text = DC_Main.ColValue[0];
							}
							return;
						}
						UpiTypeAdd = false;
						break;
					}
					case 4:
						if (Operators.CompareString(TEXT_UPI.Text, "", false) != 0)
						{
							DC_Main.RsQry = "SELECT UPI_ID,CO_BOOK,VCH_NO FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND UPI_ID = '" + TEXT_UPI.Text + "'";
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count > 0)
							{
								Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This UpiId already Exist In Book No =  ", DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)" AND VchNo = "), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)" Please Change Upi Id ..."), (MsgBoxStyle)0, (object)null);
								((TextBoxBase)TEXT_UPI).SelectAll();
								return;
							}
						}
						break;
					case 5:
						if (Conversion.Val(TEXT_UPI.Text) != 0.0)
						{
							if (mSG_UPI.Row == mSG_UPI.Rows - 1)
							{
								mSG_UPI.Rows += 1;
								mSG_UPI.Row += 1;
								CommPassAddUpi();
								mSG_UPI.Col = 1;
							}
							else
							{
								mSG_UPI.Row += 1;
								mSG_UPI.Col = 1;
								((Control)TEXT_UPI).Visible = true;
								((Control)TEXT_UPI).Focus();
							}
						}
						return;
					}
					if (mSG_UPI.Col < mSG_UPI.Cols - 1)
					{
						MSG_UPI.Col += 1;
					}
					((Control)TEXT_UPI).Visible = true;
					((Control)TEXT_UPI).Focus();
				}
			}
		}
		mSG_UPI = null;
	}

	private void MSG_ORD_CLEAR()
	{
		AxMSFlexGrid mSG_ORD = MSG_ORD;
		mSG_ORD.Clear();
		mSG_ORD.Cols = 9;
		mSG_ORD.FixedRows = 1;
		mSG_ORD.Rows = 2;
		mSG_ORD.Row = 1;
		mSG_ORD[0] = 0;
		mSG_ORD[1] = 0;
		mSG_ORD.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_ORD[0] = (int)Math.Round(400.0 * ColCon);
			mSG_ORD[0] = 3;
			mSG_ORD[0, 0] = "Sr";
			mSG_ORD[1] = (int)Math.Round(1200.0 * ColCon);
			mSG_ORD[1] = 0;
			mSG_ORD[0, 1] = "Ord No";
			mSG_ORD[2] = (int)Math.Round(1400.0 * ColCon);
			mSG_ORD[2] = 7;
			mSG_ORD[0, 2] = "Ord Weight";
			mSG_ORD[3] = (int)Math.Round(1400.0 * ColCon);
			mSG_ORD[3] = 7;
			mSG_ORD[0, 3] = "Ord Amt";
			mSG_ORD[5] = 0;
			mSG_ORD[6] = 0;
			mSG_ORD[7] = 0;
			mSG_ORD[8] = 0;
			mSG_ORD[4] = 0;
			mSG_ORD[1, 0] = Conversions.ToString(1);
			mSG_ORD.Row = 1;
			mSG_ORD.Col = 1;
			((Control)TEXT_ORD).Visible = false;
			mSG_ORD[0] = (int)Math.Round(325.0 * ColCon);
			mSG_ORD[1] = (int)Math.Round(300.0 * ColCon);
			mSG_ORD.ScrollBars = (ScrollBarsSettings)3;
			mSG_ORD = null;
		}
	}

	private void MSG_ORD_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_ORD = MSG_ORD;
		checked
		{
			if (mSG_ORD.CellWidth >= 0)
			{
				((Control)TEXT_ORD).Left = (int)Math.Round((double)((Control)mSG_ORD).Left + (double)mSG_ORD.CellLeft / 15.0);
				((Control)TEXT_ORD).Top = (int)Math.Round((double)((Control)mSG_ORD).Top + (double)mSG_ORD.CellTop / 15.0);
				((Control)TEXT_ORD).Width = (int)Math.Round((double)mSG_ORD.CellWidth / 15.0);
				((Control)TEXT_ORD).Height = (int)Math.Round((double)mSG_ORD.CellHeight / 15.0);
				TEXT_ORD.Text = mSG_ORD[mSG_ORD.Row, mSG_ORD.Col];
				((Control)TEXT_ORD).Visible = true;
				((TextBoxBase)TEXT_ORD).SelectAll();
				((Control)TEXT_ORD).Focus();
				mSG_ORD = null;
			}
		}
	}

	private void MSG_ORD_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_ORD = MSG_ORD;
		checked
		{
			if (!((mSG_ORD.Row == 0) | (mSG_ORD.CellWidth <= 0)) && mSG_ORD[mSG_ORD.Col] != 0)
			{
				((Control)TEXT_ORD).Left = (int)Math.Round((double)((Control)mSG_ORD).Left + (double)mSG_ORD.CellLeft / 15.0);
				((Control)TEXT_ORD).Top = (int)Math.Round((double)((Control)mSG_ORD).Top + (double)mSG_ORD.CellTop / 15.0);
				((Control)TEXT_ORD).Width = (int)Math.Round((double)mSG_ORD.CellWidth / 15.0);
				((Control)TEXT_ORD).Height = (int)Math.Round((double)mSG_ORD.CellHeight / 15.0);
				((Control)TEXT_ORD).Visible = true;
				((TextBoxBase)TEXT_ORD).ReadOnly = false;
				switch (MSG_ORD.Col)
				{
				case 0:
					((TextBoxBase)TEXT_ORD).MaxLength = 5;
					TEXT_ORD.Text = mSG_ORD[mSG_ORD.Row, mSG_ORD.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_ORD).MaxLength = 8;
					TEXT_ORD.Text = mSG_ORD[mSG_ORD.Row, mSG_ORD.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_ORD).MaxLength = 10;
					TEXT_ORD.Text = Strings.Format((object)Conversion.Val(mSG_ORD[mSG_ORD.Row, mSG_ORD.Col]), "0.000");
					break;
				case 3:
					((TextBoxBase)TEXT_ORD).MaxLength = 10;
					TEXT_ORD.Text = Strings.Format((object)Conversion.Val(mSG_ORD[mSG_ORD.Row, mSG_ORD.Col]), "0.00");
					break;
				}
				mSG_ORD = null;
				((TextBoxBase)TEXT_ORD).SelectAll();
			}
		}
	}

	private void MSG_ORD_LeaveCell(object sender, EventArgs e)
	{
		if (!MsgClearIdtl && MSG_ORD.Row != 0 && MSG_ORD[MSG_ORD.Col] != 0 && ((Control)TEXT_ORD).Visible)
		{
			AxMSFlexGrid mSG_ORD = MSG_ORD;
			switch (MSG_ORD.Col)
			{
			case 1:
				mSG_ORD[mSG_ORD.Row, mSG_ORD.Col] = TEXT_ORD.Text;
				break;
			case 2:
				mSG_ORD[mSG_ORD.Row, mSG_ORD.Col] = Strings.Format((object)Conversion.Val(TEXT_ORD.Text), "0.000");
				break;
			case 3:
				mSG_ORD[mSG_ORD.Row, mSG_ORD.Col] = Strings.Format((object)Conversion.Val(TEXT_ORD.Text), "0.00");
				break;
			}
			mSG_ORD = null;
			BILL_TOTAL();
		}
	}

	private void TEXT_ORD_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_ORD_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected I4, but got Unknown
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
		AxMSFlexGrid mSG_ORD = MSG_ORD;
		Keys keyCode = e.KeyCode;
		checked
		{
			if (unchecked((int)keyCode) != 13)
			{
				switch (unchecked(keyCode - 37))
				{
				case 0:
					if (mSG_ORD.Col > 1)
					{
						mSG_ORD.Col -= 1;
					}
					return;
				case 2:
					if (mSG_ORD.Col < 19)
					{
						mSG_ORD.Col += 1;
					}
					return;
				case 1:
					if (mSG_ORD.Row > 1)
					{
						mSG_ORD.Row -= 1;
					}
					return;
				case 3:
					if (mSG_ORD.Row < mSG_ORD.Rows - 1)
					{
						mSG_ORD.Row += 1;
					}
					return;
				}
			}
			else
			{
				switch (mSG_ORD.Col)
				{
				case 1:
					if (Operators.CompareString(TEXT_ORD.Text, "", false) == 0)
					{
						((Control)nConvPrc).Focus();
						((Control)TEXT_ORD).Visible = false;
						return;
					}
					if (!((Operators.CompareString(TEXT_ORD.Text, "", false) == 0) | (Operators.CompareString(TEXT_ORD.Text, mSG_ORD[mSG_ORD.Row, 1], false) != 0)))
					{
						break;
					}
					DC_Main.RsQry = "SELECT * FROM SL_ORD_DATA AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG_ORD[mSG_ORD.Row, 5] + "' AND CO_BOOK = '" + mSG_ORD[mSG_ORD.Row, 6] + "' AND VCH_NO = '" + TEXT_ORD.Text + "' ";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count == 0)
					{
						DC_Main.RsQry = "SELECT A.AC_NAME AS PartyNameL,A.AC_CODE AS AcCodeL,A.VCH_NO AS VchNoT,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS OrderDtL,A.ADV_AMT AS AmountR,SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_AMT ELSE 0 END) AS AdjAmountR ,A.OLD_GL AS GoldW,SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_GOLD ELSE 0 END) AS AdjGoldW,A.OLD_SL AS SilverW,SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_SILVER ELSE 0 END) AS AdjSilverW ,A.CO_YEAR AS YearL,A.CO_BOOK as BookL,A.HD_VCH_NO As HdVchNoL FROM SL_ORD_DATA AS A LEFT JOIN SL_ORD_ADJ AS B ON  A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC AND A.CO_YEAR = B.ORD_YRCD AND A.CO_BOOK = B.ORD_DBCD AND A.VCH_NO = B.ORD_NO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  GROUP BY A.AC_NAME,A.AC_CODE,A.VCH_NO,A.VCH_DATE,A.ADV_AMT,A.OLD_GL,A.OLD_SL,A.CO_YEAR,A.CO_BOOK,A.HD_VCH_NO HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END)+SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_GOLD ELSE - B.ORD_GOLD END)+SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_SILVER ELSE - B.ORD_SILVER END) > 0  ORDER BY A.VCH_DATE,A.VCH_NO ";
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.ColWidth = new double[14];
						DC_Main.ColWidth[0] = 300.0;
						DC_Main.ColWidth[1] = 90.0;
						DC_Main.ColWidth[2] = 85.0;
						DC_Main.ColWidth[3] = 105.0;
						DC_Main.ColWidth[4] = 105.0;
						DC_Main.ColWidth[5] = 105.0;
						DC_Main.ColWidth[6] = 100.0;
						DC_Main.ColWidth[7] = 100.0;
						DC_Main.ColWidth[8] = 100.0;
						DC_Main.ColWidth[9] = 100.0;
						DC_Main.ColWidth[10] = 0.0;
						DC_Main.ColWidth[11] = 0.0;
						DC_Main.ColWidth[12] = 0.0;
						DC_Main.HelpSelect = 1;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						if (!DC_Main.HelpClose)
						{
							if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
							{
								TEXT_ORD.Text = DC_Main.ColValue[2];
								mSG_ORD[mSG_ORD.Row, 5] = DC_Main.ColValue[10];
								mSG_ORD[mSG_ORD.Row, 6] = DC_Main.ColValue[11];
								mSG_ORD[mSG_ORD.Row, 7] = DC_Main.ColValue[1];
								mSG_ORD[mSG_ORD.Row, 8] = DC_Main.ColValue[12];
								mSG_ORD[mSG_ORD.Row, 4] = DC_Main.MLc_code;
								LessAdvAmt = Conversions.ToDouble(DC_Main.ColValue[5]);
								LessAdvNetWt = Conversion.Val(DC_Main.ColValue[7]) + Conversion.Val(DC_Main.ColValue[9]);
							}
							((Control)TEXT_ORD).Focus();
						}
					}
					else
					{
						mSG_ORD[mSG_ORD.Row, 1] = TEXT_ORD.Text;
						mSG_ORD[mSG_ORD.Row, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CO_BOOK"], (object)""));
						mSG_ORD[mSG_ORD.Row, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["HD_VCH_NO"], (object)""));
						AxMSFlexGrid obj = mSG_ORD;
						int row = mSG_ORD.Row;
						DataRow dataRow;
						object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["ADV_AMT"]);
						double num = DC_Main.Fnv(ref Value);
						dataRow["ADV_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						obj[row, 3] = Strings.Format((object)(num - LessAdvAmt), "0.00");
						if (cboItemTyp.SelectedIndex == 1)
						{
							AxMSFlexGrid obj2 = mSG_ORD;
							int row2 = mSG_ORD.Row;
							Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["OLD_SL"]);
							double num2 = DC_Main.Fnv(ref Value);
							dataRow["OLD_SL"] = RuntimeHelpers.GetObjectValue(Value);
							obj2[row2, 2] = Strings.Format((object)(num2 - LessAdvNetWt), "0.000");
						}
						else
						{
							AxMSFlexGrid obj3 = mSG_ORD;
							int row3 = mSG_ORD.Row;
							Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["OLD_GL"]);
							double num3 = DC_Main.Fnv(ref Value);
							dataRow["OLD_GL"] = RuntimeHelpers.GetObjectValue(Value);
							obj3[row3, 2] = Strings.Format((object)(num3 - LessAdvNetWt), "0.000");
						}
						mSG_ORD[mSG_ORD.Row, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CODE"], (object)""));
						mSG_ORD[mSG_ORD.Row, 4] = DC_Main.MLc_code;
						LessAdvAmt = 0.0;
						BILL_TOTAL();
					}
					return;
				case 3:
					if (mSG_ORD.Row == mSG_ORD.Rows - 1)
					{
						mSG_ORD[mSG_ORD.Row, 3] = Strings.Format((object)Conversion.Val(TEXT_ORD.Text), "0.00");
						mSG_ORD.Rows += 1;
						mSG_ORD.Row += 1;
						mSG_ORD.Col = 1;
						mSG_ORD[mSG_ORD.Row, 0] = Conversions.ToString(mSG_ORD.Row);
					}
					else
					{
						mSG_ORD.Row += 1;
					}
					mSG_ORD.Col = 1;
					((Control)TEXT_ORD).Visible = true;
					((Control)TEXT_ORD).Focus();
					return;
				}
				if (mSG_ORD.Col < mSG_ORD.Cols - 1)
				{
					mSG_ORD.Col += 1;
				}
				((Control)TEXT_ORD).Visible = true;
				((Control)TEXT_ORD).Focus();
			}
			mSG_ORD = null;
		}
	}

	private void MSG_PR_CLEAR()
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		mSG_PR.Clear();
		mSG_PR.Cols = 39;
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
			mSG_PR[1] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[1] = 0;
			mSG_PR[0, 1] = "ItCode";
			mSG_PR[2] = (int)Math.Round(2000.0 * ColCon);
			mSG_PR[2] = 0;
			mSG_PR[0, 2] = "ItName";
			mSG_PR[3] = (int)Math.Round(600.0 * ColCon);
			mSG_PR[3] = 7;
			mSG_PR[0, 3] = "Pcs";
			mSG_PR[4] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[4] = 7;
			mSG_PR[0, 4] = "GrWt";
			mSG_PR[5] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[5] = 7;
			mSG_PR[0, 5] = "NetWt";
			mSG_PR[6] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[6] = 7;
			mSG_PR[0, 6] = "Touch";
			mSG_PR[8] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[8] = 7;
			mSG_PR[0, 8] = "Fine";
			mSG_PR[10] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[10] = 0;
			mSG_PR[0, 10] = "Counter";
			mSG_PR[11] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[11] = 0;
			mSG_PR[0, 11] = "Design";
			mSG_PR[12] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[12] = 7;
			mSG_PR[0, 12] = "BagWt";
			mSG_PR[13] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[13] = 7;
			mSG_PR[0, 13] = "PsWt";
			mSG_PR[14] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[14] = 7;
			mSG_PR[0, 14] = "OthWt";
			mSG_PR[9] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[9] = 7;
			mSG_PR[0, 9] = "GhtWt";
			mSG_PR[15] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[15] = 7;
			mSG_PR[0, 15] = "West%";
			mSG_PR[7] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[7] = 7;
			mSG_PR[0, 7] = "LTouch";
			mSG_PR[16] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[16] = 7;
			mSG_PR[0, 16] = "HmFine";
			mSG_PR[17] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[17] = 7;
			mSG_PR[0, 17] = "SlvFine";
			mSG_PR[18] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[18] = 3;
			mSG_PR[0, 18] = "Sign";
			mSG_PR[19] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[19] = 7;
			mSG_PR[0, 19] = "Rate";
			mSG_PR[20] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[20] = 7;
			mSG_PR[0, 20] = "ItAmt";
			mSG_PR[21] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[21] = 7;
			mSG_PR[0, 21] = "Lbr%";
			mSG_PR[22] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[22] = 3;
			mSG_PR[0, 22] = "Ltype";
			mSG_PR[23] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[23] = 7;
			mSG_PR[0, 23] = "LRate";
			mSG_PR[24] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[24] = 7;
			mSG_PR[0, 24] = "LAmt";
			mSG_PR[25] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[25] = 7;
			mSG_PR[0, 25] = "OthAmt";
			mSG_PR[26] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[26] = 3;
			mSG_PR[0, 26] = "ORate";
			mSG_PR[27] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[27] = 7;
			mSG_PR[0, 27] = "OFine";
			mSG_PR[28] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[28] = 7;
			mSG_PR[0, 28] = "Mrp";
			mSG_PR[30] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[30] = 7;
			mSG_PR[0, 30] = "TotAmt";
			mSG_PR[31] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[31] = 7;
			mSG_PR[0, 31] = "TaxPrc";
			mSG_PR[29] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[29] = 7;
			mSG_PR[0, 29] = "NetAmt";
			mSG_PR[32] = 0;
			mSG_PR[33] = 0;
			mSG_PR[34] = 0;
			mSG_PR[35] = 0;
			mSG_PR[36] = 0;
			mSG_PR[37] = 0;
			mSG_PR[38] = 0;
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
					dataView.RowFilter = " BOOK_NAME = 'LBR_REC' AND COL_NAME = '" + mSG_PR[0, DC_Main.M] + "'";
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
			if (MSG[1] == 0)
			{
				mSG_PR[19] = (int)Math.Round(1200.0 * ColCon);
				mSG_PR[19] = 7;
				mSG_PR[0, 19] = "Rate";
				mSG_PR[20] = (int)Math.Round(1400.0 * ColCon);
				mSG_PR[20] = 7;
				mSG_PR[0, 20] = "ItAmt";
				mSG_PR[29] = (int)Math.Round(1400.0 * ColCon);
				mSG_PR[29] = 7;
				mSG_PR[0, 29] = "NetAmt";
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
		mSG_PR[mSG_PR.Row, 18] = "+";
		mSG_PR = null;
	}

	private void TEXT_PR_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_PR_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Invalid comparison between Unknown and I4
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Invalid comparison between Unknown and I4
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Invalid comparison between Unknown and I4
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Invalid comparison between Unknown and I4
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Invalid comparison between Unknown and I4
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
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
					Interaction.MsgBox((object)"Record is Deleted....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else
		{
			if ((int)keyCode == 37)
			{
				checked
				{
					if (mSG_PR.Col > 1)
					{
						Msgleft = true;
						mSG_PR.Col -= 1;
					}
					((TextBoxBase)TEXT_PR).SelectionLength = Strings.Len(TEXT_PR.Text) + 1;
					return;
				}
			}
			if ((int)keyCode == 39)
			{
				if (mSG_PR.Col < 29)
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
									mSG_PR[mSG_PR.Row, 1] = DC_Main.ColValue[1];
									mSG_PR[mSG_PR.Row, 2] = DC_Main.ColValue[0];
									mSG_PR[mSG_PR.Row, 32] = DC_Main.ColValue[4];
								}
								((Control)TEXT_PR).Focus();
							}
							return;
						}
						mSG_PR[mSG_PR.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_PR[mSG_PR.Row, 32] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 33] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						break;
					case 4:
						if ((Conversion.Val(TEXT_PR.Text) == 0.0) & (Operators.CompareString(mSG_PR[mSG_PR.Row, 33], "P", false) != 0))
						{
							((Control)TEXT_PR).Focus();
							return;
						}
						break;
					case 8:
						if (mSG_PR.Row == mSG_PR.Rows - 1)
						{
							mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
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
			if (!((mSG_PR.Row == 0) | (mSG_PR.CellWidth <= 0)) && mSG_PR[mSG_PR.Col] != 0)
			{
				((Control)TEXT_PR).Left = (int)Math.Round((double)((Control)mSG_PR).Left + (double)mSG_PR.CellLeft / 15.0);
				((Control)TEXT_PR).Top = (int)Math.Round((double)((Control)mSG_PR).Top + (double)mSG_PR.CellTop / 15.0);
				((Control)TEXT_PR).Width = (int)Math.Round((double)mSG_PR.CellWidth / 15.0);
				((Control)TEXT_PR).Height = (int)Math.Round((double)mSG_PR.CellHeight / 15.0);
				((Control)TEXT_PR).Visible = true;
				((TextBoxBase)TEXT_PR).ReadOnly = false;
				switch (MSG_PR.Col)
				{
				case 0:
				case 1:
					((TextBoxBase)TEXT_PR).MaxLength = 5;
					TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_PR).MaxLength = 50;
					TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
					break;
				case 10:
					((TextBoxBase)TEXT_PR).MaxLength = 3;
					TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
					break;
				case 11:
					((TextBoxBase)TEXT_PR).MaxLength = 15;
					TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
					break;
				case 18:
				case 22:
					((TextBoxBase)TEXT_PR).MaxLength = 1;
					TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_PR).MaxLength = 8;
					TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0");
					break;
				case 6:
				case 7:
				case 15:
				case 19:
				case 20:
				case 21:
				case 23:
				case 24:
				case 25:
				case 26:
				case 28:
				case 29:
				case 30:
				case 31:
					((TextBoxBase)TEXT_PR).MaxLength = 10;
					TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
					break;
				case 4:
				case 5:
				case 8:
				case 9:
				case 12:
				case 13:
				case 14:
				case 16:
				case 17:
				case 27:
					((TextBoxBase)TEXT_PR).MaxLength = 10;
					TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
					break;
				}
				mSG_PR = null;
				((TextBoxBase)TEXT_PR).SelectAll();
			}
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
			case 10:
			case 11:
			case 18:
			case 22:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
				break;
			case 3:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0");
				CommPassTotal_Pr(mSG_PR.Row);
				break;
			case 6:
			case 7:
			case 15:
			case 19:
			case 20:
			case 21:
			case 23:
			case 24:
			case 25:
			case 26:
			case 28:
			case 29:
			case 30:
			case 31:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
				CommPassTotal_Pr(mSG_PR.Row);
				break;
			case 4:
			case 5:
			case 8:
			case 9:
			case 12:
			case 13:
			case 14:
			case 16:
			case 17:
			case 27:
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
				CommPassTotal_Pr(mSG_PR.Row);
				break;
			}
			mSG_PR = null;
		}
	}

	private void CommPassTotal_Pr(int CRow)
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 4]) != Conversion.Val(mSG_PR[mSG_PR.Row, 34]))
		{
			mSG_PR[mSG_PR.Row, 34] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 4]), "0.000");
			mSG_PR[mSG_PR.Row, 5] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 4]) - Conversion.Val(mSG_PR[mSG_PR.Row, 14])), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 14]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 4]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 5] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 4]) - Conversion.Val(mSG_PR[mSG_PR.Row, 14])), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 5]) != Conversion.Val(mSG_PR[mSG_PR.Row, 35]))
		{
			mSG_PR[mSG_PR.Row, 35] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 5]), "0.000");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 6]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 5]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 8] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 5]) + Conversion.Val(mSG_PR[mSG_PR.Row, 9])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 6]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]) - Conversion.Val(mSG_PR[mSG_PR.Row, 7])) / 100.0), "0.000");
			}
			else
			{
				mSG_PR[mSG_PR.Row, 8] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 5]), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 6]) + Conversion.Val(mSG_PR[mSG_PR.Row, 7]) != Conversion.Val(mSG_PR[mSG_PR.Row, 36]))
		{
			mSG_PR[mSG_PR.Row, 36] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 6]) + Conversion.Val(mSG_PR[mSG_PR.Row, 7])), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 6]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 5]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 8] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 5]) + Conversion.Val(mSG_PR[mSG_PR.Row, 9])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 6]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]) - Conversion.Val(mSG_PR[mSG_PR.Row, 7])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != Conversion.Val(mSG_PR[mSG_PR.Row, 37]))
		{
			mSG_PR[mSG_PR.Row, 37] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 15]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 6]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 5]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 8] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 5]) + Conversion.Val(mSG_PR[mSG_PR.Row, 9])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 6]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]) - Conversion.Val(mSG_PR[mSG_PR.Row, 7])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 6]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 8] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 5]) + Conversion.Val(mSG_PR[mSG_PR.Row, 9])), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 26]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 25]) != 0.0))
		{
			string text = mSG_PR[mSG_PR.Row, 33];
			if (Operators.CompareString(text, "1", false) != 0)
			{
				if (Operators.CompareString(text, "K", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 25]) * 1000.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 26]), 3), "0.000");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 25]) / Conversion.Val(mSG_PR[mSG_PR.Row, 26]), 3), "0.000");
				}
			}
			else
			{
				mSG_PR[mSG_PR.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 25]) * 10.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 26]), 3), "0.000");
			}
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 8]) + Conversion.Val(mSG_PR[mSG_PR.Row, 3]) != 0.0))
		{
			switch (mSG_PR[mSG_PR.Row, 33])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 3]) * Conversion.Val(mSG_PR[mSG_PR.Row, 19]), 0), "0.00");
				break;
			case "1":
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 8]) * (Conversion.Val(mSG_PR[mSG_PR.Row, 19]) / 10.0), 0), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 8]) * (Conversion.Val(mSG_PR[mSG_PR.Row, 19]) / 1000.0), 0), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 8]) * Conversion.Val(mSG_PR[mSG_PR.Row, 19]), 0), "0.00");
				break;
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 23]) != 0.0)
		{
			switch (mSG_PR[mSG_PR.Row, 22])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 3]) * Conversion.Val(mSG_PR[mSG_PR.Row, 23]), 0), "0.00");
				break;
			case "N":
				if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 5]) * Conversion.Val(mSG_PR[mSG_PR.Row, 23]), 0), "0.00");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 5]) + Conversion.Val(mSG_PR[mSG_PR.Row, 9])) * Conversion.Val(mSG_PR[mSG_PR.Row, 23]), 0), "0.00");
				}
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 5]) + Conversion.Val(mSG_PR[mSG_PR.Row, 9])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 23]) / 1000.0), 0), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 4]) * Conversion.Val(mSG_PR[mSG_PR.Row, 23]), 0), "0.00");
				break;
			}
		}
		mSG_PR[mSG_PR.Row, 30] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) + Conversion.Val(mSG_PR[mSG_PR.Row, 25]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20])), "0.00");
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 31]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 30]), "0.00");
		}
		if (mSG_PR.Col == 31)
		{
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 31]) != 0.0)
			{
				mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 31]) + 100.0) * 100.0, 0), "0.00");
				mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 29]) - Conversion.Val(mSG_PR[mSG_PR.Row, 20]) - Conversion.Val(mSG_PR[mSG_PR.Row, 25]), 0), "0.00");
				if (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) != 0.0)
				{
					if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 22], "P", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 3]) != 0.0))
					{
						mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / Conversion.Val(mSG_PR[mSG_PR.Row, 3])), "0.00");
					}
					else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 22], "N", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 5]) != 0.0))
					{
						if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
						{
							mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / Conversion.Val(mSG_PR[mSG_PR.Row, 5])), "0.00");
						}
						else
						{
							mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 5]) + Conversion.Val(mSG_PR[mSG_PR.Row, 9]))), "0.00");
						}
					}
					else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 22], "K", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 4]) != 0.0))
					{
						mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / Conversion.Val(mSG_PR[mSG_PR.Row, 4]) * 1000.0), "0.00");
					}
					else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 22], "G", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 4]) != 0.0))
					{
						mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / Conversion.Val(mSG_PR[mSG_PR.Row, 4])), "0.00");
					}
				}
			}
			else
			{
				mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 30]), "0.00");
			}
		}
		MSG_PR_TOT_FILL();
		BILL_TOTAL();
		mSG_PR = null;
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
			mSG_PR_TOT[0, 11] = "Total :";
			int num2 = MSG_PR.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num2)
			{
				mSG_PR_TOT[0, 3] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 3]) + Conversion.Val(MSG_PR[DC_Main.M, 3]))), "0");
				mSG_PR_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 12]) + Conversion.Val(MSG_PR[DC_Main.M, 12]))), "0.000");
				mSG_PR_TOT[0, 4] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 4]) + Conversion.Val(MSG_PR[DC_Main.M, 4]))), "0.000");
				mSG_PR_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 14]) + Conversion.Val(MSG_PR[DC_Main.M, 14]))), "0.000");
				mSG_PR_TOT[0, 5] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 5]) + Conversion.Val(MSG_PR[DC_Main.M, 5]))), "0.000");
				mSG_PR_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 9]) + Conversion.Val(MSG_PR[DC_Main.M, 9]))), "0.000");
				mSG_PR_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 8]) + Conversion.Val(MSG_PR[DC_Main.M, 8]))), "0.000");
				mSG_PR_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 20]) + Conversion.Val(MSG_PR[DC_Main.M, 20]))), "0.00");
				mSG_PR_TOT[0, 24] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 24]) + Conversion.Val(MSG_PR[DC_Main.M, 24]))), "0.00");
				mSG_PR_TOT[0, 25] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 25]) + Conversion.Val(MSG_PR[DC_Main.M, 25]))), "0.00");
				if (Conversion.Val(MSG_PR[DC_Main.M, 26]) != 0.0)
				{
					PrOthAmtLess += Conversion.Val(MSG_PR[DC_Main.M, 25]);
				}
				mSG_PR_TOT[0, 27] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 27]) + Conversion.Val(MSG_PR[DC_Main.M, 27]))), "0.000");
				mSG_PR_TOT[0, 28] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 28]) + Conversion.Val(MSG_PR[DC_Main.M, 28]))), "0.000");
				mSG_PR_TOT[0, 30] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 30]) + Conversion.Val(MSG_PR[DC_Main.M, 30]))), "0.00");
				mSG_PR_TOT[0, 29] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 29]) + Conversion.Val(MSG_PR[DC_Main.M, 29]))), "0.00");
				if (Conversion.Val(MSG_PR[DC_Main.M, 20]) == 0.0)
				{
					TotCrFine += Conversion.Val(MSG_PR[DC_Main.M, 8]);
				}
				DC_Main.M++;
			}
			mSG_PR_TOT = null;
		}
	}

	private void MSG_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		mSG_IDTL.Clear();
		mSG_IDTL.Cols = 24;
		mSG_IDTL.FixedRows = 1;
		mSG_IDTL.Rows = 2;
		mSG_IDTL.Row = 0;
		mSG_IDTL[0] = 0;
		mSG_IDTL[1] = 0;
		mSG_IDTL.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_IDTL[0] = (int)Math.Round(500.0 * ColCon);
			mSG_IDTL[0] = 3;
			mSG_IDTL[0, 0] = "Sr";
			mSG_IDTL[1] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[1] = 0;
			mSG_IDTL[0, 1] = "ItCode";
			mSG_IDTL[2] = (int)Math.Round(2200.0 * ColCon);
			mSG_IDTL[2] = 0;
			mSG_IDTL[0, 2] = "ItName";
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				mSG_IDTL[3] = (int)Math.Round(900.0 * ColCon);
				mSG_IDTL[3] = 0;
				mSG_IDTL[0, 3] = "DmCode";
				mSG_IDTL[4] = (int)Math.Round(2000.0 * ColCon);
				mSG_IDTL[4] = 0;
				mSG_IDTL[0, 4] = "DmName";
				mSG_IDTL[5] = (int)Math.Round(900.0 * ColCon);
				mSG_IDTL[5] = 3;
				mSG_IDTL[0, 5] = "DmSize";
				mSG_IDTL[6] = (int)Math.Round(1500.0 * ColCon);
				mSG_IDTL[6] = 0;
				mSG_IDTL[0, 6] = "DmSfNo";
			}
			else
			{
				mSG_IDTL[3] = 0;
				mSG_IDTL[0, 3] = "DmCode";
				mSG_IDTL[4] = 0;
				mSG_IDTL[0, 4] = "DmName";
				mSG_IDTL[5] = 0;
				mSG_IDTL[0, 5] = "DmSize";
				mSG_IDTL[6] = (int)Math.Round(1500.0 * ColCon);
				mSG_IDTL[6] = 0;
				mSG_IDTL[0, 6] = "DmSfNo";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
			{
				mSG_IDTL[7] = (int)Math.Round(750.0 * ColCon);
				mSG_IDTL[7] = 7;
				mSG_IDTL[0, 7] = "MotiPs";
				mSG_IDTL[8] = (int)Math.Round(750.0 * ColCon);
				mSG_IDTL[8] = 7;
				mSG_IDTL[0, 8] = "MotiWt";
			}
			else
			{
				mSG_IDTL[7] = 0;
				mSG_IDTL[0, 7] = "MotiPs";
				mSG_IDTL[8] = 0;
				mSG_IDTL[0, 8] = "MotiWt";
			}
			mSG_IDTL[9] = (int)Math.Round(750.0 * ColCon);
			mSG_IDTL[9] = 7;
			mSG_IDTL[0, 9] = "Pcs";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
			{
				mSG_IDTL[10] = (int)Math.Round(900.0 * ColCon);
				mSG_IDTL[10] = 7;
				mSG_IDTL[0, 10] = "PcsWt";
			}
			else
			{
				mSG_IDTL[10] = (int)Math.Round(800.0 * ColCon);
				mSG_IDTL[10] = 7;
				mSG_IDTL[0, 10] = "PcsWt";
			}
			mSG_IDTL[12] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[12] = 7;
			mSG_IDTL[0, 12] = "Weight";
			mSG_IDTL[11] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[11] = 7;
			mSG_IDTL[0, 11] = "KrWt";
			mSG_IDTL[13] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[13] = 7;
			mSG_IDTL[0, 13] = "Con%";
			mSG_IDTL[14] = (int)Math.Round(700.0 * ColCon);
			mSG_IDTL[14] = 3;
			mSG_IDTL[0, 14] = "P/W";
			mSG_IDTL[15] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[15] = 7;
			mSG_IDTL[0, 15] = "Rate";
			mSG_IDTL[16] = (int)Math.Round(1150.0 * ColCon);
			mSG_IDTL[16] = 7;
			mSG_IDTL[0, 16] = "ItAmt";
			mSG_IDTL[17] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[17] = 7;
			mSG_IDTL[0, 17] = "LbrRate";
			mSG_IDTL[18] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[18] = 7;
			mSG_IDTL[0, 18] = "LbrAmt";
			mSG_IDTL[19] = (int)Math.Round(1150.0 * ColCon);
			mSG_IDTL[19] = 7;
			mSG_IDTL[0, 19] = "NetAmt";
			mSG_IDTL[20] = 0;
			mSG_IDTL[0, 20] = "ConWt";
			mSG_IDTL[21] = 0;
			mSG_IDTL[0, 21] = "KrConWt";
			mSG_IDTL[22] = 0;
			mSG_IDTL[0, 22] = "ItType";
			mSG_IDTL[23] = 0;
			mSG_IDTL[0, 23] = "RowSrNo";
			mSG_IDTL.Row = 1;
			mSG_IDTL.Col = 0;
			((Control)TEXT_IDTL).Visible = false;
			DataView dataView = new DataView(DC_Main.RsClIdtl);
			if (dataView.Count > 0)
			{
				int num = mSG_IDTL.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = "BOOK_NAME = 'TAG_IDTL' AND COL_NAME = '" + mSG_IDTL[0, DC_Main.M] + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							mSG_IDTL[DC_Main.M] = 0;
						}
						mSG_IDTL[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
					DC_Main.M++;
				}
			}
			mSG_IDTL[0] = (int)Math.Round(325.0 * ColCon);
			mSG_IDTL[1] = (int)Math.Round(300.0 * ColCon);
			mSG_IDTL.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd_Idtl();
			mSG_IDTL = null;
		}
	}

	private void CommPassAdd_Idtl()
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		mSG_IDTL[mSG_IDTL.Row, 0] = Conversions.ToString(mSG_IDTL.Row);
		mSG_IDTL[mSG_IDTL.Row, 23] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 21]));
		mSG_IDTL = null;
	}

	private void TEXT_IDTL_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_IDTL_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Invalid comparison between Unknown and I4
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Invalid comparison between Unknown and I4
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Invalid comparison between Unknown and I4
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Invalid comparison between Unknown and I4
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Invalid comparison between Unknown and I4
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = DtIdtl.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 23])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 0])))
						{
							DtIdtl.Rows.Remove(DtIdtl.Rows[i]);
							DtIdtl.AcceptChanges();
							break;
						}
					}
					int num2 = mSG_IDTL.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num2)
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
				if (mSG_IDTL.Col < 19)
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
						if (Operators.CompareString(TEXT_IDTL.Text, "", false) == 0)
						{
							((Control)TEXT_IDTL).Visible = false;
							MSG.Col += 1;
							MSG_EnterCell(MSG, new EventArgs());
							((Control)TEXT_ENTRY).Visible = true;
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_IDTL.Text + "'";
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
									TEXT_IDTL.Text = DC_Main.ColValue[1];
									mSG_IDTL[mSG_IDTL.Row, 1] = DC_Main.ColValue[1];
									mSG_IDTL[mSG_IDTL.Row, 2] = DC_Main.ColValue[0];
									mSG_IDTL[mSG_IDTL.Row, 22] = DC_Main.ColValue[4];
								}
								((Control)TEXT_IDTL).Focus();
							}
							return;
						}
						mSG_IDTL[mSG_IDTL.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_IDTL[mSG_IDTL.Row, 22] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 15]) == 0.0)
							{
								mSG_IDTL[mSG_IDTL.Row, 15] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
							if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 13]) == 0.0)
							{
								mSG_IDTL[mSG_IDTL.Row, 13] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CON_PRC"], (object)"")), "0.000");
							}
						}
						break;
					case 3:
						if (Operators.CompareString(TEXT_IDTL.Text, "", false) == 0 || mSG_IDTL[3] == 0)
						{
							break;
						}
						DC_Main.RsQry = "Select * From DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND DM_CODE = '" + TEXT_IDTL.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.DM_NAME As ItemNameL,A.DM_CODE as ItCodeL,B.GR_NAME As GroupL FROM DM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.DM_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[4];
							DC_Main.ColWidth[0] = 300.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 250.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_IDTL.Text = DC_Main.ColValue[1];
									mSG_IDTL[mSG_IDTL.Row, 3] = DC_Main.ColValue[1];
									mSG_IDTL[mSG_IDTL.Row, 4] = DC_Main.ColValue[0];
								}
								((Control)TEXT_IDTL).Focus();
							}
							return;
						}
						mSG_IDTL[mSG_IDTL.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DM_CODE"], (object)""));
						mSG_IDTL[mSG_IDTL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DM_NAME"], (object)""));
						if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 15]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 15] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SL_RATE"], (object)"")), "0.00");
						}
						break;
					case 19:
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							mSG_IDTL[mSG_IDTL.Row, 19] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
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
							mSG_IDTL.Col = 1;
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
			switch (MSG_IDTL.Col)
			{
			case 0:
			case 1:
				((TextBoxBase)TEXT_IDTL).MaxLength = 5;
				TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
				break;
			case 3:
				((TextBoxBase)TEXT_IDTL).MaxLength = 8;
				TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
				break;
			case 2:
			case 4:
				((TextBoxBase)TEXT_IDTL).MaxLength = 50;
				TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
				break;
			case 5:
			case 6:
				((TextBoxBase)TEXT_IDTL).MaxLength = 15;
				TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
				break;
			case 14:
				((TextBoxBase)TEXT_IDTL).MaxLength = 1;
				TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
				break;
			case 7:
			case 9:
				((TextBoxBase)TEXT_IDTL).MaxLength = 6;
				TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0");
				break;
			case 13:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
				((TextBoxBase)TEXT_IDTL).MaxLength = 10;
				TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.00");
				break;
			case 8:
			case 11:
			case 12:
			case 20:
				((TextBoxBase)TEXT_IDTL).MaxLength = 10;
				TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.000");
				break;
			case 10:
				((TextBoxBase)TEXT_IDTL).MaxLength = 10;
				if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
				{
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.000000");
				}
				else
				{
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.0000");
				}
				break;
			}
			mSG_IDTL = null;
			((TextBoxBase)TEXT_IDTL).SelectAll();
		}
	}

	private void MSG_IDTL_LeaveCell(object sender, EventArgs e)
	{
		if (MsgClearIdtl || MSG_IDTL.Row == 0 || MSG_IDTL[MSG_IDTL.Col] == 0 || !((Control)TEXT_IDTL).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		switch (MSG_IDTL.Col)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 14:
			mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = TEXT_IDTL.Text;
			break;
		case 7:
		case 9:
			mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0");
			CommPassTotal_Idtl(mSG_IDTL.Row);
			break;
		case 13:
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
			mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
			CommPassTotal_Idtl(mSG_IDTL.Row);
			break;
		case 8:
		case 11:
		case 12:
		case 20:
			mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.000");
			CommPassTotal_Idtl(mSG_IDTL.Row);
			break;
		case 10:
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
			{
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.000000");
			}
			else
			{
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.0000");
			}
			CommPassTotal_Idtl(mSG_IDTL.Row);
			break;
		}
		mSG_IDTL = null;
	}

	private void CommPassTotal_Idtl(int CRow)
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		if ((Conversion.Val(mSG_IDTL[CRow, 7]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 8]) != 0.0))
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
			{
				mSG_IDTL[CRow, 10] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 8]) / Conversion.Val(mSG_IDTL[CRow, 7])), "0.000000");
			}
			else
			{
				mSG_IDTL[CRow, 10] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 8]) / Conversion.Val(mSG_IDTL[CRow, 7])), "0.0000");
			}
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 9]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 10]) != 0.0))
		{
			mSG_IDTL[CRow, 11] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 9]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 11]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 12]) == 0.0))
		{
			mSG_IDTL[CRow, 12] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 11]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 11]) == 0.0))
		{
			mSG_IDTL[CRow, 11] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 12]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 13]) != 0.0))
		{
			mSG_IDTL[CRow, 20] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 12]) * Conversion.Val(mSG_IDTL[CRow, 13])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 20] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 11]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 13]) != 0.0))
		{
			mSG_IDTL[CRow, 21] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 11]) * Conversion.Val(mSG_IDTL[CRow, 13])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 21] = Conversions.ToString(0);
		}
		if (Operators.CompareString(mSG_IDTL[CRow, 14], "", false) == 0)
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 12]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 9]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 15]) != 0.0))
			{
				mSG_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 15]) * Conversion.Val(mSG_IDTL[CRow, 9])), "0.00");
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 15]) != 0.0))
			{
				mSG_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 15]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 14], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 15])))) != 0)
		{
			mSG_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 15]) * Conversion.Val(mSG_IDTL[CRow, 9])), "0.00");
		}
		else if (Conversion.Val(mSG_IDTL[CRow, 15]) != 0.0)
		{
			mSG_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 15]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0)
		{
			mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 17]) * Conversion.Val(mSG_IDTL[CRow, 9])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 16]) + Conversion.Val(mSG_IDTL[CRow, 18]) != 0.0)
		{
			mSG_IDTL[CRow, 19] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 16]) + Conversion.Val(mSG_IDTL[CRow, 18])), "0.00");
		}
		checked
		{
			int num = mSG_IDTL.Rows - 1;
			DC_Main.M = 1;
			double num2 = default(double);
			double num3 = default(double);
			double num4 = default(double);
			while (DC_Main.M <= num)
			{
				num2 += Conversion.Val(mSG_IDTL[DC_Main.M, 20]);
				num3 += Conversion.Val(mSG_IDTL[DC_Main.M, 21]);
				num4 += Conversion.Val(mSG_IDTL[DC_Main.M, 19]);
				DC_Main.M++;
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 8] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 9] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 7]) - Conversion.Val(MSG[MSG.Row, 8])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 30] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 31] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 7]) - Conversion.Val(MSG[MSG.Row, 30])), "0.000");
			}
			if (num4 != 0.0)
			{
				MSG[MSG.Row, 19] = Strings.Format((object)num4, "0.00");
			}
			if (Operators.CompareString(mSG_IDTL[CRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num5 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num5; i++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23])) == Conversion.Val(mSG_IDTL[CRow, 23])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[CRow, 0])))
					{
						flag = true;
						DtIdtl.Rows[i][0] = mSG_IDTL[CRow, 0];
						DtIdtl.Rows[i][1] = mSG_IDTL[CRow, 1];
						DtIdtl.Rows[i][2] = mSG_IDTL[CRow, 2];
						DtIdtl.Rows[i][3] = mSG_IDTL[CRow, 3];
						DtIdtl.Rows[i][4] = mSG_IDTL[CRow, 4];
						DtIdtl.Rows[i][5] = mSG_IDTL[CRow, 5];
						DtIdtl.Rows[i][6] = mSG_IDTL[CRow, 6];
						DtIdtl.Rows[i][7] = mSG_IDTL[CRow, 7];
						DtIdtl.Rows[i][8] = mSG_IDTL[CRow, 8];
						DtIdtl.Rows[i][9] = mSG_IDTL[CRow, 9];
						DtIdtl.Rows[i][10] = mSG_IDTL[CRow, 10];
						DtIdtl.Rows[i][12] = mSG_IDTL[CRow, 12];
						DtIdtl.Rows[i][11] = mSG_IDTL[CRow, 11];
						DtIdtl.Rows[i][13] = mSG_IDTL[CRow, 13];
						DtIdtl.Rows[i][14] = mSG_IDTL[CRow, 14];
						DtIdtl.Rows[i][15] = mSG_IDTL[CRow, 15];
						DtIdtl.Rows[i][16] = mSG_IDTL[CRow, 16];
						DtIdtl.Rows[i][17] = mSG_IDTL[CRow, 17];
						DtIdtl.Rows[i][18] = mSG_IDTL[CRow, 18];
						DtIdtl.Rows[i][19] = mSG_IDTL[CRow, 19];
						DtIdtl.Rows[i][20] = mSG_IDTL[CRow, 20];
						DtIdtl.Rows[i][21] = mSG_IDTL[CRow, 21];
						DtIdtl.Rows[i][22] = mSG_IDTL[CRow, 22];
						DtIdtl.Rows[i][23] = mSG_IDTL[CRow, 23];
						break;
					}
				}
				if (!flag)
				{
					dr = DtIdtl.NewRow();
					dr[0] = mSG_IDTL[CRow, 0];
					dr[1] = mSG_IDTL[CRow, 1];
					dr[2] = mSG_IDTL[CRow, 2];
					dr[3] = mSG_IDTL[CRow, 3];
					dr[4] = mSG_IDTL[CRow, 4];
					dr[5] = mSG_IDTL[CRow, 5];
					dr[6] = mSG_IDTL[CRow, 6];
					dr[7] = mSG_IDTL[CRow, 7];
					dr[8] = mSG_IDTL[CRow, 8];
					dr[9] = mSG_IDTL[CRow, 9];
					dr[10] = mSG_IDTL[CRow, 10];
					dr[12] = mSG_IDTL[CRow, 12];
					dr[11] = mSG_IDTL[CRow, 11];
					dr[13] = mSG_IDTL[CRow, 13];
					dr[14] = mSG_IDTL[CRow, 14];
					dr[15] = mSG_IDTL[CRow, 15];
					dr[16] = mSG_IDTL[CRow, 16];
					dr[17] = mSG_IDTL[CRow, 17];
					dr[18] = mSG_IDTL[CRow, 18];
					dr[19] = mSG_IDTL[CRow, 19];
					dr[20] = mSG_IDTL[CRow, 20];
					dr[21] = mSG_IDTL[CRow, 21];
					dr[22] = mSG_IDTL[CRow, 22];
					dr[23] = mSG_IDTL[CRow, 23];
					DtIdtl.Rows.Add(dr);
				}
			}
			mSG_IDTL = null;
		}
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 60;
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
			mSG[2] = (int)Math.Round(900.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "ItCode";
			mSG[1] = (int)Math.Round(1200.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "TagNo";
			mSG[3] = (int)Math.Round(2100.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "ItName";
			mSG[4] = (int)Math.Round(1300.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "Design";
			mSG[5] = (int)Math.Round(900.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "HuId";
			mSG[6] = (int)Math.Round(600.0 * ColCon);
			mSG[6] = 7;
			mSG[0, 6] = "Pcs";
			mSG[7] = (int)Math.Round(1000.0 * ColCon);
			mSG[7] = 7;
			mSG[0, 7] = "GrWt";
			mSG[8] = (int)Math.Round(900.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "OthWt";
			mSG[9] = (int)Math.Round(1000.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "NetWt";
			mSG[12] = (int)Math.Round(850.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "Touch";
			mSG[13] = (int)Math.Round(850.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "West%";
			mSG[10] = (int)Math.Round(750.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "Ght%";
			mSG[11] = (int)Math.Round(850.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "GhtWt";
			mSG[14] = (int)Math.Round(1000.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "Fine";
			mSG[15] = (int)Math.Round(800.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "Lbr%";
			mSG[16] = (int)Math.Round(800.0 * ColCon);
			mSG[16] = 3;
			mSG[0, 16] = "LType";
			mSG[17] = (int)Math.Round(900.0 * ColCon);
			mSG[17] = 7;
			mSG[0, 17] = "LbrRate";
			mSG[18] = (int)Math.Round(1000.0 * ColCon);
			mSG[18] = 7;
			mSG[0, 18] = "LbrAmt";
			mSG[19] = (int)Math.Round(1000.0 * ColCon);
			mSG[19] = 7;
			mSG[0, 19] = "OthAmt";
			mSG[20] = (int)Math.Round(1300.0 * ColCon);
			mSG[20] = 7;
			mSG[0, 20] = "NetAmt";
			mSG[29] = (int)Math.Round(0.0 * ColCon);
			mSG[29] = 7;
			mSG[0, 29] = "Mrp";
			mSG[35] = (int)Math.Round(0.0 * ColCon);
			mSG[35] = 3;
			mSG[0, 35] = "TagCost";
			mSG[24] = (int)Math.Round(0.0 * ColCon);
			mSG[24] = 7;
			mSG[0, 24] = "KrCode";
			mSG[23] = (int)Math.Round(0.0 * ColCon);
			mSG[23] = 0;
			mSG[0, 23] = "Counter";
			mSG[30] = (int)Math.Round(0.0 * ColCon);
			mSG[30] = 7;
			mSG[0, 30] = "KrOthWt";
			mSG[31] = (int)Math.Round(0.0 * ColCon);
			mSG[31] = 7;
			mSG[0, 31] = "KrNwt";
			mSG[32] = (int)Math.Round(0.0 * ColCon);
			mSG[32] = 7;
			mSG[0, 32] = "KrTouch";
			mSG[33] = (int)Math.Round(0.0 * ColCon);
			mSG[33] = 7;
			mSG[0, 33] = "KrWst%";
			mSG[34] = (int)Math.Round(0.0 * ColCon);
			mSG[34] = 7;
			mSG[0, 34] = "KrFine";
			mSG[21] = 0;
			mSG[26] = 0;
			mSG[27] = 0;
			mSG[28] = 0;
			mSG[25] = 0;
			mSG[22] = 0;
			mSG[36] = 0;
			mSG[37] = 0;
			mSG[38] = 0;
			mSG[39] = 0;
			mSG[40] = 0;
			mSG[41] = 0;
			mSG[42] = 0;
			mSG[43] = 0;
			mSG[44] = 0;
			mSG[45] = 0;
			mSG[46] = 0;
			mSG[47] = 0;
			mSG[48] = 0;
			mSG[49] = 0;
			mSG[50] = 0;
			mSG[51] = 0;
			mSG[52] = 0;
			mSG[53] = 0;
			mSG[54] = 0;
			mSG[56] = 0;
			mSG[57] = 0;
			mSG[55] = 0;
			mSG[58] = 0;
			mSG[59] = 0;
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
					dataView.RowFilter = " BOOK_NAME = 'LBR_ISU' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
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
			MsgLastCol = 24;
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
		checked
		{
			if (!UpDown)
			{
				TotDrFine = 0.0;
				SlOthAmtLess = 0.0;
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				int num = MSG.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					mSG_TOT[0, DC_Main.M] = "";
					DC_Main.M++;
				}
				mSG_TOT[0, 4] = "Total :";
				int num2 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_TOT[0, 6] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 6]) + Conversion.Val(MSG[DC_Main.M, 6]))), "0");
					mSG_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 7]) + Conversion.Val(MSG[DC_Main.M, 7]))), "0.000");
					mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0.000");
					mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) + Conversion.Val(MSG[DC_Main.M, 9]))), "0.000");
					mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0.000");
					mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) + Conversion.Val(MSG[DC_Main.M, 14]))), "0.000");
					mSG_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 20]) + Conversion.Val(MSG[DC_Main.M, 20]))), "0.00");
					mSG_TOT[0, 18] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 18]) + Conversion.Val(MSG[DC_Main.M, 18]))), "0.00");
					mSG_TOT[0, 19] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 19]) + Conversion.Val(MSG[DC_Main.M, 19]))), "0.00");
					mSG_TOT[0, 35] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 35]) + Conversion.Val(MSG[DC_Main.M, 35]))), "0.00");
					mSG_TOT[0, 29] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 29]) + Conversion.Val(MSG[DC_Main.M, 29]))), "0.000");
					mSG_TOT[0, 30] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 30]) + Conversion.Val(MSG[DC_Main.M, 30]))), "0.000");
					mSG_TOT[0, 31] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 31]) + Conversion.Val(MSG[DC_Main.M, 31]))), "0.000");
					mSG_TOT[0, 34] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 34]) + Conversion.Val(MSG[DC_Main.M, 34]))), "0.000");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 7]) + Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 31]) + Conversion.Val(MSG_TOT[0, 19]) + Conversion.Val(MSG_TOT[0, 18]);
			}
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 6] = Conversions.ToString(1);
		mSG[mSG.Row, 16] = DC_Main.MsLbrType;
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			mSG[mSG.Row, 21] = Conversions.ToString(MSG.Row);
		}
		else
		{
			mSG[mSG.Row, 21] = Conversions.ToString(Conversion.Val(mSG[checked(mSG.Rows - 2), 21]) + 1.0);
		}
		mSG[mSG.Row, 22] = "A";
		mSG[mSG.Row, 37] = "N";
		mSG[mSG.Row, 54] = "N";
		MSG_IDTL_CLEAR();
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
				if (MsgOldRow != MSG.Row)
				{
					MsgOldRow = 0;
				}
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
				if ((mSG.Col != 23) & (mSG.Col != 4))
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
			case 24:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 2:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 23:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 5:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
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
			case 4:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 16:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 6:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 10:
			case 12:
			case 13:
			case 15:
			case 32:
			case 33:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 17:
			case 18:
			case 19:
			case 20:
			case 29:
			case 35:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 7:
			case 8:
			case 9:
			case 14:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				break;
			case 11:
			case 30:
			case 31:
			case 34:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
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
			case 5:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 4:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 0:
			case 1:
			case 23:
			case 24:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 6:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				break;
			case 16:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				CommPassTotal();
				break;
			case 15:
				CommPassTotal();
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				break;
			case 10:
			case 12:
			case 13:
			case 32:
			case 33:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 17:
			case 18:
			case 19:
			case 20:
			case 29:
			case 35:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 7:
			case 8:
			case 9:
			case 11:
			case 14:
			case 30:
			case 31:
			case 34:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
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
				case 3787:
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
							goto IL_0042;
						case 5:
							goto IL_0061;
						case 6:
						case 7:
							goto IL_007a;
						case 8:
							goto IL_00bf;
						case 9:
							goto IL_00f2;
						case 10:
							goto IL_0126;
						case 11:
						case 12:
							goto IL_0140;
						case 13:
							goto IL_01a0;
						case 15:
							goto IL_021e;
						case 14:
						case 16:
						case 17:
							goto IL_0253;
						case 18:
							goto IL_028e;
						case 19:
						case 20:
							goto IL_02d8;
						case 21:
							goto IL_0323;
						case 23:
							goto IL_036e;
						case 22:
						case 24:
						case 25:
							goto IL_03a3;
						case 26:
							goto IL_0403;
						case 28:
							goto IL_046d;
						case 27:
						case 29:
						case 30:
							goto IL_04a2;
						case 31:
							goto IL_04b8;
						case 32:
							goto IL_04ec;
						case 33:
							goto IL_0513;
						case 37:
							goto IL_0577;
						case 38:
							goto IL_05a4;
						case 39:
							goto IL_05ea;
						case 34:
						case 35:
						case 36:
						case 40:
						case 41:
						case 42:
						case 43:
							goto IL_064b;
						case 44:
							goto IL_067e;
						case 45:
							goto IL_06b1;
						case 46:
						case 47:
							goto IL_06cb;
						case 48:
							goto IL_0702;
						case 49:
							goto IL_0737;
						case 51:
							goto IL_0780;
						case 53:
							goto IL_07d3;
						case 54:
							goto IL_07ef;
						case 56:
							goto IL_0841;
						case 59:
							goto IL_08aa;
						case 61:
							goto IL_0919;
						case 50:
						case 52:
						case 55:
						case 57:
						case 58:
						case 60:
						case 62:
						case 63:
							goto IL_0969;
						case 64:
						case 65:
							goto IL_0995;
						case 66:
							goto IL_09ee;
						case 67:
							goto IL_0a22;
						case 68:
							goto IL_0a68;
						case 70:
							goto IL_0ab5;
						case 71:
							goto IL_0aff;
						case 72:
							goto IL_0b1b;
						case 74:
							goto IL_0b67;
						case 77:
							goto IL_0bca;
						case 78:
							goto IL_0c10;
						case 80:
							goto IL_0c67;
						case 81:
							goto IL_0cad;
						case 69:
						case 73:
						case 75:
						case 76:
						case 79:
						case 82:
						case 83:
						case 84:
							goto IL_0cf7;
						case 85:
							goto IL_0d40;
						case 86:
							goto IL_0d42;
						case 87:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 88:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0cf7:
					num2 = 84;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])), "0.00");
					goto IL_0d40;
					IL_0d40:
					val = null;
					goto IL_0d42;
					IL_0cad:
					num2 = 81;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 18]) / Conversion.Val(val[val.Row, 7])), "0.00");
					goto IL_0cf7;
					IL_0d42:
					num2 = 86;
					MSG_TOT_FILL();
					break;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Operators.CompareString(val[val.Row, 16], val[val.Row, 49], false) != 0)
					{
						goto IL_0042;
					}
					goto IL_007a;
					IL_0042:
					num2 = 4;
					val[val.Row, 49] = val[val.Row, 16];
					goto IL_0061;
					IL_0061:
					num2 = 5;
					val[val.Row, 38] = Conversions.ToString(0);
					goto IL_007a;
					IL_007a:
					num2 = 7;
					val[val.Row, 9] = Strings.Format((object)(Conversion.Val(val[val.Row, 7]) - Conversion.Val(val[val.Row, 8])), "0.000");
					goto IL_00bf;
					IL_00bf:
					num2 = 8;
					if (Conversion.Val(val[val.Row, 9]) != Conversion.Val(val[val.Row, 48]))
					{
						goto IL_00f2;
					}
					goto IL_0140;
					IL_00f2:
					num2 = 9;
					val[val.Row, 48] = Strings.Format((object)Conversion.Val(val[val.Row, 9]), "0.000");
					goto IL_0126;
					IL_0126:
					num2 = 10;
					val[val.Row, 38] = Conversions.ToString(0);
					goto IL_0140;
					IL_0140:
					num2 = 12;
					if ((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 13]) != 0.0) & (Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_01a0;
					}
					goto IL_021e;
					IL_01a0:
					num2 = 13;
					val[val.Row, 14] = Strings.Format((object)((Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 11])) * (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 13])) / 100.0), "0.000");
					goto IL_0253;
					IL_021e:
					num2 = 15;
					val[val.Row, 14] = Strings.Format((object)Conversion.Val(val[val.Row, 9]), "0.000");
					goto IL_0253;
					IL_0253:
					num2 = 17;
					if (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 13]) == 0.0)
					{
						goto IL_028e;
					}
					goto IL_02d8;
					IL_028e:
					num2 = 18;
					val[val.Row, 14] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 11])), "0.000");
					goto IL_02d8;
					IL_02d8:
					num2 = 20;
					if ((Conversion.Val(val[val.Row, 30]) != 0.0) & (Conversion.Val(val[val.Row, 7]) != 0.0))
					{
						goto IL_0323;
					}
					goto IL_036e;
					IL_0323:
					num2 = 21;
					val[val.Row, 31] = Strings.Format((object)(Conversion.Val(val[val.Row, 7]) - Conversion.Val(val[val.Row, 30])), "0.000");
					goto IL_03a3;
					IL_036e:
					num2 = 23;
					val[val.Row, 31] = Strings.Format((object)Conversion.Val(val[val.Row, 31]), "0.000");
					goto IL_03a3;
					IL_03a3:
					num2 = 25;
					if ((Conversion.Val(val[val.Row, 32]) + Conversion.Val(val[val.Row, 33]) != 0.0) & (Conversion.Val(val[val.Row, 31]) != 0.0))
					{
						goto IL_0403;
					}
					goto IL_046d;
					IL_0403:
					num2 = 26;
					val[val.Row, 34] = Strings.Format((object)(Conversion.Val(val[val.Row, 31]) * (Conversion.Val(val[val.Row, 32]) + Conversion.Val(val[val.Row, 33])) / 100.0), "0.000");
					goto IL_04a2;
					IL_046d:
					num2 = 28;
					val[val.Row, 34] = Strings.Format((object)Conversion.Val(val[val.Row, 31]), "0.000");
					goto IL_04a2;
					IL_04a2:
					num2 = 30;
					if (val.Col == 15)
					{
						goto IL_04b8;
					}
					goto IL_0577;
					IL_04b8:
					num2 = 31;
					if (Conversion.Val(val[val.Row, 15]) != Conversion.Val(TEXT_ENTRY.Text))
					{
						goto IL_04ec;
					}
					goto IL_064b;
					IL_04ec:
					num2 = 32;
					if (Conversion.Val(nItmRate.Text) != 0.0)
					{
						goto IL_0513;
					}
					goto IL_064b;
					IL_0513:
					num2 = 33;
					val[val.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 36]) * Conversion.Val(TEXT_ENTRY.Text) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_064b;
					IL_0577:
					num2 = 37;
					if (Conversion.Val(val[val.Row, 15]) != 0.0)
					{
						goto IL_05a4;
					}
					goto IL_064b;
					IL_05a4:
					num2 = 38;
					if ((Conversion.Val(val[val.Row, 17]) == 0.0) & (Conversion.Val(nItmRate.Text) != 0.0))
					{
						goto IL_05ea;
					}
					goto IL_064b;
					IL_05ea:
					num2 = 39;
					val[val.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 36]) * Conversion.Val(val[val.Row, 15]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_064b;
					IL_064b:
					num2 = 43;
					if (Conversion.Val(val[val.Row, 6]) != Conversion.Val(val[val.Row, 59]))
					{
						goto IL_067e;
					}
					goto IL_06cb;
					IL_067e:
					num2 = 44;
					val[val.Row, 59] = Strings.Format((object)Conversion.Val(val[val.Row, 6]), "0");
					goto IL_06b1;
					IL_06b1:
					num2 = 45;
					val[val.Row, 38] = Conversions.ToString(0);
					goto IL_06cb;
					IL_06cb:
					num2 = 47;
					if (Conversion.Val(val[val.Row, 17]) != Conversion.Val(val[val.Row, 38]))
					{
						goto IL_0702;
					}
					goto IL_0995;
					IL_0702:
					num2 = 48;
					val[val.Row, 38] = Strings.Format((object)Conversion.Val(val[val.Row, 17]), "0.00");
					goto IL_0737;
					IL_0737:
					num2 = 49;
					switch (val[val.Row, 16])
					{
					case "P":
						break;
					case "N":
						goto IL_07d3;
					case "K":
						goto IL_08aa;
					default:
						goto IL_0919;
					}
					goto IL_0780;
					IL_0919:
					num2 = 61;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 7]) * Conversion.Val(val[val.Row, 17]), 0), "0.00");
					goto IL_0969;
					IL_08aa:
					num2 = 59;
					val[val.Row, 18] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 11])) * (Conversion.Val(val[val.Row, 17]) / 1000.0), 0), "0.00");
					goto IL_0969;
					IL_07d3:
					num2 = 53;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_07ef;
					}
					goto IL_0841;
					IL_07ef:
					num2 = 54;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 9]) * Conversion.Val(val[val.Row, 17]), 0), "0.00");
					goto IL_0969;
					IL_0841:
					num2 = 56;
					val[val.Row, 18] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 11])) * Conversion.Val(val[val.Row, 17]), 0), "0.00");
					goto IL_0969;
					IL_0780:
					num2 = 51;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 6]) * Conversion.Val(val[val.Row, 17]), 0), "0.00");
					goto IL_0969;
					IL_0969:
					num2 = 63;
					val[val.Row, 39] = Conversions.ToString(Conversion.Val(val[val.Row, 18]));
					goto IL_0995;
					IL_0995:
					num2 = 65;
					if ((Conversion.Val(val[val.Row, 18]) != 0.0) & (Conversion.Val(val[val.Row, 18]) != Conversion.Val(val[val.Row, 39])))
					{
						goto IL_09ee;
					}
					goto IL_0cf7;
					IL_09ee:
					num2 = 66;
					val[val.Row, 39] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_0a22;
					IL_0a22:
					num2 = 67;
					if ((Operators.CompareString(val[val.Row, 16], "P", false) == 0) & (Conversion.Val(val[val.Row, 6]) != 0.0))
					{
						goto IL_0a68;
					}
					goto IL_0ab5;
					IL_0a68:
					num2 = 68;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 18]) / Conversion.Val(val[val.Row, 6])), "0.00");
					goto IL_0cf7;
					IL_0ab5:
					num2 = 70;
					if ((Operators.CompareString(val[val.Row, 16], "N", false) == 0) & (Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_0aff;
					}
					goto IL_0bca;
					IL_0aff:
					num2 = 71;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_0b1b;
					}
					goto IL_0b67;
					IL_0b1b:
					num2 = 72;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 18]) / Conversion.Val(val[val.Row, 9])), "0.00");
					goto IL_0cf7;
					IL_0b67:
					num2 = 74;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 18]) / (Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 11]))), "0.00");
					goto IL_0cf7;
					IL_0bca:
					num2 = 77;
					if ((Operators.CompareString(val[val.Row, 16], "K", false) == 0) & (Conversion.Val(val[val.Row, 7]) != 0.0))
					{
						goto IL_0c10;
					}
					goto IL_0c67;
					IL_0c10:
					num2 = 78;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 18]) / Conversion.Val(val[val.Row, 7]) * 1000.0), "0.00");
					goto IL_0cf7;
					IL_0c67:
					num2 = 80;
					if ((Operators.CompareString(val[val.Row, 16], "G", false) == 0) & (Conversion.Val(val[val.Row, 7]) != 0.0))
					{
						goto IL_0cad;
					}
					goto IL_0cf7;
					end_IL_0001_2:
					break;
				}
				num2 = 87;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 3787;
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
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		//IL_1b8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b9b: Invalid comparison between Unknown and I4
		//IL_1daf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db2: Invalid comparison between Unknown and I4
		//IL_1bac: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb2: Invalid comparison between Unknown and I4
		//IL_1dc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc6: Invalid comparison between Unknown and I4
		//IL_06c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ddb: Invalid comparison between Unknown and I4
		//IL_1e44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e47: Invalid comparison between Unknown and I4
		//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec3: Invalid comparison between Unknown and I4
		//IL_1f14: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f17: Invalid comparison between Unknown and I4
		//IL_1f6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f72: Invalid comparison between Unknown and I4
		//IL_199c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0831: Unknown result type (might be due to invalid IL or missing references)
		//IL_1da2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_4584: Unknown result type (might be due to invalid IL or missing references)
		//IL_225f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2431: Unknown result type (might be due to invalid IL or missing references)
		//IL_25d0: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == 112)
		{
			if ((mSG.Col == 12) | (mSG.Col == 13) | (mSG.Col == 17))
			{
				DC_Main.RsQry = "SELECT * FROM TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + MSG[MSG.Row, 2] + "'";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (mSG.Col == 12)
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
				else if (mSG.Col == 13)
				{
					if (dataTable.Rows.Count == 0)
					{
						DC_Main.ExeQuteDc("INSERT INTO TOUCH_MAST (CO_CODE,LC_CODE,AC_CODE,AC_IT_CODE,AC_TOUCH,AC_WEST,AC_LBR_RATE) VALUES('" + DC_Main.MCo_code + "' ,'" + DC_Main.MLc_code + "','" + tAcCode.Text + "', '" + mSG[mSG.Row, 2] + "' ," + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 12])) + "," + Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text)) + ",0) ");
					}
					else
					{
						DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_WEST = " + Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG[mSG.Row, 2] + "' ");
					}
				}
				else if (mSG.Col == 17)
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
			checked
			{
				if ((mSG.Col == 1) & (Operators.CompareString(EntryMode, "A", false) == 0))
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.ORD_NO As OrdNoL,D.AC_NAME As AcNameL,A.TAG_NO AS TagNoL,A.DESIGN_NO AS DesignNoL,C.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,A.ITM_GWT AS GrWtW,A.ITM_NWT AS NetWtW,A.ITM_MRP as MrpR,A.VCH_SRNO,A.ORD_YRCD As OrdYrCdL,A.ORD_DBCD As OrdDbCdL,A.ORD_SRNO As OrdSrNoL,B.TAG_STK_LESS As TagStkLessM From ((BAR_DETL AS A LEFT JOIN SL_ORD_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.ORD_YRCD = B.CO_YEAR AND A.ORD_DBCD = B.CO_BOOK AND A.ORD_NO = B.VCH_NO AND A.ORD_SRNO = B.OLD_SRNO)LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE =  C.IT_CODE)  LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.ORD_AC = D.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND  A.LC_CODE = '" + DC_Main.MLc_code + "' and A.ORD_NO <> '' AND B.TAG_SALE = 'N' AND A.ORD_AC = '" + tAcCode.Text + "' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)"  ORDER BY A.ORD_NO,A.TAG_NO"));
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.ColWidth = new double[15];
					DC_Main.ColWidth[0] = 90.0;
					DC_Main.ColWidth[1] = 275.0;
					DC_Main.ColWidth[2] = 110.0;
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
					DC_Main.HelpSelect = 1;
					((Form)MyProject.Forms.MS_HELP).ShowDialog();
					if (DC_Main.HelpClose)
					{
						return;
					}
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) == 0)
					{
						TEXT_ENTRY.Text = "";
						mSG[mSG.Row, 50] = "";
						mSG[mSG.Row, 51] = "";
						mSG[mSG.Row, 52] = "";
						mSG[mSG.Row, 53] = "";
						((Control)TEXT_ENTRY).Focus();
						return;
					}
					TEXT_ENTRY.Text = DC_Main.ColValue[2];
					if (Operators.CompareString(DC_Main.ColValue[13], "Y", false) != 0)
					{
						int num = mSG.Rows - 1;
						DC_Main.X = 1;
						while (DC_Main.X <= num)
						{
							if ((Operators.CompareString(mSG[DC_Main.X, 1], TEXT_ENTRY.Text, false) == 0) & (mSG.Row != DC_Main.X))
							{
								Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
								return;
							}
							DC_Main.X++;
						}
						mSG[mSG.Row, 50] = DC_Main.ColValue[0];
						mSG[mSG.Row, 3] = DC_Main.ColValue[4];
						mSG[mSG.Row, 2] = DC_Main.ColValue[5];
						mSG[mSG.Row, 4] = DC_Main.ColValue[3];
						mSG[mSG.Row, 7] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.000");
						mSG[mSG.Row, 9] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.000");
						mSG[mSG.Row, 29] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
						mSG[mSG.Row, 25] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[9]));
						mSG[mSG.Row, 51] = DC_Main.ColValue[10];
						mSG[mSG.Row, 52] = DC_Main.ColValue[11];
						mSG[mSG.Row, 53] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[12]));
						((Control)TEXT_ENTRY).Focus();
						return;
					}
					DC_Main.i = 0;
					DC_Main.RsQry = "SELECT * FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.ColValue[10] + "' AND CO_BOOK = '" + DC_Main.ColValue[11] + "' AND VCH_NO = '" + DC_Main.ColValue[0] + "' AND OLD_SRNO = '" + DC_Main.ColValue[12] + "'";
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (RsDetl.Rows.Count > 0)
					{
						int num2 = mSG.Rows - 1;
						DC_Main.X = 1;
						while (DC_Main.X <= num2)
						{
							if ((Operators.CompareString(mSG[DC_Main.X, 1], TEXT_ENTRY.Text, false) == 0) & (mSG.Row != DC_Main.X))
							{
								Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
								return;
							}
							DC_Main.X++;
						}
						mSG[mSG.Row, 50] = DC_Main.ColValue[0];
						mSG[mSG.Row, 51] = DC_Main.ColValue[10];
						mSG[mSG.Row, 52] = DC_Main.ColValue[11];
						mSG[mSG.Row, 53] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[12]));
						mSG[mSG.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
						mSG[mSG.Row, 3] = DC_Main.ColValue[4];
						mSG[mSG.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
						mSG[mSG.Row, 23] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
						mSG[mSG.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
						mSG[mSG.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["HM_ID"], (object)""));
						mSG[mSG.Row, 6] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
						mSG[mSG.Row, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						mSG[mSG.Row, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
						mSG[mSG.Row, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						mSG[mSG.Row, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.000");
						mSG[mSG.Row, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
						mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG[mSG.Row, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						mSG[mSG.Row, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
						mSG[mSG.Row, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
						mSG[mSG.Row, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
						mSG[mSG.Row, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
						mSG[mSG.Row, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
						mSG[mSG.Row, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
						mSG[mSG.Row, 16] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
						mSG[mSG.Row, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
						mSG[mSG.Row, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
						mSG[mSG.Row, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
						mSG[mSG.Row, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
						mSG[mSG.Row, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
						mSG[mSG.Row, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
						mSG[mSG.Row, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
						mSG[mSG.Row, 24] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
						mSG[mSG.Row, 47] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
						mSG[mSG.Row, 26] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
						mSG[mSG.Row, 28] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
						mSG[mSG.Row, 25] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
						mSG[mSG.Row, 40] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["HM_ID2"], (object)""));
						mSG[mSG.Row, 41] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["HM_ID3"], (object)""));
						mSG[mSG.Row, 42] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["HM_ID4"], (object)""));
						mSG[mSG.Row, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["HM_ID_WT"])), "0.000");
						mSG[mSG.Row, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["HM_ID2_WT"])), "0.000");
						mSG[mSG.Row, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["HM_ID3_WT"])), "0.000");
						mSG[mSG.Row, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["HM_ID4_WT"])), "0.000");
						mSG[mSG.Row, 37] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["DESIGN_IMG_ID"], (object)""));
						mSG[mSG.Row, 54] = "Y";
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_ORD_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + mSG[mSG.Row, 1] + "' AND A.VCH_SRNO = " + mSG[mSG.Row, 25] + " ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[23] = Conversion.Val(MSG[mSG.Row, 21]);
							dr[0] = DC_Main.i + 1;
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
							dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
							dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_CODE"], (object)"");
							dr[4] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_NAME"], (object)"");
							dr[5] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SIZE"], (object)"");
							dr[6] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SFNO"], (object)"");
							dr[7] = 0;
							dr[8] = 0;
							dr[9] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS_WT"])), "0.000");
							dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
							dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
							dr[14] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							dr[22] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
							DtIdtl.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
					}
				}
			}
		}
		else if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num3 = (int)Math.Round(Conversion.Val(mSG[mSG.Row, 21]));
					List<DataRow> list = new List<DataRow>();
					int num4 = DtIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num4)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[DC_Main.M][23])) == Conversion.Val(mSG[mSG.Row, 21]))
						{
							list.Add(DtIdtl.Rows[DC_Main.M]);
						}
						DC_Main.M++;
					}
					foreach (DataRow item in list)
					{
						DtIdtl.Rows.Remove(item);
						DtIdtl.AcceptChanges();
					}
					int num5 = mSG.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num5)
					{
						mSG[mSG.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					if (mSG.Row == mSG.Rows - 1)
					{
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							mSG[mSG.Row, 21] = Conversions.ToString(MSG.Row);
						}
						else
						{
							mSG[mSG.Row, 21] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 21]) + 1.0);
						}
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
					{
						if (Operators.CompareString(FormBookInOut, "I", false) != 0 || !((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 1], false) != 0)))
						{
							break;
						}
						mSG[mSG.Row, 25] = Conversions.ToString(0);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO,A.VCH_SRNO,B.VCH_TIME FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 25]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 25]))) ?? ""))), (object)" AND B.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_TIME HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_TIME DESC"));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
							{
								DC_Main.RsQry = "Select C.DESIGN_NO AS DesignNoL,A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO <> 'N' AND C.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY SUBSTRING(C.DESIGN_NO,1,2), LEN(C.DESIGN_NO),C.DESIGN_NO,A.TAG_NO,C.VCH_TIME DESC";
							}
							else
							{
								DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,C.DESIGN_NO AS DesignNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO <> 'N' AND C.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_TIME DESC";
							}
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[10];
							DC_Main.ColWidth[0] = 120.0;
							DC_Main.ColWidth[1] = 120.0;
							DC_Main.ColWidth[2] = 300.0;
							DC_Main.ColWidth[3] = 100.0;
							DC_Main.ColWidth[4] = 100.0;
							DC_Main.ColWidth[5] = 100.0;
							DC_Main.ColWidth[6] = 110.0;
							DC_Main.ColWidth[7] = 0.0;
							DC_Main.ColWidth[8] = 0.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if ((Operators.CompareString(DC_Main.ColValue[0], "", false) != 0) | (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0))
							{
								if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[1];
									mSG[mSG.Row, 4] = DC_Main.ColValue[0];
								}
								else
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[0];
									mSG[mSG.Row, 4] = DC_Main.ColValue[1];
								}
								mSG[mSG.Row, 3] = DC_Main.ColValue[2];
								mSG[mSG.Row, 2] = DC_Main.ColValue[3];
								mSG[mSG.Row, 7] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 9] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 25] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
							}
							else
							{
								mSG[mSG.Row, 25] = "";
								mSG[mSG.Row, 1] = "";
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						int num14 = mSG.Rows - 1;
						DC_Main.X = 1;
						while (DC_Main.X <= num14)
						{
							if ((Operators.CompareString(mSG[DC_Main.X, 1], TEXT_ENTRY.Text, false) == 0) & (mSG.Row != DC_Main.X))
							{
								Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
								return;
							}
							DC_Main.X++;
						}
						mSG[mSG.Row, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
						if (DC_Main.Rshlp.Rows.Count > 1)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_TIME DESC"));
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[10];
							DC_Main.ColWidth[0] = 120.0;
							DC_Main.ColWidth[1] = 300.0;
							DC_Main.ColWidth[2] = 100.0;
							DC_Main.ColWidth[3] = 120.0;
							DC_Main.ColWidth[4] = 100.0;
							DC_Main.ColWidth[5] = 100.0;
							DC_Main.ColWidth[6] = 110.0;
							DC_Main.ColWidth[7] = 0.0;
							DC_Main.ColWidth[8] = 0.0;
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
								mSG[mSG.Row, 2] = DC_Main.ColValue[0];
								mSG[mSG.Row, 4] = DC_Main.ColValue[3];
								mSG[mSG.Row, 7] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 9] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 25] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
							}
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.RATE_TYPE FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = '"), (object)mSG[mSG.Row, 25]), (object)"' "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = mSG.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							mSG[DC_Main.i, 23] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							mSG[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
							mSG[DC_Main.i, 6] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG[DC_Main.i, 47] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
							mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
							mSG[DC_Main.i, 16] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							mSG[DC_Main.i, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_NET_WT"])), "0.00");
							mSG[DC_Main.i, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_TOUCH"])), "0.00");
							mSG[DC_Main.i, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_FINE"])), "0.000");
							mSG[DC_Main.i, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
							mSG[DC_Main.i, 24] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							mSG[DC_Main.i, 26] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG[DC_Main.i, 27] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 28] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
							mSG[DC_Main.i, 37] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
							mSG[DC_Main.i, 40] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID2"], (object)""));
							mSG[DC_Main.i, 41] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID3"], (object)""));
							mSG[DC_Main.i, 42] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID4"], (object)""));
							mSG[DC_Main.i, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID_WT"])), "0.000");
							mSG[DC_Main.i, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID2_WT"])), "0.000");
							mSG[DC_Main.i, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID3_WT"])), "0.000");
							mSG[DC_Main.i, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID4_WT"])), "0.000");
							lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)" : It Name"));
						}
						int num15 = 0;
						int num16 = DtIdtl.Rows.Count - 1;
						int num17 = num16;
						for (int i = 0; i <= num17; i++)
						{
							if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num15][23], (object)Conversion.Val(mSG[DC_Main.i, 21]), false))
							{
								DtIdtl.Rows[num15].Delete();
								DtIdtl.AcceptChanges();
								num15--;
							}
							num15++;
						}
						MSG_IDTL_CLEAR();
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + mSG[mSG.Row, 1] + "' AND A.VCH_SRNO = " + mSG[mSG.Row, 25] + " ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[23] = Conversion.Val(MSG[mSG.Row, 21]);
							dr[0] = DC_Main.i + 1;
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
							dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
							dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_CODE"], (object)"");
							dr[4] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_NAME"], (object)"");
							dr[5] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SIZE"], (object)"");
							dr[6] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SFNO"], (object)"");
							dr[7] = 0;
							dr[8] = 0;
							dr[9] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS_WT"])), "0.000");
							dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
							dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
							dr[14] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
							dr[22] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							DtIdtl.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
						CommPassTotal();
						MSG_RowColChange(MSG, new EventArgs());
						MSG_TOT_FILL();
						if (((Operators.CompareString(DC_Main.SSRegSrNo, "DM019NEDM", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)) && mSG.Row == mSG.Rows - 1)
						{
							MsgClear = true;
							mSG.Rows += 1;
							mSG.Row += 1;
							MsgClear = false;
							mSG.Col = 1;
							CommPassAdd();
							return;
						}
						break;
					}
					case 2:
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_ENTRY.Text + "'"), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "All", false) == 0, (object)"", (object)(" AND IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), Interaction.IIf(Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0, (object)"", (object)"AND BULK_SALE <> 'N'")), (object)""));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(Operators.CompareString(cboItemTyp.Text, "All", false) == 0, (object)"", (object)(" AND IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'"))), (object)" AND BULK_SALE <> 'N' ORDER BY A.IT_NAME"));
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
									mSG[mSG.Row, 28] = DC_Main.ColValue[3];
									mSG[mSG.Row, 26] = DC_Main.ColValue[4];
									mSG[mSG.Row, 27] = DC_Main.ColValue[4];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_CODE"], (object)""));
						mSG[mSG.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG[mSG.Row, 28] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						mSG[mSG.Row, 26] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG[mSG.Row, 27] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						mSG[mSG.Row, 47] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)" : It Name"));
						if (Conversions.ToBoolean(Operators.AndObject((object)((Operators.CompareString(mSG[mSG.Row, 22], "A", false) == 0) & (mSG.Row == mSG.Rows - 1)), Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""), (object)"P", false))))
						{
							mSG[mSG.Row, 16] = "P";
							mSG[mSG.Row, 38] = Conversions.ToString(0);
						}
						if ((DC_Main.RtView != null) & (Operators.CompareString(mSG[mSG.Row, 22], "A", false) == 0))
						{
							DC_Main.RtView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_CODE = '", DC_Main.Tbl.Rows[0]["GR_CODE"]), (object)"'"));
							if (DC_Main.RtView.Count > 0)
							{
								if (Operators.ConditionalCompareObjectNotEqual(DC_Main.RtView[0]["GR_RATE"], (object)0, false))
								{
									mSG[mSG.Row, 36] = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
									{
										Operators.DivideObject(DC_Main.RtView[0]["GR_RATE"], (object)10),
										0
									}, (string[])null, (Type[])null, (bool[])null)), "0.00");
									nItmRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
									{
										Operators.DivideObject(DC_Main.RtView[0]["GR_RATE"], (object)10),
										0
									}, (string[])null, (Type[])null, (bool[])null)), "0.00");
								}
							}
							else
							{
								mSG[mSG.Row, 36] = "";
								nItmRate.Text = "";
							}
						}
						if (!((Operators.CompareString(mSG[mSG.Row, 22], "E", false) != 0) & (Operators.CompareString(DC_Main.MsSoftType, "L", false) != 0)))
						{
							break;
						}
						DC_Main.RsQry = "Select * From TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_IT_CODE = '" + mSG[mSG.Row, 2] + "' AND AC_CODE  = '" + tAcCode.Text + "'";
						DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (dataTable2.Rows.Count > 0)
						{
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_TOUCH"]);
							double num6 = DC_Main.Fnv(ref Value);
							dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
							Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_WEST"]);
							double num7 = DC_Main.Fnv(ref Value);
							dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
							if (num6 + num7 != 0.0)
							{
								AxMSFlexGrid obj = mSG;
								int row = mSG.Row;
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_TOUCH"]);
								double num8 = DC_Main.Fnv(ref Value);
								dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
								obj[row, 12] = Strings.Format((object)num8, "0.00");
								AxMSFlexGrid obj2 = mSG;
								int row2 = mSG.Row;
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_WEST"]);
								double num9 = DC_Main.Fnv(ref Value);
								dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
								obj2[row2, 13] = Strings.Format((object)num9, "0.00");
								if ((Conversion.Val(mSG[mSG.Row, 9]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 12]) != 0.0))
								{
									mSG[mSG.Row, 14] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 9]) * (Conversion.Val(mSG[mSG.Row, 12]) + Conversion.Val(mSG[mSG.Row, 13])) / 100.0), "0.000");
								}
							}
							Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_LBR_RATE"]);
							double num10 = DC_Main.Fnv(ref Value);
							dataRow["AC_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							if (num10 != 0.0)
							{
								AxMSFlexGrid obj3 = mSG;
								int row3 = mSG.Row;
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["AC_LBR_RATE"]);
								double num11 = DC_Main.Fnv(ref Value);
								dataRow["AC_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								obj3[row3, 17] = Strings.Format((object)num11, "0.00");
								mSG[mSG.Row, 16] = Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[0]["AC_LBR_TYPE"], (object)""));
							}
							break;
						}
						DC_Main.RsQry = "Select IT_TOUCH,IT_WEST From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + mSG[mSG.Row, 2] + "' ";
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (dataTable2.Rows.Count > 0 && Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[0]["IT_TOUCH"], (object)"")) + Conversion.Val(Operators.ConcatenateObject(dataTable2.Rows[0]["IT_WEST"], (object)"")) != 0.0)
						{
							AxMSFlexGrid obj4 = mSG;
							int row4 = mSG.Row;
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["IT_TOUCH"]);
							double num12 = DC_Main.Fnv(ref Value);
							dataRow["IT_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
							obj4[row4, 12] = Strings.Format((object)num12, "0.00");
							AxMSFlexGrid obj5 = mSG;
							int row5 = mSG.Row;
							Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable2.Rows[0])["IT_WEST"]);
							double num13 = DC_Main.Fnv(ref Value);
							dataRow["IT_WEST"] = RuntimeHelpers.GetObjectValue(Value);
							obj5[row5, 13] = Strings.Format((object)num13, "0.00");
							if ((Conversion.Val(mSG[mSG.Row, 9]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 12]) != 0.0))
							{
								mSG[mSG.Row, 14] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 9]) * (Conversion.Val(mSG[mSG.Row, 12]) + Conversion.Val(mSG[mSG.Row, 13])) / 100.0), "0.000");
							}
						}
						break;
					}
					case 23:
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
									mSG[mSG.Row, 23] = DC_Main.ColValue[1];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 23] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
						break;
					case 7:
						if ((Conversion.Val(TEXT_ENTRY.Text) == 0.0) & (Operators.CompareString(mSG[mSG.Row, 47], "P", false) != 0))
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						mSG[mSG.Row, 7] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
						CommPassTotal();
						((Control)TEXT_ENTRY).Visible = false;
						MSG_IDTL.Row = MSG_IDTL.Rows - 1;
						MSG_IDTL.Col = 1;
						MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
						((Control)TEXT_IDTL).Focus();
						((TextBoxBase)TEXT_IDTL).SelectAll();
						return;
					case 20:
						if (mSG.Row == mSG.Rows - 1)
						{
							MsgClear = true;
							mSG.Rows += 1;
							mSG.Row += 1;
							MsgClear = false;
							if (MSG[1] == 0)
							{
								MSG.Col = 2;
							}
							else
							{
								MSG.Col = 1;
							}
							CommPassAdd();
						}
						else
						{
							mSG.Row += 1;
							if (MSG[1] == 0)
							{
								MSG.Col = 2;
							}
							else
							{
								MSG.Col = 1;
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

	private void TR_SALE_LBR_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_12a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12af: Expected O, but got Unknown
		//IL_12d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e3: Expected O, but got Unknown
		//IL_1308: Unknown result type (might be due to invalid IL or missing references)
		//IL_130d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1317: Expected O, but got Unknown
		//IL_133c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1341: Unknown result type (might be due to invalid IL or missing references)
		//IL_134b: Expected O, but got Unknown
		//IL_138a: Unknown result type (might be due to invalid IL or missing references)
		//IL_138f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1399: Expected O, but got Unknown
		//IL_13b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c2: Expected O, but got Unknown
		//IL_13dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_13eb: Expected O, but got Unknown
		//IL_1405: Unknown result type (might be due to invalid IL or missing references)
		//IL_140a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1414: Expected O, but got Unknown
		//IL_142e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1433: Unknown result type (might be due to invalid IL or missing references)
		//IL_143d: Expected O, but got Unknown
		//IL_1457: Unknown result type (might be due to invalid IL or missing references)
		//IL_145c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1466: Expected O, but got Unknown
		//IL_148e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1495: Expected O, but got Unknown
		//IL_1555: Unknown result type (might be due to invalid IL or missing references)
		//IL_155a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1564: Expected O, but got Unknown
		//IL_15ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_15fb: Expected O, but got Unknown
		//IL_1694: Unknown result type (might be due to invalid IL or missing references)
		//IL_1699: Unknown result type (might be due to invalid IL or missing references)
		//IL_169f: Expected O, but got Unknown
		//IL_1729: Unknown result type (might be due to invalid IL or missing references)
		//IL_172e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1738: Expected O, but got Unknown
		//IL_175d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1762: Unknown result type (might be due to invalid IL or missing references)
		//IL_176c: Expected O, but got Unknown
		//IL_177c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1786: Expected O, but got Unknown
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
				AxMSFlexGrid mSG_PR = MSG_PR;
				object? obj18 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG_PR2 = MSG_PR;
				object? obj19 = colorConverter.ConvertFromString("DarkGray");
				mSG_PR2.BackColorBkg = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG_PR3 = MSG_PR;
				object? obj20 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_PR3.BackColorFixed = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG_PR_TOT = MSG_PR_TOT;
				object? obj21 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG_PR_TOT2 = MSG_PR_TOT;
				object? obj22 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT2.BackColorBkg = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG_PR_TOT3 = MSG_PR_TOT;
				object? obj23 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT3.BackColorFixed = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				object? obj24 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				object? obj25 = colorConverter.ConvertFromString("DarkGray");
				mSG2_TOTAL2.BackColorBkg = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				object? obj26 = colorConverter.ConvertFromString("255, 224, 192");
				mSG2_TOTAL3.BackColorFixed = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG_ORD = MSG_ORD;
				object? obj27 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_ORD.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG_ORD2 = MSG_ORD;
				object? obj28 = colorConverter.ConvertFromString("DarkGray");
				mSG_ORD2.BackColorBkg = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG_ORD3 = MSG_ORD;
				object? obj29 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_ORD3.BackColorFixed = ((obj29 != null) ? ((Color)obj29) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj30 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj31 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj32 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj33 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj34 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj35 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj36 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj37 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj37 != null) ? ((Color)obj37) : default(Color));
				AxMSFlexGrid mSG_IDTL4 = MSG_IDTL;
				object? obj38 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL4.BackColor = ((obj38 != null) ? ((Color)obj38) : default(Color));
				AxMSFlexGrid mSG_IDTL5 = MSG_IDTL;
				object? obj39 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_IDTL5.BackColorBkg = ((obj39 != null) ? ((Color)obj39) : default(Color));
				AxMSFlexGrid mSG_IDTL6 = MSG_IDTL;
				object? obj40 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_IDTL6.BackColorFixed = ((obj40 != null) ? ((Color)obj40) : default(Color));
				AxMSFlexGrid mSG_PR4 = MSG_PR;
				object? obj41 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR4.BackColor = ((obj41 != null) ? ((Color)obj41) : default(Color));
				AxMSFlexGrid mSG_PR5 = MSG_PR;
				object? obj42 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_PR5.BackColorBkg = ((obj42 != null) ? ((Color)obj42) : default(Color));
				AxMSFlexGrid mSG_PR6 = MSG_PR;
				object? obj43 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_PR6.BackColorFixed = ((obj43 != null) ? ((Color)obj43) : default(Color));
				AxMSFlexGrid mSG_PR_TOT4 = MSG_PR_TOT;
				object? obj44 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT4.BackColor = ((obj44 != null) ? ((Color)obj44) : default(Color));
				AxMSFlexGrid mSG_PR_TOT5 = MSG_PR_TOT;
				object? obj45 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT5.BackColorBkg = ((obj45 != null) ? ((Color)obj45) : default(Color));
				AxMSFlexGrid mSG_PR_TOT6 = MSG_PR_TOT;
				object? obj46 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT6.BackColorFixed = ((obj46 != null) ? ((Color)obj46) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj47 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj47 != null) ? ((Color)obj47) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj48 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj48 != null) ? ((Color)obj48) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj49 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj49 != null) ? ((Color)obj49) : default(Color));
				AxMSFlexGrid mSG_ORD4 = MSG_ORD;
				object? obj50 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_ORD4.BackColor = ((obj50 != null) ? ((Color)obj50) : default(Color));
				AxMSFlexGrid mSG_ORD5 = MSG_ORD;
				object? obj51 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_ORD5.BackColorBkg = ((obj51 != null) ? ((Color)obj51) : default(Color));
				AxMSFlexGrid mSG_ORD6 = MSG_ORD;
				object? obj52 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_ORD6.BackColorFixed = ((obj52 != null) ? ((Color)obj52) : default(Color));
				ComboBox obj53 = cboItemTyp;
				object? obj54 = colorConverter.ConvertFromString("233, 235, 240");
				obj53.BackColor = ((obj54 != null) ? ((Color)obj54) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj55 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj55 != null) ? ((Color)obj55) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj56 = lblBook;
				object? obj57 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj56).ForeColor = ((obj57 != null) ? ((Color)obj57) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj58 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj58 != null) ? ((Color)obj58) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj59 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj59 != null) ? ((Color)obj59) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj60 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj60 != null) ? ((Color)obj60) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj61 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj61 != null) ? ((Color)obj61) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj62 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj62 != null) ? ((Color)obj62) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj63 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj63 != null) ? ((Color)obj63) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj64 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj64 != null) ? ((Color)obj64) : default(Color));
				AxMSFlexGrid mSG_IDTL7 = MSG_IDTL;
				object? obj65 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL7.BackColor = ((obj65 != null) ? ((Color)obj65) : default(Color));
				AxMSFlexGrid mSG_IDTL8 = MSG_IDTL;
				object? obj66 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_IDTL8.BackColorBkg = ((obj66 != null) ? ((Color)obj66) : default(Color));
				AxMSFlexGrid mSG_IDTL9 = MSG_IDTL;
				object? obj67 = colorConverter.ConvertFromString("Cornsilk");
				mSG_IDTL9.BackColorFixed = ((obj67 != null) ? ((Color)obj67) : default(Color));
				AxMSFlexGrid mSG_PR7 = MSG_PR;
				object? obj68 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR7.BackColor = ((obj68 != null) ? ((Color)obj68) : default(Color));
				AxMSFlexGrid mSG_PR8 = MSG_PR;
				object? obj69 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_PR8.BackColorBkg = ((obj69 != null) ? ((Color)obj69) : default(Color));
				AxMSFlexGrid mSG_PR9 = MSG_PR;
				object? obj70 = colorConverter.ConvertFromString("Cornsilk");
				mSG_PR9.BackColorFixed = ((obj70 != null) ? ((Color)obj70) : default(Color));
				AxMSFlexGrid mSG_PR_TOT7 = MSG_PR_TOT;
				object? obj71 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT7.BackColor = ((obj71 != null) ? ((Color)obj71) : default(Color));
				AxMSFlexGrid mSG_PR_TOT8 = MSG_PR_TOT;
				object? obj72 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT8.BackColorBkg = ((obj72 != null) ? ((Color)obj72) : default(Color));
				AxMSFlexGrid mSG_PR_TOT9 = MSG_PR_TOT;
				object? obj73 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT9.BackColorFixed = ((obj73 != null) ? ((Color)obj73) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj74 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj74 != null) ? ((Color)obj74) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj75 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj75 != null) ? ((Color)obj75) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj76 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj76 != null) ? ((Color)obj76) : default(Color));
				AxMSFlexGrid mSG_ORD7 = MSG_ORD;
				object? obj77 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_ORD7.BackColor = ((obj77 != null) ? ((Color)obj77) : default(Color));
				AxMSFlexGrid mSG_ORD8 = MSG_ORD;
				object? obj78 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_ORD8.BackColorBkg = ((obj78 != null) ? ((Color)obj78) : default(Color));
				AxMSFlexGrid mSG_ORD9 = MSG_ORD;
				object? obj79 = colorConverter.ConvertFromString("Cornsilk");
				mSG_ORD9.BackColorFixed = ((obj79 != null) ? ((Color)obj79) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj80 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj80 != null) ? ((Color)obj80) : default(Color));
				ComboBox obj81 = cboItemTyp;
				object? obj82 = colorConverter.ConvertFromString("238, 244, 236");
				obj81.BackColor = ((obj82 != null) ? ((Color)obj82) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_IDTL).AutoSize = false;
				((TextBoxBase)TEXT_PR).AutoSize = false;
				((TextBoxBase)TEXT_ENTRY_2).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_PR).Font = new Font(((Control)TEXT_PR).Font.FontFamily, (float)num3, ((Control)TEXT_PR).Font.Style);
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_IDTL).Font = new Font(((Control)TEXT_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_IDTL).Font.Style);
				((Control)TEXT_ENTRY_2).Font = new Font(((Control)TEXT_ENTRY_2).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY_2).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG_PR.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_PR_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
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
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_IDTL", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_PR", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY_2", false) != 0)))
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
				((Control)chkWapp).Font = new Font("Segoe UI Semibold", (float)num3, (FontStyle)0);
				if (DC_Main.ScreenHight > 1.0)
				{
					MSG_TOT.ScrollBars = (ScrollBarsSettings)0;
					MSG_PR_TOT.ScrollBars = (ScrollBarsSettings)0;
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
			if ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) & (Operators.CompareString(DC_Main.MsBillProfit, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0))
			{
				nItProfit.Text = "It Profit :";
				((Control)nBillProfit).Visible = true;
				((Control)Label9).Visible = true;
			}
			if ((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) | DC_Main.MsEmailOpen)
			{
				((Control)chkWapp).Visible = true;
			}
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
		lblItem.Text = "";
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		OldAcCode = "";
		((TextBoxBase)tVchNo).ReadOnly = true;
		OldValTot = 0.0;
		NewValTot = 0.0;
		TotCrFine = 0.0;
		TotDrFine = 0.0;
		SlOthAmtLess = 0.0;
		PrOthAmtLess = 0.0;
		LessAdvAmt = 0.0;
		LessAdvNetWt = 0.0;
		OldCardAmt = 0.0;
		CrDrTot = 0.0;
		UpiTypeAdd = false;
		((Control)PnlUpi).Visible = false;
		chkWapp.Checked = false;
		CustMobile = "";
		if (Operators.CompareString(DC_Main.MsCardComAdj, "Y", false) == 0)
		{
			CardCommAdj = "Y";
		}
		else
		{
			CardCommAdj = "N";
		}
		UsUPdate = "N";
		UsDelete = "N";
		if (VchOldData != null)
		{
			VchOldData.Clear();
		}
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
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_IDTL).Visible = false;
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)TEXT_PR).Visible = false;
		((Control)TEXT_ORD).Visible = false;
		nItProfit.Text = "";
		MSG_CLEAR();
		MSG_IDTL_CLEAR();
		MSG_PR_CLEAR();
		MSG2_CLEAR();
		MSG_ORD_CLEAR();
		MSG_UPI_CLEAR();
		CommPassAddUpi();
		if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
		{
			cboItemTyp.SelectedIndex = 0;
		}
		else
		{
			cboItemTyp.SelectedIndex = 1;
		}
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) != 0)
		{
			if (Operators.CompareString(FormBookType, "T", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '10'";
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
					MSG2_TOTAL[2, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
				}
			}
		}
		else if (Operators.CompareString(FormBookType, "T", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '11'";
			DC_Main.RsTax = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.RsTax.Rows.Count > 0)
			{
				TEXT_ENTRY_2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
				MSG2_TOTAL[2, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL2[2, 2] = Strings.Format((object)num2, "0.00");
				MSG2_TOTAL[2, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
			}
		}
		if (Operators.CompareString(FormBookType, "T", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '11'";
			DC_Main.RsTax = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.RsTax.Rows.Count > 0)
			{
				TEXT_ENTRY_2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
				MSG2_TOTAL[7, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL3[7, 2] = Strings.Format((object)num3, "0.00");
				MSG2_TOTAL[7, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
			}
		}
		DtIdtl.Clear();
		DtIdtl.Reset();
		FilRow = 0;
		checked
		{
			int num4 = MSG_IDTL.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num4)
			{
				DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
			{
				tEmpCode.Text = DC_Main.MsUserEmpCode;
				tEmpName.Text = DC_Main.MsUserEmpName;
			}
			DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
			TodayFineRate();
			EntryMode = "A";
			((Control)BtnSave).Enabled = true;
			((Control)tVchNo).Focus();
		}
	}

	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "SELECT A.*,B.AC_NAME,B.AC_MOBILE FROM LBR_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "'";
		if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
		{
			VchOldData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
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
				tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
				OldAcCode = tAcCode.Text;
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_NAME"], (object)""));
				CustMobile = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_MOBILE"], (object)""));
				nTotWtCr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CR_WT"]), "0.000");
				nTotWtDr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_WT"]), "0.000");
				nOrdWt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ORD_FINE"]), "0.000");
				nConvRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CONV_RATE"]), "0.00");
				nConvPrc.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CONV_PRC"]), "0.00");
				nCrFine.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CR_FINE"]), "0.000");
				nDrFine.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_FINE"]), "0.000");
				nDrRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_RATE"]), "0.00");
				nCrAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CR_AMT"]), "0.00");
				nDrAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_AMT"]), "0.00");
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
				if (Operators.ConditionalCompareObjectEqual(RsData.Rows[0]["IT_TYPE"], (object)"G", false))
				{
					cboItemTyp.SelectedIndex = 0;
				}
				else
				{
					cboItemTyp.SelectedIndex = 1;
				}
				MSG2_TOTAL[1, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_NET_AMT"]), "0.00");
				MSG2_TOTAL[2, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TAX_CODE"], (object)""));
				MSG2_TOTAL[2, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"]), "0.00");
				MSG2_TOTAL[2, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_AMT"]), "0.00");
				MSG2_TOTAL[5, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DR_LBR"]), "0.00");
				MSG2_TOTAL[6, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["LBR_DISC_PRC"]), "0.00");
				MSG2_TOTAL[6, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["LBR_DISC_AMT"]), "0.00");
				MSG2_TOTAL[7, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["LBR_TAX_CODE"], (object)""));
				MSG2_TOTAL[7, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["LBR_TAX_PRC"]), "0.00");
				MSG2_TOTAL[7, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["LBR_TAX_AMT"]), "0.00");
				MSG2_TOTAL[8, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_DR_AMT"]), "0.00");
				MSG2_TOTAL[3, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OTH_DR_AMT"]), "0.00");
				MSG2_TOTAL[4, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["OTH_TAX_CODE"], (object)""));
				MSG2_TOTAL[4, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OTH_TAX_PRC"]), "0.00");
				MSG2_TOTAL[4, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OTH_TAX_AMT"]), "0.00");
				MSG2_TOTAL[9, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CHQ_AMT"]), "0.00");
				MSG2_TOTAL[10, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CARD_AMT"]), "0.00");
				MSG2_TOTAL[10, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_COM_AMT"]), "0.00");
				OldCardAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CARD_AMT"]), "0.00"));
				CardCommAdj = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_ADJ"], (object)""));
				MSG2_TOTAL[11, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ORD_AMT"]), "0.00");
				MSG2_TOTAL[12, 4] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SL_CASH_AMT"]), "0.00");
				MSG2_TOTAL[12, 1] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["UPI_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["SL_KASAR_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["SL_KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[13, 4] = Strings.Format((object)num, "0.00");
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["SL_BILL_OS"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["SL_BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL2[14, 4] = Strings.Format((object)num2, "0.00");
				MSG2_TOTAL[1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_NET_AMT"]), "0.00");
				MSG2_TOTAL[8, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_CR_AMT"]), "0.00");
				MSG2_TOTAL[9, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_CHQ_AMT"]), "0.00");
				MSG2_TOTAL[10, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_CARD_AMT"]), "0.00");
				MSG2_TOTAL[12, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PR_CASH_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["PR_KASAR_AMT"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["PR_KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL3[13, 3] = Strings.Format((object)num3, "0.00");
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["PR_BILL_OS"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["PR_BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL4[14, 3] = Strings.Format((object)num4, "0.00");
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[2, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[2, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
				}
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[4, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[4, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
				}
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[7, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[7, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
				}
				MSG2_TOTAL[9, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[9, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[9, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[9, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[10, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[10, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[10, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
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
				if (Operators.CompareString(Strings.Mid(cboItemTyp.Text, 1, 1), "G", false) == 0)
				{
					DC_Main.MsAcGoldClBal += 0.0 - Conversion.Val(nOrdWt.Text);
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
				if (Operators.CompareString(Strings.Mid(cboItemTyp.Text, 1, 1), "S", false) == 0)
				{
					DC_Main.MsAcSilverClBal += 0.0 - Conversion.Val(nOrdWt.Text);
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
				TodayFineRate();
				MSG_CLEAR();
				MSG_IDTL_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.RATE_TYPE FROM LBR_ISU_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 21] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""), (object)"", false))
					{
						mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					}
					else
					{
						mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					}
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
					{
						mSG[DC_Main.i + 1, 1] = "";
					}
					else
					{
						mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					}
					mSG[DC_Main.i + 1, 23] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 59] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 47] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 16] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 49] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_COST"])), "0.00");
					mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 24] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 26] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 28] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG[DC_Main.i + 1, 37] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
					mSG[DC_Main.i + 1, 40] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG[DC_Main.i + 1, 41] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG[DC_Main.i + 1, 42] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
					mSG[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
					mSG[DC_Main.i + 1, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
					mSG[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
					mSG[DC_Main.i + 1, 50] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_NO"], (object)""));
					mSG[DC_Main.i + 1, 51] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_DBCD"], (object)""));
					mSG[DC_Main.i + 1, 53] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_SRNO"], (object)"")), "0");
					mSG[DC_Main.i + 1, 54] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_TAG_STK_ADD"], (object)""));
					mSG[DC_Main.i + 1, 22] = "E";
					mSG.Rows += 1;
					DC_Main.i++;
				}
				if (mSG.Rows > 2)
				{
					mSG.Rows -= 1;
				}
				ItmProfit(1);
				mSG = null;
				if ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) & (Operators.CompareString(DC_Main.MsBillProfit, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0))
				{
					double num5 = 0.0;
					int num6 = MSG.Rows - 1;
					for (int i = 0; i <= num6; i++)
					{
						ItmProfit(i);
						num5 += Conversion.Val(MSG[i, 55]);
					}
					nBillProfit.Text = Strings.Format((object)num5, "0.00");
				}
				MSG_TOT_FILL();
				DtIdtl.Clear();
				DtIdtl.Reset();
				FilRow = 0;
				int num7 = MSG_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num7)
				{
					DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM LBR_ISU_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					dr = DtIdtl.NewRow();
					dr[23] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
					dr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]);
					dr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
					dr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
					dr[3] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_CODE"], (object)"");
					dr[4] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_NAME"], (object)"");
					dr[5] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
					dr[6] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
					dr[7] = 0;
					dr[8] = 0;
					dr[9] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
					if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
					{
						dr[10] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_PCS_WT"], (object)"")), "0.000000");
					}
					else
					{
						dr[10] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_PCS_WT"], (object)"")), "0.0000");
					}
					dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
					dr[14] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					dr[22] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE FROM LBR_REC_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsPrDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG_PR = MSG_PR;
				while (DC_Main.i < RsPrDetl.Rows.Count)
				{
					mSG_PR[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_PR[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG_PR[DC_Main.i + 1, 10] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 11] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 3] = Conversions.ToString(RsPrDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_PR[DC_Main.i + 1, 4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LESS_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 36] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_TOUCH"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LESS_TOUCH"]))), "0.00");
					mSG_PR[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 22] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_OTH_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_OTH_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 18] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["ITM_SIGN"], (object)""));
					mSG_PR[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG_PR[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 33] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 32] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_PR.Rows += 1;
					DC_Main.i++;
				}
				if (mSG_PR.Rows > 2)
				{
					mSG_PR.Rows -= 1;
				}
				mSG_PR = null;
				MSG_PR_TOT_FILL();
				DC_Main.i = 0;
				DC_Main.RsQry = "Select * From SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'  Order By Sr_No";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				while (DC_Main.i < dataTable.Rows.Count)
				{
					AxMSFlexGrid mSG_ORD = MSG_ORD;
					mSG_ORD[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_ORD[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_HD_VCH_NO"], (object)""));
					mSG_ORD[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_NO"], (object)""));
					mSG_ORD[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_LC"], (object)""));
					mSG_ORD[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_AC_CODE"], (object)""));
					mSG_ORD[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_YRCD"], (object)""));
					mSG_ORD[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_DBCD"], (object)""));
					mSG_ORD[DC_Main.i + 1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["ORD_AMT"]), "0.00");
					if (cboItemTyp.SelectedIndex == 1)
					{
						mSG_ORD[DC_Main.i + 1, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["ORD_SILVER"]), "0.000");
					}
					else
					{
						mSG_ORD[DC_Main.i + 1, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["ORD_GOLD"]), "0.000");
					}
					mSG_ORD.Rows += 1;
					DC_Main.i++;
					mSG_ORD = null;
				}
				if (MSG_ORD.Rows > 2)
				{
					MSG_ORD.Rows -= 1;
				}
				dataTable.Clear();
				DC_Main.RsQry = "SELECT * FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ORDER BY SR_NO ";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					DC_Main.i = 0;
					AxMSFlexGrid mSG_UPI = MSG_UPI;
					while (DC_Main.i < DC_Main.Tbl.Rows.Count)
					{
						mSG_UPI[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
						mSG_UPI[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["UPI_AC_CODE"], (object)""));
						mSG_UPI[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["UPI_AC_NAME"], (object)""));
						mSG_UPI[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["UPI_TYPE"], (object)""));
						mSG_UPI[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["UPI_ID"], (object)""));
						mSG_UPI[DC_Main.i + 1, 5] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["UPI_AMT"]), "0.00");
						if (Conversion.Val(mSG_UPI[DC_Main.i + 1, 5]) == 0.0)
						{
							mSG_UPI[DC_Main.i + 1, 5] = "";
						}
						mSG_UPI.Rows += 1;
						DC_Main.i++;
					}
					if (mSG_UPI.Rows > 2)
					{
						mSG_UPI.Rows -= 1;
					}
					mSG_UPI = null;
				}
				BILL_TOTAL();
				OldValTot = Conversion.Val(MSG_TOT[0, 7]) + Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 31]) + Conversion.Val(MSG_TOT[0, 19]) + Conversion.Val(MSG_TOT[0, 18]) + Conversion.Val(MSG2_TOTAL[14, 3]);
				NewValTot = Conversion.Val(MSG_TOT[0, 7]) + Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 31]) + Conversion.Val(MSG_TOT[0, 19]) + Conversion.Val(MSG_TOT[0, 18]) + Conversion.Val(MSG2_TOTAL[14, 3]);
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

	private void TR_SALE_LBR_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_SALE_LBR_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_52ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_528a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
		{
			Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
			((Control)tEmpCode).Focus();
			return;
		}
		DC_Main.DefaulterAc(tAcCode.Text);
		if ((Operators.CompareString(DC_Main.MsDefaulterAc, "Y", false) == 0) & (Conversion.Val(MSG2_TOTAL[14, 4]) > 0.0))
		{
			Interaction.MsgBox((object)"You Cant Save Entry Because This Party Is in Defaulter List...Please Change It First In AcMast...", (MsgBoxStyle)0, (object)null);
			DC_Main.MsDefaulterAc = "N";
			return;
		}
		if (DC_Main.MsCashLimit > 0.0 && Operators.CompareString(tAcCode.Text, "00045", false) != 0)
		{
			DC_Main.LedrCash(tAcCode.Text, DC_Main.MCo_Book, tVchNo.Text);
			if (Conversion.Val(MSG2_TOTAL[12, 4]) + DC_Main.AcCash > DC_Main.MsCashLimit)
			{
				Interaction.MsgBox((object)("Cash Recieved Limit Amount = " + Conversions.ToString(DC_Main.MsCashLimit) + " \r\nOld Ledr Value Is " + Conversions.ToString(DC_Main.AcCash) + " \r\nAnd Total Cash Amount Is " + Conversions.ToString(Conversion.Val(MSG2_TOTAL[12, 4]) + DC_Main.AcCash) + " You Can Not Receive More Then Cash Limit ..."), (MsgBoxStyle)0, (object)null);
				return;
			}
		}
		if ((Conversion.Val(MSG2_TOTAL[9, 3]) + Conversion.Val(MSG2_TOTAL[9, 4]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[9, 5], "", false) == 0))
		{
			Interaction.MsgBox((object)"Please Select Bank Account And Try Because Chq Rec Amt <> 0......", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (((Conversion.Val(MSG2_TOTAL[10, 3]) + Conversion.Val(MSG2_TOTAL[10, 4]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[10, 5], "", false) == 0)) && Operators.CompareString(CardCommAdj, "N", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Card Bank Account And Try Because Card Amt <> 0......", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if ((Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save This Voucher Becouse This Company Type is B......", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			mTime.Text = DateTime.Now.ToString("HH:mm:ss");
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
			DC_Main.RsQry = "SELECT * FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		Module_Save.LbrTran = null;
		checked
		{
			try
			{
				if (DC_Main.Dc.State != ConnectionState.Open)
				{
					DC_Main.Dc.Open();
				}
				Module_Save.LbrTran = DC_Main.Dc.BeginTransaction();
				Module_Save.ExeQuteDcSave("DELETE FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.LbrTran);
				Module_Save.ExeQuteDcSave("DELETE FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.LbrTran);
				Module_Save.ExeQuteDcSave("DELETE FROM LBR_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.LbrTran);
				Module_Save.ExeQuteDcSave("DELETE FROM LBR_ISU_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.LbrTran);
				if (Conversion.Val(MSG2_TOTAL[1, 4]) + Conversion.Val(MSG2_TOTAL[1, 3]) + Conversion.Val(MSG2_TOTAL[5, 4]) + Conversion.Val(nDrFine.Text) + Conversion.Val(nCrFine.Text) + Conversion.Val(nTotWtDr.Text) + Conversion.Val(nTotWtCr.Text) != 0.0)
				{
					Module_Save.ExeQuteDcSave("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "'", Module_Save.LbrTran);
					DC_Main.RsQry = "SELECT * FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "'";
					DataTable dataTable = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.LbrTran);
					Module_Save.MsInsertDataSave(Module_Save.LbrTran);
					DataRow dataRow = dataTable.NewRow();
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					dataRow["LC_CODE"] = DC_Main.MLc_code;
					dataRow["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow["VCH_NO"] = tHdVchNo.Text;
					dataRow["BOOK_NAME"] = FormName;
					dataTable.Rows.Add(dataRow);
					((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
					dataTable.Clear();
					DC_Main.RsQry = "SELECT * FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
					RsData = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.LbrTran);
					Module_Save.MsInsertDataSave(Module_Save.LbrTran);
					DataRow dataRow2 = RsData.NewRow();
					dataRow2["CO_CODE"] = DC_Main.MCo_code;
					dataRow2["LC_CODE"] = DC_Main.MLc_code;
					dataRow2["CO_YEAR"] = DC_Main.MCo_year;
					dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow2["VCH_NO"] = tVchNo.Text;
					dataRow2["AC_CODE"] = tAcCode.Text;
					dataRow2["VCH_DATE"] = mVchDate.Text;
					dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
					dataRow2["AC_CODE"] = tAcCode.Text;
					dataRow2["VCH_TYPE"] = FormBookSname;
					dataRow2["INOUT_TYPE"] = FormBookInOut;
					dataRow2["ENTRY_TYPE"] = "C";
					dataRow2["BOOK_NAME"] = FormMainBook;
					dataRow2["CR_WT"] = Conversion.Val(nTotWtCr.Text);
					dataRow2["DR_WT"] = Conversion.Val(nTotWtDr.Text);
					dataRow2["ORD_FINE"] = Conversion.Val(nOrdWt.Text);
					dataRow2["CR_TOUCH"] = 0;
					dataRow2["DR_TOUCH"] = 0;
					dataRow2["CR_FINE"] = Conversion.Val(nCrFine.Text);
					dataRow2["DR_FINE"] = Conversion.Val(nDrFine.Text);
					dataRow2["RATE_PAR"] = CurRatePar;
					dataRow2["CARD_ADJ"] = CardCommAdj;
					dataRow2["CONV_RATE"] = Conversion.Val(nConvRate.Text);
					dataRow2["CONV_PRC"] = Conversion.Val(nConvPrc.Text);
					dataRow2["CR_RATE"] = 0;
					dataRow2["DR_RATE"] = Conversion.Val(nDrRate.Text);
					dataRow2["DR_AMT"] = Conversion.Val(nDrAmt.Text);
					dataRow2["CR_AMT"] = Conversion.Val(nCrAmt.Text);
					dataRow2["IT_TYPE"] = Strings.Mid(cboItemTyp.Text, 1, 1);
					dataRow2["SL_NET_AMT"] = Conversion.Val(MSG2_TOTAL[1, 4]);
					dataRow2["TAX_CODE"] = Conversion.Val(MSG2_TOTAL[2, 5]);
					dataRow2["TAX_PRC"] = Conversion.Val(MSG2_TOTAL[2, 2]);
					dataRow2["TAX_AMT"] = Conversion.Val(MSG2_TOTAL[2, 4]);
					dataRow2["DR_LBR"] = Conversion.Val(MSG2_TOTAL[5, 4]);
					dataRow2["LBR_DR_AMT"] = 0;
					dataRow2["LBR_DISC_PRC"] = Conversion.Val(MSG2_TOTAL[6, 2]);
					dataRow2["LBR_DISC_AMT"] = Conversion.Val(MSG2_TOTAL[6, 4]);
					dataRow2["LBR_TAX_CODE"] = MSG2_TOTAL[7, 5];
					dataRow2["LBR_TAX_PRC"] = Conversion.Val(MSG2_TOTAL[7, 2]);
					dataRow2["LBR_TAX_AMT"] = Conversion.Val(MSG2_TOTAL[7, 4]);
					dataRow2["TOT_DR_AMT"] = Conversion.Val(MSG2_TOTAL[8, 4]);
					dataRow2["OTH_DR_AMT"] = Conversion.Val(MSG2_TOTAL[3, 4]);
					dataRow2["OTH_TAX_CODE"] = MSG2_TOTAL[4, 5];
					dataRow2["OTH_TAX_PRC"] = Conversion.Val(MSG2_TOTAL[4, 2]);
					dataRow2["OTH_TAX_AMT"] = Conversion.Val(MSG2_TOTAL[4, 4]);
					dataRow2["UPI_AMT"] = Conversion.Val(MSG2_TOTAL[12, 1]);
					dataRow2["SL_CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[9, 4]);
					dataRow2["SL_CARD_AMT"] = Conversion.Val(MSG2_TOTAL[10, 4]);
					dataRow2["CARD_COM_AMT"] = Conversion.Val(MSG2_TOTAL[10, 2]);
					dataRow2["ORD_AMT"] = Conversion.Val(MSG2_TOTAL[11, 4]);
					dataRow2["SL_CASH_AMT"] = Conversion.Val(MSG2_TOTAL[12, 4]);
					dataRow2["SL_KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[13, 4]);
					dataRow2["SL_BILL_OS"] = Conversion.Val(MSG2_TOTAL[14, 4]);
					dataRow2["CR_LBR"] = 0;
					dataRow2["PR_NET_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
					dataRow2["TOT_CR_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);
					dataRow2["PR_CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);
					dataRow2["PR_CARD_AMT"] = Conversion.Val(MSG2_TOTAL[10, 3]);
					dataRow2["PR_CASH_AMT"] = Conversion.Val(MSG2_TOTAL[12, 3]);
					dataRow2["PR_KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[13, 3]);
					dataRow2["PR_BILL_OS"] = Conversion.Val(MSG2_TOTAL[14, 3]);
					dataRow2["CARD_AC"] = MSG2_TOTAL[10, 5];
					dataRow2["BANK_AC"] = MSG2_TOTAL[9, 5];
					dataRow2["CHQ_NO"] = MSG2_TOTAL[9, 2];
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
				}
				DC_Main.RsQry = "SELECT * FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsDetl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.LbrTran);
				Module_Save.MsInsertDataSave(Module_Save.LbrTran);
				DataRow dataRow3 = RsDetl.NewRow();
				int num = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num)
				{
					AxMSFlexGrid mSG = MSG;
					if (((Operators.CompareString(mSG[DC_Main.i, 2], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 29]) != 0.0)) | (Conversion.Val(mSG[DC_Main.i, 9]) + Conversion.Val(mSG[DC_Main.i, 19]) + Conversion.Val(mSG[DC_Main.i, 18]) != 0.0))
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
						dataRow3["ENTRY_TYPE"] = "C";
						dataRow3["BOOK_NAME"] = FormMainBook;
						dataRow3["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
						dataRow3["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 21]);
						dataRow3["IT_CODE"] = mSG[DC_Main.i, 2];
						dataRow3["ITM_REMARK"] = mSG[DC_Main.i, 3];
						if (Operators.CompareString(mSG[DC_Main.i, 1], "", false) == 0)
						{
							dataRow3["TAG_NO"] = "N";
						}
						else
						{
							dataRow3["TAG_NO"] = mSG[DC_Main.i, 1];
						}
						dataRow3["TBL_CODE"] = mSG[DC_Main.i, 23];
						dataRow3["DESIGN_NO"] = mSG[DC_Main.i, 4];
						dataRow3["HM_ID"] = mSG[DC_Main.i, 5];
						dataRow3["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 6]);
						dataRow3["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 7]);
						dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 8]);
						dataRow3["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 9]);
						dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 11]);
						dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 12]);
						dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 13]);
						dataRow3["NEW_FINE"] = 0;
						dataRow3["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 14]);
						dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 36]);
						dataRow3["LBR_PRC"] = Conversion.Val(mSG[DC_Main.i, 15]);
						dataRow3["LBR_TYPE"] = mSG[DC_Main.i, 16];
						dataRow3["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 17]);
						dataRow3["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 18]);
						dataRow3["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 19]);
						dataRow3["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 20]);
						dataRow3["NEW_GWT"] = 0;
						dataRow3["NEW_OTH"] = 0;
						dataRow3["NEW_NWT"] = 0;
						dataRow3["DIFF_GWT"] = 0;
						dataRow3["DIFF_NWT"] = 0;
						dataRow3["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 29]);
						dataRow3["TAG_COST"] = Conversion.Val(mSG[DC_Main.i, 35]);
						dataRow3["KR_NET_WT"] = Conversion.Val(mSG[DC_Main.i, 31]);
						dataRow3["KR_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 30]);
						if (Conversion.Val(mSG[DC_Main.i, 32]) + Conversion.Val(mSG[DC_Main.i, 33]) == 0.0)
						{
							dataRow3["KR_TOUCH"] = 0;
							dataRow3["KR_WEST_PRC"] = 0;
							dataRow3["KR_FINE"] = Conversion.Val(mSG[DC_Main.i, 14]);
						}
						else
						{
							dataRow3["KR_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 32]);
							dataRow3["KR_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 33]);
							dataRow3["KR_FINE"] = Conversion.Val(mSG[DC_Main.i, 34]);
						}
						dataRow3["KR_LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 56]);
						dataRow3["KR_OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 57]);
						dataRow3["KR_NAME"] = mSG[DC_Main.i, 24];
						dataRow3["IT_TYPE"] = mSG[DC_Main.i, 26];
						dataRow3["PR_CODE"] = mSG[DC_Main.i, 28];
						dataRow3["VCH_SRNO"] = Conversion.Val(mSG[DC_Main.i, 25]);
						dataRow3["NEW_VCH_SRNO"] = 0;
						dataRow3["DATA_TRFR"] = "N";
						dataRow3["APR_ISU"] = "N";
						dataRow3["DESIGN_IMG_ID"] = mSG[DC_Main.i, 37];
						dataRow3["HM_ID2"] = mSG[DC_Main.i, 40];
						dataRow3["HM_ID3"] = mSG[DC_Main.i, 41];
						dataRow3["HM_ID4"] = mSG[DC_Main.i, 42];
						dataRow3["HM_ID_WT"] = Conversion.Val(mSG[DC_Main.i, 43]);
						dataRow3["HM_ID2_WT"] = Conversion.Val(mSG[DC_Main.i, 44]);
						dataRow3["HM_ID3_WT"] = Conversion.Val(mSG[DC_Main.i, 45]);
						dataRow3["HM_ID4_WT"] = Conversion.Val(mSG[DC_Main.i, 46]);
						dataRow3["ORD_NO"] = mSG[DC_Main.i, 50];
						dataRow3["ORD_YRCD"] = mSG[DC_Main.i, 51];
						dataRow3["ORD_DBCD"] = mSG[DC_Main.i, 52];
						dataRow3["ORD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 53]);
						dataRow3["ORD_TAG_STK_ADD"] = mSG[DC_Main.i, 54];
						dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow3["MAIN_USER"] = MainUser;
						RsDetl.Rows.Add(dataRow3);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
					mSG = null;
					DC_Main.i++;
				}
				DC_Main.RsQry = "SELECT * FROM LBR_ISU_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsIdtl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.LbrTran);
				Module_Save.MsInsertDataSave(Module_Save.LbrTran);
				DataRow dataRow4 = RsIdtl.NewRow();
				int num2 = 0;
				int num3 = 1;
				int num4 = 0;
				if (DtIdtl.Rows.Count > 0)
				{
					DataView dataView = new DataView(DtIdtl);
					dataView.Sort = "RowSrNo Asc";
					DtIdtl = dataView.ToTable();
				}
				int num5 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num5; i++)
				{
					DataTable dtIdtl = DtIdtl;
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19])) != 0.0)
					{
						if ((double)num4 != Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23])))
						{
							num4 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23])));
							num3 = 1;
						}
						int num6 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23])));
						int num7 = MSG.Rows - 1;
						DC_Main.M = 1;
						while (DC_Main.M <= num7)
						{
							if ((double)num6 == Conversion.Val(MSG[DC_Main.M, 21]))
							{
								num2 = (int)Math.Round(Conversion.Val(MSG[DC_Main.M, 0]));
								break;
							}
							DC_Main.M++;
						}
						dataRow4["CO_CODE"] = DC_Main.MCo_code;
						dataRow4["LC_CODE"] = DC_Main.MLc_code;
						dataRow4["CO_YEAR"] = DC_Main.MCo_year;
						dataRow4["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow4["VCH_NO"] = tVchNo.Text;
						dataRow4["VCH_DATE"] = mVchDate.Text;
						dataRow4["AC_CODE"] = tAcCode.Text;
						dataRow4["VCH_TYPE"] = FormBookSname;
						dataRow4["INOUT_TYPE"] = FormBookInOut;
						dataRow4["ENTRY_TYPE"] = "W";
						dataRow4["BOOK_NAME"] = FormMainBook;
						dataRow4["SR_NO"] = Conversion.Val(MSG[num2, 21]);
						dataRow4["TAG_NO"] = MSG[num2, 1];
						dataRow4["VCH_SRNO"] = Conversion.Val(MSG[num2, 25]);
						dataRow4["ISR_NO"] = num3;
						dataRow4["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1]);
						dataRow4["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][3]);
						dataRow4["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][4]);
						dataRow4["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][5]);
						dataRow4["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][6]);
						dataRow4["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9]));
						dataRow4["IT_PCS_WT"] = Conversion.Val(Operators.ConcatenateObject(DtIdtl.Rows[i][10], (object)""));
						dataRow4["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12]));
						dataRow4["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][11]));
						dataRow4["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13]));
						dataRow4["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14]);
						dataRow4["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]));
						dataRow4["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]));
						dataRow4["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]));
						dataRow4["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18]));
						dataRow4["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]));
						dataRow4["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]));
						dataRow4["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22]);
						dataRow4["MAIN_USER"] = MainUser;
						num3++;
						RsIdtl.Rows.Add(dataRow4);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
						RsIdtl.Clear();
					}
					dtIdtl = null;
				}
				Module_Save.ExeQuteDcSave("DELETE FROM LBR_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'", Module_Save.LbrTran);
				DC_Main.RsQry = "SELECT * FROM LBR_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
				RsPrDetl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.LbrTran);
				Module_Save.MsInsertDataSave(Module_Save.LbrTran);
				DataRow dataRow5 = RsPrDetl.NewRow();
				int num8 = MSG_PR.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num8)
				{
					AxMSFlexGrid mSG_PR = MSG_PR;
					if ((Conversion.Val(MSG_PR[DC_Main.i, 5]) + Conversion.Val(MSG_PR[DC_Main.i, 29]) != 0.0) & (Operators.CompareString(MSG_PR[DC_Main.i, 1], "", false) != 0))
					{
						dataRow5["CO_CODE"] = DC_Main.MCo_code;
						dataRow5["LC_CODE"] = DC_Main.MLc_code;
						dataRow5["CO_YEAR"] = DC_Main.MCo_year;
						dataRow5["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow5["VCH_NO"] = tVchNo.Text;
						dataRow5["VCH_DATE"] = mVchDate.Text;
						dataRow5["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow5["AC_CODE"] = tAcCode.Text;
						dataRow5["VCH_TYPE"] = FormBookSname;
						dataRow5["INOUT_TYPE"] = FormBookInOut;
						dataRow5["ENTRY_TYPE"] = "P";
						dataRow5["BOOK_NAME"] = FormMainBook;
						dataRow5["SR_NO"] = Conversion.Val(mSG_PR[DC_Main.i, 0]);
						dataRow5["OLD_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 0]);
						dataRow5["IT_CODE"] = mSG_PR[DC_Main.i, 1];
						dataRow5["TAG_NO"] = "N";
						dataRow5["TBL_CODE"] = mSG_PR[DC_Main.i, 10];
						dataRow5["DESIGN_NO"] = mSG_PR[DC_Main.i, 11];
						dataRow5["BAG_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 12]);
						dataRow5["ITM_PCS"] = Conversion.Val(mSG_PR[DC_Main.i, 3]);
						dataRow5["ITM_GWT"] = Conversion.Val(mSG_PR[DC_Main.i, 4]);
						dataRow5["ITM_OTH_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 14]);
						dataRow5["ITM_NWT"] = Conversion.Val(mSG_PR[DC_Main.i, 5]);
						dataRow5["ITM_GHT_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 9]);
						dataRow5["ITM_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 6]);
						dataRow5["ITM_WEST_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 15]);
						dataRow5["LESS_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 7]);
						dataRow5["ITM_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 8]);
						dataRow5["LBR_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 21]);
						dataRow5["LBR_TYPE"] = mSG_PR[DC_Main.i, 22];
						dataRow5["LBR_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 23]);
						dataRow5["LBR_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 24]);
						dataRow5["OTH_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 25]);
						dataRow5["ITM_OTH_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 26]);
						dataRow5["ITM_OTH_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 27]);
						dataRow5["ITM_SIGN"] = mSG_PR[DC_Main.i, 18];
						dataRow5["ITM_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 19]);
						dataRow5["ITM_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 20]);
						dataRow5["ITM_MRP"] = Conversion.Val(mSG_PR[DC_Main.i, 28]);
						dataRow5["TOT_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 30]);
						dataRow5["TAX_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 31]);
						dataRow5["NET_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 29]);
						dataRow5["RATE_TYPE"] = mSG_PR[DC_Main.i, 33];
						dataRow5["IT_TYPE"] = mSG_PR[DC_Main.i, 32];
						dataRow5["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow5["WITH_STOCK"] = "Y";
						dataRow5["MAIN_USER"] = MainUser;
						RsPrDetl.Rows.Add(dataRow5);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsPrDetl);
						RsPrDetl.Clear();
					}
					mSG_PR = null;
					DC_Main.i++;
				}
				DC_Main.RsQry = "Delete FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.LbrTran);
				DC_Main.RsQry = "SELECT * FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ";
				DataTable dataTable2 = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.LbrTran);
				Module_Save.MsInsertDataSave(Module_Save.LbrTran);
				DataRow dataRow6 = dataTable2.NewRow();
				if (Conversion.Val(MSG2_TOTAL[11, 4]) + Conversion.Val(nOrdWt.Text) != 0.0)
				{
					AxMSFlexGrid mSG_ORD = MSG_ORD;
					int num9 = MSG_ORD.Rows - 1;
					DC_Main.i = 1;
					while (DC_Main.i <= num9)
					{
						if (Conversion.Val(MSG_ORD[DC_Main.i, 3]) + Conversion.Val(MSG_ORD[DC_Main.i, 2]) != 0.0)
						{
							dataRow6["CO_CODE"] = DC_Main.MCo_code;
							dataRow6["LC_CODE"] = DC_Main.MLc_code;
							dataRow6["CO_YEAR"] = DC_Main.MCo_year;
							dataRow6["CO_BOOK"] = DC_Main.MCo_Book;
							dataRow6["VCH_NO"] = tVchNo.Text;
							dataRow6["SR_NO"] = DC_Main.i;
							dataRow6["VCH_DATE"] = mVchDate.Text;
							dataRow6["HD_VCH_NO"] = tHdVchNo.Text;
							dataRow6["AC_CODE"] = tAcCode.Text;
							dataRow6["AC_NAME"] = tAcName.Text;
							dataRow6["VCH_TYPE"] = FormBookSname;
							dataRow6["INOUT_TYPE"] = FormBookInOut;
							dataRow6["ENTRY_TYPE"] = "S";
							dataRow6["BOOK_NAME"] = FormMainBook;
							dataRow6["ORD_HD_VCH_NO"] = mSG_ORD[DC_Main.i, 8];
							dataRow6["ORD_NO"] = mSG_ORD[DC_Main.i, 1];
							dataRow6["ORD_LC"] = mSG_ORD[DC_Main.i, 4];
							dataRow6["ORD_YRCD"] = mSG_ORD[DC_Main.i, 5];
							dataRow6["ORD_DBCD"] = mSG_ORD[DC_Main.i, 6];
							dataRow6["ORD_AC_CODE"] = mSG_ORD[DC_Main.i, 7];
							dataRow6["ORD_SIGN"] = "-";
							dataRow6["ORD_AMT"] = Conversion.Val(mSG_ORD[DC_Main.i, 3]);
							dataRow6["PAID_AC"] = "";
							dataRow6["PAID_AMT"] = 0;
							dataRow6["ORD_BAL_AMT"] = 0;
							if (cboItemTyp.SelectedIndex == 1)
							{
								dataRow6["ORD_GOLD"] = 0;
								dataRow6["ORD_SILVER"] = Conversion.Val(mSG_ORD[DC_Main.i, 2]);
							}
							else
							{
								dataRow6["ORD_GOLD"] = Conversion.Val(mSG_ORD[DC_Main.i, 2]);
								dataRow6["ORD_SILVER"] = 0;
							}
							dataRow6["KASAR_AMT"] = 0;
							dataRow6["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
							dataRow6["DATA_TRFR"] = "N";
							dataRow6["EMP_CODE"] = tEmpCode.Text;
							dataRow6["IT_DESC"] = "";
							dataRow6["MAIN_USER"] = MainUser;
							dataTable2.Rows.Add(dataRow6);
							((DbDataAdapter)(object)DC_Main.Da).Update(dataTable2);
							dataTable2.Clear();
						}
						DC_Main.i++;
					}
					mSG_ORD = null;
				}
				if (Operators.CompareString(tAcCode.Text, "00045", false) != 0)
				{
					Module_Save.ExeQuteDcSave("DELETE FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'", Module_Save.LbrTran);
					DC_Main.RsQry = "SELECT * FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
					RsBillOs = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.LbrTran);
					Module_Save.MsInsertDataSave(Module_Save.LbrTran);
					DataRow dataRow7 = RsBillOs.NewRow();
					if (Conversion.Val(MSG2_TOTAL[8, 4]) != 0.0)
					{
						dataRow7["CO_CODE"] = DC_Main.MCo_code;
						dataRow7["LC_CODE"] = DC_Main.MLc_code;
						dataRow7["CO_YEAR"] = DC_Main.MCo_year;
						dataRow7["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow7["VCH_NO"] = tVchNo.Text;
						dataRow7["SR_NO"] = 1;
						dataRow7["VCH_DATE"] = mVchDate.Text;
						dataRow7["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow7["AC_CODE"] = tAcCode.Text;
						dataRow7["VCH_TYPE"] = FormBookSname;
						dataRow7["INOUT_TYPE"] = FormBookInOut;
						dataRow7["ENTRY_TYPE"] = "O";
						dataRow7["BOOK_NAME"] = FormMainBook;
						dataRow7["BILL_AMT"] = Conversion.Val(MSG2_TOTAL[8, 4]);
						dataRow7["REC_AMT"] = Conversion.Val(MSG2_TOTAL[8, 4]) - (Conversion.Val(MSG2_TOTAL[14, 4]) + Conversion.Val(MSG2_TOTAL[13, 4]));
						dataRow7["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[13, 4]);
						dataRow7["BILL_GOLD"] = 0;
						dataRow7["REC_GOLD"] = 0;
						dataRow7["KASAR_GOLD"] = 0;
						dataRow7["BILL_SILVER"] = 0;
						dataRow7["REC_SILVER"] = 0;
						dataRow7["KASAR_SILVER"] = 0;
						dataRow7["OLD_ADJ_AMT"] = 0;
						dataRow7["OLD_ADJ_GOLD"] = 0;
						dataRow7["OLD_ADJ_SILVER"] = 0;
						dataRow7["BILL_LC"] = DC_Main.MLc_code;
						dataRow7["BILL_YRCD"] = DC_Main.MCo_year;
						dataRow7["BILL_DBCD"] = DC_Main.MCo_Book;
						dataRow7["BILL_NO"] = tVchNo.Text;
						dataRow7["BILL_HD_VCH_NO"] = tHdVchNo.Text;
						dataRow7["BILL_SRNO"] = 1;
						dataRow7["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow7["MAIN_USER"] = MainUser;
						dataRow7["DATA_TRFR"] = "N";
						dataRow7["DATA_TYPE"] = "A";
						RsBillOs.Rows.Add(dataRow7);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsBillOs);
						RsBillOs.Clear();
					}
				}
				DC_Main.RsQry = "DELETE FROM UPI_DATA WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.LbrTran);
				DC_Main.RsQry = "SELECT * FROM UPI_DATA WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsDetl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.LbrTran);
				Module_Save.MsInsertDataSave(Module_Save.LbrTran);
				DataRow dataRow8 = RsDetl.NewRow();
				int num10 = MSG_UPI.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num10)
				{
					if ((Operators.CompareString(MSG_UPI[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(MSG_UPI[DC_Main.i, 5]) != 0.0))
					{
						dataRow8["CO_CODE"] = DC_Main.MCo_code;
						dataRow8["LC_CODE"] = DC_Main.MLc_code;
						dataRow8["CO_YEAR"] = DC_Main.MCo_year;
						dataRow8["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow8["VCH_NO"] = tVchNo.Text;
						dataRow8["SR_NO"] = DC_Main.i;
						dataRow8["AC_CODE"] = tAcCode.Text;
						dataRow8["VCH_DATE"] = mVchDate.Text;
						dataRow8["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow8["UPI_AC_CODE"] = MSG_UPI[DC_Main.i, 1];
						dataRow8["UPI_AC_NAME"] = MSG_UPI[DC_Main.i, 2];
						dataRow8["UPI_TYPE"] = MSG_UPI[DC_Main.i, 3];
						dataRow8["UPI_ID"] = MSG_UPI[DC_Main.i, 4];
						dataRow8["UPI_AMT"] = Conversion.Val(MSG_UPI[DC_Main.i, 5]);
						RsDetl.Rows.Add(dataRow8);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
					DC_Main.i++;
				}
				DC_Main.RsQry = "UPDATE SL_ORD_DETL  SET SL_ORD_DETL.TAG_SALE = 'Y'  FROM SL_ORD_DETL,LBR_ISU_DETL AS A WHERE SL_ORD_DETL.CO_CODE = A.CO_CODE AND SL_ORD_DETL.LC_CODE = A.LC_CODE AND SL_ORD_DETL.VCH_NO = A.ORD_NO AND SL_ORD_DETL.CO_YEAR = A.ORD_YRCD AND SL_ORD_DETL.CO_BOOK = A.ORD_DBCD AND SL_ORD_DETL.OLD_SRNO = A.ORD_SRNO  AND A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  AND A.VCH_NO ='" + tVchNo.Text + "'";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.LbrTran);
				DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.LbrTran);
				Ac_Ledr.Labour_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.LbrTran);
				Ac_Rojmel.Labour_RojMel(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.LbrTran);
				Ac_Stock.Labour_Stk(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.LbrTran);
				Ac_Tax.LbrWork_GST(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.LbrTran);
				Ac_Stock.Dm_Sale_Lbr_Detl(DC_Main.MCo_Book, tVchNo.Text);
				Module_Save.LbrTran.Commit();
				Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
				double num11 = 0.0;
				DC_Main.RsQry = "SELECT CO_YEAR,CO_BOOK,VCH_NO,SL_NET_AMT AS VCH_NET_AMT,TAX_AMT AS VCH_TAX_AMT,0 As VCH_DISC_AMT FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND TAX_AMT <> 0 ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["VCH_TAX_AMT"], (object)0, false), Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["VCH_NET_AMT"], (object)0, false))))
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_YEAR,CO_BOOK,VCH_NO,SR_NO,NET_AMT FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
						DataTable dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(NET_AMT) As ItTotal FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"' "));
						DataTable dataTable4 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (dataTable4.Rows.Count > 0)
						{
							num11 = Conversions.ToDouble(dataTable4.Rows[0]["ItTotal"]);
						}
						int num12 = 0;
						int num13 = dataTable3.Rows.Count - 1;
						for (num12 = 0; num12 <= num13; num12++)
						{
							if (Operators.ConditionalCompareObjectNotEqual(dataTable3.Rows[num12]["NET_AMT"], (object)0, false))
							{
								double num14 = Conversions.ToDouble(Operators.AddObject(dataTable3.Rows[num12]["NET_AMT"], Operators.MultiplyObject(Operators.DivideObject(dataTable3.Rows[num12]["NET_AMT"], (object)num11), Operators.SubtractObject(DC_Main.Rshlp.Rows[0]["VCH_NET_AMT"], (object)num11))));
								double num15 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
								{
									Operators.DivideObject(Operators.MultiplyObject((object)num14, DC_Main.Rshlp.Rows[0]["VCH_TAX_AMT"]), DC_Main.Rshlp.Rows[0]["VCH_NET_AMT"]),
									2
								}, (string[])null, (Type[])null, (bool[])null)), "0.000"));
								double num16 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
								{
									Operators.DivideObject(Operators.MultiplyObject((object)num14, DC_Main.Rshlp.Rows[0]["VCH_DISC_AMT"]), DC_Main.Rshlp.Rows[0]["VCH_NET_AMT"]),
									2
								}, (string[])null, (Type[])null, (bool[])null)), "0.000"));
								DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE LBR_ISU_DETL SET IT_TAX_AMT = " + Conversions.ToString(num15) + ",IT_NET_AMT =  " + Conversions.ToString(num14) + " ,IT_DISC_AMT =  " + Conversions.ToString(num16) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable3.Rows[num12]["CO_YEAR"]), (object)"' and CO_BOOK = '"), dataTable3.Rows[num12]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable3.Rows[num12]["VCH_NO"]), (object)"'  AND SR_NO = "), dataTable3.Rows[num12]["SR_NO"]), (object)"")));
							}
						}
					}
					else
					{
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DETL SET IT_TAX_AMT = 0 WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"'")));
					}
				}
				DC_Main.RsQry = "SELECT CO_YEAR,CO_BOOK,VCH_NO,DR_LBR AS LBR_NET_AMT,LBR_TAX_AMT AS LBR_TAX_AMT,LBR_DISC_AMT FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND LBR_TAX_AMT <> 0 ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["LBR_TAX_AMT"], (object)0, false), Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["LBR_NET_AMT"], (object)0, false))))
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_YEAR,CO_BOOK,VCH_NO,SR_NO,LBR_AMT FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
						DataTable dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT SUM(LBR_AMT) As ItTotal FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"' "));
						DataTable dataTable4 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (dataTable4.Rows.Count > 0)
						{
							num11 = Conversions.ToDouble(dataTable4.Rows[0]["ItTotal"]);
						}
						int num12 = 0;
						int num17 = dataTable3.Rows.Count - 1;
						for (num12 = 0; num12 <= num17; num12++)
						{
							if (Operators.ConditionalCompareObjectNotEqual(dataTable3.Rows[num12]["LBR_AMT"], (object)0, false))
							{
								double num14 = Conversions.ToDouble(Operators.AddObject(dataTable3.Rows[num12]["LBR_AMT"], Operators.MultiplyObject(Operators.DivideObject(dataTable3.Rows[num12]["LBR_AMT"], (object)num11), Operators.SubtractObject(DC_Main.Rshlp.Rows[0]["LBR_NET_AMT"], (object)num11))));
								double num15 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
								{
									Operators.DivideObject(Operators.MultiplyObject((object)num14, DC_Main.Rshlp.Rows[0]["LBR_TAX_AMT"]), DC_Main.Rshlp.Rows[0]["LBR_NET_AMT"]),
									2
								}, (string[])null, (Type[])null, (bool[])null)), "0.000"));
								double num16 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
								{
									Operators.DivideObject(Operators.MultiplyObject((object)num14, DC_Main.Rshlp.Rows[0]["LBR_DISC_AMT"]), DC_Main.Rshlp.Rows[0]["LBR_NET_AMT"]),
									2
								}, (string[])null, (Type[])null, (bool[])null)), "0.000"));
								DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE LBR_ISU_DETL SET IT_LBR_TAX = " + Conversions.ToString(num15) + ",IT_LBR_AMT =  " + Conversions.ToString(num14) + " ,IT_LBR_DISC =  " + Conversions.ToString(num16) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable3.Rows[num12]["CO_YEAR"]), (object)"' and CO_BOOK = '"), dataTable3.Rows[num12]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable3.Rows[num12]["VCH_NO"]), (object)"'  AND SR_NO = "), dataTable3.Rows[num12]["SR_NO"]), (object)"")));
							}
						}
					}
					else
					{
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DETL SET IT_LBR_TAX = 0 WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"'")));
					}
				}
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0 && Operators.CompareString(EntryMode, "E", false) == 0)
				{
					DC_Main.RsQry = "SELECT * FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
					RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.TableCol();
					string text = "";
					int num18 = RsData.Columns.Count - 2;
					DC_Main.M = 0;
					while (DC_Main.M <= num18)
					{
						if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(RsData.Rows[0][DC_Main.M], (object)""), Operators.ConcatenateObject(VchOldData.Rows[0][DC_Main.M], (object)""), false))
						{
							int num19 = DC_Main.RsTblCol.Rows.Count - 1;
							for (int j = 0; j <= num19; j++)
							{
								if (Operators.ConditionalCompareObjectEqual((object)RsData.Columns[DC_Main.M].ColumnName, DC_Main.RsTblCol.Rows[j]["TBL_COL_NAME"], false))
								{
									text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTblCol.Rows[j]["COL_NAME"], (object)""));
								}
							}
							if (Operators.CompareString(text, "", false) == 0)
							{
								text = RsData.Columns[DC_Main.M].ColumnName;
							}
							DC_Main.RsQry = "INSERT INTO USER_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,VCH_DATE,EDIT_DATE,ENTRY_TIME,USER_NAME,NEW_USER,BOOK_NAME,COL_TYPE,OLD_VAL,NEW_VAL,ENTRY_CHECK)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + tAcCode.Text + "','" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy hh:mm") + "','" + MainUser + "','" + DC_Main.MCo_User + "','" + FormMainBook + "','" + text + "','" + Strings.Mid(Conversions.ToString(VchOldData.Rows[0][DC_Main.M]), 1, 50) + "','" + Strings.Mid(Conversions.ToString(RsData.Rows[0][DC_Main.M]), 1, 50) + "','N')";
							DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							text = "";
						}
						DC_Main.M++;
					}
					DC_Main.RsTblCol.Clear();
				}
				if (Operators.CompareString(DC_Main.MsWappApiActive, "Y", false) == 0)
				{
					string path = "";
					string sSRegSrNo = DC_Main.SSRegSrNo;
					string tYPE = "greet";
					string mCo_Name = DC_Main.MCo_Name;
					string cUST_MO = DC_Main.MsCountryId + CustMobile;
					string text2 = tAcName.Text;
					string dEFULT_MESS = "Thank You";
					string text3 = mVchDate.Text;
					Module_Schm.PostapiWapp(path, sSRegSrNo, tYPE, mCo_Name, cUST_MO, text2, dEFULT_MESS, text3);
				}
				if (Operators.CompareString(FormVchNo, "", false) != 0)
				{
					CLEAR_DATA();
					((Form)this).Close();
					return;
				}
				CurPrnVch = tVchNo.Text;
				DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
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
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				try
				{
					Module_Save.LbrTran.Rollback();
					Interaction.MsgBox((object)("Error: " + ex2.Message), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					Interaction.MsgBox((object)("Rollback Failed: " + ex4.Message), (MsgBoxStyle)0, (object)null);
					ProjectData.ClearProjectError();
				}
				((Control)BtnSave).Enabled = true;
				ProjectData.ClearProjectError();
			}
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0a: Unknown result type (might be due to invalid IL or missing references)
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
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,0,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,A.AC_CODE,C.AC_NAME,TOT_DR_AMT,SL_CASH_AMT+SL_CARD_AMT+SL_CHQ_AMT,'A',DR_WT,CR_WT,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',SUBSTRING(VCH_DESC,1,149) FROM  (LBR_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE SL_ORD_DETL  SET SL_ORD_DETL.TAG_SALE = 'N'  FROM SL_ORD_DETL,LBR_ISU_DETL AS A WHERE SL_ORD_DETL.CO_CODE = A.CO_CODE AND SL_ORD_DETL.LC_CODE = A.LC_CODE AND SL_ORD_DETL.VCH_NO = A.ORD_NO AND SL_ORD_DETL.CO_YEAR = A.ORD_YRCD AND SL_ORD_DETL.CO_BOOK = A.ORD_DBCD AND SL_ORD_DETL.OLD_SRNO = A.ORD_SRNO  AND A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  AND A.VCH_NO ='" + tVchNo.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "SELECT * FROM CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND BILL_YRCD = '" + DC_Main.MCo_year + "' AND BILL_DBCD = '" + DC_Main.MCo_Book + "' AND BILL_NO = '" + tVchNo.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
				DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
				DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
				DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM CARD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
			}
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("Delete FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LBR_ISU_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_SALE_LBR_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 27)
		{
			return;
		}
		checked
		{
			if (((Control)TEXT_ENTRY).Visible)
			{
				MSG_LeaveCell(MSG, new EventArgs());
				MSG.Row = MSG.Rows - 1;
				if (MSG[1] == 0)
				{
					MSG.Col = 2;
				}
				else
				{
					MSG.Col = 1;
				}
				((Control)TEXT_ENTRY).Visible = false;
				MSG_TOT_FILL();
				MSG_PR.Row = 1;
				MSG_PR.Col = 1;
				MSG_PR_EnterCell(MSG_PR, new EventArgs());
				((Control)TEXT_PR).Focus();
			}
			else if (((Control)TEXT_PR).Visible)
			{
				MSG_PR_LeaveCell(MSG, new EventArgs());
				MSG_PR.Row = MSG_PR.Rows - 1;
				MSG_PR.Col = 1;
				((Control)TEXT_PR).Visible = false;
				MSG_PR_TOT_FILL();
				MSG_ORD.Row = 1;
				MSG_ORD.Col = 1;
				MSG_ORD_EnterCell(MSG_ORD, new EventArgs());
				((Control)TEXT_ORD).Focus();
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
		DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,DESIGN_IMG_ID,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,OLD_SRNO,'I',AC_CODE,IT_CODE,'',TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,ITM_REMARK,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT  FROM LBR_ISU_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,DESIGN_IMG_ID,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,'R',AC_CODE,IT_CODE,'',TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE,LESS_TOUCH,'',  '','','','',0,0,0,0  FROM LBR_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		if ((Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0) | chkWapp.Checked)
		{
			DC_Main.MsCustMail = "";
			DC_Main.MsCustWappNo = "";
			DC_Main.RsQry = "SELECT B.AC_EMAIL,B.AC_MOBILE FROM LBR_DATA AS A INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND  A.VCH_NO = '" + CurPrnVch + "' AND (B.AC_EMAIL <> '' OR B.AC_MOBILE <> '')";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				DC_Main.MsCustMail = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_EMAIL"], (object)""));
				DC_Main.MsCustWappNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)DC_Main.MsCountryId, DC_Main.Tbl.Rows[0]["AC_MOBILE"]), (object)""));
			}
			string rptName = ((Operators.CompareString(FormBookType, "T", false) != 0) ? "LabourWorkVch" : "LabourBillGst");
			DC_Main.RptName = rptName;
			DC_Main.MsWappOpAmt = Conversions.ToDouble(Strings.Format((object)CustOpAmt, "0.00"));
			DC_Main.MsWappClAmt = Conversions.ToDouble(Strings.Format((object)CustClAmt, "0.00"));
			DC_Main.MsWappOpGlFine = Conversions.ToDouble(Strings.Format((object)CustOpGold, "0.00"));
			DC_Main.MsWappClGlFine = Conversions.ToDouble(Strings.Format((object)CustClGold, "0.00"));
			DC_Main.MsWappOpSlFine = Conversions.ToDouble(Strings.Format((object)CustOpSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00"))));
			DC_Main.MsWappClSlFine = Conversions.ToDouble(Strings.Format((object)CustClSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00"))));
			DC_Main.MsWappPrintType = "LbrWork";
			DC_Main.RptFormula = "{LBR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LBR_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {LBR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {LBR_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {LBR_DATA.VCH_NO} = '" + CurPrnVch + "'";
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
		if (Operators.CompareString(FormBookType, "T", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\LabourBillGst.RPT";
			string rptName = "LabourBillGst";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\LabourWorkVch.RPT";
			string rptName = "LabourWorkVch";
		}
		Cr.SelectionFormula = "{LBR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {LBR_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {LBR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {LBR_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {LBR_DATA.VCH_NO} = '" + CurPrnVch + "'";
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

	private void TR_SALE_LBR_Activated(object sender, EventArgs e)
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
		if (DC_Main.MsCardSlAdj & (DC_Main.MsCardAdj != 0.0))
		{
			TEXT_ENTRY_2.Text = Strings.Format((object)DC_Main.MsCardAdj, "0.00");
			MSG2_TOTAL[10, 4] = Strings.Format((object)DC_Main.MsCardAdj, "0.00");
			MSG2_TOTAL[10, 2] = Strings.Format((object)DC_Main.MsCardAdjComm, "0.00");
			MSG2_TOTAL[10, 1] = DC_Main.MsCardBankName;
			MSG2_TOTAL[10, 5] = DC_Main.MsCardBank;
			DC_Main.MsCardAdj = 0.0;
			DC_Main.MsCardAdjComm = 0.0;
			DC_Main.MsCardBankName = "";
			DC_Main.MsCardBank = "";
			((Control)TEXT_ENTRY_2).Focus();
		}
		else
		{
			DC_Main.MsCardSlAdj = false;
			((ContainerControl)this).ActiveControl = CurActCtrl;
			CurActCtrl.Focus();
		}
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL FROM LBR_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 250.0;
		DC_Main.ColWidth[4] = 100.0;
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void MSG_RowColChange(object sender, EventArgs e)
	{
		//IL_0c7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c85: Expected O, but got Unknown
		//IL_0b36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b40: Expected O, but got Unknown
		//IL_09f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fe: Expected O, but got Unknown
		//IL_0e16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e20: Expected O, but got Unknown
		if (MSG.Row == 0)
		{
			return;
		}
		checked
		{
			if ((MsgOldRow != MSG.Row) & !MsgClear)
			{
				MsgOldRow = MSG.Row;
				lblItem.Text = MSG[MSG.Row, 3] + " : It Name";
				nItmRate.Text = Strings.Format((object)Conversion.Val(MSG[MSG.Row, 36]), "0.00");
				MSG_IDTL_CLEAR();
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				int num4 = 1;
				int num5 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num5; i++)
				{
					if (Conversion.Val(MSG[MSG.Row, 21]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23])))
					{
						MSG_IDTL[num4, 0] = Conversions.ToString(num4);
						MSG_IDTL[num4, 1] = Conversions.ToString(DtIdtl.Rows[i][1]);
						MSG_IDTL[num4, 2] = Conversions.ToString(DtIdtl.Rows[i][2]);
						MSG_IDTL[num4, 3] = Conversions.ToString(DtIdtl.Rows[i][3]);
						MSG_IDTL[num4, 4] = Conversions.ToString(DtIdtl.Rows[i][4]);
						MSG_IDTL[num4, 5] = Conversions.ToString(DtIdtl.Rows[i][5]);
						MSG_IDTL[num4, 6] = Conversions.ToString(DtIdtl.Rows[i][6]);
						MSG_IDTL[num4, 7] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][7], (object)""));
						MSG_IDTL[num4, 8] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][8], (object)""));
						MSG_IDTL[num4, 9] = Conversions.ToString(DtIdtl.Rows[i][9]);
						MSG_IDTL[num4, 10] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][10], (object)""));
						MSG_IDTL[num4, 12] = Conversions.ToString(DtIdtl.Rows[i][12]);
						MSG_IDTL[num4, 11] = Conversions.ToString(DtIdtl.Rows[i][11]);
						MSG_IDTL[num4, 13] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][13], (object)""));
						MSG_IDTL[num4, 14] = Conversions.ToString(DtIdtl.Rows[i][14]);
						MSG_IDTL[num4, 15] = Conversions.ToString(DtIdtl.Rows[i][15]);
						MSG_IDTL[num4, 16] = Conversions.ToString(DtIdtl.Rows[i][16]);
						MSG_IDTL[num4, 17] = Conversions.ToString(DtIdtl.Rows[i][17]);
						MSG_IDTL[num4, 18] = Conversions.ToString(DtIdtl.Rows[i][18]);
						MSG_IDTL[num4, 19] = Conversions.ToString(DtIdtl.Rows[i][19]);
						MSG_IDTL[num4, 20] = Conversions.ToString(DtIdtl.Rows[i][20]);
						MSG_IDTL[num4, 21] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][21], (object)""));
						MSG_IDTL[num4, 22] = Conversions.ToString(DtIdtl.Rows[i][22]);
						MSG_IDTL[num4, 23] = Conversions.ToString(DtIdtl.Rows[i][23]);
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]));
						num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]));
						num3 += Conversion.Val(Operators.ConcatenateObject(DtIdtl.Rows[i][21], (object)""));
						MSG_IDTL.Rows += 1;
						num4++;
					}
				}
				if (num2 != 0.0)
				{
					MSG[MSG.Row, 8] = Strings.Format((object)num2, "0.000");
					MSG[MSG.Row, 9] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 7]) - Conversion.Val(MSG[MSG.Row, 8])), "0.000");
				}
				if (num3 != 0.0)
				{
					MSG[MSG.Row, 30] = Strings.Format((object)num3, "0.000");
					MSG[MSG.Row, 31] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 7]) - Conversion.Val(MSG[MSG.Row, 30])), "0.000");
				}
				if (num != 0.0)
				{
					MSG[MSG.Row, 19] = Strings.Format((object)num, "0.00");
				}
				CommPassTotal();
				PicImage.Image = null;
				if ((Operators.CompareString(MSG[MSG.Row, 37], "N", false) != 0) & (Operators.CompareString(MSG[MSG.Row, 4], "", false) != 0))
				{
					DC_Main.MsImageNo = MSG[MSG.Row, 37];
					DC_Main.MsImageType = "TagImage";
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						Image image;
						using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
						{
							image = Image.FromStream(stream);
						}
						PicImage.Image = image;
					}
					else
					{
						DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 37] + "' AND IMAGE_TYPE = 'D'";
						DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
						if (dataTable.Rows.Count > 0)
						{
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
							{
								PicImage.Image = null;
								return;
							}
							object obj = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
							byte[] bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj));
							object objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
							PicImage.Image = (Image)objectValue;
						}
					}
				}
				else
				{
					DC_Main.MsImageNo = MSG[MSG.Row, 1] + "_" + MSG[MSG.Row, 25];
					DC_Main.MsImageType = "TagImage";
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
					{
						try
						{
							string address = ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"));
							PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
						}
						catch (Exception ex)
						{
							ProjectData.SetProjectError(ex);
							Exception ex2 = ex;
							DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 25]))) ?? "";
							DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
							if (dataTable.Rows.Count > 0)
							{
								if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
								{
									PicImage.Image = null;
									ProjectData.ClearProjectError();
									return;
								}
								object obj2 = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
								byte[] bA2 = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj2));
								object objectValue2 = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA2));
								PicImage.Image = (Image)objectValue2;
							}
							else if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
							{
								Image image2;
								using (Stream stream2 = File.OpenRead(DC_Main.MsImagePath))
								{
									image2 = Image.FromStream(stream2);
								}
								PicImage.Image = image2;
							}
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 25]))) ?? "";
						DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
						if (dataTable.Rows.Count > 0)
						{
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
							{
								PicImage.Image = null;
								return;
							}
							object obj3 = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
							byte[] bA3 = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj3));
							object objectValue3 = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA3));
							PicImage.Image = (Image)objectValue3;
						}
						else if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
						{
							Image image3;
							using (Stream stream3 = File.OpenRead(DC_Main.MsImagePath))
							{
								image3 = Image.FromStream(stream3);
							}
							PicImage.Image = image3;
						}
					}
				}
				MSG_IDTL[num4, 0] = Conversions.ToString(num4);
				MSG_IDTL[num4, 23] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 21]));
			}
			if ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) & (Operators.CompareString(DC_Main.MsBillProfit, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0))
			{
				ItmProfit(MSG.Row);
			}
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
				DC_Main.RsQry = "SELECT VCH_NO FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM LBR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void PicImage_DoubleClick(object sender, EventArgs e)
	{
		PicZoom.Image = PicImage.Image;
		((Control)PicZoom).Left = ((Control)this).Left;
		((Control)PicZoom).Top = ((Control)this).Top;
		((Control)PicZoom).Width = ((Control)this).Width;
		((Control)PicZoom).Height = ((Control)this).Height;
		((Control)PicZoom).BringToFront();
		((Control)PicZoom).Visible = true;
	}

	private void PicZoom_DoubleClick(object sender, EventArgs e)
	{
		PicZoom.Image = null;
		((Control)PicZoom).Dock = (DockStyle)0;
		((Control)PicZoom).Visible = false;
	}

	private void MSG_Scroll(object sender, EventArgs e)
	{
		if (MSG_TOT.LeftCol != MSG.LeftCol)
		{
			MSG_TOT.LeftCol = MSG.LeftCol;
			MSG_TOT.ScrollTrack = MSG.LeftCol != 0;
		}
	}

	private void TR_SALE_LBR_Closed(object sender, EventArgs e)
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
				return;
			}
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tAcCode.Text = DC_Main.ColValue[1];
				tAcName.Text = DC_Main.ColValue[0];
				CustMobile = DC_Main.ColValue[6];
			}
			((Control)tAcCode).Focus();
			return;
		}
		if (Operators.CompareString(tAcCode.Text, OldAcCode, false) != 0)
		{
			OldAcCode = tAcCode.Text;
			CustMobile = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MOBILE"], (object)""));
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
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
		MSG.Col = 1;
		MSG.Row = 1;
		MSG_EnterCell(MSG, new EventArgs());
		((Control)TEXT_ENTRY).Focus();
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
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM LBR_DATA WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
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
		mSG2_TOTAL.Rows = 15;
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
			mSG2_TOTAL[6] = 0;
			DC_Main.i = 0;
			do
			{
				mSG2_TOTAL.Row = DC_Main.i;
				mSG2_TOTAL[DC_Main.i] = (int)Math.Round(308.0 * ColCon);
				if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
				{
					mSG2_TOTAL[6] = 0;
					mSG2_TOTAL[9] = 0;
				}
				else
				{
					mSG2_TOTAL[3] = 0;
					mSG2_TOTAL[4] = 0;
				}
				switch (DC_Main.i)
				{
				case 1:
				case 8:
				case 14:
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
				case 2:
				case 4:
				case 6:
				case 7:
				{
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					AxMSFlexGrid obj7 = mSG2_TOTAL;
					object? obj8 = colorConverter.ConvertFromString("DarkBlue");
					obj7.CellForeColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
					break;
				}
				case 0:
				case 3:
				case 5:
				case 11:
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
			while (DC_Main.i <= 14);
			mSG2_TOTAL[0, 3] = "Payment    ";
			mSG2_TOTAL[0, 4] = "Received    ";
			mSG2_TOTAL[1, 0] = "Net Amt : ";
			mSG2_TOTAL[2, 0] = "Sale Tax : ";
			mSG2_TOTAL[3, 0] = "Oth Amt : ";
			mSG2_TOTAL[4, 0] = "Oth Tax : ";
			mSG2_TOTAL[5, 0] = "Lbr Amt : ";
			mSG2_TOTAL[6, 0] = "Lbr Disc : ";
			mSG2_TOTAL[7, 0] = "Lbr Tax : ";
			mSG2_TOTAL[8, 0] = "Total Amt : ";
			mSG2_TOTAL[9, 0] = "Cheque Amt : ";
			mSG2_TOTAL[10, 0] = "Card Amt : ";
			mSG2_TOTAL[11, 0] = "Order Amt : ";
			mSG2_TOTAL[12, 0] = "Cash Amt : ";
			mSG2_TOTAL[13, 0] = "Kasar Amt : ";
			mSG2_TOTAL[14, 0] = "Os Amt : ";
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
				if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 8) | (mSG2_TOTAL.Row == 14))
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
				if ((mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 10))
				{
					TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				}
				else
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 8) | (mSG2_TOTAL.Row == 14) | (mSG2_TOTAL.Row == 2))
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
				if ((Operators.CompareString(DC_Main.MsEstmateBankLock, "Y", false) == 0) & (Operators.CompareString(FormBookType, "T", false) != 0))
				{
					if ((mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 10))
					{
						((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
					}
				}
				else if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 8) | (mSG2_TOTAL.Row == 14))
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
				if ((Operators.CompareString(DC_Main.MsEstmateBankLock, "Y", false) == 0) & (Operators.CompareString(FormBookType, "T", false) != 0))
				{
					if ((mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 10))
					{
						((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
					}
				}
				else if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 8) | (mSG2_TOTAL.Row == 14))
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
			if ((mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 10))
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
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Invalid comparison between Unknown and I4
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a23: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		Keys keyCode = e.KeyCode;
		checked
		{
			if (unchecked((int)keyCode) != 13)
			{
				switch (unchecked(keyCode - 37))
				{
				default:
					if (unchecked((int)keyCode) != 112 || mSG2_TOTAL.Row != 12 || MSG2_TOTAL.Col != 1)
					{
						break;
					}
					((Control)PnlUpi).Visible = true;
					MSG_UPI.Row = MSG_UPI.Rows - 1;
					MSG_UPI.Col = 1;
					MSG_UPI_EnterCell(MSG_UPI, new EventArgs());
					((Control)TEXT_ENTRY_2).Visible = false;
					((Control)TEXT_UPI).Focus();
					return;
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
					if (((mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 10)) && Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_NAME = '" + TEXT_ENTRY_2.Text + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (mSG2_TOTAL.Row == 9)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '02','22','03','23')  ORDER BY A.AC_NAME";
							}
							else if (mSG2_TOTAL.Row == 10)
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
					if ((mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 4))
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
								if (DC_Main.HelpClose)
								{
									return;
								}
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_ENTRY_2.Text = DC_Main.ColValue[0];
									mSG2_TOTAL[mSG2_TOTAL.Row, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.00");
									mSG2_TOTAL[mSG2_TOTAL.Row, 5] = DC_Main.ColValue[2];
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
								if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
								{
									if (mSG2_TOTAL.Row == 2)
									{
										mSG2_TOTAL.Row = 4;
									}
									else
									{
										mSG2_TOTAL.Row = 7;
									}
									mSG2_TOTAL.Col = 1;
								}
								else
								{
									mSG2_TOTAL.Row = 6;
									mSG2_TOTAL.Col = 4;
								}
								((Control)TEXT_ENTRY_2).Focus();
								return;
							}
							mSG2_TOTAL[mSG2_TOTAL.Row, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00");
							double num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00"));
							mSG2_TOTAL[mSG2_TOTAL.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
							{
								if (mSG2_TOTAL.Row == 2)
								{
									mSG2_TOTAL.Row = 4;
								}
								else
								{
									mSG2_TOTAL.Row = 7;
								}
								mSG2_TOTAL.Col = 1;
							}
							else
							{
								mSG2_TOTAL.Row = 6;
								mSG2_TOTAL.Col = 4;
							}
							((Control)TEXT_ENTRY_2).Focus();
							return;
						}
						if (Operators.CompareString(DC_Main.MCo_BookType, "T", false) != 0)
						{
							TEXT_ENTRY_2.Text = "TAX FREE";
							mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "TAX FREE";
							mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "0.00";
							mSG2_TOTAL[mSG2_TOTAL.Row, 5] = "00";
						}
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
						{
							if (mSG2_TOTAL.Row == 2)
							{
								mSG2_TOTAL.Row = 4;
							}
							else
							{
								mSG2_TOTAL.Row = 7;
							}
							mSG2_TOTAL.Col = 1;
						}
						else
						{
							mSG2_TOTAL.Row = 6;
							mSG2_TOTAL.Col = 4;
						}
						((Control)TEXT_ENTRY_2).Focus();
						return;
					}
					if (mSG2_TOTAL.Row != 7)
					{
						break;
					}
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
									mSG2_TOTAL[7, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.00");
									mSG2_TOTAL[7, 5] = DC_Main.ColValue[2];
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
								if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
								{
									mSG2_TOTAL.Row = 10;
									mSG2_TOTAL.Col = 4;
								}
								else
								{
									mSG2_TOTAL.Row = 9;
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
							if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
							{
								mSG2_TOTAL.Row = 10;
								mSG2_TOTAL.Col = 4;
							}
							else
							{
								mSG2_TOTAL.Row = 9;
								mSG2_TOTAL.Col = 4;
							}
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
							mSG2_TOTAL[mSG2_TOTAL.Row, 5] = "00";
						}
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
						{
							mSG2_TOTAL.Row = 10;
							mSG2_TOTAL.Col = 4;
						}
						else
						{
							mSG2_TOTAL.Row = 9;
							mSG2_TOTAL.Col = 4;
						}
						((Control)TEXT_ENTRY_2).Focus();
					}
					return;
				case 3:
					switch (mSG2_TOTAL.Row)
					{
					case 12:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 11:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 9:
					case 10:
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
					case 13:
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
					mSG2_TOTAL.Row = mSG2_TOTAL.Row;
					switch (mSG2_TOTAL.Row)
					{
					case 2:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
						{
							mSG2_TOTAL.Row = 4;
							mSG2_TOTAL.Col = 1;
						}
						else
						{
							mSG2_TOTAL.Row += 1;
							mSG2_TOTAL.Col = 4;
						}
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 12:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 4;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 11:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 4;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 10:
						if ((Operators.CompareString(DC_Main.MsCardComAdj, "Y", false) == 0) & (Operators.CompareString(FormBookType, "T", false) == 0))
						{
							if (Conversion.Val(TEXT_ENTRY_2.Text) == 0.0)
							{
								break;
							}
							if (!DC_Main.MsCardSlAdj & (OldCardAmt != Conversion.Val(TEXT_ENTRY_2.Text)) & (Operators.CompareString(tAcCode.Text, "00045", false) != 0))
							{
								OldCardAmt = Conversions.ToDouble(Strings.Format((object)Conversion.Val(TEXT_ENTRY_2.Text), "0.00"));
								DC_Main.MsSlBill = tVchNo.Text;
								DC_Main.MsSlAcCode = tAcCode.Text;
								DC_Main.MsSlYrCd = DC_Main.MCo_year;
								DC_Main.MsSlDbCd = DC_Main.MCo_Book;
								DC_Main.MsSlAmt = Conversion.Val(mSG2_TOTAL[8, 4]);
								DC_Main.MsCardSlAdj = true;
								DC_Main.CurBookHelp("CARD ADJUST");
								if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
								{
									TR_CARD_REC tR_CARD_REC = new TR_CARD_REC();
									((Form)tR_CARD_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
									DC_Main.TotOpenForm++;
									((Form)tR_CARD_REC).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
									((Control)tR_CARD_REC).Show();
									((Control)tR_CARD_REC).Focus();
								}
							}
							else
							{
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								BILL_TOTAL();
								mSG2_TOTAL.Row += 1;
								mSG2_TOTAL.Col = 4;
								((Control)TEXT_ENTRY_2).Visible = true;
								((Control)TEXT_ENTRY_2).Focus();
							}
							return;
						}
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
					case 9:
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
					case 13:
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
			nDrRate.Text = Strings.Format((object)Math.Round(Conversion.Val(nConvRate.Text) / Conversion.Val(nConvPrc.Text) * 100.0, 2), "0.00");
		}
		else if (Conversion.Val(nConvRate.Text) != 0.0)
		{
			nDrRate.Text = Strings.Format((object)Conversion.Val(nConvRate.Text), "0.00");
		}
		nTotWtDr.Text = Strings.Format((object)Conversion.Val(MSG_TOT[0, 14]), "0.000");
		nTotWtCr.Text = Strings.Format((object)Conversion.Val(MSG_PR_TOT[0, 8]), "0.000");
		mSG2_TOTAL[11, 4] = "";
		nOrdWt.Text = "";
		checked
		{
			int num = MSG_ORD.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num)
			{
				mSG2_TOTAL[11, 4] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[11, 4]) + Conversion.Val(MSG_ORD[DC_Main.M, 3])), "0.00");
				nOrdWt.Text = Strings.Format((object)(Conversion.Val(nOrdWt.Text) + Conversion.Val(MSG_ORD[DC_Main.M, 2])), "0.000");
				DC_Main.M++;
			}
			if (Conversion.Val(nTotWtDr.Text) > Conversion.Val(nTotWtCr.Text) + Conversion.Val(nOrdWt.Text))
			{
				nDrFine.Text = Strings.Format((object)(Conversion.Val(nTotWtDr.Text) - (Conversion.Val(nTotWtCr.Text) + Conversion.Val(nOrdWt.Text))), "0.000");
			}
			else
			{
				nDrFine.Text = "";
				nDrAmt.Text = "";
			}
			if (Conversion.Val(nTotWtDr.Text) < Conversion.Val(nTotWtCr.Text) + Conversion.Val(nOrdWt.Text))
			{
				nCrFine.Text = Strings.Format((object)(Conversion.Val(nTotWtCr.Text) + Conversion.Val(nOrdWt.Text) - Conversion.Val(nTotWtDr.Text)), "0.000");
			}
			else
			{
				nCrFine.Text = "";
				nCrAmt.Text = "";
			}
			if ((Conversion.Val(nDrRate.Text) != 0.0) & (Conversion.Val(nCrFine.Text) != 0.0))
			{
				if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
				{
					nCrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nCrFine.Text) * (Conversion.Val(nDrRate.Text) / 10.0), 0), "0.00");
				}
				else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
				{
					nCrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nCrFine.Text) * (Conversion.Val(nDrRate.Text) / 1000.0), 0), "0.00");
				}
				else
				{
					nCrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nCrFine.Text) * Conversion.Val(nDrRate.Text), 1), "0.00");
				}
			}
			else
			{
				nCrAmt.Text = "";
			}
			if ((Conversion.Val(nDrRate.Text) != 0.0) & (Conversion.Val(nDrFine.Text) != 0.0))
			{
				if (Operators.CompareString(DC_Main.MsRatePar, "T", false) == 0)
				{
					nDrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nDrFine.Text) * (Conversion.Val(nDrRate.Text) / 10.0), 0), "0.00");
				}
				else if (Operators.CompareString(DC_Main.MsRatePar, "K", false) == 0)
				{
					nDrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nDrFine.Text) * (Conversion.Val(nDrRate.Text) / 1000.0), 0), "0.00");
				}
				else
				{
					nDrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nDrFine.Text) * Conversion.Val(nDrRate.Text), 1), "0.00");
				}
			}
			else
			{
				nDrAmt.Text = "";
			}
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				mSG2_TOTAL[1, 4] = Strings.Format((object)Math.Round(Conversion.Val(nDrAmt.Text), 0), "0.00");
				mSG2_TOTAL[3, 4] = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 19]), 0), "0.00");
			}
			else
			{
				mSG2_TOTAL[1, 4] = Strings.Format((object)Math.Round(Conversion.Val(nDrAmt.Text) + Conversion.Val(MSG_TOT[0, 19]), 0), "0.00");
			}
			mSG2_TOTAL[1, 3] = Strings.Format((object)Math.Round(Conversion.Val(nCrAmt.Text), 0), "0.00");
			if ((Conversion.Val(mSG2_TOTAL[1, 4]) != 0.0) & (Conversion.Val(mSG2_TOTAL[2, 2]) != 0.0))
			{
				mSG2_TOTAL[2, 4] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[1, 4]) * Conversion.Val(mSG2_TOTAL[2, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
			}
			else
			{
				mSG2_TOTAL[2, 4] = "";
			}
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				if ((Conversion.Val(mSG2_TOTAL[3, 4]) != 0.0) & (Conversion.Val(mSG2_TOTAL[4, 2]) != 0.0))
				{
					mSG2_TOTAL[4, 4] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[3, 4]) * Conversion.Val(mSG2_TOTAL[4, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
				}
				else
				{
					mSG2_TOTAL[4, 4] = "";
				}
			}
			mSG2_TOTAL[5, 4] = Strings.Format((object)Conversion.Val(MSG_TOT[0, 18]), "0.00");
			if ((Conversion.Val(mSG2_TOTAL[5, 4]) != 0.0) & (Conversion.Val(mSG2_TOTAL[6, 2]) != 0.0))
			{
				mSG2_TOTAL[6, 4] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[5, 4]) * Conversion.Val(mSG2_TOTAL[6, 2]) / 100.0, 0), "0.00");
			}
			if ((Conversion.Val(mSG2_TOTAL[5, 4]) != 0.0) & (Conversion.Val(mSG2_TOTAL[7, 2]) != 0.0))
			{
				mSG2_TOTAL[7, 4] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[5, 4]) - Conversion.Val(mSG2_TOTAL[6, 4])) * Conversion.Val(mSG2_TOTAL[7, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
			}
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				mSG2_TOTAL[8, 4] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[1, 4]) + Conversion.Val(mSG2_TOTAL[2, 4]) + Conversion.Val(mSG2_TOTAL[3, 4]) + Conversion.Val(mSG2_TOTAL[4, 4]) + Conversion.Val(mSG2_TOTAL[5, 4]) + Conversion.Val(mSG2_TOTAL[7, 4])), "0.00");
				mSG2_TOTAL[8, 3] = Strings.Format((object)Conversion.Val(mSG2_TOTAL[1, 3]), "0.00");
			}
			else
			{
				mSG2_TOTAL[8, 4] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[1, 4]) + Conversion.Val(mSG2_TOTAL[2, 4]) + Conversion.Val(mSG2_TOTAL[5, 4]) + Conversion.Val(mSG2_TOTAL[7, 4]) - Conversion.Val(mSG2_TOTAL[6, 4]), 0), "0.00");
				mSG2_TOTAL[8, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[1, 3]), 0), "0.00");
			}
			mSG2_TOTAL[14, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[12, 3]) - Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[10, 3]) - Conversion.Val(mSG2_TOTAL[13, 3])), "0.00");
			mSG2_TOTAL[14, 4] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[8, 4]) - Conversion.Val(mSG2_TOTAL[12, 1]) - Conversion.Val(mSG2_TOTAL[11, 4]) - Conversion.Val(mSG2_TOTAL[12, 4]) - Conversion.Val(mSG2_TOTAL[9, 4]) - Conversion.Val(mSG2_TOTAL[10, 4]) - Conversion.Val(mSG2_TOTAL[13, 4]) + Conversion.Val(mSG2_TOTAL[10, 2])), "0.00");
			if (Conversion.Val(mSG2_TOTAL[14, 3]) > Conversion.Val(mSG2_TOTAL[14, 4]))
			{
				lblDiffAmt.Text = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[14, 3]) - Conversion.Val(mSG2_TOTAL[14, 4])), "0.00") + "  Pay";
			}
			else if (Conversion.Val(mSG2_TOTAL[14, 3]) < Conversion.Val(mSG2_TOTAL[14, 4]))
			{
				lblDiffAmt.Text = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[14, 4]) - Conversion.Val(mSG2_TOTAL[14, 3])), "0.00") + "  Rec";
			}
			else
			{
				lblDiffAmt.Text = ".";
			}
			if (CustOpAmt > 0.0)
			{
				CustClAmt = CustOpAmt + Conversion.Val(mSG2_TOTAL[14, 3]) - Conversion.Val(mSG2_TOTAL[14, 4]);
			}
			else if (CustOpAmt < 0.0)
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[14, 3]) - (Math.Abs(CustOpAmt) + Conversion.Val(mSG2_TOTAL[14, 4]));
			}
			else
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[14, 3]) - Conversion.Val(mSG2_TOTAL[14, 4]);
			}
			if (cboItemTyp.SelectedIndex == 0)
			{
				if (CustOpGold > 0.0)
				{
					if (Conversion.Val(nOrdWt.Text) != 0.0)
					{
						if (Conversion.Val(nDrRate.Text) != 0.0)
						{
							CustClGold = CustOpGold - (Conversion.Val(nDrFine.Text) + Conversion.Val(nOrdWt.Text));
						}
						else
						{
							CustClGold = CustOpGold + Conversion.Val(nCrFine.Text) - (Conversion.Val(nDrFine.Text) + Conversion.Val(nOrdWt.Text));
						}
					}
					else
					{
						CustClGold = CustOpGold + Conversion.Val(nCrFine.Text) - Conversion.Val(nDrFine.Text);
					}
				}
				else if (CustOpGold < 0.0)
				{
					CustClGold = Conversion.Val(nCrFine.Text) - (Math.Abs(CustOpGold) + Conversion.Val(nDrFine.Text));
				}
				else
				{
					CustClGold = Conversion.Val(nCrFine.Text) - Conversion.Val(nDrFine.Text);
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
					if (Conversion.Val(nOrdWt.Text) != 0.0)
					{
						CustClSilver = CustOpSilver + Conversion.Val(nCrFine.Text) - (Conversion.Val(nDrFine.Text) + Conversion.Val(nOrdWt.Text));
					}
					else
					{
						CustClSilver = CustOpSilver + Conversion.Val(nCrFine.Text) - Conversion.Val(nDrFine.Text);
					}
				}
				else if (CustOpSilver < 0.0)
				{
					CustClSilver = Conversion.Val(nCrFine.Text) - (Math.Abs(CustOpSilver) + Conversion.Val(nDrFine.Text));
				}
				else
				{
					CustClSilver = Conversion.Val(nCrFine.Text) - Conversion.Val(nDrFine.Text);
				}
			}
			else
			{
				CustClSilver = CustOpSilver;
			}
			if ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) & (Operators.CompareString(DC_Main.MsBillProfit, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0))
			{
				double num2 = 0.0;
				int num3 = MSG.Rows - 1;
				for (int i = 0; i <= num3; i++)
				{
					num2 += Conversion.Val(MSG[i, 55]);
				}
				nBillProfit.Text = Strings.Format((object)num2, "0.00");
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
		if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
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
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if ((int)Interaction.MsgBox((object)"Creat New Addres ?", (MsgBoxStyle)292, (object)null) == 6)
		{
			if ((int)e.KeyCode == 13)
			{
				SendKeys.Send("{TAB}");
			}
			return;
		}
		if (MSG[1] == 0)
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

	private void nCrAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nCrAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nCrAmt.Text)), "0.00");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nDrAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nDrAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDrAmt.Text)), "0.00");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nCrFine_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nCrFine.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nCrFine.Text)), "0.000");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nDrFine_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nDrFine.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDrFine.Text)), "0.000");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nDrRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nDrRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDrRate.Text)), "0.00");
			BILL_TOTAL();
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
			((Control)tAcCode).Focus();
		}
	}

	private void TEXT_ENTRY_2_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)TEXT_ENTRY_2).SelectionStart = 0;
		((TextBoxBase)TEXT_ENTRY_2).SelectionLength = Strings.Len(TEXT_ENTRY_2.Text);
	}

	private void tVchNo_DoubleClick(object sender, EventArgs e)
	{
		((TextBoxBase)tVchNo).ReadOnly = false;
	}

	private void TR_SALE_LBR_KeyUp(object sender, KeyEventArgs e)
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
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Invalid comparison between Unknown and I4
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Invalid comparison between Unknown and I4
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Invalid comparison between Unknown and I4
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Invalid comparison between Unknown and I4
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Invalid comparison between Unknown and I4
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Invalid comparison between Unknown and I4
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Invalid comparison between Unknown and I4
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Invalid comparison between Unknown and I4
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Invalid comparison between Unknown and I4
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Invalid comparison between Unknown and I4
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
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ORD", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_ORD).SelectionStart = 0;
			((TextBoxBase)TEXT_ORD).SelectionLength = Strings.Len(TEXT_ORD.Text);
		}
	}

	private void tVchDesc_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
	}

	private void ItmProfit(int Row)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		AxMSFlexGrid mSG = MSG;
		if (Operators.CompareString(mSG[Row, 26], "G", false) == 0)
		{
			num = ToDayGlRate;
		}
		else if (Operators.CompareString(mSG[Row, 26], "S", false) == 0)
		{
			num = ToDaySlRate;
		}
		if (Conversion.Val(mSG[Row, 29]) != 0.0)
		{
			nItProfit.Text = "PrCost = " + Strings.Format((object)Conversion.Val(mSG[Row, 35]), "0.00") + " / " + Strings.Format((object)(Conversion.Val(mSG[Row, 20]) - Conversion.Val(mSG[Row, 35])), "0.00");
			mSG[Row, 55] = Conversions.ToString(Conversion.Val(mSG[Row, 20]) - Conversion.Val(mSG[Row, 35]));
		}
		else if ((Conversion.Val(mSG[Row, 34]) != 0.0) & (Operators.CompareString(mSG[Row, 1], "", false) != 0))
		{
			double num4 = Conversion.Val(mSG[Row, 35]);
			num2 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(mSG[Row, 34]) * num + Conversion.Val(mSG[Row, 56]) + Conversion.Val(mSG[Row, 57])), "0.00"));
			num3 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(mSG[Row, 14]) * num + Conversion.Val(mSG[Row, 18]) + Conversion.Val(mSG[Row, 19])), "0.00"));
			nItProfit.Text = "Kf = " + mSG[Row, 34] + "  Fr = " + Conversions.ToString(num) + "  Ko = " + Strings.Format((object)Conversion.Val(mSG[Row, 35]), "0.00") + " = " + Conversions.ToString(num2) + " / " + Strings.Format((object)(num3 - num2), "0.00");
			mSG[Row, 55] = Conversions.ToString(num3 - num2);
		}
		else
		{
			double num5 = 0.0;
			DC_Main.RsQry = "SELECT AVG_TOUCH FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + mSG[Row, 2] + "' AND AVG_TOUCH <> 0";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				if (Conversion.Val(mSG[Row, 9]) != 0.0)
				{
					num5 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(mSG[Row, 9]) * Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AVG_TOUCH"])) / 100.0), "0.000"));
					num2 = Conversions.ToDouble(Strings.Format((object)(num5 * num), "0.00"));
					num3 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(mSG[Row, 14]) * num + Conversion.Val(mSG[Row, 18]) + Conversion.Val(mSG[Row, 19])), "0.00"));
					nItProfit.Text = "Kf = " + Conversions.ToString(num5) + "  Fr = " + Conversions.ToString(num) + " = " + Conversions.ToString(num2) + " / " + Strings.Format((object)(num3 - num2), "0.00");
					mSG[Row, 55] = Conversions.ToString(num3 - num2);
				}
			}
			else
			{
				nItProfit.Text = "It Profit :";
			}
		}
		if (!(((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) & (Operators.CompareString(DC_Main.MsBillProfit, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0)) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM244NEKU", false) == 0)))
		{
			nItProfit.Text = "";
		}
		mSG = null;
	}

	private void TodayFineRate()
	{
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		DataTable dataTable = default(DataTable);
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
					goto IL_000b;
				case 604:
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
							goto IL_000b;
						case 3:
							goto IL_006f;
						case 4:
							goto IL_007c;
						case 5:
							goto IL_0095;
						case 6:
							goto IL_00b3;
						case 7:
							goto IL_0112;
						case 9:
							goto IL_0178;
						case 10:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 8:
						case 11:
						case 12:
						case 13:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_00b3:
					num2 = 6;
					ToDayGlRate = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FINE_GL_RATE"], (object)"")) / 103.0 * 100.0 / 10.0), "0.00"));
					goto IL_0112;
					IL_0112:
					num2 = 7;
					ToDaySlRate = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FINE_SL_RATE"], (object)"")) / 103.0 * 100.0 / 1000.0), "0.00"));
					goto end_IL_0001_3;
					IL_0095:
					num2 = 5;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0)
					{
						goto IL_00b3;
					}
					goto IL_0178;
					IL_0178:
					num2 = 9;
					ToDayGlRate = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FINE_GL_RATE"], (object)"")) / 10.0), "0.00"));
					break;
					IL_000b:
					num2 = 2;
					DC_Main.RsQry = "SELECT TOP(1) FINE_GL_RATE,FINE_SL_RATE,VCH_DATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND SR_NO = 1  ORDER BY VCH_DATE DESC";
					goto IL_006f;
					IL_006f:
					num2 = 3;
					dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_007c;
					IL_007c:
					num2 = 4;
					if (dataTable.Rows.Count <= 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_0095;
					end_IL_0001_2:
					break;
				}
				num2 = 10;
				ToDaySlRate = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FINE_SL_RATE"], (object)"")) / 1000.0), "0.00"));
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 604;
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
		if ((int)e.KeyCode == 13)
		{
			nConvRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nConvRate.Text)), "0.00");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}
}
